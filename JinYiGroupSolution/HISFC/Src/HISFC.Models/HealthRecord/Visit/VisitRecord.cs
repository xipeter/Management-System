using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Visit
{
    /// <summary>
    /// VisitRecord <br></br>
    /// [功能描述: 随访明细记录]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-08-16]<br></br>
    /// <修改记录
    ///		修改人='金鹤'
    ///		修改时间='2009-09-17'
    ///		修改目的='新增属性 随访结果'
    ///		修改描述='{E9F858A6-BDBC-4052-BA57-68755055FB80}'
    ///  />
    /// </summary>
    [Serializable]
    public class VisitRecord : Case.CaseInfo
    {
        #region 变量

        /// <summary>
        /// 一般情况

        /// </summary>
        private HISFC.Models.Base.Const circs = new Neusoft.HISFC.Models.Base.Const();

        /// <summary>
        /// 症状表现
        /// </summary>
        private HISFC.Models.Base.Const symptom = new Neusoft.HISFC.Models.Base.Const();

        /// <summary>
        /// 是否复发
        /// </summary>
        private bool isRecrudesce;

        /// <summary>
        /// 复发时间
        /// </summary>
        private DateTime recrudesceTime = DateTime.MinValue;

        /// <summary>
        /// 是否转移
        /// </summary>
        private bool isTransfer;

        /// <summary>
        /// 转移部位
        /// </summary>
        private HISFC.Models.Base.Const transferPosition = new Neusoft.HISFC.Models.Base.Const();

        /// <summary>
        /// 是否有后遗症
        /// </summary>
        private bool isSequela;

        /// <summary>
        /// 后遗症

        /// </summary>
        private HISFC.Models.Base.Const sequela = new Neusoft.HISFC.Models.Base.Const();

        /// <summary>
        /// 是否死亡
        /// </summary>
        private bool isDead;

        /// <summary>
        /// 死亡时间
        /// </summary>
        private DateTime deadTime = DateTime.MinValue;
        
        /// <summary>
        /// 死因编码
        /// </summary>
        private HISFC.Models.Base.Const deadReason = new Neusoft.HISFC.Models.Base.Const();
        
        /// <summary>
        /// 回信人

        /// </summary>
        private string writeBackPerson;
        
        /// <summary>
        /// 随访方式
        /// </summary>
        private HISFC.Models.Base.Const visitType = new Neusoft.HISFC.Models.Base.Const();

       /// <summary>
        /// 随访操作环境
       /// </summary>
        private HISFC.Models.Base.OperEnvironment visitOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
        /// <summary>
        /// 随访结果录入操作环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment resultOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
        /// <summary>
        /// 随访结果是否成功
        /// </summary>
        private bool isSuccess;
        
        /// <summary>
        /// 是否被动随访
        /// </summary>
        private bool isPassive;

        /// <summary>
        /// 是否形成随访结果
        /// </summary>
        private bool isResult;

        /// <summary>
        /// 是否统计工作量

        /// </summary>
        private bool isWorkLoad;

        /// <summary>
        /// 随访采用的联系方式

        /// </summary>
        private LinkWay linkWay = new LinkWay();

        #region {E9F858A6-BDBC-4052-BA57-68755055FB80}
        
        
        /// <summary>
        /// 随访结果
        /// </summary>
        private HISFC.Models.Base.Const visitResult = new Neusoft.HISFC.Models.Base.Const();

        #endregion


        #endregion

        #region 属性


        /// <summary>
        /// 一般情况

        /// </summary>
        public HISFC.Models.Base.Const Circs
        {
            get
            {
                return this.circs;
            }
            set
            {
                this.circs = value;
            }
        }

        /// <summary>
        /// 症状表现
        /// </summary>
        public HISFC.Models.Base.Const Symptom
        {
            get
            {
                return this.symptom;
            }
            set
            {
                this.symptom = value;
            }
        }

        /// <summary>
        /// 是否复发
        /// </summary>
        public bool IsRecrudesce
        {
            get
            {
                return this.isRecrudesce;
            }
            set
            {
                this.isRecrudesce = value;
            }
        }

        /// <summary>
        /// 复发时间
        /// </summary>
        public DateTime RecrudesceTime
        {
            get
            {
                return this.recrudesceTime;
            }
            set
            {
                this.recrudesceTime = value;
            }
        }

        /// <summary>
        /// 是否转移
        /// </summary>
        public bool IsTransfer
        {
            get
            {
                return this.isTransfer;
            }
            set
            {
                this.isTransfer = value;
            }
        }

        /// <summary>
        /// 转移部位
        /// </summary>
        public HISFC.Models.Base.Const TransferPosition
        {
            get
            {
                return this.transferPosition;
            }
            set
            {
                this.transferPosition = value;
            }
        }

        /// <summary>
        /// 是否有后遗症
        /// </summary>
        public bool IsSequela
        {
            get
            {
                return this.isSequela;
            }
            set
            {
                this.isSequela = value;
            }
        }

        /// <summary>
        /// 后遗症

        /// </summary>
        public HISFC.Models.Base.Const Sequela
        {
            get
            {
                return this.sequela;
            }
            set
            {
                this.sequela = value;
            }
        }

        /// <summary>
        /// 是否死亡
        /// </summary>
        public bool IsDead
        {
            get
            {
                return this.isDead;
            }
            set
            {
                this.isDead = value;
            }
        }

        /// <summary>
        /// 死亡时间
        /// </summary>
        public DateTime DeadTime
        {
            get
            {
                return this.deadTime;
            }
            set
            {
                this.deadTime = value;
            }
        }

        /// <summary>
        /// 死因编码
        /// </summary>
        public HISFC.Models.Base.Const DeadReason
        {
            get
            {
                return this.deadReason;
            }
            set
            {
                this.deadReason = value;
            }
        }

        /// <summary>
        /// 回信人

        /// </summary>
        public string WriteBackPerson
        {
            get
            {
                return this.writeBackPerson;
            }
            set
            {
                this.writeBackPerson = value;
            }
        }

        /// <summary>
        /// 随访方式
        /// </summary>
        public HISFC.Models.Base.Const VisitType
        {
            get
            {
                return this.visitType;
            }
            set
            {
                this.visitType = value;
            }
        }

        /// <summary>
        /// 随访操作环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment VisitOper
        {
            get
            {
                return this.visitOper;
            }
            set
            {
                this.visitOper = value;
            }
        }

        /// <summary>
        /// 随访结果录入操作环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment ResultOper
        {
            get
            {
                return this.resultOper;
            }
            set
            {
                this.resultOper = value;
            }
        }

        /// <summary>
        /// 随访结果是否成功
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return this.isSuccess;
            }
            set
            {
                this.isSuccess = value;
            }
        }

        /// <summary>
        /// 是否被动随访
        /// </summary>
        public bool IsPassive
        {
            get
            {
                return this.isPassive;
            }
            set
            {
                this.isPassive = value;
            }
        }

        /// <summary>
        /// 是否形成随访结果
        /// </summary>
        public bool IsResult
        {
            get
            {
                return this.isResult;
            }
            set
            {
                this.isResult = value;
            }
        }

        /// <summary>
        /// 是否统计工作量

        /// </summary>
        public bool IsWorkLoad
        {
            get
            {
                return this.isWorkLoad;
            }
            set
            {
                this.isWorkLoad = value;
            }
        }


        /// <summary>
        /// 随访采用的联系方式

        /// </summary>
        public LinkWay LinkWay
        {
            get
            {
                return this.linkWay;
            }
            set
            {
                this.linkWay = value;
            }
        }
        #region {E9F858A6-BDBC-4052-BA57-68755055FB80}
        
        
        /// <summary>
        /// 随访结果
        /// </summary>
        public HISFC.Models.Base.Const VisitResult
        {
            get { return visitResult; }
            set { visitResult = value; }
        }

        #endregion
        #endregion

        #region 方法

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>随访明细记录</returns>
        public new VisitRecord Clone()
        {
            VisitRecord visitRecord = base.Clone() as VisitRecord;

            visitRecord.Circs = this.Circs.Clone();
            visitRecord.Symptom = this.Symptom.Clone();
            visitRecord.TransferPosition = this.TransferPosition.Clone();
            visitRecord.Sequela = this.Sequela.Clone();
            visitRecord.DeadReason = this.DeadReason.Clone();
            visitRecord.VisitType = this.VisitType.Clone();
            visitRecord.VisitOper = this.VisitOper.Clone();
            visitRecord.ResultOper = this.ResultOper.Clone();

            #region {E9F858A6-BDBC-4052-BA57-68755055FB80}

            visitRecord.VisitResult = this.VisitResult.Clone();

            #endregion

            visitRecord.LinkWay = this.LinkWay.Clone();

            return visitRecord;
        }

        #endregion
        #endregion
    }
}
