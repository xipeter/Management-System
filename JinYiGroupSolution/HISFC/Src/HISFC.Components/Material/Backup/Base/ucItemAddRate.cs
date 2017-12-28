using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Material.Base
{
    public partial class ucItemAddRate : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucItemAddRate()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 物品基本信息管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// ObjectHelper
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 加价方式
        /// </summary>
        ArrayList alRateKindInfo = new ArrayList();

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {
            this.ucMaterialItemList1.ChooseDataEvent += new ucMaterialItemList.ChooseDataHandler(ucMaterialItemList1_ChooseDataEvent);

            //{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            this.ucMaterialItemList1.ShowMaterialList(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID);

            this.SetColumnType();

            Neusoft.HISFC.Models.Material.MaterialAddRateEnumService matAddRateEnum = new Neusoft.HISFC.Models.Material.MaterialAddRateEnumService();

            ArrayList al = Neusoft.HISFC.Models.Material.MaterialAddRateEnumService.List();
            this.alRateKindInfo = al;
            this.helper.ArrayObject = al;
        }

        /// <summary>
        /// 表格设置
        /// </summary>
        protected virtual void SetColumnType()
        {
            Neusoft.HISFC.Models.Material.MaterialAddRate addRate = new Neusoft.HISFC.Models.Material.MaterialAddRate();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cmbAddRuleCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

            cmbAddRuleCellType.Items = addRate.RateKind.StringItems;
            this.FpMetItemAddRule_Sheet1.Columns[5].CellType = cmbAddRuleCellType;
            this.FpMetItemAddRule_Sheet1.Columns[0].Visible = false;
            this.FpMetItemAddRule_Sheet1.Columns[1].Locked = true;
            this.FpMetItemAddRule_Sheet1.Columns[2].Locked = true;
            this.FpMetItemAddRule_Sheet1.Columns[3].Locked = true;
            this.FpMetItemAddRule_Sheet1.Columns[4].Locked = true;
            this.FpMetItemAddRule_Sheet1.Columns[8].Visible = false;
        }

        /// <summary>
        /// 添加数据到表格
        /// </summary>
        /// <param name="item"></param>
        protected virtual void AddDataToFP(Neusoft.HISFC.Models.Material.MaterialItem item, bool isNew)
        {
            int rowCount = this.FpMetItemAddRule_Sheet1.RowCount;
            this.FpMetItemAddRule_Sheet1.Rows.Add(rowCount, 1);

            this.FpMetItemAddRule_Sheet1.Cells[rowCount, 0].Text = item.ID;
            this.FpMetItemAddRule_Sheet1.Cells[rowCount, 1].Text = item.Name;
            this.FpMetItemAddRule_Sheet1.Cells[rowCount, 2].Text = item.Specs;
            this.FpMetItemAddRule_Sheet1.Cells[rowCount, 3].Text = item.UnitPrice.ToString();
            this.FpMetItemAddRule_Sheet1.Cells[rowCount, 4].Text = item.MinUnit;
            this.FpMetItemAddRule_Sheet1.Cells[rowCount, 5].Text = this.helper.GetName(item.AddRule);

            if (isNew)
            {
                this.FpMetItemAddRule_Sheet1.Cells[rowCount, 8].Text = "ADD";
            }

            this.FpMetItemAddRule_Sheet1.Rows[rowCount].Tag = item;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        protected virtual void QueryAll()
        {
            this.FpMetItemAddRule_Sheet1.RowCount = 0;
            List<Neusoft.HISFC.Models.Material.MaterialItem> al = this.itemManager.QueryMetItemHaveAddRule();
            if (al != null && al.Count > 0)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Material.MaterialItem item = al[i] as Neusoft.HISFC.Models.Material.MaterialItem;
                    this.AddDataToFP(item, false);
                }
            }
        }

        protected virtual int SaveAddRule()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.itemManager.Connection);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            for (int i = 0; i < this.FpMetItemAddRule_Sheet1.RowCount; i++)
            {
                if (this.FpMetItemAddRule_Sheet1.Cells[i, 8].Text != "")
                {
                    int iReturn = 0;
                    string addRule = "";
                    string itemID = "";

                    itemID = this.FpMetItemAddRule_Sheet1.Cells[i, 0].Text;
                    addRule = this.helper.GetID(this.FpMetItemAddRule_Sheet1.Cells[i, 5].Text.Trim());
                    iReturn = this.itemManager.UpdateMetItemAddRule(itemID, addRule);

                    if (iReturn < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新物资账目加价信息失败！" + this.itemManager.Err);
                        return -1;
                    }
                }

            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功！");
            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryAll();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveAddRule();
            return base.OnSave(sender, neuObject);
        }

        #endregion

        #region 共有方法

        #endregion

        #region 事件

        private void ucMaterialItemList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            //by yuyun 08-7-28 第一列变成自定义码  原自定义码列成物资编码{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            //string itemCode = sv.Cells[activeRow, 0].Text;
            string itemCode = sv.Cells[activeRow, 10].Text;

            Neusoft.HISFC.Models.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(itemCode);
            for (int i = 0; i < this.FpMetItemAddRule_Sheet1.RowCount; i++)
            {
                if (item.ID == this.FpMetItemAddRule_Sheet1.Cells[i, 0].Text)
                {
                    this.FpMetItemAddRule.Focus();
                    this.FpMetItemAddRule_Sheet1.ActiveRowIndex = i;

                    return;
                }
            }
            this.AddDataToFP(item, true);
        }

        private void ucItemAddRate_Load(object sender, EventArgs e)
        {
            this.Init();

            this.QueryAll();
        }

        private void FpMetItemAddRule_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (this.FpMetItemAddRule_Sheet1.Cells[e.Row, 0].Text == "" && e.Column == 8)
            {
                this.FpMetItemAddRule_Sheet1.Cells[e.Row, 0].Text = "MODIFY";

            }
        }

        #endregion
    }
}

