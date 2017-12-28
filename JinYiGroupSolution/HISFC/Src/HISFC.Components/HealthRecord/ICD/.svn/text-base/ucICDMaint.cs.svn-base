using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
namespace Neusoft.HISFC.Components.HealthRecord.ICD
{
    /// <summary>
    /// ucICDMaint<br></br>
    /// [功能描述: 病案ICD维护信息录入]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-20]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucICDMaint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucICDMaint()
        {
            InitializeComponent();
        }

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
            toolBarService.AddToolButton("增加", "增加", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("修改", "修改", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            //toolBarService.AddToolButton("查询(&Q))", "查询(&Q)", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            //toolBarService.AddToolButton("导出", "导出", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C借出, true, false, null);
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
                case "增加":
                    InsertRow();
                    break;
                case "修改":
                    ModifyInfo();
                    break;
                case "查询(&Q)":
                    //ClearICD();
                    break;
                default:
                    break;
            }
        }
        public override int Export(object sender, object neuObject)
        {
            Export();
            return base.Export(sender, neuObject);
        }
        #endregion

        #endregion

        #region 自定义变量

        //定义字符变量 确定显示方式XML	
        //		private string filePath = Application.StartupPath +"\\profile\\ICDMaint.xml";
        //全局变量，存储加载的类型 ICD10 ICD9 手术ICD 信息
        private ICDTypes type;
        private DataSet ds = new DataSet();
        //		//定义全局变量 DataTable  存储 查询出来的数据集
        //		private DataTable dtICD = new DataTable();
        //定义全局变量 DataView   用来过滤数据
        private DataView dvICD = new DataView();
        //编辑类别
        private EditTypes editType;
        //查询类别
        private QueryTypes queryType;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cb30dis;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cancerFlag;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox infectFlag;
        private System.Windows.Forms.Button Search;
        //ICD业务层
        private Neusoft.HISFC.BizLogic.HealthRecord.ICD myICD = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();

        #endregion

