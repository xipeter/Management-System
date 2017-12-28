using Neusoft.FrameWork.WinFormsDrawing;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
	
	#region CollapsiblePanel class
	/// <summary>
	/// An extended <see cref="System.Windows.Forms.Panel">Panel</see> that provides collapsible panels like those provided in Windows XP.
	/// </summary>
	public class CollapsiblePanel : System.Windows.Forms.Panel
	{
		#region Events
		/// <summary>
		/// A <see cref="PanelState">PanelState</see> changed event.
		/// </summary>
		[Category("State"),
		Description("Raised when panel state has changed.")]
		public event PanelStateChangedEventHandler PanelStateChanged;
		public event LinkLabelLinkClickedEventHandler LinkClick;
		#endregion

		#region Private class data
		private System.Drawing.Imaging.ColorMatrix grayMatrix;
		private System.Drawing.Imaging.ImageAttributes grayAttributes;
		private PanelState state = PanelState.Expanded;
		private int panelHeight;
		private int imageIndex = 0;
		private const int minTitleHeight = 24;
		private const int iconBorder = 2;
		private const int expandBorder = 4;
		private System.Drawing.Color startColour = Color.White;
		private System.Drawing.Color endColour = Color.FromArgb(199, 212, 247);
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label labelTitle;
        private ImageList imageList;
		private System.Drawing.Image image;

		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollapsiblePanel));
            this.labelTitle = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Navy;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            this.labelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitle_Paint);
            this.labelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseUp);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Expand.png");
            this.imageList.Images.SetKeyName(1, "Collapse.gif");
            this.imageList.Images.SetKeyName(2, "Collapse.png");
            this.imageList.Images.SetKeyName(3, "CollapsiblePanel.bmp");
            this.imageList.Images.SetKeyName(4, "CollapsiblePanel.ico");
            this.imageList.Images.SetKeyName(5, "CollapsiblePanelBar.bmp");
            this.imageList.Images.SetKeyName(6, "Expand.gif");
            // 
            // CollapsiblePanel
            // 
            this.Controls.Add(this.labelTitle);
            this.ResumeLayout(false);

		}
		#endregion
	
		#region Public Constructors
		/// <summary>
		/// Initialises a new instance of <a cref="Salamander.Windows.Forms.CollapsiblePanel">CollapsiblePanel</a>.
		/// </summary>
		public CollapsiblePanel() : base()
		{
			this.components = new System.ComponentModel.Container();

			InitializeComponent();

			// Set the background colour to ControlLightLight
			this.BackColor = Color.AliceBlue;

			// Store the current panelHeight
			this.panelHeight = this.Height;

			// Setup the ColorMatrix and ImageAttributes for grayscale images.
			this.grayMatrix = new ColorMatrix();
			this.grayMatrix.Matrix00 = 1/3f;
			this.grayMatrix.Matrix01 = 1/3f;
			this.grayMatrix.Matrix02 = 1/3f;
			this.grayMatrix.Matrix10 = 1/3f;
			this.grayMatrix.Matrix11 = 1/3f;
			this.grayMatrix.Matrix12 = 1/3f;
			this.grayMatrix.Matrix20 = 1/3f;
			this.grayMatrix.Matrix21 = 1/3f;
			this.grayMatrix.Matrix22 = 1/3f;
			this.grayAttributes = new ImageAttributes();
			this.grayAttributes.SetColorMatrix(this.grayMatrix, ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets/sets the <see cref="PanelState">PanelState</see>.
		/// </summary>
		[Browsable(false)]
		public PanelState PanelState
		{
			get
			{
				return this.state;
			}
			set
			{
				PanelState oldState = this.state;
				this.state = value;
				if(oldState != this.state)
				{
					// State has changed to update the display
					UpdateDisplayedState();
				}
			}
		}

		/// <summary>
		/// Gets/sets the text displayed as the panel title.
		/// </summary>
		[Category("Title"),
		Description("The text contained in the title bar.")]
		public string TitleText
		{
			get
			{
				return this.labelTitle.Text;
			}
			set
			{
				this.labelTitle.Text = value;
			}
		}

		/// <summary>
		/// Gets/sets the foreground colour used for the title bar.
		/// </summary>
		[Category("Title"),
		Description("The foreground colour used to display the title text.")]
		public Color TitleFontColour
		{
			get
			{
				return this.labelTitle.ForeColor;
			}
			set
			{
				this.labelTitle.ForeColor = value;
			}
		}

		/// <summary>
		/// Gets/sets the font used for the title bar text.
		/// </summary>
		[Category("Title"),
		Description("The font used to display the title text.")]
		public Font TitleFont
		{
			get
			{
				return this.labelTitle.Font;
			}
			set
			{
				this.labelTitle.Font = value;
			}
		}

		/// <summary>
		/// Gets/sets the image list used for the expand/collapse image.
		/// </summary>
		[Category("Title"),
		Description("The image list to get the images displayed for expanding/collapsing the panel.")]
		public ImageList ImageList
		{
			get
			{
				return this.imageList;
			}
			set
			{
				this.imageList = value;
				if(null != this.imageList)
				{
					if(this.imageList.Images.Count > 0)
					{
						this.imageIndex = 0;
					}
				}
				else
				{
					this.imageIndex = -1;
				}
			}
		}

		/// <summary>
		/// Gets/sets the starting colour for the background gradient of the header.
		/// </summary>
		[Category("Title"),
		Description("The colour used at the start of the colour gradient displayed as the background of the title bar.")]
		public Color StartColour
		{
			get
			{
				return this.startColour;
			}
			set
			{
				this.startColour = value;
				this.labelTitle.Invalidate();
			}
		}

		/// <summary>
		/// Gets/sets the ending colour for the background gradient of the header.
		/// </summary>
		[Category("Title"),
		Description("The colour used at the end of the colour gradient displayed as the background of the title bar.")]
		public Color EndColour
		{
			get
			{
				return this.endColour;
			}
			set
			{
				this.endColour = value;
				this.labelTitle.Invalidate();
			}
		}

		/// <summary>
		/// Gets/sets the image displayed in the header of the title bar.
		/// </summary>
		[Category("Title"),
		Description("The image that will be displayed on the left hand side of the title bar.")]
		public Image Image
		{
			get
			{
				return this.image;
			}
			set
			{
				this.image = value;
				if(null != value)
				{
					// Update the height of the title label
					this.labelTitle.Height = this.image.Height + (2 * CollapsiblePanel.iconBorder);
					if(this.labelTitle.Height < minTitleHeight)
					{
						this.labelTitle.Height = minTitleHeight;
					}
				}
				this.labelTitle.Invalidate();
			}
		}
		#endregion

		#region Private Helper functions
		// <feature>Expand/Collapse functionality updated as per Windows XP. Whole of title bar is active
		// <version>1.3</version>
		// <date>23-Oct-2002</date>
		// </feature>
		/// <summary>
		/// Helper function to determine if the mouse is currently over the title bar.
		/// </summary>
		/// <param name="xPos">The x-coordinate of the mouse position.</param>
		/// <param name="yPos">The y-coordinate of the mouse position.</param>
		/// <returns></returns>
		private bool IsOverTitle(int xPos, int yPos)
		{
			// Get the dimensions of the title label
			Rectangle rectTitle = this.labelTitle.Bounds;
			// Check if the supplied coordinates are over the title label
			if(rectTitle.Contains(xPos, yPos))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Helper function to update the displayed state of the panel.
		/// </summary>
		private void UpdateDisplayedState()
		{
			switch(this.state)
			{
				case PanelState.Collapsed :
					// Entering collapsed state, so store the current height.
					this.panelHeight = this.Height;
					// Collapse the panel
					this.Height = labelTitle.Height;
					// Update the image.
					this.imageIndex = 1;
					break;
				case PanelState.Expanded :
					// Entering expanded state, so expand the panel.
					this.Height = this.panelHeight;
					// Update the image.
					this.imageIndex = 0;
					break;
				default :
					// Ignore
					break;
			}
			this.labelTitle.Invalidate();

			OnPanelStateChanged(new PanelEventArgs(this));
		}
		#endregion

		#region Event handlers
		/// <summary>
		/// Event handler for the <see cref="CollapsiblePanel.PanelStateChanged">PanelStateChanged</see> event.
		/// </summary>
		/// <param name="e">A <see cref="Salamander.Windows.Forms.PanelEventArgs">PanelEventArgs</see> that contains the event data.</param>
		protected virtual void OnPanelStateChanged(PanelEventArgs e)
		{
			if(PanelStateChanged != null)
			{
				PanelStateChanged(this, e);
			}
		}

		private void labelTitle_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			const int diameter = 14;
			int radius = diameter / 2;
			Rectangle bounds = labelTitle.Bounds;
			int offsetY = 0;
			if(null != this.image)
			{
				offsetY = this.labelTitle.Height - CollapsiblePanel.minTitleHeight;
				if(offsetY < 0)
				{
					offsetY = 0;
				}
				bounds.Offset(0, offsetY);
				bounds.Height -= offsetY;
			}

			e.Graphics.Clear(this.Parent.BackColor);

			// Create a GraphicsPath with curved top corners
			GraphicsPath path = new GraphicsPath();
			path.AddLine(bounds.Left + radius, bounds.Top, bounds.Right - diameter - 1, bounds.Top);
			path.AddArc(bounds.Right - diameter - 1, bounds.Top, diameter, diameter, 270, 90);
			path.AddLine(bounds.Right, bounds.Top + radius, bounds.Right, bounds.Bottom);
			path.AddLine(bounds.Right, bounds.Bottom, bounds.Left - 1, bounds.Bottom);
			path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);

			// Create a colour gradient
			// <feature>Draws the title gradient grayscale when disabled.
			// <version>1.4</version>
			// <date>25-Nov-2002</date>
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if(true == this.Enabled)
			{
				LinearGradientBrush brush = new LinearGradientBrush(
					bounds, this.startColour, this.endColour, LinearGradientMode.Horizontal);

				// Paint the colour gradient into the title label.
				e.Graphics.FillPath(brush, path);
			}
			else
			{
				Colour grayStart = new Colour();
				grayStart.CurrentColour = this.startColour;
				grayStart.Saturation = 0f;
				Colour grayEnd = new Colour();
				grayEnd.CurrentColour = this.endColour;
				grayEnd.Saturation = 0f;
				LinearGradientBrush brush = new LinearGradientBrush(
					bounds, grayStart.CurrentColour, grayEnd.CurrentColour,
					LinearGradientMode.Horizontal);

				// Paint the grayscale gradient into the title label.
				e.Graphics.FillPath(brush, path);
			}
			// </feature>

			// Draw the header icon, if there is one
			System.Drawing.GraphicsUnit graphicsUnit = System.Drawing.GraphicsUnit.Display;
			int offsetX = CollapsiblePanel.iconBorder;
			if(null != this.image)
			{
				offsetX += this.image.Width + CollapsiblePanel.iconBorder;
				// <feature>Draws the title icon grayscale when the panel is disabled.
				// <version>1.4</version>
				// <date>25-Nov-2002</date>
				RectangleF srcRectF = this.image.GetBounds(ref graphicsUnit);
				Rectangle destRect = new Rectangle(CollapsiblePanel.iconBorder,
					CollapsiblePanel.iconBorder, this.image.Width, this.image.Height);
				if(true == this.Enabled)
				{
					e.Graphics.DrawImage(this.image, destRect, (int)srcRectF.Left, (int)srcRectF.Top,
						(int)srcRectF.Width, (int)srcRectF.Height, graphicsUnit);
				}
				else
				{
					e.Graphics.DrawImage(this.image, destRect, (int)srcRectF.Left, (int)srcRectF.Top,
						(int)srcRectF.Width, (int)srcRectF.Height, graphicsUnit, this.grayAttributes);
				}
				// </feature>
			}

			// Draw the title text.
			SolidBrush textBrush = new SolidBrush(this.TitleFontColour);
			// <feature>Title text truncated with an ellipsis where necessary.
			// <version>1.2</version>
			// <date>18-Oct-2002</date>
			// <source>Nnamdi Onyeyiri (mailto:theeclypse@hotmail.com)</source>
			float left = (float)offsetX;
			float top = (float)offsetY + (float)CollapsiblePanel.expandBorder;
			float width = (float)this.labelTitle.Width - left - this.imageList.ImageSize.Width - 
				CollapsiblePanel.expandBorder;
			float height = (float)CollapsiblePanel.minTitleHeight - (2f * (float)CollapsiblePanel.expandBorder);
			RectangleF textRectF = new RectangleF(left, top, width, height);
			StringFormat format = new StringFormat();
			format.Trimming = StringTrimming.EllipsisWord;
			// <feature>Draw title text disabled where appropriate.
			// <version>1.4</version>
			// <date>25-Nov-2002</date>
			if(true == this.Enabled)
			{
				e.Graphics.DrawString(labelTitle.Text, labelTitle.Font, textBrush, 
					textRectF, format);
			}
			else
			{
				Color disabled = SystemColors.GrayText;
				ControlPaint.DrawStringDisabled(e.Graphics, labelTitle.Text, labelTitle.Font,
					disabled, textRectF, format);
			}
			// </feature>
			// </feature>

			// Draw a white line at the bottom:
			const int lineWidth = 1;
			SolidBrush lineBrush = new SolidBrush(Color.White);
			Pen linePen = new Pen(lineBrush, lineWidth);
			path.Reset();
			path.AddLine(bounds.Left, bounds.Bottom - lineWidth, bounds.Right, 
				bounds.Bottom - lineWidth);
			e.Graphics.DrawPath(linePen, path);

			// Draw the expand/collapse image
			// <feature>Expand/Collapse image drawn grayscale when panel is disabled.
			// <version>1.4</version>
			// <date>25-Nov-2002</date>
			int xPos = bounds.Right - this.imageList.ImageSize.Width - CollapsiblePanel.expandBorder;
			int yPos = bounds.Top + CollapsiblePanel.expandBorder;
			RectangleF srcIconRectF = this.ImageList.Images[(int)this.state].GetBounds(ref graphicsUnit);
			Rectangle destIconRect = new Rectangle(xPos, yPos, 
				this.imageList.ImageSize.Width, this.imageList.ImageSize.Height);
			if(true == this.Enabled)
			{
				e.Graphics.DrawImage(this.ImageList.Images[(int)this.state], destIconRect,
					(int)srcIconRectF.Left, (int)srcIconRectF.Top, (int)srcIconRectF.Width,
					(int)srcIconRectF.Height, graphicsUnit);
			}
			else
			{
				e.Graphics.DrawImage(this.ImageList.Images[(int)this.state], destIconRect,
					(int)srcIconRectF.Left, (int)srcIconRectF.Top, (int)srcIconRectF.Width,
					(int)srcIconRectF.Height, graphicsUnit, this.grayAttributes);
			}
			// </feature>
		}

		private void labelTitle_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if((e.Button == MouseButtons.Left) && (true == IsOverTitle(e.X, e.Y)))
			{
				if((null != this.imageList) && (this.imageList.Images.Count >=2))
				{
					if(0 == this.imageIndex)
					{
						// Currently expanded, so store the current height.
						this.state = PanelState.Collapsed;
					}
					else
					{
						// Currently collapsed, so expand the panel.
						this.state = PanelState.Expanded;
					}
					UpdateDisplayedState();
				}
			}
		}

		private void labelTitle_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if((e.Button == MouseButtons.None) && (true == IsOverTitle(e.X, e.Y)))
			{
				this.labelTitle.Cursor = Cursors.Hand;
			}
			else
			{
				this.labelTitle.Cursor = Cursors.Default;
			}
		}
		#endregion

		#region Customs

		int iIndex = -1;

		int left = 5;
		int top = 2;

		int firstTop = 25;


		/// <summary>
		/// Ìí¼ÓNode
		/// </summary>
		/// <param name="text"></param>
		/// <param name="tag"></param>
		public void AddNode(string text,object tag,Image image)
		{
			iIndex++;
			LinkLabel lnk = new LinkLabel();
			lnk.Text = text;
			lnk.TabIndex = iIndex;
			lnk.Tag = tag;
			lnk.Visible = true;
			
			lnk.LinkBehavior = LinkBehavior.HoverUnderline;
			lnk.Location = new Point(left,iIndex*(lnk.Height + top)+top+firstTop);
			lnk.Width = this.Width - 20;
			lnk.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			lnk.LinkClicked+=new LinkLabelLinkClickedEventHandler(lnk_LinkClicked);
			
			this.Height = lnk.Top+ lnk.Height + top;
			this.panelHeight = this.Height;
			this.Controls.Add(lnk);
			if(image!=null)
			{
				PictureBox p = new PictureBox();
				p.Image = image;
				p.Size = image.Size;
				p.Location = lnk.Location;
				p.Visible = true;
				this.Controls.Add(p);
				lnk.Left +=p.Width;
			}
			
		}

		public void AddNode(string text,object tag)
		{
			this.AddNode(text,tag,null);
		}
		/// <summary>
		/// Çå³ý
		/// </summary>
		public void Clear()
		{
			iIndex =-1;
			this.Controls.Clear();
		}

		protected virtual void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(LinkClick!=null)
				LinkClick(sender,e);
		}

		
		#endregion

		
	}
	#endregion

    #region Enumerations
    /// <summary>
    /// Defines the state of a <see cref="CollapsiblePanel">CollapsiblePanel</see>.
    /// </summary>
    public enum PanelState
    {
        /// <summary>
        /// The <see cref="CollapsiblePanel">CollapsiblePanel</see> is expanded.
        /// </summary>
        Expanded,
        /// <summary>
        /// The <see cref="CollapsiblePanel">CollapsiblePanel</see> is collapsed.
        /// </summary>
        Collapsed
    }
    #endregion

    #region Delegates
    /// <summary>
    /// A delegate type for hooking up panel state change notifications.
    /// </summary>
    public delegate void PanelStateChangedEventHandler(object sender, PanelEventArgs e);
    #endregion

    #region PanelEventArgs class
    /// <summary>
    /// 
    /// </summary>
    public class PanelEventArgs : System.EventArgs
    {
        #region Private Class data
        private CollapsiblePanel panel;
        #endregion

        #region Public Constructors
        /// <summary>
        /// Initialises a new <see cref="PanelEventArgs">PanelEventArgs</see>.
        /// </summary>
        /// <param name="sender">The originating <see cref="CollapsiblePanel">CollapsiblePanel</see>.</param>
        public PanelEventArgs(CollapsiblePanel sender)
        {
            this.panel = sender;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the <see cref="CollapsiblePanel">CollapsiblePanel</see> that triggered the event.
        /// </summary>
        public CollapsiblePanel CollapsiblePanel
        {
            get
            {
                return this.panel;
            }
        }

        /// <summary>
        /// Gets the <see cref="PanelState">PanelState</see> of the <see cref="CollapsiblePanel">CollapsiblePanel</see> that triggered the event.
        /// </summary>
        public PanelState PanelState
        {
            get
            {
                return this.panel.PanelState;
            }
        }
        #endregion
    }
    #endregion

	
}
