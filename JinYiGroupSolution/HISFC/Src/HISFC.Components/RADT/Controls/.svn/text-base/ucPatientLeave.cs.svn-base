using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 请假管理组件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPatientLeave : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientLeave()
        {
            InitializeComponent();
        }

        private void ucPatientLeave_Load(object sender, EventArgs e)
        {

        }

        #region 变量

        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.Order orderManager = new Neusoft.HISFC.BizProcess.Integrate.Order();
        Neusoft.HISFC.BizLogic.RADT.InPatient inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.HISFC.Models.RADT.Leave myLeave = null;
        Neusoft.FrameWork.Models.NeuObject dept = null;
        protected bool IsLeave = false;
        #endregion
        /// <summary>

        /// 初始化控件
		/// </summary>
		private  void InitControl() {
			dept  = this.patientInfo.PVisit.PatientLocation.Dept.Clone();
			try {
				//初始化医生列表
				this.cmbDoc.AddItems(manager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D,dept.ID ));
				this.cmbDoc.IsListOnly = true;
				
				//清空显示控件中的内容
				ClearInfo();
			}
			catch{}
			
		}
		

		/// <summary>
		/// 初始化树型列表
		/// </summary>
		private void InitTree() {
			//清空变量
			this.IsLeave = false;
			this.treeView1.Nodes.Clear();
			this.treeView1.BeginUpdate();
			System.Windows.Forms.TreeNode Node=new System.Windows.Forms.TreeNode();
			Node.Text ="请假管理";
			Node.Tag = "";
			this.treeView1.Nodes.Add(Node);

			//取患者请假信息
			ArrayList al=new ArrayList();
			al=this.inpatient.GetPatientLeaveAvailable(this.patientInfo.ID);
			if (al == null) {
                MessageBox.Show(this.inpatient.Err);
				return;
			}

			//添加患者请假信息
			foreach(Neusoft.HISFC.Models.RADT.Leave leave in al) {	
				this.AddTreeNode(leave);
			}
			this.treeView1.ExpandAll();
			this.treeView1.SelectedNode = this.treeView1.Nodes[0];
			this.treeView1.EndUpdate();

		}


		/// <summary>
		/// 增加树型节点
		/// </summary>
		/// <param name="leave"></param>
		private void AddTreeNode(Neusoft.HISFC.Models.RADT.Leave leave) {
			System.Windows.Forms.TreeNode Node=new System.Windows.Forms.TreeNode();
			try {
				Node.Text = leave.LeaveTime.ToString();
				Node.Tag  = leave;
				//根据请假状态的不同,显示不同的图片
				if(leave.LeaveFlag == "0") {
					//存在请假记录
					Node.ImageIndex = 1;
					//标识患者存在有效的请假记录
					this.IsLeave = true;
				}
				else {
					//存在消假记录
					Node.ImageIndex = 2;
				}

				Node.SelectedImageIndex = Node.ImageIndex;
				
				this.treeView1.Nodes[0].Nodes.Add(Node);
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,"错误提示");
			}
		}


		/// <summary>
		/// 设置患者请假信息到控件
		/// </summary>
		/// <param name="leave"></param>
		private void ShowLeaveInfo(Neusoft.HISFC.Models.RADT.Leave leave) {
			//如果没有患者信息,则清屏
			if(this.myLeave == null) {
				this.ClearInfo();
				return;
			}

			//给假医生
			this.cmbDoc.Tag  =leave.DoctCode;
			if(leave.DoctCode == "") 
				this.cmbDoc.Text = null;
			//请假天数
			this.txtDays.Text= leave.LeaveDays.ToString();
			//登记人姓名
			this.txtRegisterPerson.Text = manager.GetEmployeeInfo(leave.Oper.ID).Name;
			//消假人姓名
			try {
                if(leave.CancelOper.ID !="")
				    this.txtCancelPerson.Text= manager.GetEmployeeInfo(leave.CancelOper.ID).Name;
			}
			catch {
				this.txtCancelPerson.Text = "";
			}
			//备注
			this.txtRemark.Text = leave.Memo;
			//请假日期
			this.dtpRegisterDate.Text = leave.LeaveTime.ToString();
            try
            {
			    //取消日期
			    if(this.myLeave.LeaveFlag != "0") 
                    this.dtpCancelDate.Text = leave.CancelOper.OperTime.ToString();
			    else
                    this.dtpCancelDate.Text = this.inpatient.GetDateTimeFromSysDateTime().ToString();
            }catch{}
			//显示请假记录
			if(leave.LeaveFlag == "0") {
				
				this.btnCancel.Enabled = true;
				this.btnSave.Enabled   = true;
			}
			else {
				//取消的请假记录显示消假信息
			
				this.btnCancel.Enabled = false;
				this.btnSave.Enabled   = false;
			}
		
		}


		/// <summary>
		/// 获取患者请假信息
		/// </summary>
		private bool GetLeaveInfo() {
			bool isNew = true;
			if(this.myLeave == null)
			{
				this.myLeave = new Neusoft.HISFC.Models.RADT.Leave();
				isNew = true;
			}
			else
			{
				isNew = false;
			}

			//如果是新增请假信息,则取本次请假信息
			if(this.myLeave.ID == "") {
				this.myLeave.ID = this.patientInfo.ID;
				this.myLeave.LeaveTime =this.dtpRegisterDate.Value;
			}
            
			//请假天数
			this.myLeave.LeaveDays = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtDays.Text);
			//给假医生
			this.myLeave.DoctCode = this.cmbDoc.Tag.ToString();
			//备注
			this.myLeave.Memo = this.txtRemark.Text;
			return isNew;
		}


		/// <summary>
		/// 清屏
		/// </summary>
		private void ClearInfo() {
			//请假列表选中根节点
			this.treeView1.SelectedNode = this.treeView1.Nodes[0];
			this.txtName.Tag  = this.patientInfo.ID;
            this.txtName.Text = this.patientInfo.Name;
            this.txtBed.Text = this.patientInfo.PVisit.PatientLocation.Bed.ID;
			this.dtpRegisterDate.Value = this.inpatient.GetDateTimeFromSysDateTime();
			this.dtpCancelDate.Value =this.dtpRegisterDate.Value;
			this.cmbDoc.Tag  ="";
			this.cmbDoc.Text = null;
			this.txtDays.Text="";
			this.txtCancelPerson.Text = "";
			this.txtRegisterPerson.Text="";
			this.txtRemark.Text = "";
			//按钮可用
			this.btnCancel.Enabled = true;
			this.btnSave.Enabled   = true;
		}


		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="inPatientNo"></param>
		public void RefreshList(string inPatientNo) {
			//初始化控件
			InitControl();

			//初始化树
			InitTree();
		}


		/// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public int Save() {
			//如果患者存在有效的请假记录,则不能新增请假信息
			if(this.IsLeave && this.myLeave == null) {
				MessageBox.Show("此患者已经存在一有效的请假信息,不能同时登记两次有效的请假. \n请先对已存在的请假信息进行消假处理.","提示");
				this.txtDays.Focus();
				return -1;
			}

			//婴儿不允许请假
			if(this.patientInfo.IsBaby ) {
				MessageBox.Show("婴儿不可以请假.","提示");
				return -1;
			}

			//取患者主表中最新的信息,用来判断并发
            this.patientInfo = this.inpatient.QueryPatientInfoByInpatientNO(this.patientInfo.ID);
			if(this.patientInfo == null) {
				MessageBox.Show(this.inpatient.Err);
				return -1;
			}

            //判断是否欠费

            if (this.patientInfo.FT.LeftCost < this.patientInfo.PVisit.MoneyAlert)
            {
                if(MessageBox.Show("该患者已经欠费，是否允许请假", "注意", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return -1;
                }
            }

			//必须录入天数
			if (this.txtDays.Text == "") {
				MessageBox.Show("必须填写请假天数","提示");
				this.txtDays.Focus();
				return -1;
			}

			//天数不能为0
			if (Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtDays.Text) == 0) {
				MessageBox.Show("请录入有效的请假天数","提示");
				this.txtDays.Focus();
				return -1;
			}

			//取患者请假信息
			bool b =this.GetLeaveInfo();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA=new Neusoft.FrameWork.Management.Transaction(this.inpatient.Connection);
            //SQLCA.BeginTransaction();

            this.inpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

			//保存请假信息
            int parm = this.inpatient.SetPatientLeave(this.myLeave, this.patientInfo.PVisit.PatientLocation.Bed);
			if (parm == -1) {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show(this.inpatient.Err);
				return -1;
			}
			else if(parm == 0){
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show("患者信息已发生变动,请刷新当前窗口","提示");
				return 0;
			}

			if(b)//新请假的
			{
				//请假时,停止医嘱执行
				//请假，更新请假后1000天
                if (orderManager.UpdateDecoTime(this.patientInfo.ID, 1000) == -1) 
				{
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					MessageBox.Show(this.orderManager.Err);
					return 0;
				}
			}
            Neusoft.FrameWork.Management.PublicTrans.Commit();
			this.RefreshList(this.patientInfo.ID);
			MessageBox.Show("登记成功!","提示");

			return 1;
		}


		/// <summary>
		/// 消假处理
		/// </summary>
		public void Cancel() 
        {
			//取患者主表中最新的信息,用来判断并发
            this.patientInfo = this.inpatient.QueryPatientInfoByInpatientNO(this.patientInfo.ID);
			if(this.patientInfo == null) {
				MessageBox.Show(this.inpatient.Err);
				return;
			}		

			if(this.myLeave == null) {
				MessageBox.Show("请选择要消假的记录","提示");
				return;
			}

			//取患者请假信息
			this.GetLeaveInfo();
			this.myLeave.LeaveFlag = "1";

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA=new Neusoft.FrameWork.Management.Transaction(this.inpatient.Connection);
            //SQLCA.BeginTransaction();

            this.inpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

			int parm = this.inpatient.DiscardPatientLeave(this.myLeave, this.patientInfo.PVisit.PatientLocation.Bed);
			if (parm == -1) {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show(this.inpatient.Err);
			}
			else if(parm == 0){
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show("患者信息已发生变动,请刷新当前窗口","提示");
				return;
			}

			//消假时,--%%%%将医嘱下次执行时间改为此刻系统时间
			//先更新回去，再更新到当前时间（如果当前时间>下次分解时间才更新)
            DateTime dtToday = this.inpatient.GetDateTimeFromSysDateTime();
		
			if(this.orderManager.UpdateDecoTime(this.patientInfo.ID,-1000) == -1) 
			{
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show(this.orderManager.Err);
				return;
			}
			//更新成当前日期；
			if(this.orderManager.UpdateDecoTime(this.patientInfo.ID,dtToday) == -1) 
			{
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show(this.orderManager.Err);
				return;
			}

            Neusoft.FrameWork.Management.PublicTrans.Commit();
			this.RefreshList(this.patientInfo.ID);
			MessageBox.Show("消假成功!","提示");
		}


		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			//获取当前选中请假信息
			this.myLeave = e.Node.Tag as Neusoft.HISFC.Models.RADT.Leave ;

			//将选中的请假信息显示在控件中
			this.ShowLeaveInfo(this.myLeave);
		}


		private void btAdd_Click(object sender, System.EventArgs e) {
			this.ClearInfo();
		}

		private void btCancel_Click(object sender, System.EventArgs e) {
			//消假处理
			this.Cancel();		
		}

		private void btSave_Click(object sender, System.EventArgs e) {	
			if(this.Save() == 1) {
                    //Report.ucPrintTempOutHosDrug u = new RADT.Report.ucPrintTempOutHosDrug();
                    //u.InpatientNo = this.PatientInfo.ID;
                    //u.PrintPreview();
				
			}
		}

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.patientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            if (this.patientInfo.ID != null || this.patientInfo.ID != "")
            {
                try
                {
                    RefreshList(patientInfo.ID);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
               
            }
            return 0;
        }
	
    }
}
