using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.WinForms.WorkStation
{
    /// <summary>
    /// 医嘱管理主窗口
    /// </summary>
    public partial class frmOrder : Neusoft.FrameWork.WinForms.Forms.frmBaseForm,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        private Control CurrentControl;

        public frmOrder()
        {
            
            InitializeComponent();

            this.SetTree(this.tvDoctorPatientList1);
            this.iQueryControlable = this.ucOrder1 as Neusoft.FrameWork.WinForms.Forms.IQueryControlable;
            this.iControlable = this.ucOrder1 as Neusoft.FrameWork.WinForms.Forms.IControlable;
            this.CurrentControl = this.ucOrder1;
            this.tbGroup.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套);
            this.tbQueryOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询);
            this.tbExitOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出);
            this.tbPrintOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印);
            this.tbGroup.CheckState = CheckState.Unchecked;
            this.Resize += new EventHandler(frmOrder_Resize);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            #region  {49026086-DCA3-4af4-A064-58F7479C324A}
            this.ucOrder1.refreshGroup += new Neusoft.HISFC.Components.Order.Controls.RefreshGroupTree(ucOrder1_refreshGroup);
            #endregion
        }

        #region {49026086-DCA3-4af4-A064-58F7479C324A}
        /// <summary>
        /// 刷新组套树
        /// </summary>
        private void ucOrder1_refreshGroup()
        {
            this.tvGroup.RefrshGroup();
        }
        #endregion
        //{A5409134-55B5-42d9-A264-25060169A64B}
        private Neusoft.FrameWork.Public.ObjectHelper frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 传染病上报类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.DCP.IDCP dcpInstance = null;

        #region addby xuewj 2010-10-20 {BB852AD4-81CC-44aa-86F7-FD4C419DDFAC} 组套调医嘱时根据参数RemoveDrugRoom屏蔽发药药房--郑州用来处理临床营养药房
        /// <summary>
        /// 药品业务类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyMgr = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy(); 
        #endregion

        void frmOrder_Resize(object sender, EventArgs e)
        {
            this.panelTree.Height = this.Height - 162;

        }


        Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup tvGroup = null;//组套
        bool isEditGroup = false;
        private void frmOrder_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.tbFilter.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked_1);
            this.AddOrderHandle();
            this.initButton(false);

            this.tbAddOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y医嘱);
            this.tbComboOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并);
            this.tbCancelOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消);
            this.tbDelOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage( Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除);
            this.tbOperation.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage( Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z诊断);
            this.tbSaveOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage( Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存);
            this.tbCheck.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage( Neusoft.FrameWork.WinForms.Classes.EnumImageList.H换单);
            this.tb1Exit.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage( Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出);
            this.tsbHerbal.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.M明细);
            ///{FB86E7D8-A148-4147-B729-FD0348A3D670}  增加医嘱重整按钮
            this.tbRetidyOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T套餐);

            #region add by xuewj 增加化疗按钮 {1F2B9330-7A32-4da4-8D60-3A4568A2D1D8}
            this.tbAssayCure.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H化验);
            #endregion
            #region {3559BBC9-3799-4a46-AB1A-716601D34543}
            this.tbDiseaseReport.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.J健康档案);
            this.tbFilter.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找);
            #endregion
            //加入选择医生按钮{D5517722-7128-4d0c-BBC4-1A5558A39A03}
            this.tbChooseDoct.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H换医师);
            //进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
            this.tbChooseDrugDept.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.K科室);
            this.panelTree.Height = this.Height - 162;
            //{A5409134-55B5-42d9-A264-25060169A64B}
            ArrayList alFrequency = Neusoft.HISFC.Components.Order.Classes.Function.HelperFrequency.ArrayObject;
            if (alFrequency != null)
            {
                this.frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alFrequency);
            }
            this.toolStrip1.Focus();

            #region {F6767B0D-4BA4-4920-863F-40912AC3B554}

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamMgr = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            string treeSearchMode = "1";

            treeSearchMode = controlParamMgr.GetControlParam<string>("200303", true, "1");

            if (treeSearchMode == "2")
            {
                this.ucQueryInpatientNo1.Visible = true;
            }
            else
            {
                this.ucQueryInpatientNo1.Visible = false;
            }

            #endregion

            #region {0768F6B2-B3FD-42f4-B83E-3422E3A319E2}
            this.SetMenuVisible();
            #endregion

            //进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
            this.ChooseDrugDept(false);
            //this.SetToolBarText();
        }


        #region 私有函数

        /// <summary>
        /// {0768F6B2-B3FD-42f4-B83E-3422E3A319E2}
        /// 菜单设置可见性
        /// </summary>
        private void SetMenuVisible()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager dictionaryMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            ArrayList alset = dictionaryMgr.GetConstantList("INPATMENU");

            Neusoft.FrameWork.Public.ObjectHelper setHelper = new Neusoft.FrameWork.Public.ObjectHelper();

            setHelper.ArrayObject = alset;

            if (setHelper.GetObjectFromID(this.tb1Exit.Name) == null)
            {
                this.tb1Exit.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbAddOrder.Name) == null)
            {
                this.tbAddOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbAssayCure.Name) == null)
            {
                this.tbAssayCure.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbCancelOrder.Name) == null)
            {
                this.tbCancelOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbCheck.Name) == null)
            {
                this.tbCheck.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbChooseDoct.Name) == null)
            {
                this.tbChooseDoct.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbComboOrder.Name) == null)
            {
                this.tbComboOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbDelOrder.Name) == null)
            {
                this.tbDelOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbDiseaseReport.Name) == null)
            {
                this.tbDiseaseReport.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbExitOrder.Name) == null)
            {
                this.tbExitOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbFilter.Name) == null)
            {
                this.tbFilter.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbGroup.Name) == null)
            {
                this.tbGroup.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbLisResultPrint.Name) == null)
            {
                this.tbLisResultPrint.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbOperation.Name) == null)
            {
                this.tbOperation.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbPacsResultPrint.Name) == null)
            {
                this.tbPacsResultPrint.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbPrintOrder.Name) == null)
            {
                this.tbPrintOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbQueryOrder.Name) == null)
            {
                this.tbQueryOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbRefresh.Name) == null)
            {
                this.tbRefresh.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbRetidyOrder.Name) == null)
            {
                this.tbRetidyOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tbSaveOrder.Name) == null)
            {
                this.tbSaveOrder.Visible = false;
            }
            if (setHelper.GetObjectFromID(this.tsbHerbal.Name) == null)
            {
                this.tsbHerbal.Visible = false;
            }
        }

        private void initButton(bool isDisign)
        {
            this.tbGroup.Enabled = !isDisign;
            tbRefresh.Enabled = !isDisign;
            this.tbAddOrder.Enabled = !isDisign;
            this.tbComboOrder.Enabled = isDisign;
            this.tbCancelOrder.Enabled = isDisign;
            this.tbCheck.Enabled = isDisign;
            //this.tbOperation.Enabled = false;
            this.tbOperation.Enabled = isDisign;
            this.tbAssayCure.Enabled = isDisign;
            this.tbDelOrder.Enabled = isDisign;
            this.tbExitOrder.Enabled = isDisign;
            this.tbFilter.Enabled = !isDisign;
            this.tbQueryOrder.Enabled = !isDisign;
            this.tbSaveOrder.Enabled = isDisign;
            this.tsbHerbal.Enabled = isDisign;
            //{D5517722-7128-4d0c-BBC4-1A5558A39A03}
            this.tbChooseDoct.Enabled = isDisign;
            if (isDisign) //开立
            {
                if (tvGroup == null)
                {
                    tvGroup = new Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup();
                    tvGroup.Type = Neusoft.HISFC.Components.Common.Controls.enuType.Order;
                    tvGroup.Init();
                    tvGroup.SelectOrder += new Neusoft.HISFC.Components.Common.Controls.SelectOrderHandler(tvGroup_SelectOrder);
                }
                tvGroup.Dock = DockStyle.Fill;
                tvGroup.Visible = true;
                
                this.tvDoctorPatientList1.Visible = false;
                this.panelTree.Controls.Add(tvGroup);
                //{D5517722-7128-4d0c-BBC4-1A5558A39A03}
                //判断当前人员是否医生
                if (((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).EmployeeType.ID.ToString() == Neusoft.HISFC.Models.Base.EnumEmployeeType.D.ToString())
                {
                    this.tbChooseDoct.Enabled = false;
                }
                else
                {
                    this.tbChooseDoct.Enabled = true;
                }
                #region {190B18B2-9CF0-4b44-BB93-63A15387AD0B}
                if (this.ucOrder1.OrderType == Neusoft.HISFC.Models.Order.EnumType.LONG)
                {
                    this.tsbHerbal.Enabled = false;
                    this.tbOperation.Enabled = false;
                }
                #endregion

            }
            else
            {
                this.tvDoctorPatientList1.Visible = true;
                if(tvGroup!=null) tvGroup.Visible = false;
            }
        }

        void tvGroup_SelectOrder(System.Collections.ArrayList alOrders)
        {
            //{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988} //草药弹出草药开立界面
            ArrayList alHerbal = new ArrayList(); //草药

            foreach(Neusoft.HISFC.Models.Order.Inpatient.Order order in alOrders)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order myorder = order.Clone();
                myorder.Patient.PVisit.PatientLocation.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                if (fillOrder(ref myorder) != -1)
                {
                    if (order.Item.SysClass.ID.ToString() == "PCC") //草药
                    {
                        alHerbal.Add(order);
                    }
                    else
                    {
                        if (myorder.OrderType.IsDecompose)
                        {
                            this.ucOrder1.AddNewOrder(myorder, 0);
                        }
                        else
                        {
                            this.ucOrder1.AddNewOrder(myorder, 1);
                        }
                    }
                }
            }

            if (alHerbal.Count > 0)
            {
                this.ucOrder1.AddHerbalOrders(alHerbal);
            }
            this.ucOrder1.RefreshCombo();
           
        }

        private int  fillOrder(ref Neusoft.HISFC.Models.Order.Inpatient.Order order)
        { string err = "";
            //if (order.Item.IsPharmacy)
       if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
        //if (order.Item.IsPharmacy)
       {
           #region addby xuewj 2010-10-20 {BB852AD4-81CC-44aa-86F7-FD4C419DDFAC} 组套调医嘱时根据参数RemoveDept屏蔽发药药房--郑州用来处理临床营养药房
           Neusoft.FrameWork.Models.NeuObject stockDept = new Neusoft.FrameWork.Models.NeuObject();
                if (order.StockDept.ID != "")
                {
                    //stockDept = this.pharmacyMgr.GetStockDept(order.Patient.PVisit.PatientLocation.Dept.ID, order.Item.SysClass.ID.ToString(), order.Item.ID);//原来只适用与西药，中成药和草药会报错.不应该传sysClassID，要用药品类别
                    stockDept = this.pharmacyMgr.GetStockDept(order.Patient.PVisit.PatientLocation.Dept.ID, ((Neusoft.HISFC.Models.Pharmacy.Item)(order.Item)).Type.ID.ToString(), order.Item.ID);
                    if (stockDept == null)
                    {
                        MessageBox.Show(this.pharmacyMgr.Err);
                        return -1;
                    }
                }
                if (Neusoft.HISFC.BizProcess.Integrate.Order.FillPharmacyItemWithStockDept(null, ref order, out err) == -1)
                {
                    MessageBox.Show(err);
                    return -1;
                }
                if (stockDept.ID != "")
                {
                    order.StockDept.ID = stockDept.ID;
                    order.StockDept.Name = stockDept.Name;
                } 
                #endregion
            }
            else
            {
                if (Neusoft.HISFC.BizProcess.Integrate.Order.FillFeeItem(null, ref order, out err) == -1)
                {
                    MessageBox.Show(err);
                    return -1;
                }
            }
            //{A5409134-55B5-42d9-A264-25060169A64B}
            Neusoft.FrameWork.Models.NeuObject trueFrequency = this.frequencyHelper.GetObjectFromID(order.Frequency.ID);
            if (trueFrequency != null)
            {
                order.Frequency = trueFrequency as Neusoft.HISFC.Models.Order.Frequency;
            }

            return 0;
        }
        private void initButtonGroup(bool isEdit)
        {
            this.tbAddOrder.Enabled = !isEdit;
            this.tbSaveOrder.Enabled = isEdit;
            this.tbRefresh.Enabled = !isEdit;
            this.tbExitOrder.Enabled = isEdit;
            this.isEditGroup = isEdit;
            //{EB959BC4-9120-478a-B527-74A1D7EF4C9E}
            this.tbComboOrder.Enabled = isEdit;
            this.tbCancelOrder.Enabled = isEdit;
            //{74E478F5-BDDD-4637-9F5A-E251AF9AA72F}
            this.tbRetidyOrder.Enabled = !isEdit;

            if (isEdit) //开立
            {
                if (tvGroup == null)
                {
                    tvGroup = new Neusoft.HISFC.Components.Common.Controls.tvDoctorGroup();
                    tvGroup.Type = Neusoft.HISFC.Components.Common.Controls.enuType.Order;
                    tvGroup.Init();
                    tvGroup.SelectOrder+=new Neusoft.HISFC.Components.Common.Controls.SelectOrderHandler(tvGroup_SelectOrder);
                }
                tvGroup.Dock = DockStyle.Fill;
                tvGroup.Visible = true;
                this.tbDelOrder.Enabled = isEdit;//{11F97F55-F747-4ad9-A74F-086635D5EBD9}

                this.tvDoctorPatientList1.Visible = false;
                this.panelTree.Controls.Add(tvGroup);
            }
            else
            {
                this.tvDoctorPatientList1.Visible = true;
                if (tvGroup != null) tvGroup.Visible = false;
            }
        }

        private void AddOrderHandle()
        {
            this.ucOrder1.OrderCanCancelComboChanged += new Neusoft.HISFC.Components.Order.Controls.ucOrder.EventButtonHandler(ucOrder1_OrderCanCancelComboChanged);
            this.ucOrder1.OrderCanOperatorChanged += new Neusoft.HISFC.Components.Order.Controls.ucOrder.EventButtonHandler(ucOrder1_OrderCanOperatorChanged);
            this.ucOrder1.OrderCanSetCheckChanged += new Neusoft.HISFC.Components.Order.Controls.ucOrder.EventButtonHandler(ucOrder1_OrderCanSetCheckChanged);
        }

        void ucOrder1_OrderCanSetCheckChanged(bool b)
        {
            this.tbCheck.Enabled = b;
        }

        void ucOrder1_OrderCanOperatorChanged(bool b)
        {
            this.tbOperation.Enabled = b;
            this.tbAssayCure.Enabled = b;
            #region {190B18B2-9CF0-4b44-BB93-63A15387AD0B}
            this.tsbHerbal.Enabled = b;
            #endregion
        }

        void ucOrder1_OrderCanCancelComboChanged(bool b)
        {
            this.tbCancelOrder.Enabled = b;
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
                    this.ucOrder1.Clear();
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
        #endregion

        Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
        Neusoft.HISFC.BizProcess.Integrate.RADT inpatientManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.BizLogic.Order.Consultation consultation = new Neusoft.HISFC.BizLogic.Order.Consultation();
        protected string inpatientNo;
        ArrayList co = null;

        #region 事件
        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.tbAddOrder)
            {
                /// <summary>
                /// [功能描述: 开立医嘱]<br></br>
                /// [创 建 者: ]<br></br>
                /// [创建时间: ]<br></br>
                /// <修改记录
                ///		修改人='张琦'
                ///		修改时间='2007-8-25'
                ///		修改目的='对会诊医师能否开立医嘱进行控制'
                ///		修改描述='判断会诊患者有无开立医嘱的权限'
                ///  />
                /// </summary>
                //选择子节点
                if (this.tvDoctorPatientList1.SelectedNode.Parent != null && this.tvDoctorPatientList1.SelectedNode.Parent.Tag != null)
                {
                    int count = 0;
                    count = this.tvDoctorPatientList1.SelectedNode.Parent.GetNodeCount(false);
                    //判断所选节点父节点如果为会诊患者,则判断有无开立医嘱的权限/如果不是会诊患者则不需要进行判断,都可以进行开立医嘱
                    if (this.tvDoctorPatientList1.SelectedNode.Parent.Text == ("会诊患者" + "(" + count.ToString() + ")"))
                    {
                        patient = this.tvDoctorPatientList1.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

                        //处理床位号截位
                        string bedNO = patient.PVisit.PatientLocation.Bed.ID;
                        if (bedNO.Length > 4)
                        {
                            bedNO = bedNO.Substring( 4 );
                        }
                        //处理住院号显示
                        string patientNO = patient.PID.PatientNO;
                        if (string.IsNullOrEmpty( patientNO ) == true)
                        {
                            patientNO = patient.ID;
                        }

                        this.Text = "您正在操作的患者为 住院号：" + patientNO + "姓名：" + patient.Name + "性别：" + patient.Sex.Name + "年龄：" + consultation.GetAge(this.patient.Birthday) + " 床号:" + bedNO;
                        inpatientNo = patient.ID;
                        co = consultation.QueryConsulation(this.inpatientNo);
                        if (co != null || co.Count != 0)
                            for (int i = 0; i < co.Count; i++)
                            {
                                Neusoft.HISFC.Models.Order.Consultation obj = co[i] as Neusoft.HISFC.Models.Order.Consultation;
                                //根据会诊患者有效的会诊单信息,判断医生是否有对该会诊患者开立医嘱权限
                                if ((Neusoft.FrameWork.Management.Connection.Operator.ID == obj.DoctorConsultation.ID) &&
                                    (obj.EndTime >= consultation.GetDateTimeFromSysDateTime())
                                    && (obj.IsCreateOrder))
                                {
                                    if (this.ucOrder1.Add() == 0)
                                        this.initButton(true);
                                    break;//{3541798B-AF9C-415c-AFAA-8BD22A34A808}
                                }
                                else
                                {
                                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("对不起,您没有对该患者开立医嘱的权限!"), "提示");
                                    return;
                                }
                            }
                    }
                    else
                    {
                        Neusoft.HISFC.Models.RADT.PatientInfo patient1 = this.tvDoctorPatientList1.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

                        //处理床位号截位
                        string bedNO = patient1.PVisit.PatientLocation.Bed.ID;
                        if (bedNO.Length > 4)
                        {
                            bedNO = bedNO.Substring( 4 );
                        }
                        //处理住院号显示
                        string patientNO = patient1.PID.PatientNO;
                        if (string.IsNullOrEmpty( patientNO ) == true)
                        {
                            patientNO = patient1.ID;
                        }

                        this.Text = "您正在操作的患者为 住院号：" + patientNO + "姓名：" + patient1.Name + " 性别：" + patient1.Sex.Name + "年龄：" + consultation.GetAge(patient1.Birthday) + " 床号:" + bedNO;

                        //{FBBE8298-886C-4b33-8CF6-69134BE95422} 判断是否请假患者 20100507 yangw
                        if (patient1.PVisit.PatientLocation.Bed != null && patient1.PVisit.PatientLocation.Bed.Status.ID.ToString() == Neusoft.HISFC.Models.Base.EnumBedStatus.R.ToString())
                        {//请假患者不能开医嘱，须先销假，主要为防止请假后开立长嘱下次执行时间不对，这个bug有点2
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("患者请假中，如需开立医嘱请先销假"));
                            return;
                        }

                        if (this.ucOrder1.Add() == 0)
                            this.initButton(true);
                    }
                }
            }
            else if (e.ClickedItem == this.tbCheck)
            {
                this.ucOrder1.AddTest();
            }
            else if (e.ClickedItem == this.tbRefresh)
            {
                //刷新
                this.tvDoctorPatientList1.RefreshInfo();
            }
            else if (e.ClickedItem == this.tbGroup)
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
                    this.ucOrder1.SetEditGroup(true);
                    this.ucOrder1.SetPatient(null);
                    this.initButtonGroup(true);

                }
                else
                {
                    this.ucOrder1.SetEditGroup(false);
                    this.initButtonGroup(false);
                }

            }
            else if (e.ClickedItem == this.tbOperation)
            {
                //Neusoft.HISFC.Models.RADT.PatientInfo pi = (Neusoft.HISFC.Models.RADT.PatientInfo)this.tvDoctorPatientList1.SelectedNode.Tag;
                //frmOperation frmOpt = new frmOperation(pi);
                //frmOpt.ShowDialog();

                //ucOperation operation = new ucOperation(pi);
                //operation.Show();
                //operation.Show();
                //UFC.Operation.ucApplicationForm appForm = new UFC.Operation.ucApplicationForm();
                //appForm.PatientInfo = pi;
                //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(appForm);
                //appForm.Show();
                //UFC.Operation.ucApplication ucApply = new UFC.Operation.ucApplication(pi, pi);
                Neusoft.HISFC.Models.RADT.PatientInfo pi = (Neusoft.HISFC.Models.RADT.PatientInfo)this.tvDoctorPatientList1.SelectedNode.Tag;
                frmOperation frmOpt = new frmOperation(pi);
                frmOpt.ShowDialog();
            }
            else if (e.ClickedItem == this.tbAssayCure)
            {
                this.ucOrder1.AddAssayCure();
            }
            else if (e.ClickedItem == this.tbDelOrder)
            {
                this.ucOrder1.Delete();
            }
            else if (e.ClickedItem == this.tbQueryOrder)
            {
                try
                {

                    this.ucOrder1.Query(this.tvDoctorPatientList1.SelectedNode, this.tvDoctorPatientList1.SelectedNode.Tag);
                }
                catch { }
            }
            else if (e.ClickedItem == this.tbPrintOrder)
            {
                if (CurrentControl != null)
                {
                    try
                    {
                        Neusoft.FrameWork.WinForms.Controls.ucBaseControl control = CurrentControl as Neusoft.FrameWork.WinForms.Controls.ucBaseControl;
                        if (control != null)
                            control.Print(null, null);
                    }
                    catch { }
                }

            }
            else if (e.ClickedItem == this.tbComboOrder)
            {
                this.ucOrder1.ComboOrder();
            }
            else if (e.ClickedItem == this.tbCancelOrder)
            {
                this.ucOrder1.CancelCombo();
            }
            else if (e.ClickedItem == this.tbExitOrder)
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
                    this.ucOrder1.SetEditGroup(false);
                    //this.initButtonGroup(false);//{64E07B94-39F0-439a-BB53-6C3D8DB7EFE4}退出医嘱，患者树不失去焦点

                }
                else
                {
                    if (this.ucOrder1.ExitOrder() == 0)
                        this.initButton(false);
                    tvDoctorPatientList1.RefreshInfo();
                }
            }
            else if (e.ClickedItem == this.tbInValid)
            {
                this.ucOrder1.Filter(Neusoft.HISFC.Components.Order.Controls.EnumFilterList.Invalid);
            }
            else if (e.ClickedItem == this.tbValid)
            {
                this.ucOrder1.Filter(Neusoft.HISFC.Components.Order.Controls.EnumFilterList.Valid);
            }
            else if (e.ClickedItem == this.tbAll)
            {
                this.ucOrder1.Filter(Neusoft.HISFC.Components.Order.Controls.EnumFilterList.All);
            }
            else if (e.ClickedItem == this.tbToday)
            {
                this.ucOrder1.Filter(Neusoft.HISFC.Components.Order.Controls.EnumFilterList.Today);
            }
            else if (e.ClickedItem == this.tbNew)
            {
                this.ucOrder1.Filter(Neusoft.HISFC.Components.Order.Controls.EnumFilterList.New);
            }
            else if (e.ClickedItem == this.tbSaveOrder)
            {
                //
                if (isEditGroup)
                {
                    SaveGroup();
                }
                else
                {
                    if (this.ucOrder1.Save() == -1)
                    {
                    }
                    else
                    {
                        this.initButton(false);
                        //tvDoctorPatientList1.RefreshInfo();//{64E07B94-39F0-439a-BB53-6C3D8DB7EFE4}保存医嘱，患者树不失去焦点
                    }
                }
            }
            else if (e.ClickedItem == this.tsbHerbal)
            {
                this.ucOrder1.HerbalOrder();
            }
            else if (e.ClickedItem == this.tbChooseDoct)//{D5517722-7128-4d0c-BBC4-1A5558A39A03}
            {
                this.ucOrder1.ChooseDoctor();
            }
            else if (e.ClickedItem == this.tb1Exit)
            {
                if (this.ucOrder1.IsDesignMode) //是在开立状态
                {
                    DialogResult result = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("医嘱目前处于开立模式，是否保存?"), "提示", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        if (this.ucOrder1.Save() == 0) this.Close();

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
            ///{FB86E7D8-A148-4147-B729-FD0348A3D670}  增加医嘱重整按钮
            else if (e.ClickedItem == this.tbRetidyOrder)
            {
                if (this.ucOrder1.IsDesignMode == false)
                {
                    this.ucOrder1.ReTidyOrder();
                }
                else
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("非开立状态下才允许进行医嘱重整"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (e.ClickedItem == this.tbDiseaseReport)      //  {E53A21A7-2B74-4b48-A9F4-9E05F8FA11A2} 传染病报告卡
            {
                if (this.dcpInstance == null)
                {
                    this.dcpInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject( this.GetType(), typeof( Neusoft.HISFC.BizProcess.Interface.DCP.IDCP ) ) as Neusoft.HISFC.BizProcess.Interface.DCP.IDCP;
                }

                if (this.dcpInstance != null)
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.tvDoctorPatientList1.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

                    this.dcpInstance.RegisterDiseaseReport(patientInfo,Neusoft.HISFC.Models.Base.ServiceTypes.I);
                }
            }
            else if (e.ClickedItem == this.tbLisResultPrint)//{17CC6DF8-1883-4d3c-8D24-2E08C93F047F},Lis结果打印,shangxw 2009-11-10
            {
                patient = this.tvDoctorPatientList1.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

                if (this.patient == null || this.patient.PID.ID == "" || this.patient.PID.ID == null)
                {
                    MessageBox.Show("请选择一个患者！");
                    return;

                }

                try
                {


                    #region 郑大修改---{15C4A9D2-34AF-484b-B65B-BBD3CACABA5C}

                    rm_barprinter_common.In_rm_barprinter_common mobj = new rm_barprinter_common.COClass_n_rm_barprinter_commonClass();

                    if (!string.IsNullOrEmpty(patient.ID))
                    {
                        mobj.uf_lis_result(patient.ID, "3");
                    }
                    else
                    {
                        MessageBox.Show("Lis调用失败");
                        return;
                    }

                    //string s = "LisResult";

                    //System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(s);
                    //if (proc.Length > 0)
                    //{
                    //    for (int i = 0; i < proc.Length; i++)
                    //    {
                    //        proc[i].Kill();
                    //    }
                    //}

                    //System.Diagnostics.Process p = new System.Diagnostics.Process();

                    //p.StartInfo.FileName = Application.StartupPath + @"\LisBin\LisResult.exe";    //需要启动的程序名       
                    //#region 取配置参数
                    //ArrayList defaultValue = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("lis");
                    //if ((defaultValue == null) || (defaultValue.Count == 0))
                    //{
                    //    p.StartInfo.Arguments = " '" + this.patient.PID.ID + "' " + "住院" + "";// +" " + "'住院'";//启动参数      

                    //}
                    //else
                    //{
                    //    p.StartInfo.Arguments = " '" + defaultValue[1].ToString() + "' " + "住院" + "";// +" " + "'住院'";//启动参数      

                    //}

                    //#endregion

                    //p.Start();//启动      
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.ClickedItem == this.tbPacsResultPrint)//{17CC6DF8-1883-4d3c-8D24-2E08C93F047F},Lis结果打印,shangxw 2009-11-10
            {
                patient = this.tvDoctorPatientList1.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
             
                if (this.patient == null || this.patient.PID.ID == "" || this.patient.PID.ID == null)
                {
                    MessageBox.Show("请选择一个患者！");
                    return;

                }

                try
                {
                    string patientNo = patient.ID;
                    this.ucOrder1.ShowPacsResultByPatient(patientNo);
                   
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
        }


        private void SaveGroup()
        {
            Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager group = new Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager();
           
            try
            {
                group.IsManager = (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager;
            }
            catch
            { }

            ArrayList al = new ArrayList();
            #region 长期临时一起保存组套{11F97F55-F747-4ad9-A74F-086635D5EBD9}
            for (int i = 0; i < this.ucOrder1.fpSpread1.Sheets[0].Rows.Count; i++)//长期医嘱
            {
                //{F4CA5CB3-0C23-4e0e-978D-5B72711A6C86}
                Neusoft.HISFC.Models.Order.Inpatient.Order longorderTemp = this.ucOrder1.GetObjectFromFarPoint(i, 0);
                if (longorderTemp == null)
                {
                    continue;
                }

                //Neusoft.HISFC.Models.Order.Inpatient.Order longorder = this.ucOrder1.GetObjectFromFarPoint(i, 0).Clone();
                Neusoft.HISFC.Models.Order.Inpatient.Order longorder = longorderTemp.Clone();
                if (longorder == null)
                {
                    MessageBox.Show("获得医嘱出错！");
                }
                else
                {
                    string s = longorder.Item.Name;
                    string sno = longorder.Combo.ID;
                    //保存医嘱组套 默认开立时间为 零点
                    longorder.BeginTime = new DateTime(longorder.BeginTime.Year, longorder.BeginTime.Month, longorder.BeginTime.Day, 0, 0, 0);
                    al.Add(longorder);
                }
            }
            for (int i = 0; i < this.ucOrder1.fpSpread1.Sheets[1].Rows.Count; i++)//临时医嘱
            {
                //{F4CA5CB3-0C23-4e0e-978D-5B72711A6C86}
                Neusoft.HISFC.Models.Order.Inpatient.Order shortorderTemp = this.ucOrder1.GetObjectFromFarPoint(i, 1);
                if (shortorderTemp == null)
                {
                    continue;
                }
                //Neusoft.HISFC.Models.Order.Inpatient.Order shortorder = this.ucOrder1.GetObjectFromFarPoint(i, 1).Clone();
                Neusoft.HISFC.Models.Order.Inpatient.Order shortorder = shortorderTemp.Clone();
                if (shortorder == null)
                {
                    MessageBox.Show("获得医嘱出错！");
                }
                else
                {
                    string s = shortorder.Item.Name;
                    string sno = shortorder.Combo.ID;
                    //保存医嘱组套 默认开立时间为 零点
                    shortorder.BeginTime = new DateTime(shortorder.BeginTime.Year, shortorder.BeginTime.Month, shortorder.BeginTime.Day, 0, 0, 0);
                    al.Add(shortorder);
                }
            }
            #endregion
            if (al.Count > 0)
            {
                group.alItems = al;
                group.ShowDialog();
                this.tvGroup.RefrshGroup();
            }
        }
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Controls.Count > 0)
            {
                this.iQueryControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IQueryControlable;
                this.iControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                this.CurrentControl = this.tabControl1.SelectedTab.Controls[0];
            }
        }

        #region add by xuewj 2009-8-25 查询出院患者，需要设置权限 {8B4B8C49-2181-4aeb-95D4-DADFDE26DBC2}

        private void ucQueryInpatientNo1_myEvent()
        {
            if (string.IsNullOrEmpty(this.ucQueryInpatientNo1.InpatientNo))
            {
                return;
            }
            #region {640B03D9-8D8D-4720-A05A-42691EAADD0B} 开立状态不能查询患者
            if (this.ucOrder1.IsDesignMode)
            {
                MessageBox.Show("开立状态不能查询患者");
                return;
            }
            #endregion
            this.tvDoctorPatientList1.QueryPaitent(this.ucQueryInpatientNo1.InpatientNo,this.consultation.Operator as Neusoft.HISFC.Models.Base.Employee);
        }

        private void tvDoctorPatientList1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvDoctorPatientList1.SelectedNode.Tag != null 
               && this.tvDoctorPatientList1.SelectedNode.Tag.ToString() != ""
               && this.tvDoctorPatientList1.SelectedNode.Parent != null)
            {
                if (this.tvDoctorPatientList1.SelectedNode.Parent.Tag != null
                    && this.tvDoctorPatientList1.SelectedNode.Parent.Tag.ToString() != "")
                {
                    if (this.tvDoctorPatientList1.SelectedNode.Parent.Tag.ToString() == "QueryPatient")
                    {
                        if (this.CurrentControl.GetType().FullName == "Neusoft.HISFC.Components.Order.Controls.ucOrder")
                        {
                            this.tbAddOrder.Enabled = false;
                        }
                        //else if (this.CurrentControl.GetType().FullName == "Neusoft.HISFC.Components.Order.Controls.ucOrderPrint")
                        //{

                        //}
                        //else
                        //{
                        //    base.tree.SelectedNode = this.tvDoctorPatientList1.SelectedNode.Parent;
                        //}
                    }
                    else
                    {
                        if (this.CurrentControl.GetType().FullName == "Neusoft.HISFC.Components.Order.Controls.ucOrder")
                        {
                            this.tbAddOrder.Enabled = true;
                        }
                    }

                }
            }
        }

        #endregion

        #region IInterfaceContainer 成员    {E53A21A7-2B74-4b48-A9F4-9E05F8FA11A2}

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { 
                    typeof(Neusoft.HISFC.BizProcess.Interface.DCP.IDCP) ,
                typeof(Neusoft.HISFC.BizProcess.Interface.Common.IPacs)};
            }
        }

        #endregion       

        private void frmOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ucOrder1.RelePacsInterface();
        }
    }
}