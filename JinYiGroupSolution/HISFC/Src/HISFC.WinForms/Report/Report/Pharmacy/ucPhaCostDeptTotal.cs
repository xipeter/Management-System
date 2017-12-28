using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Pharmacy
{
    /// <summary>
    /// 药品消耗统计汇总表，按取药科室汇总
    /// </summary>
    public partial class ucPhaCostDeptTotal : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaCostDeptTotal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重写画树方法，构建所有库存科室列表
        /// </summary>
        /// <returns></returns>
        protected override int OnDrawTree()
        {
            if (this.tvLeft == null)
            {
                return -1;
            }

            //不支持排序
            this.isSort = false;

            try
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                ArrayList deptList = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);
                deptList.AddRange(manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P));

                TreeNode root = new TreeNode("所有库存科室");
                root.Tag = "ROOT";

                TreeNode node;
                Neusoft.HISFC.Models.Base.Department dept;
                foreach (Object obj in deptList)
                {
                    dept = obj as Neusoft.HISFC.Models.Base.Department;
                    node = new TreeNode();
                    node.Text = dept.Name;
                    node.Tag = dept.ID;
                    root.Nodes.Add(node);
                }

                this.tvLeft.Nodes.Add(root);
                root.ExpandAll();
                //this.cmbQuery.alItems = deptList;

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始数据发生异常\n"+ex.Message,"提示");
                return -1;
            }

        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            string deptCode = this.tvLeft.SelectedNode.Tag.ToString().Equals("ROOT") ? "ALL" : this.tvLeft.SelectedNode.Tag.ToString();
            return base.OnRetrieve(deptCode, this.beginTime, this.endTime, this.tvLeft.SelectedNode.Text);
        }

    }
}

