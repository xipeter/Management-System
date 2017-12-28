using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.RADT.Classes
{
    class LocalManager:Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 获取领用情况
        /// </summary>
        private static string GetRecipePersonSql = @"select count(a.in_patientno) from zz_recipe_history a where a.in_patientno = '{0}' ";
        /// <summary>
        /// 更新领用情况
        /// </summary>
        private static string UpdateRecipePersonSql = @"update zz_recipe_history t
                                                                                   set t.flag = '{0}', t.oper_time = sysdate
                                                                                 where t.in_patientno = '{1}'";
        /// <summary>
        /// 添加领用情况
        /// </summary>
        private static string InsertRecipePerson = @" insert into zz_recipe_history values ('{0}', '1', '{1}', sysdate)";
        /// <summary>
        /// 获取领用标识
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public string GetReceiptPerson(string inpatientNo) {
            string sql = string.Format(GetRecipePersonSql, inpatientNo);
            return this.ExecSqlReturnOne(sql);
        }
        /// <summary>
        /// 更新领用标识
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="opercode"></param>
        /// <returns></returns>
        public int UpdateRecipePerson(string inpatientNo,string opercode) {
            string rev = this.GetReceiptPerson(inpatientNo);
            int flag = 1;
            string sql = string.Format(InsertRecipePerson,inpatientNo,opercode);
            if (rev == "0")
            {
                if (this.ExecNoQuery(sql) < 0)
                {
                    flag = -1;
                }
            }
            //else {
            //    sql = string.Format(UpdateRecipePersonSql, inpatientNo);
            //    if (this.ExecNoQuery(sql) < 0) {
            //        flag = -1;
            //    }
            //}
            return flag;
        }
    }
}
