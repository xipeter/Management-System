using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.Query
{
	/// <summary>
	/// frmQuery 的摘要说明。
	/// </summary>
	public class frmQuery : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private EPR.Query.ucConditions ucConditions1;
		private System.Windows.Forms.ToolBar toolBar1;
		private Crownwood.Magic.Controls.TabControl tabControl1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.ImageList imageList16;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton tbQuery;
		private System.Windows.Forms.ToolBarButton tbShowEMR;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton tbExit;
		private System.Windows.Forms.Label label1;
        private CheckBox checkBox1;
        private Label label2;
		private System.ComponentModel.IContainer components;

		public frmQuery()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucConditions1 = new Neusoft.HISFC.Components.EPR.Query.ucConditions();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbQuery = new System.Windows.Forms.ToolBarButton();
            this.tbShowEMR = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.tbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucConditions1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 86);
            this.panel1.TabIndex = 0;
            // 
            // ucConditions1
            // 
            this.ucConditions1.BackColor = System.Drawing.Color.Honeydew;
            this.ucConditions1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConditions1.Location = new System.Drawing.Point(0, 0);
            this.ucConditions1.MaxConditionCount = 4;
            this.ucConditions1.Name = "ucConditions1";
            this.ucConditions1.Size = new System.Drawing.Size(846, 86);
            this.ucConditions1.TabIndex = 0;
            this.ucConditions1.Query += new Neusoft.HISFC.Components.EPR.Query.QueryHandler(this.ucquery1_Query);
            this.ucConditions1.ConditionCountChanged += new System.EventHandler(this.ucquery1_ConditionCountChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 127);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(846, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 371);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(846, 371);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fpSpread1);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(846, 346);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "结果";
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1";
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(846, 346);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 8;
            this.fpSpread1_Sheet1.RowCount = 1;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "文件编码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "住院流水号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "患者姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "节点路径";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "节点名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "数值";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "文件类型";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "文件名称";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "文件编码";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 76F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "住院流水号";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 103F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "患者姓名";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 88F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "节点路径";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 111F;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "节点名称";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 104F;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "数值";
            this.fpSpread1_Sheet1.Columns.Get(5).Locked = false;
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 101F;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "文件类型";
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 121F;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "文件名称";
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 111F;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(846, 346);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Title = "病历";
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.tbQuery,
            this.tbShowEMR,
            this.toolBarButton5,
            this.tbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList16;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(846, 41);
            this.toolBar1.TabIndex = 3;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbQuery
            // 
            this.tbQuery.ImageIndex = 4;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Text = "查询";
            this.tbQuery.ToolTipText = "查询";
            // 
            // tbShowEMR
            // 
            this.tbShowEMR.ImageIndex = 33;
            this.tbShowEMR.Name = "tbShowEMR";
            this.tbShowEMR.Text = "显示病历";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbExit
            // 
            this.tbExit.ImageIndex = 14;
            this.tbExit.Name = "tbExit";
            this.tbExit.Text = "退出";
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "");
            this.imageList16.Images.SetKeyName(1, "");
            this.imageList16.Images.SetKeyName(2, "");
            this.imageList16.Images.SetKeyName(3, "");
            this.imageList16.Images.SetKeyName(4, "");
            this.imageList16.Images.SetKeyName(5, "");
            this.imageList16.Images.SetKeyName(6, "");
            this.imageList16.Images.SetKeyName(7, "");
            this.imageList16.Images.SetKeyName(8, "");
            this.imageList16.Images.SetKeyName(9, "");
            this.imageList16.Images.SetKeyName(10, "");
            this.imageList16.Images.SetKeyName(11, "");
            this.imageList16.Images.SetKeyName(12, "");
            this.imageList16.Images.SetKeyName(13, "");
            this.imageList16.Images.SetKeyName(14, "");
            this.imageList16.Images.SetKeyName(15, "");
            this.imageList16.Images.SetKeyName(16, "");
            this.imageList16.Images.SetKeyName(17, "");
            this.imageList16.Images.SetKeyName(18, "");
            this.imageList16.Images.SetKeyName(19, "");
            this.imageList16.Images.SetKeyName(20, "");
            this.imageList16.Images.SetKeyName(21, "");
            this.imageList16.Images.SetKeyName(22, "");
            this.imageList16.Images.SetKeyName(23, "");
            this.imageList16.Images.SetKeyName(24, "");
            this.imageList16.Images.SetKeyName(25, "");
            this.imageList16.Images.SetKeyName(26, "");
            this.imageList16.Images.SetKeyName(27, "");
            this.imageList16.Images.SetKeyName(28, "");
            this.imageList16.Images.SetKeyName(29, "");
            this.imageList16.Images.SetKeyName(30, "");
            this.imageList16.Images.SetKeyName(31, "");
            this.imageList16.Images.SetKeyName(32, "");
            this.imageList16.Images.SetKeyName(33, "");
            this.imageList16.Images.SetKeyName(34, "");
            this.imageList16.Images.SetKeyName(35, "");
            this.imageList16.Images.SetKeyName(36, "");
            this.imageList16.Images.SetKeyName(37, "");
            this.imageList16.Images.SetKeyName(38, "");
            this.imageList16.Images.SetKeyName(39, "");
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(256, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "灰色代表只满足部分查询条件的患者";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(464, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "全符合/部分符合";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "结果";
            // 
            // frmQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(846, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmQuery";
            this.Text = "病历查询";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
//		protected Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
//        protected Neusoft.HISFC.Management.File fileParam = new Neusoft.HISFC.Management.File.DataFileParam();
		protected TemplateDesignerApplication.ucLoader loader = new TemplateDesignerApplication.ucLoader();
		private void frmQuery_Load(object sender, System.EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
            Neusoft.HISFC.Models.File.DataFileParam param = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetDataFileParam("0") ;
            ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetNodePathList(param.Name);
			this.panel1.Height = this.ucConditions1.ControlHeight;
			this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
			this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpSpread1.CellDoubleClick+=new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);

			//添加EMRControl
			loader.Dock = DockStyle.Fill;
			this.tabPage2.Controls.Add(loader);
			this.fpSpread1_Sheet1.SetColumnMerge(1,FarPoint.Win.Spread.Model.MergePolicy.Always);
			this.fpSpread1_Sheet1.SetColumnMerge(2,FarPoint.Win.Spread.Model.MergePolicy.Always);

		}

		private int iConditionNum = 0;
		/// <summary>
		/// 获得where条件
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public string GetWhereString(ArrayList arr)
		{
			if(arr == null) return "";
			string strWhere = " ";
			string sCondition ="",sOperation ="",sValue ="",sRelation ="",sRelationNew = "";
			iConditionNum = arr.Count;
			for(int i=0;i<arr.Count;i++)
			{
				sCondition ="";sOperation ="";sValue ="";sRelationNew = "";
				Neusoft.FrameWork.Models.NeuObject obj = (Neusoft.FrameWork.Models.NeuObject)arr[i];

				sCondition = obj.ID;
				sOperation = obj.Name;
				sValue = obj.Memo;
				sRelationNew = obj.User01;
				if(sOperation == "" || sCondition == "" || sValue == "") continue;
				string stemp ="";
				stemp =" {3} (parentnodename like '%{0}%' and nodevalue {1} '{2}')";

				if(sOperation.Trim().ToLower() == "not like" || sOperation.Trim().ToLower() == "like")
				{
					if(sValue =="") 
					{
						sValue ="%";
						stemp =" {3} (parentnodename like '%{0}%' and (nodevalue {1} '{2}' or nodevalue is null))";
					}
					else
					{
						sValue = "%"+sValue+"%";
					}
					
				}
				else if(sOperation.IndexOf(">")>=0 || sOperation.IndexOf("<")>=0)
				{
					stemp =" {3} (parentnodename like '%{0}%' and lpad(nodevalue,5,'0') {1} lpad('{2}',5,'0'))";		
				}
				
				//获得条件
				if(sOperation =="=" && sValue.Trim() =="") return "";
				Neusoft.FrameWork.Public.String.FormatString(stemp,out stemp,sCondition,sOperation,sValue,sRelation);
				sRelation = sRelationNew;
				strWhere += stemp;


			}
			return strWhere+" order by index1";
		}	
		private void ucquery1_Query(Object sender, QueryEventArgs e)
		{
			string strWhere = GetWhereString(e.QueryCondition);
			this.Query(strWhere);
		}
        System.Data.DataSet ds = null;
		private void Query(string strWhere)
		{
             ds = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryEMRByNode(strWhere);
			if(ds == null) 
			{
                MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return ;
			}
            
			this.fpSpread1_Sheet1.DataSource = ds;
			
			try
			{
				int iMultiLineColumn = -1;
				int iColumnWidth = -1;
				for(int i=0;i<ds.Tables[0].Columns.Count;i++)
				{
					if(ds.Tables[0].Columns[0].MaxLength>200)
					{
						((FarPoint.Win.Spread.CellType.TextCellType)this.fpSpread1_Sheet1.Columns[i].CellType).Multiline = true;
						this.fpSpread1_Sheet1.Columns[i].Width = iColumnWidth;
						iMultiLineColumn = i;
						break;
					}		
				}
			
				if(iMultiLineColumn !=-1) 
				{
					for(int i=0;i<ds.Tables[0].Rows.Count;i++)
					{
						int iRowHeight = ds.Tables[0].Rows[i][iMultiLineColumn].ToString().Length /iColumnWidth;
						this.fpSpread1_Sheet1.Rows[i].Height = iRowHeight * this.fpSpread1_Sheet1.Rows[i].Height;
					}
				}
			}
			catch{}
			Filter();
		}
		private void ucquery1_ConditionCountChanged(object sender, EventArgs e)
		{
			ucConditions condition = (ucConditions)sender;
			this.panel1.Height = condition.ControlHeight;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbQuery)
			{
				string strWhere = GetWhereString(this.ucConditions1.GetQueryCondition());
				this.Query(strWhere);
			}
			else if(e.Button == this.tbShowEMR)
			{
				string fileid  ;
				if(this.fpSpread1_Sheet1.ActiveRowIndex <0) 
				{
					MessageBox.Show("请选择一条记录！");
					return;
				}
				fileid  = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,0].Text;
				this.ShowEmr(fileid);
				
			}
			else if (e.Button == this.tbExit)
			{
				this.Close();
			}
		}

		private void ShowEmr(string fileid)
		{
			Neusoft.HISFC.Models.File.DataFileInfo dt = new Neusoft.HISFC.Models.File.DataFileInfo();
//			Neusoft.HISFC.Management.File.DataFileInfo managerFileInfo = new Neusoft.HISFC.Management.File.DataFileInfo();
            dt = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetFile(fileid);
			if(dt == null)
			{
				MessageBox.Show("无法找到病历。");
				return;
			}

			string[] param={Neusoft.FrameWork.Management.Connection.Operator.ID,dt.Index1 };
			loader.ISql = Common.Classes.Function.ISql;

			loader.ISql.SetParam(param);
			loader.ISql.RefreshVariant();

			string fileName = TemplateDesignerHost.Function.LoadFileCheckFile(dt,false);
			
			loader.Init(dt,fileName,param);

			this.tabControl1.SelectedTab = this.tabPage2;

		}

		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			string fileid  ;
			if(this.fpSpread1_Sheet1.ActiveRowIndex <0) 
			{
				MessageBox.Show("请选择一条记录！");
				return;
			}
			fileid  = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,0].Text;
			this.ShowEmr(fileid);
		}

		private void Filter()
		{

            //for(int i=0;i<this.fpSpread1_Sheet1.RowCount;i++)
            //{
            //    if(this.fpSpread1_Sheet1.Rows[i].ForeColor != Color.Gray)
            //    {
            //        string inpatientNo = this.fpSpread1_Sheet1.Cells[i,1].Text;
            //        bool b = true;
            //        for(int j=0;j<this.iConditionNum;j++)//向下查找
            //        {
            //            if(j+i>this.fpSpread1_Sheet1.RowCount) 
            //            {

            //            }
            //            else
            //            {
            //                string tmp1 = this.fpSpread1_Sheet1.Cells[i+j,1].Text;
            //                if(tmp1!=inpatientNo) //不同的，要变颜色了
            //                {
            //                    for(int m=0;m<j;m++)
            //                    {
            //                        b = false;
            //                        i=i+m;
            //                        this.fpSpread1_Sheet1.Rows[i+m].ForeColor = Color.Gray;
            //                    }
            //                }
            //            }
            //        }
            //        if(b)//是对的
            //        {
            //            i = i+this.iConditionNum-1;
            //        }
            //    }
            //}
            string inpatientNo = "";
            System.Collections.Hashtable hat = new Hashtable();

            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                inpatientNo = this.fpSpread1_Sheet1.Cells[i, 1].Text;
                int iValue = Neusoft.FrameWork.Function.NConvert.ToInt32(hat[inpatientNo]);
                iValue = iValue + 1;
                hat.Remove(inpatientNo);
                hat.Add(inpatientNo, iValue++);
                if (this.fpSpread1_Sheet1.Cells[i, 4].Text == "现病史"
                       || this.fpSpread1_Sheet1.Cells[i, 4].Text == "主诉")
                {
                    this.fpSpread1_Sheet1.RowHeader.Cells[i, 0].Text = "+";
                    this.fpSpread1_Sheet1.RowHeader.Cells[i, 0].BackColor = Color.Yellow;
                }
                else
                {
                    this.fpSpread1_Sheet1.RowHeader.Cells[i, 0].Text = "";
                    this.fpSpread1_Sheet1.RowHeader.Cells[i, 0].BackColor = Color.LightGray;
                }
            }

            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                inpatientNo = this.fpSpread1_Sheet1.Cells[i, 1].Text;
                int iValue = Neusoft.FrameWork.Function.NConvert.ToInt32(hat[inpatientNo]);
                if (iValue < this.iConditionNum )
                {
                    this.fpSpread1_Sheet1.Rows[i].ForeColor = Color.Gray;//变灰色
                }
            }
            this.label2.Text = "查询符合条件的患者人数：" + hat.Count.ToString();
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                for (int i = this.fpSpread1_Sheet1.RowCount-1; i >=0; i--)
                {
                    if (this.fpSpread1_Sheet1.Rows[i].ForeColor == Color.Gray)
                    {
                        this.fpSpread1_Sheet1.Rows.Remove(i, 1);
                    }
                }
                System.Collections.Hashtable hat = new Hashtable();

                for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                {
                    string inpatientNo = this.fpSpread1_Sheet1.Cells[i, 1].Text;
                    int iValue = Neusoft.FrameWork.Function.NConvert.ToInt32(hat[inpatientNo]);
                    iValue = iValue + 1;
                    hat.Remove(inpatientNo);
                    hat.Add(inpatientNo, iValue++);
                }

            
                this.label2.Text = "查询符合条件的患者人数：" + hat.Count.ToString();
            }
            else
            {
                string strWhere = GetWhereString(this.ucConditions1.GetQueryCondition());
                this.Query(strWhere);
            }
        }

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowHeader.Cells[e.Row, 0].Text == "+" && e.RowHeader)
            {
                this.fpSpread1_Sheet1.RowHeader.Cells[e.Row, 0].Text = "-";
                string strWhere = @" id='{0}' and parentnodename like '{1}\%'";
                strWhere = string.Format(strWhere,this.fpSpread1_Sheet1.Cells[e.Row, 0].Text, this.fpSpread1_Sheet1.Cells[e.Row, 4].Text);
                System.Data.DataSet myds  = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryEMRByNode(strWhere);
                if (myds == null || myds.Tables.Count == 0 || myds.Tables[0].Rows.Count== 0) return;
                this.fpSpread1_Sheet1.Rows.Add(e.Row+1, myds.Tables[0].Rows.Count);

                int i = 0;
                foreach (System.Data.DataRow dr in myds.Tables[0].Rows)
                {
                    i++;
                    int j = 0;
                    foreach (System.Data.DataColumn dc in myds.Tables[0].Columns)
                    {
                        this.fpSpread1_Sheet1.Cells[i + e.Row, j].Text = dr[j].ToString();
                        j++;
                    }
                    this.fpSpread1_Sheet1.RowHeader.Cells[i + e.Row,0].Text = ".";
                    this.fpSpread1_Sheet1.RowHeader.Cells[i + e.Row, 0].BackColor = Color.White;
                }
            }
            else if (this.fpSpread1_Sheet1.RowHeader.Cells[e.Row, 0].Text == "-" && e.RowHeader)
            {
                this.fpSpread1_Sheet1.RowHeader.Cells[e.Row, 0].Text = "+";
                try
                {
                    while (true)
                    {
                        if (this.fpSpread1_Sheet1.RowHeader.Cells[e.Row + 1, 0].Text == ".")
                            this.fpSpread1_Sheet1.Rows.Remove(e.Row + 1, 1);
                        else
                            break;
                    }
                }
                catch { }
            }
        }
    }
}
