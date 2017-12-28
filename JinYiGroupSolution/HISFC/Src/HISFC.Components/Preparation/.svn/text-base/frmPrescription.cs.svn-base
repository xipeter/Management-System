using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Object.Pharmacy;
using System.Collections;
using Neusoft.NFC.Function;

namespace UFC.Preparation
{
    public partial class frmPrescription : Form
    {
        public frmPrescription()
        {
            InitializeComponent();
        }

        #region 私有变量
        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.Management.Pharmacy.Preparation preparationMgr = new Neusoft.HISFC.Management.Pharmacy.Preparation();
        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.Management.Pharmacy.Item itemMgr = new Neusoft.HISFC.Management.Pharmacy.Item();
        /// <summary>
        /// 配制处方数据集
        /// </summary>
        private DataSet dsPrescription;
        /// <summary>
        /// 配制处方DataView
        /// </summary>
        private DataView dvPrescription;
        /// <summary>
        /// 过滤字符串
        /// </summary>
        private string filterStr = "";
        /// <summary>
        /// 已维护的成品信息
        /// </summary>
        private ArrayList alDrug;

        private List<Neusoft.HISFC.Object.Preparation.Prescription> alPrescription;
        /// <summary>
        /// 当前显示的配制处方的成品编码
        /// </summary>
        private string nowDrugPrescription = "";
        /// <summary>
        /// 是否对成品框执行过滤
        /// </summary>
        private bool isFilter = true;
        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在加载基础数据 请稍候...");
            Application.DoEvents();

            this.ucQueryItem1.Init(false,"E");
            this.ucQueryItem1.SelectItem += new EventHandler(ucQueryItem1_SelectItem);
            this.ucQueryItem1.TextKeyDown += new KeyEventHandler(ucQueryItem1_TextKeyDown);
            this.ucQueryItem1.TextChanged += new EventHandler(ucQueryItem1_TextChanged);

            this.ucQueryItem2.Init(false,"E1");
            this.ucQueryItem2.isCheck = true;
            this.ucQueryItem2.isShow = false;
            this.ucQueryItem2.SelectItem += new EventHandler(ucQueryItem2_SelectItem);
            this.ucQueryItem2.TextKeyDown += new KeyEventHandler(ucQueryItem1_TextKeyDown);
            this.ucQueryItem2.TextChanged += new EventHandler(ucQueryItem1_TextChanged);
            this.neuSpread1.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(fpSpread1_SelectionChanged);

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 数据集初始化
        /// </summary>
        /// <returns></returns>
        private int InitDataSet()
        {
            try
            {
                this.dsPrescription = new DataSet();
                Type dtStr = System.Type.GetType("System.String");
                Type dtDec = typeof(System.Decimal);
                Type dtInt = typeof(System.Int32);
                Type dtBol = typeof(System.Boolean);
                Type dtDate = typeof(System.DateTime);

                DataTable dt = new DataTable("Table");
                dt.Columns.AddRange(new DataColumn[] {
															new DataColumn("药品编码",dtStr),			//药品编码
															new DataColumn("药品名称",dtStr),			//药品名称
															new DataColumn("药品通用名",dtStr),			//药品通用名
															new DataColumn("英文商品名",dtStr),			//英文商品名
															new DataColumn("规格",dtStr),				//规格
															new DataColumn("包装数量",dtDec),			//包装数量
															new DataColumn("包装单位",dtStr),			//包装单位
															new DataColumn("最小单位",dtStr),			//最小单位
															new DataColumn("零售价",dtDec),				//零售价
															new DataColumn("药品类别",dtStr),			//药品类别
															new DataColumn("药品性质",dtStr),			//药品性质
															new DataColumn("系统类别",dtStr),			//系统类别
															new DataColumn("是否停用",dtBol),			//是否停用
															new DataColumn("拼音码",dtStr),				//拼音码
															new DataColumn("五笔码",dtStr),				//五笔码
														    new DataColumn("自定义码",dtStr),			//自定义码
															new DataColumn("通用名拼音码",dtStr),			//通用名拼音码
															new DataColumn("通用名五笔码",dtStr),		//通用名五笔码
															new DataColumn("通用名自定义码",dtStr)		//通用名自定义码															
														});
                DataColumn[] keys = new DataColumn[] { dt.Columns["药品编码"] };
                dt.PrimaryKey = keys;
                this.dsPrescription.Tables.Add(dt);

                this.filterStr = "(药品名称 like '{0}') or (拼音码 like '{1}') or (五笔码 like '{2}') or (自定义码 like '{3}')";
                //格式化FarPoint
                this.SetFormat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据集初始化发生错误" + ex.Message);
                return -1;
            }
            return 1;

        }

