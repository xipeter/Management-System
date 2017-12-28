using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.EPR.QC
{
    /// <summary>
    /// 设置质控条件控件
    /// 潘铁俊于2008-4-1创建
    /// </summary>
    public partial class ucQCSetting : UserControl
    {
        public ucQCSetting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="alQCConditions">所有质控条件</param>
        /// <param name="alPreSelectedCondition">以前选择的质控条件</param>
        /// <param name="alSelectedCondition">重新选择后的质控条件</param>
        public ucQCSetting(ArrayList alQCConditions,ArrayList alPreSelectedCondition,ref ArrayList alSelectedCondition)
        {
            InitializeComponent();
            this.alPreSelectedCondtion = alPreSelectedCondition;
            this.alQCConditions = alQCConditions;
            alSelectedCondition = this.alSelectedCondition;
            this.init();
        }
        /// <summary>
        /// 质控条件
        /// </summary>
        private ArrayList alQCConditions;
        /// <summary>
        /// 是否有查询到的节点
        /// </summary>
        private bool hasNode = false;
        /// <summary>
        /// 当前查找的索引
        /// </summary>
        private int currentIndex = 0;
        /// <summary>
        /// 提示F3可以重复前面的查找
        /// </summary>
        private ToolTip tt = new ToolTip();
        /// <summary>
        /// 选择的条件
        /// </summary>
        private ArrayList alSelectedCondition = new ArrayList();
        /// <summary>
        /// 此次选择前以选择的条件
        /// </summary>
        private ArrayList alPreSelectedCondtion;
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            this.tt.SetToolTip(this.neuTbSearch,"按【F3】可以重复前面的查找");
            ArrayList alSelectedConditionNames = new ArrayList();
            bool hasPreCondition = (this.alPreSelectedCondtion != null);
            if (hasPreCondition && this.alPreSelectedCondtion.Count>0)
            {
                for(int i=0;i<this.alPreSelectedCondtion.Count;i++){
                    alSelectedConditionNames.Add(this.alPreSelectedCondtion[i].ToString());
                }
            }
            if (this.alQCConditions != null)
            {
                for (int i = 0; i < this.alQCConditions.Count; i++)
                {
                    TreeNode node = new TreeNode(this.alQCConditions[i].ToString());
                    node.Text = this.alQCConditions[i].ToString();
                    node.Tag = this.alQCConditions[i];

                    node.Checked = alSelectedConditionNames.Contains(this.alQCConditions[i].ToString());
                    
                    this.neuTVSetting.Nodes.Add(node);
                }
            }
        }
        /// <summary>
        /// 回车转换焦点
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {

                if (this.neuTbSearch.Focused)
                {
                    if (!string.IsNullOrEmpty(this.neuTbSearch.Text))
                    {
                        this.currentIndex = 0;
                        this.hasNode = false;
                        if (this.neuTVSetting.Nodes.Count > 0)
                        {
                            this.LocateCondition();
                        }
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("查询值不能为空！");
                        this.neuTbSearch.Focus();
                        return false;
                    }
                }
                SendKeys.Send("{TAB}");
                return true;
            }
            if (keyData == Keys.F1)
            {
                this.neuTbSearch.Focus();
                return true;
            }
            if (keyData == Keys.F3)
            {
                if (string.IsNullOrEmpty(this.neuTbSearch.Text))
                {
                    MessageBox.Show("查询值不能为空！");
                    this.neuTbSearch.Focus();
                    return false;
                }
                if (this.currentIndex + 1 >= this.neuTVSetting.Nodes.Count)
                {
                    this.currentIndex = 0;
                }
                this.currentIndex++;
                this.LocateCondition();
            }
            return base.ProcessDialogKey(keyData);

        }
        /// <summary>
        /// 根据名称查找条件
        /// </summary>
        /// <param name="ruleName"></param>
        private void LocateCondition()
        {
            if (this.neuTVSetting.Nodes.Count>0)
            {
                for (; this.currentIndex < this.neuTVSetting.Nodes.Count; this.currentIndex++)
                {
                    if (this.neuTVSetting.Nodes[this.currentIndex].Text.IndexOf(this.neuTbSearch.Text) != -1)
                    {
                        this.neuTVSetting.SelectedNode = this.neuTVSetting.Nodes[this.currentIndex];
                        this.hasNode = true;
                        break;
                    }
                    else
                    {
                        if (this.hasNode && this.currentIndex + 1 >= neuTVSetting.Nodes.Count)
                        {
                            this.currentIndex = 0;
                            continue;
                        }
                    }
                }
                if (!this.hasNode)
                {
                    MessageBox.Show("没有找到要搜索的节点！");
                }
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuBtCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().DialogResult = DialogResult.Cancel;
            this.FindForm().Close();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuBtOk_Click(object sender, EventArgs e)
        {
            this.alSelectedCondition.Clear();
            foreach (TreeNode node in this.neuTVSetting.Nodes)
            {
                if (node.Checked)
                {
                    this.alSelectedCondition.Add(node.Tag);
                }
            }
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }
        /// <summary>
        /// 全部选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuCbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool setChecked = this.neuCbSelectAll.Checked;
            foreach (TreeNode node in this.neuTVSetting.Nodes)
            {
                node.Checked = setChecked;
            }
        }

        private void neuBtRevSelect_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.neuTVSetting.Nodes)
            {
                node.Checked = !node.Checked;
            }
        }
    }
}
