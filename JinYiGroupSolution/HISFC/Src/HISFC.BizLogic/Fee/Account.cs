using System;
using System.Collections.Generic;
using System.Data;
using Neusoft.FrameWork.Models;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Account;

namespace Neusoft.HISFC.BizLogic.Fee
{
    /// <summary>
    /// ReturnApply<br></br>
    /// [功能描述: 帐户管理]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2007-10-01]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Account : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Account()
        { }

        #region 变量
        /// <summary>
        /// 根据卡规则读取卡号和卡类型
        /// </summary>
        private static IReadMarkNO IreadMarkNO = null;
        #endregion

        #region 私有方法
        /// <summary>
        /// 提取卡信息
        /// </summary>
        /// <param name="Sql">sql语句</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Account.AccountCard GetAccountCardInfo(string Sql)
        {
            Neusoft.HISFC.Models.Account.AccountCard accountCard = null;
            try
            {
                if (this.ExecQuery(Sql) == -1) return null;
                while (this.Reader.Read())
                {
                    accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                    accountCard.Patient.PID.CardNO = Reader[0].ToString();
                    accountCard.MarkNO = Reader[1].ToString();
                    accountCard.MarkType.ID = Reader[2].ToString();
                    accountCard.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[3]);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return accountCard;
        }
        
        /// <summary>
        /// 更新单表(update、insert)
        /// </summary>
        /// <param name="sqlIndex">sql索引</param>
        /// <param name="args">where条件参数</param>
        /// <returns>1成功 -1失败 0没有更新到记录</returns>
        private int UpdateSingTable(string sqlIndex,params string[] args)
        {
            string strSql = string.Empty;
            if (this.Sql.GetSql(sqlIndex, ref strSql) == -1)
            {
                this.Err = "查找索引为" + sqlIndex + "的Sql语句失败！";
                return -1;
            }
            return this.ExecNoQuery(strSql, args);
        }
        
        /// <summary>
        /// 预交金属性字符串数组
        /// </summary>
        /// <param name="prePay"></param>
        /// <returns></returns>
        private string[] GetPrePayArgs(PrePay prePay)
        {
            string[] args = new string[] {
                                            prePay.Patient.PID.CardNO,//病历卡号
                                            prePay.HappenNO.ToString(),//发生序号
                                            prePay.Patient.Name,//患者姓名
                                            prePay.InvoiceNO,//发票号
                                            prePay.PayType.ID.ToString(),//支付方式
                                            prePay.FT.PrepayCost.ToString(),//预交金额
                                            prePay.Bank.Name,//开户银行
                                            prePay.Bank.Account,//开户帐户
                                            prePay.Bank.InvoiceNO,//pos交易流水号或支票号或汇票号
                                            NConvert.ToInt32(prePay.IsValid).ToString(),//0未日结/1已日结
                                            prePay.BalanceNO,//日结序号
                                            prePay.BalanceOper.ID,//日结人
                                            prePay.BalanceOper.OperTime.ToString(),// 日结时间
                                            ((int)prePay.ValidState).ToString(),//预交金状态
                                            prePay.PrintTimes.ToString(),//重打次数
                                            prePay.OldInvoice,//原票据号
                                            prePay.PrePayOper.ID, //操作员
                                            prePay.AccountNO, //帐号
                                            NConvert.ToInt32(prePay.IsHostory).ToString(),//是否历史数据
                                            prePay.Bank.WorkName ,//开户单位
                                            prePay.FT.DerateCost.ToString() //优惠金额
                                        };
            return args;
        }

        /// <summary>
        /// 查找患者就诊卡
        /// </summary>
        /// <param name="whereIndex"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private List<AccountCard> GetAccountMarkList(string whereIndex, params string[] args)
        {
            List<Neusoft.HISFC.Models.Account.AccountCard> list = new List<Neusoft.HISFC.Models.Account.AccountCard>();
            try
            {
                string Sql = string.Empty;
                string SqlWhere = string.Empty;
                if (this.Sql.GetSql("Fee.Account.SelectAccountCard", ref Sql) == -1) return null;
                if (this.Sql.GetSql(whereIndex, ref SqlWhere) == -1) return null;
                SqlWhere = string.Format(SqlWhere, args);
                Sql += " " + SqlWhere;
                if (this.ExecQuery(Sql) == -1) return null;
                Neusoft.HISFC.Models.Account.AccountCard accountCard = null;

                while (this.Reader.Read())
                {
                    accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                    accountCard.Patient.PID.CardNO = Reader[0].ToString();
                    accountCard.MarkNO = Reader[1].ToString();
                    accountCard.MarkType.ID = Reader[2].ToString();
                    accountCard.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[3]);
                    list.Add(accountCard);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            finally
            {
                if (!this.Reader.IsClosed && this.Reader != null)
                {
                    this.Reader.Close();
                }
            }
            return list;
        }
        
        /// <summary>
        /// 初始化动态库
        /// </summary>
        /// <returns></returns>
        private bool InitReadMark()
        {
            if (IreadMarkNO == null)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(@"./ReadMarkNO.dll");
                if (assembly == null) return false;
                Type[] vType = assembly.GetTypes();
                foreach (Type type in vType)
                {
                    if (type.GetInterface("IReadMarkNO") != null)
                    {
                        System.Runtime.Remoting.ObjectHandle obj = System.Activator.CreateInstance(type.Assembly.ToString(), type.FullName);
                        IreadMarkNO = obj.Unwrap() as IReadMarkNO;
                        break;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 查找患者信息
        /// </summary>
        /// <param name="Sql">WhereSql语句的索引</param>
        /// <param name="args">Where条件参数</param>
        /// <returns>null失败</returns>
        private List<Neusoft.HISFC.Models.RADT.PatientInfo> GetPatient(string Sql)
        {
            try
            {
                if (this.ExecQuery(Sql) == -1) return null;
                List<Neusoft.HISFC.Models.RADT.PatientInfo> list = new List<Neusoft.HISFC.Models.RADT.PatientInfo>();
                Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = null;
                while (this.Reader.Read())
                {
                    PatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    #region 患者信息
                    if (!Reader.IsDBNull(0)) PatientInfo.PID.CardNO = Reader[0].ToString(); //就诊卡号
                    if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); //姓名
                    if (!Reader.IsDBNull(2)) PatientInfo.SpellCode = Reader[2].ToString(); //拼音码
                    if (!Reader.IsDBNull(3)) PatientInfo.WBCode = Reader[3].ToString(); //五笔
                    if (!Reader.IsDBNull(4)) PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString()); //出生日期
                    if (!Reader.IsDBNull(5)) PatientInfo.Sex.ID = Reader[5].ToString(); //性别
                    if (!Reader.IsDBNull(6)) PatientInfo.IDCard = Reader[6].ToString(); //身份证号
                    if (!Reader.IsDBNull(7)) PatientInfo.BloodType.ID = Reader[7].ToString(); //血型
                    if (!Reader.IsDBNull(8)) PatientInfo.Profession.ID = Reader[8].ToString(); //职业
                    if (!Reader.IsDBNull(9)) PatientInfo.CompanyName = Reader[9].ToString(); //工作单位
                    if (!Reader.IsDBNull(10)) PatientInfo.PhoneBusiness = Reader[10].ToString(); //单位电话
                    if (!Reader.IsDBNull(11)) PatientInfo.BusinessZip = Reader[11].ToString(); //单位邮编
                    if (!Reader.IsDBNull(12)) PatientInfo.AddressHome = Reader[12].ToString(); //户口或家庭所在
                    if (!Reader.IsDBNull(13)) PatientInfo.PhoneHome = Reader[13].ToString(); //家庭电话
                    if (!Reader.IsDBNull(14)) PatientInfo.HomeZip = Reader[14].ToString(); //户口或家庭邮政编码
                    if (!Reader.IsDBNull(15)) PatientInfo.DIST = Reader[15].ToString(); //籍贯
                    if (!Reader.IsDBNull(16)) PatientInfo.Nationality.ID = Reader[16].ToString(); //民族
                    if (!Reader.IsDBNull(17)) PatientInfo.Kin.Name = Reader[17].ToString(); //联系人姓名
                    if (!Reader.IsDBNull(18)) PatientInfo.Kin.RelationPhone = Reader[18].ToString(); //联系人电话
                    if (!Reader.IsDBNull(19)) PatientInfo.Kin.RelationAddress = Reader[19].ToString(); //联系人住址
                    if (!Reader.IsDBNull(20)) PatientInfo.Kin.Relation.ID = Reader[20].ToString(); //联系人关系
                    if (!Reader.IsDBNull(21)) PatientInfo.MaritalStatus.ID = Reader[21].ToString(); //婚姻状况
                    if (!Reader.IsDBNull(22)) PatientInfo.Country.ID = Reader[22].ToString(); //国籍
                    if (!Reader.IsDBNull(23)) PatientInfo.Pact.PayKind.ID = Reader[23].ToString(); //结算类别
                    if (!Reader.IsDBNull(24)) PatientInfo.Pact.PayKind.Name = Reader[24].ToString(); //结算类别名称
                    if (!Reader.IsDBNull(25)) PatientInfo.Pact.ID = Reader[25].ToString(); //合同代码
                    if (!Reader.IsDBNull(26)) PatientInfo.Pact.Name = Reader[26].ToString(); //合同单位名称
                    if (!Reader.IsDBNull(27)) PatientInfo.SSN = Reader[27].ToString(); //医疗证号
                    if (!Reader.IsDBNull(28)) PatientInfo.AreaCode = Reader[28].ToString(); //地区
                    if (!Reader.IsDBNull(29)) PatientInfo.FT.TotCost = NConvert.ToDecimal(Reader[29].ToString()); //医疗费用
                    if (!Reader.IsDBNull(30)) PatientInfo.Card.ICCard.ID = Reader[30].ToString(); //电脑号
                    if (!Reader.IsDBNull(31)) PatientInfo.Disease.IsAlleray = NConvert.ToBoolean(Reader[31].ToString()); //药物过敏
                    if (!Reader.IsDBNull(32)) PatientInfo.Disease.IsMainDisease = NConvert.ToBoolean(Reader[32].ToString()); //重要疾病
                    if (!Reader.IsDBNull(33)) PatientInfo.Card.NewPassword = Reader[33].ToString(); //帐户密码
                    if (!Reader.IsDBNull(34)) PatientInfo.Card.NewAmount = NConvert.ToDecimal(Reader[34].ToString()); //帐户总额
                    if (!Reader.IsDBNull(35)) PatientInfo.Card.OldAmount = NConvert.ToDecimal(Reader[35].ToString()); //上期帐户余额
                    if (!Reader.IsDBNull(47)) PatientInfo.Memo = Reader[47].ToString(); //备注
                    if (!Reader.IsDBNull(48)) PatientInfo.User01 = Reader[48].ToString(); //操作员
                    if (!Reader.IsDBNull(49)) PatientInfo.User02 = Reader[49].ToString(); //操作日期
                    if (!Reader.IsDBNull(50)) PatientInfo.IsEncrypt = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[50].ToString());//是否加密
                    if (!Reader.IsDBNull(51)) PatientInfo.NormalName = Reader[51].ToString(); //密文
                    if (!Reader.IsDBNull(52)) PatientInfo.IDCardType.ID = Reader[52].ToString();//证件类型
                    //if (!Reader.IsDBNull(53)) PatientInfo.VipFlag = NConvert.ToBoolean(Reader[53]);//vip标识
                    //if (!Reader.IsDBNull(54)) PatientInfo.MatherName = Reader[54].ToString();//母亲姓名
                    //if (!Reader.IsDBNull(55)) PatientInfo.IsTreatment = NConvert.ToBoolean(Reader[55]);//是否急诊
                    if (!Reader.IsDBNull(56)) PatientInfo.PID.CaseNO = Reader[56].ToString();//病案号
                    #endregion
                    list.Add(PatientInfo);
                }
                return list;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                if (!this.Reader.IsClosed && this.Reader != null)
                {
                    this.Reader.Close();
                }
            }
        }

        //{63F68506-F49D-4ed5-92BD-28A52AF54626}
        /// <summary>
        /// 查找患者信息
        /// </summary>
        /// <param name="Sql">WhereSql语句的索引</param>
        /// <returns>null失败</returns>
        private List<Neusoft.HISFC.Models.Account.AccountCard> GetAccountCardList(string Sql)
        {
            try
            {
                if (this.ExecQuery(Sql) == -1) return null;
                List<Neusoft.HISFC.Models.Account.AccountCard> list = new List<AccountCard>();
                Neusoft.HISFC.Models.Account.AccountCard accountCard = null;
                while (this.Reader.Read())
                {
                    accountCard = new AccountCard();
                    #region 患者信息
                    if (!Reader.IsDBNull(0)) accountCard.Patient.PID.CardNO = Reader[0].ToString(); //就诊卡号
                    if (!Reader.IsDBNull(1)) accountCard.Patient.Name = Reader[1].ToString(); //姓名
                    if (!Reader.IsDBNull(2)) accountCard.Patient.SpellCode = Reader[2].ToString(); //拼音码
                    if (!Reader.IsDBNull(3)) accountCard.Patient.WBCode = Reader[3].ToString(); //五笔
                    if (!Reader.IsDBNull(4)) accountCard.Patient.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString()); //出生日期
                    if (!Reader.IsDBNull(5)) accountCard.Patient.Sex.ID = Reader[5].ToString(); //性别
                    if (!Reader.IsDBNull(6)) accountCard.Patient.IDCard = Reader[6].ToString(); //身份证号
                    if (!Reader.IsDBNull(7)) accountCard.Patient.BloodType.ID = Reader[7].ToString(); //血型
                    if (!Reader.IsDBNull(8)) accountCard.Patient.Profession.ID = Reader[8].ToString(); //职业
                    if (!Reader.IsDBNull(9)) accountCard.Patient.CompanyName = Reader[9].ToString(); //工作单位
                    if (!Reader.IsDBNull(10)) accountCard.Patient.PhoneBusiness = Reader[10].ToString(); //单位电话
                    if (!Reader.IsDBNull(11)) accountCard.Patient.BusinessZip = Reader[11].ToString(); //单位邮编
                    if (!Reader.IsDBNull(12)) accountCard.Patient.AddressHome = Reader[12].ToString(); //户口或家庭所在
                    if (!Reader.IsDBNull(13)) accountCard.Patient.PhoneHome = Reader[13].ToString(); //家庭电话
                    if (!Reader.IsDBNull(14)) accountCard.Patient.HomeZip = Reader[14].ToString(); //户口或家庭邮政编码
                    if (!Reader.IsDBNull(15)) accountCard.Patient.DIST = Reader[15].ToString(); //籍贯
                    if (!Reader.IsDBNull(16)) accountCard.Patient.Nationality.ID = Reader[16].ToString(); //民族
                    if (!Reader.IsDBNull(17)) accountCard.Patient.Kin.Name = Reader[17].ToString(); //联系人姓名
                    if (!Reader.IsDBNull(18)) accountCard.Patient.Kin.RelationPhone = Reader[18].ToString(); //联系人电话
                    if (!Reader.IsDBNull(19)) accountCard.Patient.Kin.RelationAddress = Reader[19].ToString(); //联系人住址
                    if (!Reader.IsDBNull(20)) accountCard.Patient.Kin.Relation.ID = Reader[20].ToString(); //联系人关系
                    if (!Reader.IsDBNull(21)) accountCard.Patient.MaritalStatus.ID = Reader[21].ToString(); //婚姻状况
                    if (!Reader.IsDBNull(22)) accountCard.Patient.Country.ID = Reader[22].ToString(); //国籍
                    if (!Reader.IsDBNull(23)) accountCard.Patient.Pact.PayKind.ID = Reader[23].ToString(); //结算类别
                    if (!Reader.IsDBNull(24)) accountCard.Patient.Pact.PayKind.Name = Reader[24].ToString(); //结算类别名称
                    if (!Reader.IsDBNull(25)) accountCard.Patient.Pact.ID = Reader[25].ToString(); //合同代码
                    if (!Reader.IsDBNull(26)) accountCard.Patient.Pact.Name = Reader[26].ToString(); //合同单位名称
                    if (!Reader.IsDBNull(27)) accountCard.Patient.SSN = Reader[27].ToString(); //医疗证号
                    if (!Reader.IsDBNull(28)) accountCard.Patient.AreaCode = Reader[28].ToString(); //地区
                    if (!Reader.IsDBNull(29)) accountCard.Patient.FT.TotCost = NConvert.ToDecimal(Reader[29].ToString()); //医疗费用
                    if (!Reader.IsDBNull(30)) accountCard.Patient.Card.ICCard.ID = Reader[30].ToString(); //电脑号
                    if (!Reader.IsDBNull(31)) accountCard.Patient.Disease.IsAlleray = NConvert.ToBoolean(Reader[31].ToString()); //药物过敏
                    if (!Reader.IsDBNull(32)) accountCard.Patient.Disease.IsMainDisease = NConvert.ToBoolean(Reader[32].ToString()); //重要疾病
                    if (!Reader.IsDBNull(33)) accountCard.Patient.Card.NewPassword = Reader[33].ToString(); //帐户密码
                    if (!Reader.IsDBNull(34)) accountCard.Patient.Card.NewAmount = NConvert.ToDecimal(Reader[34].ToString()); //帐户总额
                    if (!Reader.IsDBNull(35)) accountCard.Patient.Card.OldAmount = NConvert.ToDecimal(Reader[35].ToString()); //上期帐户余额
                    if (!Reader.IsDBNull(47)) accountCard.Patient.Memo = Reader[47].ToString(); //备注
                    if (!Reader.IsDBNull(48)) accountCard.Patient.User01 = Reader[48].ToString(); //操作员
                    if (!Reader.IsDBNull(49)) accountCard.Patient.User02 = Reader[49].ToString(); //操作日期
                    if (!Reader.IsDBNull(50)) accountCard.Patient.IsEncrypt = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[50].ToString());//是否加密
                    if (!Reader.IsDBNull(51)) accountCard.Patient.NormalName = Reader[51].ToString(); //密文
                    if (!Reader.IsDBNull(52)) accountCard.Patient.IDCardType.ID = Reader[52].ToString();//证件类型
                    //if (!Reader.IsDBNull(53)) accountCard.Patient.VipFlag = NConvert.ToBoolean(Reader[53]);//vip标识
                    //if (!Reader.IsDBNull(54)) accountCard.Patient.MatherName = Reader[54].ToString();//母亲姓名
                    //if (!Reader.IsDBNull(55)) accountCard.Patient.IsTreatment = NConvert.ToBoolean(Reader[55]);//是否急诊
                    if (!Reader.IsDBNull(56)) accountCard.Patient.PID.CaseNO = Reader[56].ToString();//病案号
                    if (!Reader.IsDBNull(57)) accountCard.MarkNO = this.Reader[57].ToString(); //就诊卡号
                    if (!Reader.IsDBNull(58)) accountCard.MarkType.ID = this.Reader[58].ToString(); //卡类型
                    #endregion
                    list.Add(accountCard);
                }
                return list;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                if (!this.Reader.IsClosed && this.Reader != null)
                {
                    this.Reader.Close();
                }
            }
        }

