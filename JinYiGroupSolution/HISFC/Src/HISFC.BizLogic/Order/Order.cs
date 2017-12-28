using System;
using Neusoft.HISFC.Models;
using System.Collections;
using Neusoft.FrameWork.Models;
using System.Data;
namespace Neusoft.HISFC.BizLogic.Order
{
	/// <summary>
	/// 医嘱管理类。
    /// 
    /// <说明>
    ///     1 2007-04 增加配液中心处理
    ///         执行挡插入函数增加参数是否需配液
    ///     2 增加查询、更新函数
    /// </说明>
	/// </summary>
	public class Order:Neusoft.FrameWork.Management.Database 
	{
		public Order()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region 静态量

        /// <summary>
        /// 需配液用法
        /// </summary>
        private static System.Collections.Hashtable hsCompoundUsage = null;

        #endregion

        #region 作废
        /// <summary>
		/// 
		/// </summary>
        /// <param name="order"></param>
		/// <returns></returns>
		[Obsolete("用InsertOrder代替！",true)]
		public int CreateOrder(Neusoft.HISFC.Models.Order.Inpatient.Order  order)
		{
			return this.InsertOrder(order);
		}


		[Obsolete("QueryOrderSubtbl代替了",true)]
		public ArrayList QueryOrderSub(string InPatientNo)
		{
			return this.QueryOrderSubtbl(InPatientNo);
		}
        [Obsolete("用InsertExecOrder代替了",true)]
        public int CreateExec(Neusoft.HISFC.Models.Order.ExecOrder ExecOrder)
		{
			return this.InsertExecOrder(ExecOrder);
		}

		[Obsolete("UpdateRecordExec代替",true)]
        public int RecordExec(Neusoft.HISFC.Models.Order.ExecOrder ExecOrder)
		{
			return this.UpdateRecordExec(ExecOrder);
		}
		
		[Obsolete("用UpdateChargeExec代替",true)]
        public int ChargeExec(Neusoft.HISFC.Models.Order.ExecOrder ExecOrder)
		{
			return UpdateChargeExec(ExecOrder);
		}
		[Obsolete("UpdateDrugExec代替",true)]
        public int DrugExec(Neusoft.HISFC.Models.Order.ExecOrder ExecOrder)
		{
			return this.UpdateDrugExec(ExecOrder);
		}

        [Obsolete("QueryExecOrder(inpatientNo,itemType);代替",true)]
		public ArrayList QueryPatientExec(string inpatientNo,string itemType)
		{
			return this.QueryExecOrder(inpatientNo,itemType);
		}
		[Obsolete("用QueryExecOrder(InPatientNo,ItemType,IsValid)代替",true)]
		public ArrayList QueryValidOrder(string InPatientNo,string ItemType,bool IsValid)
		{
			return this.QueryExecOrder(InPatientNo,ItemType,IsValid);
		}
		[Obsolete("QueryExecOrder(inpatientNo,itemType,isCharge)代替",true)]
		public ArrayList QueryChargeOrder(string inpatientNo,string itemType,bool isCharge)
		{
			return QueryExecOrder(inpatientNo,itemType,isCharge);
		}
		[Obsolete("QueryExecOrderByDrugFlag(InPatientNo,DateTimeBegin,DateTimeEnd,  DrugFlag)代替",true)]
		public ArrayList QueryOrderDrugFlag(string InPatientNo,DateTime DateTimeBegin,DateTime DateTimeEnd, int DrugFlag)
		{
			return this.QueryExecOrderByDrugFlag(InPatientNo,DateTimeBegin,DateTimeEnd,  DrugFlag);
		}
		[Obsolete("QueryExecOrderByDrugFlag(InPatientNo,DrugFlag)代替",true)]
		public ArrayList QueryOrderDrugFlag(string InPatientNo,int DrugFlag)
		{
			return this.QueryExecOrderByDrugFlag(InPatientNo,DrugFlag);
		}
		#endregion

		#region 增删改
		
