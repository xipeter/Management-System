using System;
using System.Collections;

namespace neusoft.HISFC.Management.Manager
{
	/// <summary>
	/// Control 的摘要说明。
	/// </summary>
	public class Control:neusoft.neuFC.Management.Database
	{
		public Control()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 添加控制信息
		/// </summary>
		/// <param name="Control"></param>
		/// <returns></returns>
		public int AddControlInfo(neusoft.HISFC.Object.Base.Control Control)
		{
			string strSql = "";
			if (this.Sql.GetSql("AddControlInfo.1",ref strSql)==-1)return -1;
			try
			{
				//0控制参数代码1控制参数名称2控制参数值3显示标记4操作员5操作时间
				strSql = string.Format(strSql,Control.ID,Control.Name,Control.ControlValue,Control.VisibleFlag,
					this.Operator.ID,this.GetSysDateTime());
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 更新控制信息
		/// </summary>
		/// <param name="Control"></param>
		/// <returns></returns>
		public int UpdateControlInfo(neusoft.HISFC.Object.Base.Control Control)
		{
			string strSql = "";
			if (this.Sql.GetSql("UpdateControlInfo.1",ref strSql)==-1)return -1;
			try
			{
				//0控制参数代码1控制参数名称2控制参数值3显示标记4操作员5操作时间
				strSql = string.Format(strSql,Control.ID,Control.Name,Control.ControlValue,Control.VisibleFlag,
					this.Operator.ID,this.GetSysDateTime());
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 检索控制信息 只显示让客户可以看见的信息
		/// </summary>
		/// <returns></returns>
		public ArrayList QueryControlInfo()
		{
			string strSql = "";
			ArrayList al = new ArrayList();
			if (this.Sql.GetSql("QueryControlInfo.1",ref strSql)==-1)return null;
			this.ExecQuery(strSql);
			//0控制参数代码1控制参数名称2控制参数值3显示标记
			while (this.Reader.Read())
			{
				neusoft.HISFC.Object.Base.Control Control = new neusoft.HISFC.Object.Base.Control();
				try
				{
					Control.ID = this.Reader[0].ToString();
					Control.Name= this.Reader[1].ToString();
					Control.ControlValue=this.Reader[3].ToString();
					Control.VisibleFlag=this.Reader[4].ToString();
				}
				catch(Exception ex)
				{
					this.Err="查询控制信息赋值错误!"+ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				
				al.Add(Control);

			}
			this.Reader.Close();

			return al;
		}
		/// <summary>
		/// 根据控制类代码检索控制类型的值
		/// </summary>
		/// <param name="ControlCode"></param>
		/// <returns></returns>
		public string QueryControlInfo(string ControlCode)
		{
			string strSql = "";
			if (this.Sql.GetSql("QueryControlInfo.2",ref strSql)==-1)return "";
			try
			{
				//0控制参数代码
				strSql = string.Format(strSql,ControlCode);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return "";
			}
			return this.ExecSqlReturnOne(strSql);
		}
		/// <summary>
		/// 删除控制信息 暂时没用
		/// </summary>
		/// <param name="Control"></param>
		/// <returns></returns>
		public int DeleteControlInfo(neusoft.HISFC.Object.Base.Control Control)
		{
			return 0;
		}
	}
}
