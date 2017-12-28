using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizProcess.Integrate.Registration
{
    public class Tabulation : IntegrateBase
    {
        /// <summary>
        /// 排班管理类
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Operation.Tabulation tabulationManager = new Neusoft.HISFC.BizLogic.Operation.Tabulation();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            tabulationManager.SetTrans(trans);
        }

        #region  方法

        #region 增、删、改
        /// <summary>
        /// 插入出勤类别_goa_med_worktype
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.Registration.WorkType type)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Insert(type);
        }
        /// <summary>
        /// 插入科常用出勤类别_goa_med_depttype,出勤类别实体,实体只要赋值id,OperID
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Insert(string deptID, Neusoft.HISFC.Models.Registration.WorkType type)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Insert(deptID, type);
        }
        /// <summary>
        /// 插入排班_goa_med_tabulation
        /// </summary>
        /// <param name="tabular"></param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.Registration.Tabulation tabular)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Insert(tabular);
        }
        /// <summary>
        /// 删除科常用出勤类别
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(string deptID, string ID)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Delete(deptID, ID);
        }
        /// <summary>
        /// 删除出勤类别
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(string ID)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Delete(ID);
        }
        /// <summary>
        /// 根据排班序号删除排班记录
        /// </summary>
        /// <param name="arrangeID"></param>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public int DeleteTabular(string arrangeID, string deptID)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.DeleteTabular(arrangeID, deptID);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 按安排序号查询排班信息
        /// </summary>
        /// <param name="arrangeID"></param>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList Query(string arrangeID, string deptID)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Query(arrangeID, deptID);
        }
        /// <summary>
        /// 按出勤日期、科室查询排班信息
        /// </summary>
        /// <param name="workDate"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public ArrayList Query(DateTime workDate, Neusoft.FrameWork.Models.NeuObject dept)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Query(workDate, dept);
        }
        /// <summary>
        /// 按时间段、科室查询排班序号
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList Query(DateTime beginDate, string deptID)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Query(beginDate, deptID);
        }

        /// <summary>
        /// 查询科常用出勤类别
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList Query(string deptID)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Query(deptID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="deptcode"></param>
        /// <param name="classcode"></param>
        /// <returns></returns>
        public ArrayList QueryTabular(DateTime begin, DateTime end, string deptcode, string classcode)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.QueryTabular(begin, end, deptcode, classcode);
        }


        /// <summary>
        /// 查询全部、有效、无效出勤类别
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public ArrayList Query(Neusoft.HISFC.BizLogic.Operation.QueryState state)
        {
            this.SetDB(tabulationManager);
            return tabulationManager.Query(state);
        } 

        #endregion
        #endregion 
    }
}
