using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Operation
{
    public partial class frmChangeOpsRoom :Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
       //路志鹏　时间：２００７-４-１６
       //目的：完成在手术安排中变换执行科室

        #region 业务实体
        /// <summary>
        /// 手术申请单对象实例
        /// </summary>
        //public neusoft.HISFC.Object.Operator.OpsApplication m_objOpsApp = new neusoft.HISFC.Object.Operator.OpsApplication();
        public Neusoft.HISFC.Models.Operation.OperationAppllication m_objOpsApp = new Neusoft.HISFC.Models.Operation.OperationAppllication();
        /// <summary>
        /// 手术申请控制类实例
        /// </summary>
        //private neusoft.HISFC.Management.Operator.Operator m_objOpsManager = new neusoft.HISFC.Management.Operator.Operator();
        private Neusoft.HISFC.BizProcess.Integrate.Operation.Operation m_objOpsManager = new Neusoft.HISFC.BizProcess.Integrate.Operation.Operation();

        private Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();


        //neusoft.HISFC.Management.Manager.Constant l_objC = new neusoft.HISFC.Management.Manager.Constant();
        #endregion

        #region 变量
        /// <summary>
        /// 更换后的手术室ID
        /// </summary>
        public string strNewOpsRoomID = "";
        #endregion

        #region 初始化

        public frmChangeOpsRoom(Neusoft.HISFC.Models.Operation.OperationAppllication apply)
        {
            InitializeComponent();
            m_objOpsApp = apply;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitWin()
        {
            if (this.m_objOpsApp == null) return;
            //姓名
            this.txtName.Text = this.m_objOpsApp.PatientInfo.Name;
            //科室
            this.txtDept.Text = deptManager.GetDepartment(m_objOpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID.ToString()).Name;
            //住院号/门诊号
            this.txtPatientNo.Text = m_objOpsApp.PatientInfo.PID.ID.ToString();
            //原手术室
            if (m_objOpsApp.OperateRoom != null)
            {
                this.txtOldOpsRoom.Tag = m_objOpsApp.OperateRoom.ID.ToString();
                this.txtOldOpsRoom.Text = m_objOpsApp.OperateRoom.Name;
                strNewOpsRoomID = m_objOpsApp.OperateRoom.ID.ToString();
            }
            else
            {
                
                this.txtOldOpsRoom.Text=Environment.GetDept(m_objOpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID).Name;
                //this.txtOldOpsRoom.Text = dept.GetDeptmentById(this.var.User.Dept.ID.ToString()).Name;
                //this.txtOldOpsRoom.Tag = this.var.User.Dept.ID.ToString();
                this.txtOldOpsRoom.Tag = m_objOpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID;
            }
            //手术预约时间
            if (m_objOpsApp.PreDate != DateTime.MinValue)
                this.dtpPreDate.Value = m_objOpsApp.PreDate;
            else
                this.dtpPreDate.Value = this.m_objOpsManager.GetDateTimeFromSysDateTime();
            //手术室combox列表
            this.cmbOpsRoom.Items.Clear();
            ArrayList OpsRoomAl = new ArrayList();
            OpsRoomAl = deptManager.GetDeptmentByType("1");//"1"表示手术类型的科室
            this.cmbOpsRoom.AddItems(OpsRoomAl);
            //缺省选中原手术室
            this.cmbOpsRoom.Tag = this.m_objOpsApp.OperateRoom.ID.ToString();
            //手术台类型combox列表
            ArrayList alTableType = new ArrayList();
            //neusoft.neNeusoft.HISFC.Components.Object.neuObject obj = new neusoft.neNeusoft.HISFC.Components.Object.neuObject();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "1";
            obj.Name = "正台";
            alTableType.Add(obj.Clone());
            obj.ID = "2";
            obj.Name = "加台";
            alTableType.Add(obj.Clone());
            obj.ID = "3";
            obj.Name = "点台";
            alTableType.Add(obj.Clone());
            this.cmbTableType.AddItems((ArrayList)(alTableType.Clone()));
            //缺省选中“正台”
            cmbTableType.SelectedIndex = 0;
        }
        #endregion

        #region 方法
        //手术预约时间
        /// <summary>
        /// 预约时间时效性判断
        /// </summary>
        /// <returns> 0 有效 -1 无效</returns>
        public int PreDateValidity()
        {
            //时效判断
            //Error:系统值未维护或格式非法，Before:预约时间小于现在，Over:不能申请该日的正台，OK:可以申请
            string strResult = "";
            strResult = this.m_objOpsManager.PreDateValidity(this.dtpPreDate.Value);
            switch (strResult)
            {
                case "Error":
                    MessageBox.Show("系统手术申请截至时间参数为空或格式非法，请联系系统管理员！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                case "Before":
                    MessageBox.Show("手术预约时间不能小于当前时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                case "Over":
                    //如果选中的是正台
                    if (this.cmbTableType.SelectedIndex == 0)
                    {
                        DialogResult result;
                        result = MessageBox.Show("已超过该日手术正台申请的截至时间，\n请预约至其他日期进行手术或申请加台手术。\n是否需要申请加台？", "提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)//申请加台
                        {
                            this.cmbTableType.Tag = "2";
                            //this.rdbZT.Enabled = false;//该情况下不能再申请正台
                            this.m_objOpsApp.PreDate = this.dtpPreDate.Value;
                            return 0;
                        }
                        else
                        {
                            this.dtpPreDate.Focus();
                            return -1;
                        }
                    }
                    return 0;
                case "OK":
                    this.m_objOpsApp.PreDate = this.dtpPreDate.Value;
                    return 0;
            }
            return 0;
        }

        //剩余正台数
        /// <summary>
        /// 设置剩余正台数的显示
        /// </summary>
        /// <return>0 success -1 fail -2手术室为空</return>
        public int ShowTableNum()
        {
            DateTime dtPreDate = this.dtpPreDate.Value;
            //获取选中的转往手术室
            Neusoft.HISFC.Models.Base.Department OpsRoom = deptManager.GetDepartment(this.cmbOpsRoom.Tag.ToString());
            
            //获取剩余可申请正台数
            int iEnableNum = 0;
            if (OpsRoom == null || OpsRoom.ID.ToString() == "") return -2;
            try
            {
                //申请医生所属科室
                //neusoft.neNeusoft.HISFC.Components.Object.neuObject Dept = new neusoft.neNeusoft.HISFC.Components.Object.neuObject();
                Neusoft.FrameWork.Models.NeuObject Dept = new Neusoft.FrameWork.Models.NeuObject();
                //if (this.m_objOpsApp.Apply_Doct.Dept == null)
                if(this.m_objOpsApp.ApplyDoctor.Dept==null)
                    Dept = this.m_objOpsApp.PatientInfo.PVisit.PatientLocation.Dept;
                else
                    Dept = this.m_objOpsApp.ApplyDoctor.Dept;// Apply_Doct.Dept;
                //正台数
                iEnableNum = this.m_objOpsManager.GetEnableTableNum(OpsRoom, Dept.ID.ToString(), dtPreDate);
            }
            catch (Exception ex)
            {
                this.m_objOpsManager.Err = "Operator.frmChangeOpsRoom.ShowTableNum 获取正台数时出错";
                this.m_objOpsManager.ErrCode = ex.Message;
                this.m_objOpsManager.WriteErr();
                return -1;
            }

            if (iEnableNum <= 0 && this.cmbTableType.SelectedIndex == 0)
            {
                DialogResult result;
                result = MessageBox.Show("临床科室于该预约日期在所选手术室已无正台配额，\n请预约至其他日期或其他手术室进行手术\n或在所选手术室申请加台手术。\n是否需要申请加台？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)//申请加台
                {
                    this.cmbTableType.SelectedIndex = 1;//加台
                    this.txtTableNum.Text = "0";
                    return 0;
                }
                else
                    return -1;
            }
            this.txtTableNum.Text = iEnableNum.ToString();
            return 0;
        }
        #endregion

        #region 事件
        private void cmbOpsRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ShowTableNum() == -1) return;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //如果手术室未做改变
                if (this.txtOldOpsRoom.Tag.ToString() == this.cmbOpsRoom.Tag.ToString())
                {
                    DialogResult result = MessageBox.Show("您并没有更换手术室信息，是否确认关闭本窗口？", "提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.btnCancel_Click(sender, e);
                    }
                    else
                    {
                        this.cmbOpsRoom.Focus();
                    }
                    return;
                }
                //先做有效性判断
                if (this.PreDateValidity() == -1 || this.ShowTableNum() == -1) return;
                //判断通过后，将录入的值赋给m_objOpsApp相关成员
                //手术时间
                this.m_objOpsApp.PreDate = this.dtpPreDate.Value;
                //手术室
                this.m_objOpsApp.OperateRoom.ID = this.cmbOpsRoom.Tag.ToString();
                this.m_objOpsApp.OperateRoom.Name = this.cmbOpsRoom.Text;
                strNewOpsRoomID = this.cmbOpsRoom.Tag.ToString();
                //手术台类型
                this.m_objOpsApp.TableType = this.cmbTableType.Tag.ToString();
                //将修改的结果保存到数据库中
                //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.var.con);

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.m_objOpsManager.Connection);
                //trans.BeginTransaction();

                this.m_objOpsManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //调用业务层手术室更换函数
                if (this.m_objOpsManager.ChangeOperatorRoom(this.m_objOpsApp) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存手术室更换信息时出错！\n请与系统管理员联系。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("手术室更换成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region 焦点切换
        private void dtpPreDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.cmbOpsRoom.Focus();
        }

        private void cmbOpsRoom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ShowTableNum() == 0)
                    this.cmbTableType.Focus();
            }
        }

        private void cmbTableType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnOK.Focus();
        }
        #endregion
    }
}