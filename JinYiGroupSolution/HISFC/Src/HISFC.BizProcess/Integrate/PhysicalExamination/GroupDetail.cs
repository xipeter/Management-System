using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.Integrate.PhysicalExamination
{
    class GroupDetail : IntegrateBase
    {
        #region 变量
        //体检组套管理类
        protected static Neusoft.HISFC.Management.PhysicalExamination.GroupDetail mgrGroupDetail = new Neusoft.HISFC.Management.PhysicalExamination.GroupDetail();
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
            mgrGroupDetail.SetTrans(trans);
        }
        #endregion

        /// <summary>
        /// 根据科室编码获取所有项目信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryGroupTailByDeptID(string deptCode)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.QueryGroupTailByDeptID(deptCode);
        }

        /// <summary>
        /// 得到新的ID
        /// </summary>
        /// <returns></returns>
        public string GetGroupID()
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.GetGroupID();
        }

        public ArrayList QueryGroupTailByGroupID(string groupID)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.QueryGroupTailByGroupID(groupID);
        }

        /// <summary>
        /// 插入一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertGroupTail(Neusoft.HISFC.Object.PhysicalExamination.GroupDetail info)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.InsertGroupTail(info);
        }

        /// <summary>
        /// 修改一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateGroupTail(Neusoft.HISFC.Object.PhysicalExamination.GroupDetail info)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.UpdateGroupTail(info);
        }

        /// <summary>
        /// 删除一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int DeleteGroupTail(Neusoft.HISFC.Object.PhysicalExamination.GroupDetail info)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.DeleteGroupTail(info);
        }

        #endregion
    }
}
