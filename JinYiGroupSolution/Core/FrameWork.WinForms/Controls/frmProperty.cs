using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// frmProperty 的摘要说明。
	/// </summary>
	internal class frmProperty :Neusoft.FrameWork.WinForms.Forms.BaseForm
	{
		public System.Windows.Forms.PropertyGrid propertyGrid1;
		private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkUseDefault;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton btnRestore;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboControlList;
		private System.Windows.Forms.ToolTip toolTip1;
		private Neusoft.FrameWork.WinForms.Controls.NeuButton button1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;

		/// <summary>
		/// 窗体焦点控件
		/// </summary>
		public Control ControlToChange
		{
			set
			{
				int i = this.cboControlList.FindStringExact(Neusoft.FrameWork.WinForms.Controls.DesignControl.GetFullName(value,"", this.design.ContainerBox.Name));//value.Name + " " + value.GetType().FullName);
				this.cboControlList.SelectedIndex = i;
			}
		}

		/// <summary>
		/// 是否使用缺省窗体
		/// </summary>
		public bool isUseDefault
		{
			get
			{
				return this.chkUseDefault.Checked;
			}
			set
			{
				this.chkUseDefault.Checked = value;
			}
		}

		/// <summary>
		/// 当前控件设计类
		/// </summary>
		protected DesignControl design;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="design">当前控件设计类</param>
		public frmProperty(DesignControl design)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.design = design;
			this.cboControlList.Items.Clear();
//			this.cboControlList.Items.Add(Neusoft.FrameWork.WinForms.Controls.DesignControl.GetFullName(design.ContainerBox,"",this.design.ContainerBox.Name));//design.ContainerBox.Name + " " + design.ContainerBox.GetType().FullName);
			this.AddComboBoxItem(design.ContainerBox, true);

			if(this.cboControlList.Items.Count>0) this.cboControlList.SelectedIndex = 0;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmProperty));
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.chkUseDefault = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
			this.btnRestore = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.cboControlList = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(8, 64);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(312, 360);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
			// 
			// chkUseDefault
			// 
			this.chkUseDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkUseDefault.Location = new System.Drawing.Point(16, 8);
			this.chkUseDefault.Name = "chkUseDefault";
			this.chkUseDefault.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
			this.chkUseDefault.TabIndex = 1;
			this.chkUseDefault.Text = "使用默认窗体";
			this.chkUseDefault.CheckedChanged += new System.EventHandler(this.chkUseDefault_CheckedChanged);
			// 
			// btnRestore
			// 
			this.btnRestore.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnRestore.Location = new System.Drawing.Point(248, 8);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.Size = new System.Drawing.Size(72, 24);
			this.btnRestore.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
			this.btnRestore.TabIndex = 2;
			this.btnRestore.Text = "恢复配置";
			this.btnRestore.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// cboControlList
			// 
			this.cboControlList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboControlList.IsLike = true;
			this.cboControlList.Location = new System.Drawing.Point(8, 40);
			this.cboControlList.Name = "cboControlList";
			this.cboControlList.PopForm = null;
			this.cboControlList.IsShowCustomerList = false;
			this.cboControlList.ShowID = false;
			this.cboControlList.Size = new System.Drawing.Size(312, 20);
			this.cboControlList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
			this.cboControlList.TabIndex = 3;
			this.cboControlList.Tag = "";
			this.cboControlList.SelectedIndexChanged += new System.EventHandler(this.cboControlList_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(160, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
			this.button1.TabIndex = 4;
			this.button1.Text = "隐藏";
			this.button1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "自定义设置";
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2,
																						 this.menuItem4,
																						 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "打开";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "恢复上次配置";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "保存并退出";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// frmProperty
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(330, 431);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cboControlList);
			this.Controls.Add(this.chkUseDefault);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.btnRestore);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmProperty";
			this.ShowInTaskbar = false;
			this.Text = "设置";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProperty_KeyDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmProperty_Closing);
			this.Load += new System.EventHandler(this.frmProperty_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 恢复默认设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRestore_Click(object sender, System.EventArgs e)
		{
			design.ReadFile(true);
			string name = this.cboControlList.Text;//.Substring(0, this.cboControlList.Text.IndexOf(" "));
			GetPropertyGridItem(name, design.ContainerBox, true);
			this.isUseDefault = design.IsUseDefaultSetting;
		}

		/// <summary>
		/// 是否使用默认窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkUseDefault_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkUseDefault.Checked)
			{
				
				this.errorProvider1.SetError(this.chkUseDefault, "加载默认设置，需要重新打开窗体");
			}
			else
			{
				this.errorProvider1.SetError(this.chkUseDefault, "");
			}
			design.IsUseDefaultSetting = this.chkUseDefault.Checked;
		}

		/// <summary>
		/// 增加下拉框选项
		/// </summary>
		/// <param name="parentControl"></param>
		private void AddComboBoxItem(Control parentControl, bool IsAddParent)
		{
			if(IsAddParent)
			{
				this.cboControlList.Items.Add(Neusoft.FrameWork.WinForms.Controls.DesignControl.GetFullName(parentControl,"",design.ContainerBox.Name));
			}
			foreach(Control control in parentControl.Controls)
			{
				this.cboControlList.Items.Add(Neusoft.FrameWork.WinForms.Controls.DesignControl.GetFullName(control,"",design.ContainerBox.Name));//control.Name + " " + control.GetType().FullName);
				AddComboBoxItem(control,false);
			}
		}

		/// <summary>
		/// 下拉框SelectedIndex改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cboControlList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string name = this.cboControlList.Text;//.Substring(0, this.cboControlList.Text.IndexOf(" "));
			GetPropertyGridItem(name, design.ContainerBox, true);
			this.toolTip1.SetToolTip(sender as Control,this.cboControlList.Text);
		}

		/// <summary>
		/// 更新属性框
		/// </summary>
		/// <param name="control"></param>
		private void UpdateProperty(Control control)
		{
			control.Focus();
			design.DrawControlPoint(control);
			OwnControl ownControl = new OwnControl(design.GetIsUseDefaultTextSetting(control));

			ownControl.Control = control;
			this.propertyGrid1.SelectedObject = ownControl;
		}

		/// <summary>
		/// 找到符合条件的控件，更新属性框
		/// </summary>
		/// <param name="name"></param>
		/// <param name="parentControl"></param>
		/// <param name="IsCheckParentControl"></param>
		/// <returns></returns>
		private bool GetPropertyGridItem(string name, Control parentControl, bool IsCheckParentControl)
		{
			//检查父控件
			if(IsCheckParentControl)
			{
				if(name  == Neusoft.FrameWork.WinForms.Controls.DesignControl.GetFullName(parentControl,"",design.ContainerBox.Name))
				{
					UpdateProperty(parentControl);
					return true;
				}
			}

			//检查子控件
			foreach(Control control in parentControl.Controls)
			{
				if(name  == Neusoft.FrameWork.WinForms.Controls.DesignControl.GetFullName(control,"",design.ContainerBox.Name))//control.Name)
				{
					UpdateProperty(control);
					return true;
				}
				//嵌套循环
				if(GetPropertyGridItem(name, control, false)) return true;
			}
			return false;
		}

		private void frmProperty_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Alt && e.Control && e.KeyCode == Keys.W )
			{
				this.Close();
			}
		}

		/// <summary>
		/// 加载窗体时发生
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmProperty_Load(object sender, System.EventArgs e)
		{
			this.KeyPreview = true;
			this.notifyIcon1.Visible = false;
		}
		/// <summary>
		/// 显示图标
		/// </summary>
		/// <param name="b"></param>
		public void ShowNotify(bool b)
		{
            try
            {
                if (notifyIcon1 != null) this.notifyIcon1.Visible = b;
            }
            catch { }
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Hide();
            try
            {
                if (notifyIcon1 != null) this.notifyIcon1.Visible = true;
            }
            catch { }
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.Show();
            try
            {
            if (notifyIcon1 != null) this.notifyIcon1.Visible = false;
            }
            catch { }
		}

		private void frmProperty_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            try
            {
            if (notifyIcon1 != null) this.notifyIcon1.Visible = false;
        }
        catch { }
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.Show();
            try
            {
                if (notifyIcon1 != null) this.notifyIcon1.Visible = false;
            }
            catch { }
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			btnRestore_Click( sender, e);
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 属性窗属性值更改事件
		/// 当是否使用缺省文本属性改变时，保存是否使用缺省文本设置
		/// 当文本属性更改时，更新控件文本属性（因为不会自动更新）
		/// </summary>
		/// <param name="s"></param>
		/// <param name="e"></param>
		private void propertyGrid1_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			bool boolOld = false;
			bool boolNew = false;

			//是否使用缺省文本属性
			if(e.ChangedItem.Label == "IsUseDefaultText")
			{
				boolOld = (bool)e.OldValue;
				boolNew = (bool)e.ChangedItem.Value;
			}
			//展开文本属性
			else if(e.ChangedItem.Label == "ControlText")
			{
				ControlText OldText = (ControlText)e.OldValue;
				ControlText NewText = (ControlText)e.ChangedItem.Value;
				OwnControl ownControl = (OwnControl)this.propertyGrid1.SelectedObject;
				ownControl.ControlText = NewText;
				boolOld = OldText.IsUseDefaultText;
				boolNew = NewText.IsUseDefaultText;
			}
			//文本属性
			else if(e.ChangedItem.Label == "Text")
			{
				OwnControl ownControl = (OwnControl)this.propertyGrid1.SelectedObject;
				ControlText NewText = new ControlText((string)e.ChangedItem.Value,  ownControl.ControlText.IsUseDefaultText);
				ownControl.ControlText = NewText;
			}

			//保存到Xml文件
			if(boolOld != boolNew)
			{
				design.SaveIsUseDefaultTextSetting(this.cboControlList.Text, boolNew);
			}
		}
	}
}
