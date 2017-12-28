using System;


namespace Neusoft.HISFC.Object.PhysicalExam {


	/// <summary>
	/// DeptUse 的摘要说明。
	/// </summary>
	public class DeptUse : Neusoft.NFC.Object.NeuObject
	{
		public DeptUse()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private Neusoft.NFC.Object.NeuObject execDeptInfo = null;
		private Neusoft.NFC.Object.NeuObject deptInfo = null;
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
		public Neusoft.NFC.Object.NeuObject ExecDeptInfo
		{
			get
			{
				if(execDeptInfo == null)
				{
					execDeptInfo = new Neusoft.NFC.Object.NeuObject();
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
		public Neusoft.NFC.Object.NeuObject DeptInfo 
		{
			get
			{
				if(deptInfo == null)
				{
					deptInfo = new Neusoft.NFC.Object.NeuObject();
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
		public Neusoft.HISFC.Object.Base.Item  item = new Neusoft.HISFC.Object.Base.Item();
		/// <summary>
		/// 标示明细还是祖套
		/// </summary>
		public string UnitFlag ;

		public new DeptUse Clone()
		{
			DeptUse obj = base.Clone() as DeptUse;
			obj.ExecDeptInfo= this.ExecDeptInfo.Clone();
			obj.DeptInfo=this.DeptInfo.Clone();//(Neusoft.HISFC.Object.Fee.Invoice)Invoice.Clone();

			obj.item=this.item.Clone();
			return obj;
		}
	}
}
