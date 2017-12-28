using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Material.Pay
{
    /// <summary>
    /// [功能描述: 供货商结存]
    /// [创 建 者: wangw]
    /// [创建时间: 2008-03]
    /// </summary>
    public partial class ucPay : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucPay()
        {
            InitializeComponent();
        }

        #region 字段

        /// <summary>
        /// 银行帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper bankHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 物资管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store matManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 结存明细信息
        /// </summary>
        private ArrayList alPayDetail = new ArrayList();

        /// <summary>
        /// 供货公司
        /// </summary>
        private Neusoft.HISFC.Models.Material.MaterialCompany company = new Neusoft.HISFC.Models.Material.MaterialCompany();

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper;

        /// <summary>
        /// 查询起始时间
        /// </summary>
        private DateTime dtBegin = System.DateTime.MinValue;

        /// <summary>
        /// 查询终止时间
        /// </summary>
        private DateTime dtEnd = System.DateTime.MaxValue;

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

        protected Neusoft.HISFC.Models.Material.MaterialCompany Company
        {
            set
            {
                if(value == null)
                {
                    this.company = new Neusoft.HISFC.Models.Material.MaterialCompany();
                }
                else
                {
                    this.company = value;
                }
                this.lbCompany.Text = "结存单位" + this.company.Name;
            }
        }

        #endregion

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 方法

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("时  间", "设置查询时间", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询历史, true, false, null);
            toolBarService.AddToolButton("已结存查询", "已结存单据查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A安排, true, false, null);
            toolBarService.AddToolButton("未结存查询", "未结存单据查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.P盘点结存解封, true, false, null);
            toolBarService.AddToolButton("供货单位", "选择查询的供货单位", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J集体, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "时  间")
            {
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref this.dtBegin, ref dtEnd) == 0)
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
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object NeuObject)
        {
            if (this.rbPay.Checked)
            {
                MessageBox.Show(Language.Msg("已结存单据不能再次保存"), "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            ArrayList al = new ArrayList();

            #region 银行信息

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

            #region 供应商

            Neusoft.HISFC.BizLogic.Material.ComCompany companyManager = new Neusoft.HISFC.BizLogic.Material.ComCompany();

            this.alCompany = companyManager.QueryCompany("1", "A");

            if (this.alCompany == null)
            {
                MessageBox.Show(constantManager.Err);
                return;
            }

            #endregion

            #region 时间

            Neusoft.FrameWork.Management.DataBaseManger databaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime sysTime = databaseManager.GetDateTimeFromSysDateTime().Date.AddDays(1);
            this.dtBegin = sysTime.AddDays(-30);
            this.dtEnd = sysTime;

            this.privOper = databaseManager.Operator;

            this.payFlag = "'0','1'";

            #endregion

        }

        protected void ShowCompany()
        {
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alCompany, ref info) == 0)
            {
                return;
            }
            else
            {
                this.Company = (Neusoft.HISFC.Models.Material.MaterialCompany)info;

                this.Query(this.payFlag, this.dtBegin, this.dtEnd);
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
            al = this.matManager.QueryPayList(this.privDept.ID, this.company.ID, payFlag, dtBegin, dtEnd);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取结存汇总信息失败" + this.matManager.Err));
                return;
            }

            this.alPayDetail = new ArrayList();
            this.neuSpread1_Sheet1.Rows.Count = 0;
            this.neuSpread2_Sheet1.Rows.Count = 0;
            Neusoft.HISFC.Models.Material.Pay info;

            for (int i = 0; i < al.Count; i++)
            {
                info = al[i] as Neusoft.HISFC.Models.Material.Pay;
                if (info == null)
                {
                    MessageBox.Show(Language.Msg("处理第" + (i + 1).ToString() + "行结存汇总信息出错"));
                    continue;
                }
                ArrayList alTemp = this.matManager.QueryPayDetail(info.ID, info.InvoiceNo);
                if (alTemp == null)
                {
                    MessageBox.Show(Language.Msg("获取第" + (i + 1).ToString() + "行结存明细信息出错" + this.matManager.Err));
                    continue;
                }
                if (alTemp.Count > 0)
                {
                    this.alPayDetail.Add(alTemp);
                }

                this.AddPayHeadData(info);
            }
        }

        /// <summary>
        /// 向结存汇总信息FarPoint内加入数据
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        protected void AddPayHeadData(Neusoft.HISFC.Models.Material.Pay pay)
        {
            int rowCount = this.neuSpread1_Sheet1.Rows.Count;

            this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);

            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColChoose].Value = true;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInvoiceNo].Text = pay.InvoiceNo;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInvoiceDate].Value = pay.InvoiceTime;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInvoiceCost].Value = pay.PurchaseCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColDiscountCost].Value = pay.DiscountCost;
            //应付金额通过FarPoint公式自动设置
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColPaidUpCost].Value = pay.PayCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColPayCost].Value = pay.UnpayCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColDeliveryCost].Value = pay.DeliveryCost;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColPayType].Value = pay.PayType;
            if (pay.Company.OpenBank == null || pay.Company.OpenBank == "")
                this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColOpenBank].Value = this.company.OpenBank;
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
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColDept].Value = this.privDept.Name;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColInListCode].Value = pay.InListCode;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColUnpayCredence].Value = pay.UnpayCredence;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColUnpayCredence].Locked = false;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColUnpayCredence].BackColor = System.Drawing.Color.SeaShell;

            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColUnCredenceDate].Value = pay.UnpayCredenceTime;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColUnCredenceDate].Locked = false;
            this.neuSpread1_Sheet1.Cells[rowCount, (int)ColPayHeadSet.ColUnCredenceDate].BackColor = System.Drawing.Color.SeaShell;

            this.neuSpread1_Sheet1.Rows[rowCount].Tag = pay;
        }

        /// <summary>
        /// 向结存明细FarPoint内加入数据
        /// </summary>
        /// <param name="al">供货商结存实体数组</param>
        protected void AddPayDetailData(ArrayList al)
        {
            foreach (Neusoft.HISFC.Models.Material.Pay pay in al)
            {
                int rowCount = this.neuSpread2_Sheet1.Rows.Count;
                this.neuSpread2_Sheet1.Rows.Add(rowCount, 1);

                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColInvoiceNo].Value = pay.InvoiceNo;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayCost].Value = pay.PayCost;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColDeliveryCost].Value = pay.DeliveryCost;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayType].Text = pay.PayType;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColOpenBank].Value = pay.Company.OpenBank;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColOpenAccounts].Value = pay.Company.OpenAccounts;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayOper].Value = this.personHelper.GetName(pay.PayOper.ID);
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayDate].Text = pay.Oper.OperTime.ToString();


                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColInvoiceNo].Locked = true;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayCost].Locked = true;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColDeliveryCost].Locked = true;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayType].Locked = true;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColOpenBank].Locked = true;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColOpenAccounts].Locked = true;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayOper].Locked = true;
                this.neuSpread2_Sheet1.Cells[rowCount, (int)ColPayDetailSet.ColPayDate].Locked = true;
                this.neuSpread2_Sheet1.Rows[rowCount].Tag = pay;
            }
        }

        /// <summary>
        /// 显示供货商结存信息
        /// </summary>
        public void ShowPayDetail()
        {
            if (this.alPayDetail != null && this.alPayDetail.Count > 0)
            {
                this.neuSpread2_Sheet1.Rows.Count = 0;

                if (this.alPayDetail.Count <= this.neuSpread1_Sheet1.ActiveRowIndex)
                {
                    return;
                }

                this.AddPayDetailData(this.alPayDetail[this.neuSpread1_Sheet1.ActiveRowIndex] as ArrayList);
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

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.matManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.Models.Material.Pay pay;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColChoose].Value == null || !((bool)this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColChoose].Value))
                    continue;

                pay = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Material.Pay;
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

                if (pay.DiscountCost <= 0)
                {
                    //优惠金额
                    pay.DiscountCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColDiscountCost].Value);
                    pay.UnpayCost = pay.UnpayCost - pay.DiscountCost;		//未付金额
                }
                //运费
                pay.DeliveryCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColDeliveryCost].Value);
                pay.Oper.ID = this.privOper.ID;
                pay.Oper.OperTime = this.matManager.GetDateTimeFromSysDateTime();

                if (this.matManager.UpdateInsertPayHead(pay) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新供货商结存信息出错" + this.matManager.Err));
                    return -1;
                }

                //付款类型
                pay.PayType = this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColPayType].Text;
                if (pay.PayType == "")
                    pay.PayType = "现金";
                //开户银行
                pay.Company.OpenBank = this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColOpenBank].Text;
                //银行帐号
                pay.Company.OpenAccounts = this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColOpenAccounts].Text;
                pay.PayOper.ID = this.privOper.ID;
                //本次付款
                pay.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColPayCost].Value);
                //未付款凭证
                pay.UnpayCredence = this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColUnpayCredence].Text;
                //未付款凭证日期
                pay.UnpayCredenceTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[i, (int)ColPayHeadSet.ColUnCredenceDate].Text);

                if (pay.PayCost == 0)
                    continue;

                pay.UnpayCost = pay.UnpayCost - pay.PayCost;

                if (this.matManager.Pay(pay.ID, pay) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存供货商结存信息出错" + this.matManager.Err));
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
                //Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0514", ref testPrivDept);

                //if (parma == -1)            //无权限
                //{
                //    MessageBox.Show(Language.Msg("您无此窗口操作权限"));
                //    return;
                //}
                //else if (parma == 0)       //用户选择取消
                //{
                //    return;
                //}

                //this.privDept = testPrivDept;

                //base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

                this.Init();
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// 未付款账单打印 {54092BCA-BDA1-45e8-A7C6-777282653264}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Print(object sender, object neuObject)
        {
            if (this.neuSpread1_Sheet1.RowCount <= 0)
            {
                MessageBox.Show("请先查询再打印！");

                return -1;
            }

            string strTime = dtBegin.ToString() + "--" + dtEnd.ToString();
            List<Neusoft.HISFC.Models.Material.Pay> payList = new List<Neusoft.HISFC.Models.Material.Pay>();
            foreach (FarPoint.Win.Spread.Row r in this.neuSpread1_Sheet1.Rows)
            {
                Neusoft.HISFC.Models.Material.Pay pay = r.Tag as Neusoft.HISFC.Models.Material.Pay;
                payList.Add(pay);
            }

            Neusoft.HISFC.Components.Material.Pay.ucUnpayListPrint ucPrint = new Neusoft.HISFC.Components.Material.Pay.ucUnpayListPrint();
            ucPrint.SetPrintValue(strTime, this.company, this.privDept.Name, payList);
            ucPrint.Print();

            return base.Print(sender, neuObject);
        }


        #endregion
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
            ColDept,
            /// <summary>
            /// 入库单据号	13
            /// </summary>
            ColInListCode,
            /// <summary>
            /// 未付款凭证
            /// </summary>
            ColUnpayCredence,
            /// <summary>
            /// 未付款凭证日期
            /// </summary>
            ColUnCredenceDate
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

        private void neuSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.ShowPayDetail();
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

        #region IPreArrange 成员

        public int PreArrange()
        {
            Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0514", ref testPrivDept);

            if (parma == -1)            //无权限
            {
                MessageBox.Show(Language.Msg("您无此窗口操作权限"));
                return -1;
            }
            else if (parma == 0)       //用户选择取消
            {
                return -1;
            }

            this.privDept = testPrivDept;

            base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

            return 1;
        }

        #endregion
    }
}
