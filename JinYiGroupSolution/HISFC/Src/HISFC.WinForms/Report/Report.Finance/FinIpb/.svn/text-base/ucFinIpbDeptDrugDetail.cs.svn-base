using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbDeptDrugDetail : NeuDataWindow.Controls.ucQueryBaseForDataWindow  
    {
        /// <summary>
        /// 全院科室药品费用明细查询
        /// </summary>
        public ucFinIpbDeptDrugDetail()
        {
            InitializeComponent();
        }

        private string deptcode = string.Empty;
        private string deptname = string.Empty;
        private string execcode = string.Empty;
        private string execname = string.Empty;
        private string reccode = string.Empty;
        private string recname = string.Empty;

        protected override void OnLoad()
        {
            base.OnLoad();
            //填充数据
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

            Neusoft.HISFC.Models.Base.Department top = new Neusoft.HISFC.Models.Base.Department();
            top.ID = "ALL";
            top.Name = "全  部";
            top.IsRegDept = false;
            top.IsStatDept = false;
            top.SpellCode = "QB";
            top.WBCode = "WU";
            

            this.neuComboBox1.Items.Add(top);
            foreach (Neusoft.HISFC.Models.Base.Department con in constantList)
            {
                neuComboBox1.Items.Add(con);
            }            
            this.neuComboBox1.alItems.Add(top);
            this.neuComboBox1.alItems.AddRange(constantList);

            if (neuComboBox1.Items.Count > 0)
            {
                neuComboBox1.SelectedIndex = 0;
                deptcode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[0]).ID;
                deptname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[0]).Name;
            }

            Neusoft.HISFC.BizProcess.Integrate.Manager managers = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList1 = manager.GetDepartment();

            this.neuComboBox2.Items.Add(top);
            foreach (Neusoft.HISFC.Models.Base.Department con in constantList1)
            {
                neuComboBox2.Items.Add(con);
            }

            this.neuComboBox2.alItems.Add(top);
            this.neuComboBox2.alItems.AddRange(constantList1);


            if (neuComboBox2.Items.Count > 0)
            {
                neuComboBox2.SelectedIndex = 0;
                execcode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox2.Items[0]).ID;
                execname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox2.Items[0]).Name;
            }

            Neusoft.HISFC.BizProcess.Integrate.Manager manageres = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList2 = manager.GetDepartment();

            this.neuComboBox3.Items.Add(top);
            foreach (Neusoft.HISFC.Models.Base.Department con in constantList2)
            {
                neuComboBox3.Items.Add(con);
            }

            this.neuComboBox3.alItems.Add(top);
            this.neuComboBox3.alItems.AddRange(constantList2);


            if (neuComboBox3.Items.Count > 0)
            {
                neuComboBox3.SelectedIndex = 0;
                reccode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox3.Items[0]).ID;
                recname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox3.Items[0]).Name;
            }
        }

        /// <summary>
        /// 检索数据



        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            this.dwMain.Modify("time.text='" + this.beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            return base.OnRetrieve(this.beginTime, this.endTime, deptcode, execcode, reccode);
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

        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox1.SelectedIndex > -1)
            {
                deptcode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                deptname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }
        }

        private void neuComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox2.SelectedIndex > -1)
            {
                execcode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox2.Items[this.neuComboBox2.SelectedIndex]).ID;
                execname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox2.Items[this.neuComboBox2.SelectedIndex]).Name;
            }
        }

        private void neuComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox3.SelectedIndex > -1)
            {
                reccode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox3.Items[this.neuComboBox3.SelectedIndex]).ID;
                recname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox3.Items[this.neuComboBox3.SelectedIndex]).Name;
            }
        }

        private string queryStr = "((dept_name like '{0}%') or (dept_spell_code like '{0}%') or (dept_wb_code like '{0}%')) and ((fee_name like '{1}%') or (fee_spell_code like '{1}%') or (fee_wb_code like '{1}%')) and ((drug_name like '{2}%') or (drug_spell_code like '{2}%') or (drug_wb_code like '{2}%')) and ((rec_name like '{3}%') or (rec_spell_code like '{3}%') or (rec_wb_code like '{3}%')) and ((exec_name like '{4}%') or (exec_spell_code like '{4}%') or (exec_wb_code like '{4}%'))";

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            string dept = this.neuTextBox1.Text.Trim().ToUpper().Replace(@"\", "");
            string fee = this.neuTextBox2.Text.Trim().ToUpper().Replace(@"\", "");
            string drug = this.neuTextBox3.Text.Trim().ToUpper().Replace(@"\", "");
            string rec = this.neuTextBox4.Text.Trim().ToUpper().Replace(@"\", "");
            string exec = this.neuTextBox5.Text.Trim().ToUpper().Replace(@"\", "");
            DataView dv = this.dwMain.Dv;

            if (dept.Equals("") && fee.Equals("") && drug.Equals("") && rec.Equals("") && exec.Equals(""))
            {
                
                //this.dwMain.SetFilter("");
                //this.dwMain.Filter();
                dv.RowFilter = "";
                return;
            }

            string str = string.Format(this.queryStr,dept,fee,drug,rec,exec);
           
            if (dv == null)
            {
                return;
            }

            try
            {
                dv.RowFilter = str;
            }
            catch
            {
                MessageBox.Show("请输入正确信息，不许输入特殊字符");
                return ;
            }

            //this.dwMain.SetFilter(str);
            //this.dwMain.Filter();
        }

    }
}
