using System;
using System.Collections;
using Neusoft.HISFC.Models.Preparation;
using Neusoft.FrameWork.Function;
using System.Collections.Generic;

namespace Neusoft.HISFC.BizLogic.Pharmacy
{
    /// <summary>
    /// [功能描述: 制剂管理类]<br></br>
    /// [创 建 者: Dorian]<br></br>
    /// [创建时间: 2008]<br></br>
    /// <修改记录>
    ///    
    /// </修改记录>
    /// </summary>
	public class Preparation:Neusoft.FrameWork.Management.Database
	{
		public Preparation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		
		#region 配制处方维护

		/// <summary>
		/// 根据制剂处方实体获取参数数组
		/// </summary>
		/// <param name="prescription">制剂处方实体</param>
		/// <returns>成功返回对应的参数数组</returns>
		private string[] myGetPrescriptionParam(PrescriptionBase prescription)
		{
			string[] strParm = 
				{
                    ((int)prescription.ItemType).ToString(),//项目类别
					prescription.ID,					//成品编码
					prescription.Name,					//成品名称
					prescription.ProductSpecs,			//成品规格
                    ((int)prescription.MaterialType).ToString(),
					prescription.Material.ID,				//原料编码
					prescription.Material.Name,				//原料名称
					prescription.Specs,			            //原料规格
                    prescription.MaterialPackQty.ToString(),
                    prescription.Price.ToString(),          //单价
					prescription.NormativeQty.ToString(),	//标准处方量
					prescription.NormativeUnit,				//单位
					prescription.OperEnv.Name,
					prescription.OperEnv.OperTime.ToString(),		//操作时间
					prescription.Memo
				};
			return strParm;
		}

		/// <summary>
		/// 执行Sql语句获取处方实体
		/// </summary>
		/// <param name="strSql">欲执行Sql语句</param>
		/// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> myGetPrescription(string strSql)
		{
            List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> al = new List<PrescriptionBase>();
            PrescriptionBase prescription;

			if (this.ExecQuery(strSql) == -1)
			{
				this.Err = "执行Sql语句出错\n" + strSql + this.Err;
				return null;
			}

			try
			{
				while (this.Reader.Read())
				{
                    prescription = new PrescriptionBase();

                    prescription.ItemType = (Neusoft.HISFC.Models.Base.EnumItemType)(NConvert.ToInt32(this.Reader[0]));
					prescription.ID = this.Reader[1].ToString();			    //成品编码
					prescription.Name = this.Reader[2].ToString();			    //成品名称
					prescription.ProductSpecs = this.Reader[3].ToString();		//成品规格
                    prescription.MaterialType = (EnumMaterialType)(NConvert.ToInt32(this.Reader[4]));
					prescription.Material.ID = this.Reader[5].ToString();		//原料编码
					prescription.Material.Name = this.Reader[6].ToString();		//原料名称
					prescription.Specs = this.Reader[7].ToString();	            //原料规格
                    prescription.MaterialPackQty = NConvert.ToDecimal(this.Reader[8]);
                    prescription.Price = NConvert.ToDecimal(this.Reader[9]);    //单价
					prescription.NormativeQty = NConvert.ToDecimal(this.Reader[10].ToString());
					prescription.NormativeUnit = this.Reader[11].ToString();
					prescription.OperEnv.Name = this.Reader[12].ToString();
					prescription.OperEnv.OperTime = NConvert.ToDateTime(this.Reader[13].ToString());
					prescription.Memo = this.Reader[14].ToString();

					al.Add(prescription);
				}
			}
			catch (Exception ex)
			{
				this.Err = "由Reader内获取处方信息出错" + ex.Message;
				return null;
			}
			finally
			{
				this.Reader.Close();
			}

			return al;
		}

