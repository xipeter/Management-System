namespace Neusoft.HISFC.Object.Base
{
	/// <summary>
	/// BedWeave<br></br>
	/// [功能描述: 床位实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class BedWeave : Neusoft.NFC.Object.NeuObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public BedWeave()
		{
		}


		#region 变量
		/// <summary>
		/// 枚举
		/// </summary>
		private BedAttribute myID; 

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		#endregion

		#region Enum
		/// <summary>
		/// 病床状态
		/// </summary>
		#endregion

		#region 属性

		/// <summary>
		/// 重载ID
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
				base.ID = this.myID.ToString();
			}
		}

		/// <summary>
		/// 返回编制中文
		/// </summary>
		public new string Name
		{
			get
			{
				string strBedWeave;
				switch ((int)this.ID)
				{
					case 0:
						strBedWeave= "编制内";
						break;
					case 1:
						strBedWeave="编制外";
						break;
					case 2:
						strBedWeave="加床";
						break;
					case 3:
						strBedWeave="家庭病床";
						break;
					default:
						strBedWeave="编制内";
						break;
				}
				base.Name=strBedWeave;
				return	strBedWeave;
			}
		}

		#endregion

		#region 方法

		#region 释放资源

		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing"></param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}
		#endregion

		#region 克隆
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>Bed类实例</returns>
		public new BedWeave Clone()
		{
			return base.Clone() as BedWeave;
		}
		#endregion


		/// <summary>
		/// 根据名称得到ID
		/// </summary>
		/// <param name="Name">名称</param>
		/// <returns>ID</returns>
		public BedAttribute GetIDFromName(string Name)
		{
			BedAttribute c=new BedAttribute();
			for(int i = 0;i < 100 ;i++)
			{
				c=(BedAttribute)i;
				if(c.ToString()==Name) return c;
			}
			return (BedAttribute)int.Parse(Name);
		}

		/// <summary>
		/// 获得编制类型全部列表
		/// </summary>
		/// <returns>ArrayList(BedWeave)</returns>
		public static System.Collections.ArrayList List()
		{
			BedWeave aBedWeave;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i = 0;i <=3 ;i++)
			{
				aBedWeave = new BedWeave();
				aBedWeave.ID = (BedAttribute)i;
				aBedWeave.Memo =i.ToString();
				alReturn.Add(aBedWeave);
			}
			return alReturn;
		}
		#endregion

		

	}


	public enum BedAttribute {

		/// <summary>
		/// 编制内
		/// </summary>
		I,
		/// <summary>
		/// 编制外
		/// </summary>
		O,
		/// <summary>
		/// 加床
		/// </summary>
		A,
		/// <summary>
		/// 家庭病床
		/// </summary>
		F
	}	

}
