using System;
using System.Collections;
using System.Collections.Generic;

namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// ControlParam 的摘要说明。
	/// 控制参数管理类
	/// </summary>
	public class ControlParam:Database
	{
		public ControlParam()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 控制参数缓存 Key ControlCode  Value ControlValue
        /// </summary>
        private static Dictionary<string, string> controlDictionary = new Dictionary<string, string>();

		#region 控制函数

		/// <summary>
		/// 添加控制信息
		/// </summary>
		/// <param name="controlParam"></param>
		/// <returns></returns>
		public int AddControlerInfo( Neusoft.HISFC.Models.Base.ControlParam controlParam )
		{
			string strSql = "";
            if (this.Sql.GetSql( "AddControlerInfo.1", ref strSql ) == -1)
            {
                return -1;
            }

			try
			{
				//0控制参数代码1控制参数名称2控制参数值3显示标记4操作员5操作时间
                strSql = string.Format( strSql, controlParam.ID, controlParam.Name, controlParam.ControlerValue, Neusoft.FrameWork.Function.NConvert.ToInt32( controlParam.IsVisible ).ToString(),
					this.Operator.ID,this.GetSysDateTime());
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新控制信息
		/// </summary>
		/// <param name="controlParam"></param>
		/// <returns></returns>
		public int UpdateControlerInfo( Neusoft.HISFC.Models.Base.ControlParam controlParam )
		{
			string strSql = "";
			if (this.Sql.GetSql("UpdateControlerInfo.1",ref strSql)==-1)return -1;
			try
			{
				//0控制参数代码1控制参数名称2控制参数值3显示标记4操作员5操作时间
                strSql = string.Format( strSql, controlParam.ID, controlParam.Name, controlParam.ControlerValue, Neusoft.FrameWork.Function.NConvert.ToInt32( controlParam.IsVisible ).ToString(),
                    this.Operator.ID );
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 检索控制信息 只显示让客户可以看见的信息
		/// </summary>
		/// <returns></returns>
		public ArrayList QueryControlerInfo()
		{
			string strSql = "";
			ArrayList al = new ArrayList();
            if (this.Sql.GetSql( "QueryControlerInfo.1", ref strSql ) == -1)
            {
                return null;
            }

            //strSql = string.Format( strSql, Neusoft.FrameWork.Management.Connection.Hospital.ID );

			if(this.ExecQuery(strSql) == -1)
			{
				return null;
			}
			//0控制参数代码1控制参数名称2控制参数值3显示标记
			while (this.Reader.Read())
			{
				Neusoft.HISFC.Models.Base.ControlParam Controler = new Neusoft.HISFC.Models.Base.ControlParam();
				try
				{
					Controler.ID = this.Reader[0].ToString();
					Controler.Name= this.Reader[1].ToString();
					Controler.ControlerValue=this.Reader[2].ToString();
					Controler.IsVisible = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());
                    Controler.User01 = this.Reader[4].ToString();
                    Controler.User02 = this.Reader[5].ToString();
	
				}
				catch(Exception ex)
				{
					this.Err="查询控制信息赋值错误!"+ex.Message;
					return null;
				}
                finally
                {
                    this.Reader.Close();
                }

				al.Add(Controler);
			}

			return al;
		}

		/// <summary>
		/// 根据控制类代码检索控制类型的值
		/// 不重新从数据库中取
		/// </summary>
		/// <param name="controlCode"></param>
		/// <returns></returns>
		public string QueryControlerInfo(string controlCode)
		{
			return this.QueryControlerInfo(controlCode,false);
		}

		/// <summary>
		/// 根据控制类代码检索控制类型的值
		/// </summary>
		/// <param name="controlCode"></param>
		/// <param name="isRefresh"></param>
		/// <returns></returns>
		public string QueryControlerInfo( string controlCode,bool isRefresh )
		{
            //不重新取
            if (isRefresh == false)
            {
                if (controlDictionary.ContainsKey( controlCode ) == true)         //已包含
                {
                    return controlDictionary[controlCode];
                }
            }

			string strSql = "";
            if (this.Sql.GetSql( "QueryControlerInfo.2", ref strSql ) == -1)
            {
                return "";
            }

			try
			{
				//0控制参数代码
                strSql = string.Format( strSql, controlCode);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				return "";
			}

			string strValue =  this.ExecSqlReturnOne(strSql);

            if (controlDictionary.ContainsKey( controlCode ) == false)         //不包含该对应 添加到缓存内
            {
                controlDictionary.Add( controlCode, strValue );
            }

			return strValue;
		}
		
		/// <summary>
		/// 获得整个控制类信息
		/// </summary>
		/// <param name="controlCode"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.ControlParam QueryControlInfoByCode( string controlCode)
		{

			string strSql = "";

            if (this.Sql.GetSql( "QueryControlInfoByCode", ref strSql ) == -1)
            {
                return null;
            }

			strSql = string.Format(strSql,controlCode );
            if (this.ExecQuery( strSql ) == -1)
            {
                return null;
            }
			Neusoft.HISFC.Models.Base.ControlParam Controler = null;
			//0控制参数代码1控制参数名称2控制参数值3显示标记
			while (this.Reader.Read())
			{
				Controler = new Neusoft.HISFC.Models.Base.ControlParam();
				try
				{
					Controler.ID = this.Reader[0].ToString();
					Controler.Name= this.Reader[1].ToString();
					Controler.ControlerValue=this.Reader[2].ToString();
					Controler.IsVisible =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());
                    Controler.User01  = this.Reader[4].ToString();
                    Controler.User02  = this.Reader[5].ToString();
	
				}
				catch(Exception ex)
				{
					this.Err="查询控制信息赋值错误!"+ex.Message;
					return null;
				}
                finally
                {
                    this.Reader.Close();
                }
			}

			return Controler;
		}

		/// <summary>
		/// 获得整个控制类信息
		/// </summary>
		/// <param name="controlName"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.ControlParam QueryControlInfoByName( string controlName )
		{
			string strSql = "";

            if (this.Sql.GetSql( "QueryControlInfoByName", ref strSql ) == -1)
            {
                return null;
            }

            strSql = string.Format( strSql, controlName  );
            if (this.ExecQuery( strSql ) == -1)
            {
                return null;
            }

			Neusoft.HISFC.Models.Base.ControlParam Controler = null;
			//0控制参数代码1控制参数名称2控制参数值3显示标记
			while (this.Reader.Read())
			{
				Controler = new Neusoft.HISFC.Models.Base.ControlParam();
				try
				{
					Controler.ID = this.Reader[0].ToString();
					Controler.Name= this.Reader[1].ToString();
					Controler.ControlerValue=this.Reader[2].ToString();
					Controler.IsVisible=Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());
                    Controler.User01 =  this.Reader[4].ToString();
                    Controler.User02 = this.Reader[5].ToString();
	
				}
				catch(Exception ex)
				{
					this.Err="查询控制信息赋值错误!"+ex.Message;
					return null;
				}
                finally
                {
                    this.Reader.Close();
                }
			}

			return Controler;
		}

		/// <summary>
		/// 获得控制参数通过类别
		/// </summary>
		/// <param name="kind"></param>
		/// <returns></returns>
		public ArrayList QueryControlInfoByKind( string kind )
		{
			string strSql = "";
			ArrayList al = new ArrayList();
            if (this.Sql.GetSql( "QueryControlInfoByKind", ref strSql ) == -1)
            {
                return null;
            }
            strSql = string.Format( strSql, kind  );
            if (this.ExecQuery( strSql ) == -1)
            {
                return null;
            }

			//0控制参数代码1控制参数名称2控制参数值3显示标记
			while (this.Reader.Read())
			{
				Neusoft.HISFC.Models.Base.ControlParam Controler = new Neusoft.HISFC.Models.Base.ControlParam();
				try
				{
					Controler.ID = this.Reader[0].ToString();
					Controler.Name= this.Reader[1].ToString();
					Controler.ControlerValue=this.Reader[2].ToString();
					Controler.IsVisible=Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());
                    Controler.User01 =  this.Reader[4].ToString();
                    Controler.User02 =  this.Reader[5].ToString();
	
				}
				catch(Exception ex)
				{
					this.Err="查询控制信息赋值错误!"+ex.Message;
					return null;
				}
                finally
                {
                    this.Reader.Close();
                }
				al.Add(Controler);

			}

			return al;
		}

		#endregion
	}
}


namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Controler<br></br>
	/// [功能描述: 控制类实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class ControlParam : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public ControlParam()
		{
		}


		#region 变量

		/// <summary>
		/// 控制参数值
		/// </summary>
		private string controlerValue;

		/// <summary>
		/// 是否有效
		/// </summary>
		private bool isVisible; 

		#endregion

		#region 属性

		/// <summary>
		/// 控制参数的值
		/// </summary>
		public string ControlerValue
		{
			get
			{
				return this.controlerValue;
			}
			set
			{
				this.controlerValue = value;
			}
		}

		/// <summary>
		/// 是否有效  0 无效 1 有效
		/// </summary>
		public bool IsVisible
		{
			get
			{
				return this.isVisible;
			}
			set
			{
				this.isVisible = value;
			}
		}
		#endregion

		#region 方法

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>Controler类的实例</returns>
		public new ControlParam Clone()
		{
			return base.Clone() as ControlParam;
		}
		#endregion

		#endregion

	}
}

