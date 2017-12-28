using System;
using Neusoft.HISFC.Models;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Nurse
{
	/// <summary>
	/// 诊室管理类
	/// </summary>
	public class Room:Neusoft.FrameWork.Management.Database
    {
        #region 原来的

//        public Room()
//        {
//            //
//            // TODO: 在此处添加构造函数逻辑
//            //
//        }

//        #region 门诊科室诊室信息

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public string GetSqlRoomInfo() 
//        {
//            string strSql = "";
//            if (this.Sql.GetSql("Nurse.Room.GetRoomInfo.Select",ref strSql)==-1) return null;
//            return strSql;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="NurseNo"></param>
//        /// <returns></returns>
//        public ArrayList GetRoomInfoByNurseNo(string NurseNo)
//        {
//            string strSql1="";
//            string strSql2="";
//            //获得项目明细的SQL语句
//            strSql1=this.GetSqlRoomInfo();
//            if(this.Sql.GetSql("Nurse.Room.GetRoomInfo.Where1",ref strSql2)==-1)return null;
//            strSql1=strSql1+" "+strSql2;
//            try
//            {
//                strSql1=string.Format(strSql1,NurseNo);
//            }
//            catch(Exception ex)
//            {
//                this.ErrCode = ex.Message;
//                this.Err = ex.Message;
//                return null;
//            }			
//            return this.GetRoomInfo(strSql1);
//        }


//        /// <summary>
//        /// 根据科室获取诊室列表
//        /// </summary>
//        /// <param name="deptID"></param>
//        /// <returns></returns>
//        public ArrayList GetRoomsByDeptID(string deptID)
//        {
//            string strSql1="";
//            string strSql2="";
//            //获得项目明细的SQL语句
//            strSql1=this.GetSqlRoomInfo();
//            if(this.Sql.GetSql("Nurse.Room.GetRoomInfo.Where2",ref strSql2)==-1)return null;
//            strSql1=strSql1+" "+strSql2;
//            try
//            {
//                strSql1=string.Format(strSql1,deptID);
//            }
//            catch(Exception ex)
//            {
//                this.ErrCode = ex.Message;
//                this.Err = ex.Message;
//                return null;
//            }			
//            return this.GetRoomInfo(strSql1);
//        }

//        private ArrayList GetRoomInfo(string strSql)
//        {
//            ArrayList al = new ArrayList();
//            Neusoft.HISFC.Models.Nurse.Room objRoom ;
//            this.ExecQuery(strSql);
//            while (this.Reader.Read()) 
//            {
//                #region
////								DEPT_CODE	--VARCHAR2(4)	N			分诊科室
////					ROOM_ID	--VARCHAR2(4)	N			诊室代码
////					ROOM_NAME	--VARCHAR2(20)	Y			诊室名称
////					INPUT_CODE	--VARCHAR2(8)	Y			助记码
////					VALID_FLAG	--VARCHAR2(1)	Y			1有效/0无效
////					SORT_ID	--NUMBER(4)	Y			显示顺序
////					OPER_CODE	--VARCHAR2(6)	Y			操作员
////					OPER_DATE	--DATE	Y			操作时间
//                #endregion
//                objRoom = new Neusoft.HISFC.Models.Nurse.Room();
//                try 
//                {
//                    objRoom.Nurse.ID = this.Reader[0].ToString();//RECIPE_NO,	--		发票号
	
//                    objRoom.ID = this.Reader[1].ToString();//诊室代码

//                    objRoom.Name = this.Reader[2].ToString();//诊室名称

//                    objRoom.InputCode = this.Reader[3].ToString();//助记码
			
//                    objRoom.IsValid = this.Reader[4].ToString();//是否有效

//                    objRoom.Sort = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5].ToString());//序号

//                    objRoom.User01 = this.Reader[6].ToString();//操作员

//                    objRoom.User02 = this.Reader[7].ToString();//操作时间
					
//                }

//                catch(Exception ex) 
//                {
//                    this.Err= "查询处方明细赋值错误"+ex.Message;
//                    this.ErrCode=ex.Message;
//                    this.WriteErr();
//                    return null;
//                }
				
//                al.Add(objRoom);
//            }
//            this.Reader.Close();
//            return al;
//        }


//        protected string [] myGetParmRoomInfo(Neusoft.HISFC.Models.Nurse.Room obj)
//        {
//            string[] strParm={	
//                                 obj.Nurse.ID,
//                                    obj.ID,
//                obj.Name,
//                obj.InputCode,
//                obj.IsValid,
//                obj.Sort.ToString(),
//                obj.User01,
//                obj.User02
												
//                             };

//            return strParm;

//        }

//        #endregion


//        #region 插入

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="obj"></param>
//        /// <returns></returns>
//        public int InsertRoomInfo(Neusoft.HISFC.Models.Nurse.Room obj)
//        {
//                string strSQL = "";
//                //取插入操作的SQL语句
//                string[] strParam ;
//                if(this.Sql.GetSql("Nurse.Room.GetRoomInfo.Insert",ref strSQL) == -1) 
//                {
//                    this.Err = "没有找到字段!";
//                    return -1;
//                }
//                try
//                {
//                    if (obj.ID == null) return -1;
//                    strParam = this.myGetParmRoomInfo(obj); 
				
//                }
//                catch(Exception ex)
//                {
//                    this.Err = "格式化SQL语句时出错:" + ex.Message;
//                    this.WriteErr();
//                    return -1;
//                }
//                return this.ExecNoQuery(strSQL,strParam);
			
//        }

//        /// <summary>
//        /// 删除诊室信息
//        /// </summary>
//        /// <param name="nurseNo"></param>
//        /// <returns></returns>
//        public int DelRoomInfo(string nurseNo)
//        {
//            string strSql = "";
//            if (this.Sql.GetSql("Nurse.DelRoomInfo.1",ref strSql)==-1) return -1;
//            try
//            {
//                strSql = string.Format(strSql,nurseNo);
//            }
//            catch(Exception ex)
//            {
//                this.Err=ex.Message;
//                this.ErrCode=ex.Message;
//                return -1;
//            }
//            return this.ExecNoQuery(strSql);
//        }

//        #endregion
        #endregion

        public Room()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region 方法

        /// <summary>
        /// 根据护理站代码获取诊室列表
        /// </summary>
        /// <param name="NurseNo"></param>
        /// <returns></returns>
        public ArrayList GetRoomInfoByNurseNo(string NurseNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            //获得项目明细的SQL语句
            strSql1 = this.GetSqlRoomInfo();
            if (this.Sql.GetSql("Nurse.Room.GetRoomInfo.Where1", ref strSql2) == -1) return null;
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
            return this.GetRoomInfo(strSql1);

        }
        /// <summary>
        /// 根据护理站代码获取有效诊室列表
        /// </summary>
        /// <param name="NurseNo"></param>
        /// <returns></returns>
        public ArrayList GetRoomInfoByNurseNoValid(string NurseNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            //获得项目明细的SQL语句
            strSql1 = this.GetSqlRoomInfo();
            if (this.Sql.GetSql("Nurse.Room.GetRoomInfo.Where3", ref strSql2) == -1) return null;
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
            return this.GetRoomInfo(strSql1);
        }
        /// <summary>
        /// 根据科室获取诊室列表
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList GetRoomsByDeptID(string deptID)
        {
            string strSql1 = "";
            string strSql2 = "";
            //获得项目明细的SQL语句
            strSql1 = this.GetSqlRoomInfo();
            if (this.Sql.GetSql("Nurse.Room.GetRoomInfo.Where1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + " " + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, deptID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.GetRoomInfo(strSql1);
        }
        /// <summary>
        /// 插入一条
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertRoomInfo(Neusoft.HISFC.Models.Nurse.Room obj)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            string[] strParam;
            if (this.Sql.GetSql("Nurse.Room.GetRoomInfo.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到字段!";
                return -1;
            }
            try
            {
                if (obj.ID == null) return -1;
                strParam = this.myGetParmRoomInfo(obj);

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
        /// 更新登记信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Neusoft.HISFC.Models.Nurse.Room info)
        {
            string sql = "";
            string[] strParam;
            if (this.Sql.GetSql("Nurse.Room.Update.1", ref sql) == -1) return -1;

            try
            {
                if (info.ID == null) return -1;
                strParam = this.myGetParmRoomInfo(info);

            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(sql, strParam);
        }

        /// <summary>
        /// 删除诊室信息(根据诊室代码)
        /// </summary>
        /// <param name="nurseNo"></param>
        /// <returns></returns>
        public int DelRoomInfo(string RoomNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Nurse.DelRoomInfo.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, RoomNo);
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
        /// 更新诊室下的诊台状态
        /// </summary>
        /// <param name="roomID">诊室编号</param>
        /// <param name="isVlid">是否有效(1，有效； 0，无效)</param>
        /// <returns>-1,失败；</returns>
        public int UpdateSeatByRoom(string roomID, string isvalid)
        {
            string strsql = "";
            if (this.Sql.GetSql("UpdateSeatStateByRoomID", ref strsql) == -1)
            {
                this.Err = "得到UpdateSeatStateByRoomID失败";
                return -1;
            }
            try
            {
                strsql = string.Format(strsql, isvalid, roomID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strsql);
        }
        /// <summary>
        /// 查询要删除的诊室是否被队列维护
        /// </summary>
        /// <param name="roomID">诊室</param>
        /// <param name="strDate">系统时间</param>
        /// <returns></returns>
        public int QueryRoom(string roomID,string strDate)
        {
            string strsql = "";
            if (this.Sql.GetSql("Nurse.Room.GetRoomUsed", ref strsql) == -1)
            {
                this.Err = "得到Nurse.Room.GetRoomUsed失败";
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,roomID,strDate);

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return  Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strsql));
        }

        /// <summary>
        ///根据科室，诊室名称判断诊室是否存在
        /// </summary>
        /// <param name="deptID">科室代码</param>
        /// <param name="roomName">诊室名称</param>
        /// <returns></returns>
        public int QueryRoomByNameAndDept(string roomID, string deptID,string roomName)
        {
            string strsql = string.Empty;
            if (this.Sql.GetSql("Nurse.Room.GetRoomByNameAndDept", ref strsql) == -1)
            {
                this.Err = "得到Nurse.Room.GetRoomByNameAndDept失败";
                return -1;
            }

            try
            {
                strsql = string.Format(strsql,roomID,deptID,roomName);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strsql));
 
        }
        /// <summary>
        /// 查询met_nuo_assignrecord中是否有符合条件的诊室是否在用
        /// </summary>
        /// <param name="roomID">诊室代码</param>
        /// <returns></returns>
        public int QueryRoomByRoomID(string roomID,string currentDT)
        {
            string strsql = string.Empty;
            if (this.Sql.GetSql("Nurse.Room.GetRoomByRoomID", ref strsql) == -1)
            {
                this.Err = "得到Nurse.Room.GetRoomByRoomID失败";
                return -1;
            }

            try
            {
                strsql = string.Format(strsql, roomID,currentDT);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strsql));
        }
        

           
        
        #endregion

        #region 公用

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetSqlRoomInfo()
        {
            string strSql = "";
            if (this.Sql.GetSql("Nurse.Room.GetRoomInfo.Select", ref strSql) == -1) return null;
            return strSql;
        }
        /// <summary>
        /// 转化为实体
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList GetRoomInfo(string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Nurse.Room objRoom;
            this.ExecQuery(strSql);
            while (this.Reader.Read())
            {
                #region
                //								DEPT_CODE	--VARCHAR2(4)	N			分诊科室
                //					ROOM_ID	--VARCHAR2(4)	N			诊室代码
                //					ROOM_NAME	--VARCHAR2(20)	Y			诊室名称
                //					INPUT_CODE	--VARCHAR2(8)	Y			助记码
                //					VALID_FLAG	--VARCHAR2(1)	Y			1有效/0无效
                //					SORT_ID	--NUMBER(4)	Y			显示顺序
                //					OPER_CODE	--VARCHAR2(6)	Y			操作员
                //					OPER_DATE	--DATE	Y			操作时间
                #endregion
                objRoom = new Neusoft.HISFC.Models.Nurse.Room();
                try
                {
                    objRoom.Nurse.ID = this.Reader[0].ToString();//RECIPE_NO,	--		发票号

                    objRoom.ID = this.Reader[1].ToString();//诊室代码

                    objRoom.Name = this.Reader[2].ToString();//诊室名称

                    objRoom.InputCode = this.Reader[3].ToString();//助记码

                    objRoom.IsValid = this.Reader[4].ToString();//是否有效

                    objRoom.Sort = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5].ToString());//序号

                    objRoom.User01 = this.Reader[6].ToString();//操作员

                    objRoom.User02 = this.Reader[7].ToString();//操作时间

                }

                catch (Exception ex)
                {
                    this.Err = "查询处方明细赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }

                al.Add(objRoom);
            }
            this.Reader.Close();
            return al;
        }


        protected string[] myGetParmRoomInfo(Neusoft.HISFC.Models.Nurse.Room obj)
        {
            string[] strParm ={	
								 obj.Nurse.ID,
								 obj.ID,
								 obj.Name,
								 obj.InputCode,
								 obj.IsValid,
								 obj.Sort.ToString(),
								 obj.User01,
								 obj.User02
												
							 };

            return strParm;

        }

        #endregion
    }
}