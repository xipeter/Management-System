using System;
using System.Collections;
using System.Data;
namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// Derate 的摘要说明。
	/// </summary>
	public class Derate :Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public Derate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			
		}
		/// <summary>
        /// 得到减免的费用及金额 按最小费用分类{BD300517-D927-43c0-A1D3-8FB99BD10298}
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
        //public ArrayList GetFeeCodeAndDerateCost(string clinicNo)
        //{
        //    //SELECT FEE_CODE ,SUM(DERATE_COST) FROM FIN_COM_DERATE  WHERE CLINIC_NO ='{0}' AND  PARENT_CODE = '[父级编码]'  AND CURRENT_CODE ='[本级编码]' GROUP BY  FEE_CODE
        //    ArrayList List = null;
        //    string  strSql="";
        //    if (this.Sql.GetSql("Management.Fee.GetFeeCodeAndDerateCost1",ref strSql)==-1) return null;
        //    try
        //    {
        //        strSql = string.Format(strSql,clinicNo);
        //        this.ExecQuery(strSql);
        //        Neusoft.HISFC.Models.Fee.Rate info = null;
        //        List = new ArrayList();
        //        while(this.Reader.Read())
        //        {
        //            info = new Neusoft.HISFC.Models.Fee.Rate();
        //            if(Reader[0]!=null)
        //            {
        //                info.FeeCode =Reader[0].ToString(); //住院流水号
        //            }
        //            try
        //            {
        //                info.derate_Cost = Convert.ToDecimal(Reader[1]);
        //            }
        //            catch(Exception ee)
        //            {
        //                string Error = ee.Message;
        //                info.derate_Cost = Convert.ToDecimal(0);
        //            }
        //            List.Add(info);
        //            info = null;
        //        }
        //        this.Reader.Close();
        //    }
        //    catch(Exception ee)
        //    {
        //        string Error = ee.Message;
        //    }
        //    return List;
        //}
        /// <summary>
        /// 得到减免的费用及金额 按最小费用分类{BD300517-D927-43c0-A1D3-8FB99BD10298}
        /// </summary>
        /// <param name="clinicNo"></param>
        /// <returns></returns>
        public ArrayList GetFeeCodeAndDerateCost(string clinicNo, string balanceNO)
        {
            //SELECT FEE_CODE ,SUM(DERATE_COST) FROM FIN_COM_DERATE  WHERE CLINIC_NO ='{0}' AND  PARENT_CODE = '[父级编码]'  AND CURRENT_CODE ='[本级编码]' GROUP BY  FEE_CODE
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Management.Fee.GetFeeCodeAndDerateCost1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, clinicNo, balanceNO);
                this.ExecQuery(strSql);
                //{8D6068F9-058A-4a25-976A-FB4C68834FA9}
                //Neusoft.HISFC.Models.Fee.Rate info = null;
                Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo info;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    //{8D6068F9-058A-4a25-976A-FB4C68834FA9}
                    //info = new Neusoft.HISFC.Models.Fee.Rate();
                    info = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
                    if (Reader[0] != null)
                    {
                        //{8D6068F9-058A-4a25-976A-FB4C68834FA9}
                        //info.FeeCode =Reader[0].ToString(); //住院流水号
                        info.Item.MinFee.ID = Reader[0].ToString(); //
                    }
                    try
                    {
                        //{8D6068F9-058A-4a25-976A-FB4C68834FA9}
                        //info.derate_Cost = Convert.ToDecimal(Reader[1]);
                        info.FT.OwnCost = Convert.ToDecimal(Reader[1]);
                        info.FT.TotCost = Convert.ToDecimal(Reader[1]);
                    }
                    catch (Exception ee)
                    {
                        string Error = ee.Message;
                        //{8D6068F9-058A-4a25-976A-FB4C68834FA9}
                        //info.derate_Cost = Convert.ToDecimal(0);
                        info.FT.TotCost = Convert.ToDecimal(0);
                        info.FT.OwnCost = Convert.ToDecimal(0);
                    }
                    List.Add(info);
                    info = null;
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
            }
            return List;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="clinicNo">医疗流水号</param>
		/// <returns></returns>
		public ArrayList GetDerate(string clinicNo)
		{
			ArrayList List = null;
			string  strSql="";
			if (this.Sql.GetSql("Management.Fee.GetDerate",ref strSql)==-1) return null;
			try
			{
				//SELECT CLINIC_NO ,HAPPEN_NO,DERATE_KIND,RECIPE_NO,SEQUENCE_NO,DERATE_TYPE,FEE_CODE,DERATE_COST,DERATE_CAUSE,CONFIRM_OPERCODE,CONFIRM_NAME,DEPT_CODE ,BALANCE_NO ,BALANCE_STATE ,OPER_CODE ,OPER_DATE  FROM FIN_COM_DERATE WHERE CLINIC_NO  = '{0}' and PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]'
				strSql = string.Format(strSql,clinicNo);
				this.ExecQuery(strSql);
				Neusoft.HISFC.Models.Fee.Rate info = null;
				List = new ArrayList();
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Fee.Rate();
					if(Reader[0]!=DBNull.Value )
					{
						info.clinicNo =Reader[0].ToString(); //住院流水号
					}
					if(Reader[1]!=DBNull.Value )
					{
						try
						{
							info.happenNo =Convert.ToInt32(Reader[1]); //发生序号
						}
						catch(Exception ee)
						{
							this.Err = ee.Message;
						}
					}
					if(Reader[2]!=DBNull.Value )
					{
						info.derateKind =Reader[2].ToString(); //减免种类
					}
					if(Reader[3]!=DBNull.Value )
					{
						info.recipeNo =Reader[3].ToString();//处方号
					}			
					if(Reader[4]!=DBNull.Value )
					{
						info.sequenceNo =Convert.ToInt32(Reader[4]); //处方内项目流水号
					}
					else
					{
						info.sequenceNo =0;
					}
					if(Reader[5]!=DBNull.Value )
					{
						info.derateType =Reader[5].ToString(); //减免类型
					}
					if(Reader[6]!=DBNull.Value )
					{
						info.FeeCode =Reader[6].ToString();  //最小费用
					}
					if(Reader[7]!=DBNull.Value )
					{
						try
						{
							info.derate_Cost =Convert.ToDecimal(Reader[7]); //减免金额
						}
						catch(Exception ee)
						{
							string Error =ee.Message;
						}
					}
					if(Reader[8]!=DBNull.Value )
					{
						info.derate_cause =Reader[8].ToString(); //减免原因
					}
					if(Reader[9]!=DBNull.Value )
					{
						info.confirmOpercode =Reader[9].ToString(); //批准人
					}
					if(Reader[10]!=DBNull.Value )
					{
						info.confirmName =Reader[10].ToString(); // 批准人编码
					}
					if(Reader[11]!=DBNull.Value )
					{
						info.deptCode =Reader[11].ToString(); //  科室
					}
					if(Reader[12]!=DBNull.Value )
					{
						info.balanceState =Reader[12].ToString(); // 结算状态
					}
					if(Reader[13]!=DBNull.Value )
					{
						info.opercode =Reader[13].ToString(); // 结算状态
					}
					if(Reader[14]!=DBNull.Value )
					{
						info.operdate =Convert.ToDateTime(Reader[14]);
					}
					List.Add(info);
					info = null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
			}
			return List;
		}
		/// <summary>
		/// 更新 费用减免表 fin_com_derate 一条记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public  int UpdateDerate(Neusoft.HISFC.Models.Fee.Rate info)
		{
			string strSql = "";
			//UPDATE FIN_COM_DERATE  SET DERATE_KIND  = '{2}' ,RECIPE_NO ='{3}' ,SEQUENCE_NO='{4}',DERATE_TYPE ='{5}',FEE_CODE  ='{6}',DERATE_COST ='{7}',CONFIRM_OPERCODE ='{8}', CONFIRM_NAME='{9}',DEPT_CODE ='{10}' ,OPER_CODE ='{11}',OPER_DATE = sysdate WHERE  CLINIC_NO= '{0}' AND  HAPPEN_NO ='{1}'AND  PARENT_CODE = '[父级编码]' AND  CURRENT_CODE ='[本级编码]' 
			if(this.Sql.GetSql("Management.Fee.UpdateDerate",ref strSql)==-1 ) return -1;
			try
			{
				string  OperCode = this.Operator.ID;
				strSql = string.Format(strSql,info.clinicNo,info.happenNo,info.derateKind,info.recipeNo,info.sequenceNo,info.derateType,info.FeeCode,info.derate_Cost,info.confirmOpercode,info.confirmName,info.deptCode,OperCode);
			}
			catch(Exception ee)
			{
				this.Err =ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除 费用减免表 fin_com_derate一条记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int DeleteDerate(Neusoft.HISFC.Models.Fee.Rate info)
		{
			string strSql = "";
			// DELETE FIN_COM_DERATE  WHERE  CLINIC_NO ='{0}',HAPPEN_NO ='{1}'  and PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]'
			if(this.Sql.GetSql("Management.Fee.DeleteDerate",ref strSql)==-1 ) return -1;
			try
			{
				strSql = string.Format(strSql,info.clinicNo,info.happenNo);
			}
			catch(Exception ee)
			{
				this.Err =ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 插入 费用减免表 fin_com_derate 一条新的记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertDerate(Neusoft.HISFC.Models.Fee.Rate info)
		{
			string strSql = "";
			//INSERT  INTO  FIN_COM_DERATE  ( PARENT_CODE ,CURRENT_CODE,CLINIC_NO ,HAPPEN_NO ,DERATE_KIND ,RECIPE_NO ,SEQUENCE_NO ,DERATE_TYPE ,FEE_CODE, DERATE_COST,DERATE_CAUSE,CONFIRM_OPERCODE,CONFIRM_NAME,DEPT_CODE,OPER_CODE ,OPER_DATE  ) VALUES ('[父级编码]','[本级编码]','{0}',(select max(happen_no)+1 from fin_com_derate where parent_code ='[父级编码]' and current_code ='[本级编码]'),'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',sysdate)
			if(this.Sql.GetSql("Management.Fee.InsertDerate",ref strSql)==-1 ) return -1;
			try
			{
				string  OperCode = this.Operator.ID;
				int sequenceNo =0;
				try
				{
					sequenceNo =Convert.ToInt32(info.sequenceNo);
				}
				catch(Exception )
				{
					sequenceNo = 0;
				}
				info.happenNo =  GetHappenNO(info.clinicNo);
				strSql  =  string.Format(strSql,info.clinicNo,info.happenNo,info.derateKind,info.recipeNo,sequenceNo,info.derateType,info.FeeCode,info.derate_Cost,info.derate_cause,info.confirmOpercode,info.confirmName,info.deptCode,info.balanceState,OperCode);
			}
			catch(Exception ee)
			{
				this.Err =ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 根据住院流水号和结算序号查讯 费用减免记录
		/// </summary>
		/// <param name="Clinic"></param>
		/// <param name="BalanceNo"></param>
		/// <returns></returns>
		public ArrayList GetDerateByClinicAndBalance(string Clinic,int  BalanceNo)
		{
			ArrayList List = null;
			string  strSql="";
			//SELECT CLINIC_NO ,HAPPEN_NO,DERATE_KIND,RECIPE_NO,SEQUENCE_NO,DERATE_TYPE,FEE_CODE,DERATE_COST,DERATE_CAUSE,CONFIRM_OPERCODE,CONFIRM_NAME,DEPT_CODE ,BALANCE_NO ,BALANCE_STATE  FROM FIN_COM_DERATE WHERE CLINIC_NO  = '{0}'  and  BALANCE_NO = '{1}' and PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]' 
			if (this.Sql.GetSql("Management.Fee.GetDerateByClinicAndBalance",ref strSql)==-1) return null;
			try
			{
				strSql = string.Format(strSql,Clinic,BalanceNo);
				this.ExecQuery(strSql);
				Neusoft.HISFC.Models.Fee.Rate info = null;
				List = new ArrayList();
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Fee.Rate();
					if(Reader[0]!=DBNull.Value )
					{
						info.clinicNo =Reader[0].ToString(); //住院流水号
					}
					if(Reader[1]!=DBNull.Value )
					{
						try
						{
							info.happenNo =Convert.ToInt32(Reader[1]); //发生序号
						}
						catch(Exception ee)
						{
							this.Err = ee.Message;
						}
					}
					if(Reader[2]!=DBNull.Value )
					{
						info.derateKind =Reader[2].ToString(); //减免种类
					}
					if(Reader[3]!=DBNull.Value )
					{
						info.recipeNo =Reader[3].ToString();//处方号
					}			
					if(Reader[4]!=DBNull.Value )
					{
						info.sequenceNo =Convert.ToInt32(Reader[4]); //处方内项目流水号
					}
					else
					{
						info.sequenceNo =0;
					}
					if(Reader[5]!=DBNull.Value )
					{
						info.derateType =Reader[5].ToString(); //减免类型
					}
					if(Reader[6]!=DBNull.Value )
					{
						info.FeeCode =Reader[6].ToString();  //最小费用
					}
					if(Reader[7]!=DBNull.Value )
					{
						try
						{
							info.derate_Cost =Convert.ToDecimal(Reader[7]); //减免金额
						}
						catch(Exception ee)
						{
							string Error =ee.Message;
						}
					}
					//DERATE_COST,DERATE_CAUSE,CONFIRM_OPERCODE,CONFIRM_NAME,DEPT_CODE ,BALANCE_NO ,BALANCE_STATE,OPER_CODE,OPER_DATE 
					if(Reader[8]!=DBNull.Value )
					{
						info.derate_cause =Reader[8].ToString(); //减免原因
					}
					if(Reader[9]!=DBNull.Value )
					{
						info.confirmOpercode =Reader[9].ToString(); //批准人
					}
					if(Reader[10]!=DBNull.Value )
					{
						info.confirmName =Reader[10].ToString(); // 批准人编码
					}
					if(Reader[11]!=DBNull.Value )
					{
						info.deptCode =Reader[11].ToString(); //  科室
					}
					if(Reader[12]!=DBNull.Value )
					{
						info.balanceState =Reader[12].ToString(); // 结算状态
					}
					if(Reader[13]!=DBNull.Value )
					{
						info.opercode =Reader[13].ToString(); // 操作员
					}
					if(Reader[14]!=DBNull.Value )
					{
						info.operdate =Convert.ToDateTime(Reader[14]);// 操作时间
					}

					List.Add(info);
					info = null;
				}
				this.Reader.Close(); //关闭reader
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				List =null;
			}
			return List;
		}
		/// <summary>
		/// 得到该住院流水号用到过的项目列表
		/// </summary>
		/// <param name="ClinicNo"></param>
		/// <returns></returns>
		public ArrayList GetItemList(string ClinicNo)
		{
			ArrayList List = null;
			try
			{
				//select recipe_no,sequence_no ,drug_name , own_cost from fin_ipb_medicinelist where inpatient_no ='{0}' and parent_code ='[父级编码]' and current_code ='[本级编码]' union select recipe_no , sequence_no , item_name, own_cost  from fin_ipb_itemlist  where inpatient_no ='{0}' and parent_code ='[父级编码]' and current_code ='[本级编码]'

				string strSql = "";
				if (this.Sql.GetSql("Management.Fee.zjyGetItemList",ref strSql)==-1) return null;
				List = new ArrayList();
				Neusoft.HISFC.Models.Fee.Item.Undrug ItemInfo = null;
				strSql = string.Format(strSql ,ClinicNo);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					//
					ItemInfo = new Neusoft.HISFC.Models.Fee.Item.Undrug();
					if(Reader[0]!=null)
					{
						//处方号
						ItemInfo.ID  = Reader[0].ToString();
					}
					if(Reader[1]!=null)
					{
						//处方内流水号
						ItemInfo.GBCode =Convert.ToString( Reader[1]);
					}
					if(Reader[2]!=null)
					{
						//药品/非药品名称
						ItemInfo.Name = Reader[2].ToString();
					}
					if(Reader[3]!=null)
					{
						//自付金额
						ItemInfo.Price = Convert.ToDecimal(Reader[3]);
					}
					else
					{
						ItemInfo.Price=0;
					}
					List.Add(ItemInfo);
					ItemInfo= null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
			}
			return List;
		}
		/// <summary>
		/// 根据住院号和项目名称得到处方号和处方项目流水号
		/// </summary>
		/// <param name="ClinicNo"></param>
		/// <param name="ItemName"></param>
		/// <returns></returns>
		public ArrayList GetItemListByClinicAndFeeName(string ClinicNo,string ItemName)
		{
			ArrayList List = null;
			try
			{
				//select recipe_no,sequence_no ,drug_name , own_cost from fin_ipb_medicinelist where inpatient_no ='{0}' and parent_code ='[父级编码]' and current_code ='[本级编码]' union select recipe_no , sequence_no , item_name, own_cost  from fin_ipb_itemlist  where inpatient_no ='{0}' and parent_code ='[父级编码]' and current_code ='[本级编码]'

				string strSql = "";
				if (this.Sql.GetSql("Management.Fee.GetItemListByClinicAndFeeName",ref strSql)==-1) return null;
				List = new ArrayList();
				Neusoft.HISFC.Models.Fee.Item.Undrug ItemInfo = null;
				strSql = string.Format(strSql ,ClinicNo,ItemName);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					//
					ItemInfo = new Neusoft.HISFC.Models.Fee.Item.Undrug();
					if(Reader[0]!=null)
					{
						//处方号
						ItemInfo.ID  = Reader[0].ToString();
					}
					if(Reader[1]!=null)
					{
						//处方内流水号
						ItemInfo.GBCode =Convert.ToString( Reader[1]);
					}
					if(Reader[2]!=null)
					{
						//药品/非药品名称
						ItemInfo.Name = Reader[2].ToString();
					}
					if(Reader[3]!=null)
					{
						//自付金额
						ItemInfo.Price = Convert.ToDecimal(Reader[3]);
					}
					else
					{
						ItemInfo.Price=0;
					}
					List.Add(ItemInfo);
					ItemInfo= null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
			}
			return List;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="clinic"></param>
		/// <returns></returns>
		public int IsBalance(string clinic )
		{
			//判断是否已经结算完毕了
			int Result =0;
			try
			{
				string  strSql="";
				if (this.Sql.GetSql("Management.Fee.IsBalance",ref strSql)==-1) return -1;
				// SELECT DISTINCT  INPATIENT_NO FROM  fin_ipr_inmaininfo where INPATIENT_NO ='{0}' and IN_STATE IN( 'R', 'I', 'B', 'P')  and PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]'
				strSql = string.Format(strSql,clinic);
				Result =this.ExecQuery(strSql);
				
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				Result =-1;
			}
			return Result ;
		}
		/// <summary>
		/// 根据住院号 得到最近一次的住院流水号
		/// </summary>
		/// <param name="patientno"></param>
		/// <returns></returns>
		public Neusoft.FrameWork.Models.NeuObject  GetLastClinicNO(string patientno )
		{
			Neusoft.FrameWork.Models.NeuObject obj =null;
			string strSql ="";
			//select inpatient_no ,dept_code  from fin_ipr_inmaininfo where inpatient_no =(select Max(inpatient_no) from fin_ipr_inmaininfo where inpatient_no = '{0}' and PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]') and PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]'
			if (this.Sql.GetSql("Management.Fee.GetLastClinicNO",ref strSql)==-1) return null;
			strSql = string.Format(strSql,patientno);
			this.ExecQuery(strSql);
			while(this.Reader.Read())
			{
				obj = new Neusoft.FrameWork.Models.NeuObject();
				try
				{
					if(Reader[0]!=DBNull.Value)
					{
						obj.ID =  Reader[0].ToString();     //住院流水号                 
					}
					if(Reader[1]!=DBNull.Value)
					{
						obj.Name = Reader[1].ToString(); //科室代码
					}
				}
				catch(Exception ee)
				{
					this.Err = ee.Message;
				}
			}
			this.Reader.Close();
			return obj;
		}

		/// <summary>
		/// 根据减免总额 分派最小项目的减免金额
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <param name="DerateCost">减免总额</param>
		/// <param name="DerateTotal">分摊的总费用</param>
		/// <returns></returns>
		public ArrayList GetFeeCodeAndDerateCost(string clinicNo,decimal DerateCost,decimal DerateTotal)
		{
			//select fee_code,sum(own_cost) from fin_ipb_feeinfo where parent_code ='[父级编码]' and current_code ='[本级编码]' and inpatient_no ='{0}' and balance_state ='0' group by fee_code
			ArrayList costList = null;
			string  strSql="";
			if (this.Sql.GetSql("Management.Fee.GetFeeCodeAndDerateCost2",ref strSql)==-1) return null;
			try
			{
				ArrayList List = null;
				strSql = string.Format(strSql,clinicNo);
				this.ExecQuery(strSql);
				Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo info = null;
				List = new ArrayList();
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
					info.Item.MinFee.ID = Reader[0].ToString();
					info.FT.OwnCost = Convert.ToDecimal(Reader[1]);
					List.Add(info);
					info= null;
				}
				this.Reader.Close();
				costList = CalculateDerateCost(DerateCost,List,DerateTotal);
			}
			catch(Exception ee)
			{
				//出错，返回null
				this.Err = ee.Message;
				costList =null;
			}
			return costList;
		}
/// <summary>
/// 确切的计算最小项目的减免金额
/// </summary>
/// <param name="DerateCost"></param>
/// <param name="List"></param>
/// <param name="DerateTotal"></param>
/// <returns></returns>
		private ArrayList  CalculateDerateCost(decimal DerateCost,ArrayList List ,decimal DerateTotal)
		{
			ArrayList costList =null;
			try
			{
				decimal costSum =0;
				if(List!=null&&DerateCost>=0)
				{
					costList = new ArrayList();
					if(List.Count==0)
					{
						return List;
					}
					Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo  FeeRate = null;
					if(List.Count >1)
					{
						for(int i=0;i<List.Count-1;i++)
						{
							FeeRate = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo(); 
							FeeRate.Item.MinFee.ID =((Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)List[i]).Item.MinFee.ID;
							decimal temp = ((Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)List[i]).FT.OwnCost;
							FeeRate.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber((temp /DerateTotal) * DerateCost,2);
							FeeRate.FT.OwnCost = FeeRate.FT.TotCost;
							costSum = costSum + FeeRate.FT.TotCost;
							costList.Add(FeeRate);
							FeeRate = null;
						}
						FeeRate = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
						FeeRate.Item.MinFee.ID =((Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)List[List.Count-1]).Item.MinFee.ID;
						FeeRate.FT.TotCost = DerateCost -costSum  ;
						FeeRate.FT.OwnCost = FeeRate.FT.TotCost;
						costList.Add(FeeRate);
						FeeRate = null;
					}
					else
					{
						FeeRate = new Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo();
                        //FeeRate.Item.ID = ((Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)List[List.Count - 1]).Item.MinFee.ID;
                        //luzhp 2008-3-31减免金额
                        //{372537A2-51BD-4113-A1CE-991C98391ECD}
						FeeRate.Item.MinFee.ID =((Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)List[0]).Item.MinFee.ID;
						FeeRate.FT.TotCost = DerateCost ;
						FeeRate.FT.OwnCost = FeeRate.FT.TotCost;
						costList.Add(FeeRate);
					}
				}
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				costList = null;
			}
			return costList ;
		}
		/// <summary>
		/// 得到自费的总额
		/// </summary>
		/// <param name="ClinicNo"></param>
		/// <returns></returns>
		public decimal SelectFeeDerate(string ClinicNo)
		{
			//select sum(own_cost) from fin_ipb_feeinfo where parent_code ='[父级编码]' and current_code ='[本级编码]' and inpatient_no ='{0}' and balance_state ='0' group by fee_code
			decimal Result =0;
			string  strSql="";
			if (this.Sql.GetSql("Management.Fee.SelectFeeDerate",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,ClinicNo);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					Result = Convert.ToDecimal(Reader[0]);
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return Result ;
		}

		/// <summary>
		/// 获取发生序号
		/// </summary>
		/// <param name="ClinicNo"></param>
		/// <returns></returns>
		public int GetHappenNO(string ClinicNo)
		{
			int HappenNo =0;
			string  strSql="";
			if (this.Sql.GetSql("Management.Fee.GetHappenNO",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,ClinicNo);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					HappenNo = Convert.ToInt32(Reader[0]);
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return HappenNo ;
        }

        #region 减免新增{BD300517-D927-43c0-A1D3-8FB99BD10298}

        /// <summary>
        /// 根据住院流水号取已经减免的明细
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public ArrayList GetDeratedDetail(string inpatientNO)
        {
            return this.QueryDerateInfoByIndex("Fee.Inpatient.Derate.QueryDeratedInfo.ClinicNO", inpatientNO);
        }

        /// <summary>
        /// 基本查询
        /// </summary>
        /// <returns></returns>
        private string PatientQuerySelect()
        {
            string sql = string.Empty;
            if (Sql.GetSql("Fee.Inpatient.Derate.selectBase", ref sql) == -1)
            {
                return null;
            }
            return sql;
        }

        /// <summary>
        /// 根据where条件查询信息
        /// </summary>
        /// <param name="sqlIndex"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private ArrayList QueryDerateInfoByIndex(string sqlIndex, params string[] args)
        {
            string selectSql = this.PatientQuerySelect();

            string whereSql = "";

            int returnValue = this.Sql.GetSql(sqlIndex, ref whereSql);

            if (returnValue < 0)
            {
                this.Err = "查询" + sqlIndex + "对应的sql语句失败";
                return null;
            }

            this.ExecQuery(selectSql + " " + whereSql, args);

            Neusoft.HISFC.Models.Fee.DerateFee info = null;

            ArrayList al = new ArrayList();

            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.Fee.DerateFee();
                if (!this.Reader.IsDBNull(0))
                {
                    info.InpatientNO = Reader[0].ToString(); //住院流水号
                }

                if (!this.Reader.IsDBNull(1))
                {
                    info.HappenNO = Convert.ToInt32(Reader[1].ToString()); //发生序号 
                }

                if (!this.Reader.IsDBNull(2))
                {
                    info.DerateKind.ID = Reader[2].ToString(); //减免种类
                }

                if (!this.Reader.IsDBNull(3))
                {
                    info.RecipeNO = Reader[3].ToString();//处方号
                }

                if (!this.Reader.IsDBNull(4))
                {
                    info.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32((Reader[4].ToString())); //处方内项目流水号
                }

                if (!this.Reader.IsDBNull(5))
                {
                    info.DerateType.ID = Reader[5].ToString(); //减免类型
                }

                if (!this.Reader.IsDBNull(6))
                {
                    info.FeeCode = Reader[6].ToString();  //最小费用
                }

                if (!this.Reader.IsDBNull(7))
                {
                    info.DerateCost = Convert.ToDecimal(Reader[7]); //减免金额
                }

                if (!this.Reader.IsDBNull(8))
                {
                    info.DerateCause = Reader[8].ToString(); //减免原因
                }

                if (!this.Reader.IsDBNull(9))
                {
                    info.ConfirmOperator.ID = Reader[9].ToString(); //批准人编码
                }

                if (!this.Reader.IsDBNull(10))
                {
                    info.ConfirmOperator.Name = Reader[10].ToString(); // 批准人
                }

                if (!this.Reader.IsDBNull(11))
                {
                    info.DerateOper.Dept.ID = Reader[11].ToString(); //  科室
                }

                if (!this.Reader.IsDBNull(12))
                {
                    info.BalanceNO = Convert.ToInt32(Reader[12].ToString()); // 结算序号
                }

                if (!this.Reader.IsDBNull(13))//结算状态 0:未结算；1:已结算
                {
                    info.BalanceState = this.Reader[13].ToString(); //结算状态 0:未结算；1:已结算
                }

                if (!this.Reader.IsDBNull(14))//发票号
                {
                    info.InvoiceNO = Reader[14].ToString();
                }

                if (!this.Reader.IsDBNull(15))//作废人代码
                {
                    info.CancelDerateOper.ID = Reader[15].ToString();
                }

                if (!this.Reader.IsDBNull(16))//作废时间
                {
                    info.CancelDerateOper.OperTime = Convert.ToDateTime(Reader[16].ToString());
                }

                if (!this.Reader.IsDBNull(17))//操作员
                {
                    info.DerateOper.ID = Reader[17].ToString();
                }

                if (!this.Reader.IsDBNull(18))//操作日期
                {
                    info.DerateOper.OperTime = Convert.ToDateTime(Reader[18]);
                }

                if (!this.Reader.IsDBNull(19))//项目代码
                {
                    info.ItemCode = this.Reader[19].ToString();
                }

                if (!this.Reader.IsDBNull(20))//项目名称
                {
                    info.ItemName = this.Reader[20].ToString();
                }

                if (!this.Reader.IsDBNull(21))//最小费用
                {
                    info.FeeName = this.Reader[21].ToString();
                }
                if (!this.Reader.IsDBNull(22))
                {
                    info.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[22]);
                }
                if (!this.Reader.IsDBNull(23))
                {
                    info.DerateKind.Name = this.Reader[23].ToString();
                }
                if (!this.Reader.IsDBNull(24))
                {
                    info.DerateType.Name = this.Reader[24].ToString();
                }
                if (!this.Reader.IsDBNull(25))
                {
                    info.DerateOper.Dept.Name = this.Reader[25].ToString();
                }
                al.Add(info);
            }
            this.Reader.Close();
            return al;

        }

        /// <summary>
        /// 减免实体赋值
        /// </summary>
        /// <param name="derateFeeObj"></param>
        /// <returns></returns>
        private string[] getArgs(Neusoft.HISFC.Models.Fee.DerateFee derateFeeObj)
        {
            string[] strArgs = new string[] {
                   derateFeeObj.InpatientNO,//0}', --医疗流水号
                   derateFeeObj.HappenNO.ToString(),//{1}', --发生序号
                   derateFeeObj.DerateKind.ID,//{2}', --减免种类 0 总额 1 最小费用 2 项目减免 3 减免管理使用（按最小费用）
                   derateFeeObj.RecipeNO,//{3}', --处方号
                   derateFeeObj.SequenceNO.ToString(),//{4}', --处方内项目流水号
                   derateFeeObj.DerateType.ID,//{5}', --减免类型
                   derateFeeObj.FeeCode,//{6}', --最小费用
                   derateFeeObj.DerateCost.ToString(),//{7}', --减免金额
                   derateFeeObj.DerateCause,//{8}', --减免原因
                   derateFeeObj.ConfirmOperator.ID,//{9}', --批准人员工代码
                   derateFeeObj.ConfirmOperator.Name,//{10}', --批准人姓名
                   derateFeeObj.DerateOper.Dept.ID,//{11}', --科室代码
                   derateFeeObj.BalanceNO.ToString(),//{12}', --结算序号
                   derateFeeObj.BalanceState,//{13}', --结算状态 0:未结算；1:已结算
                   derateFeeObj.InvoiceNO,//{14}', --发票号
                   derateFeeObj.CancelDerateOper.ID,//{15}', --作废人代码
                   derateFeeObj.CancelDerateOper.OperTime.ToString(),//{16}', --作废时间
                   derateFeeObj.DerateOper.ID,//{17}', --操作员
                   derateFeeObj.DerateOper.OperTime.ToString(),//{18}', --操作日期
                   derateFeeObj.ItemCode,//{19}', --项目代码
                   derateFeeObj.ItemName,//{20}', --项目名称
                   derateFeeObj.FeeName,//'{21}', --最小费用
                   (Neusoft.FrameWork.Function.NConvert.ToInt32(derateFeeObj.IsValid)).ToString()

            };
            return strArgs;

        }

        /// <summary>
        /// 更新或插入数据
        /// </summary>
        /// <param name="sqlIndex"></param>
        /// <param name="derateList"></param>
        /// <returns></returns>
        private int InsertOrUpdateSingleTable(string sqlIndex, Neusoft.HISFC.Models.Fee.DerateFee derateObj)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return -1;
            }
            string[] args = this.getArgs(derateObj);
            return this.ExecNoQuery(sql, args);

        }

        /// <summary>
        /// 插入减免信息
        /// </summary>
        /// <param name="derateList">减免实体</param>
        /// <returns></returns>
        public int InsertDerateFeeInfo(Neusoft.HISFC.Models.Fee.DerateFee derateObj)
        {
            return this.InsertOrUpdateSingleTable("Fee.Inpatient.Derate.NewInsert", derateObj);

        }

        /// <summary>
        /// 更新减免信息
        /// </summary>
        /// <param name="derateList">减免实体</param>
        /// <returns></returns>
        public int UpdateDerateFeeInfo(Neusoft.HISFC.Models.Fee.DerateFee derateObj)
        {
            return this.InsertOrUpdateSingleTable("Fee.Inpatient.Derate.NewUpdate", derateObj);
        }

        /// <summary>
        /// 根据据住院号,发票号,查询减免信息
        /// </summary>
        /// <param name="clinicNO">住院号</param>
        /// <param name="invoiceNO">发票号</param>
        /// <returns></returns>
        public ArrayList QueryDerateDetailByClinicNOAndInvoiceNO(string clinicNO, string invoiceNO)
        {
            return this.QueryDerateInfoByIndex("Fee.Inpatient.Derate.Where_1", clinicNO, invoiceNO);
        }

        /// <summary>
        /// 根据流水号取减免总金额
        /// </summary>
        /// <param name="clinicNO"></param>
        /// <returns></returns>
        public string GetTotDerateFeeByClinicNO(string clinicNO)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("Fee.Inpatient.Derate.Query1", ref strSql);

            if (returnValue < 0)
            {
                this.Err = "没有找到Fee.Inpatient.Derate.Query1对应的sql语句";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, clinicNO);
            }
            catch (Exception ex)
            {

                this.Err = ex.Message;
                return null;
            }

            this.ExecQuery(strSql);

            Neusoft.FrameWork.Models.NeuObject obj = null;

            while (this.Reader.Read())
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
            }
            this.Reader.Close();
            return obj.ID;
        }
        /// <summary>
        /// 查询患者的最小费用和已减免的最小费用
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns></returns>
        public System.Data.DataSet GetMinFeeAndDerateByInpatientNO(string inpatientNO)
        {
            DataSet ds = new DataSet();
            this.ExecQuery("Fee.Inpatient.Derate.QueryMinFee", ref ds, inpatientNO);
            return ds;
        }

        /// <summary>
        /// 查询患者的费用明细
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns></returns>
        public System.Data.DataSet GetFeeDetailByInpatientNO(string inpatientNO)
        {
            DataSet ds = new DataSet();
            this.ExecQuery("Fee.Inpatient.Derate.QueryFeeDetail", ref ds, inpatientNO);
            return ds;
        }

        #endregion
    }
}
