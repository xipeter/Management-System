using System;
using Neusoft.HISFC.Models;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Nurse
{
	/// <summary>
	/// 分诊台对应科室管理类
	/// </summary>
	public class Dept:Neusoft.FrameWork.Management.Database
	{
        #region 原来的

    //    public Dept()
    //    {
    //        //
    //        // TODO: 在此处添加构造函数逻辑
    //        //
    //    }
		
    //    #region 门诊护士站对应查看诊室列表

    //    public string GetSqlDept() 
    //    {
    //        string strSql = "";
    //        if (this.Sql.GetSql("Nurse.Dept.GetDeptInfo.Select",ref strSql)==-1) return null;
    //        return strSql;
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="NurseNo"></param>
    //    /// <returns></returns>
    //    public ArrayList GetDeptInfoByNurseNo(string NurseNo)
    //    {
    //        string strSql1="";
    //        string strSql2="";
    //        //获得项目明细的SQL语句
    //        strSql1=this.GetSqlDept();
    //        if(this.Sql.GetSql("Nurse.Dept.GetDeptInfo.Where1",ref strSql2)==-1)return null;
    //        strSql1=strSql1+" "+strSql2;
    //        try
    //        {
    //            strSql1=string.Format(strSql1,NurseNo);
    //        }
    //        catch(Exception ex)
    //        {
    //            this.ErrCode = ex.Message;
    //            this.Err = ex.Message;
    //            return null;
    //        }			
    //        return this.GetDeptInfo(strSql1);
    //    }


    //    /// <summary>
    //    /// 根据科室代码获得科室对应的病区代码
    //    /// </summary>
    //    /// <param name="deptID"></param>
    //    /// <returns></returns>
    //    public string GetNurseByDeptID(string deptID)
    //    {
    //        string sql = "";

    //        if(this.Sql.GetSql("Nurse.Dept.GetDeptInfo.Where2",ref sql)==-1)return null;
			
    //        try
    //        {
    //            sql = string.Format(sql,deptID);
    //        }
    //        catch(Exception ex)
    //        {
    //            this.ErrCode = ex.Message;
    //            this.Err = ex.Message;
    //            return null;
    //        }			
			
    //        return this.ExecSqlReturnOne(sql,"-1");
			
    //    }
    //    /// <summary>
    //    /// ID:门诊护士站代码,Name:挂号科室,user01:显示顺序,02:操作员,03:时间
    //    /// </summary>
    //    /// <param name="strSql"></param>
    //    /// <returns></returns>
    //    private ArrayList GetDeptInfo(string strSql)
    //    {
    //        ArrayList al = new ArrayList();
    //        Neusoft.FrameWork.Models.NeuObject obj;
    //        this.ExecQuery(strSql);
    //        while (this.Reader.Read()) 
    //        {
    //            #region
    ////				  NURSE_CELL_CODE,--		0 VARCHAR2(4)	N			门诊护士站代码
    ////             DEPT_CODE					1 VARCHAR2(4)	N			挂号科室
    ////             SORT_ID						2 NUMBER(4)	Y			显示顺序
    ////             OPER_CODE					3 VARCHAR2(6)	Y			操作员
    ////             OPER_DATE					4 DATE	Y			操作时间 
    //            #endregion
    //            obj = new Neusoft.FrameWork.Models.NeuObject();
    //            try 
    //            {
    //                obj.ID = this.Reader[0].ToString();//门诊护士站代码,	--		发票号
	
    //                obj.Name = this.Reader[1].ToString();//挂号科室

    //                obj.User01 = this.Reader[2].ToString();//显示顺序

    //                obj.User02 = this.Reader[3].ToString();//操作员
			
    //                obj.User03 = this.Reader[4].ToString();//操作时间				
					
    //            }

    //            catch(Exception ex) 
    //            {
    //                this.Err= "查询明细赋值错误"+ex.Message;
    //                this.ErrCode=ex.Message;
    //                this.WriteErr();
    //                return null;
    //            }
				
    //            al.Add(obj);
    //        }
    //        this.Reader.Close();
    //        return al;
    //    }


    //    protected string [] myGetParmDeptInfo(Neusoft.FrameWork.Models.NeuObject obj)
    //    {
    //        string[] strParm={	
    //                             obj.ID,
    //            obj.Name,
    //            obj.User01,
    //            obj.User02,
    //            obj.User03
												
    //                         };

    //        return strParm;

    //    }

    //    #endregion


		
    //    #region 护士站对应查看诊室操作

    //    public int InsertDeptInfo(Neusoft.FrameWork.Models.NeuObject obj)
    //    {
    //        string strSQL = "";
    //        //取插入操作的SQL语句
    //        string[] strParam ;
    //        if(this.Sql.GetSql("Nurse.Room.GetDeptInfo.Insert",ref strSQL) == -1) 
    //        {
    //            this.Err = "没有找到字段!";
    //            return -1;
    //        }
    //        try
    //        {
    //            if (obj.ID == null) return -1;
    //            strParam = this.myGetParmDeptInfo(obj); 
				
    //        }
    //        catch(Exception ex)
    //        {
    //            this.Err = "格式化SQL语句时出错:" + ex.Message;
    //            this.WriteErr();
    //            return -1;
    //        }
    //        return this.ExecNoQuery(strSQL,strParam);
			
    //    }

    //    /// <summary>
    //    /// 删除诊室信息
    //    /// </summary>
    //    /// <param name="nurseNo"></param>
    //    /// <returns></returns>
    //    public int DelDeptInfo(string nurseNo)
    //    {
    //        string strSql = "";
    //        if (this.Sql.GetSql("Nurse.DelDeptInfo.1",ref strSql)==-1) return -1;
    //        try
    //        {
    //            strSql = string.Format(strSql,nurseNo);
    //        }
    //        catch(Exception ex)
    //        {
    //            this.Err=ex.Message;
    //            this.ErrCode=ex.Message;
    //            return -1;
    //        }
    //        return this.ExecNoQuery(strSql);
    //    }


    //    #endregion

        #endregion

        public Dept()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 门诊护士站对应查看诊室列表

        public string GetSqlDept()
        {
            string strSql = "";
            if (this.Sql.GetSql("Nurse.Dept.GetDeptInfo.Select", ref strSql) == -1) return null;
            return strSql;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NurseNo"></param>
        /// <returns></returns>
        public ArrayList GetDeptInfoByNurseNo(string NurseNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            //获得项目明细的SQL语句
            strSql1 = this.GetSqlDept();
            if (this.Sql.GetSql("Nurse.Dept.GetDeptInfo.Where1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + " " + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, NurseNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.GetDeptInfo(strSql1);
        }


        /// <summary>
        /// 根据科室代码获得科室对应的病区代码
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public string GetNurseByDeptID(string deptID)
        {
            string sql = "";

            if (this.Sql.GetSql("Nurse.Dept.GetDeptInfo.Where2", ref sql) == -1) return null;

            try
            {
                sql = string.Format(sql, deptID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            return this.ExecSqlReturnOne(sql, "-1");

        }
        /// <summary>
        /// ID:门诊护士站代码,Name:挂号科室,user01:显示顺序,02:操作员,03:时间
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList GetDeptInfo(string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj;
            this.ExecQuery(strSql);
            while (this.Reader.Read())
            {
                #region
                //				  NURSE_CELL_CODE,--		0 VARCHAR2(4)	N			门诊护士站代码
                //             DEPT_CODE					1 VARCHAR2(4)	N			挂号科室
                //             SORT_ID						2 NUMBER(4)	Y			显示顺序
                //             OPER_CODE					3 VARCHAR2(6)	Y			操作员
                //             OPER_DATE					4 DATE	Y			操作时间 
                #endregion
                obj = new Neusoft.FrameWork.Models.NeuObject();
                try
                {
                    obj.ID = this.Reader[0].ToString();//门诊护士站代码,	--		发票号

                    obj.Name = this.Reader[1].ToString();//挂号科室

                    obj.User01 = this.Reader[2].ToString();//显示顺序

                    obj.User02 = this.Reader[3].ToString();//操作员

                    obj.User03 = this.Reader[4].ToString();//操作时间				

                }

                catch (Exception ex)
                {
                    this.Err = "查询明细赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }

                al.Add(obj);
            }
            this.Reader.Close();
            return al;
        }


        protected string[] myGetParmDeptInfo(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string[] strParm ={	
								 obj.ID,
				obj.Name,
				obj.User01,
				obj.User02,
				obj.User03
												
							 };

            return strParm;

        }

        #endregion



        #region 护士站对应查看诊室操作

        public int InsertDeptInfo(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            string[] strParam;
            if (this.Sql.GetSql("Nurse.Room.GetDeptInfo.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到字段!";
                return -1;
            }
            try
            {
                if (obj.ID == null) return -1;
                strParam = this.myGetParmDeptInfo(obj);

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
        /// 删除诊室信息
        /// </summary>
        /// <param name="nurseNo"></param>
        /// <returns></returns>
        public int DelDeptInfo(string nurseNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Nurse.DelDeptInfo.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, nurseNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }


        #endregion



    }
}
