using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// frmExportToRtf 的摘要说明。
	/// </summary>
	public class frmExportToRtf : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolBarButton tbPrint;
		private System.Windows.Forms.ToolBarButton tbExit;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton tbOut;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.ComponentModel.IContainer components;

		public frmExportToRtf()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmExportToRtf));
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbPrint = new System.Windows.Forms.ToolBarButton();
			this.tbOut = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbExit = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(0, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(800, 1000);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.richTextBox1.WordWrap = false;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton3,
																						this.toolBarButton2,
																						this.tbPrint,
																						this.tbOut,
																						this.toolBarButton1,
																						this.tbExit});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(576, 41);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbPrint
			// 
			this.tbPrint.ImageIndex = 0;
			this.tbPrint.Text = "打印";
			// 
			// tbOut
			// 
			this.tbOut.ImageIndex = 2;
			this.tbOut.Text = "Word";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbExit
			// 
			this.tbExit.ImageIndex = 1;
			this.tbExit.Text = "退出";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.richTextBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(576, 468);
			this.panel1.TabIndex = 2;
			// 
			// frmExportToRtf
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(576, 509);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Name = "frmExportToRtf";
			this.Text = "输出方式1";
			this.Load += new System.EventHandler(this.frmExportToRtf_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// 包含控件
		/// </summary>
		public Control ContainerControl
		{
			set
			{
				int Height = value.Height;
				this.richTextBox1.Height = Height;
				string s = "                                                                                                                                    \n";
				string ss = "";
				for(int i=0;i<Height/15;i++)
				{
					ss = ss+s;
				}
				this.richTextBox1.Text = ss;
				this.Draw(this.richTextBox1,value);

				//this.RemoveChar();
			}
		}
		private void RemoveChar()
		{
			for(int i=richTextBox1.TextLength;i>=0;i--)
			{
				this.richTextBox1.Select(i,1);
				if(this.richTextBox1.SelectedText == "@" )
				{
					this.richTextBox1.SelectedText = " ";
				}
			}
			
		}
		int allTop =0;

		#region 函数
			
		private void GetOffSet(Control c)
		{
			if(c.Parent != null && c.Parent!=this.CurrentForm)
			{
				offsetX += c.Parent.Left;offsetY += c.Parent.Top;	
				if(c.Parent!=null) GetOffSet(c.Parent);
			}
		}

		#region 画窗口
		int offsetX =0;
		int offsetY =0;
		int iPageHeight = 5000;
		int page = 0;
		Control CurrentForm;
		/// <summary>
		/// 画背景
		/// </summary>
		/// <param name="g"></param>
		/// <param name="form"></param>
		/// <param name="page"></param>
		private void Draw(RichTextBox g,Control form)
		{
			allTop =0;			
			
			this.CurrentForm = form;
			this.DrawForm(g,form);
		}
		/// <summary>
		/// 画容器
		/// </summary>
		/// <param name="g"></param>
		/// <param name="form"></param>
		/// <param name="page"></param>
		private void DrawForm(RichTextBox g,Control form)
		{

			if(form.Container != null)
			{
				foreach(Component m in form.Container.Components)
				{
					Control c= m as Control;
					if(c != null && c.Visible)
					{
						offsetX = 0;offsetY = 0;
						GetOffSet(c);//获得位移							
						if((c.Top+offsetY  >= page * iPageHeight && c.Top <(page+1) * iPageHeight) || (c.Top +offsetY +c.Height > page *iPageHeight && c.Top+offsetY  <= page*iPageHeight ))
						{
							allTop = c.Top -(page *iPageHeight);
									
							this.DrawControl(c,g,allTop);
						}
						
					}
				}

			
			}
			else
			{
				foreach(Control c in form.Controls)
				{
					if(c != null && c.Visible )
					{
						try
						{
							offsetX = 0;offsetY = 0 ;
							GetOffSet(c);//获得位移
							if((c.Top+offsetY  >= page * iPageHeight && c.Top <(page+1) * iPageHeight) || (c.Top+offsetY  +c.Height > page *iPageHeight && c.Top +offsetY <= page*iPageHeight ))
							{
								allTop = c.Top -(page *iPageHeight);
								this.DrawControl(c,g,allTop);
							}
							if(c.Controls.Count>0) 
							{
								this.DrawForm(g,c);
							}
							
						}
						catch{}
					}
				}
			}
		}
		
		/// <summary>
		/// 画控件
		/// </summary>
		/// <param name="c"></param>
		/// <param name="g"></param>
		/// <param name="allTop"></param>
		protected void DrawControl(Control c,RichTextBox g,int allTop)
		{
			//控件不显示不画
			if(c.Visible == false) return;

			#region 
			string strType = c.GetType().ToString().Substring(c.GetType().ToString().LastIndexOf(".") + 1);
			
			int ControlLeft =c.Left+offsetX;
			int ControlTop = allTop+offsetY;
			int ControlWidth = c.Width;
			int ControlHeight = c.Height;

			//ButtonState bState =ButtonState.All;
			int iFill =0;
			int ControlBackWidth =0;
			int ControlBackHeight =0;
		
		
			ControlBackWidth = c.Width-(iFill*2) ;
			ControlBackHeight = c.Height -(iFill*2);
			
			int ControlBackLeft =c.Left+iFill+offsetX;
			int ControlBackTop = allTop+iFill+offsetY;
			
			
			if(iFill<0)
			{
				//ControlBackWidth = c.Width;//-(iFill*2);
				ControlBackHeight =c.Height;
			}

			//如果控件高度小于零
			if(ControlBackHeight <= 0)
			{
				ControlBackHeight =c.Height;
			}
			//如果控件宽度
			if(ControlBackWidth <= 0)
			{
				ControlBackWidth =c.Width;
			}
			
			int ControlForeLeft =c.Left +iFill+2 +offsetX;
			int ControlForeTop = allTop+iFill+3 +offsetY;
		
			#endregion
			try
			{
				//是表格不画子控件
				if(c.Parent!=null && c.Parent.GetType().ToString() == "classControl.ucGrid")
					return;

			}
			catch{}

			//非打印控件
			if(c.Tag !=null && c.Tag.ToString() == "EMRGRIDLINE") return;
			
			if(strType=="GroupBox" || strType =="emrGroupBox" )
			{
			}
			else if(strType=="PictureBox" || strType =="emrPictureBox" || strType =="emrImage" )
			{
				
			}
			else if(strType=="Panel" || strType =="emrPanel"  )
			{
			}
			else if(strType=="TabPage" || strType =="TabControl" )
			{
				
			}
			else if( strType =="emrLine")
			{
				string strLine = "-";
				this.DrawString(strLine.PadRight(ControlBackWidth),c.Font,c.BackColor,ControlForeLeft,ControlForeTop+ControlHeight);
			}
			else if(strType=="RichTextBox" || strType =="emrMultiLineTextBox" )
			{
				Neusoft.FrameWork.WinForms.Controls.RichTextBox linkRTB = c as Neusoft.FrameWork.WinForms.Controls.RichTextBox;
				
				RichTextBox t = c as RichTextBox;
				
				string oldText = t.Text;
				//如果是linkRTB
				if(linkRTB!=null)
				{
					oldText = linkRTB.SuperText;
					t.Text = linkRTB.Text;
				}

				
				t.Text = t.Text.TrimEnd();
				t.Text = t.Text.TrimEnd('\n');

				RectangleF r ;
				int x =0,y=0;
				int ioffsetY = t.GetPositionFromCharIndex(0).Y;
				y = t.GetPositionFromCharIndex(t.TextLength-1).Y - ioffsetY;
				t.Select(0,0);
				t.ScrollToCaret();
				Graphics mg = this.CreateGraphics();
				#region 多行文本框
				
			{
				if(y+(int)mg.MeasureString("李",t.Font).Height+2>ControlHeight)
				{
					ControlHeight = y+(int)mg.MeasureString("李",t.Font).Height+2;
					//this.allOffsetY = ControlHeight - c.Height;
						
				}
				//忘记为什么从最后开始计算
				for(int iTextLength =0;iTextLength<t.TextLength;iTextLength++)//for(int iTextLength =t.TextLength-1;iTextLength>=0;iTextLength--)
				{
					t.Select(0,0);
					Point point = t.GetPositionFromCharIndex(iTextLength);
					x = point.X;
					y = point.Y;
					y = y - ioffsetY;
					t.Select(iTextLength,1);
					r = new RectangleF(ControlForeLeft+x,ControlForeTop+y,mg.MeasureString(t.SelectedText,t.Font).Width,mg.MeasureString(t.SelectedText,t.Font).Height);
					this.DrawString(t.SelectedText,t.SelectionFont,t.SelectionColor,(int)r.Left,(int)r.Bottom);
				}
			}
				
				#endregion

				if(linkRTB!=null)
				{
					linkRTB.SuperText = oldText;
				}
			}
			else if(strType =="FpSpread")
			{
				#region farpoint
				//				FarPoint.Win.Spread.FpSpread t = c as FarPoint.Win.Spread.FpSpread;
				//				
				//				Rectangle rect = new Rectangle(ControlLeft ,ControlTop ,ControlWidth,ControlHeight);//ControlWidth,ControlHeight );
				//				FarPoint.Win.Spread.PrintInfo printinfo = new FarPoint.Win.Spread.PrintInfo();
				//				for(int iSheet=0;iSheet<t.Sheets.Count;iSheet++)
				//				{
				//					
				//					printinfo.ShowRowHeaders = t.Sheets[iSheet].RowHeader.Visible;
				//					printinfo.ShowColumnHeaders = t.Sheets[iSheet].ColumnHeader.Visible;
				//					t.Sheets[iSheet].PrintInfo = printinfo;
				//				}
				//				int iCount = t.GetOwnerPrintPageCount(g,rect,0);
				//				if(maxpage <iCount) maxpage =iCount; //为多个farpoint打印用的
				//				if(addpage ==0 && maxpage == iCount)
				//				{
				//					addpage = 1;
				//				}
				//				if(addpage<=iCount)
				//				{
				//					t.OwnerPrintDraw(g,rect,0,addpage);
				//					addpage++;
				//				}
				//				if(addpage>maxpage)
				//				{
				//					addpage = 0;
				//				}
				#endregion
			}
			else if(strType.IndexOf("SpreadView")>=0 ||  strType =="HScrollBar" || strType =="VScrollBar" ||strType.IndexOf("ScrollBar")>=0)//strType.IndexOf("SpreadView")>=0 || strType.IndexOf("ScrollBar")>=0)//去掉fpscroll
			{

			}
			else if(strType =="DataGrid")
			{
				
				
			}
			
			else if(strType =="Button")
			{
			}
			else if(strType== ("emrGrid")  || strType =="ucGrid")
			{
			}
			else if(strType =="Form")
			{

			}
			else if(strType =="ucDiseaseRecord")
			{

			}
			else 
			{
				if(c.Text!="")
					this.DrawString(c.Text,c.Font ,c.ForeColor,ControlForeLeft,ControlForeTop+ControlHeight);
			}
		}
		
		#endregion
		
		#endregion

		private void DrawString(string text,Font font,Color foreColor,int x,int y)
		{
			int iIndex = this.richTextBox1.GetCharIndexFromPosition(new Point(x,y));
			this.richTextBox1.Select(iIndex,1);
			this.richTextBox1.SelectedText = text;
			this.richTextBox1.Select(iIndex,text.Length);
			this.richTextBox1.SelectionFont = font;
			this.richTextBox1.SelectionColor = foreColor;

		}

		private void frmExportToRtf_Load(object sender, System.EventArgs e)
		{
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbPrint)
			{
				Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
				p.IsDataAutoExtend = false;
				p.PrintPreview(this.panel1);
			}
			else if(e.Button == this.tbExit)
			{
				this.Close();
			}
			else if(e.Button == this.tbOut)
			{
				SaveFileDialog F = new SaveFileDialog();
				F.Filter = "word文件|*.rtf";
				if(F.ShowDialog ()== DialogResult.OK)
				{
					if(F.FileName.IndexOf(".rtf")<=0)
						F.FileName = F.FileName = ".rtf";
					this.richTextBox1.SaveFile(F.FileName);
				}
			}
		}
	}
}
