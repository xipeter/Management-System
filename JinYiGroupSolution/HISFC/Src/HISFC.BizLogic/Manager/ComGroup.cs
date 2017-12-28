using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// ComGroup 的摘要说明。
	/// </summary>
	public class ComGroup :Neusoft.FrameWork.Management.Database 
	{
		public ComGroup()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 获取所有组套
		/// </summary>
		/// <returns></returns>
		public ArrayList GetAllGroups()
		{
			#region sql
//			SELECT group_id,   --组套ID
//					group_name,   --组套名称
//					spell_code,   --组套拼音码
//					input_code,   --组套助记吗
//					group_kind,   --组套类型  0 .财务用  1 .科室用
//					dept_code,   --组套科室
//					sort_id,   --显示顺序
//					valid_flag,   --有效标志，1有效/2无效
//					remark,   --组套备注
//					oper_code,   --操作员
//					oper_date    --操作时间
//				FROM fin_com_group   --组套信息表,用于门诊收费、住院收费、护士站收费、体检收费、手术组套、终端组套
			#endregion
			#region
//			ArrayList List = null;
//			string strSql = "";
//			if (this.Sql.GetSql("Manager.ComGroup.GetAllGroups",ref strSql)==-1) return null;
//			try
//			{				
//				if(this.ExecQuery(strSql)==-1)return null;
//				List = new ArrayList();
//				Neusoft.HISFC.Models.Fee.ComGroup  info =null;
//				while(this.Reader.Read())
//				{
//					info =new Neusoft.HISFC.Models.Fee.ComGroup();
//					info.ID=Reader[0].ToString();
//					info.Name=Reader[1].ToString();
//					info.spellCode=Reader[2].ToString();
//					info.inputCode=Reader[3].ToString();
//					info.groupKind=Reader[4].ToString();
//					info.deptCode=Reader[5].ToString();
//					info.sortId=System.Convert.ToInt32(Reader[6].ToString());
//					info.validFlag=Reader[7].ToString();
//					info.reMark=Reader[8].ToString();
//					info.operCode=Reader[9].ToString();
//					info.operDate=Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
//					
//					List.Add(info);					
//				}
//				this.Reader.Close();
//			}
//			catch(Exception ee)
//			{
//				this.Err = "Manager.ComGroup.GetAllGroups"+ee.Message;
//				this.ErrCode=ee.Message;
//				WriteErr();
//				return null;
//			}
//			return List;
			#endregion
			return  this.GetAllGroups("1");
		}

		/// <summary>
		/// 获取所有组套
		/// </summary>
		/// <param name="GroupKind">0 财务用，1科室用,ALL 全部</param>
		/// <returns></returns>
		public ArrayList GetAllGroups(string GroupKind)
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Manager.ComGroup.GetAllGroups",ref strSql)==-1) return null;
			try
			{	
				strSql = string.Format(strSql,GroupKind);
				if(this.ExecQuery(strSql)==-1)return null;
				List = new ArrayList();
				Neusoft.HISFC.Models.Fee.ComGroup  info =null;
				while(this.Reader.Read())
				{
					info =new Neusoft.HISFC.Models.Fee.ComGroup();
					info.ID=Reader[0].ToString();
					info.Name=Reader[1].ToString();
					info.spellCode=Reader[2].ToString();
					info.inputCode=Reader[3].ToString();
					info.groupKind=Reader[4].ToString();
					info.deptCode=Reader[5].ToString();
					info.sortId=System.Convert.ToInt32(Reader[6].ToString());
                    info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));                    
					info.reMark=Reader[8].ToString();
					info.operCode=Reader[9].ToString();
					info.operDate=Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    //增加父及节点
                    info.ParentGroupID = this.Reader[12].ToString();
					
					List.Add(info);					
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = "Manager.ComGroup.GetAllGroups"+ee.Message;
				this.ErrCode=ee.Message;
				WriteErr();
				return null;
			}
			return List;
		}

        /// <summary>
        /// 获取所有组套
        /// </summary>
        /// <param name="GroupKind">0 财务用，1科室用,ALL 全部</param>
        /// <returns></returns>
        public ArrayList GetAllGroupsByRoot(string GroupKind)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Manager.ComGroup.GetAllGroupsByRoot", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, GroupKind);
                if (this.ExecQuery(strSql) == -1) return null;
                List = new ArrayList();
                Neusoft.HISFC.Models.Fee.ComGroup info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.Fee.ComGroup();
                    info.ID = Reader[0].ToString();
                    info.Name = Reader[1].ToString();
                    info.spellCode = Reader[2].ToString();
                    info.inputCode = Reader[3].ToString();
                    info.groupKind = Reader[4].ToString();
                    info.deptCode = Reader[5].ToString();
                    info.sortId = System.Convert.ToInt32(Reader[6].ToString());
                    info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
                    info.reMark = Reader[8].ToString();
                    info.operCode = Reader[9].ToString();
                    info.operDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    //增加父及节点
                    info.ParentGroupID = this.Reader[12].ToString();

                    List.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = "Manager.ComGroup.GetAllGroupsByRoot" + ee.Message;
                this.ErrCode = ee.Message;
                WriteErr();
                return null;
            }
            return List;
        }

        /// <summary>
        /// 根据科室获取所有组套{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
        /// </summary>
        /// <param name="GroupKind">0 财务用，1科室用,ALL 全部</param>
        /// <returns></returns>
        public ArrayList GetValidGroupListByRoot(string deptCode)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Manager.ComGroup.GetAllGroupsByRootAndDeptCode", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, deptCode);
                if (this.ExecQuery(strSql) == -1) return null;
                List = new ArrayList();
                Neusoft.HISFC.Models.Fee.ComGroup info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.Fee.ComGroup();
                    info.ID = Reader[0].ToString();
                    info.Name = Reader[1].ToString();
                    info.spellCode = Reader[2].ToString();
                    info.inputCode = Reader[3].ToString();
                    info.groupKind = Reader[4].ToString();
                    info.deptCode = Reader[5].ToString();
                    info.sortId = System.Convert.ToInt32(Reader[6].ToString());
                    info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
                    info.reMark = Reader[8].ToString();
                    info.operCode = Reader[9].ToString();
                    info.operDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    //增加父及节点
                    info.ParentGroupID = this.Reader[11].ToString();

                    List.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = "Manager.ComGroup.GetAllGroupsByRootAndDeptCode" + ee.Message;
                this.ErrCode = ee.Message;
                WriteErr();
                return null;
            }
            return List;
        }

        /// <summary>
        /// 获取所有组套{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
        /// </summary>
        /// <param name="GroupKind">0 财务用，1科室用,ALL 全部</param>
        /// <returns></returns>
        public ArrayList GetGroupsByDeptParent(string GroupKind, string deptCode, string parentGroupID)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Manager.ComGroup.GetGroupsByDeptParent", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, GroupKind,deptCode,parentGroupID);
                if (this.ExecQuery(strSql) == -1) return null;
                List = new ArrayList();
                Neusoft.HISFC.Models.Fee.ComGroup info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.Fee.ComGroup();
                    info.ID = Reader[0].ToString();
                    info.Name = Reader[1].ToString();
                    info.spellCode = Reader[2].ToString();
                    info.inputCode = Reader[3].ToString();
                    info.groupKind = Reader[4].ToString();
                    info.deptCode = Reader[5].ToString();
                    info.sortId = System.Convert.ToInt32(Reader[6].ToString());
                    info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
                    info.reMark = Reader[8].ToString();
                    info.operCode = Reader[9].ToString();
                    info.operDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    //增加父及节点
                    info.ParentGroupID = this.Reader[12].ToString();

                    List.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = "Manager.ComGroup.GetAllGroups" + ee.Message;
                this.ErrCode = ee.Message;
                WriteErr();
                return null;
            }
            return List;
        }

		public Neusoft.HISFC.Models.Fee.ComGroup GetComGroupByGroupID(string GroupID)
		{
			string strSql = "";
			//select group_id,group_name ,a.spell_code,a.input_code,group_Kind,dept_name,a.sort_id,valid_flag,remark from fin_com_group a ,com_department b where a.dept_code =b.dept_code and group_id ='{0}' and a.PARENT_CODE ='[父级编码]'   and a.CURRENT_CODE  ='[本级编码]';
			Neusoft.HISFC.Models.Fee.ComGroup info = null;
			try
			{
				if (this.Sql.GetSql("Manager.ComGroup.GetComGroupByGroupID",ref strSql)==-1) return null;
				strSql = string.Format(strSql,GroupID);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Fee.ComGroup();
					info.ID =Reader[0].ToString();
					info.Name =Reader[1].ToString();
					info.spellCode =Reader[2].ToString();
					info.inputCode =Reader[3].ToString();
					info.groupKind =Reader[4].ToString();
					info.deptName = Reader[5].ToString();
					if(Reader[6]!=DBNull.Value)
					{
						info.sortId =Convert.ToInt32(Reader[6]);
					}
					else
					{
						info.sortId =0;
					}
                    info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
					info.reMark =Reader[8].ToString();
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
			return info;
		}
		public  int InsertInToComGroup(Neusoft.HISFC.Models.Fee.ComGroup info )
		{
			string strSql ="";
            string OperCode = this.Operator.ID;
            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}增加父及节点
            string[] str = new string[] { info.ID, info.Name, info.spellCode, info.inputCode, info.groupKind, info.deptName, info.sortId.ToString(), ((int)info.ValidState).ToString(), info.reMark, OperCode,info.ParentGroupID};
			try
			{
				//insert into fin_com_group values('[本级编码]','[父级编码]','{0}','{1}','{2}','{3}','{4}',(select dept_code from com_department where dept_name ='{5}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]'),'{6}','{7}','{8}','{9}',sysdate)
				if (this.Sql.GetSql("Manager.ComGroup.InsertInToComGroup",ref strSql)==-1) return -1;
				
                //strSql = string.Format(strSql, info.ID, info.Name, info.spellCode, info.inputCode, info.groupKind, info.deptName, info.sortId, ((int)info.ValidState).ToString(), info.reMark, OperCode);
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
			}
			return this.ExecNoQuery(strSql,str);
		}
		public  int ModefyComGroup(Neusoft.HISFC.Models.Fee.ComGroup info)
		{
			string strSql ="";
			try
			{
				//update fin_com_group set GROUP_NAME ='{0}',SPELL_COD ='{1}',INPUT_CODE='{2}',GROUP_KIND='{3}',DEPT_CODE=(select dept_code from com_department where dept_name ='{4}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]') ,SORT_ID ={5},VALID_FLAG ='{6}',REMARK ='{7}',OPER_CODE ='{8}' where GROUP_ID ='{9}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]'
				if (this.Sql.GetSql("Manager.ComGroup.ModefyComGroup",ref strSql)==-1) return -1;
				string OperCode = this.Operator.ID;
                strSql = string.Format(strSql, info.Name, info.spellCode, info.inputCode, info.groupKind, info.deptName, info.sortId, ((int)info.ValidState).ToString(), info.reMark, OperCode, info.ID);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		public  int DeleteComGroup(Neusoft.HISFC.Models.Fee.ComGroup com)
		{
			string strSql ="";
			try
			{
				//delete fin_com_group where group_id = '{0}'
				if (this.Sql.GetSql("Manager.ComGroup.DeleteComGroup",ref strSql)==-1) return -1;
				strSql = string.Format(strSql,com.ID);
				if(this.ExecNoQuery(strSql)==-1)return -1;
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				WriteErr();
				return -1;
			}		
			return 0;
		}
		/// <summary>
		/// 删除组套所有明细
		/// </summary>
		/// <param name="groupID"></param>
		/// <returns></returns>
		public int DelGroupDetails(string groupID)
		{
			#region sql
			//DELETE FROM fin_com_groupdetail 
			//		WHERE parent_code='[父级编码]' and current_code='[本级编码]' and group_id='{0}'
			#endregion
			string strSql="";
			
			if(Sql.GetSql("Manager.ComGroup.DeleteDetails",ref strSql)==-1)return -1;
			try
			{
				strSql=string.Format(strSql,groupID);
				if(ExecNoQuery(strSql)==-1)return -1;
			}
			catch(Exception e)
			{
				this.Err="Manager.ComGroup.DeleteDetails!"+e.Message;
				WriteErr();
				return -1;
			}
			return 0;
		}
		/// <summary>
		/// 查询指定科室手术模板组套
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <returns>组套对象列表</returns>
		public ArrayList GetOpsTreeComGroup(string DeptID)
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Manager.ComGroup.GetOpsTreeComGroup",ref strSql)==-1) return null;
			strSql = string.Format(strSql,DeptID);
			try
			{
				this.ExecQuery(strSql);
				List = new ArrayList();				
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.ComGroup info =new Neusoft.HISFC.Models.Fee.ComGroup();
					info.deptCode  =Reader[0].ToString();
					info.ID = Reader[1].ToString();
					info.Name =Reader[2].ToString();
					List.Add(info);
				}
				Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = "Manager.ComGroup.GetOpsTreeComGroup";
				this.ErrCode = ee.Message;
				this.WriteErr();
				return null;
			}
			return List;
		}
		/// <summary>
		/// 按科室获取所有有效组套
		/// </summary>
		/// <returns></returns>
		public ArrayList GetValidGroupList(string deptID)
		{
			#region sql
//			 SELECT group_id,   --组套ID
//					group_name,   --组套名称
//					spell_code,   --组套拼音码
//					input_code,   --组套助记吗
//					group_kind,   --组套类型  0 .财务用  1 .科室用
//					dept_code,   --组套科室
//					sort_id,   --显示顺序
//					valid_flag,   --有效标志，1有效/2无效
//					remark,   --组套备注
//					oper_code,   --操作员
//					oper_date    --操作时间
//			   FROM fin_com_group   --组套信息表,用于门诊收费、住院收费、护士站收费、体检收费、手术组套、终端组套
//			  WHERE parent_code='[父级编码]' and current_code='[本级编码]' and dept_code='{0}' and valid_flag='1'
			#endregion
			string strSql="";
			ArrayList group=new ArrayList();

			if(this.Sql.GetSql("Manager.ComGroup.GetValidGroupList",ref strSql)==-1)return null;
			try
			{
				strSql=string.Format(strSql,deptID);
				if(this.ExecQuery(strSql)==-1)return null;
				while(Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.ComGroup c=new Neusoft.HISFC.Models.Fee.ComGroup();
					c.ID=Reader[0].ToString();
					c.Name=Reader[1].ToString();
					c.spellCode=Reader[2].ToString();
					c.inputCode=Reader[3].ToString();
					c.groupKind=Reader[4].ToString();
					c.deptCode=Reader[5].ToString();
					if(Reader[6]!=DBNull.Value)
					{
						c.sortId =Convert.ToInt32(Reader[6].ToString());
					}
					else
					{
						c.sortId =0;
					}
                    c.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
					c.reMark=Reader[8].ToString();
					c.operCode=Reader[9].ToString();
					c.operDate=Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
					group.Add(c);
				}
				Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="Manager.ComGroup.GetValidGroupList!"+e.Message;
				WriteErr();
				if(Reader.IsClosed!=true)Reader.Close();
				return null;
			}
			return group;
		}
		/// <summary>
		/// 根据科室代码和组套类别获取组套
		/// </summary>
		/// <param name="GroupKind">0 财务用，1科室用,ALL 全部</param>
		/// <param name="deptID">科室代码</param>
		/// <returns></returns>
		public ArrayList GetGroupsByDept(string GroupKind,string deptID)
		{
			#region sql
			//			 SELECT group_id,   --组套ID
			//					group_name,   --组套名称
			//					spell_code,   --组套拼音码
			//					input_code,   --组套助记吗
			//					group_kind,   --组套类型  0 .财务用  1 .科室用
			//					dept_code,   --组套科室
			//					sort_id,   --显示顺序
			//					valid_flag,   --有效标志，1有效/2无效
			//					remark,   --组套备注
			//					oper_code,   --操作员
			//					oper_date    --操作时间
			//			   FROM fin_com_group   --组套信息表,用于门诊收费、住院收费、护士站收费、体检收费、手术组套、终端组套
			//			  WHERE parent_code='[父级编码]' and current_code='[本级编码]' and dept_code='{0}' and valid_flag='1'
			//                 ( and group_kind = '{2}'  or 'ALL'='{2}')
			#endregion
			string strSql="";
			ArrayList group=new ArrayList();

			if(this.Sql.GetSql("Manager.ComGroup.GetGroupsByDept",ref strSql)==-1)return null;
			try
			{
				strSql=string.Format(strSql,deptID,GroupKind);
				if(this.ExecQuery(strSql)==-1)return null;
				while(Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.ComGroup c=new Neusoft.HISFC.Models.Fee.ComGroup();
					c.ID=Reader[0].ToString();
					c.Name=Reader[1].ToString();
					c.spellCode=Reader[2].ToString();
					c.inputCode=Reader[3].ToString();
					c.groupKind=Reader[4].ToString();
					c.deptCode=Reader[5].ToString();
					if(Reader[6]!=DBNull.Value)
					{
						c.sortId =Convert.ToInt32(Reader[6].ToString());
					}
					else
					{
						c.sortId =0;
					}
                    c.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
					c.reMark=Reader[8].ToString();
					c.operCode=Reader[9].ToString();
					c.operDate=Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
					group.Add(c);
				}
				Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="Manager.ComGroup.GetGroupsByDept!"+e.Message;
				WriteErr();
				if(Reader.IsClosed!=true)Reader.Close();
				return null;
			}
			return group;
		}

        /// <summary>
        /// 根据组套名称组套编码科室编码
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="groupID"></param>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList QueryGroupsByName(string groupName , string deptID)
        {
            string strSql = "";
            ArrayList group = new ArrayList();

            if (this.Sql.GetSql("Manager.ComGroup.QueryGroupsByName", ref strSql) == -1) return null;
            try
            {
                string [] str = new string[] { groupName, deptID };
                //strSql = string.Format(strSql, groupName, deptID);
                if (this.ExecQuery(strSql, str) == -1) return null;
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.ComGroup c = new Neusoft.HISFC.Models.Fee.ComGroup();
                    c.ID = Reader[0].ToString();
                    c.Name = Reader[1].ToString();
                    c.spellCode = Reader[2].ToString();
                    c.inputCode = Reader[3].ToString();
                    c.groupKind = Reader[4].ToString();
                    c.deptCode = Reader[5].ToString();
                    if (Reader[6] != DBNull.Value)
                    {
                        c.sortId = Convert.ToInt32(Reader[6].ToString());
                    }
                    else
                    {
                        c.sortId = 0;
                    }
                    c.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
                    c.reMark = Reader[8].ToString();
                    c.operCode = Reader[9].ToString();
                    c.operDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    group.Add(c);
                }
                Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = "Manager.ComGroup.GetGroupsByDept!" + e.Message;
                WriteErr();
                if (Reader.IsClosed != true) Reader.Close();
                return null;
            }
            return group;
        }
        /// <summary>
        /// 按科室获取所有有效组套
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllGroupList(string deptID)
        {
            #region sql
            //			 SELECT group_id,   --组套ID
            //					group_name,   --组套名称
            //					spell_code,   --组套拼音码
            //					input_code,   --组套助记吗
            //					group_kind,   --组套类型  0 .财务用  1 .科室用
            //					dept_code,   --组套科室
            //					sort_id,   --显示顺序
            //					valid_flag,   --有效标志，1有效/2无效
            //					remark,   --组套备注
            //					oper_code,   --操作员
            //					oper_date    --操作时间
            //			   FROM fin_com_group   --组套信息表,用于门诊收费、住院收费、护士站收费、体检收费、手术组套、终端组套
            //			  WHERE parent_code='[父级编码]' and current_code='[本级编码]' and dept_code='{0}' and valid_flag='1'
            #endregion
            string strSql = "";
            ArrayList group = new ArrayList();

            if (this.Sql.GetSql("Manager.ComGroup.GetAllGroupList", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, deptID);
                if (this.ExecQuery(strSql) == -1) return null;
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.ComGroup c = new Neusoft.HISFC.Models.Fee.ComGroup();
                    c.ID = Reader[0].ToString();
                    c.Name = Reader[1].ToString();
                    c.spellCode = Reader[2].ToString();
                    c.inputCode = Reader[3].ToString();
                    c.groupKind = Reader[4].ToString();
                    c.deptCode = Reader[5].ToString();
                    if (Reader[6] != DBNull.Value)
                    {
                        c.sortId = Convert.ToInt32(Reader[6].ToString());
                    }
                    else
                    {
                        c.sortId = 0;
                    }
                    c.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString()));
                    c.reMark = Reader[8].ToString();
                    c.operCode = Reader[9].ToString();
                    c.operDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    group.Add(c);
                }
                Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = "Manager.ComGroup.GetValidGroupList!" + e.Message;
                WriteErr();
                if (Reader.IsClosed != true) Reader.Close();
                return null;
            }
            return group;
        }
	}
}
