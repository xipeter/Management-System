using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Logistics.DrugStore
{
    public partial class ucDrugStoreNotUse1 : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucDrugStoreNotUse1()
        {
            InitializeComponent();
        }

        //private string emplCode = string.Empty;
        //private string emplName = string.Empty;
       // ArrayList alDept = new ArrayList();


        protected override int OnRetrieve(params object[] objects)
        {


            if (this.dtpBeginTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间!");
                return -1;
            }

            //string deptCode = "ALL";

            // deptCode = neuDept.SelectedItem.ID;



          return  base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, "ALL");
            
          
        }
      
    }
}
