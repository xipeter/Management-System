using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class frmSetFeeAlert : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmSetFeeAlert()
        {
            InitializeComponent();
        }
        #region
        //传入类型
        private int level;
        private bool isAll = true;
        private Neusoft.FrameWork.Models.NeuObject nurseCellObject = null;
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
        private Neusoft.FrameWork.Models.NeuObject myObject = null;
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.Models.Base.EnumAlertTypeService alerTypeService = new Neusoft.HISFC.Models.Base.EnumAlertTypeService();
        Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        #region {DB3B44F0-B049-4644-B599-82456C9CFC31}
        Neusoft.HISFC.BizProcess.Integrate.Manager constantManager =new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.FrameWork.Models.NeuObject contantObject = null;
        private Neusoft.FrameWork.Models.NeuObject operObject = Neusoft.FrameWork.Management.Connection.Operator;

        Neusoft.HISFC.BizProcess.Integrate.Function intgrFunction = new Neusoft.HISFC.BizProcess.Integrate.Function();
        //是否允许设置金额警戒线
        private bool isallowset = false;
        #endregion

        #endregion


        #region 属性
        /// <summary>
        /// 传人的层次0：全院1：病区：2科室：3个人
        /// </summary>
        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }
        [Category("控件设置"), Description("是否允许按照金额设置警戒线"),DefaultValue(false)]
        public bool AllowSet
        {
            get { return this.isallowset; }
            set { isallowset = value; }
        }
        /// <summary>
        /// 科室或者病区编码
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return this.patientInfo;
            }
            set
            {
                this.patientInfo = value;
            }
        }

        /// <summary>
        /// 传入实体
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject MyObject
        {
            get
            {
                return this.myObject;
            }
            set
            {
                this.myObject = value;
            }
        }

        
        /// <summary>
        /// 判断是住院处用还是护士站用 true 全院设置 false 本科室设置
        /// </summary>
        public bool IsAll
        {
            set
            {
                this.isAll = value;
            }
            get
            {
                return this.isAll;
            }
        }

        /// <summary>
        /// 护士站信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseCellObject
        {
            set
            {
                this.nurseCellObject = value;
            }
            get
            {
                return this.nurseCellObject;
            }
        }


        //可设置警戒线天数
        int alterDay = 1;

        public int AlterDay
        {
            get { return  alterDay; }
            set { alterDay = value; }
        }
       
        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
            this.cmbType.AddItems(Neusoft.HISFC.Models.Base.EnumAlertTypeService.List());
            if (this.cmbType.alItems.Count > 0)
            {
                this.cmbType.Tag = "M";
            }
            DateTime now = inpatientManager.GetDateTimeFromSysDateTime();
            this.dtBegin.Value = now;
            this.dtEnd.Value = now;
           
            #region {DB3B44F0-B049-4644-B599-82456C9CFC31}
            contantObject = this.constantManager.GetConstant("ALERTPERSON", operObject.ID);
            if (contantObject == null || string.IsNullOrEmpty(contantObject.Memo.Trim()))
            {
               alterDay=1; 
            }
            else
            {
              try 
              {
                  alterDay = Convert.ToInt16(  contantObject.Memo.Trim());
              }
              catch(Exception e)
              {
                 MessageBox.Show("常数维护中,警戒线天数不正确！"+e.Message);
              }            
            }

          #endregion 
            switch (this.Level)
            {
                case 0://全员设置
                    {
                        this.lblTip.Text = this.MyObject.Name.ToString();
                        this.cmbUnit.Visible = false;
                        break;
                    }
                case 1://病区设置
                    {
                        this.lblTip.Text = this.MyObject.Name.ToString();
                        this.cmbUnit.Visible = false;
                        break;

                    }
                case 2://科室设置
                    {
                        this.lblTip.Text = this.MyObject.Name.ToString();
                        this.cmbUnit.Visible = false;
                        break;
                    }
                case 3://单人设置
                    {
                        this.lblTip.Text = this.PatientInfo.Name.ToString();
                        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
                        this.cmbType.Tag = this.patientInfo.PVisit.AlertType.ID;
                        this.ntbAlert.Text = this.patientInfo.PVisit.MoneyAlert.ToString();
                        if (this.patientInfo.PVisit.BeginDate != DateTime.MinValue)
                        {
                            this.dtBegin.Value = this.patientInfo.PVisit.BeginDate;
                        }
                        else
                        {
                            this.dtBegin.Value = inpatientManager.GetDateTimeFromSysDateTime();
                        }
                        if (this.patientInfo.PVisit.EndDate != DateTime.MinValue)
                        {
                            this.dtEnd.Value = this.patientInfo.PVisit.EndDate;

                            if (alterDay < 2)
                            {
                                this.dtEnd.MaxDate = this.dtEnd.Value;                            
                            }
                        }
                        else
                        {
                            this.dtEnd.Value = inpatientManager.GetDateTimeFromSysDateTime();
                        }
                        this.cmbUnit.Visible = false;
                        break;
                    }
                case 4:
                    {
                        this.cmbUnit.Visible = true;
                        lbInfo.Text = "合同单位";
                        this.InitPact();
                        break;
                    }
            }
            
            return 1;
        }
        private int InitPact()
        {
            ArrayList alPact = new ArrayList();
            alPact = managerIntegrate.QueryPactUnitAll();
            this.cmbUnit.AddItems(alPact);
            return 1;
        }
        private int Valid()
        {
            string type = this.cmbType.Tag.ToString();
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("请选择警戒线的设置类别！");
                this.cmbType.Focus();
                return -1;
            }
            //按金额设置
            if (type == "M")
            {
                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntbAlert.Text.Trim()) > 9999999)
                {
                    MessageBox.Show("金额不能大于9999999元");
                    this.ntbAlert.Focus();
                    this.ntbAlert.SelectAll();
                    return -1;
                }
            }

            //按时间段设置
            if (type == "D")
            {
                if (dtBegin.Value.Date > dtEnd.Value.Date)
                {
                    MessageBox.Show("开始时间不能大于终止时间！");
                    this.dtBegin.Focus();
                    return -1;
                }
            }
            

            if (this.Level == 4)
            {
                if (this.cmbUnit.Tag == null || this.cmbUnit.Tag.ToString() == "")
                {
                    MessageBox.Show("请选择合同单位");
                    this.cmbUnit.Focus();
                    return -1;
                }
            }
            return 1;
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 根据合同单位更新警戒线
        /// </summary>
        /// <param name="pactID"></param>
        /// <returns></returns>
        private int UpdateByPactID(string pactID, decimal alertMoney,string alertType,DateTime beginDate,DateTime endDate)
        {
            int result = radtIntegrate.UpdatePatientAlertByPactID(pactID, alertMoney,alertType,beginDate,endDate);
            return result;
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 根据护士站更新警戒线
        /// </summary>
        /// <param name="nurseCellID"></param>
        /// <returns></returns>
        private int UpdateByNurseCellID(string nurseCellID, decimal alertMoney, string alertType, DateTime beginDate, DateTime endDate)
        {
            int result = radtIntegrate.UpdatePatientAlertByNurseCellID(nurseCellID, alertMoney, alertType, beginDate, endDate);
            return result;
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 根据护士站科室更新警戒线
        /// </summary>
        /// <param name="nurseCellID"></param>
        /// <param name="alertMoney"></param>
        /// <param name="radtIntegrade"></param>
        /// <returns></returns>
        private int UpdateByNurseCellIDAndDept(string nurseCellID, string deptCode, decimal alertMoney, string alertType, DateTime beginDate, DateTime endDate)
        {
            int result = radtIntegrate.UpdatePatientAlertByNurseCellIDAndDept(nurseCellID, deptCode, alertMoney, alertType, beginDate, endDate);
            return result;
        }
        
        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 根据科室更新警戒线
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        private int UpdateByDeptID(string deptID, decimal alertMoney, string alertType, DateTime beginDate, DateTime endDate)
        {

            int result = radtIntegrate.UpdatePatientAlertByDeptID(deptID, alertMoney, alertType, beginDate, endDate);
            return result;
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新所有患者
        /// </summary>
        /// <returns></returns>
        private int UpdateAllPatient(decimal alertMoney, string alertType, DateTime beginDate, DateTime endDate)
        {
            int result = radtIntegrate.UpdatePatientAlertAll(alertMoney,alertType,beginDate,endDate);
            return result;
        }
        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新单个患者
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="alertMoney"></param>
        /// <param name="radtIntegrade"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private int UpdatePatient(string inpatientNo, decimal alertMoney, string alertType, DateTime beginDate, DateTime endDate)
        {
            int result = radtIntegrate.UpdatePatientAlert(inpatientNo, alertMoney, alertType, beginDate, endDate);

            #region {DB3B44F0-B049-4644-B599-82456C9CFC31}
            Neusoft.HISFC.Models.RADT.PVisit myPv = this.patientInfo.PVisit.Clone();
            myPv.AlertType.ID = alertType;
            myPv.MoneyAlert = alertMoney;
            myPv.BeginDate = beginDate;
            myPv.EndDate = endDate;

            intgrFunction.SaveChange<Neusoft.HISFC.Models.RADT.PVisit>(false,false,this.patientInfo.ID,this.patientInfo.PVisit,myPv);
            #endregion

            return result;
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新警戒线
        /// </summary>
        /// <param name="type">0：不按合同单位模式 1：按合同单位模式</param>
        /// <param name="chooseType">0：全院1：病区患者2：科室患者3:单个患者4:合同单位</param>
        /// <returns></returns>
        protected int Update(string type, decimal alertMoney,string alertType,DateTime beginDate,DateTime endDate)
        {
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
           
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int retureValue = 0;
            if (IsAll == true)  //设置全院
            {
                switch (type)
                {
                    case "0"://
                        {
                            retureValue = this.UpdateAllPatient(alertMoney, alertType, beginDate, endDate);
                            break;
                        }
                    case "1"://
                        {
                            retureValue = this.UpdateByNurseCellID(this.myObject.ID.ToString(), alertMoney, alertType, beginDate, endDate);
                            break;
                        }
                    case "2"://
                        {
                            retureValue = this.UpdateByNurseCellIDAndDept(this.NurseCellObject.ID, this.myObject.ID.ToString(), alertMoney, alertType, beginDate, endDate);
                            break;
                        }
                    case "3"://
                        {
                            retureValue = this.UpdatePatient(this.PatientInfo.ID, alertMoney, alertType, beginDate, endDate);
                            break;
                        }
                    case "4":
                        {
                            retureValue = this.UpdateByPactID(this.cmbUnit.SelectedItem.ID, alertMoney, alertType, beginDate, endDate);
                            break;
                        }


                    default:
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case "0"://
                        {
                            break;
                        }
                    case "1"://
                        {
                            //retureValue = this.UpdateByNurseCellID(this.myObject.ID.ToString(), alertMoney, radtIntegrate);
                            retureValue = this.UpdateByNurseCellIDAndDept(this.NurseCellObject.ID, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID, alertMoney, alertType, beginDate, endDate);
                            break;
                        }
                    case "2"://
                        {
                            retureValue = this.UpdateByNurseCellIDAndDept(this.NurseCellObject.ID, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID, alertMoney, alertType, beginDate, endDate);
                            break;
                        }
                    case "3"://
                        {
                            retureValue = this.UpdatePatient(this.PatientInfo.ID, alertMoney, alertType, beginDate, endDate);
                            break;
                        }
                    case "4":
                        {
                            retureValue = this.UpdateByPactID((this.cmbUnit.Tag as Neusoft.FrameWork.Models.NeuObject).ID, alertMoney, alertType, beginDate, endDate);
                            break;
                        }


                    default:
                        break;
                }

            }

            if (retureValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("警戒线设置失败" + Neusoft.FrameWork.Management.PublicTrans.Err);
                return -1;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("警戒线设置成功");
            }

            return 1;
        }

        #endregion

        #region 事件

        private void frmSetFeeAlert_Load(object sender, EventArgs e)
        {
            this.Init();
            #region 非普通收款员可以连续欠费记帐 modified by xizf 20110325
            if (AlterDay < 2)
            {
                this.dtEnd.MaxDate = this.dtBegin.Value.AddDays(alterDay);
                this.dtEnd.Value = this.dtEnd.MaxDate;
            }
            else {
                if (this.patientInfo.PVisit.EndDate == DateTime.MinValue)
                {
                    this.dtEnd.MaxDate = this.dtBegin.Value.AddDays(alterDay);
                }
                else {
                    this.dtEnd.MaxDate = this.patientInfo.PVisit.EndDate.AddDays(alterDay);
                }
                
            }
            #endregion
            if (cmbUnit.Visible)
            {
                this.ActiveControl = this.cmbUnit;
            }
            else
            {
                this.ActiveControl = this.ntbAlert;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            //警戒线
            decimal alertMoney = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntbAlert.Text.Trim());
            //校验数据
            if (this.Valid() < 0)
            {
                return;
            }
            //根据级别设置警戒线

            string alertType  = this.cmbType.Tag.ToString();
            DateTime beginDate = this.dtBegin.Value;
            DateTime endDate = this.dtEnd.Value;
            //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
            if (this.Update(this.Level.ToString(), alertMoney, alertType,beginDate,endDate) < 0)
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        private void ntbAlert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.btnOK_Click(new object(), new EventArgs());
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
            if (this.cmbType.Tag.ToString() == "M")
            {
                this.gbDate.Enabled = false;
                this.gbMoney.Enabled = this.AllowSet;
                this.ntbAlert.Focus();
            }
            else
            {
                this.gbMoney.Enabled = false;
                this.gbDate.Enabled = true;
                this.dtBegin.Focus();
            }
        }
    }

}