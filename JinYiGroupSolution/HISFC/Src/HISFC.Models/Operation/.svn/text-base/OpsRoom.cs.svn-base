using System;
using System.Collections.Generic;

namespace Neusoft.HISFC.Models.Operation
{
	/// <summary>
	/// [功能描述: 手术室实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class OpsRoom : Neusoft.FrameWork.Models.NeuObject
	{
		public OpsRoom()
		{}

        #region 字段
        private List<OpsTable> tables = new List<OpsTable>();
        #endregion

        #region 属性


		[Obsolete("InputCode",true)]
		public string Input_Code;

		private string inputCode = string.Empty;
		///<summary>
		///输入码
		///</summary>
		public string InputCode
		{
			get
			{
				return this.inputCode;
			}
			set
			{
				this.inputCode = value;
			}
		}
		
		private string deptID = string.Empty;
		///<summary>
		///所属科室(手术室)
		///</summary>
		public string DeptID
		{
			get
			{
				return this.deptID;
			}
			set
			{
				this.deptID = value;
			}
		}

		///<summary>
		///1有效/0无效
		///</summary>
		private bool isValid = true;
		[Obsolete("IsValid",true)]
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


		private string operCode = string.Empty;
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperCode
		{
			get
			{
				return this.operCode;
			}
			set
			{
				this.operCode = value;
			}
		}


		private DateTime operDate = DateTime.MinValue;
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OperDate
		{
			get
			{
				return this.operDate;
			}
			set
			{
				this.operDate = value;
			}
		}

        /// <summary>
        /// 所包含的手术台
        /// </summary>
        /// Robin   2007-01-16
        public List<OpsTable> Tables
        {
            get
            {
                return this.tables;
            }
        }
		#endregion

        /// <summary>
        /// 添加手术台
        /// </summary>
        /// <param name="table">手术台</param>
        /// Robin   2007-01-16
        public void AddTable(OpsTable table)
        {
            table.Room = this;
            this.tables.Add(table);            
        }
		public new OpsRoom Clone()
		{
			OpsRoom newOpsRoom = base.Clone() as OpsRoom;
			return newOpsRoom;
		}
	}
}
