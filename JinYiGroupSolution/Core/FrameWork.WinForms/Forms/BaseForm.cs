using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Forms
{

	
    /// <summary>
    /// [功能描述: 	
    /// 基类窗口 created by wolf 2004-6-21
    /// 添加控制窗口控件功能
    /// 实现Ctrl+Alt+W进入界面设置功能]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public class BaseForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		/// <summary>
		/// 
		/// </summary>
		public BaseForm()
		{

			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.AutoScaleMode = AutoScaleMode.None ;
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
		}


		~BaseForm()
		{
			GC.Collect();
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

			//窗口关闭时,强制进行垃圾收集.cuipeng test this function 2005-4-30
			GC.Collect();
		}
		
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.Closed += new System.EventHandler(this.BaseForm_Closed);
            this.ResumeLayout(false);

		}
		#endregion
      

        //*************下面是全局变量传递过来需要调用的*****************
		/// <summary>
		/// 设置控件
		/// </summary>
		protected Neusoft.FrameWork.WinForms.Controls.DesignControl DisignControl;
		private void BaseForm_Load(object sender, System.EventArgs e)
		{
            this.iniForm();
            this.iniControlText(this);
			this.KeyPreview = true;
			this.KeyDown+=new KeyEventHandler(BaseForm_KeyDown);
		}

        /// <summary>
        /// 设置Text
        /// </summary>
        /// <param name="control"></param>
        public void iniControlText(object control)
        {
            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD}  多语言实现方式变更 基于.Net 本地化平台方案，不采用自动转换方式以保证界面展现效果
            return;

            if (Neusoft.FrameWork.Management.Language.IsUseLanguage == false)
            {
                return;
            }

            this.ReplaceText(control);
            Control c = control as Control;
            if (c != null && c.Controls.Count>0)
            {
                foreach (Control c1 in c.Controls)
                {
                    this.iniControlText(c1);
                }
            }
        }

        /// <summary>
        /// 替换
        /// </summary>
        protected void ReplaceText(object c)
        {
            try
            {
                if (c.GetType().IsSubclassOf(typeof(TabPage)) 
                    || c.GetType().IsSubclassOf(typeof(Label))
                    || c.GetType().IsSubclassOf(typeof(ButtonBase))
                    || c.GetType() == typeof(TabPage)
                    || c.GetType() == typeof(Label))
                {
                    Control control = c as Control;
                    control.Text = Neusoft.FrameWork.Management.Language.Msg(control.Text);

                }
                else if (c.GetType().IsSubclassOf(typeof(ToolBar)) || c.GetType() == typeof(ToolBar))
                {
                    ToolBar tb = c as ToolBar;
                    foreach (ToolBarButton button in tb.Controls)
                    {
                        button.Text = Neusoft.FrameWork.Management.Language.Msg(button.Text);
                        button.ToolTipText = Neusoft.FrameWork.Management.Language.Msg(button.ToolTipText);
                    }
                }
                else if (c.GetType().IsSubclassOf(typeof(ToolStrip)) || c.GetType() == typeof(ToolStrip))
                {
                    ToolStrip ts = c as ToolStrip;
                    foreach (ToolStripItem button in ts.Items)
                    {
                        button.Text = Neusoft.FrameWork.Management.Language.Msg(button.Text);
                        button.ToolTipText = Neusoft.FrameWork.Management.Language.Msg(button.ToolTipText);
                    }
                }
                else if (c.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)) || c.GetType() == typeof(FarPoint.Win.Spread.FpSpread))
                {
                    //暂时屏蔽该部分代码 以下代码放开后导致DataSet绑定到FarPoint后，列标题保持A、B、C不变

                    //FarPoint.Win.Spread.FpSpread fp = c as FarPoint.Win.Spread.FpSpread;
                    //foreach (FarPoint.Win.Spread.SheetView sv in fp.Sheets)
                    //{
                    //    foreach (FarPoint.Win.Spread.Column column in sv.Columns)
                    //    {
                    //        column.Label = Neusoft.FrameWork.Management.Language.Msg(column.Label);
                    //    }
                    //}
                }
            }
            catch { }
            //else if (c.GetType().IsSubclassOf(GroupBox))
            //{

            //}  //else if (c.GetType().IsSubclassOf(Panel))
            //{

            //}//else if (c.GetType().IsSubclassOf(MainMenu))
            //{

            //}
            //else if (c.GetType().IsSubclassOf(MainMenuStrip))
            //{

            //}
            //if (c.GetType().IsSubclassOf(TextBoxBase))
            //{

            //}

        }

        /// <summary>
        /// 初始化Designer
        /// </summary>
        public void iniForm()
        {
            try
            {
                DisignControl = new Neusoft.FrameWork.WinForms.Controls.DesignControl(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
		private void BaseForm_Closed(object sender, System.EventArgs e) 
		{
            try
            {
                this.DisignControl.Dispose();
            }
            catch { }
		}

		private void BaseForm_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Alt && e.Control && e.KeyCode == Keys.W )
			{
				DisignControl.IsDesignMode = !DisignControl.IsDesignMode;
			}
			else if(e.KeyCode == Keys.F4)
			{
				if(DisignControl.IsDesignMode)
					DisignControl.IsShowPropertyForm = true;
			}
		}
	}
	
	
}
