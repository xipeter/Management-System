using System;
using System.Collections;
namespace Neusoft.FrameWork.Public
{

    /// <summary>
    /// TableConvert <br></br>
	/// [功能描述: TableConvert数据库表转化类,从数据表转化成历史数据表，从历史数据表转化成数据表]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    
    public class TableConvert
	{
		public TableConvert()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region 变量
        
        //在线表和历史表对照表的arraylist列表
        private static ArrayList alTables;
        
        #endregion

        #region 属性
        #endregion

        #region 方法

        /// <summary>
		/// 传入没有替换参数的SQL语句,根据是否存在历史数据，如果存在，对相应的查询统计重组SQL语句
		/// </summary>
		/// <param name="sql">传入的sql语句</param>
		/// <returns>0 成功 -1失败</returns>
		public static int ConverTable(ref string sql)
		{
            //如果查询的是历史数据库对SQL语句进行处理
            if (Neusoft.FrameWork.Management.Connection.IsHistory)
            {
                
                //转成对历史数据的SQL
                return ConvertTableToHistoryTable(ref sql);
            }
			
            return 0;
		}


        /// <summary>
        /// 把在线的表和历史表的对照信息载入到静态ArrayList表当中
        /// </summary>
        /// <returns>0 成功 -1失败</returns>
		private static int initTableList()
		{
			try
			{
                //定义一个新的ArrayList
				alTables = new ArrayList();
				//查找COM_TABLELIST
				Neusoft.FrameWork.Management.DataBaseManger manager = new Neusoft.FrameWork.Management.DataBaseManger();
				if(manager.ExecQuery("select tablename,historytablename,memo from com_tablelist where historytablename is not null")==-1) return -1;
				while(manager.Reader.Read())//读数据
				{
					Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
					obj.ID = manager.Reader[0].ToString();
					obj.Name = manager.Reader[1].ToString();
					obj.Memo = manager.Reader[2].ToString();
					alTables.Add(obj);
				}
				manager.Reader.Close();
			}
			catch//无聊的错误
			{

				return -1;
			}
			
            return 0;
		}
        
		/// <summary>
		/// 转化sql成历史数据表sql
		/// </summary>
		/// <param name="sql"></param>
		/// <returns>0 成功 -1失败</returns>
		public static int ConvertTableToHistoryTable(ref string sql)
		{
			if(alTables == null)//第一次运行，查找数据表
			{
				if(initTableList() == -1) return -1;
			}
			if(alTables == null) return 0;
			foreach(Neusoft.FrameWork.Models.NeuObject obj in alTables)//一个一个替换
			{
				if(obj.Name == null || obj.Name.Trim() =="")
				{
				}
				else//有历史表的进行替换
				{
					sql = sql.Replace(obj.ID.ToUpper(),obj.Name);
					sql = sql.Replace(obj.ID.ToLower(),obj.Name);
				}
			}
			return 0;
		}

		/// <summary>
		/// 转化sql历史数据表成数据表
		/// </summary>
		/// <param name="sql"></param>
		/// <returns>0 成功 -1失败</returns>
		public static int ConvertHistoryTableToTable(ref string sql)
		{
			if(alTables == null)//第一次运行，查找数据表
			{
				if(initTableList()==-1) return -1;
			}
			if(alTables == null) return 0;
			foreach(Neusoft.FrameWork.Models.NeuObject obj in alTables)//一个一个替换
			{
				if(obj.Name == null || obj.Name.Trim() =="")
				{
				}
				else//有历史表的进行替换
				{
					sql = sql.Replace(obj.Name.ToUpper(),obj.ID);
					sql = sql.Replace(obj.Name.ToLower(),obj.ID);
				}
			}
			return 0;
		}
		
		
        #endregion

    }
}
