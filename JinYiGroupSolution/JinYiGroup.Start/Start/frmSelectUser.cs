using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace HIS
{
    public partial class frmSelectUser : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmSelectUser()
        {
            InitializeComponent();
        }

        #region 变量
            //TreeNode集合,用与查找节点时使用
            private ArrayList ArrayItem = new ArrayList();
        #endregion

        #region 函数

        /// <summary>
        /// 初始化TreeView
        /// </summary>
        private void InitTree()
        {     
            TreeNode nodeParent = null;
            TreeNode node = null;
            string parentCode = "";
            try
            {
                //获取科室列表
                Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayItem = dept.GetDeptmentAllOrderByDeptType();
                if (ArrayItem == null)
                {
                    MessageBox.Show(dept.Err);
                    return;
                }
                foreach (Neusoft.HISFC.Models.Base.Department obj in ArrayItem)
                {
                    //加入父节点
                    if (obj.DeptType.ID.ToString() != parentCode)
                    {
                        nodeParent = new TreeNode();
                        nodeParent.Text = obj.DeptType.Name;
                        nodeParent.Tag = obj;
                        nodeParent.ImageIndex = 0;
                        nodeParent.SelectedImageIndex = 1;
                        this.tree.Nodes.Add(nodeParent);
                        parentCode = obj.DeptType.ID.ToString();
                    }
                    //加入子节点
                    node = new TreeNode();
                    node.Text = obj.Name;
                    node.Tag = obj;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    nodeParent.Nodes.Add(node);
                }
            }
            catch 
            {
                MessageBox.Show("加载科室信息失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 事件

        private void frmSelectUser_Load(object sender, EventArgs e)
        {
            InitTree();   
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                Neusoft.HISFC.Models.Base.Employee person = (Neusoft.HISFC.Models.Base.Employee)this.neuSpread1.ActiveSheet.ActiveRow.Tag;
                Neusoft.FrameWork.Management.Connection.Operator = person;
                if (person.PermissionGroup == null || person.PermissionGroup.Count == 0)
                { }
                else if (person.PermissionGroup.Count == 1)
                {
                    person.CurrentGroup = (Neusoft.FrameWork.Models.NeuObject)person.PermissionGroup[0];
                    frmSelectGroup f = new frmSelectGroup();
                    f.ShowDialog();
                }
                else
                {
                    frmSelectGroup f = new frmSelectGroup();
                    f.ShowDialog();
                }

                if (Program.mainForm == null)
                {
                    Program.mainForm = new frmMain();
                }
                foreach (Form f in Program.mainForm.MdiChildren)
                {
                    f.Close();
                }
                Program.mainForm.Show();
            }
            catch
            { }
        }

        private void btfind_Click(object sender, EventArgs e)
        {
            
           Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch frm = new Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch();
            frm.Init(this.tree, ArrayItem);
            frm.Show();
            
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Neusoft.HISFC.Models.Base.Department obj;
                //得到node的Tag
                obj = (Neusoft.HISFC.Models.Base.Department)e.Node.Tag;
                if (obj == null) return;
                ArrayList al = new ArrayList();

                Neusoft.HISFC.BizLogic.Manager.Person manager = new Neusoft.HISFC.BizLogic.Manager.Person();
                Neusoft.HISFC.BizLogic.Manager.UserManager manager1 = new Neusoft.HISFC.BizLogic.Manager.UserManager();
                //科室人员
                al = manager.GetEmployee(obj.ID);
                this.neuSpread1_Sheet1.Rows.Count = 0;
                //加载人员信息
                foreach (Neusoft.HISFC.Models.Base.Employee objPerson1 in al)
                {
                    Neusoft.HISFC.Models.Base.Employee objPerson = new Neusoft.HISFC.Models.Base.Employee();
                    objPerson = manager1.GetPerson(objPerson1.ID);
                    this.neuSpread1_Sheet1.Rows.Add(0, 1);
                    this.neuSpread1_Sheet1.Cells[0, 0].Text = objPerson.Name;
                    this.neuSpread1_Sheet1.Cells[0, 1].Text = objPerson.EmployeeType.Name;
                    this.neuSpread1_Sheet1.Cells[0, 2].Text = objPerson.Memo;
                    this.neuSpread1_Sheet1.Rows[0].Tag = objPerson;
                    
                    if (objPerson.PermissionGroup == null || objPerson.PermissionGroup.Count == 0)
                    {
                        this.neuSpread1_Sheet1.Rows[0].BackColor = Color.Gray;
                    }

                }
            }
            catch
            {
                MessageBox.Show("显示数据失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void neuLinkLabel1_Click(object sender, EventArgs e)
        {
            //调出查询节点窗口
           Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch frm = new Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch();
            //初始设置窗体
            frm.Init(this.tree, ArrayItem);
            frm.Show();
        }

        #endregion
    }
}