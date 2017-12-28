using System;
using System.Collections.Generic;
using System.Collections;

namespace Neusoft.HISFC.Integrate.PhysicalExamination
{
    class Group : IntegrateBase
    {
        #region 变量
        //体检组套管理类
        protected static Neusoft.HISFC.Management.PhysicalExamination.Group mgrGroup = new Neusoft.HISFC.Management.PhysicalExamination.Group();
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
            mgrGroup.SetTrans(trans);
        }
         #endregion
        /// <summary>
        /// 获取所有组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryAllGroups()
        {
            this.SetDB(mgrGroup);
            return mgrGroup.QueryAllGroups();
        }

        /// <summary>
        /// 根据组套ID获取组套信息
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Object.PhysicalExamination.Group GetGroupByGroupID(string groupID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.GetGroupByGroupID(groupID);
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertGroup(Neusoft.HISFC.Object.PhysicalExamination.Group info)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.InsertGroup(info);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateGroup(Neusoft.HISFC.Object.PhysicalExamination.Group info)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.UpdateGroup(info);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public int DeleteGroup(Neusoft.HISFC.Object.PhysicalExamination.Group info)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.DeleteGroup(info);
        }

        /// <summary>
        /// 删除组套所有明细
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int DelGroupDetails(string groupID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.DelGroupDetails(groupID);
        }

        /// <summary>
        /// 按科室获取所有有效组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryValidGroupList(string deptID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.QueryValidGroupList(deptID);
        }

        /// <summary>
        /// 按科室获取所有有效组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryAllGroupListByDeptID(string deptID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.QueryAllGroupListByDeptID(deptID);
        }

        #endregion 
    }
}
