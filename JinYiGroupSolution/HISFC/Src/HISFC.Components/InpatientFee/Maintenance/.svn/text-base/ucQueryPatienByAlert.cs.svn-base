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
    /// <summary>
    /// 在院患者欠费查询控件
    /// </summary>
    public partial class ucQueryPatienByAlert : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQueryPatienByAlert()
        {
            InitializeComponent();
        }
                
        #region 变量

        /// <summary>
        /// RADT业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// Manager业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 患者表
        /// </summary>
        DataTable dtPatient = new DataTable();
        DataView dvPatient = new DataView();
        //
        //护士站代码
        string nurseCell = string.Empty;
        //
        //科室数组
        ArrayList alDept = new ArrayList();

        #endregion

        #region 属性

        /// <summary>
        /// 护士站代码
        /// </summary>
        public string NurseCellCode
        {
            get 
            {
                return nurseCell;
            }
            set
            {
                nurseCell = value;
            }
        }

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <param name="nurseCode"></param>
        /// <returns></returns>
        private ArrayList GetDept(string nurseCode)
        {
            alDept = this.manager.QueryDepartment(nurseCode);
            return alDept;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件
        /// </summary>
        protected virtual void InitControl()
        {
            this.txtMoney.Visible = false;
        }

        /// <summary>
        /// 初始化表
        /// </summary>
        protected virtual void InitDataTable()
        {
            this.dtPatient.Columns.AddRange(new DataColumn []
            {
                new DataColumn ("住院号",typeof(string)),
                new DataColumn ("科室",typeof(string)),
                new DataColumn ("床号",typeof(string)),
                new DataColumn ("姓名",typeof(string)),
                new DataColumn ("合同单位",typeof(string)),
                new DataColumn ("未结预交金",typeof(decimal)),
                new DataColumn ("未结总金额",typeof(decimal)),
                new DataColumn ("余额",typeof(decimal)),
                new DataColumn ("警戒线",typeof(decimal))
                //new DataColumn ("",typeof()),
            });
            this.dvPatient = new DataView(this.dtPatient);
            this.fpPatient_Sheet1.DataSource = this.dvPatient;
        }

        /// <summary>
        /// 向表格中插入数据
        /// </summary>
        /// <param name="patInfo"></param>
        /// <param name="limit"></param>
        protected virtual void InsertData(Neusoft.HISFC.Models.RADT.PatientInfo patInfo,decimal limit)
        {
            if (patInfo.FT.LeftCost < limit)
            {
                DataRow row = this.dtPatient.NewRow();
                row["住院号"] = patInfo.PID.PatientNO;
                row["科室"] = patInfo.PVisit.PatientLocation.Dept.Name;
                row["床号"] = patInfo.PVisit.PatientLocation.Bed.ID;
                row["姓名"] = patInfo.Name;
                row["合同单位"] = patInfo.Pact.Name;
                row["未结预交金"] = patInfo.FT.PrepayCost;
                row["未结总金额"] = patInfo.FT.TotCost;
                row["余额"] = patInfo.FT.LeftCost;
                row["警戒线"] = patInfo.PVisit.MoneyAlert;
                this.dtPatient.Rows.Add(row);
            }
        }

        /// <summary>
        /// 按护士站查询
        /// </summary>
        protected virtual void QueryByNurse()
        {
            this.dtPatient.Clear();
            alDept = this.GetDept(this.nurseCell);
            
            foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
            {
                ArrayList alPat = this.radtManager.QueryPatient(dept.ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in alPat)
                {
                    decimal limit = 0;
                    if (this.rdoAlert.Checked)
                    {
                        limit = patientInfo.PVisit.MoneyAlert;
                    }
                    if (this.rdoMoneyLevel.Checked)
                    {
                        limit = Convert.ToDecimal(this.txtMoney.Text.Trim());
                    }
                    this.InsertData(patientInfo, limit);
                }
            }
            this.dtPatient.AcceptChanges();
        }

        #endregion
                
        #region 共有方法

        #endregion

        #region 事件

        private void ucQueryPatienByAlert_Load(object sender, EventArgs e)
        {
            this.InitControl();
            this.InitDataTable();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.QueryByNurse();
        }

        private void rdoAlert_CheckedChanged(object sender, EventArgs e)
        {
            this.txtMoney.Visible = !this.rdoAlert.Checked;
            
        }

        private void rdoMoneyLevel_CheckedChanged(object sender, EventArgs e)
        {
            this.txtMoney.Visible = this.rdoMoneyLevel.Checked;
        }
               
        #endregion
                
    }
}

