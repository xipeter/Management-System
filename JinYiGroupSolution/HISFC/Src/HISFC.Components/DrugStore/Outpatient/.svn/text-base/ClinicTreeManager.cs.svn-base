using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.UFC.DrugStore.Outpatient
{
    class ClinicTreeManager
    {
        /// <summary>
        /// 树管理类初始化
        /// </summary>
        /// <param name="addTree">数据添加树 向该树内添加节点</param>
        /// <param name="operTree">数据操作树 对该树内数据进行操作</param>
        /// <param name="nextTree">数据后继树 数据操作后移动目的树</param>
        /// <param name="funMode">功能模块类型</param>
        /// <param name="operDateState">数据添加树节点数据状态</param>
        internal ClinicTreeManager(TabPage addTab,TreeView addTree,TabPage operTab,TreeView operTree,TabPage nextTab,TreeView nextTree)
        {
            this.AddTab = addTab;
            this.AddTree = addTree;

            this.OperTab = operTab;
            this.OperTree = operTree;

            this.NextTab = nextTab;
            this.NextTree = nextTree;

            Neusoft.NFC.Management.DataBaseManger dataBaseManager = new Neusoft.NFC.Management.DataBaseManger();
            this.minQueryDate = dataBaseManager.GetDateTimeFromSysDateTime().Date;
        }

        #region 变量

        /// <summary>
        /// 添加TabPage页
        /// </summary>
        private TabPage AddTab = null;

        /// <summary>
        /// 数据添加树
        /// </summary>
        private TreeView AddTree = null;

        /// <summary>
        /// 操作TabPage
        /// </summary>
        private TabPage OperTab = null;        

        /// <summary>
        /// 数据操作树
        /// </summary>
        private TreeView OperTree = null;

        /// <summary>
        /// 后继TabPage
        /// </summary>
        private TabPage NextTab = null;

        /// <summary>
        /// 数据后继树
        /// </summary>
        private TreeView NextTree = null;

        /// <summary>
        /// 功能模块类型
        /// </summary>
        private OutpatientFun funMode = OutpatientFun.Drug;

        /// <summary>
        /// 自身操作树节点数据状态
        /// </summary>
        private string operDataState = "0";

        /// <summary>
        /// 查询时检索的时间下限
        /// </summary>
        private DateTime minQueryDate = System.DateTime.MinValue;

        #endregion

        #region 属性

        /// <summary>
        /// 列表节点
        /// </summary>
        public int NodeCount
        {
            get
            {
                return this.AddTree.Nodes.Count;
            }
        }

        /// <summary>
        /// 自身操作树节点类型
        /// </summary>
        public string OperDataState
        {
            get
            {
                return this.operDataState;
            }
        }

        /// <summary>
        /// 查询时检索的时间下限
        /// </summary>
        public DateTime MinQueryDate
        {
            get
            {
                if (this.funMode != null && this.funMode == OutpatientFun.Send)
                    return this.minQueryDate.AddSeconds(1);
                else
                    return this.minQueryDate;
            }
        }

        #endregion

        /// <summary>
        /// 获取传入的处方调剂数组内最大配药时间
        /// </summary>
        /// <param name="drugRecipeAl">处方调剂数组</param>
        private void GetMinDrugedDate(ArrayList drugRecipeAl)
        {
            if (this.funMode == OutpatientFun.Drug || this.funMode == OutpatientFun.Back)
                return;

            if (drugRecipeAl.Count <= 0)
                return;

            this.minQueryDate = System.DateTime.MinValue;
            foreach (Neusoft.HISFC.Object.Pharmacy.DrugRecipe info in drugRecipeAl)
            {
                if (info.DrugedOper.OperTime > this.minQueryDate)
                {
                    this.minQueryDate = info.DrugedOper.OperTime;
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
            if (this.AddTree == null)
                return;

            if (!isSupplemental)
                this.AddTree.Nodes.Clear();

            this.GetMinDrugedDate(alDrugRecipe);

            foreach (Neusoft.HISFC.Object.Pharmacy.DrugRecipe drugRecipe in alDrugRecipe)
            {
                TreeNode node = new TreeNode();
                node.Text = drugRecipe.PatientName;
                node.ImageIndex = 3;
                node.SelectedImageIndex = 4;
                node.Tag = drugRecipe;
                this.AddTree.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 树节点位置转换 将AddTree内节点转移到NextTree
        /// </summary>
        public void ChangeNode()
        {
            if (this.AddTree == null)
                return;

            TreeNode tempNode = this.AddTree.SelectedNode;
            if (tempNode != null)
            {
                this.AddTree.Nodes.Remove(tempNode);
                if (this.NextTree != null)
                    this.NextTree.Nodes.Add(tempNode);
            }
        }

        /// <summary>
        /// 删除 由OperTree内删除节点
        /// </summary>
        public void DelNode()
        {
            if (this.OperTree == null)
                return;

            TreeNode tempNode = this.OperTree.SelectedNode;
            if (tempNode != null)
            {
                this.OperTree.Nodes.Remove(tempNode);              
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            this.AddTree.Nodes.Clear();
            this.NextTree.Nodes.Clear();
            this.OperTree.Nodes.Clear();
        }

        /// <summary>
        /// 节点选择移动
        /// </summary>
        /// <param name="isDown">是否向下移动</param>
        public void SelectNextNode(bool isDown)
        {
           
        }

    }
}
