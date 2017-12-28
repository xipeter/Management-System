using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Plan
{
    /// <summary>
    /// [功能描述: 入库/采购计划树列表控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class tvPlanList : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvPlanList()
        {
            InitializeComponent();

            this.ImageList = this.groupImageList;
        }

        public tvPlanList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.ImageList = this.groupImageList;
        }

        /// <summary>
        /// 入库计划单据列表
        /// </summary>
        /// <param name="privDept">权限科室</param>
        /// <param name="planState">计划状态</param>
        public void ShowInPlanList(Neusoft.FrameWork.Models.NeuObject privDept, string planState)
        {
            this.Nodes.Clear();

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            ArrayList alList = itemManager.QueryInPLanList(privDept.ID, "0");
            if (alList == null)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取入库计划单列表发生错误" + itemManager.Err));
                return;
            }

            if (alList.Count == 0)
            {
                this.Nodes.Add(new System.Windows.Forms.TreeNode("没有入库计划单", 0, 0));
            }
            else
            {
                System.Windows.Forms.TreeNode parentNode = new System.Windows.Forms.TreeNode("入库计划单列表", 0, 0);
                this.Nodes.Add(parentNode);

                System.Windows.Forms.TreeNode node;
                string temp = "";
                foreach (Neusoft.FrameWork.Models.NeuObject info in alList)
                {
                    node = new System.Windows.Forms.TreeNode();

                    if (planState == "0")
                        node.Text = info.ID + "  【计划单】";
                    else
                        node.Text = info.ID + "  【采购单】";

                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 4;

                    info.Memo = planState;

                    node.Tag = info;

                    if (temp != info.ID)
                    {
                        parentNode.Nodes.Add(node);
                    }

                    temp = info.ID;
                }
                this.Nodes[0].ExpandAll();
                this.SelectedNode = this.Nodes[0];
            }
        }

        /// <summary>
        /// 采购计划单据列表
        /// </summary>
        /// <param name="privDept">权限科室</param>
        /// <param name="stockState">采购状态</param>
        public void ShowStockPlanList(Neusoft.FrameWork.Models.NeuObject privDept, string stockState)
        {
            //清空列表
            this.Nodes.Clear();

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            //显示采购单列表  0 状态为入库计划单
            ArrayList alList = itemManager.QueryStockPLanCompanayList(privDept.ID, stockState);
            if (alList == null)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取采购计划单列表发生错误" + itemManager.Err));
                return;
            }

            if (alList.Count == 0)
            {
                this.Nodes.Add(new System.Windows.Forms.TreeNode("没有采购计划单", 0, 0));
            }
            else
            {
                this.Nodes.Add(new System.Windows.Forms.TreeNode("采购计划单列表", 0, 0));
                foreach (Neusoft.FrameWork.Models.NeuObject info in alList)
                {
                    System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();

                    node.Text = "【" + info.ID + "】" + info.Name;//【入库计划单号】+供货公司名称
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 4;

                    //初始入库计划制定时指定供货公司编码为'0000000000'
                    if (info.User01 == null || info.User01.Trim() == "")
                    {
                        info.User01 = "0000000000";
                    }

                    node.Tag = info;   //入库计划单号+供货公司ID

                    this.Nodes[0].Nodes.Add(node);
                }
                this.Nodes[0].ExpandAll();
                this.SelectedNode = this.Nodes[0];
            }
        }
    }
}
