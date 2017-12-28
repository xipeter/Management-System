using System;

namespace neusoft.HISFC.Object.Check
{
	/// <summary>
	/// DeptUse 的摘要说明。
	/// </summary>
	public class DeptUse : neusoft.neuFC.Object.neuObject
	{
		public DeptUse()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private neusoft.neuFC.Object.neuObject execDeptInfo = null;
		private neusoft.neuFC.Object.neuObject deptInfo = null;
		/// <summary>
		/// 本级编码 
		/// </summary>
		public string ParentCode ;
		/// <summary>
		/// 父级编码
		/// </summary>
		public string CurrentCode; 
		/// <summary>
		/// 执行科室
		/// </summary>
		public neusoft.neuFC.Object.neuObject ExecDeptInfo
		{
			get
			{
				if(execDeptInfo == null)
				{
					execDeptInfo = new neusoft.neuFC.Object.neuObject();
				}
				return execDeptInfo;
			}
			set
			{
				execDeptInfo = value;
			}
		}
		/// <summary>
		/// 科室
		/// </summary>
		public neusoft.neuFC.Object.neuObject DeptInfo 
		{
			get
			{
				if(deptInfo == null)
				{
					deptInfo = new neusoft.neuFC.Object.neuObject();
				}
				return deptInfo;
			}
			set
			{
				deptInfo = value;
			}
		}
		/// <summary>
		/// 项目
		/// </summary>
		public neusoft.HISFC.Object.Base.Item  item = new neusoft.HISFC.Object.Base.Item();
		/// <summary>
		/// 标示明细还是祖套
		/// </summary>
		public string UnitFlag ;
		public new DeptUse Clone()
		{
			DeptUse obj = base.Clone() as DeptUse;
			obj.ExecDeptInfo= this.ExecDeptInfo.Clone();
			obj.DeptInfo=this.DeptInfo.Clone();//(neusoft.HISFC.Object.Fee.Invoice)Invoice.Clone();

			obj.item=this.item.Clone();
			return obj;
		}
	}
}
