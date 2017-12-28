using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Notice
{
	/// <summary>
	/// frmNotice 的摘要说明。
	/// </summary>
	public class frmNotice : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox ckShowEveryDay;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnCancel;
		private Manager.Notice.ucNotice ucNotice1;
		private System.Windows.Forms.Label lbNewNotice;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.Panel panelTop;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNotice()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Load += new EventHandler(frmNotice_Load);
			this.btnRead.Click += new EventHandler(btnRead_Click);
			this.btnNext.Click += new EventHandler(btnNext_Click);
			this.btnCancel.Click += new EventHandler(btnCancel_Click);

			this.GetNotice("A","A","");
			this.DeptCode = "A";
			this.GroupCode = "A";
		}

		public frmNotice(string deptCode,string groupCode,string baseNotice)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Load += new EventHandler(frmNotice_Load);
			this.btnRead.Click += new EventHandler(btnRead_Click);
			this.btnNext.Click += new EventHandler(btnNext_Click);
			this.btnCancel.Click += new EventHandler(btnCancel_Click);

			this.GetNotice(deptCode,groupCode,baseNotice);
			this.DeptCode = deptCode;
			this.GroupCode = groupCode;
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
			this.panelBottom = new System.Windows.Forms.Panel();
			this.lbNewNotice = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.ckShowEveryDay = new System.Windows.Forms.CheckBox();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.ucNotice1 = new Manager.Notice.ucNotice();
			this.panelTop = new System.Windows.Forms.Panel();
			this.btnQuery = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.panelBottom.SuspendLayout();
			this.panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.lbNewNotice);
			this.panelBottom.Controls.Add(this.btnNext);
			this.panelBottom.Controls.Add(this.ckShowEveryDay);
			this.panelBottom.Controls.Add(this.btnRead);
			this.panelBottom.Controls.Add(this.btnCancel);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 330);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(598, 38);
			this.panelBottom.TabIndex = 0;
			// 
			// lbNewNotice
			// 
			this.lbNewNotice.ForeColor = System.Drawing.Color.Red;
			this.lbNewNotice.Location = new System.Drawing.Point(139, 11);
			this.lbNewNotice.Name = "lbNewNotice";
			this.lbNewNotice.Size = new System.Drawing.Size(197, 17);
			this.lbNewNotice.TabIndex = 2;
			this.lbNewNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnNext
			// 
			this.btnNext.BackColor = System.Drawing.Color.MintCream;
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnNext.Location = new System.Drawing.Point(337, 8);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(98, 23);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "显示下一条(N)";
			// 
			// ckShowEveryDay
			// 
			this.ckShowEveryDay.Location = new System.Drawing.Point(4, 11);
			this.ckShowEveryDay.Name = "ckShowEveryDay";
			this.ckShowEveryDay.Size = new System.Drawing.Size(143, 17);
			this.ckShowEveryDay.TabIndex = 0;
			this.ckShowEveryDay.Text = "启动时显示每日信息";
			this.ckShowEveryDay.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// btnRead
			// 
			this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRead.Location = new System.Drawing.Point(440, 8);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(73, 23);
			this.btnRead.TabIndex = 1;
			this.btnRead.Text = "已读(R)";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(519, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(73, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "取消(C)";
			// 
			// ucNotice1
			// 
			this.ucNotice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucNotice1.Location = new System.Drawing.Point(0, 35);
			this.ucNotice1.Name = "ucNotice1";
			this.ucNotice1.Size = new System.Drawing.Size(598, 295);
			this.ucNotice1.TabIndex = 1;
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.btnQuery);
			this.panelTop.Controls.Add(this.label2);
			this.panelTop.Controls.Add(this.label1);
			this.panelTop.Controls.Add(this.dateTimePicker1);
			this.panelTop.Controls.Add(this.dateTimePicker2);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(598, 35);
			this.panelTop.TabIndex = 2;
			this.panelTop.Visible = false;
			// 
			// btnQuery
			// 
			this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnQuery.Location = new System.Drawing.Point(440, 5);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(73, 23);
			this.btnQuery.TabIndex = 3;
			this.btnQuery.Text = "查询(Q)";
			this.btnQuery.Click += new EventHandler(btnQuery_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(188, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(18, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "－";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "发布日期：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(78, 7);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(102, 21);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(217, 8);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(102, 21);
			this.dateTimePicker2.TabIndex = 0;
			// 
			// frmNotice
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.MintCream;
			this.ClientSize = new System.Drawing.Size(598, 368);
			this.Controls.Add(this.ucNotice1);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.panelBottom);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNotice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmNotice";
			this.panelBottom.ResumeLayout(false);
			this.panelTop.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 发布信息管理类
		/// </summary>
		Neusoft.HISFC.BizLogic.Manager.Notice noticeManager = new Neusoft.HISFC.BizLogic.Manager.Notice();
		
		private string DeptCode = "";
		private string GroupCode = "";
		/// <summary>
		/// 本次已读的发布信息索引
		/// </summary>
		private int readIndex = 0;
		/// <summary>
		/// 本次新发布信息数组内时间最新的一个已读信息
		/// </summary>
		private int iReadTop = -1;
		/// <summary>
		/// 本次新发布信息数组内时间最后的一个已读信息
		/// </summary>
		private int iReadBottom = -1;
		/// <summary>
		/// 当前显示的提示信息 在提示信息数组内的索引
		/// </summary>
		private int iArrayIndex = 0;
		/// <summary>
		/// 提示信息数组
		/// </summary>
		private ArrayList noticeInfo;
		/// <summary>
		/// 提示信息数组 数组成员类型 NeuObject Name 提示日期 Memo 提示内容
		/// </summary>
		public ArrayList NoticeInfo
		{
			set
			{
				this.noticeInfo = value;
				if (value.Count <= 1)
					this.btnNext.Enabled = false;
				this.ucNotice1.Notice = this.noticeInfo[this.iArrayIndex] as Neusoft.HISFC.Models.Base.Notice;
			}
		}

		/// <summary>
		/// 设置是否显示时间选择
		/// </summary>
		public bool SetDateSelect
		{
			set
			{
				this.panelTop.Visible = value;
			}
		}

		/// <summary>
		/// 根据科室编码、组编码、及附加显示信息 
		/// </summary>
		/// <param name="deptCode"></param>
		/// <param name="groupCode"></param>
		/// <param name="baseNotice"></param>
		protected void GetNotice(string deptCode,string groupCode,string baseNotice)
		{
			DateTime dt1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dateTimePicker1.Text);
			DateTime dt2 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dateTimePicker2.Text);
			if (!this.panelTop.Visible)
				dt1 = new DateTime(2005,10,1);
			ArrayList al = this.noticeManager.GetNotice(deptCode,groupCode,dt1,dt2);
			if (al == null)
			{
				MessageBox.Show("获取发布信息出错" + noticeManager.Err);
				return;
			}
			if (baseNotice != null && baseNotice != "")
			{
				Neusoft.HISFC.Models.Base.Notice temp = new Neusoft.HISFC.Models.Base.Notice();
				temp.Dept.ID = deptCode;
				temp.Group.ID = groupCode;
				temp.NoticeInfo = baseNotice;
				temp.NoticeDate = noticeManager.GetDateTimeFromSysDateTime();
				temp.NoticeDept.ID = "";
				temp.NoticeTitle = "系统提示";
				al.Insert(0,temp);
			}
			if (al.Count > 0)
			{
				string strErr = "";
				ArrayList alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("NoticeSetting",out strErr);
				if (alValues == null)
				{
					MessageBox.Show(strErr);
				}
				bool isCheck = false;
				DateTime dtEnd;
				if (alValues.Count > 0)
				{
					isCheck = Neusoft.FrameWork.Function.NConvert.ToBoolean(alValues[0]);
					dtEnd = Neusoft.FrameWork.Function.NConvert.ToDateTime(alValues[1]);

					this.ckShowEveryDay.Checked = isCheck;

					if (isCheck)
					{
						this.NoticeInfo = al;
					}
					else

					{
						ArrayList alTemp = new ArrayList();
						foreach(Neusoft.HISFC.Models.Base.Notice info in al)
						{
							if (info.NoticeDate >= dtEnd)
								alTemp.Add(info);
						}
						this.NoticeInfo = alTemp;
					}
				}
				else
				{
					this.ckShowEveryDay.Checked = false;
					this.NoticeInfo = al;
				}

				this.iReadBottom = 0;
				this.iReadTop = this.noticeInfo.Count - 1;
				this.readIndex = this.noticeInfo.Count;
			}

			this.SetNewNoticeLabel();
		}
		
		/// <summary>
		/// 查询中调用
		/// </summary>
		public void GetNotice()
		{
			DateTime dt1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dateTimePicker1.Text);
			DateTime dt2 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dateTimePicker2.Text);
			ArrayList al = this.noticeManager.GetNotice(this.DeptCode,this.GroupCode,dt1,dt2);
			if (al == null)
			{
				MessageBox.Show("获取发布信息出错" + noticeManager.Err);
				return;
			}
			if (al.Count > 0)
			{
				this.NoticeInfo = al;
				this.iReadBottom = 0;
				this.iReadTop = this.noticeInfo.Count - 1;
				this.readIndex = this.noticeInfo.Count;
			}
		}

		private void SetNewNoticeLabel()
		{
			this.lbNewNotice.Text = "您有" + this.readIndex.ToString() + "条未读信息";
		}


		private void frmNotice_Load(object sender, EventArgs e)
		{
			if (this.ucNotice1 != null)
				this.ucNotice1.OnlyShow = true;
            try
            {
                this.dateTimePicker2.Value = this.noticeManager.GetDateTimeFromSysDateTime();
                this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-30);

                this.SetDateSelect = true;
            }
            catch { }
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			if (this.iArrayIndex == this.iReadTop)		//由数组内最后一个元素索引开始 al.count
			{
				this.iReadTop = this.iArrayIndex - 1;
			}
			if (this.iArrayIndex == this.iReadBottom)	//由数组内最前一个元素索引开始 0 
			{
				this.iReadBottom = this.iArrayIndex + 1;
			}
			if (this.readIndex > 0)
			{
				this.readIndex = this.readIndex - 1;
				this.btnNext_Click(null,System.EventArgs.Empty);
			}
			else
			{
				this.btnRead.Enabled = false;
			}

			this.SetNewNoticeLabel();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (this.noticeInfo.Count > 1)
			{
				int i;
				this.iArrayIndex = System.Math.DivRem(this.iArrayIndex + 1,this.noticeInfo.Count,out i);
				this.iArrayIndex = i;
				this.ucNotice1.Notice = this.noticeInfo[this.iArrayIndex] as Neusoft.HISFC.Models.Base.Notice;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (this.noticeInfo != null && this.noticeInfo.Count > 0 && this.readIndex >= 0)
			{
				DateTime dtEnd = new DateTime(2005,01,01);
				if (this.iReadTop <= this.noticeInfo.Count)
					dtEnd = (this.noticeInfo[this.iReadTop] as Neusoft.HISFC.Models.Base.Notice).NoticeDate;
				Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("NoticeSetting",this.ckShowEveryDay.Checked.ToString(),dtEnd.ToString());
			}
			this.Close();
		}

		private void btnQuery_Click(object sender, EventArgs e)
		{
			this.GetNotice();

			using(Manager.Notice.frmNoticeManager frm = new frmNoticeManager())
			{
				frm.OnlyShow = true;
				Neusoft.HISFC.Models.Base.Notice info = new Neusoft.HISFC.Models.Base.Notice();
				info.NoticeTitle = "aaaaa";
				info.NoticeDate = this.noticeManager.GetDateTimeFromSysDateTime();
				info.NoticeInfo = "阿飞毒素幅度所附斯多夫撒阿发送毒发斯多夫缩短发送多幅撒";
				ArrayList al = new ArrayList();
				al.Add(info);
				al.Add("11");
				frm.ShowData(al);
				if (frm.NoticeInfo.Count > 0)
					frm.ShowDialog();
			}
		}
	}
}
