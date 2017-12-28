using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucItemLevelManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 层级医嘱维护
        /// {1EB2DEC4-C309-441f-BCCE-516DB219FD0E} 
        /// </summary>
        public ucItemLevelManager()
        {
            InitializeComponent();
        }

        protected Neusoft.HISFC.BizLogic.Manager.ItemLevel itemLevelManager = new Neusoft.HISFC.BizLogic.Manager.ItemLevel();

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                ArrayList alLevelClass = managerMgr.GetConstantList("LEVELCLASS");
                this.cmbItemClass.AddItems(alLevelClass);

                this.cmbInOutType.SelectedValueChanged -= new System.EventHandler(this.cmbInOutType_SelectedIndexChanged);
                ArrayList alInOutType = new ArrayList();
                Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject("0", "全部", "");
                alInOutType.Add(obj1);
                Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject("1", "门诊", "");
                alInOutType.Add(obj2);
                Neusoft.FrameWork.Models.NeuObject obj3 = new Neusoft.FrameWork.Models.NeuObject("2", "住院", "");
                alInOutType.Add(obj3);
                this.cmbInOutType.AddItems(alInOutType);
                this.cmbInOutType.Tag = "0";
                this.cmbInOutType.SelectedValueChanged += new System.EventHandler(this.cmbInOutType_SelectedIndexChanged);
                this.ucInputItem1.ShowCategory = Neusoft.HISFC.Components.Common.Controls.EnumCategoryType.SysClass;
                this.ucInputItem1.ShowItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.Pharmacy;
                this.ucInputItem1.Init();
                this.ucInputItem1.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputItem1_SelectedItem);
                this.tvItemLevel1.AfterSelect += new TreeViewEventHandler(tvItemLevel1_AfterSelect);
                this.tvItemLevel1.IsEdit = true;

                this.tvItemLevel1.ShowPlusMinus = true;
            }
            
        }


        private void tvItemLevel1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvItemLevel1.SelectedNode.Tag == null)
            {
                return;
            }
            this.neuSpread1_Sheet1.RowCount = 0;
            ArrayList alItemLevel = new ArrayList();
            Neusoft.HISFC.Models.Fee.Item.ItemLevel myItemLevel = this.tvItemLevel1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
            if ((this.tvItemLevel1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel).ID == "ROOT")
            {
                alItemLevel = this.itemLevelManager.GetAllItemByFolderAndItemClass(myItemLevel.ID, myItemLevel.LevelClass.ID);
            }
            else
            {
                alItemLevel = this.itemLevelManager.GetAllItemByFolderID(myItemLevel.ID);
            }
            if (alItemLevel != null)
            {
                foreach (Neusoft.HISFC.Models.Fee.Item.ItemLevel itemLevel in alItemLevel)
                {
                    this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                    int lastRowIndex = this.neuSpread1_Sheet1.RowCount - 1;
                    this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColCode].Text = itemLevel.ID;
                    this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColName].Text = itemLevel.Name;
                    this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColSortID].Text = itemLevel.SortID.ToString();
                }
            }
        }

        private void ucInputItem1_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            if (this.tvItemLevel1.SelectedNode == null)
            {
                return;
            }
            if (sender is Neusoft.HISFC.Models.Pharmacy.Item)
            {               
                //Neusoft.HISFC.Models.Fee.Item.Undrug undrugTmp = sender as Neusoft.HISFC.Models.Fee.Item.Undrug;
                Neusoft.HISFC.Models.Pharmacy.Item durgTmp = sender as Neusoft.HISFC.Models.Pharmacy.Item;
                if (durgTmp.Type.ID.ToString() == "C")
                {
                    MessageBox.Show("不能添加草药");
                    return;
                }
                Neusoft.HISFC.Models.Fee.Item.ItemLevel itemLevel = new Neusoft.HISFC.Models.Fee.Item.ItemLevel();
                itemLevel.ID = durgTmp.ID;
                itemLevel.Name = durgTmp.Name;
                itemLevel.InOutType = this.tvItemLevel1.InOutType;
                if (this.tvItemLevel1.SelectedNode == this.tvItemLevel1.Nodes[0])
                {
                    itemLevel.Dept.ID = (this.itemLevelManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                    itemLevel.Owner = this.itemLevelManager.Operator;
                    itemLevel.ParentID = "ROOT";                
                    itemLevel.LevelClass = this.tvItemLevel1.LevelClass;
                    itemLevel.SpellCode = durgTmp.SpellCode;
                    itemLevel.WBCode = durgTmp.WBCode;
                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Item.ItemLevel itemLevelSelected = this.tvItemLevel1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;

                    itemLevel.Dept = itemLevelSelected.Dept;

                    itemLevel.Owner = this.itemLevelManager.Operator;
                    itemLevel.ParentID = itemLevelSelected.ID;
                    itemLevel.LevelClass = this.tvItemLevel1.LevelClass;
                    itemLevel.SpellCode = durgTmp.SpellCode;
                    itemLevel.WBCode = durgTmp.WBCode;
                }
                itemLevel.UserCode = "Y";
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                if (this.itemLevelManager.insertItem(itemLevel) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (this.itemLevelManager.DBErrCode == 1)
                    {
                        MessageBox.Show( itemLevel.Name + "  已存在，不能重复维护" );
                    }
                    else
                    {
                        MessageBox.Show( "增加项目失败！" + this.itemLevelManager.Err );
                    }

                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();

                this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                int lastRowIndex = this.neuSpread1_Sheet1.RowCount - 1;
                this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColCode].Text = durgTmp.ID;
                this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColName].Text = durgTmp.Name;
                this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColSpec].Text = durgTmp.Specs;
                this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColPrice].Text = durgTmp.Price.ToString();

                MessageBox.Show("增加项目成功！");
            }
        }

        private void cmbItemClass_SelectedValueChanged(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            if (this.cmbItemClass.Tag != null && this.cmbItemClass.SelectedItem != null)
            {
                this.tvItemLevel1.LevelClass = this.cmbItemClass.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
                this.tvItemLevel1.RefreshGroupByClass();
            }
        }

        private void cmbInOutType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbInOutType.Tag != null)
            {
                this.tvItemLevel1.InOutType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.cmbInOutType.Tag);
            }
        }

        protected enum Col
        {
            ColCode,
            ColName,
            ColSpec,
            ColPrice,
            //ColMemo,
            ColSortID,
            ColUpdate,
            ColDel
        }

        private void neuSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == (int)Col.ColUpdate)
            {
                int sort = Neusoft.FrameWork.Function.NConvert.ToInt32( this.neuSpread1_Sheet1.Cells[e.Row,(int)Col.ColSortID].Text);
                if (sort >= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    if (this.itemLevelManager.UpdateItemSortID(sort.ToString(), this.neuSpread1_Sheet1.Cells[e.Row, (int)Col.ColCode].Text, (this.tvItemLevel1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel).ID) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新排序号失败!" + this.itemLevelManager.Err);
                        return;
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show("更新排序号成功");
                }
            }
            if (e.Column == (int)Col.ColDel)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                if (this.itemLevelManager.deleteItem(this.neuSpread1_Sheet1.Cells[e.Row, (int)Col.ColCode].Text, (this.tvItemLevel1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel).ID) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除失败!" + this.itemLevelManager.Err);
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("删除成功！");
                this.neuSpread1_Sheet1.RowCount = 0;
                ArrayList alItemLevel = new ArrayList();
                Neusoft.HISFC.Models.Fee.Item.ItemLevel myItemLevel = this.tvItemLevel1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                if (myItemLevel.ID == "ROOT")
                {
                    alItemLevel = this.itemLevelManager.GetAllItemByFolderAndItemClass(myItemLevel.ID, myItemLevel.LevelClass.ID);
                }
                else
                {
                    alItemLevel = this.itemLevelManager.GetAllItemByFolderID(myItemLevel.ID);
                }
                if (alItemLevel != null)
                {
                    foreach (Neusoft.HISFC.Models.Fee.Item.ItemLevel itemLevel in alItemLevel)
                    {
                        this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                        int lastRowIndex = this.neuSpread1_Sheet1.RowCount - 1;
                        this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColCode].Text = itemLevel.ID;
                        this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColName].Text = itemLevel.Name;
                        this.neuSpread1_Sheet1.Cells[lastRowIndex, (int)Col.ColSortID].Text = itemLevel.SortID.ToString();
                    }
                }
            }
        }
    }
}
