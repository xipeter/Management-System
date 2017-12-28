using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.WinForms.Report.Operation
{
    /// <summary>
    /// [功能描述: 手术安排通知单打印控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-04]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucArrangeNotifyPrint : UserControl, Neusoft.HISFC.BizProcess.Interface.Operation.IArrangeNotifyFormPrint
    {
        /// <summary>
        /// [功能描述: 手术安排打印]<br></br>
        /// [创 建 者: 王铁全]<br></br>
        /// [创建时间: 2007-01-04]<br></br>
        /// <修改记录
        ///		修改人=''
        ///		修改时间='yyyy-mm-dd'
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucArrangeNotifyPrint()
        {
            InitializeComponent();
            if(!Environment.DesignMode)
            {
                this.Init();
            }
        }

#region 字段

        Neusoft.HISFC.BizLogic.Manager.Constant constManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
        Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

#endregion

#region 属性

#endregion

#region 方法

        private void Init()
        {
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
        }


#endregion

        #region IApplicationFormPrint 成员

        /// <summary>
        /// 手术申请单对象
        /// </summary>
        public Neusoft.HISFC.Models.Operation.OperationAppllication OperationApplicationForm
        {
            set 
            {
                Neusoft.HISFC.Models.Operation.OperationAppllication thisOpsApp = value;
                if (thisOpsApp == null) 
                    return;
                this.a0.Text = "手术室：";
                this.a1.Text = string.Empty;
                this.a2.Text = string.Empty;
                this.a3.Text = string.Empty;
                this.a4.Text = string.Empty;
                this.a5.Text = string.Empty;

                this.a6.Text = string.Empty;
                this.a7.Text = string.Empty;
                this.a8.Text = string.Empty;
                this.a9.Text = string.Empty;
                this.a10.Text = string.Empty;

                this.a11.Text = string.Empty;
                this.a12.Text = string.Empty;
                this.a13.Text = string.Empty;
                this.a14.Text = string.Empty;
                this.a15.Text = string.Empty;

                this.a16.Text = string.Empty;
                this.a17.Text = string.Empty;
                this.a18.Text = string.Empty;
                this.a19.Text = string.Empty;
                this.a20.Text = string.Empty;
                
                
                this.b1.Text = string.Empty;
                this.b2.Text = string.Empty;
                this.b3.Text = string.Empty;
                this.b4.Text = string.Empty;
                this.b5.Text = string.Empty;

                this.b6.Text = string.Empty;
                this.b7.Text = string.Empty;
                this.b8.Text = string.Empty;
                this.b9.Text = string.Empty;
                this.b10.Text = string.Empty;

                this.b11.Text = string.Empty;
                this.b12.Text = string.Empty;
                this.b13.Text = string.Empty;
                this.b14.Text = string.Empty;
                this.b15.Text = string.Empty;

                this.b16.Text = string.Empty;
                this.b17.Text = string.Empty;

                this.a0.Text = string.Format("手术室：{0}",thisOpsApp.ExeDept.Name);

                //手术日期
                this.a1.Text = thisOpsApp.PreDate.ToString();
                this.b13.Text = thisOpsApp.PreDate.ToString("yyyy-MM-dd");					
                this.b15.Text = thisOpsApp.PreDate.ToString("HH:mm");

                //科室
                this.a2.Text = thisOpsApp.PatientInfo.PVisit.PatientLocation.Dept.Name;
                this.b1.Text = thisOpsApp.PatientInfo.PVisit.PatientLocation.Dept.Name;

                //姓名
                this.a3.Text = thisOpsApp.PatientInfo.Name;
                this.b2.Text = thisOpsApp.PatientInfo.Name;		

                //年龄				
                //int li_thisYear = this.constManager.GetDateTimeFromSysDateTime().Year;//当前年
                //int li_BirYear = thisOpsApp.PatientInfo.Birthday.Year;//出生年
                //int li_age = li_thisYear - li_BirYear;
                //if (li_age == 0) li_age = 1;
                //this.a4.Text = li_age.ToString();
                //this.b3.Text = li_age.ToString();

                this.a4.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(thisOpsApp.PatientInfo.Birthday);
                this.b3.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(thisOpsApp.PatientInfo.Birthday);

                //性别
                this.a5.Text = thisOpsApp.PatientInfo.Sex.Name;
                this.b4.Text = thisOpsApp.PatientInfo.Sex.Name;

                //病房
                this.a6.Text = thisOpsApp.OpsTable.Name;
                this.b5.Text = thisOpsApp.OpsTable.Name;

                //床号
                this.a7.Text = thisOpsApp.PatientInfo.PVisit.PatientLocation.Bed.Name;
                this.b6.Text = thisOpsApp.PatientInfo.PVisit.PatientLocation.Bed.Name;

                //住院号
                this.a8.Text = thisOpsApp.PatientInfo.PID.PatientNO;
                this.b7.Text = thisOpsApp.PatientInfo.PID.PatientNO;
                
                #region 诊断
                //this.lbDiagnose.Text = thisOpsApp.DiagnoseAl[0].ToString();

                StringBuilder diagnose = new StringBuilder();

                for (int i = 0; i < thisOpsApp.DiagnoseAl.Count; i++)
                {

                    diagnose.Append(thisOpsApp.DiagnoseAl[i].ToString()+"；");
                }

                this.a9.Text = diagnose.ToString();
                this.b8.Text = diagnose.ToString();
                
                #endregion


                this.b9.Text = thisOpsApp.AneNote;

                #region 手术项目

                //this.lbItemName.Text = thisOpsApp.MainOperationName;//手术项目

                StringBuilder opitem = new StringBuilder();
                foreach (Neusoft.HISFC.Models.Operation.OperationInfo myOpsInfo in thisOpsApp.OperationInfos)
                {
                    opitem.Append(myOpsInfo.OperationItem.Name+"；");
                }

                this.a11.Text = opitem.ToString();
                this.b10.Text = opitem.ToString();

                #endregion
                
                
                //手术医师
                this.a10.Text = thisOpsApp.OperationDoctor.Name;
                this.b14.Text = thisOpsApp.OperationDoctor.Name;		

                //特殊手术
                this.a14.Text = thisOpsApp.SpecialItem;

                //麻醉方式
                NeuObject obj = new NeuObject();
                if ( !string.IsNullOrEmpty( thisOpsApp.AnesWay))//.ID != null && thisOpsApp.AnesType.ID != "")
                {
                    obj = this.constManager.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ANESWAY, thisOpsApp.AnesWay);
                    if (obj != null)
                    {
                        this.a16.Text = obj.Name;
                        this.b12.Text = obj.Name;
                    }
                }

                					

                for (int i = 1; i < thisOpsApp.RoleAl.Count; i++)
                {
                    obj = (NeuObject)(thisOpsApp.RoleAl[i]);
                    switch (i)
                    {
                        case 1:
                            this.a12.Text = obj.Name;											//一助手
                            break;
                        case 2:
                            this.a13.Text = obj.Name;											//二助手
                            break;
                        case 3:
                            this.a15.Text = obj.Name;											//三助手
                            break;
                    }
                }
                
                //this.lbOpsNote.Text = thisOpsApp.OpsNote;								//手术注意事项
                
                //申请医师
                this.a18.Text = thisOpsApp.ApplyDoctor.Name;
                this.b16.Text = thisOpsApp.ApplyDoctor.Name;
	
                //申请时间
                this.a19.Text = thisOpsApp.ApplyDate.ToString();
                this.b17.Text = thisOpsApp.ApplyDate.ToString();


                //特殊用具
                this.a20.Text = thisOpsApp.ApplyNote.Trim();
                this.b18.Text = thisOpsApp.ApplyNote.Trim();

                //////是否需要器械护士
                //if (thisOpsApp.IsAccoNurse == true)
                //{
                //    this.lbIsAccoNurse.Text = "■是□否";
                //}
                //else
                //{
                //    this.lbIsAccoNurse.Text = "□是■否";
                //}

                ////是否需要巡回护士
                //if (thisOpsApp.IsPrepNurse == true)
                //{
                //    this.lbIsPrepNurse.Text = "■是□否";
                //}
                //else
                //{
                //    this.lbIsPrepNurse.Text = "□是■否";
                //}


               
			
            }
        }


        #endregion

        #region IReportPrinter 成员

        public int Export()
        {
            return 0;
        }

        public int Print()
        {
            #region MyRegion郑大更新--{CF9C3E37-1B84-48c6-BBE8-DAEF847B7BAC}
            this.print.PrintPage(60, 40, this); //this.print.PrintPage(0, 0, this); 
            #endregion
            return 0;
        }

        public int PrintPreview()
        {
            this.print.PrintPreview(this);
            return 0;
        }

        #endregion

        #region IArrangeFormPrint 成员

        private bool isPrintExTable;
        /// <summary>
        /// 是否打印手术加台申请表
        /// </summary>
        public bool IsPrintExtendTable
        {
            set
            {
                this.isPrintExTable = value;
            }
        }

        #endregion


    }
}
