using System;

namespace Neusoft.FrameWork.Models
{
    /// <summary>
    /// NeuSetting<br></br>
    /// [功能描述: NeuSetting类]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public class NeuSetting
	{
		public NeuSetting()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 连接串
		/// </summary>
		public string ConnectionString;
		/// <summary>
		/// web service地址数组
		/// </summary>
		public System.Collections.ArrayList alWebservice=new System.Collections.ArrayList();
		/// <summary>
		/// 开关
		/// </summary>
		public bool SQLByXMl = true;

        /// <summary>
		/// 获得WebServiceAddress
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public string GetWebServiceAddress(string index)
		{
			string strUrl="";
			int i;
			for(i=0;i<=alWebservice.Count;i++)
			{
                if (((NeuObject)alWebservice[i]).ID == index)
                {

                    return ((NeuObject)alWebservice[i]).Name;
                }
			}
			return strUrl;
		}
	}
}
