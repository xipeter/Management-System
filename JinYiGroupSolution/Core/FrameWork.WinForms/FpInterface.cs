using System;
using System.Drawing;
using System.Collections;
namespace Neusoft.NFC.Interface
{
	/// <summary>
	/// FpInterface 的摘要说明。
	/// </summary>
	public interface FpInterface
	{
		/// <summary>
		/// 初始化
		/// </summary>
		void init();
		/// <summary>
		/// 重新加载
		/// </summary>
		void Refresh();
		/// <summary>
		/// 设置数据
		/// </summary>
		System.Data.DataSet fpDateSet
		{
			get;
			set;
		}
		#region Color
		Color fpBackColor
		{
			get;
			set;
		}
		Color fpForeColor
		{
			get;
			set;
		}
		Color fpHeaderBackColor
		{
			get;
			set;
		}
		Color fpHeaderForeColor
		{
			get;
			set;
		}
		Color fpColumnBackColor
		{
			get;
			set;
		}
		Color fpColumnForeColor
		{
			get;
			set;
		}
		Color fpChildHeader1BackColor
		{
			get;
			set;
		}
		Color fpChildHeader1ForeColor
		{
			get;
			set;
		}
		Color fpChildColumn1BackColor
		{
			get;
			set;
		}
		Color fpChildColumn1ForeColor
		{
			get;
			set;
		}
		Color fpChildHeader2BackColor
		{
			get;
			set;
		}
		Color fpChildHeader2ForeColor
		{
			get;
			set;
		}
		Color fpChildColumn2BackColor
		{
			get;
			set;
		}
		Color fpChildColumn2ForeColor
		{
			get;
			set;
		}

		#endregion
		#region visible
		bool fpChildHeaderVisible
		{
			get;
			set;
		}
		bool fpChildColumnVisible
		{
			get;
			set;
		}
		bool fpHeaderVisible
		{
			get;
			set;
		}
		bool fpColumnVisible
		{
			get;
			set;
		}
		bool fpIDColumnVisible
		{
			get;
			set;
		}
		#endregion
		#region FPSet
		int DefaultColumnWidth
		{
			get;
			set;
		}
		int DefaultRowHeight
		{
			get;
			set;
		}
		bool DataAutoSizeColumns
		{
			get;
			set;
		}
		ArrayList ColumnsProperty
		{
			get;
			set;
		}
		#endregion
	}
}
