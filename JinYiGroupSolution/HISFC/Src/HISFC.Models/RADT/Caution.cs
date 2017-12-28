using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// [功能描述: 担保实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2006-9-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [Serializable]
	public class Caution :NeuObject 
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Caution()
		{
		}

        #region 变量

		/// <summary>
		/// 担保金额
		/// </summary>
		private decimal money = 0M;

		
		
		/// <summary>
		/// 审批人
		/// </summary>
		private OperEnvironment  auditingOper= new OperEnvironment();
		
		/// <summary>
		/// 担保类型
		/// </summary>
		private string type;

		#endregion

        #region 属性

		/// <summary>
		/// 担保金额
		/// </summary>
		public decimal Money
		{
			get
			{
				return this.money;
			}
			set
			{
				this.money = value ;
			}
		}

		/// <summary>
		/// 审批人
		/// </summary>
		public OperEnvironment  AuditingOper
		{
			get
			{
				return this.auditingOper;
			}
			set
			{
				this.auditingOper = value ;
			}
		}
		
		/// <summary>
		/// 担保类型
		/// </summary>
		public string Type
		{
			get
			{
				return this.type ;
			}
			set
			{
				this.type = value ;
			}
		}
		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Caution Clone()
		{
			Caution caution= base.Clone() as Caution;
			caution.AuditingOper = this.AuditingOper.Clone();
			return caution;
		}

		#endregion
		
		#region 过期
		
		/// <summary>
		/// 审批人 已作废
		/// </summary>
		[Obsolete("更改为 属性 AuditingOper")]
		private OperEnvironment  applyPerson = new OperEnvironment();

		#endregion
	}
}
