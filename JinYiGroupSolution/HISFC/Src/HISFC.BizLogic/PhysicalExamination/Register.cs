using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.BizLogic.PhysicalExamination.Enum;
namespace Neusoft.HISFC.BizLogic.PhysicalExamination
{
    /// <summary>
    /// Register<br></br>
    /// [功能描述: 体检登记类]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Register : Neusoft.FrameWork.Management.Database
    {
        #region 基本信息
        #region 查询一段时间内体检人员信息 返回 动态数组
        /// <summary>
        /// 查询一段时间内体检人员信息 返回 动态数组
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public ArrayList QueryPatient(string BeginTime, string EndTime)
        {
            string strSql = GetExamPatientSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkPatient.All", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, BeginTime, EndTime);
            //取单位信息数据
            return this.myGetItem(strSQL);
        }
        #endregion

        #region 根据卡号获取病人基本信息  注意不是登记信息
        /// <summary>
        /// 根据卡号获取病人基本信息  注意不是登记信息 
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public ArrayList QueryPatient(string CardNo)
        {
            string strSql = GetExamPatientSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkPatient.ByCardNO", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, CardNo);
            //取单位信息数据
            return this.myGetItem(strSQL);
        }
        #endregion

        #region 获取某个时间段内的体检人员信息 返回 DataSet
        /// <summary>
        /// 获取某个时间段内的体检人员信息 返回 DataSet 
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int QueryPatient(string BeginTime, string EndTime, ref System.Data.DataSet ds)
        {
            string strSql = GetExamPatientSql();
            if (strSql == null)
            {
                return -1;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkPatient.All", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return -1;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, BeginTime, EndTime);
            //取单位信息数据
            return this.ExecQuery(strSQL, ref ds);
        }
        #endregion

        #region  增加或删除一行数据
        /// <summary>
        /// 增加或删除一行数据
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public int AddOrUpdate(Neusoft.HISFC.Models.PhysicalExamination.Register register)
        {
            if (this.UpdateInfo(register) <= 0)
            {
                if (InsertInfo(register) <= 0)
                {

                    return -1;
                }
            }
            return 1;
        }
        #endregion

        #region  取单位信息数据列表，可能是一条或者多条
        /// <summary>
        /// 取单位信息数据列表，可能是一条或者多条
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>单位信息对象数组</returns>
        private ArrayList myGetItem(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.PhysicalExamination.Register ChkRegister = null; //单位项目信息实体
            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得单位项目信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    ChkRegister = new Neusoft.HISFC.Models.PhysicalExamination.Register();
                    ChkRegister.PID.CardNO = this.Reader[0].ToString();//就诊卡号
                    ChkRegister.Name = this.Reader[1].ToString();//姓名
                    ChkRegister.SpellCode = this.Reader[2].ToString();//拼音码
                    ChkRegister.WBCode = this.Reader[3].ToString(); //五笔
                    ChkRegister.IDCard = this.Reader[4].ToString();//身份证
                    ChkRegister.Profession.ID = this.Reader[5].ToString();//职业   
                    ChkRegister.Company.ID = this.Reader[6].ToString();//体检单位
                    ChkRegister.PhoneBusiness = this.Reader[7].ToString();//单位电话
                    ChkRegister.BusinessZip = this.Reader[8].ToString();//单位邮编
                    ChkRegister.AddressHome = this.Reader[9].ToString();//户口或家庭所在
                    ChkRegister.PhoneHome = this.Reader[10].ToString();//家庭电话
                    ChkRegister.HomeZip = this.Reader[11].ToString();//户口或家庭邮政编码
                    ChkRegister.Nationality.ID = this.Reader[12].ToString();//民族
                    ChkRegister.Kin.Name = this.Reader[13].ToString();//联系人姓名
                    ChkRegister.Kin.RelationPhone = this.Reader[14].ToString();//联系人电话
                    ChkRegister.Kin.RelationAddress = this.Reader[15].ToString();//联系人住址
                    ChkRegister.Kin.RelationLink = this.Reader[16].ToString();//联系人关系
                    ChkRegister.MaritalStatus.ID = this.Reader[17].ToString();//婚姻状况
                    ChkRegister.Country.ID = this.Reader[18].ToString(); //国籍 
                    ChkRegister.Pact.PayKind.ID = this.Reader[19].ToString();//结算类别
                    ChkRegister.Pact.PayKind.Name = this.Reader[20].ToString();//结算类别名称 
                    ChkRegister.SSN = this.Reader[21].ToString(); //医疗证号
                    ChkRegister.DIST = this.Reader[22].ToString();//出生地
                    ChkRegister.AnaphyFlag = this.Reader[23].ToString();//药物过敏
                    ChkRegister.Disease.ID = this.Reader[24].ToString();//重要疾病
                    ChkRegister.ArchivesNO = this.Reader[25].ToString();//健康档案号
                    ChkRegister.Company.Name = this.Reader[26].ToString();//体检单位
                    ChkRegister.IdentityLevel = this.Reader[27].ToString();//身份类别
                    ChkRegister.Sex.ID = this.Reader[30].ToString(); //性别
                    ChkRegister.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[31].ToString()); //性别
                    //取查询结果中的记录

                    al.Add(ChkRegister);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得单位项目信息信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            this.Reader.Close();

            ;
            return al;
        }
        #endregion

        #region 获取登记序号
        /// <summary>
        /// 获取登记序号
        /// </summary>
        /// <returns></returns>
        public string GetExamSequence()
        {
            string str = GetSequence("Exami.ChkPatient.GetSEQ");
            str = str.PadLeft(10, '0');
            str = "TJ01" + str;
            return str;
        }
        #endregion

        #region  删除一行数据
        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="register">体检登记实体</param>
        /// <returns></returns>
        public int DeleteInfo(Neusoft.HISFC.Models.PhysicalExamination.Register register)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.DeleteInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.DeleteInfo字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, register.ID);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.DeleteInfo:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region  增加一行数据
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="register">体检登记实体</param>
        /// <returns></returns>
        protected int InsertInfo(Neusoft.HISFC.Models.PhysicalExamination.Register register)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.AddInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.AddInfo字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmItem(register);     //取参数列表
                //strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
                return this.ExecNoQuery(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.AddInfo:" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }
        #endregion

        #region  修改一行数据
        /// <summary>
        /// 修改一行数据
        /// </summary>
        /// <param name="register">体检登记实体</param>
        /// <returns></returns>
        protected int UpdateInfo(Neusoft.HISFC.Models.PhysicalExamination.Register register)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateInfo字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmItem(register);     //取参数列表
                //strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
                return this.ExecNoQuery(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.UpdateInfo:" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }
        #endregion

        #region 获得update或者insert单位项目信息表的传入参数数组
        /// <summary>
        /// 获得update或者insert单位项目信息表的传入参数数组
        /// </summary>
        /// <param name="Item">单位项目信息实体</param>
        /// <returns>字符串数组</returns>
        private string[] myGetParmItem(Neusoft.HISFC.Models.PhysicalExamination.Register ChkRegister)
        {
            string[] strParm ={	
								 ChkRegister.PID.CardNO, //就诊卡号
								 ChkRegister.Name,//姓名
								 ChkRegister.SpellCode,//拼音码
								 ChkRegister.WBCode,//五笔
								 ChkRegister.IDCard,//身份证
								 ChkRegister.Profession.ID,//职业   
								 ChkRegister.Company.Name,//体检单位
								 ChkRegister.PhoneBusiness,//单位电话
								 ChkRegister.BusinessZip,//单位邮编
								 ChkRegister.AddressHome,//户口或家庭所在
								 ChkRegister.PhoneHome ,//家庭电话
								 ChkRegister.HomeZip,//户口或家庭邮政编码
								 ChkRegister.Nationality.ID,//民族
								 ChkRegister.Kin.Name,//联系人姓名
								 ChkRegister.Kin.RelationPhone,//联系人电话
								 ChkRegister.Kin.RelationAddress,//联系人住址
								 ChkRegister.Kin.RelationLink,//联系人关系
								 ChkRegister.MaritalStatus.ID.ToString(),//婚姻状况
								 ChkRegister.Country.ID, //国籍 
								 ChkRegister.Pact.PayKind.ID,//结算类别
								 ChkRegister.Pact.PayKind.Name,//结算类别名称
								 ChkRegister.SSN, //医疗证号
								 ChkRegister.DIST,//出生地
								 ChkRegister.AnaphyFlag,//药物过敏
								 ChkRegister.Disease.ID,//重要疾病
								 ChkRegister.ArchivesNO,//健康档案号
								 ChkRegister.Company.ID,//体检单位
								 ChkRegister.IdentityLevel,//身份类别
								 this.Operator.ID, //操作员
								 ChkRegister.Sex.ID.ToString(), //性别
								 ChkRegister.Birthday.ToString()//生日
							 };
            return strParm;
        }

        #endregion

        #region    获取主SQL
        /// <summary>
        /// 获取主SQL
        /// </summary>
        /// <returns></returns>
        private string GetExamPatientSql()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetCHKPatientSql", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }

            //取单位信息数据
            return strSQL;
        }

        #endregion
        #endregion

        #region 人员信息登记
        #region 获取某个时间段内的体检人员信息 返回 DataSet
        /// <summary>
        /// 获取某个时间段内的体检人员信息 返回 DataSet 
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetRegisterPatient(string BeginTime, string EndTime, ref System.Data.DataSet ds)
        {
            string strSql = GetRegisterSqlSeparater();
            if (strSql == null)
            {
                return -1;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegisterPatient.All", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return -1;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, BeginTime, EndTime);
            //取单位信息数据
            return this.ExecQuery(strSQL, ref ds);
        }
        #endregion

        #region 根据特殊条件查询
        /// <summary>
        /// 获取某个时间段内的体检人员信息 返回 DataSet 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetRegisterPatient(string strWhere, ref System.Data.DataSet ds)
        {
            string strSql = GetRegisterSqlSeparater();
            if (strSql == null)
            {
                return -1;
            }
            strSql += strWhere;
            //取单位信息数据
            return this.ExecQuery(strSql, ref ds);
        }
        #endregion

        #region 按编码查询体检人员信息
        /// <summary>
        /// 按编码查询体检人员信息
        /// </summary>
        /// <param name="ID">卡号 或健康档案号,体检单位,姓名 </param>
        /// <param name="ds"></param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public int GetRegisterPatient(string dtBegin, string dtEnd, string ID, ref System.Data.DataSet ds, ExamType type)
        {
            string strSql = GetRegisterSqlSeparater();
            if (strSql == null)
            {
                return -1;
            }
            string strSQL = "";
            if (type == ExamType.CARDNO)
            {
                //取SELECT语句
                if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegisterPatient.ID.1", ref strSQL) == -1)
                {
                    this.Err = "没有找到Exami.ChkPatient.GetChkRegisterPatient.ID.1字段!";
                    return -1;
                }
            }
            else if (type == ExamType.CHKID)
            {
                //取SELECT语句
                if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegisterPatient.ID.2", ref strSQL) == -1)
                {
                    this.Err = "没有找到Exami.ChkPatient.GetChkRegisterPatient.ID.2字段!";
                    return -1;
                }
            }
            else if (type == ExamType.COMPANY)
            {
                //取SELECT语句
                if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegisterPatient.CompanyCode", ref strSQL) == -1)
                {
                    this.Err = "没有找到Exami.ChkPatient.GetChkRegisterPatient.CompanyCode字段!";
                    return -1;
                }
            }
            else if (type == ExamType.NAME)
            {
                //取SELECT语句
                if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegisterPatient.Name", ref strSQL) == -1)
                {
                    this.Err = "没有找到Exami.ChkPatient.GetChkRegisterPatient.Name字段!";
                    return -1;
                }
            }
            else if (type == ExamType.CLINICNO)
            {
                //取SELECT语句
                if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegisterPatient.ClinicNO", ref strSQL) == -1)
                {
                    this.Err = "没有找到Exami.ChkPatient.GetChkRegisterPatient.ClinicNO字段!";
                    return -1;
                }
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, ID, dtBegin, dtEnd);
            //取单位信息数据
            return this.ExecQuery(strSQL, ref ds);
        }
        #endregion

        #region 根据体检号获取体检登记信息
        /// <summary>
        /// 根据体检号获取体检登记信息
        /// </summary>
        /// <param name="ClinicNO">体检号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.PhysicalExamination.Register GetRegisterByClinicNO(string ClinicNO)
        {
            ArrayList list = null;
            Neusoft.HISFC.Models.PhysicalExamination.Register obj = new Neusoft.HISFC.Models.PhysicalExamination.Register();
            string strSql = GetRegisterSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.ClinicNO", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, ClinicNO);
            //取单位信息数据
            list = this.GetmyRegister(strSQL);
            if (list == null)
            {
                return null;
            }
            if (list.Count > 0)
            {
                obj = (Neusoft.HISFC.Models.PhysicalExamination.Register)list[0];
            }
            return obj;

        }
        #endregion

        #region 根据体检号获取体检登记信息
        /// <summary>
        /// 根据集体体检号 和 内部序号
        /// </summary>
        /// <param name="ClinicNO">体检号</param>
        /// <returns></returns>
        public ArrayList QueryRegisterByCollectivity(string Collectivity, string SortNO)
        {
            ArrayList list = null;
            string strSql = GetRegisterSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.QueryRegisterByCollectivity", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, Collectivity, SortNO);
            //取单位信息数据
            list = this.GetmyRegister(strSQL);
            return list;

        }
        #endregion

        #region 根据卡号查询登记信息
        /// <summary>
        /// 根据卡号查询登记信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByCardNO(string CardNo)
        {
            ArrayList list = null;
            Neusoft.HISFC.Models.PhysicalExamination.Register obj = new Neusoft.HISFC.Models.PhysicalExamination.Register();
            string strSql = GetRegisterSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.CardNo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkRegister.CardNo字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, CardNo);
            //取单位信息数据
            list = this.GetmyRegister(strSQL);
            return list;
        }

        /// <summary>
        /// 根据卡号获取这个卡号下的集体体检记录
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        private ArrayList myQueryInfo(string CardNo)
        {
            ArrayList list = new ArrayList();
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.myQueryInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkRegister.myQueryInfo字段!";
                return null;
            }
            strSQL = string.Format(strSQL, CardNo);
            this.ExecQuery(strSQL);
            Neusoft.HISFC.Models.PhysicalExamination.Register obj = null;
            while (this.Reader.Read())
            {
                obj = new Neusoft.HISFC.Models.PhysicalExamination.Register();
                obj.Company.ID = this.Reader[0].ToString(); //就诊卡号
                obj.Company.Name = this.Reader[1].ToString(); //体检单位
                obj.CollectivityCode = this.Reader[2].ToString(); //集体体检号
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 提供给划价用的函数
        /// <summary>
        /// 根据卡号或费用汇总号或集体体检号,获取个人体检和集体体检登记人员信息 划价用
        /// </summary>
        /// <param name="CollectivityCode">集体体检号</param>
        /// <param name="CardNo">卡号</param>
        /// <returns></returns>
        public ArrayList QueryCollectivityRegisterByCardNO(string CardNo)
        {
            //Exami.GetChkRegister.QueryCollectivityRegisterByCardNO

            //获取某个卡号下的所有人员信息
            ArrayList AList = QueryRegisterByCardNO(CardNo);

            if (AList == null)
            {
                return null;
            }
            #region  根据集体体检号获取信息
            ArrayList BList = QueryRegisterByCollectivityCode(CardNo);
            if (BList == null)
            {
                return null;
            }
            if (BList.Count > 0)
            {
                Neusoft.HISFC.Models.PhysicalExamination.Register obj = (Neusoft.HISFC.Models.PhysicalExamination.Register)BList[0];
                obj.ChkClinicNo = obj.CollectivityCode;
                obj.PID.CardNO = obj.CollectivityCode.Substring(5);
                obj.Name = obj.Company.Name;
                AList.Add(obj);
            }
            #endregion

            #region 根据费用汇总号获取信息
            ArrayList CList = QueryRegisterByRecipeSequence(CardNo);
            if (CList == null)
            {
                return null;
            }
            if (CList.Count > 0)
            {
                Neusoft.HISFC.Models.PhysicalExamination.Register obj = (Neusoft.HISFC.Models.PhysicalExamination.Register)CList[0];
                obj.ChkClinicNo = obj.RecipeSequence;
                obj.PID.CardNO = obj.RecipeSequence.Substring(5);
                obj.Name = obj.Company.Name;
                AList.Add(obj);
            }
            #endregion 
            return AList;
        }
        #endregion

        #region 查询根据汇总号查询
        /// <summary>
        /// 查询根据汇总号查询
        /// </summary>
        /// <param name="RecipeSequence"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByRecipeSequence(string RecipeSequence)
        {
            ArrayList list = null;
            Neusoft.HISFC.Models.PhysicalExamination.Register obj = new Neusoft.HISFC.Models.PhysicalExamination.Register();
            string strSql = GetRegisterSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.QueryRegisterByRecipeSequence", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.QueryRegisterByRecipeSequence字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, RecipeSequence);
            //取单位信息数据
            list = this.GetmyRegister(strSQL);
            return list;
        }
        #endregion

        #region 根据健康档案号查询登记信息
        /// <summary>
        /// 根据健康档案号查询登记信息
        /// </summary>
        /// <param name="ChkNO"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByArchivesNO(string ArchivesNO)
        {
            ArrayList list = null;
            Neusoft.HISFC.Models.PhysicalExamination.Register obj = new Neusoft.HISFC.Models.PhysicalExamination.Register();
            string strSql = GetRegisterSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.ChkNO", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkRegister.ChkNO字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, ArchivesNO);
            //取单位信息数据
            list = this.GetmyRegister(strSQL);
            return list;
        }
        #endregion

        #region 增加或更新某行数据
        /// <summary>
        /// 增加或更新某行数据
        /// </summary>
        /// <param name="Register"></param>
        /// <returns></returns>
        public int AddOrUpdateRegister(Neusoft.HISFC.Models.PhysicalExamination.Register Register)
        {
            if (UpdateInfoRegister(Register) <= 0)
            {
                if (this.AddInfoRegister(Register) <= 0)
                {
                    return -1;
                }
            }
            return 1;
        }
        #endregion

        #region 增加一行数据
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        private int AddInfoRegister(Neusoft.HISFC.Models.PhysicalExamination.Register Register)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.AddInfoRegister", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.AddInfoRegister字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmItemRegister(Register);     //取参数列表
                //strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
                return this.ExecNoQuery(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.AddInfoRegister:" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }
        #endregion

        #region 修改一行数据
        /// <summary>
        /// 修改一行数据
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        private int UpdateInfoRegister(Neusoft.HISFC.Models.PhysicalExamination.Register Register)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateInfoRegister", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateInfoRegister字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmItemRegister(Register);     //取参数列表
                //strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
                return this.ExecNoQuery(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.UpdateInfoRegister:" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }
        #endregion

        #region 删除一行数据
        /// <summary>
        /// 根据体检流水号 删除一行数据
        /// </summary>
        /// <param name="ClinicNo"></param>
        /// <returns></returns>
        public int DeleteInfoRegister(string ClinicNo)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.DeleteInfoRegister", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.DeleteInfoRegister字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ClinicNo);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.DeleteInfoRegister:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 获取卡号
        /// <summary>
        /// 获取当天最大的看诊号
        /// </summary>
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <returns></returns>
        public int GetMaxSeeNo(string strBegin, string strEnd)
        {
            try
            {
                string strSQL = "";
                //取删除操作的SQL语句
                if (this.Sql.GetSql("Exami.ChkPatient.GetMaxSeeNo", ref strSQL) == -1)
                {
                    this.Err = "没有找到Exami.ChkPatient.GetMaxSeeNo字段!";
                    return -1;
                }

                strSQL = string.Format(strSQL, strBegin, strEnd);    //替换SQL语句中的参数。
                return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strSQL));
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        #endregion

        #region 私有
        #region 获取登记人员信息
        /// <summary>
        /// 获取登记人员信息
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        private ArrayList GetmyRegister(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.PhysicalExamination.Register ChkRegister = null; //单位项目信息实体
            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获取登记人员信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    ChkRegister = new Neusoft.HISFC.Models.PhysicalExamination.Register();
                    ChkRegister.TransType = this.Reader[0].ToString(); //交易类型 1 正交易 -1 负交易
                    ChkRegister.ChkClinicNo = this.Reader[1].ToString();//-体检序号
                    ChkRegister.ID = this.Reader[1].ToString();//-体检序号
                    ChkRegister.PID.ID = this.Reader[1].ToString();//-体检序号
                    ChkRegister.SpecalChkType.ID = this.Reader[2].ToString();//特殊体检类型 （招工，入学等） 
                    ChkRegister.PID.CardNO = this.Reader[3].ToString();//就诊卡号
                    ChkRegister.ChkSortNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());//看诊序号
                    ChkRegister.Name = this.Reader[5].ToString();//姓名
                    ChkRegister.Name = this.Reader[5].ToString();//姓名
                    ChkRegister.Sex.ID = this.Reader[6].ToString(); //性别//性别
                    ChkRegister.MaritalStatus.ID = this.Reader[7].ToString();//婚姻状况
                    ChkRegister.Country.ID = this.Reader[8].ToString();//国籍
                    ChkRegister.Height = this.Reader[9].ToString();//身高
                    ChkRegister.Weight = this.Reader[10].ToString();//体重
                    ChkRegister.BloodPressTop = this.Reader[11].ToString();//血压
                    ChkRegister.BloodPressDown = this.Reader[12].ToString();//血压
                    ChkRegister.ChkKind = this.Reader[13].ToString();//2 集体 1 个人
                    ChkRegister.Company.ID = this.Reader[14].ToString();//体检单位
                    ChkRegister.Company.Name = this.Reader[15].ToString();//体检单位名称
                    ChkRegister.SSN = this.Reader[16].ToString();//医疗证号
                    ChkRegister.CheckTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[17]);//体检日期
                    ChkRegister.HomeCase = this.Reader[18].ToString();//家族史
                    ChkRegister.CaseHospital = this.Reader[19].ToString(); //现病史
                    //t.oper_code 审核人,   --审核人 
                    //t.oper_date 审核时间 ,    --审核时间 
                    ChkRegister.SpellCode = this.Reader[22].ToString();//拼音码
                    ChkRegister.WBCode = this.Reader[23].ToString(); //五笔
                    ChkRegister.IDCard = this.Reader[24].ToString();//身份证
                    ChkRegister.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[25].ToString()); //性别
                    ChkRegister.Profession.ID = this.Reader[26].ToString();//职业   
                    //ChkRegister.Company.Name = this.Reader[27].ToString();//体检单位
                    ChkRegister.PhoneBusiness = this.Reader[28].ToString();//单位电话
                    ChkRegister.BusinessZip = this.Reader[29].ToString();//单位邮编
                    ChkRegister.AddressHome = this.Reader[30].ToString();//户口或家庭所在
                    ChkRegister.PhoneHome = this.Reader[31].ToString();//家庭电话
                    ChkRegister.HomeZip = this.Reader[32].ToString();//户口或家庭邮政编码
                    ChkRegister.Nationality.ID = this.Reader[33].ToString();//民族
                    ChkRegister.Kin.Name = this.Reader[34].ToString();//联系人姓名
                    ChkRegister.Kin.RelationPhone = this.Reader[35].ToString();//联系人电话
                    ChkRegister.Kin.RelationAddress = this.Reader[36].ToString();//联系人住址
                    ChkRegister.Kin.RelationLink = this.Reader[37].ToString();//联系人关系
                    ChkRegister.Pact.PayKind.ID = this.Reader[38].ToString();//结算类别
                    ChkRegister.Pact.PayKind.Name = this.Reader[39].ToString();//结算类别名称 
                    ChkRegister.SSN = this.Reader[40].ToString(); //医疗证号
                    ChkRegister.DIST = this.Reader[41].ToString();//出生地
                    ChkRegister.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[42]);//医疗费用
                    ChkRegister.AnaphyFlag = this.Reader[43].ToString();//药物过敏
                    ChkRegister.Disease.ID = this.Reader[44].ToString();//重要疾病
                    ChkRegister.IdentityLevel = this.Reader[45].ToString();//身份类别
                    ChkRegister.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[46].ToString());//身份类别
                    ChkRegister.DutyNuse.ID = this.Reader[47].ToString(); //责任护士
                    ChkRegister.ArchivesNO = this.Reader[48].ToString(); //健康档案号
                    ChkRegister.Operator.Dept.ID = this.Reader[49].ToString(); //操作员科室 
                    ChkRegister.ExtCha = this.Reader[50].ToString(); // 扩展字段1 
                    ChkRegister.ExtDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[51].ToString()); //扩展字段 2
                    ChkRegister.ExtNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[52].ToString()); //扩展字段3 
                    ChkRegister.Item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[53].ToString()); //扩展字段4 
                    ChkRegister.ExtDate1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[54].ToString()); //扩展字段 5
                    ChkRegister.ExtNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[55].ToString()); //扩展字段 6
                    ChkRegister.CollectivityCode = this.Reader[56].ToString(); //集体登记序号
                    ChkRegister.CollectivityTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[57].ToString()); //集体登记日期
                    ChkRegister.CompanyDeptName = this.Reader[58].ToString();//体检单位内部门
                    ChkRegister.CompanyDeptSeq = this.Reader[59].ToString(); //体检内序号
                    ChkRegister.RecipeSequence = this.Reader[60].ToString();//最近一次发票组合号
                    //取查询结果中的记录
                    al.Add(ChkRegister);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获取登记人员信息出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            this.Reader.Close();
            return al;
        }
        #endregion
        #region 获得update或者insert登记信息信息表的传入参数数组
        /// <summary>
        /// 获得update或者insert登记信息信息表的传入参数数组
        /// </summary>
        /// <param name="Item">登记信息信息实体</param>
        /// <returns>字符串数组</returns>
        private string[] myGetParmItemRegister(Neusoft.HISFC.Models.PhysicalExamination.Register ChkRegister)
        {
            string[] strParm ={	
								 ChkRegister.TransType, //交易类型 1 正交易 -1 负交易
								 ChkRegister.ChkClinicNo,//-体检序号
								 ChkRegister.SpecalChkType.ID,//特殊体检类型 （招工，入学等） 
								 ChkRegister.PID.CardNO,//就诊卡号
								 ChkRegister.ChkSortNO.ToString(),//看诊序号
								 ChkRegister.Name,//姓名
								 ChkRegister.MaritalStatus.ID.ToString(),//婚姻状况
								 ChkRegister.Country.ID,//国籍
								 ChkRegister.Height,//身高
								 ChkRegister.Weight,//体重
								 ChkRegister.BloodPressTop ,//血压
								 ChkRegister.BloodPressDown,//血压11
								 ChkRegister.ChkKind,//1 集体 0 个人
								 ChkRegister.Company.ID,//体检单位
								 ChkRegister.Company.Name,//体检单位名称
								 ChkRegister.SSN,//医疗证号
								 ChkRegister.CheckTime.ToString(),//体检日期16
								 ChkRegister.HomeCase,//家族史
								 ChkRegister.CaseHospital, //现病史
								 Operator.ID,//审核人
								 ChkRegister.OwnCost.ToString(),  //花费金额，
								 ChkRegister.DutyNuse.ID, //责任护士21
								 ChkRegister.Operator.Dept.ID , // 操作员科室
								 ChkRegister.ExtCha, //--  扩展字符串                  
								 ChkRegister.ExtDate.ToString(),//--  扩展字符串   
								 ChkRegister.ExtNum.ToString(),//--  扩展字符串   
								 ChkRegister.Item.PackQty.ToString(),//--  扩展字符串   
								 ChkRegister.ExtDate1.ToString(),//--  扩展字符串   
								 ChkRegister.ExtNum1.ToString(),//--  扩展字符串 
								 ChkRegister.CollectivityCode, //集体体检序号
								 ChkRegister.CollectivityTime.ToString(), // 集体体检日期
								 ChkRegister.CompanyDeptName ,//体检内部门
								 ChkRegister.CompanyDeptSeq //体检内序号
							 };
            return strParm;
        }

        #endregion
        #region 简单获取体检人员信息
        /// <summary>
        /// 简单获取体检人员信息
        /// </summary>
        /// <returns></returns>
        private string GetRegisterSqlSeparater()
        {
            //Exami.ChkPatient.GetRegisterSqlSeparater
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetRegisterSqlSeparater", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetRegisterSqlSeparater字段!";
                return null;
            }

            //取单位信息数据
            return strSQL;
        }
        #endregion
        #region 获取人员登记表SQL
        /// <summary>
        /// 获取人员登记表SQL
        /// </summary>
        /// <returns></returns>
        private string GetRegisterSql()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetRegisterSql", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetRegisterSql字段!";
                return null;
            }

            //取单位信息数据
            return strSQL;
        }
        #endregion
        #endregion

        #region  获取体检档案号
        /// <summary>
        /// 获取体检档案号
        /// </summary>
        /// <returns></returns>
        public string GetChkNo()
        {
            string str = GetSequence("Exami.ChkPatient.GetChkNo");
            str = str.PadLeft(10, '0');
            return str;
        }
        /// <summary>
        /// 获取集体体检流水
        /// </summary>
        /// <returns></returns>
        public string GetChkCollectivityCode()
        {
            string str = GetSequence("Exami.ChkPatient.GetChkCollectivityCode");
            str = str.PadLeft(14, '0');
            str = "JT" + str.Substring(2);
            return str;
        }
        #endregion

        #region 获取 集体体检
        /// <summary>
        /// 获取集体体检记录
        /// </summary>
        /// <param name="strCompCode"></param>
        /// <returns></returns>
        public ArrayList QueryCollectivity(string strCompCode)
        {
            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.PhysicalExamination.Register obj = null;
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetCollectivity", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetCollectivity字段!";
                return null;
            }
            strSQL = string.Format(strSQL, strCompCode);
            this.ExecQuery(strSQL);
            //取单位信息数据
            while (this.Reader.Read())
            {
                obj = new Neusoft.HISFC.Models.PhysicalExamination.Register();
                obj.Company.Name = this.Reader[0].ToString();
                obj.CollectivityCode = this.Reader[1].ToString();
                //				obj.CollectivityDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[2].ToString());
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 根据集体体检号获取该体检人员信息
        /// <summary>
        /// 根据集体体检号获取该体检人员信息
        /// </summary>
        /// <param name="CollectivityCode"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByCollectivityCode(string CollectivityCode)
        {
            ArrayList list = null;
            Neusoft.HISFC.Models.PhysicalExamination.Register obj = new Neusoft.HISFC.Models.PhysicalExamination.Register();
            string strSql = GetRegisterSql();
            if (strSql == null)
            {
                return null;
            }
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.CollectivityCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkRegister.CollectivityCode字段!";
                return null;
            }
            strSQL = strSql + strSQL;
            strSQL = string.Format(strSQL, CollectivityCode);
            //取单位信息数据
            list = this.GetmyRegister(strSQL);
            return list;
        }
        #endregion

        #region 根据集体体检号获取该体检单位的历次集体体检号
        /// <summary>
        /// 根据集体体检号获取该体检单位的历次集体体检号
        /// </summary>
        /// <param name="CollectivityCode"></param>
        /// <returns></returns>
        public ArrayList QueryCompanyByCollectivityCode(string CollectivityCode)
        {
            ArrayList list = new ArrayList();
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.GetCompanyByCollectivityCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkRegister.GetCompanyByCollectivityCode字段!";
                return null;
            }
            strSQL = string.Format(strSQL, CollectivityCode);
            //取单位信息数据
            this.ExecQuery(strSQL);

            Neusoft.FrameWork.Models.NeuObject obj = null;
            while (this.Reader.Read())
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                obj.Name = this.Reader[1].ToString();
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 根据体检档案号获取卡号
        public ArrayList QueryCardNoByChkID(string ChkID)
        {
            ArrayList list = new ArrayList();
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.QueryCardNoByChkID", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkRegister.QueryCardNoByChkID字段!";
                return null;
            }
            strSQL = string.Format(strSQL, ChkID);
            //取单位信息数据
            this.ExecQuery(strSQL);

            Neusoft.FrameWork.Models.NeuObject obj = null;
            while (this.Reader.Read())
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 查询一段时间内的集体登记信息
        public ArrayList QueryCompanyRegister(string beginDate,string endDate)
        {
            ArrayList list = new ArrayList();
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkRegister.QueryCompanyRegister", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkRegister.QueryCompanyRegister字段!";
                return null;
            }
            strSQL = string.Format(strSQL, beginDate, endDate);
            //取单位信息数据
            this.ExecQuery(strSQL);

            Neusoft.FrameWork.Models.NeuObject obj = null;
            while (this.Reader.Read())
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.Name = this.Reader[0].ToString();
                obj.ID = this.Reader[1].ToString();
                list.Add(obj);
            }
            return list;
        }
        #endregion 
        #region 获取集体体检列表
        /// <summary>
        /// 获取集体体检列表 -- 用于费用汇总
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryCollectivityRegister(string CollectivityCode)
        {
            ArrayList list = new ArrayList();
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.QueryCollectivityRegisterID", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.QueryCollectivityRegister字段!";
                return null;
            }

            //取单位信息数据
            this.ExecQuery(strSQL, CollectivityCode);

            Neusoft.FrameWork.Models.NeuObject obj = null;
            while (this.Reader.Read())
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();//流水号 
                obj.User01 = this.Reader[1].ToString();//收费组合号
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #endregion

        #region 费用信息
        #region  更新体检明细的确认人＆确认事件
        /// <summary>
        /// 更新体检明细的确认人＆确认事件
        /// </summary>
        /// <param name="obj">要确认的实体</param>
        /// <returns></returns>
        public int UpdateConfirmInfo(string MoOrder, string ConfirmFlag, int NoBackQty)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateConfirmInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateConfirmInfo字段!";
                return -1;
            }
            strSQL = string.Format(strSQL, MoOrder, ConfirmFlag, this.Operator.ID, NoBackQty);
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新确认数量
        /// </summary>
        /// <param name="moOrder"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public int UpdateConfirmAmount(string moOrder, decimal confirmNum)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateConfirmAmount", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateConfirmInfo字段!";
                return -1;
            }
            strSQL = string.Format(strSQL, moOrder, confirmNum.ToString(), this.Operator.ID);
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region  获取体检明细
        /// <summary>
        /// 获取体检明细
        /// </summary>
        /// <param name="ClinicNo"></param>
        /// <returns></returns>
        public ArrayList QueryItemListByClinicNO(string ClinicNo)
        {
            string strSQL = "";
            string strSql2 = GetChkItemSql();
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkItemList.ClinicNo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }
            strSQL = string.Format(strSQL, ClinicNo);
            strSQL = strSql2 + strSQL;
            return GetItemList(strSQL); //体检项目信息实体
        }
        /// <summary>
        /// 获取体检明细
        /// </summary>
        /// <param name="ClinicNo"></param>
        /// <param name="feeFlag"> 0 未收费，1，已收费，2作废</param>
        /// <returns></returns>
        public ArrayList QueryItemListByClinicNO(string ClinicNo, string feeFlag)
        {
            string strSQL = "";
            string strSql2 = GetChkItemSql();
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkItemList.ClinicNoFeeFlag", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }
            strSQL = string.Format(strSQL, ClinicNo, feeFlag);
            strSQL = strSql2 + strSQL;
            return GetItemList(strSQL); //体检项目信息实体
        }
        /// <summary>
        /// 根据流水号获取体检项目明细
        /// </summary>
        /// <param name="SequenceNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.PhysicalExamination.ItemList GetItemListBySequence(string SequenceNo)
        {
            string strSQL = "";
            string strSql2 = GetChkItemSql();
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkItemBySequence", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.GetChkItemBySequence字段!";
                return null;
            }
            strSQL = string.Format(strSQL, SequenceNo);
            strSQL = strSql2 + strSQL;
            ArrayList list = GetItemList(strSQL); //体检项目信息实体
            if (list == null)
            {
                return null;
            }
            if (list.Count == 0)
            {
                return new Neusoft.HISFC.Models.PhysicalExamination.ItemList();
            }
            return (Neusoft.HISFC.Models.PhysicalExamination.ItemList)list[0];
        }
        #endregion

        #region 汇总费用
        public ArrayList QueryGatherItemList(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.QueryGatherItemList", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.QueryGatherItemList字段!";
                return null;
            }
            strSQL = string.Format(strSQL, obj.ID);
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得体检项目信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            ArrayList list = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.PhysicalExamination.ItemList item = new Neusoft.HISFC.Models.PhysicalExamination.ItemList();
                item.Item.ID = this.Reader[0].ToString();//项目编码
                item.Item.Name = this.Reader[1].ToString();//项目名称
                item.ExecDept.ID = this.Reader[2].ToString();//执行科室
                item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                item.RealCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                item.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                item.NoBackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6].ToString());
                item.UnitFlag = this.Reader[7].ToString();
                item.Item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8].ToString());
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region 更新可退数量
        public int UpdateNobackNum(string seqenceNO, int Qty, int BackQty)
        {

            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateNobackNum", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateNobackNum字段!";
                return -1;
            }
            try
            {
                //				string[] strParm = GetParame( item );     //取参数列表
                strSQL = string.Format(strSQL, seqenceNO, Qty, BackQty, this.Operator.ID);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.InsertChkItemList:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int InsertChkItemList(Neusoft.HISFC.Models.PhysicalExamination.ItemList item)
        {

            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.InsertChkItemList", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.InsertChkItemList字段!";
                return -1;
            }
            try
            {
                string[] strParm = GetParame(item);     //取参数列表
                //strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
                return this.ExecNoQuery(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.InsertChkItemList:" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }

        #region 更新收费标志
        /// <summary>
        /// 更新收费标志
        /// </summary>
        /// <param name="feeFlag">  0 未收费，1，已收费，2作废 </param>
        /// <param name="MoOrder">医嘱流水号</param>
        /// <returns></returns>
        public int UpdateItemListFeeFlagByMoOrder(string feeFlag, string MoOrder)
        {
            if (feeFlag == null || feeFlag == "")
            {
                this.Err = "更新体检收费标志失败,收费标志没有赋值";
                return -1;
            }
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateItemListFeeFlag", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateItemListFeeFlag字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, MoOrder, feeFlag, this.Operator.ID);
                return this.ExecNoQuery(strSQL);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.UpdateItemListFeeFlag:" + ex.Message;
                this.WriteErr();
                return -1;
            }
        }
        /// <summary>
        /// 更新收费标志
        /// </summary>
        /// <param name="feeFlag">  0 未收费，1，已收费，2作废 </param>
        /// <param name="RecipeSeq">收费组合号</param>
        /// <returns></returns>
        public int UpdateItemListFeeFlagByRecipeSeq(string feeFlag, string RecipeSeq)
        {
            if (feeFlag == null || feeFlag == "")
            {
                this.Err = "更新体检收费标志失败,收费标志没有赋值";
                return -1;
            }
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateItemListFeeFlagByRecipeSeq", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateItemListFeeFlagByRecipeSeq字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, RecipeSeq, feeFlag, this.Operator.ID);
                return this.ExecNoQuery(strSQL);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.UpdateItemListFeeFlag:" + ex.Message;
                this.WriteErr();
                return -1;
            }
        }
        #endregion

        #region 删除所有体检明细
        /// <summary>
        /// 删除所有体检记录
        /// </summary>
        /// <param name="ClinicNO"></param>
        /// <returns></returns>
        public int DeleteItemListByClinicNO(string ClinicNO)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.DeleteCHkItemList", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.DeleteCHkItemList字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ClinicNO);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.DeleteCHkItemList:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 删除某一条体检明细
        /// <summary>
        /// 某一条体检明细
        /// </summary>
        /// <param name="SeqenceNo"></param>
        /// <returns></returns>
        public int DeleteItemListBySeqenceNO(string SeqenceNo)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.DeleteOneCHkItemList", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.DeleteOneCHkItemList字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, SeqenceNo);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.ChkPatient.DeleteOneCHkItemList:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region 更新汇总后的收费序列
        /// <summary>
        /// 更新体检明细的发票组合序列
        /// </summary>
        /// <param name="item"></param>
        /// <param name="recipeSequence"></param>
        /// <returns></returns>
        public int UpdateItemListRecipeSequence(Neusoft.HISFC.Models.PhysicalExamination.ItemList item, string recipeSequence)
        {

            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateRecipeSequence", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateRecipeSequence字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, item.ClinicNO, recipeSequence); //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错 Exami.ChkPatient.UpdateRecipeSequence:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新体检登记表最近一次汇总发票序列
        /// </summary>
        /// <param name="item"></param>
        /// <param name="recipeSequence"></param>
        /// <returns></returns>
        public int UpdateRegisterRecipeSequence(Neusoft.HISFC.Models.PhysicalExamination.ItemList item, string recipeSequence)
        {

            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.ChkPatient.UpdateRegisterRecipeSequence", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.UpdateRegisterRecipeSequence字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, item.ClinicNO, recipeSequence); //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错 Exami.ChkPatient.UpdateRegisterRecipeSequence:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region 查询汇总费用信息
        public int QueryGatherFeeByRecipeSeq(ref System.Data.DataSet ds, string RecipeSeq)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.QueryGatherFeeByRecipeSeq", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient.QueryGatherFeeByRecipeSeq字段!";
                return -1;
            }
            strSQL = string.Format(strSQL, RecipeSeq);
            //取单位信息数据
            return this.ExecQuery(strSQL, ref ds);
        }
        #endregion

        #region 私有成员
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="itemlist"></param>
        /// <returns></returns>
        private string[] GetParame(Neusoft.HISFC.Models.PhysicalExamination.ItemList itemlist)
        {
            string strConformFlag = "";
            //if (itemlist.Item.IsNeedConfirm == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient || itemlist.Item.IsNeedConfirm == Neusoft.HISFC.Models.Fee.ConfirmState.All)
            //{
            //    strConformFlag = "1";
            //}
            //else
            //{
            //    strConformFlag = "0";
            //}
            if (itemlist.Item.IsNeedConfirm)
            {
                strConformFlag = "1";
            }
            else
            {
                strConformFlag = "0";
            }
            string[] str = new string[]
				{
					itemlist.SequenceNO,//序列号0
					itemlist.ClinicNO,//体检序号1
					itemlist.CardNO,//就诊卡号2
					itemlist.Item.ID ,//项目代码3
					itemlist.Item.Qty.ToString(),//数量4
					itemlist.UnitFlag,//单位标识5
					itemlist.EcoRate.ToString(),//优惠了多少金额6
					itemlist.ExecDept.ID,//执行科室7
					strConformFlag,//8
					itemlist.ConformOper.ID, //确认人9
					itemlist.ConformOper.OperTime.ToString() , //确认时间10
					itemlist.ExtFlag,//出国体检码11
					itemlist.RealCost.ToString(),//--实际价格12
					itemlist.Item.PriceUnit ,//   --单位
					itemlist.Combo ,//--扩展标志14
					itemlist.Item.Price.ToString(),//   --价格15
					itemlist.Item.PackQty.ToString(),//  --包装数量16
					this.Operator.ID,//操作员代码17
					System.DateTime.Now.ToString(), //执行科室18
					itemlist.NoBackQty.ToString(),
					itemlist.RecipeDoc.ID, //开单科室
					itemlist.ChkFlag, //集体体检 2  个人体检 1
					itemlist.RecipeDept.ID, //开单医生
					itemlist.Item.Name,//项目名称
					itemlist.Item.SysClass.ID.ToString(), //系统类别
                    itemlist.AccountFlag //扣账户标记 0 没有扣账户  1 已扣门诊账户
				};
            return str;
        }
        /// <summary>
        /// 获取体检项目信息
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        private ArrayList GetItemList(string strSQL)
        {
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得体检项目信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            ArrayList al = new ArrayList();
            try
            {

                Neusoft.HISFC.Models.PhysicalExamination.ItemList itemlist = null;
                while (this.Reader.Read())
                {
                    itemlist = new Neusoft.HISFC.Models.PhysicalExamination.ItemList();
                    itemlist.SequenceNO = this.Reader[0].ToString();//序列号
                    itemlist.ClinicNO = this.Reader[1].ToString();//体检序号
                    itemlist.CardNO = this.Reader[2].ToString();//就诊卡号
                    itemlist.Item.ID = this.Reader[3].ToString();//项目代码
                    itemlist.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4]);//数量
                    itemlist.UnitFlag = this.Reader[5].ToString();//单位标识
                    itemlist.EcoRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6]);//实际金额6
                    itemlist.ExecDept.ID = this.Reader[7].ToString();//执行科室
                    itemlist.ExecDept.Name = this.Reader[8].ToString();//执行科室
                    if (this.Reader[9].ToString() == "1")
                    {
                        itemlist.Item.IsNeedConfirm = true;
                    }
                    else
                    {
                        itemlist.Item.IsNeedConfirm = false;
                    }
                    itemlist.ConformOper.ID = this.Reader[10].ToString(); //确认人
                    itemlist.ConformOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11]); //确认时间
                    itemlist.ExtFlag = this.Reader[12].ToString();//扩展标志12
                    itemlist.RealCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13]);//--扩展标志13
                    itemlist.Item.PriceUnit = this.Reader[14].ToString();//   --单位
                    itemlist.Combo = this.Reader[15].ToString();//--组合号
                    itemlist.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16].ToString());//   --扩展标志16
                    itemlist.Item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());//  --扩展字符字段17
                    itemlist.OperInfo.ID = this.Reader[18].ToString();//操作员代码
                    itemlist.OperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[19].ToString());//操作日期
                    itemlist.FeeFlag = this.Reader[20].ToString();//收费标志
                    itemlist.FeeOperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[21]);//收费时间
                    itemlist.FeeOperInfo.ID = this.Reader[22].ToString();//收费员
                    itemlist.NoBackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[23].ToString());  //可退数量
                    itemlist.RecipeDoc.ID = this.Reader[24].ToString(); //开单科室
                    itemlist.ChkFlag = this.Reader[25].ToString(); //集体体检 2  个人体检 1
                    itemlist.RecipeDept.ID = this.Reader[26].ToString(); //开单医生
                    itemlist.Item.Name = this.Reader[27].ToString();//项目名称
                    itemlist.Item.SysClass.ID = this.Reader[28].ToString();
                    itemlist.OperInfo.Name = this.Reader[29].ToString();//操作员
                    itemlist.RecipeSequence = this.Reader[30].ToString();
                    itemlist.AccountFlag = this.Reader[31].ToString();//0 扣门诊账户 1 扣门诊账户
                    //取查询结果中的记录
                    al.Add(itemlist);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得单位项目信息信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            this.Reader.Close();
            return al;
        }
        /// <summary>
        /// 获取体检项目sql
        /// </summary>
        /// <returns></returns>
        private string GetChkItemSql()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.ChkPatient.GetChkItemList.Sql", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.ChkPatient字段!";
                return null;
            }
            return strSQL;
        }
        #endregion

        #endregion 
    }
}
