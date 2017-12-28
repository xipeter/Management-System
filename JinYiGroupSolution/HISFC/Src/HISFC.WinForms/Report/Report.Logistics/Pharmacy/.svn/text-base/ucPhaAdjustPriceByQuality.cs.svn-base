using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Logistics.Pharmacy
{
    public partial class ucPhaAdjustPriceByQuality : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        #region 变量

        Neusoft.HISFC.BizProcess.Integrate.Manager inteManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        Neusoft.HISFC.BizLogic.Pharmacy.Item itemPhaManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        #endregion

        public ucPhaAdjustPriceByQuality()
        {
            InitializeComponent();
        }

        private void ucPhaAdjustPriceByQuality_Load(object sender, EventArgs e)
        {
            this.dtpBeginTime.Value = this.dtpBeginTime.Value.Date;
            this.dtpEndTime.Value = this.dtpEndTime.Value.Date.AddDays(1).AddMilliseconds(-1);

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("数据加载中，请稍候……");
            Application.DoEvents();
            cmbQuality.AddItems(inteManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY));
            List<Neusoft.HISFC.Models.Pharmacy.Item> drugList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            drugList = itemPhaManager.QueryItemList();
            if (drugList == null)
            {
                MessageBox.Show("初始化药品信息出错！");
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return;
            }
            else
            {
                cmbDrug.AddItems(new ArrayList(drugList));
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #region 方法

        protected override int OnRetrieve(params object[] objects)
        {
            string quality = "000";
            string drugID = "111";

            if(ckQuality.Checked)
            {
                if (cmbQuality.SelectedItem == null)
                {
                    MessageBox.Show("请选择详细类别！");
                    return -1;
                }
                else
                {
                    quality = cmbQuality.SelectedItem.ID;
                }
            }

            if(ckDrug.Checked)
            {
                if(cmbDrug.SelectedItem == null)
                {
                    MessageBox.Show("请选择药品！");
                    return -1;
                }
                else
                {
                    drugID = cmbDrug.SelectedItem.ID;
                }
            }

            return base.OnRetrieve(empl.Dept.ID,this.dtpBeginTime.Value,this.dtpEndTime.Value,quality,drugID);
        }

        #endregion

        #region 事件

        private void ckQuality_CheckedChanged(object sender, EventArgs e)
        {
            if (ckQuality.Checked)
            {
                cmbQuality.Enabled = true;
            }
            else
            {
                cmbQuality.Tag = null;
                cmbQuality.Text = "";
                cmbQuality.Enabled = false;
            }
        }

        private void ckDrug_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDrug.Checked)
            {
                cmbDrug.Enabled = true;
            }
            else
            {
                cmbDrug.Tag = null;
                cmbDrug.Text = "";
                cmbDrug.Enabled = false;
            }
        }

        #endregion
    }
}
