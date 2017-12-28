using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Register
{
    public partial class frmInhos : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmInhos()
        {
            InitializeComponent();
        }


        ucPrepayIn control = new ucPrepayIn();
        private void frmInhos_Load(object sender, EventArgs e)
        {
            control.Dock = DockStyle.Fill;
            this.Panel1.Controls.Add(control);
        }


        private void neuToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == btnSave)
            {
                control.Save();
            }
            else if (e.Button == btnClear)
            {
                control.Clear();
            }
            else if (e.Button == btnCancel)
            {
                control.CancelPre();
            }
            else if (e.Button == btnQuery)
            {
                control.QueryData();
            }
            else if (e.Button == btnExit)
            {
                this.control.Close();
            }
            else if (e.Button == btnPrint)
            {
                control.Print();
            }

            
        }
        /// <summary>
        /// 设置工具栏快捷键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            int AltKey = Keys.Alt.GetHashCode();
            if (keyData.GetHashCode() == AltKey + Keys.O.GetHashCode())
                control.Save();
            if (keyData.GetHashCode() == AltKey + Keys.C.GetHashCode())
                control.Clear();
            if (keyData.GetHashCode() == AltKey + Keys.Q.GetHashCode())
                control.QueryData();
            if (keyData.GetHashCode() == AltKey + Keys.D.GetHashCode())
                control.CancelPre();
            if (keyData.GetHashCode() == AltKey + Keys.P.GetHashCode())
                control.Print();
            if (keyData.GetHashCode() == AltKey + Keys.X.GetHashCode())
                this.Close();


            return base.ProcessDialogKey(keyData);
        }
    }
}