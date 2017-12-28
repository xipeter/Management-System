using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.WinForms.Report.DrugStore
{

    public partial class ucPhaGetLZTotBill : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaGetLZTotBill()
        {
            InitializeComponent();
         
        }
        /// <summary>
        /// 常数管理类－取常数列表
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }


           
            return base.OnRetrieve(base.beginTime, base.endTime, cmbQuality.Tag.ToString(),base.employee.Dept.ID);
        }


        private void ucPhaGetTotBill_Load(object sender, EventArgs e)
        {
 

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "all";
            obj.Name ="全部";

            System.Collections.ArrayList alDrugQuality = new System.Collections.ArrayList();

            alDrugQuality = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
            alDrugQuality.Insert(0, obj);
            this.cmbQuality.AddItems(alDrugQuality);

            this.cmbQuality.SelectedIndex =0;
        }

        private void cmbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            this.OnRetrieve(base.beginTime, base.endTime, cmbQuality.Tag.ToString(),base.employee.Dept.ID);
        }
       

        }

         
}  

