using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    

    /// <summary>
    /// (ICD10, ICD9, 手术ICD, ICD9, ICD10共用一个业务层 Creator: zhangjunyi@neusoft.com  2005/05/30
    /// </summary>
    public class ICD : Neusoft.FrameWork.Management.Database
    {

        public ICD()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region ICD9 ICD10 ICDOperation 操作函数
        /// <summary>
        /// 函数说明: 根据ICD类别插入ICD表 Creator: zhangjunyi@neusoft.com  2005/06/01
        /// </summary>
        /// <param name="obj">ICD类型</param>
        /// <param name="type">查询类型 </param>
        /// <returns> 错误返回 -1 成功返回  插入操作影响的行数 </returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.ICD obj, Neusoft.HISFC.Models.HealthRecord.EnumServer.ICDTypes type)
        {
            //定义字符变量，存储SQL语句
            string strSql = "";
            //唯一主键
            string sSequenceNo = "";
            //获得SQL语句
            switch (type)
            {
                case ICDTypes.ICD10:
                    //获得插入ICD10的SQL语句
                    if (this.Sql.GetSql("Case.ICDDML.Insert.ICD10", ref strSql) == -1)
                    {
                        this.Err = "获得SQL语句出错!没有找到索引Case.ICDDML.Insert.ICD10";
                        return -1;
                    }
                    //获得主键
                    obj.KeyCode = this.GetSequence("Case.ICDDML.GetSeq.ICD10");
                    if (obj.KeyCode == "" || sSequenceNo == null)
                    {
                        this.Err = "获得ICD10主键流水号出错!";
                        return -1;
                    }
                    break;
                case ICDTypes.ICD9:
                    //获得插入 ICD9的SQL语句
                    if (this.Sql.GetSql("Case.ICDDML.Insert.ICD9", ref strSql) == -1)
                    {
                        this.Err = "获得SQL语句出错!没有找到索引Case.ICDDML.Insert.ICD9";
                        return -1;
                    }
                    //获得主键
                    obj.KeyCode = this.GetSequence("Case.ICDDML.GetSeq.ICD9");
                    if (obj.KeyCode == "" || sSequenceNo == null)
                    {
                        this.Err = "获得ICD9主键流水号出错!";
                        return -1;
                    }
                    break;
                case ICDTypes.ICDOperation:
                    //获得插入手术的SQL语句
                    if (this.Sql.GetSql("Case.ICDDML.Insert.ICDOperation", ref strSql) == -1)
                    {
                        this.Err = "获得SQL语句出错!没有找到索引Case.ICDDML.Insert.ICDOperation";
                        return -1;
                    }
                    //获得主键
                    obj.KeyCode = this.GetSequence("Case.ICDDML.GetSeq.ICDOperation");
                    if (obj.KeyCode == "" || sSequenceNo == null)
                    {
                        this.Err = "获得ICDOperation主键流水号出错!";
                        return -1;
                    }
                    break;
            }   
            return this.ExecNoQuery(strSql, GetICDParam(obj));
        }

        /// <summary>
        /// 更新ICD表 
        /// </summary>
        /// <param name="orgICD">变更前实体</param>
        /// <param name="newICD">变更后实体</param>
        /// <param name="type">诊断类型枚举</param>
        /// <returns>-1 表示程序中有未处理的错误 >1 表示成功</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/06/01
        public int Update(Neusoft.HISFC.Models.HealthRecord.ICD orgICD, Neusoft.HISFC.Models.HealthRecord.ICD newICD, ICDTypes type)
        {
            try
            {
                //定义字符变量 ，保存更新SQL语句
                string strUpdateSql = "";
                //定义 整数变量，保存更新或插入操作影响的行数
                switch (type)
                {
                    case ICDTypes.ICD10:
                        //获得更新ICD10的SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Update.ICD10", ref strUpdateSql) == -1)
                        {
                            this.Err = "获得SQL语句出错!索引:Case.ICDDML.Update.ICD10";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICD9:
                        //获得更新ICD9的SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Update.ICD9", ref strUpdateSql) == -1)
                        {
                            this.Err = "获得SQL语句出错!";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICDOperation:
                        //获得更新手术的SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Update.ICDOperation", ref strUpdateSql) == -1)
                        {
                            this.Err = "获得SQL语句出错!";
                            return -1;
                        }
                        break;
                } 
                //执行更新操作 
                int iReturn = 0;
                iReturn = this.ExecNoQuery(strUpdateSql, GetICDParam(newICD)); //执行操作
                if (iReturn == 0) //没有更新记录,前台考虑是否并发
                {
                    return 0;
                }
                else if (iReturn == -1)//数据库操作失败
                {
                    return -1;
                }
                //执行插入变更记录
                iReturn = InsertShift(orgICD, newICD, type);
                if (iReturn == -1)//插入操作失败
                {
                    return -1;
                }
                else//插入操作成功
                {
                    return iReturn;
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //发生异常
                return -1;
            }
        }
        
        /// <summary>
        /// 获得相应查询类别的ICD信息 
        /// </summary>
        /// <param name="ICDType">诊断类型枚举</param>
        /// <param name="queryType">查询类型枚举</param>
        /// <returns>ArrayList.Count >= 1 正确获得符合条件的ICD集合 
        ///			 ArrayList.Count == 0 没有符合条件的ICD集合 
        ///			 null  出现未处理的错误    </returns>
        ///	Creator: zhangjunyi@neusoft.com  2005/06/01
        public ArrayList Query(ICDTypes ICDType, QueryTypes queryType)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            //查询条件
            string strWhere = "";
            //定义字符变量 ,存储WHERE 条件SQL语句
            string strValidString = "";
            //定义动态数组 ,存储查询出的信息
            ArrayList arryList = new ArrayList();
            try
            {
                switch (queryType)
                {
                    case QueryTypes.All:
                        //所有废弃和有效的
                        strValidString = "%";
                        break;
                    case QueryTypes.Valid:
                        //有效的
                        strValidString = "1";
                        break;
                    case QueryTypes.Cancel:
                        //废弃的 
                        strValidString = "0";
                        break;
                }

                switch (ICDType)
                {
                    case ICDTypes.ICD10:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD10.Base", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.ICD10";
                            return null;
                        }
                        break;
                    case ICDTypes.ICD9:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD9.Base", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败索引:Case.ICDDML.Query.ICD9";
                            return null;
                        }
                        break;
                    case ICDTypes.ICDOperation:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICDOperation.Base", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.ICDOperation";
                            return null;
                        }
                        break;
                }
                //获得查询条件
                if (this.Sql.GetSql("Case.ICDDML.Query.Valid", ref strWhere) == -1)
                {
                    this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.Valid";
                    return null;
                }
                strQuerySql += strWhere;
                try
                {
                    //格式化SQL语句
                    strQuerySql = string.Format(strQuerySql, strValidString);
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错!" + ex.Message;
                }
                //执行查询操作
                this.ExecQuery(strQuerySql);
                //读取数据
                arryList = ICDReaderInfo();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;

                if (!Reader.IsClosed) // 如果没有关闭reader
                {
                    this.Reader.Close(); //关闭reader
                }

                return null; // 出现错误返回null
            }

            return arryList;
        }
        /// <summary>
        ///  获得相应查询类别的ICD信息  用的时候 首先要判断返回值是
        ///   如果是0 则取DataSet 如果是-1 说明有错误  应该提示错误信息
        /// </summary>
        /// <param name="ICDType">诊断类型枚举</param>
        /// <param name="queryType">查询类型枚举</param>
        /// <param name="ds">符合条件的数据集</param>
        /// <returns>出现未知错误 返回 -1 成功返回 1</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/06/01
        public int Query(ICDTypes ICDType, QueryTypes queryType, ref DataSet ds)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            //定义字符变量, 存储查询条件
            string strWhere = "";
            //定义字符变量 ,存储WHERE 条件SQL语句
            string strValidString = "";
            try
            {
                switch (queryType)
                {
                    case QueryTypes.All:
                        //所有废弃和有效的
                        strValidString = "%";
                        break;
                    case QueryTypes.Valid:
                        //有效的
                        strValidString = "1";
                        break;
                    case QueryTypes.Cancel:
                        //废弃的 
                        strValidString = "0";
                        break;
                }

                switch (ICDType)
                {
                    case ICDTypes.ICD10:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD10.Base.ds", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.ICD10.Base.ds";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICD9:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD9.Base.ds", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.ICD9.Base.ds";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICDOperation:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICDOperation.Base.ds", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败, 索引:Case.ICDDML.Query.ICDOperation.Base.ds";
                            return -1;
                        }
                        break;
                }

                //获得查询条件
                if (this.Sql.GetSql("Case.ICDDML.Query.Valid", ref strWhere) == -1)
                {
                    this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.Valid";
                    return -1;
                }

                strQuerySql += strWhere;

                try
                {
                    //组建查询语句 
                    strQuerySql = string.Format(strQuerySql, strValidString);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return -1;
                }
                //执行查询操作
                return this.ExecQuery(strQuerySql, ref ds);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //获取错误信息
                return -1; //产生未处理的错误
            }
        }
        /// <summary>
        /// 从Reader  中读取数据
        /// </summary>
        /// <returns> 出现未处理的错误返回 null 有记录list.Count >1  没有记录 list.Count =0</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/06/01
        private ArrayList ICDReaderInfo()
        {
            //定义 动态数组， 用来存储读出的信息
            ArrayList list = new ArrayList();
            try
            {
                //定义实体
                Neusoft.HISFC.Models.HealthRecord.ICD icd = null;
                while (this.Reader.Read())
                {
                    icd = new Neusoft.HISFC.Models.HealthRecord.ICD();

                    icd.KeyCode = Reader[0].ToString(); //ICD主键
                    icd.ID = Reader[1].ToString();//ICD编码
                    icd.SICode = Reader[2].ToString(); //医保中心代码
                    icd.UserCode = Reader[3].ToString(); //统计代码
                    icd.SpellCode = Reader[4].ToString();    //拼音码
                    icd.WBCode = Reader[5].ToString();//五笔码
                    icd.Name = Reader[6].ToString(); //ICD名称
                    icd.User01 = Reader[7].ToString(); //疾病名称1
                    icd.User02 = Reader[8].ToString(); //疾病名称2
                    icd.DeadReason = Reader[9].ToString(); //死亡原因
                    icd.DiseaseCode = Reader[10].ToString(); //疾病分类代码
                    icd.StandardDays = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[11].ToString());//标准住院日
                    icd.Is30Illness = Reader[12].ToString();//是否30种疾病
                    icd.IsInfection = Reader[13].ToString();//是否传染病
                    icd.IsTumour = Reader[14].ToString();//是否恶性肿瘤 
                    icd.InpGrade = Reader[15].ToString();//住院等级
                    icd.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[16].ToString());//是否有效
                    icd.SeqNo = Reader[17].ToString();//序号
                    icd.OperInfo.ID = Reader[18].ToString();
                    icd.OperInfo.Name = Reader[19].ToString();
                    if (!Reader.IsDBNull(20))
                    {
                        icd.OperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[20].ToString());
                    }
                    icd.User01 = Reader[21].ToString(); //副诊断码
                    icd.SexType.ID = Reader[22].ToString(); //适用性别
                    icd.TraditionalDiag = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[23].ToString());
                    list.Add(icd); //填充数据
                    icd = null;
                }
                this.Reader.Close(); //关闭reade
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;

                if (!this.Reader.IsClosed) // 判断是否关闭了Reader
                {
                    this.Reader.Close();//没有关闭则先关闭
                }

                return null; //出现错误返回null 
            }

            return list;
        }
        /// <summary>
        /// 判断录入的ICD编码是否存在,如果存在返回符合条件的ArrayList,否则返回null参数
        /// </summary>
        /// <param name="ICDCode">录入的ICD编码</param>
        /// <param name="type">ICD类别</param>
        /// <param name="isValid">是否有效 true 有效 false 作废</param>
        /// <returns>Arralist.Count >= 1 实体类型ICD 符合查询条件的ICD实体ArralyList
        ///          ArrayList.Count = 0 没有符合条件的记录
        ///          null 数据库操作失败 </returns>
        ///          Creator: zhangjunyi@neusoft.com  2005/06/01
        public ArrayList IsExistAndReturn(string ICDCode, ICDTypes type, bool isValid)
        {
            //主要处理当操作员在做新增操作时判断输入ICDCode是否存在,
            //如果不存在那么默认新增状态,如果输入的ICDCode存在,则为修改状态
            //定义字符变量，存储SQL语句
            string strSql = "";
            //定义字符变量，存储查询条件
            string strWhere = "";
            //第一动态数组 ，存储符合条件的记录
            ArrayList arrList = new ArrayList();
            try
            {
                //根据type获得对应的SQL语句
                switch (type)
                {
                    case ICDTypes.ICD10:
                        //获取SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD10.Base", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错, 索引:Case.ICDDML.Query.ICD10";
                            return null;
                        }
                        break;
                    case ICDTypes.ICD9:
                        //获取SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD9.Base", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错, 索引:Case.ICDDML.Query.ICD9";
                            return null;
                        }
                        break;
                    case ICDTypes.ICDOperation:
                        //获取SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICDOperation.Base", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错,索引:Case.ICDDML.Query.ICDOperation";
                            return null;
                        }
                        break;
                }

                if (this.Sql.GetSql("Case.ICDDML.Query.IsExistAndReturn", ref strWhere) == -1)
                {
                    this.Err = "获取SQL语句出错,索引:Case.ICDDML.Query.IsExistAndReturn";
                    return null;
                }

                strSql += strWhere;

                try
                {
                    strSql = string.Format(strSql, ICDCode, NConvert.ToInt32(isValid));
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错!" + ex.Message;
                }
                //执行SQL语句
                this.ExecQuery(strSql);
                //读取数据
                arrList = ICDReaderInfo();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //获取错误信息

                if (!Reader.IsClosed)  //如果Reader没有关闭
                {
                    this.Reader.Close(); //关闭Reader
                }

                return null; // 错误返回null
            }

            return arrList;
        }
        /// <summary>
        /// 判断录入的ICD编码是否存在,如果存在返回符合条件的实体,否则返回null参数
        /// </summary>
        /// <param name="ICDCode">录入的ICD编码</param>
        /// <param name="type">ICD类别</param>
        /// <param name="isValid">是否有效 true 有效 false 作废</param>
        /// <returns>null 数据库操作失败 </returns>
        ///          Creator: zhangjunyi@neusoft.com  2005/06/01
        public Neusoft.HISFC.Models.HealthRecord.ICD IsExistAndReturnOne(string ICDCode, ICDTypes type, bool isValid)
        {
            //主要处理当操作员在做新增操作时判断输入ICDCode是否存在,
            //如果不存在那么默认新增状态,如果输入的ICDCode存在,则为修改状态
            //定义字符变量，存储SQL语句
            string strSql = "";
            //定义字符变量，存储查询条件
            string strWhere = "";
            //第一动态数组 ，存储符合条件的记录
            ArrayList arrList = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.ICD info = null;
            try
            {
                //根据type获得对应的SQL语句
                switch (type)
                {
                    case ICDTypes.ICD10:
                        //获取SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD10.Base", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错, 索引:Case.ICDDML.Query.ICD10";
                            return null;
                        }
                        break;
                    case ICDTypes.ICD9:
                        //获取SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICD9.Base", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错, 索引:Case.ICDDML.Query.ICD9";
                            return null;
                        }
                        break;
                    case ICDTypes.ICDOperation:
                        //获取SQL语句
                        if (this.Sql.GetSql("Case.ICDDML.Query.ICDOperation.Base", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错,索引:Case.ICDDML.Query.ICDOperation";
                            return null;
                        }
                        break;
                }

                if (this.Sql.GetSql("Case.ICDDML.Query.IsExistAndReturn", ref strWhere) == -1)
                {
                    this.Err = "获取SQL语句出错,索引:Case.ICDDML.Query.IsExistAndReturn";
                    return null;
                }

                strSql += strWhere;

                try
                {
                    strSql = string.Format(strSql, ICDCode, NConvert.ToInt32(isValid));
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错!" + ex.Message;
                }
                //执行SQL语句
                this.ExecQuery(strSql);
                //读取数据
                arrList = ICDReaderInfo();
                if (arrList == null)
                {
                    return null;
                }
                if (arrList.Count > 0)
                {
                    info = (Neusoft.HISFC.Models.HealthRecord.ICD)arrList[0];
                }
                return info;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //获取错误信息

                if (!Reader.IsClosed)  //如果Reader没有关闭
                {
                    this.Reader.Close(); //关闭Reader
                }

                return null; // 错误返回null
            }
        }
        /// <summary>
        /// 获取只适用于男性或女性的诊断 sexCode为"M" 查询男性诊断, "F"查询女性诊断
        /// </summary>
        /// <param name="sexCode"></param>
        /// <returns></returns>
        public ArrayList QueryDiagnoseBySex(string sexCode)
        {
            //定义字符变量，存储SQL语句
            string strSql = "";
            //定义字符变量，存储查询条件
            string strWhere = "";
            //第一动态数组 ，存储符合条件的记录
            ArrayList arrList = new ArrayList();
            try
            {
                if (this.Sql.GetSql("Case.ICDDML.Query.ICD10.Base", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句出错, 索引:Case.ICDDML.Query.ICD10";
                    return null;
                }
                if (this.Sql.GetSql("Case.ICDDML.Query.GetDiagnoseBySex", ref strWhere) == -1)
                {
                    this.Err = "获取SQL语句出错,索引:Case.ICDDML.Query.GetDiagnoseBySex";
                    return null;
                }
                strSql += strWhere;
                try
                {
                    strSql = string.Format(strSql, sexCode);
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错!" + ex.Message;
                    if (!Reader.IsClosed)  //如果Reader没有关闭
                    {
                        this.Reader.Close(); //关闭Reader
                    }
                    return null;
                }
                //执行SQL语句
                this.ExecQuery(strSql);
                //读取数据
                arrList = ICDReaderInfo();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                if (!Reader.IsClosed)  //如果Reader没有关闭
                {
                    this.Reader.Close(); //关闭Reader
                }

                return null;
            }
            return arrList;
        }

        #region 私有函数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgICD"></param>
        /// <param name="newICD"></param>
        /// <returns></returns>
        private string[] GetICDParam(Neusoft.HISFC.Models.HealthRecord.ICD newICD)
        {
            string[] str = new string[]{
                                        newICD.KeyCode, //0
                                        newICD.ID,
                                        newICD.SICode, //1
                                        newICD.UserCode, //2
                                        newICD.SpellCode,//3
                                        newICD.WBCode, //4
                                        newICD.Name, //5
                                        newICD.User01, //6
                                        newICD.User02, //7
                                        newICD.DeadReason, //8
                                        newICD.DiseaseCode,//9
                                        newICD.StandardDays.ToString(), //10
                                        newICD.Is30Illness, //11
                                        newICD.IsInfection,//12
                                        newICD.IsTumour, //13
                                        newICD.InpGrade,  //14
                                        Neusoft.FrameWork.Function.NConvert.ToInt32(newICD.IsValid).ToString(),//15
                                        newICD.SeqNo, //16
                                        newICD.OperInfo.ID, //17
                                        newICD.User01, //18
                                        newICD.SexType.ID.ToString(),//19
                                         Neusoft.FrameWork.Function.NConvert.ToInt32(newICD.TraditionalDiag).ToString()
            };
            return str;
        }
        #endregion 
        #endregion

        #region 针对ICD对照的函数.
        /// <summary>
        /// 插入已对照信息  
        /// </summary>
        /// <param name="compare">obj ICD对照实体</param>
        /// <returns>出现错误 返回 -1 成功 返回 1</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/05/30
        public int InsertCompare(Neusoft.HISFC.Models.HealthRecord.ICDCompare compare)
        {
            try
            {
                //定义字符变量 ，存储SQL语句
                string strSql = "";
                //获得SQL语句
                if (this.Sql.GetSql("Case.ICDDML.InsertCompare", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return -1;
                }
                //有效性
                string isValid = "";
                if (compare.IsValid)
                {
                    isValid = "1";
                }
                else
                {
                    isValid = "0";
                }
                //try
                //{
                //    //格式化SQL语句 
                //    strSql = string.Format(strSql, compare.ICD9.ID, compare.ICD9.Name, compare.ICD10.ID,
                //        compare.ICD10.Name, isValid, compare.OperInfo.ID, compare.ICD9.SpellCode,
                //        compare.ICD9.UserCode, compare.ICD9.KeyCode);
                //}
                //catch (Exception ex)
                //{
                //    this.Err = "SQL语句赋值出错!" + ex.Message;
                //    return -1;
                //}
                string[] str = new string[] { compare.ICD9.ID, 
                                            compare.ICD9.Name, 
                                            compare.ICD10.ID,
                                            compare.ICD10.Name, 
                                            isValid, 
                                            compare.OperInfo.ID, 
                                            compare.ICD9.SpellCode,
                                            compare.ICD9.UserCode, 
                                            compare.ICD9.KeyCode
                };
                //执行插入操作
                return this.ExecNoQuery(strSql, str);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //捕获错误
                return -1; //返回错误
            }
        }
        /// <summary>
        /// 获得未对照的ICD9信息
        /// </summary>
        /// <param name="type">查询类型</param>
        /// <returns>错误返回 NULL 正确返回arrayList</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/05/30
        public ArrayList QueryNoComparedICD9(QueryTypes type)
        {
            try
            {
                //定义字符变量 ，存储SQL语句
                string strSql = "";
                //定义字符变量 存储 Where 条件
                string strValidString = "";
                //定义动态数组 ，存储符合条件的数据集
                ArrayList arrayList = new ArrayList();
                //获取SQL语句
                if (this.Sql.GetSql("Case.ICDDML.QueryNoComparedICD9", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return null;
                }
                //根据type给SQL语句赋值
                switch (type)
                {
                    case QueryTypes.All:  //查询所有的
                        strValidString = "%";
                        break;
                    case QueryTypes.Cancel: //查询作废的
                        strValidString = "0";
                        break;
                    case QueryTypes.Valid: // 查询有效的
                        strValidString = "1";
                        break;
                }
                try
                {
                    strSql = string.Format(strSql, strValidString);
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错! " + ex.Message;
                    return null;
                }
                //执行查询操作
                this.ExecQuery(strSql);
                //利用Reader装载实体(HISFC.Object.Case.ICD)
                arrayList = ICDReaderInfo();
                //返回ArrayList
                return arrayList;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;//捕获错误
                return null;  //返回null
            }

        }
        /// <summary>
        /// 从Reader 中读取信息 存到 数组中 
        /// </summary>
        /// <returns>错误返回 null  成功返回 数组</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/05/30
        private ArrayList QueryICDCompare(string strSql)
        {
            try
            {
                this.ExecQuery(strSql);
                //定义动态数组 ，存储查询出来的数据集
                ArrayList arryCompare = new ArrayList();
                //定义变量 ，存储数据
                Neusoft.HISFC.Models.HealthRecord.ICDCompare compare = null;
                while (this.Reader.Read())
                {
                    compare = new Neusoft.HISFC.Models.HealthRecord.ICDCompare();

                    compare.ICD9.ID = Reader[0].ToString();		//ICD9编码
                    compare.ICD9.Name = Reader[1].ToString();		//ICD9名称
                    compare.ICD10.ID = Reader[2].ToString();			//ICD10编码
                    compare.ICD10.Name = Reader[3].ToString();		//ICD10名称
                    compare.OperInfo.ID = Reader[4].ToString();		//录入操作员工号
                    compare.OperInfo.Name = Reader[5].ToString();	//录入操作员姓名
                    compare.OperInfo.OperTime = NConvert.ToDateTime(Reader[6]);
                    compare.IsValid = NConvert.ToBoolean(Reader[7].ToString()); //有效性
                    compare.ICD9.SpellCode = Reader[8].ToString(); //拼音
                    compare.ICD9.UserCode = Reader[9].ToString(); //自定义
                    compare.ICD9.KeyCode = Reader[10].ToString();
                    arryCompare.Add(compare); //添家到动态数组中
                    compare = null;           //释放资源
                }
                this.Reader.Close(); //关闭Reader
                return arryCompare;
            }
            catch (Exception ex)
            {
                //出现错误
                this.Err = ex.Message;
                if (!this.Reader.IsClosed) //如果没有释放 Reader
                {
                    this.Reader.Close(); //关闭Reader
                }
                return null;
            }
        }

        /// <summary>
        /// 重载 获得未对照的ICD9信息
        /// </summary>
        /// <param name="type">查询类型</param>
        /// <param name="ds">数据集</param>
        /// <returns>程序中出现未处理的错误 返回 -1 正确返回 1 并返回符合条件的数据集</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/05/30
        public int QueryNoComparedICD9(QueryTypes type, ref DataSet ds)
        {
            try
            {
                //定义字符变量 ，存储SQL语句
                string strSql = "";
                //定义字符变量 存储 Where 条件
                string strValidString = "";
                //定义动态数组 ，存储符合条件的数据集
                ArrayList arrayList = new ArrayList();
                //获取SQL语句
                if (this.Sql.GetSql("Case.ICDDML.QueryNoComparedICD9", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return -1;
                }
                //根据type给SQL语句赋值
                switch (type)
                {
                    case QueryTypes.All:  //查询所有的
                        strValidString = "%";
                        break;
                    case QueryTypes.Cancel: //查询作废的
                        strValidString = "0";
                        break;
                    case QueryTypes.Valid: // 查询有效的
                        strValidString = "1";
                        break;
                }
                try
                {
                    //格式化SQL
                    strSql = string.Format(strSql, strValidString);
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错!" + ex.Message;
                    return -1;
                }
                //执行查询操作
                return this.ExecQuery(strSql, ref ds);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;//捕获错误
                return -1;  //返回null
            }
        }
        /// <summary>
        /// 获得已对照的ICD信息
        /// </summary>
        /// <returns>承载ICDCompare实体的ArrayList 
        ///null 数据库出错
        /// ArrayList.Count = 0 没有符合记录的数据
        /// ArrayLIst.Count >= 1</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/05/30
        public ArrayList QueryComparedICD()
        {
            try
            {
                //定义字符变量 ，存储SQL语句
                string strSql = "";
                //定义动态数组 ，存储符合条件的数据集
                ArrayList arrayList = new ArrayList();

                //获得查询SQL语句
                if (this.Sql.GetSql("Case.ICDDML.QueryComparedICD", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return null;
                }
                //执行插入操作
                
                //读取Reader 给实体赋值(HISFC.Object.Case.ICDCompare)
                arrayList = QueryICDCompare(strSql);
                //返回ArrayList
                return arrayList;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //捕获错误
                return null;  //返回null 
            }
        }
        /// <summary>
        /// 获得已对照的ICD信息 返回  DataSet  
        /// </summary>
        /// <param name="ds">符合条件的数据集</param>
        /// <returns> 程序中有未发现的错误返回-1 没有错误返回 1</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/05/30
        public int QueryComparedICD(ref DataSet ds)
        {
            try
            {
                //定义字符变量 ，存储SQL语句
                string strSql = "";
                //定义动态数组 ，存储符合条件的数据集
                ArrayList arrayList = new ArrayList();

                //获得查询SQL语句
                if (this.Sql.GetSql("Case.ICDDML.QueryComparedICD", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return -1;
                }
                //执行插入操作
                return this.ExecQuery(strSql, ref ds);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //捕获错误
                return -1;  //返回null 
            }
        }
        /// <summary>
        /// 删除已对照信息  
        /// </summary>
        /// <param name="ICDCode">已对照的ICD9编码(对照表ICD9编码是主键)</param>
        /// <returns>  -1 数据库操作错误
        ///            0	没有找到删除的行(考虑Where条件错误,或者并发)
        ///		       1	删除成功  </returns>
        ///		       Creator: zhangjunyi@neusoft.com  2005/05/30
        public int DeleteCompared(string ICDCode)
        {
            try
            {
                //定义字符变量 ，存储SQL语句
                string strSql = "";
                //获得删除SQL语句
                if (this.Sql.GetSql("Case.ICDDML.DeleteCompared", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return -1;
                }
                try
                {
                    //给SQL语句赋参数
                    strSql = string.Format(strSql, ICDCode);
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错!" + ex.Message;
                    return -1;
                }
                //执行删除操作
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message; //捕获错误
                return -1;
            }
        }

        #endregion

        #region ICD变更表
        /// <summary>
        /// 插入变更信息 
        /// </summary>
        /// <param name="orgICD">变更前状态</param>
        /// <param name="newICD">变更后状态</param>
        /// <param name="type">诊断类型枚举</param>
        /// <returns>-1 出错  >=1成功</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/06/01
        private int InsertShift(Neusoft.HISFC.Models.HealthRecord.ICD orgICD, Neusoft.HISFC.Models.HealthRecord.ICD newICD, ICDTypes type)
        {
            try
            {
                //定义字符变量，存储SQL语句
                string strSql = "";
                //根据type获得SQL语句
                switch (type)
                {
                    case ICDTypes.ICD10:
                        //获取SQL 语句
                        if (this.Sql.GetSql("Case.ICDDML.InsertShift.ICD10", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICD9:
                        //获取SQL 语句
                        if (this.Sql.GetSql("Case.ICDDML.InsertShift.ICD9", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICDOperation:
                        //获取SQL 语句
                        if (this.Sql.GetSql("Case.ICDDML.InsertShift.ICDOperation", ref strSql) == -1)
                        {
                            this.Err = "获取SQL语句出错";
                            return -1;
                        }
                        break;
                    //赋值
                } 
                //执行插入操作
                return this.ExecNoQuery(strSql, GetICDLogParam(orgICD, newICD));
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //发生未处理异常
                return -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgICD"></param>
        /// <param name="newICD"></param>
        /// <returns></returns>
        private string[] GetICDLogParam(Neusoft.HISFC.Models.HealthRecord.ICD orgICD, Neusoft.HISFC.Models.HealthRecord.ICD newICD)
        {
            string[] str = new string[]{
                                        orgICD.ID, 
                        orgICD.SICode, 
                        orgICD.UserCode, 
                        orgICD.SpellCode, 
                        orgICD.WBCode,
                        orgICD.Name, 
                        orgICD.User01, 
                        orgICD.User02, 
                        orgICD.DeadReason, 
                        orgICD.DiseaseCode, 
                        orgICD.StandardDays.ToString(),
                        orgICD.Is30Illness, 
                        orgICD.IsInfection, 
                        orgICD.IsTumour,
                        orgICD.InpGrade, 
                        Neusoft.FrameWork.Function.NConvert.ToInt32(orgICD.IsValid).ToString(), 
                        newICD.SICode, 
                        newICD.UserCode, 
                        newICD.SpellCode, 
                        newICD.WBCode,
                        newICD.Name, 
                        newICD.User01, 
                        newICD.User02, 
                        newICD.DeadReason, 
                        newICD.DiseaseCode, 
                        newICD.StandardDays.ToString(),
                        newICD.Is30Illness, 
                        newICD.IsInfection, 
                        newICD.IsTumour,
                        newICD.InpGrade, 
                        Neusoft.FrameWork.Function.NConvert.ToInt32(newICD.IsValid).ToString(), 
                this.Operator.ID
            };
            return str;
        }
        #endregion 

        #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}

        /// <summary>
        /// 查询所有科常用诊断
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList QueryDeptDiag(string deptID)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";

            //定义动态数组 ,存储查询出的信息
            ArrayList arryList = new ArrayList();

            if (this.Sql.GetSql("Case.ICD.Query.DpetICD.1", ref strQuerySql) == -1)
            {
                this.Err = "获取SQL语句失败,索引:Case.ICD.Query.DpetICD.1";
                return null;
            }

            try
            {
                //格式化SQL语句
                strQuerySql = string.Format(strQuerySql, deptID);
            }
            catch (Exception ex)
            {
                this.Err = "SQL语句赋值出错!" + ex.Message;
            }
            //执行查询操作
            this.ExecQuery(strQuerySql);

            try
            {
                //读取数据
                arryList = ICDReaderInfo();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;

                if (!Reader.IsClosed) // 如果没有关闭reader
                {
                    this.Reader.Close(); //关闭reader
                }

                return null; // 出现错误返回null
            }
            return arryList;
        }

        #endregion

        #region 废弃
        /// <summary>
        /// 获取只适用于男性或女性的诊断 sexCode为"M" 查询男性诊断, "F"查询女性诊断
        /// </summary>
        /// <param name="sexCode"></param>
        /// <returns></returns>
        [Obsolete("废弃,用QueryDiagnoseBySex代替",true)]
        public ArrayList GetDiagnoseBySex(string sexCode)
        {
            //定义字符变量，存储SQL语句
            string strSql = "";
            //定义字符变量，存储查询条件
            string strWhere = "";
            //第一动态数组 ，存储符合条件的记录
            ArrayList arrList = new ArrayList();
            try
            {
                if (this.Sql.GetSql("Case.ICDDML.Query.ICD10.Base", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句出错, 索引:Case.ICDDML.Query.ICD10";
                    return null;
                }
                if (this.Sql.GetSql("Case.ICDDML.Query.GetDiagnoseBySex", ref strWhere) == -1)
                {
                    this.Err = "获取SQL语句出错,索引:Case.ICDDML.Query.GetDiagnoseBySex";
                    return null;
                }
                strSql += strWhere;
                try
                {
                    strSql = string.Format(strSql, sexCode);
                }
                catch (Exception ex)
                {
                    this.Err = "SQL语句赋值出错!" + ex.Message;
                    if (!Reader.IsClosed)  //如果Reader没有关闭
                    {
                        this.Reader.Close(); //关闭Reader
                    }
                    return null;
                }
                //执行SQL语句
                this.ExecQuery(strSql);
                //读取数据
                arrList = ICDReaderInfo();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                if (!Reader.IsClosed)  //如果Reader没有关闭
                {
                    this.Reader.Close(); //关闭Reader
                }

                return null;
            }
            return arrList;
        }
        /// <summary>
        /// 性别 
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 枚举 代替 ", true)]
        public ArrayList SexList()
        {
            ArrayList list = new ArrayList();
            //Neusoft.HISFC.Object.Base.Spell obj = new Neusoft.HISFC.Object.Base.Spell();
            //obj.ID = "A";
            //obj.Name = "全部";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "M";
            //obj.Name = "男"; //这里跟医生站有区别，出院诊断对应 主要诊断
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "F";
            //obj.Name = "女"; //这里跟医生站有区别，出院诊断对应 主要诊断
            //list.Add(obj);
            return list;
        }

        /// <summary>
        /// 从Reader 中读取信息 存到 数组中 
        /// </summary>
        /// <returns>错误返回 null  成功返回 数组</returns>
        /// Creator: zhangjunyi@neusoft.com  2005/05/30
        [Obsolete("废弃 用 QueryCompareICD 代替 ", true)]
        private ArrayList ReadInfoCompare()
        {
            try
            {
                //定义动态数组 ，存储查询出来的数据集
                ArrayList arryCompare = new ArrayList();
                //定义变量 ，存储数据
                Neusoft.HISFC.Models.HealthRecord.ICDCompare compare = null;
                while (this.Reader.Read())
                {
                    compare = new Neusoft.HISFC.Models.HealthRecord.ICDCompare();

                    compare.ICD9.ID = Reader[0].ToString();		//ICD9编码
                    compare.ICD9.Name = Reader[1].ToString();		//ICD9名称
                    compare.ICD10.ID = Reader[2].ToString();			//ICD10编码
                    compare.ICD10.Name = Reader[3].ToString();		//ICD10名称
                    compare.OperInfo.ID = Reader[4].ToString();		//录入操作员工号
                    compare.OperInfo.Name = Reader[5].ToString();	//录入操作员姓名
                    compare.OperInfo.OperTime = NConvert.ToDateTime(Reader[6]);
                    compare.IsValid = NConvert.ToBoolean(Reader[7].ToString()); //有效性
                    compare.ICD9.SpellCode = Reader[8].ToString(); //拼音
                    compare.ICD9.UserCode = Reader[9].ToString(); //自定义
                    compare.ICD9.KeyCode = Reader[10].ToString();
                    arryCompare.Add(compare); //添家到动态数组中
                    compare = null;           //释放资源
                }
                this.Reader.Close(); //关闭Reader
                return arryCompare;
            }
            catch (Exception ex)
            {
                //出现错误
                this.Err = ex.Message;
                if (!this.Reader.IsClosed) //如果没有释放 Reader
                {
                    this.Reader.Close(); //关闭Reader
                }
                return null;
            }
        }
        #endregion
    }
}
