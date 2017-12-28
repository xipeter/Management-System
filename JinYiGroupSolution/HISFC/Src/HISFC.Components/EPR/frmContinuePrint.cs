using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// frmContinuePrint 的摘要说明。
	/// </summary>
	internal class frmContinuePrint : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox chkTitile;
        private TabPage tabPage2;
        private PictureBox pictureBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
        private System.ComponentModel.Container components = null;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private TrackBar trackBar1;
        private Control panel = null;
		public frmContinuePrint(RichTextBox c,Control panel)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            this.panel = panel;

			this.richBox = c;

			this.richTextBox1.Rtf = c.Rtf;
			this.richTextBox1.Width = c.Width;

			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionProtected = true;
			
			this.SetColor(Neusoft.FrameWork.Function.NConvert.ToInt32(c.Tag));

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		private void SetColor(int iLength)
		{
			this.iLength = iLength;

			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionProtected = false;
		
			this.richTextBox1.Select(0,iLength);
			this.richTextBox1.SelectionColor = Color.Red;
			this.richTextBox1.Select(iLength+1,this.richTextBox1.TextLength - iLength);
			this.richTextBox1.SelectionColor = Color.Black;
			
			
			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionProtected = true;
			this.richTextBox1.Select(this.richTextBox1.SelectionStart,0);
		

		}
		private RichTextBox richBox = null;
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkTitile = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 554);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.chkTitile);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(574, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkTitile
            // 
            this.chkTitile.Location = new System.Drawing.Point(192, 16);
            this.chkTitile.Name = "chkTitile";
            this.chkTitile.Size = new System.Drawing.Size(80, 24);
            this.chkTitile.TabIndex = 4;
            this.chkTitile.Text = "打印标头";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(269, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "红色的代表已经打印，用鼠标点击设置打印起始位置";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(18, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 482);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            this.richTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDown);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(136, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "从第几页开始打印：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trackBar1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.numericUpDown2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(574, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "预览";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(445, 30);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(129, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "页码：";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown2.Location = new System.Drawing.Point(523, 3);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(404, 526);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(403, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "打印";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(484, 560);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "退出";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmContinuePrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(582, 599);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmContinuePrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "续打设置窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	

        #region continuePrint
        protected System.Windows.Forms.RichTextBox getRichtTextBox(Neusoft.FrameWork.EPRControl.emrPanel panel)
        {
            if (panel == null) return null;
            foreach (Component c in panel.Components)
            {
                if (c.GetType().IsSubclassOf(typeof(RichTextBox)))
                    return c as RichTextBox;

            }
            return null;
        }
        private void continuePrint(Control c, int page, bool bTitle, Control panel)
        {
            ((Neusoft.FrameWork.EPRControl.emrPanel)panel).AutoScrollPosition = new Point(0, 0);

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            //if (page == 0) page = 1;
            Common.Classes.Function.GetPageSize("EMR", ref print);
            //print.PrintDocument.DefaultPageSettings.PrinterSettings.FromPage = page;
            //print.PrintDocument.DefaultPageSettings.PrinterSettings.ToPage = 100;
            print.IsPrintInputBox = !bTitle;
            print.IsPrintBackImage = false;
            print.IsDataAutoExtend = false;
            print.IsHaveGrid = true;
            if (bTitle == false)
                setOtherControlVisible(false, panel);
            ((RichTextBox)c).Select(0, 0);
            ((RichTextBox)c).ScrollToCaret();

            Neusoft.FrameWork.WinForms.Classes.PrintControlCompare p = new Neusoft.FrameWork.WinForms.Classes.PrintControlCompare();
            p.SetEPRControl();
            print.SetControlCompare(p);

            print.PageLabel = ((Neusoft.FrameWork.EPRControl.emrPanel)panel).PageNumberControl;
            //print.DrawGraphic(this.pictureBox1.CreateGraphics(),panel);
            string file = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.TempPath + "1.bmp";
            print.SaveAsFile(panel, file,page);
            System.IO.StreamReader reader = new System.IO.StreamReader(file);

            this.pictureBox1.Image = Image.FromStream(reader.BaseStream);
            reader.Close();
            if (bTitle == false) setOtherControlVisible(true, panel);
            c.Tag = this.StartLength;
        }
        ArrayList alForVisibleControls = null;
        private void setOtherControlVisible(bool bVisible, Control panel)
        {
            if (panel == null) return;

            if (bVisible == false)
            {
                alForVisibleControls = new ArrayList();
                foreach (Control c in ((Neusoft.FrameWork.EPRControl.emrPanel)panel).Controls)
                {
                    Neusoft.FrameWork.EPRControl.IUserControlable ip = c as Neusoft.FrameWork.EPRControl.IUserControlable;
                    if (ip != null)
                    {
                        if (ip.FocusedControl.GetType().IsSubclassOf(typeof(RichTextBox)) == false)
                        {
                            if (c.Visible)
                            {
                                this.alForVisibleControls.Add(c.Handle);
                                c.Visible = false;
                            }
                        }

                    }
                    else
                    {
                        if (c.GetType().IsSubclassOf(typeof(RichTextBox)) == false)
                        {
                            if (c.Visible)
                            {
                                c.Visible = false;
                                this.alForVisibleControls.Add(c.Handle);
                            }
                        }

                    }
                }
            }
            else
            {
                foreach (Control c in ((Neusoft.FrameWork.EPRControl.emrPanel)panel).Controls)
                {
                    if (c.GetType().IsSubclassOf(typeof(RichTextBox)) == true)
                    {

                    }
                    else
                    {
                        if (alForVisibleControls == null) return;
                        foreach (System.IntPtr handle in alForVisibleControls)
                        {
                            if (c.Handle == handle)
                            {
                                c.Visible = true;
                                break;
                            }
                        }

                    }
                }

            }

        }
        #endregion

        #region 函数
        
        private void richTextBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
		}

		private void richTextBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.SetColor(this.richTextBox1.SelectionStart);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
		private int iLength = 0;
		public int StartLength
		{
			get
			{
				return iLength;
			}
		}
		public int StartPage
		{
			get
			{
				return (int)this.numericUpDown1.Value;
			}
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

        
      
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.richBox.Tag = this.StartLength;

                this.continuePrint(this.richBox, (int)this.numericUpDown2.Value - 1, this.chkTitile.Checked, this.panel);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.richBox.Tag = this.StartLength;

            this.continuePrint(this.richBox, (int)this.numericUpDown2.Value-1, this.chkTitile.Checked, this.panel);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown2.Minimum = this.numericUpDown1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            decimal scale = (decimal)this.trackBar1.Value / 10 +1;
            decimal width = 400 * scale;
            decimal height = 500 * scale;
            this.pictureBox1.Size = new Size((int)width,(int)height);
            this.trackBar1.BringToFront();
        }

      
    }
}
