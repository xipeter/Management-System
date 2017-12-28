using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// [功能描述: 家属关系实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2006-9-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [System.Serializable]
    public class Kin:NeuObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Kin()
		{
		}

		#region 变量

		/// <summary>
		/// 关系
		/// </summary>
		private NeuObject  relation=new NeuObject();

		/// <summary>
		/// 联系人电话 
		/// </summary>
		private string relationPhone;

		/// <summary>
		/// 联系人地址 
		/// </summary>
		private string relationAddress;

		/// <summary>
		/// 联系人关系
		/// </summary>
		private string relationLink ;

        //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
        /// <summary>
        /// 联系人地址门牌号
        /// </summary>
        private string relationDoorNo = string.Empty;

		#endregion

		#region 属性

		/// <summary>
		/// 关系
		/// </summary>
		public NeuObject  Relation
		{
			get
			{
				return this.relation;
			}
			set
			{
				this.relation = value;
			}
		}

		/// <summary>
		/// 联系人电话 
		/// </summary>
		public string RelationPhone
		{
			get
			{
				return this.relationPhone;
			}
			set
			{
				this.relationPhone = value;
			}
		}

		/// <summary>
		/// 联系人地址 
		/// </summary>
		public string RelationAddress
		{
			get
			{
				return this.relationAddress;
			}
			set
			{
				this.relationAddress = value;
			}
		}

		/// <summary>
		/// 联系人关系
		/// </summary>
		public string RelationLink
		{
			get
			{
				return this.relationLink;
			}
			set
			{
				this.relationLink = value;
			}
		}


        //{9543865B-629A-4353-A45A-99D3FC1136BB}
        /// <summary>
        /// 联系人地址门牌号
        /// </summary>
        public string RelationDoorNo
        {
            get
            {
                return relationDoorNo;
            }
            set
            {
                relationDoorNo = value;
            }
        }

 

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Kin Clone()
		{
			Kin kin=base.Clone() as Kin;
			kin.Relation=this.Relation.Clone();
			return kin;
		}
		
		#endregion
	}
}
