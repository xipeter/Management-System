using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.MET.MetOpd
{
    public partial class ucMetOpdFeeCode : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetOpdFeeCode()
        {
            InitializeComponent();
        }
        DeptZone deptZone1 = DeptZone.ALL;


        public enum DeptZone
        {
            MZ = 0,
            ZY = 1,
            ALL = 2,
        }

        [Category("控制设置"), Description("查询范围：ALL：全院、MZ：门诊、ZY：住院")]
        public DeptZone DeptZone1
        {
            get
            {
                return deptZone1;
            }
            set
            {
                deptZone1 = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.isAcross = true;
            this.isSort = false;
            base.OnLoad(e);

            cmbDept.ClearItems();

            if (deptZone1 == DeptZone.ALL)
            {
                cmbDept.Items.Add("全院");
                cmbDept.Items.Add("门诊");
                cmbDept.Items.Add("住院");

            }
            if (deptZone1 == DeptZone.MZ)
            {
                cmbDept.Items.Add("门诊");
                cmbDept.Enabled = false;
            }
            if (deptZone1 == DeptZone.ZY)
            {
                cmbDept.Items.Add("住院");
                cmbDept.Enabled = false;
            }

            cmbDept.SelectedIndex = 0;
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }


            string strFeelan = "全院";
            //List<string> alType = new List<string>();


            if (!string.IsNullOrEmpty(cmbDept.Items[cmbDept.SelectedIndex].ToString()))
            {
                strFeelan = cmbDept.Items[cmbDept.SelectedIndex].ToString();
            }


            return base.OnRetrieve(this.beginTime, this.endTime, strFeelan);
        }

    }
}
