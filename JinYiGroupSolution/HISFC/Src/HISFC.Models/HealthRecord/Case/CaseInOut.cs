using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病历入出库实体]<br></br>
    /// [创 建 者: 蒋飞]<br></br>
    /// [创建时间: 2007/08/23]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public class CaseInOut : Neusoft.NFC.Object.NeuObject
    {
        public CaseInOut()
        {
        }

        #region 私有变量

        /// <summary>
        /// 入出库流水号
        /// </summary>
        private int bill;

   
        /// <summary>
        ///出库单号码
        /// </summary>
        private string code;

     
        /// <summary>
        ///入库申请信息  
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment operRequest = new Neusoft.HISFC.Object.Base.OperEnvironment();

 
        /// <summary>
        ///入库申请病区编码        
        /// </summary>
        private string requestNurseCode;

 
        /// <summary>
        ///入库申请分区编码
        /// </summary>
        private string requestPartCode;

      
        /// <summary>
        ///出库核准信息 
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment operAuditing = new Neusoft.HISFC.Object.Base.OperEnvironment();

        
        /// <summary>
        ///出库审核病区编码
        /// </summary>
        private string auditingNurseCode;

        
        /// <summary>
        ///入库确认信息 
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment operConfirm = new Neusoft.HISFC.Object.Base.OperEnvironment();

       
        /// <summary>
        ///发送确认信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment operSend = new Neusoft.HISFC.Object.Base.OperEnvironment();

      
        /// <summary>
        ///接收确认信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment operReceive = new Neusoft.HISFC.Object.Base.OperEnvironment();

         
        /// <summary>           
        /// 是否接收
        /// </summary>
        private bool isReceive;

      
        /// <summary>
        /// 病历唯一ID
        /// </summary>
        private int caseID;

      
        /// <summary>
        /// 单据状态
        /// </summary>
        private string billState;

     
        /// <summary>           
        /// 是否被发送
        /// </summary>
        private bool isSend;

        #endregion


        #region 属性

        /// <summary>
        /// 入出库流水号
        /// </summary>
        public int Bill
        {
            get { return bill; }
            set { bill = value; }
        }
        
        /// <summary>
        ///出库单号码
        /// </summary>
        public string Code
        {
            get { return Code; }
            set { Code = value; }
        }

        /// <summary>
        ///入库申请信息  人工号 申请科室 入库时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment OperRequest
        {
            get { return operRequest; }
            set { operRequest = value; }
        }


        /// <summary>
        ///入库申请病区编码        
        /// </summary>
        public string RequestNurseCode
        {
            get { return RequestNurseCode; }
            set { RequestNurseCode = value; }
        }

           
        /// <summary>
        ///入库申请分区编码
        /// </summary>
        public string RequestPartCode
        {
            get { return RequestPartCode; }
            set { RequestPartCode = value; }
        }

        /// <summary>
        ///出库核准信息  人工号 出库科室 出库时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment OperAuditing
        {
            get { return OperAuditing; }
            set { OperAuditing = value; }
        }

        /// <summary>
        ///出库审核病区编码
        /// </summary>
        public string AuditingNurseCode
        {
            get { return AuditingNurseCode; }
            set { AuditingNurseCode = value; }
        }

        /// <summary>
        ///入库确认信息 人工号  入库确认时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment OperConfirm
        {
            get { return OperConfirm; }
            set { OperConfirm = value; }
        }

        /// <summary>
        ///发送确认信息 人工号  确认时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment OperSend
        {
            get { return OperSend; }
            set { OperSend = value; }
        }


        /// <summary>
        ///接收确认信息 人工号 确认时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment OperReceive
        {
            get { return OperReceive; }
            set { OperReceive = value; }
        }

        /// <summary>           
        /// 是否接收
        /// </summary>
        public bool IsReceive
        {
            get { return isReceive; }
            set { isReceive = value; }
        }

        /// <summary>
        /// 病历唯一ID
        /// </summary>
        public int CaseID
        {
            get { return CaseID; }
            set { CaseID = value; }
        }

        /// <summary>
        /// 单据状态
        /// </summary>
        public string BillState
        {
            get { return BillState; }
            set { BillState = value; }
        }
                
        /// <summary>           
        /// 是否被发送
        /// </summary>
        public bool IsSend
        {
            get { return isSend; }
            set { isSend = value; }
        }
        #endregion

        #region 公有函数


        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new CaseInOut Clone()
        {
            CaseInOut caseInOut = base.Clone() as CaseInOut;
            caseInOut.operRequest = this.operRequest.Clone();  
            caseInOut.operAuditing = this.operAuditing.Clone();          
            caseInOut.operConfirm = this.operConfirm.Clone();
            caseInOut.operSend = this.operSend.Clone();
            caseInOut.operReceive = this.operReceive.Clone();
          
            return caseInOut;
        }

        #endregion



    }
   
}
