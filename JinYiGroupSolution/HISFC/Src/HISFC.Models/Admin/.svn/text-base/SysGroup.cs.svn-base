using System;


namespace Neusoft.HISFC.Models.Admin {


	/// <summary>
	/// SysGroup 的摘要说明。
	/// 系统组
	/// id 本组编码，name 本组名称
	/// </summary>
    /// 
    [System.Serializable]
	public class SysGroup:Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.ISort
	{
		public SysGroup()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 父级组
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ParentGroup = new Neusoft.FrameWork.Models.NeuObject();

		#region ISort 成员
		protected int sortid;
		public int SortID
		{
			get
			{
				// TODO:  添加 SysGroup.SortID getter 实现
				return this.sortid;
			}
			set
			{
				// TODO:  添加 SysGroup.SortID setter 实现
				this.sortid = value;
			}
		}

		#endregion


		public new SysGroup Clone()
		{
			SysGroup obj= base.Clone() as SysGroup;
			obj.ParentGroup = this.ParentGroup.Clone();
			return obj;
		}
	}
}
