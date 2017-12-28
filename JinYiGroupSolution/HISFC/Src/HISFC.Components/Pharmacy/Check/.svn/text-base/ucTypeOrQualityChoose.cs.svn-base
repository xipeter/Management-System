using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Check
{
    /// <summary>
    /// [功能描述: 批量盘点设置]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改>
    ///     <时间>2007-07-16</时间>
    ///     <修改人>Liangjz</修改人>
    ///     <修改内容>
    ///             1 增加全盘功能
    ///             2 批量封帐时,增加对停用药品/库存为零药品的处理.
    ///     </修改内容>
    /// </修改>
    /// </summary>
    public partial class ucTypeOrQualityChoose : UserControl
    {
        public ucTypeOrQualityChoose()
        {
            InitializeComponent();
        }

        public ucTypeOrQualityChoose(ArrayList alList) : this()
        {
 
        }

        public ucTypeOrQualityChoose(bool isTypeQuality) : this()
        {
            this.IsTypeQuality = isTypeQuality;

            this.ShowTypeQuality();
        }

        #region 域变量

        /// <summary>
        /// 选择的药品类别/药品性质
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> drugTypeList = new List<Neusoft.FrameWork.Models.NeuObject>();

        /// <summary>
        /// 是否显示药品类别/药品性质
        /// </summary>
        private bool IsTypeQuality = true;

        /// <summary>
        /// 结果类型 0 取消 1 确认 2 全部药品
        /// </summary>
        private string resultFlag = "1";

        /// <summary>
        /// 选择的药品类别
        /// </summary>
        private string drugType = "";

        /// <summary>
        /// 选择的药品性质
        /// </summary>
        private string drugQuality = "";

        #endregion

        #region 属性

        /// <summary>
        /// 选择的药品类别/药品性质
        /// </summary>
        public List<Neusoft.FrameWork.Models.NeuObject> DrugTypeList
        {
            get
            {
                return this.drugTypeList;
            }
            set
            {
                this.drugTypeList = value;
            }
        }

        /// <summary>
        /// 结果类型
        /// </summary>
        public string ResultFlag
        {
            get
            {
                return this.resultFlag;
            }
            set
            {
                this.resultFlag = value;
            }
        }

        /// <summary>
        /// 选择的药品类别
        /// </summary>
        public string DrugType
        {
            get
            {
                return this.drugType;
            }
            set
            {
                this.drugType = value;
            }
        }

        /// <summary>
        /// 选择的药品性质
        /// </summary>
        public string DrugQuality
        {
            get
            {
                return this.drugQuality;
            }
            set
            {
                this.drugQuality = value;
            }
        }

        /// <summary>
        /// 是否对库存为零的药品进行封帐处理
        /// </summary>
        public bool IsCheckZeroStock
        {
            get
            {
                return this.ckZeroState.Checked;
            }
        }

        /// <summary>
        /// 是否对停用药品(本库房停用)进行封帐处理
        /// </summary>
        public bool IsCheckStopDrug
        {
            get
            {
                return this.ckValidDrug.Checked;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 显示药品类别、药品性质列表
        /// </summary>
        public virtual void ShowTypeQuality()
        {
            this.tvObject.CheckBoxes = true;

            Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList al;

            TreeNode typeParent = null;
            TreeNode typeNode = null;

            //加载药品类别列表
            typeParent = new TreeNode();
            typeParent.Text = "药品类别";
            typeParent.Tag = "";
            typeParent.ImageIndex = 0;
            typeParent.SelectedImageIndex = 0;
            this.tvObject.Nodes.Add(typeParent);

            al = constant.GetList("ITEMTYPE");
            foreach (Neusoft.HISFC.Models.Base.Const obj in al)
            {
                typeNode = new TreeNode();
                typeNode.Text = obj.Name;
                typeNode.Tag = obj.ID;
                typeNode.ImageIndex = 0;
                typeNode.SelectedImageIndex = 0;
                this.tvObject.Nodes[0].Nodes.Add(typeNode);
            }
            //加载药品性质列表
            typeParent = new TreeNode();
            typeParent.Text = "药品性质";
            typeParent.Tag = "";
            typeParent.ImageIndex = 0;
            typeParent.SelectedImageIndex = 0;
            this.tvObject.Nodes.Add(typeParent);

            al = constant.GetList("DRUGQUALITY");
            foreach (Neusoft.HISFC.Models.Base.Const obj in al)
            {
                typeNode = new TreeNode();
                typeNode.Text = obj.Name;
                typeNode.Tag = obj.ID;
                typeNode.ImageIndex = 0;
                typeNode.SelectedImageIndex = 0;
                this.tvObject.Nodes[1].Nodes.Add(typeNode);
            }

            this.tvObject.ExpandAll();
        }

        /// <summary>
        /// 根据传入的数组，显示在tvObject中
        /// </summary>
        /// <param name="arrayObject">neuObject数组</param>
        public virtual void ShowList(ArrayList alList)
        {
            //添加父级节点
            TreeNode nodeParent = new TreeNode();
            nodeParent.Text = "全部";
            nodeParent.Tag = "";
            nodeParent.ImageIndex = 0;
            nodeParent.SelectedImageIndex = 0;
            this.tvObject.Nodes.Add(nodeParent);

            foreach (Neusoft.FrameWork.Models.NeuObject obj in alList)
            {
                TreeNode node = new TreeNode();
                node.Text = obj.Name;
                node.Tag = obj;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                nodeParent.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 将treeview中选中的数据保存到数组中
        /// </summary>
        public void Save()
        {
            //清空数组中的数据。
            this.drugTypeList.Clear();

            if (this.tvObject.Nodes.Count == 0)
                return;

            foreach (TreeNode node in this.tvObject.Nodes)
            {
                foreach (TreeNode tn in node.Nodes)
                {
                    //将选中的项保存到数组中
                    if (tn.Checked) this.drugTypeList.Add(tn.Tag as Neusoft.FrameWork.Models.NeuObject);
                }
            }
        }

        /// <summary>
        /// 对药品性质与药品类别的选择返回字符串
        /// </summary>
        public void SaveForTypeQuality()
        {
            //清空数据
            this.drugType = "AAAA";
            this.drugQuality = "AAAA";
            if (this.tvObject.Nodes.Count == 0) 
                return;

            foreach (TreeNode node in this.tvObject.Nodes[0].Nodes)
            {
                if (node.Checked)
                {
                    if (this.drugType == "AAAA")
                        this.drugType = "";
                    this.drugType += node.Tag.ToString() + "','";
                }
            }
            foreach (TreeNode node in this.tvObject.Nodes[1].Nodes)
            {
                if (node.Checked)
                {
                    if (this.drugQuality == "AAAA")
                        this.drugQuality = "";
                    this.drugQuality += node.Tag.ToString() + "','";
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (this.ParentForm != null)
                this.ParentForm.Close();
        }

        #endregion

        #region 事件

        private void tvObject_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //如果选中的是根节点，则选中其所有子节点
            if (e.Node.Parent == null)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    if (node.Checked != e.Node.Checked) node.Checked = e.Node.Checked;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.IsTypeQuality)
            {
                this.SaveForTypeQuality();
                this.resultFlag = "1";
            }
            else
            {
                this.Save();
            }

            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.resultFlag = "0";

            this.Close();
        }


        private void btnAll_Click(object sender, EventArgs e)
        {
            this.resultFlag = "2";

            this.Close();
        }


        #endregion         
    }
}
