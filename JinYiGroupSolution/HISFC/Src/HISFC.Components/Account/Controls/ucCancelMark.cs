using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Account;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucCancelMark : UserControl
    {
        /// <summary>
        /// 就诊卡停用
        /// </summary>
        /// <param name="list"></param>
        public ucCancelMark(List<AccountCard> list)
        {
            InitializeComponent();
            markList = list;
        }

        #region 变量
        /// <summary>
        /// 患者有效卡集合
        /// </summary>
        List<AccountCard> markList = new List<AccountCard>();

        /// <summary>
        /// 综合管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        public delegate bool EventStopCard(List<AccountCard> list);
        /// <summary>
        /// 作废卡事件
        /// </summary>
        public event EventStopCard StopCardEvent;
        #endregion

        #region 方法
        private void InitListView()
        {
            lvMark.View = View.Details;
            lvMark.CheckBoxes = true;
            lvMark.GridLines = true;
            lvMark.FullRowSelect = true;
            lvMark.Columns.Add("就诊卡号", 150);
            lvMark.Columns.Add("卡类型", 80);
            ListViewItem lvi = null;
            Neusoft.FrameWork.Models.NeuObject obj = null;
            foreach (AccountCard accountCard in markList)
            {
                lvi = new ListViewItem();
                lvi.Text = accountCard.MarkNO;
                //查找卡类型名称
                obj = managerIntegrate.GetConstant("MarkType", accountCard.MarkType.ID);
                if (obj != null)
                {
                    lvi.SubItems.Add(obj.Name);
                }
                lvi.Tag = accountCard;
                lvMark.Items.Add(lvi);
            }
        }
        #endregion

        #region 事件
        private void ucCancelMark_Load(object sender, EventArgs e)
        {
            this.FindForm().Text = "就诊卡信息";
            InitListView();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            List<AccountCard> tempMarkList = new List<AccountCard>();
            foreach (ListViewItem lvi in lvMark.Items)
            {
                if (lvi.Checked)
                {
                    tempMarkList.Add(lvi.Tag as AccountCard);
                }
            }
            if (tempMarkList.Count == 0)
            {
                MessageBox.Show("请选择要作废的卡号！", "提示");
                return;
            }
            if (StopCardEvent != null)
            {
                bool resultValue = StopCardEvent(tempMarkList);
                if (resultValue)
                {
                    this.FindForm().DialogResult = DialogResult.OK;
                }
                else
                {
                    this.FindForm().DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().DialogResult = DialogResult.No;
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            bool bl = this.ckAll.Checked;
            foreach (ListViewItem lvi in lvMark.Items)
            {
                lvi.Checked = bl;
            }
        }
        #endregion
    }
}
