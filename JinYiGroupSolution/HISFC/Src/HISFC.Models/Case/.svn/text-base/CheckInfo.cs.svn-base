using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// 病案检查化验类代码和相应次数。
	/// </summary>
	public class CheckInfo
	{
		public CheckInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

	#region 私有变量

		private CheckBaseInfo myCheckX = new CheckBaseInfo( "X光" );
		private CheckBaseInfo myCheckCT = new CheckBaseInfo( "CT" );
		private CheckBaseInfo myCheckMRI = new CheckBaseInfo( "MRI" );
		private CheckBaseInfo myCheckDSA = new CheckBaseInfo( "DSA" );
		private CheckBaseInfo myCheckPET = new CheckBaseInfo( "PET" );
		private CheckBaseInfo myCheckECT = new CheckBaseInfo( "ECT" );
		private CheckBaseInfo myCheckBL = new CheckBaseInfo( "病理" );

	#endregion
		
	#region 属性

		/// <summary>
		/// X光信息
		/// </summary>
		public CheckBaseInfo CheckX
		{
			get
            { 
                return myCheckX; 
            }
			set
            { 
                myCheckX = value; 
            }
		}

		/// <summary>
		/// CT信息
		/// </summary>
		public CheckBaseInfo CheckCT
		{
			get
            { 
                return myCheckCT; 
            }
			set
            { 
                myCheckCT = value; 
            }
		}

		/// <summary>
		/// MRI信息
		/// </summary>
		public CheckBaseInfo CheckMRI
		{
			get
            { 
                return myCheckMRI; 
            }
			set
            { 
                myCheckMRI = value; 
            }
		}

		/// <summary>
		/// DSA信息
		/// </summary>
		public CheckBaseInfo CheckDSA
		{
			get
            { 
                return myCheckDSA; 
            }
			set
            { 
                myCheckDSA = value; 
            }
		}

		/// <summary>
		/// PET信息
		/// </summary>
		public CheckBaseInfo CheckPET
		{
			get
            { 
                return myCheckPET; 
            }
			set
            { 
                myCheckPET = value; 
            }
		}

		/// <summary>
		/// ECT信息
		/// </summary>
		public CheckBaseInfo CheckECT
		{
			get
            { 
                return myCheckECT; 
            }
			set
            { 
                myCheckECT = value; 
            }
		}

		/// <summary>
		/// 病理信息
		/// </summary>
		public CheckBaseInfo CheckBL
		{
			get
            { 
                return myCheckBL; 
            }
			set
            { 
                myCheckBL = value; 
            }
		}

	#endregion

	#region 公有函数
        
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
		public new CheckInfo Clone()
		{
			CheckInfo CheckInfoClone = base.MemberwiseClone() as CheckInfo;
			
			CheckInfoClone.CheckBL = this.CheckBL.Clone();
			CheckInfoClone.CheckCT = this.CheckCT.Clone();
			CheckInfoClone.CheckDSA = this.CheckDSA.Clone();
			CheckInfoClone.CheckECT = this.CheckECT.Clone();
			CheckInfoClone.CheckMRI = this.CheckMRI.Clone();
			CheckInfoClone.CheckPET = this.CheckPET.Clone();
			CheckInfoClone.CheckX = this.CheckX.Clone();

			return CheckInfoClone;
		}

	#endregion

	}
}
