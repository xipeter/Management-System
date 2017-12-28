using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Outpatient
{
    /// <summary>
    /// [功能描述: 门诊配发药树型组件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <修改记录 
    ///		
    ///  />
    /// </summary>
    public partial class tvClinicTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvClinicTree()
        {
            InitializeComponent();

            this.ImageList = this.groupImageList;
        }

        public tvClinicTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.ImageList = this.groupImageList;
        }

        /// <summary>
        /// 本次添加数据的树节点状态
        /// </summary>
        private string state = "0";

        /// <summary>
        /// 树节点所在的TabPage
        /// </summary>
        private System.Windows.Forms.TabPage parentTab = null;

        /// <summary>
        /// 本次添加数据的树节点状态
        /// </summary>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        /// <summary>
        /// 树节点所在的TabPage
        /// </summary>
        public System.Windows.Forms.TabPage ParentTab
        {
            get
            {
                if (this.parentTab == null)
                    this.parentTab = new System.Windows.Forms.TabPage();
                return this.parentTab;
            }
            set
            {
                this.parentTab = value;
            }
        }

        /// <summary>
        /// 显示患者列表 向AddTree内增加数据
        /// </summary>
        /// <param name="alDrugRecipe">列表数组</param>
        /// <param name="isSupplemental">是否再列表内追加显示</param>
        /// <param name="isAutoShow">是否自动选中新增节点</param>
        public void ShowList(System.Windows.Forms.TreeNode rootNode,ArrayList alDrugRecipe, bool isSupplemental, bool isAutoShow)
        {
            if (!isSupplemental)
            {
                this.Nodes.Clear();
            }

            if (rootNode != null)
            {
                this.Nodes.Add(rootNode);
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe in alDrugRecipe)
            {
                System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();

                //{DF70D8FF-A1DD-421b-8E4A-4637745F1927}
                //给树节点添加键值
                node.Name = drugRecipe.RecipeNO;

                node.Text = drugRecipe.PatientName;
                node.ImageIndex = 2;
                node.SelectedImageIndex = 4;
                node.Tag = drugRecipe;
                if (rootNode != null)
                {
                    rootNode.Nodes.Add(node);
                }
                else
                {
                    this.Nodes.Add(node);
                }
            }

            if (isAutoShow)
            {
                if (this.Nodes.Count > 0)
                {
                    this.SelectedNode = this.Nodes[this.Nodes.Count - 1];
                }
            }
        }

        /// <summary>
        /// 显示患者列表 向AddTree内增加数据
        /// </summary>
        /// <param name="alDrugRecipe">列表数组</param>
        /// <param name="isSupplemental">是否再列表内追加显示</param>
        /// <param name="isAutoShow">是否自动选中新增节点</param>
        public void ShowList(ArrayList alDrugRecipe, bool isSupplemental,bool isAutoShow)
        {
            if (!isSupplemental)
            {
                this.Nodes.Clear();
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe in alDrugRecipe)
            {
                System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();

                //{DF70D8FF-A1DD-421b-8E4A-4637745F1927}
                //给树节点添加键值
                node.Name = drugRecipe.RecipeNO;

                node.Text = drugRecipe.PatientName;
                node.ImageIndex = 2;
                node.SelectedImageIndex = 4;
                node.Tag = drugRecipe;
                this.Nodes.Add(node);
            }

            if (isAutoShow)
            {
                if (this.Nodes.Count > 0)
                {
                    this.SelectedNode = this.Nodes[this.Nodes.Count - 1];
                }
            }
        }

         /// <summary>
        /// 显示患者列表 向AddTree内增加数据
        /// </summary>
        /// <param name="alDrugRecipe">列表数组</param>
        /// <param name="isSupplemental">是否再列表内追加显示</param>
        public void ShowList(ArrayList alDrugRecipe, bool isSupplemental)
        {
            this.ShowList(alDrugRecipe, isSupplemental, false);
        }

        /// <summary>
        /// 节点选择移动
        /// </summary>
        /// <param name="isDown">是否向下移动</param>
        public void SelectNext(bool isDown)
        {
            if (this.Nodes.Count <= 0)
                return;
            if (this.SelectedNode == null)
            {
                this.SelectedNode = this.Nodes[0];
                return;
            }
            int iIndex = this.SelectedNode.Index;
            if (isDown)
            {
                if (iIndex == this.Nodes.Count - 1)
                {
                    this.SelectedNode = this.Nodes[0];
                }
                else
                {
                    this.SelectedNode = this.Nodes[iIndex + 1];
                }
            }
            else
            {
                if (iIndex == 0)
                {
                    this.SelectedNode = this.Nodes[this.Nodes.Count - 1];
                }
                else
                {
                    this.SelectedNode = this.Nodes[iIndex - 1];
                }
            }
        }
    }
}
