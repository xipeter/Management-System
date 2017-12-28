/*
 *$Header: /HIS4.0/HIS/src/Pharmacy/ucChooseList.cs 5     05-02-25 12:24 Cui $
 *$Author: Cui $  
 *$Date: 05-02-25 12:24 $  
 *$Revision: 5 $
 *$Log: /HIS4.0/HIS/src/Pharmacy/ucChooseList.cs $
 * 
 * 5     05-02-25 12:24 Cui
 * 
 * 4     05-01-26 11:07 Cui
 * 
 * 3     05-01-25 9:48 Cui
 * 
 * 2     05-01-24 10:59 Cui
 * 
 * 1     05-01-21 10:40 Cui
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Pharmacy;

namespace Neusoft.FrameWork.WinForms.Controls {
	/// <summary>
	/// ucChooseList 的摘要说明。
	/// </summary>
	public class ucChooseList: System.Windows.Forms.UserControl {
		protected System.ComponentModel.IContainer components;
		public Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
		public Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
		public Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCaption;
		public  FarPoint.Win.Spread.FpSpread fpChooseList;
		public  FarPoint.Win.Spread.SheetView fpChooseList_Sheet1;
		public  Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtQueryCode;

		public   Neusoft.FrameWork.WinForms.Controls.NeuPanel panelData;
		public Neusoft.FrameWork.WinForms.Controls.NeuButton btn1;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton btnClose;
		public   System.Windows.Forms.TreeView tvList;

		//树型列表
		public TreeView TvList {
			get {return this.tvList;}
			set {this.tvList = value as TreeView;}
		}


		//控件标题
		public string Caption {
			get {return this.lblCaption.Text;}
			set {this.lblCaption.Text = value;}
		}


		//是否显示TreeView，true显示TreeView，false显示Farpoit
		public bool IsShowTreeView {
			get {return this.tvList.Visible;}
			set {
				if(!this.tvList.Visible.Equals(value)) {
					this.tvList.Visible = value;
					this.panelData.Visible = !value;
				}
			}
		}


		//是否显示关闭按钮
		public bool IsShowCloseButton {
			get {return this.btnClose.Visible;}
			set {this.btnClose.Visible = value;	}
		}


		/// <summary>
		/// 构造函数
		/// </summary>
		public ucChooseList() {
			this.components = new System.ComponentModel.Container();
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

		}


		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>

		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}



		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		protected void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucChooseList));
			this.fpChooseList = new FarPoint.Win.Spread.FpSpread();
			this.fpChooseList_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
			this.lblCaption = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.txtQueryCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
			this.panelData = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
			this.tvList = new System.Windows.Forms.TreeView();
			this.btn1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			this.btnClose = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			((System.ComponentModel.ISupportInitialize)(this.fpChooseList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpChooseList_Sheet1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panelData.SuspendLayout();
			this.SuspendLayout();
			// 
			// fpChooseList
			// 
			this.fpChooseList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.fpChooseList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			this.fpChooseList.Location = new System.Drawing.Point(0, 24);
			this.fpChooseList.Name = "fpChooseList";
			this.fpChooseList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					  this.fpChooseList_Sheet1});
			this.fpChooseList.Size = new System.Drawing.Size(351, 317);
			this.fpChooseList.TabIndex = 1;
			this.fpChooseList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			// 
			// fpChooseList_Sheet1
			// 
			this.fpChooseList_Sheet1.Reset();
			this.fpChooseList_Sheet1.ColumnCount = 13;
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "药品编码";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "商品名称";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "规格";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "零售价";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "包装单位";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "包装数量";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "拼音码";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "五笔码";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "自定义码";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 9).Text = "通用名";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 10).Text = "通用名拼音码";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 11).Text = "通用名五笔码";
			this.fpChooseList_Sheet1.ColumnHeader.Cells.Get(0, 12).Text = "通用名自定义码";
			this.fpChooseList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.SystemColors.Control;
			this.fpChooseList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
			this.fpChooseList_Sheet1.ColumnHeader.Rows.Get(0).Height = 23F;
			this.fpChooseList_Sheet1.Columns.Get(0).Label = "药品编码";
			this.fpChooseList_Sheet1.Columns.Get(0).Visible = false;
			this.fpChooseList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpChooseList_Sheet1.Columns.Get(1).Label = "商品名称";
			this.fpChooseList_Sheet1.Columns.Get(1).Width = 136F;
			this.fpChooseList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpChooseList_Sheet1.Columns.Get(2).Label = "规格";
			this.fpChooseList_Sheet1.Columns.Get(2).Width = 76F;
			this.fpChooseList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpChooseList_Sheet1.Columns.Get(3).Label = "零售价";
			this.fpChooseList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpChooseList_Sheet1.Columns.Get(4).Label = "包装单位";
			this.fpChooseList_Sheet1.Columns.Get(4).Width = 57F;
			this.fpChooseList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpChooseList_Sheet1.Columns.Get(5).Label = "包装数量";
			this.fpChooseList_Sheet1.Columns.Get(5).Width = 58F;
			this.fpChooseList_Sheet1.Columns.Get(6).Label = "拼音码";
			this.fpChooseList_Sheet1.Columns.Get(6).Visible = false;
			this.fpChooseList_Sheet1.Columns.Get(7).Label = "五笔码";
			this.fpChooseList_Sheet1.Columns.Get(7).Visible = false;
			this.fpChooseList_Sheet1.Columns.Get(8).Label = "自定义码";
			this.fpChooseList_Sheet1.Columns.Get(8).Visible = false;
			this.fpChooseList_Sheet1.Columns.Get(9).Label = "通用名";
			this.fpChooseList_Sheet1.Columns.Get(9).Visible = false;
			this.fpChooseList_Sheet1.Columns.Get(10).Label = "通用名拼音码";
			this.fpChooseList_Sheet1.Columns.Get(10).Visible = false;
			this.fpChooseList_Sheet1.Columns.Get(11).Label = "通用名五笔码";
			this.fpChooseList_Sheet1.Columns.Get(11).Visible = false;
			this.fpChooseList_Sheet1.Columns.Get(12).Label = "通用名自定义码";
			this.fpChooseList_Sheet1.Columns.Get(12).Visible = false;
			this.fpChooseList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
			this.fpChooseList_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpChooseList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
			this.fpChooseList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpChooseList_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpChooseList_Sheet1.RowHeader.Visible = false;
			this.fpChooseList_Sheet1.Rows.Default.Height = 21F;
			this.fpChooseList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpChooseList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpChooseList_Sheet1.SheetName = "Sheet1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "查询码:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btn1);
			this.groupBox1.Controls.Add(this.btnClose);
			this.groupBox1.Controls.Add(this.lblCaption);
			this.groupBox1.Location = new System.Drawing.Point(0, -6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(351, 26);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// lblCaption
			// 
			this.lblCaption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCaption.Location = new System.Drawing.Point(4, 9);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(152, 13);
			this.lblCaption.TabIndex = 0;
			this.lblCaption.Text = "选择项目";
			// 
			// txtQueryCode
			// 
			this.txtQueryCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtQueryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQueryCode.Location = new System.Drawing.Point(52, 2);
			this.txtQueryCode.Name = "txtQueryCode";
			this.txtQueryCode.Size = new System.Drawing.Size(299, 21);
			this.txtQueryCode.TabIndex = 0;
			this.txtQueryCode.Text = "";
			this.txtQueryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQueryCode_KeyDown);
			// 
			// panelData
			// 
			this.panelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panelData.Controls.Add(this.label1);
			this.panelData.Controls.Add(this.txtQueryCode);
			this.panelData.Controls.Add(this.fpChooseList);
			this.panelData.Location = new System.Drawing.Point(0, 21);
			this.panelData.Name = "panelData";
			this.panelData.Size = new System.Drawing.Size(353, 342);
			this.panelData.TabIndex = 7;
			// 
			// tvList
			// 
			this.tvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tvList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tvList.HideSelection = false;
			this.tvList.ImageIndex = -1;
			this.tvList.Location = new System.Drawing.Point(0, 21);
			this.tvList.Name = "tvList";
			this.tvList.SelectedImageIndex = -1;
			this.tvList.Size = new System.Drawing.Size(351, 342);
			this.tvList.TabIndex = 8;
			this.tvList.Visible = false;
			// 
			// btn1
			// 
			this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn1.Image = ((System.Drawing.Image)(resources.GetObject("btn1.Image")));
			this.btn1.Location = new System.Drawing.Point(320, 8);
			this.btn1.Name = "btn1";
			this.btn1.Size = new System.Drawing.Size(13, 15);
			this.btn1.TabIndex = 4;
			this.btn1.TabStop = false;
			this.btn1.Visible = false;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
			this.btnClose.Location = new System.Drawing.Point(335, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(13, 15);
			this.btnClose.TabIndex = 3;
			this.btnClose.TabStop = false;
			this.btnClose.Visible = false;
			// 
			// ucChooseList
			// 
			this.Controls.Add(this.panelData);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tvList);
			this.Name = "ucChooseList";
			this.Size = new System.Drawing.Size(352, 363);
			this.Load += new System.EventHandler(this.ucChooseList_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpChooseList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpChooseList_Sheet1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.panelData.ResumeLayout(false);
			this.ResumeLayout(false);

            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(fpChooseList);
		}
		#endregion

		protected void ucChooseList_Load(object sender, System.EventArgs e) {
			this.btnClose.Click +=new EventHandler(btnClose_Click);

		}


		protected void txtQueryCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			if(e.KeyCode == Keys.Down) {
				this.fpChooseList_Sheet1.ActiveRowIndex++;
				this.fpChooseList_Sheet1.AddSelection(this.fpChooseList_Sheet1.ActiveRowIndex,0,1,0);
				return;
			}

			if(e.KeyCode == Keys.Up) {
				this.fpChooseList_Sheet1.ActiveRowIndex--;
				this.fpChooseList_Sheet1.AddSelection(this.fpChooseList_Sheet1.ActiveRowIndex,0,1,0);
				return;
			}
		}


		protected void btn1_Click(object sender, System.EventArgs e) {
			Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty( this.fpChooseList_Sheet1, "d:\\wolf.xml");
		}


		protected void btnClose_Click(object sender, EventArgs e) {
			this.Parent.Visible = false;
		}
	}
}
