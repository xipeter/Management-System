using System;
using System.Windows.Forms;
using System.Drawing;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuLabel<br></br>
	/// [功能描述: NeuLabel控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[ToolboxBitmap(typeof(Label))]
	public class NeuLabel : Label ,INeuControl
	{
		public NeuLabel()
		{
			//this.AutoSize = true;
		}

		private StyleType styleType;

		#region INeuControl 成员

		public Neusoft.FrameWork.WinForms.Controls.StyleType Style
		{
			get
			{				
				return this.styleType;
			}
			set
			{
				this.styleType = value;
			}
		}

		#endregion

        //#region 文本替换
        ///// <summary>
        ///// 显示文本替换
        ///// </summary>
        //public new  string Text
        //{
        //    get
        //    {
        //        return base.Text;
        //    }
        //    set
        //    {
        //        try
        //        {
        //            base.Text = FrameWork.Management.Language.Msg(value);
        //        }
        //        catch { base.Text = value; }
        //    }
        //}
        //#endregion
    }
}
