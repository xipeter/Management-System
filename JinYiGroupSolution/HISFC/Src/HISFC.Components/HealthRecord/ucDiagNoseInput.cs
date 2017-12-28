using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;
namespace UFC.HealthRecord
{
    public partial class ucDiagNoseInput : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDiagNoseInput()
        {
            InitializeComponent();
        }

        #region  全局变量
        //诊断类别
        private ArrayList diagnoseType = new ArrayList();
        private Neusoft.NFC.Public.ObjectHelper diagnoseTypeHelper = new Neusoft.NFC.Public.ObjectHelper();
        //分期列表
        private ArrayList PeriorList = new ArrayList();
        private Neusoft.NFC.Public.ObjectHelper PeriorListHelper = new Neusoft.NFC.Public.ObjectHelper();
        //分级列表
        private ArrayList LeveList = new ArrayList();
        private Neusoft.NFC.Public.ObjectHelper LeveListHelper = new Neusoft.NFC.Public.ObjectHelper();
        //出院情况 列表
        private ArrayList diagOutStateList = new ArrayList();
        private Neusoft.NFC.Public.ObjectHelper diagOutStateListHelper = new Neusoft.NFC.Public.ObjectHelper();
        private string inpatientNo  ;
        private Neusoft.HISFC.Object.RADT.PatientInfo patient = new Neusoft.HISFC.Object.RADT.PatientInfo();
        //操作 手术类型 
        private ArrayList OperList = new ArrayList();
        private Neusoft.NFC.Public.ObjectHelper OperListHelper = new Neusoft.NFC.Public.ObjectHelper();
        //诊断信息
        public ArrayList diagList = null;
        //标识是医生站 还是 病案室
        private Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes frmType = Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC;
        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService();
        private FarPoint.Win.Spread.CellType.CheckBoxCellType checkCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
        #endregion

        #region 属性

        [Description("整理员类型")]
        public Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes OperType
        {
            set
            {
                this.frmType = value;
            }
            get
            {
                return frmType;
            }
        }
        #endregion 
      
        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.AddRow();
                    break;
                case "刷新":
                    this.LoadInfo(inpatientNo);
                    break;
                case "删除":
                    this.DeleteActiveRow();
                    break;
                case "打印":

