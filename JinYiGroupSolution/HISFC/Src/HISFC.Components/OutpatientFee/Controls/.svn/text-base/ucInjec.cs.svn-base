using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucInjec : UserControl
    {
        public ucInjec()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 
        /// </summary>
        /// <param name="injecs"></param>
        public delegate void myDelegate(decimal injecs);
        
        /// <summary>
        /// 
        /// </summary>
        public event myDelegate WhenInputInjecs;

        #endregion

        #region 方法

        /// <summary>
        /// 获得输入的次数
        /// </summary>
        /// <returns></returns>
        private decimal GetInjecs()
        {
            decimal injecs = 0;
            try
            {
                injecs = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.tbInjec.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入的数字不合法!请重新输入!" + ex.Message);
                this.tbInjec.SelectAll();
                this.tbInjec.Focus();
                return -1;
            }
            if (injecs < 0)
            {
                MessageBox.Show("院注次数不能小于0");
                this.tbInjec.SelectAll();
                this.tbInjec.Focus();
                return -1;
            }

            return injecs;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbInjec_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal injecs = 0;
                injecs = GetInjecs();
                if (injecs < 0)
                {
                    return;
                }
                WhenInputInjecs(injecs);
                this.FindForm().Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbOk_Click(object sender, System.EventArgs e)
        {
            decimal injecs = 0;
            injecs = GetInjecs();
            if (injecs == -1)
            {
                return;
            }
            WhenInputInjecs(injecs);
            this.FindForm().Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCancel_Click(object sender, System.EventArgs e)
        {
            this.FindForm().Close();
            WhenInputInjecs(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucInjec_Load(object sender, System.EventArgs e)
        {
            this.tbInjec.Text = "";
            this.tbInjec.Focus();
            try
            {
                this.FindForm().Text = "院内注射次数";
            }
            catch
            { }
        }

        #endregion
    }
}
