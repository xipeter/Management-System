namespace Neusoft.HISFC.WinForms.WorkStation
{
    partial class frmOrder
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tbGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAddOrder = new System.Windows.Forms.ToolStripButton();
            this.tbDelOrder = new System.Windows.Forms.ToolStripButton();
            this.tbComboOrder = new System.Windows.Forms.ToolStripButton();
            this.tbCancelOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHerbal = new System.Windows.Forms.ToolStripButton();
            this.tbCheck = new System.Windows.Forms.ToolStripButton();
            this.tbOperation = new System.Windows.Forms.ToolStripButton();
            this.tbAssayCure = new System.Windows.Forms.ToolStripButton();
            this.tbDiseaseReport = new System.Windows.Forms.ToolStripButton();
            this.tbChooseDoct = new System.Windows.Forms.ToolStripButton();
            this.tbSaveOrder = new System.Windows.Forms.ToolStripButton();
            this.tbExitOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbRetidyOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tbQueryOrder = new System.Windows.Forms.ToolStripButton();
            this.tbFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tbValid = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInValid = new System.Windows.Forms.ToolStripMenuItem();
            this.tbToday = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPrintOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tbLisResultPrint = new System.Windows.Forms.ToolStripButton();
            this.tbPacsResultPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tbChooseDrugDept = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tb1Exit = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucOrder1 = new Neusoft.HISFC.Components.Order.Controls.ucOrder();
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.tvDoctorPatientList1 = new Neusoft.HISFC.Components.Order.Controls.tvDoctorPatientList();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panelTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panelToolBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1028, 561);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucQueryInpatientNo1);
            this.panel2.Size = new System.Drawing.Size(168, 561);
            this.panel2.Controls.SetChildIndex(this.neuTextBox1, 0);
            this.panel2.Controls.SetChildIndex(this.ucQueryInpatientNo1, 0);
            this.panel2.Controls.SetChildIndex(this.panelTree, 0);
            this.panel2.Controls.SetChildIndex(this.btnClose, 0);
            this.panel2.Controls.SetChildIndex(this.btnShow, 0);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(857, 561);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Size = new System.Drawing.Size(857, 561);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // panelTree
            // 
            this.panelTree.Controls.Add(this.tvDoctorPatientList1);
            this.panelTree.Size = new System.Drawing.Size(165, 8488);
            // 
            // lblSet
            // 
            this.lblSet.Location = new System.Drawing.Point(975, 650);
            // 
            // btnShow
            // 
            this.btnShow.Size = new System.Drawing.Size(13, 8364);
            // 
            // panelToolBar
            // 
            this.panelToolBar.Controls.Add(this.toolStrip1);
            this.panelToolBar.Size = new System.Drawing.Size(1028, 57);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 643);
            this.statusBar1.Size = new System.Drawing.Size(1028, 24);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbRefresh,
            this.tbGroup,
            this.toolStripSeparator6,
            this.tbAddOrder,
            this.tbDelOrder,
            this.tbComboOrder,
            this.tbCancelOrder,
            this.toolStripSeparator1,
            this.tsbHerbal,
            this.tbCheck,
            this.tbOperation,
            this.tbAssayCure,
            this.tbDiseaseReport,
            this.tbChooseDoct,
            this.tbSaveOrder,
            this.tbExitOrder,
            this.toolStripSeparator5,
            this.tbRetidyOrder,
            this.toolStripSeparator7,
            this.tbQueryOrder,
            this.tbFilter,
            this.tbPrintOrder,
            this.toolStripSeparator8,
            this.tbLisResultPrint,
            this.tbPacsResultPrint,
            this.toolStripSeparator9,
            this.tbChooseDrugDept,
            this.toolStripSeparator4,
            this.tb1Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 52);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked_1);
            // 
            // tbRefresh
            // 
            this.tbRefresh.Image = global::Neusoft.HISFC.WinForms.WorkStation.Properties.Resources.召回;
            this.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefresh.Name = "tbRefresh";
            this.tbRefresh.Size = new System.Drawing.Size(37, 49);
            this.tbRefresh.Text = "刷新";
            this.tbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbGroup
            // 
            this.tbGroup.Image = ((System.Drawing.Image)(resources.GetObject("tbGroup.Image")));
            this.tbGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(63, 49);
            this.tbGroup.Text = "组套管理";
            this.tbGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 52);
            // 
            // tbAddOrder
            // 
            this.tbAddOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbAddOrder.Image")));
            this.tbAddOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAddOrder.Name = "tbAddOrder";
            this.tbAddOrder.Size = new System.Drawing.Size(37, 49);
            this.tbAddOrder.Text = "开立";
            this.tbAddOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbAddOrder.ToolTipText = "医嘱开立";
            // 
            // tbDelOrder
            // 
            this.tbDelOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbDelOrder.Image")));
            this.tbDelOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelOrder.Name = "tbDelOrder";
            this.tbDelOrder.Size = new System.Drawing.Size(37, 49);
            this.tbDelOrder.Text = "删除";
            this.tbDelOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbComboOrder
            // 
            this.tbComboOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbComboOrder.Image")));
            this.tbComboOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbComboOrder.Name = "tbComboOrder";
            this.tbComboOrder.Size = new System.Drawing.Size(37, 49);
            this.tbComboOrder.Text = "组合";
            this.tbComboOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbComboOrder.ToolTipText = "组合医嘱";
            // 
            // tbCancelOrder
            // 
            this.tbCancelOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbCancelOrder.Image")));
            this.tbCancelOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCancelOrder.Name = "tbCancelOrder";
            this.tbCancelOrder.Size = new System.Drawing.Size(63, 49);
            this.tbCancelOrder.Text = "取消组合";
            this.tbCancelOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbHerbal
            // 
            this.tsbHerbal.Image = ((System.Drawing.Image)(resources.GetObject("tsbHerbal.Image")));
            this.tsbHerbal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHerbal.Name = "tsbHerbal";
            this.tsbHerbal.Size = new System.Drawing.Size(37, 49);
            this.tsbHerbal.Text = "草药";
            this.tsbHerbal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbCheck
            // 
            this.tbCheck.Image = ((System.Drawing.Image)(resources.GetObject("tbCheck.Image")));
            this.tbCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCheck.Name = "tbCheck";
            this.tbCheck.Size = new System.Drawing.Size(37, 49);
            this.tbCheck.Text = "检查";
            this.tbCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbCheck.ToolTipText = "检查申请单";
            // 
            // tbOperation
            // 
            this.tbOperation.Image = ((System.Drawing.Image)(resources.GetObject("tbOperation.Image")));
            this.tbOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOperation.Name = "tbOperation";
            this.tbOperation.Size = new System.Drawing.Size(37, 49);
            this.tbOperation.Text = "手术";
            this.tbOperation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbOperation.ToolTipText = "手术申请";
            // 
            // tbAssayCure
            // 
            this.tbAssayCure.Image = ((System.Drawing.Image)(resources.GetObject("tbAssayCure.Image")));
            this.tbAssayCure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAssayCure.Name = "tbAssayCure";
            this.tbAssayCure.Size = new System.Drawing.Size(37, 49);
            this.tbAssayCure.Text = "化疗";
            this.tbAssayCure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbDiseaseReport
            // 
            this.tbDiseaseReport.Image = ((System.Drawing.Image)(resources.GetObject("tbDiseaseReport.Image")));
            this.tbDiseaseReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDiseaseReport.Name = "tbDiseaseReport";
            this.tbDiseaseReport.Size = new System.Drawing.Size(76, 49);
            this.tbDiseaseReport.Text = "传染病报告";
            this.tbDiseaseReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbChooseDoct
            // 
            this.tbChooseDoct.Image = ((System.Drawing.Image)(resources.GetObject("tbChooseDoct.Image")));
            this.tbChooseDoct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbChooseDoct.Name = "tbChooseDoct";
            this.tbChooseDoct.Size = new System.Drawing.Size(50, 49);
            this.tbChooseDoct.Text = "选医师";
            this.tbChooseDoct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tbChooseDoct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbSaveOrder
            // 
            this.tbSaveOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbSaveOrder.Image")));
            this.tbSaveOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSaveOrder.Name = "tbSaveOrder";
            this.tbSaveOrder.Size = new System.Drawing.Size(37, 49);
            this.tbSaveOrder.Text = "保存";
            this.tbSaveOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbSaveOrder.ToolTipText = "保存医嘱";
            // 
            // tbExitOrder
            // 
            this.tbExitOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbExitOrder.Image")));
            this.tbExitOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExitOrder.Name = "tbExitOrder";
            this.tbExitOrder.Size = new System.Drawing.Size(63, 49);
            this.tbExitOrder.Text = "退出医嘱";
            this.tbExitOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbExitOrder.ToolTipText = "退出医嘱开立";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // tbRetidyOrder
            // 
            this.tbRetidyOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbRetidyOrder.Image")));
            this.tbRetidyOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRetidyOrder.Name = "tbRetidyOrder";
            this.tbRetidyOrder.Size = new System.Drawing.Size(63, 49);
            this.tbRetidyOrder.Text = "重整医嘱";
            this.tbRetidyOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 52);
            // 
            // tbQueryOrder
            // 
            this.tbQueryOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbQueryOrder.Image")));
            this.tbQueryOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbQueryOrder.Name = "tbQueryOrder";
            this.tbQueryOrder.Size = new System.Drawing.Size(37, 49);
            this.tbQueryOrder.Text = "查询";
            this.tbQueryOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbFilter
            // 
            this.tbFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAll,
            this.tbValid,
            this.tbInValid,
            this.tbToday,
            this.tbNew});
            this.tbFilter.Image = ((System.Drawing.Image)(resources.GetObject("tbFilter.Image")));
            this.tbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(46, 49);
            this.tbFilter.Text = "过滤";
            this.tbFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbAll
            // 
            this.tbAll.Name = "tbAll";
            this.tbAll.Size = new System.Drawing.Size(126, 22);
            this.tbAll.Text = "全部医嘱";
            // 
            // tbValid
            // 
            this.tbValid.Name = "tbValid";
            this.tbValid.Size = new System.Drawing.Size(126, 22);
            this.tbValid.Text = "有效医嘱";
            // 
            // tbInValid
            // 
            this.tbInValid.Name = "tbInValid";
            this.tbInValid.Size = new System.Drawing.Size(126, 22);
            this.tbInValid.Text = "作废医嘱";
            // 
            // tbToday
            // 
            this.tbToday.Name = "tbToday";
            this.tbToday.Size = new System.Drawing.Size(126, 22);
            this.tbToday.Text = "当天医嘱";
            // 
            // tbNew
            // 
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(126, 22);
            this.tbNew.Text = "未审医嘱";
            this.tbNew.ToolTipText = "未审核的医嘱";
            // 
            // tbPrintOrder
            // 
            this.tbPrintOrder.Image = ((System.Drawing.Image)(resources.GetObject("tbPrintOrder.Image")));
            this.tbPrintOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrintOrder.Name = "tbPrintOrder";
            this.tbPrintOrder.Size = new System.Drawing.Size(37, 49);
            this.tbPrintOrder.Text = "打印";
            this.tbPrintOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 52);
            // 
            // tbLisResultPrint
            // 
            this.tbLisResultPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbLisResultPrint.Image")));
            this.tbLisResultPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLisResultPrint.Name = "tbLisResultPrint";
            this.tbLisResultPrint.Size = new System.Drawing.Size(84, 49);
            this.tbLisResultPrint.Text = "Lis结果查询";
            this.tbLisResultPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbPacsResultPrint
            // 
            this.tbPacsResultPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbPacsResultPrint.Image")));
            this.tbPacsResultPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPacsResultPrint.Name = "tbPacsResultPrint";
            this.tbPacsResultPrint.Size = new System.Drawing.Size(91, 49);
            this.tbPacsResultPrint.Text = "pacs结果查询";
            this.tbPacsResultPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 51);
            // 
            // tbChooseDrugDept
            // 
            this.tbChooseDrugDept.Image = ((System.Drawing.Image)(resources.GetObject("tbChooseDrugDept.Image")));
            this.tbChooseDrugDept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbChooseDrugDept.Name = "tbChooseDrugDept";
            this.tbChooseDrugDept.Size = new System.Drawing.Size(63, 49);
            this.tbChooseDrugDept.Text = "选择药房";
            this.tbChooseDrugDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 6);
            // 
            // tb1Exit
            // 
            this.tb1Exit.Image = ((System.Drawing.Image)(resources.GetObject("tb1Exit.Image")));
            this.tb1Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb1Exit.Name = "tb1Exit";
            this.tb1Exit.Size = new System.Drawing.Size(63, 49);
            this.tb1Exit.Text = "退出窗口";
            this.tb1Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucOrder1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(849, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "医嘱";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucOrder1
            // 
            this.ucOrder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(213)))));
            this.ucOrder1.Checkslipno = null;
            this.ucOrder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOrder1.IsPrint = false;
            this.ucOrder1.IsShowPopMenu = true;
            this.ucOrder1.Location = new System.Drawing.Point(0, 0);
            this.ucOrder1.Name = "ucOrder1";
            this.ucOrder1.Size = new System.Drawing.Size(849, 536);
            this.ucOrder1.TabIndex = 0;
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point(0, 0);
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size(168, 561);
            this.ucQueryInpatientNo1.TabIndex = 1;
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
            // 
            // tvDoctorPatientList1
            // 
            this.tvDoctorPatientList1.Checked = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuChecked.None;
            this.tvDoctorPatientList1.Direction = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuShowDirection.Ahead;
            this.tvDoctorPatientList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDoctorPatientList1.Font = new System.Drawing.Font("Arial", 9F);
            this.tvDoctorPatientList1.HideSelection = false;
            this.tvDoctorPatientList1.ImageIndex = 0;
            this.tvDoctorPatientList1.IsShowContextMenu = true;
            this.tvDoctorPatientList1.IsShowCount = true;
            this.tvDoctorPatientList1.IsShowNewPatient = true;
            this.tvDoctorPatientList1.IsShowPatientNo = true;
            this.tvDoctorPatientList1.Location = new System.Drawing.Point(0, 0);
            this.tvDoctorPatientList1.Name = "tvDoctorPatientList1";
            this.tvDoctorPatientList1.SelectedImageIndex = 0;
            this.tvDoctorPatientList1.ShowType = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuShowType.Bed;
            this.tvDoctorPatientList1.Size = new System.Drawing.Size(165, 8488);
            this.tvDoctorPatientList1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDoctorPatientList1.TabIndex = 0;
            this.tvDoctorPatientList1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDoctorPatientList1_AfterSelect);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 667);
            this.IsShowToolBar = false;
            this.IsUseDefaultBar = false;
            this.Name = "frmOrder";
            this.Text = "医嘱管理主窗口";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOrder_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panelTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panelToolBar.ResumeLayout(false);
            this.panelToolBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.HISFC.Components.Order.Controls.tvDoctorPatientList tvDoctorPatientList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbComboOrder;
        private System.Windows.Forms.ToolStripButton tbCancelOrder;
        private System.Windows.Forms.ToolStripButton tbExitOrder;
        private System.Windows.Forms.ToolStripButton tb1Exit;
        protected System.Windows.Forms.ToolStripButton tbAddOrder;
        protected System.Windows.Forms.ToolStripButton tbDelOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tbFilter;
        private System.Windows.Forms.ToolStripMenuItem tbAll;
        private System.Windows.Forms.ToolStripMenuItem tbValid;
        private System.Windows.Forms.ToolStripMenuItem tbInValid;
        private System.Windows.Forms.ToolStripMenuItem tbToday;
        private System.Windows.Forms.ToolStripButton tbSaveOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbQueryOrder;
        private System.Windows.Forms.ToolStripButton tbPrintOrder;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.HISFC.Components.Order.Controls.ucOrder ucOrder1;
        private System.Windows.Forms.ToolStripMenuItem tbNew;
        private System.Windows.Forms.ToolStripButton tbCheck;
        private System.Windows.Forms.ToolStripButton tbOperation;
        private System.Windows.Forms.ToolStripButton tbGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbHerbal;
        private System.Windows.Forms.ToolStripButton tbRefresh;
        private System.Windows.Forms.ToolStripButton tbChooseDoct;
        private System.Windows.Forms.ToolStripButton tbRetidyOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tbAssayCure;
        private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
        private System.Windows.Forms.ToolStripButton tbDiseaseReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tbLisResultPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tbPacsResultPrint;
        private System.Windows.Forms.ToolStripButton tbChooseDrugDept;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;


    }
}