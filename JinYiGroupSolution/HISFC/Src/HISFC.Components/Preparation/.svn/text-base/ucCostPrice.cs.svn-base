using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PManager = Neusoft.HISFC.BizLogic.Pharmacy.Preparation;
using PObject = Neusoft.HISFC.Models.Preparation;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 成本价计算]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// <说明>
    ///  1 公式初步存储原料编码 
    ///  2 公式计算方式的具体细节实行
    ///        计算方式包括手工输入调整、公式计算
    /// </说明>
    /// </summary>
    public partial class ucCostPrice : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCostPrice ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// 药品编码为key，价格为value
        /// </summary>
        private Dictionary<string , string> drugNameDict = new Dictionary<string , string> ( );
        /// <summary>
        /// 药品编码为key，名称为value
        /// </summary>
        private Dictionary<string , string> drugCodeDict = new Dictionary<string , string> ( );
        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation ( );
        /// <summary>
        /// 成本价修改完成
        /// </summary>
        public event System.EventHandler CostPriceChanged;

        #region 静态公开函数

        /// <summary>
        /// 成本价计算
        /// </summary>
        /// <param name="preparation">制剂成品信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        internal static int ComputeCostPrice ( PManager pManager , ref PObject.Preparation preparation , ComputeCostPriceType computeType )
        {

            if ( computeType == ComputeCostPriceType.Manual )
            {
                using ( ucCostPrice uc = new ucCostPrice ( ) )
                {
                    uc.SetPreparation ( preparation,pManager,ref preparation );
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "成本价设置";
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl ( uc );
                    if ( uc.Result == DialogResult.Cancel )
                    {
                        return 1;
                    }
                    else
                    {
                        preparation.CostPrice = uc.CostPrice;
                        return 1;
                    }


                }
            }
            else
            {

                List<Neusoft.HISFC.Models.Preparation.Expand> expandList = ucExpand.QueryExpandList ( pManager , preparation );
                if ( expandList == null )
                {
                    return -1;
                }

                decimal costPrice = 0;
                
                foreach ( Neusoft.HISFC.Models.Preparation.Expand info in expandList )
                {
                    costPrice = info.FacutalExpand / info.Prescription.MaterialPackQty * info.Prescription.Price;
                    
                }
                if ( costPrice == 0 )
                {
                    preparation.CostPrice = preparation.Drug.PriceCollection.PurchasePrice;
                }
                else
                {
                    preparation.CostPrice = costPrice;
                }
            }

            return 1;
        }

        #endregion

        /// <summary>
        /// 操作结果
        /// </summary>
        private DialogResult result = DialogResult.Cancel;

        protected string strPreparation = "制剂成品：{0}  规格：{1}  批号：{2}  计划量：{3}  单位：{4}";

        #region 属性

        /// <summary>
        /// 操作结果
        /// </summary>
        internal DialogResult Result
        {
            get
            {
                return result;
            }
        }

        /// <summary>
        /// 本次计算成本值
        /// </summary>
        internal decimal CostPrice
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.ntxtCostPrice.Text );
            }
        }

        #endregion
        private Dictionary<string , string> ComputeCostPrice ( PManager pManager , ref PObject.Preparation preparation )
        {
            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = ucExpand.QueryExpandList ( pManager , preparation );
            if ( expandList == null )
            {
                return null;
            }

            decimal costPrice = 0;

            foreach ( Neusoft.HISFC.Models.Preparation.Expand info in expandList )
            {
                costPrice = info.FacutalExpand / info.Prescription.MaterialPackQty * info.Prescription.Price;
                this.drugNameDict.Add ( "[" + info.Prescription.Material.ID + "]" , costPrice.ToString() );

            }
            if ( costPrice == 0 )
            {
                preparation.CostPrice = preparation.Drug.PriceCollection.PurchasePrice;
            }
            else
            {
                preparation.CostPrice = costPrice;
            }
            return drugNameDict;
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
        /// 编码转化成价格
        /// </summary>
        /// <param name="costPriceFormula"></param>
        /// <returns></returns>
        private string CodeToPrice ( string costPriceFormula,Dictionary<string,string> drugNameDict )
        {
            int i , j;

            string oldValue , newValue;
            
         
            for ( i = costPriceFormula.Length - 1; i >= 0; i-- )
            {


                if ( costPriceFormula [ i ] == '[' )
                {
                    j = costPriceFormula.IndexOf ( ']' , i );
                    oldValue = costPriceFormula.Substring ( i  , j - i + 1 );
                    newValue = drugNameDict[ oldValue ];

                    costPriceFormula = costPriceFormula.Replace ( oldValue , newValue );
                }

            }
            return costPriceFormula;
        }
        /// <summary>
        /// 设置制剂成品信息 并 显示成本计算公式、当前成本价
        /// </summary>
        /// <param name="preparation">制剂成品信息</param>
        protected int SetPreparation ( Neusoft.HISFC.Models.Preparation.Preparation preparation , PManager pManager , ref PObject.Preparation preparation1 )
        {
            
            string drugCode = preparation.Drug.ID;
            List<Neusoft.HISFC.Models.Preparation.Prescription> al = this.preparationManager.QueryDrugPrescription( drugCode);
            if ( al == null )
            {

                return -1;
            }
            foreach ( Neusoft.HISFC.Models.Preparation.Prescription info in al )
            {

                drugCodeDict.Add ( info.Material.ID , info.Material.Name );
                //drugNameDict.Add ( info.Material.Name, info.Material.ID );
            }

            string costPriceFormula = this.preparationManager.GetCostPriceFormula ( drugCode );
            this.ntxtCostPrice.Text = Neusoft.FrameWork.Public.String.ExpressionVal ( this.CodeToPrice ( costPriceFormula,this.ComputeCostPrice(pManager, ref preparation1 ) )).ToString();
            costPriceFormula = this.CodeToName ( costPriceFormula );
            this.costPriceTxt.Text = costPriceFormula;
            this.lbPreparation.Text = string.Format ( this.strPreparation , preparation.Drug.Name , preparation.Drug.Specs , preparation.BatchNO , preparation.PlanQty , preparation.Unit );

            return this.ucExpand1.ShowExpand ( preparation );

        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected void Close ( )
        {
            if ( this.ParentForm != null )
            {
                this.ParentForm.Close ( );
            }
        }

        private void btnOK_Click ( object sender , System.EventArgs e )
        {
            this.result = DialogResult.OK;

            if ( this.CostPriceChanged != null )
            {
                this.CostPriceChanged ( null , System.EventArgs.Empty );
            }

            this.Close ( );
        }

        private void btnCancel_Click ( object sender , System.EventArgs e )
        {
            this.result = DialogResult.Cancel;

            this.Close ( );
        }

    }

    internal enum ComputeCostPriceType
    {
        /// <summary>
        /// 自动计算 无弹出界面信息 根据公式计算价格
        /// </summary>
        Auto ,
        /// <summary>
        /// 手动计算 弹出界面信息 可手工调整
        /// </summary>
        Manual
    }
}
