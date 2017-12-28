using System;

namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// DataBaseManger 的摘要说明。
	/// 管理基类的实现
	/// </summary>
	public class DataBaseManger : Database
	{
		public DataBaseManger()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose(bool isDisposing)
		{
			base.Dispose (isDisposing);
		}

			

	

	}
}
