using System;

namespace neusoft.HISFC.Object.Check
{
	/// <summary>
	/// 体检组套明细 
	/// </summary>
	public class ChkGroupDetail  : neusoft.HISFC.Object.Fee.ComGroupTail
	{
		public ChkGroupDetail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 有效 0 有效 1无效 
		/// </summary>
		public  string ValidState ;
		/// <summary>
		/// 检测次数
		/// </summary>
		public int ChkTime ; 
		/// <summary>
		/// 规格
		/// </summary>
		public string Spacs;
		/// <summary>
		/// 执行科室
		/// </summary>
		public neusoft.neuFC.Object.neuObject ExecDept = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new ChkGroupDetail Clone()
		{
			return this.MemberwiseClone() as ChkGroupDetail;
		}
	}
}
