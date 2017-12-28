using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    /// <summary>
    /// [功能描述: 门诊工作量查询]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-03]<br></br>
    /// <修改记录 
    ///		 待实现 权限系统完善
    ///  />
    /// </summary>
    public partial class ucMzOutWorkQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMzOutWorkQuery()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 药房数组
        /// </summary>
        ArrayList deptData = new ArrayList();

        /// <summary>
        /// 人员数组
        /// </summary>
        ArrayList personData = new ArrayList();

        /// <summary>
        /// 是否进行配药工作量查询
        /// </summary>
        private bool isDrugTerminalQuery = true;

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = null;

        /// <summary>
        /// 权限人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper = null;

        #endregion

        #region 属性

        /// <summary>
        /// 是否进行配药工作量查询
        /// </summary>
        [Description("是否进行配药工作量查询"), Category("设置"), DefaultValue(true)]
        public bool IsDrugTerminalQuery
        {
            get
            {
                return this.isDrugTerminalQuery;
            }
            set
            {
                this.isDrugTerminalQuery = value;

                this.SetParm();
            }
        }

        /// <summary>
        /// 是否按药房查询
        /// </summary>
        public bool DrugDeptQuery
        {
            set
            {
                this.rbTerminalShow.Visible = value;
                this.rbOperShow.Visible = value;
            }
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryData();

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            this.Export();

            return base.Export(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        private int Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载查询数据 请稍候");
            Application.DoEvents();
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

            DateTime sysTime = deptManager.GetDateTimeFromSysDateTime();

            this.dtBegin.Value = sysTime.Date.AddDays(-1);
            this.dtEnd.Value = sysTime;

            ArrayList al = deptManager.GetDeptmentAll();
            if (al == null)
            {
               Function.ShowMsg("加载科室列表失败" + deptManager.Err);
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Base.Department info in al)
            {
                if (info.DeptType.ID.ToString() == "P")
                    this.deptData.Add(info);
            }

            this.personData = personManager.GetEmployeeAll();
            if (this.personData == null)
            {
                Function.ShowMsg("加载人员列表失败" + personManager.Err);
                return -1;
            }

            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)deptManager.Operator).Dept;
            this.privOper = deptManager.Operator;

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        /// <summary>
        /// 根据参数进行不同设置
        /// </summary>
        protected void SetParm()
        {
            if (this.isDrugTerminalQuery)
                this.lbReportTitle.Text = "配药工作量统计";
            else
                this.lbReportTitle.Text = "发药工作量统计";
        }

        /// <summary>
        /// 获取Sql索引
        /// </summary>
        /// <returns></returns>
        protected string GetSqlIndex()
        {
            string sqlIndex = "";
            if (this.rbDept.Checked)		//药房查询
            {
                if (this.isDrugTerminalQuery)		//配药工作量查询
                {
                    if (this.rbTerminalShow.Checked)
                        sqlIndex = "Pharmacy.Item.ClinicQuery.Druged.DrugDept.Terminal";
                    else
                        sqlIndex = "Pharmacy.Item.ClinicQuery.Druged.DrugDept.Oper";
                }
                else
                {
                    if (this.rbTerminalShow.Checked)
                        sqlIndex = "Pharmacy.Item.ClinicQuery.Send.DrugDept.Terminal";
                    else
                        sqlIndex = "Pharmacy.Item.ClinicQuery.Send.DrugDept.Oper";
                }
            }
            if (this.rbPerson.Checked)		//人员查询
            {
                if (this.isDrugTerminalQuery)		//配药工作量查询
                    sqlIndex = "Pharmacy.Item.ClinicQuery.Druged.Person";
                else
                    sqlIndex = "Pharmacy.Item.ClinicQuery.Send.Person";
            }
            return sqlIndex;
        }

        /// <summary>
        /// 判断是否对查询条件已选择完整
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsValid()
        {
            if (this.cmbData.Tag == null)
            {
                MessageBox.Show(Language.Msg("请选择查询科室或人员"));
                return false;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text) >= Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text))
            {
                MessageBox.Show(Language.Msg("查询 开始时间应大于终止时间"));
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 数据检索
        /// </summary>
        protected void QueryData()
        {
            if (!this.IsValid())
            {
                return;
            }

            this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet1;
            if (this.neuSpread1.Sheets.Contains(this.neuSpread1_Sheet2))
            {
                this.neuSpread1.Sheets.Remove(this.neuSpread1_Sheet2);
            }


            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
            string sqlIndex = this.GetSqlIndex();
            string sql = "";
            dataManager.Sql.GetSql(sqlIndex, ref sql);
            sql = string.Format(sql, this.cmbData.Tag.ToString(), Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text).ToString(), Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text).ToString());
            DataSet ds = new DataSet();
            if (dataManager.ExecQuery(sql, ref ds) == -1)
            {
                MessageBox.Show(Language.Msg("工作量查询出错 \n" + dataManager.Err));
                return;
            }

            this.neuSpread1_Sheet1.Rows.Count = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.DataSource = ds;
            }

            try
            {
                if (this.rbPerson.Checked)
                {
                    this.Sum(2, 3, 4, 5);
                }
                else
                {
                    if (this.rbTerminalShow.Checked)
                    {
                        this.Sum(1, 2, 3, 4);
                    }
                    else
                    {
                        this.Sum(2, 3, 4, 5);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 明细查询
        /// </summary>
        /// <param name="operCode">欲查询人员编码</param>
        protected void QueryDetail(string operCode)
        {
            this.neuSpread1_Sheet2.Rows.Count = 0;

            DateTime beginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text);
            DateTime endTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text);

            DateTime queryBeginDate = beginTime;
            DateTime queryEndDate = System.DateTime.MinValue;

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            string sqlIndex = "";
            if (this.isDrugTerminalQuery)
                sqlIndex = "Pharmacy.Item.ClinicQuery.Druged.Oper.Detail";
            else
                sqlIndex = "Pharmacy.Item.ClinicQuery.Send.Oper.Detail";

            string sql = "";
            if (dataManager.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                MessageBox.Show(Language.Msg("根据索引获取Sql语句出错 \n" + dataManager.Err));
                return;
            }

            DataSet dsDetail = null;

            string formatSql = "";

            while (queryEndDate < endTime)
            {
                queryEndDate = queryBeginDate.Date.AddDays(1);
                if (queryEndDate > endTime)
                {
                    queryEndDate = endTime;
                }

                formatSql = string.Format(sql, operCode, queryBeginDate, queryEndDate,this.cmbData.Tag.ToString());
                DataSet ds = new DataSet();
                if (dataManager.ExecQuery(formatSql, ref ds) == -1)
                {
                    MessageBox.Show(Language.Msg("工作量查询出错 \n" + dataManager.Err));
                    return;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (dsDetail == null)
                    {
                        dsDetail = ds.Clone();
                    }

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dsDetail.Tables[0].Rows.Add(new object[] {
																	dr[0],
																	dr[1],
																	dr[2],
																	dr[3],
																	dr[4],
																	dr[5],
																	dr[6]
																 });
                    }
                }
                queryBeginDate = queryEndDate;
            }

            if (dsDetail != null && dsDetail.Tables.Count > 0 && dsDetail.Tables[0].Rows.Count > 0)
            {
                this.neuSpread1_Sheet2.DataSource = dsDetail;
            }
            if (this.neuSpread1.Sheets.Contains(this.neuSpread1_Sheet2))
            {
                this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet2;
            }
        }

        /// <summary>
        /// 增加合计
        /// </summary>
        /// <param name="countColumns">需累加的列</param>
        protected void Sum(params int[] countColumns)
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return;

            int iIndex = this.neuSpread1_Sheet1.Rows.Count;
            this.neuSpread1_Sheet1.Rows.Add(iIndex, 1);
            this.neuSpread1_Sheet1.Cells[iIndex, 0].Text = "合计：";

            for (int j = 0; j < countColumns.Length; j++)
            {
                this.neuSpread1_Sheet1.Cells[iIndex, countColumns[j]].Formula = "SUM(" + (char)(65 + countColumns[j]) + "1:" + (char)(65 + countColumns[j]) + iIndex.ToString() + ")";
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void Export()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!Neusoft.HISFC.Components.Common.Classes.Function.ChoosePiv("0300"))
                {
                    MessageBox.Show(Language.Msg("您无查询权限..."));
                    return;
                }

                if (this.Init() == -1)
                {
                    return;
                }

                //触发事件 加载药房列表
                this.rbDept_CheckedChanged(null, System.EventArgs.Empty);

                this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
            }
            catch
            { }

            base.OnLoad(e);
        }

        private void rbDept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDept.Checked)
            {
                this.cmbData.alItems = null;
                this.cmbData.AddItems(this.deptData);

                int selectIndex = 0;
                foreach (Neusoft.FrameWork.Models.NeuObject dept in this.deptData)
                {
                    if (this.privDept.ID == dept.ID)
                    {
                        break;
                    }

                    selectIndex++;
                }

                if (selectIndex < this.deptData.Count)
                {
                    this.cmbData.SelectedIndex = selectIndex;
                }

                this.DrugDeptQuery = true;
            }
        }

        private void rbPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbPerson.Checked)
            {
                this.cmbData.alItems = null;
                this.cmbData.AddItems(this.personData);

                int selectIndex = 0;
                foreach (Neusoft.FrameWork.Models.NeuObject person in this.personData)
                {
                    if (this.privOper.ID == person.ID)
                    {
                        break;
                    }

                    selectIndex++;
                }

                if (selectIndex < this.personData.Count)
                {
                    this.cmbData.SelectedIndex = selectIndex;
                }

                this.DrugDeptQuery = false;
            }
        }

        private void rbTerminal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbTerminalShow.Checked)
            {
                this.QueryData();
            }
        }

        private void rbOper_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbOperShow.Checked)
            {
                this.QueryData();
            }
        }

        //打印预览
        public override int PrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print printview = new Neusoft.FrameWork.WinForms.Classes.Print();

            //printview.PrintPreview(0, 0, this.neuTabControl1.SelectedTab);
            printview.PrintPreview(this.neuPanel2);
            return base.OnPrintPreview(sender, neuObject);
        }

        //打印
        protected override int OnPrint(object sender, object neuObject)
        {
            this.neuSpread1.PrintSheet(0);
            return base.OnPrint(sender, neuObject);
        }
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.rbPerson.Checked)
            {
                return;
            }

            if (!this.rbOperShow.Checked)
            {
                return;
            }

            if (!this.neuSpread1.Sheets.Contains(this.neuSpread1_Sheet2))
            {
                this.neuSpread1.Sheets.Add(this.neuSpread1_Sheet2);
            }

            if (this.neuSpread1.ActiveSheet == this.neuSpread1_Sheet1)
            {
                string operCode = this.neuSpread1_Sheet1.Cells[e.Row, 0].Text;

                try
                {
                    this.QueryDetail(operCode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
