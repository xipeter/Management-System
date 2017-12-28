using System;
using System.Collections;
//{55BBD9DB-F5C9-4e0a-94E5-9F7FCB121350}
using System.Collections.Generic;
namespace Neusoft.HISFC.BizLogic.Order.OutPatient
{
	/// <summary>
	/// Order 的摘要说明。
	/// 门诊医嘱
	/// </summary>
	public class Order:Neusoft.FrameWork.Management.Database
	{
		public Order()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		

		#region 基本操作，增删改

		/// <summary>
		/// 插入一条
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public int InsertOrder(Neusoft.HISFC.Models.Order.OutPatient.Order order)
		{
			string sql = "Order.OutPatient.Order.Insert";
			if (this.Sql.GetSql(sql,ref sql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			sql = this.myGetSql( sql,order );
			if(sql == null) return -1;
			if(this.ExecNoQuery(sql) <= 0) return -1;
			return 0;
		}

		
		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public int UpdateOrder(Neusoft.HISFC.Models.Order.OutPatient.Order order)
		{
            if (this.DeleteOrder(order.SeeNO, Neusoft.FrameWork.Function.NConvert.ToInt32(order.ID)) < 0) return -1;//删除不成功
			return this.InsertOrder(order);
		}
		
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="seeNo"></param>
		/// <param name="seqNo"></param>
		/// <returns></returns>
		public int DeleteOrder(string seeNo,int seqNo)
		{
			string sql = "Order.OutPatient.Order.Delete";
			if(this.Sql.GetSql(sql, ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				sql = string.Format(sql,seeNo,seqNo);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(sql);
		}
		#endregion

        #region 门诊医嘱变更表操作add by sunm

        public int InsertOrderChangeInfo(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            string sql = "Order.OutPatient.Order.InsertChangeInfo";
            if (this.Sql.GetSql(sql, ref sql) == -1) return -1;
            sql = this.myGetSql(sql, order);
            if (sql == null) return -1;
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }
        /// <summary>
        /// 更新医嘱变更纪录
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrderChangedInfo(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            string sql = "Order.OutPatient.Order.UpdateChangeInfo";
            if (this.Sql.GetSql(sql, ref sql) == -1) return -1;
            sql = System.String.Format(sql, order.DCOper.ID, order.SeeNO, order.SequenceNO);
            if (sql == null) return -1;
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 作废医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrderBeCaceled(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            string sql = "Order.OutPatient.Order.CancelOrder";
            if (this.Sql.GetSql(sql, ref sql) == -1)
            {
                this.Err = "Can't Find Sql:Order.OutPatient.Order.CancelOrder";
                return -1;
            }
            sql = System.String.Format(sql, order.ID);
            if (sql == null) return -1;
            return this.ExecNoQuery(sql);
        }

        #endregion

        #region 获得新的看诊序号
        /// <summary>
		/// 
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public int GetNewSeeNo( string cardNo )
		{
			string sql = "Order.OutPatient.Order.GetNewSeeNo.1";
			if(this.Sql.GetSql(sql,ref sql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				sql = string.Format(sql,cardNo);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return -1;
			}
			return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql));
		}
		#endregion

        /// <summary>
        /// 获得新医嘱组合序号
        /// </summary>
        /// <returns></returns>
        public string GetNewOrderComboID()
        {
            string sql = "";
            if (this.Sql.GetSql("Management.Order.GetComboID", ref sql) == -1) return null;
            string strReturn = this.ExecSqlReturnOne(sql);
            if (strReturn == "-1" || strReturn == "") return null;
            return strReturn;
        }

		#region 更新医嘱已经收费
		/// <summary>
		/// 更新医嘱已经收费
		/// </summary>
		/// <param name="orderID"></param>
		/// <returns></returns>
		public int UpdateOrderCharged(string orderID)
		{
			string sql = "Order.OutPatient.Order.Update.UpdateOrderCharged.2";
			if(this.Sql.GetSql(sql,ref sql) == -1) return -1;
			return this.ExecNoQuery(sql,orderID);
		}
		/// <summary>
		/// 更新医嘱已经收费
		/// </summary>
		/// <param name="reciptNo"></param>
		/// <param name="seqNo"></param>
		/// <returns></returns>
		public int UpdateOrderCharged(string reciptNo,string seqNo)
		{
			string sql = "Order.OutPatient.Order.Update.UpdateOrderCharged.1";
			if(this.Sql.GetSql(sql, ref sql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			return this.ExecNoQuery(sql,reciptNo,seqNo,this.Operator.ID);
		}
        /// <summary>
        /// 更新医嘱已经收费
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="chargeOperID"></param>
        /// <returns></returns>
        public int UpdateOrderChargedByOrderID(string orderID,string chargeOperID)
        {
            string sql = "Order.OutPatient.Order.Update.UpdateOrderCharged.4";
            if (this.Sql.GetSql(sql, ref sql) == -1) return -1;
            return this.ExecNoQuery(sql, orderID, chargeOperID);
        }
		#endregion

        #region  更新医嘱序号
        /// <summary>
        /// 更新医嘱序号
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="sortID"></param>
        /// <returns></returns>
        public int UpdateOrderSortID(string orderID,int sortID)
        {
            string sql = "Order.OutPatient.Order.Update.UpdateOrderSortID.1";
            if(this.Sql.GetSql(sql, ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				sql = string.Format(sql,orderID,sortID);
			}
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(sql);
        }
        #endregion

        #region  更新医嘱皮试结果
        /// <summary>
        /// 更新医嘱皮试结果//{26E88889-B2CF-4965-AFD8-6D9BE4519EBF}
        /// </summary>
        /// <param name="sequenceNO"></param>
        /// <returns></returns>
        public int UpdateOrderHyTest(string hytestValue, string sequenceNO)
        {
            string sql = "Order.OutPatient.Order.UpdateHyTest.1";
            if (this.Sql.GetSql(sql, ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                sql = string.Format(sql, hytestValue, sequenceNO);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 更新医嘱皮试结果{55BBD9DB-F5C9-4e0a-94E5-9F7FCB121350}
        /// </summary>
        /// <param name="sequenceNO"></param>
        /// <returns></returns>
        public int UpdateOrderHyTest(string hytestValue,string hytestName, string sequenceNO, string seeNO)
        {
            string sql = "Order.OutPatient.Order.UpdateHyTest.2";
            if (this.Sql.GetSql(sql, ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                sql = string.Format(sql, hytestValue, hytestName,sequenceNO, seeNO);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(sql);
        }
        //{55BBD9DB-F5C9-4e0a-94E5-9F7FCB121350}
        public List<Neusoft.FrameWork.Models.NeuObject> QueryHytoRecord(string cardNO, string beginDtime, string endDtime)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("Order.OutPatient.Order.QueryHyRecord", ref strSql);

            if (returnValue < 0)
            {
                this.Err = "查询对应[Order.OutPatient.Order.QueryHyRecord]的sql语句失败";
                return null;
            }

            try
            {
                strSql = string.Format(strSql, cardNO, beginDtime, endDtime);
            }
            catch (Exception ex)
            {

                this.Err = "格式化出错！\n" + ex.Message;
                return null;
            }

            if (this.ExecQuery(strSql) < 0)
            {
                return null;
            }
            List<Neusoft.FrameWork.Models.NeuObject> orderList = new List<Neusoft.FrameWork.Models.NeuObject>();
            while (this.Reader.Read())
            {

                Neusoft.FrameWork.Models.NeuObject order = new Neusoft.FrameWork.Models.NeuObject();
                order.ID = this.Reader[0].ToString();
                order.Name = this.Reader[1].ToString();
                order.Memo = this.Reader[2].ToString();
                orderList.Add(order);
            }

            this.Reader.Close();

            return orderList;


        }

        // 根据病历号，门诊流水号，查询需要做皮试的有效医嘱
       /// <summary>
        /// 根据病历号，门诊流水号，查询需要做皮试的有效医嘱{55BBD9DB-F5C9-4e0a-94E5-9F7FCB121350}
       /// </summary>
       /// <param name="cardNO"></param>
       /// <param name="clinicNO"></param>
       /// <returns></returns>
        public ArrayList QueryOrderByCardNOClinicNO(string cardNO,string clinicNO)
        {
            string sql = "", sqlSelect = "", sqlWhere = "Order.OutPatient.Order.Query.Where.5";
            if (this.myGetSelectSql(ref sqlSelect) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            if (this.Sql.GetSql(sqlWhere, ref sqlWhere) == -1) return null;
            sql = sqlSelect + " " + sqlWhere;
            sql = string.Format(sql, cardNO,clinicNO);
            return this.myGetExecOrder(sql);
        }

        /// <summary>
        /// 根据主键查询医嘱
        /// </summary>
        /// <param name="seeNO"></param>
        /// <param name="sqeNO"></param>
        /// <returns></returns>{55BBD9DB-F5C9-4e0a-94E5-9F7FCB121350}
        public ArrayList QueryOrderByKey(string seeNO,string sqeNO)
        {
            string sql = "", sqlSelect = "", sqlWhere = "Order.OutPatient.Order.Query.Where.6";
            if (this.myGetSelectSql(ref sqlSelect) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            if (this.Sql.GetSql(sqlWhere, ref sqlWhere) == -1) return null;
            sql = sqlSelect + " " + sqlWhere;
            sql = string.Format(sql, seeNO,sqeNO);
            return this.myGetExecOrder(sql);
        }
        #endregion

        #region 查询

        /// <summary>
		/// 查询执行医嘱--通过看诊序号查询
		/// </summary>
		/// <param name="seeNo"></param>
		/// <returns></returns>
		public ArrayList QueryOrder( string seeNo )
		{
			string sql ="",sqlSelect = "",sqlWhere = "Order.OutPatient.Order.Query.Where.1";
			if(this.myGetSelectSql(ref sqlSelect) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			if(this.Sql.GetSql(sqlWhere,ref sqlWhere) == -1) return null;
			sql = sqlSelect + " " + sqlWhere;
			sql = string.Format (sql,seeNo);
			return this.myGetExecOrder(sql);
			
		}

        /// <summary>
        /// 根据处方号查询医嘱
        /// </summary>
        /// <param name="recipeNO"></param>
        /// <returns></returns>
        public ArrayList QueryOrderByRecipeNO(string recipeNO)
        {
            string sql = "", sqlSelect = "", sqlWhere = "Order.OutPatient.Order.Query.Where.4";
            if (this.myGetSelectSql(ref sqlSelect) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            if (this.Sql.GetSql(sqlWhere, ref sqlWhere) == -1) return null;
            sql = sqlSelect + " " + sqlWhere;
            sql = string.Format(sql, recipeNO);
            return this.myGetExecOrder(sql);
        }

		/// <summary>
		/// 查询一条医嘱
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Order.OutPatient.Order QueryOneOrder(string id)
		{
			string sql ="",sqlSelect = "",sqlWhere = "Order.OutPatient.Order.Query.Where.2";
			if(this.myGetSelectSql(ref sqlSelect)==-1) return null;
			if(this.Sql.GetSql(sqlWhere,ref sqlWhere) == -1) 
			{
				this.Err = this.Sql.Err;
				return null;
			}
			sql = sqlSelect + " " + sqlWhere;
			sql = string.Format(sql,id);
			ArrayList al = this.myGetExecOrder(sql);
			if(al == null) return null;
			if(al.Count <= 0) return null;
			return al[0] as Neusoft.HISFC.Models.Order.OutPatient.Order;
		}
		/// <summary>
		/// 获得看诊序号列表
		/// </summary>
		/// <param name="cardNo">门诊卡号</param>
		/// <returns></returns>
		public ArrayList QuerySeeNoListByCardNo(string cardNo)
		{
			string sql = "Order.OutPatient.Order.GetSeeNoList";
			if(this.Sql.GetSql(sql,ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			try
			{
				sql = string.Format(sql,cardNo);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(sql) == -1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
				obj.ID = this.Reader[0].ToString();
				obj.Name = this.Reader[1].ToString();
				obj.Memo = this.Reader[2].ToString();
				try
				{
					obj.User01 = this.Reader[3].ToString();
					obj.User02  = this.Reader[4].ToString();
					obj.User03 = this.Reader[5].ToString();
				}
				catch{}
				al.Add(obj);
			}		
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 获得看诊序号列表
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public ArrayList QuerySeeNoListByCardNo( string clinicNo, string cardNo )
		{
			string sql = "Order.OutPatient.Order.GetSeeNoList.2";
			if(this.Sql.GetSql(sql,ref sql) == -1) return null;
			try
			{
				sql = string.Format(sql,clinicNo,cardNo);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(sql) == -1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
				obj.ID = this.Reader[0].ToString();
				obj.Name = this.Reader[1].ToString();
				obj.Memo = this.Reader[2].ToString();
				try
				{
					obj.User01 = this.Reader[3].ToString();
					obj.User02  = this.Reader[4].ToString();
					obj.User03 = this.Reader[5].ToString();
				}
				catch{}
				al.Add(obj);
			}		
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 查询看诊序号根据名子
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ArrayList QuerySeeNoListByName(string name)
		{
			string sql = "Order.OutPatient.Order.GetSeeNoList.Name";
			if(this.Sql.GetSql(sql,ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			try
			{
				sql = string.Format(sql,name);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(sql) == -1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
				obj.ID = this.Reader[0].ToString();
				obj.Name = this.Reader[1].ToString();
				obj.Memo = this.Reader[2].ToString();
				try
				{
					obj.User01 = this.Reader[3].ToString();
					obj.User02  = this.Reader[4].ToString();
					obj.User03 = this.Reader[5].ToString();
				}
				catch{}
				al.Add(obj);
			}		
			this.Reader.Close();
			return al;
		}

        /// <summary>
        /// 取得药品处方号通过门诊号和看诊号
        /// </summary>
        /// <param name="clinicNo"></param>
        /// <param name="seeNo"></param>
        /// <returns></returns>
        public ArrayList GetPhaRecipeNoByClinicNoAndSeeNo(string clinicNo, string seeNo)
        {
            string sql = "Order.OutPatient.Order.GetPhaRecipeNoByClinicNoAndSeeNo";
            if (this.Sql.GetSql(sql, ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                sql = string.Format(sql, clinicNo, seeNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
            if (this.ExecQuery(sql) == -1) return null;
            ArrayList alRecipe = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                
                alRecipe.Add(obj);
            }
            this.Reader.Close();
            return alRecipe;
        }

		#endregion

        #region 门诊病历

        #region 废弃的方法
        /// <summary>
        /// 根据传入的实体更新或者插入门诊病历
        /// </summary>
        /// <param name="reg"></param>
        /// <param name="casehistory"></param>
        /// <returns></returns>
       
        //public int SetCaseHistory(Neusoft.HISFC.Models.Registration.Register reg, Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory)
        //{
        //    int iReturn = this.UpdateCaseHistory(reg, casehistory);
        //    if (iReturn == -1)
        //        return -1;
        //    else if (iReturn == 0)
        //        return this.InsertCaseHistory(reg, casehistory);
        //    else
        //        return 1;
        //}
        #endregion

        /// <summary>
        /// 插入一条病历
        /// </summary>
        /// <param name="reg"></param>
        /// <param name="casehistory"></param>
        /// <returns></returns>
        public int InsertCaseHistory(Neusoft.HISFC.Models.Registration.Register reg, Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.InsertCase", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return -1;
            }
            try
            {
                strSql = System.String.Format(strSql, 
                                              reg.ID, //门诊流水号，需替换
                                              reg.PID.CardNO, 
                                              reg.Name, //患者姓名
                                              reg.Sex.Name, 
                                              reg.Age, 
                                              reg.DoctorInfo.Templet.Dept.ID, 
                                              reg.Pact.PayKind.Name,
                                              casehistory.CaseMain, 
                                              casehistory.CaseNow, 
                                              casehistory.CaseOld, 
                                              casehistory.CaseAllery, 
                                              casehistory.IsAllery == true ? "1" : "0",
                                              casehistory.IsInfect == true ? "1" : "0", 
                                              casehistory.CheckBody, 
                                              casehistory.CaseDiag, 
                                              casehistory.Memo,
                                              this.Operator.ID,casehistory.CaseOper.OperTime.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新一条病历
        /// </summary>
        /// <param name="reg"></param>
        /// <param name="casehistory"></param>
        /// <returns></returns>
        public int UpdateCaseHistory(Neusoft.HISFC.Models.Registration.Register reg, Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory,string oldOperTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.UpdateCase", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return -1;
            }
            try
            {
                /*
                 UPDATE MET_CAS_HISTORY
                    SET    CASEMAIN = '{0}',--主诉
                           CASENOW = '{1}',--现病史
                           CASEOLD = '{2}',--既往史
                           CASEALLERY = '{3}',--过敏史
                           ALLERY_FLAG = '{4}',--是否过敏
                           INFECT_FLAG = '{5}',--是否传染病
                           CHECKBODY = '{6}',--查体 
                           DIAGNOSE = '{7}',--诊断
                           MEMO = '{8}',--备注
                           OPER_CODE = '{9}',--操作员
                           OPER_DATE = to_date('{10}','YYYY-MM-DD hh24:Mi:SS')--操作日期
                    WHERE  CLINIC_CODE = '{11}'--门诊流水号 
                           and oper_date=to_date('{12}','YYYY-MM-DD hh24:Mi:SS')--操作时
                 */
                strSql = System.String.Format(strSql, 
                                              casehistory.CaseMain, 
                                              casehistory.CaseNow, 
                                              casehistory.CaseOld, 
                                              casehistory.CaseAllery, 
                                              casehistory.IsAllery == true ? "1" : "0",
                                              casehistory.IsInfect == true ? "1" : "0", 
                                              casehistory.CheckBody, 
                                              casehistory.CaseDiag, 
                                              casehistory.Memo,
                                              this.Operator.ID,
                                              casehistory.CaseOper.OperTime.ToString(),//本次操作时间
                                              reg.ID,
                                              oldOperTime //上一次的操作时间
                                              ); //门诊流水号，需替换
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 根据门诊流水号查询一条门诊病历
        /// </summary>
        /// <param name="clinicCode"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory QueryCaseHistoryByClinicCode(string clinicCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.GetCase", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            strSql = System.String.Format(strSql, clinicCode);
            ArrayList al = this.GetMyObject(strSql);
            if (al == null)
                return null;
            else if (al.Count == 0)
                return null;
            else
                return al[0] as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
        }

        /// <summary>
        /// 根据门诊流水号和操作时间查询一条门诊病历
        /// </summary>
        /// <param name="clinicCode"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory QueryCaseHistoryByClinicCode(string clinicCode,string operTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.GetCase1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return null;
            }
            strSql = System.String.Format(strSql, clinicCode,operTime);
            ArrayList al = this.GetMyObject(strSql);
            if (al == null)
                return null;
            else if (al.Count == 0)
                return null;
            else
                return al[0] as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
        }

        /// <summary>
        /// 根据门诊号查询门诊所有病历
        /// </summary>
        /// <param name="CardNO"></param>
        /// <returns></returns>
        public ArrayList QueryAllCaseHistory(string CardNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.GetAllCase", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return null;
            }
            strSql = System.String.Format(strSql, CardNO);
            return this.GetMyObjectByCardNO(strSql);
        }

        /// <summary>
        /// 通过门诊号取病历最大操作时间
        /// </summary>
        /// <param name="ClinicCode"></param>
        /// <returns></returns>
        public DateTime QueryMaxOperTimeByClinicCode(string ClinicCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.GetMaxOperDateByClinicCode", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return System.DateTime.MinValue;
            }
            strSql = System.String.Format(strSql, ClinicCode);
            string strReturn = "";
            strReturn = this.ExecSqlReturnOne(strSql);
            if (strReturn != "" && strReturn != null)
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(strReturn);
            }
            else
            {
                return System.DateTime.MinValue;
            }
        }

        #region 私有函数

        /// <summary>
        /// 得到病历实体
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList GetMyObjectByCardNO(string strSql)
        {
            ArrayList al = new ArrayList();
            if (this.ExecQuery(strSql) == -1) return null;
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();//流水号
                obj.Name = this.Reader[1].ToString();//姓名
                if (!this.Reader.IsDBNull(2))
                    obj.Memo = this.Reader[2].ToString();
                //User01是操作时间 路志鹏 2007-5-9
                obj.User01 = this.Reader[3].ToString();
                al.Add(obj);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 得到病历实体
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList GetMyObject(string strSql)
        {
            ArrayList al = new ArrayList();
            if (this.ExecQuery(strSql) == -1) return null;
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory = new Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory();
                casehistory.CaseMain = this.Reader.GetValue(0).ToString();//主诉
                casehistory.CaseNow = this.Reader.GetValue(1).ToString();//现病史
                casehistory.CaseOld = this.Reader.GetValue(2).ToString();//既往史
                casehistory.CaseAllery = this.Reader.GetValue(3).ToString();//过敏史
                casehistory.CheckBody = this.Reader.GetValue(4).ToString();//查体
                casehistory.CaseDiag = this.Reader.GetValue(5).ToString();//诊断
                casehistory.Memo = this.Reader.GetValue(6).ToString();//备注
                casehistory.Name = this.Reader.GetValue(7).ToString();//姓名
                casehistory.ID = this.Reader.GetValue(8).ToString();//门诊流水号
                if (!this.Reader.IsDBNull(9))
                    casehistory.IsAllery = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader.GetValue(9).ToString());//是否过敏
                if (!this.Reader.IsDBNull(10))
                    casehistory.IsInfect = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader.GetValue(10).ToString());//是否传染病
                //操作时间
                casehistory.CaseOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader.GetValue(11));
                al.Add(casehistory);
            }
            this.Reader.Close();
            return al;
        }

        #endregion

        #endregion

        #region 门诊病历模板

        /// <summary>
        /// 获取病历模板流水号
        /// </summary>
        /// <returns></returns>
        public string GetModuleSeq()
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.GetModuleSeq", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return "";
            }
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行错误";
                return "";
            }
            string ID = "";
            while (this.Reader.Read())
            {
                ID = this.Reader[0].ToString();
            }
            this.Reader.Close();
            ID = ID.PadLeft(10, '0');
            return ID;
        }

        /// <summary>
        /// 根据传入的实体更新或者插入门诊病历模板
        /// </summary>
        /// <param name="casehistory"></param>
        /// <returns></returns>
        public int SetCaseModule(Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory)
        {
            int i = this.UpdateCaseModule(casehistory);
            if (i == -1)
                return -1;
            else if (i == 0)
                return this.InsertCaseModule(casehistory);
            else
                return 1;
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="casehistory"></param>
        /// <returns></returns>
        public int InsertCaseModule(Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.InsertModule", ref strSql) == -1)
            {
                this.Err = "没有找到Order.OutPatient.Case.InsertModule字段";
                return -1;
            }
            try
            {
                strSql = System.String.Format(strSql, 
                                              casehistory.ID, 
                                              casehistory.Name,
                                              casehistory.DeptID, 
                                              casehistory.CaseMain,
                                              casehistory.CaseNow, 
                                              casehistory.CaseOld, 
                                              casehistory.CaseAllery, 
                                              casehistory.CheckBody, 
                                              casehistory.CaseDiag, 
                                              casehistory.Memo,
                                              casehistory.ModuleType, 
                                              casehistory.DoctID, 
                                              this.Operator.ID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新病历模板Type
        /// </summary>
        /// <param name="ModuleType">模板类型</param>
        /// <param name="Module_NO">模板ID</param>
        /// <returns></returns>
        public int UpdateCaseModuleType(string ModuleType,string Module_NO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.UpdateModuleType", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = System.String.Format(strSql,
                                              ModuleType,Module_NO);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="casehistory"></param>
        /// <returns></returns>
        public int UpdateCaseModule(Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.UpdateModule", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return -1;
            }
            try
            {   
                strSql = System.String.Format(strSql, 
                                              casehistory.Name,
                                              casehistory.DeptID, 
                                              casehistory.ModuleType, 
                                              casehistory.CaseMain,
                                              casehistory.CaseNow, 
                                              casehistory.CaseOld, 
                                              casehistory.CaseAllery, 
                                              casehistory.CheckBody, 
                                              casehistory.CaseDiag, 
                                              casehistory.Memo,
                                              casehistory.DoctID,
                                              this.Operator.ID, 
                                              casehistory.ID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="moduleNo"></param>
        /// <returns></returns>
        public int DeleteCaseModule(string moduleNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.DelModule", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return -1;
            }
            try
            {
                strSql = System.String.Format(strSql, moduleNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 根据模板流水号查询一条记录
        /// </summary>
        /// <param name="moduleNO"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory QueryCaseModule(string moduleNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OutPatient.Case.GetModule", ref strSql) == -1)
            {
                this.Err = this.Sql.Err; 
                return null;
            }
            strSql = System.String.Format(strSql, moduleNO);
            ArrayList al = this.GetMyModule(strSql);
            if (al == null)
                return null;
            else if (al.Count == 0)
                return new Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory();
            else
                return al[0] as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
        }

        /// <summary>
        /// 根据类别获得所有模板
        /// </summary>
        /// <param name="moduletype"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public ArrayList QueryAllCaseModule(string moduletype, string Code)
        {
            string strSql = "";
            if (moduletype == "1")//科室
            {
                if (this.Sql.GetSql("Order.OutPatient.Case.GetAllModuleByDeptCode", ref strSql) == -1)
                {
                    this.Err = this.Sql.Err;
                    return null;
                }
            }
            else
            {
                if (this.Sql.GetSql("Order.OutPatient.Case.GetAllModuleByOperId", ref strSql) == -1)
                {
                    this.Err = this.Sql.Err;
                    return null;
                }
            }
            strSql = System.String.Format(strSql, moduletype, Code);
            return this.GetMyModule(strSql);
        }

        #region 私有函数
        /// <summary>
        /// 得到病历模板实体
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList GetMyModule(string strSql)
        {
            ArrayList al = new ArrayList();
            if (this.ExecQuery(strSql) == -1) return null;
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory casehistory = new Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory();
                casehistory.CaseMain = this.Reader.GetValue(0).ToString();//主诉
                casehistory.CaseNow = this.Reader.GetValue(1).ToString();//现病史
                casehistory.CaseOld = this.Reader.GetValue(2).ToString();//既往史
                casehistory.CaseAllery = this.Reader.GetValue(3).ToString();//过敏史
                casehistory.CheckBody = this.Reader.GetValue(4).ToString();//查体
                casehistory.CaseDiag = this.Reader.GetValue(5).ToString();//诊断
                casehistory.Memo = this.Reader.GetValue(6).ToString();//备注
                casehistory.Name = this.Reader.GetValue(7).ToString();//模板名称
                casehistory.ID = this.Reader.GetValue(8).ToString();//模板流水号
                casehistory.ModuleType = this.Reader.GetValue(9).ToString();//类别
                casehistory.DoctID = this.Reader.GetValue(10).ToString();//医师编码
                casehistory.DeptID = this.Reader.GetValue(11).ToString();//科室
                al.Add(casehistory);
            }
            this.Reader.Close();
            return al;
        }
        #endregion

        #endregion

        #region 私有函数

        /// <summary>
		/// 获得sql，传入参数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="order"></param>
		/// <returns></returns>
		protected string myGetSql(string sql,Neusoft.HISFC.Models.Order.OutPatient.Order order)
		{
			#region sql
			//   0--看诊序号 ,1 --项目流水号,2 --门诊号,3   --病历号 ,4    --挂号日期
			//   5 --挂号科室,6   --项目代码,7   --项目名称, 8  --规格, 9  --1药品，2非药品
			//   10   --系统类别,   --最小费用代码,   --单价,   --开立数量,   --付数
			//    --包装数量,   --计价单位,   --自费金额0,   --自负金额0,   --报销金额0
			//   --基本剂量,   --自制药,   --药品性质，普药、贵药,   --每次用量
			//     --每次用量单位,   --剂型代码,   --频次,   --频次名称,   --使用方法
			//     --用法名称,   --用法英文缩写,   --执行科室代码,   --执行科室名称
			//      --主药标志,   --组合号,   --1不需要皮试/2需要皮试，未做/3皮试阳/4皮试阴
			//     --院内注射次数,   --备注,   --开立医生,   --开立医生名称,   --医生科室
			//     --开立时间,   --处方状态,1开立，2收费，3确认，4作废,   --作废人,   --作废时间
			//        --加急标记0普通/1加急,   --样本类型,   --检体,   --申请单号
			//     --0不是附材/1是附材,   --是否需要确认，1需要，0不需要,   --确认人
			//        --确认科室,   --确认时间,   --0未收费/1收费,   --收费员
            //       --收费时间,   --处方号,    --处方内流水号,     --发药药房，    
            //      --开立单位是否是最小单位 1 是 0 不是，      --医嘱类型（目前没有）
			#endregion

			//if(order.Item.IsPharmacy)//药品
            if(order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
			{
				Neusoft.HISFC.Models.Pharmacy.Item pItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                //{9BAE643C-57BF-4dc5-889E-6B5F6B3E1E38} 由于接入电子申请单，apply_no字段赋order.ApplyNo20100505 yangw
                System.Object[] s = {order.SeeNO ,Neusoft.FrameWork.Function.NConvert.ToInt32(order.ID),order.Patient.ID,order.Patient.PID.CardNO,order.RegTime,
										order.InDept.ID,pItem.ID,pItem.Name,pItem.Specs,"1",
										order.Item.SysClass.ID,order.Item.MinFee.ID,order.Item.Price,order.Qty,order.HerbalQty,
										pItem.PackQty,pItem.PriceUnit,order.FT.OwnCost ,order.FT.PayCost,order.FT.PubCost,
										pItem.BaseDose,Neusoft.FrameWork.Function.NConvert.ToInt32(pItem.Product.IsSelfMade),pItem.Quality.ID,order.DoseOnce,
										order.DoseUnit,pItem.DosageForm.ID,order.Frequency.ID,order.Frequency.Name,order.Usage.ID,
										order.Usage.Name,order.Usage.Memo,order.ExeDept.ID,order.ExeDept.Name,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.Combo.IsMainDrug),order.Combo.ID,order.HypoTest,
										order.InjectCount,order.Memo,order.ReciptDoctor.ID,order.ReciptDoctor.Name,order.ReciptDept.ID,
										order.MOTime,order.Status,order.DCOper.ID,order.DCOper.OperTime,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsEmergency),order.Sample.Name,order.CheckPartRecord,order.ApplyNo,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsSubtbl),Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsNeedConfirm),order.ConfirmOper.ID,
										order.ConfirmOper.Dept.ID,order.ConfirmOper.OperTime,Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsHaveCharged),order.ChargeOper.ID,
										order.ChargeOper.OperTime,order.ReciptNO,order.SequenceNO,
                                        order.StockDept.ID,order.NurseStation.User03,"",
                                        order.NurseStation.User01,order.ExtendFlag1,
										order.ReciptSequence,order.NurseStation.Memo,order.SortID};

				try
				{
					string sReturn = string.Format(sql,s);
					return sReturn;
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.WriteErr();
					return null;
				}
			}
			else//非药品
			{
				Neusoft.HISFC.Models.Fee.Item.Undrug pItem = order.Item as Neusoft.HISFC.Models.Fee.Item.Undrug;
                //{9BAE643C-57BF-4dc5-889E-6B5F6B3E1E38} 由于接入电子申请单，apply_no字段赋order.ApplyNo 20100505 yangw
                System.Object[] s = {order.SeeNO,Neusoft.FrameWork.Function.NConvert.ToInt32(order.ID),order.Patient.ID,order.Patient.PID.CardNO,order.RegTime,
										order.InDept.ID,pItem.ID,pItem.Name,pItem.Specs,"2",
										order.Item.SysClass.ID,order.Item.MinFee.ID,order.Item.Price,order.Qty,order.HerbalQty,
										pItem.PackQty,pItem.PriceUnit,order.FT.OwnCost ,order.FT.PayCost,order.FT.PubCost,
										"0",0,"",order.DoseOnce,
										order.DoseUnit,"",order.Frequency.ID,order.Frequency.Name,order.Usage.ID,
										order.Usage.Name,order.Usage.Memo,order.ExeDept.ID,order.ExeDept.Name,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.Combo.IsMainDrug),order.Combo.ID,order.HypoTest,
										order.InjectCount,order.Memo,order.ReciptDoctor.ID,order.ReciptDoctor.Name,order.ReciptDept.ID,
										order.MOTime,order.Status,order.DCOper.ID,order.DCOper.OperTime,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsEmergency),order.Sample.Name,order.CheckPartRecord,order.ApplyNo,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsSubtbl),Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsNeedConfirm),order.ConfirmOper.ID,
										order.ConfirmOper.Dept.ID,order.ConfirmOper.OperTime,Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsHaveCharged),order.ChargeOper.ID,
										order.ChargeOper.OperTime,order.ReciptNO,order.SequenceNO,
                                        order.StockDept.ID,order.NurseStation.User03,"",
                                        order.NurseStation.User01,order.ExtendFlag1,
										order.ReciptSequence,order.NurseStation.Memo,order.SortID};
				try
				{
					string sReturn = string.Format(sql,s);
					return sReturn;
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.WriteErr();
					return null;
				}
	
			}	
			
		}

		
		/// <summary>
		/// 获得查询sql语句
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		protected int myGetSelectSql(ref string sql)
		{
			return this.Sql.GetSql("Order.OutPatient.Order.Query.Select",ref sql);
		}
		

		/// <summary>
		/// 获得执行医嘱信息
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		protected ArrayList myGetExecOrder(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.HISFC.Models.Order.OutPatient.Order order = new Neusoft.HISFC.Models.Order.OutPatient.Order();
				order.SeeNO = this.Reader[0].ToString();
				order.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());//项目流水好
				order.ID = this.Reader[1].ToString();//项目流水好
				order.Patient.ID  = this.Reader[2].ToString();//门诊号
				order.Patient.PID.CardNO = this.Reader[3].ToString();//病历卡号
				order.RegTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4]);//挂号日期
				order.ReciptDept.ID = this.Reader[5].ToString();//挂号科室 编码
				if(this.Reader[9].ToString() =="1")//药品
				{
					Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item();
					item.ID = this.Reader[6].ToString();
					item.Name = this.Reader[7].ToString();
					item.Specs = this.Reader[8].ToString();
					item.SysClass.ID = this.Reader[10].ToString();
					item.MinFee.ID = this.Reader[11].ToString();
					item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12]);
					item.BaseDose = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20]);
					item.DoseUnit =  this.Reader[24].ToString();
					item.Product.IsSelfMade = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[21]);
					item.Quality.ID = this.Reader[22].ToString();
					item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[15]);
					item.DosageForm.ID = this.Reader[25].ToString();
					item.PriceUnit = this.Reader[16].ToString();

                    //{6DBBDC62-2303-4d97-85EF-8BA2A622117A} 拆分属性 xuc
                    item.SplitType = this.Reader[61].ToString();

					order.Item = item;

				}
				else if(this.Reader[9].ToString() =="2")//非药品
				{
					Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();
					item.ID = this.Reader[6].ToString();
					item.Name = this.Reader[7].ToString();
					item.Specs = this.Reader[8].ToString();
					item.SysClass.ID = this.Reader[10].ToString();
					item.MinFee.ID = this.Reader[11].ToString();
					item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12]);
					item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[15]);
					item.PriceUnit = this.Reader[16].ToString();
					order.Item = item;

				}else
				{
					this.Err ="读取met_ord_recipedetail，区分药品非药品出错，drug_flag="+this.Reader[9].ToString();
					this.WriteErr();
					return null;
				}
				order.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13]);
				order.HerbalQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[14]);
				order.Unit = this.Reader[16].ToString();
				order.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17]);
				order.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18]);
				order.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19]);
					
				order.DoseOnce = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[23]);
				order.DoseUnit = this.Reader[24].ToString();
					
				order.Frequency.ID = this.Reader[26].ToString();
				order.Frequency.Name = this.Reader[27].ToString();
				order.Usage.ID  = this.Reader[28].ToString();
				order.Usage.Name  = this.Reader[29].ToString();
				order.Usage.Memo = this.Reader[30].ToString();
				order.ExeDept.ID = this.Reader[31].ToString();
				order.ExeDept.Name = this.Reader[32].ToString();
				order.Combo.IsMainDrug = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[33]);
				order.Combo.ID = this.Reader[34].ToString();
				order.HypoTest = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[35]);
				order.InjectCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[36]);
				order.Memo = this.Reader[37].ToString();
				order.ReciptDoctor.ID = this.Reader[38].ToString();
				order.ReciptDoctor.Name = this.Reader[39].ToString();
				order.ReciptDept.ID =this.Reader[40].ToString();
				//order.ReciptDept.Name =this.Reader[41].ToString();
				order.MOTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[41]);
				order.Status = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[42]);
				order.DCOper.ID = this.Reader[43].ToString();
				order.DCOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[44]);
				order.IsEmergency = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[45]);
				order.Sample.Name = this.Reader[46].ToString();
				order.CheckPartRecord = this.Reader[47].ToString();
				order.ApplyNo = this.Reader[48].ToString();
				order.IsSubtbl = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[49]);
				order.IsNeedConfirm = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[50]);
				order.ConfirmOper.ID = this.Reader[51].ToString();
				order.ConfirmOper.Dept.ID = this.Reader[52].ToString();
				order.ConfirmOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[53]);
				order.IsHaveCharged = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[54]);
				order.ChargeOper.ID = this.Reader[55].ToString();
				order.ChargeOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[56]);
				order.ReciptNO = this.Reader[57].ToString();
				order.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[58]);
                order.StockDept.ID = this.Reader[59].ToString();
                order.NurseStation.User03 = this.Reader[60].ToString();//最小单位标志
                //order.OrderType.ID = this.Reader[62].ToString();
                order.NurseStation.User01 = this.Reader[63].ToString();//附材组合号（检验）
                order.ExtendFlag1 = this.Reader[64].ToString();//接瓶信息
                order.ReciptSequence = this.Reader[65].ToString();//收费序列
                order.NurseStation.Memo = this.Reader[66].ToString();
                order.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[67]);
				#region sql
				//		0--看诊序号 1  --项目流水号, 2  --门诊号, 3  --病历号 4 -挂号日期  5,   --挂号科室
				//       6,   --项目代码 7,   --项目名称 8,   --规格 9,   --1药品，2非药品 10,   --系统类别
				//       11,   --最小费用代码 12,   --单价 13,   --开立数量 14 ,   --付数  15,   --包装数量
				//       16,   --计价单位 17,   --自费金额 18  --自负金额 19,   --报销金额 20,   --基本剂量
				//       21,   --自制药 2  --药品性质，普药、贵药 23,   --每次用量 24,   --每次用量单位 25,   --剂型代码
				//       26,   --频次 27,   --频次名称 28 --使用方法 29,   --用法名称 30,   --用法英文缩写
				//       31,   --执行科室代码 32,   --执行科室名称 33   --主药标志 34   --组合号 35   --1不需要皮试/2需要皮试，未做/3皮试阳/4皮试阴
				//       36,   --院内注射次数 37   --备注  38,   --开立医生 39,   --开立医生名称 40,   --医生科室
				//       41,   --开立时间   42,   --处方状态,1开立，2收费，3确认，4作废    43,   --作废人   44,   --作废时间    45,   --加急标记0普通/1加急
				//       46,   --样本类型    47,   --检体 48,   --申请单号    49,   --0没有附材/1带附材/2是附材     50,   --是否需要确认，1需要，0不需要
				//       51,   --确认人     52,   --确认科室    53,   --确认时间    54,   --0未收费/1收费      55,   --收费员
				//       56,   --收费时间      57,   --处方号      58    --处方内流水号
				//  FROM met_ord_recipedetail   --诊间处方明细表
				#endregion
				al.Add(order);
			}
			this.Reader.Close();
			return al;
		}


		#endregion

        #region 获得用法和用法所带的附材(add by sunm from 4.0)
        public Hashtable GetUsageAndSub()
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.OutPatient.Order.GetUsageAndSub", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            if (this.ExecQuery(strSql) < 0)
            {
                this.Err = "Exec Err" + this.Err;
                return null;
            }

            string usageCode = "";
            Hashtable hsUsageAndSub = new Hashtable();

            while (this.Reader.Read())
            {
                usageCode = this.Reader[0].ToString();

                if (!hsUsageAndSub.Contains(usageCode))
                {
                    ArrayList al = new ArrayList();

                    Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();

                    o.ID = this.Reader[1].ToString();

                    al.Add(o);

                    hsUsageAndSub.Add(usageCode, al);
                }
                else
                {
                    Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();

                    o.ID = this.Reader[1].ToString();

                    (hsUsageAndSub[usageCode] as ArrayList).Add(o);
                }
            }
            this.Reader.Close();
            return hsUsageAndSub;
        }
        #endregion

	}
}
