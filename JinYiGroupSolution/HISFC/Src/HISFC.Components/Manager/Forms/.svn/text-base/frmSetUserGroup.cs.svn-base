using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Forms
{
    public partial class frmSetUserGroup : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public delegate bool CheckLogNameHandler(string logName,ref string err);
        public event CheckLogNameHandler CheckLogName;
        public frmSetUserGroup(Neusoft.HISFC.Models.Base.Employee obj)
        {
            InitializeComponent();
            this.employee = obj.Clone();
            this.getPerson();
            if (obj.ID == "")
            {
                this.UpdateOrAdd = "A";
                this.lblEmployee.Visible = true;
            }
            else
            {
                this.UpdateOrAdd = "U";
                this.lblEmployee.Visible = false;
            }
            this.employee = obj;
            try
            {
                Neusoft.HISFC.BizLogic.Manager.Person managerPerson = new Neusoft.HISFC.BizLogic.Manager.Person();
                form = new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose(managerPerson.GetUserEmployeeAll());
                form.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(form_SelectedItem);

                this.tvGroup1.DoubleClick += new EventHandler(this.treeView_DoubleClick);               
                this.lsvGroup.DoubleClick += new EventHandler(listView1_DoubleClick);
                this.RefreshGroupList();
                this.tvGroup1.Visible = true;
            }
            catch { }
        }

        #region 变量
        protected Neusoft.HISFC.Models.Base.Employee employee = null;

        #endregion
        
        #region 函数

        protected virtual void getPerson()
        {
            Neusoft.HISFC.BizLogic.Manager.UserManager manager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
            this.txtLoginID.Text = employee.User01;
            this.txtName.Text = employee.Name;
            this.chkManager.Checked = employee.IsManager;
            ArrayList al = manager.GetPersonGroupList(this.employee.ID);
            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }
            this.lsvGroup.Items.Clear();
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                myAddListView(obj, 2);
            }
        }

        private void myAddListView(Neusoft.FrameWork.Models.NeuObject obj, int imageindex)
        {

            ListViewItem item = new ListViewItem(obj.Name, imageindex);
            item.Text = obj.Name;
            item.Tag = obj;
            this.lsvGroup.Items.Add(item);

        }
        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        private bool ValidateValue()
        {

            if (this.txtLoginID.Text.Trim() == "")
            {
                MessageBox.Show("登录名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("姓名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.txtLoginID.Text != this.employee.User01 || this.chkPWD.Checked) this.employee.Password = "-";

            this.employee.User01 = this.txtLoginID.Text;
            this.employee.Name = this.txtName.Text;
            this.employee.IsManager = this.chkManager.Checked;
            //验证登陆名是否存在
            if (this.CheckLogName != null)
            {
                string logName = this.txtLoginID.Text.Trim();
                string error = string.Empty;
                if (!this.CheckLogName(logName, ref error))
                {
                    MessageBox.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }


        private bool Save()
        {
            if (ValidateValue())
            {
                if (!LoginNameVal())
                {
                    return false;
                }

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Neusoft.HISFC.BizLogic.Manager.UserManager manager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
                //t.BeginTransaction();
                //manager.SetTrans(t.Trans);
                int returnValue = manager.UpdatePersonGroup(this.employee);
                if (returnValue >0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    return true;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (returnValue == 0)
                    {
                        MessageBox.Show("请为人员选择所属组");
                    }
                    else
                    {
                        MessageBox.Show("请选择权限组!\n数据保存失败！" + manager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return false;
                }
            }

            return false;
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        private void RefreshGroupList()
        {
            Neusoft.HISFC.BizLogic.Manager.SysGroup sysGroupManager = new Neusoft.HISFC.BizLogic.Manager.SysGroup();
            
            //{1D7BC020-92AC-431b-B27B-1BFBEB0E566B} 根据操作员是否为管理员权限 决定SysGroup列表显示
            Neusoft.HISFC.Models.Base.Employee person = (Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator;
            ArrayList al = new ArrayList();
            if (person.IsManager)
            {
                al = sysGroupManager.GetList();

                this.chkManager.Visible = true;
                this.chkPWD.Visible = true;
                this.lblEmployee.Visible = true;
                this.txtLoginID.Enabled = true;
            }
            else
            {
                al = person.PermissionGroup;

                this.txtLoginID.Enabled = false;
                this.chkManager.Visible = false;
                this.chkPWD.Visible = false;
                this.lblEmployee.Visible = false;
            }

            this.tvGroup1.Nodes[0].Nodes.Clear();
            foreach (Neusoft.HISFC.Models.Admin.SysGroup obj in al)
            {
                TreeNode node = new TreeNode(obj.Name);
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
                node.Tag = obj;
                this.tvGroup1.Nodes[0].Nodes.Add(node);
            }
            foreach (TreeNode node in this.tvGroup1.Nodes[0].Nodes)
            {
                TreeNode pNode = null;
                SearchParentNode(this.tvGroup1.Nodes[0], node.Tag, ref pNode);
                if (pNode != null)
                {
                    node.Parent.Nodes.Remove(node);
                    pNode.Nodes.Add(node);
                }
            }
            this.tvGroup1.ExpandAll();
        }
        private void SearchParentNode(TreeNode rootNode, object obj, ref TreeNode rtnNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                Neusoft.HISFC.Models.Admin.SysGroup o = node.Tag as Neusoft.HISFC.Models.Admin.SysGroup;

                this.SearchParentNode(node, obj, ref rtnNode);

                if (o != null)
                {
                    try
                    {
                        if (o.ID == ((Neusoft.HISFC.Models.Admin.SysGroup)obj).ParentGroup.ID)
                        {
                            rtnNode = node;
                        }
                    }
                    catch { }
                }
            }
        }
        string UpdateOrAdd = "";
        private bool LoginNameVal()
        {
            Neusoft.HISFC.BizLogic.Manager.UserManager us = new Neusoft.HISFC.BizLogic.Manager.UserManager();
            int temp = us.IsExistLoginName(this.txtLoginID.Text, employee.ID);
            if (UpdateOrAdd == "A") //新增加的用户
            {
                if (temp == 1)
                {
                    MessageBox.Show("此登陆名已经存在，请更换 。");
                    this.txtLoginID.Focus();
                    return false;
                }
                else if (temp == -1)
                {
                    MessageBox.Show("查找SQL出错：" + us.Err);
                    return false;
                }

            }
            else if (UpdateOrAdd == "U") //  修改现有人员
            {
                if (employee.User01 != this.txtLoginID.Text) //名字已经修改了
                {
                    if (temp == 1)
                    {
                        MessageBox.Show("此登陆名已经存在，请更换 。");
                        this.txtLoginID.Focus();
                        return false;
                    }
                    else if (temp == -1)
                    {
                        MessageBox.Show("查找SQL出错：" + us.Err);
                        return false;
                    }

                }
            }
            return true;
        }
        #endregion

        #region 事件

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            this.FindForm().DialogResult = DialogResult.Cancel;
            this.FindForm().Close();

        }

       

        private void treeView_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.tvGroup1.SelectedNode.Tag != null)
            {
                if (ValidateValue() == false) return;
                Neusoft.FrameWork.Models.NeuObject o = this.tvGroup1.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                //修改人：路志鹏
                //修改时间：2007-4-11
                //目的：不选择跟节点，如果是跟节点（系统组），则return
                if (o.ID == "ROOT") return;

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Neusoft.HISFC.BizLogic.Manager.UserManager manager = new Neusoft.HISFC.BizLogic.Manager.UserManager();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
                //t.BeginTransaction();
                //manager.SetTrans(t.Trans);

                #region  Edit By liangjz 2005-10 根据员工是否已设置过密码设置默认密码
                ArrayList al = manager.GetLoginInfoByEmplCode(this.employee.ID);
                if (al == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(manager.Err);
                    return;
                }
                Neusoft.FrameWork.Models.NeuObject info = al[0] as Neusoft.FrameWork.Models.NeuObject;
                if (info == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("获取员工登陆信息出错 发生类型转换错误");
                    return;
                }
                //取患者以前的密码,插入一条新记录.
                if (info.User02 == "" || info.User02 == null)
                    //如果是新人员,则用默认密码0(加密后为-)
                    this.employee.Password = "-";
                else
                    //如果患者已有登陆信息,则取以前的密码
                    this.employee.Password = info.User02;
                #endregion
                if (manager.InsertPersonGroup(this.employee, o) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("已经添加该组!");
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();;
                    myAddListView(o, 2);
                }
            }

        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.lsvGroup.SelectedItems.Count <= 0) return;

            if (MessageBox.Show("确实要删除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Neusoft.HISFC.BizLogic.Manager.UserManager manager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
                //t.BeginTransaction();
                //manager.SetTrans(t.Trans);
                if (manager.DeletePersonGroup(this.employee, (Neusoft.FrameWork.Models.NeuObject)this.lsvGroup.SelectedItems[0].Tag) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(manager.Err);
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();;
                    this.lsvGroup.Items.Remove(this.lsvGroup.SelectedItems[0]);
                }
            }

        }
        Neusoft.FrameWork.WinForms.Forms.frmEasyChoose form = null;

       

        private void form_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            try
            {
                Neusoft.HISFC.Models.Base.Employee p = sender as Neusoft.HISFC.Models.Base.Employee;
                if (p != null)
                {
                    this.employee = p;
                    Neusoft.HISFC.BizLogic.Manager.Spell sm = new Neusoft.HISFC.BizLogic.Manager.Spell();
                    if (this.txtLoginID.Text == "")
                    {
                        if (p.ID != "")
                            this.txtLoginID.Text = p.ID;
                        else
                            this.txtLoginID.Text = sm.Get(p.Name).SpellCode;
                    }
                    this.txtName.Text = p.Name;
                    this.employee.User01 = this.txtLoginID.Text;
                }
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.FindForm().DialogResult = DialogResult.OK;

                this.FindForm().Close();
            }
        }

        private void lblEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form.ShowDialog();
        }
#endregion
    }
}