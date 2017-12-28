using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public delegate void myTipEvent(string Tip, int Hypotest);
    /// <summary>
    /// 提示修改控件
    /// </summary>
    public partial class ucTip : UserControl
    {
        public ucTip()
        {
            InitializeComponent();
        }

        public event myTipEvent OKEvent;

        private void ucTip_Load(object sender, EventArgs e)
        {
            //{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
            if (this.FindForm() != null)
            {
                this.FindForm().Activated += new EventHandler(ucTip_Activated);
            }
        }
        protected string defaultTip = "?";
        /// <summary>
        /// 默认提示
        /// </summary>
        public string DefaultTip
        {
            get
            {
                return this.defaultTip;
            }
            set
            {
                this.defaultTip = value;
            }
        }

        /// <summary>
        /// 批注
        /// </summary>
        public string Tip
        {
            set
            {
                if (value == "") value = defaultTip;
                this.rtb.Text = value;
            }
            get
            {
                return this.rtb.Text;
            }
        }
        /// <summary>
        /// 是否可以修改皮试结果
        /// </summary>
        public bool IsCanModifyHypotest
        {
            get
            {
                return this.neuGroupBox1.Enabled;
            }
            set
            {
                this.neuGroupBox1.Enabled = value;
                this.chkHypotest.Enabled = !value;

            }
        }

        /// <summary>
        /// 皮试结果
        /// </summary>
        public int Hypotest
        {
            get
            {
                if (this.chkHypotest.Checked == false)
                {
                    return 1;
                }
                else
                {
                    if (this.rdo1.Checked)
                    {
                        return 3;
                    }
                    else if (this.rdo2.Checked)
                    {
                        return 4;
                    }
                    return 2;
                }
            }
            set
            {
                if (value <= 1)//if (value == 1) //{7D04C498-DB29-4dc9-B636-F96F0FDEE8E9}
                {
                    //{FC21CC20-38F0-4e97-8432-235F3BEC04A9}
                    this.chkHypotest.Checked = false;
                    if (this.tabControl1.TabPages.Contains(this.tabPage2))
                        this.tabControl1.TabPages.Remove(this.tabPage2);
                }
                else
                {
                    this.chkHypotest.Checked = true;
                    if (value == 3)
                    {
                        this.rdo1.Checked = true;
                    }
                    else if (value == 4)
                    {
                        this.rdo2.Checked = true;
                    }
                }
            }
        }
        
        

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Neusoft.FrameWork.Public.String.ValidMaxLengh(Tip, 80) == false)
                {
                    MessageBox.Show("批注只能录入40个汉字!", "提示");
                    return;
                }
                this.OKEvent(Tip, Hypotest);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
            if (this.FindForm() == Neusoft.FrameWork.WinForms.Classes.Function.PopForm)
            {
                this.FindForm().Close();
            }
        }

       

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            this.neuGroupBox1.Enabled = this.chkHypotest.Checked;
        }

        private void ucTip_Activated(object sender, EventArgs e)
        {
            this.rtb.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
            if (this.FindForm() == Neusoft.FrameWork.WinForms.Classes.Function.PopForm)
            {
                this.FindForm().Close();
            }
        }


    }
}
