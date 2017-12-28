using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbItemStat : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 变量

        Neusoft.HISFC.BizProcess.Integrate.Manager inteManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        //Neusoft.HISFC.BizProcess.Integrate.RADT patientRadt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.BizProcess.Integrate.RADT patientRadt = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        #endregion 

        public ucFinIpbItemStat()
        {
            InitializeComponent();
        }

        private void ucFinIpbItemStat_Load(object sender, EventArgs e)
        {
            this.InitDeptTree();
            this.InitPatientTree();
        }

        #region 方法

        /// <summary>
        /// 初始化终端科室树
        /// </summary>
        private void InitDeptTree()
        {
            TreeNode parentNode = new TreeNode("终端科室");
            this.tvDept.Nodes.Add(parentNode);
            ArrayList al = new ArrayList();
            al = inteManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.T);
            if(al == null|| al.Count == 0)
            {
                return;
            }
            foreach(Neusoft.HISFC.Models.Base.Department dept in al)
            {
                TreeNode node = new TreeNode();
                node.Tag = dept.ID;
                node.Text = dept.Name;
                parentNode.Nodes.Add(node);
            }
            this.tvDept.ExpandAll();
        }

        /// <summary>
        /// 初始化本区患者树
        /// </summary>
        private void InitPatientTree()
        {
            string currentDeptID = empl.Dept.ID;

            TreeNode patientNode = new TreeNode("本区患者");
            this.tvPatient.Nodes.Add(patientNode);
            ArrayList al = new ArrayList();
            al = patientRadt.QueryPatient(currentDeptID,Neusoft.HISFC.Models.Base.EnumInState.I);
            if (al == null || al.Count == 0)
            {
                return;
            }
            foreach(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in al)
            {
                TreeNode node = new TreeNode();
                node.Tag = patientInfo.PID.CaseNO;
                node.Text = patientInfo.Name;
                patientNode.Nodes.Add(node);
            }
            this.tvPatient.ExpandAll();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            System.Type dtStr = System.Type.GetType("System.String");
            String[] condition;
            ArrayList tempAL = new ArrayList();

            if (this.neuTabControl1.SelectedTab == this.tabPage1)//终端科室列表
            {
                foreach (TreeNode tn in tvDept.GetNodeAt(0, 0).Nodes)
                {
                    if (tn.Checked)
                    {
                        tempAL.Add(tn.Tag.ToString());
                    }
                }
                condition = tempAL.ToArray(dtStr) as string[];
                if (condition != null && condition.Length == 0)
                {
                    MessageBox.Show("请选择科室");
                    return -1;
                }
                //for (int i = 0; i < tempAL.Count; i++)
                //{
                //    if (i == tempAL.Count - 1)
                //    {
                //        condition += tempAL[i].ToString();
                //        condition += ")";
                //    }
                //    else
                //    {
                //        condition += tempAL[i].ToString();
                //        condition += ",";
                //    }
                //}
                this.neuTabControl2.SelectedTab = this.tabPage3;
                return dwDeptPatient.Retrieve(this.dtpTime.Value.Date, this.dtpTime.Value.Date.AddDays(1).AddMilliseconds(-1), empl.Dept.ID, empl.Dept.Name,condition);
            }
            else
            {
                foreach (TreeNode tn in tvPatient.GetNodeAt(0, 0).Nodes)
                {
                    if (tn.Checked)
                    {
                        tempAL.Add(tn.Tag.ToString());
                    }
                }
                condition = tempAL.ToArray(dtStr) as string[];
                if (condition != null && condition.Length == 0)
                {
                    MessageBox.Show("请选择患者");
                    return -1;
                }
                //for (int j = 0; j < tempAL.Count; j++)
                //{
                //    if (j == tempAL.Count - 1)
                //    {
                //        condition += tempAL[j].ToString();
                //        condition += ")";
                //    }
                //    else
                //    {
                //        condition += tempAL[j].ToString();
                //        condition += ",";
                //    }
                //}
                this.neuTabControl2.SelectedTab = this.tabPage4;
                return dwPatientDept.Retrieve(this.dtpTime.Value.Date, this.dtpTime.Value.Date.AddDays(1).AddMilliseconds(-1), empl.Dept.ID, empl.Dept.Name,condition);
                
            }
        }
        #endregion

        #region 事件

        private void tvDept_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e == null)
            {
                return;
            }
            if(e.Node.Text.Equals("终端科室"))
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    if(e.Node.Checked)
                    {
                        tn.Checked = true;
                    }
                    else
                    {
                        tn.Checked = false;
                    }     
                }
                return;
            }
            else 
            {
                if (e.Node.Checked)
                {
                    e.Node.Checked = true;
                }
                else
                {
                    e.Node.Checked = false;  
                }      
            }
        }

        private void tvPatient_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            if (e.Node.Text.Equals("本区患者"))
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    if (e.Node.Checked)
                    {
                        tn.Checked = true;
                    }
                    else
                    {
                        tn.Checked = false;
                    }
                }
                return;
            }
            else
            {
                if (e.Node.Checked)
                {
                    e.Node.Checked = true;
                }
                else
                {
                    e.Node.Checked = false;
                }
            }
        }

        #endregion

        
    }
}
