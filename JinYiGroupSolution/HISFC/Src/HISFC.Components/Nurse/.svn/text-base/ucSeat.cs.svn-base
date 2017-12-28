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
    public partial class ucSeat : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 工具条
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();


        #region 工具条按钮处理程序

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("添加房间", "添加一个新的房间", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            this.toolBarService.AddToolButton("删除房间", "删除一个已经房间", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);
            this.toolBarService.AddToolButton("增加", "增加明细", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolBarService.AddToolButton("删除", "删除明细", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "添加房间":
                    this.AddRoom();
                    break;

                case "删除房间":
                    this.DelRoom();
                    break;

                case "增加":
                    this.AddRecord();
                    break;

                case "删除":
                    this.DelRecord();
                    break;

                default:
                    break;
            }
            //base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.Save() == -1)
            {
                return -1;
            }
            return 1;
            //return base.OnSave(sender, neuObject);
        }

        #endregion

        public ucSeat()
        {
            InitializeComponent();
        }

        private void ucSeat_Load(object sender, EventArgs e)
        {
            InitCtrl();
            this.SetFp();
        }

        #region 初始化

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void InitCtrl()
        {
            try
            {
                RefreshRooms();
                this.SetFp();
                this.neuSpread1.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            }
            catch { }
        }

        /// <summary>
        /// 初始化诊室列表
        /// </summary>
        public void RefreshRooms()
        {
            this.neuTreeView1.Nodes.Clear();
            Neusoft.HISFC.Models.Base.Employee e = (Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator;
            
            //string FormSet = this.ParentForm.Tag.ToString();
            ArrayList alNurse = new ArrayList();
            Neusoft.HISFC.BizLogic.Nurse.Room roomMgr = new Neusoft.HISFC.BizLogic.Nurse.Room();

            //TreeNode root = new TreeNode("护士站");
            //this.neuTreeView1.Nodes.Add(root);

            //全部护理站都可以维护
            //if (FormSet == "ALL")
            if(e.IsManager)
            {
                alNurse = this.deptMgr.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);

                TreeNode root = new TreeNode("护士站");
                this.neuTreeView1.Nodes.Add(root);

                //获取护士站列表
                this.alNurse = this.deptMgr.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
                if (alNurse != null)
                {
                    foreach (Neusoft.HISFC.Models.Base.Department obj in alNurse)
                    {
                        TreeNode node = new TreeNode(obj.Name, 1, 1);
                        node.Tag = obj;
                        root.Nodes.Add(node);
                        //node.ContextMenuStrip = this.contextMenuStrip1;
                        //添加该护理站的诊室
                        ArrayList alrooms = roomMgr.GetRoomInfoByNurseNo(obj.ID);
                        if (alrooms != null)
                        {
                            foreach (Neusoft.HISFC.Models.Nurse.Room room in alrooms)
                            {
                                TreeNode node2 = new TreeNode(room.Name, 0, 0);
                                node2.Tag = room;
                                node2.ContextMenuStrip = this.contextMenuStrip1;
                                node.Nodes.Add(node2);
                            }
                        }
                    }
                    root.Expand();
                }
                else
                {
                    MessageBox.Show("没有获得护理站列表!");
                    return;
                }
            }
            else//只能维护自己所在的护理站
            {
                //初始化诊室列表
                ArrayList alCurrent = this.deptMgr.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
                TreeNode node = new TreeNode();
                foreach (Neusoft.HISFC.Models.Base.Department obj in alCurrent)
                {
                    //if (obj.ID.Trim().Equals(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID))
                    if (obj.ID.Trim().Equals(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID))
                    {
                        node.SelectedImageIndex = 1;
                        node.ImageIndex = 1;
                        node.Text = obj.Name;
                        node.Tag = obj;
                        this.neuTreeView1.Nodes.Add(node);
                        //node.ContextMenuStrip=this.contextMenuStrip1;
                        break;
                    }
                }

                //添加该护理站的诊室
                //ArrayList alrooms = roomMgr.GetRoomInfoByNurseNo(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID);
                ArrayList alrooms = roomMgr.GetRoomInfoByNurseNo(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID);
                if (alrooms != null)
                {
                    foreach (Neusoft.HISFC.Models.Nurse.Room room in alrooms)
                    {
                        TreeNode node2 = new TreeNode(room.Name, 0, 0);
                        node2.Tag = room;
                        node2.ContextMenuStrip = this.contextMenuStrip1;
                        node.Nodes.Add(node2);
                    }
                    this.neuTreeView1.ExpandAll();
                }
                //TreeNode root = new TreeNode(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.Name);
                //this.neuTreeView1.Nodes.Add(root);

                ////ArrayList alrooms = roomMgr.GetRoomInfoByNurseNo(Neusoft.FrameWork.Management.Connection.Operator.ID);
                //ArrayList alrooms = roomMgr.GetRoomInfoByNurseNo(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID);
                //if (alrooms != null)
                //{
                //    foreach (Neusoft.HISFC.Models.Nurse.Room room in alrooms)
                //    {
                //        TreeNode node = new TreeNode(room.Name, 1, 1);
                //        node.Tag = room;
                //        root.Nodes.Add(node);
                //    }
                //    this.neuTreeView1.ExpandAll();
                //}
            }
        }

        #endregion

        #region 方法

        #region 对诊室的操作

        /// <summary>
        /// 修改诊室
        /// </summary>
        private void ModifyRoom()
        {
            TreeNode node = this.neuTreeView1.SelectedNode;
            if (node == null || node.Tag == null)
            {
                MessageBox.Show("请选择一个诊室", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (node.Tag.GetType() != typeof(Neusoft.HISFC.Models.Nurse.Room)) return;

            Neusoft.HISFC.Models.Nurse.Room info = node.Tag as Neusoft.HISFC.Models.Nurse.Room;
            Nurse.ucRoom ucRoom1 = new ucRoom();
            ucRoom1.StateFlag = "EDIT";
            ucRoom1.RoomInfo = info;
            
            ucRoom1.init();
            if (Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucRoom1) == System.Windows.Forms.DialogResult.OK)
            {
                //this.RefreshRooms();
                //this.neuTreeView1.SelectedNode = node;
                //node.Expand();
                node.Text = ucRoom1.RoomInfo.Name;
                if (ucRoom1.RoomInfo.IsValid == "0")
                {
                    this.SetFp("停用");
                }
            }
            this.SetFp();
        }

        /// <summary>
        /// 添加诊室
        /// </summary>
        private void AddRoom()
        {
            Nurse.ucRoom ucRoom1 = new ucRoom();
            ucRoom1.StateFlag = "ADD";

            TreeNode node = this.neuTreeView1.SelectedNode;
            if (node.Level == 0)
            {
                return;
            }
            if (node == null/*node.Tag == null*/)
            {
                MessageBox.Show("请选择一个护理站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (node.Tag.GetType() != typeof(Neusoft.HISFC.Models.Base.Department)) return;

            Neusoft.HISFC.Models.Base.Department info = node.Tag as Neusoft.HISFC.Models.Base.Department;
            ucRoom1.RoomInfo.Nurse = info;
            ucRoom1.init();

            if (Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucRoom1) == System.Windows.Forms.DialogResult.OK)
            {
                TreeNode node2 = new TreeNode(ucRoom1.RoomInfo.Name, 0, 0);
                node2.Tag = ucRoom1.RoomInfo;
                node2.ContextMenuStrip = this.contextMenuStrip1;
                node.Nodes.Add(node2);
               
 
                node.Expand();
            }
        }

        /// <summary>
        /// 删除诊室
        /// </summary>
        private void DelRoom()
        {
            TreeNode node = this.neuTreeView1.SelectedNode;
            if (node == null || node.Tag == null || node.Tag.GetType() != typeof(Neusoft.HISFC.Models.Nurse.Room))
            {
                MessageBox.Show("请选择一个诊室", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Neusoft.HISFC.Models.Nurse.Room info = node.Tag as Neusoft.HISFC.Models.Nurse.Room;
            if (MessageBox.Show("删除诊室将同时删除其下面的诊台,是否确认删除:" + info.Name + "?",
                "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //SQLCA.BeginTransaction();

            roomMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            seatMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                //判断诊室是否被排班
                int result = roomMgr.QueryRoom(info.ID, roomMgr.GetSysDate());
                if (result < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("查询诊室失败" + roomMgr.Err);

                    return;
                }
                if (result >= 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("在以后的时间里，该诊室在队列维护中已经被维护，不能删除");

                    return;
                }

                //
               

                if (roomMgr.DelRoomInfo(info.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除诊室失败！\n请与系统管理员联系。" + roomMgr.Err, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.seatMgr.DeleteByRoom(info.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除诊台失败！\n请与系统管理员联系。" + this.seatMgr.Err, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除诊室失败！" + e.Message, "提示");
                return;
            }
            this.neuTreeView1.Nodes.Remove(node);
            MessageBox.Show("删除成功!", "提示");
        }

        #endregion

        #region 对诊台的操作
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="flagStr">停用或在用</param>
        private void SetFp(string flagStr)
        {
            int RowCount = this.neuSpread1_Sheet1.RowCount;
            if (RowCount <= 0) return;
            for (int i = 0; i < RowCount; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 3].Value = flagStr;
            }
        }

        /// <summary>
        /// 增加诊台记录
        /// </summary>
        private void AddRecord()
        {
            TreeNode node = this.neuTreeView1.SelectedNode;
            if (node == null || node.Tag == null) return;
            if (node.Tag.GetType() != typeof(Neusoft.HISFC.Models.Nurse.Room)) return;

            Neusoft.HISFC.Models.Nurse.Room room = node.Tag as Neusoft.HISFC.Models.Nurse.Room;

            if (room.IsValid.Trim().Equals("0"))
            {
                if (MessageBox.Show("【" + room.Name + "】已经停用," + "是否继续添加诊台?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            this.neuSpread1.StopCellEditing();

            string strNewNo = this.seatMgr.GetSequence("Nurse.Seat.GetSeq");
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);
            int row = this.neuSpread1_Sheet1.RowCount - 1;
            this.neuSpread1_Sheet1.ActiveRowIndex = row;
            this.neuSpread1_Sheet1.Cells[row, 0].Tag = strNewNo;
            this.neuSpread1_Sheet1.Cells[row, 2].Value = room.Name;
            this.neuSpread1_Sheet1.Cells[row, 2].Tag = room.ID;
            this.neuSpread1_Sheet1.Rows[row].Tag = room.Nurse.ID;

            if (room.IsValid.Trim().Equals("1"))
            {
                this.neuSpread1_Sheet1.Cells[row, 3].Value = "在用";
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[row, 3].Value = "停用";
            }

            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
            txt.ReadOnly = true;
            txt.StringTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.neuSpread1_Sheet1.Cells[row, 2].CellType = txt;

            this.IsModified = true;
            this.neuSpread1.Focus();
        }

        /// <summary>
        /// 删除诊台记录
        /// </summary>
        private void DelRecord()
        {
            if (this.neuSpread1_Sheet1.ActiveRow == null)//未选定记录
            {
                MessageBox.Show("请选择要删除的诊台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strSeatName = "";//诊室名称
            string strSeatID = "";
            strSeatID = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRow.Index, 0].Tag.ToString();
            if (this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRow.Index, 0].Text == "")
                strSeatName = "";
            else
                strSeatName = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRow.Index, 0].Value.ToString();
            DialogResult result;
            result = MessageBox.Show("是否确认删除诊台 " + strSeatName, "提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) return;

           
            //数据库事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            this.seatMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //判断诊室是否被排班

            int result1 = this.seatMgr.QueryConsole(strSeatID, this.seatMgr.GetSysDate());
            if (result1 < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("查询诊台失败" + this.seatMgr.Err);

                return;
            }
            if (result1 >= 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("在以后的时间里，该诊台在队列维护中已经被维护，不能删除");

                return;
            }

            try
            {
                if (this.seatMgr.DeleteByConsole(strSeatID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除诊台失败！\n请与系统管理员联系。" + this.seatMgr.Err, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除诊台失败！" + e.Message, "提示");
                return;
            }
            this.neuSpread1_Sheet1.ActiveRow.Remove();
        }

        /// <summary>
        /// 判断是否有相同记录
        /// </summary>
        /// <returns></returns>
        private int ValidSameValue()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount - 1; i++)
            {
                for (int j = i + 1; j < this.neuSpread1_Sheet1.RowCount  ;j++ )
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 0].Text == this.neuSpread1_Sheet1.Cells[j, 0].Text)// &&
                       // this.neuSpread1_Sheet1.Cells[i, 1].Text == this.neuSpread1_Sheet1.Cells[j, 1].Text)
                    {
                        MessageBox.Show("已经存在相同诊台");
                        return -1;
                    }

                }
            }
            return 1;
        }
        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns></returns>
        private int Valid()
        {
            if (this.neuSpread1_Sheet1.RowCount <= 0) return -1;
            if (this.ValidSameValue() == -1) return -1;
            try
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    //诊台名称 {B8E0377D-1F45-4077-B168-E38E76C5A2D7}
                    string strTemp = this.neuSpread1_Sheet1.Cells[i, 0].Text.Trim();
                    if (strTemp == null || strTemp == "")
                    {
                        MessageBox.Show("诊台名称不能为空!", "提示");
                        return -1;
                    }
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(strTemp, 20))
                    {
                        MessageBox.Show("诊台名称不能超过10个汉字!", "提示");
                        return -1;
                    }
                    //输入码
                    strTemp = this.neuSpread1_Sheet1.Cells[i, 1].Text.Trim();
                    if (strTemp == null || strTemp == "")
                    {
                        MessageBox.Show("输入码不能为空!", "提示");
                        return -1;
                    }
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(strTemp, 20))
                    {
                        MessageBox.Show("输入码不能超过8个汉字!", "提示");
                        return -1;
                    }

                    //备注
                    string strMemo = this.neuSpread1_Sheet1.Cells[i, 4].Text.Trim();
                    if (strMemo != null && !Neusoft.FrameWork.Public.String.ValidMaxLengh(strMemo, 50))
                    {
                        MessageBox.Show("备注长度不能超过25个汉字!", "提示");
                        return -1;
                    }


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 保存操作结果
        /// </summary>
        /// <return>0 success, -1 fail</return>
        public int Save()
        {
            this.neuSpread1.StopCellEditing();

            if (this.neuSpread1_Sheet1.RowCount <= 0)
            {
                MessageBox.Show("没有要保存的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            

            if (this.Valid() == -1) return -1;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //SQLCA.BeginTransaction();

            this.seatMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    #region 界面生成实体
                    Neusoft.HISFC.Models.Nurse.Seat info = new Neusoft.HISFC.Models.Nurse.Seat();
                    info.ID = this.neuSpread1_Sheet1.Cells[i, 0].Tag.ToString();
                    info.Name = this.neuSpread1_Sheet1.GetValue(i, 0).ToString();
                    info.PRoom.InputCode = this.neuSpread1_Sheet1.GetValue(i, 1).ToString();
                    info.PRoom.ID = this.neuSpread1_Sheet1.Cells[i, 2].Tag.ToString();
                    info.PRoom.Name = this.neuSpread1_Sheet1.GetValue(i, 2).ToString();
                    //状态
                    string strTemp = "1";
                    if (this.neuSpread1_Sheet1.GetValue(i, 3).ToString().Trim() == "停用")
                    {
                        strTemp = "0";
                    }
                    info.PRoom.IsValid = strTemp;
                    //备注
                    string strMemo = this.neuSpread1_Sheet1.Cells[i, 4].Text.Trim();
                    if (strMemo == null) strMemo = "";
                    info.Memo = strMemo;
                    //操作信息
                    info.Oper.ID= this.seatMgr.Operator.ID;
                    info.Oper.OperTime = this.seatMgr.GetDateTimeFromSysDateTime();



                   
                    #endregion

                    if (!Neusoft.FrameWork.Function.NConvert.ToBoolean(info.PRoom.IsValid))
                    {
                        Neusoft.HISFC.BizLogic.Nurse.Assign assMgr = new Neusoft.HISFC.BizLogic.Nurse.Assign();
                        assMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        if (assMgr.ExistPatient(info.ID, assMgr.GetSysDateTime()))
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(info.Name + " 有患者,不能将状态改为无效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.neuSpread1_Sheet1.SetValue(i, 3, "在用");
                            return -1;
                        }

                        //if (this.seatMgr.QuerySeatByConsoleID(info.ID) < 0)
                        //{

                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //    MessageBox.Show(this.seatMgr.Err);
                        //    return -1;
                        //}
                        //if (this.seatMgr.QuerySeatByConsoleID(info.ID) > 0)
                        //{

                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //    MessageBox.Show("该诊台正在使用不能置成无效");
                        //    return -1;
                        //}

                       
                    }


                    if (this.seatMgr.Insert(info) == -1)
                    {
                        if (this.seatMgr.Update(info) == -1)
                        {

                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存失败!" + this.seatMgr.Err, "提示");
                            return -1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存失败!" + e.Message, "提示");
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功!", "提示");

            this.SetFp();

            return 0;
        }

        #endregion

        #endregion

        #region  公用

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str, i))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 设置farpoint格式
        /// </summary>
        private void SetFp()
        {
            FarPoint.Win.Spread.CellType.TextCellType txtOnly = new FarPoint.Win.Spread.CellType.TextCellType();
            txtOnly.ReadOnly = true;
            this.neuSpread1_Sheet1.Columns[2].CellType = txtOnly;
            this.neuSpread1_Sheet1.Columns[2].Visible = false;
        }

        #endregion

        #region 事件处理程序

        private void neuTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.neuTreeView1.SelectedNode = e.Node;
                
            }
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                this.neuSpread1_Sheet1.RemoveRows(0, this.neuSpread1_Sheet1.RowCount);
            }

            if (e.Node.Tag == null) return;
            //没有放在诊室上面
            if (e.Node.Tag.GetType() != typeof(Neusoft.HISFC.Models.Nurse.Room)) return;


            Neusoft.HISFC.Models.Nurse.Room room = (Neusoft.HISFC.Models.Nurse.Room)e.Node.Tag;
            ArrayList al = new ArrayList();
            al = this.seatMgr.Query(room.ID);
            if (al == null || al.Count <= 0) return;


            foreach (Neusoft.HISFC.Models.Nurse.Seat seat in al)
            {
                this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                int row = this.neuSpread1_Sheet1.RowCount - 1;

                this.neuSpread1_Sheet1.Cells[row, 0].Tag = seat.ID;
                this.neuSpread1_Sheet1.SetValue(row, 0, seat.Name);
                this.neuSpread1_Sheet1.SetValue(row, 1, seat.PRoom.InputCode);
                this.neuSpread1_Sheet1.SetValue(row, 2, room.Name);
                this.neuSpread1_Sheet1.Cells[row, 2].Tag = room.ID;
                if (seat.PRoom.IsValid == "1")
                {
                    this.neuSpread1_Sheet1.Cells[row, 3].Value = "在用";
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[row, 3].Value = "停用";
                }
                this.neuSpread1_Sheet1.SetValue(row, 4, seat.PRoom.Memo);
            }
        }

        private void neuSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.neuSpread1_Sheet1.ActiveColumnIndex < 4)
                {
                    this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex,
                        this.neuSpread1_Sheet1.ActiveColumnIndex + 1);
                }
                if (this.neuSpread1_Sheet1.ActiveColumnIndex == 4
                    && this.neuSpread1_Sheet1.ActiveRowIndex < this.neuSpread1_Sheet1.RowCount - 1)
                {
                    this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex + 1, 0);
                }
            }
        }

        private void neuSpread1_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 3)
            {
                this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex,
                    this.neuSpread1_Sheet1.ActiveColumnIndex + 1);
            }
        }

        /// <summary>
        /// 右键菜单-修改  处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode node = this.neuTreeView1.SelectedNode;
            if (node.Parent == null)
            {
                MessageBox.Show("请选择一个诊台");
                return;
            }
            ModifyRoom();
        }

        /// <summary>
        /// 右键菜单-删除 处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TreeNode node = this.neuTreeView1.SelectedNode;
            if (node.Parent == null)
            {
                MessageBox.Show("请选择一个诊台");
                return;
            }
            DelRoom();
        }

        #endregion

        #region 定义域

        private Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        public Neusoft.HISFC.BizLogic.Nurse.Seat seatMgr = new Neusoft.HISFC.BizLogic.Nurse.Seat();
        public Neusoft.HISFC.BizLogic.Nurse.Room roomMgr = new Neusoft.HISFC.BizLogic.Nurse.Room();
        private Neusoft.HISFC.Models.Nurse.Seat seatInfo = new Neusoft.HISFC.Models.Nurse.Seat();

        private ArrayList alConsole = new ArrayList();//所选手术室所有诊台对象列表
        private ArrayList alNurse = new ArrayList();

        public bool IsModified = false;//编辑状态
        public delegate void RefRoom();

        #endregion
    }
}