using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.WinForms.DrugStore
{
    /// <summary>
    /// [控件名称: frmDrugBillApprove]<br></br>
    /// [功能描述: 摆药单核准<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-22]<br></br>
    /// <修改记录 
    ///		修改人='梁俊泽' 
    ///		修改时间='2007-03-dd' 
    ///		修改目的='保存后刷新列表'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class frmDrugBillApprove : Neusoft.FrameWork.WinForms.Forms.BaseStatusBar, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public frmDrugBillApprove( )
        {
            InitializeComponent( );
            
            this.ucApproveList1.SelectBillEvent += new Neusoft.HISFC.Components.DrugStore.Inpatient.ucApproveList.SelectBillHandler( ucApproveList1_SelectBillEvent );
            this.ucApproveList1.RootNodeCheckedEvent += new EventHandler(ucApproveList1_RootNodeCheckedEvent);
            this.ucDrugBillApprove1.SaveFinished += new EventHandler(ucDrugBillApprove1_SaveFinished);
        }           

        /// <summary>
        /// 操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = null;

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

                this.ucApproveList1.OperDept = value;
                this.ucDrugBillApprove1.OperDept = value;
            }
        }

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载摆药单控件..."));
            Application.DoEvents();

            #region 反射读取标签格式

            object interfacePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;
            if (interfacePrint != null)
            {
                this.ucDrugBillApprove1.AddDrugBill(interfacePrint, true);
            }
            else
            {
                //object[] o = new object[] { };

                //try
                //{
                //    //门诊标签打印接口实现类
                //    Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                //    string billValue = ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Inpatient_Print_Bill, true, "Report.DrugStore.ucDrugBill");

                //    System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", billValue, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
                //    object oLabel = objHandel.Unwrap();

                //    this.ucDrugBillApprove1.AddDrugBill(oLabel, true);
                //}
                //catch (System.TypeLoadException ex)
                //{
                //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //    MessageBox.Show(Language.Msg("摆药单命名空间无效\n" + ex.Message));
                //    return;
                //}

                MessageBox.Show("未设置住院摆药单据实现,无法进行摆药单打印", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion

            Neusoft.HISFC.Components.DrugStore.Function.IsApproveInitPrintInterface = true;

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 显示合并数据
        /// </summary>
        private void ShowMergeData( )
        {
            string drugBillCodes = "";
            bool isNeedApprove = false;
            //获取摆药单列表中，被选中的摆药单组合,并返回是否可以对摆药单进行核准
            isNeedApprove = this.ucApproveList1.GetCheckBill( ref drugBillCodes );
            if( drugBillCodes != null && drugBillCodes != "''")
            {
                this.ucDrugBillApprove1.ShowData( drugBillCodes , isNeedApprove );
            }
        }
        
        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载，数据初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmDrugBillApprove_Load( object sender , EventArgs e )
        {
            this.WindowState = FormWindowState.Maximized;

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.InitData();

                ////是否进行部分核准 
                //this.ucDrugBillApprove1.IsPartialApprove = true;

                //刷新当前摆药单列表
                this.ucApproveList1.RefreshBill();
            }
        }

        /// <summary>
        /// 摆药单列表选择事件(单个摆药单数据显示)
        /// </summary>
        /// <param name="drugBillClass"></param>
        private void ucApproveList1_SelectBillEvent( Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass )
        {
            if( drugBillClass != null )
            {
                //this.ucDrugBillApprove1.ShowData( drugBillClass.DrugBillNO.ToString() ,true );
                if (!drugBillClass.Name.Contains("补打"))
                {
                    drugBillClass.Name += "  补打";//{DE81F86D-5AD1-41d6-9F2D-A60D4D19AEFF}
                }
                this.ucDrugBillApprove1.ShowData(drugBillClass);
            }
        }

        private void ucApproveList1_RootNodeCheckedEvent(object sender, EventArgs e)
        {
            if ((bool)sender)
            {
                this.ShowMergeData();
            }
            else
            {
                this.ucDrugBillApprove1.Clear();
            }
        }   

        private void ucDrugBillApprove1_SaveFinished(object sender, EventArgs e)
        {
            this.ucApproveList1.RefreshBill();
        }

        /// <summary>
        /// 工具栏按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip1_ItemClicked( object sender , ToolStripItemClickedEventArgs e )
        {
            switch( e.ClickedItem.Name )
            {
                //刷新
                case "tsbRefresh":
                    //刷新当前摆药单列表
                    this.ucApproveList1.RefreshBill( );
                    //清空摆药单显示中的数据
                    this.ucDrugBillApprove1.Clear( );
                    break;
                //合并
                case "tsbMerge": 
                    //显示合并数据
                    this.ShowMergeData( );
                    break;
                //打印
                case "tsbPrint":
                    this.ucDrugBillApprove1.Print( );
                    break;
                //退出
                case "tsbExit": 
                    this.Close( );
                    break;

            }
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] printType = new Type[1];
                printType[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint);

                return printType;
            }
        }

        #endregion

 
    }
}