using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
namespace neusoft.neuFC.Interface.Controls
{
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
	/// <summary>
	/// FpTreeView 的摘要说明。
	/// 显示有TreeView的FP组件
	/// </summary>
	public class BaseFp :System.Windows.Forms.UserControl,neusoft.neuFC.Interface.FpInterface
	{
		
		public FarPoint.Win.Spread.FpSpread fpSpread1;
		public FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public BaseFp(System.ComponentModel.IContainer container)
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public BaseFp()
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			// 
			// fpSpread1
			// 
			this.fpSpread1.Location = new System.Drawing.Point(17, 17);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.Add(this.fpSpread1_Sheet1);
			this.fpSpread1.TabIndex = 0;
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();

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
		#region FpInterface 成员
		public void init()
		{
			// TODO:  添加 FpTreeView.init 实现
		}

		public void Refresh()
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
		#endregion

	}
}
