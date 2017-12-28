using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PManager = Neusoft.HISFC.BizLogic.Pharmacy.Preparation;
using PObject = Neusoft.HISFC.Models.Preparation;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 成本价计算公式]<br></br>
    /// [创 建 者: 彭真]<br></br>
    /// [创建时间: 2008-04]<br></br>
    /// </summary>
    public partial class ucCostPriceFormula : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCostPriceFormula ( )
        {
            InitializeComponent ( );
        }

        #region 定义
        /// <summary>
        /// 制剂管理药品列表树
        /// </summary>
        private tvDrugList tvList = null;
  
        /// <summary>
        /// 药品项目管理类
        /// </summary>
        HISFC.BizLogic.Pharmacy.Item itemMr = new Neusoft.HISFC.BizLogic.Pharmacy.Item ( );
        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation ( );
        /// <summary>
        /// 药品哈希表（名称为key）
        /// </summary>
        private Dictionary<string , string> drugNameDict = new Dictionary<string , string> ( );
        /// <summary>
        /// 药品哈希表（编码为key）
        /// </summary>
        private Dictionary<string , string> drugCodeDict = new Dictionary<string , string> ( );
        #endregion
        

        #region 方法
        /// <summary>
        /// 树列表加载
        /// </summary>
        /// <returns></returns>
        protected void ShowList ( )
        {
            this.tvList.ShowDrugList ( );

        }
       
        /// <summary>
        /// 配制处方信息 并显示
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowPrescription ( string drugCode )
        {

            this.neuSpread1_Sheet1.RowCount = 0;
            drugCodeDict.Clear ( );
            drugNameDict.Clear ( );
            
            List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> al = this.preparationManager.QueryPrescription ( drugCode,Neusoft.HISFC.Models.Base.EnumItemType.Drug, Neusoft.HISFC.Models.Preparation.EnumMaterialType.Material );
            if ( al == null )
            {
                MessageBox.Show ( Language.Msg ( "获取当前选择成品的配制处方信息出错\n" + drugCode ) );
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Preparation.PrescriptionBase info in al)
            {
                int i = this.neuSpread1_Sheet1.Rows.Count;

                this.neuSpread1_Sheet1.Rows.Add ( i , 1 );
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColMaterialID ].Text = info.Material.ID;
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColMaterialName ].Text = info.Material.Name;
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColMaterialSpecs ].Text = info.Specs;
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColPrice ].Text = info.Price.ToString ( );
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColQty ].Text = info.NormativeQty.ToString ( );
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColMemo ].Text = info.Memo;
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColUnit ].Text = info.NormativeUnit;
                this.neuSpread1_Sheet1.Cells [ i , ( int ) MaterialColumnSet.ColPackQty ].Text = info.MaterialPackQty.ToString ( );

                this.neuSpread1_Sheet1.Rows [ i ].Tag = info.Material;
                drugCodeDict.Add ( info.Material.ID , info.Material.Name + "(" + info.Specs + ")" );
                drugNameDict.Add ( info.Material.Name + "(" + info.Specs + ")" , info.Material.ID );
            }

            string costPriceFormula = preparationManager.GetCostPriceFormula ( drugCode );

            this.neuTextBox1.Text = this.CodeToName ( costPriceFormula );
            return 1;
        }
        /// <summary>
        /// 名称转化成编码
        /// </summary>
        /// <param name="costPriceFormula"></param>
        /// <returns></returns>
        private string NameToCode ( string costPriceFormula )
        {
            int i , j;

            string oldValue , newValue;


            for ( i = costPriceFormula.Length - 1; i >= 0; i-- )
            {

                if ( costPriceFormula [ i ] == '[' )
                {
                    j = costPriceFormula.IndexOf ( ']' , i );
                    oldValue = costPriceFormula.Substring ( i + 1 , j - i - 1 );
                    try
                    {
                        newValue = drugNameDict [ oldValue ];
                    }
                    catch ( Exception e )
                    {
                        MessageBox.Show ( e.Message );
                        return null;
                    }
                    costPriceFormula = costPriceFormula.Replace ( oldValue , newValue );
                }

            }
            return costPriceFormula;
        }
        /// <summary>
        /// 编码转化成名称
        /// </summary>
        /// <param name="costPriceFormula"></param>
        /// <returns></returns>
        private string CodeToName ( string costPriceFormula )
        {
            int i , j;

            string oldValue , newValue;


            for ( i = costPriceFormula.Length - 1; i >= 0; i-- )
            {


                if ( costPriceFormula [ i ] == '[' )
                {
                    j = costPriceFormula.IndexOf ( ']' , i );
                    oldValue = costPriceFormula.Substring ( i + 1 , j - i - 1 );
                    newValue = drugCodeDict [ oldValue ];

                    costPriceFormula = costPriceFormula.Replace ( oldValue , newValue );
                }

            }
            return costPriceFormula;
        }
        /// <summary>
        /// 检查成本计算公式是否能算出一个值
        /// </summary>
        /// <param name="costPriceFormula"></param>
        /// <returns></returns>
        private string Check ( string costPriceFormula )
        {
            int i , j;

            string oldValue;
            string newValue = "1";
            


            for ( i = costPriceFormula.Length - 1; i >= 0; i-- )
            {


                if ( costPriceFormula [ i ] == '[' )
                {
                    j = costPriceFormula.IndexOf ( ']' , i );
                    oldValue = costPriceFormula.Substring ( i , j - i + 1 );


                    costPriceFormula = costPriceFormula.Replace ( oldValue , newValue );
                }
            }
            return costPriceFormula;
        }
        #endregion

        #region 事件
        /// <summary>
        /// load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnLoad ( EventArgs e )
        {
            this.tvList = this.tv as tvDrugList;
            this.ShowList ( );
            base.OnLoad ( e );
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int  OnSave(object sender, object neuObject)
        {
            Neusoft.FrameWork.Models.NeuObject info = this.tvList.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                Neusoft.HISFC.Models.Preparation.CostPrice costPrice = new Neusoft.HISFC.Models.Preparation.CostPrice ( );
                HISFC.Models.Pharmacy.Item item = itemMr.GetItem ( info.ID );
                //判断item是否为空
                if ( item.ID == null || item == null )
                {
                }
                else
                {
                    costPrice.ID = item.ID;
                    costPrice.Name = item.Name;
                    costPrice.Specs = item.Specs;
                    costPrice.PactUnit = item.PackUnit;
                    costPrice.PactQty = ( int ) item.PackQty;
                    costPrice.MinUnit = item.MinUnit;
                    string costPriceFormula = this.neuTextBox1.Text;
                    costPrice.CostPriceFormula = this.NameToCode ( costPriceFormula );
                    //判断表达式能否算出一个值，如果可以算出值证明合法。
                    object i = Neusoft.FrameWork.Public.String.ExpressionVal ( ( this.Check ( costPriceFormula ) ) );




                    costPrice.SalePriceFormula = "";
                    costPrice.PriceSource = "";
                    costPrice.PriceRate = item.PriceCollection.PriceRate;
                    costPrice.Memo = item.Memo;
                    costPrice.Extend = "";
                    costPrice.Oper.Name = ( ( Neusoft.HISFC.Models.Base.Employee ) Neusoft.FrameWork.Management.Connection.Operator ).ID;
                    costPrice.Oper.OperTime = DateTime.Now;
                
                if ( preparationManager.IsHaveCostPriceFormula ( costPrice.ID ) )
                {
                    if ( i == null )
                    {
                        MessageBox.Show ( "修改失败" );
                    }
                    else
                    {
                        if ( costPrice.CostPriceFormula == null )
                        {
                            MessageBox.Show ( "修改失败" );
                        }
                        else
                        {
                            preparationManager.UpdateCostPrice ( costPrice );
                            MessageBox.Show ( "修改成功" );
                        }
                    }

                }
                else
                {
                    if ( preparationManager.InsertCostPrice ( costPrice ) == 1 )
                    {
                        if ( i == null )
                        {
                            MessageBox.Show ( "保存失败" );
                        }
                        else
                        {
                            if ( costPrice.CostPriceFormula == null )
                            {
                                MessageBox.Show ( "保存失败" );
                            }
                            else
                            {
                                MessageBox.Show ( "保存成功" );
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show ( preparationManager.Err );
                    }

                }
            }
            return base.OnSave ( sender , neuObject );
        }

       

       /// <summary>
       /// 不让鼠标光标停留在中括号里
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void neuTextBox1_MouseUp ( object sender , MouseEventArgs e )
        {
            string costPriceFormula = this.neuTextBox1.Text;

            int start = this.neuTextBox1.SelectionStart;
            int i , j;

            for ( i = costPriceFormula.Length - 1; i >= 0; i-- )
            {


                if ( costPriceFormula [ i ] == '[' )
                {
                    j = costPriceFormula.IndexOf ( ']' , i );
                    if ( start > i && start <= j )
                    {
                        this.neuTextBox1.SelectionStart += ( j - start+1 );
                    }
                }

            }
        }
        /// <summary>
        /// 当光标在中括号里不能输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_KeyPress ( object sender , KeyPressEventArgs e )
        {
            string costPriceFormula = this.neuTextBox1.Text;

            int start = this.neuTextBox1.SelectionStart;
            int i , j;

            for ( i = costPriceFormula.Length - 1; i >= 0; i-- )
            {


                if ( costPriceFormula [ i ] == '[' )
                {
                    j = costPriceFormula.IndexOf ( ']' , i );
                    if ( start > i && start <= j )
                    {
                        e.Handled = true;
                        this.neuTextBox1.SelectionStart += ( j - start + 1 );
                        return;
                    }
                }

            }
        }

        protected override int OnSetValue ( object neuObject , TreeNode e )
        {
            if ( e.Tag != null )
            {
                Neusoft.FrameWork.Models.NeuObject info = e.Tag as Neusoft.FrameWork.Models.NeuObject;
                this.ShowPrescription ( info.ID );
            }
            return base.OnSetValue ( neuObject , e );
        }
      
        #endregion

        protected enum MaterialColumnSet
        {
            /// <summary>
            /// 原料编码
            /// </summary>
            ColMaterialID ,
            /// <summary>
            /// 名称
            /// </summary>
            ColMaterialName ,
            /// <summary>
            /// 规格
            /// </summary>
            ColMaterialSpecs ,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty ,
            /// <summary>
            /// 价格
            /// </summary>
            ColPrice ,
            /// <summary>
            /// 处方量
            /// </summary>
            ColQty ,
            /// <summary>
            /// 单位
            /// </summary>
            ColUnit ,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo
        }

        private void neuSpread1_CellDoubleClick ( object sender , FarPoint.Win.Spread.CellClickEventArgs e )
        {
            int activeRow = this.neuSpread1_Sheet1.ActiveRowIndex;
            string drugInfo="["+this.neuSpread1_Sheet1.Cells[activeRow,(int)MaterialColumnSet.ColMaterialName].Text+"("+this.neuSpread1_Sheet1.Cells[activeRow,(int)MaterialColumnSet.ColMaterialSpecs].Text+")]";
            this.neuTextBox1.Text = this.neuTextBox1.Text.Insert ( this.neuTextBox1.SelectionStart , drugInfo );
        }





    }

    
}
