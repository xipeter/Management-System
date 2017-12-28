using System;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Fee;
using System.Data;
using System.Collections.Generic;

namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// InvoiceService<br></br>
	/// [功能描述: 发票信息业务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-10-01]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// {C81461BC-CAFE-4df0-837F-D8F759F6D7BF}
    [Obsolete("废弃由InvoiceServiceNoEnum类代替", true)]
	public class InvoiceService	: Neusoft.FrameWork.Management.Database
	{

		#region 私有方法

		/// <summary>
		/// 检索发票信息
		/// </summary>
		/// <param name="sql">执行的查询SQL语句</param>
		/// <param name="args">SQL语句的参数</param>
		/// <returns>成功:发票信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		private ArrayList QueryInvoicesBySql(string sql, params string[] args)
		{
			ArrayList invoices = new ArrayList();
			
			//执行SQL语句
			if (this.ExecQuery(sql, args) == -1)
			{
				return null;
			}

			try
			{
				//循环读取数据
				while (this.Reader.Read())
				{
					Invoice invoice = new Invoice();
					
					invoice.AcceptTime = NConvert.ToDateTime(this.Reader[0].ToString());
					invoice.Type.ID = this.Reader[1].ToString();
					invoice.AcceptOper.ID = this.Reader[2].ToString();
					invoice.BeginNO = this.Reader[3].ToString();
					invoice.EndNO =this.Reader[4].ToString();
					invoice.UsedNO =this.Reader[5].ToString();
					invoice.ValidState = this.Reader[6].ToString();
					invoice.IsPublic = NConvert.ToBoolean(this.Reader[7].ToString());
					invoice.AcceptOper.Name = this.Reader[8].ToString();
					
					invoices.Add(invoice);
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

			return invoices;
		}

		/// <summary>
		/// 获得update或者insert退费申请的传入参数数组
		/// </summary>
		/// <param name="invoice">发票实体类</param>
		/// <returns>参数数组</returns>
		private string[] GetInvoiceParams(Invoice invoice) 
		{
			string[] args =
				{
					invoice.AcceptTime.ToString(),
					invoice.AcceptOper.ID,
					invoice.Type.ID.ToString(),
					invoice.Type.Name,
					invoice.BeginNO,
					invoice.EndNO,
					invoice.UsedNO,
					invoice.ValidState.ToString(),
					NConvert.ToInt32(invoice.IsPublic).ToString(),
					this.Operator.ID,
					this.GetSysDateTime()
				};
								 
			return args;
		}

		/// <summary>
		/// 检索获得发票的人员信息
		/// </summary>
		/// <param name="sql">执行的查询SQL语句</param>
		/// <param name="args">SQL语句的参数</param>
		/// <returns>成功:人员信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		private ArrayList QueryPersonsBySql(string sql, params string[] args)
		{
			ArrayList persons = new ArrayList();

			//执行SQL语句
			if (this.ExecQuery(sql, args) == -1)
			{
				return null;
			}
			
			try
			{
				//循环读取数据
				while (this.Reader.Read())
				{
					Neusoft.HISFC.Models.Base.Employee person = new Neusoft.HISFC.Models.Base.Employee();
				
					person.ID = this.Reader[0].ToString();
					person.Name = this.Reader[1].ToString();
					person.SpellCode = this.Reader[2].ToString();
					person.WBCode = this.Reader[3].ToString();				
					person.Sex.ID = this.Reader[4].ToString();
					person.Birthday = this.Reader.GetDateTime(5);
					person.Duty.ID = this.Reader[6].ToString();
					person.Level.ID = this.Reader[7].ToString();
					person.GraduateSchool.ID = this.Reader[8].ToString();
					person.IDCard = this.Reader[9].ToString();
					person.Dept.ID = this.Reader[10].ToString();
					person.Nurse.ID = this.Reader[11].ToString();
					person.EmployeeType.ID = Reader[12].ToString();
					person.IsExpert = NConvert.ToBoolean(Reader[13].ToString());
					person.IsCanModify = NConvert.ToBoolean(Reader[14].ToString());
					person.IsNoRegCanCharge = NConvert.ToBoolean(this.Reader[15].ToString());
					person.ValidState = (HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[16].ToString());
					person.SortID = NConvert.ToInt32(this.Reader[17].ToString());
				
					persons.Add(person);
				}//循环结束

				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();
				
				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				return null;
			}
			
			return persons;
		}

        /// <summary>
        /// 获得发票变更参数数组
        /// </summary>
        /// <param name="invoiceChange"></param>
        /// <returns></returns>
        private string[] GetInvoiceChangeParms(InvoiceChange invoiceChange)
        {
            string[] args =
				{
					invoiceChange.HappenNO.ToString(),
					invoiceChange.GetOper.ID,
					invoiceChange.InvoiceType.ID.ToString(),
                    invoiceChange.InvoiceType.Name,
					
					invoiceChange.BeginNO,
					invoiceChange.EndNO,
					invoiceChange.ShiftType,
					invoiceChange.Oper.ID,
                    invoiceChange.Memo.ToString()
				};

            return args;
        }

		#endregion

		#region 公有方法

		/// <summary>
		/// 通过发票类型,查询发票信息
		/// </summary>
		/// <param name="invoiceType">发票类别</param>
		/// <returns>成功:发票信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryInvoices(InvoiceTypeEnumService invoiceType)
		{
			string sql = string.Empty; //查询SQL语句

			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.2",ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.SelectInvoices.2的SQL语句";

				return null;
			}

			return this.QueryInvoicesBySql(sql, invoiceType.ID.ToString());
		}

		/// <summary>
		///  根据是否是Groupy以及发票类别获得所有使用状态的发票信息。
		/// </summary>
		/// <param name="invoiceType">发票类别</param>
		/// <param name="isGroup">是否发票组</param>
		/// <returns>成功:发票信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryInvoices(InvoiceTypeEnumService invoiceType, bool isGroup)
		{
			
			string sql = string.Empty; //查询SQL语句

			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.ByTypeIsGroup",ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.SelectInvoices.ByTypeIsGroup的SQL语句";

				return null;
			}

			return this.QueryInvoicesBySql(sql, invoiceType.ID.ToString(), NConvert.ToInt32(isGroup).ToString());
		}

		/// <summary>
		/// 获得领用过发票类型为InvoiceType的所有人员信息 /
		/// </summary>
		/// <param name="invoiceType">发票类别</param>
		/// <returns>成功:人员信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryPersonsByInvoiceType(InvoiceTypeEnumService invoiceType)
		{
			
			string sql = string.Empty; //查询SQL语句

			if (this.Sql.GetSql("Fee.InvoiceService.GetPersonByInvoiceType",ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.GetPersonByInvoiceType的SQL语句";

				return null;
			}

			return this.QueryPersonsBySql(sql, invoiceType.ID.ToString());
		}

		/// <summary>
		/// 通过人员编号,和发票类别查询该人员的发票信息
		/// </summary>
		/// <param name="personID">人员编号</param>
		/// <param name="invoiceType">发票类别</param>
		/// <returns>成功:发票信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryInvoices(string personID, InvoiceTypeEnumService invoiceType)
		{
			string sql = string.Empty; //查询SQL语句

			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.1",ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.SelectInvoices.1的SQL语句";

				return null;
			}

			return this.QueryInvoicesBySql(sql, personID, invoiceType.ID.ToString());	
		}
		
		/// <summary>
		/// 通过人员编号,和发票类别查询和是否财务组该人员的发票信息
		/// </summary>
		/// <param name="personID">人员编号</param>
		/// <param name="invoiceType">发票类别</param>
		/// <param name="isGroup">是否财务组</param>
		/// <returns>成功:发票信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryInvoices(string personID, InvoiceTypeEnumService invoiceType, bool isGroup)
		{
			string sql = string.Empty; //查询SQL语句

			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.ByIdTypeIsGroup",ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.SelectInvoices.ByIdTypeIsGroup的SQL语句";

				return null;
			}

			return this.QueryInvoicesBySql(sql, personID, invoiceType.ID.ToString(), NConvert.ToInt32(isGroup).ToString().ToString());	
		}

		/// <summary>
		/// 根据发票类型得到当前可用的起始号(默认)
		/// </summary>
		/// <param name="invoiceType">发票类型</param>
		/// <returns>可用起始号</returns>
		public string GetDefaultStartCode(InvoiceTypeEnumService invoiceType)
		{
			string sql = string.Empty;//查询SQL语句
			string startNO = string.Empty;//起始号

			if (this.Sql.GetSql("Fee.InvoiceService.GetDefaultStartCode.1", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.GetDefaultStartCode.1的SQL语句";

				return null;
			}

			try
			{
				sql = string.Format(sql, invoiceType.ID);
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return null;
			}

			startNO = this.ExecSqlReturnOne(sql);
			
			//如果起始号为空,那么默认为"000000000001"
			if (startNO == null || startNO == string.Empty)
			{
				startNO = "000000000001";
			}
			else//否则,为当前号+1
			{
				startNO = (Convert.ToInt64(startNO) + 1).ToString().PadLeft(12,'0');
			}

			return startNO;
		}
		
		/// <summary>
		/// 检测所给的起始号和发票数量是否有效：
		/// </summary>
		/// <param name="startNO">起始号</param>
		/// <param name="endNO">发票数量</param>
		/// <param name="invoiceType">发票类型</param>
		/// <returns>有效true, 无效 false</returns>
		public bool InvoicesIsValid(long startNO, long endNO, InvoiceTypeEnumService invoiceType)
		{
			
			if (endNO < startNO)
			{
				this.Err="输入的终止号大于起始号!";

				return false;
			}

			string sql = string.Empty;

			ArrayList invoices = new ArrayList();

			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.2", ref sql) == -1) 
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.SelectInvoices.2的SQL语句";
		
				return false;
			}

			invoices= QueryInvoicesBySql(sql, invoiceType.ID.ToString());
			
			//如果没有符合条件的发票,说明可以生成
			if (invoices == null)
			{
				return true;
			}
			
			for (int i = 0; i < invoices.Count; i++)
			{
				Invoice invoice = invoices[i] as Invoice;
				 
				if (Convert.ToInt64(invoice.BeginNO) <= startNO && startNO <= Convert.ToInt64(invoice.EndNO))
				{
					return false;
				}
				if (Convert.ToInt64(invoice.BeginNO) <= endNO && endNO <= Convert.ToInt64(invoice.EndNO))
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 插入一条发票信息.
		/// </summary>
		/// <param name="invoice">发票信息类</param>
		/// <returns> 成功: 1 失败: -1 没有插入记录: 0</returns>
		public int InsertInvoice(Invoice invoice)
		{
			string sql = string.Empty;//插入SQL语句

			if (this.Sql.GetSql("Fee.InvoiceService.InsertInvoice.1", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvoiceService.InsertInvoice.1的SQL语句";
				
				return -1;
			}
		
			return this.ExecNoQuery(sql, this.GetInvoiceParams(invoice));
		}
		
		/// <summary>
		/// 更新一条发票信息.发票回收专用
		/// </summary>
		/// <param name="invoice">发票信息类</param>
		/// <returns> 成功: 1 失败: -1 没有更新记录: 0</returns>
		public int UpdateInvoice(Invoice invoice)
		{
			string sql = string.Empty;//插入SQL语句

			if (this.Sql.GetSql("Fee.InvocieService.UpdateInvoice.1", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvocieService.UpdateInvoice.1的SQL语句";
				
				return -1;
			}
		
			return this.ExecNoQuery(sql, this.GetInvoiceParams(invoice));
		}

		/// <summary>
		/// 删除一条记录
		/// </summary>
		/// <param name="invoice">发票信息类</param>
		/// <returns>成功: 删除的条目 失败: -1 没有删除记录: 0</returns>
		public int Delete(Invoice invoice)
		{
			string sql = string.Empty;//插入SQL语句

			if (this.Sql.GetSql("Fee.InvocieService.DeleteInvoice.1", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.InvocieService.DeleteInvoice.1的SQL语句";
				
				return -1;
			}
		
			return this.ExecNoQuery(sql, invoice.AcceptTime.ToString(), invoice.AcceptOper.ID);
        }

        #region 发票变更

        /// <summary>
        /// 插入发票变更记录
        /// </summary>
        /// <param name="invoiceChange"></param>
        /// <returns></returns>
        public int InsertInvoiceChange(InvoiceChange invoiceChange)
        {
            string sql = string.Empty;//插入SQL语句

            if (this.Sql.GetSql("Fee.InvoiceService.InsertInvoiceChange.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.InvoiceService.InsertInvoiceChange.1的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, this.GetInvoiceChangeParms(invoiceChange));
        }

        /// <summary>
        /// 按发票领取人取得发票变更序号
        /// </summary>
        /// <param name="getPersonID"></param>
        /// <returns></returns>
        public int GetInvoiceChangeHappenNO(string getPersonID)
        {
            string sql = string.Empty;
            string happenNO = string.Empty;

            if (this.Sql.GetSql("Fee.InvoiceService.GetInvoiceChangeHappenNO.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.InvoiceService.GetInvoiceChangeHappenNO.1的SQL语句";

                return -1;
            }

            try
            {
                sql = string.Format(sql, getPersonID);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return -1;
            }
            happenNO = this.ExecSqlReturnOne(sql);

            if (happenNO == null || happenNO == string.Empty)
            {
                return 1;
            }
            else//否则,为当前号+1
            {
                return (Convert.ToInt32(happenNO) + 1);
            }
        }

        /// <summary>
        /// 更新发票已用号码（发票跳号用）
        /// </summary>
        /// <param name="usedNO"></param>
        /// <param name="getPersonID"></param>
        /// <param name="getDate"></param>
        /// <returns></returns>
        public int UpdateInvoiceUsedNO(string usedNO, string getPersonID, DateTime getDate)
        {
            string sql = string.Empty;//插入SQL语句

            if (this.Sql.GetSql("Fee.InvoiceService.UpdateInvoice.2", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.InvoiceService.UpdateInvoice.2的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, getDate.ToString("yyyy-MM-dd HH:mm:ss"), getPersonID, usedNO);
        }

        #endregion

        #region 发票核销
        /// <summary>
        /// 获取门诊发票
        /// </summary>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="casher">收款员</param>
        ///<param name="list"></param>
        /// <returns></returns>
        public int GetOutpatientFeeInvoice(string begin, string end,string  casher, ref List<Neusoft.FrameWork.Models.NeuObject> list)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Fee.CheckInvoice.GetOutpatientInvoice", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句Fee.CheckInvoice.GetOutpatientInvoice失败！";
                return -1;
            }
            try
            {
                sqlStr = string.Format(sqlStr, begin, end,casher);
                if (this.ExecQuery(sqlStr) == -1)
                {
                    this.Err = "查找门诊发票数据失败！";
                    return -1;
                }
                Neusoft.FrameWork.Models.NeuObject obj = null;
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();
                    obj.User01 = this.Reader[2].ToString();
                    obj.User02 = this.Reader[3].ToString();
                    obj.User03 = this.Reader[4].ToString();
                    obj.Memo = this.Reader[5].ToString();
                    list.Add(obj);
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

        }

        /// <summary>
        /// 获取住院发票数据
        /// </summary>
        /// <param name="begin">开始时间</param>
        /// <param name="end">终止时间</param>
        /// <param name="casher">收款员</param>
        /// <param name="list"></param>
        /// <returns></returns>
        public int GetInpatientFeeInvoice(string begin, string end,string  casher, ref List<Neusoft.FrameWork.Models.NeuObject> list)
        { 
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Fee.CheckInvoice.GetInpatientInvoice", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句Fee.CheckInvoice.GetOutpatientInvoice失败！";
                return -1;
            }
            try
            {
                sqlStr = string.Format(sqlStr, begin, end,casher);
                if (this.ExecQuery(sqlStr) == -1)
                {
                    this.Err = "查找住院发票数据失败！";
                    return -1;
                }
                Neusoft.FrameWork.Models.NeuObject obj = null;
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();
                    obj.User01 = this.Reader[2].ToString();
                    obj.Memo = this.Reader[3].ToString();
                    list.Add(obj);
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

        }

        /// <summary>
        /// 核销门诊发票数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="operTime">操作时间</param>
        /// <param name="oper">操作人</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public int SaveCheckOutPatientFeeInvoice(Neusoft.FrameWork.Models.NeuObject obj, string operTime, string oper,string begin,string end)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Fee.CheckInvoice.SaveOutpatientInvoice", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句Fee.CheckInvoice.SaveOutpatientInvoice失败！";
                return -1;
            }
            try
            {
                sqlStr = string.Format(sqlStr, obj.ID,//发票号
                                            obj.User02,//seq
                                            oper,//操作人
                                            operTime,//操作时间
                                            begin,//开始时间
                                            end);//结束时间
                
            }
            catch(Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(sqlStr);
        }

        /// <summary>
        /// 核销住院发票数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="operTime">操作时间</param>
        /// <param name="oper">操作人</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public int SaveCheckInpatientFeeInvoice(Neusoft.FrameWork.Models.NeuObject obj, string operTime, string oper,string begin,string end)
        { 
             string sqlStr = string.Empty;
             if (this.Sql.GetSql("Fee.CheckInvoice.SaveInpatientInvoice", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句Fee.CheckInvoice.SaveOutpatientInvoice失败！";
                return -1;
            }
            try
            {
                sqlStr = string.Format(sqlStr, obj.ID,//发票号
                                            oper,//操作人
                                            operTime,//操作时间
                                            begin,//开始时间
                                            end);//结束时间
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(sqlStr);
        }
        #endregion

        #endregion


        #region 废弃方法

        /// <summary>
		/// 
		/// </summary>
		/// <param name="invoiceType"></param>
		/// <returns></returns>
		[Obsolete("作废,QueryInvoices()", true)]
		public ArrayList SelectInvoices(InvoiceTypeEnumService invoiceType)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.2",ref strSql)==-1) return null;
			try
			{
				//0领取时间1发票种类2领取人3发票开始号4发票终止号5发票已用号
				//6 used_state7公用标志
				string typeid =invoiceType.ToString();
				strSql = string.Format(strSql,typeid);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}
			return QueryInvoicesBySql(strSql);
		}

		/// <summary>
		///  根据是否是Group获得所有使用状态的发票信息。
		/// </summary>
		/// <param name="invoiceType"></param>
		/// <param name="isGroup"></param>
		/// <returns></returns>
		[Obsolete("作废,QueryInvoices()", true)]
		public ArrayList SelectInvoicesByGroup(InvoiceTypeEnumService invoiceType,bool isGroup)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.ByTypeIsGroup",ref strSql)==-1) return null;
			try
			{
				//0领取时间1发票种类2领取人3发票开始号4发票终止号5发票已用号
				//6 used_state7公用标志
				string typeid =invoiceType.ID.ToString();
				strSql = string.Format(strSql,typeid,isGroup == true ? 1 : 0);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}
			return QueryInvoicesBySql(strSql);
		}

		/// <summary>
		/// 获得领用过发票类型为InvoiceType的所有人员信息 /
		/// </summary>
		/// <param name="invoiceType"></param>
		/// <returns></returns>
		[Obsolete("作废,QueryPersonsByInvoiceType()", true)]
		public ArrayList GetPersonByInvoiceType(string invoiceType)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.InvoiceService.GetPersonByInvoiceType",ref strSql)==-1) return null;
			try
			{
				//0领取时间1发票种类2领取人3发票开始号4发票终止号5发票已用号
				//6 used_state7公用标志
				
				strSql = string.Format(strSql,invoiceType);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}

			return QueryPersonsBySql(strSql);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="personID"></param>
		/// <param name="invoiceType"></param>
		/// <returns></returns>
		[Obsolete("作废,QueryInvoices()", true)]
		public ArrayList SelectInvoices(string personID,EnumInvoiceType invoiceType)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.1",ref strSql)==-1) return null;
			try
			{
				//0领取时间1发票种类2领取人3发票开始号4发票终止号5发票已用号
				//6 used_state7公用标志
				string typeid =invoiceType.ToString();
				strSql = string.Format(strSql,personID,typeid);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}
			return QueryInvoicesBySql(strSql);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="personID"></param>
		/// <param name="invoiceType"></param>
		/// <param name="isGroup"></param>
		/// <returns></returns>
		[Obsolete("作废,QueryInvoices()", true)]
		public ArrayList SelectInvoices(string personID,EnumInvoiceType invoiceType,bool isGroup)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.ByIdTypeIsGroup",ref strSql)==-1) return null;
			try
			{
				//0领取时间1发票种类2领取人3发票开始号4发票终止号5发票已用号
				//6 used_state7公用标志
				string typeid =invoiceType.ToString();
				strSql = string.Format(strSql,personID,typeid,isGroup == true ? 1 : 0);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}
			return QueryInvoicesBySql(strSql);
			
			
		}
		/// <summary>
		/// 检测是否可以生成发票号。 
		///		----检测所给的起始号和发票数量是否有效：
		/// </summary>
		/// <param name="startcode">起始号</param>
		/// <param name="endcode">发票数量</param>
		/// <param name="invoiceType">发票类型</param>
		/// <returns></returns>
		[Obsolete("作废,InvoicesIsValid()", true)]
		public bool CheckCodeValid(long startcode, long endcode,Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService invoiceType)
		{
			
			if (endcode<startcode)
			{
				this.Err="输入的终止号大于起始号!";
				return false;
			}
			string strSql = "";
			ArrayList al = new ArrayList();
			if (this.Sql.GetSql("Fee.InvoiceService.SelectInvoices.2",ref strSql)==-1) 
			{
				this.Err="获取sql出错!";
				this.ErrCode="获取sql出错!";
				return false;
			}
			try
			{
				//0领取时间1发票种类2领取人3发票开始号4发票终止号5发票已用号
				//6 used_state7公用标志
				strSql = string.Format(strSql,invoiceType.ID.ToString());
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return false;
			}
			al= QueryInvoicesBySql(strSql);
			if (al==null) return true;
			for(int i=0;i < al.Count;i++)
			{
				Neusoft.HISFC.Models.Fee.Invoice obj;
				obj = (Neusoft.HISFC.Models.Fee.Invoice)al[i];
				if ((long.Parse(obj.BeginNO)<=startcode)&&(startcode<=long.Parse(obj.EndNO)))return false;
				if ((long.Parse(obj.BeginNO)<=endcode)&&(endcode<=long.Parse(obj.EndNO)))return false;
			}
			return true;
		}

		#endregion       

	}
}
