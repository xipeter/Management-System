using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Neusoft.NFC.Interface.Controls
{
	public class FpMultiColumn : Neusoft.NFC.Interface.Controls.BaseFp
	{
		private System.ComponentModel.IContainer components = null;

		public FpMultiColumn()
		{
			// 该调用是 Windows 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}
		public FarPoint.Win.Spread.SheetView FpSheet
		{
			get
			{
				return this.fpSpread1_Sheet1;
			}
		}
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		public System.Resources.ResourceManager	resources = new System.Resources.ResourceManager(typeof(FpMultiColumn));	 
		#region 设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			// 
			// fpSpread1
			// 
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Size = new System.Drawing.Size(368, 328);
			// 
			// FpMultiColumn
			// 
			this.Name = "FpMultiColumn";
			this.Size = new System.Drawing.Size(368, 328);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();

		}
		#endregion
		private int iColumnNum=1;
		private int iMaxRows=0;
		private int iBlankColumnNum=0;
		private int iMinRows=20;
	
		public bool BandingDataSet=false;
		public ArrayList alData;
		#region "方法"
		public new void  init()
		{
			this.fpSpread1_Sheet1.DefaultStyle.CellType=new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpSpread1.SelectionChanged+=new FarPoint.Win.Spread.SelectionChangedEventHandler(fpSpread1_SelectionChanged);
			if(this.BandingDataSet)
			{
				this.fpSpread1.DataSource=this.fpDateSet;
				this.fpSpread1.DataMember="Table";
			}
			else
			{
				try
				{
					initSpread();
				}
				catch{}
			}
			return;
		}
		public new void Refresh()
		{
			this.initSpread();
			return;
		}

//		public System.Data.DataTable CreateTable(string[]  Columns)
//		{
//			
//				System.Data.DataSet myDataSet=new System.Data.DataSet();
//				myDataSet.EnforceConstraints=false;//是否遵循约束规则
//			
//				//定义类型
//				System.Type dtStr=System.Type.GetType("System.String");
//				System.Type dtInt=System.Type.GetType("System.Int32");
//
//				//定义表********************************************************
//				//Main Table
//				System.Data.DataTable dtMain;	
//				dtMain=myDataSet.Tables.Add("Table");
//				for(int i=0;i<Columns.GetUpperBound(0);i++)
//					dtMain.Columns.AddRange(new System.Data.DataColumn[]{new DataColumn(Columns[0],dtStr)});
//
//				return dtMain;
//			
//		}
//		public System.Data.DataSet CreateDataSet(System.Data.DataTable dtMain,ArrayList al)
//		{
//			for(int i=0;i<al.Count ;i++)
//			{
//				dtMain.Rows.Add((object[])al[i]);
//			}
//			return 
//		}
		#endregion
		#region "属性"
		/// <summary>
		/// 最小行数 default=20;
		/// </summary>
		public int MinRows
		{
			get
			{
				return iMinRows;
			}
			set
			{
				iMinRows=value;
			}
		}
		/// <summary>
		/// 列数
		/// </summary>
		public int ColumnNum
		{
			get
			{
				return iColumnNum;
			}
			set
			{
				iColumnNum=value;
			}
		}
		/// <summary>
		/// 最大行数
		/// </summary>
		public int MaxRows
		{
			get
			{
				return iMaxRows;
			}
			set
			{
				iMaxRows=value;
			}
		}
		/// <summary>
		/// 空白间隔列
		/// </summary>
		public int BlankColumnNum
		{
			get
			{
				return iBlankColumnNum;
			}
			set
			{
				iBlankColumnNum=value;
			}
		}
//		/// <summary>
//		/// 是否变选择行的颜色
//		/// </summary>
//		public bool IsShowRowSelected
//		{
//			get
//			{
//				return bIsShowRowSelected;
//			}
//			set
//			{
//				IsShowRowSelected=value;
//			}
//		}
		#endregion
		#region"函数"
		private void initSpread()
		{
			this.fpSpread1_Sheet1.RowCount=0;
			int RowCount;
			
			//获得每列的行数
			if(MaxRows>0) 
			{
				RowCount=MaxRows;
				this.ColumnNum=this.fpDateSet.Tables[0].Rows.Count/RowCount+1;
			}
			else
			{
				if(this.ColumnNum==1)
					RowCount=this.fpDateSet.Tables[0].Rows.Count;
				else
					RowCount=this.fpDateSet.Tables[0].Rows.Count /this.ColumnNum +1;
			}
			if(RowCount<=this.MinRows ) RowCount=this.MinRows;

			this.fpSpread1_Sheet1.RowCount=RowCount;
			//添加列，行
			int c=0;
			for(int j=0;j<this.ColumnNum;j++)
			{
				if(j*RowCount>this.fpDateSet.Tables[0].Rows.Count) break;
				for(int k=0;k<this.fpDateSet.Tables[0].Columns.Count;k++)
				{
					this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Label=this.fpDateSet.Tables[0].Columns[k].Caption;
					try
					{
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Width=((Neusoft.NFC.Interface.Controls.ColumnProperty)this.ColumnsProperty[k]).Width;
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Locked=((Neusoft.NFC.Interface.Controls.ColumnProperty)this.ColumnsProperty[k]).Locked;
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].BackColor =((Neusoft.NFC.Interface.Controls.ColumnProperty)this.ColumnsProperty[k]).BackColor;
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].ForeColor =((Neusoft.NFC.Interface.Controls.ColumnProperty)this.ColumnsProperty[k]).ForeColor ;
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Font =((Neusoft.NFC.Interface.Controls.ColumnProperty)this.ColumnsProperty[k]).Font ;
					}
					catch
					{
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Width=this.DefaultColumnWidth;
						//this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Locked=
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].BackColor =this.fpBackColor;
						this.fpSpread1_Sheet1.ColumnHeader.Columns[c].ForeColor =this.fpForeColor ;
						//this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Font=this.
					}
					try
					{
						for(int i=0;i<RowCount;i++)
						{
							this.fpSpread1_Sheet1.Cells[i,c].Text=this.fpDateSet.Tables[0].Rows[j*RowCount+i][k].ToString();
							try
							{
								this.fpSpread1_Sheet1.Rows[i].Tag=this.alData[i];
							}
							catch{}
						}
					}
					catch
					{
						
					}
					c++;
				}
				for(int m=0;m<this.BlankColumnNum;m++)
				{
					if(j+1>=this.ColumnNum) break;
					this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Label=" ";
					this.fpSpread1_Sheet1.ColumnHeader.Columns[c].Locked=true;
					c++;
				}
			}
			this.fpSpread1_Sheet1.ColumnCount=c;

		}
		#endregion
		#region 事件

		#endregion

		private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
		{
//			if(this.bIsShowRowSelected)
//			{
//				for(int i=0;i<this.fpSpread1_Sheet1.Rows.Count-1;i++)
//				{
//					this.fpSpread1_Sheet1.Rows[i].BackColor=this.fpBackColor;
//				}
//				this.fpSpread1_Sheet1.Rows[fpSpread1_Sheet1.ActiveRowIndex].BackColor=Color.Blue;
//			}
		}
	}
}

