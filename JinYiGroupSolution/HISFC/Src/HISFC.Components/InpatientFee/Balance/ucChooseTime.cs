using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UFC.InpatientFee.Balance
{
    public partial class ucChooseTime : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucChooseTime()
        {
            InitializeComponent();
        }



        #region "变量"

        Neusoft.HISFC.Management.Fee.InPatient feeInpatient = new Neusoft.HISFC.Management.Fee.InPatient();

        /// <summary>
        /// 设置一个delegate
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        public delegate void myDelegateGetDateTime(DateTime beginTime, DateTime endTime);
        public event myDelegateGetDateTime OnEndChooseDateTime;

        #endregion

        #region "属性"

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return this.dtpBeginDate.Value;
            }
            set
            {
                this.dtpBeginDate.Value = value;
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.dtpEndDate.Value;
            }

            set
            {
                this.dtpEndDate.Value = value;
            }
        }
        /// <summary>
        /// 开始时间是否允许编辑
        /// </summary>
        public bool IsBeginDateEdit
        {
            get
            {
                return this.dtpBeginDate.Enabled;
            }
            set
            {
                this.dtpBeginDate.Enabled = value;
            }
        }
        /// <summary>
        /// 结束时间是否允许编辑
        /// </summary>
        public bool IsEndDateEdit
        {
            get
            {
                return this.dtpEndDate.Enabled;
            }
            set
            {
                this.dtpEndDate.Enabled = value;
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.EndChooseTime();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            //this.EndChooseTime();
            try
            {

                this.FindForm().Close();
            }
            catch{}
            
        }

        #region "事件"
        #endregion

        #region "函数"
        /// <summary>
        /// 结束选择
        /// </summary>
        protected virtual void EndChooseTime()
        {
            if (this.EndDate < this.BeginDate)
            {
                MessageBox.Show("结束时间小于起始时间请重新选择");
                return;
            }
            if (this.EndDate > this.feeInpatient.GetDateTimeFromSysDateTime())
            {
                MessageBox.Show("结束时间大于当前时间请重新选择");
                return;
            }

            try
            {
                this.OnEndChooseDateTime(this.BeginDate, this.EndDate);
            }
            catch { };

            this.FindForm().Close();

        }

        #endregion
    }
}
