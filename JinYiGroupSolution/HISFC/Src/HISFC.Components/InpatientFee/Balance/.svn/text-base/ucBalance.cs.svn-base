using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using Neusoft.HISFC.Models.Fee;
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.BizProcess.Integrate.FeeInterface;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.InpatientFee.Balance
{
    /// <summary>
    /// ucBalance<br></br>
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
    public partial class ucBalance : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISIReadCard, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucBalance()
        {
            this.InitializeComponent();
        }
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlUp;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlDown;
        protected Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblFeeDate;
        protected Neusoft.FrameWork.WinForms.Controls.NeuButton btnExecute;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblReach;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblDerate;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtDeratefee;
        private System.Windows.Forms.Panel pnlMidUp;
        protected Neusoft.FrameWork.WinForms.Controls.NeuSpread fpCost;
        private FarPoint.Win.Spread.SheetView fpCost_Sheet1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuSpread fpPrepay;
        private FarPoint.Win.Spread.SheetView fpPrepay_Sheet1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtBalanceCost;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel llblBalanceCost;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtOwnTot;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblOwnCost;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPubTot;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblPubCost;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPrepayCost;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblPrepayCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlMidDown;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpPayType;
        private FarPoint.Win.Spread.SheetView fpPayType_Sheet1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPay;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblPay;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtShouldPay;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblShouldPay;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtCharge;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCharge;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblPatientInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbPayType;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtRebateFee;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblRebateFee;
        protected Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEnd;
        protected Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuListTextBox neuListTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblMannal;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtMannalCost;
        protected Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox neuNumericTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlMain;

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            this.pnlMain = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.pnlDown = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.pnlMidDown = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpPayType = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpPayType_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.gbPayType = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lblShouldPay = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtShouldPay = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtPay = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblPay = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtMannalCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtCharge = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuNumericTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblMannal = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblCharge = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuListTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuListTextBox();
            this.pnlMidUp = new System.Windows.Forms.Panel();
            this.txtPrepayCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblPrepayCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtOwnTot = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblOwnCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtPubTot = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblPubCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtBalanceCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.llblBalanceCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fpPrepay = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpPrepay_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpCost = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpCost_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlUp = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnExecute = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.ucQueryInpatientNo = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.lblReach = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblFeeDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtDeratefee = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblDerate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.txtRebateFee = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblPatientInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblRebateFee = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.pnlMain.SuspendLayout();
            this.pnlDown.SuspendLayout();
            this.pnlMidDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpPayType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPayType_Sheet1)).BeginInit();
            this.gbPayType.SuspendLayout();
            this.pnlMidUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpPrepay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPrepay_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCost_Sheet1)).BeginInit();
            this.pnlUp.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlMain.Controls.Add(this.pnlDown);
            this.pnlMain.Controls.Add(this.pnlUp);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(784, 578);
            this.pnlMain.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDown
            // 
            this.pnlDown.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDown.Controls.Add(this.pnlMidDown);
            this.pnlDown.Controls.Add(this.pnlMidUp);
            this.pnlDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDown.Location = new System.Drawing.Point(0, 88);
            this.pnlDown.Name = "pnlDown";
            this.pnlDown.Size = new System.Drawing.Size(784, 490);
            this.pnlDown.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlDown.TabIndex = 1;
            // 
            // pnlMidDown
            // 
            this.pnlMidDown.Controls.Add(this.fpPayType);
            this.pnlMidDown.Controls.Add(this.gbPayType);
            this.pnlMidDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidDown.Location = new System.Drawing.Point(0, 289);
            this.pnlMidDown.Name = "pnlMidDown";
            this.pnlMidDown.Size = new System.Drawing.Size(784, 201);
            this.pnlMidDown.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlMidDown.TabIndex = 99;
            // 
            // fpPayType
            // 
            this.fpPayType.About = "3.0.2004.2005";
            this.fpPayType.AccessibleDescription = "fpPayType, Sheet1, Row 0, Column 0, ";
            this.fpPayType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fpPayType.BackColor = System.Drawing.SystemColors.Control;
            this.fpPayType.FileName = "";
            this.fpPayType.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpPayType.IsAutoSaveGridStatus = false;
            this.fpPayType.IsCanCustomConfigColumn = false;
            this.fpPayType.Location = new System.Drawing.Point(6, 61);
            this.fpPayType.Name = "fpPayType";
            this.fpPayType.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpPayType_Sheet1});
            this.fpPayType.Size = new System.Drawing.Size(769, 137);
            this.fpPayType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpPayType.TabIndex = 90;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpPayType.TextTipAppearance = tipAppearance1;
            this.fpPayType.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpPayType.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpPayType_CellClick);
            // 
            // fpPayType_Sheet1
            // 
            this.fpPayType_Sheet1.Reset();
            this.fpPayType_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpPayType_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpPayType_Sheet1.ColumnCount = 6;
            this.fpPayType_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "支付方式";
            this.fpPayType_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "金额";
            this.fpPayType_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "开户银行";
            this.fpPayType_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "开户帐号";
            this.fpPayType_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "开据单位";
            this.fpPayType_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "支票号/交易流水号";
            this.fpPayType_Sheet1.Columns.Get(0).Label = "支付方式";
            this.fpPayType_Sheet1.Columns.Get(0).Width = 103F;
            currencyCellType1.DecimalPlaces = 2;
            this.fpPayType_Sheet1.Columns.Get(1).CellType = currencyCellType1;
            this.fpPayType_Sheet1.Columns.Get(1).Label = "金额";
            this.fpPayType_Sheet1.Columns.Get(1).Width = 72F;
            this.fpPayType_Sheet1.Columns.Get(2).Label = "开户银行";
            this.fpPayType_Sheet1.Columns.Get(2).Width = 124F;
            this.fpPayType_Sheet1.Columns.Get(3).Label = "开户帐号";
            this.fpPayType_Sheet1.Columns.Get(3).Width = 96F;
            this.fpPayType_Sheet1.Columns.Get(4).Label = "开据单位";
            this.fpPayType_Sheet1.Columns.Get(4).Width = 86F;
            this.fpPayType_Sheet1.Columns.Get(5).Label = "支票号/交易流水号";
            this.fpPayType_Sheet1.Columns.Get(5).Width = 122F;
            this.fpPayType_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpPayType_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpPayType_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpPayType_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpPayType.SetViewportTopRow(0, 0, 12);
            // 
            // gbPayType
            // 
            this.gbPayType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPayType.Controls.Add(this.lblShouldPay);
            this.gbPayType.Controls.Add(this.txtShouldPay);
            this.gbPayType.Controls.Add(this.txtPay);
            this.gbPayType.Controls.Add(this.lblPay);
            this.gbPayType.Controls.Add(this.txtMannalCost);
            this.gbPayType.Controls.Add(this.txtCharge);
            this.gbPayType.Controls.Add(this.neuNumericTextBox1);
            this.gbPayType.Controls.Add(this.lblMannal);
            this.gbPayType.Controls.Add(this.lblCharge);
            this.gbPayType.Controls.Add(this.neuListTextBox1);
            this.gbPayType.ForeColor = System.Drawing.Color.Black;
            this.gbPayType.Location = new System.Drawing.Point(3, 6);
            this.gbPayType.Name = "gbPayType";
            this.gbPayType.Size = new System.Drawing.Size(778, 195);
            this.gbPayType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbPayType.TabIndex = 14;
            this.gbPayType.TabStop = false;
            this.gbPayType.Text = "补收款项";
            // 
            // lblShouldPay
            // 
            this.lblShouldPay.AutoSize = true;
            this.lblShouldPay.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShouldPay.ForeColor = System.Drawing.Color.Blue;
            this.lblShouldPay.Location = new System.Drawing.Point(12, 24);
            this.lblShouldPay.Name = "lblShouldPay";
            this.lblShouldPay.Size = new System.Drawing.Size(111, 19);
            this.lblShouldPay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblShouldPay.TabIndex = 8;
            this.lblShouldPay.Text = "补交(自费)";
            // 
            // txtShouldPay
            // 
            this.txtShouldPay.AllowNegative = false;
            this.txtShouldPay.BackColor = System.Drawing.Color.White;
            this.txtShouldPay.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtShouldPay.IsAutoRemoveDecimalZero = false;
            this.txtShouldPay.IsEnter2Tab = false;
            this.txtShouldPay.Location = new System.Drawing.Point(127, 18);
            this.txtShouldPay.Name = "txtShouldPay";
            this.txtShouldPay.NumericPrecision = 10;
            this.txtShouldPay.NumericScaleOnFocus = 2;
            this.txtShouldPay.NumericScaleOnLostFocus = 2;
            this.txtShouldPay.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtShouldPay.ReadOnly = true;
            this.txtShouldPay.SetRange = new System.Drawing.Size(-1, -1);
            this.txtShouldPay.Size = new System.Drawing.Size(137, 29);
            this.txtShouldPay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtShouldPay.TabIndex = 9;
            this.txtShouldPay.Text = "0.00";
            this.txtShouldPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShouldPay.UseGroupSeperator = true;
            this.txtShouldPay.ZeroIsValid = true;
            // 
            // txtPay
            // 
            this.txtPay.AllowNegative = false;
            this.txtPay.BackColor = System.Drawing.Color.White;
            this.txtPay.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPay.IsAutoRemoveDecimalZero = false;
            this.txtPay.IsEnter2Tab = false;
            this.txtPay.Location = new System.Drawing.Point(351, 16);
            this.txtPay.Name = "txtPay";
            this.txtPay.NumericPrecision = 10;
            this.txtPay.NumericScaleOnFocus = 2;
            this.txtPay.NumericScaleOnLostFocus = 2;
            this.txtPay.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPay.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPay.Size = new System.Drawing.Size(132, 29);
            this.txtPay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPay.TabIndex = 11;
            this.txtPay.Text = "0.00";
            this.txtPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPay.UseGroupSeperator = true;
            this.txtPay.ZeroIsValid = true;
            this.txtPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPay_KeyDown);
            this.txtPay.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // lblPay
            // 
            this.lblPay.AutoSize = true;
            this.lblPay.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPay.Location = new System.Drawing.Point(285, 22);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(60, 19);
            this.lblPay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblPay.TabIndex = 10;
            this.lblPay.Text = "实 收";
            // 
            // txtMannalCost
            // 
            this.txtMannalCost.AllowNegative = false;
            this.txtMannalCost.BackColor = System.Drawing.Color.White;
            this.txtMannalCost.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMannalCost.ForeColor = System.Drawing.Color.Red;
            this.txtMannalCost.IsAutoRemoveDecimalZero = false;
            this.txtMannalCost.IsEnter2Tab = false;
            this.txtMannalCost.Location = new System.Drawing.Point(695, 70);
            this.txtMannalCost.Name = "txtMannalCost";
            this.txtMannalCost.NumericPrecision = 10;
            this.txtMannalCost.NumericScaleOnFocus = 2;
            this.txtMannalCost.NumericScaleOnLostFocus = 2;
            this.txtMannalCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMannalCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtMannalCost.Size = new System.Drawing.Size(48, 23);
            this.txtMannalCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMannalCost.TabIndex = 91;
            this.txtMannalCost.Text = "0.00";
            this.txtMannalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMannalCost.UseGroupSeperator = true;
            this.txtMannalCost.ZeroIsValid = true;
            // 
            // txtCharge
            // 
            this.txtCharge.AllowNegative = false;
            this.txtCharge.BackColor = System.Drawing.Color.White;
            this.txtCharge.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCharge.IsAutoRemoveDecimalZero = false;
            this.txtCharge.IsEnter2Tab = false;
            this.txtCharge.Location = new System.Drawing.Point(609, 16);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.NumericPrecision = 10;
            this.txtCharge.NumericScaleOnFocus = 2;
            this.txtCharge.NumericScaleOnLostFocus = 2;
            this.txtCharge.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCharge.ReadOnly = true;
            this.txtCharge.SetRange = new System.Drawing.Size(-1, -1);
            this.txtCharge.Size = new System.Drawing.Size(139, 29);
            this.txtCharge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCharge.TabIndex = 13;
            this.txtCharge.Text = "0.00";
            this.txtCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharge.UseGroupSeperator = true;
            this.txtCharge.ZeroIsValid = true;
            // 
            // neuNumericTextBox1
            // 
            this.neuNumericTextBox1.AllowNegative = false;
            this.neuNumericTextBox1.BackColor = System.Drawing.Color.White;
            this.neuNumericTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuNumericTextBox1.IsAutoRemoveDecimalZero = false;
            this.neuNumericTextBox1.IsEnter2Tab = false;
            this.neuNumericTextBox1.Location = new System.Drawing.Point(315, 88);
            this.neuNumericTextBox1.Name = "neuNumericTextBox1";
            this.neuNumericTextBox1.NumericPrecision = 10;
            this.neuNumericTextBox1.NumericScaleOnFocus = 2;
            this.neuNumericTextBox1.NumericScaleOnLostFocus = 2;
            this.neuNumericTextBox1.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.neuNumericTextBox1.ReadOnly = true;
            this.neuNumericTextBox1.SetRange = new System.Drawing.Size(-1, -1);
            this.neuNumericTextBox1.Size = new System.Drawing.Size(100, 23);
            this.neuNumericTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuNumericTextBox1.TabIndex = 15;
            this.neuNumericTextBox1.Text = "0.00";
            this.neuNumericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.neuNumericTextBox1.UseGroupSeperator = true;
            this.neuNumericTextBox1.ZeroIsValid = true;
            // 
            // lblMannal
            // 
            this.lblMannal.AutoSize = true;
            this.lblMannal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMannal.ForeColor = System.Drawing.Color.Red;
            this.lblMannal.Location = new System.Drawing.Point(622, 88);
            this.lblMannal.Name = "lblMannal";
            this.lblMannal.Size = new System.Drawing.Size(96, 12);
            this.lblMannal.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblMannal.TabIndex = 14;
            this.lblMannal.Text = "手工分票金额：";
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCharge.Location = new System.Drawing.Point(534, 22);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(69, 19);
            this.lblCharge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCharge.TabIndex = 12;
            this.lblCharge.Text = "找　零";
            // 
            // neuListTextBox1
            // 
            this.neuListTextBox1.EnterVisiable = false;
            this.neuListTextBox1.IsFind = false;
            this.neuListTextBox1.ListBoxHeight = 100;
            this.neuListTextBox1.ListBoxWidth = 100;
            this.neuListTextBox1.Location = new System.Drawing.Point(430, 90);
            this.neuListTextBox1.Name = "neuListTextBox1";
            this.neuListTextBox1.OmitFilter = true;
            this.neuListTextBox1.SelectedItem = null;
            this.neuListTextBox1.SelectNone = true;
            this.neuListTextBox1.ShowID = true;
            this.neuListTextBox1.Size = new System.Drawing.Size(100, 21);
            this.neuListTextBox1.TabIndex = 0;
            // 
            // pnlMidUp
            // 
            this.pnlMidUp.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMidUp.Controls.Add(this.txtPrepayCost);
            this.pnlMidUp.Controls.Add(this.lblPrepayCost);
            this.pnlMidUp.Controls.Add(this.txtOwnTot);
            this.pnlMidUp.Controls.Add(this.lblOwnCost);
            this.pnlMidUp.Controls.Add(this.txtPubTot);
            this.pnlMidUp.Controls.Add(this.lblPubCost);
            this.pnlMidUp.Controls.Add(this.txtBalanceCost);
            this.pnlMidUp.Controls.Add(this.llblBalanceCost);
            this.pnlMidUp.Controls.Add(this.fpPrepay);
            this.pnlMidUp.Controls.Add(this.fpCost);
            this.pnlMidUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidUp.Location = new System.Drawing.Point(0, 0);
            this.pnlMidUp.Name = "pnlMidUp";
            this.pnlMidUp.Size = new System.Drawing.Size(784, 289);
            this.pnlMidUp.TabIndex = 98;
            // 
            // txtPrepayCost
            // 
            this.txtPrepayCost.AllowNegative = false;
            this.txtPrepayCost.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrepayCost.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrepayCost.IsAutoRemoveDecimalZero = false;
            this.txtPrepayCost.IsEnter2Tab = false;
            this.txtPrepayCost.Location = new System.Drawing.Point(685, 12);
            this.txtPrepayCost.Name = "txtPrepayCost";
            this.txtPrepayCost.NumericPrecision = 10;
            this.txtPrepayCost.NumericScaleOnFocus = 2;
            this.txtPrepayCost.NumericScaleOnLostFocus = 2;
            this.txtPrepayCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrepayCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPrepayCost.Size = new System.Drawing.Size(86, 23);
            this.txtPrepayCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPrepayCost.TabIndex = 9;
            this.txtPrepayCost.Text = "0.00";
            this.txtPrepayCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrepayCost.UseGroupSeperator = true;
            this.txtPrepayCost.ZeroIsValid = true;
            // 
            // lblPrepayCost
            // 
            this.lblPrepayCost.AutoSize = true;
            this.lblPrepayCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrepayCost.Location = new System.Drawing.Point(579, 16);
            this.lblPrepayCost.Name = "lblPrepayCost";
            this.lblPrepayCost.Size = new System.Drawing.Size(104, 16);
            this.lblPrepayCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblPrepayCost.TabIndex = 8;
            this.lblPrepayCost.Text = "冲预交金累计";
            // 
            // txtOwnTot
            // 
            this.txtOwnTot.AllowNegative = false;
            this.txtOwnTot.BackColor = System.Drawing.SystemColors.Control;
            this.txtOwnTot.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOwnTot.IsAutoRemoveDecimalZero = false;
            this.txtOwnTot.IsEnter2Tab = false;
            this.txtOwnTot.Location = new System.Drawing.Point(278, 13);
            this.txtOwnTot.Name = "txtOwnTot";
            this.txtOwnTot.NumericPrecision = 10;
            this.txtOwnTot.NumericScaleOnFocus = 2;
            this.txtOwnTot.NumericScaleOnLostFocus = 2;
            this.txtOwnTot.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOwnTot.SetRange = new System.Drawing.Size(-1, -1);
            this.txtOwnTot.Size = new System.Drawing.Size(78, 23);
            this.txtOwnTot.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOwnTot.TabIndex = 7;
            this.txtOwnTot.Text = "0.00";
            this.txtOwnTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOwnTot.UseGroupSeperator = true;
            this.txtOwnTot.ZeroIsValid = true;
            // 
            // lblOwnCost
            // 
            this.lblOwnCost.AutoSize = true;
            this.lblOwnCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOwnCost.Location = new System.Drawing.Point(176, 16);
            this.lblOwnCost.Name = "lblOwnCost";
            this.lblOwnCost.Size = new System.Drawing.Size(104, 16);
            this.lblOwnCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblOwnCost.TabIndex = 6;
            this.lblOwnCost.Text = "个人自付累计";
            // 
            // txtPubTot
            // 
            this.txtPubTot.AllowNegative = false;
            this.txtPubTot.BackColor = System.Drawing.SystemColors.Control;
            this.txtPubTot.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPubTot.IsAutoRemoveDecimalZero = false;
            this.txtPubTot.IsEnter2Tab = false;
            this.txtPubTot.Location = new System.Drawing.Point(476, 13);
            this.txtPubTot.Name = "txtPubTot";
            this.txtPubTot.NumericPrecision = 10;
            this.txtPubTot.NumericScaleOnFocus = 2;
            this.txtPubTot.NumericScaleOnLostFocus = 2;
            this.txtPubTot.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPubTot.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPubTot.Size = new System.Drawing.Size(89, 23);
            this.txtPubTot.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPubTot.TabIndex = 5;
            this.txtPubTot.Text = "0.00";
            this.txtPubTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPubTot.UseGroupSeperator = true;
            this.txtPubTot.ZeroIsValid = true;
            // 
            // lblPubCost
            // 
            this.lblPubCost.AutoSize = true;
            this.lblPubCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPubCost.Location = new System.Drawing.Point(362, 16);
            this.lblPubCost.Name = "lblPubCost";
            this.lblPubCost.Size = new System.Drawing.Size(112, 16);
            this.lblPubCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblPubCost.TabIndex = 4;
            this.lblPubCost.Text = "医保/公费记帐";
            // 
            // txtBalanceCost
            // 
            this.txtBalanceCost.AllowNegative = false;
            this.txtBalanceCost.BackColor = System.Drawing.SystemColors.Control;
            this.txtBalanceCost.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBalanceCost.IsAutoRemoveDecimalZero = false;
            this.txtBalanceCost.IsEnter2Tab = false;
            this.txtBalanceCost.Location = new System.Drawing.Point(98, 13);
            this.txtBalanceCost.Name = "txtBalanceCost";
            this.txtBalanceCost.NumericPrecision = 10;
            this.txtBalanceCost.NumericScaleOnFocus = 2;
            this.txtBalanceCost.NumericScaleOnLostFocus = 2;
            this.txtBalanceCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBalanceCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtBalanceCost.Size = new System.Drawing.Size(72, 23);
            this.txtBalanceCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBalanceCost.TabIndex = 3;
            this.txtBalanceCost.Text = "0.00";
            this.txtBalanceCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceCost.UseGroupSeperator = true;
            this.txtBalanceCost.ZeroIsValid = true;
            // 
            // llblBalanceCost
            // 
            this.llblBalanceCost.AutoSize = true;
            this.llblBalanceCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llblBalanceCost.Location = new System.Drawing.Point(9, 16);
            this.llblBalanceCost.Name = "llblBalanceCost";
            this.llblBalanceCost.Size = new System.Drawing.Size(88, 16);
            this.llblBalanceCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.llblBalanceCost.TabIndex = 2;
            this.llblBalanceCost.Text = "结算总金额";
            // 
            // fpPrepay
            // 
            this.fpPrepay.About = "3.0.2004.2005";
            this.fpPrepay.AccessibleDescription = "";
            this.fpPrepay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fpPrepay.BackColor = System.Drawing.Color.White;
            this.fpPrepay.FileName = "";
            this.fpPrepay.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpPrepay.IsAutoSaveGridStatus = false;
            this.fpPrepay.IsCanCustomConfigColumn = false;
            this.fpPrepay.Location = new System.Drawing.Point(378, 42);
            this.fpPrepay.Name = "fpPrepay";
            this.fpPrepay.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpPrepay_Sheet1});
            this.fpPrepay.Size = new System.Drawing.Size(393, 239);
            this.fpPrepay.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpPrepay.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpPrepay.TextTipAppearance = tipAppearance2;
            this.fpPrepay.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpPrepay_Sheet1
            // 
            this.fpPrepay_Sheet1.Reset();
            this.fpPrepay_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpPrepay_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpPrepay_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpPrepay_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpCost
            // 
            this.fpCost.About = "3.0.2004.2005";
            this.fpCost.AccessibleDescription = "";
            this.fpCost.BackColor = System.Drawing.Color.White;
            this.fpCost.FileName = "";
            this.fpCost.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCost.IsAutoSaveGridStatus = false;
            this.fpCost.IsCanCustomConfigColumn = false;
            this.fpCost.Location = new System.Drawing.Point(3, 42);
            this.fpCost.Name = "fpCost";
            this.fpCost.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpCost_Sheet1});
            this.fpCost.Size = new System.Drawing.Size(373, 239);
            this.fpCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpCost.TabIndex = 97;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpCost.TextTipAppearance = tipAppearance3;
            this.fpCost.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpCost_Sheet1
            // 
            this.fpCost_Sheet1.Reset();
            this.fpCost_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpCost_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpCost_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpCost_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlUp
            // 
            this.pnlUp.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUp.Controls.Add(this.neuGroupBox1);
            this.pnlUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUp.Location = new System.Drawing.Point(0, 0);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(784, 88);
            this.pnlUp.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlUp.TabIndex = 0;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.btnExecute);
            this.neuGroupBox1.Controls.Add(this.ucQueryInpatientNo);
            this.neuGroupBox1.Controls.Add(this.lblReach);
            this.neuGroupBox1.Controls.Add(this.lblFeeDate);
            this.neuGroupBox1.Controls.Add(this.txtDeratefee);
            this.neuGroupBox1.Controls.Add(this.lblDerate);
            this.neuGroupBox1.Controls.Add(this.dtpEnd);
            this.neuGroupBox1.Controls.Add(this.dtpBegin);
            this.neuGroupBox1.Controls.Add(this.txtRebateFee);
            this.neuGroupBox1.Controls.Add(this.lblPatientInfo);
            this.neuGroupBox1.Controls.Add(this.lblRebateFee);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(784, 88);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 8;
            this.neuGroupBox1.TabStop = false;
            // 
            // btnExecute
            // 
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.Location = new System.Drawing.Point(339, 56);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(69, 23);
            this.btnExecute.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "执行";
            this.btnExecute.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // ucQueryInpatientNo
            // 
            this.ucQueryInpatientNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucQueryInpatientNo.InputType = 0;
            this.ucQueryInpatientNo.Location = new System.Drawing.Point(15, 13);
            this.ucQueryInpatientNo.Name = "ucQueryInpatientNo";
            this.ucQueryInpatientNo.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo.Size = new System.Drawing.Size(190, 36);
            this.ucQueryInpatientNo.TabIndex = 0;
            this.ucQueryInpatientNo.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
            // 
            // lblReach
            // 
            this.lblReach.AutoSize = true;
            this.lblReach.Location = new System.Drawing.Point(197, 63);
            this.lblReach.Name = "lblReach";
            this.lblReach.Size = new System.Drawing.Size(17, 12);
            this.lblReach.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblReach.TabIndex = 3;
            this.lblReach.Text = "至";
            // 
            // lblFeeDate
            // 
            this.lblFeeDate.AutoSize = true;
            this.lblFeeDate.Location = new System.Drawing.Point(16, 61);
            this.lblFeeDate.Name = "lblFeeDate";
            this.lblFeeDate.Size = new System.Drawing.Size(53, 12);
            this.lblFeeDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblFeeDate.TabIndex = 1;
            this.lblFeeDate.Text = "费用日期";
            // 
            // txtDeratefee
            // 
            this.txtDeratefee.AllowNegative = false;
            this.txtDeratefee.BackColor = System.Drawing.Color.White;
            this.txtDeratefee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDeratefee.IsAutoRemoveDecimalZero = false;
            this.txtDeratefee.IsEnter2Tab = false;
            this.txtDeratefee.Location = new System.Drawing.Point(491, 54);
            this.txtDeratefee.Name = "txtDeratefee";
            this.txtDeratefee.NumericPrecision = 10;
            this.txtDeratefee.NumericScaleOnFocus = 2;
            this.txtDeratefee.NumericScaleOnLostFocus = 2;
            this.txtDeratefee.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDeratefee.SetRange = new System.Drawing.Size(-1, -1);
            this.txtDeratefee.Size = new System.Drawing.Size(89, 23);
            this.txtDeratefee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDeratefee.TabIndex = 7;
            this.txtDeratefee.Text = "0.00";
            this.txtDeratefee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDeratefee.UseGroupSeperator = true;
            this.txtDeratefee.ZeroIsValid = true;
            // 
            // lblDerate
            // 
            this.lblDerate.AutoSize = true;
            this.lblDerate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDerate.Location = new System.Drawing.Point(423, 60);
            this.lblDerate.Name = "lblDerate";
            this.lblDerate.Size = new System.Drawing.Size(63, 14);
            this.lblDerate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblDerate.TabIndex = 6;
            this.lblDerate.Text = "减免金额";
            // 
            // dtpEnd
            // 
            this.dtpEnd.IsEnter2Tab = false;
            this.dtpEnd.Location = new System.Drawing.Point(217, 55);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(113, 21);
            this.dtpEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEnd.TabIndex = 11;
            // 
            // dtpBegin
            // 
            this.dtpBegin.IsEnter2Tab = false;
            this.dtpBegin.Location = new System.Drawing.Point(76, 55);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(115, 21);
            this.dtpBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBegin.TabIndex = 10;
            // 
            // txtRebateFee
            // 
            this.txtRebateFee.AllowNegative = false;
            this.txtRebateFee.BackColor = System.Drawing.Color.White;
            this.txtRebateFee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRebateFee.IsAutoRemoveDecimalZero = false;
            this.txtRebateFee.IsEnter2Tab = false;
            this.txtRebateFee.Location = new System.Drawing.Point(673, 54);
            this.txtRebateFee.Name = "txtRebateFee";
            this.txtRebateFee.NumericPrecision = 10;
            this.txtRebateFee.NumericScaleOnFocus = 2;
            this.txtRebateFee.NumericScaleOnLostFocus = 2;
            this.txtRebateFee.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRebateFee.ReadOnly = true;
            this.txtRebateFee.SetRange = new System.Drawing.Size(-1, -1);
            this.txtRebateFee.Size = new System.Drawing.Size(86, 23);
            this.txtRebateFee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRebateFee.TabIndex = 9;
            this.txtRebateFee.Text = "0.00";
            this.txtRebateFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRebateFee.UseGroupSeperator = true;
            this.txtRebateFee.ZeroIsValid = true;
            // 
            // lblPatientInfo
            // 
            this.lblPatientInfo.AutoSize = true;
            this.lblPatientInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientInfo.Location = new System.Drawing.Point(243, 23);
            this.lblPatientInfo.Name = "lblPatientInfo";
            this.lblPatientInfo.Size = new System.Drawing.Size(0, 14);
            this.lblPatientInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblPatientInfo.TabIndex = 1;
            // 
            // lblRebateFee
            // 
            this.lblRebateFee.AutoSize = true;
            this.lblRebateFee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRebateFee.Location = new System.Drawing.Point(604, 59);
            this.lblRebateFee.Name = "lblRebateFee";
            this.lblRebateFee.Size = new System.Drawing.Size(63, 14);
            this.lblRebateFee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblRebateFee.TabIndex = 8;
            this.lblRebateFee.Text = "优惠金额";
            // 
            // ucBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.pnlMain);
            this.Name = "ucBalance";
            this.Size = new System.Drawing.Size(784, 578);
            this.Load += new System.EventHandler(this.ucBalance_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlDown.ResumeLayout(false);
            this.pnlMidDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpPayType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPayType_Sheet1)).EndInit();
            this.gbPayType.ResumeLayout(false);
            this.gbPayType.PerformLayout();
            this.pnlMidUp.ResumeLayout(false);
            this.pnlMidUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpPrepay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpPrepay_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCost_Sheet1)).EndInit();
            this.pnlUp.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #region"变量"
        /// <summary>
        /// DataSet
        /// </summary>
        protected DataSet dsDetail = new DataSet();
        
        protected DataSet dsPrepay = new DataSet();
        
        /// <summary>
        /// toolBarService
        /// </summary>
        ToolBarService toolBarService = new ToolBarService();
        
        private Neusoft.FrameWork.Models.NeuObject operFinGroup = new Neusoft.FrameWork.Models.NeuObject();
        
        /// <summary>
        /// 费用大类数组变量
        /// </summary>
        ArrayList alFeeInfo = new ArrayList();

        /// <summary>
        /// 1应收2返还3转押金
        /// </summary>
        string payTrace = "1";

        /// <summary>
        /// 结算时间段


        /// </summary>
        DateTime dtBegin, dtEnd;


        /// <summary>
        /// //转入预交金---预交金查询时候赋值
        /// </summary>
        decimal ChangePrepay = 0m;

        /// <summary>
        /// 结算总金额中的自费金额,自付金额,公费金额
        /// </summary>
        decimal TotalOwnCost = 0m;
        decimal TotalPayCost = 0m;
        decimal TotalPubCost = 0m;

        /// <summary>
        /// 结算发票存储
        /// </summary>
        ArrayList alBalanceListBaby = new ArrayList();
        ArrayList alBalanceListFood = new ArrayList();
        ArrayList alBalanceListDerate = new ArrayList();
        ArrayList alBalanceListRebate = new ArrayList();
        ArrayList alBalanceListMannal = new ArrayList();

        /// <summary>
        /// 存储主打印发票
        /// </summary>
        ArrayList alBalanceListHead = new ArrayList();
        //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
        ArrayList alBalancePay = new ArrayList();

        #region "控制类变量"

        //中途结算是否允许修改结算费用
        bool IsModifyCost;

        //婴儿是否单独打印发票
        private bool IsBabyPrint;
        
        //营养膳食是否单独打印发票
        private bool IsFoodPrint;
        
        //减免费用是否单独打印发票
        private bool IsDeratePrint;
        
        //优惠是否单独打印发票
        private bool IsRebatePrint;

        /// <summary>
        /// 结算时候是否输入减免金额
        /// </summary>
        private bool IsInputDerateFee;

        /// <summary>
        /// 中途结算是否使用转押金
        /// </summary>
        private bool IsTransPrepay;

        /// <summary>
        /// 是否打印自费药收据
        /// </summary>
        private bool IsOwnMediPrint;

        /// <summary>
        /// 支票汇票是否需要输入完整银行信息
        /// </summary>
        private bool IsFullBankInfo;
        //{64B39671-DC96-4b6b-81C6-7F6B551FA2AF}
        /// <summary>
        /// 年终结转月份
        /// </summary>
        private int midBalanceMonth = 12;
        /// <summary>
        /// 年终结转日期
        /// </summary>
        private int midBalanceDay = 31;

        /// <summary>
        /// 结转跨度天数
        /// </summary>
        private int preMidDay = 0;

        /// <summary>
        /// 中途结算是否可以修改终止时间
        /// </summary>
        private bool isCanEditEndDate = true;
        #endregion


        /// <summary>
        /// 业务层变量
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private Neusoft.HISFC.BizLogic.Fee.Ecoformula feeEcoFormula = new Neusoft.HISFC.BizLogic.Fee.Ecoformula();
        private Neusoft.HISFC.BizLogic.Fee.Derate feeDerate = new Neusoft.HISFC.BizLogic.Fee.Derate();
        private Neusoft.FrameWork.Management.ControlParam controlParm = new Neusoft.FrameWork.Management.ControlParam();
        private Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeCodeStat = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();
        private Sql local = new Sql();  //本地业务层

        /// <summary>
        /// 实体变量
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 医疗待遇接口
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();
        
        /// <summary>
        /// 结算类别
        /// </summary>
        private Neusoft.HISFC.Models.Base.EBlanceType blanceType = Neusoft.HISFC.Models.Base.EBlanceType.Out;

        /// <summary>
        /// 退费申请业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.ReturnApply returnApplyManager = new Neusoft.HISFC.BizLogic.Fee.ReturnApply();

        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        #endregion

        #region IInterfaceContainer 成员

        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                Type[] type = new Type[1];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy);

                return type;
            }
        }

        #endregion

        #region"属性"
        [Category("控件设置"), Description("结算类别Out:出院结算Mid:中途结算Owe:欠费结算")]
        public Neusoft.HISFC.Models.Base.EBlanceType BlanceType
        {
            get
            {
                return blanceType;
            }
            set
            {
                blanceType = value;
            }
        }

        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get { return this.patientInfo; }
        }

        //{64B39671-DC96-4b6b-81C6-7F6B551FA2AF}
        [Category("年终结转日期设置"), Description("年终结转月份")]
        public int 年终结转月份
        {
            get
            {
                return midBalanceMonth;
            }
            set
            {
                midBalanceMonth = value;
            }
        }
        [Category("年终结转日期设置"), Description("年终结转日期")]
        public int 年终结转日期
        {
            get
            {
                return midBalanceDay;
            }
            set
            {
                midBalanceDay = value;
            }
        }
        [Category("年终结转日期设置"),Description("结转跨度天数")]
        public int 结转跨度天数
        {
            get
            {
                return preMidDay;
            }

            set
            {
                preMidDay = value;
            }
        }

        [Category("控件设置"), Description("中途结算是否可以修改终止时间")]
        public bool IsCanEditEndDate
        {
            get
            {
                return isCanEditEndDate;
            }
            set
            {
                isCanEditEndDate = value;
            }
        }

        //{29F39131-89B4-4128-B4C9-EAB9F07B719F}
        private bool quitFeeApplyFlag = false;
        /// <summary>
        /// 有退费申请是否允许结算{29F39131-89B4-4128-B4C9-EAB9F07B719F}
        /// </summary>
        [Category("控件设置"), Description("有退费申请是否允许结算")]
        public bool QuitFeeApplyFlag
        {
            get
            {
                return quitFeeApplyFlag;
            }
            set
            {
                quitFeeApplyFlag = value;
            }
        }
        #endregion

        #region"方法"
        /// <summary>
        /// 清空
        /// </summary>
        protected virtual void Clear()
        {
            //清空farpoint
            try
            {
                if (this.fpCost_Sheet1.RowCount > 0)
                {
                    try
                    {
                        this.dsDetail.Tables[0].Rows.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    this.alFeeInfo = new ArrayList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (this.fpPrepay_Sheet1.RowCount > 0)
            {
                this.dsPrepay.Tables[0].Rows.Clear();
            }

            try
            {
                this.txtBalanceCost.Text = "0.00";
                this.txtOwnTot.Text = "0.00";
                this.txtPubTot.Text = "0.00";
                this.txtPrepayCost.Text = "0.00";
                this.txtDeratefee.Text = "0.00";
                //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
                this.txtMannalCost.Text = "0.00";
                this.lblShouldPay.Text = "补交(自费)";
                this.lblShouldPay.Font = new Font("宋体", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)134));
                this.lblShouldPay.ForeColor = Color.Blue;
                this.txtShouldPay.ForeColor = System.Drawing.Color.Blue;
                this.gbPayType.Text = "补收款项";
                //this.txtPay.Enabled = false;
                this.txtPay.ReadOnly = false;
                this.txtShouldPay.Text = "0.00";
                this.txtPay.Text = "0.00";
                //清空支付列表
                this.fpPayType_Sheet1.Rows.Count = 0;
                this.fpPayType_Sheet1.Rows.Count = 5;
                for (int i = 0; i < this.fpPayType_Sheet1.Columns.Count; i++)
                {
                    this.fpPayType_Sheet1.Columns[i].Locked = false;
                }
                //清空变量
                payTrace = "1";

                this.alBalanceListBaby = new ArrayList();
                this.alBalanceListDerate = new ArrayList();
                this.alBalanceListFood = new ArrayList();
                this.alBalanceListHead = new ArrayList();
                this.alBalanceListRebate = new ArrayList();
                //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
                this.alBalanceListMannal = new ArrayList();
                TotalOwnCost = 0m;
                TotalPayCost = 0m;
                TotalPubCost = 0m;

                //this.IsAdjustLimitOverTop = false;
                //this.AdjustLimitOverTop = 0m;
                //对于上一个没有处理完毕的患者 进行开帐处理

                #region 注释{E7D41747-D6D7-42f5-899B-B7911592E9FF} 出院登记做封帐,出院召回做开帐,其他地方都不做开帐处理
                //if (this.patientInfo != null || patientInfo.ID == "")
                //{
                //    //开帐


                //    if (this.feeInpatient.OpenAccount(this.patientInfo.ID) == -1)
                //    {
                //        Neusoft.FrameWork.WinForms.Classes.Function.Msg("开帐失败" + this.feeInpatient.Err, 211);
                //        return;
                //    }
                //}
                #endregion 
                //清空患者信息控件

                this.EvaluatePatientInfo(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        /// <summary>
        /// 患者信息赋值
        /// </summary>
        /// <param name="patientInfo">患者信息实体</param>
        protected virtual void EvaluatePatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                this.lblPatientInfo.Text = "姓名".PadRight(6, ' ') + "入院日期:".PadRight(6, ' ') + "结算类别:".PadRight(6, ' ');
            }
            else
            {
                //{7A9E8339-AD72-4b6b-8F9B-B361F30685F7} 席宗飞20101112 显示科室
                this.lblPatientInfo.Text = "姓名: " + patientInfo.Name +"  科室:"+patientInfo.PVisit.PatientLocation.Dept.Name +"  入院日期: " +
                    patientInfo.PVisit.InTime.ToString("yyyy-MM-dd") + "  结算类别: " + patientInfo.Pact.Name;
            }
        }
        
        /// <summary>
        /// 结算有效性判断
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        protected virtual int ValidPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            //中途结算判断在院状态


            if (this.BlanceType == Neusoft.HISFC.Models.Base.EBlanceType.Mid)
            {
                if (patientInfo.PVisit.InState.ID.ToString() != "I")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("患者状态不是在院治疗,不能进行中途结算！", 111);
                    return -1;
                }
                //{64B39671-DC96-4b6b-81C6-7F6B551FA2AF}
                if (this.patientInfo.Pact.PayKind.ID == "02")
                {
                    DateTime dtnow = Neusoft.FrameWork.Function.NConvert.ToDateTime(feeInpatient.GetSysDateTime("yyyy-MM-dd hh:mm:ss"));
                    string endstr = dtnow.Year.ToString() + "-" + midBalanceMonth.ToString() + "-" + midBalanceDay.ToString() + " 23:59:59";
                    bool isdate = Neusoft.FrameWork.Public.String.IsDateTime(endstr);
                    if (!isdate)
                    {
                        MessageBox.Show("年终结算时间设置错误，请重新设置！");
                        return -1;
                    }
                    DateTime dtend = Neusoft.FrameWork.Function.NConvert.ToDateTime(dtnow.Year.ToString() + "-" + midBalanceMonth.ToString() + "-" + midBalanceDay.ToString()+" 23:59:59");
                    DateTime dttemp = dtend.AddDays(-preMidDay);
                    DateTime dtbegin = Neusoft.FrameWork.Function.NConvert.ToDateTime(dttemp.Year.ToString() + "-" + dttemp.Month.ToString() + "-" + dttemp.Day.ToString() + " 00:00:00");
                    if (dtnow < dtbegin || dtnow > dtend)
                    {
                        MessageBox.Show("该患者是医保护患者，不能中途结算！");
                        return -1;
                    }
                }
            }
            //出院结算判断状态


            else
            {
                //{A575F3DE-4A35-4d91-B2D0-6D087AFE5365}
                string suretyCost = this.feeInpatient.GetSurtyCost(patientInfo.ID);

                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(suretyCost) > 0)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("患者有未返还的担保金:" + suretyCost + "元,请返还后再进行出院结算！", 111);
                    return -1;
                }

                if (patientInfo.PVisit.InState.ID.ToString() == "O")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院结算!", 111);
                    return -1;
                }

                if (patientInfo.PVisit.InState.ID.ToString() == "B" ||
                    patientInfo.PVisit.InState.ID.ToString() == "C")
                {
                    return 1;
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("患者状态不是出院登记,不能进行出院结算！", 111);
                    return -1;
                }
               


            }


            return 1;
        }

        /// <summary>
        /// 住院号回车处理
        /// </summary>
        protected virtual void EnterPatientNo()
        {
            string errText = "";

            //回车触发事件
            this.Clear();

            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("住院号错误，没有找到该患者", 111);
                this.ucQueryInpatientNo.Focus();
                return;
            }
            try
            {
                patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);
                //判断患者状态


                if (this.ValidPatient(this.patientInfo) == -1)
                {
                    this.ucQueryInpatientNo.Focus();
                    return;
                }
                //if (patientInfo.FT.LeftCost < 0 && this.BlanceType != EBlanceType.Owe)
                //{
                //    Neusoft.FrameWork.WinForms.Classes.Function.Msg("此患者已欠费，请缴纳预交金或者进行欠费设置后欠费结算！", 211);
                //    return;
                //}

                //赋上住院号


                this.ucQueryInpatientNo.TextBox.Text = patientInfo.PID.PatientNO;
                //赋值患者信息


                this.EvaluatePatientInfo(patientInfo);

            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(ex.Message, 211);
                return;
            }

            //判断是否存在未确认的退费申请
            //{92BD4A97-79F4-46ea-A0D6-50AD78594DAD}
            if (this.JudgeHaveQuitApply(this.patientInfo.ID) == 1)
            {
                if (BlanceType == EBlanceType.Mid)
                {
                    MessageBox.Show("存在未确认的退费申请，请退费后再结算！");
                    return;
                }
                else
                {
                    //{92BD4A97-79F4-46ea-A0D6-50AD78594DAD}
                    if (!quitFeeApplyFlag)
                    {
                        MessageBox.Show("患者存在退费申请，不能进行出院结算！");
                        return;
                    }
                    else 
                    {
                        if (Neusoft.FrameWork.WinForms.Classes.Function.Msg("存在未确认的退费申请，是否继续?", 422) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

            }

            //判断医保患者是否允许中途结算－－－－－－－－－－－－－
            //判断出院医嘱停止情况
            if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe)
            {

            }
            //判断转押金


            if (this.VerifyPatientForgift(patientInfo) == 1)
            {

                this.ucQueryInpatientNo.Focus();
                return;
            }

            //事务连接
            //t = new Neusoft.FrameWork.Management.Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //读取控制类信息


            if (this.ReadControlInfo() == -1)
            {
                errText = "读取控制类错误" + this.managerIntegrate.Err;
                goto Error;
            }
            //控制减免金额是否可以输入--提出feeintegrate
            this.txtDeratefee.ReadOnly = !IsInputDerateFee;

            //进行封帐操作 ---------------如果有院内帐号对帐号进行封帐
            if (this.feeInpatient.CloseAccount(this.patientInfo.ID) == -1)
            {
                errText = this.feeInpatient.Err;
                goto Error;
            }
            //提交封帐操作   此处提交方便将来回车处理多个sql操作
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //显示患者此次住院的费用、预交金、减免情况


            this.dtpBegin.Value = this.patientInfo.PVisit.InTime;


            this.dtpEnd.Value = this.feeInpatient.GetDateTimeFromSysDateTime();
            //付给变量方便更新费用函数使用
            dtBegin = this.dtpBegin.Value;
            dtEnd = DateTime.Parse((this.dtpEnd.Value).Date.ToString("d") + " 23:59:59");
            if (this.DisplayPatientCost() == -1)
            {
                goto Error;
            }



            //医保接口 预结算－－－－－－－－－－－－－－－－－－－－－－－－－－



            long returnValue = 0;

            returnValue = this.medcareInterfaceProxy.SetPactCode(this.patientInfo.Pact.ID);
            if (returnValue != 1)
            {

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }
            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }

            //{BF6500FD-71FE-4cce-B328-D10CB7CBF22B}添加读卡 注意：主要为了读取医保串，PreBalanceInpatient预结方法PreBalanceInpatient中应判断patient.SIMainInfo.Memo是否为空
            //如果为空从本地取
            returnValue = this.medcareInterfaceProxy.GetRegInfoInpatient(this.patientInfo);
            if (returnValue != 1)
            {

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }


            returnValue = this.medcareInterfaceProxy.PreBalanceInpatient(this.patientInfo, ref this.alFeeInfo);
            if (returnValue != 1)
            {

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }

            returnValue = this.medcareInterfaceProxy.Disconnect();
            if (returnValue != 1)
            {

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }

            //医保接口预结算完毕




            //计算费用显示返还情况
            this.ComputeSupplyCost();

            //判断生育保险时候最终结算----------------------暂时不加

            this.txtPay.Focus();

            return;
        //错误处理-------------------
        Error:
            try
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
            }
            catch { }
            //清空
            this.Clear();
            this.patientInfo.ID = null;

            if (errText != null && errText.Trim() != "")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(errText, 211);
            }
            this.ucQueryInpatientNo.Focus();
            return;
        }
        /// <summary>
        /// 计算患者结算补收返还费用金额
        /// </summary>
        protected virtual void ComputeSupplyCost()
        {
            decimal BalanceCost = 0m;
            decimal PrepayCost = 0m;
            decimal BalanceOwnCost = 0m;
            decimal BalancePubCost = 0m;
            decimal BalancePayCost = 0m;
            decimal BalanceRebateCost = 0m;
            decimal DerateCost = 0m;
            decimal RealCost = 0m;
            PrepayCost = decimal.Parse(this.txtPrepayCost.Text);
            BalanceCost = decimal.Parse(this.txtBalanceCost.Text);
            BalanceRebateCost = decimal.Parse(this.txtRebateFee.Text);
            DerateCost = decimal.Parse(this.txtDeratefee.Text);
            #region 此处判断大病，如果是，处理总费用为定额 modified by xizf@neusoft.com 20110413
            if (local.isNcum(this.patientInfo.ID)) {
                BalanceCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(local.GetDeUnbalTot(this.patientInfo.ID));
            }
            #endregion
            if (this.patientInfo.ID == null || this.patientInfo.ID == string.Empty)
            {
                return;
            }
            if (BalanceCost < 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("中途结算的范围选择引起本次结算总额小于零，请对中结进行召回！", 111);
                return;
            }

            if (BalanceCost == 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("结算总费用必须大于零！", 111);
                return;
            }
            //获得各费用分项


            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
            for (int i = 0; i < this.fpCost_Sheet1.Rows.Count; i++)
            {
                if ((bool)this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("选择")].Value == true)
                {
                    f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)this.fpCost_Sheet1.Rows[i].Tag;
                    BalanceOwnCost += f.FT.OwnCost;
                    BalancePubCost += f.FT.PubCost;
                    BalancePayCost += f.FT.PayCost;
                }

            }
            this.TotalOwnCost = BalanceOwnCost;
            this.TotalPayCost = BalancePayCost;
            this.TotalPubCost = BalancePubCost;
            //医保
            if (this.patientInfo.Pact.PayKind.ID == "02")
            {
                this.TotalOwnCost = this.patientInfo.SIMainInfo.OwnCost;
                this.TotalPayCost = this.patientInfo.SIMainInfo.PayCost;
                this.TotalPubCost = this.patientInfo.SIMainInfo.PubCost;
            }

            //获取实付金额

            //通过接口实现全部患者都统一用此算法
            RealCost = BalanceCost - this.patientInfo.SIMainInfo.PubCost - DerateCost - BalanceRebateCost;
            BalancePubCost = patientInfo.SIMainInfo.PubCost;
            this.txtOwnTot.Text = RealCost.ToString("###.00");
            this.txtPubTot.Text = BalancePubCost.ToString("###.00");

            //获取supplycost
            decimal SupplyCost = 0m;
            SupplyCost = RealCost - this.patientInfo.SIMainInfo.PayCost - PrepayCost;
            //清空各支付信息框
            this.txtShouldPay.Text = "0.00";
            this.txtPay.Text = "0.00";
            this.txtCharge.Text = "0.00";
            this.fpPayType_Sheet1.Rows.Count = 0;
            this.fpPayType_Sheet1.Rows.Count = 5;
            //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            this.txtMannalCost.Text = "0.00";
            //设置为可用


            for (int i = 0; i < this.fpPayType_Sheet1.Columns.Count; i++)
            {
                this.fpPayType_Sheet1.Columns[i].Locked = false;
            }
            if (SupplyCost >= 0)//补收
            {
                // {ADABD0C1-3208-4620-BECE-8CA5567EAA7B} 出院结算时补收款项为蓝色,特大号字体显示
                this.gbPayType.Text = "补收款项";
                //this.txtPay.Enabled = true;
                this.txtPay.ReadOnly = false;
                this.payTrace = "1";
                this.lblShouldPay.Text = "补交(自费)";
                this.lblShouldPay.Font = new Font("宋体", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)134));
                this.lblShouldPay.ForeColor = System.Drawing.Color.Blue;
                ////{C2A1CA01-0BF6-41b2-8E2A-F24B7825AC82} 出院结算时，应收款的字与数保持一样颜色（显示为蓝色）
                this.txtShouldPay.ForeColor = System.Drawing.Color.Blue;
                ////{C2A1CA01-0BF6-41b2-8E2A-F24B7825AC82} 出院结算时，应收款的字与数保持一样颜色（显示为红色）结束
                this.txtShouldPay.Text = SupplyCost.ToString();
                this.txtShouldPay.ForeColor = System.Drawing.Color.Blue;
                this.txtPay.Text = SupplyCost.ToString();
                this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text = "现金";
                this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("金额")].Value = SupplyCost;

            }
            else //应返 
            {
                if (this.IsTransPrepay) //是否使用转押金
                {
                    if (this.BlanceType == EBlanceType.Mid)
                    {

                        this.payTrace = "3";
                        this.gbPayType.Text = "转押金款项";
                        //this.txtPay.Enabled = false;
                        this.txtPay.ReadOnly = true;
                        this.lblShouldPay.Text = "转押金";
                        this.txtShouldPay.Text = (-SupplyCost).ToString();
                        this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("金额")].Value = -SupplyCost;
                        this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text = "转押金";


                        for (int i = 0; i < this.fpPayType_Sheet1.Columns.Count; i++)
                        {
                            this.fpPayType_Sheet1.Columns[i].Locked = true;
                        }
                    }
                    else
                    {
                        //{ADABD0C1-3208-4620-BECE-8CA5567EAA7B} 出院结算返还金额红色显示,字体正常
                        this.payTrace = "2";
                        this.gbPayType.Text = "返还款项";
                        //this.txtPay.Enabled = false;
                        this.txtPay.ReadOnly = true;
                        this.lblShouldPay.Text = "应退(自费)";
                        this.lblShouldPay.Font = new Font("宋体", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)134));
                        this.lblShouldPay.ForeColor = System.Drawing.Color.Red;
                        //{C2A1CA01-0BF6-41b2-8E2A-F24B7825AC82} 出院结算时，应收款的字与数保持一样颜色（显示为红色）
                        this.txtShouldPay.ForeColor = System.Drawing.Color.Red;
                        //{C2A1CA01-0BF6-41b2-8E2A-F24B7825AC82} 出院结算时，应收款的字与数保持一样颜色（显示为红色）结束
                        this.txtShouldPay.Text = (-SupplyCost).ToString();
                        this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("金额")].Value = -SupplyCost;
                        this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text = "现金";


                    }
                }
                else
                {
                    //{ADABD0C1-3208-4620-BECE-8CA5567EAA7B} 出院结算退款项红色正常字体显示
                    this.payTrace = "2";
                    this.gbPayType.Text = "返还款项";
                    //this.txtPay.Enabled = false;
                    this.txtPay.ReadOnly = true;
                    this.lblShouldPay.Font = new Font("宋体", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)134));
                    this.lblShouldPay.Text = "应退(自费)";
                    this.lblShouldPay.ForeColor = System.Drawing.Color.Red;
                    //{C2A1CA01-0BF6-41b2-8E2A-F24B7825AC82} 出院结算时，应收款的字与数保持一样颜色（显示为红色）
                    this.txtShouldPay.ForeColor = System.Drawing.Color.Red;
                    //{C2A1CA01-0BF6-41b2-8E2A-F24B7825AC82} 出院结算时，应收款的字与数保持一样颜色（显示为红色）//结束
                    this.txtShouldPay.Text = (-SupplyCost).ToString();
                    this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("金额")].Value = -SupplyCost;
                    this.fpPayType_Sheet1.Cells[0, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text = "现金";


                }

            }

        }

        /// <summary>
        /// 显示患者费用信息
        /// </summary>
        /// <returns>1成功 －1失败</returns>
        protected virtual int DisplayPatientCost()
        {
            //检索减免费用


            if ((this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe) && !this.IsInputDerateFee)
            {
                decimal DerateCost = 0m;
                //检索减免金额


                DerateCost = this.feeInpatient.GetTotDerateCost(this.patientInfo.ID);
                if (DerateCost < 0)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("获取减免总费用出错!" + this.feeInpatient.Err, 211);
                    return -1;
                }
                this.txtDeratefee.Text = DerateCost.ToString();
                this.txtDeratefee.ReadOnly = true;
            }
            //中途结算不处理减免
            if (this.BlanceType == EBlanceType.Mid)
            {
                this.txtDeratefee.Text = "0.00";
                this.txtDeratefee.ReadOnly = true;
            }
            //检索费用--含优惠


            if (this.QueryFeeInfo(dtBegin, dtEnd) == -1) return -1;

            //检索预交金
            if (this.QueryPrepayInfo() == -1) return -1;
            //判断无费退院


            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtBalanceCost.Text) == 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者没有可结算费用", 111);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 检索患者费用汇总信息
        /// </summary>
        /// <param name="dtFeeBegin">开始时间</param>
        /// <param name="dtFeeEnd">结束时间</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int QueryFeeInfo(DateTime dtFeeBegin, DateTime dtFeeEnd)
        {
            ArrayList al = new ArrayList();
            if (this.BlanceType == EBlanceType.Mid)//中途结算
            {
                if (dtFeeBegin > dtFeeEnd)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("起始时间大于终止时间,请重新输入时间!", 111);
                    return -1;
                }
                //检索feeinfo       
                al = this.feeInpatient.QueryFeeInfosGroupByMinFeeByInpatientNO(this.patientInfo.ID, dtFeeBegin, dtFeeEnd, "0");
                if (al == null)
                {

                    MessageBox.Show(feeInpatient.Err);
                    return -1;
                }

            }
            else //出院结算
            {
                //检索feeinfo和转入费用


                al = this.feeInpatient.QueryFeeInfosAndChangeCostGroupByMinFeeByInpatientNO(patientInfo.ID, "0");
                if (al == null)
                {
                    MessageBox.Show(feeInpatient.Err);
                    return -1;
                }

            }

            //结算总金额


            decimal BalanceTotCost = 0m;
            //优惠总金额


            decimal RebateCost = 0m;
            //单病种优惠金额


            decimal icdRebate = 0m;

            //判断是否有血押金----提取血押金FeeCode   
            string BloodFeeCode = "";
            Neusoft.FrameWork.Management.ControlParam controlParm = new Neusoft.FrameWork.Management.ControlParam();
            BloodFeeCode = controlParm.QueryControlerInfo("100008");

            for (int i = 0; i < al.Count; i++)
            {

                Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfo = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
                Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfoClone = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
                feeInfo = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)al[i];

                // 暂时中山医不这样处理
                if (feeInfo.Item.MinFee.ID == BloodFeeCode)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者有血押金,请退还再结算!", 111);
                    return -1;
                }

                //此处有可能提取其他类别费用－－－－－－－－－－－－－－－－－－－－－－－－－－



                //获取feeinfo克隆
                feeInfoClone = feeInfo.Clone();
                try
                {
                    this.alFeeInfo.Add(feeInfoClone);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
                //获取最小费用名称


                feeInfo.Item.MinFee.Name = this.feeInpatient.GetMinFeeNameByCode(feeInfo.Item.MinFee.ID);
                BalanceTotCost += feeInfo.FT.TotCost;
                RebateCost += feeInfo.FT.RebateCost;

                try
                {

                    DataRow row = this.dsDetail.Tables[0].NewRow();
                    row[0] = true;
                    row[1] = feeInfo.Item.MinFee.Name;
                    row[2] = feeInfo.FT.TotCost;
                    row[3] = feeInfo.FT.TotCost;
                    this.dsDetail.Tables[0].Rows.Add(row);
                    this.fpCost_Sheet1.Rows[i].Tag = feeInfo;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }



            for (int i = 0; i < al.Count; i++)
            {
                this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("选择")].Value = true;
            }
            //结算总金额赋值


            this.txtBalanceCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(BalanceTotCost, 2).ToString("###.00");

            //判断该患者是否单病种优惠提取单病种金额



            if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe)
            {
                //单病种定额


                decimal icdFee = 0m;
                icdFee = this.feeEcoFormula.GetCost(this.patientInfo.ID, "000", this.feeEcoFormula.GetDateTimeFromSysDateTime());
                if (icdFee < 0)
                {
                    MessageBox.Show("提取单病种定额出错!");
                    return -1;
                }
                //单病种优惠时候不允许有其他优惠


                if (icdFee > 0 && icdFee < BalanceTotCost)
                {
                    icdRebate = BalanceTotCost - icdFee;
                    this.IsInputDerateFee = true;
                    //其他优惠为零
                    RebateCost = 0;
                    this.txtDeratefee.ReadOnly = true;
                    //{BD300517-D927-43c0-A1D3-8FB99BD10298}
                    this.txtDeratefee.Text = Neusoft.FrameWork.Public.String.FormatNumber(icdRebate, 2).ToString("###.00");
                }
                //{BD300517-D927-43c0-A1D3-8FB99BD10298}
                //this.txtDeratefee.Text = Neusoft.FrameWork.Public.String.FormatNumber(icdRebate, 2).ToString("###.00");
                this.txtRebateFee.Text = Neusoft.FrameWork.Public.String.FormatNumber(RebateCost, 2).ToString("###.00");

            }

            return 1;
        }
        /// <summary>
        /// 检索患者预交金信息
        /// </summary>
        /// <returns>1成功 －1失败</returns>
        protected virtual int QueryPrepayInfo()
        {
            ArrayList al = new ArrayList();

            al = this.feeInpatient.QueryPrepaysBalanced(patientInfo.ID);
            if (al == null)
            {
                MessageBox.Show(this.feeInpatient.Err);
                return -1;
            }
            //检索是否有转入预交金--出院结算处理
            if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe)
            {
                ChangePrepay = this.feeInpatient.GetTotChangePrepayCost(patientInfo.ID);
                if (ChangePrepay < 0)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("检索转入预交金出错!" + this.feeInpatient.Err, 211);
                    return -1;
                }
                if (ChangePrepay > 0)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
                    prepay.FT.PrepayCost = ChangePrepay;
                    prepay.PayType.Name = "转入预交金";
                    al.Add(prepay);

                }

            }
            //预交金额
            decimal PrepayCost = 0m;
            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
                prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)al[i];
                PrepayCost += prepay.FT.PrepayCost;



                this.dsPrepay.Tables[0].Rows.Add(new object[] { true, prepay.PrepayOper.OperTime, prepay.PayType.Name, prepay.FT.PrepayCost });
                this.fpPrepay_Sheet1.Rows[i].Tag = prepay;
            }



            //this.fpPrepay.alData = alInvoice;

            //循环赋值选择
            for (int i = 0; i < al.Count; i++)
            {
                this.fpPrepay_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPrepay("选择")].Value = true;
            }
            this.txtPrepayCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(PrepayCost, 2).ToString("###.00");

            return 1;
        }

        /// <summary>
        /// 检查患着是否存在转押金未打印情况
        /// </summary>
        /// <returns>1存在 0不存在 －1失败</returns>
        protected virtual int VerifyPatientForgift(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            ArrayList alForegift = new ArrayList();
            //检索转押金
            alForegift = this.feeInpatient.QueryForegif(patientInfo.ID);

            if (alForegift == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err, 211);

                return -1;
            }
            if (alForegift.Count > 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者存在没有打印的中结转押金票据,请打印!", 111);
                return 1;
            }


            return 0;
        }
        /// <summary>
        /// 读取控制信息
        /// </summary>
        /// <returns>1成功 －1失败</returns>
        protected int ReadControlInfo()
        {

            try
            {
                //是否打印婴儿发票
                this.IsBabyPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100004"));
                //是否打印减免发票
                this.IsDeratePrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100005"));
                //是否打印膳食发票
                this.IsFoodPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100006"));
                //是否打印减免发票
                this.IsRebatePrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100007"));
                //是否可输入减免费用


                this.IsInputDerateFee = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100009"));

                //是否处理转押金


                this.IsTransPrepay = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100018"));
                //是否打印自费药发票


                this.IsOwnMediPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100026"));
                //支票汇票是否需要输入完整银行信息


                this.IsFullBankInfo = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100025"));

                IsModifyCost = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100023"));
                if (!IsModifyCost)
                {
                    this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("结帐金额")].Locked = true;
                    this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("选择")].Locked = true;
                    this.fpCost_Sheet1.Columns[0].Locked = true;
                }
                else
                {
                    this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("结帐金额")].Locked = false;
                    this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("选择")].Locked = true;
                    this.fpCost_Sheet1.Columns[0].Locked = false;

                }
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("读取控制类信息出错!", 211);
                return -1;
            }

            return 1;

        }

        /// <summary>
        /// 通过列名获得列索引--预交金
        /// </summary>
        /// <param name="Name">Column名称</param>
        /// <returns>－1失败 成功返回ColumnIndex</returns>
        protected int GetColumnIndexFromNameForfpPrepay(string Name)
        {
            for (int i = 0; i < dsPrepay.Tables[0].Columns.Count; i++)
            {
                if (dsPrepay.Tables[0].Columns[i].ColumnName == Name) return i;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("缺少列" + Name, 111);

            return -1;
        }

        /// <summary>
        /// 通过列名获得列索引---费用
        /// </summary>
        /// <param name="Name">Column名称</param>
        /// <returns>－1失败 成功返回ColumnIndex</returns>
        protected int GetColumnIndexFromNameForfpCost(string Name)
        {
            for (int i = 0; i < dsDetail.Tables[0].Columns.Count; i++)
            {
                if (dsDetail.Tables[0].Columns[i].ColumnName == Name) return i;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("缺少列" + Name, 211);

            return -1;
        }
        
        /// <summary>
        /// 通过列名获得列索引---支付方式
        /// </summary>
        /// <param name="Name">Column名称</param>
        /// <returns>－1失败 成功返回ColumnIndex</returns>
        protected int GetColumnIndexFromNameForfpPayType(string Name)
        {
            for (int i = 0; i < this.fpPayType_Sheet1.Columns.Count; i++)
            {
                if (this.fpPayType_Sheet1.Columns[i].Label == Name) return i;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("缺少列" + Name, 211);

            return -1;
        }
        
        /// <summary>
        /// 初始化函数
        /// </summary>
        protected virtual void initControl()
        {
            //住院号控件


            this.ucQueryInpatientNo.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucQueryInpatientNo.TextBox.Size = new System.Drawing.Size(104, 21);
            this.ucQueryInpatientNo.TextBox.Location = new System.Drawing.Point(52, 5);
            this.ucQueryInpatientNo.TextBox.BringToFront();

            //初始化farpoint
            initfpCost();
            initfpPrepay();
            initfpPayType();

            //初始化生成事件



            this.fpCost_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpCost_Sheet1_CellChanged);
            this.fpCost.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpCost_CellClick);
            this.fpPrepay.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpPrepay_CellClick);
            this.txtDeratefee.KeyDown += new KeyEventHandler(txtDeratefee_KeyDown);
            this.txtDeratefee.Leave += new EventHandler(txtDeratefee_Leave);


            //提取操作员的财务编码
            this.operFinGroup = this.feeInpatient.GetFinGroupInfoByOperCode(this.feeInpatient.Operator.ID);
            if (this.operFinGroup == null)
            {
                MessageBox.Show(this.feeInpatient.Err);
                return;
            }

            txtBalanceCost.ReadOnly = true;
            this.txtPrepayCost.ReadOnly = true;
            //时间控件初始值


            this.dtpBegin.Value = this.feeInpatient.GetDateTimeFromSysDateTime();
            this.dtpEnd.Value = this.feeInpatient.GetDateTimeFromSysDateTime();

            this.dtpBegin.Enabled = false;
            //this.dtpBegin.
            if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe)
            {
                this.dtpEnd.Enabled = false;


            }

            //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            if (this.BlanceType == EBlanceType.Mid)
            {
                this.lblMannal.Visible = false;
                this.txtMannalCost.Visible = false;
                this.dtpEnd.Enabled = isCanEditEndDate;
            }
            //焦点
            this.ucQueryInpatientNo.Focus();
            
        }

        /// <summary>
        /// 初始化支付方式
        /// </summary>
        protected virtual void initfpPayType()
        {
            //清空
            this.fpPayType_Sheet1.RowCount = 5;

            FarPoint.Win.Spread.CellType.ComboBoxCellType comboType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            // 获取name
            try
            {
                comboType.Items = this.GetPayTypeNameForFpPayType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.fpPayType_Sheet1.Columns[this.GetColumnIndexFromNameForfpPayType("支付方式")].CellType = comboType;

            FarPoint.Win.Spread.CellType.ComboBoxCellType banktype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            banktype.Items = this.GetBankNameForFpBank();
            this.fpPayType_Sheet1.Columns[this.GetColumnIndexFromNameForfpPayType("开户银行")].CellType = banktype;
            this.fpPayType.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentCell;
            //设置属性和颜色
            this.fpPayType_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpPayType_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            //事件

            this.fpPayType_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpPayType_Sheet1_CellChanged);
        }

        /// <summary>
        /// 获取支付方式的parpoint下拉列表
        /// </summary>
        /// <returns></returns>
        protected string[] GetPayTypeNameForFpPayType()
        {
            ArrayList al = new ArrayList();
            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            //al = Neusoft.HISFC.Models.Fee.EnumPayTypeService.List();
            al = managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);
            if (al == null || al.Count <= 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("获取支付方式错误", 211);
                return null;
            }
            //Neusoft.HISFC.Models.Fee.EnumPayType t = new EnumPayType();
            string[] PayName = new string[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                //t = (Neusoft.HISFC.Models.Fee.EnumPayType)alInvoice[i];
                PayName[i] = al[i].ToString();
            }
            return PayName;
        }
        /// <summary>
        /// 获得银行名称的farpoint下拉列表
        /// </summary>
        /// <returns></returns>
        protected string[] GetBankNameForFpBank()
        {
            ArrayList al = new ArrayList();
            al = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BANK);

            if (al == null || al.Count <= 0)
            {
                MessageBox.Show("获取银行列表失败!");
                return null;
            }
            Neusoft.FrameWork.Models.NeuObject obj;
            string[] BankName = new string[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                obj = (Neusoft.FrameWork.Models.NeuObject)al[i];
                BankName[i] = obj.Name;
            }
            return BankName;
        }
        /// <summary>
        /// 初始化结算费用控件
        /// </summary>
        protected virtual void initfpCost()
        {
            try
            {
                System.Type stStr = System.Type.GetType("System.String");
                //System.Type stInt = System.Type.GetType("System.Int16");
                System.Type stDec = System.Type.GetType("System.Single");
                System.Type stDate = System.Type.GetType("System.DateTime");
                System.Type stBool = System.Type.GetType("System.Boolean");


                DataTable dtDetail = dsDetail.Tables.Add("MyTable");
                dtDetail.Columns.AddRange(new DataColumn[]{  new DataColumn("选择",stBool),
															  new DataColumn("费用科目",stStr),
															  new DataColumn("未结金额",stDec),
															  new DataColumn("结帐金额",stDec)
														  });
                this.fpCost_Sheet1.DataSource = this.dsDetail.Tables[0];



                this.fpCost_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Default;
                this.fpCost_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                //中途结算可以选择费用

                this.fpCost_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
                this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("结帐金额")].Locked = true;
                if (this.BlanceType == EBlanceType.Mid || IsModifyCost)
                {

                    this.fpCost_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
                    this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("结帐金额")].Locked = false;
                    this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("选择")].Locked = false;
                }

                this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("选择")].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                //this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("未结金额")].CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("未结金额")].Locked = true;
                this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("费用科目")].Locked = true;
                //this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("结帐金额")].CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                this.fpCost_Sheet1.Columns[this.GetColumnIndexFromNameForfpCost("选择")].Locked = true;
                this.fpCost_Sheet1.Columns[0].Locked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        /// <summary>
        /// 初始化预交金控件
        /// </summary>
        protected virtual void initfpPrepay()
        {
            try
            {
                System.Type stStr = System.Type.GetType("System.String");
                System.Type stInt = System.Type.GetType("System.Int16");
                System.Type stDec = typeof(decimal);
                System.Type stDate = System.Type.GetType("System.DateTime");
                System.Type stBool = System.Type.GetType("System.Boolean");

                DataTable dtDetail = dsPrepay.Tables.Add("MyTable");
                dtDetail.Columns.AddRange(new DataColumn[]{  new DataColumn("选择",stBool),
															  new DataColumn("收取日期",stDate),
															  new DataColumn("支付方式",stStr),
															  new DataColumn("预交金额",stDec)
														  });

                this.fpPrepay_Sheet1.DataSource = this.dsPrepay.Tables[0];



                this.fpPrepay_Sheet1.Columns[this.GetColumnIndexFromNameForfpPrepay("选择")].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                //this.fpPrepay_Sheet1.Columns[this.GetColumnIndexFromNameForfpPrepay("预交金额")].CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                this.fpPrepay_Sheet1.Columns[this.GetColumnIndexFromNameForfpPrepay("收取日期")].Locked = true;
                this.fpPrepay_Sheet1.Columns[this.GetColumnIndexFromNameForfpPrepay("支付方式")].Locked = true;
                this.fpPrepay_Sheet1.Columns[this.GetColumnIndexFromNameForfpPrepay("预交金额")].Locked = true;
                this.fpPrepay_Sheet1.Columns[this.GetColumnIndexFromNameForfpPrepay("选择")].Locked = true;
                this.fpPrepay_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Default;
                this.fpPrepay_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                if (this.BlanceType == EBlanceType.Mid)
                {
                    this.fpPrepay_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
                }
                else
                {
                    this.fpPrepay_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            toolBarService.AddToolButton("确定", "结算患者费用", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("预览", "预览发票信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y预览, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            //{5ED1C898-1F3E-477e-9916-52A3932A45B0} 席宗飞modified 2010-09-22
            toolBarService.AddToolButton("明细打印", "打印患者明细汇总", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);

            return this.toolBarService;
        }
        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "确定":

                    this.ExecuteBalance();
                    break;
                //case "预览":

                //    this.PreviewInvoice();
                //    break;

                case "帮助":
                    break;
                //{79E6528F-7CEF-415f-9364-0FF756A85E23} 席宗飞 2010-9-22
                case "明细打印":
                    Neusoft.WinForms.Report.Finance.FinIpb.ucFinIpbOutPatientDetail3 list = new Neusoft.WinForms.Report.Finance.FinIpb.ucFinIpbOutPatientDetail3();
                    Neusoft.FrameWork.WinForms.Forms.frmBaseForm basef = new Neusoft.FrameWork.WinForms.Forms.frmBaseForm();
                    basef.AddControl(list);
                    list.Dock = DockStyle.Fill;
                    list.Visible = true;
                    list.Show();
                    basef.Show();
                    list.ucQueryInpatientNo1.Text = this.patientInfo.PID.PatientNO.ToString();
                    break;

            }

            base.ToolStrip_ItemClicked(sender, e);
        }
        /// <summary>
        /// 执行结算
        /// </summary>
        protected virtual void ExecuteBalance()
        {
            //{645F3DDE-4206-4f26-9BC5-307E33BD882C}
            string errText = string.Empty;
            if (!feeIntegrate.AfterDayBalanceCanFee(this.feeInpatient.Operator.ID,true, ref errText))
            {
                MessageBox.Show(errText);
                return;
            }
            if (this.patientInfo == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请输入住院号", 111);
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("请输入住院号", 111);
                    return;
                }
            }

            if (this.patientInfo.PID.PatientNO != this.ucQueryInpatientNo.Text.Trim())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请回车确认住院号", 111);
                return;
            }
            this.txtShouldPay.Focus();
            //结算验证
            if (this.VerifyBalance() == -1) return;

            //判断是否有未确认的退费申请

            if (this.JudgeHaveQuitApply(this.patientInfo.ID) == 1)
            {
                if (Neusoft.FrameWork.WinForms.Classes.Function.Msg("存在未确认的退费申请，是否继续?", 423) == DialogResult.No)
                {
                    return;
                }

            }

            //待遇算法
            long returnValue = this.medcareInterfaceProxy.SetPactCode(this.patientInfo.Pact.ID);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }
            if (MessageBox.Show("是否确认保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            //事务连接
            //t = new Neusoft.FrameWork.Management.Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeDerate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.controlParm.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeCodeStat.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //重新判断患者在院状态避免并发           
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfoTemp = new Neusoft.HISFC.Models.RADT.PatientInfo();
            patientInfoTemp = this.radtIntegrate.GetPatientInfomation(patientInfo.ID);
            if (patientInfoTemp == null)
            {
                errText = this.feeInpatient.Err;
                goto Error;
            }
            if (ValidPatient(patientInfoTemp) == -1)
            {
                goto Error;
            }
            //检验金额是否合法


            if (this.ValidCost() == -1) goto Error;

            //结算发票号


            string invoiceNo = "";
            //结算序号
            int balanceNo = 0;
            //系统时间
            DateTime dtSys;

            //获取系统时间
            dtSys = this.feeInpatient.GetDateTimeFromSysDateTime();

            //领取发票   
            //{297E97FA-EF89-40a4-9269-1D1B1D084214}
            //invoiceNo = this.feeIntegrate.GetNewInvoiceNO(EnumInvoiceType.I);
            invoiceNo = this.feeIntegrate.GetNewInvoiceNO("I");

            if (invoiceNo == null || invoiceNo.Trim() == "")
            {
                //errText = this.feeInpatient.Err;
                errText = "请领取发票！";
                goto Error;
            }

            //调业务层获取结算次数
            string balNo = "";
            balNo = this.feeInpatient.GetNewBalanceNO(this.patientInfo.ID);
            if (balNo == null)
            {
                errText = "获取结算序号出错!";
                goto Error;
            }
            else
            {
                balanceNo = int.Parse(balNo);
            }

            //更新预交金信息，将其置为结算状态


            if (this.UpdateBalancePrepay(balanceNo, dtSys, invoiceNo) == -1)
            {
                errText = "更新结算预交金失败!";
                goto Error;

            }

            //更新减免信息,将其置为结算状态



            if ((this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe) && decimal.Parse(this.txtDeratefee.Text) > 0)
            {
                if (this.UpdateDerateFee(balanceNo, dtSys, invoiceNo) == -1)
                {
                    errText = "处理更新减免信息失败!";
                    goto Error;
                }
            }

            //初始化发票组各费用信息


            #region 2007-8-23 liuq 利用打印类返回发票大类，以适应多种发票格式的情况，在这里只能实例化一个对象了。





            Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy p = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy), Neusoft.FrameWork.Management.PublicTrans.Trans) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy;
            if (p == null)
            {
                MessageBox.Show("获取发票打印控件出错");
                goto Error;
            }
            p.PatientInfo = patientInfo;

            if (this.InitInvoice(p.InvoiceType, balanceNo, invoiceNo, dtSys, false) == -1)
            {
                errText = "初始化发票信息失败!" + feeInpatient.Err;
                goto Error;
            }
            #endregion

            //将结算的费用信息置为结算状态


            if (this.UpdateFeeBalanced(balanceNo, dtSys, invoiceNo, this.dtBegin, this.dtEnd) == -1)
            {
                errText = feeInpatient.Err + "处理更新费用信息失败!";
                goto Error;
            }
            //插入结算主表和明细记录---根据发票组循环处理


            //添加结算明细记录信息
            if (this.InsertIntoBalanceList() == -1)
            {
                errText = "插入结算明细记录出错!" + feeInpatient.Err;
                goto Error;
            }
            //添加结算头表记录信息
            if (this.InsertBalanceHead() == -1)
            {
                errText = "插入结算头表出错" + this.feeInpatient.Err;
                goto Error;
            }

            //插入实付表


            if (this.InsertBalancePay(balanceNo, dtSys, invoiceNo) == -1)
            {
                errText = "插入实付表出错" + feeInpatient.Err;
                goto Error;
            }

            //更新住院主表中的结算金额、住院状态


            if (this.UpdateInhos(balanceNo, dtSys) == -1)
            {
                errText = "结算更新住院主表出错!" + feeInpatient.Err;
                goto Error;
            }
            //记录变更
            if (this.InsertShift(balanceNo) == -1)
            {
                errText = "插入变更记录出错!" + this.radtIntegrate.Err;
                goto Error;
            }


            //开帐

            #region {E7D41747-D6D7-42f5-899B-B7911592E9FF} 注释 出院登记封帐,出院召回开帐,其他时候不处理
            if (this.patientInfo.PVisit.InState.ID.ToString() == "I" && this.BlanceType == EBlanceType.Mid)
            {
                if (this.feeInpatient.OpenAccount(this.patientInfo.ID) == -1)
                {
                    errText = "开帐失败" + this.feeInpatient.Err;
                    goto Error;
                }
            }
            //待遇接口处理－－－－－－－－－－－－－－－－－－－－－－－－－－－－
            #endregion 

            this.patientInfo.SIMainInfo.BalNo = balanceNo.ToString();


            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            this.medcareInterfaceProxy.Connect();

            returnValue = this.medcareInterfaceProxy.GetRegInfoInpatient(this.patientInfo);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }
            this.patientInfo.SIMainInfo.InvoiceNo = invoiceNo;
            if (this.BlanceType == EBlanceType.Mid)//医保中途结算（一般是年度结转）
            {
                returnValue = this.medcareInterfaceProxy.MidBalanceInpatient(this.patientInfo, ref this.alFeeInfo);
            }
            else
            {
                returnValue = this.medcareInterfaceProxy.BalanceInpatient(this.patientInfo, ref this.alFeeInfo);
            }
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }

            returnValue = this.medcareInterfaceProxy.Disconnect();
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }
            //-----------------待遇接口计算完毕.
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.medcareInterfaceProxy.Commit();
            //{3335BB2D-DE98-4ac5-9B2D-B5237155714E}
            this.medcareInterfaceProxy.Disconnect();

            Neusoft.FrameWork.WinForms.Classes.Function.Msg("结算成功!", 111);

            //打印结算发票
            this.PrintInvoice();

            this.patientInfo.ID = null;
            //{E4BF4BC4-FDE3-414e-A8DE-E6735FE87DAC} 席宗飞20101107 结算成功后重新获取焦点
            this.ucQueryInpatientNo.Focus();
            return;
        //错误信息
        Error:
            this.medcareInterfaceProxy.Rollback();
            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            if (errText.Trim() != "") MessageBox.Show(errText);

            return;
        }
        /// <summary>
        /// 通过balancelist汇总形成balancehead信息
        /// </summary>
        /// <param name="alBalanceList"></param>
        /// <param name="IsMain"></param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.Fee.Inpatient.Balance MadeBalanceHeadByBalanceList(ArrayList alBalanceList, bool IsMain)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList = null;
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            decimal TotCost = 0m;
            decimal OwnCost = 0m;
            decimal PayCost = 0m;
            decimal PubCost = 0m;

            for (int i = 0; i < alBalanceList.Count; i++)
            {
                balanceList = (BalanceList)alBalanceList[i];
                TotCost += balanceList.BalanceBase.FT.TotCost;
                OwnCost += balanceList.BalanceBase.FT.OwnCost;
                PayCost += balanceList.BalanceBase.FT.PayCost;
                PubCost += balanceList.BalanceBase.FT.PubCost;
            }
            //{4A5515CB-9382-4cd6-8430-D3587BBB3E3E}
            //if (patientInfo.Pact.ID == "2")
            if (patientInfo.Pact.PayKind.ID == "02")
            {
                PayCost = patientInfo.SIMainInfo.PayCost;
                OwnCost = patientInfo.SIMainInfo.OwnCost;
                PubCost = patientInfo.SIMainInfo.PubCost;
            }

            //头表实体赋值


            balance = ((Neusoft.HISFC.Models.Fee.Inpatient.Balance)balanceList.BalanceBase).Clone();
            balance.BeginTime = this.dtBegin;
            balance.EndTime = this.dtEnd;
            balance.FT.TotCost = TotCost;
            balance.FT.OwnCost = OwnCost;
            balance.FT.PayCost = PayCost;
            balance.FT.PubCost = PubCost;


            if (!this.IsRebatePrint)
            {
                balance.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtRebateFee.Text);
            }
            if (!this.IsDeratePrint)
            {
                balance.FT.DerateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDeratefee.Text);
            }
            if (IsMain)
            {
                balance.FT.PrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPrepayCost.Text);
                //balance.FT.ChangeTotCost = this.TotChangeCost;
                //balance.FT.ChangePrepay = this.ChangePrepay;

                switch (this.payTrace)
                {
                    case "1":
                        balance.FT.SupplyCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtShouldPay.Text);
                        break;
                    case "2":
                        balance.FT.ReturnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtShouldPay.Text);
                        break;
                    case "3":
                        balance.FT.TransferPrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtShouldPay.Text);
                        break;
                }
            }



            return balance;
        }

        /// <summary>
        /// 打印结算发票
        /// </summary>
        protected virtual int PrintInvoice()
        {

            Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy p = null;
            if (this.alBalanceListHead.Count > 0)
            {

                if (this.patientInfo.IsEncrypt)
                {
                    this.patientInfo.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(this.patientInfo.NormalName);
                }

                //ucBalanceInvoice p = new ucBalanceInvoice();
                p = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy;
                p.PatientInfo = this.patientInfo;

                //通过BalanceList信息形成BalanceHead信息
                p.IsMidwayBalance = this.BlanceType;
                //p.IsMidwayBalance = this.IsMidwayBalance;

                Neusoft.HISFC.Models.Fee.Inpatient.Balance BalanceForInvoice = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                BalanceForInvoice = this.MadeBalanceHeadByBalanceList(this.alBalanceListHead, true);
                #region {2F7096E9-7DF9-484a-B31D-EADBF6379810} 如果是定额补偿，总费用为定额
                if (local.isNcum(this.patientInfo.ID)) {
                    BalanceForInvoice.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal( local.GetDeTot(this.patientInfo.ID));
                }
                #endregion

                //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                if (p.SetValueForPrint(this.patientInfo, BalanceForInvoice, this.alBalanceListHead,this.alBalancePay) == -1)
                {
                    this.alBalanceListHead = new ArrayList();
                    //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                    this.alBalancePay = new ArrayList();
                    return -1;
                }
                //调打印类
                p.Print();
            }
            if (this.alBalanceListFood.Count > 0)
            {
                //ucBalanceInvoice p = new ucBalanceInvoice();
                p = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy;
                //通过BalanceList信息形成BalanceHead信息
                p.PatientInfo = this.patientInfo;
                p.IsMidwayBalance = this.BlanceType;
                //p.IsMidwayBalance = this.IsMidwayBalance;
                Neusoft.HISFC.Models.Fee.Inpatient.Balance BalanceForInvoice = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                BalanceForInvoice = this.MadeBalanceHeadByBalanceList(this.alBalanceListFood, false);
                //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                if (p.SetValueForPrint(patientInfo, BalanceForInvoice, this.alBalanceListFood,this.alBalancePay) == -1)
                {

                    this.alBalanceListFood = new ArrayList();
                    //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                    this.alBalancePay = new ArrayList();
                    return -1;
                }
                //调打印类
                p.Print();
            }
            //{31BA07D4-E8F8-4653-A879-1EB59B8E20F3}
            if (this.alBalanceListDerate.Count > 0 && IsDeratePrint)
            {
                // ucBalanceInvoice p = new ucBalanceInvoice();
                p = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy;
                p.IsMidwayBalance = this.BlanceType;
                p.PatientInfo = this.patientInfo;
                //p.IsMidwayBalance = this.IsMidwayBalance;
                //通过BalanceList信息形成BalanceHead信息
                Neusoft.HISFC.Models.Fee.Inpatient.Balance BalanceForInvoice = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                BalanceForInvoice = this.MadeBalanceHeadByBalanceList(this.alBalanceListDerate, false);
                //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                if (p.SetValueForPrint(patientInfo, BalanceForInvoice, this.alBalanceListDerate,this.alBalancePay) == -1)
                {   
                    this.alBalanceListDerate = new ArrayList();
                    //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                    this.alBalancePay = new ArrayList();
                    return -1;
                }
                //调打印类
                p.Print();
            }
            //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            if (this.alBalanceListMannal.Count > 0)
            {

                if (this.patientInfo.IsEncrypt)
                {
                    this.patientInfo.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(this.patientInfo.NormalName);
                }

                //ucBalanceInvoice p = new ucBalanceInvoice();
                p = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy;
                p.PatientInfo = this.patientInfo;

                //通过BalanceList信息形成BalanceHead信息
                p.IsMidwayBalance = this.BlanceType;
                //p.IsMidwayBalance = this.IsMidwayBalance;

                Neusoft.HISFC.Models.Fee.Inpatient.Balance BalanceForInvoice = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                BalanceForInvoice = this.MadeBalanceHeadByBalanceList(this.alBalanceListMannal, true);
                //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                if (p.SetValueForPrint(this.patientInfo, BalanceForInvoice, this.alBalanceListMannal, this.alBalancePay) == -1)
                {
                    this.alBalanceListMannal = new ArrayList();
                    //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
                    this.alBalancePay = new ArrayList();
                    return -1;
                }
                //调打印类
                p.Print();
            }
            return 1;
        }

        /// 插入变更记录
        /// </summary>
        /// <param name="balNo">结算序号</param>
        /// <returns>1成功－1失败</returns>
        protected virtual int InsertShift(int balNo)
        {
            Neusoft.FrameWork.Models.NeuObject oldObj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject newObj = new Neusoft.FrameWork.Models.NeuObject();
            newObj.ID = balNo.ToString();
            newObj.Name = "结算序号";
            if (this.BlanceType == EBlanceType.Mid)
            {
                if (this.radtIntegrate.InsertShiftData(this.patientInfo.ID, Neusoft.HISFC.Models.Base.EnumShiftType.MB, "中途结算", oldObj, newObj) == -1) return -1;

            }
            else
            {
                if (this.radtIntegrate.InsertShiftData(patientInfo.ID, Neusoft.HISFC.Models.Base.EnumShiftType.BA, "出院结算", oldObj, newObj) == -1) return -1;
            }


            return 1;
        }

        /// <summary>
        /// 更新住院主表相关信息
        /// </summary>
        /// <param name="balNo">结算序号</param>
        /// <param name="dtBalance">结算序号</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int UpdateInhos(int balNo, DateTime dtBalance)
        {

            Neusoft.HISFC.Models.Base.FT ft = new Neusoft.HISFC.Models.Base.FT();

            ft.PrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPrepayCost.Text);
            ft.DerateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDeratefee.Text);
            //暂存本地总费用
            decimal tempTot = 0m;

            if (this.BlanceType == EBlanceType.Mid)//中途结算-- 不包含转入费用
            {
                //转入预交金－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
                //ft.ChangePrepay = 0;
                //ft.ChangeTotCost = 0;
                ft.OwnCost = this.TotalOwnCost;
                ft.PayCost = this.TotalPayCost;
                ft.PubCost = this.TotalPubCost;
                ft.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtRebateFee.Text);
                ft.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtBalanceCost.Text);
                //加一个判断
                #region {2F7096E9-7DF9-484a-B31D-EADBF6379810}
                bool isNcum = local.isNcum(this.patientInfo.ID);
                #endregion
                //允许0.01的误差
                if (!isNcum) {
                    //如果是定额大病就不进行判断
                    if (Math.Abs(ft.TotCost - (ft.OwnCost + ft.PayCost + ft.PubCost + ft.RebateCost)) > 0.01m)
                    {
                        this.feeInpatient.Err = "总费用与分支费用相加不等";
                        return -1;
                    }
                }
                //{411B146C-F152-402b-AF0B-C332D8DFFF59}
                //转押金
                if (this.payTrace == "3")
                {
                    decimal transPrepay = 0m;
                    for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
                    {
                        if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text == "转押金" &&
                            Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString()) > 0)
                        {
                            transPrepay += Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                        }
                    }
                    ft.TransferPrepayCost = transPrepay;
                }
            }
            else
            {
                //转入预交金--------------------------------------------------------
                //ft.ChangePrepay = this.ChangePrepay;

                //转入费用

                Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfo = new FeeInfo();
                //feeInfo = this.feeInpatient.GetChangeCostTotal(this.patientInfo.ID, "0");
                //if (feeInfo == null)
                //{
                //    Neusoft.FrameWork.WinForms.Classes.Function.Msg("获取转入费用总额出错for主表!" + this.feeInpatient.Err,211);
                //    return -1;
                //}
                //转入预交金--------------------------------------------------------
                //ft.ChangeTotCost = feeInfo.FT.TotCost;
                //全局的结转总额赋值


                //this.TotChangeCost = ft.ChangeTotCost;
                ft.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtBalanceCost.Text) - feeInfo.FT.TotCost;
                ft.OwnCost = this.TotalOwnCost - feeInfo.FT.OwnCost;
                ft.PayCost = this.TotalPayCost - feeInfo.FT.PayCost;
                ft.PubCost = this.TotalPubCost - feeInfo.FT.PubCost;
                ft.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtRebateFee.Text) - feeInfo.FT.RebateCost;
                this.patientInfo.PVisit.InState.ID = Neusoft.HISFC.Models.Base.EnumInState.O;
                //加一个判断

                #region {2F7096E9-7DF9-484a-B31D-EADBF6379810} modified by xizf@neusoft.com 20110411
                bool isNcum = local.isNcum(this.patientInfo.ID);
                #endregion
                //允许0.01的误差
                if (!isNcum)
                {
                    //如果是定额大病就不进行判断
                    if (Math.Abs(ft.TotCost - (ft.OwnCost + ft.PayCost + ft.PubCost + ft.RebateCost)) > 0.01m)
                    {
                        this.feeInpatient.Err = "总费用与分支费用相加不等";
                        return -1;
                    }
                }
                else { 
                    //如果是大病，因为新农合不支持中途结算，所以此处可将总费用更新为医保总费用，不然
                    //会造成结算完之后主表总费用不为0 modified by xizf@neusoft.com 20110411
                    tempTot = ft.TotCost;//暂存
                    ft.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(local.GetDeUnbalTot(this.patientInfo.ID));
                }
            }
            if (this.feeInpatient.UpdateInMainInfoBalanced(this.patientInfo, dtBalance, balNo, ft) <= 0) return -1;
            ft.TotCost = tempTot;//恢复
            //{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F} 婴儿的费用是否可以收取到妈妈身上
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            string motherPayAllFee = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Mother_PayAllFee, false, "0");
            if (motherPayAllFee == "1")//婴儿的费用收在妈妈的身上 
            {
                ArrayList babyList = this.radtIntegrate.QueryBabiesByMother(this.patientInfo.ID);
                if (babyList != null && babyList.Count > 0) 
                {
                    foreach (Neusoft.HISFC.Models.RADT.PatientInfo p in babyList) 
                    {
                        Neusoft.HISFC.Models.RADT.PatientInfo pTemp = this.radtIntegrate.GetPatientInfomation(p.ID);
                        if (pTemp != null && !string.IsNullOrEmpty(pTemp.ID)) 
                        {
                            pTemp.PVisit = this.patientInfo.PVisit.Clone();
                            if (this.feeInpatient.UpdateInMainInfoBalanced(pTemp, dtBalance, balNo, new Neusoft.HISFC.Models.Base.FT()) <= 0) return -1;
                        }
                    }
                }
            }

            return 1;
        }

        /// <summary>
        /// 插入结算支付信息
        /// </summary>
        /// <param name="balNo">结算序号</param>
        /// <param name="dtBalance">结算时间</param>
        /// <param name="invoiceNo">发票号</param>
        /// <returns>1成功 －1 失败</returns>
        protected int InsertBalancePay(int balNo, DateTime dtBalance, string invoiceNo)
        {
            string payType = "";
            decimal payTypeCost = 0m;
            string bankName = "";
            //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
            this.alBalancePay = new ArrayList(); //重新清空一下

            //循环查找支付方式和金额


            for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
            {
                payType = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text;
                bankName = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户银行")].Text;
                if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value == null)
                {
                    payTypeCost = 0;
                }
                else
                {
                    payTypeCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                }
                if (payType.Trim() != "" && payTypeCost > 0)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.BalancePay balancePay = new BalancePay();
                    balancePay.Invoice.ID = invoiceNo;
                    balancePay.TransKind.ID = "1";
                    balancePay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                    balancePay.PayType.ID = Function.GetPayTypeIdByName(payType);
                    if (balancePay.PayType.ID == null || balancePay.PayType.ID.ToString().Trim() == "") return -1;
                    balancePay.BalanceNO = balNo;
                    balancePay.FT.TotCost = payTypeCost;
                    balancePay.Qty = 1;
                    balancePay.Bank.ID = Function.GetBankIdByName(bankName);
                    balancePay.Bank.Name = bankName;
                    balancePay.Bank.Account = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户帐号")].Text;
                    balancePay.Bank.WorkName = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开据单位")].Text;
                    balancePay.Bank.InvoiceNO = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支票号/交易流水号")].Text;
                    balancePay.RetrunOrSupplyFlag = payTrace;

                    balancePay.BalanceOper.ID = this.feeInpatient.Operator.ID;

                    balancePay.BalanceOper.OperTime = dtBalance;
                    //添加记录
                    if (this.feeInpatient.InsertBalancePay(balancePay) == -1) return -1;
                }



            }
            //插入结算预交金额
            if (this.fpPrepay_Sheet1.RowCount > 0)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalancePay Bpay = new BalancePay();
                Bpay.Invoice.ID = invoiceNo;
                Bpay.TransKind.ID = "0";
                Bpay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                Bpay.PayType.ID = "CA";
                Bpay.BalanceNO = balNo;
                Bpay.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPrepayCost.Text);
                Bpay.Qty = this.fpPrepay_Sheet1.RowCount; ;
                Bpay.BalanceOper.ID = this.feeInpatient.Operator.ID;
                Bpay.BalanceOper.OperTime = dtBalance;
                Bpay.RetrunOrSupplyFlag = this.payTrace;
                //添加记录
                if (this.feeInpatient.InsertBalancePay(Bpay) == -1) return -1;

            }

            return 1;
        }

        /// <summary>
        /// 获取支付方式
        /// </summary>
        /// <returns></returns>
        protected ArrayList GetBalancePay()
        {
            string payType = "";
            decimal payTypeCost = 0m;
            string bankName = "";

            ArrayList alPayMode = new ArrayList();
            //循环查找支付方式和金额



            for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
            {
                payType = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text;
                bankName = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户银行")].Text;
                if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value == null)
                {
                    payTypeCost = 0;
                }
                else
                {
                    payTypeCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                }
                if (payType.Trim() != "" && payTypeCost > 0)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.BalancePay balancePay = new BalancePay();


                    balancePay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                    balancePay.PayType.ID = Function.GetPayTypeIdByName(payType);
                    if (balancePay.PayType.ID == null || balancePay.PayType.ID.ToString().Trim() == "") return null;

                    balancePay.FT.TotCost = payTypeCost;
                    balancePay.Qty = 1;
                    balancePay.Bank.ID = Function.GetBankIdByName(bankName);
                    balancePay.Bank.Name = bankName;
                    balancePay.Bank.Account = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户帐号")].Text;
                    balancePay.Bank.WorkName = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开据单位")].Text;
                    balancePay.Bank.InvoiceNO = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支票号/交易流水号")].Text;
                    balancePay.RetrunOrSupplyFlag = payTrace;

                    balancePay.BalanceOper.ID = this.feeInpatient.Operator.ID;


                    //添加记录
                    //if (this.feeInpatient.InsertBalancePay(balancePay) == -1) return -1;
                    alPayMode.Add(balancePay);

                }
            }

            return alPayMode;
        }

        /// <summary>
        ///  插入结算头
        /// </summary>
        /// <returns></returns>
        protected int InsertBalanceHead()
        {

            //主发票记录


            if (this.alBalanceListHead.Count > 0)
            {
                BalanceList balanceList = null;
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                decimal TotCost = 0m;
                decimal OwnCost = 0m;
                decimal PayCost = 0m;
                decimal PubCost = 0m;
                for (int i = 0; i < this.alBalanceListHead.Count; i++)
                {
                    balanceList = (BalanceList)this.alBalanceListHead[i];
                    TotCost += balanceList.BalanceBase.FT.TotCost;
                    OwnCost += balanceList.BalanceBase.FT.OwnCost;
                    PayCost += balanceList.BalanceBase.FT.PayCost;
                    PubCost += balanceList.BalanceBase.FT.PubCost;

                }
                //保险接口－－－－－－－－－－－－－－－－－－－－－－－－－－

                //头表实体赋值


                balanceHead = ((Neusoft.HISFC.Models.Fee.Inpatient.Balance)balanceList.BalanceBase).Clone();
                balanceHead.BeginTime = this.dtBegin;
                balanceHead.EndTime = this.dtEnd;
                balanceHead.FT.TotCost = TotCost;
                balanceHead.FT.OwnCost = OwnCost;
                balanceHead.FT.PayCost = PayCost;
                balanceHead.FT.PubCost = PubCost;

                balanceHead.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                balanceHead.IsMainInvoice = true;
                if (!this.IsRebatePrint)
                {
                    balanceHead.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtRebateFee.Text);
                }
                if (!this.IsDeratePrint)
                {
                    balanceHead.FT.DerateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDeratefee.Text);
                }
                balanceHead.FT.PrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPrepayCost.Text);
                //插入转入预交金暂时屏蔽


                //balanceHead.FT.ChangeTotCost= this.TotChangeCost;
                //balanceHead.FT.ChangePrepay = this.ChangePrepay;
                //保险接口－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
                ////生育保险最终结算标记////公费患者日限额结算调整等操作





                switch (this.payTrace)
                {
                    case "1":
                        balanceHead.FT.SupplyCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtShouldPay.Text);
                        break;
                    case "2":
                        balanceHead.FT.ReturnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtShouldPay.Text);
                        break;
                    case "3":
                        balanceHead.FT.TransferPrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtShouldPay.Text);
                        break;
                }

                if (this.patientInfo.Pact.PayKind.ID == "02")
                {

                    balanceHead.FT.OwnCost = this.patientInfo.SIMainInfo.OwnCost - balanceHead.FT.DerateCost - balanceHead.FT.RebateCost;
                    balanceHead.FT.PayCost = this.patientInfo.SIMainInfo.PayCost;
                    balanceHead.FT.PubCost = this.patientInfo.SIMainInfo.PubCost;
                }

                //插入结算头表
                if (this.feeInpatient.InsertBalance(this.patientInfo, balanceHead) < 1) return -1;

            }
            //{31BA07D4-E8F8-4653-A879-1EB59B8E20F3}
            if (this.alBalanceListDerate.Count > 0 && IsDeratePrint)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList = null;
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceDerate = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                decimal TotCost = 0m;
                decimal OwnCost = 0m;
                decimal PayCost = 0m;
                decimal PubCost = 0m;

                for (int i = 0; i < this.alBalanceListDerate.Count; i++)
                {
                    balanceList = (BalanceList)this.alBalanceListDerate[i];
                    TotCost += balanceList.BalanceBase.FT.TotCost;
                    OwnCost += balanceList.BalanceBase.FT.OwnCost;
                    PayCost += balanceList.BalanceBase.FT.PayCost;
                    PubCost += balanceList.BalanceBase.FT.PubCost;
                }
                //头表实体赋值


                balanceDerate = ((Neusoft.HISFC.Models.Fee.Inpatient.Balance)balanceList.BalanceBase).Clone();
                balanceDerate.FT.TotCost = TotCost;
                balanceDerate.FT.OwnCost = OwnCost;
                balanceDerate.FT.PayCost = PayCost;
                balanceDerate.FT.PubCost = PubCost;
                balanceDerate.FT.DerateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDeratefee.Text);
                balanceDerate.BeginTime = this.dtBegin;
                balanceDerate.EndTime = this.dtEnd;

                balanceDerate.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                balanceDerate.IsMainInvoice = false;
                //插入结算头表
                if (this.feeInpatient.InsertBalance(this.patientInfo, balanceDerate) < 1) return -1;

            }
            //优惠记录
            if (this.alBalanceListRebate.Count > 0)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList BList = null;
                Neusoft.HISFC.Models.Fee.Inpatient.Balance BalanceRebate = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                decimal TotCost = 0m;
                decimal OwnCost = 0m;
                decimal PayCost = 0m;
                decimal PubCost = 0m;
                for (int i = 0; i < this.alBalanceListRebate.Count; i++)
                {
                    BList = (BalanceList)this.alBalanceListRebate[i];
                    TotCost += BList.BalanceBase.FT.TotCost;
                    OwnCost += BList.BalanceBase.FT.OwnCost;
                    PayCost += BList.BalanceBase.FT.PayCost;
                    PubCost += BList.BalanceBase.FT.PubCost;

                }
                //头表实体赋值


                BalanceRebate = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)BList.BalanceBase.Clone();
                BalanceRebate.FT.TotCost = TotCost;
                BalanceRebate.FT.OwnCost = OwnCost;
                BalanceRebate.FT.PayCost = PayCost;
                BalanceRebate.FT.PubCost = PubCost;
                BalanceRebate.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtRebateFee.Text);
                BalanceRebate.BeginTime = this.dtBegin;
                BalanceRebate.EndTime = this.dtEnd;

                BalanceRebate.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                BalanceRebate.IsMainInvoice = false;
                //插入结算头表
                if (this.feeInpatient.InsertBalance(this.patientInfo, BalanceRebate) < 1) return -1;
            }
            //膳食记录
            if (this.alBalanceListFood.Count > 0)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList = null;
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceFood = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                decimal TotCost = 0m;
                decimal OwnCost = 0m;
                decimal PayCost = 0m;
                decimal PubCost = 0m;

                for (int i = 0; i < this.alBalanceListFood.Count; i++)
                {
                    balanceList = (BalanceList)this.alBalanceListFood[i];
                    TotCost += balanceList.BalanceBase.FT.TotCost;
                    OwnCost += balanceList.BalanceBase.FT.OwnCost;
                    PayCost += balanceList.BalanceBase.FT.PayCost;
                    PubCost += balanceList.BalanceBase.FT.PubCost;
                }
                //头表实体赋值


                balanceFood = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)balanceList.BalanceBase.Clone();
                balanceFood.BeginTime = this.dtBegin;
                balanceFood.EndTime = this.dtEnd;
                balanceFood.FT.TotCost = TotCost;
                balanceFood.FT.OwnCost = OwnCost;
                balanceFood.FT.PayCost = PayCost;
                balanceFood.FT.PubCost = PubCost;

                balanceFood.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                balanceFood.IsMainInvoice = false;
                //插入结算头表
                if (this.feeInpatient.InsertBalance(this.patientInfo, balanceFood) < 1) return -1;

            }
            //婴儿发票
            if (this.alBalanceListBaby.Count > 0)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList = null;
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceBaby = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                decimal TotCost = 0m;
                decimal OwnCost = 0m;
                decimal PayCost = 0m;
                decimal PubCost = 0m;

                for (int i = 0; i < this.alBalanceListBaby.Count; i++)
                {
                    balanceList = (BalanceList)this.alBalanceListBaby[i];
                    TotCost += balanceList.BalanceBase.FT.TotCost;
                    OwnCost += balanceList.BalanceBase.FT.OwnCost;
                    PayCost += balanceList.BalanceBase.FT.PayCost;
                    PubCost += balanceList.BalanceBase.FT.PubCost;

                }
                //头表实体赋值


                balanceBaby = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)balanceList.BalanceBase.Clone();
                balanceBaby.BeginTime = this.dtBegin;
                balanceBaby.EndTime = this.dtEnd;
                balanceBaby.FT.TotCost = TotCost;
                balanceBaby.FT.OwnCost = OwnCost;
                balanceBaby.FT.PayCost = PayCost;
                balanceBaby.FT.PubCost = PubCost;

                balanceBaby.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                balanceBaby.IsMainInvoice = false;
                //插入结算头表
                if (this.feeInpatient.InsertBalance(this.patientInfo, balanceBaby) < 1) return -1;
            }

            //手工分票{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            if (this.alBalanceListMannal.Count > 0)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList = null;
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceMannal = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                decimal TotCost = 0m;
                decimal OwnCost = 0m;
                decimal PayCost = 0m;
                decimal PubCost = 0m;

                for (int i = 0; i < this.alBalanceListMannal.Count; i++)
                {
                    balanceList = (BalanceList)this.alBalanceListMannal[i];
                    TotCost += balanceList.BalanceBase.FT.TotCost;
                    OwnCost += balanceList.BalanceBase.FT.OwnCost;
                    PayCost += balanceList.BalanceBase.FT.PayCost;
                    PubCost += balanceList.BalanceBase.FT.PubCost;

                }
                //头表实体赋值


                balanceMannal = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)balanceList.BalanceBase.Clone();
                balanceMannal.BeginTime = this.dtBegin;
                balanceMannal.EndTime = this.dtEnd;
                balanceMannal.FT.TotCost = TotCost;
                balanceMannal.FT.OwnCost = OwnCost;
                balanceMannal.FT.PayCost = PayCost;
                balanceMannal.FT.PubCost = PubCost;

                balanceMannal.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                balanceMannal.IsMainInvoice = false;
                //插入结算头表
                if (this.feeInpatient.InsertBalance(this.patientInfo, balanceMannal) < 1) return -1;
            }
            return 1;
        }
        /// <summary>
        ///  添加结算明细记录信息
        /// </summary>
        /// <returns></returns>
        protected virtual int InsertIntoBalanceList()
        {
            Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList;
            //插入主发票信息


            for (int i = 0; i < this.alBalanceListHead.Count; i++)
            {
                balanceList = (BalanceList)alBalanceListHead[i];
                if (this.feeInpatient.InsertBalanceList(this.patientInfo, balanceList) < 1) return -1;
            }
            //{31BA07D4-E8F8-4653-A879-1EB59B8E20F3}
            //插入减免发票信息
            if (this.alBalanceListDerate.Count > 0  && IsDeratePrint)
            {
                for (int j = 0; j < this.alBalanceListDerate.Count; j++)
                {
                    balanceList = (BalanceList)alBalanceListDerate[j];
                    if (this.feeInpatient.InsertBalanceList(this.patientInfo, balanceList) == -1) return -1;
                }
            }
            //插入优惠发票信息
            if (this.alBalanceListRebate.Count > 0)
            {
                for (int j = 0; j < this.alBalanceListRebate.Count; j++)
                {
                    balanceList = (BalanceList)this.alBalanceListRebate[j];
                    if (this.feeInpatient.InsertBalanceList(this.patientInfo, balanceList) == -1) return -1;
                }
            }
            //插入膳食发票信息
            if (this.alBalanceListFood.Count > 0)
            {
                for (int j = 0; j < this.alBalanceListFood.Count; j++)
                {
                    balanceList = (BalanceList)this.alBalanceListFood[j];
                    if (this.feeInpatient.InsertBalanceList(this.patientInfo, balanceList) == -1) return -1;
                }
            }
            //插入婴儿发票信息
            if (this.alBalanceListBaby.Count > 0)
            {
                for (int j = 0; j < this.alBalanceListBaby.Count; j++)
                {
                    balanceList = (BalanceList)this.alBalanceListBaby[j];
                    if (this.feeInpatient.InsertBalanceList(this.patientInfo, balanceList) == -1) return -1;
                }
            }

            //插入手工发票信息{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            if (this.alBalanceListMannal.Count > 0)
            {
                for (int j = 0; j < this.alBalanceListMannal.Count; j++)
                {
                    balanceList = (BalanceList)this.alBalanceListMannal[j];
                    if (this.feeInpatient.InsertBalanceList(this.patientInfo, balanceList) == -1) return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// 将结算的费用信息置为结算状态
        /// </summary>
        /// <param name="balNo">结算序号</param>
        /// <param name="dtSys">结算时间</param>
        /// <param name="invoiceNo">发票号码</param>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        protected virtual int UpdateFeeBalanced(int balNo, DateTime dtSys, string invoiceNo, DateTime dtBegin, DateTime dtEnd)
        {
            if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe)
            {
                //出院结算更新费用
                //判断并发操作
                int result = 0;
                result = this.feeInpatient.UpdateFeeInfoBalanced(patientInfo.ID, balNo, dtSys, invoiceNo);
                if (result == 0)
                {
                    this.feeInpatient.Err = "可能存在并发操作导致";
                    return -1;
                }
                if (result < 1) return -1;
                if (this.feeInpatient.UpdateFeeItemListBalanced(patientInfo.ID, balNo, invoiceNo) == -1) return -1;
                if (this.feeInpatient.UpdateMedItemListBalanced(patientInfo.ID, balNo, invoiceNo) == -1) return -1;
                //更新转入费用
                if (this.feeInpatient.UpdateAllChangeCostBalanced(patientInfo.ID, balNo) == -1) return -1;

            }
            else
            {
                Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
                //中途结算费用更新---先按时间全部更新后判断是否有金额不等
                for (int i = 0; i < this.fpCost_Sheet1.RowCount; i++)
                {
                    if ((bool)this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("选择")].Value == true)
                    {
                        f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)this.fpCost_Sheet1.Rows[i].Tag;
                        //首先先更新未结算---如果不相等等拆处方


                        //判断并发
                        int Result = 0;
                        Result = this.feeInpatient.UpdateFeeInfoBalanced(patientInfo.ID, balNo, dtSys, invoiceNo, this.dtBegin, this.dtEnd, f.Item.MinFee.ID);
                        if (Result == 0)
                        {
                            this.feeInpatient.Err = "可能存在并发操作导致";
                            return -1;
                        }
                        if (Result < 1) return -1;
                        if (this.feeInpatient.UpdateFeeItemListBalanced(patientInfo.ID, balNo, invoiceNo, this.dtBegin, this.dtEnd, f.Item.MinFee.ID) == -1) return -1;
                        if (this.feeInpatient.UpdateMedItemListBalanced(patientInfo.ID, balNo, invoiceNo, this.dtBegin, this.dtEnd, f.Item.MinFee.ID) == -1) return -1;
                        if (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()), 2) < Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("未结金额")].Value.ToString()), 2))
                        {

                            //查找原始相等的记录


                            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo finfo;
                            for (int j = 0; j < this.alFeeInfo.Count; j++)
                            {
                                finfo = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)this.alFeeInfo[j];
                                if (f.Item.MinFee.ID == finfo.Item.MinFee.ID)
                                {
                                    //实体赋值--形成未结算正记录
                                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList itemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                                    itemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("未结金额")].Value.ToString()), 2) - Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()), 2);
                                    itemList.FT.OwnCost = finfo.FT.OwnCost - f.FT.OwnCost;
                                    itemList.FT.PayCost = finfo.FT.PayCost - f.FT.PayCost;
                                    itemList.FT.PubCost = finfo.FT.PubCost - f.FT.PubCost;
                                    itemList.FT.RebateCost = finfo.FT.RebateCost - f.FT.RebateCost;
                                    if ((itemList.FT.TotCost) != (itemList.FT.OwnCost + itemList.FT.PubCost + itemList.FT.PayCost + itemList.FT.RebateCost))
                                    {
                                        MessageBox.Show("拆分处方金额相加不等于总金额");
                                        return -1;
                                    }

                                    itemList.RecipeNO = this.feeInpatient.GetUndrugRecipeNO();
                                    itemList.SequenceNO = 1;
                                    itemList.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;//-------
                                    itemList.RecipeOper.ID = "中结";

                                    itemList.StockOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;
                                    itemList.ExecOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;
                                    itemList.RecipeOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;

                                    ((Neusoft.HISFC.Models.RADT.PatientInfo)itemList.Patient).PVisit.PatientLocation.NurseCell.ID = this.patientInfo.PVisit.PatientLocation.NurseCell.ID;

                                    itemList.Item.ID = "faaaaaaaaaaaaa";
                                    itemList.Item.Name = "中结差额款";
                                    itemList.Item.MinFee.ID = f.Item.MinFee.ID;
                                    //单价等于总额数量为1
                                    itemList.Item.Price = itemList.FT.TotCost;
                                    itemList.Item.Qty = 1;
                                    itemList.Item.PriceUnit = "次";
                                    //itemList.Item.IsPharmacy = false;
                                    itemList.Item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                                    itemList.PayType = Neusoft.HISFC.Models.Base.PayTypes.Balanced;
                                    itemList.BalanceNO = 0;
                                    itemList.ChargeOper.ID = this.feeInpatient.Operator.ID;
                                    itemList.ChargeOper.OperTime = dtSys;
                                    //整处方婴儿标记为false
                                    itemList.IsBaby = false;
                                    itemList.FeeOper.ID = this.feeInpatient.Operator.ID;
                                    itemList.FeeOper.OperTime = dtSys;
                                    itemList.ExecOper.ID = this.feeInpatient.Operator.ID;
                                    itemList.ExecOper.OperTime = dtSys;
                                    //插入正记录未结算实体
                                    if (this.feeInpatient.InsertFeeItemList(this.patientInfo, itemList) <= 0) return -1;
                                    //赋值形成负记录结算实体
                                    itemList.Item.Qty = -itemList.Item.Qty;
                                    itemList.FT.TotCost = -itemList.FT.TotCost;
                                    itemList.FT.OwnCost = -itemList.FT.OwnCost;
                                    itemList.FT.PayCost = -itemList.FT.PayCost;
                                    itemList.FT.PubCost = -itemList.FT.PubCost;
                                    itemList.FT.RebateCost = -itemList.FT.RebateCost;
                                    itemList.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                                    itemList.Invoice.ID = invoiceNo;
                                    itemList.BalanceOper.OperTime = dtSys;
                                    itemList.BalanceNO = balNo;
                                    itemList.BalanceState = "1";
                                    //插入负记录结算记录


                                    if (this.feeInpatient.InsertFeeItemList(this.patientInfo, itemList) <= 0) return -1;
                                    break;

                                }
                            }

                        }
                    }

                }
            }
            return 1;
        }
        /// <summary>
        /// 初始化发票组各费用信息---形成赋值后balancelist数组数据
        /// </summary>
        /// <param name="invoiceType">发票所属大类，如“ZY01”“ZY02”“ZY03”等</param>
        /// <param name="balNo">结算序号</param>
        /// <param name="invoiceNo">发票号</param>
        /// <param name="dtSys">结算时间</param>
        /// <param name="IsPreview">是否预览</param>
        /// <returns></returns>
        /// <remarks> 2007-8-23 liuq 添加发票大类参数，以适应多种发票格式的情况。</remarks>
        protected virtual int InitInvoice(string invoiceType, int balNo, string invoiceNo, DateTime dtSys, bool IsPreview)
        {
            ArrayList alInvoiceHeadFeeInfo = new ArrayList();
            ArrayList alInvoiceDerateFeeInfo = new ArrayList();
            ArrayList alInvoiceFoodFeeInfo = new ArrayList();
            ArrayList alInvoiceBabyFeeInfo = new ArrayList();
            ArrayList alInvoiceRebateFeeInfo = new ArrayList();
            ArrayList alFeeState = new ArrayList();
            //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
            this.alBalancePay = new ArrayList();


            //初始化全局数组,清空防止发票预览产生的数组信息


            this.alBalanceListBaby = new ArrayList();
            this.alBalanceListDerate = new ArrayList();
            this.alBalanceListFood = new ArrayList();
            this.alBalanceListHead = new ArrayList();
            this.alBalanceListRebate = new ArrayList();
            //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            this.alBalanceListMannal = new ArrayList();

            //将现有的结算好的feeinfo的汇总信息接过来
            for (int i = 0; i < this.fpCost_Sheet1.RowCount; i++)
            {
                if ((bool)this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("选择")].Value == true)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
                    f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)this.fpCost_Sheet1.Rows[i].Tag;
                    //if(ft.FT.TotCost>0)
                    //{
                    alInvoiceHeadFeeInfo.Add(f);
                    //}	
                }
            }
            #region  生成支付信息 {B7A6B07C-165A-4a7b-B53C-A959F765D94D}
            string payType = "";
            decimal payTypeCost = 0m;
            string bankName = "";
            for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
            {
                payType = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text;
                bankName = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户银行")].Text;
                if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value == null)
                {
                    payTypeCost = 0;
                }
                else
                {
                    payTypeCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                }
                if (payType.Trim() != "" && payTypeCost > 0)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.BalancePay balancePay = new BalancePay();
                    balancePay.Invoice.ID = invoiceNo;
                    balancePay.TransKind.ID = "1";
                    balancePay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                    balancePay.PayType.ID = Function.GetPayTypeIdByName(payType);
                    if (balancePay.PayType.ID == null || balancePay.PayType.ID.ToString().Trim() == "") return -1;
                    balancePay.BalanceNO = balNo;
                    balancePay.FT.TotCost = payTypeCost;
                    balancePay.Qty = 1;
                    balancePay.Bank.ID = Function.GetBankIdByName(bankName);
                    balancePay.Bank.Name = bankName;
                    balancePay.Bank.Account = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户帐号")].Text;
                    balancePay.Bank.WorkName = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开据单位")].Text;
                    balancePay.Bank.InvoiceNO = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支票号/交易流水号")].Text;
                    balancePay.RetrunOrSupplyFlag = payTrace;

                    balancePay.BalanceOper.ID = this.feeInpatient.Operator.ID;

                    balancePay.BalanceOper.OperTime = feeDerate.GetDateTimeFromSysDateTime();

                    this.alBalancePay.Add(balancePay.Clone());
                }
            }
            #endregion 

            //首先获取减免最小费用列表---如果输入的就形成(形成同时插入减免表)如果不输入检索



            if ((this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe) && decimal.Parse(this.txtDeratefee.Text) > 0)
            {
                if (this.IsInputDerateFee)
                {
                    alInvoiceDerateFeeInfo = this.feeDerate.GetFeeCodeAndDerateCost(this.patientInfo.ID, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDeratefee.Text), this.TotalOwnCost);
                    if (alInvoiceDerateFeeInfo == null)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("分配减免金额出错!zhangjy业务层" + this.feeDerate.Err, 211);
                        return -1;
                    }
                    //循环插入减免记录表


                    for (int i = 0; i < alInvoiceDerateFeeInfo.Count; i++)
                    {
                        Neusoft.HISFC.Models.Fee.Rate rate = new Rate();
                        Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
                        f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alInvoiceDerateFeeInfo[i];
                        //						d = (Rate)alInvoiceDerateFeeInfo[i];

                        rate.derate_Cost = f.FT.TotCost;
                        rate.FeeCode = f.Item.MinFee.ID;
                        rate.clinicNo = this.patientInfo.ID;
                        rate.derateKind = "1";
                        rate.derate_cause = "结算减免";
                        rate.deptCode = this.patientInfo.PVisit.PatientLocation.Dept.ID;
                        rate.balanceState = "1";
                        rate.BalanceNo = balNo;
                        rate.invoiceNo = invoiceNo;
                        if (this.feeDerate.InsertDerate(rate) == -1)
                        {
                            MessageBox.Show(this.feeDerate.Err);
                            return -1;
                        }
                    }

                }
                else
                {
                    //{BD300517-D927-43c0-A1D3-8FB99BD10298}
                    alInvoiceDerateFeeInfo = this.feeDerate.GetFeeCodeAndDerateCost(this.patientInfo.ID,balNo.ToString());
                    if (alInvoiceDerateFeeInfo == null)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取减免费用信息出错!zhangjy业务层" + this.feeDerate.Err, 211);
                        return -1;
                    }

                }
            }


            //判断减免是否单独打印发票---如果单独打印将原有的owncost和totcost-减免cost
            if (this.IsDeratePrint && (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe) && alInvoiceDerateFeeInfo.Count > 0)
            {
                for (int i = 0; i < alInvoiceDerateFeeInfo.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeinfoDerate;
                    feeinfoDerate = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alInvoiceDerateFeeInfo[i];
                    for (int j = 0; j < alInvoiceHeadFeeInfo.Count; j++)
                    {
                        Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeinfoHead;
                        feeinfoHead = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alInvoiceHeadFeeInfo[j];
                        if (feeinfoHead.Item.MinFee.ID == feeinfoDerate.Item.MinFee.ID)
                        {
                            if (feeinfoHead.FT.OwnCost < feeinfoDerate.FT.OwnCost)
                            {
                                this.feeInpatient.Err = "费用代码为" + feeinfoDerate.Item.MinFee.ID + "的减免费用大于该项可结算自费金额";
                                return -1;
                            }
                            feeinfoHead.FT.OwnCost = feeinfoHead.FT.OwnCost - feeinfoDerate.FT.OwnCost;
                            feeinfoHead.FT.TotCost = feeinfoHead.FT.TotCost - feeinfoDerate.FT.TotCost;

                        }
                    }
                }
            }


            //判断优惠是否单独打印发票
            if (this.IsRebatePrint && decimal.Parse(this.txtDeratefee.Text) > 0)
            {
                for (int i = 0; i < alInvoiceHeadFeeInfo.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
                    f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alInvoiceHeadFeeInfo[i];
                    if (f.FT.RebateCost > 0)
                    {
                        Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfoRebate = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
                        FeeInfoRebate.Item.MinFee.ID = f.Item.MinFee.ID;
                        FeeInfoRebate.FT.RebateCost = f.FT.RebateCost;
                        FeeInfoRebate.FT.TotCost = f.FT.TotCost;
                        alInvoiceRebateFeeInfo.Add(FeeInfoRebate);
                    }
                }
            }
            //判断是否膳食单独打印发票

            if (this.IsFoodPrint)
            {
                string foodMinfeeID = "";
                foodMinfeeID = this.controlParm.QueryControlerInfo("100014");

                if (foodMinfeeID == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取营养膳食最小费用编码出错!" + this.controlParm.Err, 211);
                    return -1;
                }
                for (int i = 0; i < alInvoiceHeadFeeInfo.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
                    f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alInvoiceHeadFeeInfo[i];
                    if (f.Item.MinFee.ID == foodMinfeeID)
                    {
                        alInvoiceHeadFeeInfo.RemoveAt(i);
                        alInvoiceFoodFeeInfo.Add(f);
                    }
                }
            }
            //判断婴儿费用是否单独打印发票 
            if (this.IsBabyPrint && this.patientInfo.IsBaby)
            {

                ArrayList al = new ArrayList();
                al = this.feeInpatient.QueryFeeInfosGroupByMinFeeForBaby(patientInfo.ID, this.dtBegin, this.dtEnd, "0");
                if (al == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取婴儿费用出错!", 211);
                    return -1;
                }
                for (int i = 0; i < alInvoiceHeadFeeInfo.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
                    f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alInvoiceHeadFeeInfo[i];
                    for (int j = 0; j < al.Count; j++)
                    {
                        Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeinfoBaby;
                        feeinfoBaby = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)al[j];
                        if (f.Item.MinFee.ID == feeinfoBaby.Item.MinFee.ID)
                        {
                            if (f.FT.TotCost - feeinfoBaby.FT.TotCost < 0)
                            {
                                Neusoft.FrameWork.WinForms.Classes.Function.Msg("输入的结算金额小于婴儿实际发生费用,打印婴儿发票时出错!", 211);
                                return -1;

                            }
                            f.FT.TotCost = f.FT.TotCost - feeinfoBaby.FT.TotCost;
                            f.FT.OwnCost = f.FT.OwnCost - feeinfoBaby.FT.OwnCost;
                            f.FT.PayCost = f.FT.PayCost - feeinfoBaby.FT.PayCost;
                            f.FT.PubCost = f.FT.PubCost - feeinfoBaby.FT.PubCost;
                            if (!this.IsRebatePrint)
                            {
                                f.FT.RebateCost = f.FT.RebateCost - feeinfoBaby.FT.RebateCost;
                            }
                            alInvoiceBabyFeeInfo.Add(feeinfoBaby);
                        }
                    }

                }
            }

            #region 手工拆发票{8D10153C-ECC4-498c-AFF0-EFD70208BE82} 中途结算不允许手工拆票

            ArrayList alInvoiceManualFeeInfo = new ArrayList();

            //取得拆分金额
            decimal splitCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtMannalCost.Text) ;

            if ((this.blanceType == EBlanceType.Out || this.blanceType == EBlanceType.Owe) && splitCost > 0)
            {
                decimal splitCostLeft = splitCost;

                decimal totCost = 0.00m;

                //获得费用总额
                foreach (FeeInfo feeInfoHead in alInvoiceHeadFeeInfo)
                {
                    totCost += feeInfoHead.FT.TotCost;
                }
                //循环处理分票明细及主发票明细
                //
                for (int i = 0; i < alInvoiceHeadFeeInfo.Count; i++)
                {
                    FeeInfo InvoiceHeadInfo = alInvoiceHeadFeeInfo[i] as FeeInfo;
                    FeeInfo InvoiceManualInfo = InvoiceHeadInfo.Clone();


                    decimal splitCostTemp = Neusoft.FrameWork.Function.NConvert.ToDecimal(Neusoft.FrameWork.Public.String.FormatNumberReturnString(InvoiceHeadInfo.FT.TotCost * (splitCost / totCost), 2));

                    //if (splitCostLeft > 0) //如果项目金额大于剩余金额
                    //{
                    //如果一行
                    //if (i == alInvoiceHeadFeeInfo.Count - 1)
                    //{
                    //    InvoiceManualInfo.FT.TotCost = splitCostLeft;
                    //    InvoiceHeadInfo.FT.TotCost = InvoiceHeadInfo.FT.TotCost - InvoiceManualInfo.FT.TotCost;


                    //    InvoiceManualInfo.FT.OwnCost = splitCostLeft;
                    //    InvoiceHeadInfo.FT.OwnCost = InvoiceHeadInfo.FT.OwnCost - InvoiceManualInfo.FT.OwnCost;

                    //    //InvoiceManualInfo.FT.PayCost = splitCostLeft;
                    //    InvoiceManualInfo.FT.PayCost = 0;
                    //    //InvoiceHeadInfo.FT.PayCost = InvoiceHeadInfo.FT.TotCost - InvoiceManualInfo.FT.TotCost;

                    //    //InvoiceManualInfo.FT.PubCost = splitCostLeft;
                    //    InvoiceManualInfo.FT.PubCost = 0;
                    //    //InvoiceHeadInfo.FT.PubCost = InvoiceHeadInfo.FT.PubCost - InvoiceManualInfo.FT.PubCost;
                    //    //alInvoiceManualFeeInfo.Add(InvoiceManualInfo);
                    //}
                    //else//多行利用比例计算
                    //{




                    decimal tmp = Neusoft.FrameWork.Function.NConvert.ToDecimal(Neusoft.FrameWork.Public.String.FormatNumberReturnString(InvoiceHeadInfo.FT.TotCost * (splitCost / totCost), 2));



                    InvoiceManualInfo.FT.TotCost = tmp;
                    InvoiceHeadInfo.FT.TotCost = InvoiceHeadInfo.FT.TotCost - InvoiceManualInfo.FT.TotCost;

                    InvoiceManualInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Neusoft.FrameWork.Public.String.FormatNumberReturnString(InvoiceHeadInfo.FT.OwnCost * (splitCost / totCost), 2));
                    InvoiceHeadInfo.FT.OwnCost = InvoiceHeadInfo.FT.OwnCost - InvoiceManualInfo.FT.OwnCost;

                    InvoiceManualInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Neusoft.FrameWork.Public.String.FormatNumberReturnString(InvoiceHeadInfo.FT.PayCost * (splitCost / totCost), 2));
                    InvoiceHeadInfo.FT.PayCost = InvoiceHeadInfo.FT.PayCost - InvoiceManualInfo.FT.PayCost;

                    InvoiceManualInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Neusoft.FrameWork.Public.String.FormatNumberReturnString(InvoiceHeadInfo.FT.PubCost * (splitCost / totCost), 2));
                    InvoiceHeadInfo.FT.PubCost = InvoiceHeadInfo.FT.PubCost - InvoiceManualInfo.FT.PubCost;

                    splitCostLeft = tmp + splitCostLeft;

                    if (splitCostLeft > splitCost)
                    {

                    }
                    //}

                    alInvoiceManualFeeInfo.Add(InvoiceManualInfo);
                    //}

                    //else //如果不够了
                    //{

                    //}
                }
            }
            

            


            #endregion
            //处理形成balancelist记录方便发票形成和结算表的插入


            //形成发票大类的arrlyList以便查找对应大类------

            #region 2007-8-23 liuq 发票大类改为参数，以适应多种发票格式的情况。


            alFeeState = feeCodeStat.QueryFeeCodeStatByReportCode(invoiceType);
            #endregion

            if (alFeeState == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("检索费用大类表出错!" + feeCodeStat.Err, 211);
                return -1;
            }
            //处理主结算费用为结算明细大类
            if (alInvoiceHeadFeeInfo.Count > 0)
            {
                if (this.FeeInfoTransFeeStat(alInvoiceHeadFeeInfo, this.alBalanceListHead, dtSys, balNo, invoiceNo, alFeeState) == -1) return -1;

            }
            //{31BA07D4-E8F8-4653-A879-1EB59B8E20F3}
            //处理减免发票
            if (alInvoiceDerateFeeInfo.Count > 0 && !IsPreview && IsDeratePrint)
            {
                //获取一张新的发票号码



                string invoiceDerate = "";
                //{297E97FA-EF89-40a4-9269-1D1B1D084214}
                //invoiceDerate = this.feeIntegrate.GetNewInvoiceNO(EnumInvoiceType.I);
                invoiceDerate = this.feeIntegrate.GetNewInvoiceNO("I");

                if (invoiceDerate == null || invoiceDerate.Trim() == "")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取减免发票号出错!", 211);
                    return -1;
                }

                if (this.FeeInfoTransFeeStat(alInvoiceDerateFeeInfo, this.alBalanceListDerate, dtSys, balNo, invoiceDerate, alFeeState) == -1) return -1;
            }
            //处理优惠发票明细大类
            if (alInvoiceRebateFeeInfo.Count > 0 && !IsPreview)
            {
                //获取一张新的发票号码


                string invoiceRebate = "";

                //{297E97FA-EF89-40a4-9269-1D1B1D084214}
                //invoiceRebate = this.feeIntegrate.GetNewInvoiceNO(EnumInvoiceType.I);
                invoiceRebate = this.feeIntegrate.GetNewInvoiceNO("I");
                if (invoiceRebate == null || invoiceRebate.Trim() == "")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取优惠发票号出错!", 211);
                    return -1;
                }
                if (this.FeeInfoTransFeeStat(alInvoiceRebateFeeInfo, this.alBalanceListRebate, dtSys, balNo, invoiceRebate, alFeeState) == -1) return -1;
            }
            //处理膳食发票明细大类
            if (alInvoiceFoodFeeInfo.Count > 0 && !IsPreview)
            {
                string invoiceFood = "";

                //{297E97FA-EF89-40a4-9269-1D1B1D084214}
                //invoiceFood = this.feeIntegrate.GetNewInvoiceNO(EnumInvoiceType.I);
                invoiceFood = this.feeIntegrate.GetNewInvoiceNO("I");
                if (invoiceFood == null || invoiceFood.Trim() == "") return -1;
                if (this.FeeInfoTransFeeStat(alInvoiceFoodFeeInfo, this.alBalanceListFood, dtSys, balNo, invoiceFood, alFeeState) == -1) return -1;
            }
            //处理婴儿发票明细大类
            if (alInvoiceBabyFeeInfo.Count > 0 && !IsPreview)
            {
                string invoiceBaby = "";

                //{297E97FA-EF89-40a4-9269-1D1B1D084214}
                //invoiceBaby = this.feeIntegrate.GetNewInvoiceNO(EnumInvoiceType.I);
                invoiceBaby = this.feeIntegrate.GetNewInvoiceNO("I");
                if (invoiceBaby == null || invoiceBaby.Trim() == "") return -1;
                if (this.FeeInfoTransFeeStat(alInvoiceBabyFeeInfo, this.alBalanceListBaby, dtSys, balNo, invoiceBaby, alFeeState) == -1) return -1;

            }

            if (alInvoiceManualFeeInfo.Count > 0)
            {
                string invoiceManual = "";

                invoiceManual = this.feeIntegrate.GetNewInvoiceNO("I");
                if (invoiceManual == null || invoiceManual.Trim() == "") return -1;
                if (this.FeeInfoTransFeeStat(alInvoiceManualFeeInfo, this.alBalanceListMannal, dtSys, balNo, invoiceManual, alFeeState) == -1) return -1;

            }
            return 1;

        }
        /// <summary>
        /// 结算费用转为费用大类
        /// </summary>
        /// <param name="alFeeInfo">最小费用汇总费用信息</param>
        /// <param name="alBalanceList"></param>
        /// <param name="dtSys">结算时间</param>
        /// <param name="balNo">结算序号</param>
        /// <param name="invoiceNo">费用大类汇总数组</param>
        /// <param name="alFeeState">费用大类名称数组</param>
        /// <returns></returns>
        protected virtual int FeeInfoTransFeeStat(ArrayList alFeeInfo, ArrayList alBalanceList, DateTime dtSys, int balNo, string invoiceNo, ArrayList alFeeState)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
            for (int i = 0; i < alFeeInfo.Count; i++)
            {
                //取得一条费用记录


                f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alFeeInfo[i];
                //判断是否存在和该条费用feecode对应的统计大类,存在即取出大类


                Neusoft.FrameWork.Models.NeuObject objFeeStat = new Neusoft.FrameWork.Models.NeuObject();
                objFeeStat = this.GetFeeStatByFeeCode(f.Item.MinFee.ID, alFeeState);
                if (objFeeStat == null)
                {
                    string feeName = "";
                    feeName = this.feeInpatient.GetMinFeeNameByCode(f.Item.MinFee.ID);
                    this.feeInpatient.Err = "请维护发票对照中最小费用为" + feeName + "的发票项目";
                    return -1;
                }
                //去balancelist相关的集合里去找有没有此大类费用有的话费用相加,没有数组add一条新记录
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList;
                bool BFind = false;
                for (int j = 0; j < alBalanceList.Count; j++)
                {
                    balanceList = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[j];
                    if (balanceList.FeeCodeStat.StatCate.ID == objFeeStat.ID)
                    {
                        BFind = true;
                        balanceList.BalanceBase.FT.OwnCost += f.FT.OwnCost;
                        balanceList.BalanceBase.FT.TotCost += f.FT.TotCost;

                        balanceList.BalanceBase.FT.PayCost += f.FT.PayCost;
                        balanceList.BalanceBase.FT.PubCost += f.FT.PubCost;
                    }
                }
                //没有找到所以像数组添加一条记录


                if (BFind == false)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceListAdd = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                    //实体赋值



                    balanceListAdd.FeeCodeStat.StatCate.ID = objFeeStat.ID;
                    balanceListAdd.FeeCodeStat.StatCate.Name = objFeeStat.Name;

                    balanceListAdd.FeeCodeStat.SortID = int.Parse(objFeeStat.Memo);


                    balanceListAdd.BalanceBase.FT.TotCost = f.FT.TotCost;
                    balanceListAdd.BalanceBase.FT.OwnCost = f.FT.OwnCost;
                    balanceListAdd.BalanceBase.FT.PayCost = f.FT.PayCost;
                    balanceListAdd.BalanceBase.FT.PubCost = f.FT.PubCost;
                    balanceListAdd.BalanceBase.Invoice.ID = invoiceNo;
                    balanceListAdd.BalanceBase.Patient.IsBaby = this.patientInfo.IsBaby;
                    balanceListAdd.ID = balNo.ToString();
                    balanceListAdd.BalanceBase.ID = balNo.ToString();
                    balanceListAdd.BalanceBase.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                    balanceListAdd.BalanceBase.BalanceOper.ID = this.feeInpatient.Operator.ID;
                    balanceListAdd.BalanceBase.BalanceOper.OperTime = dtSys;
                    balanceListAdd.BalanceBase.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                    if (this.BlanceType == EBlanceType.Mid)
                    {
                        balanceListAdd.BalanceBase.BalanceType.ID = Neusoft.HISFC.Models.Fee.EnumBalanceType.I;


                    }
                    if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe)
                    {
                        balanceListAdd.BalanceBase.BalanceType.ID = Neusoft.HISFC.Models.Fee.EnumBalanceType.O;

                    }
                    if (this.BlanceType == EBlanceType.Owe)
                    {
                        balanceListAdd.BalanceBase.BalanceType.ID = Neusoft.HISFC.Models.Fee.EnumBalanceType.Q;
                    }
                    alBalanceList.Add(balanceListAdd);
                }
                BFind = false;

            }
            return 1;
        }
        /// <summary>
        /// 通过最小费用获取统计大类memo存打印顺序
        /// </summary>
        /// <param name="feeCode"></param>
        /// <param name="alInvoice"></param>
        /// <returns></returns>
        protected Neusoft.FrameWork.Models.NeuObject GetFeeStatByFeeCode(string feeCode, ArrayList al)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.HISFC.Models.Fee.FeeCodeStat feeStat;

            for (int i = 0; i < al.Count; i++)
            {
                feeStat = (Neusoft.HISFC.Models.Fee.FeeCodeStat)al[i];
                if (feeStat.MinFee.ID == feeCode)
                {
                    obj.ID = feeStat.StatCate.ID;

                    obj.Name = feeStat.StatCate.Name;
                    obj.Memo = feeStat.SortID.ToString();
                    return obj;
                }
            }
            return null;
        }

        /// <summary>
        /// 更新减免信息,将其置为结算状态
        /// </summary>
        /// <param name="balNo">结算序号</param>
        /// <param name="dtSys">结算时间</param>
        /// <param name="invoiceNo">发票号</param>
        /// <returns></returns>
        protected virtual int UpdateDerateFee(int balNo, DateTime dtSys, string invoiceNo)
        {
            if (!this.IsInputDerateFee)//提取减免费用 直接全部更新
            {
                if (this.feeInpatient.UpdateDerateBalanced(this.patientInfo.ID, balNo, invoiceNo) == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("更新减免出错!" + this.feeInpatient.Err, 211);
                    return -1;
                }
            }
            else
            {
                //输入减免金额 自动处理分解成各最小费用-中山需求-----已经在wf_INvoice中处理了
            }
            return 1;
        }
        /// <summary>
        /// 更新预交金信息，将其置为结算状态
        /// </summary>
        /// <param name="balNo">结算序号</param>
        /// <param name="dtSys">结算时间</param>
        /// <param name="invoiceNo">发票号码</param>
        /// <returns>1成功 -1 失败</returns>
        protected virtual int UpdateBalancePrepay(int balNo, DateTime dtSys, string invoiceNo)
        {

            for (int i = 0; i < this.fpPrepay_Sheet1.RowCount; i++)
            {
                if ((bool)this.fpPrepay_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPrepay("选择")].Value == true)
                {
                    if (this.fpPrepay_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPrepay("支付方式")].Text != "转入预交金")
                    {
                        Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay;
                        prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)this.fpPrepay_Sheet1.Rows[i].Tag;
                        prepay.BalanceOper.ID = this.feeInpatient.Operator.ID;
                        prepay.BalanceOper.OperTime = dtSys;
                        prepay.BalanceNO = balNo;
                        prepay.Invoice.ID = invoiceNo;
                        //判断并发
                        int result = 0;
                        result = this.feeInpatient.UpdatePrepayBalanced(this.patientInfo, prepay);
                        if (result == 0)
                        {
                            this.feeInpatient.Err = "并发操作,预交金记录已经结算";
                            return -1;
                        }
                        if (result < 1) return -1;
                    }
                    else//更新转入预交金
                    {
                        if (this.feeInpatient.UpdateChangePrepayBalanced(this.patientInfo.ID, balNo) == -1) return -1;
                    }

                }
            }
            //处理转押金


            if (this.payTrace == "3")
            {
                decimal transPrepay = 0m;
                for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
                {
                    if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text == "转押金" &&
                        Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString()) > 0)
                    {
                        transPrepay += Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                    }
                }
                if (transPrepay > 0)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
                    prepay.FT.PrepayCost = transPrepay;
                    prepay.TransPrepayOper.ID = this.feeInpatient.Operator.ID;
                    prepay.TransPrepayOper.Name = this.feeInpatient.Operator.Name;
                    prepay.TransferPrepayTime = dtSys;
                    prepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
                    prepay.PrepayOper.OperTime = dtSys;
                    prepay.TransferPrepayBalanceNO = balNo;
                    prepay.TransferPrepayState = "1";
                    prepay.BalanceState = "0";
                    prepay.PrepayState = "0";
                    prepay.FinGroup.ID = this.operFinGroup.ID;
                    prepay.RecipeNO = "转押金";
                    prepay.PayType.ID = "CA";
                    //添加转押金记录


                    if (this.feeInpatient.InsertPrepay(this.patientInfo, prepay) < 1) return -1;

                }
            }
            return 1;
        }
        /// <summary>
        /// 结算时候验证费用金额是否正确
        /// </summary>
        /// <returns>1正确 -1 错误</returns>
        protected virtual int ValidCost()
        {
            decimal balanceCost = 0m;
            decimal supplyCost = 0m;
            //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            //手工分票金额
            decimal splitMannalcost = 0m;

            supplyCost = decimal.Parse(this.txtShouldPay.Text);
            balanceCost = decimal.Parse(this.txtBalanceCost.Text);
            if (balanceCost <= 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("结算金额必须大于零!", 111);
                return -1;
            }
            splitMannalcost = decimal.Parse(this.txtMannalCost.Text);
            if (splitMannalcost < 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("手工分票金额必须大于零!", 111);
                return -1;
            }
            //{8D10153C-ECC4-498c-AFF0-EFD70208BE82}
            if (splitMannalcost >= balanceCost)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("手工分票金额不能大于或等于结算金额!", 111);
                return -1;
            }

            

            decimal payTypeCost = 0m;
            string payType = "";
            decimal payAllCost = 0m;

            for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
            {
                payType = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text;
                if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value == null)
                {
                    payTypeCost = 0;
                }
                else
                {
                    payTypeCost = decimal.Parse(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                }
                if (payType.Trim() != "" && payTypeCost > 0)
                {
                    if (IsFullBankInfo)
                    {
                        if (payType.Trim() == "支票" || payType.Trim() == "汇票")
                        {
                            if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户银行")].Text.Trim() == "" ||
                                this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户帐号")].Text.Trim() == "" ||
                                this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开据单位")].Text.Trim() == "" ||
                                this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支(汇)票号/交易号")].Text.Trim() == "")
                            {
                                MessageBox.Show("支票汇票必须将完整的开户银行,帐户,开据单位,票号补充完整!");
                                return -1;
                            }
                        }
                        if (payType.Trim() == "借记卡" || payType.Trim() == "信用卡")
                        {
                            if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户银行")].Text.Trim() == "" ||
                                this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("开户帐号")].Text.Trim() == "" ||
                                this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支(汇)票号/交易号")].Text.Trim() == "")
                            {
                                MessageBox.Show("支票汇票必须将完整的开户,银行帐户,交易号补充完整!");
                                return -1;
                            }
                        }
                    }

                    payAllCost += payTypeCost;
                }

            }
            //控制不能同时使用两种相同的支付方式


            for (int i = 0; i < this.fpPayType_Sheet1.RowCount; i++)
            {
                string paytype = this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text.Trim();
                if (paytype != "")
                {
                    for (int j = i + 1; j < this.fpPayType_Sheet1.RowCount; j++)
                    {
                        if (paytype == this.fpPayType_Sheet1.Cells[j, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text.Trim())
                        {
                            MessageBox.Show("不能同时使用两种相同的支付方式");
                            return -1;
                        }
                    }
                }
                else
                {
                    if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value != null)
                    {
                        MessageBox.Show("支付方式不能为空");
                        return -1;
                    }
                }
            }
            //判断是否金额相等
            if (supplyCost != payAllCost)
            {
                switch (this.payTrace)
                {
                    case "1":
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("补交款项总额" + supplyCost.ToString() + "与分项费用之和" + payAllCost.ToString() + "不符合!", 111);
                        break;
                    case "2":
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("返还款项总额" + supplyCost.ToString() + "与分项费用之和" + payAllCost.ToString() + "不符合!", 111);
                        break;
                }
                return -1;
            }


            //判断减免金额和优惠金额


            if (this.txtDeratefee.Text.Trim() == "") this.txtDeratefee.Text = "0.00";
            if (this.txtRebateFee.Text.Trim() == "") this.txtRebateFee.Text = "0.00";
            return 1;
        }
        /// <summary>
        /// 结算前验证函数,为继承后修改特殊备用
        /// </summary>
        /// <returns>1成功-1判断有误</returns>
        protected virtual int VerifyBalance()
        {
            return 1;
        }
        /// <summary>
        /// 预览结算发票
        /// </summary>
        public override int PrintPreview(object sender, object neuObject)
        {



            //ucBalanceInvoice p = new ucBalanceInvoice();


            int balanceNO = 0;
            string invoiceNO = "";
            DateTime dtSys = DateTime.MinValue;
            dtSys = this.feeInpatient.GetDateTimeFromSysDateTime();
            //初始化Balancelist数组以便形成票面信息
            #region  2007-8-23 liuq 利用打印类返回发票大类，以适应多种发票格式的情况。


            Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy p = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy;
            p.PatientInfo = patientInfo;
            this.InitInvoice(p.InvoiceType, balanceNO, invoiceNO, dtSys, true);
            #endregion
            //无费用信息


            if (this.alBalanceListHead.Count <= 0) return 0;


            //通过BalanceList信息形成BalanceHead信息
            Neusoft.HISFC.Models.Fee.Inpatient.Balance BalanceForInvoice = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            BalanceForInvoice = this.MadeBalanceHeadByBalanceList(this.alBalanceListHead, true);
            //{B7A6B07C-165A-4a7b-B53C-A959F765D94D}
            if (p.SetValueForPreview(patientInfo, BalanceForInvoice, this.alBalanceListHead,this.alBalancePay) == -1)
            {

                this.alBalanceListHead = new ArrayList();
                return -1;
            }
            //调打印预览


            p.PrintPreview();

            return 1;


        }

        /// <summary>
        /// //判断是否有未确认掉的退费申请
        /// </summary>
        /// <param name="patientInfoID"></param>
        /// <returns></returns>
        protected int JudgeHaveQuitApply(string patientInfoID)
        {
            //判断是否有未确认掉的退费申请

            ArrayList returnApplysOfPharmacy = this.returnApplyManager.QueryReturnApplys(patientInfoID, false, true);//未确认的药品退费申请


            ArrayList returnApplysOfUndrug = this.returnApplyManager.QueryReturnApplys(patientInfoID, false, false);//未确认的非药品退费申请
            //{92BD4A97-79F4-46ea-A0D6-50AD78594DAD}
            int phaApplyCount = phaIntegrate.QueryNoConfirmQuitApply(patientInfoID);


            if (returnApplysOfPharmacy.Count > 0 || returnApplysOfUndrug.Count > 0 || phaApplyCount > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region "事件"
        /// <summary>
        /// 住院号回车事件
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            this.EnterPatientNo();
        }
        //实收焦点离开
        protected void txtPay_Leave(object sender, EventArgs e)
        {
            if (this.txtPay.Text == "") this.txtPay.Text = "0.00";

            try
            {
                if (decimal.Parse(this.txtPay.Text) == 0) return;
                if (decimal.Parse(this.txtPay.Text) < 0)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("实付金额应大于零!", 111);
                    return;
                }
                //应收
                decimal ShouldPay = 0m;
                //实收
                decimal RealPayCost = 0m;
                ShouldPay = decimal.Parse(this.txtShouldPay.Text);
                RealPayCost = decimal.Parse(this.txtPay.Text);
                //找零
                decimal charge = 0m;
                charge = RealPayCost - ShouldPay;
                this.txtCharge.Text = charge.ToString();
            }
            catch { }
        }

        //初始化

        protected void ucBalance_Load(object sender, EventArgs e)
        {

            if (!Neusoft.HISFC.Components.Common.Classes.Function.DesignMode)
            {
                this.initControl();
                this.ucQueryInpatientNo.Focus();
                this.FindForm().FormClosing += new FormClosingEventHandler(frm_FormClosing);
            }
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Exit(null, null);
        }

        /// <summary>
        /// 支付farpoint CellChange事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpPayType_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            //只响应金额的变化

            if (e.Column != this.GetColumnIndexFromNameForfpPayType("金额")) return;
            //金额判断
            decimal PayTypeCost = 0m;
            for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
            {
                if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value == null)
                {
                    continue;
                }
                else
                {
                    PayTypeCost += decimal.Parse(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                }
            }
            decimal Spay = decimal.Parse(this.txtShouldPay.Text);
            if (PayTypeCost == Spay)
            {
                return;
            }
            if (PayTypeCost < Spay)
            {
                decimal Rest = Spay - PayTypeCost;
                for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
                {
                    if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value == null)
                    {
                        this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value = Rest;
                        this.fpPayType.Focus();
                        this.fpPayType_Sheet1.SetActiveCell(i, this.GetColumnIndexFromNameForfpPayType("支付方式"));
                        break;
                    }
                }
                return;
            }
            if (PayTypeCost > Spay)
            {
                bool found = false;

                for (int i = 0; i < this.fpPayType_Sheet1.Rows.Count; i++)
                {
                    if (this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("支付方式")].Text.Trim() == "现金")
                    {
                        decimal Cash = 0m;//现金
                        decimal Rest = 0m;//其他支付方式
                        Cash = decimal.Parse(this.fpPayType_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
                        Rest = PayTypeCost - Cash;
                        if (Rest > Spay)
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.Msg("现金为负值，如果不允许，请更改！", 111);
                        }
                        //现金为其他支付方式与应收应付之间的差额


                        this.fpPayType_Sheet1.SetValue(i, this.GetColumnIndexFromNameForfpPayType("金额"), Spay - Rest);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("除现金外，其它支付方式不能大于应收应付金额", 111);
                    return;
                }
            }


            //			decimal payTypeCost = 0m;
            //			
            //			if(this.fpPayType_Sheet1.Cells[this.fpPayType_Sheet1.Rows.Count-1,this.GetColumnIndexFromNameForfpPayType("支付方式")].Text!="")
            //			{
            //				this.fpPayType_Sheet1.Rows.Add(this.fpPayType_Sheet1.Rows.Count,1);
            //			}
            //			for(int i=0;i<this.fpPayType_Sheet1.Rows.Count;i++)
            //			{
            //				if (this.fpPayType_Sheet1.Cells[i,this.GetColumnIndexFromNameForfpPayType("金额")].Value==null)
            //				{
            //					continue;
            //				}
            //				else
            //				{					
            //					payTypeCost +=decimal.Parse(this.fpPayType_Sheet1.Cells[i,this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString());
            //				}
            //			}
            //			decimal Spay = decimal.Parse(this.txtShouldPay.Text);
            //			if(this.IsPay)
            //			{//应收
            //				if(payTypeCost<decimal.Parse(this.txtShouldPay.Text))
            //					return;
            //				else
            //				{
            //					this.txtPay.Text = payTypeCost.ToString();
            //					decimal chage = 0m;
            //					chage = payTypeCost - decimal.Parse(this.txtShouldPay.Text);
            //					this.txtCharge.Text = chage.ToString();
            //				}
            //			}
            //			else
            //			{//应返
            //				this.txtCharge.Text = this.txtShouldPay.Text;
            //				if(Spay+payTypeCost!=0)
            //				{
            //					bool found=false;
            //					for(int i=0;i<this.fpPayType_Sheet1.Rows.Count;i++)
            //					{
            //						if(this.fpPayType_Sheet1.Cells[i,this.GetColumnIndexFromNameForfpPayType("支付方式")].Text.Trim()=="现金")
            //						{
            //							decimal Cash =0m;
            //							Cash=decimal.Parse(this.fpPayType_Sheet1.Cells[i,this.GetColumnIndexFromNameForfpPayType("金额")].Value.ToString()); 
            //							this.fpPayType_Sheet1.SetValue(i,this.GetColumnIndexFromNameForfpPayType("金额"),-Spay-payTypeCost+Cash);
            //							found=true;
            //							break;
            //						}
            //					}
            //					if(!found)
            //					{
            //						for(int i=0;i<this.fpPayType_Sheet1.Rows.Count;i++)
            //						{
            //							if (this.fpPayType_Sheet1.Cells[i,this.GetColumnIndexFromNameForfpPayType("金额")].Value!=null)
            //							{
            //								continue;
            //							}
            //							else
            //							{
            //								this.fpPayType_Sheet1.SetValue(i,this.GetColumnIndexFromNameForfpPayType("金额"),-Spay-payTypeCost);
            //								this.fpPayType_Sheet1.SetValue(i,this.GetColumnIndexFromNameForfpPayType("支付方式"),"现金");	
            //								break;
            //							}
            //						}
            //					}
            //				}
            //			}
            //	
        }

        /// <summary>
        /// 费用金额控件farpoint CellChange事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpCost_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            int k = e.Row;
            this.fpCost_Sheet1.Cells[k, this.GetColumnIndexFromNameForfpCost("选择")].Value = true;
            if (e.Column == this.GetColumnIndexFromNameForfpCost("结帐金额") && this.fpCost_Sheet1.Rows[e.Row].Tag != null)
            {
                if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe) return;
                if (this.patientInfo.Pact.PayKind.ID == "02") return;
                decimal UnBalanceCost = 0m;
                UnBalanceCost = decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString());
                if (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()), 2) < 0)
                {
                    this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value = this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("未结金额")].Value;
                    MessageBox.Show("可结算金额不能小于0");
                    return;
                }
                if ((Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()), 2) > Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("未结金额")].Value.ToString()), 2)))
                {
                    this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value = this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("未结金额")].Value;
                    MessageBox.Show("可结算金额不能大于花费金额");
                    return;
                }
                //重新计算费用分解拆分
                decimal BalanceCost = 0m;
                decimal RebateCost = 0m;
                Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
                for (int i = 0; i < this.fpCost_Sheet1.RowCount; i++)
                {
                    this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("选择")].Value = true;
                    if ((bool)this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("选择")].Value == true)
                    {

                        f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)this.fpCost_Sheet1.Rows[i].Tag;
                        if (this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value != this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("未结金额")].Value)
                        {

                            decimal Rate = decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()) / decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("未结金额")].Value.ToString());

                            f.FT.PubCost = Neusoft.FrameWork.Public.String.FormatNumber((f.FT.PubCost * Rate), 2);
                            f.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber((f.FT.PayCost * Rate), 2);
                            f.FT.RebateCost = Neusoft.FrameWork.Public.String.FormatNumber((f.FT.RebateCost * Rate), 2);
                            f.FT.OwnCost = decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()) - f.FT.PubCost - f.FT.PayCost - f.FT.RebateCost;
                            f.FT.TotCost = decimal.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString());
                        }
                        BalanceCost = BalanceCost + decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString());
                        RebateCost = Neusoft.FrameWork.Public.String.FormatNumber((RebateCost + f.FT.RebateCost), 2);
                    }

                }
                this.txtBalanceCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(BalanceCost, 2).ToString("###.00");
                this.txtRebateFee.Text = RebateCost.ToString("###.00");
                //显示返还情况
                this.ComputeSupplyCost();
            }
        }
        /// <summary>
        /// 费用控件单击选择费用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpCost_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //屏蔽按最小费用分类退费
            //{D53D9DE6-33AE-41ed-90B2-04EA80DA58AE}
            if (this.fpCost_Sheet1.RowCount <= 0)
            {
                return;
            }

            if ((bool)this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("选择")].Value) return;
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null) return;
            }
            if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe) return;
            if (this.patientInfo.Pact.PayKind.ID == "02") return;
            if (e.Column != this.GetColumnIndexFromNameForfpCost("选择")) return;
            if (e.Row >= this.fpCost_Sheet1.RowCount) return;
            //结算总金额


            decimal BalanceCost = 0m;

            this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("选择")].Value = !bool.Parse(this.fpCost_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpCost("选择")].Value.ToString());
            //重新计算费用
            decimal RebateCost = 0m;
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo f;
            for (int i = 0; i < this.fpCost_Sheet1.RowCount; i++)
            {

                if ((bool)this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("选择")].Value == true)
                {
                    f = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)this.fpCost_Sheet1.Rows[i].Tag;
                    if (this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value != this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("未结金额")].Value)
                    {

                        decimal Rate = decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()) / decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("未结金额")].Value.ToString());
                        f.FT.PubCost = Neusoft.FrameWork.Public.String.FormatNumber((f.FT.PubCost * Rate), 2);
                        f.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber((f.FT.PayCost * Rate), 2);
                        f.FT.RebateCost = Neusoft.FrameWork.Public.String.FormatNumber((f.FT.RebateCost * Rate), 2);
                        f.FT.OwnCost = decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("结帐金额")].Value.ToString()) - f.FT.PubCost - f.FT.PayCost - f.FT.RebateCost;
                    }
                    BalanceCost = BalanceCost + decimal.Parse(this.fpCost_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpCost("未结金额")].Value.ToString());
                    RebateCost = Neusoft.FrameWork.Public.String.FormatNumber((RebateCost + f.FT.RebateCost), 2);
                }
            }
            this.txtBalanceCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(BalanceCost, 2).ToString("###.00");
            this.txtRebateFee.Text = RebateCost.ToString("###.00");
            //显示返还情况
            this.ComputeSupplyCost();
        }
        /// <summary>
        /// 选择结算预交金事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpPrepay_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null) return;
            }
            if (this.BlanceType == EBlanceType.Out || this.BlanceType == EBlanceType.Owe) return;
            if (this.patientInfo.Pact.PayKind.ID == "02") return;
            if (e.Column != this.GetColumnIndexFromNameForfpPrepay("选择")) return;
            if (e.Row >= this.fpPrepay_Sheet1.RowCount) return;
            decimal PrepayCost = 0m;
            this.fpPrepay_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpPrepay("选择")].Value = !bool.Parse(this.fpPrepay_Sheet1.Cells[e.Row, this.GetColumnIndexFromNameForfpPrepay("选择")].Value.ToString());
            for (int i = 0; i < this.fpPrepay_Sheet1.RowCount; i++)
            {

                if ((bool)this.fpPrepay_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPrepay("选择")].Value == true)
                {
                    PrepayCost = PrepayCost + decimal.Parse(this.fpPrepay_Sheet1.Cells[i, this.GetColumnIndexFromNameForfpPrepay("预交金额")].Value.ToString());
                }
            }
            this.txtPrepayCost.Text = PrepayCost.ToString("###.00");
            //显示返还情况
            this.ComputeSupplyCost();
        }
        /// <summary>
        /// 减免金额回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtDeratefee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtShouldPay.Focus();
            }
        }

        /// <summary>
        /// 减免金额失去焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtDeratefee_Leave(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null) return;
            }
            if (this.txtDeratefee.Text == "") this.txtDeratefee.Text = "0.00";
            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDeratefee.Text) > this.TotalOwnCost)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("输入金额大于结算自费金额!", 111);
                this.txtDeratefee.Text = "0.00";
                return;
            }
            //显示返还情况
            this.ComputeSupplyCost();
        }

        public override int Exit(object sender, object neuObject)
        {

            if (this.patientInfo == null)
            {
                return base.Exit(sender, neuObject);
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return base.Exit(sender, neuObject);
            }
            #region {E7D41747-D6D7-42f5-899B-B7911592E9FF} 注释 出院登记封帐,出院召回开帐,其他不处理
            //if (this.feeInpatient.OpenAccount(this.patientInfo.ID) == -1)
            //{
            //    MessageBox.Show("开帐失败" + this.feeInpatient.Err);
            //    return -1;
            //}
            #endregion 
            return base.Exit(sender, neuObject);
        }

        /// <summary>
        /// 执行按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {

            //出院结算返回
            if (this.BlanceType == EBlanceType.Out) return;
            if (this.BlanceType == EBlanceType.Owe) return;
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return;
            }
            //医保患者返回 --------------------------------
            if (this.patientInfo.Pact.PayKind.ID == "02") return;
            dtBegin = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpBegin.Value.ToShortDateString() + " 0:00:00");
            dtEnd = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpEnd.Value.ToShortDateString() + " 23:59:59");

            if (dtEnd < dtBegin)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("结束时间小于开始时间，请重新输入！", 111);
                this.dtpEnd.Value = this.feeCodeStat.GetDateTimeFromSysDateTime();
                return;
            }
            //清空费用记录重新检索


            if (this.fpCost_Sheet1.RowCount > 0)
            {
                try
                {
                    this.dsDetail.Tables[0].Rows.Clear();
                    //					this.fpCost.fpSpread1_Sheet1.Rows.Remove(0,this.fpCost.alData.Count);
                    //					this.fpCost.fpSpread1_Sheet1.Rows.Add(0,this.fpCost.alData.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.alFeeInfo = new ArrayList();
            }

            //判断是否有未确认掉的退费申请

            if (this.JudgeHaveQuitApply(this.patientInfo.ID) == 1)
            {
                if (Neusoft.FrameWork.WinForms.Classes.Function.Msg("存在未确认的退费申请，是否继续?", 423) == DialogResult.No)
                {
                    return;
                }

            }

            //检索费用--含优惠

            if (this.QueryFeeInfo(dtBegin, dtEnd) == -1) return;
            //显示返还情况
            this.ComputeSupplyCost();

        }
        private void txtPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCharge.Focus();
            }
        }

        #endregion

        #region ISIReadCard 成员

        /// <summary>
        /// 医保读卡
        /// </summary>
        /// <param name="pactCode">传入的合同单位编码</param>
        /// <returns>成功 1 失败 -1</returns>
        public int ReadCard(string pactCode)
        {
            long returnValue = 0;

            returnValue = this.medcareInterfaceProxy.SetPactCode(pactCode);
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            returnValue = this.medcareInterfaceProxy.GetRegInfoInpatient(this.patientInfo);
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            returnValue = this.medcareInterfaceProxy.Disconnect();
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            return 1;
        }

        public int SetSIPatientInfo()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void fpPayType_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }
    }
}
