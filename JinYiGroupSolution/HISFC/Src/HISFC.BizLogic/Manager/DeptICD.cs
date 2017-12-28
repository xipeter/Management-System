using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Manager
{
    /// <summary>
    /// 科室常用诊断维护
    /// 创建者：孙盟
    /// 创建时间：2010-05-20
    /// 修改人：
    /// 修改日期：
    /// 修改原因
    /// {6EF7D73B-4350-4790-B98C-C0BD0098516E}
    /// </summary>
    public class DeptICD : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 
        /// </summary>
        public DeptICD()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 插入科常用诊断
        /// </summary>
        /// <param name="deptDiag">科常用诊断</param>
        /// <returns></returns>
        public int InsertDeptDiag(Neusoft.FrameWork.Models.NeuObject deptDiag)
        {
            string strSql = "";

            if (this.Sql.GetSql("Manager.DeptDiag.InsertDiag", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = String.Format(strSql,
                                       deptDiag.ID,/*科室代码*/
                                       deptDiag.Name,/*icd码*/
                                       deptDiag.Memo,/*疾病名称*/
                                       deptDiag.User01.ToString(),/*拼音码*/
                                       deptDiag.User02.ToString()/*操作员*/
                                      );
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句出错！" + ex.Message;
                return -1;
            }

            //执行SQL语句
            return this.ExecNoQuery(strSql);

        }

        /// <summary>
        /// 删除一条科常用诊断
        /// </summary>
        /// <param name="deptDiag"></param>
        /// <returns></returns>
        public int DeleteDeptDiag(Neusoft.FrameWork.Models.NeuObject deptDiag)
        {
            string strSql = "";

            if (this.Sql.GetSql("Manager.DeptDiag.DeleteDiag", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = String.Format(strSql, deptDiag.ID, deptDiag.Name);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句出错！" + ex.Message;
                return -1;
            }

            //执行SQL语句
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 按科室查询科常用诊断
        /// </summary>
        /// <param name="deptID">科室编码</param>
        /// <returns></returns>
        public ArrayList QueryDeptDiagByDept(string deptID)
        {
            string strSql = "";

            if (this.Sql.GetSql("Manager.DeptDiag.QueryDiagByDept", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            try
            {
                strSql = String.Format(strSql, deptID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句出错！" + ex.Message;
                return null;
            }

            if (this.ExecQuery(strSql) == -1)
            {
                return null;
            }

            ArrayList al = new ArrayList();

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

                    obj.ID = this.Reader[0].ToString();//科室
                    obj.Name = this.Reader[1].ToString();//ICD编码
                    obj.Memo = this.Reader[2].ToString();//ICD名称
                    obj.User01 = this.Reader[3].ToString();//拼音码
                    obj.User02 = this.Reader[4].ToString();//操作员
                    obj.User03 = this.Reader[5].ToString();//操作时间

                    al.Add(obj);
                }

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                this.Reader.Close();
                return null;
            }

            this.Reader.Close();

            return al;
        }

    }
}
