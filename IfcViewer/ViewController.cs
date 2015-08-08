using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using IfcEngineCS;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Point = System.Drawing.Point;

namespace IFCViewer
{
    /// <summary>
    /// IFCItem presents a single ifc item for drawing 
    /// </summary>
    class IFCItem
    {
        public void CreateItem(IFCItem parent, IntPtr ifcID, string ifcType, string globalID, string name, string desc)
        {

            this.parent = parent;
            this.next = null;
            this.child = null;
            this.globalID = globalID;
            this.ifcID = ifcID;
            this.ifcType = ifcType;
            this.description = desc;
            this.name = name;

            if (parent != null) {
                if (parent.child == null) {
                    parent.child = this;
                } else {
                    IFCItem NextChild = parent;

                    while (true) {
                        if (NextChild.next == null) {
                            NextChild.next = this;
                            break;
                        } else {
                            NextChild = NextChild.next;
                        }

                    }

                }

            }
        }
        public IntPtr ifcID = IntPtr.Zero;
        public string globalID;
        public string ifcType;
        public string name;
        public string description;
        public IFCItem parent = null;
        public IFCItem next = null;
        public IFCItem child = null;
        public int noVerticesForFaces;
        public int noPrimitivesForFaces;
        public float[] verticesForFaces;
        public int[] indicesForFaces;
        public int vertexOffsetForFaces;
        public int indexOffsetForFaces;
        public int noVerticesForWireFrame;
        public int noPrimitivesForWireFrame;
        public float[] verticesForWireFrame;
        public int[] indicesForWireFrame;
        public int[] indicesForWireFrameLineParts;
        public int vertexOffsetForWireFrame;
        public int indexOffsetForWireFrame;

        public IFCTreeItem ifcTreeItem = null;
        public MeshGeometryVisual3D Mesh3d;
    }

    /// <summary>
    /// Class aims to read ifc file and draw its objects 
    /// </summary>
    class ViewController
    {
        private IFCItem _rootIfcItem = null;
        private Control _destControl = null;
        private TreeView _treeControl = null;
        public CIFCTreeData _treeData = null;
        private bool _enableWireFrames = true;
        private bool _enableFaces = true;
        private bool _enableHover = false;

        private IFCItem _hoverIfcItem = null;
        private IFCItem _selectedIfcItem = null;
        private float[] _minCorner;
        private float[] _maxCorner;

        private Dictionary<MeshGeometryVisual3D, IFCItem> _meshToIfcItems = null;
        private IfcEngine _ifcEngine = null;
        private Brush _hoverBrush = Brushes.BlueViolet;
        private Brush _selectBrush = Brushes.Chartreuse;
        private Brush _defaultBrush = Brushes.Gray;
        public ViewController()
        {
            _ifcEngine = new IfcEngine();
            _treeData = new CIFCTreeData(_ifcEngine);
            _meshToIfcItems = new Dictionary<MeshGeometryVisual3D, IFCItem>();
            _minCorner = new float[3] { float.MaxValue, float.MaxValue, float.MaxValue };
            _maxCorner = new float[3] { float.MinValue, float.MinValue, float.MinValue };
        }

        public void Reset()
        {
            _meshToIfcItems.Clear();
            _hoverIfcItem = null;
            _selectedIfcItem = null;
            _minCorner = new float[3] { float.MaxValue, float.MaxValue, float.MaxValue };
            _maxCorner = new float[3] { float.MinValue, float.MinValue, float.MinValue };
        }

