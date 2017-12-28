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
    public partial class ucEmployeeByDept : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 变量

        private Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //人员实体
        private Neusoft.HISFC.Models.Base.Employee myPerson = new Neusoft.HISFC.Models.Base.Employee();
        //人员管理类
        private Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
        //人员属性变动管理类
        private Neusoft.HISFC.BizLogic.Manager.EmployeeRecord recordManager = new Neusoft.HISFC.BizLogic.Manager.EmployeeRecord();
        //当前操作人所在的科室或者病区（护士）
        private Neusoft.FrameWork.Models.NeuObject myDept = new Neusoft.FrameWork.Models.NeuObject();
        //人员类型
        string myEmplType = "";

        #endregion

        #region 辅助函数

        /// <summary>
        /// 申请转科
        /// </summary>
        private void ApplyTransfer()
        {
            if (this.myPerson.ID == "") return;
            Neusoft.HISFC.Models.Base.EmployeeRecord record = new Neusoft.HISFC.Models.Base.EmployeeRecord();
            //取人员未核准的科室变动记录
            ArrayList al = recordManager.GetEmployeeRecordListByEmpl(this.myPerson.ID, "0");
            if (al == null)
            {
                MessageBox.Show(recordManager.Err, "错误提示");
                return;
            }
            if (al.Count > 0)
            {
                //如果存在在，显示申请的记录。不能同时存在两天申请记录。
                record = al[0] as Neusoft.HISFC.Models.Base.EmployeeRecord;
            }
            else
            {
                record.Employee = this.myPerson;
                record.OldData.ID = this.myPerson.Dept.ID;
                record.OldData.Name = this.objHelper.GetName(this.myPerson.Dept.ID);
                record.ShiftType.ID = "DEPT";
            }
            
            ucEmployeeRecord temp = new ucEmployeeRecord();
            temp.EmployeeRecord = record;
            temp.IsApply = true;            

            //取窗口返回参数
            DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(temp);
            if (dlg == DialogResult.OK)
            {
                //刷新人员属性变动数据
                this.RefreshData();
            }
        }


        /// <summary>
        /// 转科确认
        /// </summary>
        private void ConfirmTransfer()
        {
            Neusoft.HISFC.Models.Base.EmployeeRecord record = new Neusoft.HISFC.Models.Base.EmployeeRecord();
            Neusoft.HISFC.Models.Base.EmployeeRecord newRecord = new Neusoft.HISFC.Models.Base.EmployeeRecord();
            
            record.ShiftType.ID = "DEPT";
            //record.NewData.ID = (this.personManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
            //record.NewData.Name = (this.personManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.Name;
            ArrayList al = recordManager.GetEmployeeRecordListByEmpl(this.myPerson.ID, "0");
            if (al == null)
            {
                MessageBox.Show(recordManager.Err, "错误提示");
                return;
            }
            //if (al.Count >= 0)
            if(al.Count > 0)
            {
                newRecord = al[0] as Neusoft.HISFC.Models.Base.EmployeeRecord;
                record.NewData.ID = newRecord.NewData.ID;
                record.NewData.Name = newRecord.NewData.Name;
            }
            else
            {
                return;
            }

            ucEmployeeRecord temp = new ucEmployeeRecord();

            temp.EmployeeRecord = new Neusoft.HISFC.Models.Base.EmployeeRecord();
            temp.EmployeeRecord = record;
            temp.IsApply = false;

            //取窗口返回参数
            DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(temp);
            if (dlg == DialogResult.OK)
            {
                //确认之后刷新人员列表
                this.ShowEmployee();
            }
        }

        private void CancelTransfer()
        {
            this.ucEmployeeRecord1.Delete();
            this.RefreshData();
        }

        /// <summary>
        /// 显示人员列表，如果操作人是住院护士则取并且护士列表；否则取本科室非护士人员列表
        /// </summary>
        private void ShowEmployee()
        {
            //清空当前人员列表
            this.tvEmployee.Nodes.Clear();
            //取人员列表
            ArrayList alEmployee = new ArrayList();
            if (this.myEmplType == "N")
            {
                alEmployee = this.personManager.GetNurse(this.myDept.ID);
            }
            else
            {
                alEmployee = this.personManager.GetAllButNurse(this.myDept.ID);
            }

            if (alEmployee == null)
            {
                MessageBox.Show(this.personManager.Err, "错误提示");
                return;
            }

            this.tvEmployee.ImageList = this.imageList1;
            //添加根节点
            TreeNode root = new TreeNode(this.myDept.Name, 0, 0);
            root.Text = this.myDept.Name;
            root.Tag = new Neusoft.HISFC.Models.Base.Employee();
            this.tvEmployee.Nodes.Add(root);

            //添加人员节点			
            TreeNode node = null;
            foreach (Neusoft.HISFC.Models.Base.Employee person in alEmployee)
            {
                node = new TreeNode();
                node.Text = person.Name;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                node.Tag = person;
                root.Nodes.Add(node);
            }

            //选中根节点
            this.tvEmployee.SelectedNode = root;
            //展开根节点
            root.ExpandAll();
        }


        /// <summary>
        /// 窗口初始化
        /// </summary>
        private void Init()
        {
            //取全院科室列表，用于将编码转换为名称
            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            objHelper.ArrayObject = dept.GetDeptmentAll();

            //取人员类型
            myEmplType = ((Neusoft.HISFC.Models.Base.Employee)this.personManager.Operator).EmployeeType.ID.ToString();

            //根据人员类型，取科室或者病区
            if (this.myEmplType == "N")
                this.myDept = ((Neusoft.HISFC.Models.Base.Employee)this.personManager.Operator).Nurse;
            else
                this.myDept = ((Neusoft.HISFC.Models.Base.Employee)this.personManager.Operator).Dept;
            //显示人员列表
            this.ShowEmployee();
        }


        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            if (this.myPerson.ID == "") return;
            //取某个人的科室变动属性
            ArrayList al = this.recordManager.GetEmployeeRecordListByEmpl(this.myPerson.ID);
            if (al == null)
            {
                MessageBox.Show(this.recordManager.Err, "错误提示");
                return;
            }

            //显示在ListView中
            this.ucEmployeeRecord1.ShowListView(al);
        }


        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearData()
        {
        }


        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("申请", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("确认", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z执行, true, false, null);
            toolBarService.AddToolButton("取消", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "申请")
            {
                this.ApplyTransfer();
            }
            if (e.ClickedItem.Text == "确认")
            {
                this.ConfirmTransfer();
            }
            if (e.ClickedItem.Text == "取消")
            {
                this.CancelTransfer();
            }
            base.ToolStrip_ItemClicked(sender, e);
        } 

        #endregion

        public ucEmployeeByDept()
        {
            InitializeComponent();
        }

        private void ucEmployeeByDept_Load(object sender, EventArgs e)
        {
            try
            {
                this.Init();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tvEmployee_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvEmployee.SelectedNode != null)
                this.myPerson = e.Node.Tag as Neusoft.HISFC.Models.Base.Employee;
            else
                this.myPerson = new Neusoft.HISFC.Models.Base.Employee();
            //刷新人员属性变动数据
            this.RefreshData();

        }

    }
}