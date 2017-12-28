using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Operation 
{
	/// <summary>
	/// [功能描述: 手术台实体]<br></br>
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
    public class OpsTable : Neusoft.FrameWork.Models.NeuObject
	{
#region 构造函数
		public OpsTable()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}		

		public OpsTable(Department dept)
		{
			this.dept = dept;
		}

		public OpsTable(NeuObject user)
		{
			this.user = user;
		}

		public OpsTable(Department dept, NeuObject user)
		{
			this.dept = dept;
			this.user = user;
		}
#endregion

#region 字段
        private OpsRoom room;
        private string okInfo = string.Empty;
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


		private Neusoft.HISFC.Models.Base.Department dept;
		///<summary>
		///所属科室(手术室)
		///</summary>
		public Neusoft.HISFC.Models.Base.Department Dept
		{
			get
			{
				if (this.dept == null) 
				{
					this.dept = new Neusoft.HISFC.Models.Base.Department();
				}
				return this.dept;
			}
			set
			{
				this.dept = value;
			}
		}


		private Neusoft.FrameWork.Models.NeuObject user;
		/// <summary>
		/// 操作员
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject User
		{
			get
			{
				if (this.user == null) 
				{
					this.user = new Neusoft.FrameWork.Models.NeuObject();
				}
				return this.user;
			}
			set
			{
				this.user = value;
			}
		}


		private string roomID = string.Empty;
		/// <summary>
		/// 手术室代码
		/// </summary>
		public string RoomID
		{
			get
			{
				return this.roomID;
			}
			set
			{
				this.roomID = value;
			}
		}

        /// <summary>
        /// 所在手术室
        /// </summary>
        /// Robin   2007-01-16
        public OpsRoom Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
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


		private string remark = string.Empty;
		///<summary>
		///备注
		///</summary>
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

        /// <summary>
        /// 不合法信息
        /// </summary>
        public string InvalidInfo
        {         
           get
            {
                return this.okInfo;
            }
            set
            {
                this.okInfo = value;
            }
        }
#endregion

#region 方法
        /// <summary>
        /// 是否合法
        /// </summary>
        /// <returns></returns>
        public bool IsOK()
        {
            if(this.Name.Length==0)
            {
                this.okInfo = "行手术台名称为空";
                return false;
            }
  
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.Name, 20) == false)
            {
                this.okInfo = "手术台名称已超过10个汉字!";
                return false;
            }
                        
            if (this.inputCode == "")
            {
                this.okInfo =  "行手术台助记码为空";
                return false;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.inputCode, 8) == false)
            {
                this.okInfo = "助记码长度已超过8个字符!";
                return false;
            }
            
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.Memo, 50) == false)
            {
                this.okInfo = "备注长度已超过25个汉字!";
                return false;
            }

            return true;
        }

		public new OpsTable Clone()
		{
			OpsTable newOpsTable = base.Clone() as OpsTable;
			newOpsTable.Dept = this.Dept.Clone();
			newOpsTable.User = this.User.Clone();
			return newOpsTable;
		}
#endregion
		
	}

	
}
