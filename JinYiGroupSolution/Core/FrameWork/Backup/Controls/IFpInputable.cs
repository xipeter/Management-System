using System;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// IFpInputable 的摘要说明。
	/// for ucFP的输入控件接口
	/// </summary>
	public interface IFpInputable
	{
		/// <summary>
		/// 下一个
		/// </summary>
		void MoveNext();
		/// <summary>
		/// 上一个
		/// </summary>
		void MovePrevious();
		/// <summary>
		/// 下页
		/// </summary>
		void NextPage();
		/// <summary>
		/// 上页
		/// </summary>
		void PreviousPage();

		/// <summary>
		/// 获得第几行
		/// </summary>
		/// <param name="row"></param>
		object GetRow(int row);
		
		/// <summary>
		/// 过滤
		/// </summary>
		/// <param name="filter"></param>
		void Filter(string filter);
		
		/// <summary>
		/// 切换输入法
		/// </summary>
		void ChangeInput();
		
		/// <summary>
		/// 获得当前项目
		/// </summary>
		/// <returns></returns>
		object GetSelectedItem();

		/// <summary>
		/// 选择项目事件
		/// </summary>
		event System.EventHandler SelectedItem;
	}
}
