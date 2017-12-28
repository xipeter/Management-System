using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Check
{
    /// <summary>
    /// [功能描述: 药品盘点列表控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class tvCheckList : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvCheckList()
        {
            InitializeComponent();

            this.ImageList = this.deptImageList;
        }

        public tvCheckList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.ImageList = this.deptImageList;
        }       

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();        

        /// <summary>
        ///显示盘点单列表
        /// </summary>
        public void ShowCheckList(Neusoft.FrameWork.Models.NeuObject checkDept,string checkState,Neusoft.FrameWork.Models.NeuObject checkOper)
        {
            //清空列表
            this.Nodes.Clear();

            this.privDept = checkDept;

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            //增加对盘点单状态为“取消”，“结存”的盘点单的显示处理{DCE7937E-C36F-4d9a-B706-4E80F93BFC8B}sel
            string strCheckState = "封帐";
            switch (checkState)
            {
                case "0": strCheckState = "封帐"; break;
                case "1": strCheckState = "结存"; break;
                case "2": strCheckState = "取消"; break;
                default: strCheckState = "封帐";  break;
            }

            //当前忽略对封帐人的判断，检索显示全部封帐盘点单            
            try
            {
                List<Neusoft.HISFC.Models.Pharmacy.Check> checkList = new List<Neusoft.HISFC.Models.Pharmacy.Check>();
                checkList = itemManager.QueryCheckList(checkDept.ID,checkState,checkOper.ID);
                if (checkList == null)
                {
                    System.Windows.Forms.MessageBox.Show(Language.Msg(itemManager.Err));
                    return;
                }
                if (checkList.Count == 0)
                {
                    this.Nodes.Add(new System.Windows.Forms.TreeNode("没有" + strCheckState + "盘点单", 0, 0));//{DCE7937E-C36F-4d9a-B706-4E80F93BFC8B}
                }
                else
                {
                    this.Nodes.Add(new System.Windows.Forms.TreeNode(strCheckState + "盘点单列表", 0, 0));//{DCE7937E-C36F-4d9a-B706-4E80F93BFC8B}
                    //显示盘点单列表
                    System.Windows.Forms.TreeNode newNode;
                    foreach (Neusoft.HISFC.Models.Pharmacy.Check check in checkList)
                    {
                        newNode = new System.Windows.Forms.TreeNode();

                        //获得封帐人员姓名
                        Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                        Neusoft.HISFC.Models.Base.Employee employee = personManager.GetPersonByID(check.FOper.ID);
                        if (employee == null)
                        {
                            System.Windows.Forms.MessageBox.Show(Language.Msg("获得" + strCheckState + "人员信息时出错！人员编码为" + check.FOper.ID + "的人员不存在"));//{DCE7937E-C36F-4d9a-B706-4E80F93BFC8B}
                            return;
                        }
                        check.FOper.Name = employee.Name;

                        if (check.CheckName == "")
                            newNode.Text = check.CheckNO + "-" + check.FOper.Name;		    //盘点单号+封帐人
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
                        
                Neusoft.HISFC.Models.Pharmacy.Check check = e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.Check;

                Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

                check.CheckName = e.Label; 

                if (check.CheckNO != "")
                {
                    if (itemManager.UpdateCheckListName(this.privDept.ID,check.CheckNO,e.Label) == -1)
                    {
                        System.Windows.Forms.MessageBox.Show(Language.Msg("更新盘点统计信息中盘点单名称出错"));
                        return;
                    }
                }
            }

            base.OnAfterLabelEdit(e);
        }
    }
}
