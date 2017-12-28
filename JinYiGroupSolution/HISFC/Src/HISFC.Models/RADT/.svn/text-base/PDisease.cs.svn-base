using System;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// PDisease <br></br>
	/// [功能描述: 患者疾病实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2004-05]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-09-11'
	///		修改目的='版本整合'
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class PDisease : Neusoft.FrameWork.Models.NeuObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PDisease()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 是否有重大疾病
		/// </summary>
		private bool isMainDisease;

		/// <summary>
		/// 是否过敏
		/// </summary>
		private bool isAlleray;

		/// <summary>
		/// 护理信息
		/// </summary>
		private Neusoft.HISFC.Models.RADT.Tend tend=new Tend();

		/// <summary>
        /// 过敏信息{B005D949-B8CE-4d7f-98FF-4156AEE71CCC}
		/// </summary>
        //private Neusoft.HISFC.Models.Medical.Allergy alleray = new Neusoft.HISFC.Models.Medical.Allergy();

		#endregion

		#region 属性

		/// <summary>
		/// 是否有重大疾病
		/// </summary>
		public bool IsMainDisease
		{
			get
			{
				return this.isMainDisease;
			}
			set
			{
				this.isMainDisease = value;
			}
		}


		/// <summary>
		/// 是否过敏
		/// </summary>
		public bool IsAlleray
		{
			get
			{
				return this.isAlleray;
			}
			set
			{
				this.isAlleray = value;
			}
		}


		/// <summary>
		/// 护理信息
		/// </summary>
		public Neusoft.HISFC.Models.RADT.Tend Tend
		{
			get
			{
				return this.tend;
			}
			set
			{
				this.tend = value;
			}
		}


		/// <summary>
        /// 过敏信息{B005D949-B8CE-4d7f-98FF-4156AEE71CCC}
		/// </summary>
        //public Neusoft.HISFC.Models.Medical.Allergy Alleray
        //{
        //    get
        //    {
        //        return this.alleray;
        //    }
        //    set
        //    {
        //        this.alleray = value;
        //    }
        //}

		#endregion

		#region 过期

		/// <summary>
		/// 是否有重大疾病
		/// </summary>
		[Obsolete("已经过期，更改为IsMainDisease",true)]
		public bool IsMainDesease;

		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new PDisease Clone()
		{
			PDisease pDisease = base.Clone() as PDisease;

			return pDisease;
		}

		#endregion
	}
}