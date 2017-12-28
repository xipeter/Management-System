using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Components.DrugStore.InBase
{
    /// <summary>
    /// [控件名称:ucDrugBill]<br></br>
    /// [功能描述: 摆药单设置]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-10]<br></br>
    /// <修改记录>
    ///     改的烦死。。。。
    ///     郁闷 写的程序。
    /// </修改记录>
    ///  />
    /// </summary>
    public partial class ucDrugBill : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugBill( )
        {
            InitializeComponent( );
        }

        #region 变量

        //摆药单分类实体类
        private DrugBillClass drugBillClassInfo;
        //药房管理类
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore( ); 

        #endregion

        #region 方法

        #region 摆药单设置

        /// <summary>
        /// 判断传入摆药单信息是否有效
        /// </summary>
        /// <param name="drugBillClass">摆药单信息</param>
        /// <returns>成功返回True  失败返回False</returns>
        private bool IsDrugBillDataValid(DrugBillClass drugBillClass)
        {
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(drugBillClass.Memo, 150))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("备注字段超长"));
                return false;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(drugBillClass.Name, 30))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("摆药单名称超长"));
                return false;
            }

            foreach (ListViewItem lv in this.lvPutDrugBill1.Items)
            {
                DrugBillClass tempDrugBill = lv.Tag as DrugBillClass;
                if (tempDrugBill == null)
                {
                    continue;
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(tempDrugBill.Memo, 150))
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("备注字段超长"));
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(tempDrugBill.Name, 30))
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("摆药单名称超长"));
                    return false;
                }

                if (tempDrugBill.ID == drugBillClass.ID)
                {
                    continue;
                }                

                if (lv.Text == drugBillClass.Name)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(drugBillClass.Name + "摆药单名称重复 请重新维护"));
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 从tabpage2中中取数据，保存在myDrugBillClass中。
        /// </summary>
        private DrugBillClass GetDrugBillItem( )
        {
            if( this.drugBillClassInfo == null )
            {
                drugBillClassInfo = new DrugBillClass( );
            }

            this.drugBillClassInfo.Name = this.txtName.Text;                       //摆药分类名称
            this.drugBillClassInfo.PrintType.ID = this.cbxPrinttype.Tag;           //打印类型
            this.drugBillClassInfo.DrugAttribute.ID = this.cbxPutType.Tag.ToString(); //摆药类型
            this.drugBillClassInfo.IsValid = this.cbxIsValid.Checked;              //是否有效
            this.drugBillClassInfo.Memo = this.txtMark.Text;               //备注
            return this.drugBillClassInfo;
        }

        /// <summary>
        /// 从myDrugBillClass中取数据，显示在tabpage2中。
        /// </summary>
        private void SetDrugBillItem( DrugBillClass drugbill )
        {
            this.drugBillClassInfo = drugbill;

            this.txtName.Text = this.drugBillClassInfo.Name;          //摆药分类名称
            this.cbxPrinttype.Tag = this.drugBillClassInfo.PrintType.ID;  //打印类型
            this.cbxPutType.Tag = this.drugBillClassInfo.DrugAttribute.ID;   //摆药类型
            this.cbxIsValid.Checked = this.drugBillClassInfo.IsValid;       //是否有效
            this.txtMark.Text = this.drugBillClassInfo.Memo;          //备注
            //手术室摆药单不能修改
            if( this.drugBillClassInfo.ID == "P" || this.drugBillClassInfo.ID == "R" )
            {
                this.lvPutDrugBill1.AllowEdit = false;
            }
            else
            {
                this.lvPutDrugBill1.AllowEdit = true;
            }
        }

        #endregion

        #region 摆药单属性设置

        /// <summary>
        /// 重置摆药单属性列表
        /// </summary>
        private void ResetDrugBillAttribute( )
        {
            //清空医嘱类型
            this.tvAdviceKinde.Nodes[ 0 ].Checked = false;

            //清空药品用法
            this.tvUse.Nodes[ 0 ].Checked = false;

            //清空药品剂型
            this.tvMode.Nodes[ 0 ].Checked = false;

            //清空药品性质
            this.tvQuality.Nodes[ 0 ].Checked = false;

            //清空药品类型
            this.tvType.Nodes[ 0 ].Checked = false;
        }

        /// <summary>
        /// 根据摆药单编码初始化摆药单属性树
        /// </summary>
        /// <param name="drugBillClassCode">摆药单编码</param>
        public void ShowListByDrugBill( string drugBillClassCode )
        {
            try
            {
                ArrayList al;
                //医嘱类别
                this.tvAdviceKinde.Nodes[ 0 ].Checked = false;
                al = this.drugStoreManager.QueryDrugBillList( drugBillClassCode , "TYPE_CODE" );
                foreach( DrugBillList info in al )
                {
                    foreach( TreeNode tn in this.tvAdviceKinde.Nodes[ 0 ].Nodes )
                    {
                        NeuObject obj = ( NeuObject )tn.Tag;
                        if( info.ID == obj.ID )
                        {
                            tn.Checked = true;
                        }
                    }
                }
                //药品用法
                this.tvUse.Nodes[ 0 ].Checked = false;
                al = this.drugStoreManager.QueryDrugBillList( drugBillClassCode , "USAGE_CODE" );
                foreach( DrugBillList info in al )
                {
                    foreach( TreeNode tn in this.tvUse.Nodes[ 0 ].Nodes )
                    {
                        NeuObject obj = ( NeuObject )tn.Tag;
                        if( info.ID == obj.ID )
                        {
                            tn.Checked = true;
                        }
                    }
                }
                //药品剂型
                this.tvMode.Nodes[ 0 ].Checked = false;
                al = this.drugStoreManager.QueryDrugBillList( drugBillClassCode , "DOSE_MODEL_CODE" );
                foreach( DrugBillList info in al )
                {
                    foreach( TreeNode tn in this.tvMode.Nodes[ 0 ].Nodes )
                    {
                        NeuObject obj = ( NeuObject )tn.Tag;
                        if( info.ID == obj.ID )
                        {
                            tn.Checked = true;
                        }
                    }
                }
                //药品性质
                this.tvQuality.Nodes[ 0 ].Checked = false;
                al = this.drugStoreManager.QueryDrugBillList( drugBillClassCode , "DRUG_QUALITY" );
                foreach( DrugBillList info in al )
                {
                    foreach( TreeNode tn in this.tvQuality.Nodes[ 0 ].Nodes )
                    {
                        NeuObject obj = ( NeuObject )tn.Tag;
                        if( info.ID == obj.ID )
                        {
                            tn.Checked = true;
                        }
                    }
                }
                //药品类别
                this.tvType.Nodes[ 0 ].Checked = false;
                al = this.drugStoreManager.QueryDrugBillList( drugBillClassCode , "DRUG_TYPE" );
                foreach( DrugBillList info in al )
                {
                    foreach( TreeNode tn in this.tvType.Nodes[ 0 ].Nodes )
                    {
                        NeuObject obj = ( NeuObject )tn.Tag;
                        if( info.ID == obj.ID )
                        {
                            tn.Checked = true;
                        }
                    }
                }
            }
            catch( Exception e )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "初始化摆药单属性信息出错" ) + e.Message );
            }
        }

        #endregion

        #region 数据操作

        /// <summary>
        /// 增加摆药单
        /// </summary>
        private void AddDrugBill()
        {
            if (this.neuTabControl1.TabPages.ContainsKey(tabPage2.Name))
            {
                this.neuTabControl1.TabPages.Remove(this.tabPage2);
            }
            //设置要插入的节点
            DrugBillClass info = new DrugBillClass( );
            info.Name = "新建摆药单";
            info.IsValid = true;

            //在详细信息中显示新增加的摆药单
            this.SetDrugBillItem( info );

            //重置摆药单属性树未选中状态
            this.ResetDrugBillAttribute( );

            this.neuTabControl1.TabPages.Add( this.tabPage2 );
            this.neuTabControl1.SelectedIndex = 1;
        }

        /// <summary>
        /// 修改摆药单类别
        /// </summary>
        private void ModifyDrugBill( )
        {
            if( this.lvPutDrugBill1.SelectedItems.Count > 0 )
            {
                if (this.drugBillClassInfo.ID == "" || this.drugBillClassInfo.ID == null)
                {
                    this.lvPutDrugBill1.ClearSelection();

                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择要修改的摆药单"));
                    return;
                }

                //显示摆药单编辑信息
                this.neuTabControl1.TabPages.Add( this.tabPage2 );
                this.neuTabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择要修改的摆药单"));
                //重新设置摆药单属性
                this.neuTabControl1.SelectedIndex = 1;
                this.ResetDrugBillAttribute( );
                this.drugBillClassInfo = new DrugBillClass( );

            }
        }

        /// <summary>
        /// 删除一条摆药单分类数据
        /// </summary>
        private void DeleteDrugBill( )
        {
            //判断是否选中一个摆药单
            if( this.lvPutDrugBill1.SelectedItems.Count > 0 )
            {
                //获取当前摆药单信息
                this.GetDrugBillItem( );
            }
            else
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择您要删除的摆药单！" ));

                return;
            }

            if (this.drugBillClassInfo.ID == "P" || this.drugBillClassInfo.ID == "R")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("退药单及非医嘱摆药单不允许删除"),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if( this.drugBillClassInfo.ID != "" )
            {
    
                //弹出提示窗口
                System.Windows.Forms.DialogResult result;
                result = MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "摆药单删除后将不可恢复,您确定要删除【" + drugBillClassInfo.Name + "】摆药单吗？" ), Neusoft.FrameWork.Management.Language.Msg( "删除提示") , System.Windows.Forms.MessageBoxButtons.OKCancel );
                if( result == DialogResult.Cancel ) return;

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( Neusoft.FrameWork.Management.Language.Msg( "正在删除摆药单及其明细信息，请稍等..." ));
                Application.DoEvents( );

                //删除事务
                int parmClass;
                int parmList;

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );

                drugStoreManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //先删除摆药单属性信息
                parmList = drugStoreManager.DeleteDrugBillList( this.drugBillClassInfo.ID );
                //再删除摆药单信息
                parmClass = drugStoreManager.DeleteDrugBillClass( this.drugBillClassInfo.ID );

                if( parmList == -1 || parmClass == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( this.drugStoreManager.Err , Neusoft.FrameWork.Management.Language.Msg( "Neusoft.FrameWork.Management.Language.Msg( 提示"));
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
                    return;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "删除成功！") );
                    
                }
            }
            //重置摆药单属性树未未选中状态
            this.ResetDrugBillAttribute( );
            //删除节点
            this.lvPutDrugBill1.DeleteItem( this.lvPutDrugBill1.SelectedIndices[ 0 ] );
            this.lvPutDrugBill1.Focus( );
            this.neuTabControl1.SelectedIndex = 0;
            this.drugBillClassInfo = new DrugBillClass( );
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
        }

        /// <summary>
        /// 保存摆药单类别
        /// </summary>
        private void SaveDrugBill()
        {
            //获取当前摆药单最新的编辑信息
            this.GetDrugBillItem();
            //有效性判断
            if (!this.IsDrugBillDataValid(this.drugBillClassInfo))
            {
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            drugStoreManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            bool isNewDrugBill = false;
            //保存操作
            if (this.drugBillClassInfo.ID == "")
            {
                isNewDrugBill = true;
            }

            int parm = drugStoreManager.SetDrugBillClass(this.drugBillClassInfo);
            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(this.drugStoreManager.Err);
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));

            if (isNewDrugBill)
            {
                this.lvPutDrugBill1.AddItem(this.drugBillClassInfo,true);

                this.drugBillClassInfo = new DrugBillClass();
            }
            else
            {
                //用更新后的节点信息修改ListView中对应的节点
                this.lvPutDrugBill1.ModifyItem(this.drugBillClassInfo, this.lvPutDrugBill1.SelectedIndices[0]);
            }

            this.neuTabControl1.SelectedIndex = 0;            
        }

        /// <summary>
        /// 保存摆药单明细信息
        /// </summary>
        /// <param name="isIncrement">是否增量保存</param>
        private void SaveDrugBillList( bool isIncrement )
        {
            if( this.drugBillClassInfo == null )
            {
                return;
            }
            //判断传入参数是否有效
            if( this.drugBillClassInfo.ID == "" )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请在摆药单分类列表中选择要维护的记录并保存" ));
                return ;
            }
            //非医嘱摆药单和退药单不允许设置明细信息
            if(this.drugBillClassInfo.ID == "P" )
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(  "非医嘱摆药单(手术室摆药单)不需要保存明细信息。") );
                return ;
            }
            if (this.drugBillClassInfo.ID == "R")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("退药单不需要保存明细信息。"));
                return;
            }
            //提示确认是否保存
            if (!isIncrement)
            {
                DialogResult rs = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("确认进行全部保存操作吗? 保存操作耗时时间较长"),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (rs == DialogResult.No)
                {
                    return;
                }
            }

            #region 取树型列表中被选中的项，并检测是否漏选
            //医嘱类型
            ArrayList alOrderType = new ArrayList( );
            foreach( TreeNode tn in this.tvAdviceKinde.Nodes[ 0 ].Nodes )
            {
                if( tn.Checked )
                {
                    alOrderType.Add( ( Neusoft.HISFC.Models.Order.OrderType )tn.Tag ); 
                }
            }
            if( alOrderType.Count == 0 )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择医嘱类型" ));
                return ;
            }
            //药品用法
            List<Neusoft.HISFC.Models.Base.Const> alUsage = this.tvUse.SelectedNodes;
            if( alUsage.Count == 0 )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择药品用法" ));
                return ;
            }
            //药品剂型
            List<Neusoft.HISFC.Models.Base.Const> alDosageForm = this.tvMode.SelectedNodes;
            if( alDosageForm.Count == 0 )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择药品剂型" ));
                return ;
            }
            //药品性质
            List<Neusoft.HISFC.Models.Base.Const> alDrugQuality = this.tvQuality.SelectedNodes;
            if( alDrugQuality.Count == 0 )
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg( "请选择药品性质" ));
                return ;
            }
            //药品类型
            List<Neusoft.HISFC.Models.Base.Const> alDrugType = this.tvType.SelectedNodes;
            if( alDrugType.Count == 0 )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择药品类型" ));
                return ;
            }
            #endregion

            int parm;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );
            //t.BeginTransaction( );

            drugStoreManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( Neusoft.FrameWork.Management.Language.Msg( "正在保存摆药单及其明细信息，请稍等..." ));
            Application.DoEvents( );

            //根据参数判断是否需要先删除后增加。
            if( !isIncrement )
            {
                //先删除旧摆药单分类明细中的所有数据，然后插入新的数据。
                parm = drugStoreManager.DeleteDrugBillList( this.drugBillClassInfo.ID );
                if( parm == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( this.drugStoreManager.Err );
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
                    return ;
                }
            }

            //插入新数据，用医嘱类型，用法，剂型，药品性质，药铺类型的全排列分别插入明细表。	
            DrugBillList myList = new DrugBillList( );
            myList.DrugBillClass.ID = this.drugBillClassInfo.ID;
            int pro = 0; //进度条上显示的数据
            int max = alOrderType.Count * alUsage.Count * alDosageForm.Count * alDrugQuality.Count * alDrugType.Count;
            foreach( Neusoft.HISFC.Models.Order.OrderType OrderType in alOrderType )
            {
                foreach( NeuObject Usage in alUsage )
                {
                    foreach( NeuObject DosageForm in alDosageForm )
                    {
                        foreach( NeuObject DrugQuality in alDrugQuality )
                        {
                            foreach( NeuObject DrugType in alDrugType )
                            {
                                //为摆药单明细实例赋值
                                myList.OrderType = OrderType ;
                                myList.Usage = Usage;
                                myList.DosageForm = DosageForm;
                                myList.DrugQuality = DrugQuality;
                                myList.DrugType = DrugType;

                                //插入摆药单分类明细表
                                parm = this.drugStoreManager.InsertDrugBillList( myList );
                                if( parm != 1 )
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    if( this.drugStoreManager.DBErrCode == 1 )
                                    {
                                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg( "数据已经存在，不能重复维护！ 请检查上是否在其他摆药单内已存在以下组合信息\n") +
                                            " 医嘱类型;" + OrderType.ID + OrderType.Name +
                                            " 用法:" + Usage.ID + Usage.Name +
                                            " 剂型:" + DosageForm.ID + DosageForm.Name +
                                            " 药品性质:" + DrugQuality.ID + DrugQuality.Name +
                                            " 药品类型:" + DrugType.ID + DrugType.Name );
                                    }
                                    else
                                    {
                                        MessageBox.Show( this.drugStoreManager.Err );
                                    }
                                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
                                    return ;
                                }
                                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( pro++ , max );
                                Application.DoEvents( );
                            }
                        }
                    }
                }
            }
            //提交数据库
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg( "保存成功！") );
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
            return;
        }

        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            try
            {
                //初始化打印类型
                this.cbxPrinttype.AddItems(BillPrintType.List());
                //初始化摆药类型
                this.cbxPutType.AddItems(DrugAttribute.List());
                //隐藏tabpage2
                this.neuTabControl1.TabPages.Remove(this.tabPage2);

                this.lvPutDrugBill1.CheckBoxes = false;
                this.lvPutDrugBill1.MultiSelect = false;
            }
            catch { }

            base.OnLoad( e );
        }

        /// <summary>
        /// 保存摆药单类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click( object sender , EventArgs e )
        {
            this.SaveDrugBill( );
        }

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
                //设置当前摆药单信息
                this.SetDrugBillItem( this.lvPutDrugBill1.SelectedItems[ 0 ].Tag as DrugBillClass );
                if( this.drugBillClassInfo.ID != null )
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg( "正在生成预览信息..." ));
                    Application.DoEvents( );
                    //根据摆药单编码初始化属性树
                    this.ShowListByDrugBill( this.drugBillClassInfo.ID );
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
                }
            }
            else
            {
                //重新设置摆药单属性
                this.ResetDrugBillAttribute( );
                this.drugBillClassInfo = new DrugBillClass( );
            }
        }

        /// <summary>
        /// tabpage切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTabControl1_SelectedIndexChanged( object sender , EventArgs e )
        {
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                this.neuTabControl1.TabPages.Remove(this.tabPage2);
            }
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService( );
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit( object sender , object NeuObject , object param )
        {
            //增加工具栏
            this.toolBarService.AddToolButton( "增加" , "增加摆药单" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加 , true , false , null );
            this.toolBarService.AddToolButton( "编辑" , "编辑摆药单" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改 , true , false , null );
            this.toolBarService.AddToolButton( "删除" , "删除摆药单" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除 , true , false , null );
            //this.toolBarService.AddToolButton( "保存" , "保存设置" , 3 , true , false , null );
            this.toolBarService.AddToolButton( "增量保存" , "增量保存" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z暂存 , true , false , null );
            //this.toolBarService.AddToolButton( "退出" , "退出当前窗口" , 5 , true , false , null );
            return this.toolBarService;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave( object sender , object neuObject )
        {
            
            this.SaveDrugBillList( false );
            return base.OnSave( sender , neuObject );
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
                    this.AddDrugBill( );
                    break;
                case "编辑":
                    this.ModifyDrugBill( );
                    break;
                case "删除":
                    this.DeleteDrugBill( );
                    break;
                case "增量保存":
                    this.SaveDrugBillList( true );
                    break;
            }

        }
        #endregion


    }
}
