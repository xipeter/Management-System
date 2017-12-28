using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MetChk
{
    public partial class ucMetChkNum : Common.ucQueryBaseForDataWindow 
    {
        public ucMetChkNum()
        {
            InitializeComponent();
        }
        //protected override void OnLoad()
        //{
        //    this.Init();

        //    base.OnLoad();
        //}
        protected override int OnDrawTree()
        {

            if (this.tvLeft == null)
            {
                return -1;
            }

            DateTime now=DateTime.Now;
            DateTime dt=new DateTime(DateTime.Now.Year,1,1);
            this.dtpBeginTime.Value = dt;

            System.Collections.ArrayList deptList = new Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager().QueryCompanyRegister
                (dt.ToString(), dt.AddYears(1).AddMilliseconds(-1).ToString());
            if (deptList == null)
            {
                return -1;
            }
            TreeNode parentTreeNode = new TreeNode("所有公司");

            this.tvLeft.Nodes.Add(parentTreeNode);

            foreach (Neusoft.FrameWork.Models.NeuObject dept in deptList)
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
        /// 检索数据
        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            TreeNode selectNode = this.tvLeft.SelectedNode;
            string deptCode;
            //if (selectNode.Level == 0)
            //{
            //    return -1;
            //}

            if (selectNode.Tag == null)
            {
                deptCode = "";
            }
            else
            {
                deptCode = selectNode.Tag.ToString();
            }
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptCode);
            
        }
    }
}
