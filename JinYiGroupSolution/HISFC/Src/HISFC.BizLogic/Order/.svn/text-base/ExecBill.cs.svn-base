using System;
using Neusoft.HISFC.Models;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.Order
{
	/// <summary>
	/// ExecBill 的摘要说明。
	/// 执行单设置管理类
	/// </summary>
	public class ExecBill:Neusoft.FrameWork.Management.Database 
	{
		public ExecBill()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 增删改
		/// <summary>
		/// 插入执行单信息
		/// 必须填写（objBill.ID 执行单流水号，objBill.Name 执行单名,objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型,
		/// objBill.user02非药系统类别、药品类别,objBill.user03 药品用法）
		/// </summary>
		/// <param name="objBill"></param>
		/// <param name="nurseCode"></param>
		/// <returns></returns>
		private int InsertExecBill( Neusoft.FrameWork.Models.NeuObject objBill, string nurseCode )
		{
			string strSql = "";
			#region "接口"
			//传入：0 病区编码 ，1执行单流水号 2 执行单名称 3 医嘱类型 4非药系统类别、药品类别 5 药品用法６操作员
			//传出：0
			#endregion

			if (objBill.Memo == "1") //药品
			{
				if (this.Sql.GetSql("Order.ExecBill.InsertItem.1",ref strSql) == -1) 
				{
					this.Err = this.Sql.Err;
					return -1;
				}
			}
			else if (objBill.Memo == "2")//非药品
			{
				if (this.Sql.GetSql("Order.ExecBill.InsertItem.2",ref strSql) == -1)
				{
					this.Err = this.Sql.Err;
					return -1;
				}
			}
			
			try
			{
				strSql = string.Format(strSql,nurseCode,objBill.ID,objBill.Name,objBill.User01,objBill.User02,objBill.User03,this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql) ;

        }

        #region addby xuewj 2009-8-26 执行单管理 单项目维护 {0BB98097-E0BE-4e8c-A619-8B4BCA715001}

        /// <summary>
        /// 更新非药品项目执行单（全部）
        /// </summary>
        /// <param name="nurseID">护士站</param>
        /// <param name="billNO">执行单号</param>
        /// <param name="typeCode">医嘱类型</param>
        /// <param name="classCode">医嘱项目类型</param>
        /// <returns></returns>
        public int UpdateExecBillAllItem(string nurseID, string billNO, string typeCode, string classCode)
        {
            if (this.DeleteExecBillAllItem(nurseID, typeCode, classCode) == -1)
            {
                return -1;
            }

            if (this.InsertExecBillAllItem(nurseID, billNO, typeCode, classCode) == -1)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 删除非药品项目执行单（全部）
        /// </summary>
        /// <param name="nurseID">护士站</param>
        /// <param name="billNO">执行单号</param>
        /// <param name="typeCode">医嘱类型</param>
        /// <param name="classCode">医嘱项目类型</param>
        /// <returns></returns>
        private int DeleteExecBillAllItem(string nurseID, string typeCode, string classCode)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.ExecBill.DeleteAllItem", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                sql = string.Format(sql, nurseID, typeCode, classCode);
            }
            catch (Exception err)
            {
                this.Err = err.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 增加非药品项目执行单（全部）
        /// </summary>
        /// <param name="nurseID">护士站编码</param>
        /// <param name="billNO">执行单编码</param>
        /// <param name="typeCode">医嘱类型</param>
        /// <param name="classCode">医嘱项目类型</param>
        /// <returns></returns>
        private int InsertExecBillAllItem(string nurseID, string billNO, string typeCode, string classCode)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.ExecBill.InsertAllItem", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                sql = string.Format(sql, nurseID, billNO, typeCode, classCode, Operator.ID);
            }
            catch (Exception err)
            {
                this.Err = err.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 增加非药品项目执行单（剩余全部）
        /// </summary>
        /// <param name="nurseID">护士站编码</param>
        /// <param name="billNO">执行单编码</param>
        /// <param name="typeCode">医嘱类型</param>
        /// <param name="classCode">医嘱项目类型</param>
        /// <returns></returns>
        public int InsertExecBillOtherItem(string nurseID, string billNO, string typeCode, string classCode)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.ExecBill.InsertOtherItem", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                sql = string.Format(sql, nurseID, billNO, typeCode, classCode, Operator.ID);
            }
            catch (Exception err)
            {
                this.Err = err.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 更新非药品项目执行单（单个）
        /// </summary>
        /// <param name="nurseID">护士站编码</param>
        /// <param name="billNO">执行单</param>
        /// <param name="orderType">医嘱类型</param>
        /// <param name="sysClass">医嘱项目类型</param>
        /// <param name="itemCode">项目编码</param>
        /// <param name="itemName">项目名称</param>
        /// <returns></returns>
        public int UpdateExecBillItem(string nurseID, string billNO, string orderType, string sysClass, string itemCode, string itemName)
        {
            if (this.DeleteExecBillItem(nurseID, billNO, orderType, sysClass, itemCode) == -1)
            {
                return -1;
            }
            if (this.InsertExecBillItem(nurseID, billNO, orderType, sysClass, itemCode, itemName) == -1)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 删除非药品项目执行单（单个）
        /// </summary>
        /// <param name="nurseID">护士站编码</param>
        /// <param name="billNO">执行单编码</param>
        /// <param name="orderType">医嘱类型</param>
        /// <param name="sysClass">医嘱项目类型</param>
        /// <param name="itemCode">项目编码</param>
        /// <param name="itemName">项目名称</param>
        /// <returns></returns>
        private int DeleteExecBillItem(string nurseID, string billNO, string orderType, string sysClass, string itemCode)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.ExecBill.DeleteOneItem", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                sql = string.Format(sql, nurseID, billNO, orderType, sysClass, itemCode);
            }
            catch (Exception err)
            {
                this.Err = err.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 插入非药品项目执行单（单个）
        /// </summary>
        /// <param name="nurseID">护士站编码</param>
        /// <param name="billNO">执行单</param>
        /// <param name="orderType">医嘱类型</param>
        /// <param name="sysClass">医嘱项目类型</param>
        /// <param name="itemCode">项目编码</param>
        /// <param name="itemName">项目名称</param>
        /// <returns></returns>
        private int InsertExecBillItem(string nurseID, string billNO, string orderType, string sysClass, string itemCode, string itemName)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.ExecBill.InsertOneItem", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                sql = string.Format(sql, nurseID, billNO, orderType, sysClass, this.Operator.ID, itemCode, itemName);
            }
            catch (Exception err)
            {
                this.Err = err.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 插入新执行单
        /// 必须填写（objBill.Name 执行单名,objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型
        /// objBill.user02非药系统类别、药品类别 objBill.user03 药品用法）
        /// </summary>
        /// <param name="al"></param>
        /// <param name="nurseCode"></param>
        /// <returns></returns>
        public int SetExecBill(Neusoft.FrameWork.Models.NeuObject objExecBill, string nurseCode)
        {
            string strBillNo = GetNewExecBillID();
            if (strBillNo == "-1" || strBillNo == "")
            {
                return -1;
            }
            objExecBill.ID = strBillNo;

            string strSql = "";

            if (this.Sql.GetSql("Order.ExecBill.InsertItem", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, nurseCode, strBillNo, objExecBill.Name, this.Operator.ID, objExecBill.User02, objExecBill.User01, objExecBill.Memo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return -1;
            }
            if (this.ExecNoQuery(strSql) < 0) return -1;

            return 0;
        }

        /// <summary>
        /// 执行单设置（批量导入用）
        /// 必须填写（objBill.Name 执行单名,objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型
        /// objBill.user02非药系统类别、药品类别 objBill.user03 药品用法）
        /// </summary>
        /// <param name="al"></param>
        /// <param name="nurseCode"></param>
        /// <returns></returns>
        public int SetExecBillNew(ArrayList al, Neusoft.FrameWork.Models.NeuObject objExecBill, string nurseCode, ref string billID)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();
            Neusoft.FrameWork.Models.NeuObject objExecInfo = objExecBill.Clone();
            if (al.Count == 0)
            {
                this.Err = Neusoft.FrameWork.Management.Language.Msg("没有维护详细项目!");
                return -1;
            }

            if (this.SetExecBill(objExecInfo, nurseCode) == -1)
            {
                this.Err = Neusoft.FrameWork.Management.Language.Msg("执行单设置失败！") + this.Err;
                return -1;
            }

            if (objExecInfo.Memo == "1")
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order  orderInfo= (Neusoft.HISFC.Models.Order.Inpatient.Order)al[i];
                    orderInfo.ID = objExecInfo.ID;
                    if (orderInfo.ID == "-1" || orderInfo.ID == "") return -1;
                    if (this.InsertExecBillItem(nurseCode, objExecInfo.ID, orderInfo.OrderType.ID, orderInfo.Item.SysClass.ID.ToString(), orderInfo.Item.ID, orderInfo.Item.Name) < 0)
                    {
                        this.Err = Neusoft.FrameWork.Management.Language.Msg("执行单设置失败！") + this.Err;
                        return -1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order orderInfo = (Neusoft.HISFC.Models.Order.Inpatient.Order)al[i];
                    obj.ID = objExecInfo.ID;
                    obj.User02 = orderInfo.Item.User01;
                    obj.User01 = orderInfo.OrderType.ID;
                    obj.User03 = orderInfo.Usage.ID;
                    obj.Memo = "1";
                    if (obj.ID == "-1" || obj.ID == "") return -1;
                    if (InsertExecBill(obj, nurseCode) < 0)
                    {
                        this.Err = Neusoft.FrameWork.Management.Language.Msg("执行单设置失败！") + this.Err;
                        return -1;
                    }
                }
            }
            billID = objExecInfo.ID;

            return 0;
        }		

        #endregion

        /// <summary>
		/// 更新执行内容
		///必须填写（objBill.ID 执行单流水号，objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型,
		/// objBill.user02非药系统类别、药品类别,objBill.user03 药品用法）
		/// </summary>
		/// <param name="objBill"></param>
		/// <param name="nurseCode"></param>
		/// <returns></returns>
		public int UpdateExecBill(Neusoft.FrameWork.Models.NeuObject objBill,string nurseCode)
		{
			if (DeleteExecBill(objBill) < 0 ) return -1;
			if (InsertExecBill(objBill,nurseCode) <= 0 ) return -1;
			return 0;
		}
		/// <summary>
		/// 删除执行单
		/// </summary>
		/// <param name="billNo"></param>
		/// <returns></returns>
		public int DeleteExecBill(string billNo)
		{
			string strSql = "";
			#region 删除主档
			if (this.Sql.GetSql("Order.ExecBill.DeleteItem",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,billNo);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql) <= 0) return -1;
			#endregion
			#region 删除细档
			if (this.Sql.GetSql("Order.ExecBill.DeleteItem.Drug",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,billNo);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<0) return -1;
			if (this.Sql.GetSql("Order.ExecBill.DeleteItem.unDrug",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,billNo);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql) < 0) return -1;
			#endregion
			return 0;
		}

        #region {46983F5B-E184-4b8b-B819-AA1C34993F1B}
        /// <summary>
        /// 删除执行单内容其中的一个项目
        /// 必须填写（objBill.ID 执行单流水号，objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型,
        /// objBill.user02非药系统类别、药品类别,objBill.user03 药品用法）
        /// </summary>
        /// <param name="objBill"></param>
        /// <returns></returns>
        public int DeleteExecBillOneItem(Neusoft.FrameWork.Models.NeuObject objBill)
        {
            string strSql = "";
            #region "接口"
            //传入：0 执行单流水号 1医嘱类型 2非药系统类别、药品类别 3药品用法
            //传出：0
            #endregion

            if (this.Sql.GetSql("Order.ExecBill.DeleteItem.OneItem", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, objBill.ID, objBill.User01, objBill.User02, objBill.User03);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);

        }
        #endregion

		#endregion

		#region 作废
		[Obsolete("用SetExecBill代替了吧",true)]
		public int CreatExecBill(ArrayList al,Neusoft.FrameWork.Models.NeuObject objExecBill,string NurseCode,ref string BillID)
		{
			
			return 0;
		}
		
		#endregion

		#region 共有
		/// <summary>
		/// 执行单设置
		/// 必须填写（objBill.Name 执行单名,objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型
		/// objBill.user02非药系统类别、药品类别 objBill.user03 药品用法）
		/// </summary>
		/// <param name="al"></param>
		/// <param name="nurseCode"></param>
		/// <returns></returns>
		public int SetExecBill(ArrayList al,Neusoft.FrameWork.Models.NeuObject objExecBill,string nurseCode,ref string billID)
		{
			string strSql = "";
			string strBillNo = "";
			Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();
			if(al.Count ==0) 
			{
                this.Err = Neusoft.FrameWork.Management.Language.Msg("没有维护详细项目!");
				return -1;
			}
			strBillNo = GetNewExecBillID();

			if (strBillNo == "-1" || strBillNo == "") return -1;
			if (this.Sql.GetSql("Order.ExecBill.InsertItem",ref strSql) == -1)
			{
				this.Err  = this.Sql.Err;
				return -1;
			}
			try
			{
					strSql = string.Format(strSql,nurseCode,strBillNo,objExecBill.Name,this.Operator.ID,objExecBill.User02,objExecBill.User01);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			if ( this.ExecNoQuery(strSql) < 0 ) return -1;

			for (int i=0;i< al.Count;i++)
			{
				obj = (Neusoft.FrameWork.Models.NeuObject)al[i];
				obj.ID = strBillNo;
				if (obj.ID == "-1" || obj.ID =="") return -1;
				if (InsertExecBill(obj, nurseCode) < 0 ) 
				{
                    this.Err = Neusoft.FrameWork.Management.Language.Msg("执行单设置失败！") + this.Err;
					return -1;
				}
			}
			billID = strBillNo;

			return 0;
		}
		
		/// <summary>
		/// 获得执行单流水号
		/// </summary>
		/// <returns></returns>
		public string GetNewExecBillID()
		{
			string sql = "";
			if(this.Sql.GetSql("Management.ExecBill.GetNewExecBillID",ref sql)==-1) return null;
			string strReturn = this.ExecSqlReturnOne(sql);
			if(strReturn=="-1" || strReturn =="") return null;
			return strReturn;
		}
		/// <summary>
		/// 从com_dirctionary表里取得项目信息
		/// </summary>
		/// <param name="itemType"></param>
		/// <returns></returns>
		public ArrayList GetItemInfo(string itemType) {
			string strSql = "";
			ArrayList alItem = new ArrayList();
			if(this.Sql.GetSql("Management.ExecBill.GetItemInfo",ref strSql) == -1) {
			    this.Err = this.Sql.Err;
				return null;
			}
			strSql = System.String.Format(strSql,itemType);
			if(this.ExecQuery(strSql) == -1) return null;

			while(this.Reader.Read()) {				
				Neusoft.FrameWork.Models.NeuObject obj=new NeuObject();
				obj.ID=this.Reader[0].ToString();//编码
				obj.Name = this.Reader[1].ToString();//名称
				obj.User01 = this.Reader[2].ToString();//备注
				obj.User02 = this.Reader[3].ToString();//有效标志
				alItem.Add(obj);
			}
			this.Reader.Close();
			return alItem;
		}
		
		/// <summary>
		/// 更新执行单名称
		/// </summary>
		/// <param name="billNo"></param>
		/// <param name="billName"></param>
		/// <param name="Memo"></param>
		/// <param name="style"></param>
		/// <returns></returns>
		public int UpdateExecBillName(string billNo,string billName,string Memo,string style)
		{
			string strSql = "";
			#region "接口"
			//传入：0 执行单流水号 1 执行单名称 3 操作员
			//传出：0
			#endregion
		
			if (this.Sql.GetSql("Order.ExecBill.UpdateItem",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,billNo,billName,this.Operator.ID,Memo,style);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除执行单内容
		/// 必须填写（objBill.ID 执行单流水号，objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型,
		/// objBill.user02非药系统类别、药品类别,objBill.user03 药品用法）
		/// </summary>
		/// <param name="objBill"></param>
		/// <returns></returns>
		public int DeleteExecBill(Neusoft.FrameWork.Models.NeuObject objBill)
		{
			string strSql = "";
			#region "接口"
			//传入：0 执行单流水号 1医嘱类型 2非药系统类别、药品类别 3药品用法
			//传出：0
			#endregion

			if (objBill.Memo == "1") //药品
			{
				if (this.Sql.GetSql("Order.ExecBill.DeleteItem.1",ref strSql) == -1)
				{
					this.Err = this.Sql.Err;
					return -1;
				}
			}
			else if (objBill.Memo == "2")//非药品
			{
				if (this.Sql.GetSql("Order.ExecBill.DeleteItem.2",ref strSql) == -1)
				{
					this.Err = this.Sql.Err;
					return -1;
				}
			}
		
			try
			{
				strSql = string.Format(strSql,objBill.ID,objBill.User01,objBill.User02,objBill.User03);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);

		}
		
		/// <summary>
		/// 获得病区执行单
		/// </summary>
		/// <param name="nurseCode"></param>
		/// <returns></returns>
		public ArrayList QueryExecBill( string nurseCode )
		{
			ArrayList al=new ArrayList();
			string strSql="";
			//Order.ExecBill.SelectItem.1
			//传入：０病区编码
			//传出:0 执行单流水号，１执行单名称
			if(this.Sql.GetSql("Order.ExecBill.SelectItem.1",ref strSql)==0)
			{
				try
				{
				　　strSql=string.Format(strSql,nurseCode);
				}
				catch(Exception ex)
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(strSql)==-1) return null;
				while(this.Reader.Read())
				{
					
					Neusoft.FrameWork.Models.NeuObject obj=new NeuObject();
					obj.ID=this.Reader[0].ToString();
					obj.Name = this.Reader[1].ToString();
					obj.User01 = this.Reader[2].ToString();//执行单备注
					obj.User02 = this.Reader[3].ToString();//执行单分类
                    #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
                    obj.Memo = this.Reader[4].ToString();//明细执行单标记
                    #endregion
					al.Add(obj);
				}
				this.Reader.Close();
			}
			else
			{
				return null;
			}
			return al;
		}

		/// <summary>
		/// 获得执行单控制信息by执行单流水号
		/// </summary>
		/// <param name="billNo"></param>
		/// <returns></returns>
		public ArrayList QueryExecBillDetail(string billNo)
		{
			ArrayList al = new ArrayList();
			string strSql = "";
			//Order.ExecBill.SelectItem.２
			//传入：0  执行单流水号
			//传出:0  执行单流水号,1（　１药２非药）
			//2医嘱类型id 3 name　4非药系统类别／药品类别　5药品用法 id 6 name
			if(this.Sql.GetSql("Order.ExecBill.SelectItem.2",ref strSql) == 0)
			{
				try
				{
				　　strSql=string.Format(strSql,billNo);
				}
				catch(Exception ex)
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					this.WriteErr();
					return null;
				}
				if(this.ExecQuery(strSql) == -1) return null;
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Order.Inpatient.Order  obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();
					obj.ID=this.Reader[0].ToString();
					obj.Memo  = this.Reader[1].ToString();//药品非药品
					obj.OrderType.ID  = this.Reader[2].ToString();
					obj.OrderType.Name  = this.Reader[3].ToString();
					if(obj.Memo == "1")
						obj.Item.User01 = this.Reader[4].ToString();
					else
					    obj.Item.SysClass.ID = this.Reader[4].ToString();//系统类别
					obj.Usage.ID  =this.Reader[5].ToString();
					obj.Usage.Name = this.Reader[6].ToString();
                    #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
                    obj.Item.ID = this.Reader[7].ToString();
                    obj.Item.Name = this.Reader[8].ToString();
                    #endregion
					al.Add(obj);
				}
				this.Reader.Close();
			}
			else
			{
				return null;
			}
			return al;
		}


		/// <summary>
		/// 删除某个护理站下的所有执行单及明细
		/// </summary>
		/// <param name="nurseCode"></param>
		/// <returns></returns>
		public int DeleteAllExecBill(string nurseCode)
		{
			string strSql = "";
			#region 删除细档
			if (this.Sql.GetSql("Order.ExecBill.DeleteAllExecBill.Drug",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,nurseCode);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<0) return -1;
			if (this.Sql.GetSql("Order.ExecBill.DeleteAllExecBill.unDrug",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,nurseCode);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			if(this.ExecNoQuery(strSql) < 0) return -1;
			#endregion
			#region 删除主档
			if (this.Sql.GetSql("Order.ExecBill.DeleteAllExecBill",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, nurseCode);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)< 0) return -1;
			#endregion
			return 0;
		}

		/// <summary>
		/// 获得执行单控制信息by执行单流水号　返回neuobject 实体类型列表
		/// </summary>
		/// <param name="billNo"></param>
		/// <returns></returns>
		public ArrayList QueryExecBillDetailByBillNo(string billNo)
		{
			ArrayList al=new ArrayList();
			string strSql="";
			//Order.ExecBill.SelectItem.２
			//传入：0  执行单流水号
			//传出:0  执行单流水号,1（　１药２非药）
			//2医嘱类型id 3 name　4非药系统类别／药品类别　5药品用法 id 6 name
			if(this.Sql.GetSql("Order.ExecBill.SelectItem.2",ref strSql) == 0)
			{
				try
				{
				　　strSql=string.Format(strSql,billNo);
				}
				catch(Exception ex)
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					this.WriteErr();
					return null;
				}
				if(this.ExecQuery(strSql) == -1) return null;
				while(this.Reader.Read())
				{
					Neusoft.FrameWork.Models.NeuObject  obj = new NeuObject();
					obj.ID=this.Reader[0].ToString();
					obj.Memo  = this.Reader[1].ToString();//药品非药品
					obj.User01  = this.Reader[2].ToString();
					obj.User02= this.Reader[4].ToString();//系统类别
					obj.User03  =this.Reader[5].ToString(); //用法
					al.Add(obj);
				}
				this.Reader.Close();
			}
			else
			{
				return null;
			}
			return al;
		}

        #region {D05A3C7C-1CA1-4b9a-96B6-5D3018CF8FD7}
        /// <summary>
        /// 根据执行单号查询执行单
        /// </summary>
        /// <param name="billNO"></param>
        /// <returns></returns>
        public Neusoft.FrameWork.Models.NeuObject GetExecBillInfoByBillNO(string billNO)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();
            string strSql = "";
            //Order.ExecBill.GetExecBillInfoByBillNO
            //传入：0  执行单流水号
            //传出:0  执行单实体
            if (this.Sql.GetSql("Order.ExecBill.GetExecBillInfoByBillNO", ref strSql) == 0)
            {
                try
                {
                    strSql = string.Format(strSql, billNO);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                if (this.ExecQuery(strSql) == -1) return null;
                while (this.Reader.Read())
                {
                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();
                    obj.User01 = this.Reader[2].ToString();//执行单备注
                    obj.User02 = this.Reader[3].ToString();//执行单分类
                    obj.Memo = this.Reader[4].ToString();//明细执行单标记
                }
                this.Reader.Close();
            }
            else
            {
                return null;
            }
            return obj;
        } 
        #endregion

		#endregion
	}
}
