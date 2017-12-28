using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.PhysicalExamination
{
    /// <summary>
    /// Company<br></br>
    /// [功能描述: 体检单位类]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Company : Neusoft.FrameWork.Management.Database
    {
        #region 共有函数
        #region 查询所有的体检单位信息 返回动态数组
        /// <summary>
        /// 查询所有的体检单位信息 返回动态数组
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryCompany()
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.Company.GetCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.Company字段!";
                return null;
            }

            //取单位信息数据
            return this.myGetItem(strSQL);
        }
        #endregion

        #region 查询某个ID的体检单位信息
        /// <summary>
        /// 查询某个ID的体检单位信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Pharmacy.Company GetCompanyByID(string ID)
        {
            Neusoft.HISFC.Models.Pharmacy.Company com = new Neusoft.HISFC.Models.Pharmacy.Company();
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Exami.Company.GetCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.Company字段!";
                return null;
            }

            //取单位信息数据
            ArrayList list = this.myGetItem(strSQL);
            if (list == null)
            {
                return null;
            }
            if (list.Count == 0)
            {
                return com;
            }
            return (Neusoft.HISFC.Models.Pharmacy.Company)list[0];
        }
        #endregion

        #region 增加或删除一行数据
        /// <summary>
        /// 增加或删除一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int AddOrUpdate(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            if (UpdateInfo(company) <= 0)
            {
                if (this.InsertInfo(company) == -1)
                {
                    return -1;
                }
            }
            return 1;
        }
        #endregion

        #region  删除一行数据
        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int DeleteInfo(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Exami.Company.DeleteInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.Company.DeleteInfo字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, company.ID);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.Company.DeleteInfo" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region  获取序号
        public string GetCHKSequence()
        {
            return this.GetSequence("Exami.Company.GetSEQ");
        }
        #endregion

        #region 是否已经存在
        /// <summary>
        /// 是否
        /// </summary>
        /// <param name="ComCode"></param>
        /// <returns>-1 出错 ，1 没有用过 2 用过</returns>
        public int IsExistCompany(string comCode)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Exami.Company.IsExistCompany", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.Company.IsExistCompany字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, comCode);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.Company.IsExistCompany:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            this.ExecQuery(strSQL);
            while (this.Reader.Read())
            {
                return 2;
            }
            return 1;
        }
        #endregion
        #endregion

        #region  私有成员函数
        #region 增加一行数据
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        protected int InsertInfo(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Exami.Company.AddInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.Company.AddInfo字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmItem(company);     //取参数列表
                //strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
                return this.ExecNoQuery(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.Company.AddInfo:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            
        }
        #endregion

        #region 取单位信息数据列表，可能是一条或者多条
        /// <summary>
        /// 取单位信息数据列表，可能是一条或者多条
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>单位信息对象数组</returns>
        protected ArrayList myGetItem(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Company company = null; //单位项目信息实体
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
                    //取查询结果中的记录
                    company = new Neusoft.HISFC.Models.Pharmacy.Company();
                    company.ID = this.Reader[0].ToString();  //公司编码 //0 
                    company.Name = this.Reader[1].ToString();//公司名称//1
                    company.Type = this.Reader[2].ToString(); //单位类别//2
                    company.SpellCode = this.Reader[3].ToString();//拼音码//3
                    company.WBCode = this.Reader[4].ToString();//五笔码//4
                    company.RelationCollection.Email = this.Reader[5].ToString(); //邮件地址//5
                    company.RelationCollection.Phone = this.Reader[6].ToString();//电话号码/6
                    company.OpenAccounts = this.Reader[7].ToString(); //银行帐号7
                    company.RelationCollection.LinkMan.Name = this.Reader[8].ToString();//公司联系人8
                    company.RelationCollection.Address = this.Reader[9].ToString(); //单位地址9
                    company.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[10].ToString()); //有效标志10
                    company.Oper.Name = this.Reader[11].ToString(); //操作员11
                    company.Oper.ID = this.Reader[12].ToString();//操作员编码12
                    company.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[13].ToString()); //操作时间13
                    company.RelationCollection.FaxCode = this.Reader[14].ToString();//传真
                    company.Memo = this.Reader[15].ToString();//备注
                    company.User01 = this.Reader[16].ToString(); //手机号
                    al.Add(company);
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
        #endregion

        #region 修改一行数据
        /// <summary>
        /// 修改一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        protected int UpdateInfo(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Exami.Company.UpdateInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Exami.Company.UpdateInfo字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmItem(company);     //取参数列表
                //strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
                return this.ExecNoQuery(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Exami.Company.UpdateInfo:" + ex.Message;
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
        private string[] myGetParmItem(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            string IsValid = "0";
            if (company.IsValid)
            {
                IsValid = "1";
            }
            string[] strParm ={	company.ID,  //公司编码 //0 
								company.Name ,//公司名称//1
								company.Type , //单位类别//2
								company.SpellCode  ,//拼音码//3
								company.WBCode ,//五笔码//4
								company.RelationCollection.Email , //邮件地址//5
								company.RelationCollection.Phone ,//电话号码/6
								company.OpenAccounts , //银行帐号7
								company.RelationCollection.LinkMan.Name,//公司联系人8
								company.RelationCollection.Address , //单位地址9
								IsValid , //有效标志10
								company.Oper.ID ,//操作员编码11
							    company.RelationCollection.FaxCode ,//传真12
					            company.Memo,//13
								company.User01 // 手机号
							 };
            return strParm;
        }

        #endregion

        #endregion 
    }
}
