using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    public partial class ucOutPatientItemSelect : UserControl
    {
        public ucOutPatientItemSelect()
        {
            InitializeComponent();
        }

        #region 初始化
        public void Init()
        {
            if (DesignMode) return;
            if (Neusoft.FrameWork.Management.Connection.Operator.ID == "") return;
            #region 设置tip
            tooltip.SetToolTip(this.ucInputItem1, "输入拼音码查询，开立医嘱(ESC取消列表)");
            tooltip.SetToolTip(this.txtQTY, "输入总数量(回车输入结束)");
            #endregion
            try
            {
                //this.ucInputItem1.DeptCode = "";//科室看到全部项目
                this.ucInputItem1.DeptCode = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                this.ucInputItem1.ShowCategory = Neusoft.HISFC.Components.Common.Controls.EnumCategoryType.SysClass;
                
                this.ucOrderInputByType1.ItemSelected += new ItemSelectedDelegate(ucOrderInputByType1_ItemSelected);

                this.ucInputItem1.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputItem1_SelectedItem);
                this.ucInputItem1.CatagoryChanged += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputItem1_CatagoryChanged);

                this.txtQTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQTY_KeyPress);
                this.txtQTY.Leave += new EventHandler(txtQTY_Leave);

                this.ucOrderInputByType1.Leave += new EventHandler(ucOrderInputByType1_Leave);
                this.ucOrderInputByType1.InitControl(null, null, null);

                this.cmbUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnit_KeyPress);
                this.cmbUnit.TextChanged += new EventHandler(cmbUnit_TextChanged);
                this.ucInputItem1.UndrugApplicabilityarea = Neusoft.HISFC.Components.Common.Controls.EnumUndrugApplicabilityarea.Clinic;
                this.ucInputItem1.Init();//初始化项目列表
                
                this.ucInputItem1.AlCatagory = this.OrderCatatagory();
            }
            catch { }
            
            this.pValue = this.controlManager.QueryControlerInfo("200004");
        }
        #endregion

        #region 变量
        protected ToolTip tooltip = new ToolTip(); //ToolTip
        protected bool dirty = false;//是新的时候
        public int CurrentRow = -1; //当前行
        public bool EditGroup = false;// 是否进行组套编辑功能
        protected bool isLisDetail = false;
        protected bool bPermission = false;//是否知情同意书
        protected string pValue = "0";//是否可以开立描述医嘱
        /// <summary>
        /// 医嘱变化时候用
        /// </summary>
        public event ItemSelectedDelegate OrderChanged;
        /// <summary>
        /// 当前操作类型
        /// </summary>
        public Operator OperatorType = Operator.Query;

        public event Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler CatagoryChanged;
        /// <summary>
        /// 药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyManager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        /// <summary>
        /// 非药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee itemManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.FrameWork.Management.ControlParam controlManager = new Neusoft.FrameWork.Management.ControlParam();

        /// <summary>
        /// {24BDD373-4F2C-4899-88A7-FE2E8386F7CF}
        /// </summary>
        public string isDrugListFlag = string.Empty;
        
        #endregion

        #region 属性

        protected Neusoft.HISFC.Models.Order.OutPatient.Order order;
        /// <summary>
        /// 医嘱
        /// </summary>
        public Neusoft.HISFC.Models.Order.OutPatient.Order currOrder
        {
            get
            {
                return this.order;
            }
            set
            {
                if (value == null) return;
                this.order = value;
                dirty = false; //不是变化时候--传入时候
                
                    this.ucOrderInputByType1.IsNew = false;//修改旧医嘱
                    this.ucOrderInputByType1.Order = value;

                    this.ucInputItem1.FeeItem = this.order.Item;

                    ReadOrder(this.order);//读进来的医嘱
                    dirty = true;

            }
                
        }

        protected Neusoft.HISFC.Models.Registration.Register patientInfo = null;
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            set
            {
                this.patientInfo = value;
            }
        }

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

        #endregion
        
        #region 函数

        private ArrayList OrderCatatagory()
        {
            System.Collections.ArrayList al = Neusoft.HISFC.Models.Base.SysClassEnumService.List();
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();
            objAll.ID = "ALL";
            objAll.Name = "全部";
            al.Add(objAll);
            //屏蔽些东西

            System.Collections.ArrayList rAl = new ArrayList();
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "MR")//非药品，转科，转床
                {

                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "MF")//膳食
                {
                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "UN")//护理级别
                {
                }
                else if (obj.ID.Length > 1 && obj.ID.Substring(0, 2) == "UJ")	//计量
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
        /// 清空医嘱显示
        /// </summary>
        public void Clear()
        {
            try
            {
                this.order = null;
                this.ucInputItem1.txtItemCode.Text = "";			//项目编码
                this.ucInputItem1.txtItemName.Text = "";			//项目名称
                this.txtQTY.Text = "";					//总量

                this.cmbUnit.Items.Clear();
                this.ucOrderInputByType1.Clear();
            }
            
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// 读取医嘱信息-控制控件显示状态
        /// </summary>
        /// <param name="myOrder"></param>
        public virtual int ReadOrder(Neusoft.HISFC.Models.Order.Order myOrder)
        {
            if (myOrder == null) return 0;
            //项目
            if (myOrder.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))//药品
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = ((Neusoft.HISFC.Models.Pharmacy.Item)myOrder.Item);
                if (myOrder.Frequency.ID == null || myOrder.Frequency.ID == "")
                    myOrder.Frequency.ID = "PRN";//门诊医嘱默认为需要时执行
                
                this.txtQTY.Text = myOrder.Qty.ToString(); //总量
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
                        
                        this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).MinUnit);//min单位
                        this.cmbUnit.Items.Add((this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Pharmacy.Item).PackUnit);//pack单位

                        this.cmbUnit.Enabled = true;
                        
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
                    this.cmbUnit.Enabled = this.txtQTY.Enabled;
                }
                else
                {
                    this.cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;//只能选择
                    this.cmbUnit.Enabled = true;
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
                        #region 包装单位显示 --donggq----{BC5E1C12-B63E-4efb-BA52-2BF30AA5FFF4}

                        if (this.cmbUnit.Items.Count > 1)
                        {
                            this.cmbUnit.SelectedIndex = 1;  myOrder.NurseStation.User03 = "0";
                        }
                        else 
                        {
                            this.cmbUnit.SelectedIndex = 0;  myOrder.NurseStation.User03 = "1";
                        }
                        
                        #endregion

                        myOrder.Unit = this.cmbUnit.Text;
                    }
                }
                else
                {
                    this.cmbUnit.Text = myOrder.Unit;
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
                if (myOrder.Frequency.ID == null || myOrder.Frequency.ID == "")
                    myOrder.Frequency.ID = "QD";//门诊医嘱默认QD

                //this.ShowTotal(true);

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
                    this.txtQTY.ValueChanged -= new System.EventHandler(this.txtQTY_ValueChanged);
                    this.txtQTY.Text = "1.00"; //总量
                    this.txtQTY.ValueChanged += new System.EventHandler(this.txtQTY_ValueChanged);
                    myOrder.Qty = 1;
                }
                else
                {
                    this.txtQTY.Text = myOrder.Qty.ToString();
                }
            }
            else
            {
                MessageBox.Show("无法识别的类型！");
                return -1;
            }


            return 0;

        }

        /// <summary>
        /// 设置新医嘱
        /// </summary>
        public virtual void SetOrder()
        {
            if (this.DesignMode) return;
            //定义个新医嘱对象
            this.order = new Neusoft.HISFC.Models.Order.OutPatient.Order();//重新设置医嘱
            
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
                            if (((Neusoft.HISFC.Models.Base.Item)this.ucInputItem1.FeeItem).PriceUnit != "[复合项]")
                            {
                                Neusoft.HISFC.Models.Fee.Item.Undrug itemTemp = null;
                                itemTemp = itemManager.GetItem(this.ucInputItem1.FeeItem.ID);

                                this.order.Item = itemTemp;

                                //执行科室赋值 开立项目同时赋值执行科室 
                                //----Edit By liangjz 07-03
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
                                    //设置复合项目明细所属大项编码、样本类型/检查部位
                                    this.order.Sample.Name = itemTemp.CheckBody;
                                }
                                else
                                    this.order.CheckPartRecord = itemTemp.CheckBody;
                            }
                            else
                            {
                                Neusoft.HISFC.Models.Fee.Item.Undrug itemTemp = null;
                                itemTemp = (Neusoft.HISFC.Models.Fee.Item.Undrug)this.ucInputItem1.FeeItem;
                                this.order.Item = itemTemp;
                                //检查要求是否为空 暂时由此判断该项目为检查还是检验		
                                if (itemTemp.SysClass.ID.ToString() == "UL")
                                {
                                    //设置复合项目明细所属大项编码、样本类型/检查部位
                                    this.order.Sample.Name = itemTemp.CheckBody;
                                }
                                else
                                    this.order.CheckPartRecord = itemTemp.CheckBody;
                                this.order.Item.MinFee.ID = "fh";
                            }
                        }
                        catch { MessageBox.Show("转换出错!", "ucItemSelect"); }
                    }
                    
                }
            }
            catch { return; }


            //显示给界面
            if (ReadOrder(this.order) == -1) return;

            //设置医嘱开立时间
            Neusoft.FrameWork.Management.DataBaseManger manager = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime dtNow = manager.GetDateTimeFromSysDateTime();
                                    
            this.order.MOTime = dtNow;//开立时间
            this.order.BeginTime = dtNow;//开始时间
            this.order.Item.PriceUnit = this.cmbUnit.Text;
            this.order.Unit = this.cmbUnit.Text;

            this.order.ReciptDept = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.Clone();//开立科室
            this.order.Oper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;//录入人
            this.order.Oper.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
            
            //医嘱类型
            //this.order.OrderType = this.cmbOrderType1.alItems[this.cmbOrderType1.SelectedIndex] as Neusoft.HISFC.Models.Order.OrderType;


            if (this.txtQTY.Enabled)
            {
                this.txtQTY.Focus();//focus
                this.txtQTY.Select(0, this.txtQTY.Value.ToString().Length);
            }
            else
            {
                this.ucOrderInputByType1.Focus();
            }
            if (this.cmbUnit.Items.Count > 0) this.cmbUnit.SelectedIndex = 0;//默认选择第一个。
            this.ucOrderInputByType1.IsNew = true;//新的

            //初始化新项目信息 设置医嘱频次用法
            
            if (this.order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
            {
                //this.order.Frequency.ID = "PRN";
                this.order.Usage.ID = (this.order.Item as Neusoft.HISFC.Models.Pharmacy.Item).Usage.ID;
                this.order.Usage.Name = Order.Classes.Function.HelperUsage.GetName(this.order.Usage.ID);
            }
            else
            {
                //this.order.Frequency.ID = "QD";
            }

            if (this.order.HerbalQty == 0) this.order.HerbalQty = 1;//更新草药付数

            this.ucOrderInputByType1.Order = this.order;//传递给选择类型
            dirty = true;
            this.myOrderChanged(this.order, EnumOrderFieldList.Item);

        }

        protected void myOrderChanged(object sender, EnumOrderFieldList enumOrderFieldList)
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

                this.currOrder = sender as Neusoft.HISFC.Models.Order.OutPatient.Order;//控件传出的对象

                this.OrderChanged(order, enumOrderFieldList);
            }
            catch { }
        }

        /// <summary>
        /// 处理组套医嘱（拆分）
        /// </summary>
        private void DealGroupOrder(Neusoft.FrameWork.Models.NeuObject group)
        {
            if (group == null || group.ID.Length <= 0)
            {
                return;
            }
            ArrayList alGroupDetail = null;
            
            try
            {
                ////alGroupDetail = this.groupManager.GetComGroupTailByGroupID(group.ID);
            }
            catch
            {
                MessageBox.Show("获得组套明细信息出错！");
                return;
            }
            if (alGroupDetail == null || alGroupDetail.Count <= 0)
            {
                return;
            }
            ////OutPatient.frmGroupDetail frm = new frmGroupDetail();

            ////frm.alGroupDel = alGroupDetail;
            ////frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ////frm.ShowDialog();
            ////if (frm.alOrderItem.Count <= 0)
            ////{
            ////    return;
            ////}
            ////for (int i = 0; i < frm.alOrderItem.Count; i++)
            ////{
            ////    this.ucItem1.FeeItem = (neusoft.neHISFC.Components.Object.neuObject)frm.alOrderItem[i];
            ////    this.CurrentRow = -1;
            ////    this.SetOrder();
            ////}
        }

        protected virtual void ucOrderInputByType1_ItemSelected(Neusoft.HISFC.Models.Order.OutPatient.Order order, EnumOrderFieldList changedField)
        {
            dirty = true;
            
            this.txtQTY.Text = order.Qty.ToString();
            
            this.myOrderChanged(order, changedField);
            dirty = false;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 数量变化-跳到下一级完成其它输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.order == null) return;
            if (e == null || e.KeyChar == 13)
            {
                if (this.order.Qty != Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtQTY.Value))
                {
                    this.order.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtQTY.Value);
                    myOrderChanged(this.order, EnumOrderFieldList.Qty);
                }
                if (e != null)
                {
                    //if (this.order.Item.IsPharmacy == false)//非药品跳回 新加
                    if (this.order.Item.ItemType != EnumItemType.Drug)//非药品跳回 新加
                        this.ucOrderInputByType1.Focus();
                    else
                        this.cmbUnit.Focus();
                }
            }
        }

        private void txtQTY_Leave(object sender, EventArgs e)
        {
            if (this.order == null) return;
            if (this.order.Qty == Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtQTY.Value))
            {
                if (isDrugListFlag == string.Empty)//{24BDD373-4F2C-4899-88A7-FE2E8386F7CF}
                {
                    return;
                }
                else
                {
                    this.txtQTY.Focus();
                    isDrugListFlag = string.Empty;
                }
            }
            this.txtQTY_KeyPress(sender, null);            

        }

        private void txtQTY_Enter(object sender, EventArgs e)
        {
            this.txtQTY.Select(0, this.txtQTY.Value.ToString().Length);
        }

        private void cmbUnit_TextChanged(object sender, EventArgs e)
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
                    #region 判断是否是最小单位 --donggq----{BC5E1C12-B63E-4efb-BA52-2BF30AA5FFF4}
                    //if (this.order.Item.IsPharmacy)
                    if (this.order.Item.ItemType == EnumItemType.Drug)
                    {
                        if (this.cmbUnit.SelectedIndex == 0)
                        {
                            this.order.NurseStation.User03 = "1";
                        }
                        else
                        {
                            this.order.NurseStation.User03 = "0";
                        }
                    }
                    # endregion
                    this.order.Unit = unit;//更新单位
                    myOrderChanged(this.order, EnumOrderFieldList.Unit);
                }
            }
            catch { }
        }

        void ucInputItem1_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {

            if (this.ucInputItem1.FeeItem == null) return;
            if (!this.EditGroup)		//当实现对组套修改功能时 不需对知情同意情况进行判断
            {
                //判断当前输入的项目是否知情同意书
                ////this.bPermission = Order.Classes.Function.IsPermission(this.patientInfo,
                ////    (Neusoft.HISFC.Models.Order.OrderType)this.cmbOrderType1.SelectedItem,
                ////    (Neusoft.HISFC.Models.Base.Item)this.ucInputItem1.FeeItem);
            }

            if (this.order != null && this.ucInputItem1.FeeItem as Neusoft.HISFC.Models.Base.Item == this.order.Item) //不重复
            {
                this.txtQTY.Focus();
                this.txtQTY.Select(0, this.txtQTY.Value.ToString().Length);
                return;
            }

            //项目变化-指向新行
            this.CurrentRow = -1;

            this.OperatorType = Operator.Add;

            //设置新医嘱
            this.SetOrder();

            //数量变化
            if (this.txtQTY.Enabled)
            {
                this.txtQTY.Focus();
                this.txtQTY.Select(0, this.txtQTY.Value.ToString().Length);
            }
            else
            {
                this.ucOrderInputByType1.Focus();
            }

        }

        public void SetQtyFocus()
        {
            this.txtQTY.Focus();
            this.txtQTY.Select(0, this.txtQTY.Value.ToString().Length);
        }

        void ucInputItem1_CatagoryChanged(Neusoft.FrameWork.Models.NeuObject sender)
        {
            ////try
            ////{
            ////    Neusoft.FrameWork.Models.NeuObject obj = sender;
            ////    if (obj.ID.Length > 0 && obj.ID.Substring(0, 1) == "M")
            ////    {
            ////        GeChargeableOrderType(false);
            ////    }
            ////    else
            ////    {
            ////        GeChargeableOrderType(true);
            ////    }
            ////}
            ////catch { }
            ////if (CatagoryChanged != null) CatagoryChanged(sender);
        }

        void ucOrderInputByType1_Leave(object sender, EventArgs e)
        {
            this.ucInputItem1.Focus();
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
                if (this.order.Item.ItemType != EnumItemType.Drug)//非药品跳回 新加
                    this.ucOrderInputByType1.Focus();
                else
                    this.ucOrderInputByType1.Focus();
                #region 判断是否是最小单位
                //if (this.order.Item.IsPharmacy)
                if (this.order.Item.ItemType == EnumItemType.Drug)
                {
                    if (this.cmbUnit.SelectedIndex == 0)
                    {
                        this.order.NurseStation.User03 = "1";
                    }
                    else
                    {
                        this.order.NurseStation.User03 = "0";
                    }
                }
                # endregion
            }
        }

        /// <summary>
        /// 单位选择变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    #region 判断是否是最小单位
                    //if (this.order.Item.IsPharmacy)
                    if (this.order.Item.ItemType == EnumItemType.Drug)
                    {
					    if(this.cmbUnit.SelectedIndex == 0)
					    {
						    this.order.NurseStation.User03 = "1";
					    }
					    else
					    {
                            this.order.NurseStation.User03 = "0";
					    }
                    }
				    # endregion
                    this.order.Unit = unit;//更新单位
                    myOrderChanged(this.order, EnumOrderFieldList.Unit);
                }
            }
            catch { }
        }

        #endregion

        private void txtQTY_ValueChanged(object sender, EventArgs e)
        {
            if (this.order == null) return;
            if (this.order.Qty == Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtQTY.Value)) return;
            this.txtQTY_KeyPress(sender, null);
        }

        
    }
    /// <summary>
    /// 医嘱操作
    /// </summary>
    public enum Operator
    { Add, Modify, Delete, Query }
}

