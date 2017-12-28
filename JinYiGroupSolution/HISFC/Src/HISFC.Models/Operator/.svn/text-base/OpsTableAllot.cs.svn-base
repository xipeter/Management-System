using System;
using System.Collections;
namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// OpsTableAllot 的摘要说明。
	/// 手术正台分配记录类
	/// </summary>
	public class OpsTableAllot:neusoft.neuFC.Object.neuObject
	{
		public OpsTableAllot()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//手术室
		public neusoft.neuFC.Object.neuObject OpsRoom = new neusoft.neuFC.Object.neuObject();
		//分配给科室
		public neusoft.neuFC.Object.neuObject Dept = new neusoft.neuFC.Object.neuObject();
		//星期
		public neusoft.neuFC.Object.neuObject week = new neusoft.neuFC.Object.neuObject();
		//操作员
		public neusoft.neuFC.Object.neuObject User = new neusoft.neuFC.Object.neuObject();
		//分配正台数
		private int limitedQty;
		public int Qty
		{
			get
			{				
				return this.limitedQty;
			}
			set
			{
				this.limitedQty = value;
			}
		}		
		//已经使用正台数
		private int usedQty;
		/// <summary>
		/// 使用正台数
		/// </summary>
		public int Used
		{
			get{return usedQty;}
		}

		public new OpsTableAllot Clone()
		{
			OpsTableAllot newOpsTableAllot = new OpsTableAllot();
			newOpsTableAllot.OpsRoom = this.OpsRoom.Clone();
			newOpsTableAllot.Dept = this.Dept.Clone();
			newOpsTableAllot.week = this.week.Clone();
			newOpsTableAllot.limitedQty = this.limitedQty;
			newOpsTableAllot.usedQty=this.usedQty;
			newOpsTableAllot.User = this.User.Clone();
			return newOpsTableAllot;
		}
	}
}
