
/*----------------------------------------------------------------
            // Copyright (C) 沈阳东软软件股份有限公司
            // 版权所有。 
            //
            // 文件名：			TerminalConfirmDetail.cs
            // 文件功能描述：	医技终端确认业务明细实体层类
            //
            // 
            // 创建标识：		2006-6-21
            //
            // 修改标识：
            // 修改描述：
            //
            // 修改标识：
            // 修改描述：
//----------------------------------------------------------------*/

using neusoft.neuFC.Object;
namespace neusoft.HISFC.Object.MedTech
{
	/// <summary>
	/// 终端确认业务明细
	/// </summary>
	public class TerminalConfirmDetail : neusoft.neuFC.Object.neuObject
	{
		public TerminalConfirmDetail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 申请单信息
		/// </summary>
		TerminalApply apply = new TerminalApply();
		/// <summary>
		/// 申请单信息
		/// </summary>
		public TerminalApply Apply
		{
			get
			{
				return this.apply;
			}
			set
			{
				this.apply = value;
			}
		}
		
		/// <summary>
		/// 医院级别编码
		/// </summary>
		neusoft.neuFC.Object.neuObject hospital = new neuObject();
		/// <summary>
		/// 医院级别编码
		/// </summary>
		public neusoft.neuFC.Object.neuObject Hospital
		{
			get
			{
				return this.hospital;
			}
			set
			{
				this.hospital = value;
			}
		}
		/// <summary>
		/// 记录流水号
		/// </summary>
		int sequence = 0;
		/// <summary>
		/// 记录流水号
		/// </summary>
		public int Sequence
		{
			get
			{
				return this.sequence;
			}
			set
			{
				this.sequence = value;
			}
		}
		/// <summary>
		/// 剩余数量
		/// </summary>
		decimal freeCount = 0m;
		/// <summary>
		/// 剩余数量
		/// </summary>
		public decimal FreeCount
		{
			get
			{
				return this.freeCount;
			}
			set
			{
				this.freeCount = value;
			}
		}
		/// <summary>
		/// 状态
		/// </summary>
		neusoft.neuFC.Object.neuObject status = new neuObject();
		/// <summary>
		/// 状态
		/// </summary>
		public neusoft.neuFC.Object.neuObject Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}

		public new TerminalConfirmDetail Clone()
		{
			TerminalConfirmDetail detail = base.Clone() as TerminalConfirmDetail;
			detail.Apply = this.Apply.Clone();
			detail.Hospital = this.Hospital.Clone();
			detail.Status = this.Status.Clone();
			return detail;
		}
	}
}
