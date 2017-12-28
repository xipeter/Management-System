using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ShenYangCitySI.Control
{
    public partial class frmSreimApprove : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        #region 变量
        //接口类
        Process process = new Process();
        //本地业务层
        LocalManager localManager = new LocalManager();
        Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();
        #endregion
        public frmSreimApprove()
        {
            InitializeComponent();
        }

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
           returnValue=  process.GetRegInfoOutpatient(register);
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
            this.tbMarkNO.Text= string.Empty;
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
            al = this.localManager.GetDiagnoseby();
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
        /// 
        private int UpLoadAprInfo(Neusoft.HISFC.Models.Registration.Register r)
        {
            long returnValue = process.Connect();
            if (returnValue < 0)
            {
                MessageBox.Show(process.ErrMsg);
                return -1;
            }
            string inPutString = string.Empty;//上传字符串
            string dateSB = this.dtpSBRQ.Value.ToString("yyyyMMdd"); //申报日期
            string apprdate = this.dtpSPRQ.Value.ToString("yyyyMMdd");//审批日期
            string remark = this.tbDescribe.Text;
            string apprPerson = this.tbApprPerson.Text;
            r.SIMainInfo.InDiagnose.ID = this.cmbDesease.Tag.ToString() ;
            r.SIMainInfo.InDiagnose.Name = this.cmbDesease.Text;
            //StringBuilder dataBuffer = new StringBuilder(1024);
            string dataBuffer = string.Empty;
            
	        //|个人编号|审批类别|病种编码|科主任意见|诊断意见|申报日期|审批人|审批日期|审批标志|经办人|备注|

            inPutString = "|" + r.SSN /*个人编号*/ +
                             "|" + cmbApprKind.Tag/*审批类别*/ +
                             "|" + r.SIMainInfo.InDiagnose.ID/*病种编码*/ +
                             "|" + ""         /*科主任意见*/ +
                             "|" + r.SIMainInfo.InDiagnose.Name/*诊断意见*/ +
                             "|" + dateSB  /*申报日期*/ +
                             "|" + apprPerson/*审批人*/ +
                             "|" + apprdate/*审批日期*/ +
                             "|" + "1"/*审批标志*/ +
                             "|" + Neusoft.FrameWork.Management.Connection.Operator.ID     /*经办人*/   +
                             "|" + remark/*备注*/     +
                             "|";

            returnValue = Functions.Bussiness("41", inPutString, dataBuffer);
            
            if (returnValue < 0)
            {
                process.Rollback();
                MessageBox.Show("调用医保接口时出错!" + dataBuffer);
                return -1;
            }

            returnValue = process.Disconnect();
            if (returnValue < 0)
            {
                MessageBox.Show(process.ErrMsg);
                process.Rollback();
                return -1;
            }
            return 1;
        }

        #endregion

        #region 事件

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            //清屏
            this.Clear();
            //读卡获得患者信息
            this.ReadCard();

            
        }

        private void frmSreimApprove_Load(object sender, EventArgs e)
        {
            //初始化
            this.Init();
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            long returnValue = this.UpLoadAprInfo(register);
            if (returnValue == 1)
            {
                this.process.Commit();
                MessageBox.Show("申请成功");
            }
            

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}