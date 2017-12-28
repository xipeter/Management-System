using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Group<br></br>
	/// [功能描述: 组套类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Group : Spell 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Group()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量
		
		/// <summary>
		/// 使用范围 1门诊/2住院
		/// </summary>
		private ServiceTypes userType;

		/// <summary>
		/// 组套类别
		/// </summary>
		private GroupKinds kind;

		/// <summary>
		/// 科室信息
		/// </summary>
		private NeuObject dept = new NeuObject();

		/// <summary>
		/// 医生信息
		/// </summary>
		private NeuObject doctor = new NeuObject();

		/// <summary>
		/// 是否共享，1是，0否
		/// </summary>
		private bool isShared ;

		/// <summary>
		/// 是否已经释放资源 默认为false没有释放
		/// </summary>
		private bool alreadyDisposed = false;

        //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
        /// <summary>
        /// 父节点ID
        /// </summary>
        private string parentID;
		
		#endregion
		
		#region 属性

		/// <summary>
		/// 使用范围 1门诊/2住院
		/// </summary>
		public ServiceTypes UserType 
		{
			get
			{
				return this.userType; 
			}
			set
			{
				this.userType = value; 
			}
		}

		/// <summary>
		/// 组套类型,1.医师组套；2.科室组套
		/// </summary>
		public GroupKinds Kind
		{
			get
			{
				return this.kind; 
			}
			set
			{
				this.kind = value; 
			}
		}

		/// <summary>
		/// 科室信息
		/// </summary>
		public NeuObject Dept
		{
			get
			{
				return this.dept; 
			}
			set
			{
				this.dept = value; 
			}
		}

		/// <summary>
		/// 医生信息
		/// </summary>
		public NeuObject Doctor
		{
			get
			{
				return this.doctor; 
			}
			set
			{
				this.doctor = value; 
			}
		}

		/// <summary>
		/// 是否共享，1是，0否
		/// </summary>
		public bool IsShared
		{
			get
			{
				return this.isShared; 
			}
			set
			{
				this.isShared = value; 
			}
		}

        //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
        /// <summary>
        /// 父节点ID
        /// </summary>
        public string ParentID
        {
            get 
            { 
                return parentID; 
            }
            set 
            { 
                parentID = value;
            }
        }
		#endregion
		
		#region 方法
		
		#region 释放资源
		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing">是否释放 true是 false否</param>
		protected override void Dispose(bool isDisposing)
		{
			if (alreadyDisposed)
			{
				return;
			}

			if (this.dept != null)
			{
				this.dept.Dispose();
				this.dept = null;
			}
			if (this.doctor != null)
			{
				this.doctor.Dispose();
				this.doctor = null;
			}

			base.Dispose (isDisposing);

			alreadyDisposed = true;
		}
		#endregion
		
		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象副本</returns>
		public new Group Clone()
		{
			Group group = base.Clone() as Group;

			group.Dept = this.Dept.Clone();
			group.Doctor = this.Doctor.Clone();

			return group;
		}
		#endregion

		#endregion
	}

	    #region 枚举
	
	/// <summary>
	/// 组套类型
	/// </summary>
	public enum GroupKinds
	{
		/// <summary>
		/// 医生
		/// </summary>
		Doctor = 1,
		/// <summary>
		/// 科室
		/// </summary>
		Dept = 2,
		/// <summary>
		/// 全院
		/// </summary>
		All = 3,
		/// <summary>
		/// 费用
		/// </summary>
		Fee = 4
	}

	#endregion
}