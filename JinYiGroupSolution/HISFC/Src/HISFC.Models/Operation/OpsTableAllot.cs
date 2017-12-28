using System;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Operation 
{
	/// <summary>
	/// [功能描述: 手术正台分配记录类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class OpsTableAllot : Neusoft.FrameWork.Models.NeuObject
	{
		public OpsTableAllot()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public OpsTableAllot(NeuObject user)
		{
			this.user = user;
		}
#region 属性
		private NeuObject opsRoom = new NeuObject();
		//手术室
		public Neusoft.FrameWork.Models.NeuObject OpsRoom
		{
			get
			{
				return this.opsRoom;
			}
			set
			{
				this.opsRoom = value;
			}
		}

		NeuObject dept = new NeuObject();
		//分配给科室
		public Neusoft.FrameWork.Models.NeuObject Dept
		{
			get
			{
				return this.dept;
			}
			set
			{
				this.dept = value;
			}
		}

		private NeuObject week =new NeuObject();
		//星期
		public Neusoft.FrameWork.Models.NeuObject Week
		{
			get
			{
				return this.week;
			}
			set
			{
				this.week = value;
			}
		}

		private NeuObject user;
		//操作员
		public Neusoft.FrameWork.Models.NeuObject User
		{
			get
			{
				if (this.user == null) 
				{
					this.user = new NeuObject();
				}
				return this.user;
			}
			set
			{
				this.user = value;
			}
		}
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
			get
			{
				return usedQty;
			}
		}

#endregion

#region 方法
		public new OpsTableAllot Clone()
		{
			OpsTableAllot newOpsTableAllot = base.Clone() as OpsTableAllot;
			newOpsTableAllot.OpsRoom = this.OpsRoom.Clone();
			newOpsTableAllot.Dept = this.Dept.Clone();
			newOpsTableAllot.week = this.week.Clone();
			newOpsTableAllot.User = this.User.Clone();
			return newOpsTableAllot;
		}
#endregion
		
	}
}
