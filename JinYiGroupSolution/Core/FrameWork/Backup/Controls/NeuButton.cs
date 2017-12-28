using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using Neusoft.FrameWork.WinForms.Controls.General;
using System.Resources;
using System.Reflection;
using System.Collections;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuButton<br></br>
	/// [功能描述: NeuButton控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[ToolboxBitmap(typeof(Button))]
	public class NeuButton : System.Windows.Forms.Button , INeuControl
	{

        //bool gotFocus = false;
        //bool mouseDown = false;
        //bool mouseEnter = false;
		//private StringFormat		sf;
		private ButtonType		buttonType;
        //private bool typeChange = false;
		private StyleType styleType;
        //private string text;
        //private Image image;

		public NeuButton( ) 
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint|ControlStyles.UserPaint|ControlStyles.DoubleBuffer, true);
            //base.Text = "";
            //this.ImageAlign = ContentAlignment.MiddleLeft;
            //this.TextAlign = ContentAlignment.MiddleRight;
		}

        //public new string Text
        //{
        //    get
        //    {
        //        return base.Text;
        //    }
        //    set
        //    {
        //        try
        //        {
        //            base.Text = Neusoft.FrameWork.Management.Language.Msg(value);
        //        }
        //        catch { 
        //            base.Text = value; 
        //        }
        //    }
        //}

        //public new Image Image
        //{
        //    get
        //    {
        //        return this.image;
        //    }
        //    set
        //    {
        //        this.image = value;
        //    }
        //}
        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //    Graphics g = pe.Graphics;

        //    if (this.DesignMode)
        //    {
        //        DrawButtonState(pe.Graphics, DrawState.Normal);
        //        return;
        //    }

        //    if ( mouseDown )
        //    {
        //        DrawButtonState(g, DrawState.Pressed);
        //        return;
        //    }

        //    if ( gotFocus || mouseEnter) 
        //    {
        //        DrawButtonState(g, DrawState.Hot);
        //        return;
        //    }
			
        //    if ( Enabled )
        //        DrawButtonState(pe.Graphics, DrawState.Normal);
        //    else
        //        DrawButtonState(pe.Graphics, DrawState.Disable);
        //}

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    mouseEnter = true;
        //    base.OnMouseEnter(e);
        //    Invalidate();
		
        //}

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    mouseEnter = false;
        //    base.OnMouseLeave(e);
        //    Invalidate();
        //}

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    mouseDown = true;
        //    Invalidate();
        //}

        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);
        //    mouseDown = false;
        //    Invalidate();
        //}

        //protected override void OnGotFocus(EventArgs e)
        //{
        //    base.OnGotFocus(e);
        //    gotFocus = true;
        //    Invalidate();
        //}
        
        //protected override void OnLostFocus(EventArgs e)
        //{
        //    base.OnLostFocus(e);
        //    gotFocus = false;
        //    Invalidate();
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnTextChanged(EventArgs e) 
        //{
        //    if (this.typeChange) 
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        this.buttonType=ButtonType.None;
        //        this.Image=null;
        //    }
        //    if (sf != null) sf.Dispose();
        //        sf = new StringFormat();
        //    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

        //    base.OnTextChanged(e);
        //}

        //protected void DrawButtonState(Graphics g, DrawState state)
        //{
        //    if (this.styleType == StyleType.VS2003)
        //        DrawBackground(g, state);
	
        //    Rectangle rc = ClientRectangle;
			
        //    bool hasText = false;
        //    bool hasImage = Image != null;
        //    Size textSize = new Size(0,0);
        //    if ( Text != string.Empty && Text != "" )
        //    {
        //        hasText = true;
        //        textSize = TextUtil.GetTextSize(g, Text, Font);
        //    }
			
        //    int imageWidth = 0;
        //    int imageHeight = 0;
        //    if ( hasImage )
        //    {
        //        SizeF sizeF = Image.PhysicalDimension;
        //        imageWidth = (int)sizeF.Width;
        //        imageHeight = (int)sizeF.Height;
        //        // We are assuming that the button image is smaller than
        //        // the button itself
        //        if ( imageWidth > rc.Width || imageHeight > rc.Height)
        //        {
        //            Debug.WriteLine("Image dimensions need to be smaller that button's dimension...");
        //            return;
        //        }
        //    }

        //    int x, y;
        //    if ( hasText && !hasImage )
        //    {
        //        // Text only drawing
        //        x = (Width - textSize.Width)/2;
        //        y = (Height - textSize.Height)/2;
        //        DrawText(g, Text, state, x, y);
        //    }
        //    else if ( hasImage && !hasText )
        //    {
        //        // Image only drawing
        //        x = (Width - imageWidth)/2;
        //        y = (Height - imageHeight)/2;
        //        DrawImage(g, state, Image, x, y);
        //    }
        //    else 
        //    {
        //        // Text and Image drawing
        //        x = (Width - textSize.Width - imageWidth -2)/2;
        //        y = (Height - imageHeight)/2;
        //        DrawImage(g, state, Image, x, y);
        //        x += imageWidth + 2;
        //        y = (Height - textSize.Height)/2;
        //        DrawText(g, Text, state, x, y);
        //    }
			
        //}

        //protected void DrawBackground(Graphics g, DrawState state)
        //{
        //    //if (this.styleType != StyleType.VS2003) 			
        //    //    return;

        //    Rectangle rc = ClientRectangle;
        //    // Draw background
        //    if ( state == DrawState.Normal || state == DrawState.Disable )
        //    {
        //        g.FillRectangle(new SolidBrush(SystemColors.Control), rc);
        //        SolidBrush rcBrush;
        //        if ( state == DrawState.Disable )
        //            rcBrush = new SolidBrush(SystemColors.ControlDark);
        //        else
        //            rcBrush = new SolidBrush(SystemColors.ControlDarkDark);
				
        //        // Draw border rectangle
        //        g.DrawRectangle(new Pen(rcBrush), rc.Left, rc.Top, rc.Width-1, rc.Height-1);

        //    }
        //    else if ( state == DrawState.Hot || state == DrawState.Pressed  )
        //    {
        //        // Erase whaterver that was there before
        //        if ( state == DrawState.Hot )
        //            g.FillRectangle(new SolidBrush(ColorUtil.VSNetSelectionColor), rc);
        //        else
        //            g.FillRectangle(new SolidBrush(ColorUtil.VSNetPressedColor), rc);
        //        // Draw border rectangle
        //        g.DrawRectangle(SystemPens.Highlight, rc.Left, rc.Top, rc.Width-1, rc.Height-1);
        //    }
        //}

        //protected void DrawImage(Graphics g, DrawState state, Image image, int x, int y)
        //{
        //    //if (this.styleType != StyleType.VS2003) 			
        //    //    return;

        //    SizeF sizeF = Image.PhysicalDimension;
        //    int imageWidth = (int)sizeF.Width;
        //    int imageHeight = (int)sizeF.Height;
			
        //    if ( state == DrawState.Normal )
        //    {
        //        g.DrawImage(Image, x, y, imageWidth, imageHeight);
        //    }
        //    else if ( state == DrawState.Disable )
        //    {
        //        ControlPaint.DrawImageDisabled(g, Image, x, y, SystemColors.Control);
        //    }
        //    else if ( state == DrawState.Pressed || state == DrawState.Hot )
        //    {
        //        ControlPaint.DrawImageDisabled(g, Image, x+1, y, SystemColors.Control);
        //        g.DrawImage(Image, x, y-1, imageWidth, imageHeight);                 
        //    }
        //}

        //protected void DrawText(Graphics g, string Text, DrawState state, int x, int y)
        //{
        //    //if (this.styleType != StyleType.VS2003) 			
        //    //    return;

        //    if ( state == DrawState.Disable )
        //        //g.DrawString(Text, Font, SystemBrushes.ControlDark, new Point(x, y));
        //        g.DrawString(Text, Font, SystemBrushes.ControlText, new Point(x, y), sf);
        //    else
        //        //g.DrawString(Text, Font, SystemBrushes.ControlText, new Point(x, y));
        //        g.DrawString(Text, Font, SystemBrushes.ControlText, new Point(x, y), sf);
        //}


        public ButtonType Type
        {
            get
            {
                return this.buttonType;
            }
            set
            {
                this.buttonType = value;
                //this.typeChange = true;
                //this.TextAlign = ContentAlignment.MiddleRight;
                switch (value)
                {
                    case ButtonType.OK:
                        {
                            this.Text = "确定(&O)";
                            //this.Image = new Bitmap(this.GetType(), "ICON.Check.ico");
                            break;
                        }
                    case ButtonType.Cancel:
                        {
                            this.Text = "取消(&C)";
                            //this.Image = new Bitmap(this.GetType(), "ICON.delete.ico");
                            break;
                        }
                    case ButtonType.Save:
                        {
                            this.Text = "保存(&S)";
                            this.Image = null;
                            break;
                        }

                    case ButtonType.Close:
                        {
                            this.Text = "关闭(&C)";
                            this.Image = null;
                            break;
                        }
                    case ButtonType.Exit:
                        {
                            this.Text = "退出(&X)";
                            this.Image = null;
                            break;
                        }

                    case ButtonType.Add:
                        {
                            this.Text = "添加(&A)";
                            this.Image = null;
                            break;
                        }
                    case ButtonType.Remove:
                        {
                            this.Text = "移除(&D)";
                            this.Image = null;
                            break;
                        }
                    case ButtonType.None:
                        {
                            this.Image = null;
                            this.TextAlign = ContentAlignment.MiddleCenter;
                            break;
                        }
                }

                //this.typeChange = false;
                this.Invalidate();
            }
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
					this.FlatStyle = FlatStyle.Flat;
				else if(value == StyleType.Fixed3D)
					this.FlatStyle = FlatStyle.Standard;
				else
					this.Invalidate();
			}
		}

		#endregion
	}
}
