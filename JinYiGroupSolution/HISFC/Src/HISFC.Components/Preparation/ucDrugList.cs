using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Preparation
{
    /// <summary>
    /// 药品列表控件
    /// 
    /// 暂时屏蔽显示停用功能
    /// </summary>
    public partial class ucDrugList : UserControl
    {
        public ucDrugList()
        {
            InitializeComponent();

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            //临时屏蔽CheckBox
            this.showStopCk.Enabled = false;
            this.showStopCk.Checked = false;
        }

        public delegate void ChooseDataHandler(FarPoint.Win.Spread.SheetView sv,int activeRow);

        /// <summary>
        /// 双击或回车选中时触发 返回参数Fp的Row
        /// </summary>
        public event ChooseDataHandler ChooseDataEvent;

        /// <summary>
        /// 点击关闭按钮
        /// </summary>
        public event System.EventHandler CloseClickEvent;

        #region 域变量

        /// <summary>
        /// Fp数据源DataSet
        /// </summary>
        private DataTable dt = null;
        /// <summary>
        /// Fp数据源生成的DataView
        /// </summary>
        private DataView dv = null;
        /// <summary>
        /// 需显示的树型列表
        /// </summary>
        private TreeView tvList = null;

        /// <summary>
        /// 是否显示高级过滤选项
        /// </summary>
        private bool showAdvanceFilter = false;

        /// <summary>
        /// 高级过滤显示标记 0 当前未显示高级过滤项 1 当前显示高级过滤项
        /// </summary>
        private int advanceFilterFlag = 0;

        /// <summary>
        /// 是否允许根据数字选择项目
        /// </summary>
        private bool isUseNumChooseData = false;

        /// <summary>
        /// 过滤字段数组
        /// </summary>
        private string[] filterField = null;

        #endregion

        #region 属性

        /// <summary>
        /// 标题栏显示文本
        /// </summary>
        [Description("上部标题栏显示文本 在ShowCatpion属性为True时才有效"),Category("设置"),DefaultValue("药品选择")]
        public string Caption
        {
            get
            {
                return this.captionLabel.Text;
            }
            set
            {
                this.captionLabel.Text = value;
            }
        }

        /// <summary>
        /// 是否显示Caption标题栏
        /// </summary>
        [Description("是否显示标题栏"),Category("设置"),DefaultValue(true)]
        public bool ShowCaption
        {
            get
            {
                return this.groupBox1.Visible;
            }
            set
            {
                this.groupBox1.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示关闭按钮
        /// </summary>
        [Description("是否显示关闭按钮"),Category("设置"),DefaultValue(true)]
        public bool ShowCloseButton
        {
            get
            {
                return this.closeButton.Visible;
            }
            set
            {
                this.closeButton.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示停用药品
        /// </summary>
        [Description("显示列表为药品时 是否显示停用药品"),Category("设置"),DefaultValue(true)]
        public bool ShowStop
        {
            get
            {
                return this.showStopCk.Checked;
            }
            set
            {
                this.showStopCk.Checked = value;
            }
        }

        /// <summary>
        /// 是否显示高级过滤选项
        /// </summary>
        [Description("过滤时 是否显示高级过滤选项 当且仅当显示列表内容为药品时才有效"),Category("设置"),DefaultValue(false)]
        public bool ShowAdvanceFilter
        {
            get
            {
                return this.showAdvanceFilter;
            }
            set
            {
                if (value)
                {
                    if (!this.showAdvanceFilter)
                    {
                        this.advanceFilterFlag = 1;
                        this.panelFilter.Height = 105;
                    }
                }
                else
                {
                    if (this.showAdvanceFilter)
                    {
                        this.advanceFilterFlag = 0;
                        this.panelFilter.Height = 30;
                    }
                }
                this.showAdvanceFilter = value;
                this.lnbAdvanceFilter.Visible = value;
            }
        }

        /// <summary>
        /// 是否允许根据数字选择项目
        /// </summary>
        [Description("是否允许根据数字(行索引)选择项目"), Category("设置"), DefaultValue(false)]
        public bool IsUseNumChooseData
        {
            get
            {
                return this.isUseNumChooseData;
            }
            set
            {
                this.isUseNumChooseData = value;
            }
        }

        /// <summary>
        /// 过滤字段
        /// </summary>
        public string[] FilterField
        {
            get
            {
                return this.filterField;
            }
            set
            {
                this.filterField = value;
            }
        }

        #endregion

        #region 树属性

        /// <summary>
        /// 是否显示树型列表
        /// </summary>
        [Description("是否显示树型列表"), Category("设置")]
        public bool ShowTreeView
        {
            get
            {
                return !this.neuSpread1.Visible;
            }
            set
            {
                if (this.tvList != null && value)
                {
                    this.neuSpread1.Visible = false;
                    this.panelFilter.Visible = false;
                    this.tvList.Dock = DockStyle.Fill;
                    this.panelList.Controls.Add(this.tvList);
                }
                else
                {
                    this.neuSpread1.Visible = true;
                    this.panelFilter.Visible = true;
                }
            }
        }

        /// <summary>
        /// 显示的树型列表
        /// </summary>
        public TreeView TreeView
        {
            set
            {
                this.tvList = value;
            }
        }

        #endregion

        #region Fp属性

        /// <summary>
        /// 是否显示Fp行标题
        /// </summary>
        [Description("显示列表时 是否显示行标题"), Category("设置"), DefaultValue(true)]
        public bool ShowFpRowHeader
        {
            get
            {
                return this.neuSpread1_Sheet1.RowHeader.Visible;
            }
            set
            {
                this.neuSpread1_Sheet1.RowHeader.Visible = value;
            }
        }

        /// <summary>
        /// 是否根据DataSet数据源设置列类型
        /// </summary>
        [Description("是否根据DataSet数据源设置Fp单元格类型"),Category("设置"),DefaultValue(true)]
        public bool DataAutoCellType
        {
            get
            {
                return this.neuSpread1_Sheet1.DataAutoCellTypes;
            }
            set
            {
                this.neuSpread1_Sheet1.DataAutoCellTypes = value;
            }
        }

        /// <summary>
        /// 是否使用DataSet数据源内的列标题
        /// </summary>
        [Description("是否根据DataSet数据源设置Fp单元列标题"),Category("设置"),DefaultValue(true)]
        public bool DataAutoHeading
        {
            get
            {
                return this.neuSpread1_Sheet1.DataAutoHeadings;
            }
            set
            {
                this.neuSpread1_Sheet1.DataAutoHeadings = value;
            }
        }

        /// <summary>
        /// 是否使用DataSet数据源内的列宽度
        /// </summary>
        [Description("是否根据DataSet数据源设置Fp列宽度"),Category("设置"),DefaultValue(true)]
        public bool DataAutoWidth
        {
            get
            {
                return this.neuSpread1_Sheet1.DataAutoSizeColumns;
            }
            set
            {
                this.neuSpread1_Sheet1.DataAutoSizeColumns = value;
            }
        }

        /// <summary>
        /// Fp数据源
        /// </summary>
        public DataTable DataTable
        {
            get
            {
                return this.dt;
            }
            set
            {
                this.dt = value;
                if( value != null )
                {
                    this.dv = new DataView( this.dt );

                    this.neuSpread1_Sheet1.DataSource = this.dv;
                }
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected virtual void Filter()
        {
            string filter = " ";
            if (this.filterField != null)      //不使用默认过滤字段
            {
                #region 使用自定义过滤字段
                if (this.filterField.Length == 0)
                    return;

                if (this.ckBlurFilter.Checked)
                    filter = "(" + this.filterField[0] + " LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                else
                    filter = "(" + this.filterField[0] + " LIKE '%" + this.txtQueryCode.Text.Trim() + "' )";
                for (int i = 1; i < this.filterField.Length; i++)
                {
                    if (this.ckBlurFilter.Checked)
                        filter += "OR (" + this.filterField[i] + " LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                    else
                        filter += "OR (" + this.filterField[i] + " LIKE '%" + this.txtQueryCode.Text.Trim() + "' )";

                }
                #endregion
            }
            else                                //使用默认过滤字段
            {
                if (this.showAdvanceFilter)
                {
                    switch (this.cmbFilterField.Text)
                    {
                        #region 设置过滤字符串
                        case "全部":
                            if (this.ckBlurFilter.Checked)
                                filter = string.Format("拼音码 LIKE '%{0}%' OR 五笔码 LIKE '%{1}%' OR 自定义码 LIKE '%{2}%' OR 商品名称 LIKE '%{3}%'", this.txtQueryCode.Text.Trim(),
                                this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim());
                            else
                                filter = string.Format("拼音码 LIKE '%{0}' OR 五笔码 LIKE '%{1}' OR 自定义码 LIKE '%{2}' OR 商品名称 LIKE '%{3}'", this.txtQueryCode.Text.Trim(),
                                this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim());
                            break;
                        case "拼音码":
                            if (this.ckBlurFilter.Checked)
                                filter = "(拼音码 LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                            else
                                filter = "(拼音码 LIKE '%" + this.txtQueryCode.Text.Trim() + "' )";
                            break;
                        case "五笔码":
                            if (this.ckBlurFilter.Checked)
                                filter = "(五笔码 LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                            else
                                filter = "(五笔码 LIKE '%" + this.txtQueryCode.Text.Trim() + "' )";
                            break;
                        case "自定义码":
                            if (this.ckBlurFilter.Checked)
                                filter = "(自定义码 LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                            else
                                filter = "(自定义码 LIKE '%" + this.txtQueryCode.Text.Trim() + "' )";
                            break;
                        case "商品名称":
                            if (this.ckBlurFilter.Checked)
                                filter = "(商品名称 LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                            else
                                filter = "(商品名称 LIKE '%" + this.txtQueryCode.Text.Trim() + "' )";
                            break;
                        #endregion
                    }
                }
                else
                {
                    #region 使用默认过滤字段进行过滤
                    if (this.ckBlurFilter.Checked)
                        filter = string.Format("拼音码 LIKE '%{0}%' OR 五笔码 LIKE '%{1}%' OR 自定义码 LIKE '%{2}%' OR 商品名称 LIKE '%{3}%'", this.txtQueryCode.Text.Trim(),
                        this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim());
                    else
                        filter = string.Format("拼音码 LIKE '%{0}' OR 五笔码 LIKE '%{1}' OR 自定义码 LIKE '%{2}' OR 商品名称 LIKE '%{3}'", this.txtQueryCode.Text.Trim(),
                        this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim(), this.txtQueryCode.Text.Trim());
                    #endregion
                }
            }
            //设置过滤条件
            this.dv.RowFilter = filter;
            this.neuSpread1_Sheet1.ActiveRowIndex = 0;

        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="label">列标题</param>
        /// <param name="width">宽度</param>
        /// <param name="visible">是否显示</param>
        public virtual void SetFormat(string[] label, int[] width, bool[] visible)
        {
            if (label != null && label.Length > 0)
                this.neuSpread1_Sheet1.DataAutoHeadings = false;
            if (width != null && visible.Length > 0)
                this.neuSpread1_Sheet1.DataAutoSizeColumns = false;

            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (label != null && label.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Label = label[i];
                if (width != null && width.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Width = width[i];
                if (visible != null && visible.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Visible = visible[i];
            }
        }

        /// <summary>
        /// 显示药品列表  不显示药库停用的药品 与药房是否停用无关
        /// </summary>
        public virtual void ShowPharmacyList(string drugType)
        {
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在检索药品信息...");
            Application.DoEvents();
            try
            {
                Neusoft.NFC.Management.DataBaseManger databaseManager = new Neusoft.NFC.Management.DataBaseManger();
                DataSet dataSet = new DataSet();
                string[] sqlIndex = new string[2] { "Pharmacy.Item.ValibInfo", "Preparation.Item.GetList.QueryByType" };

                databaseManager.ExecQuery(sqlIndex, ref dataSet, drugType);
                if (dataSet == null)
                {
                    MessageBox.Show("检索列表数据发生错误\n" + databaseManager.Err);
                    return;
                }
                this.filterField = new string[7]{"SPELL_CODE","WB_CODE","REGULAR_NAME","REGULAR_SPELL",
														"REGULAR_WB","CUSTOM_CODE","TRADE_NAME"};
                this.DataTable = dataSet.Tables[0];

                this.SetpharmacyFormat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            }
        }
        
        /// <summary>
        /// 设置药品格式化
        /// </summary>
        private void SetpharmacyFormat()
        {
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "药品编码";
            this.neuSpread1_Sheet1.Columns.Get(0).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(1).Label = "商品名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 150F;
            this.neuSpread1_Sheet1.Columns.Get(1).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(2).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 76F;
            this.neuSpread1_Sheet1.Columns.Get(2).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(3).Label = "零售价";
            this.neuSpread1_Sheet1.Columns.Get(3).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(4).Label = "包装单位";
            this.neuSpread1_Sheet1.Columns.Get(4).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(5).Label = "包装数量";
            this.neuSpread1_Sheet1.Columns.Get(5).Visible = true;

            for (int i = 6; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].Visible = false;
            }

            this.neuSpread1_Sheet1.Columns.Get(6).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(6).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(7).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "自定义码";
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "通用名";
            this.neuSpread1_Sheet1.Columns.Get(9).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "通用名拼音码";
            this.neuSpread1_Sheet1.Columns.Get(10).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "通用名五笔码";
            this.neuSpread1_Sheet1.Columns.Get(11).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "通用名自定义码";
            this.neuSpread1_Sheet1.Columns.Get(12).Visible = false;
        }

        /// <summary>
        /// 显示库存药品列表  不显示药库停用的药品 无药房是否停用无关
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号管理</param>
        public virtual void ShowDeptStorage(string deptCode, bool isBatch)
        {
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在检索库存药品信息...");
            Application.DoEvents();
            try
            {
                Neusoft.NFC.Management.DataBaseManger databaseManager = new Neusoft.NFC.Management.DataBaseManger();
                DataSet dataSet = new DataSet();
                string sqlIndex;
                if (isBatch)
                    sqlIndex = "Pharmacy.Item.GetStorageListByBatch";
                else
                    sqlIndex = "Pharmacy.Item.GetStorageListNoBatch";

                databaseManager.ExecQuery(sqlIndex, ref dataSet, deptCode);
                if (dataSet == null)
                {
                    MessageBox.Show("检索列表数据发生错误\n" + databaseManager.Err);
                    return;
                }
                this.filterField = new string[3] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" };
                this.DataTable = dataSet.Tables[0];

                //使用控件默认的显示格式
                this.SetFormatForStorage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            }
        }
        
        /// <summary>
        /// 显示库存药品时进行格式化
        /// </summary>
        private void SetFormatForStorage()
        {
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "药品编码";
            this.neuSpread1_Sheet1.Columns.Get(0).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(1).Label = "商品名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 150F;

            this.neuSpread1_Sheet1.Columns.Get(2).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 76F;
            this.neuSpread1_Sheet1.Columns.Get(2).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(3).Label = "批号";
            this.neuSpread1_Sheet1.Columns.Get(3).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(4).Label = "库位号";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 57F;
            this.neuSpread1_Sheet1.Columns.Get(4).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(5).Label = "库存";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 58F;
            this.neuSpread1_Sheet1.Columns.Get(5).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(6).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(6).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(7).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "通用名拼音码";
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "通用名五笔码";
            this.neuSpread1_Sheet1.Columns.Get(9).Visible = false;
        }

        /// <summary>
        /// 检索程序中需要的列表
        /// </summary>
        /// <param name="sqlIndex">检索的SQL语句在XML中的索引</param>
        /// <param name="filterField">用于对该列表检索的字段，由SQL语句检索的数据内选择</param>
        /// <param name="formatStr">对SQL语句进行格式化的数据</param>
        public void ShowInfoList(string sqlIndex, string[] filterField, params string[] formatStr)
        {
            string[] sqlIndexex = { sqlIndex };
            this.ShowInfoList(sqlIndexex, filterField, formatStr);
        }
       
        /// <summary>
        /// 检索程序中需要的列表
        /// </summary>
        /// <param name="sqlIndex">检索的SQL语句在XML中的索引数组 第一位为select索引 其他为where索引</param>
        /// <param name="filterField">用于对该列表进行检索的字段，由sql语句检索的数据内选择</param>
        /// <param name="formatStr">对sql语句进行格式化的数据</param>
        public void ShowInfoList(string[] sqlIndex, string[] filterField, params string[] formatStr)
        {
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在检索数据 请稍候.....");
            Application.DoEvents();

            try
            {
                this.DataAutoCellType = false;
                this.DataAutoHeading = false;
                this.DataAutoWidth = false;

                Neusoft.NFC.Management.DataBaseManger databaseManager = new Neusoft.NFC.Management.DataBaseManger();
                DataSet dataSet = new DataSet();
                databaseManager.ExecQuery(sqlIndex, ref dataSet, formatStr);
                if (dataSet == null)
                {
                    MessageBox.Show("检索列表数据发生错误\n" + databaseManager.Err);
                    return;
                }
                this.DataTable = dataSet.Tables[0];
                this.FilterField = filterField;
            }
            catch (Exception ex)
            {
                MessageBox.Show("检索列表数据发生错误\n" + ex.Message);
            }
            finally
            {
                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 获取显示数据的第一列到指定列宽度
        /// </summary>
        /// <param name="columnNum">需计算的列数量</param>
        /// <param name="width">返回的宽度</param>
        public void GetColumnWidth(int columnNum, ref int width)
        {
            int iNum = 0;
            width = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Columns[i].Visible)
                {
                    width = width + (int)this.neuSpread1_Sheet1.Columns[i].Width;
                    iNum = iNum + 1;
                    if (iNum > columnNum - 1)
                        break;
                }
            }
        }

        /// <summary>
        /// 设置过滤框为内容全选状态
        /// </summary>
        public void SetFocusSelect()
        {
            this.Select();
            this.txtQueryCode.Select();
            this.txtQueryCode.Focus();
            this.txtQueryCode.SelectAll();
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            try
            {
                this.neuSpread1_Sheet1.Rows.Count = 0;

                if (this.dt != null)
                    this.dt.Clear();                
            }
            catch(Exception ex)
            {
                MessageBox.Show(Neusoft.NFC.Management.Language.Msg(ex.Message));
            }
        }

        private void lnbAdvanceFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.advanceFilterFlag == 0)            //未显示高级过滤项
            {
                this.panelFilter.Height = 105;
                this.advanceFilterFlag = 1;
            }
            else                                       //已显示高级过滤项
            {
                this.panelFilter.Height = 30;
                this.advanceFilterFlag = 0;
            }
        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            if (this.chkRealTimeFilter.Checked)
                this.Filter();
        }

        private void txtQueryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex++;
                this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex--;
                this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.chkRealTimeFilter.Checked)
                {
                    this.Filter();
                }
                else
                {
                    if (this.ChooseDataEvent != null && this.neuSpread1_Sheet1.Rows.Count > 0)
                    {
                        this.ChooseDataEvent(this.neuSpread1_Sheet1,this.neuSpread1_Sheet1.ActiveRowIndex);
                    }
                }
            }
            if (this.isUseNumChooseData && char.IsDigit(((char)e.KeyCode)))
            {
                if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                {
                    return;
                }

                if ((Neusoft.NFC.Function.NConvert.ToInt32((char)e.KeyCode) - 48) <= this.neuSpread1_Sheet1.Rows.Count)
                {
                    if (this.ChooseDataEvent != null)
                    {
                        this.ChooseDataEvent(this.neuSpread1_Sheet1,Neusoft.NFC.Function.NConvert.ToInt32((char)e.KeyCode) - 49);
                    }
                    e.Handled = true;
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (this.CloseClickEvent != null)
            {
                this.CloseClickEvent(null, System.EventArgs.Empty);
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.ChooseDataEvent != null)
            {
                this.ChooseDataEvent(this.neuSpread1_Sheet1,e.Row);
            }
        }
    }
}
