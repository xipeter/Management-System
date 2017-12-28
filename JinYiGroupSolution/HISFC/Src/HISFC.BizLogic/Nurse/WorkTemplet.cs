using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Nurse
{
    /// <summary>
    /// 排班模版管理类
    /// </summary>
    public class WorkTemplet : Neusoft.FrameWork.Management.Database
    {
        public WorkTemplet()
        {
        }
        #region 增加
        /// <summary>
		/// 登记一条护士排班模板
		/// </summary>
		/// <param name="templet"></param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Nurse.WorkTemplet templet)
		{
			string sql = "";

			if(this.Sql.GetSql("Nurse.WorkTemplet.Insert",ref sql) == -1)return -1;

            #region SQL
     //       INSERT INTO met_nui_worktemplet   --排班模板表
     //     ( 
     //       id,   --序号
     //       week,   --星期
     //       nrs_cell_code, --护士站编号
     //       cell_name, --护士站名称
     //       dept_code,   --科室号
     //       dept_name,   --科室名称
     //       nrs_code,   --医生代码
     //       nrs_name,   --医生名称
     //       noon_code,   --午别
     //       noon_name,    --午别名称
     //       valid_flag,   --0有效/1无效
     //       remark,   --备注
     //       oper_code,   --操作员代码
     //       oper_date,  --最近变动日期
     //       nrs_type,  --护士类别
     //       begin_time, --开始时间
     //       end_time,	--结束时间
     //         reason_no, --原因
     //         reason_name --原因名称
     //       )
     //VALUES 
     //     (  
     //       '{0}',   --序号
     //       '{1}',   --星期
     //       '{2}',   --护士站编号
     //       '{3}',   --护士站名称
     //       '{4}',   --科室号
     //       '{5}',   --科室名称
     //       '{6}',   --护士代码
     //       '{7}',   --护士名称
     //       '{8}',   --午别
     //       '{9}',   --午别名称
     //       '{10}',   --0有效/1无效
     //       '{11}',   --备注
     //       '{12}',  --操作员代码
     //       to_date('{13}','yyyy-mm-dd hh24:mi:ss'), --最近变动日期
     //       '{14}',   --护士类别
     //       to_date('{15}','yyyy-mm-dd hh24:mi:ss'), --开始时间
     //       to_date('{16}','yyyy-mm-dd hh24:mi:ss'), --结束时间
     //       '{17}',  --原因
     //       '{18}',  --原因名称 )
            #endregion
			try
			{
                sql = string.Format(sql, templet.ID, (int)templet.Week, templet.NurseCell.ID, templet.NurseCell.Name,
                    templet.Dept.ID, templet.Dept.Name, templet.Employee.ID, templet.Employee.Name, templet.Noon.ID,
                    templet.Noon.Name, Neusoft.FrameWork.Function.NConvert.ToInt32(templet.IsValid),
                    templet.Memo, templet.Oper.ID, templet.Oper.OperTime, templet.EmplType.ID,
                    templet.Begin.ToString(), templet.End.ToString(), templet.Reason.ID, templet.Reason.Name);
            }
			catch(Exception e)
			{
                this.Err = "[Nurse.WorkTemplet.Insert]格式不匹配!" + e.Message;
				this.ErrCode = e.Message;
				return -1;
			}
			return this.ExecNoQuery(sql);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据ID删除一条护士模板记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(string ID)
        {
            string sql = "";

            if (this.Sql.GetSql("Nurse.WorkTemplet.Delete", ref sql) == -1) return -1;

            try
            {
                sql = string.Format(sql, ID);
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.WorkTemplet.Delete]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据星期、科室查询排班模板
        /// </summary>
        /// <param name="schemaType"></param>
        /// <param name="week"></param>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public ArrayList Query(DayOfWeek week, string DeptID)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Nurse.WorkTemplet.Query", ref sql) == -1) return null;
            if (this.Sql.GetSql("Nurse.WorkTemplet.Query.ByWeek&Dept", ref where) == -1) return null;

            sql = sql + " " + where;

            try
            {
                sql = string.Format(sql,(int)week, DeptID);
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.WorkTemplet.Query.ByWeek&Dept]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            return this.QueryBase(sql);
        }

        /// <summary>
        /// 根据星期查询是否有效模板信息。
        /// 模板调用
        /// </summary>
        /// <param name="schemaType"></param>
        /// <param name="week"></param>
        /// <param name="IsValid"></param>
        /// <returns></returns>
        public ArrayList Query(DayOfWeek week, bool IsValid)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Nurse.WorkTemplet.Query", ref sql) == -1) return null;
            if (this.Sql.GetSql("Nurse.WorkTemplet.Query.ByWeek&VaildState", ref where) == -1) return null;

            sql = sql + " " + where;

            try
            {
                sql = string.Format(sql, (int)week, Neusoft.FrameWork.Function.NConvert.ToInt32(IsValid));
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.WorkTemplet.Query.ByWeek&VaildState]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            return this.QueryBase(sql);
        }

        /// <summary>
        /// 模板实体
        /// </summary>
        protected Neusoft.HISFC.Models.Nurse.WorkTemplet workTemplet;

        protected ArrayList al;
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private ArrayList QueryBase(string sql)
        {
            if (this.ExecQuery(sql) == -1) return null;

            this.al = new ArrayList();

            try
            {
                while (this.Reader.Read())
                {
                    this.workTemplet = new Neusoft.HISFC.Models.Nurse.WorkTemplet();

                    this.workTemplet.ID = this.Reader[2].ToString();
                    this.workTemplet.Week = (DayOfWeek)(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString()));
                    this.workTemplet.NurseCell.ID = this.Reader[4].ToString();
                    this.workTemplet.NurseCell.Name = this.Reader[5].ToString();
                    this.workTemplet.Dept.ID = this.Reader[6].ToString();
                    this.workTemplet.Dept.Name = this.Reader[7].ToString();
                    this.workTemplet.Employee.ID = this.Reader[8].ToString();
                    this.workTemplet.Employee.Name = this.Reader[9].ToString();
                    this.workTemplet.Noon.ID = this.Reader[10].ToString();
                    this.workTemplet.Noon.Name = this.Reader[11].ToString();
                    this.workTemplet.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[12].ToString());
                    this.workTemplet.Memo = this.Reader[13].ToString();
                    this.workTemplet.Oper.ID = this.Reader[14].ToString();
                    this.workTemplet.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[15].ToString());
                    this.workTemplet.EmplType.ID = this.Reader[16].ToString();
                    this.workTemplet.Begin = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[17].ToString());
                    this.workTemplet.End = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[18].ToString());
                    this.workTemplet.Reason.ID = this.Reader[19].ToString();
                    this.workTemplet.Reason.Name = this.Reader[20].ToString();

                    this.al.Add(this.workTemplet);
                }

                this.Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = "查询排班模板信息出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            return al;
        }
        #endregion
    }
}
