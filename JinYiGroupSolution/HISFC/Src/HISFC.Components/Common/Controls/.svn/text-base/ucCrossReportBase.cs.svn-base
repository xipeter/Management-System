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
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2009-4-13]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public abstract partial class ucCrossReportBase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        protected Hashtable htSQL = new Hashtable();

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCrossReportBase()
        {
            InitializeComponent();
            this.GetSql();
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

        private bool bFirstCrossTable;

        [Category("报表设置"), Description("首页是否交叉报表，默认为false")]
        public bool IsFirstCrossTable
        {
            get
            {
                return this.bFirstCrossTable;
            }
            set
            {
                this.bFirstCrossTable = value;
            }
        }

        #endregion 属性

        #region 方法

        #region 资源释放
        #endregion 资源释放

        #region 克隆
        #endregion 克隆

        #region 私有方法

        protected virtual void Init()
        {
            //科室查询条件
            if (this.isHaveDept)
            {
                //if (string.IsNullOrEmpty(this.privClass3Code.Trim()))
                //{
                //    Neusoft.HISFC.Integrate.Manager interMgr = new Neusoft.HISFC.Integrate.Manager();
                //    ArrayList alDept = interMgr.GetDepartment();
                //    this.cmbDept.AddItems(alDept);
                //}
                //else
                //{
                //    Neusoft.HISFC.Integrate.Manager managerIntegrate = new Neusoft.HISFC.Integrate.Manager();
                //    List<Neusoft.FrameWork.Object.NeuObject> alPrivDept = managerIntegrate.QueryUserPriv(Neusoft.FrameWork.Management.Connection.Operator.ID, this.privClass3Code.Trim());
                //    if (alPrivDept != null)
                //    {
                //        this.cmbDept.AddItems(new ArrayList(alPrivDept.ToArray()));
                //    }
                //}
                this.InitComboBox();
            }
            //this.InitComboBox();

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
                if (this.bFirstCrossTable)
                {
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
                }
                else
                {
                    this.neuSpread1.Sheets[0].DataSource = dt;
                }

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
                this.lbQueryInfo.Text += "  查询条件：" + this.cmbDept.Text;
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
                
                this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex + 1].DataSource = this.dtDetail.DefaultView;
                if (this.dtDetail.Rows.Count == 0)
                {
                    this.neuSpread1.Sheets.RemoveAt(this.neuSpread1.ActiveSheetIndex + 1);
                }

                //this.SetFormat(true);

                //this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet2;
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

        private void ShowDetail(string sqlID, FarPoint.Win.Spread.SheetView sv)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索明细信息...请稍候");
                Application.DoEvents();

                this.dtDetail = this.GetDataTableBySql(sqlID);

                //2009-8-31 合计

                //ArrayList alLength = new ArrayList();
                //int maxLength = 0;

                //foreach (DataColumn dc in this.dtDetail.Columns)
                //{
                //    foreach (DataRow dr in this.dtDetail.Rows)
                //    {
                //        if (maxLength < dr[dc].ToString().Length)
                //        {
                //            maxLength = dr[dc].ToString().Length;
                //        }
                //    }
                //    alLength.Add(maxLength);
                //}


                for (int i = 0; i < sv.Columns.Count; i++)
                {
                    //sv.Columns[i].Width = Neusoft.FrameWork.Function.NConvert.ToInt32(alLength[i]) * 10 ;//.GetPreferredWidth();
                    //sv.Columns[i].Width = sv.GetPreferredColumnWidth(i, true) + 10;
                    sv.Columns[i].Width = 80;
                }

                decimal total = 0m;
                DataTable dt = this.dtDetail;
                //如果无法合计,不要报错 {38F63C55-A810-47d4-A3D9-6968F3CE3BB5}  by shizj
                try
                {
                    int lastColumn = this.dtDetail.Columns.Count - 1;
                    foreach (DataRow dr in this.dtDetail.Rows)
                    {
                        total += Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[lastColumn].ToString());
                    }
                    DataRow newDR = this.dtDetail.NewRow();
                    newDR[0] = "合计：";
                    newDR[lastColumn] = total;
                    this.dtDetail.Rows.Add(newDR);
                }
                catch
                {
                    this.dtDetail = dt;
                }
                //2009-8-31 END

                sv.DataSource = this.dtDetail.DefaultView;

                //this.SetFormat(true);

                this.neuSpread1.ActiveSheet = sv;
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

            //if (this.neuSpread1.ActiveSheetIndex > 0)
            //{
            //    this.SetDate(this.neuSpread1.ActiveSheetIndex);
            //    if (string.IsNullOrEmpty(this.sqlstatement))
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(this.sqlDetailId))
            //    {
            //        return;
            //    }
            //}
            this.SetDate(this.neuSpread1.ActiveSheetIndex + 1);
            if (string.IsNullOrEmpty(this.sqlstatement))
            {
                return;
            }

            if (this.isHaveDept)
            {
                detailParm = new string[3 + this.neuSpread1.Sheets.Count];
                detailParm[0] = this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                detailParm[1] = this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                detailParm[2] = this.cmbDept.Tag.ToString();
                for (int i = 3; i < this.neuSpread1.Sheets.Count + 3; i++)
                {
                    detailParm[i] = this.neuSpread1.Sheets[i - 3].Cells[this.neuSpread1.Sheets[i - 3].ActiveRowIndex, 0].Text.ToString();
                    //detailParm = new string[] {this.neuSpread1.ActiveSheetIndex.Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 0].Text.ToString() };
                }
                //detailParm = new string[] { this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.cmbDept.Tag.ToString(), this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text.ToString(), this.neuSpread1_Sheet1.Columns[this.neuSpread1_Sheet1.ActiveColumnIndex].Label.ToString() };
            }
            else
            {
                detailParm = new string[2 + this.neuSpread1.Sheets.Count];
                detailParm[0] = this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                detailParm[1] = this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                for (int i = 2; i < this.neuSpread1.Sheets.Count + 2; i++)
                {
                    detailParm[i] = this.neuSpread1.Sheets[i - 2].Cells[this.neuSpread1.Sheets[i - 2].ActiveRowIndex, 0].Text.ToString();
                    //detailParm = new string[] { this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.neuSpread1.ActiveSheetIndex.Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 0].Text.ToString() };
                }
                //detailParm = new string[] { this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text.ToString(), this.neuSpread1_Sheet1.Columns[this.neuSpread1_Sheet1.ActiveColumnIndex].Label.ToString() };
            }


            //if(this.neuSpread1.ActiveSheetIndex > 0)
            //{
            //    this.AddSheetView();
            //    //if (this.neuSpread1.Sheets.Count == this.neuSpread1.ActiveSheetIndex + 1)
            //    //{
            //    //    this.neuSpread1.Sheets.RemoveAt(this.neuSpread1.ActiveSheetIndex + 1);
            //    //}
            //    this.ShowDetail(this.sqlstatement, this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex + 1]);
            //}
            //else
            //{
            //    this.AddSheetView();
            //    //显示详细信息
            //    this.ShowDetail();
            //}
            this.AddSheetView();
            this.ShowDetail(this.sqlstatement, this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex + 1]);
        }

        #endregion 事件

        #region 接口实现
        #endregion 接口实现

        protected virtual int SetData(string sqlText, FarPoint.Win.Spread.SheetView sv, bool IsCrossReport)
        {
            //if (sqlText == null || sqlText == "")
            //{
            //    return -1;
            //}

            //Neusoft.HISFC.Management.Manager.Report reportMgr = new Neusoft.HISFC.Management.Manager.Report(); 
            //DataSet ds = new DataSet();
            //if (reportMgr.ExecQuery(sqlText, ref ds) < 0)
            //{
            //    return -1;
            //}

            //if( IsCrossReport)
            //{
            //    sv.DataSource = this.GetCrossDataTable(ds.Tables[0]);
            //    if (sv.DataSource == null)
            //    {
            //        return -1;
            //    }
            //}
            //else
            //{
            //    return this.ShowDetail(sqlText, sv);
            //}
            return 1;
        }
        
        /// <summary>
        /// virtual虚方法(可重写)
        /// abstract方法是纯虚方法,(必须重写)
        /// </summary>
        /// <param name="sheetIndex"></param>
        protected virtual void SetDate(int sheetIndex)
        {
            IDictionaryEnumerator ide = this.htSQL.GetEnumerator();
            while (ide.MoveNext())
            {
                if (Neusoft.FrameWork.Function.NConvert.ToInt32(ide.Key) == sheetIndex)
                {
                    this.sqlstatement = ide.Value.ToString();
                    return;
                }
            }
            this.sqlstatement = string.Empty;

            //this.AddSheetView();
        }

        protected void SetGrid()
        {
            int index = this.neuSpread1.ActiveSheetIndex;
            for (int i = this.neuSpread1.ActiveSheetIndex, j = this.neuSpread1.Sheets.Count; i < j; i++)
            {
                if (index < i)
                {
                    this.neuSpread1.Sheets.RemoveAt(index + 1);
                }
            }
        }

        protected string sqlstatement = string.Empty;
        protected void AddSheetView()
        {
            this.SetGrid();
            FarPoint.Win.Spread.SheetView sv = new FarPoint.Win.Spread.SheetView();
            sv.SheetName = "明细";
            sv.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            sv.DataAutoSizeColumns = false;
            sv.Tag = this.sqlstatement;
            
            this.neuSpread1.Sheets.Add(sv);
            //this.neuSpread1.ActiveSheet = sv;
        }

        protected void SetActiveView()
        {
            this.neuSpread1.ActiveSheetIndex++;
        }

        protected virtual void InitComboBox()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager interMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alDept = interMgr.GetDepartment();
            this.cmbDept.AddItems(alDept);
        }

        protected abstract void GetSql();

        private void neuSpread1_ActiveSheetChanging(object sender, FarPoint.Win.Spread.ActiveSheetChangingEventArgs e)
        {
            if (e.ActivatedSheetIndex != 0)
            {
                this.neuPanel1.Enabled = false;
            }
            else
            {
                this.neuPanel1.Enabled = true;
            }
        }
    }
}