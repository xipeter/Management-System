using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// Ecoformula 的摘要说明。
	/// </summary>
	public class Ecoformula :  Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public Ecoformula()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//		ECO_FLAG       VARCHAR2(1)                     优惠准则标志 0 对人 1 对就诊记录     
		//		CLINIC_CODE    VARCHAR2(14)            'AAAA'  就诊记录                             
		//		CARD_NO        VARCHAR2(10)                    就诊卡号                             
		//		PACTCODE_FLAG  VARCHAR2(1)    Y                合同单位                             
		//		ICDCODE_FLAG   VARCHAR2(1)    Y                单病种标志                           
		//		DATE_FLAG      VARCHAR2(1)    Y                时段标志                             
		//		ECOREAL_FLAG   VARCHAR2(1)    Y                优惠原则关系 0 取最大优惠 1 取并优惠 
		//		SPECIL_FORMULA VARCHAR2(2000) Y                特殊规则公式 

		/// <summary>
		/// 查询优惠套餐表的数据
		/// </summary>
		/// <param name="ecoflag"></param>
		/// <param name="clinic"></param>
		/// <returns></returns>
		public ArrayList GetEcoformulaInfo(string ecoflag,string clinic)
		{
			ArrayList List = new ArrayList();
			string strSql ="";
			//select ECO_FLAG ,CLINIC_CODE ,PACTCODE_FLAG ,ICDCODE_FLAG,DATE_FLAG ,ECOREAL_FLAG from  fin_com_ecoformula where PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]' and ECO_FLAG ='{0}'  and   CLINIC_CODE = '{1}' 
			if(this.Sql.GetSql("Management.Fee.GetEcoformulaInfo",ref strSql)==-1) return null;
			try
			{
				Neusoft.HISFC.Models.Fee.Useless.EcoFormula info ;
				strSql = string.Format(strSql,ecoflag ,clinic);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Fee.Useless.EcoFormula();
					info.EcoFlag = Reader[0].ToString();
					info.ClinicCode = Reader[1].ToString();
					info.PactcodeFlag = Reader[2].ToString();
					info.IcdcodeFlag = Reader[3].ToString();
					info.DateFlag = Reader[4].ToString();
					info.EcorealFlag = Reader[5].ToString();
					List.Add(info);
					info = null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				List = null;
			}

			return List;
		}
		/// <summary>
		/// 
		/// 查询优惠套餐表的数据
		/// </summary>
		/// <returns></returns>
		public ArrayList GetEcoformulaAll()
		{
			ArrayList List = new ArrayList();
			string strSql ="";
			//select ECO_FLAG ,CLINIC_CODE ,PACTCODE_FLAG ,ICDCODE_FLAG,DATE_FLAG ,ECOREAL_FLAG from  fin_com_ecoformula where PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]'
			if(this.Sql.GetSql("Management.Fee.GetEcoformulaAll",ref strSql)==-1) return null;
			try
			{
				Neusoft.HISFC.Models.Fee.Useless.EcoFormula info ;
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Fee.Useless.EcoFormula();
					try
					{
						info.EcoFlag = Reader[0].ToString();
					}
					catch(Exception ee)
					{
						string Error  =ee.Message;
					}
					try
					{
						info.ClinicCode = Reader[1].ToString();
					}
					catch(Exception ee)
					{
						string Error  =ee.Message;
					}

					try
					{
						info.PactcodeFlag = Reader[2].ToString();
					}
					catch(Exception ee)
					{
						string Error  =ee.Message;
					}
					try
					{
						info.IcdcodeFlag = Reader[3].ToString();
					}
					catch(Exception ee)
					{
						string Error  =ee.Message;
					}
					try
					{
						info.DateFlag = Reader[4].ToString();
					}
					catch(Exception ee)
					{
						string Error  =ee.Message;
					}
					try
					{
						info.EcorealFlag = Reader[5].ToString();
					}
					catch(Exception ee)
					{
						string Error  =ee.Message;
					}

					List.Add(info);
					info = null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				List = null;
			}

			return List;
		}

		/// <summary>
		/// 更新优惠套餐表的数据
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateEcoformula(Neusoft.HISFC.Models.Fee.Useless.EcoFormula info)
		{
			string strSql = "";
			//update fin_com_ecoformula set PACTCODE_FLAG= '{2}' ,ICDCODE_FLAG='{3}' ,DATE_FLAG='{4}',ECOREAL_FLAG='{5}',SPECIL_FORMULA='{6}'  where ECO_FLAG= '{0}' and CLINIC_CODE='{1}'and PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]' 
			if(this.Sql.GetSql("Management.Fee.UpdateEcoformula",ref strSql)==-1 ) return -1;
			try
			{
				strSql = string.Format(strSql,info.EcoFlag,info.ClinicCode,info.PactcodeFlag,info.IcdcodeFlag,info.DateFlag,info.EcorealFlag);
			}
			catch(Exception ee)
			{
				this.Err =ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除优惠套餐表的数据
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int DeleteEcoformula(Neusoft.HISFC.Models.Fee.Useless.EcoFormula info)
		{
			string strSql = "";
			// delete fin_com_ecoformula where ECO_FLAG ='{0}' and CLINIC_CODE ='{1}' and CARD_NO ='{2}' and  PARENT_CODE = '[父级编码]' and CURRENT_CODE ='[本级编码]'
			if (this.Sql.GetSql("Management.Fee.DeleteEcoformula",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.EcoFlag,info.ClinicCode);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 插入 优惠套餐表的数据
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertEcoformula(Neusoft.HISFC.Models.Fee.Useless.EcoFormula info)
		{
			string strSql = "";
			//insert into fin_com_ecoformula (PARENT_CODE,CURRENT_CODE,ECO_FLAG ,CLINIC_CODE ,PACTCODE_FLAG ,ICDCODE_FLAG,DATE_FLAG ,ECOREAL_FLAG,OPER_CODE,OPER_DATE ) values('[父级编码]','[本级编码]','{0}','{1}','{2}','{3}','{4}','{5}','{6}',,sysdate)
			if (this.Sql.GetSql("Management.Fee.InsertEcoformula",ref strSql)==-1)return -1;
			try
			{
				string OperCode = this.Operator.ID;
				strSql = string.Format(strSql,info.EcoFlag,info.ClinicCode,info.PactcodeFlag,info.IcdcodeFlag,info.DateFlag,info.EcorealFlag,OperCode);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		private  int SelectDataByClinic_no(string Clinic_Code)
		{     
			string strSql ="";
			int Return = -1 ;
			//select CLINIC_CODE from fin_com_ecoformula  where parent_code ='[父级编码]'   and current_code='[本级编码]'   and CLINIC_CODE  = '{1}'  and icdcode_flag ='1' 
			if(this.Sql.GetSql("Management.Fee.SelectDateByClinic_no",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,Clinic_Code);
				Return = this.ExecQuery(strSql);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				Return = -1;
			}
			return Return;
		}             
		/// <summary>
		///  如果是SQL出错或程序出错返回-1,如果没有该住院号或就诊卡号，返回0 ，如果有记录，则返回 上封顶线 
		/// </summary>
		/// <param name="Clinic_Code">住院号或就诊卡号 </param>
		/// <param name="feeCode">最小费用编码</param>
		/// <param name="dt">日期</param>
		/// <returns></returns>
		public  decimal  GetCost(string Clinic_Code,string feeCode ,System.DateTime dt )
		{
			//
			decimal Result =0;
			try
			{
				int temp = SelectDataByClinic_no(Clinic_Code);
				if(temp>0)
				{
					string  IcdCode = GetIcdCode(Clinic_Code);
					if (IcdCode=="-1")
					{
						//
						return -1;
					}
					if(IcdCode =="")
					{
						return 0;
					}
					if(IcdCode!="")
					{
						Result =Convert.ToInt32( GetCostByIcode(feeCode, IcdCode, dt));
					}
				}
				else if(temp ==0)
				{
					Result = 0;
				}
				else
				{
					Result =-1;
				}

			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				Result =-1;
			}
			return Result;
		}
		/// <summary>
		/// 得到icdcode 疾病编码      
		/// </summary>
		/// <param name="Clinic_Code"></param>
		/// <returns></returns>
		private  string GetIcdCode(string Clinic_Code)
		{
			//SELECT icd_code FROM met_com_diagnose WHERE parent_code = '[父级编码]'  AND current_code = '[本级编码]'  AND inpatient_no = '{0}'   AND diag_kind = '17'  AND diag_flag = '0'
			string Icdcode = "";
			string strSql ="";
			if(this.Sql.GetSql("Management.Fee.GetIcdCode",ref strSql)==-1) return "";
			try
			{
				strSql = string.Format(strSql,Clinic_Code);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					Icdcode = this.Reader[0].ToString();
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message; 
				Icdcode =  "-1";
			}
			return Icdcode ;
		}
		private string GetCostByIcode(string feecode,string IcdCode,System.DateTime dt)
		{
			string Cost ="";
			string strSql ="";
			//select cost from fin_com_ecoicdfee where parent_code  ='[父级编码]' and current_code ='[本级编码]' and fee_code = '{0}'  and begin_date  < to_date('{2}','yyyy-mm-dd hh24:mi:ss')   and end_date > to_date('{2}','yyyy-mm-dd hh24:mi:ss')  and icd_code = '{1}'
			if(this.Sql.GetSql("Management.Fee.GetCostByIcode",ref strSql)==-1) return "-1";
			try
			{
				strSql = string.Format(strSql,feecode,IcdCode,dt);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					Cost = this.Reader[0].ToString();
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				return   "-1";
			}
			return Cost;
		}
	}
}
