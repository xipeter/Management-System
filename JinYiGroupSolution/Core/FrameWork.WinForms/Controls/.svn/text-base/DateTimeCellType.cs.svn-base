using System;
using System.Windows.Forms.Design;

namespace Neusoft.FrameWork.WinForms.Controls 
{	
	/// <summary>
	/// DateTimeCellType 的摘要说明。
	/// 禁止双击控件时弹出日期选择控件
	/// </summary>
	public class DateTimeCellType:FarPoint.Win.Spread.CellType.DateTimeCellType 
	{
		
		/// <summary>
		/// ucEditor 的摘要说明。 屏蔽双击弹出日期选择控件
		/// </summary>
		private class ucEditor:FarPoint.Win.Spread.CellType.ISubEditor 
		{
			public ucEditor() 
			{
				//
				// TODO: 在此处添加构造函数逻辑
				//
			}
			#region ISubEditor 成员

			public object GetValue() 
			{
				// TODO:  添加 ucEditor.GetValue 实现
				return null;
			}
			
			/// <summary>
			/// 关闭事件
			/// </summary>
			public event System.EventHandler CloseUp;

			/// <summary>
			/// 设置数值
			/// </summary>
			/// <param name="value"></param>
			public void SetValue(object value) 
			{
				// TODO:  添加 ucEditor.SetValue 实现
			}

			/// <summary>
			/// 获得位置
			/// </summary>
			/// <param name="rect"></param>
			/// <returns></returns>
			public System.Drawing.Point GetLocation(System.Drawing.Rectangle rect) 
			{
				// TODO:  添加 ucEditor.GetLocation 实现
				return new System.Drawing.Point ();
			}
		
			/// <summary>
			/// 获得子控件
			/// </summary>
			/// <returns></returns>
			public System.Windows.Forms.Control GetSubEditorControl() 
			{
				// TODO:  添加 ucEditor.GetSubEditorControl 实现
				return null;
			}
			
			/// <summary>
			/// 数值变化
			/// </summary>
			public event System.EventHandler ValueChanged;

			/// <summary>
			/// 获得
			/// </summary>
			/// <returns></returns>
			public System.Drawing.Size GetPreferredSize() 
			{
				// TODO:  添加 ucEditor.GetPreferredSize 实现
				return new System.Drawing.Size ();
			}

			#endregion
		}

		public DateTimeCellType() 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.SubEditor = new ucEditor();
		}
		/// <summary>
		/// 子控件
		/// </summary>
		public override FarPoint.Win.Spread.CellType.ISubEditor SubEditor 
		{
			get 
			{
				return null;
			}
			set 
			{
				base.SubEditor = value;
			}
		}

		/// <summary>
		/// 显示子控件
		/// </summary>
		public override void ShowSubEditor() 
		{
			base.ShowSubEditor ();
		}


	}
}
