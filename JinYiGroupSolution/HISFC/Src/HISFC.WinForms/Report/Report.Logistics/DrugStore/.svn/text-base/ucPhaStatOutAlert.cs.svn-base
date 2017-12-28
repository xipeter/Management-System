using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucPhaStatOutAlert : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaStatOutAlert()
        {
            InitializeComponent();

        }
     protected Neusoft.HISFC.Models.Base.Employee employee = null;

     protected override int OnRetrieve(params object[] objects)
        {
            if (textBox1.Text == null && textBox1.Text == "")
            {
                MessageBox.Show("请输入比较天数！");
                this.textBox1.Focus();
                return -1;
            }
            int num = 0;

            if (!int.TryParse(textBox1.Text, out num))
            {
                MessageBox.Show("只能输入数字");
                this.textBox1.Focus();
                return -1;
            }

            if (Convert.ToInt32(textBox1.Text) > 999999)
            {
                MessageBox.Show("比较天数不能超过最大值999999天，请重新输入");
                this.textBox1.Focus();
                return -1;
            }
            this.employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;
            return base.OnRetrieve(System.DateTime.Now,Convert.ToInt32(textBox1.Text),employee.Dept.ID);
        }
       
    }
}

