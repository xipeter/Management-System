using System;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Confect<br></br>
	/// [功能描述: 配制类]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Confect:PPRBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Confect()
		{
		}


		#region 变量
		/// <summary>
		/// 配制衡器校验 药物天平 0 矫正 1 效期内
		/// </summary>
		private string scaleFlag;
		/// <summary>
		/// 配制衡器校验 磅秤 0 矫正 1 效期内
		/// </summary>
		private string stetlyardFlag;
		/// <summary>
		/// 配制复核人
		/// </summary>
		private string checkOper;
		/// <summary>
		/// 配制--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment confectEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();


		#endregion

		#region  属性
		/// <summary>
		/// 配制衡器校验 药物天平 0 矫正 1 效期内
		/// </summary>		
		public string ScaleFlag
		{
			get
			{
				return this.scaleFlag;
			}
			set
			{
				this.scaleFlag = value;
			}
		}
		/// <summary>
		/// 配制衡器校验 磅秤 0 矫正 1 效期内
		/// </summary>
		public string StetlyardFlag
		{
			get
			{
				return this.stetlyardFlag;
			}
			set
			{
				this.stetlyardFlag = value;
			}
		}

		/// <summary>
		/// 配制复核人
		/// </summary>
		public string CheckOper
		{
			get
			{
				return this.checkOper;
			}
			set
			{
				this.checkOper = value;
			}
		}
		/// <summary>
		/// 配制--人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ConfectEnv
		{
			get
			{
				return this.confectEnv;
			}
			set
			{
				this.confectEnv = value;
			}
		}

		#endregion

		#region  方法
		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>Confect</returns>
		public new Confect Clone()
		{
			Confect confect = base.Clone() as Confect;
			confect.confectEnv = this.confectEnv.Clone();
			return confect;
		}
		#endregion
		
		#region 过期的属性
		/// <summary>
		/// 配制人
		/// </summary>
		[System.Obsolete("已经过期，使用ConfectEnv", true)]
		public string ConfectOper;
		/// <summary>
		/// 配制时间
		/// </summary>
		[System.Obsolete("已经过期，使用ConfectEnv", true)]
		public DateTime ConfectDate;
		#endregion
	}
}