        private bool ParseIfcFile(string sPath)
        {
            if (File.Exists(sPath)) {
                IntPtr ifcModel = _ifcEngine.OpenModel(IntPtr.Zero, sPath, "IFC2X3_TC1.exp");

                string xmlSettings_IFC2x3 = @"IFC2X3-Settings.xml";
                string xmlSettings_IFC4 = @"IFC4-Settings.xml";

                if (ifcModel != IntPtr.Zero) {

                    IntPtr outputValue = IntPtr.Zero;

                    _ifcEngine.GetSPFFHeaderItem(ifcModel, 9, 0, IfcEngine.SdaiType.String, out outputValue);

                    string s = Marshal.PtrToStringAnsi(outputValue);


                    XmlTextReader textReader = null;
                    if (s.Contains("IFC2") == true) {
                        textReader = new XmlTextReader(xmlSettings_IFC2x3);
                    } else {
                        if (s.Contains("IFC4") == true) {
                            _ifcEngine.CloseModel(ifcModel);
                            ifcModel = _ifcEngine.OpenModel(IntPtr.Zero, sPath, "IFC4.exp");

                            if (ifcModel != IntPtr.Zero)
                                textReader = new XmlTextReader(xmlSettings_IFC4);
                        }
                    }

                    if (textReader == null)
                        return false;

                    // if node type us an attribute
                    while (textReader.Read()) {
                        textReader.MoveToElement();

                        if (textReader.AttributeCount > 0) {
                            if (textReader.LocalName == "object") {
                                if (textReader.GetAttribute("name") != null) {
                                    string Name = textReader.GetAttribute("name").ToString();
                                    //string Desc = textReader.GetAttribute("description").ToString();

                                    RetrieveObjects(ifcModel, Name, Name);
                                }
                            }
                        }
                    }

                    int a = 0;
                    GenerateGeometry(ifcModel, _rootIfcItem, ref a);

                    // Generate Tree Control
                    _treeData.BuildTree(this, ifcModel, _rootIfcItem, _treeControl);

                    _ifcEngine.CloseModel(ifcModel);

                    return true;
                }
            }

            return false;
        }

        private void GenerateWireFrameGeometry(IntPtr ifcModel, IFCItem ifcItem)
        {
            if (ifcItem.ifcID != IntPtr.Zero) {
                IntPtr noVertices = IntPtr.Zero, noIndices = IntPtr.Zero;
                _ifcEngine.InitializeModellingInstance(ifcModel, ref noVertices, ref noIndices, 0, ifcItem.ifcID);

                if (noVertices != IntPtr.Zero && noIndices != IntPtr.Zero) {
                    ifcItem.noVerticesForWireFrame = noVertices.ToInt32();
                    ifcItem.verticesForWireFrame = new float[3 * noVertices.ToInt32()];
                    ifcItem.indicesForWireFrame = new int[noIndices.ToInt32()];

                    float[] pVertices = new float[noVertices.ToInt32() * 3];

                    _ifcEngine.FinalizeModelling(ifcModel, pVertices, ifcItem.indicesForWireFrame, IntPtr.Zero);

                    int i = 0;
                    while (i < noVertices.ToInt32()) {
                        ifcItem.verticesForWireFrame[3 * i + 0] = pVertices[3 * i + 0];
                        ifcItem.verticesForWireFrame[3 * i + 1] = pVertices[3 * i + 1];
                        ifcItem.verticesForWireFrame[3 * i + 2] = pVertices[3 * i + 2];

                        i++;
                    };

                    ifcItem.noPrimitivesForWireFrame = 0;
                    ifcItem.indicesForWireFrameLineParts = new int[2 * noIndices.ToInt32()];

                    int faceCnt = _ifcEngine.GetConceptualFaceCount(ifcItem.ifcID).ToInt32();

                    for (int j = 0; j < faceCnt; j++) {
                        IntPtr startIndexFacesPolygons = IntPtr.Zero, noIndicesFacesPolygons = IntPtr.Zero, nonValue = IntPtr.Zero, nonValue1 = IntPtr.Zero, nonValue2 = IntPtr.Zero;
                        _ifcEngine.GetConceptualFaceEx(ifcItem.ifcID, new IntPtr(j), ref nonValue, ref nonValue, ref nonValue, ref nonValue, ref nonValue, ref nonValue1, ref startIndexFacesPolygons, ref noIndicesFacesPolygons, ref nonValue2, ref nonValue2);
                        i = 0;
                        int lastItem = -1;
                        while (i < noIndicesFacesPolygons.ToInt32()) {
                            if (lastItem >= 0 && ifcItem.indicesForWireFrame[startIndexFacesPolygons.ToInt32() + i] >= 0) {
                                ifcItem.indicesForWireFrameLineParts[2 * ifcItem.noPrimitivesForWireFrame + 0] = lastItem;
                                ifcItem.indicesForWireFrameLineParts[2 * ifcItem.noPrimitivesForWireFrame + 1] = ifcItem.indicesForWireFrame[startIndexFacesPolygons.ToInt32() + i];
                                ifcItem.noPrimitivesForWireFrame++;
                            }
                            lastItem = ifcItem.indicesForWireFrame[startIndexFacesPolygons.ToInt32() + i];
                            i++;
                        }
                    }
                }
            }
        }

