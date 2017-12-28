using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucDeptTemplet : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDeptTemplet()
        {
            InitializeComponent();

            this.Load += new EventHandler(ucTempletForm_Load);
            this.treeView1.BeforeSelect += new TreeViewCancelEventHandler(treeView1_BeforeSelect);
            this.treeView1.AfterSelect  += new TreeViewEventHandler(treeView1_AfterSelect);

            this.tabControl1.Deselecting += new TabControlCancelEventHandler(tabControl1_SelectionChanging);
            this.tabControl1.Selected += new TabControlEventHandler(tabControl1_SelectionChanged);
            
            this.cmbDept.SelectedIndexChanged += new EventHandler(cmbDept_SelectedIndexChanged);
            this.cmbDept.KeyDown += new KeyEventHandler(cmbDept_KeyDown);
        }

        #region 变量
        /// <summary>
        /// 排班控件数组,方便操作
        /// </summary>
        protected Registration.ucSchemaTemplet[] controls;
        /// <summary>
        /// 排班模板类别
        /// </summary>
        protected Neusoft.HISFC.Models.Base.EnumSchemaType SchemaType;
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 事件
        private void ucTempletForm_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag.ToString() == "" || this.Tag.ToString().ToUpper() == "DEPT")
            {
                this.SchemaType = Neusoft.HISFC.Models.Base.EnumSchemaType.Dept;
                this.Text = "专科排班模板维护";
                //this.tbFind.Visible = false;
            }
            else
            {
                this.SchemaType = Neusoft.HISFC.Models.Base.EnumSchemaType.Doct;
                this.Text = "专家排班模板维护";
            }

            this.InitArray();

            this.InitControls();

            this.InitDept();

            this.treeView1_AfterSelect(new object(), new System.Windows.Forms.TreeViewEventArgs(new TreeNode(), System.Windows.Forms.TreeViewAction.Unknown));
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            int Index = this.tabControl1.SelectedIndex;
            Index++;

            if (Index == 7) Index = 0;

            if (controls[Index].IsChange())
            {
                if (MessageBox.Show("数据已经改变,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (controls[Index].Save() == -1)
                    {
                        e.Cancel = true;
                        controls[Index].Focus();
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;

            if (node == null) return;

            string deptID;
            Neusoft.HISFC.Models.Base.Department dept = null;

            if (node.Parent == null)//父节点
            {
                deptID = "ALL";
            }
            else
            {
                dept = (Neusoft.HISFC.Models.Base.Department)node.Tag;
                deptID = dept.ID;
            }

            int Index = this.tabControl1.SelectedIndex;

            Index++;

            if (Index == 7) Index = 0;

            controls[Index].Dept = dept;
            controls[Index].Query(deptID);

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            //{
            //    this.Del();
            //    return true;
            //}
            //else if (keyData == Keys.Add || keyData == Keys.Oemplus)
            //{
            //    this.Add();
            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            //{
            //    this.Save();
            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            //{
            //    this.FindForm().Close();
            //}
            if (keyData == Keys.F1)
            {
                this.cmbDept.Focus();
                return true;
            }
            //else if (keyData == Keys.F3)
            //{
            //    this.Find();
            //    return true;
            //}

            return base.ProcessDialogKey(keyData);
        }

        private void tabControl1_SelectionChanging(object sender, EventArgs e)
        {
            int Index = this.tabControl1.SelectedIndex;
            int TabIndex = Index;

            Index++;

            if (Index == 7) Index = 0;

            if (controls[Index].IsChange())
            {
                if (MessageBox.Show("数据已经修改,是否保存变动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (controls[Index].Save() == -1)
                    {
                        //this.tabControl1.SelectedIndex = TabIndex ;
                        return;
                    }
                }
            }
        }

        private void tabControl1_SelectionChanged(object sender, EventArgs e)
        {
            object obj = this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Tag;

            if (obj == null || obj.ToString() == "")
            {
                this.treeView1.SelectedNode = this.treeView1.Nodes[0];
                this.treeView1_AfterSelect(new object(), new System.Windows.Forms.TreeViewEventArgs(new TreeNode(), System.Windows.Forms.TreeViewAction.Unknown));
                this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Tag = "Has Retrieve";
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.treeView1.Nodes[0].Nodes)
            {
                if ((node.Tag as Neusoft.HISFC.Models.Base.Department).ID == this.cmbDept.Tag.ToString())
                {
                    this.treeView1.SelectedNode = node;
                    break;
                }
            }
        }

        private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Index = this.tabControl1.SelectedIndex;

                if (Index == 6)
                {
                    Index = 0;
                }
                else
                {
                    Index = Index + 1;
                }

                controls[Index].Focus();
            }
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("增加", "",(int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolBarService.AddToolButton("删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            this.toolBarService.AddToolButton("全部删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);

            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.Add();
                    break;
                case "删除":
                    this.Del();
                    break;
                case "全部删除":
                    this.DelAll();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return 0;
        }
        #endregion

        #region 函数
        /// <summary>
        /// 初始化数组
        /// </summary>
        private void InitArray()
        {
            controls = new Registration.ucSchemaTemplet[7];
            controls[0] = this.ucSchemaTemplet7;
            controls[1] = this.ucSchemaTemplet1;
            controls[2] = this.ucSchemaTemplet2;
            controls[3] = this.ucSchemaTemplet3;
            controls[4] = this.ucSchemaTemplet4;
            controls[5] = this.ucSchemaTemplet5;
            controls[6] = this.ucSchemaTemplet6;
        }

        /// <summary>
        /// 初始化模板控间
        /// </summary>
        private void InitControls()
        {
            Registration.ucSchemaTemplet obj;

            for (int i = 0; i < 7; i++)
            {
                obj = controls[i];
                obj.Init((DayOfWeek)i, this.SchemaType);
            }
        }

        /// <summary>
        /// 生成门诊科室树
        /// </summary>
        private void InitDept()
        {
            this.treeView1.Nodes.Clear();
            TreeNode parent = new TreeNode("出诊科室");
            this.treeView1.ImageList = this.treeView1.deptImageList;
            parent.ImageIndex = 5;
            parent.SelectedImageIndex = 5;
            this.treeView1.Nodes.Add(parent);

            Neusoft.HISFC.BizProcess.Integrate.Manager Mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            ArrayList al = Mgr.QueryRegDepartment();
            if (al == null)
            {
                MessageBox.Show("获取科室列表时出错!" + Mgr.Err, "提示");
                return;
            }

            foreach (Neusoft.HISFC.Models.Base.Department dept in al)
            {
                TreeNode node = new TreeNode();
                node.Text = dept.Name;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 1;
                node.Tag = dept;

                parent.Nodes.Add(node);
            }

            this.cmbDept.AddItems(al);
            parent.ExpandAll();
        }



        //private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        //{
        //    if (e.Button == this.tbAdd)
        //    {
        //        this.Add();
        //    }
        //    else if (e.Button == this.tbDel)
        //    {
        //        this.Del();
        //    }
        //    else if (e.Button == this.tbSave)
        //    {
        //        this.Save();
        //    }
        //    else if (e.Button == this.tbExit)
        //    {
        //        this.Close();
        //    }
        //    else if (e.Button == this.tbDelAll)
        //    {
        //        this.DelAll();
        //    }
        //    else if (e.Button == this.tbFind)
        //    {
        //        this.Find();
        //    }
        //}
        /// <summary>
        /// 增加
        /// </summary>
        private void Add()
        {
            int Index = this.tabControl1.SelectedIndex;

            if (Index == 6)
            {
                Index = 0;
            }
            else
            {
                Index = Index + 1;
            }

            controls[Index].Add();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            int Index = this.tabControl1.SelectedIndex;

            if (Index == 6)
            {
                Index = 0;
            }
            else
            {
                Index = Index + 1;
            }

            controls[Index].Del();
        }

        /// <summary>
        /// 删除全部
        /// </summary>
        private void DelAll()
        {
            int Index = this.tabControl1.SelectedIndex;

            if (Index == 6)
            {
                Index = 0;
            }
            else
            {
                Index = Index + 1;
            }

            controls[Index].DelAll();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            int Index = this.tabControl1.SelectedIndex;

            if (Index == 6)
            {
                Index = 0;
            }
            else
            {
                Index = Index + 1;
            }

            if (controls[Index].Save() == -1)
            {
                controls[Index].Focus();
                return;
            }

            MessageBox.Show("保存成功!", "提示");

            controls[Index].Focus();
        }

        /// <summary>
        /// 搜索人员
        /// </summary>
        private void Find()
        {
            int Index = this.tabControl1.SelectedIndex;

            if (Index == 6)
            {
                Index = 0;
            }
            else
            {
                Index = Index + 1;
            }

            this.cmbDept.Focus();

            //frmFindEmployee f = new frmFindEmployee();
            //f.SelectedEmployee = controls[Index].SearchEmployee;

            //if (f.ShowDialog() == DialogResult.Yes)
            //{
            //    controls[Index].Focus();
            //    controls[Index].SearchEmployee = f.SelectedEmployee;
            //    f.Dispose();
            //}
        }
        #endregion

    }
}
