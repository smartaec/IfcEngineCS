using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf.SharpDX;
using IfcEngineCS;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SharpDX;
using HelixToolkit.Wpf.SharpDX.Core;
using System.Windows.Controls;

namespace IfcSharpDXSampleProject
{
    /// <summary>
    /// IFCItem presents a single ifc item for drawing 
    /// </summary>
    public class IFCItem
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

            if (parent != null)
            {
                if (parent.child == null)
                {
                    parent.child = this;
                }
                else {
                    IFCItem NextChild = parent;

                    while (true)
                    {
                        if (NextChild.next == null)
                        {
                            NextChild.next = this;
                            break;
                        }
                        else {
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
        public MeshGeometryModel3D Mesh3d;
        public LineGeometryModel3D Wireframe;
    }


    /// <summary>
    /// Class aims to read ifc file and draw its objects 
    /// </summary>
    class ViewController
    {
        private IFCItem _rootIfcItem = null;
        private bool _enableWireFrames = true;
        private bool _enableFaces = true;
        private bool _enableHover = false;

        private TreeView _treeControl = null;
        private IFCItem _hoverIfcItem = null;
        private IFCItem _selectedIfcItem = null;
        public CIFCTreeData _treeData = null;
        private float[] _minCorner;
        private float[] _maxCorner;

        private Dictionary<MeshGeometryModel3D, IFCItem> _meshToIfcItems = null;
        private IfcEngine _ifcEngine = null;
        private Brush _hoverBrush = Brushes.BlueViolet;
        private Brush _selectBrush = Brushes.Chartreuse;
        private System.Windows.Media.Color _defaultLineColor = System.Windows.Media.Color.FromRgb(0, 0, 0);
        private Brush _defaultBrush = Brushes.Gray;
        public ViewController()
        {
            _ifcEngine = new IfcEngine();
            _treeData = new CIFCTreeData(_ifcEngine);
            _meshToIfcItems = new Dictionary<MeshGeometryModel3D, IFCItem>();
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
            if (File.Exists(sPath))
            {
                IntPtr ifcModel = _ifcEngine.OpenModel(IntPtr.Zero, sPath, "IFC2X3_TC1.exp");

                string xmlSettings_IFC2x3 = @"IFC2X3-Settings.xml";
                string xmlSettings_IFC4 = @"IFC4-Settings.xml";

                if (ifcModel != IntPtr.Zero)
                {

                    IntPtr outputValue = IntPtr.Zero;

                    _ifcEngine.GetSPFFHeaderItem(ifcModel, 9, 0, IfcEngine.SdaiType.String, out outputValue);

                    string s = Marshal.PtrToStringAnsi(outputValue);


                    XmlTextReader textReader = null;
                    if (string.IsNullOrEmpty(s) || s.Contains("IFC2"))
                    {
                        textReader = new XmlTextReader(xmlSettings_IFC2x3);

                    }
                    else if (s.Contains("IFC4"))
                    {
                        _ifcEngine.CloseModel(ifcModel);
                        ifcModel = _ifcEngine.OpenModel(IntPtr.Zero, sPath, "IFC4.exp");

                        if (ifcModel != IntPtr.Zero)
                            textReader = new XmlTextReader(xmlSettings_IFC4);
                    }

                    if (textReader == null)
                    {
                        return false;
                    }

                    // if node type us an attribute
                    while (textReader.Read())
                    {
                        textReader.MoveToElement();

                        if (textReader.AttributeCount > 0)
                        {
                            if (textReader.LocalName == "object")
                            {
                                if (textReader.GetAttribute("name") != null)
                                {
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
                    _treeData.BuildTree(this, ifcModel, _rootIfcItem,_treeControl);

                    _ifcEngine.CloseModel(ifcModel);

                    return true;
                }
            }

            return false;
        }

        private void GenerateWireFrameGeometry(IntPtr ifcModel, IFCItem ifcItem)
        {
            if (ifcItem.ifcID != IntPtr.Zero)
            {
                IntPtr noVertices = IntPtr.Zero, noIndices = IntPtr.Zero;
                _ifcEngine.InitializeModellingInstance(ifcModel, ref noVertices, ref noIndices, 0, ifcItem.ifcID);

                if (noVertices != IntPtr.Zero && noIndices != IntPtr.Zero)
                {
                    ifcItem.noVerticesForWireFrame = noVertices.ToInt32();
                    ifcItem.verticesForWireFrame = new float[3 * noVertices.ToInt32()];
                    ifcItem.indicesForWireFrame = new int[noIndices.ToInt32()];

                    float[] pVertices = new float[noVertices.ToInt32() * 3];

                    _ifcEngine.FinalizeModelling(ifcModel, pVertices, ifcItem.indicesForWireFrame, IntPtr.Zero);

                    int i = 0;
                    while (i < noVertices.ToInt32())
                    {
                        ifcItem.verticesForWireFrame[3 * i + 0] = pVertices[3 * i + 0];
                        ifcItem.verticesForWireFrame[3 * i + 1] = pVertices[3 * i + 1];
                        ifcItem.verticesForWireFrame[3 * i + 2] = pVertices[3 * i + 2];

                        i++;
                    };

                    ifcItem.noPrimitivesForWireFrame = 0;
                    ifcItem.indicesForWireFrameLineParts = new int[2 * noIndices.ToInt32()];

                    int faceCnt = _ifcEngine.GetConceptualFaceCount(ifcItem.ifcID).ToInt32();

                    for (int j = 0; j < faceCnt; j++)
                    {
                        IntPtr startIndexFacesPolygons = IntPtr.Zero, noIndicesFacesPolygons = IntPtr.Zero, nonValue = IntPtr.Zero, nonValue1 = IntPtr.Zero, nonValue2 = IntPtr.Zero;
                        _ifcEngine.GetConceptualFaceEx(ifcItem.ifcID, new IntPtr(j), ref nonValue, ref nonValue, ref nonValue, ref nonValue, ref nonValue, ref nonValue1, ref startIndexFacesPolygons, ref noIndicesFacesPolygons, ref nonValue2, ref nonValue2);
                        i = 0;
                        int lastItem = -1;
                        while (i < noIndicesFacesPolygons.ToInt32())
                        {
                            if (lastItem >= 0 && ifcItem.indicesForWireFrame[startIndexFacesPolygons.ToInt32() + i] >= 0)
                            {
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
            if (ifcItem.ifcID != IntPtr.Zero)
            {
                IntPtr noVertices = IntPtr.Zero, noIndices = IntPtr.Zero;
                _ifcEngine.InitializeModellingInstance(ifcModel, ref noVertices, ref noIndices, 0, ifcItem.ifcID);

                if (noVertices != IntPtr.Zero && noIndices != IntPtr.Zero)
                {
                    ifcItem.noVerticesForFaces = noVertices.ToInt32();
                    ifcItem.noPrimitivesForFaces = noIndices.ToInt32() / 3;
                    ifcItem.verticesForFaces = new float[6 * noVertices.ToInt32()];
                    ifcItem.indicesForFaces = new int[noIndices.ToInt32()];

                    float[] pVertices = new float[noVertices.ToInt32() * 6];

                    _ifcEngine.FinalizeModelling(ifcModel, pVertices, ifcItem.indicesForFaces, IntPtr.Zero);

                    int i = 0;
                    while (i < noVertices.ToInt32())
                    {
                        ifcItem.verticesForFaces[6 * i + 0] = pVertices[6 * i + 0];
                        ifcItem.verticesForFaces[6 * i + 1] = pVertices[6 * i + 1];
                        ifcItem.verticesForFaces[6 * i + 2] = pVertices[6 * i + 2];

                        ifcItem.verticesForFaces[6 * i + 3] = pVertices[6 * i + 3];
                        ifcItem.verticesForFaces[6 * i + 4] = pVertices[6 * i + 4];
                        ifcItem.verticesForFaces[6 * i + 5] = pVertices[6 * i + 5];

                        for (int j = 0; j < 3; j++)
                        {
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
            while (ifcItem != null)
            {
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

            if (noIfcObjectIntances != IntPtr.Zero)
            {
                IFCItem NewItem = null;
                if (_rootIfcItem == null)
                {
                    _rootIfcItem = new IFCItem();

                    _rootIfcItem.CreateItem(null, IntPtr.Zero, "", ObjectDisplayName, "", "");
                    NewItem = _rootIfcItem;
                }
                else {
                    IFCItem LastItem = _rootIfcItem;
                    while (LastItem != null)
                    {
                        if (LastItem.next == null)
                        {
                            LastItem.next = new IFCItem();
                            LastItem.next.CreateItem(null, IntPtr.Zero, "", ObjectDisplayName, "", "");
                            NewItem = LastItem.next;

                            break;
                        }
                        else
                            LastItem = LastItem.next;
                    };
                }


                for (int i = 0; i < noIfcObjectIntances.ToInt32(); ++i)
                {
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

                if (_enableHover == false)
                {
                    if (_hoverIfcItem != null)
                    {
                        _hoverIfcItem = null;
                        Redraw();
                    }
                }
            }
        }

        private Viewport3DX hVp3D = null;
        private Element3DCollection model;
        public void InitGraphics(Viewport3DX viewport,Element3DCollection model,TreeView _treeview)
        {
            this.model = model;
            hVp3D = viewport;
            _treeControl = _treeview;
            BindMouseHandler();

        }

        public bool OpenIFCFile(string ifcFilePath)
        {
            _rootIfcItem = null;
            Reset();

            if (ParseIfcFile(ifcFilePath) == true)
            {
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
            if (_enableHover)
            {
                var hits = hVp3D.FindHits(e.GetPosition(hVp3D));
                foreach (var hit in hits)
                {
                    OnModelSelected(hit.ModelHit as MeshGeometryModel3D);
                    break;
                }
            }
        }

        void hVp3D_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var hits = hVp3D.FindHits(e.GetPosition(hVp3D));
                foreach (var hit in hits)
                {
                    OnModelSelected(hit.ModelHit as MeshGeometryModel3D);
                    break;
                }        
            }
        }

        private void OnModelHovered(MeshGeometryModel3D model)
        {
            if (_hoverIfcItem != null)
            {
                FillMeshByIfcColor(_hoverIfcItem);
                _hoverIfcItem = null;
            }
            if (model != null)
            {
                var mesh = (model as MeshGeometryModel3D);
                if (mesh != null && _meshToIfcItems.ContainsKey(mesh))
                {
                    mesh.Material = PhongMaterials.Chrome;
                    _hoverIfcItem = _meshToIfcItems[mesh];
                }
            }

            Redraw();
        }

        private void OnModelSelected(MeshGeometryModel3D model)
        {
            if (_selectedIfcItem != null)
            {
                FillMeshByIfcColor(_selectedIfcItem);
                _selectedIfcItem = null;
            }

            Redraw();
        }

        private void InitModel()
        {
            Vector3D center = new Vector3D((_minCorner[0] + _maxCorner[0]) / 2.0, (_minCorner[1] + _maxCorner[1]) / 2.0, (_minCorner[2] + _maxCorner[2]) / 2.0);
            CreateMeshes(center);
            CreateWireframes(center);
        }

        private void CreateWireframes(Vector3D center)
        {
            CreateWireFrameModels(_rootIfcItem, center);
        }

        private void CreateWireFrameModels(IFCItem item, Vector3D center)
        {
            while (item != null)
            {
                if (item.ifcID != IntPtr.Zero && item.noVerticesForWireFrame != 0 && item.noPrimitivesForWireFrame != 0)
                {
                    var points = new Vector3Collection();
                    Vector3Collection positions;
                    if (item.verticesForWireFrame != null)
                    {
                        for (int i = 0; i < item.noVerticesForWireFrame; i++)
                        {
                            points.Add(new Vector3((float)(item.verticesForWireFrame[3 * i + 0] - center.X), (float)(item.verticesForWireFrame[3 * i + 1] - center.Y), (float)(item.verticesForWireFrame[3 * i + 2] - center.Z)));
                        }
                    }

                    if (item.indicesForWireFrameLineParts != null)
                    {
                        positions = new Vector3Collection();
                        for (int i = 0; i < item.noPrimitivesForWireFrame; i++)
                        {
                            var idx = item.indicesForWireFrameLineParts[2 * i + 0];
                            positions.Add(points[idx]);
                            idx = item.indicesForWireFrameLineParts[2 * i + 1];
                            positions.Add(points[idx]);
                        }
                    }
                    else {
                        positions = points;
                    }


                    var lineBuilder = new LineBuilder();
                    lineBuilder.Add(false,positions.ToArray());
                    LineGeometryModel3D line = new LineGeometryModel3D();
                    line.Geometry = lineBuilder.ToLineGeometry3D();
                    line.Color = new SharpDX.Color(0,0,0,0);
                    item.Wireframe = line;
                    model.Add(line as Element3D);
                }

                CreateFaceModels(item.child, center);
                item = item.next;
            }
        }

        private void CreateMeshes(Vector3D center)
        {
            CreateFaceModels(_rootIfcItem, center);
        }

        private void CreateFaceModels(IFCItem item, Vector3D center)
        {
            while (item != null)
            {
                if (item.ifcID != IntPtr.Zero && item.noVerticesForFaces != 0 && item.noPrimitivesForFaces != 0)
                {
                    var positions = new List<Vector3>();
                    var normals = new List<Vector3>();
                    if (item.verticesForFaces != null)
                    {
                        for (int i = 0; i < item.noVerticesForFaces; i++)
                        {
                            var point = new Point3D(item.verticesForFaces[6 * i + 0] - center.X, item.verticesForFaces[6 * i + 1] - center.Y, item.verticesForFaces[6 * i + 2] - center.Z);
                            var normal = new Vector3D(item.verticesForFaces[6 * i + 3], item.verticesForFaces[6 * i + 4], item.verticesForFaces[6 * i + 5]);
                            positions.Add(new Vector3((float)point.X, (float)point.Y, (float)point.Z));
                            normals.Add(new Vector3((float)normal.X, (float)normal.Y, (float)normal.Z));
                        }

                        Debug.Assert(item.verticesForFaces.Length == item.noVerticesForFaces * 6);
                    }

                    var indices = new Int32Collection();
                    if (item.indicesForFaces != null)
                    {
                        for (int i = 0; i < 3 * item.noPrimitivesForFaces; i++)
                        {
                            indices.Add(item.indicesForFaces[i]);
                        }
                    }

                    List<Vector2> textureCoords = positions.Select(o => new Vector2(o.X, o.Y)).ToList();
                    
                    var meshBuilder = new MeshBuilder();
                    meshBuilder.Append(positions, indices,normals,textureCoords);
                    MeshGeometryModel3D mesh = new MeshGeometryModel3D() { Geometry = meshBuilder.ToMeshGeometry3D() };
                    item.Mesh3d = mesh;
                    _meshToIfcItems[mesh] = item;
#if DEBUG
                    OutputObj(item.ifcID.ToString(), mesh);
#endif
                    FillMeshByIfcColor(item);

                    model.Add(mesh);
                }

                CreateFaceModels(item.child, center);
                item = item.next;
            }
        }

        public static void OutputObj(string ifcId, MeshGeometryModel3D rep)
        {
            using (var writer = new StreamWriter("./" + ifcId + ".obj"))
            {
                for (int i = 0, count = rep.Geometry.Positions.Count; i < count; i++)
                {
                    writer.WriteLine("v {0} {1} {2}", rep.Geometry.Positions[i].X, rep.Geometry.Positions[i].Y, rep.Geometry.Positions[i].Z);
                }
                List<int> dummyList = rep.Geometry.Indices;
                dummyList.Reverse();
                var indices = dummyList;//HACK winding
                for (int i = 0, count = indices.Count / 3; i < count; i++)
                {
                    writer.WriteLine("f {0}//{0} {1}//{1} {2}//{2}", indices[i * 3] + 1, indices[i * 3 + 1] + 1, indices[i * 3 + 2] + 1);
                }
            }
        }
        private void FillMeshByIfcColor(IFCItem item)
        {
            if (item.Mesh3d != null)
            {
                if (item.ifcTreeItem.ifcColor != null)
                {
                    var ifcColor = item.ifcTreeItem.ifcColor;
                    var color = System.Windows.Media.Color.FromArgb((byte)(255 - ifcColor.A * 255),(byte)(ifcColor.R * 255), (byte)(ifcColor.G * 255), (byte)(ifcColor.B * 255));
                    item.Mesh3d.Material = new PhongMaterial() {
                        AmbientColor= Colors.Black.ToColor4(),
                        DiffuseColor = Colors.Black.ToColor4(),
                        EmissiveColor = color.ToColor4(),
                        ReflectiveColor= Colors.Black.ToColor4(),
                        SpecularColor= color.ToColor4(),
                    };
                }
                else {
                    item.Mesh3d.Material = PhongMaterials.Bronze;
                }
            }
        }

        public void Redraw()
        {

        }

        public void SelectItem(IFCItem ifcItem)
        {
            if (ifcItem != null && ifcItem.Mesh3d != null)
            {
                OnModelSelected(ifcItem.Mesh3d);
            }
            this.Redraw();
        }



    }
}
