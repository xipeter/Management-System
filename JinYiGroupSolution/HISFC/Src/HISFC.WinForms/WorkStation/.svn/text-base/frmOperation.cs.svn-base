using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.WinForms.WorkStation
{
    public partial class frmOperation : Neusoft.FrameWork.WinForms.Forms.BaseStatusBar
    {
        private Neusoft.HISFC.Components.Operation.ucApplicationForm ucApplyForm;
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        public frmOperation(Neusoft.HISFC.Models.RADT.PatientInfo pi)
        {
            InitializeComponent();
            this.patientInfo = pi;
        }

        private void frmOperation_Load(object sender, EventArgs e)
        {
            this.ucApplyForm = new Neusoft.HISFC.Components.Operation.ucApplicationForm();
            this.ucApplyForm.PatientInfo = this.patientInfo;
            this.neuPanel1.Controls.Add(this.ucApplyForm);
            this.ucApplyForm.AutoScroll = true;
            this.ucApplyForm.Dock = DockStyle.Fill;
        }

        private void neuToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Text.Trim())
            {
                case "保存":
                    if (this.ucApplyForm.Save() == 0)
                    {
                        MessageBox.Show("保存手术申请成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    break;
                case "退出":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}