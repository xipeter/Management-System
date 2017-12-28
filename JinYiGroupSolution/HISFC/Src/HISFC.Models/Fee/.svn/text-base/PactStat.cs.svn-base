using System;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// PactStat 的摘要说明。
	/// id,name
	/// </summary>
    /// 
    [System.Serializable]
	public class PactStat :Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.ISpell
	{
		public PactStat()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		//拼音码
		private string spellCode ;
		//五笔
		private string wBCode;
		// 输入码
		private string userCode;
		// 顺序号 
		public int SortId;

		//有效性标识
		public string ValidState;

		//操作人代码
		public string Opercode;
		#region ISpell 成员

		public string SpellCode
		{
			get
			{
				return spellCode;
			}
			set
			{
				this.spellCode = value;
			}
		}

		public string WBCode
		{
			get
			{
				return this.wBCode;
			}
			set
			{
				this.wBCode = value;
			}
		}

		public string UserCode
		{
			get
			{
				return this.userCode;
			}
			set
			{
				this.userCode = value;
			}
		}

		#endregion
	}
}
