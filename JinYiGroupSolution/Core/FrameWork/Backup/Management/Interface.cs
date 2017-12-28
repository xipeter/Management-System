using System;
using System.Collections;
using Neusoft.FrameWork.Models;
namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// xml接口类
	/// wolf 2004-6
	/// </summary>
	public class Interface:Neusoft.FrameWork.Management.Database 
	{

		#region 公用函数

		public Interface()
		{
			alInfo=new  ArrayList();
		}
		/// <summary>
		/// 信息结构体
		/// </summary>
		protected ArrayList alInfo;
		/// <summary>
		/// 读取xml接口文件
		/// <br>读取配置文件 HIS_SETTING.XML,LIS_SETTING.XML,PACS_SETTING.XML</br>
		/// </summary>
		/// <param name="xmlFileName"></param>
		/// <returns></returns>
		public int ReadXML(string xmlFileName)
		{
			//显示进度
			this.ProgressBarValue=0;
			this.ProgressBarText="读取设置信息...";

			System.Xml.XmlDocument doc;
			System.Xml.XmlNodeList nodes;
			Neusoft.FrameWork.Models.NeuInfo info=new Neusoft.FrameWork.Models.NeuInfo();

			Neusoft.FrameWork.Xml.XML  manageXml=new Neusoft.FrameWork.Xml.XML();
			doc=manageXml.LoadXml(xmlFileName);
			if(doc==null)
			{
				this.Err="无法打开文件！" +xmlFileName+manageXml.Err;
				this.ErrCode="-1";
				this.WriteErr();
				return -1;
			}  
            nodes = doc.SelectNodes("设置/变量");
			try
			{
				foreach(System.Xml.XmlNode node in nodes)
				{
					this.ProgressBarValue=this.ProgressBarValue+(100/nodes.Count);

					info=new Neusoft.FrameWork.Models.NeuInfo();
				    info.Name = node.Attributes["显示名称"].Value;
				    info.ID = node.Attributes["变量名"].Value;
					switch (node.Attributes["类型"].Value.ToString())
					{
						case "参数":
							info.type= Neusoft.FrameWork.Models.NeuInfo.infoType.Param;
							break;
						case "全局变量":
							info.type = Neusoft.FrameWork.Models.NeuInfo.infoType.Global;
							break;
						case "临时变量":
                            info.type = Neusoft.FrameWork.Models.NeuInfo.infoType.Temp;
							break;
						case "常量":
							info.type = Neusoft.FrameWork.Models.NeuInfo.infoType.Const;
							break;
						case "患者列表":
							info.type = Neusoft.FrameWork.Models.NeuInfo.infoType.PatientList;
							break;
						case "科室列表":
							info.type = Neusoft.FrameWork.Models.NeuInfo.infoType.inDeptList;
							break;
						case "关联变量":
							info.type=Neusoft.FrameWork.Models.NeuInfo.infoType.Associate ;
					        break;
						case "事件":
							info.type=Neusoft.FrameWork.Models.NeuInfo.infoType.Event;
							break;
						case "其它列表":
				            info.type = Neusoft.FrameWork.Models.NeuInfo.infoType.List;
							break;
						default:
				            info.type = (Neusoft.FrameWork.Models.NeuInfo.infoType)int.Parse(node.Attributes["类型"].Value.ToString());
							break;
					}
				    info.Sql = node.ChildNodes[0].InnerText;
					try
					{
						info.showType = node.ChildNodes[2].InnerText;
					}
					catch{}
					try
					{
						info.UpdateSql = node.ChildNodes[1].InnerText;
					}
					catch{}
					info.Memo = info.Sql;//存储以前的sql

				    alInfo.Add(info);
				}
				this.ProgressBarValue=100;
				return 0;
			}
			catch(Exception ex){
				this.ProgressBarValue=0;
                Err = ex.Message;
				return -1;}
		}
		/// <summary>
		/// 设置参数
		/// </summary>
		/// <param name="myParams"></param>
		/// <returns></returns>
		public int SetParam(params string[] myParams)
		{
			int i;
			NeuInfo info=new NeuInfo();
			for(i=0;i<alInfo.Count;i++)
			{
				info=(NeuInfo)alInfo[i];
				if(info.type == Neusoft.FrameWork.Models.NeuInfo.infoType.Param)
				{
					try
					{
						info.Sql=string.Format(info.Memo,myParams);
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						return -1;
					}
				}
			}
			
			return 0;
		}
		/// <summary>
		/// 获得信息结构的数值
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public string GetValue(string Name)
		{
			int i;
			NeuInfo  info;
			for(i=0;i<=alInfo.Count-1;i++)
			{
				info=new Models.NeuInfo();
				info=(NeuInfo)alInfo[i];
				if(info.ID==Name || info.ID=="["+Name+"]") 
					return info.value;
			}
			return "";
		}
		/// <summary>
		/// 获得信息位置
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public int GetPosition(string Name)
		{
			int i;
			NeuInfo info;
			for(i=0;i<alInfo.Count;i++)
			{
				info=(NeuInfo)alInfo[i];
				if(info.ID==Name || info.ID=="["+Name+"]") 
					return i;
			}
			return -1;
		}
		/// <summary>
		/// 获得信息结构
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public NeuInfo GetInfo(string Name)
		{
			int i;
			NeuInfo info=new NeuInfo();
			for(i=0;i<alInfo.Count;i++)
			{
				info=(NeuInfo)alInfo[i];
				if(info.ID==Name || info.ID=="["+Name+"]") 
					return info;
			}
			return info;
		}
		/// <summary>
		/// 获得信息结构
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public NeuInfo GetInfo(int i)
		{
			return (NeuInfo)alInfo[i];
		}
		/// <summary>
		/// 设置数值
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="Value"></param>
		public void SetValue(string Name,string Value)
		{
			int i;
			NeuInfo info;
			for(i=0;i<alInfo.Count;i++)
			{
				info=(NeuInfo)alInfo[i];
				if(info.ID==Name || info.ID=="["+Name+"]") 
				{
					info.value=Value;
					return;
				}
			}
		}
		/// <summary>
		///  执行存储过程
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public int ExecEvent(int i)
		{
			return 0;
		}
		public int ExecEvent(int i,string NameSpace)
		{
			return 0;
		}
		/// <summary>
		///  执行Sql,获得该信息结构的数值
		/// </summary>
		/// <param name="i"></param>
		public void ExecValue(int i)
		{
			this.ExecValue(i,"");
		}
	    /// <summary>
		///  执行Sql,获得该信息结构的数值
	    /// </summary>
	    /// <param name="i"></param>
	    /// <param name="NameSpace"></param>
		public void ExecValue(int i,string NameSpace)
		{
			NeuInfo info=(NeuInfo)alInfo[i];
			try
			{
				switch(info.type)
				{
					case NeuInfo.infoType.Global:
						this._execSql(i,NameSpace);
						break;
					case NeuInfo.infoType.Temp:
						this._execSql(i,NameSpace);
						break;
					case NeuInfo.infoType.Const:
						string sql=this.TransSql(info.Sql).Trim();
						Caculation c=new Caculation();
						info.value=c._if(sql);
						break;
					case NeuInfo.infoType.Param:
						this._execSql(i,NameSpace);
						break;
					default:
						break;
				}
			}
			catch
			{
			}
		}
		/// <summary>
		/// 替换sql信息
		/// </summary>
		/// <param name="oldSql"></param>
		/// <returns></returns>
		public string TransSql(string oldSql)
		{
			int i;
			for(i=0;i<alInfo.Count;i++)
			{	
				NeuInfo info=(NeuInfo)alInfo[i];
				if(info.value !="") oldSql = oldSql.Replace(info.ID,info.value);
			}
			return oldSql;
		}
		/// <summary>
		/// 获得信息数量
		/// </summary>
		public  int Count
		{
			get
			{
				return alInfo.Count;
			}
		}
		/// <summary>
		/// 刷新变量
		/// </summary>
		/// <param name="Type">变量类型</param>
		/// <param name="Except">不更新的变量，防止死循环</param>
		public void RefreshVariant(Models.NeuInfo.infoType  Type,int Except)
		{
			int i;
			for(i=0;i<alInfo.Count;i++)
			{
				NeuInfo info=(NeuInfo)alInfo[i];
				if(i!=Except & info.type==Type) this.ExecValue(i,"%");
			}
		}
		/// <summary>
		/// 刷新变量
		/// </summary>
		public void RefreshVariant()
		{
			int i;
			for(i=0;i<alInfo.Count;i++)
			{
				 this.ExecValue(i,"%");
			}
		}

        public ArrayList GetList(int i)
        {
            ArrayList al = new ArrayList();
            NeuInfo info = (NeuInfo)alInfo[i];
            try
            {
                if (this.ExecQuery(info.Sql) == -1)
                {
                    return al;
                }
            }
            catch (Exception ex)
            {
                this.Logo.WriteLog("执行sql语句出错! " + info.Sql + "错误原因 :" + ex.Message);
            }
            try
            {

                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = null;
                    switch (this.Reader.FieldCount)
                    {
                        case 1:
                            obj = new NeuObject(this.Reader[0].ToString(), this.Reader[0].ToString(), "");
                            break;
                        case 2:
                            obj = new NeuObject(this.Reader[0].ToString(), this.Reader[1].ToString(), "");
                            break;
                        case 3:
                            obj = new NeuObject(this.Reader[0].ToString(), this.Reader[1].ToString(), this.Reader[2].ToString());
                            break;
                        default:
                            break;
                    }
                    al.Add(obj);
                }
            }
            catch { };

            try
            {
                this.Reader.Close();
            }
            catch { }
            return al;
        }
		#endregion

		#region 私有函数
		/// <summary>
		/// 私有_执行sql语句
		/// </summary>
		/// <param name="i"></param>
		/// <param name="NameSpace"></param>
		private void _execSql(int i,string NameSpace)
		{
			//特殊情况 是单行，多列的情况
			NeuInfo info=new NeuInfo();
			info=(NeuInfo)alInfo[i];
			if(info.Sql.Substring(0,1)=="[" &info.Sql.Substring(info.Sql.Length-1,1)=="]")
			{
				int k,m,iStart;//,iEnd;
				string strLeft,strReal;//剩余的字符串,实际的字符串
				int iDot=0;//有几个逗号
				for(k=0;k<alInfo.Count;k++)
				{
					NeuInfo Info=(NeuInfo)alInfo[k];
					if(NameSpace.Trim()==Info.Name || Info.Name=="" || Info.Name=="%")
					{
						iStart=Info.ID.IndexOf(info.Sql);
						if(iStart>=0)//sql 同 ID 对应上
						{
							strLeft=Info.ID.Substring(0,iStart);
							while(iStart>=0)
							{
								iStart=strLeft.IndexOf(",");
								try
								{
									strLeft=strLeft.Substring(iStart+1);
								}
								catch{}
								iDot++;
							}
							strLeft=Info.value;
							strReal="";
							for(m=1;m<=iDot;m++)
							{
								iStart=strLeft.IndexOf(",");
								if(iStart>=0)
								{
									strReal=strLeft.Substring(0,iStart );
									strLeft=strLeft.Substring(iStart+1);

								}
								else
								{
									strReal=strLeft;
								}
							}
							info.value  = strReal;
							break;
						}
					}
				}
				return;
			}
			//执行sql语句;
			string sql;
			sql=this.TransSql(info.Sql);
			try
			{
				this.ExecQuery(sql);
			}
			catch(Exception ex)
			{
				this.Logo.WriteLog("执行sql语句出错! " + sql+ "错误原因 :" + ex.Message);
			}
			try
			{
				int j;
				string sValue;
				this.Reader.Read();

				for(j=0;j<this.Reader.FieldCount;j++)
				{
					try
					{
						sValue=this.Reader.GetValue(j).ToString();
					}
					catch
					{
						sValue="";
					}
					if(j==0) 
					{
						info.value=sValue;
					}
					else
					{
						info.value=info.value +","+sValue;
					}
				}
			}
			catch
			{
				info.value="";
			}
			try
			{
				this.Reader.Close();
			}catch{}
		}


#endregion

	}
}
