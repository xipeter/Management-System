using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [功能描述: 一般入库信息登记组件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// 待完成:
    ///     不显示项目列表时 右侧维护控件显示优化
    /// </summary>
    public partial class ucCommonInDetail : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCommonInDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 事件触发
        /// </summary>
        /// <param name="sender">sender说明 User01 标志是否处理焦点 -1  不处理焦点 User02 标志是否为手工选择药品 1 手工选择 0 非手工选择</param>
        public delegate void InstanceCompleteHandler(ref Neusoft.FrameWork.Models.NeuObject sender);

        public event InstanceCompleteHandler InInstanceCompleteEvent;

        public event InstanceCompleteHandler ClearPriKey;

        #region 域 变 量

        /// <summary>
        /// 是否按批号管理
        /// </summary>
        private bool isManagerBatchNO = true;

        /// <summary>
        /// 是否关联发票分类
        /// </summary>
        private bool isManagerInvoiceType = false;

        /// <summary>
        /// 是否管理生产厂家/生产日期
        /// </summary>
        private bool isManagerFac = false;

        /// <summary>
        /// 是否处理扩展信息
        /// </summary>
        private bool isManagerExtend = false;

        /// <summary>
        /// 一般入库时 是否默认上次发票信息
        /// </summary>
        private bool isDefaultPrivInvoiceNO = true;

        /// <summary>
        /// 当前操作的入库药品实例
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item item = null;

        /// <summary>
        /// 当前操作的入库实例
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Input inInstance = null;

        /// <summary>
        /// 是否已进行了初始化
        /// </summary>
        private bool isInit = false;

        /// <summary>
        /// 正常状态下列表宽度
        /// </summary>
        private int privItemListWidth = 250;

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = null;

        #endregion

        #region 属    性

        /// <summary>
        /// 是否按批号管理
        /// </summary>
        public bool IsManagerBatchNO
        {
            get
            {
                return this.isManagerBatchNO;
            }
            set
            {
                this.isManagerBatchNO = value;
            }
        }

        /// <summary>
        /// 是否管理发票分类
        /// </summary>
        public bool IsManagerInvoiceType
        {
            get
            {
                return this.isManagerInvoiceType;
            }
            set
            {
                this.isManagerInvoiceType = value;
            }
        }

        /// <summary>
        /// 是否管理生产厂家/生产日期
        /// </summary>
        public bool IsManagerFac
        {
            get
            {
                return this.isManagerFac;
            }
            set
            {
                this.isManagerFac = value;
            }
        }

        /// <summary>
        /// 是否处理扩展信息
        /// </summary>
        public bool IsManagerExtend
        {
            get
            {
                return this.isManagerExtend;
            }
            set
            {
                this.isManagerExtend = value;
            }
        }

        /// <summary>
        /// 是否显示项目选择列表
        /// </summary>
        public bool IsShowItemSelect
        {
            get
            {
                return !this.splitContainer1.Panel1Collapsed;
            }
            set
            {
                this.splitContainer1.Panel1Collapsed = !value;
            }
        }

        /// <summary>
        /// 是否处理购入价信息
        /// </summary>
        public bool IsManagerPurchasePrice
        {
            get
            {
                return this.ntbPurchasePrice.Enabled;
            }
            set
            {
                this.ntbPurchasePrice.Enabled = value;
            }
        }

        /// <summary>
        /// 一般入库时 是否默认上次发票信息
        /// </summary>
        public bool IsDefaultPrivInvoiceNO
        {
            get
            {
                return this.isDefaultPrivInvoiceNO;
            }
            set
            {
                this.isDefaultPrivInvoiceNO = value;
            }
        }

        /// <summary>
        /// 权限科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PrivDept
        {
            get
            {
                return this.privDept;
            }
            set
            {
                this.privDept = value;
            }
        }

        #endregion

        /// <summary>
        /// 当前操作的入库药品实例
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
        {
            set
            {
                this.Clear(true);

                this.item = value;

                if (value != null)
                {
                    this.SetItem(value);
                }
            }
        }

        /// <summary>
        /// 当前操作的入库实例
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Input InInstance
        {
            get
            {
                if (this.inInstance == null)
                {
                    this.inInstance = new Neusoft.HISFC.Models.Pharmacy.Input();
                }

                this.GetInInstance();

                return this.inInstance;
            }
            set
            {
                this.Clear(true);

                this.inInstance = value;

                if (value != null)
                {
                    this.SetInInstance(value);

                    this.item = value.Item;
                }
            }
        }

        #region 初 始 化

        /// <summary>
        /// 初始化
        /// </summary>
        public  virtual void Init()
        {
            if (!isInit)
            {
                this.ucDrugList1.ShowPharmacyList();    //加载药品列表

                Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
                System.Collections.ArrayList alInvoiceType = consManager.GetList("InvoiceType");

                this.cmbInvoiceType.AddItems(alInvoiceType);

                Neusoft.HISFC.BizLogic.Pharmacy.Constant phaCons = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                System.Collections.ArrayList alProduce = phaCons.QueryCompany("0");
                this.cmbProduce.AddItems(alProduce);

                isInit = true;                          //已进行了初始化
            }
        }

        #endregion

        #region 方    法

        /// <summary>
        /// 根据药品信息设置界面显示
        /// </summary>
        /// <param name="item">药品信息</param>
        private void SetItem(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            this.lbDrugName.Text = string.Format("商品名称 {0}  规格 {1}",item.Name,item.Specs);

            this.lbDrugPackInfo.Text = string.Format("零 售 价 {0} 包装数量 {1} 包装单位 {2} 最小单位 {3}", 
                item.PriceCollection.RetailPrice.ToString(), item.PackQty.ToString(), item.PackUnit, item.MinUnit);

            this.lbUnit.Text = item.PackUnit;

            //购 入 价
            this.ntbPurchasePrice.Text = item.PriceCollection.PurchasePrice.ToString();

            this.cmbProduce.Tag = item.Product.Producer.ID;
        }

        /// <summary>
        /// 根据入库信息设置界面显示
        /// </summary>
        /// <param name="input">入库信息</param>
        private void SetInInstance(Neusoft.HISFC.Models.Pharmacy.Input inInstance)
        {
            this.SetItem(inInstance.Item);

            //入库数量
            this.ntbInQty.Text = Math.Round(inInstance.Quantity / inInstance.Item.PackQty,2).ToString("N");
            //入库金额
            this.ntbInCost.Text = inInstance.RetailCost.ToString();
            //零售金额
            this.ntbPurchaseCost.Text = inInstance.PurchaseCost.ToString();
            //批    号
            this.txtBatchNO.Text = inInstance.BatchNO;
            //有 效 期
            this.dtValidTime.Value = inInstance.ValidTime;
            if (inInstance.InvoiceNO != "" && inInstance.InvoiceNO != null)
            {
                //发 票 号
                this.txtInvoiceNO.Text = inInstance.InvoiceNO;
            }
            //发票分类
            this.cmbInvoiceType.Text = inInstance.InvoiceType;
            //购 入 价
            this.ntbPurchasePrice.Text = inInstance.Item.PriceCollection.PurchasePrice.ToString();
            //生产厂家
            this.cmbProduce.Text = inInstance.Item.Product.Producer.Name;
            this.cmbProduce.Tag = inInstance.Item.Product.Producer.ID;
            //送货单号
            this.txtDeliveryNO.Text = inInstance.DeliveryNO;
            //货位号
            this.txtPlaceNO.Text = inInstance.PlaceNO;
            //备注
            this.txtMemo.Text = inInstance.Memo;
        }

        /// <summary>
        /// 获取输入的入库信息
        /// </summary>
        private void GetInInstance()
        {
            if (this.inInstance == null)
                this.inInstance = new Neusoft.HISFC.Models.Pharmacy.Input();

            if (this.item == null || this.item.ID == "")
                return;

            this.inInstance.Item = this.item;                               //药品信息
            this.inInstance.Quantity = NConvert.ToDecimal(this.ntbInQty.NumericValue) * this.item.PackQty;          //入库数量
            this.inInstance.RetailCost = NConvert.ToDecimal(this.ntbInCost.NumericValue);       //入库金额
            this.inInstance.BatchNO =  Neusoft.FrameWork.Public.String.TakeOffSpecialChar( this.txtBatchNO.Text.Trim());                  //批    号
            this.inInstance.ValidTime = this.dtValidTime.Value.Date;                     //有 效 期
            this.inInstance.InvoiceNO = Neusoft.FrameWork.Public.String.TakeOffSpecialChar( this.txtInvoiceNO.Text.Trim());              //发 票 号
            this.inInstance.InvoiceType = this.cmbInvoiceType.Text.Trim();          //发票分类
            this.inInstance.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.ntbPurchasePrice.NumericValue);     //购入价
            if (this.cmbProduce.Tag != null)                                //生产厂家
            {
                //{3F6FF86C-0C62-44de-B09B-595B297DD832}
                this.inInstance.Producer.ID = this.cmbProduce.Tag.ToString();
                this.inInstance.Producer.Name = this.cmbProduce.Text.Trim();

                //{C03DD304-AE71-4b6a-BC63-F385DB162EB7}
                this.inInstance.Item.Product.Producer.ID = this.cmbProduce.Tag.ToString();
                this.inInstance.Item.Product.Producer.Name = this.cmbProduce.Text.Trim();
            }
            this.inInstance.DeliveryNO = this.txtDeliveryNO.Text.Trim();           //送货单号
            this.inInstance.PlaceNO = Neusoft.FrameWork.Public.String.TakeOffSpecialChar( this.txtPlaceNO.Text.Trim());                 //货位号
            this.inInstance.Memo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar( this.txtMemo.Text);                       //备注
        }

        /// <summary>
        /// 输入有效性判断
        /// </summary>
        /// <returns>无错误返回True 否则返回False</returns>
        private bool Valid()
        {
            //if (this.txtBatchNO.Text == "")
            //{
            //    MessageBox.Show(Language.Msg("请输入批号"));
            //    return false;
            //}
            if (NConvert.ToDecimal(this.ntbInQty.Text) <= 0)
            {
                MessageBox.Show(Language.Msg("请正确输入入库数量 入库数量应大于等于零"));
                this.errorProvider1.SetError(this.ntbInQty, "入库数量必须输入且大于0");
                this.ntbInQty.Focus();
                return false;
            }
            else
            {
                this.errorProvider1.Clear();
            }
            return true;
        }

        /// <summary>
        /// 入库金额计算
        /// </summary>
        private void ComputeCost()
        {
            if (this.item == null)
            {
                MessageBox.Show("请选择待入库药品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal qty = NConvert.ToDecimal(this.ntbInQty.Text);
            this.ntbInCost.Text = (qty * this.item.PriceCollection.RetailPrice).ToString();

            decimal purchasePrice = NConvert.ToDecimal(this.ntbPurchasePrice.Text);
            if (purchasePrice != 0)
                this.ntbPurchaseCost.NumericValue = qty * purchasePrice;
            else
                this.ntbPurchaseCost.Text = (qty * this.item.PriceCollection.PurchasePrice).ToString();
        }

        /// <summary>
        /// 清屏
        /// </summary>
        /// <param name="clearDrugInfo">是否清除显示的药品基本信息</param>
        public void Clear(bool clearDrugInfo)
        {
            if (clearDrugInfo)
            {
                this.lbDrugName.Text = "商品名称    规格 "; 
                this.lbDrugPackInfo.Text = "零 售 价   包装数量   包装单位   最小单位 ";
                this.lbUnit.Text = "单位";
                //购 入 价
                this.ntbPurchasePrice.NumericValue = 0;
            }
            //入库数量
            this.ntbInQty.NumericValue = 0;
            //入库金额
            this.ntbInCost.NumericValue = 0;
            //批    号
            this.txtBatchNO.Text = "";
            if (!this.isDefaultPrivInvoiceNO)
            {        //发 票 号
                this.txtInvoiceNO.Text = "";
            }
            //发票分类
            this.cmbInvoiceType.Text = "";
            //购 入 价
            this.ntbPurchasePrice.NumericValue = 0;
            //生产厂家
            this.cmbProduce.Text = "";
            this.cmbProduce.Tag = null;
            //送货单号
            this.txtDeliveryNO.Text = "";
            //货位号
            this.txtPlaceNO.Text = "";
            //备注
            this.txtMemo.Text = "";
        }

        /// <summary>
        /// 设置焦点
        /// </summary>
        public new void Focus()
        {
            this.ucDrugList1.SetFocusSelect();
        }      

        #endregion

        private void ntbInQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.Valid())
                {
                    this.ComputeCost();
                    if (this.isManagerBatchNO)
                        this.txtBatchNO.Focus();
                    else
                        this.dtValidTime.Focus();
                }
            }
        }

        private void txtBatchNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dtValidTime.Focus();
            }
        }

        private void dtValidTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtInvoiceNO.Focus();
            }
        }

        private void txtInvoiceNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.isManagerInvoiceType)
                    this.cmbInvoiceType.Focus();
                else
                    this.ntbPurchasePrice.Focus();

                if (!this.IsManagerPurchasePrice)
                {
                    KeyEventArgs eKey = new KeyEventArgs(Keys.Enter);
                    this.ntbPurchasePrice_KeyDown(this.ntbPurchasePrice, eKey);
                }
            }
        }

        private void comInvoiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ntbPurchasePrice.Focus();
            }
        }

        private void ntbPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (NConvert.ToDecimal(this.ntbPurchasePrice.Text) <= 0)
                {
                    MessageBox.Show(Language.Msg("请正确输入购入价 购入价应大于等于零"));
                    this.errorProvider1.SetError(this.ntbPurchasePrice, "购入价必须输入且大于0");
                    this.ntbPurchasePrice.Focus();
                    return;
                }
                else
                {
                    this.errorProvider1.Clear();
                }

                this.ComputeCost();
                if (this.isManagerFac)
                    this.cmbProduce.Focus();
                else if (this.isManagerExtend)
                    this.txtDeliveryNO.Focus();
                else
                    this.btnOK.Focus();
            }
        }

        private void comboProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.isManagerExtend)
                    this.txtDeliveryNO.Focus();
                else
                    this.btnOK.Focus();
            }
        }

        private void txtDeliveryNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject msg = new Neusoft.FrameWork.Models.NeuObject();

            if (this.item == null)
            {
                return;
            }

            if (this.InInstance.BatchNO == "")
            {
                MessageBox.Show(Language.Msg("请输入批号"));
                this.txtBatchNO.Focus();
                return;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtBatchNO.Text.Trim(), 16))
            {
                MessageBox.Show(Language.Msg("批号过长:不能多于16位"));
                this.txtBatchNO.Focus();
                return;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtPlaceNO.Text.Trim(), 16))
            {
                MessageBox.Show(Language.Msg("货位号过长:不能多于16位"));
                this.txtPlaceNO.Focus();
                return;
            }
            ///
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtInvoiceNO.Text.Trim(), 10))
            {
                MessageBox.Show(Language.Msg("发票过长:不能多于10位"));
                this.txtInvoiceNO.Focus();
                return;
            }

            if (this.InInstanceCompleteEvent != null)
            {
                if (this.item.User01 == "1")    //手工选择药品
                {
                    this.item.User01 = "";
                    msg.User02 = "1";
                }
                else                           //非手工选择药品 
                {
                    msg.User02 = "0";
                }              

                this.InInstanceCompleteEvent(ref msg);
            }
            //根据该值是否发生变化 来决定是否设置焦点
            if (msg.User01 != "-1")
            {
                this.Focus();
            }
        }

        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (sv != null && activeRow >= 0)
            {
                string drugID;
                drugID = sv.Cells[activeRow, 0].Value.ToString();
                //取药品字典信息
                Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                this.item = itemManager.GetItem(drugID);
                if (this.item != null)
                {
                    //{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}  协定处方校验 对于未维护明细的协定处方，不能进行入库操作
                    if (this.item.IsNostrum == true)
                    {
                        List<Neusoft.HISFC.Models.Pharmacy.Nostrum> nostrumList = itemManager.QueryNostrumDetail( this.item.ID );
                        if (nostrumList == null || nostrumList.Count <= 0)
                        {
                            MessageBox.Show( this.item.Name + " 为协定处方，但尚未进行明细内容维护，不能进行入库操作" );
                            return;
                        }
                    }
                    this.Clear(true);
                    //标志是否已新加的药品 
                    this.item.User01 = "1";

                    if (Function.SetPrice(this.privDept.ID, this.item.ID, ref this.item) == -1)
                    {
                        return;
                    }

                    //添加数据
                    this.SetItem(this.item);

                    this.ntbInQty.Focus();

                    //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                    //双击清空键值
                    if (this.ClearPriKey != null)
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                        this.ClearPriKey(ref obj);
                    }
                }
                else
                {
                    MessageBox.Show(Language.Msg("检索药品基本信息失败"));
                    this.ucDrugList1.SetFocusSelect();
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                this.btnOK_Click(null, System.EventArgs.Empty);
            }
            if (keyData == Keys.F6)
            {
                this.ucDrugList1.Select();
                this.ucDrugList1.SetFocusSelect();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnShowItemSelectPanel_Click(object sender, EventArgs e)
        {
            this.ucDrugList1.Visible = true;

            this.btnShowItemSelectPanel.Visible = false;

            this.splitContainer1.SplitterDistance = this.privItemListWidth;                     
        }

        private void ucDrugList1_CloseClickEvent(object sender, System.EventArgs e)
        {
            this.ucDrugList1.Visible = false;

            this.btnShowItemSelectPanel.Visible = true;

            this.privItemListWidth = this.splitContainer1.SplitterDistance;

            this.splitContainer1.SplitterDistance = this.btnShowItemSelectPanel.Width + 1;
        }

    }
}
