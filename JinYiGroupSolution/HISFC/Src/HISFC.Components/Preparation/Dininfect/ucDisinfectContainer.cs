using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Preparation.Prescription;

namespace Neusoft.HISFC.Components.Preparation.Disinfect
{
    /// <summary>
    /// 供应室处方维护
    /// </summary>
    public partial class ucDisinfectContainer : ucPrescriptionContainer
    {
        public ucDisinfectContainer()
        {
            InitializeComponent();
        }

        protected override Neusoft.HISFC.Models.Base.EnumItemType GetItemType()
        {
            return Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
        }

        protected override int GetInterface()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载基础数据 请稍候...");
            Application.DoEvents();

            Disinfect.ucDisinfectProduct ucP = new ucDisinfectProduct();
            this.ProductInstance = ucP;
            this.ProductInstance.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
            ucP.Init();

            ucDisinfectMaterial ucM = new ucDisinfectMaterial();
            this.MaterialInstance = ucM;
            this.MaterialInstance.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
            ucM.Init();

            this.splitContainer2.Panel1.Controls.Add(ucP);
            ucP.Dock = DockStyle.Fill;

            this.splitContainer2.Panel2.Controls.Add(ucM);
            ucM.Dock = DockStyle.Fill;

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }
    }
}
