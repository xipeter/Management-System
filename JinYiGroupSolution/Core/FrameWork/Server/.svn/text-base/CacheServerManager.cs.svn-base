using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.FrameWork.Server
{
    /// <summary>
    /// [功能描述: 服务端缓存数据管理]<br></br>
    /// [创 建 者: dorian]<br></br>
    /// [创建时间: 2009-04]<br></br>
    /// <修改记录>
    ///         1、错误日志如何记录、返回？
    /// </修改记录>
    /// </summary>
    [Serializable]
    public class CacheServerManager : MarshalByRefObject
    {
        #region 域变量 缓冲池变量

        /// <summary>
        /// 数据缓冲池
        /// </summary>
        private Dictionary<Neusoft.FrameWork.Models.CacheDataType, ArrayList> cacheDataPool = new Dictionary<Neusoft.FrameWork.Models.CacheDataType, ArrayList>();

        /// <summary>
        /// 版本缓冲池
        /// </summary>
        private Dictionary<Neusoft.FrameWork.Models.CacheDataType, string> cacheVersionPool = new Dictionary<Neusoft.FrameWork.Models.CacheDataType, string>();

        /// <summary>
        /// 数据刷新标志
        /// </summary>
        private Dictionary<Neusoft.FrameWork.Models.CacheDataType, bool> cacheRefreshingFlag = new Dictionary<Neusoft.FrameWork.Models.CacheDataType, bool>();

        private string error = string.Empty;

        /// <summary>
        /// 错误代码 
        /// </summary>
        private string errCode;

        #endregion

        #region 二级缓存变量  参数数据方法缓存

        /// <summary>
        /// 二级缓存--  CacheKey 与 Param数组
        /// </summary>
        private Dictionary<string, List<string>> cacheParamDataKey = new Dictionary<string, List<string>>();

        /// <summary>
        /// 二级缓存--  CacheKey+Param 与  Data
        /// </summary>
        private Dictionary<string, ArrayList> cacheParamDataPool = new Dictionary<string, ArrayList>();

        #endregion

        public CacheServerManager()
        {

        }

        public string Error
        {
            get
            {
                return error;
            }
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode
        {
            get
            {
                return this.errCode;
            }
        }

 
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="cacheDataKey">数据索引</param>
        /// <param name="funParam">函数参数</param>
        /// <param name="t">数据类型</param>
        /// <returns>成功返回Byte数据</returns>
        public byte[] GetCacheData(Neusoft.FrameWork.Models.CacheDataType cacheDataKey, object[] funParam, Type t)
        {
            ArrayList alCacheData = this.GetDictionary(cacheDataKey, funParam, t);
            if (alCacheData == null)
            {
                return null;
            }

            try
            {
                return Neusoft.FrameWork.Function.Serialize.Serialization(alCacheData);
            }
            catch (Exception e)
            {
                this.error = e.Message + "\n" +  e.InnerException;
                return null;
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// 
        /// ErrCode=NoDataFound       未维护数据
        /// ErrCode=NoManagmentFound  未维护数据提取信息
        /// ErrCode=PauseCache        暂停了缓存处理
        /// ErrCode=MisMatch          需要的数据类型与缓存数据类别不匹配
        /// 
        /// </summary>
        /// <param name="cacheDataKey">数据索引</param>
        /// <param name="funParam">函数参数</param>
        /// <param name="t">数据类型</param>
        /// <returns>成功返回ArrayList数据</returns>
        public ArrayList GetDictionary(Neusoft.FrameWork.Models.CacheDataType cacheDataKey, object[] funParam, Type t)
        {
            //如果当前正在进行数据刷新则等待完成
            while (cacheRefreshingFlag.ContainsKey(cacheDataKey) && cacheRefreshingFlag[cacheDataKey])
            {
                continue;
            }

            this.error = string.Empty;
            this.errCode = string.Empty;
            //有效性判断 根据ErrCode返回不同错误情况
            Neusoft.FrameWork.Management.CacheManager dataConfigManager = new Neusoft.FrameWork.Management.CacheManager();
            Neusoft.FrameWork.Models.NeuCache cacheInfo = dataConfigManager.GetCacheConfig(cacheDataKey);
            if (cacheInfo == null)
            {
                this.error = dataConfigManager.Err;
                this.errCode = dataConfigManager.ErrCode;
                return null;
            }
            

            bool isRefreshData = true;

            if (cacheDataPool.ContainsKey(cacheDataKey))
            {
                #region 校验缓存数据是否过时

                //校验缓存数据是否过时
                bool isDirtyData = this.JudegeIsDirty(cacheDataKey,cacheInfo);
                if (isDirtyData)
                {
                    this.RemoveDictionary(cacheDataKey);                    
                }
                else
                {
                    isRefreshData = false;
                }

                #endregion
            }

            //获取参数缓存数据
            if (isRefreshData == false && funParam != null && funParam.Length > 0)
            {
                ArrayList cacheData = this.GetDictionaryFromCache(cacheDataKey, funParam);
                if (cacheData == null)
                {
                    //参数缓存数据不存在 仍需要刷新
                    isRefreshData = true;
                }
                else
                {
                    if (cacheData != null && cacheData.Count > 0 && cacheData[0].GetType() != t)
                    {
                        error = "缓存数据类型不匹配";
                        errCode = "MisMatch";
                        return null;
                    }

                    return cacheData;
                }
            }

            if (isRefreshData == false)     //不需要重新刷新数据
            {
                #region 由缓存内获取数据内

                ArrayList cacheData = cacheDataPool[cacheDataKey];
                if (cacheData.Count > 0 && cacheData[0].GetType() != t)
                {
                    error = "缓存数据类型不匹配";
                    errCode = "MisMatch";
                    return null;
                }

                return cacheData;

                #endregion
            }
            else
            {
                //根据cacheDataKey获取数据并加入缓存
                ArrayList cacheData = AddDictionary(cacheDataKey, funParam);
                if (cacheData == null)
                {
                    return null;
                }

                return cacheData;
            }
        }

        /// <summary>
        /// 判断数据是否过时
        /// </summary>
        /// <param name="cacheDataKey">数据索引</param>
        /// <returns></returns>
        private bool JudegeIsDirty(Neusoft.FrameWork.Models.CacheDataType cacheDataKey,Neusoft.FrameWork.Models.NeuCache cacheInfo)
        {
            string cacheVersion = cacheVersionPool[cacheDataKey];

            if (cacheInfo.DataVersion.ToString() == cacheVersion)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 移除缓存数据 
        /// </summary>
        /// <param name="cacheDataKey"></param>
        /// <returns></returns>
        public int RemoveDictionary(Neusoft.FrameWork.Models.CacheDataType cacheDataKey)
        {
            if (cacheDataPool.ContainsKey(cacheDataKey))
            {
                ArrayList cacheData = cacheDataPool[cacheDataKey];

                cacheDataPool.Remove(cacheDataKey);

                cacheVersionPool.Remove(cacheDataKey);

                cacheData = null;

                this.RemoveParamDictionary(cacheDataKey);
            }

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheDataKey"></param>
        /// <returns></returns>
        private ArrayList AddDictionary(Neusoft.FrameWork.Models.CacheDataType cacheDataKey, object[] funParam)
        {
            try
            {
                Neusoft.FrameWork.Management.CacheManager dataConfigManager = new Neusoft.FrameWork.Management.CacheManager();

                if (cacheRefreshingFlag.ContainsKey(cacheDataKey) == false)
                {
                    cacheRefreshingFlag.Add(cacheDataKey, true);
                }
                cacheRefreshingFlag[cacheDataKey] = true;

                //数据获取                 //添加版本信息
                string dataVersion = "";
                ArrayList cacheTemp = dataConfigManager.LoadCacheData(cacheDataKey, funParam, out dataVersion);
                if (cacheTemp == null)
                {
                    this.error = dataConfigManager.Err;
                    return null;
                }

                //对于参数数据 只需添加首次数据即可
                if (cacheDataPool.ContainsKey(cacheDataKey) == false)
                {
                    cacheDataPool.Add(cacheDataKey, cacheTemp);

                    cacheVersionPool.Add(cacheDataKey, dataVersion);
                }

                //缓存参数数据
                if (funParam != null)
                {
                    if (this.AddParamDictionary(cacheDataKey, funParam, cacheTemp) == -1)
                    {
                        return null;
                    }
                }

                return cacheTemp;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }
            finally
            {
                cacheRefreshingFlag[cacheDataKey] = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheDataKey"></param>
        /// <param name="funParam"></param>
        /// <returns></returns>
        private ArrayList GetDictionaryFromCache(Neusoft.FrameWork.Models.CacheDataType cacheDataKey, object[] funParam)
        {
            if (funParam == null || funParam.Length <= 0)
            {
                return cacheDataPool[cacheDataKey];
            }
            else
            {
                string paramKey = GetParamKey(cacheDataKey, funParam);

                if (cacheParamDataPool.ContainsKey(paramKey))
                {
                    return cacheParamDataPool[paramKey];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 参数数据缓存
        /// </summary>
        /// <param name="funParam">参数</param>
        /// <param name="alCacheData">参数数据</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddParamDictionary(Neusoft.FrameWork.Models.CacheDataType cacheDataKey ,object[] funParam, ArrayList alCacheData)
        {
            if (funParam == null || funParam.Length <= 0)
            {
                return 1;
            }

            //获取参数数据主键
            string paramKey = GetParamKey(cacheDataKey, funParam);

            //缓存参数主键
            if (this.cacheParamDataKey.ContainsKey(cacheDataKey.ToString()))
            {
                this.cacheParamDataKey[cacheDataKey.ToString()].Add(paramKey);
            }
            else
            {
                List<string> paramKeysList = new List<string>();
                paramKeysList.Add(paramKey);

                this.cacheParamDataKey.Add(cacheDataKey.ToString(), paramKeysList);
            }

            //缓存参数数据
            this.cacheParamDataPool.Add(paramKey, alCacheData);

            return 1;
        }

        /// <summary>
        /// 获取参数数据主键
        /// </summary>
        /// <param name="cacheDataKey"></param>
        /// <param name="funParam"></param>
        /// <returns></returns>
        private static string GetParamKey(Neusoft.FrameWork.Models.CacheDataType cacheDataKey, object[] funParam)
        {
            string paramKey = funParam[0].ToString();

            for (int i = 1; i < funParam.Length - 1; i++)
            {
                paramKey = "|" + funParam[i].ToString();
            }

            //建立参数主键
            paramKey = cacheDataKey.ToString() + "|" + paramKey;

            return paramKey;
        }

        /// <summary>
        /// 移除参数数据缓存
        /// </summary>
        /// <param name="cacheDataKey"></param>
        /// <returns></returns>
        private int RemoveParamDictionary(Neusoft.FrameWork.Models.CacheDataType cacheDataKey)
        {
            if (this.cacheParamDataKey.ContainsKey(cacheDataKey.ToString()))
            {
                //根据参数主键移除所有缓存数据
                foreach (string strParamKey in this.cacheParamDataKey[cacheDataKey.ToString()])
                {
                    this.cacheParamDataPool.Remove(strParamKey);
                }
                //移除主数据主键移除所有参数主键
                this.cacheParamDataKey.Remove(cacheDataKey.ToString());
            }

            return 1;
        }
    }
}
