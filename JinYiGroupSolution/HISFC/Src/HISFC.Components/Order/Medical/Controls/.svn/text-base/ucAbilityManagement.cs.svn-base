using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Medical.Controls
{
    /// <summary>
    /// [功能描述: 执业资质管理]<br></br>
    /// [创 建 者: 孙久海]<br></br>
    /// [创建时间: 2008－7－17]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucAbilityManagement : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private string happenNO = string.Empty;

        /// <summary>
        /// 资质实体类

        /// </summary>
        private Neusoft.HISFC.Models.Order.Medical.Ability ability = new Neusoft.HISFC.Models.Order.Medical.Ability();

        /// <summary>
        /// 资质业务类

        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.Medical.Ability aby = new Neusoft.HISFC.BizLogic.Order.Medical.Ability();

        /// <summary>
        /// 帮助类

        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper ehSpeciality = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper ehVocationType = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper ehLevel = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper ehEdu = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper ehDept = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 工具条

        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        public ucAbilityManagement()
        {
            InitializeComponent();
        }

        #region 工具条处理

        /// <summary>
        /// 注册工具条

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("添加资质", "添加一条资质信息", 1, true, false, null);
            this.toolBarService.AddToolButton("删除资质", "删除一行资质信息", 2, true, false, null);
            return this.toolBarService;
        }

        /// <summary>
        /// 重写保存按钮实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Save(object sender, object neuObject)
        {
            this.SaveAbility();
            return base.Save(sender, neuObject);
        }

        /// <summary>
        /// 重写导出按钮实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            ExportToExcel();
            return base.Export(sender, neuObject);
        }

        /// <summary>
        /// 处理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "添加资质":
                    NewAbility();
                    break;
                case "删除资质":
                    DeleteAbility();
                    break;
                //case "导出":
                //ExportToExcel();
                //break;
                default: break;
            }

        }

        /// <summary>
        /// 添加一条资质

        /// </summary>
        private void NewAbility()
        {
            if (tv.SelectedNode.ToolTipText == "人员")
            {
                Neusoft.HISFC.Models.Base.Employee empls = new Neusoft.HISFC.Models.Base.Employee();
                empls = tv.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Employee;
                this.tbEmplCode.Text = empls.ID;
                this.tbEmplName.Text = empls.Name;
                this.tbBirthday.Text = empls.Birthday.Year.ToString();
                this.tbDept.Text = ehDept.GetName(empls.Dept.ID);
                this.tbEducation.Text = ehEdu.GetName(empls.GraduateSchool.ID);
                this.tbPost.Text = ehLevel.GetName(empls.Level.ID);
                this.tbSex.Text = empls.Sex.Name;
                this.tbRemark.Text = "";
                this.tbAbilityCardNO.Text = "";
                this.tbVocationArea.Text = "";
                this.tbVocationCardNO.Text = "";
                this.cbVocationType.SelectedIndex = -1;
                this.cbSpeciality.SelectedIndex = -1;
                this.happenNO = "-1";
            }
            else
            {
                MessageBox.Show("选择的不是人员节点，不能添加资质信息！");
            }

        }

        /// <summary>
        /// 删除一条资质

        /// </summary>
        private void DeleteAbility()
        {
            if (this.happenNO == "-1")
            {
                MessageBox.Show("没有选择资质信息！");

                return;
            }
            if (this.tbEmplCode.Text == "")
            {
                MessageBox.Show("没有选择资质信息！");

                return;
            }
            if (aby.DeleteAbilityByHappenNO(this.happenNO) == -1)
            {
                MessageBox.Show("删除失败！");

                return;
            }

            this.fpAbility_Sheet1.Rows.Remove(this.fpAbility_Sheet1.ActiveRowIndex, 1);
            MessageBox.Show("删除成功！");
        }

        private void SaveAbility()
        {
            if (this.CheckControlsValid() == -1)
            {
                return;
            }

            if (CheckDataValid() == false)
            {
                return;
            }

            Neusoft.HISFC.Models.Order.Medical.Ability abilityFC = new Neusoft.HISFC.Models.Order.Medical.Ability();
            abilityFC = this.FillObj();
            if (abilityFC == null)
            {
                MessageBox.Show("获取资质实体出错！");

                return;
            }

            if (this.happenNO == "-1")
            {
                if (aby.InsertAbility(abilityFC) == -1)
                {
                    MessageBox.Show("更新资质信息失败！" + aby.Err);

                    return;
                }
            }
            else
            {
                if (aby.UpdateAbility(abilityFC) == -1)
                {
                    MessageBox.Show("更新资质信息失败！" + aby.Err);

                    return;
                }
            }
            MessageBox.Show("更新资质信息成功！", "提示", MessageBoxButtons.OK);
            List<Neusoft.HISFC.Models.Order.Medical.Ability> abList = new List<Neusoft.HISFC.Models.Order.Medical.Ability>();
            abList = aby.QueryAbilityByPersonID(abilityFC.Employee.ID);
            FillFP(abList);
        }

        /// <summary>
        /// 工具条:"导出"按钮处理程序
        /// </summary>
        private void ExportToExcel()
        {
            if (this.fpAbility_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有要保存的数据!"), "消息");

                return;
            }
            if (this.fpAbility.Export() == 1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("数据导出成功!"), "消息");
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucAbilityManagement_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            IniHelper();
            Init();
            tv.AfterSelect += new TreeViewEventHandler(tv_AfterSelect);
        }

        /// <summary>
        /// 树形控件选择节点触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tv.SelectedNode != null)
            {
                if (tv.SelectedNode.ToolTipText == "人员")
                {
                    List<Neusoft.HISFC.Models.Order.Medical.Ability> abList;
                    Neusoft.HISFC.Models.Base.Employee empls = new Neusoft.HISFC.Models.Base.Employee();
                    empls = tv.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Employee;
                    abList = aby.QueryAbilityByPersonID(empls.ID);
                    FillFP(abList);
                }

                if (tv.SelectedNode.ToolTipText == "科室")
                {
                    List<Neusoft.HISFC.Models.Order.Medical.Ability> abList;
                    Neusoft.HISFC.Models.Base.Department depts = new Neusoft.HISFC.Models.Base.Department();
                    depts = tv.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Department;
                    abList = aby.QueryAbilityByDeptID(depts.ID);
                    FillFP(abList);
                }
                this.ClearControls();
            }
        }

        /// <summary>
        /// 根据参数类型获得ArrayList
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ArrayList GetConstant(Neusoft.HISFC.Models.Base.EnumConstant type)
        {
            //常数管理类

            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            //Neusoft.HISFC.BizProcess.Integrate.Manager consManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList constList = consManager.GetList(type);
            if (constList == null)
                throw new Neusoft.FrameWork.Exceptions.ReturnNullValueException();

            return constList;
        }

        /// <summary>
        /// 初始化combobox控件
        /// </summary>
        private void Init()
        {
            this.cbSpeciality.IsListOnly = true;
            this.cbSpeciality.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.SPECIALITY));

            this.cbVocationType.IsListOnly = true;
            this.cbVocationType.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.VOCATIONTYPE));
        }

        /// <summary>
        /// 初始化Helper类型
        /// </summary>
        private void IniHelper()
        {
            ehSpeciality.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.SPECIALITY);//专业
            ehVocationType.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.VOCATIONTYPE);//执业类型
            Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
            ehDept.ArrayObject = deptMgr.GetDeptNoNurse();//科室
            ehEdu.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.EDUCATION);//学历
            ehLevel.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.LEVEL);//职级
        }

        /// <summary>
        /// 填充FP控件
        /// </summary>
        /// <param name="abList"></param>
        private void FillFP(List<Neusoft.HISFC.Models.Order.Medical.Ability> abList)
        {
            if (abList == null)
            {
                this.fpAbility_Sheet1.RowCount = 0;

                return;
            }
            this.fpAbility_Sheet1.RowCount = 0;
            for (int rowCount = 0; rowCount < abList.Count; rowCount++)
            {
                Neusoft.HISFC.Models.Order.Medical.Ability abtemp = new Neusoft.HISFC.Models.Order.Medical.Ability();
                //根据记录行数动态加载FarPoint的行，每次循环加一行

                this.fpAbility_Sheet1.Rows.Add(rowCount, 1);
                abtemp = abList[rowCount] as Neusoft.HISFC.Models.Order.Medical.Ability;
                //赋值查询结果到FarPoint对应的单元格中

                this.fpAbility_Sheet1.Cells[rowCount, 0].Text = abtemp.Employee.ID;
                this.fpAbility_Sheet1.Cells[rowCount, 1].Text = abtemp.Employee.Name;
                this.fpAbility_Sheet1.Cells[rowCount, 2].Text = this.ehDept.GetName(abtemp.Employee.Dept.ID);
                this.fpAbility_Sheet1.Cells[rowCount, 3].Text = this.ehLevel.GetName(abtemp.Employee.Level.ID);
                this.fpAbility_Sheet1.Cells[rowCount, 4].Text = this.ehSpeciality.GetName(abtemp.Speciality.ID);
                this.fpAbility_Sheet1.Cells[rowCount, 5].Text = abtemp.VocationCardNO;
                this.fpAbility_Sheet1.Cells[rowCount, 6].Text = abtemp.AbilityCardNO;
                this.fpAbility_Sheet1.Cells[rowCount, 7].Text = this.ehVocationType.GetName(abtemp.VocationType.ID);
                this.fpAbility_Sheet1.Cells[rowCount, 8].Text = abtemp.VocationArea;
                this.fpAbility_Sheet1.Cells[rowCount, 9].Text = abtemp.Remark;
                this.fpAbility_Sheet1.Cells[rowCount, 10].Text = abtemp.ID;
                this.fpAbility_Sheet1.Cells[rowCount, 11].Text = abtemp.Employee.Birthday.ToString();
                this.fpAbility_Sheet1.Cells[rowCount, 12].Text = abtemp.Employee.Sex.Name;
                this.fpAbility_Sheet1.Cells[rowCount, 13].Text = this.ehEdu.GetName(abtemp.Employee.GraduateSchool.ID);


            }
        }

        /// <summary>
        /// 点击FP控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpAbility_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int rowID;
            rowID = this.fpAbility_Sheet1.ActiveRowIndex;
            //可编辑项
            cbSpeciality.Text = this.fpAbility_Sheet1.Cells[rowID, 4].Text;
            cbVocationType.Text = this.fpAbility_Sheet1.Cells[rowID, 7].Text;
            tbVocationArea.Text = this.fpAbility_Sheet1.Cells[rowID, 8].Text;
            tbVocationCardNO.Text = this.fpAbility_Sheet1.Cells[rowID, 5].Text;
            tbAbilityCardNO.Text = this.fpAbility_Sheet1.Cells[rowID, 6].Text;
            tbRemark.Text = this.fpAbility_Sheet1.Cells[rowID, 9].Text;
            //只读控件
            tbEmplCode.Text = this.fpAbility_Sheet1.Cells[rowID, 0].Text;
            tbEmplName.Text = this.fpAbility_Sheet1.Cells[rowID, 1].Text;
            tbDept.Text = this.fpAbility_Sheet1.Cells[rowID, 2].Text;
            tbSex.Text = this.fpAbility_Sheet1.Cells[rowID, 12].Text;
            tbBirthday.Text = this.fpAbility_Sheet1.Cells[rowID, 11].Text;
            tbEducation.Text = this.fpAbility_Sheet1.Cells[rowID, 13].Text;
            tbPost.Text = this.fpAbility_Sheet1.Cells[rowID, 3].Text;
            this.happenNO = this.fpAbility_Sheet1.Cells[rowID, 10].Text;

        }

        /// <summary>
        /// 清空窗口中的控件
        /// </summary>
        private void ClearControls()
        {
            this.tbEmplCode.Text = "";
            this.tbEmplName.Text = "";
            this.tbBirthday.Text = "";
            this.tbDept.Text = "";
            this.tbEducation.Text = "";
            this.tbPost.Text = "";
            this.tbSex.Text = "";
            this.tbRemark.Text = "";
            this.tbAbilityCardNO.Text = "";
            this.tbVocationArea.Text = "";
            this.tbVocationCardNO.Text = "";
            this.cbVocationType.SelectedIndex = -1;
            this.cbSpeciality.SelectedIndex = -1;
        }

        /// <summary>
        /// 验证控件输入是否合法
        /// </summary>
        /// <returns></returns>
        private int CheckControlsValid()
        {
            if (this.tbEmplCode.Text == "")
            {
                MessageBox.Show("未选择需要更新的人员或资质信息！");

                return -1;
            }

            if (this.cbSpeciality.SelectedIndex < 0)
            {
                MessageBox.Show("未选择专业信息！");
                this.cbSpeciality.Focus();

                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 检查数据是否合法，包括：数据唯一性
        /// </summary>
        /// <returns></returns>
        private bool CheckDataValid()
        {
            //根据人员，专业查询资质信息记录个数
            //{65C2D1EE-A2ED-4781-BB10-48D7156CFD6C}
            string strRecordCount = aby.GetAbilityCountByEmplAndSpeciality(this.tbEmplCode.Text.Trim(), this.cbSpeciality.Tag.ToString());
            int recordCount = Neusoft.FrameWork.Function.NConvert.ToInt32(strRecordCount);

            if (recordCount > 0)
            {
                MessageBox.Show("同一个员工不允许维护相同专业的资质信息！");
                return false;
            }

            return true;
        }

        private Neusoft.HISFC.Models.Order.Medical.Ability FillObj()
        {
            Neusoft.HISFC.Models.Order.Medical.Ability abtemp = new Neusoft.HISFC.Models.Order.Medical.Ability();

            abtemp.Speciality.ID = cbSpeciality.Tag.ToString();
            abtemp.VocationType.ID = cbVocationType.Tag.ToString();
            abtemp.VocationArea = tbVocationArea.Text;
            abtemp.VocationCardNO = tbVocationCardNO.Text;
            abtemp.AbilityCardNO = tbAbilityCardNO.Text;
            abtemp.Remark = tbRemark.Text;
            abtemp.Employee.ID = tbEmplCode.Text;
            abtemp.ID = this.happenNO;

            return abtemp;
        }

        #endregion

    }
}
