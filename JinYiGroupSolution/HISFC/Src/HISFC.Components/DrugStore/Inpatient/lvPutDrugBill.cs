using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Object.Pharmacy;

namespace Neusoft.UFC.DrugStore.Inpatient
{
    public partial class lvPutDrugBill : Neusoft.NFC.Interface.Controls.NeuListView
    {
        public lvPutDrugBill( )
        {
            InitializeComponent( );
            //初始化
            try
            {
                this.InitListView();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 带容器的构造器
        /// </summary>
        /// <param name="container"></param>
        public lvPutDrugBill( IContainer container )
        {
            InitializeComponent( );
            container.Add( this );
            //初始化
            try
            {
                this.InitListView( );
            }
            catch
            {
            }
        }

        #region 变量
        /// <summary>
        /// 是否可以编辑摆药单信息
        /// </summary>
        private bool isAllowEdit = true;

        #endregion

        #region 属性
        /// <summary>
        /// 是否可以编辑摆药单信息
        /// </summary>
        [Description( "是否可以编辑摆药单信息" ) , Category( "设置" ) , DefaultValue( true )]
        public bool AllowEdit
        {
            get
            {
                return this.isAllowEdit;
            }
            set
            {
                this.isAllowEdit = value;
            }

        }
        /// <summary>
        /// 当前选中的摆药单信息
        /// </summary>
        [Description( "当前选中的摆药单信息" ) , Category( "设置" )]
        public virtual List<DrugBillClass> SelectedDrugBill
        {
            get
            {
                List<DrugBillClass> selectedBill = new List<DrugBillClass>( );
                if( this.CheckBoxes && this.Items.Count > 0 )
                {
                    foreach( ListViewItem item in this.Items )
                    {
                        if( item.Checked )
                        {
                            selectedBill.Add( item.Tag as DrugBillClass );
                        }
                    }
                }
                return selectedBill;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 初始化摆药单信息
        /// </summary>
        protected virtual void InitListView( )
        {
            if( this.DesignMode )
            {
                return;
            }
            this.SuspendLayout( );
            this.Columns.Clear( );
            this.Items.Clear( );

            this.Columns.Add( "摆药单名称" , 160 , HorizontalAlignment.Left );
            this.Columns.Add( "打印类型" , 70 , HorizontalAlignment.Center );
            this.Columns.Add( "是否有效" , 70 , HorizontalAlignment.Center );
            this.Columns.Add( "备注" , 200 , HorizontalAlignment.Left );

            try
            {
                Neusoft.HISFC.Management.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.Management.Pharmacy.DrugStore( );
                ArrayList drugBillClassList = new ArrayList( );
                drugBillClassList = drugStore.QueryDrugBillClassList( );

                foreach( DrugBillClass billClass in drugBillClassList )
                {
                    this.AddItem( billClass );
                }
            }
            catch( Exception e )
            {
                //MessageBox.Show( e.Message );
            }
            this.ResumeLayout( );
        }

        /// <summary>
        /// 增加单条摆药单信息
        /// </summary>
        /// <param name="billClass">摆药单分类实体</param>
        /// <returns></returns>
        protected virtual int AddItem( DrugBillClass billClass )
        {
            if( billClass != null )
            {
                //设置插入的节点信息
                ListViewItem lvi = new ListViewItem( );

                //区别有效和无效的项目图标
                if( billClass.IsValid )
                {
                    lvi.ImageIndex = 0;
                }
                else
                {
                    lvi.ImageIndex = 1;
                }
                //如果是新增加的项目，显示特殊的图标
                if( billClass.ID == "" )
                {
                    lvi.ImageIndex = 2;
                }

                //Tag属性保存摆药单分类实体
                lvi.Tag = billClass;
                lvi.Text = billClass.Name;
                //添加listView的子节点
                lvi.SubItems.Add( billClass.PrintType.Name );
                lvi.SubItems.Add( billClass.IsValid ? "有效" : "无效" );
                lvi.SubItems.Add( billClass.Memo );
                this.Items.Add( lvi );
                return 0;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 修改单条摆药单信息
        /// </summary>
        /// <param name="billClass">摆药单分类实体</param>
        /// <returns></returns>
        protected virtual int ModifyItem( DrugBillClass billClass , int index )
        {
            if( billClass != null && index >= 0 )
            {
                //区别有效和无效的项目图标
                if( billClass.IsValid )
                {
                    this.Items[ index ].ImageIndex = 0;
                }
                else
                {
                    this.Items[ index ].ImageIndex = 1;
                }
                //如果是新增加的项目，显示特殊的图标
                if( billClass.ID == "" )
                {
                    this.Items[ index ].ImageIndex = 2;
                }

                //Tag属性保存摆药单分类实体
                this.Items[ index ].Tag = billClass;
                //添加listView的子节点
                this.Items[ index ].SubItems[ 0 ].Text = billClass.Name;
                this.Items[ index ].SubItems[ 1 ].Text = billClass.PrintType.Name;
                this.Items[ index ].SubItems[ 2 ].Text = billClass.IsValid ? "有效" : "无效";
                this.Items[ index ].SubItems[ 3 ].Text = billClass.Memo;
                return 0;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 删除单条摆药单信息
        /// </summary>
        /// <param name="billClass">摆药单分类实体</param>
        /// <returns></returns>
        protected virtual int DeleteItem( DrugBillClass billClass )
        {
            if( billClass != null )
            {
                foreach( ListViewItem item in this.Items )
                {
                    if( item.Tag == billClass )
                    {
                        this.Items.Remove( item );
                    }
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 删除单条摆药单信息
        /// </summary>
        /// <param name="index">要删除的列表索引</param>
        /// <returns></returns>
        protected virtual int DeleteItem( int index )
        {
            if( index >= 0 )
            {
                this.Items.RemoveAt( index );
                return 0;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}
