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
    public partial class ucDept : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {

        public ucDept()
        {
            InitializeComponent();
        }

        private void ucDept_Load(object sender, EventArgs e)
        {
            this.InitTree();

            //得到挂号科室
            Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            al = deptMgr.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.C);

            if (al == null) al = new ArrayList();
            this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 0, al);

            foreach (Neusoft.HISFC.Models.Base.Department dept in al)
            {
                htDept.Add(dept.ID, dept.Name);
            }
            this.fpEnter1.KeyEnter += new Neusoft.HISFC.Components.Nurse.Base.FpEnter.keyDown(fpEnter1_KeyEnter);
            this.fpEnter1.SetItem += new Neusoft.HISFC.Components.Nurse.Base.FpEnter.setItem(fpSpread1_SetItem);
        }

        #region 定义域

        private Neusoft.HISFC.BizProcess.Integrate.Manager cDept = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizLogic.Nurse.Dept nurseDept = new Neusoft.HISFC.BizLogic.Nurse.Dept();
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup current = null;

        private Hashtable hashFlag = new Hashtable();
        private Hashtable htDept = new Hashtable();
        private ArrayList alNurse = null;
        private ArrayList al = new ArrayList();

        #endregion

        #region 工具条

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("添加", "", 0, true, false, null);
            this.toolBarService.AddToolButton("删除", "", 0, true, false, null);
            return this.toolBarService;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            return 1;
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

        #endregion

        #region 方法

        /// <summary>
        /// 根据科室代码查找名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetDeptNameByID(string ID)
        {
            IDictionaryEnumerator dict = this.htDept.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == ID)
                    return dict.Value.ToString();
            }
            return ID;
        }

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
            try
            {
                if (this.fpEnter1_Sheet1.Tag == null)
                {
                    MessageBox.Show("请先选择病区!", "提示");
                    return;
                }
                this.fpEnter1_Sheet1.Rows.Add(this.fpEnter1_Sheet1.RowCount, 1);
                int row = this.fpEnter1_Sheet1.RowCount - 1;
                //挂号科室
                this.fpEnter1_Sheet1.SetValue(row, 0, "", false);
                //显示顺序
                this.fpEnter1_Sheet1.SetValue(row, 1, "1", false);
                //操作员
                this.fpEnter1_Sheet1.SetValue(row, 2, Neusoft.FrameWork.Management.Connection.Operator.Name/*var.User.Name*/, false);
                this.fpEnter1_Sheet1.Cells[row, 2].Value = Neusoft.FrameWork.Management.Connection.Operator.ID;/* var.User.ID;*/
                //操作时间
                this.fpEnter1_Sheet1.SetValue(row, 3, this.nurseDept.GetDateTimeFromSysDateTime().ToString(), false);
                this.fpEnter1.Focus();
                this.fpEnter1_Sheet1.SetActiveCell(row, 0, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
        }


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
                MessageBox.Show(ex.ToString() + this.nurseDept.Err);
            }
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
                this.alNurse = this.nurseDept.GetDeptInfoByNurseNo(nurse.ID);

                this.neuTabControl1.TabPages[0].Text = nurse.Name;

                this.fpEnter1_Sheet1.Tag = nurse;

                if (alNurse != null)
                {
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in alNurse)
                    {
                        this.fpEnter1_Sheet1.Rows.Add(this.fpEnter1_Sheet1.RowCount, 1);
                        int row = this.fpEnter1_Sheet1.RowCount - 1;
                        this.fpEnter1_Sheet1.Rows[row].Tag = obj;
                        //挂号科室代码
                        this.fpEnter1_Sheet1.SetText(row, 0, this.GetDeptNameByID(obj.Name));

                        this.fpEnter1_Sheet1.Cells[row, 0].Tag = obj.Name;
                        //显示顺序
                        this.fpEnter1_Sheet1.SetValue(row, 1, obj.User01, false);

                        //操作员
                        this.fpEnter1_Sheet1.SetValue(row, 2, obj.User02, false);
                        //操作时间
                        this.fpEnter1_Sheet1.SetValue(row, 3, this.nurseDept.GetSysDateTime(), false);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + this.nurseDept.Err);
            }
        }

        private bool ValidData()
        {
            Hashtable hash = new Hashtable();

            if (this.fpEnter1_Sheet1.Rows.Count > 0)
            {
                this.fpEnter1.StopCellEditing();

                for (int i = 0; i < this.fpEnter1_Sheet1.Rows.Count; i++)
                {
                    //诊室代码
                    if (this.fpEnter1_Sheet1.GetTag(i, 0) == null)
                    {
                        MessageBox.Show("挂号科室代码未选择!");
                        return false;
                    }
                    string DeptID = this.fpEnter1_Sheet1.GetTag(i, 0).ToString();

                    if (DeptID == "")
                    {
                        MessageBox.Show("挂号科室不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(DeptID, 4))
                    {
                        MessageBox.Show("挂号科室代码过长");
                        return false;
                    }
                    if (hash.Contains(DeptID))
                    {
                        MessageBox.Show("挂号科室不能重复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        hash.Add(DeptID, 0);
                    }

                    //显示顺序
                    string SortId = this.fpEnter1_Sheet1.GetText(i, 1).ToString();
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(SortId, 4))
                    {
                        MessageBox.Show("顺序号过长");
                        return false;
                    }
                    else if (SortId == "")
                    {
                        MessageBox.Show("顺序号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                }

                return true;

            }
            else
            {
                return true;
            }
        }



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
            //Neusoft.FrameWork.Management.Transaction tran = new Neusoft.FrameWork.Management.Transaction(this.nurseDept.Connection);
            //开始事务
            try
            {
                //tran.BeginTransaction();

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                this.nurseDept.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.nurseDept.DelDeptInfo((this.fpEnter1_Sheet1.Tag as Neusoft.FrameWork.Models.NeuObject).ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.nurseDept.Err, "提示");
                    return;
                }
                //循环插入
                for (int i = 0; i < this.fpEnter1_Sheet1.RowCount; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject objDept = new Neusoft.FrameWork.Models.NeuObject();
                    //护士站
                    objDept.ID = (this.fpEnter1_Sheet1.Tag as Neusoft.FrameWork.Models.NeuObject).ID;
                    //挂号科室
                    objDept.Name = this.fpEnter1_Sheet1.Cells[i, 0].Tag.ToString();
                    //显示顺序
                    objDept.User01 = this.fpEnter1_Sheet1.Cells[i, 1].Text.ToString();
                    //操作员					
                    objDept.User02 = this.nurseDept.Operator.ID;
                    //操作时间
                    objDept.User03 = this.nurseDept.GetSysDateTime();

                    if (this.nurseDept.InsertDeptInfo(objDept) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.nurseDept.Err, "提示");
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

        #endregion

        #region 事件

        //private void fpSpread1_Enter(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F11)
        //    {
        //        this.AddRow();
        //    }
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //挂号科室
        //        if (this.fpEnter1_Sheet1.ActiveColumnIndex == 0)
        //        {
        //            current = this.fpEnter1.GetCurrentList(this.fpEnter1_Sheet1, 0);
        //            if (current == null) return ;

        //            Neusoft.FrameWork.Models.NeuObject obj = current.GetSelectedItem();

        //            if (obj == null) return ;
        //            this.fpEnter1_Sheet1.SetText(this.fpEnter1_Sheet1.ActiveRowIndex, this.fpEnter1_Sheet1.ActiveColumnIndex,
        //                obj.Name);
        //            this.fpEnter1_Sheet1.SetTag(this.fpEnter1_Sheet1.ActiveRowIndex,
        //                this.fpEnter1_Sheet1.ActiveColumnIndex, obj.ID);

        //            this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 1, false);
        //        }
        //        //显示顺序
        //        else if (this.fpEnter1_Sheet1.ActiveColumnIndex == 1)
        //        {
        //            if (this.fpEnter1_Sheet1.ActiveRowIndex == this.fpEnter1_Sheet1.RowCount - 1)
        //            {
        //                this.AddRow();
        //                this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 0, false);
        //            }
        //            else
        //            {
        //                this.fpEnter1_Sheet1.ActiveRowIndex++;
        //                this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 0, false);
        //            }
        //        }
        //    }
        //}

        private int fpEnter1_KeyEnter(Keys key)
        {
            if (key == Keys.F11)
            {
                this.AddRow();
            }
            if (key == Keys.Enter)
            {
                //挂号科室
                if (this.fpEnter1_Sheet1.ActiveColumnIndex == 0)
                {
                    current = this.fpEnter1.GetCurrentList(this.fpEnter1_Sheet1, 0);
                    if (current == null) return -1;

                    Neusoft.FrameWork.Models.NeuObject obj = current.GetSelectedItem();

                    if (obj == null) return -1;
                    this.fpEnter1_Sheet1.SetText(this.fpEnter1_Sheet1.ActiveRowIndex, this.fpEnter1_Sheet1.ActiveColumnIndex,
                        obj.Name);
                    this.fpEnter1_Sheet1.SetTag(this.fpEnter1_Sheet1.ActiveRowIndex,
                        this.fpEnter1_Sheet1.ActiveColumnIndex, obj.ID);

                    this.fpEnter1_Sheet1.SetActiveCell(this.fpEnter1_Sheet1.ActiveRowIndex, 1, false);
                }
                //显示顺序
                else if (this.fpEnter1_Sheet1.ActiveColumnIndex == 1)
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

        private int fpSpread1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
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
            int altKey = Keys.Alt.GetHashCode();

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
            if (keyData.GetHashCode() == altKey + Keys.S.GetHashCode())
            {
                this.SaveData();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void tvPatientList1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode currentNode = this.tvPatientList1.SelectedNode;

            if (currentNode == null || currentNode.Parent == null)
            {
                if (this.fpEnter1_Sheet1.RowCount > 0)
                    this.fpEnter1_Sheet1.Rows.Remove(0, this.fpEnter1_Sheet1.RowCount);

                this.fpEnter1_Sheet1.Tag = null;
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject nurse = (Neusoft.FrameWork.Models.NeuObject)currentNode.Tag;
                this.RefreshList(nurse);
            }
        }

        #endregion

    }
}
