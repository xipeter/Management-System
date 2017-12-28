using System;
using System.Collections;
namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// OpsApparatusRec 的摘要说明。
	/// 手术资料安排实体类
	/// </summary>
	public class OpsApparatusRec:neusoft.neuFC.Object.neuObject
	{
		public OpsApparatusRec()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 手术序号
		/// </summary>
		public string OperationNo = "";
		/// <summary>
		/// 仪器设备实体对象
		/// </summary>
		public neusoft.HISFC.Object.Operator.OpsApparatus OpsAppa = new OpsApparatus();
		/// <summary>
		/// 1术前安排2术后记录
		/// </summary>
		public int foreflag = 1;
		/// <summary>
		/// 数量
		/// </summary>
		public int Qty = 0;
		/// <summary>
		/// 资料单位
		/// </summary>
		public string AppaUnit = "";		
		/// <summary>
		/// 操作员
		/// </summary>
		public neusoft.HISFC.Object.RADT.Person User = new neusoft.HISFC.Object.RADT.Person();

		public new OpsApparatusRec Clone()
		{
			OpsApparatusRec newRec = new OpsApparatusRec();
			newRec.OperationNo = this.OperationNo;
			newRec.OpsAppa = this.OpsAppa.Clone();
			newRec.foreflag = this.foreflag;
			newRec.Qty = this.Qty;
			newRec.AppaUnit = this.AppaUnit;
			newRec.User = this.User.Clone();
			return newRec;
		}
	}
}
