using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// frmSelectWeek <br></br>
	/// [功能描述: 选择星期窗口]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class frmSelectWeek : Form
	{
		public frmSelectWeek()
		{
			InitializeComponent();
		}
        Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking booking = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ( );

		#region 属性
        /// <summary>
        /// 标识位
        /// </summary>
        private string tmpFlag;
        /// <summary>
        /// 标识位
        /// </summary>
        public string TmpFlag
        {
            get
            {
                return tmpFlag;
            }
            set
            {
                tmpFlag = value;
            }
        }

		/// <summary>
		/// 当前选择的星期
		/// </summary>
		public DayOfWeek SelectedWeek
		{
			get
			{
				return (DayOfWeek)this.neuComboBox1.SelectedIndex;
			}
			set
			{
				this.neuComboBox1.SelectedIndex = (int)value;
			}
		}

		#endregion

		/// <summary>
		/// 星期选择控件回车事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuComboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.DialogResult = DialogResult.OK;
				this.Hide();
			}
		}

		/// <summary>
		/// 确定按钮单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuButtonOK_Click(object sender, EventArgs e)
		{
			this.Hide();
			this.DialogResult = DialogResult.OK;
            if ( this.TmpFlag == "0" )
            {
            }
            else if ( this.TmpFlag == "1" )
            {
                if ( this.lblMessage.Text == "设备模板" )
                {
                    MessageBox.Show ( "已有项目，不能添加设备模板" );
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else if ( this.TmpFlag == "2" )
            {
                if ( this.lblMessage.Text == "项目模板" )
                {
                    MessageBox.Show ( "已有设备，不能添加项目模板" );
                    this.DialogResult = DialogResult.Cancel;
                }
            }
		}

		/// <summary>
		/// 确定按钮单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuButtonCancel_Click(object sender, EventArgs e)
		{
			this.Hide();
			this.DialogResult = DialogResult.Cancel;
		}
        /// <summary>
        /// 星期变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuComboBox1_SelectedIndexChanged ( object sender , EventArgs e )
        {
            this.lblMessage.Text = "";
            ucMedTechBookingTemplet medTechBookingTemplet =new ucMedTechBookingTemplet();
            ArrayList tempList = new ArrayList ( );
            string tmpFlag = string.Empty;
            tempList=booking.QueryTemp ( medTechBookingTemplet.GetDept ( ).ID , this.neuComboBox1.SelectedIndex.ToString ( ) );
            if ( tempList == null || tempList.Count == 0 )
            {
                tmpFlag = "0";
            }
            else
            {
                Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp = tempList [ 0 ] as Neusoft.HISFC.Models.Terminal.MedTechItemTemp;
                tmpFlag = medTechItemTemp.TmpFlag;
            }
            if ( tmpFlag == "0" )
            {
                this.lblMessage.Text = "没有模板";
            }
            else if ( tmpFlag == "1" )
            {
                this.lblMessage.Text = "项目模板";
            }
            else
            {
                this.lblMessage.Text = "设备模板";
            }
        }
	}
}