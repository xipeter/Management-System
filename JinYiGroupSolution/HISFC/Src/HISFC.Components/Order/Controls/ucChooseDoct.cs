using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucChooseDoct : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 选择医生的控件{D5517722-7128-4d0c-BBC4-1A5558A39A03}
        /// </summary>
        public ucChooseDoct()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.BizProcess.Integrate.Manager sysManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private Neusoft.HISFC.Models.Base.Employee myDoct = new Neusoft.HISFC.Models.Base.Employee();

        public Neusoft.HISFC.Models.Base.Employee ChooseDoct
        {
            get
            { 
                return this.myDoct; 
            }
            set 
            {
                this.myDoct = value;
            }
        }

        private void Init()
        {
            ArrayList alDoct = new ArrayList();
            alDoct = this.sysManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            this.cmbDoct.AddItems(alDoct);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.cmbDoct.Tag != null)
            {
                this.myDoct.ID = this.cmbDoct.Tag.ToString();
                this.myDoct.Name = this.cmbDoct.Text.ToString().Trim();
                this.myDoct = sysManager.GetEmployeeInfo(this.myDoct.ID);
                if (this.ParentForm != null)
                {
                    this.ParentForm.Close();
                }
            }
        }

        private void ucChooseDoct_Load(object sender, EventArgs e)
        {
            this.Init();
        }

    }
}

