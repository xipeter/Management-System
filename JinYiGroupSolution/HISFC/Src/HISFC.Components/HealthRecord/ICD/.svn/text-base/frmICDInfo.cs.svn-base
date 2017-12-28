using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
namespace Neusoft.HISFC.Components.HealthRecord.ICD
{
    /// <summary>
    /// frmICDInfo<br></br>
    /// [功能描述: 病案ICD维护信息录入]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-20]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class frmICDInfo : Form
    {
        public frmICDInfo()
        {
            InitializeComponent();
        }
        #region   私有变量

        //定义类型， 增加，修改，或停用 根据这个来设定窗口中控件的属性 
        private Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes editType;
        //定义ICD变量 ，存储修改前ICD信息
        private Neusoft.HISFC.Models.HealthRecord.ICD orgICD = new Neusoft.HISFC.Models.HealthRecord.ICD();
        //定义ICD变量 ，存储修改后ICD信息
        private Neusoft.HISFC.Models.HealthRecord.ICD newICD = new Neusoft.HISFC.Models.HealthRecord.ICD();
        //定义业务层 变量
        private Neusoft.HISFC.BizLogic.HealthRecord.ICD myICD = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();
        //ICD类别
        private ICDTypes myICDType;

        #endregion

        #region	公有属性

        /// <summary>
        /// 定义类型， 增加，修改，或停用 
        /// EditType.ADD 增加
        /// EditType.Modify修改
        /// EditType.Cancel 作废 
        /// </summary>
        public EditTypes EditType
        {
            set
            {
                editType = value;
            }
        }
        /// <summary>
        /// 修改前信息
        /// </summary>
        public Neusoft.HISFC.Models.HealthRecord.ICD OrgICD
        {
            set
            {
                orgICD = value;
            }
        }
        /// <summary>
        /// 修改后信息
        /// </summary>
        public Neusoft.HISFC.Models.HealthRecord.ICD NewICD
        {
            set
            {
                newICD = value;
            }
        }
        /// <summary>
        /// 操作ICD类别 ICD10 ，ICD9 ，ICDOperation 
        /// </summary>
        public ICDTypes ICDType
        {
            set
            {
                myICDType = value;
            }
        }
        #endregion

        #region  窗口控件的事件

        #region 窗体的Load 事件
        private void ucICDInfo_Load(object sender, System.EventArgs e)
        {
            Neusoft.HISFC.BizLogic.HealthRecord.ICD icd = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();
            //加载性别列表
            this.SexComBox.AppendItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
            if (SexComBox.Items != null)
            {
                if (SexComBox.Items.Count > 0)
                {
                    SexComBox.SelectedIndex = 0;
                }
            }

            //首先判断是增加 ，修改 
            if (editType == EditTypes.Add)
            {
                //增加
                this.IsValid.Checked = true;  //增加的的时候 有效的
                this.IsValid.Enabled = false; //有效
                ContinueInput.Checked = true; //可以连续输入
                cbTraditional.Checked = false;
                Is30Illness.Checked = false;
                IsInfection.Checked = false;
                IsTumour.Checked = false;
                this.Text = "增加";
            }
            else
            {
                //修改
                this.textSeqNO.Text = orgICD.User01.ToString();//序列号
                this.textICDid.Text = orgICD.ID; //ICD编码
                this.textICDName.Text = orgICD.Name;//ICD名称
                this.WBCode.Text = orgICD.WBCode;
                this.textSpellCode.Text = orgICD.SpellCode;//拼音码
                this.textUserCode.Text = orgICD.UserCode;//自定义编码
                this.cbTraditional.Checked = orgICD.TraditionalDiag;
                //if (orgICD.Is30Illness == "是")
                //{
                    this.Is30Illness.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(orgICD.Is30Illness); //是否30种疾病
                //}
                //else
                //{
                //    this.Is30Illness.Checked = false; //是否30种疾病
                //}
                //if (orgICD.IsInfection == "是")
                //{
                    this.IsInfection.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(orgICD.IsInfection);//是否是传染病
                //}
                //else
                //{
                //    this.IsInfection.Checked = false;//是否是传染病
                //}
                //if (orgICD.IsTumour == "是")
                //{
                    this.IsTumour.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(orgICD.IsTumour);// //是否是恶性肿瘤
                //}
                //else
                //{
                //    this.IsTumour.Checked = false; //是否是恶性肿瘤
                //}
                this.IsValid.Checked = orgICD.IsValid;
                //if (orgICD.IsValid == "是")
                //{
                //    this.IsValid.Checked = true;//是否有效
                //}
                //else
                //{
                //    this.IsValid.Checked = false;//是否有效
                //}
                this.SexComBox.Tag = orgICD.SexType.ID; //适用性别
                ContinueInput.Enabled = false;  //修改不允许连续输入
                //不允许修改ID
                textICDid.ReadOnly = true;
                this.Text = "修改";
            }
        }
        #endregion

        #region  关闭按钮
        private void button2_Click(object sender, System.EventArgs e)
        {
            //关闭本窗口
            this.Close();
        }
        #endregion

        #region  确定按钮
        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                //判断数据的有效性
                if (!ValidCheck())
                {
                    //有的数据无效
                    return;
                }
                //获取信息
                this.GetICDinfo();

                if (newICD == null) //获取信息失败
                {
                    return;
                }
                if (Save())
                {
                    //保存成功 ，刷新主窗口数据
                    SaveButtonClick(newICD);
                    if (!ContinueInput.Enabled)
                    {
                        //如果是修改数据 修改完后直接关闭窗口
                        this.Close();
                    }
                    textICDid.Focus(); //诊断编码获得焦点
                    //判断是否是连续数据
                    if (ContinueInput.Checked)
                    {
                        //清空窗口 继续输入
                        this.textSpellCode.Text = "";
                        this.textICDid.Text = "";
                        this.textICDName.Text = "";
                        this.textSeqNO.Text = "";
                        this.textUserCode.Text = "";
                        this.Is30Illness.Checked = false;
                        this.IsInfection.Checked = false;
                        this.IsTumour.Checked = false;
                    }
                    else
                    {
                        this.Close(); //关闭窗口
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 回车事件
        /// <summary>
        /// ICD id 的回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textICDid_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.textICDName.Focus();
            }
        }

        /// <summary>
        ///ICD名称 的 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textICDName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.textSpellCode.Focus();
            }

        }

        /// <summary>
        /// 拼音码 的 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSpellCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.WBCode.Focus();
            }

        }
        /// <summary>
        /// 自定义  的 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textUserCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.textSeqNO.Focus();
            }
        }
        /// <summary>
        /// 30 中疾病 按钮 的 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Is30Illness_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.IsInfection.Focus();
            }
        }
        /// <summary>
        /// 传染 按钮 的 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsInfection_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.IsTumour.Focus();
            }
        }
        /// <summary>
        /// 肿瘤按钮 的 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsTumour_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (this.IsValid.Enabled) //如果有效
                {
                    this.IsValid.Focus(); //获得焦点
                }
                else
                {
                    this.ContinueInput.Focus(); //否则 跳 到下一个控件
                }
            }
        }
        /// <summary>
        /// 有效性按钮 的 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsValid_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.ContinueInput.Focus();
            }
        }
        /// <summary>
        /// 连续输入的回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinueInput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.button1.Focus();
            }

        }
        /// <summary>
        /// 序号的回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSeqNO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.Is30Illness.Focus();
            }
        }
        #endregion

        #endregion

        #region 自定义函数

        /// <summary>
        /// 保存信息
        /// </summary>
        /// <returns>成功返回 true 失败返回 false</returns>
        private bool Save()
        {
            //定义事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(myICD.Connection);
            ////开始事务
            //t.BeginTransaction();

            myICD.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //执行插入操作
            int iReturn = 0; //返回值 
            //如果是增加的 则插入
            if (editType == EditTypes.Add)
            {
                //插入ICD信息
                iReturn = myICD.Insert(newICD, myICDType);

                if (iReturn > 0)
                {
                    //提交数据
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show("保存成功");
                    return true;
                }
                else
                {
                    //回退数据
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存失败" + myICD.Err);
                    return false;
                }
            }
            else if (editType == EditTypes.Modify) //其他的执行更新操作。
            {
                iReturn = myICD.Update(orgICD, newICD, myICDType);
                if (iReturn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新ICD信息失败!" + myICD.Err);
                    return false;
                }
                if (iReturn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("没有找到可更新的ICD信息,您所修改的ICD信息已经被其他人修改!");
                    return false;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功");
                return true;
            }

            return true;
        }
        #endregion

        #region 自定义函数
        /// <summary>
        /// 获取修改或新增的信息
        /// </summary>
        private void GetICDinfo()
        {

            try
            {
                if (editType == EditTypes.Add)
                {
                    newICD.User01 = textSeqNO.Text;    //副诊断码
                    newICD.ID = this.textICDid.Text;					 //ICD编码
                    newICD.Name = this.textICDName.Text;				 //ICD名称
                    newICD.SpellCode = this.textSpellCode.Text; //拼音码
                    newICD.WBCode = this.WBCode.Text; //五笔码 
                    newICD.UserCode = this.textUserCode.Text;    //统计码
                    newICD.Is30Illness = Neusoft.FrameWork.Function.NConvert.ToInt32(Is30Illness.Checked).ToString();		 //是否是30种疾病
                    newICD.IsInfection = Neusoft.FrameWork.Function.NConvert.ToInt32(IsInfection.Checked).ToString();		 //是否是传染病
                    newICD.IsTumour = Neusoft.FrameWork.Function.NConvert.ToInt32(IsTumour.Checked).ToString();//;            //是否是肿瘤
                    newICD.IsValid = true;
                    newICD.SexType.ID = this.SexComBox.Tag.ToString(); //适用性别 
                    newICD.SexType.Name = this.SexComBox.Text;
                    newICD.TraditionalDiag = cbTraditional.Checked;

                }
                if (editType == EditTypes.Modify)
                {
                    newICD = orgICD.Clone();
                    newICD.User01 = textSeqNO.Text;    //副诊断码
                    newICD.Name = this.textICDName.Text;				 //ICD名称
                    newICD.SpellCode = this.textSpellCode.Text; //拼音码
                    newICD.WBCode = this.WBCode.Text; //五笔码 
                    newICD.UserCode = this.textUserCode.Text;    //统计码
                    newICD.Is30Illness = Neusoft.FrameWork.Function.NConvert.ToInt32(Is30Illness.Checked).ToString();		 //是否是30种疾病
                    newICD.IsInfection = Neusoft.FrameWork.Function.NConvert.ToInt32(IsInfection.Checked).ToString();		 //是否是传染病
                    newICD.IsTumour = Neusoft.FrameWork.Function.NConvert.ToInt32(IsTumour.Checked).ToString();//;            //是否是肿瘤
                    newICD.IsValid = this.IsValid.Checked; //有效性
                    newICD.SexType.ID = this.SexComBox.Tag.ToString(); //适用性别
                    newICD.SexType.Name = this.SexComBox.Text;
                    newICD.TraditionalDiag = cbTraditional.Checked;
                }
                #region 取操作员 和操作时间
                //这个地方不是很准，只是暂时给前台显示用。
                Neusoft.HISFC.BizLogic.HealthRecord.ICD icd = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();
                //操作员 编码 姓名
                newICD.OperInfo.ID = icd.Operator.ID;
                newICD.OperInfo.Name = icd.Operator.Name;
                //操作时间
                newICD.OperInfo.OperTime = icd.GetDateTimeFromSysDateTime();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 判断输入数据的有效性
        /// </summary>
        /// <returns>数据都合乎规则 返回TRUE  否则返回false </returns>
        private bool ValidCheck()
        {
            try
            {
                //定义数组 存储 ICD 
                ArrayList alReturn = new ArrayList();

                if (textICDid.Text == "")
                {
                    textICDid.Focus();
                    MessageBox.Show("ICD 编码不能为空");//
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(textICDid.Text, 20))
                {
                    textICDid.Focus();
                    MessageBox.Show("ICD编码过长"); //提示错误
                    return false;
                }
                //如果是增加 ，则判断编码是否存在 ，修改不判断
                if (editType == EditTypes.Add)
                {
                    //判断ICD编码是否存在
                    alReturn = myICD.IsExistAndReturn(textICDid.Text, myICDType, true);

                    if (alReturn == null)
                    {
                        MessageBox.Show("获得ICD信息出错!" + myICD.Err);
                        return false;
                    }
                    if (alReturn.Count > 0)
                    {
                        textICDid.Focus();
                        MessageBox.Show("编码 " + textICDid.Text + " 已经存在");
                        return false;
                    }
                }
                if (textICDName.Text == null || textICDName.Text == "")
                {
                    textICDName.Focus();
                    MessageBox.Show("请输入名称");
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(textICDName.Text, 100))
                {
                    textICDName.Focus();
                    MessageBox.Show("ICD 名称过长");
                    return false;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(textSpellCode.Text, 8))
                {
                    textSpellCode.Focus();
                    MessageBox.Show("拼音码 过长");
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(WBCode.Text, 8))
                {
                    WBCode.Focus();
                    MessageBox.Show("五笔码 过长");
                    return false;
                }


                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(textUserCode.Text, 8))
                {
                    textUserCode.Focus();
                    MessageBox.Show("统计码 过长");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 生成拼音码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textICDName_Leave(object sender, System.EventArgs e)
        {
            try
            {
                //生成 拼音码
                //定义 实例化 业务类
                Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();
                //声明 实例化实体类
                Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
                //查询
                spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(textICDName.Text);
                //出错返回
                if (spCode.SpellCode == null)
                    return;
                //判断是否超长
                if (spCode.SpellCode.Length > 8)
                {
                    spCode.SpellCode = spCode.SpellCode.Substring(0, 8);
                }
                //判断是否超长
                if (spCode.WBCode.Length > 8)
                {
                    spCode.WBCode = spCode.WBCode.Substring(0, 8);
                }
                if (textSpellCode.Text == "")
                {
                    //赋值
                    textSpellCode.Text = spCode.SpellCode; //拼音码 
                }
                if (WBCode.Text == "")
                {
                    WBCode.Text = spCode.WBCode; //五笔码 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void WBCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.textUserCode.Focus();
            }
        }

    }
}