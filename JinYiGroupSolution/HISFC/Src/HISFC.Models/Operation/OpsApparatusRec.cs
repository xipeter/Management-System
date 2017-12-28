using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Operation 
{
	/// <summary>
	/// OpsApparatusRec 的摘要说明。
	/// 手术资料安排实体类
	/// </summary>
    [Serializable]
    public class OpsApparatusRec : Neusoft.FrameWork.Models.NeuObject
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
		public OpsApparatus OpsAppa = new OpsApparatus();
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
		public Neusoft.HISFC.Models.Base.Employee User = new Employee();

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