                    break;
                default:
                    break;
            }
        }
        #endregion 

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "增加",Neusoft.NFC.Interface.Classes.EnumImageList.A添加, true, false, null);
            toolBarService.AddToolButton("刷新", "刷新", Neusoft.NFC.Interface.Classes.EnumImageList.A刷新, true, false, null);
            toolBarService.AddToolButton("删除", "删除", Neusoft.NFC.Interface.Classes.EnumImageList.A删除, true, false, null);
            toolBarService.AddToolButton("打印", "打印", Neusoft.NFC.Interface.Classes.EnumImageList.A打印, true, false, null);
            return toolBarService;
        }
        #endregion


        #region 枚举
        enum Cols
        {
            diagType, //诊断类别
            ICDCode,//icd
            ICDName, //ICD名称
            outState, //出院情况
            Operation,//手术类型
            disease, //30种疾病
            clpa,//病理符合
            perionCode,//分期 
            levelCode,//分级
            dubdiag,//是否疑诊
            mainDiag,//主诊断
            happenNo,//序号
            diagTime,//诊断日期
            inTime,//入院日期
            outTime,//出院日期
            diagDocCode,//诊断医生
            diagDocName//诊断医生

        }
        #endregion

        #region 初始化

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.fpEnter1_Sheet1.Rows.Remove(0, this.fpEnter1_Sheet1.RowCount);
            Neusoft.NFC.Object.NeuObject obj = neuObject as Neusoft.NFC.Object.NeuObject;
            if (obj == null) return -1;
            this.inpatientNo = obj.ID;
            this.LoadInfo(obj.ID);//分级
            return 0;
        }
        #region 总体初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private  void InitInfo()
        {
            try
            {
                //设置下拉列表
                this.initList();
                fpEnter1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 设置列下拉列表
        /// <summary>
        /// 设置列下拉列表
        /// </summary>
        private void initList()
        {
            try
            {
                Neusoft.HISFC.Management.HealthRecord.Diagnose da = new Neusoft.HISFC.Management.HealthRecord.Diagnose();
                Neusoft.HISFC.Management.Manager.Constant con = new Neusoft.HISFC.Management.Manager.Constant();
                this.fpEnter1.SelectNone = true;
                //获取出院诊断类别诊断
                //				diagnoseType = da.GetDiagnoseList();
                diagnoseType = Neusoft.HISFC.Object.HealthRecord.DiagnoseType.SpellList();
                diagnoseTypeHelper.ArrayObject = diagnoseType;
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 0, diagnoseType);

                //分期列表
                PeriorList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.DIAGPERIOD);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 7, PeriorList);
                PeriorListHelper.ArrayObject = PeriorList;
                //手术操作类型
                OperList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.OPERATIONTYPE);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 4, OperList);
                OperListHelper.ArrayObject = OperList;

                //分级列表 
                LeveList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.DIAGLEVEL);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 8, LeveList);
                LeveListHelper.ArrayObject = LeveList;

                //出院情况列表
                diagOutStateList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.ZG);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 3, diagOutStateList);
                diagOutStateListHelper.ArrayObject = diagOutStateList;

                this.fpEnter1.SetWidthAndHeight(200, 200);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #endregion
        
        #region 增加一行
        //添加一行项目
        public int AddRow()
        {
            try
            {
                if (this.inpatientNo == null || this.inpatientNo == "")
                {
                    MessageBox.Show("录诊断前请先选择患者");
                    return 0;
                }
                fpEnter1_Sheet1.Rows.Add(0, 1);
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.Rows.Count, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        #endregion 

        #region 删除一行
        /// <summary>
        /// 删除当前行 
        /// </summary>
        /// <returns></returns>
        public int DeleteActiveRow()
        {
            if (fpEnter1_Sheet1.Rows.Count > 0)
            {
                this.fpEnter1_Sheet1.Rows.Remove(fpEnter1_Sheet1.ActiveRowIndex, 1);
            }
            if (fpEnter1_Sheet1.Rows.Count == 0)
            {
                this.fpEnter1.SetAllListBoxUnvisible();
            }
            return 1;
        }
         #endregion 

        #region 保存

        #region 获取需要保存的数据
        #region 获取修改过的信息
        /// <summary>
        /// 获取修改过的信息
        /// </summary>
        /// <returns></returns>
        private ArrayList GetChangeInfo()
        {
            ArrayList list = new ArrayList();
            try
            {
                Neusoft.HISFC.Management.HealthRecord.Diagnose dia = new Neusoft.HISFC.Management.HealthRecord.Diagnose();
                Neusoft.HISFC.Object.HealthRecord.Diagnose info = null;
                for (int i = 0; i < this.fpEnter1_Sheet1.RowCount; i++)
                {
                    info = new Neusoft.HISFC.Object.HealthRecord.Diagnose();
                    info.DiagInfo.Patient.ID = inpatientNo;
                    //诊断类别
                    info.DiagInfo.DiagType.ID = diagnoseTypeHelper.GetID(this.fpEnter1_Sheet1.Cells[i, (int)Cols.diagType].Text);
                    info.DiagInfo.ICD10.ID = fpEnter1_Sheet1.Cells[i, (int)Cols.ICDCode].Text;//2
                    //if (info.DiagInfo.DiagType.ID == "1") //将主诊断设置成 
                    //{
                        
                    //}
                    //else
                    //{
                    //    info.DiagInfo.IsMain = false;
                    //}
                    info.DiagInfo.ICD10.Name = fpEnter1_Sheet1.Cells[i, (int)Cols.ICDName].Text;
                    //if (row["出院情况"] != DBNull.Value)
                    //{
                    info.DiagOutState = diagOutStateListHelper.GetID(fpEnter1_Sheet1.Cells[i, (int)Cols.outState].Text); //3
                    //}
                    //if (row["有无手术"] != DBNull.Value)
                    //{
                    info.OperationFlag = OperListHelper.GetID(fpEnter1_Sheet1.Cells[i, (int)Cols.Operation].Text);
                    //}

                    //if ()//5
                    //{
                    info.Is30Disease = Neusoft.NFC.Function.NConvert.ToInt32(ConvertBool(fpEnter1_Sheet1.Cells[i, (int)Cols.disease].Value)).ToString();
                    //}
                    //else
                    //{
                    //    info.Is30Disease = "0";
                    //}
                    //if (ConvertBool(row["病理符合"]))//6
                    //{
                    info.CLPA = Neusoft.NFC.Function.NConvert.ToInt32(ConvertBool(fpEnter1_Sheet1.Cells[i, (int)Cols.clpa].Value)).ToString();
                    //}
                    //else
                    //{
                    //info.CLPA = "0";
                    //}
                    //if (row["分级"] != DBNull.Value)
                    //{
                    info.LevelCode = LeveListHelper.GetID(fpEnter1_Sheet1.Cells[i, (int)Cols.levelCode].Text); //7
                    //}
                    //if (row["分期"] != DBNull.Value)
                    //{
                    info.PeriorCode = PeriorListHelper.GetID(fpEnter1_Sheet1.Cells[i, (int)Cols.perionCode].Text);//8
                    //}
                    //if (ConvertBool(row["是否疑诊"]))//9
                    //{
                    info.DubDiagFlag = Neusoft.NFC.Function.NConvert.ToInt32(ConvertBool(fpEnter1_Sheet1.Cells[i, (int)Cols.dubdiag].Value)).ToString(); ;
                    info.DiagInfo.IsMain = ConvertBool(fpEnter1_Sheet1.Cells[i, (int)Cols.mainDiag].Value);
                    //}
                    //else
                    //{
                    //    info.DubDiagFlag = "0";
                    //}
                    info.DiagInfo.HappenNo = i;
                    info.DiagInfo.DiagDate = Neusoft.NFC.Function.NConvert.ToDateTime(fpEnter1_Sheet1.Cells[i, (int)Cols.diagTime].Text);//11
                    info.Pvisit.InTime = Neusoft.NFC.Function.NConvert.ToDateTime(fpEnter1_Sheet1.Cells[i, (int)Cols.inTime].Text);//12
                    info.Pvisit.OutTime = Neusoft.NFC.Function.NConvert.ToDateTime(fpEnter1_Sheet1.Cells[i, (int)Cols.outTime].Text);//13
                    if (frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC)
                    {
                        info.OperType = "1";
                    }
                    else if (frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS)
                    {
                        info.OperType = "2";
                    }
                    
                    if (fpEnter1_Sheet1.Cells[i,0].Tag != null)
                    {
                        Neusoft.HISFC.Object.HealthRecord.Diagnose obj = (Neusoft.HISFC.Object.HealthRecord.Diagnose)fpEnter1_Sheet1.Cells[i, 0].Tag;
                        info.DiagInfo.Doctor = obj.DiagInfo.Doctor;
                    }
                    else
                    {
                        info.DiagInfo.Doctor.ID = dia.Operator.ID;
                        info.DiagInfo.Doctor.Name = dia.Operator.Name;
                    }
                    list.Add(info);
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion

        #region 将实体转化成BOOL类型
        /// <summary>
        /// 将实体转化成BOOL类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ConvertBool(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Neusoft.NFC.Function.NConvert.ToBoolean(obj);
        }
        #endregion

                #endregion

        public override int Save(object sender, object neuObject)
        {
            if (inpatientNo == null || inpatientNo == "")
            {
                MessageBox.Show("请选择患者");
                return 0;
            }
            Neusoft.HISFC.Management.HealthRecord.Diagnose diagNose = new Neusoft.HISFC.Management.HealthRecord.Diagnose();
            Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(diagNose.Connection);
            trans.BeginTransaction();
            diagNose.SetTrans(trans.Trans);
            this.fpEnter1.StopCellEditing();
            ArrayList list = this.GetChangeInfo();
            if(list.Count == 0)
            {
                trans.RollBack();
                MessageBox.Show("没有可保存的信息");
                return 0;
            }
            if (ValueState(list) == -1)
            {

                trans.RollBack();
                return -1;
            }

            
            #region 删除
            if (diagNose.DeleteDiagnoseAll(this.inpatientNo,frmType) < 0)
            {
                trans.RollBack();
                MessageBox.Show("保存诊断信息失败" + diagNose.Err);
                return -1;
            }
            #endregion 
            #region 更新 增加
            foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose obj in list)
            {
                if (diagNose.InsertDiagnose(obj) < 0)
                {
                    trans.RollBack();
                    MessageBox.Show("保存失败 " + diagNose.Err);
                }
            }
            #endregion
            this.fpEnterSaveChanges();
            trans.Commit();
            ClearInfo();
            LoadInfo(inpatientNo);
            MessageBox.Show("保存成功");

            return base.Save(sender, neuObject);
        }
        #endregion 

        #region 清空原有的数据
        /// <summary>
        /// 清空原有的数据
        /// </summary>
        /// <returns></returns>
        private int ClearInfo()
        {
            if (this.fpEnter1_Sheet1.RowCount != 0)
            {
                this.fpEnter1_Sheet1.Rows.Remove(0, this.fpEnter1_Sheet1.RowCount);
                LockFpEnter();
            }
            else
            {
                MessageBox.Show("诊断表为null");
            }
            return 1;
        }
        #endregion 

        #region 设置只读
        bool readOnly; //是否只读
        [Description ("是否只读")]
        public bool SetReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
                if (readOnly)
                {
                    this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
                }
                else
                {
                    this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                }

            }
        }
        #endregion 

        #region 校验数据的合法性
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
            foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.Patient.ID == "" || obj.DiagInfo.Patient.ID == null)
                {
                    MessageBox.Show("诊断信息的住院流水号不能为空");
                    return -1;
                }
                if (obj.DiagInfo.Patient.ID.Length > 14)
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
                if (obj.DiagInfo.DiagType.ID.Length > 2)
                {
                    MessageBox.Show("诊断信息的诊断类型编码过长");
                    return -1;
                }
                if (obj.LevelCode.Length > 3)
                {
                    MessageBox.Show("诊断信息的诊断级别编码过长");
                    return -1;
                }
                if (obj.PeriorCode.Length > 3)
                {
                    MessageBox.Show("诊断信息的诊断分期编码过长");
                    return -1;
                }
                if (obj.DiagInfo.ICD10.ID == "" || obj.DiagInfo.ICD10.ID == null)
                {
                    MessageBox.Show("诊断信息的ICD诊断不能为空");
                    return -1;
                }
                if (obj.DiagInfo.ICD10.ID.Length > 30)
                {
                    MessageBox.Show("诊断信息的诊断编码过长");
                    return -1;
                }
                if (obj.DiagInfo.ICD10.Name == "" || obj.DiagInfo.ICD10.Name == null)
                {
                    MessageBox.Show("诊断信息的ICD诊断不能为空");
                    return -1;
                }
                if (obj.DiagInfo.ICD10.Name.Length > 100)
                {
                    MessageBox.Show("诊断信息的诊断名称过长");
                    return -1;
                }
                if (obj.DiagInfo.Doctor.ID == "" || obj.DiagInfo.Doctor.ID == null)
                {
                    MessageBox.Show("诊断信息的诊断医生编码不能为空");
                    return -1;
                }
                if (obj.DiagInfo.Doctor.ID.Length > 6)
                {
                    MessageBox.Show("诊断信息的医生编码过长");
                    return -1;
                }
                if (obj.DiagInfo.Doctor.Name == "" || obj.DiagInfo.Doctor.Name == null)
                {
                    MessageBox.Show("诊断信息的诊断医生不能为空");
                    return -1;
                }
                if (obj.DiagInfo.Doctor.Name.Length > 10)
                {
                    MessageBox.Show("诊断信息的医生名称过长");
                    return -1;
                }
                if (obj.DiagOutState.Length > 2)
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
        #endregion 

        #region 保存对表做的所有修改
        /// <summary>
        /// 保存对表做的所有修改
        /// </summary>
        /// <returns></returns>
        public int fpEnterSaveChanges()
        {
            try
            {
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }
        #endregion 

        #region 根据输入的住院号/门诊号 查询诊断信息
        /// <summary>
        /// 根据输入的住院号/门诊号 查询诊断信息
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Type"></param>
        /// <returns>-1 出错 0 传入的病人信息为空,不作处理，1 不允许有病案，2病案已经封存，不允许医生修改和查阅 3 查询有数据 4查询没有数据  </returns>
        public int LoadInfo(string InpatientNO) //Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes Type)
        {
            try
            {
                if (this.fpEnter1_Sheet1.RowCount > 0)
                {
                    this.fpEnter1_Sheet1.Rows.Remove(0, this.fpEnter1_Sheet1.RowCount);
                }
                if (InpatientNO == null || InpatientNO == "")
                {
                    //没有该病人的信息
                    MessageBox.Show("请选择病人");
                    return 0;
                }
                this.inpatientNo = InpatientNO;
                Neusoft.HISFC.Object.RADT.PatientInfo patient = new Neusoft.HISFC.Object.RADT.PatientInfo();
                Neusoft.HISFC.Integrate.RADT pa = new Neusoft.HISFC.Integrate.RADT();// Neusoft.HISFC.Management.RADT.InPatient();
                Neusoft.HISFC.Integrate.Registration.Registration register = new Neusoft.HISFC.Integrate.Registration.Registration();
                //从住院主表中查旬
                patient = pa.GetPatientInfoByPatientNO(InpatientNO);
                if (patient == null)
                {
                    Neusoft.HISFC.Object.Registration.Register obj = register.GetByClinic(InpatientNO);
                    if (obj == null)
                    {
                        MessageBox.Show("查询病人信息出错");
                        return -1;
                    }
                    patient = new Neusoft.HISFC.Object.RADT.PatientInfo();
                    patient.ID = obj.ID;
                    patient.CaseState = "1";
                }

                if (patient.CaseState == "0")
                {
                    //不允许有病案
                    return 1;
                }
                //定义业务层的类
                Neusoft.HISFC.Management.HealthRecord.Diagnose diag = new Neusoft.HISFC.Management.HealthRecord.Diagnose();
                diagList = new ArrayList();

                if (frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC) // 医生站录入病历
                {
                    #region  医生站录入病历

                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    // 医生站录入病例

                    if (patient.CaseState == null || patient.CaseState == "1" || patient.CaseState == "2")
                    {
                        //从医生站录入的信息中查询
                        diagList = diag.QueryCaseDiagnose(patient.ID, "%", Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC);
                    }
                    else
                    {
                        // 病案已经封存已经不允许医生修改和查阅
                        return 2;
                    }

                    #endregion
                }
                else if (frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS)//病案室录入病历
                {
                    #region 病案室录入病历
                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    if (patient.CaseState == null||patient.CaseState == "1" || patient.CaseState == "2")
                    {
                        //医生站已经录入病案
                        diagList = diag.QueryCaseDiagnose(patient.ID, "%", Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC);
                    }
                    else if (patient.CaseState == "3")
                    {
                        //病案室已经录入病案
                        diagList = diag.QueryCaseDiagnose(patient.ID, "%", Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS);
                    }
                    else if (patient.CaseState == "4")
                    {
                        //病案已经封存 不允许修改。
                        diagList = diag.QueryCaseDiagnose(patient.ID, "%", Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS);
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
                    AddInfoToFP(diagList);
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
        #endregion

        #region 填充数据
        /// <summary>
        /// 查询诊断信息并且填充的表中
        /// </summary>
        private void AddInfoToFP(ArrayList alReturn)
        {
            bool Result = false;
            if ((this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC && this.patient.CaseState == "2") || (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS && this.patient.CaseState == "3"))
            {
                Result = true;
            }
            //清空以前的数据
            if (this.fpEnter1_Sheet1.RowCount > 0)
            {
                this.fpEnter1_Sheet1.Rows.Remove(0, this.fpEnter1_Sheet1.Rows.Count);
            }
            //循环插入信息
            foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose info in alReturn)
            {
                this.fpEnter1_Sheet1.Rows.Add(0, 1);
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.diagType].Text = diagnoseTypeHelper.GetName(info.DiagInfo.DiagType.ID); //0
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.ICDName].Text = info.DiagInfo.ICD10.Name;//1
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.ICDCode].Text = info.DiagInfo.ICD10.ID;//2
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.outState].Text = diagOutStateListHelper.GetName(info.DiagOutState); //3
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.Operation].Text = OperListHelper.GetName(info.OperationFlag);
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.disease].Value = Neusoft.NFC.Function.NConvert.ToBoolean(info.Is30Disease);
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.clpa].Value = Neusoft.NFC.Function.NConvert.ToBoolean(info.CLPA);
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.levelCode].Text = LeveListHelper.GetName(info.LevelCode); //7
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.perionCode].Text = PeriorListHelper.GetName(info.PeriorCode);//8
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.dubdiag].Value = Neusoft.NFC.Function.NConvert.ToBoolean(info.DubDiagFlag);
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.mainDiag].Value = info.DiagInfo.IsMain;
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.happenNo].Text = info.DiagInfo.HappenNo.ToString();
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.diagTime].Text = info.DiagInfo.DiagDate.ToString();
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.inTime].Text = patient.PVisit.InTime.ToString();
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.outTime].Text = patient.PVisit.OutTime.ToString();
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.diagDocCode].Text = info.DiagInfo.Doctor.ID;
                this.fpEnter1_Sheet1.Cells[0, (int)Cols.diagDocName].Text = info.DiagInfo.Doctor.Name;
                this.fpEnter1_Sheet1.Cells[0, 0].Tag = info;
            }
            LockFpEnter();
        }
        #endregion 

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
            fpEnter1.KeyEnter += new Neusoft.NFC.Interface.Controls.NeuFpEnter.keyDown(fpEnter1_KeyEnter);
            fpEnter1.SetItem += new Neusoft.NFC.Interface.Controls.NeuFpEnter.setItem(fpEnter1_SetItem);
            fpEnter1.KeyUp += new KeyEventHandler(fpEnter1_KeyUp);
            fpEnter1.ShowListWhenOfFocus = true;
            InitInfo();
            this.ucDiagnose1.Init();
            this.ucDiagnose1.SelectItem +=new Neusoft.UFC.Common.Controls.ucDiagnose.MyDelegate(ucDiagnose1_SelectItem); 
            this.ucDiagnose1.Visible = false;
        }

        #region  对选择项目的处理事件 
        #region 处理回车操作 ，并且取出数据
        /// <summary>
        /// 处理回车操作 ，并且取出数据
        /// </summary>
        /// <returns></returns>
        private int ProcessDept()
        {
            int CurrentRow = fpEnter1_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            if (fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.DiagKind) //诊断类型 
            {
                //获取选中的信息
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)EnumCol.DiagKind);
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //诊断类别
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.Icd10Code);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.OutState)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)EnumCol.OutState);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                // 出院信息
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.OperationFlag);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.OperationFlag)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)EnumCol.OperationFlag);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                // 出院信息
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.Disease);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.Perior)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)EnumCol.Perior);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //分期
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.Level);
                return 0;
            }
            else if (fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.Level)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)EnumCol.Level);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //分期
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.DubDiag);
                return 0;
            }

            return 0;
        }

        private int fpEnter1_SetItem(Neusoft.NFC.Object.NeuObject obj)
        {
            this.ProcessDept();
            return 0;
        }
        #endregion
        #endregion 

        #region 按键响应处理
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
                    if (i == (int)EnumCol.DiagKind || i == (int)EnumCol.OutState || i == (int)EnumCol.OperationFlag || i == (int)EnumCol.Perior || i == (int)EnumCol.Level)
                    {
                        ProcessDept();
                    }
                    else if (i == (int)EnumCol.DubDiag)
                    {
                        if (fpEnter1_Sheet1.ActiveRowIndex < fpEnter1_Sheet1.Rows.Count - 1)
                        {
                            fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex + 1, 0);
                        }
                        else
                        {
                            //if (this.Tag != null)
                            //{
                            //    this.AddBlankRow(); //增加一个空白行 
                            //}
                            //else
                            //{
                                //增加一行
                                this.AddRow();
                            //}
                        }
                    }
                    else
                    {
                        if (i < (int)EnumCol.DubDiag)
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
                if (fpEnter1_Sheet1.Rows.Count == 0 || fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.DubDiag)
                {
                    AddRow();
                }
            }
            return 0;
        }
        #endregion 

        #region 限定格的宽度和可见性
        /// <summary>
        /// 限定格的宽度和可见性 
        /// </summary>
        private void LockFpEnter()
        {
            //this.fpEnter1_Sheet1.Columns[(int)Cols.diagType].Width = 59; //诊断类别
            //this.fpEnter1_Sheet1.Columns[(int)Cols.ICDCode].Width = 124;//ICD10
            this.fpEnter1_Sheet1.Columns[(int)Cols.ICDName].Locked = true;
            //this.fpEnter1_Sheet1.Columns[(int)Cols.ICDName].Width = 150;//诊断名称
            //this.fpEnter1_Sheet1.Columns[(int)Cols.outState].Width = 65; //出院情况
            //this.fpEnter1_Sheet1.Columns[(int)Cols.Operation].Width = 40; //有无手术
            this.fpEnter1_Sheet1.Columns[(int)Cols.disease].CellType = checkCellType; //30种疾病

            this.fpEnter1_Sheet1.Columns[(int)Cols.clpa].CellType = checkCellType; //病理符合
            //this.fpEnter1_Sheet1.Columns[(int)Cols.perionCode].Width = 51; //分期
            //this.fpEnter1_Sheet1.Columns[(int)Cols.levelCode].Width = 50; //分级
            this.fpEnter1_Sheet1.Columns[(int)Cols.dubdiag].CellType = checkCellType ; //是否疑诊
            this.fpEnter1_Sheet1.Columns[(int)Cols.mainDiag].CellType = checkCellType; //主诊断
            //this.fpEnter1_Sheet1.Columns[(int)Cols.mainDiag].Visible = false; //主诊断
            this.fpEnter1_Sheet1.Columns[(int)Cols.happenNo].Visible = false; //序号
            this.fpEnter1_Sheet1.Columns[(int)Cols.diagTime].Visible = false; //诊断日期
            this.fpEnter1_Sheet1.Columns[(int)Cols.inTime].Visible = false; //入院日期
            this.fpEnter1_Sheet1.Columns[(int)Cols.outTime].Visible = false; //出院日期
            this.fpEnter1_Sheet1.Columns[(int)Cols.diagDocCode].Visible = false; //诊断医师代码
            this.fpEnter1_Sheet1.Columns[(int)Cols.diagDocName].Visible = false; //诊断医师
        }
        #endregion 

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.NumPad1)
            {
                int i = fpEnter1_Sheet1.ActiveColumnIndex;
                if (i == (int)EnumCol.Disease || i == (int)EnumCol.CLPa || i == (int)EnumCol.DubDiag || i == (int)EnumCol.MainDiag)
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
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.Icd10Code)
                {
                    this.ucDiagnose1.PriorRow();
                }
            }
            else if (keyData.GetHashCode() == Keys.Down.GetHashCode())
            {
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.Icd10Code)
                {
                    this.ucDiagnose1.NextRow();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        #region 当单元格中的数据变化时触发
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
                    this.ucDiagnose1.Filter(fpEnter1_Sheet1.ActiveCell.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion 

        #region 选择诊断

        #region 获取诊断
        private int GetInfo()
        {
            try
            {
                Neusoft.HISFC.Object.HealthRecord.ICD item = null;
                if (this.ucDiagnose1.GetItem(ref item) == -1)
                {
                    //MessageBox.Show("获取项目出错!","提示");
                    return -1;
                }
                //			this.contralActive.Text=(item as Neusoft.HISFC.Object.HealthRecord.ICD).Name;
                //			this.contralActive.Tag=item;
                //			this.ucDiag1.Visible=false;
                if (item == null) return -1;
                //ICD诊断名称
                fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.Icd10Code].Text = item.ID;
                //ICD诊断编码
                fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.Icd10Name].Text = item.Name;
                ucDiagnose1.Visible = false;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, (int)EnumCol.OutState);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        #endregion 

        #region 鼠标点到单元格
        /// <summary>
        /// 鼠标点到单元格 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpEnter1_EditModeOn(object sender, System.EventArgs e)
        {
            if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)EnumCol.Icd10Code)
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
        #endregion 

        #region 回车事件
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
        #endregion 

        #endregion

        #region  列的枚举
        private enum EnumCol
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
            MainDiag = 10//主诊断
        }
        #endregion

        #region 废弃
        /// <summary>
        /// 增加一个空白行 
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 ", true)]
        public void AddBlankRow()
        {
            this.fpEnter1_Sheet1.Rows.Add(this.fpEnter1_Sheet1.RowCount, 1);
        }

        /// <summary>
        /// 是否有并发症
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃", true)]
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
        /// 院内感染次数 
        /// </summary>
        /// <returns></returns>
        [Obsolete(" 废弃 ",true)]
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
        /// 删除空白的行
        /// </summary>
        /// <returns></returns>
        public int deleteRow()
        {
            if (fpEnter1_Sheet1.Rows.Count == 1)
            {
                //第一行编码为空 
                if (fpEnter1_Sheet1.Cells[0, 1].Text == "")
                {
                    fpEnter1_Sheet1.Rows.Remove(0, 1);
                }
            }
            return 1;
        }

        /// <summary>
        /// 返回当前行数
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃")]
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
        [Obsolete("废弃", true)]
        public bool Reset(bool reset)
        {
            if (reset)
            {
                //清空数据 保存更改 
                //if (dtDiagnose != null)
                //{
                //    dtDiagnose.Clear();
                //    dtDiagnose.AcceptChanges();
                //}
            }
            else
            {
                //保存更改
                //dtDiagnose.AcceptChanges();
            }
            LockFpEnter();
            return true;
        }
        /// <summary>
        /// 设置活动单元格
        /// </summary>
        [Obsolete("废弃", true)]
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
        /// 将保存完的数据回写到表中
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public int fpEnterSaveChanges(ArrayList list)
        {
            AddInfoToFP(list);
            this.LockFpEnter();
            return 0;
        }

        #region 获取所有的诊断信息
        /// <summary>
        /// 获取所有的诊断信息
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public int GetAllDiagnose(ArrayList list)
        {
            //GetChangeInfo(dtDiagnose, list);
            return 1;
        }
        #endregion
        #endregion 
    }
}