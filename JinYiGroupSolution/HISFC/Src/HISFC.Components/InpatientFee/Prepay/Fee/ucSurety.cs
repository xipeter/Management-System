using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    public partial class ucSurety : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// [功能描述: 住院患者担保]<br></br>
        /// [创 建 者: nxy]<br></br>
        /// [创建时间: 2010-05-21]<br></br>
        /// <修改记录>
        ///     
        /// </修改记录>
        /// </summary>
        public ucSurety()
        {
            InitializeComponent();
        }
        #region 域
        /// <summary>
        /// 住院患者信息实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        
        /// <summary>
        /// 住院入出转综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
       
        /// <summary>
        /// 人员管理业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Person personMgr = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 综合管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 住院费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.InPatient inpatientFee = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        Neusoft.FrameWork.Public.ObjectHelper payWayHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        Neusoft.FrameWork.Public.ObjectHelper suretyWayHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        Neusoft.FrameWork.Public.ObjectHelper bankHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 担保打印接口
        /// </summary>
        Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety iPrintSurety = null;
        #endregion
        #region 方法

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <returns></returns>
        private int InitControl()
        {
            //初始化担保类型
            ArrayList alSuretyType = Neusoft.HISFC.Models.Fee.SuretyTypeEnumService.List();
            this.cmbSuretyType.AddItems(alSuretyType);

            this.suretyWayHelper.ArrayObject = alSuretyType;

            //支付方式
            ArrayList alPayWay = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);

            this.payWayHelper.ArrayObject = alPayWay;

            //初始化担保人
            ArrayList alPerson = this.personMgr.GetEmployeeAll();

            if (alPerson == null)
            {
                MessageBox.Show("查询人员信息失败" + this.personMgr.Err);
                return 1;
            }
            
            //初始化科室
            ArrayList alDept = managerIntegrate.GetDepartment();

            if (alDept == null)
            {
                MessageBox.Show("查询科室信息失败" + this.personMgr.Err);
                return 1;
            }

            this.deptHelper.ArrayObject = alDept;


            this.cmbSurePerson.AddItems(alPerson);

            ArrayList alBackList = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BANK);
            this.bankHelper.ArrayObject = alBackList;
            this.InitInterface();

            return 1;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            this.InitControl();
            return 1;
        }

        /// <summary>
        /// 初始化接口
        /// </summary>
        private void InitInterface()
        {
            this.iPrintSurety = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety;

        }

        /// <summary>
        /// 查询已经存在的担保信息
        /// </summary>
        /// <returns></returns>
        private int QuerySuretyDetail(string inpatientNO)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            ArrayList alSuretyDetail = this.inpatientFee.QuerySuretyDetailByInpatientNO(inpatientNO);
            if (alSuretyDetail == null)
            {
                MessageBox.Show("查询担保信息出错");
                return -1;
            }

            for (int i = 0; i < alSuretyDetail.Count; i++)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo p = alSuretyDetail[i] as Neusoft.HISFC.Models.RADT.PatientInfo;
                this.neuSpread1_Sheet1.Rows.Add(0, 1);

                //发生序号
                this.neuSpread1_Sheet1.Cells[0, 0].Text = p.Surety.HappenNO.ToString();

                //担保人
                this.neuSpread1_Sheet1.Cells[0, 1].Text = p.Surety.SuretyPerson.Name;

                //担保金额
                this.neuSpread1_Sheet1.Cells[0, 2].Text = p.Surety.SuretyCost.ToString();

                //担保类型
                this.neuSpread1_Sheet1.Cells[0, 3].Text = this.suretyWayHelper.GetName(p.Surety.SuretyType.ID.ToString());

                //支付方式
                this.neuSpread1_Sheet1.Cells[0, 4].Text = this.payWayHelper.GetName(p.Surety.PayType.ID);

                //担保状态
                string state = string.Empty;
                switch (p.Surety.State)
                {
                    case "1":
                        {
                            this.neuSpread1_Sheet1.Cells[0, 5].Text = "有效";
                            this.neuSpread1_Sheet1.Rows[0].ForeColor = Color.Black;
                            break;
                        }
                    case "0":
                        {
                            
                            this.neuSpread1_Sheet1.Cells[0, 5].Text = "返还";
                            this.neuSpread1_Sheet1.Rows[0].ForeColor = Color.Red;
                            break;
                        }
                    case "2":
                        { 
                            this.neuSpread1_Sheet1.Cells[0, 5].Text = "补打";
                            this.neuSpread1_Sheet1.Rows[0].ForeColor = Color.Red;
                            break;
                        }
                    default:
                        break;
                }
                

                //开户银行
                this.neuSpread1_Sheet1.Cells[0, 6].Text = this.bankHelper.GetName(p.Surety.Bank.ID);
                //开户账户
                this.neuSpread1_Sheet1.Cells[0, 7].Text = p.Surety.Bank.Account;

                //工作单位
                this.neuSpread1_Sheet1.Cells[0, 8].Text = p.Surety.Bank.WorkName;

                //交易流水号
                this.neuSpread1_Sheet1.Cells[0, 9].Text = p.Surety.Bank.InvoiceNO;

                //收据号
                this.neuSpread1_Sheet1.Cells[0, 10].Text = p.Surety.InvoiceNO;

                //备注
                this.neuSpread1_Sheet1.Cells[0, 11].Text = p.Surety.Memo;

                this.neuSpread1_Sheet1.Rows[0].Tag = p;

            }
            //查询担保总额
            string suretyCost = this.inpatientFee.GetSurtyCost(inpatientNO);

            if (suretyCost == "-1")
            {
                MessageBox.Show("查询担保总额出错");
                return -1;
            }

            this.txtSuretyTotCost.Text = suretyCost;
            

            return 1;
        }


        private void ReceiveSure()
        {

            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return;
            }
            //金额判断
            decimal sureCost = 0m;
            try
            {
                sureCost = decimal.Parse(this.txtSureCost.Text);
            }
            catch
            {
                sureCost = 0;
                this.txtSureCost.Text = "0.00";
            }
            if ((this.txtSureCost.Text == null) || (this.txtSureCost.Text == "") || sureCost == 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请输入担保金额!", 111);
                this.txtSureCost.Focus();
                this.txtSureCost.SelectAll();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSureCost.Text) < 0)
            {

                Neusoft.FrameWork.WinForms.Classes.Function.Msg("担保金额应大于零!", 111);
                this.txtSureCost.Focus();
                this.txtSureCost.SelectAll();
                return;

            }
            //判断支付方式
            if (this.cmbTransType1.Tag == null || this.cmbTransType1.Tag.ToString() == string.Empty)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请选择支付方式！", 111);
                this.cmbTransType1.Focus();
                return;
            }

            if (this.cmbSurePerson.Tag == null || this.cmbSurePerson.Tag.ToString() == string.Empty|| this.cmbSurePerson.SelectedItem == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请选择担保人！", 111);
                this.cmbSurePerson.Focus();
                return;
            }
            //判断回车确认住院号


            if (this.patientInfo.PID.PatientNO != this.ucQueryInpatientNo.Text.Trim())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请回车确认住院号", 111);
                return;
            }

            //实体赋值
            Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            myPatientInfo = this.patientInfo;
            myPatientInfo.Surety.SuretyPerson = this.cmbSurePerson.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            myPatientInfo.Surety.SuretyCost = sureCost;
            myPatientInfo.Surety.Bank = this.cmbTransType1.bank.Clone();
            myPatientInfo.Surety.State = "1";
            myPatientInfo.Surety.SuretyType.ID = this.cmbSuretyType.Tag.ToString();
            myPatientInfo.Surety.Oper.ID = this.inpatientFee.Operator.ID;
            myPatientInfo.Surety.Oper.OperTime = this.inpatientFee.GetDateTimeFromSysDateTime();
            myPatientInfo.Surety.PayType.ID = this.cmbTransType1.Tag.ToString();
            myPatientInfo.Surety.Mark = this.txtMark.Text;
            myPatientInfo.Surety.InvoiceNO = this.inpatientFee.GetSequence("Fee.Inpatient.GetSeq.InvoiceNO");
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            

           int returnValue = this.inpatientFee.InsertSurty(myPatientInfo);

           if (returnValue < 0)
           {
               Neusoft.FrameWork.Management.PublicTrans.RollBack();
               MessageBox.Show("插入担保信息出错"  + this.inpatientFee.Err);
               return;
           }
           Neusoft.FrameWork.Management.PublicTrans.Commit();
           MessageBox.Show("担保成功");

           this.QuerySuretyDetail(this.patientInfo.ID);

           this.PrintSurety(myPatientInfo);

           this.txtSureCost.Text = "0.00";
           this.cmbTransType1.Focus();
           this.cmbSurePerson.Tag = "";
           this.cmbSuretyType.Tag = "";


            return;
        }

        /// <summary>
        /// 返还担保金额
        /// </summary>
        private void ReturnSuretyCost()
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
            try
            {
                patientInfo = this.neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
            }
            catch (Exception)
            {

                patientInfo = null;
            }

            if (patientInfo == null)
            {
                MessageBox.Show("请选择要返还的担保金记录");
                return;
            }

            

            Neusoft.HISFC.Models.RADT.PatientInfo p = patientInfo.Clone();

            if (p.Surety.State != "1")
            {
                MessageBox.Show("改条记录已经作废,不能返还");
                return ;
            }

            p.Surety.SuretyCost = -patientInfo.Surety.SuretyCost;
            p.Surety.Oper.ID = this.inpatientFee.Operator.ID;
            p.Surety.Oper.OperTime = this.inpatientFee.GetDateTimeFromSysDateTime();
            p.Surety.State = "0";

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //更新原来记录
            int returnValue = this.inpatientFee.UpdateSurtyState(patientInfo.ID, patientInfo.Surety.HappenNO.ToString(), "0");

            //更新出错
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新担保金记录失败" + this.inpatientFee.Err);
                return;
            }

            //没有找到记录
            if (returnValue == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("没有找到更细的记录");
            }

            //插入负记录

            returnValue = this.inpatientFee.InsertSurty(p);

            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("返还担保金失败：插入记录失败" + this.inpatientFee.Err );
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("返还成功");

            this.QuerySuretyDetail(this.patientInfo.ID);


        }

        private void Reprint()
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
            try
            {
                patientInfo = this.neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
            }
            catch (Exception)
            {

                patientInfo = null;
            }

            if (patientInfo == null)
            {
                MessageBox.Show("请选择要返还的担保金记录");
                return;
            }



            Neusoft.HISFC.Models.RADT.PatientInfo p = patientInfo.Clone();

            if (p.Surety.State != "1")
            {
                MessageBox.Show("改条记录已经作废,不能返还");
                return;
            }
            p.Surety.SuretyCost = -patientInfo.Surety.SuretyCost;
            p.Surety.Oper.ID = this.inpatientFee.Operator.ID;
            p.Surety.Oper.OperTime = this.inpatientFee.GetDateTimeFromSysDateTime();
            p.Surety.State = "2";
            p.Surety.OldInvoiceNO = patientInfo.Surety.InvoiceNO;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //更新原来记录
            int returnValue = this.inpatientFee.UpdateSurtyState(patientInfo.ID, patientInfo.Surety.HappenNO.ToString(), "0");

            //更新出错
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新担保金记录失败" + this.inpatientFee.Err);
                return;
            }

            //没有找到记录
            if (returnValue == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("没有找到更细的记录");
            }

            //插入负记录

            returnValue = this.inpatientFee.InsertSurty(p);

            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("补打担保金失败：插入负记录失败" + this.inpatientFee.Err);
                return;
            }

            //付给正值
            Neusoft.HISFC.Models.RADT.PatientInfo tempPatientInfo = p.Clone();
            tempPatientInfo.Surety.SuretyCost = -tempPatientInfo.Surety.SuretyCost;
            tempPatientInfo.Surety.OldInvoiceNO = this.patientInfo.Surety.InvoiceNO;
            tempPatientInfo.Surety.State = "1";
            tempPatientInfo.Surety.InvoiceNO = this.inpatientFee.GetSequence("Fee.Inpatient.GetSeq.InvoiceNO");
            returnValue = this.inpatientFee.InsertSurty(tempPatientInfo);
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("补打担保金失败：插入正记录失败" + this.inpatientFee.Err);
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("补打成功");

            this.QuerySuretyDetail(this.patientInfo.ID);

            //打印单据
            this.PrintSurety(tempPatientInfo);



            return ;
        }

        private void Clear()
        {
            this.patientInfo = null;
            this.txtSureCost.Text = "0.00";
            this.cmbSurePerson.Tag = "";
            this.cmbSuretyType.Tag = "";
            this.cmbTransType1.bank = new Neusoft.HISFC.Models.Base.Bank();
            this.cmbTransType1.Tag = "CA";
            this.cmbTransType1.Text = "现金";
            this.neuSpread1_Sheet1.RowCount = 0;
            this.txtMark.Text = string.Empty;
            this.ucInpatientInfo1.Clear();
        }

        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="patientInfo"></param>
        private void PrintSurety(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            if (this.iPrintSurety != null)
            {
                iPrintSurety.SetValue(patientInfo);
                iPrintSurety.Print();
            }
        }
        #endregion
        #region 事件
        void ucQueryInpatientNo1_myEvent()
        {
            this.Clear();
            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                if (this.ucQueryInpatientNo.Err == "")
                {
                    ucQueryInpatientNo.Err = "此患者不在院!";
                }
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.ucQueryInpatientNo.Err, 211);

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
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!", 111);

                this.patientInfo.ID = null;

                return;
            };

            this.ucInpatientInfo1.PatientInfoObj = this.patientInfo;

            this.QuerySuretyDetail(this.patientInfo.ID);

            this.cmbTransType1.Focus();
        }



        protected override void OnLoad(EventArgs e)
        {
            this.Init();
            base.OnLoad(e);
        }

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {

            toolBarService.AddToolButton("收取", "收取担保金", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借入, true, false, null);
            toolBarService.AddToolButton("返还", "返还担保金", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借出, true, false, null);
            toolBarService.AddToolButton("补打", "补打担保金", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "收取":
                    {
                        this.ReceiveSure();
                        break;
                    }
                case "返还":
                    {
                        this.ReturnSuretyCost();
                        break;
                    }
                case "补打":
                    {
                        this.Reprint();
                        break;
                    }
                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        
        #endregion

        private void cmbTransType1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.cmbTransType1.Tag == null || this.cmbTransType1.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请选择支付方式");
                cmbTransType1.Focus();
                return;
            }
            this.cmbSuretyType.Focus();
        }

        private void cmbSuretyType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (this.cmbSuretyType.Tag == null || this.cmbSuretyType.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请选择担保类型");
                this.cmbSuretyType.Focus();
                return;
            }
            this.cmbSurePerson.Focus();
        }

        private void cmbSurePerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (this.cmbSurePerson.Tag == null || this.cmbSurePerson.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请选择担保人");
                this.cmbSurePerson.Focus();
                return;
            }
            this.txtSureCost.Focus();
        }

        private void txtSureCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            this.txtMark.Focus();
        }



        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];

                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety);
                return type;

            }
        }

        #endregion
    }
}
