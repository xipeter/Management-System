using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Balance
{
    /// <summary>
    /// ucPayTypeSelect<br></br>
    /// [功能描述: 支付方式控件]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-12-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPayTypeSelect : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPayTypeSelect()
        {
            InitializeComponent();
        }
        #region "变量"
        /// <summary>
        /// 结算方式支付方式
        /// </summary>
        private ArrayList alBalancePay;
        #endregion

        #region "属性"

        /// <summary>
        /// 结算方式支付方式
        /// </summary>
        public ArrayList AlPayType
        {
            set
            {
                this.alBalancePay = value;
                this.InitBalancePayList();
            }
            get 
            {
                return this.alBalancePay;
            }
        }
        #endregion

        #region "函数"

        public virtual void InitBalancePayList()
        {

        }
        #endregion

    }
}
