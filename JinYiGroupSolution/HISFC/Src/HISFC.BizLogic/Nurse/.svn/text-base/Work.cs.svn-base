using System;
using System.Collections;
using System.Data;

namespace Neusoft.HISFC.BizLogic.Nurse
{
   /// <summary>
   /// 排班管理类
   /// </summary>
    public class Work : Neusoft.FrameWork.Management.Database
    {
        public Work()
        {

        }
        #region 增加
        /// <summary>
        /// 增加一条排班记录
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.Nurse.Work work)
        {
            string sql = "";

            if (this.Sql.GetSql("Nurse.Work.Insert", ref sql) == -1) return -1;
 
            try
            {
                #region SQL
     //          INSERT INTO met_nui_work  --排班模板表
     //     ( 
     //       id,   --序号
     //       week,   --星期
     //       nrs_date, --护士排班日期
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
     //       '{2}',   --护士排班日期
     //       '{3}',   --护士站编号
     //       '{4}',   --护士站名称
     //       '{5}',   --科室号
     //       '{6}',   --科室名称
     //       '{7}',   --护士代码
     //       '{8}',   --护士名称
     //       '{9}',   --午别
     //       '{10}',   --午别名称
     //       '{11}',   --0有效/1无效
     //       '{12}',   --备注
     //       '{13}',  --操作员代码
     //       to_date('{14}','yyyy-mm-dd hh24:mi:ss'), --最近变动日期
     //       '{15}',   --护士类别
     //       to_date('{16}','yyyy-mm-dd hh24:mi:ss'), --开始时间
     //       to_date('{17}','yyyy-mm-dd hh24:mi:ss'), --结束时间
     //       '{18}',  --原因
     //       '{19}' --原因名称)
                #endregion
                sql = string.Format(sql, work.Templet.ID, (int)work.Templet.Week, work.WorkDate.ToString(),
                    work.Templet.NurseCell.ID.ToString(), work.Templet.NurseCell.Name.ToString(), work.Templet.Dept.ID,
                    work.Templet.Dept.Name, work.Templet.Employee.ID, work.Templet.Employee.Name, work.Templet.Noon.ID,
                    work.Templet.Noon.Name, Neusoft.FrameWork.Function.NConvert.ToInt32(work.Templet.IsValid.ToString()),
                    work.Templet.Memo, work.Templet.Oper.ID, work.Templet.Oper.OperTime, work.Templet.EmplType.ID,
                    work.Templet.Begin.ToString(), work.Templet.End.ToString(), work.Templet.Reason.ID,
                    work.Templet.Reason.Name);
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.Work.Insert]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据ID删除一条排班记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(string ID)
        {
            string sql = "";

            if (this.Sql.GetSql("Nurse.Work.Delete", ref sql) == -1) return -1;

            try
            {
                sql = string.Format(sql, ID);
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.Work.Delete]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 根据ID修改一条排班记录(已使用的)
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public int Update(Neusoft.HISFC.Models.Nurse.Work work)
        {
            string sql = "";

            if (this.Sql.GetSql("Nurse.Work.Update.ById", ref sql) == -1) return -1;
            #region SQL
//       update met_nui_work
//     SET
//       valid_flag='{0}',   --1正常/0停诊
//       noon_code='{1}',--午别
//       noon_name='{2}',--午别名称
//       begin_time='{3}',--开始时间
//       end_tiem='{4}',--结束时间
//       reason_no='{5}',   --原因
//       reason_name='{6}',   --原因名称
//       oper_code='{7}',   --操作员
//       oper_date=to_date('{8}','yyyy-mm-dd hh24:mi:ss'),    --最近改动日期
//where id='{9}'
            #endregion
            try
            {
                sql = string.Format(sql, Neusoft.FrameWork.Function.NConvert.ToInt32(work.Templet.IsValid), work.Templet.Noon.ID,
                    work.Templet.Noon.Name, work.Templet.Begin.ToString(), work.Templet.End.ToString(),
                    work.Templet.Reason.ID, work.Templet.Reason.Name, work.Templet.Oper.ID,
                    work.Templet.Oper.OperTime.ToString(), work.Templet.ID);
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.Work.Update.ById]格式不匹配!" + e.Message;
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
        public ArrayList Query(DateTime day, string DeptID)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Nurse.Work.Query", ref sql) == -1) return null;
            if (this.Sql.GetSql("Nurse.Work.Query.ByDay&Dept", ref where) == -1) return null;

            sql = sql + " " + where;

            try
            {
                sql = string.Format(sql, day, DeptID);
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.Work.Query.ByDay&Dept]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            return this.QueryBase(sql);
        }

        public ArrayList QueryHistory(int week, string DeptID)
        {
            string sql = string.Empty;
            string where = string.Empty;

            if (this.Sql.GetSql("Nurse.Work.Query", ref sql) == -1) return null;
            if (this.Sql.GetSql("Nurse.Work.Query.ByWeek&Dept", ref where) == -1) return null;
            sql = sql + " " + where;

            try
            {
                sql = string.Format(sql, week, DeptID);
            }
            catch (Exception e)
            {
                this.Err = "[Nurse.Work.Query.ByWeek&Dept]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            return this.QueryBase(sql);

        }

        #region 根据科室所属护理站 排班时间查询排班信息
        #endregion

        #region 根据护士编号 排班时间查询排班信息
        #endregion

        #region 根据科室 排班时间查询排班信息
        #endregion

        #region 获得最近有效的护士排班信息
        #endregion

        #region 根据排班序号获得排版实体
        #endregion

        /// <summary>
        /// 排班信息实体
        /// </summary>
        Neusoft.HISFC.Models.Nurse.Work objWork;
        private ArrayList al;

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public ArrayList QueryBase(string sql)
        {

            if (this.ExecQuery(sql) == -1) return null;

            this.al = new ArrayList();

            try
            {
                while (this.Reader.Read())
                {
                    this.objWork = new Neusoft.HISFC.Models.Nurse.Work();

                    this.objWork.Templet.ID = this.Reader[2].ToString();
                    this.objWork.Templet.Week = (DayOfWeek)(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString()));
                    this.objWork.WorkDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());
                    this.objWork.Templet.NurseCell.ID = this.Reader[5].ToString();
                    this.objWork.Templet.NurseCell.Name = this.Reader[6].ToString();
                    this.objWork.Templet.Dept.ID = this.Reader[7].ToString();
                    this.objWork.Templet.Dept.Name = this.Reader[8].ToString();
                    this.objWork.Templet.Employee.ID = this.Reader[9].ToString();
                    this.objWork.Templet.Employee.Name = this.Reader[10].ToString();
                    this.objWork.Templet.Noon.ID = this.Reader[11].ToString();
                    this.objWork.Templet.Noon.Name = this.Reader[12].ToString();
                    this.objWork.Templet.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[13].ToString());
                    this.objWork.Templet.Memo = this.Reader[14].ToString();
                    this.objWork.Templet.Oper.ID = this.Reader[15].ToString();
                    this.objWork.Templet.Oper.OperTime =Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[16].ToString());
                    this.objWork.Templet.EmplType.ID = this.Reader[17].ToString();
                    this.objWork.Templet.Begin = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[18].ToString());
                    this.objWork.Templet.End = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[19].ToString());
                    this.objWork.Templet.Reason.ID = this.Reader[20].ToString();
                    this.objWork.Templet.Reason.Name = this.Reader[21].ToString();

                    this.al.Add(this.objWork);
                }

                this.Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = "查询排班信息出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            return al;
        }

        #endregion
    }
}
