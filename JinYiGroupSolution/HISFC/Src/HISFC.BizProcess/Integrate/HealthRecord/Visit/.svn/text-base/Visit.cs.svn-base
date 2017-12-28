using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Visit
{
    /// <summary>
    /// [功能描述: 随访业务组合类]<br></br>
    /// [创 建 者: 王立]<br></br>
    /// [创建时间: 2007-8-22]<br></br>
    ///  <修改记录
    ///		修改人=金鹤'
    ///     新增方法,插入随访明细,并更新随访主记录
    ///     {E9F858A6-BDBC-4052-BA57-68755055FB80}
    ///     '
    ///		修改时间='2009-09-21'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Visit : IntegrateBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Visit()
        {
            
        }
     

        #region 变量

        /// <summary>
        /// 随访主记录管理类
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.HealthRecord.Visit.Visit visitManager = new Neusoft.HISFC.BizLogic.HealthRecord.Visit.Visit();

        /// <summary>
        /// 随访明细管理类
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.HealthRecord.Visit.VisitRecord visitRecordManager = new Neusoft.HISFC.BizLogic.HealthRecord.Visit.VisitRecord();

        /// <summary>
        /// 常数管理类
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.Manager.Constant constFunction = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 联系方式管理类
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.HealthRecord.Visit.LinkWay linkWayManager = new Neusoft.HISFC.BizLogic.HealthRecord.Visit.LinkWay();

        #endregion    

        #region 随访主记录

        /// <summary>
        /// 插入一条随访主记录
        /// </summary>
        /// <param name="visit">随访主记录实体类</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int InsertVisit(Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit)
        {
            this.SetDB(visitManager);

            int intReturn = visitManager.Insert(visit);
            if (intReturn < 0)
            {
                this.Err = visitManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 更新随访主记录
        /// </summary>
        /// <param name="visit">随访主记录实体类</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int UpdateVisit(Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit)
        {
            this.SetDB(visitManager);

            int intReturn = visitManager.Update(visit);
            if (intReturn < 0)
            {
                this.Err = visitManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 将某个患者的随访状态设为停止随访
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>影响的行数；-1－失败</returns>
        public int UpdateVisitStat(string cardNo)
        {
            this.SetDB(visitManager);

            int intReturn = visitManager.UpdateStat(cardNo);
            if (intReturn != 1)
            {
                this.Err = visitManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 根据病历号查询随访主记录
        /// </summary>
        /// <param name="visit">随访主记录实体类</param>
        /// <param name="cardNo">病历号</param>
        /// <returns>1 查询出结果、0 没有查询到结果、-1 失败</returns>   
        public int GetVisitInfo(ref Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit, string cardNo)
        {
            this.SetDB(visitManager);

            int intReturn = visitManager.Select(ref visit, cardNo);
            if (intReturn < 0)
            {
                this.Err = visitManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 传入病历号判断该患者是否已经停止随访 （供医生站提示医生录入随访信息使用）
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>-1 失败、0 停止随访、1 正常随访</returns>
        public int IsVisitStop(string cardNo)
        {
            this.SetDB(visitManager);

            int intReturn = visitManager.IsVisitStop(cardNo);
            if (intReturn == -1)
            {
                this.Err = visitManager.Err;

                return -1;
            }

            return intReturn;
        }
        #endregion

        #region 联系方式

        /// <summary>
        /// 插入一条联系方式记录
        /// </summary>
        /// <param name="linkway">联系方式实体类</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int InsertLinkWay(Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkway)
        {
            this.SetDB(linkWayManager);

            int intReturn = linkWayManager.Insert(linkway);
            if (intReturn < 0)
            {
                this.Err = linkWayManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 删除一条联系方式记录
        /// </summary>
        /// <param name="linkWayID">联系方式流水号</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int DeleteLinkWayByLinkID(string linkWayID)
        {
            this.SetDB(linkWayManager);

            int intReturn = linkWayManager.DeleteByLinkWayID(linkWayID);
            if (intReturn < 0)
            {
                this.Err = linkWayManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 删除某个患者的所有联系方式
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int DeleteLinkWayByCardNo(string cardNo)
        {
            this.SetDB(linkWayManager);

            int intReturn = linkWayManager.DeleteByCardNo(cardNo);
            if (intReturn < 0)
            {
                this.Err = linkWayManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 根据电话号码患者的联系方式
        /// </summary>
        /// <param name="Phone">电话号码</param>
        /// <returns>返回数组、失败返回null</returns>
        public ArrayList GetLinkWayByPhone(string phone)
        {
            this.SetDB(linkWayManager);

            ArrayList temp = new ArrayList();
            temp = linkWayManager.SelectByPhone(phone);
            if (temp == null)
            {
                this.Err = linkWayManager.Err;
                return null;
            }

            return temp;
        }

        /// <summary>
        /// 根据姓名查询联系方式
        /// </summary>
        /// <param name="Phone">姓名</param>
        /// <returns>返回数组、失败返回null</returns>
        public ArrayList GetLinkWayByName(string name)
        {
            this.SetDB(linkWayManager);

            ArrayList temp = new ArrayList();
            temp = linkWayManager.SelectByName(name);
            if (temp == null)
            {
                this.Err = linkWayManager.Err;
                return null;
            }

            return temp;
        }

        /// <summary>
        /// 根据地址查询联系方式
        /// </summary>
        /// <param name="Phone">地址</param>
        /// <returns>返回数组、失败返回null</returns>
        public ArrayList GetLinkWayByAddress(string address)
        {
            this.SetDB(linkWayManager);

            ArrayList temp = new ArrayList();
            temp = linkWayManager.SelectByAddress(address);
            if (temp == null)
            {
                this.Err = linkWayManager.Err;
                return null;
            }

            return temp;
        }

        /// <summary>
        /// 根据病历号读取患者的联系方式
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>返回数组、失败返回null</returns>
        public ArrayList GetLinkWayByCard(string cardNo)
        {
            this.SetDB(linkWayManager);

            ArrayList temp = new ArrayList();
            temp = linkWayManager.SelectByCardNo(cardNo);
            if (temp == null)
            {
                this.Err = linkWayManager.Err;
                return null;
            }

            return temp;
        }

        #endregion

        #region 随访明细

        /// <summary>
        /// 插入随访记录明细
        /// </summary>
        /// <param name="visitRecord">随访明细记录</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int InsertVisitRecordInfo(Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord, string sequ)
        {
            this.SetDB(visitRecordManager);

            int intReturn = visitRecordManager.Insert(visitRecord, sequ);
            if (intReturn < 0)
            {
                this.Err = visitRecordManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 获取随访明细流水号
        /// </summary>
        /// <returns>流水号</returns>
        public string GetVisitRecordSequ()
        {
            this.SetDB(visitRecordManager);

            string strReturn = visitRecordManager.GetVisitRecordSequ();
            if (strReturn == null)
            {
                this.Err = visitRecordManager.Err;

                return null;
            }

            return strReturn;
        }

        /// <summary>
        /// 更新随访记录明细
        /// </summary>
        /// <param name="visitRecord">随访明细记录</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int UpdateVisitRecord(Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord)
        {
            this.SetDB(visitRecordManager);

            int intReturn = visitRecordManager.Update(visitRecord);
            if (intReturn < 0)
            {
                this.Err = visitRecordManager.Err;
                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 查询随访明细
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="type">是否有结果</param>
        /// <param name="cardNo">病历号</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList GetVisitRecordInfo(DateTime beginTime, DateTime endTime, char type, string cardNo)
        {
            this.SetDB(visitRecordManager);

            ArrayList temp = new ArrayList();
            temp = visitRecordManager.Select(beginTime, endTime, type, cardNo);
            if (temp == null)
            {
                this.Err = visitRecordManager.Err;
                return null;
            }

            return temp;
        }

        /// <summary>
        /// 根据随访记录明细ID删除其所有的症状表现记录
        /// </summary>
        /// <param name="recordID">随访记录明细ID</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int DeleteSymptom(int recordID)
        {
            this.SetDB(visitRecordManager);

            int intReturn = visitRecordManager.DeleteSymptom(recordID);
            if (intReturn < 0)
            {
                this.Err = visitRecordManager.Err;

                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 向随访明细症状表现表中插入一条新记录,将随访记录明细的ID存在常数实体的SortID中
        /// </summary>
        /// <returns>影响的行数、-1 失败</returns>
        public int InsertSymptom(Neusoft.HISFC.Models.Base.Const symptom)
        {
            this.SetDB(visitRecordManager);

            int intReturn = visitRecordManager.InsertSymptom(symptom);
            if (intReturn <= 0)
            {
                this.Err = visitRecordManager.Err;

                return -1;
            }

            return intReturn;
        }

        /// <summary>
        /// 根据随访记录明细ID读取其所有的症状表现
        /// </summary>
        /// <param name="recordID">随访记录明细ID</param>
        /// <returns>返回查询的数组、失败返回null</returns>
        public ArrayList GetSymptom(int recordID)
        {
            this.SetDB(visitRecordManager);

            ArrayList temp = visitRecordManager.SelectSymptom(recordID);
            if (temp == null)
            {
                this.Err = visitRecordManager.Err;

                return null;
            }

            return temp;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取系统当前时间
        /// </summary>
        /// <returns>系统当前时间</returns>
        public DateTime GetCurrentDateTime()
        {
            return visitManager.GetDateTimeFromSysDateTime();
        }

        /// <summary>
        /// 从字典表中获取所有的随访方式联系方法等等，用于初始化
        /// </summary>
        /// <param name="constType">常数类型</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList GetVisitConst(string constType)
        {
            this.SetDB(constFunction);

            ArrayList temp = new ArrayList();
            temp = constFunction.GetList(constType);
            if (temp == null)
            {
                this.Err = constFunction.Err;
                return null;
            }

            return temp;
        }

        /// <summary>
        /// 事务设置
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            visitManager.SetTrans(trans);
            constFunction.SetTrans(trans);
            visitRecordManager.SetTrans(trans);
            linkWayManager.SetTrans(trans);
        }

        #region {E9F858A6-BDBC-4052-BA57-68755055FB80}

        /// <summary>
        /// 新增方法,插入随访明细,并更新随访主记录
        /// </summary>
        /// <param name="visitRecord">随访明细实体</param>
        /// <param name="sequ">随访记录唯一ID</param>
        /// <param name="visit">随访主记录实体</param>
        /// <returns>成功返回 0;失败返回 -1;</returns>
        public int InsertAndUpdateVisit(Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord
            , string sequ, Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit)
        {
            if (InsertVisitRecordInfo(visitRecord, sequ) == -1)
            {
                return -1;
            }
            if (UpdateVisit(visit) == -1)
            {
                return -1;
            }
            return 0;
        }

        
        #endregion

       

        #endregion
    }
}
