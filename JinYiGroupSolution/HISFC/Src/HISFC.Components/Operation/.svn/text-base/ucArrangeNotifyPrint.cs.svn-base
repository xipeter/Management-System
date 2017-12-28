using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Object;
using Neusoft.HISFC.Object.Operation;

namespace UFC.Operation
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
    public partial class ucArrangeNotifyPrint : UserControl, Neusoft.HISFC.Integrate.Operation.IArrangeNotifyFormPrint
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

        Neusoft.HISFC.Management.Manager.Constant constManager = new Neusoft.HISFC.Management.Manager.Constant();
        Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();

#endregion

#region 属性

#endregion

#region 方法

        private void Init()
        {
            print.ControlBorder = Neusoft.NFC.Interface.Classes.enuControlBorder.None;
        }


#endregion

        #region IApplicationFormPrint 成员

        /// <summary>
        /// 手术申请单对象
        /// </summary>
        public Neusoft.HISFC.Object.Operation.OperationAppllication OperationApplicationForm
        {
            set 
            {
                Neusoft.HISFC.Object.Operation.OperationAppllication thisOpsApp = value;
                if (thisOpsApp == null) return;
                
                NeuObject kind = this.constManager.GetConstant(Neusoft.HISFC.Object.Base.EnumConstant.PAYKIND, thisOpsApp.PatientInfo.Pact.PayKind.ID);
                if (kind == null)
                    this.lbPatientType.Text = thisOpsApp.PatientInfo.Pact.PayKind.ID;
                else
                    this.lbPatientType.Text = kind.Name;

                //显示特殊手术

                this.lbOpSpecial.Text = "特殊手术:" + thisOpsApp.SpecialItem;

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

                this.lbOrder.Text = thisOpsApp.BloodUnit;									//台序
                this.lbOpsDate.Text = thisOpsApp.PreDate.ToString();					//手术日期
                this.lbOpsRoom.Text = thisOpsApp.OperateRoom.Name;						//手术室
                this.lbInPatientNo.Text = thisOpsApp.PatientInfo.PID.PatientNO;	//住院号
                this.PatientNO.Text = thisOpsApp.PatientInfo.PID.PatientNO;
                this.lbName.Text = thisOpsApp.PatientInfo.Name;					//姓名
                this.PatientName.Text = thisOpsApp.PatientInfo.Name;
                this.lbSex.Text = thisOpsApp.PatientInfo.Sex.Name;				//性别
                SexType.Text = thisOpsApp.PatientInfo.Sex.Name;
                //年龄				
                int li_thisYear = this.constManager.GetDateTimeFromSysDateTime().Year;//当前年
                int li_BirYear = thisOpsApp.PatientInfo.Birthday.Year;//出生年
                int li_age = li_thisYear - li_BirYear;
                if (li_age == 0) li_age = 1;
                this.lbAge.Text = li_age.ToString();									//年龄
                Age.Text = this.lbAge.Text;
                this.deptName.Text = thisOpsApp.PatientInfo.PVisit.PatientLocation.Dept.Name;
                string BedNO = "";
                if (thisOpsApp.PatientInfo.PVisit.PatientLocation.Bed.ID.Length >= 7)
                {
                    BedNO = thisOpsApp.PatientInfo.PVisit.PatientLocation.Bed.ID.Substring(4);
                }
                this.lbDept.Text = thisOpsApp.PatientInfo.PVisit.PatientLocation.Dept.Name + BedNO + "床";//科室
                
                // TODO: 诊断未实现
                #region 诊断
                //术前诊断
                //				string strDiagnoses = "";
                //int m = 0;
                //foreach (neusoft.HISFC.Object.Case.DiagnoseBase myDiagnose in thisOpsApp.DiagnoseAl)
                //{
                //    if (m == 0)
                //    {
                //        this.lbDiagnose.Text = myDiagnose.Name;
                //    }
                //    else if (m == 1)
                //    {
                //        this.lbDiagnose2.Text = myDiagnose.Name;
                //    }
                //    else if (m == 2)
                //    {
                //        this.lbDiagnose3.Text = myDiagnose.Name;
                //    }
                //    m++;
                //    //					//组合各诊断名为一个字符串
                //    //					if (strDiagnoses != "")
                //    //						strDiagnoses = strDiagnoses + " / ";
                //    //					strDiagnoses = strDiagnoses + myDiagnose.Name;
                //    //						this.lbDiagnose.Text = strDiagnoses;	
                //}
                ////术前诊断
                ////手术项目
                ////				string strItemName = "";
                //int j = 0;
                //foreach (neusoft.HISFC.Object.Operator.OperateInfo myOpsInfo in thisOpsApp.OperateInfoAl)
                //{

                //    if (j == 0)
                //    {
                //        this.lbItemName.Text = myOpsInfo.OperateItem.Name;
                //        lbOperationName.Text = myOpsInfo.OperateItem.Name;
                //    }
                //    else if (j == 1)
                //    {
                //        this.lbItemName2.Text = myOpsInfo.OperateItem.Name;
                //    }
                //    else if (j == 2)
                //    {
                //        this.lbItemName3.Text = myOpsInfo.OperateItem.Name;
                //    }
                //    j++;
                //    //					if(myOpsInfo.bMainFlag)
                //    //					{
                //    //						//找到主手术则只显示主手术
                //    //						strItemName = myOpsInfo.OperateItem.Name;
                //    //						break;
                //    //					}
                //    //					//否则，组合各手术名为一个字符串
                //    //					if(strItemName != "")
                //    //						strItemName = strItemName + " / ";
                //    //					strItemName = strItemName + myOpsInfo.OperateItem.Name;
                //}
                #endregion

                //手术项目（手术名称）

                NeuObject obj = new NeuObject();
                if (thisOpsApp.AnesType.ID != null && thisOpsApp.AnesType.ID != "")
                {
                    obj = this.constManager.GetConstant(Neusoft.HISFC.Object.Base.EnumConstant.ANESTYPE,
                        thisOpsApp.AnesType.ID);
                    if (obj != null)
                    {
                        this.lbAnaeType.Text = obj.Name;
                    }
                }

                this.lbOpsDoct.Text = thisOpsApp.OperationDoctor.Name;							//手术医师

                for (int i = 0; i < thisOpsApp.HelperAl.Count; i++)
                {
                    obj = (NeuObject)(thisOpsApp.HelperAl[i]);
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
                this.lbOpsNote.Text = thisOpsApp.OpsNote;								//手术注意事项
                this.lbApplyDoct.Text = thisOpsApp.ApplyDoctor.Name;						//申请医师

                if (thisOpsApp.RoleAl != null)
                {
                    foreach (Neusoft.HISFC.Object.Operation.ArrangeRole role in thisOpsApp.RoleAl)
                    {
                        if (role.RoleType.ID.ToString() == EnumOperationRole.WashingHandNurse.ToString())
                            //洗手护士
                        {
                            if (lbIfQX2.Text == "")
                            {
                                this.lbIfQX2.Text = role.Name;
                            }
                            else
                            {
                                if (lbIfQX3.Text == "")
                                {
                                    lbIfQX3.Text = role.Name;
                                }
                                else
                                {
                                    lbIfQX.Text = role.Name;
                                }
                            }

                        }
                        else if (role.RoleType.ID.ToString() == EnumOperationRole.ItinerantNurse.ToString())
                            //巡回护士
                        {
                            if (lbIfXH2.Text == "")
                            {
                                this.lbIfXH2.Text = role.Name;
                            }
                            else
                            {
                                if (this.lbIfXH3.Text == "")
                                {
                                    this.lbIfXH3.Text = role.Name;
                                }
                                else
                                {
                                    this.lbIfXH.Text = role.Name;
                                }
                            }
                        }
                    }
                }
                lbOpsNote.Text = thisOpsApp.ApplyNote;
                this.lbBedNo.Text = thisOpsApp.OpsTable.Name;//房号
                //				neusoft.HISFC.Management.Operator.OpsTableManage roomMgr=new neusoft.HISFC.Management.Operator.OpsTableManage();
                //				if(thisOpsApp.RoomID!=null&&thisOpsApp.RoomID!="")
                //				{
                //					neusoft.HISFC.Object.Operator.OpsRoom room=roomMgr.GetRoomByID(thisOpsApp.RoomID);
                //					if(room!=null)
                //					{
                //						this.lbBedNo.Text=room.Name + thisOpsApp.OpsTable.Name;//房号
                //						
                //					}
                //				}				
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
            //this.print.PrintPage(0,0,this);
            return 0;
        }

        public int PrintPreview()
        {
            this.print.PrintPreview(this);
            return 0;
        }

        #endregion

        #region IArrangeFormPrint 成员

        /// <summary>
        /// 是否打印手术加台申请表
        /// </summary>
        public bool IsPrintExtendTable
        {
            set
            {
                label16.Visible = value;
                label15.Visible = value;
                label14.Visible = value;
                label3.Visible = value;
                label4.Visible = value;
                label5.Visible = value;
                label6.Visible = value;
                label7.Visible = value;
                label8.Visible = value;
                label9.Visible = value;
                label10.Visible = value;
                label11.Visible = value;
                label12.Visible = value;
                label13.Visible = value;
                PatientName.Visible = value;
                SexType.Visible = value;
                Age.Visible = value;
                deptName.Visible = value;
                PatientNO.Visible = value;
                lbOperationName.Visible = value;
            }
        }

        #endregion
    }
}
