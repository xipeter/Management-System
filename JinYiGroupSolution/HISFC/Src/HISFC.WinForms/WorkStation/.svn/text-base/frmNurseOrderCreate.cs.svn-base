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
    /// {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
    /// 护士医嘱管理主窗口
    /// </summary>
    public partial class frmNurseOrderCreate : Neusoft.FrameWork.WinForms.Forms.frmBaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        private Control CurrentControl;

        /// <summary>
        /// 
        /// </summary>
        public frmNurseOrderCreate()
        {
            
            InitializeComponent();

            this.SetTree(this.tvNursePatientList1);
            this.ucOrder1.IsNurseCreate = true;
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

            this.tbGroup.Visible = false;
            this.tbOperation.Visible = false;
            this.tbCheck.Visible = false;
            this.tbAssayCure.Visible = false;
            this.tbPrintOrder.Visible = false;
            this.tsbHerbal.Visible = false;
            this.tbQueryOrder.Visible = false;
            this.tbRetidyOrder.Visible = false;
            this.tbFilter.Visible = false;
            this.toolStripSeparator4.Visible = false;
            this.toolStripSeparator5.Visible = false;
            this.tvNursePatientList1.Refresh();
        }
        //{A5409134-55B5-42d9-A264-25060169A64B}
        private Neusoft.FrameWork.Public.ObjectHelper frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper();


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

            //加入选择医生按钮{D5517722-7128-4d0c-BBC4-1A5558A39A03}
            this.tbChooseDoct.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H换医师);
            this.panelTree.Height = this.Height - 162;
            //{A5409134-55B5-42d9-A264-25060169A64B}
            ArrayList alFrequency = Neusoft.HISFC.Components.Order.Classes.Function.HelperFrequency.ArrayObject;
            if (alFrequency != null)
            {
                this.frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alFrequency);
            }

        }


        #region 私有函数
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
                
                this.tvNursePatientList1.Visible = false;
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

            }
            else
            {
                this.tvNursePatientList1.Visible = true;
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

        private int fillOrder(ref Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            string err = "";
            //if (order.Item.IsPharmacy)
            if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            //if (order.Item.IsPharmacy)
            {
                //护士不允许开立药品 {5DE2C8F9-2E5D-43d6-9CAD-A5E0F60AC94B
                return -1;
                //if (Neusoft.HISFC.BizProcess.Integrate.Order.FillPharmacyItemWithStockDept(null, ref order, out err) == -1)
                //{
                //    MessageBox.Show(err);
                //    return -1;
                //}
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
               
                this.tvNursePatientList1.Visible = false;
                this.panelTree.Controls.Add(tvGroup);
            }
            else
            {
                this.tvNursePatientList1.Visible = true;
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
        }

        void ucOrder1_OrderCanCancelComboChanged(bool b)
        {
            this.tbCancelOrder.Enabled = b;
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
                if (this.tvNursePatientList1.SelectedNode.Parent != null && this.tvNursePatientList1.SelectedNode.Parent.Tag != null)
                {
                    int count = 0;
                    count = this.tvNursePatientList1.SelectedNode.Parent.GetNodeCount(false);
                    //判断所选节点父节点如果为会诊患者,则判断有无开立医嘱的权限/如果不是会诊患者则不需要进行判断,都可以进行开立医嘱
                    if (this.tvNursePatientList1.SelectedNode.Parent.Text == ("会诊患者" + "(" + count.ToString() + ")"))
                    {
                        patient = this.tvNursePatientList1.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
                        this.Text = "您正在操作的患者为 住院号：" + patient.ID + "姓名：" + patient.Name + "性别：" + patient.Sex.Name + " 床号:" + patient.PVisit.PatientLocation.Bed.ID;
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
                        Neusoft.HISFC.Models.RADT.PatientInfo patient1 = this.tvNursePatientList1.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
                        this.Text = "您正在操作的患者为 住院号：" + patient1.ID + "姓名：" + patient1.Name + " 性别：" + patient1.Sex.Name + " 床号:"+ patient1.PVisit.PatientLocation.Bed.ID;
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
                this.tvNursePatientList1.Refresh();
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
                Neusoft.HISFC.Models.RADT.PatientInfo pi = (Neusoft.HISFC.Models.RADT.PatientInfo)this.tvNursePatientList1.SelectedNode.Tag;
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

                    this.ucOrder1.Query(this.tvNursePatientList1.SelectedNode, this.tvNursePatientList1.SelectedNode.Tag);
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
                    this.initButtonGroup(false);

                }
                else
                {
                    if (this.ucOrder1.ExitOrder() == 0)
                        this.initButton(false);
                    tvNursePatientList1.Refresh();
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
                        tvNursePatientList1.Refresh();
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
            for (int i = 0; i < this.ucOrder1.fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.ucOrder1.fpSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = this.ucOrder1.GetObjectFromFarPoint(i, this.ucOrder1.fpSpread1.ActiveSheetIndex).Clone();
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
                }
            }
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
    }
}