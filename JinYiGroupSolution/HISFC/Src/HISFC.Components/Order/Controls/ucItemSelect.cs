using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医嘱项目选择控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucItemSelect : UserControl
    {
        public ucItemSelect()
        {
            InitializeComponent();
            
        }
        public event Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler CatagoryChanged;
        #region 初始化
        public void Init()
        {
            if (DesignMode) return;
            if (Neusoft.FrameWork.Management.Connection.Operator.ID == "") return;

            #region 设置tip
            tooltip.SetToolTip(this.ucInputItem1, "输入拼音码查询，开立医嘱(ESC取消列表)");
            tooltip.SetToolTip(this.txtDays, "输入医嘱执行天数");
            tooltip.SetToolTip(this.txtQuantity, "输入总数量(回车输入结束)");
            tooltip.SetToolTip(this.dtBegin, "输入医嘱开始执行时间");
            tooltip.SetToolTip(this.dtEnd, "输入医嘱结束执行时间");
            #endregion
            try
            {
                Neusoft.HISFC.Models.Base.Employee p = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                if (p == null) return;
                this.ucInputItem1.DeptCode = p.Dept.ID;//科室看自己科室的药品项目
                this.ucInputItem1.ShowCategory = Neusoft.HISFC.Components.Common.Controls.EnumCategoryType.SysClass;

                this.ucOrderInputByType1.ItemSelected += new ItemSelectedDelegate(ucOrderInputByType1_ItemSelected);
                this.cmbOrderType1.SelectedIndexChanged += new System.EventHandler(this.cmbOrderType1_SelectedIndexChanged);

                this.ucInputItem1.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputItem1_SelectedItem);
                this.ucInputItem1.CatagoryChanged += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputItem1_CatagoryChanged);
                this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
                this.txtQuantity.Leave += new EventHandler(txtQuantity_Leave);

                this.cmbUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnit_KeyPress);
                //this.cmbUnit.TextChanged+=new EventHandler(cmbUnit_TextChanged);    //{8670585E-EE96-47db-86FE-FA2F81EBF459}  上下键选择时不触发，改用ucInputItem1_SelectedItem代替 20100915
                this.ucOrderInputByType1.Leave += new EventHandler(ucOrderInputByType1_Leave);
                this.ucOrderInputByType1.InitControl(null, null, null);
                this.dtBegin.ValueChanged += new System.EventHandler(this.dtBegin_ValueChanged);
                this.dtEnd.ValueChanged += new EventHandler(dtEnd_ValueChanged);

                this.cmbOrderType1.DropDownStyle = ComboBoxStyle.DropDownList;
                this.ucInputItem1.Init();//初始化项目列表
            }
            catch { }
            try
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                ArrayList alOrderType = manager.QueryOrderTypeList();
                if (alOrderType == null) return;
                //医嘱类型还没用
                foreach (Neusoft.HISFC.Models.Order.OrderType obj in alOrderType)
                {
                    if (obj.IsDecompose)
                    {
                        alLong.Add(obj);
                    }
                    else
                    {

                        alShort.Add(obj);
                    }
                }
                SetLongOrShort(false);

                ArrayList alResQuality = manager.QueryConstantList("LongOrderResQuality");
                if (alResQuality != null)
                {
                    this.hsResQuality = new Hashtable();
                    foreach (Neusoft.FrameWork.Models.NeuObject info in alResQuality)
                    {
                        this.hsResQuality.Add(info.ID, null);
                    }
                }
            }
            catch { }           
            this.dtEnd.MinDate = DateTime.MinValue;
            this.dtEnd.Value = DateTime.Today.AddDays(1);
            this.dtEnd.Checked = false;
        }
        #endregion

        #region 变量
        /// <summary>
        /// 医嘱变化时候用
        /// </summary>
        public event ItemSelectedDelegate OrderChanged;//

        /// <summary>
        /// 当前操作类型
        /// </summary>
        public Operator OperatorType = Operator.Query;

        public int CurrentRow = -1; //当前行
        /// <summary>
        /// 是否显示Lis详细信息
        /// </summary>
        public bool IsLisDetail
        {
            set
            {
                this.isLisDetail = value;
            }
        }
        /// <summary>
        /// 是否进行组套编辑功能
        /// </summary>
        public bool EditGroup = false;

        protected ArrayList alLong = new ArrayList();//长期医嘱类型
        protected ArrayList alShort = new ArrayList();//临时医嘱类型        
        protected bool dirty = false;//是新的时候
        protected ToolTip tooltip = new ToolTip(); //ToolTip
        protected bool isLisDetail = false;
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyManager = null;
        protected Neusoft.HISFC.BizProcess.Integrate.Fee itemManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 长期医嘱限制性药品性质
        /// </summary>
        System.Collections.Hashtable hsResQuality = new Hashtable();

        //{7F57E64E-D49E-4b3a-9E41-AF668543ECE7}任何医嘱都可以修改开始时间 by guanyx
        //控制是否可以修改开始时间
        private bool canModifyStartTime = true;

        #endregion

        #region 属性
        /// <summary>
        /// 当前医嘱
        /// </summary>
        protected Neusoft.HISFC.Models.Order.Inpatient.Order order = null;

        /// <summary>
        /// 当前医嘱
        /// </summary>
        [DefaultValue(null)]
        public Neusoft.HISFC.Models.Order.Inpatient.Order Order
        {
            get
            {
                return this.order;
            }
            set
            {
                if (value == null) return;
                this.order = value;
                #region {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
                if (this.isNurseCreate)
                {
                    if (this.order.ReciptDoctor.ID != Neusoft.FrameWork.Management.Connection.Operator.ID)
                    {
                        MessageBox.Show("护士不允许修改他人开立的医嘱!");
                        return ;
                    }
                }
                #endregion
                dirty = false; //不是变化时候--传入时候
                
                    this.LongOrShort = (int)this.order.OrderType.Type;
                    this.ucOrderInputByType1.IsNew = false;//修改旧医嘱
                    this.ucOrderInputByType1.Order = value;

                    this.ucInputItem1.FeeItem = this.order.Item;
                    this.cmbOrderType1.Tag = this.order.OrderType.ID;
                    ReadOrder(this.order);//读进来的医嘱
                
                dirty = true;
            }
        }

        protected int longOrShort = 0;

        /// <summary>
        /// 长嘱 0 or临时医嘱 1
        /// </summary>
        public int LongOrShort
        {
            get
            {
                return longOrShort;
            }
            set
            {
                if (DesignMode) return;
                if (longOrShort == value) return;
                if (value == 0)
                {
                    this.SetLongOrShort(false);
                    
                }
                else
                {
                    this.SetLongOrShort(true);   
                }
                longOrShort = value;
            }
        }

        #region {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}

        private bool isNurseCreate = false;
        /// <summary>
        /// 是否护士开立
        /// </summary>
        [DefaultValue(false)]
        public bool IsNurseCreate
        {
            set
            {
                this.isNurseCreate = value;
            }
        }

        #endregion

        #endregion

        #region 事件
        protected bool bPermission = false;//是否知情同意书
     

        protected void ShowTotal(bool b)
        {
            this.label3.Enabled = b;
            this.txtQuantity.Enabled = b;
            this.cmbUnit.Enabled = b;
        }
        
        /// <summary>
        /// 医嘱变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="changedField"></param>
        protected virtual void ucOrderInputByType1_ItemSelected(Neusoft.HISFC.Models.Order.Inpatient.Order order, EnumOrderFieldList changedField)
        {
            dirty = true;
            //临时医嘱,出院，请假带药，药品，数量为零的项目自动计算-2005-6-1新加为了中山一
            //if (order.OrderType.IsDecompose == false 
            //    && order.Item.IsPharmacy && order.Frequency.ID != "" &&
            //    Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtDays.Text) > 0)
            
            if (order.OrderType.IsDecompose == false
                && order.Item.ItemType == EnumItemType.Drug && order.Frequency.ID != "" &&
                Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtDays.Text) > 0)
            {
                this.txtQuantity.Text = order.Qty.ToString();
                this.cmbUnit.Text = ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit;
            }
            //{49C1DF42-7050-42b1-B418-BD4A2D733E83}
            //this.dtEnd.Checked = false;
            
            this.myOrderChanged(order,changedField);
            dirty = false;
        }

        protected void myOrderChanged(object sender,EnumOrderFieldList enumOrderFieldList)
        {
            try
            {
                if (this.CurrentRow == -1)
                {
                    this.CurrentRow = 0;
                    this.OperatorType = Operator.Add;//添加
                }
                else
                {
                    this.OperatorType = Operator.Modify;
                    
                }

                #region {A3772F6F-C68D-4987-AF2F-FA1A32208488}
                //此处应该用order而不是属性Order，使用属性Order会执行一系列的代码，可能导致错误
                //this.Order = sender as Neusoft.HISFC.Models.Order.Inpatient.Order;//控件传出的对象
                this.order = sender as Neusoft.HISFC.Models.Order.Inpatient.Order;//控件传出的对象
                #region {7ED5BB10-74B0-4cfc-9D39-4C7E18E0465C}
                this.ucOrderInputByType1.IsNew = false;//修改旧医嘱
                this.ucOrderInputByType1.Order = this.order;
                #endregion
                #endregion

                this.OrderChanged(order, enumOrderFieldList);
            }
            catch { }
        }
        /// <summary>
        /// 数量变化-跳到下一级完成其它输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.order == null) return;
            if ( e==null || e.KeyChar == 13 )
            {
                if (this.order.Qty != Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtQuantity.Value))
                {
                    this.order.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtQuantity.Value);
                    myOrderChanged(this.order, EnumOrderFieldList.Qty);
                }
                if (this.cmbUnit.Enabled)
                {
                    this.cmbUnit.Focus();
                }
                else
                {
                    //if (this.order.Item.IsPharmacy == false)//非药品跳回 新加
                    if (this.order.Item.ItemType != EnumItemType.Drug)//非药品跳回 新加
                        this.ucInputItem1.Focus();
                    else
                        this.ucOrderInputByType1.Focus();
                }
            }
        }
        /// <summary>
        /// 单位keyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.order == null) return;
            if (e == null || e.KeyChar == 13)
            {
                    //if (this.order.Item.IsPharmacy == false)//非药品跳回 新加
                #region addby xuewj 2010-9-24 非药品焦点正常跳转 {1B93C17C-DB7D-44cc-98AE-2E76DB0532F6}
                //if (this.order.Item.ItemType != EnumItemType.Drug)//非药品跳回 新加
                //{
                //    if (this.order.Item.IsNeedConfirm)//{31EB54C5-C30E-4130-89F2-BBF57D6BAFF6}
                //    {
                //        this.ucOrderInputByType1.Focus();
                //    }
                //    else
                //    {
                //        this.ucInputItem1.Focus();
                //    }
                //}
                //else
                this.ucOrderInputByType1.Focus(); 
                #endregion
             
            }
        }
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (this.order == null) return;
            if (this.order.Qty == Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtQuantity.Value)) return;
            this.txtQuantity_KeyPress(sender, null);

        }

        //{7F57E64E-D49E-4b3a-9E41-AF668543ECE7}任何医嘱都可以修改开始时间 by guanyx
        /// <summary>
        /// 判断修改的开始时间的有效性（即只允许修改时间，不允许修改日期）
        /// </summary>
        /// <param name="dt"></param>
        private int CheckBeginTimeValid(DateTime dt,int i)
        {
            Neusoft.HISFC.BizLogic.Order.Order manger = new Neusoft.HISFC.BizLogic.Order.Order();
            DateTime sysdate = Convert.ToDateTime(manger.GetSysDateTime());
            if (dt.Date < sysdate.AddDays(i ).Date)
            {
                this.dtBegin.Value = sysdate;
                MessageBox.Show("开始时间无效！请不要修改的时间太长！");
                return -1;
            }
            else
            {
                return 1;
            }
        }

        private void dtBegin_ValueChanged(object sender, System.EventArgs e)
        {
            if (dirty == true)
            {
                if (this.order == null)
                {
                    return;
                }
                //{7F57E64E-D49E-4b3a-9E41-AF668543ECE7}任何医嘱都可以修改开始时间 by guanyx
                if (this.canModifyStartTime == false)
                {
                    //临时使用本地时间判断
                    //应该在此处获取系统时间 但考虑效率问题 先使用本地时间判断
                    //只有补录医嘱可以设置开立时间小于当前时间
                    //Edit By liangjz 
                    if (this.dtBegin.Value < DateTime.Now && this.order.OrderType.ID != "BL")
                    {
                        this.dtBegin.Value = this.order.BeginTime;
                        return;
                    }
                }
                int days = 0;
                if (this.order.OrderType.ID == "BL")
                {
                    days = -10;
                }
                else
                {
                    days = 0;
                }
                if (this.CheckBeginTimeValid(this.dtBegin.Value, days) == -1)
                {
                    return;
                }
                if (this.order.BeginTime != this.dtBegin.Value)
                {
                    this.dtBegin.Value = new DateTime(this.dtBegin.Value.Year, this.dtBegin.Value.Month, this.dtBegin.Value.Day, this.dtBegin.Value.Hour, this.dtBegin.Value.Minute, 0);//{8FEB04B3-0A07-4893-A5B8-829D8ADC468B}
                    this.order.BeginTime = this.dtBegin.Value;                    
                    myOrderChanged(this.order, EnumOrderFieldList.BeginDate);
                }
            }
              
        }

        private Panel PanelEnd
        {
            get
            {
                return this.panelEndDate;
            }
        }

        /// <summary>
        /// {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
        /// 过滤系统类别
        /// </summary>
        /// <param name="isShort"></param>
        /// <param name="alSysClass"></param>
        /// <returns></returns>
        private ArrayList FilterSysClassForNurse(bool isShort, ArrayList alSysClass)
        {
            System.Collections.ArrayList al = Neusoft.HISFC.Models.Base.SysClassEnumService.List();
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();
            objAll.ID = "ALL";
            objAll.Name = "全部";
            al.Add(objAll);
            
            //护士医嘱屏蔽些东西

            System.Collections.ArrayList rAl = new ArrayList();
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "MR")//非药品，转科，转床
                {

                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "UO")//手术
                {
                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "UC")//检查
                {
                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "UL")	//检验
                {
                }
                else if (obj.ID.Length >= 1 && obj.ID.Substring(0, 1) == "P")//药
                {
                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "MC")//会诊
                {
                }
                else
                {
                    rAl.Add(obj);
                }
            }
            return rAl;
        }

        /// <summary>
        /// 设置医嘱类型
        /// </summary>
        /// <param name="b"></param>
        protected void SetLongOrShort(bool isShort)
        {
            dirty = false;

            //长期医嘱停止日期
            this.PanelEnd.Visible = !isShort;
            //.
            this.panelEndDay.Visible = !isShort;

            if (isShort) //临时医嘱
            {
                this.cmbOrderType1.AddItems(alShort);
                #region {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
                if (this.isNurseCreate)
                {
                    this.ucInputItem1.AlCatagory = this.FilterSysClassForNurse(isShort, Classes.Function.OrderCatatagory(isShort));
                }
                else
                {
                    this.ucInputItem1.AlCatagory = Classes.Function.OrderCatatagory(isShort);
                }
                #endregion

            }//长期
            else
            {
                this.cmbOrderType1.AddItems(alLong);//添加长期医嘱类别
                #region {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
                if (this.isNurseCreate)
                {
                    this.ucInputItem1.AlCatagory = this.FilterSysClassForNurse(isShort, Classes.Function.OrderCatatagory(isShort));
                }
                else
                {
                    this.ucInputItem1.AlCatagory = Classes.Function.OrderCatatagory(isShort);
                }
                #endregion
            }
            try
            {
                this.cmbOrderType1.SelectedIndex = 0;
            }
            catch { }
        }
        /// <summary>
        /// 医嘱类型变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOrderType1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cmbOrderType1.SelectedIndex < 0) return;
            Neusoft.HISFC.Models.Order.OrderType obj = null;
            if (this.LongOrShort == 0) //长期医嘱
            {
                obj = this.alLong[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType;
            }
            else //临时医嘱
            {
                obj = this.alShort[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType;
                //出院带药，请假带药，可能要输入天数
            }
        
            if (obj.IsCharge == false)
            {
                this.ucInputItem1.IsCanInputName = false;
            }
            else
            {
                this.ucInputItem1.IsCanInputName = true;
            }

            this.ucInputItem1.Focus();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charge"></param>
        private void GeChargeableOrderType(bool charge)
        {
            //判断当前医嘱收费类型
            Neusoft.HISFC.Models.Order.OrderType ordertype = this.cmbOrderType1.SelectedItem as Neusoft.HISFC.Models.Order.OrderType;
            if (ordertype != null)
            {
                if (ordertype.IsCharge == charge)
                    return;
            }
            //不符合，查找第一个符合的收费类型
            foreach (Neusoft.HISFC.Models.Order.OrderType obj in this.cmbOrderType1.alItems)
            {
                if (obj.IsCharge == charge)
                {
                    this.cmbOrderType1.Tag = obj.ID;
                    return;
                }
            }
        }

        #region 废弃方法
        //{8670585E-EE96-47db-86FE-FA2F81EBF459}  上下键选择时不触发，改用ucInputItem1_SelectedItem代替 20100915
        //private void cmbUnit_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string unit = this.cmbUnit.Text.Trim();
        //        if (Neusoft.FrameWork.Public.String.ValidMaxLengh(unit, 16) == false)
        //        {
        //            MessageBox.Show("单位超长!", "提示");
        //            return;
        //        }
        //        if (this.order.Unit != unit && dirty == true)
        //        {
        //            this.order.Unit = unit;//更新单位
        //            myOrderChanged(this.order, EnumOrderFieldList.Unit);
        //        }
        //    }
        //    catch { }
        //}
        #endregion

        /// <summary>
        /// 当前选择的医嘱类型
        /// </summary>
        public Neusoft.HISFC.Models.Order.OrderType SelectedOrderType
        {
            get
            {
                return this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType;
            }
        }

        /// <summary>
        /// 开始时间变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBegin_ValueChanged_1(object sender, System.EventArgs e)
        {
            //在This.order为null时不进行判断处理 Add By liangjz 2005-08
            if (this.order == null) return;
            if (this.txtQuantity.Text == "")
                return;
            //{7F57E64E-D49E-4b3a-9E41-AF668543ECE7}任何医嘱都可以修改开始时间 by guanyx
            if (this.canModifyStartTime == false)
            {
                //****************可能需要更改的地方*************************
                //只有补录医嘱可以调整时间小于当前时间  BL 补录医嘱
                if (this.dtBegin.Value.Date < DateTime.Today.Date && this.order.OrderType.ID != "BL")
                {
                    this.dtBegin.Value = System.DateTime.Today.Date;
                    return;
                }
            }
            if (this.dtEnd.Value <= this.dtBegin.Value && this.dtEnd.Checked)
            {
                this.dtBegin.Value = this.dtEnd.Value;
                return;
            }
            try
            {
                this.order.BeginTime = this.dtBegin.Value;//开始时间
                myOrderChanged(this.order,EnumOrderFieldList.BeginDate);
            }
            catch { }
        }

        /// <summary>
        /// 停止时间变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            //在This.order为null时不进行判断处理 Add By liangjz 2005-08
            if (this.order == null) return;
            
            if (this.txtQuantity.Text == "")
                return;

            if (this.dtEnd.Value.Date <= this.dtBegin.Value.Date && this.dtEnd.Checked)
            {
                this.dtEnd.Value = this.dtBegin.Value;

                return;
            }
            try
            {
                if (this.dtEnd.Checked == false)
                {
                    this.order.EndTime = System.DateTime.MinValue;
                }
                else
                {
                    this.order.EndTime = this.dtEnd.Value;//停止时间
                }
                dirty = true;
                myOrderChanged(this.order,EnumOrderFieldList.EndDate);
                dirty = false;
            }
            catch { }
        }
        /// <summary>
        /// 乘以日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDays_TextChanged(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (this.txtDays.Text == "" || int.Parse(this.txtDays.Text) < 1) return;
            //    if (this.SelectedOrderType.IsDecompose == true)
            //    {
            //        this.dtEnd.Value = this.dtBegin.Value.AddDays(int.Parse(this.txtDays.Text));
            //    }
            //    else
            //    {
            //        //临时医嘱,出院，请假带药，药品，数量为零的项目自动计算-2005-6-1新加为了中山一
            //        if (order.OrderType.IsDecompose == false && (order.OrderType.ID == "CD" || order.OrderType.ID == "QL")
            //            && order.Item.isPharmacy && order.Frequency.ID != "" &&
            //            Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtDays.Text) > 0)//&& this.txtQuantity.Enabled==false
            //        {
            //            Neusoft.HISFC.Models.Pharmacy.Item item = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
            //            #region 获得时间点
            //            if (order.Frequency.Usage.ID == "") order.Frequency.Usage = order.Usage.Clone();
            //            string DeptCode = order.ReciptDept.ID;//开单科室
            //            Neusoft.HISFC.BizLogic.Manager.Frequency frequencyManagement = new Neusoft.HISFC.BizLogic.Manager.Frequency();
            //            order.Frequency = (Neusoft.HISFC.Models.Order.Frequency)frequencyManagement.Get(order.Frequency, DeptCode);//获得时间点
            //            if (order.Frequency == null)
            //            {
            //                MessageBox.Show(frequencyManagement.Err);
            //                return;
            //            }
            //            Neusoft.HISFC.Models.Order.Frequency f = frequencyManagement.GetDfqspecial(order.ID, order.Combo.ID);
            //            if (f != null) order.Frequency = f.Clone();
            //            int days = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtDays.Text);
            //            if (days == 0) days = 1;
            //            #endregion
            //            if (item.OnceDose == 0M)//一次剂量为零，默认显示基本剂量
            //                order.Qty = item.BaseDose / item.BaseDose * order.Frequency.Times.Length * days;
            //            else
            //                order.Qty = item.OnceDose / item.BaseDose * order.Frequency.Times.Length * days;

            //            this.txtQuantity.Text = order.Qty.ToString();
            //            this.cmbUnit.Text = item.MinUnit;
            //        }

            //    }
            //}
            //catch { }
        }
        private void dtEnd_CloseUp(object sender, System.EventArgs e)
        {
            if (this.dtEnd.Value.Date <= this.dtBegin.Value.Date && this.dtEnd.Checked)
            {
                MessageBox.Show("医嘱终止时间不能小于起始时间，请更改", "提示");
            }

        }

        void ucInputItem1_CatagoryChanged(Neusoft.FrameWork.Models.NeuObject sender)
        {
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = sender;
                if (obj.ID.Length > 0 && obj.ID.Substring(0, 1) == "M")
                {
                    GeChargeableOrderType(false);
                }
                else
                {
                    GeChargeableOrderType(true);
                }
            }
            catch { }
            if (CatagoryChanged != null) CatagoryChanged(sender);
        }

        void ucOrderInputByType1_Leave(object sender, EventArgs e)
        {
            this.ucInputItem1.Focus();
        }

        void ucInputItem1_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {

            if (this.ucInputItem1.FeeItem == null) return;
            if (!this.EditGroup)		//当实现对组套修改功能时 不需对知情同意情况进行判断
            {
                //判断当前输入的项目是否知情同意书
                this.bPermission = Classes.Function.IsPermission(this.patientInfo,
                    (Neusoft.HISFC.Models.Order.OrderType)this.cmbOrderType1.SelectedItem,
                    (Neusoft.HISFC.Models.Base.Item)this.ucInputItem1.FeeItem);
            }

            if (this.order != null && this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Base.Item == this.order.Item) //不重复
            {
                this.txtQuantity.Focus();
                return;
            }

            //项目变化-指向新行
            this.CurrentRow = -1;

            this.OperatorType = Operator.Add;

            //设置新医嘱
            this.SetOrder();

            //数量变化
            if (this.txtQuantity.Enabled)
            {
                this.txtQuantity.Focus();

            }
            else
            {
                this.ucOrderInputByType1.Focus();
            }

        }
        #endregion

        #region 函数
        /// <summary>
        /// 读取医嘱信息-控制控件显示状态
        /// </summary>
        /// <param name="myOrder"></param>
        protected int ReadOrder(Neusoft.HISFC.Models.Order.Order myOrder)
        {
            if (myOrder == null) return 0;
            
            //项目
            if (myOrder.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))//药品
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = ((Neusoft.HISFC.Models.Pharmacy.Item)myOrder.Item);

                if (this.LongOrShort == 0) //长期医嘱，不显示总量
                {
                    this.ShowTotal(false);
                }
                else
                {
                    //药品 临时医嘱，频次为空，默认为需要时候服用prn
                    if (myOrder.Frequency.ID == null || myOrder.Frequency.ID == "")
                        myOrder.Frequency.ID = "PRN";//临时医嘱默认为需要时执行

                    this.ShowTotal(true);
                }

                this.txtQuantity.Text = myOrder.Qty.ToString(); //总量
                this.cmbUnit.Items.Clear();

                if (myOrder.Item.ID != "999") //自定义药品
                {
                    if (item.PackQty == 0)//检查包装数量
                    {
                        MessageBox.Show("该药品的包装数量为零！");
                        return -1;
                    }
                    if (item.BaseDose == 0)//检查基本剂量
                    {
                        MessageBox.Show("该药品的基本剂量为零！");
                        return -1;
                    }
                    if (item.DosageForm.ID == "")//检查剂型
                    {
                        MessageBox.Show("该药品的剂型为空！");
                        return -1;
                    }
                }
                //单位
                if ((myOrder.Item as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit != "" && (myOrder.Item as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit != null)//包装单位不为空
                {
                    try
                    {
                        //{8670585E-EE96-47db-86FE-FA2F81EBF459} 可修改包装单位还是最小单位，按一定规则控制单位显示 20100915
                        //#region 屏蔽包装单位显示 只显示最小单位 无法修改单位
                        //this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).MinUnit);//单位
                        //this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit);//单位
                        //this.cmbUnit.Enabled = false;  
                        //#endregion
                        //此处控制包装单位，最小单位如何显示
                        //如有必要可丰富判断条件
                        if (myOrder is Neusoft.HISFC.Models.Order.Inpatient.Order)
                        {
                            if (item.SysClass.ID.ToString() == "PCZ")
                            {//中成药,只显示包装单位，并且不可选择
                                this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit);//单位
                                this.cmbUnit.Enabled = false;
                            }
                            if (item.SysClass.ID.ToString() == "PCC")
                            {//中草药默认最小单位
                                this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).MinUnit);//单位
                                this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit);//单位
                                this.cmbUnit.Enabled = true;
                            }
                            else
                            {//其他默认包装单位
                                this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit);//单位
                                this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).MinUnit);//单位
                                this.cmbUnit.Enabled = true;
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    if (myOrder.Unit == null || myOrder.Unit == "")
                    {

                    }
                    else
                    {
                        this.cmbUnit.Items.Add(myOrder.Unit);
                    }
                }
                if (myOrder.Item.ID == "999")
                {
                    this.cmbUnit.DropDownStyle = ComboBoxStyle.DropDown;//可以更改
                    this.cmbUnit.Enabled = this.txtQuantity.Enabled;
                }
                else
                {
                    this.cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;//只能选择
                    //{8670585E-EE96-47db-86FE-FA2F81EBF459} 可修改包装单位还是最小单位，按一定规则控制单位显示 20100915
                    //this.cmbUnit.Enabled = false; 
                }

                if (myOrder.StockDept.ID == null || myOrder.StockDept.ID == "")
                {
                    myOrder.StockDept.ID = item.User02; //扣库科室,可能要变需要注意
                    myOrder.StockDept.Name = item.User03;//扣库科室
                }

                if (myOrder.Unit == null || myOrder.Unit.Trim() == "")
                {
                    if (this.cmbUnit.Items.Count > 0)
                    {
                        this.cmbUnit.SelectedIndex = 0;
                        myOrder.Unit = this.cmbUnit.Text;
                    }
                }
                else
                {
                    this.cmbUnit.Text = myOrder.Unit;
                }

                //结束时间
                if (this.order.BeginTime >= this.dtBegin.MinDate)
                    this.dtBegin.Value = this.order.BeginTime;

                if (this.order.EndTime <= this.dtEnd.MaxDate)
                {
                    if (this.order.EndTime == DateTime.MinValue) //最小日期不设置结束日期
                        this.dtEnd.Checked = false;
                    else
                    {
                        this.dtEnd.Checked = true;//非最小日期，设置结束日期
                        this.dtEnd.Value = this.order.EndTime;
                    }
                }

            }
            else if (myOrder.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))//非药品
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug item = ((Neusoft.HISFC.Models.Fee.Item.Undrug)myOrder.Item);

                //如果执行科室为空--付给本科科室
                if (myOrder.ExeDept.ID == "")
                {
                    if (item.ExecDept == "")
                    {
                        myOrder.ExeDept = myOrder.Patient.PVisit.PatientLocation.Dept.Clone();////执行科室?????可能需要修改
                    }
                    else if (item.ExecDepts != null && item.ExecDepts.Count > 0)
                    {
                        try
                        {
                            myOrder.ExeDept.ID = ((Neusoft.HISFC.Models.Fee.Item.Undrug)myOrder.Item).ExecDepts[0].ToString();
                        }
                        catch { }
                    }
                }
                if (myOrder.CheckPartRecord == "" && myOrder.Item.SysClass.ID.ToString() == "UC") //检查检体部位
                {
                    myOrder.CheckPartRecord = item.CheckBody;
                }
                if (myOrder.Sample.Name == "" && myOrder.Item.SysClass.ID.ToString() == "UL") //检查检体部位
                {
                    myOrder.Sample.Name = item.CheckBody;
                }
                if (myOrder.Frequency.ID == "") myOrder.Frequency.ID = "QD";//临时医嘱默认QD

                this.ShowTotal(true);

                this.cmbUnit.Items.Clear();

                if (myOrder.Unit == null || myOrder.Unit.Trim() == "")
                {
                    string unit = ((Neusoft.HISFC.Models.Fee.Item.Undrug)myOrder.Item).PriceUnit;
                    if (unit == null || unit == "") unit = "次";
                    this.cmbUnit.Items.Add(unit);
                    if (this.cmbUnit.Items.Count > 0)
                    {
                        this.cmbUnit.SelectedIndex = 0;
                        myOrder.Unit = this.cmbUnit.Text;
                    }
                }
                else
                {
                    this.cmbUnit.Items.Add(myOrder.Unit);
                    this.cmbUnit.Text = myOrder.Unit;
                }
                if (myOrder.Qty == 0)
                {
                    this.txtQuantity.Text = "1.00"; //总量
                    myOrder.Qty = 1;
                }
                else
                {
                    this.txtQuantity.Text = myOrder.Qty.ToString();
                }
               
                //结束时间
                if (this.order.BeginTime >= this.dtBegin.MinDate)
                    this.dtBegin.Value = this.order.BeginTime;

                if (this.order.EndTime == DateTime.MinValue) //最小日期不设置结束日期
                    this.dtEnd.Checked = false;
                else
                {
                    this.dtEnd.Checked = true;//非最小日期，设置结束日期
                    this.dtEnd.Value = this.order.EndTime;
                }
              
            }
            else
            {
                MessageBox.Show("无法识别的类型！");
                return -1;
            }

            
            return 0;

        }

        protected Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set
            {
                //{112B7DB5-0462-4432-AD9D-17A7912FFDBE} 
                bool isRefresh = false;
                //{CE481BFE-9211-48eb-8921-50D04858CB39} 增加value != null的判断 Added by Gengxl
                if (value != null && this.patientInfo != null && this.patientInfo.ID != value.ID)
                {
                    isRefresh = true;
                }
                this.patientInfo = value;
                //{112B7DB5-0462-4432-AD9D-17A7912FFDBE}  患者信息
                this.ucInputItem1.Patient = value;

                if (isRefresh)
                {
                    if (this.patientInfo.Pact.PayKind.ID == "02")
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在刷新医保项目类别标记..");
                        Application.DoEvents();

                        this.ucInputItem1.RefreshSIFlag();

                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    }
                }
            }
        }

        /// <summary>
        /// 设置新医嘱
        /// </summary>
        protected void SetOrder()
        {
            if (this.DesignMode) return;
            //定义个新医嘱对象
            this.order = new Neusoft.HISFC.Models.Order.Inpatient.Order();//重新设置医嘱

            dirty = false;
            try
            {
                if (this.ucInputItem1.FeeItem.ID == "999")//自己录的项目
                {
                    this.order.Item = this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Base.Item;
                }
                else
                {
                    //药品
                    if (this.ucInputItem1.FeeItem.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                    {
                        if (pharmacyManager == null) pharmacyManager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
                        this.order.Item = pharmacyManager.GetItem(this.ucInputItem1.FeeItem.ID);
                        this.order.Item.User01 = this.ucInputItem1.FeeItem.User01;
                        this.order.Item.User02 = this.ucInputItem1.FeeItem.User02;//传递取药药房
                        this.order.Item.User03 = this.ucInputItem1.FeeItem.User03;
                    }
                    else//非药品
                    {
                        try
                        {
                            Neusoft.HISFC.Models.Fee.Item.Undrug itemTemp = null;
                            itemTemp = itemManager.GetItem(this.ucInputItem1.FeeItem.ID);                          

                            this.order.Item = itemTemp;

                            //执行科室赋值 开立项目同时赋值执行科室 
                            //----Edit By liangjz 07-03  {72CEDD06-8C9F-4799-8309-0A55D9567F60}
                            if (itemTemp.ExecDept != null && itemTemp.ExecDept != "")
                            {
                                this.order.ExeDept.ID = itemTemp.ExecDept;
                            }
                            else
                            {
                                this.order.ExeDept = this.order.Patient.PVisit.PatientLocation.Dept.Clone();
                            }
                            //-----

                            //检查要求是否为空 暂时由此判断该项目为检查还是检验		
                            if (itemTemp.SysClass.ID.ToString() == "UL")
                            {
                                //设置复合项目明细所属大项编码、样本类型
                                this.order.Sample.Name = itemTemp.CheckBody;
                            }
                            else
                                this.order.CheckPartRecord = itemTemp.CheckBody;

                        }
                        catch { MessageBox.Show("转换出错!", "ucItemSelect"); }
                    }
                    //传递知情同意书
                    this.order.IsPermission = bPermission;
                }
            }
            catch { return; }
            
            //显示给界面
            if (ReadOrder(this.order) == -1) return;
            
            //设置医嘱开立时间
            Neusoft.FrameWork.Management.DataBaseManger manager = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime dtNow = manager.GetDateTimeFromSysDateTime();
            if (Classes.Function.IsDefaultMoDate == false)
            {
                if (dtNow.Hour >= 12)
                    this.dtBegin.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);
                else
                    this.dtBegin.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

                if (Classes.Function.MoDateDays > 0)
                {
                    this.dtBegin.Value = new DateTime(dtNow.Year, dtNow.Month, dtNow.AddDays(Classes.Function.MoDateDays).Day, 0, 0, 2);
                }
            }
            else
            {
                this.dtBegin.Value = dtNow;
            }


            try//设置停止时间
            {
                if (this.PanelEnd.Visible)//{A25B1E70-1EA9-40fd-BB6C-050DE67AD4EF} 临时医嘱不需要显示停止时间
                {
                    this.dtEnd.Value = DateTime.Today.AddDays(1);
                    this.dtEnd.Checked = false;
                }
            }
            catch { }

            this.order.MOTime = dtNow;//开立时间
            this.order.BeginTime = this.dtBegin.Value;//开始时间
            this.order.Item.PriceUnit = this.cmbUnit.Text;
            this.order.Unit = this.cmbUnit.Text;

            this.order.ReciptDept = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.Clone();//开立科室
            this.order.Oper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;//录入人
            this.order.Oper.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
            try
            {
                //*****************需要更改，判断医嘱类型，自动变化*****************
                ////如果不收费，改变医嘱类型为嘱托(复合项目除外)
                //if (this.order.Item.Price == 0 && (this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType).IsCharge
                //    && this.order.Item.PriceUnit != "[复合项]")
                //{
                //    GeChargeableOrderType(false);
                //}
                //else
                //{
                //}
                ////如项目为手术 更改医嘱类型为术前临嘱  Edit By liangjz 2005-10 中山一院需求 便于打印术前医嘱执行单
                //if (this.order.Item.SysClass.ID.ToString() == "UO" && (this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.FrameWork.Models.NeuObject).ID.ToString() != "SQ")
                //{	//SQ 术前临嘱 SZ 术前嘱托
                //    this.cmbOrderType1.Tag = "SQ";
                //}
            }
            catch { }
            //医嘱类型
            this.order.OrderType = this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType;

            if (this.order.OrderType.ID == "CZ")        //长期医嘱
            {
                if (this.order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                {                    
                    string drugQuality = ((Neusoft.HISFC.Models.Pharmacy.Item)this.order.Item).Quality.ID;
                    if (this.hsResQuality.ContainsKey(drugQuality))
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.order.Item.Name + " 该性质药品不允许开立长期医嘱"),"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            
            if (this.txtQuantity.Enabled) this.txtQuantity.Focus();//focus
            else this.ucOrderInputByType1.Focus();
            if (this.cmbUnit.Items.Count > 0) this.cmbUnit.SelectedIndex = 0;//默认选择第一个。
            this.ucOrderInputByType1.IsNew = true;//新的
            
            //初始化新项目信息 设置医嘱频次
            Classes.Function.SetDefaultOrderFrequency(this.order);
            if (this.order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
            {
                this.order.Usage.ID = (this.order.Item as Neusoft.HISFC.Models.Pharmacy.Item).Usage.ID;
                this.order.Usage.Name = Classes.Function.HelperUsage.GetName(this.order.Usage.ID);
            }
        
            this.ucOrderInputByType1.Order = this.order;//传递给选择类型
            dirty = true;
            myOrderChanged(this.order,EnumOrderFieldList.Item);
          
        
        }
        #endregion

        #region  清屏、医嘱类型修改函数 
        /// <summary>
        /// 清空医嘱显示
        /// </summary>
        public void Clear()
        {
            try
            {
                this.order = null;
                #region
                //进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
                //this.ucInputItem1.txtItemCode.Text = "";			//项目编码
                //this.ucInputItem1.txtItemName.Text = "";			//项目名称
                this.ucInputItem1.Clear();
                this.ucInputItem1.ItemListVisible = false;
                #endregion
                this.txtQuantity.Text = "";					//总量
                this.dtEnd.Checked = false;
                this.cmbUnit.Items.Clear();
                this.ucOrderInputByType1.Clear();

              
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
            this.txtQuantity.Select(0, this.txtQuantity.Value.ToString().Length);
        }

        private void dtEnd_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string unit = this.cmbUnit.Text.Trim();
                if (Neusoft.FrameWork.Public.String.ValidMaxLengh(unit, 16) == false)
                {
                    MessageBox.Show("单位超长!", "提示");
                    return;
                }
                if (this.order.Unit != unit && dirty == true)
                {
                    this.order.Unit = unit;//更新单位
                    myOrderChanged(this.order, EnumOrderFieldList.Unit);
                }
            }
            catch { }
        }

        #region addby xuewj 2010-10-3 医嘱类型焦点跳转 {9128C28D-DF9E-4494-ABAB-BC0F87A3C120}
        private void cmbOrderType1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e == null || e.KeyChar == 13)
            {
                this.ucInputItem1.Focus();
            }
        } 
        #endregion

        private void dtBegin_ValueChanged_2(object sender, EventArgs e)
        {

        }
        ///// <summary>
        ///// 选择医嘱类型第一项
        ///// </summary>
        //public void ResetOrderType()
        //{
        //    this.cmbOrderType1.SelectedIndex = 0;
        //}
        ///// <summary>
        ///// 更改医嘱类型 Add By liangjz 2005-08
        ///// </summary>
        //public void SetOrderType()
        //{
        //    bool isFind = false;
        //    if (this.LongOrShort == 0)		//如为长嘱直接显示全部频次，不需判断
        //        this.ucOrderInputByType1.SetFrequency(false);
        //    else							//如临嘱则根据类型显示不同频次
        //    {
        //        switch ((this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType).ID)
        //        {
        //            case "LZ":	//临时医嘱
        //            case "ZL":	//嘱托医嘱
        //            case "BL":	//补录医嘱
        //            case "SQ":	//术前嘱托
        //            case "SZ":	//术前医嘱
        //                this.ucOrderInputByType1.SetFrequency(true);
        //                break;
        //            default:
        //                this.ucOrderInputByType1.SetFrequency(false);
        //                break;
        //        }
        //    }

        //    if (this.order == null)
        //    {
        //        return;
        //    }
        //    if (this.LongOrShort == 0)		//长嘱
        //    {
        //        for (int i = 0; i < this.alLong.Count; i++)
        //        {
        //            if (this.order.OrderType.ID == (this.alLong[i] as Neusoft.HISFC.Models.Order.OrderType).ID)
        //            {
        //                isFind = true;
        //                break;
        //            }
        //        }
        //    }
        //    else if (this.LongOrShort == 1)		//临嘱
        //    {
        //        for (int i = 0; i < this.alShort.Count; i++)
        //        {
        //            if (this.order.OrderType.ID == (this.alShort[i] as Neusoft.HISFC.Models.Order.OrderType).ID)
        //            {
        //                isFind = true;
        //                break;
        //            }
        //        }
        //    }

        //    if (!isFind)
        //        return;

        //    if ((this.order != null && this.order.Status == 0) || (this.order != null && this.order.ID == ""))		//非审核、停止医嘱
        //    {
        //        this.order.OrderType = this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType;
        //        try
        //        {
        //            //如果不收费，改变医嘱类型为嘱托(复合项目除外)
        //            if (this.order.Item.Price == 0 && (this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType).IsCharge
        //                && this.order.Item.PriceUnit != "[复合项]")
        //            {
        //                GeChargeableOrderType(false);
        //            }
        //            else
        //            {
        //            }
        //        }
        //        catch { }
        //        myOrderChanged(this.Order);
        //    }

        //}
        #endregion
      
    }

    /// <summary>
    /// 医嘱操作
    /// </summary>
    public enum Operator
    { Add, Modify, Delete, Query }
}
