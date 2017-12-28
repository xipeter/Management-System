using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Nurse
{
	/// <summary>
	/// 队列信息管理类
	/// </summary>
	public class Queue : Neusoft.FrameWork.Management.Database
    {
        #region 原来的

        //public Queue()
        //{
        //    //
        //    // TODO: 在此处添加构造函数逻辑
        //    //
        //}
        //#region 声明变量
        //protected ArrayList al = null;
        //protected Neusoft.HISFC.Models.Nurse.Queue queue = null;
        //#endregion

        ///// <summary>
        ///// 获得插入参数列表
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //protected string [] myGetParmInsertQueue(Neusoft.HISFC.Models.Nurse.Queue obj)
        //{
        //    string[] strParm={	
        //                         obj.Dept.ID,//代码
        //                            obj.Name,//队列名称
        //        obj.Noon.ID,//午别
        //        obj.User01,//队列类别
        //        obj.Order.ToString(),//顺序
        //        obj.IsValid?"1":"0",//是否有效
        //        obj.Memo,//备注
        //        obj.OperID,//操作员
        //        obj.QueueDate.ToString(),
        //        obj.Doctor.ID,
        //        obj.ID,
        //        obj.Room.ID,
        //        obj.Room.Name

        //                     };

        //    return strParm;

        //} 
        ///// <summary>
        ///// 获得修改队列参数列表
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //protected string [] myGetParmUpdateQueue(Neusoft.HISFC.Models.Nurse.Queue obj)
        //{
        //    string[] strParm={	
        //                         obj.ID,
        //                         obj.Dept.ID,
        //                         obj.Name,
        //        obj.Noon.ID,
        //        obj.User01,
        //        obj.Order.ToString(),
        //        obj.IsValid?"1":"0",
        //        obj.Memo,
        //        obj.OperID,
        //        obj.QueueDate.ToString(),
        //        obj.Doctor.ID,
        //        obj.Room.ID,
        //        obj.Room.Name

        //                     };
        //    return strParm;
        //} 

        ///// <summary>
        ///// 获得处方号
        ///// </summary>
        ///// <returns></returns>
        //public string GetQueueNo()
        //{
        //    return this.GetSequence("Nurse.GetRecipeNo.Select");
        //}
        ///// <summary>
        ///// 插入队列
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>

        //public int InsertQueue(Neusoft.HISFC.Models.Nurse.Queue obj)
        //{
        //    string strSQL = "";
        //        //取插入操作的SQL语句
        //    string[] strParam ;
        //    if(this.Sql.GetSql("Nurse.Queue.InsertQueue",ref strSQL) == -1) 
        //    {
        //        this.Err = "没有找到字段!";
        //        return -1;
        //    }
        //    try
        //    {
        //        if (obj.ID == null) return -1;
        //        obj.ID = "T"+this.GetQueueNo();
        //        strParam = this.myGetParmInsertQueue(obj); 
			
        //    }
        //    catch(Exception ex)
        //    {
        //        this.Err = "格式化SQL语句时出错:" + ex.Message;
        //        this.WriteErr();
        //        return -1;
        //    }
        //    return this.ExecNoQuery(strSQL,strParam);
			
			
        //}

        ///// <summary>
        ///// 获得修改队列参数列表
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public int UpdateQueue(Neusoft.HISFC.Models.Nurse.Queue obj) 
        //{
        //    string strSql="";			
        //    string[] strParam ;
        //    if(this.Sql.GetSql("Nurse.Queue.UpdateQueue",ref strSql)==-1) return -1;
        //    try
        //    {
        //        //获取参数列表
        //        strParam = this.myGetParmUpdateQueue(obj);
        //        strSql = string.Format(strSql,strParam);
        //    }
        //    catch(Exception ex)
        //    {
        //        this.Err=ex.Message;
        //        this.ErrCode=ex.Message;
        //        return -1;
        //    }
            
        //    return this.ExecNoQuery(strSql);
        //}

        ///// <summary>
        ///// 删除队列
        ///// </summary>
        ///// <param name="queueNo"></param>
        ///// <returns></returns>
        //public int DelQueue(string queueNo)
        //{
        //    string strSql = "";
        //    if (this.Sql.GetSql("Nurse.DelQueue.1",ref strSql)==-1) return -1;
        //    try
        //    {
        //        strSql = string.Format(strSql,queueNo);
        //    }
        //    catch(Exception ex)
        //    {
        //        this.Err=ex.Message;
        //        this.ErrCode=ex.Message;
        //        return -1;
        //    }			
        //    return this.ExecNoQuery(strSql);
        //}

        ///// <summary>
        ///// 按护士站/分诊日期/午别查询分诊队列信息
        ///// </summary>
        ///// <param name="nurseID"></param>
        ///// <param name="queueDate"></param>
        ///// <param name="noonID"></param>
        ///// <returns></returns>
        //public ArrayList Query(string nurseID,DateTime queueDate,string noonID)
        //{
        //    string sql = "", where = "";

        //    if(this.Sql.GetSql("Nurse.Queue.Query.1",ref sql) == -1)
        //    {
        //        this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]";
        //        return null;
        //    }
			
        //    if(this.Sql.GetSql("Nurse.Queue.Query.2",ref where) == -1)
        //    {
        //        this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.2]";
        //        return null;
        //    }

        //    try
        //    {
        //        where = string.Format(where,nurseID,queueDate.ToString(),noonID);
        //    }
        //    catch(Exception e)
        //    {
        //        this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]" + e.Message;
        //        this.ErrCode = e.Message;
        //        return null;
        //    }

        //    sql = sql + " " + where ;

        //    return this.Query(sql);
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="nurseID"></param>
        ///// <param name="queueDate"></param>
        ///// <returns></returns>
        //public ArrayList Query(string nurseID,string queueDate)
        //{
        //    string sql = "", where = "";
        //    string strBegin = queueDate+" "+"00:00:00",strEnd = queueDate+" "+"23:59:59"; 

        //    if(this.Sql.GetSql("Nurse.Queue.Query.1",ref sql) == -1)
        //    {
        //        this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]";
        //        return null;
        //    }
			
        //    if(this.Sql.GetSql("Nurse.Queue.Query.3",ref where) == -1)
        //    {
        //        this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.3]";
        //        return null;
        //    }
        //    try
        //    {
        //        where = string.Format(where,nurseID,strBegin,strEnd);
        //    }
        //    catch(Exception e)
        //    {
        //        this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]" + e.Message;
        //        this.ErrCode = e.Message;
        //        return null;
        //    }

        //    sql = sql + " " + where ;

        //    return this.Query(sql);
        //}
        ///// <summary>
        ///// 根据sql查询队列信息
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //protected ArrayList Query(string sql)
        //{
        //    if(this.ExecQuery(sql) == -1)
        //    {
        //        this.Err = "基本sql出错!"+sql;
        //        this.ErrCode = "基本sql出错!"+sql;
        //        return null;
        //    }

        //    this.al = new ArrayList();

        //    try
        //    {
        //        while(this.Reader.Read())
        //        {
        //            this.queue = new Neusoft.HISFC.Models.Nurse.Queue();

        //            //所属护士站
        //            this.queue.Dept.ID = this.Reader[0].ToString();
        //            //队列代码
        //            this.queue.ID = this.Reader[1].ToString();
        //            //队列名称
        //            this.queue.Name = this.Reader[2].ToString();
        //            //午别代码
        //            this.queue.Noon.ID = this.Reader[3].ToString();
        //            //显示顺序
        //            if(!this.Reader.IsDBNull(5))
        //                this.queue.Order = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5].ToString());
        //            //是否有效
        //            this.queue.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
        //            //备注
        //            this.queue.Memo = this.Reader[7].ToString();
        //            //操作员
        //            this.queue.OperID = this.Reader[8].ToString();
        //            //操作时间
        //            this.queue.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());
        //            //队列日期
        //            this.queue.QueueDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
        //            //看诊医生
        //            this.queue.Doctor.ID = this.Reader[11].ToString();
        //            this.queue.Room.ID = this.Reader[12].ToString();
        //            this.queue.Room.Name = this.Reader[13].ToString();

        //            this.al.Add(this.queue);
        //        }
				
        //        this.Reader.Close();
        //    }
        //    catch(Exception e)
        //    {
        //        if(!this.Reader.IsClosed)this.Reader.Close();
        //        this.Err = "查询门诊护士站分诊队列信息出错!"+e.Message;
        //        this.ErrCode = e.Message;
        //        return null;
        //    }

        //    return this.al;
        //}

        #endregion

        public Queue()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 声明变量
        protected ArrayList al = null;
        protected Neusoft.HISFC.Models.Nurse.Queue queue = null;
        #endregion

        /// <summary>
        /// 获得插入参数列表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string[] myGetParmInsertQueue(Neusoft.HISFC.Models.Nurse.Queue obj)
        {
            string[] strParm ={	
								    obj.Dept.ID,//代码1
									obj.Name,//队列名称2
									obj.Noon.ID,//午别3
									obj.User01,//队列类别4
									obj.Order.ToString(),//顺序5
									obj.IsValid?"1":"0",//是否有效6
									obj.Memo,//备注7
									obj.Oper.ID,//操作员8
									obj.QueueDate.ToString(),//队列时间9
									obj.Doctor.ID,//医生代码10
									obj.ID,//队列号11
									obj.SRoom.ID,//诊室代码12
									obj.SRoom.Name,//诊室名称13
									obj.Console.ID,//诊台代码14
									obj.Console.Name,//诊台名称15
									obj.ExpertFlag,//专家16
								    obj.AssignDept.ID,
									obj.AssignDept.Name
							 };

            return strParm;

        }
        /// <summary>
        /// 获得修改队列参数列表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string[] myGetParmUpdateQueue(Neusoft.HISFC.Models.Nurse.Queue obj)
        {
            string[] strParm ={	
								obj.ID,//队列号
								obj.Dept.ID,//科室代码
								obj.Name,//队列名称
								obj.Noon.ID,//午别
								obj.User01,//队列类别
								obj.Order.ToString(),//顺序
								obj.IsValid?"1":"0",//是否有效
								obj.Memo,//备注
								obj.Oper.ID,//操作员
								obj.QueueDate.ToString(),//操作时间
								obj.Doctor.ID,//医生代码
								obj.SRoom.ID,//诊室代码
								obj.SRoom.Name,//诊室名称
								obj.Console.ID,//诊台
								obj.Console.Name,//诊台名称
								 obj.ExpertFlag,//专家16
								 obj.AssignDept.ID,
								 obj.AssignDept.Name
							 };
            return strParm;
        }

        /// <summary>
        /// 获得处方号
        /// </summary>
        /// <returns></returns>
        public string GetQueueNo()
        {
            return this.GetSequence("Nurse.GetRecipeNo.Select");
        }
        /// <summary>
        /// 插入队列
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        public int InsertQueue(Neusoft.HISFC.Models.Nurse.Queue obj)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            string[] strParam;
            if (this.Sql.GetSql("Nurse.Queue.InsertQueue", ref strSQL) == -1)
            {
                this.Err = "没有找到字段!";
                return -1;
            }
            try
            {
                if (obj.ID == null) return -1;
                obj.ID = "T" + this.GetQueueNo();
                strParam = this.myGetParmInsertQueue(obj);

            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL, strParam);


        }

        /// <summary>
        /// 获得修改队列参数列表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateQueue(Neusoft.HISFC.Models.Nurse.Queue obj)
        {
            string strSql = "";
            string[] strParam;
            if (this.Sql.GetSql("Nurse.Queue.UpdateQueue", ref strSql) == -1) return -1;
            try
            {
                //获取参数列表
                strParam = this.myGetParmUpdateQueue(obj);
                strSql = string.Format(strSql, strParam);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 删除队列
        /// </summary>
        /// <param name="queueNo"></param>
        /// <returns></returns>
        public int DelQueue(string queueNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Nurse.DelQueue.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, queueNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 按护士站/分诊日期/午别查询分诊队列信息
        /// </summary>
        /// <param name="nurseID"></param>
        /// <param name="queueDate"></param>
        /// <param name="noonID"></param>
        /// <returns></returns>
        public ArrayList Query(string nurseID, DateTime queueDate, string noonID)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Nurse.Queue.Query.1", ref sql) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]";
                return null;
            }

            if (this.Sql.GetSql("Nurse.Queue.Query.2", ref where) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.2]";
                return null;
            }

            try
            {
                where = string.Format(where, nurseID, queueDate.ToString(), noonID);
            }
            catch (Exception e)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.Query(sql);
        }
        /// <summary>
        /// 按护士站/分诊日期/午别/科室 查询分诊队列信息
        /// </summary>
        /// <param name="nurseID"></param>
        /// <param name="queueDate"></param>
        /// <param name="noonID"></param>
        /// <returns></returns>
        public ArrayList Query(string nurseID, DateTime queueDate, string noonID, string deptCode)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Nurse.Queue.Query.1", ref sql) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]";
                return null;
            }

            if (this.Sql.GetSql("Nurse.Queue.Query.5", ref where) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.5]";
                return null;
            }

            try
            {
                where = string.Format(where, nurseID, queueDate.ToString(), noonID, deptCode);
            }
            catch (Exception e)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1+5]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.Query(sql);
        }
        /// <summary>
        /// 根据序列号去序列信息
        /// </summary>
        /// <param name="queueID">序列号</param> 
        /// <returns></returns>
        public ArrayList QueryByQueueID(string queueID)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Nurse.Queue.Query.1", ref sql) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]";
                return null;
            }

            if (this.Sql.GetSql("Nurse.Queue.Query.7", ref where) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.7]";
                return null;
            }

            try
            {
                where = string.Format(where, queueID);
            }
            catch (Exception e)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1+7]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.Query(sql);
        }

        /// <summary>
        /// 查询met_nuo_assignrecord中是否有符合条件的诊室是否在用
        /// </summary>
        /// <param name="roomID">诊室代码</param>
        /// <returns></returns>
        public int QueryQueueByQueueID(string roomID, string currentDateStr)
        {
            string strsql = string.Empty;
            if (this.Sql.GetSql("Nurse.Room.GetQueueByQueueID", ref strsql) == -1)
            {
                this.Err = "得到Nurse.Room.GetQueueByQueueID失败";
                return -1;
            }

            try
            {
                strsql = string.Format(strsql, roomID, currentDateStr);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strsql));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nurseID"></param>
        /// <param name="queueDate"></param>
        /// <returns></returns>
        public ArrayList Query(string nurseID, string queueDate)
        {
            string sql = "", where = "";
            string strBegin = queueDate + " " + "00:00:00", strEnd = queueDate + " " + "23:59:59";

            if (this.Sql.GetSql("Nurse.Queue.Query.1", ref sql) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]";
                return null;
            }

            if (this.Sql.GetSql("Nurse.Queue.Query.3", ref where) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.3]";
                return null;
            }
            try
            {
                where = string.Format(where, nurseID, strBegin, strEnd);
            }
            catch (Exception e)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.Query(sql);
        }
        /// <summary>
        /// 根据sql查询队列信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected ArrayList Query(string sql)
        {
            if (this.ExecQuery(sql) == -1)
            {
                this.Err = "基本sql出错!" + sql;
                this.ErrCode = "基本sql出错!" + sql;
                return null;
            }

            this.al = new ArrayList();

            try
            {
                while (this.Reader.Read())
                {
                    this.queue = new Neusoft.HISFC.Models.Nurse.Queue();

                    //所属护士站
                    this.queue.Dept.ID = this.Reader[0].ToString();
                    //队列代码
                    this.queue.ID = this.Reader[1].ToString();
                    //队列名称
                    this.queue.Name = this.Reader[2].ToString();
                    //午别代码
                    this.queue.Noon.ID = this.Reader[3].ToString();

                    //队列类型[2007/03/27]
                    this.queue.User01 = this.Reader[4].ToString();

                    //显示顺序
                    if (!this.Reader.IsDBNull(5))
                        this.queue.Order = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5].ToString());
                    //是否有效
                    this.queue.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
                    //备注
                    this.queue.Memo = this.Reader[7].ToString();
                    //操作员
                    this.queue.Oper.ID = this.Reader[8].ToString();
                    //操作时间
                    this.queue.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());
                    //队列日期
                    this.queue.QueueDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    //看诊医生
                    this.queue.Doctor.ID = this.Reader[11].ToString();
                    //诊室
                    this.queue.SRoom.ID = this.Reader[12].ToString();
                    this.queue.SRoom.Name = this.Reader[13].ToString();
                    //诊台
                    this.queue.Console.ID = this.Reader[14].ToString();
                    this.queue.Console.Name = this.Reader[15].ToString();
                    //专家标志
                    this.queue.ExpertFlag = this.Reader[16].ToString();
                    //分诊科室
                    this.queue.AssignDept.ID = this.Reader[17].ToString();
                    this.queue.AssignDept.Name = this.Reader[18].ToString();
                    this.queue.WaitingCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[19]);
                    this.al.Add(this.queue);
                }

                this.Reader.Close();
            }
            catch (Exception e)
            {
                if (!this.Reader.IsClosed) this.Reader.Close();
                this.Err = "查询门诊护士站分诊队列信息出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            return this.al;
        }

        /// <summary>
        ///  根据护理站，时间 获取一个最少待诊人数的队列实体
        /// </summary>
        /// <param name="nurseID"></param>
        /// <param name="queueDate"></param>
        /// <param name="noonID"></param>
        /// <returns></returns>
        public ArrayList QueryMinCount(string nurseID, DateTime queueDate, string noonID)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Nurse.Queue.Query.1", ref sql) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1]";
                return null;
            }

            if (this.Sql.GetSql("Nurse.Queue.Query.4", ref where) == -1)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.4]";
                return null;
            }

            try
            {
                where = string.Format(where, nurseID, queueDate.ToString(), noonID);
            }
            catch (Exception e)
            {
                this.Err = "查询分诊队列信息出错![Nurse.Queue.Query.1+4]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;
            ArrayList al = new ArrayList();
            al = this.Query(sql);

            if (al == null || al.Count <= 0) return null;
            return al;
            //			Neusoft.HISFC.Models.Nurse.Queue info = (Neusoft.HISFC.Models.Nurse.Queue)al[0];
            //			return info;
        }


        /// <summary>
        /// 查询分诊表中队列诊台的 分诊,进诊信息
        /// </summary>
        /// <returns></returns>
        public ArrayList Query(string nurse, Neusoft.HISFC.Models.Nurse.EnuTriageStatus status,
            DateTime dtfrom, DateTime dtto, string noon)
        {
            string sql = "";

            if (this.Sql.GetSql("Nurse.Assign.Auto.Query.3", ref sql) == -1)
            {
                this.Err = "查询sql出错,索引为[Nurse.Assign.Auto.Query.3]";
                this.ErrCode = "查询sql出错,索引为[Nurse.Assign.Auto.Query.3]";
                return null;
            }
            try
            {
                sql = string.Format(sql, nurse, status, dtfrom.ToString(), dtto.ToString(), noon);
            }
            catch (Exception e)
            {
                this.Err = "字符转换出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            if (this.ExecQuery(sql) == -1)
            {
                this.Err = "基本sql出错!" + sql;
                this.ErrCode = "基本sql出错!" + sql;
                return null;
            }
            this.al = new ArrayList();

            try
            {
                while (this.Reader.Read())
                {
                    this.queue = new Neusoft.HISFC.Models.Nurse.Queue();
                    this.queue.ID = this.Reader[0].ToString();
                    this.queue.Console.ID = this.Reader[1].ToString();
                    this.queue.WaitingCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[2]);
                    this.al.Add(this.queue);
                }

                this.Reader.Close();
            }
            catch (Exception e)
            {
                if (!this.Reader.IsClosed) this.Reader.Close();
                this.Err = "查询队列信息出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            return this.al;
        }
        /// <summary>
        /// 根据诊室诊台午别日期队列日期查询诊台是否已用
        /// </summary>
        ///  
        /// <param name="consoleCode">诊台</param>
        /// <param name="noonID">午别</param>
        /// <param name="queueDate">队列时间</param>
        /// <returns>false：取sql出错或该诊台已被使用 true ：没有被使用</returns>
        public bool QueryUsed(string consoleCode,string noonID,string queueDate)
        {
            string sqlStr = string.Empty;
            int returnValue = this.Sql.GetSql("Nurse.Room.GetQueueByConsolecodeNoonIdQDate", ref sqlStr);
            if (returnValue < 0)
            {
                this.Err = "查询sql出错,索引为[Nurse.Room.GetQueueByConsolecodeNoonIdQDate]";
                this.ErrCode = "查询sql出错,索引为[Nurse.Room.GetQueueByConsolecodeNoonIdQDate]";
                return false;
            }
            try
            {
                sqlStr = string.Format(sqlStr,consoleCode, noonID, queueDate);
            }
            catch (Exception e)
            {
                
                this.Err = "字符转换出错!" + e.Message;
                this.ErrCode = e.Message;
            }
            int myReturn = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sqlStr));
            if (myReturn > 0)
            {
                
                this.Err = "该诊台已经被使用，请选择其他诊台";

                return false;
            }
            else if (myReturn < 0)
            {
                this.Err = "查询失败";
                return false;
            }
            return true;

        }

        /// <summary>
        /// 判断是否有患者
        /// </summary>
        /// <param name="roomID">诊室编号</param>
        /// <param name="seatID">诊台编号</param>
        /// <param name="queueID">队列编号</param>
        /// <param name="noonID">午别编号</param>
        /// <returns>true,有患者</returns>
        public bool ExistPatient(string roomID, string seatID, string queueID, string noonID)
        {
            string strsql = "";
            if (this.Sql.GetSql("Nurse.Queue.Query.6", ref strsql) == -1)
            {
                return true;
            }

            try
            {
                strsql = string.Format(strsql, roomID, seatID, queueID, noonID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return true;
            }
            try
            {
                this.ExecSqlReturnOne(strsql);
            }
            catch (Exception ex)
            {

                string aaaa = ex.Message;
            }
                    
               
            string retv = this.ExecSqlReturnOne(strsql);

            if (retv == null || retv.Trim().Equals("0"))
            {
                return false;
            }

            return true;
        }
    }
}
