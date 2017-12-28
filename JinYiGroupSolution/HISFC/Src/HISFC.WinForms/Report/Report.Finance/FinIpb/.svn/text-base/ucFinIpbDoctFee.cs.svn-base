using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbDoctFee : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        /// <summary>
        /// 住院医生工作量统计
        /// </summary>
        public ucFinIpbDoctFee()
        {
            InitializeComponent();
        }
        //Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private string emplCode = string.Empty;
        protected override void OnLoad()
        {

            this.isAcross = true;
            this.isSort = false;
            //this.Init();

            base.OnLoad();
           
            //填充数据、医生
            Neusoft.HISFC.Models.Base.Employee allDoct = new Neusoft.HISFC.Models.Base.Employee();
            System.Collections.ArrayList alDoctList = managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            allDoct.ID = "%%";
            allDoct.Name = "全部";
            allDoct.SpellCode = "QB";
            alDoctList.Insert(0, allDoct);
            this.cboDoctCode.AddItems(alDoctList);
            if (cboDoctCode.Items.Count > 0)
            {
                cboDoctCode.SelectedIndex = 0;
                emplCode = this.cboDoctCode.Tag.ToString();
            }

        }

        /// <summary>
        /// 重写树方法
        /// </summary>
        /// <returns></returns>
        //protected override int OnDrawTree()
        //{
        //    if (tvLeft == null)
        //    {
        //        return -1;
        //    }
        //    ArrayList emplList = managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);

        //    TreeNode parentTreeNode = new TreeNode("所有医生");
        //    tvLeft.Nodes.Add(parentTreeNode);
        //    foreach (Neusoft.HISFC.Models.Base.Employee empl in emplList)
        //    {
        //        TreeNode emplNode = new TreeNode();
        //        emplNode.Tag = empl.ID;
        //        emplNode.Text = empl.Name;
        //        parentTreeNode.Nodes.Add(emplNode);
        //    }

        //    parentTreeNode.ExpandAll();

        //    return base.OnDrawTree();
        //}
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            //TreeNode selectNode = tvLeft.SelectedNode;

            //if (selectNode.Level == 0)
            //{
            //    return -1;
            //}
            //string emplCode = selectNode.Tag.ToString();

            return base.OnRetrieve(base.beginTime, base.endTime, emplCode);
        }

        private void cboDoctCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDoctCode.SelectedIndex >= 0)
            {
                emplCode = this.cboDoctCode.Tag.ToString();
            }
        }

       
    }
}

