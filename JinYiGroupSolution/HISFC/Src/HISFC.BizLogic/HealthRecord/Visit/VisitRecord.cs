using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Visit
{
    /// <summary>
    /// VisitRecord<br></br>
    /// [功能描述: 随访明细基本业务层]<br></br>
    /// [创 建 者: 王立]<br></br>
    /// [创建时间: 2007-08-30]<br></br>
    /// <修改记录
    ///		修改人='金鹤'
    ///		修改时间='2009-09-15'
    ///		修改目的='新增加查询待随访患者列表'
    ///		修改描述='{E9F858A6-BDBC-4052-BA57-68755055FB80}'
    ///  />
    /// </summary>
    public class VisitRecord :Neusoft.FrameWork.Management.Database
    {
        #region 数据库的基本操作

        /// <summary>
        /// 向随访明细表中插入一条新记录
        /// </summary>
        /// <returns>影响的行数、-1 失败</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord, string sequ) 
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.Insert字段!";
                return -1;
            }
            try
            {
                //获取随访明细流水号
                visitRecord.ID = sequ;

                //获取传递参数数组
                string[] strParm = this.GetVisitRecordParmItem(visitRecord);
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错!" + ex.Message;
                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);

        }

        /// <summary>
        /// 获取随访明细流水号
        /// </summary>
        /// <returns>流水号</returns>
        public string GetVisitRecordSequ()
        {
            string sequ = this.GetSequence("HealthReacord.Visit.VisitRecord.GetVisitRecordID");

            if (sequ == null)
            {
                this.Err = "获取流水号出错！";

                return null;
            }

            return sequ;
        }

        /// <summary>
        /// 随访信息录入
        /// </summary>
        /// <param name="visitRecord"></param>
        /// <returns>影响的行数、-1 失败</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.Update", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.Update字段！";
                return -1;
            }
            try
            {
                string[] strParm = this.GetVisitRecordParmItem(visitRecord);
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }
            
            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 获取insert或update的参数
        /// </summary>
        /// <param name="linkway">随访明细记录类</param>
        /// <returns>返回参数数组</returns>
        private string[] GetVisitRecordParmItem(Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord)
        {
            string[] strParm =new string[36];

            strParm[0] = visitRecord.ID;
            strParm[1] = visitRecord.Patient.PID.CardNO;
            strParm[2] = visitRecord.Circs.ID;
            strParm[3] = visitRecord.DeadReason.ID;
            strParm[4] = visitRecord.DeadTime.ToString();
            if (visitRecord.IsDead)
            {
                strParm[5] = "1";
            }
            else
            {
                strParm[5] = "0";
            }
            if (visitRecord.IsRecrudesce)
            {
                strParm[6] = "1";
            }
            else
            {
                strParm[6] = "0";
            }
            if (visitRecord.IsSequela)
            {
                strParm[7] = "1";
            }
            else
            {
                strParm[7] = "0";
            }
            if (visitRecord.IsSuccess)
            {
                strParm[8] = "1";
            }
            else
            {
                strParm[8] = "0";
            }
            if (visitRecord.IsTransfer)
            {
                strParm[9] = "1";
            }
            else
            {
                strParm[9] = "0";
            }
            strParm[10] = visitRecord.RecrudesceTime.ToString();
            strParm[11] = visitRecord.ResultOper.ID;
            strParm[12] = visitRecord.ResultOper.OperTime.ToString();
            strParm[13] = visitRecord.Sequela.ID;
            strParm[14] = visitRecord.Symptom.ID;
            strParm[15] = visitRecord.TransferPosition.ID;
            strParm[16] = visitRecord.VisitOper.ID;
            strParm[17] = visitRecord.VisitOper.OperTime.ToString();
            strParm[18] = visitRecord.VisitType.ID;
            strParm[19] = visitRecord.WriteBackPerson;
            if (visitRecord.IsPassive)
            {
                strParm[20] = "1";
            }
            else
            {
                strParm[20] = "0";
            }
            if (visitRecord.LinkWay.IsLinkMan)
            {
                strParm[21] = "1";
            }
            else
            {
                strParm[21] = "0";
            }
            strParm[22] = visitRecord.LinkWay.LinkMan.Name;
            strParm[23] = visitRecord.LinkWay.LinkWayType.ID;
            strParm[24] = visitRecord.LinkWay.Relation.ID;
            if (visitRecord.IsResult)
            {
                strParm[25] = "1";
            }
            else
            {
                strParm[25] = "0";
            }
            strParm[26] = visitRecord.LinkWay.ZIP;
            if (visitRecord.IsWorkLoad)
            {
                strParm[27] = "1";
            }
            else
            {
                strParm[27] = "0";
            }
            strParm[28] = visitRecord.LinkWay.Address;
            strParm[29] = visitRecord.LinkWay.Mail;
            strParm[30] = visitRecord.LinkWay.Phone;
            strParm[31] = visitRecord.LinkWay.OtherLinkway;
            strParm[32] = visitRecord.User01;
            strParm[33] = visitRecord.User02;
            strParm[34] = visitRecord.User03;

            #region {E9F858A6-BDBC-4052-BA57-68755055FB80}

            strParm[35] = visitRecord.VisitResult.ID;

            #endregion

            //返回数组
            return strParm;

        }

        /// <summary>
        /// 向随访明细症状表现表中插入一条新记录,将随访记录明细的ID存在常数实体的SortID中
        /// </summary>
        /// <returns>影响的行数、-1 失败</returns>
        public int InsertSymptom(Neusoft.HISFC.Models.Base.Const symptomInfo)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.InsertSymptom", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.InsertSymptom字段!";
                return -1;
            }
            try
            {
                //传递参数
                strSQL = string.Format(strSQL, Neusoft.FrameWork.Function.NConvert.ToInt32(symptomInfo.SortID), symptomInfo.ID, symptomInfo.Name);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错!" + ex.Message;
                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据随访记录明细ID删除其所有的症状表现记录
        /// </summary>
        /// <param name="recordID">随访记录明细ID</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int DeleteSymptom(int recordID)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.DeleteSymptom", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.DeleteSymptom字段!";
                return -1;
            }
            try
            {
                //传递参数
                strSQL = string.Format(strSQL, recordID);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错!" + ex.Message;
                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region  查询

        /// <summary>
        /// 查询随访明细
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="type">A 全部、1 有结果、0 无结果</param>
        /// <param name="cardNo">病历号</param>
        /// <returns>返回查询的数组、失败返回null</returns>
        public ArrayList Select(DateTime beginTime, DateTime endTime, char type, string cardNo)
        {
            string strSQL = "";
            string strSQL1 = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.Select字段！";
                return null;
            }

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.Where", ref strSQL1) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.Where字段！";
                return null;
            }

            try
            {
                //传入参数 {D943E66E-9E08-4e06-9052-B79388DAB7B4}
                strSQL1 = string.Format(strSQL1, beginTime, endTime, type, cardNo);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return null;
            }

            strSQL = strSQL + "\n" + strSQL1;

            //执行SQL语句
            return ExecQueryBySQL(strSQL);
        }

        /// <summary>
        /// 根据SQl语句读取随访明细信息
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        private ArrayList ExecQueryBySQL(string strSQL)
        {
            this.ExecQuery(strSQL);

            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord = null;

            try
            {
                while (this.Reader.Read())
                {
                    visitRecord = new Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord();

                    visitRecord.ID = this.Reader[0].ToString();
                    visitRecord.Patient.PID.CardNO = this.Reader[1].ToString();
                    visitRecord.Circs.ID = this.Reader[2].ToString();

                    
                    visitRecord.DeadReason.ID = this.Reader[3].ToString();
                    
                    visitRecord.DeadTime = NConvert.ToDateTime(this.Reader[4].ToString());
                    if (this.Reader[5].ToString().Equals("1"))
                    {
                        visitRecord.IsDead = true;
                    }
                    else
                    {
                        visitRecord.IsDead = false;
                    }
                    if (this.Reader[6].ToString().Equals("1"))
                    {
                        visitRecord.IsRecrudesce = true;
                    }
                    else
                    {
                        visitRecord.IsRecrudesce = false;
                    }
                    if (this.Reader[7].ToString().Equals("1"))
                    {
                        visitRecord.IsSequela = true;
                    }
                    else
                    {
                        visitRecord.IsSequela = false;
                    }
                    if (this.Reader[8].ToString().Equals("1"))
                    {
                        visitRecord.IsSuccess = true;
                    }
                    else
                    {
                        visitRecord.IsSuccess = false;
                    }
                    if (this.Reader[9].ToString().Equals("1"))
                    {
                        visitRecord.IsTransfer = true;
                    }
                    else
                    {
                        visitRecord.IsTransfer = false;
                    }
                    visitRecord.RecrudesceTime = NConvert.ToDateTime(this.Reader[10].ToString());
                    visitRecord.ResultOper.ID = this.Reader[11].ToString();
                    visitRecord.ResultOper.OperTime = NConvert.ToDateTime(this.Reader[12].ToString());
                    visitRecord.Sequela.ID = this.Reader[13].ToString();
                    
                    visitRecord.Symptom.ID = this.Reader[14].ToString();
                    visitRecord.TransferPosition.ID = this.Reader[15].ToString();
                    
                    visitRecord.VisitOper.ID = this.Reader[16].ToString();
                    visitRecord.VisitOper.OperTime = NConvert.ToDateTime(this.Reader[17].ToString());
                    visitRecord.VisitType.ID = this.Reader[18].ToString();

                    #region {E9F858A6-BDBC-4052-BA57-68755055FB80}

                    //随访方式
                    visitRecord.VisitType.Name = this.Reader[44].ToString();
                    visitRecord.Symptom.Name = this.Reader[45].ToString();
                    visitRecord.VisitResult.Name = this.Reader[46].ToString();


                    #endregion

                    visitRecord.WriteBackPerson = this.Reader[19].ToString();
                    if (this.Reader[20].ToString().Equals("1"))
                    {
                        visitRecord.IsPassive = true;
                    }
                    else
                    {
                        visitRecord.IsPassive = false;
                    }
                    if (this.Reader[21].ToString().Equals("1"))
                    {
                        visitRecord.LinkWay.IsLinkMan = true;
                    }
                    else
                    {
                        visitRecord.LinkWay.IsLinkMan = false;
                    }
                    visitRecord.LinkWay.LinkMan.Name = this.Reader[22].ToString();
                    visitRecord.LinkWay.LinkWayType.ID = this.Reader[23].ToString();
                    visitRecord.LinkWay.Relation.ID = this.Reader[24].ToString();
                    if (this.Reader[25].ToString().Equals("1"))
                    {
                        visitRecord.IsResult = true;
                    }
                    else
                    {
                        visitRecord.IsResult = false;
                    }
                    visitRecord.LinkWay.ZIP = this.Reader[26].ToString();
                    //visitRecord.ResultOper.Name = this.Reader[37].ToString();
                    if (this.Reader[27].ToString().Equals("1"))
                    {
                        visitRecord.IsWorkLoad = true;
                    }
                    else
                    {
                        visitRecord.IsWorkLoad = false;
                    }
                    visitRecord.LinkWay.Address = this.Reader[28].ToString();
                    visitRecord.LinkWay.Mail = this.Reader[29].ToString();
                    visitRecord.LinkWay.Phone = this.Reader[30].ToString();
                    visitRecord.LinkWay.OtherLinkway = this.Reader[31].ToString();
                    visitRecord.User01 = this.Reader[32].ToString();
                    visitRecord.User02 = this.Reader[33].ToString();
                    visitRecord.User03 = this.Reader[34].ToString();
                    visitRecord.Circs.Name = this.Reader[35].ToString();
                    visitRecord.DeadReason.Name = this.Reader[36].ToString();
                    visitRecord.Sequela.Name = this.Reader[37].ToString();
                    visitRecord.TransferPosition.Name = this.Reader[38].ToString();
                    visitRecord.LinkWay.LinkWayType.Name = this.Reader[39].ToString();
                    visitRecord.LinkWay.Relation.Name = this.Reader[40].ToString();
                    visitRecord.ResultOper.Name = this.Reader[41].ToString();
                    visitRecord.VisitOper.Name = this.Reader[42].ToString();



                    list.Add(visitRecord);
                }
            }
            catch (Exception ex)
            {
                this.Err = "读取随访明细出错！" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return list;
        }

        /// <summary>
        /// 根据随访记录明细ID读取其所有的症状表现
        /// </summary>
        /// <param name="recordID">随访记录明细ID</param>
        /// <returns>返回查询的数组、失败返回null</returns>
        public ArrayList SelectSymptom(int recordID)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.SelectSymptom", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.SelectSymptom字段！";
                return null;
            }
            try
            {
                //传入参数
                strSQL = string.Format(strSQL, recordID);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return null;
            }

            //执行SQL语句
            this.ExecQuery(strSQL);

            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.Base.Const symptom = null;

            try
            {
                while (this.Reader.Read())
                {
                    symptom = new Neusoft.HISFC.Models.Base.Const();
                    symptom.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0].ToString());
                    symptom.ID = this.Reader[1].ToString();
                    symptom.Name = this.Reader[2].ToString();
                    list.Add(symptom);
                }
            }
            catch (Exception ex)
            {
                this.Err = "读取症状表现出错" + ex.Message;

                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return list;
        }

        #region {E9F858A6-BDBC-4052-BA57-68755055FB80}

       

        /// <summary>
        /// 查询待随访患者列表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int PatQuery(ref System.Data.DataSet ds)
        {
            string strSQL = string.Empty;
            string strWhere = string.Empty;

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.Visit.PatQuery", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.Query字段!";
                return -1;
            }

            if (this.Sql.GetSql("HealthReacord.Visit.Visit.PatQueryWait", ref strWhere) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.Visit.PatQueryWait字段!";
                return -1;
            }

            try
            {
                strWhere = string.Format(strWhere, this.Operator.ID);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }


            //执行SQL语句并返回
            return this.ExecQuery(strSQL + strWhere, ref ds);
        }

        /// <summary>
        /// 查询已随访患者列表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int PatQueryAlready(ref System.Data.DataSet ds)
        {
            string strSQL = string.Empty;
            string strWhere = string.Empty;

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.Visit.PatQuery", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.Query字段!";
                return -1;
            }

            if (this.Sql.GetSql("HealthReacord.Visit.Visit.PatQueryAlready", ref strWhere) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.Visit.PatQueryAlready字段!";
                return -1;
            }

            try
            {
                strWhere = string.Format(strWhere, this.Operator.ID);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }


            //执行SQL语句并返回
            return this.ExecQuery(strSQL + strWhere, ref ds);
        }

        /// <summary>
        /// 查询不随访患者列表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int PatQueryOff(ref System.Data.DataSet ds)
        {
            string strSQL = string.Empty;

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.Visit.PatQueryOff", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.PatQueryOff字段!";
                return -1;
            }



            //执行SQL语句并返回
            return this.ExecQuery(strSQL, ref ds);
        }

        /// <summary>
        /// 查询已出院患者的随访情况
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int OutPatientQuery(ref System.Data.DataSet ds)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.OutPatientSelect", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.OutPatientSelect字段!";
                return -1;
            }

            //执行SQL语句并返回
            return this.ExecQuery(strSQL, ref ds);
        }

        /// <summary>
        /// 按ICD范围查询已出院患者的随访情况
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int OutPatientQueryByICD(ref System.Data.DataSet ds,string icdRange)
        {
            string strSQL = "";
            string strWhere = string.Empty;

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.OutPatientSelect", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.OutPatientSelect字段!";
                return -1;
            }

            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.OutPatientWhereByICD", ref strWhere) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.OutPatientWhereByICD字段!";
                return -1;
            }


            try
            {
                strWhere = string.Format(strWhere, icdRange);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }


            strSQL = strSQL + strWhere;

            //执行SQL语句并返回
            return this.ExecQuery(strSQL, ref ds);
        }


        /// <summary>
        /// 按病案号查询随访明细
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>失败返回 -1</returns>
        public ArrayList QueryByCardNo(string cardNo)
        {
            string strSQL = "";
            string strSQL1 = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.Select字段！";
                return null;
            }

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.WhereByCardNo", ref strSQL1) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.WhereByCardNo字段！";
                return null;
            }

            try
            {
                strSQL1 = string.Format(strSQL1,cardNo);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return null;
            }

            strSQL = strSQL + "\n" + strSQL1;

            //执行SQL语句
            return ExecQueryBySQL(strSQL);
        }

        /// <summary>
        /// 删除随访明细
        /// </summary>
        /// <param name="recordID">随访明细记录ID</param>
        /// <returns></returns>
        public int DelVisitRecord(string recordID)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.DeleteBySeqNo", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.DeleteBySeqNo字段!";
                return -1;
            }

            try
            {
                strSQL = string.Format(strSQL, recordID);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新待随访患者列表
        /// </summary>
        /// <returns>成功返回 0;失败返回 -1</returns>
        public int RefreshVisitList()
        {
            //待随访用户主要信息
            System.Data.DataSet ds = new System.Data.DataSet(); 

            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.VisitSelect", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.VisitSelect字段!";
                return -1;
            }

            if (this.ExecQuery(strSQL, ref ds) ==-1)
            {
                this.Err = "获取待随访用户信息失败";
                return -1;
            }

            if (ds.Tables.Count == 0)
            {
                this.Err = "获取待随访用户信息失败";
                return -1;
            }

            foreach(System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    InsertVisit(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                catch
                {
                    continue;
                }
            }

            return 0;
            

        }

        /// <summary>
        /// 插入随访用户列表
        /// </summary>
        /// <param name="patientNo">住院号</param>
        /// <param name="cardNo">病历号</param>
        /// <param name="lastTime">末次随访时间</param>
        /// <returns>成功返回 0 ; 失败返回 -1</returns>
        public int InsertVisit(string patientNo,string cardNo,string lastTime)
        {
           
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.VisitInsert", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitRecord.VisitInsert字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, patientNo, cardNo, lastTime);
            }
            catch(Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSQL);

        }


        #endregion

        #endregion
    }
}
