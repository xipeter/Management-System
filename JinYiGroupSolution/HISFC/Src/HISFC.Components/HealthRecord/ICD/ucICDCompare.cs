using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
namespace Neusoft.HISFC.Components.HealthRecord.ICD
{
    /// <summary>
    /// ucICDCompare<br></br>
    /// [功能描述: 病案ICD对照]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-20]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucICDCompare :Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucICDCompare()
        {
            InitializeComponent();
        }

        #region  变量

        //控制用哪个字段检索
        private int circle = 0;
        //定义Table  存储ICD10信息 
        private DataTable dtICD10 = null;
        //定义 DataView 用来筛选ICD10 数据
        private DataView dvICD10 = null;
        //配置文件路径
        private string filePath10 = Application.StartupPath + "\\profile\\ICD10Compare.xml";
        //定义对照类
        private Neusoft.HISFC.Models.HealthRecord.ICDCompare icdCompare = new Neusoft.HISFC.Models.HealthRecord.ICDCompare();
        //定义Table  存储ICD9信息 
        private DataTable dtICD9 = null;
        //定义 DataView 用来筛选ICD9 数据
        private DataView dvICD9 = null;
        //配置文件路径
        private string filePath9 = Application.StartupPath + "\\profile\\ICD9Compare.xml";

        //定义Table  存储ICD10信息 
        private DataTable dtICDCompare = null;
        //定义 DataView 用来筛选ICD对照 数据
        private DataView dvICDCompare = null;
        //配置文件路径
        private string filePathCompare = Application.StartupPath + "\\profile\\ICDCompare.xml";

        //ICD业务层
        private Neusoft.HISFC.BizLogic.HealthRecord.ICD myICD = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();
        //		//定义字符串，存储筛选码
        //		private string code ="拼音码";
        #endregion

