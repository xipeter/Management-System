using System;
using System.Xml;
using System.Collections;
namespace Neusoft.FrameWork.Xml
{
	/// <summary>
	/// XML<br></br>
	/// [功能描述: XML类,继承VB.NET]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class XML:Neusoft.FrameWork.Models.NeuManageObject 
	{
		public XML()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region	变量
		#endregion
		
		#region 属性
		#endregion

		#region 方法
		
		/// <summary>
		/// 转换中文http到unicode
		/// </summary>
		/// <param name="http">传入的地址</param>
		/// <returns>转换后的字符串</returns>
		public string ConvertUniCode(string http)
		{
            //如果小于四位返回
            if (http.TrimStart().Length < 4)
            {

                return http;
            }

            //如果前四个字母不是HTTP返回http
            if (http.TrimStart().Substring(0, 4).ToUpper() != "HTTP")
            {

                return http;
            }

            //临时变量
			string r = ""; 

            //把传入的http字符串加载到一个字符串数据组当中
			char[] a = http.ToCharArray();

            try
			{
                //循环判断是否汉字，如果是汉字进行加%处理，解决非IIS无法处理汉字地址
				for ( int i = 0 ; i < a.Length ; i++)
				{
                    //如果是汉字,加%处理
					if ( a[i] < 0 || a[i] > 127 )
					{
                        string s = a[i].ToString();
						short l = (short)Microsoft.VisualBasic.Strings.Asc(s);
						string t = l.ToString("X4");
						r = r + "%" + t.Substring(0,2) + "%" + t.Substring(t.Length - 2, 2);			
					}
					else
					{
						r = r + http.Substring(i, 1);
					}
				}
			}
			catch
			{

				return http;
			}
			return r;
		}
		
		/// <summary>
		/// 添加Xml文本结点
		/// </summary>
		/// <param name="doc">文档</param>
		/// <param name="e">元素</param>
		/// <param name="NodeName">节点名</param>
		/// <param name="NodeValue">节点值</param>
		/// <returns></returns>
		public XmlElement AddXmlNode(XmlDocument doc, XmlElement e, string NodeName, string NodeValue)
		{
            //对XML文档添加XML元素
			XmlElement tempXmlElement = doc.CreateElement(NodeName);

            //添加结点文本
			XmlText tempXmlText = doc.CreateTextNode(NodeValue);
			
            //添加结点文本到文本元素当中
            tempXmlElement.AppendChild(tempXmlText);
			
            //在指定结点添加结点信息
            e.AppendChild(tempXmlElement);
			
            return tempXmlElement;
		}

        /// <summary>
        /// 添加XmlCData结点，与上面完全一样，真是另类重载呀
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="e">parent node</param>
        /// <param name="NodeName">append node</param>
        /// <param name="NodeValue">append node text</param>
        public XmlElement AddXmlCDataNode(XmlDocument doc, XmlElement e, string NodeName, string NodeValue)
        {
            //对XML文档添加XML元素
            XmlElement tempXmlElement = doc.CreateElement(NodeName);

            //添加结点文本
            XmlCDataSection tempXmlText = doc.CreateCDataSection(NodeValue);

            //添加结点文本元素当中
            tempXmlElement.AppendChild(tempXmlText);

            //在指定结点添加结点信息
            e.AppendChild(tempXmlElement);

            return tempXmlElement;
        }

		/// <summary>
		/// 添加结点属性
		/// </summary>
		/// <param name="e">元素</param>
		/// <param name="AttributeName">属性名</param>
		/// <param name="AttributeValue">属性值</param>
		public void AddNodeAttibute(XmlElement e,string AttributeName,string AttributeValue)
		{
			e.SetAttribute(AttributeName,AttributeValue);
		}

		
		/// <summary>
		/// 加载http当中的xml document,并转换unicode字符
		/// </summary>
		/// <param name="xmlFileName">xml文件名</param>
		/// <returns>XmlDocument</returns>
		public XmlDocument LoadXml(string xmlFileName)
		{
			XmlDocument doc = new XmlDocument();
			xmlFileName = this.ConvertUniCode(xmlFileName);
			try
			{
				doc.Load(xmlFileName);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = "-1";
				return null;
			}
			return doc;
		}

		/// <summary>
		/// 加载xml返回arraylist
		/// </summary>
		/// <param name="xmlFileName">xmlFileName</param>
		/// <param name="xPath">xPath</param>
		/// <returns>null</returns>
		public ArrayList LoadXmlReturnArrayList(string xmlFileName,string xPath)
		{
			XmlDocument doc = this.LoadXml(xmlFileName);
			ArrayList alReturn = new ArrayList();
			if (doc==null) return null;
			try
			{
				XmlNodeList nodes=doc.SelectNodes(xPath);
				foreach(XmlNode node in nodes)
				{
					alReturn.Add(node.InnerText);
				}
				return alReturn;
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode="-1";
			}
			return null;
		}

		/// <summary>
		/// 添加document根结点 默认1.0版本
		/// </summary>
		/// <param name="doc">doc XmlDocument</param>
		/// <param name="root">根结点名</param>
		/// <returns>XmlElement 根结点</returns>
		public XmlElement CreateRootElement(XmlDocument doc,string root)
		{
			return CreateRootElement(doc,root,"1.0");
		}

		/// <summary>
		/// 添加document根结点
		/// </summary>
		/// <param name="doc">doc XmlDocument</param>
		/// <param name="root">根结点名</param>
		/// <param name="version">xml版本号</param>
		/// <returns>XmlElement 根结点</returns>
		public XmlElement CreateRootElement(XmlDocument doc,string root,string version)
		{
			XmlElement myXmlElement;
			doc.AppendChild(doc.CreateXmlDeclaration("1.0","GB2312",""));
			myXmlElement=doc.CreateElement(root);
			myXmlElement.SetAttribute("Version",version);
			doc.AppendChild(myXmlElement);
			return myXmlElement;
		}

		#endregion
	}
}