		/// <summary>
		/// 向制剂处方表内插入新记录
		/// </summary>
		/// <param name="prescription">制剂处方实体</param>
		/// <returns>成功返回1 失败返回-1</returns>
        protected int InsertPrescription(PrescriptionBase prescription)
		{
			string strSQL="";
			if(this.Sql.GetSql("Pharmacy.PPR.Prescription.InsertPrescription",ref strSQL) == -1)
				return -1;
			try 
			{
				string[] strParm = this.myGetPrescriptionParam( prescription ); //取参数列表
				strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err="格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Prescription.InsertPrescription" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 更新一条已有处方配制信息
		/// </summary>
		/// <param name="prescription">制剂处方实体</param>
		/// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdatePrescription(PrescriptionBase prescription)
		{
			string strSQL="";
			if(this.Sql.GetSql("Pharmacy.PPR.Prescription.UpdatePrescription",ref strSQL) == -1)
				return -1;
			try 
			{
				string[] strParm = this.myGetPrescriptionParam( prescription ); //取参数列表
				strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err="格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Prescription.UpdatePrescription" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 先执行更新操作 更新不成功则执行插入操作
		/// </summary>
		/// <param name="prescription">制剂处方实体</param>
		/// <returns>成功返回操作记录数 失败返回-1</returns>
        public int SetPrescription(PrescriptionBase prescription)
		{
			int parm = this.UpdatePrescription(prescription);
			if (parm < 1)
			{
				parm = this.InsertPrescription(prescription);
			}
			return parm;
		}

		/// <summary>
		/// 删除配制处方记录
		/// </summary>
		/// <param name="drugCode">成品编码</param>
        /// <param name="itemType">项目类别</param>
		/// <param name="materialCode">原料编码</param>
		/// <returns>成功返回删除条数  失败返回-1</returns>
		public int DelPrescription(string drugCode,Neusoft.HISFC.Models.Base.EnumItemType itemType,string materialCode)
		{
			string strSQL=""; 
			if(this.Sql.GetSql("Pharmacy.PPR.Prescription.DelPrescription",ref strSQL) == -1) return -1;
			try 
			{
				strSQL = string.Format(strSQL, drugCode,((int)itemType).ToString(),materialCode);
			}
			catch 
			{
				this.Err="传入参数不正确！Pharmacy.PPR.Prescription.DelPrescription";
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 删除某个成品的配制处方
		/// </summary>
		/// <param name="drugCode">成品编码</param>
        /// <param name="itemType">项目类别</param>
		/// <returns>成功返回删除记录数  失败返回-1</returns>
		public int DelPrescription(string drugCode,Neusoft.HISFC.Models.Base.EnumItemType itemType)
		{
			return this.DelPrescription(drugCode,itemType,"AAAA");
		}

		/// <summary>
		/// 获取某成品配制处方信息
		/// </summary>
		/// <param name="drugCode">成功编码</param>
        /// <param name="itemType">项目类别</param>
		/// <returns>成功返回配制处方数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> QueryPrescription(string drugCode,Neusoft.HISFC.Models.Base.EnumItemType itemType)
		{
			string strSelect = "";
			string strSQL = "";
			if (this.Sql.GetSql("Pharmacy.PPR.Prescription.GetPrescription",ref strSelect) == -1)
				return null;
			if(this.Sql.GetSql("Pharmacy.PPR.Prescription.GetPrescription.Where.1",ref strSQL) == -1)
				return null;
			try 
			{
				strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, drugCode, ((int)itemType).ToString());
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Pharmacy.PPR.Prescription.GetPrescription:" + ex.Message;
				return null;
			}
			return this.myGetPrescription(strSQL);
		}

        /// <summary>
        /// 根据原料类别、成品编码获取配置处方信息
        /// </summary>
        /// <param name="drugCode">成品编码</param>
        /// <param name="itemType">项目类别</param>
        /// <param name="materialType">原料类别</param>
        /// <returns>成功返回配置处方信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> QueryPrescription(string drugCode, Neusoft.HISFC.Models.Base.EnumItemType itemType, EnumMaterialType materialType)
        {
            List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> alList = this.QueryPrescription(drugCode,itemType);
            if (alList == null)
            {
                return null;
            }

            List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> alTypeList = new List<PrescriptionBase>();

            foreach (Neusoft.HISFC.Models.Preparation.PrescriptionBase info in alList)
            {
                if (info.MaterialType == materialType)                
                {
                    alTypeList.Add(info);
                }
            }

            return alTypeList;
        }

        /// <summary>
        /// 获取配置处方列表
        /// </summary>
        /// <returns></returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryPrescriptionList(Neusoft.HISFC.Models.Base.EnumItemType itemType)
        {
            string strSelect = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Prescription.GetPrescriptionList", ref strSelect) == -1)
            {
                return null;
            }

            strSelect = string.Format(strSelect, ((int)itemType).ToString());

            List<Neusoft.FrameWork.Models.NeuObject> alList =  new List<Neusoft.FrameWork.Models.NeuObject>();
            if (this.ExecQuery(strSelect) == -1)
            {
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();			//成品编码
                    info.Name = this.Reader[1].ToString();			//成品名称
                    info.Memo = this.Reader[2].ToString();		    //成品规格

                    alList.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取处方信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return alList;
        }

        /// <summary>
        /// 制剂成品配制处方信息保存
        /// </summary>
        /// <param name="baseList"></param>
        /// <returns></returns>
        public int SavePrescription(List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> baseList)
        {
            Neusoft.HISFC.Models.Preparation.PrescriptionBase tempPrescription = baseList[0];

            if (this.DelPrescription(tempPrescription.ID, tempPrescription.ItemType) == -1)
            {
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Preparation.PrescriptionBase info in baseList)
            {
                if (this.InsertPrescription(info) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        #region 药品配制处方信息

        /// <summary>
        /// 类型转换。我也知道比较恶心，不过没办法了。。
        /// </summary>
        /// <param name="basePrescription"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Preparation.Prescription ConvertBaseToChild(Neusoft.HISFC.Models.Preparation.PrescriptionBase basePrescription)
        {
            Neusoft.HISFC.Models.Preparation.Prescription info = new Prescription();
            info.ItemType = basePrescription.ItemType;
            info.Drug.ID = basePrescription.ID;
            info.Drug.Name = basePrescription.Name;
            info.Drug.Specs = basePrescription.ProductSpecs;
            info.MaterialType = basePrescription.MaterialType;
            info.Material = basePrescription.Material;
            info.Specs = basePrescription.Specs;
            info.MaterialPackQty = basePrescription.MaterialPackQty;
            info.Price = basePrescription.Price;
            info.NormativeQty = basePrescription.NormativeQty;
            info.NormativeUnit = basePrescription.NormativeUnit;
            info.OperEnv = basePrescription.OperEnv;
            info.Memo = basePrescription.Memo;
            
            return info;
        }

        public List<Neusoft.HISFC.Models.Preparation.Prescription> QueryDrugPrescription(string drugCode)
        {
            List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> baseList = this.QueryPrescription(drugCode, Neusoft.HISFC.Models.Base.EnumItemType.Drug);
            if (baseList == null)
            {
                return null;
            }

            List<Neusoft.HISFC.Models.Preparation.Prescription> drugPrescriptionList = new List<Prescription>();

            foreach (Neusoft.HISFC.Models.Preparation.PrescriptionBase info in baseList)
            {
                Neusoft.HISFC.Models.Preparation.Prescription drugPrescription = this.ConvertBaseToChild(info);

                drugPrescriptionList.Add(drugPrescription);
            }

            return drugPrescriptionList;
        }

        public List<Neusoft.HISFC.Models.Preparation.Prescription> QueryDrugPrescription(string drugCode, Neusoft.HISFC.Models.Preparation.EnumMaterialType materialType)
        {
            List<Neusoft.HISFC.Models.Preparation.Prescription> drugPrescriptionList = this.QueryDrugPrescription(drugCode);
            if (drugPrescriptionList == null)
            {
                return null;
            }

            List<Neusoft.HISFC.Models.Preparation.Prescription> alTypeList = new List<Prescription>();

            foreach (Neusoft.HISFC.Models.Preparation.Prescription info in drugPrescriptionList)
            {
                if (info.MaterialType == materialType)
                {
                    alTypeList.Add(info);
                }
            }

            return alTypeList;
        }

        #endregion

        #endregion

        #region 制剂主表

        #region 基础增、删、改操作

        /// <summary>
		/// 根据制剂主信息获取参数数组
		/// </summary>
		/// <param name="preparation">制剂主信息实体</param>
		/// <returns>成功返回对应的参数数组</returns>
		private string[] myGetPreparationParam(Neusoft.HISFC.Models.Preparation.Preparation preparation)
		{
			
			string[] strParam = {
									preparation.PlanNO,					//生产计划编号
									preparation.Drug.ID,				//成品编码
									preparation.Drug.Name,				//成品名称
									preparation.Drug.Specs,				//成品规格
									preparation.Drug.PackUnit,			//包装单位
									preparation.Drug.PackQty.ToString(),//包装数量
									((int)preparation.State).ToString(),					//状态
									preparation.PlanQty.ToString(),		//计划配液量
									preparation.Unit,					//配液量单位
									preparation.BatchNO,				//生产成品批号
									preparation.PlanEnv.ID,				//计划人
									preparation.PlanEnv.OperTime.ToString(),	//计划时间
									preparation.ConfectEnv.ID,			//配制人
									preparation.ConfectEnv.OperTime.ToString(),	//配制时间
									preparation.AssayQty.ToString(),	//送检数量
									NConvert.ToInt32(preparation.IsAssayEligible).ToString(),	//检验结果是否合格 0 不合格 1 合格
									preparation.AssayEnv.ID,				//检验人
									preparation.AssayEnv.OperTime.ToString(),	//检验时间	
									preparation.InputState,				//入库状态 0 暂入库 1 正式入库
									preparation.InputQty.ToString(),	//入库数量
									preparation.InputEnv.ID,				//入库人
									preparation.InputEnv.OperTime.ToString(),	//入库时间	
									preparation.CheckResult,			//审核意见
									preparation.CheckOper,				//审核员
									preparation.Memo,					//备注	
									NConvert.ToInt32(preparation.IsClear).ToString(),			//是否清场 1 清场 0 未清场
                                    preparation.ProcessState,
									preparation.OperEnv.ID,				//操作员
									preparation.OperEnv.OperTime.ToString(),	//操作时间
									preparation.Extend1,				//扩展标记
									preparation.Extend2,				//扩展标记1
									preparation.Extend3,				//扩展标记2
                                    preparation.CostPrice.ToString()
								};
			return strParam;
		}

		/// <summary>
		/// 执行Sql语句获取制剂主信息
		/// </summary>
		/// <param name="strSql">欲执行Sql语句</param>
		/// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
		private List<Neusoft.HISFC.Models.Preparation.Preparation> myGetPreparation(string strSql)
		{
            List<Neusoft.HISFC.Models.Preparation.Preparation> al = new List < Neusoft.HISFC.Models.Preparation.Preparation >();
			Neusoft.HISFC.Models.Preparation.Preparation info;

			if (this.ExecQuery(strSql) == -1)
			{
				this.Err = "执行Sql语句出错\n" + strSql + this.Err;
				return null;
			}

			try
			{
				while (this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Preparation.Preparation();

					info.PlanNO = this.Reader[0].ToString();			//生产计划编码
					info.Drug.ID = this.Reader[1].ToString();			//成品编码
					info.Drug.Name = this.Reader[2].ToString();			//成品名称
					info.Drug.Specs = this.Reader[3].ToString();		//成品规格
					info.Drug.PackUnit = this.Reader[4].ToString();		//包装单位
					info.Drug.PackQty = NConvert.ToDecimal(this.Reader[5].ToString());	//包装数量
					info.State = (EnumState)(NConvert.ToInt32(this.Reader[6].ToString()));								//状态
					info.PlanQty = NConvert.ToDecimal(this.Reader[7].ToString());		//计划数量
					info.Unit = this.Reader[8].ToString();								//单位
					info.BatchNO = this.Reader[9].ToString();							//批号
					info.PlanEnv.ID = this.Reader[10].ToString();							//计划人
					info.PlanEnv.OperTime = NConvert.ToDateTime(this.Reader[11].ToString());	//计划时间
					info.ConfectEnv.ID = this.Reader[12].ToString();						//配制人
					info.ConfectEnv.OperTime = NConvert.ToDateTime(this.Reader[13].ToString());	//配制时间
					info.AssayQty = NConvert.ToDecimal(this.Reader[14].ToString());		//送检数量
					info.IsAssayEligible = NConvert.ToBoolean(this.Reader[15].ToString());//检验结果是否合格
					info.AssayEnv.ID = this.Reader[16].ToString();						//检验人
					info.AssayEnv.OperTime = NConvert.ToDateTime(this.Reader[17].ToString());	//检验时间
					info.InputState = this.Reader[18].ToString();						//入库状态
					info.InputQty = NConvert.ToDecimal(this.Reader[19].ToString());		//入库数量
					info.InputEnv.ID = this.Reader[20].ToString();						//入库人
					info.InputEnv.OperTime = NConvert.ToDateTime(this.Reader[21].ToString());	//入库时间
					info.CheckResult = this.Reader[22].ToString();						//审核意见
					info.CheckOper = this.Reader[23].ToString();						//审核员
					info.Memo = this.Reader[24].ToString();
					info.IsClear = NConvert.ToBoolean(this.Reader[25].ToString());		//是否清场
                    info.ProcessState = this.Reader[26].ToString();
					info.OperEnv.ID = this.Reader[27].ToString();
					info.OperEnv.OperTime = NConvert.ToDateTime(this.Reader[28].ToString());
					info.Extend1 = this.Reader[29].ToString();
					info.Extend2 = this.Reader[30].ToString();
					info.Extend3 = this.Reader[31].ToString();
                    info.CostPrice = NConvert.ToDecimal(this.Reader[32]);

					al.Add(info);
				}
			}
			catch (Exception ex)
			{
				this.Err = "由Reader内获取制剂主信息信息出错" + ex.Message;
				return null;
			}
			finally
			{
				this.Reader.Close();
			}

			return al;
		}

		/// <summary>
		/// 向制剂主表内插入新记录
		/// </summary>
		/// <param name="preparation">制剂主实体</param>
		/// <returns>成功返回1 失败返回-1</returns>
		protected int InsertPreparation(Neusoft.HISFC.Models.Preparation.Preparation preparation)
	
		{
			string strSQL="";
			if(this.Sql.GetSql("Pharmacy.PPR.Preparation.InsertPreparation",ref strSQL) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetPreparationParam( preparation ); //取参数列表
				strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err="格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.InsertPreparation" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
        /// <summary>
		/// 更新一条已有制剂主表信息
		/// </summary>
		/// <param name="preparation">制剂主实体</param>
		/// <returns>成功返回更新条数 失败返回-1</returns>
		protected int UpdatePreparation(Neusoft.HISFC.Models.Preparation.Preparation preparation)
		
		{
			string strSQL="";
			if(this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparation",ref strSQL) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetPreparationParam( preparation ); //取参数列表
				strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err="格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.UpdatePreparation" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}	
		
        /// <summary>
		/// 删除制剂记录
		/// </summary>
		/// <param name="planNo">生产计划编码</param>
		/// <param name="drugCode">成品编码</param>
		/// <returns>成功返回删除条数  失败返回-1</returns>
		public int DelPreparation(string planNo,string drugCode)
		
		{
			string strSQL=""; 
			if(this.Sql.GetSql("Pharmacy.PPR.Preparation.DelPreparation",ref strSQL) == -1) return -1;
			try 
			{
				strSQL = string.Format(strSQL, planNo,drugCode);
			}
			catch 
			{
				this.Err="传入参数不正确！Pharmacy.PPR.Preparation.DelPreparation";
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
        /// <summary>
		/// 删除制剂记录
		/// </summary>
		/// <param name="planNo">生产计划编码</param>
		/// <returns>成功返回删除条数  失败返回-1</returns>
		public int DelPreparation(string planNo)
		{
			return this.DelPreparation(planNo,"AAAA");
        }

        #endregion
		
		/// <summary>
		/// 获取制剂信息
		/// </summary>
		/// <param name="planNo">生产计划编码</param>
		/// <param name="drugCode">成品编码</param>
        /// <param name="stateCollection">生产状态 0 计划 1 配置  2 半成品分装 3 半成品检验 4 成品外包装 5 成品检验 6 成品入库</param>
		/// <returns>成功返回获取信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Preparation> QueryPreparation(string planNo, string drugCode, params Neusoft.HISFC.Models.Preparation.EnumState[] stateCollection)
		{
			string strSelect = "";
			string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.GetPreparation", ref strSelect) == -1)
            {
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.PPR.Where.DrugState", ref strSQL) == -1)
            {
                return null;
            }

            string states = "";
            foreach (EnumState state in stateCollection)
            {
                states = states + ((int)state).ToString() + "','";
            }

			try 
			{
				strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, planNo, states, drugCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Pharmacy.PPR.Preparation.GetPreparation:" + ex.Message;
				return null;
			}
			return this.myGetPreparation(strSQL);
		}
		
        /// <summary>
		/// 获取制剂信息
		/// </summary>
		/// <param name="planNo">生产计划编码</param>
        /// <param name="stateCollection">生产状态 0 计划 1 配置 2 半成品分装 3 半成品检验 4 成品外包装 5 成品检验 6 成品入库</param>
		/// <returns>成功返回获取信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Preparation> QueryPreparation(string planNo, params Neusoft.HISFC.Models.Preparation.EnumState[] stateCollection)
		{
            return this.QueryPreparation(planNo, "AAAA", stateCollection);
		}
		
        /// <summary>
		/// 获取制剂信息
		/// </summary>
		/// <param name="state">生产状态 0 计划 1 配置 2 半成品分装 3 半成品检验 4 成品外包装 5 成品检验 6 成品入库</param>
		/// <returns>成功返回获取信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Preparation> QueryPreparation(Neusoft.HISFC.Models.Preparation.EnumState state)
		
		{
			string strSelect = "";
			string strSQL = "";
			if (this.Sql.GetSql("Pharmacy.PPR.Preparation.GetPreparation",ref strSelect) == -1)
				return null;
			if(this.Sql.GetSql("Pharmacy.PPR.Preparation.Where.State",ref strSQL) == -1)
				return null;
			try 
			{
				strSQL = strSelect + strSQL;
				strSQL = string.Format(strSQL,((int)state).ToString());
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Pharmacy.PPR.Preparation.GetPreparation:" + ex.Message;
				return null;
			}
			return this.myGetPreparation(strSQL);
		}

        /// <summary>
        /// 先执行更新操作 更新不成功则执行插入操作
        /// </summary>
        /// <param name="preparation">制剂主实体</param>
        /// <returns>成功返回操作记录数 失败返回-1</returns>
        public int PreparationPlan(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            int parm = this.UpdatePreparation(preparation);
            if (parm < 1)
            {
                parm = this.InsertPreparation(preparation);
            }
            return parm;
        }

        /// <summary>
        /// 更新制剂配置计划
        /// </summary>
        /// <param name="info">制剂配置计划主信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int UpdatePreparationConfect(Neusoft.HISFC.Models.Preparation.Preparation info)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationConfect", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationConfect";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   info.PlanNO, 
									   info.Drug.ID,                                        
									   info.OperEnv.ID,					    //配制员
									   info.ConfectEnv.OperTime.ToString(),		//配制时间
									   NConvert.ToInt32(info.IsClear).ToString()
								   };
                strSQL = string.Format(strSQL, strParm);              //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新制剂配置检验
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdatePreparationAssay(Neusoft.HISFC.Models.Preparation.Preparation info)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationAssay", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationAssay";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   info.PlanNO, 
									   info.Drug.ID, 
                                       info.AssayQty.ToString(),
                                       NConvert.ToInt32(info.IsAssayEligible).ToString(),
									   info.OperEnv.ID,					    //配制员
									   info.OperEnv.OperTime.ToString(),		//配制时间
									   NConvert.ToInt32(info.IsClear).ToString()
								   };
                strSQL = string.Format(strSQL, strParm);              //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 制剂成品入库操作
        /// </summary>
        /// <param name="preparation">制剂主实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdatePreparationInput(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationInput", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationInput";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   preparation.PlanNO, 
									   preparation.Drug.ID,
									   preparation.InputState,				//成品入库状态 0 暂入库 1 正式入库
									   preparation.InputQty.ToString(),		//入库数量
									   preparation.InputEnv.ID,				//入库操作人
									   preparation.InputEnv.OperTime.ToString(),	//入库操作时间
									   preparation.CheckResult,				//审核意见
									   preparation.CheckOper,				//审核员
									   preparation.Extend1,					//扩展字段  (入库时存储物料平衡 0 不合格 1 合格)
									   preparation.Extend2,				//扩展字段1 (入库时存储生产质控情况 0 不合格 1 合格)
									   NConvert.ToInt32(preparation.IsClear).ToString(),
                                       preparation.CostPrice.ToString()
								   };
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 制剂状态更新
        /// </summary>
        /// <param name="preparation">制剂信息</param>
        /// <param name="saveState">数据保存</param>
        /// <param name="oldStateCollection">允许的更新前状态</param>
        /// <returns>成功返回更新影响条目数，失败返回－1</returns>
        public int UpdatePreparationState(Neusoft.HISFC.Models.Preparation.Preparation preparation, EnumState saveState,params EnumState[] oldStateCollection)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationState", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationState";
                return -1;
            }
            string oldStates = "";
            foreach (EnumState state in oldStateCollection)
            {
                oldStates = oldStates + ((int)state).ToString() + "','";
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   preparation.PlanNO, 
									   preparation.Drug.ID,
                                       oldStates,
                                       ((int)saveState).ToString(),                                       
									   this.Operator.ID						//操作员
								   };
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 制剂消耗

        #region 基础增、删、改操作

        /// <summary>
        /// 根据制剂消耗信息获取参数数组
        /// </summary>
        /// <param name="expand">制剂消耗信息实体</param>
        /// <returns>成功返回对应的参数数组</returns>
        private string[] myGetExpandParam(Neusoft.HISFC.Models.Preparation.Expand expand)
        {

            string[] strParam = {
									expand.PlanNO,					                    //生产计划编号
									expand.Prescription.Drug.ID,				        //成品编码
									expand.Prescription.Drug.Name,				        //成品名称
									expand.Prescription.Drug.Specs,				        //成品规格
                                    ((int)expand.Prescription.MaterialType).ToString(), //生产原料类型
                                    expand.Prescription.Material.ID,                    //原料编码
                                    expand.Prescription.Material.Name,                  //原料名称
                                    expand.Prescription.Specs,                          //原料规格
                                    expand.Prescription.Price.ToString(),               //原料价格
                                    expand.Prescription.NormativeQty.ToString(),        //标准处方量
                                    expand.Prescription.NormativeUnit,                  //单位
                                    expand.PlanQty.ToString(),                          //计划配液量
                                    expand.PlanExpand.ToString(),                       //理论消耗量
                                    expand.StoreQty.ToString(),                         //库存量
                                    expand.FacutalExpand.ToString(),                    //实际消耗量 
                                    NConvert.ToInt32(expand.ExecOutput).ToString(),     //是否已执行扣库                   
									expand.Memo,					                    //备注	
									expand.Prescription.OperEnv.Name,				    //操作员
									expand.Prescription.OperEnv.OperTime.ToString(), 	//操作时间
                                    expand.Prescription.MaterialPackQty.ToString()
								};
            return strParam;
        }

        /// <summary>
        /// 执行Sql语句获取制剂消耗信息
        /// </summary>
        /// <param name="strSql">欲执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private List<Neusoft.HISFC.Models.Preparation.Expand> myGetExpandList(string strSql)
        {
            List<Neusoft.HISFC.Models.Preparation.Expand> al = new List<Neusoft.HISFC.Models.Preparation.Expand>();
            Neusoft.HISFC.Models.Preparation.Expand info;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.Preparation.Expand();

                    info.PlanNO = this.Reader[0].ToString();			//生产计划编码
                    info.Prescription.Drug.ID = this.Reader[1].ToString();			//成品编码
                    info.Prescription.Drug.Name = this.Reader[2].ToString();			//成品名称
                    info.Prescription.Drug.Specs = this.Reader[3].ToString();		//成品规格
                    info.Prescription.MaterialType = ((EnumMaterialType)(NConvert.ToInt32(this.Reader[4]))); //生产原料类型
                    info.Prescription.Material.ID = this.Reader[5].ToString();                  //原料编码
                    info.Prescription.Material.Name = this.Reader[6].ToString();               //原料名称
                    info.Prescription.Specs = this.Reader[7].ToString();                          //原料规格
                    info.Prescription.Price = NConvert.ToDecimal(this.Reader[8]);              //原料价格
                    info.Prescription.NormativeQty = NConvert.ToDecimal(this.Reader[9]);       //标准处方量
                    info.Prescription.NormativeUnit = this.Reader[10].ToString();                 //单位
                    info.PlanQty = NConvert.ToDecimal(this.Reader[11]);                                     //计划配液量
                    info.PlanExpand = NConvert.ToDecimal(this.Reader[12]);                                  //理论消耗量
                    info.StoreQty = NConvert.ToDecimal(this.Reader[13]);                                   //库存量
                    info.FacutalExpand = NConvert.ToDecimal(this.Reader[14]);                              //实际消耗量   
                    info.ExecOutput = NConvert.ToBoolean(this.Reader[15]);                  //是否已执行扣库 1 已执行 0 未执行 
                    info.Memo = this.Reader[16].ToString();
                    info.Prescription.OperEnv.Name = this.Reader[17].ToString();
                    info.Prescription.OperEnv.OperTime = NConvert.ToDateTime(this.Reader[18].ToString());
                    info.Prescription.MaterialPackQty = NConvert.ToDecimal(this.Reader[19]);

                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取制剂主信息信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 向制剂消耗表内插入新记录
        /// </summary>
        /// <param name="expand">制剂消耗实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertExpand(Neusoft.HISFC.Models.Preparation.Expand expand)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.InsertExpand", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetExpandParam(expand); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.InsertExpand" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新一条已有制剂消耗表信息
        /// </summary>
        /// <param name="expand">制剂消耗实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdateExpand(Neusoft.HISFC.Models.Preparation.Expand expand)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdateExpand", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetExpandParam(expand); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.UpdateExpand" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除制剂消耗记录
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="productCode">成品编码</param>
        /// <param name="type">原料类别</param>
        /// <param name="materialCode">原料编码</param>
        /// <returns>成功返回删除条数  失败返回-1</returns>
        public int DelExpand(string planNo, string productCode,Neusoft.HISFC.Models.Preparation.EnumMaterialType type,string materialCode)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.DelExpand", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, planNo, productCode, ((int)type).ToString(), materialCode);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.PPR.Preparation.DelExpand";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        /// <summary>
        /// 生成制剂消耗信息
        /// </summary>
        /// <param name="expand">制剂消耗信息</param>
        /// <returns>成功返回1  失败返回－1</returns>
        public int SetExpand(Neusoft.HISFC.Models.Preparation.Expand expand)
        {
            int param = this.UpdateExpand(expand);
            if (param == 0)
            {
                return this.InsertExpand(expand);
            }

            return param;
        }

        /// <summary>
        /// 根据单据号、成品编码获取成品消耗信息
        /// </summary>
        /// <param name="listCode">单据号</param>
        /// <param name="productCode">成品编码</param>
        /// <returns>成功返回成品消耗信息 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Expand> QueryExpand(string listCode, string productCode)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Prescription.GetExpand", ref strSelect) == -1)
            {
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.PPR.Prescription.GetExpand.Where", ref strSQL) == -1)
            {
                return null;
            }
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, listCode, productCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Prescription.GetPrescription:" + ex.Message;
                return null;
            }
            return  this.myGetExpandList(strSQL);
        }

        /// <summary>
        /// 制剂原料消耗信息获取
        /// </summary>
        /// <param name="info">制剂原料信息</param>
        /// <returns>成功返回消耗信息集合，失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Expand> QueryExpand(Neusoft.HISFC.Models.Preparation.Preparation info, Neusoft.FrameWork.Models.NeuObject stockDept)
        {
            //{8840008D-2FEA-4471-B404-B05E25832120}  当消耗信息不存在时，获取库存
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Item();
            if (this.Trans != null)
            {
                itemManager.SetTrans(this.Trans);
            }

            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = this.QueryExpand(info.PlanNO, info.Drug.ID);
            if (expandList == null)
            {
                return null;
            }
            else if (expandList.Count == 0)
            {
                List<Neusoft.HISFC.Models.Preparation.Prescription> prescriptionList = this.QueryDrugPrescription(info.Drug.ID);
                if (prescriptionList == null)
                {
                    return null;
                }
                if (prescriptionList.Count == 0)
                {
                    this.Err = "未设置制剂配置处方";
                    return null;
                }

                Neusoft.HISFC.Models.Preparation.Expand expand = null;
                foreach (Neusoft.HISFC.Models.Preparation.Prescription prescription in prescriptionList)
                {
                    expand = new Expand();

                    expand.Prescription = prescription;
                    expand.PlanNO = info.PlanNO;
                    expand.PlanExpand = expand.Prescription.NormativeQty * info.PlanQty;
                    expand.PlanQty = info.PlanQty;

                    //{8840008D-2FEA-4471-B404-B05E25832120}  当消耗信息不存在时，获取库存
                    if (stockDept != null)
                    {
                        decimal storeQty = 0;
                        if (itemManager.GetStorageNum(stockDept.ID, expand.Prescription.Material.ID, out storeQty) == -1)
                        {
                            this.Err = "加载原料库存发生错误" + itemManager.Err;
                            return null;
                        }
                        expand.StoreQty = storeQty;
                    }
                    //{8840008D-2FEA-4471-B404-B05E25832120}  获取库存

                    //{E261A3CB-0A68-4a9e-99A0-4A6ED1ACFA4B}
                    expand.FacutalExpand = expand.PlanExpand;

                    expandList.Add(expand);
                }
            }

            return expandList;

        }

        /// <summary>
        /// 制剂原料消耗信息获取
        /// </summary>
        /// <param name="info">制剂原料信息</param>
        /// <returns>成功返回消耗信息集合，失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Expand> QueryExpand(Neusoft.HISFC.Models.Supply.Product info)
        {
            List<Neusoft.HISFC.Models.Preparation.Expand> expandList = this.QueryExpand(info.ProductiveListNO, info.UnDrug.ID);
            if (expandList == null)
            {
                return null;
            }
            else if (expandList.Count == 0)
            {
                List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> prescriptionList = this.QueryPrescription(info.UnDrug.ID, Neusoft.HISFC.Models.Base.EnumItemType.UnDrug);
                if (prescriptionList == null)
                {
                    return null;
                }
                if (prescriptionList.Count == 0)
                {
                    this.Err = "未设置制剂配置处方";
                    return null;
                }

                Neusoft.HISFC.Models.Preparation.Expand expand = null;
                foreach (Neusoft.HISFC.Models.Preparation.PrescriptionBase prescription in prescriptionList)
                {
                    expand = new Expand();

                    expand.Prescription = prescription as Prescription;
                    expand.PlanNO = info.ProductiveListNO;
                    expand.PlanExpand = expand.Prescription.NormativeQty * info.PlanQty;
                    expand.PlanQty = info.PlanQty;
                    expand.StoreQty = 0;
                    expand.FacutalExpand = 0;

                    expandList.Add(expand);
                }
            }

            return expandList;

        }

        #endregion

        #region 生产工艺流程描述

        /// <summary>
        /// 获取Sql语句执行参数数组
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string[] GetProcessParam(Neusoft.HISFC.Models.Preparation.Process p)
        {
            string[] param = new string[] { 
                                            p.Preparation.PlanNO,
                                            p.Preparation.Drug.ID,
                                            p.Preparation.Drug.Name,
                                            p.Preparation.Drug.Specs,
                                            p.Preparation.Drug.PackUnit,
                                            p.Preparation.Drug.PackQty.ToString(),
                                            ((int)p.Preparation.State).ToString(),
                                            p.ProcessItem.ID,
                                            p.ProcessItem.Name,
                                            p.ResultQty.ToString(),
                                            p.ResultStr,
                                            p.Oper.ID,
                                            p.Oper.OperTime.ToString(),
                                            p.Extend,
                                            p.ItemType,
                                            NConvert.ToInt32(p.IsEligibility).ToString()
                                          };

            return param;
        }

        /// <summary>
        /// 执行Sql语句获取生产工艺数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.Preparation.Process> ExecSqlForPreparationProcess(string strSql)
        {
            List<Neusoft.HISFC.Models.Preparation.Process> al = new List<Neusoft.HISFC.Models.Preparation.Process>();
            Neusoft.HISFC.Models.Preparation.Process info;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.Preparation.Process();

                    info.Preparation.PlanNO = this.Reader[0].ToString();			//生产计划编码
                    info.Preparation.Drug.ID = this.Reader[1].ToString();			//成品编码
                    info.Preparation.Drug.Name = this.Reader[2].ToString();			//成品名称
                    info.Preparation.Drug.Specs = this.Reader[3].ToString();		//成品规格
                    info.Preparation.Drug.PackUnit = this.Reader[4].ToString();
                    info.Preparation.Drug.PackQty = NConvert.ToDecimal(this.Reader[5]);
                    info.Preparation.State = (EnumState)(NConvert.ToInt32(this.Reader[6]));
                    info.ProcessItem.ID = this.Reader[7].ToString();
                    info.ProcessItem.Name = this.Reader[8].ToString();

                    info.ResultQty = NConvert.ToDecimal(this.Reader[9].ToString());

                    info.ResultStr = this.Reader[10].ToString();
                    info.Oper.ID = this.Reader[11].ToString();
                    info.Oper.OperTime = NConvert.ToDateTime(this.Reader[12].ToString());
                    info.Extend = this.Reader[13].ToString();

                    info.ItemType = this.Reader[14].ToString();
                    info.IsEligibility = NConvert.ToBoolean(this.Reader[15]);

                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取制剂主信息信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获取工艺流程记录信息
        /// </summary>
        /// <param name="planNO">生产计划编码</param>
        /// <param name="drugCode">成品编码</param>
        /// <param name="state">流程状态</param>
        /// <returns>成功返回工艺流程记录信息 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Process> QueryProcess(string planNO, string drugCode, string state)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.GetProcess", ref strSelect) == -1)
            {
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.GetProcess.Where", ref strSQL) == -1)
            {
                return null;
            }

            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, planNO, drugCode, state);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Preparation.GetProcess:" + ex.Message;
                return null;
            }
            return this.ExecSqlForPreparationProcess(strSQL);
        }

        /// <summary>
        /// 插入制剂生产工艺流程信息
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int InsertProcess(Neusoft.HISFC.Models.Preparation.Process p)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.InsertProcess", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetProcessParam(p); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.InsertProcess" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新制剂生产工艺流程信息
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int UpdateProcess(Neusoft.HISFC.Models.Preparation.Process p)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdateProcess", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.GetProcessParam(p); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.UpdateProcess" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        public int SetProcess(Neusoft.HISFC.Models.Preparation.Process p)
        {
            int parm = this.UpdateProcess(p);
            if (parm == -1)
            {
                return -1;
            }
            else if (parm == 0)
            {
                return this.InsertProcess(p);
            }
            return 1;
        }

        /// <summary>
        /// 删除生产工艺流程
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int DelProcess(Neusoft.HISFC.Models.Preparation.Process p)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.DelProcess", ref strSQL) == -1) return -1;
            try
            {
                //string[] strParm = this.GetProcessParam(p); //取参数列表
                strSQL = string.Format(strSQL, p.Preparation.PlanNO, p.Preparation.Drug.ID, ((int)p.Preparation.State).ToString(), p.ProcessItem.ID);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.DelProcess" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }


        #endregion

        #region 制剂成品模版 － 检验模版

        /// <summary>
        /// 获取模版明细记录流水号
        /// </summary>
        /// <returns>成功返回流水号 失败返回null</returns>
        private string GetStencilSequence()
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Preparation.GetStencilSequence", ref strSQL) == -1)
                return null;
            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "取药品出库单流水号时出错！" + this.Err;
                return null;
            }
            return strReturn;
        }

        /// <summary>
        /// 根据制剂成品模版获取参数数组
        /// </summary>
        /// <param name="stencil">制剂成品模版</param>
        /// <returns>成功返回对应的参数数组</returns>
        private string[] myGetStencilParam(Stencil stencil)
        {
            stencil.Item.ID = stencil.ID;

            string[] strParam = 
                {
                    stencil.ID,                 //流水主键
                    stencil.Drug.ID,			//成品编码
                    stencil.Drug.Name,			//成品名称
                    stencil.Drug.Specs,			//成品规格
                    ((int)stencil.Kind).ToString(),				//模版类别 0 半成品检验模版  1 成品检验模版 2 生产流程 3 其他
                    stencil.Type.ID,			//类别编码
                    stencil.Type.Name,			//类别名称
                    stencil.ItemType.ToString(),//项目类别
                    stencil.Item.ID,			//项目编码
                    stencil.Item.Name,			//项目名称
                    stencil.StandardMin.ToString(), //标准区间最小值
                    stencil.StandardMax.ToString(), //标准区间最大值
                    stencil.StandardDes,            //标准现象
                    stencil.Memo,				//备注
                    stencil.Extend,				//扩展字段
                    stencil.Name,			    //维护人
                    stencil.OperEnv.OperTime.ToString() //维护时间
                };
            return strParam;
        }

        /// <summary>
        /// 执行Sql语句获取成品模版实体
        /// </summary>
        /// <param name="strSql">欲执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private List<Stencil> myGetStencil(string strSql)
        {
            List<Stencil> al = new List<Stencil>();
            Stencil stencil;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    stencil = new Stencil();

                    stencil.ID = this.Reader[0].ToString();                 //流水主键
                    stencil.Drug.ID = this.Reader[1].ToString();			//成品编码
                    stencil.Drug.Name = this.Reader[2].ToString();			//成品名称
                    stencil.Drug.Specs = this.Reader[3].ToString();			//成品规格
                    stencil.Kind = (EnumStencialType)(NConvert.ToInt32(this.Reader[4].ToString()));				//类别
                    stencil.Type.ID = this.Reader[5].ToString();			//类别编码
                    stencil.Type.Name = this.Reader[6].ToString();			//类别名称
                    stencil.ItemType = (EnumStencilItemType)Enum.Parse(typeof(EnumStencilItemType), this.Reader[7].ToString());
                    stencil.Item.ID = this.Reader[8].ToString();			//项目编码
                    stencil.Item.Name = this.Reader[9].ToString();			//项目名称
                    stencil.StandardMin = NConvert.ToDecimal(this.Reader[10]);
                    stencil.StandardMax = NConvert.ToDecimal(this.Reader[11]);
                    stencil.StandardDes = this.Reader[12].ToString();
                    stencil.Memo = this.Reader[13].ToString();				//备注
                    stencil.Extend = this.Reader[14].ToString();
                    stencil.OperEnv.ID = this.Reader[15].ToString();
                    stencil.OperEnv.OperTime = NConvert.ToDateTime(this.Reader[16].ToString());

                    stencil.Item.ID = stencil.ID;

                    al.Add(stencil);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取成品模版信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 向制剂成品模版表内插入新记录
        /// </summary>
        /// <param name="stencil">制剂成品模版</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertStencil(Stencil stencil)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Stencil.InsertStencil", ref strSQL) == -1) return -1;
            try
            {
                if (stencil.ID == "" || stencil.ID == null)
                {
                    stencil.ID = this.GetStencilSequence();
                }
                if (stencil.ID == "" || stencil.ID == null)
                {
                    return -1;
                }
                stencil.Item.ID = stencil.ID;

                string[] strParm = this.myGetStencilParam(stencil); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Stencil.InsertStencil" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新一条已有成品模版配制信息
        /// </summary>
        /// <param name="stencil">制剂成品模版</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdateStencil(Stencil stencil)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Stencil.UpdateStencil", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetStencilParam(stencil); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQL参数赋值时出错！Pharmacy.PPR.Stencil.UpdateStencil" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 先执行更新操作 更新不成功则执行插入操作
        /// </summary>
        /// <param name="stencil">制剂成品模版</param>
        /// <returns>成功返回操作记录数 失败返回-1</returns>
        public int SetStencil(Stencil stencil)
        {
            if (stencil.ID == null || stencil.ID == "")
            {
                return this.InsertStencil(stencil);
            }
            int parm = this.UpdateStencil(stencil);
            if (parm < 1)
            {
                parm = this.InsertStencil(stencil);
            }
            return parm;
        }

        /// <summary>
        /// 删除成品模版记录
        /// </summary>
        /// <param name="id">流水主键</param
        /// <returns>成功返回删除条数  失败返回-1</returns>
        public int DelStencil(string id)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Stencil.DelStencil", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, id);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.PPR.Stencil.DelStencil";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除某个成品的配制处方
        /// </summary>
        /// <param name="drugCode">成品编码</param>
        /// <param name="kind">模版类别 </param>
        /// <returns>成功返回删除记录数  失败返回-1</returns>
        public int DelStencil(string drugCode, EnumStencialType kind)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Stencil.DelStencil.Drug", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, drugCode,((int)kind).ToString());
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.PPR.Stencil.DelStencil";
                return -1;
            }
            return this.ExecNoQuery(strSQL);

        }

        /// <summary>
        /// 获取某成品模版信息
        /// </summary>
        /// <param name="drugCode">成品编码</param>
        /// <param name="kind">模版类别 </param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public List<Stencil> QueryStencil(string drugCode, EnumStencialType kind)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Stencil.GetStencil", ref strSelect) == -1)
                return null;
            if (this.Sql.GetSql("Pharmacy.PPR.Stencil.GetStencil.Where.1", ref strSQL) == -1)
                return null;
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, drugCode, ((int)kind).ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Stencil.GetStencil:" + ex.Message;
                return null;
            }
            return this.myGetStencil(strSQL);
        }

        /// <summary>
        /// 获取某成品模版信息
        /// </summary>
        /// <param name="kind">模版类别</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public List<Stencil> QueryStencil(EnumStencialType kind)
        {
            return this.QueryStencil("AAAA", kind);
        }

        #endregion

        #region 暂时不使用

        #region 各流程制剂主表更新

        /// <summary>
        /// 配制确认 更新制剂表
        /// </summary>
        /// <param name="confect">制剂配制实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        public int UpdatePreparation(Confect confect)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationConfect", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationConfect";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
                                       confect.PlanNO, 
                                       confect.Drug.ID, 
                                       confect.Name,					//配制员
                                       confect.ConfectEnv.OperTime.ToString(),		//配制时间
                                       NConvert.ToInt32(confect.IsClear).ToString(),
                                       this.Operator.ID						//操作员
                                   };
                strSQL = string.Format(strSQL, strParm);              //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对半成品/成品检验更新制剂主表
        /// </summary>
        /// <param name="assay">制剂检验实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        public int UpdatePreparation(Assay assay)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationAssay", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationAssay";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
                                       assay.PlanNO, 
                                       assay.Drug.ID,
                                       ((int)assay.State).ToString(),
                                       assay.AssayQty.ToString(),		//送检数量
                                       NConvert.ToInt32(assay.IsEligibility).ToString(),
                                       assay.Name,					//检验人
                                       assay.AssayEnv.OperTime.ToString(),		//检验时间
                                       NConvert.ToInt32(assay.IsClear).ToString(),
                                       this.Operator.ID					//操作员
                                   };
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对制剂清场记录更新制剂主表
        /// </summary>
        /// <param name="clear">制剂清场</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        public int UpdatePreparation(Clear clear)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationClear", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationClear";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
                                       clear.PlanNO, 
                                       clear.Drug.ID,
                                       ((int)clear.State).ToString(),
                                       NConvert.ToInt32(clear.IsCleaner).ToString(),
                                       clear.Name,
                                       clear.ClearEnv.OperTime.ToString()
                                   };
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion        

        #region 成品配制
        /// <summary>
        /// 根据制剂制剂配制信息获取参数数组
        /// </summary>
        /// <param name="confect">制剂配制实体</param>
        /// <returns>成功返回对应的参数数组</returns>
        private string[] myGetConfectParam(Confect confect)
        {
            string[] strParam = 
                {
                    confect.PlanNO,						//生产计划编码
                    confect.Drug.ID,					//成品编码
                    confect.Drug.Name,					//成品名称
                    confect.Drug.Specs,					//规格
                    confect.Drug.PackUnit,				//成品包装单位
                    confect.Drug.PackQty.ToString(),	//成品包装数量
                    confect.Unit,						//配液量单位
                    confect.BatchNO,					//成品批号
                    confect.PlanQty.ToString(),			//计划配液量
                    confect.AssayQty.ToString(),		//送检样品量
                    NConvert.ToInt32(confect.IsWhole).ToString(),		//配制设备是否完好
                    NConvert.ToInt32(confect.IsCleanness).ToString(),	//配制设备是否清洁
                    confect.ScaleFlag,					//药物天平衡器校验
                    confect.StetlyardFlag,				//磅秤衡器校验
                    confect.Regulations,				//规程名
                    confect.Quality,					//质量情况
                    confect.Execute,					//工艺执行情况
                    confect.Name,				//配制人
                    confect.ConfectEnv.OperTime.ToString(),		//配制时间
                    confect.CheckOper,					//配制复核人
                    confect.Memo,						
                    confect.Extend1
                };
            return strParam;
        }

        /// <summary>
        /// 执行Sql语句获取制剂配制数组
        /// </summary>
        /// <param name="strSql">欲执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private ArrayList myGetConfect(string strSql)
        {
            ArrayList al = new ArrayList();
            Confect confect;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    confect = new Confect();

                    confect.PlanNO = this.Reader[0].ToString();				//生产计划编码
                    confect.Drug.ID = this.Reader[1].ToString();			//成品编码
                    confect.Drug.Name = this.Reader[2].ToString();			//成品名称
                    confect.Drug.Specs = this.Reader[3].ToString();			//成品规格
                    confect.Drug.PackUnit = this.Reader[4].ToString();		//成品包装单位
                    confect.Drug.PackQty = NConvert.ToDecimal(this.Reader[5].ToString());	//成品包装数量
                    confect.Unit = this.Reader[6].ToString();				//计划配液量单位
                    confect.BatchNO = this.Reader[7].ToString();			//成品批号
                    confect.PlanQty = NConvert.ToDecimal(this.Reader[8].ToString());		//计划配液量
                    confect.AssayQty = NConvert.ToDecimal(this.Reader[9].ToString());		//送检样品量
                    confect.IsWhole = NConvert.ToBoolean(this.Reader[10].ToString());		//设备是否完好
                    confect.IsCleanness = NConvert.ToBoolean(this.Reader[11].ToString());	//设备是否清洁
                    confect.ScaleFlag = this.Reader[12].ToString();
                    confect.StetlyardFlag = this.Reader[13].ToString();
                    confect.Regulations = this.Reader[14].ToString();
                    confect.Quality = this.Reader[15].ToString();
                    confect.Execute = this.Reader[16].ToString();
                    confect.Name = this.Reader[17].ToString();
                    confect.ConfectEnv.OperTime = NConvert.ToDateTime(this.Reader[18].ToString());
                    confect.CheckOper = this.Reader[19].ToString();
                    confect.Memo = this.Reader[20].ToString();
                    confect.Extend1 = this.Reader[21].ToString();

                    al.Add(confect);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取成品模版信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }
        /// <summary>
        /// 向制剂配制信息内插入新记录
        /// </summary>
        /// <param name="confect">制剂配制实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertConfect(Confect confect)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Confect.InsertConfect", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetConfectParam(confect); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Confect.InsertConfect" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新一条已有制剂配制信息
        /// </summary>
        /// <param name="confect">制剂配制实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdateConfect(Confect confect)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Confect.UpdateConfect", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetConfectParam(confect); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Confect.UpdateConfect" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 先执行更新操作 更新不成功则执行插入操作
        /// </summary>
        /// <param name="confect">制剂配制实体</param>
        /// <returns>成功返回操作记录数 失败返回-1</returns>
        public int SetConfect(Confect confect)
        {
            int parm = this.UpdateConfect(confect);
            if (parm < 1)
            {
                parm = this.InsertConfect(confect);
            }
            return parm;
        }
        /// <summary>
        /// 获取某成品配制信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="drugCode">成品编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryConfect(string planNo, string drugCode)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Confect.GetConfect", ref strSelect) == -1)
                return null;
            if (this.Sql.GetSql("Pharmacy.PPR.Where.DrugCode", ref strSQL) == -1)
                return null;
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, planNo, drugCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Confect.GetConfect:" + ex.Message;
                return null;
            }
            return this.myGetConfect(strSQL);
        }
        /// <summary>
        /// 获取某成品配制信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryConfect(string planNo)
        {
            return this.QueryConfect(planNo, "AAAA");
        }
        #endregion

        #region 成品分装
        /// <summary>
        /// 根据制剂制剂分装信息获取参数数组
        /// </summary>
        /// <param name="division">制剂分装实体</param>
        /// <returns>成功返回对应的参数数组</returns>
        private string[] myGetDivisiontParam(Division division)
        {
            string[] strParam = 
                {
                    division.PlanNO,					//生产计划编码
                    division.Drug.ID,					//成品编码
                    division.Drug.Name,					//成品名称
                    division.Drug.Specs,				//规格
                    division.Drug.PackUnit,				//成品包装单位
                    division.Drug.PackQty.ToString(),	//成品包装数量
                    division.Unit,						//配液量单位
                    division.BatchNO,					//成品批号
                    division.PlanQty.ToString(),		//计划配液量
                    division.DivisionQty.ToString(),	//分装量
                    division.WasterQty.ToString(),		//废品量
                    division.AssayQty.ToString(),		//送检样品量
                    division.DivisionParam.ToString(),	//物料平衡
                    NConvert.ToInt32(division.IsWhole).ToString(),		//设备是否完好
                    NConvert.ToInt32(division.IsCleanness).ToString(),	//设备是否清洁
                    division.Regulations,				//规程名
                    division.Quality,					//质量情况
                    division.Execute,					//工艺执行情况
                    division.Name,				//分装人
                    division.DivisionEnv.OperTime.ToString(),	//分装时间
                    division.InceptOper,				//入库移交人
                    division.Memo,						
                    division.Extend1
                };
            return strParam;
        }

        /// <summary>
        /// 执行Sql语句获取制剂分装数组
        /// </summary>
        /// <param name="strSql">欲执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private ArrayList myGetDivision(string strSql)
        {
            ArrayList al = new ArrayList();
            Division division;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    division = new Division();

                    division.PlanNO = this.Reader[0].ToString();				//生产计划编码
                    division.Drug.ID = this.Reader[1].ToString();				//成品编码
                    division.Drug.Name = this.Reader[2].ToString();				//成品名称
                    division.Drug.Specs = this.Reader[3].ToString();			//成品规格
                    division.Drug.PackUnit = this.Reader[4].ToString();			//成品包装单位
                    division.Drug.PackQty = NConvert.ToDecimal(this.Reader[5].ToString());	//成品包装数量
                    division.Unit = this.Reader[6].ToString();					//计划配液量单位
                    division.BatchNO = this.Reader[7].ToString();				//成品批号
                    division.PlanQty = NConvert.ToDecimal(this.Reader[8].ToString());		//计划配液量
                    division.DivisionQty = NConvert.ToDecimal(this.Reader[9].ToString());	//分装样品量
                    division.WasterQty = NConvert.ToDecimal(this.Reader[10].ToString());	//废品量
                    division.AssayQty = NConvert.ToDecimal(this.Reader[11].ToString());		//送检样品量
                    division.DivisionParam = NConvert.ToDecimal(this.Reader[12].ToString());//物料平衡
                    division.IsWhole = NConvert.ToBoolean(this.Reader[13].ToString());		//设备是否完好
                    division.IsCleanness = NConvert.ToBoolean(this.Reader[14].ToString());	//设备是否清洁
                    division.Regulations = this.Reader[15].ToString();
                    division.Quality = this.Reader[16].ToString();
                    division.Execute = this.Reader[17].ToString();
                    division.Name = this.Reader[18].ToString();
                    division.DivisionEnv.OperTime = NConvert.ToDateTime(this.Reader[19].ToString());
                    division.InceptOper = this.Reader[20].ToString();
                    division.Memo = this.Reader[21].ToString();
                    division.Extend1 = this.Reader[22].ToString();

                    al.Add(division);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取成品分装信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }
        /// <summary>
        /// 向制剂分装信息内插入新记录
        /// </summary>
        /// <param name="division">制剂分装实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertDivision(Division division)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Division.InsertDivision", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetDivisiontParam(division); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Division.InsertDivision" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新一条已有制剂分装信息
        /// </summary>
        /// <param name="division">制剂分装实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdateDivision(Division division)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Division.UpdateDivision", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetDivisiontParam(division); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Division.UpdateDivision" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 先执行更新操作 更新不成功则执行插入操作
        /// </summary>
        /// <param name="division">制剂分装实体</param>
        /// <returns>成功返回操作记录数 失败返回-1</returns>
        public int SetDivision(Division division)
        {
            int parm = this.UpdateDivision(division);
            if (parm < 1)
            {
                parm = this.InsertDivision(division);
            }
            return parm;
        }
        /// <summary>
        /// 获取某成品分装信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="drugCode">成品编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryDivision(string planNo, string drugCode)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Division.GetDivision", ref strSelect) == -1)
                return null;
            if (this.Sql.GetSql("Pharmacy.PPR.Where.DrugCode", ref strSQL) == -1)
                return null;
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, planNo, drugCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Division.GetDivision:" + ex.Message;
                return null;
            }
            return this.myGetDivision(strSQL);
        }
        /// <summary>
        /// 获取某成品分装信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryDivision(string planNo)
        {
            return this.QueryDivision(planNo, "AAAA");
        }
        #endregion

