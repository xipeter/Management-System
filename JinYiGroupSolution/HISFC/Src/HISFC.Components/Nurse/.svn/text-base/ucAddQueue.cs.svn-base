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
    /// <summary>
    /// 添加新分诊队列
    /// </summary>
    internal partial class ucAddQueue : UserControl
    {
        public ucAddQueue()
        {
            InitializeComponent();
        }

        public ucAddQueue(cResult r)
            : this()
		{
			this.myResult = r;				
		}

        #region 定义域myQueue

        /// <summary>
        /// 取(ADD,EDIT)值
        /// </summary>
        private string stateFlag = "ADD";

        private Nurse.cResult myResult = new cResult();
        /// <summary>
        /// 医生排班管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration myMgr = null;
        /// <summary>
        /// 人员管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = null;

        private Neusoft.HISFC.BizProcess.Integrate.Manager depMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 队列管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Queue myQueue = null;
     
        /// <summary>
        /// 诊室管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Room myRoom = null;
       
        /// <summary>
        /// 队列实体
        /// </summary>
        private Neusoft.HISFC.Models.Nurse.Queue queue = new Neusoft.HISFC.Models.Nurse.Queue();

        private Neusoft.HISFC.Models.Nurse.Queue oldQuery = new Neusoft.HISFC.Models.Nurse.Queue();
        private Neusoft.HISFC.Models.Nurse.Queue myOldQueue = new Neusoft.HISFC.Models.Nurse.Queue();
        /// <summary>
        /// 诊台管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Seat seatMgr = new Neusoft.HISFC.BizLogic.Nurse.Seat();

        private ArrayList al = new ArrayList();

        #endregion	

        #region 事件

        public delegate void ClickSave(Neusoft.FrameWork.Models.NeuObject obj);
        public event ClickSave RefList;

        #endregion

        #region 属性

        /// <summary>
        /// 队列实体
        /// </summary>
        public Neusoft.HISFC.Models.Nurse.Queue Queue
        {
            get { return this.queue; }
            set { this.queue = value; }
        }

        /// <summary>
        /// 取(ADD,EDIT)值
        /// </summary>
        public string StateFlag
        {
            get { return this.stateFlag; }
            set { this.stateFlag = value; }
        }

        #region {B3E7633A-D9FB-492f-9D62-D2F7188D5643}
        DialogResult myDiagResult = DialogResult.Cancel;
        /// <summary>
        /// 窗口返回
        /// </summary>
        public DialogResult AddQueDiagResult
        {
            get
            {
                return this.myDiagResult;
            }
        }
        #endregion
        #endregion


        #region 初始化

        /// <summary>
        /// 根据传入参数初始化
        /// </summary>
        private void Init()
        {
            if (this.myResult.strTab.ToUpper() == "ADD")
            {
                this.Add();
            }
            if (this.myResult.strTab.ToUpper() == "EDIT")
            {
                this.Edit();
            }
            Initcbo();
            this.SetQueue();
            this.dtQueue.Focus();
        }

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        private void Initcbo()
        {
            //初始化午别
            if (this.myMgr == null) this.myMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
            al = this.myMgr.Query();
            if (al == null) al = new ArrayList();
            this.cmbNoon.AddItems(al);
            //初始化看诊科室
            Neusoft.HISFC.BizProcess.Integrate.Manager ps = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //Neusoft.HISFC.BizLogic.Manager.Person ps = new Neusoft.HISFC.BizLogic.Manager.Person();
            //Neusoft.HISFC.Models.RADT.Person p = new Neusoft.HISFC.Models.RADT.Person();
            Neusoft.HISFC.Models.Base.Employee p = new Neusoft.HISFC.Models.Base.Employee();
            p = ps.GetEmployeeInfo(this.seatMgr.Operator.ID);
            //al = this.depMgr.QueryDepartment(this.myResult.Nurse.ID);//
            al = this.depMgr.QueryDepartmentForArray (this.myResult.Nurse.ID);
            if (al != null || al.Count > 0)
            {
                this.cmbAssignDept.ClearItems();
                this.cmbAssignDept.AddItems(al);
                this.cmbAssignDept.IsListOnly = true;
            }
            //初始化看诊医生
            if (this.personMgr == null) this.personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //得到医生列表
            al = this.personMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (al == null) al = new ArrayList();
            this.cmbDoct.AddItems(al);
            this.cmbDoct.BringToFront();
            this.cmbDoct.IsListOnly = true;
            //加载病区诊室
            if (this.myRoom == null) this.myRoom = new Neusoft.HISFC.BizLogic.Nurse.Room();
            al = new ArrayList();
            al = this.myRoom.GetRoomInfoByNurseNoValid(this.Queue.Dept.ID);
            if (al != null)　
            {
                ArrayList b = new ArrayList();

                foreach (Neusoft.HISFC.Models.Nurse.Room obj in al)
                {
                    Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

                    dept.ID = obj.ID;
                    dept.Name = obj.Name;
                    dept.UserCode = obj.InputCode;

                    b.Add(dept);
                }

                this.cmbRoom.AddItems(b);
                this.cmbRoom.IsListOnly = true;
            }
            //加载有效状态
            al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "1";
            obj1.Name = "有效";
            al.Add(obj1);
            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            obj2.ID = "0";
            obj2.Name = "无效";
            al.Add(obj2);
            this.cmbValid.AddItems(al);
            this.cmbValid.SelectedIndex = 0;
            //加载队列类别
            al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj3 = new Neusoft.FrameWork.Models.NeuObject();
            obj3.ID = "1";
            obj3.Name = "医生队列";
            al.Add(obj3);
            Neusoft.FrameWork.Models.NeuObject obj4 = new Neusoft.FrameWork.Models.NeuObject();
            obj4.ID = "2";
            obj4.Name = "自定义队列";
            al.Add(obj4);
            this.cmbQueueType.AddItems(al);
            //操作员信息
            this.tbOper.Text = p.Name;
            this.tbOper.Tag = p.ID;
            this.tbOperDate.Text = this.seatMgr.GetDateTimeFromSysDateTime().ToString();

            this.dtQueue.Focus();
        }

        #endregion

        #region 方法

        private void Add()
        {
            this.myResult.strTab = "ADD";
            this.dtQueue.Focus();
        }

        private void Edit()
        {
            this.myResult.strTab = "EDIT";
            this.dtQueue.Focus();
        }

        private void Clear()
        {
            this.tbQueueName.Text = "";
            this.cmbQueueType.Text = "";
            this.cmbDoct.Text = "";
        }

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsNum(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsNumber(str, i))
                    return false;
            }
            return true;
        }

        private bool ValidData()
        {
           // if (this.dtQueue.Value.Date.CompareTo(DateTime.Now.Date) < 0 )
            if (this.dtQueue.Value.Date.CompareTo(Neusoft.FrameWork.Function.NConvert.ToDateTime((this.seatMgr.GetSysDate())).Date)< 0)
            {
                MessageBox.Show("不能保存小于当前日期的队列信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtQueue.Focus();
                return false;
            }
            //诊室不能为空
            string strRoom = this.cmbRoom.Text;
            if (strRoom == "")
            {
                MessageBox.Show("诊室不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbRoom.Focus();
                return false;
            }
            //诊台不能为空
            string strSeat = this.cmbConsole.Text;
            if (strSeat == "")
            {
                MessageBox.Show("诊台不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbConsole.Focus();
                return false;
            }
            //看诊科室 {FE3F7C68-0CD6-4a3c-8878-920542863F2F}
            if (this.cmbAssignDept.Text.ToString().Trim() == null || this.cmbAssignDept.Text.ToString().Trim() == "")
            {
                MessageBox.Show("看诊科室不能为空!", "提示");
                this.cmbAssignDept.Focus();
                return false;
            }
            //队列名称		
            #region {A5165913-94E7-428a-86D4-CE0442697D96}
            string QueueName = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.tbQueueName.Text);
            this.tbQueueName.Text = QueueName; 
            #endregion
            if (QueueName == "")
            {
                MessageBox.Show("队列名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbQueueName.Focus();
                return false;
            }
            else if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(QueueName, 40))
            {
                MessageBox.Show("队列名称过长");
                this.tbQueueName.Focus();
                this.tbQueueName.SelectAll();
                return false;
            }
           
            //显示顺序
            string SortId = this.tbSort.Text;
            if (SortId == "")
            {
                MessageBox.Show("顺序号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbSort.Focus();
                return false;
            }
            if (!this.IsNum(SortId))
            {
                MessageBox.Show("顺序号必须为数字");
                this.tbSort.Focus();
                this.tbSort.SelectAll();
                return false;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(SortId, 4))
            {
                MessageBox.Show("顺序号过长");
                this.tbSort.SelectAll();
                return false;
            }
            //备注
            string Memo = this.tbMemo.Text;
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(Memo, 100))
            {
                MessageBox.Show("备注过长");
                return false;
            }
            //午别
            string strNoon = this.cmbNoon.Text;
            if (strNoon == "")
            {
                MessageBox.Show("午别不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbNoon.Focus();
                return false;
            }

            return true;
        }
        /// <summary>
        /// 判断诊室诊台已经被其它科室使用
        /// </summary>
        /// <param name="myQueue">分诊队列实体</param>
        /// <returns></returns>
        private bool ValidUsed(Neusoft.HISFC.Models.Nurse.Queue myQueue)
        {
            if (this.queue.User03 == "0")
            {
                return true;
            }

            bool returnValue = this.myQueue.QueryUsed(myQueue.Console.ID,myQueue.Noon.ID,myQueue.QueueDate.ToString());
            if (returnValue == false)
            {
                MessageBox.Show(this.myQueue.Err);
                return false;
            }
            return true;
        }

        private int ValidInUsing(string QueueID)
        {
            DateTime currentDT = this.myQueue.GetDateTimeFromSysDateTime();
            int returnValue = this.myQueue.QueryQueueByQueueID(QueueID,currentDT.ToString());
            if (returnValue < 0)
            {
                MessageBox.Show(this.myQueue.Err);
                return -1;
            }
            if (returnValue > 0)
            {
                MessageBox.Show("该队列正在使用，不能置成无效状态");
                return -1;

            }
            return 1;
        }
        private int ValidModify(Neusoft.HISFC.Models.Nurse.Queue OldQueue, Neusoft.HISFC.Models.Nurse.Queue Queue)
        {
            if (    OldQueue.QueueDate      != Queue.QueueDate
                ||  OldQueue.SRoom.ID       != Queue.SRoom.ID
                ||  OldQueue.Console.ID     != Queue.Console.ID
                ||  OldQueue.AssignDept.ID  != Queue.AssignDept.ID
                ||  OldQueue.Doctor.ID      != Queue.Doctor.ID
                ||  OldQueue.ExpertFlag     != Queue.ExpertFlag
                ||  OldQueue.Name           != Queue.Name
                ||  OldQueue.User01         != Queue.User01
                ||  OldQueue.Noon.ID        != Queue.Noon.ID
                ||  OldQueue.Order          != Queue.Order
                ||  OldQueue.IsValid        != Queue.IsValid

                )
            {
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private int SaveData()
        {
            //验证数据
            if (!this.ValidData())
            {
                return -1;
            }
            if (myQueue == null) this.myQueue = new Neusoft.HISFC.BizLogic.Nurse.Queue();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(myQueue.Connection);
            //trans.BeginTransaction();

            myQueue.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.GetQueue();
            if (this.myResult.strTab.ToUpper() == "ADD")
            {
                if (this.IsExistsQueue())
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("相同的队列已经存在");
                    return -1;
                }
                //判断是否使用
                if (this.ValidUsed(this.Queue) == false)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
                if (this.myQueue.InsertQueue(this.Queue) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入队列出错" + this.myQueue.Err);
                    return -1;
                }
            }
            if (this.myResult.strTab.ToUpper() == "EDIT")
            {
                //if (this.myQueue.ExistPatient(this.queue.SRoom.ID, this.queue.Console.ID, this.queue.ID, this.queue.Noon.ID))
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("队列中有患者，不能修改!");
                //    return -1;
                //}
                //if (this.myQueue.UpdateQueue(this.Queue) == -1)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("修改队列出错" + this.myQueue.Err);
                //    return -1;
                //}
                //if (this.IsExistsQueue())
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("相同的队列已经存在");
                //    return -1;
                //}
                if (this.ValidModify(this.myOldQueue, this.queue) == 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("记录没有改变，无需保存!");
                    return -1;
                }

                if (this.ValidUsed(this.queue) == false)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }

                if (this.myQueue.ExistPatient(this.myOldQueue.SRoom.ID, this.myOldQueue.Console.ID, this.myOldQueue.ID, this.myOldQueue.Noon.ID))
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("队列中有患者，不能修改!");
                    return -1;
                }
                if (this.queue.IsValid == false)
                {
                    if (this.ValidInUsing(this.Queue.ID) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                }


                if (this.myQueue.UpdateQueue(this.Queue) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("修改队列出错" + this.myQueue.Err);
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;

        }

        /// <summary>
        /// 判断队列存在
        /// </summary>
        /// <returns>false:不存在;  true存在</returns>
        private bool IsExistsQueue()
        {

            if (this.queue.Doctor.ID != null && this.queue.Doctor.ID != "")
            {
                for (int i = 0, j = this.myResult.QueueList.Count; i < j; i++)
                {
                    if (this.queue.Noon.ID == this.myResult.QueueList[i].Noon.ID &&
                        this.queue.QueueDate.Date == this.myResult.QueueList[i].QueueDate.Date &&
                        this.queue.AssignDept.ID == this.myResult.QueueList[i].AssignDept.ID &&
                        this.queue.Doctor.ID == this.myResult.QueueList[i].Doctor.ID &&
                        this.queue.Console.ID == this.myResult.QueueList[i].Console.ID &&
                        this.queue.IsValid == this.myResult.QueueList[i].IsValid)
                    {
                        return true;
                    }
                }
            }
            
            if (this.queue.Doctor.ID == null || this.queue.Doctor.ID == "")
            {
                for (int i = 0, j = this.myResult.QueueList.Count; i < j; i++)
                {
                    if (this.queue.Noon.ID == this.myResult.QueueList[i].Noon.ID &&
                        this.queue.QueueDate.Date == this.myResult.QueueList[i].QueueDate.Date &&
                        //this.queue.AssignDept.ID == this.myResult.QueueList[i].AssignDept.ID &&
                        this.queue.Console.ID == this.myResult.QueueList[i].Console.ID &&
                        this.queue.IsValid == this.myResult.QueueList[i].IsValid &&
                        (this.myResult.QueueList[i].Doctor.ID == null || this.myResult.QueueList[i].Doctor.ID == "")
                        )
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 从实体复制到控件
        /// </summary>
        public void SetQueue()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager ps = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Employee p = new Neusoft.HISFC.Models.Base.Employee();
            p = ps.GetEmployeeInfo(this.seatMgr.Operator.ID);

            //护士站
            this.tbDept.Text = this.Queue.Dept.Name;
            this.tbDept.Tag = this.Queue.Dept.ID;
            //午别
            this.cmbNoon.Tag = this.Queue.Noon.ID;
            this.cmbNoon.Text = this.Queue.Noon.Name;
            //看诊科室
            if (this.queue.AssignDept.ID != null && this.queue.AssignDept.ID != "")
            {
                this.cmbAssignDept.Tag = this.queue.AssignDept.ID;
                this.cmbAssignDept.Text = this.queue.AssignDept.Name;
            }
            else
            {
                //this.cmbAssignDept.Tag = p.Dept.ID;
                //this.cmbAssignDept.Text = this.depMgr.GetDeptmentById(p.Dept.ID).Name;
            }
            //看诊医生
            this.cmbDoct.Tag = this.Queue.Doctor.ID;
            //队列日期
            this.dtQueue.Value = this.Queue.QueueDate;

            //对列类型
            //if (this.cmbDoct.Text != "" && this.cmbDoct.Tag != null)
            //{
            //    this.cmbQueueType.Text = "医生队列";
            //}
            //else
            //{
            //    this.cmbQueueType.Text = "自定义队列";
            //}

            //对列类型[2007/03/27]
            if (this.queue.User01.Trim() == "1")
            {
                this.cmbQueueType.Text = "医生队列";
            }
            else
            {
                this.cmbQueueType.Text = "自定义队列";

            }
            //显示顺序
            this.tbSort.Text = this.Queue.Order.ToString();
            //是否有效
            if (this.Queue.IsValid)
            {
                this.cmbValid.Tag = "1";
            }
            else
            {
                this.cmbValid.Tag = "0";
            }
            this.cmbRoom.Tag = this.Queue.SRoom.ID;
            
            this.cmbExport.SelectedIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Queue.ExpertFlag);

            //对列名称
            this.tbQueueName.Text = this.Queue.Name;
            //队列标识
            this.tbQueueName.Tag = this.Queue.ID;
            //操作员信息
            this.tbOper.Text = p.Name;
            this.tbOper.Tag = p.ID;
            this.tbOperDate.Text = this.seatMgr.GetDateTimeFromSysDateTime().ToString();
            
            this.cmbConsole.Tag = this.Queue.Console.ID;
            this.cmbConsole.Text = this.Queue.Console.Name;
            //备注
            this.tbMemo.Text = this.Queue.Memo;
        }

        public void GetQueue()
        {
            if (this.Queue == null) this.Queue = new Neusoft.HISFC.Models.Nurse.Queue();
            //队列名
            if (this.tbQueueName.Tag != null)
            {
                //队列标识
                this.Queue.ID = this.tbQueueName.Tag.ToString();
            }
            this.Queue.Name = this.tbQueueName.Text;
            if (this.tbDept.Tag != null)
            {
                this.Queue.Dept.ID = this.tbDept.Tag.ToString();
            }

            this.Queue.Dept.Name = this.tbDept.Text;
            //队列日期
            this.Queue.QueueDate = this.dtQueue.Value;
            //看诊科室
            this.queue.AssignDept.ID = this.cmbAssignDept.Tag.ToString();
            this.queue.AssignDept.Name = this.cmbAssignDept.Text.ToString();
            //看诊医生
            if (this.cmbDoct.SelectedIndex != -1) this.Queue.Doctor.ID = this.cmbDoct.SelectedItem.ID;
            //队列类别
            if (this.cmbQueueType.SelectedIndex != -1) this.Queue.User01 = this.cmbQueueType.SelectedItem.ID;
            //午别
            if (this.cmbNoon.SelectedIndex != -1) this.Queue.Noon.ID = this.cmbNoon.SelectedItem.ID;
            //显示顺序
            this.Queue.Order = Neusoft.FrameWork.Function.NConvert.ToInt32(this.tbSort.Text);
            //是否有效
            this.Queue.IsValid = this.cmbValid.SelectedItem.ID == "1" ? true : false;
            if (this.cmbRoom.SelectedIndex != -1)
            {
                this.Queue.SRoom.ID = this.cmbRoom.SelectedItem.ID;
                this.Queue.SRoom.Name = this.cmbRoom.SelectedItem.Name;
            }
            //备注
            this.Queue.Memo = this.tbMemo.Text;
            //操作员
            this.Queue.Oper.ID = this.myQueue.Operator.ID;
            //诊台
            if (this.cmbConsole.Tag.ToString() == this.queue.Console.ID)
            {
                this.queue.User03 = "0";        //说明本次未修改诊台信息
            }
            this.queue.Console.ID = this.cmbConsole.Tag.ToString();
            this.queue.Console.Name = this.cmbConsole.Text;
            //是否专家
            this.queue.ExpertFlag = this.cmbExport.SelectedIndex.ToString();

        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SaveData() == -1) return;
                MessageBox.Show("保存成功!", "提示");
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.tbDept.Tag.ToString();
                obj.Name = this.tbDept.Text;

                #region {B3E7633A-D9FB-492f-9D62-D2F7188D5643}
                
                //    this.RefList(obj);
                                
                this.myDiagResult = DialogResult.OK;
                #endregion
                this.FindForm().Close();
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            #region {B3E7633A-D9FB-492f-9D62-D2F7188D5643}
            this.myDiagResult = DialogResult.Cancel;
            #endregion
            this.FindForm().Close();
        }

        private void ucAddQueue_Load(object sender, EventArgs e)
        {
            try
            {
                this.Queue = this.myResult.Queue;
                this.myOldQueue = this.myResult.Queue.Clone();
                this.Init();

                this.FindForm().Text = "队列维护";
                this.FindForm().MinimizeBox = false;
                this.FindForm().MaximizeBox = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            this.dtQueue.Focus();
        }

        private void cmbDoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDoct.SelectedIndex != -1)//如果选择医生队列名称为医生否这为自定义队列
            {
                //对列名称
                this.tbQueueName.Text = this.cmbDoct.SelectedItem.Name;
                this.cmbQueueType.Tag = "1";
            }
            else
            {
                this.cmbQueueType.Tag = "2";
            }
        }

        private void cmbDoct_Leave(object sender, EventArgs e)
        {
            if (this.cmbDoct.Text == "")
            {
                this.tbQueueName.Focus();
                this.cmbQueueType.Tag = "2";
            }
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbMemo.Text = this.cmbRoom.SelectedItem.ToString();
            //根据诊室，生成有效的诊台
            string strRoom = this.cmbRoom.Tag.ToString();
            ArrayList al = new ArrayList();
            al = this.seatMgr.QueryValid(strRoom);
            if (al == null || al.Count <= 0)
            {
                this.cmbConsole.ClearItems();
                return;
            }
            ArrayList b = new ArrayList();

            foreach (Neusoft.HISFC.Models.Nurse.Seat obj in al)
            {
                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

                dept.ID = obj.ID;
                dept.Name = obj.Name;
                dept.UserCode = obj.PRoom.InputCode;

                b.Add(dept);
            }
            this.cmbConsole.AddItems(b);
            this.cmbConsole.IsListOnly = true;
            this.cmbConsole.Text = "";
            this.tbMemo.Text = this.cmbRoom.SelectedItem.ToString() + "◆" + this.cmbConsole.Text;
            al.Clear();
        }

        private void cmbConsole_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbMemo.Text = this.cmbRoom.Text + "◆" + this.cmbConsole.Text;
        }

        private void cmbExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbExport.SelectedIndex == 0)
            {
                return;
            }
            if (this.cmbDoct.Text == null || this.cmbDoct.Text == "")
            {
                MessageBox.Show("没有选择医生，不能设为专家队列!请先选择医生!", "提示");
                this.cmbExport.SelectedIndex = 0;
                this.cmbDoct.Focus();
                return;
            }
        }
    }
}
