using System;
using Neusoft.HISFC.Models;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.Order
{
	/// <summary>
	/// AdditionalItem 的摘要说明。
	/// 附材项目管理
	/// </summary>
	public class AdditionalItem:Neusoft.FrameWork.Management.Database 
	{
		public AdditionalItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 添加附材信息
		/// 必须填写（item.id,item.Amount,Item.isPharmacy）
        /// {24F859D1-3399-4950-A79D-BCCFBEEAB939}
		/// </summary>
		/// <param name="item"></param>
		/// <param name="deptCode"></param>
		/// <param name="isPharmacy"></param>
		/// <param name="typeCode"></param>
        /// <param name="USE_INTERVAL"></param>{24F859D1-3399-4950-A79D-BCCFBEEAB939}
		/// <returns></returns>
        /// {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 增加参数price
        public int InsertAdditionalItem(Neusoft.HISFC.Models.Base.Item item, string deptCode, bool isPharmacy, string typeCode, string USE_INTERVAL, decimal price)
		{
			#region "接口"
			//传入：0 科室编码 1是否药品，2用法（项目）编码 3 附材项目ID 4 附材项目数量 5 操作员 6 操作时间
			//传出：0
			#endregion
			string strSql = "";
		
			if (this.Sql.GetSql("Order.AdditionalItem.InsertItem",ref strSql)==-1) 
			{
				this.Err = "没有找到Order.AdditionalItem.InsertItem";
				return -1;
			}
			try
			{
                //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 增加参数price
                strSql = string.Format(strSql, deptCode, System.Convert.ToInt16(isPharmacy).ToString(), typeCode, item.ID, item.Qty, this.Operator.ID, this.GetSysDateTime(), System.Convert.ToInt32(USE_INTERVAL.Replace('H', ' ')), price);
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
		///  更新附材信息
		/// 必须填写（item.id,item.Amount,Item.isPharmacy）
		/// </summary>
		/// <param name="item"></param>
		/// <param name="deptCode"></param>
		/// <param name="isPharmacy"></param>
		/// <param name="typeCode"></param>
        /// <param name="USE_INTERVAL"></param>//{24F859D1-3399-4950-A79D-BCCFBEEAB939}
		/// <returns></returns>
        /// {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 增加参数price
        public int UpdateAdditionalItem(Neusoft.HISFC.Models.Base.Item item, string deptCode, bool isPharmacy, string typeCode, string USE_INTERVAL, decimal price)
		{
			string strSql = "";
			#region "接口"
			//传入：0 科室编码 1是否药品，2用法（项目）编码 3 附材项目ID 4 附材项目数量 5 操作员 6 操作时间
			//传出：0
			#endregion
			if (this.Sql.GetSql("Order.AdditionalItem.UpdateItem",ref strSql)==-1)
			{
				this.Err = "没有找到Order.AdditionalItem.UpdateItem";
				return -1;
			}
			try
			{
                //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                // {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 增加参数price
                strSql = string.Format(strSql, deptCode, Neusoft.FrameWork.Function.NConvert.ToInt32(isPharmacy).ToString(), typeCode, item.ID, item.Qty, this.Operator.ID, this.GetSysDateTime(), System.Convert.ToInt32(USE_INTERVAL.Replace('H', ' ')), price);
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
		///  删除附材信息
		/// 必须填写（item.id,item.Amount,Item.isPharmacy）
		/// </summary>
		/// <param name="item"></param>
		/// <param name="deptCode"></param>
		/// <param name="isPharmacy"></param>
		/// <param name="typeCode"></param>
		/// <returns></returns>
		public int DeleteAdditionalItem( Neusoft.HISFC.Models.Base.Item item, string deptCode, bool isPharmacy, string typeCode )
		{
			string strSql = "";
			#region "接口"
			//传入：0 科室编码 1是否药品，2用法（项目）编码 3 附材项目ID 
			//传出：0
			#endregion
			if (this.Sql.GetSql("Order.AdditionalItem.DeleteItem",ref strSql)==-1) 
			{
				this.Err = "没有找到Order.AdditionalItem.DeleteItem";
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,deptCode,FrameWork.Function.NConvert.ToInt32(isPharmacy).ToString(),typeCode,item.ID);
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
		/// 设置附材
		/// </summary>
		/// <param name="item"></param>
		/// <param name="deptCode"></param>
		/// <param name="isPharmacy"></param>
		/// <param name="typeCode"></param>
        /// <param name="USE_INTERVAL"></param>//{24F859D1-3399-4950-A79D-BCCFBEEAB939}
		/// <returns></returns>
        /// {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 增加参数price
        public int SetAdditionalItem(Neusoft.HISFC.Models.Base.Item item, string deptCode, bool isPharmacy, string typeCode, string USE_INTERVAL, decimal price)
		{
            //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
            int i = this.UpdateAdditionalItem(item, deptCode, isPharmacy, typeCode, (USE_INTERVAL == null || USE_INTERVAL == "") ? "0" : USE_INTERVAL, price);
			if( i== 0 )
			{
                //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                i = this.InsertAdditionalItem(item, deptCode, isPharmacy, typeCode, (USE_INTERVAL == null || USE_INTERVAL == "") ? "0" : USE_INTERVAL, price);
				if(i<0) return -1;
				return i;
			}
			return i;
		}

		#region 作废的
		/// <summary>
		/// 获得医嘱用法（项目）的附材信息
		/// </summary>
		/// <param name="IsPharmacy"></param>
		/// <param name="TypeCode"></param>
		/// <param name="DeptCode"></param>
		/// <returns></returns>
		[Obsolete("用QueryAdditionalItem代替",true)]
		public ArrayList GetAdditionalItem(bool IsPharmacy,string TypeCode,string DeptCode)
		{
			return this.QueryAdditionalItem(IsPharmacy,TypeCode,DeptCode);			
		}

		[Obsolete("用QueryAdditionalItem代替",true)]
		public ArrayList GetAdditionalUndrugItems(bool IsPharmacy,string DeptCode)
		{
			return this.QueryAdditionalItem(IsPharmacy,DeptCode);
		}
		#endregion 

		/// <summary>
		/// 获得医嘱用法（项目）的附材信息
		/// </summary>
		/// <param name="isPharmacy"></param>
		/// <param name="typeCode"></param>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public ArrayList QueryAdditionalItem( bool isPharmacy, string typeCode, string deptCode )
		{
			ArrayList al=new ArrayList();
			string strSql="";
			//Order.AdditionalItem.SelectItem.1
			//传入：0 DeptCode 1 IsPharmacy,2 TypeCode 
			//传出:属于该项目或用法的附材
			if(this.Sql.GetSql("Order.AdditionalItem.SelectItem.1",ref strSql) == 0)
			{
				if(this.ExecQuery(strSql,deptCode,Neusoft.FrameWork.Function.NConvert.ToInt32(isPharmacy).ToString(),typeCode)==-1) return null;
				while(this.Reader.Read())
				{
					
					Neusoft.HISFC.Models.Base.Item obj=new Neusoft.HISFC.Models.Base.Item();
					//0 TypeCode 没用 
					//1 项目编码 
					//2 数量
					//3 操作员
					//4 操作时间
					obj.ID=this.Reader[1].ToString();
					obj.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2]);
					obj.User01 = this.Reader[3].ToString();
					obj.User02 = this.Reader[4].ToString();
                    //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                    obj.User03 = this.Reader[5].ToString() == "0" ? "0" : this.Reader[5].ToString() + "H";
                    //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 增加查找单价
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6]);
					al.Add(obj);
				}
				this.Reader.Close();
			}
			else
			{
				this.Err = "没有找到Order.AdditionalItem..SelectItem.1";
				return null;
			}
			return al;
		}
		/// <summary>
		/// 获得已经维护的非药品附材项目
		/// 只获得非药品项目
		/// </summary>
		/// <param name="isPharmacy"></param>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public ArrayList QueryAdditionalItem( bool isPharmacy, string deptCode )
		{
			ArrayList al = new ArrayList();
			string strSql="";
			
			if(this.Sql.GetSql("Order.AdditionalItem.SelectItems.1",ref strSql) == 0)
			{
				if(this.ExecQuery(strSql,deptCode,FrameWork.Function.NConvert.ToInt32(isPharmacy).ToString())==-1) return null;
				while(this.Reader.Read())
				{
					
					Neusoft.FrameWork.Models.NeuObject  obj=new Neusoft.FrameWork.Models.NeuObject();
					//ID 项目类别
					//Name 项目编码
					//Memo 数量
					obj.ID=this.Reader[0].ToString();
					try
					{
						obj.Name = this.Reader[1].ToString();
						obj.Memo = this.Reader[2].ToString();
                        //{24F859D1-3399-4950-A79D-BCCFBEEAB939}
                        obj.User03 = this.Reader[3].ToString() == "0" ? "0" : this.Reader[3].ToString() + "H";
                        //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                        obj.User01 = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6]).ToString();
					}
					catch{}
					al.Add(obj);
				}
				this.Reader.Close();
			}
			else
			{
				this.Err = "没有找到Order.AdditionalItem..SelectItem.1";
				return null;
			}
			return al;
		}
	}
}
