using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;
namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    /// <summary>
    /// ucDiagNoseInput<br></br>
    /// [功能描述: 病案诊断录入]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-20]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDiagNoseInput : UserControl
    {
        public ucDiagNoseInput()
        {
            InitializeComponent();
        }

        #region  全局变量

        

        //诊断类别
        private ArrayList diagnoseType = new ArrayList();
        private Neusoft.FrameWork.Public.ObjectHelper diagnoseTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //分期列表
        private ArrayList PeriorList = new ArrayList();
        private Neusoft.FrameWork.Public.ObjectHelper PeriorListHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //分级列表
        private ArrayList LeveList = new ArrayList();
        private Neusoft.FrameWork.Public.ObjectHelper LeveListHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //出院情况 列表
        private ArrayList diagOutStateList = new ArrayList();
        private Neusoft.FrameWork.Public.ObjectHelper diagOutStateListHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //配置文件的路径 
        private string filePath = Application.StartupPath + "\\profile\\ucDiagNoseInput.xml";
        private DataTable dtDiagnose = new DataTable("诊断信息表");
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
        //操作 手术类型 
        private ArrayList OperList = new ArrayList();
        private Neusoft.FrameWork.Public.ObjectHelper OperListHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //诊断信息
        public ArrayList diagList = null;
        //标识是医生站 还是 病案室
        private Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes frmType;

        #region  列的全局变量
        private enum Col
        {
            DiagKind = 0, //诊断类别
            Icd10Code = 1, //ICD10 编码 
            Icd10Name = 2,//ICD10 名称
            OutState = 3, //出院情况
            OperationFlag = 4, //手术
            Disease = 5, //30种疾病
            CLPa = 6,//病理符合
            Perior = 7,//分期
            Level = 8,//分级
            DubDiag = 9,//是否疑诊
            MainDiag = 10,//主诊断
            //{74A9AA46-74B3-49e8-910A-54A998E428AF} 增加拟诊功能
            IsDraftExamine = 17, //是否拟诊
            // {C79B428F-5A7B-4aaf-89EB-946679354446} 增加是否传染病
            //IsCRB = 18
        }

        #endregion
        #endregion

        #region 属性
        //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
        /// <summary>
        /// 病案室还是医生站使用
        /// </summary>
        private bool isCas = true;

        public bool IsCas
        {
            get
            {
                return isCas;
            }
            set
            {
                isCas = value;
            }
        }

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
        /// 病人信息
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }

        /// <summary>
        /// 增加一个空白行 
        /// </summary>
        /// <returns></returns>
        public void AddBlankRow()
        {
            this.fpEnter1_Sheet1.Rows.Add(this.fpEnter1_Sheet1.RowCount, 1);
            this.fpEnter1.Focus();
            this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.RowCount-1, 0);

        }
        /// <summary>
        /// 院内感染次数 
        /// </summary>
        /// <returns></returns>
        public int GetInfectionNum()
        {
            int j = 0;
            if (fpEnter1_Sheet1.RowCount == 0)
            {
                return 0;
            }
            string strName = diagnoseTypeHelper.GetName("4");
            for (int i = 0; i < fpEnter1_Sheet1.RowCount; i++)
            {
                if (fpEnter1_Sheet1.Cells[i, 0].Text == strName)
                {
                    j++;
                }
            }
            return j;
        }
        /// <summary>
        /// 是否有并发症
        /// </summary>
        /// <returns></returns>
        public string GetSyndromeFlag()
        {
            string str = "0";
            if (fpEnter1_Sheet1.RowCount == 0)
            {
                return "0";
            }
            for (int i = 0; i < fpEnter1_Sheet1.RowCount; i++)
            {
                if (fpEnter1_Sheet1.Cells[i, 0].Text == str)
                {
                    str = "1";
                    break;
                }
            }
            return str;
        }
        /// <summary>
        /// 设置活动单元格
        /// </summary>
        public void SetActiveCells()
        {
            try
            {
                this.fpEnter1_Sheet1.SetActiveCell(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 清空原有的数据
        /// </summary>
        /// <returns></returns>
        public int ClearInfo()
        {
            if (this.dtDiagnose != null)
            {
                this.dtDiagnose.Clear();
                LockFpEnter();
            }
            else
            {
                MessageBox.Show("诊断表为null");
            }
            return 1;
        }
        /// <summary>
        /// 获取所有的诊断信息
        /// </summary>
        /// <returns></returns>
        public int GetAllDiagnose(ArrayList list)
        {
            //{691E10E6-4AB5-4252-82AD-4552DB079F2F}
            this.fpEnter1.StopCellEditing();
            foreach (DataRow dr in dtDiagnose.Rows)
            {
                dr.EndEdit();
            }
            DataTable tempdt = dtDiagnose.Copy();
            tempdt.AcceptChanges();
            GetChangeInfo(tempdt, list);
            return 1;
        }
        public int SetReadOnly(bool type)
        {
            if (type)
            {
                this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            }
            else
            {
                this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
            }
            return 0;
        }
        /// <summary>
        /// 校验数据的合法性。
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int ValueState(ArrayList list)
        {
            if (list == null)
            {
                return -2;
            }
            foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.Patient.ID == "" || obj.DiagInfo.Patient.ID == null)
                {
                    MessageBox.Show("诊断信息的住院流水号不能为空");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.DiagInfo.Patient.ID,14))
                {
                    MessageBox.Show("诊断信息的住院流水号过长");
                    return -1;
                }
                if (obj.DiagInfo.HappenNo > 999999999)
                {
                    MessageBox.Show("诊断信息的发生序号过长");
                    return -1;
                }
                if (obj.DiagInfo.DiagType.ID == "" || obj.DiagInfo.DiagType.ID == null)
                {
                    MessageBox.Show("诊断信息的诊断类型不能为空");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.DiagInfo.DiagType.ID, 2))
                {
                    MessageBox.Show("诊断信息的诊断类型编码过长");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.LevelCode, 20))
                {
                    MessageBox.Show("诊断信息的诊断级别编码过长");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.PeriorCode,20))
                {
                    MessageBox.Show("诊断信息的诊断分期编码过长");
                    return -1;
                }
                //{74A9AA46-74B3-49e8-910A-54A998E428AF} 增加拟诊功能
                if (obj.User01 == "0")
                {
                    if (obj.DiagInfo.ICD10.ID.Trim() == "" || obj.DiagInfo.ICD10.ID.Trim() == null)
                    {
                        MessageBox.Show("诊断信息的ICD诊断不能为空");
                        return -1;
                    }
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.DiagInfo.ICD10.ID, 50))
                    {
                        MessageBox.Show("诊断信息的诊断编码过长");
                        return -1;
                    }
                }
                if (obj.DiagInfo.ICD10.Name == "" || obj.DiagInfo.ICD10.Name == null)
                {
                    MessageBox.Show("诊断信息的ICD诊断不能为空");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.DiagInfo.ICD10.Name, 150))
                {
                    MessageBox.Show("诊断信息的诊断名称过长");
                    return -1;
                }
                if (obj.DiagInfo.Doctor.ID == "" || obj.DiagInfo.Doctor.ID == null)
                {
                    MessageBox.Show("诊断信息的诊断医生编码不能为空");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.DiagInfo.Doctor.ID, 6))
                {
                    MessageBox.Show("诊断信息的医生编码过长");
                    return -1;
                }
                if (obj.DiagInfo.Doctor.Name == "" || obj.DiagInfo.Doctor.Name == null)
                {
                    MessageBox.Show("诊断信息的诊断医生不能为空");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.DiagInfo.Doctor.Name,10))
                {
                    MessageBox.Show("诊断信息的医生名称过长");
                    return -1;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(obj.DiagOutState, 20))
                {
                    MessageBox.Show("诊断信息的治疗情况编码过长");
                    return -1;
                }
                if (obj.OperType.Length > 1)
                {
                    MessageBox.Show("诊断信息的类别编码过长");
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 保存对表做的所有修改
        /// </summary>
        /// <returns></returns>
        public int fpEnterSaveChanges()
        {
            try
            {
                this.dtDiagnose.AcceptChanges();
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 返回当前行数
        /// </summary>
        /// <returns></returns>
        public int GetfpSpreadRowCount()
        {
            return fpEnter1_Sheet1.Rows.Count;
        }
        /// <summary>
        /// 如果reset 为真 则清空现有数据 并保存更改  为假 只是保存当前更改
        /// creator:zhangjunyi@Neusoft.com
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
        public bool Reset(bool reset)
        {
            if (reset)
            {
                //清空数据 保存更改 
                if (dtDiagnose != null)
                {
                    dtDiagnose.Clear();
                    dtDiagnose.AcceptChanges();
                }
            }
            else
            {
                //保存更改
                dtDiagnose.AcceptChanges();
            }
            LockFpEnter();
            return true;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitInfo()
        {
            try
            {
                #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}
                if (!this.DesignMode)
                {
                    this.ucDiagnose1.IsUseDeptICD = this.isUseDeptICD;
                    this.ucDiagnose1.Init();
                }
                #endregion
                //初始化表
                InitDateTable();
                //设置下拉列表
                this.initList();
                //InputMap im;
                //im = fpEnter1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                //im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

                //im = fpEnter1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                //im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

                //im = fpEnter1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
                //im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
 
                fpEnter1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 根据输入的住院患者信息 和type参数查询诊断信息
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Type"></param>
        /// <returns>-1 出错 0 传入的病人信息为空,不作处理，1 不允许有病案，2病案已经封存，不允许医生修改和查阅 3 查询有数据 4查询没有数据  </returns>
        public int LoadInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes Type)
        {
            try
            {
                frmType = Type;
                if (patientInfo == null)
                {
                    //没有该病人的信息
                    return 0;
                }

                patient = patientInfo;
                if (patientInfo.CaseState == "0")
                {
                    //不允许有病案
                    return 1;
                }
                //定义业务层的类
                Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diag = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
                diagList = new ArrayList();

                if (Type == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC) // 医生站录入病历
                {
                    #region  医生站录入病历

                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    // 医生站录入病例
                    if (patientInfo.CaseState == "1" || patientInfo.CaseState == "2" || patientInfo.CaseState == "5")
                    {
                        //从医生站录入的信息中查询
                        diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC);
                    }
                    else
                    {
                        // 病案已经封存已经不允许医生修改和查阅
                        return 2;
                    }

                    #endregion
                }
                else if (Type == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)//病案室录入病历
                {
                    #region 病案室录入病历
                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    if (patientInfo.CaseState == "1" || patientInfo.CaseState == "2" || patientInfo.CaseState == "5")
                    {
                        //医生站已经录入病案
                        diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC);
                    }
                    else if (patientInfo.CaseState == "3")
                    {
                        //病案室已经录入病案
                        diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
                    }
                    else if (patientInfo.CaseState == "4")
                    {
                        //病案已经封存 不允许修改。
                        diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
                        this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
                    }

                    #endregion
                }
                else
                {
                    //没有传入参数 不作任何处理
                }

                if (diagList != null)
                {
                    //查询有数据
                    AddInfoToTable(diagList);
                    return 3;
                }
                else
                {//查询没有数据
                    return 4;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
        /// <summary>
        /// 根据输入的住院患者信息 和type参数查询诊断信息
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Type"></param>
        /// <returns>-1 出错 0 传入的病人信息为空,不作处理，1 不允许有病案，2病案已经封存，不允许医生修改和查阅 3 查询有数据 4查询没有数据  </returns>
        public int LoadInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes Type, string diagInputType)
        {

            try
            {
                frmType = Type;
                if (patientInfo == null)
                {
                    //没有该病人的信息
                    return 0;
                }

                patient = patientInfo;
                if (patientInfo.CaseState == "0")
                {
                    //不允许有病案
                    return 1;
                }
                //定义业务层的类
                Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diag = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
                diagList = new ArrayList();

                if (Type == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC) // 医生站录入病历
                {
                    if (diagInputType == "cas")
                    {
                        #region  医生站录入病历

                        //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                        // 医生站录入病例
                        if (patientInfo.CaseState == "1" || patientInfo.CaseState == "2")
                        {
                            //从医生站录入的信息中查询
                            diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC);
                        }
                        else
                        {
                            // 病案已经封存已经不允许医生修改和查阅
                            return 2;
                        }

                        #endregion
                    }
                    else
                    {
                        diagList = diag.QueryDiagnoseNoOps(patientInfo.ID);

                    }
                }
                else if (Type == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)//病案室录入病历
                {
                    #region 病案室录入病历
                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    if (patientInfo.CaseState == "1" || patientInfo.CaseState == "2")
                    {
                        //医生站已经录入病案
                        diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC);
                    }
                    else if (patientInfo.CaseState == "3")
                    {
                        //病案室已经录入病案
                        diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
                    }
                    else if (patientInfo.CaseState == "4")
                    {
                        //病案已经封存 不允许修改。
                        diagList = diag.QueryCaseDiagnose(patientInfo.ID, "%", Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS);
                        this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
                    }

                    #endregion
                }
                else
                {
                    //没有传入参数 不作任何处理
                }

                if (diagList != null)
                {
                    //查询有数据
                    AddInfoToTable(diagList);

                    //for (int i = 0; i < diagList.Count; i++)
                    //{
                    //    Neusoft.HISFC.Models.HealthRecord.Diagnose diagInfo = diagList[i] as Neusoft.HISFC.Models.HealthRecord.Diagnose;
                    //    if (diagInfo.IsDraftExamine == "1") //判断是否拟诊
                    //    {
                    //        this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Code].Locked = true;
                    //        this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Name].Locked = false;

                    //    }
                    //    else
                    //    {
                    //        this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Code].Locked = false;
                    //        this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Name].Locked = true;

                    //    }
                    //}
                    this.dtDiagnose.AcceptChanges();

                    return 3;
                }
                else
                {//查询没有数据
                    return 4;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        //		/// <summary>
        //		/// 加载ICD列表
        //		/// </summary>
        //		/// <param name="al"></param>
        //		/// <returns></returns>
        //		public int InitICDList(ArrayList al)
        //		{
        //			if(al == null)
        //			{
        //				return -1;
        //			}
        ////			Neusoft.HISFC.BizLogic.HealthRecord.ICD ICDdml = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();
        ////			//获取诊断类型信息
        ////			ArrayList al=ICDdml.Query(Neusoft.HISFC.BizLogic.HealthRecord.ICDTypes.ICD10,Neusoft.HISFC.BizLogic.HealthRecord.QueryTypes.Valid);
        //			this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1,1,al);
        //			this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1,2,al);
        //			return 0;
        //		}
        public bool GetList(string strType, ArrayList list)
        {
            try
            {
                this.fpEnter1.StopCellEditing();
                //this.fpEnter1.EditModePermanent = false;
                //this.fpEnter1.EditModeReplace = false;
                foreach (DataRow dr in this.dtDiagnose.Rows)
                {
                    dr.EndEdit();
                }
                switch (strType)
                {
                    case "A":
                        //增加的数据
                        DataTable AddTable = this.dtDiagnose.GetChanges(DataRowState.Added);
                        GetChangeInfo(AddTable, list);
                        break;
                    case "M":
                        DataTable ModTable = this.dtDiagnose.GetChanges(DataRowState.Modified);
                        GetChangeInfo(ModTable, list);
                        break;
                    case "D":
                        DataTable DelTable = this.dtDiagnose.GetChanges(DataRowState.Deleted);
                        if (DelTable != null)
                        {
                            DelTable.RejectChanges();
                        }
                        GetChangeInfo(DelTable, list);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除当前行 
        /// </summary>
        /// <returns></returns>
        public int DeleteActiveRow()
        {
            this.fpEnter1.SetAllListBoxUnvisible();
            this.fpEnter1.EditModePermanent = false;
            this.fpEnter1.EditModeReplace = false;
            if (fpEnter1_Sheet1.Rows.Count > 0)
            {
                this.fpEnter1_Sheet1.Rows.Remove(fpEnter1_Sheet1.ActiveRowIndex, 1);

                //{3C71EDBD-8179-41e6-98DB-B70CC6E01D61}
                if (this.ucDiagnose1.Visible) 
                {
                    this.ucDiagnose1.Visible = false;
                }
            }
            if (fpEnter1_Sheet1.Rows.Count == 0)
            {
                this.fpEnter1.SetAllListBoxUnvisible();
                #region {3C71EDBD-8179-41e6-98DB-B70CC6E01D61}
                this.ucDiagnose1.Visible = false;
                #endregion
            } 
            this.fpEnter1.EditModePermanent = true;
            this.fpEnter1.EditModeReplace = true;
            return 1;
        }
        /// <summary>
        /// 删除空白的行
        /// </summary>
        /// <returns></returns>
        public int deleteRow()
        {
            this.fpEnter1.SetAllListBoxUnvisible();
            this.fpEnter1.EditModePermanent = false;
            this.fpEnter1.EditModeReplace = false;
            if (fpEnter1_Sheet1.Rows.Count == 1)
            {
                //第一行编码为空 
                if (fpEnter1_Sheet1.Cells[0, 1].Text == "")
                {
                    fpEnter1_Sheet1.Rows.Remove(0, 1);
                }
            }
            #region {3C71EDBD-8179-41e6-98DB-B70CC6E01D61}
            if (fpEnter1_Sheet1.Rows.Count == 0)
            {
                this.fpEnter1.SetAllListBoxUnvisible();
                
                this.ucDiagnose1.Visible = false;
            }
            #endregion
            this.fpEnter1.EditModePermanent = true;
            this.fpEnter1.EditModeReplace = true;
            return 1;
        }
        /// <summary>
        /// 获取修改过的信息
        /// </summary>
        /// <returns></returns>
        private bool GetChangeInfo(DataTable tempTable, ArrayList list)
        {
            if (tempTable == null)
            {
                return true;
            }
            try
            {
                Neusoft.HISFC.Models.HealthRecord.Diagnose info = null;
                foreach (DataRow row in tempTable.Rows)
                {
                    if (string.IsNullOrEmpty(row["诊断类别"].ToString().Trim()) && string.IsNullOrEmpty(row["ICD10"].ToString().Trim()))
                    {
                        continue;
                    }
                    info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    info.DiagInfo.Patient.ID = this.patient.ID;
                    //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                    info.DiagInfo.Patient.PID.CardNO = this.patient.PID.CardNO;
                    //诊断类别
                    info.DiagInfo.DiagType.ID = diagnoseTypeHelper.GetID(row["诊断类别"].ToString());
                    //出院诊断的明细类别
                    //					info.MainFlag = diagnoseTypeHelper.GetID(row["诊断类别"].ToString());
                    info.DiagInfo.ICD10.ID = row["ICD10"].ToString();//2
                    if (info.DiagInfo.DiagType.ID == "1") //将主诊断设置成 
                    {
                        info.DiagInfo.IsMain = true;
                    }
                    else
                    {
                        info.DiagInfo.IsMain = false;
                    }
                    info.DiagInfo.ICD10.Name = row["诊断名称"].ToString();
                    if (row["出院情况"] != DBNull.Value)
                    {
                        info.DiagOutState = diagOutStateListHelper.GetID(row["出院情况"].ToString()); //3
                    }
                    if (row["有无手术"] != DBNull.Value)
                    {
                        info.OperationFlag = OperListHelper.GetID(row["有无手术"].ToString());
                    }

                    if (ConvertBool(row["30种疾病"]))//5
                    {
                        info.Is30Disease = "1";
                    }
                    else
                    {
                        info.Is30Disease = "0";
                    }
                    if (ConvertBool(row["病理符合"]))//6
                    {
                        info.CLPA = "1";
                    }
                    else
                    {
                        info.CLPA = "0";
                    }
                    if (row["分级"] != DBNull.Value)
                    {
                        info.LevelCode = LeveListHelper.GetID(row["分级"].ToString()); //7
                    }
                    if (row["分期"] != DBNull.Value)
                    {
                        info.PeriorCode = PeriorListHelper.GetID(row["分期"].ToString());//8
                    }
                    if (ConvertBool(row["是否疑诊"]))//9
                    {
                        info.DubDiagFlag = "1";
                    }
                    else
                    {
                        info.DubDiagFlag = "0";
                    }
                    info.DiagInfo.HappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(row["序号"]);//10
                    info.DiagInfo.DiagDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["诊断日期"]);//11
                    //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                    if (info.DiagInfo.DiagDate == System.DateTime.MinValue)
                    {
                        info.DiagInfo.DiagDate = (new FrameWork.Management.DataBaseManger()).GetDateTimeFromSysDateTime();
                    }
                    info.Pvisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["入院日期"]);//12
                    info.Pvisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row["出院日期"]);//13
                    if (frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
                    {
                        info.OperType = "1";
                    }
                    else if (frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
                    {
                        info.OperType = "2";
                    }
                    else
                    {
                    }
                    Neusoft.HISFC.BizLogic.HealthRecord.Diagnose dia = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
                    if (row["诊断医师代码"] != DBNull.Value)
                    {
                        info.DiagInfo.Doctor.ID = row["诊断医师代码"].ToString();
                    }
                    else
                    {
                        info.DiagInfo.Doctor.ID = dia.Operator.ID;
                        info.DiagInfo.Doctor.Name = dia.Operator.Name;
                    }
                    if (row["诊断医师"] != DBNull.Value)
                    {
                        info.DiagInfo.Doctor.Name = row["诊断医师"].ToString();
                    }
                    else
                    {
                        info.DiagInfo.Doctor.ID = dia.Operator.ID;
                        info.DiagInfo.Doctor.Name = dia.Operator.Name;
                    }
                    //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                    info.DiagInfo.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                    info.DiagInfo.IsValid = true;
                    //{74A9AA46-74B3-49e8-910A-54A998E428AF} 增加拟诊功能
                    if (ConvertBool(row["是否拟诊"]))
                    {
                        info.User01 = "1";
                    }
                    else
                    {
                        info.User01 = "0";
                    }

                    // {C79B428F-5A7B-4aaf-89EB-946679354446} 增加是否传染病
                    //if (ConvertBool(row["是否传染病"]))
                    //{
                    //    info.Memo = "1";
                    //    info.DiagInfo.Memo = "1";
                    //}
                    //else
                    //{
                    //    info.Memo = "0";
                    //    info.DiagInfo.Memo = "0";
                    //}

                    list.Add(info);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        
        /// <summary>
        /// 将实体转化成BOOL类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ConvertBool(object obj)
        {
            if (obj == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(obj);
        }
        /// <summary>
        /// 将保存完的数据回写到表中
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int fpEnterSaveChanges(ArrayList list)
        {
            AddInfoToTable(list);
            dtDiagnose.AcceptChanges();
            this.LockFpEnter();
            return 0;
        }
        /// <summary>
        /// 查询诊断信息并且填充的表中
        /// </summary>
        private void AddInfoToTable(ArrayList alReturn)
        {
            bool Result = false;
            if ((this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC && this.patient.CaseState == "2") || (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS && this.patient.CaseState == "3"))
            {
                Result = true;
            }
            //清空以前的数据
            if (this.dtDiagnose != null)
            {
                this.dtDiagnose.Clear();
                this.dtDiagnose.AcceptChanges();
            }
            //循环插入信息
            foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in alReturn)
            {
                //这里只存除了门诊诊断和入院诊断之外的诊断
                //				if(obj.DiagInfo.DiagType.ID != "1"&&obj.DiagInfo.DiagType.ID != "14")
                //				{
                DataRow row = dtDiagnose.NewRow();

                SetRow(obj, row, Result);
                dtDiagnose.Rows.Add(row);
                //				}

            }
            //			if(System.IO.File.Exists(filePath))
            //			{
            //				Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpEnter1_Sheet1,filePath);
            //			}
            if ((this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC && this.patient.CaseState == "2") || (this.frmType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS && this.patient.CaseState == "3"))
            {
                //清空表的标志位
                dtDiagnose.AcceptChanges();
            }
            LockFpEnter();
        }

        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="info"></param>
        private void SetRow(Neusoft.HISFC.Models.HealthRecord.Diagnose info, DataRow row, bool tempBool)
        {
            row["诊断类别"] = diagnoseTypeHelper.GetName(info.DiagInfo.DiagType.ID); //0
            row["诊断名称"] = info.DiagInfo.ICD10.Name;//1
            row["ICD10"] = info.DiagInfo.ICD10.ID;//2
            row["出院情况"] = diagOutStateListHelper.GetName(info.DiagOutState); //3
            row["有无手术"] = OperListHelper.GetName(info.OperationFlag);
            if (info.Is30Disease == "0")//5
            {
                row["30种疾病"] = false;
            }
            else if (info.Is30Disease == "1")
            {
                row["30种疾病"] = true;
            }

            if (info.CLPA == "0")//6
            {
                row["病理符合"] = false;
            }
            else if (info.CLPA == "1")
            {
                row["病理符合"] = true;
            }
            row["分级"] = LeveListHelper.GetName(info.LevelCode); //7
            row["分期"] = PeriorListHelper.GetName(info.PeriorCode);//8


            if (info.DubDiagFlag == "0") //9
            {
                row["是否疑诊"] = false;
            }
            else if (info.DubDiagFlag == "1")
            {
                row["是否疑诊"] = true;
            }
            //主诊断
            row["主诊断"] = info.DiagInfo.IsMain;
            row["序号"] = info.DiagInfo.HappenNo;//10
            if (info.DiagInfo.DiagDate == System.DateTime.MinValue)
            {
                row["诊断日期"] = System.DateTime.Now;
            }
            else
            {
                row["诊断日期"] = info.DiagInfo.DiagDate;//11
            }
            row["入院日期"] = patient.PVisit.InTime;//12
            row["出院日期"] = patient.PVisit.OutTime;//13
            row["诊断医师代码"] = info.DiagInfo.Doctor.ID;
            row["诊断医师"] = info.DiagInfo.Doctor.Name;
            //{74A9AA46-74B3-49e8-910A-54A998E428AF} 增加拟诊功能
            if (string.IsNullOrEmpty(info.DiagInfo.ICD10.ID.Trim()) && !string.IsNullOrEmpty(info.DiagInfo.ICD10.Name.Trim()))
            {
                row["是否拟诊"] = true;
            }
            else
            {
                row["是否拟诊"] = false;
            }
            //设置fpSpread1 的属性

            // {C79B428F-5A7B-4aaf-89EB-946679354446} 增加是否传染病
            //if (info.Memo == "1" || info.DiagInfo.Memo == "1")
            //{
            //    row["是否传染病"] = true;
            //}
            //else
            //{
            //    row["是否传染病"] = false;
            //}

        }
        private void ucDiagNoseInput_Load(object sender, System.EventArgs e)
        {
            InputMap im;
            im = fpEnter1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpEnter1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpEnter1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //定义响应按键事件
            fpEnter1.KeyEnter += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.keyDown(fpEnter1_KeyEnter);
            fpEnter1.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(fpEnter1_SetItem);
            fpEnter1.KeyUp += new KeyEventHandler(fpEnter1_KeyUp);
            fpEnter1.ShowListWhenOfFocus = true;
            #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}
            //if (!this.DesignMode)
            //{
            //    this.ucDiagnose1.Init();
            //}
            #endregion
            this.ucDiagnose1.SelectItem +=new Common.Controls.ucDiagnose.MyDelegate(ucDiagnose1_SelectItem);
            this.ucDiagnose1.Visible = false;
        }
        private void InitDateTable()
        {
            try
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                Type floatType = typeof(System.Single);

                dtDiagnose.Columns.AddRange(new DataColumn[]{
														   new DataColumn("诊断类别", strType),	//0
														   new DataColumn("ICD10", strType),	 //1
														   new DataColumn("诊断名称", strType),//2
														   new DataColumn("出院情况", strType),//3
														   new DataColumn("有无手术", strType),//4
														   new DataColumn("30种疾病", boolType),//5
														   new DataColumn("病理符合", boolType),//6
														   new DataColumn("分期", strType), //7
														   new DataColumn("分级", strType),//8
														   new DataColumn("是否疑诊", boolType),//9
														   new DataColumn("主诊断", boolType),//9
														   new DataColumn("序号", intType),//10
														   new DataColumn("诊断日期", dtType),//11
														   new DataColumn("入院日期", dtType),//12
														   new DataColumn("出院日期", dtType),//13
														   new DataColumn("诊断医师代码", strType),//14 
														   new DataColumn("诊断医师", strType),//15
                                                           //{74A9AA46-74B3-49e8-910A-54A998E428AF} 增加拟诊功能
                                                           new DataColumn("是否拟诊", boolType)});//16
                // {C79B428F-5A7B-4aaf-89EB-946679354446} 增加是否传染病
                //new DataColumn("是否传染病", boolType)}); // 18

                //绑定数据源
                this.fpEnter1_Sheet1.DataSource = dtDiagnose;
                //设置fpSpread1 的属性
                //				if(System.IO.File.Exists(filePath))
                //				{
                //					Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpEnter1_Sheet1,filePath);
                //				}
                //				else
                //				{
                //					Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpEnter1_Sheet1,filePath);
                //				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 设置列下拉列表
        /// </summary>
        private void initList()
        {
            try
            {
                Neusoft.HISFC.BizLogic.HealthRecord.Diagnose da = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
                Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();
                this.fpEnter1.SelectNone = true;
                //获取出院诊断类别诊断
                //				diagnoseType = da.GetDiagnoseList();
                diagnoseType = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.SpellList();
                diagnoseTypeHelper.ArrayObject = diagnoseType;
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 0, diagnoseType);

                //分期列表
                PeriorList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DIAGPERIOD);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 7, PeriorList);
                PeriorListHelper.ArrayObject = PeriorList;
                //手术操作类型
                OperList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.OPERATIONTYPE);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 4, OperList);
                OperListHelper.ArrayObject = OperList;

                //分级列表 
                LeveList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DIAGLEVEL);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 8, LeveList);
                LeveListHelper.ArrayObject = LeveList;

                //出院情况列表
                diagOutStateList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ZG);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 3, diagOutStateList);
                diagOutStateListHelper.ArrayObject = diagOutStateList;
                this.fpEnter1.SetSpecalCol((int)Col.Icd10Code);

                this.fpEnter1.SetWidthAndHeight(200, 200);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 处理回车操作 ，并且取出数据
        /// </summary>
        /// <returns></returns>
        private int ProcessDept()
        {
            int CurrentRow = fpEnter1_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.DiagKind) //诊断类型 
            {
                //获取选中的信息
                Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.DiagKind);
                Neusoft.FrameWork.Models.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //诊断类别
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Icd10Code);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.OutState)
            {
                Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.OutState);
                //获取选中的信息
                Neusoft.FrameWork.Models.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                // 出院信息
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.OperationFlag);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.OperationFlag)
            {
                Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.OperationFlag);
                //获取选中的信息
                Neusoft.FrameWork.Models.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                // 出院信息
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Disease);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Perior)
            {
                Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.Perior);
                //获取选中的信息
                Neusoft.FrameWork.Models.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //分期
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Level);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Level)
            {
                Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)Col.Level);
                //获取选中的信息
                Neusoft.FrameWork.Models.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //分期
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.DubDiag);
                return 0;
            }
            //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Icd10Code)
            {
                #region {9FFEAAA8-2387-4b90-B3BD-D2FBFDC48E95}
                //if (!this.isCas)
                //{
                    #region {9F550E5B-669F-4856-BAED-94F69B729CAE}
                    //增加回车选择诊断信息
                    this.GetInfo();
                    #endregion
                    if (this.isCas)
                    {
                        fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.OutState);
                    }
                    else
                    {
                        fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.IsDraftExamine);
                    }
                    //fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.IsDraftExamine);
                    return 0;
                    //}
                #endregion
                }

            return 0;
        }
        /// <summary>
        /// 按键响应处理
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int fpEnter1_KeyEnter(Keys key)
        {
            if (key == Keys.Enter)
            {
                //				MessageBox.Show("Enter,可以自己添加处理事件，比如跳到下一cell");
                //回车
                if (this.fpEnter1.ContainsFocus)
                {
                    int i = this.fpEnter1_Sheet1.ActiveColumnIndex;
                    //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                    if (i == (int)Col.DiagKind || i == (int)Col.OutState || i == (int)Col.OperationFlag || i == (int)Col.Perior || i == (int)Col.Level || i == (int)Col.Icd10Code)
                    {
                        ProcessDept();
                    }
                    if (i == (int)Col.OutState || i == (int)Col.IsDraftExamine)
                    {
                        if (fpEnter1_Sheet1.ActiveRowIndex < fpEnter1_Sheet1.Rows.Count - 1)
                        {
                            fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex + 1, 0);
                        }
                        else
                        {
                            if (this.Tag != null)
                            {
                                this.AddBlankRow(); //增加一个空白行 
                            }
                            else
                            {
                                //增加一行
                                this.AddRow();
                            }
                        }
                    }
                    else
                    {
                        if (i < (int)Col.IsDraftExamine)
                        {
                            fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, i + 1);
                        }
                    }
                }
            }
            else if (key == Keys.Up)
            {
                //				MessageBox.Show("Up,可以自己添加处理事件，比如无下拉列表时，跳到下列，显示下拉控件时，在下拉控件上下移动");
            }
            else if (key == Keys.Down)
            {
                //				MessageBox.Show("Down，可以自己添加处理事件，比如无下拉列表时，跳到上列，显示下拉控件时，在下拉控件上下移动");
            }
            else if (key == Keys.Escape)
            {
                //				MessageBox.Show("Escape,取消列表可见");
            }
            else if (key == Keys.Add)
            {
                if (fpEnter1_Sheet1.Rows.Count == 0 || fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.DubDiag)
                {
                    AddRow();
                }
            }
            return 0;
        }
        //添加一行项目
        public int AddRow()
        {
            try
            {
                if (fpEnter1_Sheet1.Rows.Count < 1)
                {
                    //增加一行空值
                    DataRow row = dtDiagnose.NewRow();
                    row["序号"] = 1;
                    dtDiagnose.Rows.Add(row);


                    #region donggq---{ACE7750F-F9C2-4fae-90C1-4F3024C248DA}

                    this.fpEnter1.Focus();
                    this.fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.Rows.Count, (int)Col.DiagKind);
                    this.fpEnter1.ActiveSheet.ActiveCell.Text = "主要诊断";

                    this.fpEnter1.Focus();
                    this.fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.Rows.Count, (int)Col.Icd10Code);
                    this.fpEnter1.ActiveSheet.ActiveCell.Text = "";
                    this.fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.Rows.Count, (int)Col.Icd10Code);

                    #endregion

                }
                else
                {
                    //增加一行
                    int j = fpEnter1_Sheet1.Rows.Count;
                    this.fpEnter1_Sheet1.Rows.Add(j, 1);
                    //for (int i = 0; i < fpEnter1_Sheet1.Columns.Count; i++)
                    //{
                    //    fpEnter1_Sheet1.Cells[j, i].Value = fpEnter1_Sheet1.Cells[j - 1, i].Value;
                    //}
                    
                    fpEnter1.Focus();
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.Rows.Count, 0);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        /// <summary>
        /// 设置网格的宽度 等属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            Common.Controls.ucSetColumn uc = new Common.Controls.ucSetColumn();
            uc.FilePath = this.filePath;
            //uc.GoDisplay += new Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplay);
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }
        /// <summary>
        /// 调整fpSpread1_Sheet1的宽度等 保存后触发的事件
        /// </summary>
        private void uc_GoDisplay()
        {
            //			LoadInfo(inpatientNo,operType); //重新加载数据

        }

        /// <summary>
        /// 删除当前记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            if (this.fpEnter1_Sheet1.Rows.Count > 0)
            {
                //删除当前行
                this.fpEnter1_Sheet1.Rows.Remove(this.fpEnter1_Sheet1.ActiveRowIndex, 1);
            }
            for (int i = 0; i < this.fpEnter1_Sheet1.Columns.Count; i++)
            {
                try
                {
                    this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, i).Visible = false;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 限定格的宽度很可见性 
        /// </summary>
        private void LockFpEnter()
        {
            this.fpEnter1_Sheet1.Columns[0].Width = 59; //诊断类别
            this.fpEnter1_Sheet1.Columns[1].Width = 124;//ICD10
            this.fpEnter1_Sheet1.Columns[2].Locked = true;
            this.fpEnter1_Sheet1.Columns[2].Width = 150;//诊断名称
            this.fpEnter1_Sheet1.Columns[3].Width = 65; //出院情况
            this.fpEnter1_Sheet1.Columns[4].Width = 40; //有无手术
            this.fpEnter1_Sheet1.Columns[5].Width = 40; //30种疾病
            this.fpEnter1_Sheet1.Columns[6].Width = 40; //病理符合
            this.fpEnter1_Sheet1.Columns[7].Width = 51; //分期
            this.fpEnter1_Sheet1.Columns[8].Width = 50; //分级
            this.fpEnter1_Sheet1.Columns[9].Width = 40; //是否疑诊
            this.fpEnter1_Sheet1.Columns[10].Width = 40; //主诊断
            this.fpEnter1_Sheet1.Columns[10].Visible = false; //主诊断
            this.fpEnter1_Sheet1.Columns[11].Visible = false; //序号
            this.fpEnter1_Sheet1.Columns[12].Visible = false; //诊断日期
            this.fpEnter1_Sheet1.Columns[13].Visible = false; //入院日期
            this.fpEnter1_Sheet1.Columns[14].Visible = false; //出院日期
            this.fpEnter1_Sheet1.Columns[15].Visible = false; //诊断医师代码
            this.fpEnter1_Sheet1.Columns[16].Visible = false; //诊断医师

            //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
            if (!isCas) //不是病案室就是医生站用
            {

                fpEnter1_Sheet1.Columns[(int)Col.OutState].Visible = false;//出院情况
                fpEnter1_Sheet1.Columns[(int)Col.OperationFlag].Visible = false;//有无手术
                fpEnter1_Sheet1.Columns[(int)Col.Disease].Visible = false;//30种疾病
                fpEnter1_Sheet1.Columns[(int)Col.CLPa].Visible = false;//病理符合
                fpEnter1_Sheet1.Columns[(int)Col.Perior].Visible = false;//分期
                fpEnter1_Sheet1.Columns[(int)Col.Level].Visible = false;//分级
                fpEnter1_Sheet1.Columns[(int)Col.DubDiag].Visible = false;//是否疑诊
                //fpEnter1_Sheet1.Columns[(int)Col.MainDiag].Visible = true;//主诊断
            }
            else
            {
                fpEnter1_Sheet1.Columns[(int)Col.OutState].Visible = true;//出院情况
                fpEnter1_Sheet1.Columns[(int)Col.OperationFlag].Visible = true;//有无手术
                fpEnter1_Sheet1.Columns[(int)Col.Disease].Visible = true;//30种疾病
                fpEnter1_Sheet1.Columns[(int)Col.CLPa].Visible = true;//病理符合
                fpEnter1_Sheet1.Columns[(int)Col.Perior].Visible = true;//分期
                fpEnter1_Sheet1.Columns[(int)Col.Level].Visible = true;//分级
                fpEnter1_Sheet1.Columns[(int)Col.DubDiag].Visible = true;//是否疑诊
                //fpEnter1_Sheet1.Columns[(int)Col.MainDiag].Visible = false;//主诊断

            }

            //{74A9AA46-74B3-49e8-910A-54A998E428AF} 增加拟诊功能
            fpEnter1_Sheet1.Columns[(int)Col.IsDraftExamine].Visible = true;//是否拟诊
            for (int i = 0; i < fpEnter1_Sheet1.Rows.Count; i++)
            {
                if (this.fpEnter1_Sheet1.Cells[i, (int)Col.IsDraftExamine].Value == null || this.fpEnter1_Sheet1.Cells[i, (int)Col.IsDraftExamine].Value.ToString() == "False")
                {
                    this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Code].Locked = false;
                    this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Name].Locked = true;
                }
                else
                {
                    this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Code].Locked = true;
                    this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Name].Locked = false;
                    this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Code].Text = " ";
                }
            }

        }
        private int fpEnter1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
        {
            this.ProcessDept();
            return 0;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        { 
            if (keyData == Keys.NumPad1)
            {
                //r如果当前列是checkbox类型的 点 数字1 选中状态
                int i = fpEnter1_Sheet1.ActiveColumnIndex;
                if (i == (int)Col.Disease || i == (int)Col.CLPa || i == (int)Col.DubDiag || i == (int)Col.MainDiag)
                {
                    //统计标志取反
                    if (fpEnter1_Sheet1.Cells[fpEnter1_Sheet1.ActiveRowIndex, i].Value == null)
                    {
                        fpEnter1_Sheet1.Cells[fpEnter1_Sheet1.ActiveRowIndex, i].Value = true;
                    }
                    else if (fpEnter1_Sheet1.Cells[fpEnter1_Sheet1.ActiveRowIndex, i].Value.ToString() == "False")
                    {
                        fpEnter1_Sheet1.Cells[fpEnter1_Sheet1.ActiveRowIndex, i].Value = true;
                    }
                    else
                    {
                        fpEnter1_Sheet1.Cells[fpEnter1_Sheet1.ActiveRowIndex, i].Value = false;
                    }
                }
            }
            else if (keyData.GetHashCode() == Keys.Escape.GetHashCode())
            {
                this.ucDiagnose1.Visible = false;
            }
            else if (keyData.GetHashCode() == Keys.Up.GetHashCode())
            {
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Icd10Code)
                {
                    this.ucDiagnose1.PriorRow();
                }
            }
            else if (keyData.GetHashCode() == Keys.Down.GetHashCode())
            {
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Icd10Code)
                {
                    this.ucDiagnose1.NextRow();
                }
            }
            return base.ProcessDialogKey(keyData);
            //return true;
        }

        private void fpEnter1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            //设置fpSpread1 的属性
            if (System.IO.File.Exists(filePath))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpEnter1_Sheet1, filePath);
            }
        }
        /// <summary>
        /// 当单元格中的数据变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpEnter1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            //筛选数据

            try
            {
                if (e.Column == 1)
                {
                    if (this.ucDiagnose1.Visible == false)
                    {
                        this.ucDiagnose1.Visible = true;
                    }
                    string str = fpEnter1_Sheet1.ActiveCell.Text;
                    this.ucDiagnose1.Filter(str);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int GetInfo()
        {
            try
            {
                Neusoft.HISFC.Models.HealthRecord.ICD item = null;
                if (this.ucDiagnose1.GetItem(ref item) == -1)
                {
                    //MessageBox.Show("获取项目出错!","提示");
                    return -1;
                }
                //			this.contralActive.Text=(item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                //			this.contralActive.Tag=item;
                //			this.ucDiag1.Visible=false;
                if (item == null) return -1;

                string itemCode = string.Empty;
                string diagType = this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)Col.DiagKind].Text.Trim();
                for (int i = 0; i < this.fpEnter1_Sheet1.Rows.Count; i++)
                {
                    if (i == this.fpEnter1_Sheet1.ActiveRowIndex) continue;
                    //集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
                    //itemCode = this.fpEnter1_Sheet1.Cells[i, (int)Col.Icd10Code].Text.Trim();
                    //if (!string.IsNullOrEmpty(itemCode) && itemCode == item.ID)
                    //{
                    //    MessageBox.Show("该诊断已存在！");
                    //    return -1;
                    //}
                }

                //ICD诊断名称
                fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Icd10Code].Text = item.ID;
                //ICD诊断编码
                fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)Col.Icd10Name].Text = item.Name;
                ucDiagnose1.Visible = false;
                fpEnter1.Focus();
                //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
                if (this.isCas)
                {
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.OutState);
                }
                else
                {
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)Col.IsDraftExamine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        /// <summary>
        /// 鼠标点到单元格 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpEnter1_EditModeOn(object sender, System.EventArgs e)
        {
            if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)Col.Icd10Code)
            {
                Control _cell = fpEnter1.EditingControl;
                //设置位置
                this.ucDiagnose1.Location = new System.Drawing.Point(_cell.Location.X, _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                ucDiagnose1.BringToFront();
                this.ucDiagnose1.Filter(fpEnter1_Sheet1.ActiveCell.Text);
                this.ucDiagnose1.Visible = true;
            }
            else
            {
                this.ucDiagnose1.Visible = false;
            }

            //显示
        }

        private int ucDiagnose1_SelectItem(Keys key)
        {
            GetInfo();
            return 0;
        }

        private void fpEnter1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == 2)//(int)Col.Icd10Code)
                {
                    GetInfo();
                }
            }
        }

        //{74A9AA46-74B3-49e8-910A-54A998E428AF} 增加拟诊功能
        private void fpEnter1_Sheet1_CellChanged(object sender, SheetViewEventArgs e)
        {
            //集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
            if (e.Column == (int)Col.DiagKind)
            {
                string diagType = this.fpEnter1_Sheet1.Cells[e.Row, (int)Col.DiagKind].Text.Trim();
                if (string.IsNullOrEmpty(diagType.Trim()))
                {
                    this.fpEnter1_Sheet1.SetActiveCell(e.Row, (int)Col.DiagKind);
                    return;
                }
                for (int i = 0; i < this.fpEnter1_Sheet1.Rows.Count; i++)
                {
                    if (i == e.Row)
                        continue;
                    string otherDiagType = this.fpEnter1_Sheet1.Cells[i, (int)Col.DiagKind].Text.Trim();
                    if (diagType == otherDiagType)
                    {
                        this.fpEnter1_Sheet1.Cells[e.Row, (int)Col.DiagKind].Text = "";
                        this.fpEnter1_Sheet1.SetActiveCell(e.Row, (int)Col.DiagKind);
                        MessageBox.Show("该诊断类型已存在");
                        return;
                    }
                }

            }
            if (e.Column == (int)Col.IsDraftExamine)
            {
                if (this.fpEnter1_Sheet1.Cells[e.Row, e.Column].Value.ToString() == "False")
                {
                    this.fpEnter1_Sheet1.Cells[e.Row, (int)Col.Icd10Code].Locked = false;
                    this.fpEnter1_Sheet1.Cells[e.Row, (int)Col.Icd10Name].Locked = true;
                }
                else
                {
                    this.fpEnter1_Sheet1.Cells[e.Row, (int)Col.Icd10Code].Locked = true;
                    this.fpEnter1_Sheet1.Cells[e.Row, (int)Col.Icd10Name].Locked = false;
                    this.fpEnter1_Sheet1.Cells[e.Row, (int)Col.Icd10Code].Text = " ";
                }
            }
        }

        /// <summary>
        /// 集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
        /// </summary>
        /// <returns></returns>
        public bool IsValid(ref string err)
        {
            bool haveMainDiag = false;
            foreach (DataRow  dr in this.dtDiagnose.Rows)
            {
                dr.EndEdit();
                if (dr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (diagnoseTypeHelper.GetID(dr["诊断类别"].ToString()) == "1" && !string.IsNullOrEmpty(dr["ICD10"].ToString().Trim()))
                {
                    haveMainDiag = true;
                }
            }
            if (!haveMainDiag)
            {
                err = "请录入出院主诊断";
                return false;
            }
            return true;
        }

    }
}
