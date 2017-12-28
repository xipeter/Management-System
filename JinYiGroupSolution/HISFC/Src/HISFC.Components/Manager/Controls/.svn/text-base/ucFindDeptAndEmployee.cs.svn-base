using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 科室人员查找控件]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－12－12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucFindDeptAndEmployee : UserControl
    {
        
        private ucDepartmentManager ucDeptMgr;
        int searchPerson = 0;//查找人员位置初始值
        int searchPersonMax = 0;//查找人员位置最大值
        int searchDept = 0;//查找科室位置初始值
        int searchDeptMax = 0;//查找科室位置最大值
        string tempSearch = "XXXXXXhhdhfhruuuurrr^^&&&&&((**&&%%###$";
        ArrayList alPerson = new ArrayList();
        //人员管理类
        Neusoft.HISFC.BizLogic.Manager.Person perMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
        public ucFindDeptAndEmployee()
        {   
            InitializeComponent();
        }
        /// <summary>
        /// 科室人员管理类属性
        /// </summary>
        public ucDepartmentManager UcDeptMgr
        {
            get 
            {
                return this.ucDeptMgr;
            }
            set
            {
                this.ucDeptMgr = value;
            }
        }

        /// <summary>
        /// 根据科室编码查询科室方法
        /// </summary>
        /// <param name="deptCode"></param>
        private void SearchDept(string deptCode)
        {
            foreach (TreeNode obj in this.ucDeptMgr.tvDeptList1.Nodes[0].Nodes)
            {
                foreach (TreeNode objT in obj.Nodes)
                {
                    if (objT.Text.Substring(1, 4) == deptCode)
                    {
                        this.ucDeptMgr.tvDeptList1.SelectedNode = objT;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 查找方法
        /// </summary>
        private void Search()
        {
            try
            {
                string search = this.tbFind.Text;
                //如果查找为科室
                if (rbDept.Checked)
                {   //如果查找条件为编码
                    if (rbCode.Checked)
                    {
                        search = search.PadLeft(4, '0');
                        foreach (TreeNode typeNode in this.ucDeptMgr.tvDeptList1.Nodes[0].Nodes)
                        {
                            foreach (TreeNode obj in typeNode.Nodes)
                            {
                                string text = obj.Text.Substring(0, 4);

                                if (obj.Text.Substring(1, 4) == search)
                                {
                                    this.ucDeptMgr.tvDeptList1.SelectedNode = obj;
                                    break;
                                }
                            }
                        }
                    }
                    //如果查询条件为名称
                    if (rbName.Checked)
                    {
                        if (search != tempSearch)
                        {
                            searchDept = 0;
                            searchDeptMax = this.ucDeptMgr.tvDeptList1.Nodes[0].Nodes.Count;
                        }

                        tempSearch = search;

                        for (int i = searchDept; i < this.ucDeptMgr.tvDeptList1.Nodes[0].Nodes.Count; i++)
                        {
                            TreeNode typeNode = this.ucDeptMgr.tvDeptList1.Nodes[0].Nodes[i];
                            foreach (TreeNode obj in typeNode.Nodes)
                            {
                                if (obj.Text.IndexOf(search) >= 0)
                                {
                                    this.ucDeptMgr.tvDeptList1.SelectedNode = obj;
                                    break;
                                }
                            }
                            searchDept++;
                        }

                        searchDept++;
                        if (searchDept == searchDeptMax)
                        {
                            searchDept = 0;
                        }

                    }
                }
                //如果查找为人员
                if (rbEmpl.Checked)
                {   //如果查询条件为编码
                    if (rbCode.Checked)
                    {
                        search = search.PadLeft(6, '0');
                       Neusoft.HISFC.Models.Base.Employee obj = perMgr.GetPersonByID(search);
                        if (obj == null)
                        {
                            MessageBox.Show("没有此员工编号的人员!");
                            return;
                        }
                        SearchDept(obj.Dept.ID);
                        for (int i = 0; i < this.ucDeptMgr.neuSpread1_Sheet1.RowCount; i++)
                        {
                            if (this.ucDeptMgr.neuSpread1_Sheet1.Cells[i, 0].Text == search)
                            {
                                //{4C8F4B67-330F-4e5e-B537-8AB753F272A7}
                                this.ucDeptMgr.neuSpread1_Sheet1.AddSelection(i, 1, 1,1);
                                break;
                            }
                        }
                    }
                    //如果查询条件为名称
                    if (rbName.Checked)
                    {
                        if (search != tempSearch)
                        {
                            alPerson = perMgr.GetPersonByName("%" + search + "%");
                            /*
                             *  [2007/02/05] 这个地方应该是错误的,alPerson是全局的变的变量
                             *               已经在第31行初始化了,而且业务层的返回值不太可能是null.
                             *               我觉得本意应该是 alPerson.Count==0;
                             *     
                             *   if (alPerson == null)
                             *   {
                             *       MessageBox.Show("没有名称符合" + "[" + search + "]" + "的员工!");
                             *       return;
                             *   }
                             * 
                             * */
                            if (alPerson.Count == 0)
                            {
                                MessageBox.Show("没有名称符合" + "[" + search + "]" + "的员工!");
                                return;
                            }
                            searchPersonMax = alPerson.Count;
                            searchPerson = 0;
                        }

                        tempSearch = search;

                        if (alPerson.Count == 0)
                        {
                            MessageBox.Show("没有此员工编号的人员!");
                            return;
                        }

                        Neusoft.HISFC.Models.Base.Employee obj = (Neusoft.HISFC.Models.Base.Employee)alPerson[searchPerson];
                        if (obj == null)
                        {
                            MessageBox.Show("没有此员工编号的人员!");
                            return;
                        }
                        SearchDept(obj.Dept.ID);
                        for (int i = 0; i < this.ucDeptMgr.neuSpread1_Sheet1.RowCount; i++)
                        {
                            if (this.ucDeptMgr.neuSpread1_Sheet1.Cells[i, 0].Text == obj.ID)
                            {
                                //{4C8F4B67-330F-4e5e-B537-8AB753F272A7}
                                this.ucDeptMgr.neuSpread1_Sheet1.AddSelection(i, 1, 1, 1);
                                break;
                            }
                        }
                        searchPerson++;
                        if (searchPerson == searchPersonMax)
                            searchPerson = 0;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void bttClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void bttNext_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void rbCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCode.Checked)
            {
                if (rbDept.Checked)
                    tbFind.MaxLength = 4;
                if (rbEmpl.Checked)
                    tbFind.MaxLength = 6;
            }
            else
            {
                tbFind.MaxLength = 100;
            }
        }

        private void rbDept_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDept.Checked)
            {
                if (rbCode.Checked)
                {
                    tbFind.MaxLength = 4;
                }
                if (rbName.Checked)
                {
                    tbFind.MaxLength = 100;
                }
            }
            else
            {
                if (rbCode.Checked)
                {
                    tbFind.MaxLength = 6;
                }
                if (rbName.Checked)
                {
                    tbFind.MaxLength = 100;
                }
            }
        }

        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }
    }
}
