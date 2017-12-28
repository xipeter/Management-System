using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// ucTextToolBar 的摘要说明。
	/// </summary>
	public class ucTextToolBar : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox cmdLevel;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components;
		public event System.EventHandler EventReturn;
		public ucTextToolBar()
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
			this.components = new System.ComponentModel.Container();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.btnShow = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmdLevel = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnShow
			// 
			this.btnShow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnShow.Location = new System.Drawing.Point(24, 8);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(88, 24);
			this.btnShow.TabIndex = 1;
			this.btnShow.Text = "突出显示";
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(120, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "删除线";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "上标",
														   "无",
														   "下标"});
			this.comboBox1.Location = new System.Drawing.Point(216, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(80, 20);
			this.comboBox1.TabIndex = 3;
			this.toolTip1.SetToolTip(this.comboBox1, "定义上标，下标");
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.White;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(312, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "字体...";
			this.toolTip1.SetToolTip(this.button2, "更改选择的字体");
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.checkBox1.Location = new System.Drawing.Point(8, 24);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 24);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "上级修订";
			this.toolTip1.SetToolTip(this.checkBox1, "上级修订，点击查看和修订");
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.btnShow);
			this.panel1.Location = new System.Drawing.Point(80, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(464, 40);
			this.panel1.TabIndex = 6;
			// 
			// cmdLevel
			// 
			this.cmdLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmdLevel.Items.AddRange(new object[] {
														  "住院医师",
														  "主治医师",
														  "主任医师"});
			this.cmdLevel.Location = new System.Drawing.Point(8, 24);
			this.cmdLevel.Name = "cmdLevel";
			this.cmdLevel.Size = new System.Drawing.Size(32, 20);
			this.cmdLevel.TabIndex = 5;
			this.cmdLevel.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.cmdLevel);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 64);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(552, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(40, 40);
			this.button3.TabIndex = 7;
			this.button3.Text = "返回";
			this.toolTip1.SetToolTip(this.button3, "返回病历操作界面");
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 1;
			this.toolTip1.ShowAlways = true;
			// 
			// ucTextToolBar
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "ucTextToolBar";
			this.Size = new System.Drawing.Size(600, 64);
			this.Load += new System.EventHandler(this.ucTextToolBar_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		bool bCanModified = false;
		private void ucTextToolBar_Load(object sender, System.EventArgs e)
		{
			this.comboBox1.SelectedIndex = 1;
			this.cmdLevel.SelectedIndex = 2;
            //bCanModified = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetMedicalPermission(Neusoft.HISFC.Models.EPR.EnumPermissionType.EMR, 5);
		}
		
		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
            //if(this.myCurrentPanel == null) return;
            //bool b = false;
            //foreach(Control c in myCurrentPanel.Components )
            //{
            //    Neusoft.FrameWork.EPRControl.IControlTextable ic = c as Neusoft.FrameWork.EPRControl.IControlTextable;
            //    if(ic!=null)
            //    {
            //        if(this.checkBox1.Checked)
            //        {
            //            if(this.cmdLevel.SelectedIndex <=0)
            //            {
            //                this.cmdLevel.SelectedIndex = 2;//主任医师，默认
            //            }
            //            if(this.cmdLevel.SelectedIndex == 1)
            //            {
            //                ic.ShowLevel2Text();
            //            }
            //            else if(this.cmdLevel.SelectedIndex == 2)
            //            {
            //                ic.ShowLevel1Text();
            //            }
            //            else
            //            {
            //                ic.ShowLevel2Text();
            //            }
						
            //        }
            //        else
            //        {
            //            ic.ShowLevel3Text();
            //        }
            //        b = true;
            //    }
            //}
            //if(b==false && this.checkBox1.Checked )
            //{
            //    MessageBox.Show("没有可以添加批注的地方！此病历也不提供批注功能。");
            //    this.checkBox1.Checked = false;
            //}
            //else if(this.checkBox1.Checked == false)
            //{
            //    this.panel1.Enabled = true;
            //}
            //else
            //{
            //    this.panel1.Enabled = this.bCanModified;
            //}
			
			
		}
		
		private Neusoft.FrameWork.EPRControl.emrPanel  myCurrentPanel = null;
		
		protected Color SHOWCOLOR = Color.Red;
		private void btnShow_Click(object sender, System.EventArgs e)
		{
            //if(myValue.GetType()==typeof(Neusoft.FrameWork.EPRControl.ucDiseaseRecord))
            //{
            //    this.CurrentControl = myValue;//重新读取
            //}
            //if(myCurrentControl == null) return;
            //if(currentIC!=null)currentIC.IsOnSaveSuperText = false;
			
            //if(myCurrentControl.SelectionColor == SHOWCOLOR)
            //{
            //    myCurrentControl.SelectionColor = Color.Black;
            //}
            //else
            //{
            //    myCurrentControl.SelectionColor = SHOWCOLOR;
            //}
		}
		protected RichTextBox myCurrentControl = null;

		private void button1_Click(object sender, System.EventArgs e)
		{
            //if(myValue.GetType()==typeof(Neusoft.FrameWork.EPRControl.ucDiseaseRecord))
            //{
            //    this.CurrentControl = myValue;//重新读取
            //}
            //if(myCurrentControl == null) return;
            //if(currentIC!=null)currentIC.IsOnSaveSuperText = false;

            //Font Font_delete = new Font(myCurrentControl.SelectionFont.FontFamily.Name , myCurrentControl.SelectionFont.Size,FontStyle.Strikeout);
            //if(!myCurrentControl.SelectionFont.Strikeout)
            //{
            //    myCurrentControl.SelectionFont = Font_delete;
            //    myCurrentControl.SelectionColor = Color.Blue;
            //}
            //else
            //{
            //    myCurrentControl.SelectionFont = new Font(myCurrentControl.SelectionFont.FontFamily.Name , myCurrentControl.SelectionFont.Size,FontStyle.Regular);;
            //    myCurrentControl.SelectionColor = Color.Black;
            //}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            //try
            //{
            //    if(this.myValue.GetType()==typeof(Neusoft.FrameWork.EPRControl.ucDiseaseRecord))
            //    {
            //        this.CurrentControl = myValue;//重新读取
            //    }
            //    if(currentIC!=null)currentIC.IsOnSaveSuperText = false;
            //    switch(this.comboBox1.SelectedIndex )
            //    {
            //        case 0:
            //            myCurrentControl.SelectionCharOffset = 4;
            //            myCurrentControl.SelectionFont = new Font(myCurrentControl.SelectionFont.FontFamily.Name ,7,myCurrentControl.SelectionFont.Style);;
            //            break;
            //        case 1:
            //            myCurrentControl.SelectionCharOffset = 0;
            //            myCurrentControl.SelectionFont = new Font(myCurrentControl.SelectionFont.FontFamily.Name ,9,myCurrentControl.SelectionFont.Style);;
            //            break;
            //        case 2:
            //            myCurrentControl.SelectionCharOffset = -4;
            //            myCurrentControl.SelectionFont = new Font(myCurrentControl.SelectionFont.FontFamily.Name ,7,myCurrentControl.SelectionFont.Style);;
            //            break;
            //    }
            //}
            //catch{}
		}

		public void button2_Click(object sender, System.EventArgs e)
		{
            //if(this.myValue.GetType()==typeof(Neusoft.FrameWork.EPRControl.ucDiseaseRecord))
            //{
            //    this.CurrentControl = myValue;//重新读取
            //}

            //if(myCurrentControl ==null && myCurrentTextControl==null) return;
            //if(currentIC!=null)currentIC.IsOnSaveSuperText = false;
			
            //if(myCurrentControl==null)
            //    this.fontDialog1.Font = myCurrentTextControl.Font;
            //else
            //    this.fontDialog1.Font = myCurrentControl.SelectionFont;

            //this.fontDialog1.ShowColor = true;
            //if(this.fontDialog1.ShowDialog()==DialogResult.OK)
            //{
            //    if(myCurrentControl!=null)
            //    {
            //        myCurrentControl.SelectionFont = this.fontDialog1.Font;
            //        myCurrentControl.SelectionColor = this.fontDialog1.Color; 
            //    }
            //    else
            //    {
            //        try
            //        {
            //            myCurrentTextControl.Font = this.fontDialog1.Font;
            //            myCurrentTextControl.ForeColor = this.fontDialog1.Color; 
            //        }
            //        catch{}
            //    }
			//}

		}
		private Control myCurrentTextControl = null;
		private Control myValue = null;
		/// <summary>
		/// 当前激活控件
		/// </summary>
		public object CurrentControl
		{
			set
			{
                //try
                //{
                //    myValue = value as Control ;
                //    if(value.GetType() == typeof(Neusoft.FrameWork.EPRControl.emrMultiLineTextBox))
                //    {
                //        myCurrentTextControl = null;
                //        myCurrentControl = value as RichTextBox;
                //    }
                //    else if(value.GetType() == typeof(RichTextBox))
                //    {
                //        myCurrentTextControl = null;
                //        myCurrentControl = value as RichTextBox;
                //    }
                //    else
                //    {
                //        currentIC = value as Neusoft.FrameWork.EPRControl.IControlTextable;
                //        if(currentIC !=null)
                //        {
                //            myCurrentTextControl = null;
                //            myCurrentControl  = currentIC.FocedControl as RichTextBox;	
                //        }
                //        else
                //        {
                //            myCurrentTextControl = value as Control;
                //            myCurrentControl = null;
                //        }
                //    }
					
                //}
                //catch(Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

			}
		}
		
		/// <summary>
		/// 当前Panel
		/// </summary>
		public Control CurrentPanel
		{
			set
			{
				if(value==null || value.Controls.Count<=0) this.myCurrentPanel = null;
				Reset();
				if(value!=null)this.myCurrentPanel = value.Controls[0] as Neusoft.FrameWork.EPRControl.emrPanel;
			}
		}
		public void Reset()
		{
			this.checkBox1.Checked = false;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if(EventReturn!=null)EventReturn(this,e);
		}

	}
}
