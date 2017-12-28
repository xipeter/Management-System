using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using PManager = Neusoft.HISFC.BizLogic.Pharmacy.Preparation;
using PObject = Neusoft.HISFC.Models.Preparation;

namespace Neusoft.HISFC.Components.Preparation
{       
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂原料消耗]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>
    ///    1、制剂材料扣库实现
    ///    2、对不足库存原材料自动形成申请计划
    /// </说明>
    /// </summary>
    public partial class ucExpand : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucExpand()
        {
            InitializeComponent();

            this.Init();
        }

        /// <summary>
        /// 消耗信息处理完成事件
        /// </summary>
        public event System.EventHandler ExpandDataFinishEvent;

        #region 域变量

        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();

        /// <summary>
        /// 药品组合业务类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 制剂原料管理接口
        /// </summary>
        private HISFC.Components.Preparation.IPreparation MaterialInterface = null;

        /// <summary>
        /// 库存操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject stockDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 原料库存科室 用于自动形成原料入库申请
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject materialStockDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 生产计划单号
        /// </summary>
        private string planNO = "";

        #endregion

        #region 属性

        /// <summary>
        /// 是否可以单独编辑
        /// </summary>
        public bool IsCanEdit
        {
            set
            {
                this.btnSave.Enabled = value;

                this.fsMaterial_Sheet1.Columns[(int)ExpandColumnSet.ColFactualExpand].Locked = !value;
                this.fsMaterial_Sheet1.Columns[(int)ExpandColumnSet.ColMemo].Locked = !value;
            }
        }

        /// <summary>
        /// 库存操作科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject StockDept
        {
            get
            {
                return this.stockDept;
            }
            set
            {
                this.stockDept = value;

                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                System.Collections.ArrayList alMaterialStockDept = managerIntegrate.GetPrivInOutDeptList(this.stockDept.ID, "0310");
                if (alMaterialStockDept == null)
                {
                    MessageBox.Show(managerIntegrate.Err);
                    return;
                }
                if (alMaterialStockDept.Count > 0)
                {
                    //{385C8E03-2028-4bb4-81C6-D1197FEA2E74} 获取对应上级科室 用于原材料申请
                    this.materialStockDept = (alMaterialStockDept[0] as Neusoft.HISFC.Models.Base.PrivInOutDept).Dept;
                }
            }
        }

        /// <summary>
        /// 生产计划单号
        /// </summary>
        public string PlanNO
        {
            set
            {
                this.planNO = value;
            }
            get
            {
                return this.planNO;
            }
        }

        /// <summary>
        /// 是否仅用于消耗信息显示
        /// </summary>
        public bool IsOnlyShowExpand
        {
            get
            {
                return !this.gbControl.Visible;
            }
            set
            {
                this.gbControl.Visible = !value;

                this.fsMaterial_Sheet1.Columns[(int)ExpandColumnSet.ColPlanExpand].Visible = !value;
                this.fsMaterial_Sheet1.Columns[(int)ExpandColumnSet.ColStore].Visible = !value;
                this.fsMaterial_Sheet1.Columns[(int)ExpandColumnSet.ColNormativeQty].Visible = !value;

                this.IsCanEdit = !value;
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected int Init()
        {
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            this.fsMaterial_Sheet1.Columns[(int)ExpandColumnSet.ColFactualExpand].CellType = markNumCellType;

            return 1;
        }

        /// <summary>
        /// 添加制剂成品消耗信息
        /// </summary>
        /// <param name="info">制剂消耗信息</param>
        protected void AddExpandToFp(Neusoft.HISFC.Models.Preparation.Expand info)
        {
            int rowCoount = this.fsMaterial_Sheet1.Rows.Count;

            this.fsMaterial_Sheet1.Rows.Add(rowCoount, 1);
            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColMaterialName].Text = info.Prescription.Material.Name;
            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColSpecs].Text = info.Prescription.Specs;
            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColPrice].Text = info.Prescription.Price.ToString();
            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColNormativeQty].Text = info.Prescription.NormativeQty.ToString() + "[" + info.Prescription.NormativeUnit + "]";
            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColPlanExpand].Text = info.PlanExpand.ToString() + "[" + info.Prescription.NormativeUnit + "]";

            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColStore].Text = info.StoreQty.ToString() + "[" + info.Prescription.NormativeUnit + "]";
            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColFactualExpand].Text = info.FacutalExpand.ToString() + "[" + info.Prescription.NormativeUnit + "]";
            this.fsMaterial_Sheet1.Cells[rowCoount, (int)ExpandColumnSet.ColMemo].Text = info.Memo;

            this.fsMaterial_Sheet1.Rows[rowCoount].Tag = info;
        }

        /// <summary>
        /// 制剂成品消耗信息显示
        /// </summary>
        /// <param name="expandList">制剂成品消耗信息集合</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int ShowExpand(List<Neusoft.HISFC.Models.Preparation.Expand> expandList)
        {
            this.Clear();

            foreach (Neusoft.HISFC.Models.Preparation.Expand info in expandList)
            {
                if (info.Prescription.MaterialType == Neusoft.HISFC.Models.Preparation.EnumMaterialType.Material)
                {
                    info.Prescription.Material = this.pharmacyIntegrate.GetItem(info.Prescription.Material.ID);
                    if (info.Prescription.Material == null)
                    {
                        MessageBox.Show("根据项目编码" + info.Prescription.Material.ID + "获取项目信息实体失败");
                        return -1;
                    }
                    decimal storeQty = 0;
                    if (this.pharmacyIntegrate.GetStorageNum(this.stockDept.ID, info.Prescription.Material.ID, out storeQty) == -1)
                    {
                        MessageBox.Show("加载原料库存发生错误" + this.pharmacyIntegrate.Err);
                        return -1;
                    }
                    info.StoreQty = storeQty;
                }
                else
                {
                    if (this.MaterialInterface != null)
                    {
                        info.StoreQty = this.MaterialInterface.GetStore(this.stockDept.ID, info.Prescription.Material.ID);
                    }
                }

                if (info.FacutalExpand == -1)       //初始值 第一次产生
                {
                    info.FacutalExpand = info.PlanExpand;
                }

                this.AddExpandToFp(info);
            }
            return 1;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        internal void Clear()
        {
            this.fsMaterial_Sheet1.Rows.Count = 0;

            this.tabPage1.Text = "生产原料、辅料信息 － 修改消耗信息后请注意保存";
        }

        /// <summary>
        /// 制剂成品消耗信息获取
        /// </summary>
        /// <param name="preparation">制剂成品消耗信息</param>
        /// <returns>成功返回制剂成品消耗信息 失败返回null</returns>
        internal List<Neusoft.HISFC.Models.Preparation.Expand> QueryExpandList(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = this.preparationManager.QueryExpand(preparation,this.stockDept);
            if (expandList == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取制剂消耗信息发生错误") + this.preparationManager.Err);
                return null;
            }
            else if (expandList.Count == 0)
            {
                expandList = this.ComputePrescription(preparation);
            }
            else
            {
                foreach (Neusoft.HISFC.Models.Preparation.Expand expand in expandList)
                {
                    if (expand.PlanQty == preparation.PlanQty)
                    {
                        continue;
                    }
                    else
                    {
                        expand.PlanQty = preparation.PlanQty;
                        expand.PlanExpand = preparation.PlanQty * expand.Prescription.NormativeQty;
                        expand.FacutalExpand = -1;
                    }
                }
            }

            return expandList;
        }

        /// <summary>
        /// 制剂成品消耗信息显示
        /// </summary>
        /// <param name="preparation">制剂成品消耗信息集合</param>
        /// <returns>成功返回1 失败返回－1</returns>
        internal int ShowExpand(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            this.tabPage1.Text = preparation.Drug.Name + "[ " + preparation.Drug.Specs + " ] －－  生产原料、辅料信息 － 修改消耗信息后请注意保存";

            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = this.QueryExpandList(preparation);

            if (expandList != null)
            {
                this.ShowExpand(expandList);
            }

            return 1;
        }

        /// <summary>
        /// 制剂原料消耗信息计算
        /// </summary>
        /// <param name="info">制剂成品计划信息</param>
        internal List<Neusoft.HISFC.Models.Preparation.Expand> ComputePrescription(Neusoft.HISFC.Models.Preparation.Preparation info)
        {
            List<Neusoft.HISFC.Models.Preparation.Prescription> prescriptionList = this.preparationManager.QueryDrugPrescription(info.Drug.ID);
            if (prescriptionList == null)
            {
                MessageBox.Show(Language.Msg("获取制剂配制处方信息发生错误") + this.preparationManager.Err);
                return null;
            }

            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = new List<Neusoft.HISFC.Models.Preparation.Expand>();

            foreach (Neusoft.HISFC.Models.Preparation.Prescription prescription in prescriptionList)
            {
                Neusoft.HISFC.Models.Preparation.Expand expand = new Neusoft.HISFC.Models.Preparation.Expand();

                expand.Prescription = prescription;
                expand.PlanNO = info.PlanNO;
                expand.PlanQty = info.PlanQty;
                expand.PlanExpand = info.PlanQty * prescription.NormativeQty;

                expand.FacutalExpand = -1;

                //{8840008D-2FEA-4471-B404-B05E25832120}  获取库存
                decimal storeQty = 0;
                if (this.pharmacyIntegrate.GetStorageNum(this.stockDept.ID, expand.Prescription.Material.ID, out storeQty) == -1)
                {
                    MessageBox.Show("加载原料库存发生错误" + this.pharmacyIntegrate.Err);
                    return null;
                }
                expand.StoreQty = storeQty;
                //{8840008D-2FEA-4471-B404-B05E25832120}  获取库存

                expandList.Add(expand);
            }

            return expandList;
        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <param name="isNotice">是否进行信息提示</param>
        /// <returns>库存条件满足或自动形成申请信息 True 库存不足或不自动形成申请 False</returns>
        internal bool ValidStock(bool isNotice)
        {
            for (int i = 0; i < this.fsMaterial_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Preparation.Expand expand = (this.fsMaterial_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Preparation.Expand).Clone();

                expand.FacutalExpand = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsMaterial_Sheet1.Cells[i, (int)ExpandColumnSet.ColFactualExpand].Text);

                if (expand.StoreQty < expand.FacutalExpand)
                {
                    if (isNotice)
                    {
                        DialogResult rs = MessageBox.Show(Language.Msg("库存不足 无法完原材料库存扣除,对库存不足的原材料是否自动形成申请？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rs == DialogResult.No)      //不允许自动形成申请 数据无效
                        {
                            return false;
                        }
                        else                           //允许自动形成申请 isAutoApply设置为True
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <param name="preparation">制剂主信息</param>
        /// <param name="isNotice">是否进行信息提示</param>
        /// <returns>库存条件满足或自动形成申请信息 True 库存不足或不自动形成申请 False</returns>
        internal bool ValidStock(Neusoft.HISFC.Models.Preparation.Preparation preparation, bool isNotice)
        {
            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = this.QueryExpandList(preparation);
            if (expandList == null)
            {
                return false;
            }
            foreach (Neusoft.HISFC.Models.Preparation.Expand expand in expandList)
            {
                if (expand.StoreQty < expand.FacutalExpand)
                {
                    if (isNotice)
                    {
                        DialogResult rs = MessageBox.Show(preparation.Drug.Name + Language.Msg("  原料库存不足,是否自动形成入库申请？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rs == DialogResult.No)      //不允许自动形成申请 数据无效
                        {
                            return false;
                        }
                        else                           //允许自动形成申请 isAutoApply设置为True
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 消耗信息保存
        /// </summary>
        /// <param name="info">制剂主信息</param>
        /// <param name="isExecApplyData">是否用于生成原材料申请信息</param>
        /// <param name="Err">错误提示</param>
        /// <returns></returns>
        internal int SaveExpandForStock(Neusoft.HISFC.Models.Preparation.Preparation preparation, bool isExecApplyData, ref string Err)
        {
            Err = "";
            bool isLocalTrans = false;
            if (Neusoft.FrameWork.Management.PublicTrans.Trans == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                isLocalTrans = true;
            }

            this.pharmacyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.preparationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);          

            DateTime sysTime = this.preparationManager.GetDateTimeFromSysDateTime();

            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = this.preparationManager.QueryExpand(preparation,this.stockDept);
            if (expandList == null)
            {
                if (isLocalTrans)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                }
                Err = Neusoft.FrameWork.Management.Language.Msg("获取制剂消耗信息发生错误") + this.preparationManager.Err;
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Preparation.Expand info in expandList)
            {
                info.Prescription.OperEnv.OperTime = sysTime;
                info.Prescription.OperEnv.ID = this.preparationManager.Operator.ID;
                info.PlanNO = preparation.PlanNO;

                if (isExecApplyData)
                {
                    #region 申请信息生成

                    if (info.StoreQty < info.FacutalExpand)
                    {
                        if (info.Prescription.MaterialType == Neusoft.HISFC.Models.Preparation.EnumMaterialType.Material)     //药品
                        {
                            //{64FAE14C-7D1B-42ea-B19D-2C1B3846D2D0} 申请信息自动生成时 重新获取项目信息
                            Neusoft.HISFC.Models.Pharmacy.Item tempItem = this.pharmacyIntegrate.GetItem(info.Prescription.Material.ID);
                            if (tempItem == null)
                            {
                                if (isLocalTrans)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                }
                                Err = Language.Msg("根据药品原料编码获取原材料信息失败！ ") + this.pharmacyIntegrate.Err;
                                return -1;
                            }
                            if (this.pharmacyIntegrate.ProduceApply(tempItem, info, this.stockDept, this.materialStockDept) == -1)
                            {
                                if (isLocalTrans)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                }
                                Err = Language.Msg("根据库存及原料消耗生成申请信息发生错误" + this.pharmacyIntegrate.Err);
                                return -1;
                            }
                        }
                        else
                        {
                            if (this.MaterialInterface != null)
                            {
                                if (this.MaterialInterface.Apply(info.Prescription.Material, info, stockDept,Neusoft.FrameWork.Management.PublicTrans.Trans) == -1)
                                {
                                    if (isLocalTrans)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    }
                                    Err = Language.Msg("通过接口进行原料申请时发生错误") + this.preparationManager.Err;
                                    return -1;
                                }
                            }
                        }
                    }

                    #endregion

                    info.ExecOutput = false;
                }
                else
                {
                    #region 库存扣除

                    //生产原料扣库
                    if (info.Prescription.MaterialType == Neusoft.HISFC.Models.Preparation.EnumMaterialType.Material)     //药品
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item tempItem = this.pharmacyIntegrate.GetItem(info.Prescription.Material.ID);
                        if (tempItem == null)
                        {
                            if (isLocalTrans)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            }
                            Err = Language.Msg("根据药品原料编码获取原材料信息失败！ ") + this.pharmacyIntegrate.Err;
                            return -1;
                        }
                        if (this.pharmacyIntegrate.ProduceOutput(tempItem, info, stockDept) == -1)
                        {
                            if (isLocalTrans)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            }
                            Err = this.pharmacyIntegrate.Err;
                            return -1;
                        }
                    }
                    else
                    {
                        if (this.MaterialInterface != null)
                        {
                            if (this.MaterialInterface.Output(info.Prescription.Material, info, stockDept, Neusoft.FrameWork.Management.PublicTrans.Trans) == -1)
                            {
                                if (isLocalTrans)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                }
                                Err = Language.Msg("通过接口进行原料库存扣除失败！ ");
                                return -1;
                            }
                        }
                    }
                    #endregion

                    info.ExecOutput = true;
                }

                if (this.preparationManager.SetExpand(info) == -1)
                {
                    if (isLocalTrans)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    Err = Language.Msg("保存消耗信息时发生错误") + this.preparationManager.Err;
                    return -1;
                }
            }

            if (isLocalTrans)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }

            return 1;
        }
        
        /// <summary>
        /// 消耗设置信息保存
        /// </summary>
        /// <param name="isLocalTrans">是否本地(函数内部)开启事务</param>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        internal int SaveExpandInfo(bool isLocalTrans,ref string msg)
        {
            msg = "";
            if (this.fsMaterial_Sheet1.Rows.Count <= 0)
            {
                return 0;
            }

            if (isLocalTrans)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            }
            this.preparationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            
            DateTime sysTime = this.preparationManager.GetDateTimeFromSysDateTime();

            for (int i = 0; i < this.fsMaterial_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Preparation.Expand expand = (this.fsMaterial_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Preparation.Expand).Clone();

                if (expand.PlanNO == null || expand.PlanNO == "")
                {
                    if (isLocalTrans)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    msg = Language.Msg("请先保存计划信息再进行消耗信息设置");
                    return -1;
                }

                expand.FacutalExpand = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsMaterial_Sheet1.Cells[i, (int)ExpandColumnSet.ColFactualExpand].Text);
                expand.Prescription.OperEnv.OperTime = sysTime;
                expand.Prescription.OperEnv.ID = this.preparationManager.Operator.ID;

                if (this.preparationManager.SetExpand(expand) == -1)
                {
                    if (isLocalTrans)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    msg = Language.Msg("保存消耗信息时发生错误") + this.preparationManager.Err;
                    return -1;
                }
            }

            if (isLocalTrans)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                msg = Language.Msg("消耗信息设置成功");
            }

            if (this.ExpandDataFinishEvent != null)
            {
                this.ExpandDataFinishEvent(this, System.EventArgs.Empty);
            }

            return 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            this.SaveExpandInfo(true,ref msg);

            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region 静态公开函数

        /// <summary>
        /// 制剂消耗信息获取
        /// </summary>
        /// <param name="preparationManager">制剂管理业务层</param>
        /// <param name="preparation">制剂成品信息</param>
        /// <returns>成功返回制剂消耗信息 失败返回null</returns>
        internal static List<PObject.Expand> QueryExpandList(PManager preparationManager, PObject.Preparation preparation)
        {
            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = preparationManager.QueryExpand(preparation,null);
            if (expandList == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取制剂消耗信息发生错误") + preparationManager.Err);
                return null;
            }

            return expandList;
        }

        #endregion

        private enum ExpandColumnSet
        {
            /// <summary>
            /// 原料名称
            /// </summary>
            ColMaterialName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 单价
            /// </summary>
            ColPrice,
            /// <summary>
            /// 标准处方量
            /// </summary>
            ColNormativeQty,
            /// <summary>
            /// 理论消耗量
            /// </summary>
            ColPlanExpand,
            /// <summary>
            /// 库存量
            /// </summary>
            ColStore,
            /// <summary>
            /// 实际消耗量
            /// </summary>
            ColFactualExpand,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo
        }
    }
}
