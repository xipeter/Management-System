using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Base
{
    /// <summary>
    /// [控件名称:ucPharmacyFunctionProperty]<br></br>
    /// [功能描述: 药理作用属性控件<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-17]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPharmacyFunctionProperty : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 带参数的构造器
        /// </summary>
        /// <param name="nodeCode">节点编码</param>
        /// <param name="operKind">操作类型</param>
        public ucPharmacyFunctionProperty(string nodecode, string operkind, int gridLevel)
        {
            InitializeComponent( );

            this.operKind = operkind;
            this.nodeCode = nodecode;
            //{FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}  药理作用级别
            this.gridLevel = gridLevel;

            this.cmbparent.Enabled = false;
        }

        /// <summary>
        /// 不带参数的构造器，通过属性赋值
        /// </summary>
        public ucPharmacyFunctionProperty( )
        {
            this.cmbparent.Enabled = false;
        }

        #region 变量

        /// <summary>
        /// 由父窗口传过来的节点编码
        /// </summary>
        private string nodeCode;

        /// <summary>
        /// 操作类型UPDATE/DELETE/INSERT
        /// </summary>
        private string operKind;

        /// <summary>
        /// 药理常数管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant pharmacyConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant( );

        private Neusoft.HISFC.Models.Pharmacy.PhaFunction functionObject = null ;

        /// <summary>
        /// 药理作用集合
        /// 
        /// //{C8D1015E-41B3-4e90-B624-8B47CF81E665} 校验药理作用名称重复
        /// </summary>
        private static Hashtable hsFunctionNameDictionary = new Hashtable();

        /// <summary>
        /// 当前药理作用级别   {FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}
        /// </summary>
        private int gridLevel;

        #endregion

        #region 属性

        /// <summary>
        /// 由父窗口传过来的节点编码
        /// </summary>
        [Description( "由父窗口传过来的节点编码" )]
        public string NodeCode
        {
            get
            {
                return nodeCode;
            }
            set
            {
                nodeCode = value;
            }
        }

        /// <summary>
        /// 操作类型UPDATE/DELETE/INSERT
        /// </summary>
        [Description( "操作类型UPDATE/DELETE/INSERT" )]
        public string OperKind
        {
            get
            {
                return operKind;
            }
            set
            {
                operKind = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 药理作用名称校验
        /// 
        /// //{C8D1015E-41B3-4e90-B624-8B47CF81E665} 校验药理作用名称重复
        /// </summary>
        protected bool VerifyFunctionName()
        {
            if (this.txtName.Tag != null)
            {
                if (this.txtName.Tag.ToString() == this.txtName.Text)           //名称未变
                {
                    return true;
                }
            }

            if (hsFunctionNameDictionary.Count == 0)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager drugconstant = new Neusoft.HISFC.BizProcess.Integrate.Manager();

                ArrayList al = drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PHYFUNCTION);
                if (al == null)
                {
                    MessageBox.Show("加载药理作用集合发生错误" + drugconstant.Err);
                    return false;
                }

                foreach (Neusoft.FrameWork.Models.NeuObject info in al)
                {
                    if (hsFunctionNameDictionary.ContainsKey(info.Name) == false)
                    {
                        hsFunctionNameDictionary.Add(info.Name, null);
                    }
                }
            }

            if (this.operKind == "DELETE")          //删除
            {
                if (hsFunctionNameDictionary.ContainsKey(this.txtName.Text) == true)
                {
                    hsFunctionNameDictionary.Remove(this.txtName.Text);
                }
            }
            else
            {
                if (hsFunctionNameDictionary.ContainsKey(this.txtName.Text) == true)
                {
                    DialogResult rs = MessageBox.Show(this.txtName.Text + "  药理作用名称已存在，是否确认添加？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        return true;
                    }
                    else if (rs == DialogResult.No)
                    {
                        return false;
                    }
                }
                else
                {
                    hsFunctionNameDictionary.Add(this.txtName.Text, null);
                }
            }

            return true;
        }

        /// <summary>
        /// 数据有效性检验  {FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}
        /// </summary>
        /// <returns>成功返回True  失败返回 False</returns>
        protected bool IsDataValid()
        {
            #region 有效性判断

            //节点名称不能为空
            if (this.txtName.Text.Trim() == null || this.txtName.Text.Trim() == "")
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "药理作用名称不允许空！" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }
            if (this.txtName.Text.Trim().Length > 25)
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "药理作用名称超长 请简略" ) );
                return false;
            }

            //节点编码不能为空且不能为0
            if (this.txtCode.Text.Trim() == null || this.txtCode.Text.Trim() == "" || this.txtCode.Text.Trim() == "0")
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "编码不允许空值和零！" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }
            if (this.txtCode.Text.Trim().Length > 30)
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "编码超长 请简略" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }

            //字符无效判断
            if (this.txtCode.Text.IndexOfAny( new char[] { '@', '.', ',', '!', '-', '#', '$', '%', '^', '&', '*', '[', ']', '|', '}', '\'', '?' } ) != -1)
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "无效的编码.\n" +
                    "无效字符:  '@', '.', ',', '!', '-', '#', '$', '%', '^', '&', '*', '[', ']', '|', '}','\'','?'" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }

            if (this.txtName.Text.IndexOfAny( new char[] { '@', '.', ',', '!', '-', '#', '$', '%', '^', '&', '*', '[', ']', '|', '}', '\'', '?' } ) != -1)
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "无效的药理作用名称.\n" +
                    "无效字符:  '@', '.', ',', '!', '-', '#', '$', '%', '^', '&', '*', '[', ']', '|', '}','\'','?'" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }

            //备注长度判断
            if (this.txtMark.Text.Length > 200)
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "备注字段超长 请适当简略" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }

            #endregion

            return true;
        }

        /// <summary>
        /// 由界面获取药理作用信息   {FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int GetPhaFunction()
        {
            //如果是当前没有父节点，则为第一级
            if (string.IsNullOrEmpty( this.cmbparent.Text ) == false)       //上级节点非空
            {
                functionObject.ParentNode = this.cmbparent.SelectedItem.ID;
            }
            else
            {
                functionObject.ParentNode = "0";
            }

            functionObject.ID = this.txtCode.Text.Trim();//药理作用编码
            functionObject.Name = this.txtName.Text.Trim();  //药理作用名称
            functionObject.WBCode = this.txtWBCode.Text.Trim(); //五笔码
            functionObject.SpellCode = this.txtSpellCode.Text.Trim();    //拼音码

            functionObject.GradeLevel = this.gridLevel;

            functionObject.Memo = this.txtMark.Text.Trim();//备注
            functionObject.SortID = 0;
            functionObject.Oper.ID = pharmacyConstant.Operator.ID;
            functionObject.Oper.OperTime = pharmacyConstant.GetDateTimeFromSysDateTime();

            //药理作用是否有效
            functionObject.IsValid = this.chkIsValid.Checked;

            return 1;
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            //{FF5503FA-0057-413e-BF08-5A8C1DCF7ED8} 有效性校验  更改实体获取方式
            if (this.IsDataValid() == false)
            {
                return -1;
            }

            //实体初始化
            this.functionObject = new Neusoft.HISFC.Models.Pharmacy.PhaFunction();

            this.GetPhaFunction();
            //{FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}

            //判断是否有子节点
            ArrayList al = new ArrayList();
            al = pharmacyConstant.QueryFunctionByParentNode( functionObject.ID );
            if (al != null)
            {
                int ifleave = al.Count;
                if (ifleave > 0)                 //有子节点   用于排序
                {
                    functionObject.NodeKind = 1;//叶子节点
                }
                else
                {
                    functionObject.NodeKind = 0;//非叶子节点
                }
            }
            else
            {
                functionObject.NodeKind = 0;//非叶子节点
            }

            //判断是否重复
            if (this.operKind == "INSERT")//插入
            {
                int i = 0;
                ArrayList alfun = new ArrayList();
                alfun = pharmacyConstant.QueryFunctionByNode( functionObject.ID );
                if (alfun != null)
                {
                    i = alfun.Count;
                    if (i >= 1)
                    {
                        MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "该节点编号" ) + this.txtCode.Text.Trim() + Neusoft.FrameWork.Management.Language.Msg( "已存在！" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );//节点已存在的不能再插入
                        return -1;
                    }
                }
            }
            ////增，删，改操作
            try
            {
                if (pharmacyConstant.SetFunction( functionObject, this.operKind ) == -1)
                {
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "更新药理作用信息失败" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    return -1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
                return -1;
            }
        }

        #endregion

        #region 事件

        private void btnOk_Click( object sender , EventArgs e )
        {
            //{C8D1015E-41B3-4e90-B624-8B47CF81E665} 校验药理作用重名
            if (this.VerifyFunctionName() == false)
            {
                return;
            }

            if( Save( ) == 0 )
            {
                this.ParentForm.Close( );
                this.FindForm( ).DialogResult = DialogResult.OK;
            }
        }
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.ParentForm.Close( );
            this.FindForm( ).DialogResult = DialogResult.Cancel;
        }
         /// <summary>
         /// .自动生成拼音码和五笔码
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void txtName_Leave( object sender , EventArgs e )
        {
            if (this.txtName.Text.IndexOfAny(new char[] { '@', '.', ',', '!', '-', '#', '$', '%', '^', '&', '*', '[', ']', '|', '}', '\'', '?' }) != -1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("无效的药理作用名称.\n" +
                    "无效字符:  '@', '.', ',', '!', '-', '#', '$', '%', '^', '&', '*', '[', ']', '|', '}','\'','?'"));
                this.txtName.Focus();
                this.txtName.SelectAll();
                return;
            }

            Neusoft.HISFC.Models.Base.Spell spellobj = new Neusoft.HISFC.Models.Base.Spell( );
            Neusoft.HISFC.BizLogic.Manager.Spell spell = new Neusoft.HISFC.BizLogic.Manager.Spell( );

            spellobj = spell.Get( this.txtName.Text.Trim() ) as Neusoft.HISFC.Models.Base.Spell;

            this.txtSpellCode.Text = spellobj.SpellCode;
            this.txtWBCode.Text = spellobj.WBCode;
        }
        /// <summary>
        /// 响应键盘事件，用回车键触发Tab事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey( Keys keyData )
        {
            if( keyData == Keys.Enter )
            {
                System.Windows.Forms.SendKeys.Send( "{TAB}" );
            }
            return base.ProcessDialogKey( keyData );
        }
        /// <summary>
        /// 控件初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            functionObject = new Neusoft.HISFC.Models.Pharmacy.PhaFunction( );
            ArrayList al = new ArrayList( );
            al = this.pharmacyConstant.QueryPhaFunction( );
            if( al != null)
            {
                //初始化父级节点列表
                this.cmbparent.AddItems(al );
            }
            //如果是修改或者删除
            if( this.operKind == "UPDATE" || this.operKind == "DELETE" )
            {
                functionObject = ( Neusoft.HISFC.Models.Pharmacy.PhaFunction )this.pharmacyConstant.QueryFunctionByNode( this.nodeCode )[ 0 ];

                ////{FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}  获取原始值：原始药理作用节点
                this.gridLevel = functionObject.GradeLevel;

                this.cmbparent.Tag = functionObject.ParentNode;//父级节点
                this.txtName.Text = functionObject.Name;//节点名
                //{C8D1015E-41B3-4e90-B624-8B47CF81E665} 校验药理作用名称重复
                this.txtName.Tag = functionObject.Name;

                this.txtCode.Enabled = false;
                this.txtCode.Text = functionObject.ID;//节点ID
                this.txtWBCode.Text = functionObject.WBCode;
                this.txtSpellCode.Text = functionObject.SpellCode;
                this.txtMark.Text = functionObject.Memo;
                if( functionObject.IsValid  )
                {
                    this.chkIsValid.Checked = true;
                }
  
            }
            //如果是增加
            if( this.operKind == "INSERT" )
            {
                this.txtName.Text = null;//节点名
                this.txtCode.Text = null;
                this.txtWBCode.Text = null;
                this.txtSpellCode.Text = null;
                this.txtMark.Text = null;
                this.chkIsValid.Checked = true;
                this.cmbparent.Tag = this.nodeCode;//传入的节点做为父节点
            }
            base.OnLoad( e );
        }
        #endregion
    }
}
