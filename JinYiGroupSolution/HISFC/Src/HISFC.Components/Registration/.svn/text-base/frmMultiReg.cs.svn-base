using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 多张号输入窗口
    /// </summary>
    public partial class frmMultiReg : Form
    {
        public frmMultiReg()
        {
            InitializeComponent();

            this.textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            this.button2.Click += new EventHandler(button2_Click);
            this.button2.KeyDown += new KeyEventHandler(button2_KeyDown);
        }

        /// <summary>
        /// 挂号数量
        /// </summary>
        public int RegNumber
        {
            get
            {
                return int.Parse(this.textBox1.Text.Trim());
            }
        }


        private int Valid()
        {
            string txt = this.textBox1.Text.Trim();

            try
            {
                int qty = int.Parse(txt);
                if (qty < 2 || qty >= 100)
                {
                    MessageBox.Show("输入挂号数量超出范围,请重新输入!", "提示");
                    return -1;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                MessageBox.Show("挂号数量必须是数字,且大于1,小于100!", "提示");
                return -1;
            }

            return 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Valid() == -1)
                {
                    this.textBox1.Focus();
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Valid() == -1)
            {
                this.textBox1.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button2_Click(new object(), new EventArgs());
            }
        }
    }
}