using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.WinForms.Forms;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
    /// <summary>
    /// [功能描述: 医技预约设备维护]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-08-20]<br></br> 
    /// </summary>
    /// </summary>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucTerminalCarrier : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucTerminalCarrier()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。


            InitializeComponent();
            this.Load += new EventHandler(ucTerminalCarrier_Load);
            this.ChooseDateEvent += new ChooseDateHandler(ucTerminalCarrier_ChooseDateEvent);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread_CellDoubleClick);

        }

        #region 初始化按钮


        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "新增", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("修改", "修改", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarService.AddToolButton("删除", "删除", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.Add();
                    break;
                case "修改":
                    this.Modify();
                    break;
                case "删除":
                    this.Delete();
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        #region 初始化


        /// <summary>
        /// Load加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucTerminalCarrier_Load(object sender, EventArgs e)
        {
            this.Init();

            this.tvTerminalCarTree = this.tv as HISFC.Components.Terminal.Confirm.tvTerminalCarTree;

            this.ShowList();
        }

        /// <summary>
        /// 数据初始化 
        /// </summary>
        private void Init()
        {
            #region 科室信息加载

            Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alDept = deptManager.GetDeptmentAllValid();
            if (alDept == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("获取所有科室列表发生错误" + deptManager.Err);
                return;
            }

            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            //当前操作科室
            this.operDeptCode = ((Neusoft.HISFC.Models.Base.Employee)this.terminalManager.Operator).Dept.ID;

            #endregion
        }

        /// <summary>
        /// 列表刷新
        /// </summary>
        protected void ShowList()
        {
            this.tvTerminalCarTree.ShowDeptAll(operDeptCode);
        }
        #endregion

        #region 属性
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        private Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal = new Neusoft.HISFC.Models.Terminal.TerminalCarrier();

        public delegate void ChooseDateHandler(FarPoint.Win.Spread.SheetView sv, int activeRow);

        public event ChooseDateHandler ChooseDateEvent;

        /// <summary>
        /// 医技设备管理类

        /// </summary>
        private Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier terminalManager = new Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier();

        /// <summary>
        /// 科室帮助类 
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 操作类型 Update/Insert/Check
        /// </summary>
        private string inputType = "Update";

        /// <summary>
        /// 医技设备维护控件
        /// </summary>
        private ucAddTerminalCarrier MainteranceUC = null;

        /// <summary>
        /// 医技维护窗口
        /// </summary>
        private System.Windows.Forms.Form MainteranceForm = null;

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private string operDeptCode = "";

        /// <summary>
        /// 声明树

        /// </summary>
        private Terminal.Confirm.tvTerminalCarTree tvTerminalCarTree = new tvTerminalCarTree();

        #endregion

        #region 方法

        /// <summary>
        /// 医技维护弹出窗口 
        /// </summary>
        public HISFC.Components.Terminal.Confirm.ucAddTerminalCarrier MaintenancePopUC
        {
            set
            {
                if (value != null && value as HISFC.Components.Terminal.Confirm.ucAddTerminalCarrier == null)
                {
                    System.Windows.Forms.MessageBox.Show("该维护控件需继承自HISFC.Components.Terminal.Confirm.ucAddTerminalCarrier");
                }
                else
                {
                    this.MainteranceUC = value as HISFC.Components.Terminal.Confirm.ucAddTerminalCarrier;

                }
            }
        }

        private void InitMaintenanceForm()
        {
            if (this.MainteranceUC == null)
            {
                this.MainteranceUC = new ucAddTerminalCarrier();
            }
            if (this.MainteranceForm == null)
            {
                this.MainteranceForm = new Form();
                this.MainteranceForm.Width = this.MainteranceUC.Width + 10;
                this.MainteranceForm.Height = this.MainteranceUC.Height + 25;
                this.MainteranceForm.Text = "医技设备详细信息维护";
                this.MainteranceForm.ShowInTaskbar = false;
                this.MainteranceForm.StartPosition = FormStartPosition.CenterScreen;
                this.MainteranceForm.HelpButton = false;
                this.MainteranceForm.MaximizeBox = false;
                this.MainteranceForm.MinimizeBox = false;
                this.MainteranceForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            }

            this.MainteranceUC.Dock = DockStyle.Fill;
            this.MainteranceForm.Controls.Add(this.MainteranceUC);
        }

        private void ShowMaintenanceForm(string inputType, Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal)
        {
            if (this.MainteranceUC == null || this.MainteranceForm == null)
                this.InitMaintenanceForm();

            this.MainteranceUC.InputType = inputType;
            this.MainteranceUC.Terminal = terminal;

            this.MainteranceForm.ShowDialog();

            this.QueryDesign(this.dept.ID);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        public void Add()
        {
            this.ShowMaintenanceForm("Insert", null);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns>成功删除返回1 失败返回-1 无操作返回0</returns>
        public int Delete()
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
            {
                return 0;
            }

            string designNo = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 1].Text;

            #region 删除判断  确认

            System.Windows.Forms.DialogResult dr;
            dr = MessageBox.Show("您是否要删除这条医疗设备?", "提示!", System.Windows.Forms.MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                return 0;
            }
            #endregion

            #region 数据库删除操作

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.terminalManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.terminalManager.DelTerminalCarrier(designNo) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("执行医技设备删除操作失败" + this.terminalManager.Err);
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("删除成功！");

            #endregion

            return 1;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        public void Modify()
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
                return;
            this.terminal = this.terminalManager.GetItem(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 1].Text, dept.ID);

            this.ShowMaintenanceForm("Update", this.terminal);
        }

        /// <summary>
        /// 检索数据

        /// </summary>
        public int QueryDesign(string deptId)
        {
            this.Clear();

            ArrayList al = terminalManager.GetDesigns(deptId);
            if (al == null)
            {
                MessageBox.Show(this.terminalManager.Err);
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal in al)
            {
                this.SetTerminal(terminal);
            }

            return 1;
        }

        private void Clear()
        {
            this.fpSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 设置医技设备数据显示 
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private int SetTerminal(Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal)
        {
            int rowCount = this.fpSpread1_Sheet1.Rows.Count;

            this.fpSpread1_Sheet1.Rows.Add(rowCount, 1);

            this.fpSpread1_Sheet1.Cells[rowCount, 0].Text = terminal.Dept.ID;
            this.fpSpread1_Sheet1.Cells[rowCount, 1].Text = terminal.CarrierCode;
            this.fpSpread1_Sheet1.Cells[rowCount, 2].Text = terminal.CarrierName;
            this.fpSpread1_Sheet1.Cells[rowCount, 3].Text = terminal.CarrierType;
            this.fpSpread1_Sheet1.Cells[rowCount, 4].Text = terminal.CarrierMemo;
            this.fpSpread1_Sheet1.Cells[rowCount, 5].Text = terminal.SpellCode;
            this.fpSpread1_Sheet1.Cells[rowCount, 6].Text = terminal.WBCode;
            this.fpSpread1_Sheet1.Cells[rowCount, 7].Text = terminal.UserCode;
            this.fpSpread1_Sheet1.Cells[rowCount, 8].Text = terminal.Model;
            if (terminal.IsDisengaged == "1")
                this.fpSpread1_Sheet1.Cells[rowCount, 9].Text = "是";
            else
                this.fpSpread1_Sheet1.Cells[rowCount, 9].Text = "否";
            this.fpSpread1_Sheet1.Cells[rowCount, 10].Text = terminal.DisengagedTime.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 11].Text = terminal.DayQuota.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 12].Text = terminal.DoctorQuota.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 13].Text = terminal.SelfQuota.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 14].Text = terminal.WebQuota.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 15].Text = terminal.Building;
            this.fpSpread1_Sheet1.Cells[rowCount, 16].Text = terminal.Floor;
            this.fpSpread1_Sheet1.Cells[rowCount, 17].Text = terminal.Room;
            this.fpSpread1_Sheet1.Cells[rowCount, 18].Text = terminal.SortId.ToString();
            if (terminal.IsPrestopTime == "1")
                this.fpSpread1_Sheet1.Cells[rowCount, 19].Text = "是";
            else
                this.fpSpread1_Sheet1.Cells[rowCount, 19].Text = "否";
            this.fpSpread1_Sheet1.Cells[rowCount, 20].Text = terminal.PreStopTime.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 21].Text = terminal.PreStartTime.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 22].Text = terminal.AvgTurnoverTime.ToString();
            this.fpSpread1_Sheet1.Cells[rowCount, 23].Text = terminal.CreateOper;
            this.fpSpread1_Sheet1.Cells[rowCount, 24].Text = terminal.CreateTime.ToString();
            if (terminal.IsValid == "1")
                this.fpSpread1_Sheet1.Cells[rowCount, 25].Value = true;
            else
                this.fpSpread1_Sheet1.Cells[rowCount, 25].Value = false;
            this.fpSpread1_Sheet1.Cells[rowCount, 26].Text = terminal.DeviceType;

            this.fpSpread1_Sheet1.Rows[rowCount].Tag = terminal;

            return 1;

        }

        #endregion

        #region 事件

        /// <summary>
        /// 单击树事件，查询点击的科室
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            //Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

            //if (obj == null) return -1;

            //dept = e.Tag as Neusoft.HISFC.Models.Base.Department;

            //QueryDesign(dept.ID);

            return base.OnSetValue(neuObject, e);
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.dept = ((Neusoft.HISFC.Models.Base.Employee)this.terminalManager.Operator).Dept;

                this.QueryDesign(this.dept.ID);
            }
            catch { }

            base.OnLoad(e);
        }


        private void ucTerminalCarrier_ChooseDateEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            this.Modify();
        }

        private void fpSpread_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.ChooseDateEvent != null)
            {

                this.ChooseDateEvent(this.fpSpread1_Sheet1, e.Row);
            }
        }

        #endregion

    }
}
