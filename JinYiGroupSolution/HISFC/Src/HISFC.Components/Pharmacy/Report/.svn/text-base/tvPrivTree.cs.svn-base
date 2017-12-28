using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy.Report
{
    /// <summary>
    /// [功能描述: 单据补打列表树]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class tvPrivTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvPrivTree()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        public tvPrivTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        #region 域变量

        /// <summary>
        /// 入库单节点名称
        /// </summary>
        private string inBillName = "入库单";

        /// <summary>
        /// 出库单节点名称
        /// </summary>
        private string outBillName = "出库单";

        /// <summary>
        /// 调拨单节点名称
        /// </summary>
        private string attempBillName = "调拨单";

        /// <summary>
        /// 是否显示调拨单
        /// </summary>
        private bool isShowAttempBill = true;

        #endregion

        #region 属性

        /// <summary>
        /// 入库单节点名称
        /// </summary>
        public string InBillName
        {
            get
            {
                return inBillName;
            }
            set
            {
                inBillName = value;
            }
        }

        /// <summary>
        /// 出库单节点名称
        /// </summary>
        public string OutBillName
        {
            get
            {
                return outBillName;
            }
            set
            {
                outBillName = value;
            }
        }

        /// <summary>
        /// 调拨单节点名称
        /// </summary>
        public string AttempBillName
        {
            get
            {
                return attempBillName;
            }
            set
            {
                attempBillName = value;
            }
        }

        /// <summary>
        /// 是否显示调拨单
        /// </summary>
        public bool IsShowAttempBill
        {
            get
            {
                return isShowAttempBill;
            }
            set
            {
                isShowAttempBill = value;

                this.Init();
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.ImageList = this.groupImageList;

            this.Nodes.Clear();

            Neusoft.FrameWork.Models.NeuObject tempObject;
            //按权限初始化
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            List<Neusoft.FrameWork.Models.NeuObject> alPriv = null;

            #region 显示入库节点

            alPriv = privManager.QueryUserPriv(privManager.Operator.ID, "0310");
            if (alPriv == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("获取入库权限发生错误" + privManager.Err));
                return;
            }
            if (alPriv.Count > 0)
            {
                tempObject = new Neusoft.FrameWork.Models.NeuObject();
                tempObject.Name = "入库单";
                tempObject.ID = "I";
                tempObject.Memo = "Bill";
                
                System.Windows.Forms.TreeNode inParentNode = new System.Windows.Forms.TreeNode();
                inParentNode.Text = tempObject.Name;

                inParentNode.ImageIndex = 0;
                inParentNode.SelectedImageIndex = 0;

                inParentNode.Tag = tempObject;
                this.Nodes.Add(inParentNode);
                foreach (Neusoft.FrameWork.Models.NeuObject obj in alPriv)
                {
                    //{32C46091-AE5F-44b0-BE40-4CF31D307C7C}  放开对药房的限制
                    if (obj.Memo == "PI" || obj.Memo == "P")
                    {
                        System.Windows.Forms.TreeNode nod = new System.Windows.Forms.TreeNode();
                        nod.Text = obj.Name;

                        nod.ImageIndex = 2;
                        nod.SelectedImageIndex = 4;

                        nod.Tag = obj;
                        inParentNode.Nodes.Add(nod);
                    }
                }
            }

            #endregion

            #region 显示出库节点

            alPriv = privManager.QueryUserPriv(privManager.Operator.ID, "0320");
            if (alPriv == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("加载出库权限列表发生错误" + privManager.Err));
                return;
            }
            if (alPriv.Count > 0)
            {
                tempObject = new Neusoft.FrameWork.Models.NeuObject();
                tempObject.Name = "出库单";
                tempObject.ID = "O";
                tempObject.Memo = "Bill";                

                if (this.isShowAttempBill)
                {
                    #region 显示调拨单

                    System.Windows.Forms.TreeNode outParentNode = new System.Windows.Forms.TreeNode();
                    outParentNode.Text = tempObject.Name;

                    outParentNode.ImageIndex = 0;
                    outParentNode.SelectedImageIndex = 0;

                    outParentNode.Tag = tempObject;
                    this.Nodes.Add(outParentNode);
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in alPriv)
                    {
                        if (obj.Memo == "PI")
                        {
                            System.Windows.Forms.TreeNode nod = new System.Windows.Forms.TreeNode();
                            nod.Text = obj.Name;

                            nod.ImageIndex = 2;
                            nod.SelectedImageIndex = 4;

                            nod.Tag = obj;
                            outParentNode.Nodes.Add(nod);
                        }
                    }
                    tempObject = new Neusoft.FrameWork.Models.NeuObject();
                    tempObject.Name = "调拨单";
                    tempObject.ID = "D";
                    tempObject.Memo = "Bill";                    

                    System.Windows.Forms.TreeNode attempNode = new System.Windows.Forms.TreeNode();
                    attempNode.Text = tempObject.Name;

                    attempNode.ImageIndex = 0;
                    attempNode.SelectedImageIndex = 0;

                    attempNode.Tag = tempObject;
                    this.Nodes.Add(attempNode);
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in alPriv)
                    {
                        if (obj.Memo == "P")
                        {
                            System.Windows.Forms.TreeNode nod = new System.Windows.Forms.TreeNode();
                            nod.Text = obj.Name;

                            nod.ImageIndex = 2;
                            nod.SelectedImageIndex = 4;

                            nod.Tag = obj;
                            attempNode.Nodes.Add(nod);
                        }
                    }

                    #endregion
                }
                else
                {
                    System.Windows.Forms.TreeNode outParentNode = new System.Windows.Forms.TreeNode();

                    outParentNode.Text = tempObject.Name;
                    outParentNode.Tag = tempObject;

                    this.Nodes.Add(outParentNode);
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in alPriv)
                    {
                        if (obj.Memo == "PI" || obj.Memo == "P")
                        {
                            System.Windows.Forms.TreeNode nod = new System.Windows.Forms.TreeNode();
                            nod.Text = obj.Name;
                            nod.Tag = obj;

                            nod.ImageIndex = 2;
                            nod.SelectedImageIndex = 4;

                            outParentNode.Nodes.Add(nod);
                        }
                    }
                }
            }

            #endregion

            if (this.Nodes.Count == 0)
            {
                System.Windows.Forms.TreeNode noPrivNode = new System.Windows.Forms.TreeNode("无权限");
                noPrivNode.Tag = null;
                this.Nodes.Add(noPrivNode);
            }

            this.ExpandAll();
        }
    }
}
