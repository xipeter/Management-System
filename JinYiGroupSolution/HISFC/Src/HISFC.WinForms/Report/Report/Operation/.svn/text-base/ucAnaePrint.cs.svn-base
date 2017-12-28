using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;
using Neusoft.FrameWork.Models;

namespace Neusoft.WinForms.Report.Operation
{
    public partial class ucAnaePrint : UserControl, Neusoft.HISFC.BizProcess.Interface.Operation.IAnaeFormPrint
    {
        public ucAnaePrint()
        {
            InitializeComponent();
        }

        #region 字段
        Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
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


        #region IAnaeFormPrint 成员

        AnaeRecord Neusoft.HISFC.BizProcess.Interface.Operation.IAnaeFormPrint.AnaeRecord
        {
            set
            {
                AnaeRecord anaeRecord = value;
                if (anaeRecord == null)
                {
                    return;
                }
                OperationAppllication thisOpsApp = anaeRecord.OperationApplication;          

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
                
                //this.lbOpsDate.Text = anaeRecord.OpsDate.ToString();					//手术日期
                this.lbOpsRoom.Text = thisOpsApp.OperateRoom.Name;						//手术室
                this.lbInPatientNo.Text = thisOpsApp.PatientInfo.PID.ID.ToString();	//住院号
                this.lbName.Text = thisOpsApp.PatientInfo.Name;					//姓名
                this.lbSex.Text = thisOpsApp.PatientInfo.Sex.Name;				//性别
                //年龄				
                int year = System.DateTime.Today.Year;//当前年
                int birthYear = thisOpsApp.PatientInfo.Birthday.Year;//出生年
                int age = year - birthYear;
                this.lbAge.Text = age.ToString();

               

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
                this.lbAnaeType.Text = thisOpsApp.AnesType.Name;                        //麻醉方式
               // this.lbAnaerName.Text = thisOpsApp                                     //麻醉者
                this.lbAnaeTime.Text = anaeRecord.AnaeDate.ToString();                  //麻醉时间
                if (anaeRecord.IsPACU == true)                                          //有/无PACU
                {
                    this.lbPACU.Text = "有";
                }
                else
                {
                    this.lbPACU.Text = "无";
                }
                this.lbInTime.Text = anaeRecord.InPacuDate.ToString();                  //入室时间
                this.lbInState.Text = anaeRecord.InPacuStatus.ToString();
                this.lbOutTime.Text = anaeRecord.OutPacuDate.ToString();
                this.lbOutState.Text = anaeRecord.OutPacuStatus.ToString();

                if (anaeRecord.IsDemulcent == true)                                          //有/无 术后镇痛
                {
                    this.lbIsDemulcent.Text = "有";
                }
                else
                {
                    this.lbIsDemulcent.Text = "无";
                }

                this.lbDemuKind.Text = anaeRecord.DemulcentType.Name.ToString();
                this.lbDemuModel.Text = anaeRecord.DemulcentModel.Name.ToString();
                this.lbDemuDays.Text = anaeRecord.DemulcentDays.ToString();
                this.lbPullOutDate.Text = anaeRecord.PullOutDate.ToString();
                this.lbPullOutOpcd.Text = anaeRecord.PullOutOperator.Name;
                this.lbDemuResult.Text = anaeRecord.DemulcentEffect.Name;

                this.lbAnaerName.Text = "";
                for (int i = 0; i < anaeRecord.OperationApplication.RoleAl.Count; i++)
                {              
                    this.lbAnaerName.Text += anaeRecord.OperationApplication.RoleAl[i].ToString() + " ";                    
                }   
            }            
        }

        #endregion
        }
}
