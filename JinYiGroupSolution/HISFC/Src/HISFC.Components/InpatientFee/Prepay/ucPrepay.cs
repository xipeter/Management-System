using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.FrameWork.WinForms.Classes;

namespace Neusoft.HISFC.Components.InpatientFee.Prepay
{
    /// <summary>
    /// ucPrepay<br></br>
    /// [功能描述: 结算控件]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>

    public partial class ucPrepay : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPrepay()
        {
            this.InitializeComponent();
        }

        #region "变量"
        /// <summary>
        /// 患者基本信息综合实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 入出转integrate层
        /// </summary>
        
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        /// <summary>
        /// 住院费用业务层

        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        /// <summary>
        /// 住院费用组合业务层

        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
 

        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        
        //按比例警戒线业务层
        Components.InpatientFee.Function fun = new Function();
        //控制参数判断
        /// <summary>
        /// 是否打印冲红发票
        /// </summary>
        bool IsPrintReturn = false;

        /// <summary>
        /// 负发票是否走新票号
        /// </summary>
        bool IsReturnNewInvoice = false;
        /// <summary>
        /// 是否可以作废，重打隔天票据
        /// </summary>
        private bool isCanDealBefore = true;

        /// <summary>
        /// 是否可以交叉退预交金
        /// </summary>
        private bool isCanQuitOtherOper = true;

        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint prepayPrint = null;

        #endregion "属性"

