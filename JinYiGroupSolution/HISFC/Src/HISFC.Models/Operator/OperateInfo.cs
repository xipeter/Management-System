using System;
using neusoft.neuFC;
using neusoft.HISFC;
using System.Collections;
namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// 手术项目信息类 Written By liling 
	/// </summary>
	public class OperateInfo:neusoft.neuFC.Object.neuObject
	{
		public OperateInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		///<summary>
		///项目基本
		///</summary>
		public neusoft.HISFC.Object.Base.Item OperateItem = new neusoft.HISFC.Object.Base.Item();

		///<summary>
		///收费比例
		///</summary>
		public decimal FeeRate = 1;

		///<summary>
		///数量
		///</summary>
		public int Qty = 0;

		///<summary>
		///单位
		///</summary>
		public string StockUnit = "";
		///<summary>
		///手术规模
		///</summary>
		public neusoft.neuFC.Object.neuObject OperateType = new neusoft.neuFC.Object.neuObject();
		
		///<summary>
		///切口类型
		///</summary>
		public neusoft.neuFC.Object.neuObject InciType = new neusoft.neuFC.Object.neuObject();

		///<summary>
		///手术部位
		///</summary>
		public neusoft.neuFC.Object.neuObject OpePos = new neusoft.neuFC.Object.neuObject();
		///<summary>
		///备注
		///</summary>
		public string Remark = "";

		///<summary>
		///主手术标志 1是/0否
		///</summary>
		private string Main_Flag = "0";
		public bool bMainFlag
		{
			get
			{
				if(Main_Flag =="1")
					return true;
				else
					return false;
			}
			set
			{
				if(value ==true)
					Main_Flag = "1";
				else
					Main_Flag = "0";
			}
		}
		///<summary>
		///1有效/0无效
		///</summary>
		private string YNValid = "1";
		public bool bValid
		{
			get
			{
				if(YNValid =="1")
					return true;
				else
					return false;
			}
			set
			{
				if(value ==true)
					YNValid = "1";
				else
					YNValid = "0";
			}
		}
		public new OperateInfo Clone()
		{
			OperateInfo newOpsInfo = new OperateInfo();
			newOpsInfo.OperateItem = this.OperateItem.Clone();
			newOpsInfo.FeeRate = this.FeeRate;
			newOpsInfo.Qty = this.Qty;
			newOpsInfo.StockUnit = this.StockUnit;
			newOpsInfo.OperateType = this.OperateType.Clone();
			newOpsInfo.InciType = this.InciType.Clone();
			newOpsInfo.OpePos = this.OpePos.Clone();
			newOpsInfo.Remark = this.Remark;
			newOpsInfo.Main_Flag = this.Main_Flag;
			newOpsInfo.YNValid = this.YNValid;
			return newOpsInfo;
		}
	}
}
