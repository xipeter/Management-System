using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Visit
{
    /// <summary>
    /// [功能描述: 随访检索申请业务组合类]<br></br>
    /// [创 建 者: 王立]<br></br>
    /// [创建时间: 2007-9-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class VisitSearches : IntegrateBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public VisitSearches()
        {
            
        }

        

        #region 变量

        /// <summary>
        /// 随访检索申请管理类
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.HealthRecord.Visit.VisitSearches visitSearchesManager = new Neusoft.HISFC.BizLogic.HealthRecord.Visit.VisitSearches();

        /// <summary>
        /// 常数管理类
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.Manager.Constant constFunction = new Neusoft.HISFC.BizLogic.Manager.Constant();

        #endregion

        #region 方法

        /// <summary>
        /// 向随访申请表中插入一条新的记录
        /// </summary>
        /// <param name="visitSearches">随访检索申请实体</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int InsertVisitSeaches(Neusoft.HISFC.Models.HealthRecord.Visit.VisitSearches visitSearches)
        {
            this.SetDB(visitSearchesManager);

            int intReturn = visitSearchesManager.Insert(visitSearches);
            if (intReturn < 0)
            {
                this.Err = visitSearchesManager.Err;

                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 修改随访检索申请记录
        /// </summary>
        /// <param name="visitSearches">随访检索申请实体</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int UpdateVisitSearches(Neusoft.HISFC.Models.HealthRecord.Visit.VisitSearches visitSearches)
        {
            this.SetDB(visitSearchesManager);

            int intReturn = visitSearchesManager.Update(visitSearches);
            if (intReturn < 0)
            {
                this.Err = visitSearchesManager.Err;

                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 根据申请流水号删除一条随访检索申请记录
        /// </summary>
        /// <param name="applyID">随访检索申请流水号</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int DeleteVisitSearches(string applyID)
        {
            this.SetDB(visitSearchesManager);

            int intReturn = visitSearchesManager.Delete(applyID);
            if (intReturn < 0)
            {
                this.Err = visitSearchesManager.Err;

                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 通过状态检索随访申请记录
        /// </summary>
        /// <param name="searchesStat">申请状态</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList QueryBYDocCode(string docCode, string searchesStat)
        {
            this.SetDB(visitSearchesManager);

            ArrayList temp = visitSearchesManager.QueryByDocCode(docCode, searchesStat);
            if (temp == null)
            {
                this.Err = visitSearchesManager.Err;

                return null;
            }

            return temp;
        }

        /// <summary>
        /// 通过执行SQL语句，将查询到的信息读到ArrayList中
        /// </summary>
        /// <param name="strSQL">需要执行的SQL语句</param>
        /// <returns>返回读取到的数组、错误返回null</returns>
        public ArrayList QueryByStat(string searches)
        {
            this.SetDB(visitSearchesManager);

            ArrayList temp = visitSearchesManager.QueryByStat(searches);
            if (temp == null)
            {
                this.Err = visitSearchesManager.Err;

                return null;
            }

            return temp;
        }

        /// <summary>
        /// 通过申请流水号检索随访申请记录
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public ArrayList QueryByApplyId(string applyId)
        {
            this.SetDB(visitSearchesManager);

            ArrayList temp = visitSearchesManager.QueryByApplyId(applyId);
            if (temp == null)
            {
                this.Err = visitSearchesManager.Err;

                return null;
            }

            return temp;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取系统当前时间
        /// </summary>
        /// <returns>系统当前时间</returns>
        public DateTime GetSystemTime()
        {
            return visitSearchesManager.GetDateTimeFromSysDateTime();
        }

        /// <summary>
        /// 事务设置
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            visitSearchesManager.SetTrans(trans);
            constFunction.SetTrans(trans);
        }

        #endregion
    }
}
