using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// [控件名称: ucDrugBillApprove]<br></br>
    /// [功能描述: 摆药单核准]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-22]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDrugBillApprove : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugBillApprove( )
        {
            InitializeComponent( );
        }

        public event System.EventHandler SaveFinished;

        #region 变量

        // 帮助类
        private Neusoft.FrameWork.Public.ObjectHelper objectHelper = new Neusoft.FrameWork.Public.ObjectHelper( );

        //药品管理类
        private Neusoft.HISFC.BizLogic.Pharmacy.Item item = new Neusoft.HISFC.BizLogic.Pharmacy.Item( );

        //摆药单实体
        Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();

        //是否只能药房人员（药师、药剂师）审核
        private bool isPharmaceutistOnly = true;

        /// <summary>
        /// 是否允许部分核准
        /// </summary>
        private bool isPartialApprove = false;

        /// <summary>
        /// 操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = null;

        #endregion

        #region 属性

        /// <summary>
        /// 是否只能药师、药剂师审核
        /// </summary>
        [Description( "是否只能药师、药剂师审核"),Category("设置"),DefaultValue(true)]
        public bool IsPharmaceutistOnly
        {
            get
            {
                return isPharmaceutistOnly; 
            }
            set
            {
                isPharmaceutistOnly = value; 
            }
        }

        ///// <summary>
        ///// 是否对一张单据进行部分核准
        ///// </summary>
        //[Description("是否对一张单据进行部分核准"), Category("设置"), DefaultValue(false)]
        //public bool IsPartialApprove 
        //{
        //    get
        //    {
        //        return this.isPartialApprove;
        //    }
        //    set
        //    {
        //        this.isPartialApprove = value;
        //    }
        //}

        /// <summary>
        /// 操作科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OperDept
        {
            get
            {
                return this.operDept;
            }
            set
            {
                this.operDept = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 根据录入的员工编码取员工姓名
        /// </summary>
        /// <returns></returns>
        private bool GetOperName( )
        {
            //录入员工代码后判断录入是否正确
            string operCode = this.txtOperCode.Text.PadLeft( 6 , '0' );
            string operName = "";
            this.txtOperCode.Text = operCode;
            operName = this.objectHelper.GetName( operCode );
            if( operName == null )
            {
                MessageBox.Show( Language.Msg( "无效的员工代码,请重新录入!" ) );
                this.txtOperCode.SelectAll( );
                this.txtOperCode.Focus( );
                return false;
            }
            this.txtOperName.Text = operName;
            return true;
        }

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsPharmaceutistOnly = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Need_Priv, true, false);
           
            //this.IsPartialApprove = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Part_Approve, true, false);
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 添加摆药单打印显示控件
        /// </summary>
        /// <param name="ucBill">控件名称</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugBill(object ucBill,bool isAddToContainer)
        {
            return this.ucDrugDetail1.AddDrugBill(ucBill,isAddToContainer);
        }

        /// <summary>
        /// 设置审核人输入框及确认按钮得状态
        /// </summary>
        /// <param name="isTrue"></param>
        public void SetEnabled( bool isTrue )
        {
            this.txtOperCode.Enabled = isTrue;
            this.btnOk.Enabled = isTrue;

            //this.ucDrugDetail1.IsShowCheckColumn = false;
            this.ucDrugDetail1.IsAutoCheck = false;
        }

        /// <summary>
        /// 摆药单核准
        /// </summary>
        /// <returns></returns>
        public virtual int ApproveDrugBill( )
        {
            //如果没有选中摆药单，则提示
            if( drugBillClass ==null )
            {
                MessageBox.Show( Language.Msg( "请选择要核准的摆药单" ) );
                return 0;
            }
            //如果该摆药单已核准或者作废，则返回
            if( this.drugBillClass.ApplyState != "1" )
            {
                return 0;
            }
            if( this.txtOperCode.Text == "" || this.txtOperCode.Text == null )
            {
                MessageBox.Show( Language.Msg( "请输入审核人编号！" ) );
                return -1;
            }

            string deptCode = ((Neusoft.HISFC.Models.Base.Employee)item.Operator).Dept.ID;

            //isPartialApprove 参数作废 根据选择数据进行核准操作
            ArrayList al = this.ucDrugDetail1.GetCheckData();
            if (al.Count <= 0)
            {
                MessageBox.Show(Language.Msg("请选择待核准数据"));
                return -1;
            }
            //摆药单核准处理
            if (Function.DrugApprove(al, this.txtOperCode.Text, deptCode) == -1)
            {
                return -1;
            }

            ////此处应该使用操作员的权限科室，目前先使用所在科室
            //if (!this.isPartialApprove)
            //{                
            //    //取摆药单中的明细数据
            //    string billCodes = "'" + drugBillClass.DrugBillNO + "'";
            //    ArrayList al = this.item.QueryApplyOutListByBill(billCodes);
            //    if (al == null)
            //    {
            //        MessageBox.Show(this.item.Err);
            //        return -1;
            //    }
            //    //摆药单核准处理
            //    if (Function.DrugApprove(al, this.txtOperCode.Text, deptCode) == -1)
            //    {
            //        return -1;
            //    }
            //}
            //else
            //{
                
            //}

            return 1;
        }

        /// <summary>
        /// 显示摆药单数据
        /// </summary>
        /// <param name="billClass"></param>
        public virtual void ShowData( Neusoft.HISFC.Models.Pharmacy.DrugBillClass billClass )
        {
            this.drugBillClass = billClass;
            this.ShowData( billClass.DrugBillNO , billClass.ApplyState == "2" ? false : true );
        }

        /// <summary>
        /// 显示摆药单摆药数据
        /// </summary>
        /// <param name="drugBillCodes">摆药单号，如果是组合，则以“，”隔开</param>
        /// <param name="isNeedApprove">是否需要核准</param>
        public virtual void ShowData( string drugBillCodes , bool isNeedApprove )
        {         
            //清空明细数据
            this.Clear( );

            if (drugBillCodes.IndexOf(',') == -1)
            {
                drugBillCodes = "'" + drugBillCodes + "'";
            }

            //保存当前摆药单号码及是否需要核准
            string originalBillNO = this.drugBillClass.DrugBillNO;

            this.drugBillClass.DrugBillNO = drugBillCodes;
            this.drugBillClass.ApplyState = isNeedApprove == true ? "1" : "2";

            #region 根据是否可以被核准标记，设置控件是否可以显示

            if ( isNeedApprove )
            {
                this.SetEnabled( true);
                this.txtOperCode.Text = "";
                this.txtOperName.Text = "";
            }
            else
            {
                this.SetEnabled( false );
                this.txtOperCode.Text = drugBillClass.Oper.ID;
                this.txtOperName.Text = this.objectHelper.GetName( drugBillClass.Oper.ID );
            }

            #endregion

            //如果没有选中摆药单，则清空数据
            if( drugBillCodes == "''" )
            {
                this.Clear( );
                this.SetEnabled( false );
                return;
            }

            #region 取摆药单中的明细数据 

            ArrayList al = this.item.QueryApplyOutListByBill( drugBillCodes );
            if( al == null )
            {
                MessageBox.Show( this.item.Err );
                return;
            }

            ArrayList alState = new ArrayList();
            if (this.isPartialApprove)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
                {
                    if (isNeedApprove && info.State == "2")
                        continue;
                    if (!isNeedApprove && info.State == "1")
                        continue;

                    alState.Add(info);
                }
            }
            else
            {
                alState = al;
            }
            //显示明细数据
            this.ucDrugDetail1.ShowData( alState , drugBillClass );
            this.txtOperCode.Focus( );

            #endregion

            //保存原摆药单号
            this.drugBillClass.DrugBillNO = originalBillNO;
        }

        /// <summary>
        /// 清空当前数据
        /// </summary>
        public virtual void Clear( )
        {
            this.ucDrugDetail1.Clear( );
        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual void Print( )
        {
            #region 增加核准的打印权限 wbo 2010-10-11

            Neusoft.HISFC.BizLogic.Manager.Constant consMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
            Neusoft.FrameWork.Models.NeuObject obj = consMgr.GetConstant("PhaPrintPriv", consMgr.Operator.ID);
            Neusoft.HISFC.Models.Base.Const cons = obj as Neusoft.HISFC.Models.Base.Const;
            if (cons == null || string.IsNullOrEmpty(cons.ID) || cons.IsValid == false)
            {
                MessageBox.Show("无摆药单补打权限，请联系药学部或信息科！");
                return;
            }
            if (cons.IsValid == false)
            {
                MessageBox.Show("摆药单补打权限无效，请联系药学部或信息科！");
                return;
            }

            #endregion

            if (MessageBox.Show("是否打印?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ucDrugDetail1.Print();
                MessageBox.Show("打印完毕！");
            }
        }

         /// <summary>
         /// 打印预览
         /// </summary>
        public virtual void PrintPreview( )
        {
            this.ucDrugDetail1.Preview( );
        }
        #endregion

        #region 事件

        /// <summary>
        /// 确定核准事件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click( object sender , EventArgs e )
        {

            if( this.GetOperName( ) )
            {
                if (this.ApproveDrugBill() == 1)
                {
                    MessageBox.Show(Language.Msg("核准成功"));

                    if (this.SaveFinished != null)
                    {
                        this.SaveFinished(null, System.EventArgs.Empty);
                    }
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 审核人输入框回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOperCode_KeyDown( object sender , KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter )
            {
                if( this.GetOperName( ) )
                {
                    this.btnOk.Focus( );
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 控件装载事件、控件信息初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            try
            {
                this.InitControlParam();

                this.ucDrugDetail1.IsShowBillPreview = true;

                //取人员数据列表，根据用户录入的人员代码检索姓名
                Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager( );
                //根据属性设置，是否只有药剂师才能核准
                if( this.isPharmaceutistOnly )
                {
                    objectHelper.ArrayObject = manager.QueryEmployee( Neusoft.HISFC.Models.Base.EnumEmployeeType.P );
                }
                else
                {
                    objectHelper.ArrayObject = manager.QueryEmployeeAll( );
                }
                //设置控件初始状态
                this.SetEnabled( false );
            }
            catch
            {

            }
            base.OnLoad( e );
        }

        #endregion

    }
}
