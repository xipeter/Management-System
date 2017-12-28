using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.MedTech.Base;

namespace Neusoft.HISFC.Models.MedTech.Booking
{
    /// <summary>
    /// [功能描述: 项目预约信息]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public class BookingApplyInfo : Spell,IPatientItemApply,ISort
    {
        /// <summary>
        /// 构造函数 
        /// ID 预约单号
        /// NAME 无意义

        /// </summary>
        public BookingApplyInfo()
        {
        }

        #region 变量

        /// <summary>
        /// 健康情况
        /// </summary>
        private string healthStatus;

        private Neusoft.HISFC.Models.Fee.FeeItemBase feeItem = null;

        /// <summary>
        /// 患者信息实体

        /// </summary>
        private Neusoft.HISFC.Models.RADT.Patient patient;

        /// <summary>
        /// 交易类型
        /// </summary>
        private Neusoft.HISFC.Models.Base.TransTypes transType;

        /// <summary>
        /// 项目预约扩展信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.DeptItem deptitem = new DeptItem();

        ///数量
        private decimal amount;

        /// <summary>
        /// 预约状态(这个可能要改[2006/12/26]xuwz,用下面的枚举代替)
        /// </summary>
        private Neusoft.HISFC.Models.MedTech.Booking.BookingStateEnumService bookState = new Neusoft.HISFC.Models.MedTech.Booking.BookingStateEnumService();

        private Neusoft.HISFC.Models.Base.EnumBookingState bookingState = new EnumBookingState();
        /// <summary>
        ///当前序号
        /// </summary>
        private int sortId;

        /// <summary>
        /// 预约登记单据号

        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject recipeNo;

        /// <summary>
        /// 开单科室

        /// </summary>
        private Neusoft.HISFC.Models.Base.Department recipeDept;

        /// <summary>
        /// 医嘱流水号

        /// </summary>
        private string orderExecSequence;

        /// <summary>
        /// 由于设备没写呢，拿Neuobject代替
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject machine = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        ///预约申请操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new OperEnvironment();

        /// <summary>
        /// 预约登记操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment bookingOper = new OperEnvironment();
        
        /// <summary>
        /// 预约取消操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment cancelOper = new OperEnvironment();

        #endregion 
        
        #region 属性


        /// <summary>
        /// 预约状态[2006/12/23]xuwz
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumBookingState BookingState
        {
            get
            {
                return this.bookingState;
            }
            set
            {
                this.bookingState = value;
            }
        }

        /// <summary>
        /// 健康情况
        /// </summary>
        public string HealthStatus
        {
            get
            {
                return this.healthStatus;
            }
            set
            {
                this.healthStatus = value;
            }
        }

        public Neusoft.HISFC.Models.Fee.FeeItemBase FeeItem 
        {
            get 
            {
                return this.feeItem;
            }
            set 
            {
                this.feeItem = value;
            }
        }

        /// <summary>
        /// 交易类型
        /// </summary>
        public Neusoft.HISFC.Models.Base.TransTypes TransType
        {
            get
            {
                return this.transType;
            }
            set
            {
                this.transType = value;
            }
        }

        /// <summary>
        /// 开单科室

        /// </summary>
        public Neusoft.HISFC.Models.Base.Department RecipeDept
        {
            get { return recipeDept; }
            set { recipeDept = value; }
        }

        /// <summary>
        /// 预约状态

        /// </summary>
        public Neusoft.HISFC.Models.MedTech.Booking.BookingStateEnumService BookState
        {
            get 
            {
                return bookState; 
            }
            set 
            { 
                bookState = value; 
            }
        }

        /// <summary>
        /// 预约登记单据号

        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject RecipeNo
        {
            get { return recipeNo; }
            set { recipeNo = value; }
        }
        
        /// <summary>
        /// 预约登记操作员

        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment BookingOper
        {
            get { return bookingOper; }
            set { bookingOper = value; }
        }
      
        /// <summary>
        /// 预约取消操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CancelOper
        {
            get 
            { 
                return cancelOper; 
            }
            set 
            { 
                cancelOper = value; 
            }
        }

        
        #endregion

        #region 方法
        public new BookingApplyInfo Clone()
        {
            BookingApplyInfo bookingApplyInfo = base.Clone() as BookingApplyInfo;
            bookingApplyInfo.patient = this.patient.Clone();
            bookingApplyInfo.deptitem = this.deptitem.Clone();
            bookingApplyInfo.oper = this.oper.Clone();
            bookingApplyInfo.bookingOper = this.bookingOper.Clone();
            bookingApplyInfo.cancelOper = this.cancelOper.Clone();

            return bookingApplyInfo;
        }
        #endregion

        #region 实现接口

        #region IPatientItemApply 成员

        public Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }

        public DeptItem DeptItem
        {
            get
            {
                return this.deptitem;
            }
            set
            {
                this.deptitem = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string OrderExecSequence
        {
            get
            {
                return this.orderExecSequence;
            }
            set
            {
                this.orderExecSequence = value;
            }
        }

        public Neusoft.FrameWork.Models.NeuObject Machine
        {
            get
            {
                return this.machine;
            }
            set
            {
                machine = value;
            }
        }

        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        #endregion

        #endregion

        #region ISort 成员

        public int SortID
        {
            get
            {
                return this.sortId;
            }
            set
            {
                this.sortId = value;
            }
        }

        #endregion
    }
}