        #region 成品外包装
        /// <summary>
        /// 根据制剂制剂外包装信息获取参数数组
        /// </summary>
        /// <param name="package">制剂外包装实体</param>
        /// <returns>成功返回对应的参数数组</returns>
        private string[] myGetPackageParam(Package package)
        {
            string[] strParam = 
                {
                    package.PlanNO,						//生产计划编码
                    package.Drug.ID,					//成品编码
                    package.Drug.Name,					//成品名称
                    package.Drug.Specs,					//规格
                    package.Drug.PackUnit,				//成品包装单位
                    package.Drug.PackQty.ToString(),	//成品包装数量
                    package.Unit,						//配液量单位
                    package.BatchNO,					//成品批号
                    package.PlanQty.ToString(),			//计划配液量
                    package.DivisionQty.ToString(),		//分装产品量
                    package.PackingQty.ToString(),		//外包装产品量
                    package.WasterQty.ToString(),		//外包装废品量
                    package.PacParam.ToString(),		//物料平衡
                    package.FinParam.ToString(),		//成品率
                    NConvert.ToInt32(package.IsCleanness).ToString(),		//是否清洁
                    NConvert.ToInt32(package.IsClear).ToString(),			//是否清场
                    package.Regulations,				//规程名
                    package.Quality,					//质量情况
                    package.Execute,					//工艺执行情况
                    package.Name,				//外包装人
                    package.PackingEnv.OperTime.ToString(),		//外包装时间
                    package.CheckOper,					//外包装复核人
                    package.InceptOper,					//入库接受人
                    package.Memo,						
                    package.Extend1
                };
            return strParam;
        }

