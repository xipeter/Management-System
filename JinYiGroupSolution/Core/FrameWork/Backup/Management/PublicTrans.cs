using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.Management
{
    /// <summary>
    /// 全局事务处理
    /// 2007 wolf create
    /// 2009 wolf add connect db while handle db
    /// </summary>
    public class PublicTrans
    {
        #region 新加
        public static Neusoft.FrameWork.Models.NeuLog log = new Neusoft.FrameWork.Models.NeuLog("./err.log");

        /// <summary>
        /// 开始事务 递数据库连接生成数据库事务
        /// </summary>
        public static void BeginTransaction()
        {
           // Server.Function manager = new Neusoft.NFC.Server.Function();
            Server.Function.Manager.BeginTransaction();
            Trans = Server.Function.Manager.GetTrans();

        }

        /// <summary>
        /// 当前已经连接的事务 传递给管理类的command 调用setTrans(SQLCA.Trans)
        /// </summary>
        public static System.Data.IDbTransaction Trans;

        public static string Err = "";

        /// <summary>
        /// rollback;
        /// </summary>
        public static void RollBack()
        {
            //Server.Function manager = new Neusoft.NFC.Server.Function();

            Server.Function.Manager.Rollback();            
            Trans = null;
        }
        /// <summary>
        /// commit;
        /// </summary>
        public static void Commit()
        {
            //Server.Function manager = new Neusoft.NFC.Server.Function();
            Server.Function.Manager.Commit();
            Trans = null;
        }
        #endregion
    }
}
