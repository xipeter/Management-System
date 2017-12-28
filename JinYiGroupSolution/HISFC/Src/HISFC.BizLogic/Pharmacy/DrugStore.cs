using System;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.HISFC.Models;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Pharmacy 
{
    /// <summary>
    /// [功能描述: 药品摆药管理类]<br></br>
    /// [创 建 者: Cuip]<br></br>
    /// [创建时间: 2005-01]<br></br>
    /// <修改记录
    ///		修改人='梁俊泽'
    ///		修改时间='2006-09-28'
    ///		修改目的='系统重构'
    ///		修改描述='函数名称规范 格式规范'
    ///  />
    /// <修改记录>
    ///    1 取消更新方式的终端处方调剂，采用新处方调剂方式by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F} 
    /// </修改记录>
    /// </summary>
    public class DrugStore : Neusoft.FrameWork.Management.Database 
	{
		public DrugStore() 
		{   
			
		}

        #region 静态变量

        /// <summary>
        /// 科室地址 (返回发药信息  前置字符)
        /// </summary>
        public static System.Collections.Hashtable hsDeptAddress = null;

        /// <summary>
        /// 用法对照
        /// </summary>
        internal static System.Collections.Hashtable hsUsageContrast = null;

        /// <summary>
        /// 剂型对照
        /// </summary>
        internal static System.Collections.Hashtable hsDosageContrast = null;
        #endregion

		#region 摆药单分类

        #region 基础增、删、改操作

        /// <summary>
		/// 获得update或者insert摆药单分类表的传入参数数组
		/// </summary>
		/// <param name="DrugBillClass">入库申请类</param>
		/// <returns>成功返回字符串数组 失败返回null</returns>
		private string[] myGetParmDrugBillClass(DrugBillClass DrugBillClass) 
		{
			#region "接口说明"
			//1、摆药分类代码
			//2、摆药分类名称
			//3、打印类型1汇总2明细3草药4大处方
			//4、摆药类型
			//5、停用标记1-停用0－有效
			//6、操作员
			//7、操作时间
			//8、备注
 
			#endregion
			string[] strParm={   DrugBillClass.ID,
								 DrugBillClass.Name,
								 DrugBillClass.DrugAttribute.ID.ToString(),
								 DrugBillClass.PrintType.ID.ToString(),
				NConvert.ToInt32(DrugBillClass.IsValid).ToString(),
								 DrugBillClass.Memo,
								 this.Operator.ID
							 };
								 
			return strParm;
		}

		/// <summary>
		/// 取摆药单分类信息列表，可能是一条或者多条药品记录
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>摆药单分类数组</returns>
		private ArrayList myGetDrugBillClass(string SQLString) 
		{
			ArrayList al=new ArrayList();  //用于返回药品信息的数组
			DrugBillClass info;            //返回数组中的摆药单分类信息
			
			this.ExecQuery(SQLString);
			try 
			{
				while (this.Reader.Read()) 
				{
					info = new DrugBillClass();
					try 
					{
						info.ID = this.Reader[0].ToString();                          //摆药单分类编码
						info.Name = this.Reader[1].ToString();                        //摆药单分类名称
						info.PrintType.ID = this.Reader[2].ToString();                //打印类型
						info.IsValid = NConvert.ToBoolean(this.Reader[3].ToString()); //是否有效
						info.Memo = this.Reader[4].ToString();                        //备注
						info.Oper.ID     = this.Reader[5].ToString();                //操作员编码
						try{info.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());}	
						catch{}//操作时间
					}
					catch(Exception ex) 
					{
						this.Err="获得摆药单分类信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					
					al.Add(info);
				}				
			}//抛出错误
            catch(Exception ex) 
			{
				this.Err="获得摆药单分类信息时，执行SQL语句出错！myGetDrugBillClass"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return al;
			}
			finally
			{
				this.Reader.Close();
			}

			return al;
		}

        /// <summary>
        /// 插入一条摆药单分类记录
        /// </summary>
        /// <param name="info">摆药单分类实体</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int InsertDrugBillClass(DrugBillClass info)
        {
            string strSql = "";

            if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugBillClass", ref strSql) == -1) return -1;
            try
            {
                //取摆药单分类流水号
                string ID = "";
                ID = this.GetSysDateTime("yyMMddHHmmss");
                if (ID == "-1") return -1;

                //赋值给info.ID，以便调用此方法的对象使用此摆药单分类流水号
                if (info.ID != "P" && info.ID != "R")
                {
                    info.ID = ID;
                }

                string[] strParm = myGetParmDrugBillClass(info);  //取参数列表
                strSql = string.Format(strSql, strParm);       //
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新一条摆药单分类记录
        /// </summary>
        /// <param name="info">摆药单分类实体</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int UpdateDrugBillClass(DrugBillClass info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugBillClass", ref strSql) == -1) return -1;

            try
            {
                string[] strParm = myGetParmDrugBillClass(info);  //取参数列表
                strSql = string.Format(strSql, strParm);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 根据摆药单分类编码,删除一条记录
        /// </summary>
        /// <param name="ID">摆药单分类编码</param>
        /// <returns>成功返回删除条数 失败返回null</returns>
        public int DeleteDrugBillClass(string ID)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugBillClass", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, ID);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "传入参数不正确！Pharmacy.Item.DrugBillClass";
                return -1;
            }
            int parm = this.ExecNoQuery(strSql);
            if (parm == -1) return -1;

            //删除摆药分类的同时，删除摆药分类明细数据
            return this.DeleteDrugBillList(ID);
        }

        /// <summary>
        /// 保存摆药单分类－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
        /// </summary>
        /// <param name="info">摆药单分类实体</param>
        /// <returns>0未更新，大于1成功，-1失败</returns>
        public int SetDrugBillClass(DrugBillClass info)
        {
            int parm;
            #region 先更新后插入
            //			//执行更新操作
            //			parm = UpdateDrugBillClass(info);
            //
            //			//如果没有找到可以更新的数据，则插入一条新记录
            //			if (parm == 0 )
            //			{
            //				parm = InsertDrugBillClass(info);
            //			}
            #endregion

            //如果是新增加的数据则插入一条新记录，否则更新此记录
            if (info.ID == "")
                parm = InsertDrugBillClass(info);
            else
                parm = UpdateDrugBillClass(info);

            return parm;
        }

        #endregion

        #region 内部使用

        /// <summary>
		/// 根据摆药单分类编码获得某一摆药单分类信息
		/// </summary>
		/// <param name="ID">摆药单分类编码</param>
		/// <returns>成功返回摆药单分类信息 失败返回null</returns>
		public DrugBillClass GetDrugBillClass(string ID) 
		{            
			string strSelect ="";  //获得摆药单分类信息的SELECT语句
			string strSQL  ="";  //根据摆药单分类编码获得某一摆药单分类信息的WHERE条件语句

			//取SELECT语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugBillClass",ref strSelect) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugBillClass字段!";
				return null;
			}

			//取WHERE条件语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugBillClass.Where",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugBillClass.Where字段!";
				return null;
			}

			try 
			{
				strSQL = string.Format(strSelect + " " + strSQL,ID);
			}
			catch 
			{
				return null;
			}

			//根据SQL语句取摆药单分类数组并返回数组中的首条记录
			try 
			{
				ArrayList al   = this.myGetDrugBillClass(strSQL);
				//如果没有取到数据，提示错误
				if (al.Count == 0) 
				{
					this.Err = "没有找到对应的摆药单！ 编码："+ID;
					this.WriteErr();
					return null;
				}
				return (DrugBillClass)al[0];
			}
			catch (Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}
		}

		/// <summary>
		/// 根据摆药单分类明细（医嘱类型，用法，药品类型，药品性质，药品剂型）获得某一摆药单分类信息
		/// </summary>
		/// <param name="orderType">医嘱类型</param>
		/// <param name="usageCode">用法</param>
		/// <param name="drugType">药品类型</param>
		/// <param name="drugQuality">药品性质</param>
		/// <param name="dosageFormCode">药品剂型</param>
		/// <returns>查找成功返回实体 失败返回null 未找到返回ErrCode -1</returns>
		public DrugBillClass GetDrugBillClass(string orderType, string usageCode, string drugType, string drugQuality, string dosageFormCode) 
		{     
			string strSQL ="";  //获得摆药单分类信息的SQL语句

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugBillClass.ByList",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugBillClass.ByList字段!";
				return null;
			}

			try 
			{
				string[] parm = {
									orderType,
									usageCode,
									drugType,
									drugQuality,
									dosageFormCode
								};
				strSQL = string.Format(strSQL, parm);
			}
			catch 
			{
				return null;
			}

			//根据SQL语句取摆药单分类数组并返回数组中的首条记录
			try 
			{
				ArrayList al   = this.myGetDrugBillClass(strSQL);
				//如果没有取到数据，提示错误
				if (al.Count == 0) 
				{
					this.Err = "没有找到对应的摆药单，请检查是否在摆药单中维护了数据。\n医嘱类型:"+orderType
						+" \n药品类型:"+drugType + " \n用法:"+ usageCode +" \n药品性质:"+drugQuality+" \n药品剂型:" + dosageFormCode;
					this.ErrCode = "-1";
					this.WriteErr();
					return null;
				}
				return (DrugBillClass)al[0];
			}
			catch (Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}
		}

        /// <summary>
		/// 根据摆药单分类明细（医嘱类型，用法，药品类型，药品性质，药品剂型）获得某一摆药单分类信息
		/// </summary>
        /// <param name="isUsageDosageClass">摆药单是否使用用法/剂型大类</param>
		/// <param name="orderType">医嘱类型</param>
		/// <param name="usageCode">用法</param>
		/// <param name="drugType">药品类型</param>
		/// <param name="drugQuality">药品性质</param>
		/// <param name="dosageFormCode">药品剂型</param>
		/// <returns>查找成功返回实体 失败返回null 未找到返回ErrCode -1</returns>
        public DrugBillClass GetDrugBillClass(bool isUsageDosageClass,string orderType, string usageCode, string drugType, string drugQuality, string dosageFormCode)
        {
            if (!isUsageDosageClass)
            {
                return GetDrugBillClass(orderType, usageCode, drugType, drugQuality, dosageFormCode);
            }
            else
            {
                //获取传入参数的用法/剂型对应的大类明细
                if (DrugStore.hsUsageContrast == null || DrugStore.hsDosageContrast == null)      //获取用法大类对照
                {
                    Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
                    if (this.Trans != null)
                    {
                        consManager.SetTrans(this.Trans);
                    }
                    //获取用法大类对照信息
                    ArrayList alUsageContrast = consManager.GetList("USAGECONTRAST");
                    if (alUsageContrast == null || alUsageContrast.Count == 0)
                    {
                        DrugStore.hsUsageContrast = new Hashtable();
                    }
                    else
                    {
                        foreach (Neusoft.HISFC.Models.Base.Const usageContrast in alUsageContrast)
                        {
                            DrugStore.hsUsageContrast.Add(usageContrast.ID, usageContrast.Name);
                        }
                    }
                    //获取剂型大类对照信息
                    ArrayList alDosageContrast = consManager.GetList("DOSAGECONTRAST");
                    if (alDosageContrast == null || alDosageContrast.Count == 0)
                    {
                        DrugStore.hsDosageContrast = new Hashtable();
                    }
                    else
                    {
                        foreach (Neusoft.HISFC.Models.Base.Const dosageContrast in alDosageContrast)
                        {
                            DrugStore.hsDosageContrast.Add(dosageContrast.ID, dosageContrast.Name);
                        }
                    }
                }
                //获取对照大类
                if (DrugStore.hsDosageContrast.ContainsKey(dosageFormCode))
                {
                    dosageFormCode = DrugStore.hsDosageContrast[dosageFormCode] as string;
                }
                //获取对照大类
                if (DrugStore.hsUsageContrast.ContainsKey(usageCode))
                {
                    usageCode = DrugStore.hsUsageContrast[usageCode] as string;
                }

                return GetDrugBillClass(orderType, usageCode, drugType, drugQuality, dosageFormCode);
            }
        }

		/// <summary>
		/// 获得摆药单分类信息列表
		/// </summary>
		/// <returns>摆药单分类数组</returns>
		public ArrayList QueryDrugBillClassList() 
		{
			string strSelect = "";  //获得全部摆药单分类信息的SELECT语句
			string strOrder  = "";  //获得全部摆药单分类信息的ORDER语句

			//取SELECT语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugBillClass",ref strSelect) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugBillClass字段!";
				return null;
			}

			//取ORDER条件语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugBillClass.Order",ref strOrder) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugBillClass.Order字段!";
				return null;
			}

			//根据SQL语句取摆药单分类数组并返回数组
			return this.myGetDrugBillClass(strSelect + strOrder);
        }

        #endregion

        #endregion 摆药单分类

        #region 摆药单分类明细

        /// <summary>
		/// 根据摆药单分类编码获得摆药单分类明细
		/// </summary>
		/// <param name="drugBillClassCode">分类编码</param>
        /// <param name="column">指定去处重复的列名称</param>
		/// <returns>成功返回摆药单分类明细 失败返回null</returns>
		public ArrayList QueryDrugBillList(string drugBillClassCode,string column) 
		{
			ArrayList al = new ArrayList();
			string strSelect = "";  //获得全部摆药单分类信息的SELECT语句

			//临时使用固定的sql语句，以后会有变化
            strSelect = "SELECT DISTINCT " + column + " FROM PHA_STO_BILLLIST WHERE BILLCLASS_CODE = '" + drugBillClassCode + "'";
			DrugBillList info;            //返回数组中的摆药单分类信息

			if (this.ExecQuery(strSelect) == -1) 
			{
				this.Err = "取摆药单分类明细时出错：" + this.Err;
				return null;
			}

            try
            {
                while (this.Reader.Read())
                {
                    info = new DrugBillList();
                    try
                    {
                        info.ID = this.Reader[0].ToString();
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得摆药单分类明细信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }

                    al.Add(info);
                }

                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得摆药单分类信息时，执行SQL语句出错！myGetDrugBillClass" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        #region 基础增、删、改操作

        /// <summary>
		/// 插入摆药单分类明细记录
		/// </summary>
		/// <param name="info">摆药单分类明细实体</param>
		/// <returns>1成功，-1失败</returns>
		public int InsertDrugBillList(DrugBillList info) 
		{
			string strSql = "";
					
			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugBillList",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = myGetParmDrugBillList(info);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
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
		/// 根据摆药单分类编码,删除摆药单分类明细
		/// </summary>
		/// <param name="ID">摆药单分类编码</param>
		/// <returns>0没有更新的数据，1成功，-1失败</returns>
		public int DeleteDrugBillList(string ID) 
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugBillList",ref strSql)==-1) return -1;
						
			try 
			{  
				strSql = string.Format(strSql, ID);

			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="传入参数不正确！Pharmacy.Item.DeleteDrugBillList";
				return -1;
			}      			
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 获得update或者insert摆药单分类明细表的传入参数数组
		/// </summary>
		/// <param name="DrugBillList">入库申请类</param>
		/// <returns>成功返回字符串参数数组 失败返回null</returns>
		private string[] myGetParmDrugBillList(DrugBillList DrugBillList) 
		{
			#region "接口说明"
			//摆药分类代码
			//医嘱类型编码
			//药品用法编码
			//药品类型编码
			//药品性质编码
			//剂型编码
 
			#endregion
			string[] strParm={
								 DrugBillList.DrugBillClass.ID,
								 DrugBillList.OrderType.ID,
								 DrugBillList.Usage.ID,
								 DrugBillList.DrugType.ID,
								 DrugBillList.DrugQuality.ID,
								 DrugBillList.DosageForm.ID
							 };
								 
			return strParm;
        }

        #endregion

        #region 更新操作暂时没用

        /// <summary>
		/// 更新摆药单分类明细记录
		/// </summary>
		/// <param name="info">摆药单分类明细实体</param>
		/// <returns>0没有更新的数据，1成功，-1失败</returns>
		public int UpdateDrugBillList(DrugBillList info) 
		{			
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugBillList",ref strSql)==-1) return -1;
					
			try 
			{   				
				string[] strParm = myGetParmDrugBillList(info);  //取参数列表
				strSql = string.Format(strSql, strParm);

			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			
				
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 设置摆药单分类明细实体
		/// 先删除，后插入
		/// </summary>
		/// <param name="info">摆药单分类明细实体</param>
		/// <returns></returns>
		public int SetDrugBillList(DrugBillList info) 
		{
			int parm;
			parm = this.DeleteDrugBillList(info.ID);
			if (parm == -1) return parm;

			return this.InsertDrugBillList(info);

		}

		#endregion

		#endregion 摆药单分类明细

		#region 摆药台

        #region 内部使用

        /// <summary>
		/// 取摆药台流水号
		/// </summary>
		/// <returns>"-1"出错，oterhs 成功</returns>
		public string GetDrugControlNO()
        {
            #region //格式化时间错误 {35DE4ACA-F66C-47fd-845C-5AFF253731F7} wbo 2010-08-23
            //return this.GetSysDateTime("YYMMDDHH24MISS");
            string conNO = "-1";
            try
            {
                conNO = this.GetDateTimeFromSysDateTime().ToString("yyMMddHHmmss");
            }
            catch (Exception e)
            {
                conNO = "-1";
            }
            return conNO;
            #endregion
		}
					
		/// <summary>
		/// 根据科室编码和摆药性质，取摆药台信息
		/// </summary>
		/// <param name="deptCode">科室编码</param>
        /// <param name="drugAtr">摆药台性质</param>
		/// <returns>成功返回摆药台数组 失败返回null</returns>
		public Neusoft.HISFC.Models.Pharmacy.DrugControl GetDrugControl(string deptCode, Neusoft.HISFC.Models.Pharmacy.DrugAttribute.enuDrugAttribute drugAtr ) 
		{
			string strSQL = "";  //获得某一科室全部摆药台信息的SQL语句
			
			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugControl",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugControl字段!";
				return null;
			}

			//根据SQL语句取摆药台数组并返回数组中的首条记录
			try 
			{
				string[] parm = {deptCode, drugAtr.ToString()};
				strSQL = string.Format(strSQL, parm);
				//取摆药台数组
				ArrayList al  = this.myGetDrugControl(strSQL);
				//如果没有取到数据，则返回新实体
				if (al.Count == 0) 
				{
					DrugControl info = new DrugControl();
					info.Dept.ID = deptCode;
					info.DrugAttribute.ID = drugAtr;
					return info;
				}
				//返回数组中的首条记录
				return al[0] as DrugControl;
			}
			catch 
			{
				return null;
			}
		}

		/// <summary>
		/// 根据科室编码，取本科室的全部摆药台列表
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <returns>摆药台数组</returns>
		public ArrayList QueryDrugControlList(string deptCode) 
		{
			ArrayList al = new ArrayList();
			string strSQL = "";  //获得某一科室全部摆药台信息的SELECT语句
			
			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugControlList",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugControlList字段!";
				return null;
			}
						
			strSQL = string.Format(strSQL, deptCode);
			//取摆药台数据列表			
			return this.myGetDrugControl(strSQL);
		}

		/// <summary>
		/// 根据摆药台编码，取此摆药台中的全部明细
		/// </summary>
		/// <param name="drugControlCode">摆药台编码</param>
		/// <returns>摆药单分类数组</returns>
		public ArrayList QueryDrugControlDetailList(string drugControlCode) 
		{
			ArrayList al = new ArrayList();
			string strSelect = "";  
			
			//取SELECT语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugControlDetailList",ref strSelect) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugControlDetailList字段!";
				return null;
			}
			
			DrugBillClass info;   //摆药单分类实体			
									
			strSelect = string.Format(strSelect, drugControlCode);
			if (this.ExecQuery(strSelect) == -1) 
			{
				this.Err = "取摆药台明细列表时出错：" + this.Err;
				return null;
			}
            try
            {
                while (this.Reader.Read())
                {
                    info = new DrugBillClass();
                    try
                    {
                        info.ID = this.Reader[0].ToString();                          //摆药单分类编码
                        info.Name = this.Reader[1].ToString();                        //摆药单分类名称
                        info.PrintType.ID = this.Reader[2].ToString();                //打印类型
                        info.IsValid = NConvert.ToBoolean(this.Reader[3].ToString()); //是否有效
                        info.Memo = this.Reader[4].ToString();                        //备注
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得摆药台明细列表时出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }

                    al.Add(info);
                }
                return al; ;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得摆药台明细列表时，执行SQL语句出错！myGetDrugBillClass" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        #endregion

        #region 基础增、删、改操作

        /// <summary>
		/// 向摆药台表中插入一条记录
		/// </summary>
		/// <param name="info">摆药台实体</param>
		/// <returns>1成功，-1失败</returns>
		public int InsertDrugControl(DrugControl info) 
		{
			string strSql = "";
					
			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugControl",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = myGetParmDrugControl(info);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
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
		/// 删除一个摆药台（数据库中是多条记录）
		/// </summary>
		/// <param name="ID">摆药台编码</param>
		/// <returns>0没有更新的数据，1成功，-1失败</returns>
		public int DeleteDrugControl(string ID) 
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugControl",ref strSql)==-1) return -1;
						
			try 
			{  
				strSql = string.Format(strSql, ID);

			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="传入参数不正确！Pharmacy.Item.DrugControl";
				return -1;
			}      			
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 获得update或者insert摆药单分类明细表的传入参数数组
		/// </summary>
		/// <param name="drugControl">入库申请类</param>
		/// <returns>成功返回字符串数组 失败返回null</returns>
		private string[] myGetParmDrugControl(DrugControl drugControl) 
		{
			#region "接口说明"
			//摆药台编码
			//摆药台名称
			//摆药单分类编码
			//摆药单分类明处
			//摆药属性
			//科室编码
 
			#endregion
			string[] strParm={
								 drugControl.ID,                         //摆药台编码
								 drugControl.Name,                       //摆药台名称
								 drugControl.DrugBillClass.ID,           //摆药单分类编码
								 drugControl.DrugBillClass.Name,         //摆药单分类明处
								 drugControl.DrugAttribute.ID.ToString(),//摆药属性
								 drugControl.SendType.ToString(),        //医嘱发送类型	
								 drugControl.Dept.ID,			         //科室编码					 
								 this.Operator.ID,                       //操作员
								 drugControl.Memo,                       //备注
								 drugControl.ShowLevel.ToString(),        //显示等级：0显示科室汇总，1显示科室明细，2显示患者明细
                                 NConvert.ToInt32(drugControl.IsAutoPrint).ToString(), //是否自动打印
                                 NConvert.ToInt32(drugControl.IsPrintLabel).ToString(),//出院带药是否打印门诊标签
                                 NConvert.ToInt32(drugControl.IsBillPreview).ToString(),//摆药单是否需要预览
                                 drugControl.ExtendFlag,
                                 drugControl.ExtendFlag1
							 };
								 
			return strParm;
		}

		/// <summary>
		/// 取摆药台信息
		/// </summary>
		/// <param name="strSQL">取摆药台的SQL语句</param>
		/// <returns>成功返回摆药台数组 失败返回null</returns>
		private ArrayList myGetDrugControl(string strSQL) 
		{
			if (this.ExecQuery(strSQL) == -1) 
			{
				this.Err = "取摆药台时出错：" + this.Err;
				return null;
			}
			ArrayList al = new ArrayList();
			try 
			{
				DrugControl info;   //摆药台实体	
				while (this.Reader.Read()) 
				{
					info = new DrugControl();
					info.ID = this.Reader[0].ToString();                 //摆药台编码
					info.Name = this.Reader[1].ToString();               //摆药台名称
					info.DrugAttribute.ID = this.Reader[2].ToString();   //摆药属性
					info.SendType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString());//医嘱发送类型
					info.Dept.ID = this.Reader[4].ToString();            //科室编码
					info.Memo = this.Reader[5].ToString();               //备注
					info.ShowLevel = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6].ToString());//显示等级：0显示科室汇总，1显示科室明细，2显示患者明细
                    info.IsAutoPrint = NConvert.ToBoolean(this.Reader[7].ToString());
                    info.IsPrintLabel = NConvert.ToBoolean(this.Reader[8].ToString());
                    info.IsBillPreview = NConvert.ToBoolean(this.Reader[9].ToString());
                    info.ExtendFlag = this.Reader[10].ToString();
                    info.ExtendFlag1 = this.Reader[11].ToString();

					al.Add(info);
				}				
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得摆药台时出错！"+ex.Message;
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

        #endregion 摆药台

        #region 摆药通知

        #region 内部使用

        /// <summary>
		/// 获得某一申请科室的未摆药通知列表
		/// </summary>
		/// <param name="sendDeptCode">申请科室编码</param>
		/// <returns>成功返回摆药通知信息 失败返回null</returns>
		public ArrayList QueryDrugMessageList(string sendDeptCode) 
		{
			string strSQL = "";    //获得某一申请科室的全部摆药通知列表的SELECT语句
			
			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.BySendDept",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugMessageList.BySendDept字段!";
				return null;
			}
			try 
			{
				strSQL = string.Format(strSQL, sendDeptCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.BySendDept";
				return null;
			}
			return myGetDrugMessage(strSQL);
		}

		/// <summary>
		/// 获得某一申请科室的全部摆药通知列表
		/// </summary>
		/// <param name="sendDeptCode">申请科室编码</param>
		/// <returns>成功返回摆药通知列表 失败返回null</returns>
		public ArrayList QueryAllDrugMessageList(string sendDeptCode)
		{
			string strSQL = "";    //获得某一申请科室的全部摆药通知列表的SELECT语句
			
			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetAllDrugMessageList",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetAllDrugMessageList字段!";
				return null;
			}
			try 
			{
				strSQL = string.Format(strSQL, sendDeptCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "|Pharmacy.DrugStore.GetAllDrugMessageList";
				return null;
			}

			ArrayList al = new ArrayList();
			if (this.ExecQuery(strSQL) == -1) 
			{
				this.Err = "取摆药通知列表时出错：" + this.Err;
				return null;
			}
            try
            {
                DrugMessage info;   //摆药通知实体		
                while (this.Reader.Read())
                {
                    info = new DrugMessage();
                    try
                    {
                        info.StockDept.ID = this.Reader[0].ToString();          //发送科室编码
                        info.StockDept.Name = this.Reader[1].ToString();          //发送科室名称
                        info.DrugBillClass.ID = this.Reader[2].ToString();          //摆药单分类编码
                        info.DrugBillClass.Name = this.Reader[3].ToString();          //摆药单分类名称
                        info.SendType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());      //摆药类型1-集中摆药2-临时摆药
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得摆药通知信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    al.Add(info);
                }
                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得摆药通知信息时，执行SQL语句出错！myGetDrugBillClass" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }			
		}
		
		/// <summary>
		/// 获得某一摆药台中全部摆药通知列表
		/// SendType=1集中，2临时
		/// 当SendType＝0时，显示全部类型的摆药通知。
		/// </summary>
		/// <param name="drugControl">摆药台</param>
		/// <returns>成功返回摆药通知数组 失败返回null</returns>
		public ArrayList QueryDrugMessageList(DrugControl drugControl) 
		{
			//如果没有指定发送科室，则取全部发送科室的通知
			string strSQL = "";    //获得某一摆药台（摆药台中有科室信息）中全部摆药通知列表的SELECT语句

			#region 取手术室摆药单
			//取SQL语句
			//			if (drugControl.ID =="P") {
			//				if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.ByOPR",ref strSQL) == -1) {
			//					this.Err="没有找到Pharmacy.DrugStore.GetDrugMessageList.ByOPR字段!";
			//					return null;
			//				}
			//				try {
			//					string[] strParm={drugControl.Dept.ID};
			//					strSQL = string.Format(strSQL, strParm);
			//				}
			//				catch(Exception ex) {
			//					this.ErrCode=ex.Message;
			//					this.Err=ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.ByOPR";
			//					return null;
			//				}
			//			}
			#endregion 

			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.ByDrugControl",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugMessageList.ByDrugControl字段!";
				return null;
			}
			try 
			{
				string[] strParm={drugControl.ID};
				strSQL = string.Format(strSQL, strParm);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.ByDrugControl";
				return null;
			}
			return myGetDrugMessage(strSQL);
		}

		/// <summary>
		/// 获得某一摆药通知的明细列表;
		/// </summary>
		/// <param name="drugMessage">摆药通知</param>
		/// <returns>成功返回摆药通知信息 失败返回null</returns>
		public ArrayList QueryDrugMessageList(DrugMessage drugMessage) 
		{

			string strSQL = "";    //获得某一摆药通知的明细列表的SQL语句

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.ByDrugMessage",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugMessageList.ByDrugMessage字段!";
				return null;
			}
			try 
			{
				string[] strParm={
									 drugMessage.StockDept.ID, 
									 drugMessage.DrugBillClass.ID, 
									 drugMessage.SendType.ToString()
								 };
				strSQL = string.Format(strSQL, strParm);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.ByDrugMessage";
				return null;
			}
			return myGetDrugMessage(strSQL);
		}

		/// <summary>
		/// 成功返回摆药通知信息
		/// </summary>
		/// <param name="drugControlID">摆药台编码</param>
		/// <param name="drugMessage">摆药通知</param>
		/// <returns>成功返回摆药通知信息 失败返回null</returns>
		public ArrayList QueryDrugBillList(string drugControlID,DrugMessage drugMessage)
		{
			string strSQL = "";		
			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugBillList.ByDept",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugBillList.ByDept字段!";
				return null;
			}
			try 
			{
				string[] strParm={
									 drugControlID,
									 drugMessage.ApplyDept.ID, 
									 drugMessage.StockDept.ID, 
									 drugMessage.SendType.ToString()
								 };
				strSQL = string.Format(strSQL, strParm);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "|Pharmacy.DrugStore.GetDrugBillList.ByDept";
				return null;
			}
			return myGetDrugMessage(strSQL);
		}

        /// <summary>
        /// 更新摆药通知状态
        /// </summary>
        /// <param name="drugDeptCode">发药药房</param>
        /// <param name="deptCode">申请科室</param>
        /// <param name="billClassCode">摆药单类别</param>
        /// <param name="sendType">发送类型 1 集中 2 临时</param>
        /// <param name="state">通知状态 0 通知 1 已摆</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateDrugMessage(string drugDeptCode, string deptCode, string billClassCode, int sendType, string state)
        {
            string strSql = "";

            if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugMessageState", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, drugDeptCode, deptCode, billClassCode, sendType.ToString(), state);       //
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确！" + "Pharmacy.DrugStore.UpdateDrugMessageState"; ;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        #endregion

        #region 基础增、删、改操作

        /// <summary>
		/// 向摆药台表中插入一条记录
		/// </summary>
		/// <param name="drugMessage">摆药台实体</param>
		/// <returns>1成功，-1失败</returns>
		public int InsertDrugMessage(DrugMessage drugMessage) 
		{
			string strSql = "";
					
			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugMessage",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = myGetParmDrugMessage(drugMessage);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.InsertDrugMessage";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
			
		/// <summary>
		/// 向摆药通知表中插入一条记录
		/// </summary>
		/// <param name="drugMessage">摆药通知实体</param>
		/// <returns>1成功，-1失败</returns>
		public int UpdateDrugMessage(DrugMessage drugMessage) 
		{
			string strSql = "";
					
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugMessage",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = myGetParmDrugMessage (drugMessage);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确！" + "Pharmacy.DrugStore.UpdateDrugMessage";;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 删除一条摆药通知
		/// </summary>
		/// <param name="ID">摆药通知流水号</param>
		/// <returns>0没有更新的数据，1成功，-1失败</returns>
		public int DeleteDrugMessage(string ID) 
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugMessage",ref strSql)==-1) return -1;
						
			try 
			{  
				strSql = string.Format(strSql, ID);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="传入参数不正确！Pharmacy.Item.DeleteDrugMessage";
				return -1;
			}      			
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 设置摆药通知
		/// 先执行更新操作，如果数据库中没有记录则执行插入操作
		/// </summary>
		/// <param name="drugMessage">摆药通知</param>
		/// <returns></returns>
		public int SetDrugMessage(DrugMessage drugMessage) 
		{
			//先执行更新操作
			int parm = UpdateDrugMessage(drugMessage);
			if (parm == 0) 
			{
				//如果数据库中没有记录则执行插入操作
				parm = InsertDrugMessage(drugMessage);
			}
			return parm;
		}

		/// <summary>
		/// 获得update或者insert摆药通知传入参数数组
		/// </summary>
		/// <param name="drugMessage">摆药通知</param>
		/// <returns>成功返回字符串参数数组  失败返回null</returns>
		private string[] myGetParmDrugMessage(DrugMessage drugMessage) 
		{
			string[] strParm={
								 drugMessage.ApplyDept.ID,         //科室或者病区编码
								 drugMessage.ApplyDept.Name,       //科室或者病区编码
								 drugMessage.DrugBillClass.ID,    //摆药单分类代码
								 drugMessage.DrugBillClass.Name,  //摆药单分类名称
								 drugMessage.SendType.ToString(), //发送类型0全部,1-集中,2-临时
								 drugMessage.SendFlag.ToString(), //状态0-通知,1-已摆
								 drugMessage.StockDept.ID,		  //科室编码					 
								 this.Operator.ID,                //操作员编码				 
								 this.Operator.Name,              //操作员姓名
			};
								 
			return strParm;
		}

		/// <summary>
		/// 根据SQL语句，取摆药通知数组
		/// </summary>
		/// <param name="strSQL">查询SQL语句</param>
		/// <returns>成功返回摆药通知数组 失败返回null</returns>
		private ArrayList myGetDrugMessage(string strSQL) 
		{		
			ArrayList al = new ArrayList();

			if (this.ExecQuery(strSQL) == -1) 
			{
				this.Err = "取摆药通知列表时出错：" + this.Err;
				return null;
			}
			try 
			{
				DrugMessage info;   //摆药通知实体		
				while (this.Reader.Read()) 
				{
					info = new DrugMessage();
					try 
					{
						info.ApplyDept.ID        = this.Reader[0].ToString();          //发送科室编码
						info.ApplyDept.Name      = this.Reader[1].ToString();          //发送科室名称
						info.DrugBillClass.ID   = this.Reader[2].ToString();          //摆药单分类编码
						info.DrugBillClass.Name = this.Reader[3].ToString();          //摆药单分类名称
						info.SendType    = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());      //摆药类型1-集中摆药2-临时摆药
						info.SendTime   = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString()); //通知时间
						info.SendFlag    = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6].ToString());      //发送状态0－通知，1－已摆药
						info.StockDept.ID  = this.Reader[7].ToString();                 //发药科室编码				 
						info.ID          = this.Reader[8].ToString();                 //操作员编码				 
						info.Name        = this.Reader[9].ToString();                 //操作员姓名
					}
					catch(Exception ex) 
					{
						this.Err="获得摆药通知信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					
					al.Add(info);
				}
                return al;
				
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得摆药通知信息时，执行SQL语句出错！myGetDrugBillClass"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			finally
			{
				this.Reader.Close();
			}
        }

        #endregion

        #endregion 摆药通知

        #region 摆药出库申请

        /// <summary>
		/// 取某一科室申请，某一目标本科室未核准的某一摆药单分类中的申请列表
		/// 例如，某一药房查看某一科室（病区）中某一张摆药单分类中的待摆药信息	
		/// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="objectDeptCode">申请科室</param>
        /// <param name="drugBillClass">摆药单分类编码</param>
		/// <returns>成功返回摆药单内申请 失败返回null</returns>
		public ArrayList QueryDrugList(string deptCode, string objectDeptCode,string drugBillClass) 
		{
			string strSelect ="";  //获得摆药信息的SELECT语句
			string strWhere  ="";  //获得某一科室摆药信息信息的WHERE条件语句

			//取SELECT语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugListByClass",ref strSelect) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugListByClass字段!";
				return null;
			}

			//取WHERE条件语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugListByClass.Where",ref strWhere) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugListByClass.Where字段!";
				return null;
			}

			//根据SQL语句取药品类数组并返回数组
			return this.myGetDrugList(strSelect + " " + strWhere);
		}

		/// <summary>
		/// 取药品基本信息列表，可能是一条或者多条药品记录
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>摆药单对象数组</returns>
		private ArrayList myGetDrugList(string SQLString) 
		{
			ArrayList al = new ArrayList();            //用于返回药品信息的数组
			Neusoft.HISFC.Models.Pharmacy.DrugControl DrugList;   //返回数组中的摆药信息类，每次在循环中创建实例。
			
			this.ExecQuery(SQLString);
            try
            {
                while (this.Reader.Read())
                {
                    DrugList = new Neusoft.HISFC.Models.Pharmacy.DrugControl();
                    #region "接口说明"

                    #endregion

                    try
                    {
                        DrugList.ID = this.Reader[0].ToString();


                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得摆药信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }

                    al.Add(DrugList);
                }

                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return al;
            }
            finally
            {
                this.Reader.Close();
            }

		}

		#endregion

		#region 门诊发药窗、摆药台维护 

        #region 基础增、删、改操作

        /// <summary>
		/// 获得Update或Insert门诊终端维护的传入参数数组
		/// </summary>
		/// <param name="drugTerminal">门诊终端实体</param>
		/// <returns>成功返回字符串数组、失败返回null</returns>
		protected string[] myGetParmDrugTerminal(DrugTerminal drugTerminal) 
		{
			//操作时间在sql内通过sysdate取得
			string[] strParm = {
								   drugTerminal.ID,							              //0 终端编号
								   drugTerminal.Name,							          //1 终端名称
								   drugTerminal.Dept.ID,								  //2 所属库房编号
								   drugTerminal.TerminalType.GetHashCode().ToString(),	  //3 终端类别 0 发药窗口 1 配药台
								   drugTerminal.ReplaceTerminal.ID,						  //4 替代终端号
								   NConvert.ToInt32(drugTerminal.IsClose).ToString(),	  //5 是否关闭 0 开启 1 关闭
								   NConvert.ToInt32(drugTerminal.IsAutoPrint).ToString(), //6 是否自动打印 0 否 1 自动打印
								   drugTerminal.RefreshInterval1.ToString(),			  //7 程序刷新时间间隔
								   drugTerminal.RefreshInterval2.ToString(),			  //8 打印/显示 时间间隔
								   drugTerminal.TerminalProperty.GetHashCode().ToString(),						  //9 终端性质 0 普通 1 专科 2 特殊
								   drugTerminal.AlertQty.ToString(),					  //10 警戒线
								   drugTerminal.ShowQty.ToString(),						  //11 显示人数
								   drugTerminal.SendWindow.ID,								  //12 发药窗口编号
								   this.Operator.ID,									  //13 操作员
								   drugTerminal.Memo,									  //14 备注
                                   ((int)drugTerminal.TerimalPrintType).ToString()
							   };
			return strParm;
		}
				
		/// <summary>
		/// 获取门诊终端信息
		/// </summary>
		/// <param name="StrSQL">查询的sql语句</param>
		/// <returns>成功返回门诊终端实体数组、失败返回null</returns>
		protected ArrayList myGetDrugTerminal(string StrSQL) 
		{
			ArrayList al = new ArrayList();
			if (this.ExecQuery(StrSQL) == -1) 
			{
				this.Err = "获取门诊终端信息时出错" + this.Err;
				return null;
			}
			try 
			{
				DrugTerminal info;
				while (this.Reader.Read()) 
				{
					info = new DrugTerminal();

					info.ID = this.Reader[0].ToString();							//0 终端编码
					info.Name = this.Reader[1].ToString();							//1 终端名称
					info.Dept.ID = this.Reader[2].ToString();								//2 所属库房编码
					info.TerminalType = (EnumTerminalType)NConvert.ToInt32(this.Reader[3].ToString());							//3 终端类别
					info.TerminalProperty = (EnumTerminalProperty)NConvert.ToInt32(this.Reader[4].ToString());						//4 终端性质
					info.ReplaceTerminal.ID = this.Reader[5].ToString();							//5 替代终端号
					info.IsClose = NConvert.ToBoolean(this.Reader[6].ToString());			//6 是否关闭
					info.IsAutoPrint = NConvert.ToBoolean(this.Reader[7].ToString());		//7 是否自动打印
					info.RefreshInterval1 = NConvert.ToDecimal(this.Reader[8].ToString());	//8 程序刷新时间间隔
					info.RefreshInterval2 = NConvert.ToDecimal(this.Reader[9].ToString());	//9 打印/显示 刷新时间间隔
					info.AlertQty = NConvert.ToInt32(this.Reader[10].ToString());			//10 警戒线
					info.ShowQty = NConvert.ToInt32(this.Reader[11].ToString());			//11 显示人数
					info.SendWindow.ID = this.Reader[12].ToString();							//12 发药窗口编码
					info.Oper.ID = this.Reader[13].ToString();								//13 操作员
					info.Oper.OperTime = NConvert.ToDateTime(this.Reader[14].ToString());		//14 操作时间
					info.Memo = this.Reader[15].ToString();									//15 备注
					info.SendQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16].ToString());
					info.DrugQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());
					info.Average = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18].ToString());
                    if (this.Reader.FieldCount > 18)
                    {
                        info.TerimalPrintType = (EnumClinicPrintType)NConvert.ToInt32(this.Reader[19]);
                    }

					al.Add(info);
				}
			}
			catch (Exception ex) 
			{
				this.Err = "获得门诊终端信息时，执行SQL语句出错" + ex.Message; 
				this.ErrCode = "-1";
				return null;
			}
			finally
			{
				this.Reader.Close();
			}
			return al;
		}
				
		/// <summary>
		/// 向门诊终端表内插入数据
		/// </summary>
		/// <param name="drugTerminal">门诊终端实体</param>
		/// <returns>成功返回1 失败返回-1</returns>
		public int InsertDrugTerminal(DrugTerminal drugTerminal) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugTerminal",ref strSql) == -1) return -1;
			try 
			{
				//设置门诊终端号
				drugTerminal.ID = this.GetSequence("Pharmacy.Constant.GetNewCompanyID");
				if (drugTerminal.SendWindow == null || drugTerminal.SendWindow.ID == "")
					drugTerminal.SendWindow.ID = drugTerminal.ID;
				string[] strParm = this.myGetParmDrugTerminal(drugTerminal);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.InsertDrugTerminal";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 更新门诊终端实体
		/// </summary>
		/// <param name="drugTerminal">门诊终端实体</param>
		/// <returns>成功返回1 失败返回－1 无更新返回0</returns>
		public int UpdateDrugTerminal(DrugTerminal drugTerminal) 
		{
			string strSql = "";
					
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugTerminal",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugTerminal (drugTerminal);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确！" + "Pharmacy.DrugStore.UpdateDrugTerminal";;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 删除一条门诊终端数据
		/// </summary>
		/// <param name="terminalCode">终端编号</param>
		/// <returns>无更新返回0 成功返回1 失败返回－1</returns>
		public int DeleteDrugTerminal(string terminalCode) 
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugTerminal",ref strSql)==-1) return -1;
						
			try 
			{  
				strSql = string.Format(strSql,terminalCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="传入参数不正确！Pharmacy.Item.DeleteDrugTerminal";
				return -1;
			}      			
			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 更新门诊终端实体信息，如无数据则插入
		/// </summary>
		/// <param name="drugTerminal">门诊终端实体</param>
		/// <returns>成功返回1，失败返回－1</returns>
		public int SetDrugTerminal(DrugTerminal drugTerminal) 
		{
			int parm;
			parm = this.UpdateDrugTerminal(drugTerminal);
			if (parm == 0)
				parm = this.InsertDrugTerminal(drugTerminal);
			return parm;
        }

        #endregion

        #region 内部使用

        /// <summary>
		/// 获得某科室某类型门诊终端列表
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="terminalType">终端类型 0 发药窗 1 配药台</param>
		/// <returns>成功返回DrugTerminal的ArrayList数组，失败返回null</returns>
		public ArrayList QueryDrugTerminalByDeptCode(string deptCode,string terminalType) 
		{
			string strSQL = "",strWhere = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal字段!";
				return null;
			}
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal.ByDeptCode",ref strWhere) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal.ByDeptCode字段!";
				return null;
			}
			try 
			{
				strSQL = strSQL + strWhere;
				strSQL = string.Format(strSQL, deptCode,terminalType);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.GetDrugTerminal.ByDeptCode";
				return null;
			}
			return this.myGetDrugTerminal(strSQL);
		}

        /// <summary>
        /// 查询终端处方状态数新处方调剂方式 by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="terminalType"></param>
        /// <returns></returns>
        public ArrayList QueryDrugTerminalByDeptCodeNew(string deptCode, string terminalType)
        {
            string strSQL = "", strWhere = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.Terminal.Adjust", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.Terminal.Adjust字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, terminalType);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "Pharmacy.DrugStore.Terminal.Adjust";
                return null;
            }
            return this.myGetDrugTerminal(strSQL);
        }

        /// <summary>
        /// 获得某科室某类型门诊终端列表 按所属库房排序
        /// </summary>
        /// <param name="terminalType">终端类型 0 发药窗 1 配药台</param>
        /// <returns>成功返回DrugTerminal的ArrayList数组，失败返回null</returns>
        public ArrayList QueryDrugTerminalByTerminalType(string terminalType)
        {
            string strSQL = "", strWhere = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.GetDrugTerminal字段!";
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal.ByTerminalType", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.GetDrugTerminal.ByTerminalType字段!";
                return null;
            }
            try
            {
                strSQL = strSQL + strWhere;
                strSQL = string.Format(strSQL, terminalType);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "Pharmacy.DrugStore.GetDrugTerminal.ByTerminalType";
                return null;
            }
            return this.myGetDrugTerminal(strSQL);
        }
				
		/// <summary>
		/// 根据终端编号、科室编码获得门诊终端信息
		/// </summary>
		/// <param name="terminalCode">终端编号</param>
		/// <returns>DrugTerminal、失败或没找到返回null</returns>
		public DrugTerminal GetDrugTerminalById(string terminalCode) 
		{
			string strSQL = "",strWhere = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal字段!";
				return null;
			}
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal.ById",ref strWhere) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal.ById字段!";
				return null;
			}
			try 
			{
				strSQL = strSQL + strWhere;
				strSQL = string.Format(strSQL,terminalCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.GetDrugTerminal.ById";
				return null;
			}
			ArrayList al = this.myGetDrugTerminal(strSQL);
			if (al == null) return null;
			
			if (al.Count == 0) return new DrugTerminal();

			return al[0] as DrugTerminal;
		}

		/// <summary>
		/// 根据发药窗口编码获取在用的一个配药台编码
		/// </summary>
		/// <param name="sendWindow">发药窗口编码</param>
		/// <returns>成功返回对应的配药台信息 失败返回null</returns>
		public DrugTerminal GetDrugTerminalBySendWindow(string sendWindow)
		{
			string strSQL = "",strWhere = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal字段!";
				return null;
			}
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal.BySendWindow",ref strWhere) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal.BySendWindow字段!";
				return null;
			}
			try 
			{
				strSQL = strSQL + strWhere;
				strSQL = string.Format(strSQL,sendWindow);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.GetDrugTerminal.BySendWindow";
				return null;
			}
			ArrayList al = this.myGetDrugTerminal(strSQL);
			if (al == null) return null;
			
			if (al.Count == 0) return new DrugTerminal();

			return al[0] as DrugTerminal;
		}
		
		/// <summary>
		/// 根据终端编码配药台信息 如果该配药台关闭 则循环查找替代终端信息
		/// </summary>
		/// <param name="terminalCode">配药终端编码</param>
		/// <returns>成功返回未关闭的配药终端 失败返回null 无满足条件的配药终端返回空实体</returns>
		public DrugTerminal GetDrugTerminal(string terminalCode)
		{
			Neusoft.HISFC.Models.Pharmacy.DrugTerminal info = null;
			info = this.GetDrugTerminalById(terminalCode);
			if (info == null)
				return null;
			if (info.ID != "")
			{
				while(info.IsClose)
				{
					if (info.ReplaceTerminal.ID == null || info.ReplaceTerminal.ID == "")
					{
						info = new DrugTerminal();
						break;
					}
					info = this.GetDrugTerminalById(info.ReplaceTerminal.ID);
					if (info == null || info.ID == "")
						break;
					//防止循环查找
					if (info.ID == terminalCode)
					{
						if (info.IsClose)
							info = new DrugTerminal();
						break;
					}
				}
			}
			return info;
		}
		
		/// <summary>
		/// 判断该终端是否为其他终端的替代终端
		/// </summary>
		/// <param name="terminalCode">终端编码</param>
		/// <returns>如为替代终端返回1 否则返回0 出错返回-1</returns>
		public int IsReplaceFlag(string terminalCode) 
		{
			string strSQL = "",strWhere = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal字段!";
				return -1;
			}
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal.IsReplaceFlag",ref strWhere) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal.IsReplaceFlag字段!";
				return -1;
			}
			try 
			{
				strSQL = strSQL + strWhere;
				strSQL = string.Format(strSQL,terminalCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.IsReplaceFlag";
				return -1;
			}
			ArrayList al = this.myGetDrugTerminal(strSQL);

			if (al == null) return -1;

			if (al.Count == 0)		//不是其他终端的替代终端
				return 0;
			else					//为其他终端的替代终端
				return 1;
		}
		
		/// <summary>
		/// 对处方调剂后 更新已发送、待配药、均分次数信息
		/// </summary>
		/// <param name="terminalCode">终端编码</param>
		/// <param name="sendNum">当日已发送处方品种数</param>
		/// <param name="drugNum">当日待配药处方品种数</param>
		/// <param name="averageNum">当日均分次数</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int UpdateTerminalAdjustInfo(string terminalCode,decimal sendNum,decimal drugNum,decimal averageNum)
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateTerminalAdjustInfo",ref strSql) == -1)
				return -1;
			try
			{
				strSql = string.Format(strSql,terminalCode,sendNum.ToString(),drugNum.ToString(),averageNum.ToString());
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 根据处方号 更新已发送、待配药信息 作废调剂信息时调用
		/// </summary>
		/// <param name="recipeNo">处方号</param>
		/// <param name="sendNum">当日已发送处方品种数</param>
		/// <param name="drugNum">当然待配药处方品种数</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int UpdateTerminalAdjustInfo(string recipeNo,decimal sendNum,decimal drugNum)
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateTerminalAdjustInfo.1",ref strSql) == -1)
				return -1;
			try
			{
				strSql = string.Format(strSql,recipeNo,sendNum.ToString(),drugNum.ToString());
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新一类终端 是否关闭 状态
		/// </summary>
		/// <param name="terminalType">终端类别 0 发药窗口 1 配药台</param>
		/// <param name="closeFlag">关闭状态 0 开放 1 关闭</param>
		/// <returns>成功返回受影响行数 失败返回null</returns>
		public int UpdateTerminalCloseFlag(string terminalType,string closeFlag)
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateTerminalCloseFlag",ref strSql) == -1)
				return -1;
			try
			{
				strSql = string.Format(strSql,terminalType,closeFlag);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

        /// <summary>
        /// 更新一类终端 是否关闭 状态
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="terminalType">终端类别</param>
        /// <param name="closeFlag">关闭状态</param>
        /// <returns>成功返回受影响行数 失败返回null</returns>
        public int UpdateTerminalCloseFlag(string deptCode, string terminalType, string closeFlag)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDeptTerminalCloseFlag", ref strSql) == -1)
                return -1;
            try
            {
                strSql = string.Format(strSql, deptCode, terminalType, closeFlag);
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

		/// <summary>
		/// 根据类别 寻找满足条件的配药终端
		/// </summary>
		/// <param name="deptCode">药房编码</param>
		/// <param name="type">类别 1 已发送的处方品种数最少的配药台 2 待配药的处方品种数最少的配药台</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public Neusoft.HISFC.Models.Pharmacy.DrugTerminal TerminalStatInfo(string deptCode,string type)
		{
            #region 使用新的处方调剂方式，原方式屏蔽 by Sunjh 2010-12-9

            //string strSQL = "",strWhere = "";    

            ////取SQL语句
            //if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminal",ref strSQL) == -1) 
            //{
            //    this.Err="没有找到Pharmacy.DrugStore.GetDrugTerminal字段!";
            //    return null;
            //}

            //if (this.Sql.GetSql("Pharmacy.DrugStore.TerminalStatInfo" + "." + type,ref strWhere) == -1)
            //{
            //    this.Err="没有找到Pharmacy.DrugStore.TerminalStatInfo" + "." + type + "字段!";
            //    return null;
            //}
            //try 
            //{
            //    strSQL = strSQL + strWhere;
            //    strSQL = string.Format(strSQL,deptCode);
            //}
            //catch(Exception ex) 
            //{
            //    this.ErrCode=ex.Message;
            //    this.Err=ex.Message + "Pharmacy.DrugStore.TerminalStatInfo";
            //    return null;
            //}
            //ArrayList al = this.myGetDrugTerminal(strSQL);
            //if (al == null) return null;

            //if (al.Count == 0) return new DrugTerminal();

            //return al[0] as DrugTerminal;

            #endregion

            #region 新处方调剂方式 by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}

            string strSQL = "";

            if (this.Sql.GetSql("Pharmacy.DrugStore.Terminal.Adjust" + "." + type, ref strSQL) == -1)
            {
                this.Err = "Pharmacy.DrugStore.Terminal.Adjust" + "." + type + "字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "Pharmacy.DrugStore.Terminal.Adjust.*";
                return null;
            }

            ArrayList al = this.myGetDrugTerminal(strSQL);

            if (al == null) return null;

            if (al.Count == 0) return new DrugTerminal();

            return al[0] as DrugTerminal;

            #endregion
        }

        /// <summary>
        /// 检查该终端是否仍存在未执行的数据
        /// </summary>
        /// <param name="terminalNO">终端编码</param>
        /// <returns></returns>
        public bool IsHaveRecipe(string terminalNO)
        {
            string strSQL = "", strWhere = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.IsHaveRecipe", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.IsHaveRecipe字段!";
                return false;
            }
            try
            {
                strSQL = string.Format(strSQL, terminalNO);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "Pharmacy.DrugStore.IsHaveRecipe";
                return false;
            }

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "检查该终端是否仍存在未执行的数据" + this.Err;
                return false;
            }

            if (this.Reader.Read())
            {
                this.Reader.Close();

                return true;
            }

            this.Reader.Close();

            return false;
        }

        #endregion

        #endregion

        #region 门诊特殊配药台维护 

        #region 基础增、删、改操作

        /// <summary>
		/// 获得update或insert传入的参数数组
		/// </summary>
		/// <param name="drugSPETerminal">门诊特殊配药台信息实体</param>
		/// <returns>成功返回字符串数组、失败返回null</returns>
		protected string[] myGetParmDrugSPETerminal(DrugSPETerminal drugSPETerminal) 
		{
			//操作时间通过sql内sysdate取得
			string[] strParm = {
								   drugSPETerminal.Terminal.ID,		//0 终端编号(配药台编号)
								   drugSPETerminal.ItemType,					//1 项目类别 1 药品 2 专科 3 结算类别 4 特定收费窗口
								   drugSPETerminal.Item.ID,					//2 项目编码
								   drugSPETerminal.Item.Name,					//3 项目名称
								   this.Operator.ID,							//4 操作员
								   drugSPETerminal.Memo,						//5 备注
			};
			return strParm;
		}
		
		/// <summary>
		/// 获得门诊特殊配药台信息
		/// </summary>
		/// <param name="StrSQL">执行的SQL语句</param>
		/// <returns>成功返回数组、失败返回null</returns>
		protected ArrayList myGetDrugSPETerminal(string StrSQL) 
		{
			ArrayList al = new ArrayList();
			if (this.ExecQuery(StrSQL) == -1) 
			{
				this.Err = "获取门诊特殊配药台信息时出错" + this.Err;
				return null;
			}
			try 
			{
				DrugSPETerminal info;
				while (this.Reader.Read()) 
				{
					info = new DrugSPETerminal();						

					info.Terminal.ID = this.Reader[0].ToString();		
					info.ItemType = this.Reader[1].ToString();									//1 项目类别
					info.Item.ID = this.Reader[2].ToString();									//2 项目编码
					info.Item.Name = this.Reader[3].ToString();									//3 项目名称
					info.Oper.ID = this.Reader[4].ToString();									//4 操作员
					info.Oper.OperTime = NConvert.ToDateTime(this.Reader[5].ToString());				//5 操作时间
					info.Memo = this.Reader[6].ToString();										//6 备注

					al.Add(info);
				}
			}
			catch (Exception ex) 
			{
				this.Err = "获得门诊特殊配药台信息时，执行SQL语句出错" + ex.Message; 
				this.ErrCode = "-1";
				return null;
			}
			finally
			{
				this.Reader.Close();
			}

			return al;
		}

		/// <summary>
		/// 向门诊特殊配药台插入数据
		/// </summary>
		/// <param name="drugSPETerminal">门诊特殊配药台实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int InsertDrugSPETerminal(DrugSPETerminal drugSPETerminal) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugSPETerminal",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugSPETerminal(drugSPETerminal);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.InsertDrugSPETerminal";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 更新门诊特殊配药台数据
		/// </summary>
		/// <param name="drugSPETerminal">门诊特殊配药台实体</param>
		/// <returns>成功返回1 失败返回－1 无更新返回0</returns>
		public int UpdateDrugSPETerminal(DrugSPETerminal drugSPETerminal) 
		{
			string strSql = "";
					
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugSPETerminal",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugSPETerminal (drugSPETerminal);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确！" + "Pharmacy.DrugStore.UpdateDrugSPETerminal";;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// 删除一条门诊特殊配药台信息
		/// </summary>
		/// <param name="speInfo">特殊配药台实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int DeleteDrugSPETerminal(Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal speInfo) 
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugSPETerminal",ref strSql)==-1) return -1;
						
			try 
			{  
				strSql = string.Format(strSql,speInfo.Terminal.ID,speInfo.ItemType,speInfo.Item.ID);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="传入参数不正确！Pharmacy.Item.DeleteDrugSPETerminal";
				return -1;
			}      			
			return this.ExecNoQuery(strSql);
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 删除指定药房、指定类型的特殊配药终端信息
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="itemType">终端类型</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int DeleteDrugSPETerminal(string deptCode, string itemType)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugSPETerminal.DeptItemType", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, itemType, deptCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "传入参数不正确！Pharmacy.Item.DeleteDrugSPETerminal.DeptItemType";
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
       
        /// <summary>
        /// 删除某类别特殊配药台信息
        /// </summary>
        /// <param name="itemType">项目类别 1 药品类别 2 专科类别 3 结算类别 4 收费窗口</param>
        /// <returns>成功返回删除数据数目 失败返回－1 无操作返回0</returns>
        public int DeleteDrugSPETerminal(string itemType)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugSPETerminal.ItemType", ref strSql) == -1)
                return -1;
            try
            {
                strSql = string.Format(strSql, itemType);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句传入参数出错!" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
		
		/// <summary>
		/// 某类型门诊特殊配药台列表
		/// </summary>
		/// <param name="itemType">类别 1 药品 2 专科 3 结算类别 4 特定收费窗口 "A"所有 </param>
		/// <returns>成功返回DrugSPETerminal的ArrayList数组，失败返回null</returns>
		public ArrayList QueryDrugSPETerminalByType(string itemType) 
		{
			string strSQL = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugSPETerminal.ByType",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugSPETerminal.ByType字段!";
				return null;
			}
			try 
			{
				strSQL = string.Format(strSQL,itemType);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.GetDrugSPETerminal.ByType";
				return null;
			}
			return this.myGetDrugSPETerminal(strSQL);
		}
				
		/// <summary>
		/// 某科室、某类型门诊特殊配药台列表 类型为"A"代表所有类别
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="itemType">类别  1 药品 2 专科 3 结算类别 4 特定收费窗口 "A"所有</param>
		/// <returns>成功返回DrugSPETerminal的ArrayList数组、失败返回null</returns>
		public ArrayList QueryDrugSPETerminalByDeptCode(string deptCode,string itemType) 
		{
			ArrayList al = this.QueryDrugSPETerminalByType(itemType);
			ArrayList myAl = new ArrayList();
			DrugSPETerminal info;
			for(int i = 0;i<al.Count;i++) 
			{
				info = al[i] as DrugSPETerminal;
				info.Terminal = this.GetDrugTerminalById(info.Terminal.ID);
				if (info.Terminal == null) return null;

				if (info.Terminal.Dept.ID == deptCode)
					myAl.Add(info);
			}
			return myAl;
		}
				
		/// <summary>
		/// 根据终端编号获得门诊特殊配药台信息
		/// </summary>
		/// <param name="terminalCode">终端编号</param>
		/// <returns>DrugSPETerminal、失败返回null</returns>
		public DrugSPETerminal GetDrugSPETerminalById(string terminalCode) 
		{
			string strSQL = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugSPETerminal.ById",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugSPETerminal.ById字段!";
				return null;
			}
			try 
			{
				strSQL = string.Format(strSQL,terminalCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.GetDrugSPETerminal.ById";
				return null;
			}
			ArrayList al = this.myGetDrugSPETerminal(strSQL);
			if (al == null) return null;

			if (al.Count == 0) return null;

			return al[0] as DrugSPETerminal;
		}
				
		/// <summary>
		/// 处方调剂过程中调用
		/// 根据特殊项目编码获取特殊配药终端信息 返回优先级别最高的配药终端
		/// sql语句使用in条件语句
		/// </summary>
		/// <param name="adjustType">调剂方式 0 平均 1 竞争</param>
		/// <param name="itemCode">特殊项目编码</param>
		/// <returns>成功返回特殊项目实体 失败返回null 无记录返回空实体</returns>
		public Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal GetDrugSPETerminalByItemCode(string adjustType,string deptCode,params string[] itemCode)
		{
			string strSQL = "";    
			//SQL语句内通过In实现
			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugSPETerminal.ByItemCode" + "." + adjustType,ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugSPETerminal.ByItemCode."+ adjustType + "字段!";
				return null;
			}
			try 
			{
				string strParm = "";
				foreach(string str in itemCode)
				{
					if (strParm == "")
						strParm = "'" + str + "'";
					else
						strParm = strParm + "," + "'" + str + "'"; 
				}
				strSQL = string.Format(strSQL,deptCode,strParm);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err = ex.Message + "Pharmacy.DrugStore.GetDrugSPETerminal.ByItemCode";
				return null;
			}
			ArrayList al = this.myGetDrugSPETerminal(strSQL);
			if (al == null) return null;
			if (al.Count == 0) return new Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal();
			return al[0] as DrugSPETerminal;
		}
		
        /// <summary>
		/// 更新门诊特殊配药台实体信息，如无数据则插入
		/// </summary>
		/// <param name="drugSPETerminal">门诊特殊配药台实体</param>
		/// <returns>成功返回1，失败返回－1</returns>
		public int SetDrugSPETerminal(DrugSPETerminal drugSPETerminal) 
		{
			int parm;
			parm = this.UpdateDrugSPETerminal(drugSPETerminal);
			if (parm == 0)
				parm = this.InsertDrugSPETerminal(drugSPETerminal);
			return parm;
        }

        #endregion

        #endregion

        #region 门诊配药台(发药窗口)模板维护 

        #region 基础增、删、改操作

        /// <summary>
		/// 获得Update或Insert传入参数数组
		/// </summary>
		/// <param name="obj">模版neuObject实体</param>
		/// <returns>成功返回字符串数组 失败返回null</returns>
		protected string[] myGetParmDrugOpenTerminal(Neusoft.FrameWork.Models.NeuObject obj) 
		{
			string[] strParm = {
								   obj.ID,						//模板编码
								   obj.Name,					//模板名称
								   obj.User01,					//配药台编码
								   obj.User02,					//是否关闭 0 开放 1 关闭
								   obj.User03,					//所属库房编码
								   obj.Memo					//备注
							   };
			return strParm;
		}
				
		/// <summary>
		/// 获得门诊模板信息
		/// </summary>
		/// <param name="StrSQL">查询sql字符串</param>
		/// <returns>成功返回neuobject数组 失败返回null</returns>
		protected ArrayList myGetDrugOpenTerminal(string StrSQL) 
		{
			ArrayList al = new ArrayList();
			if (this.ExecQuery(StrSQL) == -1) 
			{
				this.Err = "获取门诊模板信息时出错" + this.Err;
				return null;
			}
			try 
			{
				Neusoft.FrameWork.Models.NeuObject info;
				while (this.Reader.Read()) 
				{
					info = new Neusoft.FrameWork.Models.NeuObject();
					
					info.ID = this.Reader[1].ToString();		//模板编码
					info.Name = this.Reader[2].ToString();		//模板名称
					info.User01 = this.Reader[3].ToString();	//配药台编码
					info.User02 = this.Reader[4].ToString();	//是否关闭 0 开发 1 关闭
					info.User03 = this.Reader[0].ToString();	//所属库房编码
					info.Memo = this.Reader[5].ToString();		//备注
					
					al.Add(info);
				}
			}
			catch (Exception ex) 
			{
				this.Err = "获得门诊模板信息时，执行SQL语句出错" + ex.Message; 
				this.ErrCode = "-1";
				return null;
			}
			finally
			{
				this.Reader.Close();
			}
			return al;
		}
		
		/// <summary>
		/// 插入一条数据进入门诊模板
		/// </summary>
		/// <param name="info">neuobject实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int InsertDrugOpenTerminal(Neusoft.FrameWork.Models.NeuObject info) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugOpenTerminal",ref strSql) == -1) return -1;
			try 
			{
				//				if (info.ID == null || info.ID == "")				//获取模板编号
				//                    info.ID = this.GetSequence("Pharmacy.Constant.GetNewCompanyID");
				string[] strParm = this.myGetParmDrugOpenTerminal(info);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.InsertDrugOpenTerminal";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 根据库房编码 模板编号、终端编号 更新一条门诊配药台（发药窗）模板数据
		/// </summary>
		/// <param name="info">neuobject实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int UpdateDrugOpenTerminal(Neusoft.FrameWork.Models.NeuObject info) 
		{
			string strSql = "";
					
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugOpenTerminal",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugOpenTerminal (info);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确！" + "Pharmacy.DrugStore.UpdateDrugOpenTerminal";;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 根据模板编号、终端类型删除模板信息
		/// </summary>
		/// <param name="templateCode">模板编号</param>
		/// <param name="terminalType">终端类型 (0 发药窗口 1 配药台) "A"所有类型</param>
		/// <returns>成功返回删除条数 失败返回－1</returns>
		public int DeleteDrugOpenTerminalByType(string templateCode,string terminalType) 
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugOpenTerminalByType",ref strSql)==-1) return -1;
						
			try 
			{  
				strSql = string.Format(strSql,templateCode,terminalType);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="传入参数不正确！Pharmacy.DrugStore.DeleteDrugOpenTerminalByType";
				return -1;
			}      			
			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 根据模板编号删除所有该模板数据
		/// </summary>
		/// <param name="templateCode">模板编号</param>
		/// <returns>成功返回删除条数 失败返回－1</returns>
		public int DeleteDrugOpenTerminalByTemplateCode(string templateCode) 
		{
			return this.DeleteDrugOpenTerminalByType(templateCode,"A");
		}
				
		/// <summary>
		/// 根据模板编号、终端编号删除一条模板信息
		/// </summary>
		/// <param name="templateCode">模板编号</param>
		/// <param name="terminalCode">终端编号</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int DeleteDrugOpenTerminalById(string templateCode,string terminalCode) 
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugOpenTerminalById",ref strSql)==-1) return -1;
						
			try 
			{  
				strSql = string.Format(strSql,templateCode,terminalCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="传入参数不正确！Pharmacy.DrugStore.DeleteDrugOpenTerminalById";
				return -1;
			}      			
			return this.ExecNoQuery(strSql);
		}			
		
        /// <summary>
		/// 根据终端编号删除在模板表内所有信息
		/// </summary>
		/// <param name="terminalCode">终端编号</param>
		/// <returns>成功返回删除数、失败返回null</returns>
		public int DeleteDrugOpenTerminalById(string terminalCode) 
		{
			return this.DeleteDrugOpenTerminalById("AAAA",terminalCode);
        }

        #endregion

        #region 内部使用

        /// <summary>
		/// 根据科室编号获取该科室模板列表
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <returns>成功返回neuobject数组(ID 模板编号 Name 模板名称)、失败返回null</returns>
		public ArrayList QueryDrugOpenTerminalByDeptCode(string deptCode) 
		{
			string strSQL = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugOpenTerminalByDeptCode",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugOpenTerminalByDeptCode字段!";
				return null;
			}
			try 
			{
				strSQL = string.Format(strSQL,deptCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.GetDrugOpenTerminalByDeptCode";
				return null;
			}
			ArrayList al = new ArrayList();
			if (this.ExecQuery(strSQL) == -1) 
			{
				this.Err = "获取门诊模板信息时出错" + this.Err;
				return null;
			}
            try
            {
                Neusoft.FrameWork.Models.NeuObject info;
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[1].ToString();		//模板编码
                    info.Name = this.Reader[2].ToString();		//模板名称
                    info.User03 = this.Reader[0].ToString();	//所属库房编码

                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得门诊模板信息时，执行SQL语句出错" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
			return al;
		}
				
		/// <summary>
		/// 根据模板编号获取模板详细信息
		/// </summary>
		/// <param name="templateCode">模板编号</param>
		/// <returns>成功返回数组 失败返回null</returns>
		public ArrayList QueryDrugOpenTerminalById(string templateCode) 
		{
			string strSQL = "";    

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugOpenTerminalById",ref strSQL) == -1) 
			{
				this.Err="没有找到Pharmacy.DrugStore.GetDrugOpenTerminal.ById字段!";
				return null;
			}
			try 
			{
				strSQL = string.Format(strSQL,templateCode);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message + "Pharmacy.DrugStore.GetDrugOpenTerminalById";
				return null;
			}
			return this.myGetDrugOpenTerminal(strSQL);
		}
		
		/// <summary>
		/// 更新门诊模板信息、如无数据则插入一条新数据
		/// </summary>
		/// <param name="info">neuobject实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int SetDrugOpenTerminal(Neusoft.FrameWork.Models.NeuObject info) 
		{
			int parm;
			parm = this.UpdateDrugOpenTerminal(info);
			if (parm == 0)
				parm = this.InsertDrugOpenTerminal(info);
			return parm;
		}

        /// <summary>
        /// 执行选定模板
        /// </summary>
        /// <param name="templateCode">模板编号</param>
        /// <returns>成功返回更新数量 失败返回-1</returns>
        public int ExecOpenTerminal(string deptCode, string templateCode)
        {
            if (this.UpdateTerminalCloseFlag(deptCode, "1", "1") == -1)
            {
                this.Err = "执行关闭全部配药台失败" + this.Err;
                return -1;
            }

            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.ExecOpenTerminal", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.ExecOpenTerminal字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, templateCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "Pharmacy.DrugStore.ExecOpenTerminal";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #endregion

        #region 操作员默认配药台、发药窗口维护 

        #region 基础增、删、改操作

        /// <summary>
		/// 获得Update或Insert传入数组
		/// </summary>
		/// <param name="info">neuobject实体</param>
		/// <returns>成功返回string参数数组、失败返回null</returns>
		protected string[] myGetParmDrugTerminalOper(Neusoft.FrameWork.Models.NeuObject info) 
		{
			string[] strParm = {
								   info.ID,				//员工代码
								   info.Name,				//员工姓名
								   info.User01,			//终端(配药台、发药窗口)编码
								   this.Operator.ID		//操作员
							   };
			return strParm;
		}
				
		/// <summary>
		/// 获得门诊终端默认操作员信息
		/// </summary>
		/// <param name="strSQL">查询的SQl语句</param>
		/// <returns>成功返回neuobject动态数组 失败返回null</returns>
		protected ArrayList myGetDrugTerminalOper(string strSQL) 
		{
			ArrayList al = new ArrayList();
			if (this.ExecQuery(strSQL) == -1) 
			{
				this.Err = "获取门诊终端默认操作员信息" + this.Err;
				return null;
			}
			try 
			{
				Neusoft.FrameWork.Models.NeuObject info;
				while (this.Reader.Read()) 
				{
					info = new Neusoft.FrameWork.Models.NeuObject();
					
					info.ID = this.Reader[0].ToString();		//员工编码
					info.Name = this.Reader[1].ToString();		//员工名称
					info.Memo = this.Reader[2].ToString();		//配/发药终端类型 0 发药窗口 1 配药台
					info.User01 = this.Reader[3].ToString();	//终端编码
					info.User02 = this.Reader[4].ToString();	//终端名称					
					al.Add(info);
				}
			}
			catch (Exception ex) 
			{
				this.Err = "获取门诊终端默认操作员信息，执行SQL语句出错" + ex.Message; 
				this.ErrCode = "-1";
				return null;
			}
			finally
			{
				this.Reader.Close();
			}
			return al;
		}
		
		/// <summary>
		/// 向门诊操作员默认配药台表插入一条数据
		/// </summary>
		/// <param name="info">neuobject实体</param>
		/// <returns>成功返回1 失败返回null</returns>
		public int InsertDrugTerminalOper(Neusoft.FrameWork.Models.NeuObject info) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugTerminalOper",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugTerminalOper(info);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.InsertDrugTerminalOper";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
			
		/// <summary>
		/// 向门诊操作员默认配药台表更新一条数据
		/// </summary>
		/// <param name="info">neuobject实体</param>
		/// <returns>成功返回1 失败返回null</returns>
		public int UpdateDrugTerminalOper(Neusoft.FrameWork.Models.NeuObject info)
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugTerminalOper",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugTerminalOper(info);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.UpdateDrugTerminalOper";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 向门诊操作员默认配药台表删除一条数据
		/// </summary>
		/// <param name="emplCode">操作员员编码</param>
		/// <param name="terminalCode">终端编码</param>
		///<returns>成功返回删除条数、失败返回－1</returns>
		public int DeleteDrugTerminalOper(string emplCode,string terminalCode)
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.DeleteDrugTerminalOper",ref strSql) == -1) return -1;
			try 
			{
				strSql = string.Format(strSql, emplCode,terminalCode);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.DeleteDrugTerminalOper";
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
				
		/// <summary>
		/// 删除某操作员所有默认操作信息
		/// </summary>
		/// <param name="emplCode">操作员编码</param>
		/// <returns>成功返回删除条数 失败返回－1</returns>
		public int DelDrugTerminalOperByEmplId(string emplCode) 
		{
			return this.DeleteDrugTerminalOper(emplCode,"AAAA");
		}
				
		/// <summary>
		/// 删除某指定终端所有操作信息
		/// </summary>
		/// <param name="terminalCode">终端编码</param>
		/// <returns>成功返回删除条数 失败返回-1</returns>
		public int DelDrugTerminalOperByTerminalId(string terminalCode) 
		{
			return this.DeleteDrugTerminalOper("AAAA",terminalCode);
		}
				
		/// <summary>
		///  先进行数据删除在进行插入操作
		/// </summary>
		/// <param name="info">neuobject实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int SetDrugTerminalOper(Neusoft.FrameWork.Models.NeuObject info) 
		{
			int parm;
			parm = this.DeleteDrugTerminalOper(info.ID,info.User01);
			if (parm == -1) return parm;

			parm = this.InsertDrugTerminalOper(info);

			return parm;
        }

        #endregion

        #region 内部使用

        /// <summary>
		/// 检索本科室操作员默认操作终端列表信息
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <returns>成功返回neuobject数组 失败返回null</returns>
		public ArrayList QueryDrugTerminalOperList(string deptCode) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminalOperList",ref strSql) == -1) return null;
			try 
			{
				strSql = string.Format(strSql, deptCode);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.GetDrugTerminalOperList";
				this.ErrCode=ex.Message;
				return null;
			}
			return this.myGetDrugTerminalOper(strSql);
		}
				
		/// <summary>
		/// 获取指定操作员默认操作信息
		/// </summary>
		/// <param name="emplCode">操作员编码</param>
		/// <returns>成功返回门诊终端实体数组 失败返回null</returns>
		public ArrayList QueryDrugTerminalOperByEmplId(string emplCode) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.GerDrugTerminalOperByEmplId",ref strSql) == -1) return null;
			try 
			{
				strSql = string.Format(strSql, emplCode);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.GerDrugTerminalOperByEmplId";
				this.ErrCode=ex.Message;
				return null;
			}
			return this.myGetDrugTerminal(strSql);
		}
				
		/// <summary>
		/// 获取指定终端的默认操作员信息
		/// </summary>
		/// <param name="terminalCode">终端编码</param>
		/// <returns>成功返回neuobject数组(Id 人员编码 Name 人员姓名) 失败返回null</returns>
		public ArrayList QueryDrugTerminalOperByTerminalId(string terminalCode) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugTerminalOperByTerminalId",ref strSql) == -1) return null;
			try 
			{
				strSql = string.Format(strSql, terminalCode);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.GetDrugTerminalOperByTerminalId";
				this.ErrCode=ex.Message;
				return null;
			}
			return this.myGetDrugTerminalOper(strSql);
        }

        #endregion

        #endregion

        #region 门诊摆药处方(处方调剂)

        #region 基础增、删、改操作

        /// <summary>
        /// 获取Update或Insert数组传入参数数组 
        /// </summary>
        /// <param name="info">门诊摆药处方实体</param>
        /// <returns>成功返回string参数数组 失败返回null</returns>
        protected string[] myGetParmDrugRecipe(Neusoft.HISFC.Models.Pharmacy.DrugRecipe info)
        {
            string[] strParm = {
								   info.StockDept.ID,							//药房编码(发药药房)
								   info.RecipeNO,								//处方号
								   info.SystemType,								//出库申请分类
								   info.TransType,								//交易类型 1 正交易 2 反交易								
								   info.RecipeState,							//处方状态
								   info.ClinicNO,								//门诊号
								   info.CardNO,									//病历号
								   info.PatientName,							//患者姓名
								   info.Sex.ID.ToString(),						//性别
								   info.Age.ToString(),							//年龄
								   info.PayKind.ID,								//结算类别
								   info.PatientDept.ID,							//患者科室
								   info.RegTime.ToString(),						//挂号日期
								   info.Doct.ID,								//开发医生
								   info.DoctDept.ID,							//开方医生科室
								   info.DrugTerminal.ID,						//配药终端
								   info.SendTerminal.ID,						//发药终端
								   info.FeeOper.ID,								//收费人
								   info.FeeOper.OperTime.ToString(),			//收费时间
								   info.InvoiceNO,								//票据号
								   info.Cost.ToString(),						//处方金额
								   info.RecipeQty.ToString(),					//处方内药品品种数
								   info.DrugedQty.ToString(),					//已配药药品品种数
								   info.DrugedOper.ID,							//配药人
								   info.StockDept.ID,							//配药科室
								   info.DrugedOper.OperTime.ToString(),			//配药日期
								   info.SendOper.ID,							//发药人
								   info.SendOper.OperTime.ToString(),			//发药日期
								   info.StockDept.ID,							//发药科室

								   ((int)info.ValidState).ToString(),		    //有效状态 1 有效 0 无效 2 发药后退费
								   NConvert.ToInt32(info.IsModify).ToString(),	//退/改药状态 0 否 1 是

								   info.BackOper.ID,							//还药人
								   info.BackOper.OperTime.ToString(),			//还药时间
								   info.CancelOper.ID,							//取消人
								   info.CancelOper.OperTime.ToString(),			//取消时间
								   info.Memo,									//备注
                                   info.SumDays.ToString()						//处方内药品剂数合计
							   };
            return strParm;
        }

        /// <summary>
        /// 获得门诊摆药处方(处方调剂)信息
        /// </summary>
        /// <param name="strSQL">查询的SQl语句</param>
        /// <returns>成功返回数组 失败返回null</returns>
        protected ArrayList myGetDrugRecipeInfo(string strSQL)
        {
            ArrayList al = new ArrayList();
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获取门诊处方调剂信息出错" + this.Err;
                return null;
            }
            try
            {
                Neusoft.HISFC.Models.Pharmacy.DrugRecipe info;
                while (this.Reader.Read())
                {
                    #region 由结果集内读取数据
                    info = new DrugRecipe();

                    info.StockDept.ID = this.Reader[0].ToString();						//药房编码
                    info.RecipeNO = this.Reader[1].ToString();							//处方号
                    info.SystemType = this.Reader[2].ToString();						//出库申请分类
                    info.TransType = this.Reader[3].ToString();							//交易类型,1正交易，2反交易
                    info.RecipeState = this.Reader[4].ToString();						//处方状态: 0申请,1打印,2配药,3发药,4还药(当天未发的药品返回货价)
                    info.ClinicNO = this.Reader[5].ToString();						//门诊号
                    info.CardNO = this.Reader[6].ToString();							//病历卡号
                    info.PatientName = this.Reader[7].ToString();						//患者姓名
                    info.Sex.ID = this.Reader[8].ToString();							//性别
                    info.Age = NConvert.ToDateTime(this.Reader[9].ToString());			//年龄
                    info.PayKind.ID = this.Reader[10].ToString();						//结算类别代码
                    info.PatientDept.ID = this.Reader[11].ToString();					//患者科室编码
                    info.RegTime = NConvert.ToDateTime(this.Reader[12].ToString());		//挂号日期
                    info.Doct.ID = this.Reader[13].ToString();							//开方医师
                    info.DoctDept.ID = this.Reader[14].ToString();						//开方医师所在科室
                    info.DrugTerminal.ID = this.Reader[15].ToString();					//配药终端（打印台）
                    info.SendTerminal.ID = this.Reader[16].ToString();					//发药终端（发药窗口）
                    info.FeeOper.ID = this.Reader[17].ToString();							//收费人编码(申请人编码)
                    info.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[18].ToString());		//收费时间(申请时间)
                    info.InvoiceNO = this.Reader[19].ToString();						//票据号
                    info.Cost = NConvert.ToDecimal(this.Reader[20].ToString());			//处方金额（零售金额）
                    info.RecipeQty = NConvert.ToDecimal(this.Reader[21].ToString());	//处方中药品数量(中山一用品种数)
                    info.DrugedQty = NConvert.ToDecimal(this.Reader[22].ToString());	//已配药的药品数量(中山一用品种数)
                    info.DrugedOper.ID = this.Reader[23].ToString();						//配药人
                    info.StockDept.ID = this.Reader[24].ToString();					    //配药科室
                    info.DrugedOper.OperTime = NConvert.ToDateTime(this.Reader[25].ToString());	//配药日期
                    info.SendOper.ID = this.Reader[26].ToString();							//发药人
                    info.SendOper.OperTime = NConvert.ToDateTime(this.Reader[27].ToString());	//发药时间
                    info.StockDept.ID = this.Reader[28].ToString();						//发药科室

                    info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[29]));					//有效状态：0有效，1无效 2 发药后退费
                    info.IsModify = NConvert.ToBoolean(this.Reader[30].ToString());						//退药改药0否1是

                    info.BackOper.ID = this.Reader[31].ToString();							//-还药人
                    info.BackOper.OperTime = NConvert.ToDateTime(this.Reader[32].ToString());	//还药时间
                    info.CancelOper.ID = this.Reader[33].ToString();						//取消操作员
                    info.CancelOper.OperTime = NConvert.ToDateTime(this.Reader[34].ToString());	//取消日期
                    info.Memo = this.Reader[35].ToString();								//备注
                    info.SumDays = NConvert.ToDecimal(this.Reader[36].ToString());

                    al.Add(info);

                    #endregion
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取门诊处方调剂信息出错，执行SQL语句出错" + ex.Message;
                this.ErrCode = ex.ToString();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }
		
        /// <summary>
		/// 向门诊摆药处方(处方调剂)内加入一条数据
		/// </summary>
		/// <param name="info">门诊摆药处方(处方调剂)实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int InsertDrugRecipeInfo(Neusoft.HISFC.Models.Pharmacy.DrugRecipe info) 
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.InsertDrugRecipeInfo",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugRecipe(info);  //取参数列表
				strSql = string.Format(strSql, strParm);       //
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.InsertDrugRecipeInfo";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
		
        /// <summary>
		/// 向 门诊摆药处方(处方调剂) 更新数据
		/// </summary>
		/// <param name="info">门诊摆药处方(处方调剂)实体</param>
		/// <returns>成功返回1 失败返回－1 无更新返回0</returns>
		public int UpdateDrugRecipeInfo(Neusoft.HISFC.Models.Pharmacy.DrugRecipe info)
		{
			string strSql = "";

			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo",ref strSql) == -1) return -1;
			try 
			{
				string[] strParm = this.myGetParmDrugRecipe(info);  //取参数列表
				strSql = string.Format(strSql, strParm);       
			}
			catch(Exception ex) 
			{
				this.Err="参数不正确" + "Pharmacy.DrugStore.UpdateDrugRecipeInfo";
				this.ErrCode=ex.Message;
				return -1;
			}

			return this.ExecNoQuery(strSql);
		}
		
        /// <summary>
		///  先进行数据删除在进行插入操作
		/// </summary>
		/// <param name="info">门诊摆药处方(处方调剂)实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int SetDrugTerminalOper(Neusoft.HISFC.Models.Pharmacy.DrugRecipe info) 
		{
			int parm;
			parm = this.UpdateDrugRecipeInfo(info);
			if (parm == 0)
				parm = this.InsertDrugRecipeInfo(info);
			return parm;
        }

        #endregion

        #region 内部使用

        /// <summary>
		/// 更新记录有效/无效状态
		/// </summary>
		/// <param name="recipeNo">处方号</param>
		/// <param name="class3MenaingCode">出库申请类别 M1/M2/AA</param>
		/// <param name="validState">状态 0 有效 1 无效</param>
		/// <returns>成功返回1 失败返回－1 无操作返回0</returns>
		public int UpdateDrugRecipeValidState(string recipeNo,string class3MenaingCode,Neusoft.HISFC.Models.Base.EnumValidState validState)
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeValidState",ref strSql) == -1)
				return -1;
			try
			{
				strSql = string.Format(strSql,recipeNo,class3MenaingCode,((int)validState).ToString(),this.Operator.ID);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
        /// <summary>
		/// 更新记录状态
		/// </summary>
		/// <param name="deptCode">药房编码</param>
		/// <param name="recipeNo">处方号</param>
		/// <param name="class3MeaningCode">出库申请类别 M1/M2</param>
		/// <param name="oldState">原状态</param>
		/// <param name="newState">新状态</param>		
		/// <returns>成功返回1 失败返回-1 无操作返回0</returns>
		public int UpdateDrugRecipeState(string deptCode,string recipeNo,string class3MeaningCode,string oldState,string newState)
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeState",ref strSql) == -1)
				return -1;
			try
			{
				strSql = string.Format(strSql,deptCode,recipeNo,class3MeaningCode,oldState,newState);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
        /// <summary>
		/// 更新配药信息 根据本次已配药数量改变处方状态 不更新配药终端 
		/// </summary>
		/// <param name="drugDept">库房编码</param>
		/// <param name="recipeNo">处方号</param>
		/// <param name="class3MeaningCode">出库分类</param>
		/// <param name="drugOper">配药人</param>
		/// <param name="drugedDept">配药科室</param>
		/// <param name="drugedNum">本次已配药数量</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int UpdateDrugRecipeDrugedInfo(string drugDept,string recipeNo,string class3MeaningCode,string drugOper,string drugedDept,decimal drugedNum)
		{
			#region 原Sql语句
			/*
			 UPDATE PHA_STO_RECIPE T
				   SET T.Druged_Oper = '{3}',
					   T.DRUGED_DEPT = '{4}',
					   T.DRUGED_DATE = sysdate,
					   T.DRUGED_QTY = {5},
					   T.RECIPE_STATE = DECODE(T.RECIPE_QTY - T.DRUGED_QTY - 1,0,'2','1')
				WHERE  T.PARENT_CODE = '000010'
				  AND  T.CURRENT_CODE = '004004'
				  AND  T.RECIPE_STATE = '1'
				  AND  T.CLASS3_MEANING_CODE = '{2}'
				  AND  T.DRUG_DEPT_CODE = '{0}'
				  AND  T.RECIPE_NO = '{1}'
			现更改为 暂不考虑配药部分确认 因为存在未知问题 导致 状态更新不对
			  UPDATE PHA_STO_RECIPE T
				   SET T.Druged_Oper = '{3}',
					   T.DRUGED_DEPT = '{4}',
					   T.DRUGED_DATE = sysdate,
					   T.DRUGED_QTY = {5},
					   T.RECIPE_STATE = '2'
				WHERE  T.PARENT_CODE = '000010'
				  AND  T.CURRENT_CODE = '004004'
				  AND  T.RECIPE_STATE = '1'
				  AND  T.CLASS3_MEANING_CODE = '{2}'
				  AND  T.DRUG_DEPT_CODE = '{0}'
				  AND  T.RECIPE_NO = '{1}'
			*/
			#endregion
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo.Druged",ref strSql) == -1)
				return -1;
			try
			{
				string[] strParm = {	
									   drugDept,							//药房
									   recipeNo,							//处方号
									   class3MeaningCode,					//出库分类
									   drugOper,							//配药人
									   drugedDept,							//配药科室
									   drugedNum.ToString(),				//本次已配药数量
				};
				strSql = string.Format(strSql,strParm);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

        /// <summary>
        /// 更新配药信息 根据本次已配药数量改变处方状态 更新配药终端
        /// </summary>
        /// <param name="drugDept">库房编码</param>
        /// <param name="recipeNo">处方号</param>
        /// <param name="class3MeaningCode">出库分类</param>
        /// <param name="drugOper">配药人</param>
        /// <param name="drugedDept">配药科室</param>
        /// <param name="drugedNum">本次已配药数量</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int UpdateDrugRecipeDrugedInfo(string drugDept, string recipeNo, string class3MeaningCode, string drugOper, string drugedDept, string drugedTerminal,decimal drugedNum)
        {
            #region 原Sql语句
            /*
			 UPDATE PHA_STO_RECIPE T
				   SET T.Druged_Oper = '{3}',
					   T.DRUGED_DEPT = '{4}',
					   T.DRUGED_DATE = sysdate,
					   T.DRUGED_QTY = {5},
					   T.RECIPE_STATE = DECODE(T.RECIPE_QTY - T.DRUGED_QTY - 1,0,'2','1')
				WHERE  T.PARENT_CODE = '000010'
				  AND  T.CURRENT_CODE = '004004'
				  AND  T.RECIPE_STATE = '1'
				  AND  T.CLASS3_MEANING_CODE = '{2}'
				  AND  T.DRUG_DEPT_CODE = '{0}'
				  AND  T.RECIPE_NO = '{1}'
			现更改为 暂不考虑配药部分确认 因为存在未知问题 导致 状态更新不对
			  UPDATE PHA_STO_RECIPE T
				   SET T.Druged_Oper = '{3}',
					   T.DRUGED_DEPT = '{4}',
					   T.DRUGED_DATE = sysdate,
                       T.DRUGED_TERMINAL = '{5}',
					   T.DRUGED_QTY = {6},
					   T.RECIPE_STATE = '2',
                       T.EXT_FLAG = T.DRUGED_TERMINAL
				WHERE  T.PARENT_CODE = '000010'
				  AND  T.CURRENT_CODE = '004004'
				  AND  T.RECIPE_STATE = '1'
				  AND  T.CLASS3_MEANING_CODE = '{2}'
				  AND  T.DRUG_DEPT_CODE = '{0}'
				  AND  T.RECIPE_NO = '{1}'
			*/
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo.Druged.Other", ref strSql) == -1)
                return -1;
            try
            {
                string[] strParm = {	
									   drugDept,							//药房
									   recipeNo,							//处方号
									   class3MeaningCode,					//出库分类
									   drugOper,							//配药人
									   drugedDept,							//配药科室
                                       drugedTerminal,                      //配药终端
									   drugedNum.ToString(),				//本次已配药数量
				};
                strSql = string.Format(strSql, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
		

        /// <summary>
		/// 更新发药信息
		/// </summary>
		/// <param name="drugDept">库房编码</param>
		/// <param name="recipeNo">处方号</param>
		/// <param name="class3MeaningCode">出库分类</param>
		/// <param name="type">1 普通门诊 2 急诊发药</param>
		/// <param name="sendOper">发药人</param>
		/// <param name="sendDept">发药科室</param>
		/// <param name="sendTerminal">发药终端</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int UpdateDrugRecipeSendInfo(string drugDept,string recipeNo,string class3MeaningCode,string type,string sendOper,string sendDept,string sendTerminal)
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo.Send",ref strSql) == -1)
				return -1;
			try
			{
				if (type == "1")			//普通门诊
				{
					string[] strParm = {
										   drugDept,					//药房编码
										   recipeNo,					//处方号
										   class3MeaningCode,			//出库分类
										   "2",
										   sendOper,					//发药人
										   sendDept,					//发药科室
										   sendTerminal,				//发药终端
									   };
					strSql = string.Format(strSql,strParm);
				}
				else if (type == "2")	   //急诊发药
				{
					string[] strParm = {
										   drugDept,					//药房编码
										   recipeNo,					//处方号
										   class3MeaningCode,			//出库分类
										   "A",
										   sendOper,					//发药人
										   sendDept,					//发药科室
										   sendTerminal
									   };
					strSql = string.Format(strSql,strParm);
				}
				
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// 还药确认
		/// </summary>
		/// <param name="drugDept">库房编码</param>
		/// <param name="recipeNo">处方号</param>
		/// <param name="class3MeaningCode">出库分类</param>
		/// <param name="drugOper">还药人</param>
		/// <param name="oldState">如需判断并发 指定数据原状态 不需判断 传为"A"</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int UpdateDrugRecipeBackInfo(string drugDept,string recipeNo,string class3MeaningCode,string drugOper,string oldState)
		{
			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo.Back",ref strSql) == -1)
				return -1;
			try
			{
				string[] strParm = {	
									   drugDept,							//药房
									   recipeNo,							//处方号
									   class3MeaningCode,					//出库分类
									   drugOper,							//还药人
									   oldState,							//指定数据原状态
				};
				strSql = string.Format(strSql,strParm);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
        /// <summary>
		/// 对退改药更新处方状态、收费时间、退改药标记
		/// </summary>
		/// <param name="drugDept">发药药房</param>
		/// <param name="recipeNo">处方号</param>
		/// <param name="class3MeaningCode">权限码</param>
		/// <param name="newState">新处方状态</param>
		/// <param name="feeDate">收费时间</param>
		/// <param name="isModify">是否退改药</param>
		/// <returns>成功更新返回1 无记录返回0 出错返回0</returns>
		public int UpdateDrugRecipeModifyInfo(string drugDept,string recipeNo,string class3MeaningCode,string newState,DateTime feeDate,bool isModify)
		{
			string strSql = "";
			/*
			 *
					UPDATE PHA_STO_RECIPE T
					   SET T.Recipe_State = '{3}',
						   T.FEE_DATE = TO_DATE('{4}','YYYY-MM-DD HH24:MI:SS'),
				 T.MODIFY_FLAG = '{5}'
					WHERE  T.PARENT_CODE = '000010'
					  AND  T.CURRENT_CODE = '004004'
					  AND  T.DRUG_DEPT_CODE = '{0}'
					  AND  T.RECIPE_NO = '{1}'
			AND  T.CLASS3_MEANING_CODE = '{2}' 
			*/
			if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo.Modify",ref strSql) == -1)
				return -1;
			try
			{
				string[] strParm;
				if (isModify)
				{
					strParm = new string[]{	
											  drugDept,							//药房
											  recipeNo,							//处方号
											  class3MeaningCode,					//出库分类
											  newState,							//新处方状态
											  feeDate.ToString(),					//收费时间
											  "1"
										  };
				}
				else
				{
					strParm = new string[]{	
											  drugDept,							//药房
											  recipeNo,							//处方号
											  class3MeaningCode,					//出库分类
											  newState,							//新处方状态
											  feeDate.ToString(),					//收费时间
											  "0"
										  };
				}
				strSql = string.Format(strSql,strParm);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
        
        /// <summary>
        /// 对退改药更新处方状态、药品数量、处方金额、收费时间、退改药标记、处方号、有效性状态等
        /// </summary>
        /// <param name="modifyRecipeInfo">更改处方信息</param>
        /// <returns>成功更新返回1 无记录返回0 出错返回-1</returns>
        public int UpdateDrugRecipeModifyInfo(Neusoft.HISFC.Models.Pharmacy.DrugRecipe modifyRecipeInfo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo.Modify.Recipe", ref strSql) == -1)
                return -1;
            try
            {
                string[] strParm;
                strParm = new string[]{	
										  modifyRecipeInfo.StockDept.ID,							//药房
										  modifyRecipeInfo.RecipeNO,							//处方号
										  modifyRecipeInfo.SystemType,							//出库分类
										  modifyRecipeInfo.RecipeState,							//新处方状态
										  modifyRecipeInfo.RecipeQty.ToString(),				//处方内品种数量
										  modifyRecipeInfo.Cost.ToString(),						//处方金额
										  modifyRecipeInfo.FeeOper.OperTime.ToString(),					//收费时间
										  modifyRecipeInfo.InvoiceNO,							//发票号
										  ((int)modifyRecipeInfo.ValidState).ToString(),							//有效性
										  NConvert.ToInt32(modifyRecipeInfo.IsModify).ToString()//退改药 0 否 1 是
									  };
                strSql = string.Format(strSql, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        
        /// <summary>
        /// 根据旧发票号更新新发票号
        /// </summary>
        /// <param name="oldInvoiceNo">旧发票号</param>
        /// <param name="newInvoiceNo">新发票号</param>
        /// <returns>成功返回1 失败返回-1 无记录返回0</returns>
        public int UpdateDrugRecipeInvoiceN0(string oldInvoiceNo, string newInvoiceNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.UpdateDrugRecipeInfo.UpdateInvoiceNo", ref strSql) == -1)
                return -1;
            try
            {
                string[] strParm;
                strParm = new string[]{	
										 oldInvoiceNo,
										 newInvoiceNo
									  };
                strSql = string.Format(strSql, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

		/// <summary>
		/// 获取发送到指定药房、指定终端的处方列表
		/// </summary>
		/// <param name="deptCode">药房编码</param>
		/// <param name="terminalCode">终端编码</param>
		/// <param name="type">终端类别 0发药窗口/1配药台</param>
		/// <param name="state">处方状态</param>
		/// <returns>成功返回门诊摆药实体数组 失败返回null</returns>
		public ArrayList QueryList(string deptCode,string terminalCode,string type,string state)
		{
			string strSqlSelect = "",strSqlWhere = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Select",ref strSqlSelect) == -1)
			{
				return null;
			}
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Where1",ref strSqlWhere) == -1)
			{
				return null;
			}
			try
			{
				strSqlSelect = strSqlSelect + strSqlWhere;
				strSqlSelect = string.Format(strSqlSelect,deptCode,terminalCode,type,state);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return null;
			}
			ArrayList al = new ArrayList();
			al = this.myGetDrugRecipeInfo(strSqlSelect);
			return al;
		}
        
        /// <summary>
        /// 获取指定收费时间后发送到指定药房、指定终端的处方列表
        /// </summary>
        /// <param name="deptCode">药房编码</param>
        /// <param name="terminalCode">终端编码</param>
        /// <param name="type">终端类别  0发药窗口/1配药台/2还药/3直接发药</param>
        /// <param name="state">处方状态</param>
        /// <param name="queryDate">收费时间</param>
        /// <returns>成功返回门诊摆药实体数组 失败返回null</returns>
        public ArrayList QueryList(string deptCode, string terminalCode, string type, string state, DateTime queryDate)
        {
            string strSqlSelect = "", strSqlWhere = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Select", ref strSqlSelect) == -1)
            {
                return null;
            }
            if (type == "1")		//配药
            {
                if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Druged", ref strSqlWhere) == -1)
                {
                    return null;
                }
            }
            else if (type == "0")   //发药
            {
                if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Send", ref strSqlWhere) == -1)
                {
                    return null;
                }
            }
            else if (type == "3")   //直接发药
            {
                if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.DirectSend", ref strSqlWhere) == -1)
                {
                    return null;
                }
            }

            try
            {
                strSqlSelect = strSqlSelect + strSqlWhere;
                strSqlSelect = string.Format(strSqlSelect, deptCode, terminalCode, state, queryDate.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return null;
            }
            ArrayList al = new ArrayList();
            al = this.myGetDrugRecipeInfo(strSqlSelect);
            return al;
        }

        /// <summary>
        /// 获取某科室所有未发药患者列表
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回患者列表 失败返回null</returns>
        public ArrayList QueryUnSendList(string deptCode)
        {
            string strSqlSelect = "", strSqlWhere = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Select", ref strSqlSelect) == -1)
            {
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.UnSend", ref strSqlWhere) == -1)
            {
                return null;
            }
            try
            {
                strSqlSelect = strSqlSelect + strSqlWhere;
                strSqlSelect = string.Format(strSqlSelect, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return null;
            }

            ArrayList al = this.myGetDrugRecipeInfo(strSqlSelect);

            return al;
        }
		
        /// <summary>
		/// 根据处方号获取处方调剂信息
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="class3MeaningCode">出库分类</param>
		/// <param name="recipeNo">处方号</param>
		/// <param name="state">处方状态</param>
		/// <returns>成功返回DrugRecipe实体 失败返回null 未找到返回空实体</returns>
		public Neusoft.HISFC.Models.Pharmacy.DrugRecipe GetDrugRecipe(string deptCode,string class3MeaningCode,string recipeNo,string state)
		{
			string strSqlSelect = "",strSqlWhere = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Select",ref strSqlSelect) == -1)
			{
				return null;
			}
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Where3",ref strSqlWhere) == -1)
			{
				return null;
			}
			try
			{
				strSqlSelect = strSqlSelect + strSqlWhere;
				strSqlSelect = string.Format(strSqlSelect,deptCode,class3MeaningCode,recipeNo,state);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return null;
			}
			ArrayList al = new ArrayList();
			al = this.myGetDrugRecipeInfo(strSqlSelect);
			if (al == null)
				return null;
			if (al.Count == 0)
				return new Neusoft.HISFC.Models.Pharmacy.DrugRecipe();
			return al[0] as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
		}

        /// <summary>
        /// 根据处方号获取处方调剂信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="recipeNO">处方号</param>
        /// <returns>成功返回DrugRecipe实体,失败返回null 未找到返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.DrugRecipe GetDrugRecipe(string deptCode, string recipeNO)
        {
            string strSqlSelect = "", strSqlWhere = "";
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Select", ref strSqlSelect) == -1)
            {
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Where.Recipe", ref strSqlWhere) == -1)
            {
                return null;
            }
            try
            {
                strSqlSelect = strSqlSelect + strSqlWhere;
                strSqlSelect = string.Format(strSqlSelect, deptCode, recipeNO);
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return null;
            }
            ArrayList al = new ArrayList();
            al = this.myGetDrugRecipeInfo(strSqlSelect);
            if (al == null)
                return null;
            if (al.Count == 0)
                return new Neusoft.HISFC.Models.Pharmacy.DrugRecipe();
            return al[0] as Neusoft.HISFC.Models.Pharmacy.DrugRecipe;
        }

		/// <summary>
		/// 根据单据号 获取 处方调剂信息
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="class3MeaningCode">出库分类 M1 门诊出库 M2  门诊退库</param>
		/// <param name="recipeState">处方状态</param>
		/// <param name="billType">单据类型 0 处方号 1 发票号 2 病历卡号</param>
		/// <param name="billNo">单据号</param>
		/// <returns>成功返回DrugRecipe数组 失败返回null 未找到返回空数组</returns>
		public ArrayList QueryDrugRecipe(string deptCode,string class3MeaningCode,string recipeState,int billType,string billNo)
		{
			string strSqlSelect = "",strSqlWhere = "";
			string strWhereIndex = "";				//SQL语句Where条件 索引
			if (this.Sql.GetSql("Pharmacy.DrugStore.GetList.Select",ref strSqlSelect) == -1)
			{
				return null;
			}
			switch (billType)
			{
				case 0:			//处方号
					strWhereIndex = "Pharmacy.DrugStore.GetList.Where3";
					break;
				case 1:			//发票号
					strWhereIndex = "Pharmacy.DrugStore.GetList.Where4";
					break;
				default:		//病历卡号
					strWhereIndex = "Pharmacy.DrugStore.GetList.Where5";
					break;
			}
			if (this.Sql.GetSql(strWhereIndex,ref strSqlWhere) == -1)
			{
				return null;
			}
			try
			{
				strSqlSelect = strSqlSelect + strSqlWhere;
				strSqlSelect = string.Format(strSqlSelect,deptCode,class3MeaningCode,billNo,recipeState);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return null;
			}
			ArrayList al = new ArrayList();
			al = this.myGetDrugRecipeInfo(strSqlSelect);
			if (al == null)
				return null;
			return al;
		}
		
        /// <summary>
		/// 判断患者是否存在未取药的处方 如存在 则返回上一张处方的发药窗口号
		/// 如不存在未取药的处方 则返回发药窗口号为空
		/// 如上一张处方的发药窗口已关闭 则返回空
		/// </summary>
		/// <param name="deptCode">取药药房</param>
		/// <param name="clinicNo">门诊流水号</param>
		/// <param name="sendWindow">发药窗口号 为空表示不存在未取药处方</param>
		/// <returns>1 返回成功 －1 出错 </returns>
		public int JudegPatientRecipe(string deptCode,string clinicNo,out string sendWindow)
		{
			sendWindow = "";

			string strSql = "";
			if (this.Sql.GetSql("Pharmacy.DrugStore.JudegPatientRecipe",ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,deptCode,clinicNo);
			}
			catch (Exception ex)
			{
				this.Err = "参数不正确" + ex.Message;
				return -1;
			}
			if (this.ExecQuery(strSql) == -1) 
			{
				this.Err = "获取未取药处方信息出错" + this.Err;
				return -1;
			}
			try
			{
				while (this.Reader.Read())
				{
					sendWindow = this.Reader[0].ToString();
				}
			}
			catch (Exception ex)
			{
				this.Err = "" + ex.Message;
				return -1;
			}
			finally
			{
				this.Reader.Close();
			}
			return 1;
        }

        #endregion

        #endregion

        #region 处方调剂

        /// <summary>
        /// 获取调剂方式 
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回处方调剂方式 0 平均 1 竞争</returns>
        public string GetAdjustType(string deptCode)
        {
            Neusoft.FrameWork.Management.ExtendParam extManager = new Neusoft.FrameWork.Management.ExtendParam();
            extManager.SetTrans(this.Trans);

            string adjustType = "0";

            try
            {
                Neusoft.HISFC.Models.Base.ExtendInfo deptExt = extManager.GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT,"TerminalAdjust", deptCode);
                if (deptExt == null)
                {
                    this.Err = "获取科室扩展属性内配药调剂参数失败！";

                    adjustType = "0";
                }

                if (deptExt.StringProperty == "1")		//竞争
                {
                    adjustType = "1";
                }
                else									//平均
                {
                    adjustType = "0";
                }
            }
            catch { }

            return adjustType;
        }

        /// <summary>
		/// 收费过程中调用 插入处方调剂表
		/// 返回处方调剂信息 发药药房+发药窗口
		/// </summary>
		/// <param name="patient">患者信息实体</param>
		/// <param name="feeAl">费用信息数组</param>
		/// <param name="feeWindow">收费窗口号</param>
		/// <param name="drugSendInfo">处方调剂信息 发药药房+发药窗口</param>        
		/// <returns>成功返回1 失败返回-1 </returns>
		public int DrugRecipe(Neusoft.HISFC.Models.Registration.Register patient,ArrayList feeAl,string feeWindow,out string drugSendInfo)
        {
           return DrugRecipe(patient,feeAl,feeWindow,null,out drugSendInfo);
        }
      
        /// <summary>
		/// 收费过程中调用 插入处方调剂表
		/// 返回处方调剂信息 发药药房+发药窗口
		/// </summary>
		/// <param name="patient">患者信息实体</param>
		/// <param name="feeAl">费用信息数组</param>
		/// <param name="feeWindow">收费窗口号</param>
        /// <param name="hsDeptAddress">药房位置信息</param>
		/// <param name="drugSendInfo">处方调剂信息 发药药房+发药窗口</param>        
		/// <returns>成功返回1 失败返回-1 </returns>
		public int DrugRecipe(Neusoft.HISFC.Models.Registration.Register patient,ArrayList feeAl,string feeWindow,System.Collections.Hashtable hsDeptAddress,out string drugSendInfo)
		{
            if (hsDeptAddress == null)
            {
                hsDeptAddress = new Hashtable();

                #region 以下代码以后挪到组合业务层

                //Neusoft.HISFC.BizLogic.Manager.Constant consMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
                ////consMgr.SetTrans(this.Transaction);
                //ArrayList alDeptAddress = consMgr.GetList("DeptAddress");
                //if (alDeptAddress != null)
                //{
                //    DrugStore.hsDeptAddress = new Hashtable();
                //    foreach (Neusoft.HISFC.Models.Base.Const consInfo in alDeptAddress)
                //    {
                //        hsDeptAddress.Add(consInfo.ID, consInfo.Name);
                //    }
                //}

                #endregion
            }

            string adjustType = "0";            //0 平均调剂 1 竞争调剂

			drugSendInfo = "";

			#region 对费用信息数组按照发药药房进行分组
			ArrayList feeTempAl = new ArrayList();			//二维数组 存储分组后的费用信息
			ArrayList feeNowTemp = new ArrayList(); 		//二维数组 存储上一次的费用

            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeTemp;
			string privDrugDept = "";
			try
			{
				FeeSort feeSortInterface = new FeeSort();
				feeAl.Sort(feeSortInterface);
			}
			catch (Exception ex)
			{
				this.Err = "处理患者费用信息排序时发生错误" + ex.Message;
				return -1;
			}
			for(int i = 0;i < feeAl.Count;i++)
			{
                feeTemp = feeAl[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
				if (feeTemp == null) continue;
				if (feeTemp.ExecOper.Dept.ID == privDrugDept)
				{
					feeNowTemp.Add(feeTemp);
				}
				else
				{
					feeNowTemp = new ArrayList();
					feeNowTemp.Add(feeTemp);
					feeTempAl.Add(feeNowTemp);
					privDrugDept = feeTemp.ExecOper.Dept.ID;
				}
			}	
			#endregion
	
			Neusoft.HISFC.Models.Pharmacy.DrugRecipe info;		//处方调剂信息实体
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeInfo = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
			foreach(ArrayList temp in feeTempAl)
			{
				if (temp.Count == 0) continue;
				info = new DrugRecipe();
				info.Cost = 0;
                info.SumDays = 0;

				string recipeNo = "";
				ArrayList alTemp = new ArrayList();
                Hashtable comboHs = new Hashtable();

				try
				{
					RecipeSort feeRecipeSort = new RecipeSort();
					temp.Sort(feeRecipeSort);
				}
				catch (Exception ex)
				{
					this.Err = "处理患者费用信息处方排序时发生错误" + ex.Message;
					return -1;
				}

                //设置临时变量处理分方问题 避免设置了特殊药品的情况下，如果特殊药品处于第二个处方 那么会出现
                //一张医生处方分到了不同的配药台。同时对于处方调剂参数的更新也会出现只更新了一张处方的量
                DrugTerminal drugTerminalTemp = new DrugTerminal();
                DrugTerminal sendTerminalTemp = new DrugTerminal();
                bool isArrangeDrugTerminal = false;

				for(int i = 0;i < temp.Count;i++)
				{
                    feeInfo = temp[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
					if (feeInfo == null)
					{
						this.Err = "根据传入的费用实体数组 获取费用实体实例时发生类型转换错误";
						return -1;
					}
					if (recipeNo != "" && recipeNo != feeInfo.RecipeNO)
					{
						if (alTemp.Count > 0)
						{
                            //{24CF1B4D-1422-45da-B6E9-7075978ECF5A}  同一组费用可能存在不同的发票号
                            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList tempFeeInfo = alTemp[0] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;

							#region 根据费用信息实体对处方调剂信息实体进行赋值
							info.StockDept.ID = feeInfo.ExecOper.Dept.ID;						//药房编码(发药药房)
							info.RecipeNO = recipeNo;									        //处方号
							info.SystemType = "M1";												//出库申请分类
							info.TransType = "1";												//交易类型 1 正交易 2 反交易								
							info.RecipeState = "0";												//处方状态
							info.ClinicNO = feeInfo.Patient.ID;								            //门诊号
							info.CardNO = feeInfo.Patient.PID.CardNO;							//病历号
							info.PatientName = patient.Name;									//患者姓名
							info.Sex = patient.Sex;												//性别
							info.Age = patient.Birthday;										//年龄
							info.PayKind.ID = patient.Pact.PayKind.ID;								//结算类别
							//患者科室 ＝ 挂号科室
							info.PatientDept = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.Templet.Dept;								//患者科室
							info.RegTime = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.SeeDate;										//挂号日期
                            info.Doct = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.Templet.Doct;									//开方医生
                            info.DoctDept = feeInfo.RecipeOper.Dept;							//开方医生科室

                            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                            if (patient.IsAccount)
                            {
                                info.FeeOper.OperTime = feeInfo.ChargeOper.OperTime;
                                info.FeeOper.ID = feeInfo.ChargeOper.ID;
                            }
                            else
                            {
                                info.FeeOper.OperTime = feeInfo.FeeOper.OperTime;					//收费时间
                                info.FeeOper.ID = feeInfo.FeeOper.ID;
                            }

                            //{24CF1B4D-1422-45da-B6E9-7075978ECF5A}  同一组费用可能存在不同的发票号
                            info.InvoiceNO = tempFeeInfo.Invoice.ID;									//票据号
							info.RecipeQty = alTemp.Count;										//处方内药品品种数
							info.DrugedQty = 0;													//已配药药品品种数
							info.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;	//有效状态 1 有效 0 无效 2 发药后退费
							info.IsModify = false;												//退/改药状态 0 否 1 是
							//info.Memo = feeInfo.Memo;											//备注
							#endregion

                            #region 获取处方调剂方式

                            adjustType = this.GetAdjustType(info.StockDept.ID);

                            #endregion

							#region 根据处方调剂规则获取配药台、发药窗口编码

                            //DrugTerminal drugTerminalTemp = new DrugTerminal(),sendTerminalTemp = new DrugTerminal();
                            if (isArrangeDrugTerminal == false)     //对本数组第一次进行调剂
                            {
                                if (this.RecipeAdjust(patient, alTemp, feeWindow, adjustType, out drugTerminalTemp, out sendTerminalTemp) == -1)
                                    return -1;
                                isArrangeDrugTerminal = true;
                            }
                            else
                            {
                                int averageNum = 0;
                                if (adjustType == "1")
                                {
                                    averageNum = 1;
                                }

                                //屏蔽更新语句使用新处方调剂方式by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}
                                ////更新调剂参数 在调剂函数外更新避免出现多更新
                                //if (this.UpdateTerminalAdjustInfo(drugTerminalTemp.ID, alTemp.Count, alTemp.Count, averageNum) == -1)
                                //{
                                //    this.Err = "更新配药台已发送、待配药数量时出错" + this.Err;
                                //    return -1;
                                //}
                            }

							info.DrugTerminal.ID = drugTerminalTemp.ID;
							info.SendTerminal.ID = sendTerminalTemp.ID;
                            if (drugTerminalTemp.Memo != null)
                            {
                                info.Memo = drugTerminalTemp.Memo;
                            }

							if (info.DrugTerminal.ID == "" || info.SendTerminal.ID == "")
							{
								this.Err = "处方调剂执行错误 未获取正确的配药台/发药窗口编码";
								return -1;
							}
                            if (drugSendInfo == "")
                            {
                                if (feeInfo.UndrugComb.User03 == null || feeInfo.UndrugComb.User03 == "")
                                {
                                    if (hsDeptAddress.ContainsKey(feeInfo.ExecOper.Dept.ID))
                                        drugSendInfo = drugSendInfo + hsDeptAddress[feeInfo.ExecOper.Dept.ID].ToString() + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;
                                    else
                                        drugSendInfo = drugSendInfo + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;	//取药药房 + 发药窗口
                                }
                            }
                            else
                            {
                                if (feeInfo.UndrugComb.User03 == null || feeInfo.UndrugComb.User03 == "")
                                {
                                    if (hsDeptAddress.ContainsKey(feeInfo.ExecOper.Dept.ID))
                                        drugSendInfo = drugSendInfo + "|" + hsDeptAddress[feeInfo.ExecOper.Dept.ID].ToString() + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;
                                    else
                                        drugSendInfo = drugSendInfo + "|" + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;	//取药药房 + 发药窗口
                                }
                            }
							#endregion

							if (this.InsertDrugRecipeInfo(info) == -1)
							{
								if (this.DBErrCode != 1)
								{									
									return -1;
								}
								else
								{
									#region 对退/改药情况 对处方调剂头表进行状态更新
                                    int parm = this.UpdateDrugRecipeModifyInfo(info);
									if (parm == -1)
									{
										return parm;
									}
									else if (parm == 0)
									{
										this.Err = "未正确找到退改药需要更新的处方调剂头表数据 可能数据已发生变化 ";
										return -1;
									}
									#endregion
								}
							}
						}

						recipeNo = feeInfo.RecipeNO;

						alTemp = new ArrayList();
                        comboHs = new Hashtable();
						alTemp.Add(feeInfo);
                        comboHs.Add(feeInfo.Order.Combo, feeInfo.Days);
						info.Cost = 0;
						info.Cost = info.Cost + feeInfo.FT.TotCost;
                        info.SumDays = 0;
                        info.SumDays = info.SumDays + feeInfo.Days;
					}
					else
					{
						recipeNo = feeInfo.RecipeNO;
						alTemp.Add(feeInfo);

                        if (!comboHs.ContainsKey(feeInfo.Order.Combo))
                        {
                            comboHs.Add(feeInfo.Order.Combo, feeInfo.Days);
                            info.SumDays = info.SumDays + feeInfo.Days;
                        }

						info.Cost = info.Cost + feeInfo.FT.TotCost;
					}
					
				}		
				#region 保存最后一组
				if (alTemp != null && alTemp.Count > 0)
				{
                    //{24CF1B4D-1422-45da-B6E9-7075978ECF5A}  同一组费用可能存在不同的发票号
                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList tempFeeInfo = alTemp[0] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;

					#region 根据费用信息实体对处方调剂信息实体进行赋值
					info.StockDept.ID = feeInfo.ExecOper.Dept.ID;							//药房编码(发药药房)
					info.RecipeNO = recipeNo;									            //处方号
					info.SystemType = "M1";												    //出库申请分类
					info.TransType = "1";												    //交易类型 1 正交易 2 反交易								
					info.RecipeState = "0";												    //处方状态
					info.ClinicNO = feeInfo.Patient.ID;								        //门诊号
					info.CardNO = feeInfo.Patient.PID.CardNO;								//病历号
					info.PatientName = patient.Name;									    //患者姓名
					info.Sex = patient.Sex;												    //性别
					info.Age = patient.Birthday;										    //年龄
					info.PayKind.ID = patient.Pact.PayKind.ID;								//结算类别
					//患者科室 ＝ 挂号科室
					info.PatientDept = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.Templet.Dept;								//患者科室
					info.RegTime = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.SeeDate;										//挂号日期
                    info.Doct = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.Templet.Doct;										//开方医生
					info.DoctDept = feeInfo.RecipeOper.Dept;								//开方医生科室
                    //info.FeeOper.ID = feeInfo.FeeOper.ID;								    //收费人
                    //info.FeeOper.OperTime = feeInfo.FeeOper.OperTime;						//收费时间

                    //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                    if (patient.IsAccount)
                    {
                        info.FeeOper.OperTime = feeInfo.ChargeOper.OperTime;
                        info.FeeOper.ID = feeInfo.ChargeOper.ID;
                    }
                    else
                    {
                        info.FeeOper.OperTime = feeInfo.FeeOper.OperTime;					//收费时间
                        info.FeeOper.ID = feeInfo.FeeOper.ID;
                    }

                    //{24CF1B4D-1422-45da-B6E9-7075978ECF5A}  同一组费用可能存在不同的发票号
                    info.InvoiceNO = tempFeeInfo.Invoice.ID;									//票据号
					info.RecipeQty = alTemp.Count;										    //处方内药品品种数
					info.DrugedQty = 0;													    //已配药药品品种数

					info.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;												

					info.IsModify = false;												    //退/改药状态 0 否 1 是
					//info.Memo = feeInfo.Memo;											    //备注
					#endregion

                    #region 获取处方调剂方式

                    adjustType = this.GetAdjustType(info.StockDept.ID);

                    #endregion

					#region 根据处方调剂规则获取配药台、发药窗口编码

                    //DrugTerminal drugTerminalTemp = new DrugTerminal(),sendTerminalTemp = new DrugTerminal();
                    if (isArrangeDrugTerminal == false)
                    {
                        if (this.RecipeAdjust(patient, alTemp, feeWindow, adjustType, out drugTerminalTemp, out sendTerminalTemp) == -1)
                            return -1;
                        isArrangeDrugTerminal = true;
                    }
                    else
                    {
                        int averageNum = 0;
                        if (adjustType == "1")
                        {
                            averageNum = 1;
                        }

                        //屏蔽更新语句使用新处方调剂方式by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}
                        ////更新调剂参数
                        //if (this.UpdateTerminalAdjustInfo(drugTerminalTemp.ID, alTemp.Count, alTemp.Count, averageNum) == -1)
                        //{
                        //    this.Err = "更新配药台已发送、待配药数量时出错" + this.Err;
                        //    return -1;
                        //}
                    }

					info.DrugTerminal.ID = drugTerminalTemp.ID;
					info.SendTerminal.ID = sendTerminalTemp.ID;
                    if (drugTerminalTemp.Memo != null)
                    {
                        info.Memo = drugTerminalTemp.Memo;
                    }
					if (info.DrugTerminal.ID == "" || info.SendTerminal.ID == "")
					{
						this.Err = "处方调剂执行错误 未获取正确的配药台/发药窗口编码";
						return -1;
					}
                    if (drugSendInfo == "")
                    {
                        if (feeInfo.UndrugComb.User03 == null || feeInfo.UndrugComb.User03 == "")
                        {
                            if (hsDeptAddress.ContainsKey(feeInfo.ExecOper.Dept.ID))
                                drugSendInfo = drugSendInfo + hsDeptAddress[feeInfo.ExecOper.Dept.ID].ToString() + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;
                            else
                                drugSendInfo = drugSendInfo + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;	//取药药房 + 发药窗口
                        }
                    }
                    else
                    {
                        if (feeInfo.UndrugComb.User03 == null || feeInfo.UndrugComb.User03 == "")
                        {
                            if (hsDeptAddress.ContainsKey(feeInfo.ExecOper.Dept.ID))
                                drugSendInfo = drugSendInfo + "|" + hsDeptAddress[feeInfo.ExecOper.Dept.ID].ToString() + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;
                            else
                                drugSendInfo = drugSendInfo + "|" + feeInfo.ExecOper.Dept.Name + sendTerminalTemp.Name;	//取药药房 + 发药窗口
                        }
                    }
					#endregion

					if (this.InsertDrugRecipeInfo(info) == -1)
					{
						if (this.DBErrCode != 1)
						{
							return -1;
						}
						else
						{
							#region 对退/改药情况 对处方调剂头表进行状态更新
                            int parm = this.UpdateDrugRecipeModifyInfo(info);
							if (parm == -1)
							{
								return parm;
							}
							else if (parm == 0)
							{
								this.Err = "未正确找到退改药需要更新的处方调剂头表数据 可能数据已发生变化 ";
								return -1;
							}
							#endregion
						}
					}
				}
				#endregion
			}

			return 1;
		}		
	
        /// <summary>
		/// 根据所传入的费用信息数组 根据调剂规则判断应发送的配药台、发药窗编号 
		/// 并返回 调剂后的发药窗口号、配药终端号
		/// </summary>
		/// <param name="patient">患者信息实体</param>
		/// <param name="feeAl">费用信息数组</param>
		/// <param name="feeWindow">收费窗口编码</param>
		/// <param name="adjustType">处方调剂类别 0 平均调剂 1 竞争调剂</param>
		/// <param name="drugTerminalObject">配药终端实体</param>
		/// <param name="sendTerminalObject">发药终端实体</param>
		/// <returns>成功返回1 失败返回－1</returns>
		public int RecipeAdjust(Neusoft.HISFC.Models.Registration.Register patient,ArrayList feeAl,string feeWindow,string adjustType,out DrugTerminal drugTerminalObject,out DrugTerminal sendTerminalObject)
		{
			
			drugTerminalObject = new DrugTerminal();				//调剂结果返回的配药终端
			sendTerminalObject = new DrugTerminal();				//调剂结果返回的发药终端
			string drugTerminal = "";								//本组调剂分配后的配药台编码
			string sendTerminal = "";								//本组调剂分配后的发药窗编码

			string adjustLevel = "a";								//处方调剂级别 字符越大级别越高
			int drugKindNum = feeAl.Count;							//本处方品种数
			int averageNum = 0;										//均分次数
			
			if (adjustType != "1")
				adjustType = "0";

            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeTemp = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
			if (feeAl.Count <= 0)
				return 1;
			
			for(int i = 0;i < feeAl.Count;i++)
			{
				#region 调剂规则计算
                feeTemp = feeAl[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
				if (feeTemp == null)
				{
					this.Err = "处理费用信息时 发生类型转换错误";
					return -1;
				}

				#region 根据特殊配药台的调剂规则进行判断 如返回不为空 判断是否为退改费的处方
				//判断是否满足特殊配药台需求 
				Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal speTerminalTemp = new DrugSPETerminal();
				//调剂中的专科根据什么判断 当前先根据挂号科室判断
                string strDept = ((Neusoft.HISFC.Models.Registration.Register)feeTemp.Patient).DoctorInfo.Templet.Dept.ID;
				//feeItemList实体继承自BaseItem feeTemp.ID存储项目编码 
                speTerminalTemp = this.GetDrugSPETerminalByItemCode(adjustType, feeTemp.ExecOper.Dept.ID, feeWindow, feeTemp.Item.ID, strDept, patient.Pact.ID);
				//返回不为空 说明满足特殊配药台调剂条件 进入判断
				if (speTerminalTemp != null && speTerminalTemp.Terminal.ID != null && speTerminalTemp.Terminal.ID != "")
				{
					if (adjustType == "1")
						averageNum = 1;

                    Neusoft.HISFC.Models.Pharmacy.DrugTerminal tempTerminal = this.GetDrugTerminal(speTerminalTemp.Terminal.ID);
                    if (tempTerminal != null && tempTerminal.ID != "" && !tempTerminal.IsClose)
                    {
                        speTerminalTemp.Terminal = tempTerminal;
                        if (speTerminalTemp.ItemType != null && speTerminalTemp.ItemType.CompareTo(adjustLevel) >= 0) //本次调剂级别高于已有配药台的调剂级别时才进行更改
                        {
                            drugTerminal = speTerminalTemp.Terminal.ID;					//根据调剂条件得到的配药台
                            adjustLevel = speTerminalTemp.ItemType;					//调剂级别 'a'～'z' 字符级大级别越高
                            drugTerminalObject = null;
                        }
                        if (speTerminalTemp.ItemType == "z")	//满足收费窗口的调剂规则 不需继续进行判断 可直接返回
                        {
                            //收费窗口为最高级别的调剂规则 肯定会对已有的配药台进行更改
                            drugTerminal = speTerminalTemp.Terminal.ID;
                            adjustLevel = "z";					//最高级别
                            drugTerminalObject = null;
                            break;
                        }
                        continue;
                    }
				}
				#endregion

				#region 判断该患者是否未取药的取药处方  此处取未关闭的配药台
				if (adjustLevel.CompareTo("d") < 0)				//原调剂级别优先级小于本级别时才进行下一步判断
				{
					//发药药房 = 执行科室
					this.JudegPatientRecipe(feeTemp.ExecOper.Dept.ID,feeTemp.Patient.PID.CardNO,out sendTerminal);
					//存在未取药的处方
					if (sendTerminal != "")
					{
						Neusoft.HISFC.Models.Pharmacy.DrugTerminal terminalTemp = new DrugTerminal();
						terminalTemp = this.GetDrugTerminalBySendWindow(sendTerminal);
						if (terminalTemp != null && terminalTemp.ID != "")
						{
							drugTerminal = terminalTemp.ID;			//配药台编码
							adjustLevel = "d";		
							drugTerminalObject = null;
							continue;
						}						
						else
						{
							sendTerminal = "";
						}
					}
				}
				#endregion

				#region 调剂规则判定 平均调剂/竞争调剂  此处取未关闭的、参与调剂的普通配药台
				if (adjustType != "1")
				{
					#region 平均调剂
					if (adjustLevel.CompareTo("c") < 0)			//上次调剂级别小于本级时 
					{
						drugTerminalObject = this.TerminalStatInfo(feeTemp.ExecOper.Dept.ID,"1");
						if (drugTerminalObject == null)
							return -1;
						if (drugTerminalObject.ID != "")
						{
							averageNum = 0;
							drugTerminal = drugTerminalObject.ID;
							adjustLevel = "c";
							continue;
						}
						else
						{
							this.Err = "在" + feeTemp.ExecOper.Dept.ID + "内未找到满足调剂条件的开放的配药台 请与药房管理人员联系";
							return -1;
						}
					}
					#endregion
				}
				else
				{
					#region 竞争调剂
					if (adjustLevel.CompareTo("b") < 0)			//上次调剂级别小于本级时
					{
						drugTerminalObject = this.TerminalStatInfo(feeTemp.ExecOper.Dept.ID,"2");
						if (drugTerminalObject == null)
							return -1;
						if (drugTerminalObject.ID != "")
						{
							averageNum = 1;
							drugTerminal = drugTerminalObject.ID;
							adjustLevel = "b";
							continue;
						}
						else
						{
							this.Err = "在" + feeTemp.ExecOper.Dept.ID + "内未找到满足调剂条件的开放的配药台 请与药房管理人员联系";
							return -1;
						}
					}
					#endregion
				}
				#endregion

				#endregion
			}
			if (drugTerminal != "")
			{
				#region 根据该配药台编码 获取对应的发药窗口编码 更新已发送处方品种数信息 并返回对应的取药信息字符串
				if (drugTerminalObject == null || drugTerminalObject.ID == "")
				{
					drugTerminalObject = this.GetDrugTerminal(drugTerminal);
					if (drugTerminalObject == null)
					{
						this.Err = "获取调剂后的配药终端详细信息时出错" + this.Err;
						return -1;
					}					
					if (drugTerminalObject.ID == "")
					{
						this.Err = "根据处方调剂规则 无法找到满足条件且开放的配药台/发药窗口";
						return -1;
					}
				}
				//发药窗口编码为空 根据配药台获取对应的发药窗口编码
				if (sendTerminalObject == null || sendTerminalObject.ID == "")
				{
					if (sendTerminal != null && sendTerminal != "")
						sendTerminalObject = this.GetDrugTerminalById(sendTerminal);
					else
						sendTerminalObject = this.GetDrugTerminalById(drugTerminalObject.SendWindow.ID);
					if (sendTerminalObject == null)
					{
						this.Err = "获取调剂后的发药终端详细信息时出错" + this.Err;
						return -1;
					}
					if (sendTerminalObject.ID == "")
					{
						this.Err = "根据处方调剂规则 无法找到满足条件且开放的配药台/发药窗口" + this.Err;
						return -1;
					}
				}

                //屏蔽更新语句使用新处方调剂方式by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}
                ////更新已发送、待配药的处方品种数信息
                //if (this.UpdateTerminalAdjustInfo(drugTerminalObject.ID,drugKindNum,drugKindNum,averageNum) == -1)
                //{
                //    this.Err = "更新配药台已发送、待配药数量时出错" + this.Err;
                //    return -1;
                //}

                //记录调剂原因
                drugTerminalObject.Memo = adjustLevel;
				return 1;
				#endregion
			}
						
			this.Err = "根据处方调剂规则 无法找到满足条件且开放的配药台/发药窗口" + this.Err;
			return -1;
		}
		
		public class FeeSort:System.Collections.IComparer
		{
			public FeeSort() {}


			#region IComparer 成员

			public int Compare(object x, object y)
			{
                // TODO:  添加 FeeSort.Compare 实现
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f1 = x as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f2 = y as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                if (f1 == null || f2 == null)
                {
                    throw new Exception("数组内必须为OutPatient.FeeItemList类型");
                }
                string oX = f1.ExecOper.Dept.ID;          //执行科室
                string oY = f2.ExecOper.Dept.ID;          //执行科室

                int nComp;

                if (oX == null)
                {
                    nComp = (oY != null) ? -1 : 0;
                }
                else if (oY == null)
                {
                    nComp = 1;
                }
                else
                {
                    nComp = string.Compare(oX.ToString(), oY.ToString());
                }

                return nComp;
			}

			#endregion

		}
		public class RecipeSort:System.Collections.IComparer
		{
			public RecipeSort() {}


			#region IComparer 成员

			public int Compare(object x, object y)
			{
                // TODO:  添加 FeeSort.Compare 实现
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f1 = x as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f2 = y as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                if (f1 == null || f2 == null)
                    throw new Exception("数组内必须为OutPatient.FeeItemList类型");
                string oX = f1.RecipeNO;          //处方号
                string oY = f2.RecipeNO;          //处方号

                int nComp;

                if (oX == null)
                {
                    nComp = (oY != null) ? -1 : 0;
                }
                else if (oY == null)
                {
                    nComp = 1;
                }
                else
                {
                    nComp = string.Compare(oX.ToString(), oY.ToString());
                }

                return nComp;
			}

			#endregion
		}

		#endregion


        #region 无效
        /// <summary>
		/// 获得摆药单分类信息列表
		/// </summary>
		/// <returns>摆药单分类数组</returns>
        [System.Obsolete("系统重构 整合为QueryDrugBillClassList函数",true)]
        public ArrayList GetDrugBillClassList()
        {
            return null;
        }
        /// <summary>
		/// 根据摆药单分类编码获得摆药单分类明细
		/// </summary>
		/// <param name="drugBillClassCode">分类编码</param>
		/// <returns></returns>
        [System.Obsolete("系统重构 整合为QueryDrugBillList函数 该函数参数待加注释",true)]
        public ArrayList GetDrugBillList(string drugBillClassCode, string column)
        {
            return null;
        }

        /// <summary>
		/// 取摆药台流水号
		/// </summary>
		/// <returns>"-1"出错，oterhs 成功</returns>
        [System.Obsolete("系统重构 整合为GetDrugControlNO函数",true)]
        public string GetDrugControlID()
        {
            return null;
        }

        /// <summary>
		/// 根据科室编码，取本科室的全部摆药台列表
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <returns>摆药台数组</returns>
        [System.Obsolete("系统重构 整合为QueryDrugControlList函数", true)]
        public ArrayList GetDrugControlList(string deptCode)
        {
            return null;
        }
        /// <summary>
		/// 根据摆药台编码，取此摆药台中的全部明细
		/// </summary>
		/// <param name="drugControlCode">摆药台编码</param>
		/// <returns>摆药单分类数组</returns>
        [System.Obsolete("系统重构 整合为QueryDrugControlDetailList函数", true)]
        public ArrayList GetDrugControlDetailList(string drugControlCode)
        {
            return null;
        }

        /// <summary>
        /// 获得某一申请科室的未摆药通知列表
        /// </summary>
        /// <param name="sendDeptCode">申请科室编码</param>
        /// <returns>成功返回摆药通知信息 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugMessageList函数", true)]
        public ArrayList GetDrugMessageList(string sendDeptCode)
        {
            string strSQL = "";    //获得某一申请科室的全部摆药通知列表的SELECT语句

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.BySendDept", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.GetDrugMessageList.BySendDept字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, sendDeptCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.BySendDept";
                return null;
            }
            return myGetDrugMessage(strSQL);
        }


        /// <summary>
        /// 获得某一申请科室的全部摆药通知列表
        /// </summary>
        /// <param name="sendDeptCode">申请科室编码</param>
        /// <returns>成功返回摆药通知列表 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryAllDrugMessageList函数", true)]
        public ArrayList GetAllDrugMessageList(string sendDeptCode)
        {
            string strSQL = "";    //获得某一申请科室的全部摆药通知列表的SELECT语句

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetAllDrugMessageList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.GetAllDrugMessageList字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, sendDeptCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "|Pharmacy.DrugStore.GetAllDrugMessageList";
                return null;
            }

            ArrayList al = new ArrayList();
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取摆药通知列表时出错：" + this.Err;
                return null;
            }
            try
            {
                DrugMessage info;   //摆药通知实体		
                while (this.Reader.Read())
                {
                    info = new DrugMessage();
                    try
                    {
                        info.StockDept.ID = this.Reader[0].ToString();          //发送科室编码
                        info.StockDept.Name = this.Reader[1].ToString();          //发送科室名称
                        info.DrugBillClass.ID = this.Reader[2].ToString();          //摆药单分类编码
                        info.DrugBillClass.Name = this.Reader[3].ToString();          //摆药单分类名称
                        info.SendType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());      //摆药类型1-集中摆药2-临时摆药
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得摆药通知信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    al.Add(info);
                }
                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得摆药通知信息时，执行SQL语句出错！myGetDrugBillClass" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获得某一摆药台中全部摆药通知列表
        /// SendType=1集中，2临时
        /// 当SendType＝0时，显示全部类型的摆药通知。
        /// </summary>
        /// <param name="drugControl">摆药台</param>
        /// <returns>成功返回摆药通知数组 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugMessageList函数", true)]
        public ArrayList GetDrugMessageList(DrugControl drugControl)
        {
            //如果没有指定发送科室，则取全部发送科室的通知
            string strSQL = "";    //获得某一摆药台（摆药台中有科室信息）中全部摆药通知列表的SELECT语句

            #region 取手术室摆药单
            //取SQL语句
            //			if (drugControl.ID =="P") {
            //				if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.ByOPR",ref strSQL) == -1) {
            //					this.Err="没有找到Pharmacy.DrugStore.GetDrugMessageList.ByOPR字段!";
            //					return null;
            //				}
            //				try {
            //					string[] strParm={drugControl.Dept.ID};
            //					strSQL = string.Format(strSQL, strParm);
            //				}
            //				catch(Exception ex) {
            //					this.ErrCode=ex.Message;
            //					this.Err=ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.ByOPR";
            //					return null;
            //				}
            //			}
            #endregion

            if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.ByDrugControl", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.GetDrugMessageList.ByDrugControl字段!";
                return null;
            }
            try
            {
                string[] strParm ={ drugControl.ID };
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.ByDrugControl";
                return null;
            }
            return myGetDrugMessage(strSQL);
        }


        /// <summary>
        /// 获得某一摆药通知的明细列表;
        /// </summary>
        /// <param name="drugMessage">摆药通知</param>
        /// <returns>成功返回摆药通知信息 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugMessageList函数", true)]
        public ArrayList GetDrugMessageList(DrugMessage drugMessage)
        {

            string strSQL = "";    //获得某一摆药通知的明细列表的SQL语句

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugMessageList.ByDrugMessage", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.GetDrugMessageList.ByDrugMessage字段!";
                return null;
            }
            try
            {
                string[] strParm ={
									 drugMessage.StockDept.ID, 
									 drugMessage.DrugBillClass.ID, 
									 drugMessage.SendType.ToString()
								 };
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "|Pharmacy.DrugStore.GetDrugMessageList.ByDrugMessage";
                return null;
            }
            return myGetDrugMessage(strSQL);
        }
        /// <summary>
        /// 成功返回摆药通知信息
        /// </summary>
        /// <param name="drugControlID">摆药台编码</param>
        /// <param name="drugMessage">摆药通知</param>
        /// <returns>成功返回摆药通知信息 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugBillList函数", true)]
        public ArrayList GetDrugBillList(string drugControlID, DrugMessage drugMessage)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.DrugStore.GetDrugBillList.ByDept", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.DrugStore.GetDrugBillList.ByDept字段!";
                return null;
            }
            try
            {
                string[] strParm ={
									 drugControlID,
									 drugMessage.ApplyDept.ID, 
									 drugMessage.StockDept.ID, 
									 drugMessage.SendType.ToString()
								 };
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message + "|Pharmacy.DrugStore.GetDrugBillList.ByDept";
                return null;
            }
            return myGetDrugMessage(strSQL);
        }

        /// <summary>
		/// 获得某科室某类型门诊终端列表
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="terminalType">终端类型 0 发药窗 1 配药台</param>
		/// <returns>成功返回DrugTerminal的ArrayList数组，失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugTerminalByDeptCode函数", true)]
        public ArrayList GetDrugTerminalByDeptCode(string deptCode, string terminalType)
        {
            return null;
        }

        /// <summary>
		/// 某类型门诊特殊配药台列表
		/// </summary>
		/// <param name="itemType">类别 1 药品 2 专科 3 结算类别 4 特定收费窗口 "A"所有 </param>
		/// <returns>成功返回DrugSPETerminal的ArrayList数组，失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugSPETerminalByType函数", true)]
		public ArrayList GetDrugSPETerminalByType(string itemType) 
		{
			return null;
		}
				
		/// <summary>
		/// 某科室、某类型门诊特殊配药台列表 类型为"A"代表所有类别
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="itemType">类别  1 药品 2 专科 3 结算类别 4 特定收费窗口 "A"所有</param>
		/// <returns>成功返回DrugSPETerminal的ArrayList数组、失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugSPETerminalByDeptCode函数", true)]
        public ArrayList GetDrugSPETerminalByDeptCode(string deptCode, string itemType)
        {
            return null;
        }

        /// <summary>
		/// 根据科室编号获取该科室模板列表
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <returns>成功返回neuobject数组(ID 模板编号 Name 模板名称)、失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugOpenTerminalByDeptCode函数", true)]
		public ArrayList GetDrugOpenTerminalByDeptCode(string deptCode) 
        {
            return null;
        }	
		/// <summary>
		/// 根据模板编号获取模板详细信息
		/// </summary>
		/// <param name="templateCode">模板编号</param>
		/// <returns>成功返回数组 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryDrugOpenTerminalByID函数", true)]
        public ArrayList GetDrugOpenTerminalById(string templateCode)
        {
            return null;
        }

        /// <summary>
		/// 获取发送到指定药房、指定终端的处方列表
		/// </summary>
		/// <param name="deptCode">药房编码</param>
		/// <param name="terminalCode">终端编码</param>
		/// <param name="type">终端类别 0发药窗口/1配药台</param>
		/// <param name="state">处方状态</param>
		/// <returns>成功返回门诊摆药实体数组 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryList函数", true)]
        public ArrayList GetList(string deptCode, string terminalCode, string type, string state)
        {
            return null;
        }

         /// <summary>
        /// 获取指定收费时间后发送到指定药房、指定终端的处方列表
        /// </summary>
        /// <param name="deptCode">药房编码</param>
        /// <param name="terminalCode">终端编码</param>
        /// <param name="type">终端类别  0发药窗口/1配药台</param>
        /// <param name="state">处方状态</param>
        /// <param name="queryDate">收费时间</param>
        /// <returns>成功返回门诊摆药实体数组 失败返回null</returns>
        [System.Obsolete("系统重构 整合为QueryList函数", true)]
        public ArrayList GetList(string deptCode, string terminalCode, string type, string state, DateTime queryDate)
        {
            return null;
        }

        	/// <summary>
		/// 根据单据号 获取 处方调剂信息
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="class3MeaningCode">出库分类 M1 门诊出库 M2  门诊退库</param>
		/// <param name="recipeState">处方状态</param>
		/// <param name="billType">单据类型 0 处方号 1 发票号 2 病历卡号</param>
		/// <param name="billNo">单据号</param>
		/// <returns>成功返回DrugRecipe数组 失败返回null 未找到返回空数组</returns>
        [System.Obsolete("系统重构 整合为QueryDrugRecipe函数", true)]
        public ArrayList GetDrugRecipe(string deptCode, string class3MeaningCode, string recipeState, int billType, string billNo)
        {
            return null;
        }

        #endregion

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户新增
        /// <summary>
        /// 根据处方号执行科室删除调剂头表
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="execDeptCode">执行科室</param>
        /// <returns></returns>
        public int DeleteDrugStoRecipe(string recipeNO, string execDeptCode)
        {
            string strSql = "";

            if (this.Sql.GetSql("Pharmacy.Item.DeleteStoRecipe", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, recipeNO, execDeptCode);       //
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新调剂头表的处方金额药品数量
        /// </summary>
        /// <param name="reciptCost">处方金额</param>
        /// <param name="drugCount">药品数量</param>
        /// <returns></returns>
        public int UpdateStoRecipe(string recipeNO, string deptCode, decimal reciptCost, int drugCount)
        {
            //根据处方号执行科室查询未收费的药品费用信息
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStoRecipe", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateStoRecipe";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, recipeNO, deptCode, reciptCost.ToString(), drugCount.ToString());
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateStoRecipe";
                return -1;
            }
            return this.ExecNoQuery(strSQL);

        }

        /// <summary>
        /// 更新处方调剂表收费操作信息
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="deptCode">执行科室</param>
        /// <param name="operCode">操作员</param>
        /// <param name="operDate">操作时间</param>
        /// <returns></returns>
        public int UpdateStoRecipeFeeOper(string recipeNO, string deptCode, string operCode)
        {
            //根据处方号执行科室查询未收费的药品费用信息
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStoRecipeFeeOper", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateStoRecipeFeeOper";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, recipeNO, deptCode, operCode);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateStoRecipeFeeOper";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region 住院领药单查询 无锡添加（来自中日）

        /// <summary>
        /// 查询摆药单列表
        /// </summary>
        /// <param name="deptCode">科室代码</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="useTime">是否设置时间查询 0否 1是</param>
        /// <param name="drugedType">摆药类型 0未摆药 1已摆药 2全部</param>
        /// <returns></returns>
        public ArrayList QueryBillListByDept(string deptCode, string startDate, string endDate, string useTime, string drugedType)
        {
            string strSql = "";
            ArrayList alBills = new ArrayList();

            if (this.Sql.GetSql("Pharmacy.Drugstore.Inpatient.DrugList.BillList", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Drugstore.Inpatient.DrugList.BillList索引";
                return null;
            }
            try
            {
                if (this.ExecQuery(strSql, "0", deptCode, startDate, endDate, useTime, drugedType) == -1)
                {
                    this.Err = "获得摆药单列表失败，执行SQL语句出错！" + this.Err;
                    this.ErrCode = "-1";
                    return null;
                }
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject billObj = new Neusoft.FrameWork.Models.NeuObject();
                    billObj.ID = this.Reader[0].ToString();
                    billObj.Name = this.Reader[1].ToString();
                    alBills.Add(billObj);
                }

                return alBills;
            }
            catch (Exception ex)
            {
                this.Err = "执行sql获得摆药单列表失败！" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 查询领药单汇总
        /// </summary>
        /// <param name="billCode">摆药单编号</param>
        /// <param name="deptCode">科室代码</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="useTime">是否设置时间查询 0否 1是</param>
        /// <param name="drugedType">摆药类型 0未摆药 1已摆药 2全部</param>
        /// <returns></returns>
        public System.Data.DataTable QueryDrugTotalByDept(string billCode, string deptCode, string startDate, string endDate, string drugedType)
        {
            string strSql = "";
            System.Data.DataSet dsTotal = new System.Data.DataSet();

            if (this.Sql.GetSql("Pharmacy.Drugstore.Inpatient.DrugList.Total", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Drugstore.Inpatient.DrugList.Total索引";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, billCode, deptCode, startDate, endDate, drugedType);

                if (this.ExecQuery(strSql, ref dsTotal) == -1)
                {
                    this.Err = "获得摆药单药品汇总信息失败，执行SQL语句出错！" + this.Err;
                    this.ErrCode = "-1";
                    return null;
                }

                return dsTotal.Tables[0];
            }
            catch (Exception ex)
            {
                this.Err = "执行sql获得摆药单药品汇总信息失败！" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 查询领药单明细
        /// </summary>
        /// <param name="billCode">摆药单编号</param>
        /// <param name="deptCode">科室代码</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="useTime">是否设置时间查询 0否 1是</param>
        /// <param name="drugedType">摆药类型 0未摆药 1已摆药 2全部</param>
        /// <returns></returns>
        public System.Data.DataTable QueryDrugDetailByDept(string billCode, string deptCode, string startDate, string endDate, string drugedType)
        {
            string strSql = "";
            System.Data.DataSet dsTotal = new System.Data.DataSet();

            if (this.Sql.GetSql("Pharmacy.Drugstore.Inpatient.DrugList.Detail", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Drugstore.Inpatient.DrugList.Detail索引";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, billCode, deptCode, startDate, endDate, drugedType);

                if (this.ExecQuery(strSql, ref dsTotal) == -1)
                {
                    this.Err = "获得摆药单药品明细信息失败，执行SQL语句出错！" + this.Err;
                    this.ErrCode = "-1";
                    return null;
                }

                return dsTotal.Tables[0];
            }
            catch (Exception ex)
            {
                this.Err = "执行sql获得摆药单药品明细信息失败！" + ex.Message;
                return null;
            }
        }

        #endregion

        #region 住院领药单查询 郑大修改（不知道sql索引别处是否使用，所以提出来） wbo 2010-10-02

        /// <summary>
        /// 查询领药单汇总
        /// </summary>
        /// <param name="billCode">摆药单编号</param>
        /// <param name="deptCode">科室代码</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="useTime">是否设置时间查询 0否 1是</param>
        /// <param name="drugedType">摆药类型 0未摆药 1已摆药 2全部</param>
        /// <returns></returns>
        public System.Data.DataTable LocalQueryDrugTotalByDept(string billCode, string deptCode, string startDate, string endDate, string drugedType)
        {
            string strSql = "";
            System.Data.DataSet dsTotal = new System.Data.DataSet();

            strSql = @"select s.trade_name as 药品名称,
       t.specs as 规格,
       sum(t.apply_num) as 总量,
       t.min_unit as 单位,
       (select dept_name from com_department where t.dept_code = dept_code) as 申请科室,
       (select dept_name
          from com_department
         where drug_dept_code = dept_code) as 取药药房,
       (select pha_sto_billclass.billclass_name
          from pha_sto_billclass
         where pha_sto_billclass.billclass_code = t.billclass_code) as 摆药单,
       decode(t.valid_state, '1', '有效', '无效') as 有效性,
       s.spell_code as 拼音码,
       s.wb_code as 五笔码
--decode(t.PRINT_DATE, '', '未摆', '已摆') AS 状态
--decode('', '2', '★', '') as 进口标识--无锡不要
  from pha_com_applyout t, pha_com_baseinfo s
 where t.drug_code = s.drug_code
   and t.billclass_code = '{0}'
   and t.dept_code in ('{1}')
      /*   and (t.druged_date >= to_date('{2}', 'yyyy-mm-dd hh24:mi:ss') and
             t.druged_date < to_date('{3}', 'yyyy-mm-dd hh24:mi:ss'))
      */
   and (t.apply_date >= to_date('{2}', 'yyyy-mm-dd hh24:mi:ss') and
       t.apply_date < to_date('{3}', 'yyyy-mm-dd hh24:mi:ss'))
   and t.apply_state in ({4})
 group by s.trade_name,
          t.specs,
          t.min_unit,
          t.dept_code,
          t.drug_dept_code,
          t.billclass_code,
          t.valid_state,
          s.spell_code,
          s.wb_code
--t.PRINT_DATE
 order by t.drug_dept_code, s.trade_name";
            try
            {
                strSql = string.Format(strSql, billCode, deptCode, startDate, endDate, drugedType);

                if (this.ExecQuery(strSql, ref dsTotal) == -1)
                {
                    this.Err = "获得摆药单药品汇总信息失败，执行SQL语句出错！" + this.Err;
                    this.ErrCode = "-1";
                    return null;
                }

                return dsTotal.Tables[0];
            }
            catch (Exception ex)
            {
                this.Err = "执行sql获得摆药单药品汇总信息失败！" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 查询领药单明细
        /// </summary>
        /// <param name="billCode">摆药单编号</param>
        /// <param name="deptCode">科室代码</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="useTime">是否设置时间查询 0否 1是</param>
        /// <param name="drugedType">摆药类型 0未摆药 1已摆药 2全部</param>
        /// <returns></returns>
        public System.Data.DataTable LocalQueryDrugDetailByDept(string billCode, string deptCode, string startDate, string endDate, string drugedType)
        {
            string strSql = "";
            System.Data.DataSet dsTotal = new System.Data.DataSet();

            strSql = @"select substr(r.bed_no, 5) as 床号,
       r.name as 姓名,
       r.patient_no as 住院号,
       s.trade_name as 药品名称,
       t.specs as 规格,
       t.dose_once as 每次量,
       t.dose_unit as 剂量单位,
       t.dfq_freq as 频次,
       t.use_name as 用法,
       sum(t.apply_num) as 总量,
       t.min_unit as 单位,
       (select dept_name from com_department where t.dept_code = dept_code) as 申请科室,
       (select dept_name
          from com_department
         where drug_dept_code = dept_code) as 取药药房,
       (select pha_sto_billclass.billclass_name
          from pha_sto_billclass
         where pha_sto_billclass.billclass_code = t.billclass_code) as 摆药单,
       decode(t.valid_state, '1', '有效', '无效') as 有效性,
       s.spell_code as 拼音码,
       s.wb_code as 五笔码,
       decode(t.PRINT_DATE, '', '未摆', '已摆') AS 状态,
       --decode('', '2', '★', '') as 进口标识,--无锡不要
       t.druged_bill as 摆药单号,
       to_char(t.PRINT_DATE, 'yyyy-MM-dd hh24:mi:ss') as 发药时间
  from pha_com_applyout t, pha_com_baseinfo s, fin_ipr_inmaininfo r
 where t.drug_code = s.drug_code
   and t.patient_id = r.inpatient_no
   and t.billclass_code = '{0}'
   and t.dept_code in ('{1}')
      /*and (t.druged_date >= to_date('{2}', 'yyyy-mm-dd hh24:mi:ss') and
             t.druged_date < to_date('{3}', 'yyyy-mm-dd hh24:mi:ss'))*/
   and (t.apply_date >= to_date('{2}', 'yyyy-mm-dd hh24:mi:ss') and
       t.apply_date < to_date('{3}', 'yyyy-mm-dd hh24:mi:ss'))
   and t.apply_state in ({4})
 group by r.patient_no,
          r.bed_no,
          r.name,
          s.trade_name,
          t.specs,
          t.dose_once,
          t.dose_unit,
          t.dfq_freq,
          t.use_name,
          t.min_unit,
          t.dept_code,
          t.drug_dept_code,
          t.billclass_code,
          t.valid_state,
          s.spell_code,
          s.wb_code,
          t.druged_bill,
          t.PRINT_DATE
 order by r.bed_no, r.name";

            try
            {
                strSql = string.Format(strSql, billCode, deptCode, startDate, endDate, drugedType);

                if (this.ExecQuery(strSql, ref dsTotal) == -1)
                {
                    this.Err = "获得摆药单药品明细信息失败，执行SQL语句出错！" + this.Err;
                    this.ErrCode = "-1";
                    return null;
                }

                return dsTotal.Tables[0];
            }
            catch (Exception ex)
            {
                this.Err = "执行sql获得摆药单药品明细信息失败！" + ex.Message;
                return null;
            }
        }

        #endregion

    }
}
