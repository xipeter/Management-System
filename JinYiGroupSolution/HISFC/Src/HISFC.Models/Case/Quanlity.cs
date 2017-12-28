using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// 病案实体类:质量监控
	/// </summary>
	public class Quanlity
	{
		public Quanlity()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 门急_入院符合定义 string Varchar(1)
		/// <summary>
		/// 门急_入院符合 string Varchar(1)
		/// </summary>
		public string cePi
		{
			set
			{
				if( this.ExLength( value, 1, "门急_入院符合" ) )
				{
					cePi = value;
				}
			}
		}
		#endregion
		#region 入出_院符合定义 string Varchar(1)
		/// <summary>
		/// 入出_院符合 string Varchar(1)
		/// </summary>
		public string piPo
		{
			set
			{
				if( this.ExLength( value, 1, "入出_院符合" ) )
				{
					piPo = value;
				}
			}
		}
		#endregion
		#region 术前_后符合定义 string Varchar(1)
		/// <summary>
		/// 术前_后符合 string Varchar(1)
		/// </summary>
		public string opbOpa
		{
			set
			{
				if( this.ExLength( value, 1, "术前_后符合" ) )
				{
					opbOpa = value;
				}
			}
		}
		#endregion
		#region 临床_X光符合定义 string Varchar(1)
		/// <summary>
		/// 临床_X光符合 string Varchar(1)
		/// </summary>
		public string clX
		{
			set
			{
				if( this.ExLength( value, 1, "临床_X光符合" ) )
				{
					clX = value;
				}
			}
		}
		#endregion
		#region 临床_CT符合定义 string Varchar(1)
		/// <summary>
		/// 临床_CT符合 string Varchar(1)
		/// </summary>
		public string ctCT
		{
			set
			{
				if( this.ExLength( value, 1, "临床_CT符合" ) )
				{
					ctCT = value;
				}
			}
		}
		#endregion
		#region 临床_MRI符合定义 string Varchar(1)
		/// <summary>
		/// 临床_MRI符合 string Varchar(1)
		/// </summary>
		public string clMRI
		{
			set
			{
				if( this.ExLength( value, 1, "临床_MRI符合" ) )
				{
					clMRI = value;
				}
			}
		}
		#endregion
		#region 临床_病理符合定义 string Varchar(1)
		/// <summary>
		/// 临床_病理符合 string Varchar(1)
		/// </summary>
		public string clPA
		{
			set
			{
				if( this.ExLength( value, 1, "临床_病理符合" ) )
				{
					clPA = value;
				}
			}
		}
		#endregion
		#region 放射_病理符合定义 string Varchar(1)
		/// <summary>
		/// 放射_病理符合 string Varchar(1)
		/// </summary>
		public string fsBL
		{
			set
			{
				if( this.ExLength( value, 1, "放射_病理符合" ) )
				{
					fsBL = value;
				}
			}
		}
		#endregion

		private bool ExLength( System.Object Obj, int length, string exMessage )
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

		public new Quanlity Clone()
		{
			Quanlity QuanlityClone = base.MemberwiseClone() as Quanlity;

			return QuanlityClone;
		} 

	}
}
