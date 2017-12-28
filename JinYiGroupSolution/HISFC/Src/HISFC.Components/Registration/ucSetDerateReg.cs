using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucSetDerateReg : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSetDerateReg()
        {
            InitializeComponent();
        }


        private int InitControl()
        {
            int j = 0;
            for (int i = 0; i < 20; i++)
            {
                int mod = 0;

                Math.DivRem(i, 4, out mod);
                if (mod == 0 && i != 0)
                {
                    j++;
                }


                ucSetDerateRegPannel uc = new ucSetDerateRegPannel();

                uc.Size = new Size(uc.Width + 10, uc.Height);

                uc.Location = new Point(uc.Width * mod + 30 * mod, uc.Width * j + 100 * j);
                uc.Tag = i.ToString();
                this.plControls.Controls.Add(uc);


            }
            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.InitControl();
            base.OnLoad(e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.InitControl();
            
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.InitControl();
            return 1;
            //return base.OnSave(sender, neuObject);
        }
    }
}
