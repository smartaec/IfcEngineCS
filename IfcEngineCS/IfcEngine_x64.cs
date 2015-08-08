/* ***********************************************
 * author :  LinJiarui
 * email  :  lin@bimer.cn
 * file   :  IfcEngine_x64
 * history:  created by LinJiarui at 2015/8/7 16:58:55
 *           modified by
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ptr64 = System.IntPtr;

namespace IfcEngineCS
{
    public partial class IfcEngine
    {
        public const string Path_x64 = @"IFCEngine_x64.dll";

        #region File IO
        /// <summary>
        /// This call can be used to close a model. Be aware that closing a model will release all memory allocated for this model, handles and strings allocated in the context of this model cannot be trusted anymore after this call.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiCloseModel")]
        internal static extern  void sdaiCloseModel_x64(Ptr64 model);


        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="repository">Size: 64 bit / 8 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateModelBN")]
        internal static extern  Ptr64 sdaiCreateModelBN_x64(Ptr64 repository, string fileName, string schemaName);


        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="repository">Size: 64 bit / 8 byte (value).Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateModelBN")]
        internal static extern  Ptr64 sdaiCreateModelBN_x64(Ptr64 repository, byte[] fileName, byte[] schemaName);

        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="repository">Size: 64 bit / 8 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>

        [DllImport(Path_x64, EntryPoint = "sdaiCreateModelBNUnicode")]
        internal static extern  Ptr64 sdaiCreateModelBNUnicode_x64(Ptr64 repository, byte[] fileName, byte[] schemaName);


        /// <summary>
        /// This call is used to open a model with normal ASCII character namings. The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository">Size: 64 bit / 8 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiOpenModelBN")]
        internal static extern  Ptr64 sdaiOpenModelBN_x64(Ptr64 repository, string fileName, string schemaName);

        /// <summary>
        /// This call is used to open a model with normal ASCII character namings. The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository">Size: 64 bit / 8 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiOpenModelBN")]
        internal static extern  Ptr64 sdaiOpenModelBN_x64(Ptr64 repository, byte[] fileName, byte[] schemaName);

        /// <summary>
        /// This call is used to open a model with Unicode character namings (technically via wchar_t, different lengths (16 bit and 32 bit) on different systems are supported). The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository">Size: 64 bit / 8 byte (value). Not relevant within the IFC Engine DLL, although several models can be loaded at once, they will always be in separate models.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        /// <param name="schemaName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC schema, for example 'C:\myPath\IFC4.exp'.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiOpenModelBNUnicode")]
        internal static extern  Ptr64 sdaiOpenModelBNUnicode_x64(Ptr64 repository, byte[] fileName, byte[] schemaName);


        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelBN")]
        internal static extern  void sdaiSaveModelBN_x64(Ptr64 model, string fileName);


        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelBN")]
        internal static extern  void sdaiSaveModelBN_x64(Ptr64 model, byte[] fileName);

        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelBNUnicode")]
        internal static extern  void sdaiSaveModelBNUnicode_x64(Ptr64 model, byte[] fileName);

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelAsXmlBN")]
        internal static extern  void sdaiSaveModelAsXmlBN_x64(Ptr64 model, string fileName);

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelAsXmlBN")]
        internal static extern  void sdaiSaveModelAsXmlBN_x64(Ptr64 model, byte[] fileName);

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelAsXmlBNUnicode")]
        internal static extern  void sdaiSaveModelAsXmlBNUnicode_x64(Ptr64 model, byte[] fileName);


        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelAsSimpleXmlBN")]
        internal static extern  void sdaiSaveModelAsSimpleXmlBN_x64(Ptr64 model, string fileName);

        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelAsSimpleXmlBN")]
        internal static extern  void sdaiSaveModelAsSimpleXmlBN_x64(Ptr64 model, byte[] fileName);
        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="fileName">Size: 64 bit / 8 byte (reference). Address of string containing the path of the IFC file, for example 'C:\myPath\myFile.ifc' or 'C:\myPath\myFile.ifcXML'.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiSaveModelAsSimpleXmlBNUnicode")]
        internal static extern  void sdaiSaveModelAsSimpleXmlBNUnicode_x64(Ptr64 model, byte[] fileName);
        #endregion

        #region Schema Reading
        /// <summary>
        /// This call retrieves a handle to an entity based on a given entity name.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entityName">Size: 64 bit / 8 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetEntity")]
        internal static extern  Ptr64 sdaiGetEntity_x64(Ptr64 model, string entityName);
        /// <summary>
        /// This call retrieves a handle to an entity based on a given entity name.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entityName">Size: 64 bit / 8 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetEntity")]
        internal static extern  Ptr64 sdaiGetEntity_x64(Ptr64 model, byte[] entityName);

        /// <summary>
        /// This call can be used to retrieve the name of the n-th argument of the given entity. Arguments of parent entities are included in the index. Both direct and inverse arguments are included.
        /// </summary>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="index">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="argumentName">Size: 64 bit / 8 byte (reference). Name of the argument (schema attribute/property), for example Name of IFCROOT as defined in IFC4.exp.</param>
        [DllImport(Path_x64, EntryPoint = "engiGetEntityArgumentName")]
        internal static extern  void engiGetEntityArgumentName_x64(Ptr64 entity, Ptr64 index, Ptr64 valueType, out IntPtr argumentName);

        /// <summary>
        /// This call can be used to retrieve the type of the n-th argument of the given entity. In case of a select argument no relevant information is given by this call as it depends on the instance. Arguments of parent entities are included in the index. Both direct and inverse arguments are included.
        /// </summary>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="index">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <param name="argumentType">Size: 64 bit / 8 byte (reference). Type of the argument, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        [DllImport(Path_x64, EntryPoint = "engiGetEntityArgumentType")]
        internal static extern  void engiGetEntityArgumentType_x64(Ptr64 entity, Ptr64 index, ref Ptr64 argumentType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "engiGetEntityCount")]
        internal static extern  Ptr64 engiGetEntityCount_x64(Ptr64 model);

        /// <summary>
        /// This call returns a specific entity based on an index, the index needs to be 0 or higher but lower then the number of entities in the loaded schema.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="index">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "engiGetEntityElement")]
        internal static extern  Ptr64 engiGetEntityElement_x64(Ptr64 model, Ptr64 index);

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetEntityExtent")]
        internal static extern  Ptr64 sdaiGetEntityExtent_x64(Ptr64 model, Ptr64 entity);

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetEntityExtentBN")]
        internal static extern  Ptr64 sdaiGetEntityExtentBN_x64(Ptr64 model, string entityName);

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetEntityExtentBN")]
        internal static extern  Ptr64 sdaiGetEntityExtentBN_x64(Ptr64 model, byte[] entityName);

        /// <summary>
        /// This call can be used to get the name of the given entity.
        /// </summary>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="entityName">Size: 64 bit / 8 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        [DllImport(Path_x64, EntryPoint = "engiGetEntityName")]
        internal static extern  void engiGetEntityName_x64(Ptr64 entity, Ptr64 valueType, out IntPtr entityName);

        /// <summary>
        /// This call returns the number of arguments, this includes the arguments of its (nested) parents and inverse argumnets.
        /// </summary>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "engiGetEntityNoArguments")]
        internal static extern  Ptr64 engiGetEntityNoArguments_x64(Ptr64 entity);

        /// <summary>
        /// Returns the direct parent entity, for example the parent of IfcObject is IfcObjectDefinition, of IfcObjectDefinition is IfcRoot and of IfcRoot is 0.
        /// </summary>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "engiGetEntityParent")]
        internal static extern  Ptr64 engiGetEntityParent_x64(Ptr64 entity);

        #endregion

        #region Instance Header
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="itemIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 giving the header element index where this value is placed.</param>
        /// <param name="itemSubIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 giving the header sub element index where this value is placed.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "GetSPFFHeaderItem")]
        internal static extern  Ptr64 GetSPFFHeaderItem_x64(Ptr64 model, Ptr64 itemIndex, Ptr64 itemSubIndex, Ptr64 valueType, out IntPtr value);

        /// <summary>
        /// This call is an aggregate of several SetSPFFHeaderItem calls. In several cases the header can be set easily with this call. In case an argument is zero, this argument will not be updated, i.e. it will not be filled with 0.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="description">Size: 64 bit / 8 byte (reference). The description in the header.</param>
        /// <param name="implementationLevel">Size: 64 bit / 8 byte (reference). The implementation level in the header.</param>
        /// <param name="name">Size: 64 bit / 8 byte (reference). The name in the header.</param>
        /// <param name="timeStamp">Size: 64 bit / 8 byte (reference). The time stamp in the header.</param>
        /// <param name="author">Size: 64 bit / 8 byte (reference). The author in the header.</param>
        /// <param name="organization">Size: 64 bit / 8 byte (reference). The organization in the header.</param>
        /// <param name="preprocessorVersion">Size: 64 bit / 8 byte (reference). The preprocessor version in the header.</param>
        /// <param name="originatingSystem">Size: 64 bit / 8 byte (reference). The originating system in the header.</param>
        /// <param name="authorization">Size: 64 bit / 8 byte (reference). The authorization in the header.</param>
        /// <param name="fileSchema">Size: 64 bit / 8 byte (reference). The file schema in the header.</param>
        [DllImport(Path_x64, EntryPoint = "SetSPFFHeader")]
        internal static extern  void SetSPFFHeader_x64(Ptr64 model, string description, string implementationLevel, string name, string timeStamp, string author, string organization, string preprocessorVersion, string originatingSystem, string authorization, string fileSchema);

        /// <summary>
        /// This call is an aggregate of several SetSPFFHeaderItem calls. In several cases the header can be set easily with this call. In case an argument is zero, this argument will not be updated, i.e. it will not be filled with 0.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="description">Size: 64 bit / 8 byte (reference). The description in the header.</param>
        /// <param name="implementationLevel">Size: 64 bit / 8 byte (reference). The implementation level in the header.</param>
        /// <param name="name">Size: 64 bit / 8 byte (reference). The name in the header.</param>
        /// <param name="timeStamp">Size: 64 bit / 8 byte (reference). The time stamp in the header.</param>
        /// <param name="author">Size: 64 bit / 8 byte (reference). The author in the header.</param>
        /// <param name="organization">Size: 64 bit / 8 byte (reference). The organization in the header.</param>
        /// <param name="preprocessorVersion">Size: 64 bit / 8 byte (reference). The preprocessor version in the header.</param>
        /// <param name="originatingSystem">Size: 64 bit / 8 byte (reference). The originating system in the header.</param>
        /// <param name="authorization">Size: 64 bit / 8 byte (reference). The authorization in the header.</param>
        /// <param name="fileSchema">Size: 64 bit / 8 byte (reference). The file schema in the header.</param>
        [DllImport(Path_x64, EntryPoint = "SetSPFFHeader")]
        internal static extern  void SetSPFFHeader_x64(Ptr64 model, byte[] description, byte[] implementationLevel, byte[] name, byte[] timeStamp, byte[] author, byte[] organization, byte[] preprocessorVersion, byte[] originatingSystem, byte[] authorization, byte[] fileSchema);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="itemIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 giving the header element index where this value is placed.</param>
        /// <param name="itemSubIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 giving the header sub element index where this value is placed.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "SetSPFFHeaderItem")]
        internal static extern  Ptr64 SetSPFFHeaderItem_x64(Ptr64 model, Ptr64 itemIndex, Ptr64 itemSubIndex, Ptr64 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="itemIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 giving the header element index where this value is placed.</param>
        /// <param name="itemSubIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 giving the header sub element index where this value is placed.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "SetSPFFHeaderItem")]
        internal static extern  Ptr64 SetSPFFHeaderItem_x64(Ptr64 model, Ptr64 itemIndex, Ptr64 itemSubIndex, Ptr64 valueType, byte[] value);
        #endregion

        #region Instance Reading
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 64 bit / 8 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetADBType")]
        internal static extern  Ptr64 sdaiGetADBType_x64(Ptr64 ADB);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 64 bit / 8 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="typeNameNumber">Size: 64 bit / 8 byte (value). Enables the user to define the output, typical use is sdaiSTRING, sdaiUNICODE or sdaiEXPRESSSTRING.</param>
        /// <param name="path"></param>
        [DllImport(Path_x64, EntryPoint = "sdaiGetADBTypePathx")]
        internal static extern  void sdaiGetADBTypePath_x64(Ptr64 ADB, Ptr64 typeNameNumber, out IntPtr path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 64 bit / 8 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiGetADBValue")]
        internal static extern  void sdaiGetADBValue_x64(Ptr64 ADB, Ptr64 valueType, out  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 64 bit / 8 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiGetADBValue")]
        internal static extern  void sdaiGetADBValue_x64(Ptr64 ADB, Ptr64 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 64 bit / 8 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="elementIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of list of elements used.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "engiGetAggrElement")]
        internal static extern  Ptr64 engiGetAggrElement_x64(Ptr64 aggregate, Ptr64 elementIndex, Ptr64 valueType, out  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 64 bit / 8 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="elementIndex">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of list of elements used.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "engiGetAggrElement")]
        internal static extern  Ptr64 engiGetAggrElement_x64(Ptr64 aggregate, Ptr64 elementIndex, Ptr64 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 64 bit / 8 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="aggragateType">Size: 64 bit / 8 byte (reference). Type of the aggregation, for example sdaiINSTANCE, sdaiREAL, ...</param>
        [DllImport(Path_x64, EntryPoint = "engiGetAggrType")]
        internal static extern  void engiGetAggrType_x64(Ptr64 aggregate, ref Ptr64 aggragateType);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttr")]
        internal static extern  Ptr64 sdaiGetAttr_x64(Ptr64 instance, Ptr64 attribute, Ptr64 valueType, out  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttr")]
        internal static extern  Ptr64 sdaiGetAttr_x64(Ptr64 instance, Ptr64 attribute, Ptr64 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttrBN")]
        internal static extern  Ptr64 sdaiGetAttrBN_x64(Ptr64 instance, string attributeName, Ptr64 valueType, out  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttrBN")]
        internal static extern  Ptr64 sdaiGetAttrBN_x64(Ptr64 instance, string attributeName, Ptr64 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttrBN")]
        internal static extern  Ptr64 sdaiGetAttrBN_x64(Ptr64 instance, byte[] attributeName, Ptr64 valueType, out  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttrBN")]
        internal static extern  Ptr64 sdaiGetAttrBN_x64(Ptr64 instance, byte[] attributeName, Ptr64 valueType, out double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="attributeName">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttrDefinition")]
        internal static extern  Ptr64 sdaiGetAttrDefinition_x64(Ptr64 entity, string attributeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="attributeName">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetAttrDefinition")]
        internal static extern  Ptr64 sdaiGetAttrDefinition_x64(Ptr64 entity, byte[] attributeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetInstanceType")]
        internal static extern  Ptr64 sdaiGetInstanceType_x64(Ptr64 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Size: 64 bit / 8 byte (value). Handle of an aggregation (i.e. sorted collection).</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiGetMemberCount")]
        internal static extern  Ptr64 sdaiGetMemberCount_x64(Ptr64 aggregate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="entity">Size: 64 bit / 8 byte (value). Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiIsKindOf")]
        internal static extern  Ptr64 sdaiIsKindOf_x64(Ptr64 instance, Ptr64 entity);
        #endregion

        #region Instance Wrting
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 64 bit / 8 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiAppend")]
        internal static extern  void sdaiAppend_x64(Ptr64 list, Ptr64 valueType, ref  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 64 bit / 8 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiAppend")]
        internal static extern  void sdaiAppend_x64(Ptr64 list, Ptr64 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 64 bit / 8 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiAppend")]
        internal static extern  void sdaiAppend_x64(Ptr64 list, Ptr64 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">Size: 64 bit / 8 byte (value). A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiAppend")]
        internal static extern  void sdaiAppend_x64(Ptr64 list, Ptr64 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateADB")]
        internal static extern  Ptr64 sdaiCreateADB_x64(Ptr64 valueType, ref  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateADB")]
        internal static extern  Ptr64 sdaiCreateADB_x64(Ptr64 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateADB")]
        internal static extern  Ptr64 sdaiCreateADB_x64(Ptr64 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateADB")]
        internal static extern  Ptr64 sdaiCreateADB_x64(Ptr64 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateAggr")]
        internal static extern  Ptr64 sdaiCreateAggr_x64(Ptr64 instance, Ptr64 attribute);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateAggrBN")]
        internal static extern  Ptr64 sdaiCreateAggrBN_x64(Ptr64 instance, string attributeName);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (value). A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateAggrBN")]
        internal static extern  Ptr64 sdaiCreateAggrBN_x64(Ptr64 instance, byte[] attributeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 64 bit / 8 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateInstance")]
        internal static extern  Ptr64 sdaiCreateInstance_x64(Ptr64 model, Ptr64 entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 64 bit / 8 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateInstanceBN")]
        internal static extern  Ptr64 sdaiCreateInstanceBN_x64(Ptr64 model, string entityName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Size: 64 bit / 8 byte (reference). Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "sdaiCreateInstanceBN")]
        internal static extern  Ptr64 sdaiCreateInstanceBN_x64(Ptr64 model, byte[] entityName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        [DllImport(Path_x64, EntryPoint = "sdaiDeleteInstance")]
        internal static extern  void sdaiDeleteInstance_x64(Ptr64 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 64 bit / 8 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="pathCount">Size: 64 bit / 8 byte (value). The number of path's for this ADB type, in case of IFC4 and all earlier versions this should always be 1.</param>
        /// <param name="path">Size: 64 bit / 8 byte (reference). The path of the ADB type, in case of example IFCLABEL('myLabel') the path is "IFCLABEL".</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutADBTypePath")]
        internal static extern  void sdaiPutADBTypePath_x64(Ptr64 ADB, Ptr64 pathCount, string path);

        // <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Size: 64 bit / 8 byte (value). Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="pathCount">Size: 64 bit / 8 byte (value). The number of path's for this ADB type, in case of IFC4 and all earlier versions this should always be 1.</param>
        /// <param name="path">Size: 64 bit / 8 byte (reference). The path of the ADB type, in case of example IFCLABEL('myLabel') the path is "IFCLABEL".</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutADBTypePath")]
        internal static extern  void sdaiPutADBTypePath_x64(Ptr64 ADB, Ptr64 pathCount, byte[] path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttr")]
        internal static extern  void sdaiPutAttr_x64(Ptr64 instance, Ptr64 attribute, Ptr64 valueType, ref  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttr")]
        internal static extern  void sdaiPutAttr_x64(Ptr64 instance, Ptr64 attribute, Ptr64 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttr")]
        internal static extern  void sdaiPutAttr_x64(Ptr64 instance, Ptr64 attribute, Ptr64 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttr")]
        internal static extern  void sdaiPutAttr_x64(Ptr64 instance, Ptr64 attribute, Ptr64 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, string attributeName, Ptr64 valueType, ref  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, string attributeName, Ptr64 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, string attributeName, Ptr64 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, string attributeName, Ptr64 valueType, byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, byte[] attributeName, Ptr64 valueType, ref  Ptr64 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, byte[] attributeName, Ptr64 valueType, ref double value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, byte[] attributeName, Ptr64 valueType, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">Size: 64 bit / 8 byte (reference). Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Size: 64 bit / 8 byte (value). Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Size: 64 bit / 8 byte (reference). Placeholder for the information, formatting depending on defined valueType.</param>
        [DllImport(Path_x64, EntryPoint = "sdaiPutAttrBN")]
        internal static extern  void sdaiPutAttrBN_x64(Ptr64 instance, byte[] attributeName, Ptr64 valueType, byte[] value);

        /// <summary>
        /// This call can be used to add a comment to an instance when exporting the content. The comment is available in the exported/saved IFC file.
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="comment">Size: 64 bit / 8 byte (reference). A string value that will be included in the exported IFC file as comment to the instance.</param>
        [DllImport(Path_x64, EntryPoint = "engiSetComment")]
        internal static extern  void engiSetComment_x64(Ptr64 instance, string comment);

        /// <summary>
        /// This call can be used to add a comment to an instance when exporting the content. The comment is available in the exported/saved IFC file.
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="comment">Size: 64 bit / 8 byte (reference). A string value that will be included in the exported IFC file as comment to the instance.</param>
        [DllImport(Path_x64, EntryPoint = "engiSetComment")]
        internal static extern  void engiSetComment_x64(Ptr64 instance, byte[] comment);
        #endregion

        #region Controling Calls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="circles">Size: 64 bit / 8 byte (value). Segmentation parts of a complete or large part of a circle (default is 36).</param>
        /// <param name="smallCircles">Size: 64 bit / 8 byte (value). Segmentation parts of a small part of a circle (default is 5).</param>
        [DllImport(Path_x64, EntryPoint = "circleSegments")]
        internal static extern  void circleSegments_x64(Ptr64 circles, Ptr64 smallCircles);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="mode">Size: 64 bit / 8 byte (value). ...</param>
        [DllImport(Path_x64, EntryPoint = "cleanMemory")]
        internal static extern  void cleanMemory_x64(Ptr64 model, Ptr64 mode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "internalGetP21Line")]
        internal static extern  Ptr64 internalGetP21Line_x64(Ptr64 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="P21Line">Size: 64 bit / 8 byte (value). SPFF address line, i.e. 31313 in line '#31313 = IFCWALLSTANDARDCASE(...);'.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "internalGetInstanceFromP21Line")]
        internal static extern  Ptr64 internalGetInstanceFromP21Line_x64(Ptr64 model, Ptr64 P21Line);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unicode">Size: 64 bit / 8 byte (value). If non-zero entity names and attribute names given are expected to be in wchar_t format, in case unicode = 0 the names expected to be given as ASCII.</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "setStringUnicode")]
        internal static extern  Ptr64 setStringUnicode_x64(Ptr64 unicode);
        #endregion

        #region Geometry Interaction
        /// <summary>
        /// The number of vertices and number of indices needed for storing the geometry of the given IFC instance is calculated by this function.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="noVertices">Size: 64 bit / 8 byte (reference). The number of vertices that are needed for this instance.</param>
        /// <param name="noIndices">Size: 64 bit / 8 byte (reference). The number of indices that are needed for this instance.</param>
        /// <param name="scale">Size: 64 bit / 8 byte (value). Ignore this argument use 1 as default value.</param>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "initializeModellingInstance")]
        internal static extern  Ptr64 initializeModellingInstance_x64(Ptr64 model, ref Ptr64 noVertices, ref Ptr64 noIndices, double scale, Ptr64 instance);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 64 bit / 8 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 64 bit / 8 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 64 bit / 8 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "finalizeModelling")]
        internal static extern  Ptr64 finalizeModelling_x64(Ptr64 model, float[] vertices, Int32[] indices, Ptr64 FVF);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 64 bit / 8 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 64 bit / 8 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 64 bit / 8 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "finalizeModelling")]
        internal static extern  Ptr64 finalizeModelling_x64(Ptr64 model, float[] vertices, Int64[] indices, Ptr64 FVF);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 64 bit / 8 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 64 bit / 8 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 64 bit / 8 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "finalizeModelling")]
        internal static extern  Ptr64 finalizeModelling_x64(Ptr64 model, double[] vertices, Int32[] indices, Ptr64 FVF);

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">Size: 64 bit / 8 byte (reference). The array containing the space for vertex information.</param>
        /// <param name="indices">Size: 64 bit / 8 byte (reference). The array containing the space for index information.</param>
        /// <param name="FVF">Size: 64 bit / 8 byte (value). Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "finalizeModelling")]
        internal static extern  Ptr64 finalizeModelling_x64(Ptr64 model, double[] vertices, Int64[] indices, Ptr64 FVF);

        /// <summary>
        /// This call will return the part of the index array representing the triangle set that visualizes the IFC instance. This call is only relevant if purely the triangulated geometry is generated (setFormat is not requesting points, lines or wireframe). For geometry also containing points, lines and/or wireframe representations the calls getConceptualFaceCnt() and getConceptualFaceEx() should be used.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="mode">Size: 64 bit / 8 byte (value). ...</param>
        /// <param name="startVertex">Size: 64 bit / 8 byte (reference). The first vertex in the array of relevance for this instance (can be used to improve performance of the rendering engine).</param>
        /// <param name="startIndex">Size: 64 bit / 8 byte (reference). The first index in the array of relevance for this instance (can be used to improve performance of the rendering engine).</param>
        /// <param name="primitiveCount">Size: 64 bit / 8 byte (reference). The number of primitives available (for example 4 primitives and the case we have triangles means 12 following indices representing the data on the index array).</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "getInstanceInModelling")]
        internal static extern  Ptr64 getInstanceInModelling_x64(Ptr64 model, Ptr64 instance, Ptr64 mode, ref Ptr64 startVertex, ref Ptr64 startIndex, ref Ptr64 primitiveCount);

        /// <summary>
        /// This call will update the vertex offset of the returned geometry. Some IFC files have the origin placed far far away from the actual geometry, in case 32 bit precision vertices are requested (what is default), the converted results from internal 64 bit representation could cause visual disturbances due to precision limitations in 32 bit that can be solved by moving the origin of the geometry closer to the actual geometry.
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="x">Size: 64 bit / 8 byte (value). X value for offset of each vertex.</param>
        /// <param name="y">Size: 64 bit / 8 byte (value). Y value for offset of each vertex.</param>
        /// <param name="z">Size: 64 bit / 8 byte (value). Z value for offset of each vertex.</param>
        [DllImport(Path_x64, EntryPoint = "setVertexOffset")]
        internal static extern  void setVertexOffset_x64(Ptr64 model, double x, double y, double z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="setting">Size: 64 bit / 8 byte (value). ...</param>
        /// <param name="mask">Size: 64 bit / 8 byte (value). ...</param>
        [DllImport(Path_x64, EntryPoint = "setFilter")]
        internal static extern  void setFilter_x64(Ptr64 model, Ptr64 setting, Ptr64 mask);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Size: 64 bit / 8 byte (value). Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="setting">Size: 64 bit / 8 byte (value). ...</param>
        /// <param name="mask">Size: 64 bit / 8 byte (value). ...</param>
        [DllImport(Path_x64, EntryPoint = "setFormat")]
        internal static extern  void setFormat_x64(Ptr64 model, Ptr64 setting, Ptr64 mask);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "getConceptualFaceCnt")]

        internal static extern  Ptr64 getConceptualFaceCnt_x64(Ptr64 instance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Size: 64 bit / 8 byte (value). Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="index">Size: 64 bit / 8 byte (value). Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <param name="startIndexTriangles">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="noIndicesTriangles">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="startIndexLines">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="noIndicesLines">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="startIndexPoints">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="noIndicesPoints">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="startIndexFacesPolygons">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="noIndicesFacesPolygons">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="startIndexConceptualFacePolygons">Size: 64 bit / 8 byte (reference). ...</param>
        /// <param name="noIndicesConceptualFacePolygons">Size: 64 bit / 8 byte (reference). ...</param>
        /// <returns></returns>
        [DllImport(Path_x64, EntryPoint = "getConceptualFaceEx")]
        internal static extern  Ptr64 getConceptualFaceEx_x64(Ptr64 instance, Ptr64 index, ref Ptr64 startIndexTriangles, ref Ptr64 noIndicesTriangles, ref Ptr64 startIndexLines, ref Ptr64 noIndicesLines, ref Ptr64 startIndexPoints, ref Ptr64 noIndicesPoints, ref Ptr64 startIndexFacesPolygons, ref Ptr64 noIndicesFacesPolygons, ref Ptr64 startIndexConceptualFacePolygons, ref Ptr64 noIndicesConceptualFacePolygons);
        #endregion
    }

}
