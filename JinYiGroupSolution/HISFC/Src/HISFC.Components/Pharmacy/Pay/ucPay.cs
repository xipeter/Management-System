using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy.Pay
{
    /// <summary>
    /// [功能描述: 供货商结存]<br></br>
    /// [创 建 者: liangjz]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucPay : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPay()
        {
            InitializeComponent();
        }        

        #region 变量

        /// <summary>
        /// 银行帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper bankHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 供货公司帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper companyHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 结存明细信息
        /// </summary>
        private ArrayList payDetail = new ArrayList();

        /// <summary>
        /// 供货公司
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Company company;

        /// <summary>
        /// 入库科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper;

        /// <summary>
        /// 查询起始时间
        /// </summary>
        private DateTime dtBegin = System.DateTime.Now.Date;//System.DateTime.MinValue;

        /// <summary>
        /// 查询终止时间
        /// </summary>
        private DateTime dtEnd = System.DateTime.Now.Date.AddDays(1);//System.DateTime.MaxValue;

        /// <summary>
        /// 查询结存标志
        /// </summary>
        private string payFlag;

        /// <summary>
        /// 供货单位
        /// </summary>
        private ArrayList alCompany = new ArrayList();

        #endregion

        #region 属性
      
        /// <summary>
        /// 供货公司
        /// </summary>
        protected Neusoft.HISFC.Models.Pharmacy.Company Company
        {
            set
            {
                if (value == null)
                    this.company = new Neusoft.HISFC.Models.Pharmacy.Company();
                else
                    this.company = value;

                this.lbCompany.Text = "结存单位：" + this.company.Name;
            }
        }    

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            toolBarService.AddToolButton("时  间", "设置查询时间", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询历史, true, false, null);
            toolBarService.AddToolButton("已结存查询", "已结存单据查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A安排, true, false, null);
            toolBarService.AddToolButton("未结存查询", "未结存单据查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.P盘点结存解封, true, false, null);
            toolBarService.AddToolButton("供货单位", "选择查询的供货单位", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J集体, true, false, null);

            toolBarService.AddToolButton("选择", "对当前所列数据进行反向选择", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "时  间")
            {
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref this.dtBegin, ref this.dtEnd) == 0)
                {
                    return;
                }
            }
            if (e.ClickedItem.Text == "未结存查询")
            {
                this.Query("'0','1'", dtBegin, dtEnd);

                this.payFlag = "'0','1'";
            }
            if (e.ClickedItem.Text == "已结存查询")
            {
                this.Query("'2'", dtBegin, dtEnd);

                this.payFlag = "2";
            }
            if (e.ClickedItem.Text == "供货单位")
            {
                this.ShowCompany();
            }
            if (e.ClickedItem.Text == "选择")
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColChoose].Value = !Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColChoose].Value);
                }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object NeuObject)
        {
            

            int chooseCount = 0;
            
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isChoose = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColChoose].Value);
                if (isChoose)
                {
                    chooseCount++;
                }
            }

            if (this.rbUnPay.Checked)
            {
                if (this.neuSpread1_Sheet1.RowCount == 0)
                {
                    MessageBox.Show("没有要结存的单据");
                    return -1;
                }
                else
                {
                    if (chooseCount == 0)
                    {
                        MessageBox.Show("请选择单据");
                        return -1;
                    }
                }
               
               
            }


            if (this.rbPay.Checked)
            {
                if (chooseCount == 0)
                {
                    //不提示
                }
                else
                {
                    MessageBox.Show(Language.Msg("已结存单据不能再次保存"), "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                return -1;
            }

            this.SavePay();

            this.Query(this.payFlag, this.dtBegin, this.dtEnd);

            return 1;
        }

        public override int Export(object sender, object NeuObject)
        {
            if (this.neuSpread2.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query(this.payFlag, dtBegin, dtEnd);

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 数据初始化
        /// </summary>
        protected void Init()
        {
            ArrayList al = new ArrayList();

            #region 银行

            Neusoft.HISFC.BizLogic.Manager.Constant constantManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            al = constantManager.GetList("BANK");
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取银行列表失败" + constantManager.Err));
                return;
            }
            bankHelper.ArrayObject = al;

            #endregion

            #region 人员

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            al = personManager.GetEmployeeAll();
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取所有人员列表" + personManager.Err));
                return;
            }
            this.personHelper.ArrayObject = al;

            #endregion

            #region 供货单位

            Neusoft.HISFC.BizLogic.Pharmacy.Constant constant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            this.alCompany = constant.QueryCompany("1");
            if (this.alCompany == null)
            {
                MessageBox.Show(constant.Err);
                return;
            }
            //{49390DE5-B54F-4b15-A012-208CDF288FF5}  可选择全部供货公司 增加银行列表选择功能
            Neusoft.HISFC.Models.Pharmacy.Company rootCompany = new Neusoft.HISFC.Models.Pharmacy.Company();
            rootCompany.ID = "AAAA";
            rootCompany.Name = "全部供货公司";

            this.alCompany.Insert(0, rootCompany);

            this.companyHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alCompany);

            #endregion

            Neusoft.FrameWork.Management.DataBaseManger dataBaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime sysTime = dataBaseManager.GetDateTimeFromSysDateTime().Date.AddDays(1);
            this.dtBegin = sysTime.AddDays(-30);
            this.dtEnd = sysTime;

            this.privOper = dataBaseManager.Operator;

            this.payFlag = "'0','1'";
        }

        /// <summary>
        /// 显示供货公司
        /// </summary>
        protected void ShowCompany()
        {         
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alCompany, ref info) == 0)
            {
                return;
            }
            else
            {
                this.Company = (Neusoft.HISFC.Models.Pharmacy.Company)info;

                this.Query(this.payFlag, this.dtBegin, this.dtEnd);
            }
        }

        /// <summary>
        /// 显示银行选择列表   //{49390DE5-B54F-4b15-A012-208CDF288FF5}  可选择全部供货公司
        /// </summary>
        protected void ShowBank(int rowIndex)
        {
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.bankHelper.ArrayObject, ref info) == 0)
            {
                return;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColPayHeadSet.ColOpenBank].Text = info.Name;
            }
        }

        /// <summary>
        /// 根据结存标记查询结存汇总信息
        /// </summary>
        /// <param name="payFlag">结存标记 0未付款  1已付款 2完成付款</param>
        /// <param name="dtBegin">查询起始时间</param>
        /// <param name="dtEnd">查询结束时间</param>
        public void Query(string payFlag, DateTime dtBegin, DateTime dtEnd)
        {
            if (this.company == null)
            {
                MessageBox.Show(Language.Msg("请选择供货公司"));
                return;
            }
            ArrayList al = new ArrayList();
            al = this.itemManager.QueryPayList(this.privDept.ID, this.company.ID, payFlag, dtBegin, dtEnd);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取结存汇总信息失败" + this.itemManager.Err));
                return;
            }

            this.payDetail = new ArrayList();
            this.neuSpread1_Sheet1.Rows.Count = 0;
            this.neuSpread2_Sheet1.Rows.Count = 0;
            Neusoft.HISFC.Models.Pharmacy.Pay info;

            for (int i = 0; i < al.Count; i++)
            {
                info = al[i] as Neusoft.HISFC.Models.Pharmacy.Pay;
                if (info == null)
                {
                    MessageBox.Show(Language.Msg("处理第" + (i + 1).ToString() + "行结存汇总信息出错"));
                    continue;
                }
                ArrayList alTemp = this.itemManager.QueryPayDetail(info.ID, info.InvoiceNO);
                if (alTemp == null)
                {
                    MessageBox.Show(Language.Msg("获取第" + (i + 1).ToString() + "行结存明细信息出错" + this.itemManager.Err));
                    continue;
                }
                if (alTemp.Count >= 0)
                {
                    this.payDetail.Add(alTemp);
                }

                this.AddPayHeadData(info);
            }
        }

        /// <summary>
        /// 向结存汇总信息FarPoint内加入数据
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        protected void AddPayHeadData(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            int rowCount = this.neuSpread1_Sheet1.Rows.Count;

            this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);

            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColChoose].Value = true;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInvoiceNo].Text = pay.InvoiceNO;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInvoiceDate].Value = pay.InvoiceTime;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInvoiceCost].Value = pay.PurchaseCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColDiscountCost].Value = pay.DisCountCost;
            //应付金额通过FarPoint公式自动设置
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColPaidUpCost].Value = pay.PayCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColPayCost].Value = pay.UnPayCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColDeliveryCost].Value = pay.DeliveryCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColPayType].Value = pay.PayType;

            if (pay.Company.OpenBank == null || pay.Company.OpenBank == "")
            {
                this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColOpenBank].Value = this.company.OpenBank;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColOpenBank].Value = pay.Company.OpenBank;
            }

            if (pay.Company.OpenAccounts == null || pay.Company.OpenAccounts == "")
            {
                this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColOpenAccounts].Value = this.company.OpenAccounts;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColOpenAccounts].Value = pay.Company.OpenAccounts;
            }

            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColDrugDept].Value = this.privDept.Name;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInListCode].Value = pay.InListNO;

            this.neuSpread1_Sheet1.Rows[rowCount].Tag = pay;
        }

        /// <summary>
        /// 向结存明细FarPoint内加入数据
        /// </summary>
        /// <param name="al">供货商结存实体数组</param>
        protected void AddPayDetailData(ArrayList al)
        {
            foreach (Neusoft.HISFC.Models.Pharmacy.Pay pay in al)
            {
                int rowCount = this.neuSpread2_Sheet1.Rows.Count;
                this.neuSpread2_Sheet1.Rows.Add(rowCount, 1);

                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColInvoiceNo].Value = pay.InvoiceNO;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayCost].Value = pay.PayCost;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColDeliveryCost].Value = pay.DeliveryCost;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayType].Value = pay.PayType;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColOpenBank].Value = pay.Company.OpenBank;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColOpenAccounts].Value = pay.Company.OpenAccounts;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayOper].Value = this.personHelper.GetName(pay.PayOper.ID);
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayDate].Text = pay.Oper.OperTime.ToString();

                this.neuSpread2_Sheet1.Rows[rowCount].Tag = pay;
            }
        }

        /// <summary>
        /// 显示供货商结存信息
        /// </summary>
        public void ShowPayDetail()
        {
            if (this.payDetail != null && this.payDetail.Count > 0)
            {
                this.neuSpread2_Sheet1.Rows.Count = 0;

                if (this.payDetail.Count <= this.neuSpread1_Sheet1.ActiveRowIndex)
                {
                    return;
                }

                this.AddPayDetailData(this.payDetail[this.neuSpread1_Sheet1.ActiveRowIndex] as ArrayList);
            }
        }

        /// <summary>
        /// 清屏操作
        /// </summary>
        public void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
            this.neuSpread2_Sheet1.Rows.Count = 0;
            this.lbCompany.Text = "结存单位：";
        }

        /// <summary>
        /// 保存有效性判断
        /// </summary>
        /// <returns>返回是否允许保存</returns>
        protected bool SaveValid()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return false;
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                decimal payCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColPayCost].Value);
                decimal due = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColDue].Value);
                decimal paidUp = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColPaidUpCost].Value);
                if (payCost > due - paidUp)
                {
                    MessageBox.Show(Language.Msg("发票号" + this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColInvoiceNo].Text + " 本次付款不能大于未付款金额"));
                    return false;
                }
                if (this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColPayType].Text == "支票")
                {
                    if (this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColOpenBank].Text == "")
                    {
                        MessageBox.Show(Language.Msg("发票号" + this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColInvoiceNo].Text + " 付款类型为支票时需填写开户银行"));
                        return false;
                    }
                    if (this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColOpenAccounts].Text == "")
                    {
                        MessageBox.Show(Language.Msg("发票号" + this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColInvoiceNo].Text + " 付款类型为支票时需填写银行帐号"));
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SavePay()
        {
            if (!this.SaveValid())
            {
                return -1;
            }

            DialogResult rs = MessageBox.Show("确认对当前选中的发票进行结存吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.Models.Pharmacy.Pay pay;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColChoose].Value == null || !((bool)this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColChoose].Value))
                {
                    continue;
                }

                pay = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.Pay;
                if (pay == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存操作过程中 发生类型转换错误"));
                    return -1;
                }
                //已结存 不再次处理
                if (pay.PayState == "2")
                {
                    continue;
                }

                if (pay.DisCountCost <= 0)
                {
                    //优惠金额
                    pay.DisCountCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColDiscountCost].Value);
                    pay.UnPayCost = pay.UnPayCost - pay.DisCountCost;		//未付金额
                }
                //运费
                pay.DeliveryCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColDeliveryCost].Value);
                pay.Oper.ID = this.privOper.ID;
                pay.Oper.OperTime = this.itemManager.GetDateTimeFromSysDateTime();

                if (this.itemManager.UpdateInsertPayHead(pay) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新供货商结存信息出错" + this.itemManager.Err));
                    return -1;
                }

                //付款类型
                pay.PayType = this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColPayType].Text;
                if (pay.PayType == "")
                {
                    pay.PayType = "现金";
                }

                //开户银行
                pay.Company.OpenBank = this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColOpenBank].Text;
                //银行帐号
                pay.Company.OpenAccounts = this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColOpenAccounts].Text;
                pay.PayOper.ID = this.privOper.ID;
                //本次付款
                pay.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColPayCost].Value);

                if (pay.PayCost == 0)
                {
                    continue;
                }

                pay.UnPayCost = pay.UnPayCost - pay.PayCost;

                if (this.itemManager.Pay(pay.ID, pay) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存供货商结存信息出错" + this.itemManager.Err));
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("保存成功"));
            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0314", ref testPrivDept);

                if (parma == -1)            //无权限
                {
                    MessageBox.Show(Language.Msg("您无此窗口操作权限"));
                    return;
                }
                else if (parma == 0)       //用户选择取消
                {
                    return;
                }

                this.privDept = testPrivDept;

                base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

                this.Init();

                this.rbPay.Visible = false;
                this.rbUnPay.Visible = false;
            }

            base.OnLoad(e);
        }

        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            // //{49390DE5-B54F-4b15-A012-208CDF288FF5}  可选择全部供货公司
            int rowIndex = this.neuSpread1_Sheet1.ActiveRowIndex;
            if (rowIndex >= 0)
            {
                Neusoft.HISFC.Models.Pharmacy.Pay info = this.neuSpread1_Sheet1.Rows[rowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.Pay;
                if (this.company != null && this.company.ID == "AAAA")
                {
                    this.lbCompany.Text = "结存单位：" + this.company.Name + "        当前：" + this.companyHelper.GetName(info.Company.ID);
                }
            }

            this.ShowPayDetail();
        }       

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //{49390DE5-B54F-4b15-A012-208CDF288FF5}  可选择全部供货公司
            if (e.Column == (int)ColPayHeadSet.ColOpenBank)
            {
                this.ShowBank(this.neuSpread1_Sheet1.ActiveRowIndex);
            }
        }

        private void rbUnPay_CheckedChanged(object sender, EventArgs e)
        {
            this.payFlag = "'0','1'";

            this.Query(null, null);
        }

        private void rbPay_CheckedChanged(object sender, EventArgs e)
        {
            this.payFlag = "2";

            this.Query(null, null);
        }

        #region 列枚举
        /// <summary>
        /// 结存汇总信息列设置
        /// </summary>
        enum ColPayHeadSet
        {
            /// <summary>
            /// 是否付款 0
            /// </summary>
            ColChoose,
            /// <summary>
            /// 发票号 1
            /// </summary>
            ColInvoiceNo,
            /// <summary>
            /// 发票日期	2
            /// </summary>
            ColInvoiceDate,
            /// <summary>
            /// 发票金额	3
            /// </summary>
            ColInvoiceCost,
            /// <summary>
            /// 优惠金额	4
            /// </summary>
            ColDiscountCost,
            /// <summary>
            /// 应付金额	5
            /// </summary>
            ColDue,
            /// <summary>
            /// 已付金额	6
            /// </summary>
            ColPaidUpCost,
            /// <summary>
            /// 本次付款	7
            /// </summary>
            ColPayCost,
            /// <summary>
            /// 运费		8
            /// </summary>
            ColDeliveryCost,
            /// <summary>
            /// 付款类型	9
            /// </summary>
            ColPayType,
            /// <summary>
            /// 开户银行	10
            /// </summary>
            ColOpenBank,
            /// <summary>
            /// 银行帐号	11
            /// </summary>
            ColOpenAccounts,
            /// <summary>
            /// 入库科室	12
            /// </summary>
            ColDrugDept,
            /// <summary>
            /// 入库单据号	13
            /// </summary>
            ColInListCode
        }
        /// <summary>
        /// 结存付款明细信息行列设置
        /// </summary>
        enum ColPayDetailSet
        {
            /// <summary>
            /// 发票号
            /// </summary>
            ColInvoiceNo,
            /// <summary>
            /// 付款金额
            /// </summary>
            ColPayCost,
            /// <summary>
            /// 运费
            /// </summary>
            ColDeliveryCost,
            /// <summary>
            /// 付款类型
            /// </summary>
            ColPayType,
            /// <summary>
            /// 开户银行
            /// </summary>
            ColOpenBank,
            /// <summary>
            /// 银行帐号
            /// </summary>
            ColOpenAccounts,
            /// <summary>
            /// 付款人
            /// </summary>
            ColPayOper,
            /// <summary>
            /// 付款日期
            /// </summary>
            ColPayDate
        }
        #endregion             
    }
}
