using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// ucSignManager 的摘要说明。
	/// </summary>
	public class ucSignManager : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFilter;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucSignManager()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel1.Controls.Add(this.fpSpread1);
			this.panel1.Controls.Add(this.txtFilter);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(520, 456);
			this.panel1.TabIndex = 0;
			// 
			// fpSpread1
			// 
			this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.fpSpread1.Location = new System.Drawing.Point(0, 44);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(520, 408);
			this.fpSpread1.TabIndex = 2;
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// txtFilter
			// 
			this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFilter.Location = new System.Drawing.Point(141, 14);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(138, 21);
			this.txtFilter.TabIndex = 1;
			this.txtFilter.Text = "";
			this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "按员工代码查找：";
			// 
			// ucSignManager
			// 
			this.Controls.Add(this.panel1);
			this.Name = "ucSignManager";
			this.Size = new System.Drawing.Size(520, 456);
			this.Load += new System.EventHandler(this.ucPermissionManager_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ucPermissionManager_Load(object sender, System.EventArgs e)
		{
			this.init();	
			Retrieve();

		}


		private DataSet ds = new DataSet();
		private DataView dv ;
		/// <summary>
		/// 初始化控件
		/// </summary>
		private void init()
		{
			//初始化DataTable
			DataTable table = new DataTable("Table");

			DataColumn dataColumn1 = new DataColumn("员工编码");
			dataColumn1.DataType = typeof(System.String);
			table.Columns.Add(dataColumn1);

			DataColumn dataColumn2 = new DataColumn("姓名");
			dataColumn2.DataType = typeof(System.String);
			table.Columns.Add(dataColumn2);
			
			DataColumn dataColumn3 = new DataColumn("签名");
			dataColumn3.DataType = typeof(System.String);
			table.Columns.Add(dataColumn3);
			
			DataColumn dataColumn4 = new DataColumn("加密字符串");
			dataColumn4.DataType = typeof(System.String);
			table.Columns.Add(dataColumn4);

			DataColumn dataColumn9 = new DataColumn("操作员");
			dataColumn9.DataType = typeof(System.String);
			table.Columns.Add(dataColumn9);

			DataColumn dataColumn10 = new DataColumn("操作日期");
			dataColumn10.DataType = typeof(System.DateTime);
			table.Columns.Add(dataColumn10);

			//初始化dataSet
			ds.Tables.Add(table);
			
			
			dv = new DataView(ds.Tables[0]);
			this.fpSpread1.Sheets[0].DataSource = dv;
			this.fpSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this._SetFP();
		}
		
		protected void _SetFP()
		{
			this.fpSpread1.Sheets[0].Columns[0].Width = 80;
			this.fpSpread1.Sheets[0].Columns[1].Width = 100;
			this.fpSpread1.Sheets[0].Columns[2].Width = 100;
			this.fpSpread1.Sheets[0].Columns[3].Width = 100;
			this.fpSpread1.Sheets[0].Columns[4].Width = 100;
			this.fpSpread1.Sheets[0].Columns[5].Width = 100;
//			this.fpSpread1.Sheets[0].Columns[6].Width = 100;
//			this.fpSpread1.Sheets[0].Columns[7].Width = 100;
//			this.fpSpread1.Sheets[0].Columns[8].Width = 60;
//			this.fpSpread1.Sheets[0].Columns[9].Width = 100;
		}
		#region IToolBar 成员

		public ToolBarButton PreButton
		{
			get
			{
				// TODO:  添加 ucSignManager.PreButton getter 实现
				return null;
			}
		}

		public int Search()
		{
			// TODO:  添加 ucSignManager.Search 实现
			return 0;
		}

		public ToolBarButton SaveButton
		{
			get
			{
				// TODO:  添加 ucSignManager.SaveButton getter 实现
				return null;
			}
		}

		public ToolBarButton SearchButton
		{
			get
			{
				// TODO:  添加 ucSignManager.SearchButton getter 实现
				return null;
			}
		}
		/// <summary>
		/// 修改
		/// </summary>
		/// <returns></returns>
		public int Auditing()
		{
			// TODO:  添加 ucSignManager.Auditing 实现
			if(this.fpSpread1.Sheets[0].ActiveRowIndex<0) 
			{
				MessageBox.Show("请选择要修改的行！");
				return 0;
			}
			int i = this.fpSpread1.Sheets[0].ActiveRowIndex;
			Neusoft.FrameWork.Models.NeuObject obj =new Neusoft.FrameWork.Models.NeuObject();
			obj.ID = this.fpSpread1.Sheets[0].Cells[i,0].Text;
			obj.Name = this.fpSpread1.Sheets[0].Cells[i,1].Text;
			obj.Memo = this.fpSpread1.Sheets[0].Cells[i,2].Text;
			obj.User01  = this.fpSpread1.Sheets[0].Cells[i,3].Text;
			obj.User02  = this.fpSpread1.Sheets[0].Cells[i,4].Text;
			obj.User03  = this.fpSpread1.Sheets[0].Cells[i,5].Text;
			//byte[] img =
//			System.Drawing.Image image ;
//			System.IO.Stream writer;
//			image.Save(writer);
//			System.Windows.Forms.PictureBox p;
//			//writer.Write(buffer,0,buffer.);
//			System.IO.StreamReader reader;
			//reader.Read(buffer,0,length);


            byte[] byteimg = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSignBackGround(obj.ID);
			ucSignInput uc = new ucSignInput(obj, byteimg);
			Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text ="修改";
			if(Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc)==DialogResult.OK)
			{
				this.Retrieve();
			}
			return 0;
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <returns></returns>
		public int Del()
		{
			// TODO:  添加 ucSignManager.Del 实现
			if(this.fpSpread1.Sheets[0].ActiveRowIndex<0) 
			{
				MessageBox.Show("请选择要修改的行！");
				return 0;
			}
			int i = this.fpSpread1.Sheets[0].ActiveRowIndex;
			Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();

            if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteSign(this.fpSpread1.Sheets[0].Cells[i, 0].Text) == -1)
			{
				Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return -1;
			}
            Neusoft.HISFC.BizProcess.Factory.Function.Commit();
			MessageBox.Show("删除成功！");
			this.fpSpread1.Sheets[0].Rows.Remove(i,1);
			return 0;
		}

		public ToolBarButton AddButton
		{
			get
			{
				// TODO:  添加 ucSignManager.AddButton getter 实现
				return null;
			}
		}

		public int Print()
		{
			// TODO:  添加 ucSignManager.Print 实现
			return 0;
		}

		public int Pre()
		{
			// TODO:  添加 ucSignManager.Pre 实现
			this.fpSpread1.Sheets[0].ActiveRowIndex--;
			this.fpSpread1.Sheets[0].AddSelection(this.fpSpread1.Sheets[0].ActiveRowIndex,0,1,1);
			return 0;
		}

		public ToolBarButton NextButton
		{
			get
			{
				// TODO:  添加 ucSignManager.NextButton getter 实现
				return null;
			}
		}

		public int Help()
		{
			// TODO:  添加 ucSignManager.Help 实现
			return 0;
		}

		public int Next()
		{
			// TODO:  添加 ucSignManager.Next 实现
			this.fpSpread1.Sheets[0].ActiveRowIndex++;
			this.fpSpread1.Sheets[0].AddSelection(this.fpSpread1.Sheets[0].ActiveRowIndex,0,1,1);
			return 0;
		}
		/// <summary>
		/// 刷新列表
		/// </summary>
		/// <returns></returns>
		public int Retrieve()
		{
			// TODO:  添加 ucSignManager.Retrieve 实现
			ds.Tables[0].Rows.Clear();
            ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSignList();
			foreach(Neusoft.FrameWork.Models.NeuObject obj in al)
			{
				DataRow dr = ds.Tables[0].NewRow();
				
				dr["员工编码"] = obj.ID;
				dr["姓名"] = obj.Name;
				dr["签名"] = obj.Memo;
				dr["加密字符串"] = obj.User01;
				dr["操作员"] = obj.User02;
				dr["操作日期"] = DateTime.Parse(obj.User03);
				ds.Tables[0].Rows.Add(dr);
			}		
			this._SetFP();
			return 0;
		}
		/// <summary>
		/// 添加新人员权限
		/// </summary>
		/// <returns></returns>
		public int Add()
		{
			// TODO:  添加 ucSignManager.Add 实现
            //Neusoft.HISFC.Models.Medical.Permission obj =new Neusoft.HISFC.Models.Medical.Permission();
            //ucSignInput uc = new ucSignInput(obj, null);
            //Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text ="添加";
            //if(Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc)==DialogResult.OK)
            //{
            //    this.Retrieve();
            //}
			return 0;
		}

		public ToolBarButton RetrieveButton
		{
			get
			{
				// TODO:  添加 ucSignManager.RetrieveButton getter 实现
				return null;
			}
		}

		public ToolBarButton DelButton
		{
			get
			{
				// TODO:  添加 ucSignManager.DelButton getter 实现
				return null;
			}
		}

		public ToolBarButton PrintButton
		{
			get
			{
				// TODO:  添加 ucSignManager.PrintButton getter 实现
				return null;
			}
		}
		/// <summary>
		/// 退出
		/// </summary>
		/// <returns></returns>
		public int Exit()
		{
			// TODO:  添加 ucSignManager.Exit 实现
			this.FindForm().Close();
			return 0;
		}

		public int Save()
		{
			// TODO:  添加 ucSignManager.Save 实现
			return 0;
		}

		private void txtFilter_TextChanged(object sender, System.EventArgs e)
		{
			dv.RowFilter = "员工编码 like '%" +this.txtFilter.Text.Trim()+"%'";
			this._SetFP();
		}

		public ToolBarButton AuditingButton
		{
			get
			{
				// TODO:  添加 ucSignManager.AuditingButton getter 实现
				return null;
			}
		}

		#endregion
	}
}
