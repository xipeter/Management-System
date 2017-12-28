using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂管理计划列表]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>
    ///    
    /// </说明>
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
        /// <param name="planState">计划状态</param>
        public void ShowPlanList(params Neusoft.HISFC.Models.Preparation.EnumState[] stateCollection)
        {
            this.Nodes.Clear();

            Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();

            List<Neusoft.HISFC.Models.Preparation.Preparation> alList = new List<Neusoft.HISFC.Models.Preparation.Preparation>();

            foreach (Neusoft.HISFC.Models.Preparation.EnumState state in stateCollection)
            {
                List<Neusoft.HISFC.Models.Preparation.Preparation> alTempList = preparationManager.QueryPreparation(state);
                if (alTempList == null)
                {
                    System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取制剂计划列表发生错误" + preparationManager.Err));
                    return;
                }

                //{FF5101E6-3188-4928-AEAE-6C2B55A9848D}  对检验不合格的项目列表进行过滤
                List<Neusoft.HISFC.Models.Preparation.Preparation> alFilterList = new List<Neusoft.HISFC.Models.Preparation.Preparation>();
                foreach (Neusoft.HISFC.Models.Preparation.Preparation info in alTempList)
                {
                    if (info.IsAssayEligible == true)
                    {
                        alFilterList.Add(info);
                    }
                }

                alList.AddRange(alFilterList);
            }

            if (alList.Count == 0)
            {
                this.Nodes.Add(new System.Windows.Forms.TreeNode("没有计划单", 0, 0));
            }
            else
            {
                System.Windows.Forms.TreeNode parentNode = new System.Windows.Forms.TreeNode("计划单列表", 0, 0);
                this.Nodes.Add(parentNode);

                System.Windows.Forms.TreeNode planNode = new TreeNode();
                string privPlanNO = "";
                foreach (Neusoft.HISFC.Models.Preparation.Preparation info in alList)
                {
                    if (privPlanNO != info.PlanNO)      //添加计划单节点
                    {
                        planNode = new System.Windows.Forms.TreeNode(info.PlanNO);
                        planNode.Tag = info;
                        planNode.ImageIndex = 2;
                        planNode.SelectedImageIndex = 4;

                        parentNode.Nodes.Add(planNode);

                        privPlanNO = info.PlanNO;
                    }
                }

                this.Nodes[0].ExpandAll();

                this.SelectedNode = this.Nodes[0];
            }
        }

       
    }
}
