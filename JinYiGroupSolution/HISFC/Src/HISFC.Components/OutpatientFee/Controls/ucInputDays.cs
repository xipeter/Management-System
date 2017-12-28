using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucInputDays : UserControl
    {
        public ucInputDays()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 付数
        /// </summary>
        private int days;

        /// <summary>
        /// 组合号
        /// </summary>
        private string combNO = string.Empty;

        /// <summary>
        /// 是否选择
        /// </summary>
        private bool isSelect = false;

        #endregion

        #region 属性

        /// <summary>
        /// 付数
        /// </summary>
        public int Days
        {
            get
            {
                return days;
            }
        }

        /// <summary>
        /// 组合号
        /// </summary>
        public string CombNO
        {
            get
            {
                return combNO;
            }
            set
            {
                this.tbCombNo.Text = value;
            }
        }

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsSelect 
        {
            get 
            {
                return this.isSelect;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获得输入
        /// </summary>
        /// <returns></returns>
        public int GetDays()
        {
            string tempDays = this.tbDays.Text;
            if (tempDays == null || tempDays.Trim() == "")
            {
                MessageBox.Show(Language.Msg("请输入付数!"));
                this.tbDays.SelectAll();
                this.tbDays.Focus();

                return -1;
            }
            if (tempDays.Length >= 3)
            {
                MessageBox.Show(Language.Msg("请输入付数小于100!"));
                this.tbDays.SelectAll();
                this.tbDays.Focus();

                return -1;
            }
            if (tempDays.IndexOf(".") >= 0)
            {
                MessageBox.Show(Language.Msg("请输入整数付数!"));
                this.tbDays.SelectAll();
                this.tbDays.Focus();

                return -1;
            }
            try
            {
                days = int.Parse(tempDays);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("付数输入不合法!") + ex.Message);
                this.tbDays.SelectAll();
                this.tbDays.Focus();

                return -1;
            }
            string tmpCombNo = this.tbCombNo.Text;
            if (tmpCombNo != null && tmpCombNo.Length > 14)
            {
                MessageBox.Show(Language.Msg("组合号输入过长,不能超过14位!请重新输入"));
                this.tbCombNo.SelectAll();
                this.tbCombNo.Focus();

                return -1;
            }
            this.combNO = tmpCombNo;

            return 1;
        }

        #endregion

        #region 事件
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.isSelect = false;
                this.FindForm().Close();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (GetDays() != -1)
            {
                this.isSelect = true;
                this.FindForm().Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbCombNo.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCombNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        #endregion
    }
}
