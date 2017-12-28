using System;

namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// OpsTable 的摘要说明。
	/// </summary>
	public class OpsTable:neusoft.neuFC.Object.neuObject
	{
		public OpsTable()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}		

		///<summary>
		///输入码
		///</summary>
		public string Input_Code;
		///<summary>
		///所属科室(手术室)
		///</summary>
		public neusoft.HISFC.Object.Base.Department Dept = new neusoft.HISFC.Object.Base.Department();
		/// <summary>
		/// 手术间代码
		/// </summary>
		public string RoomID;
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
		///<summary>
		///备注
		///</summary>
		public string Remark;
		/// <summary>
		/// 操作员
		/// </summary>
		public neusoft.neuFC.Object.neuObject User = new neusoft.neuFC.Object.neuObject();

		public new OpsTable Clone()
		{
			OpsTable newOpsTable = new OpsTable();
			newOpsTable.ID = this.ID.ToString();
			newOpsTable.Name = this.Name;
			newOpsTable.Input_Code = this.Input_Code;
			newOpsTable.Dept = this.Dept.Clone();
			newOpsTable.RoomID=this.RoomID;
			newOpsTable.YNValid = this.YNValid;
			newOpsTable.Remark = this.Remark;
			newOpsTable.User = this.User.Clone();
			return newOpsTable;
		}
	}

	public class OpsRoom:neusoft.neuFC.Object.neuObject
	{
		public OpsRoom()
		{}
		///<summary>
		///输入码
		///</summary>
		public string Input_Code;
		///<summary>
		///所属科室(手术室)
		///</summary>
		public string DeptID;
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
		
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperCode;
		public DateTime OperDate=DateTime.MinValue;

		public new OpsRoom Clone()
		{
			OpsRoom newOpsRoom = new OpsRoom();
			newOpsRoom.ID = this.ID.ToString();
			newOpsRoom.Name = this.Name;
			newOpsRoom.Input_Code = this.Input_Code;
			newOpsRoom.DeptID = this.DeptID;
			newOpsRoom.YNValid = this.YNValid;
			newOpsRoom.OperCode = this.OperCode;
			newOpsRoom.OperDate=this.OperDate;
			return newOpsRoom;
		}
	}
}
