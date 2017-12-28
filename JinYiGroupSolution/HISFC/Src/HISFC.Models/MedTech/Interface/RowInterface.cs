namespace Neusoft.HISFC.Object.MedTech.Interface 
{
    /// <summary>
    /// [功能描述: 记录操作接口]<br></br>
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
	public interface RowInterface 
	{
		/// <summary>
		/// 记录的总个数
		/// </summary>
		int RowCount 
		{
			get;
			set;
		}

		/// <summary>
		/// 获取当前的记录行号
		/// </summary>
		/// <returns>当前记录的行号</returns>
		int GetRowNumber( );

		/// <summary>
		/// 选择全部
		/// </summary>
		void SelectAll( );

		/// <summary>
		/// 增加一条记录
		/// </summary>
		/// <returns>－1失败,大于等于0成功</returns>
		int InsertRow( );

		/// <summary>
		/// 删除选择的记录
		/// </summary>
		/// <returns>－1失败,大于等于0成功</returns>
		int DeleteRow( );

		/// <summary>
		/// 获取当前行记录的承载对象
		/// </summary>
		/// <param name="getObject">获取的承载对象</param>
		/// <param name="row">指定的行号</param>
		/// <returns>－1失败,大于等于0成功</returns>
		int GetObjectFromRow( ref Neusoft.NFC.Object.NeuObject getObject, int row );
		
	}
}
