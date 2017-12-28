using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Nurse
{

	/// <summary>
	/// 门诊护士注射管理类
	/// </summary>
	public class Inject : Neusoft.FrameWork.Management.Database
	{
		public Inject()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据时间，病例号查询当天未注射信息
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public ArrayList Query(string cardNo,DateTime dt)
		{
			ArrayList al = new ArrayList();
			string strSQL;
			string strWhere = "";
			strSQL = this.GetSqlInjectInfo();
			if(this.Sql.GetSql("Nurse.Inject.Query.1",ref strWhere) == -1) return null;
			strSQL = strSQL + strWhere;
			strSQL = string.Format(strSQL,cardNo,dt);
			al = this.myGetInfo(strSQL);
			return al;
		}
		/// <summary>
		/// 根据时间，病例号查询当天所有注射信息（未注射，已注射）
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public ArrayList QueryAll(string cardNo,DateTime dt)
		{
			ArrayList al = new ArrayList();
			string strSQL;
			string strWhere = "";
			strSQL = this.GetSqlInjectInfo();
			if(this.Sql.GetSql("Nurse.Inject.Query.2",ref strWhere) == -1) return null;
			strSQL = strSQL + strWhere;
			strSQL = string.Format(strSQL,cardNo,dt);
			al = this.myGetInfo(strSQL);
			return al;
		}
		/// <summary>
		/// 根据时间，病例号查询当天所有注射信息（未注射，已注射）
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public ArrayList QueryByOrder(string orderNo,DateTime dt)
		{
			ArrayList al = new ArrayList();
			string strSQL;
			string strWhere = "";
			strSQL = this.GetSqlInjectInfo();
			if(this.Sql.GetSql("Nurse.Inject.Query.3",ref strWhere) == -1) return null;
			strSQL = strSQL + strWhere;
			strSQL = string.Format(strSQL,orderNo,dt);
			al = this.myGetInfo(strSQL);
			return al;
		}
		/// <summary>
		/// 根据时间，病例号,处方号，处方顺序号查询当天已经登记信息
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public ArrayList Query(string cardNo,string recipeNo,string seq,DateTime dt)
		{
			ArrayList al = new ArrayList();
			string strSQL;
			string strWhere = "";
			strSQL = this.GetSqlInjectInfo();
			if(this.Sql.GetSql("Nurse.Inject.Query.4",ref strWhere) == -1) return null;
			strSQL = strSQL + strWhere;
			strSQL = string.Format(strSQL,cardNo,recipeNo,seq,dt);
			al = this.myGetInfo(strSQL);
			return al;
		}
		/// <summary>
		/// 生成注射分解信息
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Nurse.Inject info)
		{
			string sql = "";

			if(this.Sql.GetSql("Nurse.Inject.Insert",ref sql) == -1)return -1;

			try
			{
				string strMainDrug = "0";
				string strSelfMake = "0";
				if(info.Item.Order.Combo.IsMainDrug)
				{
					strMainDrug = "1";
				}
                Neusoft.HISFC.Models.Pharmacy.Item tempi = (Neusoft.HISFC.Models.Pharmacy.Item)info.Item.Item;

                if (tempi.Product.IsSelfMade)
				{
					strSelfMake = "1";
				}
				sql = string.Format(sql,
                    info.ID,
                    info.OrderNO,
                    info.Patient.ID,
                    info.Patient.PID.CardNO,
                    info.Patient.Name,
					info.Patient.Sex.ID,
                    info.Patient.Birthday,
                    info.Item.Order.DoctorDept.ID,
                    info.Item.Order.DoctorDept.Name,
                    info.Item.Order.Doctor.ID,
					info.Item.Order.Doctor.Name,
                    info.Item.RecipeNO,
                    info.Item.SequenceNO,
                    info.Item.ID,
                    info.Item.Name,
					info.Item.Item.Specs,
                    strSelfMake,
                    tempi.Quality.ID,
                    tempi.DosageForm,       /*剂型*/
                    info.Item.Item.MinFee.ID,
					info.Item.Item.Price,
                    info.Item.Order.Frequency.ID,
                    info.Item.Order.Usage.ID,
                    info.Item.Order.Usage.Name,
                    info.Item.InjectCount,
					info.Hypotest,
                    info.Item.Order.DoseOnce,
                    info.Item.Order.DoseUnit,
                    tempi.BaseDose,
                    info.Item.Item.PackQty,
					strMainDrug,
                    info.Item.Order.Combo.ID,
                    info.ExecTime,
                    info.Booker.ID,
                    info.Booker.OperTime,
					info.MixOperInfo.ID,
                    info.MixOperInfo.Name,
                    info.MixTime,
                    info.InjectOperInfo.ID,
                    info.InjectOperInfo.Name,
					info.InjectTime,
                    info.InjectSpeed,
                    info.EndTime,
                    info.SendemcTime,
                    info.Memo,
                    info.Item.ExecOper.ID,
					info.InjectOrder,
                    info.StopOper.ID,
                    //{EB016FFE-0980-479c-879E-225462ECA6D0} 瓶签补打
                    info.PrintNo);
			}
			catch(Exception e)
			{
				this.Err = "转换出错!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}

		/// <summary>
		/// 根据流水号取消（删除）一次登记信息
		/// </summary>
		/// <param name="strId"></param> 
		/// <returns></returns>
		public int Delete(string strId)
		{
			string strSql = "";
			if (this.Sql.GetSql("Nurse.Inject.Delete",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,strId);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}			
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 更新登记信息
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateReg(Neusoft.HISFC.Models.Nurse.Inject info)
		{
			string sql = "";
			if(this.Sql.GetSql("Nurse.Inject.Update.1",ref sql) == -1) return -1;
			try
			{
				sql = string.Format(sql,
                    info.ID,
                    info.OrderNO,
                    info.Item.Order.Combo.ID,
                    info.Booker.Name,   /*登记科室*/
                    info.Booker.ID,
                    info.Booker.OperTime);
			}
			catch(Exception e)
			{
				this.Err ="转换出错!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}

		/// <summary>
		/// 更新配药信息
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateMix(Neusoft.HISFC.Models.Nurse.Inject info)
		{
			string sql = "";

			if(this.Sql.GetSql("Nurse.Inject.Update.2",ref sql) == -1) return -1;
			try
			{
				sql = string.Format(sql,
                    info.ID,
                    info.MixOperInfo.ID,
                    info.MixOperInfo.Name,
                    info.MixTime,
                    info.Memo);
			}
			catch(Exception e)
			{
				this.Err ="转换出错!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}

		/// <summary>
		/// 更新注射信息
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateInject(Neusoft.HISFC.Models.Nurse.Inject info)
		{
			string sql = "";

			if(this.Sql.GetSql("Nurse.Inject.Update.3",ref sql) == -1) return -1;
            
            try
			{
				sql = string.Format(sql,
                    info.ID,
                    info.InjectOperInfo.ID,
                    info.InjectOperInfo.Name,
                    info.InjectTime,
					info.InjectSpeed,
                    info.SendemcTime,
                    info.Memo);
			}
			catch(Exception e)
			{
				this.Err ="转换出错!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}
		/// <summary>
		/// 更新拔针信息
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateStop(Neusoft.HISFC.Models.Nurse.Inject info)
		{
			string sql = "";

			if(this.Sql.GetSql("Nurse.Inject.Update.4",ref sql) == -1) return -1;

			try
			{
				sql = string.Format(sql,info.ID,info.StopOper.ID,info.EndTime);
			}
			catch(Exception e)
			{
				this.Err ="转换出错!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}

		/// <summary>
		/// 查询最后一次注射信息
		/// </summary>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Nurse.Inject QueryLast()
		{
			Neusoft.HISFC.Models.Nurse.Inject info = new Neusoft.HISFC.Models.Nurse.Inject();
			string strSQL;
			string strWhere = "";
			strSQL = this.GetSqlInjectInfo();
			if(this.Sql.GetSql("Nurse.Inject.Query.5",ref strWhere) == -1) return null;
			strSQL = strSQL + strWhere;
			strSQL = string.Format(strSQL);
			ArrayList al = new ArrayList();
			al = this.myGetInfo(strSQL);
            if (al.Count > 0)
            {
                info = (Neusoft.HISFC.Models.Nurse.Inject)al[0];
                return info;
            }
            else
            {
                return null;
            }
		}

        /// <summary>
        /// 查询当天该注射号的注射信息
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryInjectOrder(string id)
        {
            Neusoft.HISFC.Models.Nurse.Inject info = new Neusoft.HISFC.Models.Nurse.Inject();
            string strSQL;
            string strWhere = "";
            strSQL = this.GetSqlInjectInfo();
            if (this.Sql.GetSql("Nurse.Inject.Query.7", ref strWhere) == -1) return null;
            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, id);
            ArrayList al = new ArrayList();
            al = this.myGetInfo(strSQL);
            return al;
        }

        /// <summary>
        /// 查询最后一次注射信息
        /// </summary>
        /// <param name="code">使用方法编码</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Nurse.Inject QueryLast(string code)
        {
            Neusoft.HISFC.Models.Nurse.Inject info = new Neusoft.HISFC.Models.Nurse.Inject();
            string strSQL;
            string strWhere = "";
            strSQL = this.GetSqlInjectInfo();
            if (this.Sql.GetSql("Nurse.Inject.Query.6", ref strWhere) == -1) return null;
            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, code);
            ArrayList al = new ArrayList();
            al = this.myGetInfo(strSQL);
            info = (Neusoft.HISFC.Models.Nurse.Inject)al[0];
            return info;
        }

        /// <summary>
        /// 查询需要配药的记录
        /// {03E7916F-5AA8-4e95-BBE2-61EB6FDEB96C}
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryNeedDosageInjectRecord(DateTime beginDate)
        {
            string strSQL;
            string strWhere = "";
            strSQL = this.GetSqlInjectInfo();
            if (this.Sql.GetSql("Nurse.Inject.Query.NeedDosage", ref strWhere) == -1)
                return null;
            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, beginDate.ToString("yyyy-MM-dd HH:mm:ss"));
            ArrayList al = new ArrayList();
            al = this.myGetInfo(strSQL);
            return al;
        }

        /// <summary>
        /// 查询该患者最后一次注射信息
        /// {03E7916F-5AA8-4e95-BBE2-61EB6FDEB96C}
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Nurse.Inject QueryLastByPatient(string cardNo)
        {
            Neusoft.HISFC.Models.Nurse.Inject info = new Neusoft.HISFC.Models.Nurse.Inject();
            string strSQL;
            string strWhere = "";
            strSQL = this.GetSqlInjectInfo();
            if (this.Sql.GetSql("Nurse.Inject.Query.Last", ref strWhere) == -1)
                return null;
            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, cardNo);
            ArrayList al = new ArrayList();
            al = this.myGetInfo(strSQL);
            if (al == null)
            {
                return null;
            }
            if (al.Count == 0)
            {
                this.Err = "没有找到记录";
                return null;
            }
            info = (Neusoft.HISFC.Models.Nurse.Inject)al[0];
            return info;
        }

        /// <summary>
        /// 查询注射登记记录，用于补打
        /// {EB016FFE-0980-479c-879E-225462ECA6D0}
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryRePrintInjectRecord(string printNo)
        {
            string strSQL;
            string strWhere = "";
            strSQL = this.GetSqlInjectInfo();
            if (this.Sql.GetSql("Nurse.Inject.Query.CureRePrint", ref strWhere) == -1)
                return null;
            strSQL = strSQL + strWhere;
            strSQL = string.Format(strSQL, printNo);
            ArrayList al = new ArrayList();
            al = this.myGetInfo(strSQL);
            return al;
        }

		#region 公用信息
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetSqlInjectInfo() 
		{
			string strSql = "";
			if (this.Sql.GetSql("Nurse.Inject.Query",ref strSql)==-1) return null;
			return strSql;
		}
		/// <summary>
		/// 根据SQL,获取实体数组
		/// </summary>
		/// <param name="SQLString"></param>
		/// <returns></returns>
		public ArrayList myGetInfo(string SQLString) 
		{
			ArrayList al=new ArrayList();         
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) 
			{
				this.Err="获得注射信息时，执行SQL语句出错！"+this.Err; 
				this.ErrCode="-1";
				return null;
			}
			try 
			{
				while (this.Reader.Read())  
				{
					#region 将结果转化为实体
                    Neusoft.HISFC.Models.Nurse.Inject info = new Neusoft.HISFC.Models.Nurse.Inject();
					info.ID = this.Reader[0].ToString();
					info.OrderNO = this.Reader[1].ToString();
					info.Patient.ID = this.Reader[2].ToString();
					info.Patient.PID.CardNO = this.Reader[3].ToString();
					info.Patient.Name = this.Reader[4].ToString();
					info.Patient.Sex.ID = this.Reader[5].ToString();
                    info.Patient.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6]);
					info.Item.Order.DoctorDept.ID = this.Reader[7].ToString();
					info.Item.Order.DoctorDept.Name = this.Reader[8].ToString();
					info.Item.Order.Doctor.ID = this.Reader[9].ToString();
					info.Item.Order.Doctor.Name = this.Reader[10].ToString();
					info.Item.RecipeNO = this.Reader[11].ToString();
                    info.Item.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[12].ToString());
					info.Item.ID = this.Reader[13].ToString();
					info.Item.Name = this.Reader[14].ToString();
					info.Item.Item.Specs = this.Reader[15].ToString();

                    //下面三个变量暂时用的,没地方存
					info.Item.Item.SpecialFlag1 = this.GetBool(this.Reader[16].ToString()).ToString();//自配药
					info.Item.Item.SpecialFlag2 = this.Reader[17].ToString();
                    info.Item.Item.SpecialFlag3 = this.Reader[18].ToString();

					info.Item.Item.MinFee.ID = this.Reader[19].ToString();
                    info.Item.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20]);
					info.Item.Order.Frequency.ID = this.Reader[21].ToString();
					info.Item.Order.Usage.ID = this.Reader[22].ToString();
					info.Item.Order.Usage.Name = this.Reader[23].ToString();
                    info.Item.InjectCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[24].ToString());
					info.Hypotest = this.Reader[25].ToString();
                    info.Item.Order.DoseOnce = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26]);
					info.Item.Order.DoseUnit = this.Reader[27].ToString();

                    info.Item.User01 = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[28]).ToString();
                    //info.Item.BaseDose = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[28]);

                    info.Item.Item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[29]);

                    info.Item.User02 = this.GetBool(this.Reader[30].ToString()).ToString();
					//info.Item.IsMainDrug = this.getBool(this.Reader[30].ToString());

					info.Item.Order.Combo.ID = this.Reader[31].ToString();
                    info.ExecTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[32].ToString());
					info.Booker.ID = this.Reader[33].ToString();
                    info.Booker.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[34]);
					info.MixOperInfo.ID = this.Reader[35].ToString();
					info.MixOperInfo.Name = this.Reader[36].ToString();
                    info.MixTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[37]);
					info.InjectOperInfo.ID = this.Reader[38].ToString();
					info.InjectOperInfo.Name = this.Reader[39].ToString();
                    info.InjectTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[40]);
					info.InjectSpeed = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[41].ToString());
					info.EndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[42]);
					info.SendemcTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[43]);
					info.Memo = this.Reader[44].ToString();
					info.Item.ExecOper.ID = this.Reader[45].ToString();//登记科室
					info.InjectOrder = this.Reader[46].ToString();// 
					info.StopOper.ID = this.Reader[47].ToString();
                    //{EB016FFE-0980-479c-879E-225462ECA6D0} 瓶签补打
                    info.PrintNo = this.Reader[48].ToString();//打印流水号
					#endregion
					al.Add(info);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得注射信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();
			this.ProgressBarValue=-1;
			return al;
		}
		private bool GetBool(string str)
		{
			bool bl = false;
			if(str == "1") bl = true;
			return bl;
		}
		#endregion
	}
}