/* ***********************************************
 * author :  LinJiarui
 * email  :  lin@bimer.cn
 * file   :  IfcEngine
 * history:  created by LinJiarui at 2015/8/7 17:00:54
 *           modified by
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IfcEngineCS
{
    public partial class IfcEngine
    {
        public IfcEngine()
        {
            if (Environment.Is64BitProcess) {
                #region File IO
                _sdaiCloseModel = sdaiCloseModel_x64;
                _sdaiCreateModelBn = sdaiCreateModelBN_x64;
                _sdaiCreateModelBn_byte = sdaiCreateModelBN_x64;
                _sdaiCreateModelBn_unicode = sdaiCreateModelBNUnicode_x64;
                _sdaiOpenModelBn = sdaiOpenModelBN_x64;
                _sdaiOpenModelBn_byte = sdaiOpenModelBN_x64;
                _sdaiOpenModelBn_unicode = sdaiOpenModelBNUnicode_x64;
                _sdaiSaveModelBn = sdaiSaveModelBN_x64;
                _sdaiSaveModelBn_byte = sdaiSaveModelBN_x64;
                _sdaiSaveModelBn_unicode = sdaiSaveModelBNUnicode_x64;
                _sdaiSaveModelAsXmlBn = sdaiSaveModelAsXmlBN_x64;
                _sdaiSaveModelAsXmlBn_byte = sdaiSaveModelAsXmlBN_x64;
                _sdaiSaveModelAsXmlBn_unicode = sdaiSaveModelAsXmlBNUnicode_x64;
                _sdaiSaveModelAsSimpleXmlBn = sdaiSaveModelAsXmlBN_x64;
                _sdaiSaveModelAsSimpleXmlBn_byte = sdaiSaveModelAsXmlBN_x64;
                _sdaiSaveModelAsSimpleXmlBn_unicode = sdaiSaveModelAsXmlBNUnicode_x64;
                #endregion

                #region Schema Reading
                _sdaiGetEntity = sdaiGetEntity_x64;
                _sdaiGetEntity_byte = sdaiGetEntity_x64;
                _engiGetEntityName = engiGetEntityName_x64;
                _engiGetEntityArgumentName = engiGetEntityArgumentName_x64;
                _engiGetEntityArgumentType = engiGetEntityArgumentType_x64;
                _engiGetEntityCount = engiGetEntityCount_x64;
                _engiGetEntityElement = engiGetEntityElement_x64;
                _sdaiGetEntityExtent = sdaiGetEntityExtent_x64;
                _sdaiGetEntityExtentBn = sdaiGetEntityExtentBN_x64;
                _sdaiGetEntityExtentBn_byte = sdaiGetEntityExtentBN_x64;
                _engiGetEntityNoArguments = engiGetEntityNoArguments_x64;
                _engiGetEntityParent = engiGetEntityParent_x64;
                #endregion

                #region Instance Header
                _getSpffHeaderItem = GetSPFFHeaderItem_x64;
                _setSpffHeader = SetSPFFHeader_x64;
                _setSpffHeader_byte = SetSPFFHeader_x64;
                _setSpffHeaderItem = SetSPFFHeaderItem_x64;
                _setSpffHeaderItem_byte = SetSPFFHeaderItem_x64;
                #endregion

                #region Instance Reading
                _sdaiGetAdbType = sdaiGetADBType_x64;
                _sdaiGetAdbTypePath = sdaiGetADBTypePath_x64;
                _sdaiGetAdbValue = sdaiGetADBValue_x64;
                _sdaiGetAdbValue_d = sdaiGetADBValue_x64;
                _engiGetAggrElement = engiGetAggrElement_x64;
                _engiGetAggrElement_d = engiGetAggrElement_x64;
                _engiGetAggrType = engiGetAggrType_x64;
                _sdaiGetAttr = sdaiGetAttr_x64;
                _sdaiGetAttrBn = sdaiGetAttrBN_x64;
                _sdaiGetAttrBn_byte = sdaiGetAttrBN_x64;
                _sdaiGetAttr_d = sdaiGetAttr_x64;
                _sdaiGetAttrBn_d = sdaiGetAttrBN_x64;
                _sdaiGetAttrBn_byte_d = sdaiGetAttrBN_x64;
                _sdaiGetAttrDefinition = sdaiGetAttrDefinition_x64;
                _sdaiGetAttrDefinition_byte = sdaiGetAttrDefinition_x64;
                _sdaiGetInstanceType = sdaiGetInstanceType_x64;
                _sdaiGetMemberCount = sdaiGetMemberCount_x64;
                _sdaiIsKindOf = sdaiIsKindOf_x64;
                #endregion

                #region Instance Writing
                _sdaiAppend = sdaiAppend_x64;
                _sdaiAppend_d = sdaiAppend_x64;
                _sdaiAppend_s = sdaiAppend_x64;
                _sdaiAppend_b = sdaiAppend_x64;
                _sdaiCreateAdb = sdaiCreateADB_x64;
                _sdaiCreateAdb_d = sdaiCreateADB_x64;
                _sdaiCreateAdb_s = sdaiCreateADB_x64;
                _sdaiCreateAdb_b = sdaiCreateADB_x64;
                _sdaiCreateAggr = sdaiCreateAggr_x64;
                _sdaiCreateAggrBn = sdaiCreateAggrBN_x64;
                _sdaiCreateAggrBn_byte = sdaiCreateAggrBN_x64;
                _sdaiCreateInstance = sdaiCreateInstance_x64;
                _sdaiCreateInstanceBn = sdaiCreateInstanceBN_x64;
                _sdaiCreateInstanceBn_byte = sdaiCreateInstanceBN_x64;
                _sdaiDeleteInstance = sdaiDeleteInstance_x64;
                _sdaiPutAdbTypePath = sdaiPutADBTypePath_x64;
                _sdaiPutAdbTypePath_byte = sdaiPutADBTypePath_x64;
                _sdaiPutAttr = sdaiPutAttr_x64;
                _sdaiPutAttr_d = sdaiPutAttr_x64;
                _sdaiPutAttr_s = sdaiPutAttr_x64;
                _sdaiPutAttr_b = sdaiPutAttr_x64;
                _sdaiPutAttrBN = sdaiPutAttrBN_x64;
                _sdaiPutAttrBN_d = sdaiPutAttrBN_x64;
                _sdaiPutAttrBN_s = sdaiPutAttrBN_x64;
                _sdaiPutAttrBN_b = sdaiPutAttrBN_x64;
                _sdaiPutAttrBN_byte = sdaiPutAttrBN_x64;
                _sdaiPutAttrBN_byte_d = sdaiPutAttrBN_x64;
                _sdaiPutAttrBN_byte_s = sdaiPutAttrBN_x64;
                _sdaiPutAttrBN_byte_b = sdaiPutAttrBN_x64;
                _engiSetComment = engiSetComment_x64;
                _engiSetComment_byte = engiSetComment_x64;
                #endregion

                #region Controling Calls
                _circleSegments = circleSegments_x64;
                _cleanMemory = cleanMemory_x64;
                _internalGetP21Line = internalGetP21Line_x64;
                _internalGetInstanceFromP21Line = internalGetInstanceFromP21Line_x64;
                _setStringUnicode = setStringUnicode_x64;
                #endregion

                #region Geometry Interaction
                _initializeModellingInstance = initializeModellingInstance_x64;
                _finalizeModelling = finalizeModelling_x64;
                _finalizeModelling_64 = finalizeModelling_x64;
                _finalizeModelling_d = finalizeModelling_x64;
                _finalizeModelling_d64 = finalizeModelling_x64;
                _getInstanceInModelling = getInstanceInModelling_x64;
                _setVertexOffset = setVertexOffset_x64;
                _setFilter = setFilter_x64;
                _setFormat = setFormat_x64;
                _getConceptualFaceCnt = getConceptualFaceCnt_x64;
                _getConceptualFaceEx = getConceptualFaceEx_x64;
                #endregion
            } else {
                #region File IO
                _sdaiCloseModel = sdaiCloseModel_x32;
                _sdaiCreateModelBn = sdaiCreateModelBN_x32;
                _sdaiCreateModelBn_byte = sdaiCreateModelBN_x32;
                _sdaiCreateModelBn_unicode = sdaiCreateModelBNUnicode_x32;
                _sdaiOpenModelBn = sdaiOpenModelBN_x32;
                _sdaiOpenModelBn_byte = sdaiOpenModelBN_x32;
                _sdaiOpenModelBn_unicode = sdaiOpenModelBNUnicode_x32;
                _sdaiSaveModelBn = sdaiSaveModelBN_x32;
                _sdaiSaveModelBn_byte = sdaiSaveModelBN_x32;
                _sdaiSaveModelBn_unicode = sdaiSaveModelBNUnicode_x32;
                _sdaiSaveModelAsXmlBn = sdaiSaveModelAsXmlBN_x32;
                _sdaiSaveModelAsXmlBn_byte = sdaiSaveModelAsXmlBN_x32;
                _sdaiSaveModelAsXmlBn_unicode = sdaiSaveModelAsXmlBNUnicode_x32;
                _sdaiSaveModelAsSimpleXmlBn = sdaiSaveModelAsXmlBN_x32;
                _sdaiSaveModelAsSimpleXmlBn_byte = sdaiSaveModelAsXmlBN_x32;
                _sdaiSaveModelAsSimpleXmlBn_unicode = sdaiSaveModelAsXmlBNUnicode_x32;
                #endregion

                #region Schema Reading
                _sdaiGetEntity = sdaiGetEntity_x32;
                _sdaiGetEntity_byte = sdaiGetEntity_x32;
                _engiGetEntityName = engiGetEntityName_x32;
                _engiGetEntityArgumentName = engiGetEntityArgumentName_x32;
                _engiGetEntityArgumentType = engiGetEntityArgumentType_x32;
                _engiGetEntityCount = engiGetEntityCount_x32;
                _engiGetEntityElement = engiGetEntityElement_x32;
                _sdaiGetEntityExtent = sdaiGetEntityExtent_x32;
                _sdaiGetEntityExtentBn = sdaiGetEntityExtentBN_x32;
                _sdaiGetEntityExtentBn_byte = sdaiGetEntityExtentBN_x32;
                _engiGetEntityNoArguments = engiGetEntityNoArguments_x32;
                _engiGetEntityParent = engiGetEntityParent_x32;
                #endregion

                #region Instance Header
                _getSpffHeaderItem = GetSPFFHeaderItem_x32;
                _setSpffHeader = SetSPFFHeader_x32;
                _setSpffHeader_byte = SetSPFFHeader_x32;
                _setSpffHeaderItem = SetSPFFHeaderItem_x32;
                _setSpffHeaderItem_byte = SetSPFFHeaderItem_x32;
                #endregion

                #region Instance Reading
                _sdaiGetAdbType = sdaiGetADBType_x32;
                _sdaiGetAdbTypePath = sdaiGetADBTypePath_x32;
                _sdaiGetAdbValue = sdaiGetADBValue_x32;
                _sdaiGetAdbValue_d = sdaiGetADBValue_x32;
                _engiGetAggrElement = engiGetAggrElement_x32;
                _engiGetAggrElement_d = engiGetAggrElement_x32;
                _engiGetAggrType = engiGetAggrType_x32;
                _sdaiGetAttr = sdaiGetAttr_x32;
                _sdaiGetAttrBn = sdaiGetAttrBN_x32;
                _sdaiGetAttrBn_byte = sdaiGetAttrBN_x32;
                _sdaiGetAttr_d = sdaiGetAttr_x32;
                _sdaiGetAttrBn_d = sdaiGetAttrBN_x32;
                _sdaiGetAttrBn_byte_d = sdaiGetAttrBN_x32;
                _sdaiGetAttrDefinition = sdaiGetAttrDefinition_x32;
                _sdaiGetAttrDefinition_byte = sdaiGetAttrDefinition_x32;
                _sdaiGetInstanceType = sdaiGetInstanceType_x32;
                _sdaiGetMemberCount = sdaiGetMemberCount_x32;
                _sdaiIsKindOf = sdaiIsKindOf_x32;
                #endregion

                #region Instance Writing
                _sdaiAppend = sdaiAppend_x32;
                _sdaiAppend_d = sdaiAppend_x32;
                _sdaiAppend_s = sdaiAppend_x32;
                _sdaiAppend_b = sdaiAppend_x32;
                _sdaiCreateAdb = sdaiCreateADB_x32;
                _sdaiCreateAdb_d = sdaiCreateADB_x32;
                _sdaiCreateAdb_s = sdaiCreateADB_x32;
                _sdaiCreateAdb_b = sdaiCreateADB_x32;
                _sdaiCreateAggr = sdaiCreateAggr_x32;
                _sdaiCreateAggrBn = sdaiCreateAggrBN_x32;
                _sdaiCreateAggrBn_byte = sdaiCreateAggrBN_x32;
                _sdaiCreateInstance = sdaiCreateInstance_x32;
                _sdaiCreateInstanceBn = sdaiCreateInstanceBN_x32;
                _sdaiCreateInstanceBn_byte = sdaiCreateInstanceBN_x32;
                _sdaiDeleteInstance = sdaiDeleteInstance_x32;
                _sdaiPutAdbTypePath = sdaiPutADBTypePath_x32;
                _sdaiPutAdbTypePath_byte = sdaiPutADBTypePath_x32;
                _sdaiPutAttr = sdaiPutAttr_x32;
                _sdaiPutAttr_d = sdaiPutAttr_x32;
                _sdaiPutAttr_s = sdaiPutAttr_x32;
                _sdaiPutAttr_b = sdaiPutAttr_x32;
                _sdaiPutAttrBN = sdaiPutAttrBN_x32;
                _sdaiPutAttrBN_d = sdaiPutAttrBN_x32;
                _sdaiPutAttrBN_s = sdaiPutAttrBN_x32;
                _sdaiPutAttrBN_b = sdaiPutAttrBN_x32;
                _sdaiPutAttrBN_byte = sdaiPutAttrBN_x32;
                _sdaiPutAttrBN_byte_d = sdaiPutAttrBN_x32;
                _sdaiPutAttrBN_byte_s = sdaiPutAttrBN_x32;
                _sdaiPutAttrBN_byte_b = sdaiPutAttrBN_x32;
                _engiSetComment = engiSetComment_x32;
                _engiSetComment_byte = engiSetComment_x32;
                #endregion

                #region Controling Calls
                _circleSegments = circleSegments_x32;
                _cleanMemory = cleanMemory_x32;
                _internalGetP21Line = internalGetP21Line_x32;
                _internalGetInstanceFromP21Line = internalGetInstanceFromP21Line_x32;
                _setStringUnicode = setStringUnicode_x32;
                #endregion

                #region Geometry Interaction
                _initializeModellingInstance = initializeModellingInstance_x32;
                _finalizeModelling = finalizeModelling_x32;
                _finalizeModelling_64 = finalizeModelling_x32;
                _finalizeModelling_d = finalizeModelling_x32;
                _finalizeModelling_d64 = finalizeModelling_x32;
                _getInstanceInModelling = getInstanceInModelling_x32;
                _setVertexOffset = setVertexOffset_x32;
                _setFilter = setFilter_x32;
                _setFormat = setFormat_x32;
                _getConceptualFaceCnt = getConceptualFaceCnt_x32;
                _getConceptualFaceEx = getConceptualFaceEx_x32;
                #endregion
            }
        }

        static Encoding unicode = Encoding.Unicode;
        #region File IO
        private Delegates.sdaiCloseModel _sdaiCloseModel;
        private Delegates.sdaiCreateModelBN _sdaiCreateModelBn;
        private Delegates.sdaiCreateModelBN_byte _sdaiCreateModelBn_byte;
        private Delegates.sdaiCreateModelBNUnicode _sdaiCreateModelBn_unicode;
        private Delegates.sdaiOpenModelBN _sdaiOpenModelBn;
        private Delegates.sdaiOpenModelBN_byte _sdaiOpenModelBn_byte;
        private Delegates.sdaiOpenModelBNUnicode _sdaiOpenModelBn_unicode;
        private Delegates.sdaiSaveModelBN _sdaiSaveModelBn;
        private Delegates.sdaiSaveModelBN_byte _sdaiSaveModelBn_byte;
        private Delegates.sdaiSaveModelBNUnicode _sdaiSaveModelBn_unicode;
        private Delegates.sdaiSaveModelAsXmlBN _sdaiSaveModelAsXmlBn;
        private Delegates.sdaiSaveModelAsXmlBN_byte _sdaiSaveModelAsXmlBn_byte;
        private Delegates.sdaiSaveModelAsXmlBNUnicode _sdaiSaveModelAsXmlBn_unicode;
        private Delegates.sdaiSaveModelAsSimpleXmlBN _sdaiSaveModelAsSimpleXmlBn;
        private Delegates.sdaiSaveModelAsSimpleXmlBN_byte _sdaiSaveModelAsSimpleXmlBn_byte;
        private Delegates.sdaiSaveModelAsSimpleXmlBNUnicode _sdaiSaveModelAsSimpleXmlBn_unicode;

        /// <summary>
        /// This call can be used to close a model. Be aware that closing a model will release all memory allocated for this model, handles and strings allocated in the context of this model cannot be trusted anymore after this call.
        /// </summary>
        /// <param name="model"></param>
        public void CloseModel(IntPtr model)
        {
            if (_sdaiCloseModel == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            _sdaiCloseModel.Invoke(model);
        }

        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        [Obsolete("Use carefully, cause it does not support file name with wide chars.")]
        public IntPtr CreateModel(IntPtr repository, string fileName, string schemaName)
        {
            if (_sdaiCreateModelBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiCreateModelBn.Invoke(repository, fileName, schemaName);
        }

        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr CreateModel(IntPtr repository, byte[] fileName, byte[] schemaName)
        {
            if (_sdaiCreateModelBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiCreateModelBn_byte.Invoke(repository, fileName, schemaName);
        }

        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        public IntPtr CreateModelUnicode(IntPtr repository, string fileName, string schemaName)
        {
            if (_sdaiCreateModelBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiCreateModelBn_unicode.Invoke(repository, unicode.GetBytes(fileName), unicode.GetBytes(schemaName));
        }

        /// <summary>
        /// This call can be used to create an empty model. Every model needs to be opened against a schema, the schema needs to be existing. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr CreateModelUnicode(IntPtr repository, byte[] fileName, byte[] schemaName)
        {
            if (_sdaiCreateModelBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiCreateModelBn_unicode.Invoke(repository, fileName, schemaName);
        }

        /// <summary>
        /// This call is used to open a model with normal ASCII character namings. The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        [Obsolete("Use carefully, cause it does not support file name with wide chars.")]
        public IntPtr OpenModel(IntPtr repository, string fileName, string schemaName)
        {
            if (_sdaiOpenModelBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiOpenModelBn.Invoke(repository, fileName, schemaName);
        }

        /// <summary>
        /// This call is used to open a model with normal ASCII character namings. The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr OpenModel(IntPtr repository, byte[] fileName, byte[] schemaName)
        {
            if (_sdaiOpenModelBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiOpenModelBn_byte.Invoke(repository, fileName, schemaName);
        }

        /// <summary>
        /// This call is used to open a model with Unicode character namings (technically via wchar_t, different lengths (16 bit and 32 bit) on different systems are supported). The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        public IntPtr OpenModelUnicode(IntPtr repository, string fileName, string schemaName)
        {
            if (_sdaiOpenModelBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiOpenModelBn_unicode.Invoke(repository, unicode.GetBytes(fileName), unicode.GetBytes(schemaName));
        }

        /// <summary>
        /// This call is used to open a model with Unicode character namings (technically via wchar_t, different lengths (16 bit and 32 bit) on different systems are supported). The property repository is expected to be 0 in all cases, however will be ignored. The property fileName is optional and can be 0 or an empty string, i.e. ""; in both cases an empty model against the defined schema is created. The property schemaName is non optional and has to link to an existing valid schema.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="fileName"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr OpenModelUnicode(IntPtr repository, byte[] fileName, byte[] schemaName)
        {
            if (_sdaiOpenModelBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiOpenModelBn_unicode.Invoke(repository, fileName, schemaName);
        }

        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Use carefully, cause it does not support file name with wide chars.")]
        public void SaveModel(IntPtr model, string fileName)
        {
            if (_sdaiSaveModelBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            _sdaiSaveModelBn.Invoke(model, fileName);
        }

        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Will be removed in next version.")]
        public void SaveModel(IntPtr model, byte[] fileName)
        {
            if (_sdaiSaveModelBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            _sdaiSaveModelBn_byte.Invoke(model, fileName);
        }

        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public void SaveModelUnicode(IntPtr model, string fileName)
        {
            if (_sdaiSaveModelBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiSaveModelBn_unicode.Invoke(model, unicode.GetBytes(fileName));
        }

        /// <summary>
        /// This call can be used to save a model in SPF Format (Step Physical File Format), this is currently still the default format for IFC files. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Will be removed in next version.")]
        public void SaveModelUnicode(IntPtr model, byte[] fileName)
        {
            if (_sdaiSaveModelBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiSaveModelBn_unicode.Invoke(model, fileName);
        }

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Use carefully, cause it does not support file name with wide chars.")]
        public void SaveModelAsXml(IntPtr model, string fileName)
        {
            if (_sdaiSaveModelAsXmlBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            _sdaiSaveModelAsXmlBn.Invoke(model, fileName);
        }

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Will be removed in next version.")]
        public void SaveModelAsXml(IntPtr model, byte[] fileName)
        {
            if (_sdaiSaveModelAsXmlBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            _sdaiSaveModelAsXmlBn_byte.Invoke(model, fileName);
        }

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public void SaveModelAsXmlUnicode(IntPtr model, string fileName)
        {
            if (_sdaiSaveModelAsXmlBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiSaveModelAsXmlBn_unicode.Invoke(model, unicode.GetBytes(fileName));
        }

        /// <summary>
        /// This call can be used to save a model in XML Format, this XML serialization is advised for ifcXML files of schema IFC2x3 TC1 and before. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Will be removed in next version.")]
        public void SaveModelAsXmlUnicode(IntPtr model, byte[] fileName)
        {
            if (_sdaiSaveModelAsXmlBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiSaveModelAsXmlBn_unicode.Invoke(model, fileName);
        }
        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Use carefully, cause it does not support file name with wide chars.")]
        public void SaveModelAsSimpleXml(IntPtr model, string fileName)
        {
            if (_sdaiSaveModelAsSimpleXmlBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            _sdaiSaveModelAsSimpleXmlBn.Invoke(model, fileName);
        }

        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any ASCII filename with a character length of 8 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Will be removed in next version.")]
        public void SaveModelAsSimpleXml(IntPtr model, byte[] fileName)
        {
            if (_sdaiSaveModelAsSimpleXmlBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            _sdaiSaveModelAsSimpleXmlBn_byte.Invoke(model, fileName);
        }

        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public void SaveModelAsSimpleXmlUnicode(IntPtr model, string fileName)
        {
            if (_sdaiSaveModelAsSimpleXmlBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiSaveModelAsSimpleXmlBn_unicode.Invoke(model, unicode.GetBytes(fileName));
        }

        /// <summary>
        /// This call can be used to save a model in simple XML Format, this XML serialization is advised for ifcXML files of schema IFC4 and later. The file name can be any unicode filename with a character length of 16 bits.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        [Obsolete("Will be removed in next version.")]
        public void SaveModelAsSimpleXmlUnicode(IntPtr model, byte[] fileName)
        {
            if (_sdaiSaveModelAsSimpleXmlBn_unicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiSaveModelAsSimpleXmlBn_unicode.Invoke(model, fileName);
        }

        #endregion

        #region Schema Reading

        private Delegates.sdaiGetEntity _sdaiGetEntity;
        private Delegates.sdaiGetEntity_byte _sdaiGetEntity_byte;
        private Delegates.engiGetEntityName _engiGetEntityName;
        private Delegates.engiGetEntityArgumentName _engiGetEntityArgumentName;
        private Delegates.engiGetEntityArgumentType _engiGetEntityArgumentType;
        private Delegates.engiGetEntityCount _engiGetEntityCount;
        private Delegates.engiGetEntityElement _engiGetEntityElement;
        private Delegates.sdaiGetEntityExtent _sdaiGetEntityExtent;
        private Delegates.sdaiGetEntityExtentBN _sdaiGetEntityExtentBn;
        private Delegates.sdaiGetEntityExtentBN_byte _sdaiGetEntityExtentBn_byte;
        private Delegates.engiGetEntityNoArguments _engiGetEntityNoArguments;
        private Delegates.engiGetEntityParent _engiGetEntityParent;

        /// <summary>
        /// This call retrieves a handle to an entity based on a given entity name.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public IntPtr GetEntity(IntPtr model, string entityName)
        {
            if (_sdaiGetEntity == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiGetEntity.Invoke(model, entityName);
        }

        /// <summary>
        /// This call retrieves a handle to an entity based on a given entity name.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr GetEntity(IntPtr model, byte[] entityName)
        {
            if (_sdaiGetEntity_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }

            return _sdaiGetEntity_byte.Invoke(model, entityName);
        }

        /// <summary>
        /// This call can be used to retrieve the name of the n-th argument of the given entity. Arguments of parent entities are included in the index. Both direct and inverse arguments are included.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        /// <param name="valueType"></param>
        /// <param name="argumentName"></param>
        public void GetEntityArgumentName(IntPtr entity, int index, SdaiType valueType, out IntPtr argumentName)
        {
            if (_engiGetEntityArgumentName == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _engiGetEntityArgumentName.Invoke(entity, new IntPtr(index), new IntPtr((int)valueType), out argumentName);
        }

        /// <summary>
        /// This call can be used to retrieve the type of the n-th argument of the given entity. In case of a select argument no relevant information is given by this call as it depends on the instance. Arguments of parent entities are included in the index. Both direct and inverse arguments are included.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        /// <param name="argumentType"></param>
        public void GetEntityArgumentType(IntPtr entity, int index, ref SdaiType argumentType)
        {
            if (_engiGetEntityArgumentType == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            var aType = IntPtr.Zero;
            _engiGetEntityArgumentType.Invoke(entity, new IntPtr(index), ref aType);
            argumentType = (SdaiType)aType.ToInt32();
        }
        public IntPtr GetEntityCount(IntPtr model)
        {
            if (_engiGetEntityCount == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _engiGetEntityCount.Invoke(model);
        }

        /// <summary>
        /// This call returns a specific entity based on an index, the index needs to be 0 or higher but lower then the number of entities in the loaded schema.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public IntPtr GetEntityElement(IntPtr model, int index)
        {
            if (_engiGetEntityElement == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _engiGetEntityElement.Invoke(model, new IntPtr(index));
        }

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IntPtr GetEntityExtent(IntPtr model, IntPtr entity)
        {
            if (_sdaiGetEntityExtent == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetEntityExtent.Invoke(model, entity);
        }

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public IntPtr GetEntityExtent(IntPtr model, string entityName)
        {
            if (_sdaiGetEntityExtentBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetEntityExtentBn.Invoke(model, entityName);
        }

        /// <summary>
        /// This call retrieves an aggregation that contains all instances of the entity given.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr GetEntityExtent(IntPtr model, byte[] entityName)
        {
            if (_sdaiGetEntityExtentBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetEntityExtentBn_byte.Invoke(model, entityName);
        }

        /// <summary>
        /// This call can be used to get the name of the given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="valueType"></param>
        /// <param name="entityName"></param>
        public void GetEntityName(IntPtr entity, SdaiType valueType, out IntPtr entityName)
        {
            if (_engiGetEntityName == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _engiGetEntityName.Invoke(entity, new IntPtr((int)valueType), out entityName);
        }

        /// <summary>
        /// This call returns the number of arguments, this includes the arguments of its (nested) parents and inverse argumnets.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IntPtr GetEntityNoArguments(IntPtr entity)
        {
            if (_engiGetEntityNoArguments == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _engiGetEntityNoArguments.Invoke(entity);
        }

        /// <summary>
        /// Returns the direct parent entity, for example the parent of IfcObject is IfcObjectDefinition, of IfcObjectDefinition is IfcRoot and of IfcRoot is 0.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IntPtr GetEntityParent(IntPtr entity)
        {
            if (_engiGetEntityParent == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _engiGetEntityParent.Invoke(entity);
        }
        #endregion

        #region Instance Header

        private Delegates.GetSPFFHeaderItem _getSpffHeaderItem;
        private Delegates.SetSPFFHeader _setSpffHeader;
        private Delegates.SetSPFFHeader_byte _setSpffHeader_byte;
        private Delegates.SetSPFFHeaderItem _setSpffHeaderItem;
        private Delegates.SetSPFFHeaderItem_byte _setSpffHeaderItem_byte;

        public IntPtr GetSPFFHeaderItem(IntPtr model, int itemIndex, int itemSubIndex, SdaiType valueType, out IntPtr value)
        {
            if (_getSpffHeaderItem == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _getSpffHeaderItem.Invoke(model, new IntPtr(itemIndex), new IntPtr(itemSubIndex), new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// This call is an aggregate of several SetSPFFHeaderItem calls. In several cases the header can be set easily with this call. In case an argument is zero, this argument will not be updated, i.e. it will not be filled with 0.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="description"></param>
        /// <param name="implementationLevel"></param>
        /// <param name="name"></param>
        /// <param name="timeStamp"></param>
        /// <param name="author"></param>
        /// <param name="organization"></param>
        /// <param name="preprocessorVersion"></param>
        /// <param name="originatingSystem"></param>
        /// <param name="authorization"></param>
        /// <param name="fileSchema"></param>
        public void SetSPFFHeader(IntPtr model, string description, string implementationLevel, string name,
            string timeStamp, string author, string organization, string preprocessorVersion, string originatingSystem,
            string authorization, string fileSchema)
        {
            if (_setSpffHeader == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _setSpffHeader.Invoke(model, description, implementationLevel, name,
                timeStamp, author, organization, preprocessorVersion, originatingSystem,
                authorization, fileSchema);
        }

        /// <summary>
        /// This call is an aggregate of several SetSPFFHeaderItem calls. In several cases the header can be set easily with this call. In case an argument is zero, this argument will not be updated, i.e. it will not be filled with 0.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="description"></param>
        /// <param name="implementationLevel"></param>
        /// <param name="name"></param>
        /// <param name="timeStamp"></param>
        /// <param name="author"></param>
        /// <param name="organization"></param>
        /// <param name="preprocessorVersion"></param>
        /// <param name="originatingSystem"></param>
        /// <param name="authorization"></param>
        /// <param name="fileSchema"></param>
        [Obsolete("Will be removed in next version.")]
        public void SetSPFFHeader(IntPtr model, byte[] description, byte[] implementationLevel, byte[] name,
            byte[] timeStamp, byte[] author, byte[] organization, byte[] preprocessorVersion, byte[] originatingSystem,
            byte[] authorization, byte[] fileSchema)
        {
            if (_setSpffHeader_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _setSpffHeader_byte.Invoke(model, description, implementationLevel, name,
                timeStamp, author, organization, preprocessorVersion, originatingSystem,
                authorization, fileSchema);
        }

        public IntPtr SetSPFFHeaderItem(IntPtr model, int itemIndex, int itemSubIndex, SdaiType valueType, string value)
        {
            if (_setSpffHeaderItem == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _setSpffHeaderItem.Invoke(model, new IntPtr(itemIndex), new IntPtr(itemSubIndex), new IntPtr((int)valueType), value);
        }

        [Obsolete("Will be removed in next version.")]
        public IntPtr SetSPFFHeaderItem(IntPtr model, int itemIndex, int itemSubIndex, SdaiType valueType, byte[] value)
        {
            if (_setSpffHeaderItem_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _setSpffHeaderItem_byte.Invoke(model, new IntPtr(itemIndex), new IntPtr(itemSubIndex), new IntPtr((int)valueType), value);
        }
        #endregion

        #region Instance Reading

        private Delegates.sdaiGetADBType _sdaiGetAdbType;
        private Delegates.sdaiGetADBTypePath _sdaiGetAdbTypePath;
        private Delegates.sdaiGetADBValue _sdaiGetAdbValue;
        private Delegates.sdaiGetADBValue_d _sdaiGetAdbValue_d;
        private Delegates.engiGetAggrElement _engiGetAggrElement;
        private Delegates.engiGetAggrElement_d _engiGetAggrElement_d;
        private Delegates.engiGetAggrType _engiGetAggrType;
        private Delegates.sdaiGetAttr _sdaiGetAttr;
        private Delegates.sdaiGetAttrBN _sdaiGetAttrBn;
        private Delegates.sdaiGetAttrBN_byte _sdaiGetAttrBn_byte;
        private Delegates.sdaiGetAttr_d _sdaiGetAttr_d;
        private Delegates.sdaiGetAttrBN_d _sdaiGetAttrBn_d;
        private Delegates.sdaiGetAttrBN_byte_d _sdaiGetAttrBn_byte_d;
        private Delegates.sdaiGetAttrDefinition _sdaiGetAttrDefinition;
        private Delegates.sdaiGetAttrDefinition_byte _sdaiGetAttrDefinition_byte;
        private Delegates.sdaiGetInstanceType _sdaiGetInstanceType;
        private Delegates.sdaiGetMemberCount _sdaiGetMemberCount;
        private Delegates.sdaiIsKindOf _sdaiIsKindOf;

        /// <summary>
        /// Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).
        /// </summary>
        /// <param name="ADB"></param>
        /// <returns></returns>
        public IntPtr GetADBType(IntPtr ADB)
        {
            if (_sdaiGetAdbType == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAdbType.Invoke(ADB);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="typeNameNumber">Enables the user to define the output, typical use is sdaiSTRING, sdaiUNICODE or sdaiEXPRESSSTRING.</param>
        /// <param name="path"></param>
        public void GetADBTypePath(IntPtr ADB, IntPtr typeNameNumber, out IntPtr path)
        {
            if (_sdaiGetAdbTypePath == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiGetAdbTypePath.Invoke(ADB, typeNameNumber, out path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void GetADBValue(IntPtr ADB, SdaiType valueType, out IntPtr value)
        {
            if (_sdaiGetAdbValue == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiGetAdbValue.Invoke(ADB, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void GetADBValue(IntPtr ADB, SdaiType valueType, out double value)
        {
            if (_sdaiGetAdbValue_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiGetAdbValue_d.Invoke(ADB, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="elementIndex">Integer value equal or larger then 0 and smaller than given maximum length of list of elements used.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        public IntPtr GetAggregationElement(IntPtr aggregate, int elementIndex, SdaiType valueType,
            out IntPtr value)
        {
            if (_engiGetAggrElement == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _engiGetAggrElement.Invoke(aggregate, new IntPtr(elementIndex), new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="elementIndex">Integer value equal or larger then 0 and smaller than given maximum length of list of elements used.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        public IntPtr GetAggregationElement(IntPtr aggregate, int elementIndex, SdaiType valueType,
            out double value)
        {
            if (_engiGetAggrElement_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _engiGetAggrElement_d.Invoke(aggregate, new IntPtr(elementIndex), new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Handle of an aggregation (i.e. sorted collection).</param>
        /// <param name="aggragateType">Type of the aggregation, for example sdaiINSTANCE, sdaiREAL, ...</param>
        public void GetAggregationType(IntPtr aggregate, ref SdaiType aggragateType)
        {
            if (_engiGetAggrType == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            var aType = IntPtr.Zero;
            _engiGetAggrType.Invoke(aggregate, ref aType);
            aggragateType = (SdaiType)aType.ToInt32();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        public IntPtr GetAttribute(IntPtr instance, IntPtr attribute, SdaiType valueType, out IntPtr value)
        {
            if (_sdaiGetAttr == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttr.Invoke(instance, attribute, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        public IntPtr GetAttribute(IntPtr instance, IntPtr attribute, SdaiType valueType, out double value)
        {
            if (_sdaiGetAttr_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttr_d.Invoke(instance, attribute, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        public IntPtr GetAttribute(IntPtr instance, string attributeName, SdaiType valueType, out IntPtr value)
        {
            if (_sdaiGetAttrBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttrBn.Invoke(instance, attributeName, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        public IntPtr GetAttribute(IntPtr instance, string attributeName, SdaiType valueType, out double value)
        {
            if (_sdaiGetAttrBn_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttrBn_d.Invoke(instance, attributeName, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr GetAttribute(IntPtr instance, byte[] attributeName, SdaiType valueType,
            out IntPtr value)
        {
            if (_sdaiGetAttrBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttrBn_byte.Invoke(instance, attributeName, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr GetAttribute(IntPtr instance, byte[] attributeName, SdaiType valueType,
            out double value)
        {
            if (_sdaiGetAttrBn_byte_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttrBn_byte_d.Invoke(instance, attributeName, new IntPtr((int)valueType), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        public IntPtr GetAttributeDefinition(IntPtr entity, string attributeName)
        {
            if (_sdaiGetAttrDefinition == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttrDefinition.Invoke(entity, attributeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr GetAttributeDefinition(IntPtr entity, byte[] attributeName)
        {
            if (_sdaiGetAttrDefinition_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetAttrDefinition_byte.Invoke(entity, attributeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        public IntPtr GetInstanceType(IntPtr instance)
        {
            if (_sdaiGetInstanceType == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetInstanceType.Invoke(instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregate">Handle of an aggregation (i.e. sorted collection).</param>
        /// <returns></returns>
        public IntPtr GetMemberCount(IntPtr aggregate)
        {
            if (_sdaiGetMemberCount == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiGetMemberCount.Invoke(aggregate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="entity">Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        public IntPtr IsKindOf(IntPtr instance, IntPtr entity)
        {
            if (_sdaiIsKindOf == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiIsKindOf.Invoke(instance, entity);
        }
        #endregion

        #region Instance Wrting

        private Delegates.sdaiAppend _sdaiAppend;
        private Delegates.sdaiAppend_d _sdaiAppend_d;
        private Delegates.sdaiAppend_s _sdaiAppend_s;
        private Delegates.sdaiAppend_b _sdaiAppend_b;
        private Delegates.sdaiCreateADB _sdaiCreateAdb;
        private Delegates.sdaiCreateADB_d _sdaiCreateAdb_d;
        private Delegates.sdaiCreateADB_s _sdaiCreateAdb_s;
        private Delegates.sdaiCreateADB_b _sdaiCreateAdb_b;
        private Delegates.sdaiCreateAggr _sdaiCreateAggr;
        private Delegates.sdaiCreateAggrBN _sdaiCreateAggrBn;
        private Delegates.sdaiCreateAggrBN_byte _sdaiCreateAggrBn_byte;
        private Delegates.sdaiCreateInstance _sdaiCreateInstance;
        private Delegates.sdaiCreateInstanceBN _sdaiCreateInstanceBn;
        private Delegates.sdaiCreateInstanceBN_byte _sdaiCreateInstanceBn_byte;
        private Delegates.sdaiDeleteInstance _sdaiDeleteInstance;
        private Delegates.sdaiPutADBTypePath _sdaiPutAdbTypePath;
        private Delegates.sdaiPutADBTypePath_byte _sdaiPutAdbTypePath_byte;
        private Delegates.sdaiPutAttr _sdaiPutAttr;
        private Delegates.sdaiPutAttr_d _sdaiPutAttr_d;
        private Delegates.sdaiPutAttr_s _sdaiPutAttr_s;
        private Delegates.sdaiPutAttr_b _sdaiPutAttr_b;
        private Delegates.sdaiPutAttrBN _sdaiPutAttrBN;
        private Delegates.sdaiPutAttrBN_d _sdaiPutAttrBN_d;
        private Delegates.sdaiPutAttrBN_s _sdaiPutAttrBN_s;
        private Delegates.sdaiPutAttrBN_b _sdaiPutAttrBN_b;
        private Delegates.sdaiPutAttrBN_byte _sdaiPutAttrBN_byte;
        private Delegates.sdaiPutAttrBN_byte_d _sdaiPutAttrBN_byte_d;
        private Delegates.sdaiPutAttrBN_byte_s _sdaiPutAttrBN_byte_s;
        private Delegates.sdaiPutAttrBN_byte_b _sdaiPutAttrBN_byte_b;
        private Delegates.engiSetComment _engiSetComment;
        private Delegates.engiSetComment_byte _engiSetComment_byte;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void Append(IntPtr list, SdaiType valueType, ref IntPtr value)
        {
            if (_sdaiAppend == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiAppend.Invoke(list, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void Append(IntPtr list, SdaiType valueType, ref double value)
        {
            if (_sdaiAppend_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiAppend_d.Invoke(list, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void Append(IntPtr list, SdaiType valueType, string value)
        {
            if (_sdaiAppend_s == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiAppend_s.Invoke(list, new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">A handle to the list that is extended with this call.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        [Obsolete("Will be removed in next version.")]
        public void Append(IntPtr list, SdaiType valueType, byte[] value)
        {
            if (_sdaiAppend_b == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiAppend_b.Invoke(list, new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value"></param>
        /// <returns>Placeholder for the information, formatting depending on defined valueType.</returns>
        public IntPtr CreateADB(SdaiType valueType, ref IntPtr value)
        {
            if (_sdaiCreateAdb == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateAdb.Invoke(new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value"></param>
        /// <returns>Placeholder for the information, formatting depending on defined valueType.</returns>
        public IntPtr CreateADB(SdaiType valueType, ref double value)
        {
            if (_sdaiCreateAdb_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateAdb_d.Invoke(new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value"></param>
        /// <returns>Placeholder for the information, formatting depending on defined valueType.</returns>
        public IntPtr CreateADB(SdaiType valueType, string value)
        {
            if (_sdaiCreateAdb_s == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateAdb_s.Invoke(new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value"></param>
        /// <returns>Placeholder for the information, formatting depending on defined valueType.</returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr CreateADB(SdaiType valueType, byte[] value)
        {
            if (_sdaiCreateAdb_b == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateAdb_b.Invoke(new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <returns></returns>
        public IntPtr CreateAggregation(IntPtr instance, IntPtr attribute)
        {
            if (_sdaiCreateAggr == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateAggr.Invoke(instance, attribute);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        public IntPtr CreateAggregation(IntPtr instance, string attributeName)
        {
            if (_sdaiCreateAggrBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateAggrBn.Invoke(instance, attributeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr CreateAggregation(IntPtr instance, byte[] attributeName)
        {
            if (_sdaiCreateAggrBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateAggrBn_byte.Invoke(instance, attributeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entity">Handle of an entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        public IntPtr CreateInstance(IntPtr model, IntPtr entity)
        {
            if (_sdaiCreateInstance == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateInstance.Invoke(model, entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entityName">Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        public IntPtr CreateInstance(IntPtr model, string entityName)
        {
            if (_sdaiCreateInstanceBn == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateInstanceBn.Invoke(model, entityName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="entityName">Name of the entity (schema item/class), for example IFCWALLSTANDARDCASE as defined in IFC4.exp.</param>
        /// <returns></returns>
        [Obsolete("Will be removed in next version.")]
        public IntPtr CreateInstance(IntPtr model, byte[] entityName)
        {
            if (_sdaiCreateInstanceBn_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _sdaiCreateInstanceBn_byte.Invoke(model, entityName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        public void DeleteInstance(IntPtr instance)
        {
            if (_sdaiDeleteInstance == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiDeleteInstance.Invoke(instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="pathCount">The number of path's for this ADB type, in case of IFC4 and all earlier versions this should always be 1.</param>
        /// <param name="path">The path of the ADB type, in case of example IFCLABEL('myLabel') the path is "IFCLABEL".</param>
        public void PutADBTypePath(IntPtr ADB, IntPtr pathCount, string path)
        {
            if (_sdaiPutAdbTypePath == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAdbTypePath.Invoke(ADB, pathCount, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADB">Handle to ADB type, a typical representation is IFCLABEL('myLabel') or IFCINTEGER(313).</param>
        /// <param name="pathCount">The number of path's for this ADB type, in case of IFC4 and all earlier versions this should always be 1.</param>
        /// <param name="path">The path of the ADB type, in case of example IFCLABEL('myLabel') the path is "IFCLABEL".</param>
        [Obsolete("Will be removed in next version.")]
        public void PutADBTypePath(IntPtr ADB, IntPtr pathCount, byte[] path)
        {
            if (_sdaiPutAdbTypePath_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAdbTypePath_byte.Invoke(ADB, pathCount, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void PutAttribute(IntPtr instance, IntPtr attribute, SdaiType valueType, ref IntPtr value)
        {
            if (_sdaiPutAttr == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttr.Invoke(instance, attribute, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void PutAttribute(IntPtr instance, IntPtr attribute, SdaiType valueType, ref double value)
        {
            if (_sdaiPutAttr_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttr_d.Invoke(instance, attribute, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void PutAttribute(IntPtr instance, IntPtr attribute, SdaiType valueType, string value)
        {
            if (_sdaiPutAttr_s == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttr_s.Invoke(instance, attribute, new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attribute">A handle to the an attribute of a certain entity, for example attribute Name of entity IFCROOT.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        [Obsolete("Will be removed in next version.")]
        public void PutAttribute(IntPtr instance, IntPtr attribute, SdaiType valueType, byte[] value)
        {
            if (_sdaiPutAttr_b == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttr_b.Invoke(instance, attribute, new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void PutAttribute(IntPtr instance, string attributeName, SdaiType valueType, ref IntPtr value)
        {
            if (_sdaiPutAttrBN == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN.Invoke(instance, attributeName, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void PutAttribute(IntPtr instance, string attributeName, SdaiType valueType, ref double value)
        {
            if (_sdaiPutAttrBN_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN_d.Invoke(instance, attributeName, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        public void PutAttribute(IntPtr instance, string attributeName, SdaiType valueType, string value)
        {
            if (_sdaiPutAttrBN_s == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN_s.Invoke(instance, attributeName, new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        [Obsolete("Will be removed in next version.")]
        public void PutAttribute(IntPtr instance, string attributeName, SdaiType valueType, byte[] value)
        {

            if (_sdaiPutAttrBN_b == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN_b.Invoke(instance, attributeName, new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        [Obsolete("Will be removed in next version.")]
        public void PutAttribute(IntPtr instance, byte[] attributeName, SdaiType valueType, ref IntPtr value)
        {

            if (_sdaiPutAttrBN_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN_byte.Invoke(instance, attributeName, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        [Obsolete("Will be removed in next version.")]
        public void PutAttribute(IntPtr instance, byte[] attributeName, SdaiType valueType,
            ref double value)
        {

            if (_sdaiPutAttrBN_byte_d == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN_byte_d.Invoke(instance, attributeName, new IntPtr((int)valueType), ref value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        [Obsolete("Will be removed in next version.")]
        public void PutAttribute(IntPtr instance, byte[] attributeName, SdaiType valueType, string value)
        {
            if (_sdaiPutAttrBN_byte_s == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN_byte_s.Invoke(instance, attributeName, new IntPtr((int)valueType), value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="attributeName">Name of the attribute, for example Name of IFCROOT as defined in IFC4.exp.</param>
        /// <param name="valueType">Type of the value, for example sdaiSTRING, sdaiINSTANCE, sdaiREAL, ...</param>
        /// <param name="value">Placeholder for the information, formatting depending on defined valueType.</param>
        [Obsolete("Will be removed in next version.")]
        public void PutAttribute(IntPtr instance, byte[] attributeName, SdaiType valueType, byte[] value)
        {
            if (_sdaiPutAttrBN_byte_b == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _sdaiPutAttrBN_byte_b.Invoke(instance, attributeName, new IntPtr((int)valueType), value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="comment">A string value that will be included in the exported IFC file as comment to the instance.</param>
        public void SetComment(IntPtr instance, string comment)
        {
            if (_engiSetComment == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _engiSetComment.Invoke(instance, comment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="comment">A string value that will be included in the exported IFC file as comment to the instance.</param>
        [Obsolete("Will be removed in next version.")]
        public void SetComment(IntPtr instance, byte[] comment)
        {
            if (_engiSetComment_byte == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _engiSetComment_byte.Invoke(instance, comment);
        }
        #endregion

        #region Controling Calls

        private Delegates.circleSegments _circleSegments;
        private Delegates.cleanMemory _cleanMemory;
        private Delegates.internalGetP21Line _internalGetP21Line;
        private Delegates.internalGetInstanceFromP21Line _internalGetInstanceFromP21Line;
        private Delegates.setStringUnicode _setStringUnicode;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="circles">Segmentation parts of a complete or large part of a circle (default is 36).</param>
        /// <param name="smallCircles">Segmentation parts of a small part of a circle (default is 5).</param>
        public void CircleSegments(int circles = 36, int smallCircles = 5)
        {
            if (_circleSegments == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _circleSegments.Invoke(new IntPtr(circles), new IntPtr(smallCircles));
        }

        public void CleanMemory(IntPtr model, Mode mode = Mode.Default)
        {
            if (_cleanMemory == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _cleanMemory.Invoke(model, new IntPtr((int)mode));
        }

        /// <summary>
        /// get P21 line number by an instance id
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public IntPtr InternalGetP21Line(IntPtr instance)
        {
            if (_internalGetP21Line == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _internalGetP21Line.Invoke(instance);
        }

        public IntPtr InternalGetInstanceFromP21Line(IntPtr model, IntPtr P21Line)
        {
            if (_internalGetInstanceFromP21Line == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _internalGetInstanceFromP21Line.Invoke(model, P21Line);
        }

        public IntPtr SetStringUnicode(IntPtr unicode)
        {
            if (_setStringUnicode == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _setStringUnicode.Invoke(unicode);
        }
        #endregion

        #region Geometry Interaction

        private Delegates.initializeModellingInstance _initializeModellingInstance;
        private Delegates.finalizeModelling _finalizeModelling;
        private Delegates.finalizeModelling_64 _finalizeModelling_64;
        private Delegates.finalizeModelling_d _finalizeModelling_d;
        private Delegates.finalizeModelling_d64 _finalizeModelling_d64;
        private Delegates.getInstanceInModelling _getInstanceInModelling;
        private Delegates.setVertexOffset _setVertexOffset;
        private Delegates.setFilter _setFilter;
        private Delegates.setFormat _setFormat;
        private Delegates.getConceptualFaceCnt _getConceptualFaceCnt;
        private Delegates.getConceptualFaceEx _getConceptualFaceEx;

        /// <summary>
        /// The number of vertices and number of indices needed for storing the geometry of the given IFC instance is calculated by this function.
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="noVertices">The number of vertices that are needed for this instance.</param>
        /// <param name="noIndices">The number of indices that are needed for this instance.</param>
        /// <param name="scale">Ignore this argument use 1 as default value.</param>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <returns></returns>
        public IntPtr InitializeModellingInstance(IntPtr model, ref IntPtr noVertices, ref IntPtr noIndices, double scale, IntPtr instance)
        {
            if (_initializeModellingInstance == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _initializeModellingInstance.Invoke(model, ref noVertices, ref noIndices, scale, instance);
        }

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">The array containing the space for vertex information.</param>
        /// <param name="indices">The array containing the space for index information.</param>
        /// <param name="FVF">Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        public IntPtr FinalizeModelling(IntPtr model, float[] vertices, Int32[] indices, IntPtr FVF)
        {
            if (_finalizeModelling == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _finalizeModelling.Invoke(model, vertices, indices, FVF);
        }

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">The array containing the space for vertex information.</param>
        /// <param name="indices">The array containing the space for index information.</param>
        /// <param name="FVF">Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        public IntPtr FinalizeModelling(IntPtr model, float[] vertices, Int64[] indices, IntPtr FVF)
        {
            if (_finalizeModelling == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _finalizeModelling_64.Invoke(model, vertices, indices, FVF);
        }

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">The array containing the space for vertex information.</param>
        /// <param name="indices">The array containing the space for index information.</param>
        /// <param name="FVF">Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        public IntPtr FinalizeModelling(IntPtr model, double[] vertices, Int32[] indices, IntPtr FVF)
        {
            if (_finalizeModelling == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _finalizeModelling_d.Invoke(model, vertices, indices, FVF);
        }

        /// <summary>
        /// After initializeModellingInstance() this call will fill the actual vertex and index array allocated by the client application.
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="vertices">The array containing the space for vertex information.</param>
        /// <param name="indices">The array containing the space for index information.</param>
        /// <param name="FVF">Ignore this argument use 0 as default value. Its original use is covered by setFormat().</param>
        /// <returns></returns>
        public IntPtr FinalizeModelling(IntPtr model, double[] vertices, Int64[] indices, IntPtr FVF)
        {
            if (_finalizeModelling == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _finalizeModelling_d64.Invoke(model, vertices, indices, FVF);
        }

        /// <summary>
        /// This call will return the part of the index array representing the triangle set that visualizes the IFC instance. This call is only relevant if purely the triangulated geometry is generated (setFormat is not requesting points, lines or wireframe). For geometry also containing points, lines and/or wireframe representations the calls getConceptualFaceCnt() and getConceptualFaceEx() should be used.
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="mode"></param>
        /// <param name="startVertex">The first vertex in the array of relevance for this instance (can be used to improve performance of the rendering engine).</param>
        /// <param name="startIndex">The first index in the array of relevance for this instance (can be used to improve performance of the rendering engine).</param>
        /// <param name="primitiveCount">The number of primitives available (for example 4 primitives and the case we have triangles means 12 following indices representing the data on the index array).</param>
        /// <returns></returns>
        public IntPtr GetInstanceInModelling(IntPtr model, IntPtr instance, Mode mode, ref IntPtr startVertex,
            ref IntPtr startIndex, ref IntPtr primitiveCount)
        {
            if (_getInstanceInModelling == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _getInstanceInModelling.Invoke(model, instance, new IntPtr((int)mode), ref startVertex, ref startIndex, ref primitiveCount);
        }

        /// <summary>
        /// This call will update the vertex offset of the returned geometry. Some IFC files have the origin placed far far away from the actual geometry, in case 32 bit precision vertices are requested (what is default), the converted results from internal 64 bit representation could cause visual disturbances due to precision limitations in 32 bit that can be solved by moving the origin of the geometry closer to the actual geometry.
        /// </summary>
        /// <param name="model">Handle of the model containing the IFC file, this handle is needed in many other calls and given when the model is created.</param>
        /// <param name="x">X value for offset of each vertex.</param>
        /// <param name="y">Y value for offset of each vertex.</param>
        /// <param name="z">Z value for offset of each vertex.</param>
        public void SetVertexOffset(IntPtr model, double x, double y, double z)
        {
            if (_setVertexOffset == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _setVertexOffset.Invoke(model, x, y, z);
        }

        public void SetFilter(IntPtr model, Setting setting, Mask mask)
        {
            if (_setFilter == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _setFilter.Invoke(model, new IntPtr((int)setting), new IntPtr((int)mask));
        }

        public void SetFormat(IntPtr model, Setting setting, Mask mask)
        {
            if (_setFormat == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            _setFormat.Invoke(model, new IntPtr((int)setting), new IntPtr((int)mask));
        }

        public IntPtr GetConceptualFaceCount(IntPtr instance)
        {
            if (_getConceptualFaceCnt == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _getConceptualFaceCnt.Invoke(instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance">Handle of an instance within an IFC file, for example #31313 = IFCWALLSTANDARDCASE(...)</param>
        /// <param name="index">Integer value equal or larger then 0 and smaller than given maximum length of array/list/aggregation used.</param>
        /// <param name="startIndexTriangles"></param>
        /// <param name="noIndicesTriangles"></param>
        /// <param name="startIndexLines"></param>
        /// <param name="noIndicesLines"></param>
        /// <param name="startIndexPoints"></param>
        /// <param name="noIndicesPoints"></param>
        /// <param name="startIndexFacesPolygons"></param>
        /// <param name="noIndicesFacesPolygons"></param>
        /// <param name="startIndexConceptualFacePolygons"></param>
        /// <param name="noIndicesConceptualFacePolygons"></param>
        /// <returns></returns>
        public IntPtr GetConceptualFaceEx(IntPtr instance, IntPtr index, ref IntPtr startIndexTriangles,
            ref IntPtr noIndicesTriangles, ref IntPtr startIndexLines, ref IntPtr noIndicesLines,
            ref IntPtr startIndexPoints, ref IntPtr noIndicesPoints, ref IntPtr startIndexFacesPolygons,
            ref IntPtr noIndicesFacesPolygons, ref IntPtr startIndexConceptualFacePolygons,
            ref IntPtr noIndicesConceptualFacePolygons)
        {
            if (_getConceptualFaceEx == null) {
                throw new Exception("Failed in loading IfcEngine.");
            }
            return _getConceptualFaceEx.Invoke(instance, index, ref startIndexTriangles, ref noIndicesTriangles,
                ref startIndexLines, ref noIndicesLines, ref startIndexPoints, ref noIndicesPoints,
                ref startIndexFacesPolygons, ref noIndicesFacesPolygons, ref startIndexConceptualFacePolygons, ref noIndicesConceptualFacePolygons);
        }
        #endregion

        #region Engine Const
        private const int flagbit0 = 1;           // 2^^0    0000.0000..0000.0001
        private const int flagbit1 = 2;           // 2^^1    0000.0000..0000.0010
        private const int flagbit2 = 4;           // 2^^2    0000.0000..0000.0100
        private const int flagbit3 = 8;           // 2^^3    0000.0000..0000.1000
        private const int flagbit4 = 16;          // 2^^4    0000.0000..0001.0000
        private const int flagbit5 = 32;          // 2^^5    0000.0000..0010.0000
        private const int flagbit6 = 64;          // 2^^6    0000.0000..0100.0000
        private const int flagbit7 = 128;         // 2^^7    0000.0000..1000.0000
        private const int flagbit8 = 256;         // 2^^8    0000.0001..0000.0000
        private const int flagbit9 = 512;         // 2^^9    0000.0010..0000.0000
        private const int flagbit10 = 1024;       // 2^^10   0000.0100..0000.0000
        private const int flagbit11 = 2048;       // 2^^11   0000.1000..0000.0000
        private const int flagbit12 = 4096;       // 2^^12   0001.0000..0000.0000
        private const int flagbit13 = 8192;       // 2^^13   0010.0000..0000.0000
        private const int flagbit14 = 16384;      // 2^^14   0100.0000..0000.0000
        private const int flagbit15 = 32768;      // 2^^15   1000.0000..0000.0000

        private const int sdaiADB = 1;
        private const int sdaiAGGR = sdaiADB + 1;
        private const int sdaiBINARY = sdaiAGGR + 1;
        private const int sdaiBOOLEAN = sdaiBINARY + 1;
        private const int sdaiENUM = sdaiBOOLEAN + 1;
        private const int sdaiINSTANCE = sdaiENUM + 1;
        private const int sdaiINTEGER = sdaiINSTANCE + 1;
        private const int sdaiLOGICAL = sdaiINTEGER + 1;
        private const int sdaiREAL = sdaiLOGICAL + 1;
        private const int sdaiSTRING = sdaiREAL + 1;
        private const int sdaiUNICODE = sdaiSTRING + 1;
        private const int sdaiEXPRESSSTRING = sdaiUNICODE + 1;
        private const int engiGLOBALID = sdaiEXPRESSSTRING + 1;
        #endregion

        [Flags]
        public enum Mask : int
        {
            /// <summary>
            /// use single precision and 32bit index array, turn normals, triangles, wireframe off
            /// </summary>
            Default = 0,
            DoublePrecision = flagbit2,
            UseIndex64 = flagbit3,
            GenNormals = flagbit5,
            GenTriangles = flagbit8,
            GenWireFrame = flagbit12,
        }

        [Flags]
        public enum Setting : int
        {
            /// <summary>
            /// use single precision and 32bit index array, turn normals, triangles, wireframe off
            /// </summary>
            Default = 0,
            DoublePrecision = flagbit2,
            UseIndex64 = flagbit3,
            GenNormals = flagbit5,
            GenTriangles = flagbit8,
            GenWireframe = flagbit12
        }

        [Flags]
        public enum Mode : int
        {
            Default = 0,
            //TODO add other mode
        }

        public enum SdaiType : int
        {
            None = 0,
            ADB = sdaiADB,
            Aggregation = sdaiAGGR,
            Binary = sdaiBINARY,
            Boolean = sdaiBOOLEAN,
            Enum = sdaiENUM,
            Instance = sdaiINSTANCE,
            Integer = sdaiINTEGER,
            Logical = sdaiLOGICAL,
            Real = sdaiREAL,
            String = sdaiSTRING,
            Unicode = sdaiUNICODE,
            ExpressString = sdaiEXPRESSSTRING,
            GlobalId = engiGLOBALID
        }

        class Delegates
        {
            #region File IO
            public delegate void sdaiCloseModel(IntPtr model);
            public delegate IntPtr sdaiCreateModelBN(IntPtr repository, string fileName, string schemaName);
            public delegate IntPtr sdaiCreateModelBN_byte(IntPtr repository, byte[] fileName, byte[] schemaName);
            public delegate IntPtr sdaiCreateModelBNUnicode(IntPtr repository, byte[] fileName, byte[] schemaName);
            public delegate IntPtr sdaiOpenModelBN(IntPtr repository, string fileName, string schemaName);
            public delegate IntPtr sdaiOpenModelBN_byte(IntPtr repository, byte[] fileName, byte[] schemaName);
            public delegate IntPtr sdaiOpenModelBNUnicode(IntPtr repository, byte[] fileName, byte[] schemaName);
            public delegate void sdaiSaveModelBN(IntPtr model, string fileName);
            public delegate void sdaiSaveModelBN_byte(IntPtr model, byte[] fileName);
            public delegate void sdaiSaveModelBNUnicode(IntPtr model, byte[] fileName);
            public delegate void sdaiSaveModelAsXmlBN(IntPtr model, string fileName);
            public delegate void sdaiSaveModelAsXmlBN_byte(IntPtr model, byte[] fileName);
            public delegate void sdaiSaveModelAsXmlBNUnicode(IntPtr model, byte[] fileName);
            public delegate void sdaiSaveModelAsSimpleXmlBN(IntPtr model, string fileName);
            public delegate void sdaiSaveModelAsSimpleXmlBN_byte(IntPtr model, byte[] fileName);
            public delegate void sdaiSaveModelAsSimpleXmlBNUnicode(IntPtr model, byte[] fileName);
            #endregion

            #region Schema Reading
            public delegate IntPtr sdaiGetEntity(IntPtr model, string entityName);
            public delegate IntPtr sdaiGetEntity_byte(IntPtr model, byte[] entityName);
            public delegate void engiGetEntityArgumentName(IntPtr entity, IntPtr index, IntPtr valueType, out IntPtr argumentName);
            public delegate void engiGetEntityArgumentType(IntPtr entity, IntPtr index, ref IntPtr argumentType);
            public delegate IntPtr engiGetEntityCount(IntPtr model);
            public delegate IntPtr engiGetEntityElement(IntPtr model, IntPtr index);
            public delegate IntPtr sdaiGetEntityExtent(IntPtr model, IntPtr entity);
            public delegate IntPtr sdaiGetEntityExtentBN(IntPtr model, string entityName);
            public delegate IntPtr sdaiGetEntityExtentBN_byte(IntPtr model, byte[] entityName);
            public delegate void engiGetEntityName(IntPtr entity, IntPtr valueType, out IntPtr entityName);
            public delegate IntPtr engiGetEntityNoArguments(IntPtr entity);
            public delegate IntPtr engiGetEntityParent(IntPtr entity);
            #endregion

            #region Instance Header
            public delegate IntPtr GetSPFFHeaderItem(IntPtr model, IntPtr itemIndex, IntPtr itemSubIndex, IntPtr valueType, out IntPtr value);
            public delegate void SetSPFFHeader(IntPtr model, string description, string implementationLevel, string name, string timeStamp, string author, string organization, string preprocessorVersion, string originatingSystem, string authorization, string fileSchema);
            public delegate void SetSPFFHeader_byte(IntPtr model, byte[] description, byte[] implementationLevel, byte[] name, byte[] timeStamp, byte[] author, byte[] organization, byte[] preprocessorVersion, byte[] originatingSystem, byte[] authorization, byte[] fileSchema);
            public delegate IntPtr SetSPFFHeaderItem(IntPtr model, IntPtr itemIndex, IntPtr itemSubIndex, IntPtr valueType, string value);
            public delegate IntPtr SetSPFFHeaderItem_byte(IntPtr model, IntPtr itemIndex, IntPtr itemSubIndex, IntPtr valueType, byte[] value);
            #endregion

            #region Instance Reading
            public delegate IntPtr sdaiGetADBType(IntPtr ADB);
            public delegate void sdaiGetADBTypePath(IntPtr ADB, IntPtr typeNameNumber, out IntPtr path);
            public delegate void sdaiGetADBValue(IntPtr ADB, IntPtr valueType, out  IntPtr value);
            public delegate void sdaiGetADBValue_d(IntPtr ADB, IntPtr valueType, out double value);
            public delegate IntPtr engiGetAggrElement(IntPtr aggregate, IntPtr elementIndex, IntPtr valueType, out  IntPtr value);
            public delegate IntPtr engiGetAggrElement_d(IntPtr aggregate, IntPtr elementIndex, IntPtr valueType, out double value);
            public delegate void engiGetAggrType(IntPtr aggregate, ref IntPtr aggragateType);
            public delegate IntPtr sdaiGetAttr(IntPtr instance, IntPtr attribute, IntPtr valueType, out  IntPtr value);
            public delegate IntPtr sdaiGetAttr_d(IntPtr instance, IntPtr attribute, IntPtr valueType, out double value);
            public delegate IntPtr sdaiGetAttrBN(IntPtr instance, string attributeName, IntPtr valueType, out  IntPtr value);
            public delegate IntPtr sdaiGetAttrBN_d(IntPtr instance, string attributeName, IntPtr valueType, out double value);
            public delegate IntPtr sdaiGetAttrBN_byte(IntPtr instance, byte[] attributeName, IntPtr valueType, out  IntPtr value);
            public delegate IntPtr sdaiGetAttrBN_byte_d(IntPtr instance, byte[] attributeName, IntPtr valueType, out double value);
            public delegate IntPtr sdaiGetAttrDefinition(IntPtr entity, string attributeName);
            public delegate IntPtr sdaiGetAttrDefinition_byte(IntPtr entity, byte[] attributeName);
            public delegate IntPtr sdaiGetInstanceType(IntPtr instance);
            public delegate IntPtr sdaiGetMemberCount(IntPtr aggregate);
            public delegate IntPtr sdaiIsKindOf(IntPtr instance, IntPtr entity);
            #endregion

            #region Instance Wrting
            public delegate void sdaiAppend(IntPtr list, IntPtr valueType, ref  IntPtr value);
            public delegate void sdaiAppend_d(IntPtr list, IntPtr valueType, ref double value);
            public delegate void sdaiAppend_s(IntPtr list, IntPtr valueType, string value);
            public delegate void sdaiAppend_b(IntPtr list, IntPtr valueType, byte[] value);
            public delegate IntPtr sdaiCreateADB(IntPtr valueType, ref  IntPtr value);
            public delegate IntPtr sdaiCreateADB_d(IntPtr valueType, ref double value);
            public delegate IntPtr sdaiCreateADB_s(IntPtr valueType, string value);
            public delegate IntPtr sdaiCreateADB_b(IntPtr valueType, byte[] value);
            public delegate IntPtr sdaiCreateAggr(IntPtr instance, IntPtr attribute);
            public delegate IntPtr sdaiCreateAggrBN(IntPtr instance, string attributeName);
            public delegate IntPtr sdaiCreateAggrBN_byte(IntPtr instance, byte[] attributeName);
            public delegate IntPtr sdaiCreateInstance(IntPtr model, IntPtr entity);
            public delegate IntPtr sdaiCreateInstanceBN(IntPtr model, string entityName);
            public delegate IntPtr sdaiCreateInstanceBN_byte(IntPtr model, byte[] entityName);
            public delegate void sdaiDeleteInstance(IntPtr instance);
            public delegate void sdaiPutADBTypePath(IntPtr ADB, IntPtr pathCount, string path);
            public delegate void sdaiPutADBTypePath_byte(IntPtr ADB, IntPtr pathCount, byte[] path);
            public delegate void sdaiPutAttr(IntPtr instance, IntPtr attribute, IntPtr valueType, ref  IntPtr value);
            public delegate void sdaiPutAttr_d(IntPtr instance, IntPtr attribute, IntPtr valueType, ref double value);
            public delegate void sdaiPutAttr_s(IntPtr instance, IntPtr attribute, IntPtr valueType, string value);
            public delegate void sdaiPutAttr_b(IntPtr instance, IntPtr attribute, IntPtr valueType, byte[] value);
            public delegate void sdaiPutAttrBN(IntPtr instance, string attributeName, IntPtr valueType, ref  IntPtr value);
            public delegate void sdaiPutAttrBN_d(IntPtr instance, string attributeName, IntPtr valueType, ref double value);
            public delegate void sdaiPutAttrBN_s(IntPtr instance, string attributeName, IntPtr valueType, string value);
            public delegate void sdaiPutAttrBN_b(IntPtr instance, string attributeName, IntPtr valueType, byte[] value);
            public delegate void sdaiPutAttrBN_byte(IntPtr instance, byte[] attributeName, IntPtr valueType, ref  IntPtr value);
            public delegate void sdaiPutAttrBN_byte_d(IntPtr instance, byte[] attributeName, IntPtr valueType, ref double value);
            public delegate void sdaiPutAttrBN_byte_s(IntPtr instance, byte[] attributeName, IntPtr valueType, string value);
            public delegate void sdaiPutAttrBN_byte_b(IntPtr instance, byte[] attributeName, IntPtr valueType, byte[] value);
            public delegate void engiSetComment(IntPtr instance, string comment);
            public delegate void engiSetComment_byte(IntPtr instance, byte[] comment);
            #endregion

            #region Controling Calls
            public delegate void circleSegments(IntPtr circles, IntPtr smallCircles);
            public delegate void cleanMemory(IntPtr model, IntPtr mode);
            public delegate IntPtr internalGetP21Line(IntPtr instance);
            public delegate IntPtr internalGetInstanceFromP21Line(IntPtr model, IntPtr P21Line);
            public delegate IntPtr setStringUnicode(IntPtr unicode);
            #endregion

            #region Geometry Interaction
            public delegate IntPtr initializeModellingInstance(IntPtr model, ref IntPtr noVertices, ref IntPtr noIndices, double scale, IntPtr instance);
            public delegate IntPtr finalizeModelling(IntPtr model, float[] vertices, Int32[] indices, IntPtr FVF);
            public delegate IntPtr finalizeModelling_64(IntPtr model, float[] vertices, Int64[] indices, IntPtr FVF);
            public delegate IntPtr finalizeModelling_d(IntPtr model, double[] vertices, Int32[] indices, IntPtr FVF);
            public delegate IntPtr finalizeModelling_d64(IntPtr model, double[] vertices, Int64[] indices, IntPtr FVF);
            public delegate IntPtr getInstanceInModelling(IntPtr model, IntPtr instance, IntPtr mode, ref IntPtr startVertex, ref IntPtr startIndex, ref IntPtr primitiveCount);
            public delegate void setVertexOffset(IntPtr model, double x, double y, double z);
            public delegate void setFilter(IntPtr model, IntPtr setting, IntPtr mask);
            public delegate void setFormat(IntPtr model, IntPtr setting, IntPtr mask);
            public delegate IntPtr getConceptualFaceCnt(IntPtr instance);
            public delegate IntPtr getConceptualFaceEx(IntPtr instance, IntPtr index, ref IntPtr startIndexTriangles, ref IntPtr noIndicesTriangles, ref IntPtr startIndexLines, ref IntPtr noIndicesLines, ref IntPtr startIndexPoints, ref IntPtr noIndicesPoints, ref IntPtr startIndexFacesPolygons, ref IntPtr noIndicesFacesPolygons, ref IntPtr startIndexConceptualFacePolygons, ref IntPtr noIndicesConceptualFacePolygons);
            #endregion
        }
    }
}
