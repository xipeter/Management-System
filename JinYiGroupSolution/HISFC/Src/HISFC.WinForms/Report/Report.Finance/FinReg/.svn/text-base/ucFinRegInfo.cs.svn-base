using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using Common = Report.Common;
//using Manager = Report.Manager;
using System.Collections;

namespace Neusoft.Report.Finance.FinReg
{
    public partial class ucFinRegInfo : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinRegInfo()
        {
            InitializeComponent();
        }
        //科室
     
        string deptCode = string.Empty;
        string deptName = string.Empty;
        
        #region 管理类

        Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();


     
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();


        System.Collections.ArrayList DeptList = new System.Collections.ArrayList();

        #endregion
        protected override void OnLoad()
        {
            base.OnLoad();
            //填充数据
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetDeptmentAllValid();

            Neusoft.HISFC.Models.Base.Department top = new Neusoft.HISFC.Models.Base.Department();
            top.ID = "all";
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
                deptCode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[0]).ID;
                deptName = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[0]).Name;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            #region 科室
          

            #endregion
            
         
            

            dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptCode);
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptCode);
        }

       

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           


            if (neuComboBox1.SelectedIndex > -1)
            {
                deptCode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                deptName = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }

            

        }

    }
}