using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// TransactionType 的摘要说明。
	/// 交易类型
	/// <br>Values 	 Description</br>
	///	<br>CG	Charge</br>
	///	<br>CD	Credit</br>
	///	<br>PY	Payment</br>
	///	<br>AJ	Adjustment</br>
	/// </summary>
	public class TransactionType:Neusoft.NFC.Object.NeuObject 
	{
		public TransactionType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public enum enuTransactionType
		{
			/// <summary>
			/// cash 现金
			/// </summary>
			CA=0,
			/// <summary>
			/// cheque 支票
			/// </summary>
			CH=1,
			
			/// <summary>
			/// 信用卡
			/// </summary>
			CD=2,
			/// <summary>
			/// debit借记卡
			/// </summary>
			DB=3,
//			/// <summary>
//			/// 转押金
//			/// </summary>
//			AJ=4,
			/// <summary>
			/// 汇票
			/// </summary>
			PO=4,
			/// <summary>
			/// 保险帐户
			/// </summary>
			PS=5,
//			/// <summary>
//			/// 免费
//			/// </summary>
//			FR=9
		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuTransactionType myID;
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
		public enuTransactionType GetIDFromName(string Name)
		{
			enuTransactionType c=new enuTransactionType();
			for(int i=0;i<100;i++)
			{
				c=(enuTransactionType)i;
				if(c.ToString()==Name) return c;
			}
			return (enuTransactionType)int.Parse(Name);
		}
		public new string Name
		{
			get
			{
				string strTransactionType;
				switch ((int)this.ID)
				{
					case 0:
						strTransactionType= "现金";
						break;
					case 1:
						strTransactionType= "支票";
						break;

					case 2:
						strTransactionType="信用卡";
						break;
					case 3:
						strTransactionType="借记卡";
						break;
					case 5:
						strTransactionType="保险帐户";
						break;
//					case 4:
//						strTransactionType="转押金";
//						break;
					case 4:
						strTransactionType="汇票";
						break;
//					case 8:
//						strTransactionType="扣保险帐户";
//						break;
//					case 9:
//						strTransactionType="免费";
//						break;
					default:
						strTransactionType="现金";
						break;
				}
				base.Name=strTransactionType;
				return	strTransactionType;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(TransactionType)</returns>
		public static System.Collections.ArrayList List()
		{
			TransactionType aTransactionType;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i=0;i<=5;i++)
			{
				aTransactionType=new TransactionType();
				aTransactionType.ID=(enuTransactionType)i;
				aTransactionType.Memo=i.ToString();
				alReturn.Add(aTransactionType);
			}
			return alReturn;
		}
	}
}
