using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
	#region CollapsiblePanelBar class
	// <fix>Implemented System.ComponentModel.ISupportInitialize interface to fix run-time/design-time ordering problem.
	// <version>1.2</version>
	// </date>21-Oct-2002</date>
	// <source>Russell Morris (mailto:russell@russellsprojects.com)
	// </fix>
	/// <summary>
	/// An ExplorerBar-type extended Panel for containing <see cref="CollapsiblePanel">CollapsiblePanel</see> objects.
	/// </summary>
	public class CollapsiblePanelBar : System.Windows.Forms.Panel, System.ComponentModel.ISupportInitialize
	{
		#region Private class data
		private CollapsiblePanelCollection panels = new CollapsiblePanelCollection();
		private int border = 8;
		private int spacing = 8;
		private bool initialising = false;
		#endregion
		
		public event LinkLabelLinkClickedEventHandler LinkClick;
		#region Public Constructors
		/// <summary>
		/// Initialises a new instance of <see cref="Salamander.Windows.Forms.CollapsiblePanelBar">CollapsiblePanelBar</see>.
		/// </summary>
		public CollapsiblePanelBar() : base()
		{
			InitializeComponent();

			//this.AutoScroll = true;
			this.BackColor = Color.CornflowerBlue;
            this.AutoScroll = true;
		}
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			// 
			// CollapsiblePanelBar
			// 
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the <see cref="CollapsiblePanelCollection">CollapsiblePanelCollection</see> collection.
		/// </summary>
		[Browsable(false)]
		public CollapsiblePanelCollection CollapsiblePanelCollection
		{
			get
			{
				return this.panels;
			}
		}

		/// <summary>
		/// Gets/sets the border around the panels. 
		/// </summary>
		public int Border
		{
			get
			{
				return this.border;
			}
			set
			{
				this.border = value;
				UpdatePositions(this.panels.Count - 1);
			}
		}

		/// <summary>
		/// Gets/sets the vertical spacing between adjacent panels.
		/// </summary>
		public int Spacing
		{
			get
			{
				return this.spacing;
			}
			set
			{
				this.spacing = value;
				UpdatePositions(this.panels.Count - 1);
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Signals the object that initialization is starting.
		/// </summary>
		public void BeginInit()
		{
			this.initialising = true;
		}

		/// <summary>
		/// Signals the object that initialization is complete.
		/// </summary>
		public void EndInit()
		{
			this.initialising = false;
		}
		#endregion
		
		#region Private Helper Functions
		private void UpdatePositions(int index)
		{
			for(int i = index; i >= 0; i--)
			{
				// Update the panel locations.
				if(i == this.panels.Count - 1)
				{
					// Top panel.
					this.panels.Item(i).Top = this.border;
				}
				else
				{
					this.panels.Item(i).Top = this.panels.Item(i + 1).Bottom + this.border;
				}
				// Update the panel widths.
				this.panels.Item(i).Left = this.spacing;
				this.panels.Item(i).Width = this.Width - (2 * this.spacing);
				// <feature>Panel width adjusted when vertical scroll bars are present.
				// <version>1.3</version>
				// <date>23-Oct-2002</date>
				if(true == this.VScroll)
				{
					this.panels.Item(i).Width -= SystemInformation.VerticalScrollBarWidth;
				}
				// </feature>
			}
            try
            {
                if (this.panels.Count > 0)
                {
                    for (int i = index; i < this.panels.Count; i++)
                        this.panels.Item(i).Width = this.panels.Item(0).Width;
                }
            }
            catch { }

		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Event handler for the <see cref="Control.ControlAdded">ControlAdded</see> event.
		/// </summary>
		/// <param name="e">A <see cref="System.Windows.Forms.ControlEventArgs">ControlEventArgs</see> that contains the event data.</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);

            // <fix>Changed type check to allow for derived CollapsiblePanels
            // <version>1.4</version>
            // <date>19-Dec-2002</date>
            // <source>flipdoubt (mailto:d.smith@ceoimage.com)
			if(e.Control is CollapsiblePanel)
            // </fix>
			{
				// Adjust the docking property to Left | Right | Top
				e.Control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

				// <fix>Implemented System.ComponentModel.ISupportInitialize interface to fix run-time/design-time ordering problem.
				// <version>1.2</version>
				// </date>21-Oct-2002</date>
				// <source>Russell Morris (mailto:russell@russellsprojects.com)
				if(true == initialising)
				{
					// In the middle of InitializeComponent call.
					// Generated code adds panels in reverse order, so add to end
					this.panels.Add((CollapsiblePanel)e.Control);

					this.panels.Item(this.panels.Count - 1).PanelStateChanged +=
						new Neusoft.FrameWork.WinForms.Controls.PanelStateChangedEventHandler(this.panel_StateChanged);
				}
				else
				{
					// Add the panel to the beginning of the internal collection.
					panels.Insert(0, (CollapsiblePanel)e.Control);

					panels.Item(0).PanelStateChanged += 
						new Neusoft.FrameWork.WinForms.Controls.PanelStateChangedEventHandler(this.panel_StateChanged);
				}
				// </fix>

				// Update the size and position of the panels
				UpdatePositions(this.panels.Count - 1);
			}
		}

		/// <summary>
		/// Event handler for the <see cref="Control.ControlRemoved">ControlRemoved</see> event.
		/// </summary>
		/// <param name="e">A <see cref="System.Windows.Forms.ControlEventArgs">ControlEventArgs</see> that contains the event data.</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);

            // <fix>Changed type check to allow for derived CollapsiblePanels
            // <version>1.4</version>
            // <date>19-Dec-2002</date>
            // <source>flipdoubt (mailto:d.smith@ceoimage.com)
            if(e.Control is CollapsiblePanel)
            // </fix>
            {
				// Get the index of the panel within the collection.
				int index = this.panels.IndexOf((CollapsiblePanel)e.Control);
				if(-1 != index)
				{
					// Remove this panel from the collection.
					this.panels.Remove(index);
					// Update the position of any remaining panels.
					UpdatePositions(this.panels.Count - 1);
				}
			}
		}
		#endregion

		#region Event handlers
		private void panel_StateChanged(object sender, PanelEventArgs e)
		{
			// Get the index of the control that just changed state.
			int index = this.panels.IndexOf(e.CollapsiblePanel);
			if(-1 != index)
			{
				// Now update the position of all subsequent panels
                //wolf modified.
                UpdatePositions(--index);//UpdatePositions(--index);
			}
		}
		#endregion

		#region Customs

		int iIndex = -1;
		/// <summary>
		/// 添加panel
		/// </summary>
		/// <param name="panel"></param>
		public void AddPanel(CollapsiblePanel panel)
		{
			iIndex ++;
			panel.TabIndex = iIndex;
			panel.LinkClick+=new LinkLabelLinkClickedEventHandler(panel_LinkClick);
			panel.PanelStateChanged+=new PanelStateChangedEventHandler(panel_PanelStateChanged);

			this.Controls.Add(panel);
		}

		/// <summary>
		/// 添加panel
		/// </summary>
		/// <param name="panel"></param>
		public CollapsiblePanel AddPanel(string text,object tag)
		{
			iIndex ++;
			CollapsiblePanel panel = new CollapsiblePanel();
			panel.TitleText = text;
			panel.Tag = tag;
			panel.TabIndex = iIndex;
			
			panel.LinkClick+=new LinkLabelLinkClickedEventHandler(panel_LinkClick);
			panel.PanelStateChanged+=new PanelStateChangedEventHandler(panel_PanelStateChanged);
			this.Controls.Add(panel);
			return panel;
		}

		/// <summary>
		/// 添加panel
		/// </summary>
		/// <param name="panel"></param>
		public CollapsiblePanel AddPanel(string text)
		{
			return this.AddPanel(text,null);
		}
		/// <summary>
		/// 添加节点
		/// </summary>
		/// <param name="iPanel"></param>
		/// <param name="text"></param>
		/// <param name="tag"></param>
		public int AddNode(int iPanel,string text,object tag,Image image)
		{
			foreach(CollapsiblePanel panel in this.CollapsiblePanelCollection)
			{
				if(panel.TabIndex == iPanel)
				{
					panel.AddNode(text,tag,image);
					return 0;
				}
			}

			return -1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="iPanel"></param>
		/// <param name="text"></param>
		/// <param name="tag"></param>
		/// <returns></returns>
		public int AddNode(int iPanel,string text,object tag)
		{
			return this.AddNode(iPanel,text,tag,null);
		}
		/// <summary>
		/// 清除
		/// </summary>
		public void Clear()
		{
			iIndex =-1;
			this.Controls.Clear();
			this.CollapsiblePanelCollection.Clear();
		}

		/// <summary>
		/// 清空
		/// </summary>
		/// <param name="iPanel"></param>
		public void ClearNode(int iPanel)
		{
			foreach(CollapsiblePanel panel in this.CollapsiblePanelCollection)
			{
				if(panel.TabIndex == iPanel)
				{
					 panel.Clear();
				}
			}
		}
		#endregion

		private void panel_LinkClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(LinkClick!=null)
				LinkClick(sender,e);
		}

		public void CollapsedAll()
		{
			foreach(CollapsiblePanel panel in this.CollapsiblePanelCollection)
			{
				panel.PanelState = PanelState.Collapsed;
			}
			
		}

		protected bool myisExpendOne = true;
		/// <summary>
		/// 是否只打开一个
		/// </summary>
		/// <returns></returns>
		public bool IsExpendOne
		{
			get
			{
				return myisExpendOne;
			}
			set
			{
				myisExpendOne = value;
			}
		}

		bool bChange = false;
		private void panel_PanelStateChanged(object sender, PanelEventArgs e)
		{
			if(bChange) return;
			foreach(CollapsiblePanel panel in this.CollapsiblePanelCollection)
			{
				if(panel.TabIndex !=((CollapsiblePanel)sender).TabIndex)
				{
					if(panel.PanelState != PanelState.Collapsed)
					{
						bChange = true;
						panel.PanelState = PanelState.Collapsed;
						bChange = false;
					}
				}
			}
		}
	}
	#endregion
}
