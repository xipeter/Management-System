using System;


namespace Neusoft.HISFC.Models.Admin {

	/// <summary>
	/// 类名称<br></br>
	/// ID    常数类型编码
	/// Name  常数类型名称
	/// <Font color='#FF1111'>[功能描述: ]</Font><br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///		/>
	/// </summary>
    /// 
    [System.Serializable]
	public class ConstantGroup: Neusoft.FrameWork.Models.NeuObject 
	{
		private System.String myPargrpCode ;
		private System.String myCurgrpCode ;
		private System.String myControlName ;
		private System.String myControlNote ;

		/// <summary>
		/// 父级组别编码
		/// </summary>
		public System.String PargrpCode {
			get {
				return this.myPargrpCode;
			}
			set {
				this.myPargrpCode = value;
			}
		}


		/// <summary>
		/// 本级组别编码
		/// </summary>
		public System.String CurgrpCode {
			get {
				return this.myCurgrpCode;
			}
			set {
				this.myCurgrpCode = value;
			}
		}


		/// <summary>
		/// 控件名称
		/// </summary>
		public System.String ControlName {
			get {
				return this.myControlName;
			}
			set {
				this.myControlName = value;
			}
		}


		/// <summary>
		/// 控件注释
		/// </summary>
		public System.String ControlNote {
			get {
				return this.myControlNote;
			}
			set {
				this.myControlNote = value;
			}
		}


//		public new Neusoft.HISFC.Models.Power.SysMenu Clone() {
//			return (Neusoft.HISFC.Models.Power.SysMenu)this.MemberwiseClone();
//		}

	}
}