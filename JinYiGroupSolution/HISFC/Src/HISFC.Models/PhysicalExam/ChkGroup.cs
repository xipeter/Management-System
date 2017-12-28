namespace Neusoft.HISFC.Object.PhysicalExam {


	/// <summary>
	/// Bank<br></br>
	/// [功能描述: 银行实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class ChkGroup : Neusoft.HISFC.Object.Fee.ComGroup
	{
		public ChkGroup()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}                       
//		COMB_NAME    VARCHAR2(40) Y                组套名称                       
//		OWN_RATE     NUMBER(10,2) Y                优惠比例          
//		PAY_RATE     NUMBER(10,2) Y                自付金额          
//		PUB_RATE     NUMBER(10,2) Y                公费金额          
//		ECO_RATE     NUMBER(10,2) Y                优惠金额          
//		VALID_STATE  VARCHAR2(1)  Y                停用标志   
		/// <summary>
		/// 自负比例
		/// </summary>
		public decimal OwnRate ; //
		/// <summary>
		/// 自付比例
		/// </summary>
		public decimal PayRate ; //
		/// <summary>
		/// 公费比例
		/// </summary>
		public decimal PubRate ;//
		/// <summary>
		///优惠比例 
		/// </summary>
		public decimal EcoRate ;//
		/// <summary>
		/// 是否共享 
		/// </summary>
		public string ISShare ;

		public new ChkGroup Clone()
		{
			ChkGroup obj = base.Clone() as ChkGroup;
			return obj;
		}
	}
}
