using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Pharmacy
{
    public partial class ucPhaDeptDrugInputDetail : Common.ucQueryBaseForDataWindow
    {
        private string DeptCode = string.Empty;
        private string name;
        private DateTime dt;
        public ucPhaDeptDrugInputDetail()
        {
            InitializeComponent();
        }

        #region 管理类


        Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
        //Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        System.Collections.ArrayList drugDeptList = new System.Collections.ArrayList();
        Neusoft.HISFC.BizLogic.Manager.Department manager = new Neusoft.HISFC.BizLogic.Manager.Department();

        #endregion

        #region 字段
        /// <summary>
        ///过滤字符表达式

        private string querycode = string.Empty;
        #endregion

        /// <summary>
        /// 过滤文本框事件

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.querycode = ((Neusoft.FrameWork.WinForms.Controls.NeuTextBox)sender).Text.Trim();
            try
            {
                if (!this.querycode.Equals(""))
                {
                    this.dwMain.SetFilter("(pha_com_input_trade_name LIKE '" + querycode + "%') or (pha_com_input_spell_code LIKE '" + querycode.ToUpper() + "%')");
                }
                else
                {
                    this.dwMain.SetFilter("");
                }
                this.dwMain.Filter();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "提示");
            }
        }

        protected override void OnLoad()
        {
            this.Init();
            drugDeptList = manager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

            foreach (Neusoft.FrameWork.Models.NeuObject con in drugDeptList)
            {
                this.deptComboBox1.Items.Add(con);
            }
            if (deptComboBox1.Items.Count >= 0)
            {
                deptComboBox1.SelectedIndex = 0;
                DeptCode = ((Neusoft.FrameWork.Models.NeuObject)deptComboBox1.Items[0]).ID;
            }
            base.OnLoad();
            dt = System.DateTime.Now;
			this.name = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name;
            //Neusoft.HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //ArrayList alCon = interManager.GetDepartment();
            //Neusoft.FrameWork.Models.NeuObject neuO = new Neusoft.FrameWork.Models.NeuObject();
            //alCon.Insert(0, neuO);

            //this.cmbQuery.AddItems(alCon);
        }
        protected override int OnRetrieve(params object[] objects)
        {
            dwMain.Retrieve(DeptCode, this.dtpBeginTime.Value, this.dtpEndTime.Value,this.name);
            return base.OnRetrieve(DeptCode, this.dtpBeginTime.Value, this.dtpEndTime.Value,this.name);
        }

        //private void cmbQuery_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //DeptCode = this.cmbQuery.Tag.ToString();
        //    DeptCode = ((Neusoft.FrameWork.Models.NeuObject)this.deptComboBox1.Items[this.deptComboBox1.SelectedIndex]).ID;
        //}

        private void deptComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.deptComboBox1.SelectedIndex >= 0)
            {
                DeptCode = ((Neusoft.FrameWork.Models.NeuObject)this.deptComboBox1.Items[this.deptComboBox1.SelectedIndex]).ID;
            }
        }
    }
}
