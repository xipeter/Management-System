using System;
using System.IO;
using System.Reflection;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// 反射类
	/// </summary>
	internal class OwnAssembly
	{
		public static Type GetType(string TypeName)
		{
			if(TypeName == null) return null;

			string[] typeName = TypeName.Split(new Char[] {','});
			if(typeName.Length < 2) return null;

			string TypeFullName = typeName[0].Trim();
			if(TypeFullName == "") return null;
			

			string dllName = typeName[1].Trim();
			if(dllName == "") return null;

            Assembly ass = null;
            try
            {
                ass = GetAssembly(dllName);
            }
            catch
            {
                return null;
            }
			if(ass == null) return null;

			Type t = null;

			foreach(Type tt in ass.GetTypes())
			{
				if(TypeFullName == tt.ToString())
				{
					t = tt;
					break;
				}
			}

			return t;
		}

		/// <summary>
		/// 方法，根据DLL名取得Assembly：public static Assembly
		/// </summary>
		/// <param name="DllName">DLL名</param>
		/// <returns>成功返回 Assembly，失败返回 null</returns>
		public static Assembly GetAssembly(string DllName)
		{
			if(DllName == null) return null;

			Assembly ass = null;
			string dllName = DllName.Trim();
			dllName = KillEnd(dllName, ".dll");

			try
			{
				ass = Assembly.Load(dllName);

			}
			catch(FileNotFoundException)
			{
				throw (new Exception("找不到动态链接库：" + DllName));
			}
			catch(ArgumentNullException)
			{
				throw (new Exception("动态链接库为空" + DllName));
			}

			if(ass == null) 
			{
				throw (new Exception("找不到动态链接库：" + DllName));
			}
			return ass;
		}

		/// <summary>
		/// 方法，去掉结尾的子串(不区分大小写)
		/// </summary>
		/// <param name="strName">字符串</param>
		/// <param name="strSub">子串</param>
		/// <returns>去掉结尾的子串的字符串</returns>
		public static string KillEnd(string strName, string strSub)
		{
			if(strName.Length < strSub.Length) return strName;

			if(strName.Substring(strName.Length-strSub.Length,strSub.Length).ToLower() == strSub)
			{
				return (strName.Substring(0, strName.Length-strSub.Length));
			}
			else return strName;
		}

	}
}
