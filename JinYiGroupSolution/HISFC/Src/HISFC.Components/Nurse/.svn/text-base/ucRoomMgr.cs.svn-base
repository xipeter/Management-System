using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse
{
    public partial class ucRoomMgr : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucRoomMgr()
        {
            InitializeComponent();
        }

        #region 定义域

        private ArrayList alNurse = null;
        private Hashtable hashFlag = new Hashtable();
        private string formSet;

        private Neusoft.HISFC.BizProcess.Integrate.Manager cDept = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizLogic.Nurse.Room nurseRoom = new Neusoft.HISFC.BizLogic.Nurse.Room();
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = null;

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("添加", "", 0, true, false, null);
            this.toolBarService.AddToolButton("删除", "", 0, true, false, null);
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "添加":
                    this.AddRow();
                    break;
                case "删除":
                    this.DelRow();
                    break;
                default:
                    break;
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            return 1;
        }

        #endregion


        #region 方法

        /// <summary>
        /// 生成挂号员列表
        /// </summary>
        private void InitTree()
        {
            this.tvPatientList1.Nodes.Clear();

            TreeNode root = new TreeNode("护士站");
            this.tvPatientList1.Nodes.Add(root);

            //获的护士站列表
            this.alNurse = cDept.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
            if (alNurse != null)
            {
                foreach (Neusoft.FrameWork.Models.NeuObject obj in alNurse)
                {
                    //设置维护权限------------这儿最好是通过入口参数控制-------------

                    if (!(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).IsManager))
                    {
                        if (obj.ID != (((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID) /*var.User.Nurse.ID*/) continue;
                    }
                    //end------------------------------------------------------------
                    TreeNode node = new TreeNode(obj.Name);
                    node.Tag = obj;
                    root.Nodes.Add(node);
                }
            }
            root.Expand();
        }

        /// <summary>
        /// 增加
        /// </summary>
        private void AddRow()
        {
            if (this.fpEnter1_Sheet1.Tag == null)
            {
                MessageBox.Show("请先选择病区!", "提示");
                return;
            }
            this.fpEnter1_Sheet1.Rows.Add(this.fpEnter1_Sheet1.RowCount, 1);
            int row = this.fpEnter1_Sheet1.RowCount - 1;
            //诊室代码
            this.fpEnter1_Sheet1.SetValue(row, 0, "", false);
            //诊室名称
            this.fpEnter1_Sheet1.SetValue(row, 1, "", false);
            //助记码
            this.fpEnter1_Sheet1.SetValue(row, 2, "", false);
            //显示顺序
            this.fpEnter1_Sheet1.SetValue(row, 3, "1", false);
            //是否有效
            this.fpEnter1_Sheet1.SetValue(row, 4, "有效", false);
            //操作员
            this.fpEnter1_Sheet1.SetValue(row, 5, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name/* var.User.Name*/, false);
            this.fpEnter1_Sheet1.Cells[row, 5].Value = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID/* var.User.ID*/;
            //操作时间
            this.fpEnter1_Sheet1.SetValue(row, 6, this.nurseRoom.GetDateTimeFromSysDateTime().ToString(), false);
            this.fpEnter1.Focus();
            this.fpEnter1_Sheet1.SetActiveCell(row, 0, false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void DelRow()
        {
            try
            {
                int row = this.fpEnter1_Sheet1.ActiveRowIndex;
                if (row < 0 || this.fpEnter1_Sheet1.RowCount == 0) return;

                if (MessageBox.Show("是否要删除该记录?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                //已经保存的项目,从数据库中删除
                if (this.fpEnter1_Sheet1.Rows[row].Tag != null)
                {

                }
                this.fpEnter1_Sheet1.Rows.Remove(row, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + this.nurseRoom.Err);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void SaveData()
        {
            this.fpEnter1.StopCellEditing();

            if (this.fpEnter1_Sheet1.Tag == null)
            {
                MessageBox.Show("请先选择病区!", "提示");
                return;
            }
            //验证数据
            if (!this.ValidData())
            {
                this.fpEnter1.Focus();
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction tran = new Neusoft.FrameWork.Management.Transaction(this.nurseRoom.Connection);
            //开始事务
            try
            {

                //tran.BeginTransaction();

                this.nurseRoom.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.nurseRoom.DelRoomInfo((this.fpEnter1_Sheet1.Tag as Neusoft.FrameWork.Models.NeuObject).ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.nurseRoom.Err, "提示");
                    return;
                }
                //循环插入
                for (int i = 0; i < this.fpEnter1_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Nurse.Room obj = new Neusoft.HISFC.Models.Nurse.Room();
                    //病区代码
                    obj.Nurse.ID = (this.fpEnter1_Sheet1.Tag as Neusoft.FrameWork.Models.NeuObject).ID;


                    //诊室标识
                    obj.ID = this.fpEnter1_Sheet1.Cells[i, 0].Text.ToString();
                    //诊室名称
                    obj.Name = this.fpEnter1_Sheet1.Cells[i, 1].Text.ToString();
                    //助剂码
                    obj.InputCode = this.fpEnter1_Sheet1.Cells[i, 2].Text.ToString();
                    //显示顺序
                    obj.Sort = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpEnter1_Sheet1.Cells[i, 3].Text.ToString());
                    //是否有效
                    if (this.fpEnter1_Sheet1.Cells[i, 4].Text.ToString() == "有效")
                    {
                        obj.IsValid = "1";
                    }
                    else
                    {
                        obj.IsValid = "0";
                    }
                    //操作员					
                    obj.User01 = this.nurseRoom.Operator.ID;
                    //操作时间
                    obj.User02 = this.nurseRoom.GetSysDateTime();

                    if (this.nurseRoom.InsertRoomInfo(obj) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.nurseRoom.Err, "提示");
                        return;
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }
            MessageBox.Show("保存成功!", "提示");
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="person"></param>
        private void RefreshList(Neusoft.FrameWork.Models.NeuObject nurse)
        {
            if (this.fpEnter1_Sheet1.RowCount > 0)
                this.fpEnter1_Sheet1.Rows.Remove(0, this.fpEnter1_Sheet1.RowCount);

            try
            {
                //检索病区的维护信息
                this.alNurse = this.nurseRoom.GetRoomInfoByNurseNo(nurse.ID);

                this.fpEnter1_Sheet1.Tag = nurse;

                if (alNurse != null)
                {
                    foreach (Neusoft.HISFC.Models.Nurse.Room obj in alNurse)
                    {
                        this.fpEnter1_Sheet1.Rows.Add(this.fpEnter1_Sheet1.RowCount, 1);
                        int row = this.fpEnter1_Sheet1.RowCount - 1;
                        this.fpEnter1_Sheet1.Rows[row].Tag = obj;
                        //诊室代码
                        this.fpEnter1_Sheet1.SetValue(row, 0, obj.ID, false);

                        this.fpEnter1_Sheet1.Cells[row, 0].Tag = nurse.ID;
                        //诊室名称
                        this.fpEnter1_Sheet1.SetValue(row, 1, obj.Name, false);
                        //助剂码
                        this.fpEnter1_Sheet1.SetValue(row, 2, obj.InputCode, false);
                        //显示顺序
                        this.fpEnter1_Sheet1.SetValue(row, 3, obj.Sort, false);
                        //是否有效
                        if (obj.IsValid == "1")
                        {
                            this.fpEnter1_Sheet1.SetValue(row, 4, "有效", false);
                        }
                        else
                        {
                            this.fpEnter1_Sheet1.SetValue(row, 4, "无效", false);
                        }
                        //操作员
                        this.fpEnter1_Sheet1.SetValue(row, 5,((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID/* var.User.ID*/, false);
                        //操作时间
                        this.fpEnter1_Sheet1.SetValue(row, 6, this.nurseRoom.GetSysDateTime(), false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + this.nurseRoom.Err);
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            Hashtable hash = new Hashtable();

            if (this.fpEnter1_Sheet1.Rows.Count > 0)
            {
                this.fpEnter1.StopCellEditing();

                for (int i = 0; i < this.fpEnter1_Sheet1.Rows.Count; i++)
                {
                    //诊室代码
                    string RoomID = this.fpEnter1_Sheet1.GetText(i, 0).ToString();

                    if (RoomID == "")
                    {
                        MessageBox.Show("诊室代码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(RoomID, 4))
                    {
                        MessageBox.Show("诊室代码过长");
                        return false;
                    }
                    if (hash.Contains(RoomID))
                    {
                        MessageBox.Show("诊室代码不能重复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        hash.Add(RoomID, 0);
                    }

                    //诊室名称
                    string RoomName = this.fpEnter1_Sheet1.GetText(i, 1).ToString();
                    if (RoomName == "")
                    {
                        MessageBox.Show("诊室名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(RoomName, 20))
                    {
                        MessageBox.Show("诊室名称过长");
                        return false;
                    }
                    //助记码
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.fpEnter1_Sheet1.GetText(i, 2).ToString(), 8))
                    {
                        MessageBox.Show("助记码过长");
                        return false;
                    }
                    //显示顺序
                    string SortId = this.fpEnter1_Sheet1.GetText(i, 3).ToString();
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(SortId, 4))
                    {
                        MessageBox.Show("顺序号过长");
                        return false;
                    }

                }

                return true;

            }
            else
                return true;
        }

        #endregion

        private void ucRoomMgr_Load(object sender, EventArgs e)
        {
            this.InitTree();

            if (this.Tag != null)
                this.formSet = this.Tag.ToString();
            this.fpEnter1.KeyEnter += new Neusoft.HISFC.Components.Nurse.Base.FpEnter.keyDown(fpEnter1_KeyEnter);
            this.fpEnter1.SetItem += new Neusoft.HISFC.Components.Nurse.Base.FpEnter.setItem(fpEnter1_SetItem);
        }

        private int fpEnter1_KeyEnter(Keys key)
        {
            if (key == Keys.F11)
            {
                this.AddRow();
            }
            if (key == Keys.Enter)
            {
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == 4)
                {
                    current = this.fpEnter1.GetCurrentList(this.fpEnter1_Sheet1, 4);
                    if (current == null) return -1;

                    Neusoft.FrameWork.Models.NeuObject obj = current.GetSelectedItem();

                    if (obj == null) return -1;
                    this.fpEnter1_Sheet1.SetText(this.fpEnter1_Sheet1.ActiveRowIndex, this.fpEnter1_Sheet1.ActiveColumnIndex,obj.Name);
                    this.fpEnter1_Sheet1.SetTag(this.fpEnter1_Sheet1.ActiveRowIndex,
                        this.fpEnter1_Sheet1.ActiveColumnIndex, obj.ID);

                }
                //科室代码
                else if (this.fpEnter1_Sheet1.ActiveColumnIndex == 0)
                {
                    this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 1, false);
                }
                //科室名称
                else if (this.fpEnter1_Sheet1.ActiveColumnIndex == 1)
                {
                    this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 2, false);
                }
                //助剂码
                else if (this.fpEnter1_Sheet1.ActiveColumnIndex == 2)
                {
                    this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 3, false);
                }
                //显示顺序
                else if (this.fpEnter1_Sheet1.ActiveColumnIndex == 3)
                {
                    this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 4, false);
                }
                else if (this.fpEnter1_Sheet1.ActiveColumnIndex == 5)
                {
                    if (this.fpEnter1_Sheet1.ActiveRowIndex == this.fpEnter1_Sheet1.RowCount - 1)
                    {
                        this.AddRow();
                        this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 0, false);
                    }
                    else
                    {
                        this.fpEnter1_Sheet1.ActiveRowIndex++;
                        this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 0, false);
                    }
                }

            }
            return 0;
        }

        private int fpEnter1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
        {
            if (obj == null) return -1;

            this.fpEnter1_Sheet1.SetText(this.fpEnter1_Sheet1.ActiveRowIndex, this.fpEnter1_Sheet1.ActiveColumnIndex,
                obj.Name);
            this.fpEnter1_Sheet1.SetTag(this.fpEnter1_Sheet1.ActiveRowIndex, this.fpEnter1_Sheet1.ActiveColumnIndex,
                obj.ID);

            this.fpEnter1.Focus();
            this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, this.fpEnter1_Sheet1.ActiveColumnIndex);
            return 0;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Add || keyData == Keys.Oemplus)
            {
                this.AddRow();
                return true;
            }
            else if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            {
                this.DelRow();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void tvPatientList1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode current = this.tvPatientList1.SelectedNode;


            if (current == null || current.Parent == null)
            {
                if (this.fpEnter1_Sheet1.RowCount > 0)
                    this.fpEnter1_Sheet1.Rows.Remove(0, this.fpEnter1_Sheet1.RowCount);

                this.fpEnter1_Sheet1.Tag = null;
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject nurse = (Neusoft.FrameWork.Models.NeuObject)current.Tag;
                this.RefreshList(nurse);
            }
        }
		
    }
}
