using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Neusoft.FrameWork.WinForms.Forms {
	/// <summary>
	/// frmChooseDate 的摘要说明。
	/// </summary>
	public class frmChooseDate : BaseForm {
		private Neusoft.FrameWork.WinForms.Controls.NeuPictureBox pictureBox1;
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel label3;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
		private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBeginDate;
		private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndDate;
		private bool myIsOneDate = false;
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblBeginDate;
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblEndDate;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		//是否只可以选择一个日期
		public bool IsOneDate {
			set{
				this.myIsOneDate = value;
				//this.Init();
			}
		}

		//起始时间
		public DateTime DateBegin {
			get{return this.dtpBeginDate.Value;}
			set{this.dtpBeginDate.Value = value;}
		}

		//终止时间
		public DateTime DateEnd {
			get{return this.dtpEndDate.Value;}
			set{this.dtpEndDate.Value = value;}
		}


		public frmChooseDate() {
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			// 初始化
			this.Init();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		public void Init() {
			try {
				//取系统日期
				Neusoft.FrameWork.Management.DataBaseManger dataBase = new Neusoft.FrameWork.Management.DataBaseManger();
				string sysDate = dataBase.GetSysDate();
				this.dtpBeginDate.Value = DateTime.Parse(sysDate + " 00:00:00");	//起始日期
				this.dtpEndDate.Value   = DateTime.Parse(sysDate + " 23:59:59");	//结束日期

				if(this.myIsOneDate) {
					//用户只可以选择一个日期的时候
					this.lblBeginDate.Text  = "日期:";
					//不显示终止日期
					this.lblEndDate.Visible = false; 
					this.dtpEndDate.Visible = false;
				}
				else {
					//用户只可以选择起始日期和终止日期的时候
					this.lblBeginDate.Text  = "起始日期:";
					//不显示终止日期
					this.lblEndDate.Visible = true; 
					this.dtpEndDate.Visible = true;
				}
			}
			catch{}
		}


		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChooseDate));
			this.dtpBeginDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
			this.dtpEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
			this.lblBeginDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.lblEndDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.pictureBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuPictureBox();
			this.label3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			this.SuspendLayout();
			// 
			// dtpBeginDate
			// 
			this.dtpBeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpBeginDate.Location = new System.Drawing.Point(117, 50);
			this.dtpBeginDate.Name = "dtpBeginDate";
			this.dtpBeginDate.Size = new System.Drawing.Size(151, 21);
			this.dtpBeginDate.TabIndex = 0;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point(117, 75);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(151, 21);
			this.dtpEndDate.TabIndex = 0;
			// 
			// lblBeginDate
			// 
			this.lblBeginDate.Location = new System.Drawing.Point(54, 52);
			this.lblBeginDate.Name = "lblBeginDate";
			this.lblBeginDate.Size = new System.Drawing.Size(60, 17);
			this.lblBeginDate.TabIndex = 2;
			this.lblBeginDate.Text = "起始时间:";
			this.lblBeginDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblEndDate
			// 
			this.lblEndDate.Location = new System.Drawing.Point(54, 77);
			this.lblEndDate.Name = "lblEndDate";
			this.lblEndDate.Size = new System.Drawing.Size(60, 17);
			this.lblEndDate.TabIndex = 2;
			this.lblEndDate.Text = "终止时间:";
			this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 7);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(54, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "请选择日期:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(78, 106);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(79, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "确定(&O)";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnExit
			// 
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(169, 106);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(79, 23);
			this.btnExit.TabIndex = 4;
			this.btnExit.Text = "退出(&X)";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// frmChooseDate
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(313, 145);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblBeginDate);
			this.Controls.Add(this.lblEndDate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtpBeginDate);
			this.Controls.Add(this.dtpEndDate);
			this.Controls.Add(this.btnExit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmChooseDate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "日期选择";
			this.Load += new System.EventHandler(this.frmChooseDate_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e) {
			this.FindForm().Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e) {
			DateTime dateBegin = this.dtpBeginDate.Value;
			DateTime dateEnd   = this.dtpEndDate.Value;
			if(dateEnd.CompareTo(dateBegin) < 0) {
				MessageBox.Show("终止时间必须大于起始时间！","提示");
				return;
			}

			this.DialogResult = DialogResult.OK;

		}

		private void frmChooseDate_Load(object sender, System.EventArgs e) {
		}

	}
}
