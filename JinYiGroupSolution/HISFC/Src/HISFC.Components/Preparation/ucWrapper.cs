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
    /// [功能描述: 制剂处方维护接口实现类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public partial class ucWrapper : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.Components.Preparation.IPrescription
    {
        public ucWrapper()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();

        /// <summary>
        /// 制剂成品
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item drug = null;

        #region IPrescription 成员

        public Neusoft.HISFC.Models.Pharmacy.Item Drug
        {
            set
            {
                this.drug = value;
            }
        }

        public string DisplayTitle
        {
            get
            {
                return "其他消耗";
            }
        }

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl Control
        {
            get 
            {
                return this;
            }
        }

        public int Init()
        {
            FarPoint.Win.Spread.InputMap im;
            im = this.fsWrapper.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            this.fsWrapper.DrugType = "M";
            this.fsWrapper.PhaListEnabled = true;
            this.fsWrapper.PhaListColumnIndex = 1;

            this.fsWrapper.Init();

            return 1;
        }

        public int Save(Neusoft.HISFC.Models.Pharmacy.Item item, ref string information)
        {
            if (Neusoft.FrameWork.Management.PublicTrans.Trans != null)
            {
                this.preparationManager.SetTrans( Neusoft.FrameWork.Management.PublicTrans.Trans );
            }

            DateTime sysTime = this.preparationManager.GetDateTimeFromSysDateTime();

            try
            {
                Neusoft.HISFC.Models.Preparation.Prescription info = null;

                #region 保存其他材料

                for (int i = 0; i < this.fsWrapper_Sheet1.Rows.Count; i++)
                {
                    if (this.fsWrapper_Sheet1.Cells[i, 0].Text == "")
                    {
                        continue;
                    }

                    info = new Neusoft.HISFC.Models.Preparation.Prescription();

                    info.Drug = item;

                    info.Material = this.fsWrapper_Sheet1.Rows[i].Tag as Neusoft.FrameWork.Models.NeuObject;
                    if (info.Material == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("类型转换错误");
                        return -1;
                    }

                    info.Specs = this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialSpecs].Text;
                    info.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColPrice].Text );
                    info.NormativeUnit = this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColUnit].Text;

                    info.MaterialType = Neusoft.HISFC.Models.Preparation.EnumMaterialType.Wrapper;
                    info.NormativeQty = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColQty].Text );
                    info.Memo = this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMemo].Text;
                    info.OperEnv.ID = this.preparationManager.Operator.ID;
                    info.OperEnv.OperTime = sysTime;

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
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message);
                return -1;
            }

            return 1;
        }

        public int Delete()
        {
            if (this.fsWrapper.ContainsFocus)
            {
                #region 生产原料删除

                if (this.fsWrapper_Sheet1.Rows.Count <= 0)
                    return 1;

                DialogResult rs = MessageBox.Show(Language.Msg("删除当前选择的成品配制处方信息吗？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.No)
                    return 1;


                int iIndex = this.fsWrapper_Sheet1.ActiveRowIndex;
                Neusoft.FrameWork.Models.NeuObject material = this.fsWrapper_Sheet1.Rows[iIndex].Tag as Neusoft.FrameWork.Models.NeuObject;
                if (material == null)
                {
                    return 1;
                }
                if (this.preparationManager.DelPrescription(this.drug.ID,Neusoft.HISFC.Models.Base.EnumItemType.Drug, material.ID) == -1)
                {
                    MessageBox.Show("对当前选择处方记录进行删除操作失败\n" + this.preparationManager.Err);
                    return -1;
                }
                this.fsWrapper_Sheet1.Rows.Remove(iIndex, 1);

                #endregion
            }

            return 1;
        }

        public int Query()
        {
            if (this.drug == null)
            {
                return -1;
            }
            this.fsWrapper_Sheet1.Rows.Count = 0;

            List<Neusoft.HISFC.Models.Preparation.Prescription> al = this.preparationManager.QueryDrugPrescription(this.drug.ID, Neusoft.HISFC.Models.Preparation.EnumMaterialType.Wrapper);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取当前选择成品的配制其他材料信息出错\n" + this.drug.ID));
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Preparation.Prescription info in al)
            {
                int i = this.fsWrapper_Sheet1.Rows.Count;

                this.fsWrapper_Sheet1.Rows.Add(i, 1);
                this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialID].Text = info.Material.ID;
                this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialName].Text = info.Material.Name;
                this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialSpecs].Text = info.Specs;
                this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColPrice].Text = info.Price.ToString();
                this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColQty].Text = info.NormativeQty.ToString();
                this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMemo].Text = info.Memo;
                this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColUnit].Text = info.NormativeUnit;

                this.fsWrapper_Sheet1.Rows[i].Tag = info.Material;
            }

            return 1;
        }

        public int AddNewItem()
        {
            int rowCount = this.fsWrapper_Sheet1.Rows.Count;

            this.fsWrapper_Sheet1.Rows.Add(rowCount, 1);

            return 1;
        }

        #endregion

        /// <summary>
        /// 添加处方明细信息
        /// </summary>
        /// <param name="item"></param>
        public int AddItemDetail(Item item)
        {
            int i = this.fsWrapper_Sheet1.ActiveRowIndex;

            this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialID].Text = item.ID;
            this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialName].Text = item.Name;
            this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColMaterialSpecs].Text = item.Specs;
            this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColPrice].Text = item.PriceCollection.RetailPrice.ToString();
            this.fsWrapper_Sheet1.Cells[i, (int)MaterialColumnSet.ColUnit].Text = item.MinUnit;

            this.fsWrapper_Sheet1.Rows[i].Tag = item;

            return 1;
        }

        private void ucWrapper_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCell = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            this.fsWrapper_Sheet1.Columns[(int)MaterialColumnSet.ColQty].CellType = markNumCell;
        }

        private void fsWrapper_SelectItem(object sender, EventArgs e)
        {
            if (this.AddItemDetail(sender as Neusoft.HISFC.Models.Pharmacy.Item) == 1)
            {
                this.fsWrapper_Sheet1.ActiveColumnIndex = (int)MaterialColumnSet.ColQty;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.fsWrapper.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    if (this.fsWrapper_Sheet1.ActiveColumnIndex == (int)MaterialColumnSet.ColQty)
                    {
                        this.fsWrapper_Sheet1.ActiveColumnIndex = (int)MaterialColumnSet.ColMemo;
                        return base.ProcessDialogKey(keyData);
                    }
                    if (this.fsWrapper_Sheet1.ActiveColumnIndex == (int)MaterialColumnSet.ColMemo)
                    {
                        this.fsWrapper_Sheet1.Rows.Add(this.fsWrapper_Sheet1.Rows.Count, 1);
                        this.fsWrapper_Sheet1.ActiveRowIndex = this.fsWrapper_Sheet1.Rows.Count;
                        this.fsWrapper_Sheet1.ActiveColumnIndex = (int)MaterialColumnSet.ColMaterialName;
                    }
                }
            }
            return base.ProcessDialogKey(keyData);
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
    }
}
