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
    /// ［功能描述：住院出院登记医疗类别修改窗口］
    /// ［创建人：］
    /// ［创建时间：］
    /// ［修改人：］
    /// ［修改时间：2009－2－12］
    /// ［修改原因：代码格式修改及诊断属性修改］
    /// </summary>
    public partial class frmSiPobInPatientInfoOut : Form
    {
        public frmSiPobInPatientInfoOut()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 住院患者实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;

        /// <summary>
        /// 新医疗类别
        /// </summary>
        public string medicalType = string.Empty;

        /// <summary>
        /// 本地业务层
        /// </summary>
        LocalManager lm = new LocalManager();
        
        /// <summary>
        /// 旧医疗类别
        /// </summary>
        string oldMType = "";

        #endregion

        #region 属性
        /// <summary>
        /// 住院患者实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化医疗类别        /// </summary>
        /// <returns></returns>
        protected int InitMedicalType()
        {
            EnumMedicalTypeServiceInhos es = new EnumMedicalTypeServiceInhos();
            this.cmbMedicalType.AddItems(EnumMedicalTypeServiceInhos.List());
            if (this.patient.SIMainInfo.MedicalType.ID != null && this.patient.SIMainInfo.MedicalType.ID != "")
            {
                this.cmbMedicalType.Tag = this.patient.SIMainInfo.MedicalType.ID;
                //存放旧诊断代码，以便保存时进行选择提示
                this.oldMType = this.patient.SIMainInfo.MedicalType.ID;
            }
            else
            {
                //默认医保类别
                this.cmbMedicalType.Tag = "21";
            }

            return 1;
        }
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <returns></returns>
        protected int InitDiagnose()
        {
            if (this.patient.SIMainInfo.OutDiagnose.Name != null && this.patient.SIMainInfo.OutDiagnose.Name != "")
            {
                this.textDiagnose.Text = this.patient.SIMainInfo.OutDiagnose.Name;
                this.textDiagnose.Enabled = false;
            }
            else
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("未找到诊断信息!"));
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 输入值校验
        /// </summary>
        /// <returns></returns>
        public int Valid()
        {
            //必须输入类别
            if (this.cmbMedicalType.Tag == null || this.cmbMedicalType.Text.Trim() == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择医疗类别"));
                this.cmbMedicalType.Focus();
                return -1;
            }
            //判断新输入的医疗类别是否有变化            if (this.cmbMedicalType.Tag.ToString() == this.oldMType)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("患者医疗类别没有变化！"));
                this.cmbMedicalType.Focus();
                return -1;
            }
            else
            {
                //请用户确认更新                if (MessageBox.Show(this,"是否更新患者医疗类别？","提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 获取新的医疗类别        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            this.patient.SIMainInfo.MedicalType.ID = this.cmbMedicalType.Tag.ToString();
            return 1;

        }

        /// <summary>
        /// 加裁事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSiPobInpatientInfo_Load(object sender, EventArgs e)
        {
            this.InitMedicalType();
            this.InitDiagnose();
            this.cmbMedicalType.Focus();
        }


        /// <summary>
        /// 确定 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //校验
            if (this.Valid() == 1)
            {
                if (this.GetValue() == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }      

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMedicalType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                if (textDiagnose.Enabled)
                {
                    textDiagnose.Focus();
                }
                else
                {
                    btnOK.Focus();
                }
            }
        }

        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDiagNose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                btnOK.Focus();
            }
        }
        #endregion
    }
}