using System;
using System.Xml;
namespace Neusoft.FrameWork.Management
{
    /// <summary>
    /// Language<br></br>
    /// [功能描述:多语言类,对传入的语句进行分析]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		2010-09-19
    ///		{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换 更改实现方式
    ///  />
    /// </summary>
	public class Language:Neusoft.FrameWork.Models.NeuManageObject
	{
		public Language(string xmlFileName)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 当前语言资源文件
        /// </summary>
        private static string currentLanguageResources;

        /// <summary>
        /// 当前语言资源文件
        /// </summary>
        public static string CurrentLanguage
        {
            get
            {
                return currentLanguageResources;
            }
            set
            {
                currentLanguageResources = value;
            }
        }


		protected static System.Collections.ArrayList alLanguage = null;

        /// <summary>
        /// 是否使用多语言
        /// </summary>
        public static bool IsUseLanguage
        {
            get
            {
                if ((string.IsNullOrEmpty( currentLanguageResources ) == true) || (currentLanguageResources == "Default Language"))
                {
                    return false;
                }

                return true;
            }
        }

		/// <summary>
		/// 更换消息
		/// </summary>
		/// <param name="strMessage"></param>
		/// <returns></returns>
		public static string Msg(string strMessage)
		{
            string translateMsg = strMessage;
            try
            {
                if (currentLanguageResources == "Default Language")
                {
                    return strMessage;
                }

                if (string.IsNullOrEmpty( currentLanguageResources ) == true)
                {
                    return translateMsg;
                }
                
                translateMsg =  Neusoft.HISFC.WinForms.Resources.Language.GetLanguageString( strMessage, currentLanguageResources );
                if (string.IsNullOrEmpty( translateMsg ) == true)         //说明没有找到对应翻译文本 
                {
                    translateMsg = strMessage;
                }
            }
            catch
            {
            }

            return translateMsg;
        }


        #region 屏蔽原多语言处理方式

        ///// <summary>
        ///// 获得配置文件
        ///// </summary>
        ///// <param name="xmlFileName"></param>
        ///// <returns></returns>
        //private int init(string xmlFileName)
        //{
        //    System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
        //    try
        //    {
        //        doc.Load(xmlFileName);
        //            }
        //    catch(Exception ex)
        //    {
        //        this.Err=ex.Message;
        //        this.ErrCode="-1";
        //        return -1;
        //    }
        //    try
        //    {
        //        currentLanguage = xmlFileName.Substring(xmlFileName.LastIndexOf(@"\"));
        //        currentLanguage = currentLanguage.Substring(0, currentLanguage.Length - 4);
        //        currentLanguage = currentLanguage.Replace(@"\", "");
	
        //    }
        //    catch
        //    {
        //    }
        //    XmlNodeList nodes;
        //    nodes=doc.SelectNodes(@"//MSG");
        //    try
        //    {
        //        Language.alLanguage = new System.Collections.ArrayList();
        //        foreach(XmlNode node in nodes)
        //        {
        //            Neusoft.FrameWork.Models.NeuObject objValue=new Neusoft.FrameWork.Models.NeuObject();
        //            objValue.ID=node.Attributes[0].Value.ToString();
        //            objValue.Name=node.InnerText.ToString();
        //            objValue.Name=objValue.Name.Replace("\r"," ");
        //            objValue.Name=objValue.Name.Replace("\t"," ");
        //            try
        //            {
        //                objValue.Memo=node.Attributes[1].Value.ToString();
        //            }
        //            catch{}
        //            Language.alLanguage.Add(objValue);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        this.Err=ex.Message;
        //        this.ErrCode="-1";
        //        return -1;
        //    }
        //    return 0;
        //}

        #endregion 屏蔽原多语言处理方式
    }
}
