using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material
{
    /// <summary>
    /// [功能描述: 物资库存初始化]
    /// [创 建 者: wangw]
    /// [创建时间: 2008-3-14]
    /// </summary>
    public partial class ucAddStock : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造方法

        public ucAddStock()
        {
            InitializeComponent();
        }

        #endregion

        #region 字段

        private DataView dvMatList;

        private DataSet dsMat = new DataSet();

        /// <summary>
        /// 物资科目帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper matTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 物资数量帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 物资业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store matManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资基本信息业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem matItemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 物资基础数据业务逻辑类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Baseset matBaseSet = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// 过虑串
        /// </summary>
        private string filter = "1=1";

        /// <summary>
        /// 是否拥有权限
        /// </summary>
        private bool isHavePriv = false;

        /// <summary>
        /// 权限科室类
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        #endregion

        #region 方法

        /// <summary>
        /// 检索物品信息
        /// </summary>
        private void RetrieveData()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在检索物资信息...请稍后!"));

            Application.DoEvents();

            List<Neusoft.HISFC.Models.Material.MaterialItem> alMatItem = this.matItemManager.GetMetItemList();

            if (alMatItem == null)
            {
                MessageBox.Show(matItemManager.Err);
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return;
            }

            //取物品类型数组
            this.matTypeHelper.ArrayObject = this.matBaseSet.QueryKindAllByID("0");

            Neusoft.HISFC.Models.Material.MaterialItem info;
            for (int i = 0; i < alMatItem.Count; i++)
            {
                info = alMatItem[i] as Neusoft.HISFC.Models.Material.MaterialItem;
                this.dsMat.Tables[0].Rows.Add(new object[]
                    {
                        false,//是否添加
                        info.Name,//物品名称
                        info.Specs,//物品规格
                        info.UnitPrice,//零售金额(现有物资程序购入价=零售价)
                        info.PackUnit,//包装单位
                        info.PackQty,//包装数量
                        info.MinUnit,//最小单位
                        info.ID,//物品编码
                        info.SpellCode,//拼音码
                        info.WbCode,//五笔码
                        info.UserCode,//自定义码
                        info.MaterialKind.ID//物资种类
                    }
                    );
                //设置格式
                this.SetFormat();
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, alMatItem.Count);
                Application.DoEvents();
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

        }

        /// <summary>
        /// 初始化视图
        /// </summary>
        private void InitDataView()
        {
            this.dsMat.Tables.Clear();
            this.dsMat.Tables.Add();
            this.dvMatList = new DataView(this.dsMat.Tables[0]);
            this.neuSpread1_Sheet1.DataSource = this.dvMatList;
            this.dvMatList.AllowEdit = true;

            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            this.dsMat.Tables[0].Columns.AddRange(new DataColumn[]{
                                                                       new DataColumn("添加",dtBool),
                                                                       new DataColumn("物品名称",dtStr),
                                                                       new DataColumn("规格",dtStr),
                                                                       new DataColumn("零售价",dtDec),
                                                                       new DataColumn("包装单位",dtStr),
                                                                       new DataColumn("包装数量",dtDec),
                                                                       new DataColumn("最小单位",dtStr),
                                                                       new DataColumn("物品编码",dtStr),
                                                                       new DataColumn("拼音码",dtStr),
                                                                       new DataColumn("五笔码",dtStr),
                                                                       new DataColumn("自定义码",dtStr),
                                                                       new DataColumn("物资种类",dtStr)
                                                                       });
        }

        /// <summary>
        /// 设置farpoint格式
        /// </summary>
        private void SetFormat()
        {
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType;
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "添加";
            this.neuSpread1_Sheet1.Columns.Get(0).Locked = false;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 38F;

            this.neuSpread1_Sheet1.Columns.Get(1).Label = "物品名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 129F;

            this.neuSpread1_Sheet1.Columns.Get(2).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(2).Locked = true;

            FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 4;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "零售价";
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = numberCellType;
            this.neuSpread1_Sheet1.Columns.Get(3).Locked = true;

            this.neuSpread1_Sheet1.Columns.Get(4).Label = "包装单位";
            this.neuSpread1_Sheet1.Columns.Get(4).Locked = true;

            this.neuSpread1_Sheet1.Columns.Get(5).Label = "包装数量";
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = numberCellType;
            this.neuSpread1_Sheet1.Columns.Get(5).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 42F;

            this.neuSpread1_Sheet1.Columns.Get(6).Label = "最小单位";
            this.neuSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 41F;

            this.neuSpread1_Sheet1.Columns.Get(7).Label = "物品编码";
            this.neuSpread1_Sheet1.Columns.Get(7).Locked = true;

            this.neuSpread1_Sheet1.Columns.Get(8).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(8).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(9).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(9).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(9).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(10).Label = "自定义码";
            this.neuSpread1_Sheet1.Columns.Get(10).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(10).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(11).Label = "物资种类";
            this.neuSpread1_Sheet1.Columns.Get(11).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(11).Visible = true;
        }

        /// <summary>
        /// 选择事件
        /// </summary>
        /// <param name="isSelectAll"></param>
        private void SelectMat(bool isSelectAll)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Value = isSelectAll;
            }
        }

        /// <summary>
        /// 合法性检查
        /// </summary>
        private int ValidCheck()
        {
            //判断数量录入是否正确
            if (this.txtSum.Text == string.Empty || this.txtSum.Text.Trim() == "")
            {
                MessageBox.Show(Language.Msg("请录入要增加的库存数量（最小单位）"), Language.Msg("提示"));
                return -1;
            }

            //判断录入数量是否大于零

            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSum.Text) <= 0)
            {
                MessageBox.Show(Language.Msg("数量必须大于零"), Language.Msg("数量录入错误"));
                this.txtSum.Focus();
                return -1;
            }

            //停止数据编辑状态
            for (int i = 0; i < this.dvMatList.Count; i++)
            {
                this.dvMatList[i].EndEdit();
            }
            //设置过滤条件
            this.dvMatList.RowFilter = this.filter + " and 添加 = true";
            //设置格式
            this.SetFormat();

            //判断是否存在药品数据dvMatList
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show(Language.Msg("请选择要添加的药品"), Language.Msg("提示"));
                return -1;
            }

            if (MessageBox.Show(Language.Msg("确定要增加您选中的“") + this.neuSpread1_Sheet1.Rows.Count.ToString() + Language.Msg("”条项目库存吗？"), Language.Msg("确认增加库存"), MessageBoxButtons.YesNo) == DialogResult.No) return -1;

            return 0;
        }

        /// <summary>
        /// 初始化库存
        /// </summary>
        private void AddStock()
        {
            if (this.ValidCheck() < 0)
            {
                return;
            }

            List<Neusoft.HISFC.Models.Material.MaterialStorage> alDept = this.tvDeptTree1.SelectNodes;
            if (alDept.Count == 0)
            {
                MessageBox.Show(Language.Msg("请选择要添加的库房"), Language.Msg("提示"));
                return;
            }
            if (!this.isHavePriv)
            {
                bool isAllowEdit = false;
                foreach (Neusoft.HISFC.Models.Material.MaterialStorage dept in alDept)
                {
                    if (dept.ID == this.privDept.ID)
                    {
                        isAllowEdit = true;
                    }
                }
                if (!isAllowEdit)
                {
                    MessageBox.Show(Language.Msg("您的权限不能对其他库存科室进行库存初始化! 请添加药品基本信息维护权限"), Language.Msg("提示"));
                    return;
                }
            }

            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.matManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                string matCode = "";
                decimal quantity = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSum.Text);
                bool IsUpdate = false;
                bool check = false;
                Neusoft.HISFC.Models.Material.StoreDetail storeDetail = new Neusoft.HISFC.Models.Material.StoreDetail();

                storeDetail.StoreBase.StockNO = this.matManager.GetNewStockNO();
                storeDetail.StoreBase.BatchNO = "1";
                storeDetail.StoreBase.ValidTime = this.matManager.GetDateTimeFromSysDateTime().AddYears(5);
                storeDetail.StoreBase.Quantity = quantity;
                storeDetail.StoreBase.StoreQty = quantity;
                storeDetail.StoreBase.PlaceNO = "0";
                storeDetail.StoreBase.ID = "0";
                storeDetail.StoreBase.SerialNO = 0;
                storeDetail.StoreBase.SystemType = "01";
                storeDetail.StoreBase.PrivType = "00";
                storeDetail.StoreBase.Class2Type = "0510";
                storeDetail.Memo = "库存初始化";
                storeDetail.StoreBase.Item.ValidState = true;
                storeDetail.StoreBase.Operation.Oper.OperTime = this.matManager.GetDateTimeFromSysDateTime();

                foreach (Neusoft.HISFC.Models.Material.MaterialStorage dept in alDept)
                {
                    for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, this.neuSpread1_Sheet1.RowCount);
                        Application.DoEvents();

                        //如果没有选中，则不处理此条数据
                        check = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);
                        if (!check)
                        {
                            continue;
                        }

                        matCode = this.neuSpread1_Sheet1.Cells[i, 7].Text;

                        storeDetail.StoreBase.StockDept.ID = dept.ID;
                        storeDetail.StoreBase.TargetDept.ID = dept.ID;
                        storeDetail.StoreBase.Item = this.matItemManager.GetMetItemByMetID(matCode);

                        if (storeDetail.StoreBase.Item == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("无法转化为storeDetail.StoreBase.Item类型"));
                            return;
                        }

                        if (storeDetail.StoreBase.Quantity == 0)
                        {
                            continue;
                        }

                        storeDetail.StoreBase.PriceCollection.PurchasePrice = storeDetail.StoreBase.Item.UnitPrice;
                        storeDetail.StoreBase.PriceCollection.RetailPrice = storeDetail.StoreBase.PriceCollection.PurchasePrice;
                        storeDetail.StoreBase.StoreCost = quantity * storeDetail.StoreBase.PriceCollection.PurchasePrice;

                        #region 写入有效性状态 {EBFFA2FC-9E48-4b6e-BB0B-2910C6E98501}
                        storeDetail.StoreBase.State = Neusoft.FrameWork.Function.NConvert.ToInt32(storeDetail.StoreBase.Item.ValidState).ToString(); 
                        #endregion

                        if (this.matManager.SetStorage(storeDetail) != 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(this.matManager.Err, Language.Msg("保存错误提示"));
                            return;
                        }
                        IsUpdate = true;
                    }
                }

                if (IsUpdate)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show(Language.Msg("保存成功！"));
                }
                else
                {
                    //如果没有更新的数据,则回滚事务.
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                }
            }
            catch (System.Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message);
                return;
            }

            //显示全部药品
            this.dvMatList.RowFilter = "1=1";
            this.SetFormat();
            //取消选中
            this.SelectMat(false);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.InitDataView();
            this.RetrieveData();
            this.tvKindTree1.Nodes[0].Expand();

            this.isHavePriv = Neusoft.HISFC.BizProcess.Integrate.Pharmacy.ChoosePiv("0510");
            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)(matManager.Operator)).Dept;

            base.OnLoad(e);
        }

        /// <summary>
        /// 过滤事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            if (this.dsMat.Tables[0].Rows.Count == 0) return;

            try
            {
                string queryCode = "";
                queryCode = "%" + this.txtQueryCode.Text.Trim() + "%";

                string str = "((拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(自定义码 LIKE '" + queryCode + "') OR " +
                    "(物品名称 LIKE '" + queryCode + "') )";

                //设置过滤条件
                this.dvMatList.RowFilter = this.filter + " AND " + str;
                //设置格式
                this.SetFormat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 物资科目选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvKindTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.filter = "1=1";
            this.txtQueryCode.Text = "";
            if (e.Node.Parent != null)
            {
                string fife = e.Node.Tag.ToString();
                this.filter = "( 物资种类 = '" + fife + "') ";
            }
            else
            {
                this.filter = "1=1";
            }

            this.dvMatList.RowFilter = this.filter;
            this.SetFormat();
        }


        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            //增加工具栏
            this.toolBarService.AddToolButton("全选", "选中全部药品", 0, true, false, null);
            this.toolBarService.AddToolButton("全不选", "取消选中全部药品", 1, true, false, null);
            return this.toolBarService;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在添加库存数据..."));
            Application.DoEvents();
            this.AddStock();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "全选":
                    this.SelectMat(true);
                    break;
                case "全不选":
                    this.SelectMat(false);
                    break;

            }

        }

        #endregion
    }
}
