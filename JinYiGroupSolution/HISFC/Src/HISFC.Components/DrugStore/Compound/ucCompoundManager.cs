using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.DrugStore.Compound
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 配置管理主程序]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// <说明>
    ///     1、暂时不处理药柜管理相关部分
    ///     2、增加控制参数 判断是否需要配置核准
    /// </说明>
    /// </summary>
    public partial class ucCompoundManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCompoundManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 核准人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject approveOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 核准科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject approveDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 组件患者选择树
        /// </summary>
        private tvCompoundList tvCompound = null;

        /// <summary>
        /// 医嘱批次信息
        /// </summary>
        private string groupCode = "U";

        /// <summary>
        /// 是否需配置确认
        /// </summary>
        private bool isNeedConfirm = true;

        /// <summary>
        /// 医嘱类型集合
        /// </summary>
        private System.Collections.Hashtable hsOrderType = new Hashtable();

        #endregion

        #region 属性

        /// <summary>
        /// 核准科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ApproveDept
        {
            get
            {
                return this.approveDept;
            }
            set
            {
                this.approveDept = value;
            }
        }

        /// <summary>
        /// 所选择的医嘱批次
        /// </summary>
        private string GroupCode
        {
            get
            {
                if (this.cmbOrderGroup.Text == "" || this.cmbOrderGroup.Text == null || this.cmbOrderGroup.Text == "全部")
                {
                    this.groupCode = "U";
                }
                else
                {
                    this.groupCode = this.cmbOrderGroup.Text;
                }

                return this.groupCode;
            }
        }

        /// <summary>
        /// 本次检索最大时间
        /// </summary>
        private DateTime MaxDate
        {
            get
            {
                return NConvert.ToDateTime(this.dtMaxDate.Text);
            }
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
            this.toolBarService.AddToolButton("全选", "选择全部申请", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            this.toolBarService.AddToolButton("全不选", "取消全部申请选择", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            this.toolBarService.AddToolButton("刷新", "刷新患者列表显示", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
            
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
            this.SaveApply();

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
                    this.Check(true);
                    break;
                case "全不选":
                    this.Check(false);
                    break;
                case "刷新":
                    this.ShowList();
                    break;
            }

        }

        protected override int OnPrint(object sender, object neuObject)
        {
            ArrayList alCheck = this.GetCheckData();

            Function.PrintCompound(alCheck,true,true);

            return base.OnPrint(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        protected virtual int Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载基础数据.请稍候..."));
            Application.DoEvents();

            this.tvCompound = this.tv as Neusoft.HISFC.Components.DrugStore.Compound.tvCompoundList;

            this.tvCompound.Init();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            this.approveOper = dataManager.Operator;

            this.approveDept = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;

            this.InitOrderGroup();

            this.dtMaxDate.Value = dataManager.GetDateTimeFromSysDateTime().Date.AddDays(1);

            this.tvCompound.SelectDataEvent += new tvCompoundList.SelectDataHandler(tvCompound_SelectDataEvent);

            //取医嘱类型，用于将编码转换成名称
            Neusoft.HISFC.BizLogic.Manager.OrderType orderManager = new Neusoft.HISFC.BizLogic.Manager.OrderType();
            ArrayList alOrderType = orderManager.GetList();
            foreach (Neusoft.FrameWork.Models.NeuObject infoOrderType in alOrderType)
            {
                this.hsOrderType.Add(infoOrderType.ID, infoOrderType.Name);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 初始化医嘱批次信息
        /// </summary>
        /// <returns></returns>
        private int InitOrderGroup()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

            List<Neusoft.HISFC.Models.Pharmacy.OrderGroup> orderGroupList = consManager.QueryOrderGroup();
            if (orderGroupList == null)            
            {
                MessageBox.Show(Language.Msg("获取医嘱批次信息发生错误"));
                return -1;
            }

            string[] strOrderGroup = new string[orderGroupList.Count + 1];
            strOrderGroup[0] = "全部";
            int i = 1;
            foreach (Neusoft.HISFC.Models.Pharmacy.OrderGroup info in orderGroupList)
            {
                strOrderGroup[i] = info.ID;
                i++;
            }

            this.cmbOrderGroup.Items.AddRange(strOrderGroup);

            string orderGroup = consManager.GetOrderGroup(consManager.GetDateTimeFromSysDateTime());
            if (orderGroup != "")
            {
                this.cmbOrderGroup.Text = orderGroup;
            }

            return 1;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns></returns>
        protected int Clear()
        {
            this.fpApply_Sheet1.Rows.Count = 0;

            return 1;
        }

        /// <summary>
        /// 列表显示
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected virtual int ShowList()
        {
            this.Clear();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载配置数据,请稍候..."));
            Application.DoEvents();

            //根据库存药房/批次获取列表
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alList = itemManager.QueryCompoundList(this.ApproveDept.ID, this.GroupCode,"0");
            if (alList == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("获取配置单列表发生错误") + itemManager.Err);
                return -1;
            }

            this.tvCompound.ShowList(alList);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;            
        }

        /// <summary>
        /// 向Fp内加入数据
        /// </summary>
        /// <param name="alApply">摆药申请信息</param>
        /// <returns></returns>
        protected int AddDataToFp(ArrayList alApply)
        {
            this.fpApply_Sheet1.Rows.Count = 0;

            int i = 0;

            Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alApply)
            {
                if (info.UseTime > this.MaxDate)
                {
                    continue;
                }

                this.fpApply_Sheet1.Rows.Add(i, 1);

                if (info.UseTime != System.DateTime.MinValue)
                {
                    this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColUseTime].Text = info.UseTime.ToString();
                }

                if (info.User01.Length > 4)
                {
                    this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColBedName].Text = "[" + info.User01.Substring(4) + "]" + info.User02;
                }
                else
                {
                    this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColBedName].Text = "[" + info.User01 + "]" + info.User02;
                }

                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value = true;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColTradeNameSpecs].Text = info.Item.Name + "[" + info.Item.Specs + "]";
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColRetailPrice].Text = info.Item.PriceCollection.RetailPrice.ToString();
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColDoseOnce].Text = info.DoseOnce.ToString();
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColDoseUnit].Text = info.Item.DoseUnit;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColQty].Text = (info.Operation.ApplyQty * info.Days).ToString();
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColUnit].Text = info.Item.MinUnit;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColFrequency].Text = info.Frequency.ID;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColUsage].Text = info.Usage.Name;

                if (info.OrderType == null || info.OrderType.ID == "")
                {
                    this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColOrderType].Text = "直接收费";
                }
                else
                {
                    if (this.hsOrderType.ContainsKey(info.OrderType.ID))
                    {
                        this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColOrderType].Text = this.hsOrderType[info.OrderType.ID].ToString();
                    }
                    else
                    {
                        this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColOrderType].Text = info.OrderType.ID;
                    }
                }

                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColDoctor].Text = info.RecipeInfo.ID;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColApplyTime].Text = info.Operation.ApplyOper.OperTime.ToString() ;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColCompoundGroup].Text = info.CompoundGroup;
                this.fpApply_Sheet1.Rows[i].Tag = info;
            }

            return 1;
        }

        /// <summary>
        /// 获取所有当前选中的数据
        /// </summary>
        /// <returns></returns>
        protected ArrayList GetCheckData()
        {
            ArrayList al = new ArrayList();

            for (int i = 0; i < this.fpApply_Sheet1.Rows.Count; i++)
            {
                if (NConvert.ToBoolean(this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value))
                {
                    al.Add(this.fpApply_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut);
                }
            }

            return al;
        }

        /// <summary>
        /// 选中/不选中
        /// </summary>
        /// <param name="isCheck"></param>
        /// <returns></returns>
        public int Check(bool isCheck)
        {
            for (int i = 0; i < this.fpApply_Sheet1.Rows.Count; i++)
            {
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value = isCheck;
            }

            return 1;
        }

        /// <summary>
        /// 保存申请
        /// </summary>
        /// <returns></returns>
        public virtual int SaveApply()
        {
            ArrayList alCheck = this.GetCheckData();
            if (alCheck.Count == 0)
            {
                return 0;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            DateTime sysTime = itemManager.GetDateTimeFromSysDateTime();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //itemManager.SetTrans(t.Trans);

            //暂时不处理药柜问题

            if (Function.DrugConfirm(alCheck, null, null, this.approveDept.Clone(), Neusoft.FrameWork.Management.PublicTrans.Trans) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            if (Function.DrugApprove(alCheck, this.approveOper.ID, this.approveDept.ID, Neusoft.FrameWork.Management.PublicTrans.Trans) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            //如不需配置确认则在此直接进行确认
            if (!this.isNeedConfirm)
            {
                Neusoft.HISFC.Models.Base.OperEnvironment compoundOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
                compoundOper.OperTime = sysTime;
                compoundOper.ID = this.approveOper.ID;

                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alCheck)
                {
                    if (itemManager.UpdateCompoundApplyOut(info, compoundOper, true) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("更新配置确认信息发生错误") + itemManager.Err);
                        return -1;
                    }
                }
            }

            if (Function.CompoundFee(alCheck, this.approveDept, Neusoft.FrameWork.Management.PublicTrans.Trans) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功"));

            Function.PrintCompound(alCheck,true,true);

            this.ShowList();

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                if (this.Init() == -1)
                {
                    MessageBox.Show(Language.Msg("初始化执行发生错误"));
                    return;
                }
            }           
        }

        private void tvCompound_SelectDataEvent(ArrayList alData)
        {
            if (this.tvCompound.SelectedNode.Parent == null)
            {
                this.lbInfo.Text = string.Format("当前科室:{0} 患者总计:{1} ", this.tvCompound.SelectedNode.Text, this.tvCompound.SelectedNode.Nodes.Count);
            }
            else
            {
                this.lbInfo.Text = string.Format("当前患者:{0}", this.tvCompound.SelectedNode.Text);
            }
            this.AddDataToFp(alData);
        }

        private void cmbOrderGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tvCompound.GroupCode = this.GroupCode;

            this.ShowList();
        }

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 床号 姓名
            /// </summary>
            ColBedName,
            /// <summary>
            /// 选中
            /// </summary>
            ColSelect,
            /// <summary>
            /// 药品名称 规格
            /// </summary>
            ColTradeNameSpecs,
            /// <summary>
            /// 零售价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 用量
            /// </summary>
            ColDoseOnce,
            /// <summary>
            /// 剂量单位
            /// </summary>
            ColDoseUnit,
            /// <summary>
            /// 总量
            /// </summary>
            ColQty,
            /// <summary>
            /// 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 频次
            /// </summary>
            ColFrequency,
            /// <summary>
            /// 用法
            /// </summary>
            ColUsage,
            /// <summary>
            /// 用药时间
            /// </summary>
            ColUseTime,
            /// <summary>
            /// 医嘱类型
            /// </summary>
            ColOrderType,
            /// <summary>
            /// 开方医生
            /// </summary>
            ColDoctor,
            /// <summary>
            /// 申请时间
            /// </summary>
            ColApplyTime,
            /// <summary>
            /// 批次号
            /// </summary>
            ColCompoundGroup
        }
    }
}
