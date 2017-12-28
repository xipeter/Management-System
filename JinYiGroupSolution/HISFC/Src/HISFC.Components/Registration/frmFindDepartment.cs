using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class frmFindDepartment : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmFindDepartment()
        {
            InitializeComponent();
            this.InitDept();
        }
        private void InitDept()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager DeptMananger = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList al = DeptMananger.QueryRegDepartment();
            this.neuCboDeptList.AddItems(al);
        }
        public string SelectedDepartment
        {
            get
            {
                if (this.neuCboDeptList.Tag == null)
                    return "";


                return this.neuCboDeptList.Tag.ToString();
            }

            set
            {
                this.neuCboDeptList.Tag = value;
            }
        }

        private void neuCboDeptList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
    

        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void neuBtnFind_Click(object sender, EventArgs e)
        {
            
        }

        private void neuCboDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}