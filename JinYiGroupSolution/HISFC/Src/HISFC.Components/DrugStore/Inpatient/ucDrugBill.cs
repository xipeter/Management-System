using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Object.Pharmacy;

namespace Neusoft.UFC.DrugStore.Inpatient
{
    public partial class ucDrugBill : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDrugBill( )
        {
            InitializeComponent( );
        }

        #region 事件

        /// <summary>
        /// 选择摆药单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvPutDrugBill1_SelectedIndexChanged( object sender , EventArgs e )
        {
            if( this.lvPutDrugBill1.SelectedItems.Count > 0 )
            {
                //置所有的非当前摆药单为未选中状态
                foreach( ListViewItem lvi in this.lvPutDrugBill1.CheckedItems )
                {
                    lvi.Checked = false;
                }
                this.lvPutDrugBill1.SelectedItems[ 0 ].Checked = true;
            }
            else
            {

            }
        }

        private void lvPutDrugBill1_DoubleClick( object sender , EventArgs e )
        {

        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService( );

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            //初始化打印类型
            this.cbxPrinttype.AddItems( BillPrintType.List( ) );
            //初始化摆药类型
            this.cbxPutType.AddItems( DrugAttribute.List( ) );
            //隐藏tabpage2
            //this.neuTabControl1.TabPages.Remove( this.tabPage2 );
            base.OnLoad( e );
        }

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit( object sender , object neuObject , object param )
        {
            //增加工具栏
            this.toolBarService.AddToolButton( "增加" , "增加摆药单" , 0 , true , false , null );
            this.toolBarService.AddToolButton( "删除" , "删除摆药单" , 1 , true , false , null );
            this.toolBarService.AddToolButton( "保存" , "保存设置" , 2 , true , false , null );
            this.toolBarService.AddToolButton( "增量保存" , "增量保存" , 3 , true , false , null );
            return this.toolBarService;
        }
        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked( object sender , ToolStripItemClickedEventArgs e )
        {
            switch( e.ClickedItem.Text )
            {
                case "增加":
                    //this.AddDrugControl( );
                    break;
                case "删除":
                    //this.DeleteDrugControl( );
                    break;
                case "保存":
                    //this.SaveDrugControl( );
                    break;
                case "增量保存":
                    //this.SaveDrugControl( );
                    break;
            }

        }
        #endregion

    }
}
