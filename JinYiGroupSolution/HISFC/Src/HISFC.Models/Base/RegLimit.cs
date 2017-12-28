using System;
using neusoft.neuFC.Object;
namespace neusoft.HISFC.Object.Base
{
	/// <summary>
	///门诊限额实体
	/// </summary>
	public class RegLimit:neusoft.neuFC.Object.neuObject 
	{
		public RegLimit()
		{
		}
		/// <summary>
		/// 星期
		/// </summary>
		public string week;
		/// <summary>
		/// 午别
		/// </summary>
		public neuObject Noon=new neuObject();
		/// <summary>
		/// 看诊日期
		/// </summary>
		public DateTime SeeDate;
		/// <summary>
		/// 出诊科室
		/// </summary>
		public neuObject OutDept=new neuObject();
		/// <summary>
		/// 挂号级别
		/// </summary>
		public neuObject RegLevel=new neuObject();
		/// <summary>
		/// 预约限额
		/// </summary>
		public int Pre_Limit; 
		/// <summary>
		/// 初诊限额
		/// </summary>
		public int Fir_Limit;
		/// <summary>
		/// 复诊限额
		/// </summary>
		public int Rep_Limit;
		/// <summary>
		/// 急诊限额
		/// </summary>
		public int Urg_Limit;
		/// <summary>
		/// 预约已挂
		/// </summary>
		public int Pre_Reged; 
		/// <summary>
		/// 初诊已挂
		/// </summary>
		public int Fir_Reged;
		/// <summary>
		/// 复诊已挂
		/// </summary>
		public int Rep_Reged;
		/// <summary>
		/// 急诊已挂
		/// </summary>
		public int Urg_Reged;
		/// <summary>
		/// 预约额满
		/// </summary>
		public bool Pre_full; 
		/// <summary>
		/// 初诊额满
		/// </summary>
		public bool Fir_full;
		/// <summary>
		/// 复诊额满
		/// </summary>
		public bool Rep_full;
		/// <summary>
		/// 急诊额满
		/// </summary>
		public bool Urg_full;
		/// <summary>
		/// 出诊挂号费
		/// </summary>
		public float Fir_Fee;
		/// <summary>
		/// 复诊挂号费
		/// </summary>
		public float Rep_Fee;
		/// <summary>
		/// 检查费
		/// </summary>
		public float Check_Fee;
		/// <summary>
		/// 诊察费
		/// </summary>
		public float Diag_Fee;
		/// <summary>
		/// 其他费
		/// </summary>
		public float Other_Fee;
		/// <summary>
		/// 急诊挂号费
		/// </summary>
		public float Urg_Fee;
		/// <summary>
		/// 急诊检查费
		/// </summary>
		public float Urg_Check_Fee;
		/// <summary>
		/// 急诊诊察费
		/// </summary>
		public float Urg_Diag_Fee;
		/// <summary>
		/// 急诊其他费
		/// </summary>
		public float Urg_Other_Fee;

	}
}
