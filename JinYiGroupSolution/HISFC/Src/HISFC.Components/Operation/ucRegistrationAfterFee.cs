using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.HISFC.Models.Operation;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// 【功能说明：手术批费后直接登记】//{35F92442-637A-4017-9BD4-D8FE73B15D31}
    /// 【创建人：董国强】
    /// 【创建时间：2010-09-28】
    /// </summary>
    public partial class ucRegistrationAfterFee :  Neusoft.FrameWork.WinForms.Controls.ucBaseControl 
    {

        private OperationRecord operationRecord = new OperationRecord();
        private OperationAppllication operationAppllication = new OperationAppllication();
        
        public OperationAppllication OperationAppllication
        {
            set { this.ucRegistrationForm1.OperationApplication = value; }
        }
        /// <summary>
        /// 是否新录入
        /// </summary>
        public bool IsNew
        {
            get { return this.ucRegistrationForm1.IsNew; }
            set { this.ucRegistrationForm1.IsNew = value; }
        }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool IsCancled 
        {
            set { this.ucRegistrationForm1.IsCancled = value; }
        }


        public ucRegistrationAfterFee()
        {
            InitializeComponent();
        }




        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ucRegistrationForm1.Save() >= 0)
            {
                this.FindForm().Close();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.FindForm().Close();
        }


    }
}
