using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.DrugStore
{
    public partial class ucOutpatientShow : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientShow
    {
        public ucOutpatientShow()
        {
            InitializeComponent();
        }

        #region IOutpatientShow ≥…‘±

        public void ShowInfo(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            this.neuLabel1.Text = drugRecipe.PatientName;
        }

        #endregion
    }
}
