using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术台树形控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-04]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucOperationTableTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public ucOperationTableTree()
        {
            InitializeComponent();
            //if (!Environment.DesignMode)
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
                this.Init();
        }

        public ucOperationTableTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //if(!Environment.DesignMode)
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
                this.Init();
        }

#region 字段
        private Neusoft.HISFC.BizLogic.Operation.OpsTableManage tableManager = new Neusoft.HISFC.BizLogic.Operation.OpsTableManage();

#endregion
        private void Init()
        {
            this.Nodes.Clear();
            TreeNode root = new TreeNode();
            root.Text = "手术台";
            root.ImageIndex = 18;
            root.SelectedImageIndex = 18;
            this.Nodes.Add(root);

            //获取手术台列表			
            ArrayList tables = this.tableManager.GetOpsTableByDept(Environment.OperatorDeptID);

            //添加树形列表
            if (tables != null)
            {
                foreach (Neusoft.HISFC.Models.Operation.OpsTable table in tables)
                {
                    if (table.IsValid == false) 
                        continue;

                    TreeNode node = new TreeNode();
                    node.Tag = table;
                    node.Text = "[" + table.ID + "]" + table.Name;
                    node.ImageIndex = 37;
                    node.SelectedImageIndex = 37;
                    root.Nodes.Add(node);
                }
            }

            root.Expand();
        }
    }
}
