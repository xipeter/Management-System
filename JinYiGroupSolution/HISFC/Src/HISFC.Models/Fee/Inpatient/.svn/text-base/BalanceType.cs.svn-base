using System;

namespace Neusoft.HISFC.Object.Fee.Inpatient
{
	/// <summary>
	/// BalanceType结算类型。
	///  在院结算 I
	///  转科结算 R
	///  出院结算 O
	///  重结算 M
	///  结转结算 S
	/// </summary>
	public class BalanceType:Neusoft.NFC.Object.NeuObject
	{
		public BalanceType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public enum enuBalanceType
		{
			/// <summary>
			/// 中途结算 I
			/// </summary>
			I,
			/// <summary>
			/// 出院结算 O
			/// </summary>
			O,
			/// <summary>
			/// 直接结算
			/// </summary>
			D,
			/// <summary>
			/// 结转结算
			/// </summary>
			S
		};
		private enuBalanceType myID;
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
		public enuBalanceType GetIDFromName(string Name)
		{
			enuBalanceType c=new enuBalanceType();
			for(int i=0;i<100;i++)
			{
				c=(enuBalanceType)i;
				if(c.ToString()==Name) return c;
			}
			return (enuBalanceType)int.Parse(Name);
		}
		
		public new string Name
		{
			get
			{
				string strBalanceType;
				switch ((int)this.ID)
				{
					case 0:
						strBalanceType= "中途结算";
						break;
					case 1:
						strBalanceType="出院结算";
						break;
					case 2:
						strBalanceType="直接结算";
						break;
					case 3:
						strBalanceType = "结转结算";
						break;
					default:
						strBalanceType="中途结算";
						break;
				}
				base.Name=strBalanceType;
				return	strBalanceType;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(BalanceType)</returns>
		public System.Collections.ArrayList List()
		{
			BalanceType aBalanceType;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i=0;i<=4;i++)
			{
				aBalanceType=new BalanceType();
				aBalanceType.ID=(enuBalanceType)i;
				alReturn.Add(aBalanceType);
			}
			return alReturn;
		}
		public override string ToString()
		{
			return this.Name;
		}

		public new BalanceType Clone()
		{
			return base.Clone() as BalanceType;
		}

	}
}
