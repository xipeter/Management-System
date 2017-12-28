using System;
using System.Data;
namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// IDataBase 的摘要说明。
	/// </summary>
	public interface IDataBase
    {

        #region 字段
        string Err
        {
            get;
            set;
        }
        string ErrCode
        {
            get;
            set;
        }
        int DBErrCode
        {
            get;
            set;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 连接
        /// </summary>
        System.Data.IDbConnection con
        {
            get;
            set;
        }

        /// <summary>
        /// sql语句
        /// </summary>
        Neusoft.FrameWork.Management.Sql Sql
        {
            get;
            set;
        }



        /// <summary>
        /// Reader
        /// </summary>
        System.Data.IDataReader Reader
        {
            get;
        }

        /// <summary>
        /// TempReader
        /// </summary>
        System.Data.IDataReader TempReader
        {
            get;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 设备事物
        /// </summary>
        /// <param name="Trans">传入的事物</param>
        void SetTrans(System.Data.IDbTransaction Trans);

		/// <summary>
		///  设置连接 
		/// </summary>
		/// <param name="strConnectString">连接的字符串</param>
		/// <returns>0 成功 -1 失败</returns>
		int Connect(string strConnectString);

		/// <summary>
		/// 执行非查询语句
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <returns>执行sql语句影响的行数 0执行到零行,-1没有执行有错误，对于update,insert,del外都为-1。>0成功的行数</returns>
		int ExecNoQuery(string strSql);
		
		/// <summary>
        /// 执行非查询语句
		/// </summary>
		/// <param name="strSql">执行的sql语句</param>
		/// <param name="parms">传入的字符串数组</param>
        /// <returns>执行sql语句影响的行数0执行到零行,-1没有执行有错误，对于update,insert,del外都为-1。>0成功的行数</returns>
		int ExecNoQuery(string strSql,params string[] parms) ;
	
		
		/// <summary>
		/// 执行查询语句,返回Reader
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <returns>0 成功 -1 失败</returns>
		int ExecQuery(string strSql) ;
			
		/// <summary>
		/// 执行查询语句，返回Reader
		/// </summary>
		/// <param name="strSql">原始sql语句</param>
		/// <param name="parms">需要替换的参数数组</param>
		/// <returns>返回执行状态 －1失败 0 成功 </returns>
		int ExecQuery(string strSql,params string[] parms) ;
			
		
		/// <summary>
		/// 执行sql语句 重载
		/// </summary>
		/// <param name="strSql">传入的sql语句</param>
		/// <param name="strDataSet">返回DataSet xml</param>
		/// <returns>返回执行状态 -1失败 0 成功</returns>
		int ExecQuery(string strSql,ref string strDataSet) ;

        /// <summary>
        /// 默认是Reader,临时用需要用TempReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>返回执行状态 -1失败 0 成功</returns>
		int ExecQueryByTempReader(string strSql) ;
			
		/// <summary>
		/// 执行sql
		/// </summary>
		/// <param name="strSql">传入的sql语句</param>
		/// <param name="strDataSet"></param>
		/// <returns>返回执行状态 -1 失败 0 成功</returns>
		int ExecQuery(string strSql,ref string strDataSet,string strXSLFileName) ;
			
		
		/// <summary>
		/// 执行sql，返回DataSet
		/// </summary>
		/// <param name="strSql">传入sql语句</param>
		/// <param name="DataSet">传出的dataset</param>
		/// <returns>返回执行状态 -1 失败 0 成功</returns>
		int ExecQuery(string strSql,ref DataSet DataSet) ;
		

		/// <summary>
		/// 执行sql，返回DataSet
		/// writed by cuipeng 
		/// 2005-08
		/// </summary>
		/// <param name="indexes">SQL语句在xml中的索引位置</param>
		/// <param name="dataSet">返回的DataSet</param>
		/// <param name="parms">参数数组,如果没有参数则传入null</param>
		/// <returns>0成功，-1错误</returns>
		int ExecQuery(string[] indexes, ref DataSet dataSet, params string[] parms) ;

		

		/// <summary>
		/// 执行sql，返回DataSet
		/// </summary>
		/// <param name="index">SQL语句在xml中的索引位置</param>
		/// <param name="dataSet">返回的dataSet</param>
		/// <param name="parms">参数数组,如果没有参数则传入null</param>
		/// <returns>0成功，-1错误</returns>
		int ExecQuery(string index, ref DataSet dataSet, params string[] parms) ;
		
		

		/// <summary>
		/// 执行sql语句，返回一条记录
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <returns> 0 成功 -1错误</returns>
		 string ExecSqlReturnOne(string strSql) ;
		
		
		
		/// <summary>
		/// 执行sql语句，返回一条记录 ,如果没有记录，返回默认字符串
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <param name="defaultstring">传入的字符串</param>
		/// <returns></returns>
		string ExecSqlReturnOne(string strSql,string defaultstring) ;
			
		

		/// <summary>
		/// 更新数据库的Blob数据类型,需指定sql参数为length=1的参数
		/// </summary>
		/// <param name="strSql">传入的sql语句</param>
		/// <param name="ImageData">传入的字节变量</param>
		/// <returns> 0 成功 -1 失败</returns>
		int InputBlob(string strSql,byte[] ImageData) ;
		
			
		
		/// <summary>
		/// 输出blob
		/// </summary>
		/// <param name="strSql">传入的sql语句</param>
		/// <returns>返回的字节</returns>
		byte[] OutputBlob(string strSql) ;
			
			
		
		/// <summary>
		/// 输入长字符串
		/// 针对>4000长度的字符串
		/// </summary>
		/// <param name="strSql">传入的sql字符串</param>
		/// <param name="data">长字符串</param>
		/// <returns></returns>
		 int InputLong(string strSql,string data) ;
			
		
		
		/// <summary>
		/// 执行存储过程
		/// <example>PRC_HIEBILL_CHARGE_ext,arg_checkopercode,22,1,;0},
		///		arg_exec_Sqn,22,1,{1},arg_yearcode,22,1,{2},return_code,30,2,{3},return_result,22,2,{4}</example>
		/// </summary>
		/// <param name="strSql">存储过程-参数,类型，输入输出,数值<br>22 varchar 30 double 33 int 6 DATETIME </br></param>
		/// <param name="Return">存储过程返回值 逗号分割</param>
		/// <returns>0 成功 -1 失败</returns>
		 int ExecEvent(string strSql,ref string Return) ;
			

		#region 获得时间
		/// <summary>
		/// 获得系统时间/日期
		/// </summary>
		/// <returns>DateTime from Oracle</returns>
		 string GetSysDateTime() ;
		
		
		 string GetSysDateTime(string format) ;
			
		
		 DateTime GetDateTimeFromSysDateTime() ;
			
		
		/// <summary>
		/// 获得系统日期 -
		/// </summary>
		/// <returns>Date yyyy-mm-dd</returns>
		 string GetSysDate() ;
			
		
		/// <summary>
		/// 获得系统日期 yyyy?mm?dd
		/// </summary>
		/// <returns>Date</returns>
		 string GetSysDate(string format ) ;
			
		
		/// <summary>
		/// 获得系统日期yyymmdd
		/// </summary>
		/// <returns>Date yyyymmdd</returns>
		 string GetSysDateNoBar() ;
		
		
		#endregion

        #endregion

     }
}
