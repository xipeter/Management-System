using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;
namespace Neusoft.HISFC.Components.Terminal.Confirm
{
    public partial class ucInpatientConfirm : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucInpatientConfirm()
        {
            InitializeComponent();
        }

        #region 私有变量
        public bool seeAll = false;
        public bool clearConfirm = false;
        Neusoft.HISFC.Models.Base.MessType messType =  Neusoft.HISFC.Models.Base.MessType.N;
        private bool addFirstRow = false;
        Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm terminalMgr = new Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm();
        Neusoft.HISFC.Components.Common.Controls.EnumShowItemType itemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.DeptItem;
        Neusoft.ApplyInterface.HisInterface PACSApplyInterface = null;
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam cpMgr = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        #region {5E5299D8-95A2-4498-B2F1-52D00E4FB11A}
        Neusoft.HISFC.Components.PacsApply.HisInterface PACSApplyInterfaceNew = null;
        #endregion
        #endregion

        #region  属性
        /// <summary>
        /// 控制欠费类型
        /// </summary>
        [Category("控件设置"), Description("欠费判断提示类型")]
        public Neusoft.HISFC.Models.Base.MessType MessType
        {
            get
            {
                return messType;
            }
            set
            {
                messType = value;
            }
        }
        /// <summary>
        /// 显示的项目类别
        /// </summary>
        [Category("控件设置"), Description("显示的项目类别")]
        public Neusoft.HISFC.Components.Common.Controls.EnumShowItemType ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
            }
        }
        /// <summary>
        /// 查看所有科室终端确认项目
        /// </summary>
        [Category("控件设置"), Description("查看所有科室终端确认项目")]
        public bool SeeAll
        {
            get
            {
                return seeAll;
            }
            set
            {
                seeAll = value;
            }
        }
        /// <summary>
        /// 点击保存后是否删除已确认项目
        /// </summary>
        [Category("控件设置"), Description("点击保存后是否删除已确认项目")]
        public bool ClearConfirm
        {
            get
            {
                return clearConfirm;
            }
            set
            {
                clearConfirm = value;
            }
        }


        /// <summary>
        /// 新增行是否在第一行
        /// </summary>
        [Category("控件设置"), Description("新增行是否在第一行")]
        public bool AddFirstRow
        {
            get
            {
                return addFirstRow;
            }
            set
            {
                addFirstRow = value;
            }
        }
        #endregion

        #region 变量

        private enum Cols
        {
            IsExec, //0
            Except,
            ItemCode,//1
            ItemName,//2
            doc_name,//3
            ItemQty,//4
            ItemAlreadConfirmQty,//5
            ItemConfirmQty,//6
            Unit,//7
            Price,//8
            TotCost,//9
            OrderType,//10
            //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
            ItemStatus,//10项目状态：未确认、部分确认、全部确认，通过各数量进行综合比较
            Machine,//11项目使用设备：从医技载体表进行查找
            Operator//12技师：默认是当前操作员，可以修改
            //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
        }
        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo myPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee oper = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Clone();

        /// <summary>
        /// 医嘱业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Order orderManager = new Neusoft.HISFC.BizProcess.Integrate.Order();

        /// <summary>
        /// 费用业务
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 终端业务
        /// </summary>
        private Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm terminalManager = new Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm();

        /// <summary>
        /// 终端业务
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
        //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
        /// <summary>
        /// 医技载体业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier terminalCarrier = new Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier();                        

        private ArrayList alExecOrder = new ArrayList();

        private DataTable dtExecOrder = new DataTable();

        private DataView dvExecOrder = new DataView();

        private string filePath = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + @"\Profile\TecExecOrder.xml";

        /// <summary>
        /// ToolBarService
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 项目选择控件
        /// </summary>
        public Neusoft.HISFC.Components.Common.Controls.ucItemList ucItemList;

        public Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        private int currentRow = 0;
        private int currentColumn = 0;
        private DateTime dtNow = DateTime.Now;

        //是否使用电子申请单
        private string isUseDL = "0";

        #region addby xuewj 2010-9-21 {9300A7AC-DA0F-472d-B2CF-7F509CB8BE72} 终端确认调用记账单

        /// <summary>
        /// 是否打印病区记账单
        /// </summary>
        private bool isPrintFeeSheet = false;

        [Category("控件设置"),Description("是否打印病区记账单")]
        public bool IsPrintFeeSheet
        {
            get { return isPrintFeeSheet; }
            set { isPrintFeeSheet = value; }
        }

        /// <summary>
        /// 记账单打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet nurseFeeBill = null;

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载收费项目信息...");
            Application.DoEvents();

            //this.ucItemList = new ucItemList(Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.Undrug);
            //this.ucItemList = new Neusoft.HISFC.Components.Common.Controls.ucItemList(itemType);

            this.ucItemList = new Neusoft.HISFC.Components.Common.Controls.ucItemList();

            // 添加项目列表
            this.Controls.Add(this.ucItemList);
            // 设置项目列表不可见

            this.ucItemList.enuShowItemType = itemType;
            this.ucItemList.Init(string.Empty);


            this.ucItemList.Visible = false;
            // 使项目列表最前

            this.ucItemList.BringToFront();
            // 收费项目列表选择项目事件
            this.ucItemList.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucItemList.MyDelegate(ucItemList_SelectItem);
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(ucQueryInpatientNo1_myEvent);//{C30E2F4A-3BC4-4b98-973F-C734537F4EA4}

            this.InitFp();

            this.fpExecOrder.KeyEnter += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.keyDown(fpExecOrder_KeyEnter);

            #region addby xuewj 2010-11-11 电子申请单读取本地配置文件{457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
            //isUseDL = cpMgr.GetControlParam<string>("200212");
            isUseDL = Neusoft.FrameWork.Function.NConvert.ToInt32(Neusoft.HISFC.Components.Common.Classes.Function.LoadMenuSet()).ToString(); 
            #endregion
            this.QueryTermalDept();
        }

        //{D614378E-677D-4a84-891B-D0E2D47D3E00}

        private ArrayList alTermalDept = new ArrayList();

        private int QueryTermalDept()
        {
            //Neusoft.HISFC.BizProcess.Integrate.Manager managerInt = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager dsmManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();

            alTermalDept = dsmManager.LoadDepartmentStatAndByNodeKind( "98","1");

            //this.alTermalDept = managerInt.GetConstantList("Termin");
            
            return 1;
        }

        void ucQueryInpatientNo1_myEvent() //{C30E2F4A-3BC4-4b98-973F-C734537F4EA4}
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patient = radt.QueryPatientInfoByInpatientNO(this.ucQueryInpatientNo1.InpatientNo);
            if (patient != null)
            {
                this.myPatient = patient;
                lblName.Text = "患者姓名：" + this.myPatient.Name;
                lblPatientNO.Text = "住院号：" + this.myPatient.PID.PatientNO;
                lblDept.Text = "患者科室：" + this.myPatient.PVisit.PatientLocation.Dept.Name;
                lblFreeCost.Text = "可用余额：" + this.myPatient.FT.LeftCost.ToString();
                lblPack.Text = "合同单位：" + this.myPatient.Pact.Name;

                if (this.seeAll)
                {
                    alExecOrder = this.orderManager.QueryExecOrderByDept(patient.ID, "2", false, "all");
                }
                else
                {
                    alExecOrder = this.orderManager.QueryExecOrderByDept(patient.ID, "2", false, oper.Dept.ID);
                }
                if (alExecOrder != null)
                {
                    this.fpExecOrder.Sheets[0].RowCount = 0;
                    this.AddExecOrderToFp(alExecOrder);
                }
            }
            else
            {
                MessageBox.Show("无此患者!");
                this.fpExecOrder.Sheets[0].RowCount = 0;
                lblName.Text = "患者姓名：" ;
                lblPatientNO.Text = "住院号：";
                lblDept.Text = "患者科室：";
                lblFreeCost.Text = "可用余额：";
                lblPack.Text = "合同单位：" ;
                return;
            }
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        private void InitFp()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg("正在初始化表格，请稍候....."));
            try
            {
                if (System.IO.File.Exists(this.filePath))
                {

                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.filePath, this.dtExecOrder, ref this.dvExecOrder, this.fpExecOrder_Sheet1);

                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpExecOrder_Sheet1, this.filePath);
                }
                else
                {
                    this.dtExecOrder.Columns.AddRange(new DataColumn[]
                    {
                        new DataColumn("执行标记",typeof(bool)),
                        new DataColumn("执行科室",typeof(string)),
                        new DataColumn("项目编码",typeof(string)),
                        new DataColumn("项目名称",typeof(string)),
                        //增加开方医生显示 {C675754A-973E-4619-BCCD-B459CCD3BD0D} hzl 2010-11-16 
                        new DataColumn("开立医生",typeof(string)),
                        new DataColumn("总数量",typeof(decimal)),
                        new DataColumn("已确认数量",typeof(decimal)),
                        new DataColumn("确认数量",typeof(decimal)),
                        new DataColumn("单位",typeof(string)),
                        new DataColumn("单价",typeof(decimal)),
                        new DataColumn("总额",typeof(decimal)),
                        new DataColumn("SOURCE",typeof(string)),
                        //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
                        new DataColumn("状态",typeof(string)),
                        new DataColumn("对应设备",typeof(string)),
                        new DataColumn("技师",typeof(string))
                        //by yuyun 08-7-7
                    });

                    this.dvExecOrder = new DataView(this.dtExecOrder);

                    this.fpExecOrder.DataSource = this.dvExecOrder;

                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpExecOrder_Sheet1, this.filePath);
                }
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.fpExecOrder_Sheet1.DefaultStyle.Locked = true;

            this.fpExecOrder_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.IsExec].Locked = false;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.Except].Locked = true;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.ItemName].Locked = false;
            //增加开方医生显示 {C675754A-973E-4619-BCCD-B459CCD3BD0D} hzl 2010-11-16
            this.fpExecOrder_Sheet1.Columns[(int)Cols.doc_name].Locked = false;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.ItemQty].Locked = true;
            //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
            //this.fpExecOrder_Sheet1.Columns[(int)Cols.ItemQty].Visible = false;
            //by yuyun 08-7-7
            #region {DEF0DE5C-96BF-4f48-80DC-297B9B16315A}
            this.fpExecOrder_Sheet1.Columns[(int)Cols.ItemCode].Locked = true;
            #endregion
            this.fpExecOrder_Sheet1.Columns[(int)Cols.ItemAlreadConfirmQty].Locked = true;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.ItemConfirmQty].Locked = false;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.Unit].Locked = true;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.Price].Locked = true;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.TotCost].Locked = true;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.OrderType].Locked = true;
            //by yuyun 08-7-8{52355595-B401-4db9-82BC-A3650F11D2CC}
            this.fpExecOrder_Sheet1.Columns[(int)Cols.ItemStatus].Locked = true;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.Machine].Locked = false;
            this.fpExecOrder_Sheet1.Columns[(int)Cols.Operator].Locked = false;
            //在技师列中加入人员列表供选择
            ArrayList al = new ArrayList();
            Neusoft.HISFC.BizProcess.Integrate.Manager ztManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            al = ztManager.QueryEmployeeAll();
            //.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.T);
            this.fpExecOrder.SetColumnList(this.fpExecOrder_Sheet1, (int)Cols.Operator, al);
            //设备列加入医技设备数据，只显示当前操作员所在科室的医技设备
            al = this.terminalCarrier.GetDesigns(this.oper.Dept.ID);
            if (al.Count > 0)
            {
                ArrayList alTer = new ArrayList();
                foreach (HISFC.Models.Terminal.TerminalCarrier terObj in al)
                {
                    alTer.Add(new Neusoft.FrameWork.Models.NeuObject(terObj.CarrierCode, terObj.CarrierName, ""));
                }
                this.fpExecOrder.SetColumnList(this.fpExecOrder_Sheet1, (int)Cols.Machine, alTer);
            }
            this.fpExecOrder.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(fpExecOrder_SetItem);
            //by yuyun 08-7-8
        }
        //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
        private int fpExecOrder_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
        {
            this.fpExecOrder_Sheet1.Cells[this.fpExecOrder_Sheet1.ActiveRowIndex, this.fpExecOrder_Sheet1.ActiveColumnIndex].Text = obj.Name;
            this.fpExecOrder_Sheet1.Cells[this.fpExecOrder_Sheet1.ActiveRowIndex, this.fpExecOrder_Sheet1.ActiveColumnIndex].Tag = obj;
            return 0;
        }
        //{23016A93-22CE-4fe6-9CF4-1F9E90B3DD08}
        private bool IsExist(Neusoft.HISFC.Models.Order.ExecOrder order)
        {

            for (int i = 0; i < this.alTermalDept.Count; i++)
            {
                Neusoft.HISFC.Models.Base.DepartmentStat obj = alTermalDept[i] as Neusoft.HISFC.Models.Base.DepartmentStat;
                if (order.Order.ExeDept.ID == obj.DeptCode)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 添加医嘱数据到表格
        /// </summary>
        /// <param name="alExecOrder"></param>
        /// <returns></returns>
        protected virtual int AddExecOrderToFp(ArrayList alExecOrder)
        {
            try
            {
                foreach (Neusoft.HISFC.Models.Order.ExecOrder order in alExecOrder)
                {
                    #region {5197289A-AB55-410b-81EE-FC7C1B7CB5D7}
                    //修正长期终端确认医嘱，护士分解，但没有打勾没有保存的数据也显示出来的问题
                    if (order.Order.OrderType.IsDecompose)
                    {
                        if (!this.orderManager.CheckLongUndrugIsConfirm(order.ID))
                        {
                            continue;
                        }
                    }
                    //{23016A93-22CE-4fe6-9CF4-1F9E90B3DD08}
                    if (this.seeAll)
                    {
                        if (this.IsExist(order)) //不存在，继续
                        {
                            continue;
                        }
                    }

                    #endregion

                    this.fpExecOrder.Sheets[0].Rows.Add(0, 1);
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemName].Locked = true;//{15387EC4-F638-4084-A4F4-0A6FF4AF13D9} 锁定医嘱名称
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.Except].Text = order.Order.ExeDept.Name;
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.IsExec].Value = order.IsExec;
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemCode].Text = order.Order.Item.ID;
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemName].Text = order.Order.Item.Name;
                    //增加开方医生显示 {C675754A-973E-4619-BCCD-B459CCD3BD0D} hzl 2010-11-16
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.doc_name].Text = order.Order.ReciptDoctor.Name;
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemQty].Text = order.Order.Qty.ToString();

                    decimal AlreadyQty = terminalMgr.GetAlreadConfirmNum(order.Order.ID, order.ID);
                    if (AlreadyQty < 0)
                    {
                        MessageBox.Show("获取已确认项目数量失败" + terminalMgr.Err);
                        return -1;
                    }
                    decimal LeaveQty = order.Order.Qty - AlreadyQty;
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemAlreadConfirmQty].Text = AlreadyQty.ToString();
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemConfirmQty].Text = LeaveQty.ToString();
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.Unit].Text = order.Order.Unit;
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.Price].Text = order.Order.Item.Price.ToString();
                    if (order.Order.Item.Price == 0 && order.Order.Unit != "[复合项]")//by zhouxs 2007-10-28
                    {
                        this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.Price].Locked = false;
                    }//end zhouxs
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.TotCost].Text = Convert.ToString(order.Order.Item.Price * order.Order.Qty);
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.OrderType].Text = "ORDER";
                    //by yuyun 08-7-8{07D1BACB-8E4F-4ac8-8254-81763D0F0699}
                    if (AlreadyQty > 0 && AlreadyQty < order.Order.Qty)
                    {
                        this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemStatus].Text = "部分确认";
                        this.fpExecOrder.Sheets[0].Rows[0].BackColor = Color.LightBlue;//将部分确认的项目用颜色区分
                    }
                    else
                    {
                        this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.ItemStatus].Text = "未确认";
                    }
                    //医技设备
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.Machine].Text = "";
                    ////////////////////
                    //技师
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.Operator].Text = this.oper.Name;
                    this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.Operator].Tag = this.oper.ID;
                    //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}

                    this.fpExecOrder.Sheets[0].Rows[0].Tag = order;
                }
                #region addby xuewj 2010-9-27 {C3F7C1B0-97BA-4001-A0B8-6AAB8785C90D} 增加合计
                if (!this.seeAll)
                {
                    this.fpExecOrder.Sheets[0].RowCount += 1;
                    decimal totCost = this.SumCost();
                    int activeRowIndex = this.fpExecOrder.Sheets[0].RowCount - 1;
                    this.fpExecOrder.Sheets[0].Cells[activeRowIndex, (int)Cols.TotCost].Text = totCost.ToString();
                    this.fpExecOrder.Sheets[0].Cells[activeRowIndex, (int)Cols.Unit].Text = "合计:";
                    this.fpExecOrder.Sheets[0].Rows[activeRowIndex].Locked = true;
                    if (this.fpExecOrder.Sheets[0].RowCount == 1)
                    {
                        this.AddNewRow();
                    }
                }
                else
                {
                    if (this.fpExecOrder.Sheets[0].RowCount > 0)
                    {
                        this.fpExecOrder.Sheets[0].RowCount += 1;
                        decimal totCost = this.SumCost();
                        int activeRowIndex = this.fpExecOrder.Sheets[0].RowCount - 1;
                        this.fpExecOrder.Sheets[0].Cells[activeRowIndex, (int)Cols.TotCost].Text = totCost.ToString();
                        this.fpExecOrder.Sheets[0].Cells[activeRowIndex, (int)Cols.Unit].Text = "合计:";
                        this.fpExecOrder.Sheets[0].Rows[activeRowIndex].Locked = true;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载表格格式错误！请更新TecExecOrder.xml文件" + ex.Message);

                return -1;
            }
            return 0;
        }

        #region addby xuewj 2010-9-27 {C3F7C1B0-97BA-4001-A0B8-6AAB8785C90D} 增加合计
        /// <summary>
        /// 计算当前选中项目的总金额
        /// </summary>
        /// <returns></returns>
        protected virtual decimal SumCost()
        {
            string tempPrice = "";
            decimal totCost = 0m;
            for (int i = 0; i < this.fpExecOrder_Sheet1.RowCount; i++)
            {
                if (this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.OrderType].Text != "")
                {
                    tempPrice = this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.TotCost].Text;
                    totCost += Neusoft.FrameWork.Function.NConvert.ToDecimal(tempPrice);
                }
            }

            return totCost;
        } 
        #endregion

        /// <summary>
        /// 选择项目列表数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int ucItemList_SelectItem(Keys key)
        {
            this.InsertItem();
            this.fpExecOrder.Focus();//add by xuewj 2010-9-27 双击项目列表 焦点跳回fp {E10F354A-2EB3-4caf-AE16-F87F78464DF5}
            return 0;
        }

        /// <summary>
        /// 菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        {
            base.Init(sender, neuObject, param);

            this.toolBarService.AddToolButton("新增", "补收项目的划价信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolBarService.AddToolButton("刷新", "刷新患者信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
            #region {53061BA2-33FC-469d-9773-9A9454023612}
            this.toolBarService.AddToolButton("删除", "删除新增的补收项目的划价信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            #endregion
            //by yuyun 08-7-8{C46CFCDE-132B-47c0-ADAC-4AD73DA2FD90}
            //this.toolBarService.AddToolButton("开立处方", "开立处方", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D医嘱, true, false, null);
            //by yuyun 08-7-8
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "新增":
                    if (this.seeAll)
                    {
                        MessageBox.Show("查询全院确认信息时 不能新增收费项目", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    this.AddNewRow();
                    break;
                #region {53061BA2-33FC-469d-9773-9A9454023612}
                case "删除":
                    DeleteItemEvent();
                    break;
                #endregion
                case "刷新":
                    this.Clear();
                    this.tv.Refresh();
                    break;
                //by yuyun 08-7-8{CFBF5A32-66FF-468e-A26E-624DE186BD9C}
                //case "开立处方":
                //    this.Clear();
                //    //todo
                //    break;
                //by yuyun 08-7-8
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        #region {53061BA2-33FC-469d-9773-9A9454023612}
        /// <summary>
        /// 删除新项目事件

        /// </summary>

        void DeleteItemEvent()
        {
            this.MakeItemListDisappear();
            this.DeleteNew();
        }

        /// <summary>
        /// 删除一行(当前行)新项目

        /// </summary>
        public void DeleteNew()
        {
            // 如果没有记录，则返回
            if (this.fpExecOrder_Sheet1.RowCount == 0)
            {
                return;
            }
            // 只能删除新项目

            if (this.GetItem(this.fpExecOrder_Sheet1.ActiveRowIndex, (int)Cols.OrderType) != "NEW")
            {
                MessageBox.Show("该项目不允许删除", "医技终端确认");
                //this.Focus();
                //this.CellFocus(this.fpExecOrder_Sheet1.ActiveRowIndex, (int)Cols.OrderType);
                return;
            }
            // 删除
            this.DeleteRow(this.fpExecOrder_Sheet1.ActiveRowIndex, true);
            #region addby xuewj 2010-9-27 {C3F7C1B0-97BA-4001-A0B8-6AAB8785C90D} 增加合计
            decimal totCost = this.SumCost();
            int activeRowIndex = this.fpExecOrder.Sheets[0].RowCount - 1;
            this.fpExecOrder.Sheets[0].Cells[activeRowIndex, (int)Cols.TotCost].Text = totCost.ToString(); 
            #endregion
        }
        /// <summary>
        /// 按指定的行号删除一行

        /// [参数1: int row - 要删除的行号]
        /// [参数2: bool confirm - 是否需要用户确认]
        /// </summary>
        /// <param name="row">要删除的行号</param>
        /// <param name="confirm">是否需要确认</param>
        public void DeleteRow(int row, bool confirm)
        {
            // 如果是空记录，则直接删除，否则需要确认删除

            if (confirm && (!this.IsNull(row)))
            {
                // 如果取消删除，那么返回

                if (MessageBox.Show("是否删除当前行？", "医技终端确认",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    this.Focus();
                    return;
                }
            }
            //{8C0239CE-4272-4f30-B547-9C3C27D694E4} 停止编辑模式，否则删除时保留了当前选中文本
            this.fpExecOrder.EditMode = false;
            // 删除指定的行
            this.fpExecOrder_Sheet1.RemoveRows(row, 1);
            // 设置焦点到上一行

            //this.fpExecOrder_Sheet1.Focus();
            //if (row - 1 >= 0)
            //{
            //    this.CurrentRow = row - 1;
            //    // 设置焦点到项目名称

            //    this.CurrentColumn = (int)DisplayField.ItemName;
            //}
        }
        /// <summary>
        /// 判断指定行是否为空（如果项目编号14列为空就认为是空记录）

        /// [参数: int row - 行号]
        /// [返回: bool,true - 空, false - 非空]
        /// </summary>
        /// <param name="row">指定的行号</param>
        /// <returns>true：为空/false：不为空</returns>
        public bool IsNull(int row)
        {
            // 如果项目编码为空，代表项目为空

            if (this.fpExecOrder_Sheet1.Cells[row, (int)Cols.ItemCode].Text.Equals(""))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 获取一个CELL的值

        /// [参数1: int row - 行号]
        /// [参数2: int column - 列号]
        /// [返回: string, 文本值]
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="column">列</param>
        /// <returns>CELL里面的文本</returns>
        public string GetItem(int row, int column)
        {
            return this.fpExecOrder_Sheet1.Cells[row, column].Text;
        }
        /// <summary>
        /// 是收费项目选择控件不可见

        /// </summary>
        private void MakeItemListDisappear()
        {
            if (this.ucItemList.Visible == true)
            {
                this.ucItemList.Visible = false;
            }
        }
        #endregion
        private void Clear()
        {
            this.myPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
            lblName.Text = "患者姓名：";
            lblPatientNO.Text = "住院号：";
            lblDept.Text = "患者科室：";
            lblFreeCost.Text = "可用余额：";
            this.fpExecOrder.Sheets[0].RowCount = 0;
        }

        /// <summary>
        /// 树选择
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {

            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            if (neuObject != null)
            {
                if (neuObject.GetType() == patientInfo.GetType())
                {
                    patientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
                    this.myPatient = patientInfo;
                    lblName.Text = "患者姓名：" + this.myPatient.Name;
                    lblPatientNO.Text = "住院号：" + this.myPatient.PID.PatientNO;
                    lblDept.Text = "患者科室：" + this.myPatient.PVisit.PatientLocation.Dept.Name;
                    lblFreeCost.Text = "可用余额：" + this.myPatient.FT.LeftCost.ToString();
                    if (this.seeAll)
                    {
                        alExecOrder = this.orderManager.QueryExecOrderByDept(patientInfo.ID, "2", false, "all");
                    }
                    else
                    {
                        alExecOrder = this.orderManager.QueryExecOrderByDept(patientInfo.ID, "2", false, oper.Dept.ID);
                    }
                    if (alExecOrder != null)
                    {
                        this.fpExecOrder.Sheets[0].RowCount = 0;
                        this.AddExecOrderToFp(alExecOrder);
                    }
                }
            }
            else
            {

                return -1;
            }

            return base.OnSetValue(neuObject, e);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.Init();
            base.OnLoad(e);
            InputMap im;
            im = fpExecOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpExecOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpExecOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 添加新划价数据
        /// </summary>
        private void AddNewRow()
        {
            if (this.myPatient == null || this.myPatient.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("您没有选择患者！"));
                return;
            }
            #region addby xuewj 2010-9-27 {C3F7C1B0-97BA-4001-A0B8-6AAB8785C90D} 增加合计
            //int rowcount = this.fpExecOrder.Sheets[0].RowCount;
            int rowcount = this.fpExecOrder.Sheets[0].RowCount - 1; 
            #endregion
            if (AddFirstRow)
            {
                this.fpExecOrder.Sheets[0].Rows.Add(0, 1);
                this.fpExecOrder.Sheets[0].Cells[0, (int)Cols.OrderType].Text = "NEW";
                #region {15181E09-0842-4e3f-A91C-A25F3930CA28}
                this.fpExecOrder.Sheets[0].SetActiveCell(0, (int)Cols.ItemName, true);
                #endregion

            }
            else
            {
                this.fpExecOrder.Sheets[0].Rows.Add(rowcount, 1);
                this.fpExecOrder.Sheets[0].Cells[rowcount, (int)Cols.OrderType].Text = "NEW";
                #region {15181E09-0842-4e3f-A91C-A25F3930CA28}
                this.fpExecOrder.Sheets[0].SetActiveCell(rowcount, (int)Cols.ItemName, true);
                #endregion
            }
            #region {15181E09-0842-4e3f-A91C-A25F3930CA28}
            this.fpExecOrder.EditMode = true;
            //this.fpExecOrder.Focus();
            #endregion
            this.currentRow = rowcount;
        }

        /// <summary>
        /// 添加新划价数据到表格
        /// </summary>
        private void InsertItem()
        {
            Neusoft.HISFC.Models.Base.Item item = null;
            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = null;
            int intReturn = this.ucItemList.GetSelectItem(out item);

            if (item == null || item.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有找到项目"));
                return;
            }
            undrug = feeManager.GetUndrugByCode(item.ID);
            if (intReturn > 0)
            {

                this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.IsExec].Value = true;
                this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.ItemCode].Text = undrug.ID;
                this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.ItemName].Text = undrug.Name;
                this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Unit].Text = undrug.PriceUnit;
                if (undrug.UnitFlag == "0")
                {
                    this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Price].Text = undrug.Price.ToString();
                }
                else if (undrug.UnitFlag == "1")
                {
                    //{85F65949-AD94-422f-93C9-588D0072F2AA} 不需要重新取价格
                    //this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Price].Text = feeManager.GetUndrugCombPrice(item.ID).ToString();
                    this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Price].Text = undrug.Price.ToString();
                }
                this.UnDisplayUcItemList();
                this.fpExecOrder.Sheets[0].ActiveRow.Tag = item;
            }
        }


        /// <summary>
        /// 项目选择列表隐藏
        /// </summary>
        public void UnDisplayUcItemList()
        {
            if (this.ucItemList.Visible)
            {
                this.ucItemList.Visible = false;
            }
        }


        /// <summary>
        /// 表格数据转换成order
        /// </summary>
        /// <returns></returns>
        private ArrayList GetFeeOrder()
        {
            int rowCount = this.fpExecOrder.Sheets[0].RowCount;
            ArrayList alFeeOrder = new ArrayList();
            for (int i = 0; i < rowCount; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.IsExec].Value))
                {
                    Neusoft.HISFC.Models.Base.OperEnvironment o = new Neusoft.HISFC.Models.Base.OperEnvironment();
                    o.ID = oper.ID;
                    o.Name = oper.Name;
                    o.Dept = oper.Dept;
                    o.OperTime = this.dtNow;
                    if (this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.OrderType].Text == "ORDER")
                    {
                        Neusoft.HISFC.Models.Order.ExecOrder order = new Neusoft.HISFC.Models.Order.ExecOrder(); ;
                        order = (Neusoft.HISFC.Models.Order.ExecOrder)this.fpExecOrder.Sheets[0].Rows[i].Tag;
                        Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                        undrug = this.feeManager.GetUndrugByCode(order.Order.Item.ID);
                        order.Order.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.ItemConfirmQty].Value);
                        obj = order.Order;
                        obj.Item.MinFee = undrug.MinFee;
                        obj.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Price].Value);
                        obj.ExecOper = o;
                        obj.ExecOper.Dept = order.Order.ExeDept.Clone();
                        obj.Oper = o;
                        obj.User03 = order.ID;
                        //执行设备
                        //by yuyun 08-7-7{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
                        if (this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Machine].Value != null)
                        {
                            obj.Item.User01 = this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Machine].Value.ToString();
                        }
                        //执行技师
                        if (this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Operator].Value != null)
                        {
                            obj.Item.User02 = this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Operator].Value.ToString();
                        }
                        alFeeOrder.Add(obj);
                    }

                }
            }

            return alFeeOrder;
        }

        /// <summary>
        /// 表格中的新增收费数据转换成FeeItemList
        /// </summary>cc
        /// <returns></returns>
        private ArrayList GetNewFeeItemList()
        {
            int rowCount = this.fpExecOrder.Sheets[0].RowCount;
            ArrayList alFeeItemList = new ArrayList();
            for (int i = 0; i < rowCount; i++)
            {
                //{A22E7A8E-DE5E-40fc-8273-F774B286B7C8}改正复合项目补划价错误
                //Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.IsExec].Value))
                {
                    //if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder_Sheet1.Cells[i, (int)Cols.ItemQty].Text) <= 0)
                    //{
                    //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("新增收费项目需填写数量"));
                    //    return null;
                    //}
                    Neusoft.HISFC.Models.Base.OperEnvironment o = new Neusoft.HISFC.Models.Base.OperEnvironment();
                    o.ID = oper.ID;
                    o.Name = oper.Name;
                    o.Dept = oper.Dept;
                    o.OperTime = this.dtNow;
                    //------------------------
                    if (this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.OrderType].Text == "NEW")
                    {
                        Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item(); ;
                        Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                        item = this.fpExecOrder.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;
                        #region {B56C131D-2600-421c-9D51-12A1C214CA1E}
                        if (item == null)
                        {
                            continue;
                        }
                        #endregion
                        undrug = this.feeManager.GetUndrugByCode(item.ID);
                        //{F6A2DCD5-10B9-4fac-8ACB-D4B6FE9D684F}当住院补记账的项目的unitflag为空时，该费用没计上但提示确认成功。
                        if (string.IsNullOrEmpty(undrug.UnitFlag))
                        {
                            MessageBox.Show(undrug.Name + "该项目既不是明细项目，也不是组套项目，不能对其进行计费，请重新维护该项目信息。");
                            return null;
                        }
                        //----------------------------------------------
                        if (undrug.UnitFlag == "0")
                        {
                            //{A22E7A8E-DE5E-40fc-8273-F774B286B7C8}改正复合项目补划价错误
                            Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();

                            obj.Item = item;
                            obj.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.ItemConfirmQty].Text);
                            obj.ReciptDept = oper.Dept;
                            obj.ReciptDoctor.ID = oper.ID;
                            obj.ExecOper = o;
                            obj.Unit = item.PriceUnit;
                            obj.Oper = o;
                            obj.ExeDept = oper.Dept;//by yuyun 08-8-12 插入确认科室
                            //{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
                            obj.Item.User01 = this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Machine].Text;//执行设备
                            obj.Item.User02 = this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Operator].Text;//执行技师
                            alFeeItemList.Add(obj);
                        }
                        else if (undrug.UnitFlag == "1")
                        {
                            Neusoft.HISFC.BizProcess.Integrate.Manager ztManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                            ztManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            ArrayList alZtDetail = ztManager.QueryUndrugPackageDetailByCode(undrug.ID);
                            foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrugitem in alZtDetail)
                            {
                                //{A22E7A8E-DE5E-40fc-8273-F774B286B7C8}改正复合项目补划价错误
                                Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();

                                Neusoft.HISFC.Models.Fee.Item.Undrug myUndrug = this.feeManager.GetUndrugByCode(undrugitem.ID);
                                obj.Item = myUndrug as Neusoft.HISFC.Models.Base.Item;
                                obj.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.ItemConfirmQty].Text);

                                //{6EFEC5EC-2258-4d3e-877B-179215E2F783} 重新计算明细数量
                                obj.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.ItemConfirmQty].Text) * undrugitem.Qty;

                                obj.ReciptDept = oper.Dept;
                                obj.ReciptDoctor.ID = oper.ID;
                                obj.Unit = undrugitem.PriceUnit;
                                obj.ExecOper = o;
                                obj.ExeDept = oper.Dept;//by yuyun 08-8-12 {58B76F7C-A35D-4cbb-8948-8163EA3C5191}
                                obj.Oper = o;
                                //{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
                                obj.Item.User01 = this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Machine].Text;//执行设备
                                obj.Item.User02 = this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.Operator].Text;//执行技师
                                alFeeItemList.Add(obj);
                            }
                        }

                    }
                }
            }

            return alFeeItemList;
        }

        /// <summary>
        /// 表格数据转换成execorder
        /// </summary>
        /// <returns></returns>
        private ArrayList GetExecOrder()
        {
            int rowCount = this.fpExecOrder.Sheets[0].RowCount;
            ArrayList alNeedExecOrder = new ArrayList();
            for (int i = 0; i < rowCount; i++)
            {

                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.IsExec].Value))
                {
                    Neusoft.HISFC.Models.Base.OperEnvironment o = new Neusoft.HISFC.Models.Base.OperEnvironment();
                    o.ID = oper.ID;
                    o.Name = oper.Name;
                    o.OperTime = this.dtNow;
                    o.Dept = oper.Dept;
                    if (this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.OrderType].Text == "ORDER")
                    {
                        Neusoft.HISFC.Models.Order.ExecOrder order = new Neusoft.HISFC.Models.Order.ExecOrder(); ;
                        order = (Neusoft.HISFC.Models.Order.ExecOrder)this.fpExecOrder.Sheets[0].Rows[i].Tag;

                        order.Order.ExecOper = o;
                        order.ExecOper = o;
                        order.ExecOper.Dept = order.Order.ExeDept.Clone();
                        order.IsExec = true;
                        order.ChargeOper = o;
                        order.IsCharge = true;
                        order.Order.User03 = order.ID;
                        alNeedExecOrder.Add(order);
                    }

                }
            }

            return alNeedExecOrder;
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        private bool ValidState()
        {
            for (int i = 0; i < this.fpExecOrder_Sheet1.RowCount; i++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.IsExec].Value))
                {
                    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder_Sheet1.Cells[i, (int)Cols.ItemConfirmQty].Text) <= 0)
                    {
                        MessageBox.Show("请输入需要确认的数量");
                        return false;
                    }
                    if (this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.OrderType].Text == "ORDER")
                    {
                        decimal totQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder_Sheet1.Cells[i, (int)Cols.ItemQty].Text);
                        decimal alreadQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder_Sheet1.Cells[i, (int)Cols.ItemAlreadConfirmQty].Text);
                        decimal confirmQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder_Sheet1.Cells[i, (int)Cols.ItemConfirmQty].Text);
                        if (totQty < alreadQty + confirmQty)
                        {
                            MessageBox.Show("可确认数量过大，最大可确认数量不能大于" + (totQty - alreadQty).ToString());
                            return false;
                        }
                    }
                    if (this.fpExecOrder_Sheet1.Cells[i, (int)Cols.OrderType].Text == "NEW")
                    {
                        #region {B56C131D-2600-421c-9D51-12A1C214CA1E}
                        Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item(); ;
                        item = this.fpExecOrder.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Base.Item;
                        if (item == null)
                        {
                            MessageBox.Show("请输入需要确认的项目！");
                            return false;
                        }
                        #endregion
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 数据转换成feeitemlist
        /// </summary>
        /// <param name="alOrder"></param>
        /// <returns></returns>
        private ArrayList ChangeOrderToFeeItemList(ArrayList alOrder)
        {
            ArrayList alFeeItemList = new ArrayList();
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in alOrder)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();

                feeItemList.Item = order.Item.Clone();
                feeItemList.Item.PriceUnit = order.Unit;//单位重新付
                feeItemList.RecipeOper.Dept = order.ReciptDept.Clone();
                feeItemList.RecipeOper.ID = order.ReciptDoctor.ID;
                feeItemList.RecipeOper.Name = order.ReciptDoctor.Name;
                feeItemList.ExecOper = order.ExecOper.Clone();
                feeItemList.ExecOper.Dept = order.ExeDept.Clone();
                feeItemList.StockOper.Dept = order.StockDept.Clone();
                if (feeItemList.Item.PackQty == 0)
                {
                    feeItemList.Item.PackQty = 1;
                }
                feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber((feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty), 2);
                feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
                feeItemList.IsBaby = order.IsBaby;
                feeItemList.IsEmergency = order.IsEmergency;
                feeItemList.Order = order.Clone();
                feeItemList.ExecOrder.ID = order.User03;
                feeItemList.NoBackQty = feeItemList.Item.Qty;
                feeItemList.FTRate.OwnRate = 1;
                feeItemList.BalanceState = "0";
                feeItemList.ChargeOper = order.Oper.Clone();
                feeItemList.FeeOper = order.Oper.Clone();
                feeItemList.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                feeItemList.Item.User01 = order.Item.User01;
                feeItemList.Item.User02 = order.Item.User02;
                alFeeItemList.Add(feeItemList);
            }
            return alFeeItemList;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            #region 变量及Trans
            //{58B76F7C-A35D-4cbb-8948-8163EA3C5191}
            this.dtNow = this.terminalManager.GetDateTimeFromSysDateTime();
            ArrayList alOrder = new ArrayList();
            ArrayList alFeeItemList = new ArrayList();
            ArrayList alNeedExecOrder = new ArrayList();
            int iReturn = 0;
            #region addby xuewj 2010-9-21 {9300A7AC-DA0F-472d-B2CF-7F509CB8BE72} 终端确认调用记账单
            string paramRecipeNO = "";//收费处方号
            DateTime beginDate = terminalManager.GetDateTimeFromSysDateTime(); 
            #endregion
            //Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.None;
            if (!ValidState())
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.terminalManager.Connection);
            //t.BeginTransaction();
            this.feeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.confirmIntergrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            terminalMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeManager.MessageType = messType;

            #endregion

            #region 取得需要操作的数据ArrayList

            alOrder = this.GetFeeOrder();
            if (alOrder == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            alFeeItemList = this.GetNewFeeItemList();
            if (alFeeItemList == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            alFeeItemList = this.ChangeOrderToFeeItemList(alFeeItemList);
            alNeedExecOrder = this.GetExecOrder();
            #endregion

            #region 拆分复合项目{856164A9-000A-482f-B9F4-2A2FF44F96B3}

            Neusoft.HISFC.BizProcess.Integrate.Manager managerPack = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizProcess.Integrate.Fee tempManagerFee = new Neusoft.HISFC.BizProcess.Integrate.Fee();

            ArrayList alOrderTemp = new ArrayList();

            for (int i = 0; i < alOrder.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order oldOrder = alOrder[i] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                Neusoft.HISFC.Models.Fee.Item.Undrug ug = tempManagerFee.GetItem((oldOrder as Neusoft.HISFC.Models.Order.Inpatient.Order).Item.ID);
                if (ug.UnitFlag == "1")
                {
                    ArrayList al = managerPack.QueryUndrugPackageDetailByCode(oldOrder.Item.ID);
                    foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in al)
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug tmpUndrug = tempManagerFee.GetItem(undrug.ID);
                        Neusoft.HISFC.Models.Order.Inpatient.Order myorder = null;
                        decimal qty = oldOrder.Qty;
                        myorder = oldOrder.Clone();
                        myorder.Item = tmpUndrug.Clone();
                        myorder.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量
                        myorder.Item.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量
                        myorder.Package.ID = oldOrder.Item.ID;//符合项目编码
                        myorder.Package.Name = oldOrder.Item.Name; //符合项目名称
                        alOrderTemp.Add(myorder);
                    }
                }
                else
                {
                    alOrderTemp.Add(alOrder[i]);
                }
            }
            alOrder = alOrderTemp;

            #endregion

            #region 插入收费，并更新可退数量

            if ((alOrder == null || alOrder.Count == 0) && (alFeeItemList == null || alFeeItemList.Count == 0))
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有选择保存的医嘱数据！"));
                return 100;
            }

            if (alFeeItemList != null && alOrder.Count > 0)
            {
                #region 判断是否已经确认过，避免在两台机器确认两次的情况 modified by xizf20101220 {B98851B0-9C5A-4d68-ABB5-CB48C4DBD34B}
                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order temporder in alOrder)
                {
                    string exec_sqn = temporder.User03;
                    if (this.feeManager.GetTecFlag(exec_sqn)) {
                        MessageBox.Show("某些项目可能已经确认,请输入住院号重试");
                        return -1;
                    }
                
                }
                #endregion
                iReturn = this.feeManager.FeeItem(this.myPatient, ref alOrder);
                if (iReturn < 0)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("收取患者费用失败！" + this.feeManager.Err));
                    return iReturn;
                }
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alOrder)
                {
                    //{07D1BACB-8E4F-4ac8-8254-81763D0F0699}
                    iReturn = this.feeManager.UpdateNoBackQtyForUndrug(feeItem.RecipeNO, feeItem.SequenceNO, feeItem.Item.Qty, feeItem.BalanceState);
                    if (iReturn < 0)
                    {
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                        feeManager.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新费用明细可退数量失败！" + this.feeManager.Err));
                        return -1;
                    }
                    iReturn = this.feeManager.UpdateExtFlagForUndrug(feeItem.RecipeNO, feeItem.SequenceNO, "5", feeItem.BalanceState);
                    if (iReturn < 0)
                    {
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                        feeManager.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新费用明细扩展标记失败！" + this.feeManager.Err));
                        return -1;
                    }

                    #region addby xuewj 2010-9-21 {9300A7AC-DA0F-472d-B2CF-7F509CB8BE72} 终端确认调用记账单
                    if (isPrintFeeSheet)
                    {
                        if (feeItem.RecipeNO != "" && !paramRecipeNO.Contains(feeItem.RecipeNO))
                        {
                            paramRecipeNO = "'" + feeItem.RecipeNO + "'," + paramRecipeNO;
                        }
                    } 
                    #endregion
                }

            }
            if (alFeeItemList != null && alFeeItemList.Count > 0)
            {
                iReturn = this.feeManager.FeeItem(this.myPatient, ref alFeeItemList);
                if (iReturn < 0)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("收取患者费用失败！" + this.feeManager.Err));
                    return iReturn;
                }

                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alFeeItemList)
                {
                    //{07D1BACB-8E4F-4ac8-8254-81763D0F0699}
                    iReturn = this.feeManager.UpdateNoBackQtyForUndrug(feeItem.RecipeNO, feeItem.SequenceNO, feeItem.Item.Qty, feeItem.BalanceState);
                    if (iReturn < 0)
                    {
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                        feeManager.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新费用明细可退数量失败！" + this.feeManager.Err));
                        return -1;
                    }
                    iReturn = this.feeManager.UpdateExtFlagForUndrug(feeItem.RecipeNO, feeItem.SequenceNO, "5", feeItem.BalanceState);
                    if (iReturn < 0)
                    {
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                        feeManager.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新费用明细扩展标记失败！" + this.feeManager.Err));
                        return -1;
                    }

                    #region addby xuewj 2010-9-21 {9300A7AC-DA0F-472d-B2CF-7F509CB8BE72} 终端确认调用记账单
                    if (isPrintFeeSheet)
                    {
                        if (feeItem.RecipeNO != "" && !paramRecipeNO.Contains(feeItem.RecipeNO))
                        {
                            paramRecipeNO = "'" + feeItem.RecipeNO + "'," + paramRecipeNO;
                        }
                    } 
                    #endregion
                }

            }

            #endregion

            #region 插入终端
            //目前不插入终端，需要时修改本部分代码
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alOrder)
            {
                Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail = new Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail();

                #region 构建确认明细
                string applySequence = "";
                int sReturn = terminalMgr.GetNextSequence(ref applySequence);
                if (sReturn == -1)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show("获取确认流水号失败");
                    return -1;
                }
                detail.MoOrder = feeItem.Order.ID;//医嘱流水号 0
                detail.ExecMoOrder = feeItem.ExecOrder.ID;//医嘱内执行单流水号1 
                detail.Sequence = applySequence;//2
                detail.Apply.Item.ID = feeItem.Item.ID;//3
                detail.Apply.Item.Name = feeItem.Item.Name;//4
                detail.Apply.Item.ConfirmedQty = feeItem.Item.Qty;//5
                detail.Apply.ConfirmOperEnvironment.ID = this.oper.ID;//6
                detail.Apply.ConfirmOperEnvironment.Dept.ID = this.oper.Dept.ID;//7
                #region {3EF2F4C8-D9CF-4e8c-87A8-5DA22B2597C8}
                detail.Apply.ConfirmOperEnvironment.OperTime = this.dtNow;//8
                //detail.Apply.ConfirmOperEnvironment.OperTime = System.DateTime.Now;//8
                #endregion
                detail.Status.ID = "0";//9 0-正常，1-取消，2-退费
                detail.Apply.Patient.ID = feeItem.Patient.ID;
                detail.Apply.Item.RecipeNO = feeItem.RecipeNO;
                detail.Apply.Item.SequenceNO = feeItem.SequenceNO;
                //{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
                detail.ExecDevice = feeItem.Item.User01;
                detail.Oper.ID = feeItem.Item.User02;

                #endregion
                if (terminalMgr.InsertInpatientConfirmDetail(detail) == -1)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("插入终端确认明细失败！" + this.confirmIntergrate.Err));
                    return -1;
                }
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alFeeItemList)
            {
                Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail = new Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail();

                #region 构建确认明细
                string applySequence = "";
                int sReturn = terminalMgr.GetNextSequence(ref applySequence);
                if (sReturn == -1)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show("获取确认流水号失败");
                    return -1;
                }
                detail.MoOrder = feeItem.Order.ID;//医嘱流水号 0
                detail.ExecMoOrder = feeItem.ExecOrder.ID;//医嘱内执行单流水号1 
                detail.Sequence = applySequence;//2
                detail.Apply.Item.ID = feeItem.Item.ID;//3
                detail.Apply.Item.Name = feeItem.Item.Name;//4
                detail.Apply.Item.ConfirmedQty = feeItem.Item.Qty;//5
                detail.Apply.ConfirmOperEnvironment.ID = this.oper.ID;//6

                //修改了新增划价项目无确认科室的bug by yuyun {58B76F7C-A35D-4cbb-8948-8163EA3C5191}
                detail.Apply.ConfirmOperEnvironment.Dept.ID = this.oper.Dept.ID;//7
                detail.Apply.ConfirmOperEnvironment.OperTime = this.dtNow;//8
                //---------------------------------------------------------------------------------

                detail.Status.ID = "0";//9 0-正常，1-取消，2-退费
                detail.Apply.Patient.ID = feeItem.Patient.ID;
                detail.Apply.Item.RecipeNO = feeItem.RecipeNO;
                detail.Apply.Item.SequenceNO = feeItem.SequenceNO;
                //{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
                detail.ExecDevice = feeItem.Item.User01;
                detail.Oper.ID = feeItem.Item.User02;
                #endregion
                if (terminalMgr.InsertInpatientConfirmDetail(detail) == -1)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("插入终端确认明细失败！" + this.confirmIntergrate.Err));
                    return -1;
                }
            }
            #endregion

            #region 更新医嘱确认和收费

            foreach (Neusoft.HISFC.Models.Order.ExecOrder execOrder in alNeedExecOrder)
            {
                execOrder.ExecOper.OperTime = dtNow;
                execOrder.ChargeOper.OperTime = dtNow;

                iReturn = this.orderManager.UpdateRecordExec(execOrder);
                if (iReturn < 0)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱确认信息失败！" + this.orderManager.Err));
                    return iReturn;
                }
                iReturn = this.orderManager.UpdateChargeExec(execOrder);
                if (iReturn < 0)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱收费信息失败！" + this.orderManager.Err));
                    return iReturn;
                }
                iReturn = this.orderManager.UpdateOrderStatus(execOrder.Order.ID, 2);
                if (iReturn < 0)
                {
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
                    feeManager.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱主档执行信息失败！" + this.orderManager.Err));
                    return iReturn;
                }
            }

            #endregion

            //Neusoft.FrameWork.Management.PublicTrans.Commit();
            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}
            feeManager.Commit();
            for (int i = this.fpExecOrder.Sheets[0].RowCount - 1; i >= 0; i--)
            {

                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.IsExec].Value))
                {
                    if (clearConfirm)
                    {
                        this.fpExecOrder.Sheets[0].Rows.Remove(i, 1);
                    }
                    else
                    {
                        this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.IsExec].Value = false;
                        this.fpExecOrder.Sheets[0].Cells[i, (int)Cols.IsExec].Locked = true;
                        this.fpExecOrder_Sheet1.Rows[i].BackColor = System.Drawing.Color.Azure;
                    }
                }
            }

            #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
            
            if (!string.IsNullOrEmpty(isUseDL) && isUseDL == "1")
            {
                try
                {
                    if (PACSApplyInterface == null)
                    {
                        PACSApplyInterface = new Neusoft.ApplyInterface.HisInterface();
                    }
                    if (PACSApplyInterface != null)
                    {
                        foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in alOrder)
                        {
                            if (f.Item.SysClass.ID.ToString() == "UC" && f.Order.ID != null)
                            {
                                try
                                {
                                    string applyNo = string.Empty;
                                    terminalMgr.GetApplyNoByOrderNo(f.Order.ID, ref applyNo);
                                    Neusoft.HISFC.Models.Order.Inpatient.Order order = orderManager.QueryOneOrder(f.Order.ID);
                                    applyNo = order.ApplyNo;
                                    int a = PACSApplyInterface.Charge(applyNo, "1");
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("更新电子申请单收费标志时出错：\n" + e.Message);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            #endregion

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("确认成功！"));
            this.ucQueryInpatientNo1.Focus();
            #region  打印
            if (this.IsPrint)
            {
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj in alOrder)
                {
                    if (OnPrint(new object(), obj) == -1)
                    {
                        return -1;
                    }
                }
            }
            #endregion

            #region addby xuewj 2010-9-21 {9300A7AC-DA0F-472d-B2CF-7F509CB8BE72} 终端确认调用记账单
            if (this.isPrintFeeSheet)
            {
                if (paramRecipeNO != "")
                {
                    MessageBox.Show("即将打印——记账单，请确认打印机已就位？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        paramRecipeNO = paramRecipeNO.Substring(0, paramRecipeNO.Length - 1);
                    if (this.nurseFeeBill == null)
                    {
                        this.nurseFeeBill = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet)) as Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet;
                    }
                    if (this.nurseFeeBill != null)
                    {
                        DateTime endDate = this.terminalManager.GetDateTimeFromSysDateTime();
                        this.nurseFeeBill.NurseFeeBill(beginDate, endDate, paramRecipeNO);
                    }

                }
            }
            #endregion
            return 0;
        }

        /// <summary>
        /// 显示检查申请单
        /// </summary>
        private void ShowPacsApply(int rowIndex)
        {
            if (!string.IsNullOrEmpty(isUseDL) && isUseDL == "1")
            {
                #region {5E5299D8-95A2-4498-B2F1-52D00E4FB11A} UpdateApply需要使用Neusoft.HISFC.Components.PacsApply.HisInterface,以后需要电子申请单重构到Neusoft.ApplyInterface.HisInterface中
                //if (PACSApplyInterface == null)
                //{
                //    PACSApplyInterface = new Neusoft.ApplyInterface.HisInterface();
                //}
                //int rowIndex = this.fpExecOrder.Sheets[0].ActiveRowIndex;
                if (rowIndex == -1)
                {
                    return;
                }
                if (PACSApplyInterfaceNew == null)
                {
                    PACSApplyInterfaceNew = new Neusoft.HISFC.Components.PacsApply.HisInterface(Neusoft.FrameWork.Management.Connection.Operator.ID, (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID);
                }                
                #endregion
                
                if (this.fpExecOrder.Sheets[0].Cells[rowIndex, (int)Cols.OrderType].Text == "ORDER")
                {
                    Neusoft.HISFC.Models.Order.ExecOrder exeOrder = new Neusoft.HISFC.Models.Order.ExecOrder(); ;
                    exeOrder = (Neusoft.HISFC.Models.Order.ExecOrder)this.fpExecOrder.Sheets[0].Rows[rowIndex].Tag;
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = orderManager.QueryOneOrder(exeOrder.Order.ID);
                    if (order == null || order.Item.SysClass.ID.ToString() != "UC")
                        return;
                    if (!string.IsNullOrEmpty(order.ApplyNo))
                    {
                        #region {5E5299D8-95A2-4498-B2F1-52D00E4FB11A}
                        //if (PACSApplyInterface.UpdateApply(order.ApplyNo) < 0)
                        if (PACSApplyInterfaceNew.UpdateApply(order.ApplyNo) < 0)
                        #endregion
                        {
                            MessageBox.Show("查询电子申请单失败！");
                        }
                    }
                }
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            return base.OnSave(sender, neuObject);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 表格EditChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpExecOrder_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string source = this.fpExecOrder.Sheets[0].Cells[e.Row, (int)Cols.OrderType].Text.ToString();
            if (source == "NEW")//e.Row == this.currentRow &&
            {
                if (e.Column == 3)
                {
                    System.Windows.Forms.Control cellControl = this.fpExecOrder.EditingControl;
                    //设置位置
                    this.ucItemList.Location = new System.Drawing.Point(cellControl.Location.X, cellControl.Location.Y + cellControl.Height + 40);
                    ucItemList.BringToFront();
                    // 过滤项目
                    this.ucItemList.Filter(this.fpExecOrder_Sheet1.ActiveCell.Text);
                    this.ucItemList.Visible = true;
                    // 保存当前行，用于保证移动上下箭头不改变当前记录
                    this.fpExecOrder_Sheet1.ActiveRowIndex = e.Row;
                    this.currentRow = e.Row;
                }
                else
                {
                    this.UnDisplayUcItemList();
                }
            }
        }

        /// <summary>
        /// 表格回车
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int fpExecOrder_KeyEnter(Keys key)
        {
            if (key == Keys.Up)
            {
                if (this.ucItemList.Visible)
                {

                    this.ucItemList.PriorRow();
                    this.fpExecOrder_Sheet1.ActiveRowIndex = this.currentRow;
                }
                return 0;
            }
            if (key == Keys.Escape)
            {
                if (this.ucItemList.Visible)
                {

                    this.ucItemList.Visible = false;
                }
                return 0;
            }
            if (key == Keys.Down)
            {
                if (this.ucItemList.Visible)
                {
                    this.ucItemList.NextRow();
                    this.fpExecOrder_Sheet1.ActiveRowIndex = this.currentRow;
                }
                return 0;
            }

            if (key == Keys.Enter)
            {
                if (this.fpExecOrder.Sheets[0].ActiveColumnIndex == (int)Cols.ItemName)
                {
                    this.InsertItem();
                    this.fpExecOrder_Sheet1.ActiveColumnIndex = (int)Cols.ItemConfirmQty;
                    return 0;
                }
                #region 更改确认数量
                if (this.fpExecOrder.Sheets[0].ActiveColumnIndex == (int)Cols.ItemConfirmQty)
                {
                    decimal price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Price].Text);
                    decimal qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.ItemConfirmQty].Text);
                    this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.TotCost].Text = Convert.ToString(price * qty);
                    #region addby xuewj 2010-9-27 {C3F7C1B0-97BA-4001-A0B8-6AAB8785C90D} 增加合计
                    decimal totCost = this.SumCost();
                    int activeRowIndex = this.fpExecOrder.Sheets[0].RowCount - 1;
                    this.fpExecOrder.Sheets[0].Cells[activeRowIndex, (int)Cols.TotCost].Text = totCost.ToString(); 
                    #endregion

                    if (price == 0)//by zhouxs 2007-10-28
                    {
                        this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder_Sheet1.ActiveRowIndex, (int)Cols.Price].Locked = false;
                        this.fpExecOrder.Sheets[0].SetActiveCell(this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Price);
                        return 0;//end zhouxs
                    }

                    #region addby xuewj 2010-9-27 {C3F7C1B0-97BA-4001-A0B8-6AAB8785C90D} 增加合计
                    //if (this.fpExecOrder_Sheet1.ActiveRowIndex == this.fpExecOrder_Sheet1.Rows.Count - 1)
                    if (this.fpExecOrder_Sheet1.ActiveRowIndex == this.fpExecOrder_Sheet1.Rows.Count - 2) 
                    #endregion
                    {
                        fpExecOrder_Sheet1.SetActiveCell(this.fpExecOrder_Sheet1.ActiveRowIndex, (int)Cols.ItemConfirmQty);
                        if (qty > 0)
                        {
                            if (DialogResult.Yes.Equals(MessageBox.Show("是否增加新收费项目?", "医技终端确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                            {
                                this.AddNewRow();
                            }
                        }
                    }
                    else
                    {
                        fpExecOrder_Sheet1.SetActiveCell(this.fpExecOrder_Sheet1.ActiveRowIndex + 1, (int)Cols.ItemConfirmQty);
                    }
                    return 0;
                }
                #endregion
                if (this.fpExecOrder.Sheets[0].ActiveColumnIndex == (int)Cols.Price)
                {
                    decimal price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Price].Text);
                    decimal qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.ItemConfirmQty].Text);
                    this.fpExecOrder.Sheets[0].Cells[this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.TotCost].Text = Convert.ToString(price * qty);
                    this.fpExecOrder.Sheets[0].SetActiveCell(this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.ItemConfirmQty);
                    return 0;
                }
                //by yuyun 08-7-8{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
                if (this.fpExecOrder.Sheets[0].ActiveColumnIndex == (int)Cols.Machine)
                {
                    this.fpExecOrder.Sheets[0].SetActiveCell(this.fpExecOrder.Sheets[0].ActiveRowIndex, (int)Cols.Operator);
                }

            }

            return 0;
        }


        #endregion

        protected override int OnPrint(object sender, object neuObject)
        {
            #region {019B78E5-8076-4d17-8CEE-4F2FC66AD0D3}
            return base.OnPrint(sender, neuObject);
            #endregion
            if (this.terminalInterface == null)
            {
                this.terminalInterface = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(TerminalInterface)) as TerminalInterface;
                if (this.terminalInterface == null)
                {
                    MessageBox.Show("获得接口TerminalInterface错误\n，可能没有维护相关的打印控件或打印控件没有实现接口TerminalInterface\n请与系统管理员联系。");
                    return -11;
                }
            }
            if (this.terminalInterface.Reset() == -1)
            {
                return -1;
            }
            //for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            //{
            if (this.terminalInterface.ControlValue(neuObject) == -1)
            {
                return -1;
            }
            if (this.terminalInterface.Print() == -1)
            {
                return -1;
            }
            return base.OnPrint(sender, neuObject);
        }
        private void ucInpatientConfirm_Load(object sender, EventArgs e)
        {
            if (this.tv != null)
            {
                try
                {
                    tvInpatientConfirm t = (tvInpatientConfirm)tv;
                    if (this.seeAll)
                    {
                        t.OperDept = "all";
                        //t.Init();  
                    }
                    t.Init();

                }
                catch
                { }
            }
        }


        #region IInterfaceContainer 成员
        TerminalInterface terminalInterface = null;
        public Type[] InterfaceTypes
        {
            get { return new Type[] { typeof(TerminalInterface) ,
		typeof(Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet)// {9300A7AC-DA0F-472d-B2CF-7F509CB8BE72} 终端确认调用记账单
            }; }
        }

        #endregion

        private void fpExecOrder_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            ShowPacsApply(e.Row);
        }
    }
}

