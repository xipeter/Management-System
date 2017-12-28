using System;
using Neusoft.HISFC.Object;
using System.Collections;
using Neusoft.NFC.Object;
namespace Neusoft.HISFC.Management.Order
{
	/// <summary>
	/// 医嘱管理类。
	/// </summary>
	public class ExecOrder:Neusoft.NFC.Management.Database 
	{
		public ExecOrder()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		// <summary>
		// 建立执行档(插入执行档记录)
		// </summary>
		// <param name="ExecOrder"></param>
		// <returns>0 success -1 fail</returns>
//		public int CreateExec(Object.Order.ExecOrder ExecOrder)
//		{
//			#region insert执行档
//			///插入执行档
//			///Order.ExecOrder.CreateExec.1
//			///传入：71
//			///传出：0 
//			#endregion
//			string strSql="";
//			string strItemType="";
//
//			strItemType=JudgeItemType(ExecOrder);
//			if (strItemType=="") return -1;
//			#region "药嘱执行档"
//			if (strItemType== "1")
//			{
//				Neusoft.HISFC.Object.Pharmacy.Item objPharmacy ;
//				objPharmacy = (Neusoft.HISFC.Object.Pharmacy.Item)ExecOrder.Order.Item;
//
//				if(this.Sql.GetSql("Order.ExecOrder.CreateExec.Drug.1",ref strSql)==-1) return -1;
//	
//				#region "药嘱接口说明"
//				//0 ID执行流水号
//				//患者信息——  
//				//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
//				//医嘱辅助信息
//				// ——项目信息
//				//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
//				//	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
//				//         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
//				//         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
//				//         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
//				// ——医嘱属性
//				//		   30医嘱类别代码 31医嘱流水号  32医嘱是否分解:1长期/2临时     33是否计费 
//				//		   34药房是否配药 35打印执行单    36是否需要确认  
//				// ——执行情况
//				//		   37开立医师Id   38开立医师name  39要求执行时间  40作废时间     41开立科室
//				//		   42开立时间     43作废人代码    44记账人代码    45记账科室代码 46记账时间       
//				//		   47取药药房     48执行科室      49执行护士代码  50执行科室代码 51执行时间
//				//         52分解时间 
//				// ——医嘱类型
//				//		   52是否婴儿（1是/2否）          53发生序号  	  54组合序号     55主药标记 
//				//		   56是否包含附材                 57是否有效      58扣库标记     59是否执行 
//				//		   60配药标记                     61收费标记      62医嘱说明     63备注 
//				#endregion 
//				try
//				{
//					string[] s={ExecOrder.ID,ExecOrder.Order.Patient.ID,ExecOrder.Order.Patient.Patient.PID.PatientNo,ExecOrder.Order.Patient.PVisit.PatientLocation.Dept.ID,ExecOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID,
//								   strItemType,ExecOrder.Order.Item.ID,ExecOrder.Order.Item.Name,ExecOrder.Order.Item.UserCode,ExecOrder.Order.Item.SpellCode,
//								   ExecOrder.Order.Item.SysClass.ID.ToString(),ExecOrder.Order.Item.SysClass.Name,objPharmacy.Specs,objPharmacy.BaseDose.ToString(),objPharmacy.DoseUnit,objPharmacy.MinUnit,objPharmacy.PackQty.ToString(),
//								   objPharmacy.DosageForm.ID,objPharmacy.Type.ID,objPharmacy.Quality.ID.ToString(),objPharmacy.RetailPrice.ToString(),
//								   ExecOrder.Order.Usage.ID,ExecOrder.Order.Usage.Name,ExecOrder.Order.Usage.Memo,ExecOrder.Order.Frequency.ID,ExecOrder.Order.Frequency.Name,
//								   ExecOrder.Order.DoseOnce.ToString(),ExecOrder.Order.QTY.ToString(),ExecOrder.Order.Unit,ExecOrder.Order.Usetimes.ToString(),
//								   ExecOrder.Order.OrderType.ID,ExecOrder.Order.OrderType.Name,System.Convert.ToInt16(ExecOrder.Order.OrderType.IsDecompose).ToString(),System.Convert.ToInt16(ExecOrder.Order.OrderType.IsCharge).ToString(),
//								   System.Convert.ToInt16(ExecOrder.Order.OrderType.IsNeedPharmacy).ToString(),System.Convert.ToInt16(ExecOrder.Order.OrderType.IsPrint).ToString(),System.Convert.ToInt16(ExecOrder.Order.OrderType.IsConfirm).ToString(),
//								   ExecOrder.Order.ReciptDoct.ID,ExecOrder.Order.ReciptDoct.Name,ExecOrder.DateUse.ToString(),ExecOrder.DcExecTime.ToString(),ExecOrder.Order.ReciptDept.ID,
//								   ExecOrder.Order.Date_MO.ToString(),ExecOrder.DcExecUser.ID,ExecOrder.ChargeUser.ID,ExecOrder.ReciptDept.ID,ExecOrder.ChargeTime.ToString(),
//								   ExecOrder.StockDept.ID,ExecOrder.ExeDept.ID,ExecOrder.ExecUser.ID,ExecOrder.ReciptDept.ID,ExecOrder.ExecTime.ToString(),
//								   ExecOrder.DateDeco.ToString(),
//								   System.Convert.ToInt16(ExecOrder.Order.IsBaby).ToString(),ExecOrder.Order.BabyNo.ToString(),ExecOrder.Order.Combo.ID,System.Convert.ToInt16(ExecOrder.Order.Combo.MainDrug).ToString(),
//								   System.Convert.ToInt16(ExecOrder.Order.IsHaveSubtbl).ToString(),System.Convert.ToInt16(ExecOrder.IsInvalid).ToString(),System.Convert.ToInt16(ExecOrder.Order.IsStock).ToString(),System.Convert.ToInt16(ExecOrder.IsExec).ToString(),
//								   ExecOrder.DrugFlag.ToString(),System.Convert.ToInt16(ExecOrder.IsCharge).ToString(),ExecOrder.Order.Note,ExecOrder.Order.Memo};
//					strSql=string.Format(strSql,s);
//				}
//				catch(Exception ex)
//				{
//					this.Err="付数值时候出错！"+ex.Message;
//					this.WriteErr();
//					return -1;
//				}
//			}			
//			#endregion
//			#region "非药嘱执行档"
//			else if (strItemType== "2")
//			{
//				Neusoft.HISFC.Object.Fee.Item objAssets;
//				objAssets = (Neusoft.HISFC.Object.Fee.Item)ExecOrder.Order.Item;
//
//				if(this.Sql.GetSql("Order.ExecOrder.CreateExec.Undrug.1",ref strSql)==-1) return -1;	
//				#region "非药嘱接口说明"
//				//0 ID执行流水号
//				//患者信息——  
//				//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
//				//医嘱辅助信息
//				// ——项目信息
//				//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
//				//	       10项目类别代码 11项目类别名称  12规格         13零售价        14用法代码   
//				//         15用法名称     16用法英文缩写  17频次代码     18频次名称      19每次用量
//				//         20项目总量     21计价单位      22使用次数			  
//				// ——医嘱属性
//				//		   23医嘱类别代码 24医嘱流水号    25医嘱是否分解:1长期/2临时     26是否计费 
//				//		   27药房是否配药 28打印执行单    29是否需要确认  
//				// ——执行情况
//				//		   30开立医师Id   31开立医师name  32要求执行时间  33作废时间     34开立科室
//				//		   35开立时间     36作废人代码    37记账人代码    38记账科室代码 39记账时间       
//				//		   40取药药房     41执行科室      42执行护士代码  43执行科室代码 44执行时间
//				//       45分解时间     46执行科室名称
//				// ——医嘱类型
//				//		   47是否婴儿（1是/2否）          48发生序号  	  49组合序号     50主项标记 
//				//		   51是否附材                     52是否包含附材  53是否有效     54是否执行 
//				//		   55收费标记     56加急标记      57检查部位检体  58医嘱说明     59备注 
//				#endregion 
//				try
//				{
//					string[] s={ExecOrder.ID,ExecOrder.Order.Patient.ID,ExecOrder.Order.Patient.Patient.PID.PatientNo,ExecOrder.Order.Patient.PVisit.PatientLocation.Dept.ID,ExecOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID,
//								   strItemType,ExecOrder.Order.Item.ID,ExecOrder.Order.Item.Name,ExecOrder.Order.Item.UserCode,ExecOrder.Order.Item.SpellCode,
//								   ExecOrder.Order.Item.SysClass.ID.ToString(),ExecOrder.Order.Item.SysClass.Name,objAssets.Specs,objAssets.Price.ToString(),ExecOrder.Order.Usage.ID,
//								   ExecOrder.Order.Usage.Name,ExecOrder.Order.Usage.Memo,ExecOrder.Order.Frequency.ID,ExecOrder.Order.Frequency.Name,ExecOrder.Order.DoseOnce.ToString(),
//								   ExecOrder.Order.QTY.ToString(),ExecOrder.Order.Unit,ExecOrder.Order.Usetimes.ToString(),
//								   ExecOrder.Order.OrderType.ID,ExecOrder.Order.OrderType.Name,System.Convert.ToInt16(ExecOrder.Order.OrderType.IsDecompose).ToString(),System.Convert.ToInt16(ExecOrder.Order.OrderType.IsCharge).ToString(),
//								   System.Convert.ToInt16(ExecOrder.Order.OrderType.IsNeedPharmacy).ToString(),System.Convert.ToInt16(ExecOrder.Order.OrderType.IsPrint).ToString(),System.Convert.ToInt16(ExecOrder.Order.OrderType.IsConfirm).ToString(),
//								   ExecOrder.Order.ReciptDoct.ID,ExecOrder.ReciptDoct.Name,ExecOrder.DateUse.ToString(),ExecOrder.DcExecTime.ToString(),ExecOrder.Order.ReciptDept.ID,
//								   ExecOrder.Order.Date_MO.ToString(),ExecOrder.DcExecUser.ID,ExecOrder.ChargeUser.ID,ExecOrder.ReciptDept.ID,ExecOrder.ChargeTime.ToString(),
//								   ExecOrder.StockDept.ID,ExecOrder.ExeDept.ID,ExecOrder.ExecUser.ID,ExecOrder.ReciptDept.ID,ExecOrder.ExecTime.ToString(),
//								   ExecOrder.DateDeco.ToString(),ExecOrder.ExeDept.Name,
//								   System.Convert.ToInt16(ExecOrder.Order.IsBaby).ToString(),ExecOrder.Order.BabyNo.ToString(),ExecOrder.Order.Combo.ID,System.Convert.ToInt16(ExecOrder.Order.Combo.MainDrug).ToString(),
//								   System.Convert.ToInt16(ExecOrder.Order.IsSubtbl).ToString(),System.Convert.ToInt16(ExecOrder.Order.IsHaveSubtbl).ToString(),System.Convert.ToInt16(ExecOrder.IsInvalid).ToString(),System.Convert.ToInt16(ExecOrder.IsExec).ToString(),
//								   System.Convert.ToInt16(ExecOrder.IsCharge).ToString(),System.Convert.ToInt16(ExecOrder.Order.IsEmergency).ToString(),ExecOrder.Order.CheckPartRecord,ExecOrder.Order.Note,ExecOrder.Order.Memo};
//					strSql=string.Format(strSql,s);
//				}
//				catch(Exception ex)
//				{
//					this.Err="付数值时候出错！"+ex.Message;
//					this.WriteErr();
//					return -1;
//				}
//			}
//			#endregion
//		
//			if (strSql == null) return -1;
//			
//			return this.ExecNoQuery(strSql);
//		}
//		private string JudgeItemType(Object.Order.ExecOrder ExecOrder)
//		{
//			string strItem="";
//			//判断药品/非药品 
//			if (ExecOrder.Order.Item.GetType().ToString()== "Neusoft.HISFC.Object.Pharmacy.Item")
//			{
//				strItem="1";
//			}
//			else if (ExecOrder.Order.Item.GetType().ToString()== "Neusoft.HISFC.Object.Fee.Item")
//			{
//				strItem="2";
//			}
//			return strItem;
//		}
//		#region "更新执行档"
//		/// <summary>
//		/// 作废执行档
//		/// </summary>
//		/// <param name="ExecOrder">执行档信息</param>
//		/// <returns>0 success -1 fail</returns>
//		public int dcExec(Object.Order.ExecOrder ExecOrder)
//		{
//			#region 作废执行档
//			///作废执行档(医嘱停止或直接作废)
//			///Order.ExecOrder.dcExec
//			///传入：0 id，1 停止人id,2停止人姓名，3停止时间,4作废标志 
//			///传出：0 
//			#endregion
//			string strSql="",strSqlName="Order.ExecOrder.dcExec.";
//			string strItemType="";
//
//			strItemType=JudgeItemType(ExecOrder);
//			if (strItemType=="") return -1;
//			strSqlName= strSqlName + strItemType;
//
//			if(this.Sql.GetSql(strSqlName,ref strSql)==-1) return -1;
//			try
//			{
//				strSql=string.Format(strSql,ExecOrder.ID,ExecOrder.DcExecUser.ID,ExecOrder.DcExecUser.Name,ExecOrder.DcExecTime.ToString(),System.Convert.ToInt16(ExecOrder.IsInvalid).ToString());
//			}
//			catch
//			{
//				this.Err="传入参数不对"+strSqlName;
//				return -1;
//			}
//			return this.ExecNoQuery(strSql);
//		}
//		/// <summary>
//		/// 按医嘱流水号作废执行档
//		/// </summary>
//		/// <param name="OrderNo"></param>
//		/// <returns>0 success -1 fail</returns>
//		public int dcExec(string OrderNo,string ItemType,Neusoft.NFC.Object.NeuObject dcPerson)
//		{
//			#region 按医嘱流水号作废执行档
//			///作废执行档(医嘱停止或直接作废)
//			///Order.ExecOrder.dcOrderExec
//			///传入：0 orderid，1 停止人id,2停止人姓名，3停止时间,4作废标志 
//			///传出：0 
//			#endregion
//			string strSql="",strSqlName="Order.ExecOrder.dcOrderExec.";
//			
//			if (ItemType=="") return -1;
//			strSqlName= strSqlName + ItemType;
//
//			if(this.Sql.GetSql(strSqlName,ref strSql)==-1) return -1;
//			try
//			{
//				strSql=string.Format(strSql,OrderNo,dcPerson.ID,dcPerson.Name,this.GetSysDateTime(),"0");
//			}
//			catch
//			{
//				this.Err="传入参数不对"+strSqlName;
//				return -1;
//			}
//			return this.ExecNoQuery(strSql);
//		}
//		/// <summary>
//		/// 执行记录
//		/// </summary>
//		/// <param name="ExecOrder">执行档信息</param>
//		/// <returns>0 success -1 fail</returns>
//		public int RecordExec(Object.Order.ExecOrder ExecOrder)
//		{
//			#region 执行记录
//			///执行记录
//			///Order.ExecOrder.RecordExec.1
//			///传入：0 id，1 执行人id,2执行科室，3执行科室名称 4执行时间,5执行标志 
//			///传出：0 
//			#endregion
//			string strSql="",strSqlName="Order.ExecOrder.RecordExec.";
//			string strItemType="";
//
//			strItemType=JudgeItemType(ExecOrder);
//			if (strItemType=="") return -1;
//			strSqlName= strSqlName + strItemType;
//
//			if(this.Sql.GetSql(strSqlName,ref strSql)==-1) return -1;
//			try
//			{
//				strSql=string.Format(strSql,ExecOrder.ID,ExecOrder.DcExecUser.ID,ExecOrder.DcExecUser.Name,ExecOrder.DcExecTime.ToString(),System.Convert.ToInt16(ExecOrder.IsInvalid).ToString());
//			}
//			catch
//			{
//				this.Err="传入参数不对！"+strSqlName;
//				return -1;
//			}
//			return this.ExecNoQuery(strSql);
//		}
//		/// <summary>
//		/// 收费记录
//		/// </summary>
//		/// <param name="ExecOrder">执行档信息</param>
//		/// <returns>0 success -1 fail</returns>
//		public int ChargeExec(Object.Order.ExecOrder ExecOrder)
//		{
//			#region 收费记录
//			///收费记录
//			///Order.ExecOrder.Charge.
//			///传入：0 id，1 收费人id,2收费科室ID，3收费时间,5收费标志 
//			///传出：0 
//			#endregion
//			string strSql="",strSqlName="Order.ExecOrder.Charge.";
//			string strItemType="";
//
//			strItemType=JudgeItemType(ExecOrder);
//			if (strItemType=="") return -1;
//			strSqlName= strSqlName + strItemType;
//
//			if(this.Sql.GetSql(strSqlName,ref strSql)==-1) return -1;
//			try
//			{
//				strSql=string.Format(strSql,ExecOrder.ID,ExecOrder.ChargeUser.ID,ExecOrder.ChargeUser.Name,ExecOrder.ChargeTime.ToString(),System.Convert.ToInt16(ExecOrder.IsCharge).ToString());
//			}
//			catch
//			{
//				this.Err="传入参数不对！"+strSqlName;
//				return -1;
//			}
//			return this.ExecNoQuery(strSql);
//		}
//		/// <summary>
//		/// 配药记录
//		/// </summary>
//		/// <param name="ExecOrder">执行档信息</param>
//		/// <returns>0 success -1 fail</returns>
//		public int DrugExec(Object.Order.ExecOrder ExecOrder)
//		{
//			#region 配药记录
//			///配药记录
//			///Order.ExecOrder.DrugExec.
//			///传入：0 id，1 配药状态 
//			///传出：0 
//			#endregion
//			string strSql="";
//			string strItemType="";
//
//			strItemType=JudgeItemType(ExecOrder);
//			if (strItemType !="1") return -1;
//
//			if(this.Sql.GetSql("Order.ExecOrder.DrugExec.1",ref strSql)==-1) return -1;
//			try
//			{
//				strSql=string.Format(strSql,ExecOrder.ID,ExecOrder.DrugFlag.ToString());
//			}
//			catch
//			{
//				this.Err="传入参数不对！Order.ExecOrder.DrugExec.1";
//				return -1;
//			}
//			return this.ExecNoQuery(strSql);
//		}
//		#endregion 
//
//		#region "查询医嘱执行信息"
//		/// <summary>
//		/// 查询所有医嘱执行情况
//		/// </summary>
//		/// <param name="InPatientNo"></param>
//		/// <param name="ItemType">""全部，1药2非药</param>
//		/// <returns></returns>
//		public ArrayList QueryPatientExec(string InPatientNo,string ItemType)
//		{
//			#region 查询所有医嘱执行情况
//			///查询所有医嘱执行情况（药，非药）
//			///Order.ExecOrder.QueryPatientExec.1
//			///传入：0 inpatientno
//			///传出：ArrayList
//			#endregion
//			string[] s;
//			string sql="",sql1="";
//			ArrayList al=new ArrayList();
//			
//			s= ExecOrderQuerySelect(ItemType);
//			for (int i=0;i<2;i++)
//			{
//				sql= s[i];
//				if (sql==null ) return null;
//				if(this.Sql.GetSql("Order.ExecOrder.QueryPatientExec.1",ref sql1)==-1)
//				{
//					this.Err="没有找到Order.ExecOrder.QueryPatientExec.1字段!";
//					this.ErrCode="-1";
//					this.WriteErr();
//					return null;
//				}
//				sql= sql +" " +string.Format(sql1,InPatientNo);
//				addExecOrder(al,sql);
//			}
//			return al;
//		}
//		/// <summary>
//		/// 按查询是否有效执行医嘱
//		/// </summary>
//		/// <param name="InPatientNo"></param>
//		/// <param name="ItemType"></param>
//		/// <param name="IsValid"></param>
//		/// <returns></returns>
//		public ArrayList QueryValidOrder(string InPatientNo,string ItemType,bool IsValid)
//		{
//			#region 按查询有效执行医嘱
//			///按查询有效执行医嘱
//			///Order.ExecOrder.QueryValidOrder.1
//			///传入：0 inpatientno 1  IsValid
//			///传出：ArrayList
//			#endregion
//			string[] s;
//			string sql="",sql1="";
//			ArrayList al=new ArrayList();
//			
//			s= ExecOrderQuerySelect(ItemType);
//			for (int i=0;i<2;i++)
//			{
//				sql= s[i];
//				if (sql==null ) return null;
//				if(this.Sql.GetSql("Order.ExecOrder.QueryValidOrder.1",ref sql1)==-1)
//				{
//					this.Err="没有找到Order.ExecOrder.QueryValidOrder.1字段!";
//					this.ErrCode="-1";
//					this.WriteErr();
//					return null;
//				}
//				sql= sql +" " +string.Format(sql1,InPatientNo,System.Convert.ToInt16(IsValid).ToString());
//				addExecOrder(al,sql);
//			}
//			return al;
//		}
//		/// <summary>
//		/// 按查询是否执行医嘱
//		/// </summary>
//		/// <param name="InPatientNo"></param>
//		/// <param name="ItemType"></param>
//		/// <param name="IsExec"></param>
//		/// <returns></returns>
//		public ArrayList QueryExecOrder(string InPatientNo,string ItemType,bool IsExec)
//		{
//			#region 按查询是否执行医嘱
//			///按查询是否执行医嘱
//			///Order.ExecOrder.QueryExecOrder.1
//			///传入：0 inpatientno 1 IsExec
//			///传出：ArrayList
//			#endregion
//			string[] s;
//			string sql="",sql1="";
//			ArrayList al=new ArrayList();
//			
//			s= ExecOrderQuerySelect(ItemType);
//			for (int i=0;i<2;i++)
//			{
//				sql= s[i];
//				if (sql==null ) return null;
//				if(this.Sql.GetSql("Order.ExecOrder.QueryExecOrder.1",ref sql1)==-1)
//				{
//					this.Err="没有找到Order.ExecOrder.QueryExecOrder.1字段!";
//					this.ErrCode="-1";
//					this.WriteErr();
//					return null;
//				}
//				sql= sql +" " +string.Format(sql1,InPatientNo,System.Convert.ToInt16(IsExec).ToString());
//				addExecOrder(al,sql);
//			}
//			return al;
//		}
//		/// <summary>
//		/// 按查询是否收费医嘱
//		/// </summary>
//		/// <param name="InPatientNo"></param>
//		/// <param name="ItemType"></param>
//		/// <param name="IsCharge"></param>
//		/// <returns></returns>
//		public ArrayList QueryChargeOrder(string InPatientNo,string ItemType,bool IsCharge)
//		{
//			#region 按查询是否收费医嘱
//			///按查询是否收费医嘱
//			///Order.ExecOrder.QueryChargeOrder.1
//			///传入：0 inpatientno 1  IsCharge
//			///传出：ArrayList
//			#endregion
//			string[] s;
//			string sql="",sql1="";
//			ArrayList al=new ArrayList();
//			
//			s= ExecOrderQuerySelect(ItemType);
//			for (int i=0;i<2;i++)
//			{
//				sql= s[i];
//				if (sql==null ) return null;
//				if(this.Sql.GetSql("Order.ExecOrder.QueryChargeOrder.1",ref sql1)==-1)
//				{
//					this.Err="没有找到Order.ExecOrder.QueryChargeOrder.1字段!";
//					this.ErrCode="-1";
//					this.WriteErr();
//					return null;
//				}
//				sql= sql +" " +string.Format(sql1,InPatientNo,System.Convert.ToInt16(IsCharge).ToString());
//				addExecOrder(al,sql);
//			}
//			return al;
//		}
//		/// <summary>
//		/// 按查询配药状态医嘱
//		/// </summary>
//		/// <param name="InPatientNo"></param>
//		/// <param name="DrugFlag"></param>
//		/// <returns></returns>
//		public ArrayList QueryOrderDrugFlag(string InPatientNo,int DrugFlag)
//		{
//			#region 按查询配药状态医嘱
//			///按查询配药状态医嘱
//			///Order.ExecOrder.QueryOrderDrugFlag.1
//			///传入：0 inpatientno 1  DrugFlag
//			///传出：ArrayList
//			#endregion
//			string[] s;
//			string sql="",sql1="";
//			ArrayList al=new ArrayList();
//			
//			s= ExecOrderQuerySelect("1");
//			sql= s[1];
//			if (sql==null ) return null;
//			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderDrugFlag.1",ref sql1)==-1)
//			{
//				this.Err="没有找到Order.ExecOrder.QueryOrderDrugFlag.1字段!";
//				this.ErrCode="-1";
//				this.WriteErr();
//				return null;
//			}
//			sql= sql +" " +string.Format(sql1,InPatientNo,DrugFlag.ToString());
//			return this.myExecOrderQuery(sql);
//		}	
//		/// <summary>
//		/// 按医嘱流水号查询医嘱执行信息
//		/// </summary>
//		/// <param name="OrderNo"></param>
//		/// <param name="ItemType">1药2非药""全部</param>
//		/// <returns></returns>
//		public ArrayList QueryOneOrder(string OrderNo,string ItemType)
//		{
//			string[] s;
//			string sql="",sql1="";
//			ArrayList al=new ArrayList();
//			#region 按医嘱流水号查询医嘱执行信息
//			///按医嘱流水号查询医嘱执行信息
//			///Order.ExecOrder.QueryOrder.where.5
//			///传入：0 OrderNo
//			///传出：ArrayList
//			#endregion
//			s= ExecOrderQuerySelect(ItemType);
//			for (int i=0;i<2;i++)
//			{
//				sql= s[i];
//				if (sql==null ) return null;
//				if(this.Sql.GetSql("Order.ExecOrder.Query.where.5",ref sql1)==-1)
//				{
//					this.Err="没有找到Order.ExecOrder.Query.where.5字段!";
//					this.ErrCode="-1";
//					this.WriteErr();
//					return null;
//				}
//				sql= sql +" " +string.Format(sql1,OrderNo);
//				addExecOrder(al,sql);
//			}
//			return al;
//		}
//		//添加查询信息
//		private void addExecOrder(ArrayList al,string sqlOrder)
//		{
//			ArrayList al1=null;
//			try
//			{
//				al1=this.myExecOrderQuery(sqlOrder);;
//			}
//			catch(Exception ex)
//			{
//				this.Err = ex.Message;
//			}
//			foreach(Object.Order.ExecOrder ExecOrder in al1)
//			{
//				al.Add(ExecOrder);
//			}
//		}
//		/// 查询患者信息的select语句（无where条件）
//		private string[] ExecOrderQuerySelect(string Type)
//		{
//			#region 接口说明
//			///Order.ExecOrder.QueryOrder.Select.1
//			///传入：0
//			///传出：sql.select
//			#endregion
//			string[] s=null;
//			string sql="";
//			if (Type=="1" || Type =="")
//			{
//				if(this.Sql.GetSql("Order.ExecOrder.QueryOrder.Select.1",ref sql)==-1)
//				{
//					this.Err="没有找到Order.ExecOrder.QueryOrder.Select.1字段!";
//					this.ErrCode="-1";
//					this.WriteErr();
//					return null;
//				}
//				s[1]=sql;
//			}
//			else if (Type=="2" || Type =="")
//			{
//				if(this.Sql.GetSql("Order.ExecOrder.QueryOrder.Select.2",ref sql)==-1)
//				{
//					this.Err="没有找到Order.ExecOrder.QueryOrder.Select.2字段!";
//					this.ErrCode="-1";
//					this.WriteErr();
//					return null;
//				}
//				s[2]=sql;
//			}
//			
//			return s;
//		}
//		//私有函数，查询医嘱信息
//		private ArrayList myExecOrderQuery(string SQLPatient)
//		{
//			
//			ArrayList al=new ArrayList();
//
//			this.ExecQuery(SQLPatient);
//			try
//			{
//				while (this.Reader.Read())
//				{
//					Object.Order.ExecOrder objOrder = new Neusoft.HISFC.Object.Order.ExecOrder();
//					    
//					#region "患者信息"
//					//患者信息——  
//					//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
//					try
//					{
//						objOrder.Order.Patient.ID =this.Reader[1].ToString();
//						objOrder.Order.Patient.Patient.PID.PatientNo = this.Reader[2].ToString(); 
//						objOrder.Order.Patient.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString(); 
//						objOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID = this.Reader[4].ToString(); 
//						objOrder.NurseStation.ID = this.Reader[4].ToString();
//						objOrder.InDept.ID=this.Reader[3].ToString();
//
//					}
//					catch(Exception ex)
//					{
//						this.Err="获得患者基本信息出错！"+ex.Message;
//						this.WriteErr();
//						return null;
//					}
//					#endregion
//					  
//					if (this.Reader[5].ToString() == "1")
//					{
//						Neusoft.HISFC.Object.Pharmacy.Item objPharmacy= new Neusoft.HISFC.Object.Pharmacy.Item();
//						try
//						{
//							#region "项目信息"
//							//医嘱辅助信息
//							// ——项目信息
//							//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
//							//	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
//							//         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
//							//         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
//							//         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			
//							objPharmacy.ID = this.Reader[6].ToString();
//							objPharmacy.Name = this.Reader[7].ToString();
//							objPharmacy.UserCode = this.Reader[8].ToString();
//							objPharmacy.SpellCode = this.Reader[9].ToString();
//							objPharmacy.SysClass.ID = this.Reader[10].ToString();
//							//objPharmacy.SysClass.Name = this.Reader[11].ToString();
//							objPharmacy.Specs     = this.Reader[12].ToString();
//							try{
//							objPharmacy.BaseDose  = decimal.Parse(this.Reader[13].ToString());}
//							catch{}
//							objPharmacy.DoseUnit = this.Reader[14].ToString();
//							objPharmacy.MinUnit = this.Reader[15].ToString();
//							try{
//							objPharmacy.PackQty = decimal.Parse(this.Reader[16].ToString());}
//							catch{}
//							objPharmacy.DosageForm.ID = this.Reader[17].ToString();
//							objPharmacy.Type.ID    = this.Reader[18].ToString();
//							objPharmacy.Quality.ID = this.Reader[19].ToString();
//							try{
//							objPharmacy.RetailPrice= decimal.Parse(this.Reader[20].ToString());}
//							catch{}		
//							#endregion
//
//							objOrder.Order.Usage.ID  =this.Reader[21].ToString();
//							objOrder.Order.Usage.Name=this.Reader[22].ToString();
//							objOrder.Order.Usage.Memo=this.Reader[23].ToString();
//							objOrder.Order.Frequency.ID  =this.Reader[24].ToString();
//							objOrder.Order.Frequency.Name=this.Reader[25].ToString();
//							try
//							{
//								objOrder.Order.DoseOnce=decimal.Parse(this.Reader[26].ToString());}
//							catch{}
//							try
//							{
//								objOrder.Order.QTY =decimal.Parse(this.Reader[27].ToString());}
//							catch{}
//							objOrder.Order.Unit=this.Reader[28].ToString();
//							try
//							{
//								objOrder.Order.Usetimes=int.Parse(this.Reader[29].ToString());}
//							catch{}
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱项目信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						objOrder.Order.Item = objPharmacy;
//
//						#region "医嘱属性"
//						// ——医嘱属性
//						//		   30医嘱类别代码 31医嘱流水号  32医嘱是否分解:1长期/2临时     33是否计费 
//						//		   34药房是否配药 35打印执行单    36是否需要确认  
//						try
//						{
//							objOrder.ID = this.Reader[0].ToString();
//							objOrder.Order.OrderType.ID = this.Reader[30].ToString();
//							objOrder.Order.OrderType.Name = this.Reader[31].ToString();
//							try
//							{
//								objOrder.Order.OrderType.IsDecompose = System.Convert.ToBoolean(int.Parse(this.Reader[32].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsCharge = System.Convert.ToBoolean(int.Parse(this.Reader[33].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsNeedPharmacy = System.Convert.ToBoolean(int.Parse(this.Reader[34].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsPrint = System.Convert.ToBoolean(int.Parse(this.Reader[35].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsConfirm = System.Convert.ToBoolean(int.Parse(this.Reader[36].ToString()));}
//							catch{}
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱属性信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						#endregion
//						#region "执行情况"
//						// ——执行情况
//						//		   37开立医师Id   38开立医师name  39要求执行时间  40作废时间     41开立科室
//						//		   42开立时间     43作废人代码    44记账人代码    45记账科室代码 46记账时间       
//						//		   47取药药房     48执行科室      49执行护士代码  50执行科室代码 51执行时间
//						//         52分解时间
//						try
//						{						  
//							objOrder.ReciptDoct.ID = this.Reader[37].ToString();
//							objOrder.ReciptDoct.Name = this.Reader[38].ToString();
//							try{objOrder.DateUse = DateTime.Parse(this.Reader[39].ToString());}
//							catch{}
//							try{objOrder.DcExecTime = DateTime.Parse(this.Reader[40].ToString());}
//							catch{}
//							objOrder.Order.ReciptDept.ID = this.Reader[41].ToString();
//							try{objOrder.Order.Date_MO = DateTime.Parse(this.Reader[42].ToString());}
//							catch{}
//							objOrder.DcExecUser.ID = this.Reader[43].ToString();
//							objOrder.ChargeUser.ID = this.Reader[44].ToString();
//							objOrder.ReciptDept.ID = this.Reader[45].ToString();
//							try{objOrder.ChargeTime = DateTime.Parse(this.Reader[46].ToString());}
//							catch{}
//							objOrder.StockDept.ID = this.Reader[47].ToString();
//							objOrder.ExeDept.ID = this.Reader[48].ToString();
//							objOrder.ExecUser.ID = this.Reader[49].ToString();
//							objOrder.ExeDept.ID = this.Reader[50].ToString();
//							try{objOrder.ExecTime = DateTime.Parse(this.Reader[51].ToString());}
//							catch{}
//							objOrder.DateDeco = DateTime.Parse(this.Reader[52].ToString());
//						
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱执行情况信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						#endregion
//						#region "医嘱类型"
//						// ——医嘱类型
//						//		   52是否婴儿（1是/2否）          53发生序号  	  54组合序号     55主药标记 
//						//		   56是否包含附材                 57是否有效      58扣库标记     59是否执行 
//						//		   60配药标记                     61收费标记      62医嘱说明     63备注 
//						try
//						{
//							try{objOrder.Order.IsBaby = System.Convert.ToBoolean(int.Parse(this.Reader[52].ToString()));}
//							catch{}
//							try{objOrder.Order.BabyNo = this.Reader[53].ToString();}
//							catch{}
//							objOrder.Order.Combo.ID = this.Reader[54].ToString();
//							try{objOrder.Order.Combo.MainDrug = System.Convert.ToBoolean(int.Parse(this.Reader[55].ToString()));}
//							catch{}
//							try{objOrder.Order.IsHaveSubtbl = System.Convert.ToBoolean(int.Parse(this.Reader[56].ToString()));}
//							catch{}
//							try{objOrder.IsInvalid = System.Convert.ToBoolean(this.Reader[57].ToString());}
//							catch{}
//							try{objOrder.Order.IsStock = System.Convert.ToBoolean(int.Parse(this.Reader[58].ToString()));}
//							catch{}
//							try{objOrder.IsExec = System.Convert.ToBoolean(this.Reader[59].ToString());}
//							catch{}
//							try{objOrder.DrugFlag = int.Parse(this.Reader[60].ToString());}
//							catch{}
//							try{objOrder.IsCharge = System.Convert.ToBoolean(this.Reader[61].ToString());}
//							catch{}
//							objOrder.Order.Note = this.Reader[62].ToString();
//							objOrder.Order.Memo = this.Reader[63].ToString();
//
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱类型信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						#endregion
//					} 	
//					else if (this.Reader[5].ToString() == "2")
//					{
//						Neusoft.HISFC.Object.Fee.Item objAssets=new Neusoft.HISFC.Object.Fee.Item();
//						try
//						{
//							#region "项目信息"
//							// ——项目信息
//							//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
//							//	       10项目类别代码 11项目类别名称  12规格         13零售价        14用法代码   
//							//         15用法名称     16用法英文缩写  17频次代码     18频次名称      19每次用量
//							//         20项目总量     21计价单位      22使用次数	
//							objAssets.ID = this.Reader[6].ToString();
//							objAssets.Name = this.Reader[7].ToString();
//							objAssets.UserCode = this.Reader[8].ToString();
//							objAssets.SpellCode = this.Reader[9].ToString();
//							objAssets.SysClass.ID = this.Reader[10].ToString();
//							//objAssets.SysClass.Name = this.Reader[11].ToString();
//							objAssets.Specs     = this.Reader[12].ToString();
//							try{
//							objAssets.Price= decimal.Parse(this.Reader[13].ToString());}
//							catch{}	
//							objAssets.PriceUnit = this.Reader[21].ToString();
//							#endregion
//
//							objOrder.Order.Usage.ID  =this.Reader[14].ToString();
//							objOrder.Order.Usage.Name=this.Reader[15].ToString();
//							objOrder.Order.Usage.Memo=this.Reader[16].ToString();
//							objOrder.Order.Frequency.ID  =this.Reader[17].ToString();
//							objOrder.Order.Frequency.Name=this.Reader[18].ToString();
//							try
//							{
//								objOrder.Order.DoseOnce=decimal.Parse(this.Reader[19].ToString());}
//							catch{}
//							try
//							{
//								objOrder.Order.QTY =decimal.Parse(this.Reader[20].ToString());}
//							catch{}
//							objOrder.Order.Unit=this.Reader[21].ToString();
//							try
//							{
//								objOrder.Order.Usetimes=int.Parse(this.Reader[22].ToString());}
//							catch{}
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱项目信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						objOrder.Order.Item = objAssets;	
//						#region "医嘱属性"
//						// ——医嘱属性
//						//		   23医嘱类别代码 24医嘱流水号    25医嘱是否分解:1长期/2临时     26是否计费 
//						//		   27药房是否配药 28打印执行单    29是否需要确认    
//						try
//						{
//							objOrder.Order.ID = this.Reader[0].ToString();
//							objOrder.Order.OrderType.ID = this.Reader[23].ToString();
//							objOrder.Order.OrderType.Name = this.Reader[24].ToString();
//							try
//							{
//								objOrder.Order.OrderType.IsDecompose = System.Convert.ToBoolean(int.Parse(this.Reader[25].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsCharge = System.Convert.ToBoolean(int.Parse(this.Reader[26].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsNeedPharmacy = System.Convert.ToBoolean(int.Parse(this.Reader[27].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsPrint = System.Convert.ToBoolean(int.Parse(this.Reader[28].ToString()));}
//							catch{}
//							try
//							{
//								objOrder.Order.OrderType.IsConfirm = System.Convert.ToBoolean(int.Parse(this.Reader[29].ToString()));}
//							catch{}
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱属性信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						#endregion
//						#region "执行情况"
//						// ——执行情况
//						//		   30开立医师Id   31开立医师name  32要求执行时间  33作废时间     34开立科室
//						//		   35开立时间     36作废人代码    37记账人代码    38记账科室代码 39记账时间       
//						//		   40取药药房     41执行科室      42执行护士代码  43执行科室代码 44执行时间
//						//         45分解时间     46执行科室名称
//						try
//						{						  
//							objOrder.ReciptDoct.ID = this.Reader[30].ToString();
//							objOrder.ReciptDoct.Name = this.Reader[31].ToString();
//							try{objOrder.DateUse = DateTime.Parse(this.Reader[32].ToString());}
//							catch{}
//							try{objOrder.DcExecTime = DateTime.Parse(this.Reader[33].ToString());}
//							catch{}
//							objOrder.Order.ReciptDept.ID = this.Reader[34].ToString();
//							try{objOrder.Order.Date_MO = DateTime.Parse(this.Reader[35].ToString());}
//							catch{}
//							objOrder.DcExecUser.ID = this.Reader[36].ToString();
//							objOrder.ChargeUser.ID = this.Reader[37].ToString();
//							objOrder.ReciptDept.ID = this.Reader[38].ToString();
//							try{objOrder.ChargeTime = DateTime.Parse(this.Reader[39].ToString());}
//							catch{}
//							objOrder.StockDept.ID = this.Reader[40].ToString();
//							objOrder.ExeDept.ID = this.Reader[41].ToString();
//							objOrder.ExecUser.ID = this.Reader[42].ToString();
//							objOrder.ExeDept.ID = this.Reader[43].ToString();
//							try{objOrder.ExecTime = DateTime.Parse(this.Reader[44].ToString());}
//							catch{}
//							objOrder.DateDeco = DateTime.Parse(this.Reader[45].ToString());
//							objOrder.ExeDept.Name = this.Reader[46].ToString();
//						
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱执行情况信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						#endregion
//						#region "医嘱类型"
//						// ——医嘱类型
//						//		   47是否婴儿（1是/2否）          48发生序号  	  49组合序号     50主项标记 
//						//		   51是否附材                     52是否包含附材  53是否有效     54是否执行 
//						//		   55收费标记     56加急标记      57检查部位检体  58医嘱说明     59备注  
//						try
//						{
//							try{objOrder.Order.IsBaby = System.Convert.ToBoolean(int.Parse(this.Reader[47].ToString()));}
//							catch{}
//							try{objOrder.Order.BabyNo = this.Reader[48].ToString();}
//							catch{}
//							objOrder.Order.Combo.ID = this.Reader[49].ToString();
//							try{objOrder.Order.Combo.MainDrug = System.Convert.ToBoolean(int.Parse(this.Reader[50].ToString()));}
//							catch{}
//							try{objOrder.Order.IsSubtbl = System.Convert.ToBoolean(int.Parse(this.Reader[51].ToString()));}
//							catch{}
//							try{objOrder.Order.IsHaveSubtbl = System.Convert.ToBoolean(int.Parse(this.Reader[52].ToString()));}
//							catch{}
//							try{objOrder.IsInvalid = System.Convert.ToBoolean(this.Reader[53].ToString());}
//							catch{}
//							try{objOrder.IsExec = System.Convert.ToBoolean(this.Reader[54].ToString());}
//							catch{}
//							try{objOrder.IsCharge = System.Convert.ToBoolean(this.Reader[55].ToString());}
//							catch{}
//							try{objOrder.Order.IsEmergency = System.Convert.ToBoolean(int.Parse(this.Reader[56].ToString()));}
//							catch{}
//							objOrder.Order.CheckPartRecord = this.Reader[57].ToString();
//
//							objOrder.Order.Note = this.Reader[58].ToString();
//							objOrder.Order.Memo = this.Reader[59].ToString();
//
//						}
//						catch(Exception ex)
//						{
//							this.Err="获得医嘱类型信息出错！"+ex.Message;
//							this.WriteErr();
//							return null;
//						}
//						#endregion
//					}
//					al.Add(objOrder);
//				}
//			}
//			catch(Exception ex)
//			{
//				this.Err="获得医嘱信息出错！"+ex.Message;
//				this.ErrCode="-1";
//				this.WriteErr();
//				return null;
//			}
//			this.Reader.Close();
//			return al;
//		}
//		#endregion 
//		
//		
//		/// <summary>
//		/// 判断录入数据的合法性
//		/// </summary>
//		/// <param name="Order"></param>
//		/// <returns></returns>
//		private int CheckOrder(Object.Order.Order Order)
//		{
//
//			//判断药品/非药品
//			if (Order.Item.GetType().ToString()== "Neusoft.HISFC.Object.Pharmacy.Item")
//			{
//				Neusoft.HISFC.Object.Pharmacy.Item objPharmacy ;
//				objPharmacy = (Neusoft.HISFC.Object.Pharmacy.Item)Order.Item;
//
//			}
//			else if (Order.Item.GetType().ToString()== "Neusoft.HISFC.Object.Fee.Item")
//			{
//				Neusoft.HISFC.Object.Fee.Item objAssets;
//				objAssets = (Neusoft.HISFC.Object.Fee.Item)Order.Item;
//			}
//			return 0;
//		}

	}
}
