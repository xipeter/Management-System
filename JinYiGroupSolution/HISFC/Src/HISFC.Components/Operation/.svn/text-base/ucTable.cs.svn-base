using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术台维护]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucTable : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucTable()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.Init();
                this.LoadRooms();

            }
        }

        #region 字段

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        private frmOperationRoom room;
        private List<string> modified = new List<string>();
        #endregion

        #region 属性
        /// <summary>
        /// 当前手术室
        /// </summary>
        private OpsRoom CurrentRoom
        {
            get
            {
                return this.treeView1.SelectedNode.Tag as OpsRoom;
            }
        }

        private frmOperationRoom DialogRoom
        {
            get
            {
                if (this.room == null)
                    this.room = new frmOperationRoom();

                return this.room;
            }
        }
        #endregion

        #region 方法

        private void Init()
        {
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.F分解));
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.B病历));
        }

        /// <summary>
        /// 装载手术室
        /// </summary>
        private void LoadRooms()
        {
            treeView1.Nodes.Clear();
            //初始化手术间列表
            TreeNode root = new TreeNode(Environment.OperatorDept.Name, 0, 0);
            treeView1.Nodes.Add(root);

            ArrayList rooms = Environment.TableManager.GetRoomsByDept(Environment.OperatorDeptID);
            if (rooms != null)
            {
                foreach (OpsRoom room in rooms)
                {
                    //读出手术台
                    ArrayList tables = Environment.TableManager.GetOpsTable(room.ID);
                    foreach (OpsTable table in tables)
                    {
                        room.AddTable(table);
                    }

                    TreeNode node = new TreeNode(room.Name, 1, 1);
                    node.Tag = room;
                    root.Nodes.Add(node);
                }
                treeView1.ExpandAll();
            }
        }

        private int Save()
        {
            this.ucTableSpread1.Update();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();
            Environment.TableManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.ucTableSpread1.ValidState() == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            foreach (string id in this.modified)
            {
                foreach (TreeNode node in this.treeView1.Nodes[0].Nodes)
                {
                    OpsRoom room = node.Tag as OpsRoom;
                    if (room.ID == id)
                    {
                        foreach (OpsTable table in room.Tables)
                        {
                            if (!table.IsOK())
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(table.InvalidInfo + ",请确认后重试！"
                                    , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }
                        }
                        if (Environment.TableManager.DelOpsTables(id) == -1)
                        {

                        }

                        if (Environment.TableManager.AddOpsTable(room.Tables) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存手术台失败！\n请与系统管理员联系。" + Environment.TableManager.Err
                                , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                    }
                }
            }

            this.modified.Clear();
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功");
            return 0;
        }
        #endregion

        #region 事件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.CurrentRoom == null)
            {
                this.ucTableSpread1.OperationRoom = null;
                return;
            }
            this.ucTableSpread1.Reset();

            this.ucTableSpread1.OperationRoom = this.CurrentRoom;
            this.ucTableSpread1.AddItem(this.CurrentRoom.Tables);

        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

            this.ucTableSpread1.Update();
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton( "增加", "增加", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null );
            this.toolBarService.AddToolButton("删除", "删除", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            this.toolBarService.AddToolButton( "-", "-", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null );
            this.toolBarService.AddToolButton("增加房间", "增加房间", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolBarService.AddToolButton("删除房间", "删除房间", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加")
            {
                if (this.CurrentRoom == null)
                {
                    MessageBox.Show("请先选择手术房间！");
                    return;
                }
                this.ucTableSpread1.AddItem();
            }
            else if (e.ClickedItem.Text == "删除")
            {
                this.ucTableSpread1.DeleteItem();
                if (CurrentRoom == null)
                {
                    MessageBox.Show("请选择手术房间");
                    return;
                }
                if (!this.modified.Contains(this.CurrentRoom.ID))
                    this.modified.Add(this.CurrentRoom.ID);
            }
            else if (e.ClickedItem.Text == "增加房间")
            {

                this.DialogRoom.Room = new OpsRoom();
                this.DialogRoom.IsNew = true;

                if (this.DialogRoom.ShowDialog() == DialogResult.OK)
                {
                    OpsRoom room = this.DialogRoom.Room.Clone();

                    this.ucTableSpread1.Reset();
                    TreeNode node = new TreeNode(room.Name, 1, 1);
                    node.Tag = room;
                    this.treeView1.Nodes[0].Nodes.Add(node);
                    this.modified.Add(room.ID);

                }
            }
            else if (e.ClickedItem.Text == "删除房间")
            {
                if (this.CurrentRoom == null)
                    return;

                if (MessageBox.Show("删除手术间将同时删除其下面的手术台,是否确认删除手术间:" + this.CurrentRoom.Name + "?",
                           "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                if (Environment.TableManager.DelOpsRoom(this.CurrentRoom) == -1)
                {
                    MessageBox.Show("删除手术间失败！\n请与系统管理员联系。" + Environment.TableManager.Err, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.treeView1.Nodes.Remove(this.treeView1.SelectedNode);
            }
            base.ToolStrip_ItemClicked(sender, e);
        }


        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.CurrentRoom == null)
                return;

            this.DialogRoom.IsNew = false;

            this.DialogRoom.Room = this.CurrentRoom.Clone();
            if (this.DialogRoom.ShowDialog() == DialogResult.OK)
            {
                this.CurrentRoom.Name = this.DialogRoom.Room.Name;
                e.Node.Text = this.DialogRoom.Room.Name;
                this.CurrentRoom.InputCode = this.DialogRoom.Room.InputCode;
                this.CurrentRoom.IsValid = this.DialogRoom.Room.IsValid;

            }
        }

        private void ucTableSpread1_ItemModified(object sender, EventArgs e)
        {
            if (!this.modified.Contains(this.CurrentRoom.ID))
                this.modified.Add(this.CurrentRoom.ID);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            return base.OnSave(sender, neuObject);
        }
        #endregion

    }
}
