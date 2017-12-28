using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Supply
{
    /// <summary>    
    /// [功能描述: 供应室生产管理类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-05-26]<br></br>
    /// <说明
    ///		
    ///  />
    /// </summary>   
    [Serializable]
    public class Product : Neusoft.FrameWork.Models.NeuObject
    {
        public Product()
        {
            
        }

        #region 变量

        /// <summary>
        /// 成品
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();

        /// <summary>
        /// 生产编号 
        /// </summary>
        private string productiveListNO = "";

        /// <summary>
        /// 计划生产量
        /// </summary>
        private decimal planQty;

        /// <summary>
        /// 入库成品量
        /// </summary>
        private decimal inputQty;

        /// <summary>
        /// 制剂 单位
        /// </summary>
        private string unit;

        /// <summary>
        /// 操作信息--人员、日期
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 扩展标记
        /// </summary>
        private string extend1;

        /// <summary>
        /// 扩展标记1
        /// </summary>
        private string extend2;

        #endregion

        #region 属性

        /// <summary>
        /// 制剂成品
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Item.Undrug UnDrug
        {
            get
            {
                return this.undrug;
            }
            set
            {
                this.undrug = value;
            }
        }

        /// <summary>
        /// 生产计划编号
        /// </summary>
        public string ProductiveListNO
        {
            get
            {
                return this.productiveListNO;
            }
            set
            {
                this.ID = value;
                this.productiveListNO = value;
            }
        }

        /// <summary>
        /// 计划生产量
        /// </summary>
        public decimal PlanQty
        {
            get
            {
                return this.planQty;
            }
            set
            {
                this.planQty = value;
            }
        }

        /// <summary>
        /// 成品入库量
        /// </summary>
        public decimal InputQty
        {
            get
            {
                return this.inputQty;
            }
            set
            {
                this.inputQty = value;
            }
        }

        /// <summary>
        /// 制剂 单位
        /// </summary>
        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        /// <summary>
        /// 操作信息--人员、日期
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperEnv
        {
            get
            {
                return this.operEnv;
            }
            set
            {
                this.operEnv = value;
            }
        }

        /// <summary>
        /// 扩展标记1
        /// </summary>
        public string Extend1
        {
            get
            {
                return this.extend1;
            }
            set
            {
                this.extend1 = value;
            }
        }

        /// <summary>
        /// 扩展标记2
        /// </summary>
        public string Extend2
        {
            get
            {
                return this.extend2;
            }
            set
            {
                this.extend2 = value;
            }
        }

        #endregion        

        #region 方法

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>PPRBase</returns>
        public new Product Clone()
        {
            Product product = base.Clone() as Product;
            product.undrug = this.undrug.Clone();
            product.operEnv = this.operEnv.Clone();

            return product;
        }

        #endregion
    }
}
