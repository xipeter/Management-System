using System;

namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// 计算类
	/// wolf 2004-6
	/// </summary>
	public class Caculation
	{
		public Caculation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// if语句判断
		/// <example>
		/// <code>
		///MessageBox.Show(c._if("if( 120 > 50,true,false )"));
		///</code>
		///</example>
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string _if(string s)
		{
			int j;
			string condition,t,f="";
			try
			{
				if(s.TrimStart().Substring(0,2).ToLower()=="if")
				{
					s=s.Substring(4);
					j=s.IndexOf(",");
					condition=s.Substring(0,j);
					s=s.Substring(j+1);
					j=s.IndexOf(",");
					t=s.Substring(0,j);
					s=s.Substring(j+1);
					f=s.Substring(0,s.Length-1);
					if(_condition(condition))
					{
						return t;
					}
					else
					{
						return f;
					}
				}
				return f;
			}
			catch
			{
				return "";
			}

		}
		public string f_cal(string s)
		{
			try
			{
				
				int i,pos;
				//			for(i =1;i<5;i++)
				//			{
				//				switch(i)
				//				{
				//					case 1:control =" + ";break;
				//					case 2:control =" - ";break;
				//					case 3:control =" * ";break;
				//					case 4:control =" / ";break;
				//					default:
				//						break;
				//				}
				//				if(s.IndexOf(control) >0) break;		
				//			}
				//			pos = s.IndexOf(control);
				for(i=0;i<s.Length;i++)
				{
					try
					{
						if((s[i]== '+' || s[i]=='-' || s[i]=='*' || s[i]=='/' ) && s[i+1]==' ' && s[i-1]==' ')
						{
							break;
						}
					}
					catch{}
				}
				pos = i;
				if(pos>= s.Length) return s;
				if(pos<=0) return s;

				string a,b,c="";
				string condition ="";
				string rtn ="";
				a = s.Substring(0,pos);
				b = s.Substring(pos+2);
				condition = s[i].ToString();
				//			for(int k =1;k<5;k++)
				//			{
				//				switch(k)
				//				{
				//					case 1:control =" + ";break;
				//					case 2:control =" - ";break;
				//					case 3:control =" * ";break;
				//					case 4:control =" / ";break;
				//					default:
				//						break;
				//				}
				//				pos =b.IndexOf(control);
				//				if( pos>0) break;		
				//			}
				for(i=0;i<b.Length;i++)
				{
					try
					{
						if((b[i]=='+' || b[i]=='-' || b[i]=='*' || b[i]=='/' ) && b[i+1]==' ' &&  b[i-1]==' ')
						{
							break;
						}
					}
					catch{}
				}
				pos = i;
				if(pos>0 && pos < b.Length) 
				{
					c = b.Substring(pos);
					b = b.Substring(0,pos);
				}
				string type ="s";
				try
				{
					a = System.Convert.ToDateTime(a).ToString();
					type ="d";
				}
				catch{}
				try
				{
					if(type =="d")
					{
						switch(condition)
						{
							case "+":
								rtn = System.Convert.ToDateTime(a).AddDays(System.Convert.ToDouble(b)).ToString();
								break;
							case "-":
								TimeSpan t = new TimeSpan(System.Convert.ToDateTime(a).Ticks -System.Convert.ToDateTime(b).Ticks);
								rtn = (t.Days *24 +t.Hours).ToString();
								break;
							case "*":
								
								break;
							case "/":
							
								break;
						}
					}
					else
					{
						switch(condition)
						{
							case "+":
								rtn = (System.Convert.ToDouble(a) + System.Convert.ToDouble(b)).ToString();
								break;
							case "-":
							
								rtn =(System.Convert.ToDouble(a) - System.Convert.ToDouble(b)).ToString();
								break;
							case "*":
								rtn = (System.Convert.ToDouble(a) * System.Convert.ToDouble(b)).ToString();
								break;
							case "/":
								rtn = (System.Convert.ToDouble(a) / System.Convert.ToDouble(b)).ToString();
								break;
						}
					}
				}
				catch
				{
					return rtn;
				}
				try
				{
					if(pos>0) rtn = f_cal(rtn +" "+ c);
					return rtn;
				}
				catch{return rtn;}
			}
			catch{return s;}
		}
		
		/// <summary>
		/// 条件判断
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public bool _condition(string s)
		{
			try
			{
				string a,b,control ="";
				int pos =-1;
				for(int i=1;i<8;i++)
				{
					switch(i)
					{
						case 1:
							control ="<>";
							break;
						case 2:
							control ="><";
							break;
						case 3:
							control = "<=";
							break;
						case 4:
							control = ">=";
							break;
						case 5:
							control = ">";
							break;
						case 6:
							control = "<";
							break;
						case 7:
							control = "=";
							break;
					}
					pos  = s.IndexOf(control);
					if(pos >0) break;
				}
				if(pos<=0) return true;
				a = s.Substring(0 ,pos -1);
				b = s.Substring(pos + control.Length);
				try
				{
					a =f_cal(a);
				}
				catch{}
				try
				{
					b =f_cal(b);
				}
				catch{}
				a = a.Trim();
				b = b.Trim();
				s = a+" "+control +" "+b;
				
				string condition,last,first;
				//			s=s.TrimStart();
				//			j=s.IndexOf(" ");
				//			if(j<0) return false;
				//			first=s.Substring(0,j);
				//			s=s.Substring(j+1);
				//			j=s.IndexOf(" ");
				//			if(j<0) return false;
				//			condition=s.Substring(0,j);
				//			s=s.Substring(j+1);
				//			j=s.IndexOf(" ");
				//			if(j<0) return false;
				//			last=s.Substring(j+1);
				first = a;
				last = b;
				condition = control;
				switch(condition.Trim())
				{
					case "=":
						if(first.Trim()==last.Trim())
							return true;
						else
							return false;
					case ">":
						if(double.Parse(first)>double.Parse(last))
							return true;
						else
							return false;
					case "<":
						if(double.Parse(first)<double.Parse(last))
							return true;
						else
							return false;
					case ">=":
						if(double.Parse(first)>=double.Parse(last))
							return true;
						else
							return false;
					case "<=":
						if(double.Parse(first)<=double.Parse(last))
							return true;
						else
							return false;

					case "<>":
						if(first!=last)
							return true;
						else
							return false;
					case "><":
						if(first!=last)
							return true;
						else
							return false;
					case "!=":
						if(first!=last)
							return true;
						else
							return false;
					default:
						return false;
				}
			}
			catch{return false;}
		}
		
	}
}
