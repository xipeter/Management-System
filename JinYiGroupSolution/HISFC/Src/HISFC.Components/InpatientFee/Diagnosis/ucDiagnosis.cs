using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizLogic;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.InpatientFee.Diagnosis
{
    /// <summary>
    /// 类名称<br>ucDiagnosis</br>
    /// <Font color='#FF1111'>[功能描述: 入院诊断录入]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-08-14]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucDiagnosis : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucDiagnosis()
        {
            InitializeComponent();
            this.Init();
        }
        #region 变量

        #region 私有

        /// <summary>
        /// 入出转integrate层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        private int happenNo;//选中记录的happenNo

        private String iType = null;//页面选中的ICD的类型

        private String icdSpell = "";//ICD拼音码

        private String operType = "";//类别 1 医生站录入诊断  2 病案室录入诊断

        private String selectedIType = "";//选中记录的原ICD类别

        private bool isDiagSelect = false;

        //private String inpatientNO = "";// 住院流水号

        //private Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes operType = null;//页面选中的记录的OperType(仅限病案诊断记录)
        
        #endregion

        #region 保护

        /// <summary>
        /// 患者基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 公共管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 诊断业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase diagnoseMgr = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase();
        protected Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC diagnoseMgrMc = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC();
        protected Neusoft.HISFC.Models.HealthRecord.Diagnose myDiagnose = new Neusoft.HISFC.Models.HealthRecord.Diagnose();

        protected bool isUpdate = false;

        protected bool isOutMain = false;
        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        #endregion

        #region 公开
        #endregion

        #endregion

        #region 属性

        /// <summary>
        /// 当前窗口是否设计模式
        /// </summary>
        protected new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }

        #endregion

        #region 方法

        #region 资源释放
        #endregion

        #region 克隆
        #endregion

        #region 私有

        /// <summary>
        /// 页面上填入患者基本信息
        /// </summary>
        private int FillPatientInfo()
        {
            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("住院号错误，没有找到该患者", 111);
                this.ucQueryInpatientNo.Focus();
                return -1;
            }
            try
            {
                this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);
                //判断患者状态

                if (this.ValidPatient(this.patientInfo) == -1)
                {
                    this.ucQueryInpatientNo.Focus();
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(ex.Message, 211);
                return -1;
            }
            this.Clear();
            this.txtName.Text = this.patientInfo.Name;
            this.txtSex.Text = this.patientInfo.Sex.ToString();
            this.txtInDate.Text = this.patientInfo.PVisit.InTime.ToShortDateString();
            this.txtDept.Text = this.patientInfo.PVisit.PatientLocation.Dept.Name;
            this.txtType.Text = this.patientInfo.Pact.Name;
            return 1;
        }

        /// <summary>
        /// 清空显示的内容
        /// </summary>
        private void Clear()
        {
            this.txtName.Text = "";
            this.txtSex.Text = "";
            this.txtInDate.Text = "";
            this.txtDept.Text = "";
            this.txtType.Text = "";
            this.diagnosisType.Text = "";
            this.diagnosisDr.Text = "";
            this.diagnosisDate.Text = "";
            this.diagnosisCode.Text = "";
            this.diagnosis.Text = "";
            this.isMain.Checked = false;
            this.happenNo = 0;
            this.iType = null;
            //this.operType = null;
            this.combICDType.Text = "ICD10";
            this.ucDiagnose1.InitICDMedicare("0");
            this.ucDiagnose1.Visible = false;
            this.isUpdate = false;
            this.icdSpell = "";
            this.operType = "";
            this.isMain.Checked = false;
            this.ucDiagnose1.Visible = false;
            this.isDiagSelect = false;
            //this.inpatientNO = "";
            this.isOutMain = false;

        }
        /// <summary>
        /// 保存后清空
        /// </summary>
        private void ClearAfterSave()
        {
            this.diagnosisType.Text = "";
            this.diagnosisDr.Text = "";
            this.diagnosisDate.Text = "";
            this.diagnosisCode.Text = "";
            this.diagnosis.Text = "";
            this.isMain.Checked = false;
            this.isUpdate = false;
            this.icdSpell = "";
            this.iType = null;
            this.operType = "";
            this.isMain.Checked = false;
            this.combICDType.Text = "ICD10";
            this.ucDiagnose1.Visible = false;
            this.isDiagSelect = false;
            //this.inpatientNO = "";
            this.isOutMain = false;
        }
        /// <summary>
        /// 初始化诊断列表
        /// </summary>
        private void InitDiagnoseList()
        {
            this.listView1.Clear();
            this.listView1.Columns.Add("", 0);
            this.listView1.Columns.Add("诊断类型", 90, HorizontalAlignment.Center);
            this.listView1.Columns.Add("诊断名称", 200, HorizontalAlignment.Center);
            this.listView1.Columns.Add("诊断医师", 90, HorizontalAlignment.Center);
            this.listView1.Columns.Add("诊断时间", 90, HorizontalAlignment.Center);
            this.listView1.Columns.Add("状态", 0, HorizontalAlignment.Center);
            this.listView1.Columns.Add("", 0);//happenNo
            this.listView1.Columns.Add("", 0);//OperType
            this.listView1.Columns.Add("", 0);//ICD_code
            this.listView1.Columns.Add("ICD类别", 70, HorizontalAlignment.Center);//ICD类别 'ICD10';'医保'
            this.listView1.Columns.Add("", 0);//MAIN_FLAG 是否主诊断1是0否
            
        }
        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        private void InitCbox()
        {
            //诊断类别
            InitDiganosisType();
            //医生
            InitDr();
            //ICD类别
            InitICDType();
        }
        /// <summary>
        /// 初始化医生列表
        /// </summary>
        private void InitDr()
        {
            ArrayList drList = this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (drList == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("初始化医生列表出错!") + this.managerIntegrate.Err);
                return;
            }
            this.diagnosisDr.AddItems(drList);
        }

        /// <summary>
        /// 初始化ICD类别下拉列表
        /// </summary>
        private void InitICDType()
        {
            ArrayList ls = new ArrayList();
            Neusoft.HISFC.Models.Base.Item icdItem = null;
            #region 写入下拉列表项
       //     icdItem = new Item();
       //     icdItem.ID = "0";
       //     icdItem.Name = "全部";
       //     ls.Add(icdItem);
            icdItem = new Item();
            icdItem.ID = "1";
            icdItem.Name = "ICD10";
            ls.Add(icdItem);
            icdItem = new Item();
            icdItem.ID = "2";
            icdItem.Name = "医保(市)";
            ls.Add(icdItem);
            icdItem = new Item();
            icdItem.ID = "3";
            icdItem.Name = "医保(省)";
            ls.Add(icdItem);
            #endregion
            this.combICDType.AddItems(ls);
            this.combICDType.Text = "ICD10";
        }
        /// <summary>
        /// 初始化诊断类别
        /// </summary>
        private void InitDiganosisType()
        {
            ArrayList DTList = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.SpellList();
            if (DTList == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("初始化诊断类别列表出错!") + this.managerIntegrate.Err);
                return;
            }
            this.diagnosisType.AddItems(DTList);
        }
        /// <summary>
        /// 设置诊断类
        /// </summary>
        /// <returns></returns>
        private int SetDiagnoseInfo()
        {
            this.myDiagnose.DiagInfo.HappenNo = this.happenNo;// HAPPENNO
            this.myDiagnose.DiagInfo.Patient.ID = this.ucQueryInpatientNo.InpatientNo;// 住院流水号
            this.myDiagnose.DiagInfo.DiagType.ID = this.diagnosisType.SelectedItem.ID;// 诊断类型
            //this.myDiagnose.DiagInfo.DiagType.Name = this.diagnosisType.SelectedItem.Name;// 诊断名称
            this.myDiagnose.DiagInfo.ICD10.ID = this.diagnosisCode.Text;// 诊断ICD码
            this.myDiagnose.DiagInfo.ICD10.Name = this.diagnosis.Text;// 诊断名称
            this.myDiagnose.DiagInfo.ICD10.SpellCode = this.icdSpell;//ICD拼音码
            this.myDiagnose.DiagInfo.DiagDate = this.diagnosisDate.Value;// 诊断日期
            this.myDiagnose.DiagInfo.Doctor.ID = this.diagnosisDr.SelectedItem.ID;// 医师代号
            this.myDiagnose.DiagInfo.Doctor.Name = this.diagnosisDr.SelectedItem.Name;// 医师姓名(诊断)
            this.myDiagnose.Pvisit = this.patientInfo.PVisit;// 患者访问类
            //this.myDiagnose.DiagInfo.Patient = this.patientInfo.PVisit;//患者信息类
            this.myDiagnose.DiagInfo.IsMain = this.isMain.Checked;// 是否主诊断 1 主诊断 0 其他诊断
            this.myDiagnose.OperType = "1";// 类别 1 医生站录入诊断  2 病案室录入诊断

            return 1;
        }

        public virtual int valid()
        {
            if (this.patientInfo.PVisit.InTime > this.diagnosisDate.Value)
            {
                MessageBox.Show("诊断日期不能早于住院日期");
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 保存诊断信息
        /// </summary>
        private int Save()
        {
            if (this.valid() < 0)
            {
                return -1;
            }

            if (this.SetDiagnoseInfo() == -1)
            {
                return -1;
            }

            if (this.isUpdate)
            {
                if (!isOutMain)
                {
                    //不能重复输入主诊断
                    if (this.myDiagnose.DiagInfo.IsMain && this.myDiagnose.DiagInfo.DiagType.ID == "1")
                    {
                        //获取出院主诊断
                        ArrayList outDiagnoses = this.diagnoseMgrMc.GetOutMainDiagnose(this.myDiagnose.DiagInfo.Patient.ID);
                        //判断是否是主诊断
                        if (outDiagnoses.Count > 0)
                        {
                            MessageBox.Show(Language.Msg("已经存在出院主诊断!"));
                            return -1;
                        }
                    }
                }
                //更新诊断信息
                if (this.iType == "1")//ICD10
                {
                    if (this.selectedIType == "医保(市)" || this.selectedIType == "医保(省)")
                    {
                        MessageBox.Show(Language.Msg("不能将医保诊断修改为ICD10诊断!"));
                        return -1;
                    }
                    if (this.diagnoseMgr.UpdateDiagnose(this.myDiagnose) == -1)
                    {
                        return -1;
                    }
                }
                else//ICDMEDICARE
                {
                    if (this.selectedIType == "ICD10")
                    {
                        MessageBox.Show(Language.Msg("不能将ICD10诊断修改为医保诊断!"));
                        return -1;
                    }
                    if (this.diagnoseMgrMc.UpdateDiagnoseMedicare(this.myDiagnose) == -1)
                    {
                        return -1;
                    }
                }
            }
            else
            {
                //不能重复输入主诊断
                if (this.myDiagnose.DiagInfo.IsMain && this.myDiagnose.DiagInfo.DiagType.ID == "1")
                {
                    //获取出院主诊断
                    ArrayList outDiagnoses = this.diagnoseMgrMc.GetOutMainDiagnose(this.myDiagnose.DiagInfo.Patient.ID);
                    //判断是否是主诊断
                    if (outDiagnoses.Count > 0)
                    {
                        MessageBox.Show(Language.Msg("已经存在出院主诊断!"));
                        return -1;
                    }
                }
                //插入诊断信息
                if (this.iType == "1")//ICD10
                {
                    if (this.diagnoseMgr.InsertDiagnose(this.myDiagnose) == -1)
                    {
                        return -1;
                    }
                }
                else//ICDMEDICARE
                {
                    if (this.diagnoseMgrMc.InsertDiagnoseMC(this.myDiagnose) == -1)
                    {
                        return -1;
                    }
                }
            }
            this.isUpdate = false;
            this.diagnosisType.Focus();
            return 1;
        }
        /// <summary>
        /// 根据输入的住院号查询诊断信息
        /// </summary>
        private void QueryDiagnose()
        {
            String InPNo = this.ucQueryInpatientNo.InpatientNo;
            // 查询诊断信息
            ArrayList diagnoseList = this.diagnoseMgrMc.QueryDiagnoseBoth(InPNo);
            // 生成诊断列表
            this.FillList(diagnoseList);
        }
        /// <summary>
        /// 生成诊断列表
        /// </summary>
        /// <param name="arr"></param>
        private void FillList(ArrayList arr)
        {
            this.InitDiagnoseList();
            try
            {
                Neusoft.HISFC.Models.HealthRecord.Diagnose diagns = null;
                Neusoft.HISFC.Models.Base.Spell dsType = null;
                Neusoft.HISFC.Models.Base.Employee emp = null;
                String strDsType = "";
                String strDsTypeID = "";
                String strDrName = "";
                String mainFlag = "";
                ArrayList dsTypeList = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.SpellList();
                ArrayList drList = this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
                for (int i = 0; i < arr.Count; i++)
                {
                    diagns = (Neusoft.HISFC.Models.HealthRecord.Diagnose)arr[i];
                    //填入诊断类型中文名称
                    for (int j = 0; j < dsTypeList.Count; j++)
                    {
                        dsType = (Neusoft.HISFC.Models.Base.Spell)dsTypeList[j];
                        if (dsType.ID.ToString() == diagns.DiagInfo.DiagType.ID)
                        {
                            strDsType = dsType.Name;
                            strDsTypeID = dsType.ID;
                            break;
                        }
                    }
                    //填入诊断医生姓名
                    for (int j = 0; j < drList.Count; j++)
                    {
                        emp = (Neusoft.HISFC.Models.Base.Employee)drList[j];
                        if (emp.ID.ToString() == diagns.DiagInfo.Doctor.ID)
                        {
                            strDrName = emp.Name;
                            break;
                        }
                    }
                    //是否主诊断
                    if (diagns.DiagInfo.IsMain)
                    {
                        mainFlag = "1";
                    }
                    else
                    {
                        mainFlag = "0";
                    }
                    ListViewItem item1 = listView1.Items.Add("");
                    item1.SubItems.Add(strDsType);// 诊断类型
                    item1.SubItems.Add(diagns.DiagInfo.ICD10.Name);// 诊断名称
                    item1.SubItems.Add(strDrName);// 诊断医师
                    item1.SubItems.Add(diagns.DiagInfo.DiagDate.ToShortDateString());// 诊断时间
                    item1.SubItems.Add("");// 状态?
                    item1.SubItems.Add(diagns.DiagInfo.HappenNo.ToString());// 发生序号
                    item1.SubItems.Add(diagns.OperType);// 操作类型
                    item1.SubItems.Add(diagns.DiagInfo.ICD10.ID);//ICD代码
                    item1.SubItems.Add(diagns.DiagInfo.User03);//ICD类别 'ICD10';'医保(市)';'医保(省)'
                    item1.SubItems.Add(mainFlag);//MAIN_FLAG 是否主诊断1是0否
                    if (strDsTypeID == "1" && mainFlag == "1" && diagns.DiagInfo.User03 == "医保")
                    {
                        item1.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("生成诊断信息列表出错!" + ex.Message));
                this.listView1.Clear();
                return;
            }
        }
        /// <summary>
        /// 得到选中的ICD信息
        /// </summary>
        /// <returns></returns>
        private int GetICDInfo()
        {
            try
            {
                Neusoft.HISFC.Models.HealthRecord.ICDMedicare item = null;
                if (this.ucDiagnose1.GetItemMc(ref item) == -1)
                {
                    return -1;
                }
                if (item == null) return -1;
                //ICD诊断名称
                this.diagnosisCode.Text = item.ID;
                //ICD诊断编码
                this.diagnosis.Text = item.Name;
                //ICD拼音码
                this.icdSpell = item.SpellCode;
                //ICD类别 1 ICD10； 2 市医保； 3省医保
                this.iType = item.IcdType;

                this.ucDiagnose1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        private void DeleteDiagnose()
        {
            if (this.isUpdate)
            {
                if (MessageBox.Show("您确定删除所选的记录么？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (iType == "1")//ICD10
                {
                    Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes ot = Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC;
                    if (this.operType == "1")//医生站
                    {
                        ot = Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC;
                    }
                    else//病案室
                    {
                        ot = Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS;
                    }
                    if (this.diagnoseMgr.DeleteDiagnoseSingle(this.ucQueryInpatientNo.InpatientNo, this.happenNo, ot) == -1)
                    {
                        MessageBox.Show(Language.Msg("删除失败!"));
                        return;
                    }
                }
                else//ICDMEDICARE
                {
                    if (this.diagnoseMgrMc.DeleteDiagnoseMedicare(this.ucQueryInpatientNo.InpatientNo, this.happenNo) == -1)
                    {
                        MessageBox.Show(Language.Msg("删除失败!"));
                        return;
                    }
                }                
                this.QueryDiagnose();
                MessageBox.Show(Language.Msg("删除成功!"));
                this.ClearAfterSave();
            }
            else
            {
                MessageBox.Show(Language.Msg("请选择一条记录!"));
                return;
            }
            return;
        }
        private int CheckBeforeSave()
        {
            if (this.txtName.Text == "")
            {
                MessageBox.Show(Language.Msg("请填入患者住院号并按回车!"));
                this.ucDiagnose1.Visible = false;
                this.ucQueryInpatientNo.TextBox.Focus();
                return -1;
            }
            if (this.diagnosisType.Text == "")
            {
                MessageBox.Show(Language.Msg("请选择诊断类型!"));
                this.ucDiagnose1.Visible = false;
                this.diagnosisType.Focus();
                return -1;
            }
            if (this.diagnosisDr.Text == "")
            {
                MessageBox.Show(Language.Msg("请选择诊断医师!"));
                this.ucDiagnose1.Visible = false;
                this.diagnosisDr.Focus();
                return -1;
            }
            if (!this.isDiagSelect)
            {
                MessageBox.Show(Language.Msg("请从列表里选择诊断代码!"));
                this.diagnosisCode.Focus();
                return -1;
            }
            if (this.diagnosisCode.Text == "")
            {
                MessageBox.Show(Language.Msg("请选择诊断代码!"));
                this.diagnosisCode.Focus();
                return -1;
            }
            if (this.patientInfo.Pact.ID == "2" && this.combICDType.Tag.ToString() == "3")
            {
                MessageBox.Show(Language.Msg("市保患者不能输入省保诊断!"));
                this.combICDType.Focus();
                return -1;
            }
            if (this.patientInfo.Pact.ID == "3" && this.combICDType.Tag.ToString() == "2")
            {
                MessageBox.Show(Language.Msg("省保患者不能输入市保诊断!"));
                this.combICDType.Focus();
                return -1;
            }
            //if (this.diagnosis.Text == "")
            //{
            //    MessageBox.Show(Language.Msg("请选择诊断名称!"));
            //    return -1;
            //}
            return 1;
        }
        /// <summary>
        /// 初始化科室下拉列表
        /// </summary>
        //private void InitDeptList()
        //{
        //    //科室下拉列表
        //    Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
        //    ArrayList deptList = dept.GetDeptmentAll();
        //    this.deptList.AddItems(deptList);
        //}
        #endregion


        #region 保护

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化,请等待...");
            Application.DoEvents();
            //toolBarService.AddToolButton("删除(F8)", "删除(F8)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //初始化下拉列表
            InitCbox();
            //初始化列表
            InitDiagnoseList();
            //初始化科室列表
            //InitDeptList();
            //初始化ICD
            this.ucDiagnose1.InitICDMedicare("0");
            this.ucDiagnose1.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucDiagnose.MyDelegate(this.ucDiagnose1_SelectItem);
            this.ucDiagnose1.Visible = false;

            return 1;
        }
        /// <summary>
        /// 效性判断
        /// </summary>
        protected virtual int ValidPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            if (patientInfo.PVisit.InState.ID.ToString() != "I")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("患者状态不是病房接诊状态,不能录入住院诊断信息！", 111);
                this.Clear();
                return -1;
            }
            return 1;
        }

        #endregion

        #region 公开
        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// ucQueryInpatientNo回车事件
        /// </summary>
        private void ucQueryInpatientNo_myEvent()
        {
            if (this.FillPatientInfo() == -1)
            {
                return;
            }
            this.QueryDiagnose();
            this.diagnosisType.Focus();
        }
        /// <summary>
        /// 诊断代码获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diagnosisCode_Focused(object sender, EventArgs e)
        {
            //this.ucDiagnose1.Visible = true;
        }
        /// <summary>
        /// 诊断代码失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diagnosisCode_LostFocus(object sender, EventArgs e)
        {
            // this.ucDiagnose1.Visible = false;
        }
        /// <summary>
        /// 诊断内容得到焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diagnosis_GotFocus(object sender, EventArgs e)
        {
            this.diagnosisCode.Focus();
            this.ucDiagnose1.Visible = true;
        }
        /// <summary>
        /// ICD类别变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combICDType_TextChanged(object sender, EventArgs e)
        {
            if (this.combICDType.SelectedItem != null)
            {
                String selectedId = this.combICDType.SelectedItem.ID;
                this.ucDiagnose1.InitICDMedicare(selectedId);
                this.diagnosisCode.Text = "";
                this.diagnosis.Text = "";
                this.ucDiagnose1.Visible = false;
           //     this.ucDiagnose1.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucDiagnose.MyDelegate(this.ucDiagnose1_SelectItem);
            }
        }
        /// <summary>
        /// 点击诊断列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewClick(object sender, EventArgs e)
        {
            this.diagnosisType.Text = this.listView1.SelectedItems[0].SubItems[1].Text;//诊断类型
            this.diagnosis.Text = this.listView1.SelectedItems[0].SubItems[2].Text;//诊断名称
            this.diagnosisDr.Text = this.listView1.SelectedItems[0].SubItems[3].Text;//诊断医生
            this.diagnosisDate.Text = this.listView1.SelectedItems[0].SubItems[4].Text;//诊断时间
            this.operType = this.listView1.SelectedItems[0].SubItems[7].Text;//类别 1 医生站录入诊断  2 病案室录入诊断
            this.selectedIType = this.listView1.SelectedItems[0].SubItems[9].Text;//ICD类别 'ICD10';'医保(市)';'医保(省)'
            //this.combICDType.Text = selectedIType;
            //写入诊断类别
            if (selectedIType == "ICD10")
            {
                this.combICDType.Text = selectedIType;
            }
            else//医保诊断写入患者对应的诊断类别
            {
                this.combICDType.Tag = this.patientInfo.Pact.ID;
            }

            if (this.listView1.SelectedItems[0].SubItems[10].Text == "1")//是否主诊断
            {
                this.isMain.Checked = true;
            }
            else
            {
                this.isMain.Checked = false;
            }
            try
            {
                this.happenNo = int.Parse(this.listView1.SelectedItems[0].SubItems[6].Text);//HappenNo
            }
            catch
            {
                MessageBox.Show(Language.Msg("读取HappenNo出错!"));
                return;
            }
            this.diagnosisCode.Text = this.listView1.SelectedItems[0].SubItems[8].Text;//诊断ICD代码
            this.GetICDInfo();
            this.isDiagSelect = true;
            this.isUpdate = true;
            //点的诊断是否是主诊断{A53A9786-A56A-4f1f-980F-B5E77BB79E4B}
            if (this.listView1.SelectedItems[0].SubItems[10].Text == "1")// && this.listView1.SelectedItems[0].SubItems[1].Tag.ToString()== "1")
            {
                this.isOutMain = true;
            }
            else
            {
                this.isOutMain = false;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            if (isUpdate)
            {
                if (MessageBox.Show("您确定更新所选的记录么？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return -1;
                }
            }
            if (this.CheckBeforeSave() == -1)
            {
                return -1;
            }
            if (this.Save() == -1)
            {
                MessageBox.Show(Language.Msg("保存诊断信息出错!"));
                return -1;
            }
            this.ClearAfterSave();

            MessageBox.Show(Language.Msg("保存成功"));
            isUpdate = false;
            this.QueryDiagnose();
            return base.OnSave(sender, neuObject);
        }
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        { 
            this.toolBarService.AddToolButton("删除", "删除", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);  
            return this.toolBarService;
        }

        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "删除":
                    DeleteDiagnose();
                    break;
                default:
                    break;
            }
        }
       
        /// <summary>
        /// ICD代码选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int ucDiagnose1_SelectItem(Keys key)
        {
            GetICDInfo();
            this.isDiagSelect = true;
            return 0;
        }
        /// <summary>
        /// 清空按钮相应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            this.ClearAfterSave();
        }
        /// <summary>
        /// 诊断代码变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diagnosisCode_TextChanged(object sender, EventArgs e)
        {
            if (this.ucDiagnose1.Visible == false)
            {
                ucDiagnose1.Visible = true;
            }
            this.isDiagSelect = false;
            String str = this.diagnosisCode.Text;
            this.ucDiagnose1.Filter(str);
        }
        /// <summary>
        /// 点击窗体触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDiagnosis_Click(object sender, EventArgs e)
        {
            this.ucDiagnose1.Visible = false;
        }
        /// <summary>
        /// 点击诊断代码输入框触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diagnosisCode_Click(object sender, EventArgs e)
        {
            if (this.ucDiagnose1.Visible)
            {
                this.ucDiagnose1.Visible = false;
            }
            else
            {
                this.ucDiagnose1.Visible = true;
            }
        }
        #endregion

        private void diagnosisType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.diagnosisDr.Focus();
            }
        }

        private void diagnosisDr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.diagnosisDate.Focus();
            }
        }

        private void diagnosisDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.isMain.Focus();
            }
        }

        private void isMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.combICDType.Focus();
            }
        }

        private void combICDType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.diagnosisCode.Focus();
            }
        }

        private void diagnosisCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (ucDiagnose1.Visible)
            {
                if (e.KeyData == Keys.Up)
                {
                   this.ucDiagnose1.PriorRow();
                }
                if (e.KeyData == Keys.Down)
                {
                    this.ucDiagnose1.NextRow();
                }
                if (e.KeyData == Keys.Enter)
                {
                    ucDiagnose1_SelectItem(Keys.Enter);
                }
            }
        
        }

        #region 接口实现
        #endregion

    }

}