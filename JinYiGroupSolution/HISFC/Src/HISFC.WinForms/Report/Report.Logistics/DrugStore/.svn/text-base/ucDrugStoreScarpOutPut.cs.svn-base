using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucDrugStoreScarpOutPut : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucDrugStoreScarpOutPut()
        {
            InitializeComponent();
        }

        private string emplCode = string.Empty;
        private string emplName = string.Empty;

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime()==-1)
            {
                return -1;
            }

            return base.OnRetrieve(this.beginTime,this.endTime,emplCode);
            
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

        private string querySql = "((trade_name like '{0}%') or (drug_spell_code  like '{0}%') or (drug_wb_code like '{0}%'))and (out_list_code like '{1}%')";

        
        private void neuTextBox2_TextChanged(object sender, EventArgs e)
        {
            FilterTextChanged();

           
        }

        private void FilterTextChanged()
        {
            //string drugCode = this.neuTextBox2.Text.Trim().ToUpper().Replace(@"\", "");
            //string outList = this.neuTextBox3.Text.Trim().ToUpper().Replace(@"\", "");

            string drugCode = this.neuTextBox2.Text.Trim().Replace(@"\", "").Replace(@"'","").ToUpper();
            string outList = this.neuTextBox3.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();

            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            if (drugCode.Equals("") && outList.Equals(""))
            {
                //this.dwMain.SetFilter("");
                //this.dwMain.Filter();
                dv.RowFilter = "";
                
                return;
            }
            else {
                
                string str = string.Format(this.querySql, drugCode, outList);
                
                dv.RowFilter = str;
            
            }
            //string str = string.Format(this.querySql, drugCode, outList);
            //this.dwMain.SetFilter(str);
           
            //this.dwMain.Filter();

            //this.dwMain.SetSort("out_list_code");

            //this.dwMain.Sort();
    
           
        }

        private void ucDrugStoreScarpOutPut_Load(object sender, EventArgs e)
        {
            this.neuTextBox2.ReadOnly = true;
            this.neuTextBox3.ReadOnly = true;
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constangList = manager.QueryEmployeeAll();
            Neusoft.HISFC.Models.Base.Employee top = new Neusoft.HISFC.Models.Base.Employee();
            top.ID = "ALL";
            top.Name = "È«²¿";
            top.SpellCode = "QB";
            top.WBCode = "WU";
            //this.neuComboBox1.Items.Add(top);
            constangList.Insert(0, top);
            this.neuComboBox1.AddItems(constangList);
            if (neuComboBox1.Items.Count > 0)
            {
                neuComboBox1.SelectedIndex = 0;
                emplCode = neuComboBox1.SelectedItem.ID;
                emplName = neuComboBox1.SelectedItem.Name;
            }
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

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuComboBox1.SelectedIndex > -1)
            {
                emplCode = neuComboBox1.SelectedItem.ID;
                emplName = neuComboBox1.SelectedItem.Name;
            }
        }

        private void dwMain_Click(object sender, EventArgs e)
        {

        }


    }
}
