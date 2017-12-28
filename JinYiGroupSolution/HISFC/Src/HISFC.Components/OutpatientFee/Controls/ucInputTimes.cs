using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    /// <summary>
    /// ucInputTimes<br></br>
    /// [功能描述: 输入组合次数UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-2-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucInputTimes : UserControl
    {
        public ucInputTimes()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 次数
        /// </summary>
        private int times = 1;

        #endregion

        #region 属性

        /// <summary>
        /// 次数
        /// </summary>
        public int Times
        {
            get
            {
                return this.times;
            }
            set
            {
                this.times = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获得次数
        /// </summary>
        /// <returns></returns>
        private int GetInjecs()
        {
            int injecs = 1;
            try
            {
                injecs = Neusoft.FrameWork.Function.NConvert.ToInt32(this.tbInjec.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入的数字不合法!请重新输入!" + ex.Message);
                this.tbInjec.SelectAll();
                this.tbInjec.Focus();
                return -1;
            }
            if (injecs < 1)
            {
                MessageBox.Show("倍数不能小于1");
                this.tbInjec.SelectAll();
                this.tbInjec.Focus();
                return -1;
            }
            this.times = injecs;

            return injecs;
        }

        #endregion

        #region 事件

        private void tbOk_Click(object sender, System.EventArgs e)
        {
            int injecs = GetInjecs();
            if (injecs == -1)
            {
                return;
            }
            this.FindForm().Close();
        }

        private void tbCancel_Click(object sender, System.EventArgs e)
        {
            this.FindForm().Close();
        }

        private void ucInjec_Load(object sender, System.EventArgs e)
        {
            this.tbInjec.Text = "1";
            this.tbInjec.Focus();
            this.tbInjec.SelectAll();
            try
            {
                this.FindForm().Text = "输入倍数";
            }
            catch
            { }
        }

        private void tbInjec_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbOk_Click(null, null);
            }
        }

        #endregion
    }
}