		/// <summary>
		/// 开立新医嘱(插入新医嘱记录)
		/// </summary>
		/// <param name="order"></param>
		/// <returns>0 success -1 fail</returns>
        public int InsertOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order)
		{
			#region 开立新医嘱
			//开立新医嘱
			//Order.Order.CreateOrder.1
			//传入：71
			//			//传出：0 
			#endregion

			string strSql = "";

			if(this.Sql.GetSql("Order.Order.CreateOrder.1",ref strSql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			strSql = getOrderInfo(strSql, order);
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}
		

		/// <summary>
		/// 更新医嘱
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
        public int UpdateOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order)
		{
			#region 更新医嘱
			//更新医嘱
			//Order.Order.CreateOrder.1
			//传入：71
			//传出：0 
			#endregion
			string strSql="";

			if(this.Sql.GetSql("Order.Order.updateOrder.1",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			strSql = getOrderInfo(strSql, order);
			if (strSql == null) return -1;
			return this.ExecNoQuery(strSql);
		}

		
		/// <summary>
		/// 删除医嘱
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
        public int DeleteOrder(Neusoft.HISFC.Models.Order.Order order)
		{
		
			#region 删除医嘱
			//删除医嘱(医嘱未生效状态)
			//Order.Order.delOrder.1
			//传入：0 id
			//传出：0 
			#endregion
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.delOrder.1",ref strSql)==-1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,order.ID);
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.delOrder.1";
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 建立执行档(插入执行档记录)
		/// </summary>
		/// <param name="execOrder"></param>
		/// <returns>0 success -1 fail</returns>
        public int InsertExecOrder(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
		{
			#region insert执行档
			//插入执行档
			//Order.ExecOrder.CreateExec.1
			//传入：71
			//传出：0 
			#endregion
			string strSql = "";
			string strItemType = "";

			strItemType = JudgeItemType(execOrder.Order);
			if (strItemType == "") return -1;

			#region "药嘱执行档"
			if (strItemType == "1")
			{
				Neusoft.HISFC.Models.Pharmacy.Item objPharmacy ;
				objPharmacy = (Neusoft.HISFC.Models.Pharmacy.Item)execOrder.Order.Item;

				if(this.Sql.GetSql("Order.ExecOrder.CreateExec.Drug.1",ref strSql) == -1) return -1;

                #region 配液判断  愁啊愁 不想引用Manager

                if (execOrder.Order.OrderType.IsDecompose)      //对需要分解的医嘱进行如下处理
                {
                    if (Order.hsCompoundUsage == null)
                    {
                        Order.hsCompoundUsage = new Hashtable();

                        Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
                        consManager.SetTrans(this.Trans);

                        ArrayList alList = consManager.GetList("CompoundUsage");
                        if (alList == null)             //不进行错误返回
                        {
                            Order.hsCompoundUsage = new Hashtable();
                        }
                        foreach (Neusoft.HISFC.Models.Base.Const cons in alList)
                        {
                            Order.hsCompoundUsage.Add(cons.ID, null);
                        }
                    }

                    if (Order.hsCompoundUsage.ContainsKey(execOrder.Order.Usage.ID))
                    {
                        execOrder.Order.Compound.IsNeedCompound = true;
                    }
                }

                #endregion

                #region "药嘱接口说明"
                //0 ID执行流水号
				//患者信息——  
				//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
				//医嘱辅助信息
				// ——项目信息
				//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
				//	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
				//         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
				//         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
				//         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
				// ——医嘱属性
				//		   30医嘱类别代码 31医嘱流水号  32医嘱是否分解:1长期/2临时     33是否计费 
				//		   34药房是否配药 35打印执行单    36是否需要确认  
				// ——执行情况
				//		   37开立医师Id   38开立医师name  39要求执行时间  40作废时间     41开立科室
				//		   42开立时间     43作废人代码    44记账人代码    45记账科室代码 46记账时间       
				//		   47取药药房     48执行科室      49执行护士代码  50执行科室代码 51执行时间
				//         52分解时间 
				// ——医嘱类型
				//		   64是否婴儿（1是/2否）          53发生序号  	  54组合序号     55主药标记 
				//		   56是否包含附材                 57是否有效      58扣库标记     59是否执行 
				//		   60配药标记                     61收费标记      62医嘱说明     63备注 
				//         65处方号                       66处方流水序号
                // ——配液信息
                //        67是否需配液                  
				#endregion 
				try
				{
					string[] s={execOrder.ID,execOrder.Order.Patient.ID,execOrder.Order.Patient.PID.PatientNO,execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID,execOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID,
								   strItemType,execOrder.Order.Item.ID,execOrder.Order.Item.Name,execOrder.Order.Item.UserCode,execOrder.Order.Item.SpellCode,
								   execOrder.Order.Item.SysClass.ID.ToString(),execOrder.Order.Item.SysClass.Name,objPharmacy.Specs,objPharmacy.BaseDose.ToString(),objPharmacy.DoseUnit,objPharmacy.MinUnit,objPharmacy.PackQty.ToString(),
								   objPharmacy.DosageForm.ID,objPharmacy.Type.ID,objPharmacy.Quality.ID.ToString(),objPharmacy.PriceCollection.RetailPrice.ToString(),
								   execOrder.Order.Usage.ID,execOrder.Order.Usage.Name,execOrder.Order.Usage.Memo,execOrder.Order.Frequency.ID,execOrder.Order.Frequency.Name,
								   execOrder.Order.DoseOnce.ToString(),execOrder.Order.Qty.ToString(),execOrder.Order.Unit,execOrder.Order.HerbalQty.ToString(),
								   execOrder.Order.OrderType.ID,execOrder.Order.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsDecompose).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsCharge).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsNeedPharmacy).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsPrint).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsConfirm).ToString(),
								   execOrder.Order.ReciptDoctor.ID,execOrder.Order.ReciptDoctor.Name,execOrder.DateUse.ToString(),execOrder.DCExecOper.OperTime.ToString(),execOrder.Order.ReciptDept.ID,
								   execOrder.Order.BeginTime.ToString(),execOrder.DCExecOper.ID,execOrder.ChargeOper.ID,execOrder.ChargeOper.Dept.ID,execOrder.ChargeOper.OperTime.ToString(),
								   execOrder.Order.StockDept.ID,execOrder.Order.ExeDept.ID,execOrder.Order.ExecOper.ID,execOrder.ExecOper.Dept.ID,execOrder.ExecOper.OperTime.ToString(),
								   execOrder.DateDeco.ToString(),
								   execOrder.Order.BabyNO.ToString(),execOrder.Order.Combo.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.Combo.IsMainDrug).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.IsHaveSubtbl).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsValid).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.IsStock).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsExec).ToString(),
								   execOrder.DrugFlag.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsCharge).ToString(),execOrder.Order.Note,execOrder.Order.Memo,Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.IsBaby).ToString(),
								   execOrder.Order.ReciptNO,execOrder.Order.SequenceNO.ToString(),
                                   Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.Compound.IsNeedCompound).ToString() };
					strSql=string.Format(strSql,s);
				}
				catch(Exception ex)
				{
					this.Err="付数值时候出错！"+ex.Message;
					this.WriteErr();
					return -1;
				}
			}			
				#endregion
				#region "非药嘱执行档"
			else if (strItemType== "2")
			{
				Neusoft.HISFC.Models.Fee.Item.Undrug objAssets;
				objAssets = (Neusoft.HISFC.Models.Fee.Item.Undrug)execOrder.Order.Item;

				if(this.Sql.GetSql("Order.ExecOrder.CreateExec.Undrug.1",ref strSql)==-1) return -1;	
				#region "非药嘱接口说明"
				//0 ID执行流水号
				//患者信息——  
				//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
				//医嘱辅助信息
				// ——项目信息
				//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
				//	       10项目类别代码 11项目类别名称  12规格         13零售价        14用法代码   
				//         15用法名称     16用法英文缩写  17频次代码     18频次名称      19每次用量
				//         20项目总量     21计价单位      22使用次数			  
				// ——医嘱属性
				//		   23医嘱类别代码 24医嘱流水号    25医嘱是否分解:1长期/2临时     26是否计费 
				//		   27药房是否配药 28打印执行单    29是否需要确认  
				// ——执行情况
				//		   30开立医师Id   31开立医师name  32要求执行时间  33作废时间     34开立科室
				//		   35开立时间     36作废人代码    37记账人代码    38记账科室代码 39记账时间       
				//		   40取药药房     41执行科室      42执行护士代码  43执行科室代码 44执行时间
				//       45分解时间     46执行科室名称
				// ——医嘱类型
				//		   47是否婴儿（1是/2否）          48发生序号  	  49组合序号     50主项标记 
				//		   51是否附材                     52是否包含附材  53是否有效     54是否执行 
				//		   55收费标记     56加急标记      57检查部位检体  58医嘱说明     59备注 
				//         60处方号       61处方流水序号
				#endregion 
				try
				{
					string[] s={execOrder.ID,execOrder.Order.Patient.ID,execOrder.Order.Patient.PID.PatientNO,execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID,execOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID,
								   strItemType,execOrder.Order.Item.ID,execOrder.Order.Item.Name,execOrder.Order.Item.UserCode,execOrder.Order.Item.SpellCode,
								   execOrder.Order.Item.SysClass.ID.ToString(),execOrder.Order.Item.SysClass.Name,objAssets.Specs,objAssets.Price.ToString(),execOrder.Order.Usage.ID,
								   execOrder.Order.Usage.Name,execOrder.Order.Usage.Memo,execOrder.Order.Frequency.ID,execOrder.Order.Frequency.Name,execOrder.Order.DoseOnce.ToString(),
								   execOrder.Order.Qty.ToString(),execOrder.Order.Unit,execOrder.Order.HerbalQty.ToString(),
								   execOrder.Order.OrderType.ID,execOrder.Order.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsDecompose).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsCharge).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsNeedPharmacy).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsPrint).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.OrderType.IsConfirm).ToString(),
								   execOrder.Order.ReciptDoctor.ID,execOrder.Order.ReciptDoctor.Name,execOrder.DateUse.ToString(),execOrder.DCExecOper.OperTime.ToString(),execOrder.Order.ReciptDept.ID,
								   execOrder.Order.BeginTime.ToString(),execOrder.DCExecOper.ID,execOrder.ChargeOper.ID,execOrder.ChargeOper.Dept.ID,execOrder.ChargeOper.OperTime.ToString(),
								   execOrder.Order.StockDept.ID,execOrder.Order.ExeDept.ID,execOrder.ExecOper.ID,execOrder.ExecOper.Dept.ID,execOrder.ExecOper.OperTime.ToString(),
								   execOrder.DateDeco.ToString(),execOrder.Order.ExeDept.Name,
								   Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.IsBaby).ToString(),execOrder.Order.BabyNO.ToString(),execOrder.Order.Combo.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.Combo.IsMainDrug).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.IsSubtbl).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.IsHaveSubtbl).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsValid).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsExec).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsCharge).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.Order.IsEmergency).ToString(),execOrder.Order.CheckPartRecord,execOrder.Order.Note,execOrder.Order.Memo,
								   execOrder.Order.ReciptNO,execOrder.Order.SequenceNO.ToString(),execOrder.Order.Sample.Name,execOrder.IsConfirm?"1":"0"/*确认标记{DA77B01B-63DF-4559-B264-798E54F24ABB}*/};
					strSql=string.Format(strSql,s);
				}
				catch(Exception ex)
				{
					this.Err="付数值时候出错！"+ex.Message;
					this.WriteErr();
					return -1;
				}
			}
			#endregion
		
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}

		#endregion

		#region "医嘱处理"
		
		#region 医嘱操作
		
		/// <summary>
		/// 保存医嘱 -根据Order.ID =="" or =="-1" 是新的 插入，其他的更新
		/// 设置医嘱
		/// </summary>
		/// <param name="Order"></param>
		/// <returns></returns>
        public int SetOrder(Neusoft.HISFC.Models.Order.Inpatient.Order Order)
		{
			if(Order.ID =="" || Order.ID =="-1")
			{
				string s = this.GetNewOrderID();
				if(s == null || s == "-1") return -1;
				Order.ID = s;
				return this.InsertOrder(Order);
			}
			else
			{
				return this.UpdateOrder(Order);
			}
		}
		
		/// <summary>
		/// 停止医嘱
		/// Order.Status = 1预停止;Order.Status = 3直接停止
		/// </summary>
		/// <param name="Order">医嘱信息</param>
		/// <returns>0 success -1 fail</returns>
        public int DcOneOrder(Neusoft.HISFC.Models.Order.Order Order)
		{
			#region 停止医嘱
			//停止医嘱(医嘱已生效状态)
			//Order.Order.dcOrder.1
			//传入：0 id，1 停止人id,2停止人姓名，3停止时间,4医嘱状态 ,5停止原因代码，6停止原因名称 
			//传出：0 
			#endregion
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.dcOrder.1",ref strSql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				if(Order.EndTime == DateTime.MinValue)//判断停止时间
					Order.EndTime = this.GetDateTimeFromSysDateTime();

				strSql=string.Format(strSql,Order.ID,Order.DCOper.ID,Order.DCOper.Name,Order.EndTime.ToString(),Order.Status.ToString(),Order.DcReason.ID,Order.DcReason.Name);
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.dcOrder.1";
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
	
		/// <summary>
		/// 删除医嘱附材
		/// </summary>
		/// <param name="ComboID"></param>
		/// <returns></returns>
		public int DeleteOrderSubtbl(string ComboID)
		{
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.delOrder.2",ref strSql)==-1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,ComboID);
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.delOrder.2";
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// '组合
		///将医嘱组合成组合医嘱一起执行
		///条件：usage用法相同
		///      frq  频次相同
		/// </summary>
		/// <param name="alOrder"></param>
		/// <returns></returns>
		public int ComboOrder(ArrayList alOrder)
		{
			string strUsage="",strFrq="";
			string strSql="";
			string strCombNo="";
			#region 组合
			//组合
			//Order.Order.ComboOrder.1
			//传入：0 orderid 1组合号 2是否主药
			//传出：0 
			#endregion

			if (alOrder == null) return -1;
			strCombNo = this.GetNewOrderComboID();
			if (strCombNo == "" || strCombNo == null) 
			{
				this.Err = Neusoft.FrameWork.Management.Language.Msg("医嘱组合号为空，不能组合！");
				return -1;
			}
			for (int i=0;i<alOrder.Count;i++)
			{
                Neusoft.HISFC.Models.Order.Order objOrder = new Neusoft.HISFC.Models.Order.Order();
                objOrder = (Neusoft.HISFC.Models.Order.Order)alOrder[i];
				if (i==0)
				{
					strUsage=objOrder.Usage.ID; 
					strFrq=objOrder.Frequency.ID;
				}
				if (strUsage != objOrder.Usage.ID) 
				{
                    this.Err = objOrder.Item.Name + Neusoft.FrameWork.Management.Language.Msg("用法不一致");
					return -1;
				}
				if (strFrq != objOrder.Frequency.ID) 
				{
                    this.Err = objOrder.Item.Name + Neusoft.FrameWork.Management.Language.Msg("频次不一致");
					return -1;
				}
				
				if(this.Sql.GetSql("Order.Order.ComboOrder.1",ref strSql)==-1) 
				{
					this.Err = this.Sql.Err;
					return -1;
				}
				try
				{
					strSql=string.Format(strSql,objOrder.ID,strCombNo,Neusoft.FrameWork.Function.NConvert.ToInt32(objOrder.Combo.IsMainDrug).ToString());
				}
				catch
				{
					this.Err="传入参数不对！Order.Order.ComboOrder.1";
					return -1;
				}
				if( this.ExecNoQuery( strSql ) <= 0)
				{
					return -1;
				}
			}
			return 0;
		}

		#endregion

		#region "查询医嘱"
		/// <summary>
		/// 查询所有医嘱
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <returns></returns>
		public ArrayList QueryOrder( string inpatientNO )
		{
			#region 查询所有医嘱
			//查询所有医嘱
			//Order.Order.QueryOrder.1
			//传入：0 inpatientno
			//传出：ArrayList
			#endregion

			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if ( sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.1", ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.1字段!";
				return null;
			}
			sql = sql +" " +string.Format(sql1,inpatientNO);
			return this.myOrderQuery(sql);
		}
		/// <summary>
		/// 查询所有医嘱的附材
		/// </summary>
		/// <returns></returns>
		public ArrayList QueryOrderSubtbl( string inpatientNO )
		{
			#region 查询所有医嘱的附材
				//查询所有医嘱
				//Order.Order.QueryOrder.1
				//传入：0 inpatientno
				//传出：ArrayList
				#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql==null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.Sub.1",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.1字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1, inpatientNO);
			return this.myOrderQuery(sql);
		}

        /// <summary>
        /// 查找某一个患者的有效附材 {24F859D1-3399-4950-A79D-BCCFBEEAB939}
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryOrdeSub(string inpatientNO, string itemcode)
        {
            #region 查询所有医嘱
            //查询所有医嘱
            //Order.Order.QueryOrder.1
            //传入：0 inpatientno
            //传出：ArrayList
            #endregion

            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();
            sql = OrderQuerySelect();
            if (sql == null) return null;
            if (this.Sql.GetSql("Order.Order.QueryOrder.6", ref sql1) == -1)
            {
                this.Err = "没有找到Order.Order.QueryOrder.1字段!";
                return null;
            }
            sql = sql + " " + string.Format(sql1, inpatientNO, itemcode);
            return this.myOrderQuery(sql);
        }
		/// <summary>
		/// 按状态查询医嘱
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public ArrayList QueryOrder( string inpatientNO, int status )
		{
			#region 按状态查询医嘱
			//按状态查询医嘱
			//Order.Order.QueryOrder.2
			//传入：0 inpatientno 2 status
			//传出：ArrayList
			#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql==null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.2",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.2字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,status.ToString());
			return this.myOrderQuery(sql);
		}
		/// <summary>
		/// 查询审核的非附材医嘱
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="status"></param>
		/// <param name="isSubtbl"></param>
		/// <returns></returns>
		public ArrayList QueryOrder( string inpatientNO, int status, bool isSubtbl )
		{
			#region 按状态查询医嘱
			//按状态查询医嘱
			//Order.Order.QueryOrder.2
			//传入：0 inpatientno 2 status
			//传出：ArrayList
			#endregion
			string sql="",sql1="";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.ForConfirmQuery",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.ForConfirmQuery字段!";
				return null;
			}
			string flag = "";
			if(isSubtbl)
			{
				flag = "1";
			}
			else
			{
				flag = "0";	
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,status.ToString(), flag);
			return this.myOrderQuery(sql);
		}
		/// <summary>
		/// 按开立时间查询医嘱
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <returns></returns>
		public ArrayList QueryOrder( string inpatientNO, DateTime beginTime, DateTime endTime )
		{
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			#region 按开立时间查询医嘱
			//按开立时间查询医嘱
			//Order.Order.QueryOrder.3
			//传入：0 inpatientno 1BeginTime 2EndTime
			//传出：ArrayList
			#endregion
			
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.3",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.3字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,beginTime,endTime);
			return this.myOrderQuery(sql);
		}
		/// <summary>
		/// 检索有效需要打印的患者巡回卡信息
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="usage"></param>
		/// <param name="isPrint"></param>
		/// <returns></returns>
		public ArrayList QueryCircuitCard( string inpatientNO, string usage, bool isPrint )
		{
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			#region 检索有效需要打印的患者巡回卡信息
			//检索有效需要打印的患者巡回卡信息
			//传入：0 inpatientno 1Usage, 2 Isprint
			//传出：ArrayList
			#endregion

			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryCircuitCard.1",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryCircuitCard.1字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,usage,Neusoft.FrameWork.Function.NConvert.ToInt32(isPrint).ToString());
			return this.myOrderQuery(sql);
		}
		/// <summary>
		/// 按医嘱类型查询医嘱
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public ArrayList QueryOrder( string inpatientNO, string type )
		{
			#region 按医嘱类型查询医嘱
			//按医嘱类型查询医嘱
			//Order.Order.QueryOrder.4
			//传入：0 inpatientno 1Type
			//传出：ArrayList
			#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql==null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.4",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.4字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,type);
			return this.myOrderQuery(sql);
		}
		/// <summary>
		/// 查询出院带药单
		/// </summary>
		/// <param name="inpatientNO">患者流水号</param>
		/// <returns></returns>
		public System.Data.DataSet QueryOutHosDrug(string inpatientNO)
		{
			string sql = "Order.Order.Query.QueryOutHosDrug";
			if(this.Sql.GetSql(sql,ref sql) == -1) 
			{
				this.Err = this.Sql.Err;
				return null;
			}
			sql= string.Format(sql,inpatientNO);
			System.Data.DataSet ds = new System.Data.DataSet();
			if( this.ExecQuery(sql,ref ds)==-1) return null;
			return ds;
		}
		/// <summary>
		/// 查询请假带药单
		/// </summary>
		/// <param name="inpatientNO">患者流水号</param>
		/// <returns></returns>
		public System.Data.DataSet QueryTempOutHosDrug(string inpatientNO)
		{
			string sql = "Order.Order.Query.QueryTempOutHosDrug";
			if(this.Sql.GetSql(sql,ref sql) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			sql = string.Format(sql,inpatientNO);
			System.Data.DataSet ds = new System.Data.DataSet();
			if( this.ExecQuery(sql, ref ds)==-1) return null;
			return ds;
		}
		/// <summary>
		/// 查询出院带疗项目
		/// </summary>
		/// <param name="inpatientNO">患者流水号</param>
		/// <returns></returns>
		public ArrayList QueryOutHosCure(string inpatientNO) {
			string sql = "Order.Order.Query.QueryOutHosCure";
			if(this.Sql.GetSql(sql,ref sql)==-1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			sql = string.Format(sql,inpatientNO);
			ArrayList alCure = new ArrayList();
			try {
				alCure = this.myGetOutHosCure(sql);
			}
			catch {
				 return null;
			}
			return alCure;
		}
		
		/// <summary>
		/// 按医嘱流水号查询医嘱信息-不分有效作废
		/// </summary>
		/// <param name="OrderNO"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Order.Inpatient.Order QueryOneOrder(string OrderNO)
		{
			string sql = "",sql1 = "";
			ArrayList al = null;
			#region 按医嘱流水号查询医嘱信息
			//按医嘱流水号查询医嘱信息
			//Order.Order.QueryOrder.5
			//传入：0 OrderNo
			//传出：ArrayList
			#endregion
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.5",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.5字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,OrderNO);
			al = this.myOrderQuery(sql);
			if(al ==null || al.Count ==0 || al.Count >1) return null;
			return al[0] as Neusoft.HISFC.Models.Order.Inpatient.Order;
		}

		/// <summary>
		/// 通过医嘱号查询医嘱状态
		/// </summary>
		/// <param name="OrderNO"></param>
		/// <returns></returns>
		public int QueryOneOrderState(string OrderNO)
		{
			string sql = string.Empty;
			if(this.Sql.GetSql("Order.Order.QueryOneOrderState.1",ref sql)==-1)
			{
				this.Err="没有找到Order.Order.QueryOneOrderState.1字段!";
				return -1;
			}
			try
			{
				sql= string.Format(sql,OrderNO);
			}
			catch{this.Err ="付数值出错！";this.WriteErr();return -1;}

			return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql));
		}
		
		/// <summary>
		/// 按医嘱类型（长期/临时），状态）查询医嘱（不包含附材）
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="type"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public ArrayList QueryOrder( string inpatientNO, Neusoft.HISFC.Models.Order.EnumType type, int status )
		{
			#region 按医嘱类型（长期/临时），状态）查询医嘱（不包含附材）
			//按医嘱类型（长期/临时），状态）查询医嘱（不包含附材）
			//Order.Order.QueryOrder.where.6
			//传入：0 inpatientno 1 Type 2 status
			//传出：ArrayList
			#endregion

			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.where.6", ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.where.6字段!";
				return null;
			}
			string strType = "1";
			if(type == Neusoft.HISFC.Models.Order.EnumType.LONG)
			{
				strType ="1";
			}
			else
			{
				strType ="0";
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,strType,status.ToString());
			return this.myOrderQuery(sql);
		}

		/// <summary>
		/// 查询是否审核的医嘱 - 不包括附材
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="type"></param>
		/// <param name="isConfirmed"></param>
		/// <returns></returns>
		public ArrayList QueryIsConfirmOrder( string inpatientNO, Neusoft.HISFC.Models.Order.EnumType type, bool isConfirmed )
		{
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryIsConfirmOrder.where.1",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryIsConfirmOrder.where.1字段!";
				return null;
			}
			string strType ="1";
			if(type == Neusoft.HISFC.Models.Order.EnumType.LONG)
			{
				strType ="1";
			}
			else
			{
				strType ="0";
			}
			try
			{
				sql= sql +" " +string.Format(sql1,inpatientNO,Neusoft.FrameWork.Function.NConvert.ToInt32(isConfirmed).ToString(),strType);
			}
			catch{return null;}
			return this.myOrderQuery(sql);
		}

        /// <summary>
        /// 查询所有医嘱
        /// </summary>
        /// <param name="InPatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryDcOrder(string InPatientNO)
        {
            #region 查询所有医嘱
            //查询所有医嘱
            //Order.Order.QueryOrder.1
            //传入：0 inpatientno
            //传出：ArrayList
            #endregion
            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();
            sql = OrderQuerySelect();
            if (sql == null) return null;
            if (this.Sql.GetSql("Order.Order.QueryOrder.OrderPrint", ref sql1) == -1)
            {
                this.Err = "没有找到Order.Order.QueryOrder.1字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            sql = sql + " " + string.Format(sql1, InPatientNO);
            return this.myOrderQuery(sql);
        }
		/// <summary>
		/// 按医嘱状态,停止审核标志 查询医嘱（不包含附材）
		/// 停止未审核医嘱查询
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="isConfirm"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public ArrayList QueryDcOrder(string inpatientNO,int status,bool isConfirm)
		{
			#region  按医嘱状态,审核标志 查询医嘱（不包含附材）
			// 按医嘱状态,审核标志 查询医嘱（不包含附材）
			//Order.Order.QueryDcOrder.where.1
			//传入：0 inpatientno 1 status 2 IsConfirm
			//传出：ArrayList
			#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql==null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryDcOrder.where.1",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryDcOrder.where.1字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,status.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(isConfirm));
			return this.myOrderQuery(sql);
		}

		/// <summary>
		/// 获得医嘱项目的附材信息(组合号）
		/// </summary>
		/// <param name="combNo"></param>
		/// <returns></returns>
		public ArrayList QuerySubtbl(string combNo)
		{
			#region 获得医嘱项目的附材信息(组合号）
			//获得医嘱项目的附材信息(组合号）
			//Order.Order.QueryOrder.where.7
			//传入：0 inpatientno 1 CombNo 
			//传出：ArrayList
			#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql==null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrder.where.7",ref sql1)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.where.7字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,combNo);
			return this.myOrderQuery(sql);
		}
        /// <summary>
        /// 从非药品执行档查找某个非药品当天是否存在执行记录
        /// {24F859D1-3399-4950-A79D-BCCFBEEAB939}
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="undrugID"></param>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList QueryExecOrderSubtblCurrentDay(string inpatientNo, string undrugID, string deptID)
        {

            string[] s;
            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();

            s = ExecOrderQuerySelect("2");

            for (int i = 0; i <= s.GetUpperBound(0); i++)
            {
                sql = s[i];
                if (sql == null) return null;
                if (this.Sql.GetSql("Order.ExecOrder.QueryExecOrderSubtblCurrentDay", ref sql1) == -1)
                {
                    this.Err = "没有找到Order.ExecOrder.QueryExecOrderBySubtblFeeMode.1字段!";
                    return null;
                }
                sql = sql + " " + string.Format(sql1, inpatientNo, undrugID, deptID);
                addExecOrder(al, sql);
            }
            return al;
        }
		/// <summary>
		/// 获得医嘱皮试信息
		/// </summary>
		/// <param name="orderNo"></param>
		/// <returns>-1错误 1不需要皮试/2需要皮试，未做/3皮试阳/4皮试阴</returns>
		public int QueryOrderHypotest(string orderNo)
		{
			#region 获得医嘱皮试信息
			//Order.Order.QueryOrderHypotest.1
			//传入：0 OrderNo 
			//传出：int 1不需要皮试/2需要皮试，未做/3皮试阳/4皮试阴
			#endregion
			string sql = "";
			int Hypotest = -1;
			
			if(this.Sql.GetSql("Order.Order.QueryOrderHypotest.1",ref sql)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrderHypotest.1字段!";
				return -1;
			}
			sql = string.Format(sql,orderNo);
			if (this.ExecQuery (sql) < 0) return -1;
			
			if(this.Reader.Read())
			{
				Hypotest=Neusoft.FrameWork.Function.NConvert.ToInt32 (this.Reader[0]);
			}
			else
			{
				Hypotest = 1;
			}
		
			this.Reader.Close();

			return Hypotest;
		}

		/// <summary>
		/// 获得医嘱批注信息
		/// </summary>
		/// <param name="orderNo"></param>
		/// <returns></returns>
		public string QueryOrderNote(string orderNo)
		{
			#region 获得医嘱反馈批注信息
			//Order.Order.QueryOrderNote.1
			//传入：0 OrderNo 
			//传出：string
			#endregion
			string sql = "";
			string Note = "";
			
			if(this.Sql.GetSql("Order.Order.QueryOrderNote.1",ref sql)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrderNote.1字段!";
				return "";
			}
			sql= string.Format(sql,orderNo);
			if (this.ExecQuery(sql) < 0) return "";
			
			if(this.Reader.Read())
			{
				Note=this.Reader[0].ToString();
			}
			this.Reader.Close();
		
			return Note;
		}

		/// <summary>
		/// 按医嘱类型（长期/临时），状态）查询医嘱（包含附材）
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="type"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public ArrayList QueryOrderWithSubtbl( string inpatientNO, Neusoft.HISFC.Models.Order.EnumType type, int status )
		{
			#region 按医嘱类型（长期/临时），状态）查询医嘱（包含附材）
			//按医嘱类型（长期/临时），状态）查询医嘱（包含附材）
			//Order.Order.QueryOrder.where.6
			//传入：0 inpatientno 1 Type 2 status
			//传出：ArrayList
			#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrderWithSubtbl.where.1",ref sql1) == -1)
			{
				this.Err="没有找到Order.Order.QueryOrderWithSubtbl.where.1字段!";
				return null;
			}
			string strType = "1";
			if(type == Neusoft.HISFC.Models.Order.EnumType.LONG)
			{
				strType ="1";
			}
			else
			{
				strType ="0";
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,strType,status.ToString());
			return this.myOrderQuery(sql);
		}
		/// <summary>
		/// 查询有效的医嘱
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public ArrayList QueryValidOrderWithSubtbl( string inpatientNO, Neusoft.HISFC.Models.Order.EnumType type )
		{
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrderWithSubtbl.where.2",ref sql1) == -1)
			{
				this.Err="没有找到Order.Order.QueryOrderWithSubtbl.where.2字段!";
				return null;
			}
			string strType ="1";
			if(type == Neusoft.HISFC.Models.Order.EnumType.LONG)
			{
				strType ="1";
			}
			else
			{
				strType ="0";
			}
			sql= sql +" " +string.Format(sql1,inpatientNO,strType);
			return this.myOrderQuery(sql);
		}
		#endregion 

		#region 流水号
		/// <summary>
		/// 获得医嘱流水号
		/// </summary>
		/// <returns></returns>
		public string GetNewOrderID()
		{
			string sql = "";
			if(this.Sql.GetSql("Management.Order.GetNewOrderID",ref sql) == -1) return null;
			string strReturn = this.ExecSqlReturnOne(sql);
			if(strReturn == "-1" || strReturn == "") return null;
			return strReturn;
		}
		/// <summary>
		/// 获得医嘱执行流水号
		/// </summary>
		/// <returns></returns>
		public string GetNewOrderExecID()
		{
			string sql="";
			if(this.Sql.GetSql("Management.Order.GetNewOrderExecID",ref sql)==-1) return null;
			string strReturn = this.ExecSqlReturnOne(sql);
			if(strReturn == "-1" || strReturn == "") return null;
			return strReturn;
		}
		/// <summary>
		/// 获得新医嘱组合序号
		/// </summary>
		/// <returns></returns>
		public string GetNewOrderComboID()
		{
			string sql="";
			if(this.Sql.GetSql("Management.Order.GetComboID",ref sql)==-1) return null;
			string strReturn = this.ExecSqlReturnOne(sql);
			if(strReturn == "-1" || strReturn == "") return null;
			return strReturn;
		}
		#endregion

		#region "医嘱审核"

		/// <summary>   
		/// 更新医嘱反馈信息（护士批注，皮试结果）
		/// 更新皮试前请判断该标志是否需要皮试（1不需要皮试/2需要皮试，未做/3皮试阳/4皮试阴）
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="orderNo"></param>
		/// <param name="notes">批注</param>
		/// <param name="hypotest">皮试（1不需要皮试/2需要皮试，未做/3皮试阳/4皮试阴）</param>
		/// <returns></returns>
		public int UpdateFeedback(string inpatientNo,string orderNo,string notes,int hypotest)
		{
			#region 更新医嘱反馈信息
			//更新医嘱反馈信息
			//Order.Order.Updatefeedback.1
			//传入：0 inpatientNo,1orderID,2 NOTES,3 hypotest
			//传出：0 
			#endregion
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.Updatefeedback.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,inpatientNo,orderNo,notes,hypotest.ToString());
			}
			catch
			{
				this.Err = "传入参数不对！Order.Order.Updatefeedback.1";
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新医嘱执行标记
		/// </summary>
		/// <param name="orderNo"></param>
		/// <returns></returns>
		public int UpdateOrderExecuted(string orderNo)
		{
			#region 更新医嘱执行情况
			//更新医嘱执行情况
			//Order.Order.UpdateExecOrder.1
			//传入：0 orderID 1 操作员 2 操作时间
			//传出：0 
			#endregion
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.UpdateExecOrder.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,orderNo,this.Operator.ID,this.GetSysDateTime().ToString());
			}
			catch
			{
				this.Err = "传入参数不对！Order.Order.UpdateExecOrder.1";
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新医嘱记帐情况
		/// 更新为记帐
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="orderNo"></param>
		/// <returns></returns>
		public int UpdateChargeOrder(string inpatientNo,string orderNo)
		{
			#region 更新医嘱记帐情况
			//更新医嘱记帐情况
			//Order.Order.UpdateChargeOrder.1
			//传入：0 inpatientNo,1orderID 2 操作员 3 操作时间
			//传出：0 
			#endregion
			string strSql="";
			if(this.Sql.GetSql("Order.Order.UpdateChargeOrder.1",ref strSql)==-1) return -1;
			try
			{
				strSql=string.Format(strSql,inpatientNo,orderNo,this.Operator.ID,this.GetSysDateTime().ToString());
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.UpdateChargeOrder.1";
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新医嘱附材数量
		/// </summary>
		/// <param name="orderNo">附材医嘱编码</param>
		/// <param name="num"></param>
		/// <returns></returns>
		public int UpdateSubtblNum(string orderNo, decimal num)
		{
			string strSql = "";
			if(this.Sql.GetSql("Order.UpdateSubNum.1", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, orderNo, num);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = "-1";
				this.WriteErr();
				return -1;
			}

			return this.ExecNoQuery(strSql);
			
		}
		#endregion

	
		#endregion

		#region "医嘱执行处理
		
		#region "更新执行档"

		/// <summary>
		/// 护士站更新临时医嘱备注信息
		/// </summary>
		/// <param name="orderNo"></param>
		/// <param name="txt"></param>
		/// <returns></returns>
		public int UpdateExecTime(string orderNo,string txt)
		{
			string strSql = "";
			if(this.Sql.GetSql("Order.ExecOrder.UpdateExecTime",ref strSql) == -1)
			{
				this.Err = "没有找到Order.ExecOrder.UpdateExecTimeDrug字段";
				return -1;
			}
			strSql = string.Format(strSql, orderNo, txt);
			return this.ExecNoQuery(strSql);
		}

        /// <summary>
        /// 更新执行档有效标记
        /// </summary>
        /// <param name="execOrderID"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public int UpdateExecValidFlag(string execOrderID, bool isPharmacy, string flag)
        {
            string strSql = "";
            string strIndex = "";

            if (isPharmacy)			//药品执行档
                strIndex = "Order.Update.UpdateExecValidFlag.1";
            else					//非药品执行档
                strIndex = "Order.Update.UpdateExecValidFlag.2";

            if (this.Sql.GetSql(strIndex, ref strSql) == -1)
            {
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, execOrderID, flag);
            }
            catch (Exception ex)
            {
                this.Err = "传入参数不对!" + strIndex + ex.Message;
                return -1;
            }
            return ExecNoQuery(strSql);
        }

		/// <summary>
		/// 作废执行档 非常规操作
		/// </summary>
		/// <param name="SqnNo"></param>
		/// <param name="isDrug"></param>
		/// <param name="dcPerson"></param>
		/// <returns></returns>
		public int DcExecImmediate(string SqnNo,bool isDrug,Neusoft.FrameWork.Models.NeuObject dcPerson) {
		    string strSql = "";
			if(isDrug) {
				if(this.Sql.GetSql("Order.ExecOrder.DcExecImmediate.UnNormal.Drug",ref strSql) == -1) {
				 	this.Err = "Can't Find Sql";
					return -1;
				}
			}
			else {
				if(this.Sql.GetSql("Order.ExecOrder.DcExecImmediate.UnNormal.UnDrug",ref strSql) == -1) {
				 	this.Err = "Can't Find Sql";
					return -1; 
				}
			}
			try{
				strSql = System.String.Format(strSql,SqnNo,dcPerson.ID,dcPerson.Name);
		    }
		    catch {
		       this.Err="传入参数不对";
		       return -1;
	        }
            return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 作废执行档
		/// </summary>
		/// <param name="dcPerson">执行档信息</param>
		/// <returns>0 success -1 fail</returns>
        public int DcExecImmediate(Neusoft.HISFC.Models.Order.Order Order, Neusoft.FrameWork.Models.NeuObject dcPerson)
		{
			#region 作废执行档
			//作废执行档(医嘱停止或直接作废)
			//Order.ExecOrder.DcExecImmediate
			//传入：0 id，1 停止人id,2停止人姓名，3停止时间,4作废标志 
			//传出：0 
			#endregion

			string strSql = "",strSqlName = "Order.ExecOrder.DcExecImmediate.";
			string strType = "";
			strType = this.JudgeItemType(Order);
			if (strType == "" ) return -1;

			strSqlName= strSqlName + strType;

			if(this.Sql.GetSql(strSqlName,ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,Order.ID,dcPerson.ID,dcPerson.Name);
			}
			catch
			{
				this.Err="传入参数不对"+strSqlName;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 停止指定执行档
		/// </summary>
		/// <param name="execOrder"></param>
		/// <param name="dcPerson"></param>
		/// <returns></returns>
        public int DcExecImmediate(Neusoft.HISFC.Models.Order.ExecOrder execOrder, Neusoft.FrameWork.Models.NeuObject dcPerson)
		{
			#region 作废执行档
			//作废执行档(医嘱停止或直接作废)
			//Order.ExecOrder.DcExecImmediate
			//传入：0 id，1 停止人id,2停止人姓名，3停止时间,4作废标志 
			//传出：0 
			#endregion
			string strSql = "",strSqlName = "Order.ExecOrder.DcExecImmediateByExecOrderID.";
			string strType = "";

			strType = this.JudgeItemType (execOrder.Order );
			if (strType == "" ) return -1;

			strSqlName= strSqlName + strType;
			
			if(this.Sql.GetSql(strSqlName,ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,execOrder.ID,dcPerson.ID,dcPerson.Name);
			}
			catch
			{
				this.Err="传入参数不对"+strSqlName;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 按医嘱流水号作废执行档
		/// </summary>
		/// <param name="Order"></param>
		/// <returns>0 success -1 fail</returns>
        public int DcExecLater(Neusoft.HISFC.Models.Order.Order Order, Neusoft.FrameWork.Models.NeuObject dcPerson, DateTime EndTime)
		{
			#region 按医嘱流水号作废执行档
			//作废执行档(医嘱停止或直接作废)
			//Order.ExecOrder.DcExecLater
			//传入：0 orderid，1 停止人id,2停止人姓名，3停止时间
			//传出：0 
			#endregion

			string strSql="",strSqlName="Order.ExecOrder.DcExecLater.";
			
			string strType = "";
			strType = this.JudgeItemType (Order);
			if (strType == "" ) return -1;

			strSqlName= strSqlName + strType;

			if(this.Sql.GetSql(strSqlName,ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,Order.ID,dcPerson.ID,dcPerson.Name,EndTime);
			}
			catch
			{
				this.Err="传入参数不对"+strSqlName;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		

		/// <summary>
		/// 更新医嘱状态
		/// 为已经执行
		/// </summary>
		/// <param name="orderNo"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public int UpdateOrderStatus(string orderNo,int status)
		{
			string strSql="";

			if(this.Sql.GetSql("Order.Update.OrderStatus",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,orderNo,status.ToString());
			}
			catch(Exception ex)
			{
				this.Err="传入参数不对！Order.Update.OrderStatus"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql) <= 0) return -1;
			return 0;
		}


		/// <summary>
		/// 更新医嘱排序号
		/// </summary>
		/// <param name="orderID"></param>
		/// <param name="sortID"></param>
		/// <returns></returns>
		public int UpdateOrderSortID(string orderID,string sortID)
		{
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.updateOrderSort.1",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			return this.ExecNoQuery(strSql,orderID,sortID);
		}
		#endregion 

		#region 更新打印标记
		
		/// <summary>
		/// 更新执行单打印标记
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <param name="itemType">1 药品 ,2 非药品</param>
		/// <returns></returns>
		public int UpdateExecOrderPrinted(string execOrderID,string itemType)
		{
			string strSql = "";
			if(itemType == "2")
			{
				//Order.ExecOrder.UpdateExecUndrugPrintFlag
				if(this.Sql.GetSql("Order.ExecOrder.UpdateExecUndrugPrintFlag",ref strSql) == -1)
				{
					this.Err = this.Sql.Err;
					return -1;
				}
				try
				{
					strSql=string.Format(strSql,execOrderID,this.Operator.ID);
				}
				catch
				{
					this.Err="传入参数不对！Order.ExecOrder.UpdateExecUndrugPrintFlag";
					this.WriteErr();
					return -1;
				}
			}
			else if(itemType == "1")
			{
				//Order.ExecOrder.UpdateExecDrugPrintFlag
				if(this.Sql.GetSql("Order.ExecOrder.UpdateExecDrugPrintFlag",ref strSql) == -1)
				{
					this.Err = this.Sql.Err;
					return -1;
				}
				try
				{
					strSql=string.Format(strSql,execOrderID,this.Operator.ID);
				}
				catch
				{
					this.Err="传入参数不对！Order.ExecOrder.UpdateExecDrugPrintFlag";
					this.WriteErr();
					return -1;
				}
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新收费打印
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <param name="itemType"></param>
		/// <returns></returns>
		public int UpdateExecNeedFeePrinted(string execOrderID,string itemType)
		{
			string strSql = "";
			if(itemType == "1")
			{
				//Order.ExecOrder.Drug.UpdateExecNeedFeePrinted
				if(this.Sql.GetSql("Order.ExecOrder.Drug.UpdateExecNeedFeePrinted",ref strSql) == -1)
				{
					this.Err = this.Sql.Err;
					return -1;
				}
				try
				{
					strSql=string.Format(strSql,execOrderID,this.Operator.ID);
				}
				catch
				{
					this.Err="传入参数不对！Order.ExecOrder.Drug.UpdateExecNeedFeePrinted";
					this.WriteErr();
					return -1;
				}
			}
			else if(itemType == "2")
			{
				//Order.ExecOrder.Undrug.UpdateExecNeedFeePrinted
				if(this.Sql.GetSql("Order.ExecOrder.Undrug.UpdateExecNeedFeePrinted",ref strSql) == -1)
				{
					this.Err = this.Sql.Err;
					return -1;
				}
				try
				{
					strSql=string.Format(strSql,execOrderID,this.Operator.ID);
				}
				catch
				{
					this.Err="传入参数不对！Order.ExecOrder.Undrug.UpdateExecNeedFeePrinted";
					this.WriteErr();
					return -1;
				}
			}
			return this.ExecNoQuery(strSql);
		}
		///<summary>
		/// 更新收费打印
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <returns></returns>
		public int UpdateTransfusionPrinted(string execOrderID)
		{
			string strSql = "";
			//Order.ExecOrder.Drug.UpdateExecNeedFeePrinted
			if(this.Sql.GetSql("Order.ExecOrder.UpdateTransfusionPrinted",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,execOrderID,this.Operator.ID);
			}
			catch
			{
				this.Err="传入参数不对！Order.ExecOrder.UpdateTransfusionPrinted";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 更新巡回卡打印标记
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <returns></returns>
		public int UpdateCircultPrinted(string execOrderID)
		{
			string strSql = "";
			if(this.Sql.GetSql("Order.ExecOrder.UpdateCircultPrinted",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql, execOrderID,this.Operator.ID);
			}
			catch
			{
				this.Err="传入参数不对！Order.ExecOrder.UpdateCircultPrinted";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		#endregion

		#region "查询医嘱执行信息"
		/// <summary>
		/// 查询所有医嘱执行情况
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="itemType">"" 全部，1药2非药</param>
		/// <returns></returns>
		public ArrayList QueryExecOrder(string inpatientNo,string itemType)
		{
			#region 查询所有医嘱执行情况
			//查询所有医嘱执行情况（药，非药）
			//Order.ExecOrder.QueryPatientExec.1
			//传入：0 inpatientno
			//传出：ArrayList
			#endregion
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect (itemType);
			for (int i = 0;i <= s.GetUpperBound(0);i++)
			{
				sql= s[i];
				if (sql == null ) return null;
				if(this.Sql.GetSql("Order.ExecOrder.QueryPatientExec.1",ref sql1)==-1)
				{
					this.Err="没有找到Order.ExecOrder.QueryPatientExec.1字段!";
					return null;
				}
				sql= sql +" " +string.Format(sql1,inpatientNo);
				addExecOrder(al,sql);
			}
			return al;
		}
		/// <summary>
		/// 按查询是否有效执行医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="itemType">"" 全部，1药2非药</param>
		/// <param name="isValid">是否有效</param>
		/// <returns></returns>
		public ArrayList QueryExecOrder(string inpatientNo,string itemType,bool isValid)
		{
			#region 按查询有效执行医嘱
			//按查询有效执行医嘱
			//Order.ExecOrder.QueryValidOrder.1
			//传入：0 inpatientno 1  IsValid
			//传出：ArrayList
			#endregion

			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect(itemType);
			for (int i = 0;i <= s.GetUpperBound(0);i++)
			{
				sql= s[i];
				if (sql == null ) return null;
				if(this.Sql.GetSql("Order.ExecOrder.QueryValidOrder.1",ref sql1) == -1)
				{
					this.Err="没有找到Order.ExecOrder.QueryValidOrder.1字段!";
					return null;
				}
				sql= sql +" " +string.Format(sql1,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isValid).ToString());
				addExecOrder(al,sql);
			}
			return al;
		}

		/// <summary>
		/// 按查询是否执行医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="itemType">"" 全部，1药2非药</param>
		/// <param name="isExec"></param>
		/// <returns></returns>
		public ArrayList QueryExecOrderIsExec(string inpatientNo,string itemType,bool isExec)
		{
			#region 按查询是否执行医嘱
			//按查询是否执行医嘱
			//Order.ExecOrder.QueryExecOrder.1
			//传入：0 inpatientno 1 IsExec
			//传出：ArrayList
			#endregion

			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			s = ExecOrderQuerySelect(itemType);
			for (int i = 0;i <= s.GetUpperBound(0);i++)
			{
				sql= s[i];
				if (sql == null ) return null;

                //{DA77B01B-63DF-4559-B264-798E54F24ABB}
                if (itemType == "")
                {
                    return null;
                }
                string strSqlName = "Order.ExecOrder.QueryExecOrder." + itemType;
                //{DA77B01B-63DF-4559-B264-798E54F24ABB}
                if (this.Sql.GetSql(strSqlName, ref sql1) == -1)
				{
                    this.Err = "没有找到" + strSqlName + "字段!";
					return null;
				}
				sql= sql +" " +string.Format(sql1,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isExec).ToString());
				addExecOrder(al,sql);
			}
			return al;
		}
		/// <summary>
		/// 按查询执行医嘱信息
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <param name="itemType"></param>
		/// <returns>Neusoft.HISFC.Models.Order.ExecOrder</returns>
		public Neusoft.HISFC.Models.Order.ExecOrder  QueryExecOrderByExecOrderID(string execOrderID,string itemType)
		{
			#region 按查询是否执行医嘱
			//按查询是否执行医嘱
			//Order.ExecOrder.QueryExecOrder.0
			//传入：0 ExecOrderID
			//传出：Neusoft.HISFC.Models.Order.ExecOrder
			#endregion
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			s = ExecOrderQuerySelect (itemType);
			for (int i = 0;i <= s.GetUpperBound(0);i++)
			{
				sql= s[i];
				if (sql==null ) return null;
				if(this.Sql.GetSql("Order.ExecOrder.QueryExecOrder.0",ref sql1)==-1)
				{
					this.Err="没有找到Order.ExecOrder.QueryExecOrder.0字段!";
					return null;
				}
				sql= sql +" " +string.Format(sql1,execOrderID);
				addExecOrder(al,sql);
			}
			if(al.Count>0) return al[0] as Neusoft.HISFC.Models.Order.ExecOrder;
			return null;
		}

		/// <summary>
		/// 按执行部门查询是否执行医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="itemType"></param>
		/// <param name="isExec"></param>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public ArrayList QueryExecOrderByDept(string inpatientNo,string itemType,bool isExec,string deptCode)
		{
			#region 按执行部门查询是否执行医嘱
			//Order.ExecOrder.QueryExecOrderByDept.1
			//传入：0 inpatientno 1 IsExec 2 deptid
			//传出：ArrayList
			#endregion
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			s= ExecOrderQuerySelect(itemType);
			for (int i = 0;i <= s.GetUpperBound(0);i++)
			{
				sql = s[i];
				if (sql==null ) return null;
				if(this.Sql.GetSql("Order.ExecOrder.QueryExecOrderByDept.1",ref sql1)==-1)
				{
					this.Err="没有找到Order.ExecOrder.QueryExecOrder.1字段!";
					return null;
				}
				sql= sql +" " +string.Format(sql1,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isExec).ToString(),deptCode);
				addExecOrder(al,sql);
			}
			return al;
		}
		/// <summary>
		/// 按查询是否收费医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="itemType"></param>
		/// <param name="isCharge"></param>
		/// <returns></returns>
		public ArrayList QueryExecOrderIsCharg(string inpatientNo,string itemType,bool isCharge)
		{
			#region 按查询是否收费医嘱
			//按查询是否收费医嘱
			//Order.ExecOrder.QueryChargeOrder.1
			//传入：0 inpatientno 1  IsCharge
			//传出：ArrayList
			#endregion
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect (itemType);
			for (int i = 0;i <= s.GetUpperBound(0);i++)
			{
				sql= s[i];
				if (sql == null ) return null;
				if(this.Sql.GetSql("Order.ExecOrder.QueryChargeOrder.1",ref sql1) == -1)
				{
					this.Err = "没有找到Order.ExecOrder.QueryChargeOrder.1字段!";
					return null;
				}
				sql= sql + " " + string.Format(sql1,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isCharge).ToString());
				addExecOrder(al,sql);
			}
			return al;
		}

		/// <summary>
		/// 按查询配药状态医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <param name="drugFlag"></param>
		/// <returns></returns>
		public ArrayList QueryExecOrderByDrugFlag(string inpatientNo,DateTime beginTime,DateTime endTime, int drugFlag)
		{
			#region 按查询配药状态医嘱
			//按查询配药状态医嘱
			//Order.ExecOrder.QueryOrderDrugFlag.1
			//传入：0 inpatientno 1  DrugFlag
			//传出：ArrayList
			#endregion
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect("1");
			sql = s[0];
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderDrugFlag.1",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryOrderDrugFlag.1字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNo,drugFlag.ToString(),beginTime,endTime);
			return this.myExecOrderQuery(sql);
		}
		/// <summary>
		/// 按查询配药状态医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="drugFlag"></param>
		/// <returns></returns>
		public ArrayList QueryExecOrderByDrugFlag(string inpatientNo,int drugFlag)
		{
			#region 按查询配药状态医嘱
			//按查询配药状态医嘱
			//Order.ExecOrder.QueryOrderDrugFlag.1
			//传入：0 inpatientno 1  DrugFlag
			//传出：ArrayList
			#endregion

			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect("1");
			sql = s[0];
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderDrugFlag.2",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryOrderDrugFlag.2字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNo,drugFlag.ToString());
			return this.myExecOrderQuery(sql);
		}	
		/// <summary>
		/// 按医嘱流水号查询医嘱执行信息
		/// </summary>
		/// <param name="orderNo"></param>
		/// <param name="itemType">1药2非药""全部</param>
		/// <returns></returns>
		public ArrayList QueryExecOrderByOneOrder(string orderNo,string itemType)
		{
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			#region 按医嘱流水号查询医嘱执行信息
			//按医嘱流水号查询医嘱执行信息
			//Order.ExecOrder.QueryOrder.where.5
			//传入：0 OrderNo
			//传出：ArrayList
			#endregion
			s = ExecOrderQuerySelect(itemType);
			for (int i = 0;i <= s.GetUpperBound(0);i++)
			{
				sql = s[i];
				if (sql == null ) return null;
				if(this.Sql.GetSql("Order.ExecOrder.Query.where.5",ref sql1) == -1)
				{
					this.Err="没有找到Order.ExecOrder.Query.where.5字段!";
					return null;
				}
				sql = sql +" " +string.Format(sql1,orderNo);
				addExecOrder(al,sql);
			}
			return al;
		}
	/// <summary>
	///  患者输液卡查询
	/// </summary>
	/// <param name="inpatientNo"></param>
	/// <param name="beginTime"></param>
	/// <param name="endTime"></param>
	/// <param name="usageCode"></param>
	/// <param name="isPrinted"></param>
	/// <returns></returns>
		public ArrayList QueryOrderExec(string inpatientNo,DateTime beginTime,DateTime endTime,string usageCode,bool isPrinted)
		{
			#region 患者输液卡查询
			//患者输液卡查询
			//Order.ExecOrder.QueryOrderExec.1
			//传入：0InpatientNo,1 DateTimeBegin,2 DateTimeEnd,3 UsageCode,4 PrintFlag
			//传出：ArrayList
			#endregion
			string[] s;
			string sql = "",sql1 = "";
			
			s = ExecOrderQuerySelect("1");
			sql = s[0];
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderExec.1",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryOrderExec.1字段!";
				this.WriteErr();
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNo,beginTime.ToString(),endTime.ToString(),usageCode,Neusoft.FrameWork.Function.NConvert.ToInt32(isPrinted).ToString());
			return this.myExecOrderQuery(sql);
		}
		/// <summary>
		/// 查询巡回卡信息
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <param name="usageCode"></param>
		/// <param name="isPrinted"></param>
		/// <returns></returns>
		public ArrayList QueryOrderCircult(string inpatientNo,DateTime beginTime,DateTime endTime,string usageCode,bool isPrinted)
		{
			string[] s;
			string sql = "",sql1 = "";
			
			s = ExecOrderQuerySelect("1");
			
			sql = s[0];
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderExec.Circlue",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryOrderExec.Circlue字段!";
				this.WriteErr();
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNo,beginTime.ToString(),endTime.ToString(),usageCode,Neusoft.FrameWork.Function.NConvert.ToInt32(isPrinted).ToString());
			return this.myExecOrderQuery(sql);
		}
		/// <summary>
		/// 获得患者执行单-药品和非药品
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <param name="isPrinted"></param>
		/// <returns></returns>
		public ArrayList QueryOrderExecBill(string inpatientNo,DateTime beginTime,DateTime endTime,string billNo,bool isPrinted)
		{
			#region 患者执行单查询
			//患者执行单查询
			//Order.ExecOrder.QueryOrderExecBill
			//传入：0InpatientNo,1 执行单流水号 2DateTimeBegin,3 DateTimeEnd,4 PrintFlag
			//传出：ArrayList
			#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();

			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderExecBill.1",ref sql) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryOrderExecBill.1字段!";
				return null;
			}
			sql = string.Format(sql,inpatientNo,billNo,beginTime.ToString(),endTime.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(isPrinted).ToString());
			addExecOrder(al,sql);
			//
			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderExecBill.2",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryOrderExecBill.2字段!";
				return null;
			}
			sql1=string.Format(sql1,inpatientNo,billNo,beginTime.ToString(),endTime.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(isPrinted).ToString());
			addExecOrder(al,sql1);
			return al;
		}
        #region {D05A3C7C-1CA1-4b9a-96B6-5D3018CF8FD7}
        /// <summary>
        /// 获得患者执行单-药品和非药品
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isPrinted"></param>
        /// <returns></returns>
        public ArrayList QueryOrderExecBillForSingle(string inpatientNo, DateTime beginTime, DateTime endTime, string billNo, bool isPrinted)
        {
            #region 患者执行单查询
            //患者执行单查询
            //Order.ExecOrder.QueryOrderExecBill
            //传入：0InpatientNo,1 执行单流水号 2DateTimeBegin,3 DateTimeEnd,4 PrintFlag
            //传出：ArrayList
            #endregion
            string sql = "";
            ArrayList al = new ArrayList();
            if (this.Sql.GetSql("Order.ExecOrder.QueryOrderExecBill.3", ref sql) == -1)
            {
                this.Err = "没有找到Order.ExecOrder.QueryOrderExecBill.3字段!";
                return null;
            }
            sql = string.Format(sql, inpatientNo, billNo, beginTime.ToString(), endTime.ToString(), Neusoft.FrameWork.Function.NConvert.ToInt32(isPrinted).ToString());
            addExecOrder(al, sql);
            return al;
        } 
        #endregion
		/// <summary>
		/// 获得患者检验单信息
		/// </summary>
		/// <param name="inpatientNo">患者住院号</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <param name="isPrinted">打印标记</param>
		/// <returns></returns>
		public ArrayList QueryOrderLisApplyBill(string inpatientNo,DateTime beginTime,DateTime endTime,bool isPrinted)
		{
			#region 患者执行单查询
			//患者执行单查询
			//Order.ExecOrder.QueryOrderLisApplyBill
			//传入：0 InpatientNo,1 DateTimeBegin,2 DateTimeEnd,4 PrintFlag
			//传出：ArrayList
			#endregion

			string sql="",sql1="";
			ArrayList al = new ArrayList();
			string[] s = ExecOrderQuerySelect("2");
			if(s.Length>0)
			{
				sql = s[0];
			}
			else
			{
				return null;
			}
			if(this.Sql.GetSql("Order.ExecOrder.QueryOrderLisApplyBill",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryOrderLisApplyBill字段!";
				return null;
			}
			sql1=string.Format(sql1,inpatientNo,beginTime.ToString(),endTime.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(isPrinted).ToString());
			sql1= sql +" "+sql1;
			addExecOrder(al,sql1);
			return al;
		}
		/// <summary>
		/// 查询医嘱收费单
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="itemType"></param>
		/// <param name="isPrinted"></param>
		/// <returns></returns>
		public ArrayList QueryExecOrderBillNeedCharge(string inpatientNo,string itemType,bool isPrinted)
		{
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect(itemType);
			sql = s[0];
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.ExecDrugUnDrug.QueryNoCharged.1",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecDrugUnDrug.QueryNoCharged.1字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,inpatientNo,Neusoft.FrameWork.Function.NConvert.ToInt32(isPrinted).ToString());
			return this.myExecOrderQuery(sql);
		}
		/// <summary>
		/// 查询医嘱执行档根据处方号
		/// </summary>
		/// <param name="itemType"></param>
		/// <param name="receiptNo"></param>
		/// <returns></returns>
		public ArrayList QueryExecOrderBillByReceiptNo(string itemType,string receiptNo)
		{
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect(itemType);
			sql = s[0];
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.QueryOrderExecBill.ReceiptNo",ref sql1) == -1)
			{
				this.Err="没有找到Order.QueryOrderExecBill.ReceiptNo字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,receiptNo);
			return this.myExecOrderQuery(sql);
		}
		/// <summary>
		/// 查询需要发药的医嘱信息
		/// </summary>
		/// <param name="deptcode"></param>
		/// <returns></returns>
		public ArrayList QureyExecOrderNeedSendDrug(string deptcode)
		{
			string[] s;
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			
			s = ExecOrderQuerySelect("1");
			
			sql = s[0];
			if (sql == null ) return null;
			
			if(this.Sql.GetSql("Order.ExecOrder.QueryNeedDrug",ref sql1) == -1)
			{
				this.Err="没有找到Order.ExecOrder.QueryNeedDrug字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,deptcode);
			addExecOrder(al,sql);
			
			return al;
		}
		/// <summary>
		/// 查询药品执行医嘱通过住院流水号
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <returns></returns>
		public DataSet QueryExecDrugOrderByInpatientNo(string inpatientNo) 
		{
			string strSql ="";  
			DataSet dataSet = new DataSet();

			//取SQL语句
			if (this.Sql.GetSql("Order.Report.ExecDrugByInpatientNo",ref strSql) == -1) 
			{
				this.Err="没有找到Order.Report.ExecDrugByInpatientNo字段!";
				return null;
			}
			try 
			{  
				strSql=string.Format(strSql, inpatientNo);    //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err="付数值时候出错Order.Report.ExecDrugByInpatientNo！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}

		
		/// <summary>
		/// 根据患者住院流水号，查询非药品医嘱执行档信息
		/// writed by cuipeng
		/// 2005-06
		/// </summary>
		/// <param name="inpatientNo">患者住院流水号</param>
		/// <returns></returns>
		public DataSet QueryExecUndrugOrderByInpatientNo(string inpatientNo) 
		{
			string strSql ="";  
			DataSet dataSet = new DataSet();

			//取SQL语句
			if (this.Sql.GetSql("Order.Report.ExecUndrugByInpatientNo",ref strSql) == -1) 
			{
				this.Err="没有找到Order.Report.ExecUndrugByInpatientNo字段!";
				return null;
			}
			try 
			{  
				strSql=string.Format(strSql, inpatientNo);    //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err="付数值时候出错Order.Report.ExecUndrugByInpatientNo！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}


		/// <summary>
		/// 根据住院流水号、药品编码、时间段检索患者累计用药情况  
		/// writed by liangjz 2005-06
		/// </summary>
		/// <param name="inpatientNo">住院流水号</param>
		/// <param name="drugCode">药品编码</param>
		/// <param name="myBeginTime">起始时间</param>
		/// <param name="myEndTime">终止时间</param>
		/// <returns>dataset</returns>
		public DataSet QueryTotalUseDrug(string inpatientNo,string drugCode,DateTime myBeginTime,DateTime myEndTime) 
		{
			string strSql = "";
			DataSet dataSet = new DataSet();
			
			//取SQL语句
			if (this.Sql.GetSql("Order.Report.TotalUseDrug",ref strSql) == -1) 
			{
				this.Err="没有找到Order.Report.TotalUseDrug字段!";
				return null;
			}
			try 
			{  
				strSql=string.Format(strSql, inpatientNo,drugCode,myBeginTime.ToString(),myEndTime.ToString());    //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err="付数值时候出错Order.Report.TotalUseDrug！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;			
		}
		/// <summary>
		/// 按照时间，最小费用，科室查询收费的药品信息
		/// </summary>
		/// <param name="minFee"></param>
		/// <param name="deptCode"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public DataSet QueryChargedMedicine(string minFee,string deptCode,string dtBegin,string dtEnd) 
		{
			string strSql = "";
			DataSet dsMedicine = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedMedicine",ref strSql) == -1) 
			{
				this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,minFee,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsMedicine);
			return dsMedicine;
		}
		/// <summary>
		/// 按照时间，最小费用，科室查询收费的非药品信息
		/// </summary>
		/// <param name="minFee"></param>
		/// <param name="deptCode"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public DataSet QueryChargedItem(string minFee,string deptCode,string dtBegin,string dtEnd) 
		{
			string strSql = "";
			DataSet dsItem = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedItem",ref strSql) == -1) 
			{
				this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,minFee,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsItem);
			return dsItem;
		}
		/// <summary>
		/// 按照时间，编码查询收费的药品明细信息
		/// </summary>
		/// <param name="code"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public DataSet QueryChargedMedicineDetail(string code,string deptCode,string dtBegin,string dtEnd) 
		{
			string strSql = "";
			DataSet dsMedicine = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedMedicineDetail",ref strSql) == -1) 
			{
				this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,code,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsMedicine);
			return dsMedicine;
		}
		/// <summary>
		/// 按照时间，编码查询收费的非药品明细信息
		/// </summary>
		/// <param name="code"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public DataSet QueryChargedItemDetail(string code,string deptCode,string dtBegin,string dtEnd) 
		{
			string strSql = "";
			DataSet dsItem = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedItemDetail",ref strSql) == -1) 
			{
				this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,code,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsItem);
			return dsItem;
		}
		#endregion 

		#region 判断出院带药单是否全部收费
		/// <summary>
		/// 判断出院带药单是否全部收费
		/// </summary>
		/// <param name="inpatient_no"></param>
		/// <returns></returns>
		public int IsCanPrintOutHosDrug(string inpatient_no,ref bool bReturn)
		{
			bReturn = false;
			string sql = "Order.ExecOrder.QueryIsCanPrintOutHosDrug";
			if(this.Sql.GetSql(sql,ref sql)==-1)
			{
				this.Err = "无法查到Order.ExecOrder.QueryIsCanPrintOutHosDrug";
				return -1;
			}
			try
			{
				sql = string.Format(sql,inpatient_no);
			}
			catch
			{
				this.Err = "Order.ExecOrder.QueryIsCanPrintOutHosDrug参数错误!";
				return -1;}
			int i= Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql));
			if(i<0)
			{

				return -1;
			}
			else if(i==0)
			{
				bReturn = true;//可以出院
				return 0;
			}
			else
			{
				return 0;
			}
		}
		#endregion

		#endregion 

		#region "医嘱审核保存"
		/// <summary>
		/// 审核医嘱 -审核未审核的和作废的医嘱
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
        public int ConfirmOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, bool IsCharge, System.DateTime dt)
		{
			#region 审核医嘱
			//审核医嘱，使医嘱处于有效状态
			//Order.Order.ConfirmOrder.1
			//传入：0 id,1 confirmcode,2 status 3confirmtime
			//传出：0 
			#endregion

			string strSql = "";
			if(order.Status == 0)//未审核的医嘱
			{
				if(this.Sql.GetSql("Order.Order.ConfirmOrder.1",ref strSql)==-1) return -1;
				//if(order.Item.IsPharmacy==false && IsCharge)//收费的非药品
                if (order.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug && IsCharge)//收费的非药品    
				{
					order.Status = 2;//给执行标记
				}
				else
				{
					order.Status = 1;//给审核标记
				}
			}
			else if(order.Status == 3)//停止作废医嘱
			{
				if(this.Sql.GetSql("Order.Order.ConfirmOrder.2",ref strSql)==-1) return -1;
			}
			else//其他
			{
                this.Err = Neusoft.FrameWork.Management.Language.Msg("医嘱状态不符合！不能审核！");
				return -1;
			}
			try//付值
			{
				strSql=string.Format(strSql,order.ID,this.Operator.ID,order.Status.ToString(),dt);
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.ConfirmOrder.1";
				this.WriteErr();
				return -1;
			}
			int intErr = 0;
			intErr =  this.ExecNoQuery(strSql);//执行医嘱
			if ( intErr == 0 )
			{
                this.Err = order.Item.Name + Neusoft.FrameWork.Management.Language.Msg(" 医嘱发生变化，不能审核！\n 请刷新界面重新检索医嘱信息！");
				return -1;
			}
			else if (intErr < 0)
			{
                this.Err = Neusoft.FrameWork.Management.Language.Msg("审核失败！");
				return -1;
			}
			return 1;

		}

		/// <summary>
		/// 审核医嘱处理（涉及执行档、收费接口由表现层完成）
		///(审核、执行本科室;通过是否收费更新收费标记）
		/// </summary>
		/// <param name="order"></param>
		/// <param name="isCharge"></param>
		/// <param name="execID"></param>
		/// <returns></returns>
        public int ConfirmAndExecOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, bool isCharge, string execID)
		{
			Neusoft.HISFC.Models.Base.Employee CurUser = new Neusoft.HISFC.Models.Base.Employee();
            CurUser = (Neusoft.HISFC.Models.Base.Employee)this.Operator;
            Neusoft.HISFC.Models.Order.ExecOrder objExec = new Neusoft.HISFC.Models.Order.ExecOrder();

			//赋值医嘱项目
			objExec.Order = order;
			
			//临期医嘱
			if (order.OrderType.IsDecompose == false) //临时医嘱
			{
				//执行科室是本护士站 或 不是终端批费
				if ((order.ExeDept.ID == order.Patient.PVisit.PatientLocation.Dept.ID ) || (JudgeItemType(objExec.Order) == "2" && 
						((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm == false ) )
				{
					//非药品 Order.OrderType.IsCharge == false
					if (JudgeItemType(objExec.Order) == "2" && 
						((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm == false )
					{
						//更新执行档执行标志
						objExec.IsExec = true;
						objExec.ExecOper.ID = CurUser.ID;
						objExec.Order.ExeDept.ID = order.ExeDept.ID;
						objExec.ExecOper.OperTime = dtCurTime;		
						//更新医嘱主档执行标志
						if (this.UpdateOrderExecuted(order.ID) < 0 ) return -1;
					}
				}

                //对不需要终端确认的 仍然需要对执行科室进行赋值
                objExec.ExecOper.ID = CurUser.ID;
                objExec.Order.ExeDept.ID = order.ExeDept.ID;
                objExec.ExecOper.Dept = order.ExeDept;
                objExec.ExecOper.OperTime = dtCurTime;	
				//----表现层记费----
				if (isCharge)
				{
					//更新执行档记帐标志
					objExec.IsCharge=true;
					objExec.ChargeOper.ID = CurUser.ID;
					objExec.ChargeOper.Dept.ID = CurUser.Dept.ID;
					objExec.ChargeOper.OperTime = dtCurTime;

                    //对于已收费项目 设置执行标记为已执行。
                    objExec.IsExec = true;
                    objExec.ExecOper.ID = CurUser.ID;
                    objExec.Order.ExeDept.ID = order.ExeDept.ID;
                    objExec.ExecOper.OperTime = dtCurTime;	
				}

				//插入执行档
				if(execID == "")
				{
					try{ objExec.ID =GetNewOrderExecID();}
					catch{}
				}
				else
				{
					objExec.ID = execID;
				}
				
				if(objExec.ID=="-1" || objExec.ID =="") return -1;
				

				if(JudgeItemType(objExec.Order) == "1" )//药品置执行标记
				{
					objExec.IsExec = true;
					objExec.ExecOper.ID = CurUser.ID;
					objExec.Order.ExeDept.ID = order.ExeDept.ID;
					objExec.ExecOper.OperTime = dtCurTime;	
					//药品存最小单位
					if(objExec.Order.Unit ==((Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item).MinUnit)//最小单位
					{
						
					}
					else
					{
						objExec.Order.Qty = objExec.Order.Qty * objExec.Order.Item.PackQty;;//变成最小单位
						objExec.Order.Unit = ((Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item).MinUnit;
					}
				}
				else//非药品
				{

				}

				objExec.IsValid = true;
				objExec.DateUse = order.BeginTime;
				objExec.DateDeco= dtCurTime;
				objExec.DrugFlag = 0; //默认为不需要发送
				
				if (this.InsertExecOrder(objExec) < 0 ) return -1;

			}
			
			//审核医嘱
			if (this.ConfirmOrder(order,isCharge,dtCurTime) < 0 ) return -1;
			return 0;
			
		}
        /// <summary>
        /// 重载审核函数
        /// </summary>
        /// <param name="order"></param>
        /// <param name="isCharge"></param>
        /// <param name="execID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int ConfirmAndExecOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, bool isCharge, string execID, DateTime dt)
        {
		    this.dtCurTime = dt;
			return this.ConfirmAndExecOrder(order,isCharge,execID);
		}
		#endregion

		#region "医嘱分解"

        #region  {DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
        /// <summary>
        /// 获取科室的分解时间
        /// </summary>
        /// <returns></returns>
        public int GetDecomposeTime()
        {
            //获取分解时间参数
            Neusoft.HISFC.BizLogic.Manager.Constant constantManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            Neusoft.FrameWork.Models.NeuObject constant = new Neusoft.FrameWork.Models.NeuObject();
            string deptCode = ((Neusoft.HISFC.Models.Base.Employee)controler.Operator).Dept.ID;
            try
            {
                constant = constantManager.GetConstant("SETEXECTIME", deptCode);
            }
            catch (Exception e)
            {
                this.Err = "获取分解时间出错~~" + e.Message.ToString();
                this.WriteErr();
                return 12;
            }
            if (constant.Memo == "")
            {
                return 12;
            }
            else
            {
                return Convert.ToInt32(constant.Memo);
            }
        }
        #endregion
		/// <summary>
		/// 分解时间
		/// </summary>
		/// <returns></returns>
		public void DecomposeTime( string nurseStationCode )
		{
			if ( nurseStationCode == strNurseStationCode)
			{

			}
			else //变化
            {
                //待更改
				controler.SetTrans(this.Trans);
                //{DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
                //string s = controler.QueryControlerInfo("200011");\
                string s = "";

				this.strNurseStationCode = nurseStationCode;
				if(s=="-1" || s=="") 
				{
                    //{DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
                    //iHour = 12;//默认12点
                    iHour = GetDecomposeTime();
					iMinute = 01;
					return;
				}
				iHour = Neusoft.FrameWork.Function.NConvert.ToDateTime(s).Hour;
				iMinute = Neusoft.FrameWork.Function.NConvert.ToDateTime(s).Minute;
			}
			return;
		}

        protected int iHour = 12;
		protected int iMinute = 1;
		protected string strNurseStationCode = "";
		public int iNum = 0;
		protected Neusoft.FrameWork.Management.ControlParam controler = new Neusoft.FrameWork.Management.ControlParam();
		DateTime dtCurTime = new DateTime();//系统时间
        /// <summary>
        /// {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF} 小时频次
        /// </summary>
        private string hourFerquenceID = "";

        /// <summary>
        /// {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF} 分解方法
        /// </summary>
        /// <param name="order"></param>
        /// <param name="days"></param>
        /// <param name="isCharge"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int DecomposeOrderToNow(Neusoft.HISFC.Models.Order.Inpatient.Order order, int days, bool isCharge, DateTime dt)
        {
            dtCurTime = dt;
            int myDays = 0;
            myDays = System.DateTime.Compare(order.NextMOTime.Date, dt.Date);
            return DecomposeOrder(order, days, isCharge);
        }


		/// <summary>
		/// 重载分解函数
		/// </summary>
		/// <param name="order"></param>
		/// <param name="days"></param>
		/// <param name="isCharge"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
        public int DecomposeOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, int days, bool isCharge, DateTime dt)
        {
		    //dtCurTime = dt;
            //{DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
            //dtCurTime = new DateTime(dt.Year,dt.Month,dt.Day,12,01,0);
            dtCurTime = new DateTime(dt.Year, dt.Month, dt.Day, GetDecomposeTime(), 01, 0);
			return DecomposeOrder(order,days,isCharge);
		}
		/// <summary>
		///  药、非药嘱分解
		///  Days分解天数IsCharge 是否收费
		/// </summary>
		/// <param name="order"></param>
		/// <param name="days">分解天数</param>
		/// <param name="isCharge">是否收费</param>
		/// <returns></returns>
        public int DecomposeOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, int days, bool isCharge)
        {
            Neusoft.HISFC.Models.Base.Employee CurUser = new Neusoft.HISFC.Models.Base.Employee();
            if (this.Operator == null)
            {
                this.Err = "当前操作员为空！";
                return -1;
            }

            //获得当前操作员			
            CurUser = (Neusoft.HISFC.Models.Base.Employee)this.Operator;

            //获得分解时间点
            iNum = iNum + 1;
            DecomposeTime(CurUser.Nurse.ID);
            Neusoft.HISFC.Models.Order.ExecOrder objExec = new Neusoft.HISFC.Models.Order.ExecOrder();

            //赋值医嘱项目
            objExec.Order = order;

            //分解时间
            DateTime dtCurDeco = dtCurTime;
            decimal DecAmount = -1;

            //长期、已生效、分解时间小于指定时间的医嘱和附材(嘱托长嘱分解不收费)
            if (order.OrderType.IsDecompose && (order.Status == 1 || order.Status == 2) && order.NextMOTime <= dtCurDeco.AddDays(days))//0开立，1 审核
            {
                int Cycle = 0;
                Cycle = System.Convert.ToInt16(order.Frequency.Days[0]);//循环时间 
                //-------计算每次用量--------	
                if (order.OrderType.IsCharge)
                {
                    //需要计费、药品医嘱需要根据药品取整规则计算
                    if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)//(order.Item.GetType().ToString() == "Neusoft.HISFC.Models.Pharmacy.Item")
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item objPharmacy;
                        objPharmacy = (Neusoft.HISFC.Models.Pharmacy.Item)order.Item;

                        DecAmount = ComputeAmount(objPharmacy.ID, objPharmacy.DosageForm.ID, order.DoseOnce, objPharmacy.BaseDose, order.Patient.PVisit.PatientLocation.Dept.ID);
                        if (DecAmount >= 0)
                        {
                            order.Item.Qty = DecAmount;
                        }
                    }
                    //不需计费、药品医嘱直接获得每次用量
                    //非药品（附材）直接获得每次执行数量		
                }

                if (order.Frequency.Days.Length > 1)//分解日期为星期
                {
                    Cycle = 1;
                }


                //结束时间
                DateTime dtTemp = dtCurDeco.AddDays(days);//+ Cycle - 1);
                DateTime dtEndTime;
                //{DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
                //int endHour = 12;
                int endHour = GetDecomposeTime();
                int endMinute = 01;

                bool bIsHaveDecompose = false;//{F1C96C96-F829-4ea1-AD07-10DBCC091C16}
                int iMOCount = 0;//分解插入执行档次数{F1C96C96-F829-4ea1-AD07-10DBCC091C16}
                //是否加发药时间？？？？？？
                //非药品，咐材第二天出单收费
                //if(order.Item.IsPharmacy == false && order.IsSubtbl ==false)//非药品，不是附材


                if (order.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug && order.IsSubtbl == false)//非药品，不是附材
                {
                    //{DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
                    //endHour = 12;//非药品时间（同药品分解时间）
                    endHour = GetDecomposeTime();
                    endMinute = 01;
                }
                else
                {
                    //如果非药品的附材，分解时间按非药品分解搞
                    if (order.ExtendFlag2 == ("【非药品附材标记】"))
                    {
                        //{DAE0F990-2FA5-4708-A3D8-B08CE0C6ADA7} 根据各自科室设定的时间来分解 made by guanyx
                        //endHour = 12;//非药品时间（同药品分解时间）
                        endHour = GetDecomposeTime();
                        endMinute = 01;
                    }
                    else//药品，药品附材按药品搞
                    {
                        endHour = iHour;
                        endMinute = iMinute;
                    }
                }


                //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF} 小时频次
                if (string.IsNullOrEmpty(this.hourFerquenceID) == true)
                {
                    this.hourFerquenceID = this.controler.QueryControlerInfo("200042", false);
                    if (string.IsNullOrEmpty(hourFerquenceID) == true)
                    {
                        this.hourFerquenceID = "NONE";
                    }
                }

                //计时医嘱分解时间到本次分解时间＋days
                if (order.Frequency.ID == this.hourFerquenceID)
                {
                    endHour = dtCurDeco.Hour;
                    endMinute = dtCurDeco.Minute;
                }

                dtEndTime = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, endHour, endMinute, 0);//默认分解到第二天 12:01

                //下次执行日期<指定的日期＋分解天数？
                int Count = System.Convert.ToInt16(new TimeSpan(order.NextMOTime.Date.Ticks - dtCurDeco.Date.Ticks).TotalDays);

                if (order.Frequency.Days.Length > 1)
                {
                    #region 分解医嘱为星期的
                    for (int i = 0; i <= days; i++)
                    {
                        for (int k = 1; k < order.Frequency.Days.Length; k++)//循环找星期
                        {
                            int week = dtCurTime.AddDays(i).DayOfWeek.GetHashCode();
                            if (week == 0) week = 7;
                            if (order.Frequency.Days[k] == week.ToString())//找到更新的
                            {
                                if (this.DecomposeTime(order, dtCurDeco, dtEndTime, isCharge, objExec, dtCurTime, CurUser, i) == -1)
                                {
                                    return -1;
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 分解医嘱为正常每天的
                    while (Count <= (days + Cycle - 1))
                    {
                        #region 分解时间
                        for (int i = 0; i <= order.Frequency.Times.GetUpperBound(0); i++)
                        {
                            DateTime dt = new DateTime();
                            try { dt = Neusoft.FrameWork.Function.NConvert.ToDateTime(order.Frequency.Times[i]); }
                            catch { }
                            if (dt.GetType().ToString() != "System.DateTime")
                            {
                                return -1;
                            }
                            DateTime dtUseTime = new DateTime(dtCurDeco.AddDays(Count).Year, dtCurDeco.AddDays(Count).Month, dtCurDeco.AddDays(Count).Day, dt.Hour, dt.Minute, dt.Second);
                            //服药时间>=下次执行日期and服药时间<分解结束时间？
                            if (dtUseTime >= order.CurMOTime && dtUseTime < dtEndTime)//wolf 更改了，不知道会不会死掉,必须靠唯一索引来锁重复记录Date_NexMO
                            {
                                //服药时间是否大于医嘱停止时间?
                                if (dtUseTime > order.EndTime && order.EndTime != DateTime.MinValue)
                                {
                                    //停止作废医嘱
                                    order.Status = 3;
                                    order.DCOper.OperTime = order.EndTime;
                                    if (DcOneOrder(order) < 0) return -1;
                                }
                                else
                                {
                                    //----表现层记费----
                                    if (isCharge)
                                    {
                                        //更新执行档记帐标志
                                        objExec.IsCharge = true;
                                        objExec.ChargeOper.ID = CurUser.ID;
                                        objExec.ChargeOper.Dept.ID = CurUser.Dept.ID;
                                        objExec.ChargeOper.OperTime = dtCurTime;
                                    }
                                    //插入执行档
                                    try { objExec.ID = GetNewOrderExecID(); }
                                    catch { }
                                    if (objExec.ID == "-1" || objExec.ID == "") return -1;
                                    objExec.IsValid = true;
                                    objExec.DateUse = dtUseTime;
                                    objExec.DateDeco = dtCurTime;
                                    objExec.DrugFlag = 0; //默认为不需要发送

                                    if (objExec.Order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))//药品
                                    {
                                        try
                                        {   //数量通过基本剂量找最小单位便于计算费用
                                            //原程序判断的Frequency.User01 更改为使用 ExecDose属性
                                            //if(objExec.Order.Frequency.User01 != "" && objExec.Order.Frequency.User01 != null) //特殊频次
                                            if (objExec.Order.ExecDose != "" && objExec.Order.ExecDose != null) //特殊频次
                                            {
                                                string[] tempDoseOnce = objExec.Order.ExecDose.Split('-');
                                                decimal tempDoseOnceDec = Convert.ToDecimal(tempDoseOnce[i]);
                                                objExec.Order.Qty = tempDoseOnceDec / ((Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item).BaseDose;
                                                //修正长嘱分解出现小于最小单位的零头问题 {276ED20A-E9FD-495f-BFE2-6F38265982BF} wbo 2010-10-21
                                                if (objExec.Order.Qty % 1 != 0)
                                                {
                                                    objExec.Order.Qty = decimal.Ceiling(objExec.Order.Qty);
                                                }
                                                objExec.Order.DoseOnce = tempDoseOnceDec;
                                                if (objExec.Order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)//(objExec.Order.Item.GetType().ToString() == "Neusoft.HISFC.Models.Pharmacy.Item")
                                                {
                                                    decimal decAmount = 0;
                                                    Neusoft.HISFC.Models.Pharmacy.Item objPharmacy;
                                                    objPharmacy = (Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item;

                                                    decAmount = ComputeAmount(objPharmacy.ID, objPharmacy.DosageForm.ID, tempDoseOnceDec, objPharmacy.BaseDose, order.Patient.PVisit.PatientLocation.Dept.ID);
                                                    if (decAmount >= 0)
                                                    {
                                                        objExec.Order.Item.Qty = decAmount;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (DecAmount != -1)
                                                    objExec.Order.Qty = DecAmount;
                                                else
                                                {
                                                    objExec.Order.Qty = objExec.Order.DoseOnce / ((Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item).BaseDose;
                                                    //修正长嘱分解出现小于最小单位的零头问题 {276ED20A-E9FD-495f-BFE2-6F38265982BF} wbo 2010-10-21
                                                    if (objExec.Order.Qty % 1 != 0)
                                                    {
                                                        objExec.Order.Qty = decimal.Ceiling(objExec.Order.Qty);
                                                    }
                                                }
                                            }
                                            objExec.Order.Unit = ((Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item).MinUnit;
                                        }
                                        catch
                                        {
                                            this.Err = "剂量为零。";
                                            this.WriteErr();
                                        }
                                    }
                                    //插入执行档
                                    if (this.InsertExecOrder(objExec) == -1)
                                    {
                                        if (this.DBErrCode != 1) return -1;
                                    }
                                    iMOCount++;//{F1C96C96-F829-4ea1-AD07-10DBCC091C16}分解次数
                                    bIsHaveDecompose = true;//{F1C96C96-F829-4ea1-AD07-10DBCC091C16}
                                }
                            }
                        }
                        #endregion
                        Count = Count + Cycle;
                    }
                    #endregion
                }

                //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                //将医嘱置下次分解时间Days + Cycle
                if (days < Cycle)
                {
                    if (days == 0)
                    {
                        //只分解到当天,下次分解时间赋成当天,
                    }
                    else
                    {
                        days = Cycle;
                    }
                }

                order.CurMOTime = dtCurDeco;
                DateTime dtNex = new DateTime();

                if (Cycle > 1)
                    //{F1C96C96-F829-4ea1-AD07-10DBCC091C16}修改QOD（20）问题
                    if (bIsHaveDecompose)
                    {
                        //如果频次的基本天数〉1医嘱的下次分解时间应该加上（本次分解次数*频次的基本天数）天

                        dtNex = order.NextMOTime.AddDays(iMOCount * Cycle);
                    }
                    else
                    {
                        dtNex = order.NextMOTime;
                    }
                else
                    dtNex = dtCurDeco.AddDays(days);

                order.NextMOTime = new DateTime(dtNex.Year, dtNex.Month, dtNex.Day, endHour, endMinute, 0);//

                //更新分解时间（本次，下次）
                if (UpdateDecoTime(order) <= 0) return -1;
            }
            return 0;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="order"></param>
		/// <param name="dtCurDeco"></param>
		/// <param name="dtEndTime"></param>
		/// <param name="isCharge"></param>
		/// <param name="objExec"></param>
		/// <param name="dtCurTime"></param>
		/// <param name="curUser"></param>
		/// <param name="addDays"></param>
		/// <returns></returns>
        private int DecomposeTime(Neusoft.HISFC.Models.Order.Inpatient.Order order, DateTime dtCurDeco, DateTime dtEndTime, bool isCharge, Neusoft.HISFC.Models.Order.ExecOrder objExec, DateTime dtCurTime, Neusoft.HISFC.Models.Base.Employee curUser, int addDays)
		{
			#region 分解时间
			for (int i=0;i<=order.Frequency.Times.GetUpperBound(0);i++)
			{
				DateTime dt = new DateTime();	
				try{dt =Neusoft.FrameWork.Function.NConvert.ToDateTime(order.Frequency.Times[i]);}
				catch{}
				if (dt.GetType().ToString() != "System.DateTime") 
				{
					return -1;
				}
				DateTime dtUseTime = new DateTime(dtCurDeco.AddDays(addDays).Year,dtCurDeco.AddDays(addDays).Month,dtCurDeco.AddDays(addDays).Day,dt.Hour,dt.Minute,dt.Second);
				//服药时间>=下次执行日期and服药时间<分解结束时间？
				if ( dtUseTime >= order.NextMOTime  && dtUseTime < dtEndTime)
				{
					//服药时间是否大于医嘱停止时间?
					if (dtUseTime > order.EndTime  && order.EndTime !=DateTime.MinValue)
					{
						//停止作废医嘱
						order.Status = 3;
						order.DCOper.OperTime = order.EndTime;
						if (DcOneOrder(order) < 0) return 0;
					}
					else
					{
						//----表现层记费----
						if (isCharge)
						{
							//更新执行档记帐标志
							objExec.IsCharge=true;
							objExec.ChargeOper.ID = curUser.ID;
							objExec.ChargeOper.Dept.ID = curUser.Dept.ID;
							objExec.ChargeOper.OperTime = dtCurTime;
						}
						//插入执行档
						try{ objExec.ID =GetNewOrderExecID();}
						catch{}
						if(objExec.ID=="-1" || objExec.ID =="") return 0;
						objExec.IsValid = true;
						objExec.DateUse = dtUseTime;
						objExec.DateDeco= dtCurTime;
						objExec.DrugFlag = 0; //默认为不需要发送
								
						if(objExec.Order.Item.GetType()== typeof(Neusoft.HISFC.Models.Pharmacy.Item))//药品
						{
							try
							{   //数量通过基本剂量找最小单位便于计算费用
								objExec.Order.Qty = objExec.Order.DoseOnce / ((Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item).BaseDose;
                                //修正长嘱分解出现小于最小单位的零头问题 {276ED20A-E9FD-495f-BFE2-6F38265982BF} wbo 2010-10-21
                                if (objExec.Order.Qty % 1 != 0)
                                {
                                    objExec.Order.Qty = decimal.Ceiling(objExec.Order.Qty);
                                }
								objExec.Order.Unit = ((Neusoft.HISFC.Models.Pharmacy.Item)objExec.Order.Item).MinUnit;
							}
							catch
							{
								this.Err = Neusoft.FrameWork.Management.Language.Msg("剂量为零。");
								this.WriteErr();}
						}
						if (this.InsertExecOrder(objExec) < 0 ) return 0;
					}
				}
			}
			return 0;
			#endregion
		}
		/// <summary>
		/// 获得分解取整标准
		/// </summary>
		/// <param name="drugCode"></param>
		/// <param name="doseCode"></param>
		/// <param name="doseOnce"></param>
		/// <param name="baseDose"></param>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public decimal ComputeAmount( string drugCode, string doseCode, decimal doseOnce, decimal baseDose, string deptCode )
		{
			#region 获得分解取整标准
			//获得分解取整标准
			//Order.Order.ComputeAmount.1
			//传入：0 DrugCode
			//传出：0 UNIT_STAT
			#endregion		

            #region {AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
            //性能优化
            string UnitSate = string.Empty;

            if (htDrugedProperty.Contains(drugCode + deptCode))
            {
                UnitSate = htDrugedProperty[drugCode + deptCode].ToString();
            }
            else
            {
                UnitSate = this.GetDrugProperty(drugCode, doseCode, deptCode);

                htDrugedProperty.Add(drugCode + deptCode, UnitSate);
            }
            #endregion

            decimal Amount=0;
			if(baseDose==0) return Amount;
			switch (UnitSate)
			{
				case "0"://不可以，向上取整
                    //Amount = (decimal)System.Math.Ceiling((decimal)doseOnce / (decimal)baseDose);
                    Amount = (decimal)System.Math.Ceiling((double)((decimal)doseOnce / (decimal)baseDose));
					break;
				case "1"://可以，配药时不取整
					Amount=System.Convert.ToDecimal(doseOnce) / baseDose;
					break;
				case "2"://可以，配药时上取整 
					Amount=System.Convert.ToDecimal(doseOnce) / baseDose;
					break;
				default://
					Amount=System.Convert.ToDecimal(doseOnce) / baseDose;
					break;
			}
			return Amount;
		}
		/// <summary>
		/// 获取药品配药属性
		/// </summary>
		/// <param name="drugCode">药品编码</param>
		/// <param name="deptCode">科室编码</param>
		/// <returns>成功返回配药属性 0 不可拆分 1 可拆分不取整 2 可拆分上取整，失败返回NULL</returns>
		public string GetDrugProperty(string drugCode,string doseCode,string deptCode) 
		{
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Pharmacy.Item.GetDrugProperty",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.Item.GetDrugProperty字段!";
				return null;
			}

			//格式化SQL语句
			try 
			{
				strSQL = string.Format(strSQL, drugCode, doseCode,deptCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Pharmacy.Item.GetDrugProperty:" + ex.Message;
				return null;
			}		

			//执行查询语句
			if (this.ExecQuery(strSQL)==-1) 
			{
				this.Err="获得配药属性信息时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			string drugProperty = "";
			if ( this.Reader.Read()) 
			{
				drugProperty = this.Reader[0].ToString();
			}
			else 
			{
				drugProperty = "0";
			}
			this.Reader.Close();
			return drugProperty;
		}
        
		/// <summary>
		/// 更新分解时间（本次，下次）
		/// </summary>
		/// <param name="order">医嘱id,(本次，下次)分解时间</param>
		/// <returns></returns>
        public int UpdateDecoTime(Neusoft.HISFC.Models.Order.Order order)
		{
			#region 更新分解时间
			//更新分解时间
			//Order.Order.UpdateDecoTime.1
			//传入：0 orderID 1 Date_CurMO 2 Date_NexMO
			//传出：0 
			#endregion
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.UpdateDecoTime.1",ref strSql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,order.ID,order.CurMOTime.ToString(),order.NextMOTime.ToString());
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.UpdateDecoTime.1";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 下次分解时间
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="days">+_天数</param>
		/// <returns></returns>
		public int UpdateDecoTime( string inpatientNo, int days )
		{
			#region 更新分解时间
			//更新分解时间
			//Order.Order.UpdateDecoTime.2
			//传入：0 inpatientNo 1 days
			//传出：0 
			#endregion
			string strSql="";
			if(this.Sql.GetSql("Order.Order.UpdateDecoTime.2",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				if(days>0)
					strSql=string.Format(strSql,inpatientNo,"+"+days.ToString());
				else
					strSql=string.Format(strSql,inpatientNo,days.ToString());
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.UpdateDecoTime.2";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 下次分解时间
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="nextDecoDateTime">下次分解时间</param>
		/// <returns></returns>
		public int UpdateDecoTime(string inpatientNo,DateTime nextDecoDateTime)
		{
			string strSql="";
			if(this.Sql.GetSql("Order.Order.UpdateDecoTime.3",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,inpatientNo,nextDecoDateTime.ToString());
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.UpdateDecoTime.3";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

        #region {AD50C155-BE2D-47b8-8AF9-4AF3548A2726}

        /// <summary>
        /// 配药属性表
        /// </summary>
        private Hashtable htDrugedProperty = new Hashtable();

        /// <summary>
        /// 为了优化性能整合的医嘱分解保存时更新药品执行档用的函数
        /// </summary>
        /// <param name="execOrder">药品执行档</param>
        /// <returns></returns>
        public int UpdateForConfirmExecDrug(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.Order.UpdateForConfirmExecDrug.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, execOrder.ID,//执行档ID
                                         execOrder.DrugFlag,//药品发送标记
                                         execOrder.ChargeOper.ID,//记账人代码
                                         execOrder.ChargeOper.Dept.ID,//记账科室代码
                                         execOrder.ChargeOper.OperTime.ToString(),//记账时间
                                         Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsCharge).ToString(),//记账标记
                                         execOrder.Order.ReciptNO,//处方号
                                         execOrder.Order.SequenceNO,//处方流水号 
                                         execOrder.ExecOper.ID, //执行护士代码
                                         execOrder.Order.ExeDept.ID, //执行科室代码
                                         execOrder.ExecOper.OperTime.ToString(), //执行时间
                                         Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsExec).ToString());//执行标记
            }
            catch
            {
                this.Err = "传入参数不对！Order.Order.UpdateForConfirmExecDrug.1";
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 为了优化性能整合的医嘱分解保存时更新非药品执行档用的函数
        /// </summary>
        /// <param name="execOrder">非药品执行档</param>
        /// <returns></returns>
        public int UpdateForConfirmExecUnDrug(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.Order.UpdateForConfirmExecUnDrug.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, execOrder.ID,//执行档ID
                                       execOrder.ChargeOper.ID,//记账人代码
                                       execOrder.ChargeOper.Dept.ID,//记账科室代码
                                       execOrder.ChargeOper.OperTime.ToString(),//记账时间
                                       Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsCharge).ToString(),//记账标记
                                       execOrder.Order.ReciptNO,//处方号
                                       execOrder.Order.SequenceNO,//处方流水号 
                                       execOrder.ExecOper.ID, //执行护士代码
                                       execOrder.Order.ExeDept.ID, //执行科室代码
                                       execOrder.ExecOper.OperTime.ToString(), //执行时间
                                       Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsExec).ToString(),//执行标记
                                       Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsConfirm).ToString());//更新确认标记
                
            }
            catch
            {
                this.Err = "传入参数不对！Order.Order.UpdateForConfirmExecUnDrug.1";
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        #endregion

		#endregion

		#region "医嘱停止处理"
		/// <summary>
		/// 停止医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="sysClass"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		public int DcOrder(string inpatientNo,Neusoft.HISFC.Models.Base.SysClassEnumService sysClass,DateTime dt)
		{
			ArrayList al = new ArrayList();
			DateTime dtBegin = new DateTime(2005,1,1);
			al = this.QueryOrder(inpatientNo,dtBegin,dt);
			if(al ==null) return -1;
			foreach(Neusoft.HISFC.Models.Order.Inpatient.Order order in al)
			{
				if(order.Status ==1 || order.Status == 0 )//有效，非作废,非执行医嘱。
				{
					if(sysClass == null)//全部都停止
					{	
						order.Status =3;
						order.DCOper.OperTime =dt;
						order.DCOper.ID  = this.Operator.ID ;
						order.DCOper.Name = this.Operator.Name;
						order.DcReason.ID ="0";
						if(order.OrderType.IsDecompose)
						{
							if(this.DcOneOrder(order)==-1) 
							{
								return -1;
							}
						}
					}
					else //类别停止 //停止指定的长期医嘱  如：护理等等。
					{
						if(order.Item.SysClass.ID.ToString() == sysClass.ID.ToString() && order.OrderType.IsDecompose)
						{
							order.Status =3;
							order.DCOper.OperTime  =dt;
							order.DCOper.ID  = this.Operator.ID ;
							order.DCOper.Name = this.Operator.Name;
							order.DcReason.ID ="0";
							if(this.DcOneOrder(order)==-1) 
							{
								return -1;
							}
						}
					}
				}
			}
			this.Err ="医嘱停止成功！";
			return 0;
		}
		/// <summary>
		/// 停止医嘱
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		public int DcOrder(string inpatientNo,DateTime dt)
		{
			return DcOrder(inpatientNo,null,dt);
		}
		/// <summary>
		/// 停止医嘱处理（包括直接停止，预停止）
		/// 停止原因Order.DcReason
		/// </summary>
		/// <param name="order"></param>
		/// <param name="isAllDc">组合医嘱是否全部停止</param>
		/// <param name="ReturnMemo">返回医嘱原始状态</param>
		/// <returns></returns>
        public int DcOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, bool isAllDc, out string ReturnMemo)
		{
			//返回医嘱执行情况
			ReturnMemo = "";
			if (order.Status == 2  )
			{
				ReturnMemo = "该条医嘱已经已经执行，请确认后退费！";
			}
			//是否是组合医嘱
			ArrayList al = new ArrayList();
			al = this.QueryOrderByCombNO(order.Combo.ID,false);
			//是否是组合医嘱
			if (al.Count > 1)
			{
				//是否停止组合项目中的单项
				if (isAllDc)
				{
					for (int i=0;i<al.Count;i++)
					{
                        Neusoft.HISFC.Models.Order.Inpatient.Order obj;
                        obj = (Neusoft.HISFC.Models.Order.Inpatient.Order)al[i];
						//本记录在下面处理
						if (obj.ID == order.ID) continue;
                        //执行单条医嘱DC
                        #region {D028C0B7-014F-4c60-883D-B49A0BD3399A}
                        obj.DCOper = order.DCOper;
                        obj.DcReason = order.DcReason;
                        #endregion
                        if (DcOneOrderDeal(obj) < 0) return -1;
					}
				}	    
				else
				{
					//是否主药
					if (order.Combo.IsMainDrug)
					{
						//主药医嘱不能单条DC
						this.Err = "不能单独作废主药医嘱！";
						return -1;
					}
				}
			}
			//else非组合项目执行单条医嘱作废
			//执行单条医嘱DC
			if (DcOneOrderDeal(order) < 0) return -1;
			return 0;

		}
		/// <summary>
		/// 根据患者住院号、系统类别和停止原因，停止患者此大类的医嘱主档。如果没有大类则还要停止医嘱执行档
		/// 0 患者住院流水号，1 系统类别，2停止时间 ,3停止原因代码，4停止原因名称 
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="sysClassCode"></param>
		/// <param name="dcDate"></param>
		/// <param name="dcReasonCode"></param>
		/// <param name="dcReasonName"></param>
		/// <returns></returns>
		public int DcOrder( string inpatientNo, string sysClassCode, DateTime dcDate, string dcReasonCode, string dcReasonName ) 
		{
			string strSql="";
			//停止医嘱主档
			if(this.Sql.GetSql("Order.Order.DcOrder.All",ref strSql)==-1) {
				this.Err = "找不到SQL语句:Order.Order.DcOrder.All";
				return -1;
			}
			try {
				strSql=string.Format(   strSql, 
										inpatientNo,        //患者住院流水号
										sysClassCode,       //系统类别
										dcDate.ToString(),  //停止日期
										dcReasonCode,       //停止原因代码
										dcReasonName,       //停止原因名称
										this.Operator.ID,   //停止人
										this.Operator.Name  //停止人姓名
									);
			}
			catch {
				this.Err="传入参数不对！Order.Order.DcOrder.All";
				return -1;
			}
			int parm = this.ExecNoQuery(strSql);
			if (parm == -1) return -1;

			//如果sysClassCode有效（不等于"00"），则只按大类停止医嘱，不处理执行档数据，否则停止执行档
			if (sysClassCode == "00") {
				//停止药品医嘱执行档
				if(this.Sql.GetSql("Order.ExecOrder.DcExecAll.Drug",ref strSql)==-1) {
					this.Err = "找不到SQL语句:Order.ExecOrder.DcExecAll.Drug";
					return -1;
				}
				try {
					strSql=string.Format(strSql, inpatientNo, dcDate.ToString(), this.Operator.ID, dcReasonName);
				}
				catch {
					this.Err="传入参数不对！Order.ExecOrder.DcExecAll.Drug";
					return -1;
				}
				parm = this.ExecNoQuery(strSql);
				if (parm == -1) return -1;

				//停止非药品医嘱执行档
				if(this.Sql.GetSql("Order.ExecOrder.DcExecAll.Undrug",ref strSql)==-1) {
					this.Err = "找不到SQL语句:Order.ExecOrder.DcExecAll.Undrug";
					return -1;
				}
				try {
					strSql=string.Format(strSql, inpatientNo, dcDate.ToString(), this.Operator.ID, dcReasonName);
				}
				catch {
					this.Err="传入参数不对！Order.ExecOrder.DcExecAll.Undrug";
					return -1;
				}
				parm = this.ExecNoQuery(strSql);
				if (parm == -1) return -1;
			}

			return parm;
		}

		/// <summary>
		/// /// 根据患者住院号和停止原因，停止患者所有医嘱主档和医嘱执行档
		/// </summary>
		/// <param name="inpatientNo">0 患者住院流水号,1 停止时间 ,2 停止原因代码，3 停止原因名称 </param>
		/// <param name="dcDate"></param>
		/// <param name="dcReasonCode"></param>
		/// <param name="dcReasonName"></param>
		/// <returns></returns>
		public int DcOrder( string inpatientNo, DateTime dcDate, string dcReasonCode, string dcReasonName ) 
		{
			return this.DcOrder(inpatientNo, "00", dcDate, dcReasonCode, dcReasonName);
		}

		/// <summary>
		/// 执行单条医嘱DC操作
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
        private int DcOneOrderDeal(Neusoft.HISFC.Models.Order.Inpatient.Order order)
		{
			//提取系统时间
			DateTime CurTime =this.GetDateTimeFromSysDateTime();
			//立即停止（临时医嘱 or 停止时间小于等于当前时间）
			if (order.OrderType.IsDecompose == false || order.EndTime <= CurTime) 
			{
				//置作废标记
				order.Status = 3;
				if (this.DcExecImmediate(order,this.Operator) <  0) 
				{
                    this.Err = Neusoft.FrameWork.Management.Language.Msg("作废医嘱执行信息失败！");
					return -1;
				}
			}
			//预停止（长期医嘱并且停止时间大于等于当前时间）
			else
			{
				if (this.DcExecLater(order,this.Operator,order.EndTime) <  0) 
				{
                    this.Err = Neusoft.FrameWork.Management.Language.Msg("作废医嘱执行信息失败！");
					return -1;
				}
			}
			//执行停止医嘱挡
			if (this.DcOneOrder(order) < 0 ) 
			{
                this.Err = Neusoft.FrameWork.Management.Language.Msg("停止医嘱失败！");
				return -1;
			}
			//药嘱
			//if (order.Item.IsPharmacy)
            if(order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
			{
				//计算退药数量
			}
			//非药嘱
			else
			{
				//停止护理项目，更新护理级别
				//计算退费数量

			}
			return 0;
		}
		/// <summary>
        /// 按组合号查询医嘱
        /// 按照数据库的SQL语句来看，目前isSubtbl参数没用了
		/// </summary>
		/// <param name="combno">组合号</param>
		/// <param name="isSubtbl">按照数据库的SQL语句来看，目前这个参数没用了</param>
		/// <returns></returns>
		public ArrayList QueryOrderByCombNO( string combno, bool isSubtbl )
		{
			#region 按状态查询医嘱
			//按组合号查询医嘱
			//Order.Order.QueryOrderByCombno.where.1
			//传入：0 combno 1 IsSub
			//传出：ArrayList
			#endregion
			string sql = "",sql1 = "";
			ArrayList al = new ArrayList();
			sql = OrderQuerySelect();
			if (sql == null ) return null;
			if(this.Sql.GetSql("Order.Order.QueryOrderByCombno.where.1",ref sql1) == -1)
			{
				this.Err="没有找到Order.Order.QueryOrderByCombno.where.1字段!";
				return null;
			}
			sql= sql +" " +string.Format(sql1,combno,isSubtbl.ToString());
			return this.myOrderQuery(sql);

		}

		#endregion

        #region 配液信息

        /// <summary>
        /// 检索待配液信息
        /// </summary>
        /// <param name="isNurse">是否按病区检索 即deptCode传入为病区编码</param>
        /// <param name="deptCode">科室</param>
        /// <param name="dtBegin">开始执行时间</param>
        /// <param name="dtEnd">终止执行时间</param>
        /// <param name="isExec">状态 是否查询已配液的</param>
        /// <returns>成功返回待配液信息 失败返回null</returns>
        public ArrayList QueryExecOrderForCompound(bool isNurse,string deptCode, DateTime dtBegin, DateTime dtEnd,bool isExec)
        {
            string[] s;
            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();

            s = ExecOrderQuerySelect("1");
            sql = s[0];
            if (sql == null)
            {
                return null;
            }

            if (isNurse)
            {
                if (this.Sql.GetSql("Order.QueryOrderExecCompound.NurseCell", ref sql1) == -1)
                {
                    this.Err = "没有找到Order.QueryOrderExecCompound.NurseCell字段!";
                    return null;
                }
            }
            else
            {
                if (this.Sql.GetSql("Order.QueryOrderExecCompound.DeptCode", ref sql1) == -1)
                {
                    this.Err = "没有找到Order.QueryOrderExecCompound.DeptCode字段!";
                    return null;
                }
            }

            string state = "0";
            if (isExec)
            {
                state = "1";
            }
            else
            {
                state = "0";
            }

            sql = sql + " " + string.Format(sql1, deptCode,dtBegin.ToString(),dtEnd.ToString(),state);

            return this.myExecOrderQuery(sql);
        }

        /// <summary>
        /// 配液信息更新
        /// </summary>
        /// <param name="execOrderID">执行挡流水号</param>
        /// <param name="compound">配液信息</param>
        /// <returns>成功返回1 失败返回-1 无记录更新返回0</returns>
        public int UpdateOrderCompound(string execOrderID, Neusoft.HISFC.Models.Order.Compound compound)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.ExecOrder.UpdateOrderCompound", ref strSql) == -1)
            {
                this.Err = "没有找到Order.ExecOrder.UpdateOrderCompound字段";
                return -1;
            }
            strSql = string.Format(strSql, execOrderID,
                                           Neusoft.FrameWork.Function.NConvert.ToInt32(compound.IsExec).ToString(),
                                           compound.CompoundOper.ID,compound.CompoundOper.Dept.ID,
                                           compound.CompoundOper.OperTime.ToString());

            return this.ExecNoQuery(strSql);
        }

        #endregion

        #region 互斥
        /// <summary>
		/// 获得互斥
		/// </summary>
		/// <param name="sysClassID"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Order.EnumMutex QueryMutex( string sysClassID )
		{
			string sql = "";
			Neusoft.HISFC.Models.Order.EnumMutex mutex = Neusoft.HISFC.Models.Order.EnumMutex.None;
			if(this.Sql.GetSql("Order.QueryMutex.1",ref sql) == -1) 
			{
				this.Err = this.Sql.Err;
				return mutex;
			}
			sql = string.Format(sql,sysClassID);
			string strMutex ="";
			strMutex = this.ExecSqlReturnOne(sql);
			try
			{
				mutex = (Neusoft.HISFC.Models.Order.EnumMutex)Neusoft.FrameWork.Function.NConvert.ToInt32(strMutex);
				return mutex;
			}
			catch
			{
				return mutex;
			}
		}
		#endregion

		#region 私有函数
		
		/// <summary>
		/// 获得项目集合
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		private ArrayList myGetOutHosCure(string strSql) 
		{
			ArrayList al = new ArrayList();
			if(this.ExecQuery(strSql) == -1) return null;
			while(this.Reader.Read()) 
			{
				Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList item = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
				try 
				{
					item.Name = this.Reader[0].ToString();//项目名称
					item.Item.Price = System.Convert.ToDecimal(this.Reader[1].ToString());//价格
					item.Order.Qty = System.Convert.ToDecimal(this.Reader[2].ToString());//总量
					item.Order.Unit = this.Reader[3].ToString();//单位
					item.Order.ExeDept.ID = this.Reader[4].ToString();//执行科室
					item.User01 = this.Reader[5].ToString();//执行序号
				}
				catch(Exception ex) 
				{
					this.Err="获得检查单信息出错！"+ex.Message;
					this.WriteErr();
					return null;	   
				}
				al.Add(item);	 
			}
			this.Reader.Close();
			return al;
		}

		/// <summary>
		/// 获得医嘱信息
		/// </summary>
		/// <param name="sqlOrder"></param>
		/// <param name="Order"></param>
		/// <returns></returns>
        private string getOrderInfo(string sqlOrder, Neusoft.HISFC.Models.Order.Inpatient.Order Order)
		{
			#region "接口说明"
			//0 ID医嘱流水号
			//患者信息——  
			//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
			//医嘱辅助信息
			// ——项目信息
			//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
			//	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
			//         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
			//         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
			//         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
			// ——医嘱属性
			//		   30医嘱类别代码 31医嘱类别名称  32医嘱是否分解:1长期/2临时     33是否计费 
			//		   34药房是否配药 35打印执行单    36是否需要确认  
			// ——执行情况
			//		   37开立医师Id   38开立医师name  39开始时间      40结束时间     41开立科室
			//		   42开立时间     43录入人员代码  44录入人员姓名  45审核人ID     46审核时间       
			//		   47DC原因代码   48DC原因名称    49DC医师代码    50DC医师姓名   51Dc时间
			//         52执行人员代码 53执行时间      54执行科室代码  55执行科室名称 
			//		   56本次分解时间 57下次分解时间
			// ——医嘱类型
			//		   58是否婴儿（1是/2否）          59发生序号  	  60组合序号     61主药标记 
			//		   62是否附材'1'  63是否包含附材  64医嘱状态      65扣库标记     66执行标记1未执行/2已执行/3DC执行 
			//		   67医嘱说明                     68加急标记:1普通/2加急         69排列序号
			//         70检查部位备注                 71批注          72整档,          73 样本类型/检查部位名称,
			//         74 取药药房编码 
			#endregion 
			string strItemType= "";
			if(Order.CurMOTime==DateTime.MinValue)
			{
				Order.CurMOTime = Order.BeginTime ;
			}
			if(Order.NextMOTime  ==DateTime.MinValue)
			{
				Order.NextMOTime = Order.BeginTime;
			}
			//判断药品/非药品
		   
			if (Order.Item.GetType()== typeof(Neusoft.HISFC.Models.Pharmacy.Item))
			{
				Neusoft.HISFC.Models.Pharmacy.Item objPharmacy ;
				objPharmacy = (Neusoft.HISFC.Models.Pharmacy.Item)Order.Item;
				strItemType = "1";
				try
				{
					System.Object[] s={Order.ID,Order.Patient.ID,Order.Patient.PID.PatientNO,Order.Patient.PVisit.PatientLocation.Dept.ID,Order.Patient.PVisit.PatientLocation.NurseCell.ID,
										  strItemType,Order.Item.ID,Order.Item.Name,Order.Item.UserCode,Order.Item.SpellCode,
										  Order.Item.SysClass.ID.ToString(),Order.Item.SysClass.Name,objPharmacy.Specs,objPharmacy.BaseDose,objPharmacy.DoseUnit,objPharmacy.MinUnit,objPharmacy.PackQty,
										  objPharmacy.DosageForm.ID,objPharmacy.Type.ID,objPharmacy.Quality.ID,objPharmacy.PriceCollection.RetailPrice,
										  Order.Usage.ID,Order.Usage.Name,Order.Usage.Memo,Order.Frequency.ID,Order.Frequency.Name,
										  Order.DoseOnce,Order.Qty,Order.Unit,Order.HerbalQty.ToString(),
										  Order.OrderType.ID,Order.OrderType.Name,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsDecompose),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsCharge),
										  Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsNeedPharmacy),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsPrint),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsConfirm),
										  Order.ReciptDoctor.ID,Order.ReciptDoctor.Name,Order.BeginTime,Order.EndTime,Order.ReciptDept.ID,
										  Order.MOTime,Order.Oper.ID,Order.Oper.Name,Order.Nurse.ID,Order.ConfirmTime,
										  Order.DcReason.ID,Order.DcReason.Name,Order.DCOper.ID,Order.DCOper.Name,Order.DCOper.OperTime,
										  Order.ExecOper.ID,Order.ExecOper.OperTime,Order.ExeDept.ID,Order.ExeDept.Name,
										  Order.CurMOTime,Order.NextMOTime,
										  Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsBaby),Order.BabyNO,Order.Combo.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Combo.IsMainDrug),
										  Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsSubtbl),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsHaveSubtbl),Order.Status,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsStock),Order.ExecStatus,
										  Order.Note,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsEmergency),Order.SortID,Order.Memo,Order.CheckPartRecord,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Reorder),Order.Sample.Name,Order.StockDept.ID,
										  objPharmacy.IsAllergy==true ?"2":"1",Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsPermission),Order.Package.ID,Order.Package.Name,Order.ExtendFlag1,Order.ExtendFlag2,Order.ExtendFlag3,
                                          Order.Frequency.Time,Order.ExecDose,Order.ApplyNo};//新加特殊频次
		
					string myErr = "";
					if(Neusoft.FrameWork.Public.String.CheckObject(out myErr,s)==-1)
					{
						this.Err = myErr;
						this.WriteErr();
						return null;
					}
					sqlOrder=string.Format(sqlOrder,s);
				}
				catch(Exception ex)
				{
					this.Err="付数值时候出错！"+ex.Message;
					this.WriteErr();
					return null;
				}
			}
			else if (Order.Item.GetType()== typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
			{
				Neusoft.HISFC.Models.Fee.Item.Undrug objAssets;
				objAssets = (Neusoft.HISFC.Models.Fee.Item.Undrug)Order.Item;
				strItemType = "2";
				
				try
				{
					string[] s={Order.ID,Order.Patient.ID,Order.Patient.PID.PatientNO,Order.Patient.PVisit.PatientLocation.Dept.ID,Order.Patient.PVisit.PatientLocation.NurseCell.ID,
								   strItemType,Order.Item.ID,Order.Item.Name,Order.Item.UserCode,Order.Item.SpellCode,
								   Order.Item.SysClass.ID.ToString(),Order.Item.SysClass.Name,objAssets.Specs,"0","","","0","","","",objAssets.Price.ToString(),
								   Order.Usage.ID,Order.Usage.Name,Order.Usage.Memo,Order.Frequency.ID,Order.Frequency.Name,
								   Order.DoseOnce.ToString(),Order.Qty.ToString(),Order.Unit,Order.HerbalQty.ToString(),
								   Order.OrderType.ID,Order.OrderType.Name,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsDecompose).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsCharge).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsNeedPharmacy).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsPrint).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsConfirm).ToString(),
								   Order.ReciptDoctor.ID,Order.ReciptDoctor.Name,Order.BeginTime.ToString(),Order.EndTime.ToString(),Order.ReciptDept.ID,
								   Order.MOTime.ToString(),Order.Oper.ID,Order.Oper.Name,Order.Nurse.ID,Order.ConfirmTime.ToString(),
								   Order.DcReason.ID,Order.DcReason.Name,Order.DCOper.ID,Order.DCOper.Name,Order.DCOper.OperTime.ToString(),
								   Order.ExecOper.ID,Order.ExecOper.OperTime.ToString(),Order.ExeDept.ID,Order.ExeDept.Name,
								   Order.CurMOTime.ToString(),Order.NextMOTime.ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsBaby).ToString(),Order.BabyNO.ToString(),Order.Combo.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Combo.IsMainDrug).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsSubtbl).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsHaveSubtbl).ToString(),Order.Status.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsStock).ToString(),Order.ExecStatus.ToString(),
								   Order.Note,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsEmergency).ToString(),Order.SortID.ToString(),Order.Memo,Order.CheckPartRecord,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Reorder).ToString(),Order.Sample.Name,Order.StockDept.ID,
								   "",Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsPermission).ToString(),Order.Package.ID,Order.Package.Name,Order.ExtendFlag1,Order.ExtendFlag2,Order.ExtendFlag3,
                                   Order.Frequency.Time,Order.ExecDose,Order.ApplyNo};//新加特殊频次
					sqlOrder=string.Format(sqlOrder,s);
				}
				catch(Exception ex)
				{
					this.Err="付数值时候出错！"+ex.Message;
					this.WriteErr();
					return null;
				}
            }
            //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl //{BE3C743B-7343-4e12-A1AF-4B2793C8F9BB}
            else if (Order.Item.GetType() == typeof(Neusoft.HISFC.Models.FeeStuff.MaterialItem))
            {
                //{BE3C743B-7343-4e12-A1AF-4B2793C8F9BB}
                Neusoft.HISFC.Models.FeeStuff.MaterialItem objAssets;
                //{BE3C743B-7343-4e12-A1AF-4B2793C8F9BB}
                objAssets = (Neusoft.HISFC.Models.FeeStuff.MaterialItem)Order.Item;
                strItemType = "2";

                try
                {
                    string[] s ={Order.ID,Order.Patient.ID,Order.Patient.PID.PatientNO,Order.Patient.PVisit.PatientLocation.Dept.ID,Order.Patient.PVisit.PatientLocation.NurseCell.ID,
								   strItemType,Order.Item.ID,Order.Item.Name,Order.Item.UserCode,Order.Item.SpellCode,
								   Order.Item.SysClass.ID.ToString(),Order.Item.SysClass.Name,objAssets.Specs,"0","","","0","","","",objAssets.Price.ToString(),
								   Order.Usage.ID,Order.Usage.Name,Order.Usage.Memo,Order.Frequency.ID,Order.Frequency.Name,
								   Order.DoseOnce.ToString(),Order.Qty.ToString(),Order.Unit,Order.HerbalQty.ToString(),
								   Order.OrderType.ID,Order.OrderType.Name,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsDecompose).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsCharge).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsNeedPharmacy).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsPrint).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsConfirm).ToString(),
								   Order.ReciptDoctor.ID,Order.ReciptDoctor.Name,Order.BeginTime.ToString(),Order.EndTime.ToString(),Order.ReciptDept.ID,
								   Order.MOTime.ToString(),Order.Oper.ID,Order.Oper.Name,Order.Nurse.ID,Order.ConfirmTime.ToString(),
								   Order.DcReason.ID,Order.DcReason.Name,Order.DCOper.ID,Order.DCOper.Name,Order.DCOper.OperTime.ToString(),
								   Order.ExecOper.ID,Order.ExecOper.OperTime.ToString(),Order.ExeDept.ID,Order.ExeDept.Name,
								   Order.CurMOTime.ToString(),Order.NextMOTime.ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsBaby).ToString(),Order.BabyNO.ToString(),Order.Combo.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Combo.IsMainDrug).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsSubtbl).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsHaveSubtbl).ToString(),Order.Status.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsStock).ToString(),Order.ExecStatus.ToString(),
								   Order.Note,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsEmergency).ToString(),Order.SortID.ToString(),Order.Memo,Order.CheckPartRecord,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Reorder).ToString(),Order.Sample.Name,Order.StockDept.ID,
								   "",Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsPermission).ToString(),Order.Package.ID,Order.Package.Name,Order.ExtendFlag1,Order.ExtendFlag2,Order.ExtendFlag3,
                                   Order.Frequency.Time,Order.ExecDose,Order.ApplyNo};//新加特殊频次
                    sqlOrder = string.Format(sqlOrder, s);
                }
                catch (Exception ex)
                {
                    this.Err = "付数值时候出错！" + ex.Message;
                    this.WriteErr();
                    return null;
                }
            }
			else 
			{
				this.Err = "项目类型出错！";
				return null;
			}
			return sqlOrder;
		}

		/// 查询患者信息的select语句（无where条件）
		private string OrderQuerySelect()
		{
			#region 接口说明
			//Order.Order.QueryOrder.Select.1
			//传入：0
			//传出：sql.select
			#endregion
			string sql="";
			if(this.Sql.GetSql("Order.Order.QueryOrder.Select.1",ref sql)==-1)
			{
				this.Err="没有找到Order.Order.QueryOrder.Select.1字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			return sql;
		}
		//私有函数，查询医嘱信息
		private ArrayList myOrderQuery(string SQLPatient)
		{
			
			ArrayList al=new ArrayList();

			if(this.ExecQuery(SQLPatient)==-1) return null;
			try
			{
				while (this.Reader.Read())
				{
					Neusoft.HISFC.Models.Order.Inpatient.Order objOrder = new Neusoft.HISFC.Models.Order.Inpatient.Order();
					#region "患者信息"
					//患者信息——  
					//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
					try
					{
						objOrder.Patient.ID =this.Reader[1].ToString();
						objOrder.Patient.PID.PatientNO = this.Reader[2].ToString(); 
						objOrder.Patient.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString(); 
						objOrder.InDept.ID = this.Reader[3].ToString();
						objOrder.Patient.PVisit.PatientLocation.NurseCell.ID = this.Reader[4].ToString(); 

					}
					catch(Exception ex)
					{
						this.Err="获得患者基本信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					#endregion
					#region "项目信息"
					//医嘱辅助信息
					// ——项目信息
					//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
					//	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
					//         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
					//         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
					//         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
					// 判断药品/非药品
					//         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
					// 73 样本类型/检查部位 名称
					if (this.Reader[5].ToString() == "1")//药品
					{
						Neusoft.HISFC.Models.Pharmacy.Item objPharmacy= new Neusoft.HISFC.Models.Pharmacy.Item();
						try
						{
							objPharmacy.ID = this.Reader[6].ToString();
							objPharmacy.Name = this.Reader[7].ToString();
							objPharmacy.UserCode = this.Reader[8].ToString();
							objPharmacy.SpellCode = this.Reader[9].ToString();
							objPharmacy.SysClass.ID = this.Reader[10].ToString();
							//objPharmacy.SysClass.Name = this.Reader[11].ToString();
							objPharmacy.Specs     = this.Reader[12].ToString();
							//							try
							//							{
							if(!this.Reader.IsDBNull(13)) objPharmacy.BaseDose  = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13].ToString());
							//}
							//							catch{}
							objPharmacy.DoseUnit = this.Reader[14].ToString();
							objPharmacy.MinUnit = this.Reader[15].ToString();
							//try
							//{
							if(!this.Reader.IsDBNull(16))objPharmacy.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16].ToString());
							//}
							//catch{}
							objPharmacy.DosageForm.ID = this.Reader[17].ToString();
							objPharmacy.Type.ID    = this.Reader[18].ToString();
							objPharmacy.Quality.ID = this.Reader[19].ToString();
							//try
							//{
							if(!this.Reader.IsDBNull(20))objPharmacy.PriceCollection.RetailPrice= Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());
							//}
							//catch{}					
							objOrder.Usage.ID  =this.Reader[21].ToString();
							objOrder.Usage.Name=this.Reader[22].ToString();
							objOrder.Usage.Memo=this.Reader[23].ToString();
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱项目信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						objOrder.Item = objPharmacy;
					}
					else if (this.Reader[5].ToString() == "2")//非药品
					{
						Neusoft.HISFC.Models.Fee.Item.Undrug objAssets=new Neusoft.HISFC.Models.Fee.Item.Undrug();
						try
						{
							objAssets.ID = this.Reader[6].ToString();
							objAssets.Name = this.Reader[7].ToString();
							objAssets.UserCode = this.Reader[8].ToString();
							objAssets.SpellCode = this.Reader[9].ToString();
							objAssets.SysClass.ID = this.Reader[10].ToString();
							//objAssets.SysClass.Name = this.Reader[11].ToString();
							objAssets.Specs     = this.Reader[12].ToString();
							//							try
							//							{
							if(!this.Reader.IsDBNull(20))objAssets.Price= Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());
							//}
							//							catch{}	
							objAssets.PriceUnit = this.Reader[28].ToString();
							//样本类型/检查部位名称
							objOrder.Sample.Name = this.Reader[73].ToString();
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱项目信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						objOrder.Item = objAssets;
					}

				
					objOrder.Frequency.ID  =this.Reader[24].ToString();
					objOrder.Frequency.Name=this.Reader[25].ToString();
					//try
					//{
					if(!this.Reader.IsDBNull(26))objOrder.DoseOnce=Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26].ToString());//}
					//catch{}
					//try
					//{
					if(!this.Reader.IsDBNull(27))objOrder.Qty =Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[27].ToString());//}
					//catch{}
					objOrder.Unit=this.Reader[28].ToString();
					//try
					//{
					if(!this.Reader.IsDBNull(29))objOrder.HerbalQty=Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[29].ToString());//}
					//catch{}
					
					#endregion
					#region "医嘱属性"
					// ——医嘱属性
					//		   30医嘱类别代码 31医嘱类别名称  32医嘱是否分解:1长期/2临时     33是否计费 
					//		   34药房是否配药 35打印执行单    36是否需要确认   
					try
					{
						objOrder.ID = this.Reader[0].ToString();
						objOrder.ExtendFlag1 = this.Reader[78].ToString();//临时医嘱执行时间－－自定义
						objOrder.OrderType.ID = this.Reader[30].ToString();
						objOrder.OrderType.Name = this.Reader[31].ToString();
						//try
						//{
						if(!this.Reader.IsDBNull(32))objOrder.OrderType.IsDecompose = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[32].ToString()));//}
						//catch{}
						//try
						//{
						if(!this.Reader.IsDBNull(33))objOrder.OrderType.IsCharge = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[33].ToString()));//}
						//catch{}
						//try
						//{
						if(!this.Reader.IsDBNull(34))objOrder.OrderType.IsNeedPharmacy = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[34].ToString()));//}
						//catch{}
						//try
						//{
						if(!this.Reader.IsDBNull(35))objOrder.OrderType.IsPrint = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[35].ToString()));//}
						//catch{}
						//try
						//{
						if(!this.Reader.IsDBNull(36))objOrder.OrderType.IsConfirm = System.Convert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[36].ToString()));//}
						//catch{}
					}
					catch(Exception ex)
					{
						this.Err="获得医嘱属性信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					#endregion
					#region "执行情况"
					// ——执行情况
					//		   37开立医师Id   38开立医师name  39开始时间      40结束时间     41开立科室
					//		   42开立时间     43录入人员代码  44录入人员姓名  45审核人ID     46审核时间       
					//		   47DC原因代码   48DC原因名称    49DC医师代码    50DC医师姓名   51Dc时间
					//         52执行人员代码 53执行时间      54执行科室代码  55执行科室名称 
					//		   56本次分解时间 57下次分解时间
					try
					{						  
						objOrder.ReciptDoctor.ID = this.Reader[37].ToString();
						objOrder.ReciptDoctor.Name = this.Reader[38].ToString();
						//try{
						if(!this.Reader.IsDBNull(39))objOrder.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[39].ToString());
						//}
						//catch{}
						//try{
						if(!this.Reader.IsDBNull(40))objOrder.EndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[40].ToString());
						//}
						//catch{}
						objOrder.ReciptDept.ID = this.Reader[41].ToString();//InDept.ID
						//try{
						if(!this.Reader.IsDBNull(42))objOrder.MOTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[42].ToString());
						//}
						//catch{}
						objOrder.Oper.ID = this.Reader[43].ToString();
						objOrder.Oper.Name = this.Reader[44].ToString();
						objOrder.Nurse.ID = this.Reader[45].ToString();
						//try{
						if(!this.Reader.IsDBNull(46))objOrder.ConfirmTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[46].ToString());
						//}
						//catch{}
						objOrder.DcReason.ID = this.Reader[47].ToString();
						objOrder.DcReason.Name = this.Reader[48].ToString();
						objOrder.DCOper.ID = this.Reader[49].ToString();
						objOrder.DCOper.Name = this.Reader[50].ToString();
						//try{
						if(!this.Reader.IsDBNull(51))objOrder.DCOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[51].ToString());
						//}
						//catch{}
						objOrder.ExecOper.ID = this.Reader[52].ToString();
						//try{
						if(!this.Reader.IsDBNull(53))objOrder.ExecOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[53].ToString());
						
						objOrder.ExeDept.ID = this.Reader[54].ToString();
						objOrder.ExeDept.Name = this.Reader[55].ToString();

                        objOrder.ExecOper.Dept.ID = this.Reader[54].ToString();
                        objOrder.ExecOper.Dept.Name = this.Reader[55].ToString();
						
						if(!this.Reader.IsDBNull(56))objOrder.CurMOTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[56].ToString());
					
						if(!this.Reader.IsDBNull(57))objOrder.NextMOTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[57].ToString());
						
					}
					catch(Exception ex)
					{
						this.Err="获得医嘱执行情况信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					#endregion
					#region "医嘱类型"
					// ——医嘱类型
					//		   58是否婴儿（1是/2否）          59发生序号  	  60组合序号     61主药标记 
					//		   62是否附材'1'  63是否包含附材  64医嘱状态      65扣库标记     66执行标记1未执行/2已执行/3DC执行 
					//		   67医嘱说明                     68加急标记:1普通/2加急         69排列序号
					//         70 批注       ,       71检查部位备注    ,72 整档标记,74 取药药房编码 81 是否皮试 
                    //         84 申请单号
					try
					{
						
						if(!this.Reader.IsDBNull(58))objOrder.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[58].ToString()));
						
						if(!this.Reader.IsDBNull(59))objOrder.BabyNO = this.Reader[59].ToString();
						
						objOrder.Combo.ID = this.Reader[60].ToString();
						
						if(!this.Reader.IsDBNull(61))objOrder.Combo.IsMainDrug = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[61].ToString()));
						
						if(!this.Reader.IsDBNull(62))objOrder.IsSubtbl = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[62].ToString()));
						
						if(!this.Reader.IsDBNull(63))objOrder.IsHaveSubtbl = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[63].ToString()));
						
						if(!this.Reader.IsDBNull(64))objOrder.Status = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[64].ToString());
						
						if(!this.Reader.IsDBNull(65))objOrder.IsStock = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[65].ToString()));

						
						if(!this.Reader.IsDBNull(66))objOrder.ExecStatus = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[66].ToString());
						
						objOrder.Note = this.Reader[67].ToString();
						
						if(!this.Reader.IsDBNull(68))objOrder.IsEmergency = Neusoft.FrameWork.Function.NConvert.ToBoolean(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[68].ToString()));
						
						if(!this.Reader.IsDBNull(69))objOrder.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[69]);
						
						objOrder.Memo = this.Reader[70].ToString();
						objOrder.CheckPartRecord = this.Reader[71].ToString();
						objOrder.Reorder = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[72].ToString());
						objOrder.StockDept.ID = this.Reader[74].ToString();//取药药房编码
						try
						{
							if(!this.Reader.IsDBNull(75)) objOrder.IsPermission = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[75]);//患者用药知情
						}
						catch{}
						objOrder.Package.ID = this.Reader[76].ToString();
						objOrder.Package.Name = this.Reader[77].ToString();
						objOrder.ExtendFlag2 = this.Reader[79].ToString();
						objOrder.ExtendFlag3 = this.Reader[80].ToString();
						try
						{
							if (!this.Reader.IsDBNull(81))
								objOrder.HypoTest = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[81].ToString());//1 不需皮试 2 需皮试 3 阳 4 阴
						}
						catch
						{
							objOrder.HypoTest = 1;
						}
                        
                        objOrder.Frequency.Time = this.Reader[82].ToString(); //执行时间
                        objOrder.ExecDose = this.Reader[83].ToString();//特殊频次剂量
                        if (!this.Reader.IsDBNull(84))  objOrder.ApplyNo = this.Reader[84].ToString(); //申请单号

                        #region {16EE9720-A7C1-4f07-8262-2F0A1567C78F}
                        if (!this.Reader.IsDBNull(85))
                        {
                            objOrder.DCNurse.ID = this.Reader[85].ToString();
                        }
                        if (!this.Reader.IsDBNull(86))
                        {
                            objOrder.DCNurse.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[86].ToString());
                        }
                        #endregion

					}
					catch(Exception ex)
					{
						this.Err="获得医嘱类型信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					#endregion
					al.Add(objOrder);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得医嘱信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 判断医嘱项目类别，药品/非药品
		/// </summary>
		/// <param name="Order"></param>
		/// <returns></returns>
        private string JudgeItemType(Neusoft.HISFC.Models.Order.Order Order)
		{
			string strItem="";
			//判断药品/非药品 
			//if (Order.Item.IsPharmacy)
            if(Order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
			{
				strItem="1";
			}
			else 
			{
				strItem="2";
			}
			return strItem;
		}

		
		//添加查询信息
		private void addExecOrder(ArrayList al,string sqlOrder)
		{
			ArrayList al1=null;
			try
			{
				al1=this.myExecOrderQuery(sqlOrder);
				//al1 = myExecOrderQueryByDataSet(sqlOrder);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
			}
			if(al1 == null) return;
			
			al.AddRange(al1);
			//			foreach(Object.Order.ExecOrder ExecOrder in al1)
			//			{
			//				al.Add(ExecOrder);
			//			}
		}
		
		/// <summary>
		/// 查询患者信息的select语句（无where条件）
		/// </summary>
		/// <param name="Type">"" 药品非药品都查，1 药品， 2 非药品</param>
		/// <returns></returns>
		private string[] ExecOrderQuerySelect(string Type)
		{
			#region 接口说明
			//Order.ExecOrder.QueryOrder.Select.1
			//传入：0
			//传出：sql.select
			#endregion
			string[] s = null;
			string sql="";
			if(Type =="") 
			{
				s = new string[2];
			}
			else
			{
				s = new string[1];
			}
			if (Type=="1" || Type =="")
			{
				if(this.Sql.GetSql("Order.ExecOrder.QueryOrder.Select.1",ref sql)==-1)
				{
					this.Err="没有找到Order.ExecOrder.QueryOrder.Select.1字段!";
					this.ErrCode="-1";
					this.WriteErr();
					return null;
				}
				s[0]=sql;
			}
			else if (Type=="2" || Type =="")
			{
				if(this.Sql.GetSql("Order.ExecOrder.QueryOrder.Select.2",ref sql)==-1)
				{
					this.Err="没有找到Order.ExecOrder.QueryOrder.Select.2字段!";
					this.ErrCode="-1";
					this.WriteErr();
					return null;
				}
				if(Type =="") 
				{
					s[1] = sql;
				}
				else
				{
					s[0] = sql;
				}
			}
			return s;
		}

		private ArrayList myExecOrderQueryByDataSet(string sql)
		{
			DataSet ds = new DataSet();
			if(this.ExecQuery(sql, ref ds) == -1)
			{
				return null;
			}
			if(ds == null)
			{
				return null;
			}
			if(ds.Tables[0] == null)
			{
				return null;
			}

			ArrayList al = new ArrayList();

            Neusoft.HISFC.Models.Order.ExecOrder objOrder;
	
			foreach(DataRow row in ds.Tables[0].Rows)
			{
				objOrder = new Neusoft.HISFC.Models.Order.ExecOrder();

				objOrder.Order.Patient.ID = row[0].ToString();
				objOrder.Order.Patient.PID.PatientNO = row[1].ToString();
				objOrder.Order.Patient.PVisit.PatientLocation.Dept.ID = row[3].ToString(); 
				objOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID = row[4].ToString(); 
				objOrder.Order.NurseStation.ID = row[4].ToString();
				objOrder.Order.InDept.ID=row[3].ToString();

				if (row[5].ToString() == "1")//药品
				{
					Neusoft.HISFC.Models.Pharmacy.Item objPharmacy= new Neusoft.HISFC.Models.Pharmacy.Item();

					#region 药品
					objPharmacy.ID = row[6].ToString();
					objPharmacy.Name = row[7].ToString();
					objPharmacy.UserCode = row[8].ToString();
					objPharmacy.SpellCode = row[9].ToString();
					objPharmacy.SysClass.ID = row[10].ToString();
					//objPharmacy.SysClass.Name = row[11].ToString();
					objPharmacy.Specs     = row[12].ToString();
					//try
					//{
					objPharmacy.BaseDose  = Neusoft.FrameWork.Function.NConvert.ToDecimal(row[13]);
					//}
					//catch{}
					objPharmacy.DoseUnit = row[14].ToString();
					objPharmacy.MinUnit = row[15].ToString();
					//try
					//{
					objPharmacy.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(row[16]);
					//}
					//catch{}
					objPharmacy.DosageForm.ID = row[17].ToString();
					objPharmacy.Type.ID    = row[18].ToString();
					objPharmacy.Quality.ID = row[19].ToString();
					//try
					//{
					objPharmacy.PriceCollection.RetailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row[20]);
					//}
					//catch{}	
					objOrder.Order.Item = objPharmacy;
					

					objOrder.Order.Usage.ID  =row[21].ToString();
					objOrder.Order.Usage.Name=row[22].ToString();
					objOrder.Order.Usage.Memo=row[23].ToString();
					objOrder.Order.Frequency.ID  =row[24].ToString();
					objOrder.Order.Frequency.Name=row[25].ToString();
					//try
					//{
					objOrder.Order.DoseOnce=Neusoft.FrameWork.Function.NConvert.ToDecimal(row[26]);
					//}
					//catch{}
					objOrder.Order.DoseUnit =objPharmacy.DoseUnit;
					//try
					//{
					objOrder.Order.Qty =Neusoft.FrameWork.Function.NConvert.ToDecimal(row[27]);
					//}
					//catch{}
					objOrder.Order.Unit=row[28].ToString();
					//try
					//{
					objOrder.Order.HerbalQty = Neusoft.FrameWork.Function.NConvert.ToInt32(row[29]);

					objOrder.ID = row[0].ToString();
					objOrder.Order.ID = row[30].ToString();
					objOrder.Order.OrderType.ID = row[31].ToString();
					objOrder.Order.OrderType.IsDecompose = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[32]);
					objOrder.Order.OrderType.IsCharge = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[33]);
					objOrder.Order.OrderType.IsNeedPharmacy = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[34]);
					objOrder.Order.OrderType.IsPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[35]);
					objOrder.Order.OrderType.IsConfirm =  Neusoft.FrameWork.Function.NConvert.ToBoolean(row[36]);
					objOrder.Order.ReciptDoctor.ID = row[37].ToString();
					objOrder.Order.ReciptDoctor.Name = row[38].ToString();
					objOrder.DateUse =  Neusoft.FrameWork.Function.NConvert.ToDateTime(row[39]);
					objOrder.DCExecOper.OperTime =  Neusoft.FrameWork.Function.NConvert.ToDateTime(row[40]);
					objOrder.Order.ReciptDept.ID = row[41].ToString();
					objOrder.Order.BeginTime =  Neusoft.FrameWork.Function.NConvert.ToDateTime(row[42]);
					objOrder.DCExecOper.ID = row[43].ToString();
					objOrder.ChargeOper.ID = row[44].ToString();
                    objOrder.ChargeOper.Dept.ID = row[45].ToString();
					objOrder.ChargeOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row[46]);
					objOrder.Order.StockDept.ID = row[47].ToString();
					objOrder.Order.ExeDept.ID = row[48].ToString();
					objOrder.ExecOper.ID = row[49].ToString();

					if(row[50].ToString()!="") 
						objOrder.Order.ExeDept.ID = row[50].ToString();
					objOrder.Order.BeginTime =  Neusoft.FrameWork.Function.NConvert.ToDateTime(row[51]);
					objOrder.DateDeco =  Neusoft.FrameWork.Function.NConvert.ToDateTime(row[52]);
					objOrder.Order.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[53]);
					objOrder.Order.BabyNO = row[54].ToString();
					objOrder.Order.Combo.ID = row[55].ToString();
					objOrder.Order.Combo.IsMainDrug = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[56]);
					objOrder.Order.IsHaveSubtbl =Neusoft.FrameWork.Function.NConvert.ToBoolean(row[57]);
					objOrder.IsValid= Neusoft.FrameWork.Function.NConvert.ToBoolean(row[58]);
					objOrder.Order.IsStock = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[59]);
					objOrder.IsExec = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[60]);
					objOrder.DrugFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(row[61]);
					objOrder.IsCharge = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[62]);
					objOrder.Order.Note = row[63].ToString();
					objOrder.Order.Memo = row[64].ToString();
					objOrder.Order.ReciptNO = row[65].ToString();
					objOrder.Order.SequenceNO =Neusoft.FrameWork.Function.NConvert.ToInt32(row[66]);
					#endregion
				}
				if (row[5].ToString() == "2")//非药品
				{
					Neusoft.HISFC.Models.Fee.Item.Undrug objAssets=new Neusoft.HISFC.Models.Fee.Item.Undrug();
					#region 非药品
						
					// ——项目信息
					//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
					//	       10项目类别代码 11项目类别名称  12规格         13零售价        14用法代码   
					//         15用法名称     16用法英文缩写  17频次代码     18频次名称      19每次用量
					//         20项目总量     21计价单位      22使用次数	
					objAssets.ID = row[6].ToString();
					objAssets.Name = row[7].ToString();
					objAssets.UserCode = row[8].ToString();
					objAssets.SpellCode = row[9].ToString();
					objAssets.SysClass.ID = row[10].ToString();
					//objAssets.SysClass.Name = row[11].ToString();
					objAssets.Specs     = row[12].ToString();
					objAssets.Price= Neusoft.FrameWork.Function.NConvert.ToDecimal(row[13].ToString());
					objAssets.PriceUnit = row[21].ToString();
					objOrder.Order.Item = objAssets;								
					objOrder.Order.Usage.ID  =row[14].ToString();
					objOrder.Order.Usage.Name=row[15].ToString();
					objOrder.Order.Usage.Memo=row[16].ToString();
					objOrder.Order.Frequency.ID  =row[17].ToString();
					objOrder.Order.Frequency.Name=row[18].ToString();
					objOrder.Order.DoseOnce=Neusoft.FrameWork.Function.NConvert.ToDecimal(row[19]);
					objOrder.Order.Qty =Neusoft.FrameWork.Function.NConvert.ToDecimal(row[20]);
					objOrder.Order.Unit =row[21].ToString();
					objOrder.Order.DoseUnit = objOrder.Order.Unit;
					objOrder.Order.HerbalQty = Neusoft.FrameWork.Function.NConvert.ToInt32(row[22]);

					objOrder.ID = row[0].ToString();
					objOrder.Order.OrderType.ID = row[23].ToString();
					objOrder.Order.ID = row[24].ToString();
					objOrder.Order.OrderType.IsDecompose = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[25]);
					objOrder.Order.OrderType.IsCharge =Neusoft.FrameWork.Function.NConvert.ToBoolean(row[26]);
					objOrder.Order.OrderType.IsNeedPharmacy = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[27]);
					objOrder.Order.OrderType.IsPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[28]);
					objOrder.Order.OrderType.IsConfirm = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[29]);
					objOrder.Order.ReciptDoctor.ID = row[30].ToString();
					objOrder.Order.ReciptDoctor.Name = row[31].ToString();
					objOrder.DateUse = Neusoft.FrameWork.Function.NConvert.ToDateTime(row[32]);
					objOrder.DCExecOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row[33]);
					objOrder.Order.ReciptDept.ID = row[34].ToString();
					objOrder.Order.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row[35]);
					objOrder.DCExecOper.ID = row[36].ToString();
					objOrder.ChargeOper.ID = row[37].ToString();
					objOrder.ChargeOper.Dept.ID = row[38].ToString();
					objOrder.ChargeOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row[39]);
					objOrder.Order.StockDept.ID = row[40].ToString();
					objOrder.Order.ExeDept.ID = row[41].ToString();
					objOrder.ExecOper.ID = row[42].ToString();
					objOrder.Order.ExeDept.ID = row[43].ToString();
					objOrder.ExecOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(row[44]);
					objOrder.DateDeco = Neusoft.FrameWork.Function.NConvert.ToDateTime(row[45]);
					objOrder.Order.ExeDept.Name = row[46].ToString();
					objOrder.Order.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[47]);
					objOrder.Order.BabyNO = row[48].ToString();
					objOrder.Order.Combo.ID = row[49].ToString();
					objOrder.Order.Combo.IsMainDrug = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[50]);
					objOrder.Order.IsSubtbl = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[51]);
					objOrder.Order.IsHaveSubtbl =Neusoft.FrameWork.Function.NConvert.ToBoolean(row[52]);
					objOrder.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[53]);
					objOrder.IsExec =Neusoft.FrameWork.Function.NConvert.ToBoolean(row[54]);
					objOrder.IsCharge = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[55]);
					objOrder.Order.IsEmergency = Neusoft.FrameWork.Function.NConvert.ToBoolean(row[56]);
					objOrder.Order.CheckPartRecord = row[57].ToString();

					objOrder.Order.Note = row[58].ToString();
					objOrder.Order.Memo = row[59].ToString();
					objOrder.Order.ReciptNO = row[60].ToString();
					objOrder.Order.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(row[61]);
					objOrder.Order.StockDept.ID = row[62].ToString();
					try
					{
						objOrder.Order.Sample.Name = row[63].ToString();			//样本类型/检查部位
						objOrder.Order.Sample.Memo = row[64].ToString();			//检验条码号
					}
					catch {}
					#endregion
				}

				al.Add(objOrder);
			}
			return al;
		}

		//私有函数，查询医嘱信息
		private ArrayList myExecOrderQuery(string SQLPatient)
		{
			
			ArrayList al=new ArrayList();

			if(this.ExecQuery(SQLPatient)==-1) return null;
			try
			{
				while (this.Reader.Read())
				{
                    Neusoft.HISFC.Models.Order.ExecOrder objOrder = new Neusoft.HISFC.Models.Order.ExecOrder();
					    
					#region "患者信息"
					//患者信息——  
					//			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
					try
					{
						objOrder.Order.Patient.ID =this.Reader[1].ToString();
						objOrder.Order.Patient.PID.PatientNO = this.Reader[2].ToString(); 
						objOrder.Order.Patient.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString(); 
						objOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID = this.Reader[4].ToString(); 
						objOrder.Order.NurseStation.ID = this.Reader[4].ToString();
						objOrder.Order.InDept.ID=this.Reader[3].ToString();
					}
					catch(Exception ex)
					{
						this.Err="获得患者基本信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					#endregion
					  
					if (this.Reader[5].ToString() == "1")//药品
					{
						Neusoft.HISFC.Models.Pharmacy.Item objPharmacy= new Neusoft.HISFC.Models.Pharmacy.Item();
						try
						{
							#region "项目信息"
							//医嘱辅助信息
							// ——项目信息
							//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
							//	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
							//         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
							//         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
							//         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			
							objPharmacy.ID = this.Reader[6].ToString();
							objPharmacy.Name = this.Reader[7].ToString();
							objPharmacy.UserCode = this.Reader[8].ToString();
							objPharmacy.SpellCode = this.Reader[9].ToString();
							objPharmacy.SysClass.ID = this.Reader[10].ToString();
							//objPharmacy.SysClass.Name = this.Reader[11].ToString();
							objPharmacy.Specs     = this.Reader[12].ToString();
							//try
							//{
							objPharmacy.BaseDose  = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13]);
							//}
							//catch{}
							objPharmacy.DoseUnit = this.Reader[14].ToString();
							objPharmacy.MinUnit = this.Reader[15].ToString();
							//try
							//{
							objPharmacy.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16]);
							//}
							//catch{}
							objPharmacy.DosageForm.ID = this.Reader[17].ToString();
							objPharmacy.Type.ID    = this.Reader[18].ToString();
							objPharmacy.Quality.ID = this.Reader[19].ToString();
							//try
							//{
							objPharmacy.PriceCollection.RetailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20]);
							//}
							//catch{}	
							objOrder.Order.Item = objPharmacy;
							#endregion

							objOrder.Order.Usage.ID  =this.Reader[21].ToString();
							objOrder.Order.Usage.Name=this.Reader[22].ToString();
							objOrder.Order.Usage.Memo=this.Reader[23].ToString();
							objOrder.Order.Frequency.ID  =this.Reader[24].ToString();
							objOrder.Order.Frequency.Name=this.Reader[25].ToString();
							//try
							//{
							objOrder.Order.DoseOnce=Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26]);
							//}
							//catch{}
							objOrder.Order.DoseUnit =objPharmacy.DoseUnit;
							//try
							//{
							objOrder.Order.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[27]);
							//}
							//catch{}
							objOrder.Order.Unit=this.Reader[28].ToString();
							//try
							//{
							objOrder.Order.HerbalQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[29]);
							//}
							//catch{}
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱项目信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						//objOrder.Order.Item = objPharmacy;

						#region "医嘱属性"
						// ——医嘱属性
						//		  30医嘱流水号 , 31医嘱类别代码  32医嘱是否分解:1长期/2临时     33是否计费 
						//		   34药房是否配药 35打印执行单    36是否需要确认  
						try
						{
							objOrder.ID = this.Reader[0].ToString();
							objOrder.Order.ID = this.Reader[30].ToString();
							objOrder.Order.OrderType.ID = this.Reader[31].ToString();
							//try
							//{
							objOrder.Order.OrderType.IsDecompose = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[32]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsCharge = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[33]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsNeedPharmacy = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[34]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[35]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsConfirm =  Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[36]);
							//}
							//catch{}
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱属性信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						#endregion
						#region "执行情况"
						// ——执行情况
						//		   37开立医师Id   38开立医师name  39要求执行时间  40作废时间     41开立科室
						//		   42开立时间     43作废人代码    44记账人代码    45记账科室代码 46记账时间       
						//		   47取药药房     48执行科室      49执行护士代码  50执行科室代码 51执行时间
						//         52分解时间
						try
						{						  
							objOrder.Order.ReciptDoctor.ID = this.Reader[37].ToString();
							objOrder.Order.ReciptDoctor.Name = this.Reader[38].ToString();
							//try{
							objOrder.DateUse =  Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[39]);
							//}
							//catch{}
							//try{
							objOrder.DCExecOper.OperTime =  Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[40]);
							//}
							//catch{}
							objOrder.Order.ReciptDept.ID = this.Reader[41].ToString();
							//try{
							objOrder.Order.BeginTime =  Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[42]);
							//}
							//catch{}
							objOrder.DCExecOper.ID = this.Reader[43].ToString();
							objOrder.ChargeOper.ID = this.Reader[44].ToString();
							objOrder.ChargeOper.Dept.ID = this.Reader[45].ToString();
							//try{
							objOrder.ChargeOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[46]);
							//}
							//catch{}
							objOrder.Order.StockDept.ID = this.Reader[47].ToString();
							objOrder.Order.ExeDept.ID = this.Reader[48].ToString();
							objOrder.ExecOper.ID = this.Reader[49].ToString();
							//try
							//{
							if(this.Reader[50].ToString()!="") 
								objOrder.Order.ExeDept.ID = this.Reader[50].ToString();
							//}
							//catch{}
							//try{
							objOrder.ExecOper.OperTime =  Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[51]);
							//}
							//catch{}
							objOrder.DateDeco =  Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[52]);

							if(!Reader.IsDBNull(68))
							{
								objOrder.DrugedTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[68].ToString());
							}
						
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱执行情况信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						#endregion
						#region "医嘱类型"
						// ——医嘱类型
						//		   64是否婴儿（1是/2否）          53发生序号  	  54组合序号     55主药标记 
						//		   56是否包含附材                 57是否有效      58扣库标记     59是否执行 
						//		   60配药标记                     61收费标记      62医嘱说明     63备注
						//         65处方号                       66处方序号
						try
						{
							//try{
							objOrder.Order.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[53]);
							//}
							//catch{}
							//try{
							objOrder.Order.BabyNO = this.Reader[54].ToString();
							//}
							//catch{}
							objOrder.Order.Combo.ID = this.Reader[55].ToString();
							//try{
							objOrder.Order.Combo.IsMainDrug = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[56]);
							//}
							//catch{}
							//try{
							objOrder.Order.IsHaveSubtbl =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[57]);
							//}
							//catch{}
							//try{
							objOrder.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[58]);
							//}
							//catch{}
							//try{
							objOrder.Order.IsStock = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[59]);
							//}
							//catch{}
							//try{
							objOrder.IsExec = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[60]);
							//}
							//catch{}
							//try{
							objOrder.DrugFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[61]);
							//}
							//catch{}
							//try{
							objOrder.IsCharge = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[62]);
							//}
							//catch{}
							objOrder.Order.Note = this.Reader[63].ToString();
							objOrder.Order.Memo = this.Reader[64].ToString();
							objOrder.Order.ReciptNO = this.Reader[65].ToString();
							//try{
							objOrder.Order.SequenceNO =Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[66]);
							//}
							//catch{}
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱类型信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						#endregion
					} 	
					else if (this.Reader[5].ToString() == "2")//非药品
					{
						Neusoft.HISFC.Models.Fee.Item.Undrug objAssets=new Neusoft.HISFC.Models.Fee.Item.Undrug();
						try
						{
							#region "项目信息"
							// ——项目信息
							//	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
							//	       10项目类别代码 11项目类别名称  12规格         13零售价        14用法代码   
							//         15用法名称     16用法英文缩写  17频次代码     18频次名称      19每次用量
							//         20项目总量     21计价单位      22使用次数	
							objAssets.ID = this.Reader[6].ToString();
							objAssets.Name = this.Reader[7].ToString();
							objAssets.UserCode = this.Reader[8].ToString();
							objAssets.SpellCode = this.Reader[9].ToString();
							objAssets.SysClass.ID = this.Reader[10].ToString();
							//objAssets.SysClass.Name = this.Reader[11].ToString();
							objAssets.Specs     = this.Reader[12].ToString();
							//try
							//{
							objAssets.Price= Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13].ToString());
							//}
							//catch{}	
							objAssets.PriceUnit = this.Reader[21].ToString();
							objOrder.Order.Item = objAssets;	
							#endregion

							objOrder.Order.Usage.ID  =this.Reader[14].ToString();
							objOrder.Order.Usage.Name=this.Reader[15].ToString();
							objOrder.Order.Usage.Memo=this.Reader[16].ToString();
							objOrder.Order.Frequency.ID  =this.Reader[17].ToString();
							objOrder.Order.Frequency.Name=this.Reader[18].ToString();
							//try
							//{
							objOrder.Order.DoseOnce=Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.Qty =Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20]);
							//}
							//catch{}
							objOrder.Order.Unit =this.Reader[21].ToString();
							objOrder.Order.DoseUnit = objOrder.Order.Unit;
							//try
							//{
							objOrder.Order.HerbalQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[22]);
							//}
							//catch{}
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱项目信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						
						#region "医嘱属性"
						// ——医嘱属性
						//		   23医嘱类别代码 24医嘱流水号    25医嘱是否分解:1长期/2临时     26是否计费 
						//		   27药房是否配药 28打印执行单    29是否需要确认    
						try
						{
							objOrder.ID = this.Reader[0].ToString();
							objOrder.Order.OrderType.ID = this.Reader[23].ToString();
							objOrder.Order.ID = this.Reader[24].ToString();
							//							try
							//							{
							objOrder.Order.OrderType.IsDecompose = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[25]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsCharge =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[26]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsNeedPharmacy = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[27]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsPrint = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[28]);
							//}
							//catch{}
							//try
							//{
							objOrder.Order.OrderType.IsConfirm = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[29]);
							//}
							//catch{}
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱属性信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						#endregion
						#region "执行情况"
						// ——执行情况
						//		   30开立医师Id   31开立医师name  32要求执行时间  33作废时间     34开立科室
						//		   35开立时间     36作废人代码    37记账人代码    38记账科室代码 39记账时间       
						//		   40取药药房     41执行科室      42执行护士代码  43执行科室代码 44执行时间
						//         45分解时间     46执行科室名称
						try
						{						  
							objOrder.Order.ReciptDoctor.ID = this.Reader[30].ToString();
							objOrder.Order.ReciptDoctor.Name = this.Reader[31].ToString();
							//try{
							objOrder.DateUse = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[32]);
							//}
							//catch{}
							//try{
							objOrder.DCExecOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[33]);
							//}
							//catch{}
							objOrder.Order.ReciptDept.ID = this.Reader[34].ToString();
							//try{
							objOrder.Order.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[35]);
							//}
							//catch{}
							objOrder.DCExecOper.ID = this.Reader[36].ToString();
							objOrder.ChargeOper.ID = this.Reader[37].ToString();
                            objOrder.ChargeOper.Dept.ID = this.Reader[38].ToString();
							//try{
							objOrder.ChargeOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[39]);
							//}
							//catch{}
							objOrder.Order.StockDept.ID = this.Reader[40].ToString();
							objOrder.Order.ExeDept.ID = this.Reader[41].ToString();//执行科室用项目执行科室
							objOrder.ExecOper.ID = this.Reader[42].ToString();
							//objOrder.ExeDept.ID = this.Reader[43].ToString();//这个字段就是没用的
							//try{
							objOrder.ExecOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[44]);
							//}
							//catch{}
							objOrder.DateDeco = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[45]);
							objOrder.Order.ExeDept.Name = this.Reader[46].ToString();
						
						}
						catch(Exception ex)
						{
							this.Err="获得医嘱执行情况信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						#endregion
						#region "医嘱类型"
						// ——医嘱类型
						//		   47是否婴儿（1是/2否）          48发生序号  	  49组合序号     50主项标记 
						//		   51是否附材                     52是否包含附材  53是否有效     54是否执行 
						//		   55收费标记     56加急标记      57检查部位检体  58医嘱说明     59备注 
						//         60处方号                       61处方序号      62配药科室ID
						try
						{
							//try{
							objOrder.Order.IsBaby = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[47]);
							//}
							//catch{}
							//try{
							objOrder.Order.BabyNO = this.Reader[48].ToString();
							//}
							//catch{}
							objOrder.Order.Combo.ID = this.Reader[49].ToString();
							//try{
							objOrder.Order.Combo.IsMainDrug = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[50]);
							//}
							//catch{}
							//try{
							objOrder.Order.IsSubtbl = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[51]);
							//}
							//catch{}
							//try{
							objOrder.Order.IsHaveSubtbl =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[52]);
							//}
							//catch{}
							//try{
							objOrder.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[53]);
							//}
							//catch{}
							//try{
							objOrder.IsExec =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[54]);
							//}
							//catch{}
							//try{
							objOrder.IsCharge = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[55]);
							//}
							//catch{}
							//try{
							objOrder.Order.IsEmergency = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[56]);
							//}
							//catch{}
							objOrder.Order.CheckPartRecord = this.Reader[57].ToString();

							objOrder.Order.Note = this.Reader[58].ToString();
							objOrder.Order.Memo = this.Reader[59].ToString();
							objOrder.Order.ReciptNO = this.Reader[60].ToString();
							//try{
							objOrder.Order.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[61]);
							//}
							//catch{}
							objOrder.Order.StockDept.ID = this.Reader[62].ToString();
							
							try
							{
								objOrder.Order.Sample.Name = this.Reader[63].ToString();			//样本类型/检查部位
								objOrder.Order.Sample.Memo = this.Reader[64].ToString();			//检验条码号
							}
							catch {}
							
							

						}
						catch(Exception ex)
						{
							this.Err="获得医嘱类型信息出错！"+ex.Message;
							this.WriteErr();
							return null;
						}
						#endregion
					}
					al.Add(objOrder);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得医嘱信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			finally
			{
				this.Reader.Close();
			}
			return al;
		}
		#endregion

		#region 对药房，医技接口
		/// <summary>
		/// 执行记录
		/// 更新医嘱执行信息
		/// 对医技开放使用
		/// </summary>
		/// <param name="execOrder">执行档信息</param>
		/// <returns>0 success -1 fail</returns>
        public int UpdateRecordExec(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
		{
			#region 执行记录
			//执行记录
			//Order.ExecOrder.RecordExec.1
			//传入：0 id，1 执行人id,2执行科室，3执行科室名称 4执行时间,5执行标志 
			//传出：0 
			#endregion

			string strSql = "",strSqlName = "Order.ExecOrder.RecordExec.";
			string strItemType = "";

			strItemType = JudgeItemType(execOrder.Order);
			if (strItemType == "") return -1;
			strSqlName = strSqlName + strItemType;

			if(this.Sql.GetSql(strSqlName,ref strSql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
                strSql = string.Format(strSql, execOrder.ID, execOrder.Order.Oper.ID, execOrder.Order.ExeDept.ID, execOrder.Order.ExeDept.Name, execOrder.Order.ExecOper.OperTime.ToString(), Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsExec).ToString(), Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsConfirm).ToString()/*确认标记{DA77B01B-63DF-4559-B264-798E54F24ABB}*/);
			}
			catch
			{
				this.Err="传入参数不对！"+strSqlName;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 收费记录
		/// 更新执行医嘱收费人，收费标记，发票号等
		/// 对费用开放使用
		/// </summary>
		/// <param name="execOrder">执行档信息</param>
		/// <returns>0 success -1 fail</returns>
        public int UpdateChargeExec(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
		{
			#region 收费记录
			//收费记录
			//Order.ExecOrder.Charge.
			//传入：0 id，1 收费人id,2收费科室ID，3收费时间,5收费标志 6 处方号 7处方流水序号
			//传出：0 
			#endregion
			string strSql = "",strSqlName = "Order.ExecOrder.Charge.";
			string strItemType = "";

			strItemType = JudgeItemType (execOrder.Order);
			if (strItemType == "") return -1;
			strSqlName= strSqlName + strItemType;

			if(this.Sql.GetSql(strSqlName,ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,execOrder.ID,
					execOrder.ChargeOper.ID,execOrder.ChargeOper.Dept.ID,execOrder.ChargeOper.OperTime.ToString(),
					Neusoft.FrameWork.Function.NConvert.ToInt32(execOrder.IsCharge).ToString(),
					execOrder.Order.ReciptNO,execOrder.Order.SequenceNO);
			}
			catch(Exception ex)
			{
				this.Err = "传入参数不对！" + strSqlName + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 配药记录
		/// 对药房开放使用,更新DrugFlag
		/// </summary>
		/// <param name="execOrder">执行档信息</param>
		/// <returns>0 success -1 fail</returns>
        public int UpdateDrugExec(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
		{
			#region 配药记录
			//配药记录
			//Order.ExecOrder.DrugExec.
			//传入：0 id，1 配药状态 
			//传出：0 
			#endregion
			string strSql = "";
			string strItemType = "";

			strItemType = JudgeItemType(execOrder.Order);
			if (strItemType != "1") 
			{
                this.Err = Neusoft.FrameWork.Management.Language.Msg("请传入药品医嘱!");
				return -1;
			}

			if(this.Sql.GetSql("Order.ExecOrder.DrugExec.1",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,execOrder.ID,execOrder.DrugFlag.ToString());
			}
			catch(Exception ex)
			{
				this.Err="传入参数不对！Order.ExecOrder.DrugExec.1"+ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 更新医嘱配药标记
		/// 对药房的接口
		/// 对药房开放使用
		/// </summary>
		/// <param name="execOrderID">执行单ID</param>
		/// <param name="orderNo">主挡ID</param>
		/// <param name="userID">操作员</param>
		/// <param name="deptID">配药科室</param>
		/// <returns>-1 失败 0 成功</returns>
		public int UpdateOrderDruged( string execOrderID, string orderNo, string userID, string deptID )
		{
			string strSql = "";
			if(this.Sql.GetSql("Order.Update.ExecOrder.Druged",ref strSql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,execOrderID,userID,deptID);
			}
			catch(Exception ex)
			{
				this.Err="传入参数不对！Order.Update.ExecOrder.Druged"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql) <= 0) return -1;//更新执行档发药标记

			if(orderNo=="")
			{
				Neusoft.HISFC.Models.Order.ExecOrder obj = this.QueryExecOrderByExecOrderID(execOrderID,"1");//获得主挡信息
				if(obj == null) 
				{
					this.Err ="更新配药标记出错！"+this.Err;
					this.WriteErr();
					return -1;
				}
				return this.UpdateOrderStatus(obj.Order.ID,3);
			}
			else
			{
				return this.UpdateOrderStatus(orderNo,3);
			}
		}
		/// <summary>
		/// 更新医嘱配药标记
		/// 对药房开放使用
		/// </summary>
		/// <param name="execOrderID">执行单ID</param>
		/// <param name="userID">操作员</param>
		/// <param name="deptID">配药科室</param>
		/// <returns>-1 失败 0 成功</returns>
		public int UpdateOrderDruged(string execOrderID,string userID,string deptID)
		{
			return UpdateOrderDruged(  execOrderID,"" ,userID, deptID);
		}


		/// <summary>
		/// 发送摆药通知\设置发药方式
		/// 0不需发送/1集中发送/2分散发送/3已配药
		/// 对药房开放使用
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <param name="drugFlag">0不需发送/1集中发送/2分散发送/3已配药</param>
		/// <returns></returns>
		public int SetDrugFlag(string execOrderID,int drugFlag)
		{
			#region 更新发送方式
			//更新发送方式
			//Order.Order.SetDrugFlag.1
			//传入：0 OrderExecID，1 DrugFlag
			//传出：0 
			#endregion
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.SetDrugFlag.1",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,execOrderID,drugFlag.ToString());
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.SetDrugFlag.1";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 更新发送通知
		/// 对药房开放使用
		/// </summary>
		/// <param name="nurse"></param>
		/// <returns></returns>
		public int SendInformation(Neusoft.FrameWork.Models.NeuObject nurse)
		{
			#region 更新发送通知
			//更新发送通知
			//传入：0 nurseid，1 nursename,2操作人ID 3 操作人姓名，3操作时间
			//传出：0 
			#endregion
			string strSql = "";
			if(this.Sql.GetSql("Order.Order.send.insert.1",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,nurse.ID,nurse.Name,this.Operator.ID,this.Operator.Name,(this.GetDateTimeFromSysDateTime().Date).ToString());
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.send.insert.1";
				return -1;
			}
			if ( this.ExecNoQuery(strSql) >= 0) return 0;

			if(this.Sql.GetSql("Order.Order.send.update.1",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,nurse.ID,nurse.Name,this.Operator.ID,this.Operator.Name,(this.GetDateTimeFromSysDateTime().Date).ToString());
			}
			catch
			{
				this.Err="传入参数不对！Order.Order.send.update.1";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);

		}

      
      
		#endregion

		#region "Lis更新条码"
		/// <summary>
		/// 更新lis条码号
		/// 对LIS开放使用
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <param name="barCode"></param>
		/// <returns></returns>
		public int UpdateExecOrderLisBarCode(string execOrderID,string barCode)
		{
			string strSql = "";	
			//Order.ExecOrder.UpdateLisBarCode
			if(this.Sql.GetSql("Order.ExecOrder.UpdateLisBarCode",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,execOrderID,barCode);
			}
			catch
			{
				this.Err="传入参数不对！Order.ExecOrder.UpdateLisBarCode";
				this.WriteErr();
				return -1;
			}
		
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 更新LIS已经打印
		/// 对LIS开放使用
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <returns></returns>
		public int UpdateExecOrderLisPrint(string execOrderID)
		{
			string strSql = "";
		
			if(this.Sql.GetSql("Order.ExecOrder.UpdateLisPrinted",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql=string.Format(strSql,execOrderID);
			}
			catch
			{
				this.Err="传入参数不对！UpdateExecOrderLisPrint";
				this.WriteErr();
				return -1;
			}
		
			return this.ExecNoQuery(strSql);
		}
	
		#endregion

        #region 医技查询

        /// <summary>
        /// 根据执行科室查询需要确认项目的患者的所在科室
        /// </summary>
        /// <param name="deptID">执行科室</param>
        /// <returns></returns>
        public ArrayList QueryPatientDeptByConfirmDeptID(string deptID)
        {
            ArrayList alDept = new ArrayList();
            string strSQL = "";

            if (this.Sql.GetSql("Order.ExecOrder.QueryPatientDept.NeedConfirm.1", ref strSQL) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			try
			{
                strSQL = string.Format(strSQL, deptID);
			}
			catch
			{
                this.Err = "传入参数不对！Order.ExecOrder.QueryPatientDept.NeedConfirm.1";
				return null;
			}

            if (this.ExecQuery(strSQL) == -1)
            {
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();

                    obj.ID = this.Reader[0].ToString();

                    alDept.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            this.Reader.Close();

            return alDept;
        }

        /// <summary>
        /// 根据执行科室、患者所在科室查询需要确认项目的患者
        /// </summary>
        /// <param name="confirmDept">执行科室</param>
        /// <param name="patientDept">患者所在科室</param>
        /// <returns></returns>
        public ArrayList QueryPatientByConfirmDeptAndPatDept(string confirmDept,string patientDept)
        {
            ArrayList alPatient = new ArrayList();
            string strSQL = "";

            if (this.Sql.GetSql("Order.ExecOrder.QueryPatient.NeedConfirm.1", ref strSQL) == -1)
			{
				this.Err = this.Sql.Err;
				return null;
			}
			try
			{
                strSQL = string.Format(strSQL, confirmDept,patientDept);
			}
			catch
			{
                this.Err = "传入参数不对！Order.ExecOrder.QueryPatient.NeedConfirm.1";
				return null;
			}

            if (this.ExecQuery(strSQL) == -1)
            {
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();

                    obj.ID = this.Reader[0].ToString();

                    alPatient.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            this.Reader.Close();

            return alPatient;
        }

        #region {5197289A-AB55-410b-81EE-FC7C1B7CB5D7}
        /// <summary>
        /// 校验长期非药品医嘱执行档护士是否分解保存
        /// </summary>
        /// <param name="execOrderID">执行档流水号</param>
        /// <returns></returns>
        public bool CheckLongUndrugIsConfirm(string execOrderID)
        {
            string strSQL = "";

            if (this.Sql.GetSql("Order.ExecOrder.LongUndrug.CheckIsConfirm.1", ref strSQL) == -1)
            {
                this.Err = this.Sql.Err;
                return false;
            }

            try
            {
                strSQL = string.Format(strSQL, execOrderID);
            }
            catch
            {
                this.Err = "传入参数不对！Order.ExecOrder.LongUndrug.CheckIsConfirm.1";
                return false;
            }

            string flag = this.ExecSqlReturnOne(strSQL, "0");

            return Neusoft.FrameWork.Function.NConvert.ToBoolean(flag);
        }
        #endregion

        #endregion

        #region 医嘱单打印查询

        /// <summary>
        /// 查询医嘱单打印的医嘱
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns></returns>
        public ArrayList QueryPrnOrder(string inpatientNO)
        {
            
            string sql = "";
            ArrayList al = new ArrayList();
            //sql = OrderQuerySelect();
            //if (sql == null) return null;
            if (this.Sql.GetSql("Order.OrderPrn.QueryOrderByPatient", ref sql) == -1)
            {
                this.Err = "没有找到Order.OrderPrn.QueryOrderByPatient字段!";
                return null;
            }
            sql = string.Format(sql, inpatientNO);
            return this.myOrderQuery(sql);
        }
        #endregion

        #region 


        /// <summary>
        /// {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF} 扩展医嘱
        /// 按医嘱流水号查询一段时间内应该收费但是未收费的医嘱
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="itemType">项目类型</param>
        /// <param name="orderID">医嘱流水号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public ArrayList QueryUnFeeExecOrderByOrderID(string inpatientNo, string itemType, string orderID, DateTime beginDate, DateTime endDate)
        {

            string[] s;
            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();

            s = ExecOrderQuerySelect(itemType);
            for (int i = 0; i <= s.GetUpperBound(0); i++)
            {
                sql = s[i];
                if (sql == null)
                    return null;
                if (this.Sql.GetSql("Order.ExecOrder.QueryUnFeeExecOrderByOrderID.1", ref sql1) == -1)
                {
                    this.Err = "没有找到Order.ExecOrder.QueryUnFeeExecOrderByOrderID.1字段!";
                    return null;
                }
                sql = sql + " " + string.Format(sql1, inpatientNo, orderID, beginDate.ToString(), endDate.ToString());
                addExecOrder(al, sql);
            }
            return al;
        }



        #endregion

        #region 医嘱重整  {FB86E7D8-A148-4147-B729-FD0348A3D670} 增加函数

        /// <summary>
        /// 医嘱重整，给一部分医嘱状态置4，表示该医嘱归档
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int OrderReform(string OrderID)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.Update.Reform", ref strSql) == -1)
            {
                return -1;
            }

            return this.ExecNoQuery(strSql, OrderID);
        }

        #endregion

        #region addby xuewj 2010-10-23 PDA {D81BC4C8-FDD1-42ab-93A0-56049C99DF9D}

        /// <summary>
        /// 插入新执行单
        /// </summary>
        /// <param name="exc"></param>
        public int InsertPCCBill(Neusoft.HISFC.Models.Order.ExcBill exc)
        {
            string sql = string.Empty;

            if (Sql.GetSql("PPC.Order.InsertExecbillPPC", ref sql) == -1)
            {
                this.Err = "未找到SQL:PPC.Order.InsertExecbillPPC";
                return -1;
            }

            try
            {
                sql = string.Format(sql,
                                exc.ExecSqn,
                                exc.InpatientNo,
                                exc.BarCode,
                                "0",
                                "0",
                                exc.UseTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                exc.ExecName,
                                exc.UseName,
                                exc.QtyTot,
                                exc.FqName,
                                exc.DoseOnce,
                                exc.DoseUnit);
            }
            catch
            {
                this.Err = "执行插入PDA中间表数据出错" + this.Err;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }

        #endregion

        #region addby xuewj 2010-10-24 按住院号，时间查询有效医嘱

        /// <summary>
        /// 按开立时间查询医嘱
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ArrayList QueryValidOrder(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            string sql = "", sql1 = "";
            ArrayList al = new ArrayList();
            #region 按开立时间查询医嘱
            //按开立时间查询医嘱
            //Order.Order.QueryOrder.3
            //传入：0 inpatientno 1BeginTime 2EndTime
            //传出：ArrayList
            #endregion

            sql = OrderQuerySelect();
            if (sql == null) return null;
            if (this.Sql.GetSql("Order.Order.QueryOrder.7", ref sql1) == -1)
            {
                this.Err = "没有找到Order.Order.QueryOrder.3字段!";
                return null;
            }
            sql = sql + " " + string.Format(sql1, inpatientNO, beginTime, endTime);
            return this.myOrderQuery(sql);
        }

        #endregion
    }
}
