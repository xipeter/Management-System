using System;
using System.Xml;
namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// 读取HisProfile.xml文件
	/// </summary>
	public class Setting:Neusoft.FrameWork.Models.NeuManageObject 
	{
		public Setting()
		{
			objSetting=new FrameWork.Models.NeuSetting();
		}
		/// <summary>
		/// HisProfile.xml配置文件名
		/// </summary>
		public string FileName;
		/// <summary>
		/// 配置结构
		/// </summary>
		public FrameWork.Models.NeuSetting objSetting;
		/// <summary>
		/// 获得配置
		/// </summary>
		/// <param name="FileName">HisProfile.xml文件名</param>
		/// <returns>0正确 -1错误</returns>
		public int GetSetting(string FileName)
		{
			XmlDocument doc;
			Neusoft.FrameWork.Xml.XML  manageXml=new Neusoft.FrameWork.Xml.XML();
			doc=manageXml.LoadXml(FileName);
			if(doc==null)
			{
				this.Err="无法打开文件！" +manageXml.Err;
				this.ErrCode="-1";
				return -1;
			}
			XmlNodeList nodes;
			XmlNode node;
			try
			{
				//数据库设置
				node=doc.SelectSingleNode(@"/设置/数据库设置");
				this.objSetting.ConnectionString=node.Attributes[0].Value;
				//ftp设置
				node=doc.SelectSingleNode(@"/设置/设置");
				objSetting.SQLByXMl = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["sql开关"].Value);
 
				//web service设置
				nodes=doc.SelectNodes(@"/设置/WebService设置");
				foreach(XmlNode mynode in nodes)
				{
					Neusoft.FrameWork.Models.NeuObject obj=new Neusoft.FrameWork.Models.NeuObject();
					obj.ID=mynode.Attributes[0].Value;
					obj.Name=mynode.Attributes[1].Value;
					try
					{
						obj.Memo=node.Attributes[2].Value;
					}
					catch{}
					this.objSetting.alWebservice.Add(obj);
				}
			}
			catch
			{
				return -1;
			}
			return 0;
		}
		/// <summary>
		/// 获得配置 重载+1
		/// </summary>
		/// <returns></returns>
		public int GetSetting()
		{
			this.GetSetting(FileName);
			return 0;
		}
	}
}
