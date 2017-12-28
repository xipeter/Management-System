using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Models;
using System.Reflection;

namespace Neusoft.FrameWork.Management
{
    /// <summary>
    /// [功能描述: 缓存数据管理类]<br></br>
    /// [创 建 者: dorian]<br></br>
    /// [创建时间: 2009-04]<br></br>
    /// <修改记录>
    ///         1、如何处理反射的缓存？
    /// </修改记录>
    /// </summary>
    [Serializable]
    public class CacheManager : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 程序集缓存
        /// </summary>
        static Dictionary<string, Assembly> cacheDataAssembly = new Dictionary<string, Assembly>();

        /// <summary>
        /// 类型缓存
        /// </summary>
        static Dictionary<string, Type> cacheDataType = new Dictionary<string, Type>();

        /// <summary>
        /// 实例缓存
        /// </summary>
        static Dictionary<string, object> cacheDataObject = new Dictionary<string, object>();



        /// <summary>
        /// 取列表，可能是一条或者多条
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>对象数组</returns>
        private List<Neusoft.FrameWork.Models.NeuCache> ExecSqlForCacheInfo(string SQLString)
        {
            List<Neusoft.FrameWork.Models.NeuCache> al = new List<Neusoft.FrameWork.Models.NeuCache>();
            Neusoft.FrameWork.Models.NeuCache info;

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得数据缓存配置信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    info = new Neusoft.FrameWork.Models.NeuCache();

                    info.ID = this.Reader[0].ToString();                //CacheKey
                    info.Name = this.Reader[1].ToString();              //Description
                    info.Table = this.Reader[2].ToString();
                    info.DataVersion = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    info.DLL = this.Reader[4].ToString();
                    info.Class = this.Reader[5].ToString();
                    info.Fun = this.Reader[6].ToString();
                    info.Valid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[7]);

                    al.Add(info);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获取数据缓存配置信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获取Sql语句执行参数
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string[] GetSqlParams(Neusoft.FrameWork.Models.NeuCache info)
        {
            string[] strParams = new string[] { info.ID,
                                                info.Name,
                                                info.Table,
                                                info.DataVersion.ToString(),
                                                info.DLL,
                                                info.Class,
                                                info.Fun,
                                                Neusoft.FrameWork.Function.NConvert.ToInt32(info.Valid).ToString()                                            
                                                };

            return strParams;
        }        

        /// <summary>
        /// 更新数据版本
        /// </summary>
        /// <param name="cacheKey">数据索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int UpdateDataVersion(Neusoft.FrameWork.Models.CacheDataType cacheKey)
        {
            string sql = "";
            if (this.Sql.GetSql("DataCaching.UpdateDataVersion", ref sql) == -1)
            {
                return -1;
            }

            sql = string.Format(sql, cacheKey.ToString());

            return this.ExecNoQuery(sql);
        }
      
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="cacheKey">数据索引</param>
        /// <param name="configInfo">缓存数据配置信息</param>
        /// <returns>成功返回数据 失败返回null</returns>
        private ArrayList LoadCacheData(Neusoft.FrameWork.Models.NeuCache configInfo, object[] funParam)
        {
            try
            {
                //装载程序集
                Assembly _assembly;
                if (cacheDataAssembly.ContainsKey(configInfo.DLL))
                {
                    _assembly = cacheDataAssembly[configInfo.DLL];
                }
                else
                {
                    _assembly = Assembly.LoadFrom("./\\" + configInfo.DLL + ".dll");
                    cacheDataAssembly.Add(configInfo.DLL, _assembly);
                }
                if (_assembly == null)
                {
                    this.Err = configInfo.DLL + ".dll 文件加载失败!";
                    return null;
                }

                //类型反射
                Type _type;
                if (cacheDataType.ContainsKey(configInfo.DLL + configInfo.Class))
                {
                    _type = cacheDataType[configInfo.DLL + configInfo.Class];
                }
                else
                {
                    _type = _assembly.GetType(configInfo.Class);
                    cacheDataType.Add(configInfo.DLL + configInfo.Class, _type);
                }
                if (_type == null)
                {
                    this.Err = "程序集:" + configInfo.DLL + ".dll中无类型为" + configInfo.Class + "数据提供类!";
                    return null;
                }

                //实例反射
                object _obj;
                if (cacheDataObject.ContainsKey(configInfo.DLL + configInfo.Class))
                {
                    _obj = cacheDataObject[configInfo.DLL + configInfo.Class];
                }
                else
                {
                    _obj = Activator.CreateInstance(_type, null);
                    cacheDataObject.Add(configInfo.DLL + configInfo.Class, _obj);
                }
                if (_obj == null)
                {
                    this.Err = "程序集:" + configInfo.DLL + ".dll中类型为" + configInfo.Class + " 的数据提供类创建失败!";
                    return null;
                }

                MethodInfo m = _type.GetMethod(configInfo.Fun);

                return m.Invoke(_obj, funParam) as ArrayList;

            }
            catch (Exception e)
            {
                this.Err = e.Message;
                return null;
            }
        }


