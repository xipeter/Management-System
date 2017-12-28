using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace HeNanProvinceSI.Diagnosis
{
    /// <summary>
    /// [功能描述: 沈阳市医保诊断录入]<br></br>
    /// [创 建 者: 许超]<br></br>
    /// [创建时间: 2009-2-18]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间=''
    ///	修改目的=''
    ///	修改描述=''
    /// </summary>
    public partial class ucSIDiagnosis : Form
    {
        public ucSIDiagnosis()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 本地业务层
        /// </summary>
        LocalManager localManager = new LocalManager();

        /// <summary>
        /// 核心住院业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT patientManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 当前患者实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patient;

        /// <summary>
        /// 诊断实体
        /// </summary>
        Object.ExtendProperty diagProperty;

        /// <summary>
        /// 主码
        /// </summary>
        Object.ICDMedicare mainDiag;

        /// <summary>
        /// 识别码 
        /// </summary>
        Object.ICDMedicare regDiag;

        /// <summary>
        /// 手术码1
        /// </summary>
        Object.ICDMedicare operDiag1;

        /// <summary>
        /// 手术码2
        /// </summary>
        Object.ICDMedicare operDiag2;

        /// <summary>
        /// 手术码3
        /// </summary>
        Object.ICDMedicare operDiag3;

        /// <summary>
        /// 日期格式
        /// </summary>
        string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 医疗类别帮助类
        /// </summary>
        Neusoft.FrameWork.Public.ObjectHelper medicareHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion

        #region 方法

        /// <summary>
        /// 保存诊断
        /// </summary>
        private void SaveDiag()
        {
            if (this.ValidValue() == false)
            {
                return;
            }

            if (this.GetValue() == false)
            {
                return;
            }

            if (this.localManager.UpdateInpatientOutDiagnoiseInnfo(this.diagProperty, this.patient) <= 0)
            {
                MessageBox.Show("保存诊断数据出错！\n" + this.localManager.Err);
                return;
            }

            MessageBox.Show("保存数据成功！");
        }

        /// <summary>
        /// 获取封装诊断
        /// </summary>
        /// <returns></returns>
        private bool GetValue()
        {
            this.diagProperty = new HeNanProvinceSI.Object.ExtendProperty();

            if (this.operDiag1 != null)
            {
                diagProperty.OperatorCode1 = this.operDiag1.ID;
            }
            
            if (this.operDiag2 != null)
            {
                diagProperty.OperatorCode2 = this.operDiag2.ID;
            }
            
            if (this.operDiag3 != null)
            {
                diagProperty.OperatorCode3 = this.operDiag3.ID;
            }
            
            if (this.mainDiag != null)
            {
                diagProperty.MainDiagnoseCode = this.mainDiag.ID;
                diagProperty.MainDiagnoseName = this.mainDiag.Name;
            }

            if (this.regDiag != null)
            {
                diagProperty.PrimaryDiagnoseCode = this.regDiag.ID;
                diagProperty.PrimaryDiagnoseName = this.regDiag.Name;
            }

            return true;
        }

        /// <summary>
        /// 验证正确性
        /// </summary>
        /// <returns></returns>
        private bool ValidValue()
        {
            if (this.patient == null)
            {
                return false;
            }

            //主码
            this.mainDiag = this.cmbMainDiag.SelectedItem as Object.ICDMedicare;
            //识别码 
            this.regDiag = this.cmbRecognitionDiag.SelectedItem as Object.ICDMedicare;
            //手术码
            this.operDiag1 = this.cmbOperation1Diag.SelectedItem as Object.ICDMedicare;
            this.operDiag2 = this.cmbOperation2Diag.SelectedItem as Object.ICDMedicare;
            this.operDiag3 = this.cmbOperation3Diag.SelectedItem as Object.ICDMedicare;

            if (mainDiag == null)
            {
                MessageBox.Show("主码诊断必须录入！");
                this.cmbMainDiag.Focus();
                return false;
            }

            if (this.patient.SIMainInfo.MedicalType.ID == "24"
                || this.patient.SIMainInfo.MedicalType.ID == "25"
                || this.patient.SIMainInfo.MedicalType.ID == "42")
            {
                if (regDiag == null)
                {
                    MessageBox.Show("特病、家病、生育、单病种必须录入识别码!");
                    this.cmbRecognitionDiag.Focus();
                    return false;
                }
            }

            switch (this.patient.SIMainInfo.MedicalType.ID)
            {
                case "21":
                case "22":
                case "24":
                case "29":
                    if (mainDiag.UseArea == "0" || mainDiag.UseArea == "4")
                    {
                        if (mainDiag.UseArea == "4")
                        {
                            if (mainDiag.ID != "10560")
                            {
                                MessageBox.Show("普通住院、转入医院、特殊住院、定点医疗机构急诊住院”患者录入主码目录上“范围内外”为'4'的诊断时识别码必须是‘10560’！");
                                this.cmbMainDiag.Focus();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("普通住院、转入医院、特殊住院、定点医疗机构急诊住院”患者主码主码必须录入主码目录上“范围内外”为‘0’的诊断！");
                        this.cmbMainDiag.Focus();
                        return false;
                    }

                    if (!(mainDiag.DisKind == "1" || mainDiag.DisKind == "2"))
                    {
                        MessageBox.Show("普通住院、转入医院、特殊住院、定点医疗机构急诊住院”患者主码必须录入诊断类别类别为‘I类’、‘II类’的诊断！");
                        this.cmbMainDiag.Focus();
                        return false;
                    }
                    break;
                case "25":
                    if (regDiag == null)
                    {
                        MessageBox.Show("医疗类别为“家庭病床”时，识别码必须录入!");
                        this.cmbRecognitionDiag.Focus();
                        return false;
                    }
                    #region {28E32DE0-2126-484d-85B7-F838A736D286}  zjl
                    //if (regDiag.UseArea == "6")
                    if (!(regDiag.UseArea == "6"))
                    #endregion
                    {
                        MessageBox.Show("医疗类别为“家庭病床”时，识别码必须为家庭病床专用码!");
                        this.cmbRecognitionDiag.Focus();
                        return false;
                    }
                    break;
                case "42":
                case "43":
                case "45":
                    if (regDiag == null)
                    {
                        MessageBox.Show("医疗类别为“生育住院、节育住院、生育转入住院”时，诊断 识别码 必须录入!");
                        this.cmbRecognitionDiag.Focus();
                        return false;
                    }
                    #region {28E32DE0-2126-484d-85B7-F838A736D286} zjl
                    //if (regDiag.UseArea == "5")
                    if (!(regDiag.UseArea == "5"))
                    #endregion
                    {
                        MessageBox.Show("医疗类别为“生育住院、节育住院、生育转入住院”时，识别码必须为生育专用码!");
                        this.cmbRecognitionDiag.Focus();
                        return false;
                    }
                    if (!(mainDiag.UseArea == "3" || mainDiag.UseArea == "4"))
                    {
                        MessageBox.Show("医疗类别为“生育住院、节育住院、生育转入住院”时，主码必须录入“范围内外”为‘3、4’的诊断!");
                        this.cmbMainDiag.Focus();
                        return false;
                    }
                    break;
            }

            return true;

        }

        /// <summary>
        /// 显示患者信息
        /// </summary>
        private void ShowPatientInfo()
        {
            if (this.patient != null)
            {
                //姓名
                this.txtName.Text = this.patient.Name;

                //性别
                this.txtSex.Text = this.patient.Sex.Name;

                //出生日期
                this.txtBrithday.Text = this.patient.Birthday.ToString(this.DateTimeFormat);

                //科室
                this.txtDept.Text = this.patient.PVisit.PatientLocation.Dept.Name;

                //入院时间
                this.txtInTime.Text = this.patient.PVisit.InTime.ToString(this.DateTimeFormat);

                //合同单位
                this.txtPact.Text = this.patient.Pact.Name;

                //医疗类别
                this.txtMedcareType.Text = this.GetInMedicalTypeName(this.patient.SIMainInfo.MedicalType.ID);

                //主码
                if (string.IsNullOrEmpty(this.patient.SIMainInfo.OutDiagnose.ID) == false)
                {
                    this.cmbMainDiag.Tag = this.patient.SIMainInfo.OutDiagnose.ID;
                    if (this.cmbMainDiag.SelectedIndex == -1)
                    {
                        this.cmbMainDiag.Tag = null;
                    }
                }

                Object.ExtendProperty diagDroperty = Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty);

                //识别码
                if (string.IsNullOrEmpty(diagDroperty.PrimaryDiagnoseCode) == false)
                {
                    this.cmbRecognitionDiag.Tag = diagDroperty.PrimaryDiagnoseCode;
                    if (this.cmbRecognitionDiag.SelectedIndex == -1)
                    {
                        this.cmbRecognitionDiag.Tag = null;
                    }
                }

                //手术1
                if (string.IsNullOrEmpty(diagDroperty.OperatorCode1) == false)
                {
                    this.cmbOperation1Diag.Tag = diagDroperty.OperatorCode1;
                    if (this.cmbOperation1Diag.SelectedIndex == -1)
                    {
                        this.cmbOperation1Diag.Tag = null;
                    }
                }

                //手术2
                if (string.IsNullOrEmpty(diagDroperty.OperatorCode2) == false)
                {
                    this.cmbOperation2Diag.Tag = diagDroperty.OperatorCode2;
                    if (this.cmbOperation2Diag.SelectedIndex == -1)
                    {
                        this.cmbOperation2Diag.Tag = null;
                    }
                }

                //手术3
                if (string.IsNullOrEmpty(diagDroperty.OperatorCode3) == false)
                {
                    this.cmbOperation3Diag.Tag = diagDroperty.OperatorCode3;
                    if (this.cmbOperation3Diag.SelectedIndex == -1)
                    {
                        this.cmbOperation3Diag.Tag = null;
                    }
                }
            }
        }

        /// <summary>
        /// 获取医疗类别名称
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetInMedicalTypeName(string p)
        {
            return this.medicareHelper.GetName(p);
        }

        /// <summary>
        /// 初始化其它数据
        /// </summary>
        private void initData()
        {
            EnumMedicalTypeServiceInhos types = new EnumMedicalTypeServiceInhos();
            this.medicareHelper.ArrayObject = EnumMedicalTypeServiceInhos.List();
        }

        /// <summary>
        /// 加载诊断信息
        /// </summary>
        private void LoadDiags()
        {
            ArrayList mainDiag = this.localManager.GetDiagnose();
            if (mainDiag != null)
            {
                this.cmbMainDiag.AddItems(mainDiag);
            }
            ArrayList recogDiag = this.localManager.GetPDiagnose();
            if (recogDiag != null)
            {
                this.cmbRecognitionDiag.AddItems(recogDiag);
            }
            ArrayList operDiag = this.localManager.GetOperate();
            if (operDiag != null)
            {
                this.cmbOperation1Diag.AddItems(operDiag);
                this.cmbOperation2Diag.AddItems(operDiag);
                this.cmbOperation3Diag.AddItems(operDiag);
            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void ClearShow()
        {
            this.txtBrithday.Text = "";
            this.txtDept.Text = "";
            this.txtInTime.Text = "";
            this.txtMedcareType.Text = "";
            this.txtName.Text = "";
            this.txtPact.Text = "";
            this.txtSex.Text = "";
            this.cmbMainDiag.Tag = null;
            this.cmbOperation1Diag.Tag = null;
            this.cmbOperation2Diag.Tag = null;
            this.cmbOperation3Diag.Tag = null;
            this.cmbRecognitionDiag.Tag = null;
        }

        #endregion

        #region 事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOK_Click(object sender, EventArgs e)
        {
            this.SaveDiag();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSIDiagnosis_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化窗口，请稍候。");
            Application.DoEvents();

            this.initData();
            this.LoadDiags();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 住院号
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            this.ClearShow();

            if (string.IsNullOrEmpty(this.ucQueryInpatientNo1.InpatientNo))
            {
                MessageBox.Show("未找到患者！");
                return;
            }

            this.patient = null;
            this.patient = this.patientManager.QueryPatientInfoByInpatientNO(this.ucQueryInpatientNo1.InpatientNo);
            if (string.IsNullOrEmpty(this.patient.ID))
            {
                patient = null;
                MessageBox.Show("查找患者信息出错！\n" + this.patientManager.Err);
                return;
            }

            this.patient = this.localManager.GetSIPersonInfo(patient.ID, "0");
            if (this.patient == null)
            {
                this.patient = null;
                MessageBox.Show("此患者不是医保患者！");
                return;
            }

            if (string.IsNullOrEmpty(this.patient.ID))
            {
                this.patient = null;
                MessageBox.Show("此患者不是医保患者！");
                return;
            }

            this.ShowPatientInfo();

            this.cmbMainDiag.Focus();
        }



        private void cmbMainDiag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.cmbMainDiag.Tag = null;
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.cmbRecognitionDiag.Tag = null;
        }

        private void neuButton3_Click(object sender, EventArgs e)
        {
            this.cmbOperation1Diag.Tag = null;
        }

        private void neuButton4_Click(object sender, EventArgs e)
        {
            this.cmbOperation2Diag.Tag = null;
        }

        private void neuButton5_Click(object sender, EventArgs e)
        {
            this.cmbOperation3Diag.Tag = null;
        }

        #endregion
    }
}
