using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// NeuLabelTextBox<br></br>
    /// [功能描述: NeuLabelTextBox控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-09-07]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.ComponentModel.DefaultEvent("TextChanged"),
    System.ComponentModel.DefaultProperty("Label"),
    ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
    public partial class NeuLabelTextBox : UserControl
    {
        public NeuLabelTextBox()
        {
            InitializeComponent();
        }
        private StyleType styleType;

        [System.ComponentModel.Browsable(true)]
        public new event EventHandler TextChanged;

        #region 属性
        /// <summary>
        /// 文本
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        public override string Text
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }

        /// <summary>
        /// 文本框左边距
        /// </summary>
        public int TextBoxLeft
        {
            get
            {
                return this.textBox1.Left;
            }
            set
            {
                this.textBox1.Left = value;
                this.Width = this.textBox1.Left + this.textBox1.Width + 2;
            }
        }

        /// <summary>
        /// 只读
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return this.textBox1.ReadOnly;
            }
            set
            {
                this.textBox1.ReadOnly = value;
            }
        }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength
        {
            get
            {
                return this.textBox1.MaxLength;
            }
            set
            {
                this.textBox1.MaxLength = value;
            }
        }

        public Color LabelForeColor
        {
            get
            {
                return this.label1.ForeColor;
            }
            set
            {
                this.label1.ForeColor = value;
            }
        }
        #endregion
        #region INeuControl 成员

        public Neusoft.FrameWork.WinForms.Controls.StyleType Style
        {
            get
            {
                return this.styleType;
            }
            set
            {
                this.styleType = value;
                this.textBox1.Style = value;
            }
        }

        #endregion
        #region 事件

        protected override void OnSizeChanged(EventArgs e)
        {
            this.textBox1.Width = this.Width - this.textBox1.Left;
            base.OnSizeChanged(e);
        }

        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            //base.OnTextChanged(e);
            this.TextChanged(this, e);
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
        #endregion
    }
}
