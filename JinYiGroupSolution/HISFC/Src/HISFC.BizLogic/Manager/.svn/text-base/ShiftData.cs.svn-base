using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

namespace Neusoft.HISFC.BizLogic.Manager
{
    /// <summary>
    /// [功能描述: 变更记录管理类]<br></br>
    /// [创 建 者: dorian]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明>
    ///     
    /// </说明>
    /// </summary>
	public class ShiftData :Neusoft.FrameWork.Management.Database
	{
		public ShiftData()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region 需变更属性记录设置

        /// <summary>
        /// 获取Sql参数数组
        /// </summary>
        /// <param name="shiftProperty">变更属性记录类</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] GetSqlParamForShiftProperty(Neusoft.HISFC.Models.Base.ShiftProperty shiftProperty)
        {
            string[] strParam = new string[]{
                                                shiftProperty.ReflectClass.ID,
                                                shiftProperty.ReflectClass.Name,                                                
                                                shiftProperty.Property.ID,
                                                shiftProperty.Property.Name,
                                                shiftProperty.PropertyDescription,
                                                Neusoft.FrameWork.Function.NConvert.ToInt32(shiftProperty.IsRecord).ToString(),
                                                shiftProperty.ShiftCause,
                                                shiftProperty.Memo,
                                                shiftProperty.Oper.ID,
                                                shiftProperty.Oper.OperTime.ToString()
                                            };

            return strParam;
        }

        /// <summary>
        /// 执行sql语句获取变更属性信息
        /// </summary>
        /// <param name="strExe">需执行的sql语句</param>
        /// <returns>成功返回List集合 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Base.ShiftProperty> ExecSqlForShiftProperty(string strExe)
        {
            List<Neusoft.HISFC.Models.Base.ShiftProperty> al = new List<Neusoft.HISFC.Models.Base.ShiftProperty>();
            Neusoft.HISFC.Models.Base.ShiftProperty sf = null;

            if (this.ExecQuery(strExe) == -1)
            {
                this.Err = "执行Sql语句发生异常" + this.Err;
                return null;
            }

            try
            {             
                while (this.Reader.Read())
                {
                    sf = new Neusoft.HISFC.Models.Base.ShiftProperty();

                    sf.ReflectClass.ID = this.Reader[0].ToString();
                    sf.ReflectClass.Name = this.Reader[1].ToString();
                    sf.Property.ID = this.Reader[2].ToString();
                    sf.Property.Name = this.Reader[3].ToString();
                    sf.PropertyDescription = this.Reader[4].ToString();
                    sf.IsRecord = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[5]);
                    sf.ShiftCause = this.Reader[6].ToString();
                    sf.Memo = this.Reader[7].ToString();
                    sf.Oper.ID = this.Reader[8].ToString();
                    sf.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9]);

                    al.Add(sf);
                }

