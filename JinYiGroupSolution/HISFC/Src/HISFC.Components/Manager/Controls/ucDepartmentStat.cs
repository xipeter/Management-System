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
    /// [功能描述: 科室结构维护]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－12－4]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDepartmentStat : UserControl
    {
        #region 变量
        
        //科室分类
        private Neusoft.HISFC.Models.Base.DepartmentStat departmentStat = null;
        //拼音管理类（拼音码，五笔码等）
        private Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();
        private Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //出入库管理类
        private Neusoft.HISFC.BizLogic.Manager.PrivInOutDept myPrivDept = new Neusoft.HISFC.BizLogic.Manager.PrivInOutDept();
        
        //科室类
        private Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
        private ArrayList alChooseDept = new ArrayList();
        
        //是否是在组织结构里添加科室
        bool isAddDept = true;
        	
        
#endregion

        #region  构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucDepartmentStat()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region 构造函数，传入科室信息
        /// <summary>
        /// 构造函数，传入科室信息
        /// </summary>
        /// <param name="dept"></param>
        public ucDepartmentStat(Neusoft.HISFC.Models.Base.DepartmentStat dept)
        {
            InitializeComponent();
            this.departmentStat = dept;
            Init();
        }
        #endregion

        #region 科室分类CheckedChanged动作
        private void chbClass_CheckedChanged(object sender, EventArgs e)
        {   
            //如果科室编码不为空
          //  if (this.deptment.DeptCode != null) return;
            
            //如果科室分类被选中
            if (this.chbClass.Checked)
            {
                this.comboDeptName.DropDownStyle = ComboBoxStyle.Simple;
                this.txtDeptSimpleName.Enabled = false;
                this.txtUserCode.Enabled = false;
                this.txtDeptEnglish.Enabled = false;
                this.comboDeptType.Enabled = false;
                this.comboDeptPro.Enabled = false;
                this.chbReg.Enabled = false;
                this.chbStop.Enabled = false;
                this.chbTat.Enabled = false;

                this.comboDeptName.Focus();
            }
            else
            {
                this.comboDeptName.DropDownStyle= ComboBoxStyle.DropDown;
                this.txtDeptSimpleName.Enabled = true;
                this.txtUserCode.Enabled = true;
                this.txtDeptEnglish.Enabled = true;
                this.comboDeptType.Enabled = true;
                this.comboDeptPro.Enabled = true;
                this.chbReg.Enabled = true;
                this.chbStop.Enabled = true;
                this.chbTat.Enabled = true;
            }

            this.comboDeptName.Text = "";
            this.txtDeptCode.Text = "";
            this.comboDeptName.Focus();
        }
        #endregion

        #region 控件初始化函数 Init()
        /// <summary>
        /// 控件初始化函数
        /// </summary>
        public void Init()
        {
            this.neuTabControl1.TabPages.Remove(this.tabPage2);
            this.neuTabControl1.TabPages.Remove(this.tabPage3);
            try
            {
                if (this.departmentStat.StatCode != "00")
                {
                    isAddDept = false;
                }
                //只有新增科室时，才可以选择科室，才可以操作是否是科室分类,才显示提示信息
                if (this.departmentStat.DeptCode == "")
                {
                    this.chbClass.Enabled = true;
                    
                }
                else
                {
                    //修改科室时，不能修改科室分类，不能选择其他科室,不显示提示信息
                    this.chbClass.Enabled = false;
                    
                }
                //将科室信息显示在控件中
                //节点类型：1终极科室，0科室分类。
                if (this.departmentStat.NodeKind == 1)
                    this.chbClass.Checked = false;
                else
                    this.chbClass.Checked = true;

                //获得全部正在使用的科室
                ArrayList deptList = deptMgr.GetDeptmentAll();

                //如果没有查到科室
                if (deptList == null)
                {
                    MessageBox.Show("获取科室信息失败" + deptMgr.Err);
                    return;
                }
                
                //查询Com_Department表 分别添加到2个ComboBox下
                this.comboDeptType.AddItems(Neusoft.HISFC.Models.Base.DepartmentTypeEnumService.List());
                this.comboDeptName.AddItems(deptList);
                

                //判断是虚科室还是实科室  虚科室的编码第一位是"S" 
                if (this.departmentStat.DeptCode.IndexOf("S") > -1 && this.departmentStat.DeptCode.Substring(0, 1) == "S") //虚科室
                {
                    this.chbClass.Checked = true;//虚科室
                    this.txtDeptCode.Text = this.departmentStat.DeptCode;
                    this.comboDeptName.Text = this.departmentStat.DeptName;
                    this.txtSpellCode.Text = this.departmentStat.SpellCode;
                    this.txtWbCode.Text = this.departmentStat.WBCode;
                    this.txtSortID.Text = this.departmentStat.SortId.ToString();
                    this.txtMark.Text = this.departmentStat.Memo;
                }
                else
                if (this.departmentStat.DeptCode == "")
                {
                    //初始化
                }
                else//实科室
                {
                    Neusoft.HISFC.Models.Base.Department objTemp = deptMgr.GetDeptmentById(this.departmentStat.DeptCode);
                    if (objTemp == null)
                    {
                        MessageBox.Show("查询科室信息失败" + deptMgr.Err);
                        return;
                    }
                    
                    this.setInfo(objTemp);
                    this.txtMark.Text = this.departmentStat.Memo;//备注
                }

                #region 备用 维护出入库科室
                ////确定是否需要维护出入库科室 数据库表DeptStat中StatCode  03代表药..05
                //if (this.department.StatCode == "03" || this.department.StatCode == "05")
                //{
                //    //标识本统计大类需要维护出入库科室
                //    this.IsInOutDept = true;

                //    //取科室列表:全院科室Union科室结构中的自定义科室
                //    Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager dept = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
                //    this.alChooseDept = dept.LoadChildrenUnionDept(this.department.StatCode, "AAAA");
                //    if (this.alChooseDept == null)
                //    {
                //        MessageBox.Show("取科室列表错误:" + dept.Err, "提示");
                //        return;
                //    }
                //    //objHelper用于查找科室类型
                //    objHelper.ArrayObject = this.alChooseDept;

                //    //显示入库科室
                //    this.ShowInOutDept(this.neuSpread1_Sheet1, this.department.StatCode + "10");
                //    //if(this.fpSpread1_Sheet1.RowCount == 0)	this.btnDeleteInput.Enabled = false;

                //    //显示出库科室
                //    this.ShowInOutDept(this.neuSpread2_Sheet1, this.department.StatCode + "20");
                //    //if(this.fpSpread2_Sheet1.RowCount == 0)	this.btnDeleteOutput.Enabled = false;
                //}
                //else
                //{
                //    this.neuTabControl1.TabPages.Remove(this.tabPage2);
                //    this.neuTabControl1.TabPages.Remove(this.tabPage3);
                //}
                #endregion
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }
       
               #region (无用)--显示入库科室
        /// <summary>
        /// 显示入库科室
        /// </summary>
        private void ShowInOutDept(FarPoint.Win.Spread.SheetView sheetView, string privType)
        {
            //取入库科室列表
            ArrayList al = this.myPrivDept.GetPrivInOutDeptList(this.departmentStat.ID, privType);
            if (al == null)
            {
                MessageBox.Show(this.myPrivDept.Err);
                return;
            }

            Neusoft.HISFC.Models.Base.PrivInOutDept dept;

            sheetView.RowCount = al.Count;
            for (int i = 0; i < al.Count; i++)
            {
                dept = al[i] as Neusoft.HISFC.Models.Base.PrivInOutDept;
                sheetView.Cells[i, 0].Value = dept.SortID;				//排序
                sheetView.Cells[i, 1].Value = dept.ID;		//部门编码
                sheetView.Cells[i, 2].Value = dept.Name;	//部门名称
                sheetView.Cells[i, 3].Value = objHelper.GetObjectFromID(dept.ID).User02;//部门类型名称
            }
        }
        #endregion
              
        #endregion

        #region 传出事件用于判断在增加科室时是否增加的是本科室(修改人：路志鹏,修改时间：2007-4-11)
        public delegate bool CheckHander(string DeptCode);
        public　static event CheckHander DoCheckNode;
        protected virtual bool DoEvent(string DeptCode)
        {
            if (DoCheckNode != null)
                return DoCheckNode(DeptCode);
            return true;
        }
        #endregion

        #region  setInfo(Department dept)根据传入的Department对象填充窗体各控件

        /// <summary>
        /// 根据传入的Department对象填充窗体各控件
        /// </summary>
        /// <param name="dept"></param>
        private void setInfo(Neusoft.HISFC.Models.Base.Department dept)
        {
            this.comboDeptName.Text = dept.Name;//科室名称
            this.txtDeptCode.Text = dept.ID;//科室编码
            this.txtSortID.Text = dept.SortID.ToString();//顺序号
            this.txtSpellCode.Text = dept.SpellCode;//拼音码 
            this.txtWbCode.Text = dept.WBCode;//五笔码           
            this.txtUserCode.Text = dept.UserCode;//自定义码
            this.txtDeptSimpleName.Text = dept.ShortName;//科室简称
            this.txtDeptEnglish.Text = dept.EnglishName;//科室英文名
            this.comboDeptType.Tag = dept.DeptType.ID;//科室类型

            if (dept.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)//有效状态
            {
                this.chbStop.Checked = true;
            }
            else
            {
                this.chbStop.Checked = false;
            }
            this.comboDeptPro.SelectedIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(dept.SpecialFlag); //科室属性
            //this.txtMark.Text = dept.Memo;//备注
            this.chbReg.Checked = dept.IsRegDept;//是否挂号科室
            this.chbTat.Checked = dept.IsStatDept;//是否统计科室

        }
        #endregion

        #region 取消按钮事件
         private void btCancle_Click_1(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        #endregion

        #region ValidateValue()验证科室信息是否录入正确
        /// <summary>
        /// 验证科室信息是否录入正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateValue()
        {   
            //如果科室分类Checked=True
            if (!this.chbClass.Checked)
            {
                if (this.txtDeptCode.Text.Trim() == "")
                {
                    MessageBox.Show("科室代码不能为空！", "提示", MessageBoxButtons.OK);
                    this.txtDeptCode.Focus();
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtDeptCode.Text, 4))
                {
                    MessageBox.Show("科室编码过长");
                    txtDeptCode.Focus();
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtDeptSimpleName.Text, 16))
                {
                    MessageBox.Show("科室简称过长");
                    this.txtDeptSimpleName.Focus();
                    return false;
                }
                if (this.comboDeptType.Text == "")
                {
                    MessageBox.Show("科室的类型不能为空！", "提示", MessageBoxButtons.OK);
                    this.comboDeptType.Focus();
                    return false;

                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtDeptEnglish.Text, 20))
                {
                    MessageBox.Show("科室英文过长");
                    this.txtDeptEnglish.Focus();
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txtSpellCode.Text, 8))
                {
                    txtSpellCode.Focus();
                    MessageBox.Show("拼音码过长");
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtWbCode.Text, 8))
                {
                    this.txtWbCode.Focus();
                    MessageBox.Show("五笔码过长");
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtUserCode.Text, 8))
                {
                    this.txtUserCode.Focus();
                    MessageBox.Show("自定义码过长");
                }
                if (this.comboDeptPro.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择科室属性");
                    this.comboDeptPro.Focus();
                }
            }
            //如果科室名称为空
            if (this.comboDeptName.Text.Trim() == "")
            {
                MessageBox.Show("请输入科室科室名称！", "提示", MessageBoxButtons.OK);
                this.comboDeptName.Focus();
                return false;
            }
             //科室名过长
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.comboDeptName.Text, 16))
            {
                MessageBox.Show("科室名称过长");
                this.comboDeptName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        
       /// <summary>
       /// 保存
       /// </summary>
        private void Save()
        {
            //判断输入有效性
            if (!ValidateValue()) return;

            //取控件中的科室数据信息
            if (this.departmentStat == null)

                this.departmentStat = new Neusoft.HISFC.Models.Base.DepartmentStat();
            
            //如果是科室分类，则取科室分类的最大编码。
            if (this.chbClass.Checked)
            {
                this.departmentStat.NodeKind = 0;

                //如果是新增科室分类，则取
                if (this.departmentStat.DeptCode == "")
                    this.GetMaxCode();
            }
            else
            {
                this.departmentStat.NodeKind = 1;
            }

            Neusoft.HISFC.Models.Base.Department deptment = new Neusoft.HISFC.Models.Base.Department();

            //在增加科室时判断该科室是否已经存在

            if (!this.DoEvent(this.txtDeptCode.Text.Trim()))
            {
                MessageBox.Show("该科室在本科室结构中已存在，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region 科室基本信息
            if (!this.chbClass.Checked)//不是科室分类
            {
                deptment.ID = this.txtDeptCode.Text.Trim();//科室编码
                deptment.Name = this.comboDeptName.Text.Trim();//科室名称
                deptment.SpellCode = this.txtSpellCode.Text.Trim();//拼音码
                deptment.WBCode = this.txtWbCode.Text.Trim();//五笔码
                deptment.UserCode = this.txtUserCode.Text.Trim();//自定义码
                deptment.ShortName = this.txtDeptSimpleName.Text.Trim();//科室简称
                
                //如果英文名称不为空
                if (this.txtDeptEnglish.Text != "")
                {
                    deptment.EnglishName = this.txtDeptEnglish.Text.Trim();//科室英文名称
                }
                
                if (this.comboDeptType.SelectedIndex != -1)
                {
                    deptment.DeptType.ID = this.comboDeptType.Tag;//科室类型ID
                }
                //停用
                if (this.chbStop.Checked)
                {
                    deptment.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;//有效性状态
                }
                else
                {
                    deptment.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
                }
                //排序ID
                if (txtSortID.Text != "")
                {
                    deptment.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(txtSortID.Text.Trim());//排序ID
                }
                deptment.SpecialFlag = this.comboDeptPro.SelectedIndex.ToString();//特殊科室标识
                deptment.IsRegDept = this.chbReg.Checked;//是否挂号科室
                deptment.IsStatDept = this.chbTat.Checked;//是否统计科室
                deptment.Memo = this.txtMark.Text.Trim();//备注

               #region  是否已经存在编码相同但名称不同的科室
                Neusoft.HISFC.Models.Base.Department depttempt = deptMgr.GetDeptmentById(deptment.ID);
                if (depttempt == null)
                {
                    MessageBox.Show("该科室编码没有与之相对应的科室" + deptMgr.Err);
                    return;
                }
                if ((depttempt.ID == deptment.ID) && (depttempt.Name != deptment.Name))
                {
                    if (MessageBox.Show("已经存在编码为" + depttempt.ID + "的记录" + depttempt.Name + "是否要替换为:" + deptment.Name + "吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
            }
                #endregion

                //将控件中的数据保存到实体中
                this.departmentStat.DeptCode = this.txtDeptCode.Text.Trim();//科室编码
                this.departmentStat.DeptName = this.comboDeptName.Text.Trim();//科室名称
                this.departmentStat.SpellCode = this.txtSpellCode.Text.Trim();//拼音码
                this.departmentStat.WBCode = this.txtWbCode.Text.Trim();//五笔码
                this.departmentStat.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid; //有效标志。0 在用。1停用
                this.departmentStat.SortId = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtSortID.Text.Trim());//排序号
                this.departmentStat.Memo = this.txtMark.Text.Trim();//备注
                
                //保存时，如果没有拼音码或者五笔码，则自动生成
                if (this.txtSpellCode.Text.Trim() == "" || this.txtWbCode.Text.Trim() == "")
                    CreateSpell();//产生拼音码和五笔码

                //定义科室分类表管理类

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptStatManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
                ////定义事务
                //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(deptStatManager.Connection);
                //trans.BeginTransaction();

                ////管理类设置当前事务
                //deptStatManager.SetTrans(trans.Trans);

                deptMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                try
                {
                    
                    //Do科室分类表，先保存，如果不存在则插入一条记录
                    int parm = deptStatManager.UpdateDepartmentStat(this.departmentStat);

                    if (parm == 0)
                    {
                        parm = deptStatManager.InsertDepartmentStat(this.departmentStat);
                    }

                    if (parm != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("数据保存失败:" + deptStatManager.Err);
                        return;
                    }
                    #region 基础数据维护
                    if (!this.chbClass.Checked)
                    {
                        if (deptMgr.Insert(deptment) == -1)
                        {
                            if (deptMgr.DBErrCode == 1)
                            {
                                if (deptMgr.Update(deptment) == -1 || deptMgr.Update(deptment) == 0)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show("保存科室信息失败" + deptMgr.Err);
                                    return;
                                }
                            }
                            else
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("保存科室信息失败" + deptMgr.Err);
                                return;
                            }
                        }
                   }
                    #endregion

                }
                catch (Exception a)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(a.Message);
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.FindForm().DialogResult = DialogResult.OK;


          
            #endregion 
        }

        #region 根据科室名称生成拼音码和五笔码
        /// <summary>
        /// 根据科室名称生成拼音码和五笔码
        /// </summary>
        private void CreateSpell()
        {
            if (this.txtSpellCode.Text == "" || this.txtWbCode.Text == "")
            {
                //根据名称生产拼音码和五笔码
                Neusoft.HISFC.Models.Base.Spell spell = new Neusoft.HISFC.Models.Base.Spell();

                spell = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(this.comboDeptName.Text.Trim());
                this.txtSpellCode.Text = spell.SpellCode;
                this.txtWbCode.Text = spell.WBCode;
            }
        }
        #endregion

        #region 取科室分类最大编码
        /// <summary>
        /// 取科室分类最大编码
        /// </summary>
        private int GetMaxCode()
        {
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            string deptCode = deptManager.GetMaxCode(this.departmentStat.StatCode);
            if (deptCode == "-1")
            {
                MessageBox.Show(deptManager.Err);
                return -1;
            }

            this.txtDeptCode.Text = deptCode;
            return 1;
        }
        #endregion

        #region  科室名称ComboBoxSelectedIndexChanged事件
        /// <summary>
        /// 科室名称ComboBoxSelectedIndexChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.chbClass.Checked)
            {
                return;
            }
            if (this.comboDeptName.Tag == null)
            {
                return;
            }
            string DeptID = this.comboDeptName.Tag.ToString();
            Neusoft.HISFC.Models.Base.Department objTemp = deptMgr.GetDeptmentById(DeptID);
            if (objTemp == null)
            {
                MessageBox.Show("查询科室信息失败" + deptMgr.Err);
                return;
            }
            setInfo(objTemp);
        }
        #endregion

        private string DeptName = "";

        private void comboDeptName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.chbClass.Checked)
                {
                    if (this.comboDeptName.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入科室名称！");
                        return;
                    }
                    this.DeptName = this.comboDeptName.Text;
                    this.chbClass.Checked = false;
                    //if (MessageBox.Show("确认要增加一个" + this.comboDeptName.Text + "科室分类吗？", "增加科室分类", MessageBoxButtons.YesNo) == DialogResult.No)
                    if (MessageBox.Show("确认要增加一个【" + this.DeptName + "】科室分类吗？", "增加科室分类", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    //根据科室名称生产拼音码和五笔码
                    this.comboDeptName.Tag = this.comboDeptName.Text;
                    this.txtDeptSimpleName.Focus();
                }
                //注释掉的代码 路志鹏 2007-5-29
                //this.chbClass.Checked = true;
                //this.comboDeptName.Text = this.DeptName;
                //this.CreateSpell();
                //if (this.chbClass.Checked)
                //{
                //    this.txtSpellCode.Focus();
                //}
                //else
                //{
                //    if (this.comboDeptName.Tag != null)
                //    {
                //        this.txtDeptCode.Text = this.comboDeptName.Tag.ToString();
                //    }
                //    this.txtDeptSimpleName.Focus();
                //}
            }
            else
            {
                return;
            }
        }

        private void txtDeptSimpleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDeptCode.Focus();
            }
        }

        private void txtDeptCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!isAddDept)
                {
                    this.txtSortID.Focus();
                }
                else
                {
                    this.txtSpellCode.Focus();
                }
            }
        }

        private void txtSpellCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtWbCode.Focus();
            }
        }

        private void txtWbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.chbClass.Checked)
                {
                    this.txtSortID.Focus();
                }
                else
                {
                    this.txtUserCode.Focus();
                }
            }
        }

        private void txtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDeptEnglish.Focus();
            }
        }

        private void txtDeptEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtSortID.Focus();
        }

        private void txtSortID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.chbClass.Checked || !isAddDept) //科室分类或不是组织结构 
                {
                    this.txtMark.Focus();
                }
                else
                {
                    this.comboDeptType.Focus();
                }
            }
        }

        private void comboDeptType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.comboDeptPro.Focus();
            }
        }

        private void comboDeptPro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtMark.Focus();
            }
        }

        private void txtMark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.chbClass.Checked || !isAddDept)
                {
                    this.Save();
                }
                else
                {
                    this.chbReg.Focus();
                }
            }
        }

        private void chbReg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chbTat.Focus();
            }
        }

        private void chbTat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chbStop.Focus();
            }
        }

        private void chbStop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Save();
            }
        }

    }

    //增加的代码用于在增加科室的时间中传出参数
    //路志鹏
    //2007-4-11
    //public class CheckEventArgs : EventArgs
    //{
    //    private string DeptCode;
    //    /// <summary>
    //    /// 要加入科室的科室编码
    //    /// </summary>
    //    public Neusoft.HISFC.Models.Base.Department Message
    //    {
    //        get
    //        {
    //            return DeptCode;
    //        }
    //        set
    //        {
    //            DeptCode = value;
    //        }
    //    }
    //    public CheckEventArgs(string Msg)
    //    {
    //        this.Message = Msg;
    //    }
    //}
    
}
