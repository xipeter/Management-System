using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Case
{
    public partial class ucCaseChangeConfirm : UserControl
    {
        public ucCaseChangeConfirm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseChangeManager changeManager = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseChangeManager();

            Neusoft.HISFC.Models.HealthRecord.Case.CaseChange change = changeManager.GetChangeApplyByOldCode(this.tbCard.Text.Trim());
            if( change == null )
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有找到病历更换申请信息"));
                return;
            }
        }
    }
}