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
    /// [功能描述: 配置标签补打]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// <说明>
    ///     1、
    /// </说明>
    /// </summary>
    public partial class ucCompoundRePrint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCompoundRePrint()
        {
            InitializeComponent();
        }

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
            this.toolBarService.AddToolButton("补打标签", "补打配置标签", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y预览, true, false, null);
            this.toolBarService.AddToolButton("补打执行", "补打执行明细单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印, true, false, null);

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
                case "补打标签":
                    this.Print(true, false);
                    break;
                case "补打执行":
                    this.Print(false, true);
                    break;
            }
        }

        protected override int OnPrint(object sender, object neuObject)
        {           
            return base.OnPrint(sender, neuObject);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryCompound(this.txtCompoundGroup.Text);

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        private void Print(bool isPrintLabel, bool isPrintDetail)
        {
            ArrayList alCheck = this.GetCheckData();

            Function.PrintCompound(alCheck,isPrintDetail,isPrintLabel);

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
            List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alList = itemManager.QueryCompoundList(this.ApproveDept.ID, this.groupCode, "2");
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
        /// 数据清屏
        /// </summary>
        protected void Clear()
        {
            this.fpApply_Sheet1.Rows.Count = 0;
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
        /// 根据批次流水号检索
        /// </summary>
        /// <param name="compoundGroup">批次流水号</param>
        protected void QueryCompound(string compoundGroup)
        {
            if (compoundGroup == null || compoundGroup == "")
            {
                return;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            ArrayList alList = itemManager.QueryCompoundApplyOut(compoundGroup);
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("根据批次流水号获取配置数据发生错误") + itemManager.Err);
                return;
            }

            this.AddDataToFp(alList);            
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

                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColDoctor].Text = info.RecipeInfo.ID;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColApplyTime].Text = info.Operation.ApplyOper.OperTime.ToString();
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

            base.OnLoad(e);
        }

        private void txtCompoundGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Clear();

                this.QueryCompound(this.txtCompoundGroup.Text);
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        protected virtual int Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载基础数据.请稍候..."));
            Application.DoEvents();

            if (this.tv != null)
            {
                this.tvCompound = this.tv as Neusoft.HISFC.Components.DrugStore.Compound.tvCompoundList;

                this.tvCompound.Init();

                this.tvCompound.State = "2";
            }

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            this.approveDept = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;

            this.InitOrderGroup();

            this.tvCompound.SelectDataEvent += new tvCompoundList.SelectDataHandler(tvCompound_SelectDataEvent);

            //this.ShowList();
          
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        private void tvCompound_SelectDataEvent(ArrayList alData)
        {
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
