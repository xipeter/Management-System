using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.Integrate.PhysicalExamination
{
    class Company : IntegrateBase
    {
        #region 变量
        //体检单位管理类
        protected static Neusoft.HISFC.Management.PhysicalExamination.Company mgrCompany = new Neusoft.HISFC.Management.PhysicalExamination.Company();
        #endregion

        #region 公有函数
        #region 事务
        /// <summary>
        /// 事务
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            mgrCompany.SetTrans(trans);
        }
        #endregion

        #region 查询所有的体检单位信息 返回动态数组
        /// <summary>
        /// 查询所有的体检单位信息 返回动态数组
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryCompany()
        {
            this.SetDB(mgrCompany);
            return mgrCompany.QueryCompany();
        }
        #endregion

        #region 查询某个ID的体检单位信息
        /// <summary>
        /// 查询某个ID的体检单位信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Object.Pharmacy.Company GetCompanyByID(string ID)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.GetCompanyByID(ID);
        }
        #endregion

        #region 增加或删除一行数据
        /// <summary>
        /// 增加或删除一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int AddOrUpdate(Neusoft.HISFC.Object.Pharmacy.Company company)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.AddOrUpdate(company);
        }
        #endregion

        #region  删除一行数据
        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int DeleteInfo(Neusoft.HISFC.Object.Pharmacy.Company company)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.DeleteInfo(company);
        }
        #endregion
        #region 是否已经存在
        /// <summary>
        /// 是否
        /// </summary>
        /// <param name="ComCode"></param>
        /// <returns>-1 出错 ，1 没有用过 2 用过</returns>
        public int IsExistCompany(string comCode)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.IsExistCompany(comCode);
        }
        #endregion

        #endregion
    }
}
