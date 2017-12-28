using System;
//using Neusoft.NFC;
using Neusoft.HISFC;
using System.Collections;


namespace Neusoft.HISFC.Models.Operation 
{

	/// <summary>
	/// 手术项目信息类 Written By liling
	/// </summary>
    [Serializable]
    public class OperationInfo : Neusoft.FrameWork.Models.NeuObject
	{
		public OperationInfo()
		{
			
		}

		private Neusoft.HISFC.Models.Base.Item operationItem;

		///<summary>
		///收费比例
		///</summary>
		private decimal feeRate = 1;
		public decimal FeeRate
		{
			get
			{
				return this.feeRate;
			}
			set
			{
				this.feeRate = value;
			}
		}

		///<summary>
		///数量
		///</summary>
		private int qty = 0;
		public int Qty
		{
			get
			{
				return this.qty;
			}
			set
			{
				this.qty = value;
			}
		}

		///<summary>
		///单位
		///</summary>
		private string stockUnit = string.Empty;

#region 属性
        ///<summary>
        ///基本手术项目
        ///</summary>
        public Neusoft.HISFC.Models.Base.Item OperationItem
        {
            get
            {
                if (this.operationItem == null)
                {
                    this.operationItem = new Neusoft.HISFC.Models.Base.Item();
                }

                return this.operationItem;
            }

            set
            {
                this.operationItem = value;
            }
        }

		public string StockUnit
		{
			get
			{
				return this.stockUnit;
			}
			set
			{
				this.stockUnit = value;
			}
		}
		///<summary>
		///手术规模
		///</summary>
		public Neusoft.FrameWork.Models.NeuObject OperateType = new Neusoft.FrameWork.Models.NeuObject();
		
		///<summary>
		///切口类型
		///</summary>
		public Neusoft.FrameWork.Models.NeuObject InciType = new Neusoft.FrameWork.Models.NeuObject();

		///<summary>
		///手术部位
		///</summary>
		public Neusoft.FrameWork.Models.NeuObject OpePos = new Neusoft.FrameWork.Models.NeuObject();
		///<summary>
		///备注
		///</summary>
		private string remark = string.Empty;
		public string Remark
		{
			get
			{
				return this.remark;
			}
			set
			{
				this.remark = value;
			}
		}

		///<summary>
		///主手术标志 1是/0否
		///</summary>
		private bool mainFlag;

		[Obsolete("改为IsMainFlag",true)]
		public bool bMainFlag
		{
			get
			{
				return this.mainFlag;
			}
			set
			{
				this.mainFlag = value;
			}
		}

		/// <summary>
		/// 主手术标志
		/// </summary>
		public bool IsMainFlag
		{
			get
			{
				return this.mainFlag;
			}
			set
			{
				this.mainFlag = value;
			}
		}
		///<summary>
		///1有效/0无效
		///</summary>
		private bool isValid = true;
		[Obsolete("改为IsValid",true)]
		public bool bValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
		}

		/// <summary>
		/// 是否有效
		/// </summary>
		public bool IsValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
        }
#endregion
        public new OperationInfo Clone()
		{
			OperationInfo newOpsInfo = base.Clone() as OperationInfo;
            newOpsInfo.operationItem = this.operationItem.Clone();
			newOpsInfo.OperateType = this.OperateType.Clone();
			newOpsInfo.InciType = this.InciType.Clone();
			newOpsInfo.OpePos = this.OpePos.Clone();
			return newOpsInfo;
		}
	}
}
