using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MET.MetCas
{
    public partial class ucMetCasStatDead3 : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasStatDead3()
        {
            InitializeComponent();
        }

        private string strIcd = string.Empty;
        private string strOrder = string.Empty;
        private int intOrder = 0;
        

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            if (string.IsNullOrEmpty( this.tbIcd.Text))
            {
                strIcd = "%%";
            }
            else
            {
                strIcd = "%" + tbIcd.Text.Trim() + "%";
              
            }

            if (string.IsNullOrEmpty(this.tbOrder.Text))
            {
                intOrder = 0;
                strOrder = "全部";
            }
            else
            { 
                try
                {
                    intOrder = Neusoft.FrameWork.Function.NConvert.ToInt32(tbOrder.Text);
                    
                }catch
                {
                     MessageBox.Show("请输入正确信息，不许输入特殊字符");
                     return -1;
                }
                strOrder = "前" + tbOrder.Text + "位";
            }

             base.OnRetrieve(base.beginTime, base.endTime, strIcd, intOrder);
             this.dwMain.Modify("t_order.text = '" + strOrder + "'");
             return 1;

        }
    }
}
