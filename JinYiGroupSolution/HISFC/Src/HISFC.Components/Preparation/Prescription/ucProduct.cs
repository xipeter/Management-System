using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Preparation.Prescription
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 成品处方维护－成品信息显示]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-05]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public partial class ucProduct : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,IPrescriptionProduct
    {
        public ucProduct()
        {
            InitializeComponent();
        }


        #region 变量

        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();     

        /// <summary>
        /// 当前已维护好的配制处方
        /// </summary>
        private System.Collections.Hashtable hsPrescription = new Hashtable();

        /// <summary>
        /// 药品列表数组
        /// </summary>
        private ArrayList alDrugList = null;

        /// <summary>
        /// 项目类别
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumItemType itemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
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

            this.hsPrescription.Add(item.ID, null);

            this.AddDrugToFp(item);

            this.fsDrug_Sheet1.ActiveRowIndex = this.fsDrug_Sheet1.Rows.Count - 1;
            this.fsDrug_Sheet1.AddSelection(this.fsDrug_Sheet1.Rows.Count - 1, 0, 1, -1);
            this.fsDrug_SelectionChanged(null, null);

            return 1;
        }

        #region IPrescriptionProduct 成员

        public event EventHandler ShowPrescriptionEvent;

        public int AddProduct()
        {
            return this.AddNewDrug();
        }

        public int ShowProduct(Neusoft.FrameWork.Models.NeuObject product)
        {
            Neusoft.HISFC.Models.Pharmacy.Item item = this.drugHelper.GetObjectFromID(product.ID) as Neusoft.HISFC.Models.Pharmacy.Item;

            return this.AddDrugToFp(item);
        }

        public int DeleteProduct()
        {
            string drugCode = this.fsDrug_Sheet1.Cells[this.fsDrug_Sheet1.ActiveRowIndex, 0].Text;

            DialogResult rs = MessageBox.Show(Language.Msg("删除当前选择的成品配制处方信息吗？\n 此项删除将彻底删除该成品所有配制处方信息"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return 1;
            if (this.preparationManager.DelPrescription(drugCode,this.itemType) == -1)
            {
                MessageBox.Show("对当前选择成品执行删除操作失败\n" + this.preparationManager.Err);
                return -1;
            }

            if (this.hsPrescription.ContainsKey(drugCode))
            {
                this.hsPrescription.Remove(drugCode);
            }

            return 1;
        }

        public int Clear()
        {
            this.fsDrug_Sheet1.Rows.Count = 0;

            return 1;
        }

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl ProductControl
        {
            get
            {
                return this;
            }
        }

        public Neusoft.HISFC.Models.Base.EnumItemType ItemType
        {
            set
            {
                this.itemType = value;
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void fsDrug_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            Neusoft.HISFC.Models.Pharmacy.Item item = this.fsDrug_Sheet1.Rows[this.fsDrug_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.Item;

            if (this.ShowPrescriptionEvent != null)
            {
                this.ShowPrescriptionEvent(item, System.EventArgs.Empty);
            }
        }


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
    }
}
