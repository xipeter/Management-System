using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// ucMoudulTypeList 的摘要说明。
	/// </summary>
	public class ucModTypeList : System.Windows.Forms.UserControl
	{
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucModTypeList()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			init();
			this.Retrieve();
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
			this.fpSpread1.Size = new System.Drawing.Size(424, 352);
			this.fpSpread1.TabIndex = 0;
			this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// ucModTypeList
			// 
			this.Controls.Add(this.fpSpread1);
			this.Name = "ucModTypeList";
			this.Size = new System.Drawing.Size(424, 352);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		DataSet dataSet = new DataSet();
		protected void init()
		{
			
			DataTable table = new DataTable("Table1");
			
			DataColumn column1 = new DataColumn("类型");
			column1.DataType = typeof(System.String);
			table.Columns.Add(column1);

			DataColumn column2 = new DataColumn("名称");
			column2.DataType =typeof(System.String);
			table.Columns.Add(column2);

			DataColumn column3 = new DataColumn("参数");
			column3.DataType = typeof(System.String);
			table.Columns.Add(column3);

			DataColumn column4 = new DataColumn("IP");
			column4.DataType = typeof(System.String);
			table.Columns.Add(column4);
			
			DataColumn column5 = new DataColumn("Http");
			column5.DataType =  typeof(System.String);
			table.Columns.Add(column5);

			DataColumn column6 = new DataColumn("数据路径");
			column6.DataType =  typeof(System.String);
			table.Columns.Add(column6);

			DataColumn column7= new DataColumn("模板路径");
			column7.DataType =  typeof(System.String);
			table.Columns.Add(column7);

			DataColumn column8 = new DataColumn("是否数据库");
			column8.DataType =  typeof(System.Boolean );
			table.Columns.Add(column8);

			DataColumn column9 = new DataColumn("操作员");
			column9.DataType =  typeof(System.String);
			table.Columns.Add(column9);

			DataColumn column10 = new DataColumn("操作日期");
			column10.DataType =  typeof(System.String);
			table.Columns.Add(column10);

			dataSet.Tables.Add(table);

		}
		#region IToolBar 成员

		public ToolBarButton PreButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.PreButton getter 实现
				return null;
			}
		}

		public int Search()
		{
			// TODO:  添加 ucMoudulTypeList.Search 实现
			return 0;
		}

		public ToolBarButton SaveButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.SaveButton getter 实现
				return null;
			}
		}

		public ToolBarButton SearchButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.SearchButton getter 实现
				return null;
			}
		}

		public int Auditing()
		{
			// TODO:  添加 ucMoudulTypeList.Auditing 实现
			return 0;
		}

		public int Del()
		{
			// TODO:  添加 ucMoudulTypeList.Del 实现
			return 0;
		}

		public ToolBarButton AddButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.AddButton getter 实现
				return null;
			}
		}

		public int Print()
		{
			// TODO:  添加 ucMoudulTypeList.Print 实现
			return 0;
		}

		public int Pre()
		{
			// TODO:  添加 ucMoudulTypeList.Pre 实现
			return 0;
		}

		public ToolBarButton NextButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.NextButton getter 实现
				return null;
			}
		}

		public int Help()
		{
			// TODO:  添加 ucMoudulTypeList.Help 实现
			return 0;
		}

		public int Next()
		{
			// TODO:  添加 ucMoudulTypeList.Next 实现
			return 0;
		}
		ArrayList al= null;
		/// <summary>
		/// 查询
		/// </summary>
		/// <returns></returns>
		public int Retrieve()
		{
            
			// TODO:  添加 ucMoudulTypeList.Retrieve 实现
            al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetParamList();
			dataSet.Tables[0].Rows.Clear();
			if(al == null) 
			{
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return -1;
			}
			foreach(Neusoft.HISFC.Models.File.DataFileParam obj in al)
			{
				DataRow row = dataSet.Tables[0].NewRow();
				row[0] = (obj.Type);
				row[1] = obj.Memo;
				row[2] = obj.ID;
				row[3]=obj.IP;
				row[4]=obj.Http;
				row[5]=obj.Folders;
				row[6]=obj.ModualFolders;
				row[7] =obj.IsInDB;
				row[8]=obj.User01;
				row[9]=obj.User02;
				dataSet.Tables[0].Rows.Add(row);
			}
			this.fpSpread1.Sheets[0].DataSource= dataSet;
			this.fpSpread1.Sheets[0].Columns[0].Width =40;
			this.fpSpread1.Sheets[0].Columns[1].Width =60;
			this.fpSpread1.Sheets[0].Columns[7].Width =50;
			this.fpSpread1.Sheets[0].Columns[5].Width =100;
			this.fpSpread1.Sheets[0].Columns[6].Width =100;
			return 0;
		}

		public int Add()
		{
			// TODO:  添加 ucMoudulTypeList.Add 实现
			try
			{
				ucModTypeSetting u = new ucModTypeSetting();
				Neusoft.HISFC.Models.File.DataFileParam o=new Neusoft.HISFC.Models.File.DataFileParam();
				u.DataFileParam = o;
				Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(u);
				this.Retrieve();
			}
			catch{}
			return 0;
		}

		public ToolBarButton RetrieveButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.RetrieveButton getter 实现
				return null;
			}
		}

		public ToolBarButton DelButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.DelButton getter 实现
				return null;
			}
		}

		public ToolBarButton PrintButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.PrintButton getter 实现
				return null;
			}
		}

		public int Exit()
		{
			// TODO:  添加 ucMoudulTypeList.Exit 实现
			this.ParentForm.Close();
			return 0;
		}

		public int Save()
		{
			// TODO:  添加 ucMoudulTypeList.Save 实现
			return 0;
		}

		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			try
			{
				ucModTypeSetting u = new ucModTypeSetting();
				u.DataFileParam = al[this.fpSpread1_Sheet1.ActiveRowIndex] as Neusoft.HISFC.Models.File.DataFileParam;
				Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(u);
				this.Retrieve();
			}
			catch{}
		}

		public ToolBarButton AuditingButton
		{
			get
			{
				// TODO:  添加 ucMoudulTypeList.AuditingButton getter 实现
				return null;
			}
		}

		#endregion
	}
}
