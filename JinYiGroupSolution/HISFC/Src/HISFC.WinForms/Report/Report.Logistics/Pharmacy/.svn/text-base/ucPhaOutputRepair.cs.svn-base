using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Neusoft.Report.Logistics.Pharmacy
{
    /// <summary>
    /// 出库单补打
    /// </summary>
    public partial class ucPhaOutputRepair : NeuDataWindow.Controls.ucQueryBaseForDataWindow//NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaOutputRepair()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnLoad()
        {
            
            base.OnLoad(); 
            this.InitCmb();
        }
        
        /// <summary>
        /// 综合业务管理
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 构建药房、药库列表
        /// </summary>
        /// <returns></returns>
        protected override int OnDrawTree()
        {
            
            if (tvLeft == null)
            {
                return -1;
            }

            ArrayList deptList = this.managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

            if (deptList == null)
            {
                return -1;
            }
            if (this.tvLeft.Nodes.Count > 0)
            {
                this.tvLeft.Nodes.Clear();
            }

            TreeNode parentTreeNode = new TreeNode("所有部门");
            tvLeft.Nodes.Add(parentTreeNode);
            foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
            {
                TreeNode deptNode = new TreeNode();
                deptNode.Tag = dept.ID;
                deptNode.Text = dept.Name;
                parentTreeNode.Nodes.Add(deptNode);
            }

            parentTreeNode.ExpandAll();

            return base.OnDrawTree();
        }
        
        /// <summary>
        /// 初始化出库类别列表
        /// </summary>
        private void InitCmb()
        {
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager userPower = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            List<Neusoft.FrameWork.Models.NeuObject> list = userPower.QueryUserPrivCollection(this.employee.ID, "0320", this.employee.Dept.ID);
            if (list != null)
            {
                this.cmbOutType.AddItems(new ArrayList(list));
                if (list.Count > 0)
                {
                    this.cmbOutType.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.cmbOutType.Tag == null)
            {
                MessageBox.Show("请选择出库类型！", "提示");
                return 1;
            }

            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            TreeNode selectNode = tvLeft.SelectedNode;

            if (selectNode.Level == 0)
            {
                return -1;
            }
            string deptCode = selectNode.Tag.ToString();

            return base.OnRetrieve(this.beginTime, this.endTime, this.cmbOutType.Tag.ToString(), deptCode);
        }
    }
}
