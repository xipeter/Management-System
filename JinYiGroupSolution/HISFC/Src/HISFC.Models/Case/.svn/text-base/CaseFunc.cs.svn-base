using System;

namespace neusoft.HISFC.Object.Case
{
   /// <summary>
   /// 为什么这个函数写到实体层当中呢，真的不明白,为啥不写到neufc当中去呀
   /// </summary>
	public class CaseFunc
	{
		public CaseFunc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 判断域是否超过数据列规定长度，如果超过长度抛出异常
		/// </summary>
		/// <param name="Obj">输入域</param>
		/// <param name="length">对应数据列制定长度</param>
		/// <param name="exMessage">异常错误信息</param>
		/// <returns>返回值 True符合条件 错误直接抛出异常</returns>
		public static bool ExLength( System.Object Obj, int length, string exMessage )
		{
			if( Obj.ToString().Length > length )
			{
				Exception ExLength = new Exception( exMessage + " 超过" + length.ToString() + "位！" );
				ExLength.Source = Obj.ToString();
				throw ExLength;
			}
			else
			{
				return true;
			}
		}
	}
}
