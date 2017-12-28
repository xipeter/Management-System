using System;
using System.Collections;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models;
using Neusoft.HISFC.Models.Admin;
using System.Collections.Generic;

namespace Neusoft.HISFC.BizLogic.Manager
{

    /// <summary>
    /// 人员权限分配明细管理
    /// cuipeng 
    /// </summary>
    public class UserPowerDetailManager : Neusoft.FrameWork.Management.Database
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserPowerDetailManager()
        {
        }

        /// <summary>
        /// 取所有明细数据
        /// </summary>	
        public ArrayList LoadAll()
        {
            //取SQL语句
            string sqlstring = PrepareSQL("Manager.UserPowerDetailManager.LoadAll", null);

            return this.myGetList(sqlstring);
        }

        /// <summary>
        /// 根据人员编码，根据大类取人员在各部门中的权限。
        /// </summary>
        /// <returns></returns>
        public ArrayList LoadByUserCode(string userCode, string class1Code)
        {
            //取SQL语句
            string sqlstring = PrepareSQL("Manager.UserPowerDetailManager.LoadByUserCode", userCode, class1Code);

            return this.myGetList(sqlstring);
        }

        /// <summary>
        /// 根据人员编码，根据大类，部门取人员在本部门中的权限。
        /// </summary>
        /// <returns></returns>
        public ArrayList LoadByUserCode(string userCode, string class1Code, string deptCode)
        {
            string sqlstring = PrepareSQL("Manager.UserPowerDetailManager.LoadByUserCode.DeptCode", userCode, class1Code, deptCode);

            return this.myGetList(sqlstring);
        }

