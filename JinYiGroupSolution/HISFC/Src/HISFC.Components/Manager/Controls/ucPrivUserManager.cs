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
    /// [功能描述: 人员权限维护]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－12－4]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPrivUserManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {

        //人员权限分配明细管理类
        Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager userMgr = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
        //人员管理类
        Neusoft.HISFC.BizLogic.Manager.Person psMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
        //人员权限明细实体类
        Neusoft.HISFC.Models.Admin.UserPowerDetail userPowerDetail = new Neusoft.HISFC.Models.Admin.UserPowerDetail();
        
        /// <summary>
        /// 人员权限明细属性
        /// </summary>
        public Neusoft.HISFC.Models.Admin.UserPowerDetail UserPowerDetail
        {
            get
            {
                return this.userPowerDetail;
            }
            set
            {
                this.userPowerDetail = value;
            }
        }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ucPrivUserManager()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 有参构造函数， 传对象
        /// </summary>
        /// <param name="userPD"></param>
        public ucPrivUserManager(Neusoft.HISFC.Models.Admin.UserPowerDetail userPD)
        {
            InitializeComponent();
            this.userPowerDetail = userPD;
            init();
        }
        
        /// <summary>
        /// 初始化方法
        /// </summary>
        private void init()
        {
            #region 初始化权限明细ListView

            //权限等级管理类，针对等级3，等级3包括1，2等级的信息
            Neusoft.HISFC.BizLogic.Manager.PowerLevelManager powerManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();
          
            //现实所在大类下的所有权限
            ArrayList al = powerManager.LoadLevel3ByLevel1(this.userPowerDetail.Class1Code);//根据一级权限编码取所有2，3级权限信息
            if (al == null)
            {
                MessageBox.Show(powerManager.Err);
                return;
            }

            ListViewItem lvi;
            //将获得改大类下具有的所有权限填充到ListView中
            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass3 info in al)
            {
                //设置插入的节点信息
                lvi = new ListViewItem();
                lvi.Text = info.Name;

                //Tag属性保存摆药单分类实体
                lvi.Tag = info;

                //设置listView的子节点
                lvi.SubItems.Add(info.PowerLevelClass2.Class2Name);

                //返回插入的节点
                this.lvPrivList.Items.Add(lvi);
            }
            #endregion

            //取用户在此处拥有的三级权限，并显示在ListView中。
            this.ShowUserPriv();

            //将人员信息显示在控件中
            this.lblCode.Text = this.userPowerDetail.User.ID;
            this.comboName.Text = this.userPowerDetail.User.Name;
            this.lblDeptName.Text = this.userPowerDetail.Dept.Name;
            this.txtMark.Text = this.userPowerDetail.Memo;
            this.comboRole.Tag = this.userPowerDetail.RoleCode;


            //只有在增加人员时才可以修改人员
            if (this.userPowerDetail.User.ID == "")
            {
                this.btnChooseUser.Enabled = true;
                this.btDelete.Enabled = false;
            }
            else
            {
                this.btnChooseUser.Enabled = false;
                this.btDelete.Enabled = true;
            }

            #region  初始化人员维护下ComboBox
            //界面初始化1
            initInfo();
            #endregion 
            
            #region 人员基本信息
            //界面初始化2
            //如果用户编码为空则返回
            if (this.userPowerDetail.User.ID == "") return;

            //人员实体
            Neusoft.HISFC.Models.Base.Employee person = this.psMgr.GetPersonByID(this.userPowerDetail.User.ID);
            setInfo(person);

              #endregion
        }

        #region 界面初始化
        /// <summary>
        /// 界面初始化
        /// </summary>
        void initInfo()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList depertments = deptMgr.GetDeptNoNurse();//取除护士站以外的科室列表

            if (depertments == null)
            {
                MessageBox.Show(deptMgr.Err);
                return;
            }
            //初始化科室类型选项
            this.comboDeptType.IsListOnly = true;
            this.comboDeptType.AddItems(depertments);
            
            //初始化人员类型选项
            this.comboPersonType.IsListOnly = true;
            this.comboPersonType.AddItems(Neusoft.HISFC.Models.Base.EmployeeTypeEnumService.List());

            //初始化人员性别选项
            this.comboPersonSex.IsListOnly = true;
            this.comboPersonSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());

            //初始化护理站选项
            ArrayList nurseList = deptMgr.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
            this.comboPersonNurse.IsListOnly = true;
            this.comboPersonNurse.AddItems(nurseList);

            //初始化职务选项
            this.comboPersonDuty.IsListOnly = true;
            this.comboPersonDuty.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.POSITION));//系统常数枚举类

            //初始化职级代号选项
            this.comboPersonLevel.IsListOnly = true;
            this.comboPersonLevel.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.LEVEL));

            //初始化学历选项

            this.comboPersonEdu.IsListOnly = true;
            this.comboPersonEdu.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.EDUCATION));

        }
        
        #region 获取常数方法
        /// <summary>
        /// 获取常数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ArrayList GetConstant(Neusoft.HISFC.Models.Base.EnumConstant type)
        {
           Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList constList = consManager.GetList(type);
            if (constList == null)
                throw new Neusoft.FrameWork.Exceptions.ReturnNullValueException();
            return constList;
        }
        #endregion
       #endregion

        #region  根据用户编码获得的用户信息添加控件
        /// <summary>
        /// 根据用户编码获得的用户信息添加控件
        /// </summary>
        /// <param name="person"></param>
        void setInfo(Neusoft.HISFC.Models.Base.Employee person)
        {
            if (person ==null) return;
            //根据用户编码－－加载多科室
            AddDeptDetial(person.ID);

            this.txtPersonCode.Text = person.ID;//人员编码
            this.txtPersonName.Text= person.Name;//人员姓名
            this.txtPersonSpellCode.Text = person.SpellCode;//拼音码
            this.txtPersonWBCode.Text = person.WBCode;//五笔码
            this.comboPersonSex.Tag = person.Sex.ID;//性别
            if (person.Birthday.ToString() == DateTime.MinValue.ToString())
                this.dtBirthday.Value = DateTime.Now;
            else
                this.dtBirthday.Value = person.Birthday;//出生日期  
            this.comboPersonEdu.Tag = person.GraduateSchool.ID;//学历,毕业学校
            this.txtPersonIDCard.Text = person.IDCard;//身份证
            this.comboPersonDuty.Tag = person.Duty.ID;//职务
            this.comboPersonLevel.Tag = person.Level.ID;//职级
            this.comboDeptType.Tag = person.Dept.ID;//所属科室
            this.comboPersonNurse.Tag = person.Nurse.ID;//所属护理站
            this.comboPersonType.Tag = person.EmployeeType.ID;//人员类型
            this.txtSortID.Text = person.SortID.ToString();//排序号

            this.chbCanModifty.Checked = person.IsCanModify;//是否可以修改票据
            this.chbExpert.Checked = person.IsExpert;//是否为专家
            this.chbCanFee.Checked = person.IsNoRegCanCharge;//是否具有直接收费权限

            //是否有效
            if (person.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
            {
                chbValidState.Checked = true;
            }
            else
            {
                chbValidState.Checked = false;
            }
        }
        #endregion

        /// <summary>
        /// 加载多科室
        /// </summary>
        private void AddDeptDetial(string EmployeCode)
        {
            if (EmployeCode == "")
            {
                this.neuSpread1_Sheet1.RowCount = 0;
            }
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deMgr = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            
            //根据人员编码提取操作员可以登陆的科室信息
            ArrayList list = deMgr.GetMultiDept(EmployeCode);
            foreach (Neusoft.HISFC.Models.Base.DepartmentStat info in list)
            {
               this.neuSpread1_Sheet1.Rows.Add(0, 1);
               this.neuSpread1_Sheet1.Cells[0, 0].Text = info.DeptName;
            }
        }

        #region  取用户在此处拥有的三级权限，并显示在ListView中。
        /// <summary>
        /// 取用户在此处拥有的三级权限，并显示在ListView中。
        /// </summary>
        public void ShowUserPriv()
        {
            this.lvPrivList.BeginUpdate();
            this.ClearListView();
            //取用户在此处拥有的三级权限
            ArrayList al = this.userMgr.LoadByUserCode(this.userPowerDetail.User.ID, this.userPowerDetail.Class1Code, this.userPowerDetail.Dept.ID);
            if (al == null)
            {
                MessageBox.Show(this.userMgr.Err);
                return;
            }
            //在权限明细列表中显示当前用户拥有的权限
            Neusoft.HISFC.Models.Admin.PowerLevelClass3 class3;
            foreach (Neusoft.HISFC.Models.Admin.UserPowerDetail info in al)
            {
                //在ListView中查找相同的项目，并将checked属性置为true
                foreach (ListViewItem lvi in this.lvPrivList.Items)
                {
                    class3 = lvi.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass3;
                    if (class3.Class3Code == info.PowerLevelClass.Class3Code && class3.Class2Code == info.Class2Code)
                    {
                        lvi.Checked = true;
                    }
                }
            }
            this.lvPrivList.EndUpdate();
        }
        #endregion
        /// <summary>
        /// 清空ListView中的checked属性
        /// </summary>
        public void ClearListView()
        {
            foreach (ListViewItem lvi in this.lvPrivList.Items)
            {
                lvi.Checked = false;
            }
        }

        private void btnChooseUser_Click(object sender, EventArgs e)
        {
            ChooseUser();
        }

        #region 选择人员
        /// <summary>
        /// 选择人员
        /// </summary>
        /// <param name="al"></param>
        private void GetPersonObj(ArrayList al)
        {
            Neusoft.FrameWork.WinForms.Forms.frmEasyChoose form = new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose(al);
            form.SelectedItem+=new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(form_SelectedItem);
            form.ShowDialog();
        }
        /// <summary>
        /// 选择人员事件
        /// </summary>
        /// <param name="neuObj">人员信息</param>
        private void form_SelectedItem(Neusoft.FrameWork.Models.NeuObject neuObj)
        {
            //取返回数据的编码和名称
            this.lblCode.Text = neuObj.ID;
            this.comboName.Text = neuObj.Name;
            Neusoft.HISFC.Models.Base.Employee objPer = this.psMgr.GetPersonByID(neuObj.ID);
            if (objPer == null)
            {
                MessageBox.Show("查询人员信息失败");
                return;
            }

            this.setInfo(objPer);

            #region 默认选中多科室
            foreach (ListViewItem lvi in this.lvPrivList.Items)
            {
                Neusoft.HISFC.Models.Admin.PowerLevelClass3 class3 = lvi.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass3;
                if (class3.Class3Code == "01" && class3.Class2Code == "0000")
                {
                    lvi.Checked = true;
                }
            }
            #endregion
            this.txtMark.Focus();
        }

        /// <summary>
        /// 选择人员
        /// </summary>
        private void ChooseUser()
        {
            //取此统计分类下面不存在的人员
            Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();
            ArrayList al = person.GetEmployeeForStat(this.userPowerDetail.Class1Code, this.userPowerDetail.Dept.ID);
            if (al == null)
            {
                MessageBox.Show(person.Err);
                return;
            }
            GetPersonObj(al);
            //Neusoft.FrameWork.Models.NeuObject neuObj = null; 
            //if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(al, ref neuObj) == 0) return;

            ////取返回数据的编码和名称
            //this.lblCode.Text = neuObj.ID;
            //this.comboName.Text = neuObj.Name;
            //Neusoft.HISFC.Models.Base.Employee objPer = this.psMgr.GetPersonByID(neuObj.ID);
            //if (objPer == null)
            //{
            //    MessageBox.Show("查询人员信息失败");
            //    return;
            //}

            //this.setInfo(objPer);

            //#region 默认选中多科室
            //foreach (ListViewItem lvi in this.lvPrivList.Items)
            //{
            //    Neusoft.HISFC.Models.Admin.PowerLevelClass3 class3 = lvi.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass3;
            //    if (class3.Class3Code == "01" && class3.Class2Code == "0000")
            //    {
            //        lvi.Checked = true;
            //    }
            //}
            //#endregion
            //this.txtMark.Focus();
        }
        #endregion

        #region 验证方法
        /// <summary>
        ///  验证方法
        /// </summary>
        /// <returns></returns>
        private bool ValidateState()
        {
            if (this.lblCode.Text == "")
            {
                MessageBox.Show("请选择要添加的人员！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if(this.lvPrivList.CheckedItems.Count==0)
            {
                MessageBox.Show("请选择要授予的权限！", "提示", MessageBoxButtons.OK);
                return false;
            }
            if (this.txtPersonCode.Text.Trim() == "")
            {
                MessageBox.Show("人员代码不能为空！", "提示", MessageBoxButtons.OK);
                this.txtPersonCode.Focus();
                return false;
            }
            if(Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtPersonCode.Text,6)==false)
            {
                MessageBox.Show("人员代码过长，请保持六位字符！", "提示", MessageBoxButtons.OK);
                this.txtPersonCode.Focus();
                return false;
            }
            if(this.txtPersonName.Text.Trim()=="")
            {
                MessageBox.Show("人员姓名不能位空！", "提示", MessageBoxButtons.OK);
                this.txtPersonName.Focus();
                return false;
            }
            if(Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtPersonName.Text,10)==false)
            {
                MessageBox.Show("人员姓名过长，请保持五位汉字或十位字符！", "提示", MessageBoxButtons.OK);
                this.txtPersonName.Focus();
                return false;
            }
            if(this.comboPersonSex.Text=="")
            {
                MessageBox.Show("人员性别不能位空！", "提示", MessageBoxButtons.OK);
                this.comboPersonSex.Focus();
                return false;
            }
            if(this.comboPersonDuty.Text=="")
            {
                MessageBox.Show("职务代号不能位空！", "提示", MessageBoxButtons.OK);
                this.comboPersonDuty.Focus();   
                return false;
            }
            if(this.comboDeptType.Text=="")
            {
                MessageBox.Show("所属科室不能为空！", "提示", MessageBoxButtons.OK);
                this.comboDeptType.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region  从页面获得数据
        /// <summary>
        /// 从页面获得数据
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Employee getPerson()
        {
            Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();

            employee.ID = this.txtPersonCode.Text.Trim();//员工代码
            employee.Name = this.txtPersonName.Text.Trim();//员工姓名
            employee.SpellCode = this.txtPersonSpellCode.Text.Trim();//拼音码
            employee.WBCode = this.txtPersonWBCode.Text.Trim();//五笔码
            employee.Sex.ID = this.comboPersonSex.Tag;//性别
            employee.Birthday = this.dtBirthday.Value;//出生日期 
            if (this.comboPersonEdu.Tag == null)
            {
                employee.GraduateSchool.ID = "";
            }
            else
            {
                employee.GraduateSchool.ID = this.comboPersonEdu.Tag.ToString() ;//学历
            }
            employee.IDCard = this.txtPersonIDCard.Text.Trim();//身份证
            if (this.comboPersonDuty.Tag == null)
            {
                employee.Duty.ID= "";
            }
            else
            {
                employee.Duty.ID = this.comboPersonDuty.Tag.ToString();//职务代码
            }
            if (this.comboPersonLevel.Tag == null)
            {
                employee.Level.ID = "";
            }
            else
            {
                employee.Level.ID = this.comboPersonLevel.Tag.ToString();//职级代码
            }
            if (this.comboDeptType.Tag ==null)
            {
                employee.Dept.ID = "";
            }
            else
            {
                employee.Dept.ID = this.comboDeptType.Tag.ToString();//所属科室
            }
            if (this.comboPersonNurse.Tag == null)
            {
                employee.Nurse.ID = "";
            }
            else
            {
                employee.Nurse.ID = this.comboPersonNurse.Tag.ToString();//所属护理站
            }
            employee.EmployeeType.ID = this.comboPersonType.Tag.ToString();//人员类型
            employee.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtSortID.Text);//顺序号
            
                employee.IsCanModify = this.chbCanModifty.Checked;//能改票据
            
                employee.IsExpert = this.chbExpert.Checked;//是否为专家
            
                employee.IsNoRegCanCharge = this.chbCanFee.Checked;//是否直接收费
            
          
            if (this.chbValidState.Checked)//是否有效
            {
                employee.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
            }
            else
            {
                employee.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
            }

            return employee;
        }
        #endregion

        #region 保存方法
        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            this.lblCode.Text = this.txtPersonCode.Text;
            this.comboName.Text = this.txtPersonName.Text;
            if (ValidateState())
            {
                Neusoft.HISFC.Models.Base.Employee objEmployee = this.getPerson();
                
                if (objEmployee == null)
                {
                    MessageBox.Show("获取人员信息失败！");
                    return;
                }
                this.userPowerDetail.GrantFlag = true;
                this.userPowerDetail.Memo = this.txtMark.Text;//备注
                this.userPowerDetail.User.ID = this.lblCode.Text;//人员编码
                this.userPowerDetail.User.Name = this.comboName.Text;//人员名称

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.userMgr.Connection);
                //trans.BeginTransaction();
                this.userMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);//人员权限分配明细管理类-设置当前事务
                this.psMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);//人员管理类-设置当前事务
                try
                {
                    #region 人员信息维护
                    if (this.psMgr.Update(objEmployee)<=0)
                    {
                        MessageBox.Show(this.psMgr.Err);
                        
                        if (this.psMgr.Insert(objEmployee)<=0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show("保存人员信息失败！"+this.psMgr.Err);
                            return;
                        }
                    }
                    #endregion

                    //删除用户在此处的权限
                    if (this.userMgr.Delete(this.userPowerDetail.User.ID, this.userPowerDetail.Class1Code, this.userPowerDetail.Dept.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show(this.userMgr.Err);
                        return;
                    }
                    foreach(ListViewItem lvi in this.lvPrivList.CheckedItems)
                    {
                        Neusoft.HISFC.Models.Admin.PowerLevelClass3 level3 = lvi.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass3;
                        this.userPowerDetail.Class2Code = level3.Class2Code;
                        this.userPowerDetail.PowerLevelClass.Class3Code = level3.Class3Code;
                        //插入用户权限列表
                        if (this.userMgr.InsertUserPowerDetail(this.userPowerDetail) != 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show("数据保存失败！"+this.userMgr.Err);
                            return;
                        }
                    }

                }
                catch (Exception e)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("数据保存失败！"+e.Message,"提示");
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("数据保存成功！");
                this.FindForm().DialogResult = DialogResult.OK;

            }

        }
        #endregion

        #region 删除方法
        /// <summary>
        /// 删除方法
        /// </summary>
        private void Delete()
        {

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

           //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.userMgr.Connection);
           // trans.BeginTransaction();
            userMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                //删除此用户在此处拥有的权限
                int parm = userMgr.Delete(this.userPowerDetail.User.ID, this.userPowerDetail.Class1Code, this.userPowerDetail.Dept.ID);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(userMgr.Err);
                    return;
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show("删除人员数据失败！" + e.Message, "提示");
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.FindForm().DialogResult = DialogResult.OK;
            MessageBox.Show("删除人员成功！");
        }
        #endregion

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void txtPersonName_TextChanged(object sender, EventArgs e)
        {
            this.comboName.Text = this.txtPersonName.Text;
        }

        private void txtPersonCode_TextChanged(object sender, EventArgs e)
        {
            this.lblCode.Text = this.txtPersonCode.Text;
        }

        private void comboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCode.Text = this.comboName.Tag.ToString();
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl1.SelectedIndex == 1)
            {
                this.comboName.Focus();
            }
        }

        private void txtPersonName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(Char)13)
            System.Windows.Forms.SendKeys.Send("{Tab}");
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            //调用保存方法
            this.Save();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (this.userPowerDetail.User.ID == "") return;
            if(MessageBox.Show("确认要删除该人员么？","删除提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            //调用删除方法
            this.Delete();
        }

    }
}
