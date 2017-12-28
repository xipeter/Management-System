using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// ucQCScoreSetManager 的摘要说明。
	/// </summary>
	public class ucQCScoreSetManager : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFilter;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Button btDel;
        private Button btAdd;
        private Button btModify;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucQCScoreSetManager()
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btModify = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btModify);
            this.panel1.Controls.Add(this.btDel);
            this.panel1.Controls.Add(this.btAdd);
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
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.Location = new System.Drawing.Point(0, 44);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(520, 408);
            this.fpSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtFilter
            // 
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Location = new System.Drawing.Point(112, 14);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(138, 21);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "按条件编码查找：";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(256, 14);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 3;
            this.btAdd.Text = "添加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDel
            // 
            this.btDel.Location = new System.Drawing.Point(337, 15);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(75, 23);
            this.btDel.TabIndex = 4;
            this.btDel.Text = "删除";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btModify
            // 
            this.btModify.Location = new System.Drawing.Point(419, 16);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(75, 23);
            this.btModify.TabIndex = 5;
            this.btModify.Text = "修改";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // ucQCScoreSetManager
            // 
            this.Controls.Add(this.panel1);
            this.Name = "ucQCScoreSetManager";
            this.Size = new System.Drawing.Size(520, 456);
            this.Load += new System.EventHandler(this.ucQCScoreSetManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ucQCScoreSetManager_Load(object sender, System.EventArgs e)
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

			DataColumn dataColumn1 = new DataColumn("条件编码");
			dataColumn1.DataType = typeof(System.String);
			table.Columns.Add(dataColumn1);

			DataColumn dataColumn2 = new DataColumn("质控名称");
			dataColumn2.DataType = typeof(System.String);
			table.Columns.Add(dataColumn2);
			
			DataColumn dataColumn3 = new DataColumn("项目类别");
			dataColumn3.DataType = typeof(System.String);
			table.Columns.Add(dataColumn3);
			
			DataColumn dataColumn4 = new DataColumn("备注");
			dataColumn4.DataType = typeof(System.String);
			table.Columns.Add(dataColumn4);

			DataColumn dataColumn5 = new DataColumn("扣分标准");
			dataColumn4.DataType = typeof(System.String);
			table.Columns.Add(dataColumn5);

			DataColumn dataColumn6 = new DataColumn("项目总分值");
			dataColumn4.DataType = typeof(System.String);
			table.Columns.Add(dataColumn6);

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
			this.fpSpread1.Sheets[0].Columns[1].Width = 300;
			this.fpSpread1.Sheets[0].Columns[2].Width = 100;
			this.fpSpread1.Sheets[0].Columns[3].Width = 140;
			this.fpSpread1.Sheets[0].Columns[4].Width = 100;
			this.fpSpread1.Sheets[0].Columns[5].Width = 100;
			this.fpSpread1.Sheets[0].Columns[6].Width = 100;
			this.fpSpread1.Sheets[0].Columns[7].Width = 100;
			//			this.fpSpread1.Sheets[0].Columns[8].Width = 60;
			//			this.fpSpread1.Sheets[0].Columns[9].Width = 100;
		}
		#region IToolBar 成员

		public ToolBarButton PreButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.PreButton getter 实现
				return null;
			}
		}

		public int Search()
		{
			// TODO:  添加 ucQCScoreSetManager.Search 实现
			return 0;
		}

		public ToolBarButton SaveButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.SaveButton getter 实现
				return null;
			}
		}

		public ToolBarButton SearchButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.SearchButton getter 实现
				return null;
			}
		}
		/// <summary>
		/// 修改
		/// </summary>
		/// <returns></returns>
		public int Auditing()
		{
			// TODO:  添加 ucQCScoreSetManager.Auditing 实现
			if(this.fpSpread1.Sheets[0].ActiveRowIndex<0) 
			{
				MessageBox.Show("请选择要修改的行！");
				return 0;
			}
			int i = this.fpSpread1.Sheets[0].ActiveRowIndex;
			Neusoft.HISFC.Models.EPR.QCScore obj =new Neusoft.HISFC.Models.EPR.QCScore();
			obj.ID = this.fpSpread1.Sheets[0].Cells[i,0].Text;
			obj.Name = this.fpSpread1.Sheets[0].Cells[i,1].Text;
			obj.Type = this.fpSpread1.Sheets[0].Cells[i,2].Text;
			obj.Memo = this.fpSpread1.Sheets[0].Cells[i,3].Text;
			obj.MiniScore  = this.fpSpread1.Sheets[0].Cells[i,4].Text;
			obj.TotalScore  = this.fpSpread1.Sheets[0].Cells[i,5].Text;
//			obj.User02  = this.fpSpread1.Sheets[0].Cells[i,4].Text;
//			obj.User03  = this.fpSpread1.Sheets[0].Cells[i,5].Text;
			//byte[] img =
			//			System.Drawing.Image image ;
			//			System.IO.Stream writer;
			//			image.Save(writer);
			//			System.Windows.Forms.PictureBox p;
			//			//writer.Write(buffer,0,buffer.);
			//			System.IO.StreamReader reader;
			//reader.Read(buffer,0,length);
			

//			byte[] byteimg = manager.GetQCScoreSetBackGround(obj.ID);
			ucQCScoreSetInput uc = new ucQCScoreSetInput(obj);
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
			// TODO:  添加 ucQCScoreSetManager.Del 实现
			if(this.fpSpread1.Sheets[0].ActiveRowIndex<0) 
			{
				MessageBox.Show("请选择要修改的行！");
				return 0;
			}
			int i = this.fpSpread1.Sheets[0].ActiveRowIndex;
			
			Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
			
			if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteQCScoreSet( this.fpSpread1.Sheets[0].Cells[i,0].Text)==-1)
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
				// TODO:  添加 ucQCScoreSetManager.AddButton getter 实现
				return null;
			}
		}

		public int Print()
		{
			// TODO:  添加 ucQCScoreSetManager.Print 实现
			return 0;
		}

		public int Pre()
		{
			// TODO:  添加 ucQCScoreSetManager.Pre 实现
			this.fpSpread1.Sheets[0].ActiveRowIndex--;
			this.fpSpread1.Sheets[0].AddSelection(this.fpSpread1.Sheets[0].ActiveRowIndex,0,1,1);
			return 0;
		}

		public ToolBarButton NextButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.NextButton getter 实现
				return null;
			}
		}

		public int Help()
		{
			// TODO:  添加 ucQCScoreSetManager.Help 实现
			return 0;
		}

		public int Next()
		{
			// TODO:  添加 ucQCScoreSetManager.Next 实现
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
			// TODO:  添加 ucQCScoreSetManager.Retrieve 实现
			ds.Tables[0].Rows.Clear();
            ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetQCScoreSetList();
			foreach(Neusoft.HISFC.Models.EPR.QCScore obj in al)
			{
				DataRow dr = ds.Tables[0].NewRow();
				
				dr["条件编码"] = obj.ID;
				dr["质控名称"] = obj.Name;
				dr["项目类别"] = obj.Type;
				dr["备注"] = obj.Memo;
				dr["扣分标准"] = obj.MiniScore;
				dr["项目总分值"] = obj.TotalScore;
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
			// TODO:  添加 ucQCScoreSetManager.Add 实现
			Neusoft.HISFC.Models.EPR.QCScore obj =new Neusoft.HISFC.Models.EPR.QCScore();
			ucQCScoreSetInput uc = new ucQCScoreSetInput(obj);
			Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text ="添加";
			if(Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc)==DialogResult.OK)
			{
				this.Retrieve();
			}
			return 0;
		}

		public ToolBarButton RetrieveButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.RetrieveButton getter 实现
				return null;
			}
		}

		public ToolBarButton DelButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.DelButton getter 实现
				return null;
			}
		}

		public ToolBarButton PrintButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.PrintButton getter 实现
				return null;
			}
		}
		/// <summary>
		/// 退出
		/// </summary>
		/// <returns></returns>
		public int Exit()
		{
			// TODO:  添加 ucQCScoreSetManager.Exit 实现
			this.FindForm().Close();
			return 0;
		}

		public int Save()
		{
			// TODO:  添加 ucQCScoreSetManager.Save 实现
			return 0;
		}

		private void txtFilter_TextChanged(object sender, System.EventArgs e)
		{
			dv.RowFilter = "条件编码 like '%" +this.txtFilter.Text.Trim()+"%'";
			this._SetFP();
		}

		public ToolBarButton AuditingButton
		{
			get
			{
				// TODO:  添加 ucQCScoreSetManager.AuditingButton getter 实现
				return null;
			}
		}

		#endregion

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1_Sheet1.Rows.Count < 0) return;
            this.Auditing();
        }
        #region add by pantiejun 2008-4-2
        private void btAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认删除？","警告",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Del();
            }
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            this.Auditing();
        }
        #endregion add by pantiejun 2008-4-2
    }
}
