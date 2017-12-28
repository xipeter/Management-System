using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Order
{
	/// <summary>
	/// ChargeBill 病区收费单
	/// </summary>
	public class ChargeBill:Neusoft.FrameWork.Management.Database
	{
		public ChargeBill()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region 增删改
		/// <summary>
		/// 插入一张收费单
		/// </summary>
		/// <param name="bill"></param>
		/// <returns></returns>
		public int InsertChargeBill( Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill )
		{
			#region 参数
//	    		'{0}',   --住院号
//            '{1}',   --是否婴儿用药 0 不是 1 是
//            '{2}',   --住院科室
//            '{3}',   --护士站
//            '{4}',   --开方医生
//            '{5}',   --开方科室
//            '{6}',   --药品标志,1药品/0非药
//            '{7}',   --项目代码
//            '{8}',   --项目名称
//            '{9}',   --规格
//            '{10}',   --零售价
//            '{11}',   --数量
//            '{12}',   --付数
//            '{13}',   --单位
//            '{14}',   --执行科室
//            '{15}',   --取药药房
//            '{16}',   --医嘱号
//            '{17}',   --医嘱执行号
//            '{18}',   --单据号-s
//            '{19}',   --打印标志 0未打/1已打印
//            '{20}',   --录入人
			#endregion
			string sql = "";
			if(this.Sql.GetSql("Order.ChargeBill.Insert.1",ref sql)==-1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}

			try
			{
				sql=string.Format(sql,bill.InpatientNO,Neusoft.FrameWork.Function.NConvert.ToInt32(bill.IsBaby),bill.InDept,bill.NurseStation.ID,
					bill.Doctor.ID,bill.ReciptDept.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(bill.IsPharmacy),bill.ID,
					bill.Name,bill.Specs,bill.Price.ToString(),bill.Qty.ToString(),
					bill.HerbalQty.ToString(),bill.PriceUnit,bill.ExeDept.ID,bill.StockDept.ID,
					bill.OrderID,bill.ExecOrderID,bill.BillNO,Neusoft.FrameWork.Function.NConvert.ToInt32(bill.IsPrint),
					bill.Oper.ID,bill.TotCost.ToString(),bill.Combo.ID,bill.OutputType);
				return this.ExecNoQuery(sql);				
			}
			catch(Exception e)
			{
				this.Err="插入收费单表出错![Order.ChargeBill.Insert.1]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}		
		}
		
		/// <summary>
		/// 更新标记
		/// 更新打印标记，或者收费标记
		/// </summary>
		/// <param name="p"></param>
		/// <param name="bill"></param>
		/// <returns></returns>
		public int UpdateChargeBill( EnumUpdateType p, Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill )
		{
			if(p==EnumUpdateType.Print)
			{
				return UpdatePrintFlag(bill);
			}
			else if(p==EnumUpdateType.Charge)
			{
				return UpdateChargeFlag(bill);
			}
			return 0;
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="billID"></param>
		/// <returns></returns>
		public int DeleteChargeBill(string billID)
		{
			#region sql
//			DELETE 
//			FROM met_nui_chargebill   --病区收费单
//			WHERE parent_code='[父级编码]'
//			AND current_code='[本级编码]'
//			AND bill_id='{0}'
			#endregion

			string sql = "";
			if(this.Sql.GetSql("Order.ChargeBill.Delete.1", ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}

			try
			{
				sql = string.Format( sql, billID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除收费单表出错![Order.ChargeBill.Delete.1]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}
		#endregion
		
		#region 作废
		[Obsolete("用UpdatePrintFlag代替了",true)]
		private int UpdatePrint(Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill)
		{
			return this.UpdatePrintFlag(bill);
		}
		[Obsolete("用UpdateChargeFlag代替了",true)]
		private int UpdateCharge(Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill)
		{
			return this.UpdateChargeFlag(bill);
		}
		[Obsolete("用QueryChargeBillNotPrinted代替了",true)]
		public ArrayList Query(string InpatientNo,bool IsPharmacy)
		{
			return this.QueryChargeBillNotPrinted(InpatientNo,IsPharmacy);
		}
		[Obsolete("用QueryByNurseStation代替了",true)]
		public ArrayList QueryForNurseStation(string inpatientNo, bool isPharmacy)
		{
			return this.QueryChargeBillByNurseStation(inpatientNo,isPharmacy);
		}
		[Obsolete("用QueryForNurseStation代替了",true)]
		public ArrayList QueryForNurseStation(string InpatientNo,bool IsPharmacy,DateTime begin,DateTime end)
		{
			return this.QueryChargeBillByNurseStation(InpatientNo,IsPharmacy, begin, end);
		}
		/// <summary>
		/// 查询患者出单显示的特殊标志.
		/// </summary>
		/// <param name="isPharmacy"></param>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		[Obsolete("应该不用吧，tmd没找到sql语句",false)]
		public string QuerySpFlag(bool isPharmacy, string itemCode)
		{
			string sql = "";
			string spFlag = "";
			if(isPharmacy)//药品
			{
				if(this.Sql.GetSql("Order.ChargeBill.QuerySpFlag.1", ref sql) == -1)
				{
					return "";
				}
			}
			else //非药品
			{
				if(this.Sql.GetSql("Order.ChargeBill.QuerySpFlag.2", ref sql) == -1)
				{
					return "";
				}
			}

			sql = string.Format(sql, itemCode);

			if(this.ExecQuery(sql) == -1)
			{
				return "";
			}

			try
			{

				while(Reader.Read())
				{
					spFlag = Reader[0].ToString();
				}
				Reader.Close();
			}
			catch(Exception ex)
			{
				if(Reader.IsClosed == false)
				{
					Reader.Close();
				}
				this.Err = "查询特殊显示标志出错!" + ex.Message;
				return "";
			}
			return spFlag;
		}
		#endregion 

		#region 标志
		/// <summary>
		/// 更新打印标志
		/// </summary>
		/// <param name="bill"></param>
		/// <returns>-1 错误 0 没有更新（没有查到记录） >0 更新到信息</returns>
		public int UpdatePrintFlag(Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill)
		{
			#region sql
			//			UPDATE met_nui_chargebill   --病区收费单
			//   SET bill_no='{1}',   --单据号
			//       print_flag='{2}',   --打印标志 0未打/1已打印
			//       print_code='{3}',   --打印人
			//       print_date=sysdate    --打印时间
			// WHERE parent_code='[父级编码]'
			//   AND current_code='[本级编码]'
			//   AND bill_id='{0}'
			#endregion
			string sql = "";
			if(this.Sql.GetSql("Order.ChargeBill.Update.1",ref sql)==-1)
			{
				this.Err = this.Sql.Err;

				return -1;
			}
			try
			{
				sql=string.Format(sql,bill.ID,bill.BillNO,Neusoft.FrameWork.Function.NConvert.ToInt32(bill.IsPrint),bill.PrintOper.ID);

				return  this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="更新收费单表出错![Order.ChargeBill.Update.1]"+e.Message;
				this.ErrCode=e.Message;

				return -1;
			}		
		}
		/// <summary>
		/// 更新收费标志
		/// </summary>
		/// <param name="bill"></param>
		/// <returns>-1 错误 0 没有更新（没有查到记录） >0 更新到信息</returns>
		public int UpdateChargeFlag(Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill)
		{
			#region sql
			//			UPDATE met_nui_chargebill   --病区收费单
			//			SET charge_flag='{1}',   --是否收费 0未/1已
			//				charge_code='{2}',   --收费人
			//				charge_date=sysdate    --收费时间
			//			WHERE parent_code='[父级编码]'
			//			AND current_code='[本级编码]'
			//			AND bill_id='{0}'
			#endregion
			string sql = "";
			if(this.Sql.GetSql("Order.ChargeBill.Update.2",ref sql) == -1)
			{
				this.Err = this.Sql.Err ;
				return -1;
			}

			try
			{
				sql=string.Format(sql,bill.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(bill.IsCharge),bill.Oper.ID,
					bill.ReciptNO,bill.SequenceNO);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="更新收费单表出错![Order.ChargeBill.Update.2]"+e.Message;
				this.ErrCode=e.Message;

				return -1;
			}
		}
		#endregion

		#region 查询
		/// <summary>
		/// 按患者查询未打印收费单
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="isPharmacy"></param>
		/// <returns>null 错误</returns>
		public ArrayList QueryChargeBillNotPrinted( string inpatientNo, bool isPharmacy )
		{
			string sql = "";
			if(this.Sql.GetSql("Order.ChargeBill.Query.1",ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			
			sql = string.Format(sql,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isPharmacy));

			return myQueryChargeBill(sql);
		}
		/// <summary>
		/// 护士占出单查询,关联执行档, 排序按,医嘱流水号，comb_no和useTime
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="isPharmacy"></param>
		/// <returns>null 错误</returns>
		public ArrayList QueryChargeBillByNurseStation(string inpatientNo, bool isPharmacy)
		{
			string sql = "";
			if(isPharmacy)
			{
				if(this.Sql.GetSql("Order.ChargeBill.Query.NurseStation.1",ref sql)==-1)
				{
					this.Err = this.Sql.Err;
					return null;
				}
			}
			else
			{
				if(this.Sql.GetSql("Order.ChargeBill.Query.NurseStation.3",ref sql)==-1)
				{
					this.Err = this.Sql.Err;
					return null;
				}
			}
			
			sql=string.Format(sql,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isPharmacy));

			return myQueryChargeBillByNurseStation(sql);
		}
		/// <summary>
		/// 按患者、时间段查询已打印收费单
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="isPharmacy"></param>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <returns></returns>
		public ArrayList QueryChargeBillByNurseStation( string inpatientNo, bool isPharmacy, DateTime beginTime, DateTime endTime )
		{
			string sql = "";
			if(isPharmacy)
			{
				if(this.Sql.GetSql("Order.ChargeBill.Query.NurseStation.2",ref sql)==-1)
				{
					this.Err = this.Sql.Err;

					return null;
				}
			}
			else
			{
				if(this.Sql.GetSql("Order.ChargeBill.Query.NurseStation.4",ref sql)==-1)
				{
					this.Err = this.Sql.Err;

					return null;
				}
			}
			
			sql = string.Format(sql,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isPharmacy),
				beginTime.ToString(),endTime.ToString());

			return myQueryChargeBillByNurseStation(sql);
		}
		/// <summary>
		/// 按患者、是否打印、是否收费查询收费单
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="isPrint"></param>
		/// <param name="isCharge"></param>
		/// <returns></returns>
		public ArrayList QueryChargeBill( string inpatientNo, bool isPrint, bool isCharge )
		{
			string sql = "";
			if(this.Sql.GetSql("Order.ChargeBill.Query.2",ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			
			sql = string.Format(sql,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isPrint),Neusoft.FrameWork.Function.NConvert.ToInt32(isCharge));

			return myQueryChargeBill(sql);
		}
		/// <summary>
		/// 按患者、时间段查询已打印收费单
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="isPharmacy"></param>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <returns></returns>
		public ArrayList QueryChargeBill( string inpatientNo, bool isPharmacy, DateTime beginTime, DateTime endTime )
		{
			string sql = "";
			if(this.Sql.GetSql("Order.ChargeBill.Query.3",ref sql)==-1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			
			sql = string.Format(sql,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isPharmacy),
				beginTime.ToString(),endTime.ToString());

			return myQueryChargeBill(sql);
		}
		
		
		#endregion

		/// <summary>
		/// 基本查询
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList myQueryChargeBill( string sql )
		{
			ArrayList al=new ArrayList();
			try
			{
				if(this.ExecQuery(sql) == -1) return null;
				while(Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill=new Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill();
					bill.ID=Reader[2].ToString();//流水号
					bill.InpatientNO = Reader[3].ToString();//住院号
					bill.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[4].ToString());
					bill.InDept.ID = Reader[5].ToString();//住院科室
					bill.NurseStation.ID = Reader[6].ToString();//住院病区
					bill.Doctor.ID = Reader[7].ToString();
					bill.ReciptDept.ID = Reader[8].ToString();//开发科室
					bill.IsPharmacy = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[9].ToString());
					bill.ID = Reader[10].ToString();//项目代码
					bill.Name = Reader[11].ToString();//项目名称
					bill.Specs = Reader[12].ToString();//规格
                    bill.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[13].ToString());//价格
                    bill.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[14].ToString());//数量
					bill.HerbalQty =  FrameWork.Function.NConvert.ToInt32(Reader[15].ToString());//草药数量
					bill.PriceUnit=Reader[16].ToString();					//价格单位
					bill.ExeDept.ID=Reader[17].ToString();					//执行科室
					bill.StockDept.ID =Reader[18].ToString();				//取药药房
					bill.OrderID =Reader[19].ToString();					//医嘱流水号
					bill.ExecOrderID =Reader[20].ToString();				//执行流水号
					bill.BillNO=Reader[21].ToString();						//单据号
					bill.IsPrint=Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[22].ToString());//是否打印
					bill.Oper.ID=Reader[23].ToString();
					bill.Oper.OperTime = FrameWork.Function.NConvert.ToDateTime(Reader[24].ToString());//操作时间
					bill.PrintOper.ID = Reader[25].ToString();						//打印人
					bill.PrintOper.OperTime = FrameWork.Function.NConvert.ToDateTime(Reader[26].ToString()); //打印时间
					bill.IsCharge=Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[27].ToString());
					bill.Oper.ID = Reader[28].ToString();					//收费人
					bill.Oper.OperTime = FrameWork.Function.NConvert.ToDateTime(Reader[29].ToString()); //收费时间
					bill.TotCost = FrameWork.Function.NConvert.ToDecimal(Reader[30].ToString());	//总额
					bill.Combo.ID =Reader[31].ToString();						//组合号
					bill.OutputType = Reader[32].ToString();				//出单类型
					al.Add(bill);
				}
				Reader.Close();
			}
			catch(Exception e)
			{
				if(Reader.IsClosed == false) Reader.Close();
				this.Err = "查询收费单表出错!"+e.Message;
				this.ErrCode=e.Message;
				this.WriteErr();
				return null;
			}
			return al;
		}
		/// <summary>
		/// 基本查询为护士占查询服务
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList myQueryChargeBillByNurseStation( string sql )
		{
			ArrayList al=new ArrayList();
			try
			{
				if(this.ExecQuery(sql)==-1)return null;
				while(Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill bill=new Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill();
					bill.ID = Reader[2].ToString();//流水号
					bill.InpatientNO = Reader[3].ToString();//住院号
					bill.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[4].ToString());
					bill.InDept.ID = Reader[5].ToString();//住院科室
					bill.NurseStation.ID =Reader[6].ToString();//住院病区
					bill.Doctor.ID = Reader[7].ToString();
					bill.ReciptDept.ID =Reader[8].ToString();//开发科室
					bill.IsPharmacy=Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[9].ToString());
					bill.ID=Reader[10].ToString();//项目代码
					bill.Name=Reader[11].ToString();//项目名称
					bill.Specs=Reader[12].ToString();//规格
					bill.Price = FrameWork.Function.NConvert.ToDecimal(Reader[13].ToString());//价格
					bill.Qty = FrameWork.Function.NConvert.ToDecimal(Reader[14].ToString());//数量
					bill.HerbalQty =FrameWork.Function.NConvert.ToInt32(Reader[15].ToString());//草药数量
					bill.PriceUnit = Reader[16].ToString();//价格单位
					bill.ExeDept.ID = Reader[17].ToString();//执行科室
					bill.StockDept.ID = Reader[18].ToString();//取药药房
					bill.OrderID = Reader[19].ToString();//医嘱流水号
					bill.ExecOrderID = Reader[20].ToString();//执行流水号
					bill.BillNO = Reader[21].ToString();//单据号
					bill.IsPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[22].ToString());//打印标记
					bill.Oper.ID =Reader[23].ToString();//操作人
					bill.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[24].ToString());//操作时间
					bill.PrintOper.ID =Reader[25].ToString();//打印人
					bill.PrintOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[26].ToString());//打印时间
					bill.IsCharge=Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[27].ToString());//是否收费标记
					bill.Oper.ID =Reader[28].ToString();//收费人
					bill.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[29].ToString());//收费时间
					bill.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[30].ToString());//总额
					bill.Combo.ID = Reader[31].ToString();//组合号
					bill.UseTime  = FrameWork.Function.NConvert.ToDateTime(Reader[32].ToString());//使用时间
					if(Reader.IsDBNull(33) == false)
					{
						bill.Frequency.ID = Reader[33].ToString();//频次
					}
					if(Reader.IsDBNull(34) == false)
					{
						bill.Memo = Reader[34].ToString();//特殊显示标志
					}
					bill.OutputType = Reader[35].ToString();//出单类型

					al.Add(bill);
				}
				Reader.Close();
			}
			catch(Exception e)
			{
				if(Reader.IsClosed == false) Reader.Close();
				this.Err="查询收费单表出错!"+e.Message;
				this.ErrCode = e.Message;
				this.WriteErr();
				return null;
			}
			return al;
		}
	}


	public enum EnumUpdateType {

		/// <summary>
		/// 更新打印
		/// </summary>
		Print,
		/// <summary>
		/// 确认收费
		/// </summary>
		Charge
	}
}
