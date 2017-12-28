using System;
using System.Collections;
namespace neusoft.HISFC.Object.EMR
{
	/// <summary>
	/// QCAction 的摘要说明。
	/// </summary>
	public class QCAction
	{
		public QCAction()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		protected ArrayList alMessage = new ArrayList();
		/// <summary>
		/// 消息
		/// </summary>
		public ArrayList AlMessage
		{
			get
			{
				return this.alMessage;
			}
		}
		protected string strName ="";
		/// <summary>
		/// 动作
		/// </summary>
		public string Name
		{
			get
			{
				return this.strName ;
			}
			set
			{
				this.strName = value;
				this.alMessage = new ArrayList();
				string[] s = value.Split('\n');
				for(int i=0;i<s.Length ;i++)
				{
					//判断动作类型及信息
					if(s[i].Trim()!="")
					{
						int iStart,iEnd;
						neusoft.neuFC.Object.neuObject obj = new neusoft.neuFC.Object.neuObject();
						string sTmp = s[i].TrimStart();
						if(sTmp.Substring(0,4) == "使提示 ")
						{
							obj.ID = "0";
							iStart =sTmp.IndexOf("'");
							iEnd = sTmp.IndexOf("'",iStart+1);
							obj.Name  =sTmp.Substring(iStart +1,iEnd - iStart -1);
						}
						else if(sTmp.Substring(0,4) == "使模板 ")
						{
							obj.ID  = "1";
							iStart = sTmp.IndexOf("'");
							iEnd = sTmp.IndexOf("'",iStart+1);
							obj.Name = sTmp.Substring(iStart +1,iEnd - iStart -1);
						}
						else
						{
							return;
						}
						this.alMessage.Add(obj);
					}
				}
			}
		}
		/// <summary>
		/// 重新写ToString
		/// </summary>
		/// <returns></returns>
		public new string ToString()
		{
			return this.strName;
		}
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new QCAction Clone()
		{
			return this.MemberwiseClone() as QCAction;
		}
	}
}
