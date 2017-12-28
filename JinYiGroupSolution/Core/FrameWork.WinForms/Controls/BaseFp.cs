using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.NFC.Interface.Controls
{
	
	/// <summary>
	/// BaseFp2 的摘要说明。
	/// </summary>
	public class BaseFp : System.Windows.Forms.UserControl,Neusoft.NFC.Interface.FpInterface
	{
		public FarPoint.Win.Spread.FpSpread fpSpread1;
		public FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BaseFp()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

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
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpSpread1
			// 
			this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fpSpread1.Location = new System.Drawing.Point(0, 0);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(384, 400);
			this.fpSpread1.TabIndex = 0;
			this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// BaseFp
			// 
			this.Controls.Add(this.fpSpread1);
			this.Name = "BaseFp";
			this.Size = new System.Drawing.Size(384, 400);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region 变量
		System.Data.DataSet myDataSet;
		Color myBackColor=Color.White;
		Color myForeColor=Color.Black;
		Color myHeaderForeColor=Color.Black;
		Color myHeaderBackColor=Color.Silver;
		Color myColumnForeColor=Color.Black;
		Color myColumnBackColor=Color.Silver;
		Color myChildHeader1ForeColor=Color.Black;
		Color myChildHeader1BackColor=Color.Silver;
		Color myChildColumn1ForeColor=Color.Black;
		Color myChildColumn1BackColor=Color.Silver;
		Color myChildHeader2ForeColor=Color.Black;
		Color myChildHeader2BackColor=Color.Silver;
		Color myChildColumn2ForeColor=Color.Black;
		Color myChildColumn2BackColor=Color.Silver;
		bool  myHeaderVisibled=true;
		bool  myColumnVisibled=true;
		bool  myChildHeaderVisibled=true;
		bool  myChildColumnVisibled=true;
		bool  myIDColumnVisibled=false;
		int   myDefaultColumnWidth=50;
		int   myDefaultRowHeight=20;
		bool  myDataAutoSizeColumns=false;
		ArrayList alColumnsProperty=new ArrayList();
		#endregion

		#region 属性
		public FarPoint.Win.Spread.FpSpread fpSpread
		{
			get
			{
				return this.fpSpread1;
			}
		}
		public FarPoint.Win.Spread.SheetView  fpCurrentSheetView
		{
			get
			{
				return this.fpSpread1.ActiveSheet;
			}
		}
		#endregion

		#region 方法
		public void KeysEvent(System.Windows.Forms.Keys key) {
			switch (key) {
				case Keys.Down:
					//向下箭头,行向下移
					//if (this.fpSpread1_Sheet1.ActiveRowIndex < 0) 
						this.fpSpread1_Sheet1.ActiveRowIndex++;
					break;
				case Keys.Up:
					//向上箭头,行向上移
					//if (this.fpSpread1_Sheet1.ActiveRowIndex > 0) 
						this.fpSpread1_Sheet1.ActiveRowIndex--;
					break;
				case Keys.Enter:
					break;
			}
		}
		#endregion

		#region FpInterface 成员
		public void init()
		{
			// TODO:  添加 FpTreeView.init 实现
		}

		public void RefreshSpread()
		{
		}
		public System.Data.DataSet fpDateSet
		{
			get
			{
				// TODO:  添加 FpTreeView.fpDateSet getter 实现
				return myDataSet;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpDateSet setter 实现
				myDataSet=value;
			}
		}
		public System.Drawing.Color fpBackColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpBackColor getter 实现
				return this.myBackColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpBackColor setter 实现
				this.myBackColor=value;
				this.fpSpread1.BackColor=this.myBackColor;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].DefaultStyle.BackColor=this.myBackColor;
			}
		}

		public System.Drawing.Color fpForeColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpForeColor getter 实现
				return this.myForeColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpForeColor setter 实现
				this.myForeColor=value;
				this.fpSpread1.ForeColor=this.myForeColor;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].DefaultStyle.ForeColor=this.myForeColor;
			}
		}

		public System.Drawing.Color fpHeaderBackColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpHeaderBackColor getter 实现
				return this.myHeaderBackColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpHeaderBackColor setter 实现
				this.myHeaderBackColor=value;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].RowHeader.DefaultStyle.BackColor =this.myHeaderBackColor;

			}
		}

		public System.Drawing.Color fpHeaderForeColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpHeaderForeColor getter 实现
				return this.myHeaderForeColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpHeaderForeColor setter 实现
				this.myHeaderForeColor=value;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].RowHeader.DefaultStyle.ForeColor=this.myHeaderForeColor;

			}
		}

		public System.Drawing.Color fpColumnBackColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpColumnBackColor getter 实现
				return this.myColumnBackColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpColumnBackColor setter 实现
				this.myColumnBackColor=value;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].ColumnHeader.DefaultStyle.BackColor=this.myColumnBackColor;

			}
		}

		public System.Drawing.Color fpColumnForeColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpColumnForeColor getter 实现
				return this.myColumnForeColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpColumnForeColor setter 实现
				this.myColumnForeColor=value;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].ColumnHeader.DefaultStyle.ForeColor=this.myColumnForeColor;
			}
		}

		public System.Drawing.Color fpChildHeader1BackColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildHeader1BackColor getter 实现
				return this.myChildHeader1BackColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildHeader1BackColor setter 实现
				this.myChildHeader1BackColor=value;
			}
		}

		public System.Drawing.Color fpChildHeader1ForeColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildHeader1ForeColor getter 实现
				return this.myChildColumn1ForeColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildHeader1ForeColor setter 实现
				this.myChildHeader1ForeColor=value;
			}
		}

		public System.Drawing.Color fpChildColumn1BackColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildColumn1BackColor getter 实现
				return this.myChildColumn1BackColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildColumn1BackColor setter 实现
				this.myChildColumn1BackColor=value;
			}
		}

		public System.Drawing.Color fpChildColumn1ForeColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildColumn1ForeColor getter 实现
				return this.myChildColumn1ForeColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildColumn1ForeColor setter 实现
				this.myChildColumn1ForeColor=value;
			}
		}

		public System.Drawing.Color fpChildHeader2BackColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildHeader2BackColor getter 实现
				return this.myChildHeader2BackColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildHeader2BackColor setter 实现
				this.myChildHeader2BackColor=value;
			}
		}

		public System.Drawing.Color fpChildHeader2ForeColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildHeader2ForeColor getter 实现
				return this.myChildHeader2ForeColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildHeader2ForeColor setter 实现
				this.myChildHeader2ForeColor=value;
			}
		}

		public System.Drawing.Color fpChildColumn2BackColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildColumn2BackColor getter 实现
				return this.myChildColumn2BackColor ;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildColumn2BackColor setter 实现
				this.myChildColumn2BackColor=value;
			}
		}

		public System.Drawing.Color fpChildColumn2ForeColor
		{
			get
			{
				// TODO:  添加 FpTreeView.fpChildColumn2ForeColor getter 实现
				return this.myChildColumn2ForeColor;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildColumn2ForeColor setter 实现
				this.myChildColumn2ForeColor=value;
			}
		}

		public bool fpChildHeaderVisible
		{
			get
			{
				return this.myChildHeaderVisibled; 
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildHeaderVisible setter 实现
				this.myChildHeaderVisibled=value;
			}
		}

		public bool fpChildColumnVisible
		{
			get
			{
				return this.myChildColumnVisibled;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpChildColumnVisible setter 实现
				this.myChildColumnVisibled=value;
			}
		}

		public bool fpHeaderVisible
		{
			get
			{
				return this.myHeaderVisibled;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpHeaderVisible setter 实现
				this.myHeaderVisibled=value;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].RowHeaderVisible=this.myHeaderVisibled;
			}
		}

		public bool fpColumnVisible
		{
			get
			{
				return this.myColumnVisibled;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpColumnVisible setter 实现
				this.myColumnVisibled=value;
				for(int i=0;i<this.fpSpread1.Sheets.Count;i++)
					this.fpSpread1.Sheets[i].ColumnHeader.Visible=this.myColumnVisibled;
			}
		}

		public bool fpIDColumnVisible
		{
			get
			{
				return this.myIDColumnVisibled;
			}
			set
			{
				// TODO:  添加 FpTreeView.fpIDColumnVisible setter 实现
				this.myIDColumnVisibled=value;
			}
		}
		public int DefaultColumnWidth
		{
			get
			{
				return this.myDefaultColumnWidth;
			}
			set
			{
				this.myDefaultColumnWidth=value;
			}
		}
		public int DefaultRowHeight
		{
			get
			{
				return this.myDefaultRowHeight;
			}
			set
			{
				this.myDefaultRowHeight=value;
			}
		}
		public bool DataAutoSizeColumns
		{
			get
			{
				return this.myDataAutoSizeColumns;
			}
			set
			{
				this.myDataAutoSizeColumns=value;
			}
		}
		public ArrayList ColumnsProperty
		{
			get
			{
				return this.alColumnsProperty;
			}
			set
			{
				this.alColumnsProperty=value;
			}
		}
		protected ArrayList alChild1ColumnsProperty;
		public ArrayList Child1ColumnsProperty
		{
			get
			{
				return this.alChild1ColumnsProperty;
			}
			set
			{
				this.alChild1ColumnsProperty=value;
			}
		}
		protected ArrayList alChild2ColumnsProperty;
		public ArrayList Child2ColumnsProperty
		{
			get
			{
				return this.alChild2ColumnsProperty;
			}
			set
			{
				this.alChild2ColumnsProperty=value;
			}
		}
		#endregion

		public void Export()
		{
			// TODO:  添加 ucMedicineCompare.Export 实现
			string Result ="";
			try
			{
				bool ret = false;
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "Excel |.xls";
				saveFileDialog1.Title = "导出数据";
				try
				{
					saveFileDialog1.FileName =fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex,1].Text;
				}
				catch(Exception )
				{
					saveFileDialog1.FileName ="";
				}
				if(saveFileDialog1.ShowDialog()==DialogResult.OK)
				{
					if(saveFileDialog1.FileName != "")
					{
						//以Excel 的形式导出数据
						ret = fpSpread1.SaveExcel(saveFileDialog1.FileName,FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
					}
					if(ret)
					{
						MessageBox.Show("成功导出数据");
					}
				}
				else
				{
					MessageBox.Show("操作被取消");
				}
			}
			catch(Exception ee)
			{
				Result = ee.Message;
				MessageBox.Show(Result);
			}
		}

		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e) {
		
		}

	}

	/// <summary>
	/// 列属性类
	/// </summary>
	public class ColumnProperty
	{	
		public string ID="";
		public string Name="";
		public int Width=-1;
		public int Height=-1;
		public Color BackColor=Color.White;
		public Color ForeColor=Color.Black;
		public Color SelectColor=Color.Blue;
		public bool Visible=true;
		public bool Locked=false;
		public Font Font=new Font("Veranda", 8, FontStyle.Regular);
	}
}
