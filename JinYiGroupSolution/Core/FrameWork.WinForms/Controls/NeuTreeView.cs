using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Neusoft.FrameWork.WinForms.Controls.General;
using Neusoft.FrameWork.WinForms.Controls.Win32;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuTreeView<br></br>
	/// [功能描述: TreeView控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-29]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[ToolboxBitmap(typeof(TreeView))]
	public class NeuTreeView : System.Windows.Forms.TreeView ,INeuControl
	{
#region 变量
		bool itemHasFocus = false;
		//bool hasFocus = false;						//控件是否有Focus
		private StyleType styleType;
		//DrawState drawState = DrawState.Normal;
#endregion

		public NeuTreeView()
		{
			this.HideSelection = false;
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			// Set state to hot
			base.OnMouseEnter(e);		
            //drawState = DrawState.Hot;
            //Invalidate();
			
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			// Set state to Normal
			base.OnMouseLeave(e);
            //if ( !ContainsFocus )
            //{
            //    drawState = DrawState.Normal;
            //    Invalidate();
            //}
		}
      
		protected override void OnGotFocus(EventArgs e)
		{
			// Set state to Hot
			base.OnGotFocus(e);
			//drawState = DrawState.Hot;
			//this.hasFocus = true;
			Invalidate();
		}
        
		protected override void OnLostFocus(EventArgs e)
		{
			// Set state to Normal
			base.OnLostFocus(e);
			//this.hasFocus = false;
			//drawState = DrawState.Normal;
			Invalidate();
		}

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);

            NeuTreeNode node = e.Node as NeuTreeNode;
            if (node != null)
            {
                node.AfterExpand();
            }

        }

        //protected override  void WndProc(ref Message message)
        //{
            //base.WndProc(ref message);
			
            //if(this.styleType != StyleType.VS2003)
            //    return;

            //switch (message.Msg)
            //{
            //    // Reflected Messages come from the treeview control itself
            //    case (int)ReflectedMessages.OCM_NOTIFY:
            //        NMHDR nm2 = (NMHDR) message.GetLParam(typeof(NMHDR));	
            //        switch (nm2.code)
            //        {
            //            case (int)NotificationMessages.NM_CUSTOMDRAW:
            //                //this.NotifyTreeCustomDraw(ref message); 
            //                //this.DrawTreeViewBorder(this.drawState);
            //            break;
            //            default:
            //            break;
            //        }
            //        break;
            //    default:
            //        break;
            //}

        //}

		private bool NotifyTreeCustomDraw(ref Message m)
		{
			m.Result = (IntPtr)CustomDrawReturnFlags.CDRF_DODEFAULT;
			NMTVCUSTOMDRAW tvcd = (NMTVCUSTOMDRAW)m.GetLParam(typeof(NMTVCUSTOMDRAW));
			IntPtr thisHandle = Handle;
			
			if ( tvcd.nmcd.hdr.hwndFrom != Handle)
				return false;
			switch (tvcd.nmcd.dwDrawStage)
			{
				case (int)CustomDrawDrawStateFlags.CDDS_PREPAINT:
					// Ask for Item painting notifications
					m.Result = (IntPtr)CustomDrawReturnFlags.CDRF_NOTIFYITEMDRAW;
					break;
				case (int)CustomDrawDrawStateFlags.CDDS_ITEMPREPAINT:
					
					itemHasFocus = false;
					if(	(tvcd.nmcd.uItemState & (int)CustomDrawItemStateFlags.CDIS_FOCUS) != 0)
						itemHasFocus = true;
					
					// Set the text and background text color to the window bakcground
					// text so that we don't see the text being painted
					tvcd.clrText = ColorUtil.RGB(SystemColors.Window.R,
						SystemColors.Window.G, SystemColors.Window.B);
					tvcd.clrTextBk = ColorUtil.RGB(SystemColors.Window.R,
						SystemColors.Window.G, SystemColors.Window.B);
					
					// Put structure back in the message
					Marshal.StructureToPtr(tvcd, m.LParam, true);
					m.Result = (IntPtr)CustomDrawReturnFlags.CDRF_NOTIFYPOSTPAINT;
					break;
				case (int)CustomDrawDrawStateFlags.CDDS_ITEMPOSTPAINT:
					DoTreeCustomDrawing(ref m);
					break;
				default:
					break;

			}
			return false;
		}


		private void DoTreeCustomDrawing(ref Message m)
		{
			NMTVCUSTOMDRAW tvcd = (NMTVCUSTOMDRAW)m.GetLParam(typeof(NMTVCUSTOMDRAW));
			IntPtr hNode = (IntPtr)tvcd.nmcd.dwItemSpec;
			Rectangle rect = GetItemRect(hNode);
			
			// Create a graphic object from the Device context in the message
			Graphics g = Graphics.FromHdc(tvcd.nmcd.hdc);
			// If this item has the focus draw the higlighting rectangle			
			if (itemHasFocus)
			{
				using ( Brush brush = new SolidBrush(ColorUtil.VSNetSelectionColor))
				{
					g.FillRectangle(brush, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
					g.DrawRectangle(SystemPens.Highlight, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
				}
			}
			
			// Draw Text
			string itemText = GetItemText(hNode);
			Size textSize = TextUtil.GetTextSize(g, itemText, Font);
			Point pos = new Point(rect.Left, rect.Top + (rect.Height - textSize.Height)/2);
			g.DrawString(itemText, Font, SystemBrushes.ControlText, pos);
                        					            			
			// Put structure back in the message
			Marshal.StructureToPtr(tvcd, m.LParam, true);
			m.Result = 	(IntPtr)CustomDrawReturnFlags.CDRF_SKIPDEFAULT;

		}


		Rectangle GetItemRect(IntPtr hTreeItem)
		{
			RECT rc = new RECT();
			
			// This is how Microsoft recommends to shovel the handle to the tree Node into
			// the rectangle structure that will be used to send a message to retrieve
			// the bounds of the tree item. Any wonders why Java became a huge success?
			unsafe 
			{ 
				*(IntPtr*)&rc = hTreeItem;
			}

			
			// --I wanted to use the TreeView NET control itself to get the bounds of the current
			// tree node, but a quick inspection through the documentation made me realize that I would 
			// have to loop through the Nodes collection and all the subnodes collections that
			// each node have which would be terribly expensive just to retrieve such information,
			// specially when I need to do this really quick
			// instead let's use the horrible but efficient way--
			WindowsAPI.SendMessage(Handle, (int)TreeViewMessages.TVM_GETITEMRECT, 1, ref rc);
			
			return new Rectangle(rc.left, rc.top, rc.right-rc.left, rc.bottom-rc.top);
		}

		string GetItemText(IntPtr hTreeItem)
		{
            string text;
			TVITEM tvi = new TVITEM();
			tvi.hItem = hTreeItem;
			tvi.mask = (int)TreeViewItemFlags.TVIF_TEXT;
			tvi.cchTextMax = 80;
			tvi.pszText = Marshal.AllocHGlobal(80);
			WindowsAPI.SendMessage(Handle, (int)TreeViewMessages.TVM_GETITEMW, 0, ref tvi);
			text = Marshal.PtrToStringAuto(tvi.pszText);
			return text;
		}


		/// <summary>
		/// 画边框
		/// </summary>
		/// <param name="drawState">控件状态</param>
		/// Robin	2006-08-29
		void DrawTreeViewBorder(DrawState drawState)
		{
			if(this.styleType != StyleType.VS2003)
				return;

			// Get window area
			Win32.RECT rc = new Win32.RECT();
			WindowsAPI.GetWindowRect(Handle, ref rc);
			// Convert to Rectangle
			Rectangle rect = new Rectangle(0, 0, rc.right - rc.left, rc.bottom - rc.top);

			// Create DC for the whole edit window instead of just for the client area
			IntPtr hDC = WindowsAPI.GetWindowDC(Handle);
			
			using (Graphics g = Graphics.FromHdc(hDC))
			{
				// This rectangle is always drawn for any state
				using ( Pen windowPen = new Pen(SystemBrushes.Window) )
				{
					g.DrawRectangle(windowPen, rect.Left+1, rect.Top+1, rect.Width-3, rect.Height-3);
				}
				
				if ( drawState == DrawState.Normal )
				{
					// draw SystemColos.Window rectangle
					//					using ( Pen windowPen = new Pen(SystemBrushes.Window) )
					//					{
					//						g.DrawRectangle(windowPen, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
					//					}
					g.DrawRectangle(DrawingUtil.BorderColorPen, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
				}
				else if ( drawState == DrawState.Hot )
				{
					// draw highlighted rectangle						
					g.DrawRectangle(DrawingUtil.BorderHotColorPen, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
					
				}
				else if ( drawState == DrawState.Disable )
				{
					// draw highlighted rectangle
					g.FillRectangle(SystemBrushes.Window, rect);

				}
			}

			// Release DC
			WindowsAPI.ReleaseDC(Handle, hDC);
            
		}

		#region INeuControl 成员


		public StyleType Style {
			get
			{				
				return this.styleType;
			}
			set
			{
				this.styleType=value;
				if (value == StyleType.Flat)
				{
					this.BorderStyle = BorderStyle.Fixed3D;
					this.BorderStyle = BorderStyle.FixedSingle;
				}
				else if(value == StyleType.Fixed3D)
				{
					this.BorderStyle = BorderStyle.FixedSingle;
					this.BorderStyle = BorderStyle.Fixed3D;
				}
				else
					this.Invalidate();
			}
		}

		#endregion

		
	}
}
