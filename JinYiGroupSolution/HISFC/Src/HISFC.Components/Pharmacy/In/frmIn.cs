using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [��������: ҩƷ��������� ʵ���Զ��尴ť����]<br></br>
    /// [�� �� ��: ������]<br></br>
    /// [����ʱ��: 2007-04]<br></br>
    /// </summary>
    public partial class frmIn : Neusoft.HISFC.Components.Common.Forms.frmIMABaseForm, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public frmIn()
        {
            InitializeComponent();

            this.Text = "ҩƷ���";
        }

        In.ucPhaIn uc = new ucPhaIn();

        protected override void OnLoad(EventArgs e)
        {
            //���Ӵ˴����� �����޷��Զ����
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

        #region IPreArrange ��Ա

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