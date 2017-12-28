using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    /// <summary>
    /// ucCaseMainInfo<br></br>
    /// [功能描述: 住院医生诊断录入]<br></br>
    /// [创 建 者: dorian]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDocDiagnoseInput : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDocDiagnoseInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 患者信息
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        #region 属性

        #region {8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
        /// <summary>
        /// 是否是病案录入诊断  医生站录入诊断和病案室录入诊断存的表不同
        /// </summary>
        public enum enumDiagInput
        {
            cas,
            order,
            outPatientOrder
        }
        private enumDiagInput enumdiaginput = enumDiagInput.cas;

        [Category("门诊医生站、住院医生站还是病案室录诊断"), Description("病案室录入诊断与医生录入诊断所存的表不同")]
        public enumDiagInput Enumdiaginput
        {
            get
            {
                return enumdiaginput;
            }
            set
            {
                enumdiaginput = value;
                if (enumdiaginput == enumDiagInput.cas)
                {
                    this.ucDiagNoseInput1.IsCas = true;
                }
                else
                {
                    this.ucDiagNoseInput1.IsCas = false;
                }
            }
        }

        //判断是否是编目组调用，如果是修改病案诊断是医生录入的，不是诊断室录入的(中日病案室不录入诊断)
        public bool isList = false;
        #endregion

        #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}
        /// <summary>
        /// 科室常用诊断标志
        /// </summary>
        private bool isUseDeptICD = false;

        /// <summary>
        /// 科室常用诊断标志
        /// </summary>
        [Category("科室常用诊断"), Description("是否其使用科室常用诊断")]
        public bool IsUseDeptICD
        {
            get
            {
                return isUseDeptICD;
            }
            set
            {
                isUseDeptICD = value;
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// 门诊号 住院号
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        public int LoadInfo(string InpatientNo)
        {
            if (InpatientNo == null || InpatientNo == "")
            {
                patientInfo = null;
                MessageBox.Show("传入的住院流水号为空");
                return -1;
            }

            Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

            //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
            if (Enumdiaginput == enumDiagInput.order)//住院医生
            {
                //从住院主表中查旬
                patientInfo = radtIntegrate.GetPatientInfomation(InpatientNo);
                if (patientInfo == null)
                {
                    Neusoft.HISFC.Models.Registration.Register obj = registerIntegrate.GetByClinic(InpatientNo);
                    if (obj == null)
                    {
                        MessageBox.Show("查询病人信息出错");
                        return -1;
                    }
                    patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    patientInfo.ID = obj.ID;
                    patientInfo.CaseState = "1";
                }
                //this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC);
                this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC, enumdiaginput.ToString());

            }
            else if (Enumdiaginput == enumDiagInput.outPatientOrder)//门诊医生
            {
                Neusoft.HISFC.Models.Registration.Register obj = registerIntegrate.GetByClinic(InpatientNo);
                if (obj == null)
                {
                    MessageBox.Show("查询病人信息出错");
                    return -1;
                }
                patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                patientInfo.ID = obj.ID;
                patientInfo.PID.CardNO = obj.PID.CardNO;
                patientInfo.CaseState = "1";
                this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC, enumdiaginput.ToString());

            }
            else if (Enumdiaginput == enumDiagInput.cas)
            {
                //从住院主表中查旬
                patientInfo = radtIntegrate.GetPatientInfomation(InpatientNo);
                if (patientInfo == null)
                {
                    Neusoft.HISFC.Models.Registration.Register obj = registerIntegrate.GetByClinic(InpatientNo);
                    if (obj == null)
                    {
                        MessageBox.Show("查询病人信息出错");
                        return -1;
                    }
                    patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    patientInfo.ID = obj.ID;
                    patientInfo.CaseState = "1";
                }
                this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS, enumdiaginput.ToString());

            }

            this.ucDiagNoseInput1.fpEnterSaveChanges();
            if (this.ucDiagNoseInput1.GetfpSpreadRowCount() == 0)
            {
                this.ucDiagNoseInput1.AddRow();
            }
            return 1;
        }

        /// <summary>
        /// 初始化表 和部分下拉选项 （不包括ICD码 ）
        /// </summary>
        /// <returns></returns>
        public void InitInfo()
        {
            this.ucDiagNoseInput1.InitInfo();
        }

        /// <summary>
        /// 保存 
        /// </summary>
        /// <returns>1 保存成功 ,-1 保存失败</returns>
        private int Save()
        {

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diagNose = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(diagNose.Connection);
            //trans.BeginTransaction();
            //diagNose.SetTrans(trans.Trans);

            ArrayList diagAdd = new ArrayList();
            ArrayList diagMod = new ArrayList();
            ArrayList diagDel = new ArrayList();

            this.ucDiagNoseInput1.deleteRow();
            this.ucDiagNoseInput1.GetList("A", diagAdd);
            this.ucDiagNoseInput1.GetList("M", diagMod);
            this.ucDiagNoseInput1.GetList("D", diagDel);

            //{6873115C-BBAC-4de0-95BB-F905B766F5AA}
            if (diagAdd.Count == 0 && diagDel.Count == 0 && diagMod.Count == 0)
            {
                MessageBox.Show("无需保存");
                return -1;
            }

            if (this.ucDiagNoseInput1.ValueState(diagAdd) == -1 || this.ucDiagNoseInput1.ValueState(diagMod) == -1 || this.ucDiagNoseInput1.ValueState(diagDel) == -1)
            {
                //trans.RollBack();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            if (diagDel != null)
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in diagDel)
                {
                    //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                    if (enumdiaginput == enumDiagInput.cas)
                    {
                        if (diagNose.DeleteDiagnoseSingle(obj.DiagInfo.Patient.ID, obj.DiagInfo.HappenNo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC) < 1)
                        {
                            //trans.RollBack();
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                            return -1;
                        }
                    }
                    else
                    {
                        if (diagNose.DeleteDiagnoseSingle(obj.DiagInfo.Patient.ID, obj.DiagInfo.HappenNo) < 1)
                        {
                            //trans.RollBack();
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("删除诊断信息失败" + diagNose.Err);
                            return -1;
                        }

                    }
                }
            }
            if (diagMod != null)
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in diagMod)
                {
                                        //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                    if (enumdiaginput == enumDiagInput.cas)
                    {
                        if (diagNose.UpdateDiagnose(obj) < 1)
                        {
                            if (diagNose.InsertDiagnose(obj) < 1)
                            {
                                //trans.RollBack();
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                                return -1;
                            }
                        }
                    }
                    else
                    {
                        if (diagNose.UpdatePatientDiagnose(obj) < 1)
                        {
                            if (diagNose.CreatePatientDiagnose(obj) < 1)
                            {
                                //trans.RollBack();
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                                return -1;
                            }
                        }
                    }
                    string result = diagNose.IsInfect(obj.DiagInfo.ICD10.ID);
                    if (result == "Error")
                        MessageBox.Show("查询诊断信息出错！", "提示");
                    if (result == "1")
                    {
                        MessageBox.Show("诊断:" + obj.DiagInfo.ICD10.Name + "为传染病诊断，请填写传染病报告卡!", "提示");
                    }
                }
            }
            if (diagAdd != null)
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in diagAdd)
                {
                                        //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                    if (enumdiaginput == enumDiagInput.cas)
                    {
                        if (diagNose.InsertDiagnose(obj) < 1)
                        {
                            //trans.RollBack();
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                            return -1;
                        }
                    }
                    else
                    {
                        obj.DiagInfo.HappenNo = diagNose.GetNewDignoseNo();
                        if (obj.DiagInfo.HappenNo < 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("取诊断流水号失败" + diagNose.Err);
                            return -1;

                        }

                        if (diagNose.CreatePatientDiagnose(obj) < 1)
                        {
                            //trans.RollBack();
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                            return -1;
                        }
                    }
                    string result = diagNose.IsInfect(obj.DiagInfo.ICD10.ID);
                    if (result == "Error")
                        MessageBox.Show("查询诊断信息出错！", "提示");
                    if (result == "1")
                    {
                        MessageBox.Show("诊断:" + obj.DiagInfo.ICD10.Name + "为传染病诊断，请填写传染病报告卡!", "提示");
                    }
                }
            }

            this.ucDiagNoseInput1.fpEnterSaveChanges();
            
            //trans.Commit();
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.ucDiagNoseInput1.ClearInfo();

            //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
            //this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC);
            if (Enumdiaginput == enumDiagInput.order || Enumdiaginput == enumDiagInput.outPatientOrder)
            {
                this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC, enumdiaginput.ToString());
            }
            else if (Enumdiaginput == enumDiagInput.cas)
            {
                if (isList)
                {
                    //this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC, enumdiaginput.ToString());
                    LoadInfo(patientInfo.ID);
                }
                else
                {
                    this.ucDiagNoseInput1.LoadInfo(patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS, enumdiaginput.ToString());
                }

            }

            MessageBox.Show("保存成功");

            return 1;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            return this.Save();
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
            {
                this.patientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;

                this.LoadInfo(this.patientInfo.ID);
            }
            //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
            if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.Registration.Register))
            {
                Neusoft.HISFC.Models.Registration.Register objReg = neuObject as Neusoft.HISFC.Models.Registration.Register;

                this.LoadInfo(objReg.ID);
            }

            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.Save();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            //if (this.Tag != null)
            //{
                this.ucDiagNoseInput1.AddBlankRow(); //增加一行
            //}
            //else
            //{
            //    //增加一行
            //    this.ucDiagNoseInput1.AddRow();
            //}
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            this.ucDiagNoseInput1.DeleteActiveRow();//删除一行 
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            //HealthRecord.CaseFirstPage.uccase uc = new ucCaseInputForClinic();
            //Neusoft.neuFC.Interface.Classes.Function.PopShowControl(uc);
        }

        private void ucDocDiagNoseInput_Load(object sender, System.EventArgs e)
        {
            #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}
            this.ucDiagNoseInput1.IsUseDeptICD = this.isUseDeptICD;
            #endregion
            this.InitInfo();

            this.ucDiagNoseInput1.AddRow();
            this.ucDiagNoseInput1.Tag = "AddNew";
        }
    }
}
