using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Logistics.Pharmacy
{
    public partial class ucPhaDrugstoresDm : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaDrugstoresDm()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.BizProcess.Integrate.Manager inteManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.Pharmacy intePharmacy = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        private void ucPhaDrugstoresDm_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("加载数据中，请稍候……");
            Application.DoEvents();
            this.cmbDrugQua.AddItems(inteManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY));
            this.cmbDrugName.AddItems(inteManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P));
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        protected override int OnRetrieve(params object[] objects)
        {

            string indept = "1";
            string qualityID = "2";

            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            if (cmbDrugName.SelectedItem == null)
            {
                MessageBox.Show("请选择药房！");
                return -1;
                indept = cmbDrugName.SelectedItem.ID;
            }
            if (cmbDrugQua.SelectedItem == null)
            {
                MessageBox.Show("请选择药品性质！");
                return -1;
                qualityID = cmbDrugQua.SelectedItem.ID;
            }
            return base.OnRetrieve(this.dtpBeginDate.Value, this.dtpEndDate.Value, indept, qualityID);

        }




    }
}
