using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

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
    /// 
    [System.Serializable]
    public class ItemBookingInfo:ItemBookingTemplate,IValid
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public ItemBookingInfo()
        {
        }

        #region 变量

        /// <summary>
        /// 限额序号
        /// </summary>
        private int sequence;

        /// <summary>
        /// 限额１序号

        /// </summary>
        private int sequence1;

        /// <summary>
        /// 限额２序号

        /// </summary>
        private int sequence2;

        /// <summary>
        /// 占用限额数

        /// </summary>
        private int surplusQuotaNum;

        /// <summary>
        /// 占用限额１数
        /// </summary>
        private int surplusQuota1Num;

        /// <summary>
        /// 占用限额２数
        /// </summary>
        private int surplusQuota2Num;

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = true;

        #endregion

        #region 属性

        
        /// <summary>
        /// 限额序号
        /// </summary>
        public int Sequence
        {
            get 
            { 
                return sequence; 
            }
            set 
            { 
                sequence = value; 
            }
        }

        /// <summary>
        /// 限额１顺号

        /// </summary>
        public int Sequence1
        {
            get 
            { 
                return sequence1; 
            }
            set 
            { 
                sequence1 = value; 
            }
        }
        
        /// <summary>
        /// 限额2序号
        /// </summary>
        public int Sequence2
        {
            get 
            { 
                return sequence2; 
            }
            set 
            { 
                sequence2 = value; 
            }
        }

        /// <summary>
        /// 占用限额数

        /// </summary>
        public int SurplusQuotaNum
        {
            get
            {
                return surplusQuotaNum;
            }
            set
            {
                surplusQuotaNum = value;
            }
        }

        /// <summary>
        /// 占用限额1数

        /// </summary>
        public int SurplusQuota1Num
        {
          get 
          {
              return surplusQuota1Num; 
          }
          set
          {
              surplusQuota1Num = value; 
          }
        }
        
        /// <summary>
        /// 占用限额2数

        /// </summary>
        public int SurplusQuota2Num
        {
          get 
          { 
               return surplusQuota2Num; 
          }
          set 
          { 
               surplusQuota2Num = value; 
          }
        }
        #endregion

        #region 方法
        public new ItemBookingInfo Clone()
        {
            ItemBookingInfo ItemBookingInfo = base.Clone() as ItemBookingInfo;

            return ItemBookingInfo;
        }
        #endregion

        #region 实现接口
         #region IValid 成员

        bool IValid.IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion
        #endregion
    }
}
