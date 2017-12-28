using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace Neusoft.WinForms.Report.Pharmacy
{
	/// <summary>
	/// ucPhaInput 的摘要说明。
	/// </summary>
	public class ucPhaInputBill : System.Windows.Forms.UserControl,Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Label label1;
        private Label label2;
        private HISFC.BizLogic.Manager.PowerLevelManager levelManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();
		public ucPhaInputBill()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

			//this.sheetView1.Rows.Default.Height = 50F;

		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
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
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb34 = new System.Windows.Forms.Label();
            this.lb33 = new System.Windows.Forms.Label();
            this.lb32 = new System.Windows.Forms.Label();
            this.lb31 = new System.Windows.Forms.Label();
            this.lb13 = new System.Windows.Forms.Label();
            this.lb11 = new System.Windows.Forms.Label();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.sheetView1 = new FarPoint.Win.Spread.SheetView();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lb35 = new System.Windows.Forms.Label();
            this.lb21 = new System.Windows.Forms.Label();
            this.lb36 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lb34);
            this.panel3.Controls.Add(this.lb33);
            this.panel3.Controls.Add(this.lb32);
            this.panel3.Controls.Add(this.lb31);
            this.panel3.Controls.Add(this.lb13);
            this.panel3.Controls.Add(this.lb11);
            this.panel3.Controls.Add(this.fpSpread1);
            this.panel3.Controls.Add(this.lbTitle);
            this.panel3.Controls.Add(this.lb35);
            this.panel3.Controls.Add(this.lb21);
            this.panel3.Controls.Add(this.lb36);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(879, 416);
            this.panel3.TabIndex = 1;
            // 
            // lb34
            // 
            this.lb34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb34.Location = new System.Drawing.Point(330, 77);
            this.lb34.Name = "lb34";
            this.lb34.Size = new System.Drawing.Size(146, 16);
            this.lb34.TabIndex = 59;
            this.lb34.Text = "药品会计：";
            // 
            // lb33
            // 
            this.lb33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb33.Location = new System.Drawing.Point(176, 77);
            this.lb33.Name = "lb33";
            this.lb33.Size = new System.Drawing.Size(123, 16);
            this.lb33.TabIndex = 58;
            this.lb33.Text = "采购员：";
            // 
            // lb32
            // 
            this.lb32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb32.Location = new System.Drawing.Point(3, 77);
            this.lb32.Name = "lb32";
            this.lb32.Size = new System.Drawing.Size(107, 16);
            this.lb32.TabIndex = 57;
            this.lb32.Text = "药库管理员：";
            // 
            // lb31
            // 
            this.lb31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb31.Location = new System.Drawing.Point(425, 23);
            this.lb31.Name = "lb31";
            this.lb31.Size = new System.Drawing.Size(62, 16);
            this.lb31.TabIndex = 56;
            this.lb31.Text = "制单人：";
            this.lb31.Visible = false;
            // 
            // lb13
            // 
            this.lb13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb13.Location = new System.Drawing.Point(330, 56);
            this.lb13.Name = "lb13";
            this.lb13.Size = new System.Drawing.Size(126, 16);
            this.lb13.TabIndex = 55;
            this.lb13.Text = "单号";
            // 
            // lb11
            // 
            this.lb11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb11.Location = new System.Drawing.Point(477, 77);
            this.lb11.Name = "lb11";
            this.lb11.Size = new System.Drawing.Size(299, 16);
            this.lb11.TabIndex = 54;
            this.lb11.Text = "供货单位";
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.Transparent;
            this.fpSpread1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpSpread1.Location = new System.Drawing.Point(7, 96);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.sheetView1});
            this.fpSpread1.Size = new System.Drawing.Size(785, 151);
            this.fpSpread1.TabIndex = 49;
            this.fpSpread1.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            // 
            // sheetView1
            // 
            this.sheetView1.Reset();
            this.sheetView1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.sheetView1.ColumnCount = 14;
            this.sheetView1.RowCount = 14;
            this.sheetView1.RowHeader.ColumnCount = 0;
            this.sheetView1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.SystemColors.WindowText, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, false, true, true, true);
            this.sheetView1.Cells.Get(0, 2).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.sheetView1.Cells.Get(13, 13).Value = "    ";
            this.sheetView1.ColumnHeader.Cells.Get(0, 0).Value = "清单号";
            this.sheetView1.ColumnHeader.Cells.Get(0, 1).Value = "编码";
            this.sheetView1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetView1.ColumnHeader.Cells.Get(0, 2).Value = "药品名称";
            this.sheetView1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetView1.ColumnHeader.Cells.Get(0, 3).Value = "规格";
            this.sheetView1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetView1.ColumnHeader.Cells.Get(0, 4).Value = "数量";
            this.sheetView1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetView1.ColumnHeader.Cells.Get(0, 5).Value = "单位";
            this.sheetView1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetView1.ColumnHeader.Cells.Get(0, 6).Value = "零售价";
            this.sheetView1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetView1.ColumnHeader.Cells.Get(0, 7).Value = "进价";
            this.sheetView1.ColumnHeader.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetView1.ColumnHeader.Cells.Get(0, 8).Value = "零售总额";
            this.sheetView1.ColumnHeader.Cells.Get(0, 9).Value = "进价总额";
            this.sheetView1.ColumnHeader.Cells.Get(0, 10).Value = "差额";
            this.sheetView1.ColumnHeader.Cells.Get(0, 11).Value = "产地";
            this.sheetView1.ColumnHeader.Cells.Get(0, 12).Value = "批号";
            this.sheetView1.ColumnHeader.Cells.Get(0, 13).Value = "备注";
            this.sheetView1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.sheetView1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.sheetView1.ColumnHeader.DefaultStyle.Locked = false;
            this.sheetView1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.sheetView1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.sheetView1.Columns.Get(0).Label = "清单号";
            this.sheetView1.Columns.Get(0).Width = 45F;
            this.sheetView1.Columns.Get(1).CellType = textCellType1;
            this.sheetView1.Columns.Get(1).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Columns.Get(1).Label = "编码";
            this.sheetView1.Columns.Get(1).Width = 46F;
            this.sheetView1.Columns.Get(2).BackColor = System.Drawing.Color.White;
            this.sheetView1.Columns.Get(2).CellType = textCellType2;
            this.sheetView1.Columns.Get(2).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(2).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.sheetView1.Columns.Get(2).Label = "药品名称";
            this.sheetView1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.sheetView1.Columns.Get(2).Width = 120F;
            this.sheetView1.Columns.Get(3).CellType = textCellType3;
            this.sheetView1.Columns.Get(3).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(3).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.sheetView1.Columns.Get(3).Label = "规格";
            this.sheetView1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.sheetView1.Columns.Get(3).Width = 53F;
            numberCellType1.MaximumValue = 9999999.9;
            numberCellType1.MinimumValue = -9999999.9;
            this.sheetView1.Columns.Get(4).CellType = numberCellType1;
            this.sheetView1.Columns.Get(4).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(4).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Columns.Get(4).Label = "数量";
            this.sheetView1.Columns.Get(4).Width = 48F;
            this.sheetView1.Columns.Get(5).CellType = textCellType4;
            this.sheetView1.Columns.Get(5).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(5).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.sheetView1.Columns.Get(5).Label = "单位";
            this.sheetView1.Columns.Get(5).Width = 30F;
            this.sheetView1.Columns.Get(6).CellType = numberCellType2;
            this.sheetView1.Columns.Get(6).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(6).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Columns.Get(6).Label = "零售价";
            this.sheetView1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.sheetView1.Columns.Get(6).Width = 51F;
            this.sheetView1.Columns.Get(7).CellType = numberCellType3;
            this.sheetView1.Columns.Get(7).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(7).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Columns.Get(7).Label = "进价";
            this.sheetView1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.sheetView1.Columns.Get(7).Width = 51F;
            this.sheetView1.Columns.Get(8).CellType = numberCellType4;
            this.sheetView1.Columns.Get(8).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(8).ForeColor = System.Drawing.Color.Black;
            this.sheetView1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Columns.Get(8).Label = "零售总额";
            this.sheetView1.Columns.Get(8).Width = 59F;
            this.sheetView1.Columns.Get(9).CellType = numberCellType5;
            this.sheetView1.Columns.Get(9).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Columns.Get(9).Label = "进价总额";
            this.sheetView1.Columns.Get(9).Width = 59F;
            this.sheetView1.Columns.Get(10).CellType = numberCellType6;
            this.sheetView1.Columns.Get(10).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.sheetView1.Columns.Get(10).Label = "差额";
            this.sheetView1.Columns.Get(10).Width = 57F;
            this.sheetView1.Columns.Get(11).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.sheetView1.Columns.Get(11).Label = "产地";
            this.sheetView1.Columns.Get(11).Width = 90F;
            this.sheetView1.Columns.Get(12).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(12).Label = "批号";
            this.sheetView1.Columns.Get(12).Width = 43F;
            this.sheetView1.Columns.Get(13).Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sheetView1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.sheetView1.Columns.Get(13).Label = "备注";
            this.sheetView1.Columns.Get(13).Width = 35F;
            this.sheetView1.RowHeader.Columns.Default.Resizable = false;
            this.sheetView1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.sheetView1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.sheetView1.RowHeader.DefaultStyle.Locked = false;
            this.sheetView1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.sheetView1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.sheetView1.SheetCornerStyle.Locked = false;
            this.sheetView1.SheetCornerStyle.Parent = "HeaderDefault";
            this.sheetView1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.sheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(216, 18);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(391, 24);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "药品入库报告单";
            // 
            // lb35
            // 
            this.lb35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb35.Location = new System.Drawing.Point(477, 56);
            this.lb35.Name = "lb35";
            this.lb35.Size = new System.Drawing.Size(163, 16);
            this.lb35.TabIndex = 53;
            this.lb35.Text = "打印日期";
            // 
            // lb21
            // 
            this.lb21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb21.Location = new System.Drawing.Point(179, 56);
            this.lb21.Name = "lb21";
            this.lb21.Size = new System.Drawing.Size(153, 16);
            this.lb21.TabIndex = 3;
            this.lb21.Text = "科别";
            // 
            // lb36
            // 
            this.lb36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb36.Location = new System.Drawing.Point(656, 56);
            this.lb36.Name = "lb36";
            this.lb36.Size = new System.Drawing.Size(112, 16);
            this.lb36.TabIndex = 53;
            this.lb36.Text = "页数";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "附原始凭证（份）：1";
            // 
            // ucPhaInputBill
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.panel3);
            this.Name = "ucPhaInputBill";
            this.Size = new System.Drawing.Size(879, 416);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

		#region 属性
		/// <summary>
		/// 是否补打
		/// </summary>
		public bool IsReprint = false;
		/// <summary>
		/// 
		/// </summary>
		private int decimals;
		/// <summary>
		/// 精度（注意farpoint小数位数）
		/// </summary>
		public int Decimals
		{
			get
			{
				return this.decimals;
			}
			set
			{
				this.decimals = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private int maxrowno;
		/// <summary>
		/// 最大行数（修改时请注意实际单据长度）
		/// </summary>
		public int MaxRowNo
		{
			get
			{
				return this.maxrowno;
			}
			set
			{
				this.maxrowno = value;
			}
		}
		/// <summary>
		/// 科室类
		/// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
		
		#region 设计器生成的

        //private System.Windows.Forms.Label lb11;
        //private System.Windows.Forms.Label lb12;
        //private System.Windows.Forms.Label lb13;
        //private System.Windows.Forms.Label lb22;
        //private System.Windows.Forms.Label lb23;
		#endregion

		/// <summary>
		/// 药品函数
		/// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        private Neusoft.HISFC.BizLogic.Pharmacy.Constant conMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
        //private System.Windows.Forms.Label lb34;
        //private System.Windows.Forms.Label lb33;
        //private System.Windows.Forms.Label lb32;
        //private System.Windows.Forms.Label lb31;
		/// <summary>
		/// 人员类
		/// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Person psMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
        private Panel panel3;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView sheetView1;
        private Label lbTitle;
        private Label lb35;
        private Label lb21;
        private Label lb36;
        private Label lb34;
        private Label lb33;
        private Label lb32;
        private Label lb31;
        private Label lb13;
        private Label lb11;

        private Neusoft.HISFC.BizLogic.Manager.Constant constantMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
		#endregion

		#region 方法

		#region 设置打印格式
		/// <summary>
		/// 设置打印数据
		/// </summary>
		/// <param name="al">数据</param>
		/// <param name="pageno">页码</param>
		/// <param name="operCode">操作员</param>
		/// <param name="Kind">打印类型 0.入库计划单  1.采购单   2.入库单   3.出库单    4.</param>
		public void SetDataForInput(ArrayList al ,int pageno,string operCode,string kind)
		{
            //this.panel1.Width = this.Width;
			try
			{
				ArrayList alPrint = new ArrayList();
                int icount = Neusoft.FrameWork.Function.NConvert.ToInt32(Math.Ceiling(Convert.ToDouble(al.Count) / MaxRowNo));

				for(int i = 1 ; i <= icount ; i++ )
				{
					if(i != icount )
					{
						alPrint = al.GetRange( MaxRowNo*(i-1),MaxRowNo );
						this.Print( alPrint , i , icount ,operCode,kind);
					}
					else
					{
						int num = al.Count%MaxRowNo;
						if(al.Count%MaxRowNo == 0)
						{
							num = MaxRowNo;
						}
						alPrint = al.GetRange( MaxRowNo*(i-1),num );
						this.Print(alPrint , i , icount,operCode,kind);
					}
				}
			}
			catch(Exception e)
			{
				MessageBox.Show("打印出错!" + e.Message);
				return;
			}
		}	
	
		#endregion

		#region 打印主函数
		/// <summary>
		/// 打印函数
		/// </summary>
		/// <param name="al">打印数组</param>
		/// <param name="i">第几页</param>
		/// <param name="count">总页数</param>
		/// <param name="operCode">制单人</param>
		/// <param name="kind">打印类型 0.入库计划单  1.采购单   2.入库单   3.出库单    5 入库申请单.</param>
        private void Print(ArrayList al, int inow, int icount, string operCode, string kind)
        {
            this.PrintInput( al, inow, icount, operCode );//计划单
        }
		#endregion

		#region 入库单打印
		/// <summary>
		/// 打印函数
		/// </summary>
		/// <param name="al">打印数组</param>
		/// <param name="i">第几页</param>
		/// <param name="count">总页数</param>
		/// <param name="operCode">制单人</param>
		private void PrintInput(ArrayList al, int inow,int icount,string operCode)
		{
			if( al.Count <= 0 )
			{
				MessageBox.Show("没有打印的数据!");
				return;
			}
            Neusoft.HISFC.BizLogic.Pharmacy.Constant constant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.Input info = (Neusoft.HISFC.Models.Pharmacy.Input)al[0];
			
			#region label赋值
			//this.lbTitle.Text = this.deptMgr.GetDeptmentById(info.StockDept.ID)+"药品入库报告单";

            Neusoft.HISFC.Models.Admin.PowerLevelClass3 class3 = levelManager.LoadLevel3ByPrimaryKey(info.Class2Type, info.PrivType);
            this.lbTitle.Text = constantMgr.GetHospitalName() + this.deptMgr.GetDeptmentById(info.StockDept.ID) + "药品" + class3.Class3Name + "单";

			if(this.IsReprint)
			{
				this.lbTitle.Text = this.lbTitle.Text + "(补打)"; 
			}
			string strCompany = "";
			try
			{
				strCompany = this.conMgr.QueryCompanyByCompanyID(info.Company.ID).Name;
			}
			catch{}
            this.lb11.Text = "供货单位:" + strCompany;
			//this.lb12.Text = "收货日期:" + info.User02;
            this.lb13.Text = "单号:" + info.InListNO;

            this.lb21.Text = "科别:" + this.deptMgr.GetDeptmentById(info.StockDept.ID);//"进货单位:" + this.deptMgr.GetDeptmentById(info.StockDept.ID);
			//this.lb22.Text = "发票号码:" + info.InvoiceNO;
			//this.lb23.Text = "内部单号:" + info.User01;
           // this.lb31.Text = "制单:" + this.psMgr.GetPersonByID(operCode);
            //this.lb32.Text = "复核:";
            //this.lb33.Text = "验收人:";
            //this.lb34.Text = "经手人:"; 
            this.lb32.Text = "药库管理员:" + this.psMgr.GetPersonByID(operCode); ;
            this.lb33.Text = "采购员:";
            this.lb34.Text = "药品会计:";

            this.lb35.Text = "打印日期:" + this.psMgr.GetSysDateTime("yyyy.MM.dd");
			this.lb36.Text = "第" + inow.ToString() + "页/共" + icount.ToString() + "页" ;
			#endregion

			#region farpoint赋值
            string strMemo = string.Empty;
			decimal sumNum2 = 0;
			decimal sumNum7 = 0;
			decimal sumNum8 = 0;
            //decimal sumNum9 = 0;
			decimal sumNum10 = 0;
			this.sheetView1.RowCount = 0;
            if (info.SystemType == "17" || info.SystemType == "18" || info.SystemType == "19")
            {
                this.sheetView1.Columns[13].Label = "备注";
                this.sheetView1.Columns[13].Visible = true;
            }
            else
            {  //暂时让有效日期不可见
                this.sheetView1.Columns[13].Label = "有效日期";
                this.sheetView1.Columns[13].Visible = false;
                
            }

            for (int i = 0; i < al.Count; i++)
            {
                this.sheetView1.AddRows(i, 1);
                Neusoft.HISFC.Models.Pharmacy.Input input = al[i] as Neusoft.HISFC.Models.Pharmacy.Input;
                this.sheetView1.Cells[i, 1].Text = input.Item.ID; //药品编码  //this.itemMgr.GetItem(input.Item.ID).UserCode; //input.Item.UserCode+"??";//药品自定义码
                this.sheetView1.Cells[i, 2].Text = input.Item.Name;//药品名称
                this.sheetView1.Cells[i, 3].Text = input.Item.Specs;//规格		
                this.sheetView1.Cells[i, 5].Text = input.Item.PackUnit;//单位
                if (input.Item.PackQty == 0) input.Item.PackQty = 1;
                decimal count = 0;
                count = input.Quantity;
                this.sheetView1.Cells[i, 4].Text = (count / input.Item.PackQty).ToString();//数量				
                this.sheetView1.Cells[i, 7].Text = (input.Item.PriceCollection.PurchasePrice).ToString();//批发价              
                this.sheetView1.Cells[i, 8].Text = ((input.Item.PriceCollection.RetailPrice) * count / input.Item.PackQty).ToString();//零售总金额
                this.sheetView1.Cells[i, 6].Text = (input.Item.PriceCollection.RetailPrice).ToString();//零售价
                this.sheetView1.Cells[i, 9].Text = ((input.Item.PriceCollection.PurchasePrice) * count / input.Item.PackQty).ToString();//批发总金额 
                this.sheetView1.Cells[i, 10].Text = ((input.Item.PriceCollection.RetailPrice) * count / input.Item.PackQty
                    - (input.Item.PriceCollection.PurchasePrice) * count / input.Item.PackQty).ToString();//购销差价
                this.sheetView1.Cells[i, 12].Text = input.BatchNO.ToString();
                //退库的时候显示备注，其他情况下显示有效期
               // this.sheetView1.Cells[i, 10].Text = input.ValidTime.ToString();
                strMemo = input.Memo;
                if (string.IsNullOrEmpty(strMemo))
                {
                    strMemo = "";
                }
                if (input.SystemType == "17" || input.SystemType == "18" || input.SystemType == "19")
                {


                    this.sheetView1.Cells[i, 13].Text = strMemo;
                }
                else
                {

                    
                    this.sheetView1.Cells[i, 13].Text = input.ValidTime.ToString();
                    
                   
                }

                this.sheetView1.Cells[i, 11].Text = input.Item.Product.Producer.ToString();
                if ((input.Item.Product.Producer.ToString()) != "")
                    this.sheetView1.Cells[i, 11].Text = input.Item.Product.Producer.ToString();
                else
                    this.sheetView1.Cells[i, 11].Text = "未录入";

                sumNum2 = sumNum2 + count / input.Item.PackQty;
                sumNum7 = sumNum7 + (input.Item.PriceCollection.RetailPrice) * count / input.Item.PackQty;
                sumNum8 = sumNum8 + (input.Item.PriceCollection.PurchasePrice) * count / input.Item.PackQty;
                sumNum10 = sumNum10 + (input.Item.PriceCollection.RetailPrice) * count / input.Item.PackQty
                    - (input.Item.PriceCollection.PurchasePrice) * count / input.Item.PackQty;
            }

          
           

			this.sheetView1.RowCount = al.Count + 1;			
			this.sheetView1.Cells[al.Count,0].Text = "合计";
            this.sheetView1.Cells[al.Count,1].Text = "共" + al.Count + "行";//行数
			this.sheetView1.Cells[al.Count,4].Text = sumNum2.ToString();			
			this.sheetView1.Cells[al.Count,9].Text = sumNum8.ToString();
            this.sheetView1.Cells[al.Count,8].Text = sumNum7.ToString();
			//this.sheetView1.Cells[al.Count,9].Text = sumNum9.ToString();
			this.sheetView1.Cells[al.Count,10].Text = sumNum10.ToString();
			#endregion 
			
			#region 界面调整
			
			//宽度
            //this.panel4.Width = this.Width - 3;
            //this.fpSpread1.Width = this.panel4.Width - 10;
			this.fpSpread1.Height = (int)this.sheetView1.RowHeader.Rows[0].Height +
				(int)(this.sheetView1.Rows[0].Height*(al.Count+1)) + 10;
			
			//高度设置
            //this.panel4.Height = this.fpSpread1.Height +3;
            //this.lb31.Location = new Point(this.lb31.Location.X,this.fpSpread1.Location.Y + this.fpSpread1.Height + 1);
            //this.lb32.Location = new Point(this.lb32.Location.X,this.lb31.Location.Y );
            //this.lb33.Location = new Point(this.lb33.Location.X,this.lb31.Location.Y );
            //this.lb34.Location = new Point(this.lb34.Location.X,this.lb31.Location.Y );
            this.lb35.Location = new Point(this.lb35.Location.X, this.lb21.Location.Y);
            this.lb36.Location = new Point(this.lb36.Location.X, this.lb21.Location.Y);
			
			#endregion

			#region 打印函数
            //Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //p.IsDataAutoExtend = false;//p.ShowPageSetup();
            //Neusoft.HISFC.Models.Base.PageSize page = new Neusoft.HISFC.Models.Base.PageSize();
            ////page.Height = 342;
            ////page.Width = 342;
            ////page.Name = "PhaInput";
            //Neusoft.HISFC.BizLogic.Manager.PageSize pManager = new Neusoft.HISFC.BizLogic.Manager.PageSize();
            //p.SetPageSize(pManager.GetPageSize("PhaInput"));
            //p.PrintPage(5, 0, this);

            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsDataAutoExtend = false;

            Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("PhaInput", ref p);

            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            p.IsHaveGrid = true;

            p.PrintPage(5, 0, this.panel3);



            //Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();

            //HISFC.Components.Common.Classes.Function.GetPageSize("PhaInput", p);

            //Neusoft.HISFC.BizLogic.Manager.PageSize pageManger = new Neusoft.HISFC.BizLogic.Manager.PageSize();

            //Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize();


            //p.SetPageSize(pageManger.GetPageSize("PhaInput"));


            //p.PrintPage(5, 0, this);

            //Neusoft.FrameWork.WinForms.Classes.Print p = null;

            //try
            //{
            //    p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("初始化打印机出错");
            //}

            //Neusoft.HISFC.BizLogic.Manager.PageSize pageManger = new Neusoft.HISFC.BizLogic.Manager.PageSize();
            
            //p.SetPageSize(pageManger.GetPageSize("PhaInput"));

            //p.PrintPreview(this);
			#endregion
 
		}

		#endregion

		#endregion


        #region IBillPrint 成员

        public int Prieview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            return 1;
        }

        public int SetData(ArrayList alPrintData, Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType billType)
        {
            if (billType == Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType.InnerApplyIn)
            {
                return this.SetDataPrintApp(alPrintData,billType);
            }

            return 1;
        }

        public int SetData(ArrayList alPrintData, string privType)
        {
            this.maxrowno = 12;
            try
            {
                ArrayList alPrint = new ArrayList();
                int icount = Neusoft.FrameWork.Function.NConvert.ToInt32(Math.Ceiling(Convert.ToDouble(alPrintData.Count) / MaxRowNo));

                for (int i = 1; i <= icount; i++)
                {
                    if (i != icount)
                    {
                        alPrint = alPrintData.GetRange(MaxRowNo * (i - 1), MaxRowNo);
                        this.Print(alPrint, i, icount, "", "");
                    }
                    else
                    {
                        int num = alPrintData.Count % MaxRowNo;
                        if (alPrintData.Count % MaxRowNo == 0)
                        {
                            num = MaxRowNo;
                        }
                        alPrint = alPrintData.GetRange(MaxRowNo * (i - 1), num);
                        this.Print(alPrint, i, icount, "", "");
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("打印出错!" + e.Message);
                return -1;
            }
        }

        public int SetData(string billNO)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        /// <summary>
        /// 设置打印页数(入库退库申请)
        /// 
        ///             //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
        /// </summary>
        /// <param name="alPrintData"></param>
        public int SetDataPrintApp(ArrayList alPrintData,Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType billType)
        {
            this.maxrowno = 13;

            try
            {
                ArrayList alPrint = new ArrayList();
                int icount = Neusoft.FrameWork.Function.NConvert.ToInt32(Math.Ceiling(Convert.ToDouble(alPrintData.Count) / MaxRowNo));

                Neusoft.HISFC.Models.Base.Employee operEmp = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

                for (int i = 1; i <= icount; i++)
                {
                    if (i != icount)
                    {
                        alPrint = alPrintData.GetRange(MaxRowNo * (i - 1), MaxRowNo);
                        this.InputPrintApp( alPrint, i, icount, operEmp.ID, billType );
                    }
                    else
                    {
                        int num = alPrintData.Count % MaxRowNo;
                        if (alPrintData.Count % MaxRowNo == 0)
                        {
                            num = MaxRowNo;
                        }
                        alPrint = alPrintData.GetRange(MaxRowNo * (i - 1), num);

                        this.InputPrintApp( alPrint, i, icount, operEmp.ID, billType );
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("打印出错!" + e.Message);
                return -1;
            }
        }

        /// <summary>
        /// 打印函数(入库退库申请)
        /// 
        ///             //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
        /// </summary>
        /// <param name="al">打印数组</param>
        /// <param name="irowno">第几页</param>
        /// <param name="icount">总页数</param>
        /// <param name="operCode">制单人</param>
        public void InputPrintApp(ArrayList al, int irowno, int icount, string operCode,Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType billType)
        {
            if (al.Count <= 0)
            {
                MessageBox.Show("无可打印的数据");
                return;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Constant constant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.ApplyOut info = (Neusoft.HISFC.Models.Pharmacy.ApplyOut)al[0];

            #region label赋值
            if (info.SystemType == "13")        //内部入库申请
            {
                this.lbTitle.Text = this.deptMgr.GetDeptmentById( info.StockDept.ID ) + " 入库申请单";
            }
            else
            {
                this.lbTitle.Text = this.deptMgr.GetDeptmentById( info.StockDept.ID ) + " 退库申请单";
            }
            if (this.IsReprint)
            {
                this.lbTitle.Text = this.lbTitle.Text + "(补打)";
            }

            this.lb21.Text = "申请科室:" + this.deptMgr.GetDeptmentById(info.ApplyDept.ID);

            this.lb35.Text = "打印日期:" + this.psMgr.GetSysDateTime("yyyy.MM.dd");
            this.lb36.Text = "第" + irowno.ToString() + "页/共" + icount.ToString() + "页";
            #endregion

            #region farpoint赋值

            decimal sumNum2 = 0;
            decimal sumNum7 = 0;
            decimal sumNum8 = 0;

            decimal sumNum10 = 0;

            this.sheetView1.RowCount = 0;
            for (int i = 0; i < al.Count; i++)
            {
                this.sheetView1.AddRows(i, 1);

                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyout = al[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                this.sheetView1.Cells[i, 1].Text = applyout.Item.ID;//this.itemMgr.GetItem(applyout.Item.ID).UserCode; 
                this.sheetView1.Cells[i, 2].Text = applyout.Item.Name;//药品名称
                this.sheetView1.Cells[i, 3].Text = applyout.Item.Specs;//规格		
                this.sheetView1.Cells[i, 5].Text = applyout.Item.PackUnit;//单位
                if (applyout.Item.PackQty == 0)
                {
                    applyout.Item.PackQty = 1;
                }

                decimal count = 0;
                count = applyout.Operation.ApplyQty;

                if (applyout.SystemType == "13")        //内部入库申请
                {
                    
                    
                    this.sheetView1.Cells[i, 4].Text = (count / applyout.Item.PackQty).ToString();//数量	
                    this.sheetView1.Cells[i, 6].Text = (applyout.Item.PriceCollection.RetailPrice).ToString();//零售价
                    this.sheetView1.Cells[i, 7].Text = (applyout.Item.PriceCollection.PurchasePrice).ToString();//进价 
                    this.sheetView1.Cells[i, 8].Text = ((applyout.Item.PriceCollection.RetailPrice) * count / applyout.Item.PackQty).ToString();//零售总金额
                    this.sheetView1.Cells[i, 9].Text = ((applyout.Item.PriceCollection.PurchasePrice) * count / applyout.Item.PackQty).ToString(); //进价总额
                                 
                    
                    
                    //this.sheetView1.Cells[i, 8].Text = ((applyout.Item.PriceCollection.PurchasePrice) * count / applyout.Item.PackQty).ToString();//批发总金额 
                    this.sheetView1.Cells[i, 10].Text = ((applyout.Item.PriceCollection.RetailPrice) * count / applyout.Item.PackQty
                        - (applyout.Item.PriceCollection.PurchasePrice) * count / applyout.Item.PackQty).ToString();//购销差价
                }
                else                                   //内部入库退库申请
                {
                    this.sheetView1.Cells[i, 4].Text = (-(count / applyout.Item.PackQty)).ToString();//数量	
                    this.sheetView1.Cells[i, 7].Text = (applyout.Item.PriceCollection.PurchasePrice).ToString();//批发价              
                    this.sheetView1.Cells[i, 8].Text = ((-applyout.Item.PriceCollection.RetailPrice) * count / applyout.Item.PackQty).ToString();//零售总金额
                    this.sheetView1.Cells[i, 6].Text = (applyout.Item.PriceCollection.RetailPrice).ToString();//零售价
                    this.sheetView1.Cells[i, 9].Text = ((-applyout.Item.PriceCollection.PurchasePrice) * count / applyout.Item.PackQty).ToString();//批发总金额 
                    this.sheetView1.Cells[i, 10].Text = ((applyout.Item.PriceCollection.RetailPrice) * count / applyout.Item.PackQty
                        - (applyout.Item.PriceCollection.PurchasePrice) * count / applyout.Item.PackQty).ToString();//购销差价
                }
                
                
                this.sheetView1.Cells[i, 12].Text = applyout.BatchNO.ToString();
                //产地
                //this.sheetView1.Columns[10].Visible = true;
                

                if ((applyout.Item.Product.Producer.ToString()) != "")
                    this.sheetView1.Cells[i, 11].Text = applyout.Item.Product.Producer.ToString();
                else
                    this.sheetView1.Cells[i, 11].Text = "未录入";
                //有效期
               

                //if ((applyout.Item.Product.Producer.ToString()) != "")
                //    this.sheetView1.Cells[i, 12].Text = applyout.Item.Product.Producer.ToString();
                //else
                //    this.sheetView1.Cells[i, 12].Text = "未录入";

                sumNum2 = sumNum2 + count / applyout.Item.PackQty;
                sumNum7 = sumNum7 + (applyout.Item.PriceCollection.RetailPrice) * count / applyout.Item.PackQty;
                sumNum8 = sumNum8 + (applyout.Item.PriceCollection.PurchasePrice) * count / applyout.Item.PackQty;

                sumNum10 = sumNum10 + (applyout.Item.PriceCollection.RetailPrice) * count / applyout.Item.PackQty
                    - (applyout.Item.PriceCollection.PurchasePrice) * count / applyout.Item.PackQty;
            }
            this.sheetView1.RowCount = al.Count + 1;
            this.sheetView1.Cells[al.Count, 0].Text = "合计";
            this.sheetView1.Cells[al.Count, 1].Text = "共" + al.Count + "行";//行数

            this.sheetView1.Cells[al.Count, 4].Text = sumNum2.ToString();
            this.sheetView1.Cells[al.Count, 9].Text = sumNum8.ToString();
            this.sheetView1.Cells[al.Count, 8].Text = sumNum7.ToString();

            this.sheetView1.Cells[al.Count, 10].Text = sumNum10.ToString();
            #endregion

            #region 界面调整

            this.fpSpread1.Height = (int)this.sheetView1.RowHeader.Rows[0].Height +
                (int)(this.sheetView1.Rows[0].Height * (al.Count + 1)) + 10;

            this.lb35.Location = new Point(this.lb35.Location.X, this.lb21.Location.Y);
            this.lb36.Location = new Point(this.lb36.Location.X, this.lb21.Location.Y);

            #endregion

            #region 打印函数

            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsDataAutoExtend = false;

            Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("PhaInput", ref p);

            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            p.IsHaveGrid = true;

            p.PrintPage(5, 0, this.panel3);

            #endregion
        }
      
    }
}
