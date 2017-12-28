using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
namespace Neusoft.FrameWork.EPRControl
{
    public partial class EmrAddTextBox : AlphaBlendTextBox
    {
        public EmrAddTextBox()
        {
            
            this.init();
        }

        public EmrAddTextBox(IContainer container)
        {
            container.Add(this);

            
            this.init();
        }

        private void init()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // this.Multiline = true;


        }
        public int InitWidth
        {
            get
            {
                return 16;
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            //System.Drawing.Graphics g = this.CreateGraphics();
            //g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Blue, 4), new System.Drawing.Point(2, this.Height - 10), new System.Drawing.Point(this.Width, this.Height - 10));
            base.OnPaint(e);
        }
        private bool isAutoSize = false;

        public bool IsAutoSize
        {
            get { return isAutoSize; }
            set { isAutoSize = value; }
        }

        protected override void OnEnter(EventArgs e)
        {
            this.isAutoSize = true;
            base.OnEnter(e);

        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.isAutoSize)
            {
                System.Drawing.Graphics g = this.CreateGraphics();
                //利用Messure判断字体大小来变化
                //this.Width = base.TextLength * (int)g.MeasureString("李",base.Font).Width + 2;
                //if (this.Lines.Length >0)
                //this.Height = this.Lines.Length * (base.Font.Height);
                byte[] bb = System.Text.Encoding.Default.GetBytes(base.Text);
                if (base.Width < bb.Length * (int)g.MeasureString("李", base.Font).Width + InitWidth)
                    base.Width = bb.Length * ((int)g.MeasureString("李", base.Font).Width / 2) + InitWidth;
            }
            base.OnTextChanged(e);
        }
    }
}
