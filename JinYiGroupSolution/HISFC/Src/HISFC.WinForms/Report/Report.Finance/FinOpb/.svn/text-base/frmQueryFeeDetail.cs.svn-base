using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class frmQueryFeeDetail : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public frmQueryFeeDetail()
        {
            InitializeComponent();
        }

        #region 变量定义
        /// <summary>
        /// 查询类型
        /// </summary>
        int intQueryType = 1;

        Neusoft.FrameWork.WinForms.Forms.frmWait frmWait = new Neusoft.FrameWork.WinForms.Forms.frmWait();

        #endregion

        #region 函数

        #region 切换检索方式
        /// <summary>
        /// 切换检索方式
        /// </summary>
        public void ChangeQueryType()
        {
            // 转换查询类型
            if (intQueryType == 3)
            {
                intQueryType = 1;
            }
            else
            {
                intQueryType++;
            }

            // 设置查询类型显示文本
            switch (this.intQueryType)
            {
                case 1:
                    this.labQueryName.Text = "发票号(F2切换)";
                    break;
                case 2:
                    this.labQueryName.Text = "病历号(F2切换)";
                    break;
                case 3:
                    this.labQueryName.Text = "姓  名(F2切换)";
                    break;
            }

            // 设置焦点到输入框
            this.tbInput.Focus();
            this.tbInput.SelectAll();

            // 设置时间复选框
            if (this.intQueryType != 1)
            {
                this.cbDataDate.Enabled = true;
            }
            else
            {
                this.cbDataDate.Enabled = false;
            }
        }
        #endregion

        #region 获取检索码(1：成功/-1：失败)
        /// <summary>
        /// 获取检索码(1：成功/-1：失败)
        /// </summary>
        /// <param name="strCode">返回的检索码</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetInput(ref string strCode)
        {
            strCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.tbInput.Text.Trim());

            // 判断合法性
            if (this.intQueryType == 2)
            {
                try
                {
                    long.Parse(strCode);
                }
                catch
                {
                    MessageBox.Show("输入的病历卡号必须是数字形式,请尝试用发票号查询");
                    this.tbInput.Text = "";
                    this.tbInput.Focus();
                    return -1;
                }
            }

            #region {571171C3-2CF8-4edc-9403-0E5E2B424A26}
            // 判断合法性
            if (this.intQueryType == 3)
            {
                strCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(strCode);
                if (strCode == "" || strCode == null) { return  -1; }
            }
            #endregion
            // 填充号码
            switch (this.intQueryType)
            {
                case 1:
                    // 按照发票号查询：12位
                    strCode = strCode.PadLeft(12, '0');
                    break;
                case 2:
                    // 病历卡号：10位
                    strCode = strCode.PadLeft(10, '0');
                    break;
            }
            this.tbInput.Text = strCode;

            return 1;
        }
        #endregion

        #region 获取查询日期
        /// <summary>
        /// 获取查询日期
        /// </summary>
        /// <param name="dtFrom">返回的起始日期</param>
        /// <param name="dtTo">返回的截止日期</param>
        public void GetQueryDate(ref DateTime dtFrom, ref DateTime dtTo)
        {
            // 如果不按照发票号查询，才可以带时间参数，因为发票号是唯一的
            if (this.intQueryType != 1)
            {
                // 如果时间选项选中，日期有效选择日期
                if (this.cbDataDate.Checked)
                {
                    dtFrom = this.dtpFromDate.Value;
                    dtTo = this.dtpDateTo.Value;

                    dtFrom = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day);
                    dtTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day + 1);
                }
                else
                {
                    // 否则，起始日期为最小日期，截止日期为最大日期
                    dtFrom = new DateTime(2000, 11, 11, 11, 11, 11);
                    dtTo = new DateTime(2020, 11, 11, 11, 11, 11);
                }
            }
        }
        #endregion

        #region 检索发票基本信息
        /// <summary>
        /// QueryInvoiceInformation
        /// </summary>
        public void QueryInvoiceInformation()
        {
            this.frmWait.Show();
            int intReturn = 0;
            // 根据不同的查询类别，执行不同的查询
            switch (this.intQueryType)
            {
                case 1:
                    intReturn = this.QueryInvoiceInfromationByInvoiceNo();
                    break;
                case 2:
                    intReturn = this.QueryInvoiceInfromationByCardNo();
                    break;
                case 3:
                    intReturn = this.QueryInvoiceInfromationByName();
                    break;
            }

            if (intReturn == -1)
            {
                this.frmWait.Hide();
                return;
            }

            // 显示第一页
            this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet1;

            this.frmWait.Hide();
        }
        #endregion

        #region 按发票号检索发票基本信息
        /// <summary>
        /// 按发票号检索发票基本信息
        /// </summary>
        public int QueryInvoiceInfromationByInvoiceNo()
        {
            // 变量定义
            int intReturn = 0;
            string strCode = "";
            System.Data.DataSet dsResult1 = new DataSet();
            System.Data.DataSet dsResult2 = new DataSet();
            System.Data.DataSet dsResult3 = new DataSet();
            Neusoft.HISFC.BizLogic.Fee.Outpatient outpatient = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

            // 获取检索码
            intReturn = this.GetInput(ref strCode);
            if (intReturn == -1)
            {
                this.frmWait.Hide();
                return -1;
            }

            // 执行查询
            intReturn = outpatient.QueryBalancesByInvoiceNO(strCode, ref dsResult1);
            if (-1 == intReturn)
            {
                MessageBox.Show("获取发票基本信息失败" + outpatient.Err);
                this.frmWait.Hide();
                return -1;
            }
            this.fpSpread1_Sheet1.DataSource = dsResult1;

            // 按发票号查询同时查询发票明细和费用明细
            intReturn = outpatient.QueryBalanceListsByInvoiceNO(strCode, ref dsResult2);
            if (-1 == intReturn)
            {
                MessageBox.Show("获取发票明细失败" + outpatient.Err);
                this.frmWait.Hide();
                return -1;
            }
            this.fpSpread1_Sheet2.DataSource = dsResult2;

            intReturn = outpatient.QueryFeeItemListsByInvoiceNO(strCode, ref dsResult3);
            if (-1 == intReturn)
            {
                MessageBox.Show("获取费用明细失败" + outpatient.Err);
                this.frmWait.Hide();
                return -1;
            }
            this.fpSpread1_Sheet3.DataSource = dsResult3;
            if (this.fpSpread1_Sheet3.RowCount > 0)
            {
                this.SetSheet3DisplayData();
            }
            return 1;
        }
        #endregion

        #region 按病历号检索发票基本信息
        /// <summary>
        /// 按病历号检索发票基本信息
        /// </summary>
        public int QueryInvoiceInfromationByCardNo()
        {
            // 变量定义
            int intReturn = 0;
            string strCode = "";
            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MaxValue;
            System.Data.DataSet dsResult = new DataSet();
            Neusoft.HISFC.BizLogic.Fee.Outpatient outpatient = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

            // 获取检索码
            intReturn = this.GetInput(ref strCode);
            if (intReturn == -1)
            {
                this.frmWait.Hide();
                return -1;
            }

            // 获取时间范围
            this.GetQueryDate(ref dtFrom, ref dtTo);

            // 执行查询
            intReturn = outpatient.QueryBalancesByCardNO(strCode, dtFrom, dtTo, ref dsResult);
            if (-1 == intReturn)
            {
                this.frmWait.Hide();
                MessageBox.Show("获取发票基本信息失败" + outpatient.Err);
                return -1;
            }

            // 设置查询结果
            this.fpSpread1_Sheet1.DataSource = dsResult;
            this.fpSpread1_Sheet2.DataSource = null;
            this.fpSpread1_Sheet3.DataSource = null;

            return 1;
        }
        #endregion

        #region 按姓名检索发票基本信息
        /// <summary>
        /// 按姓名检索发票基本信息
        /// </summary>
        public int QueryInvoiceInfromationByName()
        {

            // 变量定义
            int intReturn = 0;
            string strCode = "";
            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MaxValue;
            System.Data.DataSet dsResult = new DataSet();
            Neusoft.HISFC.BizLogic.Fee.Outpatient outpatient = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

            // 获取检索码
            intReturn = this.GetInput(ref strCode);
            if (intReturn == -1)
            {
                this.frmWait.Hide();
                return -1;
            }

            // 获取时间范围
            this.GetQueryDate(ref dtFrom, ref dtTo);

            // 执行查询
            intReturn = outpatient.QueryBalancesByPatientName(strCode, dtFrom, dtTo, ref dsResult);
            if (-1 == intReturn)
            {
                this.frmWait.Hide();
                MessageBox.Show("获取发票基本信息失败" + outpatient.Err);
                return -1;
            }

            // 设置查询结果
            this.fpSpread1_Sheet1.DataSource = dsResult;
            this.fpSpread1_Sheet2.DataSource = null;
            this.fpSpread1_Sheet3.DataSource = null;

            return 1;
        }
        #endregion

        #region 设置列的显示宽度
        /// <summary>
        /// 设置列的显示宽度
        /// </summary>
        /// <param name="intSheet">SHEET索引</param>
        public void SetSheetWidth(int intSheet)
        {
            // 设置列宽度
            for (int i = 0; i < this.fpSpread1.Sheets[intSheet].Columns.Count; i++)
            {
                this.fpSpread1.Sheets[intSheet].Columns[i].Width = 80;
            }

            // 设置特殊字段的值：结算类别5、医疗类别8、结算人14、是否体检16、发票状态17、作废操作员19、是否核查21、核查人22、是否已经日结24、日结人25、自费日结记帐28
        }
        #endregion

        #region 设置第三页特殊字段的值
        /// <summary>
        /// 
        /// </summary>
        public void SetSheet3DisplayData()
        {
            for (int i = 0; i < this.fpSpread1_Sheet3.RowCount; i++)
            {
                // 变量定义
                Neusoft.HISFC.Models.Base.SysClassEnumService enuSysClass = new Neusoft.HISFC.Models.Base.SysClassEnumService();

                // 系统类别7
                if (this.fpSpread1_Sheet3.Cells[i, 22].Text != "" || this.fpSpread1_Sheet3.Cells[i, 22].Text != null)
                {
                    enuSysClass.ID = this.fpSpread1_Sheet3.Cells[i, 22].Text;
                    this.fpSpread1_Sheet3.Cells[i, 22].Text = enuSysClass.Name;
                }
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        public void PringSheet()
        {
            if (MessageBox.Show("是否打印当前结果页", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            this.fpSpread1.PrintSheet(this.fpSpread1.ActiveSheetIndex);
        }
        #endregion

        #region 导出
        /// <summary>
        /// 导出
        /// </summary>
        public void ExportSheet()
        {
            DialogResult drExport = new DialogResult();
            drExport = this.saveFileDialog1.ShowDialog();
            if (drExport == DialogResult.OK)
            {
                this.fpSpread1.SaveExcel(this.saveFileDialog1.FileName);
            }
        }
        #endregion

        #endregion

        #region 事件

        #region 窗口按键事件
        /// <summary>
        /// 窗口按键事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                // 切换查询方式
                this.ChangeQueryType();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                // 切换数据时间复选框的状态
                this.cbDataDate.Checked = !this.cbDataDate.Checked;
                this.tbInput.Focus();
                return true;
            }
            else if (keyData == Keys.F4)
            {
                // 发票查询
                this.QueryInvoiceInformation();
                return true;
            }
            else if (keyData == Keys.F6)
            {
                // 打印
                this.PringSheet();
                return true;
            }
            else if (keyData == Keys.F7)
            {
                // 导出
                this.ExportSheet();
                return true;
            }
            else if (keyData == Keys.F1)
            {
                // 帮助
                return true;
            }
            else if (keyData == Keys.F12)
            {
                // 退出
                this.FindForm().Close();
                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.A.GetHashCode())
            {
                // 切换焦点到输入框
                this.tbInput.Focus();
                this.tbInput.SelectAll();
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region 日期复选框选中状态改变事件
        /// <summary>
        /// 日期复选框选中状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDataDate_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dtpFromDate.Enabled = this.cbDataDate.Checked;
            this.dtpDateTo.Enabled = this.cbDataDate.Checked;
            if (this.cbDataDate.Checked)
            {
                this.dtpFromDate.Focus();
            }
            else
            {
                this.tbInput.Focus();
            }
        }

        #endregion

        #region 在检索码输入框回车事件
        /// <summary>
        /// 在检索码输入框回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.tbInput.Text == "")
                {
                    return;
                }
                this.QueryInvoiceInformation();
            }
        }

        #endregion

        #region 双击表格第一页，根据发票号查询发票明细和费用明细
        /// <summary>
        /// 双击表格第一页，根据发票号查询发票明细和费用明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet1)
            {
                if (this.fpSpread1_Sheet1.RowCount > 0)
                {
                    this.frmWait.Show();
                    // 返回值
                    int intReturn = 0;
                    // 声明变量 = 所选行的发票号
                    string strCode = this.fpSpread1_Sheet1.Cells[e.Row, 0].Text;
                    // 返回的数据源
                    System.Data.DataSet dsResult1 = new DataSet();
                    System.Data.DataSet dsResult2 = new DataSet();
                    // 业务层
                    Neusoft.HISFC.BizLogic.Fee.Outpatient outpatient = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

                    // 查询患者发票明细
                    intReturn = outpatient.QueryBalanceListsByInvoiceNO(strCode, ref dsResult1);
                    if (-1 == intReturn)
                    {
                        this.frmWait.Hide();
                        MessageBox.Show("获取发票明细失败" + outpatient.Err);
                        return;
                    }
                    this.fpSpread1_Sheet2.DataSource = dsResult1;
                    this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet2;
                    // 查询患者费用明细
                    intReturn = outpatient.QueryFeeItemListsByInvoiceNO(strCode, ref dsResult2);
                    if (-1 == intReturn)
                    {
                        this.frmWait.Hide();
                        MessageBox.Show("获取费用明细失败" + outpatient.Err);
                        return;
                    }
                    this.fpSpread1_Sheet3.DataSource = dsResult2;
                    if (this.fpSpread1_Sheet3.RowCount > 0)
                    {
                        this.SetSheet3DisplayData();
                    }

                    this.frmWait.Hide();
                }
            }
        }

        #endregion

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("导出", "导出查询信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借出, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "导出") 
            {
                this.ExportSheet();
            }
            if (e.ClickedItem.Text == "查询") 
            {
                this.QueryInvoiceInformation();
            }

            if (e.ClickedItem.Text == "打印") 
            {
                this.PringSheet();
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryInvoiceInformation();
            
            return base.OnQuery(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            this.ExportSheet();
            return base.Export(sender, neuObject);
        }

        //#endregion

        #region 窗口加载
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQueryFeeDetail_Load(object sender, System.EventArgs e)
        {
            Neusoft.HISFC.BizLogic.Fee.Outpatient function = new Neusoft.HISFC.BizLogic.Fee.Outpatient();
            this.dtpFromDate.Value = function.GetDateTimeFromSysDateTime();
            this.dtpDateTo.Value = function.GetDateTimeFromSysDateTime();
            frmWait.Tip = "正在查询数据数据，请等待......";
        }

        #endregion

        #endregion
    }
}