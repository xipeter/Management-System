using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.OutPatient.Forms
{
    public partial class frmInputInjectNum : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmInputInjectNum()
        {
            InitializeComponent();
            this.neuNumericUpDown1.ReadOnly = true;
        }

        #region 变量
        private bool isHaveSetted = false;
        private bool isSpring = false;
        /// <summary>
        /// 设置需要更改的医嘱
        /// </summary>
        protected Neusoft.HISFC.Models.Order.OutPatient.Order order = null;
        #endregion

        #region 属性
        /// <summary>
        /// 获得或设置院注次数
        /// </summary>
        public int InjectNum
        {
            get
            {
                return (int)this.neuNumericUpDown1.Value;
            }
            set
            {

                this.neuNumericUpDown1.Value = (decimal)value;
            }
        }


        /// <summary>
        /// 当前医嘱
        /// </summary>
        public Neusoft.HISFC.Models.Order.OutPatient.Order Order
        {
            get
            {
                return this.order;
            }
            set
            {
                order = value;
            }
        }
        #endregion

        /// <summary>
        /// load
        /// </summary>xz
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInputInjectNum_Load(object sender, System.EventArgs e)
        {
            this.neuNumericUpDown1.Select(0, this.neuNumericUpDown1.Value.ToString().Length);
            if (this.order.ExtendFlag1 == null)
            {
                this.txtTimes.Text = "1";//默认
            }
            else
            {
                this.txtTimes.TextChanged -= new EventHandler(txtTimes_TextChanged);
                this.txtTimes.Text = "1";
                this.txtTimes.TextChanged += new EventHandler(txtTimes_TextChanged);

                if (this.order.ExtendFlag1.Length >= 1)
                {
                    decimal times = 1;

                    try
                    {
                        times = System.Convert.ToDecimal(this.order.ExtendFlag1.Substring(0, 1));
                        this.isHaveSetted = true;
                    }
                    catch
                    {
                        this.isHaveSetted = false;
                    }

                    this.txtTimes.Text = times.ToString();
                }
            }
            this.neuNumericUpDown1.Focus();
            this.lblDoseOnce.Text = "每次 " + order.DoseOnce.ToString() + order.DoseUnit;
            //{27DBE032-6896-4b8f-9CBC-EDC47F499B50} 开立医嘱时显示院注天数
            this.SetInjectDays();
        }

        /// <summary>
        /// {27DBE032-6896-4b8f-9CBC-EDC47F499B50} 开立医嘱时显示院注天数
        /// </summary>
        private void SetInjectDays()
        {
            //开立数量
            decimal qty = this.order.Item.Qty;
            //院注次数
            decimal injectTimes = this.neuNumericUpDown1.Value;
            //基本剂量
            decimal baseDose = ((Neusoft.HISFC.Models.Pharmacy.Item)this.order.Item).BaseDose;
            //每次剂量
            decimal doseOnce = this.order.DoseOnce;
            //每日频次
            int frequencyDayCount = (this.order.Frequency.Time.Split('-')).Length;
            //计算得出院注天数
            int injectDays = (int)Math.Ceiling(injectTimes / frequencyDayCount);
            //最多院注天数
            int maxDays = (int)((qty * baseDose) / (doseOnce * frequencyDayCount));

            this.lblInjectDays.Text = "院注天数：" + injectDays;
        }


        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            try
            {


                if (this.InjectNum < 0)
                {
                    MessageBox.Show("院注必须大等于零！");
                    this.neuNumericUpDown1.Select(0, this.neuNumericUpDown1.Value.ToString().Length);
                    this.neuNumericUpDown1.Focus();
                    return;
                }
                if (this.InjectNum > 98)
                {
                    MessageBox.Show("院注次数过大！");
                    this.neuNumericUpDown1.Select(0, this.neuNumericUpDown1.Value.ToString().Length);
                    this.neuNumericUpDown1.Focus();
                    return;
                }
                order.InjectCount = this.InjectNum;
                order.NurseStation.User02 = "C";//修改过
                if (this.isHaveSetted)
                {
                    order.ExtendFlag1 = order.ExtendFlag1.Remove(0, 1);
                    order.ExtendFlag1 = this.txtTimes.Text + order.ExtendFlag1;
                }
                else
                {
                    if (this.txtTimes.Text.Trim() == "")
                    {
                        MessageBox.Show("注射瓶数不能为空!");
                        this.txtTimes.Focus();
                        return;
                    }
                    int price = 0;
                    try
                    {
                        price = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtTimes.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("输入注射瓶数的格式不正确，请重新输入！");
                        this.txtTimes.Focus();
                        return;
                    }
                    if (price <= 0)
                    {
                        MessageBox.Show("输入的注射瓶数不能小于或等于0！");
                        this.txtTimes.Focus();
                        return;
                    }
                    if (price > 9)
                    {
                        MessageBox.Show("输入的注射瓶数不能大于9！");
                        this.txtTimes.Focus();
                        return;
                    }
                    this.order.ExtendFlag1 = this.txtTimes.Text.Trim() + this.order.ExtendFlag1;
                }
            }
            catch
            {
                MessageBox.Show("添加院注次数出错！");
                this.Close();
            }
            this.Close();
        }



        /// <summary>
        /// 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuNumericUpDown1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.isSpring == false)
                {
                    this.neuNumericUpDown1.Focus();
                    this.isSpring = true;
                }
                else
                {
                    this.btnOK_Click(null, null);
                }
            }
        }

        /// <summary>
        /// 输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTimes_TextChanged(object sender, System.EventArgs e)
        {
            decimal times = 1;

            if (this.txtTimes.Text.Trim() == "")
            {
                return;
            }

            try
            {
                times = System.Convert.ToDecimal(this.txtTimes.Text.Trim());
            }
            catch
            {
                MessageBox.Show("您输入的的数字格式不正确，请重新输入！");
                this.txtTimes.Focus();
                return;
            }
            if (times > 9)
            {
                MessageBox.Show("您输入的的数字过大，请重新输入！");
                this.txtTimes.Focus();
                return;
            }
        }

        /// <summary>
        /// {27DBE032-6896-4b8f-9CBC-EDC47F499B50} 开立医嘱时显示院注天数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.SetInjectDays();
        }


    }
}

