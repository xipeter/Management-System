using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Finance.FinIpb
{
    /// <summary>
    /// 出院病人费用汇总（在院+出院）
    /// </summary>
    public partial class ucFinIpbStatFee : Neusoft.HISFC.Components.Common.Report.ucCrossQueryBaseForFarPoint
    {
        public ucFinIpbStatFee()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 统计大类编码
        /// </summary>
        private string reportCode = "ZY01";//默认显示为住院收费发票大类
        /// <summary>
        /// 统计大类名称
        /// </summary>
        private string reportName = string.Empty;
        /// <summary>
        /// 用于存储统计大类list
        /// </summary>
        private List<string> feeStatList = new List<string>();
        /// <summary>
        /// 用于存储拆分好的费用大类字符串
        /// </summary>
        private string feeStatStr = string.Empty;
        /// <summary>
        /// 常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant conManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
        /// <summary>
        /// 医院名称
        /// </summary>
        private string hospitalName = string.Empty;
        #endregion

        #region 方法

        protected override int OnQuery(object sender, object neuObject)
        {
            string[] feeStatStr = this.feeStatList.ToArray();
            if (string.IsNullOrEmpty(reportCode))
            {
                MessageBox.Show("请选择统计大类！");
                return -1;
            }

            if (comDept.Text == "按患者所在科室查询")
            {
                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinIpb.ucFinIpbStatFeeInhosDept";
                //this.DataCrossValues = "2";
                //this.DataCrossColumns = "1";
                //this.DataCrossRows = "0";


            }
            if (comDept.Text == "按医生所在科室查询")
            {
                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinIpb.ucFinIpbStatFeeDOCDept";
                //this.DataCrossValues = "2";
                //this.DataCrossColumns = "1";
                //this.DataCrossRows = "0";
            }
            if (comDept.Text == "按执行科室查询")
            {

                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinIpb.ucFinIpbStatFeeEXEDept";
                //this.DataCrossValues = "2";
                //this.DataCrossColumns = "1";
                //this.DataCrossRows = "0";
            }

            //this.QuerySqlTypeValue = QuerySqlType.id;
            //this.QuerySql = "WinForms.Report.Finance.FinOpb.ucFinOpbStatFeeDoct";
            this.DataCrossValues = "2";
            this.DataCrossRows = "0";
            this.DataCrossColumns = "1";
            this.DataBeginRowIndex = 5;
            QueryParams.Clear();
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", this.dtpBeginTime.Value.ToShortDateString()+" 00:00:00", ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", this.dtpEndTime.Value.ToShortDateString()+" 23:59:59", ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", reportCode, ""));
            string feeStr = string.Empty;
            if (this.feeStatList != null)
            {
                if (this.feeStatList.Count != 0)
                {
                    foreach (string str in feeStatList)
                    {
                        feeStr = feeStr+"'" + str + "',";
                    }
                    feeStr = feeStr.Substring(0, feeStr.Length - 1);
                }
            }
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", feeStr, ""));



            Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();

            employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;
            hospitalName = this.conManager.GetHospitalName();

            this.neuSpread1_Sheet1.SetText(3, 0, "统计日期：" + this.dtpBeginTime.Value.ToShortDateString()+" 00:00:00" + "---" + this.dtpEndTime.Value.ToShortDateString()+" 23:59:59");
            this.neuSpread1_Sheet1.Cells[3, 0].ColumnSpan = 10;
            this.neuSpread1_Sheet1.SetText(4, 0, "制表人：" + employee.Name);
            this.neuSpread1_Sheet1.Cells[4, 0].ColumnSpan = 6;
            this.neuSpread1_Sheet1.SetText(4, 6, "打印日期：" + System.DateTime.Now.ToString());
            this.neuSpread1_Sheet1.Cells.Get(4, 6).ColumnSpan = 6;
            this.neuSpread1_Sheet1.SetText(0, 0, hospitalName);
            this.neuSpread1_Sheet1.Cells.Get(0, 0).Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Cells[0, 0].ColumnSpan = 10;
            this.neuSpread1_Sheet1.SetText(1, 0, "住院收入统计汇总表（在院+出院）");
            this.neuSpread1_Sheet1.Cells[1, 0].ColumnSpan = 10;
            this.neuSpread1_Sheet1.Cells.Get(1, 0).Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            neuSpread1.Sheets[0].FrozenRowCount = 6;
            return base.OnQuery(sender, neuObject);
        }
        #endregion

        #region 事件
        /// <summary>
        /// 统计大类选择按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFeeSelect_Click(object sender, EventArgs e)
        {
            Neusoft.WinForms.Report.Finance.FinIpb.ucFeeStatSelect feeStatSelect = new Neusoft.WinForms.Report.Finance.FinIpb.ucFeeStatSelect();
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "项目选择";
            DialogResult r = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(feeStatSelect);
            if (r == DialogResult.Cancel)
            {
                return;
            }
            this.reportCode = string.Empty;
            this.feeStatList = new List<string>();
            if (!string.IsNullOrEmpty(feeStatSelect.ReportCodeStr))
            {
                this.reportCode = feeStatSelect.ReportCodeStr;
                this.lblMemo.Text = "您当前选择是统计类型是:[" + conManager.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.FEECODESTAT, feeStatSelect.ReportCodeStr.ToString()) + "]";
            }
            else
            {
                this.reportCode = "ZY01";
            }
            if (feeStatSelect.FeeStatList != null)
            {
                this.feeStatList = feeStatSelect.FeeStatList;
            }        

        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        DeptZone deptZone1 = DeptZone.ALL_DEPT;

        #region 枚举
        public enum DeptZone
        {
            INHOS_DEPT = 0,
            DOC_DEPT = 1,
            EXE_DEPT = 2,
            ALL_DEPT = 3,
        }
        #endregion



        #region 属性
        [Category("控制设置"), Description("查询范围：ALL_DEPT：全部、INHOS_DEPT：按患者所在科室查询、DOC_DEPT：按医生所在科室查询、EXE_DEPT：按执行科室查询")]
        public DeptZone DeptZone1
        {
            get
            {
                return deptZone1;
            }
            set
            {
                deptZone1 = value;
            }
        }
        #endregion

        #region 初始化


        Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeCodeStatMger = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();
        private void ucFinOpbStatFeeDoct_Load(object sender, EventArgs e)
        {

            ///查询条件

            comDept.ClearItems();
            if (deptZone1 == DeptZone.ALL_DEPT)
            {
                comDept.Items.Add("按患者所在科室查询");
                comDept.Items.Add("按医生所在科室查询");
                comDept.Items.Add("按执行科室查询");

            }
            if (deptZone1 == DeptZone.DOC_DEPT)
            {
                comDept.Items.Add("按医生所在科室查询");
                comDept.Enabled = false;
            }
            if (deptZone1 == DeptZone.EXE_DEPT)
            {
                comDept.Items.Add("按执行科室查询");
                comDept.Enabled = false;
            }
            if (deptZone1 == DeptZone.INHOS_DEPT)
            {
                comDept.Items.Add("按患者所在科室查询");
                comDept.Enabled = false;
            }
            if (comDept.Items.Count >= 0)
            {
                comDept.SelectedIndex = 0;
            }

            
            System.Collections.ArrayList feelist = new System.Collections.ArrayList();
          
            feelist = feeCodeStatMger.QueryFeeCodeStatByReportCode("ZY01");//默认是门诊自费发票
            System.Collections.Hashtable feeStatHash = new System.Collections.Hashtable();
            System.Collections.ArrayList arryFeeStat = new System.Collections.ArrayList();
            foreach (Neusoft.HISFC.Models.Fee.FeeCodeStat feeStatObj in feelist)
            {
                if (!feeStatHash.ContainsKey(feeStatObj.StatCate.ID))//将统计大类编码作为哈希表主键
                {
                    feeStatHash.Add(feeStatObj.StatCate.ID, feeStatObj.StatCate.Name);
                    arryFeeStat.Add(feeStatObj);//将不重复的统计大类实体添加到ArrayList中
                }
            }
            foreach (Neusoft.HISFC.Models.Fee.FeeCodeStat feeObj in arryFeeStat)
            {
                this.feeStatList.Add(feeObj.StatCate.ID);
            }

        }
        #endregion
        #endregion 

    }
}
