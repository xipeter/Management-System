using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
namespace Neusoft.HISFC.Components.EPR
{
	public delegate void NameChangedHandler(int index,string newName);
	public delegate void DeleteHandler(int index);
	/// <summary>
	/// ucEMRManager 的摘要说明。
	/// </summary>
	public class ucEMRManager : System.Windows.Forms.UserControl
	{
		internal System.Windows.Forms.Button btnName;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.CheckBox CheckBox2;
		internal System.Windows.Forms.Button btnDel;
		internal System.Windows.Forms.CheckBox CheckBox1;
		internal System.Windows.Forms.ListBox ListBox1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.ErrorProvider errorProvider1;
        private IContainer components;
		public event NameChangedHandler NameChangedEvent;
        public event DeleteHandler DeleteEvent;
		/// <summary>
		/// 当前类型
		/// </summary>
		/// <param name="Type"></param>
		public ucEMRManager(string Type)
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			_type = Type;
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
            this.components = new System.ComponentModel.Container();
            this.btnName = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnName
            // 
            this.btnName.Enabled = false;
            this.btnName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnName.Location = new System.Drawing.Point(64, 40);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(80, 23);
            this.btnName.TabIndex = 19;
            this.btnName.Text = "确定";
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(165, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 24);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(64, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(80, 21);
            this.txtName.TabIndex = 17;
            this.txtName.Text = "新名称";
            // 
            // CheckBox2
            // 
            this.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBox2.Location = new System.Drawing.Point(8, 16);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(48, 24);
            this.CheckBox2.TabIndex = 16;
            this.CheckBox2.Text = "改名";
            this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDel.Location = new System.Drawing.Point(64, 16);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(80, 23);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "确定";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // CheckBox1
            // 
            this.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBox1.Location = new System.Drawing.Point(8, 16);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(48, 24);
            this.CheckBox1.TabIndex = 13;
            this.CheckBox1.Text = "删除";
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // ListBox1
            // 
            this.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox1.ItemHeight = 12;
            this.ListBox1.Location = new System.Drawing.Point(15, 18);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(144, 182);
            this.ListBox1.TabIndex = 11;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CheckBox2);
            this.GroupBox1.Controls.Add(this.txtName);
            this.GroupBox1.Controls.Add(this.btnName);
            this.GroupBox1.Location = new System.Drawing.Point(165, 74);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(152, 70);
            this.GroupBox1.TabIndex = 20;
            this.GroupBox1.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.CheckBox1);
            this.GroupBox2.Controls.Add(this.btnDel);
            this.GroupBox2.Location = new System.Drawing.Point(165, 18);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(152, 56);
            this.GroupBox2.TabIndex = 21;
            this.GroupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnExport);
            this.groupBox3.Location = new System.Drawing.Point(0, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 56);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "高级";
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Location = new System.Drawing.Point(15, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 24);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "编辑...";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucEMRManager
            // 
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Name = "ucEMRManager";
            this.Size = new System.Drawing.Size(336, 267);
            this.Load += new System.EventHandler(this.ucEMRManager_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ucEMRManager_Load(object sender, System.EventArgs e)
		{
            //if(this.ParentForm!=null && this.ParentForm.Text =="")
            //    this.ParentForm.Text ="文件管理";
            //try
            //{
            //    //this.groupBox3.Enabled = ((Neusoft.HISFC.Models.RADT.Person)Neusoft.FrameWork.Management.Connection.Operator).isManager;
            //}
            //catch{}
            //try
            //{
            //    if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetMedicalPermission(Neusoft.HISFC.Models.EPR.EnumPermissionType.EMR, 6) == false)
            //    {
            //        this.GroupBox1.Enabled = false;
            //        this.GroupBox2.Enabled = false;
            //        this.errorProvider1.SetError(this.btnClose,"您没有管理病历的权限！");
            //    }
            //    this.groupBox3.Visible = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).IsManager;
            //}
            //catch{}

		}
		
		
		#region 属性
		protected string _inpatientNo;
		protected string _type;

		/// <summary>
		/// 设置患者住院流水号
		/// </summary>
		public string InpatientNo
		{
			set
			{
				_inpatientNo = value;
				GetEmrList();
			}
		}
        private TemplateDesignerApplication.DataFileManager manager = new TemplateDesignerApplication.DataFileManager();
		/// <summary>
		/// 获得文件列表
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <returns></returns>
		protected int GetEmrList()
		{
			if(_type =="")
			{
				MessageBox.Show("没有设置类别！");
				return -1;
			}
			if(manager.SetType(_type)==-1)
			{
				MessageBox.Show(manager.Err);
				return -1;
			}

			if(manager.GetFiles(_inpatientNo)>0)//获得文件列表
			{
				this.ListBox1.Items.Clear();
				for(int i=0;i<manager.alFiles.Count;i++)
				{
					this.ListBox1.Items.Add(manager.alFiles[i]);
				}
			}
			return 0;
		}
		#endregion

		#region 事件
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtName.Enabled = this.CheckBox2.Checked;
			this.btnName.Enabled = this.CheckBox2.Checked;
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.btnDel.Enabled = this.CheckBox1.Checked;
		}
		
		/// <summary>
		/// 关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.ParentForm.Close();
		}
		/// <summary>
		/// 更改名字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnName_Click(object sender, System.EventArgs e)
		{
			
			Neusoft.HISFC.Models.File.DataFileInfo obj = this.ListBox1.SelectedItem as Neusoft.HISFC.Models.File.DataFileInfo;
			if(obj ==null || this.txtName.Text =="")
			{
				return;
			}
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
			
			obj.Name = this.txtName.Text;
			try
			{
				if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.SetFile(obj)==-1)
				{
					Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
					MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				}
				else
				{
                    Neusoft.HISFC.BizProcess.Factory.Function.Commit();
					this.ListBox1.Items[this.ListBox1.SelectedIndex]=obj;
					MessageBox.Show("修改成功！");
					try
					{
                        NameChangedEvent(this.ListBox1.SelectedIndex, obj.Name);
					}
					catch{}
				}
			}
			catch
			{
				Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
			}
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			Neusoft.HISFC.Models.File.DataFileInfo obj = this.ListBox1.SelectedItem as Neusoft.HISFC.Models.File.DataFileInfo;
			if(obj ==null || this.txtName.Text =="")
			{
				return;
			}
			int index = this.ListBox1.SelectedIndex;
			
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
			
			obj.Name = this.txtName.Text;
			try
			{
				if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.UpdateQCDataState(obj.ID,3)==-1)
				{
                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
					MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
					return;
				}
				if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteFile(obj.ID,0)==-1)
				{
                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
					MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
					return;
				}


				//删除节点
				if(obj.Param.Name!="")
				{
					if(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteAllNodeFromDataStore(obj.Param.Name,obj)==-1)
					{
						Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
						MessageBox.Show(manager.Err);
						return;
					}
				}

                Neusoft.HISFC.BizProcess.Factory.Function.Commit();
				this.ListBox1.Items.RemoveAt(index);
				MessageBox.Show("删除成功！");
				try
				{
                    DeleteEvent(index);
				}
				catch{}
			
			}
			catch
			{
				Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
				MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
				return;
			}
		}

		

		#endregion

		#region 导入，导出管理
		
		private void btnExport_Click(object sender, System.EventArgs e)
		{
            Neusoft.HISFC.Models.File.DataFileInfo obj = this.ListBox1.SelectedItem as Neusoft.HISFC.Models.File.DataFileInfo;
            if (obj == null || this.txtName.Text == "")
            {
                return;
            }
            obj.Data = TemplateDesignerHost.Function.LoadFileCheckFile(obj, false);
             
            TemplateDesignerApplication.frmModifyModual form = new TemplateDesignerApplication.frmModifyModual(obj);
            form.ShowDialog(this);
		}
		#endregion

        

	
	}
}
