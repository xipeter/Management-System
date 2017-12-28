using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Material.Check
{
    public partial class tvCheckList : Neusoft.FrameWork.WinForms.Controls.NeuTreeView
    {
        public tvCheckList()
        {
            InitializeComponent();
        }

        public tvCheckList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        ///显示盘点单列表
        /// </summary>
        public void ShowCheckList(Neusoft.FrameWork.Models.NeuObject checkDept, string checkState, Neusoft.FrameWork.Models.NeuObject checkOper)
        {
            //清空列表
            this.Nodes.Clear();

            this.privDept = checkDept;

            Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

            //当前忽略对封帐人的判断，检索显示全部封帐盘点单            
            try
            {
                ArrayList checkList = new ArrayList();
                checkList = itemManager.QueryCheckStatic(checkDept.ID, checkState);
                if (checkList == null)
                {
                    System.Windows.Forms.MessageBox.Show(Language.Msg(itemManager.Err));
                    return;
                }
                if (checkList.Count == 0)
                {
                    this.Nodes.Add(new System.Windows.Forms.TreeNode("没有封帐盘点单", 0, 0));
                }
                else
                {
                    this.Nodes.Add(new System.Windows.Forms.TreeNode("封帐盘点单列表", 0, 0));
                    //显示盘点单列表
                    System.Windows.Forms.TreeNode newNode;
                    foreach (Neusoft.HISFC.Models.Material.Check check in checkList)
                    {
                        newNode = new System.Windows.Forms.TreeNode();

                        //获得封帐人员姓名
                        Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                        Neusoft.HISFC.Models.Base.Employee employee = personManager.GetPersonByID(check.FOper.ID);
                        if (employee == null)
                        {
                            System.Windows.Forms.MessageBox.Show(Language.Msg("获得封帐人员信息时出错！人员编码为" + check.FOper.ID + "的人员不存在"));
                            return;
                        }
                        check.FOper.Name = employee.Name;

                        if (check.CheckName == "")
                            newNode.Text = check.CheckCode + "-" + check.FOper.Name;		    //盘点单号+封帐人
                        else
                            newNode.Text = check.CheckName;

                        newNode.ImageIndex = 4;
                        newNode.SelectedImageIndex = 5;

                        newNode.Tag = check;

                        this.Nodes[0].Nodes.Add(newNode);
                    }
                    this.Nodes[0].ExpandAll();

                    this.SelectedNode = this.Nodes[0];
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg(ex.Message));
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            System.Windows.Forms.TreeNode node = this.GetNodeAt(e.X, e.Y);

            if (node != null)
            {
                System.Windows.Forms.ContextMenu popMenu = new System.Windows.Forms.ContextMenu();

                System.Windows.Forms.MenuItem reNameMenu = new System.Windows.Forms.MenuItem("修改名称");
                reNameMenu.Click += new EventHandler(reNameMenu_Click);

                popMenu.MenuItems.Add(reNameMenu);

                this.ContextMenu = popMenu;

                this.SelectedNode = node;
            }

            base.OnMouseDown(e);
        }

        private void reNameMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null && this.SelectedNode.Parent != null)
            {
                this.LabelEdit = true;
                if (!this.SelectedNode.IsEditing)
                    this.SelectedNode.BeginEdit();
            }
        }

        protected override void OnAfterLabelEdit(System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        e.CancelEdit = true;
                        System.Windows.Forms.MessageBox.Show(Language.Msg("存在无效字符!请重新命名"));
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    System.Windows.Forms.MessageBox.Show(Language.Msg("模板名称不能为空"));
                    e.Node.BeginEdit();
                }

                Neusoft.HISFC.Models.Material.Check check = e.Node.Tag as Neusoft.HISFC.Models.Material.Check;

                //Neusoft.HISFC.BizLogic.Material.Store itemManager = new Neusoft.HISFC.BizLogic.Material.Store();

                //check.CheckName = e.Label;

                //if (check.CheckNO != "")
                //{
                //    if (itemManager.UpdateCheckListName(this.privDept.ID, check.CheckNO, e.Label) == -1)
                //    {
                //        System.Windows.Forms.MessageBox.Show(Language.Msg("更新盘点统计信息中盘点单名称出错"));
                //        return;
                //    }
                //}
            }

            base.OnAfterLabelEdit(e);
        }
    }
}
