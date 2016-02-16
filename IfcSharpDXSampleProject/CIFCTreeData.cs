using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using IfcEngineCS;
using System.Windows.Controls;
using System.Windows.Media;

namespace IfcSharpDXSampleProject
{
    /// <summary>
    /// Describe the color of IFCItem.
    /// </summary>
    public class IFCItemColor
    {
        public float R = 0;
        public float G = 0;
        public float B = 0;
        public float A = 0;
    }

    /// <summary>
    /// Describes an item in the tree.
    /// </summary>
    public class IFCTreeItem
    {
        /// <summary>
        /// Instance.
        /// </summary>
        public IntPtr instance = IntPtr.Zero;

        /// <summary>
        /// Node.
        /// </summary>
        public TreeViewItem treeNode = null;

        /// <summary>
        /// If it is not null the item can be selected.
        /// </summary>
        public IFCItem ifcItem = null;

        /// <summary>
        /// Color
        /// </summary>
        public IFCItemColor ifcColor = null;

        /// <summary>
        /// Getter
        /// </summary>
        public bool IsVisible
        {
            get
            {
                System.Diagnostics.Debug.Assert(treeNode != null, "Internal error.");

                return false;
            }
        }
    }

    /// <summary>
    /// Generates entire IFC tree. 
    /// - Initiate control by retrieving data from IFC library and transmitting it to C# Tree control.
    ///    
    ///     - IFCProject Items
    ///         - Tree Item
    ///         - Check Box
    ///     - Not-referenced in structure 
    /// - Keeps bidirectional relationship IFCElementID <-> TreeItem
    ///     - OnSelect Tree Item -> Mark IFC element
    ///     - OnMark IFC Element -> Select Tree Item
    /// - Build Context Menu functionality
    /// </summary>
    class CIFCTreeData
    {
        /// <summary>
        /// Viewer
        /// </summary>
        ViewController _viewController = null;

        /// <summary>
        /// Model
        /// </summary>
        IntPtr _ifcModel = IntPtr.Zero;

        /// <summary>
        /// Root of IFCItem-s
        /// </summary>
        IFCItem _ifcRoot = null;

        /// <summary>
        /// Tree control
        /// </summary>
        TreeView _treeControl = null;

        /// <summary>
        /// Contains info for the context menu.
        /// </summary>
        Dictionary<string, bool> _dicCheckedElements = new Dictionary<string, bool>();

        /// <summary>
        /// Zero-based indices of the images inside the image list.
        /// </summary>
        public const int IMAGE_CHECKED = 0;
        public const int IMAGE_UNCHECKED = 2;
        public const int IMAGE_PROPERTY_SET = 3;
        public const int IMAGE_PROPERTY = 4;
        public const int IMAGE_NOT_REFERENCED = 5;

        private IfcEngine _ifcEngine;
        public CIFCTreeData(IfcEngine ifcEngine)
        {
            _ifcEngine = ifcEngine;
        }

        /// <summary>
        /// - Generates IFCProject-related items
        /// - Generates Not-referenced-in-structure items
        /// - Generates Header info
        /// - Generates check box per items
        /// </summary>
        public void BuildTree(ViewController ifcViewer, IntPtr ifcModel, IFCItem ifcRoot, TreeView treeControl)
        {
            treeControl.Items.Clear();

            if (ifcViewer == null) {
                throw new ArgumentException("The viewer is null.");
            }

            if (ifcModel == IntPtr.Zero) {
                throw new ArgumentException("Invalid model.");
            }

            if (ifcRoot == null) {
                throw new ArgumentException("The root is null.");
            }

            if (treeControl == null) {
                throw new ArgumentException("The tree control is null.");
            }

            _viewController = ifcViewer;
            _ifcModel = ifcModel;
            _ifcRoot = ifcRoot;
            _treeControl = treeControl;

            _dicCheckedElements.Clear();

            CreateHeaderTreeItems();
            CreateProjectTreeItems();
            CreateNotReferencedTreeItems();
        }

