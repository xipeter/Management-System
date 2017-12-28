using Neusoft.HISFC.Models.Base;
using System.Collections;
using Neusoft.FrameWork.Models;
namespace Neusoft.HISFC.Models.MedTech.Booking
{
    /// <summary>
    /// [功能描述: 每个患者在终端所处的状态枚举]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
	public class BookingStateEnumService: EnumServiceBase
    
    {
        public BookingStateEnumService()

        {
            this.Items[EnumBookingState.Apply] = "Apply医技预约申请状态";
            this.Items[EnumBookingState.Booking] = "Booking医技预约登记状态";
            this.Items[EnumBookingState.CancelBooking] = "CancelBookinng医技预约取消状态";
            this.Items[EnumBookingState.Execute] = "Execute医技预约执行状态";
            this.Items[EnumBookingState.Invalid] = "Invalid医技预约取消状态";			
        }

        #region 变量

		/// <summary>
		/// 预约状态
		/// </summary>
        EnumBookingState enumState;

		/// <summary>
		/// 存储枚举定义
		/// </summary>
        protected static System.Collections.Hashtable items = new System.Collections.Hashtable();

		#endregion

		#region 属性

		/// <summary>
		/// 存贮枚举名称
		/// </summary>
        protected override System.Collections.Hashtable Items
		{
			get
			{
				return items;
			}
		}
		
		/// <summary>
		/// 枚举项目
		/// </summary>
		protected override System.Enum EnumItem
		{
			get
			{
				return this.enumState;
			}
		}

		#endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(items.Values));
        }
        
		
	}
}
