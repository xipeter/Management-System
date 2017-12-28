using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeNanProvinceSI.Control
{
    /// <summary>
    /// [功能描述: ]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: ]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间='2009-2-13'
    ///	修改目的='代码格式修改及诊断属性修改'
    ///	修改描述=''
    ///  >
    /// </summary>
    public partial class frmShowSIInfo : Form
    {
        //接口类
        Process process = new Process();
        //挂号实体
        Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();

        public frmShowSIInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShowSIInfo_Load(object sender, EventArgs e)
        {
            //清屏
            //this.Clear();
            //读卡获得患者信息
            this.ReadCard();
            //填入患者信息
            this.ucSiPatientInfoOutPatient1.Patient = register;
        }

        /// <summary>
        /// 读卡获得医保患者信息
        /// </summary>
        /// <returns></returns>
        private void ReadCard()
        {
            long returnValue = process.Connect();
            if (returnValue < 0)
            {
                MessageBox.Show(process.ErrMsg);
                return;
            }
            returnValue = process.GetRegInfoOutpatient(register);
            if (returnValue < 0)
            {
                MessageBox.Show(process.ErrMsg); 
                return;
            }
            process.Disconnect();

        }
    }
}