namespace Neusoft.HISFC.Models.MedTech.Management.Relation 
{

    /// <summary>
    /// [功能描述: 设备与操作员的关系]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006-12-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    /// 
    [System.Serializable]
	public class MachineOperRelation : Neusoft.HISFC.Models.Base.Spell
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public MachineOperRelation( ) 
		{
		}

		#region 变量

		/// <summary>
		/// 操作员
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper;

		#endregion

		#region 属性

		/// <summary>
		/// 操作员
		/// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper 
		{
			get 
			{
				return this.oper;
			}
			set 
			{
				this.oper = value;
			}
		}
		#endregion
		
	}
}