        #region  属性
        /// <summary>
        /// ICD类别
        /// </summary>
        //public ICDTypes ICDType
        //{
        //    get
        //    {
        //        return type;
        //    }
        //    set
        //    {
        //        type = value;
        //        //加载数据
        //        LoadInfo();
        //    }
        //}
        /// <summary>
        /// 查询类别
        /// </summary>
        public QueryTypes QueryType
        {
            get
            {
                return queryType;
            }
            set
            {
                queryType = value;
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// uc初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucICDMaint_Load(object sender, System.EventArgs e)
        
        {
            if (this.Tag == null)
            {
                return;
            }
            if (this.Tag.ToString() == "ICD10")
            {
                type =  ICDTypes.ICD10;
            }
            else if (this.Tag.ToString()== "ICD9")
            {
                type =  ICDTypes.ICD9;
            }
            else //if (this.Tag.ToString() == "ICDOperation")
            {
                type =  ICDTypes.ICDOperation;
            }
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            LoadInfo();
        }
        /// <summary>
        /// 当列宽度发生变化时,存储到配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            //			if(File.Exists(this.filePath))
            //			{
            //				Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, this.filePath);
            //			}
        }
        /// <summary>
        /// frmICDInfo自定义事件,弹出窗口确定按钮按下后触发
        /// </summary>
        /// <param name="info"></param>
        private void icdInfo_SaveButtonClick(Neusoft.HISFC.Models.HealthRecord.ICD info)
        {
            try
            {
                //处理事件
                if (editType == EditTypes.Add)
                {
                    //定义变量
                    DataRow row = ds.Tables[0].NewRow();
                    //增加一行
                    SetRow(info, row);
                    ds.Tables[0].Rows.Add(row);
                }
                else
                {
                    object[] keys = new object[] { info.KeyCode };
                    DataRow row = ds.Tables[0].Rows.Find(keys);
                    if (row == null)
                    {
                        MessageBox.Show("查找项目出错!");
                        return;
                    }
                    else
                    {
                        SetRow(info, row);
                    }
                }
                ds.Tables[0].AcceptChanges();
                LockFp();
                //				//设置fpSpread1 的属性
                //				if(System.IO.File.Exists(this.filePath))
                //				{
                //					Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, this.filePath);
                //					
                //				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 双击事件 响应修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.ModifyInfo();
        }
        /// <summary>
        /// 查询所有菜单单击触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mAll_Click(object sender, System.EventArgs e)
        {
            this.queryType = QueryTypes.All;
            LoadInfo();
        }
        /// <summary>
        /// 查询有效菜单单击触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mValid_Click(object sender, System.EventArgs e)
        {
            this.queryType = QueryTypes.Valid;
            LoadInfo();
        }
        /// <summary>
        /// 查询停用菜单单击触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mStop_Click(object sender, System.EventArgs e)
        {
            this.queryType = QueryTypes.Cancel;
            LoadInfo();
        }
        /// <summary>
        /// 查询编码时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            string temp = " like  '%" + this.textBox1.Text + "%' ";
            string rowFilter = "诊断码" + temp + " or " + "医保中心代码" + temp + " or " + "拼音码" + temp + " or " + "统计代码" + temp + " or " + "诊断名称" + temp;
            //			if(cb30dis.Checked)
            //			{
            //				//三十种疾病
            //			}
            //			else
            //			{
            //			}
            //			if(infectFlag.Checked)
            //			{
            //			}
            //			else
            //			{
            //			}
            //			if(cancerFlag.Checked)
            //			{
            //			}
            //			else
            //			{
            //			}
            this.dvICD.RowFilter = rowFilter;
            LockFp();
        }
        /// <summary>
        /// 单机是否30种疾病时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {

        }
        /// <summary>
        /// 判断是否传染病触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
        {

        }
        /// <summary>
        /// 判断是否肿瘤触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region  函数
        /// <summary>
        /// 增加一行
        /// </summary>
        private void InsertRow()
        {
            //实例化要弹出的窗口
            frmICDInfo icdInfo = new frmICDInfo();
            //赋值 ICD的类型 
            icdInfo.ICDType = type;
            //赋值 修改的类型
            icdInfo.EditType = EditTypes.Add;
            //保存修改类型
            editType = EditTypes.Add;
            //订制事件 。
            icdInfo.SaveButtonClick+=new frmICDInfo.SaveInfo(icdInfo_SaveButtonClick);
            //显示窗体
            icdInfo.ShowDialog();
        }
        /// <summary>
        /// 修改ICD信息
        /// </summary>
        private void ModifyInfo()
        {
            if (this.fpSpread1_Sheet1.RowCount <= 0)
            {
                return;
            }

            int currRow = fpSpread1_Sheet1.ActiveRowIndex;//当前行
            if (currRow < 0)
            {
                return;
            }
            ArrayList alReturn = new ArrayList(); //返回的ICD信息
            string sICDCode = "";//选取的ICD编码

            //定义变量，存储要修改的信息
            Neusoft.HISFC.Models.HealthRecord.ICD orgICD = new Neusoft.HISFC.Models.HealthRecord.ICD();
            ////获得有效性
            //string IsValue = fpSpread1_Sheet1.Cells[currRow, GetColumnKey("有效性")].Value.ToString();
            ////如果已经是无效，则不允许修改
            //if (IsValue == "False")
            //{
            //    MessageBox.Show("此项目已经无效,不能再被修改");
            //    return;
            //}
            //获得ICD编码

            sICDCode = fpSpread1_Sheet1.Cells[currRow, GetColumnKey("诊断码")].Text;

            if (sICDCode == "" || sICDCode == null)
            {
                return;
            }

            alReturn = myICD.IsExistAndReturn(sICDCode, type, true);

            if (alReturn == null)
            {
                MessageBox.Show("获得ICD信息出错!" + myICD.Err);
                return;
            }
            if (alReturn.Count == 0)
            {
                alReturn = myICD.IsExistAndReturn(sICDCode, type, false);
            }
            if (alReturn.Count == 0)
            {
                MessageBox.Show("获得ICD信息出错" );
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
            //实例化要弹出的窗口
            frmICDInfo icdInfo = new frmICDInfo();
            //显示待修改信息
            icdInfo.OrgICD = orgICD;
            //赋值 ICD的类型 
            icdInfo.ICDType = type;
            //赋值 修改的类型
            icdInfo.EditType = EditTypes.Modify;
            //保存修改类型
            editType = EditTypes.Modify;
            //订制事件 。
            icdInfo.SaveButtonClick+=new frmICDInfo.SaveInfo(icdInfo_SaveButtonClick);
            //显示窗体
            icdInfo.ShowDialog();
        }
        /// <summary>
        /// 重载函数 ，响应工具栏上的快捷键 
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.A.GetHashCode())
            //{
            //    this.InsertRow();//增加
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.M.GetHashCode())
            //{
            //    this.ModifyInfo();//修改
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            //{
            //    this.FindForm().Close();//退出
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.Q.GetHashCode())
            //{
            //    //查询 
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.E.GetHashCode())
            //{
            //    Export();//导出
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.E.GetHashCode())
            //{
            //    this.SetUp();//设置
            //}
            //else
            //{
            //}
            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// 导出数据 
        /// </summary>
        private void Export()
        {
            bool ret = false;
            //导出数据
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel|.xls";
                saveFileDialog1.FileName = "";

                saveFileDialog1.Title = "导出数据";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    //以Excel 的形式导出数据
                    ret = fpSpread1.SaveExcel(saveFileDialog1.FileName);
                    if (ret)
                    {
                        MessageBox.Show("导出成功！");
                    }
                }
            }
            catch (Exception ex)
            {
                //出错了
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        ///设置fpSpread1_Sheet1 的属性
        /// </summary>
        private void SetUp()
        {
            //			Common.Controls.ucSetColumn uc = new Common.Controls.ucSetColumn();
            //			uc.UpButton = false;
            //			uc.FilePath = this.filePath;
            //			uc.GoDisplay += new Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplay);
            //			Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }
        /// <summary>
        /// 查询主键列位置
        /// </summary>
        /// <returns></returns>
        private int GetColumnKey(string str)
        {
            foreach (FarPoint.Win.Spread.Column col in this.fpSpread1_Sheet1.Columns)
            {
                if (col.Label == str)
                {
                    return col.Index;
                }
            }
            return 0;
        }
        /// <summary>
        /// 调整fpSpread1_Sheet1的宽度等 保存后触发的事件
        /// </summary>
        private void uc_GoDisplay()
        {
            LoadInfo(); //重新加载数据

        }

        /// <summary>
        /// 在dtICD中添加加一行
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
            row["五笔"] = obj.WBCode;
            row["诊断名称"] = obj.Name;
            row["第二诊断名称"] = obj.User01;
            row["第三诊断名称"] = obj.User02;
            row["死亡原因"] = obj.DeadReason;
            row["疾病分类"] = obj.DiseaseCode;
            row["标准住院日"] = obj.StandardDays;
            if (obj.Is30Illness == "1" || obj.Is30Illness == "是")
            {
                row["是否30中疾病"] = "是";
            }
            else
            {
                row["是否30中疾病"] = "否";
            }
            if (obj.IsInfection == "1" || obj.IsInfection == "是")
            {
                row["是否传染病"] = "是";
            }
            else
            {
                row["是否传染病"] = "否";
            }
            if (obj.IsTumour == "1" || obj.IsTumour == "是")
            {
                row["是否肿瘤"] = "是";
            }
            else
            {
                row["是否肿瘤"] = "否";
            }
            row["住院等级"] = obj.InpGrade;
            if (obj.IsValid)
            {
                row["有效性"] = "有效";
            }
            else
            {
                row["有效性"] = "无效";
            }
            row["序号"] = obj.SeqNo;
            row["oper_code"] = obj.OperInfo.ID;
            row["操作员"] = obj.OperInfo.Name;
            row["操作时间"] = obj.OperInfo.OperTime;
            row["副诊断码"] = obj.User01;
            //if (obj.SexType.ID == "A")
            //{
            //    row["适用性别"] = "全部";
            //}
            //else if (obj.SexType.ID == "M")
            //{
                row["适用性别"] = obj.SexType.Name;
            //}
            //else
            //{
            //    row["适用性别"] = "女";
            //}
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadInfo()
        {
            try
            {
                //如果是none 直接返回 
                if (ICDTypes.None == type)
                {
                    return;
                }
                //等待窗口
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
                Application.DoEvents();
                //
                //				dtICD = new DataTable();
                //				//如果配置文件存在,通过配置文件生成DataTable dtICD列信息,并绑定fp
                //
                //				Type strType = typeof(System.String);
                //				Type intType = typeof(System.Int32);
                //				Type dtType = typeof(System.DateTime);
                //				Type boolType = typeof(System.Boolean);
                //				
                //				dtICD.Columns.AddRange(new DataColumn[]{new DataColumn(   "诊断码", strType),
                //														   new DataColumn("副诊断码", strType),
                //														   new DataColumn("诊断名称", strType),
                //														   new DataColumn("统计代码", strType),
                //														   new DataColumn("拼音码", strType),
                //														   new DataColumn("五笔码", strType),
                //														   new DataColumn("医保中心代码", strType),
                //														   new DataColumn("第二诊断名称", strType),
                //														   new DataColumn("第三诊断名称", strType),
                //														   new DataColumn("死亡原因", strType),
                //														   new DataColumn("疾病分类", strType),
                //														   new DataColumn("标准住院日", intType),
                //														   new DataColumn("30种疾病", boolType),
                //														   new DataColumn("传染病", boolType),
                //														   new DataColumn("肿瘤", boolType),
                //														   new DataColumn("住院等级", strType),
                //														   new DataColumn("有效性", boolType),
                //														   new DataColumn("序号", strType),
                //														   new DataColumn("操作员编码", strType),
                //														   new DataColumn("操作员", strType),
                //														   new DataColumn("操作时间", dtType),
                //														    new DataColumn("适用性别", strType),
                //														   new DataColumn("sequence_no", strType)});
                //
                //				//设置主键为sequence_no列
                //				CreateKeys();
                //				dvICD = new DataView(dtICD);
                //				this.fpSpread1_Sheet1.DataSource = dvICD;
                //				if(!File.Exists(this.filePath))
                //				{
                //					Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, this.filePath);
                //				}
                //				ArrayList alReturn = new ArrayList();//返回的ICD信息;
                //				//获得ICD信息
                //				alReturn = myICD.Query(type, queryType);
                //				if(alReturn == null)
                //				{
                //					MessageBox.Show("获得ICD信息出错!" + myICD.Err);
                //					return;
                //				}
                //				//循环插入信息
                //				foreach(Neusoft.HISFC.Models.HealthRecord.ICD obj in alReturn)
                //				{
                //					DataRow row = dtICD.NewRow();
                //					SetRow(obj, row);
                //					dtICD.Rows.Add(row);
                //				}
                //				//排序 
                //				this.dvICD.Sort = "诊断码 ASC";
                //				//设置fpSpread1 的属性
                //				if(System.IO.File.Exists(this.filePath))
                //				{
                //					Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, this.filePath);
                //					LockFp();
                //				}
                myICD.Query(type, queryType, ref ds); //查询 
                if (ds.Tables.Count == 1)
                {
                    DataColumn[] keys = new DataColumn[] { ds.Tables[0].Columns["sequence_no"] }; //z设置主键 
                    ds.Tables[0].PrimaryKey = keys;
                    this.dvICD = new DataView(ds.Tables[0]);
                }

                this.fpSpread1_Sheet1.DataSource = dvICD;
                LockFp();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void Search_Click(object sender, System.EventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                return;
            }
            string sICDCode = ConvertString(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, GetColumnKey("诊断码")].Text);
            if (sICDCode != null)
            {
                SetActiveRow(sICDCode);
            }
            LockFp();
        }

        /// <summary>
        /// 星键字符转换函数 
        /// </summary>
        /// <param name="ConvertStr"></param>
        /// <returns></returns>
        public string ConvertString(string ConvertStr)
        {
            string strReturn = "";
            try
            {
                strReturn = ConvertStr;
                int i = strReturn.IndexOf("*");
                int j = strReturn.IndexOf("+");

                if (i > 0 && strReturn.IndexOf("+") > 0)
                {
                    if (i < j)
                    {
                        string str1 = strReturn.Substring(0, i + 1);
                        string str2 = strReturn.Substring(i + 1);
                        strReturn = str2 + str1;
                    }
                    else
                    {
                        string str1 = strReturn.Substring(0, j + 1);
                        string str2 = strReturn.Substring(j + 1);
                        strReturn = str2 + str1;
                    }
                }
                return strReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public int LockFp()
        {
            //			FarPoint.Win.Spread.CellType.CheckBoxCellType ck = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

            for (int i = 0; i < fpSpread1_Sheet1.Columns.Count; i++)
            {
                fpSpread1_Sheet1.Columns[i].Locked = true;
            }
            this.fpSpread1_Sheet1.Columns[0].Visible = false; //序号 
            this.fpSpread1_Sheet1.Columns[1].Width = 100;//诊断码
            this.fpSpread1_Sheet1.Columns[2].Visible = false;//医保中心代码
            this.fpSpread1_Sheet1.Columns[3].Width = 60;//统计代码
            this.fpSpread1_Sheet1.Columns[4].Width = 60;//拼音码
            this.fpSpread1_Sheet1.Columns[5].Width = 60;//五笔码
            this.fpSpread1_Sheet1.Columns[6].Width = 250;//诊断名称
            this.fpSpread1_Sheet1.Columns[7].Visible = false;//诊断名称
            this.fpSpread1_Sheet1.Columns[8].Visible = false;//诊断名称
            this.fpSpread1_Sheet1.Columns[9].Visible = false; //死亡原因
            this.fpSpread1_Sheet1.Columns[10].Width = 50;//统计分类
            this.fpSpread1_Sheet1.Columns[11].Visible = false;//平均住院日
            //			this.fpSpread1_Sheet1.Columns[12].CellType = ck;
            this.fpSpread1_Sheet1.Columns[12].Width = 60;//是否30种疾病
            //			this.fpSpread1_Sheet1.Columns[13].CellType = ck;
            this.fpSpread1_Sheet1.Columns[13].Width = 60; //是否初染病
            //			this.fpSpread1_Sheet1.Columns[14].CellType = ck;
            this.fpSpread1_Sheet1.Columns[14].Width = 60; //是否肿瘤
            this.fpSpread1_Sheet1.Columns[15].Visible = false; //住院等级
            //			this.fpSpread1_Sheet1.Columns[16].CellType = ck;
            this.fpSpread1_Sheet1.Columns[16].Width = 60;//有效
            this.fpSpread1_Sheet1.Columns[17].Visible = false;//序号
            this.fpSpread1_Sheet1.Columns[18].Visible = false;//编码
            this.fpSpread1_Sheet1.Columns[19].Width = 60;//操作员
            this.fpSpread1_Sheet1.Columns[20].Width = 80;//时间
            this.fpSpread1_Sheet1.Columns[21].Visible = false;
            this.fpSpread1_Sheet1.Columns[22].Width = 60;//适用性别
            this.fpSpread1_Sheet1.Columns[22].Visible = false;
            return 1;
        }
        /// <summary>
        /// 查找行
        /// </summary>
        /// <param name="ICDCode"></param>
        /// <returns></returns>
        private int SetActiveRow(string ICDCode)
        {
            for (int i = 0; i < fpSpread1_Sheet1.Rows.Count; i++)
            {
                if (fpSpread1_Sheet1.Cells[i, GetColumnKey("诊断码")].Text == ICDCode)
                {
                    //设定活动行
                    //					this.fpSpread1_Sheet1.SetActiveCell(i,1);
                    this.fpSpread1_Sheet1.ActiveRowIndex = i;
                    break;
                }
            }
            return 1;
        }
    }
}
