/* ***********************************************
 * author :  LinJiarui
 * email  :  lin@bimer.cn
 * file   :  ViewController
 * history:  created by LinJiarui at 2016/2/29 18:41:41
 *           modified by
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Core;
using IfcEngineCS;
using SharpDX;
using Color = SharpDX.Color;
using Material = HelixToolkit.Wpf.SharpDX.Material;
using MeshGeometry3D = HelixToolkit.Wpf.SharpDX.MeshGeometry3D;
using Model3D = HelixToolkit.Wpf.SharpDX.Model3D;

namespace IfcViewer.DX
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
        public MeshGeometryModel3D Mesh3d;
        public LineGeometryModel3D Wireframe;
    }

    /// <summary>
    /// Class aims to read ifc file and draw its objects 
    /// </summary>
    class ViewController
    {
        private IFCItem _rootIfcItem = null;

        private TreeView _treeControl = null;
        public CIFCTreeData _treeData = null;
        private bool _enableWireFrames = true;
        private bool _enableFaces = true;
        private bool _enableHover = false;

        private bool _showSpaces = true;
        private bool _showElements = true;


        private IFCItem _hoverIfcItem = null;
        private IFCItem _selectedIfcItem = null;
        private float[] _minCorner;
        private float[] _maxCorner;

        private Dictionary<MeshGeometryModel3D, IFCItem> _meshToIfcItems = null;
        private IfcEngine _ifcEngine = null;
        private Material _hoverMaterial = PhongMaterials.Violet;
        private Material _selectMaterial = PhongMaterials.Chrome;
        private Color _defaultLineColor = new Color(0, 0, 0);
        private Material _defaultMaterial = PhongMaterials.Bronze;

        private bool _makeModelCentered = true;
        public Vector3 Max { get { return new Vector3(_maxCorner[0], _maxCorner[1], _maxCorner[2]) - Center; } }
        public Vector3 Min { get { return new Vector3(_minCorner[0], _minCorner[1], _minCorner[2]) - Center; } }
        public Vector3 Center
        {
            get
            {
                return _makeModelCentered ? Vector3.Zero : new Vector3(_minCorner[0] + _maxCorner[0], _minCorner[1] + _maxCorner[1], _minCorner[2] + _maxCorner[2]) * 0.5f;
            }
        }
        public ViewController(bool makeModelCentered = true)
        {
            _ifcEngine = new IfcEngine();
            _treeData = new CIFCTreeData(_ifcEngine);
            _meshToIfcItems = new Dictionary<MeshGeometryModel3D, IFCItem>();
            _minCorner = new float[3] { float.MaxValue, float.MaxValue, float.MaxValue };
            _maxCorner = new float[3] { float.MinValue, float.MinValue, float.MinValue };
            _makeModelCentered = makeModelCentered;
        }

        public void Reset()
        {
            model.Clear();
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
                    if (string.IsNullOrEmpty(s) || s.Contains("IFC2")) {
                        textReader = new XmlTextReader(xmlSettings_IFC2x3);

                    } else if (s.Contains("IFC4")) {
                        _ifcEngine.CloseModel(ifcModel);
                        ifcModel = _ifcEngine.OpenModel(IntPtr.Zero, sPath, "IFC4.exp");

                        if (ifcModel != IntPtr.Zero)
                            textReader = new XmlTextReader(xmlSettings_IFC4);
                    }

                    if (textReader == null) {
                        return false;
                    }

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
                model.ForEach(ele => {
                    if (ele is LineGeometryModel3D) {
                        ele.IsRendering = _enableWireFrames;
                    }
                });
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
                model.ForEach(ele => {
                    if (ele is MeshGeometryModel3D) {
                        ele.IsRendering = _enableFaces;
                    }
                });
            }
        }
        public bool ShowSpaces
        {
            get
            {
                return _showSpaces;
            }
            set
            {
                _showSpaces = value;
                model.ForEach(ele => {
                    if (ele.Tag.ToString().StartsWith("IfcSpace")) {
                        ele.IsRendering = _showSpaces;
                    }
                });
            }
        }
        public bool ShowElements
        {
            get
            {
                return _showElements;
            }
            set
            {
                _showElements = value;
                model.ForEach(ele => {
                    if (!ele.Tag.ToString().StartsWith("IfcSpace")) {
                        ele.IsRendering = _showElements;
                    }
                });
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

        private Viewport3DX hVp3D = null;
        private Element3DCollection model;
        public void InitGraphics(Viewport3DX viewport, Element3DCollection model, TreeView destTreeControl)
        {
            this.model = model;
            hVp3D = viewport;
            _treeControl = destTreeControl;

            BindMouseHandler();
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
                Point3D pnt;
                Vector3D normal;
                Model3D model;
                if (hVp3D.FindNearest(point, out pnt, out normal, out model)) {
                    OnModelHovered(model);
                }
            }
        }

        void hVp3D_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) {
                var point = Mouse.GetPosition(hVp3D);
                Point3D pnt;
                Vector3D normal;
                Model3D model;
                if (hVp3D.FindNearest(point, out pnt, out normal, out model)) {
                    OnModelSelected(model);
                }
            }
        }

        private void OnModelHovered(Model3D model)
        {
            if (_hoverIfcItem != null) {
                FillMeshByIfcColor(_hoverIfcItem);
                _hoverIfcItem = null;
            }
            if (model != null) {
                var mesh = (model as MeshGeometryModel3D);
                if (mesh != null && _meshToIfcItems.ContainsKey(mesh)) {
                    mesh.Material = _hoverMaterial;
                    _hoverIfcItem = _meshToIfcItems[mesh];
                }
            }

            Redraw();
        }

        private void OnModelSelected(Model3D model)
        {
            if (_selectedIfcItem != null) {
                _selectedIfcItem.ifcTreeItem.treeNode.IsSelected = false;
                FillMeshByIfcColor(_selectedIfcItem);
                _selectedIfcItem = null;
            }

            if (model != null) {
                var mesh = (model as MeshGeometryModel3D);
                if (mesh != null && _meshToIfcItems.ContainsKey(mesh)) {
                    mesh.Material = _selectMaterial;
                    _selectedIfcItem = _meshToIfcItems[mesh];
                    _selectedIfcItem.ifcTreeItem.treeNode.IsSelected = true;
                    _selectedIfcItem.ifcTreeItem.treeNode.Focus();
                    //                    _selectedIfcItem.ifcTreeItem.treeNode.ExpandSubtree();
                }
            }

            Redraw();
        }

        private void InitModel()
        {
            Vector3 center = new Vector3((_minCorner[0] + _maxCorner[0]) / 2.0f, (_minCorner[1] + _maxCorner[1]) / 2.0f, (_minCorner[2] + _maxCorner[2]) / 2.0f);
            CreateMeshes(center);
            CreateWireframes(center);
        }

        private void CreateWireframes(Vector3 center)
        {
            CreateWireFrameModels(_rootIfcItem, center);
        }

        private void CreateWireFrameModels(IFCItem item, Vector3 center)
        {
            while (item != null) {
                if (item.ifcID != IntPtr.Zero && item.noVerticesForWireFrame != 0 && item.noPrimitivesForWireFrame != 0) {
                    var geo = new LineGeometry3D();
                    geo.Positions=new Vector3Collection();
                    geo.Indices=new IntCollection();
                    var points = new Vector3Collection();
                    if (item.verticesForWireFrame != null) {
                        for (int i = 0; i < item.noVerticesForWireFrame; i++) {
                            points.Add(new Vector3((item.verticesForWireFrame[3 * i + 0] - center.X), (item.verticesForWireFrame[3 * i + 1] - center.Y), (item.verticesForWireFrame[3 * i + 2] - center.Z)));
                            geo.Positions.Add(new Vector3((item.verticesForWireFrame[3 * i + 0] - center.X), (item.verticesForWireFrame[3 * i + 1] - center.Y), (item.verticesForWireFrame[3 * i + 2] - center.Z)));
                        }
                    }

                    if (item.indicesForWireFrameLineParts != null) {
                        for (int i = 0; i < item.noPrimitivesForWireFrame; i++) {
                            var idx = item.indicesForWireFrameLineParts[2 * i + 0];
                            geo.Indices.Add(idx);
                            idx = item.indicesForWireFrameLineParts[2 * i + 1];
                            geo.Indices.Add(idx);
                        }
                    } else {
                        for (int i = 0, count = points.Count; i < count; i++) {
                            geo.Indices.Add(i);
                            geo.Indices.Add((i + 1) % count);
                        }
                    }

                    LineGeometryModel3D line = new LineGeometryModel3D();
                    line.Geometry = geo;
                    line.Color = _defaultLineColor;
                    line.Thickness = 0.5;
                    item.Wireframe = line;

                    line.Tag = item.ifcType + ":" + item.ifcID;
                    model.Add(line);
                }

                CreateFaceModels(item.child, center);
                item = item.next;
            }
        }

        private void CreateMeshes(Vector3 center)
        {
            CreateFaceModels(_rootIfcItem, center);
        }

        private void CreateFaceModels(IFCItem item, Vector3 center)
        {
            while (item != null) {
                if (item.ifcID != IntPtr.Zero && item.noVerticesForFaces != 0 && item.noPrimitivesForFaces != 0) {
                    var positions = new Vector3Collection();
                    var normals = new Vector3Collection();
                    if (item.verticesForFaces != null) {
                        for (int i = 0; i < item.noVerticesForFaces; i++) {
                            var point = new Vector3(item.verticesForFaces[6 * i + 0] - center.X, item.verticesForFaces[6 * i + 1] - center.Y, item.verticesForFaces[6 * i + 2] - center.Z);
                            var normal = new Vector3(item.verticesForFaces[6 * i + 3], item.verticesForFaces[6 * i + 4], item.verticesForFaces[6 * i + 5]);
                            positions.Add(point);
                            normals.Add(normal);
                        }

                        Debug.Assert(item.verticesForFaces.Length == item.noVerticesForFaces * 6);
                    }

                    var indices = new IntCollection();
                    if (item.indicesForFaces != null) {
                        for (int i = 0; i < 3 * item.noPrimitivesForFaces; i++) {
                            indices.Add(item.indicesForFaces[i]);
                        }
                    }

                    var meshGeometry = new MeshGeometry3D();
                    meshGeometry.Positions = positions;
                    meshGeometry.Normals = normals;
                    meshGeometry.Indices = indices;
                    meshGeometry.TextureCoordinates = null;
                    meshGeometry.Colors = null;
                    meshGeometry.Tangents = null;
                    meshGeometry.BiTangents = null;

                    MeshGeometryModel3D mesh = new MeshGeometryModel3D() { Geometry = meshGeometry };
                    //                    var builder = new MeshBuilder(true, false);
                    //                    builder.Positions.AddRange(positions);
                    //                    builder.Normals.AddRange(normals);
                    //                    builder.TriangleIndices.AddRange(indices);
                    //                    MeshGeometryModel3D mesh = new MeshGeometryModel3D() { Geometry = builder.ToMeshGeometry3D() };
                    item.Mesh3d = mesh;
                    _meshToIfcItems[mesh] = item;
                    //#if DEBUG
                    //                    OutputObj(item.ifcID.ToString(), meshGeometry);
                    //#endif
                    FillMeshByIfcColor(item);

                    mesh.Tag = item.ifcType + ":" + item.ifcID;
                    model.Add(mesh);
                }

                CreateFaceModels(item.child, center);
                item = item.next;
            }
        }

        public static void OutputObj(string ifcId, MeshGeometry3D rep)
        {
            using (var writer = new StreamWriter("./" + ifcId + ".obj")) {
                for (int i = 0, count = rep.Positions.Count; i < count; i++) {
                    writer.WriteLine("v {0} {1} {2}", rep.Positions[i].X, rep.Positions[i].Y, rep.Positions[i].Z);
                    writer.WriteLine("vn {0} {1} {2}", rep.Normals[i].X, rep.Normals[i].Y, rep.Normals[i].Z);
                }
                var indices = rep.Indices.ToArray().Reverse().ToList();//HACK winding
                for (int i = 0, count = indices.Count / 3; i < count; i++) {
                    writer.WriteLine("f {0}//{0} {1}//{1} {2}//{2}", indices[i * 3] + 1, indices[i * 3 + 1] + 1, indices[i * 3 + 2] + 1);
                }
            }
        }
        private void FillMeshByIfcColor(IFCItem item)
        {
            if (item.Mesh3d != null) {
                if (item.ifcTreeItem.ifcColor != null) {
                    var ifcColor = item.ifcTreeItem.ifcColor;
                    var color = System.Windows.Media.Color.FromArgb((byte)(255 - ifcColor.A * 255), (byte)(ifcColor.R * 255), (byte)(ifcColor.G * 255), (byte)(ifcColor.B * 255));
                    item.Mesh3d.Material = new PhongMaterial() {
                        AmbientColor = Colors.Black.ToColor4(),
                        DiffuseColor = Colors.Black.ToColor4(),
                        EmissiveColor = color.ToColor4(),
                        ReflectiveColor = Colors.Black.ToColor4(),
                        SpecularColor = color.ToColor4(),
                    };
                } else {
                    item.Mesh3d.Material = _defaultMaterial;
                }
            }
        }

        public void Redraw()
        {
            //_destControl.Refresh();
        }

        public void SelectItem(IFCItem ifcItem)
        {
            if (ifcItem != null && ifcItem.Mesh3d != null) {
                OnModelSelected(ifcItem.Mesh3d);
            }
            this.Redraw();
        }
    }

}
