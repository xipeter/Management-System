using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂主实现]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>
    ///    1 通过属性设置实现,取代工作流思路
    ///    2 单据打印不通过接口来实现，可通过工艺流程的自定义设置来实现打印
    /// 
    ///    2 当前编写进度: 再一张计划单包含多种药品的情况下，如何处理自定义消耗量的问题
    ///                    生产流程图录入、调用
    ///    6 成本价(购入价)计算
    ///         --如果取出的价格为0 则根据公式、消耗默认计算
    ///         --如果价格不为0 不进行处理
    ///         --可手工修改，显示消耗、公式信息进行调整
    ///         公式部分待处理调整
    ///    8 工艺流程数据与主界面数据的同步问题
    /// </说明>
    /// </summary>
    public partial class ucPPRManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl , Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucPPRManager ( )
        {
            InitializeComponent ( );
        }

        #region 域变量

        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation ( );

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharamcyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy ( );

        /// <summary>
        /// 制剂计划状态
        /// </summary>
        private Neusoft.HISFC.Models.Preparation.EnumState listState = Neusoft.HISFC.Models.Preparation.EnumState.Plan;

        /// <summary>
        /// 界面显示是否使用包装单位
        /// </summary>
        private bool isUsePackUnit = true;

        /// <summary>
        /// 下一状态
        /// </summary>
        private Neusoft.HISFC.Models.Preparation.EnumState saveState = Neusoft.HISFC.Models.Preparation.EnumState.Confect;

        /// <summary>
        /// 本次填写后，在下一审核前是否允许修改
        /// </summary>
        private bool isCanReSet = false;

        /// <summary>
        /// 是否更新配置人员信息
        /// </summary>
        private bool isUpdateConfectOper = false;

        /// <summary>
        /// 是否更新检验人员信息
        /// </summary>
        private bool isUpdateAssayOper = false;

        /// <summary>
        /// 是否更新入库人员信息
        /// </summary>
        private bool isUpdateInputOper = false;

        /// <summary>
        /// 是否扣除原料
        /// </summary>
        private bool isExpandMaterial = false;

        /// <summary>
        /// 是否进行成品入库
        /// </summary>
        private bool isInputDrug = false;

        /// <summary>
        /// 处方药品集合
        /// </summary>
        private System.Collections.ArrayList alPrescription = null;

        /// <summary>
        /// 库存操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject stockDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 提示信息
        /// </summary>
        private string noticeStr = "";
        #endregion

        #region 接口

        /// <summary>
        /// 生产工艺流程接口
        /// </summary>
        HISFC.Components.Preparation.IProcess processInterface = null;

        #endregion

        #region 属性

        /// <summary>
        /// 制剂状态
        /// </summary>
        [Category ( "设置" ) , Description ( "设置制剂生产状态" )]
        public Neusoft.HISFC.Models.Preparation.EnumState ListState
        {
            get
            {
                return this.listState;
            }
            set
            {
                this.listState = value;
            }
        }

        /// <summary>
        /// 制剂下一工作状态
        /// </summary>
        [Category ( "设置" ) , Description ( "设置制剂下一生产状态" )]
        public Neusoft.HISFC.Models.Preparation.EnumState SaveState
        {
            get
            {
                return this.saveState;
            }
            set
            {
                this.saveState = value;

                switch ( value )
                {
                    case Neusoft.HISFC.Models.Preparation.EnumState.Plan:       //计划
                    case Neusoft.HISFC.Models.Preparation.EnumState.Input:      //入库
                    this.isUsePackUnit = true;
                    break;
                    default:
                    this.isUsePackUnit = false;
                    break;
                }

                this.SetFormat ( );

                this.SetExpand ( );
            }
        }

        /// <summary>
        /// 本次填写后，在下一审核前是否允许修改
        /// </summary>
        [Category ( "设置" ) , Description ( "本次填写后，在下一审核前是否允许修改" )]
        public bool IsCanReSet
        {
            get
            {
                return this.isCanReSet;
            }
            set
            {
                this.isCanReSet = value;
            }
        }

        /// <summary>
        /// 是否更新配置人员信息
        /// </summary>
        [Category ( "设置" ) , Description ( "是否更新配置人员信息" )]
        public bool IsUpdateConfectOper
        {
            get
            {
                return this.isUpdateConfectOper;
            }
            set
            {
                this.isUpdateConfectOper = value;
            }
        }

        /// <summary>
        /// 是否更新检验人员信息
        /// </summary>
        [Category ( "设置" ) , Description ( "是否更新检验人员信息" )]
        public bool IsUpdateAssayOper
        {
            get
            {
                return this.isUpdateAssayOper;
            }
            set
            {
                this.isUpdateAssayOper = value;
            }
        }

        /// <summary>
        /// 是否更新入库人员信息
        /// </summary>
        [Category ( "设置" ) , Description ( "是否更新入库人员信息" )]
        public bool IsUpdateInputOper
        {
            get
            {
                return this.isUpdateInputOper;
            }
            set
            {
                this.isUpdateInputOper = value;
            }
        }

        /// <summary>
        /// 是否扣除原料
        /// </summary>
        [Category ( "设置" ) , Description ( "本次是否扣除原料" )]
        public bool IsExpandMaterial
        {
            get
            {
                return this.isExpandMaterial;
            }
            set
            {
                this.isExpandMaterial = value;
            }
        }

        /// <summary>
        /// 本次是否进行成品入库
        /// </summary>
        [Category ( "设置" ) , Description ( "本次是否进行成品入库" )]
        public bool IsInputDrug
        {
            get
            {
                return this.isInputDrug;
            }
            set
            {
                this.isInputDrug = value;
            }
        }

        /// <summary>
        /// 设置提示信息显示
        /// </summary>
        [Category ( "设置" ) , Description ( "设置提示信息显示" )]
        public string NoticeStr
        {
            get
            {
                return this.noticeStr;
            }
            set
            {
                if ( value == "" )
                {
                    this.gbNotice.Visible = false;
                }
                else
                {
                    this.gbNotice.Visible = true;
                    this.noticeStr = value;
                    this.lbNotice.Text = value;
                }
            }
        }
        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService ( );

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit ( object sender , object neuObject , object param )
        {
            this.toolBarService.AddToolButton ( "增加" , "新增制剂计划明细" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加 , true , false , null );
            this.toolBarService.AddToolButton ( "新建" , "新建制剂计划单" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建 , true , false , null );
            this.toolBarService.AddToolButton ( "工艺流程" , "工艺流程录入" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.H化验 , true , false , null );
            this.toolBarService.AddToolButton ( "删除" , "删除未开始配置的计划单明细" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除 , true , false , null );
            this.toolBarService.AddToolButton ( "成本调整" , "调整选择项目的成本价" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置 , true , false , null );

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
        {
            if ( e.ClickedItem.Text == "增加" )
            {
                this.AddNewPreparationDetail ( );
            }
            if ( e.ClickedItem.Text == "新建" )
            {
                this.NewPreparation ( );
            }
            if ( e.ClickedItem.Text == "工艺流程" )
            {
                this.SetProcess ( );
            }
            if ( e.ClickedItem.Text == "删除" )
            {
                this.DelPreparationPlanDetail ( );
            }
            if ( e.ClickedItem.Text == "成本调整" )
            {
                Neusoft.HISFC.Models.Preparation.Preparation ppr = this.GetDrugFromFp ( this.fsDrug_Sheet1.ActiveRowIndex );

                this.ComputeCostPrice ( ref ppr , ComputeCostPriceType.Manual );

                this.fsDrug_Sheet1.Cells [ this.fsDrug_Sheet1.ActiveRowIndex , ( int ) DrugColumnSet.ColCostPrice ].Text = ppr.CostPrice.ToString ( );
            }
            base.ToolStrip_ItemClicked ( sender , e );
        }

        protected override int OnSave ( object sender , object neuObject )
        {
            switch (this.saveState)
            {
                case Neusoft.HISFC.Models.Preparation.EnumState.Plan:
                    if (this.SavePreparationPlan() == -1)
                    {
                        return -1;
                    }
                    break;
                default:
                    if (this.SavePreparation() == -1)
                    {
                        return -1;
                    }
                    break;
            }

            this.ShowList ( );

            return 1;
        }

        #endregion

        #region 计划列表树处理

        /// <summary>
        /// 科室计划列表树
        /// </summary>
        private tvPlanList tvList = null;

        /// <summary>
        /// 树列表加载
        /// </summary>
        /// <returns></returns>
        protected int ShowList ( )
        {
            if ( this.tvList != null )
            {
                if ( this.isCanReSet )
                {
                    this.tvList.ShowPlanList ( this.listState , this.saveState );
                }
                else
                {
                    this.tvList.ShowPlanList ( this.listState );
                }
            }

            return 1;
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected int Init ( )
        {
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType ( );
            this.fsDrug_Sheet1.Columns [ ( int ) DrugColumnSet.ColCostPrice ].CellType = markNumCellType;
            this.fsDrug_Sheet1.Columns [ ( int ) DrugColumnSet.ColInQty ].CellType = markNumCellType;
            this.fsDrug_Sheet1.Columns [ ( int ) DrugColumnSet.ColPlanNum ].CellType = markNumCellType;
            this.fsDrug_Sheet1.Columns [ ( int ) DrugColumnSet.ColConfectQty ].CellType = markNumCellType;

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType markDateCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType ( );
            this.fsDrug_Sheet1.Columns [ ( int ) DrugColumnSet.ColValidDate ].CellType = markDateCellType;

            this.InitPreparationDrug ( );

            return 1;
        }

        /// <summary>
        /// 初始化制剂成品列表
        /// </summary>
        /// <returns></returns>
        protected int InitPreparationDrug ( )
        {
            List<Neusoft.FrameWork.Models.NeuObject> prescriptionList = this.preparationManager.QueryPrescriptionList ( Neusoft.HISFC.Models.Base.EnumItemType.Drug);
            if ( prescriptionList == null )
            {
                MessageBox.Show ( Language.Msg ( "加载制剂处方列表信息发生错误" ) + this.preparationManager.Err );
                return -1;
            }

            this.alPrescription = new System.Collections.ArrayList ( prescriptionList.ToArray ( ) );

            return 1;
        }

        #endregion

        #region 数据检索 加载显示

        /// <summary>
        /// 根据生产计划号显示生产计划信息
        /// </summary>
        /// <param name="planNO">生产计划单号</param>
        internal void ShowPreparation ( string planNO )
        {
            List<Neusoft.HISFC.Models.Preparation.Preparation> preparationList = null;
            if ( this.isCanReSet )        //在下一状态审核前可以修改。
            {
                preparationList = preparationManager.QueryPreparation ( planNO , this.listState , this.saveState );
            }
            else
            {
                preparationList = preparationManager.QueryPreparation ( planNO , this.listState );
            }
            if ( preparationList == null )
            {
                MessageBox.Show ( Language.Msg ( "根据生产计划流水号及生产状态获取制剂生产信息发生错误" ) + preparationManager.Err );
                return;
            }

            this.Clear ( true );

            foreach ( Neusoft.HISFC.Models.Preparation.Preparation info in preparationList )
            {
                Neusoft.HISFC.Models.Preparation.Preparation facualInfo = info.Clone ( );
                this.ComputeCostPrice ( ref facualInfo , ComputeCostPriceType.Auto );

                this.AddDrugToFp ( facualInfo );
            }

            if ( this.fsDrug_Sheet1.ActiveRowIndex >= 0 )
            {
                this.ShowExpandPrescription ( this.fsDrug_Sheet1.ActiveRowIndex );
            }
        }

        /// <summary>
        /// 制剂原料消耗信息显示
        /// </summary>
        /// <param name="info">制剂成品计划信息</param>
        internal protected void ShowExpandPrescription ( int rowIndex )
        {
            Neusoft.HISFC.Models.Preparation.Preparation info = this.GetDrugFromFp ( rowIndex );
            if ( info != null )
            {
                this.ShowExpandPrescription ( info );
            }
        }

        /// <summary>
        /// 制剂原料消耗信息显示
        /// </summary>
        /// <param name="info">制剂成品计划信息</param>
        internal protected void ShowExpandPrescription ( Neusoft.HISFC.Models.Preparation.Preparation info )
        {
            this.ucExpand1.Clear ( );

            this.ucExpand1.PlanNO = info.PlanNO;
            this.ucExpand1.ShowExpand ( info );
        }

        #endregion

        #region Fp内数据操作 赋值/获取信息

        /// <summary>
        /// 添加制剂成品计划信息
        /// </summary>
        /// <param name="info">制剂成品计划信息</param>
        protected void AddDrugToFp ( Neusoft.HISFC.Models.Preparation.Preparation info )
        {
            int rowCoount = this.fsDrug_Sheet1.Rows.Count;
            this.fsDrug_Sheet1.Rows.Add ( rowCoount , 1 );

            this.AddDrugToFp ( info , rowCoount , true );
        }

        /// <summary>
        /// 添加制剂成品计划信息
        /// </summary>
        /// <param name="info">制剂成品计划信息</param>
        protected void AddDrugToFp ( Neusoft.HISFC.Models.Preparation.Preparation info , int rowIndex , bool refreshDrug )
        {
            try
            {
                if ( refreshDrug )
                {
                    Neusoft.HISFC.Models.Pharmacy.Item item = this.pharamcyIntegrate.GetItem ( info.Drug.ID );
                    info.Drug = item;

                    if ( info.CostPrice == 0 )
                    {
                        info.CostPrice = item.PriceCollection.PurchasePrice;
                    }
                }

                this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColDrugName ].Text = info.Drug.Name;
                this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColSpecs ].Text = info.Drug.Specs;
                this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColPackQty ].Text = info.Drug.PackQty.ToString ( );
                this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColPackUnit ].Text = info.Drug.PackUnit;
                this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColMemo ].Text = info.Memo;

                this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColAssayResult ].Value = info.IsAssayEligible;

                if ( this.isUsePackUnit )
                {
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColPlanNum ].Text = ( info.PlanQty / info.Drug.PackQty ).ToString ( );
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColPlanUnit ].Text = info.Drug.PackUnit;
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColConfectQty ].Text = ( info.ConfectQty / info.Drug.PackQty ).ToString ( );
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColInQty ].Text = ( info.InputQty / info.Drug.PackQty ).ToString ( );
                }
                else
                {
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColPlanNum ].Text = info.PlanQty.ToString ( );
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColPlanUnit ].Text = info.Unit;
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColConfectQty ].Text = info.ConfectQty.ToString ( );
                    this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColInQty ].Text = info.InputQty.ToString ( );
                }

                this.fsDrug_Sheet1.Cells [ rowIndex , ( int ) DrugColumnSet.ColCostPrice ].Text = info.CostPrice.ToString ( );

                this.fsDrug_Sheet1.Cells[rowIndex, (int)DrugColumnSet.ColAssayQty].Text = info.AssayQty.ToString();

                this.fsDrug_Sheet1.Rows [ rowIndex ].Tag = info;
            }
            catch ( Exception ex )
            {
                MessageBox.Show ( ex.Message );
            }
        }

        /// <summary>
        /// 根据行索引
        /// </summary>
        /// <param name="inde"></param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.Preparation.Preparation GetDrugFromFp ( int index )
        {
            Neusoft.HISFC.Models.Preparation.Preparation info = this.fsDrug_Sheet1.Rows [ index ].Tag as Neusoft.HISFC.Models.Preparation.Preparation;
            if ( info == null )
            {
                return null;
            }
            if ( this.isUsePackUnit )         //以最小单位保存
            {
                info.PlanQty = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColPlanNum ].Text ) * info.Drug.PackQty;
                info.InputQty = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColInQty ].Text ) * info.Drug.PackQty;
                info.ConfectQty = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColConfectQty ].Text ) * info.Drug.PackQty;
            }
            else
            {
                info.PlanQty = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColPlanNum ].Text );
                info.InputQty = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColInQty ].Text );
                info.ConfectQty = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColConfectQty ].Text );
            }

            //{74EC6D6F-CD5F-446c-BB07-A23BE80F1885}  获取检验是否合格标记赋值问题
            info.IsAssayEligible = Neusoft.FrameWork.Function.NConvert.ToBoolean ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColAssayResult ].Value);
            info.BatchNO = this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColBatchNO ].Text;
            info.ValidDate = Neusoft.FrameWork.Function.NConvert.ToDateTime ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColValidDate ].Text );
            info.AssayQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsDrug_Sheet1.Cells[index, (int)DrugColumnSet.ColAssayQty].Text);

            //info.Unit = this.fsDrug_Sheet1.Cells[index, (int)DrugColumnSet.ColPlanUnit].Text;
            info.Unit = info.Drug.MinUnit;
            info.CostPrice = NConvert.ToDecimal ( this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColCostPrice ].Text );
            info.Memo = this.fsDrug_Sheet1.Cells [ index , ( int ) DrugColumnSet.ColMemo ].Text;

            return info;
        }

        /// <summary>
        /// 刷新Fp显示数据
        /// </summary>
        /// <param name="info"></param>
        public void RefreshFpData ( Neusoft.HISFC.Models.Preparation.Preparation info )
        {
            this.AddDrugToFp ( info , this.fsDrug_Sheet1.ActiveRowIndex , false );
        }

        #endregion

        #region  可继承进行重新实现 设置界面、Fp、Expand信息显示、数据校验、工艺流程记录

        /// <summary>
        /// 格式化
        /// </summary>
        protected virtual void SetFormat ( )
        {
            switch (this.SaveState)
            {
                case Neusoft.HISFC.Models.Preparation.EnumState.Plan:

                    #region Fp格式化

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayResult].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColBatchNO].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColValidDate].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColConfectQty].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColInQty].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColCostPrice].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayQty].Visible = false;

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColDrugName].Width = 160;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColSpecs].Width = 90;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackQty].Width = 80;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackUnit].Width = 80;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Width = 90;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanUnit].Width = 60;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColMemo].Width = 180;

                    #endregion

                    break;
                case Neusoft.HISFC.Models.Preparation.EnumState.Confect:
                case Neusoft.HISFC.Models.Preparation.EnumState.Division:

                    #region Fp格式化

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayResult].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColBatchNO].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColValidDate].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColConfectQty].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColInQty].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Locked = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColCostPrice].Visible = false;

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColDrugName].Width = 160;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColSpecs].Width = 90;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackQty].Width = 75;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackUnit].Width = 75;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Width = 90;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanUnit].Width = 60;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColMemo].Width = 180;

                    #endregion

                    break;
                case Neusoft.HISFC.Models.Preparation.EnumState.Input:

                    #region Fp格式化

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayResult].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColBatchNO].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColValidDate].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColConfectQty].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColInQty].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Locked = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColCostPrice].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayQty].Visible = false;

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColDrugName].Width = 120;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColSpecs].Width = 60;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackQty].Width = 70;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackUnit].Width = 70;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Width = 80;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanUnit].Width = 60;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColMemo].Width = 120;

                    #endregion

                    break;

                case Neusoft.HISFC.Models.Preparation.EnumState.SemiAssay:
                case Neusoft.HISFC.Models.Preparation.EnumState.PackAssay:

                    #region Fp格式化

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayResult].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColBatchNO].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColValidDate].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColConfectQty].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColInQty].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Locked = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColCostPrice].Visible = false;

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColDrugName].Width = 180;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColSpecs].Width = 90;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackQty].Width = 75;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackUnit].Width = 75;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Width = 100;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanUnit].Width = 60;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColMemo].Width = 180;

                    #endregion

                    break;

                case Neusoft.HISFC.Models.Preparation.EnumState.Package:

                    #region Fp格式化

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayResult].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColBatchNO].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColValidDate].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColConfectQty].Visible = false;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColInQty].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Locked = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColCostPrice].Visible = true;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColAssayQty].Visible = false;

                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColDrugName].Width = 160;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColSpecs].Width = 80;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackQty].Width = 70;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPackUnit].Width = 70;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanNum].Width = 80;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColPlanUnit].Width = 60;
                    this.fsDrug_Sheet1.Columns[(int)DrugColumnSet.ColMemo].Width = 120;

                    #endregion

                    break;
            }
        }

        /// <summary>
        /// 是否可编辑消耗信息
        /// </summary>
        protected virtual void SetExpand ( )
        {
            switch ( this.saveState )
            {
                case Neusoft.HISFC.Models.Preparation.EnumState.Plan:
                case Neusoft.HISFC.Models.Preparation.EnumState.Confect:
                this.ucExpand1.IsCanEdit = true;
                break;
                default:
                this.ucExpand1.IsCanEdit = false;
                break;
            }
        }

        /// <summary>
        /// 生产工艺流程记录
        /// </summary>
        protected virtual int SetProcess ( )
        {
            if ( this.fsDrug_Sheet1.Rows.Count <= 0 )
            {
                return 1;
            }

            Neusoft.HISFC.Models.Preparation.Preparation info = this.GetDrugFromFp ( this.fsDrug_Sheet1.ActiveRowIndex );

            if ( this.processInterface == null )
            {
                this.processInterface = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject ( this.GetType ( ) , typeof ( Neusoft.HISFC.Components.Preparation.IProcess ) ) as Neusoft.HISFC.Components.Preparation.IProcess;
            }
            if ( this.processInterface != null )
            {
                this.processInterface.SetProcess ( this.saveState , info );
            }
            else
            {
                switch ( this.saveState )
                {
                    case Neusoft.HISFC.Models.Preparation.EnumState.Confect:

                    #region 配置信息录入

                    using ( Process.ucConfectProcess uc = new Neusoft.HISFC.Components.Preparation.Process.ucConfectProcess ( ) )
                    {
                        uc.SetPreparation ( info );

                        Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "生产工艺流程信息录入";
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl ( uc );

                        if ( uc.Result == DialogResult.OK )
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }

                    #endregion

                    case Neusoft.HISFC.Models.Preparation.EnumState.Division:

                    #region 分装信息录入

                    using ( Process.ucDivisionProcess uc = new Neusoft.HISFC.Components.Preparation.Process.ucDivisionProcess ( ) )
                    {
                        uc.SetPreparation ( info );

                        Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "生产工艺流程信息录入";
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl ( uc );

                        if ( uc.Result == DialogResult.OK )
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }

                    #endregion

                    case Neusoft.HISFC.Models.Preparation.EnumState.Input:

                    #region 入库信息录入

                    using ( Process.ucInputProcess uc = new Neusoft.HISFC.Components.Preparation.Process.ucInputProcess ( ) )
                    {
                        uc.SetPreparation ( info );

                        Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "生产工艺流程信息录入";
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl ( uc );

                        if ( uc.Result == DialogResult.OK )
                        {
                            this.RefreshFpData ( info );

                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }

                    #endregion

                    case Neusoft.HISFC.Models.Preparation.EnumState.SemiAssay:

                    #region 半成品检验信息录入

                    using ( Process.ucSemiAssayProcess uc = new Neusoft.HISFC.Components.Preparation.Process.ucSemiAssayProcess ( ) )
                    {
                        uc.SetPreparation ( info );

                        Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "生产工艺流程信息录入";
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl ( uc );

                        if ( uc.Result == DialogResult.OK )
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }

                    #endregion

                    case Neusoft.HISFC.Models.Preparation.EnumState.Package:

                    #region 外包装信息录入

                    using ( Process.ucPackageProcess uc = new Neusoft.HISFC.Components.Preparation.Process.ucPackageProcess ( ) )
                    {
                        uc.SetPreparation ( info );

                        Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "生产工艺流程信息录入";
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl ( uc );

                        if ( uc.Result == DialogResult.OK )
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }

                    #endregion

                    case Neusoft.HISFC.Models.Preparation.EnumState.PackAssay:

                    #region 成品检验信息录入

                    using ( Process.frmAssayProcess uc = new Neusoft.HISFC.Components.Preparation.Process.frmAssayProcess ( ) )
                    {
                        uc.SetPreparation ( info );

                        //Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "生产工艺流程信息录入";
                        //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                        uc.ShowDialog ( );

                        //if (uc.Result == DialogResult.OK)
                        //{
                        //    return 1;
                        //}
                        //else
                        //{
                        //    return -1;
                        //}
                    }

                    #endregion

                    break;
                }
            }

            return 1;
        }

        /// <summary>
        /// 数据有效性校验
        /// </summary>
        /// <returns></returns>
        protected virtual bool DataValid()
        {
            //{7AD459B7-0533-46f1-B39E-8A36810377F5} 增加对检验合格的判断
            for (int i = 0; i < this.fsDrug_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Preparation.Preparation info = this.GetDrugFromFp(i);
                if (this.saveState == Neusoft.HISFC.Models.Preparation.EnumState.SemiAssay || this.saveState == Neusoft.HISFC.Models.Preparation.EnumState.PackAssay)
                {
                    if (info.IsAssayEligible == false)
                    {
                        DialogResult rs = MessageBox.Show(Language.Msg("该制剂计划内存在检验不合格的制剂！确认保存吗？"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rs == DialogResult.No)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #region 制剂计划的成立  新建/修改/保存

        /// <summary>
        /// 添加制剂计划信息
        /// </summary>
        protected void NewPreparation ( )
        {
            this.fsDrug_Sheet1.Rows.Count = 0;

            this.fsDrug_Sheet1.Rows.Add ( 0 , 1 );
        }

        /// <summary>
        /// 新增制剂计划信息
        /// </summary>
        protected void AddNewPreparationDetail ( )
        {
            this.fsDrug_Sheet1.Rows.Add ( this.fsDrug_Sheet1.Rows.Count , 1 );
        }

        /// <summary>
        /// 删除制剂计划明细
        /// </summary>
        protected void DelPreparationPlanDetail ( )
        {
            if ( this.fsDrug_Sheet1.Rows.Count < 0 )
            {
                return;
            }

            DialogResult rs = MessageBox.Show ( Neusoft.FrameWork.Management.Language.Msg ( "是否确认删除当前选择的计划信息" ) , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question );
            if ( rs == DialogResult.No )
            {
                return;
            }

            Neusoft.HISFC.Models.Preparation.Preparation info = this.fsDrug_Sheet1.Rows [ this.fsDrug_Sheet1.ActiveRowIndex ].Tag as Neusoft.HISFC.Models.Preparation.Preparation;
            if ( info != null )
            {
                if ( this.preparationManager.DelPreparation ( info.PlanNO , info.Drug.ID ) == -1 )
                {
                    MessageBox.Show ( Neusoft.FrameWork.Management.Language.Msg ( "删除制剂计划明细信息失败" ) + this.preparationManager.Err );
                    return;
                }
            }

            this.fsDrug_Sheet1.Rows.Remove ( this.fsDrug_Sheet1.ActiveRowIndex , 1 );

            if (this.fsDrug_Sheet1.Rows.Count == 0)
            {
                this.ucExpand1.Clear();
                this.ShowList();
            }
        }

        /// <summary>
        /// 制剂主信息、制剂计划保存
        /// </summary>
        internal protected int SavePreparationPlan ( )
        {
            if ( this.fsDrug_Sheet1.Rows.Count <= 0 )
            {
                return 0;
            }

            #region  保存当前制剂成品的消耗信息

            if (!string.IsNullOrEmpty(this.ucExpand1.PlanNO))
            {
                string msg = "";
                if (this.ucExpand1.SaveExpandInfo(true, ref msg) == -1)
                {
                    MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }

            #endregion

            //根据当前库存量及理论消耗量判断是否需要发送原材料申请
            System.Collections.Generic.Dictionary<string, bool> autoApplyList = new Dictionary<string, bool>();
            for (int i = 0; i < this.fsDrug_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Preparation.Preparation info = this.GetDrugFromFp(i);

                //{64FAE14C-7D1B-42ea-B19D-2C1B3846D2D0} 申请信息自动生成时 
                autoApplyList.Add(info.Drug.ID, this.ucExpand1.ValidStock(info, true));
            }


            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction ( );

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy ( );          
            this.preparationManager.SetTrans ( Neusoft.FrameWork.Management.PublicTrans.Trans );

            string planNO = "";

            DateTime sysTime = this.preparationManager.GetDateTimeFromSysDateTime ( );

            for ( int i = 0; i < this.fsDrug_Sheet1.Rows.Count; i++ )
            {
                #region 数据保存

                Neusoft.HISFC.Models.Preparation.Preparation info = this.GetDrugFromFp ( i );
                if ( info == null )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                    MessageBox.Show ( Language.Msg ( "由Fp内获取制剂信息发生错误" ) );
                    return -1;
                }

                #region 生产计划号处理

                if ( planNO == "" )
                {
                    if ( info.PlanNO == "" || info.PlanNO == null )
                    {
                        pharmacyIntegrate.GetCommonListNO((( Neusoft.HISFC.Models.Base.Employee ) this.preparationManager.Operator ).Dept.ID);
                        if ( planNO == null )
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                            MessageBox.Show ( Language.Msg ( "获取生产计划号发生错误" ) + pharmacyIntegrate.Err );
                            return -1;
                        }
                    }
                    else
                    {
                        planNO = info.PlanNO;
                    }
                }

                #endregion

                info.PlanNO = planNO;
                info.PlanEnv.ID = this.preparationManager.Operator.ID;
                info.PlanEnv.OperTime = sysTime;
                info.OperEnv = info.PlanEnv;

                if ( this.preparationManager.PreparationPlan ( info ) == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                    MessageBox.Show ( Language.Msg ( "进行制剂计划信息保存发生错误" ) + this.preparationManager.Err );
                    return -1;
                }

                #endregion

                #region 原材料库存判断

                if (autoApplyList.ContainsKey(info.Drug.ID))
                {
                    if (autoApplyList[info.Drug.ID])
                    {
                        string strErr = "";
                        this.ucExpand1.PlanNO = info.PlanNO;

                        if (this.ucExpand1.SaveExpandForStock(info, true, ref strErr) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg(strErr));
                            return -1;
                        }
                    }
                }

                #endregion
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit ( );
            MessageBox.Show(Language.Msg("保存成功"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //刷新列表显示
            return this.ShowList();
        }

        #endregion

        /// <summary>
        /// 清屏计算
        /// </summary>
        /// <param name="isClearDrug">是否清除消耗信息</param>        
        internal protected void Clear ( bool isClearExpandDrug )
        {
            this.fsDrug_Sheet1.Rows.Count = 0;
            if ( isClearExpandDrug )
            {
                this.ucExpand1.Clear ( );
            }
        }

        /// <summary>
        /// 入库科室配置
        /// </summary>
        /// <param name="inTargetDept">入库目标科室</param>
        /// <param name="isApply">是否需要申请</param>
        private int ConfigInputSetting(ref Neusoft.FrameWork.Models.NeuObject inTargetDept, out bool isNeedApply)
        {
            return ucChooseData.ChooseInputTargetData ( this.stockDept , ref inTargetDept , out isNeedApply );
        }

        /// <summary>
        /// 成本价计算
        /// </summary>
        /// <returns></returns>
        private int ComputeCostPrice ( ref Neusoft.HISFC.Models.Preparation.Preparation preparation , ComputeCostPriceType computeType )
        {
            if ( preparation.CostPrice == 0 || computeType == ComputeCostPriceType.Manual )
            {
                return ucCostPrice.ComputeCostPrice ( this.preparationManager , ref preparation , computeType );
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 制剂主信息、生产流程保存
        /// </summary>
        internal protected int SavePreparation ( )
        {
            if (this.fsDrug_Sheet1.Rows.Count <= 0)
            {
                return 0;
            }

            #region 工艺流程、入库 信息判断补充

            //数据校验
            if (!this.DataValid())
            {
                return -1;
            }

            if (this.isExpandMaterial)
            {
                DialogResult materialRs = MessageBox.Show(Language.Msg("请确认当前原材料消耗信息设置是否正确?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (materialRs == DialogResult.No)
                {
                    return -1;
                }
            }

            DialogResult rs = MessageBox.Show(Language.Msg("请确认已完成生产工艺流程的录入?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                if (this.SetProcess() == -1)
                {
                    return -1;
                }
            }

            Neusoft.FrameWork.Models.NeuObject inTargetDept = this.stockDept.Clone();
            bool isApply = false;
            if (this.isInputDrug)
            {
                if (this.ConfigInputSetting(ref inTargetDept, out isApply) == -1)
                {
                    return -1;
                }
            }

            #endregion

            #region  保存当前制剂成品的消耗信息

            if (!string.IsNullOrEmpty(this.ucExpand1.PlanNO))
            {
                string msg = "";
                if (this.ucExpand1.SaveExpandInfo(true, ref msg) == -1)
                {
                    MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }

            #endregion            

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction ( );

            this.preparationManager.SetTrans ( Neusoft.FrameWork.Management.PublicTrans.Trans );
            this.pharamcyIntegrate.SetTrans ( Neusoft.FrameWork.Management.PublicTrans.Trans );

            DateTime sysTime = this.preparationManager.GetDateTimeFromSysDateTime ( );

            List<Neusoft.HISFC.Models.Preparation.Preparation> inPreparationList = new List<Neusoft.HISFC.Models.Preparation.Preparation> ( );

            for ( int i = 0; i < this.fsDrug_Sheet1.Rows.Count; i++ )
            {
                Neusoft.HISFC.Models.Preparation.Preparation info = this.GetDrugFromFp ( i );
                if ( info == null )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                    MessageBox.Show ( Language.Msg ( "由Fp内获取制剂信息发生错误" ) );
                    return -1;
                }
                info.OperEnv.ID = this.preparationManager.Operator.ID;
                info.OperEnv.OperTime = sysTime;

                #region 制剂流程操作人员环境信息赋值

                if ( this.isUpdateConfectOper )
                {
                    info.ConfectEnv = info.OperEnv;
                    if ( this.preparationManager.UpdatePreparationConfect ( info ) == -1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                        MessageBox.Show ( Language.Msg ( "更新制剂配置人员信息发生错误" ) + this.preparationManager.Err );
                        return -1;
                    }
                }
                if ( this.isUpdateAssayOper )
                {
                    info.AssayEnv = info.OperEnv;
                    if ( this.preparationManager.UpdatePreparationAssay ( info ) == -1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                        MessageBox.Show ( Language.Msg ( "更新制剂检验人员信息发生错误" ) + this.preparationManager.Err );
                        return -1;
                    }
                }
                if ( this.isUpdateInputOper )
                {
                    info.InputEnv = info.OperEnv;
                    if ( this.preparationManager.UpdatePreparationInput ( info ) == -1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                        MessageBox.Show ( Language.Msg ( "更新制剂入库人员信息发生错误" ) + this.preparationManager.Err );
                        return -1;
                    }
                }

                #endregion

                #region 制剂状态更新

                if ( this.isCanReSet )
                {
                    if ( this.preparationManager.UpdatePreparationState ( info , this.saveState , this.listState , this.saveState ) == -1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                        MessageBox.Show ( Language.Msg ( "更新制剂状态信息发生错误" ) + this.preparationManager.Err );
                        return -1;
                    }
                }
                else
                {
                    if ( this.preparationManager.UpdatePreparationState ( info , this.saveState , this.listState ) == -1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                        MessageBox.Show ( Language.Msg ( "更新制剂状态信息发生错误" ) + this.preparationManager.Err );
                        return -1;
                    }
                }

                #endregion

                #region 原料扣除

                if (this.isExpandMaterial)
                {
                    string strErr = "";
                    if (this.ucExpand1.SaveExpandForStock(info, false, ref strErr) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        strErr = "制剂： " + info.Drug.Name + " 原材料库存扣除失败. \n  " + strErr;
                        MessageBox.Show(strErr);
                        return -1;
                    }
                }

                #endregion

                inPreparationList.Add ( info );
            }

            #region 成品入库

            if ( this.isInputDrug )
            {
                if ( pharamcyIntegrate.ProduceInput ( inPreparationList , this.stockDept , inTargetDept , isApply ) == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack ( );
                    MessageBox.Show ( Language.Msg ( "成品入库时发生错误" ) + pharamcyIntegrate.Err );
                    return -1;
                }
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit ( );
            MessageBox.Show(Language.Msg("保存成功"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return 1;
        }

        #region 事件处理

        protected override void OnLoad ( EventArgs e )
        {
            try
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
                {
                    this.stockDept = ((Neusoft.HISFC.Models.Base.Employee)this.preparationManager.Operator).Dept;
                    if (this.ucExpand1 != null)
                    {
                        this.ucExpand1.StockDept = this.stockDept;
                    }

                    this.Init();

                    this.tvList = this.tv as tvPlanList;

                    this.ShowList();
                }
            }
            catch
            { }

            base.OnLoad ( e );
        }

        protected override int OnSetValue ( object neuObject , TreeNode e )
        {
            this.Clear ( true );

            if ( e.Tag != null )
            {
                Neusoft.HISFC.Models.Preparation.Preparation info = e.Tag as Neusoft.HISFC.Models.Preparation.Preparation;
                if ( info != null )
                {
                    this.ShowPreparation ( info.PlanNO );
                }
            }
            return base.OnSetValue ( neuObject , e );
        }

        private void btnControl_Click ( object sender , EventArgs e )
        {
            if ( this.splitContainer1.Panel2Collapsed )
            {
                this.splitContainer1.Panel2Collapsed = false;
                this.btnControl.Text = "隐藏原材料消耗信息";
            }
            else
            {
                this.splitContainer1.Panel2Collapsed = true;
                this.btnControl.Text = "显示原材料消耗信息";
            }
        }

        private void fsDrug_CellDoubleClick ( object sender , FarPoint.Win.Spread.CellClickEventArgs e )
        {
            if ( e.Column == ( int ) DrugColumnSet.ColDrugName )
            {
                Neusoft.FrameWork.Models.NeuObject selectItem = new Neusoft.FrameWork.Models.NeuObject();
                if ( Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem ( this.alPrescription , ref selectItem ) == 1 )
                {
                    Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item ( );
                    Neusoft.HISFC.Models.Pharmacy.Item tempItem = itemManager.GetItem ( selectItem.ID );
                    if ( tempItem != null )
                    {
                        Neusoft.HISFC.Models.Preparation.Preparation info = new Neusoft.HISFC.Models.Preparation.Preparation ( );
                        info.Drug = tempItem;

                        this.AddDrugToFp ( info , e.Row , false );

                        this.fsDrug_Sheet1.ActiveRowIndex = this.fsDrug_Sheet1.Rows.Count - 1;
                        this.fsDrug_Sheet1.AddSelection ( this.fsDrug_Sheet1.Rows.Count - 1 , 0 , 1 , -1 );
                        this.fsDrug_SelectionChanged ( null , null );
                    }
                }
            }
        }

        private void fsDrug_EditModeOff ( object sender , EventArgs e )
        {
            if ( this.fsDrug_Sheet1.ActiveRowIndex >= 0 )
            {
                int index = this.fsDrug_Sheet1.ActiveRowIndex;

                this.ShowExpandPrescription ( index );
            }
        }

        private void fsDrug_SelectionChanged ( object sender , FarPoint.Win.Spread.SelectionChangedEventArgs e )
        {
            if ( this.fsDrug_Sheet1.ActiveRowIndex >= 0 )
            {
                int iIndex = this.fsDrug_Sheet1.ActiveRowIndex;

                this.ShowExpandPrescription ( iIndex );
            }
        }

        #endregion

        #region 列枚举

        protected enum DrugColumnSet
        {
            /// <summary>
            /// 成品名称
            /// </summary>
            ColDrugName ,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs ,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty ,
            /// <summary>
            /// 包装单位
            /// </summary>
            ColPackUnit ,
            /// <summary>
            /// 计划量
            /// </summary>
            ColPlanNum ,
            /// <summary>
            /// 单位
            /// </summary>
            ColPlanUnit ,
            /// <summary>
            /// 送检量
            /// </summary>
            ColAssayQty,
            /// <summary>
            /// 检验结果
            /// </summary>
            ColAssayResult ,
            /// <summary>
            /// 批号
            /// </summary>
            ColBatchNO ,
            /// <summary>
            /// 有效期
            /// </summary>
            ColValidDate ,
            /// <summary>
            /// 半成品量
            /// </summary>
            ColConfectQty ,
            /// <summary>
            /// 入库量
            /// </summary>
            ColInQty ,
            /// <summary>
            /// 成本价
            /// </summary>
            ColCostPrice ,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type [ ] InterfaceTypes
        {
            get
            {
                Type [ ] printType = new Type [ 1 ];
                printType [ 0 ] = typeof ( Neusoft.HISFC.Components.Preparation.IProcess );

                return printType;
            }
        }

        #endregion
    }
}
