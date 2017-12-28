using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// 药品列表控件
    /// 
    /// 暂时屏蔽显示停用功能
    /// </summary>
    public partial class ucDrugList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugList()
        {
            InitializeComponent();

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
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
        /// 是否允许根据数字选择项目
        /// </summary>
        private bool isUseNumChooseData = false;

        /// <summary>
        /// 过滤字段数组
        /// </summary>
        protected    string[] filterField = null;

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
        /// 是否显示高级过滤选项
        /// </summary>
        [Description("过滤时 是否允许通过药品类别过滤 当且仅当显示列表内容为药品时才有效"),Category("设置"),DefaultValue(false)]
        public bool ShowAdvanceFilter
        {
            get
            {
                return this.showAdvanceFilter;
            }
            set
            {
                this.showAdvanceFilter = value;
                this.cmbItemType.Visible = value;
                this.lbItemType.Visible = value;
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

        /// <summary>
        /// 当前SheetView
        /// {F42D8B9A-8836-4f84-8379-A71FB3A626E5} 20100524
        /// </summary>
        public FarPoint.Win.Spread.SheetView CurrentSheetView
        {
            get
            {
                return this.neuSpread1_Sheet1;
            }
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            System.Collections.ArrayList alItemType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            if (alItemType != null)
            {
                this.cmbItemType.AddItems(alItemType);
            }
            //{1DED4697-A590-47b3-B727-92A4AA05D2ED} 设置列表显示时数据锁定
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

        }

        protected virtual void FarPointReset()
        {
            this.neuSpread1_Sheet1.Reset();

            this.neuSpread1.BackColor = System.Drawing.Color.White;

            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;

            //{1DED4697-A590-47b3-B727-92A4AA05D2ED} 设置列表显示时数据锁定
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected virtual void Filter()
        {
            string filter = " ";
            #region 过滤特殊字符{7CF023E5-BB8D-4f85-A4AA-7AB7D457454C}

            string queryString = this.txtQueryCode.Text.Trim();

            if (queryString.Contains("%") == true)
            {
                queryString = queryString.Replace("%", "[%]");
            }

            #endregion
            if (this.filterField != null)      //不使用默认过滤字段
            {
                #region 使用自定义过滤字段
                if (this.filterField.Length == 0)
                    return;

                filter = "(" + this.filterField[0] + " LIKE '%" + queryString + "%' )";

                for (int i = 1; i < this.filterField.Length; i++)
                {
                    filter += "OR (" + this.filterField[i] + " LIKE '%" + queryString + "%' )";

                }
                #endregion
            }
            else                                //使用默认过滤字段
            {
                #region 使用默认过滤字段进行过滤

                filter = string.Format("拼音码 LIKE '%{0}%' OR 五笔码 LIKE '%{1}%' OR 自定义码 LIKE '%{2}%' OR 商品名称 LIKE '%{3}%'", queryString,
                queryString, queryString, queryString);
                
                #endregion
            }

            //设置过滤条件
            if (this.dv != null)
            {
                this.dv.RowFilter = filter;
            }
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
            if (width != null && visible != null && visible.Length > 0)
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
        public virtual void ShowPharmacyList()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索药品信息...");
            Application.DoEvents();
            try
            {
                Neusoft.FrameWork.Management.DataBaseManger databaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
                DataSet dataSet = new DataSet();

                this.ShowAdvanceFilter = true;

                //string[] sqlIndex = new string[2] { "Pharmacy.Item.ValibInfo", "Pharmacy.Item.GetAvailableList.Where" };
                string[] sqlIndex = new string[1] { "Pharmacy.Item.ValibInfo" };

                string itemType = "A";
                if (this.cmbItemType.Tag != null && this.cmbItemType.Text != "")
                {
                    itemType = this.cmbItemType.Tag.ToString();
                }
                databaseManager.ExecQuery(sqlIndex, ref dataSet,itemType);

                if (dataSet == null)
                {
                    MessageBox.Show("检索列表数据发生错误\n" + databaseManager.Err);
                    return;
                }
                this.filterField = new string[13]{"药品名称","通用名","拼音","五笔","自定义码","通用名拼音","别名","别名拼音",
														"通用名五笔","学名","学名拼音","学名五笔","别名五笔"};
                this.DataAutoHeading = true;
                this.DataAutoWidth = false;
                int[] widthCollect = new int[6] { 10,120,100,60,40,40};
                bool[] visibleCollect = new bool[19] {false,true,true,true,true,false,false,false,false,true,false,false,true,false,false,true,false,false,false };
                if (dataSet.Tables.Count > 0)
                {
                    this.DataTable = dataSet.Tables[0];                  
                }

                this.SetFormat(null, widthCollect, visibleCollect);
                //{3FF156FD-6AB7-4468-9BA6-69F2E143AF3C}
                for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
                {
                    if (this.neuSpread1_Sheet1.Columns[i].CellType.GetType() == typeof(FarPoint.Win.Spread.CellType.NumberCellType))
                    {
                        FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                        numCellType.DecimalPlaces = 4;
                        this.neuSpread1_Sheet1.Columns[i].CellType = numCellType;
                    }
                }
               
                //this.SetpharmacyFormat();
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
        /// <param name="showStorageFlag">是否显示库存</param>
        public virtual void ShowDeptStorage(string deptCode, bool isBatch, int showStorageFlag)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索库存药品信息...");
            Application.DoEvents();
            try
            {
                this.FarPointReset();
                Neusoft.FrameWork.Management.DataBaseManger databaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
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

                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Columns.Contains("custom_code"))
                {
                    this.filterField = new string[] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" ,"REGULAR_SPELL",
                                                "REGULAR_WB","OTHER_SPELL","OTHER_WB","FORMAL_SPELL","FORMAL_WB","custom_code"};
                }
                else
                {
                    this.filterField = new string[] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" ,"REGULAR_SPELL",
                                                "REGULAR_WB","OTHER_SPELL","OTHER_WB","FORMAL_SPELL","FORMAL_WB"};
                }

                this.DataAutoWidth = false;

                if (dataSet.Tables.Count > 0)
                {
                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        #region {D41961B7-0702-44e2-BB69-A293BFCFFD56}
                        if (Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[16]) != 0)
                        {
                            //dr[5] = Math.Round(Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[5]) / Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[14]), 2);
                            dr[7] = Math.Round(Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[7]) / Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[16]), 2);
                        } 
                        #endregion
                    }
                    //{28017834-5C98-4d3c-A8CD-7BE2F95C6D74} 过滤不显示0库存药品
                    System.Data.DataView view = dataSet.Tables[0].DefaultView;
                    view.RowFilter = "STORE_SUM > 0";
                    this.DataTable = view.ToTable();
                }

                //使用控件默认的显示格式
                this.SetFormatForStorage(showStorageFlag);
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

        /// <summary>
        /// 显示库存药品列表  不显示药库停用的药品 无药房是否停用无关
        /// 处理特殊盘点信息{98F0BF7A-5F41-4de3-884F-B38E71B41A8C}
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号管理</param>
        /// <param name="showStorageFlag">是否显示库存</param>
        public virtual void ShowDeptStorageWithSpecialCheck(string deptCode, bool isBatch, int showStorageFlag)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索库存药品信息...");
            Application.DoEvents();
            try
            {
                this.FarPointReset();
                Neusoft.FrameWork.Management.DataBaseManger databaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
                DataSet dataSet = new DataSet();
                string sqlIndex;
                if (isBatch)
                    sqlIndex = "Pharmacy.Item.GetStorageListByBatch";
                else
                    sqlIndex = "Pharmacy.Item.GetStorageListWithSpecialCheck";

                databaseManager.ExecQuery(sqlIndex, ref dataSet, deptCode);
                if (dataSet == null)
                {
                    MessageBox.Show("检索列表数据发生错误\n" + databaseManager.Err);
                    return;
                }

                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Columns.Contains("custom_code"))
                {
                    this.filterField = new string[] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" ,"REGULAR_SPELL",
                                                "REGULAR_WB","OTHER_SPELL","OTHER_WB","FORMAL_SPELL","FORMAL_WB","custom_code"};
                }
                else
                {
                    this.filterField = new string[] { "SPELL_CODE", "WB_CODE", "TRADE_NAME" ,"REGULAR_SPELL",
                                                "REGULAR_WB","OTHER_SPELL","OTHER_WB","FORMAL_SPELL","FORMAL_WB"};
                }

                this.DataAutoWidth = false;

                if (dataSet.Tables.Count > 0)
                {
                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        if (Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[14]) != 0)
                        {
                            dr[5] = Math.Round(Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[5]) / Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[14]), 2);
                        }
                    }
                    //{28017834-5C98-4d3c-A8CD-7BE2F95C6D74} 过滤不显示0库存药品
                    System.Data.DataView view = dataSet.Tables[0].DefaultView;
                    view.RowFilter = "STORE_SUM > 0";
                    this.DataTable = view.ToTable();
                }

                //使用控件默认的显示格式
                this.SetFormatForStorage(showStorageFlag);
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

        /// <summary>
        /// 显示库存药品列表 根据参数决定是否显示库存中停用的药品 
        /// {D06724D9-C415-4a6b-8E93-0FF175CB7A8A} 20091230
        /// </summary>
        /// <param name="deptCode">科室代码</param>
        /// <param name="isBatch">是否按批号显示</param>
        /// <param name="isStoreInvalid">是否过滤无效</param>
        public virtual void ShowDeptStorageAndDict(string deptCode, bool isBatch, bool isFilterStoreInvalid)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索库存药品信息...");
            Application.DoEvents();
            try
            {
                this.FarPointReset();

                Neusoft.FrameWork.Management.DataBaseManger databaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
                DataSet dataSet = new DataSet();
                string sqlIndex;
                if (isBatch)
                {
                    if (isFilterStoreInvalid)
                    {
                        sqlIndex = "Pharmacy.Item.QueryDrugList.StoreAndDic.ByBatch";
                    }
                    else
                    {
                        sqlIndex = "Pharmacy.Item.QueryDrugList.StoreAndDic.ByBatch.AllState";
                    }
                }
                else
                {
                    if (isFilterStoreInvalid)
                    {
                        sqlIndex = "Pharmacy.Item.QueryDrugList.StoreAndDic.NotByBatch";
                    }
                    else
                    {
                        sqlIndex = "Pharmacy.Item.QueryDrugList.StoreAndDic.NotByBatch.AllState";
                    }
                }

                databaseManager.ExecQuery(sqlIndex, ref dataSet, deptCode, "ALL");
                if (dataSet == null)
                {
                    MessageBox.Show("检索列表数据发生错误\n" + databaseManager.Err);
                    return;
                }

                this.filterField = new string[] { "药品名称", "商品名拼音码", "商品名五笔码", "通用名拼音码", "通用名五笔码" };

                this.DataAutoHeading = false;
                this.DataAutoWidth = false;
                this.DataAutoCellType = false;

                if (dataSet.Tables.Count > 0)
                {
                    this.DataTable = dataSet.Tables[0];
                }

                //使用控件默认的显示格式
                this.SetFormatForStorageAndDict(Neusoft.FrameWork.Function.NConvert.ToInt32(isBatch));
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
        
        /// <summary>
        /// 显示库存药品时进行格式化
        /// {D06724D9-C415-4a6b-8E93-0FF175CB7A8A} 20091230
        /// </summary>
        private void SetFormatForStorage(int isShowStorage)
        {
            #region {D41961B7-0702-44e2-BB69-A293BFCFFD56}
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "药品编码";
            this.neuSpread1_Sheet1.Columns.Get(0).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(1).Label = "自定义码";
            this.neuSpread1_Sheet1.Columns.Get(1).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 100F;

            this.neuSpread1_Sheet1.Columns.Get(2).Label = "商品名称";
            this.neuSpread1_Sheet1.Columns.Get(2).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 150F;

            this.neuSpread1_Sheet1.Columns.Get(3).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(3).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 75F;

            this.neuSpread1_Sheet1.Columns.Get(4).Label = "剂型";
            this.neuSpread1_Sheet1.Columns.Get(4).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 75F;

            this.neuSpread1_Sheet1.Columns.Get(5).Label = "批号";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 60F;
            this.neuSpread1_Sheet1.Columns.Get(5).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(6).Label = "库位号";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 57F;
            this.neuSpread1_Sheet1.Columns.Get(6).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(7).Label = "库存";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 58F;
            this.neuSpread1_Sheet1.Columns.Get(7).Visible = Neusoft.FrameWork.Function.NConvert.ToBoolean(isShowStorage);

            this.neuSpread1_Sheet1.Columns.Get(8).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(9).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(9).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(10).Label = "通用名拼音码";
            this.neuSpread1_Sheet1.Columns.Get(10).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(11).Label = "通用名五笔码";
            this.neuSpread1_Sheet1.Columns.Get(11).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(12).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(13).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(14).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(15).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(16).Visible = false;
            
            #endregion
            //this.neuSpread1_Sheet1.Columns.Get(15).Label = "自定义码";
            //this.neuSpread1_Sheet1.Columns.Get(15).Visible = true;

            //this.neuSpread1_Sheet1.Columns.Get(16).Label = "剂型";
            //this.neuSpread1_Sheet1.Columns.Get(16).Visible = true;
        }

        /// <summary>
        /// 显示库存药品时进行格式化
        /// {D06724D9-C415-4a6b-8E93-0FF175CB7A8A} 20091230
        /// </summary>
        private void SetFormatForStorageAndDict(int showBatchNO)
        {
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "药品编码";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(0).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(1).Label = "药品名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 160F;

            this.neuSpread1_Sheet1.Columns.Get(2).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(2).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(3).Label = "批号";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 70F;
            this.neuSpread1_Sheet1.Columns.Get(3).Visible = Neusoft.FrameWork.Function.NConvert.ToBoolean(showBatchNO);

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType markDateTimeCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType();
            markDateTimeCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = markDateTimeCellType;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "有效期";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 66F;
            this.neuSpread1_Sheet1.Columns.Get(4).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(5).Label = "库存";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 70F;
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            markNumCellType.DecimalPlaces = 3;
            this.neuSpread1_Sheet1.Columns[5].CellType = markNumCellType;
            this.neuSpread1_Sheet1.Columns.Get(5).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(6).Label = "单位";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 35F;
            this.neuSpread1_Sheet1.Columns.Get(6).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(7).Label = "厂家";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 110F;
            this.neuSpread1_Sheet1.Columns.Get(7).Visible = true;

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCellType2 = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            markNumCellType2.DecimalPlaces = 2;
            this.neuSpread1_Sheet1.Columns[8].CellType = markNumCellType2;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "进价";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 60F;
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = true;

            this.neuSpread1_Sheet1.Columns[9].CellType = markNumCellType2;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "零售价";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 60F;
            this.neuSpread1_Sheet1.Columns.Get(9).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(10).Label = "医保";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 39F;
            this.neuSpread1_Sheet1.Columns.Get(10).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(11).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(11).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(12).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(13).Label = "通用名拼音码";
            this.neuSpread1_Sheet1.Columns.Get(13).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(14).Label = "通用名五笔码";
            this.neuSpread1_Sheet1.Columns.Get(14).Visible = false;
        }

        /// <summary>
        /// 检索程序中需要的列表
        /// </summary>
        /// <param name="sqlIndex">检索的SQL语句在XML中的索引</param>
        /// <param name="filterField">用于对该列表检索的字段，由SQL语句检索的数据内选择</param>
        /// <param name="formatStr">对SQL语句进行格式化的数据</param>
        public void ShowInfoList(string sqlIndex, string[] filterField, params string[] formatStr)
        {
            this.FarPointReset();
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
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索数据 请稍候.....");
            Application.DoEvents();

            try
            {
                this.FarPointReset();
                this.DataAutoCellType = false;
                this.DataAutoHeading = false;
                this.DataAutoWidth = false;
                //{1DED4697-A590-47b3-B727-92A4AA05D2ED} 设置列表显示时数据锁定
                this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

                Neusoft.FrameWork.Management.DataBaseManger databaseManager = new Neusoft.FrameWork.Management.DataBaseManger();
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
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
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
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(ex.Message));
            }
        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void txtQueryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex++;
                this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 1);
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex--;
                this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 1);
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ChooseDataEvent != null && this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    this.ChooseDataEvent(this.neuSpread1_Sheet1, this.neuSpread1_Sheet1.ActiveRowIndex);
                }
            }
            if (this.isUseNumChooseData && char.IsDigit(((char)e.KeyCode)))
            {
                if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                {
                    return;
                }

                if ((Neusoft.FrameWork.Function.NConvert.ToInt32((char)e.KeyCode) - 48) <= this.neuSpread1_Sheet1.Rows.Count)
                {
                    if (this.ChooseDataEvent != null)
                    {
                        this.ChooseDataEvent(this.neuSpread1_Sheet1,Neusoft.FrameWork.Function.NConvert.ToInt32((char)e.KeyCode) - 49);
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

        protected virtual  void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbItemType.Text != "")
            {
                this.captionLabel.Text = "药品选择－" + this.cmbItemType.Text;

                this.ShowPharmacyList();
            }
        }




    }
}
