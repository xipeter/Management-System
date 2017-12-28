using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病案出库单]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007/09/14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class CaseBill : Neusoft.FrameWork.Models.NeuObject
    {

        #region 变量

        /// <summary>
        /// 流水主键
        /// </summary>
        private string id = string.Empty;

        /// <summary>
        /// 单据号码
        /// </summary>
        private string billCode = string.Empty;

        /// <summary>
        /// 入库申请操作环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment inRequestOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 入库申请病区
        /// </summary>
        private HISFC.Models.Base.Department inRequestNurse = new Neusoft.HISFC.Models.Base.Department();

        /// <summary>
        /// 入库申请物流分区
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject inRequestPartition = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 出库审核操作环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment outAuditingOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 出库审核病区
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject outAuditingNurse = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 入库确认操作环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment inConfirmOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 单据类型
        /// </summary>
        private HISFC.Models.Base.Const billType = new Neusoft.HISFC.Models.Base.Const();

        /// <summary>
        /// 物流发送操作环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment sendOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 物流接收操作环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment receiveOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否已经发送
        /// </summary>
        private bool isSend;

        /// <summary>
        /// 是否已经接收
        /// </summary>
        private bool isReceive;

        /// <summary>
        /// 病历流水主键
        /// </summary>
        private Int64 caseID = 0l;

        /// <summary>
        /// 病历信息
        /// </summary>
        private CaseInfo caseInfo = new CaseInfo();

        /// <summary>
        /// 单据状态
        /// </summary>
        private EnumCaseBillState caseBillState = EnumCaseBillState.InRequest;

        /// <summary>
        /// 申请的目标对象：可以是科室、病区
        /// </summary>
        private HISFC.Models.Base.Department fromDept = new Neusoft.HISFC.Models.Base.Department();

        #endregion

        #region 属性

        /// <summary>
        /// 流水主键
        /// </summary>
        public new string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// 单据号码
        /// </summary>
        public string BillCode
        {
            get
            {
                return this.billCode;
            }
            set
            {
                this.billCode = value;
            }
        }

        /// <summary>
        /// 入库申请操作环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment InRequestOper
        {
            get
            {
                return this.inRequestOper;
            }
            set
            {
                this.inRequestOper = value;
            }
        }

        /// <summary>
        /// 入库申请病区
        /// </summary>
        public HISFC.Models.Base.Department InRequestNurse
        {
            get
            {
                return this.inRequestNurse;
            }
            set
            {
                this.inRequestNurse = value;
            }
        }

        /// <summary>
        /// 入库申请物流分区
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InRequestPartition
        {
            get
            {
                return this.inRequestPartition;
            }
            set
            {
                this.inRequestPartition = value;
            }
        }

        /// <summary>
        /// 出库审核操作环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment OutAuditingOper
        {
            get
            {
                return this.outAuditingOper;
            }
            set
            {
                this.outAuditingOper = value;
            }
        }

        /// <summary>
        /// 出库审核病区
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OutAuditingNurse
        {
            get
            {
                return this.outAuditingNurse;
            }
            set
            {
                this.outAuditingNurse = value;
            }
        }

        /// <summary>
        /// 入库确认操作环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment InConfirmOper
        {
            get
            {
                return this.inConfirmOper;
            }
            set
            {
                this.inConfirmOper = value;
            }
        }

        /// <summary>
        /// 单据类型
        /// </summary>
        public HISFC.Models.Base.Const BillType
        {
            get
            {
                return this.billType;
            }
            set
            {
                this.billType = value;
            }
        }

        /// <summary>
        /// 物流发送操作环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment SendOper
        {
            get
            {
                return this.sendOper;
            }
            set
            {
                this.sendOper = value;
            }
        }

        /// <summary>
        /// 物流接收操作环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment ReceiveOper
        {
            get
            {
                return this.receiveOper;
            }
            set
            {
                this.receiveOper = value;
            }
        }
        
        /// <summary>
        /// 是否已经发送
        /// </summary>
        public bool IsSend
        {
            get
            {
                return this.isSend;
            }
            set
            {
                this.isSend = value;
            }
        }
        
        /// <summary>
        /// 是否已经接收
        /// </summary>
        public bool IsReceive
        {
            get
            {
                return this.isReceive;
            }
            set
            {
                this.isReceive = value;
            }
        }
        
        /// <summary>
        /// 病历流水主键
        /// </summary>
        [Obsolete("废弃，改为聚合CaseInfo", true)]
        public Int64 CaseID
        {
            get
            {
                return this.caseID;
            }
            set
            {
                this.caseID = value;
            }
        }

        /// <summary>
        /// 病历信息
        /// </summary>
        public CaseInfo CaseInfo
        {
            get
            {
                return this.caseInfo;
            }
            set
            {
                this.caseInfo = value;
            }
        }
        
        /// <summary>
        /// 单据状态
        /// </summary>
        public EnumCaseBillState CaseBillState
        {
            get
            {
                return this.caseBillState;
            }
            set
            {
                this.caseBillState = value;
            }
        }

        /// <summary>
        /// 申请的目标科室或病区（病历所在科室或病区）
        /// </summary>
        public HISFC.Models.Base.Department FromDept
        {
            get
            {
                return this.fromDept;
            }
            set
            {
                this.fromDept = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new CaseBill Clone()
        {
            CaseBill caseBill = base.Clone() as CaseBill;

            caseBill.InRequestOper = this.InRequestOper.Clone();
            caseBill.InRequestNurse = this.InRequestNurse.Clone();
            caseBill.InRequestPartition = this.InRequestPartition.Clone();
            caseBill.OutAuditingOper = this.OutAuditingOper.Clone();
            caseBill.OutAuditingNurse = this.OutAuditingNurse.Clone();
            caseBill.InConfirmOper = this.InConfirmOper.Clone();
            caseBill.BillType = this.BillType.Clone();
            caseBill.SendOper = this.SendOper.Clone();
            caseBill.ReceiveOper = this.ReceiveOper.Clone();
            caseBill.CaseInfo = this.CaseInfo.Clone();
            caseBill.FromDept = this.FromDept.Clone();

            return caseBill;
        }

        #endregion
    }

    /// <summary>
    /// 病历出库单状态
    /// </summary>
    public enum EnumCaseBillState
    {
        /// <summary>
        /// 入库申请
        /// </summary>
        InRequest = 0,
        /// <summary>
        /// 出库审核
        /// </summary>
        OutAuditing = 1,
        /// <summary>
        /// 入库确认
        /// </summary>
        InConfirm = 2
    }
}
