using System;
using System.Windows.Forms;
namespace neusoft.neuFC.Interface.Classes
{
	/// <summary>
	/// Function 的摘要说明。
	/// </summary>
	public class Function
	{
		public Function()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//			
		}
		/// <summary>
		/// 显示弹出控件
		/// </summary>
		/// <param name="c"></param>
		public static void PopShowControl(Control c)
		{
			//创建临时窗口，用来显示控件
			Form frmTemp = new Form();
			frmTemp.StartPosition =FormStartPosition.CenterScreen;
			frmTemp.Text = c.Text;
			//创建控件并添加到临时窗口中
			if(c==null) c= new Control();
			frmTemp.Width = c.Width + 8;
			frmTemp.Height = c.Height + 34;
			c.Dock = DockStyle.Fill;
			frmTemp.Controls.Add(c);
			//显示临时窗口
			frmTemp.ShowDialog();
		}
		/// <summary>
		/// 控件
		/// </summary>
		/// <param name="c"></param>
		public static void ShowControl(Control c)
		{
			//创建临时窗口，用来显示控件
			Form frmTemp = new Form();
			frmTemp.StartPosition =FormStartPosition.CenterScreen;
			frmTemp.Text = c.Text;
			//创建控件并添加到临时窗口中
			if(c==null) c= new Control();
			frmTemp.Width = c.Width + 8;
			frmTemp.Height = c.Height + 34;
			c.Dock = DockStyle.Fill;
			frmTemp.Controls.Add(c);
			//显示临时窗口
			frmTemp.Show();
		}
		
	}
}
