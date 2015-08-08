/* ***********************************************
 * author :  LinJiarui
 * email  :  lin@bimer.cn
 * file   :  IfcEngine_x32
 * history:  created by LinJiarui at 2015/8/7 16:59:48
 *           modified by
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ptr32 = System.IntPtr;

namespace IfcEngineCS
{

    public partial class IfcEngine
    {
        public const string Path_x32 = @"IFCEngine_x32.dll";

        #region File IO
        /// <summary>
        /// This call can be used to close a model. Be aware that closing a model will release all memory allocated for this model, handles and strings allocated in the context of this model cannot be trusted anymore after this call.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiCloseModel")]
        internal static extern void sdaiCloseModel_x32(Ptr32 model);


        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="repository">Size: 32 bit / 4 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateModelBN")]
        internal static extern Ptr32 sdaiCreateModelBN_x32(Ptr32 repository, string fileName, string schemaName);


        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="repository">Size: 32 bit / 4 byte (value).Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateModelBN")]
        internal static extern Ptr32 sdaiCreateModelBN_x32(Ptr32 repository, byte[] fileName, byte[] schemaName);

        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="repository">Size: 32 bit / 4 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>

        [DllImport(Path_x32, EntryPoint = "sdaiCreateModelBNUnicode")]
        internal static extern Ptr32 sdaiCreateModelBNUnicode_x32(Ptr32 repository, byte[] fileName, byte[] schemaName);


        /// <summary>
        /// This call is used to open a model with normal ASCII character namings. The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository">Size: 32 bit / 4 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiOpenModelBN")]
        internal static extern Ptr32 sdaiOpenModelBN_x32(Ptr32 repository, string fileName, string schemaName);

        /// <summary>
        /// This call is used to open a model with normal ASCII character namings. The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository">Size: 32 bit / 4 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiOpenModelBN")]
        internal static extern Ptr32 sdaiOpenModelBN_x32(Ptr32 repository, byte[] fileName, byte[] schemaName);

        /// <summary>
        /// This call is used to open a model with Unicode character namings (technically via wchar_t, different lengths (16 bit and 32 bit) on different systems are supported). The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository">Size: 32 bit / 4 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiOpenModelBNUnicode")]
        internal static extern Ptr32 sdaiOpenModelBNUnicode_x32(Ptr32 repository, byte[] fileName, byte[] schemaName);


        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelBN")]
        internal static extern void sdaiSaveModelBN_x32(Ptr32 model, string fileName);


        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelBN")]
        internal static extern void sdaiSaveModelBN_x32(Ptr32 model, byte[] fileName);

        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelBNUnicode")]
        internal static extern void sdaiSaveModelBNUnicode_x32(Ptr32 model, byte[] fileName);

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelAsXmlBN")]
        internal static extern void sdaiSaveModelAsXmlBN_x32(Ptr32 model, string fileName);

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelAsXmlBN")]
        internal static extern void sdaiSaveModelAsXmlBN_x32(Ptr32 model, byte[] fileName);

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelAsXmlBNUnicode")]
        internal static extern void sdaiSaveModelAsXmlBNUnicode_x32(Ptr32 model, byte[] fileName);


        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelAsSimpleXmlBN")]
        internal static extern void sdaiSaveModelAsSimpleXmlBN_x32(Ptr32 model, string fileName);

        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelAsSimpleXmlBN")]
        internal static extern void sdaiSaveModelAsSimpleXmlBN_x32(Ptr32 model, byte[] fileName);
        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 32 bit / 4 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiSaveModelAsSimpleXmlBNUnicode")]
        internal static extern void sdaiSaveModelAsSimpleXmlBNUnicode_x32(Ptr32 model, byte[] fileName);
        #endregion

        #region Schema Reading
        /// <summary>
        /// This call retrieves a handle to an entity based on a given entity name.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entityName">Size: 32 bit / 4 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetEntity")]
        internal static extern Ptr32 sdaiGetEntity_x32(Ptr32 model, string entityName);
        /// <summary>
        /// This call retrieves a handle to an entity based on a given entity name.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entityName">Size: 32 bit / 4 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetEntity")]
        internal static extern Ptr32 sdaiGetEntity_x32(Ptr32 model, byte[] entityName);

        /// <summary>
        /// This call can be used to retrieve the name of the n-th argument of the given entity. Arguments of parent entities are included in the index. Both direct and inverse arguments are included.
        /// </summary>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="index">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="argumentName">Size: 32 bit / 4 byte (reference). Name of the argument (schema attribute/property), for example Name of IFCROOT as defined in IFC4.exp.</param>
        [DllImport(Path_x32, EntryPoint = "engiGetEntityArgumentName")]
        internal static extern void engiGetEntityArgumentName_x32(Ptr32 entity, Ptr32 index, Ptr32 valueType, out IntPtr argumentName);

        /// <summary>
        /// This call can be used to retrieve the type of the n-th argument of the given entity. In case of a select argument no relevant information is given by this call as it depends on the instance. Arguments of parent entities are included in the index. Both direct and inverse arguments are included.
        /// </summary>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="index">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <param name="argumentType">Size: 32 bit / 4 byte (reference). Type of the argument, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        [DllImport(Path_x32, EntryPoint = "engiGetEntityArgumentType")]
        internal static extern void engiGetEntityArgumentType_x32(Ptr32 entity, Ptr32 index, ref Ptr32 argumentType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "engiGetEntityCount")]
        internal static extern Ptr32 engiGetEntityCount_x32(Ptr32 model);

        /// <summary>
        /// This call returns a specific entity based on an index, the index needs to be 0 or higher but lower then the number of entities in the loaded schema.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="index">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "engiGetEntityElement")]
        internal static extern Ptr32 engiGetEntityElement_x32(Ptr32 model, Ptr32 index);

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetEntityExtent")]
        internal static extern Ptr32 sdaiGetEntityExtent_x32(Ptr32 model, Ptr32 entity);

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetEntityExtentBN")]
        internal static extern Ptr32 sdaiGetEntityExtentBN_x32(Ptr32 model, string entityName);

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetEntityExtentBN")]
        internal static extern Ptr32 sdaiGetEntityExtentBN_x32(Ptr32 model, byte[] entityName);

        /// <summary>
        /// This call can be used to get the name of the given entity.
        /// </summary>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="entityName">Size: 32 bit / 4 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        [DllImport(Path_x32, EntryPoint = "engiGetEntityName")]
        internal static extern void engiGetEntityName_x32(Ptr32 entity, Ptr32 valueType, out IntPtr entityName);

        /// <summary>
        /// This call returns the number of arguments, this includes the arguments of its (nested) parents and inverse argumnets.
        /// </summary>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "engiGetEntityNoArguments")]
        internal static extern Ptr32 engiGetEntityNoArguments_x32(Ptr32 entity);

        /// <summary>
        /// Returns the direct parent entity, for example the parent of IfcObject is IfcObjectDefinition, of IfcObjectDefinition is IfcRoot and of IfcRoot is 0.
        /// </summary>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "engiGetEntityParent")]
        internal static extern Ptr32 engiGetEntityParent_x32(Ptr32 entity);

        #endregion

        #region Instance Header
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="itemIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 giving the header element index where this value is placed.</param>
        /// <param name="itemSubIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 giving the header sub element index where this value is placed.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "GetSPFFHeaderItem")]
        internal static extern Ptr32 GetSPFFHeaderItem_x32(Ptr32 model, Ptr32 itemIndex, Ptr32 itemSubIndex, Ptr32 valueType, out IntPtr value);

        /// <summary>
        /// This call is an aggregate of several SetSPFFHeaderItem calls. In several cases the header can be set easily with this call. In case an argument is zero, this argument will not be updated, i.e. it will not be filled with 0.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="description">Size: 32 bit / 4 byte (reference). The description in the header.</param>
        /// <param name="implementationLevel">Size: 32 bit / 4 byte (reference). The implementation level in the header.</param>
        /// <param name="name">Size: 32 bit / 4 byte (reference). The name in the header.</param>
        /// <param name="timeStamp">Size: 32 bit / 4 byte (reference). The time stamp in the header.</param>
        /// <param name="author">Size: 32 bit / 4 byte (reference). The author in the header.</param>
        /// <param name="organization">Size: 32 bit / 4 byte (reference). The organization in the header.</param>
        /// <param name="preprocessorVersion">Size: 32 bit / 4 byte (reference). The preprocessor version in the header.</param>
        /// <param name="originatingSystem">Size: 32 bit / 4 byte (reference). The originating system in the header.</param>
        /// <param name="authorization">Size: 32 bit / 4 byte (reference). The authorization in the header.</param>
        /// <param name="fileSchema">Size: 32 bit / 4 byte (reference). The file schema in the header.</param>
        [DllImport(Path_x32, EntryPoint = "SetSPFFHeader")]
        internal static extern void SetSPFFHeader_x32(Ptr32 model, string description, string implementationLevel, string name, string timeStamp, string author, string organization, string preprocessorVersion, string originatingSystem, string authorization, string fileSchema);

        /// <summary>
        /// This call is an aggregate of several SetSPFFHeaderItem calls. In several cases the header can be set easily with this call. In case an argument is zero, this argument will not be updated, i.e. it will not be filled with 0.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="description">Size: 32 bit / 4 byte (reference). The description in the header.</param>
        /// <param name="implementationLevel">Size: 32 bit / 4 byte (reference). The implementation level in the header.</param>
        /// <param name="name">Size: 32 bit / 4 byte (reference). The name in the header.</param>
        /// <param name="timeStamp">Size: 32 bit / 4 byte (reference). The time stamp in the header.</param>
        /// <param name="author">Size: 32 bit / 4 byte (reference). The author in the header.</param>
        /// <param name="organization">Size: 32 bit / 4 byte (reference). The organization in the header.</param>
        /// <param name="preprocessorVersion">Size: 32 bit / 4 byte (reference). The preprocessor version in the header.</param>
        /// <param name="originatingSystem">Size: 32 bit / 4 byte (reference). The originating system in the header.</param>
        /// <param name="authorization">Size: 32 bit / 4 byte (reference). The authorization in the header.</param>
        /// <param name="fileSchema">Size: 32 bit / 4 byte (reference). The file schema in the header.</param>
        [DllImport(Path_x32, EntryPoint = "SetSPFFHeader")]
        internal static extern void SetSPFFHeader_x32(Ptr32 model, byte[] description, byte[] implementationLevel, byte[] name, byte[] timeStamp, byte[] author, byte[] organization, byte[] preprocessorVersion, byte[] originatingSystem, byte[] authorization, byte[] fileSchema);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="itemIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 giving the header element index where this value is placed.</param>
        /// <param name="itemSubIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 giving the header sub element index where this value is placed.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "SetSPFFHeaderItem")]
        internal static extern Ptr32 SetSPFFHeaderItem_x32(Ptr32 model, Ptr32 itemIndex, Ptr32 itemSubIndex, Ptr32 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="itemIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 giving the header element index where this value is placed.</param>
        /// <param name="itemSubIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 giving the header sub element index where this value is placed.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "SetSPFFHeaderItem")]
        internal static extern Ptr32 SetSPFFHeaderItem_x32(Ptr32 model, Ptr32 itemIndex, Ptr32 itemSubIndex, Ptr32 valueType, byte[] value);
        #endregion

        #region Instance Reading
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 32 bit / 4 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetADBType")]
        internal static extern Ptr32 sdaiGetADBType_x32(Ptr32 ADB);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 32 bit / 4 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="typeNameNumber">Size: 32 bit / 4 byte (value). Enables the user to define the output, typical use is sdaiSTRING, sdaiUNICODE or sdaiEXPRESSSTRING.</param>
        /// <param name="path"></param>
        [DllImport(Path_x32, EntryPoint = "sdaiGetADBTypePathx")]
        internal static extern void sdaiGetADBTypePath_x32(Ptr32 ADB, Ptr32 typeNameNumber, out IntPtr path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 32 bit / 4 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiGetADBValue")]
        internal static extern void sdaiGetADBValue_x32(Ptr32 ADB, Ptr32 valueType, out  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 32 bit / 4 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiGetADBValue")]
        internal static extern void sdaiGetADBValue_x32(Ptr32 ADB, Ptr32 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 32 bit / 4 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="elementIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of list of elements used.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "engiGetAggrElement")]
        internal static extern Ptr32 engiGetAggrElement_x32(Ptr32 aggregate, Ptr32 elementIndex, Ptr32 valueType, out  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 32 bit / 4 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="elementIndex">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of list of elements used.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "engiGetAggrElement")]
        internal static extern Ptr32 engiGetAggrElement_x32(Ptr32 aggregate, Ptr32 elementIndex, Ptr32 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 32 bit / 4 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="aggragateType">Size: 32 bit / 4 byte (reference). Type of the aggregation, for example sdaiINSTANCE, sdaiREAL, ...</param>
        [DllImport(Path_x32, EntryPoint = "engiGetAggrType")]
        internal static extern void engiGetAggrType_x32(Ptr32 aggregate, ref Ptr32 aggragateType);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttr")]
        internal static extern Ptr32 sdaiGetAttr_x32(Ptr32 instance, Ptr32 attribute, Ptr32 valueType, out  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttr")]
        internal static extern Ptr32 sdaiGetAttr_x32(Ptr32 instance, Ptr32 attribute, Ptr32 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttrBN")]
        internal static extern Ptr32 sdaiGetAttrBN_x32(Ptr32 instance, string attributeName, Ptr32 valueType, out  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttrBN")]
        internal static extern Ptr32 sdaiGetAttrBN_x32(Ptr32 instance, string attributeName, Ptr32 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttrBN")]
        internal static extern Ptr32 sdaiGetAttrBN_x32(Ptr32 instance, byte[] attributeName, Ptr32 valueType, out  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttrBN")]
        internal static extern Ptr32 sdaiGetAttrBN_x32(Ptr32 instance, byte[] attributeName, Ptr32 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="attributeName">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttrDefinition")]
        internal static extern Ptr32 sdaiGetAttrDefinition_x32(Ptr32 entity, string attributeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="attributeName">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetAttrDefinition")]
        internal static extern Ptr32 sdaiGetAttrDefinition_x32(Ptr32 entity, byte[] attributeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetInstanceType")]
        internal static extern Ptr32 sdaiGetInstanceType_x32(Ptr32 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 32 bit / 4 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiGetMemberCount")]
        internal static extern Ptr32 sdaiGetMemberCount_x32(Ptr32 aggregate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="entity">Size: 32 bit / 4 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiIsKindOf")]
        internal static extern Ptr32 sdaiIsKindOf_x32(Ptr32 instance, Ptr32 entity);
        #endregion

        #region Instance Wrting
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 32 bit / 4 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiAppend")]
        internal static extern void sdaiAppend_x32(Ptr32 list, Ptr32 valueType, ref  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 32 bit / 4 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiAppend")]
        internal static extern void sdaiAppend_x32(Ptr32 list, Ptr32 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 32 bit / 4 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiAppend")]
        internal static extern void sdaiAppend_x32(Ptr32 list, Ptr32 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 32 bit / 4 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiAppend")]
        internal static extern void sdaiAppend_x32(Ptr32 list, Ptr32 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateADB")]
        internal static extern Ptr32 sdaiCreateADB_x32(Ptr32 valueType, ref  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateADB")]
        internal static extern Ptr32 sdaiCreateADB_x32(Ptr32 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateADB")]
        internal static extern Ptr32 sdaiCreateADB_x32(Ptr32 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateADB")]
        internal static extern Ptr32 sdaiCreateADB_x32(Ptr32 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateAggr")]
        internal static extern Ptr32 sdaiCreateAggr_x32(Ptr32 instance, Ptr32 attribute);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateAggrBN")]
        internal static extern Ptr32 sdaiCreateAggrBN_x32(Ptr32 instance, string attributeName);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateAggrBN")]
        internal static extern Ptr32 sdaiCreateAggrBN_x32(Ptr32 instance, byte[] attributeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 32 bit / 4 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateInstance")]
        internal static extern Ptr32 sdaiCreateInstance_x32(Ptr32 model, Ptr32 entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 32 bit / 4 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateInstanceBN")]
        internal static extern Ptr32 sdaiCreateInstanceBN_x32(Ptr32 model, string entityName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 32 bit / 4 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "sdaiCreateInstanceBN")]
        internal static extern Ptr32 sdaiCreateInstanceBN_x32(Ptr32 model, byte[] entityName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        [DllImport(Path_x32, EntryPoint = "sdaiDeleteInstance")]
        internal static extern void sdaiDeleteInstance_x32(Ptr32 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 32 bit / 4 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="pathCount">Size: 32 bit / 4 byte (value). The number of path's for this ADB type, in case of IFC4 and all earlier versions this should always be 1.</param>
        /// <param name="path">Size: 32 bit / 4 byte (reference). The path of the ADB type, in case of example IFCLABEL('myLabel') the path is "IFCLABEL".</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutADBTypePath")]
        internal static extern void sdaiPutADBTypePath_x32(Ptr32 ADB, Ptr32 pathCount, string path);

        // <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 32 bit / 4 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="pathCount">Size: 32 bit / 4 byte (value). The number of path's for this ADB type, in case of IFC4 and all earlier versions this should always be 1.</param>
        /// <param name="path">Size: 32 bit / 4 byte (reference). The path of the ADB type, in case of example IFCLABEL('myLabel') the path is "IFCLABEL".</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutADBTypePath")]
        internal static extern void sdaiPutADBTypePath_x32(Ptr32 ADB, Ptr32 pathCount, byte[] path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttr")]
        internal static extern void sdaiPutAttr_x32(Ptr32 instance, Ptr32 attribute, Ptr32 valueType, ref  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttr")]
        internal static extern void sdaiPutAttr_x32(Ptr32 instance, Ptr32 attribute, Ptr32 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttr")]
        internal static extern void sdaiPutAttr_x32(Ptr32 instance, Ptr32 attribute, Ptr32 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttr")]
        internal static extern void sdaiPutAttr_x32(Ptr32 instance, Ptr32 attribute, Ptr32 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, string attributeName, Ptr32 valueType, ref  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, string attributeName, Ptr32 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, string attributeName, Ptr32 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, string attributeName, Ptr32 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, byte[] attributeName, Ptr32 valueType, ref  Ptr32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, byte[] attributeName, Ptr32 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, byte[] attributeName, Ptr32 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 32 bit / 4 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 32 bit / 4 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 32 bit / 4 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x32, EntryPoint = "sdaiPutAttrBN")]
        internal static extern void sdaiPutAttrBN_x32(Ptr32 instance, byte[] attributeName, Ptr32 valueType, byte[] value);

        /// <summary>
        /// This call can be used to add a comment to an instance when exporting the content. The comment is available in the exported/saved IFC file.
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="comment">Size: 32 bit / 4 byte (reference). A string value that will be included in the exported IFC file as comment to the instance.</param>
        [DllImport(Path_x32, EntryPoint = "engiSetComment")]
        internal static extern void engiSetComment_x32(Ptr32 instance, string comment);

        /// <summary>
        /// This call can be used to add a comment to an instance when exporting the content. The comment is available in the exported/saved IFC file.
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="comment">Size: 32 bit / 4 byte (reference). A string value that will be included in the exported IFC file as comment to the instance.</param>
        [DllImport(Path_x32, EntryPoint = "engiSetComment")]
        internal static extern void engiSetComment_x32(Ptr32 instance, byte[] comment);
        #endregion

        #region Controling Calls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="circles">Size: 32 bit / 4 byte (value). Segmentation parts of a complete or large part of a circle (default is 36).</param>
        /// <param name="smallCircles">Size: 32 bit / 4 byte (value). Segmentation parts of a small part of a circle (default is 5).</param>
        [DllImport(Path_x32, EntryPoint = "circleSegments")]
        internal static extern void circleSegments_x32(Ptr32 circles, Ptr32 smallCircles);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="mode">Size: 32 bit / 4 byte (value). ...</param>
        [DllImport(Path_x32, EntryPoint = "cleanMemory")]
        internal static extern void cleanMemory_x32(Ptr32 model, Ptr32 mode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "internalGetP21Line")]
        internal static extern Ptr32 internalGetP21Line_x32(Ptr32 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="P21Line">Size: 32 bit / 4 byte (value). SPFF address line, i.e. 31313 in line '#31313 = IFCWALLSTANDARDCASE(...);'.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "internalGetInstanceFromP21Line")]
        internal static extern Ptr32 internalGetInstanceFromP21Line_x32(Ptr32 model, Ptr32 P21Line);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unicode">Size: 32 bit / 4 byte (value). If non-zero entity names and attribute names given are expected to be in wchar_t format, in case unicode = 0 the names expected to be given as ASCII.</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "setStringUnicode")]
        internal static extern Ptr32 setStringUnicode_x32(Ptr32 unicode);
        #endregion

        #region Geometry Interaction
        /// <summary>
        /// The number of vertices and number of indices needed for storing the geometry of the given IFC instance is calculated by this function.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="noVertices">Size: 32 bit / 4 byte (reference). The number of vertices that are needed for this instance.</param>
        /// <param name="noIndices">Size: 32 bit / 4 byte (reference). The number of indices that are needed for this instance.</param>
        /// <param name="scale">Size: 32 bit / 4 byte (value). Ignore this argument use 1 as default value.</param>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "initializeModellingInstance")]
        internal static extern Ptr32 initializeModellingInstance_x32(Ptr32 model, ref Ptr32 noVertices, ref Ptr32 noIndices, double scale, Ptr32 instance);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 32 bit / 4 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 32 bit / 4 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 32 bit / 4 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "finalizeModelling")]
        internal static extern Ptr32 finalizeModelling_x32(Ptr32 model, float[] vertices, Int32[] indices, Ptr32 FVF);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 32 bit / 4 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 32 bit / 4 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 32 bit / 4 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "finalizeModelling")]
        internal static extern Ptr32 finalizeModelling_x32(Ptr32 model, float[] vertices, Int64[] indices, Ptr32 FVF);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 32 bit / 4 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 32 bit / 4 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 32 bit / 4 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "finalizeModelling")]
        internal static extern Ptr32 finalizeModelling_x32(Ptr32 model, double[] vertices, Int32[] indices, Ptr32 FVF);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 32 bit / 4 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 32 bit / 4 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 32 bit / 4 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "finalizeModelling")]
        internal static extern Ptr32 finalizeModelling_x32(Ptr32 model, double[] vertices, Int64[] indices, Ptr32 FVF);

        /// <summary>
        /// This call will return the part of the index array representing the triangle set that visualizes the IFC instance. This call is only relevant if purely the triangulated geometry is generated (setFormat is not requesting points, lines or wireframe). For geometry also containing points, lines and/or wireframe representations the calls getConceptualFaceCnt() and getConceptualFaceEx() should be used.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="mode">Size: 32 bit / 4 byte (value). ...</param>
        /// <param name="startVertex">Size: 32 bit / 4 byte (reference). The first vertex in the array of relevance for this instance (can be used to improve performance of the rendering engine).</param>
        /// <param name="startIndex">Size: 32 bit / 4 byte (reference). The first index in the array of relevance for this instance (can be used to improve performance of the rendering engine).</param>
        /// <param name="primitiveCount">Size: 32 bit / 4 byte (reference). The number of primitives available (for example 4 primitives and the case we have triangles means 12 following indices representing the data on the index array).</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "getInstanceInModelling")]
        internal static extern Ptr32 getInstanceInModelling_x32(Ptr32 model, Ptr32 instance, Ptr32 mode, ref Ptr32 startVertex, ref Ptr32 startIndex, ref Ptr32 primitiveCount);

        /// <summary>
        /// This call will update the vertex offset of the returned geometry. Some IFC files have the origin placed far far away from the actual geometry, in case 32 bit precision vertices are requested (what is default), the converted results from internal 64 bit representation could cause visual disturbances due to precision limitations in 32 bit that can be solved by moving the origin of the geometry closer to the actual geometry.
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="x">Size: 32 bit / 4 byte (value). X value for offset of each vertex.</param>
        /// <param name="y">Size: 32 bit / 4 byte (value). Y value for offset of each vertex.</param>
        /// <param name="z">Size: 32 bit / 4 byte (value). Z value for offset of each vertex.</param>
        [DllImport(Path_x32, EntryPoint = "setVertexOffset")]
        internal static extern void setVertexOffset_x32(Ptr32 model, double x, double y, double z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="setting">Size: 32 bit / 4 byte (value). ...</param>
        /// <param name="mask">Size: 32 bit / 4 byte (value). ...</param>
        [DllImport(Path_x32, EntryPoint = "setFilter")]
        internal static extern void setFilter_x32(Ptr32 model, Ptr32 setting, Ptr32 mask);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 32 bit / 4 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="setting">Size: 32 bit / 4 byte (value). ...</param>
        /// <param name="mask">Size: 32 bit / 4 byte (value). ...</param>
        [DllImport(Path_x32, EntryPoint = "setFormat")]
        internal static extern void setFormat_x32(Ptr32 model, Ptr32 setting, Ptr32 mask);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "getConceptualFaceCnt")]

        internal static extern Ptr32 getConceptualFaceCnt_x32(Ptr32 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 32 bit / 4 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="index">Size: 32 bit / 4 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <param name="startIndexTriangles">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="noIndicesTriangles">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="startIndexLines">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="noIndicesLines">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="startIndexPoints">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="noIndicesPoints">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="startIndexFacesPolygons">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="noIndicesFacesPolygons">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="startIndexConceptualFacePolygons">Size: 32 bit / 4 byte (reference). ...</param>
        /// <param name="noIndicesConceptualFacePolygons">Size: 32 bit / 4 byte (reference). ...</param>
        /// <returns></returns>
        [DllImport(Path_x32, EntryPoint = "getConceptualFaceEx")]
        internal static extern Ptr32 getConceptualFaceEx_x32(Ptr32 instance, Ptr32 index, ref Ptr32 startIndexTriangles, ref Ptr32 noIndicesTriangles, ref Ptr32 startIndexLines, ref Ptr32 noIndicesLines, ref Ptr32 startIndexPoints, ref Ptr32 noIndicesPoints, ref Ptr32 startIndexFacesPolygons, ref Ptr32 noIndicesFacesPolygons, ref Ptr32 startIndexConceptualFacePolygons, ref Ptr32 noIndicesConceptualFacePolygons);
        #endregion
    }

}