        /// <summary>
        /// 根据大类，部门取在本部门中有权限的人员。
        /// </summary>
        /// <returns>NeuObject数组</returns>
        public ArrayList LoadUser(string class1Code, string deptCode)
        {
            //取SQl语句
            string strSQL = PrepareSQL("Manager.UserPowerDetailManager.LoadUser", class1Code, deptCode);

            ArrayList al = new ArrayList();
            if (strSQL == string.Empty) return null;
            try
            {
                UserPowerDetail info;
                this.ExecQuery(strSQL);
                while (this.Reader.Read())
                {
                    info = new UserPowerDetail();
                    //取字段数据
                    info.User.ID = this.Reader[0].ToString();    //编码
                    info.User.Name = this.Reader[1].ToString();    //姓名
                    info.Class1Code = this.Reader[2].ToString();    //一级权限分类码，权限类型
                    info.Dept.ID = this.Reader[3].ToString();    //权限部门
                    info.User01 = this.Reader[4].ToString();   //性别
                    al.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                al.Clear();
            }

            return al;
        }

        /// <summary>
        /// 根据人员编码，部门编码,二级权限取人员所拥有的权限。
        /// </summary>
        /// <param name="userCode">权限人员编码</param>
        /// <param name="class2Code">二级权限码</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回权限集合 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryUserPrivCollection(string userCode, string class2Code, string deptCode)
        {
            string sqlstring = PrepareSQL("Manager.UserPowerDetailManager.LoadUserPriv", userCode, class2Code, deptCode);
            if (sqlstring == null) return null;

            List<Neusoft.FrameWork.Models.NeuObject> al = new List<NeuObject>();
            try
            {
                Neusoft.FrameWork.Models.NeuObject info;
                this.ExecQuery(sqlstring);
                while (this.Reader.Read())
                {
                    info = new NeuObject();
                    info.ID = this.Reader[0].ToString();		//三级权限编码
                    info.Name = this.Reader[1].ToString();		//三级权限名称
                    info.User01 = this.Reader[2].ToString();	//是否可以授权
                    al.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            return al;
        }

        /// <summary>
        /// 根据人员编码，二级权限编码取人员拥有权限的部门
        /// </summary>
        /// <param name="userCode">操作员编码</param>
        /// <param name="class2Code">二级权限码</param>
        /// <returns>成功返回具有权限的科室集合 失败返回null</returns>        
        public List<Neusoft.FrameWork.Models.NeuObject> QueryUserPriv(string userCode, string class2Code)
        {
            //取SQL语句
            string sqlstring = PrepareSQL("Manager.UserPowerDetailManager.LoadPrivDept", userCode, class2Code);
            if (sqlstring == null)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            //取数据
            List<Neusoft.FrameWork.Models.NeuObject> al = new List<NeuObject>();
            try
            {
                Neusoft.FrameWork.Models.NeuObject info;
                this.ExecQuery(sqlstring);
                while (this.Reader.Read())
                {
                    info = new NeuObject();
                    info.ID = this.Reader[0].ToString();  //科室编码
                    info.Name = this.Reader[1].ToString();  //科室名称
                    info.User01 = this.Reader[2].ToString();  //二级权限编码
                    info.User02 = this.Reader[3].ToString();  //二级权限名称
                    info.User03 = this.Reader[4].ToString();  //二级权限特殊标记：1判断窗口权限时，只要存在权限就允许进入，不需要用户选择科室
                    info.Memo = this.Reader[5].ToString();  //科室类型
                    al.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            return al;
        }

        /// <summary>
        /// 取操作员所拥有的权限操作科室
        /// </summary>
        /// <param name="userCode">操作员编码</param>
        /// <param name="class2Code">二级权限码</param>
        /// <param name="class3Code">三级权限码</param>
        /// <returns>成功返回具有权限的科室集合 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryUserPriv(string userCode, string class2Code, string class3Code)
        {
            //取SQL语句
            string sqlstring = PrepareSQL("Manager.UserPowerDetailManager.QueryUserPriv.1", userCode, class2Code, class3Code);
            if (sqlstring == null)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            //取数据
            List<Neusoft.FrameWork.Models.NeuObject> al = new List<NeuObject>();
            try
            {
                Neusoft.FrameWork.Models.NeuObject info;
                this.ExecQuery(sqlstring);
                while (this.Reader.Read())
                {
                    info = new NeuObject();
                    info.ID = this.Reader[0].ToString();        //科室编码
                    info.Name = this.Reader[1].ToString();      //科室名称
                    info.Memo = this.Reader[2].ToString();      //科室类型
                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 科室权限判断
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="class2Code">二级权限</param>
        /// <param name="class3Code">三级权限</param>
        /// <returns>存在权限返回True 不存在权限返回False</returns>
        public bool JudgeUserPriv(string userCode, string deptCode, string class2Code, string class3Code)
        {
            List<Neusoft.FrameWork.Models.NeuObject> userDeptList = this.QueryUserPrivCollection(userCode, class2Code, deptCode);
            if (userDeptList == null)
            {
                return false;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in userDeptList)
            {
                if (info.ID == class3Code)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 取拥有特定权限的人员列表如果不确定时可以传class1Code，class2Code，class3Code
        /// </summary>
        /// <returns>NeuObject数组</returns>
        public ArrayList QueryAllPrivUser(string class1Code, string class2Code, string class3code)
        {
            string strSql = string.Empty;
            //取SQl语句
            strSql = PrepareSQL("Manager.UserPowerDetailManager.LoadAllUser", class1Code, class2Code, class3code);

            ArrayList al = new ArrayList();
            if (strSql == string.Empty) return null;
            try
            {
                UserPowerDetail info;
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    info = new UserPowerDetail();
                    //取字段数据
                    info.User.ID = this.Reader[0].ToString();    //编码
                    info.User.Name = this.Reader[1].ToString();    //姓名
                    info.Class1Code = this.Reader[2].ToString();    //一级权限分类码，权限类型
                    info.Dept.ID = this.Reader[3].ToString();    //权限部门
                    info.User01 = this.Reader[4].ToString();   //性别
                    info.User02 = this.Reader[5].ToString();//人员所在科室
                    info.User03 = this.Reader[6].ToString();//人员所在病区
                    al.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                al.Clear();
            }

            return al;
        }
     
        #region 基础操作

        /// <summary>
        /// 插入人员权限明细表中一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertUserPowerDetail(UserPowerDetail info)
        {
            string strSql = "";
            //获取SQL语句
            if (this.Sql.GetSql("Manager.UserPowerDetailManager.InsertUserPowerDetail", ref strSql) == -1) return -1;
            //获取参数
            try
            {
                string[] strParm = myGetParm(info);      //取参数列表
                strSql = string.Format(strSql, strParm);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新人员权限明细表中一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateUserPowerDetail(UserPowerDetail info)
        {
            string strSql = "";
            //获取SQL语句
            if (this.Sql.GetSql("Manager.UserPowerDetailManager.UpdateUserPowerDetail", ref strSql) == -1) return -1;
            //获取参数
            try
            {
                string[] strParm = myGetParm(info);      //取参数列表
                strSql = string.Format(strSql, strParm);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="class1"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public int Delete(string userCode, string class1, string deptCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Manager.UserPowerDetailManager.DeleteUserPowerDetail", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, deptCode, userCode, class1);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 根据传入的SQL语句，执行数据库查询操作，返回数组
        /// </summary>
        /// <returns></returns>
        private ArrayList myGetList(string strSQL)
        {
            if (strSQL == null) return null;
            ArrayList UserPowerDetails = new ArrayList();
            try
            {
                UserPowerDetail info;
                this.ExecQuery(strSQL);
                while (this.Reader.Read())
                {
                    info = new UserPowerDetail();
                    info.Dept.ID = this.Reader[0].ToString();		//科室编码
                    info.User.ID = this.Reader[1].ToString();		//用户编码
                    info.Class1Code = this.Reader[2].ToString();	//一级权限编码
                    info.Class2Code = this.Reader[3].ToString();	//二级权限编码
                    info.PowerLevelClass.Class3Code = this.Reader[4].ToString();	//三级权限编码
                    info.GrantDept = this.Reader[5].ToString();		//授权科室
                    info.GrantEmpl = this.Reader[6].ToString();		//授权人
                    info.GrantFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[7].ToString());	//是否可以授权
                    info.Memo = this.Reader[8].ToString();			//备注
                    UserPowerDetails.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            return UserPowerDetails;
        }

        /// <summary>
        /// 获得update或者insert时传入参数数组
        /// </summary>
        /// <returns></returns>
        private string[] myGetParm(UserPowerDetail info)
        {
            string[] strParm ={
				info.Dept.ID,                     //科室编码
				info.User.ID,                     //用户编码
				info.Class1Code,                  //一级权限编码
				info.Class2Code,                  //二级权限编码
				info.PowerLevelClass.Class3Code,  //三级权限编码
				info.GrantDept,                   //授权科室
				info.GrantEmpl,                   //授权人
				Neusoft.FrameWork.Function.NConvert.ToInt32(info.GrantFlag).ToString(), //是否可以授权他人
			    this.Operator.ID,				  //操作人编码
				info.Memo	                      //备注
			};
            return strParm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private string PrepareSQL(string sqlName, params string[] values)
        {
            string strSql = string.Empty;
            if (this.Sql.GetSql(sqlName, ref  strSql) == -1)
            {
                this.Err = "找不到sql语句:" + sqlName;
                return null;
            }
            try
            {
                if (values != null)
                    strSql = string.Format(strSql, values);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                strSql = null;
            }
            return strSql;
        }

        #endregion

        #region 无效

        /// <summary>
        /// 根据人员编码，二级权限编码取人员拥有权限的部门
        /// </summary>
        /// <returns></returns>
        [System.Obsolete("重构 更改为QueryUserPriv 函数", true)]
        public ArrayList LoadPrivDept(string userCode, string class2Code)
        {
            return null;
        }


        
        /// <summary>
        /// 根据人员编码，部门编码,二级权限取人员所拥有的权限。
        /// </summary>
        /// <returns></returns>
        [System.Obsolete("重构 更改为QueryUserPrivCollection 函数", true)]
        public ArrayList LoadUserPriv(string userCode, string class2Code, string deptCode)
        {
            return null;
        }
        #endregion

    }

}