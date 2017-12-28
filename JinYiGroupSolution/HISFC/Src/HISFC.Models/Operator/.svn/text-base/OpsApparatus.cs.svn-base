using System;

namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// OpsApparatus 的摘要说明。
	/// 手术仪器设备实体类
	/// </summary>
	public class OpsApparatus : neusoft.neuFC.Object.neuObject,neusoft.HISFC.Object.Base.ISpellCode
	{
		public OpsApparatus()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 拼音码
		/// </summary>
		private string mySpellCode = "";
		/// <summary>
		/// 输入码
		/// </summary>
		private string myUserCode = "";
		/// <summary>
		/// 品牌
		/// </summary>
		public string TradeMark = "";
		/// <summary>
		/// 产地
		/// </summary>
		public string AppaSource = "";
		/// <summary>
		/// 型号
		/// </summary>
		public string AppaModel = "";
		/// <summary>
		/// 购入日期
		/// </summary>
		public DateTime BuyDate = DateTime.MinValue;
		/// <summary>
		/// 价格
		/// </summary>
		public decimal AppaPrice = 0;
		/// <summary>
		/// 单位
		/// </summary>
		public string AppaUnit = "";
		/// <summary>
		/// 1在用/0未用
		/// </summary>
		private string Status = "1";
		public bool bStatus
		{
			get
			{
				if(Status == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					Status = "1";
				else
					Status = "0";
			}
		}
		/// <summary>
		/// 经销商
		/// </summary>
		public string Saler = "";
		/// <summary>
		/// 生产厂家
		/// </summary>
		public string Producer = "";
		/// <summary>
		/// 1贵重2普通
		/// </summary>
		public string AppaKind = "";
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark = "";
		/// <summary>
		/// 操作员
		/// </summary>
		public neusoft.HISFC.Object.RADT.Person User = new neusoft.HISFC.Object.RADT.Person();
		#region ISpellCode 成员
		/// <summary>
		/// 拼音码
		/// </summary>
		public string Spell_Code
		{
			get
			{
				// TODO:  添加 OpsApparatus.Spell_Code getter 实现
				return this.mySpellCode;
			}
			set
			{
				this.mySpellCode = value;
			}
		}

		public string WB_Code
		{
			get
			{
				// TODO:  添加 OpsApparatus.WB_Code getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 OpsApparatus.WB_Code setter 实现
			}
		}
		/// <summary>
		/// 输入码
		/// </summary>
		public string User_Code
		{
			get
			{
				// TODO:  添加 OpsApparatus.User_Code getter 实现
				return this.myUserCode;
			}
			set
			{
				this.myUserCode = value;
			}
		}

		#endregion

		public new OpsApparatus Clone()
		{
			OpsApparatus myApparatus = new OpsApparatus();
			myApparatus.ID = this.ID.ToString();
			myApparatus.Name = this.Name;
			myApparatus.mySpellCode = this.mySpellCode;
			myApparatus.myUserCode = this.myUserCode;
			myApparatus.TradeMark = this.TradeMark;
			myApparatus.AppaSource = this.AppaSource;
			myApparatus.AppaModel = this.AppaModel;
			myApparatus.BuyDate = this.BuyDate;
			myApparatus.AppaPrice = this.AppaPrice;
			myApparatus.AppaUnit = this.AppaUnit;
			myApparatus.Status = this.Status;
			myApparatus.Saler = this.Saler;
			myApparatus.Producer = this.Producer;
			myApparatus.AppaKind = this.AppaKind;
			myApparatus.Remark = this.Remark;
			myApparatus.User = this.User.Clone();
			return myApparatus;
		}
	}
}
