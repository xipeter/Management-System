using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using Neusoft.NFC.Interface.Controls.General;
using Neusoft.NFC.Interface.Controls.Win32;

namespace Neusoft.NFC.Interface.Controls
{
	/// <summary>
	/// Summary description for TextComboBox.
	/// </summary>
	[ToolboxBitmap(typeof(ComboBox))]
	public class ComboBox : ComboBoxBase
	{
		
		// For use when hosted by a toolbar
		public ComboBox(bool toolBarUse) : base(toolBarUse)
		{
			// Override parent, we don't want to do all the painting ourselves
			// since we want to let the edit control deal with the text for editing
			// the parent class ComboBoxBase knows to do the right stuff with 
			// non-editable comboboxes as well as editable comboboxes as long
			// as we change these flags below
			SetStyle(ControlStyles.AllPaintingInWmPaint
				|ControlStyles.UserPaint|ControlStyles.Opaque, false);
		}		
		
		public ComboBox()
		{
			// Override parent, we don't want to do all the painting ourselves
			// since we want to let the edit control deal with the text for editing
			// the parent class ComboBoxBase knows to do the right stuff with 
			// non-editable comboboxes as well as editable comboboxes as long
			// as we change these flags below
			SetStyle(ControlStyles.AllPaintingInWmPaint
				|ControlStyles.UserPaint|ControlStyles.Opaque, false);
		}

        private bool isEnter2Tab = false;

        /// <summary>
        /// 是否将Enter输入转成Tab输入
        /// </summary>
        [System.ComponentModel.Description("是否将Enter输入转成Tab输入")]
        public bool IsEnter2Tab
        {
            get { return isEnter2Tab; }
            set { isEnter2Tab = value; }
        }

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			
			// Call base class to do the "Flat ComboBox" drawing
			base.OnDrawItem(e);
			// Draw text
			Graphics g = e.Graphics;
			Rectangle bounds = e.Bounds;
			bool selected = (e.State & DrawItemState.Selected) > 0;
			bool editSel = (e.State & DrawItemState.ComboBoxEdit ) > 0;
			if ( e.Index != -1 && e.Index<20000)
				DrawComboBoxItem(g, bounds, e.Index, selected, editSel);
			
		}
		
		protected override void DrawComboBoxItem(Graphics g, Rectangle bounds, int Index, bool selected, bool editSel)
		{
			// Call base class to do the "Flat ComboBox" drawing
			base.DrawComboBoxItem(g, bounds, Index, selected, editSel);
						
				if ( Index != -1 && Index<20000)
				{
					SolidBrush brush;
					if ( selected && editSel) 
						brush =  new SolidBrush(SystemColors.MenuText);
					else if ( selected )
						brush =  new SolidBrush(SystemColors.HighlightText);
					else
						brush = new SolidBrush(SystemColors.MenuText);

					Size textSize = TextUtil.GetTextSize(g, Items[Index].ToString(), Font);
					int top = bounds.Top + (bounds.Height - textSize.Height)/2;
					g.DrawString(Items[Index].ToString(), Font, brush, new Point(bounds.Left + 1, top));
				}
			
		}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == (char)13 && this.isEnter2Tab)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
            }
        }

		protected override void DrawComboBoxItemEx(Graphics g, Rectangle bounds, int Index, bool selected, bool editSel)
		{
			// This "hack" is necessary to avoid a clipping bug that comes from the fact that sometimes
			// we are drawing using the Graphics object for the edit control in the combobox and sometimes
			// we are using the graphics object for the combobox itself. If we use the same function to do our custom
			// drawing it is hard to adjust for the clipping because of what was said about
			base.DrawComboBoxItemEx(g, bounds, Index, selected, editSel);
			
				if ( Index != -1 && Index<20000)
				{
					SolidBrush brush;
					if ( selected && editSel) 
						brush =  new SolidBrush(SystemColors.MenuText);
					else if ( selected )
						brush =  new SolidBrush(SystemColors.HighlightText);
					else
						brush = new SolidBrush(SystemColors.MenuText);

					Size textSize = TextUtil.GetTextSize(g, Items[Index].ToString(), Font);
					int top = bounds.Top + (bounds.Height - textSize.Height)/2;
					// Clipping rectangle
					Rectangle clipRect = new Rectangle(bounds.Left + 4, top, bounds.Width - ARROW_WIDTH - 4, top+textSize.Height);
					g.DrawString(Items[Index].ToString(), Font, brush, clipRect);
				}
			
		}
		
	}
}
