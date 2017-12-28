using System;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
namespace Neusoft.FrameWork.WinForms.Classes
{
	/// <summary>
	///'**********************************************
	///'
	///'  build the xsl file from the xml 
	///'
	///'  Written by wolf in 2003-5
	///'  
	///   modified in 2005-6
	///' ********************************************
	/// </summary>
	public class XslFromFile
	{
		public XslFromFile(string xmlFile)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.LoadXml(xmlFile);
			}
			catch{return;}
			mainPanel = doc.SelectSingleNode("Template/Object/Object");
		}
		/// <summary>
		/// form panel for build
		/// </summary>
		protected XmlNode mainPanel = null;
		protected int offsetX =0;
		protected int offsetY =0;
		protected int allTop =0;
		protected double rate  = 1.2;
		protected  string xsl = "xsl:";
		/// <summary>
		/// 输出文本
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public int OutPut(string FileName)
		{
			WriteHead("");// 'write header
			WriteBody("/");// 'write body
			
			this.DrawForm(mainPanel);
			string s ;
			s = xslDoc.OuterXml;
			s = s.Replace("xsl-", xsl);
			return CreateTextFile(FileName, s);
		}
		protected int CreateTextFile(string strFileName , string sContent)
		{
			TextWriter output ;
			string strTempFileName  = strFileName;
			try
			{
				output = File.CreateText(strTempFileName);
				output.Write(sContent);

			}
			catch(Exception ex)
			{
				MessageBox.Show (ex.Message);
				return -1;
			}
			try
			{
				output.Close();
			}
			catch{}
			return 0;
		}
		#region 画
		
		/// <summary>
		/// 画容器
		/// </summary>
		/// <param name="form"></param>
		private void DrawForm(XmlNode form)
		{
			foreach(XmlNode c in form.ChildNodes)
			{
				if(c != null && c.Name =="Object")//visible
				{
					try
					{

						
						allTop = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c,"Location"),1));

						this.DrawControl(c,allTop);//画控件
					
						if(c.ChildNodes.Count>0) 
						{
							offsetX = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c,"Location"),0)) +offsetX;
							offsetY = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c,"Location"),1)) +offsetY;
							if(offsetY<0) offsetY =0;
							this.DrawForm(c);//递归查找
						
							offsetX = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c.ParentNode,"Location"),0));
							offsetY = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c.ParentNode,"Location"),1)); 
							if(offsetY<0) offsetY =0;
						}
					}
					catch{}
				}
			}
		}

		private string GetProperty(XmlNode nodeControl,string propertyName)
		{
			foreach(XmlNode node in nodeControl.ChildNodes)
			{
				if(node.Attributes["name"].Value == propertyName)
				{
					return node.InnerText;
				}
			}
			if(propertyName == "Location" || propertyName =="Size")
				return "100,100";

			if(propertyName=="Checked")
				return "True";

			return "";
		}
		private string GetTextByDot(string text,int i)
		{
			string[] s = text.Split(',');
			try
			{
				return s[i];
			}
			catch{return "";}
		}
		/// <summary>
		/// 画控件
		/// </summary>
		/// <param name="c"></param>
		/// <param name="allTop"></param>
		protected void DrawControl(XmlNode c,int allTop)
		{
			//控件不显示不画
			//if(this.GetProperty(c,"Visible")== "False") return;
			#region 
			string strType = c.Attributes["name"].Value.Substring(c.Attributes["name"].Value.LastIndexOf(".") + 1);
			
			int iFill =0;

			iFill = -2;
			
			Control myControl = new Control();
			myControl.Top =Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c,"Location"),1));
			myControl.Left =Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c,"Location"),0));
			myControl.Width =Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c,"Size"),0));
			myControl.Height =Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetTextByDot(this.GetProperty(c,"Size"),1));
			myControl.Text =(this.GetProperty(c,"Text"));
			myControl.BackColor = Color.White;
			//myControl.ForeColor 
			//myControl Font

			int ControlLeft =myControl.Left+offsetX;
			int ControlTop = allTop+offsetY;
			int ControlWidth = myControl.Width;
			int ControlHeight = myControl.Height;

			int ControlBackLeft =myControl.Left+iFill+offsetX;
			int ControlBackTop = allTop+iFill+offsetY;
			
			int ControlBackWidth = myControl.Width-(iFill*2) + 2;
			int ControlBackHeight =myControl.Height -(iFill*2);

			if(iFill<0)
			{
				ControlBackWidth = myControl.Width -(iFill*2)+2;
				ControlBackHeight = myControl.Height;
			}
			
			int ControlForeLeft = myControl.Left+iFill+2 +offsetX;
			int ControlForeTop = allTop+iFill+3 +offsetY;
		
			#endregion
			if(strType.IndexOf("Label")>=0 )
			{
				strType = "label";
				Trans(strType,"",myControl.Text,ControlLeft,ControlTop,ControlWidth,ControlHeight,myControl.ForeColor.ToArgb().ToString(),myControl.BackColor.ToArgb().ToString(),"0",myControl.Font.FontFamily.Name.ToString(),myControl.Font.Size.ToString(),myControl.Font.Unit.GetTypeCode().ToString(),myControl.Font.Style.GetTypeCode().ToString(),myControl.Text );
			}
			else if(strType.IndexOf("CheckBox")>=0 || strType.IndexOf("RadioButton")>=0)
			{
				strType = "checkbox";
				string strCheck = this.GetProperty(c,"Checked").ToLower();

				Trans(strType,myControl.Name ,myControl.Text,ControlLeft,ControlTop,ControlWidth,ControlHeight,myControl.ForeColor.ToArgb().ToString(),myControl.BackColor.ToArgb().ToString(),"0",myControl.Font.FontFamily.Name.ToString(),myControl.Font.Size.ToString(),myControl.Font.Unit.GetTypeCode().ToString(),myControl.Font.Style.GetTypeCode().ToString(),strCheck);
			}
			else if(strType.IndexOf("GroupBox")>=0)
			{
				strType = "groupbox";
				Trans(strType,myControl.Name,"",ControlLeft,ControlTop,ControlWidth,ControlHeight,myControl.ForeColor.ToArgb().ToString(),myControl.BackColor.ToArgb().ToString(),"0",myControl.Font.FontFamily.Name.ToString(),myControl.Font.Size.ToString(),myControl.Font.Unit.GetTypeCode().ToString(),myControl.Font.Style.GetTypeCode().ToString(),"");
			}
			else if(strType.IndexOf("PictureBox")>=0)
			{
//				strType = "image";
//				PictureBox t=c as PictureBox;
//				Trans(strType,c.Name,c.Tag.ToString() ,ControlLeft,ControlTop,ControlWidth,ControlHeight,c.ForeColor.ToArgb().ToString(),c.BackColor.ToArgb().ToString(),"0",c.Font.FontFamily.Name.ToString(),c.Font.Size.ToString(),c.Font.Unit.GetTypeCode().ToString(),c.Font.Style.GetTypeCode().ToString(),c.Tag.ToString() );
			}
			else if(strType.IndexOf("Panel")>=0)
			{
			}
			else if(strType.IndexOf("TabPage")>=0 || strType.IndexOf("TabControl")>=0)
			{
				
			}
			else if(strType.IndexOf("RichTextBox")>=0 || strType.IndexOf("emrMultiLineTextBox")>=0)
			{
				strType = "multilinebox";
				string strRtf = this.GetProperty(c,"Rtf");
				Trans(strType,myControl.Name,myControl.Text,ControlLeft,ControlTop,ControlWidth,ControlHeight,myControl.ForeColor.ToArgb().ToString(),myControl.BackColor.ToArgb().ToString(),"0",myControl.Font.FontFamily.Name.ToString(),myControl.Font.Size.ToString(),myControl.Font.Unit.GetTypeCode().ToString(),myControl.Font.Style.GetTypeCode().ToString(),strRtf );
			}
			else if(strType.IndexOf("FpSpread")>=0)//farpoint Spread
			{
				
			}
			else if(strType.IndexOf("SpreadView")>=0 || strType.IndexOf("ScrollBar")>=0)//去掉fpscroll
			{

			}
			else if(strType.IndexOf("DataGrid")>=0)//DataGrid
			{
				
			}
			else if(strType.IndexOf("Chart")>=0)
			{
				

			}
			else if(strType.IndexOf("DateTimeBox")>=0)
			{

				Trans(strType,"",myControl.Text,ControlLeft,ControlTop,ControlWidth,ControlHeight,myControl.ForeColor.ToArgb().ToString(),myControl.BackColor.ToArgb().ToString(),"0",myControl.Font.FontFamily.Name.ToString(),myControl.Font.Size.ToString(),myControl.Font.Unit.GetTypeCode().ToString(),myControl.Font.Style.GetTypeCode().ToString(),myControl.Text);
			}
			else if(strType.IndexOf("Button")>=0)//不打印按钮
			{
			}
			else if(strType.IndexOf("emrGrid")>=0) //自定义表格
			{
//				EPRControl.emrGrid t = c as EPRControl.emrGrid;
//				string[] l;
//				string[] s ;
//				Rectangle r = new Rectangle(ControlLeft,ControlTop,ControlWidth,ControlHeight);
//				//画背景
//				Trans("line","","",r.Left ,r.Top ,r.Width ,r.Height,c.ForeColor.ToArgb().ToString(),t.BackColor.ToArgb().ToString(),"0",c.Font.FontFamily.Name.ToString(),c.Font.Size.ToString(),c.Font.Unit.GetTypeCode().ToString(),c.Font.Style.GetTypeCode().ToString(),"");
//				//画边框
//				Trans("line","","",ControlLeft,ControlTop,ControlWidth,4,c.ForeColor.ToArgb().ToString(),Color.Black.ToArgb().ToString(),"0",c.Font.FontFamily.Name.ToString(),c.Font.Size.ToString(),c.Font.Unit.GetTypeCode().ToString(),c.Font.Style.GetTypeCode().ToString(),"");
//				Trans("line","","",ControlLeft,ControlTop+ControlHeight - 4,ControlWidth,4,c.ForeColor.ToArgb().ToString(),Color.Black.ToArgb().ToString(),"0",c.Font.FontFamily.Name.ToString(),c.Font.Size.ToString(),c.Font.Unit.GetTypeCode().ToString(),c.Font.Style.GetTypeCode().ToString(),"");
//				Trans("line","","",ControlLeft,ControlTop,4,ControlHeight,c.ForeColor.ToArgb().ToString(),Color.Black.ToArgb().ToString(),"0",c.Font.FontFamily.Name.ToString(),c.Font.Size.ToString(),c.Font.Unit.GetTypeCode().ToString(),c.Font.Style.GetTypeCode().ToString(),"");
//				Trans("line","","",ControlLeft+ControlWidth-4,ControlTop,4,ControlHeight,c.ForeColor.ToArgb().ToString(),Color.Black.ToArgb().ToString(),"0",c.Font.FontFamily.Name.ToString(),c.Font.Size.ToString(),c.Font.Unit.GetTypeCode().ToString(),c.Font.Style.GetTypeCode().ToString(),"");
//
//				l = t.saveDrawing();
//				for(int m =0 ;m<l.Length;m++)
//				{
//					s = l[m].Split(',');
//					int left,top,width,height;
//					if(int.Parse(s[0].ToString())<0)
//					{
//						s[2] = (int.Parse(s[2])+int.Parse(s[0])).ToString();
//						s[0] = "0";
//					}
//					left = int.Parse(s[0])+ControlLeft;
//					if(int.Parse(s[1])<0)
//					{
//						s[3] =(int.Parse(s[3])+int.Parse(s[1])).ToString();
//						s[1] = "0";
//					}
//					top =int.Parse(s[1]) + ControlTop;
//					if (int.Parse(s[2])+int.Parse(s[0])>ControlWidth) s[2] = (ControlWidth -int.Parse(s[0])).ToString();
//					width = int.Parse(s[2]);
//					if (int.Parse(s[3])+int.Parse(s[1])>ControlWidth) s[3] = (ControlHeight -int.Parse(s[1])).ToString();
//					height = int.Parse(s[3]);
//					Trans("line","","",left,top,width,height,c.ForeColor.ToArgb().ToString(),Color.Black.ToArgb().ToString(),"0",c.Font.FontFamily.Name.ToString(),c.Font.Size.ToString(),c.Font.Unit.GetTypeCode().ToString(),c.Font.Style.GetTypeCode().ToString(),"");
//				}
			}
			else if(strType.IndexOf("ermLine")>=0) //线
			{
				Trans("line","","",ControlLeft,ControlTop,ControlWidth,ControlHeight,myControl.ForeColor.ToArgb().ToString(),myControl.BackColor.ToArgb().ToString(),"0",myControl.Font.FontFamily.Name.ToString(),myControl.Font.Size.ToString(),myControl.Font.Unit.GetTypeCode().ToString(),myControl.Font.Style.GetTypeCode().ToString(),"");
			}
			else
			{
				Trans(strType,myControl.Name,myControl.Text,ControlLeft,ControlTop,ControlWidth,ControlHeight,myControl.ForeColor.ToArgb().ToString(),myControl.BackColor.ToArgb().ToString(),"0",myControl.Font.FontFamily.Name.ToString(),myControl.Font.Size.ToString(),myControl.Font.Unit.GetTypeCode().ToString(),myControl.Font.Style.GetTypeCode().ToString(),myControl.Text);
			}
		}
	
		#endregion
		protected XmlDocument xslDoc = new XmlDocument();
		protected XmlElement elements ;
		protected XmlComment commenet;
		protected XmlElement element ;
		protected XmlText description ;
		protected XmlCDataSection cdata;
		protected XmlAttribute attr;
		protected XmlElement RootElement;
		#region Xsl
		protected void WriteHead(string sTitle)
		{
			XmlElement CRootElement;
			XmlElement CElement;
			XmlElement htmlElement;

			xslDoc = new XmlDocument();
			xslDoc.PreserveWhitespace =false;

			//生成xsl的头
			xslDoc.AppendChild(xslDoc.CreateXmlDeclaration("1.0", "", ""));
			RootElement = xslDoc.CreateElement("xsl-stylesheet"); //根
			RootElement.SetAttribute("xmlns:xsl", "http://www.w3.org/1999/XSL/Transform");
			RootElement.SetAttribute("version", "1.0");
			xslDoc.AppendChild(RootElement);

			element = xslDoc.CreateElement("xsl-output");
			element.SetAttribute("method", "html");
			RootElement.AppendChild(element);

			element = xslDoc.CreateElement("xsl-template");
			element.SetAttribute("match", "/");
			htmlElement = xslDoc.CreateElement("html");
			element.AppendChild(htmlElement);
			CElement = xslDoc.CreateElement("head");
			htmlElement.AppendChild(CElement);
			CRootElement = CElement;
			CElement = xslDoc.CreateElement("title");
			CRootElement.AppendChild(CElement);
			CRootElement = CElement;
			if( sTitle == "" )
			{
				//'备用title
			}
			else
			{
				CElement = xslDoc.CreateElement("xsl-value-of");
				CElement.SetAttribute("select", sTitle);
				CRootElement.AppendChild(CElement);
			}		
			CElement = xslDoc.CreateElement("xsl-apply-templates");
			htmlElement.AppendChild(CElement);
			RootElement.AppendChild(element);
		}
		//write body
		private void WriteBody(string sBody)
		{

			XmlElement CRootElement ;
			element = xslDoc.CreateElement("xsl-template");
			if(sBody!="")
				element.SetAttribute("match", sBody);
			CRootElement = xslDoc.CreateElement("body");

			element.AppendChild(CRootElement);
			RootElement.AppendChild(element);
			RootElement = CRootElement; //根结点为body
		}
		/// <summary>
		/// 画xsl
		/// </summary>
		/// <param name="sType"></param>
		/// <param name="sName"></param>
		/// <param name="sText"></param>
		/// <param name="sX"></param>
		/// <param name="sY"></param>
		/// <param name="sWidth"></param>
		/// <param name="sHeight"></param>
		/// <param name="sForeColor"></param>
		/// <param name="sBackColor"></param>
		/// <param name="sStyle"></param>
		/// <param name="sFontName"></param>
		/// <param name="sFontSize"></param>
		/// <param name="sFontUnit"></param>
		/// <param name="sFontStyle"></param>
		/// <param name="sValue"></param>
		protected void Trans(
			string sType,//类型
			string sName,
			string sText ,
			int sX ,
			int sY,
			int sWidth,
			int sHeight,
			string sForeColor,
			string sBackColor,
			string sStyle,
			string sFontName,
			string sFontSize,
			string sFontUnit, 
			string sFontStyle,
			string sValue)
		{
			//***************valid**********************

			if(sType == "Panel") return ;

			//******************变量声明****************
			XmlElement xslTableElement;
			XmlElement xslTrElement;
			XmlElement xslTdElement;
			XmlText xslTextElement;
			XmlElement xslFontElement;
			XmlElement xslControlElement;
			XmlElement tmpElement;

			string sTableStyle;
			//字符串解析
			sTableStyle = "position: absolute; left: " + sX.ToString() + "; top: " + sY.ToString();  //& "; width:" & sWidth & "; height:" & sHeight

			sFontSize = TransFont(sFontSize, sFontUnit);
			sBackColor = TransColor(sBackColor);
			sForeColor = TransColor(sForeColor);
			if(sBackColor == "#FFFF" ) sBackColor = "#FFFFFF"; //特殊黄色-透明

			//字符串解析
			switch (sType)
			{
				case   "line": //线
					//建立表格根结点
					xslTableElement = xslDoc.CreateElement("table");
					xslTableElement.SetAttribute("border", "0"); //设置表格属性
					xslTableElement.SetAttribute("width", sWidth.ToString());  //设置表格属性
					xslTableElement.SetAttribute("height", (sHeight - 1).ToString()); //设置表格属性
					xslTableElement.SetAttribute("style", sTableStyle); //设置表格属性
					xslTableElement.SetAttribute("bgcolor", "#FFFFFF"); //背景颜色
					xslTableElement.SetAttribute("cellpadding", "0"); //单元格留白
					xslTableElement.SetAttribute("cellspacing", "0"); //单元格间隔
					break;
				default:
					//建立表格根结点
					xslTableElement = xslDoc.CreateElement("table");
					xslTableElement.SetAttribute("border", sStyle); //设置表格属性
					xslTableElement.SetAttribute("width", sWidth.ToString());  //设置表格属性
					xslTableElement.SetAttribute("height", sHeight.ToString());  //设置表格属性
					xslTableElement.SetAttribute("style", sTableStyle); //设置表格属性
					xslTableElement.SetAttribute("bgcolor", sBackColor); //背景颜色
					xslTableElement.SetAttribute("cellpadding", "0"); //单元格留白
					xslTableElement.SetAttribute("cellspacing", "0"); //单元格间隔
					break;
			}
			//建立行结点
			xslTrElement = xslDoc.CreateElement("tr");
			xslTdElement = xslDoc.CreateElement("td");
			//建立font结点
			xslFontElement = xslDoc.CreateElement("font");
			xslFontElement.SetAttribute("face", sFontName);
			xslFontElement.SetAttribute("color", sForeColor);
			xslFontElement.SetAttribute("size", sFontSize);

			//**************font style node************
			XmlElement FontBold = null;
			XmlElement FontItalic = null;
			XmlElement FontUnderline = null;

			switch( sFontStyle)
			{
				case "0":
					break;
				case "1":
					FontBold = xslDoc.CreateElement("b");
					break;
				case "2":
					FontItalic = xslDoc.CreateElement("i");
					break;
				case "3":
					FontBold = xslDoc.CreateElement("b");
					FontItalic = xslDoc.CreateElement("i");
					break;
				case "4":
					FontUnderline = xslDoc.CreateElement("u");
					break;
				case "5":
					FontBold = xslDoc.CreateElement("b");
					FontUnderline = xslDoc.CreateElement("u");
					break;
				case "6":
					FontItalic = xslDoc.CreateElement("i");
					FontUnderline = xslDoc.CreateElement("u");
					break;
				case "7":
					FontBold = xslDoc.CreateElement("b");
					FontItalic = xslDoc.CreateElement("i");
					FontUnderline = xslDoc.CreateElement("u");
					break;
			}

			tmpElement = xslFontElement;
			if (FontBold !=null)
			{
				tmpElement.AppendChild(FontBold);
				tmpElement = FontBold;
			}
    
			if( FontItalic!=null)
			{
				tmpElement.AppendChild(FontItalic);
				tmpElement = FontItalic;
			}
			if(FontUnderline!=null)
			{
				tmpElement.AppendChild(FontUnderline);
				tmpElement = FontUnderline;
			}
			//************************font style done*******

			switch(sType)
			{
		   
				case "label" ://标签
					xslTextElement = xslDoc.CreateTextNode(sText);
					tmpElement.AppendChild(xslTextElement);
					break;
				case "image": //图片
					xslControlElement = xslDoc.CreateElement("img"); //img
					xslControlElement.SetAttribute("src", sText);
					xslControlElement.SetAttribute("alt", sValue);
					xslControlElement.SetAttribute("width", sWidth.ToString());
					xslControlElement.SetAttribute("height", sHeight.ToString());
					xslControlElement.SetAttribute("border", sStyle);

					tmpElement.AppendChild(xslControlElement);
					break;
				case "line": //线
					xslControlElement = xslDoc.CreateElement("hr"); //line
					xslControlElement.SetAttribute("size", (sHeight - 2).ToString());
					xslControlElement.SetAttribute("width", "100%");
					tmpElement.AppendChild(xslControlElement);
					break;
				case "checkbox": //checkBox
					xslControlElement = xslDoc.CreateElement("input"); //line
					xslControlElement.SetAttribute("type", "checkbox");
					xslControlElement.SetAttribute("readonly", "true");
					xslControlElement.SetAttribute("name", sName);
					if( sValue.ToUpper() == "TRUE" )
						xslControlElement.SetAttribute("checked", sValue);
               
					//文本添加
					xslTextElement = xslDoc.CreateTextNode(sText);
					xslControlElement.AppendChild(xslTextElement);
					tmpElement.AppendChild(xslControlElement);
					break;
				case "radiobutton": //checkBox
					xslControlElement = xslDoc.CreateElement("input"); //line
					xslControlElement.SetAttribute("type", "radio");
					xslControlElement.SetAttribute("name", sName);
					if( sValue.ToUpper() == "TRUE" )
						xslControlElement.SetAttribute("checked", sValue);
					//文本添加
					xslTextElement = xslDoc.CreateTextNode(sText);
					xslControlElement.AppendChild(xslTextElement);
					tmpElement.AppendChild(xslControlElement);
					break;
				case "multilinebox": //多行文本
					xslControlElement = xslDoc.CreateElement("textarea"); //line
					xslControlElement.SetAttribute("name", sName);
					xslControlElement.SetAttribute("rows", (sHeight / 16).ToString());
					xslControlElement.SetAttribute("readonly", "true");
					xslControlElement.SetAttribute("cols",  (sWidth / 7.5).ToString());
			
					xslTextElement = xslDoc.CreateTextNode(sText);
					xslControlElement.AppendChild(xslTextElement);
			
					tmpElement.AppendChild(xslControlElement);
              
					break;
				default:
					xslTextElement = xslDoc.CreateTextNode(sValue);
					tmpElement.AppendChild(xslTextElement);
			  
					break;
			}

			//组合结点
			xslTdElement.AppendChild(xslFontElement);
			xslTrElement.AppendChild(xslTdElement);
			xslTableElement.AppendChild(xslTrElement);
			RootElement.AppendChild(xslTableElement);
		}
		#endregion

		#region convert
		//trans Font
		private string TransFont(string sFontSize ,string sFontUnit)
		{
			double fontSize  = double.Parse(sFontSize);
			switch( sFontUnit)
			{
				case "0":
					fontSize = fontSize * 1;
					break;
					
				case "1":
					fontSize = fontSize * 1;
					break;
				case "2":
					fontSize = fontSize * 1;
					break;
				case "3":
					fontSize = fontSize * 1.3;
					break;
				case "4":
					fontSize = fontSize * 98;
					break;
			}

			fontSize = fontSize * 0.2 * rate;

			return fontSize.ToString() + "pt";
		}
		  
		//trans color
		private string TransColor(string sColor)
		{
			Color c = Color.FromArgb(int.Parse(sColor));
			string r = Convert.ToString(c.R,16).ToString();
			string g = Convert.ToString(c.G,16).ToString();
			string b = Convert.ToString(c.B,16).ToString();
			return "#"+r+g+b;
		}
		#endregion
	}

}
