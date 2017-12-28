using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品协定处方包装]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2010-05]<br></br>
    /// </summary>
    public partial class ucNostrumProduce : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucNostrumProduce()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// DataTable 
        /// </summary>
        private DataTable dt = new DataTable();

        #endregion

        #region 初始化
        
        #region 列表枚举

        /// <summary>
        /// 左侧协定处方选择列枚举
        /// </summary>
        private enum ColNostrumList
        {
            ColName,
            ColSpecs,
            ColPackQty,
            ColRetailPrice,
            ColPackUnit,
            ColID,
            ColSpell,
            ColWB,
            ColRegularSpell,
            ColRegularWB
        }

        /// <summary>
        /// 右侧待包装列表
        /// </summary>
        private enum ColPackageList
        {
            ColID,
            ColName,
            ColSpecs,
            ColRetailPrice,
            ColPlanQty,
            ColPackUnit,
            ColBatchNO,
            ColValidDate,
            ColMemo,
            ColDetail
        }

        #endregion

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private void InitNostrumListDataTable()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType( "System.String" );
            System.Type dtDec = System.Type.GetType( "System.Decimal" );
            System.Type dtBol = System.Type.GetType( "System.Boolean" );

            this.dt.Columns.AddRange( new DataColumn[] {
                                                                        new DataColumn("协定处方",	  dtStr),
                                                                        new DataColumn("规格",        dtStr),
                                                                        new DataColumn("包装数量",    dtDec),
                                                                        new DataColumn("零售价",      dtDec),
                                                                        new DataColumn("包装单位",    dtStr),
                                                                        new DataColumn("药品编码",	  dtStr),
                                                                        new DataColumn("拼音码",      dtStr),
                                                                        new DataColumn("五笔码",      dtStr),
                                                                        new DataColumn("通用名拼音码",dtStr),
                                                                        new DataColumn("通用名五笔码",dtStr)
                                                                    } );
            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;
            this.dt.CaseSensitive = true;

            //设定用于对DataView进行重复行检索的主键
            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.dt.Columns["药品编码"];
            this.dt.PrimaryKey = keys;

            this.fpNostrumList_Sheet1.DataSource = this.dt.DefaultView;
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private int InitDrugData()
        {
            List<Neusoft.HISFC.Models.Pharmacy.Item> alNostrumList = this.itemManager.QueryNostrumList();
            if (alNostrumList == null)
            {
                MessageBox.Show( "加载协定处方药品信息发生错误  " + this.itemManager.Err );
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Item info in alNostrumList)
            {
                DataRow dr = this.dt.NewRow();

                dr["协定处方"] = info.Name;
                dr["规格"] = info.Specs;
                dr["包装数量"] = info.PackQty;
                dr["零售价"] = info.PriceCollection.RetailPrice;
                dr["包装单位"] = info.PackUnit;
                dr["药品编码"] = info.ID;
                dr["拼音码"] = info.NameCollection.SpellCode;
                dr["五笔码"] = info.NameCollection.WBCode;
                dr["通用名拼音码"] = info.NameCollection.RegularSpell.SpellCode;
                dr["通用名五笔码"] = info.NameCollection.RegularSpell.WBCode;

                this.dt.Rows.Add( dr );
            }

            return 1;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private int Init()
        {
            this.InitNostrumListDataTable();

            this.InitDrugData();

            this.fpPackageList_Sheet1.Rows.Count = 0;

            return 1;
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton( "删除", "删除当前选择的协定处方", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null );

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除")
            {
                this.DeleteNostrum();
            }
            base.ToolStrip_ItemClicked( sender, e );
        }

        #endregion

        #region 方法

        /// <summary>
        /// 有效性校验
        /// </summary>
        /// <returns></returns>
        protected bool Valid()
        {
            for (int i = 0; i < this.fpPackageList_Sheet1.Rows.Count; i++)
            {
                //计划数量
                decimal planQty = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.fpPackageList_Sheet1.Cells[i, (int)ColPackageList.ColPlanQty].Text );

                if (planQty == 0)
                {
                    MessageBox.Show( "计划包装数量不能为0!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 数据选择
        /// </summary>
        protected void ChooseNostrum()
        {
            string drugNO = this.fpNostrumList_Sheet1.Cells[this.fpNostrumList_Sheet1.ActiveRowIndex, (int)ColNostrumList.ColID].Text;

            Neusoft.HISFC.Models.Pharmacy.Item selectNostrum = this.itemManager.GetItem( drugNO );

            int rowCount = this.fpPackageList_Sheet1.Rows.Count;

            this.fpPackageList_Sheet1.Rows.Add( rowCount, 1 );

            this.fpPackageList_Sheet1.Cells[rowCount, (int)ColPackageList.ColID].Text = selectNostrum.ID;
            this.fpPackageList_Sheet1.Cells[rowCount, (int)ColPackageList.ColName].Text = selectNostrum.Name;
            this.fpPackageList_Sheet1.Cells[rowCount, (int)ColPackageList.ColSpecs].Text = selectNostrum.Specs;
            this.fpPackageList_Sheet1.Cells[rowCount, (int)ColPackageList.ColRetailPrice].Text = selectNostrum.PriceCollection.RetailPrice.ToString();
            //计划数量
            this.fpPackageList_Sheet1.Cells[rowCount, (int)ColPackageList.ColPackUnit].Text = selectNostrum.PackUnit;
            //备注
            this.fpPackageList_Sheet1.Rows[rowCount].Tag = selectNostrum;

            this.ShowNostrumDetail( rowCount, selectNostrum );
        }

        /// <summary>
        /// 协定处方明细数据显示
        /// </summary>
        /// <param name="rowIndex">当前行索引</param>
        /// <param name="selectNostrum">当前协定处方信息</param>
        protected void ShowNostrumDetail(int rowIndex, Neusoft.HISFC.Models.Pharmacy.Item selectNostrum)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Nostrum> detailNostrumList = this.fpPackageList_Sheet1.Cells[rowIndex, (int)ColPackageList.ColDetail].Tag as List<Neusoft.HISFC.Models.Pharmacy.Nostrum>;
            if (detailNostrumList == null)
            {
                detailNostrumList = this.itemManager.QueryNostrumDetail( selectNostrum.ID );
            }

            this.lbNostrumInfo.Text = "协定处方";

            if (detailNostrumList != null)
            {
                int index = 1;
                string strDetailName = "";
                string strDetail = "";
                string strDisplayName = "协定处方：{0}  规格：{1}  处方构成明细：{2}";

                foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum info in detailNostrumList)
                {
                    strDetail += index.ToString() + ")  ";

                    strDetailName += info.Item.Name + ",";

                    strDetail += info.Item.Name + " " + info.Item.Specs + " " + info.Qty.ToString() + "    ";

                    index++;
                }

                this.fpPackageList_Sheet1.Cells[rowIndex, (int)ColPackageList.ColDetail].Text = strDetailName;
                this.fpPackageList_Sheet1.Cells[rowIndex, (int)ColPackageList.ColDetail].Tag = detailNostrumList;

                this.lbNostrumInfo.Text = string.Format( strDisplayName, selectNostrum.Name, selectNostrum.Specs, strDetail );
            }
        }

        /// <summary>
        /// 删除当前选择项
        /// </summary>
        protected void DeleteNostrum()
        {
            if (this.fpPackageList_Sheet1.Rows.Count > 0)
            {
                this.fpPackageList_Sheet1.Rows.Remove( this.fpPackageList_Sheet1.ActiveRowIndex, 1 );
            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        protected void Clear()
        {
            this.fpPackageList_Sheet1.Rows.Count = 0;

            this.lbNostrumInfo.Text = "协定处方明细";
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.Valid() == false)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaProcess = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            this.itemManager.SetTrans( Neusoft.FrameWork.Management.PublicTrans.Trans );

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();
            //操作环境信息
            Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new Neusoft.HISFC.Models.Base.OperEnvironment();
            operEnvironment.OperTime = sysTime;
            operEnvironment.ID = this.itemManager.Operator.ID;
            operEnvironment.Name = this.itemManager.Operator.Name;
            //当前库存科室
            Neusoft.FrameWork.Models.NeuObject stockDept = ((Neusoft.HISFC.Models.Base.Employee)this.itemManager.Operator).Dept;
            //出库单号
            string outListNO = phaProcess.GetInOutListNO( stockDept.ID, false );     
            //入库批次号
            string groupNO = this.itemManager.GetNewGroupNO();
            if (groupNO == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( "获取新协定处方批次号发生错误 " + this.itemManager.Err );
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "协定处方包装库存处理...");
            Application.DoEvents();

            for (int i = 0; i < this.fpPackageList_Sheet1.Rows.Count; i++)
            {
                //1. 获取当前进行包装处理的协定处方
                Neusoft.HISFC.Models.Pharmacy.Item selectNostrum = this.fpPackageList_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.Item;
                //计划数量
                decimal planQty = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.fpPackageList_Sheet1.Cells[i, (int)ColPackageList.ColPlanQty].Text );
                
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在对 " + selectNostrum.Name + "  进行库存处理");
                Application.DoEvents();
                //2. 获取协定处方构成明细
                List<Neusoft.HISFC.Models.Pharmacy.Nostrum> detailNostrumList = this.fpPackageList_Sheet1.Cells[i, (int)ColPackageList.ColDetail].Tag as List<Neusoft.HISFC.Models.Pharmacy.Nostrum>;
                if (detailNostrumList == null)
                {
                    detailNostrumList = this.itemManager.QueryNostrumDetail( selectNostrum.ID );
                }
                //3. 根据协定处方构成明细，对明细药品进行出库处理
                foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum info in detailNostrumList)
                {
                    #region 处方明细出库

                    //3.1 对明细药品逐条进行出库处理
                    Neusoft.HISFC.Models.Pharmacy.Item detailItem = this.itemManager.GetItem( info.Item.ID );
                    if (detailItem == null)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show( "处理处方明细出库，根据药品编码获取药品名称发生错误 " + this.itemManager.Err );
                        return -1;
                    }

                    //info.Qty 即协定处方维护内的数量即为生产1单位成品所需的数量，此处直接相乘即所需明细的最小单位库存量
                    decimal outQty = planQty * info.Qty;            

                    if (this.itemManager.NostrumPackageOutput( detailItem, outQty, stockDept, operEnvironment, outListNO ) == -1)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show( "处理处方明细出库，进行出库操作发生错误 " + this.itemManager.Err );
                        return -1;
                    }

                    #endregion
                }
                //4. 对协定处方进行入库处理

                #region 处方入库处理

                Neusoft.HISFC.Models.Pharmacy.Input input = new Neusoft.HISFC.Models.Pharmacy.Input();

                decimal inQty = planQty * selectNostrum.PackQty;

                #region 实体赋值

                input.Class2Type = "0310";
                input.SystemType = Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum( Neusoft.HISFC.Models.Base.EnumIMAInType.ProduceInput );                            //系统类型＝出库申请类型;				//"R1" 制剂管理类型
                input.PrivType = input.SystemType;					//制剂管理类型
                input.InListNO = outListNO;

                input.Item = selectNostrum;

                input.StockDept = stockDept;
                input.Company = stockDept;
                input.Producer = stockDept;

                input.TargetDept = stockDept;
                input.GroupNO = Neusoft.FrameWork.Function.NConvert.ToDecimal( groupNO );

                input.BatchNO = this.fpPackageList_Sheet1.Cells[i, (int)ColPackageList.ColBatchNO].Text;
                if (string.IsNullOrEmpty( input.BatchNO ) == true)
                {
                    input.BatchNO = "1";
                }
                input.ValidTime = Neusoft.FrameWork.Function.NConvert.ToDateTime( this.fpPackageList_Sheet1.Cells[i, (int)ColPackageList.ColValidDate].Text );
                if (input.ValidTime < sysTime)
                {
                    input.ValidTime = sysTime.AddYears( 10 );
                }

                input.Quantity = inQty;
                input.Operation.ApplyQty = inQty;
                input.Operation.ExamQty = inQty;

                input.Operation.ApplyOper = operEnvironment;

                input.State = "2";
                input.Operation.ExamOper = operEnvironment;
                input.Operation.ApproveOper = operEnvironment;

                #endregion

                #region 购入价计算

                ArrayList alOutputList = this.itemManager.QueryOutputInfo( stockDept.ID, outListNO, "A" );
                if (alOutputList != null)
                {
                    input.PurchaseCost = 0;
                    foreach (Neusoft.HISFC.Models.Pharmacy.Output outputTemp in alOutputList)
                    {
                        input.PurchaseCost += outputTemp.PurchaseCost;
                    }

                    input.PriceCollection.PurchasePrice = Math.Round( input.PurchaseCost / (input.Quantity / input.Item.PackQty), 4 );
                }

                #endregion

                if (this.itemManager.Input( input, "1" ) == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( "处理处方成品入库，进行入库操作发生错误 " + this.itemManager.Err );
                    return -1;
                }

                #endregion
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show( "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );

            this.Clear();

            return 1;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            this.Init();

            base.OnLoad( e );
        }

        private void txtFilter_Enter(object sender, EventArgs e)
        {
            this.txtFilter.Text = "";
            this.txtFilter.ForeColor = System.Drawing.Color.Black;
        }

        private void txtFilter_Leave(object sender, EventArgs e)
        {
            this.txtFilter.Text = "拼音码\\五笔码过滤";
            this.dt.DefaultView.RowFilter = "1=1";

            this.txtFilter.ForeColor = System.Drawing.Color.LightGray;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.dt != null)
            {
                if (this.dt.Columns.Contains( "拼音码" ) && this.dt.Columns.Contains( "五笔码" ))
                {
                    string filterStr = string.Format( "拼音码 like '%{0}%' or 五笔码 like '%{0}%' ", this.txtFilter.Text.ToUpper() );

                    this.dt.DefaultView.RowFilter = filterStr;
                }
            }
        }

        private void fpNostrumList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.ChooseNostrum();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ChooseNostrum();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.fpNostrumList_Sheet1.ActiveRowIndex++;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.fpNostrumList_Sheet1.ActiveRowIndex--;
            }
        }

        private void fpPackageList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            Neusoft.HISFC.Models.Pharmacy.Item selectNostrum = this.fpPackageList_Sheet1.Rows[this.fpPackageList_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.Item;

            if (selectNostrum != null)
            {
                this.ShowNostrumDetail( this.fpPackageList_Sheet1.ActiveRowIndex, selectNostrum );
            }
        }
    }
}
