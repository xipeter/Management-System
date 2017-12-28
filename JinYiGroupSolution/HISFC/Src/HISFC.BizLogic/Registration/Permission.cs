using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Registration
{
	/// <summary>
	/// 挂号科室管理类
	/// </summary>
	public class Permission:Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 挂号科室管理类
		/// </summary>
		public Permission()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 数组
		/// </summary>
		protected ArrayList al=null;
		/// <summary>
		/// neuObject
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject obj=null;

        #region 查询
        /// <summary>
		/// 获得能操作某一窗口的人员列表
		/// </summary>
		/// <param name="formName"></param>
		/// <returns></returns>
		public ArrayList Query(string formName)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.Permission.Query.1",ref sql)==-1)return null;

			try
			{
				sql=string.Format(sql,formName);
			}
			catch(Exception e)
			{
				this.Err="[Registration.Permission.Query.1]格式不匹配!"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			this.al=new ArrayList();

			try
			{
				if(this.ExecQuery(sql)==-1)return null;
				while(this.Reader.Read())
				{
					obj=new Neusoft.FrameWork.Models.NeuObject();
					obj.ID=this.Reader[0].ToString();//员工代码
					obj.Name=this.Reader[1].ToString();//员工名称

					this.al.Add(obj);
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="获取操作窗口"+formName+"的人员列表出错!"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			return al;
		}
		/// <summary>
		/// 查询人员负责挂号科室
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		public ArrayList Query(Neusoft.FrameWork.Models.NeuObject person)//{8AB04EE1-0A7B-45f9-A897-8CD01CE29ED1}
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Permission.Query.2",ref sql)==-1)return null;

			this.al=new ArrayList();
			try
			{
				sql=string.Format(sql,person.ID);
				if(this.ExecQuery(sql)==-1)return null;

				while(this.Reader.Read())
				{
					this.obj=new Neusoft.FrameWork.Models.NeuObject();

					this.obj.ID=this.Reader[2].ToString();//员工代码
					this.obj.User01=this.Reader[3].ToString();//挂号科室
					this.obj.User02=this.Reader[4].ToString();//操作员
					this.obj.User03=this.Reader[5].ToString();//操作时间

                    //修改挂号权限 {E2B7B9D5-6FE1-4849-AAEC-ABD916075049}
                    if (this.Reader.FieldCount >= 6)
                    {

                        this.obj.Memo = this.Reader[6].ToString();
                    }

					this.al.Add(this.obj);
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="查询人员挂号科室权限出错!"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			return this.al;

        }
        /// <summary>
        /// 查询人员负责挂号科室（排除）{8AB04EE1-0A7B-45f9-A897-8CD01CE29ED1}
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public ArrayList QueryOutContain(Neusoft.FrameWork.Models.NeuObject person)
        {
            string sql = "";
            if (this.Sql.GetSql("Registration.Permission.Query.3", ref sql) == -1) return null;

            this.al = new ArrayList();
            try
            {
                sql = string.Format(sql, person.ID);
                if (this.ExecQuery(sql) == -1) return null;

                while (this.Reader.Read())
                {
                    this.obj = new Neusoft.FrameWork.Models.NeuObject();

                    this.obj.ID = person.ID;//员工代码
                    this.obj.User01 = this.Reader[0].ToString();//挂号科室

                    this.al.Add(this.obj);
                }
                this.Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = "查询人员挂号科室权限出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            return this.al;

        }
        #endregion

        #region 插入
        /// <summary>
        /// 登记人员挂号科室表{8AB04EE1-0A7B-45f9-A897-8CD01CE29ED1}
		/// </summary>
		/// <param name="permission"></param>
		/// <returns></returns>
		public int Insert(Neusoft.FrameWork.Models.NeuObject permission)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Permission.Insert",ref sql)==-1)return -1;

			try
			{
                ////修改挂号权限 {E2B7B9D5-6FE1-4849-AAEC-ABD916075049}
				sql=string.Format(sql,permission.ID,permission.User01,permission.User02,permission.Memo);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="插入挂号员权限表出错![Registration.Permission.Insert]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
        }
        #endregion

        #region 删除
        /// <summary>
		/// 删除挂号员负责的挂号科室
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public int Delete(string userID)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.Permission.Delete",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,userID);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除挂号员权限表出错![Registration.Permission.Delete]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
        }
        #endregion
    }
}
