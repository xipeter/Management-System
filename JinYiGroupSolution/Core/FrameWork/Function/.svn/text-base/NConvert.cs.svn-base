using System;
using System.Collections;
namespace Neusoft.FrameWork.Function 
{
	/// <summary>
	/// NConvert 的摘要说明。
	/// </summary>
	public class NConvert {


		/// <summary>
		/// val 可以是"true",或"false",或"0",或"1".
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static bool ToBoolean(string val) {
			if(val == null) {
				return false;
				//throw new ArgumentNullException(val);
			}
			bool result;
			switch(val.ToLower().Trim()) {
				case "true" :
				case "1":
					result = true;
					break;
				case "false":
				case "0":
					result = false;
					break;
				default :
					result = false;
					break;
			}    
		

			return result;
		}

		public static bool ToBoolean(object val) {
			if(val == null || val.ToString() == string.Empty)
				return false;
			return ToBoolean(val.ToString());
			
		}
		public static bool ToBoolean(int val) {
			if(val == 1)
				return true;
			else
				if(val == 0)
				return false;
			else
				throw new ArgumentException(val.ToString() + " is not equal 1 or 0.");
            
		}


		public static int ToInt32(bool val) {
			if(val == true)
				return 1;
			else
				return 0;
		}

		public static int ToInt32(string val) {
			if( val == null || val == string.Empty || val.ToLower() == "false")
				return 0;
			else
				if(val.ToLower() == "true")
				return 1;

			try {
				return (int)System.Convert.ToDecimal(val);
			}
			catch {
				return 0;
			}

		}

		public static int ToInt32(object val) {
		
			if(  val == null || val.ToString() == string.Empty)
				return 0; {

							  //try
							  return System.Convert.ToInt32(val);
						  } {
								//catch
								//	throw new ArgumentException(val + " is not numbers.");
							}

		}
	 

		public static decimal ToDecimal(object val) {
			if(val == null || val.ToString() == string.Empty)
				return 0;
			return Decimal.Parse(val.ToString());
		}

		public static decimal ToDecimal(string val) {
			if(val == null || val == string.Empty)
				return 0;
			//if(char.IsNumber(
			return Decimal.Parse(val);
		
		}
		

		/// <summary>
		/// 转换时间
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static DateTime ToDateTime(object val) {
		 
			if(val == null || val.ToString() == string.Empty) return DateTime.MinValue; 
			try
			{
				DateTime d = System.Convert.ToDateTime(val.ToString());
				return d;
			}
			catch
			{
				return DateTime.MinValue;
			}
		}

		public static DateTime ToDateTime(string val) {
			if(val == null || val == string.Empty) {
				return DateTime.MinValue;     				
			}
			try
			{
				DateTime d = System.Convert.ToDateTime(val.ToString());
				return d;
			}
			catch
			{
				return DateTime.MinValue;
			}
		}

		/// <summary>
		/// 转换arrayList to Array    这个用的着吗？！
		/// </summary>
		/// <param name="al"></param>
		/// <returns></returns>
		public static object[] ToArray(ArrayList al) {
			return al.ToArray();
		}
		//	public static string ToString(bool

        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string enumString,bool ignoreCase,T defaultValue)
        {
            T tEnum = defaultValue;

            try
            {
                tEnum = (T)System.Enum.Parse(typeof(T), enumString,ignoreCase);
            }
            catch (System.ArgumentException eArgument)
            {
                return defaultValue;
            }
            return tEnum;
        }

        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string enumString, T defaultValue)
        {
            return ToEnum<T>(enumString, false, defaultValue);
        }

		#region  金额小写变大写 
		/// <summary> 
		/// 金额小写变大写 
		/// creator : zuowy@Neusoft.com 
		/// 2005.11.23 
		/// </summary> 
		/// <param name="smallnum"></param> 
		/// <returns></returns> 
		public static string ToCapital(decimal smallnum) { 
			string cmoney , cnumber, cnum, cnum_end,cmon ,cno,snum ,sno; 
			int snum_len , sint_len, cbegin, zflag , i; 
			if(smallnum > 1000000000000 || smallnum < -99999999999 || smallnum == 0) 
				return ""; 
			cmoney = "仟佰拾亿仟佰拾万仟佰拾元角分" ;// 大写人民币单位字符串 
			cnumber = "壹贰叁肆伍陆柒捌玖"          ;// 大写数字字符串 
			cnum = ""                               ;// 转换后的大写数字字符串 
			cnum_end = ""                           ;// 转换后的大写数字字符串的最后一位 
			cmon = ""                               ;// 取大写人民币单位字符串中的某一位 
			cno = ""                                ;// 取大写数字字符串中的某一位 
 
 
             
			snum = System.Decimal.Round(smallnum,2).ToString("############.00");  ;// 小写数字字符串 
			snum_len = snum.Length                  ;// 小写数字字符串的长度 
			sint_len = snum_len - 2                 ;// 小写数字整数部份字符串的长度 
			sno = ""                                ;// 小写数字字符串中的某个数字字符 
			cbegin = 15 - snum_len                  ;// 大写人民币单位中的汉字位置 
			zflag = 1                               ;// 小写数字字符是否为0(0=0)的判断标志 
			i = 0                                   ;// 小写数字字符串中数字字符的位置 
 
			if(snum_len > 15) 
				return ""; 
			for(i=0;i<snum_len;i++) { 
				if (i==sint_len-1) 
					continue; 
 
                 
				cmon = cmoney.Substring(cbegin, 1); 
				cbegin = cbegin + 1; 
				sno =snum.Substring(i,1); 
				if (sno=="-") { 
					cnum = cnum + "负"; 
					continue; 
				} 
				else if(sno=="0")
                {
                    #region {DD90B06A-90B0-4129-984E-D888FF841A64} 住院日结发生异常，日结总金额是-0.09元，跟程序发现时是转换成大写的时候发生了异常，Neusoft.NFC.Function.NConvert，方法public static string ToCapital(decimal smallnum) ，异常抛出的位置else if(sno=="0") { cnum_end = cnum.Substring(cnum.Length-2,1); ，看了半天不知道咋改，高手看看咋下刀，谢谢。
                    if (cnum.Length - 2 < 0)
                    {
                        continue;
                    } 
                    #endregion
					cnum_end = cnum.Substring(cnum.Length-2,1); 
					if(cbegin == 4 || (cbegin == 8 || cnum_end.IndexOf("亿")>=0|| cbegin == 12 )) { 
						cnum = cnum + cmon; 
						if (cnumber.IndexOf(cnum_end)>=0 ) 
							zflag = 1; 
						else 
							zflag = 0; 
					} 
					else { 
						zflag = 0; 
					} 
					continue; 
				} 
				else if( sno != "0" && zflag == 0) { 
					cnum = cnum + "零"; 
					zflag = 1; 
				} 
				cno =cnumber.Substring(System.Convert.ToInt32(sno)-1, 1); 
				cnum = cnum + cno + cmon; 
			} 
			if (snum.Substring(snum.Length-2,1)=="0") { 
				return  cnum + "整"; 
			} 
			else 
				return cnum; 
		} 

		#endregion 
	}
}
