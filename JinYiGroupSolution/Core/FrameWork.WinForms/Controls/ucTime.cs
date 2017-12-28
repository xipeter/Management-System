//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Windows.Forms;
//using System.Windows.Forms.Design;
//
//namespace Neusoft.NFC.Interface.Controls 
//{
//	/// <summary>
//	/// ucControlDesigener 的摘要说明。实现在设计时禁止修改控件高度
//	/// </summary>
//	public class ucControlDesigner:System.Windows.Forms.Design.ControlDesigner
//	{
//		public ucControlDesigner() 
//		{
//			//
//			// TODO: 在此处添加构造函数逻辑
//			//
//		}
//		
//		public override System.Windows.Forms.Design.SelectionRules SelectionRules 
//		{
//			get 
//			{
//				SelectionRules rules = SelectionRules.Visible | SelectionRules.Moveable | 
//					SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
//				return rules;
//			}
//		}
//
//	}	
//
//	/// <summary>
//	/// ucTime 的摘要说明。 
//	/// </summary>
//	[Designer(typeof(ucControlDesigner))]
//	public class ucTime : System.Windows.Forms.UserControl
//	{
//		public event System.EventHandler ValueChanged;
//		public event System.EventHandler CloseUp;
//		public event System.EventHandler DropDown;
//
//		private FarPoint.Win.Spread.FpSpread fpSpread1;
//		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
//		private System.Windows.Forms.DateTimePicker dateTimePicker1;
//		private FarPoint.Win.Spread.PrintInfo printInfo = new FarPoint.Win.Spread.PrintInfo();
//		DateTimeCellType dateTime = new DateTimeCellType();
//		/// <summary> 
//		/// 必需的设计器变量。
//		/// </summary>
//		private System.ComponentModel.Container components = null;
//
//		public ucTime()
//		{
//			// 该调用是 Windows.Forms 窗体设计器所必需的。
//			InitializeComponent();
//
//			// TODO: 在 InitializeComponent 调用后添加任何初始化
//			//初始化FarPoint DateTimeCellType设置信息
//			dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
//			dateTime.MinimumDate = this.dateTimePicker1.MinDate;
//			dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
//			this.fpSpread1_Sheet1.Cells[0,0].Value = this.dateTimePicker1.Value;
//			switch(this.dateTimePicker1.Format.ToString()) 
//			{
//				case "Long":						
//					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;	
//					break;						
//				case "Short":
//					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
//					break;
//				case "Time":
//					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
//					break;
//				case "Custom":
//					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
//					break;
//			}
//			this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
//			//对该控件打印时不显示边框
//			printInfo.ShowBorder = false;
//			printInfo.ShowGrid = false;
//			this.fpSpread1_Sheet1.PrintInfo = printInfo;
//		}
//
//		/// <summary> 
//		/// 清理所有正在使用的资源。
//		/// </summary>
//		protected override void Dispose( bool disposing )
//		{
//			if( disposing )
//			{
//				if(components != null)
//				{
//					components.Dispose();
//				}
//			}
//			base.Dispose( disposing );
//		}
//
//		#region 组件设计器生成的代码
//		/// <summary> 
//		/// 设计器支持所需的方法 - 不要使用代码编辑器 
//		/// 修改此方法的内容。
//		/// </summary>
//		private void InitializeComponent()
//		{
//			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
//			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
//			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
//			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
//			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
//			this.SuspendLayout();
//			// 
//			// fpSpread1
//			// 
//			this.fpSpread1.AllowEditOverflow = true;
//			this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
//			this.fpSpread1.EditModePermanent = true;
//			this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//			this.fpSpread1.Location = new System.Drawing.Point(0, 0);
//			this.fpSpread1.Name = "fpSpread1";
//			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//																				   this.fpSpread1_Sheet1});
//			this.fpSpread1.Size = new System.Drawing.Size(195, 21);
//			this.fpSpread1.TabIndex = 0;
//			this.fpSpread1.EditModeOff += new EventHandler(fpSpread1_EditModeOff);
//			this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//			// 
//			// fpSpread1_Sheet1
//			// 
//			this.fpSpread1_Sheet1.Reset();
//			this.fpSpread1_Sheet1.ColumnCount = 1;
//			this.fpSpread1_Sheet1.RowCount = 1;
//			this.fpSpread1_Sheet1.ColumnHeader.RowCount = 0;
//			this.fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
//			this.fpSpread1_Sheet1.ColumnHeader.Visible = false;
//			this.fpSpread1_Sheet1.Columns.Get(0).Width = 195F;
//			this.fpSpread1_Sheet1.DataAutoCellTypes = false;
//			this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
//			this.fpSpread1_Sheet1.RowHeader.Visible = false;
//			this.fpSpread1_Sheet1.SheetName = "Sheet1";
//			this.fpSpread1_Sheet1.Columns.Default.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
//			this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpSpread1_Sheet1_CellChanged);
//			// 
//			// dateTimePicker1
//			// 
//			this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//				| System.Windows.Forms.AnchorStyles.Right)));
//			this.dateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
//			this.dateTimePicker1.Location = new System.Drawing.Point(174, 0);
//			this.dateTimePicker1.Name = "dateTimePicker1";
//			this.dateTimePicker1.Size = new System.Drawing.Size(21, 21);
//			this.dateTimePicker1.TabIndex = 1;
//			this.dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
//			this.dateTimePicker1.CloseUp += new EventHandler(dateTimePicker1_CloseUp);
//			this.dateTimePicker1.DropDown += new EventHandler(dateTimePicker1_DropDown);
//			// 
//			// ucTime
//			// 
//			this.Controls.Add(this.dateTimePicker1);
//			this.Controls.Add(this.fpSpread1);
//			this.Resize += new EventHandler(ucTime_Resize);
//			this.Name = "ucTime";
//			this.Size = new System.Drawing.Size(195, 21);
//			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
//			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
//			this.ResumeLayout(false);
//
//		}
//		#endregion
//
//		/// <summary>
//		/// 禁止运行时修改高度
//		/// </summary>
//		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) 
//		{
//			base.SetBoundsCore (x, y, width, 21, specified);
//		}
//
//
//		[CategoryAttribute("行为"), DescriptionAttribute("允许显示的最小时间")] 　　
//		public DateTime MinDate 
//		{
//			get {return this.dateTimePicker1.MinDate;}
//			set 
//			{
//				this.dateTimePicker1.MinDate = value;
//				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();
//				//				dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
//				dateTime.MinimumDate = Convert.ToDateTime(value.ToString("d"));
//				//				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
//				//				switch(this.dateTimePicker1.Format.ToString()) {
//				//					case "Long":						
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;						
//				//						break;						
//				//					case "Short":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
//				//						break;
//				//					case "Time":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
//				//						break;
//				//					case "Custom":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
//				//						break;
//				//				}
//				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
//			}
//		}
//
//		[CategoryAttribute("行为"), DescriptionAttribute("允许显示的最大时间")] 　　
//		public DateTime MaxDate
//		{
//			get {return this.dateTimePicker1.MaxDate;}
//			set 
//			{
//				this.dateTimePicker1.MaxDate = value;
//				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();				dateTime.MinimumDate = this.dateTimePicker1.MinDate;
//				dateTime.MaximumDate = Convert.ToDateTime(value.ToString("d"));
//				//				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
//				//				switch(this.dateTimePicker1.Format.ToString()) {
//				//					case "Long":						
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;						
//				//						break;						
//				//					case "Short":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
//				//						break;
//				//					case "Time":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
//				//						break;
//				//					case "Custom":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
//				//						break;
//				//				}
//				//应用新的CellType设置
//				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
//			}
//		}
//		
//		[CategoryAttribute("行为"), DescriptionAttribute("控件显示时间")] 　　
//		public DateTime Value
//		{
//			get {return Convert.ToDateTime(this.fpSpread1_Sheet1.Cells[0,0].Value);}
//			set 
//			{
//				this.dateTimePicker1.Value = value;
//				this.fpSpread1_Sheet1.Cells[0,0].Value = value;
//			}
//		}
//		
//		[CategoryAttribute("行为"), DescriptionAttribute("时间显示方式"),DefaultValue(System.Windows.Forms.DateTimePickerFormat.Long)] 　　
//		public System.Windows.Forms.DateTimePickerFormat Format 
//		{
//			get {return this.dateTimePicker1.Format;}
//			set 
//			{
//				this.dateTimePicker1.Format = value;
//				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();				
//				//				dateTime.MinimumDate = this.dateTimePicker1.MinDate;
//				//				dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
//				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
//				switch(value.ToString()) 
//				{
//					case "Long":						
//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;	
//						break;						
//					case "Short":
//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
//						break;
//					case "Time":
//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
//						break;
//					case "Custom":
//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
//						break;
//				}
//				//应用新的CellType设置
//				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
//			}
//		}
//
//		[CategoryAttribute("行为"), DescriptionAttribute("时间自定义显示方式"),DefaultValue("yyyy-MM-DD")] 　　
//		public string CustomFormat 
//		{
//			get {return this.dateTimePicker1.CustomFormat;}
//			set 
//			{
//				this.dateTimePicker1.CustomFormat = value;
//				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();				
//				//				dateTime.MinimumDate = this.dateTimePicker1.MinDate;
//				//				dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
//				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
//				//				switch(this.dateTimePicker1.Format.ToString()) {
//				//					case "Long":						
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.LongDate;						
//				//						break;						
//				//					case "Short":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
//				//						break;
//				//					case "Time":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
//				//						break;
//				//					case "Custom":
//				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
//				//						break;
//				//				}
//				//应用新的CellType设置
//				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
//				
//			}
//		}
//
//		[CategoryAttribute("行为"),DescriptionAttribute("设定是否显示下拉日历"),DefaultValue(true)]
//		public bool IsShowArrow 
//		{
//			get {return this.dateTimePicker1.Visible;}
//			set {this.dateTimePicker1.Visible = value;}
//		}
//
//		private bool isEnterSkip = true;
//		[CategoryAttribute("行为"),DescriptionAttribute("设定按下Enter键后,是否按照tab键顺序自动跳转"),DefaultValue(true)]
//		public bool IsEnterSkip
//		{
//			get {return this.isEnterSkip;}
//			set {this.isEnterSkip = value;}
//		}
//
//		/// <summary>
//		/// 由下拉日历选择日期后设置farPoint显示
//		/// </summary>
//		private void dateTimePicker1_CloseUp(object sender, System.EventArgs e) 
//		{
////			this.fpSpread1_Sheet1.Cells[0,0].Value = this.dateTimePicker1.Value;
//			if (this.CloseUp != null)
//				CloseUp(sender,e);
//		}
//
//		/// <summary>
//		/// 在设计中左右拖动控件时、更改显示长度
//		/// </summary>
//		private void ucTime_Resize(object sender, EventArgs e) 
//		{
//			if (this.Width > this.fpSpread1_Sheet1.Columns.Get(0).Width + this.dateTimePicker1.Width)
//				this.fpSpread1_Sheet1.Columns.Get(0).Width = this.Width - this.dateTimePicker1.Width;
//		}
//		
//		
//		/// <summary>
//		/// 对调用该控件的父控件进行打印
//		/// </summary>
//		/// <param name="parentControl">父控件</param>
//		public void PrintPreview(System.Windows.Forms.Control parentControl) 
//		{
//			Neusoft.NFC.Interface.Classes.Print pr = new Neusoft.NFC.Interface.Classes.Print();
//			pr.IsDataAutoExtend = false;
//			this.IsShowArrow = false;
//			pr.PrintPreview(parentControl);
//			this.IsShowArrow = true;
//		}
//
//		
//		//设定在父窗口内回车键是否跳转到下一个控件
//		private void fpSpread1_EditModeOff(object sender, EventArgs e)
//		{
//			if (this.isEnterSkip)
//				this.ParentForm.SelectNextControl(this,true,true,true,true);
//		}
//		
//		
//		/// <summary>
//		/// 由下拉日历选择日期后设置farPoint显示
//		/// </summary>
//		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
//		{
//			try
//			{
//				this.fpSpread1_Sheet1.Cells[0,0].Value = this.dateTimePicker1.Value;
//			}
//			catch
//			{}
//		}
//
//		
//		private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
//		{
//			if (ValueChanged != null)
//                ValueChanged(sender,System.EventArgs.Empty);
//		}
//
//		
//		private void dateTimePicker1_DropDown(object sender, EventArgs e)
//		{
//			if (this.DropDown != null)
//				DropDown(sender,e);
//		}
//	}
//}
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Neusoft.NFC.Interface.Controls 
{
	/// <summary>
	/// ucTime 的摘要说明。 
	/// </summary>
	//[Designer(typeof(ucControlDesigner))]
	public class ucTime : System.Windows.Forms.UserControl
	{
		public event System.EventHandler ValueChanged;
		public event System.EventHandler CloseUp;
		public event System.EventHandler DropDown;

		public FarPoint.Win.Spread.FpSpread fpSpread1;
		public FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private FarPoint.Win.Spread.PrintInfo printInfo = new FarPoint.Win.Spread.PrintInfo();
		DateTimeCellType dateTime = new DateTimeCellType();
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucTime()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
			//初始化FarPoint DateTimeCellType设置信息
			dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
			dateTime.MinimumDate = this.dateTimePicker1.MinDate;
			dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
			this.fpSpread1_Sheet1.Cells[0,0].Value = this.dateTimePicker1.Value;
			switch(this.dateTimePicker1.Format.ToString()) 
			{
				case "Long":						
					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;	
					break;						
				case "Short":
					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
					break;
				case "Time":
					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
					break;
				case "Custom":
					dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
					break;
			}
			this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
			//对该控件打印时不显示边框
			printInfo.ShowBorder = false;
			printInfo.ShowGrid = false;
			this.fpSpread1_Sheet1.PrintInfo = printInfo;
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
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpSpread1
			// 
			this.fpSpread1.AllowEditOverflow = true;
			this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fpSpread1.EditModePermanent = true;
			this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpSpread1.Location = new System.Drawing.Point(0, 0);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(195, 21);
			this.fpSpread1.TabIndex = 0;
			this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpSpread1.EditModeOff += new System.EventHandler(this.fpSpread1_EditModeOff);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.ColumnCount = 1;
			this.fpSpread1_Sheet1.ColumnHeader.RowCount = 0;
			this.fpSpread1_Sheet1.RowCount = 1;
			this.fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			this.fpSpread1_Sheet1.ColumnHeader.Visible = false;
			this.fpSpread1_Sheet1.Columns.Get(0).Width = 195F;
			this.fpSpread1_Sheet1.DataAutoCellTypes = false;
			this.fpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
			this.fpSpread1_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
			this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpSpread1_Sheet1.RowHeader.Visible = false;
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.fpSpread1_Sheet1_CellChanged);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dateTimePicker1.Location = new System.Drawing.Point(174, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(21, 21);
			this.dateTimePicker1.TabIndex = 1;
			this.dateTimePicker1.DropDown += new System.EventHandler(this.dateTimePicker1_DropDown);
			this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// ucTime
			// 
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.fpSpread1);
			this.Name = "ucTime";
			this.Size = new System.Drawing.Size(195, 21);
			this.Resize += new System.EventHandler(this.ucTime_Resize);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 禁止运行时修改高度
		/// </summary>
		//		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) 
		//		{
		//			base.SetBoundsCore (x, y, width, 21, specified);
		//		}


		[CategoryAttribute("行为"), DescriptionAttribute("允许显示的最小时间")] 　　
		public DateTime MinDate 
		{
			get {return this.dateTimePicker1.MinDate;}
			set 
			{
				this.dateTimePicker1.MinDate = value;
				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();
				//				dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
				dateTime.MinimumDate = Convert.ToDateTime(value.ToString("d"));
				//				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
				//				switch(this.dateTimePicker1.Format.ToString()) {
				//					case "Long":						
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;						
				//						break;						
				//					case "Short":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
				//						break;
				//					case "Time":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
				//						break;
				//					case "Custom":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
				//						break;
				//				}
				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
			}
		}

		[CategoryAttribute("行为"), DescriptionAttribute("允许显示的最大时间")] 　　
		public DateTime MaxDate
		{
			get {return this.dateTimePicker1.MaxDate;}
			set 
			{
				this.dateTimePicker1.MaxDate = value;
				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();				dateTime.MinimumDate = this.dateTimePicker1.MinDate;
				dateTime.MaximumDate = Convert.ToDateTime(value.ToString("d"));
				//				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
				//				switch(this.dateTimePicker1.Format.ToString()) {
				//					case "Long":						
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;						
				//						break;						
				//					case "Short":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
				//						break;
				//					case "Time":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
				//						break;
				//					case "Custom":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
				//						break;
				//				}
				//应用新的CellType设置
				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
			}
		}
		
		[CategoryAttribute("行为"), DescriptionAttribute("控件显示时间")] 　　
		public DateTime Value
		{
			get {return Convert.ToDateTime(this.fpSpread1_Sheet1.Cells[0,0].Value);}
			set 
			{
				this.dateTimePicker1.Value = value;
				this.fpSpread1_Sheet1.Cells[0,0].Value = value;
			}
		}
		
		[CategoryAttribute("行为"), DescriptionAttribute("时间显示方式"),DefaultValue(System.Windows.Forms.DateTimePickerFormat.Long)] 　　
		public System.Windows.Forms.DateTimePickerFormat Format 
		{
			get {return this.dateTimePicker1.Format;}
			set 
			{
				this.dateTimePicker1.Format = value;
				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();				
				//				dateTime.MinimumDate = this.dateTimePicker1.MinDate;
				//				dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
				switch(value.ToString()) 
				{
					case "Long":						
						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;	
						break;						
					case "Short":
						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
						break;
					case "Time":
						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
						break;
					case "Custom":
						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
						break;
				}
				//应用新的CellType设置
				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
			}
		}

		[CategoryAttribute("行为"), DescriptionAttribute("时间自定义显示方式"),DefaultValue("yyyy-MM-DD")] 　　
		public string CustomFormat 
		{
			get {return this.dateTimePicker1.CustomFormat;}
			set 
			{
				this.dateTimePicker1.CustomFormat = value;
				//				FarPoint.Win.Spread.CellType.DateTimeCellType dateTime = new FarPoint.Win.Spread.CellType.DateTimeCellType();				
				//				dateTime.MinimumDate = this.dateTimePicker1.MinDate;
				//				dateTime.MaximumDate = this.dateTimePicker1.MaxDate;
				dateTime.UserDefinedFormat = this.dateTimePicker1.CustomFormat;
				//				switch(this.dateTimePicker1.Format.ToString()) {
				//					case "Long":						
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.LongDate;						
				//						break;						
				//					case "Short":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
				//						break;
				//					case "Time":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
				//						break;
				//					case "Custom":
				//						dateTime.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
				//						break;
				//				}
				//应用新的CellType设置
				this.fpSpread1_Sheet1.Cells[0,0].CellType = dateTime;
				
			}
		}

		[CategoryAttribute("行为"),DescriptionAttribute("设定是否显示下拉日历"),DefaultValue(true)]
		public bool IsShowArrow 
		{
			get {return this.dateTimePicker1.Visible;}
			set {this.dateTimePicker1.Visible = value;}
		}

		private bool isEnterSkip = true;
		[CategoryAttribute("行为"),DescriptionAttribute("设定按下Enter键后,是否按照tab键顺序自动跳转"),DefaultValue(true)]
		public bool IsEnterSkip
		{
			get {return this.isEnterSkip;}
			set {this.isEnterSkip = value;}
		}

		/// <summary>
		/// 由下拉日历选择日期后设置farPoint显示
		/// </summary>
		private void dateTimePicker1_CloseUp(object sender, System.EventArgs e) 
		{
			//			this.fpSpread1_Sheet1.Cells[0,0].Value = this.dateTimePicker1.Value;
			if (this.CloseUp != null)
				CloseUp(sender,e);
		}

		/// <summary>
		/// 在设计中左右拖动控件时、更改显示长度
		/// </summary>
		private void ucTime_Resize(object sender, EventArgs e) 
		{
			if (this.Width > this.fpSpread1_Sheet1.Columns.Get(0).Width + this.dateTimePicker1.Width)
				this.fpSpread1_Sheet1.Columns.Get(0).Width = this.Width - this.dateTimePicker1.Width;
		}
		
		
		/// <summary>
		/// 对调用该控件的父控件进行打印
		/// </summary>
		/// <param name="parentControl">父控件</param>
		public void PrintPreview(System.Windows.Forms.Control parentControl) 
		{
			Neusoft.NFC.Interface.Classes.Print pr = new Neusoft.NFC.Interface.Classes.Print();
			pr.IsDataAutoExtend = false;
			this.IsShowArrow = false;
			pr.PrintPreview(parentControl);
			this.IsShowArrow = true;
		}

		
		//设定在父窗口内回车键是否跳转到下一个控件
		private void fpSpread1_EditModeOff(object sender, EventArgs e)
		{
			if (this.isEnterSkip)
				this.ParentForm.SelectNextControl(this,true,true,true,true);
		}
		
		
		/// <summary>
		/// 由下拉日历选择日期后设置farPoint显示
		/// </summary>
		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.fpSpread1_Sheet1.Cells[0,0].Value = this.dateTimePicker1.Value;
			}
			catch
			{}
		}

		
		private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
		{
			if (ValueChanged != null)
				ValueChanged(sender,System.EventArgs.Empty);
		}

		
		private void dateTimePicker1_DropDown(object sender, EventArgs e)
		{
			if (this.DropDown != null)
				DropDown(sender,e);
		}
	}

	/// <summary>
	/// ucControlDesigener 的摘要说明。实现在设计时禁止修改控件高度
	/// </summary>
	public class ucControlDesigner:System.Windows.Forms.Design.ControlDesigner
	{
		public ucControlDesigner() 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public override System.Windows.Forms.Design.SelectionRules SelectionRules 
		{
			get 
			{
				SelectionRules rules = SelectionRules.Visible | SelectionRules.Moveable | 
					SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
				return rules;
			}
		}

	}	
}

