using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Fee
{
    public  class InvoiceJumpRecord:Neusoft.FrameWork.Management.Database
    {
        #region  插入
        /// <summary>
        ///  插入表
        /// </summary>
        /// <param name="invoiceRecord"></param>
        /// <returns></returns>
        public int InsertTable(Neusoft.HISFC.Models.Fee.InvoiceJumpRecord invoiceRecord)
        {
            string[] args = this.GetArgs(invoiceRecord);

            if (args == null)
            {
                return -1;
            }

            string StrSql = string.Empty;

            int returnValue = this.Sql.GetSql("Fee.JumpRecord.Insert", ref StrSql);

            if (returnValue < 0)
            {
                this.Err = "没有找到索引为Fee.JumpRecord.Insert的SQL语句";
                return -1;
            }

            StrSql = string.Format(StrSql, args);

            return this.ExecNoQuery(StrSql); ;
        }

        /// <summary>
        /// 获取最大序号
        /// </summary>
        /// <param name="acceptCode"></param>
        /// <param name="invoiceTypeID"></param>
        /// <returns></returns>
        public string GetMaxHappenNO(string acceptCode, string invoiceTypeID)
        {
            string StrSql = string.Empty;

            int returnValue = this.Sql.GetSql("Fee.JumpRecord.GetMaxHappenNO", ref StrSql);

            if (returnValue < 0)
            {
                this.Err = "没有找到索引为Fee.JumpRecord.GetMaxHappenNO的SQL语句";
                return "-1";
            }

            StrSql = string.Format(StrSql, acceptCode,invoiceTypeID);

            return  this.ExecSqlReturnOne(StrSql);
             
        }
        #endregion

        #region 更新
        
        #endregion

        #region 查询


        
        #endregion

        #region 私有方法

        /// <summary>
        /// 实体赋值
        /// </summary>
        /// <param name="invoiceRecord"></param>
        /// <returns></returns>
        private string[] GetArgs(Neusoft.HISFC.Models.Fee.InvoiceJumpRecord invoiceRecord)
        {
            string[] args;
            try
            {
                args = new string[] {
                    invoiceRecord.Invoice.AcceptOper.ID,
                    invoiceRecord.HappenNO.ToString(),
                    invoiceRecord.Invoice.Type.ID,
                    invoiceRecord.Invoice.Type.Name,
                    invoiceRecord.Invoice.BeginNO,
                    invoiceRecord.Invoice.EndNO,
                    invoiceRecord.OldUsedNO,
                    invoiceRecord.NewUsedNO,
                    invoiceRecord.Oper.ID,
                    invoiceRecord.Oper.OperTime.ToString()
                    };
            }
            catch (Exception ex)
            {
                this.Err = "实体赋值出错" + ex.Message;
                return null;
            }
            return args;

        }
        #endregion
    }
}
