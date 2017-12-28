using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Forms;

namespace Neusoft.HISFC.Components.Material.In
{
    public partial class frmIn : frmIMABaseForm, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public frmIn()
        {
            InitializeComponent();
            this.Text = "物资入库";
        }
        In.ucMatIn uc = new ucMatIn();
        protected override void OnLoad(EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            try
            {
                
                this.AddIMABaseCompoent(uc);
            }
            catch
            {
            }
            base.OnLoad(e);
        }

        #region IPreArrange 成员

        public int PreArrange()
        {
            if (this.uc != null)
            {
                if (this.uc is Neusoft.FrameWork.WinForms.Classes.IPreArrange)
                {
                    return (this.uc as Neusoft.FrameWork.WinForms.Classes.IPreArrange).PreArrange();
                }
            }

            return 1;
        }

        #endregion
    }
}