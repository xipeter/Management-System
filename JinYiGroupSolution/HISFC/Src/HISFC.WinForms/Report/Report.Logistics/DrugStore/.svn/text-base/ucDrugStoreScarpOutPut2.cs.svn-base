using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucDrugStoreScarpOutPut2 : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucDrugStoreScarpOutPut2()
        {
            InitializeComponent();
        }

        private string emplCode = string.Empty;
        private string emplName = string.Empty;
        ArrayList alDept = new ArrayList();


        private void ucDrugStoreScarpOutPut_Load(object sender, EventArgs e)
        {
            this.neuTextBox2.ReadOnly = true;
            this.neuTextBox3.ReadOnly = true;
            //Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //System.Collections.ArrayList constangList = manager.QueryEmployeeAll();
            //Neusoft.HISFC.Models.Base.Employee top = new Neusoft.HISFC.Models.Base.Employee();
            //top.ID = "ALL";
            //top.Name = "全部";
            //top.SpellCode = "QB";
            //top.WBCode = "WU";
            ////this.neuComboBox1.Items.Add(top);
            //constangList.Insert(0, top);
            //this.neuOper.AddItems(constangList);
            //if (neuOper.Items.Count > 0)
            //{
            //    neuOper.SelectedIndex = 0;
            //    emplCode = neuOper.SelectedItem.ID;
            //    emplName = neuOper.SelectedItem.Name;
            //}

            ///<summary>
            /// 初始化科室
            ///<summary>

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            obj.ID = "ALL";
            obj.Name = "全部";
            alDept.Add(obj);

            ArrayList dept = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);
            alDept.AddRange(dept);
            alDept.AddRange(managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P));

            this.neuDept.AddItems(alDept);
            this.neuDept.SelectedIndex = 0;



        }




        private string querySql = "((trade_name like '{0}%') or (drug_spell_code  like '{0}%') or (drug_wb_code like '{0}%'))and (out_list_code like '{1}%')";


        private void neuTextBox2_TextChanged(object sender, EventArgs e)
        {
            FilterTextChanged();


        }

        private void FilterTextChanged()
        {


            string drugCode = this.neuTextBox2.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();
            string outList = this.neuTextBox3.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();

            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            if (drugCode.Equals("") && outList.Equals(""))
            {

                dv.RowFilter = "";
                return;
            }
            else
            {

                string str = string.Format(this.querySql, drugCode, outList);

                dv.RowFilter = str;

            }


            this.dwMain.CalculateGroups();

        }




        private void neuCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.neuCheckBox2.Checked == true)
            {
                this.neuTextBox2.ReadOnly = false;
            }
            else
            {
                this.neuTextBox2.ReadOnly = true;
            }

        }

        private void neuCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (this.neuCheckBox3.Checked == true)
            {
                this.neuTextBox3.ReadOnly = false;
            }
            else
            {
                this.neuTextBox3.ReadOnly = true;
            }
        }

        //private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.neuOper.SelectedIndex > -1)
        //    {
        //        emplCode = neuOper.SelectedItem.ID;
        //        emplName = neuOper.SelectedItem.Name;
        //    }
        //}


        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            string deptCode = "ALL";

            deptCode = neuDept.SelectedItem.ID;


            return base.OnRetrieve(this.beginTime, this.endTime, deptCode);

        }

        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                this.dwMain.Print();
                return 1;
            }
            catch
            {
                return 1;
            }

            return base.OnPrint(sender, neuObject);
        }


    }
}
