using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy.Report
{
    /// <summary>
    /// [控件名称:药品自定义查询]
    /// <修改记录>
    ///    1.设计了新的打印方式 by Sunjh 2009-3-13 {699DBE34-5DEA-4ba8-AFDD-A04364CFC8AD}
    ///    2.移植加入5.0 yangw 2010-05-18 {85997F7C-0E19-46e8-B552-2A60009747B4}
    /// </修改记录>
    /// </summary>
    public partial class ucCustomQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCustomQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 平均数计算时四舍五入精度
        /// </summary>
        private int decimalValue = 2;

        /// <summary>
        /// 平均数计算时四舍五入精度
        /// </summary>
        [Description("平均数计算时四舍五入精度"), Category("设置"), Browsable(true)]
        public int DecimalValue
        {
            get { return decimalValue; }
            set { decimalValue = value; }
        }

        /// <summary>
        /// SQL语句验证时时间间隔
        /// </summary>
        private int daysSpan = 100;

        /// <summary>
        /// SQL语句验证时时间间隔
        /// </summary>
        [Description("SQL语句验证时时间间隔"), Category("设置"), Browsable(true)]
        public int DaysSpan
        {
            get
            {
                return daysSpan;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                daysSpan = value;
            }
        }

        /// <summary>
        /// SQL语句验证时时间间隔最大值
        /// </summary>
        private int maxDaysSpan = 700;

        /// <summary>
        /// SQL语句验证时时间间隔最大值
        /// </summary>
        [Description("SQL语句验证时时间间隔最大值，超过最大值时停止验证"), Category("设置"), Browsable(true)]
        public int MaxDaysSpan
        {
            get { return maxDaysSpan; }
            set { maxDaysSpan = value; }
        }

        #region 变量
        private Neusoft.FrameWork.Management.DataBaseManger dbMgr = new Neusoft.FrameWork.Management.DataBaseManger();
        private Neusoft.HISFC.Components.Common.Controls.ucPrivePowerReport myReport = new Neusoft.HISFC.Components.Common.Controls.ucPrivePowerReport();
        private Neusoft.FrameWork.Models.NeuObject myPreDefine = new Neusoft.FrameWork.Models.NeuObject();
        private tvCustomQuery tvCustomQuery;
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        private string operCode = string.Empty;

        
        #endregion

        #region 属性

        /// <summary>
        /// 设置可以全部查看的工号
        /// </summary>
        [Category("控件设置"), Description("查询权限全有的工号")]
        public string OperCode
        {
            get
            {
                return operCode;
            }
            set
            {
                operCode = value;
            }
        }
        #endregion 

        #region 方法
        /// <summary>
        /// 设置报表控件属性
        /// </summary>
        private void setReportControlPerporty()
        {
            this.myReport.lbAdditionTitleMid.Text = "";
            this.myReport.lbAdditionTitleRight.Text = "";
            this.myReport.Dock = DockStyle.Fill;
            this.myReport.IsDeptAsCondition = false;
            this.myReport.QueryDataWhenInit = false;
            this.myReport.FilerType = Neusoft.HISFC.Components.Common.Controls.ucPrivePowerReport.EnumFilterType.汇总过滤;
        }

        /// <summary>
        /// 获取过滤求和的列
        /// </summary>
        /// <param name="filters">过滤字符串</param>
        /// <param name="sumCols">过滤列</param>
        /// <returns>-1失败</returns>
        private int getFilterAndSumCol(ref string filters, ref string sumCols)
        {
            int colIndex = -1;
            sumCols = "";
            filters = "";
            try
            {
                for (int rowIndex = 0; rowIndex < this.neuFpEnter1_Sheet1.RowCount; rowIndex++)
                {
                    //跳过没有选中的字段
                    if (!Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.选中].Value))
                    {
                        continue;
                    }

                    colIndex++;

                    string customField = neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.字段别名].Text;

                    //合计
                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.添加合计].Value))
                    {
                        sumCols += colIndex.ToString() + ",";
                    }

                    //过滤
                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.过滤].Value))
                    {
                        if (string.IsNullOrEmpty(customField))
                        {
                            filters += neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.字段名称].Text + ",";
                        }
                        else
                        {
                            filters += customField + ",";
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 检查SQl有效性
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="errInfo"></param>
        /// <returns></returns>
        private bool checkSQL(string sql, ref string errInfo)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("SQL验证中...");
            Application.DoEvents();

            if (!string.IsNullOrEmpty(sql) && sql.IndexOf("usercode") != -1)
            {
                sql = sql.Replace("usercode", dbMgr.Operator.ID);
            }


            System.Data.DataSet ds = new DataSet();
            string s = sql;
            int times = 0;
            if (s.IndexOf("{0}") != -1)
            {
                #region 含有时间参数
                while (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    s = sql;

                    s = string.Format(s, System.DateTime.Now.AddDays(-(DaysSpan + DaysSpan * times)).ToString(), System.DateTime.Now.ToString());

                    if (this.dbMgr.ExecQuery(s, ref ds) == -1)
                    {
                        errInfo = dbMgr.Err;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                        errInfo = "SQL无效\n---------------------\n"
                     + dbMgr.Err
                     + "\n---------------------\n"
                     + s;

                        return false;
                    }
                    if (times > 1)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        System.Windows.Forms.DialogResult dr;
                        dr = System.Windows.Forms.MessageBox.Show(
                            Neusoft.FrameWork.Management.Language.Msg("定义验证后才能生效，但是根据您的定义最近 " + (DaysSpan + DaysSpan * times).ToString() + " 天内没有可以查询的数据，是否扩大时间范围？"),
                            Neusoft.FrameWork.Management.Language.Msg("请确认"),
                            System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Question,
                            System.Windows.Forms.MessageBoxDefaultButton.Button2);
                        if (dr != DialogResult.Yes)
                        {
                            errInfo = "SQL验证取消";
                            return false;
                        }
                        Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("SQL验证中...");
                    }
                    if (DaysSpan + DaysSpan * times > MaxDaysSpan)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        errInfo = MaxDaysSpan.ToString() + "天内没有可查询数据，已经超过最大时间间隔，请检查定义是否正确！";
                        return false;
                    }

                    times++;
                }
                #endregion
            }
            else
            {
                #region 不含时间参数
                if (this.dbMgr.ExecQuery(s, ref ds) == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                    errInfo = "SQL无效\n---------------------\n"
                    + dbMgr.Err
                    + "\n---------------------\n"
                    + s;

                    return false;
                }
                #endregion
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            errInfo = "SQL验证成功\n---------------------\n" + s;
            return true;
        }

        /// <summary>
        /// 获取SQL语句
        /// </summary>
        /// <returns></returns>
        private Neusoft.FrameWork.Models.NeuObject getSQL()
        {
            //没有数据时返回
            if (myPreDefine == null || this.neuFpEnter1_Sheet1.RowCount == 0)
            {
                return null;
            }

            string sql = "SELECT {0} \nFROM   " + neuFpEnter1_Sheet1.Cells[0, (int)ColSet.视图].Text + "\n";

            //不显示重复的数据
            if (this.ckDistinct.Checked)
            {
                sql = "SELECT DISTINCT {0} \nFROM   " + neuFpEnter1_Sheet1.Cells[0, (int)ColSet.视图].Text + "\n";
            }

            string groupFields = "";                //纪录分组的字段，逗号隔开
            string fieldAndcustomFields = "";       //字段和字段别名，
            string sumCols = "";                    //求和的列
            string sortCols = "";                   //排序的列
            string filters = "";                    //过滤的列
            string customWheres = "";               //条件表达式 自定义的where条件
            int colIndex = -1;                      //列索引，由于求和，排序
            bool isNeedGroup = false;               //是否需要分组

            for (int rowIndex = 0; rowIndex < this.neuFpEnter1_Sheet1.RowCount; rowIndex++)
            {
                //自定义Where条件
                string customWhere = neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.条件表达式].Text;
                if (!string.IsNullOrEmpty(customWhere))
                {
                    customWheres += "\nAND    " + customWhere;
                }

                //跳过没有选中的字段
                if (!Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.选中].Value))
                {
                    continue;
                }

                //列索引必须记录 用户选择一列，字段没选择时不计入
                colIndex++;

                //字段别名
                string customField = neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.字段别名].Text;

                //字段
                string field = neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.视图].Text + "." + neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.字段名称].Text;

                //表达式 用表达式替换字段，但不替换字段别名
                string f = neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.字段表达式].Text;
                if (!string.IsNullOrEmpty(f))
                {
                    field = f;
                }

                //分组求和\平均，求和的字段不在group by 中，其它必须group by
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.平均数].Value))
                {
                    isNeedGroup = true;
                    field = "ROUND(AVG(" + field + "), " + DecimalValue.ToString() + ")";
                }
                else
                {
                    if (!Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.分组求和].Value))
                    {
                        //自定义了分组字段，则用自定义分组字段
                        string customGroup = neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.分组字段].Text;
                        if (string.IsNullOrEmpty(customGroup))
                        {
                            groupFields +=
                            neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.视图].Text
                            + "."
                            + neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.字段名称].Text;
                        }
                        else
                        {
                            groupFields += customGroup;
                        }
                        groupFields += ",\n       ";
                    }
                    else
                    {
                        isNeedGroup = true;
                        field = "SUM(" + field + ")";
                    }
                }

                fieldAndcustomFields += (colIndex == 0 ? "" : "       ")
                + field
                + " " + customField
                + ",\n";

                //合计
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.添加合计].Value))
                {
                    sumCols += colIndex.ToString() + ",";
                }

                //排序
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.排序].Value))
                {
                    sortCols += colIndex.ToString() + ",";
                }

                //过滤
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.过滤].Value))
                {
                    if (string.IsNullOrEmpty(customField))
                    {
                        filters += neuFpEnter1_Sheet1.Cells[rowIndex, (int)ColSet.字段名称].Text + ",";
                    }
                    else
                    {
                        filters += customField + ",";
                    }
                }

            }

            //没有选择字段，则查询全部
            if (string.IsNullOrEmpty(fieldAndcustomFields))
            {
                for (int row = 0; row < this.neuFpEnter1_Sheet1.RowCount; row++)
                {
                    this.neuFpEnter1_Sheet1.Cells[row, (int)ColSet.选中].Value = true;
                }
                sql = "SELECT * FROM " + neuFpEnter1_Sheet1.Cells[0, (int)ColSet.视图].Text + "\n";
            }
            else
            {
                sql = string.Format(sql, fieldAndcustomFields.TrimEnd(',', '\n'));
            }

            //分组
            if (!string.IsNullOrEmpty(groupFields) && isNeedGroup)
            {
                groupFields = "\nGROUP  BY " + groupFields;
                groupFields = groupFields.TrimEnd(',', '\n', ' ');
            }
            else
            {
                groupFields = "";
            }

            //强制where条件
            string sysWhere = this.myPreDefine.User01;
            if (!string.IsNullOrEmpty(sysWhere))
            {
                if (sysWhere.IndexOf("Local.CustomQuery") != -1)
                {
                    //保存后强制where被sql索引替换,重新获取
                    string view = "" + neuFpEnter1_Sheet1.Cells[0, (int)ColSet.视图].Text + "";
                    string getViewSql = "select sql_where from com_customquery_viewinfo where view_name = '{0}'";
                    getViewSql = string.Format(getViewSql, view.ToLower());
                    sysWhere = dbMgr.ExecSqlReturnOne(getViewSql);
                    if (sysWhere == "-1")
                    {
                        getViewSql = string.Format(getViewSql, view);
                        sysWhere = dbMgr.ExecSqlReturnOne(getViewSql);
                        if (sysWhere == "-1")
                        {
                            this.richTextBox1.SuperText = "获取强制条件发生错误\n" + dbMgr.Err;
                            return null;
                        }
                    }
                }

            }
            if (string.IsNullOrEmpty(sysWhere))
            {
                sysWhere = "\nWHERE  1=1 ";
            }

            //二级权限
            if (!string.IsNullOrEmpty(this.myPreDefine.User02))
            {
                // sysWhere = sysWhere.Replace("usercode", this.dbMgr.Operator.ID);
            }

            //sql检测
            string errInfo = "";
            string checkedSql = sql + sysWhere;
            checkedSql += customWheres + groupFields;
            if (!this.checkSQL(checkedSql, ref errInfo))
            {
                this.richTextBox1.SuperText = errInfo;
                this.neuTabControl1.SelectedIndex = 2;
                return null;
            }
            this.richTextBox1.SuperText = errInfo;

            sql += sysWhere + customWheres;//强制where

            sql += groupFields;//分组

            Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();

            o.ID = this.getSQLID();
            o.Memo = this.myPreDefine.Name;
            o.User03 = this.myPreDefine.Name;
            o.User01 = "";
            o.User02 = "自定义查询";
            o.Name = sql;

            if (string.IsNullOrEmpty(filters))
            {
                this.myReport.FilerType = Neusoft.HISFC.Components.Common.Controls.ucPrivePowerReport.EnumFilterType.不过滤;
            }
            else
            {
                this.myReport.FilerType = Neusoft.HISFC.Components.Common.Controls.ucPrivePowerReport.EnumFilterType.汇总过滤;
            }


            //查询结果报表属性赋值
            this.myReport.SQL = o.Name;
            this.myReport.Filters = filters;
            this.myReport.SumColIndexs = sumCols;
            this.myReport.SortColIndexs = sortCols;
            this.myReport.RightAdditionTitle = "";
            this.myReport.SQLIndexs = o.ID;

            this.myPreDefine.User03 = o.Name;

            return o;

        }

        /// <summary>
        /// 获取SQL语句索引
        /// </summary>
        /// <returns></returns>
        private string getSQLID()
        {
            if (string.IsNullOrEmpty(this.myPreDefine.ID) && !string.IsNullOrEmpty(this.myPreDefine.User01))
            {
                return this.myPreDefine.User01;
            }
            string SQLID = "Local.CustomQuery." + this.dbMgr.Operator.ID + "." + this.getID();
            return SQLID;
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        private string getID()
        {
            return
               System.DateTime.Now.Year.ToString()
               + System.DateTime.Now.Month.ToString().PadLeft(2, '0')
               + System.DateTime.Now.Day.ToString().PadLeft(2, '0')
               + System.DateTime.Now.Hour.ToString().PadLeft(2, '0')
               + System.DateTime.Now.Minute.ToString().PadLeft(2, '0')
               + System.DateTime.Now.Second.ToString().PadLeft(2, '0')
               + System.DateTime.Now.Millisecond.ToString().PadLeft(3, '0');
        }
        /// <summary>
        ///保存一条SQL信息 
        /// </summary>
        /// <param name="sqlManagerObject"></param>
        private int saveSqlInfo(Neusoft.FrameWork.Models.NeuObject sqlObject, ref string errInfo)
        {
            int iReturn = 0;
            string strSql = "insert into COM_SQL(ID,MEMO,TYPE,SPELL_CODE,MODUAL,INPUT,OUTPUT) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
            try
            {
                strSql = string.Format(strSql, sqlObject.ID, "用户定义", this.dbMgr.Operator.ID, sqlObject.User01, sqlObject.User02, "", "");
                //strSql = string.Format(strSql, sqlObject.ID, sqlObject.Memo, sqlObject.User03, sqlObject.User01, sqlObject.User02, "", "");
                iReturn = this.dbMgr.ExecNoQuery(strSql);

            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                errInfo = e.Message;
                return -1;
            }

            string StrSql = "";
            StrSql = "Update COM_SQL set  NAME=:a where id='{0}'";

            try
            {
                StrSql = string.Format(StrSql, sqlObject.ID);

                if (sqlObject.Name != "")
                {
                    if (this.dbMgr.InputLong(StrSql, sqlObject.Name) == -1)
                    {
                        errInfo = dbMgr.Err;
                        return -1;
                    }
                }
                else
                {
                    errInfo = "SQL为空";
                    return -1;
                }
            }
            catch (Exception e)
            {
                errInfo = e.Message;
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 保存定义信息
        /// </summary>
        /// <param name="sqlObject"></param>
        /// <param name="errInfo"></param>
        /// <returns></returns>
        private int saveDefineInfo(string sqlID, string defineXML, ref string errInfo)
        {
            int iReturn = 0;
            string strSql = "";
            string shareType = "Owner";
            if (this.rbDept.Checked)
            {
                shareType = "Dept";
            }
            if (this.rbAll.Checked)
            {
                shareType = "All";
            }
            if (dbMgr.Sql.GetSql("Local.CustomQuery.InsertDefineInfo", ref strSql) == -1)
            {
                errInfo = dbMgr.Err;
                return -1;
            }
            try
            {

                //插入
                this.tvCustomQuery.SelectedNode.EndEdit(false);
                strSql = string.Format(strSql, this.myPreDefine.ID,
                    dbMgr.Operator.ID,
                    this.tvCustomQuery.SelectedNode.Parent.Text,
                    this.tvCustomQuery.SelectedNode.Text,
                    sqlID,
                    dbMgr.Operator.ID,
                    shareType);
                iReturn = this.dbMgr.ExecNoQuery(strSql);

                //更新
                if (iReturn == -1)
                {
                    if (dbMgr.Sql.GetSql("Local.CustomQuery.UpdateDefineInfo", ref strSql) == -1)
                    {
                        errInfo = dbMgr.Err;
                        return -1;
                    }

                    strSql = string.Format(strSql, sqlID, this.tvCustomQuery.SelectedNode.Parent.Text,
                        this.tvCustomQuery.SelectedNode.Text, dbMgr.Operator.ID, shareType);

                    iReturn = this.dbMgr.ExecNoQuery(strSql);
                    if (iReturn != 1)
                    {
                        errInfo = dbMgr.Err;
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                errInfo = e.Message;
                return -1;
            }

            //更新long字段
            string StrSql = "";
            StrSql = "Update com_customquery_defineinfo set  define_xml =:a where sql_id='{0}'";

            try
            {
                StrSql = string.Format(StrSql, sqlID);

                if (defineXML != "")
                {
                    if (this.dbMgr.InputLong(StrSql, defineXML) == -1)
                    {
                        errInfo = dbMgr.Err;
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                errInfo = e.Message;
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="sqlID"></param>
        /// <param name="id"></param>
        private int deleteSqlInfo(string sqlID)
        {
            string strSql = "delete from COM_SQL where ID='{0}'";
            try
            {
                strSql = string.Format(strSql, sqlID);
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                if (dbMgr.ExecNoQuery(strSql) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.ShowMessageBox("删除SQL发生错误：" + dbMgr.Err, "错误");
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();

            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.ShowMessageBox("删除SQL发生错误：" + e.Message, "错误");

                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 显示用户定义的查询信息
        /// </summary>
        /// <param name="obj"></param>
        private void showDefine(Neusoft.FrameWork.Models.NeuObject obj)
        {

            if (obj == null)
            {
                return;
            }

            string sql = "";

            System.Data.DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(this.myPreDefine.ID))
            {
                this.neuTabControl1.SelectedIndex = 1;
                try
                {
                    //string path = Application.StartupPath + "\\Profile\\CustomQuery\\" + this.dbMgr.Operator.ID;
                    //string fileName = path
                    //        + "\\"
                    //        + obj.User01.Substring(obj.User01.LastIndexOf('.') + 1, obj.User01.Length - obj.User01.LastIndexOf('.') - 1)
                    //        + ".xml";

                    ////先从本地读取
                    //if (System.IO.File.Exists(fileName))
                    //{
                    //    ds.ReadXml(fileName);
                    //    this.neuFpEnter1_Sheet1.DataSource = ds;
                    //    return;
                    //}
                    //else
                    //{
                    //下载到本地
                    //if (!System.IO.Directory.Exists(path))
                    //{
                    //    System.IO.Directory.CreateDirectory(path);
                    //}

                    sql = @"select define_xml from com_customquery_defineinfo where sql_id = '{0}'";
                    sql = string.Format(sql, obj.User01);
                    string xml = dbMgr.ExecSqlReturnOne(sql);
                    if (xml == "-1")
                    {
                        this.ShowMessageBox("获取自定义xml发生错误" + dbMgr.Err, "错误");
                        return;
                    }

                    //System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false);
                    //sw.Write(xml);
                    //sw.Close();
                    //ds.ReadXml(fileName);

                    System.IO.StringReader sr = new System.IO.StringReader(xml);
                    ds.ReadXml(sr);

                    this.neuFpEnter1_Sheet1.DataSource = ds;
                    return;
                    //}
                }
                catch (Exception ex)
                {
                    this.ShowMessageBox(ex.Message, "错误");
                    return;
                }
            }
            else
            {
                this.neuTabControl1.SelectedIndex = 0;
            }

            sql = @"select distinct
                            table_name 视图,
                            column_name 字段名称,
                              '' 选中,
                              '' 字段别名,
                              '' 排序,
                              '' 添加合计,
                              '' 过滤,
                              '' 分组字段,
                              '' 分组求和,
                              '' 平均数,
                              '' 字段表达式,
                              '' 条件表达式,
                              '' 备注,
                              '' 顺序号
                            from all_col_comments
                            where table_name = '{0}'";
            sql = string.Format(sql, obj.ID.ToUpper());
            if (this.dbMgr.ExecQuery(sql, ref ds) == -1)
            {
                MessageBox.Show("" + this.dbMgr.Err);
                return;
            }

            this.neuFpEnter1_Sheet1.DataSource = ds;
        }

        /// <summary>
        /// 设置Farpoint
        /// </summary>
        private void setFP()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\Profile\\CustomQuery\\PreDefine.xml"))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuFpEnter1_Sheet1, Application.StartupPath + "\\Profile\\CustomQuery\\PreDefine.xml");
            }
            else
            {
                FarPoint.Win.Spread.CellType.CheckBoxCellType c = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                this.neuFpEnter1_Sheet1.Columns[(int)ColSet.过滤].CellType = c;
                this.neuFpEnter1_Sheet1.Columns[(int)ColSet.添加合计].CellType = c;
                this.neuFpEnter1_Sheet1.Columns[(int)ColSet.排序].CellType = c;
                this.neuFpEnter1_Sheet1.Columns[(int)ColSet.分组求和].CellType = c;
                this.neuFpEnter1_Sheet1.Columns[(int)ColSet.选中].CellType = c;
                this.neuFpEnter1_Sheet1.Columns[(int)ColSet.平均数].CellType = c;


            }

            FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
            t.ReadOnly = true;
            this.neuFpEnter1_Sheet1.Columns[(int)ColSet.视图].CellType = t;
            this.neuFpEnter1_Sheet1.Columns[(int)ColSet.字段名称].CellType = t;

            this.neuFpEnter1_Sheet1.Columns[(int)ColSet.字段名称].ShowSortIndicator = true;
            this.neuFpEnter1_Sheet1.Columns[(int)ColSet.备注].ShowSortIndicator = true;
            this.neuFpEnter1_Sheet1.Columns[(int)ColSet.字段名称].AllowAutoSort = true;
            this.neuFpEnter1_Sheet1.Columns[(int)ColSet.备注].AllowAutoSort = true;

            this.neuFpEnter1_Sheet1.Columns[(int)ColSet.分组字段].Width = 0F;
            this.neuFpEnter1_Sheet1.ColumnHeader.Rows[0].Height = 36f;

            //int sortColumnIndex = this.neuFpEnter1_Sheet1.Columns.Count;
            //this.neuFpEnter1_Sheet1.Columns.Add(sortColumnIndex, 1);
            //this.neuFpEnter1_Sheet1.Columns[sortColumnIndex].Label = "顺序号";

            //for (int i = 0; i < this.neuFpEnter1_Sheet1.Rows.Count; i++)
            //{
            //    this.neuFpEnter1_Sheet1.Cells[i, sortColumnIndex].Text = (i + 1).ToString();
            //}

            this.neuFpEnter1_Sheet1.SortRows((int)ColSet.顺序号, true, false);

        }

        /// <summary>
        /// 显示MessageBox
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="caption">标题</param>
        private void ShowMessageBox(string text, string caption)
        {
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(text), Neusoft.FrameWork.Management.Language.Msg(caption));
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int save()
        {
            this.neuFpEnter1_Sheet1.SortRows((int)ColSet.顺序号,true, false);

            //自定义保存
            Neusoft.FrameWork.Models.NeuObject o = this.getSQL();
            if (o == null)
            {
                //
                return -1;
            }
            string errInfo = "";

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.dbMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.saveSqlInfo(o, ref errInfo) != -1)
            {
                try
                {
                    //string path = Application.StartupPath + "\\Profile\\CustomQuery\\" + this.dbMgr.Operator.ID;
                    //if (!System.IO.Directory.Exists(path))
                    //{
                    //    System.IO.Directory.CreateDirectory(path);
                    //}
                    //string fileName = path
                    //+ "\\"
                    //+ o.ID.Substring(o.ID.LastIndexOf('.') + 1, o.ID.Length - o.ID.LastIndexOf('.') - 1)
                    //+ ".xml";

                    System.Data.DataSet ds = this.neuFpEnter1_Sheet1.DataSource as System.Data.DataSet;
                    if (ds != null)
                    {
                        //string xml = ds.GetXmlSchema();
                        System.IO.StringWriter sw = new System.IO.StringWriter();

                        ds.WriteXml(sw, XmlWriteMode.WriteSchema);
                        string xml = sw.ToString();
                        sw.Close();

                        //ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
                        //if (System.IO.File.Exists(fileName))
                        //{
                        //string xml = System.IO.File.ReadAllText(fileName);
                        if (this.saveDefineInfo(o.ID, xml, ref errInfo) != -1)
                        {
                            this.myPreDefine.ID = "";
                            this.myPreDefine.User01 = o.ID;
                            this.myPreDefine.User03 = o.Name;
                        }
                        else
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.ShowMessageBox(errInfo, "错误");
                            return -1;
                        }
                        // }

                    }

                }
                catch (Exception ex)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.ShowMessageBox(ex.Message, "错误");
                    return -1;
                }
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.ShowMessageBox(errInfo, "错误");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            return 1;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        private int query()
        {
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(this.myPreDefine.ID))//预定义，新建定义时
                {
                    //报表中sql赋值
                    if (this.getSQL() == null)
                    {
                        return -1;
                    }
                    this.neuTabControl1.SelectedIndex = 1;
                }
                else
                {
                    if (this.neuFpEnter1_Sheet1.RowCount > 0)
                    {
                        if (this.getSQL() == null)
                        {
                            return -1;
                        }
                        this.neuTabControl1.SelectedIndex = 1;
                    }
                }
            }
            else if (this.neuTabControl1.SelectedIndex == 2)
            {
                return -1;
            }
            else//已经定义
            {
                if (string.IsNullOrEmpty(this.myPreDefine.User03) && !string.IsNullOrEmpty(this.myPreDefine.User01))
                {
                    if (this.dbMgr.Sql.GetSql(this.myPreDefine.User01, ref this.myPreDefine.User03) == -1)
                    {
                        string sql = @"select name from com_sql where id = '{0}'";
                        sql = string.Format(sql, this.myPreDefine.User01);
                        this.myPreDefine.User03 = this.dbMgr.ExecSqlReturnOne(sql);
                    }
                }
                if (string.IsNullOrEmpty(myReport.Filters) || string.IsNullOrEmpty(myReport.SumColIndexs))
                {
                    string filters = "";
                    string sumCols = "";
                    this.getFilterAndSumCol(ref filters, ref sumCols);
                    myReport.SumColIndexs = sumCols;
                    myReport.Filters = filters;
                }
                this.myReport.SQL = this.myPreDefine.User03;
                this.myReport.SQLIndexs = this.myPreDefine.User01;
            }

            //配置文件
            string fileName = Application.StartupPath
                            + "\\Profile\\CustomQuery\\"
                            + this.dbMgr.Operator.ID
                            + "\\"
                            + this.getSQLID()
                            + ".xml";

            this.myReport.SettingFilePatch = fileName;

            //清除已经赋值的列头名称
            if (!System.IO.File.Exists(fileName))
            {
                this.myReport.fpSpread1_Sheet1.RowCount = 0;
                this.myReport.fpSpread1_Sheet1.Columns.Count = 0;
                this.myReport.fpSpread1_Sheet1.DataSource = null;
            }


            this.myReport.lbMainTitle.Text = this.tvCustomQuery.SelectedNode.Text;

            if (!string.IsNullOrEmpty(myReport.SQL) && !string.IsNullOrEmpty(this.myPreDefine.User02) && myReport.SQL.IndexOf("usercode") != -1)
            {
                myReport.SQL = myReport.SQL.Replace("usercode", dbMgr.Operator.ID);
            }
            if (string.IsNullOrEmpty(this.myReport.SQL) || myReport.SQL == "-1")
            {
                this.ShowMessageBox("定义不正确", "错误");
                return -1;
            }
            this.myReport.QueryData();

            this.myReport.lbAdditionTitleMid.Text = "";
            this.myReport.lbAdditionTitleRight.Text = "";

            //this.isQueryEnd = true;
            return 1;
        }

        /// <summary>
        /// 删除 不可以删除别人共享的查询，不删除com_sql中的sql
        /// </summary>
        /// <returns></returns>
        private int delete(ref string errInfo)
        {
            string text = this.tvCustomQuery.SelectedNode.Text;
            System.Windows.Forms.DialogResult dr = MessageBox.Show(this, "您确实要删除" + text + "吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return 1;
            }
            TreeNode node = this.tvCustomQuery.SelectedNode;

            string sql = "";
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.dbMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //业务根节点删除
            if (node.Parent == null)
            {
                if (node.Nodes.Count == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return 1;
                }
                sql = @"delete from com_customquery_defineinfo where view_name = '{0}' and owner = '{1}'";
                sql = string.Format(sql, this.myPreDefine.ID, dbMgr.Operator.ID);
                if (dbMgr.ExecQuery(sql) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    errInfo = dbMgr.Err;
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();

                node.Nodes.Clear();
                return 1;
            }

            //文件夹
            if (!string.IsNullOrEmpty(this.myPreDefine.ID))
            {
                //新建的文件夹直接删除，否则删除文件夹所有
                if (node.Nodes.Count > 0)
                {
                    sql = @"delete from com_customquery_defineinfo where view_name = '{0}' and owner = '{1}' and type = '{2}'";
                    sql = string.Format(sql, this.myPreDefine.ID, dbMgr.Operator.ID, this.myPreDefine.Name);
                    if (dbMgr.ExecQuery(sql) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        errInfo = dbMgr.Err;
                        return -1;
                    }
                }
                node.Parent.Nodes.Remove(node);

            }
            else//单个查询
            {
                //没有保存的直接删除
                if (!string.IsNullOrEmpty(this.myPreDefine.User03))
                {
                    sql = @"delete from com_customquery_defineinfo where sql_id = '{0}' and owner = '{1}'";
                    sql = string.Format(sql, this.myPreDefine.User01, dbMgr.Operator.ID);
                    if (dbMgr.ExecQuery(sql) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        errInfo = dbMgr.Err;
                        return -1;
                    }
                }
                node.Parent.Nodes.Remove(node);
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        private void deleteDefine()
        {
            string errInfo = "";
            if (this.delete(ref errInfo) == -1)
            {
                this.ShowMessageBox(errInfo, "错误");
            }
            else
            {
                this.ShowMessageBox("删除成功！", "提示");
            }
        }
        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            if (!(Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager && !this.OperCode.Contains(Neusoft.FrameWork.Management.Connection.Operator.ID.ToString()))
            {//自定义组合查询功能准备去掉，灵活的配置不适用中日 20091213
                this.neuTabControl1.TabPages.RemoveAt(0);
            }

            this.neuFpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            base.OnLoad(e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.save() == 1)
            {
                //防止再获取sql语句
                this.neuTabControl1.SelectedIndex = 1;

                //删除配置文件
                try
                {
                    if (System.IO.File.Exists(this.myReport.SettingFilePatch))
                    {
                        System.IO.File.Delete(this.myReport.SettingFilePatch);
                    }
                }
                catch
                { }

                //查询
                this.query();

                //自动设置配置文件
                try
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(myReport.fpSpread1_Sheet1, myReport.SettingFilePatch);
                }
                catch
                {
                }

                this.ShowMessageBox(this.tvCustomQuery.SelectedNode.Text + "保存成功", "提示");
            }
            return 1;
            //return base.OnSave(sender, neuObject);
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            return this.query();
            //return base.OnQuery(sender, neuObject);
        }
        protected override int OnSetValue(object neuObject, TreeNode e)
        {

            if (e.Tag == null)
            {
                return -1;
            }

            Neusoft.FrameWork.Models.NeuObject obj = e.Tag as Neusoft.FrameWork.Models.NeuObject;
            this.myPreDefine = obj;

            if (this.tvCustomQuery == null)
            {
                this.tvCustomQuery = this.tv as tvCustomQuery;
                this.tvCustomQuery.DeleteDefineHandler += new tvCustomQuery.DeleteDefine(this.deleteDefine);
            }


            //不是自定义查询不能设置
            if (e.ImageIndex < 4)
            {
                if (this.neuFpEnter1_Sheet1.DataSource != null && this.neuFpEnter1_Sheet1.DataSource.GetType() == typeof(System.Data.DataSet))
                {
                    (this.neuFpEnter1_Sheet1.DataSource as System.Data.DataSet).Clear();
                }
                this.neuFpEnter1_Sheet1.RowCount = 0;
                this.setFP();
                this.neuTabControl1.SelectedIndex = 0;
                return 1;
            }

            //显示定义
            this.showDefine(obj);
            this.setFP();

            if (this.neuTabControl1.SelectedIndex == 1)
            {
                this.query();
            }

            return base.OnSetValue(neuObject, e);
        }
        protected override int OnPrint(object sender, object neuObject)
        {
            //this.myReport.PrintData();
            //屏蔽上一句，使用下面两句实现打印功能 by Sunjh 2009-3-13 {699DBE34-5DEA-4ba8-AFDD-A04364CFC8AD}
            Neusoft.FrameWork.WinForms.Classes.Print pp = new Neusoft.FrameWork.WinForms.Classes.Print();
            pp.PrintPreview(this.myReport.neuGroupBox2);
            return base.OnPrint(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            this.myReport.ExportData();
            return base.Export(sender, neuObject);
        }
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.setReportControlPerporty();
            this.tabPage2.Controls.Add(myReport);

            this.neuFpEnter1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(neuFpEnter1_CellDoubleClick);
            this.neuFpEnter1.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(neuFpEnter1_ColumnWidthChanged);

            this.toolBarService.AddToolButton("删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            return base.OnInit(sender, neuObject, param);
        }

        void neuFpEnter1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader)
            {
                if (e.Column == (int)ColSet.选中 && this.neuFpEnter1_Sheet1.RowCount > 0)
                {
                    bool isChoosed = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuFpEnter1_Sheet1.Cells[0, e.Column].Value);

                    for (int row = 0; row < this.neuFpEnter1_Sheet1.RowCount; row++)
                    {
                        this.neuFpEnter1_Sheet1.Cells[row, e.Column].Value = isChoosed;
                    }
                }
            }
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除")
            {
                deleteDefine();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        void neuFpEnter1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuFpEnter1_Sheet1, Application.StartupPath + "\\Profile\\CustomQuery\\PreDefine.xml");
        }
        #endregion

        /// <summary>
        /// 列枚举
        /// </summary>
        enum ColSet
        {
            视图,
            字段名称,
            选中,
            字段别名,
            排序,
            添加合计,
            过滤,
            分组字段,
            分组求和,
            平均数,
            字段表达式,
            条件表达式,
            备注,
            顺序号
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int nowIndex = this.neuFpEnter1_Sheet1.ActiveRowIndex;
            if (nowIndex == 0)
            {
                return;
            }

            string currentSort = this.neuFpEnter1_Sheet1.Cells[nowIndex, (int)ColSet.顺序号].Text;

            this.neuFpEnter1_Sheet1.Cells[nowIndex, (int)ColSet.顺序号].Text = this.neuFpEnter1_Sheet1.Cells[nowIndex - 1, (int)ColSet.顺序号].Text;
            this.neuFpEnter1_Sheet1.Cells[nowIndex, (int)ColSet.顺序号].Text = currentSort;

            this.neuFpEnter1_Sheet1.SortRows((int)ColSet.顺序号, true, false);
        }
    }
}
