using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 住院科室列表树]<br></br>
    /// [创 建 者: 管玉兴]<br></br>
    /// [创建时间: 2010-10-20]<br></br>
    /// </summary>
    public partial class tvInhosDeptTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvInhosDeptTree()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        public tvInhosDeptTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        #region 变量

        private bool isAllDept = true;

        /// <summary>
        /// 是否是全部科室，还是有权限的科室
        /// </summary>
        [Category("控件设置"), Description("全部科室或者权限科室，True:全部科室 False:权限科室")]
        public bool IsAllDept
        {
            get
            {
                return isAllDept;
            }
            set
            {
                isAllDept = value;
            }
        }
        
        #endregion


        public void Init()
        {
            this.ImageList = this.deptImageList;
            this.Nodes.Clear();

            #region 显示各个权限科室

            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptMagr = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            Neusoft .HISFC .BizLogic .Manager .Department depts = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList deptList = new ArrayList();

            TreeNode root = new TreeNode();
            root.Text = "所有科室";
            root.Tag = "ALL";
            root.ImageIndex = 1;
            this.Nodes.Add(root);
            TreeNode node;


            if (this.isAllDept == false)
            {
                deptList = deptMagr.GetMultiDeptNew(deptMagr.Operator.ID);
                foreach (Neusoft.HISFC.Models.Base.DepartmentStat dept in deptList)
                {
                    node = new TreeNode();
                    node.Text = dept.Name;
                    node.Tag = dept.ID;
                    node.ImageIndex = 0;
                    root.Nodes.Add(node);
                }
            }
            else
            {
                deptList = depts.GetInHosDepartment();
                foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
                {
                    node = new TreeNode();
                    node.Text = dept.Name;
                    node.Tag = dept.ID;
                    node.ImageIndex = 0;
                    root.Nodes.Add(node);
                }
            }

            root.ExpandAll();

            #endregion
        }
    }
}
