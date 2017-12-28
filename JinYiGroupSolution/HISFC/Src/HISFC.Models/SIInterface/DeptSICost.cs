using System;


namespace Neusoft.HISFC.Models.SIInterface {


	/// <summary>
	/// DeptSICost 的摘要说明。
	/// </summary>
    [Serializable]
    public class DeptSICost : Neusoft.FrameWork.Models.NeuObject
	{
		public DeptSICost()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private string month;
		private decimal alertMoney;
		private string validStateId;
		private string validStateName;
		private int sortId;
		private Neusoft.FrameWork.Models.NeuObject operInfo = new Neusoft.FrameWork.Models.NeuObject();
		private DateTime operDate;
		private Neusoft.HISFC.Models.Base.Spell spellCode = new Neusoft.HISFC.Models.Base.Spell();
		/// <summary>
		/// 月份
		/// </summary>
		public string Month
		{
			set{month = value;}
			get{return month;}
		}
		/// <summary>
		/// 警戒线
		/// </summary>
		public decimal AlertMoney
		{
			set{alertMoney = value;}
			get{return alertMoney;}
		}
		/// <summary>
		/// 有效性名称
		/// </summary>
		public string ValidStateName
		{
			get{return validStateName;}
			set
			{
				validStateName = value;
				switch(validStateName)
				{
					case "在用":
						validStateId = "0";
						break;
					case "停用":
						validStateId = "1";
						break;
					case "废弃":
						validStateId = "2";
						break;
					default:
						validStateId = "0";
						break;
				}
			}
		}

		/// <summary>
		/// 有效性Id
		/// </summary>
		public string ValidStateId
		{
			set
			{
				validStateId = value;
				switch(validStateId)
				{
					case "0":
						validStateName = "在用";
						break;
					case "1":
						validStateName = "停用";
						break;
					case "2":
						validStateName = "废弃";
						break;
					default:
						validStateName = "在用";
						break;
				}
			}
			get{return validStateId;}
		}
		/// <summary>
		/// 序号
		/// </summary>
		public int SortId
		{
			set{sortId = value;}
			get{return sortId;}
		}
		/// <summary>
		/// 操作员信息
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject OperInfo
		{
			set{operInfo = value;}
			get{return operInfo;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			set{operDate = value;}
			get{return operDate;}
		}

		/// <summary>
		/// 输入码信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.Spell SpellCode {
			set{spellCode = value;}
			get{return spellCode;}
		}

		/// <summary>
		/// 克隆实体
		/// </summary>
		/// <returns></returns>
		public new DeptSICost Clone()
		{
			DeptSICost obj = base.Clone() as DeptSICost;
			obj.operInfo = this.operInfo.Clone();
			obj.spellCode = this.spellCode.Clone();

			return obj;
		}
	}
}