        /// <summary>
        /// 保存缓存配置信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertNeuCache(Neusoft.FrameWork.Models.NeuCache info)
        {
            string sql = "";
            if (this.Sql.GetSql("DataCaching.InsertNeuCache", ref sql) == -1)
            {
                return -1;
            }

            string[] strParams = this.GetSqlParams(info);
            sql = string.Format(sql, strParams);

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 更新缓存配置信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateNeuCache(Neusoft.FrameWork.Models.NeuCache info)
        {
            string sql = "";
            if (this.Sql.GetSql("DataCaching.UpdateNeuCache", ref sql) == -1)
            {
                return -1;
            }

            string[] strParams = this.GetSqlParams(info);
            sql = string.Format(sql, strParams);

            return this.ExecNoQuery(sql);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public int DeleteNeuCache(string cacheKey)
        {
            string sql = "";
            if (this.Sql.GetSql("DataCaching.DeleteNeuCache", ref sql) == -1)
            {
                return -1;
            }

            sql = string.Format(sql, cacheKey);

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 根据缓存索引获取缓存配置信息
        /// 
        /// ErrCode=NoDataFound       未维护数据
        /// ErrCode=NoManagmentFound  未维护数据提取信息
        /// ErrCode=PauseCache        暂停了缓存处理
        /// </summary>
        /// <param name="cacheKey">数据索引</param>
        /// <returns>成功返回数据配置信息 失败返回null</returns>
        internal Neusoft.FrameWork.Models.NeuCache GetCacheConfig(Neusoft.FrameWork.Models.CacheDataType cacheKey)
        {
            string sql = "";
            if (this.Sql.GetSql("DataCaching.GetCacheCofig.Simple", ref sql) == -1)
            {
                this.Err = this.Sql.Err;  
                return null;
            }

            sql = string.Format(sql, cacheKey.ToString());

            if (this.ExecQuery(sql) == -1)
            {
                this.Err = "执行Sql语句失败:  " + this.Err;
                return null;
            }

            Neusoft.FrameWork.Models.NeuCache configInfo = new Neusoft.FrameWork.Models.NeuCache();
            bool isFindData = false;

            try
            {
                if (this.Reader.Read())
                {
                    configInfo.DataVersion = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());
                    configInfo.DLL = this.Reader[1].ToString();
                    configInfo.Class = this.Reader[2].ToString();
                    configInfo.Fun = this.Reader[3].ToString();
                    configInfo.Valid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[4]);

                    isFindData = true;
                }
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            if (isFindData == false)
            {
                this.Err = configInfo.ID.ToString() + " 类型数据未维护缓存管理信息。";
                this.ErrCode = "NoDataFound";
                return null;
            }
            if (string.IsNullOrEmpty(configInfo.DLL) || string.IsNullOrEmpty(configInfo.Class) || string.IsNullOrEmpty(configInfo.Fun))
            {
                this.Err = "未正确维护  " + cacheKey.ToString() + "   类型数据的数据提取管理程序";
                this.ErrCode = "NoManagmentFound";
                return null;
            }
            if (configInfo.Valid == false)
            {
                this.Err = configInfo.ID.ToString() + " 类型数据暂停了缓存处理。";
                this.ErrCode = "PauseCache";
                return null;
            }

            return configInfo;
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="cacheKey">数据索引</param>
        /// <param name="dataVersion">数据版本号</param>
        /// <returns>成功返回数据 失败返回null</returns>
        internal ArrayList LoadCacheData(Neusoft.FrameWork.Models.CacheDataType cacheKey, object[] funParam, out string dataVersion)
        {
            dataVersion = "";

            Neusoft.FrameWork.Models.NeuCache configInfo = this.GetCacheConfig(cacheKey);
            if (configInfo == null)
            {
                return null;
            }

            dataVersion = configInfo.DataVersion.ToString();

            return this.LoadCacheData(configInfo, funParam);
        }

        /// <summary>
        /// 缓存数据获取
        /// </summary>
        /// <returns>成功返回所有缓存数据 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuCache> QueryCacheConfig()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("DataCaching.GetCacheCofig.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到DataCaching.GetCacheCofig.Select字段!";
                return null;
            }

            //取科室常数数据
            return this.ExecSqlForCacheInfo(strSQL);
        }


        /// <summary>
        /// 设置缓存数据版本
        /// </summary>
        /// <param name="cacheKey">数据索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public static int SetDataVersion(Neusoft.FrameWork.Models.CacheDataType cacheKey)
        {
            CacheManager cacheManager = new CacheManager();

            return cacheManager.UpdateDataVersion(cacheKey);
        }        

    }
}
