using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace Neusoft.HISFC.Components.Order.OutPatient.Forms
{
    public partial class frmOutPatientOrder : Neusoft.FrameWork.WinForms.Forms.frmBaseForm,Neusoft.FrameWork.WinForms.Classes.IPreArrange,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public frmOutPatientOrder()
        {
            InitializeComponent();
            this.iControlable = this.ucOutPatientOrder1 as Neusoft.FrameWork.WinForms.Forms.IControlable;
            this.CurrentControl = this.ucOutPatientOrder1;
            this.panelToolBar.Visible = false;
            InitButton();
        }


        /// <summary>
        /// 账户操作的业务层  {184209CF-569F-4355-896D-FB33FF6C506F} 
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        private Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();

        private HISFC.Components.Order.OutPatient.Classes.Function Function = new HISFC.Components.Order.OutPatient.Classes.Function();

        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        private bool isAccountTerimal = false;

        #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号 by guanyx 作废
        //HISFC.BizProcess.Integrate.Registration.Registration regManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        //ZZlocal.Clinic.HISFC.OuterConnector.Triage.Triage triage = new ZZlocal.Clinic.HISFC.OuterConnector.Triage.Triage();
        //ZZlocal.Clinic.HISFC.BizLogic.Registration.QueryDepartStat departStatManager = new ZZlocal.Clinic.HISFC.BizLogic.Registration.QueryDepartStat();
        //private string deptcode = "";
        //private string opercode = "";
        //private string nurseStation = "";
        ///// <summary>
        ///// 执行分诊dll返回值
        ///// [0,*]：“呼叫”可用，其他皆不可用；
        ///// [1, 呼叫中的患者cliniccode值]：“呼叫”不可用，“就诊开始”、“过号”可用，“就诊结束”不可用；
        ///// [2, 就诊中的患者cliniccode]：“呼叫”不可用，“就诊开始”、“过号”不可用，“就诊结束”可用；
        ///// [999，]表示该科室分诊队列数据表存在问题
        ///// </summary>
        ////private char[] rtn = new char[20];
        //StringBuilder rtn = new StringBuilder(100);
        #endregion

        #region {FD676895-D54B-4e1a-8AAF-383E925DB518} 医生叫号，最后修改 by guanyx 
        [DllImport("JZWindowsDll.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int InitDllForm(IntPtr i, char[] inputString);
        //分诊管理
        ZZlocal.Clinic.HISFC.OuterConnector.Triage.Triage triage = new ZZlocal.Clinic.HISFC.OuterConnector.Triage.Triage();
        //查找上层分诊区
        ZZlocal.Clinic.HISFC.BizLogic.Registration.QueryDepartStat departStatManager = new ZZlocal.Clinic.HISFC.BizLogic.Registration.QueryDepartStat();
        private string deptcode = "";
        private string opercode = "";
        private string nurseStation = "";
        #endregion 

        /// <summary>
        /// 传染病上报类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.DCP.IDCP dcpInstance = null;

        private void frmOutPatientOrder_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.tbFilter.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked);

            ////this.AddOrderHandle();
            this.initButton(false);

            this.tbAddOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y医嘱);
            this.tbComboOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并);
            this.tbCancelOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消);
            this.tbDelOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除);
            this.tbOperation.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z诊断);
            this.tbSaveOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存);
            this.tbCheck.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H换单);
            this.tb1Exit.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出);
            this.tbExitOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出);
            this.tbGroup.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套);
            
            this.tbSeePatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q权限添加);
            this.tbRefreshPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新);
            this.tbQueryOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询);
            this.tbPatientTree.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.G顾客);
            this.tbChooseDrugDept.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.K科室);
            #region {777C56C9-D8D7-478c-A10F-EF9B37335A08}
            this.tbPrintOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印);
            this.tbRegisterEmergencyPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.J接诊);
            this.tbOutEmergencyPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.C出院登记);
            this.tbInEmergencyPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z转科);
            this.tbDiseaseReport.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.J健康档案);
            this.tbHerbal.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.M明细);

            #region {DEF4C3EC-A951-4547-80E2-AE5ADC82B606} 叫号、过号按钮by guanyx
            this.tbCallNO.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个);
            this.tbPassNO.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T跳转);
            this.tbBeginOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T体温);
            this.tbEndOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.B病历);
            #endregion

            #endregion
            this.panelTree.Height = this.Height - 162;
            this.panelTree.Visible = false;

            //{B17077E6-7E65-45fb-BA25-F2883EB6BA27}  保证诊台、诊室不维护时窗口可以关闭
            //this.ucOutPatientTree1.RefreshTreeView();

            this.ucOutPatientTree1.TreeDoubleClick += new HISFC.Components.Order.OutPatient.Controls.ucOutPatientTree.TreeDoubleClickHandler(ucOutPatientTree1_TreeDoubleClick);
            isAccountTerimal = controlIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Account_Process, true, false);
            this.ucOutPatientOrder1.OnRefreshGroupTree += new EventHandler(ucOutPatientOrder1_OnRefreshGroupTree);

            //进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
            this.ChooseDrugDept(false);

            #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx 作废
            //try
            //{
            //    deptcode = ((HISFC.Models.Base.Employee)triage.Operator).Dept.ID;
            //    opercode = triage.Operator.ID;
            //    nurseStation = departStatManager.GetUpNurseStation(deptcode);
            //    char[] deptcodeChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(deptcode);
            //    char[] opercodeChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(opercode);
            //    int returnValue = 0;
            //    /*
            //     * 0：执行成功；
            //     * 1：数据库链接失败
            //     * 2：数据模块初始化失败
            //     * 3：存储过程调用失败
            //     */
            //    if (!string.IsNullOrEmpty(nurseStation))
            //    {
            //        rtn = new StringBuilder();
            //        char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
            //        returnValue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.GetTreatState(nurseStationChar, opercodeChar, ref rtn);
            //    }
            //    else
            //    {
            //        rtn = new StringBuilder();
            //        returnValue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.GetTreatState(deptcodeChar, opercodeChar, ref rtn);
            //    }

            //    if (returnValue == 0)
            //    {
            //        string clinicCode = "";
            //        if (rtn != null)
            //        {
            //            switch (rtn.ToString().Substring(0, 1))
            //            {
            //                case "0":
            //                    this.tbCallNO.Enabled = true;
            //                    this.tbPassNO.Enabled = false;
            //                    this.tbBeginOrder.Enabled = false;
            //                    this.tbEndOrder.Enabled = false;
            //                    break;
            //                case "1":
            //                    this.tbCallNO.Enabled = false;
            //                    this.tbPassNO.Enabled = true;
            //                    this.tbBeginOrder.Enabled = true;
            //                    this.tbEndOrder.Enabled = false;
            //                    clinicCode = (rtn.ToString()).Substring(2);
            //                    Neusoft.HISFC.Models.Registration.Register p = regManager.GetByClinic(clinicCode);
            //                    MessageBox.Show(p.PID.CardNO + "(" + p.Name + "),正在呼叫中，请做【开始就诊】或者【过号】操作！");
            //                    break;
            //                case "2":
            //                    this.tbCallNO.Enabled = false;
            //                    this.tbPassNO.Enabled = false;
            //                    this.tbBeginOrder.Enabled = false;
            //                    this.tbEndOrder.Enabled = true;
            //                    clinicCode = (rtn.ToString()).Substring(2);
            //                    Neusoft.HISFC.Models.Registration.Register pp = regManager.GetByClinic(clinicCode);
            //                    MessageBox.Show(pp.PID.CardNO + "(" + pp.Name + "),正在就诊中，请做【结束就诊】操作！");
            //                    break;
            //                default:
            //                    this.tbCallNO.Enabled = false;
            //                    this.tbPassNO.Enabled = false;
            //                    this.tbBeginOrder.Enabled = false;
            //                    this.tbEndOrder.Enabled = false;
            //                    MessageBox.Show("科室分诊队列数据异常！请重新进入界面或者联系信息科！");
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //        }
            //    }
            //    else
            //    {
            //        this.tbCallNO.Enabled = false;
            //        this.tbPassNO.Enabled = false;
            //        this.tbBeginOrder.Enabled = false;
            //        this.tbEndOrder.Enabled = false;
            //        MessageBox.Show("执行初始化失败！请重新进入界面！");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    this.tbCallNO.Enabled = false;
            //    this.tbPassNO.Enabled = false;
            //    this.tbBeginOrder.Enabled = false;
            //    this.tbEndOrder.Enabled = false;
            //    MessageBox.Show("大屏接口异常，" + ee.Message + "请重新进入界面！");
            //}
            #endregion

            #region  {FD676895-D54B-4e1a-8AAF-383E925DB518} 医生叫号，最后修改 by guanyx
            deptcode = ((HISFC.Models.Base.Employee)triage.Operator).Dept.ID;
            opercode = triage.Operator.ID;
            nurseStation = departStatManager.GetUpNurseStation(deptcode);
            string inputString = "";
            char[] inputChar = new char[11];
            if (nurseStation.Length == 4)
            {
                inputString = nurseStation + "," + opercode;
                inputChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(inputString);
            }
            else
            {
                inputString = deptcode + "," + opercode;
                inputChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(inputString);
            }
            InitDllForm(this.Handle, inputChar);
            #endregion

        }

        void ucOutPatientOrder1_OnRefreshGroupTree(object sender, EventArgs e)
        {
            this.tvGroup.RefrshGroup();
        }

        private void ucOutPatientTree1_TreeDoubleClick(object sender, HISFC.Components.Order.OutPatient.Controls.ClickEventArgs e)
        {
            #region {22571B58-A56B-4dc3-A32C-EC17D74423A2}
            //if (this.CurrentControl.GetType() == typeof(HISFC.Components.Order.OutPatient.Controls.ucPatientCase))
            //{
            //    (this.CurrentControl as HISFC.Components.Order.OutPatient.Controls.ucPatientCase).Reg = e.Message;
            //}
            //if (this.CurrentControl.GetType() == typeof(HISFC.Components.Order.OutPatient.Controls.ucOrderHistory))
            //{
            //    (this.CurrentControl as HISFC.Components.Order.OutPatient.Controls.ucOrderHistory).Patient = e.Message;
            //}

            try
            {
                if (this.ucOutPatientTree1.neuTreeView1.Visible)
                {
                    this.tree = this.ucOutPatientTree1.neuTreeView1;
                    TreeViewEventArgs mye = new TreeViewEventArgs(this.ucOutPatientTree1.neuTreeView1.SelectedNode);
                    this.tree_AfterSelect(e.Message, mye);
                    this.Tag = this.ucOutPatientTree1.neuTreeView1.SelectedNode.Tag;
                }
                if (this.ucOutPatientTree1.neuTreeView2.Visible)
                {
                    this.tree = this.ucOutPatientTree1.neuTreeView2;
                    TreeViewEventArgs mye = new TreeViewEventArgs(this.ucOutPatientTree1.neuTreeView2.SelectedNode);
                    this.tree_AfterSelect(e.Message, mye);
                    this.Tag = this.ucOutPatientTree1.neuTreeView2.SelectedNode.Tag;
                }

                if (this.Tag is Neusoft.HISFC.Models.Registration.Register)
                {
                    //判断账户流程的挂号收费情况
                    //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                    bool isAccount = false;
                    decimal vacancy = 0m;
                    Neusoft.HISFC.Models.Registration.Register r = (Neusoft.HISFC.Models.Registration.Register)Tag;

                    if (isAccountTerimal && r.IsAccount)
                    {

                        if (feeMgr.GetAccountVacancy(r.PID.CardNO, ref vacancy) <= 0)
                        {
                            MessageBox.Show(feeMgr.Err);
                            return;
                        }
                        isAccount = true;

                    }
                    if (isAccount && r.IsFee == false)
                    {
                        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                        #region 账户扣取挂号费

                        if (!feeMgr.CheckAccountPassWord(r))
                        {
                            this.ucOutPatientTree1.neuTreeView1.SelectedNode = null;
                            this.ucOutPatientTree1.PatientInfo = null;
                            return;
                        }

                        if (isAccount && !r.IsFee)
                        {
                            if (vacancy < r.OwnCost)
                            {
                                MessageBox.Show("账户金额不足，请交费！");
                                return;
                            }


                            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                            if (feeMgr.AccountPay(r, r.OwnCost, "挂号收费", (orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID, string.Empty) < 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("扣账户金额失败！" + feeMgr.Err);
                                return;
                            }
                            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
                            r.SeeDOCD = orderManager.Operator.ID;
                            r.SeeDPCD = (orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                            if (registerManager.UpdateAccountFeeState(r.ID,r.SeeDOCD ,r.SeeDPCD , orderManager.GetDateTimeFromSysDateTime()) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("更新挂号表已收费状态出错");
                                return;
                            }
                            Neusoft.FrameWork.Management.PublicTrans.Commit();
                            r.IsFee = true;
                        }
                        #endregion
                    }
                }
            }
            catch { }
            finally { }
            #endregion
        }

        private void initButton(bool isDisign)
        {
            this.tbGroup.Enabled = !isDisign;
            this.tbAddOrder.Enabled = !isDisign;
            this.tbComboOrder.Enabled = isDisign;
            this.tbCancelOrder.Enabled = isDisign;
            this.tbCheck.Enabled = isDisign;
            this.tbHerbal.Enabled = isDisign;
            this.tbOperation.Enabled = false;
            this.tbDelOrder.Enabled = isDisign;
            //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            //this.tbRegisterEmergencyPatient.Enabled = isDisign;
            //this.tbInEmergencyPatient.Enabled = isDisign;
            //this.tbInEmergencyPatient.Enabled = isDisign;
            this.tbExitOrder.Enabled = isDisign;
            this.tbFilter.Enabled = !isDisign;
            this.tbFilter.Visible = false;
            this.tbQueryOrder.Enabled = !isDisign;
            
            this.tbSaveOrder.Enabled = isDisign;
            this.tbSeePatient.Enabled = !isDisign;
            if (isDisign) //开立
            {
                if (tvGroup == null)
                {
                    tvGroup = new Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup();
                    tvGroup.Type = Neusoft.HISFC.Components.Common.Controls.enuType.Order;
                    tvGroup.InpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.C;
                    tvGroup.Init();
                    tvGroup.SelectOrder += new Neusoft.HISFC.Components.Common.Controls.SelectOrderHandler(tvGroup_SelectOrder);
                }
                tvGroup.Dock = DockStyle.Fill;
                tvGroup.Visible = true;
                
                this.panelTree.Visible = true;
                this.panel2.Visible = true;

                // {4255B9B6-1BA4-4f6a-9FD9-2856220D806D} xupan
                this.neuTextBox1.Dock = DockStyle.Top;
                this.panelTree.Dock = DockStyle.Fill;
                // end

                if (this.btnShow.Visible != true)
                {
                    this.panel2.Width = 170;
                    this.panelTree.Width = 170;
                }
                #region {22571B58-A56B-4dc3-A32C-EC17D74423A2}
                this.panelTree.Controls.Add(tvGroup);
                #endregion
                //this.SetTree(tvGroup);
                this.neuPanel1.Visible = false;
            }
            else
            {
                this.neuPanel1.Visible = true;
                this.panelTree.Visible = false;
                this.panel2.Visible = false;
                if (tvGroup != null) tvGroup.Visible = false;
                this.ucOutPatientOrder1.Patient = new Neusoft.HISFC.Models.Registration.Register();
            }
        }

        /// <summary>
        /// 初始化第二排BUTTON
        /// </summary>
        private void InitButton()
        {
            //base.toolBar2.Items.Add(this.tbCallNO);
            //base.toolBar2.Items.Add(this.tbBeginOrder);
            //base.toolBar2.Items.Add(this.tbEndOrder);
            //base.toolBar2.Items.Add(this.tbPassNO);
            //base.toolBar2.Items.Add(this.toolStripSeparator8);
            base.toolBar2.Items.Add(this.tbSeePatient);
            base.toolBar2.Items.Add(this.tbClinicCase);
            base.toolBar2.Items.Add(this.toolStripSeparator7);
            base.toolBar2.Items.Add(this.tb1Exit);
            base.toolBar2.ImageScalingSize = new System.Drawing.Size(32, 32); 
            base.toolBar2.ItemClicked += new ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
        }


        Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup tvGroup = null;//组套
        bool isEditGroup = false;

        private void initButtonGroup(bool isEdit)
        {
            this.tbAddOrder.Enabled = !isEdit;
            this.tbSaveOrder.Enabled = isEdit;
            this.tbExitOrder.Enabled = !isEdit;
            this.isEditGroup = isEdit;
            this.tbQueryOrder.Enabled = !isEdit;
            this.tbSeePatient.Enabled = !isEdit;
            //{CF7BCF69-95C3-4dcf-A61C-451E26C56161}
            this.tbComboOrder.Enabled = isEdit;
            this.tbCancelOrder.Enabled = isEdit;
            this.tbDelOrder.Enabled = isEdit;//{11F97F55-F747-4ad9-A74F-086635D5EBD9}
            if (isEdit) //开立
            {
                if (tvGroup == null)
                {
                    tvGroup = new Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup();
                    tvGroup.Type = Neusoft.HISFC.Components.Common.Controls.enuType.Order;
                    tvGroup.InpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.C;
                    tvGroup.Init();
                    tvGroup.SelectOrder += new Neusoft.HISFC.Components.Common.Controls.SelectOrderHandler(tvGroup_SelectOrder);
                }
                tvGroup.Dock = DockStyle.Fill;
                tvGroup.Visible = true;
                this.panelTree.Visible = true;
                this.panel2.Visible = true;
                if (this.btnShow.Visible != true)
                {
                    this.panel2.Width = 170;
                    this.panelTree.Width = 170;
                }
                #region {22571B58-A56B-4dc3-A32C-EC17D74423A2}
                this.panelTree.Controls.Add(tvGroup);
                //this.SetTree(tvGroup);
                #endregion
            }
            else
            {
                this.panelTree.Visible = false;
                this.panel2.Visible = false;
                if (tvGroup != null) tvGroup.Visible = false;
            }
        }

        void tvGroup_SelectOrder(System.Collections.ArrayList alOrders)
        {
            //{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988} //草药弹出草药开立界面
            ArrayList alHerbal = new ArrayList(); //草药

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order order in alOrders)
            {
                if (order.Item.SysClass.ID.ToString() == "PCC") //草药
                {
                    alHerbal.Add(order);
                }
                else
                {
                    this.ucOutPatientOrder1.AddNewOrder(order, 0);
                }
            }
            if (alHerbal.Count > 0)
            {
                this.ucOutPatientOrder1.AddHerbalOrders(alHerbal);
            }
            this.ucOutPatientOrder1.RefreshCombo();
            
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Controls.Count > 0)
            {
                this.iQueryControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IQueryControlable;
                this.iControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                this.CurrentControl = this.tabControl1.SelectedTab.Controls[0];
                if (this.CurrentControl.GetType() == typeof(HISFC.Components.Order.OutPatient.Controls.ucPatientCase))
                {
                    (this.CurrentControl as HISFC.Components.Order.OutPatient.Controls.ucPatientCase).Reg = ucOutPatientTree1.PatientInfo;
                    this.neuPanel1.Visible = false;
                }
                
            }
            this.InitButton();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx
            deptcode = ((HISFC.Models.Base.Employee)triage.Operator).Dept.ID;
            opercode = triage.Operator.ID;
            nurseStation = departStatManager.GetUpNurseStation(deptcode);
            char[] deptcodeChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(deptcode);
            char[] opercodeChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(opercode);
            #endregion
            if (e.ClickedItem == this.tbAddOrder)//开立
            {
                this.ucOutPatientOrder1.Patient = this.ucOutPatientTree1.PatientInfo;
                this.ucOutPatientOrder1.CurrentRoom = this.ucOutPatientTree1.CurrRoom;
                #region {66712C76-62CB-43a1-8DE0-C0C02AB3F9B4}
                this.statusBar1.Panels[1].Text = "(绿色：新开)(蓝色：收费)(红色：作废)";
                //this.statusBar1.Controls[1].AutoSize = StatusBarPanelAutoSize.Contents;
                #endregion
                if (this.ucOutPatientOrder1.Add() == 0)
                {
                    this.initButton(true);

                    #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx 作废
                    //this.tbCallNO.Enabled = false; 
                    //this.tbPassNO.Enabled = false;
                    //StringBuilder cardno = new StringBuilder(10);
                    //try
                    //{
                    //    if (!string.IsNullOrEmpty(nurseStation))
                    //    {
                    //        char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
                    //        ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.BeginTreat(nurseStationChar, opercodeChar, ref cardno);
                    //    }
                    //    else
                    //    {
                    //        ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.BeginTreat(deptcodeChar, opercodeChar, ref cardno);
                    //    }
                    //}
                    //catch (Exception ee)
                    //{
                    //    MessageBox.Show("RW大屏接口异常，" + ee.Message);
                    //}
                    #endregion
                }

            }
            #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx 作废
            //else if (e.ClickedItem == this.tbCallNO)
            //{
            //    StringBuilder cardno = new StringBuilder(10);
            //    int returnvalue = 0;
            //    try
            //    {
            //        if (!string.IsNullOrEmpty(nurseStation))
            //        {
            //            cardno = new StringBuilder();
            //            char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.CallPatient(nurseStationChar, opercodeChar, ref cardno);
            //        }
            //        else
            //        {
            //            cardno = new StringBuilder();
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.CallPatient(deptcodeChar, opercodeChar, ref cardno);
            //        }
            //        if (returnvalue == 0)
            //        {
            //            this.tbCallNO.Enabled = false;
            //            this.tbPassNO.Enabled = true;
            //            this.tbBeginOrder.Enabled = true;
            //            this.tbEndOrder.Enabled = false;
            //            Neusoft.HISFC.Models.Registration.Register p = regManager.GetByClinic(cardno.ToString());
            //            MessageBox.Show("正在呼叫 " + p.PID.CardNO + "(" + p.Name + ")，请耐心等待！");
            //        }
            //        else
            //        {
            //            this.tbCallNO.Enabled = true;
            //            this.tbPassNO.Enabled = false;
            //            this.tbBeginOrder.Enabled = false;
            //            this.tbEndOrder.Enabled = false;
            //            MessageBox.Show("呼叫患者失败！请重新点击【叫号】！");
            //        }
            //    }
            //    catch (Exception ee)
            //    {
            //        this.tbCallNO.Enabled = true;
            //        this.tbPassNO.Enabled = false;
            //        this.tbBeginOrder.Enabled = false;
            //        this.tbEndOrder.Enabled = false;
            //        MessageBox.Show("大屏接口异常，" + ee.Message + "请重新点击【叫号】！");
            //    }
            //}
            //else if (e.ClickedItem == this.tbBeginOrder)
            //{
            //    #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx
            //    int returnvalue = 0;
            //    StringBuilder cardno = new StringBuilder(10);
            //    try
            //    {
            //        if (!string.IsNullOrEmpty(nurseStation))
            //        {
            //            cardno = new StringBuilder();
            //            char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.BeginTreat(nurseStationChar, opercodeChar, ref cardno);
            //        }
            //        else
            //        {
            //            cardno = new StringBuilder();
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.BeginTreat(deptcodeChar, opercodeChar, ref cardno);
            //        }
            //        if (returnvalue == 0)
            //        {
            //            this.tbCallNO.Enabled = false;
            //            this.tbPassNO.Enabled = false;
            //            this.tbBeginOrder.Enabled = false;
            //            this.tbEndOrder.Enabled = true;
            //        }
            //        else
            //        {
            //            this.tbCallNO.Enabled = false;
            //            this.tbPassNO.Enabled = true;
            //            this.tbBeginOrder.Enabled = true;
            //            this.tbEndOrder.Enabled = false;
            //            MessageBox.Show("开始就诊失败！请重新点击【开始就诊】！");
            //        }
            //    }
            //    catch (Exception ee)
            //    {
            //        this.tbCallNO.Enabled = false;
            //        this.tbPassNO.Enabled = true;
            //        this.tbBeginOrder.Enabled = true;
            //        this.tbEndOrder.Enabled = false;
            //        MessageBox.Show("大屏接口异常，" + ee.Message + "请重新点击【开始就诊】！");
            //    }
            //    #endregion
            //}
            //else if (e.ClickedItem == this.tbEndOrder)
            //{
            //    #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx
            //    int returnvalue = 0;
            //    StringBuilder cardno = new StringBuilder(10);
            //    try
            //    {
            //        if (!string.IsNullOrEmpty(nurseStation))
            //        {
            //            cardno = new StringBuilder();
            //            char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.TreatFinish(nurseStationChar, opercodeChar, ref cardno);
            //        }
            //        else
            //        {
            //            cardno = new StringBuilder();
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.TreatFinish(deptcodeChar, opercodeChar, ref cardno);
            //        }
            //        if (returnvalue == 0)
            //        {
            //            this.tbCallNO.Enabled = true;
            //            this.tbPassNO.Enabled = false;
            //            this.tbBeginOrder.Enabled = false;
            //            this.tbEndOrder.Enabled = false;
            //        }
            //        else
            //        {
            //            this.tbCallNO.Enabled = false;
            //            this.tbPassNO.Enabled = false;
            //            this.tbBeginOrder.Enabled = false;
            //            this.tbEndOrder.Enabled = true;
            //            MessageBox.Show("结束就诊失败！请重新点击【结束就诊】！");
            //        }
            //    }
            //    catch (Exception ee)
            //    {
            //        this.tbCallNO.Enabled = false;
            //        this.tbPassNO.Enabled = false;
            //        this.tbBeginOrder.Enabled = false;
            //        this.tbEndOrder.Enabled = true;
            //        MessageBox.Show("大屏接口异常，" + ee.Message + "请重新点击【结束就诊】！");
            //    }
            //    #endregion
            //}
            //else if (e.ClickedItem == this.tbPassNO)
            //{
            //    StringBuilder cardno = new StringBuilder(10);
            //    int returnvalue = 0;
            //    try
            //    {
            //        if (!string.IsNullOrEmpty(nurseStation))
            //        {
            //            cardno = new StringBuilder();
            //            char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.SkipPatient(nurseStationChar, opercodeChar, ref cardno);
            //        }
            //        else
            //        {
            //            cardno = new StringBuilder();
            //            returnvalue = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.SkipPatient(deptcodeChar, opercodeChar, ref cardno);
            //        }
            //        if (returnvalue == 0)
            //        {
            //            this.tbCallNO.Enabled = true;
            //            this.tbPassNO.Enabled = false;
            //            this.tbBeginOrder.Enabled = false;
            //            this.tbEndOrder.Enabled = false;
            //        }
            //        else
            //        {
            //            this.tbCallNO.Enabled = false;
            //            this.tbPassNO.Enabled = true;
            //            this.tbBeginOrder.Enabled = true;
            //            this.tbEndOrder.Enabled = false;
            //            MessageBox.Show("过号失败！请重新点击【过号】！");
            //        }
            //    }
            //    catch (Exception ee)
            //    {
            //        this.tbCallNO.Enabled = false;
            //        this.tbPassNO.Enabled = true;
            //        this.tbBeginOrder.Enabled = true;
            //        this.tbEndOrder.Enabled = false;
            //        MessageBox.Show("大屏接口异常，" + ee.Message + "请重新点击【过号】！");
            //    }
            //}
            #endregion
            else if (e.ClickedItem == this.tbGroup)//组套
            {
                if (this.tbGroup.CheckState == CheckState.Checked)
                {
                    this.tbGroup.CheckState = CheckState.Unchecked;
                }
                else
                {
                    this.tbGroup.CheckState = CheckState.Checked;
                }

                if (this.tbGroup.CheckState == CheckState.Checked)
                {
                    this.ucOutPatientOrder1.SetEditGroup(true);
                    this.ucOutPatientOrder1.Patient = null;
                    this.initButtonGroup(true);

                }
                else
                {
                    this.ucOutPatientOrder1.SetEditGroup(false);
                    this.initButtonGroup(false);
                    this.panelTree.Visible = false;
                    this.panel2.Visible = false;
                }

            }
            else if (e.ClickedItem == this.tbHerbal)
            {
                this.ucOutPatientOrder1.HerbalOrder();
            }
            else if (e.ClickedItem == this.tbCheck)
            {
                this.ucOutPatientOrder1.AddTest();
            }

            else if (e.ClickedItem == this.tbDelOrder)//删除
            {
                this.ucOutPatientOrder1.Del();
            }
            else if (e.ClickedItem == this.tbQueryOrder)//查询
            {
                this.ucOutPatientOrder1.Patient = this.ucOutPatientTree1.PatientInfo;
                this.ucOutPatientOrder1.Retrieve();
            }
            else if (e.ClickedItem == this.tbPrintOrder)//打印
            {
                this.ucOutPatientOrder1.PrintOrder();
            }
            else if (e.ClickedItem == this.tbComboOrder)//组合
            {
                this.ucOutPatientOrder1.ComboOrder();
            }
            else if (e.ClickedItem == this.tbCancelOrder)//取消组合
            {
                this.ucOutPatientOrder1.CancelCombo();
            }
            else if (e.ClickedItem == this.tbExitOrder)//退出医嘱
            {
                if (this.isEditGroup)
                {
                    if (this.tbGroup.CheckState == CheckState.Checked)
                    {
                        this.tbGroup.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        this.tbGroup.CheckState = CheckState.Checked;
                    }
                    this.ucOutPatientOrder1.SetEditGroup(false);
                    this.initButtonGroup(false);
                }
                else
                {
                    #region donggq----{31F003C4-528F-4f97-A52E-E23149688666}
                    if (DialogResult.Yes == MessageBox.Show("确定退出【医嘱开立】吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {

                        ///原来的开始
                        if (this.ucOutPatientOrder1.ExitOrder() == 0)
                        {
                            this.initButton(false);
                            #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx
                            this.tbCallNO.Enabled = false;
                            this.tbPassNO.Enabled = false;
                            #endregion
                        }
                        ///原来的结束

                    }
                    else
                    {
                        return;
                    }
                    #endregion
                }
            }

            else if (e.ClickedItem == this.tbRegisterEmergencyPatient)//留观
            {
                if (this.ucOutPatientOrder1.RegisterEmergencyPatient() < 0)
                {
                }
                else
                {
                    MessageBox.Show("留观成功！");

                    ucOutPatientTree1.RefreshTreeView();
                    ucOutPatientTree1.RefreshTreePatientDone();
                }
            }
            //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            else if (e.ClickedItem == this.tbOutEmergencyPatient) //出关
            {
                if (this.ucOutPatientOrder1.OutEmergencyPatient() > 0)
                {
                    ucOutPatientTree1.RefreshTreeView();
                    ucOutPatientTree1.RefreshTreePatientDone();
                }

            }
            //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            else if (e.ClickedItem == this.tbInEmergencyPatient) //转住院
            {
                if (this.ucOutPatientOrder1.InEmergencyPatient() > 0)
                {
                    ucOutPatientTree1.RefreshTreeView();
                    ucOutPatientTree1.RefreshTreePatientDone();
                }
            }
            else if (e.ClickedItem == this.tbSeePatient)//诊出
            {
                if (this.ucOutPatientTree1.DiagOut() < 0)
                {
                }
                else
                {
                    MessageBox.Show("诊出成功！");

                    ucOutPatientTree1.RefreshTreeView();
                    ucOutPatientTree1.RefreshTreePatientDone();
                }
            }
            else if (e.ClickedItem == this.tbRefreshPatient)//刷新
            {
                ucOutPatientTree1.RefreshTreeView();
                ucOutPatientTree1.RefreshTreePatientDone();
            }
            else if (e.ClickedItem == this.tbPatientTree)//列表
            {
                this.neuPanel1.Visible = !this.neuPanel1.Visible;
            }
            else if (e.ClickedItem == this.tbSaveOrder)//保存
            {
                //
                if (isEditGroup)
                {
                    SaveGroup();
                }
                else
                {
                    if (this.ucOutPatientOrder1.Save() == -1)
                    {

                    }
                    else
                    {
                        this.initButton(false);
                        ucOutPatientTree1.RefreshTreeView();

                        #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx
                        //this.tbCallNO.Enabled = true;
                        //this.tbPassNO.Enabled = false;
                        //StringBuilder cardno = new StringBuilder(10);
                        //try
                        //{
                        //    if (!string.IsNullOrEmpty(nurseStation))
                        //    {
                        //        char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
                        //        ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.TreatFinish(nurseStationChar, opercodeChar, ref cardno);
                        //    }
                        //    else
                        //    {
                        //        ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.TreatFinish(deptcodeChar, opercodeChar, ref cardno);
                        //    }
                        //}
                        //catch (Exception ee)
                        //{
                        //    MessageBox.Show("RW大屏接口异常，" + ee.Message);
                        //}
                        #endregion

                    }
                }
                this.statusBar1.Panels[1].Text = "";
            }
            else if (e.ClickedItem == this.tb1Exit)//退出
            {
                if (this.ucOutPatientOrder1.IsDesignMode) //是在开立状态
                {
                    DialogResult result = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("医嘱目前处于开立模式，是否保存?"), "提示", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        #region {A06E32ED-0757-4802-AC9F-D1F9615E374C}医生站叫号过号  by guanyx
                        //this.tbCallNO.Enabled = true;
                        //this.tbPassNO.Enabled = false;
                        //StringBuilder cardno = new StringBuilder(10);
                        //try
                        //{
                        //    if (!string.IsNullOrEmpty(nurseStation))
                        //    {
                        //        char[] nurseStationChar = ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.StringToChar(nurseStation);
                        //        ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.TreatFinish(nurseStationChar, opercodeChar, ref cardno);
                        //    }
                        //    else
                        //    {
                        //        ZZlocal.Clinic.HISFC.OuterConnector.Triage.TriageManager.TreatFinish(deptcodeChar, opercodeChar, ref cardno);
                        //    }
                        //}
                        //catch (Exception ee)
                        //{
                        //    MessageBox.Show("RW大屏接口异常，" + ee.Message);
                        //}
                        #endregion
                        if (this.ucOutPatientOrder1.Save() == 0)
                            this.Close();

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }

                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else if (e.ClickedItem == this.tbDiseaseReport)     //  {E53A21A7-2B74-4b48-A9F4-9E05F8FA11A2} 传染病报告卡
            {
                if (this.dcpInstance == null)
                {
                    this.dcpInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.DCP.IDCP)) as Neusoft.HISFC.BizProcess.Interface.DCP.IDCP;
                }

                if (this.dcpInstance != null)
                {
                    Neusoft.HISFC.Models.RADT.Patient patient = this.ucOutPatientTree1.PatientInfo as Neusoft.HISFC.Models.RADT.Patient;

                    this.dcpInstance.RegisterDiseaseReport(patient, Neusoft.HISFC.Models.Base.ServiceTypes.C);
                }
            }
            else if (e.ClickedItem == this.tbLisResultPrint)//{9B06773D-9674-4b20-94B8-47A1B066EA0B},检查、检验结果查询，shangxw 2009-11-10
            {
                Neusoft.HISFC.Models.Registration.Register patient = new Neusoft.HISFC.Models.Registration.Register();
                patient = this.ucOutPatientTree1.PatientInfo;
                //if continue?
                //DialogResult result = MessageBox.Show("是否打印LIS结果？", "提示", MessageBoxButtons.YesNo);
                //if (result == DialogResult.No)
                //{
                //    return;
                //}

                //Is "" or Null?
                if (patient == null || patient.PID.CardNO == "" || patient.PID.CardNO == null)
                {
                    MessageBox.Show("请选择一个患者！");


                    return;
                }

                try
                {


                    #region 郑大修改---{15C4A9D2-34AF-484b-B65B-BBD3CACABA5C}

                    rm_barprinter_common.In_rm_barprinter_common mobj = new rm_barprinter_common.COClass_n_rm_barprinter_commonClass();

                    if (!string.IsNullOrEmpty(patient.PID.CardNO))
                    {
                        mobj.uf_lis_result(patient.PID.CardNO, "1");
                    }
                    else
                    {
                        MessageBox.Show("Lis调用失败");
                        return;
                    }

                    //try
                    //{


                    //    string s = "LisResult";

                    //    System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(s);
                    //    if (proc.Length > 0)
                    //    {
                    //        for (int i = 0; i < proc.Length; i++)
                    //        {
                    //            proc[i].Kill();
                    //        }
                    //    }

                    //    System.Diagnostics.Process p = new System.Diagnostics.Process();

                    //    p.StartInfo.FileName = Application.StartupPath + @"\LisBin\LisResult.exe";    //需要启动的程序名       
                    //    #region 取配置参数
                    //    ArrayList defaultValue = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("lis");
                    //    if ((defaultValue == null) || (defaultValue.Count == 0))
                    //    {
                    //        p.StartInfo.Arguments = " '" + patient.PID.CardNO + "' " + "门诊" + "";// +" " + "'住院'";//启动参数      

                    //    }
                    //    else
                    //    {
                    //        p.StartInfo.Arguments = " '" + defaultValue[0].ToString() + "' " + "门诊" + "";// +" " + "'住院'";//启动参数      

                    //    }

                    #endregion
                    //p.StartInfo.Arguments = " '" + defaultValue[0].ToString() + "' " + "门诊" + "";// +" " + "'住院'";//启动参数      

                    // p.Start();//启动     
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.ClickedItem == this.tbPacsResultPrint)//{17CC6DF8-1883-4d3c-8D24-2E08C93F047F},Lis结果打印,shangxw 2009-11-10
            {
                Neusoft.HISFC.Models.Registration.Register patient = new Neusoft.HISFC.Models.Registration.Register();
                patient = this.ucOutPatientTree1.PatientInfo;
                //if continue?
                //DialogResult result = MessageBox.Show("是否打印LIS结果？", "提示", MessageBoxButtons.YesNo);
                //if (result == DialogResult.No)
                //{
                //    return;
                //}

                //Is "" or Null?
                if (patient == null || patient.PID.CardNO == "" || patient.PID.CardNO == null)
                {
                    MessageBox.Show("请选择一个患者！");


                    return;
                }

                try
                {
                    //string patientNo = patient.ID;
                    string patientNo = patient.PID.CardNO;
                    this.ucOutPatientOrder1.ShowPacsResultByPatient(patientNo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.ClickedItem == this.tbChooseDrugDept)
            {
                #region 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
                this.ChooseDrugDept(true);
                #endregion
            }
            else if (e.ClickedItem == this.tbClinicCase)
            {
                #region 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
                ShowClinicCase();
                #endregion
            }
        }

        /// <summary>
        /// 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
        /// </summary>
        private void ShowClinicCase()
        {
            StringBuilder strPatientInfo = new StringBuilder("");
            try
            {
                #region 拼串
                Neusoft.HISFC.Models.Registration.Register register = this.ucOutPatientTree1.PatientInfo;
                if (register == null || string.IsNullOrEmpty(register.ID))
                {
                    MessageBox.Show("患者基本信息为空！");
                    return;
                }
                /*
                Args[0]	操作员代码
                Args[1]	操作员名称
                Args[2]	操作员所在科室代码
                Args[3]	操作员所在科室名称
                */
                strPatientInfo.Append(orderManager.Operator.ID + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Name + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Dept.ID + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Dept.Name + "\r\n");
                /*
                 * Args[4]	PATIENT_ID	病人标识号	C	16	病人唯一标识号，可以由用户赋予具体的含义，如：病案号，门诊号等
                Args[5]	NAME	姓名	C	30	病人姓名
                Args[6]	NAME_PHONETIC	姓名拼音	C	16	病人姓名拼音，大写，字间用一个空格分隔，超长截断
                Args[7]	SEX	性别	C	8	男、女、未知，使用名称
                Args[8]	DATE_OF_BIRTH	出生日期	D	　	　
                Args[9]	BIRTH_PLACE	出生地	C	80	指定省市县，使用名称
                Args[10]	CITIZENSHIP	国籍	C	28	使用国家代码，使用名称
                Args[11]	NATION	民族	C	10	民族规范名称，使用名称
                Args[12]	ID_NO	身份证号	C	20	
                 */
                strPatientInfo.Append(register.ID + "\r\n");
                strPatientInfo.Append(register.Name + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(this.GetSex(register.Sex.ToString()) + "\r\n");
                strPatientInfo.Append(register.Birthday.ToString("yyyyMMdd") + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressHome) + "\r\n");
                strPatientInfo.Append("中国" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Nationality.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.IDCard) + "\r\n");
                /*
                Args[13]	IDENTITY	身份	C	16	由身份登记子系统生成，门诊登记子系统在办理入院时更新。使用规范名称，由用户定义使用名称
                Args[14]	CHARGE_TYPE	费别	C	8	由身份登记子系统生成，门诊登记子系统在办理入院时更新。使用规范名称，由用户定义，使用名称
                Args[15]	UNIT_IN_CONTRACT	合同单位	C	40	如果病人所在单位为本医院的合同单位或体系单位，则使用代码，否则为空。由身份登记子系统生成，门诊登记子系统在办理入院时更新。使用名称
                Args[16]	MAILING_ADDRESS	通信地址	C	80	指永久通信地址
                Args[17]	ZIP_CODE	邮政编码	C	6	对应通信地址的邮政编码
                Args[18]	PHONE_NUMBER_HOME	家庭电话号码	C	16	　2
                Args[19]	PHONE_NUMBER_BUSINESS	单位电话号码	C	16	　
                Args[20]	NEXT_OF_KIN	联系人姓名	C	30	病人的亲属姓名
                Args[21]	RELATIONSHIP	与联系人关系	C	16	夫妻、父子等，使用名称
                Args[22]	NEXT_OF_KIN_ADDR	联系人地址	C	80	　
                Args[23]	NEXT_OF_KIN_ZIP_CODE	联系人邮政编码	C	6	　
                Args[24]	NEXT_OF_KIN_PHONE	联系人电话号码	C	20	　
                Args[25]	LAST_VISIT_DATE	上次就诊日期	D	　	由挂号与预约子系统根据就诊记录填写
                Args[26]	VIP_INDICATOR	重要人物标志	N	1	1-VIP 0-非VIP
                Args[27]	CREATE_DATE	建卡日期	D	　	　
                Args[28]	OPERATOR	操作员	C	8	最后修改本记录的操作员姓名
                 */
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressHome) + "\r\n");
                strPatientInfo.Append(this.GetString(register.PhoneHome) + "\r\n");
                strPatientInfo.Append(this.GetString(register.PhoneBusiness) + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append((register.VipFlag == true ? "1" : "0") + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Name + "\r\n");
                /*
                Args[29]	PATIENT_ID	病人标识	C	16	非空
                Args[30]	VISIT_ID	病人本次门诊就诊次数	N	4	取该患者挂号次数
                Args[31]	DEPT_ADMISSION_TO	门诊就诊科室	C	8	按统计要求的科室代码，见2.6科室字典
                Args[32]	ADMISSION_DATE_TIME	门诊就诊日期及时间	D	　	　
                Args[33]	OCCUPATION	职业	C	40	使用名称
                Args[34]	MARITAL_STATUS	婚姻状况	C	4	已婚、未婚、离婚、丧偶，使用规范名称，
                Args[35]	IDENTITY	身份	C	16	使用名称
                Args[36]	ARMED_SERVICES	　	C	4	填空
                Args[37]	DUTY	　	C	4	填空
                Args[38]	UNIT_IN_CONTRACT	合同单位	C	40	病人所属的体系单位名称，用户定义，没有就添空
                Args[39]	CHARGE_TYPE	费别	C	20	使用规范名称
                Args[40]	WORKING_STATUS	在职标志	N	1	0-在职 1-离休 2-退休
                Args[41]	INSURANCE_TYPE	医保类别	C	16	如果此病人为医保病人，则记录反映本次门诊支付方案的医保类别
                Args[42]	INSURANCE_NO	医疗保险号	C	18	如果此病人为医保病人，则记录其保险号
                Args[43]	SERVICE_AGENCY	工作单位	C	80	　
                Args[44]	MAILING_ADDRESS	通信地址	C	80	　
                Args[45]	ZIP_CODE	邮政编码	C	10	　
                Args[46]	NEXT_OF_KIN	联系人姓名	C	30	病人的亲属姓名
                Args[47]	RELATIONSHIP	与联系人关系	C	16	夫妻、父子等，使用名称
                Args[48]	NEXT_OF_KIN_ADDR	联系人地址	C	80	　
                Args[49]	NEXT_OF_KIN_ZIPCODE	联系人邮政编码	C	6	　
                Args[50]	NEXT_OF_KIN_PHONE	联系人电话	C	20	　
                 * Args[51]	INP_NO	住院号
                 */
                strPatientInfo.Append(this.GetString(register.ID) + "\r\n");
                strPatientInfo.Append("1" + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Dept.ID + "\r\n");
                strPatientInfo.Append(this.GetString(register.DoctorInfo.SeeDate.ToString("yyyy-MM-dd HH:mm:ss")) + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append("0" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.SSN) + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressBusiness) + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressHome) + "\r\n");
                strPatientInfo.Append(this.GetString(register.HomeZip) + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");

                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("获取患者基本信息失败！" + e.ToString());
                return;
            }

            try
            {
                #region 显示
                JHEMR.OutpatientEMREdit.Class1 jhEMR = new JHEMR.OutpatientEMREdit.Class1();
                jhEMR.MyDiagnose(strPatientInfo.ToString());
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("电子病历显示失败！" + e.ToString());
                return;
            }
        }


        /// <summary>
        /// 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        private string GetSex(string sex)
        {
            switch (sex)
            {
                case "M":
                    return "男";
                    break;
                case "F":
                    return "女";
                    break;
                default:
                    return "未知";
                    break;
            }
        }

        /// <summary>
        /// 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        private string GetString(object sourceStr)
        {
            if (sourceStr == null)
            {
                return "";
            }
            else
            {
                return sourceStr.ToString();
            }
        }

        /// <summary>
        /// 选择药房 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        /// <param name="isClear"></param>
        private void ChooseDrugDept(bool isClear)
        {
            try
            {
                if (isClear)
                {
                    this.ucOutPatientOrder1.Clear();
                }
                ZZLocal.HISFC.Components.Pharmacy.ucDrugDeptSelect ucDrugDept = new ZZLocal.HISFC.Components.Pharmacy.ucDrugDeptSelect();
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucDrugDept);
                this.SetToolBarText();
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        private void SetToolBarText()
        {
            if (HISFC.BizProcess.Integrate.Function.DrugDept != null)
            {
                this.tbChooseDrugDept.Text = "选择药房";
                this.tbChooseDrugDept.ToolTipText = "当前药房：" + HISFC.BizProcess.Integrate.Function.DrugDept.Name + "，点击选择其他药房";
            }
            else
            {
                this.tbChooseDrugDept.Text = "选择药房";
                this.tbChooseDrugDept.ToolTipText = "没有指定药房，请点击选择药房";
            }
        }

        private void SaveGroup()
        {
            Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager group = new Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager();
            group.InpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.C;
            try
            {
                group.IsManager = (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager;
            }
            catch
            { }

            ArrayList al = new ArrayList();
            for (int i = 0; i < this.ucOutPatientOrder1.neuSpread1.ActiveSheet.Rows.Count; i++)
            {
                //if (this.ucOutPatientOrder1.neuSpread1.ActiveSheet.IsSelected(i, 0))
                //{
                    Neusoft.HISFC.Models.Order.OutPatient.Order order = this.ucOutPatientOrder1.GetObjectFromFarPoint(i, this.ucOutPatientOrder1.neuSpread1.ActiveSheetIndex).Clone();
                    if (order == null)
                    {
                        MessageBox.Show("获得医嘱出错！");
                    }
                    else
                    {
                        string s = order.Item.Name;
                        string sno = order.Combo.ID;
                        //保存医嘱组套 默认开立时间为 零点
                        order.BeginTime = new DateTime(order.BeginTime.Year, order.BeginTime.Month, order.BeginTime.Day, 0, 0, 0);
                        al.Add(order);
                    }
                //}
            }
            if (al.Count > 0)
            {
                group.alItems = al;
                group.ShowDialog();
                this.tvGroup.RefrshGroup();
            }
        }


        #region IPreArrange 成员   {B17077E6-7E65-45fb-BA25-F2883EB6BA27}

        public int PreArrange()
        {
            this.ucOutPatientTree1.InitControl();

            if (this.ucOutPatientTree1.RefreshTreeView() == -1)
            {
                return -1;
            }

            return 1;
        }

        #endregion

        #region IInterfaceContainer 成员    {E53A21A7-2B74-4b48-A9F4-9E05F8FA11A2}

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { typeof( Neusoft.HISFC.BizProcess.Interface.DCP.IDCP ) };
            }
        }

        #endregion
    }
}

