using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.InpatientFee.Register
{
    public partial class ucPrepayInQuery : UserControl
    {
        public ucPrepayInQuery()
        {
            InitializeComponent();

        }


        #region 变量
        //预约状态
        private string prepayinState;
        DataTable dtPrepayIn = new DataTable();
        DataView dvPrepayIn;
        private Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo;
        #endregion

        #region 业务层实体
        /// <summary>
        /// 查找合同单位名称实体
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper myObjHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        /// <summary>
        /// 查找人员名称实体
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper operObjHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        /// <summary>
        /// 常数实体
        /// </summary>
        //private Neusoft.HISFC.BizLogic.Manager.Constant Constant = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 人员业务层
        /// </summary>
        //private Neusoft.HISFC.BizLogic.Manager.Person myPerson = new Neusoft.HISFC.BizLogic.Manager.Person();

        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizLogic.Fee.InPatient inPatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        /// <summary>
        /// 合同单位业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactUnitInfo = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        //private Neusoft.HISFC.BizLogic.RADT.InPatient myInpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        #endregion

        #region 属性
        /// <summary>
        /// 预约状态 0预约　1作废 2预约转住院
        /// </summary>
        public string PrepayinState
        {
            get { return prepayinState; }
            set { prepayinState = value; }
        }
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return myPatientInfo;
            }
            set
            {
                if (value == null)
                    myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                else
                    myPatientInfo = value;
            }
        }
        #endregion    

        #region 初始化
        private void InitQuery()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据，请稍后^^");
            Application.DoEvents();
            //初始化合同单位信息
            //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
            //this.myObjHelper.ArrayObject = this.managerIntegrate.GetConstantList(EnumConstant.PACTUNIT);// Constant.GetList(EnumConstant.PACTUNIT);
            this.myObjHelper.ArrayObject = this.pactUnitInfo.QueryPactUnitAll();
            //初始化人员信息
            this.operObjHelper.ArrayObject = this.managerIntegrate.QueryEmployeeAll();// myPerson.GetEmployeeAll();
            //起止时间
            this.dtEnd.Value = inPatient.GetDateTimeFromSysDateTime();
            this.dtBegin.Value = this.dtEnd.Value.AddDays(-1);
            //初始化DataTable
            SetDataTable();
            //查询数据
            QueryData();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #endregion 

        #region 方法
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        private void SetDataTable()
        {
            this.fpMainInfo_Sheet1.RowCount = 0;

            Type str = typeof(String);
            Type date = typeof(DateTime);

            Type dec = typeof(Decimal);
            Type bo = typeof(bool);
            #region 预约登记列表

            dtPrepayIn.Columns.AddRange(new DataColumn[]{new DataColumn("发生序号", str),
															new DataColumn("病历号", str),
															new DataColumn("患者姓名", str),
															new DataColumn("性别", str),
															new DataColumn("合同单位", str),
															new DataColumn("住院科室", str),
															new DataColumn("预约日期", str),
															new DataColumn("当前状态", str),															
															new DataColumn("家庭地址", str),
															new DataColumn("家庭电话", str),
															new DataColumn("联系人", str),
															new DataColumn("联系人电话", str),
															new DataColumn("联系人地址", str),
															new DataColumn("操作员", str),
															new DataColumn("操作时间", str)});



            #endregion
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        public void QueryData()
        {
            string Begin = this.dtBegin.Value.ToShortDateString() + " 00:00:00";
            string End = this.dtEnd.Value.ToShortDateString() + " 23:59:59";
            this.QueryData( Begin, End);
        }

        /// <summary>
        /// 根据预约状态和时间查找数据
        /// </summary>
        /// <param name="PrepayinState"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private void QueryData( string begin, string end)
        {
            this.dtPrepayIn.Clear();
            try
            {
                ArrayList arrPrein = new ArrayList();
                
                //arrPrein = this.myInpatient.GetPreInPatientInfoByDateAndState(this.PrepayinState, begin, end);
                arrPrein = this.managerIntegrate.QueryPreInPatientInfoByDateAndState(this.PrepayinState, begin, end);
                string strName = "", strStateName = "";
                if (arrPrein == null)
                    return;
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo obj in arrPrein)
                {
                    #region　取性别名称
                    switch (obj.Sex.ID.ToString())
                    {
                        case "U":
                            strName = "未知";
                            break;
                        case "M":
                            strName = "男";
                            break;
                        case "F":
                            strName = "女";
                            break;
                        case "O":
                            strName = "其它";
                            break;
                        default:
                            break;
                    }
                    #endregion

                    #region 登记状态
                    switch (obj.User02.ToString())
                    {
                        case "0":
                            strStateName = "预约登记";
                            break;
                        case "1":
                            strStateName = "取消预约登记";
                            break;
                        case "2":
                            strStateName = "预约转住院";
                            break;
                        default:
                            break;
                    }
                    #endregion

                    #region 取合同单位、操作员名称
                    obj.Pact.Name = this.myObjHelper.GetName(obj.Pact.ID);
                    string strOperID = obj.User03.Substring(0, 6);
                    string strOperName = this.operObjHelper.GetName(strOperID);
                    #endregion

                    #region 向DataTable插入数据
                    DataRow row = this.dtPrepayIn.NewRow();
                    row["发生序号"] = obj.User01;
                    row["病历号"] = obj.PID.CardNO;
                    row["患者姓名"] = obj.Name;
                    row["性别"] = strName;
                    row["合同单位"] = obj.Pact.Name;//需转换
                    row["住院科室"] = obj.PVisit.PatientLocation.Dept.Name;
                    row["预约日期"] = obj.PVisit.InTime;//.Date_In;
                    row["当前状态"] = strStateName;//需转换
                    row["家庭地址"] = obj.AddressHome;
                    row["家庭电话"] = obj.PhoneHome;
                    row["联系人"] = obj.Kin.ID;
                    row["联系人电话"] = obj.Kin.Memo;
                    row["联系人地址"] = obj.Kin.User01;
                    row["操作员"] = strOperName;
                    row["操作时间"] = obj.User03.Substring(6, 10);

                    this.dtPrepayIn.Rows.Add(row);
                    #endregion

                    
                }

                dvPrepayIn = new DataView(this.dtPrepayIn);
                this.fpMainInfo_Sheet1.DataSource = this.dvPrepayIn;
                this.initFp();

            }
            catch { }
        }

        /// <summary>
        /// 控制fp宽度
        /// </summary>
        private void initFp()
        {
            try
            {
                int im = 3;
                this.fpMainInfo_Sheet1.OperationMode = (FarPoint.Win.Spread.OperationMode)im;
                this.fpMainInfo_Sheet1.Columns.Get(0).Width = 0F;
                this.fpMainInfo_Sheet1.Columns.Get(1).Width = 80F;
                this.fpMainInfo_Sheet1.Columns.Get(2).Width = 72F;
                this.fpMainInfo_Sheet1.Columns.Get(3).Width = 48F;
                this.fpMainInfo_Sheet1.Columns.Get(5).Width = 88F;
                this.fpMainInfo_Sheet1.Columns.Get(6).Width = 100F;
                this.fpMainInfo_Sheet1.Columns.Get(9).Width = 95F;
                this.fpMainInfo_Sheet1.Columns.Get(10).Width = 102F;
                this.fpMainInfo_Sheet1.Columns.Get(11).Width = 127F;
                this.fpMainInfo_Sheet1.Columns.Get(12).Width = 85F;
                //			this.fpMainInfo_Sheet1.Columns.Get(13).Width = 80F;
                this.fpMainInfo_Sheet1.Columns.Get(14).Width = 85F;
            }
            catch { }
        }

        /// <summary>
        /// 根据发生序号获得实体
        /// </summary>
        /// <param name="strNo"></param>
        /// <param name="strCardNo"></param>
        private void setPatient(string strNo, string strCardNo)
        {
            this.myPatientInfo = this.managerIntegrate.QueryPreInPatientInfoByCardNO(strNo, strCardNo);// this.myInpatient.GetPreInPatientInfoByCardNO(strNo, strCardNo);
            //this.myPatientInfo.InTimes = this.PatientInfo.InTimes + 1;
        }

        private void GetPrePayData()
        {
            try
            {
                if (this.fpMainInfo_Sheet1.Rows.Count == 0) return;
                int iRow = this.fpMainInfo_Sheet1.ActiveRowIndex;
                //获取发生序号
                string strNo = this.fpMainInfo_Sheet1.Cells[iRow, 0].Text.Trim();
                string strCardNo = this.fpMainInfo_Sheet1.Cells[iRow, 1].Text.Trim();
                //获得预约登记实体返回给属性
                this.setPatient(strNo, strCardNo);
                this.FindForm().DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("选取预约患者失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion 

        #region 事件
        private void ucPrepayInQuery_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.InitQuery();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.QueryData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.GetPrePayData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().DialogResult = DialogResult.Cancel;
        }

        private void fpMainInfo_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.GetPrePayData();
        }

        #endregion

        /// <summary>
        /// {CF4B08C1-0EC8-4f6a-A9DC-F1E9E3B9690F}门诊号过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTxtFilter_TextChanged(object sender, EventArgs e)
        {
            string carNo = this.neuTxtFilter.Text.Trim();
            string filter = "病历号 like '%" + carNo + "%'";
            if (carNo == string.Empty)
            {
                this.dvPrepayIn.RowFilter = "";
            }
            else
            {
                this.dvPrepayIn.RowFilter = filter;
            }
            this.initFp();
        }

    }
}
