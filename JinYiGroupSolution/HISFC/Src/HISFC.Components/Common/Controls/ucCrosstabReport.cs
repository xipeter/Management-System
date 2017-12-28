using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// ucCrosstabReport<br></br>
    /// <Font color='#FF1111'>[功能描述: 通过DataSet实现交叉报表]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2009-4-13]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucCrosstabReport : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCrosstabReport()
        {
            InitializeComponent();
        }
        #endregion 构造函数

        #region 变量

        #region 私有变量

        /// <summary>
        /// 是否使用科室查询条件
        /// </summary>
        private bool isHaveDept = false;

        /// <summary>
        /// 科室类型
        /// </summary>
        //private Neusoft.HISFC.Models.Base.EnumDepartmentType deptType;

        /// <summary>
        /// 三级权限代码，通过权限加载科室，为空时加载所有科室
        /// </summary>
        private string privClass3Code = "";

        /// <summary>
        /// 标题
        /// </summary>
        private string title = "";

        /// <summary>
        /// sql语句id
        /// </summary>
        private string sqlId = "";

        /// <summary>
        /// 明细SQL语句ID
        /// </summary>
        private string sqlDetailId = "";
        /// <summary>
        /// 是否包含合计行
        /// </summary>
        private bool haveSum = true;

        /// <summary>
        /// 是否包含合计列
        /// </summary>
        private bool haveRowSum = true;

        /// <summary>
        /// 是否将空值转为零
        /// </summary>
        private bool replaceNullToZero = true;

        /// <summary>
        /// 时间格式
        /// </summary>
        private string dataTiemFromat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 默认查询的时间范围：天
        /// </summary>
        private int queryDays = 1;

        /// <summary>
        /// 自定义列
        /// </summary>
        private string customColumn = "";

        /// <summary>
        /// 数字格式
        /// </summary>
        private string numberFormat = "0.00";

        /// <summary>
        /// 纸张大小
        /// {8A00B362-C6FD-4f2d-B370-ED2AC6537FCC}
        /// </summary>
        private string pageSize = "";
        /// <summary>
        /// 明细数据表
        /// </summary>
        private DataTable dtDetail = new DataTable();

        /// <summary>
        /// 明细数据表参数
        /// </summary>
        string[] detailParm = null;

        #endregion 私有变量

        #region 保护变量
        #endregion 保护变量

        #region 公开变量

        #endregion 公开变量

        #endregion 变量

        #region 属性

        /// <summary>
        /// 是否使用科室查询条件
        /// </summary>
        [Category("查询设置"), Description("是否添加科室查询条件,true添加,false不添加"), DefaultValue("false")]
        public bool IsHaveDept
        {
            get
            {
                return isHaveDept;
            }
            set
            {
                isHaveDept = value;
                this.lbDept.Visible = value;
                this.cmbDept.Visible = value;
            }
        }

        /// <summary>
        /// 科室类型
        /// </summary>
        //[Category("查询设置"), Description("科室类型")]
        //public Neusoft.HISFC.Models.Base.EnumDepartmentType DeptType
        //{
        //    get
        //    {
        //        return deptType;
        //    }
        //    set
        //    {
        //        deptType = value;
        //    }
        //}

        /// <summary>
        /// 三级权限代码，通过权限加载科室，为空时加载所有科室
        /// </summary>
        [Category("查询设置"), Description("三级权限代码，通过权限加载科室，为空时加载所有科室")]
        public string PrivClass3Code
        {
            get
            {
                return privClass3Code;
            }
            set
            {
                privClass3Code = value;
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        [Category("查询设置"), Description("标题")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// sql语句id
        /// </summary>
        [Category("查询设置"), Description("sql语句id")]
        public string SqlId
        {
            get
            {
                return sqlId;
            }
            set
            {
                sqlId = value;
            }
        }

        [Category("查询设置"), Description("是否添加合计,true添加,false不添加"), DefaultValue("true")]
        public bool HaveSum
        {
            get
            {
                return haveSum;
            }
            set
            {
                haveSum = value;
            }
        }

        /// <summary>
        /// 是否包含合计列
        /// </summary>
        [Category("查询设置"), Description("是否添加行合计,true添加,false不添加"), DefaultValue("true")]
        public bool HaveRowSum
        {
            get
            {
                return haveRowSum;
            }
            set
            {
                haveRowSum = value;
            }
        }

        /// <summary>
        /// 是否将空值转为零
        /// </summary>
        [Category("查询设置"), Description("是否将空值转为零,true转换,false不转换"), DefaultValue("true")]
        public bool ReplaceNullToZero
        {
            get
            {
                return replaceNullToZero;
            }
            set
            {
                replaceNullToZero = value;
            }
        }

        /// <summary>
        /// 时间格式
        /// </summary>
        [Category("查询设置"), Description("时间格式，默认：yyyy-MM-dd HH:mm:ss"), DefaultValue("yyyy-MM-dd HH:mm:ss")]
        public string DataTiemFromat
        {
            get
            {
                return dataTiemFromat;
            }
            set
            {
                dataTiemFromat = value;
            }
        }

        /// <summary>
        /// 默认查询的时间范围：天
        /// </summary>
        [Category("查询设置"), Description("默认查询的时间范围，单位：天，默认1天"), DefaultValue("1")]
        public int QueryDays
        {
            get
            {
                return queryDays;
            }
            set
            {
                queryDays = value;
            }
        }

        /// <summary>
        /// 字体大小
        /// </summary>
        [Category("查询设置"), Description("字体大小")]
        public float FontSize
        {
            get
            {
                if (this.neuSpread1_Sheet1.DefaultStyle.Font != null)
                {
                    return this.neuSpread1_Sheet1.DefaultStyle.Font.Size;
                }
                return 10;
            }
            set
            {
                this.neuSpread1_Sheet1.DefaultStyle.Font = new Font("[Font: Name=宋体, Size=10, Units=3, GdiCharSet=134, GdiVerticalFont=False]", value);
                this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new Font("[Font: Name=宋体, Size=10, Units=3, GdiCharSet=134, GdiVerticalFont=False]", value);
                this.neuSpread1_Sheet1.Columns[0].Font = new Font("[Font: Name=宋体, Size=10, Units=3, GdiCharSet=134, GdiVerticalFont=False]", value, FontStyle.Bold);
            }
        }

        /// <summary>
        /// 自定义列
        /// </summary>
        [Category("查询设置"), Description("添加自定义列，用公式表示，多个列之间用“,”隔开，列名用“[]”注明。例：[新列]=[列1]+[列2],[新列2]=[列1]*[列2]"), DefaultValue("")]
        public string CustomColumn
        {
            get
            {
                return customColumn;
            }
            set
            {
                customColumn = value;
            }
        }

        /// <summary>
        /// 数字格式
        /// </summary>
        [Category("查询设置"), Description("数字格式"), DefaultValue("0.00")]
        public string NumberFormat
        {
            get
            {
                return numberFormat;
            }
            set
            {
                numberFormat = value;
            }
        }

        /// <summary>
        /// 纸张大小
        /// {8A00B362-C6FD-4f2d-B370-ED2AC6537FCC}
        /// </summary>
        [Category("查询设置"), Description("设置纸张大小，格式：width,height，单位：MM"), DefaultValue("")]
        public string PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }
        /// <summary>
        /// 明细sql语句id
        /// </summary>
        [Category("查询设置"), Description("明细sql语句id")]
        public string SqlDetailId
        {
            get
            {
                return sqlDetailId;
            }
            set
            {
                sqlDetailId = value;
            }
        }

        #endregion 属性

        #region 方法

        #region 资源释放
        #endregion 资源释放

        #region 克隆
        #endregion 克隆

        #region 私有方法

        private void Init()
        {
            //科室查询条件
            if (this.isHaveDept)
            {
                if (string.IsNullOrEmpty(this.privClass3Code.Trim()))
                {
                    Neusoft.HISFC.BizProcess.Integrate.Manager interMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    ArrayList alDept = interMgr.GetDepartment();
                    this.cmbDept.AddItems(alDept);
                }
                else
                {
                    Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    List<Neusoft.FrameWork.Models.NeuObject> alPrivDept = managerIntegrate.QueryUserPriv(Neusoft.FrameWork.Management.Connection.Operator.ID, this.privClass3Code.Trim());
                    if (alPrivDept != null)
                    {
                        this.cmbDept.AddItems(new ArrayList(alPrivDept.ToArray()));
                    }
                }
            }
            this.lbDept.Visible = this.isHaveDept;
            this.cmbDept.Visible = this.isHaveDept;
            //表头
            this.lbTitle.Text = this.title;
            //时间格式
            this.dtpFromDate.CustomFormat = this.dataTiemFromat;
            this.dtpEndDate.CustomFormat = this.dataTiemFromat;
            this.dtpFromDate.Value = new DateTime(this.dtpFromDate.Value.Year, this.dtpFromDate.Value.Month, this.dtpFromDate.Value.Day, 0, 0, 0);
            this.dtpEndDate.Value = new DateTime(this.dtpEndDate.Value.Year, this.dtpEndDate.Value.Month, this.dtpEndDate.Value.Day, 23, 59, 59);
            this.dtpFromDate.Value = this.dtpEndDate.Value.AddDays(-this.queryDays).AddSeconds(1);
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍等");
                Application.DoEvents();
                //执行sql语句，获取DataTable
                DataTable dt = this.GetDataTableBySql();
                if (dt == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }
                //根据sql查询结果的DataTable生成交叉表的DataTable
                DataTable dtCross = this.GetCrossDataTable(dt);
                if (dtCross == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }
                //添加合计
                this.ComputeSum(dtCross);
                //添加自定义列
                this.AddCustomColumns(dtCross);
                //将空值转为零
                this.ConverNullToZero(dtCross);
                //取得要显示的DataTable，方便控制格式
                DataTable dtShow = this.GetShowDataTable(dtCross);
                //FarPoint赋值，设置格式
                this.SetFp(dtShow);
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("查询数据发生错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 执行sql语句，获取DataTable
        /// </summary>
        private DataTable GetDataTableBySql()
        {
            //执行sql语句
            if (string.IsNullOrEmpty(this.sqlId.Trim()))
            {
                return null;
            }
            if (this.dtpFromDate.Value > this.dtpEndDate.Value)
            {
                MessageBox.Show("开始时间不能大于截止时间，请重新输入");
                return null;
            }
            Neusoft.HISFC.BizLogic.Manager.Report reportMgr = new Neusoft.HISFC.BizLogic.Manager.Report();

            string[] parm = null;
            if (this.isHaveDept)
            {
                parm = new string[] { this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.cmbDept.Tag.ToString() };
            }
            else
            {
                parm = new string[] { this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") };
            }

            DataSet ds = new DataSet();
            if (reportMgr.ExecQuery(this.sqlId, ref ds, parm) < 0)
            {
                MessageBox.Show("查询数据出错：" + reportMgr.Err);
                return null;
            }
            return ds.Tables[0];
        }
        /// <summary>
        /// 执行sql语句，获取DataTable
        /// </summary>
        private DataTable GetDataTableBySql(string sql)
        {
            //执行sql语句
            if (string.IsNullOrEmpty(sql.Trim()))
            {
                return null;
            }
            if (this.dtpFromDate.Value > this.dtpEndDate.Value)
            {
                MessageBox.Show("开始时间不能大于截止时间，请重新输入");
                return null;
            }
            Neusoft.HISFC.BizLogic.Manager.Report reportMgr = new Neusoft.HISFC.BizLogic.Manager.Report();

            DataSet ds = new DataSet();
            if (reportMgr.ExecQuery(sql, ref ds, detailParm) < 0)
            {
                MessageBox.Show("查询数据出错：" + reportMgr.Err);
                return null;
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 根据sql查询结果的DataTable生成交叉表表的DataTable
        /// </summary>
        /// <param name="dt">原DataTable</param>
        /// <returns>CrossDataTable</returns>
        private DataTable GetCrossDataTable(DataTable dt)
        {
            if (dt.Columns.Count < 3)
            {
                MessageBox.Show("sql语句错误：交叉报表数据列不能少于3列");
                return null;
            }
            DataTable dtCross = new DataTable();
            //添加列
            //第一列、名字为空
            dtCross.Columns.Add(new DataColumn(" "));
            foreach (DataRow drCol in dt.Rows)
            {
                string colName = drCol[1].ToString();
                if (dtCross.Columns.Contains(colName))
                {
                    continue;
                }
                dtCross.Columns.Add(colName, typeof(System.Decimal));
            }
            //添加数据
            Hashtable htRow = new Hashtable();

            foreach (DataRow drRow in dt.Rows)
            {
                string rowName = drRow[0].ToString();

                if (htRow.ContainsKey(rowName))
                {
                    DataRow drAdded = htRow[rowName] as DataRow;
                    drAdded[drRow[1].ToString()] = (Neusoft.FrameWork.Function.NConvert.ToDecimal(drAdded[drRow[1].ToString()].ToString())
                                                                            + Neusoft.FrameWork.Function.NConvert.ToDecimal(drRow[2].ToString())).ToString(this.numberFormat);
                }
                else
                {
                    DataRow drNew = dtCross.NewRow();
                    htRow.Add(rowName, drNew);
                    dtCross.Rows.Add(drNew);
                    drNew[0] = rowName;
                    drNew[drRow[1].ToString()] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drRow[2].ToString()).ToString(this.numberFormat);
                }
            }
            return dtCross;
        }

        /// <summary>
        /// 添加合计
        /// </summary>
        /// <param name="dtCross">CrossDataTable</param>
        private void ComputeSum(DataTable dtCross)
        {
            //列合计
            if (this.haveSum)
            {
                DataRow drSum = dtCross.NewRow();
                dtCross.Rows.Add(drSum);
                drSum[0] = "合计:";
                for (int i = 1; i < dtCross.Columns.Count; i++)
                {
                    DataColumn dc = dtCross.Columns[i];
                    decimal sum = 0;
                    foreach (DataRow dr in dtCross.Rows)
                    {
                        sum += Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[dc.ColumnName].ToString());
                    }
                    drSum[dc.ColumnName] = sum.ToString(this.numberFormat);
                }
            }
            //行合计
            if (this.haveRowSum)
            {
                DataColumn dcSum = new DataColumn("合计", typeof(System.Decimal));
                dtCross.Columns.Add(dcSum);
                for (int i = 0; i < dtCross.Rows.Count; i++)
                {
                    DataRow drR = dtCross.Rows[i];
                    decimal rowSum = 0;
                    for (int j = 1; j < dtCross.Columns.Count; j++)
                    {
                        rowSum += Neusoft.FrameWork.Function.NConvert.ToDecimal(drR[dtCross.Columns[j].ColumnName].ToString());
                    }
                    drR["合计"] = rowSum.ToString();
                }

            }
        }

        /// <summary>
        /// 添加自定义列
        /// </summary>
        /// <param name="dtCross">CrossDataTable</param>
        private void AddCustomColumns(DataTable dtCross)
        {
            if (string.IsNullOrEmpty(this.customColumn.Trim()))
            {
                return;
            }
            string[] columnArray = this.customColumn.Split(',');
            foreach (string columnExStr in columnArray)
            {
                string[] tmpStr = columnExStr.Split('=');
                if (tmpStr.Length < 2)
                {
                    MessageBox.Show("“" + columnExStr + "”的表达式不正确：等号有错误");
                    return;
                }
                string columnName = tmpStr[0].Trim().Replace("[", "").Replace("]", "");
                string columnExpression = this.converExpression(tmpStr[1], dtCross);
                dtCross.Columns.Add(new DataColumn(columnName, typeof(System.Decimal)));
                try
                {
                    dtCross.Columns[columnName].Expression = columnExpression;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("计算“" + columnExStr + "”时发生错误：" + ex.Message);
                    continue;
                }

            }

        }

        /// <summary>
        /// 获取表达式
        /// </summary>
        /// <param name="str">表达式</param>
        /// <param name="dtCross">CrossDataTable</param>
        /// <returns>表达式</returns>
        private string converExpression(string str, DataTable dtCross)
        {
            string myStr = str.Trim().Replace(" ", "");
            string[] arrayWithOutOp = myStr.Split('+', '-', '*', '/', '(', ')', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9');

            foreach (string colName in arrayWithOutOp)
            {
                if (string.IsNullOrEmpty(colName.Trim()))
                {
                    continue;
                }
                if (colName.StartsWith("'"))
                {
                    continue;
                }
                if (!colName.StartsWith("["))
                {
                    myStr = myStr.Replace(colName, "0");
                    continue;
                }
                if (dtCross.Columns.Contains(colName.Replace("[", "").Replace("]", "")))
                {
                    continue;
                }
                myStr = myStr.Replace(colName, "0");
            }

            return myStr;
        }

        /// <summary>
        /// 取得要显示的DataTable，方便控制格式
        /// </summary>
        /// <param name="dtCross">交叉报表</param>
        /// <returns>要显示的交叉报表</returns>
        private DataTable GetShowDataTable(DataTable dtCross)
        {
            DataTable dtShow = new DataTable();
            foreach (DataColumn dc in dtCross.Columns)
            {
                dtShow.Columns.Add(new DataColumn(dc.ColumnName, typeof(System.String)));
            }
            for (int i = 0; i < dtCross.Rows.Count; i++)
            {
                DataRow drCross = dtCross.Rows[i];
                DataRow drShow = dtShow.NewRow();
                dtShow.Rows.Add(drShow);
                for (int j = 0; j < dtCross.Columns.Count; j++)
                {
                    try
                    {
                        drShow[j] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drCross[j].ToString()).ToString(this.numberFormat);
                    }
                    catch (Exception ex)
                    {
                        drShow[j] = drCross[j].ToString();
                    }
                }
            }
            return dtShow;
        }

        /// <summary>
        /// FarPoint赋值，设置格式
        /// </summary>
        /// <param name="dtCross">CrossDataTable</param>
        private void SetFp(DataTable dtCross)
        {
            //查询信息赋值
            this.lbQueryInfo.Text = "时间范围：" + this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + " 至 " + this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (isHaveDept)
            {
                this.lbQueryInfo.Text += "  查询科室：" + this.cmbDept.Text;
            }
            //数据源
            this.neuSpread1_Sheet1.DataSource = dtCross;
            //宽度
            for (int i = 0; i < this.neuSpread1_Sheet1.ColumnCount; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].Width = this.neuSpread1_Sheet1.Columns[i].GetPreferredWidth() + 8;
            }
            //表头位置
            //int windowX = this.Width;
            decimal spreadWith = 0;
            foreach (FarPoint.Win.Spread.Column fpCol in this.neuSpread1_Sheet1.Columns)
            {
                spreadWith += (decimal)fpCol.Width;
            }
            if (spreadWith > this.plPrint.Width)
            {
                spreadWith = this.plPrint.Width;
            }

            int titleWidth = this.lbTitle.Size.Width;
            int titleX = Neusoft.FrameWork.Function.NConvert.ToInt32((spreadWith - titleWidth) / 2);
            if (titleX <= 0)
            {
                titleX = 1;
            }
            this.lbTitle.Location = new Point(titleX, this.lbTitle.Location.Y);
        }

        /// <summary>
        /// 将空值转为零
        /// </summary>
        /// <param name="dtCross"></param>
        private void ConverNullToZero(DataTable dtCross)
        {
            if (!this.replaceNullToZero)
            {
                return;
            }
            for (int i = 0; i < dtCross.Rows.Count; i++)
            {
                for (int j = 1; j < dtCross.Columns.Count; j++)
                {
                    if (string.IsNullOrEmpty(dtCross.Rows[i][j].ToString()))
                    {
                        try
                        {
                            dtCross.Rows[i][j] = "0";
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }

        #endregion 私有方法

        #region 保护方法
        /// <summary>
        /// 明细查询
        /// </summary>
        protected void ShowDetail()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索明细信息...请稍候");
                Application.DoEvents();

                this.dtDetail = this.GetDataTableBySql(this.sqlDetailId);

                this.neuSpread1_Sheet2.DataSource = this.dtDetail.DefaultView;

                //this.SetFormat(true);

                this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        #endregion 保护方法

        #region 公开方法
        #endregion 公开方法

        #endregion 方法

        #region 事件

        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCrosstabReport_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();
            return 1;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            if (MessageBox.Show("是否打印?", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return 1;
            }
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            //{8A00B362-C6FD-4f2d-B370-ED2AC6537FCC}增加纸张大小控制
            if (!string.IsNullOrEmpty(this.pageSize))
            {
                try
                {
                    string[] size = this.pageSize.Split(',');
                    int pwidth = Int32.Parse(size[0]);
                    int pheight = Int32.Parse(size[0]);
                    Neusoft.HISFC.Models.Base.PageSize page = new Neusoft.HISFC.Models.Base.PageSize();
                    page.Name = "crossReport";
                    page.WidthMM = pwidth;
                    page.HeightMM = pheight;
                    print.SetPageSize(page);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("纸张大小设置有误");
                    return -1;
                }
            }
            print.PrintPage(0, 0, this.plPrint);

            return 1;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show("导出成功");
            }

            return base.Export(sender, neuObject);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPreview(0, 0, this.plPrint);

            return 1;
        }
        /// <summary>
        /// 双击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader)
            {
                return;
            }

            if (this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text == "合计:" || this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Text == "合计:" || this.neuSpread1_Sheet1.Columns[this.neuSpread1_Sheet1.ActiveColumnIndex].Label.ToString() == "合计")
            {
                return;
            }

            if (string.IsNullOrEmpty(this.sqlDetailId))
            {
                return;
            }

            if (this.isHaveDept)
            {
                detailParm = new string[] { this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.cmbDept.Tag.ToString(), this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text.ToString(), this.neuSpread1_Sheet1.Columns[this.neuSpread1_Sheet1.ActiveColumnIndex].Label.ToString() };
            }
            else
            {
                detailParm = new string[] { this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text.ToString(), this.neuSpread1_Sheet1.Columns[this.neuSpread1_Sheet1.ActiveColumnIndex].Label.ToString() };
            }
            //显示详细信息
            this.ShowDetail();
        }
        #endregion 事件

        #region 接口实现
        #endregion 接口实现

    }
}