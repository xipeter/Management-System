using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucModifyRegInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 域
        //{971E891B-4E05-42c9-8C7A-98E13996AA17}
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        #endregion

        public ucModifyRegInfo()
        {
            InitializeComponent();
        }
        private int save()
        {
            this.ucRegPatientInfo1.save();
            return 1;
        }
        private void tbCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string cardNO = this.tbCardNO.Text.Trim();
           
            if (cardNO == "" || cardNO == null)
            {
                MessageBox.Show("请输入就诊卡号");
                return;
            }
            cardNO = cardNO.PadLeft(10,'0');
            this.tbCardNO.Text = cardNO;
            //{971E891B-4E05-42c9-8C7A-98E13996AA17}
            this.txtIDNO.Text = "";
            this.ucRegPatientInfo1.CardNO = cardNO;
        }
 

        protected override int OnSave(object sender, object neuObject)
        {
            this.save();

            return base.OnSave(sender, neuObject);
        }

        
        //{971E891B-4E05-42c9-8C7A-98E13996AA17}
        private void txtIDNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string idNO = this.txtIDNO.Text.Trim();
                string IdMessage = string.Empty;
                int returnValue = Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idNO, ref IdMessage);
                if (returnValue < 0)
                {
                    MessageBox.Show(IdMessage);
                    return;
                }

                Neusoft.HISFC.Models.RADT.PatientInfo p = this.radtIntegrate.QueryComPatientInfoByIDNO(idNO);

                if (p == null)
                {
                    MessageBox.Show("根据身份证查询患者信息出错" + this.radtIntegrate.Err);
                    return;
                }
                this.tbCardNO.Text = p.PID.CardNO;
                if (!string.IsNullOrEmpty(p.PID.CardNO))
                {
                    this.ucRegPatientInfo1.CardNO = p.PID.CardNO;
                }
            }
        }

        /// <summary>
        /// 打印{D2F77BDA-F5E5-48fe-AB73-B7FE6D92E6E2}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            this.ucRegPatientInfo1.PrintBar();
            return base.OnPrint(sender, neuObject);
        }
       

    }
}