        /// <summary>
        /// Helper
        /// </summary>
        private void CreateHeaderTreeItems()
        {
            // Header info
            TreeViewItem tnHeaderInfo = new TreeViewItem() { Header = "Header Info" };
            _treeControl.Items.Add(tnHeaderInfo);

            // Descriptions
            TreeViewItem tnDescriptions = new TreeViewItem() { Header = "Descriptions" };
            tnHeaderInfo.Items.Add(tnDescriptions);

            int i = 0;
            IntPtr description;
            while (_ifcEngine.GetSPFFHeaderItem(_ifcModel, 0, i++, IfcEngine.SdaiType.Unicode, out description) == IntPtr.Zero) {
                TreeViewItem tnDescription = new TreeViewItem() { Header = Marshal.PtrToStringUni(description) };
                tnDescriptions.Items.Add(tnDescription);
            }

            // ImplementationLevel
            IntPtr implementationLevel;
            _ifcEngine.GetSPFFHeaderItem(_ifcModel, 1, 0, IfcEngine.SdaiType.Unicode, out implementationLevel);

            TreeViewItem tnImplementationLevel = new TreeViewItem() { Header = "ImplementationLevel = '" + Marshal.PtrToStringUni(implementationLevel) + "'" };
            tnHeaderInfo.Items.Add(tnImplementationLevel);


            // Name
            IntPtr name;
            _ifcEngine.GetSPFFHeaderItem(_ifcModel, 2, 0, IfcEngine.SdaiType.Unicode, out name);

            TreeViewItem tnName = new TreeViewItem() { Header = "Name = '" + Marshal.PtrToStringUni(name) + "'" };
            tnHeaderInfo.Items.Add(tnName);

            // TimeStamp
            IntPtr timeStamp;
            _ifcEngine.GetSPFFHeaderItem(_ifcModel, 3, 0, IfcEngine.SdaiType.Unicode, out timeStamp);

            TreeViewItem tnTimeStamp = new TreeViewItem() { Header = "TimeStamp = '" + Marshal.PtrToStringUni(timeStamp) + "'" };
            tnHeaderInfo.Items.Add(tnTimeStamp);

            // Authors
            TreeViewItem tnAuthors = new TreeViewItem() { Header = "Authors" };
            tnHeaderInfo.Items.Add(tnAuthors);

            i = 0;
            IntPtr author;
            while (_ifcEngine.GetSPFFHeaderItem(_ifcModel, 4, i++, IfcEngine.SdaiType.Unicode, out author) == IntPtr.Zero) {
                TreeViewItem tnAuthor = new TreeViewItem() { Header = Marshal.PtrToStringUni(author) };
                tnAuthors.Items.Add(tnAuthor);
            }

            // Organizations
            TreeViewItem tnOrganizations = new TreeViewItem() { Header = "Organizations" };
            tnHeaderInfo.Items.Add(tnOrganizations);

            i = 0;
            IntPtr organization;
            while (_ifcEngine.GetSPFFHeaderItem(_ifcModel, 5, i++, IfcEngine.SdaiType.Unicode, out organization) == IntPtr.Zero) {
                TreeViewItem tnOrganization = new TreeViewItem() { Header = Marshal.PtrToStringUni(organization) };
                tnOrganizations.Items.Add(tnOrganization);
            }

            // PreprocessorVersion
            IntPtr preprocessorVersion;
            _ifcEngine.GetSPFFHeaderItem(_ifcModel, 6, 0, IfcEngine.SdaiType.Unicode, out preprocessorVersion);

            TreeViewItem tnPreprocessorVersion = new TreeViewItem() { Header = "PreprocessorVersion = '" + Marshal.PtrToStringUni(preprocessorVersion) + "'" };
            tnHeaderInfo.Items.Add(tnPreprocessorVersion);

            // OriginatingSystem
            IntPtr originatingSystem;
            _ifcEngine.GetSPFFHeaderItem(_ifcModel, 7, 0, IfcEngine.SdaiType.Unicode, out originatingSystem);

            TreeViewItem tnOriginatingSystem = new TreeViewItem() { Header = "OriginatingSystem = '" + Marshal.PtrToStringUni(originatingSystem) + "'"};
            tnHeaderInfo.Items.Add(tnOriginatingSystem);

            // Authorization
            IntPtr authorization;
            _ifcEngine.GetSPFFHeaderItem(_ifcModel, 8, 0, IfcEngine.SdaiType.Unicode, out authorization);

            TreeViewItem tnAuthorization = new TreeViewItem() { Header = "Authorization = '" + Marshal.PtrToStringUni(authorization) + "'" };
            tnHeaderInfo.Items.Add(tnAuthorization);

            // FileSchemas
            TreeViewItem tnFileSchemas = new TreeViewItem() { Header = "FileSchemas" };
            tnHeaderInfo.Items.Add(tnFileSchemas);

            i = 0;
            IntPtr fileSchema;
            while (_ifcEngine.GetSPFFHeaderItem(_ifcModel, 9, i++, IfcEngine.SdaiType.Unicode, out fileSchema) == IntPtr.Zero) {
                TreeViewItem tnFileSchema = new TreeViewItem() { Header = Marshal.PtrToStringUni(fileSchema) };
                tnHeaderInfo.Items.Add(tnFileSchema);
            }
        }

        /// <summary>
        /// Helper
        /// </summary>
        private void CreateProjectTreeItems()
        {
            var iEntityID = _ifcEngine.GetEntityExtent(_ifcModel, "IfcProject");
            var iEntitiesCount = _ifcEngine.GetMemberCount(iEntityID);

            for (int iEntity = 0; iEntity < iEntitiesCount.ToInt32(); iEntity++) {
                IntPtr iInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(iEntityID, iEntity, IfcEngine.SdaiType.Instance, out iInstance);

                IFCTreeItem ifcTreeItem = new IFCTreeItem();
                ifcTreeItem.instance = iInstance;

                CreateTreeItem(null, ifcTreeItem);

                AddChildrenTreeItems(ifcTreeItem, iInstance, "IfcSite");
            } // for (int iEntity = ...
        }

