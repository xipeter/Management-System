using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
    public partial class tvTerminalCarTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvTerminalCarTree()
        {
            InitializeComponent();

            Init();
        }

        public tvTerminalCarTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        ///<summary>
        ///树节点所在的TabPage
        ///<summary>
        private System.Windows.Forms.TabPage parentTab = null;

        /// <summary>
        /// 科室帮助类 
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 树节点图标索引 
        /// </summary>
        private int deptImageIndex;

        /// <summary>
        /// 患者节点图标索引 
        /// </summary>
        private int patientImageIndex;

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
        /// 初始化 
        /// </summary>
        private void Init()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            ArrayList alDept = deptManager.GetDeptmentAllValid();
            if (alDept == null)
            {
                return;
            }

            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            this.ImageList = this.groupImageList;
        }

        /// <summary>
        /// 列表显示
        /// </summary>
        /// <returns></returns>
        public int ShowDeptAll(string state)
        {
            //Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier terminalManager = new Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier();

            Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alDept = deptManager.GetDeptmentAllValid();

            this.Nodes.Clear(); 

            System.Windows.Forms.TreeNode deptNode = new System.Windows.Forms.TreeNode();

            foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
            {
                deptNode = new System.Windows.Forms.TreeNode();

                deptNode.Text = this.deptHelper.GetName(dept.ID);
                deptNode.ImageIndex = 0;
                deptNode.Tag = dept;

                this.Nodes.Add(deptNode);
            }

            return 1;
        }

    }
}
