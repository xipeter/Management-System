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
    /// [功能描述: 人员维护]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－12－11]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucEmployeeInfoPanel : UserControl
    {   
        //人员管理类
        Neusoft.HISFC.BizLogic.Manager.Person personMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
        //拼音管理类
        Neusoft.HISFC.BizLogic.Manager.Spell spellMgr = new Neusoft.HISFC.BizLogic.Manager.Spell();
        //人员实体类
        Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
        public bool tr = false;//判断刷新
        private bool isModify = false;//是否修改
        /// <summary>
        /// 是否可以修改
        /// </summary>
        public bool IsModify
        {
            get
            {
                return this.isModify;
            }
            set
            {
                this.txtEmployeeCode.ReadOnly = value;
                this.btAutoID.Visible = !value;
            }
        }
        //{3BAA59AB-14DE-496e-B77A-E7C298D3245B}
        private bool isModifedlevelAndRemark = false;
        //{3BAA59AB-14DE-496e-B77A-E7C298D3245B}
        public bool IsModifedlevelAndRemark
        {
            get { return isModifedlevelAndRemark; }
            set
            {
                isModifedlevelAndRemark = value;
                //{3BAA59AB-14DE-496e-B77A-E7C298D3245B}
                if (this.isModifedlevelAndRemark == true )
                {
                    this.SetEnable();
                }
            }
        }

        
     
        public ucEmployeeInfoPanel()
        {
            InitializeComponent();
            InitialCombox();
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="empl"></param>
        public ucEmployeeInfoPanel(Neusoft.HISFC.Models.Base.Employee empl)
        {
            InitializeComponent();
            this.bttAdd.Visible = false;
            this.txtEmployeeCode.ReadOnly = false;
            this.employee = empl;
            InitialCombox();
            setInfoToControls();
        }

        /// <summary>
        /// 初始化ComboBox选项
        /// </summary>
        private void InitialCombox()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptMgr=new Neusoft.HISFC.BizLogic.Manager.Department();
            //只显示除了护士站以外的科室列表
            ArrayList aldepartments = deptMgr.GetDeptNoNurse();
            this.comboDeptType.IsListOnly = true;
            this.comboDeptType.AddItems(aldepartments);//填充所属科室ComboBox

            this.comboPersonType.IsListOnly = true;
            this.comboPersonType.AddItems(Neusoft.HISFC.Models.Base.EmployeeTypeEnumService.List());//填充人员类型下内容

            this.comboSex.IsListOnly = true;
            this.comboSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());//性别

            ArrayList alNurseDept = deptMgr.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
            this.comboNurse.IsListOnly = true;
            this.comboNurse.AddItems(alNurseDept);//所属护理站下内容

            this.comboDuty.IsListOnly = true;
            this.comboDuty.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.POSITION));//职务

            this.comboLevel.IsListOnly = true;
            this.comboLevel.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.LEVEL));//职级

            this.comboPersonEdu.IsListOnly = true;
            this.comboPersonEdu.AddItems(GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.EDUCATION));//学历
            
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

            ArrayList constList = consManager.GetList(type);
            if (constList == null)
                throw new Neusoft.FrameWork.Exceptions.ReturnNullValueException();
            
            
            return constList;
         
        }
        
        /// <summary>
        /// 根据传入对象信息填充UC
        /// </summary>
        private void setInfoToControls()
        {
            this.txtEmployeeCode.Text = this.employee.ID;//人员编码 
            this.txtEmployeeName.Text = this.employee.Name;//人员姓名
            this.txtSpell_Code.Text = this.employee.SpellCode;//拼音码
            this.txtWB_Code.Text = this.employee.WBCode;//五笔码
            this.comboSex.Tag = this.employee.Sex.ID;//性别

            //[2007-01-25]防止.NET与ORACLE表示范围不同
            //{997CB50F-1CE4-40d3-9A67-5128EAA10FD7}
            this.comboBirthday.Value = this.employee.Birthday;//出生日期
            //if (this.employee.Birthday.CompareTo(DateTime.MinValue.AddYears(1969)) <= 0 )
            //{
            //    this.comboBirthday.Value = DateTime.MinValue.AddYears(1969);
            //}
            //else
            //{
            //    this.comboBirthday.Value = this.employee.Birthday;//出生日期
            //}

            this.comboPersonEdu.Tag = this.employee.GraduateSchool.ID;//毕业学校
            this.txtIdentity.Text = this.employee.IDCard;//身份证
            this.comboDuty.Tag = this.employee.Duty.ID;//职务
            this.comboLevel.Tag = this.employee.Level.ID;//职级
            this.comboDeptType.Tag = this.employee.Dept.ID;//所属科室
            this.comboNurse.Tag = this.employee.Nurse.ID;//所属护理站
            this.comboPersonType.Tag = this.employee.EmployeeType.ID;//人员类型
            this.numSortId.Text = this.employee.SortID.ToString();//顺序号
            if (this.employee.IsExpert)//是否为专家
            {
                this.neuRadioButton1.Checked=true;
            }
            else
            {
                this.neuRadioButton2.Checked=true;
            }
            if (this.employee.IsCanModify)//是否能改票据
            {
                this.neuRadioButton3.Checked=true;
            }
            else
            {
                this.neuRadioButton4.Checked=true;
            }
            if (this.employee.IsNoRegCanCharge)//是否直接收费
            {
                this.neuRadioButton5.Checked=true;
            }
            else
            {
                this.neuRadioButton6.Checked=true;
            }
            switch (this.employee.ValidState)//有效性
            {
                case Neusoft.HISFC.Models.Base.EnumValidState.Valid:
                    this.radioValidate1.Checked=true;
                    break;
                case Neusoft.HISFC.Models.Base.EnumValidState.Invalid:
                    this.radioValidate2.Checked=true;
                    break;
                case Neusoft.HISFC.Models.Base.EnumValidState.Ignore:
                    this.radioValidate3.Checked=true;
                    break;
                default:
                    break;
            }
            this.txtUser_Code.Text = this.employee.UserCode;
            //{6A8C59DC-91FE-4246-A923-06A011918614}
            this.rtxtMark.SuperText = this.employee.Memo;

            #region donggq--20101118--{45E71A4E-803A-47fd-AC24-9BED6E530F16}--数字签名

            byte[] digitalSign = personMgr.GetEmplDigitalSignByID(employee.ID);
            if (digitalSign != null)
            {
                System.IO.MemoryStream msPic = new System.IO.MemoryStream(digitalSign);
                Bitmap bmpt = new Bitmap(msPic);
                this.picBox.Image = bmpt;
            } 

            #endregion


        }

        /// <summary>
        /// 验证方法
        /// </summary>
        /// <returns></returns>
        private bool ValueValidated()
        {   
            //人员代码不能为空
            if (this.txtEmployeeCode.Text.Trim() == "")
            {
                MessageBox.Show("人员代码不能为空！", "提示", MessageBoxButtons.OK);
                this.txtEmployeeCode.Focus();
                return false;
            }
            //人员代码长度不能超过6位字符
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtEmployeeCode.Text.Trim(), 6) == false)
            {
                MessageBox.Show("人员代码过长,请保持六位字符!", "提示", MessageBoxButtons.OK);
                this.txtEmployeeCode.Focus();
                return false;
            }
            //人员名称不能为空
            if (this.txtEmployeeName.Text.Trim() == "")
            {
                MessageBox.Show("人员名称不能为空！", "提示", MessageBoxButtons.OK);
                this.txtEmployeeName.Focus();
                return false;
            }
            //人员名称长度不能超过10位字符
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtEmployeeName.Text.Trim(), 10) == false)
            {
                MessageBox.Show("人员名称过长,请保持5位字汉字或10位字符!", "提示", MessageBoxButtons.OK);
                this.txtEmployeeName.Focus();
                return false;
            }
            //人员性别不能为空
            if (this.comboSex.Text == "")
            {
                MessageBox.Show("人员性别不能为空！", "提示", MessageBoxButtons.OK);
                this.comboSex.Focus();
                return false;
            }
            //职务代号不能为空
            if (this.comboDuty.Text == "")
            {
                MessageBox.Show("职务代号不能为空！", "提示", MessageBoxButtons.OK);
                this.comboDuty.Focus();
                return false;
            }
            //职级代号不能为空
            if (this.comboLevel.Text == "")            
            {
                MessageBox.Show("职级代号不能为空！","提示",MessageBoxButtons.OK);
                this.comboLevel.Focus();
                return false;
            }
            //人员类型不能为空
            if (this.comboPersonType.Text == "")
            {
                MessageBox.Show("人员类型不能为空！","提示",MessageBoxButtons.OK);
                this.comboPersonType.Focus();
                return false;
            }
            //所属科室不能为空
            if (this.comboDeptType.Text == "")
            {
                MessageBox.Show("所属科室不能为空！", "提示", MessageBoxButtons.OK);
                this.comboDeptType.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清空控件内容恢复原状态
        /// </summary>
        private void ClearUp()
        {
            this.txtEmployeeCode.Text = "";
            this.txtEmployeeName.Text = "";
            this.txtIdentity.Text = "";
            this.txtSpell_Code.Text = "";
            this.txtWB_Code.Text = "";
            this.txtUser_Code.Text = "";
            this.comboBirthday.Value = DateTime.Now;
            this.comboDeptType.SelectedIndex = -1;
            this.comboDuty.SelectedIndex = -1;
            this.comboLevel.SelectedIndex = -1;
            this.comboNurse.SelectedIndex = -1;
            this.comboSex.SelectedIndex = -1;
            this.comboPersonType.SelectedIndex = -1;
            this.comboPersonEdu.SelectedIndex = -1;
            this.radioValidate1.Checked = true;
            this.neuRadioButton2.Checked = true;
            this.neuRadioButton4.Checked = true;
            this.neuRadioButton6.Checked = true;

            #region donggq--20101118--{45E71A4E-803A-47fd-AC24-9BED6E530F16}--数字签名

            this.picBox.ImageLocation = string.Empty;
            this.picBox.Image = null;

            #endregion
        }

        /// <summary>
        /// 将控件内容转换成人员实体
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee ConvertUcContextToObject()
        {
            Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
            employee.ID = this.txtEmployeeCode.Text.Trim();//人员编码
            employee.Name = this.txtEmployeeName.Text.Trim();//人员姓名
            employee.SpellCode = this.txtSpell_Code.Text.Trim();//拼音码
            employee.WBCode = this.txtWB_Code.Text.Trim();//五笔码
            employee.Sex.ID = this.comboSex.Tag.ToString();//性别

            //[2007-01-25]防止.NET与ORACLE表示范围不同
            if (this.comboBirthday.Checked)
            {
                employee.Birthday = this.comboBirthday.Value;//出生日期
            }
            else
            {
                employee.Birthday = DateTime.MinValue.AddYears(1969);//默认为0001年
            }

            employee.GraduateSchool.ID = this.comboPersonEdu.Tag.ToString();//毕业学校
            employee.IDCard = this.txtIdentity.Text.Trim();//身份证
            employee.Duty.ID = this.comboDuty.Tag.ToString();//职务
            employee.Level.ID = this.comboLevel.Tag.ToString();//职级
            employee.Dept.ID = this.comboDeptType.Tag.ToString();//所属科室
            employee.Nurse.ID = this.comboNurse.Tag.ToString();//所属护理站
            employee.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.numSortId.Text.Trim());//顺序号
            employee.EmployeeType.ID = this.comboPersonType.Tag.ToString();//人员类别
            if (this.neuRadioButton1.Checked)
            {
                employee.IsExpert = true;//是否为专家
            }
            else
            {
                employee.IsExpert = false;
            }
            if (this.neuRadioButton3.Checked)
            {
                employee.IsCanModify = true;//能否改票据
            }
            else
            {
                employee.IsCanModify = false;
            }
            if (this.neuRadioButton5.Checked)
            {
                employee.IsNoRegCanCharge = true;//能否直接收费
            }
            else
            {
                employee.IsNoRegCanCharge = false;
            }
            if (this.radioValidate1.Checked)
            {
                employee.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
            }
            else if (this.radioValidate2.Checked)
            {
                employee.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
            }
            else
            {
                employee.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Ignore;
            }
            employee.UserCode = this.txtUser_Code.Text;
            //{6A8C59DC-91FE-4246-A923-06A011918614}
            employee.Memo = this.rtxtMark.Text;

            #region donggq--20101118--{45E71A4E-803A-47fd-AC24-9BED6E530F16}--数字签名

            if (!string.IsNullOrEmpty(this.picBox.ImageLocation)) 
            {
                System.IO.FileStream stream = new System.IO.FileStream(this.picBox.ImageLocation, System.IO.FileMode.Open);
                byte[] byteimg = new byte[stream.Length];
                stream.Read(byteimg, 0, (int)stream.Length);
                stream.Close();
                employee.EmployeeExt.DigitalSign = byteimg;
            }
            else
            {
                employee.EmployeeExt.DigitalSign = null;
            }

            #endregion

            return employee;
        }

        private void bttCancle_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        //private void txtEmployeeCode_Leave(object sender, EventArgs e)
        //{
        //    if (this.txtEmployeeCode.Text != "")
        //    {
        //        if (this.txtEmployeeCode.ReadOnly == false)
        //        {
        //            this.txtEmployeeCode.Text = this.txtEmployeeCode.Text.PadLeft(6, '0');
        //            Neusoft.HISFC.BizLogic.Manager.Person ps = new Neusoft.HISFC.BizLogic.Manager.Person();
        //            int temp = ps.SelectEmployIsExist(this.txtEmployeeCode.Text);
        //            if (temp == -1)
        //            {
        //                MessageBox.Show("查询出错,编码可能会重复");
        //            }
        //            else if (temp == 1)
        //            {
        //                MessageBox.Show("编码已经存在，请重新输入");
        //                this.txtEmployeeCode.Focus();
        //                this.txtEmployeeCode.Text = "";
        //            }
        //        }
        //    }
          
        //}

        private void txtEmployeeCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtEmployeeCode.Text != "")
                {
                    if (this.txtEmployeeCode.ReadOnly == false)
                    {
                        this.txtEmployeeCode.Text = this.txtEmployeeCode.Text.PadLeft(6, '0');
                        Neusoft.HISFC.BizLogic.Manager.Person ps = new Neusoft.HISFC.BizLogic.Manager.Person();
                        int temp = ps.SelectEmployIsExist(this.txtEmployeeCode.Text);
                        if (temp == -1)
                        {
                            MessageBox.Show("查询出错,编码可能会重复");
                        }
                        else if (temp == 1)
                        {
                            MessageBox.Show("编码已经存在，请重新输入");
                            this.txtEmployeeCode.Focus();
                            this.txtEmployeeCode.Text = "";
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 根据人员姓名自动获得五笔码和拼音码
        /// </summary>
        private void CreateSpell()
        {
            if (this.txtSpell_Code.Text.Trim() == "" || this.txtWB_Code.Text.Trim() == "")
            {
                Neusoft.HISFC.Models.Base.Spell spell = new Neusoft.HISFC.Models.Base.Spell();
                spell = (Neusoft.HISFC.Models.Base.Spell)spellMgr.Get(this.txtEmployeeName.Text.Trim());
                this.txtSpell_Code.Text = spell.SpellCode;
                this.txtWB_Code.Text = spell.WBCode;
            }
        }
        private void txtEmployeeName_Leave(object sender, EventArgs e)
        {
            CreateSpell();//获得五笔码和拼音码
            
        }

        private void bttConfrim_Click(object sender, EventArgs e)
        {
            if (Save() == 0)
            this.FindForm().DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        public int Save()
        {   
            //验证控件内容符合要求
            if (ValueValidated())
            {
                Neusoft.HISFC.Models.Base.Employee empl = ConvertUcContextToObject();
                if (empl == null) return -1;
                //生成拼音码和五笔码
                CreateSpell();
                try
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    Neusoft.HISFC.BizLogic.Manager.Person perMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
                    //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(perMgr.Connection);
                    ////事务开始
                    //trans.BeginTransaction();
                    ////设置事务
                    //perMgr.SetTrans(trans.Trans);
                    if (perMgr.Insert(empl) == -1)
                    {
                        if (perMgr.DBErrCode == 1)
                        {
                            if (perMgr.Update(empl) == -1 || perMgr.Update(empl) == 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("更新人员失败！");
                                return -1;
                            }
                        }
                        else
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("插入人员失败！");
                            return -1;
                        }
                    }

                    if (empl.EmployeeExt.DigitalSign != null) 
                    {
                        if (perMgr.InsertEmpExinfo(empl) == 1)
                        {
                            int val = perMgr.UpdateEmplDigitalSignByID(empl.ID, empl.EmployeeExt.DigitalSign);
                            if (val == -1 || val == 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("更新人员扩展信息失败！");
                                return -1;
                            }
                        }
                        else if (perMgr.DBErrCode == 1) 
                        {
                            int val = perMgr.UpdateEmplDigitalSignByID(empl.ID, empl.EmployeeExt.DigitalSign);
                            if ( val == -1 || val == 0 )
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("更新人员扩展信息失败！");
                                return -1;
                            }
                        }
                        else
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("插入人员扩展信息失败！");
                            return -1;
                        }
                    }


                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show("保存成功！");
                    tr = true;
                    this.txtEmployeeCode.Focus();
                    return 0;
                   
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);     
                    return -1;                                   
                }
              
            }
            else 
            {
                return -1;
            }
          
        }

        private void txtEmployeeCode_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            System.Windows.Forms.SendKeys.Send("{Tab}");
        }

        private void numSortId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.neuRadioButton1.Focus();
                this.txtUser_Code.Focus();
            }
        }

        private void neuRadioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.neuRadioButton3.Focus();
            }
        }

        private void neuRadioButton3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.neuRadioButton5.Focus();
            }
        }

        private void neuRadioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.neuRadioButton3.Focus();
            }
        }

        private void neuRadioButton4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.neuRadioButton5.Focus();
            }
        }

        private void neuRadioButton5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.radioValidate1.Focus();
            }
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            if (Save() == 0)//如果保存成功则清空控件内容接着输入
                ClearUp();
        }

        private void txtUser_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.neuRadioButton1.Focus();
                
            }
        }

        /// <summary>
        /// [2007/08/16]失去焦点时判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmployeeCode_Leave(object sender, EventArgs e)
        {
            if (this.txtEmployeeCode.Text != "")
            {
                if (this.txtEmployeeCode.ReadOnly == false)
                {
                    this.txtEmployeeCode.Text = this.txtEmployeeCode.Text.PadLeft(6, '0');
                    Neusoft.HISFC.BizLogic.Manager.Person ps = new Neusoft.HISFC.BizLogic.Manager.Person();
                    int temp = ps.SelectEmployIsExist(this.txtEmployeeCode.Text);
                    if (temp == -1)
                    {
                        MessageBox.Show("查询出错,编码可能会重复");
                    }
                    else if (temp == 1)
                    {
                        MessageBox.Show("编码已经存在，请重新输入");
                        this.txtEmployeeCode.Focus();
                        this.txtEmployeeCode.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// 获取数据库中的最大人员编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuButton1_Click(object sender, EventArgs e)
        {
            string  MaxEmplID = "";
            int NextEmplID;
            MaxEmplID = this.personMgr.GetMaxEmployeeID();
            if (MaxEmplID == "" || MaxEmplID == null)
            {
                MessageBox.Show("数据库中未存储人员信息，请自行输入人员编码");
            }
            else
            {
                NextEmplID = Neusoft.FrameWork.Function.NConvert.ToInt32(MaxEmplID) + 1;
                if (NextEmplID == 1)
                {
                    MessageBox.Show("未能成功检索数据库中存储的人员信息，请自行输入人员编码");
                }
                else
                {
                    this.txtEmployeeCode.Text = NextEmplID.ToString().PadLeft(6, '0');
                }
            }
            this.txtEmployeeCode.Focus();
        }

        private void radioValidate1_KeyDown(object sender, KeyEventArgs e)
        {
            this.rtxtMark.Focus();
        }

        #region donggq--20101118--{45E71A4E-803A-47fd-AC24-9BED6E530F16}--数字签名

        /// <summary>
        /// 选择数字签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "bmp文件|*.bmp"; //jpg文件|*.jpg|gif文件|*.gif|png文件|*.png|
            open.ShowDialog();
            if (!string.IsNullOrEmpty(open.FileName))
            {
                if (System.IO.File.Exists(open.FileName))
                {
                    picBox.ImageLocation = open.FileName;
                }
                else
                {
                    MessageBox.Show("选定的文件不存在，请重新选择。");
                }
            }
            else
            {
                MessageBox.Show("请选择文件！");
            }
        }

        /// <summary>
        /// 清除数字签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDele_Click(object sender, EventArgs e)
        {
            this.picBox.Image = null;
            this.picBox.ImageLocation = null;
            this.employee.EmployeeExt.DigitalSign = null;

            Neusoft.HISFC.Models.Base.Employee empl = ConvertUcContextToObject();

            if (empl == null)
            {
                return;
            }

            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Neusoft.HISFC.BizLogic.Manager.Person perMgr = new Neusoft.HISFC.BizLogic.Manager.Person();

                if (perMgr.DeleEmplDigitalSignByID(empl.ID) == -1)
                {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("删除失败！");
                        return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("删除成功！");
                tr = true;
                return;

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                return;
            }

        }
        //{3BAA59AB-14DE-496e-B77A-E7C298D3245B}
        protected virtual int SetEnable()
        {
            
            foreach (Control item in this.neuGroupBox1.Controls)
            {
                if (item.Name == "comboLevel")
                {
                    continue;
                }
                if (item.Name == "rtxtMark")
                {
                    continue;
                }
                
                item.Enabled = false;
            }
            return 1;
        }
        #endregion


        
    }
}