        /// <summary>
        /// 查找帐户信息
        /// </summary>
        /// <param name="whereIndex">where条件索引</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Account.Account GetAccount(string whereIndex, params string[] args)
        {
            string sqlStr = string.Empty;
            string sqlWhere = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectAccount", ref sqlStr) == -1)
            {
                this.Err = "查找索引为Fee.Account.SelectAccount的sql语句失败！";
                return null;
            }
            if (this.Sql.GetSql(whereIndex, ref sqlWhere) == -1)
            {
                this.Err = "查找索引为" + whereIndex + "的sql语句失败！";
                return null;
            }
            sqlStr += " " + sqlWhere;
            Neusoft.HISFC.Models.Account.Account account = null;
            try
            {
                sqlStr = string.Format(sqlStr, args);
                if (this.ExecQuery(sqlStr) == -1)
                {
                    this.Err = "查找数据失败！";
                    return null; ;
                }
                while (this.Reader.Read())
                {
                    account = new Neusoft.HISFC.Models.Account.Account();
                    account.CardNO = this.Reader[0].ToString();
                    if (this.Reader[1] != DBNull.Value) account.ValidState = (HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[1]));
                    if (this.Reader[2] != DBNull.Value) account.Vacancy = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2]);
                    if (this.Reader[3] != DBNull.Value) account.PassWord = HisDecrypt.Decrypt(this.Reader[3].ToString());
                    if (this.Reader[4] != DBNull.Value) account.DayLimit = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4]);
                    account.ID = this.Reader[5].ToString();
                    account.IsEmpower = NConvert.ToBoolean(this.Reader[6]);
                }
                return account;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                if (this.Reader != null && !this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
            }
            
        }

        /// <summary>
        /// 查找帐户信息
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Account.Account GetAccount(string sqlStr)
        {
            Neusoft.HISFC.Models.Account.Account account = null;
            if (this.ExecQuery(sqlStr) == -1)
            {
                this.Err = "查找数据失败！";
                return null; ;
            }
            try
            {
                while (this.Reader.Read())
                {
                    account = new Neusoft.HISFC.Models.Account.Account();
                    account.CardNO = this.Reader[0].ToString();
                    if (this.Reader[1] != DBNull.Value) account.ValidState = (HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[1]));
                    if (this.Reader[2] != DBNull.Value) account.Vacancy = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2]);
                    if (this.Reader[3] != DBNull.Value) account.PassWord = HisDecrypt.Decrypt(this.Reader[3].ToString());
                    if (this.Reader[4] != DBNull.Value) account.DayLimit = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4]);
                    account.ID = this.Reader[5].ToString();
                    account.IsEmpower = NConvert.ToBoolean(this.Reader[6]);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return account;
        }
       
        /// <summary>
        /// 查找帐户预交金信息
        /// </summary>
        /// <param name="whereIndex">WhereSql语句的索引</param>
        /// <param name="args">Where条件参数</param>
        /// <returns>null 失败</returns>
        private List<PrePay> GetPrePayList(string whereIndex, params string[] args)
        {
            string sqlstr = string.Empty;
            string sqlwhere = string.Empty;
            if (this.Sql.GetSql("Fee.Account.GetPrePayRecrod", ref sqlstr) < 0)
            {
                this.Err = "索引为Fee.Account.GetPrePayRecrod的SQL语句不存在！";
                return null;
            }
            if (this.Sql.GetSql(whereIndex, ref sqlwhere) < 0)
            {
                this.Err = "索引为" + whereIndex + "的SQL语句不存在！";
                return null;
            }
            sqlstr += " " + sqlwhere;
            if (this.ExecQuery(sqlstr,args) < 0) return null;
            List<PrePay> list = new List<PrePay>();
            PrePay prepay = null;
            try
            {
                while (this.Reader.Read())
                {
                    prepay = new PrePay();
                    prepay.Patient.PID.CardNO = this.Reader[0].ToString(); //门诊卡号
                    prepay.HappenNO = NConvert.ToInt32(this.Reader[1]); //发生序号
                    prepay.Patient.Name = this.Reader[2].ToString(); //患者姓名
                    prepay.InvoiceNO = this.Reader[3].ToString();//票据号
                    prepay.PayType.ID = this.Reader[4].ToString();//支付方式
                    prepay.FT.PrepayCost = NConvert.ToDecimal(this.Reader[5]); //预交金
                    prepay.Bank.Name = this.Reader[6].ToString(); //银行
                    prepay.Bank.Account = this.Reader[7].ToString();//开户帐号
                    prepay.Bank.InvoiceNO = this.Reader[8].ToString();//开户帐号
                    prepay.IsValid = NConvert.ToBoolean(this.Reader[9]);//是否日结算
                    prepay.BalanceNO = this.Reader[10].ToString();//日结号
                    prepay.BalanceOper.ID = this.Reader[11].ToString(); //日结人
                    prepay.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[12]);//日结时间
                    prepay.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[13]); //状态
                    prepay.PrintTimes = NConvert.ToInt32(this.Reader[14]);//打印次数;
                    prepay.OldInvoice = this.Reader[15].ToString(); //原收据号
                    prepay.PrePayOper.ID = this.Reader[16].ToString();//操作员
                    prepay.PrePayOper.OperTime = NConvert.ToDateTime(this.Reader[17]);//操作时间
                    prepay.AccountNO = this.Reader[18].ToString();//账号
                    prepay.IsHostory = NConvert.ToBoolean(this.Reader[19].ToString());
                    prepay.Bank.WorkName = this.Reader[20].ToString();
                    list.Add(prepay);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                if (this.Reader != null && !this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
            }
            return list;
        }

        /// <summary>
        /// 查找帐户交易操作流水信息
        /// </summary>
        /// <param name="whereIndex"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private List<AccountRecord> GetAccountRecord(string whereIndex, params string[] args)
        {
            string Sql = string.Empty;
            string SqlWhere = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectAccountRecord", ref Sql) == -1)
            {
                this.Err = "提取SQL语句出错！";
                return null;
            }
            if (this.Sql.GetSql(whereIndex, ref SqlWhere) == -1)
            {
                this.Err = "提取SQL语句出错！";
                return null;
            }

            try
            {
                SqlWhere = string.Format(SqlWhere, args);
                Sql += " " + SqlWhere;
                if (this.ExecQuery(Sql) == -1)
                {
                    this.Err = "查找帐户交易数据失败！";
                    return null;
                }
                List<Neusoft.HISFC.Models.Account.AccountRecord> list = new List<Neusoft.HISFC.Models.Account.AccountRecord>();
                Neusoft.HISFC.Models.Account.AccountRecord accountRecord = null;
                while (this.Reader.Read())
                {
                    accountRecord = new Neusoft.HISFC.Models.Account.AccountRecord();
                    accountRecord.Patient.PID.CardNO = Reader[0].ToString();
                    accountRecord.AccountNO = Reader[1].ToString();
                    accountRecord.OperType.ID = Reader[2].ToString();
                    if (Reader[2] != DBNull.Value) accountRecord.Money = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[3]);
                    accountRecord.DeptCode = Reader[4].ToString();
                    accountRecord.Oper = Reader[5].ToString();
                    accountRecord.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[6]);
                    if (Reader[5] != DBNull.Value) accountRecord.ReMark = Reader[7].ToString();
                    accountRecord.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[8]);
                    if (Reader[8] != DBNull.Value) accountRecord.Vacancy = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[9]);
                    if (Reader[8] != DBNull.Value) accountRecord.EmpowerPatient.PID.CardNO = this.Reader[10].ToString();
                    if (Reader[8] != DBNull.Value) accountRecord.EmpowerPatient.Name = this.Reader[11].ToString();
                    accountRecord.EmpowerCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12]);
                    accountRecord.InvoiceType.ID = this.Reader[13].ToString();
                    list.Add(accountRecord);
                }
                this.Reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 授权实体属性字符串数组
        /// </summary>
        /// <param name="accountEmpower"></param>
        /// <returns></returns>
        private string[] GetEmpowerArgs(AccountEmpower accountEmpower)
        {
            string[] args = new string[] {accountEmpower.AccountCard.Patient.PID.CardNO,
                                          accountEmpower.AccountCard.Patient.Name,  
                                          accountEmpower.AccountNO,
                                          accountEmpower.AccountCard.MarkNO,  
                                          accountEmpower.AccountCard.MarkType.ID,
                                          accountEmpower.EmpowerCard.Patient.PID.CardNO, 
                                          accountEmpower.EmpowerCard.Patient.Name,
                                          accountEmpower.EmpowerCard.MarkNO,  
                                          accountEmpower.EmpowerCard.MarkType.ID,
                                          accountEmpower.EmpowerLimit.ToString(),
                                          Neusoft.HisDecrypt.Encrypt(accountEmpower.PassWord),
                                          accountEmpower.Oper.ID,
                                          accountEmpower.Vacancy.ToString(),
                                          (NConvert.ToInt32(accountEmpower.ValidState)).ToString()
                                          };
            return args;
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private List<AccountEmpower> GetEmpowerList(string whereIndex,params string[] args)
        {
            string sql = string.Empty;
            string sqlwhere = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectEmpower", ref sql) < 0)
            {
                this.Err = "查找索引为Fee.Account.SelectEmpower的SQL语句失败！";
                return null;
            }
            if (this.Sql.GetSql(whereIndex, ref sqlwhere) < 0)
            {
                this.Err = "查找索引为" + whereIndex + "的SQL语句失败！";
                return null;
            }
            sql += " " + string.Format(sqlwhere, args);
            if (this.ExecQuery(sql) < 0) return null;
            List<AccountEmpower> list = new List<AccountEmpower>();
            AccountEmpower obj = null;
            try
            {
                while (this.Reader.Read())
                {
                    obj = new AccountEmpower();
                    obj.AccountCard.Patient.PID.CardNO = this.Reader[0].ToString();
                    obj.AccountCard.Patient.Name = this.Reader[1].ToString();
                    obj.AccountNO = this.Reader[2].ToString();
                    obj.AccountCard.MarkNO = this.Reader[3].ToString();
                    obj.AccountCard.MarkType.ID = this.Reader[4].ToString();
                    obj.EmpowerCard.Patient.PID.CardNO = this.Reader[5].ToString();
                    obj.EmpowerCard.Patient.Name = this.Reader[6].ToString();
                    obj.EmpowerCard.MarkNO = this.Reader[7].ToString();
                    obj.EmpowerCard.MarkType.ID = this.Reader[8].ToString();
                    obj.EmpowerLimit = NConvert.ToDecimal(this.Reader[9]);
                    obj.PassWord = Neusoft.HisDecrypt.Decrypt(this.Reader[10].ToString());
                    obj.Oper.ID = this.Reader[11].ToString();
                    obj.Oper.OperTime = NConvert.ToDateTime(this.Reader[12]);
                    obj.Vacancy = NConvert.ToDecimal(this.Reader[13]);
                    obj.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[14]);
                    list.Add(obj);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            return list;
        }

        /// <summary>
        /// 得到帐户余额
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="vacancy">帐户余额</param>
        /// <param name="accountNO">账号</param>
        /// <returns>-1 失败 0是没有帐户或帐户停用或帐户已被注销 1成功</returns>
        private int GetAccountVacancy(string cardNO, ref decimal vacancy,ref string accountNO)
        {
            string Sql = string.Empty;
            bool isHaveVacancy = false;
            if (this.Sql.GetSql("Fee.Account.GetVacancy", ref Sql) == -1)
            {
                this.Err = "为找到SQL语句！";

                return -1;
            }
            try
            {
                if (this.ExecQuery(Sql, cardNO) == -1)
                {
                    return -1;
                }

                string state = string.Empty;

                while (this.Reader.Read())
                {
                    vacancy = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0]);
                    state = Reader[1].ToString();
                    accountNO = Reader[2].ToString();
                    isHaveVacancy = true;
                }
                this.Reader.Close();
                if (isHaveVacancy)
                {
                    if (state == "0")
                    {
                        this.Err = "该帐户已经停用";
                        return 0;
                    }
                    return 1;
                }
                else
                {
                    this.Err = "该患者未建立帐户或帐户已注销";
                    return 0;
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得帐户余额失败！" + ex.Message;

                return -1;
            }
        }

        /// <summary>
        /// 获取被授权患者余额
        /// </summary>
        /// <param name="empowerCardNO">被授权门诊卡号</param>
        /// <returns>1成功 0不存在可用的授权信息　-1不存在被授权信息</returns>
        private int GetEmpowerVacancy(string empowerCardNO, ref decimal vacancy,ref string accountNO)
        {
            AccountEmpower accountEmpower = new AccountEmpower();
            int resultValue = QueryAccountEmpowerByEmpwoerCardNO(empowerCardNO, ref accountEmpower);
            if (resultValue == 1)
            {
                vacancy = accountEmpower.Vacancy;
                accountNO = accountEmpower.AccountNO;
            }
            return resultValue;
        }

        #endregion

        #region 查询患者信息
        /// <summary>
        /// 查询患者信息
        /// </summary>
        /// <param name="cardNO">就诊卡号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfo(string markNO)
        {
            string strSql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectPatientByMarkNO", ref strSql) == -1) return null;
            strSql = string.Format(strSql, markNO);
            List<Neusoft.HISFC.Models.RADT.PatientInfo> list = this.GetPatient(strSql);
            if (list == null || list.Count == 0) return null;
            return list[0];
        }
        //{63F68506-F49D-4ed5-92BD-28A52AF54626}
        /// <summary>
        /// 查找患者信息
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="sex">性别</param>
        /// <param name="pact">合同单位</param>
        /// <param name="caseNO">病案号</param>
        /// <param name="idenType">证件类型</param>
        /// <param name="idenNo">证件号</param>
        /// <param name="ssNO">医疗证号</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Account.AccountCard> GetAccountCard(string name, string sex, string pact, string caseNO, string idenType, string idenNo,string ssNO)
        {

            string sqlWhere = string.Empty;
            bool isInput = false;
            if (name != null && name != string.Empty)
            {
                sqlWhere += " and t.NAME like '%" + name + "%' ";
                isInput = true;
            }
            if (sex != null && sex != string.Empty)
            {
                sqlWhere += " and t.SEX_CODE  = '" + sex + "' ";
                isInput = true;
            }
            if (pact != null && pact != string.Empty)
            {
                sqlWhere += " and t.PACT_CODE  = '" + pact + "' ";
                isInput = true;
            }

            if (caseNO != null && caseNO != string.Empty)
            {
                sqlWhere += " and t.CASE_NO = '" + caseNO + "' ";
                isInput = true;
            }
            if (idenType != null && idenType != string.Empty)
            {
                sqlWhere += " and t.IDCARDTYPE = '" + idenType + "' ";
                isInput = true;
            }
            if (idenNo != null && idenNo != string.Empty)
            {
                sqlWhere += " and t.IDENNO = '" + idenNo + "'";
                isInput = true;
            }
            if (!string.IsNullOrEmpty(ssNO))
            {
                sqlWhere += " and t.MCARD_NO = '" + ssNO + "'";
                isInput = true;
            }
            if (!isInput)
            {
                this.Err = "请输入患者信息！";
                return null;
            }
            string strSql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectPatient", ref strSql) == -1)
            {
                this.Err = "查找索引为Fee.Account.SelectPatient的Sql语句失败！";
                return null;
            }
            //sqlWhere = sqlWhere.Substring(0, sqlWhere.LastIndexOf("and") - 1);
            strSql += sqlWhere + " order by t.card_no";
            //List<Neusoft.HISFC.Models.RADT.PatientInfo> list = this.GetPatient(strSql);
            List<Neusoft.HISFC.Models.Account.AccountCard> list = GetAccountCardList(strSql);
            return list;
        }
       
        #endregion

        #region 帐户卡操作

        #region 插入卡操作记录
        /// <summary>
        /// 插入卡操作记录
        /// </summary>
        /// <param name="accountCardRecord">卡操作记录实体</param>
        /// <returns></returns>
        public int InsertAccountCardRecord(Neusoft.HISFC.Models.Account.AccountCardRecord accountCardRecord)
        {
            string[] args = null;
            try
            {
                args = new string[] { accountCardRecord.MarkNO,
                                accountCardRecord.MarkType.ID.ToString(),
                                accountCardRecord.CardNO,
                                accountCardRecord.OperateTypes.ID.ToString(),
                                accountCardRecord.Oper.ID.ToString(),
                                accountCardRecord.CardMoney.ToString()};
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return this.UpdateSingTable("Fee.Account.InsetAccountCardRecord",args);
        }

        #endregion

        #region 根据患者门诊卡号查找卡信息

        /// <summary>
        /// 查找就诊卡信息
        /// </summary>
        /// <param name="markNO">物理卡号</param>
        /// <param name="markType">卡类型</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Account.AccountCard GetAccountCard(string markNO, string markType)
        {
            List<AccountCard> list = this.GetAccountMarkList("Fee.Account.SelectAccountCardWhere3", markNO, markType);
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

        /// <summary>
        /// 查找就诊卡信息
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Account.AccountCard> GetMarkList(string cardNO)
        {
            return this.GetAccountMarkList("Fee.Account.SelectAccountCardWhere2", cardNO);

        }

        /// <summary>
        /// 查找就诊卡信息
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="state">状态 0停用　1在用</param>
        /// <returns></returns>
        public List<AccountCard> GetMarkList(string cardNO, bool state)
        {
            return this.GetAccountMarkList("Fee.Account.SelectAccountCardWhere4", cardNO, (NConvert.ToInt32(state)).ToString());
        }

        /// <summary>
        /// 查找就诊卡信息
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="markType">卡类型 All全部</param>
        /// <param name="state">状态 0停用 1在用 All全部</param>
        /// <returns></returns>
        public List<AccountCard> GetMarkList(string cardNO, string markType, string state)
        {
            //return this.GetMarkList("Fee.Account.SelectAccountCardWhere5", cardNO, markType, (NConvert.ToInt32(state)).ToString());
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectAccountMarkNO", ref sqlStr) == -1)
            {
                this.Err = "查找索引为Fee.Account.SelectAccountMarkNO的SQL语句失败！";
                return null;
            }
            List<AccountCard> list = new List<AccountCard>();
            AccountCard tempCard = null;
            try
            {
                sqlStr = string.Format(sqlStr,cardNO, markType, state);
                if (this.ExecQuery(sqlStr) == -1)
                {
                    this.Err = "查找数据失败！";
                    return null;
                }
                while(this.Reader.Read())
                {
                    tempCard = new AccountCard();
                    tempCard.Patient.PID.CardNO = this.Reader[0].ToString();
                    tempCard.MarkNO = this.Reader[1].ToString();
                    tempCard.MarkType.ID = this.Reader[2].ToString();
                    tempCard.IsValid = NConvert.ToBoolean(this.Reader[3]);
                    list.Add(tempCard);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查找数据失败！" + ex.Message;
                return null;
            }
            return list;
        }

        
        #endregion

        #region 插入门诊帐户卡数据
        /// <summary>
        /// 插入门诊帐户卡数据
        /// </summary>
        /// <param name="accountCard"></param>
        /// <returns></returns>
        public int InsertAccountCard(Neusoft.HISFC.Models.Account.AccountCard accountCard)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.InsertAccountCard", ref Sql) == -1) return -1;
            try
            {
                Sql = string.Format(Sql,
                                    accountCard.Patient.PID.CardNO, //门诊卡号
                                    accountCard.MarkNO,//身份标识卡号
                                    accountCard.MarkType.ID.ToString(),//身份标识卡类别 1磁卡 2IC卡 3保障卡
                                    Neusoft.FrameWork.Function.NConvert.ToInt32(accountCard.IsValid).ToString() //状态'1'正常'0'停用 
                                    );
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(Sql);
        }
        #endregion

        #region 更新卡状态
        /// <summary>
        /// 更新卡状态
        /// </summary>
        /// <param name="markNO">物理卡号</param>
        /// <param name="type">卡类型</param>
        /// <param name="valid">状态</param>
        /// <returns></returns>
        public int UpdateAccountCardState(string markNO,NeuObject markType, bool valid)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.UpdateAccountCardState", ref Sql) == -1) return -1;
            try
            {
                Sql = string.Format(Sql, markNO, NConvert.ToInt32(valid).ToString(), markType.ID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(Sql);

        }
        #endregion

        #region 查找卡使用记录
        /// <summary>
        /// 查找卡使用记录
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Account.AccountCardRecord> GetAccountCardRecord(string cardNO, string begin, string end)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectAccountCardRecord", ref Sql) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                Sql = string.Format(Sql, cardNO, begin, end);
                if (this.ExecQuery(Sql) == -1)
                {
                    this.Err = "查找卡使用数据失败！";
                    return null;
                }
                List<Neusoft.HISFC.Models.Account.AccountCardRecord> list = new List<Neusoft.HISFC.Models.Account.AccountCardRecord>();
                Neusoft.HISFC.Models.Account.AccountCardRecord accountCardRecord = null;
                while (this.Reader.Read())
                {
                    accountCardRecord = new Neusoft.HISFC.Models.Account.AccountCardRecord();
                    accountCardRecord.MarkNO = Reader[0].ToString();
                    accountCardRecord.MarkType.ID = Reader[1].ToString();
                    accountCardRecord.CardNO = Reader[2].ToString();
                    accountCardRecord.OperateTypes.ID = Reader[3];
                    accountCardRecord.Oper.ID = Reader[4].ToString();
                    accountCardRecord.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5]);
                    accountCardRecord.CardMoney = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[6]);
                    list.Add(accountCardRecord);
                }
                this.Reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        #endregion

        #region 删除卡数据
        /// <summary>
        /// 删除卡数据
        /// </summary>
        /// <param name="markNO">卡号</param>
        /// <param name="markType">卡类型</param>
        /// <returns></returns>
        public int DeleteAccoutCard(string markNO, string markType)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.DeleteAccountCard", ref Sql) == -1) return -1;
            try
            {
                Sql = string.Format(Sql, markNO, markType);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(Sql);
        }

        #endregion

        #region 帐户换卡
        /// <summary>
        /// 帐户换卡
        /// </summary>
        /// <param name="newMark">新卡号</param>
        /// <param name="oldMark">原</param>
        /// <returns></returns>
        public int UpdateAccountCardMark(string newMark, string oldMark)
        {
            return this.UpdateSingTable("Fee.Account.UpdateAccountCardMarkNo", newMark, oldMark);
        }

        #endregion

        #region 根据卡号规则读出卡号
        ///// <summary>
        ///// 根据卡号规则读出卡号
        ///// </summary>
        ///// <param name="markNo">输入的卡号</param>
        ///// <param name="validedMarkNo"></param>
        ///// <returns></returns>
        //public int ValidMarkNO(string markNo, ref string validedMarkNo)
        //{
        //    string firstleter = markNo.Substring(0, 1);
        //    string lastleter = markNo.Substring(markNo.Length - 1, 1);
        //    if (firstleter != ";")
        //    {
        //        this.Err = "请输入正确的卡号！";
        //        return -1;
        //    }
        //    if (lastleter != "?")
        //    {
        //        this.Err = "请输入正确的卡号！";
        //        return -1;
        //    }
        //    validedMarkNo = markNo.Substring(1, markNo.Length - 2);
        //    if (!Neusoft.FrameWork.Public.String.IsNumeric(validedMarkNo))
        //    {
        //        this.Err = "请输入正确的卡号！";
        //        return -1;
        //    }
        //    return 1;
        //}
        #endregion

        #endregion

        #region 帐户交易数据操作

        #region 帐户预交金
       /// <summary>
        /// 帐户预交金
       /// </summary>
       /// <param name="accountRecord">交易实体</param>
       /// <param name="aMod">1收取 0反还</param>
       /// <returns></returns>
        public bool AccountPrePayManager(PrePay prePay,int aMode)
        {
            try
            {
                DateTime dtNow = this.GetDateTimeFromSysDateTime();
                //反还
                if (aMode == 0)
                {
                    prePay.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
                    prePay.FT.PrepayCost = -prePay.FT.PrepayCost;
                    prePay.FT.DerateCost = -prePay.FT.DerateCost;
                    prePay.OldInvoice = prePay.InvoiceNO;
                    prePay.PrePayOper.ID = this.Operator.ID;
                    prePay.PrePayOper.OperTime = dtNow;
                    if (UpdatePrePayState(prePay) < 1)
                    {
                        this.Err = this.Err + "该条记录已经进行过返还补打操作，更新状态出错!";
                        return false;
                    }
                }

                if (this.InsertPrePay(prePay) < 0)
                {
                    this.Err = "插入预交金数据失败！";
                    return false;
                }

                #region 插入交易记录

                decimal vacancy = 0;
                int result = this.GetVacancy(prePay.Patient.PID.CardNO, ref vacancy);
                if (result <= 0)
                {
                    return false;
                }
                #region 交易实体
                AccountRecord accountRecord = new AccountRecord();
                accountRecord.Patient.PID.CardNO = prePay.Patient.PID.CardNO; //门诊卡号
                accountRecord.DeptCode = (Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID; //科室
                accountRecord.Oper = this.Operator.ID; //操作员
                accountRecord.OperTime = dtNow; //日期
                accountRecord.IsValid = true;//交易状态
                accountRecord.AccountNO = prePay.AccountNO;//帐号
                accountRecord.Name = prePay.Patient.Name;//姓名
                if (aMode == 0)
                {
                    accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.CancelPrePay;//操作类型

                }
                else
                {
                    accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.PrePay;//操作类型
                }
                accountRecord.Money = prePay.FT.PrepayCost + prePay.FT.DerateCost;//金额
                accountRecord.ReMark = prePay.InvoiceNO;//发票号
                accountRecord.Vacancy = vacancy + prePay.FT.PrepayCost + prePay.FT.DerateCost;//本次交易余额
                //accountRecord.Money = prePay.FT.PrepayCost;
                accountRecord.InvoiceType.ID = "A";
                #endregion
                if (this.InsertAccountRecord(accountRecord) < 0)
                {
                    return false;
                }
                #endregion

                #region 更新帐户余额
                //在计算帐户余额时是余额-本次交易的钱
                decimal consumeMoney = -accountRecord.Money;
                if (this.UpdateAccountVacancy(accountRecord.AccountNO, consumeMoney) < 0)
                {
                    return false;
                }

                #endregion

                return true;
            }
            catch(Exception ex)
            {
                this.Err = ex.Message;
                return false;
            }

        }

        /// <summary>
        /// 插入预交金数据
        /// </summary>
        /// <param name="prePay">预交金实体</param>
        /// <returns>1成功 -1失败</returns>
        public int InsertPrePay(PrePay prePay)
        {
            return this.UpdateSingTable("Fee.Account.InsertAccountPrePay", GetPrePayArgs(prePay));
        }

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 根据时间段查询预交金数据
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="isHistory">1历史数据 0当前数据 ALL全部数据</param>
        /// <returns>null失败</returns>
        public List<PrePay> GetPrepayByAccountNO(string accountNO, string isHistory)
        {
            return this.GetPrePayList("Fee.Account.GetPrePayWhere1", accountNO, isHistory);
        }


        /// <summary>
        /// 更新预交金状态 --更新为作废或补打状态
        /// </summary>
        /// <param name="prePay">预交金实体</param>
        /// <returns>1成功 -1失败 0没有更新记录</returns>
        public int UpdatePrePayState(PrePay prePay)
        {
            return this.UpdateSingTable("Fee.Account.UpdatePrePayState", prePay.AccountNO, prePay.HappenNO.ToString(), ((int)prePay.ValidState).ToString());
        }

        /// <summary>
        /// 更新帐户预交金历史数据状态
        /// </summary>
        /// <returns></returns>
        public int UpdatePrePayHistory(string accountNO,bool currentState,bool updateState)
        {
            return this.UpdateSingTable("Fee.Account.UpdateAccountPrePayHistoryState", accountNO, NConvert.ToInt32(currentState).ToString(), NConvert.ToInt32(updateState).ToString());
        }
        #endregion

        #region  通过物理卡号查找门诊卡号
        /// <summary>
        /// 通过物理卡号查找门诊卡号
        /// </summary>
        /// <param name="markNo">物理卡号</param>
        /// <param name="markType">卡类型</param>
        /// <param name="cardNo">门诊卡号</param>
        /// <returns>bool true 成功　false 失败</returns>
        public bool GetCardNoByMarkNo(string markNo,NeuObject markType, ref string cardNo)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectCardNoByMarkNo", ref Sql) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return false;
            }
            try
            {
                Sql = string.Format(Sql, markNo, markType.ID);
                if (this.ExecQuery(Sql) == -1)
                {
                    this.Err = "查找数据失败！";
                    return false;
                }
                #region Sql
                /*select b.card_no,
                           b.markno,
                           b.type,
                           b.state as cardstate,
                           a.state as accountstate,
                           a.vacancy 
                    from fin_opb_account a,fin_opb_accountcard b 
                    where a.card_no=b.card_no 
                      and b.markno='{0}' 
                      and type='{1}'*/
                #endregion
                Neusoft.HISFC.Models.Account.Account account = null;
                while (this.Reader.Read())
                {
                    account = new Neusoft.HISFC.Models.Account.Account();
                    account.AccountCard.Patient.PID.CardNO = this.Reader[0].ToString();
                    account.AccountCard.MarkNO = this.Reader[1].ToString();
                    account.AccountCard.MarkType.ID = Reader[2].ToString();
                    account.AccountCard.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3]);
                }
                this.Reader.Close();
                if (account == null)
                {
                    this.Err = "该卡" + markNo + "已被取消使用！";
                    return false;
                }
                if (!account.AccountCard.IsValid)
                {
                    this.Err = "该卡"+ markNo +"已被停止使用！";
                    return false;
                }
                cardNo = account.AccountCard.Patient.PID.CardNO;
                
                return true;
            }
            catch (Exception ex)
            {
                this.Err = "查找门诊卡号失败，" + ex.Message;
                return false;
            }

        }

        /// <summary>
        /// 通过物理卡号查找门诊卡号
        /// </summary>
        /// <param name="markNo">物理卡号</param>
        /// <param name="cardNo">门诊卡号</param>
        /// <returns>bool true 成功　false 失败</returns>
        public bool GetCardNoByMarkNo(string markNo,ref string cardNo)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectCardNoByMarkNo1", ref Sql) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return false;
            }
            try
            {
                Sql = string.Format(Sql, markNo);
                if (this.ExecQuery(Sql) == -1)
                {
                    this.Err = "查找数据失败！";
                    return false;
                }
                #region Sql
                /*select b.card_no,
                           b.markno,
                           b.type,
                           b.state as cardstate,
                           a.state as accountstate,
                           a.vacancy 
                    from fin_opb_account a,fin_opb_accountcard b 
                    where a.card_no=b.card_no 
                      and b.markno='{0}' 
                      and type='{1}'*/
                #endregion
                Neusoft.HISFC.Models.Account.Account account = null;
                while (this.Reader.Read())
                {
                    account = new Neusoft.HISFC.Models.Account.Account();
                    account.AccountCard.Patient.PID.CardNO = this.Reader[0].ToString();
                    account.AccountCard.MarkNO = this.Reader[1].ToString();
                    account.AccountCard.MarkType.ID = Reader[2].ToString();
                    account.AccountCard.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3]);
                }
                this.Reader.Close();
                if (account == null)
                {
                    this.Err = "该卡" + markNo + "已被取消使用！";
                    return false;
                }
                if (!account.AccountCard.IsValid)
                {
                    this.Err = "该卡"+ markNo +"已被停止使用！";
                    return false;
                }
                cardNo = account.AccountCard.Patient.PID.CardNO;
                
                return true;
            }
            catch (Exception ex)
            {
                this.Err = "查找门诊卡号失败，" + ex.Message;
                return false;
            }

        }

        #endregion

        /// <summary>
        /// 帐户支付、退费管理
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="money">金额</param>
        /// <param name="reMark">标识</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="aMod">0收费 1退费</param>
        /// <returns>true 成功 false失败</returns>
        public bool AccountPayManager(HISFC.Models.RADT.Patient patient, decimal money, string reMark,string invoiceType, string deptCode, int aMod)
        {
            //帐户余额，如果是帐户则是帐户余额；如果是授权信息则返回授权信息的余额
            decimal vacancy = 0m;
            //授权信息
            HISFC.Models.Account.AccountEmpower accountEmpower = null;
            //帐户信息
            HISFC.Models.Account.Account account = null;

            HISFC.Models.RADT.Patient tempPaient = new Neusoft.HISFC.Models.RADT.Patient();
            
            #region 查询余额
            //-1失败 0没有 帐户或授权信息 1帐户帐户 2授权信息
            int result = this.GetVacancy(patient.PID.CardNO, ref vacancy);
            if (result <= 0)
            {
                return false;
            }
            #endregion 

            #region 查询帐户信息
            if (result == 1)
            {
                //tempCardNO = patient.PID.CardNO;
                tempPaient = patient;
            }
            else
            {
                //获得授权信息
                int resultValue = this.QueryAccountEmpowerByEmpwoerCardNO(patient.PID.CardNO, ref accountEmpower);
                if (resultValue <= 0)
                {
                
                    return false;
                }
                tempPaient = accountEmpower.AccountCard.Patient;
            }
            account = this.GetAccountByCardNo(tempPaient.PID.CardNO);//获得帐户信息
            if (account == null)
            {
                this.Err = "该患者不存在有效帐户！";
                return false;
            }
            #endregion

            #region 判断判断
            //在收费的时候判断
            if (aMod == 0)
            {
                #region 支付操作判断帐户余额是否够
                if (vacancy < money)
                {
                    this.Err = Neusoft.FrameWork.Management.Language.Msg("余额" + vacancy.ToString() + "不足" + money.ToString() + "！");
                    return false;
                }
                //授权信息
                if (result == 2)
                {
                    //在授权信息的余额大于费用金额，但授权的帐户余额小于费用的金额给出提示
                    if (account.Vacancy < money)
                    {
                        this.Err = "授权帐户的余额为" + account.Vacancy.ToString() + "元，不足" + money.ToString() + "元";
                        return false;
                    }
                }
                #endregion
            }
            #endregion
            try
            {
                #region 生成交易记录
                //生成交易记录
                Neusoft.HISFC.Models.Account.AccountRecord accountRecord = new Neusoft.HISFC.Models.Account.AccountRecord();
                //形成交易记录
                accountRecord.Patient = tempPaient;
                accountRecord.AccountNO = account.ID;//帐号
                if (result == 1)
                {
                    if (aMod == 0)
                    {
                        accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.Pay;//操作类型
                    }
                    if (aMod == 1)
                    {
                        accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.CancelPay;//操作类型
                    }
                }
                else
                {
                    if (aMod == 0)
                    {
                        accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.EmpowerPay;//操作类型
                    }
                    if (aMod == 1)
                    {
                        accountRecord.OperType.ID = (int)Neusoft.HISFC.Models.Account.OperTypes.EmpowerCancelPay;//操作类型
                    }
                    //被授权患者实体
                    accountRecord.EmpowerPatient = accountEmpower.EmpowerCard.Patient;
                }
                accountRecord.Money = -money;//金额
                accountRecord.DeptCode = deptCode;//科室
                accountRecord.Oper = this.Operator.ID;//操作员
                accountRecord.OperTime = this.GetDateTimeFromSysDateTime();//操作时间
                accountRecord.ReMark = reMark;//发票号
                accountRecord.IsValid = true;//是否有效
                accountRecord.Vacancy = account.Vacancy - money;//本次交易余额
                accountRecord.InvoiceType.ID = invoiceType;
                //保存帐户交易记录
                if (this.InsertAccountRecord(accountRecord) == -1)
                {
                    this.Err = "插入交易数据失败！" + this.Err;
                    return false;
                }
                #endregion

                #region 更新余额
                //更新被是授权帐户的余额
                if (result == 2)
                {
                    
                    if (UpdateEmpowerVacancy(account.ID, patient.PID.CardNO, money) <= 0)
                    {
                        this.Err = "更新授权信息余额失败！";
                        return false;
                    }
                }
                //更新帐户余额
                if (UpdateAccountVacancy(account.ID, money) <= 0)
                {
                    this.Err = "更新帐户余额失败！";
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return false;
            }
            
            return true;
        }
        
        #region 查找帐户操作数据

        #region 根据门诊帐户、交易时间、操作状态查找帐户交易操作流水记录
        /// <summary>
        /// 根据门诊帐户、交易时间、操作状态查找帐户交易操作流水记录
        /// </summary>
        /// <param name="cardNO">门诊帐户</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="opertype">操作类型</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Account.AccountRecord> GetAccountRecordList(string cardNO, string begin, string end, string opertype)
        {
            return this.GetAccountRecord("Fee.Account.SelectAccountRecordWhere1", cardNO, begin, end, opertype);
        }
        #endregion

        #region  根据门诊帐户、交易时间查找帐户交易操作流水记录
        /// <summary>
        /// 根据门诊帐户、交易时间查找帐户交易操作流水记录
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Account.AccountRecord> GetAccountRecordList(string cardNO, string begin, string end)
        {
            return this.GetAccountRecord("Fee.Account.SelectAccountRecordWhere3", cardNO, begin, end);
        }

        #endregion


        #region 根据帐号以及操作类型查找帐户交易流水记录
        
        /// <summary>
        /// 根据帐号以及操作类型查找帐户交易流水记录
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="operType">操作记录</param>
        /// <returns></returns>
        public List<AccountRecord> GetAccountRecordList(string cardNO, string operType)
        {
            return this.GetAccountRecord("Fee.Account.SelectAccountRecordWhere4", cardNO, operType);
        }

        #endregion


        #region 根据门诊卡号、发票号查询交易记录
        /// <summary>
        /// 根据门诊卡号、发票号查询交易记录
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>交易实体</returns>
        private Neusoft.HISFC.Models.Account.AccountRecord GetAccountRecord(string cardNO, string invoiceNO)
        {
            string Sql = string.Empty;
            string SqlWhere = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectAccountRecord", ref Sql) == -1)
            {
                this.Err = "提取SQL语句出错！";
                return null;
            }
            if (this.Sql.GetSql("Fee.Account.SelectAccountRecordWhere2", ref SqlWhere) == -1)
            {
                this.Err = "提取SQL语句出错！";
                return null;
            }

            try
            {
                SqlWhere = string.Format(SqlWhere, cardNO, invoiceNO);
                Sql += " " + SqlWhere;
                if (this.ExecQuery(Sql) == -1)
                {
                    this.Err = "查找帐户交易数据失败！";
                    return null;
                }
                Neusoft.HISFC.Models.Account.AccountRecord accountRecord = null;
                while (this.Reader.Read())
                {
                    accountRecord = new Neusoft.HISFC.Models.Account.AccountRecord();
                    accountRecord.Patient.PID.CardNO = Reader[0].ToString();
                    accountRecord.OperType.ID = Reader[1].ToString();
                    if (Reader[2] != DBNull.Value) accountRecord.Money = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[2]);
                    accountRecord.DeptCode = Reader[3].ToString();
                    accountRecord.Oper = Reader[4].ToString();
                    accountRecord.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5]);
                    if (Reader[5] != DBNull.Value) accountRecord.ReMark = Reader[6].ToString();
                    accountRecord.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[7]);
                    if (Reader[8] != DBNull.Value) accountRecord.Vacancy = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8]);
                }
                this.Reader.Close();
                return accountRecord;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        #endregion

        #endregion

        #region 更新交易状态
        /// <summary>
        /// 更新交易状态
        /// </summary>
        /// <param name="valid">是否有效0有效1无效</param>
        /// <param name="cardNO">门诊帐号</param>
        /// <param name="operTime">操作时间</param>
        /// <returns></returns>
        public int UpdateAccountRecordState(string valid, string cardNO, string operTime, string remark)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.UpdateAccountRecordValid", ref Sql) == -1) return -1;
            try
            {
                Sql = string.Format(Sql, valid, cardNO, operTime, remark);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(Sql);
        }
        #endregion

        #region 帐户交易记录
        /// <summary>
        /// 卡费用信息交易记录
        /// </summary>
        /// <returns></returns>
        public int InsertAccountRecord(Neusoft.HISFC.Models.Account.AccountRecord accountRecord)
        {
            string[] args = new string[] {
                                  accountRecord.Patient.PID.CardNO, //门诊卡号
                                  accountRecord.OperType.ID.ToString(),//操作类型
                                  accountRecord.Money.ToString(), //金额
                                  accountRecord.DeptCode,//科室
                                  accountRecord.Oper,//操作人
                                  accountRecord.OperTime.ToString(),//操作时间
                                  accountRecord.ReMark, //备注
                                  Neusoft.FrameWork.Function.NConvert.ToInt32(accountRecord.IsValid).ToString(),//是否有效
                                  accountRecord.Vacancy.ToString(), //交易后余额
                                  accountRecord.AccountNO,//帐号
                                  accountRecord.EmpowerPatient.PID.CardNO, //被授权卡号
                                  accountRecord.EmpowerPatient.Name, //被授权人姓名
                                  accountRecord.Patient.Name,//授权人姓名
                                  accountRecord.EmpowerCost.ToString(),//授权金额
                                  accountRecord.InvoiceType.ID};//发票类型
            return this.UpdateSingTable("Fee.Account.InsertAccountRecord",args);
        }
        #endregion

        #region 根据发票号查找费用明细
        /// <summary>
        /// 根据发票号查找费用明细
        /// </summary>
        /// <param name="invoiceNO">发票类型</param>
        /// <param name="isQuite">是否退费</param>
        /// <returns></returns>
        public DataSet GetFeeDetailByInvoiceNO(string invoiceNO, bool isQuite)
        {
            DataSet dsFeeDetail = new DataSet();
            string quiteFlg = isQuite ? "2" : "1";
            if (this.ExecQuery("Fee.Account.QueryFeeDetailByInvoiceForAccout", ref dsFeeDetail, invoiceNO, quiteFlg) < 0)
            {
                return null;
            }
            return dsFeeDetail;
        }
        #endregion
        #endregion

        #region 帐户数据操作

        #region 生成帐号
        /// <summary>
        /// 生成帐号
        /// </summary>
        /// <returns></returns>
        public string GetAccountNO()
        {
            return this.GetSequence("Fee.Account.GetAccountNO");
        }
        #endregion

        #region 得到帐户余额

        /// <summary>
        /// 查找帐户余额
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="vacancy">余额</param>
        /// <returns>-1查找失败 0不存在 1帐户余额 2授权余额</returns>
        public int GetVacancy(string cardNO, ref decimal vacancy)
        {
            string accountNO = string.Empty;
            //查找帐户余额
            int resultValue = this.GetAccountVacancy(cardNO, ref vacancy,ref accountNO);
            //不存在帐户
            if (resultValue == 0)
            {
                //查找被授权余额
                resultValue = this.GetEmpowerVacancy(cardNO, ref vacancy,ref accountNO);
                if (resultValue > 0)
                {
                    return 2;
                }
            }
            return resultValue;

        }

        /// <summary>
        /// 查找帐户余额
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="vacancy">余额</param>
        /// <param name="accountNO">账号</param>
        /// <returns>-1查找失败 0不存在 1帐户余额 2授权余额</returns>
        public int GetVacancy(string cardNO, ref decimal vacancy,ref string accountNO)
        {
            //查找帐户余额
            int resultValue = this.GetAccountVacancy(cardNO, ref vacancy, ref accountNO);
            //不存在帐户
            if (resultValue == 0)
            {
                //查找被授权余额
                resultValue = this.GetEmpowerVacancy(cardNO, ref vacancy, ref accountNO);
                if (resultValue > 0)
                {
                    return 2;
                }
            }
            return resultValue;

        }
        #endregion

        #region 根据门诊卡号更新帐户余额
        /// <summary>
        /// 根据门诊卡号更新帐户余额
        /// </summary>
        /// <param name="cardNO">帐号</param>
        /// <param name="money">消费金额</param>
        /// <returns></returns>
        public int UpdateAccountVacancy(string accountNO, decimal money)
        {
            return this.UpdateSingTable("Fee.Account.UpdateAccountVacancy", accountNO, money.ToString());
        }
        #endregion

        #region 根据门诊卡号查找密码
        /// <summary>
        /// 根据门诊卡号查找密码
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <returns>用户密码</returns>
        public string GetPassWordByCardNO(string cardNO)
        {
            HISFC.Models.Account.Account account = GetAccountByCardNo(cardNO);
            if (account == null)
            {
                AccountEmpower accountEmpower=new AccountEmpower();
                int result = this.QueryAccountEmpowerByEmpwoerCardNO(cardNO, ref accountEmpower);
                if (result <= 0) return "-1";
                return accountEmpower.PassWord;
            }
            else
            {
                return account.PassWord;
            }
        }

        #endregion

        #region 根据门诊卡号更新用户密码
        /// <summary>
        /// 根据门诊卡号更新用户密码
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public int UpdatePassWordByCardNO(string accountNO, string passWord)
        {
            return this.UpdateSingTable("Fee.Account.UpdatePassWord", accountNO, HisDecrypt.Encrypt(passWord));
        }
        #endregion

        #region 更新帐户状态
        /// <summary>
        /// 更新帐户状态
        /// </summary>
        /// <param name="accountNO">帐号</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public int UpdateAccountState(string accountNO, string state)
        {
            return this.UpdateSingTable("Fee.Account.UpdateAccountState", state, accountNO);
        }
        #endregion

        #region 新建帐户
        /// <summary>
        /// 新建帐户
        /// </summary>
        /// <param name="account">帐户实体</param>
        /// <returns></returns>
        public int InsertAccount(Neusoft.HISFC.Models.Account.Account account)
        {

            return this.UpdateSingTable("Fee.Account.InsertAccount", account.AccountCard.Patient.PID.CardNO, //门诊卡号
                                            Neusoft.FrameWork.Function.NConvert.ToInt32(account.ValidState).ToString(), //帐户状态
                                            account.ID,//帐号
                                            HisDecrypt.Encrypt(account.PassWord));//密码
        }
        #endregion

        #region 根据门诊卡号取有效帐户信息
        /// <summary>
        /// 根据门诊卡号取有效（状态为在用）帐户信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Account.Account GetAccountByCardNo(string cardNO)
        {
            return this.GetAccount("Fee.Account.where1", cardNO);
        }
        #endregion 

        #region 根据帐号获取取帐户信息
        /// <summary>
        /// 根据帐号取帐户信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Account.Account GetAccountByAccountNO(string accountNO)
        {
            return this.GetAccount("Fee.Account.where2", accountNO);
        }
        #endregion

        #region 根据物理卡号查找帐户数据
        /// <summary>
        /// 根据物理卡号查找帐户数据
        /// </summary>
        /// <param name="markNo">物理卡号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Account.Account GetAccountByMarkNo(string markNo)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Fee.Account.AccountByMarkNo", ref Sql) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                Sql = string.Format(Sql, markNo);
                if (this.ExecQuery(Sql) < 0)
                {
                    this.Err = "查找数据失败！";
                    return null;
                }
                Neusoft.HISFC.Models.Account.Account account = null;
                //一个卡号只能对应一个帐户
                while (this.Reader.Read())
                {
                    account = new Neusoft.HISFC.Models.Account.Account();
                    account.CardNO = this.Reader[0].ToString();
                    account.ValidState = (HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[1]));
                    account.Vacancy = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2]);
                    account.PassWord = HisDecrypt.Decrypt(this.Reader[3].ToString());
                    account.DayLimit = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4]);
                    account.ID = this.Reader[5].ToString();
                }
                this.Reader.Close();
                return account;
            }
            catch (Exception ex)
            {
                this.Err = "查找数据失败！" + ex.Message;
                return null;
            }

        }

        #endregion

        #region 查找帐户密码
        /// <summary>
        /// 根据证件类型
        /// </summary>
        /// <param name="idCardNO">证件号</param>
        /// <param name="idCardType">证件类型</param>
        /// <returns>-1失败</returns>
        public ArrayList GetAccountByIdNO(string idCardNO, string idCardType)
        {
            string sqlstr = string.Empty;
            if (this.Sql.GetSql("Fee.Account.SelectAccountByIdNO", ref sqlstr) == -1)
            {
                this.Err = "查找索引为Fee.Account.SelectAccountPassWord的Sql语句失败！";
                return null;
            }
            ArrayList al = new ArrayList();
            HISFC.Models.Account.Account account = null;
            try
            {
                sqlstr = string.Format(sqlstr, idCardNO, idCardType);
                if (this.ExecQuery(sqlstr) < 0) return null;

                while (this.Reader.Read())
                {
                    account = new Neusoft.HISFC.Models.Account.Account();
                    account.CardNO = this.Reader[0].ToString();
                    if (this.Reader[1] != DBNull.Value) account.ValidState = (HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[1]));
                    if (this.Reader[2] != DBNull.Value) account.Vacancy = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2]);
                    if (this.Reader[3] != DBNull.Value) account.PassWord = HisDecrypt.Decrypt(this.Reader[3].ToString());
                    if (this.Reader[4] != DBNull.Value) account.DayLimit = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4]);
                    account.ID = this.Reader[5].ToString();
                    account.IsEmpower = NConvert.ToBoolean(this.Reader[6]);
                    al.Add(account);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询数据出错！" + ex.Message;
                return null;
            }
            finally
            {
                if(!this.Reader.IsClosed && this.Reader!= null)
                    this.Reader.Close();
            }
            return al;
        }
        #endregion

        #endregion

        #region 根据卡号规则读取卡号

        /// <summary>
        ///  根据卡号规则查找卡类型
        /// </summary>
        /// <param name="markNo">物理卡号</param>
        /// <param name="accountCard">卡实体</param>
        /// <returns>1:成功 0卡未发放 -1失败</returns>
        public int GetCardByRule(string markNo,ref Neusoft.HISFC.Models.Account.AccountCard accountCard)
        {
            markNo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(markNo);
            if(string.IsNullOrEmpty(markNo))
            {
                this.Err ="请输入有效的就诊卡号！";
                return -1;
            }
            if (!InitReadMark())
            {
                this.Err = "初始化动态库失败！";
                return -1;
            }
            int resultValue = IreadMarkNO.ReadMarkNOByRule(markNo,ref accountCard);
            this.Err = IreadMarkNO.Error;
            return resultValue;
        }
        #endregion

        #region 授权
        /// <summary>
        /// 插入授权表
        /// </summary>
        /// <param name="accontEmpower">授权实体</param>
        /// <returns>1成功 -1失败</returns>
        public int InsertEmpower(AccountEmpower accontEmpower)
        {
            return this.UpdateSingTable("Fee.Account.InsertEmpower", GetEmpowerArgs(accontEmpower));
        }

        /// <summary>
        /// 更新授权表
        /// </summary>
        /// <param name="accountEmpower">授权实体</param>
        /// <returns>1成功 -1失败 0没有更新到记录</returns>
        public int UpdateEmpower(AccountEmpower accountEmpower)
        {
            return this.UpdateSingTable("Fee.Account.UpdateEmpower", GetEmpowerArgs(accountEmpower));
        }

        /// <summary>
        /// 更新帐户授权标识
        /// </summary>
        /// <param name="accountNO">帐号</param>
        /// <returns>1成功 -1失败、0帐户数据发生变化</returns>
        public int UpdateAccountEmpowerFlag(string accountNO)
        {
            return UpdateSingTable("Fee.Account.UpdateAccountEmpowerFlag",accountNO);
        }

        /// <summary>
        /// 根据授权门诊卡号查找被授权信息
        /// </summary>
        /// <param name="accountNO">授权帐号</param>
        /// <returns></returns>
        public List<AccountEmpower> QueryEmpowerByAccountNO(string accountNO)
        {
            return this.GetEmpowerList("Fee.Account.SelectEmpowerwhere2", accountNO);
        }

        /// <summary>
        /// 根据授权门诊卡号查找被授权信息
        /// </summary>
        /// <param name="accountNO"></param>
        /// <returns></returns>
        public List<AccountEmpower> QueryAllEmpowerByAccountNO(string accountNO)
        {
            return this.GetEmpowerList("Fee.Account.SelectEmpowerwhere3", accountNO);
        }

        /// <summary>
        /// 根据被授权门诊卡号查找授权信息
        /// </summary>
        /// <param name="empowerCardNO">被授权门诊卡号</param>
        /// <returns>-1失败 0不存在有效的授权信息 1成功</returns>
        public int QueryAccountEmpowerByEmpwoerCardNO(string empowerCardNO,ref AccountEmpower accountEmpower)
        {
            List<AccountEmpower> list = this.GetEmpowerList("Fee.Account.SelectEmpowerwhere1", empowerCardNO);
            if (list == null) return -1;
            if (list.Count == 0)
            {
                this.Err = "该卡不存在有效的授权信息！";
                return 0;
            }
            accountEmpower = list[0];
            return 1;
        }

        /// <summary>
        /// 根据授权帐号和被授权门诊卡号查找授权信息
        /// </summary>
        /// <param name="accountNO">授权帐号</param>
        /// <param name="empowerCardNO">门诊卡号</param>
        /// <param name="accountEmpower">授权信息</param>
        /// <returns>-1失败 0不存在授权信息 1成功</returns>
        public int QueryEmpower(string accountNO, string empowerCardNO, ref AccountEmpower accountEmpower)
        {
            List<AccountEmpower> list = this.GetEmpowerList("Fee.Account.SelectEmpowerwhere4", accountNO,empowerCardNO);
            if (list == null) return -1;
            if (list.Count == 0)
            {
                this.Err = "该卡不存在有效的授权信息！";
                return 0;
            }
            accountEmpower = list[0];
            return 1;
        }

        /// <summary>
        /// 更新授权信息余额
        /// </summary>
        /// <param name="accountNO">帐号</param>
        /// <param name="empowerCardNO">被授权门诊卡号</param>
        /// <param name="money">金额</param>
        /// <returns>1成功 -1失败</returns>
        public int UpdateEmpowerVacancy(string accountNO, string empowerCardNO, decimal money)
        {
            return this.UpdateSingTable("Fee.Account.UpdateEmpowerVacancy", accountNO, empowerCardNO, money.ToString());
        }

        /// <summary>
        /// 批量更新授权状态
        /// </summary>
        /// <param name="accountNO">帐号</param>
        /// <param name="validState">更新的状态</param>
        /// <param name="currentState">当前状态</param>
        /// <returns>1成功 -1失败</returns>
        public int UpdateEmpowerState(string accountNO, HISFC.Models.Base.EnumValidState validState, HISFC.Models.Base.EnumValidState currentState)
        {
            return this.UpdateSingTable("Fee.Account.UpdateEmpowerState", accountNO, ((int)validState).ToString(), ((int)currentState).ToString());
        }

        #endregion

    }

    /// <summary>
    /// 读取就诊卡号接口，根据卡号规则读取卡号和卡类型
    /// </summary>
    public interface IReadMarkNO
    {
        /// <summary>
        /// 根据本地卡号规则读取卡实体
        /// </summary>
        /// <param name="markNO">卡号</param>
        /// <returns>-1 失败 0卡规则正确但还没有发放 1发放</returns>
        int ReadMarkNOByRule(string markNO,ref Neusoft.HISFC.Models.Account.AccountCard accountCard);
        /// <summary>
        /// 错误
        /// </summary>
        string Error
        {
            get;
            set;
        }
    }
}