        #region IInterfaceContainer 成员

        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint);

                return type;
            }
        }

        #endregion
      
        #region "属性"

        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint PrepayPrint 
        {
            set 
            {
                this.prepayPrint = value;
            }
        }

        /// <summary>
        /// 是否允许补打以前的发票
        /// </summary>
        [Category("控件设置"),Description("是否可以作废，重打隔天票据")]
        public bool IsCanDealBefore
        {
            get
            {
                return isCanDealBefore;
            }
            set
            {
                isCanDealBefore = value;
            }
        }


        [Category("控件设置"), Description("是否可以交叉退预交金")]
        public bool IsCanQuitOtherOper
        {
            get { return isCanQuitOtherOper; }
            set { isCanQuitOtherOper = value; }
        }
        //{EC8090DB-81AC-4fff-A896-0E30DB217F70}

        private bool isCanAfterDayReportQuitFee = false;
        //{EC8090DB-81AC-4fff-A896-0E30DB217F70}
        [Category("控件设置"), Description("是否允许日结后退预交金")]
        public bool IsCanAfterDayReportQuitFee
        {
            get { return isCanAfterDayReportQuitFee; }
            set { isCanAfterDayReportQuitFee = value; }
        }

        #endregion

        #region "方法"
        /// <summary>
        /// 初始化控件信息
        /// </summary>
        public virtual void initControl()
        {
            //初始化默认现金方式
            this.cmbPayType.Tag = "CA";
            this.cmbPayType.Text = "现金";

            //确定选择方式
            this.cmbPayType.IsListOnly = true;
            //初始化farpoint属性
            this.fpPrepay_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpPrepay_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            //初始化住院号控件
            this.ucQueryInpatientNo.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucQueryInpatientNo.TextBox.Size = new System.Drawing.Size(116, 21);
            this.ucQueryInpatientNo.TextBox.Location = new System.Drawing.Point(52, 5);
            this.ucQueryInpatientNo.TextBox.BringToFront();
            //添加支付方式控件事件
            this.cmbPayType.KeyDown += new KeyEventHandler(cmbPayType_KeyDown);
            this.cmbPayType.KeyPress += new KeyPressEventHandler(cmbPayType_KeyPress);
          
        }

	    /// <summary>
		/// 读取控制类信息
		/// </summary>
        private int ReadControlInfo()
        {
            Neusoft.FrameWork.Management.ControlParam controlParm = new Neusoft.FrameWork.Management.ControlParam();
            try
            {
                this.IsPrintReturn = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100015"));
                this.IsReturnNewInvoice = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100016"));
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("读取控制类信息出错!",211);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 查询患者预交金信息
        /// </summary>
        /// <param name="patientInfo">住院患者基本信息实体</param>
        /// <returns>1 成功 －1失败</returns>
        protected virtual int QueryPatientPrepay(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            //添加行

            ArrayList al = new ArrayList();

            try
            {
                //根据住院号提取患者预交金信息到ArrayList
                al = this.feeInpatient.QueryPrepays(patientInfo.ID);
                if (al == null) return 0;
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(ex.Message,211);
                return -1;
            }
            this.fpPrepay_Sheet1.RowCount = 0;
            this.fpPrepay_Sheet1.RowCount = al.Count;
            //交款次数
            int PayCount = 0;
            //返款次数
            int WasteCount = 0;

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
                prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)al[i];

                string PrepayState = "";
                if (prepay.FT.PrepayCost > 0)
                {
                    PayCount++;
                    PrepayState = "收取";
                }
                else
                {
                    WasteCount++;
                    switch (prepay.PrepayState)
                    {
                        case "1":
                            PrepayState = "返还";

                            break;
                        case "2":
                            PrepayState = "补打";
                            break;
                        default:
                            PrepayState = "收取";
                            break;
                    }
                }
                //更新一些没有的字段()
                string PrepaySource = "";
                if (prepay.TransferPrepayState == "0")
                {
                    PrepaySource = "预交金";
                }
                else
                {
                    PrepaySource = "转押金";
                }
                //结算标记
                string BalanceFlag = "";
                if (prepay.BalanceState == "0")
                {
                    BalanceFlag = "未结算";
                }
                else
                {
                    BalanceFlag = "已结算";
                }
                //收款员姓名

                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
                empl = managerIntergrate.GetEmployeeInfo(prepay.PrepayOper.ID);

                if (empl == null)
                { prepay.PrepayOper.Name = ""; }
                else
                {
                    prepay.PrepayOper.Name = empl.Name;
                }
                //支付方式

                Neusoft.FrameWork.Models.NeuObject payObj = this.managerIntegrate.GetConstant("PAYMODES", prepay.PayType.ID);
                if (payObj == null) 
                {
                    MessageBox.Show("获得支付方式定义信息出错!" + this.managerIntegrate.Err);

                    return -1;
                }

               //添加farpoint显示内容
                Object[] o = new Object[] { prepay.RecipeNO, PrepayState, prepay.FT.PrepayCost, payObj.Name, PrepaySource, BalanceFlag, prepay.PrepayOper.Name, prepay.PrepayOper.OperTime.ToString() };

                for (int j = 0; j <= o.GetUpperBound(0); j++)
                {
                    try
                    {
                        fpPrepay_Sheet1.Cells[i, j].Value = o[j];
                    }
                    catch (Exception ex)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg(ex.Message,211);
                        return -1;
                    }
                }
                if (prepay.PrepayState != "0") this.fpPrepay_Sheet1.Cells[i, 1].ForeColor = System.Drawing.Color.Red;
                fpPrepay_Sheet1.Rows[i].Tag = prepay;
            }
            //返还交款次数
            this.txtPayNum.Text = PayCount.ToString();
            this.txtBackNum.Text = WasteCount.ToString();
            //余额
            if (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.txtFreeCost.Text), 2) < 0)
            {
                this.txtFreeCost.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.txtFreeCost.ForeColor = System.Drawing.Color.Black;
            }
            return 1;
        }

        /// <summary>
        /// 清空
        /// </summary>
        protected virtual void Clear()
        {
                 
            this.patientInfo = null;
            txtSumPreCost.Text = "";
            this.txtTotCost.Text = "";
            this.txtName.Text = "";
            this.txtDept.Text = "";
            this.txtPact.Text = "";
            this.txtBedNo.Text = "";
            this.txtOwnCost.Text = "";
            txtFreeCost.Text = "";
            txtBirthday.Text = "";
            txtNurseStation.Text = "";
            txtDateIn.Text = "";
            txtDoctor.Text = "";
            this.cmbPayType.Tag = "CA";
            this.cmbPayType.Text = "现金";
            this.cmbPayType.bank = new Neusoft.HISFC.Models.Base.Bank();
            this.fpPrepay_Sheet1.RowCount = 0;
            this.txtPayNum.Text = "";
            this.txtBackNum.Text = "";
            this.txtPreCost.Text = "";//预交金额清空
            //{99D7338F-F0A6-478c-9660-9BC728263E5F}
            this.toolBarService.SetToolButtonEnabled("收取", true);
            this.cmbPayType.Enabled = true;
            this.txtPreCost.ReadOnly = false;
        }

        /// <summary>
        /// 利用患者信息实体进行控件赋值
        /// </summary>
        /// <param name="patientInfo">患者基本信息实体</param>
        protected virtual void EvaluteByPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            }
            //预交金总额
            this.txtSumPreCost.Text = patientInfo.FT.PrepayCost.ToString();
            //费用金额
            this.txtTotCost.Text = patientInfo.FT.TotCost.ToString();
            // 姓名
            this.txtName.Text = patientInfo.Name;
            // 科室
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            // 合同单位
            this.txtPact.Text = patientInfo.Pact.Name;
            //床号
            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;
            //自费金额
            this.txtOwnCost.Text = patientInfo.FT.OwnCost.ToString();
            //余额
            txtFreeCost.Text = patientInfo.FT.LeftCost.ToString();
            //生日
            txtBirthday.Text = patientInfo.Birthday.ToString("yyyy-MM-dd");
            //所属病区


            txtNurseStation.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;
            //入院日期
            txtDateIn.Text = patientInfo.PVisit.InTime.ToString("yyyy-MM-dd");
            // 医生
            txtDoctor.Text = patientInfo.PVisit.AdmittingDoctor.Name;
            //住院号


            this.ucQueryInpatientNo.TextBox.Text = patientInfo.PID.PatientNO;         
            
        }

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("收取", "收取患者的预交金",(int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借入,true, false, null);
            toolBarService.AddToolButton("返还", "返还患者预交金", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借出, true, false, null);
            toolBarService.AddToolButton("清屏", "清空信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("补打", "预交金发票补打", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C重打, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            

            return this.toolBarService;
        }

        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //string tempText = string.Empty;

            //try
            //{
            //    tempText = this.hsToolBar[e.ClickedItem.Text].ToString();
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}

            ButtonClicked(e.ClickedItem.Text);

            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 响应键盘、鼠标事件
        /// </summary>
        /// <param name="tempText">工具栏按钮名称</param>
        private void ButtonClicked(string tempText)
        {
            switch (tempText)
            {
                case "收取":

                    this.ReceivePrepay();
                    //清空上次操作 席宗飞 xizf@neusoft.com 20101030
                    //this.Clear();
                    this.ucQueryInpatientNo.Text = "";
                    this.ucQueryInpatientNo.Focus();
                    break;
                case "返还":

                    this.ReturnPrepay();
                    break;
                case "清屏":

                    this.Clear();
                    this.ucQueryInpatientNo.Text = "";
                    this.ucQueryInpatientNo.Focus();
                    break;
                case "补打":
                    this.ReprintPrepay();
                    break;
                case "帮助":
                    break;
                case "退出":
                    {
                        this.FindForm().Close();
                        break;
                    }

            }
        }

        /// <summary>
        /// 打印预交金
        /// 王宇修改， 控制冲红票打印负数，并且注明作废字样
        /// 增加了[bool]isReturn参数，如果是冲红票为True,正常收取票为False
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="prepay"></param>
        /// <param name="isReturn"></param>
        protected virtual void PrintPrepayInvoice(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay, bool isReturn)
        {
            if (patientInfo.IsEncrypt)
            {
                patientInfo.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(patientInfo.NormalName);
            }
            this.prepayPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint;
            //regprint.SetPrintValue(regObj,regmr);
            //this.prepayPrint = new ucPrepayPrint();
            if (this.prepayPrint == null)
            {
                //this.prepayPrint = new ucPrepayPrint();
                return;
            }
           

            this.prepayPrint.SetValue(patientInfo, prepay);
            this.prepayPrint.Print();


        }

        /// <summary>
        /// 预交金收取
        /// </summary>
        protected virtual void ReceivePrepay()
        {
            //{645F3DDE-4206-4f26-9BC5-307E33BD882C}
            string errText = string.Empty;
            if (!feeIntegrate.AfterDayBalanceCanFee(this.feeInpatient.Operator.ID, true, ref errText))
            {
                MessageBox.Show(errText);
                return;
            }

            //判断患者
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return;
            }
            //金额判断
            decimal prepayCost = 0m;
            try
            {
                prepayCost = decimal.Parse(this.txtPreCost.Text);
            }
            catch
            {
                prepayCost = 0;
                this.txtPreCost.Text = "0.00";
            }
            if ((this.txtPreCost.Text == null) || (this.txtPreCost.Text == "") || prepayCost == 0)
            {
               Neusoft.FrameWork.WinForms.Classes.Function.Msg("请输入预交金金额!",111);
                this.txtPreCost.Focus();
                this.txtPreCost.SelectAll();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPreCost.Text) < 0)
            {
                
               Neusoft.FrameWork.WinForms.Classes.Function.Msg("预交金额应大于零!",111);
                this.txtPreCost.Focus();
                this.txtPreCost.SelectAll();
                return;

            }
            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPreCost.Text) >= 100000)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("预交金额不能大于100000!", 111);
                this.txtPreCost.SelectAll();
                return;
            }
            //判断支付方式
            if (this.cmbPayType.Tag == null || this.cmbPayType.Tag.ToString() == string.Empty)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请选择支付方式！", 111);
                this.cmbPayType.Focus();
                return;
            }
            //判断回车确认住院号

            if (this.patientInfo.PID.PatientNO != this.ucQueryInpatientNo.Text.Trim())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请回车确认住院号",111);
                return;
            }
            //判断封帐
            if ((this.feeInpatient.GetStopAccount(this.patientInfo.ID)) == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者处于封帐状态,可能正在结算,请稍后再做此操作!",111);
                return;
            }
            if (MessageBox.Show("是否确认保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            //事务连接
            //Neusoft.FrameWork.Management.Transaction t = new Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //this.Person.SetTrans(t.Trans);
            //建立新插入预交金实体
            Neusoft.HISFC.Models.Fee.Inpatient.Prepay newPrepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
           
            //提取发票号码
            //发票类型-预交金

            string InvoiceNo = "";
            //InvoiceNo = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
            InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");
            if (InvoiceNo == null || InvoiceNo.Trim() == "")
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请领取发票!",111);
                return;
            }
            //财务组

            Neusoft.FrameWork.Models.NeuObject finGroup = new Neusoft.FrameWork.Models.NeuObject();
            finGroup = this.feeInpatient.GetFinGroupInfoByOperCode(this.feeInpatient.Operator.ID);

            newPrepay.RecipeNO = InvoiceNo;

            //实体赋值


            newPrepay.Name = this.patientInfo.Name;
            newPrepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
            newPrepay.PrepayOper.Name = this.feeInpatient.Operator.Name;
            newPrepay.FT.PrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPreCost.Text);
            newPrepay.Bank = this.cmbPayType.bank.Clone();
            newPrepay.PayType.ID = this.cmbPayType.Tag.ToString();
            newPrepay.Dept = this.patientInfo.PVisit.PatientLocation.Dept.Clone();
            newPrepay.BalanceState = "0";
            newPrepay.BalanceNO = 0;
            newPrepay.PrepayState = "0";
            newPrepay.IsTurnIn = false;
            newPrepay.FinGroup.ID = finGroup.ID;
            newPrepay.PrepayOper.OperTime = DateTime.Parse(this.feeInpatient.GetSysDateTime());
            newPrepay.TransferPrepayState = "0";

            //正常收或退预交金 ext_falg = "1";与结算召回区分，用字段 User01  By Maokb 060804
            newPrepay.User01 = "1";

            //调用业务层组合业务

            if (this.feeInpatient.PrepayManager(this.patientInfo, newPrepay) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("收取失败!"+feeInpatient.Err,211 );
                return;

            }
            //刷新余额标记
            this.txtFreeCost.Text = (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.txtFreeCost.Text), 2) + newPrepay.FT.PrepayCost).ToString();
            this.txtSumPreCost.Text = (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.txtSumPreCost.Text), 2) + newPrepay.FT.PrepayCost).ToString();
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            //Neusoft.FrameWork.WinForms.Classes.Function.Msg("预交金收取成功!", 111);
            //打印预交金发票

            //重新检索预交金记录
            this.QueryPatientPrepay(this.patientInfo);
            this.PrintPrepayInvoice(this.patientInfo, newPrepay, false);
            //
            #region added by xizf20101128 按比例更新警戒线 {6EEB39AF-6C5B-4a53-B366-6D25DC9B7FBA}
            if (this.patientInfo.Pact.ID != "01") {
                fun.UpdateInmainMoneyAlert(this.patientInfo.ID, this.patientInfo.Pact.ID);
            }
            #endregion
            this.txtPreCost.Text = "";
            this.ucQueryInpatientNo.Focus();

        }

        /// <summary>
        /// 预交金返还判断
        /// </summary>
        /// <param name="prepay"></param>
        /// <returns></returns>
        private bool ValidReturnPrepay(Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay)
        {
            //{645F3DDE-4206-4f26-9BC5-307E33BD882C}
            string errText = string.Empty;
            if (!feeIntegrate.AfterDayBalanceCanFee(this.feeInpatient.Operator.ID, true, ref errText))
            {
                MessageBox.Show(errText);
                return false;
            }

            if (prepay.PrepayState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金已经返还!不能进行再次作废操作!", 111);
                return false;
            }
            if (prepay.PrepayState == "2")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金已经进行过补打操作,已经成为作废发票,不能再作废!", 111);
                return false;
            }
            if (prepay.BalanceState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该票据已经结算过不能作废!!", 111);
                return false;
            }
            //{9B8D83F8-CB0F-48fb-8ECD-0BA4462A952A}
            //{EC8090DB-81AC-4fff-A896-0E30DB217F70}
            if (!this.IsCanAfterDayReportQuitFee)
            {
                if (prepay.Memo == "1")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("该票据已经日结不能作废!!", 111);
                    return false;
                }
            }

            if (prepay.TransferPrepayState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金为结算的转押金还没有进行正常打印操作,不能作废!", 111);
                return false;
            }
            if (!isCanDealBefore)
            {
                if (prepay.PrepayOper.OperTime < feeInpatient.GetDateTimeFromSysDateTime().Date)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("不能作废当天前的预交金!", 111);
                    return false;
                }
            }

            if (!isCanQuitOtherOper)
            {
                if (prepay.PrepayOper.ID != feeInpatient.Operator.ID)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("该发票为操作员" + prepay.PrepayOper.ID + "收取,您没有权限作废！", 111);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 预交金返还
        /// </summary>
        protected virtual void ReturnPrepay()
        {
            //有效操作判断
            if (this.fpPrepay_Sheet1.ActiveRowIndex < 0) return;
            if (this.fpPrepay_Sheet1.Rows.Count <= 0) return;
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return;
            }

            Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
            prepay = ( Neusoft.HISFC.Models.Fee.Inpatient.Prepay)this.fpPrepay_Sheet1.ActiveRow.Tag;
            
            if (prepay == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请选择一条预交金记录",111);
                return;
            }

            prepay = feeInpatient.QueryPrePay(this.patientInfo.ID, prepay.ID);
            if (prepay == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("查询预交金信息失败！"+feeInpatient.Err, 111);
                return;
            }

            if (!ValidReturnPrepay(prepay)) return;


            DialogResult r =Neusoft.FrameWork.WinForms.Classes.Function.Msg("是否返还发票号为" + prepay.RecipeNO + "的预交金?",422);
            if (r == DialogResult.No) return;
            //判断封帐
            if ((this.feeInpatient.GetStopAccount(this.patientInfo.ID)) == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者处于封帐状态,可能正在结算,请稍后再做此操作!", 111);
                return;
            }
            //事务连接
           //Transaction t = new Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //原有发票号码
            prepay.OrgInvoice.ID = prepay.RecipeNO;
            //判断负记录走新发票号码

            if (this.IsReturnNewInvoice)
            {
                //提取发票号码
                //发票类型-预交金

                string InvoiceNo = "";
                //InvoiceNo = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");
                if (InvoiceNo == null || InvoiceNo == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取发票出错!",211);
                    return;
                }
                prepay.RecipeNO = InvoiceNo;
            }
            //调用业务层组合业务返还预交金

            if (this.feeInpatient.PrepayManagerReturn(this.patientInfo, prepay) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err + "返还失败!",211);
                return;
            }
            //刷新余额标记
            this.txtFreeCost.Text = (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.txtFreeCost.Text), 2) + prepay.FT.PrepayCost).ToString();
            this.txtSumPreCost.Text = (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.txtSumPreCost.Text), 2) + prepay.FT.PrepayCost).ToString();
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("预交金返还成功!", 111);
            //重新检索预交金记录
            this.QueryPatientPrepay(this.patientInfo);
            //打印冲红发票;
            if (this.IsPrintReturn)
            {
                this.PrintPrepayInvoice(this.patientInfo, prepay, true);
            }
            #region added by xizf20101128 按比例更新警戒线
            if (this.patientInfo.Pact.ID != "01") {
                fun.UpdateInmainMoneyAlert(this.patientInfo.ID, this.patientInfo.Pact.ID);
            }
            #endregion

        }

        /// <summary>
        /// 预交金补打
        /// </summary>
        protected virtual void ReprintPrepay()
        {
            if (this.fpPrepay_Sheet1.ActiveRowIndex < 0) return;
            if (this.fpPrepay_Sheet1.Rows.Count <= 0) return;
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return;
            }

          

            Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
            prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)this.fpPrepay_Sheet1.ActiveRow.Tag;

            if (prepay == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请选择一条预交金记录", 111);
                return;
            }

            if (prepay.PrepayState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金已经返还!不能进行补打操作!", 111);
                return;
            }
            if (prepay.PrepayState == "2")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金已经进行过补打操作,已经成为作废发票,不能再补打!", 111);
                return;
            }
            if (prepay.BalanceState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该票据已经结算过不能补打!!",111);
                return;
            }
            if (prepay.TransferPrepayState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金为结算的转押金还没有进行正常打印操作,不能补打!", 111);
                return;
            }
            //if (!isCanDealBefore)
            //{
            //    if (prepay.PrepayOper.OperTime < feeInpatient.GetDateTimeFromSysDateTime().Date)
            //    {
            //        Neusoft.FrameWork.WinForms.Classes.Function.Msg("不能作废当天前的预交金!",111);
            //        return;
            //    }
            //}
            //取控制参数限制补打天数

            string limitDays = "";
            Neusoft.FrameWork.Management.ControlParam controlParm = new Neusoft.FrameWork.Management.ControlParam();
            limitDays = controlParm.QueryControlerInfo("100022");
            if (limitDays == null || limitDays == "") limitDays = "";
            if (limitDays.Trim() != "")
            {
                if ((this.feeInpatient.GetDateTimeFromSysDateTime().Date - prepay.PrepayOper.OperTime.Date).Days > Neusoft.FrameWork.Function.NConvert.ToInt32(limitDays))
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("预交金发生间隔超过" + limitDays + "天,不能进行补打操作!", 111);
                    return;
                }
            }

            DialogResult r = Neusoft.FrameWork.WinForms.Classes.Function.Msg("是否补打发票号为" + prepay.RecipeNO + "的预交金?",422);
            if (r == DialogResult.No) return;
            //判断封帐
            if ((this.feeInpatient.GetStopAccount(this.patientInfo.ID)) == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者处于封帐状态,可能正在结算,请稍后再做此操作!", 111);
                return;
            }
            //事务连接
           //Transaction t = new Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //提取发票号码
            //发票类型-预交金

            string returnInvoice = "";
            if (this.IsReturnNewInvoice)
            {
               

                //returnInvoice = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
                returnInvoice = this.feeIntegrate.GetNewInvoiceNO("P");
                if (returnInvoice == null || returnInvoice == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取发票出错!",211);
                    return;
                }
            }
        
            string invoiceNo = "";
            //invoiceNo = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
            invoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");
            if (invoiceNo == null || invoiceNo == "")
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取发票出错!",211);
                return;
            }
            //调用组合业务处理正负记录
            Neusoft.HISFC.Models.Fee.Inpatient.Prepay returnPrepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
            if (this.feeInpatient.PrepaySignOperation(prepay, this.patientInfo, invoiceNo, returnInvoice, ref returnPrepay) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err + "补打失败!",211);
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //打印预交金发票

            if (this.IsPrintReturn)
            {
                this.PrintPrepayInvoice(this.patientInfo, returnPrepay, true);
            }
            this.PrintPrepayInvoice(this.patientInfo, prepay, false);
            //重新检索预交金记录
            this.QueryPatientPrepay(this.patientInfo);
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("补打完毕！",111);
        }

        #endregion

        #region "事件"

        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPrepay_Load(object sender, EventArgs e)
        {
            //初始化控件
            this.initControl();
            //重新初始化工具栏
            //try
            //{
            //    Function.RefreshToolBar(this.hsToolBar, ((Neusoft.FrameWork.WinForms.Forms.frmBaseForm)this.ParentForm).toolBar1, "预交金管理");
            //}
            //catch { }

            //设置窗体控件的输入法状态为半角
            Neusoft.HISFC.Components.Common.Classes.Function.SetIme(this);
        }

        void cmbPayType_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.txtPreCost.Focus();
            
        }

        void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                this.txtPreCost.SelectAll();
                txtPreCost.Focus();
            }
		
        }

        private void ucQueryInpatientNo_myEvent()
        {
            //清空
            this.Clear();
            this.fpPrepay_Sheet1.RowCount = 0;

            //判断是否有该患者
            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                if (this.ucQueryInpatientNo.Err == "")
                {
                    ucQueryInpatientNo.Err = "此患者不在院!";
                }
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.ucQueryInpatientNo.Err,211);

                this.ucQueryInpatientNo.Focus();
                return;
            }
            //获取住院号赋值给实体
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);

            if (this.patientInfo == null) MessageBox.Show(this.radtIntegrate.Err);

               

            //if ((Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.N
            //    || (Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.O)
            if (this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!",111);

                this.patientInfo.ID = null;

                return;
            }
            //{99D7338F-F0A6-478c-9660-9BC728263E5F}
            else if (this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.B.ToString())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经做过出院登记!", 111);
                this.toolBarService.SetToolButtonEnabled("收取", false);
                this.cmbPayType.Enabled = false;
                this.txtPreCost.ReadOnly = true;
            }
            //控件赋值患者信息


            this.EvaluteByPatientInfo(this.patientInfo);


         
            //读取控制类参数
            if (this.ReadControlInfo() == -1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取控制信息出错!",211);
                this.Clear();
                return;
            }

            //判断未打印的转押金


            ArrayList alForegift = new ArrayList();
            //判断是否存在未打印转押金
             alForegift = this.feeInpatient.QueryForegif(this.patientInfo.ID);
            if (alForegift == null)
            {
               Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err,211);
                this.Clear();
                return;
            }
            if (alForegift.Count > 0)
            {
                //luzp 2008-6-2
                //DialogResult r = Neusoft.FrameWork.WinForms.Classes.Function.Msg("患者有" + alForegift.Count.ToString() + "笔转押金没有打印,是否打印?", 423);
                //{64BD57CE-9361-41f6-AE91-2618CBA5047A}
                DialogResult r =MessageBox.Show("患者有" + alForegift.Count.ToString() + "笔转押金没有打印,是否打印?","提示",MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {

                    //Transaction t = new Transaction(this.feeInpatient.Connection);
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    foreach (Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay in alForegift)
                    {
                        //提取发票号码
                        //发票类型-预交金


                        string InvoiceNo = "";
                        InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");

                        if (InvoiceNo == null || InvoiceNo == "")
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err,211);
                            return;
                        }
                        //					
                        prepay.RecipeNO = InvoiceNo;
                        prepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
                        prepay.PrepayOper.Name = this.feeInpatient.Operator.Name;

                        //打印转押金发票


                        this.PrintPrepayInvoice(this.patientInfo, prepay, false);
                        //更新转押金发票号码和状态


                        if (feeInpatient.UpdateForgift(this.patientInfo, prepay) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err,211);
                            return;
                        }

                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                   
                    
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("转押金打印完毕!",111);
                }

            }

            if (this.QueryPatientPrepay(this.patientInfo) == -1)
            {
                this.Clear();
                this.fpPrepay_Sheet1.Rows.Count = 0;
                return;
            }
            this.cmbPayType.Focus();
        }
        #endregion

        #region 快捷键

        /// <summary>
        /// toolBar映射
        /// </summary>
        protected Hashtable hsToolBar = new Hashtable();

        /// <summary>
        /// 按键设置
        /// </summary>
        /// <param name="keyData">当前按键</param>
        /// <returns>继续执行True False 当前处理结束</returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {

            //if (!this.ExecuteShotCut(keyData))
            //{
            //    return false;
            //}
           if (this.cmbPayType.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    ///{17383B2D-3110-4a9b-B0B7-99D95CB693C5} 增加支付方式的数字输入方式 席宗飞20101020
                    if (string.IsNullOrEmpty(this.cmbPayType.Text.Trim()))
                    {
                        MessageBox.Show("支付方式不能为空,请重新输入!");
                        this.cmbPayType.Focus();
                    }
                    else
                    {
                        if (this.cmbPayType.Text.Trim() == "1")
                        {
                            this.cmbPayType.Tag = "CA";
                        }
                        else if (this.cmbPayType.Text.Trim() == "2")
                        {
                            this.cmbPayType.Tag = "DB";
                        }
                        else if (this.cmbPayType.Text.Trim() == "3")
                        {
                            this.cmbPayType.Tag = "CH";
                        }
                        else if (this.cmbPayType.Text.Trim() == "现金" || this.cmbPayType.Text.Trim() == "银联卡" || this.cmbPayType.Text.Trim() == "支票")
                        {

                        }
                        else
                        {
                            MessageBox.Show("支付方式输入错误,请重新输入!");
                            this.cmbPayType.Focus();
                            return true;
                        }
                    }
                    this.txtPreCost.SelectAll();
                    txtPreCost.Focus();
                    return true;
                }
            }

            //{FB14A4A2-EDDF-4ddc-A4DE-C080E2C6C40C}处理点回车之后，收取预交金
            if (this.txtPreCost.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    //{E3D8845C-F1B7-4595-B8FA-DB431745939A} 减少回车次数 席宗飞 modified  on 20100928
                    //if (MessageBox.Show("确认收取" + this.txtPreCost.Text.ToString() + "元预交金？", "收取", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPreCost.Text.Trim()) == 0)
                    {
                        MessageBox.Show("预交金额不能为零");
                        this.txtPreCost.Focus();
                        return true;
                    }
                    else {
                        this.ButtonClicked("收取");
                    }
                    //}
                    //else
                    //{
                    //    this.txtPreCost.Focus();
                    //}
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 执行快捷键
        /// </summary>
        /// <param name="key">当前按键</param>
        private bool ExecuteShotCut(Keys key)
        {
            string opName = Function.GetOperationName("预交金管理",key.GetHashCode().ToString());

            if (opName == "") return false;

            ButtonClicked(opName);

            return true;

        }

        #endregion

        /// <summary>
        /// 单击时全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreCost_Click(object sender, EventArgs e)
        {
            this.txtPreCost.SelectAll();
            txtPreCost.Focus();
        }

    }
}
