using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinReg
{
    public partial class ucFinOpbDoctstat : Neusoft.NFC.Interface.Controls.ucQueryBaseForDataWindow
    {
        public ucFinOpbDoctstat()
        {
            InitializeComponent();
        }
        //科室

        string deptCode = string.Empty;
        string deptName = string.Empty;
        protected override int OnRetrieve(params object[] objects)
        {
            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,this.deptCode);
        }

        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            this.Init();
            base.OnLoad();
            //填充数据
            Neusoft.HISFC.Integrate.Manager manager = new Neusoft.HISFC.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetDeptmentAllValid();

            Neusoft.HISFC.Object.Base.Department top = new Neusoft.HISFC.Object.Base.Department();
            top.ID = "0";
            top.Name = "全  部";
            top.SpellCode = "QB";
            top.WBCode = "WU";
            this.neuComboBox1.Items.Add(top);
            foreach (Neusoft.HISFC.Object.Base.Department con in constantList)
            {
                neuComboBox1.Items.Add(con);
            }
            this.neuComboBox1.alItems.Add(top);
            this.neuComboBox1.alItems.AddRange(constantList);

            if (neuComboBox1.Items.Count > 0)
            {
                neuComboBox1.SelectedIndex = 0;
                deptCode = ((Neusoft.HISFC.Object.Base.Department)neuComboBox1.Items[0]).ID;
                deptName = ((Neusoft.HISFC.Object.Base.Department)neuComboBox1.Items[0]).Name;
            }
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox1.SelectedIndex > -1)
            {
                deptCode = ((Neusoft.HISFC.Object.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                deptName = ((Neusoft.HISFC.Object.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }
        }
       
    }
}
