using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using IfcEngineCS;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IFCViewer
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// 

    /// <summary>
    /// Types of supported movements
    /// </summary>
    enum MOVE_TYPE
    {
        ROTATE,
        PAN,
        ZOOM,
        NONE,
    }

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
    }

    /// <summary>
    /// Class aims to read ifc file and draw its objects 
    /// </summary>
    class IFCViewerWrapper
    {
        private IFCItem _rootIfcItem = null;
        private Control _destControl = null;
        private TreeView _treeControl = null;
        public CIFCTreeData _treeData = null;
        private int counter = 0;
        private float valueZ = 0;
        private float valueX = 0;
        private MOVE_TYPE _currentMoveType = MOVE_TYPE.NONE;
        private Point _startPoint = new Point(-1, -1);
        private Point _endPoint = new Point(-1, -1);
        private bool _enableWireFrames = true;
        private bool _enableFaces = true;
        private bool _enableHover = false;
        private int currentPos = 0;
        private int currentPosInd = 0;
        private float roll_val = 0.0f;
        private float pitch_val = 0.0f;
        private float yaw_val = 0.0f;
        private float _zoomIndex = 0F;
        Material _mtrlDefault;
        Material _mtrlBlack;
        Material _mtrlRed;

        private IFCItem _hoverIfcItem = null;
        private IFCItem _selectedIfcItem = null;
        float size = 0;

        private IfcEngine _ifcEngine = null;
        /// <summary>
        /// ctor
        /// </summary>
        public IFCViewerWrapper()
        {
            _ifcEngine = new IfcEngine();
            _treeData = new CIFCTreeData(_ifcEngine);
        }

        // -------------------------------------------------------------------
        // Private Methods 

        private bool ParseIfcFile(string sPath)
        {
            if (true == File.Exists(sPath)) {
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

                    /*                    // -----------------------------------------------------------------
                                        // Generate WireFrames Geometry
                    
                                        int setting = 0, mask = 0;
                                        mask += _ifcEngine.flagbit2;        //    PRECISION (32/64 bit)
                                        mask += _ifcEngine.flagbit3;        //	   INDEX ARRAY (32/64 bit)
                                        mask += _ifcEngine.flagbit5;        //    NORMALS
                                        mask += _ifcEngine.flagbit8;        //    TRIANGLES
                                        mask += _ifcEngine.flagbit12;       //    WIREFRAME
                                        setting += 0;		     //    DOUBLE PRECISION (double)

                                        if (IntPtr.Size == 4) // indication for 32
                                        {
                                            setting += 0;            //    32 BIT INDEX ARRAY (Int32)
                                        }
                                        else
                                        {
                                            if (IntPtr.Size == 8)
                                            {
                                                setting += _ifcEngine.flagbit3;     // 64 BIT INDEX ARRAY (Int64)
                                            }
                                        }

                                        setting += 0;            //    NORMALS OFF
                                        setting += 0;			 //    TRIANGLES OFF
                                        setting += _ifcEngine.flagbit12;    //    WIREFRAME ON


                                        _ifcEngine.setFormat(ifcModel, setting, mask);

                                        GenerateWireFrameGeometry(ifcModel, _rootIfcItem);
                                        // -----------------------------------------------------------------
                                        // Generate Faces Geometry

                                        setting = 0;
                                        setting += 0;		     //    SINGLE PRECISION (float)
                                        //#ifndef	WIN64
                                        if (IntPtr.Size == 4) // indication for 32
                                        {
                                            setting += 0;            //    32 BIT INDEX ARRAY (Int32)
                                        }
                                        else
                                        {
                                            if (IntPtr.Size == 8)
                                            {
                                                setting += _ifcEngine.flagbit3;     //    64 BIT INDEX ARRAY (Int64)
                                            }
                                        }
                     
                                        setting += _ifcEngine.flagbit5;     //    NORMALS ON
                                        setting += _ifcEngine.flagbit8;     //    TRIANGLES ON
                                        setting += 0;			 //    WIREFRAME OFF 
                                        _ifcEngine.setFormat(ifcModel, setting, mask);

                                        GenerateFacesGeometry(ifcModel, _rootIfcItem);
                    */

                    // -----------------------------------------------------------------
                    // Generate Tree Control
                    _treeData.BuildTree(this, ifcModel, _rootIfcItem, _treeControl);


                    // -----------------------------------------------------------------

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

                        i++;
                    }
                }
            }
        }

        void GenerateGeometry(IntPtr ifcModel, IFCItem ifcItem, ref int a)
        {
            while (ifcItem != null) {
                // -----------------------------------------------------------------
                // Generate WireFrames Geometry

                IfcEngine.Setting setting = IfcEngine.Setting.Default;
                IfcEngine.Mask mask = IfcEngine.Mask.Default;
                mask |= IfcEngine.Mask.DoublePrecision; //    PRECISION (32/64 bit)
                mask |= IfcEngine.Mask.UseIndex64; //	   INDEX ARRAY (32/64 bit)
                mask |= IfcEngine.Mask.GenNormals; //    NORMALS
                mask |= IfcEngine.Mask.GenTriangles; //    TRIANGLES
                mask |= IfcEngine.Mask.GenWireFrame; //    WIREFRAME


                if (IntPtr.Size == 8) {
                    setting |= IfcEngine.Setting.UseIndex64; // 64 BIT INDEX ARRAY (Int64)
                }

                setting |= IfcEngine.Setting.GenWireframe; //    WIREFRAME ON


                _ifcEngine.SetFormat(ifcModel, setting, mask);

                GenerateWireFrameGeometry(ifcModel, ifcItem);
                // -----------------------------------------------------------------
                // Generate Faces Geometry

                setting = IfcEngine.Setting.Default;

                if (IntPtr.Size == 8) {
                    setting |= IfcEngine.Setting.UseIndex64; //    64 BIT INDEX ARRAY (Int64)
                }

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


        // -------------------------------------------------------------------
        // Public Methods 

        public void OnMouseMove(MouseEventArgs e)
        {
            _endPoint = e.Location;
            float _stepTranslate = 0.01F;

            // check direction of movement
            bool MoveRight = (_startPoint.X <= _endPoint.X);

            // check direction of movement
            bool MoveUp = (_startPoint.Y >= _endPoint.Y);
            int deltaY = Math.Abs(_startPoint.Y - _endPoint.Y);
            int deltaX = Math.Abs(_startPoint.X - _endPoint.X);

            var diameter = 2.5f * Math.Min(_destControl.Width, _destControl.Height);

            switch (_currentMoveType) {
                case MOVE_TYPE.ROTATE: {

                        var stepRotate = deltaY * 180 / diameter;
                        pitch_val += (MoveUp) ? stepRotate : -stepRotate;

                        stepRotate = deltaX * 180 / diameter;
                        yaw_val += (MoveRight) ? -stepRotate : stepRotate;

                        break;
                    };
                case MOVE_TYPE.PAN: {
                        _stepTranslate = 0.005F;
                        if (deltaY >= deltaX) {
                            valueZ += (MoveUp) ? _stepTranslate : -_stepTranslate;
                        } else {
                            valueX += (MoveRight) ? _stepTranslate : -_stepTranslate;
                        }


                    }
                    break;
                case MOVE_TYPE.ZOOM: {
                        _zoomIndex += (MoveUp) ? -_stepTranslate : _stepTranslate;

                        break;
                    };
            }

            _startPoint = _endPoint;

            if (_currentMoveType != MOVE_TYPE.NONE) {
                this.Redraw();
            } else {
                if (_enableHover) {
                    Console.WriteLine("todo");
                    //                    IFCPicker picker = null;
                    //                    picker = new IFCPicker(_device, center, size, _rootIfcItem);
                    //
                    //                    IFCItem newPickedItem = picker.PickObject(e.Location);

                    //                    if (_hoverIfcItem != null && newPickedItem == null) {
                    //                        _hoverIfcItem = null;
                    //
                    //                        this.Redraw();
                    //                    } else {
                    //                        if (_hoverIfcItem != newPickedItem) {
                    //                            _hoverIfcItem = newPickedItem;
                    //
                    //                            this.Redraw();
                    //                        }
                    //                    }
                }


            }

        }

        public void OnMouseWheel(MouseEventArgs e)
        {
            float _stepTranslate = 0.01F;
            _zoomIndex += (e.Delta < 0) ? -_stepTranslate : _stepTranslate;
            this.Redraw();
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            _currentMoveType = MOVE_TYPE.NONE;
        }



        public void OnMouseDown(MouseEventArgs e)
        {
            _currentMoveType = MOVE_TYPE.NONE;
            _startPoint = e.Location;
            _endPoint = _startPoint;


            switch (e.Button) {
                case MouseButtons.Left:
                    _currentMoveType = MOVE_TYPE.ROTATE;
                    break;
                case MouseButtons.Middle:
                    _currentMoveType = MOVE_TYPE.PAN;
                    break;
                case MouseButtons.Right:
                    _currentMoveType = MOVE_TYPE.ZOOM;
                    break;

            }

            if (e.Button == MouseButtons.Left) {
                Console.WriteLine("todo");
                //                IFCPicker picker = null;
                //                picker = new IFCPicker(_device, center, size, _rootIfcItem);
                //
                //                IFCItem newPickedItem = picker.PickObject(e.Location);
                //
                //                if (_selectedIfcItem != null && newPickedItem == null) {
                //                    _selectedIfcItem = null;
                //
                //                    this.Redraw();
                //                } else {
                //                    if (_selectedIfcItem != newPickedItem) {
                //                        _selectedIfcItem = newPickedItem;
                //
                //                        // expand and select the corresponding tree item for this IFCItem
                //                        _treeData.OnSelectIFCElement(_selectedIfcItem);
                //
                //                        this.Redraw();
                //                    }
                //                }
            }

        }

        public void Reset()
        {
            roll_val = 0.0f;
            pitch_val = 0.0f;
            yaw_val = 45.0f;
            _zoomIndex = 0F;
            _currentMoveType = MOVE_TYPE.NONE;
            valueZ = 0;
            valueX = 0.5f;
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

            //TODO: adaptive model must be implemented to support different type of buffers
            // See Pick_2005 MS example

            _destControl = destControl;
            _treeControl = destTreeControl;
            hVp3D = new HelixViewport3D();
            var host = new ElementHost();
            host.Dock = DockStyle.Fill;
            host.Child = hVp3D;
            _destControl.Controls.Add(host);
            var lights = new DefaultLights();
            hVp3D.Children.Add(lights);

            var teaPot = new Teapot();
            hVp3D.Children.Add(teaPot);

        }
        public bool OpenIFCFile(string ifcFilePath)
        {
            Reset();

            _rootIfcItem = null;

            if (ParseIfcFile(ifcFilePath) == true) {
                InitModel();

                this._destControl.Refresh();

                return true;
            }

            return false;


        }

        private void InitModel()
        {
            hVp3D.Children.Clear();
            var lights = new DefaultLights();
            hVp3D.Children.Add(lights);
            CreateMeshes();
            var bound = hVp3D.Children.FindBounds();
            hVp3D.ZoomExtents(bound);

        }

        private void CreateMeshes()
        {
            FillBuffers_ifcFaces(_rootIfcItem);
        }


        private void FillBuffers_ifcFaces(IFCItem item)
        {
            while (item != null) {
                if (item.ifcID != IntPtr.Zero && item.noVerticesForFaces != 0 && item.noPrimitivesForFaces != 0) {
                    var positions = new Point3DCollection();
                    var normals = new Vector3DCollection();
                    if (item.verticesForFaces != null) {
                        for (int i = 0; i < item.noVerticesForFaces; i++) {
                            var point = new Point3D(item.verticesForFaces[6 * i + 0], item.verticesForFaces[6 * i + 1], item.verticesForFaces[6 * i + 2]);
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

                    if (item.ifcTreeItem.ifcColor != null) {
                        var ifcColor = item.ifcTreeItem.ifcColor;
                        var color = System.Windows.Media.Color.FromArgb((byte)(255 - ifcColor.A * 255), (byte)(ifcColor.R * 255), (byte)(ifcColor.G * 255), (byte)(ifcColor.B * 255));
                        mesh.Fill = new SolidColorBrush(color);
                    }

                    hVp3D.Children.Add(mesh);
                }

                FillBuffers_ifcFaces(item.child);
                item = item.next;
            }
        }


        public void Redraw()
        {
            Console.WriteLine("todo");
        }

        public void SelectItem(IFCItem ifcItem)
        {
            _selectedIfcItem = ifcItem;

            this.Redraw();
        }
    }
}
