using System;
namespace Neusoft.FrameWork.Management
{
    /// <summary>
    /// Transaction<br></br>
    /// [功能描述: Transaction类]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Transaction
    {

        public Transaction()
        {

        }
        /// <summary>
        /// 构造函数 传递数据库连接生成数据库事务
        /// </summary>
        /// <param name="con">连接</param>
        public Transaction(System.Data.IDbConnection con)
        {
            this.con = con;
        }

        /// <summary>
        /// 当前已经连接的事务 传递给管理类的command 调用setTrans(SQLCA.Trans)
        /// </summary>
        public System.Data.IDbTransaction Trans;
        private System.Data.IDbConnection con;

        /// <summary>
        /// 开始事务 递数据库连接生成数据库事务
        /// </summary>
        /// <param name="con">连接</param>
        [Obsolete("用全局事务publicTrans.BeginTransaction()代替处理!", true)]
        public void BeginTransaction(System.Data.IDbConnection con)
        {
            this.con = con;
            BeginTransaction();
            Trans = PublicTrans.Trans;
        }

        public string Err = "";
        /// <summary>
        /// 开始事务
        /// </summary>
        [Obsolete("用全局事务publicTrans.BeginTransaction()代替处理!", true)]
        public void BeginTransaction()
        {   
             PublicTrans.BeginTransaction();
             Trans = PublicTrans.Trans;
        }
        /// <summary>
        /// rollback;
        /// </summary>
        [Obsolete("用全局事务publicTrans.RollBack()代替处理!", true)]
        public void RollBack()
        {
            PublicTrans.RollBack();
        }
        /// <summary>
        /// commit;
        /// </summary>
        [Obsolete("用全局事务publicTrans.Commit()代替处理!", true)]
        public void Commit()
        {
            PublicTrans.Commit();
        }
    }
}
