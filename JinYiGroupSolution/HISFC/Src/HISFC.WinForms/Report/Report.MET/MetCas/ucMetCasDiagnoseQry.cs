using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MET.MetCas
{
    public partial class ucMetCasDiagnoseQry : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasDiagnoseQry()
        {
            InitializeComponent();
            

        }
        protected override void  OnLoad(EventArgs e)
        {
            Neusoft.HISFC.BizLogic.Manager.Constant mgrCon = new Neusoft.HISFC.BizLogic.Manager.Constant();
            string strTitle = string.Empty;
            string hosNm = string.Empty;

            hosNm = mgrCon.GetHospitalName();
            if (string.IsNullOrEmpty(hosNm))
            {
                strTitle = "住院病人ICD类目顺位统计表";
            }
            else
            {
                strTitle = hosNm + "住院病人ICD类目顺位统计表";
            }

            dwMain.Modify("t_title.text = '" + strTitle + "'");
            base.OnLoad(e);
        }


        int intOrder = 0;
        string strOrder = string.Empty;

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
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

                }
                catch
                {
                    MessageBox.Show("请输入正确信息，不许输入特殊字符");
                    return -1;
                }
                strOrder = "前" + tbOrder.Text + "位";
            }

            base.OnRetrieve(base.beginTime, base.endTime, intOrder);
            this.dwMain.Modify("t_order.text = '" + strOrder + "'");
            
            return 1;

        }
    }
}
