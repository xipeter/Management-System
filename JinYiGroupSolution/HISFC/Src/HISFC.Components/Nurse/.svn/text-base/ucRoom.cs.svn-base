using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse
{
    internal partial class ucRoom : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucRoom()
        {
            InitializeComponent();
        }

        private void ucRoom_Load(object sender, EventArgs e)
        {
            try
            {
                this.init();

                this.FindForm().Text = "诊室维护";
                this.FindForm().MinimizeBox = false;
                this.FindForm().MaximizeBox = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            this.tbRoom.Focus();
        }

        #region 定义域

        /// <summary>
        /// 诊室实体
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Room roomMgr = new Neusoft.HISFC.BizLogic.Nurse.Room();
        private Neusoft.HISFC.Models.Nurse.Room roomInfo = new Neusoft.HISFC.Models.Nurse.Room();
        private Neusoft.HISFC.Models.Base.Employee p = new Neusoft.HISFC.Models.Base.Employee();

        private Neusoft.HISFC.BizProcess.Integrate.Manager ps = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        //Neusoft.HISFC.BizLogic.Manager.Person ps = new Neusoft.HISFC.BizLogic.Manager.Person();
        //private Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
        //private Neusoft.HISFC.Models.RADT.Person p = new Neusoft.HISFC.Models.RADT.Person();

        /// <summary>
        /// 诊室实体
        /// </summary>
        public Neusoft.HISFC.Models.Nurse.Room RoomInfo
        {
            get { return this.roomInfo; }
            set { this.roomInfo = value; }
        }


        private string stateFlag = "ADD";
        //控件状态
        public string StateFlag
        {
            get { return this.stateFlag; }
            set { this.stateFlag = value; }
        }
        #endregion

        #region 打开界面赋值

        /// <summary>
        /// 根据传入参数初始化
        /// </summary>
        public void init()
        {
            if (this.stateFlag.ToUpper() == "ADD")
            {
                this.Add();
            }
            if (this.stateFlag.ToUpper() == "EDIT")
            {
                this.Edit();
            }
            this.SetRoom();
            this.tbRoom.Focus();
        }
        private void Add()
        {
            this.stateFlag = "ADD";
            this.cmbValid.SelectedIndex = 1;
            this.tbRoom.Focus();

            this.roomInfo.Sort = 0;
            this.roomInfo.IsValid = "1";

        }
        private void Edit()
        {
            this.stateFlag = "EDIT";
        }

        /// <summary>
        /// 从实体复制到控件
        /// </summary>
        public void SetRoom()
        {
            p = ps.GetEmployeeInfo(this.roomMgr.Operator.ID);
            Neusoft.HISFC.Models.Base.Department dp = new Neusoft.HISFC.Models.Base.Department();
            dp = this.deptMgr.GetDepartment(roomInfo.Nurse.ID);
            this.tbDept.Text = dp.Name;
            this.tbDept.Tag = this.roomInfo.Nurse.ID;
            this.tbRoom.Text = this.roomInfo.Name;
            this.tbRoom.Tag = this.roomInfo.ID;
            this.tbInput.Text = this.roomInfo.InputCode;
            this.tbSort.Text = this.roomInfo.Sort.ToString();
            this.cmbValid.SelectedIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(this.roomInfo.IsValid);

            this.tbOper.Text = p.Name;
            this.tbOperDate.Text = this.roomMgr.GetDateTimeFromSysDateTime().ToString();
        }
        #endregion

        #region 获取界面数据，进行保存
        /// <summary>
        /// 获取界面信息，转化为实体
        /// </summary>
        public void GetRoom()
        {
            if (this.RoomInfo == null) this.RoomInfo = new Neusoft.HISFC.Models.Nurse.Room();
            //诊室代码
            if (this.tbRoom.Tag != null)
            {
                this.RoomInfo.ID = this.tbRoom.Tag.ToString();
            }
            //诊室名称
            this.RoomInfo.Name = this.tbRoom.Text;
            //助记码
            this.RoomInfo.InputCode = this.tbInput.Text.Trim().ToString();
            //显示顺序
            this.RoomInfo.Sort = Neusoft.FrameWork.Function.NConvert.ToInt32(this.tbSort.Text);
            //是否有效
            this.RoomInfo.IsValid = this.cmbValid.SelectedIndex.ToString();
            //			//备注
            //			this.RoomInfo.Memo = this.txtMemo.Text;
            //操作员
            this.RoomInfo.User01 = this.roomMgr.Operator.ID;
            //护理站代码
            if (this.roomInfo.Nurse.ID == null || this.roomInfo.Nurse.ID == "")
            {
                p = ps.GetEmployeeInfo(this.roomMgr.Operator.ID);
                this.roomInfo.Nurse.ID = p.Nurse.ID.ToString();
            }
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            //队列名称		
            #region {94891FA8-D93C-4705-AA14-FAB414F9701A}
            string QueueName = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.tbRoom.Text);
            if (QueueName == "")
            {
                MessageBox.Show("诊室名称不能为空或者包含特殊字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbRoom.Focus();
                return false;
            }
            #endregion
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(QueueName, 20))
            {
                MessageBox.Show("诊室名称不能超过10个汉字");
                return false;
            }
            //助记码
            string inputcode = this.tbInput.Text.Trim();
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(inputcode, 8))
            {
                MessageBox.Show("助记码不能超过8位");
                return false;
            }
            //显示顺序
            string SortId = this.tbSort.Text;
            if (SortId == "")
            {
                MessageBox.Show("显示顺序不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbSort.Focus();
                return false;
            }
            if (!this.IsNum(SortId))
            {
                MessageBox.Show("顺序号必须为数字");
                this.tbSort.SelectAll();
                return false;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(SortId, 4))
            {
                MessageBox.Show("显示顺序不能超过4位");
                this.tbSort.SelectAll();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 是否存在相同诊室
        /// </summary>
        /// <returns></returns>
        private int ValidExist()
        {
            int returnValue = this.roomMgr.QueryRoomByNameAndDept(this.roomInfo.ID, this.roomInfo.Nurse.ID,this.roomInfo.Name);
            if (returnValue < 0)
            {
                //{94891FA8-D93C-4705-AA14-FAB414F9701A}
                MessageBox.Show("查询诊室" + this.roomInfo.Name + "出错" + this.roomMgr.Err); 
                return -1;
            }
            if (returnValue >= 1)
            {
                MessageBox.Show("已存在相同的诊室");
                return -1;
            }

            return 1;
        }

        private int ValidInUsing(string roomId)
        {
            DateTime currentDT = this.roomMgr.GetDateTimeFromSysDateTime();
            int returnValue = this.roomMgr.QueryRoomByRoomID(roomId,currentDT.ToString());
            if (returnValue < 0)
            {
                MessageBox.Show(this.roomMgr.Err);
                return -1;
            }
            if(returnValue > 0)
            {
                MessageBox.Show("该诊室正在使用，不能置成无效状态");
                return -1;

            }
            return 1;
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
        /// <summary>
        /// 保存
        /// </summary>
        private int SaveData()
        {
            //验证数据
            if (!this.ValidData())
            {
                return -1;
            }

            this.GetRoom();
            if (this.ValidExist() < 0)
            {
                return -1;
            }
            if (this.stateFlag.ToUpper() == "ADD")
            {
                this.roomInfo.ID = this.roomMgr.GetSequence("Nurse.Seat.GetSeq");
                if (this.ValidExist() < 0)
                {
                    return -1;
                }
                this.roomInfo.User02 = this.roomMgr.GetDateTimeFromSysDateTime().ToString();

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();

                this.roomMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.roomMgr.InsertRoomInfo(this.RoomInfo) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入诊室出错" + this.roomMgr.Err);
                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            if (this.stateFlag.ToUpper() == "EDIT")
            {
                if (this.ValidExist() < 0)
                {
                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();

                this.roomMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.roomMgr.Update(this.RoomInfo) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("修改诊室出错" + this.roomMgr.Err);
                    return -1;
                }
                else
                {
                    //by niuxinyuan    暂时不更新诊台状态如果需要再打开
                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean( this.roomInfo.IsValid) == false )
                    {
                        if (this.ValidInUsing(this.roomInfo.ID) < 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            return -1;
                        }
                        if (this.roomMgr.UpdateSeatByRoom(this.roomInfo.ID, this.roomInfo.IsValid) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("修改诊台出错" + this.roomMgr.Err);
                            return -1;
                        }
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            return 0;

        }

        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            this.tbRoom.Text = "";
            this.tbInput.Text = "";
            this.tbSort.Text = "";
        }
        #endregion 

        #region 事件处理程序

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SaveData() == -1)
            {
                return;
            }
            MessageBox.Show("保存成功!", "提示");
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((!(ActiveControl is Button) && keyData == Keys.Enter))
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                return true;
            }
            return false;
        }

        #endregion

    }
}