        private void GenerateFacesGeometry(IntPtr ifcModel, IFCItem ifcItem)
        {
            if (ifcItem.ifcID != IntPtr.Zero) {
                IntPtr noVertices = IntPtr.Zero, noIndices = IntPtr.Zero;
                _ifcEngine.InitializeModellingInstance(ifcModel, ref noVertices, ref noIndices, 0, ifcItem.ifcID);

                if (noVertices != IntPtr.Zero && noIndices != IntPtr.Zero) {
                    ifcItem.noVerticesForFaces = noVertices.ToInt32();
                    ifcItem.noPrimitivesForFaces = noIndices.ToInt32() / 3;
                    ifcItem.verticesForFaces = new float[6 * noVertices.ToInt32()];
                    ifcItem.indicesForFaces = new int[noIndices.ToInt32()];

                    float[] pVertices = new float[noVertices.ToInt32() * 6];

                    _ifcEngine.FinalizeModelling(ifcModel, pVertices, ifcItem.indicesForFaces, IntPtr.Zero);

                    int i = 0;
                    while (i < noVertices.ToInt32()) {
                        ifcItem.verticesForFaces[6 * i + 0] = pVertices[6 * i + 0];
                        ifcItem.verticesForFaces[6 * i + 1] = pVertices[6 * i + 1];
                        ifcItem.verticesForFaces[6 * i + 2] = pVertices[6 * i + 2];

                        ifcItem.verticesForFaces[6 * i + 3] = pVertices[6 * i + 3];
                        ifcItem.verticesForFaces[6 * i + 4] = pVertices[6 * i + 4];
                        ifcItem.verticesForFaces[6 * i + 5] = pVertices[6 * i + 5];

                        for (int j = 0; j < 3; j++) {
                            _minCorner[j] = Math.Min(_minCorner[j], pVertices[6 * i + j]);
                            _maxCorner[j] = Math.Max(_maxCorner[j], pVertices[6 * i + j]);
                        }

                        i++;
                    }
                }
            }
        }

        void GenerateGeometry(IntPtr ifcModel, IFCItem ifcItem, ref int a)
        {
            while (ifcItem != null) {
                // Generate WireFrames Geometry
                IfcEngine.Setting setting = IfcEngine.Setting.Default;
                IfcEngine.Mask mask = IfcEngine.Mask.Default;
                mask |= IfcEngine.Mask.DoublePrecision; //    PRECISION (32/64 bit)
                mask |= IfcEngine.Mask.UseIndex64; //	   INDEX ARRAY (32/64 bit)
                mask |= IfcEngine.Mask.GenNormals; //    NORMALS
                mask |= IfcEngine.Mask.GenTriangles; //    TRIANGLES
                mask |= IfcEngine.Mask.GenWireFrame; //    WIREFRAME


                //                if (IntPtr.Size == 8) {
                //                    setting |= IfcEngine.Setting.UseIndex64; // 64 BIT INDEX ARRAY (Int64)
                //                }

                setting |= IfcEngine.Setting.GenWireframe; //    WIREFRAME ON


                _ifcEngine.SetFormat(ifcModel, setting, mask);

                GenerateWireFrameGeometry(ifcModel, ifcItem);

                // Generate Faces Geometry
                setting = IfcEngine.Setting.Default;

                //                if (IntPtr.Size == 8) {
                //                    setting |= IfcEngine.Setting.UseIndex64; //    64 BIT INDEX ARRAY (Int64)
                //                }

                setting |= IfcEngine.Setting.GenNormals; //    NORMALS ON
                setting |= IfcEngine.Setting.GenTriangles; //    TRIANGLES ON

                _ifcEngine.SetFormat(ifcModel, setting, mask);

                GenerateFacesGeometry(ifcModel, ifcItem);

                _ifcEngine.CleanMemory(ifcModel);

                GenerateGeometry(ifcModel, ifcItem.child, ref a);
                ifcItem = ifcItem.next;
            }
        }

