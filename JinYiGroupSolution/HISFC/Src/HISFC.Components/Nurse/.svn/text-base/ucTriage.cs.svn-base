using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse
{
    internal partial class ucTriage : UserControl
    {
        private ucTriage()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.BizLogic.Nurse.Queue queueMgr = new Neusoft.HISFC.BizLogic.Nurse.Queue();
        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registrationIntergrade = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        Neusoft.HISFC.Models.Registration.RegLevel regLevel = new Neusoft.HISFC.Models.Registration.RegLevel();
        ArrayList queues;
        public ucTriage(string nurseID)
		{
			InitializeComponent();

            //Neusoft.HISFC.BizLogic.Nurse.Queue queueMgr = new Neusoft.HISFC.BizLogic.Nurse.Queue();
            Neusoft.HISFC.BizLogic.Nurse.Dept deptMgr = new Neusoft.HISFC.BizLogic.Nurse.Dept();
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration schemaMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

			DateTime current = deptMgr.GetDateTimeFromSysDateTime();

			string noonID = Nurse.Function.GetNoon(current);

            //ArrayList queues = queueMgr.Query(nurseID,current.Date,noonID);
            queues = queueMgr.Query(nurseID, current.Date, noonID);
            if (queues == null) queues = new ArrayList();


            ArrayList depts = deptMgr.GetDeptInfoByNurseNo(nurseID);
            this.cmbQueue.AddItems(queues);
            #region {4600A33C-8065-4b2c-93D2-9B26B24F61CF}
            if (this.cmbQueue.Items.Count > 0)
            {

                this.cmbQueue.SelectedIndex = 0;
                // return;
            } 
            #endregion
            //this.cmbQueue.isItemOnly = true;
            this.txtCard.ReadOnly = true;
            this.txtCard.BackColor = Color.White;
            this.txtName.ReadOnly = true;
            this.txtName.BackColor = Color.White;
            this.txtRegDate.ReadOnly = true;
            this.txtRegDate.BackColor = Color.White;
            this.txtDept.ReadOnly = true;
            this.txtDept.BackColor = Color.White;

        }

        //private void SelectItem(Neusoft.HISFC.Models.Nurse.Queue queue, Neusoft.HISFC.Models.Registration.Register register)
        private void SelectItem(Neusoft.HISFC.Models.Registration.Register register)
        {
           
            for (int i = 0; i < this.queues.Count; i++)
            {
              
                //ArrayList al = new ArrayList();
                Neusoft.HISFC.Models.Nurse.Queue queue = new Neusoft.HISFC.Models.Nurse.Queue();
                queue = queues[i] as Neusoft.HISFC.Models.Nurse.Queue;

                //判断是不是专家号

                this.regLevel = this.registrationIntergrade.QueryRegLevelByCode(register.DoctorInfo.Templet.RegLevel.ID);
                register.RegLvlFee.RegLevel.IsExpert = this.regLevel.IsExpert;
               //全都符合
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(queue.ExpertFlag) == register.RegLvlFee.RegLevel.IsExpert && queue.Doctor.ID == register.DoctorInfo.Templet.Doct.ID && queue.AssignDept.ID == register.DoctorInfo.Templet.Dept.ID)
                {
                    this.cmbQueue.SelectedIndex = i;
                    return;
                }

               


            }
            for (int i = 0; i < this.queues.Count; i++)
            {

                //ArrayList al = new ArrayList();
                Neusoft.HISFC.Models.Nurse.Queue queue = new Neusoft.HISFC.Models.Nurse.Queue();
                queue = queues[i] as Neusoft.HISFC.Models.Nurse.Queue;

                //判断是不是专家号

                this.regLevel = this.registrationIntergrade.QueryRegLevelByCode(register.DoctorInfo.Templet.RegLevel.ID);
                register.RegLvlFee.RegLevel.IsExpert = this.regLevel.IsExpert;

                //号别相同（指是否专家）科室相同
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(queue.ExpertFlag) == register.RegLvlFee.RegLevel.IsExpert && queue.AssignDept.ID == register.DoctorInfo.Templet.Dept.ID)
                {
                    this.cmbQueue.SelectedIndex = i;
                    return;
                }


            }
            #region {4600A33C-8065-4b2c-93D2-9B26B24F61CF}
            if (this.cmbQueue.Items.Count > 0)
            {

                this.cmbQueue.SelectedIndex = 0;
                // return;
            } 
            #endregion
            //this.cmbQueue.SelectedIndex = 0;

        }

        #region 定义域

        public delegate void MyDelegate(Neusoft.HISFC.Models.Nurse.Assign assign);
        public event MyDelegate OK;

        public event EventHandler Cancel;

        protected virtual void OnCancel(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                this.Cancel(this, new EventArgs());
            }
        }

        //add by niuxy
        private string Regdoc_id = string.Empty; 

        /// <summary>
        /// 根据排班序号得到排班信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.DoctSchema GetDoctor(string ID)
        {
            if (docts == null) return null;

            foreach (Neusoft.HISFC.Models.Registration.DoctSchema doct in docts)
            {
                if (doct.ID == ID)
                    return doct;
            }

            return null;
        }

        /// <summary>
        /// 患者挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Register
        {
            set
            {
                this.txtCard.Text = value.PID.CardNO;
                this.txtName.Text = value.Name;
                this.txtDept.Text = value.DoctorInfo.Templet.Dept.Name;
                this.txtRegDate.Text = value.DoctorInfo.SeeDate.ToString();
                this.Regdoc_id = value.DoctorInfo.Templet.Doct.ID;

                this.txtCard.Tag = value;
                this.SelectItem(value);
            }
            get
            {
                if (this.txtCard.Tag == null)
                {
                    return null;
                }
                else
                {
                    return (Neusoft.HISFC.Models.Registration.Register)this.txtCard.Tag;
                }
            }
        }

        /// <summary>
        /// 排班医生集合
        /// </summary>
        private ArrayList docts = null;
        #endregion

        private void ucTriage_Load(object sender, EventArgs e)
        {
            this.cmbQueue.Focus();
        }

        private void cmbQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = this.cmbQueue.SelectedItem;

            if (obj == null) return;

            if (obj.GetType() == typeof(Neusoft.HISFC.Models.Nurse.Queue))
            {
                this.txtRoom.Text = (obj as Neusoft.HISFC.Models.Nurse.Queue).SRoom.Name;
            }
            else
            {
                this.txtRoom.Text = obj.User03;
            }
        }

        private void cmbQueue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.neuButton1.Focus();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = this.cmbQueue.SelectedItem;

            if (obj == null)
            {
                MessageBox.Show("请选择分诊队列!", "提示");
                this.cmbQueue.Focus();
                return;
            }

            Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            Neusoft.HISFC.Models.Nurse.Assign assgin = new Neusoft.HISFC.Models.Nurse.Assign();
            Neusoft.HISFC.Models.Nurse.Queue queueinfo = new Neusoft.HISFC.Models.Nurse.Queue();
            queueinfo = (Neusoft.HISFC.Models.Nurse.Queue)this.cmbQueue.SelectedItem;
            if (this.Register.DoctorInfo.Templet.Dept.ID != queueinfo.AssignDept.ID)
            {

            }


            #region 实体赋值
            assgin.Register = this.Register;

            if (obj.GetType() == typeof(Neusoft.HISFC.Models.Nurse.Queue))//队列
            {
                assgin.Queue = (Neusoft.HISFC.Models.Nurse.Queue)obj;
                //if (this.Regdoc_id != null && this.Regdoc_id != "")
                //{
                    if (assgin.Queue.ExpertFlag == "1" && assgin.Register.DoctorInfo.Templet.RegLevel.IsExpert == false)
                    {
                        if (MessageBox.Show("普通号进诊专家队列" + "是否继续？", "提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }
                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean(assgin.Queue.ExpertFlag )  == assgin.Register.DoctorInfo.Templet.RegLevel.IsExpert && assgin.Queue.Doctor.ID != this.Regdoc_id)
                    {
                        if (MessageBox.Show("选择医师与挂号医师不一致，是否继续", " ", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                //}
                //if (this.Regdoc_id == null || this.Regdoc_id == "")
                //{
                    if (assgin.Queue.ExpertFlag == "0" && assgin.Register.DoctorInfo.Templet.RegLevel.IsExpert == true)
                    {

                        if (MessageBox.Show("专家挂号进诊普通队列" + "是否继续？", "提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }
                //}

            }
            else
            {
                Neusoft.HISFC.Models.Registration.DoctSchema doct =
                    this.GetDoctor(obj.ID);
                //add by niuxy
                if (this.Regdoc_id != null && this.Regdoc_id != "")
                {
                    if (doct.ID != this.Regdoc_id)
                        if (MessageBox.Show("专家挂号进诊普通队列" + "是否继续？", "提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    {
                        if (MessageBox.Show("选择医师与挂号医师不一致，是否继续", " ", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
                if (this.Regdoc_id == null || this.Regdoc_id == "")
                {
                    if (assgin.Queue.ExpertFlag == "1")
                    {

                        if (MessageBox.Show("普通号进诊专家队列" + "是否继续？", "提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }
                }
                assgin.Queue.ID = obj.ID;
                assgin.Queue.Name = obj.Name;
                assgin.Queue.Dept.ID = doct.Dept;
                assgin.Queue.Doctor = doct.Doctor;
                assgin.Queue.SRoom = doct.Room;
            }
            Neusoft.HISFC.BizLogic.Nurse.Assign a = new Neusoft.HISFC.BizLogic.Nurse.Assign();
            assgin.TriageStatus = Neusoft.HISFC.Models.Nurse.EnuTriageStatus.Triage;
            //assgin.TriageDept = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID;
            assgin.TriageDept = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
            assgin.TirageTime = a.GetDateTimeFromSysDateTime();// deptMgr.GetDateTimeFromSysDateTime();
            assgin.Oper.OperTime = assgin.TirageTime;
            assgin.Oper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;// var.User.ID;
            assgin.Queue.Dept = assgin.Register.DoctorInfo.Templet.Dept;

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction(); 

            string error = "";

            if (Function.Triage(assgin, "1", ref error) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                #region {9EB5D321-AA03-435f-8581-F64F852D2656}
                MessageBox.Show("无法保存分诊信息，请刷新后重新分诊！", "提示");
                //MessageBox.Show(error, "提示"); 
                #endregion
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (this.OK != null)
                this.OK(assgin);

            this.FindForm().Close();
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            
            this.FindForm().Close();
            this.OnCancel(this, new EventArgs());
        }
    }
}
