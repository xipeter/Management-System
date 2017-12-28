using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂配置处方维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public partial class ucPrescription : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucPrescription()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();
     
        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();      

        /// <summary>
        /// 处方成品列表信息
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> prescriptionList;

        /// <summary>
        /// 当前已维护好的配制处方
        /// </summary>
        private System.Collections.Hashtable hsPrescription = new Hashtable();

        /// <summary>
        /// 当前显示的配制处方的成品编码
        /// </summary>
        private string nowDrugPrescription = "";

        /// <summary>
        /// 药品列表数组
        /// </summary>
        private ArrayList alDrugList = null;
        #endregion

        #region 帮助类

        /// <summary>
        /// 药品帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper drugHelper = null;

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载基础数据 请稍候...");
            Application.DoEvents();

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            List<Neusoft.HISFC.Models.Pharmacy.Item> phaList = pharmacyIntegrate.QueryItemList(true);
            if (phaList == null)
            {
                MessageBox.Show(Language.Msg("加载药品列表发生错误！") + pharmacyIntegrate.Err);
                return;
            }
            foreach (Neusoft.HISFC.Models.Pharmacy.Item info in phaList)
            {
                info.Memo = info.Specs;
            }

            this.alDrugList = new ArrayList(phaList.ToArray());
            this.drugHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alDrugList);

            FarPoint.Win.Spread.InputMap im;
            im = this.fsMaterial.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCell = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            this.fsMaterial_Sheet1.Columns[(int)MaterialColumnSet.ColQty].CellType = markNumCell;
            
            this.fsMaterial.PhaListColumnIndex = 1;
            this.fsMaterial.PhaListEnabled = true;
            this.fsMaterial.Init();

            this.GetInterface();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加成品", "增加新制剂成品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("增加明细", "增加制剂成品原料明细", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除制剂成品或成品原料明细", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加成品")
            {
                this.AddNewDrug();
            }
            if (e.ClickedItem.Text == "增加明细")
            {
                this.AddMaterial();
            }
            if (e.ClickedItem.Text == "删除")
            {
                this.DelPrescription();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SavePrescription();

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ShowPrescription();

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 选择成品
        /// </summary>
        protected Neusoft.HISFC.Models.Pharmacy.Item SelectDrug()
        {
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alDrugList, new string[] { "药品编码", "药品名称", "规格" }, new bool[] { false, true, true }, new int[] { 80, 120, 80 }, ref info) == 0)
            {
                return null;
            }
            else
            {
                return info as Neusoft.HISFC.Models.Pharmacy.Item;
            }
        }

        /// <summary>
        /// 添加成品信息到Fp内
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected int AddDrugToFp(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            try
            {
                int rowCount = this.fsDrug_Sheet1.Rows.Count;
                this.fsDrug_Sheet1.Rows.Add(rowCount, 1);

                this.fsDrug_Sheet1.Cells[rowCount, (int)DrugColumnSet.ColDrugID].Text = item.ID;
                this.fsDrug_Sheet1.Cells[rowCount, (int)DrugColumnSet.ColTradeName].Text = item.Name;
                this.fsDrug_Sheet1.Cells[rowCount, (int)DrugColumnSet.ColSpecs].Text = item.Specs;
                this.fsDrug_Sheet1.Cells[rowCount, (int)DrugColumnSet.ColPackQty].Text = item.PackQty.ToString();
                this.fsDrug_Sheet1.Cells[rowCount, (int)DrugColumnSet.ColPackUnit].Text = item.PackUnit;
                this.fsDrug_Sheet1.Cells[rowCount, (int)DrugColumnSet.ColMinUnit].Text = item.MinUnit;

                this.fsDrug_Sheet1.Rows[rowCount].Tag = item;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 添加制剂新成品
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        public int AddNewDrug()
        {
            Neusoft.HISFC.Models.Pharmacy.Item item = this.SelectDrug();
            if (item == null)
            {
                return -1;
            }

            if (this.hsPrescription.ContainsKey(item.ID))
            {
                MessageBox.Show(Language.Msg("该药品已维护了配制处方"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            this.hsPrescription.Add(item.ID,null);

            this.AddDrugToFp(item);

            this.fsDrug_Sheet1.ActiveRowIndex = this.fsDrug_Sheet1.Rows.Count - 1;
            this.fsDrug_Sheet1.AddSelection(this.fsDrug_Sheet1.Rows.Count - 1, 0, 1, -1);
            this.fsDrug_SelectionChanged(null, null);

            return 1;
        }

        /// <summary>
        /// 添加原料、处方明细
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        public int AddMaterial()
        {
            if (this.neuTabControl1.SelectedTab == this.tabPage1)
            {
                int rowCount = this.fsMaterial_Sheet1.Rows.Count;

                this.fsMaterial_Sheet1.Rows.Add(rowCount, 1);
            }
            else
            {
                if (this.wrapperInterface != null)
                {
                    this.wrapperInterface.AddNewItem();
                }
            }

            return 1;
        }

        /// <summary>
        /// 添加处方明细信息
        /// </summary>
        /// <param name="item"></param>
        public int AddItemDetail(Item item)
        {
            for (int rowIndex = 0; rowIndex < this.fsMaterial_Sheet1.Rows.Count; rowIndex++)
            {
                if (this.fsMaterial_Sheet1.Cells[rowIndex, (int)MaterialColumnSet.ColMaterialID].Text == item.ID)
                {
                    MessageBox.Show(item.Name + " 原材料已存在 不能重复添加", "处方明细重复", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }

            int i = this.fsMaterial_Sheet1.ActiveRowIndex;

            this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialID].Text = item.ID;
            this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialName].Text = item.Name;
            this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialSpecs].Text = item.Specs;
            this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColPrice].Text = item.PriceCollection.RetailPrice.ToString();
            this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColUnit].Text = item.MinUnit;
            this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColPackQty].Text = item.PackQty.ToString();

            this.fsMaterial_Sheet1.Rows[i].Tag = item;

            return 1;
        }

        /// <summary>
        /// 增加一条明细
        /// </summary>
        protected void Add()
        {
            this.fsMaterial_Sheet1.Rows.Add(this.fsMaterial_Sheet1.Rows.Count, 1);
            this.fsMaterial_Sheet1.ActiveColumnIndex = 0;
        }

        /// <summary>
        /// 获取成品配制处方信息
        /// </summary>
        /// <returns></returns>
        public int ShowPrescriptionList()
        {
            this.fsMaterial_Sheet1.Rows.Count = 0;
            this.fsDrug_Sheet1.Rows.Count = 0;

            this.prescriptionList = this.preparationManager.QueryPrescriptionList(Neusoft.HISFC.Models.Base.EnumItemType.Drug);
            if (this.prescriptionList == null)
            {
                MessageBox.Show(Language.Msg("未正确获取成品配制处方信息 \n" + this.preparationManager.Err));
                return -1;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in this.prescriptionList)
            {
                if (this.AddDrugToFp(this.drugHelper.GetObjectFromID(info.ID) as Neusoft.HISFC.Models.Pharmacy.Item) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }
    
        /// <summary>
        /// 配制处方信息 并显示
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowPrescription()
        {
            if (this.fsDrug_Sheet1.Rows.Count <= 0)
                return -1;

            string drugCode = this.fsDrug_Sheet1.Cells[this.fsDrug_Sheet1.ActiveRowIndex, (int)DrugColumnSet.ColDrugID].Text;
            this.fsMaterial_Sheet1.Rows.Count = 0;

            this.lbInformation.Text = string.Format("{0}  成品处方内容（标准处方量以成品量1最小单位为基准量）", this.fsDrug_Sheet1.Cells[this.fsDrug_Sheet1.ActiveRowIndex, (int)DrugColumnSet.ColTradeName].Text);

            List<Neusoft.HISFC.Models.Preparation.Prescription> al = this.preparationManager.QueryDrugPrescription(drugCode,Neusoft.HISFC.Models.Preparation.EnumMaterialType.Material);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取当前选择成品的配制处方信息出错\n" + drugCode));
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Preparation.Prescription info in al)
            {
                int i = this.fsMaterial_Sheet1.Rows.Count;

                this.fsMaterial_Sheet1.Rows.Add(i, 1);
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialID].Text = info.Material.ID;
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialName].Text = info.Material.Name;
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialSpecs].Text = info.Specs;
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColPrice].Text = info.Price.ToString();
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColQty].Text = info.NormativeQty.ToString();
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMemo].Text = info.Memo;
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColUnit].Text = info.NormativeUnit;
                this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColPackQty].Text = info.MaterialPackQty.ToString();

                this.fsMaterial_Sheet1.Rows[i].Tag = info.Material;
            }

            if (this.wrapperInterface != null)
            {
                if (this.nowDrugPrescription == "" || this.nowDrugPrescription == null)
                {
                    this.wrapperInterface.Drug = this.drugHelper.GetObjectFromID(drugCode) as Neusoft.HISFC.Models.Pharmacy.Item;

                }
                this.wrapperInterface.Query();
            }

            return 1;
        }

        /// <summary>
        /// 保存配制处方信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SavePrescription()
        {
            if (this.fsDrug_Sheet1.Rows.Count <= 0)
            {
                return 1;
            }
            if (this.fsMaterial_Sheet1.Rows.Count <= 0)
            {
                MessageBox.Show(Language.Msg("请维护制剂配制处方信息"));
                return 1;
            }

            for (int i = 0; i < this.fsMaterial_Sheet1.Rows.Count; i++)
            {
                if (this.fsMaterial_Sheet1.Cells[i, 0].Text == "")
                {
                    continue;
                }
                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColQty].Text) == 0)
                {
                    MessageBox.Show(Language.Msg("标准处方量需大于零"));
                    return 1;
                }
            }

            string drugCode = this.fsDrug_Sheet1.Cells[this.fsDrug_Sheet1.ActiveRowIndex, (int)DrugColumnSet.ColDrugID].Text;
            DateTime sysTime = this.preparationManager.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.preparationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {                
                if (this.preparationManager.DelPrescription(drugCode,Neusoft.HISFC.Models.Base.EnumItemType.Drug) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("删除配制处方信息出错" + this.preparationManager.Err));
                    return -1;
                }

                Neusoft.HISFC.Models.Pharmacy.Item drug = this.drugHelper.GetObjectFromID(drugCode) as Neusoft.HISFC.Models.Pharmacy.Item;

                Neusoft.HISFC.Models.Preparation.Prescription info = null;

                #region 保存生产原料

                for (int i = 0; i < this.fsMaterial_Sheet1.Rows.Count; i++)
                {
                    if (this.fsMaterial_Sheet1.Cells[i, 0].Text == "")
                    {
                        continue;
                    }

                    info = new Neusoft.HISFC.Models.Preparation.Prescription();

                    info.Material = this.fsMaterial_Sheet1.Rows[i].Tag as Neusoft.FrameWork.Models.NeuObject;
                    if (info.Material == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("类型转换错误");
                        return -1;
                    }

                    info.Drug = drug;

                    info.Specs = this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialSpecs].Text;
                    info.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColPrice].Text);
                    info.NormativeUnit = this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColUnit].Text;

                    info.MaterialType = Neusoft.HISFC.Models.Preparation.EnumMaterialType.Material;
                    info.NormativeQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColQty].Text);
                    info.Memo = this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColMemo].Text;
                    info.OperEnv.ID = this.preparationManager.Operator.ID;
                    info.OperEnv.OperTime = sysTime;
                    info.MaterialPackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsMaterial_Sheet1.Cells[i, (int)MaterialColumnSet.ColPackQty].Text);

                    if (this.preparationManager.SetPrescription(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        if (this.preparationManager.DBErrCode == 1)
                        {
                            MessageBox.Show(info.Material.Name + "不能重复添加");                            
                        }
                        else
                        {
                            MessageBox.Show(Language.Msg("保存" + info.Drug.Name + "配制处方信息失败" + this.preparationManager.Err));
                        }

                        return -1;
                    }
                }

                #endregion

                #region 调用接口保存

                if (this.wrapperInterface != null)
                {
                    string information = "";
                    if (wrapperInterface.Save(drug, ref information) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message);
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        /// <summary>
        /// 删除配制处方信息
        /// </summary>
        /// <returns>成功返回删除条数 失败返回-1</returns>
        public int DelPrescription()
        {
            if (this.fsDrug_Sheet1.Rows.Count <= 0)
                return 1;

            string drugCode = this.fsDrug_Sheet1.Cells[this.fsDrug_Sheet1.ActiveRowIndex, 0].Text;
            if (this.fsDrug.ContainsFocus)
            {
                #region 制剂成品删除

                DialogResult rs = MessageBox.Show(Language.Msg("删除当前选择的成品配制处方信息吗？\n 此项删除将彻底删除该成品所有配制处方信息"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.No)
                    return 1;
                if (this.preparationManager.DelPrescription(drugCode,Neusoft.HISFC.Models.Base.EnumItemType.Drug) == -1)
                {
                    MessageBox.Show("对当前选择成品执行删除操作失败\n" + this.preparationManager.Err);
                    return -1;
                }

                if (this.hsPrescription.ContainsKey(drugCode))
                {
                    this.hsPrescription.Remove(drugCode);
                }

                this.ShowPrescriptionList();

                this.ShowPrescription();

                #endregion
            }
            else if (this.fsMaterial.ContainsFocus)
            {
                #region 生产原料删除

                DialogResult rs = MessageBox.Show(Language.Msg("删除当前选择的成品配制处方信息吗？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.No)
                    return 1;

                if (this.fsMaterial_Sheet1.Rows.Count <= 0)
                    return 1;
                int iIndex = this.fsMaterial_Sheet1.ActiveRowIndex;
                Neusoft.FrameWork.Models.NeuObject material = this.fsMaterial_Sheet1.Rows[iIndex].Tag as Neusoft.FrameWork.Models.NeuObject;
                if (material == null)
                {
                    return 1;
                }
                if (this.preparationManager.DelPrescription(drugCode,Neusoft.HISFC.Models.Base.EnumItemType.Drug, material.ID) == -1)
                {
                    MessageBox.Show("对当前选择处方记录进行删除操作失败\n" + this.preparationManager.Err);
                    return -1;
                }
                this.fsMaterial_Sheet1.Rows.Remove(iIndex, 1);

                #endregion
            }
            else if (this.wrapperInterface != null)
            {
                if (this.neuTabControl1.SelectedTab != this.tabPage1)
                {
                    this.wrapperInterface.Delete();
                }
            }

            return 1;
        }

        #region 调用接口完成

        HISFC.Components.Preparation.IPrescription wrapperInterface = null;

        /// <summary>
        /// 获取接口实例
        /// </summary>
        /// <returns></returns>
        protected int GetInterface()
        {
            try
            {
                wrapperInterface = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(HISFC.Components.Preparation.IPrescription)) as HISFC.Components.Preparation.IPrescription;
                if (wrapperInterface == null)
                {
                    MessageBox.Show(Language.Msg("获取接口发生错误"));
                    return -1;
                }

                System.Windows.Forms.TabPage interfaceTab = new TabPage(wrapperInterface.DisplayTitle);

                this.neuTabControl1.TabPages.Add(interfaceTab);

                wrapperInterface.Control.Dock = DockStyle.Fill;
                interfaceTab.Controls.Add(wrapperInterface.Control);

                this.wrapperInterface.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            return 1;
        }

        #endregion

        private void fsDrug_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (this.nowDrugPrescription == this.fsDrug_Sheet1.Cells[this.fsDrug_Sheet1.ActiveRowIndex, 0].Text)
            {
                return;
            }
            else
            {
                this.nowDrugPrescription = this.fsDrug_Sheet1.Cells[this.fsDrug_Sheet1.ActiveRowIndex, 0].Text;
            }

            if (this.wrapperInterface != null)
            {
                this.wrapperInterface.Drug = this.drugHelper.GetObjectFromID(this.nowDrugPrescription) as Neusoft.HISFC.Models.Pharmacy.Item;
            }

            this.ShowPrescription();
        }

        private void fsMaterial_SelectItem(object sender, EventArgs e)
        {
            if (this.AddItemDetail(sender as Neusoft.HISFC.Models.Pharmacy.Item) == 1)
            {
                this.fsMaterial_Sheet1.ActiveColumnIndex = (int)MaterialColumnSet.ColQty;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.fsMaterial.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.fsMaterial_Sheet1.ActiveColumnIndex == (int)MaterialColumnSet.ColQty)
                    {
                        this.fsMaterial_Sheet1.ActiveColumnIndex = (int)MaterialColumnSet.ColMemo;
                        return base.ProcessDialogKey(keyData);
                    }
                    if (this.fsMaterial_Sheet1.ActiveColumnIndex == (int)MaterialColumnSet.ColMemo)
                    {
                        this.fsMaterial_Sheet1.Rows.Add(this.fsMaterial_Sheet1.Rows.Count, 1);
                        this.fsMaterial_Sheet1.ActiveRowIndex = this.fsMaterial_Sheet1.Rows.Count;
                        this.fsMaterial_Sheet1.ActiveColumnIndex = (int)MaterialColumnSet.ColMaterialName;
                    }
                }
            }

            return base.ProcessDialogKey(keyData);
        }        

        private void ucPrescription_Load(object sender, EventArgs e)
        {
            this.Init();

            this.ShowPrescriptionList();

            this.ShowPrescription();            
        }

        #region 枚举

        /// <summary>
        /// 制剂成品列设置
        /// </summary>
        protected enum DrugColumnSet
        {
            /// <summary>
            /// 药品编码
            /// </summary>
            ColDrugID,
            /// <summary>
            /// 商品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty,
            /// <summary>
            /// 包装单位
            /// </summary>
            ColPackUnit,
            /// <summary>
            /// 最小单位
            /// </summary>
            ColMinUnit
        }

        protected enum MaterialColumnSet
        {
            /// <summary>
            /// 原料编码
            /// </summary>
            ColMaterialID,
            /// <summary>
            /// 名称
            /// </summary>
            ColMaterialName,
            /// <summary>
            /// 规格
            /// </summary>
            ColMaterialSpecs,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty,
            /// <summary>
            /// 价格
            /// </summary>
            ColPrice,
            /// <summary>
            /// 处方量
            /// </summary>
            ColQty,
            /// <summary>
            /// 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] interfaceTypes = new Type[] { typeof(HISFC.Components.Preparation.IPrescription) };

                return interfaceTypes;
            }
        }

        #endregion
    }
}
