using System;

namespace Neusoft.FrameWork.Exceptions
{
	/// <summary>
	/// Exceptions 的摘要说明。
	/// </summary>
	public class ReturnNullValueException : Exception
	{
		public ReturnNullValueException()  : base("函数返回值为空！")
		{
			
		}

		public ReturnNullValueException(string msg)  : base(msg)
		{
			 
		}
	}

	public class NullValueException : Exception
	{
		public NullValueException(string msg) : base(msg)
		{
		}
	}
}
