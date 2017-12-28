using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.UFC.Order.OutPatient.Controls
{
    /// <summary>
    /// [功能描述: 草药医嘱开立]<br></br>
    /// [创 建 者: dorian]<br></br>
    /// [创建时间: 2007-10]<br></br>
    /// <修改记录
    ///  />
    /// </summary>
    public partial class ucHerbalOrder : UserControl
    {
        public ucHerbalOrder()
        {
            InitializeComponent();
        }

        public ucHerbalOrder(bool isClinic, Neusoft.HISFC.Object.Order.EnumType orderType, string deptCode)
            : this()
        {
            this.isClinic = isClinic;
            this.DeptCode = deptCode;
            this.OrderType = orderType;
            this.fpEnter1_Sheet1.Rows.Count = 0;
            this.fpEnter1_Sheet1.Rows.Add(0, 1);

            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.btnDel.Click += new EventHandler(btnDel_Click);
            this.Load += new EventHandler(ucHerbalOrder_Load);
        }

        #region 属性
        /// <summary>
        /// 是否门诊使用
        /// </summary>
        private bool isClinic = false;

        /// <summary>
        /// 是否门诊使用
        /// </summary>
        public bool IsClinic
        {
            set
            {
                this.isClinic = value;
            }
        }

        /// <summary>
        /// 医嘱类别 0 长嘱 1 临嘱
        /// </summary>
        private Neusoft.HISFC.Object.Order.EnumType orderType;

        /// <summary>
        /// 医嘱类别 0 长嘱 1 临嘱
        /// </summary>
        public Neusoft.HISFC.Object.Order.EnumType OrderType
        {
            set
            {
                this.orderType = value;
                if (this.alLong == null || this.alShort == null)
                {
                    try
                    {
                        this.DataInit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (value == Neusoft.HISFC.Object.Order.EnumType.LONG)
                {
                    this.cmbOrderType.DataSource = alLong;
                    this.cmbOrderType.DisplayMember = "Name";
                    this.cmbOrderType.ValueMember = "ID";
                    this.orderTypeHelper.ArrayObject = this.alLong;
                }
                else
                {
                    this.cmbOrderType.DataSource = alShort;
                    this.cmbOrderType.DisplayMember = "Name";
                    this.cmbOrderType.ValueMember = "ID";
                    this.orderTypeHelper.ArrayObject = this.alShort;
                }
            }
        }

        /// <summary>
        /// 开方医生科室
        /// </summary>
        private string deptCode = "";

        /// <summary>
        /// 开方医生所在科室
        /// </summary>
        public string DeptCode
        {
            set
            {
                this.deptCode = value;
            }
        }

        /// <summary>
        /// 开立后的草药医嘱信息
        /// </summary>
        ArrayList alOrder = new ArrayList();

        /// <summary>
        /// 开立后的草药医嘱信息
        /// </summary>
        public ArrayList AlOrder
        {
            get
            {
                if (this.alOrder == null)
                    this.alOrder = new ArrayList();
                return this.alOrder;
            }
        }

        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Object.RADT.PatientInfo patient = null;

        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Object.RADT.PatientInfo Patient
        {
            set
            {
                if (value == null)
                {
                    MessageBox.Show("患者信息赋值错误");
                    return;
                }
                this.patient = value;
            }
        }
        #endregion

        #region 域变量
        /// <summary>
        /// 长期医嘱类型
        /// </summary>
        ArrayList alLong = null;

        /// <summary>
        /// 临时医嘱类型
        /// </summary>
        ArrayList alShort = null;

        Neusoft.NFC.Public.ObjectHelper orderTypeHelper = new Neusoft.NFC.Public.ObjectHelper();

        /// <summary>
        /// 项目信息
        /// </summary>
        ArrayList alItem = null;

        /// <summary>
        /// 用法信息
        /// </summary>
        ArrayList alUsage = null;

        /// <summary>
        /// 本组频次
        /// </summary>
        Neusoft.NFC.Public.ObjectHelper frequencyHelper = new Neusoft.NFC.Public.ObjectHelper();

        /// <summary>
        /// 本组煎药方式
        /// </summary>
        Neusoft.HISFC.Integrate.Pharmacy itemManager = new Neusoft.HISFC.Integrate.Pharmacy();
        #endregion

        /// <summary>
        /// 数据加载初始化
        /// </summary>
        protected void DataInit()
        {
            #region 医嘱类别加载
            Neusoft.HISFC.Integrate.Manager integrateManager = new Neusoft.HISFC.Integrate.Manager();

            ArrayList alOrderType = (integrateManager.QueryOrderTypeList());//医嘱类型
            foreach (Neusoft.HISFC.Object.Order.OrderType obj in alOrderType)
            {
                if (obj.IsDecompose)
                {
                    if (alLong == null)
                        alLong = new ArrayList();
                    alLong.Add(obj);
                }
                else
                {
                    if (alShort == null)
                        alShort = new ArrayList();
                    alShort.Add(obj);
                }
            }
            #endregion

            #region 频次加载
            ArrayList List = integrateManager.QuereyFrequencyList();
            this.cmbFrequency.DataSource = List;
            this.cmbFrequency.DisplayMember = "ID";
            this.cmbFrequency.ValueMember = "ID";
            this.frequencyHelper.ArrayObject = List;
            #endregion

            #region 煎药方式
            ArrayList memoAl = new ArrayList();
            Neusoft.NFC.Object.NeuObject obj1 = new Neusoft.NFC.Object.NeuObject();
            obj1.ID = "0";
            obj1.Name = "自煎";
            memoAl.Add(obj1);
            obj1 = new Neusoft.NFC.Object.NeuObject();
            obj1.ID = "1";
            obj1.Name = "代煎";
            memoAl.Add(obj1);
            obj1 = new Neusoft.NFC.Object.NeuObject();
            obj1.ID = "2";
            obj1.Name = "复渣";
            memoAl.Add(obj1);
            obj1 = new Neusoft.NFC.Object.NeuObject();
            obj1.ID = "3";
            obj1.Name = "代复渣";
            memoAl.Add(obj1);
            this.cmbMemo.DataSource = memoAl;
            this.cmbMemo.DisplayMember = "Name";
            this.cmbMemo.ValueMember = "ID";
            #endregion

            #region 草药项目
            if (this.alItem == null)
                this.alItem = new ArrayList();
            this.alItem = this.itemManager.QueryItemAvailableList(this.deptCode, "C");
            if (this.alItem == null)
            {
                MessageBox.Show("获取草药项目列表出错！");
                return;
            }
            #endregion

            #region 用法
            this.alUsage = Neusoft.UFC.Order.Classes.Function.HelperUsage.ArrayObject;
            if (this.alUsage == null)
            {
                MessageBox.Show("获取用法列表出错!");
                return;
            }
            #endregion

            this.fpEnter1.SetWidthAndHeight(150, 100);
            this.fpEnter1.SetIDVisiable(this.fpEnter1_Sheet1, (int)ColumnSet.ColTradeName, false);
            this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, (int)ColumnSet.ColTradeName, this.alItem);

            this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, (int)ColumnSet.ColUsage, this.alUsage);

            this.fpEnter1.ShowListWhenOfFocus = true;
            this.fpEnter1.SetItem += new Neusoft.NFC.Interface.Controls.NeuFpEnter.setItem(fpEnter1_SetItem);
            this.fpEnter1.KeyEnter += new Neusoft.NFC.Interface.Controls.NeuFpEnter.keyDown(fpEnter1_KeyEnter);

            FarPoint.Win.Spread.InputMap im;

            im = this.fpEnter1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpEnter1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpEnter1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 由列表获取所选择项目
        /// </summary>
        /// <returns>成功返回1 出错返回－1</returns>
        protected int GetSelectItem()
        {
            int currentRow = this.fpEnter1_Sheet1.ActiveRowIndex;
            if (currentRow < 0) return 0;
            if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColTradeName)
            {
                //获取选中的信息
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)ColumnSet.ColTradeName);
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                if (item == null) return -1;
                this.SetSelectItem(item);
                return 0;
            }
            if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColUsage)
            {
                //获取选中的信息
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, (int)ColumnSet.ColUsage);
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                if (item == null) return -1;
                this.SetSelectItem(item);
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// 处理由列表内所选择的项目
        /// </summary>
        /// <param name="obj">由弹出列表内所选择的项目</param>
        /// <returns>成功返回1 出错返回－1</returns>
        protected int SetSelectItem(Neusoft.NFC.Object.NeuObject obj)
        {
            if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColTradeName)
            {
                Neusoft.HISFC.Object.Pharmacy.Item item = this.itemManager.GetItem(obj.ID);
                if (item == null)
                {
                    MessageBox.Show("获取药品信息失败!" + this.itemManager.Err);
                    return -1;
                }
                item.User02 = obj.User02;		//取药药房编码
                this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColTradeName].Text = obj.Name;
                this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColSpecs].Text = item.Specs;
                this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPrice].Text = item.PriceCollection.RetailPrice.ToString();
                this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColUnit].Text = item.MinUnit;
                this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColUsage].Text = item.Usage.Name;
                this.fpEnter1_Sheet1.Rows[this.fpEnter1_Sheet1.ActiveRowIndex].Tag = item;

                this.fpEnter1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColNum;
                return 1;
            }
            if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColUsage)
            {
                this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColUsage].Text = obj.Name;
                this.fpEnter1_Sheet1.Cells[this.fpEnter1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColUsage].Tag = obj;

                if (this.fpEnter1_Sheet1.ActiveRowIndex == this.fpEnter1_Sheet1.Rows.Count - 1)
                {
                    this.fpEnter1_Sheet1.Rows.Add(this.fpEnter1_Sheet1.Rows.Count, 1);
                    this.fpEnter1_Sheet1.ActiveRowIndex = this.fpEnter1_Sheet1.Rows.Count - 1;
                }
                else
                {
                    this.fpEnter1_Sheet1.ActiveRowIndex = this.fpEnter1_Sheet1.ActiveRowIndex + 1;
                }
                this.fpEnter1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColTradeName;
                return 1;
            }
            return 1;
        }
        /// <summary>
        /// 清除界面显示
        /// </summary>
        public void Clear()
        {
            this.alOrder = new ArrayList();
            this.fpEnter1_Sheet1.Rows.Count = 0;
            this.fpEnter1_Sheet1.Rows.Count = 1;
            this.txtNum.Text = "";
            this.dtEnd.Checked = false;
        }

        /// <summary>
        /// 医嘱有效性检查
        /// </summary>
        /// <returns>无错误返回1 出错返回－1</returns>
        protected int Valid()
        {
            if (this.patient == null)
            {
                MessageBox.Show("患者信息未正确赋值");
                return -1;
            }
            if (this.cmbOrderType.Text == "")
            {
                MessageBox.Show("请选择医嘱类型");
                this.cmbOrderType.Select();
                this.cmbOrderType.Focus();
                return -1;
            }
            if (this.cmbFrequency.Text == "")
            {
                MessageBox.Show("请选择本剂草药用药频次");
                this.cmbFrequency.Select();
                this.cmbFrequency.Focus();
                return -1;
            }
            if (this.txtNum.Text == "")
            {
                MessageBox.Show("请选择草药剂数");
                this.txtNum.Select();
                this.txtNum.Focus();
                return -1;
            }
            if (Neusoft.NFC.Function.NConvert.ToInt32(this.txtNum.Text) == 0)
            {
                MessageBox.Show("剂数只能为大于0得整数");
                return -1;
            }
            if (this.cmbMemo.Text == "")
            {
                MessageBox.Show("请选择本剂药得煎药方式");
                this.cmbMemo.Select();
                this.cmbMemo.Focus();
                return -1;
            }
            if (this.dtEnd.Checked)
            {
                if (Neusoft.NFC.Function.NConvert.ToDateTime(this.dtBegin.Text) >= Neusoft.NFC.Function.NConvert.ToDateTime(this.dtEnd.Text))
                {
                    MessageBox.Show("医嘱停止时间不能大于等于医嘱开始时间");
                    return -1;
                }
            }
            for (int i = 0; i < this.fpEnter1_Sheet1.Rows.Count; i++)
            {
                if (this.fpEnter1_Sheet1.Cells[i, (int)ColumnSet.ColTradeName].Text == "")
                    continue;
                if (this.fpEnter1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text == "")
                {
                    MessageBox.Show("请输入第" + (i + 1).ToString() + "行草药每剂量");
                    this.fpEnter1_Sheet1.ActiveRowIndex = i;
                    return -1;
                }
                if (this.fpEnter1_Sheet1.Cells[i, (int)ColumnSet.ColUsage].Text == "")
                {
                    MessageBox.Show("请输入第" + (i + 1).ToString() + "行草药用法");
                    this.fpEnter1_Sheet1.ActiveRowIndex = i;
                    return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// 医嘱保存
        /// </summary>
        protected int Save()
        {
            if (this.Valid() == -1)
                return -1;
            Neusoft.HISFC.Management.Order.Order orderManager = new Neusoft.HISFC.Management.Order.Order();
            Neusoft.HISFC.Object.Order.Inpatient.Order order;
            string comboID = "";
            try
            {
                comboID = orderManager.GetNewOrderComboID();//添加组合号;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取医嘱组合号出错" + ex.Message);
                return -1;
            }
            Neusoft.NFC.Object.NeuObject usageObj = null;
            for (int i = 0; i < this.fpEnter1_Sheet1.Rows.Count; i++)
            {
                order = new Neusoft.HISFC.Object.Order.Inpatient.Order();
                order.Item = this.fpEnter1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Object.Pharmacy.Item;
                if (order.Item == null)
                    continue;
                //患者信息
                order.Patient = this.patient;
                //医嘱组合号
                order.Combo.ID = comboID;
                //医嘱类型
                order.OrderType = this.orderTypeHelper.GetObjectFromID(this.cmbOrderType.SelectedValue.ToString()) as Neusoft.HISFC.Object.Order.OrderType;
                //用法
                usageObj = this.fpEnter1_Sheet1.Cells[i, (int)ColumnSet.ColUsage].Tag as Neusoft.NFC.Object.NeuObject;
                order.Usage.ID = usageObj.ID;
                order.Usage.Name = usageObj.Name;

                //剂数
                order.HerbalQty = Neusoft.NFC.Function.NConvert.ToInt32(this.txtNum.Text);
                //煎药方式
                order.Memo = this.cmbMemo.Text;
                //频次
                order.Frequency = this.frequencyHelper.GetObjectFromID(this.cmbFrequency.SelectedValue.ToString()) as Neusoft.HISFC.Object.Order.Frequency;
                //每次量
                if (this.orderType == Neusoft.HISFC.Object.Order.EnumType.LONG)
                {
                    order.DoseOnce = Neusoft.NFC.Function.NConvert.ToDecimal(this.fpEnter1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text);
                }
                else
                {
                    order.Qty = Neusoft.NFC.Function.NConvert.ToDecimal(this.fpEnter1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text);
                }
                order.BeginTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.dtBegin.Text);
                if (this.dtEnd.Checked)
                    order.EndTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.dtEnd.Text);
                //取药药房
                order.StockDept.ID = order.Item.User02;

                this.alOrder.Add(order);
            }
            return 1;
        }


        #region 事件
        private void ucHerbalOrder_Load(object sender, EventArgs e)
        {
            this.fpEnter1.Select();
            this.fpEnter1.Focus();
            this.fpEnter1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColTradeName;
        }


        private int fpEnter1_KeyEnter(Keys key)
        {
            if (key == Keys.Enter)
            {
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColTradeName)
                {
                    if (this.GetSelectItem() == -1)
                    {
                        MessageBox.Show("由列表获取所选择项目出错");
                        return -1;
                    }
                    return 1;
                }
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColNum)
                {
                    this.fpEnter1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColUsage;
                    return 1;
                }
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColUsage)
                {
                    if (this.GetSelectItem() == -1)
                    {
                        MessageBox.Show("由列表获取所选择项目出错");
                        return -1;
                    }
                }
            }
            return 0;
        }

        private int fpEnter1_SetItem(Neusoft.NFC.Object.NeuObject obj)
        {
            if (this.SetSelectItem(obj) == -1)
            {
                MessageBox.Show("处理所选择项目失败");
            }
            return 0;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Save() == 1)
            {
                if (this.ParentForm != null)
                {
                    this.ParentForm.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (this.fpEnter1_Sheet1.Rows.Count > 0)
            {
                this.fpEnter1_Sheet1.RemoveRows(this.fpEnter1_Sheet1.ActiveRowIndex, 1);
                this.fpEnter1.SetAllListBoxUnvisible();
            }
        }
        #endregion

        #region 列设置
        private enum ColumnSet
        {
            /// <summary>
            /// 药品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 价格
            /// </summary>
            ColPrice,
            /// <summary>
            /// 数量
            /// </summary>
            ColNum,
            /// <summary>
            /// 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 用法
            /// </summary>
            ColUsage
        }
        #endregion

    }
}
