using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class frmSearchName : Form
    {
        public frmSearchName()
        {
            InitializeComponent();
        }
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == this.tbSearch)
            {
                SearchButton();
            }
            else if (e.Button == this.tbPrint)
            {
                this.ucShowCaseInfo1.PrintInfo();
            }
            else if (e.Button == this.tbExport)
            {
                this.ucShowCaseInfo1.ExportInfo();
            }
            else
            {
                this.Close();
            }
        }
        //"Case.CaseReport.GetInfoIndex.NameIndex"
        /// <summary>
        /// ≤È—Ø 
        /// </summary>
        private void SearchButton()
        {
            if (ucNameSreach1.CreateName() == -1)
            {
                return;
            }
            ucShowCaseInfo1.SearchInfo("Case.CaseReport.GetInfoIndex.Index1", ucNameSreach1.strWhere);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.F4.GetHashCode())
            {
                SearchButton();
            }
            else if (keyData.GetHashCode() == Keys.F5.GetHashCode())
            {
                this.ucShowCaseInfo1.ExportInfo();
            }
            else if (keyData.GetHashCode() == Keys.F8.GetHashCode())
            {
                this.ucShowCaseInfo1.PrintInfo();
            }
            else if (keyData.GetHashCode() == Keys.Control.GetHashCode() + Keys.X.GetHashCode())
            {
                this.Close();
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}