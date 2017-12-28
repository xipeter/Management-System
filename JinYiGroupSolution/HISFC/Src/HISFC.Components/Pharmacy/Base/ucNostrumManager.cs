using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 协定处方维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-06]<br></br>
    /// <修改记录>
    ///     <修改时间>2008-07-04</修改时间>
    ///     <修改内容>
    ///         完善功能
    ///     </修改内容>
    ///     <修改人>
    ///         郝武   
    ///     </修改人>
    /// </修改记录>
    /// <中日本地化功能 待摘除>
    ///     {2229C05D-3CF4-4bcc-A3BA-6134F10E0ABA}
    ///     1、明细信息显示时增加了特殊用法信息显示 特殊用法信息 为中日本地化信息
    ///         修改了Pharmacy.Nostrum.Detail 索引指向的Sql语句
    ///    2.屏蔽协定处方修改时更新字典中协定处方的价格 by Sunjh 2010-1-6 {67F2F7C1-8AEC-4f57-ABD0-D823F662C439}
    /// </中日本地化功能>
    /// </summary>
    public partial class ucNostrumManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucNostrumManager()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 业务管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 数据视图
        /// </summary>
        DataTable dt = new DataTable();

        /// <summary>
        /// 药品Hash数据
        /// </summary>
        System.Collections.Hashtable hsDrugData = new System.Collections.Hashtable();

        /// <summary>
        /// 帮助类
        /// </summary>
        Neusoft.FrameWork.Public.ObjectHelper ehUsage = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 常数管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant conm = new Neusoft.HISFC.BizLogic.Manager.Constant();

        #endregion

        #region 初始化

        /// <summary>
        /// 协定处方数据加载
        /// </summary>
        /// <returns></returns>
        private int InitNostrumList()
        {
            this.tvNostrumList.Nodes.Clear();

            List<Neusoft.HISFC.Models.Pharmacy.Item> nostrumList = this.itemManager.QueryNostrumList();
            if (nostrumList == null)
            {
                MessageBox.Show(Language.Msg("加载协定处方模版列表发生错误") + this.itemManager.Err);
                return -1;
            }

            this.tvNostrumList.ImageList = this.tvNostrumList.groupImageList;

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "协定处方";
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = rootNode.ImageIndex;

            foreach (Neusoft.HISFC.Models.Pharmacy.Item item in nostrumList)
            {
                TreeNode nostrumNode = new TreeNode();

                nostrumNode.Text = item.Name + "[" + item.Specs + "]";
                nostrumNode.ImageIndex = 4;
                nostrumNode.SelectedImageIndex = 2;
                nostrumNode.Tag = item;

                rootNode.Nodes.Add(nostrumNode);
            }

            this.tvNostrumList.Nodes.Add(rootNode);

            this.tvNostrumList.ExpandAll();

            return 1;
        }

        /// <summary>
        /// 数据表初始化
        /// </summary>
        /// <returns></returns>
        private int InitDataSet()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBol = System.Type.GetType("System.Boolean");


            //在myDataTable中添加列
            dt.Columns.AddRange(new DataColumn[] {
                                                                        new DataColumn("商品名称",	  dtStr),
                                                                        new DataColumn("规格",        dtStr),
                                                                        new DataColumn("零售价",      dtDec),
                                                                        new DataColumn("药品编码",	  dtStr),
                                                                        new DataColumn("单位",        dtStr),
                                                                        new DataColumn("拼音码",      dtStr),
                                                                        new DataColumn("五笔码",      dtStr),
                                                                        new DataColumn("自定义码",    dtStr),
                                                                        new DataColumn("通用名拼音码",dtStr),
                                                                        new DataColumn("通用名五笔码",dtStr),
                                                                    });

            this.fsDrugListSheet.DataSource = this.dt.DefaultView;

            return 1;
        }

        /// <summary>
        /// 药品数据初始化
        /// </summary>
        /// <returns></returns>
        private int InitDrugData()
        {
            this.InitDataSet();

            this.hsDrugData.Clear();

            List<Neusoft.HISFC.Models.Pharmacy.Item> itemList = this.itemManager.QueryItemAvailableList(true);
            if (itemList == null)
            {
                MessageBox.Show(Language.Msg("加载药品列表发生错误") + this.itemManager.Err);
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Item info in itemList)
            {
                if (this.AddDrugToDataTable(info) == -1)
                {
                    return -1;
                }

                this.hsDrugData.Add(info.ID, info);
            }

            //锁定药品列表
            for (int i = 0, j = fsDrugListSheet.Columns.Count; i < j; i++)
            {
                this.fsDrugListSheet.Columns[i].Locked = true;
            }

            return 1;
        }

        /// <summary>
        /// 数据增加
        /// </summary>
        /// <param name="item">药品信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDrugToDataTable(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            try
            {
                this.dt.Rows.Add(new object[] { 
                                                item.Name,                  //商品名称
                                                item.Specs,                 //规格
                                                item.PriceCollection.RetailPrice,       //零售价
                                                item.ID,                    //药品编码
                                                item.MinUnit,               //单位
                                                item.NameCollection.SpellCode,          //拼音码
                                                item.NameCollection.WBCode,             //五笔码
                                                item.NameCollection.UserCode,           //自定义码
                                                item.NameCollection.RegularSpell.SpellCode,       //通用名
                                                item.NameCollection.RegularSpell.WBCode
                                           });
            }
            catch (System.Data.ConstraintException)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("该药品已存在 不能重复添加"));
                return -1;
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("DataTable内赋值发生错误" + e.Message));

                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("DataTable内赋值发生错误" + ex.Message));

                return -1;
            }

            return 1;
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("删除", "删除新增加的协定处方明细", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除")
            {
                this.DelNewNostrumDetail();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveButtonHandler();
            this.tvNostrumList.Tag = null;
            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.InitNostrumList();

            return base.OnQuery( sender, neuObject );
        }

        #endregion

        #region 方法

        /// <summary>
        /// 是否可编辑
        /// </summary>
        /// <returns>允许编辑 返回True 否则返回False</returns>
        protected bool IsCanEdit()
        {
            if (this.fsNostrumDetailSheet.Rows.Count <= 0)      //当前无明细内容 说明新增药品
            {
                return true;
            }

            if (this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColFlug].Text == "0")        //原已维护信息
            {
                MessageBox.Show( "该协定处方已确认保存过,不能再进行明细内容修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop );
                return false;
            }

            return true;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        protected void Clear()
        {
            this.fsNostrumDetailSheet.Rows.Count = 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        protected int AddNewNostrumDetail()
        {
            if (this.tvNostrumList.SelectedNode.Tag == null)
            {
                MessageBox.Show( "请选择所要维护的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return -1;
            }

            if (this.IsCanEdit() == false)          //不允许进行编辑
            {
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Item selectItem = (Neusoft.HISFC.Models.Pharmacy.Item)this.tvNostrumList.SelectedNode.Tag;
            string pcode = selectItem.ID;
            string pname = selectItem.Name + "[" + selectItem.Specs + "]";
            string itemID = this.fsDrugListSheet.GetText( this.fsDrugListSheet.ActiveRowIndex, 3 );

            //判断是否存在该药品
            if (this.IsNewLineExists( pcode, itemID ))
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "组套明细已经存在改处方项目" ) );
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Item detailItem = this.itemManager.GetItem( itemID );
            if (detailItem == null)
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "根据药品编码获取药品明细信息发生错误  " ) + this.itemManager.Err );
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Nostrum nostrum = new Neusoft.HISFC.Models.Pharmacy.Nostrum();
            nostrum.ID = pcode;
            nostrum.Name = pname;

            nostrum.Item = detailItem;

            nostrum.Qty = NConvert.ToDecimal( 1 );

            nostrum.IsValid = true;
            nostrum.SortNO = 1;

            //从药品列表添加到处方列表中
            CreateNewLineInFpDetails( nostrum );

            this.fsNostrumDetail.Focus();
            this.fsNostrumDetailSheet.ActiveColumnIndex = (int)NostrumDetailColumn.ColQty;

            return 1;
        }

        /// <summary>
        /// 在协定处方列表中加入一列
        /// </summary>
        /// <param name="info"></param>
        private void CreateNewLineInFpDetails(Neusoft.HISFC.Models.Pharmacy.Nostrum info)
        {
            this.fsNostrumDetailSheet.Rows.Add( 0, 1 );

            this.fsNostrumDetailSheet.SetText( 0, (int)NostrumDetailColumn.ColID, info.ID );
            this.fsNostrumDetailSheet.SetText( 0, (int)NostrumDetailColumn.ColItemID, info.Item.ID );
            this.fsNostrumDetailSheet.SetText( 0, (int)NostrumDetailColumn.ColName, info.Name );
            this.fsNostrumDetailSheet.SetText( 0, (int)NostrumDetailColumn.ColItemName, info.Item.Name );
            this.fsNostrumDetailSheet.SetText( 0, (int)NostrumDetailColumn.ColQty, info.Qty.ToString() );
            this.fsNostrumDetailSheet.SetText( 0, (int)NostrumDetailColumn.ColUnit, info.Item.MinUnit );
            this.fsNostrumDetailSheet.SetValue( 0, (int)NostrumDetailColumn.ColValid, info.IsValid );
            this.fsNostrumDetailSheet.SetText( 0, (int)NostrumDetailColumn.ColSortNO, info.SortNO.ToString() );
            this.fsNostrumDetailSheet.SetValue( 0, (int)NostrumDetailColumn.ColFlug, 1 );


            this.fsNostrumDetailSheet.SetValue( 0, (int)NostrumDetailColumn.ColPriceR, info.Item.PriceCollection.RetailPrice );
            this.fsNostrumDetailSheet.SetValue( 0, (int)NostrumDetailColumn.ColPriceP, info.Item.PriceCollection.PurchasePrice );

            this.fsNostrumDetailSheet.SetValue( 0, (int)NostrumDetailColumn.ColSumR, Math.Round( info.Item.PriceCollection.RetailPrice * info.Qty / info.Item.PackQty, 2 ) );

            this.fsNostrumDetailSheet.SetValue( 0, (int)NostrumDetailColumn.ColSumP, Math.Round( info.Item.PriceCollection.PurchasePrice * info.Qty / info.Item.PackQty, 2 ) );
        }        

        /// <summary>
        /// 删除协定处方明细
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int DelNewNostrumDetail()
        {
            if (this.fsNostrumDetailSheet.Rows.Count <= 0)
            {
                return 1;
            }
            int rowIndex = this.fsNostrumDetailSheet.ActiveRowIndex;

            if (this.fsNostrumDetailSheet.Cells[rowIndex, (int)NostrumDetailColumn.ColFlug].Text == "0")     //已有信息
            {
                MessageBox.Show( "已保存过的协定处方信息，不允许进行明细内容修改，如需修改，请作废当前协定处方，重新维护", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop );
                return -1;
            }

            DialogResult rs = MessageBox.Show("是否删除所选择的协定处方明细信息", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return 1;
            }

            this.fsNostrumDetailSheet.Rows.Remove(rowIndex, 1);

            return 1;
        }

        /// <summary>
        /// 加载协定处方明细信息
        /// </summary>
        /// <param name="nostrumItem"></param>
        protected void ShowNostrumDetail(Neusoft.HISFC.Models.Pharmacy.Item nostrumItem)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Nostrum> nostrumDetailCollection = this.itemManager.QueryNostrumDetail(nostrumItem.ID);
            if (nostrumDetailCollection == null)
            {
                MessageBox.Show(Language.Msg("加载协定处方明细信息发生错误") + this.itemManager.Err);
                return;
            }
            //{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68} 增加提示信息显示
            this.tabDetail.Text = nostrumItem.Name + "[" + nostrumItem.Specs + "]   生产 1" + nostrumItem.PackUnit + "  所需的明细处方量";

            this.ShowNostrumDetail( nostrumItem,nostrumDetailCollection );

            if (nostrumDetailCollection.Count > 0)
            {
                this.fsNostrumDetail.Enabled = false;
            }
            else
            {
                this.fsNostrumDetail.Enabled = true;
            }

            if (nostrumDetailCollection.Count > 0)
            {            
                this.fsNostrumDetailSheet.Columns[9].Locked = true;
                this.fsNostrumDetailSheet.Columns[10].Locked = true;
                this.fsNostrumDetailSheet.Columns[11].Locked = true;
                this.fsNostrumDetailSheet.Columns[12].Locked = true;
                this.fsNostrumDetailSheet.Columns[13].Locked = true;
                this.fsNostrumDetailSheet.Columns[14].Locked = true;
            }
            else
            {
                this.fsNostrumDetailSheet.Columns[9].Locked = false;
                this.fsNostrumDetailSheet.Columns[10].Locked = false;
                this.fsNostrumDetailSheet.Columns[11].Locked = false;
                this.fsNostrumDetailSheet.Columns[12].Locked = false;
                this.fsNostrumDetailSheet.Columns[13].Locked = false;
                this.fsNostrumDetailSheet.Columns[14].Locked = false;
            }
        }

        /// <summary>
        /// 协定处方明细信息显示
        /// </summary>
        /// <param name="nostrumDetailCollection">协定处方明细信息</param>
        /// <param name="nostrumItem">协定处方信息</param>
        protected void ShowNostrumDetail(Neusoft.HISFC.Models.Pharmacy.Item nostrumItem,List<Neusoft.HISFC.Models.Pharmacy.Nostrum> nostrumDetailCollection)
        {
            this.fsNostrumDetailSheet.Rows.Count = 0;

            foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum info in nostrumDetailCollection)
            {
                this.fsNostrumDetailSheet.Rows.Add(0, 1);

                //协定处方编码
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColID].Text = info.ID;
                //药品编码
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColItemID].Text = info.Item.ID;
                //协定处方规格
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColName].Text = nostrumItem.Name + "[" + nostrumItem.Specs + "]";
                //药品名称
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColItemName].Text = info.Item.Name;
                //数量
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColQty].Text = info.Qty.ToString();
                //单位
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColUnit].Text = info.Item.MinUnit;
                //是否可用
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColValid].Value = info.IsValid;
                //排序号
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColSortNO].Text = info.SortNO.ToString();
                //0标志已有信息，1标志新插入信息
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColFlug].Value = 0;

                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColPriceR].Value = info.Item.PriceCollection.RetailPrice;
                //{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}  金额计算
                decimal prr = Math.Round( info.Qty * info.Item.PriceCollection.RetailPrice / info.Item.PackQty, 2 );
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColSumR].Text = prr.ToString();

                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColPriceP].Value = info.Item.PriceCollection.PurchasePrice;
                //{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}  金额计算
                decimal prp = Math.Round( info.Qty * info.Item.PriceCollection.PurchasePrice / info.Item.PackQty, 2 );
                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColSumP].Text = prp.ToString();

                this.fsNostrumDetailSheet.Cells[0, (int)NostrumDetailColumn.ColUsage].Text = ehUsage.GetName(info.Item.Usage.ID);

                this.fsNostrumDetailSheet.Rows[0].Tag = info;
            }
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <returns></returns>
        protected int Filter()
        {
            string filterStr = Function.GetFilterStr(this.dt.DefaultView, "%" + this.txtFilter.Text + "%");

            this.dt.DefaultView.RowFilter = filterStr;

            return 1;
        }

        /// <summary>
        /// 显示协定处方的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvNostrum_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node.Parent != null)
            {
                if (e.Node.Tag != null)
                {
                    this.ShowNostrumDetail(e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.Item);
                }
            }
        }

        /// <summary>
        /// 判断药品是否已经存在组套中
        /// </summary>
        /// <param name="packageid">组套编码</param>
        /// <param name="itemid">药品编码</param>
        /// <returns></returns>
        private bool IsNewLineExists(string packageid, string itemid)
        {
            for (int i = 0, j = this.fsNostrumDetailSheet.Rows.Count; i < j; i++)
            {
                if (this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColID).Trim().Equals(packageid) &&
                    this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColItemID).Trim().Equals(itemid))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证数量{AB3CDE46-C95D-4a6f-96FF-E970F8C84523}
        /// </summary>
        private bool ValidNum()
        {
            for (int i = 0; i < this.fsNostrumDetailSheet.RowCount; i++)
            {
                try
                {
                    decimal num = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fsNostrumDetailSheet.Cells[i, 4].Value);
                    if (num > 9999.9999M)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.fsNostrumDetailSheet.Cells[i, 3].Text + " 数量过大！"));
                        return false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(" 请输入正确的" + this.fsNostrumDetailSheet.Cells[i, 3].Text + "数量！"));
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 保存和更新协定处方信息
        /// </summary>
        private void SaveButtonHandler()
        {
            if (this.fsNostrumDetailSheet.Rows.Count == 0)
            {
                return;
            }

            if (this.IsCanEdit() == false)          //不允许进行编辑
            {
                return;
            }

            if (MessageBox.Show("请确认已录入的信息是否正确？保存后将不能再进行修改", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //更新cell值
            this.fsNostrumDetail.StopCellEditing();

            //{AB3CDE46-C95D-4a6f-96FF-E970F8C84523}防止数量输入过大
            if (this.ValidNum() == false)
            {
                return;
            }


            //用于插入的协定处方列表
            List<Neusoft.HISFC.Models.Pharmacy.Nostrum> lstNostrumInsert = new List<Neusoft.HISFC.Models.Pharmacy.Nostrum>();
            //用于更新的协定处方列表
            List<Neusoft.HISFC.Models.Pharmacy.Nostrum> lstNostrumUpdate = new List<Neusoft.HISFC.Models.Pharmacy.Nostrum>();
            //协定处方ID
            string nostrumID = "";

            #region 将协定处方的详细信息列表转化为实体

            for (int i = 0, j = this.fsNostrumDetailSheet.Rows.Count; i < j; i++)
            {

                Neusoft.HISFC.Models.Pharmacy.Nostrum nostrum = new Neusoft.HISFC.Models.Pharmacy.Nostrum();
                nostrum.ID = this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColID).Trim();
                nostrum.Item.ID = this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColItemID).Trim();
                nostrum.Name = this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColName).Trim().Split('[')[0].ToString();
                nostrum.Item.Name = this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColItemName).Trim();
                nostrum.Item.Specs = this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColName).Trim().Split('[')[1].Split(']')[0].ToString();
                nostrum.Qty = NConvert.ToDecimal(this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColQty).Trim());
                nostrum.Item.MinUnit = this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColUnit).Trim();
                nostrum.IsValid = NConvert.ToBoolean(this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColValid).Trim());
                nostrum.SortNO = NConvert.ToInt32(this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColSortNO));
                nostrum.Oper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                nostrum.Oper.OperTime = itemManager.GetDateTimeFromSysDateTime();

                //如果是新插入的列放入插入列表
                if (NConvert.ToInt32(this.fsNostrumDetailSheet.GetText(i, (int)NostrumDetailColumn.ColFlug)) == 1)
                {
                    lstNostrumInsert.Add(nostrum);
                }
                //如果是已有的列放入更新列表
                else
                {
                    lstNostrumUpdate.Add(nostrum);
                }

                nostrumID = nostrum.ID;
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {                
                //插入新添的数据
                for (int i = 0, j = lstNostrumInsert.Count; i < j; i++)
                {
                    if (itemManager.InsertNostrum(lstNostrumInsert[i]) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败") + itemManager.Err);
                        return;
                    }
                }

                //更新已有的数据
                for (int i = 0, j = lstNostrumUpdate.Count; i < j; i++)
                {
                    if (itemManager.UpdateNostrum(lstNostrumUpdate[i]) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败") + itemManager.Err);
                        return;
                    }
                }
                //对新增药品更新价格
                if (this.itemManager.UpdateNostrumPrice( nostrumID ) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "保存数据失败" ) + this.itemManager.Err );
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功"));

                for (int i = 0, j = this.fsDrugListSheet.RowCount; i < j; i++)
                {
                    this.fsNostrumDetailSheet.SetValue(0, (int)NostrumDetailColumn.ColFlug, 0);
                }
            }
            catch
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败"));
            }

            this.tvNostrumList.SelectedNode = this.tvNostrumList.Nodes[0];
        }

        /// <summary>
        /// 导出协定处方信息到Excel
        /// </summary>
        private void ExportInfo()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel(*.xls)|*.xls";
            saveFile.Title = "将协定处方信息导出到Excel";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFile.FileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    try
                    {
                        this.fsNostrumDetail.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                        MessageBox.Show("导出成功!");
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("导出失败!请确认文件未被打开");
                    }
                    catch
                    {
                        MessageBox.Show("导出失败!");
                    }
                }
                else
                {
                    MessageBox.Show("文件名不能为空!");
                    return;
                }
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            ehUsage.ArrayObject = conm.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                //初始化协定处方树
                this.InitDrugData();

                //初始化药品列表
                this.InitNostrumList();
                this.InitControls();

                this.toolBarService.SetToolButtonEnabled("删除", true);
            }

            base.OnLoad(e);
        }

        private void fsDrugList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader)
            {
                return;
            }

            this.AddNewNostrumDetail();
        }

        /// <summary>
        /// 验证药品数量的合法性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fsNostrumDetail_EditModeOff(object sender, EventArgs e)
        {
            for (int i = 0, j = fsNostrumDetailSheet.Rows.Count; i < j; i++)
            {

                try
                {
                    if (NConvert.ToInt32(fsNostrumDetailSheet.GetText(i, 4)) < 0)
                    {
                        MessageBox.Show("药品的数量不能为负数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.fsNostrumDetailSheet.SetText(i, 4, "1");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("药品的数量必须为非负数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.fsNostrumDetailSheet.SetText(i, 4, "1");
                }
            }
        }

        /// <summary>
        /// 导出协定处方信息到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            this.ExportInfo();
            return base.Export(sender, neuObject);
        }

        /// <summary>
        /// 按钮事件处理，实现上下键移动药品列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.fsDrugListSheet.RowCount > 0)
            {
                //使用向上键
                if (e.KeyCode == Keys.Up)
                {
                    //当到达第一行以后，返回到最后一行
                    if (this.fsDrugListSheet.ActiveRowIndex == 0)
                    {
                        this.fsDrugListSheet.ActiveRowIndex = this.fsDrugListSheet.RowCount - 1;
                    }
                    else
                    {
                        this.fsDrugListSheet.ActiveRowIndex--;
                    }
                }

                //使用向上键
                if (e.KeyCode == Keys.Down)
                {
                    //当翻到最后一行时，返回第一行
                    if (this.fsDrugListSheet.ActiveRowIndex == this.fsDrugListSheet.RowCount - 1)
                    {
                        this.fsDrugListSheet.ActiveRowIndex = 0;
                    }
                    else
                    {
                        this.fsDrugListSheet.ActiveRowIndex++;
                    }
                }

                e.Handled = true;
            }
            //使用回车键
            if (e.KeyCode == Keys.Enter)
            {
                this.AddNewNostrumDetail();
            }
        }

        #endregion

        #region 列枚举

        /// <summary>
        /// 协定处方项目枚举
        /// </summary>
        private enum NostrumDetailColumn
        {
            /// <summary>
            /// 协定处方编码
            /// </summary>
            ColID = 0,

            /// <summary>
            /// 药品编码
            /// </summary>
            ColItemID = 1,

            /// <summary>
            /// 项目名称规格
            /// </summary>
            ColName = 2,

            /// <summary>
            /// 药品名称
            /// </summary>
            ColItemName = 3,

            /// <summary>
            /// 数量
            /// </summary>
            ColQty = 4,

            /// <summary>
            /// 单位
            /// </summary>
            ColUnit = 5,

            /// <summary>
            /// 有效性
            /// </summary>
            ColValid = 6,

            /// <summary>
            /// 顺序号
            /// </summary>
            ColSortNO = 7,

            /// <summary>
            /// 标志是否是新增列
            /// </summary>
            ColFlug = 8,

            /// <summary>
            /// 零售价
            /// </summary>
            ColPriceR = 9,

            /// <summary>
            /// 零售金额
            /// </summary>
            ColSumR = 10,

            /// <summary>
            /// 进价
            /// </summary>
            ColPriceP = 11,

            /// <summary>
            /// 购入金额
            /// </summary>
            ColSumP = 12,

            /// <summary>
            /// 服用方法
            /// </summary>
            ColUsage = 13,

            /// <summary>
            /// 特殊用法
            /// </summary>
            ColSpeUsage = 14
        }

        #endregion

    }
}
