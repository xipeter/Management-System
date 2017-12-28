using System;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// BedFeeItem<br></br>
	/// [功能描述: 床位信息业务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-26]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class BedFeeItem : Neusoft.FrameWork.Management.Database
	{
		
		#region 私有函数
		
		/// <summary>
		/// 通过实体获得字符参数数组
		/// </summary>
		/// <param name="bedFeeItem">床位费实体</param>
		/// <returns></returns>
		private string[] GetBedFeeItemParms(Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem)
		{
			string[] parms = {   bedFeeItem.PrimaryKey,
                                 bedFeeItem.FeeGradeCode,
								 bedFeeItem.ID,
								 bedFeeItem.Name,
								 bedFeeItem.Qty.ToString(),
								 bedFeeItem.SortID.ToString(),
								 NConvert.ToInt32(bedFeeItem.IsBabyRelation).ToString(),
								 NConvert.ToInt32(bedFeeItem.IsTimeRelation).ToString(),
								 bedFeeItem.BeginTime.ToString(),
								 bedFeeItem.EndTime.ToString(),
								 ((int)bedFeeItem.ValidState).ToString(),
								 this.Operator.ID
							 };

			return parms;
		}

		#endregion

		#region 公有函数
		
		/// <summary>
		/// 通过项目编码获得该床位信息的有效性标识(在用(1) 停用(0) 废弃(2))
		/// </summary>
		/// <param name="itemCode">项目编码</param>
		/// <returns>成功返回有效行标识 错误返回"-1"</returns>
		public string GetValidStateByItemCode(string itemCode)
		{
			string validState = string.Empty; //有效状态标志 1 在用 0 停用 2 废弃
			string sql = string.Empty; //查询有效标记的SQL语句

			if (this.Sql.GetSql("Fee.BedFeeItem.IsDisuser",ref sql)==-1)
			{
				this.Err = "没有找到索引为: Fee.BedFeeItem.IsDisuser的SQL语句";
				
				return "-1";
			}

			return this.ExecSqlReturnOne(sql, itemCode);
		}
		
		/// <summary>
		/// 插入床位信息表一条记录(fin_com_bedfeegrade)
		/// </summary>
		/// <param name="bedFeeItem">床位信息实体</param>
		/// <returns>成功 1 失败 -1 没有删除到记录 0</returns>
		public int InsertBedFeeItem(Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem)
		{
			string sql = string.Empty; //插入fin_com_bedfeegrade表的SQL语句

			if (this.Sql.GetSql("Fee.BedFeeItem.InsertBedFeeItem", ref sql) == -1)
			{
				this.Err = "没有找到索引为: Fee.BedFeeItem.InsertBedFeeItem 的SQL语句";
				
				return -1;
			}

			return this.ExecNoQuery(sql, this.GetBedFeeItemParms(bedFeeItem));
		}

		/// <summary>
		/// 更新床位信息一条记录
		/// </summary>
		/// <param name="bedFeeItem">床位信息实体</param>
		/// <returns>成功 1 失败 -1 没有删除到记录 0</returns>
		public int UpdateBedFeeItem(Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem)
		{
		
			string sql = string.Empty; //更新fin_com_bedfeegrade表的SQL语句
			
			if (this.Sql.GetSql("Fee.BedFeeItem.UpdateBedFeeItem", ref sql) == -1)
			{
				this.Err = "没有找到索引为: Fee.BedFeeItem.UpdateBedFeeItem 的SQL语句";
				
				return -1;
			}
			
			return this.ExecNoQuery(sql, this.GetBedFeeItemParms(bedFeeItem));
		}
		
		/// <summary>
		/// 通过项目编码删除一条项目
		/// </summary>
		/// <param name="itemCode">项目编码</param>
		/// <returns>成功 1 失败 -1 没有删除到记录 0</returns>
		public int DeleteByItemCode(string itemCode)
		{
			string sql = string.Empty;

			if (this.Sql.GetSql("Fee.BedFeeItem.DeleteBedFeeItem", ref sql) == -1)
			{
				this.Err = "没有找到索引为: Fee.BedFeeItem.DeleteBedFeeItem 的SQL语句";
				
				return -1;
			}

			return this.ExecNoQuery(sql, itemCode);
		}

		/// <summary>
		/// 根据床号号获取床位等级
		/// </summary>
		/// <param name="bedNO">床号</param>
		/// <returns>成功:床位信息实体 失败 null</returns>
		public Neusoft.HISFC.Models.Base.Bed GetBedGradeByBedNO(string bedNO)
		{
			Bed bed = null; //床位实体
			string sql = string.Empty;//获得床位登记SQL语句
			
			if (this.Sql.GetSql("Fee.BedFeeItem.GetBedGradeByBedNo", ref sql) == -1) 
			{		
				this.Err = "没有找到索引为:Fee.BedFeeItem.GetBedGradeByBedNo的SQL语句";

				return null;
			}			
			
			if (this.ExecQuery(sql, bedNO) == -1)
			{
				return null;
			}
			
			try
			{
				//循环读取数据
				while (this.Reader.Read())
				{
					bed = new Bed();

					bed.ID = this.Reader[0].ToString();
					bed.BedGrade.ID = this.Reader[1].ToString();
					bed.InpatientNO = this.Reader[2].ToString();				
				}//循环结束

				this.Reader.Close();
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				return null;
			}
			
			return bed;
		}
		
		/// <summary>
		/// 根据住院流水号获取床位等级
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <returns>成功: 床位等级信息数组, 失败 null, 没有找到数据:元素为0的ArrayList</returns>
		public ArrayList QueryBedGradeByInpatientNO(string inpatientNO)
		{
			ArrayList beds = new ArrayList(); //床位信息集合
			string sql = string.Empty; //根据住院流水号获得床位等级集合的SQL语句

			if (this.Sql.GetSql("Fee.BedFeeItem.GetBedGradeByInpatienNo", ref sql) == -1) 
			{				
				this.Err = "没有找到索引为:Fee.BedFeeItem.GetBedGradeByInpatienNo的SQL语句";

				return null;
			}			
			
			if(this.ExecQuery(sql, inpatientNO) == -1)
			{
				return null;
			}
			
			try
			{
				//循环读取数据
				while (this.Reader.Read())
				{
					Bed bed  = new Bed();

					bed.ID = this.Reader[0].ToString();
					bed.BedGrade.ID = this.Reader[1].ToString();
					bed.InpatientNO = this.Reader[2].ToString();				
					
					beds.Add(bed);
				}//循环结束

				this.Reader.Close();
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				beds = null;

				return null;
			}

			return beds;
		}

		/// <summary>
		/// 根据床位等级编码提取BedFeeItem信息
		/// </summary>
		/// <param name="minFeeCode">最小费用编码</param>
		/// <returns>成功: 床位信息数组, 失败 null, 没有找到数据:元素为0的ArrayList</returns>
		public ArrayList QueryBedFeeItemByMinFeeCode(string minFeeCode)
		{

			string sql = string.Empty; //查询SQL语句

			if (this.Sql.GetSql("Fee.BedFeeItem.SelectByFeeCode", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.BedFeeItem.SelectByFeeCode的SQL语句";

				return null;
			}

			if(this.ExecQuery(sql, minFeeCode) == -1)
			{
				return null;
			}
			
			try
			{
				ArrayList bedFeeItems = new ArrayList();
				
				//循环读取数据
				while (this.Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem = new Neusoft.HISFC.Models.Fee.BedFeeItem();

					bedFeeItem.PrimaryKey = this.Reader[0].ToString();
					bedFeeItem.FeeGradeCode = this.Reader[1].ToString();
					bedFeeItem.ID = this.Reader[2].ToString();
					bedFeeItem.Name = this.Reader[3].ToString();
					bedFeeItem.Qty = NConvert.ToDecimal(this.Reader[4].ToString());
					bedFeeItem.SortID = NConvert.ToInt32(this.Reader[5].ToString());
					bedFeeItem.IsBabyRelation = NConvert.ToBoolean(this.Reader[6].ToString());
					bedFeeItem.IsTimeRelation = NConvert.ToBoolean(this.Reader[7].ToString());
					bedFeeItem.BeginTime = NConvert.ToDateTime(this.Reader[8].ToString());
					bedFeeItem.EndTime = NConvert.ToDateTime(this.Reader[9].ToString());
					bedFeeItem.ValidState = (EnumValidState)NConvert.ToInt32(this.Reader[10]);
					bedFeeItem.ExtendFlag = this.Reader[13].ToString();

					bedFeeItems.Add(bedFeeItem);
				}
				
				this.Reader.Close();

				return bedFeeItems;
			}
			catch (Exception e)
			{
				this.Err = e.Message;

				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				return null;
			}
		}

		#endregion

		#region 废弃函数

		/// <summary>
		/// 根据床位等级编码提取BedFeeItem信息
		/// </summary>
		/// <param name="feeCode"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBedFeeItemByMinFeeCode()", true)]
		public ArrayList SelectByFeeCode(string feeCode)
		{

			string strSql = "";
			if (this.Sql.GetSql("Fee.BedFeeItem.SelectByFeeCode",ref strSql)==-1) return null;
			
			try
			{   				
				strSql = string.Format(strSql,feeCode);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}
			
			try
			{
				ArrayList List = new ArrayList();
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{

					Neusoft.HISFC.Models.Fee.BedFeeItem obj = new Neusoft.HISFC.Models.Fee.BedFeeItem();
					obj.ID = Reader[0].ToString();
					obj.FeeGradeCode = Reader[1].ToString();
					obj.ID = Reader[2].ToString();
					obj.Name = Reader[3].ToString();
                    obj.Qty = FrameWork.Function.NConvert.ToDecimal(Reader[4].ToString());

                    obj.SortID = FrameWork.Function.NConvert.ToInt32(Reader[5].ToString());
                    obj.IsBabyRelation = FrameWork.Function.NConvert.ToBoolean(Reader[6].ToString());
                    obj.IsTimeRelation = FrameWork.Function.NConvert.ToBoolean(Reader[7].ToString());
		
					obj.BeginTime = (DateTime)Reader[8];
					obj.EndTime = (DateTime)Reader[9];
						
					obj.ValidState = (EnumValidState)NConvert.ToInt32(Reader[10]);
					obj.ExtendFlag = Reader[13].ToString();

					List.Add(obj);
				}
				
				this.Reader.Close();

				return List;
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
		}

		/// <summary>
		/// 根据住院流水号获取床位等级
		/// </summary>
		/// <param name="InpatientNo">住院流水号</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBedGradeByInpatientNO()", true)]
		public ArrayList GetBedGradeByInpatientNo(string InpatientNo)
		{
			ArrayList ALLBedInfo = new ArrayList();
			string strSql = "";
			if (this.Sql.GetSql("Fee.BedFeeItem.GetBedGradeByInpatienNo",ref strSql)==-1) 
			{				
				return null;
			}			
			try
			{
				strSql = string.Format(strSql,InpatientNo);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}      	
			if(this.ExecQuery(strSql)==-1)return null;
			while(this.Reader.Read())
			{
				Neusoft.HISFC.Models.Base.Bed BedInfo  = new Neusoft.HISFC.Models.Base.Bed();
				BedInfo.ID=Reader[0].ToString();
				BedInfo.BedGrade.ID =Reader[1].ToString();
				BedInfo.InpatientNO =Reader[2].ToString();				
				ALLBedInfo.Add(BedInfo);
			}
			this.Reader.Close();
			return ALLBedInfo;

		}

		/// <summary>
		/// 根据床号号获取床位等级
		/// </summary>
		/// <param name="BedNo">床号</param>
		/// <returns></returns>
		[Obsolete("作废,使用GetBedGradeByBedNO()", true)]
		public Neusoft.HISFC.Models.Base.Bed GetBedGradeByBedNo(string BedNo)
		{
			Neusoft.HISFC.Models.Base.Bed BedInfo = null;
			string strSql = "";
			if (this.Sql.GetSql("Fee.BedFeeItem.GetBedGradeByBedNo",ref strSql)==-1) 
			{		
				this.Err = this.Sql.Err;
				return null;
			}			
			try
			{
				strSql = string.Format(strSql,BedNo);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}      	
			if(this.ExecQuery(strSql)==-1)return null;
			while(this.Reader.Read())
			{
				BedInfo  = new Neusoft.HISFC.Models.Base.Bed();
				BedInfo.ID=Reader[0].ToString();
				BedInfo.BedGrade.ID =Reader[1].ToString();
				BedInfo.InpatientNO =Reader[2].ToString();				
				
			}
			this.Reader.Close();
			return BedInfo;
		}

		/// <summary>
		/// 更新床位信息
		/// </summary>
		/// <param name="info">床位信息实体</param>
		/// <returns> -1 失败 > 1 成功</returns>
		[Obsolete("作废,使用UpdateBedFeeItem()", true)]
		public int Update(Neusoft.HISFC.Models.Fee.BedFeeItem info)
		{
		
			string strSql = "";
			if (this.Sql.GetSql("Fee.BedFeeItem.UpdateBedFeeItem",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql,info.ID,info.FeeGradeCode,info.ID,info.Name,info.Qty,
					
					info.SortID,
                    FrameWork.Function.NConvert.ToInt32(info.IsBabyRelation),
                    FrameWork.Function.NConvert.ToInt32(info.IsTimeRelation),
				
					info.BeginTime,info.EndTime,
					info.ValidState,
					this.Operator.ID);

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		[Obsolete("作废,使用InsertBedFeeItem()", true)]
		public int Insert(Neusoft.HISFC.Models.Fee.BedFeeItem info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.BedFeeItem.InsertBedFeeItem",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql, info.FeeGradeCode,info.ID,info.Name,info.Qty,
                    info.SortID, FrameWork.Function.NConvert.ToInt32(info.IsBabyRelation),
                    FrameWork.Function.NConvert.ToInt32(info.IsTimeRelation),
					
					info.BeginTime,info.EndTime,
					info.ValidState,this.Operator.ID);

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		[Obsolete("作废,使用DeleteByItemCode()", true)]
		public int Delete(BedFeeItem info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.BedFeeItem.DeleteBedFeeItem",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql, info.ID);

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}

		/// <summary>
		/// 查询是否被停用了。  0  在用 1 停用 2 废弃 其他的为错误
		/// </summary>
		/// <param name="ItemCode"></param>
		/// <returns></returns>
		[Obsolete("作废,使用ValidState()", true)]
		public string  IsDisuser(string  ItemCode)
		{
			string ISDisuser = "";
			try
			{
				string strSql = "";
				if (this.Sql.GetSql("Fee.BedFeeItem.IsDisuser",ref strSql)==-1) return this.Sql.Err;
				strSql = string.Format(strSql,ItemCode);
				this.ExecQuery(strSql);
				this.Reader.Read();
				ISDisuser = Reader[0].ToString();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				ISDisuser=ee.Message;
			}
			return ISDisuser;
		}

		#endregion
	}
}