                return al;
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内读取数据发生异常" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 执行sql语句获取变更属性列表信息
        /// </summary>
        /// <param name="strExe">需执行的sql语句</param>
        /// <returns>成功返回List集合 失败返回null</returns>
        private List<Neusoft.FrameWork.Models.NeuObject> ExecSqlForShiftPropertyList(string strExe)
        {
            List<Neusoft.FrameWork.Models.NeuObject> al = new List<Neusoft.FrameWork.Models.NeuObject>();
            Neusoft.FrameWork.Models.NeuObject sfList = null;

            if (this.ExecQuery(strExe) == -1)
            {
                this.Err = "执行Sql语句发生异常" + this.Err;
                return null;
            }

            try
            {              
                while (this.Reader.Read())
                {
                    sfList = new Neusoft.FrameWork.Models.NeuObject();

                    sfList.ID = this.Reader[0].ToString();          //ReflectClass ID
                    sfList.Name = this.Reader[1].ToString();        //ReflectClass Name 

                    al.Add(sfList);
                }

                return al;
            }
            catch (Exception ex)
            {
                this.Err = "由Reader内读取数据发生异常" + ex.Message;
                return null;
            }
            finally
            {                
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="sf"></param>
        /// <returns></returns>
        public int InsertShiftProperty(Neusoft.HISFC.Models.Base.ShiftProperty sf)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Manager.ShiftData.InsertShiftProperty", ref strSQL) == -1) return -1;
            string[] strParm;
            try
            {
                strParm = this.GetSqlParamForShiftProperty(sf);  //取参数列表
                strSQL = string.Format( strSQL , strParm );    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSQL, strParm);
        }

        /// <summary>
        /// 变更属性信息删除
        /// </summary>
        /// <param name="ReflectClassID">变更属性所属类</param>
        /// <param name="propertyID">变更属性</param>
        /// <returns>成功返回1 失败返回-1 无记录返回0</returns>
        public int DelShiftProperty(string ReflectClassID, string propertyID)
        {
            string strSQL = ""; //根据药品编码删除某一药品信息的DELETE语句
            if (this.Sql.GetSql("Manager.ShiftProperty.DelShiftProperty.Detail", ref strSQL) == -1)
            {
                return -1;
            }

            try
            {
                strSQL = string.Format(strSQL, ReflectClassID, propertyID);
            }
            catch
            {
                this.Err = "传入参数不对！Manager.ShiftProperty.DelShiftProperty.Detail";
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 变更属性信息删除
        /// </summary>
        /// <param name="ReflectClassID">变更属性所属类</param>
        /// <returns>成功返回大于等于1 失败返回-1 无记录返回0</returns>
        public int DelShiftProperty(string ReflectClassID)
        {
            string strSQL = ""; //根据药品编码删除某一药品信息的DELETE语句
            if (this.Sql.GetSql("Manager.ShiftProperty.DelShiftProperty.Type", ref strSQL) == -1)
            {
                return -1;
            }

            try
            {
                strSQL = string.Format(strSQL, ReflectClassID);
            }
            catch
            {
                this.Err = "传入参数不对！Manager.ShiftProperty.DelShiftProperty.Type";
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取变更属性列表信息
        /// </summary>
        /// <returns>成功返回列表信息 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryShiftPropertyList()
        {
            string strSelect = "";  //获得全部药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Manager.ShiftProperty.List", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.ExecSqlForShiftPropertyList(strSelect);
        }

        /// <summary>
        /// 获取变更属性信息
        /// </summary>
        /// <param name="ReflectClassID">所属类</param>
        /// <returns>成功返回信息 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Base.ShiftProperty> QueryShiftProperty(string ReflectClassID)
        {
            string strSelect = "";  //获得全部药品信息的SELECT语句
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Manager.ShiftProperty.Select", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Manager.ShiftProperty.Where.ReflectClass", ref strWhere) == -1)
            {

                this.Err = "没有找到Manager.ShiftProperty.Where.ReflectClass字段!";
                return null;
            }
            try
            {
                strSelect = strSelect + strWhere;

                strSelect = string.Format(strSelect, ReflectClassID);
            }
            catch
            {
                this.Err = "SQL参数初始化失败";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.ExecSqlForShiftProperty(strSelect);
        }

        #endregion

        #region 变更记录

        /// <summary>
		/// 设置变更信息-插入变更信息表
		/// insert
		/// </summary>
        /// <param name="itemCode">项目编码</param>
        /// <param name="itemType">项目类型</param>
        /// <param name="originalData">变更前数据</param>
        /// <param name="newData">变更后数据</param>
        /// <param name="shiftCause">变更原因</param>
		/// <returns>0 成功  -1失败</returns>
        public int SetShiftData(string itemCode,string itemType,Neusoft.FrameWork.Models.NeuObject originalData,Neusoft.FrameWork.Models.NeuObject newData,string shiftCause)
        {
            ///定义sql字符串
            string strSql = string.Empty;

            if (Sql.GetSql("Manager.ShiftRecord.ShiftData", ref strSql) == -1)
            {
                return -1;
            }

            try
            {
                strSql = string.Format(strSql,
                                      itemCode,
                                      itemType,
                                      originalData.ID,
                                      originalData.Name,
                                      newData.ID,
                                      newData.Name,
                                      shiftCause,
                                      "",
                                      this.Operator.ID
                                      ); 

            }
            catch
            {
                Err = "传入参数错误！Manager.ShiftRecord.ShiftData!";
                WriteErr();
                return -1;
            }

            if (ExecNoQuery(strSql) != 1)
            {
                return -1;
            };

            return 1;

        }
        #endregion

        #region 原类包含查询函数

        /// <summary>
		/// 查询变更日志
		/// </summary>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <param name="InpatientNo"></param>
		/// <returns></returns>
		public ArrayList GetShiftData(System.DateTime beginTime, System.DateTime endTime,string InpatientNo)
		{
			ArrayList List =null;
			try
			{
				string strSql = "";
				//select clinic_no,happen_no,shift_type,old_data_code,old_data_name,new_data_code,new_data_name,shift_cause,mark from com_shiftdata;
				if (this.Sql.GetSql("Manager.ShiftData.GetShiftData",ref strSql)==-1) return null;
				strSql = string.Format(strSql,beginTime,endTime,InpatientNo);
				this.ExecQuery(strSql);
				List = new ArrayList();
				Neusoft.HISFC.Models.Invalid.CShiftData  info =null;
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Invalid.CShiftData();
					info.ClinicNo =Reader[9].ToString();			//住院流水号
					if(Reader[1]!=DBNull.Value)
					{
						info.HappenNo = Convert.ToUInt32(Reader[1]);	//发生序号
					}
					info.ShitType =Reader[2].ToString();			//变更类型
					info.OldDataCode =Reader[3].ToString();			//变更前数据编码
					info.OldDataName =Reader[4].ToString();			//变更前数据名称
					info.NewDataCode =Reader[5].ToString();			//变更后数据编码
					info.NewDataName =Reader[6].ToString();			//变更后数据编码
					info.ShitCause = Reader[7].ToString();			//变更原因
					info.Mark = Reader[8].ToString();				//备注
					info.User01 = Reader[0].ToString();				//患者姓名
					info.User02 = Reader[10].ToString();			//操作时间
					List.Add(info);
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
			return List;
		}

		/// <summary>
		/// 获取变更信息
		/// </summary>
		/// <returns></returns>
		public DataSet GetShift(string beginTime ,string EndTime ,string InpatientNo,string Type,string DeptCode)
		{
			try
			{
				System.Data.DataSet ds = new DataSet();
				string strSql = "";
				if (this.Sql.GetSql("Manager.ShiftData.GetShiftDataList",ref strSql)==-1) return null;
				strSql = string.Format(strSql,beginTime,EndTime, InpatientNo,Type, DeptCode);
				if (this.ExecQuery(strSql,ref ds) == -1 ) return null;
				return ds;
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
        }

        #endregion
    }
}
