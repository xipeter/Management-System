using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医嘱分解控件的说]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucOrderExecConfirm : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucOrderExecConfirm()
        {
            InitializeComponent();
        }

        protected Neusoft.HISFC.BizLogic.Order.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.Order();
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeManagement = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        
        protected DateTime dt;
        Hashtable sendFlag;

        bool tab0AllSelect = false;
        bool tab1AllSelect = false;

        #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
        /// <summary>
        /// 科室业务类
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 科室列表
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        #endregion

        #region 属性
        protected ArrayList al = new ArrayList();
        /// <summary>
        /// 人员列表
        /// </summary>
        public ArrayList alPatients
        {
            get
            {
                if (al == null) al = new ArrayList();
                return al;
            }
            set
            {
                this.al = value;
            }
        }
        protected int intDyas = 1;
        /// <summary>
        /// 摆药天数
        /// </summary>
        [Description("摆药最大天数设置")]
        public int Days
        {
            set
            {
                this.intDyas = value;
                //this.txtDays.Value = (decimal)value;
                this.txtDays.Maximum = this.intDyas;
            }
            get
            {
                return this.intDyas;
            }
        }

        /// <summary>
        /// 显示的信息
        /// </summary>
        [Description("显示给用户的提示信息。")]
        public string Tip
        {
            get
            {
                return this.neuLabel3.Text;
            }
            set
            {
                this.neuLabel3.Text = value;
            }
        }

        #region 欠费不允许分解写死 {4AE738A2-AC87-447c-86E3-ECE465B7C4D1}
        protected EnumLackFee lackfee = EnumLackFee.欠费不允许分解;
        /// <summary>
        /// 欠费操作
        /// </summary>
        [Description("欠费后的操作")]
        public EnumLackFee 欠费操作
        {
            get
            {
                return this.lackfee;
            }
            set
            {
                this.lackfee = EnumLackFee.欠费不允许分解;
            }
        }
        #endregion
        #region {C88D3BEB-EA3F-455f-BD5D-0A997699CC2C}
        protected bool isSaveErrContinue = true;
        /// <summary>
        /// 保存出错后，是否继续进行其它患者保存
        /// </summary>
        [Description("保存出错后，是否继续进行其它患者保存")]
        public bool IsSaveErrContinue
        {
            get
            {
                return this.isSaveErrContinue;
            }
            set
            {
                this.isSaveErrContinue = value;
            }
        }

        #region {BEAB5DD3-9278-4480-BCFC-9E15469B3376} 屏蔽显示护理医嘱 by guanyx
        private bool isShowNurseFee = false;
        //[Category("控件设置"), Description("是否显示分解的护理费，True:显示 False:不显示")]
        //public bool IsShowNurseFee
        //{
        //    get
        //    {
        //        return isShowNurseFee;
        //    }
        //    set
        //    {
        //        isShowNurseFee = value;
        //    }
        //}
        #endregion

        #endregion
        #endregion

        #region 函数
        /// <summary>
        /// 初始化FpSpread
        /// </summary>
        private void InitControl()
        {
            this.fpOrderExecBrowser1.IsShowRowHeader = false;
            this.fpOrderExecBrowser2.IsShowRowHeader = false;
            this.TabControl1.SelectedIndex = 1;
            this.TabControl1.SelectedIndex = 0;

            this.fpOrderExecBrowser1.fpSpread.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread_CellDoubleClick);
            this.fpOrderExecBrowser2.fpSpread.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread_CellDoubleClick);

            this.fpOrderExecBrowser1.fpSpread.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(fpSpread_ButtonClicked);
            this.fpOrderExecBrowser2.fpSpread.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(fpSpread_ButtonClicked);

            #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
            this.deptHelper.ArrayObject = this.deptManager.GetDeptmentAllValid();
            #endregion

            #region donggq--20101110--设定时间默认为00：00:00-->23:59:59--{DE1A9E11-EF26-40eb-A8B2-E6039B8CBF50}
            this.dtpBeginTime.Value = this.dtpBeginTime.Value.Date;
            this.dtpEndTime.Value = this.dtpEndTime.Value.Date.AddDays(1).AddSeconds(-1); 
            #endregion

        }
        /// <summary>
        /// 查询执行档--分解医嘱
        /// </summary>
        /// <returns></returns>
        public int RefreshExec()
        {

            //取小时收费 {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            string frequencyID = controlManager.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.MetConstant.Hours_Frequency_ID, true);

            
            string DeptCode = ""; //病区
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.orderManagement.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            ArrayList alOrders = null;
            Neusoft.HISFC.BizProcess.Integrate.RADT pManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            try
            {
                #region 分解审核过的医嘱
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在分解，请稍候...");
                Application.DoEvents();
                
                this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                pManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //分解的操作时间,避免分解时每条医嘱都查询系统时间
                DateTime dt = new DateTime();
                dt = this.orderManagement.GetDateTimeFromSysDateTime();

                //对每个患者的医嘱分解
                for (int i = 0; i < this.al.Count; i++)
                {
                    //患者信息
                    Neusoft.HISFC.Models.RADT.PatientInfo pTemp = al[i] as Neusoft.HISFC.Models.RADT.PatientInfo;
                    if (pTemp == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("获得患者基本信息错误！");
                        return -1;
                    }

                    Neusoft.HISFC.Models.RADT.PatientInfo p = pManager.GetPatientInfomation(pTemp.ID);
                    if (p == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("获得患者基本信息错误" + pManager.Err);
                        return -1;
                    }
                    if (p.PVisit.InState.ID.ToString() == "O" ||
                        p.PVisit.InState.ID.ToString() == "P" || p.PVisit.InState.ID.ToString() == "N")
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(p.Name + "患者 已出院 无法进行医嘱分解操作");
                        return -1;
                    }

                    //由医嘱主表内检索医嘱状态为1 或 2的医嘱
                    alOrders = orderManagement.QueryValidOrderWithSubtbl(p.ID, Neusoft.HISFC.Models.Order.EnumType.LONG);
                    if (alOrders == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(orderManagement.Err);
                        return -1;
                    }
                    //分解患者的医嘱
                    for (int j = 0; j < alOrders.Count; j++)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order order = (Neusoft.HISFC.Models.Order.Inpatient.Order)alOrders[j];
                        #region 更改科室
                        DeptCode = order.ReciptDept.ID;//开单科室
                        //医嘱实体中的患者在院科室重新赋值
                        order.Patient.PVisit.PatientLocation.Dept.ID = p.PVisit.PatientLocation.Dept.ID;
                        order.Patient.PVisit.PatientLocation.NurseCell.ID = p.PVisit.PatientLocation.NurseCell.ID;
                        #endregion

                        if (order.Usage.ID == "03")   //iv.dri
                        {
                            order.Compound.IsNeedCompound = true;
                        }

                        //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                        if (order.Frequency.ID == frequencyID) //小时收费医嘱，分解时间到当前时间
                        {
                            if (orderManagement.DecomposeOrderToNow(order, 0, false, dt) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                ;
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show(orderManagement.Err);
                                return -1;
                            }
                        }

                        else
                        {
                            //对医嘱进行分解
                            if (orderManagement.DecomposeOrder(order, this.intDyas, false, dt) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                ;
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show(orderManagement.Err);
                                return -1;
                            }
                        }
                    }
                }
                
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                #endregion
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("分解出错！" + ex.Message + this.orderManagement.iNum.ToString());
                return -1;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.RefreshQuery();
            return 0;
        }
        bool bOnQuery = false;
        /// <summary>
        /// 更新查询显示
        /// </summary>
        /// <returns></returns>
        protected int RefreshQuery()
        {
            if (bOnQuery) return 0;
            bOnQuery = true;
            //this.fpOrderExecBrowser1.BeginInit();
            //this.fpOrderExecBrowser2.BeginInit();
            try
            {
                this.txtName.Items.Clear();
                ArrayList alOrders = null;
                #region 查询显示
                this.fpOrderExecBrowser1.Clear();
                this.fpOrderExecBrowser2.Clear();

                #region {D0618339-0E36-4d35-A8EF-C4F9E352C71B}
                Neusoft.FrameWork.Public.ObjectHelper orderNameHlpr = new Neusoft.FrameWork.Public.ObjectHelper();
                Neusoft.FrameWork.Public.ObjectHelper deptNameHlpr = new Neusoft.FrameWork.Public.ObjectHelper();
                Neusoft.FrameWork.Models.NeuObject objTmp = new Neusoft.FrameWork.Models.NeuObject();
                #endregion

                #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
                Neusoft.FrameWork.Public.ObjectHelper orderTypeNameHlpr = new Neusoft.FrameWork.Public.ObjectHelper(); 
                #endregion

                for (int i = 0; i < this.al.Count; i++)
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo p = al[i] as Neusoft.HISFC.Models.RADT.PatientInfo;
                    if (feeManagement.IsPatientLackFee(p) == true) //欠费患者
                    {
                        switch (this.lackfee)
                        {
                            case EnumLackFee.不判断欠费:
                                break;
                            case EnumLackFee.欠费不允许分解:
                                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(
                                    string.Format("患者{0}已经欠费,剩余金额{1}.不能进行分解操作。", p.Name, p.FT.LeftCost.ToString())));
                                continue;
                                break;
                            case EnumLackFee.欠费提示允不允许分解:
                                if (MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(
                                    string.Format("患者{0}已经欠费,剩余金额{1}.是否继续分解操作。", p.Name, p.FT.LeftCost.ToString())), "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    continue;
                                }
                                break;

                        }
                    }
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询" + p.Name + "，请稍候...");
                    #region 查询分解操作
                    alOrders = orderManagement.QueryExecOrderIsExec(p.ID, "1", false);//查询确认的药品 
                    #region {D0618339-0E36-4d35-A8EF-C4F9E352C71B}
                    //Neusoft.FrameWork.Public.ObjectHelper orderNameHlpr = new Neusoft.FrameWork.Public.ObjectHelper();
                    //Neusoft.FrameWork.Public.ObjectHelper deptNameHlpr = new Neusoft.FrameWork.Public.ObjectHelper();
                    //Neusoft.FrameWork.Models.NeuObject objTmp = new Neusoft.FrameWork.Models.NeuObject();
                    #endregion
                    for (int j = 0; j < alOrders.Count; j++)
                    {
                        Neusoft.HISFC.Models.Order.ExecOrder order = alOrders[j] as Neusoft.HISFC.Models.Order.ExecOrder;
                        order.Order.Patient = p;

                        #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}

                        string drugDept = this.deptHelper.GetName(order.Order.StockDept.ID);

                        #endregion

                        if (order.Order.OrderType.IsDecompose)
                        {
                            this.fpOrderExecBrowser1.AddRow(order);
                            objTmp = new Neusoft.FrameWork.Models.NeuObject(order.Order.Item.Name, order.Order.Item.Name, "");
                            if (orderNameHlpr.GetObjectFromID(objTmp.ID) == null)
                            {
                                orderNameHlpr.ArrayObject.Add(objTmp);
                            }
                            #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
                            if (!string.IsNullOrEmpty(drugDept))
                            {
                                objTmp = new Neusoft.FrameWork.Models.NeuObject(drugDept, drugDept, "");
                                if (deptNameHlpr.GetObjectFromID(objTmp.ID) == null)
                                {
                                    deptNameHlpr.ArrayObject.Add(objTmp);
                                }
                            }
                            #endregion
                            #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}                            
                            if (orderTypeNameHlpr.GetObjectFromID(order.Order.OrderType.ID) == null)
                            {
                                objTmp=new Neusoft.FrameWork.Models.NeuObject(order.Order.OrderType.ID, this.fpOrderExecBrowser1.orderTypeHelper.GetName(order.Order.OrderType.ID), "");
                                orderTypeNameHlpr.ArrayObject.Add(objTmp);
                            }
                            #endregion
                        }
                    }
                    //非药品
                    alOrders = orderManagement.QueryExecOrderIsExec(p.ID, "2", false);//查询未执行的非药品
                    for (int j = 0; j < alOrders.Count; j++)
                    {
                        Neusoft.HISFC.Models.Order.ExecOrder order = alOrders[j] as Neusoft.HISFC.Models.Order.ExecOrder;
                        order.Order.Patient = p;
                        //显示需要护士站确认的非药品
                        if ((((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Order.Item).IsNeedConfirm == false ||
                            order.Order.ExeDept.ID == order.Order.ReciptDept.ID ||
                            order.Order.ExeDept.ID == NurseStation.ID)) //护士站收费或者执行科室＝＝科室  
                        {
                            if (order.Order.OrderType.IsDecompose) //长期医嘱
                            {
                                #region {BEAB5DD3-9278-4480-BCFC-9E15469B3376} 屏蔽显示护理医嘱 by guanyx
                                if (this.isShowNurseFee == false)
                                {
                                    if (order.Order.Item.SysClass.ID.ToString() != "UN")
                                    {
                                        this.fpOrderExecBrowser2.AddRow(order);
                                    }
                                }
                                else
                                {
                                    this.fpOrderExecBrowser2.AddRow(order);
                                }
                                //this.fpOrderExecBrowser2.AddRow(order);
                                #endregion
                                objTmp = new Neusoft.FrameWork.Models.NeuObject(order.Order.Item.Name, order.Order.Item.Name, "");
                                if (orderNameHlpr.GetObjectFromID(objTmp.ID) == null)
                                {
                                    orderNameHlpr.ArrayObject.Add(objTmp);
                                }
                                #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
                                if (orderTypeNameHlpr.GetObjectFromID(order.Order.OrderType.ID) == null)
                                {
                                    objTmp = new Neusoft.FrameWork.Models.NeuObject(order.Order.OrderType.ID, this.fpOrderExecBrowser1.orderTypeHelper.GetName(order.Order.OrderType.ID), "");
                                    orderTypeNameHlpr.ArrayObject.Add(objTmp);
                                }
                                #endregion
                            }
                        }
                    }

                    #region {D0618339-0E36-4d35-A8EF-C4F9E352C71B}
                    //objTmp = new Neusoft.FrameWork.Models.NeuObject("ALL", "全部", "");
                    //orderNameHlpr.ArrayObject.Insert(0, objTmp);
                    //this.txtName.AddItems(orderNameHlpr.ArrayObject);
                    //this.txtName.Tag = "ALL";
                    //objTmp = new Neusoft.FrameWork.Models.NeuObject("ALL", "全部", "");
                    //deptNameHlpr.ArrayObject.Insert(0, objTmp);
                    //this.txtDrugDeptName.AddItems(deptNameHlpr.ArrayObject);
                    //this.txtDrugDeptName.Tag = "ALL";
                    #endregion

                    #endregion
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                }
                #endregion

                #region {D0618339-0E36-4d35-A8EF-C4F9E352C71B}
                objTmp = new Neusoft.FrameWork.Models.NeuObject("ALL", "全部", "");
                orderNameHlpr.ArrayObject.Insert(0, objTmp);
                this.txtName.AddItems(orderNameHlpr.ArrayObject);
                this.txtName.Tag = "ALL";
                objTmp = new Neusoft.FrameWork.Models.NeuObject("ALL", "全部", "");
                deptNameHlpr.ArrayObject.Insert(0, objTmp);
                this.txtDrugDeptName.AddItems(deptNameHlpr.ArrayObject);
                this.txtDrugDeptName.Tag = "ALL";
                #endregion
                #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
                orderTypeNameHlpr.ArrayObject.Insert(0, objTmp);
                this.cmbOrderTypeName.AddItems(orderTypeNameHlpr.ArrayObject);
                this.cmbOrderTypeName.Tag = "ALL";
                #endregion
                this.fpOrderExecBrowser1.RefreshComboNo();
                this.fpOrderExecBrowser2.RefreshComboNo();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                //{E08AD6B3-4987-44b0-A5A9-B660D24FBC4D}
                //护士重新计算时，先计算2天 然后在计算1天的时候 删除多余的数据（界面上删除）
                this.fpOrderExecBrowser1.DeleteRow(this.intDyas);
                this.fpOrderExecBrowser2.DeleteRow(this.intDyas);
                this.tabPage1.Text = "药品" + "【" + this.fpOrderExecBrowser1.GetFpRowCount(0).ToString() + "条】";
                this.tabPage2.Text = "非药品" + "【" + this.fpOrderExecBrowser2.GetFpRowCount(0).ToString() + "条】";

                //for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                //{
                //    this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexSelection].Value = true;
                //}
                //for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                //{
                //    this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser2.ColumnIndexSelection].Value = true;
                //}
            }
            catch { }
            //this.fpOrderExecBrowser1.EndInit();
            //this.fpOrderExecBrowser2.EndInit(); 
            bOnQuery = false;

            return 0;
        }

        /// <summary>
        /// 护士站属性
        /// </summary>
        protected Neusoft.FrameWork.Models.NeuObject NurseStation
        {
            get
            {
                return ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.Clone();
            }
        }

        
        /// <summary>
        /// 发送医嘱
        /// </summary>
        /// <returns></returns>
        public int ComfirmExec()
        {
            if (Neusoft.FrameWork.WinForms.Classes.Function.Msg("是否确定要保存？", 422) == DialogResult.No)
            {
                return -1;
            }
            this.btnSave.Enabled = false;
            Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();
            Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存数据，请稍候...");
            Application.DoEvents();
            dt = this.orderManagement.GetDateTimeFromSysDateTime();

            Neusoft.HISFC.Models.Order.ExecOrder order = null;
            string inpatientNo = "";
            List<Neusoft.HISFC.Models.Order.ExecOrder> alOrders = null;
            Neusoft.HISFC.Models.RADT.PatientInfo patient = null;

            //{B2E4E2ED-08CF-41a8-BF68-B9DF7454F9BB} 欠费判断
            Neusoft.HISFC.Models.Base.MessType messType =  Neusoft.HISFC.Models.Base.MessType.M;
            switch (欠费操作)
            {
                case EnumLackFee.不判断欠费:
                    messType = Neusoft.HISFC.Models.Base.MessType.N;
                    break;
                case EnumLackFee.欠费不允许分解:
                    messType = Neusoft.HISFC.Models.Base.MessType.Y;
                    break;
                case EnumLackFee.欠费提示允不允许分解:
                    messType = Neusoft.HISFC.Models.Base.MessType.M;
                    break;
            }

            orderIntegrate.MessageType = messType;
            //{B2E4E2ED-08CF-41a8-BF68-B9DF7454F9BB}
            
            for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].RowCount; i++)
            {
                if (this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexSelection].Text.ToUpper() == "TRUE")
                {
                    order = this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Order.ExecOrder;                   

                    if (inpatientNo != order.Order.Patient.ID)
                    {
                        if (patient != null) //上一个患者
                        {
                            if (orderIntegrate.ComfirmExec(patient, alOrders, NurseStation.ID, dt, true) == -1)
                            {
                                orderIntegrate.fee.Rollback();
                                this.btnSave.Enabled = true;

                                //Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                #region {C88D3BEB-EA3F-455f-BD5D-0A997699CC2C}
                                //添加提示，某个患者出错以后，可选择是否继续其它病人分解
                                //MessageBox.Show(orderIntegrate.Err);
                                //return -1;
                                if (this.isSaveErrContinue)
                                {
                                    if (MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(
                                        string.Format("{0}.是否继续执行分解其他患者的操作。", orderIntegrate.Err)), "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                                    {
                                        return -1;
                                    }
                                    this.btnSave.Enabled = true;
                                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                                    orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                    radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                    this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存数据，请稍候...");
                                    Application.DoEvents();
                                }
                                else
                                {
                                    MessageBox.Show(orderIntegrate.Err);
                                    return -1;
                                }
                                #endregion
                            }
                            //}{B3173852-136F-4c4b-9FAC-E15EB879C619}代码在这里弄个}不知道为什么？这么写要人命啊
                            else
                            {
                                orderIntegrate.fee.Commit();
                                //Neusoft.FrameWork.Management.Transaction 
                                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                                //t.BeginTransaction();
                                orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            }
                        }//{B3173852-136F-4c4b-9FAC-E15EB879C619}}上面的}应该在这里啊
                        inpatientNo = order.Order.Patient.ID;
                        patient = radtIntegrate.GetPatientInfomation(inpatientNo);
                        alOrders = new List<Neusoft.HISFC.Models.Order.ExecOrder>();

                    }
                    alOrders.Add(order);

                }
            }
            if (patient != null) //上一个患者
            {
                if (orderIntegrate.ComfirmExec(patient, alOrders, NurseStation.ID, dt,true) == -1)
                {
                    orderIntegrate.fee.Rollback();
                    this.btnSave.Enabled = true;
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(orderIntegrate.Err);
                    return -1;
                }
                else
                {
                    orderIntegrate.fee.Commit();
                    //Neusoft.FrameWork.Management.Transaction 
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();
                    orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                }
            }

            alOrders = new List<Neusoft.HISFC.Models.Order.ExecOrder>();
            patient = null;
            inpatientNo = "";
            for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].RowCount; i++)
            {
                if (this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser2.ColumnIndexSelection].Text.ToUpper() == "TRUE")
                {
                    order = this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Order.ExecOrder;
                    if (inpatientNo != order.Order.Patient.ID)
                    {
                        if (patient != null) //上一个患者
                        {
                            if (orderIntegrate.ComfirmExec(patient, alOrders, NurseStation.ID, dt,false) == -1)
                            {
                                orderIntegrate.fee.Rollback();
                                this.btnSave.Enabled = true;
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                //Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                #region {C88D3BEB-EA3F-455f-BD5D-0A997699CC2C}
                                //添加提示，某个患者出错以后，可选择是否继续其它病人分解
                                //MessageBox.Show(orderIntegrate.Err);
                                //return -1;
                                if (this.isSaveErrContinue)
                                {
                                    if (MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(
                                        string.Format("{0}.是否继续执行分解其他患者的操作。", orderIntegrate.Err)), "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                                    {
                                        return -1;
                                    }
                                    this.btnSave.Enabled = false; ;
                                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                                    orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                    radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                    this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存数据，请稍候...");
                                    Application.DoEvents();
                                }
                                else
                                {
                                    MessageBox.Show(orderIntegrate.Err);
                                    return -1;
                                }
                                #endregion
                            }
                            else
                            {
                                orderIntegrate.fee.Commit();
                                //Neusoft.FrameWork.Management.Transaction 
                                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                                //t.BeginTransaction();
                                orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            }
                        }
                        inpatientNo = order.Order.Patient.ID;
                        patient = radtIntegrate.GetPatientInfomation(inpatientNo);
                        alOrders = new List<Neusoft.HISFC.Models.Order.ExecOrder>();

                    }
                    alOrders.Add(order);

                }
            }
            if (patient != null) //上一个患者
            {
                if (orderIntegrate.ComfirmExec(patient, alOrders, NurseStation.ID, dt,false) == -1)
                {
                    orderIntegrate.fee.Rollback();
                    this.btnSave.Enabled = true;
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(orderIntegrate.Err);
                    return -1;
                }
                else
                {
                    orderIntegrate.fee.Commit();
                    //Neusoft.FrameWork.Management.Transaction 
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();
                    orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                }
            }
            orderIntegrate.fee.Commit();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.btnSave.Enabled = true;
            bOnQuery = false;
            this.RefreshQuery();
            return 0;
        }
        /// <summary>
        /// 设置发药标志位
        /// </summary>
        private void SetSendFlag()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList al = manager.QueryDepartment(this.NurseStation.ID);
            sendFlag = new Hashtable();
            for (int i = 0; i < al.Count; i++)
            {
                //if (Function.IsHaveDruged(((Neusoft.FrameWork.Models.NeuObject)al[i]).ID))
                //{
                //    sendFlag.Add(((Neusoft.FrameWork.Models.NeuObject)al[i]).ID, 2);//临时发送
                //}
                //else
                //{
                //    sendFlag.Add(((Neusoft.FrameWork.Models.NeuObject)al[i]).ID, 0);//待发送
                //}
            }
        }


        /// <summary>
        /// 选择过滤项目
        /// {ED1068B5-53FD-4bf4-A270-49AE1A70D225}
        /// </summary>
        private void CheckFilteredData()
        {
            for (int i = 0; i < this.CurrentBrowser.fpSpread.Sheets[0].Rows.Count; i++)
            {
                if (this.CurrentBrowser.fpSpread.Sheets[0].Rows[i].BackColor == Color.LightSkyBlue)
                {
                    Neusoft.HISFC.Models.Order.ExecOrder order = new Neusoft.HISFC.Models.Order.ExecOrder();
                    order = this.CurrentBrowser.fpSpread.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Order.ExecOrder;
                    if (order.Order.Combo.ID != "" && order.Order.Combo.ID != "0")
                    {//这里比较慢，如果同组可以分开，此处不要
                        for (int j = this.CurrentBrowser.fpSpread.Sheets[0].RowCount - 1; j >= 0; j--)
                        {
                            Neusoft.HISFC.Models.Order.ExecOrder objorder = (Neusoft.HISFC.Models.Order.ExecOrder)this.CurrentBrowser.fpSpread.Sheets[0].Rows[j].Tag;
                            if (objorder.Order.Combo.ID == order.Order.Combo.ID && objorder.DateUse == order.DateUse)
                            {
                                this.CurrentBrowser.fpSpread.Sheets[0].Cells[j, 1].Value = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 整合组合过滤函数
        /// {ED1068B5-53FD-4bf4-A270-49AE1A70D225}
        /// </summary>
        /// <param name="isMatchAll"></param>
        /// <param name="prmsDate">执行开始、结束时间</param>
        /// <param name="prmsStr">名称、药房</param>
        protected void SetFilteredFlag(bool isMatchAll, DateTime[] prmsDate, string[] prmsStr)
        {
            bool isHaveFilter = true;
            bool isAllOrderNames = (prmsStr[0] == "全部");
            bool isAllDeptNames = (prmsStr[1] == "全部");
            #region addby xuewj 2010-10-9 增加医嘱类型列 {CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            bool isAllOrderTypeNames = (prmsStr[2] == "全部"); 
            #endregion
            bool isAllTime = (prmsDate[0].ToString() == prmsDate[1].ToString());
            if (isAllOrderNames && isAllDeptNames && isAllTime && isAllOrderTypeNames)//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            {
                isHaveFilter = false;
            }

            Neusoft.HISFC.Models.Order.ExecOrder order = null;
            //初始化显示，药品
            if (this.TabControl1.SelectedIndex == 0)
            {
                bool b = false;
                //恢复原来的颜色
                //间隔颜色显示
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    if (b)
                    {
                        this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.Linen;
                    }
                    else
                    {
                        this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.White;
                    }
                    b = !b;
                }
                if (isHaveFilter)
                {
                    for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                    {
                        order = this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Order.ExecOrder;
                        DateTime splitTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 9].Text);
                        if (isMatchAll)
                        {
                            if ((isAllOrderNames || this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 2].Text == prmsStr[0])
                             && (isAllDeptNames || this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 11].Text == prmsStr[1])
                             && (isAllTime || (splitTime >= prmsDate[0] && splitTime <= prmsDate[1]))
                             && (isAllOrderTypeNames || this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexOrderType].Text == prmsStr[2]))//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
                            {
                                this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                            }
                        }
                        else
                        {
                            if ((isAllOrderNames || this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 2].Text.Contains(prmsStr[0]))
                             && (isAllDeptNames || this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 11].Text.Contains(prmsStr[1]))
                             && (isAllTime || (splitTime >= prmsDate[0] && splitTime <= prmsDate[1]))
                             && (isAllOrderTypeNames || this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexOrderType].Text == prmsStr[2]))//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
                            {
                                this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                            }
                        }
                    }
                }
            }
            //非药品
            else
            {
                //恢复原来的颜色
                bool b = false;
                //恢复原来的颜色
                //间隔颜色显示
                for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    if (b)
                    {
                        this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.Linen;
                    }
                    else
                    {
                        this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.White;
                    }
                    b = !b;
                }
                if (isHaveFilter)
                {
                    for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                    {
                        DateTime splitTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, 9].Text);
                        if (isMatchAll)
                        {
                            if ((isAllOrderNames || this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, 2].Text == prmsStr[0])
                             && (isAllOrderTypeNames || this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser2.ColumnIndexOrderType].Text == prmsStr[2])//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
                             && (isAllTime || (splitTime >= prmsDate[0] && splitTime <= prmsDate[1])))
                            {
                                this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                            }
                        }
                        else
                        {
                            if ((isAllOrderNames || this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, 2].Text.Contains(prmsStr[0]))
                             && (isAllOrderTypeNames || this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser2.ColumnIndexOrderType].Text == prmsStr[2])//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
                             && (isAllTime || (splitTime >= prmsDate[0] && splitTime <= prmsDate[1])))
                            {
                                this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                            }
                        }
                    }
                }
            }
        }
       
        #endregion 

        #region 事件
        //不分解医嘱
        private void fpSpread_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Models.Order.ExecOrder order = null;
            order = this.CurrentBrowser.CurrentExecOrder;

            if (order == null) return;
            if (MessageBox.Show("确认不分解" + order.DateUse.ToString() + "的医嘱[" + order.Order.Item.Name + "] ?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            //作废执行档医嘱为不审核
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.orderManagement.Connection);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.orderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj = this.orderManagement.Operator;
            ArrayList alDel = new ArrayList();
            if (order.Order.Combo.ID == "" || order.Order.Combo.ID == "0")
            {
                if (this.orderManagement.DcExecImmediate((Neusoft.HISFC.Models.Order.Order)order.Order, obj) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(this.orderManagement.Err);
                    return;
                }
                this.CurrentBrowser.fpSpread.Sheets[0].Rows.Remove(this.fpOrderExecBrowser1.fpSpread.Sheets[0].ActiveRowIndex, 1);
            }
            else //组合医嘱，作废组合号相同及使用时间相同的医嘱
            {
                for (int i = this.CurrentBrowser.fpSpread.Sheets[0].RowCount - 1; i >= 0; i--)
                {
                    Neusoft.HISFC.Models.Order.ExecOrder objorder = (Neusoft.HISFC.Models.Order.ExecOrder)this.CurrentBrowser.fpSpread.Sheets[0].Rows[i].Tag;
                    if (objorder.Order.Combo.ID == order.Order.Combo.ID && objorder.DateUse == order.DateUse)
                    {
                        if (this.orderManagement.DcExecImmediate(objorder, obj) <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show(this.orderManagement.Err);
                            return;
                        }
                        //alDel.Add(i);
                        this.CurrentBrowser.fpSpread.Sheets[0].Rows.Remove(i, 1);
                    }
                }
            }

        
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.tabPage1.Text = "【" + this.fpOrderExecBrowser1.GetFpRowCount(0).ToString() + "条】";
            this.tabPage2.Text = "【" + this.fpOrderExecBrowser2.GetFpRowCount(0).ToString() + "条】";

        }
        /// <summary>
        /// 返回当前的FpSpread页
        /// </summary>
        protected fpOrderExecBrowser CurrentBrowser
        {
            get
            {
                if (this.TabControl1.SelectedIndex == 0)
                {
                    return this.fpOrderExecBrowser1;
                }
                else
                {
                    return this.fpOrderExecBrowser2;
                }
            }
        }
       

        /// <summary>
        /// 重新计算按钮事件 已经不再使用 默认为1天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaculate_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("确定要重新计算并分解医嘱吗?\n计算需要一段时间！", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.intDyas = (int)(this.txtDays.Value);
                RefreshExec();
            }
        }

        /// <summary>
        /// fpSpread_ButtonClicked事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (this.CurrentBrowser.fpSpread.Sheets[0].RowCount <= 0)
            {
                return;
            }
            if (e.Column == 1)
            {
                string checkValue = this.CurrentBrowser.fpSpread.Sheets[0].Cells[e.Row, e.Column].Text;

                Neusoft.HISFC.Models.Order.ExecOrder order = new Neusoft.HISFC.Models.Order.ExecOrder();
                order = this.CurrentBrowser.CurrentExecOrder;
                if (order.Order.Combo.ID != "" && order.Order.Combo.ID != "0")
                {
                    for (int i = this.CurrentBrowser.fpSpread.Sheets[0].RowCount - 1; i >= 0; i--)
                    {
                        Neusoft.HISFC.Models.Order.ExecOrder objorder = (Neusoft.HISFC.Models.Order.ExecOrder)this.CurrentBrowser.fpSpread.Sheets[0].Rows[i].Tag;
                        if (objorder.Order.Combo.ID == order.Order.Combo.ID && objorder.DateUse == order.DateUse)
                        {
                            this.CurrentBrowser.fpSpread.Sheets[0].Cells[i, 1].Text = checkValue;
                        }
                    }
                }
            }
        }

    
        /// <summary>
        /// 输入查询的名称,查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //回车结束
            if (e.KeyCode != Keys.Enter)
                return;
            string name = this.txtName.Text.Trim();
            if (name == "") return;

            this.SetDrugFlag(name, false);
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            bool b = false;
            if (this.chkAll.Checked)
            { //全选
                b = true;
            }
            else
            {//取消
                b = false;
            }
            if (this.TabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexSelection].Value = b;
                    tab0AllSelect = b;
                }
            }
            else
            {
                for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser2.ColumnIndexSelection].Value = b;
                    tab1AllSelect = b;
                }
            }
        }
        /// <summary>
        /// 重新计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbtnCalculate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(string.Format("是否分解{0}天的医嘱信息！", this.txtDays.Value.ToString())),
                "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //{5617A654-9738-4db4-A006-5A80B44F0841} 重新计算时需要对患者列表赋值
                this.alPatients = this.GetSelectedTreeNodes();

                intDyas = (int)this.txtDays.Value;
                this.RefreshExec();
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TabControl1.SelectedIndex == 0)
            {
                this.chkAll.Checked = tab0AllSelect;
            }
            else
            {
                this.chkAll.Checked = tab1AllSelect;
            }

            #region {8F9EBE06-9117-457a-8FED-5FEB9A9FD619}

            dtpEndTime_ValueChanged(null, null); 

            #endregion

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ComfirmExec();
            this.btnSave.Enabled = true;

        }

        private void txtDays_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime[] prmsDate = new DateTime[] { this.dtpBeginTime.Value, this.dtpEndTime.Value };
            string[] prmsStr = new string[] { this.txtName.Text, this.txtDrugDeptName.Text, this.cmbOrderTypeName.Text };//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            SetFilteredFlag(false, prmsDate, prmsStr);
        }

        private void cmbOrderTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime[] prmsDate = new DateTime[] { this.dtpBeginTime.Value, this.dtpEndTime.Value };
            string[] prmsStr = new string[] { this.txtName.Text, this.txtDrugDeptName.Text, this.cmbOrderTypeName.Text };//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            SetFilteredFlag(false, prmsDate, prmsStr);
        }

        private void txtDrugDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime[] prmsDate = new DateTime[] { this.dtpBeginTime.Value, this.dtpEndTime.Value };
            string[] prmsStr = new string[] { this.txtName.Text, this.txtDrugDeptName.Text, this.cmbOrderTypeName.Name };//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            SetFilteredFlag(false, prmsDate, prmsStr);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            CheckFilteredData();
        }

        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime[] prmsDate = new DateTime[] { this.dtpBeginTime.Value, this.dtpEndTime.Value };
            string[] prmsStr = new string[] { this.txtName.Text, this.txtDrugDeptName.Text, this.cmbOrderTypeName.Text };//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            SetFilteredFlag(false, prmsDate, prmsStr);
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime[] prmsDate = new DateTime[] { this.dtpBeginTime.Value, this.dtpEndTime.Value };
            string[] prmsStr = new string[] { this.txtName.Text, this.txtDrugDeptName.Text, this.cmbOrderTypeName.Text };//{CA8705F5-C25E-4126-BF15-F498AE82AFAE}
            SetFilteredFlag(false, prmsDate, prmsStr);
        }
        #endregion

        #region 多太太
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.InitControl();
            TreeView tv = sender as TreeView;
            if (tv != null && this.tv.CheckBoxes == false)
                tv.CheckBoxes = true;
            return null;
        }
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (tv != null && tv.CheckBoxes == false)
                tv.CheckBoxes = true;
            return base.OnSetValue(neuObject, e);
        }
        protected override int OnSetValues(ArrayList alValues, object e)
        {
            //{5617A654-9738-4db4-A006-5A80B44F0841} 查询时也需要对天数赋值
            intDyas = (int)this.txtDays.Value;

            this.alPatients = alValues;
            this.RefreshExec();
            return 0;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            return ComfirmExec();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Print(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPreview(this.TabControl1);
            return 0;
        }

        /// <summary>
        /// 设置打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int SetPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.ShowPageSetup();
            p.PrintPreview(this.TabControl1);
            return 0;
        }
        #endregion

        #region 暂时不用的代码，以前考虑删掉
        #region {13EAF764-E1CA-4d5a-8250-056AD1DEE61B}
        [System.Obsolete("整合功能，现在刷新函数中完成")]
        private void addComboDept(string name)
        {
            if (this.txtDrugDeptName.FindStringExact(name) >= 0) return;
            this.txtDrugDeptName.Items.Add(name);
        }

        [System.Obsolete("整合功能，现在刷新函数中完成")]
        private void addCombo(string name)
        {
            if (this.txtName.FindStringExact(name) >= 0) return;
            this.txtName.Items.Add(name);
        }
        /// <summary>
        /// 对指定药房的医嘱进行显示
        /// </summary>
        /// <param name="filter">药房名称</param>
        /// <param name="isMatchAll">是否需要全字匹配</param>
        protected void SetDrugDeptFlag(string filter, bool isMatchAll)
        {
            Neusoft.HISFC.Models.Order.ExecOrder order = null;
            for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
            {
                this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexSelection].Value = false;
            }
            //初始化显示，药品
            if (this.TabControl1.SelectedIndex == 0)
            {
                bool b = false;
                //恢复原来的颜色
                //间隔颜色显示
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    if (b)
                    {
                        this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.Linen;
                    }
                    else
                    {
                        this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.White;
                    }
                    b = !b;
                }
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    order = this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Order.ExecOrder;
                    if (isMatchAll)
                    {
                        if (this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 11].Text == filter)
                        {
                            this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;

                        }
                    }
                    else
                    {
                        if (this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 11].Text.IndexOf(filter) != -1)
                        {
                            this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;

                        }
                    }
                }
            }
        }
        /// <summary>
        /// 根据时间段选择项目{ED1068B5-53FD-4bf4-A270-49AE1A70D225}
        /// </summary>
        private void SelectByTime()
        {
            DateTime beginTime = this.dtpBeginTime.Value;
            DateTime endTime = this.dtpEndTime.Value;

            //取消已经选择的项目;
            if (this.TabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexSelection].Value = false;
                }
            }
            else
            {
                for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser2.ColumnIndexSelection].Value = false;
                }
            }
            //选择时间段内的分解项目
            if (this.TabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    DateTime splitTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 9].Text);
                    if (splitTime >= beginTime && splitTime <= endTime)
                    {
                        this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser1.ColumnIndexSelection].Value = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    DateTime splitTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, 9].Text);
                    if (splitTime >= beginTime && splitTime <= endTime)
                    {
                        this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, this.fpOrderExecBrowser2.ColumnIndexSelection].Value = true;
                    }
                }
            }
        }

        /// <summary>
        /// 对制定医嘱以特殊颜色显示
        /// </summary>
        /// <param name="filterStr">满足匹配的名称</param>
        /// <param name="isMatchingAll">是否需全部匹配</param>
        protected void SetDrugFlag(string filterStr, bool isMatchingAll)
        {
            Neusoft.HISFC.Models.Order.ExecOrder order = null;
            //初始化显示，药品
            if (this.TabControl1.SelectedIndex == 0)
            {
                bool b = false;
                //恢复原来的颜色
                //间隔颜色显示
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    if (b)
                    {
                        this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.Linen;
                    }
                    else
                    {
                        this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.White;
                    }
                    b = !b;
                }
                for (int i = 0; i < this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    order = this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].Tag as Neusoft.HISFC.Models.Order.ExecOrder;
                    if (isMatchingAll)
                    {
                        if (this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 2].Text == filterStr)
                        {
                            this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                        }
                    }
                    else
                    {
                        if (this.fpOrderExecBrowser1.fpSpread.Sheets[0].Cells[i, 2].Text.IndexOf(filterStr) != -1)
                        {
                            this.fpOrderExecBrowser1.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                        }
                    }
                }
            }
            //非药品
            else
            {
                //恢复原来的颜色
                bool b = false;
                //恢复原来的颜色
                //间隔颜色显示
                for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    if (b)
                    {
                        this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.Linen;
                    }
                    else
                    {
                        this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.White;
                    }
                    b = !b;
                }
                for (int i = 0; i < this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows.Count; i++)
                {
                    if (isMatchingAll)
                    {
                        if (this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, 2].Text == filterStr)
                        {
                            this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                        }
                    }
                    else
                    {
                        if (this.fpOrderExecBrowser2.fpSpread.Sheets[0].Cells[i, 2].Text.IndexOf(filterStr) != -1)
                        {
                            this.fpOrderExecBrowser2.fpSpread.Sheets[0].Rows[i].BackColor = Color.LightSkyBlue;
                        }
                    }
                }
            }
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EnumLackFee
    {
        不判断欠费,
        欠费不允许分解,
        欠费提示允不允许分解
    }
}
