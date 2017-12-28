using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Nurse.InjectManager
{
    /// <summary>
    /// [功能描述: 不良反应]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-08-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary> 
    public class KickbackMgr : Neusoft.FrameWork.Management.Database
    {
        public KickbackMgr()
        {
        }

        /// <summary>
        /// 获取所有不良反应信息         /// </summary>
        /// <returns>null失败</returns>
        public List<Neusoft.HISFC.Models.Nurse.Kickback> QueryKickback()
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT.KICKBACK.SELECTALL", ref strsql) == -1)
            {
                this.Err = "读取 INJECT.KICKBACK.SELECTALL " + "失败";
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.Nurse.Kickback> kbList = new List<Neusoft.HISFC.Models.Nurse.Kickback>();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Nurse.Kickback kb = new Neusoft.HISFC.Models.Nurse.Kickback();
                kb.ID = this.Reader.IsDBNull(0) ? "" : this.Reader[0].ToString();//编码
                kb.Name = this.Reader.IsDBNull(1) ? "" : this.Reader[1].ToString();//名称
                kb.SpellCode = this.Reader.IsDBNull(2) ? "" : this.Reader[2].ToString();//拼音码                 kb.WBCode = this.Reader.IsDBNull(3) ? "" : this.Reader[3].ToString();//五笔码                 kb.UserCode = this.Reader.IsDBNull(4) ? "" : this.Reader[4].ToString();//自定义码
                if (this.Reader.IsDBNull(5))
                {
                    kb.IsValid = false;
                }
                else
                {
                    if (this.Reader[5].ToString().Trim().Equals("1"))
                    {
                        kb.IsValid = true;
                    }
                    else
                    {
                        kb.IsValid = false;
                    }
                }
                kb.Memo = this.Reader.IsDBNull(6) ? "" : this.Reader[6].ToString();//备注

                kbList.Add(kb);
            }

            return kbList;
        }

        /// <summary>
        /// 获取不良反应流水号         /// </summary>
        /// <returns>失败抛异常[ArgumentException]</returns>
        public string GetKBSequence()
        {
            string rets = this.GetSequence("INJECT.KICKBACK.GETSEQUENCE");
            if (rets == null)
            {
                throw new ArgumentException("获取流水号失败");
            }
            return rets;
        }

        /// <summary>
        /// 插入新的不良反应
        /// </summary>
        /// <param name="kb">实体</param>
        /// <returns>-1失败， 1成功</returns>
        public int InsertKBItem(Neusoft.HISFC.Models.Nurse.Kickback kb)
        {
            if (kb == null)
            {
                return -1;
            }
            string strsql = "";
            if (this.Sql.GetSql("INJECT.KICKBACK.INSERTITEM", ref strsql) == -1)
            {
                this.Err = "获取INJECT.KICKBACK.INSERTITEM 失败";
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,
                                       kb.ID,
                                       kb.Name,
                                       kb.SpellCode,
                                       kb.WBCode,
                                       kb.UserCode,
                                       (kb.IsValid ? "1" : "0"),
                                       kb.OperEnv.ID,
                                       kb.OperEnv.Name,
                                       kb.OperEnv.OperTime.ToString(),
                                       kb.Memo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 更新不良反应项目
        /// </summary>
        /// <param name="kb">实体</param>
        /// <returns>-1失败，1成功</returns>
        public int UpdateKBItem(Neusoft.HISFC.Models.Nurse.Kickback kb)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT.KICKBACK.UPDATEITEM_ID", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,
                                       kb.Name,
                                       kb.SpellCode,
                                       kb.WBCode,
                                       kb.UserCode,
                                       (kb.IsValid ? "1" : "0"),
                                       kb.OperEnv.ID,
                                       kb.OperEnv.Name,
                                       kb.OperEnv.OperTime.ToString(),
                                       kb.Memo,
                                       kb.ID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }

            return 1;
        }
    }
}
