using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShenYangCitySI.Control
{
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
           // this.SetPatientInfo(register);
            process.Disconnect();

        }
    }
}