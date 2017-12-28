using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.PhysicalExamination
{
    /// <summary>
    /// ItemList<br></br>
    /// [功能描述: 体检收费项目类]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class ItemList : Neusoft.FrameWork.Models.NeuObject
    {
        #region 私有变量 
        /// <summary>
        /// 单位标识 1 药品 2 非药品 3明细 4组套
        /// </summary>
        private string unitFlag = string.Empty;

        /// <summary>
        /// 体检类型 1  个人体检 2 集体体检 
        /// </summary>
        private string chkFlag = string.Empty; 

        /// <summary>
        /// 体检序号
        /// </summary>
        private string clinicNO = string.Empty; 

        /// <summary>
        /// 就诊卡号
        /// </summary>
        private string cardNO = string.Empty; 

        /// <summary>
        /// 优惠比率
        /// </summary>
        private decimal ecoRate ;

        /// <summary>
        /// 优惠金额
        /// </summary>
        private decimal realCost;

        /// <summary>
        /// 组合号
        /// </summary>
        private string comNO = string.Empty; 
 
        /// <summary>
        /// 序列号
        /// </summary>
        private string sequenceNO = string.Empty;  

        /// <summary>
        /// 确认人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment conformOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        /// <summary>
        /// 收费员员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment feeOperInfo = new Neusoft.HISFC.Models.Base.OperEnvironment(); 

        /// <summary>
        /// 执行科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject execDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 项目
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

        /// <summary>
        /// 是否已经终端确认
        /// </summary>
        private string isConfirm = string.Empty;
       
        /// <summary>
        /// 可退数量
        /// </summary>
        private decimal noBackQty;

        /// <summary>
        /// 开单医生
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject recipeDoc = new Neusoft.FrameWork.Models.NeuObject(); 
 
        /// <summary>
        /// 开单科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject recipeDept = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 组合号
        /// </summary>
        private string combo = string.Empty;
        /// <summary>
        /// 收费标志
        /// </summary>
        private string feeFlag = string.Empty;
        private string recipeSequence = string.Empty; //最近一次发票组合号
        private string accountFlag = string.Empty;
        #endregion

        #region 属性
        /// <summary>
        /// 扣账户标志 0 没有扣账户 1 已经扣账户
        /// </summary>
        public string AccountFlag
        {
            get
            {
                return accountFlag;
            }
            set
            {
                accountFlag = value;
            }
        }
        /// <summary>
        /// 最近一次发票组合号
        /// </summary>
        public string RecipeSequence
        {
            get
            {
                return recipeSequence;
            }
            set
            {
                recipeSequence = value;
            }
        }
        /// <summary>
        /// 收费操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment FeeOperInfo
        {
            get
            {
                return feeOperInfo;
            }
            set
            {
                feeOperInfo = value;
            }
        }
        /// <summary>
        /// 收费标志  0 未收费，1，已收费，2作废
        /// </summary>
        public string FeeFlag
        {
            get
            {
                return feeFlag;
            }
            set
            {
                feeFlag = value;
            }
        }
        /// <summary>
        /// 组合号
        /// </summary>
        public string Combo
        {
            get
            {
                return combo;
            }
            set
            {
                combo = value;
            }
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal RealCost
        {
            get
            {
                return realCost;
            }
            set
            {
                realCost = value;
            }
        }

        /// <summary>
        /// 开单科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject RecipeDept
        {
            get
            { 
                return recipeDept;
            }
            set
            {
                recipeDept = value;
            }
        }

        /// <summary>
        /// 开单医生
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject RecipeDoc  
        {
            get
            { 
                return recipeDoc;
            }
            set
            {
                recipeDoc = value;
            }
        }

        /// <summary>
        /// 体检类型 1个人体检 2 集体体检
        /// </summary>
        public string ChkFlag
        {
            get
            {
                return chkFlag;
            }
            set
            {
                chkFlag = value;
            }
        }

        /// <summary>
        /// 可退数量
        /// </summary>
        public decimal NoBackQty
        {
            get
            {
                return noBackQty;
            }
            set
            {
                noBackQty = value;
            }
        }

        /// <summary>
        /// 确认标志
        /// </summary>
        public string IsConfirm
        {
            get
            {
                return isConfirm;
            }
            set
            {
                isConfirm = value;
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SequenceNO
        {
            get
            {
                return sequenceNO;
            }
            set
            {
                sequenceNO = value;
            }
        }

        /// <summary>
        /// 组合号
        /// </summary>
        public string ComNO
        {
            get
            {
                return comNO;
            }
            set
            {
                comNO = value;
            }
        }

        /// <summary>
        /// 项目
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Item.Undrug Item
        {
            get
            { 
                return item;
            }
            set
            {
                item = value;
            }
        }

        /// <summary>
        /// 执行科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ExecDept
        {
            get
            { 
                return execDept;
            }
            set
            {
                execDept = value;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        }

        /// <summary>
        /// 优惠比率
        /// </summary>
        public decimal EcoRate
        {
            get
            {
                return ecoRate;
            }
            set
            {
                ecoRate = value;
            }
        }

        /// <summary>
        /// 确认人
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ConformOper
        {
            get
            { 
                return conformOper;
            }
            set
            {
                conformOper = value;
            }
        }

        /// <summary>
        /// 就诊卡号
        /// </summary>
        public string CardNO
        {
            get
            {
                return cardNO;
            }
            set
            {
                cardNO = value;
            }
        }

        /// <summary>
        /// 体检序号
        /// </summary>
        public string ClinicNO
        {
            get
            {
                return clinicNO;
            }
            set
            {
                clinicNO = value;
            }
        }

        /// <summary>
        /// 单位标识 0药品/1 非药品/2组套/3复合项目
        /// </summary>
        public string UnitFlag
        {
            get
            {
                return unitFlag;
            }
            set
            {
                unitFlag = value;
            }
        }
        #endregion 

        #region 废弃属性
        /// <summary>
        /// 体检序号
        /// </summary>
        [Obsolete("作废 用 ClinicNO 代替", true)]
        public string ClinicNo
        {
            get
            {
                return clinicNO;
            }
            set
            {
                clinicNO = value;
            }
        }

        /// <summary>
        /// 就诊卡号
        /// </summary>
        [Obsolete("作废 用 CardNO 代替", true)]
        public string CardNo
        {
            get
            {
                return cardNO;
            }
            set
            {
                cardNO = value;
            }
        }

        /// <summary>
        /// 组合号
        /// </summary>
        [Obsolete("作废 用 ComNO 代替", true)]
        public string ComNo
        {
            get
            {
                return comNO;
            }
            set
            {
                comNO = value;
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        [Obsolete("作废 用 SequenceNO 代替", true)]
        public string SequenceNo
        {
            get
            {
                return sequenceNO;
            }
            set
            {
                sequenceNO = value;
            }
        }

        /// <summary>
        /// 确认日期
        /// </summary>
        [Obsolete("作废 用 ConformOper.OperTime 代替", true)]
        public System.DateTime ConformDate
        {
            //get
            //{
            //    //return conformTime;
            //}
            set
            {
                //conformTime = value;
            }
        }

        /// <summary>
        /// 确认标志
        /// </summary>
        [Obsolete("作废 用 ISConfirm 代替", true)]
        public string ConfirmFlag 
        {
            get
            {
                return isConfirm;
            }
            set
            {
                isConfirm = value;
            }
        }

        /// <summary>
        /// 可退数量
        /// </summary>
        [Obsolete("作废 用 NoBackQty 代替", true)]
        public decimal NoBackNum
        {
            get
            {
                return noBackQty;
            }
            set
            {
                noBackQty = value;
            }
        }

        /// <summary>
        /// 操作日期
        /// </summary>
        [Obsolete("作废 用 OperInfo 里的操作时间代替 代替", true)]
        public System.DateTime OperDate
        {
            get
            {
                return operDate;
            }
            set
            {
                operDate = value;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        [Obsolete("作废 用 OperInfo 代替", true)]
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            { 
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        }

        /// <summary>
        /// 扩展标志
        /// </summary>
        //[Obsolete("作废", true)]
        public string ExtChar1
        {
            get
            {
                return extChar1;
            }
            set
            {
                extChar1 = value;
            }
        }

        /// <summary>
        /// 计价单位
        /// </summary>
        [Obsolete("作废 ,用item.PriceUnit", true)]
        public string ExtChar
        {
            get
            {
                return extChar;
            }
            set
            {
                extChar = value;
            }
        }

        /// <summary>
        /// 优惠前价格
        /// </summary>
        [Obsolete("作废 用Item 中的 Price 代替", true)]
        public decimal ExtNumber1
        {
            get
            {
                return extNumber1;
            }
            set
            {
                extNumber1 = value;
            }
        }

        /// <summary>
        /// 优惠后价格
        /// </summary>
        [Obsolete("作废 用RealCost代替  ", true)]
        public decimal ExtNumber
        {
            get
            {
                return extNumber;
            }
            set
            {
                extNumber = value;
            }
        }

        /// <summary>
        /// 扩展标志
        /// </summary>
        [Obsolete("作废 用 Combo代替", true)]
        public string ExtFlag1
        {
            get
            {
                return extFlag1;
            }
            set
            {
                extFlag1 = value;
            }
        }

        /// <summary>
        /// 扩展标志
        /// </summary>
        //[Obsolete("作废", true)]
        public string ExtFlag
        {
            get
            {
                return extFlag;
            }
            set
            {
                extFlag = value;
            }
        }
        #endregion 

        #region 废弃变量

        [Obsolete("作废 用OperInfo 内的操作时间代替", true)]
        private System.DateTime operDate;

        //[Obsolete("作废", true)]
        private string extFlag; 
   
        [Obsolete("作废", true)]                    
        private decimal extNumber;

        [Obsolete("作废", true)]                      
        private string extChar; 

        //[Obsolete("作废", true)]                  
        private string extFlag1;

        [Obsolete("作废", true)]                        
        private decimal extNumber1;

        //[Obsolete("作废", true)]                        
        private string extChar1;

        #endregion 

        #region 克隆函数
        public new ItemList Clone()
        {
            ItemList obj = base.Clone() as ItemList;
            obj.item = this.item.Clone();
            obj.execDept = this.ExecDept.Clone();//(Neusoft.HISFC.Models.Fee.Invoice)Invoice.Clone();
            obj.operInfo = this.OperInfo.Clone();
            obj.conformOper = this.ConformOper.Clone();
            return obj;
        }
        #endregion 
    }

}
