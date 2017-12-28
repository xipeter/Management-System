using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.WinForms.Report.Manager
{
    /// <summary>
    /// 功能描述: 返回医保等级
    /// 
    ///  {112B7DB5-0462-4432-AD9D-17A7912FFDBE} 
    /// </summary>
    public class GetSiItemGradeReal : Neusoft.FrameWork.Management.Database, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade
    {
        #region 变量
        System.Collections.Hashtable ht = new System.Collections.Hashtable();
        #endregion


        public GetSiItemGradeReal()
        {
            //添加所有项目
            this.GetItems();
        }

        #region IGetSiItemGrade 成员

        /// <summary>
        /// 根据合同单位项目编码获取医保等级
        /// </summary>
        /// <param name="pactID"></param>
        /// <param name="hisItemCode"></param>
        /// <param name="siGrade"></param>
        /// <returns></returns>
        public int GetSiItemGrade(string pactID, string hisItemCode, ref string siGrade)
        {
            if (this.ht.ContainsKey(pactID + hisItemCode))
            {
                siGrade = this.ht[pactID + hisItemCode].ToString();
                //转换
                siGrade = this.GetGrade(siGrade);
            }
            else
            {
                //自费
                siGrade = "4";
            }
            return 1;
        }

        /// <summary>
        /// 根据项目编码获取医保等级
        /// </summary>
        /// <param name="hisItemCode">医院项目编码</param>
        /// <param name="siGrade">医保等级</param>
        /// <returns></returns>
        public int GetSiItemGrade(string hisItemCode, ref string siGrade)
        {


            if (this.ht.ContainsKey(this.defaultPactCode + hisItemCode)) //存在
            {
                siGrade = this.ht[this.defaultPactCode + hisItemCode].ToString();
                //转换
                siGrade = this.GetGrade(siGrade);
            }
            else
            {
                //自费
                siGrade = "4";
            }

            //转换

            return 1;

        }

        private string defaultPactCode = "";

        /// <summary>
        /// 取所有项目
        /// </summary>
        /// <returns></returns>
        protected virtual System.Collections.Hashtable GetItems()
        {
            string strSql = string.Format("select a.pact_code,a.his_code, a.center_item_grade from fin_com_compare a ");
            int result = this.ExecQuery(strSql);
            string strPactAndItem = string.Empty;
            string strGrade = string.Empty;
            if (result == -1)
            {

                this.Err = "查询对照信息表失败";
                return null;
            }
            while (this.Reader.Read())
            {
                if (this.defaultPactCode == "")
                {
                    this.defaultPactCode = this.Reader[0].ToString();
                }
                strPactAndItem = this.Reader[0].ToString() + this.Reader[1].ToString();
                strGrade = this.Reader[2].ToString();
                this.ht.Add(strPactAndItem, strGrade);
            }
            this.Reader.Close();
            return ht;
        }

        /// <summary>
        /// 预留
        /// </summary>
        /// <param name="strCenterGrade"></param>
        /// <returns></returns>
        protected virtual string GetGrade(string strCenterGrade)
        {
            return strCenterGrade;
        }

        #endregion
    }
}
