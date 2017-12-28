namespace Neusoft.HISFC.Components.Material
{
    partial class ucMatInOutBase
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMatInOutBase));
            this.neuToolBar1 = new Neusoft.FrameWork.WinForms.Controls.NeuToolBar();
            this.panelItemSelect = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panelItemManager = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cmbTargetDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbTargetPerson = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbPrivType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.lnbPrivType = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.lnbTargetPerson = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.lnbTarget = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.txtFilter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTotCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.rbnPRe = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rbnAfter = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.tbShow = new System.Windows.Forms.ToolBarButton();
            this.tbStockList = new System.Windows.Forms.ToolBarButton();
            this.tbApplyList = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbInList = new System.Windows.Forms.ToolBarButton();
            this.tbOutList = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbDel = new System.Windows.Forms.ToolBarButton();
            this.tbSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.tbCancel = new System.Windows.Forms.ToolBarButton();
            this.tbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuToolBar1
            // 
            this.neuToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbShow,
            this.tbStockList,
            this.tbApplyList,
            this.toolBarButton1,
            this.tbInList,
            this.tbOutList,
            this.toolBarButton2,
            this.tbDel,
            this.tbSave,
            this.toolBarButton3,
            this.tbCancel,
            this.tbExit});
            this.neuToolBar1.DropDownArrows = true;
            this.neuToolBar1.Location = new System.Drawing.Point(0, 0);
            this.neuToolBar1.Name = "neuToolBar1";
            this.neuToolBar1.ShowToolTips = true;
            this.neuToolBar1.Size = new System.Drawing.Size(822, 41);
            this.neuToolBar1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuToolBar1.TabIndex = 0;
            // 
            // panelItemSelect
            // 
            this.panelItemSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelItemSelect.Location = new System.Drawing.Point(0, 41);
            this.panelItemSelect.Name = "panelItemSelect";
            this.panelItemSelect.Size = new System.Drawing.Size(187, 380);
            this.panelItemSelect.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelItemSelect.TabIndex = 1;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(187, 41);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 380);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 2;
            this.neuSplitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.neuSpread1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panelItemManager);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(190, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 380);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbTargetDept);
            this.panel3.Controls.Add(this.cmbTargetPerson);
            this.panel3.Controls.Add(this.cmbPrivType);
            this.panel3.Controls.Add(this.lnbPrivType);
            this.panel3.Controls.Add(this.lnbTargetPerson);
            this.panel3.Controls.Add(this.lnbTarget);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(632, 39);
            this.panel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel3.TabIndex = 0;
            // 
            // panelItemManager
            // 
            this.panelItemManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemManager.Location = new System.Drawing.Point(0, 39);
            this.panelItemManager.Name = "panelItemManager";
            this.panelItemManager.Size = new System.Drawing.Size(632, 100);
            this.panelItemManager.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelItemManager.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbnAfter);
            this.panel4.Controls.Add(this.rbnPRe);
            this.panel4.Controls.Add(this.txtFilter);
            this.panel4.Controls.Add(this.neuLabel1);
            this.panel4.Controls.Add(this.lbTotCost);
            this.panel4.Controls.Add(this.lbInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 139);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(632, 34);
            this.panel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel4.TabIndex = 2;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 173);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(632, 207);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 3;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cmbTargetDept
            // 
            this.cmbTargetDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTargetDept.FormattingEnabled = true;
            this.cmbTargetDept.IsFlat = true;
            this.cmbTargetDept.IsLike = true;
            this.cmbTargetDept.Location = new System.Drawing.Point(249, 9);
            this.cmbTargetDept.Name = "cmbTargetDept";
            this.cmbTargetDept.PopForm = null;
            this.cmbTargetDept.ShowCustomerList = false;
            this.cmbTargetDept.ShowID = false;
            this.cmbTargetDept.Size = new System.Drawing.Size(218, 20);
            this.cmbTargetDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbTargetDept.TabIndex = 16;
            this.cmbTargetDept.Tag = "";
            this.cmbTargetDept.ToolBarUse = false;
            this.cmbTargetDept.Visible = false;
            // 
            // cmbTargetPerson
            // 
            this.cmbTargetPerson.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTargetPerson.FormattingEnabled = true;
            this.cmbTargetPerson.IsFlat = true;
            this.cmbTargetPerson.IsLike = true;
            this.cmbTargetPerson.Location = new System.Drawing.Point(527, 9);
            this.cmbTargetPerson.Name = "cmbTargetPerson";
            this.cmbTargetPerson.PopForm = null;
            this.cmbTargetPerson.ShowCustomerList = false;
            this.cmbTargetPerson.ShowID = false;
            this.cmbTargetPerson.Size = new System.Drawing.Size(91, 20);
            this.cmbTargetPerson.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbTargetPerson.TabIndex = 17;
            this.cmbTargetPerson.Tag = "";
            this.cmbTargetPerson.ToolBarUse = false;
            this.cmbTargetPerson.Visible = false;
            // 
            // cmbPrivType
            // 
            this.cmbPrivType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPrivType.FormattingEnabled = true;
            this.cmbPrivType.IsFlat = true;
            this.cmbPrivType.IsLike = true;
            this.cmbPrivType.Location = new System.Drawing.Point(71, 9);
            this.cmbPrivType.Name = "cmbPrivType";
            this.cmbPrivType.PopForm = null;
            this.cmbPrivType.ShowCustomerList = false;
            this.cmbPrivType.ShowID = false;
            this.cmbPrivType.Size = new System.Drawing.Size(122, 20);
            this.cmbPrivType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbPrivType.TabIndex = 18;
            this.cmbPrivType.Tag = "";
            this.cmbPrivType.ToolBarUse = false;
            // 
            // lnbPrivType
            // 
            this.lnbPrivType.AutoSize = true;
            this.lnbPrivType.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbPrivType.Location = new System.Drawing.Point(14, 13);
            this.lnbPrivType.Name = "lnbPrivType";
            this.lnbPrivType.Size = new System.Drawing.Size(53, 12);
            this.lnbPrivType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lnbPrivType.TabIndex = 15;
            this.lnbPrivType.TabStop = true;
            this.lnbPrivType.Text = "操作类别";
            // 
            // lnbTargetPerson
            // 
            this.lnbTargetPerson.AutoSize = true;
            this.lnbTargetPerson.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbTargetPerson.Location = new System.Drawing.Point(471, 13);
            this.lnbTargetPerson.Name = "lnbTargetPerson";
            this.lnbTargetPerson.Size = new System.Drawing.Size(53, 12);
            this.lnbTargetPerson.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lnbTargetPerson.TabIndex = 14;
            this.lnbTargetPerson.TabStop = true;
            this.lnbTargetPerson.Text = "领 送 人";
            this.lnbTargetPerson.Visible = false;
            // 
            // lnbTarget
            // 
            this.lnbTarget.AutoSize = true;
            this.lnbTarget.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnbTarget.Location = new System.Drawing.Point(194, 13);
            this.lnbTarget.Name = "lnbTarget";
            this.lnbTarget.Size = new System.Drawing.Size(53, 12);
            this.lnbTarget.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lnbTarget.TabIndex = 13;
            this.lnbTarget.TabStop = true;
            this.lnbTarget.Text = "目标单位";
            this.lnbTarget.Visible = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(71, 7);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(90, 21);
            this.txtFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFilter.TabIndex = 7;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(14, 11);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 6;
            this.neuLabel1.Text = "过    滤";
            // 
            // lbTotCost
            // 
            this.lbTotCost.AutoSize = true;
            this.lbTotCost.ForeColor = System.Drawing.Color.Blue;
            this.lbTotCost.Location = new System.Drawing.Point(389, 11);
            this.lbTotCost.Name = "lbTotCost";
            this.lbTotCost.Size = new System.Drawing.Size(41, 12);
            this.lbTotCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTotCost.TabIndex = 4;
            this.lbTotCost.Text = "总金额";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoEllipsis = true;
            this.lbInfo.AutoSize = true;
            this.lbInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbInfo.Location = new System.Drawing.Point(537, 11);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(53, 12);
            this.lbInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbInfo.TabIndex = 5;
            this.lbInfo.Text = "信息说明";
            // 
            // rbnPRe
            // 
            this.rbnPRe.AutoSize = true;
            this.rbnPRe.ForeColor = System.Drawing.Color.Blue;
            this.rbnPRe.Location = new System.Drawing.Point(196, 10);
            this.rbnPRe.Name = "rbnPRe";
            this.rbnPRe.Size = new System.Drawing.Size(53, 16);
            this.rbnPRe.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbnPRe.TabIndex = 8;
            this.rbnPRe.TabStop = true;
            this.rbnPRe.Text = "税前 ";
            this.rbnPRe.UseVisualStyleBackColor = true;
            // 
            // rbnAfter
            // 
            this.rbnAfter.AutoSize = true;
            this.rbnAfter.ForeColor = System.Drawing.Color.Blue;
            this.rbnAfter.Location = new System.Drawing.Point(255, 10);
            this.rbnAfter.Name = "rbnAfter";
            this.rbnAfter.Size = new System.Drawing.Size(47, 16);
            this.rbnAfter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbnAfter.TabIndex = 9;
            this.rbnAfter.TabStop = true;
            this.rbnAfter.Text = "税后";
            this.rbnAfter.UseVisualStyleBackColor = true;
            // 
            // tbShow
            // 
            this.tbShow.Name = "tbShow";
            this.tbShow.Text = "显示栏";
            // 
            // tbStockList
            // 
            this.tbStockList.Name = "tbStockList";
            this.tbStockList.Text = "采购单";
            this.tbStockList.ToolTipText = "采购单";
            // 
            // tbApplyList
            // 
            this.tbApplyList.Name = "tbApplyList";
            this.tbApplyList.Text = "申请单";
            this.tbApplyList.ToolTipText = "申请单";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbInList
            // 
            this.tbInList.Name = "tbInList";
            this.tbInList.Text = "入库单";
            this.tbInList.ToolTipText = "入库单";
            // 
            // tbOutList
            // 
            this.tbOutList.Name = "tbOutList";
            this.tbOutList.Text = "出库单";
            this.tbOutList.ToolTipText = "出库单";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbDel
            // 
            this.tbDel.Name = "tbDel";
            this.tbDel.Text = "删除";
            this.tbDel.ToolTipText = "删除";
            // 
            // tbSave
            // 
            this.tbSave.Name = "tbSave";
            this.tbSave.Text = "保存";
            this.tbSave.ToolTipText = "保存";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbCancel
            // 
            this.tbCancel.Name = "tbCancel";
            this.tbCancel.Text = "作废申请";
            this.tbCancel.ToolTipText = "作废申请";
            // 
            // tbExit
            // 
            this.tbExit.Name = "tbExit";
            this.tbExit.Text = "退出";
            this.tbExit.ToolTipText = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "增加.ico");
            this.imageList1.Images.SetKeyName(1, "保存.ico");
            this.imageList1.Images.SetKeyName(2, "查询.ico");
            this.imageList1.Images.SetKeyName(3, "打印.ico");
            this.imageList1.Images.SetKeyName(4, "导出.GIF");
            this.imageList1.Images.SetKeyName(5, "导入.ico");
            this.imageList1.Images.SetKeyName(6, "浏览.GIF");
            this.imageList1.Images.SetKeyName(7, "删除.ico");
            this.imageList1.Images.SetKeyName(8, "退出.ico");
            this.imageList1.Images.SetKeyName(9, "预览.ico");
            // 
            // ucMatInOutBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.panelItemSelect);
            this.Controls.Add(this.neuToolBar1);
            this.Name = "ucMatInOutBase";
            this.Size = new System.Drawing.Size(822, 421);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuToolBar neuToolBar1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelItemSelect;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelItemManager;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTargetDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTargetPerson;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbPrivType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel lnbPrivType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel lnbTargetPerson;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel lnbTarget;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbnPRe;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFilter;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTotCost;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lbInfo;
        private System.Windows.Forms.ToolBarButton tbShow;
        private System.Windows.Forms.ToolBarButton tbStockList;
        private System.Windows.Forms.ToolBarButton tbApplyList;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton tbInList;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbnAfter;
        private System.Windows.Forms.ToolBarButton tbOutList;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton tbDel;
        private System.Windows.Forms.ToolBarButton tbSave;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton tbCancel;
        private System.Windows.Forms.ToolBarButton tbExit;
        private System.Windows.Forms.ImageList imageList1;
    }
}
