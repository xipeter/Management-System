using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace HeNanProvinceSI.Control
{
    /// <summary>
    /// [功能描述: 审批窗口]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: ]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间='2009-2-13'
    ///	修改目的='代码格式修改及诊断属性修改'
    ///	修改描述=''
    ///  >
    /// </summary>
    public partial class frmSreimApprove : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
       
        public frmSreimApprove()
        {
            InitializeComponent();
        }


        #region 变量
        /// <summary>
        /// 接口类
        /// </summary>
        Process process = new Process();

        /// <summary>
        /// 本地业务层
        /// </summary>
        LocalManager localManager = new LocalManager();

        /// <summary>
        /// 门诊登记实体
        /// </summary>
        Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();
        #endregion
        #region 方法

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            //初始化诊断
            this.InitDiagnose();
            this.InitMedicalType();
            return 1;
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
            this.SetPatientInfo(register);
            process.Disconnect();

        }
        /// <summary>
        /// 界面赋值
        /// </summary>
        /// <param name="r">患者信息实体</param>
        private void SetPatientInfo(Neusoft.HISFC.Models.Registration.Register r)
        {
            //患者姓名
            this.tbName.Text = r.Name;
            this.tbMarkNO.Text = r.SSN;
            this.tbSex.Text = r.Sex.Name;
            this.tbJBR.Text = Neusoft.FrameWork.Management.Connection.Operator.Name;
            this.tbJBR.Tag = Neusoft.FrameWork.Management.Connection.Operator.ID;

        }
        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            register = new Neusoft.HISFC.Models.Registration.Register();
            this.tbApprPerson.Text = string.Empty;
            this.tbDescribe.Text = string.Empty;
            this.tbJBR.Text = string.Empty;
            this.tbMarkNO.Text = string.Empty;
            this.tbSex.Text = string.Empty;
            this.tbName.Text = string.Empty;

        }

        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <returns></returns>
        private int InitDiagnose()
        {
            ArrayList al = new ArrayList();
            al = this.localManager.GetDiagnose();
            if (al != null && al.Count != 0)
            {
                this.cmbDesease.AddItems(al);
            }
            return 1;
        }


        /// <summary>
        /// 初始化医疗类别
        /// </summary>
        /// <returns></returns>
        private int InitMedicalType()
        {
            this.cmbApprKind.Items.Add("生育审批");
            this.cmbApprKind.Tag = "11";
            this.cmbApprKind.Text = "生育审批";
            return 1;
        }
        /// <summary>
        /// 上传审批信息
        /// </summary>
        /// <param name="r">患者信息实体</param>
        /// <returns></returns>
        private int UpLoadAprInfo(Neusoft.HISFC.Models.Registration.Register r)
        {
            return 1;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            //清屏
            this.Clear();
            //读卡获得患者信息
            this.ReadCard();
        }

        /// <summary>
        /// 加裁事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSreimApprove_Load(object sender, EventArgs e)
        {
            //初始化
            this.Init();
        }


        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            long returnValue = this.UpLoadAprInfo(register);
            if (returnValue == 1)
            {
                this.process.Commit();
                MessageBox.Show("申请成功");
            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}