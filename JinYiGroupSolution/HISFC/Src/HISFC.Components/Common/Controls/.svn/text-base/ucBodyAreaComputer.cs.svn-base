using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucBodyAreaComputer : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucBodyAreaComputer()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();



        private void Init()
        {
            this.txtWeightCon.Text = this.controlManager.GetControlParam<string>("200035", true, "0.425");
            this.txtHeightCon.Text = this.controlManager.GetControlParam<string>("200036", true, "0.725");
            this.txtConstant1.Text = this.controlManager.GetControlParam<string>("200037", true, "71.84");
            this.txtConstant2.Text = this.controlManager.GetControlParam<string>("200038", true, "10000");
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            double weight = 0;
            double height = 0;
            double weightCon = 0;
            double heightCon = 0;
            double constant1 = 0;
            double constant2 = 0;
            double bodyArea = 0;
            
            weight = Convert.ToDouble(this.txtWeight.Text);
            height = Convert.ToDouble(this.txtHeight.Text);
            weightCon = Convert.ToDouble(this.txtWeightCon.Text);
            heightCon = Convert.ToDouble(this.txtHeightCon.Text);
            constant1 = Convert.ToDouble(this.txtConstant1.Text);
            constant2 = Convert.ToDouble(this.txtConstant2.Text);
            
            bodyArea = System.Math.Pow(weight , weightCon) * System.Math.Pow(height , heightCon) * constant1 / constant2;
            this.txtBodyArea.Text = Convert.ToString(System.Math.Round(bodyArea, 4));
            
        }

        private void ucBodyAreaComputer_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Init();
            }
        }
    }
}