        private void RetrieveObjects(IntPtr ifcModel, string sObjectSPFFName, string ObjectDisplayName)
        {
            IntPtr ifcObjectInstances = _ifcEngine.GetEntityExtent(ifcModel, ObjectDisplayName),
                noIfcObjectIntances = _ifcEngine.GetMemberCount(ifcObjectInstances);

            if (noIfcObjectIntances != IntPtr.Zero) {
                IFCItem NewItem = null;
                if (_rootIfcItem == null) {
                    _rootIfcItem = new IFCItem();
                    _rootIfcItem.CreateItem(null, IntPtr.Zero, "", ObjectDisplayName, "", "");

                    NewItem = _rootIfcItem;
                } else {
                    IFCItem LastItem = _rootIfcItem;
                    while (LastItem != null) {
                        if (LastItem.next == null) {
                            LastItem.next = new IFCItem();
                            LastItem.next.CreateItem(null, IntPtr.Zero, "", ObjectDisplayName, "", "");

                            NewItem = LastItem.next;

                            break;
                        } else
                            LastItem = LastItem.next;
                    };
                }


                for (int i = 0; i < noIfcObjectIntances.ToInt32(); ++i) {
                    IntPtr ifcObjectIns = IntPtr.Zero;
                    _ifcEngine.GetAggregationElement(ifcObjectInstances, i, IfcEngine.SdaiType.Instance, out ifcObjectIns);

                    IntPtr value = IntPtr.Zero;
                    _ifcEngine.GetAttribute(ifcObjectIns, "GlobalId", IfcEngine.SdaiType.Unicode, out value);

                    string globalID = Marshal.PtrToStringUni((IntPtr)value);

                    value = IntPtr.Zero;
                    _ifcEngine.GetAttribute(ifcObjectIns, "Name", IfcEngine.SdaiType.Unicode, out value);

                    string name = Marshal.PtrToStringUni((IntPtr)value);

                    value = IntPtr.Zero;
                    _ifcEngine.GetAttribute(ifcObjectIns, "Description", IfcEngine.SdaiType.Unicode, out value);

                    string description = Marshal.PtrToStringUni((IntPtr)value);

                    IFCItem subItem = new IFCItem();
                    subItem.CreateItem(NewItem, ifcObjectIns, ObjectDisplayName, globalID, name, description);
                }
            }
        }

        public bool WireFrames
        {
            get
            {
                return _enableWireFrames;
            }
            set
            {
                _enableWireFrames = value;
            }
        }
        public bool Faces
        {
            get
            {
                return _enableFaces;
            }
            set
            {
                _enableFaces = value;
            }
        }

        public bool Hover
        {
            get
            {
                return _enableHover;
            }
            set
            {
                _enableHover = value;

                if (_enableHover == false) {
                    if (_hoverIfcItem != null) {
                        _hoverIfcItem = null;
                        Redraw();
                    }
                }
            }
        }

        private HelixViewport3D hVp3D = null;
        public void InitGraphics(Control destControl, TreeView destTreeControl)
        {
            _destControl = destControl;
            _treeControl = destTreeControl;
            hVp3D = new HelixViewport3D();
            var host = new ElementHost();
            host.Dock = DockStyle.Fill;
            host.Child = hVp3D;
            _destControl.Controls.Add(host);

            BindMouseHandler();

            var lights = new DefaultLights();
            hVp3D.Children.Add(lights);

            var teaPot = new Teapot();
            hVp3D.Children.Add(teaPot);
        }

        public bool OpenIFCFile(string ifcFilePath)
        {
            _rootIfcItem = null;
            Reset();

            if (ParseIfcFile(ifcFilePath) == true) {
                InitModel();
                Redraw();
                return true;
            }

            return false;
        }

        private void BindMouseHandler()
        {
            hVp3D.MouseUp += hVp3D_MouseUp;
            hVp3D.MouseMove += hVp3D_MouseMove;
        }

