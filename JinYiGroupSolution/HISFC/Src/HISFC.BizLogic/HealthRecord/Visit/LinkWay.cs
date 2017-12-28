using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Function;
using System.Data;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Visit
{

    /// <summary>
    /// LinkWay<br></br>
    /// [功能描述: 随访联系方式基本业务层]<br></br>
    /// [创 建 者: 王立]<br></br>
    /// [创建时间: 2007-08-23]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class LinkWay :Neusoft.FrameWork.Management.Database
    {
        #region  数据库基本操作

        /// <summary>
        /// 插入一条联系方式记录
        /// </summary>
        /// <param name="linkway">联系方式类</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkway)
        {
            string strSQL = "";
            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.Insert字段！";
                return -1;
            }
            try
            {
                //取联系方式流水号
                linkway.ID = this.GetSequence("HealthReacord.Visit.LinkWay.GetLinkWayID");
                if (linkway.ID == null)
                {
                    return -1;
                }
                //获取传递参数
                string[] strParm = this.GetLinkWayParmItem(linkway);
                strSQL = string.Format(strSQL, strParm);

            }
            catch(Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }

            //执行SQL语句返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除一条联系方式记录
        /// </summary>
        /// <param name="linkway">联系方式类</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int DeleteByLinkWayID(string linkWayID)
        {
            string strSQL = "";

            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.DeleteByLinkID", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.DeleteByLinkID字段！";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, linkWayID);
            }
            catch(Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }


        /// <summary>
        /// 删除某个患者的所有联系方式
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int DeleteByCardNo(string cardNo)
        {
            string strSQL = "";

            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.DeleteByCardNo", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.DeleteByCardNo字段！";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, cardNo);
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
        /// 根据卡号查询联系方式
        /// </summary>
        /// <param name="CardNo">病历号</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList SelectByCardNo(string cardNo)
        {
            string strSQL = "";
            string strSQL1 = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.Select字段！";
                return null;
            }
            //读取where语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.SelectWhereByCardNo", ref strSQL1) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.SelectWhereByCardNo字段！";
                return　null;
            }
            strSQL = strSQL + "\n" + strSQL1;
            try
            {
                //传入病历号参数
                strSQL = string.Format(strSQL, cardNo);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return null;
            }

            //返回数组
            return this.ReadLinkWayInfo(strSQL);           
        }

        /// <summary>
        /// 根据电话号码查询
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList SelectByPhone(string phone)
        {
            string strSQL = "";
            string strSQL1 = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.Select字段！";
                return null;
            }
            //读取where语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.SelectWhereByPhone", ref strSQL1) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.SelectWhereByPhone字段！";
                return null;
            }
            strSQL = strSQL + "\n" + strSQL1;
            try
            {
                //传入病历号参数
                strSQL = string.Format(strSQL, phone);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return null;
            }

            //返回数组
            return this.ReadLinkWayInfo(strSQL);         
        }

        /// <summary>
        /// 根据姓名查询联系方式
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList SelectByName(string name)
        {
            string strSQL = "";
            string strSQL1 = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.Select字段！";
                return null;
            }
            //读取where语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.SelectWhereByName", ref strSQL1) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.SelectWhereByName字段！";
                return null;
            }
            strSQL = strSQL + "\n" + strSQL1;
            try
            {
                //传入病历号参数
                strSQL = string.Format(strSQL, name);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return null;
            }

            //返回数组
            return this.ReadLinkWayInfo(strSQL);
        }

        /// <summary>
        /// 根据姓名查询联系方式
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList SelectByAddress(string address)
        {
            string strSQL = "";
            string strSQL1 = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.Select字段！";
                return null;
            }
            //读取where语句
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.SelectWhereByAddress", ref strSQL1) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.LinkWay.SelectWhereByAddress字段！";
                return null;
            }
            strSQL = strSQL + "\n" + strSQL1;
            try
            {
                //传入病历号参数
                strSQL = string.Format(strSQL, address);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return null;
            }

            //返回数组
            return this.ReadLinkWayInfo(strSQL);
        }

        /// <summary>
        /// 获取Insert的参数
        /// </summary>
        /// <param name="linkway">联系方式实体类</param>
        /// <returns>返回参数数组</returns>
        private string[] GetLinkWayParmItem(Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkway)
        {
            string[] strParm =new string[17];
            strParm[0] = linkway.ID;
            if(linkway.IsLinkMan)
            {
                strParm[1] = "1";
            }
            else
            {
                strParm[1] = "0";
            }          
            strParm[2] = linkway.LinkMan.Name;
            strParm[3] = linkway.LinkWayType.ID;
            strParm[4] = linkway.Relation.ID;
            strParm[5] = linkway.Patient.PID.CardNO;
            strParm[6] = linkway.ZIP;
            strParm[7] = linkway.OperEnvi.ID;
            strParm[8] = linkway.OperEnvi.OperTime.ToString();
            strParm[9] = linkway.Address;
            strParm[10] = linkway.Mail;
            strParm[11] = linkway.Phone;
            strParm[12] = linkway.OtherLinkway;
            strParm[13] = linkway.Memo;
            strParm[14] = linkway.User01;
            strParm[15] = linkway.User02;
            strParm[16] = linkway.User03;
            //返回数组
            return strParm;

        }

        /// <summary>
        /// 执行SQL语句，读取linkWay实体信息到ArrayList中
        /// </summary>
        /// <param name="strSQL">需要执行的SQL语句</param>
        /// <returns>返回数组、错误返回null</returns>
        private ArrayList ReadLinkWayInfo(string strSQL)
        {
            this.ExecQuery(strSQL);

            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkWay = null;

            try
            {
                while (this.Reader.Read())
                {
                    linkWay = new Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay();

                    linkWay.ID = this.Reader[0].ToString();
                    if (this.Reader[1].ToString().Equals("1"))
                    {
                        linkWay.IsLinkMan = true;
                    }
                    else
                    {
                        linkWay.IsLinkMan = false;
                    }
                    linkWay.LinkMan.Name = this.Reader[2].ToString();
                    linkWay.LinkWayType.ID = this.Reader[3].ToString();
                    linkWay.Relation.ID = this.Reader[4].ToString();
                    linkWay.Patient.PID.CardNO = this.Reader[5].ToString();
                    linkWay.ZIP = this.Reader[6].ToString();
                    linkWay.OperEnvi.ID = this.Reader[7].ToString();
                    linkWay.OperEnvi.OperTime = NConvert.ToDateTime(this.Reader[8].ToString());
                    linkWay.Address = this.Reader[9].ToString();
                    linkWay.Mail = this.Reader[10].ToString();
                    linkWay.Phone = this.Reader[11].ToString();
                    linkWay.OtherLinkway = this.Reader[12].ToString();
                    linkWay.Memo = this.Reader[13].ToString();
                    linkWay.User01 = this.Reader[14].ToString();
                    linkWay.User02 = this.Reader[15].ToString();
                    linkWay.User03 = this.Reader[16].ToString();
                    linkWay.LinkWayType.Name = this.Reader[17].ToString();
                    linkWay.Relation.Name = this.Reader[18].ToString();
                    linkWay.OperEnvi.Name = this.Reader[19].ToString();

                    list.Add(linkWay);
                }
            }
            catch (Exception ex)
            {
                this.Err = "读取联系方式出错！" + ex.Message;
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
        /// 根据住院号或者病历号查询患者联系人信息
        /// </summary>
        /// <param name="patientNo">住院号</param>
        /// <param name="cardNo">病历号</param>
        /// <returns></returns>
        public ArrayList QueryLinkWay(string patientNo, string cardNo)
        {
            //获取主sql语句
            string strSQL = string.Empty;
            string str = "";
            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.QueryLinkWay", ref strSQL) == -1)
            {
                this.Err = "获取SQL语句:HealthReacord.Visit.VisitRecord.QueryLinkWay 失败";
                return null;
            }

            if (this.Sql.GetSql("HealthReacord.Visit.VisitRecord.WhereLinkWay", ref str) == -1)
            {
                this.Err = "获取SQL语句:HealthReacord.Visit.VisitRecord.WhereLinkWay 失败";
                return null;
            }
            strSQL += str;
            strSQL = string.Format(strSQL, patientNo, cardNo);

            return QueryLinkWayBySql(strSQL);
        }


        /// <summary>
        /// 根据SQL语句，查询患者联系人列表
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList QueryLinkWayBySql(string strSql)
        {
            this.ExecQuery(strSql);

            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkWay = null;

            try
            {
                while (this.Reader.Read())
                {
                    linkWay = new Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay();

                    linkWay.ID = this.Reader[0].ToString();//唯一编号
                    linkWay.Name = this.Reader[1].ToString();//联系人
                    linkWay.Memo = this.Reader[2].ToString();//与患者关系
                    linkWay.Phone = this.Reader[3].ToString();//联系电话
                    linkWay.User01 = this.Reader[4].ToString();//电话状态
                    linkWay.Address = this.Reader[5].ToString();//联系地址
                    linkWay.Mail = this.Reader[6].ToString();//Email

                    list.Add(linkWay);
                }
            }
            catch (Exception ex)
            {
                this.Err = "读取联系方式出错！" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return list;
        }

        /// <summary>
        /// 插入联系人
        /// </summary>
        /// <param name="linkWayObj"></param>
        /// <returns></returns>
        public int InsertLinkWay(Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkWayObj)
        {
            //获取主sql语句
            string strSQL = string.Empty;
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.InsertLinkWay", ref strSQL) == -1)
            {
                this.Err = "获取SQL语句:HealthReacord.Visit.LinkWay.InsertLinkWay 失败";
                return -1;
            }

            linkWayObj.ID = GetLinkWaySeqNo();//获取唯一ID

            //获取传递参数
            string[] strParm = GetLinkWayParm(linkWayObj);

            strSQL = string.Format(strSQL, strParm);

            return this.ExecNoQuery(strSQL);
      
        }

        /// <summary>
        /// 更新联系人
        /// </summary>
        /// <param name="linkWayObj">联系方式实体类</param>
        /// <returns>失败返回-1</returns>
        public int UpdateInsertLinkWay(Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkWayObj)
        {
            //获取主sql语句
            string strSQL = string.Empty;
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.UpdateLinkWay", ref strSQL) == -1)
            {
                this.Err = "获取SQL语句:HealthReacord.Visit.LinkWay.UpdateLinkWay 失败";
                return -1;
            }

            //获取传递参数
            string[] strParm = GetLinkWayParm(linkWayObj);

            strSQL = string.Format(strSQL, strParm);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="linkWayObj">联系方式实体类</param>
        /// <returns>失败返回-1</returns>
        public int DelLinkWay(Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkWayObj)
        {
            //获取主sql语句
            string strSQL = string.Empty;
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.DeleteLinkWay", ref strSQL) == -1)
            {
                this.Err = "获取SQL语句:HealthReacord.Visit.LinkWay.DeleteLinkWay 失败";
                return -1;
            }

            strSQL = string.Format(strSQL, linkWayObj.ID);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取联系人唯一标志
        /// </summary>
        /// <returns></returns>
        private string GetLinkWaySeqNo()
        {
            //获取主sql语句
            string strSQL = string.Empty;
            if (this.Sql.GetSql("HealthReacord.Visit.LinkWay.NewLinkWayNo", ref strSQL) == -1)
            {
                this.Err = "获取SQL语句:HealthReacord.Visit.LinkWay.NewLinkWayNo 失败";
                return null;
            }

            return this.ExecSqlReturnOne(strSQL);
        }


        /// <summary>
        /// 获取SQL语句参数
        /// </summary>
        /// <param name="linkWayObj">联系方式实体类</param>
        /// <returns>返回参数数组</returns>
        private string[] GetLinkWayParm(Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkWayObj)
        {
            return new string[] { linkWayObj.ID, //唯一编号
                linkWayObj.Patient.PID.PatientNO, //住院号
                linkWayObj.Patient.PID.CardNO, //病历号
                linkWayObj.Name ,//联系人
                linkWayObj.Memo,//与患者关系
                linkWayObj.Address,//地址
                linkWayObj.Mail,//电子邮箱
                linkWayObj.Phone,//联系电话
                linkWayObj.User01,//电话状态
                this.Operator.ID,//操作员
                this.GetSysDateTime()//操作时间
            };
        }

        #endregion

        #endregion
    }
}
