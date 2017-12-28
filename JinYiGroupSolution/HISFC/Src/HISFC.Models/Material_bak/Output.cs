using System;

namespace Neusoft.HISFC.Object.Material
{
    /// <summary>
    /// [功能描述: 物资出库信息]
    /// [创 建 者: 梁俊泽]
    /// [创建时间: 2007-03]
    /// 
    /// ID 出库单流水号
    /// </summary>
    public class Output : Neusoft.NFC.Object.NeuObject
    {
        public Output()
        {
            this.storeBase.Class2Type = "0520";
        }


        #region 变量

        /// <summary>
        /// 自定义单据号 默认年月日+流水号
        /// </summary>
        private string outListNO;

        /// <summary>
        /// 出库金额
        /// </summary>
        private decimal outCost;

        /// <summary>
        /// 附加费
        /// </summary>
        private decimal otherFee;

        /// <summary>
        /// 是否个人领用
        /// </summary>
        private bool isPrivate;

        /// <summary>
        /// 领取人  只记录领取的人员
        /// </summary>
        private Neusoft.NFC.Object.NeuObject drawOper = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 物资消耗人(住院流水号或门诊流水号)
        /// </summary>
        private Neusoft.NFC.Object.NeuObject getPerson = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 出库日期
        /// </summary>
        private DateTime outTime;

        /// <summary>
        /// 单据(发票)状态  0  有发票     1  无发票    2  发票补录
        /// </summary>
        private string billState = "1";

        /// <summary>
        /// 借方科目
        /// </summary>
        private string debit = "";

        /// <summary>
        /// 入库流水号
        /// </summary>
        private string inNO = "";

        /// <summary>
        /// 生产日期
        /// </summary>
        private DateTime produceTime;

        /// <summary>
        /// 用途
        /// </summary>
        private string use = "";

        /// <summary>
        /// 库存基本信息
        /// </summary>
        private Neusoft.HISFC.Object.Material.StoreBase storeBase = new StoreBase();

        /// <summary>
        /// 生产材料流水号
        /// </summary>
        private string outSequence = "";

        /// <summary>
        /// 申请单号(liuxq add)
        /// </summary>
        private string applylistcode = "";

        /// <summary>
        /// 申请单内序号(liuxq add)
        /// </summary>
        private int applyserialno;

        private string recipeNO;

        private int sequenceNO;

        /// <summary>
        /// 申请退库数量
        /// </summary>
        private decimal returnApplyNum;

        #endregion

        #region 属性

        /// <summary>
        /// 自定义单据号 默认年月日+流水号
        /// </summary>
        public string OutListNO
        {
            get
            {
                return this.outListNO;
            }
            set
            {
                this.outListNO = value;
            }
        }

        /// <summary>
        /// 出库金额
        /// </summary>
        public decimal OutCost
        {
            get
            {
                return this.outCost;
            }
            set
            {
                this.outCost = value;
            }
        }

        /// <summary>
        /// 附加费
        /// </summary>
        public decimal OtherFee
        {
            get
            {
                return this.otherFee;
            }
            set
            {
                this.otherFee = value;
            }
        }

        /// <summary>
        /// 是否个人领用
        /// </summary>
        public bool IsPrivate
        {
            get
            {
                return this.isPrivate;
            }
            set
            {
                this.isPrivate = value;
            }
        }

        /// <summary>
        /// 领取人  只记录领取的人员
        /// </summary>
        public Neusoft.NFC.Object.NeuObject DrawOper
        {
            get
            {
                return this.drawOper;
            }
            set
            {
                this.drawOper = value;
            }
        }

        /// <summary>
        /// 物资消耗人(住院流水号或门诊流水号)
        /// </summary>
        public Neusoft.NFC.Object.NeuObject GetPerson
        {
            get
            {
                return this.getPerson;
            }
            set
            {
                this.getPerson = value;
            }
        }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime OutTime
        {
            get
            {
                return this.outTime;
            }
            set
            {
                this.outTime = value;
            }
        }

        /// <summary>
        /// 单据(发票)状态  0  有发票     1  无发票    2  发票补录
        /// </summary>
        public string BillState
        {
            get
            {
                return this.billState;
            }
            set
            {
                this.billState = value;
            }
        }

        /// <summary>
        /// 借方科目
        /// </summary>
        public string Debit
        {
            get
            {
                return this.debit;
            }
            set
            {
                this.debit = value;
            }
        }

        /// <summary>
        /// 入库单流水号
        /// </summary>
        public string InNO
        {
            get
            {
                return this.inNO;
            }
            set
            {
                this.inNO = value;
            }
        }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ProduceTime
        {
            get
            {
                return this.produceTime;
            }
            set
            {
                this.produceTime = value;
            }
        }

        /// <summary>
        /// 用途
        /// </summary>
        public string Use
        {
            get
            {
                return this.use;
            }
            set
            {
                this.use = value;
            }
        }

        /// <summary>
        /// 库存基本信息
        /// </summary>
        public Neusoft.HISFC.Object.Material.StoreBase StoreBase
        {
            get
            {
                return this.storeBase;
            }
            set
            {
                this.storeBase = value;
            }
        }

        /// <summary>
        /// 生产材料流水号
        /// </summary>
        public string OutSequence
        {
            get
            {
                return this.outSequence;
            }
            set
            {
                this.outSequence = value;
            }
        }

        /// <summary>
        /// 申请单号(liuxq)
        /// </summary>
        public string ApplyListCode
        {
            get
            {
                return this.applylistcode;
            }
            set
            {
                this.applylistcode = value;
            }
        }

        /// <summary>
        /// 申请单内序号(liuxq)
        /// </summary>
        public int ApplySerialNO
        {
            get
            {
                return this.applyserialno;
            }
            set
            {
                this.applyserialno = value;
            }
        }

        /// <summary>
        /// 处方号
        /// </summary>
        public string RecipeNO
        {
            get
            {
                return this.recipeNO;
            }
            set
            {
                this.recipeNO = value;
            }
        }

        /// <summary>
        /// 处方内项目序号
        /// </summary>
        public int SequenceNO
        {
            get
            {
                return this.sequenceNO;
            }
            set
            {
                this.sequenceNO = value;
            }
        }

        /// <summary>
        /// 申请退库数量
        /// </summary>
        public decimal ReturnApplyNum
        {
            get
            {
                return returnApplyNum;
            }
            set
            {
                returnApplyNum = value;
            }
        }

        #endregion

        #region 方法

        public new Output Clone()
        {
            Output output = base.Clone() as Output;

            output.drawOper = this.drawOper.Clone();

            output.getPerson = this.getPerson.Clone();

            output.storeBase = this.storeBase.Clone();

            return output;
        }


        #endregion
    }
}