        #region 属性
        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("对照", "对照", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("删除", "删除", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("清空", "清空", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null); 
            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "对照":
                    CompareICD();
                    break;
                case "删除":
                    CancelICD();
                    break;
                case "清空":
                    ClearICD();
                    break; 
                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region 窗体控件 事件
        /// <summary>
        /// 窗体的LOAD事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucICDCompare_Load(object sender, System.EventArgs e)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
                Application.DoEvents();

                //查询并填充未对照的ICD0
                LoadAndAddDateToICD10();
                //查询并填充未对照的ICD09
                LoadAndAddDateToICD9();
                //查询并填充未对照的ICDCompare
                LoadAndAddDateToICDCompare();

                this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                this.fpSpread2_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                this.fpSpread3_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 实例化 Table 查询数据 并填充数据 
        /// </summary>
        private void LoadAndAddDateToICD10()
        {
            dtICD10 = new DataTable("ICD 10维护");
            //如果配置文件存在,通过配置文件生成DataTable dtICD列信息,并绑定fp
            if (File.Exists(filePath10))
            {
                //定义DataTable
                Function.CreatColumnByXML(filePath10, dtICD10, ref dvICD10, this.fpSpread1_Sheet1);
                //设置主键为sequence_no列
                CreateKeys(dtICD10);
            }
            else//如果配置文件不存在,代码生成配置文件
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);

                dtICD10.Columns.AddRange(new DataColumn[]{new DataColumn("sequence_no", strType),
														   new DataColumn("诊断码", strType),
														   new DataColumn("医保中心代码", strType),
														   new DataColumn("统计代码", strType),
														   new DataColumn("拼音码", strType),
														   new DataColumn("五笔码", strType),
														   new DataColumn("诊断名称", strType),
														   new DataColumn("第二诊断名称", strType),
														   new DataColumn("第三诊断名称", strType),
														   new DataColumn("死亡原因", strType),
														   new DataColumn("疾病分类", strType),
														   new DataColumn("标准住院日", intType),
														   new DataColumn("30种疾病", boolType),
														   new DataColumn("传染病", boolType),
														   new DataColumn("肿瘤", boolType),
														   new DataColumn("住院等级", strType),
														   new DataColumn("有效性", boolType),
														   new DataColumn("序号", strType),
														   new DataColumn("操作员编码", strType),
														   new DataColumn("操作员", strType),
														   new DataColumn("操作时间", dtType)});

                //设置主键为sequence_no列
                CreateKeys(dtICD10);
                dvICD10 = new DataView(dtICD10);
                this.fpSpread1_Sheet1.DataSource = dvICD10;
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, filePath10);
            }
            ArrayList alReturn = new ArrayList();//返回的ICD信息;
            //获得有效的ICD10信息
            alReturn = myICD.Query(ICDTypes.ICD10, QueryTypes.Valid);
            if (alReturn == null)
            {
                MessageBox.Show("获得ICD信息出错!" + myICD.Err);
                return;
            }
            //循环插入信息
            foreach (Neusoft.HISFC.Models.HealthRecord.ICD obj in alReturn)
            {
                DataRow row = dtICD10.NewRow();
                SetRow(obj, row);
                dtICD10.Rows.Add(row);
            }
            dtICD10.AcceptChanges();
            //设置fpSpread1 的属性
            if (System.IO.File.Exists(filePath10))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, filePath10);
            }
        }
        /// <summary>
        /// 实例化 Table 查询数据 并填充数据 
        /// </summary>
        private void LoadAndAddDateToICD9()
        {
            dtICD9 = new DataTable("ICD 9 维护");
            //如果配置文件存在,通过配置文件生成DataTable dtICD列信息,并绑定fp
            if (File.Exists(filePath9))
            {
                //定义DataTable
                Function.CreatColumnByXML(filePath9, dtICD9, ref dvICD9, this.fpSpread2_Sheet1);
                //设置主键为sequence_no列
                CreateKeys(dtICD9);
            }
            else//如果配置文件不存在,代码生成配置文件
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);

                dtICD9.Columns.AddRange(new DataColumn[]{new DataColumn("sequence_no", strType),
															 new DataColumn("诊断码", strType),
															 new DataColumn("医保中心代码", strType),
															 new DataColumn("统计代码", strType),
															 new DataColumn("拼音码", strType),
															 new DataColumn("五笔码", strType),
															 new DataColumn("诊断名称", strType),
															 new DataColumn("第二诊断名称", strType),
															 new DataColumn("第三诊断名称", strType),
															 new DataColumn("死亡原因", strType),
															 new DataColumn("疾病分类", strType),
															 new DataColumn("标准住院日", intType),
															 new DataColumn("30种疾病", boolType),
															 new DataColumn("传染病", boolType),
															 new DataColumn("肿瘤", boolType),
															 new DataColumn("住院等级", strType),
															 new DataColumn("有效性", boolType),
															 new DataColumn("序号", strType),
															 new DataColumn("操作员编码",strType),
															 new DataColumn("操作员", strType),
															 new DataColumn("操作时间", dtType)});

                //设置主键为sequence_no列
                CreateKeys(dtICD9);
                dvICD9 = new DataView(dtICD9);
                this.fpSpread2_Sheet1.DataSource = dvICD9;
                //保存网格的宽度
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread2_Sheet1, filePath9);
            }
            ArrayList alReturn = new ArrayList();//返回的ICD信息;
            //获得未对照的ICD9信息
            alReturn = myICD.QueryNoComparedICD9(QueryTypes.Valid);
            if (alReturn == null)
            {
                MessageBox.Show("获得ICD信息出错!" + myICD.Err);
                return;
            }
            //循环插入信息
            foreach (Neusoft.HISFC.Models.HealthRecord.ICD obj in alReturn)
            {
                DataRow row = dtICD9.NewRow();
                SetRow(obj, row);
                dtICD9.Rows.Add(row);
            }
            dtICD9.AcceptChanges();
            //设置fpSpread1 的属性
            if (System.IO.File.Exists(filePath9))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread2_Sheet1, filePath9);
            }
        }
        /// <summary>
        /// 实例化 Table 查询数据 并填充数据 
        /// </summary>
        private void LoadAndAddDateToICDCompare()
        {
            dtICDCompare = new DataTable("ICD Compare 维护");
            //如果配置文件存在,通过配置文件生成DataTable dtICD列信息,并绑定fp
            if (File.Exists(filePathCompare))
            {
                //定义DataTable
                Function.CreatColumnByXML(filePathCompare, dtICDCompare, ref dvICDCompare, this.fpSpread3_Sheet1);
                //设置主键为sequence_no列
                CreateKeys(dtICDCompare);
            }
            else//如果配置文件不存在,代码生成配置文件
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);

                dtICDCompare.Columns.AddRange(new DataColumn[]{   new DataColumn("诊断码9", strType),
																  new DataColumn("诊断名称9", strType),
																  new DataColumn("诊断码10", strType),
																  new DataColumn("诊断名称10", strType),
																  new DataColumn("拼音码", strType),
																  new DataColumn("统计代码", strType),
																  new DataColumn("有效性", boolType),
																  new DataColumn("sequence_no", strType),
																  new DataColumn("操作员编码", strType),
																  new DataColumn("操作员", strType),
																  new DataColumn("操作时间", dtType)});

                //设置主键为sequence_no列
                CreateKeys(dtICDCompare);
                dvICDCompare = new DataView(dtICDCompare);
                this.fpSpread3_Sheet1.DataSource = dvICDCompare;
                //保存网格的宽度
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread3_Sheet1, filePathCompare);
            }
            ArrayList alReturn = new ArrayList();//返回的ICD信息;
            //获得未对照的ICD9信息
            alReturn = myICD.QueryComparedICD();
            if (alReturn == null)
            {
                MessageBox.Show("获得ICD信息出错!" + myICD.Err);
                return;
            }
            //循环插入信息
            foreach (Neusoft.HISFC.Models.HealthRecord.ICDCompare obj in alReturn)
            {
                DataRow row = dtICDCompare.NewRow();
                SetRowCompare(obj, row);
                dtICDCompare.Rows.Add(row);
            }
            dtICDCompare.AcceptChanges();
            //设置fpSpread1 的属性
            if (System.IO.File.Exists(filePathCompare))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread3_Sheet1, filePathCompare);
            }
        }
        /// <summary>
        /// 向对照表添加一行
        /// </summary>
        /// <param name="obj">对照信息</param>
        /// <param name="row"></param>
        private void SetRowCompare(Neusoft.HISFC.Models.HealthRecord.ICDCompare obj, DataRow row)
        {
            row["诊断码9"] = obj.ICD9.ID;
            row["诊断名称9"] = obj.ICD9.Name;

            row["诊断码10"] = obj.ICD10.ID;
            row["诊断名称10"] = obj.ICD10.Name;

            row["拼音码"] = obj.ICD9.SpellCode;
            row["统计代码"] = obj.ICD9.UserCode;

            row["有效性"] = obj.IsValid;
            row["sequence_no"] = obj.ICD9.KeyCode;
            row["操作员编码"] = obj.OperInfo.ID;
            row["操作员"] = obj.OperInfo.Name;
            row["操作时间"] = obj.OperInfo.OperTime;
        }
        /// <summary>
        /// 在Table 中添加加一行
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>
        private void SetRow(Neusoft.HISFC.Models.HealthRecord.ICD obj, DataRow row)
        {
            row["sequence_no"] = obj.KeyCode;
            row["诊断码"] = obj.ID;
            row["医保中心代码"] = obj.SICode;
            row["统计代码"] = obj.UserCode;
            row["拼音码"] = obj.SpellCode;
            row["五笔码"] = obj.WBCode;
            row["诊断名称"] = obj.Name;
            row["第二诊断名称"] = obj.User01;
            row["第三诊断名称"] = obj.User02;
            row["死亡原因"] = obj.DeadReason;
            row["疾病分类"] = obj.DiseaseCode;
            row["标准住院日"] = obj.StandardDays;
            row["30种疾病"] = Neusoft.FrameWork.Function.NConvert.ToBoolean(obj.Is30Illness);
            row["传染病"] = Neusoft.FrameWork.Function.NConvert.ToBoolean(obj.IsInfection);
            row["肿瘤"] = Neusoft.FrameWork.Function.NConvert.ToBoolean(obj.IsTumour);
            row["住院等级"] = obj.InpGrade;
            row["有效性"] = obj.IsValid;
            row["序号"] = obj.SeqNo;
            row["操作员编码"] = obj.OperInfo.ID;
            row["操作员"] = obj.OperInfo.Name;
            row["操作时间"] = obj.OperInfo.OperTime;
        }
        /// <summary>
        ///设置主键,为列sequence_no
        /// </summary>
        private void CreateKeys(DataTable table)
        {
            DataColumn[] keys = new DataColumn[] { table.Columns["sequence_no"] };
            table.PrimaryKey = keys;
        }
        /// <summary>
        /// 查询ICD10 并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchICD10_TextChanged(object sender, System.EventArgs e)
        {
            //筛选
            dvICD10.RowFilter = FilterItem(textSearchICD10.Text);
            //设置fpSpread1 的属性
            if (System.IO.File.Exists(filePath10))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, filePath10);
            }
        }
        /// <summary>
        /// 查询ICD9 并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchICD9_TextChanged(object sender, System.EventArgs e)
        {
            //筛选
            dvICD9.RowFilter = FilterItem(textSearchICD9.Text);
            //设置fpSpread1 的属性
            if (System.IO.File.Exists(filePath9))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread2_Sheet1, filePath9);
            }
        }
        /// <summary>
        /// 查询ICD对照 并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {
            //筛选
            dvICDCompare.RowFilter = FilterItem(textBox5.Text);
            //设置fpSpread1 的属性
            if (System.IO.File.Exists(filePathCompare))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread3_Sheet1, filePathCompare);
            }
        }
        /// <summary>
        /// 组建筛选字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string FilterItem(string input)
        {
            //定义要返回的字符串
            string filterString = "";
            try
            {

                filterString = textBox6.Text + " like '" + input + "%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return filterString;
        }
        /// <summary>
        /// ICD9 查询的回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchICD9_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //获取数据，填充到TexBox中
                AddinfoICD9();
                this.tabControl1.SelectedIndex = 1;
                textSearchICD10.Focus();
            }
        }
        /// <summary>
        /// 确定 显示哪个界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchICD9_Enter(object sender, System.EventArgs e)
        {
            //显示ICD9 界面
            this.tabControl1.SelectedIndex = 0;
            this.textSearchICD9.Focus();
        }
        /// <summary>
        /// 确定 显示哪个界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchICD10_Enter(object sender, System.EventArgs e)
        {
            //显示ICD10 界面
            this.tabControl1.SelectedIndex = 1;
            this.textSearchICD10.Focus();
        }
        /// <summary>
        /// 确定 显示哪个界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox5_Enter(object sender, System.EventArgs e)
        {
            //显示对照界面
            this.tabControl1.SelectedIndex = 2;
            this.textBox5.Focus();
        }
        /// <summary>
        /// 回车事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox5_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.tabControl1.SelectedIndex = 0;
                textSearchICD9.Focus();
            }
        }
        /// <summary>
        /// 获取ICD9数据，填充到TexBox中 这里是暂存
        /// </summary>
        private void AddinfoICD9()
        {
            if (fpSpread2_Sheet1.Rows.Count == 0)
            {
                return;
            }
            //获取要对照的数据
            //当前活动行
            int currRow = fpSpread2_Sheet1.ActiveRowIndex;

            string sICDCode = fpSpread2_Sheet1.Cells[currRow, GetColumnKey(fpSpread2_Sheet1, "诊断码")].Text;

            if (sICDCode == "" || sICDCode == null)
            {
                return;
            }

            Neusoft.HISFC.Models.HealthRecord.ICD icd9 = new Neusoft.HISFC.Models.HealthRecord.ICD();

            ArrayList al = myICD.IsExistAndReturn(sICDCode, ICDTypes.ICD9, true);

            if (al == null)
            {
                MessageBox.Show("获得ICD9信息出错!");
                return;
            }

            icd9 = al[0] as Neusoft.HISFC.Models.HealthRecord.ICD;

            //ICD9 编码
            textBoxICD9.Text = icd9.ID;
            //ICD9 名称
            textBoxICD9Name.Text = icd9.Name;
            //ICD 拼音
            textBoxICD9.Tag = icd9;
        }
        /// <summary>
        /// 获取ICD9数据，填充到TexBox中
        /// </summary>
        private void AddInfoICD10()
        {
            if (fpSpread1_Sheet1.Rows.Count == 0)
            {
                return;
            }
            //获取要对照的数据
            //当前活动行
            int currRow = fpSpread1_Sheet1.ActiveRowIndex;

            string sICDCode = fpSpread1_Sheet1.Cells[currRow, GetColumnKey(fpSpread1_Sheet1, "诊断码")].Text;

            if (sICDCode == "" || sICDCode == null)
            {
                return;
            }

            Neusoft.HISFC.Models.HealthRecord.ICD icd10 = new Neusoft.HISFC.Models.HealthRecord.ICD();

            ArrayList al = myICD.IsExistAndReturn(sICDCode, ICDTypes.ICD10, true);

            if (al == null)
            {
                MessageBox.Show("获得ICD10信息出错!");
                return;
            }

            icd10 = al[0] as Neusoft.HISFC.Models.HealthRecord.ICD;

            //ICD9 编码
            textBoxICD10.Text = icd10.ID;
            //ICD9 名称
            textBoxICD10Name.Text = icd10.Name;
            //ICD 拼音
            textBoxICD10.Tag = icd10;
        }
        /// <summary>
        /// ICD10 查询的回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchICD10_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //获取数据 ，填充到TextBox中
                AddInfoICD10();
                this.tabControl1.SelectedIndex = 2;
                textBox5.Focus();
            }
        }
        /// <summary>
        /// 查询主键列位置
        /// </summary>
        /// <returns></returns>
        private int GetColumnKey(FarPoint.Win.Spread.SheetView view, string str)
        {
            try
            {
                foreach (FarPoint.Win.Spread.Column col in view.Columns)
                {
                    if (col.Label == str)
                    {
                        return col.Index;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //获取数据，填充到TexBox中
            AddinfoICD9();
            //显示ICD
            this.tabControl1.SelectedIndex = 1;
        }

        /// <summary>
        ///双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //获取数据，填充到TexBox中
            AddInfoICD10();
            //显示ICDCompare
            this.tabControl1.SelectedIndex = 2;
        }
        #region 保存单元格的宽度
        /// <summary>
        /// 保存ICD9的宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread2_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            //保存fpSPread2改变 后的宽度。
            if (File.Exists(filePath9))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(fpSpread2_Sheet1, filePath9);
            }
        }

        /// <summary>
        /// 保存ICD10的宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            //保存fpSPread1改变 后的宽度。
            if (File.Exists(filePath10))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(fpSpread1_Sheet1, filePath10);
            }
        }

        /// <summary>
        /// 保存ICDCompare的宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread3_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            //保存fpSPread2改变 后的宽度。
            if (File.Exists(filePathCompare))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(fpSpread3_Sheet1, filePathCompare);
            }
        }
        #endregion
        #region  支持 上下键
        private void textSearchICD9_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //设定 移动多少格滚动一次
                this.fpSpread2.SetViewportTopRow(0, fpSpread2_Sheet1.ActiveRowIndex - 5);
                //当前位置向上移动一行
                this.fpSpread2_Sheet1.ActiveRowIndex--;
                this.fpSpread2_Sheet1.AddSelection(fpSpread2_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                //设定 移动多少格滚动一次
                this.fpSpread2.SetViewportTopRow(0, fpSpread2_Sheet1.ActiveRowIndex - 5);
                //当前位置向下移动一行
                this.fpSpread2_Sheet1.ActiveRowIndex++;
                this.fpSpread2_Sheet1.AddSelection(fpSpread2_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
        }

        private void textSearchICD10_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //设定 移动多少格滚动一次
                this.fpSpread1.SetViewportTopRow(0, fpSpread1_Sheet1.ActiveRowIndex - 5);
                //当前位置向上移动一行
                this.fpSpread1_Sheet1.ActiveRowIndex--;
                this.fpSpread1_Sheet1.AddSelection(fpSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                //设定 移动多少格滚动一次
                this.fpSpread1.SetViewportTopRow(0, fpSpread1_Sheet1.ActiveRowIndex - 5);
                //当前位置向下移动一行
                this.fpSpread1_Sheet1.ActiveRowIndex++;
                this.fpSpread1_Sheet1.AddSelection(fpSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
            }

        }

        private void textBox5_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //设定 移动多少格滚动一次
                this.fpSpread3.SetViewportTopRow(0, fpSpread3_Sheet1.ActiveRowIndex - 5);
                //当前位置向上移动一行
                this.fpSpread3_Sheet1.ActiveRowIndex--;
                this.fpSpread3_Sheet1.AddSelection(fpSpread3_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                //设定 移动多少格滚动一次
                this.fpSpread3.SetViewportTopRow(0, fpSpread3_Sheet1.ActiveRowIndex - 5);
                //当前位置向下移动一行
                this.fpSpread3_Sheet1.ActiveRowIndex++;
                this.fpSpread3_Sheet1.AddSelection(fpSpread3_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
        }
        #endregion
        #endregion

        #region  自定义函数
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //
            if (keyData == Keys.F2)
            {
                circle++;

                switch (circle)
                {
                    case 0:
                        textBox6.Text = "拼音码";
                        break;
                    case 1:
                        textBox6.Text = "统计代码";
                        break;
                    case 2:
                        textBox6.Text = "五笔码";
                        break;
                    case 3:
                        textBox6.Text = "诊断码";
                        break;
                }

                if (circle == 2)
                {
                    circle = -1;
                }
            }
            //int AltKey = Keys.Alt.GetHashCode();
            //if (keyData.GetHashCode() == AltKey + Keys.C.GetHashCode())
            //{
            //    //对照
            //    CompareICD();
            //}

            //if (keyData.GetHashCode() == AltKey + Keys.D.GetHashCode())
            //{
            //    //取消
            //    CancelICD();
            //}

            //if (keyData.GetHashCode() == AltKey + Keys.L.GetHashCode())
            //{
            //    //清空
            //    ClearICD();
            //}

            //if (keyData.GetHashCode() == AltKey + Keys.H.GetHashCode())
            //{
            //    //帮助
            //}

            //if (keyData.GetHashCode() == AltKey + Keys.X.GetHashCode())
            //{
            //    //退出
            //    this.FindForm().Close();
            //}

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        ///设置FarPoint 的属性
        /// </summary>
        private void SetUp(string filePath)
        {
            Common.Controls.ucSetColumn uc = new Common.Controls.ucSetColumn();
            uc.FilePath = filePath;
            if (filePath == filePath9)
            {
                //uc.DisplayEvent += new EventHandler(uc_GoDisplay9);
            }
            else if (filePath == filePath10)
            {
                //uc.DisplayEvent += new EventHandler(uc_GoDisplay10);// Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplay10);
            }
            else
            {
                //uc.DisplayEvent += new EventHandler(uc_GoDisplayCompare);// Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplayCompare);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }
        /// <summary>
        /// 刷新ICD9
        /// </summary>
        private void uc_GoDisplay9()
        {
            LoadAndAddDateToICD9();
        }
        /// <summary>
        /// 刷新ICD10
        /// </summary>
        private void uc_GoDisplay10()
        {
            LoadAndAddDateToICD10();
        }
        /// <summary>
        /// 刷新对照表
        /// </summary>
        private void uc_GoDisplayCompare()
        {
            LoadAndAddDateToICDCompare();
        }
        /// <summary>
        /// 判断有效性
        /// </summary>
        /// <returns></returns>
        private bool ISValid()
        {
            if (textBoxICD9.Text == "")
            {
                MessageBox.Show("请选择未对的ICD9");
                return false;
            }
            if (textBoxICD10.Text == "")
            {
                MessageBox.Show("请选择ICD10");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取对照信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.HealthRecord.ICDCompare GetInfo()
        {
            //定义变量
            Neusoft.HISFC.Models.HealthRecord.ICDCompare info = new Neusoft.HISFC.Models.HealthRecord.ICDCompare();
            try
            {
                //ICD9 的编码
                info.ICD9 = textBoxICD9.Tag as Neusoft.HISFC.Models.HealthRecord.ICD;

                info.ICD10 = textBoxICD10.Tag as Neusoft.HISFC.Models.HealthRecord.ICD;

                info.IsValid = true;
                //操作员
                info.OperInfo.ID = myICD.Operator.ID;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                info = null;
            }
            return info;
        }
        /// <summary>
        /// ICD对照
        /// </summary>
        private void CompareICD()
        {
            try
            {
                //数据验证失败 
                if (!ISValid())
                {
                    return;
                }
                icdCompare = GetInfo();
                if (icdCompare == null)
                {
                    return;
                }
                //定义事务
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(myICD.Connection);
                ////开始事务
                //t.BeginTransaction();
                myICD.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //执行插入操作
                int iReturn = 0; //返回值 
                iReturn = myICD.InsertCompare(icdCompare);
                if (iReturn > 0)
                {
                    //提交
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    //显示刚刚增加的信息
                    this.tabControl1.SelectedIndex = 2;
                    //获取操作时间
                    icdCompare.OperInfo.OperTime = myICD.GetDateTimeFromSysDateTime();
                    //操作员信息
                    icdCompare.OperInfo.ID = myICD.Operator.ID;
                    icdCompare.OperInfo.Name = myICD.Operator.Name;
                    //从ICD9 列表 中删除 对照完的行
                    DeleteICD9(icdCompare.ICD9);
                    //从在界面上 增加对照信息。
                    AddICDCompare();
                    icdCompare = null;
                    //准备下次输入
                    //清空数据
                    ClearICD();
                    MessageBox.Show("保存对照成功");
                    //					//指定显示界面
                    //					this.tabControl1.SelectedIndex = 1;
                    //					//指定光标位置
                    //					textSearchICD9.Focus();
                }
                else
                {
                    //回退
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(myICD.Err + " 保存对照失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 从ICD9 列表 中删除 对照完的行
        /// </summary>
        private void DeleteICD9(Neusoft.HISFC.Models.HealthRecord.ICD obj)
        {
            if (dtICD9.Rows.Count < 1)
            {
                //没有数据可删除
                return;
            }
            object[] findObj = new object[] { obj.KeyCode };

            DataRow row = this.dtICD9.Rows.Find(findObj);

            if (row == null)
            {
                MessageBox.Show("查找ICD信息出错！");
                return;
            }

            dtICD9.Rows.Remove(row);
        }
        /// <summary>
        /// 从在界面上 增加对照信息。
        /// </summary>
        private void AddICDCompare()
        {
            //定义一个行
            DataRow row = dtICDCompare.NewRow();
            SetRowCompare(icdCompare, row);
            //增加到表中
            dtICDCompare.Rows.Add(row);
            //保存设置
            dtICDCompare.AcceptChanges();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void CancelICD()
        {
            this.tabControl1.SelectedIndex = 2;
            //删除已经对照的信息
            if (fpSpread3_Sheet1.Rows.Count < 1)
            {
                return;
            }
            DialogResult result = MessageBox.Show("确定要删除该对照", "删除", MessageBoxButtons.YesNo);
            //如果是否则退出
            if (result == DialogResult.No)
            {
                return;
            }
            //获取当前活动行
            int currRow = fpSpread3_Sheet1.ActiveRowIndex;
            //ICD 编码
            string icdCode = fpSpread3_Sheet1.Cells[currRow, GetColumnKey(fpSpread3_Sheet1, "诊断码")].Text;
            //序列号 
            string KeyCode = fpSpread3_Sheet1.Cells[currRow, GetColumnKey(fpSpread3_Sheet1, "sequence_no")].Text;
            //操作结果

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(myICD.Connection);
            ////开始事务
            //t.BeginTransaction();

            myICD.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int intResult = myICD.DeleteCompared(icdCode);
            if (intResult < 1)
            {
                //操作失败，回退操作
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(myICD.Err + " 删除对照失败");
            }
            else
            {
                //操作成功，提交
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("删除成功");
                //从界面上删除对照信息
                DeleteICDCompare(KeyCode);
                //在ICD9中增加一行。
                AddICD9(icdCode);
            }
        }
        /// <summary>
        /// 删除对照表中的一条记录
        /// </summary>
        /// <param name="code"></param>
        private void DeleteICDCompare(string code)
        {
            try
            {
                object[] findObj = new object[] { code };
                DataRow row = dtICDCompare.Rows.Find(findObj);
                if (row == null)
                {
                    MessageBox.Show("查找ICD对照信息出错！");
                    return;
                }

                dtICDCompare.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 在未对照的ICD9中增加一条
        /// </summary>
        private void AddICD9(string code)
        {
            try
            {
                //定义动态数组 存储
                ArrayList alReturn = new ArrayList();
                //定义业务层实体类
                Neusoft.HISFC.Models.HealthRecord.ICD orgICD = new Neusoft.HISFC.Models.HealthRecord.ICD();
                //查询 对应的ICD9信息 
                alReturn = myICD.IsExistAndReturn(code, ICDTypes.ICD9, true);
                if (alReturn == null)
                {
                    MessageBox.Show("获得ICD信息出错!" + myICD.Err);
                    return;
                }
                try
                {
                    orgICD = alReturn[0] as Neusoft.HISFC.Models.HealthRecord.ICD;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获得ICD信息出错!" + ex.Message);
                    return;
                }
                DataRow row = dtICD9.NewRow();
                SetRow(orgICD, row);
                dtICD9.Rows.Add(row);
                dtICD9.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearICD()
        {
            textBoxICD9.Text = "";  //清空ICD9编码
            textBoxICD9.Tag = null;  //清空拼音码
            textBoxICD9Name.Text = ""; //清空ICD9名称
            textBoxICD9Name.Tag = null;  //清空自定义码
            textBoxICD10.Text = ""; //清空ICD10编码
            textBoxICD10Name.Text = "";//清空ICD10名称
            textBoxICD10.Tag = null;
            textSearchICD9.Text = "";  //清空检索信息
            textSearchICD10.Text = "";//清空检索信息
            textBox5.Text = ""; //清空检索信息
        }
        #endregion		
    }
}
