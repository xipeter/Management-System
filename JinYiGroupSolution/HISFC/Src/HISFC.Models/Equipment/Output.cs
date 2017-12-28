using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// [功能描述: 出库实体]
    /// [创 建 者: Sunm]
    /// [创建时间: 2007-12-04]
    /// </summary>
    /// 
    [System.Serializable]
    public class Output : Neusoft.FrameWork.Models.NeuObject
    {
        public Output()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量
        // 出库单流水号
        private string outBillNo;
        //出库单序号
        private int outSerialNo;
        //出库单据号
        private string outListNo;
        //卡片流水号
        private string cardSequence;
        //卡片编号
        private string cardNo;
        //出库类型
        private string outType;
        //出库分类
        private string outClass;
        //出库状态
        private string outState;
        //出库科室
        private Neusoft.FrameWork.Models.NeuObject outDept = new Neusoft.FrameWork.Models.NeuObject();
        //设备字典信息
        private EquipBase equBase = new EquipBase();
        //设备型号
        private string model;
        //出库数量
        private int outNum;
        //出库价格
        private decimal outPrice;
        //出库金额
        private decimal outCost;
        //领用人
        private Neusoft.FrameWork.Models.NeuObject getPerson = new Neusoft.FrameWork.Models.NeuObject();
        //领用科室
        private Neusoft.FrameWork.Models.NeuObject getDept = new Neusoft.FrameWork.Models.NeuObject();
        //设备用途
        private string equUse;
        //申请单流水号
        private string applyBillNo;
        //申请单序号
        private int applySerialNo;
        //设备条码
        private string barCode;
        //操作员
        private Neusoft.FrameWork.Models.NeuObject oper = new Neusoft.FrameWork.Models.NeuObject();
        //出库日期
        private DateTime outDate;
        //接收单位（调出用）
        private string inceptUnit;
        //卡片启用日期
        private DateTime cardStartDate;
        //批次号
        private string groupNo;

        #endregion

        #region 属性
        /// <summary>
        /// 出库单流水号
        /// </summary>
        public string OutBillNo
        {
            get
            {
                return this.outBillNo;
            }
            set
            {
                this.outBillNo = value;
            }
        }
        /// <summary>
        /// 出库单序号
        /// </summary>
        public int OutSerialNo
        {
            get
            {
                return this.outSerialNo;
            }
            set
            {
                this.outSerialNo = value;
            }
        }
        /// <summary>
        /// 出库单据号
        /// </summary>
        public string OutListNo
        {
            get
            {
                return this.outListNo;
            }
            set
            {
                this.outListNo = value;
            }
        }
        /// <summary>
        /// 卡片流水号
        /// </summary>
        public string CardSequence
        {
            get
            {
                return this.cardSequence;
            }
            set
            {
                this.cardSequence = value;
            }
        }
        /// <summary>
        /// 卡片编号
        /// </summary>
        public string CardNo
        {
            get
            {
                return this.cardNo;
            }
            set
            {
                this.cardNo = value;
            }
        }
        /// <summary>
        /// 出库类型
        /// </summary>
        public string OutType
        {
            get
            {
                return this.outType;
            }
            set
            {
                this.outType = value;
            }
        }
        /// <summary>
        /// 出库分类（Class3MeaningCode）
        /// </summary>
        public string OutClass
        {
            get
            {
                return this.outClass;
            }
            set
            {
                this.outClass = value;
            }
        }
        /// <summary>
        /// 出库状态（0申请1审批2核准）
        /// </summary>
        public string OutState
        {
            get
            {
                return this.outState;
            }
            set
            {
                this.outState = value;
            }
        }
        /// <summary>
        /// 出库科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OutDept
        {
            get
            {
                return this.outDept;
            }
            set
            {
                this.outDept = value;
            }
        }
        /// <summary>
        /// 设备字典信息
        /// </summary>
        public EquipBase EquBaseInfo
        {
            get
            {
                return this.equBase;
            }
            set
            {
                this.equBase = value;
            }
        }
        /// <summary>
        /// 设备型号
        /// </summary>
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        /// <summary>
        /// 出库数量
        /// </summary>
        public int OutNum
        {
            get
            {
                return this.outNum;
            }
            set
            {
                this.outNum = value;
            }
        }
        /// <summary>
        /// 出库价格
        /// </summary>
        public decimal OutPrice
        {
            get
            {
                return this.outPrice;
            }
            set
            {
                this.outPrice = value;
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
        /// 领用人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject GetPerson
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
        /// 领用科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject GetDept
        {
            get
            {
                return this.getDept;
            }
            set
            {
                this.getDept = value;
            }
        }
        /// <summary>
        /// 设备用途
        /// </summary>
        public string EquUse
        {
            get
            {
                return this.equUse;
            }
            set
            {
                this.equUse = value;
            }
        }
        /// <summary>
        /// 申请单流水号
        /// </summary>
        public string ApplyBillNo
        {
            get
            {
                return this.applyBillNo;
            }
            set
            {
                this.applyBillNo = value;
            }
        }
        /// <summary>
        /// 申请单序号
        /// </summary>
        public int ApplySerialNo
        {
            get
            {
                return this.applySerialNo;
            }
            set
            {
                this.applySerialNo = value;
            }
        }
        /// <summary>
        /// 设备条码
        /// </summary>
        public string BarCode
        {
            get
            {
                return this.barCode;
            }
            set
            {
                this.barCode = value;
            }
        }
        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Oper
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
        /// 出库日期
        /// </summary>
        public DateTime OutDate
        {
            get
            {
                return this.outDate;
            }
            set
            {
                this.outDate = value;
            }
        }

        /// <summary>
        /// 接收单位（调出用）
        /// </summary>
        public string InceptUnit
        {
            get
            {
                return inceptUnit;
            }
            set
            {
                inceptUnit = value;
            }
        }

        /// <summary>
        /// 卡片启用日期
        /// </summary>
        public DateTime CardStartDate
        {
            get
            {
                return cardStartDate;
            }
            set
            {
                cardStartDate = value;
            }
        }

        /// <summary>
        /// 批次号
        /// </summary>
        public string GroupNo
        {
            get
            {
                return groupNo;
            }
            set
            {
                groupNo = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Output Clone()
        {
            Output outPut = base.Clone() as Output;

            outPut.outDept = this.outDept.Clone();
            outPut.equBase = this.equBase.Clone();
            outPut.getPerson = this.getPerson.Clone();
            outPut.getDept = this.getDept.Clone();
            outPut.oper = this.oper.Clone();

            return outPut;
        }

        #endregion

    }
}
