using System;
using System.Collections;
namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// [功能描述: 血液类型实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
	[System.Obsolete("已经禁用 改为 EnumBloodType",true)]
	public class BloodType:Neusoft.NFC.Object.NeuObject
	{
		public BloodType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
/*
		public enum enuBloodType {

			/// <summary>
			/// 未知
			/// </summary>
			U = 0,
			/// <summary>
			///A 
			/// </summary>
			A=1,
			/// <summary>
			/// B
			/// </summary>
			B=2,
			/// <summary>
			/// AB
			/// </summary>
			AB=3,
			/// <summary>
			/// O
			/// </summary>
			O=4
		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private EnumBloodType myID;
		private bool bIsRH=false;
		/// <summary>
		/// 是否RH血型
		/// </summary>
		public bool RH
		{
			get
			{
				return this.bIsRH;
			}
			set
			{
				this.bIsRH=value;
			}
		}
		/// <summary>
		/// ABO血型
		/// </summary>
		public new System.Object ID
		{
			get
			{
				return this.myID;
			}
			set
			{
				try
				{
					this.myID=(this.GetIDFromName (value.ToString())); 
				}
				catch
				{}
				base.ID=this.myID.ToString();
				string s=this.Name;
			}
		}

		public EnumBloodType GetIDFromName(string Name)
		{
			EnumBloodType c=new EnumBloodType();
			for(int i=0;i<100;i++)
			{
				c=(EnumBloodType)i;
				if(c.ToString()==Name) return c;
			}
			return (Neusoft.HISFC.Object.RADT.EnumBloodType)int.Parse(Name);
		}
		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name
		{
			get
			{
				string strBloodType;
				string strRH="RH阴性";
				
				if(this.bIsRH)
					strRH="RH阳性";
				else
					strRH="RH阴性";

				switch ((int)this.ID)
				{
					case 1:
						strBloodType= "A型"+strRH;
						break;
					case 2:
						strBloodType="B型"+strRH;
						break;
					case 3:
						strBloodType="AB型"+strRH;
						break;
					case 4:
						strBloodType="O型"+strRH;
						break;
					 default:
						strBloodType="未知";
						break;

				}
				base.Name=strBloodType;
				return	strBloodType;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(BloodType)</returns>
		public static ArrayList List()
		{
			BloodType aBloodType;
			EnumBloodType e=new EnumBloodType();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aBloodType=new BloodType();
				aBloodType.ID=(EnumBloodType)i;
				aBloodType.Memo=i.ToString();
				alReturn.Add(aBloodType);
			}
			return alReturn;
		}
		public new BloodType Clone()
		{
			return base.Clone() as BloodType;
		}
		*/
	}
}
