using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    /// <summary>
    /// [控件描述: 药品月结问题检验控件]
    /// [创 建 人: 孙久海]
    /// [创建时间: 2010-7-25]
    /// </summary>
    public partial class ucMonthBalanceCheck : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMonthBalanceCheck()
        {
            InitializeComponent();
        }

        #region 变量

        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private CheckMonth cm = new CheckMonth();

        private string dtLast = "";

        private bool isStop = false;

        #endregion

        #region 方法

        public void InitDept()
        {
            ArrayList alP = this.managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
            ArrayList alPI = this.managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);
            alP.AddRange(alPI);
            this.cbbStockDept.AddItems(alP);
        }

        public void ExecCheck()
        {
            //记录本次选择数据的差额合计
            decimal costSumTotal = 0;
            //获取选择的数据，和计算行数
            ArrayList alTemp = new ArrayList();
            for (int i = 0; i < this.fpDrugList.RowCount; i++)
            {
                if (this.fpDrugList.Cells[i, 0].Text == "True")
                {
                    Neusoft.FrameWork.Models.NeuObject oTemp = new Neusoft.FrameWork.Models.NeuObject();
                    oTemp.ID = this.fpDrugList.Cells[i, 2].Text;
                    oTemp.Name = this.fpDrugList.Cells[i, 1].Text;
                    alTemp.Add(oTemp);
                }
            }
            this.lbHint.Text = "0/" + alTemp.Count.ToString();
            this.pbCheck.Maximum = alTemp.Count;
            this.lbHint.Text = "（0/" + alTemp.Count.ToString() + "）";
            this.fpProblemList.RowCount = 0;

            //校验开始
            for (int i = 0; i < alTemp.Count; i++)
            {
                if (this.isStop)
                {
                    break;
                }
                Neusoft.FrameWork.Models.NeuObject oTemp = alTemp[i] as Neusoft.FrameWork.Models.NeuObject;
                decimal costLast = 0;
                decimal costIn = 0;
                decimal costOut = 0;
                decimal costAdjust = 0;
                decimal costCheck = 0;
                decimal costStore = 0;
                decimal costTotal = 0;                
                string tempSql = "";

                if (this.rbtL.Checked)
                {
                    //上期结存
                    tempSql = @"select nvl(sum(t.current_store_cost),0) as costLast from pha_com_ms_drug t
                      where t.drug_dept_code='{0}' and t.to_date=to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costLast = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //本期入库
                    tempSql = @"select nvl(sum(t1.retail_cost),0) as costIn from pha_com_input t1
                      where t1.drug_dept_code='{0}' and t1.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t1.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costIn = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //本期出库
                    tempSql = @"select nvl(sum(t2.sale_cost),0) as costOut from pha_com_output t2
                      where t2.drug_dept_code='{0}' and t2.exam_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t2.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costOut = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //盘点盈亏
                    tempSql = @"select round(nvl(sum((s.cstore_num-s.fstore_num)/s.pack_qty*s.retail_price),0),4) as costCheck
                      from pha_com_checkdetail s where s.drug_dept_code='{0}'
                      and s.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')  and s.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costCheck = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //调价盈亏
                    tempSql = @"select round(nvl(sum((t3.retail_price-t3.pre_retail_price)*t3.store_sum/t3.pack_qty),0),4) as costAdjust
                      from pha_com_adjustpricedetail t3 where t3.drug_dept_code='{0}' 
                      and t3.inure_time>to_date('{1}','yyyy-mm-dd hh24:mi:ss') and t3.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costAdjust = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //当前库存
                    tempSql = @"select round(nvl(sum(t4.store_sum*t4.retail_price/t4.pack_qty),0),4) as costStore from pha_com_storage t4
                      where t4.drug_dept_code='{0}' and t4.drug_code='{1}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, oTemp.ID);
                    costStore = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));
                }
                else
                {
                    //上期结存
                    tempSql = @"select nvl(sum(t.current_store_purchase_cost),0) as costLast from pha_com_ms_drug t
                      where t.drug_dept_code='{0}' and t.to_date=to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costLast = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //本期入库
                    tempSql = @"select nvl(sum(t1.purchase_cost),0) as costIn from pha_com_input t1
                      where t1.drug_dept_code='{0}' and t1.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t1.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costIn = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //本期出库
                    tempSql = @"select nvl(sum(t2.purchase_price*t2.out_num/t2.pack_qty),0) as costOut from pha_com_output t2
                      where t2.drug_dept_code='{0}' and t2.exam_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t2.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costOut = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //盘点盈亏
                    tempSql = @"select round(nvl(sum((s.cstore_num-s.fstore_num)/s.pack_qty*s.purchase_price),0),4) as costCheck
                      from pha_com_checkdetail s where s.drug_dept_code='{0}'
                      and s.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')  and s.drug_code='{2}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, oTemp.ID);
                    costCheck = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));

                    //调价盈亏
                    costAdjust = 0;

                    //当前库存
                    tempSql = @"select round(nvl(sum(t4.store_sum*t4.purchase_price/t4.pack_qty),0),4) as costStore from pha_com_storage t4
                      where t4.drug_dept_code='{0}' and t4.drug_code='{1}'";
                    tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, oTemp.ID);
                    costStore = Convert.ToDecimal(this.cm.ExecSqlReturnOne(tempSql));
                }

                //计算账目差额
                costTotal = costLast + costIn - costOut + costCheck + costAdjust - costStore;
                costSumTotal += costTotal;
                if (costTotal != 0)
                {
                    Neusoft.FrameWork.Models.NeuObject dObj = new Neusoft.FrameWork.Models.NeuObject();
                    dObj.ID = costLast.ToString();
                    dObj.Name = costIn.ToString();
                    dObj.Memo = costOut.ToString();
                    dObj.User01 = costCheck.ToString();
                    dObj.User02 = costAdjust.ToString();
                    dObj.User03 = costStore.ToString();
                    this.fpProblemList.RowCount += 1;
                    this.fpProblemList.Cells[this.fpProblemList.RowCount - 1, 0].Text = oTemp.ID;
                    this.fpProblemList.Cells[this.fpProblemList.RowCount - 1, 1].Text = oTemp.Name;
                    this.fpProblemList.Cells[this.fpProblemList.RowCount - 1, 2].Text = costTotal.ToString();
                    this.fpProblemList.Rows[this.fpProblemList.RowCount - 1].Tag = dObj;
                }
                this.lbHint.Text = "（" + Convert.ToString(i + 1) + "/" + this.pbCheck.Maximum.ToString() + "）";
                this.pbCheck.Value = i + 1;
                Application.DoEvents();
            }

            MessageBox.Show("校验完成,共出现< " + this.fpProblemList.RowCount.ToString() + " >条问题数据!");
        }

        public void ShowDetail(string drugCode, object totalObj)
        {
            string tempSql = "";
            DataSet dtLast = new DataSet();
            DataSet dtIn = new DataSet();
            DataSet dtOut = new DataSet();
            DataSet dtAdjust = new DataSet();
            DataSet dtCheck = new DataSet();
            DataSet dtStore = new DataSet();
            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();

            //综合信息
            if (totalObj != null)
            {
                Neusoft.FrameWork.Models.NeuObject tempObj = totalObj as Neusoft.FrameWork.Models.NeuObject;
                this.fpTotalCheck.RowCount = 1;
                this.fpTotalCheck.Cells[0, 0].Text = tempObj.ID;
                this.fpTotalCheck.Cells[0, 1].Text = tempObj.Name;
                this.fpTotalCheck.Cells[0, 2].Text = tempObj.Memo;
                this.fpTotalCheck.Cells[0, 3].Text = tempObj.User01;
                this.fpTotalCheck.Cells[0, 4].Text = tempObj.User02;
                this.fpTotalCheck.Cells[0, 5].Text = tempObj.User03;
            }

            if (this.rbtL.Checked)
            {
                //上期结存
                tempSql = @"select t.retail_price as 零售价,t.pack_qty as 包装数量,t.current_month_num as 上期结存数量,t.current_store_cost as 上期结存金额
                      from pha_com_ms_drug t where t.drug_dept_code='{0}' and t.to_date=to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtLast = this.cm.QueryDebugSql(tempSql);
                this.fpLastBalance.DataSource = dtLast;

                //本期入库
                tempSql = @"select t1.class3_meaning_code as 入库类型,t1.retail_price as 零售价,t1.pack_qty as 包装数量,t1.in_num as 入库数量,
                      t1.retail_cost as 入库金额,t1.in_state as 状态,t1.oper_date as 时间 from pha_com_input t1
                      where t1.drug_dept_code='{0}' and t1.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t1.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtIn = this.cm.QueryDebugSql(tempSql);
                this.fpInput.DataSource = dtIn;
                this.fpInput.Columns[6].CellType = textType;

                //本期出库
                tempSql = @"select t2.class3_meaning_code as 出库类型,t2.retail_price as 零售价,t2.pack_qty as 包装数量,t2.out_num as 出库数量,
                      t2.sale_cost as 出库金额,t2.out_state as 状态,t2.exam_date as 时间 from pha_com_output t2
                      where t2.drug_dept_code='{0}' and t2.exam_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t2.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtOut = this.cm.QueryDebugSql(tempSql);
                this.fpOutput.DataSource = dtOut;
                this.fpOutput.Columns[6].CellType = textType;

                //盘点盈亏
                tempSql = @"select s.retail_price as 零售价,s.pack_qty as 包装数量,s.fstore_num as 封帐数量,s.cstore_num as 结存数量,
                      s.check_state as 状态,s.oper_date as 时间 from pha_com_checkdetail s where s.drug_dept_code='{0}'
                      and s.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss') and s.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtCheck = this.cm.QueryDebugSql(tempSql);
                this.fpCheck.DataSource = dtCheck;
                this.fpCheck.Columns[5].CellType = textType;

                //调价盈亏
                tempSql = @"select t3.retail_price as 零售价,t3.pre_retail_price as 调整前零售价,t3.store_sum as 调价库存,t3.pack_qty as 包装数量,
                      t3.current_state as 状态,t3.inure_time as 时间 from pha_com_adjustpricedetail t3 where t3.drug_dept_code='{0}' 
                      and t3.inure_time>to_date('{1}','yyyy-mm-dd hh24:mi:ss') and t3.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtAdjust = this.cm.QueryDebugSql(tempSql);
                this.fpAdjust.DataSource = dtAdjust;
                this.fpAdjust.Columns[5].CellType = textType;

                //当前库存
                tempSql = @"select t4.retail_price as 零售价,t4.pack_qty as 包装数量,t4.store_sum as 库存数量,round(t4.retail_price/t4.pack_qty*t4.store_sum,4) as 库存金额,
                      t4.valid_flag as 状态 from pha_com_storage t4
                      where t4.drug_dept_code='{0}' and t4.drug_code='{1}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, drugCode);
                dtStore = this.cm.QueryDebugSql(tempSql);
                this.fpCurrStore.DataSource = dtStore;
            }
            else
            {
                //上期结存
                tempSql = @"select t.purchase_price as 购入价,t.pack_qty as 包装数量,t.current_month_num as 上期结存数量,t.current_store_purchase_cost as 上期结存金额
                      from pha_com_ms_drug t where t.drug_dept_code='{0}' and t.to_date=to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtLast = this.cm.QueryDebugSql(tempSql);
                this.fpLastBalance.DataSource = dtLast;

                //本期入库
                tempSql = @"select t1.class3_meaning_code as 入库类型,t1.purchase_price as 购入价,t1.pack_qty as 包装数量,t1.in_num as 入库数量,
                      t1.purchase_cost as 入库金额,t1.in_state as 状态,t1.oper_date as 时间 from pha_com_input t1
                      where t1.drug_dept_code='{0}' and t1.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t1.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtIn = this.cm.QueryDebugSql(tempSql);
                this.fpInput.DataSource = dtIn;
                this.fpInput.Columns[6].CellType = textType;

                //本期出库
                tempSql = @"select t2.class3_meaning_code as 出库类型,t2.purchase_price as 购入价,t2.pack_qty as 包装数量,t2.out_num as 出库数量,
                      t2.purchase_price*t2.out_num/t2.pack_qty as 出库金额,t2.out_state as 状态,t2.exam_date as 时间 from pha_com_output t2
                      where t2.drug_dept_code='{0}' and t2.exam_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                      and t2.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtOut = this.cm.QueryDebugSql(tempSql);
                this.fpOutput.DataSource = dtOut;
                this.fpOutput.Columns[6].CellType = textType;

                //盘点盈亏
                tempSql = @"select s.purchase_price as 购入价,s.pack_qty as 包装数量,s.fstore_num as 封帐数量,s.cstore_num as 结存数量,
                      s.check_state as 状态,s.oper_date as 时间 from pha_com_checkdetail s where s.drug_dept_code='{0}'
                      and s.oper_date>to_date('{1}','yyyy-mm-dd hh24:mi:ss') and s.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtCheck = this.cm.QueryDebugSql(tempSql);
                this.fpCheck.DataSource = dtCheck;
                this.fpCheck.Columns[5].CellType = textType;

                //调价盈亏
                tempSql = @"select t3.retail_price as 零售价,t3.pre_retail_price as 调整前零售价,t3.store_sum as 调价库存,t3.pack_qty as 包装数量,
                      t3.current_state as 状态,t3.inure_time as 时间 from pha_com_adjustpricedetail t3 where t3.drug_dept_code='{0}' 
                      and t3.inure_time>to_date('{1}','yyyy-mm-dd hh24:mi:ss') and t3.drug_code='{2}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, this.dtLast, drugCode);
                dtAdjust = this.cm.QueryDebugSql(tempSql);
                this.fpAdjust.DataSource = dtAdjust;
                this.fpAdjust.Columns[5].CellType = textType;

                //当前库存
                tempSql = @"select t4.purchase_price as 购入价,t4.pack_qty as 包装数量,t4.store_sum as 库存数量,round(t4.purchase_price/t4.pack_qty*t4.store_sum,4) as 库存金额,
                      t4.valid_flag as 状态 from pha_com_storage t4
                      where t4.drug_dept_code='{0}' and t4.drug_code='{1}'";
                tempSql = string.Format(tempSql, this.cbbStockDept.SelectedItem.ID, drugCode);
                dtStore = this.cm.QueryDebugSql(tempSql);
                this.fpCurrStore.DataSource = dtStore;
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            this.InitDept();
            this.dtLast = this.cm.ExecSqlReturnOne("select t.last_dtime from com_job t where t.job_code='PHA_MS'");
            this.lbLastBalanceTime.Text = "上次月结时间:" + this.dtLast;
            base.OnLoad(e);
        }

        private void cbbStockDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbbStockDept.SelectedIndex > -1)
            {
                string sqlStr = @"select 'False' as A,s.trade_name as 药品名称,t.drug_code as C from pha_com_stockinfo t,pha_com_baseinfo s 
                       where t.drug_code=s.drug_code and t.drug_dept_code='{0}' order by s.trade_name";
                sqlStr = string.Format(sqlStr, this.cbbStockDept.SelectedItem.ID);
                DataSet dsDrugList = this.cm.QueryDebugSql(sqlStr);
                this.fpDrugList.DataSource = dsDrugList;
                FarPoint.Win.Spread.CellType.CheckBoxCellType cbct = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                this.fpDrugList.Columns[0].CellType = cbct;
                this.fpDrugList.Columns[0].Width = 20;
                this.fpDrugList.Columns[1].Width = 160;
                this.fpDrugList.Columns[2].Width = 20;
                this.lbCountDrug.Text = this.fpDrugList.RowCount.ToString();
            }
        }

        private void neuButton3_Click(object sender, EventArgs e)
        {
            this.ExecCheck();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.fpDrugList.RowCount; i++)
            {
                this.fpDrugList.Cells[i, 0].Text = "True";
            }
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.fpDrugList.RowCount; i++)
            {
                this.fpDrugList.Cells[i, 0].Text = "False";
            }
        }

        private void neuButton5_Click(object sender, EventArgs e)
        {
            for (int i = Convert.ToInt32(this.tbStart.Text) - 1; i < Convert.ToInt32(this.tbTo.Text); i++)
            {
                this.fpDrugList.Cells[i, 0].Text = "True";
            }
        }

        private void neuButton4_Click(object sender, EventArgs e)
        {
            this.isStop = true;
        }

        private void neuSpread9_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.ShowDetail(this.fpProblemList.Cells[e.Row, 0].Text, this.fpProblemList.Rows[e.Row].Tag);
            this.neuTabControl1.TabPages[0].Select();
        }
    }

    public class CheckMonth : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 执行自定义查询语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet QueryDebugSql(string strSql)
        {
            DataSet ds = new DataSet();
            try
            {
                this.ExecQuery(strSql, ref ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询语句执行出错!" + ex.Message);
                return null;
            }
            return ds;
        }
    }
}
