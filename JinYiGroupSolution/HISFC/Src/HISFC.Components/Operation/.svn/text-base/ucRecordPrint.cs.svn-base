using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Object.Operation;
using Neusoft.NFC.Object;

namespace UFC.Operation
{
    /// <summary>
    /// [功能描述: 手术登记打印控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-08]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRecordPrint : UserControl ,Neusoft.HISFC.Integrate.Operation.IRecordFormPrint
    {
        public ucRecordPrint()
        {
            InitializeComponent();
        }

#region 字段
        Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
#endregion

#region IRecordFormPrint 成员

        public Neusoft.HISFC.Object.Operation.OperationRecord OperationRecord
        {
            set 
            {
                OperationRecord operationRecord = value;
                if (operationRecord == null) 
                    return;
                OperationAppllication thisOpsApp = operationRecord.OperationAppllication;
                
                //患者类别
                NeuObject kind = Environment.GetPayKind(thisOpsApp.PatientInfo.Pact.PayKind.ID);
                if (kind == null)
                    this.lbPatientType.Text = thisOpsApp.PatientInfo.Pact.PayKind.ID;
                else
                    this.lbPatientType.Text = kind.Name;
                
                switch (thisOpsApp.TableType)
                {
                    case "1":
                        this.lbConsoleType.Text = "正台";
                        break;
                    case "2":
                        this.lbConsoleType.Text = "加台";
                        break;
                    case "3":
                        this.lbConsoleType.Text = "点台";
                        break;
                }
                //手术类别
                switch (thisOpsApp.OperateKind)
                {
                    case "1":
                        this.lbOpsKind.Text = "择期";
                        break;
                    case "2":
                        this.lbOpsKind.Text = "急诊";
                        break;
                    case "3":
                        this.lbOpsKind.Text = "感染";
                        break;
                }

                this.lbOpsDate.Text = operationRecord.OpsDate.ToString();					//手术日期
                this.lbOpsRoom.Text = thisOpsApp.OperateRoom.Name;						//手术室
                this.lbInPatientNo.Text = thisOpsApp.PatientInfo.PID.ID.ToString();	//住院号
                this.lbName.Text = thisOpsApp.PatientInfo.Name;					//姓名
                this.lbSex.Text = thisOpsApp.PatientInfo.Sex.Name;				//性别
                //年龄				
                int year = System.DateTime.Today.Year;//当前年
                int birthYear = thisOpsApp.PatientInfo.Birthday.Year;//出生年
                int age = year - birthYear;
                this.lbAge.Text = age.ToString();									//年龄
                //科室
                if (thisOpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID != "")
                {
                    Neusoft.HISFC.Object.Base.Department dept = null;
                    Neusoft.HISFC.Management.Manager.Department deptMgr = new Neusoft.HISFC.Management.Manager.Department();
                    dept = deptMgr.GetDeptmentById(thisOpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID);
                    if (dept != null) 
                        this.lbDept.Text = dept.Name;
                }

                // TODO: 添加术前诊断
                //术前诊断
                //string strDiagnoses = "";
                //foreach (neusoft.HISFC.Object.Case.DiagnoseBase myDiagnose in thisOpsApp.DiagnoseAl)
                //{
                //    //组合各诊断名为一个字符串
                //    if (strDiagnoses != "")
                //        strDiagnoses = strDiagnoses + " / ";
                //    strDiagnoses = strDiagnoses + myDiagnose.Name;
                //}
                //this.lbDiagnose.Text = strDiagnoses;									//术前诊断
                //手术项目
                string strItemName = "";
                foreach (OperationInfo myOpsInfo in thisOpsApp.OperationInfos)
                {
                    if (myOpsInfo.IsMainFlag)
                    {
                        //找到主手术则只显示主手术
                        strItemName = myOpsInfo.OperationItem.Name;
                        break;
                    }
                    //否则，组合各手术名为一个字符串
                    if (strItemName != "")
                        strItemName = strItemName + " / ";
                    strItemName = strItemName + myOpsInfo.OperationItem.Name;
                }

                this.lbItemName.Text = strItemName;										//手术项目（手术名称）
                this.lbAnaeType.Text = thisOpsApp.AnesType.Name;						//麻醉类型
                this.lbOpsDoct.Text = thisOpsApp.OperationDoctor.Name;							//手术医师
                Neusoft.NFC.Object.NeuObject obj = new Neusoft.NFC.Object.NeuObject();
                for (int i = 0; i < thisOpsApp.HelperAl.Count; i++)
                {
                    obj = (Neusoft.NFC.Object.NeuObject)(thisOpsApp.HelperAl[i]);
                    switch (i)
                    {
                        case 0:
                            this.lbHelp1.Text = obj.Name;											//一助手
                            break;
                        case 1:
                            this.lbHelp2.Text = obj.Name;											//二助手
                            break;
                        case 2:
                            this.lbHelp3.Text = obj.Name;											//三助手
                            break;
                    }
                }

                this.lbRemark.Text = operationRecord.Memo;								//申请说明
                this.lbApplyDoct.Text = thisOpsApp.ApplyDoctor.Name;						//申请医师
                this.lbBedNo.Text = thisOpsApp.PatientInfo.PVisit.PatientLocation.Bed.ID.ToString();//床号

                string strAccoNurs = "";//随台护士
                string strPrepNurs = "";//巡回护士
                foreach (ArrangeRole thisRole in thisOpsApp.RoleAl)
                {
                    if (thisRole.RoleType.ID.ToString() == EnumOperationRole.WashingHandNurse.ToString())//随台护士
                    {
                        if (strAccoNurs != "")
                            strAccoNurs = strAccoNurs + "/";
                        strAccoNurs = strAccoNurs + thisRole.Name;
                    }
                    if (thisRole.RoleType.ID.ToString() == EnumOperationRole.ItinerantNurse.ToString())//巡回护士
                    {
                        if (strPrepNurs != "")
                            strPrepNurs = strPrepNurs + "/";
                        strPrepNurs = strPrepNurs + thisRole.Name;
                    }
                }
                this.lbAcco.Text = strAccoNurs;
                this.lbPrep.Text = strPrepNurs;
            }
        }

        #endregion

        #region IReportPrinter 成员

        public int Print()
        {
            return this.print.PrintPreview(this);
        }

        public int PrintPreview()
        {
            return this.print.PrintPreview(this);
        }

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
