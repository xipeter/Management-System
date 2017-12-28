using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPR
{
	/// <summary>
	/// frmPrintSet 的摘要说明。
	/// </summary>
	public class frmPrintSet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPrintSet()
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "边框样式：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "下划线",
            "无边框",
            "全边框"});
            this.comboBox1.Location = new System.Drawing.Point(112, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "左 空 白：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "50";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 21);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "100";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "右 空 白：";
            // 
            // frmPrintSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(264, 198);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmPrintSet";
            this.Text = "打印设置";
            this.Load += new System.EventHandler(this.frmPrintSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public int BorderStyle = 0;
		public new int Left
		{
			get
			{
				return Neusoft.FrameWork.Function.NConvert.ToInt32(this.textBox1.Text);
			}
		}
		public new int Top
		{
			get
			{
				return Neusoft.FrameWork.Function.NConvert.ToInt32(this.textBox2.Text);
			}
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			this.BorderStyle = this.comboBox1.SelectedIndex;
		}

		private void frmPrintSet_Load(object sender, System.EventArgs e)
		{
            //Neusoft.HISFC.Integrate.Manager p = new Neusoft.HISFC.Integrate.Manager();
            
			//Neusoft.HISFC.Models.Base.PageSize page = p.GetPageSize("EMRPage");
            //this.textBox1.Text = page.Left.ToString() ;
            //this.textBox2.Text = page.Top.ToString();
			
            //this.comboBox1.SelectedIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(page.Printer);
		}
	}
}
