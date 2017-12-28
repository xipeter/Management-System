using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Registration
{
	/// <summary>
	/// 挂号级别管理类
	/// </summary>
	public class RegLvlFee:Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 挂号费管理类
		/// </summary>
		public RegLvlFee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 定义
		/// <summary>
		/// 挂号费实体
		/// </summary>
		protected Neusoft.HISFC.Models.Registration.RegLvlFee regFee ;
		
		/// <summary>
		///ArrayList
		/// </summary>
		protected ArrayList al = null;
		#endregion 

		#region 增加
		
        /// <summary>
        /// 插入一条挂号费
        /// </summary>
        /// <param name="regFee"></param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.Registration.RegLvlFee regFee)
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.RegFee.Insert.1", ref sql) == -1) return -1;

            try
            {
                sql = string.Format(sql, regFee.ID, regFee.Pact.ID, regFee.RegLevel.ID, "",
                    regFee.RegFee, regFee.ChkFee, regFee.OwnDigFee, regFee.OthFee,
                    regFee.Oper.ID, regFee.Oper.OperTime.ToString(), regFee.PubDigFee);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.RegFee.Insert.1]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
            return this.ExecNoQuery(sql);
        }
		#endregion

		#region 删除
		
        /// <summary>
        /// 删除一条挂号费信息
        /// </summary>
        /// <param name="myId"></param>
        /// <returns></returns>
        public int Delete(string myId)
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.RegFee.Delete.1", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, myId);
                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.RegFee.Delete.1]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 按合同单位删除挂号费
        /// </summary>
        /// <param name="pactID"></param>
        /// <returns></returns>
        public int DeleteByPact(string pactID)
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.RegFee.Delete.Pact", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, pactID);
                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.RegFee.Delete.Pact]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 将旧合同单位挂号费复制为新合同单位挂号费
        /// </summary>
        /// <param name="newPact"></param>
        /// <param name="oldPact"></param>
        /// <returns></returns>
        public int CopyByPact(string newPact, string oldPact)
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.RegFee.Copy", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, oldPact, newPact);
                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.RegFee.Copy]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }
		#endregion

        #region 更新
        /// <summary>
        /// 更新合同单位挂号费分配信息
        /// </summary>
        /// <param name="info"></param>
        public int Update(Neusoft.HISFC.Models.Registration.RegLvlFee info)
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.RegFee.Update.1", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, info.ID, info.RegFee, info.ChkFee,
                    info.OwnDigFee, info.OthFee, info.PubDigFee);
                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.RegFee.Update.1]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }
        #endregion

        #region 查询

        #region 合同单位与挂号费
        /// <summary>
		/// 按合同单位查询挂号费信息
		/// </summary>
		/// <param name="pactID"></param>
		/// <returns></returns>
		public ArrayList Query(string pactID)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.RegFee.Query.2",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.RegFee.Query.3",ref where)==-1)return null;

			sql=sql+" "+where ;
			try
			{
				sql=string.Format(sql,pactID);
			}
			catch(Exception e)
			{
				this.Err="查询挂号级别时出错![Registration.RegFee.Query.3]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			return QueryPact(sql);			
		}
        /// <summary>
        /// 按合同单位查询挂号费信息(是否关联挂号级别)
        /// </summary>
        /// <param name="pactID"></param>
        /// <returns></returns>
        public ArrayList Query(string pactID,bool Flag)
        {
            string sql = "", where = "";
            if (Flag == true)
            {

                if (this.Sql.GetSql("Registration.RegFee.Query.10", ref sql) == -1) return null;
            }
            else 
            {
                if (this.Sql.GetSql("Registration.RegFee.Query.2", ref sql) == -1) return null;
                if (this.Sql.GetSql("Registration.RegFee.Query.3", ref where) == -1) return null;
            }
            sql = sql + " " + where;
            try
            {
                sql = string.Format(sql, pactID);
            }
            catch (Exception e)
            {
                this.Err = "查询挂号级别时出错![Registration.RegFee.Query.3]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            return QueryPact(sql);
        }


		/// <summary>
		/// 根据合同单位、挂号级别查询挂号费信息
		/// </summary>
		/// <param name="pactID"></param>
		/// <param name="regLevel"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Registration.RegLvlFee Get(string pactID,string regLevel)
		{			
			string sql="",where="";

			if(this.Sql.GetSql("Registration.RegFee.Query.2",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.RegFee.Query.4",ref where)==-1)return null;

			sql=sql+" "+where ;
			try
			{
				sql=string.Format(sql,pactID,regLevel);
			}
			catch(Exception e)
			{
				this.Err="查询挂号级别时出错![Registration.RegFee.Query.4]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			//取信息
			ArrayList al = this.QueryPact(sql);
			if(al == null) 
				return null;

			if(al.Count == 0) 
				return new Neusoft.HISFC.Models.Registration.RegLvlFee();

			return al[0] as Neusoft.HISFC.Models.Registration.RegLvlFee;
		}		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList QueryPact(string sql)
		{
			if(this.ExecQuery(sql) == -1)return null;
			try
			{
				this.al = new ArrayList();

				while(this.Reader.Read())
				{
					this.regFee = new Neusoft.HISFC.Models.Registration.RegLvlFee();

					//流水号
					regFee.ID = this.Reader[0].ToString();
					//合同单位
					regFee.Pact.ID = this.Reader[1].ToString() ;
					//挂号级别
					regFee.RegLevel.ID = this.Reader[2].ToString();
					
					//挂号费
					regFee.RegFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString() );
					//检查费
					regFee.ChkFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString() );
					//诊查费
					regFee.OwnDigFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6].ToString() );
					//附加费
					regFee.OthFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString() );
					//操作员
					regFee.Oper.ID = this.Reader[8].ToString();
					//操作时间
					regFee.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());
					
					regFee.PubDigFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString()) ;

					this.al.Add( regFee);
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="查询挂号费出错!"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			return al;
		}		
		#endregion
		#endregion
	}
}