        /// <summary>
        /// Helper
        /// </summary>
        private void CreateNotReferencedTreeItems()
        {
            IFCTreeItem ifcTreeItem = new IFCTreeItem();
            TreeViewItem tvi = new TreeViewItem() { Header = "Not referenced" };
            _treeControl.Items.Add(tvi);
            ifcTreeItem.treeNode = tvi;
            ifcTreeItem.treeNode.Foreground = new SolidColorBrush(Colors.Gray);
            ifcTreeItem.treeNode.Tag = ifcTreeItem;

            FindNonReferencedIFCItems(_ifcRoot, ifcTreeItem.treeNode);

            if (ifcTreeItem.treeNode.Items.Count == 0) {
                // don't show empty Not Referenced item
                _treeControl.Items.Remove(ifcTreeItem.treeNode);
            }
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcParent"></param>
        /// <param name="iParentInstance"></param>
        /// <param name="strEntityName"></param>

        private void AddChildrenTreeItems(IFCTreeItem ifcParent, IntPtr iParentInstance, string strEntityName)
        {
            // check for decomposition
            IntPtr decompositionInstance;
            _ifcEngine.GetAttribute(iParentInstance, "IsDecomposedBy", IfcEngine.SdaiType.Aggregation, out decompositionInstance);

            if (decompositionInstance == IntPtr.Zero) {
                return;
            }

            var iDecompositionsCount = _ifcEngine.GetMemberCount(decompositionInstance);
            for (int iDecomposition = 0; iDecomposition < iDecompositionsCount.ToInt32(); iDecomposition++) {
                IntPtr iDecompositionInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(decompositionInstance, iDecomposition, IfcEngine.SdaiType.Instance, out iDecompositionInstance);

                if (!IsInstanceOf(iDecompositionInstance, "IFCRELAGGREGATES")) {
                    continue;
                }

                IntPtr objectInstances;
                _ifcEngine.GetAttribute(iDecompositionInstance, "RelatedObjects", IfcEngine.SdaiType.Aggregation, out objectInstances);

                var iObjectsCount = _ifcEngine.GetMemberCount(objectInstances);
                for (int iObject = 0; iObject < iObjectsCount.ToInt32(); iObject++) {
                    IntPtr iObjectInstance = IntPtr.Zero;
                    _ifcEngine.GetAggregationElement(objectInstances, iObject, IfcEngine.SdaiType.Instance, out iObjectInstance);

                    if (!IsInstanceOf(iObjectInstance, strEntityName)) {
                        continue;
                    }

                    IFCTreeItem ifcTreeItem = new IFCTreeItem();
                    ifcTreeItem.instance = iObjectInstance;

                    CreateTreeItem(ifcParent, ifcTreeItem);

                    switch (strEntityName) {
                        case "IfcSite": {
                                AddChildrenTreeItems(ifcTreeItem, iObjectInstance, "IfcBuilding");
                            }
                            break;

                        case "IfcBuilding": {
                                AddChildrenTreeItems(ifcTreeItem, iObjectInstance, "IfcBuildingStorey");
                            }
                            break;

                        case "IfcBuildingStorey": {
                                AddElementTreeItems(ifcTreeItem, iObjectInstance);
                            }
                            break;

                        default:
                            break;
                    }
                } // for (int iObject = ...
            } // for (int iDecomposition = ...
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcParent"></param>
        /// <param name="iParentInstance"></param>     
        private void AddElementTreeItems(IFCTreeItem ifcParent, IntPtr iParentInstance)
        {
            IntPtr decompositionInstance;
            _ifcEngine.GetAttribute(iParentInstance, "IsDecomposedBy", IfcEngine.SdaiType.Aggregation, out decompositionInstance);

            if (decompositionInstance == IntPtr.Zero) {
                return;
            }

            var iDecompositionsCount = _ifcEngine.GetMemberCount(decompositionInstance);
            for (int iDecomposition = 0; iDecomposition < iDecompositionsCount.ToInt32(); iDecomposition++) {
                var iDecompositionInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(decompositionInstance, iDecomposition, IfcEngine.SdaiType.Instance, out iDecompositionInstance);

                if (!IsInstanceOf(iDecompositionInstance, "IFCRELAGGREGATES")) {
                    continue;
                }

                IntPtr objectInstances;
                _ifcEngine.GetAttribute(iDecompositionInstance, "RelatedObjects", IfcEngine.SdaiType.Aggregation, out objectInstances);

                var iObjectsCount = _ifcEngine.GetMemberCount(objectInstances);
                for (int iObject = 0; iObject < iObjectsCount.ToInt32(); iObject++) {
                    IntPtr iObjectInstance = IntPtr.Zero;
                    _ifcEngine.GetAggregationElement(objectInstances, iObject, IfcEngine.SdaiType.Instance, out iObjectInstance);

                    IFCTreeItem ifcTreeItem = new IFCTreeItem();
                    ifcTreeItem.instance = iObjectInstance;
                    ifcTreeItem.ifcItem = FindIFCItem(_ifcRoot, ifcTreeItem);

                    CreateTreeItem(ifcParent, ifcTreeItem);

                    _dicCheckedElements[GetItemType(iObjectInstance)] = true;

                    if (ifcTreeItem.ifcItem != null) {
                        ifcTreeItem.ifcItem.ifcTreeItem = ifcTreeItem;

                    } else {

                    }
                } // for (int iObject = ...
            } // for (int iDecomposition = ...

            // check for elements
            IntPtr elementsInstance;
            _ifcEngine.GetAttribute(iParentInstance, "ContainsElements", IfcEngine.SdaiType.Aggregation, out elementsInstance);

            if (elementsInstance == IntPtr.Zero) {
                return;
            }

            var iElementsCount = _ifcEngine.GetMemberCount(elementsInstance);
            for (int iElement = 0; iElement < iElementsCount.ToInt32(); iElement++) {
                IntPtr iElementInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(elementsInstance, iElement, IfcEngine.SdaiType.Instance, out iElementInstance);

                if (!IsInstanceOf(iElementInstance, "IFCRELCONTAINEDINSPATIALSTRUCTURE")) {
                    continue;
                }

                IntPtr objectInstances;
                _ifcEngine.GetAttribute(iElementInstance, "RelatedElements", IfcEngine.SdaiType.Aggregation, out objectInstances);

                var iObjectsCount = _ifcEngine.GetMemberCount(objectInstances);
                for (int iObject = 0; iObject < iObjectsCount.ToInt32(); iObject++) {
                    var iObjectInstance = IntPtr.Zero;
                    _ifcEngine.GetAggregationElement(objectInstances, iObject, IfcEngine.SdaiType.Instance, out iObjectInstance);

                    IFCTreeItem ifcTreeItem = new IFCTreeItem();
                    ifcTreeItem.instance = iObjectInstance;
                    ifcTreeItem.ifcItem = FindIFCItem(_ifcRoot, ifcTreeItem);

                    CreateTreeItem(ifcParent, ifcTreeItem);

                    _dicCheckedElements[GetItemType(iObjectInstance)] = true;

                    if (ifcTreeItem.ifcItem != null) {
                        ifcTreeItem.ifcItem.ifcTreeItem = ifcTreeItem;


                        GetColor(ifcTreeItem);
                    } else {

                    }

                    IntPtr definedByInstances;
                    _ifcEngine.GetAttribute(iObjectInstance, "IsDefinedBy", IfcEngine.SdaiType.Aggregation, out definedByInstances);

                    if (definedByInstances == IntPtr.Zero) {
                        continue;
                    }

                    var iDefinedByCount = _ifcEngine.GetMemberCount(definedByInstances);
                    for (int iDefinedBy = 0; iDefinedBy < iDefinedByCount.ToInt32(); iDefinedBy++) {
                        var iDefinedByInstance = IntPtr.Zero;
                        _ifcEngine.GetAggregationElement(definedByInstances, iDefinedBy, IfcEngine.SdaiType.Instance, out iDefinedByInstance);

                        if (IsInstanceOf(iDefinedByInstance, "IFCRELDEFINESBYPROPERTIES")) {
                            AddPropertyTreeItems(ifcTreeItem, iDefinedByInstance);
                        } else {
                            if (IsInstanceOf(iDefinedByInstance, "IFCRELDEFINESBYTYPE")) {
                                // NA
                            }
                        }
                    }
                } // for (int iObject = ...
            } // for (int iDecomposition = ...
        }

        /// <summary>
        /// Helper. 
        /// </summary>
        /// <param name="ifcTreeItem"></param>
        void GetColor(IFCTreeItem ifcTreeItem)
        {
            if (ifcTreeItem == null) {
                throw new ArgumentException("The item is null.");
            }

            // C++ => getRGB_object()
            IntPtr representationInstance;
            _ifcEngine.GetAttribute(ifcTreeItem.instance, "Representation", IfcEngine.SdaiType.Instance, out representationInstance);
            if (representationInstance == IntPtr.Zero) {
                return;
            }

            // C++ => getRGB_productDefinitionShape()
            IntPtr representationsInstance;
            _ifcEngine.GetAttribute(representationInstance, "Representations", IfcEngine.SdaiType.Aggregation, out representationsInstance);

            var iRepresentationsCount = _ifcEngine.GetMemberCount(representationsInstance);
            for (int iRepresentation = 0; iRepresentation < iRepresentationsCount.ToInt32(); iRepresentation++) {
                var iShapeInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(representationsInstance, iRepresentation, IfcEngine.SdaiType.Instance, out iShapeInstance);

                if (iShapeInstance == IntPtr.Zero) {
                    continue;
                }

                // C++ => getRGB_shapeRepresentation()
                IntPtr representationIdentifier;
                _ifcEngine.GetAttribute(iShapeInstance, "RepresentationIdentifier", IfcEngine.SdaiType.Unicode, out representationIdentifier);

                if (Marshal.PtrToStringUni(representationIdentifier) == "Body") {
                    IntPtr itemsInstance;
                    _ifcEngine.GetAttribute(iShapeInstance, "Items", IfcEngine.SdaiType.Aggregation, out itemsInstance);

                    var iItemsCount = _ifcEngine.GetMemberCount(itemsInstance);
                    for (int iItem = 0; iItem < iItemsCount.ToInt32(); iItem++) {
                        var iItemInstance = IntPtr.Zero;
                        _ifcEngine.GetAggregationElement(itemsInstance, iItem, IfcEngine.SdaiType.Instance, out iItemInstance);

                        IntPtr styledByItem;
                        _ifcEngine.GetAttribute(iItemInstance, "StyledByItem", IfcEngine.SdaiType.Instance, out styledByItem);

                        if (styledByItem != IntPtr.Zero) {
                            getRGB_styledItem(ifcTreeItem, styledByItem);
                        } else {
                            searchDeeper(ifcTreeItem, iItemInstance);
                        } // else if (iItemInstance != 0)

                        if (ifcTreeItem.ifcColor != null) {
                            return;
                        }
                    } // for (int iItem = ...
                }
            } // for (int iRepresentation = ...
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcTreeItem"></param>
        /// <param name="iParentInstance"></param>
        void searchDeeper(IFCTreeItem ifcTreeItem, IntPtr iParentInstance)
        {
            IntPtr styledByItem;
            _ifcEngine.GetAttribute(iParentInstance, "StyledByItem", IfcEngine.SdaiType.Instance, out styledByItem);

            if (styledByItem != IntPtr.Zero) {
                getRGB_styledItem(ifcTreeItem, styledByItem);
                if (ifcTreeItem.ifcColor != null) {
                    return;
                }
            }

            if (IsInstanceOf(iParentInstance, "IFCBOOLEANCLIPPINGRESULT")) {
                IntPtr firstOperand;
                _ifcEngine.GetAttribute(iParentInstance, "FirstOperand", IfcEngine.SdaiType.Instance, out firstOperand);

                if (firstOperand != IntPtr.Zero) {
                    searchDeeper(ifcTreeItem, firstOperand);
                }
            } // if (IsInstanceOf(iParentInstance, "IFCBOOLEANCLIPPINGRESULT"))
            else {
                if (IsInstanceOf(iParentInstance, "IFCMAPPEDITEM")) {
                    IntPtr mappingSource;
                    _ifcEngine.GetAttribute(iParentInstance, "MappingSource", IfcEngine.SdaiType.Instance, out mappingSource);

                    IntPtr mappedRepresentation;
                    _ifcEngine.GetAttribute(mappingSource, "MappedRepresentation", IfcEngine.SdaiType.Instance, out mappedRepresentation);

                    if (mappedRepresentation != IntPtr.Zero) {
                        IntPtr representationIdentifier;
                        _ifcEngine.GetAttribute(mappedRepresentation, "RepresentationIdentifier", IfcEngine.SdaiType.Unicode, out representationIdentifier);

                        if (Marshal.PtrToStringUni(representationIdentifier) == "Body") {
                            IntPtr itemsInstance;
                            _ifcEngine.GetAttribute(mappedRepresentation, "Items", IfcEngine.SdaiType.Aggregation, out itemsInstance);

                            var iItemsCount = _ifcEngine.GetMemberCount(itemsInstance);
                            for (int iItem = 0; iItem < iItemsCount.ToInt32(); iItem++) {
                                var iItemInstance = IntPtr.Zero;
                                _ifcEngine.GetAggregationElement(itemsInstance, iItem, IfcEngine.SdaiType.Instance, out iItemInstance);

                                styledByItem = IntPtr.Zero;
                                _ifcEngine.GetAttribute(iItemInstance, "StyledByItem", IfcEngine.SdaiType.Instance, out styledByItem);

                                if (styledByItem != IntPtr.Zero) {
                                    getRGB_styledItem(ifcTreeItem, styledByItem);
                                } else {
                                    searchDeeper(ifcTreeItem, iItemInstance);
                                } // else if (iItemInstance != 0)

                                if (ifcTreeItem.ifcColor != null) {
                                    return;
                                }
                            } // for (int iItem = ...
                        } // if (Marshal.PtrToStringAnsi(representationIdentifier) == "Body")
                    } // if (mappedRepresentation != IntPtr.Zero)
                } // if (IsInstanceOf(iParentInstance, "IFCMAPPEDITEM"))
            } // else if (IsInstanceOf(iParentInstance, "IFCBOOLEANCLIPPINGRESULT"))
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="iStyledByItemInstance"></param>
        void getRGB_styledItem(IFCTreeItem ifcTreeItem, IntPtr iStyledByItemInstance)
        {
            IntPtr stylesInstance;
            _ifcEngine.GetAttribute(iStyledByItemInstance, "Styles", IfcEngine.SdaiType.Aggregation, out stylesInstance);

            var iStylesCount = _ifcEngine.GetMemberCount(stylesInstance);
            for (int iStyle = 0; iStyle < iStylesCount.ToInt32(); iStyle++) {
                var iStyleInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(stylesInstance, iStyle, IfcEngine.SdaiType.Instance, out iStyleInstance);

                if (iStyleInstance == IntPtr.Zero) {
                    continue;
                }

                getRGB_presentationStyleAssignment(ifcTreeItem, iStyleInstance);
            } // for (int iStyle = ...
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="iParentInstance"></param>
        void getRGB_presentationStyleAssignment(IFCTreeItem ifcTreeItem, IntPtr iParentInstance)
        {
            IntPtr stylesInstance;
            _ifcEngine.GetAttribute(iParentInstance, "Styles", IfcEngine.SdaiType.Aggregation, out stylesInstance);

            var iStylesCount = _ifcEngine.GetMemberCount(stylesInstance);
            for (int iStyle = 0; iStyle < iStylesCount.ToInt32(); iStyle++) {
                var iStyleInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(stylesInstance, iStyle, IfcEngine.SdaiType.Instance, out iStyleInstance);

                if (iStyleInstance == IntPtr.Zero) {
                    continue;
                }

                getRGB_surfaceStyle(ifcTreeItem, iStyleInstance);
            } // for (int iStyle = ...
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="iParentInstance"></param>
        unsafe void getRGB_surfaceStyle(IFCTreeItem ifcTreeItem, IntPtr iParentInstance)
        {
            IntPtr stylesInstance;
            _ifcEngine.GetAttribute(iParentInstance, "Styles", IfcEngine.SdaiType.Aggregation, out stylesInstance);

            var iStylesCount = _ifcEngine.GetMemberCount(stylesInstance);
            for (int iStyle = 0; iStyle < iStylesCount.ToInt32(); iStyle++) {
                var iStyleInstance = IntPtr.Zero;
                _ifcEngine.GetAggregationElement(stylesInstance, iStyle, IfcEngine.SdaiType.Instance, out iStyleInstance);

                if (iStyleInstance == IntPtr.Zero) {
                    continue;
                }

                IntPtr surfaceColour;
                _ifcEngine.GetAttribute(iStyleInstance, "SurfaceColour", IfcEngine.SdaiType.Instance, out surfaceColour);

                if (surfaceColour == IntPtr.Zero) {
                    continue;
                }

                double R = 0;
                _ifcEngine.GetAttribute(surfaceColour, "Red", IfcEngine.SdaiType.Real, out *(IntPtr*)&R);

                double G = 0;
                _ifcEngine.GetAttribute(surfaceColour, "Green", IfcEngine.SdaiType.Real, out *(IntPtr*)&G);

                double B = 0;
                _ifcEngine.GetAttribute(surfaceColour, "Blue", IfcEngine.SdaiType.Real, out *(IntPtr*)&B);

                ifcTreeItem.ifcColor = new IFCItemColor();
                ifcTreeItem.ifcColor.R = (float)R;
                ifcTreeItem.ifcColor.G = (float)G;
                ifcTreeItem.ifcColor.B = (float)B;

                return;
            } // for (int iStyle = ...
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcParent"></param>
        /// <param name="iParentInstance"></param>     
        private void AddPropertyTreeItems(IFCTreeItem ifcParent, IntPtr iParentInstance)
        {
            IntPtr propertyInstances;
            _ifcEngine.GetAttribute(iParentInstance, "RelatingPropertyDefinition", IfcEngine.SdaiType.Instance, out propertyInstances);

            if (IsInstanceOf(propertyInstances, "IFCELEMENTQUANTITY")) {
                IFCTreeItem ifcPropertySetTreeItem = new IFCTreeItem();
                ifcPropertySetTreeItem.instance = propertyInstances;

                CreateTreeItem(ifcParent, ifcPropertySetTreeItem);


                // check for quantity
                IntPtr quantitiesInstance;
                _ifcEngine.GetAttribute(propertyInstances, "Quantities", IfcEngine.SdaiType.Aggregation, out quantitiesInstance);

                if (quantitiesInstance == IntPtr.Zero) {
                    return;
                }

                var iQuantitiesCount = _ifcEngine.GetMemberCount(quantitiesInstance);
                for (int iQuantity = 0; iQuantity < iQuantitiesCount.ToInt32(); iQuantity++) {
                    var iQuantityInstance = IntPtr.Zero;
                    _ifcEngine.GetAggregationElement(quantitiesInstance, iQuantity, IfcEngine.SdaiType.Instance, out iQuantityInstance);

                    IFCTreeItem ifcQuantityTreeItem = new IFCTreeItem();
                    ifcQuantityTreeItem.instance = iQuantityInstance;

                    if (IsInstanceOf(iQuantityInstance, "IFCQUANTITYLENGTH"))
                        CreatePropertyTreeItem(ifcPropertySetTreeItem, ifcQuantityTreeItem, "IFCQUANTITYLENGTH");
                    else
                        if (IsInstanceOf(iQuantityInstance, "IFCQUANTITYAREA"))
                            CreatePropertyTreeItem(ifcPropertySetTreeItem, ifcQuantityTreeItem, "IFCQUANTITYAREA");
                        else
                            if (IsInstanceOf(iQuantityInstance, "IFCQUANTITYVOLUME"))
                                CreatePropertyTreeItem(ifcPropertySetTreeItem, ifcQuantityTreeItem, "IFCQUANTITYVOLUME");
                            else
                                if (IsInstanceOf(iQuantityInstance, "IFCQUANTITYCOUNT"))
                                    CreatePropertyTreeItem(ifcPropertySetTreeItem, ifcQuantityTreeItem, "IFCQUANTITYCOUNT");
                                else
                                    if (IsInstanceOf(iQuantityInstance, "IFCQUANTITYWEIGTH"))
                                        CreatePropertyTreeItem(ifcPropertySetTreeItem, ifcQuantityTreeItem, "IFCQUANTITYWEIGTH");
                                    else
                                        if (IsInstanceOf(iQuantityInstance, "IFCQUANTITYTIME"))
                                            CreatePropertyTreeItem(ifcPropertySetTreeItem, ifcQuantityTreeItem, "IFCQUANTITYTIME");
                } // for (int iQuantity = ...
            } else {
                if (IsInstanceOf(propertyInstances, "IFCPROPERTYSET")) {
                    IFCTreeItem ifcPropertySetTreeItem = new IFCTreeItem();
                    ifcPropertySetTreeItem.instance = propertyInstances;

                    CreateTreeItem(ifcParent, ifcPropertySetTreeItem);


                    // check for quantity
                    IntPtr propertiesInstance;
                    _ifcEngine.GetAttribute(propertyInstances, "HasProperties", IfcEngine.SdaiType.Aggregation, out propertiesInstance);

                    if (propertiesInstance == IntPtr.Zero) {
                        return;
                    }

                    var iPropertiesCount = _ifcEngine.GetMemberCount(propertiesInstance);
                    for (int iProperty = 0; iProperty < iPropertiesCount.ToInt32(); iProperty++) {
                        var iPropertyInstance = IntPtr.Zero;
                        _ifcEngine.GetAggregationElement(propertiesInstance, iProperty, IfcEngine.SdaiType.Instance, out iPropertyInstance);

                        if (!IsInstanceOf(iPropertyInstance, "IFCPROPERTYSINGLEVALUE"))
                            continue;

                        IFCTreeItem ifcPropertyTreeItem = new IFCTreeItem();
                        ifcPropertyTreeItem.instance = iPropertyInstance;

                        CreatePropertyTreeItem(ifcPropertySetTreeItem, ifcPropertyTreeItem, "IFCPROPERTYSINGLEVALUE");
                    } // for (int iProperty = ...
                }
            }
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcParent"></param>
        /// <param name="ifcItem"></param>
        private void CreateTreeItem(IFCTreeItem ifcParent, IFCTreeItem ifcItem)
        {
            IntPtr ifcType = _ifcEngine.GetInstanceType(ifcItem.instance);
            string strIfcType = Marshal.PtrToStringAnsi(ifcType);

            IntPtr name;
            _ifcEngine.GetAttribute(ifcItem.instance, "Name", IfcEngine.SdaiType.Unicode, out name);

            string strName = Marshal.PtrToStringUni(name);

            IntPtr description;
            _ifcEngine.GetAttribute(ifcItem.instance, "Description", IfcEngine.SdaiType.Unicode, out description);

            string strDescription = Marshal.PtrToStringUni(description);

            string strItemText = "'" + (string.IsNullOrEmpty(strName) ? "<name>" : strName) +
                    "', '" + (string.IsNullOrEmpty(strDescription) ? "<description>" : strDescription) +
                    "' (" + strIfcType + ")";

            if ((ifcParent != null) && (ifcParent.treeNode != null)) {
                TreeViewItem tvi = new TreeViewItem() { Header = strItemText };
                ifcParent.treeNode.Items.Add(tvi);
                ifcItem.treeNode = tvi;
            } else {
                TreeViewItem tvi = new TreeViewItem() { Header = strItemText };
                _treeControl.Items.Add(tvi);
                ifcItem.treeNode = tvi;
            }

            if (ifcItem.ifcItem == null) {
                // item without visual representation
                ifcItem.treeNode.Foreground = new SolidColorBrush(Colors.Gray);
            }

            ifcItem.treeNode.Tag = ifcItem;
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcParent"></param>
        /// <param name="ifcItem"></param>
        private void CreatePropertyTreeItem(IFCTreeItem ifcParent, IFCTreeItem ifcItem, string strProperty)
        {
            IntPtr ifcType = _ifcEngine.GetInstanceType(ifcItem.instance);
            string strIfcType = Marshal.PtrToStringAnsi(ifcType);

            IntPtr name;
            _ifcEngine.GetAttribute(ifcItem.instance, "Name", IfcEngine.SdaiType.Unicode, out name);

            string strName = Marshal.PtrToStringUni(name);

            string strValue = string.Empty;
            switch (strProperty) {
                case "IFCQUANTITYLENGTH": {
                        IntPtr value;
                        _ifcEngine.GetAttribute(ifcItem.instance, "LengthValue", IfcEngine.SdaiType.Unicode, out value);

                        strValue = Marshal.PtrToStringUni(value);
                    }
                    break;

                case "IFCQUANTITYAREA": {
                        IntPtr value;
                        _ifcEngine.GetAttribute(ifcItem.instance, "AreaValue", IfcEngine.SdaiType.Unicode, out value);

                        strValue = Marshal.PtrToStringUni(value);
                    }
                    break;

                case "IFCQUANTITYVOLUME": {
                        IntPtr value;
                        _ifcEngine.GetAttribute(ifcItem.instance, "VolumeValue", IfcEngine.SdaiType.Unicode, out value);

                        strValue = Marshal.PtrToStringUni(value);
                    }
                    break;

                case "IFCQUANTITYCOUNT": {
                        IntPtr value;
                        _ifcEngine.GetAttribute(ifcItem.instance, "CountValue", IfcEngine.SdaiType.Unicode, out value);

                        strValue = Marshal.PtrToStringUni(value);
                    }
                    break;

                case "IFCQUANTITYWEIGTH": {
                        IntPtr value;
                        _ifcEngine.GetAttribute(ifcItem.instance, "WeigthValue", IfcEngine.SdaiType.Unicode, out value);

                        strValue = Marshal.PtrToStringUni(value);
                    }
                    break;

                case "IFCQUANTITYTIME": {
                        IntPtr value;
                        _ifcEngine.GetAttribute(ifcItem.instance, "TimeValue", IfcEngine.SdaiType.Unicode, out value);

                        strValue = Marshal.PtrToStringUni(value);
                    }
                    break;

                case "IFCPROPERTYSINGLEVALUE": {
                        IntPtr value;
                        _ifcEngine.GetAttribute(ifcItem.instance, "NominalValue", IfcEngine.SdaiType.Unicode, out value);

                        strValue = Marshal.PtrToStringUni(value);
                    }
                    break;

                default:
                    throw new Exception("Unknown property.");
            } // switch (strProperty)    

            string strItemText = "'" + (string.IsNullOrEmpty(strName) ? "<name>" : strName) +
                    "' = '" + (string.IsNullOrEmpty(strValue) ? "<value>" : strValue) +
                    "' (" + strIfcType + ")";

            if ((ifcParent != null) && (ifcParent.treeNode != null))
            {
                TreeViewItem tvi = new TreeViewItem() { Header = strItemText };
                ifcParent.treeNode.Items.Add(tvi);
                ifcItem.treeNode = tvi;
            }
            else {
                TreeViewItem tvi = new TreeViewItem() { Header = strItemText };
                _treeControl.Items.Add(tvi);
                ifcItem.treeNode = tvi;
            }

            if (ifcItem.ifcItem == null) {
                // item without visual representation
                ifcItem.treeNode.Foreground = new SolidColorBrush(Colors.Gray);
            }

        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcTreeItem"></param>
        private IFCItem FindIFCItem(IFCItem ifcParent, IFCTreeItem ifcTreeItem)
        {
            if (ifcParent == null) {
                return null;
            }

            IFCItem ifcIterator = ifcParent;
            while (ifcIterator != null) {
                if (ifcIterator.ifcID == ifcTreeItem.instance) {
                    return ifcIterator;
                }

                IFCItem ifcItem = FindIFCItem(ifcIterator.child, ifcTreeItem);
                if (ifcItem != null) {
                    return ifcItem;
                }

                ifcIterator = ifcIterator.next;
            }

            return FindIFCItem(ifcParent.child, ifcTreeItem);
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="ifcTreeItem"></param>
        private void FindNonReferencedIFCItems(IFCItem ifcParent, TreeViewItem tnNotReferenced)
        {
            if (ifcParent == null) {
                return;
            }

            IFCItem ifcIterator = ifcParent;
            while (ifcIterator != null) {
                if ((ifcIterator.ifcTreeItem == null) && (ifcIterator.ifcID != IntPtr.Zero)) {
                    string strItemText = "'" + (string.IsNullOrEmpty(ifcIterator.name) ? "<name>" : ifcIterator.name) +
                            "' = '" + (string.IsNullOrEmpty(ifcIterator.description) ? "<description>" : ifcIterator.description) +
                            "' (" + (string.IsNullOrEmpty(ifcIterator.ifcType) ? ifcIterator.globalID : ifcIterator.ifcType) + ")";

                    IFCTreeItem ifcTreeItem = new IFCTreeItem();
                    ifcTreeItem.instance = ifcIterator.ifcID;
                    TreeViewItem tvi = new TreeViewItem() { Header = strItemText };
                    tnNotReferenced.Items.Add(tvi);
                    ifcTreeItem.treeNode = tvi;
                    ifcTreeItem.ifcItem = FindIFCItem(_ifcRoot, ifcTreeItem);
                    ifcIterator.ifcTreeItem = ifcTreeItem;
                    ifcTreeItem.treeNode.Tag = ifcTreeItem;

                    if (ifcTreeItem.ifcItem != null) {
                        ifcTreeItem.ifcItem.ifcTreeItem = ifcTreeItem;
                    } else {
                    }
                }

                FindNonReferencedIFCItems(ifcIterator.child, tnNotReferenced);

                ifcIterator = ifcIterator.next;
            }

            FindNonReferencedIFCItems(ifcParent.child, tnNotReferenced);
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="iInstance"></param>
        /// <returns></returns>
        private string GetItemType(IntPtr iInstance)
        {
            IntPtr ifcType = _ifcEngine.GetInstanceType(iInstance);
            return Marshal.PtrToStringAnsi(ifcType);
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="iInstance"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        private bool IsInstanceOf(IntPtr iInstance, string strType)
        {
            if (_ifcEngine.GetInstanceType(iInstance) == _ifcEngine.GetEntity(_ifcModel, strType)) {
                return true;
            }

            return false;
        }





    }
}
