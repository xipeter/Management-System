using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucPermissionInput : UserControl
    {
        protected Neusoft.HISFC.Models.Order.Consultation permission = new Neusoft.HISFC.Models.Order.Consultation();
        private Neusoft.HISFC.BizLogic.Order.Permission manager = new Neusoft.HISFC.BizLogic.Order.Permission();
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtMgr = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        public ucPermissionInput()
        {
            InitializeComponent(); try
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager managerDept = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                this.cmbDept.AddItems(managerDept.QueryDeptmentsInHos(true));
            }
            catch 
            { 
            }
        }

        /// <summary>
        /// 权限
        /// </summary>
        public Neusoft.HISFC.Models.Order.Consultation Permission
        {
            get
            {
                return this.permission;
            }
            set
            {
                this.permission = value;
                this.SetValue();
            }
        }

        private void SetValue()
        {
            if (this.permission == null) return;
            try
            {
                this.cmbDept.Tag = this.permission.DeptConsultation.ID;
                this.cmbDoctor.Tag = this.permission.DoctorConsultation.ID;
                this.dtBegin.Value = this.permission.BeginTime;
                this.dtEnd.Value = this.permission.EndTime;
                this.txtMemo.Text = this.permission.Name;
            }
            catch { }
        }
        private int GetValue()
        {
            if (this.cmbDept.Tag == null || this.cmbDept.Text == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请输入授权科室"));
                return -1;
            }
            if (this.cmbDoctor.Tag == null || this.cmbDoctor.Text == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请输入授权医生"));
                return -1;
            }
            System.Collections.ArrayList list = this.manager.QueryPermission(this.permission.InpatientNo);
            if (list == null)
            {
                MessageBox.Show("获取授权信息失败" + this.manager.Err);
                return -1;
            }
            Neusoft.HISFC.Models.RADT.PatientInfo patientObj = radtMgr.GetPatientInfomation(this.permission.InpatientNo);
            if (patientObj == null)
            {
                MessageBox.Show("获取病人信息失败" + this.radtMgr.Err);
                return -1;
            }
            if (cmbDoctor.Tag.ToString() == patientObj.PVisit.AdmittingDoctor.ID)
            {
                MessageBox.Show(cmbDoctor.Text + " 是分管医生 ，不需要再分配");
                return -1;
            }
            if (list.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Order.Consultation tem in list)
                {
                    if (tem.DoctorConsultation.ID == cmbDoctor.Tag.ToString() && tem.ID != permission.ID)
                    {
                        if (MessageBox.Show(cmbDoctor.Text + " 在" + tem.BeginTime.ToString() + " - " + tem.EndTime.ToString() + "期间已经有权限" + ",需要重新分配","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                        {
                            return -1;
                        }
                    }
                }
            }

            if (this.permission == null) this.permission = new Neusoft.HISFC.Models.Order.Consultation();
            this.permission.DeptConsultation.ID = this.cmbDept.Tag.ToString();
            this.permission.DoctorConsultation.ID = this.cmbDoctor.Tag.ToString();
            this.permission.DoctorConsultation.Name = this.cmbDoctor.Text;
            this.permission.BeginTime = this.dtBegin.Value;
            this.permission.EndTime = DateTime.Parse(this.dtEnd.Value.ToShortDateString() + " 23:59:59");
            if (this.permission.BeginTime > this.permission.EndTime)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("处方授权开始时间不能大于结束时间"));
                return -1;
            }
            string memo = this.txtMemo.Text.Trim();
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(memo, 20) == false)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("授权说明不能超过10个汉字!"));
                return -1;
            }
            this.permission.Name = memo;
            
            return 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            if (this.GetValue() == -1) return -1;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
            //t.BeginTransaction();
            manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            if (this.permission.ID == "")
            {
                if (manager.InsertPermission(this.permission) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(manager.Err));
                    return -1;
                }
            }
            else
            {
                if (manager.UpdatePermission(this.permission) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(manager.Err));
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));
            return 0;
        }

        /// <summary>
        /// 验证时间
        /// </summary>
        /// <returns></returns>
        private bool valid()
        {
            TimeSpan s = new TimeSpan(dtEnd.Value.Ticks - dtBegin.Value.Ticks);
            if (s.Ticks < 0)
            {
                MessageBox.Show("开始时间小于最后时间!");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.valid())
            {
                return;
            }
            if (this.Save() == 0)
            {
                this.FindForm().Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                Neusoft.HISFC.BizProcess.Integrate.Manager personManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                this.cmbDoctor.alItems = null;
                this.cmbDoctor.Text = "";
                this.cmbDoctor.Tag = "";
                this.cmbDoctor.AddItems(personManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, this.cmbDept.Tag.ToString()));
            }
            catch { MessageBox.Show(this.cmbDept.Text + "没有医生！"); }
        }

        private void ucPermissionInput_Load(object sender, EventArgs e)
        {
            this.cmbDoctor.IsListOnly = true;
            this.cmbDept.IsListOnly = true;
        }

    }
}
