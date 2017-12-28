using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Management.Factory
{
    /// <summary>
    /// 电子病历
    /// </summary>
    public abstract class EPRBase : FactoryBase
    {
        #region IEPR 成员


        public System.Collections.ArrayList UserTextGetList(string type, int usertype)
        {
            Neusoft.HISFC.Management.Manager.UserText manager = new Neusoft.HISFC.Management.Manager.UserText();
            this.SetDB(manager);
            return manager.GetList(type, usertype);
        }

        public bool GetMedicalPermission(Neusoft.HISFC.Object.EPR.EnumPermissionType type, int index)
        {
            Neusoft.HISFC.Management.Medical.Permission manager = new Neusoft.HISFC.Management.Medical.Permission();
            this.SetDB(manager);
            if (type == Neusoft.HISFC.Object.EPR.EnumPermissionType.EMR)
            {
                return manager.GetPermission(Neusoft.NFC.Management.Connection.Operator.ID).EMRPermission.GetOnePermission(index);
            }
            else if (type == Neusoft.HISFC.Object.EPR.EnumPermissionType.Order)
            {
                return manager.GetPermission(Neusoft.NFC.Management.Connection.Operator.ID).OrderPermission.GetOnePermission(index);

            }
            else
            {
                return manager.GetPermission(Neusoft.NFC.Management.Connection.Operator.ID).QCPermission.GetOnePermission(index);

            }

        }

        public Neusoft.HISFC.Object.File.DataFileParam GetDataFileParam(string type)
        {
            Neusoft.HISFC.Management.EPR.DataFileParam manager = new Neusoft.HISFC.Management.EPR.DataFileParam();
            this.SetDB(manager);
            return manager.Get(type) as Neusoft.HISFC.Object.File.DataFileParam;
            //COM_FILEPARAM
        }

        public System.Collections.ArrayList GetModualList(Neusoft.HISFC.Object.File.DataFileParam param, bool isAll)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.GetModualList(param, isAll);
        }

        public System.Collections.ArrayList GetFileList(Neusoft.HISFC.Object.File.DataFileParam param, bool isModual, bool isAll)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.GetList(param, Neusoft.NFC.Function.NConvert.ToInt32(isModual), isAll);
        }

        public string GetNewFileID()
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.GetNewFileID();
        }

        public Neusoft.HISFC.Object.File.DataFileInfo GetFile(string id)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.Get(id) as Neusoft.HISFC.Object.File.DataFileInfo;
        }

        public Neusoft.HISFC.Object.File.DataFileInfo GetModualFile(string id)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.Get(id, 1) as Neusoft.HISFC.Object.File.DataFileInfo;
        }

        public int SetFile(Neusoft.HISFC.Object.File.DataFileInfo fileInfo)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.Set(fileInfo);
        }

        public int SetFile(Neusoft.HISFC.Object.File.DataFileInfo fileInfo, int type)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.Set(fileInfo, type);
        }

        public int DeleteFile(string fileID, int type)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.Del(fileID, type);
        }

        public int SetModualValid(Neusoft.HISFC.Object.File.DataFileInfo fileInfo, int type)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.SetValid(fileInfo, type);
        }

        public int SetModualInValid(Neusoft.HISFC.Object.File.DataFileInfo fileInfo, int type)
        {
            Neusoft.HISFC.Management.EPR.DataFileInfo manager = new Neusoft.HISFC.Management.EPR.DataFileInfo();
            this.SetDB(manager);
            return manager.SetInValid(fileInfo, type);
        }

        public int SaveNodeToDataStore(string Table, Neusoft.HISFC.Object.File.DataFileInfo dt, string ParentText, string NodeText, string NodeValue)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            return manager.SaveNodeToDataStore(Table, dt, ParentText, NodeText, NodeValue);
        }

        public int DeleteAllNodeFromDataStore(string Table, Neusoft.HISFC.Object.File.DataFileInfo dt)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            return manager.DeleteAllNodeFromDataStore(Table, dt);
        }

        public string GetNodeValueFormDataStore(string Table, string inpatientNo, string nodeName)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            return manager.GetNodeValueFormDataStore(Table, inpatientNo, nodeName);
        }

        public int ImportToDatabase(Neusoft.HISFC.Object.File.DataFileInfo dt, byte[] fileData)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            return manager.ImportToDatabase(dt, fileData);
        }

        public byte[] ExportFromDatabase(Neusoft.HISFC.Object.File.DataFileInfo dt)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            byte[] b = new byte[0];
            if (manager.ExportFromDatabase(dt, ref b) == -1)
                return null;
            return b;
        }

        public int ImportToDatabase(Neusoft.HISFC.Object.File.DataFileInfo dt, string fileData)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            return manager.ImportToDatabase(dt, fileData);
        }

        public int ExportFromDatabase(Neusoft.HISFC.Object.File.DataFileInfo dt, ref  byte[] by)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            if (manager.ExportFromDatabase(dt, ref by) == -1)
                return -1;
            return 0;
        }
        public int ExportFromDatabase(Neusoft.HISFC.Object.File.DataFileInfo dt, ref string fileData)
        {
            Neusoft.HISFC.Management.EPR.DataFile manager = new Neusoft.HISFC.Management.EPR.DataFile();
            this.SetDB(manager);
            return manager.ExportFromDatabase(dt, ref fileData);
        }

        public bool IsSign(string fileID)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.IsSign(fileID);
        }

        public bool IsSeal(string inpatientNo)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.IsSeal(inpatientNo);
        }

        public int Seal(string inpatientNo)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.Seal(inpatientNo);
        }

        public System.Data.DataSet QueryLogo(string where)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.QueryLogo(where);
        }

        public int UnSeal(string inpatientNo)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.UnSeal(inpatientNo);
        }

        public int SignEmrPage(string fileId)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.SignEmrPage(fileId);
        }

        public System.Data.DataSet GetNodePath()
        {
            Neusoft.HISFC.Management.EPR.NodePath manager = new Neusoft.HISFC.Management.EPR.NodePath();
            this.SetDB(manager);
            return manager.GetNodePath();
        }

        public System.Collections.ArrayList GetNodePathList(string table)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.GetNodePathList(table);
        }

        public string GetDateNodeValueByIndex(string table, string inpatientNo, string Name, string NodeName, DateTime date, string index)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.GetDateNodeValueByIndex(table, inpatientNo, Name, NodeName, date, index);
        }

        public string GetDateNodeValueByTime(string table, string inpatientNo, string Name, string NodeName, DateTime date)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.GetDateNodeValueByTime(table, inpatientNo, Name, NodeName, date);
        }
        public ArrayList GetDateNodePathList(string table, string inpatientNo, string Name)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.GetDateNodePathList(table, inpatientNo, Name);
        }
        public ArrayList GetDateNodePathList(string table, string inpatientNo, string Name, string NodeName)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.GetDateNodePathList(table, inpatientNo, Name, NodeName);
        }
        public int SaveNodeToDateDataStoreByTime(string Table, Neusoft.HISFC.Object.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string NodeValue, string Unit)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.SaveNodeToDateDataStoreByTime(Table, dt, Name, nodeName, date, NodeValue, Unit);
        }
        public int SaveNodeToDateDataStoreByIndex(string Table, Neusoft.HISFC.Object.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string Index, string NodeValue, string Unit)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.SaveNodeToDateDataStoreByIndex(Table, dt, Name, nodeName, date, Index, NodeValue, Unit);
        }

        public int SaveNodeToDateDataStoreByInsertIndex(string Table, Neusoft.HISFC.Object.File.DataFileInfo dt, string Name, string nodeName, DateTime date, string Index, string NodeValue, string Unit)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.SaveNodeToDateDataStoreByInsertIndex(Table, dt, Name, nodeName, date, Index, NodeValue, Unit);
        }
        public int DelDataStoreVitalSignByIndex(string Table, Neusoft.HISFC.Object.File.DataFileInfo dt)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.DelDataStoreVitalSignByIndex(Table,dt);
        }
        public int DelDataStoreVitalSignByIndex1OneTime(string Table, Neusoft.HISFC.Object.File.DataFileInfo dt,DateTime recordtime)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.DelDataStoreVitalSignByIndex1OneTime(Table, dt, recordtime);
        }
        public Hashtable QueryDataStoreVitalSignByIndex1(string Table, string datatype ,string inpatientNo)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.QueryDataStoreVitalSignByIndex1(Table, datatype,inpatientNo);
        }
        public ArrayList QueryDataStoreVitalSignByIndex1OneTime(string Table, string datatype, string inpatientNo,DateTime recorddate)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.QueryDataStoreVitalSignByIndex1OneTime(Table, datatype, inpatientNo, recorddate);
        }
        public ArrayList QueryDataStoreVitalSignByRecordDate(string Table, string datatype, string nodename, string patientids)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.QueryDataStoreVitalSignByRecordDate(Table, datatype, nodename, patientids);
        }
        public Hashtable QueryDataStoreVitalSignByAllIndex1Data(string Table, string datatype, string nodename, string patientids, string recorddate)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.QueryDataStoreVitalSignByAllIndex1Data(Table, datatype, nodename, patientids, recorddate);
        }
        public System.Data.DataSet QueryEMRByNode(string strWhere)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.QueryEMRByNode(strWhere);
        }

        public int DeleteNodePath(string nodeName)
        {
            Neusoft.HISFC.Management.EPR.NodePath manager = new Neusoft.HISFC.Management.EPR.NodePath();
            this.SetDB(manager);
            return manager.DeleteNodePath(nodeName);
        }

        public int InsertNodePath(Neusoft.NFC.Object.NeuObject obj)
        {
            Neusoft.HISFC.Management.EPR.NodePath manager = new Neusoft.HISFC.Management.EPR.NodePath();
            this.SetDB(manager);
            return manager.InsertNodePath(obj);
        }

        public int InsertQCData(Neusoft.HISFC.Object.EPR.QC qc)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            if (manager.InsertQCData(qc) == -1)
            {
                return -1;
            }
            else
            {
                if (qc.QCData.Saver.ID != "") //签名更新 
                    return manager.SignEmrPage(qc);   //签名用及更新
            }
            return 1;
        }

        public bool IsHaveSameEMRName(string index1, string nodeName)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.IsHaveSameEMRName(index1, nodeName);
        }

        public System.Collections.ArrayList GetQCDataBySqlWhere(string where)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.GetQCDataBySqlWhere(where);
        }

        public int DeleteQCCondition(string qcConditonID)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.DeleteQCCondition(qcConditonID);
        }

        public System.Collections.ArrayList GetQCConditionList()
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.GetQCConditionList();
        }

        public int InsertQCCondition(Neusoft.HISFC.Object.EPR.QCConditions conditions)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.InsertQCCondition(conditions);
        }

        public int UpdateQCCondition(Neusoft.HISFC.Object.EPR.QCConditions conditions)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.UpdateQCCondition(conditions);
        }

        public System.Collections.ArrayList GetQCScoreSetList()
        {
            Neusoft.HISFC.Management.EPR.QCScore manager = new Neusoft.HISFC.Management.EPR.QCScore();
            this.SetDB(manager);
            return manager.GetQCScoreSetList();
        }

        public System.Collections.ArrayList GetQCScoreList(string inpatientNo)
        {
            Neusoft.HISFC.Management.EPR.QCScore manager = new Neusoft.HISFC.Management.EPR.QCScore();
            this.SetDB(manager);
            return manager.GetQCScoreList(inpatientNo);
        }

        public int DeleteQCScore(string inpatientNo)
        {
            Neusoft.HISFC.Management.EPR.QCScore manager = new Neusoft.HISFC.Management.EPR.QCScore();
            this.SetDB(manager);
            return manager.DeleteQCScore(inpatientNo);
        }

        public int InsertQCScore(Neusoft.HISFC.Object.EPR.QCScore qcScore)
        {
            Neusoft.HISFC.Management.EPR.QCScore manager = new Neusoft.HISFC.Management.EPR.QCScore();
            this.SetDB(manager);
            return manager.InsertQCScore(qcScore);
        }

        public int UpdateQCDataState(string qcScoreID, int state)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.UpdateQCDataState(qcScoreID, state);
        }

        public int SetSign(Neusoft.NFC.Object.NeuObject obj, byte[] byteimg)
        {
            Neusoft.HISFC.Management.EPR.Sign manager = new Neusoft.HISFC.Management.EPR.Sign();
            this.SetDB(manager);
            return manager.SetSign(obj, byteimg);
        }

        public byte[] GetSignBackGround(string emplCode)
        {
            Neusoft.HISFC.Management.EPR.Sign manager = new Neusoft.HISFC.Management.EPR.Sign();
            this.SetDB(manager);
            return manager.GetSignBackGround(emplCode);
        }

        public System.Collections.ArrayList GetQCName()
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.GetQCName();
        }

        public bool ExecQCInfo(string inpatientNo, Neusoft.NFC.Management.Interface ISql, Neusoft.HISFC.Object.EPR.QCConditions condition)
        {
            Neusoft.HISFC.Management.EPR.QCInfo manager = new Neusoft.HISFC.Management.EPR.QCInfo();
            this.SetDB(manager);
            return manager.ExecQCInfo(inpatientNo, ISql, condition);
        }

        public int DeleteQCScoreSet(string id)
        {
            Neusoft.HISFC.Management.EPR.QCScore manager = new Neusoft.HISFC.Management.EPR.QCScore();
            this.SetDB(manager);
            return manager.DeleteQCScoreSet(id);
        }

        public int InsertParam(Neusoft.HISFC.Object.File.DataFileParam fileParam)
        {
            Neusoft.HISFC.Management.EPR.DataFileParam manager = new Neusoft.HISFC.Management.EPR.DataFileParam();
            this.SetDB(manager);
            return manager.Insert(fileParam);
        }

        public int UpdateParam(Neusoft.HISFC.Object.File.DataFileParam fileParam)
        {
            Neusoft.HISFC.Management.EPR.DataFileParam manager = new Neusoft.HISFC.Management.EPR.DataFileParam();
            this.SetDB(manager);
            return manager.Update(fileParam);
        }

        public System.Collections.ArrayList GetParamList()
        {
            Neusoft.HISFC.Management.EPR.DataFileParam manager = new Neusoft.HISFC.Management.EPR.DataFileParam();
            this.SetDB(manager);
            return manager.GetList();
        }




        public Neusoft.NFC.Object.NeuObject GetSign(string operID)
        {
            Neusoft.HISFC.Management.EPR.Sign manager = new Neusoft.HISFC.Management.EPR.Sign();
            this.SetDB(manager);
            return manager.GetSign(operID);
        }

        public int DeleteSign(string operID)
        {
            Neusoft.HISFC.Management.EPR.Sign manager = new Neusoft.HISFC.Management.EPR.Sign();
            this.SetDB(manager);
            return manager.DeleteSign(operID);
        }

        public System.Collections.ArrayList GetSignList()
        {
            Neusoft.HISFC.Management.EPR.Sign manager = new Neusoft.HISFC.Management.EPR.Sign();
            this.SetDB(manager);
            return manager.GetSignList();
        }

        public System.Collections.ArrayList GetQCInputCondition()
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.GetQCInputCondition();
        }

        public System.Collections.ArrayList GetQCInputCondition(string inpatientNo)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.GetQCInputCondition(inpatientNo);
        }



        public int SetQCScoreSet(Neusoft.HISFC.Object.EPR.QCScore qcScoreSet)
        {
            Neusoft.HISFC.Management.EPR.QCScore manager = new Neusoft.HISFC.Management.EPR.QCScore();
            this.SetDB(manager);
            return manager.SetQCScoreSet(qcScoreSet);
        }




        public System.Collections.ArrayList GetSNOMED(string id, bool isAll)
        {
            Neusoft.HISFC.Management.EPR.SNOMED manager = new Neusoft.HISFC.Management.EPR.SNOMED();
            this.SetDB(manager);
            return manager.GetSNOPMED(id, isAll);
        }

        public System.Collections.ArrayList GetSNOMED()
        {
            Neusoft.HISFC.Management.EPR.SNOMED manager = new Neusoft.HISFC.Management.EPR.SNOMED();
            this.SetDB(manager);
            return manager.GetSNOPMED();
        }

        public int UpdateSNOMED(Neusoft.HISFC.Object.EPR.SNOMED s)
        {
            Neusoft.HISFC.Management.EPR.SNOMED manager = new Neusoft.HISFC.Management.EPR.SNOMED();
            this.SetDB(manager);
            return manager.UpdateSNOPMED(s);
        }

        public int UpdateSNOPMEDParentCode(Neusoft.HISFC.Object.EPR.SNOMED s)
        {
            Neusoft.HISFC.Management.EPR.SNOMED manager = new Neusoft.HISFC.Management.EPR.SNOMED();
            this.SetDB(manager);
            return manager.UpdateSNOPMEDParentCode(s);
        }

        public int DelSNOPMEDByCode(string code)
        {
            Neusoft.HISFC.Management.EPR.SNOMED manager = new Neusoft.HISFC.Management.EPR.SNOMED();
            this.SetDB(manager);
            return manager.DelSNOPMEDByCode(code);
        }

        public int DelSNOPMEDByPCode(string parentcode)
        {
            Neusoft.HISFC.Management.EPR.SNOMED manager = new Neusoft.HISFC.Management.EPR.SNOMED();
            this.SetDB(manager);
            return manager.DelSNOPMEDByPCode(parentcode);
        }

        public int InsertSNOMED(Neusoft.HISFC.Object.EPR.SNOMED s)
        {
            Neusoft.HISFC.Management.EPR.SNOMED manager = new Neusoft.HISFC.Management.EPR.SNOMED();
            this.SetDB(manager);
            return manager.InsertSNOMED(s);
        }

        public int SaveQCInputCondition(System.Collections.ArrayList al)
        {
            Neusoft.HISFC.Management.EPR.QC manager = new Neusoft.HISFC.Management.EPR.QC();
            this.SetDB(manager);
            return manager.SaveQCInputCondition(al);
        }




        public int SetPermission(Neusoft.HISFC.Object.Medical.Permission permission)
        {
            Neusoft.HISFC.Management.Medical.Permission manager = new Neusoft.HISFC.Management.Medical.Permission();
            this.SetDB(manager);
            return manager.SetPermission(permission);
        }

        public int DeletePermission(string id)
        {
            Neusoft.HISFC.Management.Medical.Permission manager = new Neusoft.HISFC.Management.Medical.Permission();
            this.SetDB(manager);
            return manager.DeletePermission(id);
        }

        public System.Collections.ArrayList GetPermissionList()
        {
            Neusoft.HISFC.Management.Medical.Permission manager = new Neusoft.HISFC.Management.Medical.Permission();
            this.SetDB(manager);
            return manager.GetPermissionList();
        }

        #endregion

        #region 消息管理
        public System.Collections.ArrayList QueryMessage(string oper)
        {
            Neusoft.HISFC.Management.EPR.Message messageManager = new Neusoft.HISFC.Management.EPR.Message();

            this.SetDB(messageManager);

            return messageManager.QueryMessage(oper);

        }

        public Neusoft.HISFC.Object.Base.Message QueryMessageById(string id)
        {
            Neusoft.HISFC.Management.EPR.Message messageManager = new Neusoft.HISFC.Management.EPR.Message();

            this.SetDB(messageManager);

            return messageManager.QueryMessageById(id);

        }

        public int InsertMessage(Neusoft.HISFC.Object.Base.Message message)
        {
            Neusoft.HISFC.Management.EPR.Message messageManager = new Neusoft.HISFC.Management.EPR.Message();

            this.SetDB(messageManager);

            return messageManager.InsertMessage(message);

        }
        public int UpdateMessage(Neusoft.HISFC.Object.Base.Message message)
        {
            Neusoft.HISFC.Management.EPR.Message messageManager = new Neusoft.HISFC.Management.EPR.Message();

            this.SetDB(messageManager);

            return messageManager.UpdateMessage(message);

        }

        public int DeleteMessage(string id)
        {
            Neusoft.HISFC.Management.EPR.Message messageManager = new Neusoft.HISFC.Management.EPR.Message();

            this.SetDB(messageManager);

            return messageManager.DeleteMessage(id);

        }
        public System.Collections.ArrayList QueryEmrId(string InpatientNo)
        {
            Neusoft.HISFC.Management.EPR.Message messageManager = new Neusoft.HISFC.Management.EPR.Message();

            this.SetDB(messageManager);

            return messageManager.QueryEmrId(InpatientNo);

        }
        public int UpdateMessage(int type,string eprid)
        {
            Neusoft.HISFC.Management.EPR.Message messageManager = new Neusoft.HISFC.Management.EPR.Message();

            this.SetDB(messageManager);

            return messageManager.UpdateMessage(type,eprid);

        }


        #endregion

        #region 基础科室
        /// <summary>
        /// 获得基础科室
        /// 虚拟科室
        /// </summary>
        /// <returns></returns>
        public System.Collections.ArrayList QueryBaseDepartment()
        {
            Neusoft.HISFC.Management.EPR.BaseDept manager = new Neusoft.HISFC.Management.EPR.BaseDept();
            this.SetDB(manager);
            return manager.QueryDepartment();
        }

        #endregion


        #region 电子病历通用配置
        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <returns>截至时间字符串，若为Error,则系统参数未设置</returns>
        public string GetControlArgument(string ctlID)
        {
            Neusoft.HISFC.Management.EPR.EMR emrManager = new Neusoft.HISFC.Management.EPR.EMR();

            this.SetDB(emrManager);

            return emrManager.GetControlArgument(ctlID);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public virtual int SaveSetting(Neusoft.NFC.Object.NeuObject obj, string xml)
        {
            string sqlInsert = "INSERT INTO emr_setting	(id,name,memo) VALUES('{0}','{1}','{2}')		";
            string sqlDelete = "delete emr_setting where id='{0}'";
            string update = string.Format("update emr_setting set xml=:a where id='{0}'", obj.ID);
            Neusoft.NFC.Management.DataBaseManger manager = new Neusoft.NFC.Management.DataBaseManger();
            this.SetDB(manager);
            manager.ExecNoQuery(sqlDelete, obj.ID);
            manager.ExecNoQuery(sqlInsert, obj.ID, obj.Name, obj.Memo);
            return manager.InputLong(update, xml);
        }

        /// <summary>
        /// 获得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual string GetSetting(string id)
        {
            string sql = "select xml from emr_setting where id='{0}'";
            sql = string.Format(sql, id);
            Neusoft.NFC.Management.DataBaseManger manager = new Neusoft.NFC.Management.DataBaseManger();
            this.SetDB(manager);
            return manager.ExecSqlReturnOne(sql);
        }
        #endregion

        #region 日程
        /// <summary>
        /// 查询全部日程
        /// </summary>
        /// <returns></returns>
        public System.Collections.ArrayList QueryCalendar()
        {
            Neusoft.HISFC.Management.EPR.Calendar calendarManager = new Neusoft.HISFC.Management.EPR.Calendar();

            this.SetDB(calendarManager);

            return calendarManager.QueryCalendar();

        }
        /// <summary>
        /// 增加日程
        /// </summary>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public int AddCalender(Neusoft.HISFC.Object.Base.Calendar calendar)
        {
            Neusoft.HISFC.Management.EPR.Calendar calendarManager = new Neusoft.HISFC.Management.EPR.Calendar();

            this.SetDB(calendarManager);

            return calendarManager.InsertCalendar(calendar);

        }
        public System.Collections.ArrayList QueryCalendar(DateTime dtBegin, DateTime dtEnd)
        {
            Neusoft.HISFC.Management.EPR.Calendar calendarManager = new Neusoft.HISFC.Management.EPR.Calendar();

            this.SetDB(calendarManager);

            return calendarManager.QueryCalendar(dtBegin, dtEnd);

        }
        public int DeleteCalendar(string id)
        {
            Neusoft.HISFC.Management.EPR.Calendar calendarManager = new Neusoft.HISFC.Management.EPR.Calendar();

            this.SetDB(calendarManager);

            return calendarManager.DeleteCalendar(id);

        }

        #endregion

        #region 护理记录
        public System.Collections.ArrayList QueryNurseSheetSettingList()
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.QueryNurseSheetSettingList();
        }

        public Neusoft.HISFC.Object.Base.Message QueryNurseSheetSettingByID(string ID)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.QueryNurseSheetSettingByID(ID);
        }


        public Neusoft.HISFC.Object.Base.Message QueryNurseSheetSettingByName(string Name)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.QueryNurseSheetSettingByName(Name);
        }

        public int InsertNurseSheetSetting(Neusoft.HISFC.Object.Base.Message obj)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.InsertNurseSheetSetting(obj);
        }


        public int DeleteNurseSheetSetting(string ID)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.DeleteNurseSheetSetting(ID);
        }

        public int UpdateNurseSheetSetting(Neusoft.HISFC.Object.Base.Message obj)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.UpdateNurseSheetSetting(obj);
        }

        public string GetXmlFromNurseSheetSetting(Neusoft.HISFC.Object.EPR.NurseSheetSetting obj)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.GetXmlFromNurseSheetSetting(obj);
        }

        public void SetNurseSheetingSetting(string strXml, Neusoft.HISFC.Object.EPR.NurseSheetSetting obj)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            nurseTendManager.SetNurseSheetingSetting(strXml, obj);
        }
        public ArrayList GetStringList(string strText, int maxCount, System.Drawing.Font font)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.GetStringList(strText, maxCount, font);
        }
        public System.Xml.XmlElement SetInnerText(Control panel, System.Xml.XmlDocument doc)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.SetInnerText(panel, doc);
        }
        public void GetInnerText(Control panel, string strInnerText)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            nurseTendManager.GetInnerText(panel, strInnerText);
        }
        public string GetString(string innerText, string sNode)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            return nurseTendManager.GetString(innerText, sNode);
        }
        #endregion

        #region 锁
        public bool IsEMRLocked(string patientid, string fileID, ref Neusoft.NFC.Object.NeuObject obj)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.IsEMRLocked(patientid, fileID, ref obj);
        }

        public int SetEMRLocked(Neusoft.HISFC.Object.File.DataFileInfo dfi, Neusoft.HISFC.Object.RADT.PatientInfo patient, Neusoft.NFC.Object.NeuObject obj, bool isLocked)//(Neusoft.HISFC.Object.RADT.PatientInfo patient, Neusoft.NFC.Object.NeuObject obj, bool isLocked)
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.SetEMRLocked(dfi, patient, obj, isLocked);
        }

        public System.Data.DataSet QueryEMRLocked()
        {
            Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
            this.SetDB(manager);
            return manager.QueryEMRLocked();
        }
        #endregion

        #region 书写规范


        public ArrayList QueryAllCatalog()
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.QueryAllCatalog();
        }

        public ArrayList QueryCatalogByDeptCode(string deptCode)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.QueryCatalogByDeptCode(deptCode);
        }

        public Neusoft.HISFC.Object.EPR.CaseWriteRule GetCatalogByID(string ruleId)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.GetCatalogByID(ruleId);
        }


        /// <summary>
        /// 通过目录名称得到某个目录
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryCatalogByName(string ruleName)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.QueryCatalogByName(ruleName);
        }

        public int DeleteRule(Neusoft.HISFC.Object.EPR.CaseWriteRule rule, bool deleteChildren)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.DeleteRule(rule, deleteChildren);
        }

        public int ModifyForDrag(Neusoft.HISFC.Object.EPR.CaseWriteRule rule, string newparent)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.ModifyForDrag(rule, newparent);
        }

        public int ModifyRule(Neusoft.HISFC.Object.EPR.CaseWriteRule rule)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.ModifyRule(rule);
        }

        public int InsertRule(Neusoft.HISFC.Object.EPR.CaseWriteRule rule)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.InsertRule(rule);
        }
        public Neusoft.HISFC.Object.EPR.CaseWriteRule GetRule(string id)
        {
            Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
            this.SetDB(cwrManager);
            return cwrManager.GetRule(id);
        }
        public void AdjustLineSpace(RichTextBox rc, double times)
        {
            Neusoft.HISFC.Management.EPR.NurseTend nurseTendManager = new Neusoft.HISFC.Management.EPR.NurseTend();

            this.SetDB(nurseTendManager);

            nurseTendManager.AdjustLineSpace(rc, times);
        }

        public string GetRuleSequence()
        {
            Neusoft.NFC.Management.DataBaseManger manager = new Neusoft.NFC.Management.DataBaseManger();
            this.SetDB(manager);

            return manager.GetSequence("EPR.CaseWriteRule.GetRuleCodeSequence");
        }
        #endregion

        #region 上级修改痕迹
        /// <summary>
        /// 保存上级修改痕迹
        /// </summary>
        /// <param name="supermark">权限实体</param>
        /// <param name="img">修改痕迹</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int SetSuperMark(Neusoft.NFC.Object.NeuObject supermark, byte[] img)
        {
            //保存
            Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();

            this.SetDB(supermarkManager);
            return supermarkManager.SetSuperMark(supermark, img);
        }
        /// <summary>
        /// 修改一条上级修改记录
        /// </summary>
        /// <returns></returns>
        public int UpdateSuperMark(Neusoft.NFC.Object.NeuObject supermark, byte[] img)
        {
            Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();

            this.SetDB(supermarkManager);
            return supermarkManager.UpdateSuperMark(supermark, img);
        }
        /// <summary>
        /// 删除一条上级修改记录
        /// </summary>
        /// <returns></returns>
        public int DeleteSuperMark(Neusoft.NFC.Object.NeuObject supermark, byte[] img)
        {
            Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();

            this.SetDB(supermarkManager);
            return supermarkManager.DeleteSuperMark(supermark, img);
        }
        /// <summary>
        /// 插入一条上级修改记录
        /// </summary>
        /// <returns></returns>
        public int InsertSuperMark(Neusoft.NFC.Object.NeuObject supermark, byte[] img)
        {
            Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();

            this.SetDB(supermarkManager);
            return supermarkManager.InsertSuperMark(supermark, img);
        }

        /// <summary>
        /// 获得上级修改痕迹
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Neusoft.NFC.Object.NeuObject GetSuperMark(Neusoft.NFC.Object.NeuObject obj)
        {
            Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();

            this.SetDB(supermarkManager);
            return supermarkManager.GetSuperMark(obj);
        }

        /// <summary>
        /// 获得上级修改痕迹
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] GetSuperMarkImage(Neusoft.NFC.Object.NeuObject obj)
        {
            Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();

            this.SetDB(supermarkManager);
            return supermarkManager.GetSuperMarkImage(obj);
        }
        #endregion 上级修改痕迹
        #region 打印页
        /// <summary>
        /// 保存打印页
        /// </summary>
        /// <param name="printPage">权限实体</param>
        /// <param name="img">修改痕迹</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int SetPrintPage(Neusoft.HISFC.Object.EPR.EPRPrintPage printPage, byte[] img)
        {
            //保存
            Neusoft.HISFC.Management.EPR.PrintPage printPageManager = new Neusoft.HISFC.Management.EPR.PrintPage();

            this.SetDB(printPageManager);
            return printPageManager.SetPrintPage(printPage, img);
        }
        /// <summary>
        /// 修改一条打印页
        /// </summary>
        /// <returns></returns>
        public int UpdatePrintPage(Neusoft.HISFC.Object.EPR.EPRPrintPage printPage, byte[] img)
        {
            Neusoft.HISFC.Management.EPR.PrintPage printPageManager = new Neusoft.HISFC.Management.EPR.PrintPage();

            this.SetDB(printPageManager);
            return printPageManager.UpdatePrintPage(printPage, img);
        }
        /// <summary>
        /// 删除一条打印页
        /// </summary>
        /// <returns></returns>
        public int DeletePrintPage(Neusoft.HISFC.Object.EPR.EPRPrintPage printPage, byte[] img)
        {
            Neusoft.HISFC.Management.EPR.PrintPage printPageManager = new Neusoft.HISFC.Management.EPR.PrintPage();

            this.SetDB(printPageManager);
            return printPageManager.DeletePrintPage(printPage, img);
        }
        /// <summary>
        /// 插入一条打印页
        /// </summary>
        /// <returns></returns>
        public int InsertPrintPage(Neusoft.HISFC.Object.EPR.EPRPrintPage printPage, byte[] img)
        {
            Neusoft.HISFC.Management.EPR.PrintPage printPageManager = new Neusoft.HISFC.Management.EPR.PrintPage();

            this.SetDB(printPageManager);
            return printPageManager.InsertPrintPage(printPage, img);
        }

        /// <summary>
        /// 获得打印页
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Object.EPR.EPRPrintPage GetPrintPage(Neusoft.HISFC.Object.EPR.EPRPrintPage obj)
        {
            Neusoft.HISFC.Management.EPR.PrintPage printPageManager = new Neusoft.HISFC.Management.EPR.PrintPage();

            this.SetDB(printPageManager);
            return printPageManager.GetPrintPage(obj);
        }

        /// <summary>
        /// 获得打印页
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ArrayList GetPrintPageList(Neusoft.HISFC.Object.EPR.EPRPrintPage obj)
        {
            Neusoft.HISFC.Management.EPR.PrintPage printPageManager = new Neusoft.HISFC.Management.EPR.PrintPage();

            this.SetDB(printPageManager);
            return printPageManager.GetPrintPageList(obj);
        }

        /// <summary>
        /// 获得打印页图片
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] GetPrintPageImage(Neusoft.HISFC.Object.EPR.EPRPrintPage obj)
        {
            Neusoft.HISFC.Management.EPR.PrintPage printPageManager = new Neusoft.HISFC.Management.EPR.PrintPage();

            this.SetDB(printPageManager);
            return printPageManager.GetPrintPageImage(obj);
        }

        #endregion 打印页

        #region 质控夜间统计
        /// <summary>
        /// 根据患者ID检索统计结果
        /// </summary>
        /// <param name="patientNo">患者ID</param>
        /// <returns>ArrayList 中每个Item为Neusoft.NFC.Object.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        public ArrayList QueryQCStatByPatientNO(string patientNO)
        {
            Neusoft.HISFC.Management.EPR.QCStat manager = new Neusoft.HISFC.Management.EPR.QCStat();
            this.SetDB(manager);
            return manager.QueryByPatienNo(patientNO);
        }
        /// <summary>
        /// 根据统计时间检索统计结果
        /// </summary>
        /// <param name="beginDate">统计时间起始时间</param>
        /// <param name="endDate">统计时间终止时间</param>
        /// <returns>ArrayList 中每个Item为Neusoft.NFC.Object.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        public ArrayList QueryQCStatByStatDate(DateTime beginDate,DateTime endDate)
        {
            Neusoft.HISFC.Management.EPR.QCStat manager = new Neusoft.HISFC.Management.EPR.QCStat();
            this.SetDB(manager);
            return manager.QueryByStatDate(beginDate,endDate);
        }
        /// <summary>
        /// 根据患者入院时间检索统计结果
        /// </summary>
        /// <param name="beginDate">患者入院时间起始时间</param>
        /// <param name="endDate">患者入院时间终止时间</param>
        /// <returns>ArrayList 中每个Item为Neusoft.NFC.Object.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        public ArrayList QueryQCStatByInDate(DateTime beginDate, DateTime endDate)
        {
            Neusoft.HISFC.Management.EPR.QCStat manager = new Neusoft.HISFC.Management.EPR.QCStat();
            this.SetDB(manager);
            return  manager.QueryByInDate(beginDate, endDate);
        }
        /// <summary>
        /// 插入统计结果
        /// </summary>
        /// <param name="result">Neusoft.NFC.Object.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</param>
        /// <returns></returns>
        public int InsertQCStat(Neusoft.NFC.Object.NeuObject result)
        {
            Neusoft.HISFC.Management.EPR.QCStat manager = new Neusoft.HISFC.Management.EPR.QCStat();
            this.SetDB(manager);
            return manager.Insert(result);
        }
        /// <summary>
        /// 删除不是今年统计结果
        /// </summary>
        /// <returns></returns>
        public int DeleteQCStat()
        {
            Neusoft.HISFC.Management.EPR.QCStat manager = new Neusoft.HISFC.Management.EPR.QCStat();
            this.SetDB(manager);
            return manager.Delete();
        }
        #endregion
    }
}
