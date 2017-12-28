using System;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Forms {
	public class frmBaseExplorer : Neusoft.FrameWork.WinForms.Forms.BaseStatusBar {
		private System.ComponentModel.IContainer components = null;
		protected System.Windows.Forms.Panel panel1;
		protected System.Windows.Forms.ImageList ilMenu;
		protected System.Windows.Forms.Splitter splitter1;
		protected System.Windows.Forms.Panel panelRight;
		protected System.Windows.Forms.Panel panelLeft;
		public Neusoft.FrameWork.WinForms.Controls.ucChooseList ucChooseList1;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.ToolBar toolBar;

		/// <summary>
		/// 基本的IE显示窗口
		/// </summary>
		public frmBaseExplorer() {
			// 该调用是 Windows 窗体设计器所必需的。
			InitializeComponent();
			this.ProgressRun(true);

			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}


		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		/// 初始化
		/// </summary>
		protected void Init() {
			
		}


		#region 设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.ucChooseList1 = new Neusoft.FrameWork.WinForms.Controls.ucChooseList();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.ilMenu = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 421);
            this.statusBar1.Size = new System.Drawing.Size(760, 16);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelRight);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panelLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 379);
            this.panel1.TabIndex = 5;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.groupBox1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(227, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(533, 379);
            this.panelRight.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(224, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 379);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.ucChooseList1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(224, 379);
            this.panelLeft.TabIndex = 5;
            // 
            // ucChooseList1
            // 
            this.ucChooseList1.Caption = "选择药品";
            this.ucChooseList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChooseList1.IsShowCloseButton = true;
            this.ucChooseList1.IsShowTreeView = true;
            this.ucChooseList1.Location = new System.Drawing.Point(0, 0);
            this.ucChooseList1.Name = "ucChooseList1";
            this.ucChooseList1.Size = new System.Drawing.Size(224, 379);
            this.ucChooseList1.TabIndex = 0;
            // 
            // toolBar
            // 
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.ilMenu;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(760, 42);
            this.toolBar.TabIndex = 6;
            // 
            // ilMenu
            // 
            this.ilMenu.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilMenu.ImageSize = new System.Drawing.Size(32, 32);
            this.ilMenu.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmBaseExplorer
            // 
            this.ClientSize = new System.Drawing.Size(760, 437);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar);
            this.KeyPreview = true;
            this.Name = "frmBaseExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaseExplorer_Load);
            this.Controls.SetChildIndex(this.toolBar, 0);
            this.Controls.SetChildIndex(this.statusBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBaseExplorer_Load(object sender, System.EventArgs e) {
			//窗口初始化
			this.Init();
		}
	}
}

