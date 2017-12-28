using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    /// <summary>
    /// DL.HealthRecord.ucDLCaseBackPrint
    /// [功能描述: 病案首页背面打印控件 ]<br></br>
    /// [创 建 者: 夏志辉]<br></br>
    /// [创建时间: 2008-09-03]<br></br>
    /// <修改记录
    ///		修改人='牛鑫元'
    ///		修改时间='2009-11-19'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucZhongRiCaseBackPrint : UserControl, Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterfaceBack
    {
        public ucZhongRiCaseBackPrint()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 打印业务层
        /// </summary>
        Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();

        //费用业务层
        Neusoft.HISFC.BizLogic.HealthRecord.Fee feeManager = new Neusoft.HISFC.BizLogic.HealthRecord.Fee();

        //手术业务层
        Neusoft.HISFC.BizLogic.HealthRecord.Operation operationManager = new Neusoft.HISFC.BizLogic.HealthRecord.Operation();

        //婴儿业务层
        Neusoft.HISFC.BizLogic.HealthRecord.Baby ba = new Neusoft.HISFC.BizLogic.HealthRecord.Baby();                   

        /// <summary>
        /// 常数管理
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 入出转管理
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntergate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        //private Neusoft.HISFC.Models.RADT.Location thirDept = null;
        /// <summary>
        /// 转科管理
        /// </summary>
        Neusoft.HISFC.BizLogic.HealthRecord.DeptShift deptChange = new Neusoft.HISFC.BizLogic.HealthRecord.DeptShift();
           
        /// <summary>
        /// 科室
        /// </summary>
        Hashtable hashICUdept = new Hashtable();

        Hashtable hashFeeControl = new Hashtable();
        Hashtable hashLableControl = new Hashtable();
        #endregion

        #region 方法

        

        public int Print()
        {
            //this.SetVisible(false);
            p.PrintPage(0, 0, this.neuPanel1);
            return 1;
        }

        public int PrintPreview()
        {
            //this.SetVisible(true);
            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            return p.PrintPreview(20, 10, this);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置打印时控件的可见性
        /// </summary>
        /// <param name="isSee"></param>
        private void SetVisible(bool isSee) 
        {
            foreach (Control c in this.neuPanel1.Controls)
            {
                if (c is Neusoft.FrameWork.WinForms.Controls.NeuLabel && !c.Name.StartsWith("lblPri"))
                {
                    c.Visible = isSee;
                }
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            foreach (Control c in this.neuPanel1.Controls)
            {
                if (c is Neusoft.FrameWork.WinForms.Controls.NeuLabel && c.Name.StartsWith("lblPri"))
                {
                    Neusoft.FrameWork.WinForms.Controls.NeuLabel lbl = c as Neusoft.FrameWork.WinForms.Controls.NeuLabel;
                    lbl.Text = " ";
                }
            }

        }

        /// <summary>
        /// 将费用控件添加的哈希表
        /// </summary>
        private void SetHashControl()
        {
            this.hashFeeControl.Clear();
            foreach (Control var in this.neuPanel1.Controls)
            {
                if (var.Name.Contains("fee") || var.Name.Contains("lbl"))
                {
                    this.hashFeeControl.Add(var.Name,var);
                }
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private Control GetControlByControlName(string controlName)
        {
            if (this.hashFeeControl.Contains(controlName))
            {
                return this.hashFeeControl[controlName] as Control;
            }
            else
            {
                return null;
            }
        }

        #endregion

        private void ucDLCaseBackPrint_Load(object sender, EventArgs e)
        {
            this.Reset();
            this.SetHashControl();
        }

        private void neuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void neuLabel11_Click(object sender, EventArgs e)
        {

        }

        private void neuLabel32_Click(object sender, EventArgs e)
        {

        }

        #region HealthRecordInterface 成员

        //public void ControlValue(Neusoft.HISFC.Models.HealthRecord.Base obj)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}
        /// <summary>
        /// 设置病案反面值
        /// </summary>
        void Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterfaceBack.ControlValue(Neusoft.HISFC.Models.HealthRecord.Base obj)
        {
            Neusoft.HISFC.Models.HealthRecord.Base healthReord = obj as Neusoft.HISFC.Models.HealthRecord.Base;

            this.SetHashControl();

            // add by lk 2008-09-12 婴儿信息赋值
            //#region 婴儿信息
            ////查询符合条件的数据  如果是一胞胎后面婴儿信息就不要显示
            //ArrayList list = ba.QueryBabyByInpatientNo(healthReord.PatientInfo.ID);
            //Neusoft.HISFC.Models.HealthRecord.Baby babyinfo = null;
            //if (list.Count > 0)
            //{
            //    for (int j = 0; j < list.Count; j++)
            //    {
            //        babyinfo = list[j] as Neusoft.HISFC.Models.HealthRecord.Baby;
            //        if (j == 0)
            //        {
            //            this.age.Text = babyinfo.Age.ToString(); //年龄 天
            //            this.outBodyWeight.Text = babyinfo.Weight.ToString();//出生时体重
            //            this.inBodyWeight.Text = babyinfo.WeightInHospital.ToString();//转院时体重

            //        }
            //        else if (j == 1)
            //        {
            //            this.age1.Text = babyinfo.Age.ToString(); //年龄 天
            //            this.outBodyWeight1.Text = babyinfo.Weight.ToString();//出生时体重
            //            this.inBodyWeight1.Text = babyinfo.WeightInHospital.ToString();//转院时体重

            //            this.txtage1.Visible = true;
            //            this.txtageunit1.Visible = true;
            //            this.txtweightunit1.Visible = true;
            //            this.txtweightunit2.Visible = true;
            //            this.age1.Visible = true;
            //            this.outBodyWeight1.Visible = true;
            //            this.inBodyWeight1.Visible = true;
            //            this.txtoutbaby1.Visible = true;
            //            this.txtinbaby1.Visible = true;
            //            this.neuLabel140.Visible = true;
            //            this.neuLabel47.Visible = true;
            //            this.neuLabel37.Visible = true;

            //        }
            //        else if (j == 2)
            //        {
            //            this.age2.Text = babyinfo.Age.ToString(); //年龄 天
            //            this.outBodyWeigh2.Text = babyinfo.Weight.ToString();//出生时体重

            //            this.inBodyWeight2.Text = babyinfo.WeightInHospital.ToString();//转院时体重

            //            this.txtageunit2.Visible = true;
            //            this.txtweightunit3.Visible = true;
            //            this.txtweightunit4.Visible = true;
            //            this.age2.Visible = true;
            //            this.outBodyWeigh2.Visible = true;
            //            this.inBodyWeight2.Visible = true;
            //            this.txtoutbaby2.Visible = true;
            //            this.txtinbaby2.Visible = true;
            //            this.neuLabel148.Visible = true;
            //            this.neuLabel166.Visible = true;
            //            this.neuLabel156.Visible = true;


            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //}
            //#endregion

            #region 手术信息

            ArrayList alOpr = operationManager.QueryOperationByInpatientNo(healthReord.PatientInfo.ID);

            int i = 1;

            foreach (object opr in alOpr)
            {
                Neusoft.HISFC.Models.HealthRecord.OperationDetail opration = opr as Neusoft.HISFC.Models.HealthRecord.OperationDetail;
                switch (i)
                {
                    case 1:
                        //编码
                        this.lblPriShoushuChaozuoBianma1.Text = opration.OperationInfo.ID;
                        //日期
                        this.lblPriChaozuoRiqi1.Text = opration.OperationDate.ToShortDateString();
                        //名称
                        this.lblPriChaozuoMingchen1.Text = opration.OperationInfo.Name;
                        //术者
                        this.lblPriChaozuoSuzhe1.Text = opration.FirDoctInfo.Name;
                        //一助
                        this.lblPriChaozuoYizu1.Text = opration.SecDoctInfo.Name;
                        //二助
                        this.lblPriChaozuoErzu1.Text = opration.ThrDoctInfo.Name;
                        //麻醉方式
                        this.lblPriChaozuoMazui1.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ANESTYPE, opration.MarcKind).Name;
                        //麻醉医师
                        this.lblPriChaozuoMazuiYishi1.Text = opration.NarcDoctInfo.Name;
                        //切口愈合等级
                        this.lblPriQiekouYuheDengji1.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.INCITYPE, opration.NickKind).Name + "/" + con.GetConstant("CICATYPE", opration.CicaKind);
                        i++;
                        break;
                    case 4:
                        //编码
                        this.lblPriShoushuChaozuoBianma4.Text = opration.OperationInfo.ID;
                        //日期
                        this.lblPriChaozuoRiqi4.Text = opration.OperationDate.ToShortDateString();
                        //名称
                        this.lblPriChaozuoMingchen4.Text = opration.OperationInfo.Name;
                        //术者
                        this.lblPriChaozuoSuzhe4.Text = opration.FirDoctInfo.Name;
                        //一助
                        this.lblPriChaozuoYizu4.Text = opration.SecDoctInfo.Name;
                        //二助
                        this.lblPriChaozuoErzu4.Text = opration.ThrDoctInfo.Name;
                        //麻醉方式
                        this.lblPriChaozuoMazui4.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ANESTYPE, opration.MarcKind).Name;
                        //麻醉医师
                        this.lblPriChaozuoMazuiYishi4.Text = opration.NarcDoctInfo.Name;
                        //切口愈合等级
                        this.lblPriQiekouYuheDengji4.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.INCITYPE, opration.NickKind).Name + "/" + con.GetConstant("CICATYPE", opration.CicaKind);
                        i++;
                        break;
                    case 2:
                        //编码
                        this.lblPriShoushuChaozuoBianma2.Text = opration.OperationInfo.ID;
                        //日期
                        this.lblPriChaozuoRiqi2.Text = opration.OperationDate.ToShortDateString();
                        //名称
                        this.lblPriChaozuoMingchen2.Text = opration.OperationInfo.Name;
                        //术者
                        this.lblPriChaozuoSuzhe2.Text = opration.FirDoctInfo.Name;
                        //一助
                        this.lblPriChaozuoYizu2.Text = opration.SecDoctInfo.Name;
                        //二助
                        this.lblPriChaozuoErzu2.Text = opration.ThrDoctInfo.Name;
                        //麻醉方式
                        this.lblPriChaozuoMazui2.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ANESTYPE, opration.MarcKind).Name;
                        //麻醉医师
                        this.lblPriChaozuoMazuiYishi2.Text = opration.NarcDoctInfo.Name;
                        //切口愈合等级
                        this.lblPriQiekouYuheDengji2.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.INCITYPE, opration.NickKind).Name + "/" + con.GetConstant("CICATYPE", opration.CicaKind);
                        i++;
                        break;
                    case 3:
                        //编码
                        this.lblPriShoushuChaozuoBianma3.Text = opration.OperationInfo.ID;
                        //日期
                        this.lblPriChaozuoRiqi3.Text = opration.OperationDate.ToShortDateString();
                        //名称
                        this.lblPriChaozuoMingchen3.Text = opration.OperationInfo.Name;
                        //术者
                        this.lblPriChaozuoSuzhe3.Text = opration.FirDoctInfo.Name;
                        //一助
                        this.lblPriChaozuoYizu3.Text = opration.SecDoctInfo.Name;
                        //二助
                        this.lblPriChaozuoErzu3.Text = opration.ThrDoctInfo.Name;
                        //麻醉方式
                        this.lblPriChaozuoMazui3.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ANESTYPE, opration.MarcKind).Name;
                        //麻醉医师
                        this.lblPriChaozuoMazuiYishi3.Text = opration.NarcDoctInfo.Name;
                        //切口愈合等级
                        this.lblPriQiekouYuheDengji3.Text = con.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.INCITYPE, opration.NickKind).Name + "/" + con.GetConstant("CICATYPE", opration.CicaKind);
                        i++;
                        break;
                    default:
                        break;
                }
                if (i > 4)
                {
                    break;
                }
            }

            #endregion

            #region 死亡信息

            if (healthReord.DeadDate != DateTime.MinValue)
            {

            }

            #endregion

            #region 费用信息

            //Modify by lk 2008-09-12 根据统计大类编码，显示金额  有时间也可以把统计大类名称也 ：）
            ArrayList alFee = feeManager.QueryFeeInfoState(healthReord.PatientInfo.ID);
            decimal totFee = 0.0M;
            foreach (Neusoft.HISFC.Models.RADT.Patient FeeObj in alFee)
            {
                ////Neusoft.HISFC.Models.RADT.Patient info = fee as Neusoft.HISFC.Models.RADT.Patient;
                //switch (patientinfo.ID)
                //{
                //    case "01":
                //        this.fee01.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "02":
                //        this.fee02.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "03":
                //        this.fee03.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "04":
                //        this.fee04.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "05":
                //        this.fee05.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "06":
                //        this.fee06.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "07":
                //        this.fee07.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "08":
                //        this.fee08.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "09":
                //        this.fee09.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "10":
                //        this.fee10.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "11":
                //        this.fee11.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "12":
                //        this.fee12.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "13":
                //        this.fee13.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "14":
                //        this.fee14.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "15":
                //        this.fee15.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "16":
                //        this.fee16.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "17":
                //        this.fee17.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "18":
                //        this.fee18.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "19":
                //        this.fee19.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "20":
                //        this.fee20.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "21":
                //        this.fee21.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "22":
                //        this.fee22.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "23":
                //        this.fee23.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "24":
                //        this.fee24.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "25":
                //        this.fee25.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "26":
                //        this.fee26.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "27":
                //        this.fee27.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "28":
                //        this.fee28.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "29":
                //        this.fee29.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    case "30":
                //        this.fee30.Text = patientinfo.User01;
                //        totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(patientinfo.User01);
                //        break;
                //    default:
                //        break;
                //}



                //this.lblPriZhuyuanFeiyongZongji.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(totFee, 2);

                Control control = this.GetControlByControlName("fee" + FeeObj.DIST);
                control.Text = FeeObj.User01;
                Control control1 = this.GetControlByControlName("lbl" + FeeObj.DIST);
                if (FeeObj.DIST == "17" || FeeObj.DIST == "18" || FeeObj.DIST == "19")
                {
                }
                else
                {
                //    control.Text = FeeObj.AreaCode;
                //}
                //totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(FeeObj.User01);
                    control1.Text = FeeObj.AreaCode;
                    control.Text = FeeObj.IDCard;
                }
                totFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(FeeObj.IDCard);
            }
            this.lblPriZhuyuanFeiyongZongji.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(totFee, 2);

            #endregion

            #region 尸检，手术治疗是否为第一例

            if (healthReord.CadaverCheck == "1")
            {
                this.lblPriShijian.Text = "1";
            }
            else
            {
                this.lblPriShijian.Text = "2";
            }
            if (healthReord.YnFirst == "1")
            {
                this.lblPriDiyili.Text = "1";
            }
            else
            {
                this.lblPriDiyili.Text = "2";
            }
            #endregion

            #region 随诊,示教病例

            if (healthReord.VisiStat == "1")
            {
                this.lblPriSuiZhen.Text = "1";
            }
            else
            {
                this.lblPriSuiZhen.Text = "2";
            }

            //随诊年月周
            this.lblPriSuizhenQixianNian.Text = healthReord.VisiPeriodYear;
            this.lblPriSuizhenQixianYue.Text = healthReord.VisiPeriodMonth;
            this.lblPriSuizhenQixianZhou.Text = healthReord.VisiPeriodWeek;

            //示教病例
            if (healthReord.TechSerc == "1")
            {
                this.lblPriShijiaoBingli.Text = "1";
            }
            else
            {
                this.lblPriShijiaoBingli.Text = "2";
            }

            #endregion

            #region 血型、输血品种

            //血型不是从常数中获取
            switch (healthReord.PatientInfo.BloodType.ID.ToString())
            {
                case "A":
                    this.lblPriXuexing.Text = "1";
                    break;
                case "B":
                    this.lblPriXuexing.Text = "2";
                    break;
                case "AB":
                    this.lblPriXuexing.Text = "3";
                    break;
                case "O":
                    this.lblPriXuexing.Text = "4";
                    break;
                case "U":
                    this.lblPriXuexing.Text = "5";
                    break;
                default:
                    this.lblPriXuexing.Text = "5";
                    break;
            }

            this.lblPriXuexing.Text = healthReord.PatientInfo.BloodType.ID.ToString();

            this.lblPriRH.Text = healthReord.RhBlood;

            this.lblPriShuxueFanying.Text = healthReord.ReactionBlood;

            //输血品种
            this.lblPriShuxuePinzhongHongxibao.Text = healthReord.BloodRed;
            this.lblPriShuxuePinzhongQuanxue.Text = healthReord.BloodWhole;
            this.lblPriShuxuePinzhongXuejiang.Text = healthReord.BloodPlasma;
            this.lblPriShuxuePinzhongXuexiaoban.Text = healthReord.BloodPlatelet;
            this.lblPriShuxuePinzhongQita.Text = healthReord.BloodOther;

            #endregion
            //#region 重症信息
            //////Neusoft.HISFC.BizProcess.RADT.InPatient( public ArrayList GetPatientRADTInfo(string patientNo))
            ////Neusoft.HISFC.Models.Invalid.CShiftData myCShiftDate = new Neusoft.HISFC.Models.Invalid.CShiftData();
            //ArrayList alShiftData = new ArrayList();
            //////获取患者转科信息
            //////alShiftData = radtIntergate.GetPatientRADTInfo(healthReord.PatientInfo.ID);
            ////从病案表取转科信息
            //alShiftData = deptChange.QueryChangeDeptFromShiftApply(healthReord.PatientInfo.ID, "2");

            ////ArrayList deptList = managerIntergate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

            //string inDate = "";
            //string outDate = "";
            //Neusoft.HISFC.Models.RADT.Location changeDept = null;
            //Neusoft.HISFC.Models.RADT.Location changeDeptTemp = null;

            //////把ICU科室信息给哈希表
            ////for (int k = 0; k < deptList.Count; i++)
            ////{
            ////    dept = deptList[0] as Neusoft.HISFC.Models.Base.Department;
            ////    if (dept.SpecialFlag != 3 || dept.SpecialFlag != 4)//不是ICU CCU  coutinue
            ////    {
            ////        continue;
            ////    }                        
            ////}
            ////hashICUdept
            ////if (alShiftData != null && alShiftData.Count > 0)
            ////{
            ////for (int p = 0; p < alShiftData.Count - 1; p++)
            ////{
            ////    changeDept = alShiftData[p] as Neusoft.HISFC.Models.RADT.Location;
            ////    if (changeDept.Dept.User01 != "3" && changeDept.Dept.User01 != "4" && p > 3)
            ////    {
            ////        continue;
            ////    }
            ////    if (p == 0)
            ////    {
            ////        inDate = healthReord.PatientInfo.PVisit.InTime.ToString();//转入日期
            ////        if (alShiftData.Count > 1)
            ////        {
            ////            changeDeptTemp = alShiftData[1] as Neusoft.HISFC.Models.RADT.Location;
            ////            outDate = changeDeptTemp.User01;//转出时间
            ////        }
            ////        else
            ////        {
            ////            outDate = obj.PatientInfo.PVisit.OutTime.ToString();
            ////        }
            ////    }
            ////    else if (p < alShiftData.Count)
            ////    {
            ////        inDate = changeDept.User01;//转入时间
            ////        changeDeptTemp = alShiftData[p + 1] as Neusoft.HISFC.Models.RADT.Location;
            ////        outDate = changeDeptTemp.User01;//转出时间
            ////    }
            ////    else if (p == alShiftData.Count)
            ////    {
            ////        inDate = changeDept.User01;//转入时间
            ////        outDate = obj.PatientInfo.PVisit.OutTime.ToString();//转出时间
            ////    }

            //    //inDate = changeDept.User01;//转入时间
            //    //Neusoft.HISFC.Models.Base.Department dept = null;

            //    //switch (p)
            //    //{
            //    //    case 0:
            //    //        Jianhu1.Text = changeDept.Dept.Name;
            //    //        Jinru1.Text = inDate;
            //    //        tuichu1.Text = outDate.ToString();
            //    //        break;
            //    //    case 1:
            //    //        Jianhu2.Text = changeDept.Dept.Name;
            //    //        Jinru2.Text = inDate;
            //    //        tuichu2.Text = outDate.ToString();
            //    //        break;
            //    //    case 2:
            //    //        Jianhu3.Text = changeDept.Dept.Name;
            //    //        Jinru3.Text = inDate;
            //    //        tuichu3.Text = outDate.ToString();
            //    //        break;
            //    //    case 3:
            //    //        Jianhu4.Text = changeDept.Dept.Name;
            //    //        Jinru4.Text = inDate;
            //    //        tuichu4.Text = outDate;
            //    //        break;
            //    //    default:
            //    //        break;

            //    //}

            ////}

            ////}
            //#endregion

            #region 其他 add by lk 2008-09-12
            //this.useHourBox.Text = healthReord.ApneaUseTime.ToString();//呼吸机使用时间
            //this.HosHour.Text = healthReord.PreComaHour.ToString();//昏迷时间小时
            //this.HosMinute.Text = healthReord.PreComaMin.ToString();//昏迷时间 分钟
            //this.inHosHour.Text = healthReord.SithComaHour.ToString();//入院后昏迷时间 小时
            //this.inHosMinute.Text = healthReord.SithComaMin.ToString();//入院后昏迷时间 分钟
            //this.outHosMethod.Text = healthReord.LeaveHospital;//离院方式
            //this.HosName.Text = healthReord.TransferHospital;//转入医院名称

            //this.SuperNus.Text = healthReord.SuperNus.ToString();//特级护理
            //this.INus.Text = healthReord.IINus.ToString();//一级护理
            //this.IINus.Text = healthReord.IINus.ToString();//二级护理
            //this.IIINus.Text = healthReord.IIINus.ToString();//三级护理
            //this.ICU.Text = healthReord.StrictNuss.ToString();//重症监护
            //this.CCU.Text = healthReord.SpecalNus.ToString();//特殊护理


            #endregion
        }

        #endregion

        #region IReportPrinter 成员

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void lbl02_Click(object sender, EventArgs e)
        {

        }
    }
}