        void hVp3D_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_enableHover) {
                var point = Mouse.GetPosition(hVp3D);
                var hit = hVp3D.FindNearestVisual(point);
                OnModelHovered(hit);
            }
        }

        void hVp3D_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) {
                var point = Mouse.GetPosition(hVp3D);
                var hit = hVp3D.FindNearestVisual(point);
                OnModelSelected(hit);
            }
        }

        private void OnModelHovered(Visual3D model)
        {
            if (_hoverIfcItem != null) {
                FillMeshByIfcColor(_hoverIfcItem);
                _hoverIfcItem = null;
            }
            if (model != null) {
                var mesh = (model as MeshGeometryVisual3D);
                if (_meshToIfcItems.ContainsKey(mesh)) {
                    mesh.Fill = _hoverBrush;
                    _hoverIfcItem = _meshToIfcItems[mesh];
                }
            }

            Redraw();
        }

        private void OnModelSelected(Visual3D model)
        {
            if (_selectedIfcItem != null) {
                FillMeshByIfcColor(_selectedIfcItem);
                _selectedIfcItem = null;
            }

            if (model != null) {
                var mesh = (model as MeshGeometryVisual3D);
                if (_meshToIfcItems.ContainsKey(mesh)) {
                    mesh.Fill = _selectBrush;
                    _selectedIfcItem = _meshToIfcItems[mesh];
                }
            }

            Redraw();
        }

        private void InitModel()
        {
            Vector3D center = new Vector3D((_minCorner[0] + _maxCorner[0]) / 2.0, (_minCorner[1] + _maxCorner[1]) / 2.0, (_minCorner[2] + _maxCorner[2]) / 2.0);
            hVp3D.Children.Clear();
            var lights = new DefaultLights();
            hVp3D.Children.Add(lights);
            CreateMeshes(center);
            var bound = hVp3D.Children.FindBounds();
            hVp3D.ZoomExtents(bound);
        }

        private void CreateMeshes(Vector3D center)
        {
            CreateFaceModels(_rootIfcItem, center);
        }

        private void CreateFaceModels(IFCItem item, Vector3D center)
        {
            while (item != null) {
                if (item.ifcID != IntPtr.Zero && item.noVerticesForFaces != 0 && item.noPrimitivesForFaces != 0) {
                    var positions = new Point3DCollection();
                    var normals = new Vector3DCollection();
                    if (item.verticesForFaces != null) {
                        for (int i = 0; i < item.noVerticesForFaces; i++) {
                            var point = new Point3D(item.verticesForFaces[6 * i + 0] - center.X, item.verticesForFaces[6 * i + 1] - center.Y, item.verticesForFaces[6 * i + 2] - center.Z);
                            var normal = new Vector3D(item.verticesForFaces[6 * i + 3], item.verticesForFaces[6 * i + 4], item.verticesForFaces[6 * i + 5]);
                            positions.Add(point);
                            normals.Add(normal);


                        }

                        Debug.Assert(item.verticesForFaces.Length == item.noVerticesForFaces * 6);
                    }

                    var indices = new Int32Collection();
                    if (item.indicesForFaces != null) {
                        for (int i = 0; i < 3 * item.noPrimitivesForFaces; i++) {
                            indices.Add(item.indicesForFaces[i]);
                        }
                    }

                    MeshGeometry3D meshGeometry = new MeshGeometry3D();
                    meshGeometry.Positions = positions;
                    meshGeometry.Normals = normals;
                    meshGeometry.TriangleIndices = indices;
                    MeshGeometryVisual3D mesh = new MeshGeometryVisual3D();
                    mesh.MeshGeometry = meshGeometry;
                    item.Mesh3d = mesh;
                    _meshToIfcItems[mesh] = item;

                    FillMeshByIfcColor(item);

                    hVp3D.Children.Add(mesh);
                }

                CreateFaceModels(item.child, center);
                item = item.next;
            }
        }

        private void FillMeshByIfcColor(IFCItem item)
        {
            if (item.Mesh3d != null) {
                if (item.ifcTreeItem.ifcColor != null) {
                    var ifcColor = item.ifcTreeItem.ifcColor;
                    var color = Color.FromArgb((byte)(255 - ifcColor.A * 255),
                        (byte)(ifcColor.R * 255), (byte)(ifcColor.G * 255), (byte)(ifcColor.B * 255));
                    item.Mesh3d.Fill = new SolidColorBrush(color);
                } else {
                    item.Mesh3d.Fill = _defaultBrush;
                }
            }
        }

        public void Redraw()
        {
            _destControl.Invalidate();
        }

        public void SelectItem(IFCItem ifcItem)
        {
            _selectedIfcItem = ifcItem;

            this.Redraw();
        }
    }
}
