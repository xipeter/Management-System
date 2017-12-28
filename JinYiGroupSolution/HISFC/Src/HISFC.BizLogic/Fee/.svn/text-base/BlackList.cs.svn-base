using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.BlackList;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Fee
{
    /// <summary>
    /// 黑名单管理业务层
    /// </summary>
    public class PBlackList :Neusoft.FrameWork.Management.Database
    {

        #region 私有
        /// <summary>
        /// 单表更新
        /// </summary>
        /// <param name="SqlIndex">SQL语句索引</param>
        /// <param name="args">格式化字符串数组</param>
        /// <returns></returns>
        private int UpdateSigleTable(string SqlIndex,params string[] args)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql(SqlIndex, ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句" + SqlIndex + "失败！";
                return -1;
            }
            int resultValue = this.ExecNoQuery(sqlStr, args);
            return resultValue;
        }
        #endregion

        #region 公有
        /// <summary>
        /// 根据病历号查找黑名单数据
        /// </summary>
        /// <param name="cardNO"></param>
        /// <param name="pbl"></param>
        /// <returns></returns>
        public int GetBlackList(string cardNO, ref PatientBlackList pbl)
        {
            int resultValue = this.GetBlackListMain(cardNO, ref pbl);
            if (resultValue == -1)
            {
                return -1;
            }
            List<PatientBlackListDetail> list = new List<PatientBlackListDetail>();
            resultValue = this.GetBlackListDetail(cardNO, ref list);
            if (resultValue == -1)
            {
                return -1;
            }
            pbl.BlackListDetail = list;
            return 1;
        }

        /// <summary>
        /// 根据病历号查找黑名单主表数据
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="pbl">黑名单实体</param>
        /// <returns></returns>
        public int GetBlackListMain(string cardNO, ref PatientBlackList pbl)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Fee.BlackList.SelectBlackList", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句Fee.BlackList.SelectBlackList失败！";
                return -1;
            }
            try
            {
                sqlStr = string.Format(sqlStr, cardNO);
                if (this.ExecQuery(sqlStr) == -1)
                {
                    this.Err = "查找患者黑名单数据失败！";
                    return -1;
                }
               
                pbl = new PatientBlackList();
                while (this.Reader.Read())
                {
                    
                    pbl.CardNO = this.Reader[0].ToString();
                    pbl.BlackListValid = NConvert.ToBoolean(this.Reader[1].ToString());
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 根据病历号查找黑名单明细数据
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="list">黑名单明细数据</param>
        /// <returns></returns>
        public int GetBlackListDetail(string cardNO,ref List<PatientBlackListDetail> list)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Fee.BlackList.SelectBlackListDetail", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句Fee.BlackList.SelectBlackList失败！";
                return -1;
            }
            try
            {
                sqlStr = string.Format(sqlStr, cardNO);
                if (this.ExecQuery(sqlStr) == -1)
                {
                    this.Err = "查找患者黑名单明细数据失败！";
                    return -1;
                }

                list = new List<PatientBlackListDetail>();
                PatientBlackListDetail obj = null;
                while (this.Reader.Read())
                {
                    obj = new PatientBlackListDetail();
                    obj.SeqNO = this.Reader[0].ToString();
                    obj.BlackListValid = NConvert.ToBoolean(this.Reader[1]);
                    obj.Memo = this.Reader[2].ToString();
                    obj.Oper.Name = this.Reader[3].ToString();
                    obj.Oper.OperTime = NConvert.ToDateTime(this.Reader[4]);
                    list.Add(obj);
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 更新患者是否在黑名单中
        /// </summary>
        ///<param name="cardNO">病历号</param>
        /// <param name="blackListValid">是否在黑名单中 "0"不在 "1"在</param>
        /// <returns></returns>
        public int UpdateBlackList(PatientBlackList pbl)
        {
            //{E8D9B53F-9C12-4f6e-8F7C-A94FB6B9D173}
            string[] args = new string[] { pbl.CardNO, NConvert.ToInt32(pbl.BlackListValid).ToString(), NConvert.ToInt32(!pbl.BlackListValid).ToString() };
            return this.UpdateSigleTable("Fee.BlackList.UpdateBlackList", args);
        }

        /// <summary>
        /// 将患者插入黑名单中
        /// </summary>
        ///<param name="cardNO">病历号</param>
        /// <param name="blackListValid">是否在黑名单中 "0"不在 "1"在</param>
        /// <returns></returns>
        public int InsertBlackList(PatientBlackList pbl)
        {
            string[] args = new string[] { pbl.CardNO, NConvert.ToInt32(pbl.BlackListValid).ToString() };
            return this.UpdateSigleTable("Fee.BlackList.InsertBlackList", args);
        }

        /// <summary>
        /// 保存黑名单主表数据
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <param name="blackListValid">是否在黑名单中 "0"不在 "1"在</param>
        /// <returns></returns>
        public int SaveBlackList(PatientBlackList pbl)
        {
            int resultValue = InsertBlackList(pbl);
            if (resultValue == -1)
            {
                resultValue = UpdateBlackList(pbl);
            }
            return resultValue;
        }

        /// <summary>
        /// 插入黑名单明细
        /// </summary>
        /// <param name="pbl">黑名单实体</param>
        /// <returns></returns>
        public int AddBlackListDetail(PatientBlackList pbl)
        {
            if (pbl.BlackListDetail == null || pbl.BlackListDetail.Count == 0)
            {
                this.Err = "保存黑名单明细数据失败！";
                return -1;
            }
            PatientBlackListDetail pbld = pbl.BlackListDetail[0];
            
            string[] args = new string[] 
                            {
                                pbld.SeqNO,
                                pbl.CardNO,
                                NConvert.ToInt32(pbld.BlackListValid).ToString(),
                                pbld.Memo,
                                pbld.Oper.ID,
                                pbld.Oper.OperTime.ToString()
                            };
            return UpdateSigleTable("Fee.BlackList.InsertBlackListDetail", args);
        }

        /// <summary>
        /// 获得黑名单序列
        /// </summary>
        /// <returns></returns>
        public string GetBlackListSeqNo()
        {
            return this.GetSequence("Fee.BlackList.SelectBlackListSeqNO");
        }
        #endregion
    }
}
