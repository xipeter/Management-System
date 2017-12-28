using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager 
{
	/// <summary>
	/// ComGroupTail 的摘要说明。
	/// </summary>
	public class ComGroupTail :Neusoft.FrameWork.Management.Database
	{
		public ComGroupTail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public ArrayList  GetComGroupTail()
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Manager.ComGroup.GetComGroupTail",ref strSql)==-1) return null;
			try
			{
				// select group_id ,sequence_no,item_code ,drug_flag,a.exec_dpcd, b.dept_name ,qty,unit_flag,comb_no,remark,a.oper_code,a.oper_date  from fin_com_groupdetail a ,com_department b  where a.exec_dpcd = b.dept_code
				this.ExecQuery(strSql);
				List = new ArrayList();
				Neusoft.HISFC.Models.Fee.ComGroupTail  info = null;
				while(this.Reader.Read())
				{
					info =new Neusoft.HISFC.Models.Fee.ComGroupTail();
					info.ID  =Reader[0].ToString();
					if(Reader[1]!=DBNull.Value)
					{
						info.sequenceNo  =Convert.ToInt32(Reader[1]);
					}
					else
					{
						info.sequenceNo =0;
					}
					info.itemCode  =Reader[2].ToString();
					info.drugFlag  =Reader[3].ToString();
					info.deptCode =Reader[4].ToString();
					info.deptName  =Reader[5].ToString();
					if(Reader[6]!=DBNull.Value)
					{
						info.qty  =Convert.ToDecimal(Reader[6]);
					}
					else
					{
						info.qty =0;
					}
					info.unitFlag  =Reader[7].ToString();
					info.combNo  =Reader[8].ToString();
					info.reMark  =Reader[9].ToString();
					info.operCode  =Reader[10].ToString();
					if(Reader[11]!=DBNull.Value)
					{
						info.OperDate  =Convert.ToDateTime(Reader[11]);
					}
					List.Add(info);
					info = null;
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
		/// 获取明细
		/// </summary>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public ArrayList  GetComGroupTailByDeptCode(string deptCode)
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Manager.ComGroup.GetComGroupTailByDeptCode",ref strSql)==-1) return null;
			try
			{
				// select group_id ,sequence_no,item_code ,drug_flag,a.exec_dpcd, b.dept_name ,qty,unit_flag,comb_no,remark,a.oper_code,a.oper_date  from fin_com_groupdetail a ,com_department b  where a.exec_dpcd = b.dept_code and dept_code = '{0}' 
				strSql = string.Format(strSql,deptCode);
				this.ExecQuery(strSql);
				List = new ArrayList();
				Neusoft.HISFC.Models.Fee.ComGroupTail  info = null;
				while(this.Reader.Read())
				{
					info =new Neusoft.HISFC.Models.Fee.ComGroupTail();
					info.ID  =Reader[0].ToString();
					if(Reader[1]!=DBNull.Value)
					{
						info.sequenceNo  =Convert.ToInt32(Reader[1]);
					}
					else
					{
						info.sequenceNo =0;
					}
					info.itemCode  =Reader[2].ToString();
					info.drugFlag  =Reader[3].ToString();
					info.deptCode =Reader[4].ToString();
					info.deptName  =Reader[5].ToString();
					if(Reader[6]!=DBNull.Value)
					{
						info.qty  =Convert.ToDecimal(Reader[6]);
					}
					else
					{
						info.qty =0;
					}
					info.unitFlag  =Reader[7].ToString();
					info.combNo  =Reader[8].ToString();
					info.reMark  =Reader[9].ToString();
					info.operCode  =Reader[10].ToString();
					if(Reader[11]!=DBNull.Value)
					{
						info.OperDate  =Convert.ToDateTime(Reader[11]);
					}
					List.Add(info);
					info = null;
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
		public ArrayList GetItemList()
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Manager.ComGroup.GetItemList",ref strSql)==-1) return null;
			try
			{
				// select '1' ,DRUG_CODE  ,TRADE_NAME  ,RETAIL_PRICE ,MIN_UNIT  , PACK_UNIT  , FORMAL_SPELL  ,FORMAL_WB  from pha_com_baseinfo where PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]' and VALID_STATE ='0' union select '2' ,ITEM_CODE  ,ITEM_NAME   ,UNIT_PRICE ,'最小单位','包装单位',SPELL_CODE,WB_CODE  from  fin_com_undruginfo where PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]' and VALID_STATE ='0'
				this.ExecQuery(strSql);
				List = new ArrayList();
				Neusoft.HISFC.Models.Pharmacy.Item  info = null;
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Pharmacy.Item();
					if(Reader[0]!=DBNull.Value)
					{
						info.NameCollection.OtherName = Reader[0].ToString();
					}
					if(Reader[1]!=DBNull.Value)
					{
						info.ID = Reader[1].ToString();
					}
					if(Reader[2]!=DBNull.Value)
					{
						info.Name = Reader[2].ToString();
					}
					if(Reader[3]!=DBNull.Value)
					{
						info.PriceCollection.RetailPrice = Convert.ToDecimal(Reader[3]);
					}
					if(Reader[4]!=DBNull.Value)
					{
						info.MinUnit = Reader[4].ToString();
					}
					if(Reader[5]!=DBNull.Value)
					{
						info.PackUnit = Reader[5].ToString();
					}
					if(Reader[6]!=DBNull.Value)
					{
						info.NameCollection.RegularName = Reader[6].ToString(); //拼音玛
					}
					if(Reader[7]!=DBNull.Value)
					{
						info.NameCollection.FormalName = Reader[7].ToString(); // 五笔码
					}
					List.Add(info);
					info = null;
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
		/// 查询药品非药品的名称和价格  
		/// </summary>
		/// <param name="ItemCode"></param>
		/// <param name="type"> "drug"为药品 "undrug" 为非药品</param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Pharmacy.Item   GetItemNameAndPrice(string ItemCode,string type)
		{
			string strSql = "";
			Neusoft.HISFC.Models.Pharmacy.Item   info = null;
			if(type=="drug")
			{
				// select '1',DRUG_CODE  ,TRADE_NAME  ,RETAIL_PRICE ,MIN_UNIT  , PACK_UNIT    from pha_com_baseinfo where PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]' and VALID_STATE ='0' and DRUG_CODE  ='{0}'
				if (this.Sql.GetSql("Manager.ComGroup.GetItemNameAndPrice1",ref strSql)==-1) return null;
			}
			else 
			{
				// select '2' ,ITEM_CODE  ,ITEM_NAME   ,UNIT_PRICE ,'最小单位','包装单位',SPELL_CODE,WB_CODE  from  fin_com_undruginfo where PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]' and VALID_STATE ='0' and DRUG_CODE  ='{0}'
				if (this.Sql.GetSql("Manager.ComGroup.GetItemNameAndPrice2",ref strSql)==-1) return null;
			}
			try
			{
				strSql = string.Format(strSql,ItemCode);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Pharmacy.Item();
					info.Oper.ID =Reader[0].ToString(); //区分是药品还是非药品
					info.ID = Reader[1].ToString();		 //项目代码
					info.Name =Reader[2].ToString();    //项目名称
					if( Reader[3]!=DBNull.Value) 
					{
						info.PriceCollection.RetailPrice =Convert.ToDecimal(Reader[3]); //参考零售价
					}
					info.MinUnit = Reader[4].ToString();  //最小单位
					info.PackUnit =Reader[5].ToString(); // 包装单位
					info.NameCollection.RegularName =Reader[6].ToString(); //拼音
					info.NameCollection.FormalName = Reader[7].ToString(); //五笔
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err =ee.Message;
				return null;
			}
			return info;
		}
		/// <summary>
		/// 得到新的ID
		/// </summary>
		/// <returns></returns>
		public string getGroupID()
		{
			string ID  = "";
			string strSql = "";  //select seq_comgroupid.nextval from dual
			if (this.Sql.GetSql("Manager.ComGroup.getGroupID",ref strSql)==-1) return null;
			try
			{
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					ID  =Reader[0].ToString();
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return "";
			}
			return ID;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="GroupID"></param>
		/// <returns></returns>
		public string  GetMaxSequenceNo(string GroupID)
		{
			string ID  = "";
			string strSql = "";
			// select nvl(Max(SEQUENCE_NO),0)+1  from fin_com_groupdetail where  PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]'  and GROUP_ID  ='{0}'
			if (this.Sql.GetSql("Manager.ComGroup.GetMaxSequenceNo",ref strSql)==-1) return null;
			try
			{
				strSql = string .Format(strSql,GroupID);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					ID  =Reader[0].ToString();
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return "";
			}
			return ID;
		}

		public ArrayList  GetComGroupTailByGroupID(string GroupID)
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Manager.ComGroup.GetComGroupTailByGroupID",ref strSql)==-1) return null;
			try
			{
				// select group_id ,sequence_no,item_code ,drug_flag,a.exec_dpcd, b.dept_name ,qty,unit_flag,comb_no,remark,a.oper_code,a.oper_date  from fin_com_groupdetail a ,com_department b  where a.exec_dpcd = b.dept_code and group_id  = '{0}' 
				strSql = string.Format(strSql,GroupID);
				this.ExecQuery(strSql);
				List = new ArrayList();
				Neusoft.HISFC.Models.Fee.ComGroupTail  info = null;
				while(this.Reader.Read())
				{
					info =new Neusoft.HISFC.Models.Fee.ComGroupTail();
					info.ID  =Reader[0].ToString();
					if(Reader[1]!=DBNull.Value)
					{
						info.sequenceNo  =Convert.ToInt32(Reader[1]);
					}
					else
					{
						info.sequenceNo =0;
					}
					info.itemCode  =Reader[2].ToString();
					info.drugFlag  =Reader[3].ToString();
					info.deptCode =Reader[4].ToString();
					info.deptName  =Reader[5].ToString();
					if(Reader[6]!=DBNull.Value)
					{
						info.qty  =Convert.ToDecimal(Reader[6]);
					}
					else
					{
						info.qty =0;
					}
					info.unitFlag  =Reader[7].ToString();
					info.combNo  =Reader[8].ToString();
					info.reMark  =Reader[9].ToString();
					info.operCode  =Reader[10].ToString();
					if(Reader[11]!=DBNull.Value)
					{
						info.OperDate  =Convert.ToDateTime(Reader[11]);
					}
					info.SortNum  = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[12].ToString());
					List.Add(info);
					info = null;
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
		/// 插入一条明细
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertDataIntoComGroupTail(Neusoft.HISFC.Models.Fee.ComGroupTail info)
		{
			string strSql ="";
			try
			{
				//insert into fin_com_groupdetail  values('[本级编码]','[父级编码]','{0}',{1},'{2}','{3}',(select dept_code from com_department where dept_name ='{4}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]'),{5},'{6}','{7}','{8}','{9}',sysdate)
				if (this.Sql.GetSql("Manager.ComGroup.InsertDataIntoComGroupTail",ref strSql)==-1) return -1;
				string OperCode = this.Operator.ID;
				strSql = string.Format(strSql,info.ID,info.sequenceNo,info.itemCode,info.drugFlag,info.deptName,info.qty,info.unitFlag,info.combNo,info.reMark,OperCode,info.SortNum);
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 修改一条明细
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int ModefyDataIntoComGroupTail(Neusoft.HISFC.Models.Fee.ComGroupTail info)
		{
			string strSql ="";
			try
			{
				//update fin_com_groupdetail set exec_dpcd =(select dept_code from com_department where dept_name ='{0}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]') ,qty= {1},unit_flag ='{2}',comb_no ='{3}' ,remark ='{4}' where group_id = '{5}' and sequence_no ={6} and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]'
				if (this.Sql.GetSql("Manager.ComGroup.ModefyDataIntoComGroupTail",ref strSql)==-1) return -1;
				string OperCode = this.Operator.ID;
				strSql = string.Format(strSql,info.deptName,info.qty,info.unitFlag,info.combNo,info.reMark,info.ID,info.sequenceNo,info.SortNum);
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除一条明细
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int DeleteDataIntoComGroupTail(Neusoft.HISFC.Models.Fee.ComGroupTail info)
		{
			string strSql ="";
			try
			{
				// delete fin_com_groupdetail where group_id ='{0}' and sequence_no ='{1}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码] 
				if (this.Sql.GetSql("Manager.ComGroup.DeleteDataIntoComGroupTail",ref strSql)==-1) return -1;
				string OperCode = this.Operator.ID;
				strSql = string.Format(strSql,info.ID,info.sequenceNo);
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
	}
}
