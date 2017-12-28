using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Models.Fee
{
    /// <summary>
    /// Invoice<br></br>
    /// [功能描述: 发票变更类]<br></br>
    /// [创 建 者: 孙盟]<br></br>
    /// [创建时间: 2007-05-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
     [System.Serializable]
    public class InvoiceChange : NeuObject
    {

        #region 变量

        /// <summary>
        /// 发生序号
        /// </summary>
        private int happenNO;

        /// <summary>
        /// 发票领取人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment getOper = new OperEnvironment();

        /// <summary>
        /// 发票类型
        /// </summary>
        /// 
         
        //private InvoiceTypeEnumService enumInvoiceType = new InvoiceTypeEnumService();
        private NeuObject invoiceType = new NeuObject ();
        
        /// <summary>
        /// 操作员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new OperEnvironment();

        /// <summary>
        /// 发票起始号
        /// </summary>
        private string beginNO;

        /// <summary>
        /// 发票中止号
        /// </summary>
        private string endNO;

        /// <summary>
        /// 当前使用号
        /// </summary>
        private string usedNO;

        /// <summary>
        /// 变更类型
        /// </summary>
        private string shiftType;

        #endregion

        #region 属性

        /// <summary>
        /// 发生序号
        /// </summary>
        public int HappenNO
        {
            get 
            {
                return this.happenNO;
            }
            set 
            {
                this.happenNO = value;
            }
        }


        /// <summary>
        /// 发票领取人
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment GetOper
        {
            get 
            {
                return this.getOper;
            }
            set
            {
                this.getOper = value;
            }
        }

        /// <summary>
        /// 发票类型
        /// </summary>
        /// 
        
        //public InvoiceTypeEnumService InvoiceType
        //{
        //    get
        //    {
        //        return this.enumInvoiceType;
        //    }
        //    set
        //    {
        //        this.enumInvoiceType = value;
        //    }
        //}

        public NeuObject InvoiceType
        {

            get
            {
                return this.invoiceType;
            }
            set
            {
                this.invoiceType = value;
            }
        }
        
        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }

        /// <summary>
        /// 发票起始号
        /// </summary>
        public string BeginNO
        {
            get
            {
                return this.beginNO;
            }
            set
            {
                this.beginNO = value.PadLeft(12, '0');
            }

        }

        /// <summary>
        /// 发票中止号
        /// </summary>
        public string EndNO
        {
            get
            {
                return this.endNO;
            }
            set
            {
                this.endNO = value.PadLeft(12, '0');
            }

        }

        /// <summary>
        /// 当前使用号
        /// </summary>
        public string UsedNO
        {
            get
            {
                return this.usedNO;
            }
            set
            {
                this.usedNO = value.PadLeft(12, '0');
            }
        }

        /// <summary>
        /// 变更类型
        /// </summary>
        public string ShiftType
        {
            get 
            {
                return this.shiftType;
            }
            set 
            {
                this.shiftType = value;
            }
        }

        #endregion
                
        #region 方法

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>当前对象的实例副本</returns>
        public new InvoiceChange Clone()
        {
            InvoiceChange invoiceChange = base.Clone() as InvoiceChange;
            invoiceChange.GetOper = this.GetOper.Clone();
            invoiceChange.Oper = this.Oper.Clone();
            invoiceChange.InvoiceType = this.InvoiceType.Clone();
            return invoiceChange;
        }

        #endregion

        #endregion
    }
}
