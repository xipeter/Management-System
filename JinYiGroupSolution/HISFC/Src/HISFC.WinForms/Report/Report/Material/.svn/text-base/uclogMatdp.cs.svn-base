using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Material
{
    public partial class uclogMatdp : Report.Common.ucQueryBaseForDataWindow
    {
        private string deptCode = string.Empty;
        private string deptName = string.Empty;
        private string querycode = string.Empty;

        public uclogMatdp()
        {
            InitializeComponent();
        }
        

        // 当前操作科室
        //private string operDeptCode = "";

        #region 管理类

        Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

        //Report.Manager.PhaPriv phaPriv = new Report.Manager.PhaPriv();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        System.Collections.ArrayList phaList = new System.Collections.ArrayList();

        #endregion

        protected override void OnLoad()
        {
            this.Init();

          phaList = manager.GetDeptmentAllValid();

          foreach (Neusoft.FrameWork.Models.NeuObject con in phaList)
            {
                this.deptComboBox1.Items.Add(con);
            }
            base.OnLoad();
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

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, this.deptCode, deptName);
        }

        private void deptComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptComboBox1.SelectedIndex >= 0)
            {
                deptCode = ((Neusoft.FrameWork.Models.NeuObject)deptComboBox1.Items[this.deptComboBox1.SelectedIndex]).ID;
                deptName = ((Neusoft.FrameWork.Models.NeuObject)deptComboBox1.Items[this.deptComboBox1.SelectedIndex]).Name;
            }
        }
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.querycode = ((Neusoft.FrameWork.WinForms.Controls.NeuTextBox)sender).Text.Trim();
            try
            {
                if (!this.querycode.Equals(""))
                {
                    this.dwMain.SetFilter("(log_mat_baseinfo_spell_code LIKE '" + querycode.ToUpper() + "%')");
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
    }
}
