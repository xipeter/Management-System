using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
namespace Neusoft.HISFC.Components.EPR.Query
{
	/// <summary>
	/// frmQueryPatient 的摘要说明。
	/// </summary>
	public class frmQueryPatient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cmbCondition;
		private System.Windows.Forms.ComboBox txtRefer3;
		private System.Windows.Forms.ComboBox txtRefer2;
		private System.Windows.Forms.ComboBox txtRefer1;
		private System.Windows.Forms.Label lblRefer1;
		private System.Windows.Forms.Label lblRefer3;
		private System.Windows.Forms.Label lblRefer2;
		private System.Windows.Forms.Label lblRefer1a;
		private System.Windows.Forms.ComboBox txtRefer4;
		private System.Windows.Forms.Label lblRefer4;
		private System.Windows.Forms.ImageList imageList16;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.ComponentModel.IContainer components;

		public frmQueryPatient()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmQueryPatient));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.imageList16 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtRefer4 = new System.Windows.Forms.ComboBox();
			this.lblRefer4 = new System.Windows.Forms.Label();
			this.txtRefer3 = new System.Windows.Forms.ComboBox();
			this.txtRefer2 = new System.Windows.Forms.ComboBox();
			this.txtRefer1 = new System.Windows.Forms.ComboBox();
			this.cmbCondition = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.lblRefer1 = new System.Windows.Forms.Label();
			this.lblRefer3 = new System.Windows.Forms.Label();
			this.lblRefer2 = new System.Windows.Forms.Label();
			this.lblRefer1a = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton4,
																						this.toolBarButton3,
																						this.toolBarButton1,
																						this.toolBarButton2});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList16;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(552, 41);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 4;
			this.toolBarButton1.Text = "查询";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 14;
			this.toolBarButton2.Text = "退出";
			// 
			// imageList16
			// 
			this.imageList16.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList16.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
			this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(552, 380);
			this.panel1.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.fpSpread1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(192, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(360, 380);
			this.panel3.TabIndex = 2;
			// 
			// fpSpread1
			// 
			this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fpSpread1.Location = new System.Drawing.Point(0, 0);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(360, 380);
			this.fpSpread1.TabIndex = 0;
			this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(184, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 380);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtRefer4);
			this.panel2.Controls.Add(this.lblRefer4);
			this.panel2.Controls.Add(this.txtRefer3);
			this.panel2.Controls.Add(this.txtRefer2);
			this.panel2.Controls.Add(this.txtRefer1);
			this.panel2.Controls.Add(this.cmbCondition);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.lblRefer1);
			this.panel2.Controls.Add(this.lblRefer3);
			this.panel2.Controls.Add(this.lblRefer2);
			this.panel2.Controls.Add(this.lblRefer1a);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(184, 380);
			this.panel2.TabIndex = 0;
			// 
			// txtRefer4
			// 
			this.txtRefer4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRefer4.Location = new System.Drawing.Point(53, 170);
			this.txtRefer4.Name = "txtRefer4";
			this.txtRefer4.Size = new System.Drawing.Size(121, 20);
			this.txtRefer4.TabIndex = 14;
			this.txtRefer4.Text = "comboBox4";
			// 
			// lblRefer4
			// 
			this.lblRefer4.Location = new System.Drawing.Point(4, 175);
			this.lblRefer4.Name = "lblRefer4";
			this.lblRefer4.Size = new System.Drawing.Size(40, 16);
			this.lblRefer4.TabIndex = 13;
			this.lblRefer4.Text = "label3";
			// 
			// txtRefer3
			// 
			this.txtRefer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRefer3.Location = new System.Drawing.Point(52, 135);
			this.txtRefer3.Name = "txtRefer3";
			this.txtRefer3.Size = new System.Drawing.Size(121, 20);
			this.txtRefer3.TabIndex = 12;
			this.txtRefer3.Text = "comboBox4";
			// 
			// txtRefer2
			// 
			this.txtRefer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRefer2.Location = new System.Drawing.Point(52, 98);
			this.txtRefer2.Name = "txtRefer2";
			this.txtRefer2.Size = new System.Drawing.Size(121, 20);
			this.txtRefer2.TabIndex = 11;
			this.txtRefer2.Text = "comboBox3";
			// 
			// txtRefer1
			// 
			this.txtRefer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRefer1.Location = new System.Drawing.Point(52, 61);
			this.txtRefer1.Name = "txtRefer1";
			this.txtRefer1.Size = new System.Drawing.Size(121, 20);
			this.txtRefer1.TabIndex = 10;
			this.txtRefer1.Text = "comboBox2";
			// 
			// cmbCondition
			// 
			this.cmbCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCondition.Location = new System.Drawing.Point(52, 24);
			this.cmbCondition.Name = "cmbCondition";
			this.cmbCondition.Size = new System.Drawing.Size(121, 20);
			this.cmbCondition.TabIndex = 9;
			this.cmbCondition.Text = "comboBox1";
			this.cmbCondition.SelectedIndexChanged += new System.EventHandler(this.cmbCondition_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(72, 226);
			this.button1.Name = "button1";
			this.button1.TabIndex = 8;
			this.button1.Text = "查询";
			this.button1.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// lblRefer1
			// 
			this.lblRefer1.Location = new System.Drawing.Point(3, 64);
			this.lblRefer1.Name = "lblRefer1";
			this.lblRefer1.Size = new System.Drawing.Size(40, 16);
			this.lblRefer1.TabIndex = 6;
			this.lblRefer1.Text = "label4";
			// 
			// lblRefer3
			// 
			this.lblRefer3.Location = new System.Drawing.Point(3, 140);
			this.lblRefer3.Name = "lblRefer3";
			this.lblRefer3.Size = new System.Drawing.Size(40, 16);
			this.lblRefer3.TabIndex = 4;
			this.lblRefer3.Text = "label3";
			// 
			// lblRefer2
			// 
			this.lblRefer2.Location = new System.Drawing.Point(3, 102);
			this.lblRefer2.Name = "lblRefer2";
			this.lblRefer2.Size = new System.Drawing.Size(40, 16);
			this.lblRefer2.TabIndex = 2;
			this.lblRefer2.Text = "label2";
			// 
			// lblRefer1a
			// 
			this.lblRefer1a.Location = new System.Drawing.Point(3, 26);
			this.lblRefer1a.Name = "lblRefer1a";
			this.lblRefer1a.Size = new System.Drawing.Size(40, 16);
			this.lblRefer1a.TabIndex = 0;
			this.lblRefer1a.Text = "条件";
			// 
			// frmQueryPatient
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(552, 421);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Name = "frmQueryPatient";
			this.Text = "患者查询";
			this.Load += new System.EventHandler(this.frmQueryPatient_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void textBox4_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		string strFileName;
		XmlDataDocument doc = new XmlDataDocument();
		XmlNodeList nodes;
		XmlNode node;
		string type  = "";
		public short param  = 0;
		ArrayList alControls = new ArrayList();

		bool first=true;
					  
		//装载查询条件
		//
		private void load_QuerySetting()
		{
			try
			{
				strFileName =  TemplateDesignerHost.Function.SystemPath  + "HIS_QUERY_SETTING.xml";
				doc.Load(strFileName);
				nodes = doc.SelectNodes("设置/系统设置");

				foreach(XmlNode node in nodes)
					this.cmbCondition.Items.Add(node.Attributes["名称"].Value);
													   
			}
			catch 
			{}
							

			first = false;
			this.cmbCondition.SelectedIndex = 0;

		}
		//变换条件
		private void cmbCondition_SelectedIndexChanged(System.Object sender, System.EventArgs e) //Handles cmbCondition.SelectedIndexChanged
		{
			if (first == true)
				return;
			try
			{
				string s  = "设置/系统设置[@名称=\"" + this.cmbCondition.Text + "\"]";
				node = doc.SelectSingleNode(s);
			}
			catch (Exception ex)
			{
																																									
				MessageBox.Show(ex.Message);
			}

			short i, j;
			
			try
			{
														  
				type = node.Attributes[1].Value;
			}
			catch
			{
				type = "";
			}
			short k  = 0;
			for (j = 0 ;j< alControls.Count;++j)
			{
					  
				Control control= alControls[j] as Control;
				control.Visible = false;
			}
			for (i = 0 ;i< node.ChildNodes[0].Attributes.Count;++i)
			{
											  
				if (node.ChildNodes[0].Attributes[i].Name.Substring(node.ChildNodes[0].Attributes[i].Name.Length- 2) != "数值")
				{
					for (j = 0 ;j<alControls.Count;++j)
					{
																							 
						Control control= alControls[j] as Control;

						if (control.Name == "lblRefer" + (k + 1).ToString())
						{
							control.Text = node.ChildNodes[0].Attributes[i].Name;
							control.Visible = true;
						}
						if (control.Name == "txtRefer" + (k + 1).ToString())
						{
							control.Tag = node.ChildNodes[0].Attributes[i].Value;
							control.Visible = true;
							((ComboBox)control).Items.Clear();
							//找到 value
							try
							{
								if (node.ChildNodes[0].Attributes[i + 1].Name.Substring(node.ChildNodes[0].Attributes[i + 1].Name.Length- 2) == "数值")
									f_fillCombo(control, node.ChildNodes[0].Attributes[i + 1].Value);
							}
							catch{}
				
						}
					}
					k += 1;
				}
			}

			this.cmbCondition.Tag = node.InnerText;
			//*****显示必须控件*******************************
			this.cmbCondition.Visible = true;
//			this.Button1.Visible = true;
//			this.Label1.Visible = true;
//			this.btnQuery.Visible = true;
//			this.DataGrid.Visible = true;
//			this.chkSealed.Visible = true;
//			this.GroupBox1.Visible = true;
//			this.Panel1.Visible = true;
//			this.Panel2.Visible = true;
//			this.CheckBox1.Visible = true;
//			if (GetPermission[11] == "1")																																																																			
//				this.Button2.Visible = true;
																																																																																	
		}
		//fill combo 
		Neusoft.FrameWork.Management.DataBaseManger manager = new Neusoft.FrameWork.Management.DataBaseManger();
		private void f_fillCombo(Object sender, string s)
		{
			string[] ss;
			bool b  = false;
			if (s.Length > 5)
				if ((s.Trim().Substring(0, 6)).ToUpper() == "SELECT")
					b = true;
																												  
			((ComboBox)sender).Text="";
			short i;
			try
			{			
				if (b) //select
				{
					System.Data.DataSet ds = new System.Data.DataSet();
					if(manager.ExecQuery(s,ref ds)==-1)
					{
						//
						MessageBox.Show(manager.Err);
						return;
					}
					
					foreach (System.Data.DataRow r in ds.Tables[0].Rows) 
					{
						((ComboBox)sender).Items.Add(r[0].ToString());
					}
				}
				else 
				{
					ss = s.Split(',');
					for (i = 0 ;i< ss.Length;i++)
						((ComboBox)sender).Items.Add(ss[i]);
																  
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

  
		private void btnQuery_Click(System.Object sender, System.EventArgs e) //Handles btnQuery.Click
		{
			//Me.chkSealed.Checked = False
			short i;
			string strSql;

			strSql = this.cmbCondition.Tag.ToString();

			for (i = 0;i<this.alControls.Count;++i)
			{
											  
				string s= ((Control)this.alControls[i]).Name;
				if (((Control)this.alControls[i]).Visible && s.Substring(0, 8) == "txtRefer" && ((Control)this.alControls[i]).Tag.ToString() != "")
				  
					strSql = strSql.Replace(((Control)this.alControls[i]).Tag.ToString(), ((Control)this.alControls[i]).Text);
																																   
			}
			System.Data.DataSet ds = new System.Data.DataSet();
			if(manager.ExecQuery(strSql,ref ds)==-1)
			{
				//
				MessageBox.Show(manager.Err);
				return;
			}
			this.fpSpread1_Sheet1.DataSource=ds;
       
		}

		private void frmQueryPatient_Load(object sender, System.EventArgs e)
		{
			alControls.Add(this.lblRefer1);
			alControls.Add(this.lblRefer2);
			alControls.Add(this.lblRefer3);
			alControls.Add(this.lblRefer4);
			alControls.Add(this.txtRefer1);
			alControls.Add(this.txtRefer2);
			alControls.Add(this.txtRefer3);
			alControls.Add(this.txtRefer4);
			this.load_QuerySetting();
			this.cmbCondition.SelectedIndex = 0;
			this.WindowState=FormWindowState.Maximized;
			this.fpSpread1_Sheet1.Columns[-1].CellType=new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpSpread1_Sheet1.OperationMode=FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpSpread1_Sheet1.DataAutoCellTypes = false;
			this.fpSpread1.Sheets[0].Columns[-1].ShowSortIndicator = true;

			this.txtRefer1.Focus();

		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button==this.toolBarButton1) 
				this.btnQuery_Click(sender,null);
			else
				this.Close();
		}

		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			string s = "";
			try
			{
				s = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,0].Text;
			}
			catch{return;}

			Neusoft.HISFC.Models.RADT.PatientInfo p = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.QueryPatientInfoByInpatientNO(s);
			if(p == null)
			{
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.Err);
				return;
			}
			Function.EditEMR(p,this);
		}
	}
}