        /// <summary>
        /// 格式化
        /// </summary>
        private void SetFormat()
        {
            this.neuSpread1_Sheet1.Columns.Count = this.dsPrescription.Tables[0].Columns.Count;

            this.neuSpread1_Sheet1.Columns[0].Label = "药品编码";
            this.neuSpread1_Sheet1.Columns[0].Visible = false;

            this.neuSpread1_Sheet1.Columns[1].Label = "成品名";
            this.neuSpread1_Sheet1.Columns[1].Visible = true;
            this.neuSpread1_Sheet1.Columns[1].Width = 180F;

            this.neuSpread1_Sheet1.Columns[2].Label = "通用名";
            this.neuSpread1_Sheet1.Columns[2].Visible = false;
            this.neuSpread1_Sheet1.Columns[3].Label = "英文名";
            this.neuSpread1_Sheet1.Columns[3].Visible = false;

            this.neuSpread1_Sheet1.Columns[4].Label = "规格";
            this.neuSpread1_Sheet1.Columns[4].Width = 80F;
            this.neuSpread1_Sheet1.Columns[5].Label = "包装数量";
            this.neuSpread1_Sheet1.Columns[6].Label = "包装单位";
            this.neuSpread1_Sheet1.Columns[7].Label = "最小单位";

            this.neuSpread1_Sheet1.Columns[8].Label = "零售价";
            this.neuSpread1_Sheet1.Columns[8].Visible = false;
            this.neuSpread1_Sheet1.Columns[9].Label = "药品类别";
            this.neuSpread1_Sheet1.Columns[9].Visible = false;
            this.neuSpread1_Sheet1.Columns[10].Label = "药品性质";
            this.neuSpread1_Sheet1.Columns[10].Visible = false;
            this.neuSpread1_Sheet1.Columns[11].Label = "系统类别";
            this.neuSpread1_Sheet1.Columns[11].Visible = false;
            this.neuSpread1_Sheet1.Columns[12].Label = "是否停用";
            this.neuSpread1_Sheet1.Columns[12].Visible = false;
            this.neuSpread1_Sheet1.Columns[13].Label = "拼音码";
            this.neuSpread1_Sheet1.Columns[13].Visible = false;
            this.neuSpread1_Sheet1.Columns[14].Label = "五笔码";
            this.neuSpread1_Sheet1.Columns[14].Visible = false;
            this.neuSpread1_Sheet1.Columns[15].Label = "自定义码";
            this.neuSpread1_Sheet1.Columns[15].Visible = false;
            this.neuSpread1_Sheet1.Columns[16].Label = "通用名拼音码";
            this.neuSpread1_Sheet1.Columns[16].Visible = false;
            this.neuSpread1_Sheet1.Columns[17].Label = "通用名五笔码";
            this.neuSpread1_Sheet1.Columns[17].Visible = false;
            this.neuSpread1_Sheet1.Columns[18].Label = "通用名自定义码";
            this.neuSpread1_Sheet1.Columns[18].Visible = false;
        }

        #endregion

