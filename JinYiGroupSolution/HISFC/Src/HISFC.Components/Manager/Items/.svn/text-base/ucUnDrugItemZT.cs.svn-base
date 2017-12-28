using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Items
{
    public partial class ucUnDrugItemZT : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private TreeNode node = new TreeNode();
        private DataView dvItems = new DataView();
        private Neusoft.HISFC.BizLogic.Manager.UndrugztManager ztManager = new Neusoft.HISFC.BizLogic.Manager.UndrugztManager();
        /// <summary>
        /// {21267B78-C198-43ed-8C52-5364C6F70FDA}
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Item itemManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        public ucUnDrugItemZT()
        {
            InitializeComponent();
        }

        private void ucUnDrugItemZT_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.FillTree() != 1)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("非药品项目组套树初始化失败"));
                    return;
                }
                
                if (this.FillFpItems() != 1)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("非药品项目列表初始化失败"));
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveButtonHandler();
            this.node.Tag = null;
            return 1;
        }

        private bool Valid()
        {
            //{78945AB0-B308-4063-B62C-82D81E662555}
            this.SpreadDetails.StopCellEditing();
            for (int i = 0; i < this.fpDetails.Rows.Count; i++)
            {
                //{78945AB0-B308-4063-B62C-82D81E662555}
                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpDetails.GetText(i, 5)) <= 0)
                {
                    MessageBox.Show("第" + (i + 1).ToString() + "数量必须是大于零的数，请重新输入！");
                    return false;
                }
            }
            return true;
        }
        private void SaveButtonHandler()
        {
            if (this.fpDetails.Rows.Count == 0)
            {
                return;
            }
            if (!Valid()) return;
            decimal ChildPrice=0;
            decimal Price=0;　
            decimal SpecialPrice = 0; //特诊
            //{67BF98D0-3FF2-4ff6-ACF9-F06C4A601C6A}
            this.SpreadDetails.StopCellEditing();//更新cell值

            List<Neusoft.HISFC.Models.Fee.Item.UndrugComb> lstUndrug = new List<Neusoft.HISFC.Models.Fee.Item.UndrugComb>();
            for (int i = 0, j = this.fpDetails.Rows.Count; i < j; i++)
            {
                Neusoft.HISFC.Models.Fee.Item.UndrugComb zt = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
                zt.Package.ID = this.fpDetails.GetText(i, 0).Trim();
                zt.Package.Name = this.fpDetails.GetText(i, 1).Trim();
                zt.ID = this.fpDetails.GetText(i, 2).Trim();
                zt.Name = this.fpDetails.GetText(i, 3).Trim();
                zt.SortID = Convert.ToInt32(this.fpDetails.GetText(i, 4));
                zt.Qty = Convert.ToDecimal(this.fpDetails.GetText(i, 5));
                if (this.fpDetails.GetText(i, 6).Trim() == "")
                {
                    zt.ValidState = "1";
                }
                else
                {
                    zt.ValidState = this.fpDetails.GetText(i, 6).Trim() == "有效" ? "1" : "0";
                }
                zt.SpellCode = this.fpDetails.GetText(i, 7);
                zt.WBCode = this.fpDetails.GetText(i, 8);
                zt.UserCode = this.fpDetails.GetText(i, 9);
                zt.Memo = this.fpDetails.GetText(i, 10);
                //{67BF98D0-3FF2-4ff6-ACF9-F06C4A601C6A}
                if (zt.ValidState == "1")//增加判断,如果该条项目有效,才累加单价
                {
                    Price += zt.Qty * Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpDetails.GetText(i, 11));
                    ChildPrice += zt.Qty * Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpDetails.GetText(i, 12));
                    SpecialPrice += zt.Qty * Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpDetails.GetText(i, 13));
                }
                lstUndrug.Add(zt);
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(ztManager.Connection);
            //trans.BeginTransaction();

            ztManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                if (this.ztManager.SaveUndrugzt(lstUndrug) != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败"));
                    return;
                }
                //string itemCode = ((Neusoft.HISFC.Models.Fee.Item.Undrug)this.node.Tag).ID;
                string itemCode = ((Neusoft.HISFC.Models.Fee.Item.Undrug)this.tvUndrugzt.SelectedNode.Tag).ID;
                if (this.ztManager.UpdateUndrugztPrice(itemCode, Price, ChildPrice, SpecialPrice) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败"));
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功"));
            }
            catch
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败"));
            }
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                p.PrintPreview(this.neuPanel3);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return base.OnPrint(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            this.ExportInfo();
            return base.Export(sender, neuObject);
        }

        /// <summary>
        /// 初始化树
        /// </summary>
        /// <returns>1,成功</returns>
        private int FillTree()
        {
            List<Neusoft.HISFC.Models.Fee.Item.Undrug> lstUndrug = new List<Neusoft.HISFC.Models.Fee.Item.Undrug>();
            if (this.ztManager.QueryAllValidItemzt(ref lstUndrug) == -1)
            {
                return -1;
            }
            if (lstUndrug.Count == 0)
            {
                return -1;
            }

            TreeNode root = new TreeNode("非药品组套列表");
            this.tvUndrugzt.Nodes.Add(root);

            for (int i = 0, j = lstUndrug.Count; i < j; i++)
            {
                TreeNode one = new TreeNode(lstUndrug[i].Name);//节点名称为项目名称
                one.Tag = lstUndrug[i];
                root.Nodes.Add(one);
            }
            this.tvUndrugzt.ExpandAll();
            return 1;
        }

        private int FillFpItems()
        {
            if (this.ztManager.QueryAllValidItems(ref dvItems) == -1)
            {
                //MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取数据失败"));
                return -1;
            }

            this.fpItems.DataSource = dvItems;
            //this.SetItemFarpoint();
            return 1;
        }        

        private int FillFpDetails(string pcode, string pname)
        {
            if (this.fpDetails.Rows.Count > 0)
            {
                this.fpDetails.Rows.Remove(0, this.fpDetails.Rows.Count);
            }

            List<Neusoft.HISFC.Models.Fee.Item.UndrugComb> lstzt = new List<Neusoft.HISFC.Models.Fee.Item.UndrugComb>();
            if (this.ztManager.QueryUnDrugztDetail(pcode, ref lstzt) == -1)
            {
                return -1;
            }

            

            if (lstzt.Count == 0)
            {
                return -1;
            }

            

            for (int i = 0, j = lstzt.Count; i < j; i++)
            {
               

               

                this.fpDetails.Rows.Add(i, 1);
                //{21267B78-C198-43ed-8C52-5364C6F70FDA}
               Neusoft.HISFC.Models.Fee.Item.Undrug item = this.itemManager.GetUndrugByCode(lstzt[i].ID);

               if (item == null)
                   continue;
            

                if (item.ValidState == "0")
                {
                    this.fpDetails.RowHeader.Cells[i, 0].Text = "帐页停用";
                    this.fpDetails.RowHeader.Cells[i, 0].ForeColor = Color.Red;
                }

                if (item.ValidState == "2")
                {
                    this.fpDetails.RowHeader.Cells[i, 0].Text = "帐页废弃";
                    this.fpDetails.RowHeader.Cells[i, 0].ForeColor = Color.Red;
                }

                if (item.ValidState == "1")
                {
                    this.fpDetails.RowHeader.Cells[i, 0].Text = "";
                    this.fpDetails.RowHeader.Cells[i, 0].ForeColor = this.fpDetails.ColumnHeader.Cells[0, 0].ForeColor;
                }

                this.fpDetails.SetText(i, 0, lstzt[i].Package.ID);
                this.fpDetails.SetText(i, 1, lstzt[i].Package.Name);
                this.fpDetails.SetText(i, 2, lstzt[i].ID);
                this.fpDetails.SetText(i, 3, lstzt[i].Name);
                this.fpDetails.SetText(i, 4, lstzt[i].SortID.ToString());
                this.fpDetails.SetText(i, 5, lstzt[i].Qty.ToString());
                this.fpDetails.SetText(i, 6, lstzt[i].ValidState);
                this.fpDetails.SetText(i, 7, lstzt[i].SpellCode);
                this.fpDetails.SetText(i, 8, lstzt[i].WBCode);
                this.fpDetails.SetText(i, 9, lstzt[i].UserCode);

                this.fpDetails.SetText(i, 10, lstzt[i].Memo);//标志位,如果有值则为更新,否则为插入
                this.fpDetails.SetText(i, 11, lstzt[i].Price.ToString());
                this.fpDetails.SetText(i, 12, lstzt[i].ChildPrice.ToString());
                this.fpDetails.SetText(i, 13, lstzt[i].SpecialPrice.ToString());
            }
            return 1;            
        }

        private void tvUndrugzt_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                return;
            }
            node.Tag = e.Node.Tag;

            string pcode = ((Neusoft.HISFC.Models.Fee.Item.Undrug)e.Node.Tag).ID;
            string pname = ((Neusoft.HISFC.Models.Fee.Item.Undrug)e.Node.Tag).Name;
            this.FillFpDetails(pcode, pname);
        }

        private void SpreadItems_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader)
            {
                return;
            }
            if (this.node.Tag == null)
            {
                MessageBox.Show("请选择所要维护的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string pcode = ((Neusoft.HISFC.Models.Fee.Item.Undrug)this.node.Tag).ID;
            string pname = ((Neusoft.HISFC.Models.Fee.Item.Undrug)this.node.Tag).Name;

            Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugzt = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
            undrugzt.Package.ID = pcode;
            undrugzt.Package.Name = pname;
            undrugzt.ID = this.fpItems.GetText(e.Row, 0);//以后把0改成名称
            undrugzt.Name = this.fpItems.GetText(e.Row, 1);//也一样
            undrugzt.SortID = 0;// Convert.ToInt32(this.fpItems.GetText(e.Row, 4));//也一样
            undrugzt.Qty = 1;// Convert.ToDecimal(this.fpItems.GetText(e.Row, 5));//也一样
            undrugzt.ValidState = "";// this.fpItems.GetText(e.Row, 6);//有效性
            undrugzt.SpellCode = this.fpItems.GetText(e.Row, 5);
            undrugzt.WBCode = this.fpItems.GetText(e.Row, 6);
            undrugzt.UserCode = this.fpItems.GetText(e.Row, 4);
            undrugzt.ChildPrice =Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpItems.GetText(e.Row, 26)); //儿童
            undrugzt.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpItems.GetText(e.Row, 9));//三甲
            undrugzt.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpItems.GetText(e.Row, 27));//特诊价
            undrugzt.Memo = "";// this.fpItems.GetText(e.Row, 10);//标志位
            if (this.IsNewLineExists(undrugzt.Package.ID, undrugzt.ID))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("组套明细已经存在"));
                return;
            }
            CreateNewLineInFpDetails(undrugzt);

        }

        private void CreateNewLineInFpDetails(Neusoft.HISFC.Models.Fee.Item.UndrugComb zt)
        {
            this.fpDetails.Rows.Add(0, 1);

            this.fpDetails.SetText(0, 0, zt.Package.ID);
            this.fpDetails.SetText(0, 1, zt.Package.Name);
            this.fpDetails.SetText(0, 2, zt.ID);
            this.fpDetails.SetText(0, 3, zt.Name);
            this.fpDetails.SetText(0, 4, zt.SortID.ToString());
            this.fpDetails.SetText(0, 5, zt.Qty.ToString());
            this.fpDetails.SetText(0, 6, zt.ValidState);
            this.fpDetails.SetText(0, 7, zt.SpellCode);
            this.fpDetails.SetText(0, 8, zt.WBCode);
            this.fpDetails.SetText(0, 9, zt.UserCode);
            this.fpDetails.SetText(0, 10, zt.Memo);//标志位,如果有值则为更新,否则为插入
            //this.fpDetails.SetText(0, 11, "1");//数量
            this.fpDetails.SetText(0, 11, zt.Price.ToString());//三甲
            this.fpDetails.SetText(0, 12, zt.ChildPrice.ToString());//儿童
            this.fpDetails.SetText(0, 13, zt.SpecialPrice.ToString());//特诊价
        }

        private bool IsNewLineExists(string packageid, string itemid)
        {
            for (int i = 0, j = this.fpDetails.Rows.Count; i < j; i++)
            {
                if( this.fpDetails.GetText(i, 0).Trim().Equals(packageid) && 
                    this.fpDetails.GetText(i, 2).Trim().Equals(itemid))
                {
                    return true;                    
                }
            }
            return false;
        }

        private void GenerateRowFilter(string whereValue)
        {
            this.dvItems.AllowDelete = true;
            this.dvItems.AllowEdit = true;
            this.dvItems.AllowNew = true;
            //if(whereValue == "")
            //{
            //    throw new Exception("查询条件不能为空!");
            //}
            StringBuilder builder = new StringBuilder();
            builder.Append("拼音码 like '");
            builder.Append(whereValue);
            builder.Append("%' ");
            builder.Append(" or ");
            builder.Append("五笔码 like '");
            builder.Append(whereValue);
            builder.Append("%' ");
            builder.Append(" or ");
            builder.Append("输入码 like '");
            builder.Append(whereValue);
            builder.Append("%' ");
            builder.Append(" or ");
            builder.Append("国家编码 like '");
            builder.Append(whereValue);
            builder.Append("%' ");
            builder.Append(" or ");
            builder.Append("国际编码 like '");
            builder.Append(whereValue);
            builder.Append("%' ");
            this.dvItems.RowFilter = builder.ToString();
            this.dvItems.RowStateFilter = DataViewRowState.CurrentRows;
        }

        private void tbQueryCondition_TextChanged(object sender, EventArgs e)
        {
            GenerateRowFilter(this.tbQueryCondition.Text);
        }

        private void SetItemFarpoint()
        {
            this.fpItems.Columns["编码"].Visible = false;
            this.fpItems.Columns["系统类别"].Visible = false;
            this.fpItems.Columns["最小费用代码"].Visible = false;
            this.fpItems.Columns["默认价"].Visible = false;
            this.fpItems.Columns["急诊加成比例"].Visible = false;
            this.fpItems.Columns["计划生育标记"].Visible = false;
            this.fpItems.Columns["确认标志"].Visible = false;
            this.fpItems.Columns["规格"].Visible = false;
            this.fpItems.Columns["设备编号"].Visible = false;
            this.fpItems.Columns["默认检查部位或标本"].Visible = false;
            this.fpItems.Columns["手术编码"].Visible = false;
            this.fpItems.Columns["手术分类"].Visible = false;
            this.fpItems.Columns["手术规模"].Visible = false;
            this.fpItems.Columns["儿童价"].Visible = false;
            this.fpItems.Columns["特诊价"].Visible = false;
            this.fpItems.Columns["省限制"].Visible = false;
            this.fpItems.Columns["市限制"].Visible = false;
            this.fpItems.Columns["自费项目"].Visible = false;
            this.fpItems.Columns["特殊标识1"].Visible = false;
            this.fpItems.Columns["特殊标识2"].Visible = false;
            this.fpItems.Columns["单价2"].Visible = false;
            this.fpItems.Columns["单价3"].Visible = false;
            this.fpItems.Columns["疾病分类"].Visible = false;
            this.fpItems.Columns["专科名称"].Visible = false;
            this.fpItems.Columns["病史及检查"].Visible = false;
            this.fpItems.Columns["检查要求"].Visible = false;
            this.fpItems.Columns["注意事项"].Visible = false;
            this.fpItems.Columns["CONSENT_FLAG"].Visible = false;
            this.fpItems.Columns["检查申请单名称"].Visible = false;
            this.fpItems.Columns["是否预约"].Visible = false;
            this.fpItems.Columns["ITEM_AREA"].Visible = false;
            this.fpItems.Columns["ITEM_NOAREA"].Visible = false;
            this.fpItems.Columns["单位标识"].Visible = false;
        }

        /// <summary>
        /// 原来想实现修改哪行,保存哪行了,以后再写吧
        /// </summary>
        /// <param name="rowIndex">被修改行的索引</param>
        /// <returns>1,成功; -1,失败</returns>
        private int SaveChangedRows(int rowIndex)
        {
            return 1;
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void ExportInfo()
        {
            bool tr = false;
            string fileName = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "excel|*.xls";
            saveFile.Title = "导出到Excel";

            //saveFile.FileName = "复合项目" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Replace(':', '-');

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FileName.Trim() != "")
                {
                    fileName = saveFile.FileName;
                    tr = this.SpreadDetails.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
                else
                {
                    MessageBox.Show("文件名不能为空!");
                    return;
                }

                if (tr)
                {
                    MessageBox.Show("导出成功!");
                }
                else
                {
                    MessageBox.Show("导出失败!");
                }
            }
        }

        /// <summary>
        /// 没处理,是为和SaveChangedRows一起使用的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpDetails_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
        }


        //private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        //protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        //{
        //    this.toolBarService.AddToolButton("保存", "保存组套明细", 0, true, false, null);
        //    return this.toolBarService;
        //    //return base.OnInit(sender, neuObject, param);
        //}
        //public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    switch (e.ClickedItem.Text)
        //    {
        //        case "保存":
        //            this.SaveButtonHandler();
        //            break;
        //        default: break;
        //    }
        //    //base.ToolStrip_ItemClicked(sender, e);
        //}
        //private void SetDetailFarpoint()
        //{
        //    this.fpDetails.Columns["项目名称"].Width = 150;
        //    this.fpDetails.Columns["组套名称"].Width = 150;
        //    this.fpDetails.Columns["拼音码"].Width = 80;
        //    this.fpDetails.Columns["五笔码"].Width = 80;
        //    this.fpDetails.Columns["输入码"].Width = 80;

        //    this.fpDetails.Columns["组套编号"].Visible = false;
        //    //this.fpDetails.Columns["组套名称"].Visible = false;
        //    this.fpDetails.Columns["项目编号"].Visible = false;
        //    //this.fpDetails.Columns["项目名称"].Visible = false;
        //    this.fpDetails.Columns["顺序号"].Visible = false;
        //    this.fpDetails.Columns["数量"].Visible = false;
        //    this.fpDetails.ColumnHeader.Cells.Get(0, 6).Value = "有效性";
        //    this.fpDetails.Columns["标志位"].Visible = false;
        //}
    }
}
