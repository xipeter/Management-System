using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Items
{
    public partial class ucUndrugPriceAdjust : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 定义全局变量

        //定义变量存储非药品信息
        private DataTable UndrugTable = null;
        private DataView UndrugView = null;
        //定义变量 存储要调价的信息
        private DataTable AdjustTable = null;
        private DataView AdjustView = null;
        private System.Windows.Forms.CheckBox immediate;
        //定义业务层操纵类
        Neusoft.HISFC.BizLogic.Fee.Item item = new Neusoft.HISFC.BizLogic.Fee.Item();
        private bool IsTextFocus = false;

        #endregion

        public ucUndrugPriceAdjust()
        {
            InitializeComponent();
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveInfo();
            return 1;
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("历史", "显示历史信息", 1, true, false, null);
            return this.toolBarService;
            //return base.OnInit(sender, neuObject, param);
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "历史":
                    this.AdjustInfo();
                    break;
                default: break;
            }
            //base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 加载信息
        /// </summary>
        private void loadUndrug()
        {
            try
            {
                UndrugTable = new DataTable();
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtDec = System.Type.GetType("System.Decimal");
                System.Type dtDTime = System.Type.GetType("System.DateTime");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                UndrugTable = new DataTable();
                UndrugTable.Columns.AddRange(new DataColumn[] {
																	new DataColumn( "编码",  dtStr ),		//0
																	new DataColumn("名称",    dtStr),		//1
																	new DataColumn("拼音码",  dtStr),		//2
																	new DataColumn("五笔",	 dtStr),		//3
																	new DataColumn("输入码",	 dtStr),		//4
																	new DataColumn("默认价",  dtDec),		//5
																	new DataColumn("儿童价",  dtDec),		//6
																	new DataColumn("特诊价",  dtDec) 		//7
																});

                //设置主键为编码
                CreateKeys(UndrugTable);
                UndrugView = new DataView(UndrugTable);
                this.neuSpread1_Sheet1.DataSource = UndrugView;

                ArrayList alReturn = new ArrayList();//返回的非药品信息;
                //获得非药品信息
                alReturn = item.Query("all", "all");
                if (alReturn == null)
                {
                    MessageBox.Show("获得非药品信息出错!" + item.Err);
                    return;
                }
                //循环插入信息
                foreach (Neusoft.HISFC.Models.Fee.Item.Undrug obj in alReturn)
                {
                    //{F8CA49B3-D36B-4172-9C8E-7D5CDD077A42} 项目列表内屏蔽复合项目 不能对复合项目进行调价
                    if (obj.UnitFlag == "1")
                    {
                        continue;
                    }

                    DataRow row = UndrugTable.NewRow();
                    SetRow(obj, row);
                    UndrugTable.Rows.Add(row);
                }
                UndrugTable.AcceptChanges(); //保存更改
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置主键为编码
        /// </summary>
        private void CreateKeys(DataTable table)
        {
            DataColumn[] keys = new DataColumn[] { table.Columns["编码"] };
            table.PrimaryKey = keys;
        }

        /// <summary>
        /// 填充信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>
        private void SetRow(Neusoft.HISFC.Models.Fee.Item.Undrug obj, DataRow row)
        {
            row["编码"] = obj.ID;			//0                                             
            row["名称"] = obj.Name;			//1	
            row["拼音码"] = obj.SpellCode;	//2											
            row["五笔"] = obj.WBCode;		//3											
            row["输入码"] = obj.UserCode;	//4								
            row["默认价"] = obj.Price;		//2											
            row["儿童价"] = obj.ChildPrice;		//3											
            row["特诊价"] = obj.SpecialPrice;		//4																		
        }

        /// <summary>
        /// 填充 调价信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>
        private void SetAdjustRow(Neusoft.HISFC.Models.Fee.Item.AdjustPrice obj, DataRow row)
        {
            row["编码"] = obj.OrgItem.ID;			    //0                                             
            row["名称"] = obj.OrgItem.Name;				//1																	
            row["调前默认价"] = obj.OrgItem.Price;		//5											
            row["调前儿童价"] = obj.OrgItem.ChildPrice;		//6											
            row["调前特诊价"] = obj.OrgItem.SpecialPrice;		//7		
            row["调后默认价"] = obj.NewItem.Price;		//5											
            row["调后儿童价"] = obj.NewItem.ChildPrice;		//6											
            row["调后特诊价"] = obj.NewItem.SpecialPrice;		//7	
        }

        /// <summary>
        /// 调价
        /// </summary>
        private void AdjustInfo()
        {
            //弹出调价历史窗口
            ucPriceHistory form = new ucPriceHistory();
            //form.Show();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(form);
            
            //Manager.FrmPricehistry form = new FrmPricehistry();
            //form.ShowDialog();
        }

        /// <summary>
        /// 得到到要调价的信息 返回列表 准备插入操作
        /// </summary>
        /// <returns></returns>
        private ArrayList GetInfo(string SequenceNo)
        {
            ArrayList ItemList = new ArrayList();
            if (AdjustTable == null)
            {
                return null;
            }
            Neusoft.HISFC.Models.Fee.Item.AdjustPrice item = null;
            //循环取数据 
            foreach (DataRow row in AdjustTable.Rows)
            {
                item = new Neusoft.HISFC.Models.Fee.Item.AdjustPrice();
                item.AdjustPriceNO = SequenceNo;
                item.OrgItem.ID = row["编码"].ToString();
                item.OrgItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["调前默认价"].ToString());
                item.OrgItem.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["调前儿童价"].ToString());
                item.OrgItem.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["调前特诊价"].ToString());
                item.NewItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["调后默认价"].ToString());
                item.NewItem.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["调后儿童价"].ToString());
                item.NewItem.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["调后特诊价"].ToString());
                item.BeginTime = this.dtpImmediate.Value;
                if (this.ckbImmediate.Checked) //是否即时生效
                {
                    item.User03 = "已生效";// 即时生效 则置成未生效
                }
                else
                {
                    item.User03 = "未生效"; //非即时生效 ，则置成已生效
                }
                ItemList.Add(item);
                item = null;
            }
            return ItemList;
        }

        private void SaveInfo()
        {
            try
            {
                this.neuSpread1.StopCellEditing();
                Neusoft.HISFC.BizLogic.Manager.AdjustPrice price = new Neusoft.HISFC.BizLogic.Manager.AdjustPrice();
                //获取调价单流水号
                string SequenceNo = price.GetAdjustPriceSequence();

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction Addtrans = new Neusoft.FrameWork.Management.Transaction(price.Connection);
                //Addtrans.BeginTransaction();

                price.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                #region 判断时间是否有效
                if (!ckbImmediate.Checked)  //定时生效
                {
                    if (this.dtpImmediate.Value < System.DateTime.Now)
                    {
                        this.dtpImmediate.Focus();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("生效的时间不能小于当前时间"));
                        return;
                    }
                }
                #endregion
                //获取要调价的信息
                ArrayList list = GetInfo(SequenceNo);
                if (list == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取调价信息出错"));
                    return;
                }

                #region  调价头表和明细表 保存调价信息
                foreach (Neusoft.HISFC.Models.Fee.Item.AdjustPrice info in list)
                {
                    //如果有以前调价还没有生效的 ，跟这次调价有冲突的 ，作废以前的调价记录
                    int temp = price.UpdateAdjustPriceDetail(info.OrgItem.ID);
                }
                //插入调价头表
                //插入调价明细表
                bool PriceHead = false;
                bool Result = true;
                foreach (Neusoft.HISFC.Models.Fee.Item.AdjustPrice info in list)
                {
                    if (!PriceHead)
                    {
                        //向调价头表中插入一条新的记录 fin_com_adjustundrugpricehead 
                        if (price.InsertAdjustPrice(info) <= 0)
                        {
                            Result = false;
                            break;
                        }
                        else
                        {
                            PriceHead = true;
                        }
                    }
                    //向调价明细中插入新的记录 fin_com_adjustundrugpricedetai
                    if (price.InsertAdjustPriceDetail(info) <= 0)
                    {
                        Result = false;
                        break;
                    }
                }
                if (Result)
                {
                    //提交数据
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));
                    if (AdjustTable != null)
                    {
                        AdjustTable.Clear();
                    }
                }
                else
                {
                    //回退信息
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存调价信息失败"));
                }
                #endregion

                #region 如果是立即生效 保存非药品 价格
                if (ckbImmediate.Checked) //立即生效
                {
                    Neusoft.HISFC.BizLogic.Fee.Item manItem = new Neusoft.HISFC.BizLogic.Fee.Item();
                    manItem.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    Neusoft.HISFC.Models.Fee.Item.Undrug temItem = null;
                    foreach (Neusoft.HISFC.Models.Fee.Item.AdjustPrice info in list)
                    {
                        //先转化成ITEM然后执行更新操作
                        temItem = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                        //药品编码
                        temItem.ID = info.OrgItem.ID;
                        //默认价
                        temItem.Price = info.NewItem.Price;
                        //儿童价
                        temItem.ChildPrice = info.NewItem.ChildPrice;
                        //特诊价
                        temItem.SpecialPrice = info.NewItem.SpecialPrice;
                        //执行更新操作。
                        if (manItem.AdjustPrice(temItem) < 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(manItem.Err));
                            return;
                        }
                        //{6DF09817-9532-4129-BE60-DED731C7E5B9} 更新所有含有该项目的复合项目价格

                        //manItem.QueryZTListByDetailItem(temItem);


                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(ex.Message));
            }
        }

        /// <summary>
        /// 如果是立即生效 先保存非药品信息 ，再保存调价信息
        /// </summary>
        private bool UpdateUndrug(ArrayList list)
        {
            bool Result = true;
            if (list == null)
            {
                return true;
            }
            Neusoft.HISFC.Models.Fee.Item.Undrug temItem = null;
            foreach (Neusoft.HISFC.Models.Fee.Item.AdjustPrice info in list)
            {
                //先转化成ITEM然后执行更新操作
                temItem = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                //药品编码
                temItem.ID = info.OrgItem.ID;
                //默认价
                temItem.Price = info.NewItem.Price;
                //儿童价
                temItem.ChildPrice = info.NewItem.ChildPrice;
                //特诊价
                temItem.SpecialPrice = info.NewItem.SpecialPrice;
            }
            return Result;
        }

        /// <summary>
        /// 加载信息
        /// </summary>
        private void loadAdjustUndrug()
        {
            try
            {
                AdjustTable = new DataTable();
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtDec = System.Type.GetType("System.Decimal");
                System.Type dtDTime = System.Type.GetType("System.DateTime");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                AdjustTable = new DataTable();
                AdjustTable.Columns.AddRange(new DataColumn[] {
																   new DataColumn( "编码",  dtStr ),		//0
																   new DataColumn("名称",    dtStr),		//1
																   new DataColumn("调前默认价",  dtDec),		//5
																   new DataColumn("调前儿童价",  dtDec),		//6
																   new DataColumn("调前特诊价",  dtDec), 		//7
																   new DataColumn("调后默认价",  dtDec),		//5
																   new DataColumn("调后儿童价",  dtDec),		//6
																   new DataColumn("调后特诊价",  dtDec), 		//7
															   });

                //设置主键为编码
                CreateKeys(AdjustTable);
                AdjustView = new DataView(AdjustTable);
                this.neuSpread2_Sheet1.DataSource = AdjustView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 查询主键列位置
        /// </summary>
        /// <returns></returns>
        private int GetColumnKey(string str)
        {
            foreach (FarPoint.Win.Spread.Column col in this.neuSpread1_Sheet1.Columns)
            {
                if (col.Label == str)
                {
                    return col.Index;
                }
            }
            return 0;
        }

        /// <summary>
        /// 增加一行数据到调价窗口
        /// </summary>
        private void AddDataInfo()
        {
            try
            {
                if (this.neuSpread1_Sheet1.RowCount < 1)
                {
                    return; //如果没有数据返回空 
                }
                ArrayList alInfo = new ArrayList();
                Neusoft.HISFC.Models.Fee.Item.Undrug info = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                //从数据库获取要修改的信息
                alInfo = item.Query(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, GetColumnKey("编码")].Text, "all");
                if (info == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取非药品信息出错"));
                    return;
                }
                if (alInfo == null)
                {
                    return;
                }
                info.ID = ((Neusoft.HISFC.Models.Fee.Item.Undrug)alInfo[0]).ID;
                info.Name = ((Neusoft.HISFC.Models.Fee.Item.Undrug)alInfo[0]).Name;
                info.Price = ((Neusoft.HISFC.Models.Fee.Item.Undrug)alInfo[0]).Price;
                info.ChildPrice = ((Neusoft.HISFC.Models.Fee.Item.Undrug)alInfo[0]).ChildPrice;
                info.SpecialPrice = ((Neusoft.HISFC.Models.Fee.Item.Undrug)alInfo[0]).SpecialPrice;

                //定义查找
                object[] keys = new object[] { info.ID };
                DataRow tempRow = AdjustTable.Rows.Find(keys);
                if (tempRow != null)
                {
                    MessageBox.Show(info.Name + "已经在调价信息表中了");
                    return;
                }

                Neusoft.HISFC.Models.Fee.Item.AdjustPrice tail = new Neusoft.HISFC.Models.Fee.Item.AdjustPrice();
                tail.OrgItem.ID = info.ID; //非药品编码
                tail.OrgItem.Name = info.Name;//非药品名称
                tail.OrgItem.Price = info.Price;//默认价
                tail.OrgItem.ChildPrice = info.ChildPrice;//儿童价
                tail.OrgItem.SpecialPrice = info.SpecialPrice;//特诊价
                tail.NewItem.Price = info.Price;
                tail.NewItem.ChildPrice = info.ChildPrice;
                tail.NewItem.SpecialPrice = info.SpecialPrice;
                //增加
                DataRow row = AdjustTable.NewRow();
                //填充数据
                SetAdjustRow(tail, row);
                //增加到表中
                AdjustTable.Rows.Add(row);
                //保存更改
                UndrugTable.AcceptChanges();
                LockfpSpread2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LockfpSpread2()
        {
            FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();
            num.MaximumValue = 999999;

            this.neuSpread2_Sheet1.Columns[2].CellType = num;
            neuSpread2_Sheet1.Columns[3].CellType = num;
            neuSpread2_Sheet1.Columns[4].CellType = num;
            neuSpread2_Sheet1.Columns[5].CellType = num;
            neuSpread2_Sheet1.Columns[6].CellType = num;
            neuSpread2_Sheet1.Columns[7].CellType = num;

            neuSpread2_Sheet1.Columns[0].Visible = false;
            neuSpread2_Sheet1.Columns[1].Locked = true;
            neuSpread2_Sheet1.Columns[2].Locked = true;
            neuSpread2_Sheet1.Columns[3].Locked = true;
            neuSpread2_Sheet1.Columns[4].Locked = true;
        }

        private void ucUndrugPriceAdjust_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
            Application.DoEvents();
            //初始化非药品列表
            loadUndrug();

            this.neuSpread1_Sheet1.Columns[0].Visible = false; ;

            //初始化调价表
            loadAdjustUndrug();
            LockfpSpread2();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            AddDataInfo();
        }

        private void ckbImmediate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbImmediate.Checked)
            {
                this.dtpImmediate.Visible = false;
            }
            else
            {
                this.dtpImmediate.Visible = true;
            }
        }

        private void neuTextBox1_Leave(object sender, EventArgs e)
        {
            this.IsTextFocus = false;
        }

        private void neuTextBox1_Enter(object sender, EventArgs e)
        {
            this.IsTextFocus = true;
        }

        private void neuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //设定 移动多少格滚动一次
                this.neuSpread1.SetViewportTopRow(0, neuSpread1_Sheet1.ActiveRowIndex - 5);
                //当前位置向上移动一行
                this.neuSpread1_Sheet1.ActiveRowIndex--;
                this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                //设定 移动多少格滚动一次
                this.neuSpread1.SetViewportTopRow(0, neuSpread1_Sheet1.ActiveRowIndex - 5);
                //当前位置向下移动一行
                this.neuSpread1_Sheet1.ActiveRowIndex++;
                this.neuSpread1_Sheet1.AddSelection(neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
            }
        }

        private void neuTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AddDataInfo(); //增加一行数据到 调价窗口
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int AltKey = Keys.Alt.GetHashCode();
            if (keyData.GetHashCode() == AltKey + Keys.S.GetHashCode())
            {
                //保存
                SaveInfo();
            }

            if (keyData.GetHashCode() == AltKey + Keys.A.GetHashCode())
            {
                //调价历史
                AdjustInfo();
            }

            if (keyData.GetHashCode() == AltKey + Keys.X.GetHashCode())
            {
                //退出
                this.FindForm().Close();
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!IsTextFocus) //查询框没有获得焦点 
            {
                if (keyData.GetHashCode() == Keys.Enter.GetHashCode())
                {
                    //回车操作 
                    if (neuSpread2_Sheet1.Rows.Count > 0)
                    {
                        //当前活动行
                        int i = neuSpread2_Sheet1.ActiveRowIndex;
                        int j = neuSpread2_Sheet1.ActiveColumnIndex;
                        if (j + 1 <= neuSpread2_Sheet1.ColumnCount - 1)
                        {
                            if (j <= 4)
                            {
                                j = 4; //直接跳到要修改得列
                            }
                            //不是最后一列 则向后移动一格
                            neuSpread2_Sheet1.SetActiveCell(i, j + 1);
                        }
                        else if (i < neuSpread2_Sheet1.Rows.Count)
                        {
                            //已经是最后一格  如果不是最后一行 则跳到下一行
                            neuSpread2_Sheet1.SetActiveCell(i + 1, 5);
                        }
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string temp = " like  '%" + this.neuTextBox1.Text + "%' ";
            this.UndrugView.RowFilter = "拼音码" + temp + " or " + "五笔" + temp + " or " + "输入码" + temp;
            this.UndrugView.RowStateFilter = DataViewRowState.CurrentRows;
        }
    }
}
