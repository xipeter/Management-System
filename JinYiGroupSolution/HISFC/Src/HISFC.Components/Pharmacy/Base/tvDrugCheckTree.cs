using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述:  药品审核树]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <说明
    ///		
    ///  />
    /// </summary>
    public partial class tvDrugCheckTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvDrugCheckTree()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                this.InitTree();
            }
        }

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        /// <summary>
        /// 常数管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 加载树
        /// </summary>
        protected virtual void InitTree()
        {
            this.ImageList = this.groupImageList;

            this.Nodes.Clear();

            ArrayList alType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);

            TreeNode root = new TreeNode("全部药品信息", 0, 0);
            root.Tag = "1=1";

            this.Nodes.Add(root);

            foreach (Neusoft.FrameWork.Models.NeuObject objType in alType) //药品分类
            {
                TreeNode typeNode = new TreeNode(objType.Name, 1, 1);
                typeNode.Tag = "药品类型 = '" + objType.Name.ToString() + "'";
                root.Nodes.Add(typeNode);

                AddNode(objType, typeNode);
            }
            //展开根节点
            root.Expand();
        }

        /// <summary>
        /// 根据不同药品类型填充待审核药品树
        /// </summary>
        /// <param name="drugType">药品类别</param>
        /// <param name="rootNode">根节点</param>
        private void AddNode(Neusoft.FrameWork.Models.NeuObject drugType, TreeNode rootNode)
        {
            //获取药品类型对应的药品，列表中显示的是新申请的药品
            List<Neusoft.HISFC.Models.Pharmacy.Item> checkItemList = this.itemManager.QueryItemListForCheck(drugType.ID.ToString());
            if (checkItemList != null)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.Item item in checkItemList)
                {
                    TreeNode tn = new TreeNode();
                    if (this.itemManager.QueryValidDrugByCustomCode(item.NameCollection.UserCode).Count > 0)
                    {
                        tn.Text = "@" + item.Name;//已经含有有效记录不能通过审核，作特殊标记
                    }
                    else
                    {
                        tn.Text = item.Name;
                    }

                    tn.ImageIndex = 2;
                    tn.SelectedImageIndex = 4;

                    tn.Tag = item;
                    rootNode.Nodes.Add(tn);
                }
                rootNode.Expand();
            }
            else
            {
                MessageBox.Show("根据药品类别加载待审核药品发生错误" + this.itemManager.Err);
            }
        }

    }
}
