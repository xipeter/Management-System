using System.Collections;

namespace Neusoft.HISFC.Object.MedTech.Interface 
{
    /// <summary>
    /// [功能描述: UC控件的基本接口]<br></br>
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
	public interface UCInterface 
	{

		/// <summary>
		/// 接口错误信息属性
		/// </summary>
		Neusoft.NFC.Object.NeuObject Error
		{
			get;
			set;
		}

		/// <summary>
		/// 加载、初始化方法
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		/// <returns>－1失败,大于等于0成功</returns>
		int Load( Neusoft.NFC.Object.NeuObject interfaceParameter );

		/// <summary>
		/// 卸载、关闭方法
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		/// <returns>－1失败,大于等于0成功</returns>
		int Unload( Neusoft.NFC.Object.NeuObject interfaceParameter );

		/// <summary>
		/// 有效性、合法性校验方法
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		/// <returns>－1失败,大于等于0成功</returns>
		int Validity( Neusoft.NFC.Object.NeuObject interfaceParameter );

		/// <summary>
		/// 保存方法
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		/// <returns>－1失败,大于等于0成功</returns>
		int Save( Neusoft.NFC.Object.NeuObject interfaceParameter );

		/// <summary>
		/// 查询、统计方法
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		/// <param name="resultList">查询、统计的结果</param>
		/// <returns>－1失败,大于等于0成功</returns>
		int Query( Neusoft.NFC.Object.NeuObject interfaceParameter, ref ArrayList resultList );

		/// <summary>
		/// 打印方法
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		void Print( Neusoft.NFC.Object.NeuObject interfaceParameter );

		/// <summary>
		/// 排序方法
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		void Sort( Neusoft.NFC.Object.NeuObject interfaceParameter );

		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="interfaceParameter">参数</param>
		void Export( Neusoft.NFC.Object.NeuObject interfaceParameter );
	}
}
