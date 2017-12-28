using System;

namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// ChangePrepay 的摘要说明。
	/// </summary>
	public class ChangePrepay :Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public ChangePrepay()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ChangeType"></param>
		/// <param name="ClinicNo"></param>
		/// <returns></returns>
		public string GetChangePrepay(string ChangeType,string ClinicNo)
		{
			string strSql="";
			string PrepayCost ="";
			//select prepay_cost from fin_com_changeprepay where clinic_no ='{0}' and change_type ='{1}' and change_code ='[本级编码]' and PARENT_CODE ='[父级编码]' and CURRENT_CODE ='[本级编码]'AND BALANCE_STATE ='0' 
			if (this.Sql.GetSql("Management.Fee.GetChangePrepay",ref strSql)==-1) return null;
			try
			{
				strSql = string.Format(strSql,ClinicNo,ChangeType);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					 PrepayCost =Reader[0].ToString(); //预交金
				}
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
				return "";
			}
			return PrepayCost;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateChangePrepay(Neusoft.HISFC.Models.Fee.TransferPrepay  info)
		{
			string strSql = "";
			//update fin_com_changeprepay set prepay_cost ={0} where change_type ='{1}' and clinic_no ='{2}' and change_code ='[本级编码]' and current_code ='[父级编码]' and parent_code='[本级编码 ]'
			if (this.Sql.GetSql("Fee.TransferPrepay.UpdateChangePrepay",ref strSql)==-1)return -1;
			try
			{
				string OperCode =this.Operator.ID;
				strSql = string.Format(strSql,info.FT.TransferPrepayCost,info.Type.ID,info.ID);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertChangePrepay(Neusoft.HISFC.Models.Fee.TransferPrepay info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.TransferPrepay.InsertChangePrepay",ref strSql)==-1)return -1;
			try
			{
				string OperCode =this.Operator.ID;
				//insert into fin_com_changeprepay (PARENT_CODE,CURRENT_CODE,CHANGE_TYPE,CLINIC_NO,NAME,PAYKIND_CODE,PACT_CODE,PREPAY_COST,CHARGE_OPERCODE,CHARGE_DATE ,BALANCE_STATE,OPER_CODE,OPER_DATE)
				//values ('[父级编码]','[本级编码]','[本级编码]','{0}','{1}','{2}','{3}',{4},'{5}',sysdate,'{6}','{7}',sysdate)
				strSql = string.Format(strSql,info.Type.ID,info.ID,info.Name,info.Pact.PayKind.ID,info.Pact.ID,info.FT.TransferPrepayCost,OperCode,info.BalanceState,OperCode);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int DeleteChangePrepay(Neusoft.HISFC.Models.Fee.TransferPrepay info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.TransferPrepay.DeleteChangePrepay",ref strSql)==-1)return -1;
			try
			{
				string OperCode =this.Operator.ID;
				// delete fin_com_changeprepay where clinic_no ='{0}' and change_type ='{1}' and change_code ='[本级编码]' and PARENT_CODE ='[父级编码]' and CURRENT_CODE ='[本级编码]'
				strSql = string.Format(strSql,info.ID,info.Type.ID);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public bool UpdateOrInsertChangePrepay(Neusoft.HISFC.Models.Fee.TransferPrepay info )
		{
			bool Result= true;;
			int temp =0;
			temp =IsAlreadyInChangePrepay(info.Type.ID,info.ID );
			if(temp>0)
			{
				//更新
				if(UpdateChangePrepay(info)<=0)
				{
					Result =false;//更新失败
				}
			}
			else if(temp ==0)
			{
				//插入
				if(InsertChangePrepay(info)<=0)
				{
					Result = false; //插入失败
				}
			}
			else
			{
				//出错了。
				Result = false;
			}
			return Result ;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="changeType"></param>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		public int IsAlreadyInChangePrepay(string changeType ,string clinicNo)
		{
			string strSql = "";
			//select clinic_no  from fin_com_changeprepay where clinic_no =[0} and  change_type ='{1}' and change_code ='[本级编码]' and PARENT_CODE ='[父级编码]' and CURRENT_CODE ='[本级编码]'
			if (this.Sql.GetSql("Fee.TransferFee.IsAlreadyInChangePrepay",ref strSql)==-1)return -1;
			try
			{
				strSql= string.Format(strSql,clinicNo,changeType);

				this.ExecQuery(strSql);

				if(this.Reader.Read())
				{
					if(Reader[0]!=DBNull.Value) 
					{
						return 1;
					}
					else 
					{
						return 0;
					}
				}
				else
				{
					return 0;
				}
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ClinicNo"></param>
		/// <returns></returns>
		public decimal  SumPrepay(string ClinicNo)
		{

			decimal  SumPrepay =0;
			string strSql = "";
			//select sum( prepay_cost) from fin_com_changeprepay where clinic_no ='{0}'  and change_code ='[本级编码]' and PARENT_CODE ='[父级编码]' and CURRENT_CODE ='[本级编码]'AND BALANCE_STATE ='0' 
			if (this.Sql.GetSql("Fee.TransferFee.SumPrepay",ref strSql)==-1)return -1;
			try
			{
				strSql= string.Format(strSql,ClinicNo);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			this.ExecQuery(strSql);
			while(this.Reader.Read())
			{
				if(Reader[0]!=DBNull.Value)
				{
					SumPrepay = Convert.ToDecimal(Reader[0]);
				}
			}
			return SumPrepay;
		}
	}
}