        /// <summary>
        /// 根据实体获取对应的DataRow
        /// </summary>
        /// <param name="drug">药品基本信息实体</param>
        /// <returns>成功返回填充后的DataRow 失败返回null</returns>
        private DataRow GetRow(Item drug)
        {
            try
            {
                DataRow dr = this.dsPrescription.Tables[0].NewRow();

                #region DataRow填充
                dr["药品编码"] = drug.ID;
                dr["药品名称"] = drug.Name;
                dr["药品通用名"] = drug.NameCollection.RegularName;
                dr["英文商品名"] = drug.NameCollection.EnglishName;		//英文名
                dr["规格"] = drug.Specs;					//规格
                dr["包装数量"] = drug.PackQty;
                dr["包装单位"] = drug.PackUnit;
                dr["最小单位"] = drug.MinUnit;
                dr["零售价"] = drug.PriceCollection.RetailPrice;
                dr["药品类别"] = drug.Type.ID;
                dr["药品性质"] = drug.Quality.ID;
                dr["系统类别"] = drug.SysClass.ID;
                dr["是否停用"] = drug.IsStop;
                dr["拼音码"] = drug.SpellCode;
                dr["五笔码"] = drug.WBCode;
                dr["自定义码"] = drug.UserCode;
                dr["通用名拼音码"] = drug.NameCollection.SpellCode;
                dr["通用名五笔码"] = drug.NameCollection.WBCode;
                dr["通用名自定义码"] = drug.NameCollection.UserCode;
                #endregion

                return dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("由实体填充DataRow时发生错误 \n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 由成品数组内获取成品信息
        /// </summary>
        /// <param name="drugCode">成品编码</param>
        /// <returns>成功返回Item实体 失败返回null</returns>
        private Item GetItem(string drugCode)
        {
            foreach (Item info in this.alDrug)
            {
                if (info.ID == drugCode)
                    return info;
            }
            return null;
        }

        /// <summary>
        /// 清屏操作
        /// </summary>
        /// <param name="isClearDrug">是否清屏制剂成品显示</param>
        public void Clear(bool isClearDrug)
        {
            //this.neuSpread2_Sheet1.Rows.Count = 0;
            //this.neuSpread1_Sheet1.Rows.Count = 0;
            //if (this.dsPrescription != null && this.dsPrescription.Tables[0].Rows.Count > 0)
            //{
            //    this.dsPrescription.Tables[0].Clear();
            //}
        }

        /// <summary>
        /// 添加新成品
        /// </summary>
        /// <param name="item"></param>
        protected void AddItem(Item item)
        {
            if (item == null || item.ID == "")
                return;

            if (this.dsPrescription == null)
            {
                this.dsPrescription = new DataSet();
            }
            bool isNew = this.dsPrescription.Tables[0].Rows.Count == 0 ? true : false;

            DataRow findRow = this.dsPrescription.Tables[0].Rows.Find(item.ID);
            if (findRow != null)
            {
                MessageBox.Show(item.Name + " 已维护好处方 不可重复维护");
                return;
            }

            DataRow dr = this.GetRow(item);
            this.dsPrescription.Tables[0].Rows.Add(dr);
            if (isNew)
            {
                this.dvPrescription = new DataView(this.dsPrescription.Tables[0]);
                this.neuSpread1_Sheet1.DataSource = this.dvPrescription;
            }

            if (this.alDrug == null)
                this.alDrug = new ArrayList();
            this.alDrug.Add(item);
            this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
        }

        public void AddItemDetail(Item item)
        {
            int i = this.neuSpread2_Sheet1.Rows.Count;
            this.neuSpread2_Sheet1.Rows.Add(i, 1);
            this.neuSpread2_Sheet1.Cells[i, 0].Text = item.Name;
            this.neuSpread2_Sheet1.Cells[i, 1].Text = item.Specs;
            this.neuSpread2_Sheet1.Cells[i, 3].Text = item.MinUnit;
            this.neuSpread2_Sheet1.Rows[i].Tag = item;
        }

        /// <summary>
        /// 获取成品列表
        /// </summary>
        public void Query()
        {
            this.GetPrescription();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return this.SavePrescription();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Del()
        {
            try
            {
                return this.DelPrescription();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 增加一条明细
        /// </summary>
        protected void Add()
        {
            this.neuSpread2_Sheet1.Rows.Add(this.neuSpread2_Sheet1.Rows.Count, 1);
            this.neuSpread2_Sheet1.ActiveColumnIndex = 0;
        }

        #region 配制处方
        /// <summary>
        /// 获取成品配制处方信息
        /// </summary>
        /// <returns></returns>
        public int GetPrescription()
        {
            //this.Clear(true);
            this.dsPrescription.Tables[0].Clear();
            this.neuSpread2_Sheet1.Rows.Count = 0;
            this.neuSpread1_Sheet1.Rows.Count = 0;

            this.alPrescription = this.preparationMgr.QueryPrescription();
            if (this.alPrescription == null)
            {
                MessageBox.Show("未正确获取成品配制处方信息 \n" + this.preparationMgr.Err);
                return -1;
            }
            DataRow dr;
            string privDrugCode = "";					//上一条记录成品编码
            ArrayList alTemp = new ArrayList();
            foreach (Neusoft.HISFC.Object.Preparation.Prescription info in this.alPrescription)
            {
                if (info.Drug.ID != privDrugCode)
                {
                    #region 获取成品基本信息
                    info.Drug = this.itemMgr.GetItem(info.Drug.ID);
                    if (info.Drug == null)
                    {
                        MessageBox.Show("对 " + info.Drug.Name + " 获取药品基本信息失败\n" + this.itemMgr.Err);
                        return -1;
                    }
                    if (this.alDrug == null)
                    {
                        this.alDrug = new ArrayList();
                    }
                    this.alDrug.Add(info.Drug);
                    #endregion

                    dr = this.GetRow(info.Drug);
                    if (dr == null)
                        return -1;
                    this.dsPrescription.Tables[0].Rows.Add(dr);
                    privDrugCode = info.Drug.ID;
                }
            }
            if (this.dsPrescription.Tables[0].Rows.Count > 0)
            {
                this.dvPrescription = new DataView(this.dsPrescription.Tables[0]);
                this.neuSpread1_Sheet1.DataSource = this.dvPrescription;
            }
            return 1;
        }

        /// <summary>
        /// 配制处方信息 并显示
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowPrescription()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return -1;

            string drugCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
            this.neuSpread2_Sheet1.Rows.Count = 0;
            //this.Clear(false);

            this.lbPrescription.Text = string.Format("{0}  成品处方内容（标准处方量以成品量1000为基准量）", this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Text);

            List<Neusoft.HISFC.Object.Preparation.Prescription> al = this.preparationMgr.QueryPrescription(drugCode);
            if (al == null)
            {
                MessageBox.Show("获取当前选择成品的配制处方信息出错\n" + drugCode);
                return -1;
            }
            foreach (Neusoft.HISFC.Object.Preparation.Prescription info in al)
            {
                int i = this.neuSpread2_Sheet1.Rows.Count;

                this.neuSpread2_Sheet1.Rows.Add(i, 1);
                this.neuSpread2_Sheet1.Cells[i, 0].Text = info.Material.Name;
                this.neuSpread2_Sheet1.Cells[i, 1].Text = info.Specs;
                this.neuSpread2_Sheet1.Cells[i, 2].Text = info.NormativeQty.ToString();
                this.neuSpread2_Sheet1.Cells[i, 3].Text = info.NormativeUnit;

                this.neuSpread2_Sheet1.Rows[i].Tag = info.Material;


            }
            return 1;
        }

        /// <summary>
        /// 保存配制处方信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SavePrescription()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return 1;
            if (this.neuSpread2_Sheet1.Rows.Count <= 0)
                return 1;

            string drugCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
            DateTime sysTime = this.preparationMgr.GetDateTimeFromSysDateTime();

            Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction(Neusoft.NFC.Management.Connection.Instance);
            t.BeginTransaction();
            this.preparationMgr.SetTrans(t.Trans);

            try
            {
                if (this.preparationMgr.DelPrescription(drugCode) == -1)
                {
                    t.RollBack();
                    MessageBox.Show("删除配制处方信息出错" + this.preparationMgr.Err);
                    return -1;
                }
                Neusoft.HISFC.Object.Preparation.Prescription info = new Neusoft.HISFC.Object.Preparation.Prescription();
                Neusoft.HISFC.Object.Pharmacy.Item tempItem;
                for (int i = 0; i < this.neuSpread2_Sheet1.Rows.Count; i++)
                {
                    if (this.neuSpread2_Sheet1.Cells[i, 0].Text == "")
                        continue;

                    info = new Neusoft.HISFC.Object.Preparation.Prescription();
                    info.Drug = this.GetItem(drugCode);
                    tempItem = this.neuSpread2_Sheet1.Rows[i].Tag as Neusoft.HISFC.Object.Pharmacy.Item;
                    if (tempItem == null)
                    {
                        t.RollBack();
                        MessageBox.Show("类型转换错误");
                        return -1;
                    }
                    info.Material = tempItem;
                    info.NormativeQty = NConvert.ToDecimal(this.neuSpread2_Sheet1.Cells[i, 2].Text);
                    info.NormativeUnit = this.neuSpread2_Sheet1.Cells[i, 3].Text;
                    info.OperEnv.ID = this.preparationMgr.Operator.ID;
                    info.OperEnv.OperTime = sysTime;

                    if (this.preparationMgr.SetPrescription(info) == -1)
                    {
                        t.RollBack();
                        if (this.preparationMgr.DBErrCode == 1)
                            MessageBox.Show(info.Material.Name + "不能重复添加");
                        else
                            MessageBox.Show("保存" + info.Drug.Name + "配制处方信息失败" + this.preparationMgr.Err);
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                t.RollBack();
                MessageBox.Show(ex.Message);
            }
            t.Commit();
            MessageBox.Show("保存成功");
            return 1;
        }

        /// <summary>
        /// 删除配制处方信息
        /// </summary>
        /// <returns>成功返回删除条数 失败返回-1</returns>
        public int DelPrescription()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return 1;

            string drugCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
            if (this.neuSpread1.ContainsFocus)
            {
                DialogResult rs = MessageBox.Show("删除当前选择的成品配制处方信息吗？\n 此项删除将彻底删除该成品所有配制处方信息", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.No)
                    return 1;
                if (this.preparationMgr.DelPrescription(drugCode) == -1)
                {
                    MessageBox.Show("对当前选择成品执行删除操作失败\n" + this.preparationMgr.Err);
                    return -1;
                }
                DataRow dr = this.dsPrescription.Tables[0].Rows.Find(drugCode);
                if (dr != null)
                {
                    this.dsPrescription.Tables[0].Rows.Remove(dr);
                }
                this.ShowPrescription();
            }
            else if (this.neuSpread2.ContainsFocus)
            {
                DialogResult rs = MessageBox.Show("删除当前选择的成品配制处方信息吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.No)
                    return 1;

                if (this.neuSpread2_Sheet1.Rows.Count <= 0)
                    return 1;
                int iIndex = this.neuSpread2_Sheet1.ActiveRowIndex;
                Neusoft.HISFC.Object.Pharmacy.Item item = this.neuSpread2_Sheet1.Rows[iIndex].Tag as Neusoft.HISFC.Object.Pharmacy.Item;
                if (item == null)
                    return 1;
                if (this.preparationMgr.DelPrescription(drugCode, item.ID) == -1)
                {
                    MessageBox.Show("对当前选择处方记录进行删除操作失败\n" + this.preparationMgr.Err);
                    return -1;
                }
                this.neuSpread2_Sheet1.Rows.Remove(iIndex, 1);
            }
            if (this.neuSpread2_Sheet1.Rows.Count <= 0)
            {
                DataRow dr = this.dsPrescription.Tables[0].Rows.Find(drugCode);
                if (dr != null)
                {
                    this.dsPrescription.Tables[0].Rows.Remove(dr);
                }
            }
            return 1;
        }
        #endregion

        #region 事件
        private void neuToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == this.tbExit)
            {
                this.Close();
                return;
            }
            if (e.Button == this.tbSave)
            {
                this.Save();
                return;
            }
            if (e.Button == this.tbQuery)
            {
                this.Query();
                return;
            }
            if (e.Button == this.tbDel)
            {
                this.Del();
                return;
            }
            if (e.Button == this.tbAdd)
            {
                this.Add();
            }
        }

        private void ucQueryItem1_SelectItem(object sender, EventArgs e)
        {
            Item item = new Item();
            item = sender as Item;

            this.AddItem(item);

            this.lbPrescription.Text = string.Format("{0}  成品处方内容（标准处方量以成品量1000为基准量）", item.Name);

            this.Clear(false);
        }

        private void ucQueryItem2_SelectItem(object sender, EventArgs e)
        {
            Item item = new Item();
            item = sender as Item;

            this.AddItemDetail(item);
            this.Clear(false);
        }

        private void ucQueryItem1_TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex--;
                //加上该行代码后 可以实现上下键翻动选择 但不一定触发SelectChanged事件
                //				this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex,0,1,this.neuSpread1_Sheet1.Columns.Count);
                this.isFilter = false;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex++;
                //				this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex,0,1,this.neuSpread1_Sheet1.Columns.Count);
                this.isFilter = false;
                e.Handled = true;
            }
            else
            {
                this.isFilter = true;
            }
        }

        private void ucQueryItem1_TextChanged(object sender, EventArgs e)
        {
            if (!this.isFilter)
                return;

            if (this.dvPrescription != null && this.dvPrescription.Table.Rows.Count > 0)
            {
                string str = "%" + this.ucQueryItem1.TxtStr + "%";
                this.dvPrescription.RowFilter = string.Format(this.filterStr, str, str, str, str);

                this.neuSpread1_Sheet1.DataSource = this.dvPrescription;

                this.ShowPrescription();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //switch (keyData)
            //{
            //    case Keys.Enter:

            //        #region 行、列跳转
            //        if (this.fpItem1.ContainsFocus)
            //        {
            //            if (this.neuSpread2_Sheet1.ActiveColumnIndex == 0)
            //                this.fpItem1.JumpColumn(2, false);
            //            else
            //                this.fpItem1.JumpColumn(0, true);
            //        }
            //        #endregion

            //        break;
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtRegulation_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (this.nowDrugPrescription == this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text)
            {
                return;
            }
            else
            {
                this.nowDrugPrescription = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
            }
            this.ShowPrescription();
        }

        private void fpItem1_SelectItem(object sender, EventArgs e)
        {
            //int i = this.neuSpread2_Sheet1.ActiveRowIndex;
            //Item item = sender as Item;
            //this.neuSpread2_Sheet1.Cells[i, 0].Text = item.Name;
            //this.neuSpread2_Sheet1.Cells[i, 1].Text = item.Specs;
            //this.neuSpread2_Sheet1.Cells[i, 2].Text = "1000";
            //this.neuSpread2_Sheet1.Cells[i, 3].Text = item.MinUnit;
            //this.neuSpread2_Sheet1.Rows[i].Tag = sender;
        }

        #endregion

        private void frmPPRManager_Load(object sender, EventArgs e)
        {
            string strWaitMessage = "";
            this.Init();
            this.InitDataSet();

            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm(strWaitMessage);
            Application.DoEvents();
            this.Query();
            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
        }

       
    }
}