        /// <summary>
        /// 执行Sql语句获取制剂外包装数组
        /// </summary>
        /// <param name="strSql">欲执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private ArrayList myGetPackage(string strSql)
        {
            ArrayList al = new ArrayList();
            Package package;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    package = new Package();

                    package.PlanNO = this.Reader[0].ToString();				//生产计划编码
                    package.Drug.ID = this.Reader[1].ToString();			//成品编码
                    package.Drug.Name = this.Reader[2].ToString();			//成品名称
                    package.Drug.Specs = this.Reader[3].ToString();			//成品规格
                    package.Drug.PackUnit = this.Reader[4].ToString();		//成品包装单位
                    package.Drug.PackQty = NConvert.ToDecimal(this.Reader[5].ToString());	//成品包装数量
                    package.Unit = this.Reader[6].ToString();				//计划配液量单位
                    package.BatchNO = this.Reader[7].ToString();			//成品批号
                    package.PlanQty = NConvert.ToDecimal(this.Reader[8].ToString());		//计划配液量
                    package.DivisionQty = NConvert.ToDecimal(this.Reader[9].ToString());	//分装产品量
                    package.PackingQty = NConvert.ToDecimal(this.Reader[10].ToString());	//外包装产品量
                    package.WasterQty = NConvert.ToDecimal(this.Reader[11].ToString());		//废品量
                    package.PacParam = NConvert.ToDecimal(this.Reader[12].ToString());		//物料平衡
                    package.FinParam = NConvert.ToDecimal(this.Reader[13].ToString());		//成品率
                    package.IsCleanness = NConvert.ToBoolean(this.Reader[14].ToString());	//是否清洁
                    package.IsClear = NConvert.ToBoolean(this.Reader[15].ToString());		//是否清场
                    package.Regulations = this.Reader[16].ToString();
                    package.Quality = this.Reader[17].ToString();
                    package.Execute = this.Reader[18].ToString();
                    package.Name = this.Reader[19].ToString();
                    package.PackingEnv.OperTime = NConvert.ToDateTime(this.Reader[20].ToString());
                    package.CheckOper = this.Reader[21].ToString();
                    package.InceptOper = this.Reader[22].ToString();
                    package.Memo = this.Reader[23].ToString();
                    package.Extend1 = this.Reader[24].ToString();

                    al.Add(package);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取成品外包装信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }
        /// <summary>
        /// 向制剂外包装信息内插入新记录
        /// </summary>
        /// <param name="package">制剂外包装实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertPackage(Package package)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Package.InsertPackage", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetPackageParam(package); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Package.InsertPackage" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新一条已有制剂外包装信息
        /// </summary>
        /// <param name="package">制剂外包装实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdatePackage(Package package)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Package.UpdatePackage", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetPackageParam(package); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Package.UpdatePackage" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 先执行更新操作 更新不成功则执行插入操作
        /// </summary>
        /// <param name="package">制剂外包装实体</param>
        /// <returns>成功返回操作记录数 失败返回-1</returns>
        public int SetPackage(Package package)
        {
            int parm = this.UpdatePackage(package);
            if (parm < 1)
            {
                parm = this.InsertPackage(package);
            }
            return parm;
        }
        /// <summary>
        /// 获取某成品外包装信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="drugCode">成品编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryPackage(string planNo, string drugCode)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Package.GetPackage", ref strSelect) == -1)
                return null;
            if (this.Sql.GetSql("Pharmacy.PPR.Where.DrugCode", ref strSQL) == -1)
                return null;
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, planNo, drugCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Package.GetPackage:" + ex.Message;
                return null;
            }
            return this.myGetPackage(strSQL);
        }
        /// <summary>
        /// 获取某成品外包装信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryPackage(string planNo)
        {
            return this.QueryPackage(planNo, "AAAA");
        }
        #endregion

        #region 制剂清场记录
        /// <summary>
        /// 根据制剂制剂清场信息获取参数数组
        /// </summary>
        /// <param name="clear">制剂清场实体</param>
        /// <returns>成功返回对应的参数数组</returns>
        private string[] myGetClearParam(Clear clear)
        {
            string[] strParam = {
                                    clear.PlanNO,						//生产过程编码
                                    ((int)clear.State).ToString(),						//生产过程标志 状态 1 配置 2 半成品分装 3 半成品检验4 成品外包装 5 成品检验 6 成品入库
                                    clear.Drug.ID,						//成品编码
                                    clear.Drug.Name,					//成品名称
                                    clear.Drug.Specs,					//规格
                                    clear.BatchNO,						//批号
                                    clear.PrivPlanNO,					//上一批次生产计划号
                                    clear.PrivDrugNum,					//上一批次成品编码
                                    NConvert.ToInt32(clear.IsMaterial).ToString(),	//物料是否合格
                                    NConvert.ToInt32(clear.IsMid).ToString(),		//中间品是否合格
                                    NConvert.ToInt32(clear.IsWaster).ToString(),	//废弃物品是否合格
                                    NConvert.ToInt32(clear.IsTechnics).ToString(),	//工艺是否合格
                                    NConvert.ToInt32(clear.IsTool).ToString(),		//工具是否合格
                                    NConvert.ToInt32(clear.IsContainer).ToString(),	//容器是否合格
                                    NConvert.ToInt32(clear.IsEquipment).ToString(),	//生产设备是否合格
                                    NConvert.ToInt32(clear.IsWorkShop).ToString(),	//工作场地是否合格
                                    NConvert.ToInt32(clear.IsCleaner).ToString(),	//洁具是否合格
                                    clear.Name,
                                    clear.ClearEnv.OperTime.ToString(),
                                    clear.CheckOper,
                                    clear.Memo,
                                    clear.Extend1
                                };
            return strParam;
        }
        /// <summary>
        /// 执行Sql语句获取制剂清场数组
        /// </summary>
        /// <param name="strSql">欲执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private ArrayList myGetClear(string strSql)
        {
            ArrayList al = new ArrayList();
            Clear clear;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    clear = new Clear();

                    clear.PlanNO = this.Reader[0].ToString();				//生产计划编码
                    clear.State = (EnumState)(NConvert.ToInt32(this.Reader[1].ToString()));				//生产过程标志 状态 1 配置 2 半成品分装 3 半成品检验 4 成品外包装 5 成品检验 6 成品入库
                    clear.Drug.ID = this.Reader[2].ToString();				//成品编码
                    clear.Drug.Name = this.Reader[3].ToString();			//成品名称
                    clear.Drug.Specs = this.Reader[4].ToString();			//成品规格
                    clear.BatchNO = this.Reader[5].ToString();				//成品批号
                    clear.PrivPlanNO = this.Reader[6].ToString();			//上一批次生产计划号
                    clear.PrivDrugNum = this.Reader[7].ToString();			//上一批次成品编码
                    clear.IsMaterial = NConvert.ToBoolean(this.Reader[8].ToString());	//物料是否合格
                    clear.IsMid = NConvert.ToBoolean(this.Reader[9].ToString());		//中间品是否合格
                    clear.IsWaster = NConvert.ToBoolean(this.Reader[10].ToString());	//废弃物是否合格
                    clear.IsTechnics = NConvert.ToBoolean(this.Reader[11].ToString());	//工艺是否合格
                    clear.IsTool = NConvert.ToBoolean(this.Reader[12].ToString());		//工具是否合格
                    clear.IsContainer = NConvert.ToBoolean(this.Reader[13].ToString());	//容器是否合格
                    clear.IsEquipment = NConvert.ToBoolean(this.Reader[14].ToString());	//生产设备是否合格
                    clear.IsWorkShop = NConvert.ToBoolean(this.Reader[15].ToString());	//生产场地是否合格
                    clear.IsCleaner = NConvert.ToBoolean(this.Reader[16].ToString());	//洁具是否合格
                    clear.Name = this.Reader[17].ToString();
                    clear.ClearEnv.OperTime = NConvert.ToDateTime(this.Reader[18].ToString());
                    clear.CheckOper = this.Reader[19].ToString();
                    clear.Memo = this.Reader[20].ToString();
                    clear.Extend1 = this.Reader[21].ToString();

                    al.Add(clear);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取成品清场信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }
        /// <summary>
        /// 向制剂清场信息内插入新记录
        /// </summary>
        /// <param name="clear">制剂清场实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertClear(Clear clear)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Clear.InsertClear", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetClearParam(clear); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Clear.InsertClear" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新一条已有制剂清场信息
        /// </summary>
        /// <param name="clear">制剂清场实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdateClear(Clear clear)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Clear.UpdateClear", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetClearParam(clear); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Clear.UpdateClear" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 先执行更新操作 更新不成功则执行插入操作
        /// </summary>
        /// <param name="clear">制剂清场实体</param>
        /// <returns>成功返回操作记录数 失败返回-1</returns>
        public int SetClear(Clear clear)
        {
            int parm = this.UpdateClear(clear);
            if (parm < 1)
            {
                parm = this.InsertClear(clear);
            }
            return parm;
        }
        /// <summary>
        /// 获取某成品清场信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="state">生产计划状态</param>
        /// <param name="drugCode">成品编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryClear(string planNo, string state, string drugCode)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Clear.GetClear", ref strSelect) == -1)
                return null;
            if (this.Sql.GetSql("Pharmacy.PPR.Where.DrugState", ref strSQL) == -1)
                return null;
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, planNo, state, drugCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Clear.GetClear:" + ex.Message;
                return null;
            }
            return this.myGetClear(strSQL);
        }
        /// <summary>
        /// 获取某成品清场信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="state">生产计划状态</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryClear(string planNo, string state)
        {
            return this.QueryClear(planNo, state, "AAAA");
        }

        /// <summary>
        /// 获取所有需要清场处理的制剂列表
        /// </summary>
        /// <param name="isClear">是否查询已做过清场记录的制剂信息 True 已做过清场记录 False 未做过清场记录</param>
        /// <param name="beginDate">查询开始时间</param>
        /// <param name="endDate">查询结束时间</param>
        /// <returns>成功返回对应数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Preparation.Preparation> QueryClearList(bool isClear, DateTime beginDate, DateTime endDate)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.GetPreparation", ref strSelect) == -1)
                return null;
            if (this.Sql.GetSql("Pharmacy.PPR.Clear.Where.ClearList", ref strSQL) == -1)
                return null;
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, NConvert.ToInt32(isClear), beginDate.ToString(), endDate.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Preparation.GetPreparation:" + ex.Message;
                return null;
            }
            return this.myGetPreparation(strSQL);
        }
        #endregion

        #region 制剂检验
        /// <summary>
        /// 根据制剂制剂检验信息获取参数数组
        /// </summary>
        /// <param name="assay">制剂检验实体</param>
        /// <returns>成功返回对应的参数数组</returns>
        private string[] myGetAssayParam(Assay assay)
        {
            string[] strParam = {
                                    assay.PlanNO,						//0 生产过程编码
                                    ((int)assay.State).ToString(),						//1 生产过程标志 状态 1 配置 2 半成品分装 3 半成品检验 4 成品外包装 5 成品检验 6 成品入库
                                    assay.Drug.ID,						//2 成品编码
                                    assay.Drug.Name,					//3 成品名称
                                    assay.Drug.Specs,					//4 规格
                                    assay.BatchNO,						//5 批号
                                    assay.ReportNum,						//6 报告书编号
                                    assay.Name,					//7 送检人
                                    assay.ApplyEnv.OperTime.ToString(),			//8 送检时间
                                    assay.DivisionQty.ToString(),		//9 生产量
                                    assay.AssayQty.ToString(),			//10 送检量
                                    assay.Unit,							//11 单位
                                    assay.Stencil.Type.ID,				//12 类别编码
                                    assay.Stencil.Type.Name,			//13 类别名称
                                    assay.Stencil.Item.ID,				//14 项目编码
                                    assay.Stencil.Item.Name,			//15 项目名称
                                    assay.Content.ToString(),			//16 检验含量
                                    assay.ResultQty.ToString(),			//17 数值检验结果
                                    assay.ResultStr,					//18 字符检验结果
                                    NConvert.ToInt32(assay.IsEligibility).ToString(),	//19 是否合格
                                    assay.AssayRule,					//20 检验标准依据
                                    assay.Name,					//21
                                    assay.CheckOper,					//22
                                    assay.AssayEnv.OperTime.ToString(),			//23
                                    assay.Memo,							//24
                                    assay.Extend1						//25
                                };
            return strParam;
        }
        /// <summary>
        /// 执行Sql语句获取制剂检验数组
        /// </summary>
        /// <param name="strSql">欲执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null 无记录返回空数组</returns>
        private ArrayList myGetAssay(string strSql)
        {
            ArrayList al = new ArrayList();
            Assay assay;

            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行Sql语句出错\n" + strSql + this.Err;
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    assay = new Assay();

                    assay.PlanNO = this.Reader[0].ToString();				//生产计划编码
                    assay.State = (EnumState)(NConvert.ToInt32(this.Reader[1].ToString()));				//生产过程标志 状态 1 配置 2 半成品分装 3 半成品检验 4 成品外包装 5 成品检验 6 成品入库
                    assay.Drug.ID = this.Reader[2].ToString();				//成品编码
                    assay.Drug.Name = this.Reader[3].ToString();			//成品名称
                    assay.Drug.Specs = this.Reader[4].ToString();			//成品规格
                    assay.BatchNO = this.Reader[5].ToString();				//成品批号
                    assay.ReportNum = this.Reader[6].ToString();				//报告书编号
                    assay.Name = this.Reader[7].ToString();						//送检人
                    assay.ApplyEnv.OperTime = NConvert.ToDateTime(this.Reader[8].ToString());	//送检日期
                    assay.DivisionQty = NConvert.ToDecimal(this.Reader[9].ToString());	//生产量
                    assay.AssayQty = NConvert.ToDecimal(this.Reader[10].ToString());		//送检量
                    assay.Unit = this.Reader[11].ToString();							//单位
                    assay.Stencil.Type.ID = this.Reader[12].ToString();					//类别编码
                    assay.Stencil.Type.Name = this.Reader[13].ToString();				//类别名称
                    assay.Stencil.Item.ID = this.Reader[14].ToString();					//项目编码
                    assay.Stencil.Item.Name = this.Reader[15].ToString();				//项目名称
                    assay.Content = NConvert.ToDecimal(this.Reader[16].ToString());		//检验含量
                    assay.ResultQty = NConvert.ToDecimal(this.Reader[17].ToString());	//数值检验结果
                    assay.ResultStr = this.Reader[18].ToString();	//字符检验结果
                    assay.IsEligibility = NConvert.ToBoolean(this.Reader[19].ToString());//洁具是否合格
                    assay.AssayRule = this.Reader[20].ToString();						//检验标准依据
                    assay.Name = this.Reader[21].ToString();
                    assay.CheckOper = this.Reader[22].ToString();
                    assay.AssayEnv.OperTime = NConvert.ToDateTime(this.Reader[23].ToString());
                    assay.Memo = this.Reader[24].ToString();
                    assay.Extend1 = this.Reader[25].ToString();

                    al.Add(assay);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内获取成品检验信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }
        /// <summary>
        /// 向制剂检验信息内插入新记录
        /// </summary>
        /// <param name="assay">制剂检验实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int InsertAssay(Assay assay)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Assay.InsertAssay", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetAssayParam(assay); //取参数列表
                strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Assay.InsertAssay" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新一条已有制剂检验信息
        /// </summary>
        /// <param name="assay">制剂检验实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        protected int UpdateAssay(Assay assay)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Assay.UpdateAssay", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = this.myGetAssayParam(assay); //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Assay.UpdateAssay" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 先执行更新操作 更新不成功则执行插入操作
        /// </summary>
        /// <param name="assay">制剂检验实体</param>
        /// <returns>成功返回操作记录数 失败返回-1</returns>
        public int SetAssay(Assay assay)
        {
            int parm = this.UpdateAssay(assay);
            if (parm < 1)
            {
                parm = this.InsertAssay(assay);
            }
            return parm;
        }
        /// <summary>
        /// 删除一条检验信息
        /// </summary>
        /// <param name="assay">检验实体</param>
        /// <returns>成功返回删除条数 失败返回-1</returns>
        public int DelAssay(Assay assay)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Assay.DelAssay", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, assay.PlanNO, assay.State, assay.Drug.ID, assay.Stencil.Type.ID, assay.Stencil.Item.ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.PPR.Assay.DelAssay";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 获取某成品检验信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="state">生产计划状态</param>
        /// <param name="drugCode">成品编码</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryAssay(string planNo, string state, string drugCode)
        {
            string strSelect = "";
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Assay.GetAssay", ref strSelect) == -1)
                return null;
            if (this.Sql.GetSql("Pharmacy.PPR.Where.DrugState", ref strSQL) == -1)
                return null;
            try
            {
                strSQL = strSelect + strSQL;
                strSQL = string.Format(strSQL, planNo, state, drugCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PPR.Assay.GetAssay:" + ex.Message;
                return null;
            }
            return this.myGetAssay(strSQL);
        }
        /// <summary>
        /// 获取某成品检验信息
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="state">生产计划状态</param>
        /// <returns>成功返回成品模版数组 失败返回null</returns>
        public ArrayList QueryAssay(string planNo, string state)
        {
            return this.QueryAssay(planNo, state, "AAAA");
        }
        #endregion


        /// <summary>
        /// 更新制剂主表状态
        /// </summary>
        /// <param name="planNo">生产计划编码</param>
        /// <param name="drugCode">成品编码</param>
        /// <param name="state">制剂状态</param>
        /// <param name="isClear">是否清场</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        public int UpdatePreparation(string planNo, string drugCode, Neusoft.HISFC.Models.Preparation.EnumState state, bool isClear)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.PPR.Preparation.UpdatePreparationState", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.PPR.Preparation.UpdatePreparationState";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
                                       planNo, 
                                       drugCode,
                                       ((int)state).ToString(),
                                       NConvert.ToInt32(isClear).ToString(),
                                       this.Operator.ID
                                   };
                strSQL = string.Format(strSQL, strParm);              //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新制剂主表的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据制剂成品获取制剂原料出库信息数组
        /// applyOut.Item.User01 存储标准处方量
        /// </summary>
        /// <param name="preparation">制剂成品信息</param>
        /// <returns>成功返回出库申请信息数组 失败返回null</returns>
        public ArrayList QueryMaterialApplyOut(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            ArrayList al = new ArrayList();

            #region 基本信息获取 配置处方与操作科室
            List<Neusoft.HISFC.Models.Preparation.Prescription> alPrescription = this.QueryDrugPrescription(preparation.Drug.ID);
            if (alPrescription == null)
                return null;
            if (alPrescription.Count == 0)
            {
                this.Err = preparation.Drug.Name + "：  该成品未进行配制处方维护";
                return null;
            }
            Neusoft.FrameWork.Models.NeuObject operDept;
            try
            {
                operDept = ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept;
                if (operDept == null)
                {
                    this.Err = "未正确获取操作员科室信息";
                    return null;
                }
            }
            catch
            {
                this.Err = "根据操作员获取操作科室出错";
                return null;
            }
            #endregion

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Item();
            //itemMgr.SetTrans(this.command.Transaction);	

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut;
            foreach (Prescription info in alPrescription)
            {
                #region ApplyOut实体赋值
                applyOut = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();
                try
                {
                    Neusoft.HISFC.Models.Pharmacy.Item itemobj = itemMgr.GetItem(info.Material.ID);
                    if (itemobj == null)
                    {
                        this.Err = "获取药品基本信息失败" + this.Err;
                        return null;
                    }
                    applyOut.Item = itemobj;
                    applyOut.ApplyDept = operDept;						//申请科室＝开方科室 
                    applyOut.StockDept = operDept;						//发药药房＝执行科室
                    applyOut.SystemType = "R1";							//申请类型＝"R1" 
                    applyOut.Operation.ApplyOper.OperTime = preparation.OperEnv.OperTime;            //申请时间＝操作时间
                    applyOut.Days = 1;								//草药付数
                    applyOut.IsPreOut = false;							//是否预扣库存
                    applyOut.IsCharge = true;							//是否收费

                    applyOut.PatientNO = info.Drug.ID;					//成品编码

                    applyOut.PatientDept = operDept;						//患者挂号科室 
                    applyOut.State = "2";								//出库申请状态:0申请,1摆药,2核准
                    applyOut.ShowState = "0";

                    applyOut.Item.User01 = info.NormativeQty.ToString();
                    applyOut.Operation.ApplyQty = preparation.PlanQty / 1000 * info.NormativeQty;

                    applyOut.BillNO = preparation.PlanNO;					//申请单号

                    applyOut.Operation.ApproveOper.Dept = applyOut.StockDept;

                    applyOut.Operation.ApproveQty = applyOut.Operation.ApplyQty;
                    applyOut.DrugNO = "3003";
                }
                catch (Exception ex)
                {
                    this.Err = "出库申请实体赋值时出错！" + ex.Message;
                    return null;
                }
                #endregion

                al.Add(applyOut);
            }
            return al;
        }

        /// <summary>
        /// 根据出库申请信息处理原料出库/出库申请
        /// </summary>
        /// <param name="applyOut">出库申请信息</param>
        /// <param name="isApply">是否需要发送出库申请</param>
        /// <returns>成功处理返回1 失败返回-1</returns>
        public int MaterialOutput(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, bool isApply)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Item();
            //itemMgr.SetTrans(this.command.Transaction);	

            if (isApply)
            {
                if (itemMgr.InsertApplyOut(applyOut) == -1)
                    return -1;
            }
            else
            {
                if (itemMgr.Output(applyOut) != 1)
                    return -1;
            }
            return 1;
        }

        /// <summary>
        /// 原料出库
        /// </summary>
        /// <param name="preparation">制剂主实体</param>
        /// <param name="isApply">是否需要发申请</param>
        /// <returns>成功处理返回1 失败返回-1</returns>
        public int MaterialOutput(Neusoft.HISFC.Models.Preparation.Preparation preparation, bool isApply)
        {
            ArrayList alMaterial = this.QueryMaterialApplyOut(preparation);
            if (alMaterial == null)
            {
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alMaterial)
            {
                if (this.MaterialOutput(info, isApply) == -1)
                    return -1;
            }
            return 1;
        }

        /// <summary>
        /// 成品入库
        /// </summary>
        /// <param name="pprList">制剂数组</param>
        /// <param name="pprDept">制剂生产科室</param>
        /// <param name="stockDept">库存科室</param>
        /// <param name="isApply">是否需要发入库申请</param>
        /// <returns></returns>
        public int DrugInput(List<Neusoft.HISFC.Models.Preparation.Preparation> pprList, Neusoft.FrameWork.Models.NeuObject pprDept,Neusoft.FrameWork.Models.NeuObject stockDept,bool isApply)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Item();
            
            if (itemMgr.ProduceInput(pprList, pprDept, stockDept, isApply) == -1)
            {
                return -1;
            }
            return 1;
        }

        #endregion

        #region 制剂定价公式
        /// <summary>
		/// 向制剂定价公式插入新记录
		/// </summary>
		/// <param name="preparation"></param>
		/// <returns>成功返回1 失败返回-1</returns>
		public int InsertCostPrice(Neusoft.HISFC.Models.Preparation.CostPrice costPrice)
	
		{
			string strSQL="";
			if(this.Sql.GetSql("Pharmacy.PPR.Preparation.InsertCostPrice",ref strSQL) == -1) return -1;
			try 
			{
                string [ ] strParm = this.myGetCostPriceParam ( costPrice ); //取参数列表
				strSQL = string.Format(strSQL, strParm);				//替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.InsertCostPrice" + ex.Message;
				return -1;
			}

            return this.ExecNoQuery ( strSQL );

            
		}
        /// <summary>
        /// 修改制剂定价公式记录
        /// </summary>
        /// <param name="preparation"></param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateCostPrice ( Neusoft.HISFC.Models.Preparation.CostPrice costPrice )
        {
            string strSQL = "";
            if ( this.Sql.GetSql ( "Pharmacy.PPR.Preparation.UpdateCostPrice" , ref strSQL ) == -1 )
                return -1;
            try
            {
                string [ ] strParm = this.myGetCostPriceParam ( costPrice ); //取参数列表
                strSQL = string.Format ( strSQL , strParm );			//替换SQL语句中的参数。
            }
            catch ( Exception ex )
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.UpdateCostPrice" + ex.Message;
                return -1;
            }

            return this.ExecNoQuery ( strSQL );


        }
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="drugCode"></param>
        public Boolean IsHaveCostPriceFormula(string drugCode)
        {
            string strSQL = "";
            if ( this.Sql.GetSql ( "Pharmacy.PPR.Preparation.IsHaveCostPriceFormula" , ref strSQL ) == -1 )
                return false;
            try
            {

                strSQL = string.Format ( strSQL , drugCode );			//替换SQL语句中的参数。
            }
            catch ( Exception ex )
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.IsHaveCostPriceFormula" + ex.Message;
                return false;
            }

            this.ExecQuery ( strSQL );
            try
            {
                while ( this.Reader.Read ( ) )
                {
                    string count = this.Reader [ 0 ].ToString();
                    if ( count=="0" )
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch ( Exception e )
            {
                this.Err = e.Message;
                return false;
            }
            finally
            {
                this.Reader.Close ( );
            }
            return true;
        }

        /// <summary>
        /// 根据制剂定价信息获取参数数组
        /// </summary>
        /// <param name="preparation"></param>
        /// <returns>成功返回对应的参数数组</returns>
        private string [ ] myGetCostPriceParam ( Neusoft.HISFC.Models.Preparation.CostPrice costPrice )
        {

            string [ ] strParam = {
                                    costPrice.ID,
                                    costPrice.Name,
                                    costPrice.Specs,
                                    costPrice.PactUnit,
                                    costPrice.PactQty.ToString(),
                                    costPrice.MinUnit,
                                    costPrice.CostPriceFormula,
                                    costPrice.SalePriceFormula,
                                    costPrice.PriceSource,
                                    ((int)costPrice.PriceRate).ToString(),
                                    costPrice.Memo,
                                    costPrice.Extend,
                                    costPrice.Oper.Name,
                                    costPrice.Oper.OperTime.ToString()
                                   
                                   
									
								};
            return strParam;
        }
        /// <summary>
        /// 根据药品编码获取成本计算公式
        /// </summary>
        /// <param name="drugCode"></param>
        /// <returns></returns>
        public string GetCostPriceFormula ( string drugCode )
        {
            string strSQL = "";
            string costPriceFormula = string.Empty;
            if ( this.Sql.GetSql ( "Pharmacy.PPR.Preparation.GetCostPriceFormula" , ref strSQL ) == -1 )
                return "";
                
            try
            {

                strSQL = string.Format ( strSQL , drugCode );
            }
            catch ( Exception ex )
            {
                this.Err = "格式化记录的SQl参数赋值时出错！Pharmacy.PPR.Preparation.GetCostPriceFormula" + ex.Message;
                
            }
            this.ExecQuery ( strSQL );
            try
            {

                while ( this.Reader.Read ( ) )
                {
                    costPriceFormula = this.Reader [ 0 ].ToString ( );
                }

            }
            catch ( Exception e )
            {
                this.Err = e.Message;

            }
            finally
            {
                this.Reader.Close ( );
            }
            return costPriceFormula;
        }
        #endregion
    }
}
