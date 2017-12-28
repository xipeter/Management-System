using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UFC.HealthRecord
{
    public partial class ucDocDiagNoseInput : UserControl
    {
        public ucDocDiagNoseInput()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
        /// <summary>
        /// 门诊号 住院号
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        public int LoadInfo(string InpatientNo)
        {
            //this.ucDiagNoseInput1.OperType = Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC;
            //if (InpatientNo == null || InpatientNo == "")
            //{
            //    patientInfo = null;
            //    MessageBox.Show("传入的住院流水号为空");
            //    return -1;
            //}
            //Neusoft.HISFC.Integrate.RADT pa = new Neusoft.HISFC.Integrate.RADT();// Neusoft.HISFC.Management.RADT.InPatient();
            //Neusoft.HISFC.Integrate.Registration.Registration register = new Neusoft.HISFC.Integrate.Registration.Registration();
            ////从住院主表中查旬
            //patientInfo = pa.GetPatientInfoByPatientNO(InpatientNo);
            //if (patientInfo == null)
            //{
            //    Neusoft.HISFC.Object.Registration.Register obj = register.GetByClinic(InpatientNo);
            //    if (obj == null)
            //    {
            //        MessageBox.Show("查询病人信息出错");
            //        return -1;
            //    }
            //    patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
            //    patientInfo.ID = obj.ID;
            //    patientInfo.CaseState = "1";
            //}
            //this.ucDiagNoseInput1.LoadInfo(InpatientNo);
            //this.ucDiagNoseInput1.fpEnterSaveChanges();
            //if (this.ucDiagNoseInput1.GetfpSpreadRowCount() == 0)
            //{
            //    this.ucDiagNoseInput1.AddRow();
            //}
            return 1;
        }
        /// <summary>
        /// 初始化表 和部分下拉选项 （不包括ICD码 ）
        /// </summary>
        /// <returns></returns>
        public void InitInfo()
        {
            //this.ucDiagNoseInput1.InitInfo();
        }
        /// <summary>
        /// 初始化ＩＣＤ列表
        /// </summary>
        /// <returns></returns>
        public int InitICDList()
        {
            //ICD10 诊断
            //			Neusoft.HISFC.Management.HealthRecord.ICD icd = new Neusoft.HISFC.Management.HealthRecord.ICD();
            //			ArrayList icdList = icd.Query(Neusoft.HISFC.Management.HealthRecord.ICDTypes.ICD10,Neusoft.HISFC.Management.HealthRecord.QueryTypes.Valid);
            //			if(icdList == null)
            //			{
            //				MessageBox.Show("获取ICD码失败" +icd.Err);
            //				return -1;
            //			}
            //			
            //			this.ucDiagNoseInput1.InitICDList(icdList);
            return 1;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }
        /// <summary>
        /// 保存 
        /// </summary>
        /// <returns>1 保存成功 ,-1 保存失败</returns>
        private int Save()
        {

            //Neusoft.HISFC.Management.HealthRecord.Diagnose diagNose = new Neusoft.HISFC.Management.HealthRecord.Diagnose();
            //Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(diagNose.Connection);
            //trans.BeginTransaction();
            //diagNose.SetTrans(trans.Trans);

            //ArrayList diagAdd = new ArrayList();
            //ArrayList diagMod = new ArrayList();
            //ArrayList diagDel = new ArrayList();
            //this.ucDiagNoseInput1.deleteRow();
            //this.ucDiagNoseInput1.GetList("A", diagAdd);
            //this.ucDiagNoseInput1.GetList("M", diagMod);
            //this.ucDiagNoseInput1.GetList("D", diagDel);
            //if (this.ucDiagNoseInput1.ValueState(diagAdd) == -1 || this.ucDiagNoseInput1.ValueState(diagMod) == -1 || this.ucDiagNoseInput1.ValueState(diagDel) == -1)
            //{

            //    trans.RollBack();
            //    return -1;
            //}

            //if (diagDel != null)
            //{
            //    foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose obj in diagDel)
            //    {
            //        if (diagNose.DeleteDiagnoseSingle(obj.DiagInfo.Patient.ID, obj.DiagInfo.HappenNo, Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC) < 1)
            //        {



            //            trans.RollBack();
            //            MessageBox.Show("保存诊断信息失败" + diagNose.Err);
            //            return -1;
            //        }
            //    }
            //}
            //if (diagMod != null)
            //{
            //    foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose obj in diagMod)
            //    {
            //        if (diagNose.UpdateDiagnose(obj) < 1)
            //        {
            //            if (diagNose.InsertDiagnose(obj) < 1)
            //            {




            //                trans.RollBack();
            //                MessageBox.Show("保存诊断信息失败" + diagNose.Err);
            //                return -1;
            //            }
            //        }
            //        string result = diagNose.IsInfect(obj.DiagInfo.ICD10.ID);
            //        if (result == "Error")
            //            MessageBox.Show("查询诊断信息出错！", "提示");
            //        if (result == "1")
            //        {
            //            MessageBox.Show("诊断:" + obj.DiagInfo.ICD10.Name + "为传染病诊断，请填写传染病报告卡!", "提示");
            //        }
            //    }
            //}
            //if (diagAdd != null)
            //{
            //    foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose obj in diagAdd)
            //    {
            //        if (diagNose.InsertDiagnose(obj) < 1)
            //        {



            //            trans.RollBack();
            //            MessageBox.Show("保存诊断信息失败" + diagNose.Err);
            //            return -1;
            //        }
            //        string result = diagNose.IsInfect(obj.DiagInfo.ICD10.ID);
            //        if (result == "Error")
            //            MessageBox.Show("查询诊断信息出错！", "提示");
            //        if (result == "1")
            //        {
            //            MessageBox.Show("诊断:" + obj.DiagInfo.ICD10.Name + "为传染病诊断，请填写传染病报告卡!", "提示");
            //        }
            //    }
            //}
            //this.ucDiagNoseInput1.fpEnterSaveChanges();
            //trans.Commit();
            //this.ucDiagNoseInput1.ClearInfo();
            //this.ucDiagNoseInput1.LoadInfo(patientInfo.ID);
            //MessageBox.Show("保存成功");
            return 1;
        }

        private void btAdd_Click(object sender, System.EventArgs e)
        {

            //if (this.Tag != null)
            //{
            //    this.ucDiagNoseInput1.AddBlankRow(); //增加一行
            //}
            //else
            //{
                //增加一行
                this.ucDiagNoseInput1.AddRow();
            //}
        }

        private void btdele_Click(object sender, System.EventArgs e)
        {
            this.ucDiagNoseInput1.DeleteActiveRow();//删除一行 
        }

        private void tbPrint_Click(object sender, System.EventArgs e)
        {
            ////			this.ucDiagNoseInput1.
            //ucCaseInputForClinic uc = new  ucCaseInputForClinic();
            //Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);
        }

        private void ucDocDiagNoseInput_Load(object sender, System.EventArgs e)
        {
            InitICDList();
            this.ucDiagNoseInput1.AddRow();
            this.ucDiagNoseInput1.Tag = this.Tag;
        }
    }
}
