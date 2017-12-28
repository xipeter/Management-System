using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Examination
{
    /// <summary>
    /// [功能说明:操作员日结实体类]
    /// [创建时间:2008-09]
    /// [创建人:许超]
    ///  <修改记录 
    ///		修改人='王政东' 
    ///		修改时间='2008-12' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CHKFeeItem : Neusoft.HISFC.Object.Fee.FeeItemBase
    {

        #region 变量
        /// <summary>
        /// 划价类别,1：个体体检划价，2：集体体检划价
        /// </summary>
        private string chargeType = "1";
        
        /// <summary>
        /// 体检单位信息
        /// </summary>
        private Neusoft.NFC.Object.NeuObject compInfo = new Neusoft.NFC.Object.NeuObject ();

        /// <summary>
        /// 是否日结
        /// </summary>
        private bool isDayBalanced = false;


        /// <summary>
        /// 登记日期
        /// </summary>
        private DateTime regDate = new DateTime();
        #endregion

        #region 属性

        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RegDate
        {
            get 
            { 
                return regDate;
            }
            
            set 
            { 
                regDate = value; 
            }
        }

        /// <summary>
        /// 是否日结
        /// </summary>
        public bool IsDayBalanced
        {
            get 
            { 
                return isDayBalanced; 
            }
            
            set 
            { 
                isDayBalanced = value; 
            }
        }

        /// <summary>
        /// 划价类别,1：个体体检划价，2：集体体检划价；默认1
        /// </summary>
        public string ChargeType
        {
            get 
            { 
                return chargeType; 
            }
            
            set 
            { 
                chargeType = value; 
            }
        }
        #endregion

        #region 克隆方法
        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public CHKFeeItem Clone()
        {
            CHKFeeItem o = base.Clone() as CHKFeeItem;
            o.compInfo = this.compInfo.Clone();
            return o;
        }
        #endregion
    }
}