using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR.Query
{
    public partial class frmQueryMessage : Form
    {
      private System.Windows.Forms.GroupBox groupBox1;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.ComponentModel.IContainer components;

        public frmQueryMessage()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

            this.fpSpread1_Sheet1.ColumnCount = 10;
            this.fpSpread1_Sheet1.Columns[0].Label = "发送日期";
            this.fpSpread1_Sheet1.Columns[1].Label = "发送人员";
            this.fpSpread1_Sheet1.Columns[2].Label = "文本";
            this.fpSpread1_Sheet1.Columns[3].Label = "接收人员";
            this.fpSpread1_Sheet1.Columns[4].Label = "接收科室";
            this.fpSpread1_Sheet1.Columns[5].Label = "是否处理";
            this.fpSpread1_Sheet1.Columns[6].Label = "患者住院号";
            this.fpSpread1_Sheet1.Columns[7].Label = "患者姓名";
            this.fpSpread1_Sheet1.Columns[8].Label = "患者病历";
            this.fpSpread1_Sheet1.Columns[9].Label = "病历ID";
            this.fpSpread1_Sheet1.Columns[0].Width = 200;
            this.fpSpread1_Sheet1.Columns[2].Width = 230;
            this.fpSpread1_Sheet1.Columns[6].Width = 120;
            this.fpSpread1_Sheet1.Columns[9].Visible = false;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryMessage));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(363, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 81);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "本人发通知查询";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(347, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(21, 24);
            this.radioButton2.TabIndex = 9;
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(13, 20);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(24, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 80);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "科室统计";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(200, 16);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(90, 21);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "通知时间：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "接收科室：";
            // 
            // comboBox1
            // 
            this.comboBox1.ArrowBackColor = System.Drawing.Color.Silver;
            this.comboBox1.IsEnter2Tab = false;
            this.comboBox1.IsFlat = false;
            this.comboBox1.IsLike = true;
            this.comboBox1.Location = new System.Drawing.Point(94, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.PopForm = null;
            this.comboBox1.ShowCustomerList = false;
            this.comboBox1.ShowID = false;
            this.comboBox1.Size = new System.Drawing.Size(96, 20);
            this.comboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Tag = "";
            this.comboBox1.ToolBarUse = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(182, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(20, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(16, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "粉色代表没有处理的通知";
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.Location = new System.Drawing.Point(8, 176);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(704, 232);
            this.fpSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton4,
            this.toolBarButton3});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(720, 41);
            this.toolBar1.TabIndex = 2;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "查询";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 1;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 0;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 1;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Text = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "退出.bmp");
            this.imageList1.Images.SetKeyName(1, "查找.bmp");
            // 
            // frmQueryMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 422);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Name = "frmQueryMessage";
            this.Text = "查询通知信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QueryMessage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button==this.toolBarButton1)
			{
			
				QueryMessages();
			}
			else if(e.Button==this.toolBarButton3)
			{
			   this.Close();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private void QueryMessages()
		{
		    string strTempSql="";
			Neusoft.FrameWork.Management.DataBaseManger dbMgr =new Neusoft.FrameWork.Management.DataBaseManger ();
			if(this.radioButton1.Checked)
			{
				if(this.dateTimePicker1.Value>this.dateTimePicker2.Value)
				{
					MessageBox.Show("起始时间不能大于结束时间！");
					return ;
				}
	
				if(this.comboBox1.Text=="")
				{
                    strTempSql = "select oper_datetime,oper_name,text,recive_person_name,recive_person_deptname,state,patientno,patinetname,patienteprname,eprid from emr_message m where m.oper_datetime  between to_date(' " + this.dateTimePicker1.Text + " ','yyyy-mm-dd hh24:mi:ss')" +
						" and to_date('"+this.dateTimePicker2.Text+"','yyyy-mm-dd hh24:mi:ss')";
				}
				else
				{
                    strTempSql = "select oper_datetime,oper_name,text,recive_person_name,recive_person_deptname,state,patientno,patinetname,patienteprname,eprid from emr_message m where m.oper_datetime  between to_date(' " + this.dateTimePicker1.Text + " ','yyyy-mm-dd hh24:mi:ss')" +
						" and to_date('"+this.dateTimePicker2.Text+"','yyyy-mm-dd hh24:mi:ss') and m.recive_person_deptname='"+this.comboBox1.Text+"'";  
				}
			}
			else
			{
                strTempSql = "select oper_datetime,oper_name,text,recive_person_name,recive_person_deptname,state,patientno,patinetname,patienteprname,eprid from emr_message m where m.oper_code ='" + Neusoft.FrameWork.Management.Connection.Operator.ID + "'";
			}
				
				DataSet ds=new DataSet();
 
				dbMgr.ExecQuery(strTempSql,ref ds);
		
				this.fpSpread1_Sheet1.RowCount=0;
				int rowIndex=0;
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					this.fpSpread1_Sheet1.Rows.Add(rowIndex,1);
					if(dr[9].ToString()=="0")
					{
						this.fpSpread1_Sheet1.Rows[rowIndex].BackColor=Color.Pink;
					}
				
					this.fpSpread1_Sheet1.Cells[rowIndex,0].Text=dr[0].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,1].Text=dr[1].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,2].Text=dr[2].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,3].Text=dr[3].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,4].Text=dr[4].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,5].Text=dr[5].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,6].Text=dr[6].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,7].Text=dr[7].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,8].Text=dr[8].ToString();
					this.fpSpread1_Sheet1.Cells[rowIndex,9].Text=dr[9].ToString();
                    //this.fpSpread1_Sheet1.Cells[rowIndex,10].Text=dr[10].ToString();
                    //this.fpSpread1_Sheet1.Cells[rowIndex,11].Text=dr[11].ToString();
                    //this.fpSpread1_Sheet1.Cells[rowIndex,12].Text=dr[12].ToString();
                    //this.fpSpread1_Sheet1.Cells[rowIndex,13].Text=dr[13].ToString();
                    //this.fpSpread1_Sheet1.Cells[rowIndex,14].Text=dr[14].ToString();
                    //this.fpSpread1_Sheet1.Cells[rowIndex,15].Text=dr[15].ToString();
                    //this.fpSpread1_Sheet1.Cells[rowIndex,16].Text=dr[16].ToString();
				
					rowIndex++;
				}
		}

		private void QueryMessage_Load(object sender, System.EventArgs e)
		{
			initialDepar();
		}
		private void initialDepar()
		{

		   //Neusoft.HISFC.Management.Manager.Department deptMgr=new Neusoft.HISFC.Management.Manager.Department();
		   this.comboBox1.AddItems(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.QueryDeptmentsInHos(true ));
		}

		private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			string tempPatientNo=this.fpSpread1_Sheet1.Cells[e.Row,6].Text;
			if(tempPatientNo=="") return;
			//Neusoft.HISFC.Management.RADT.InPatient iMgr=new Neusoft.HISFC.Management.RADT.InPatient();
			Neusoft.HISFC.Models.RADT.PatientInfo patient = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.QueryPatientInfoByInpatientNO(tempPatientNo);
			if(patient == null)
			{
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.Err);
				return;
			}

            EPR.Query.Function.ViewEMR(patient, this.fpSpread1_Sheet1.Cells[e.Row, 9].Text);
			//Panel p =new Panel();
//			p.Size = new Size(800,600);
//			Neusoft.Common.Class.Function.EMRShow(p,patientInfo,"0",false);
//			Neusoft.neuFC.Interface.Classes.Function.PopShowControl(p);
		
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
    }
}