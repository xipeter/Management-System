using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.PhysicalExamination
{
    /// <summary>
    /// Group<br></br>
    /// [功能描述: 体检组套管理类]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public  class Group : Neusoft.FrameWork.Management.Database
    {
        #region 私有函数
        /// <summary>
        /// 获取主 SQL语句 
        /// </summary>
        /// <returns></returns>
        private string GetGroupSql()
        {
            string strSql = "";
            if (this.Sql.GetSql("Exami.ChkGroup.GetAllGroups", ref strSql) == -1) return null;
            return strSql;
        }
        /// <summary>
        /// 组套参数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string[] GetParam(Neusoft.HISFC.Models.PhysicalExamination.Group obj)
        {
            string[] str = new string[]
					{
						obj.ID, //组套代码 
						obj.Name ,//组套名称1
						obj.deptCode,//科室代码2
						obj.spellCode,//拼音码3 
						obj.WBCode,//五笔码4
                        obj.inputCode,//自定义码5
						obj.reMark, //备注6
						obj.IsShare ,// --是否共享,0是，1否7
						obj.OwnRate.ToString(),//自费比例 
						obj.PayRate.ToString(),//自付比例9
						obj.PubRate.ToString(),//公费比例10
						obj.EcoRate.ToString(),//优惠比例11
						((int)obj.ValidState).ToString(),//停用标志12
						this.Operator.ID//操作员13
					};
            return  str;
        }
        /// <summary>
        /// 根据ＳＱＬ查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList QueryGroup(string strSql)
        {
            ArrayList List = new ArrayList();
            try
            {
                if (this.ExecQuery(strSql) == -1) return null;
                
                Neusoft.HISFC.Models.PhysicalExamination.Group info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.PhysicalExamination.Group();
                    info.ID = Reader[0].ToString(); //组套代码 
                    info.Name = Reader[1].ToString();//组套名称1
                    info.deptCode = Reader[2].ToString();//科室代码2
                    info.spellCode = Reader[3].ToString();//拼音码3 
                    info.inputCode = Reader[5].ToString();//自定义码5
                    info.WBCode = Reader[4].ToString();//五笔码4
                    info.reMark = Reader[6].ToString(); //备注6
                    info.IsShare = Reader[7].ToString();// --是否共享,0是，1否7
                    info.OwnRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8]);//自费比例 
                    info.PayRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[9]);//自付比例9
                    info.PubRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[10].ToString());//公费比例10
                    info.EcoRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[11]);//优惠比例11
                    info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[12].ToString()));//停用标志12
                    info.operCode = Reader[13].ToString();//操作员13

                    List.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = "Exami.ChkGroup.GetAllGroups" + ee.Message;
                this.ErrCode = ee.Message;
                WriteErr();
                return null;
            }
            return List;
        }
        #endregion 

        #region 公有函数
        /// <summary>
        /// 获取所有组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryAllGroups()
        {
            string strSql = "";
            if (this.Sql.GetSql("Exami.ChkGroup.GetAllGroups", ref strSql) == -1) return null;
            return QueryGroup(strSql);
            //return List;
        }

        /// <summary>
        /// 根据组套ID获取组套信息
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.PhysicalExamination.Group GetGroupByGroupID(string GroupID)
        {
            string strSql = "";
            Neusoft.HISFC.Models.PhysicalExamination.Group info = new Neusoft.HISFC.Models.PhysicalExamination.Group();
            string TempStr = GetGroupSql();
            if (TempStr == null)
            {
                return null;
            }
            if (this.Sql.GetSql("Exami.ChkGroup.GetAllGroups.where.2", ref strSql) == -1) return null;
            strSql = string.Format(strSql, GroupID);
            //获取SQL 
            strSql = TempStr + strSql;

            ArrayList list = this.QueryGroup(strSql);
            if (list == null)
            {
                return null;
            }
            if (list.Count == 0)
            {
                return info;
            }
            return (Neusoft.HISFC.Models.PhysicalExamination.Group)list[0];
            
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertGroup(Neusoft.HISFC.Models.PhysicalExamination.Group info)
        {
            string strSql = "";
            try
            {
                if (this.Sql.GetSql("Exami.ChkGroup.InsertInToComGroup", ref strSql) == -1) return -1;
                string OperCode = this.Operator.ID;
                return this.ExecNoQuery(strSql, GetParam(info));
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateGroup(Neusoft.HISFC.Models.PhysicalExamination.Group info)
        {
            string strSql = "";
            try
            {
                //update fin_com_group set GROUP_NAME ='{0}',SPELL_COD ='{1}',INPUT_CODE='{2}',GROUP_KIND='{3}',DEPT_CODE=(select dept_code from com_department where dept_name ='{4}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]') ,SORT_ID ={5},VALID_FLAG ='{6}',REMARK ='{7}',OPER_CODE ='{8}' where GROUP_ID ='{9}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码]'
                if (this.Sql.GetSql("Exami.ChkGroup.ModefyComGroup", ref strSql) == -1) return -1;
                string OperCode = this.Operator.ID;
              
                return this.ExecNoQuery(strSql, GetParam(info));
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public int DeleteGroup(Neusoft.HISFC.Models.PhysicalExamination.Group com)
        {
            string strSql = "";
            try
            {
                //delete fin_com_group where group_id = '{0}'
                if (this.Sql.GetSql("Exami.ChkGroup.DeleteComGroup", ref strSql) == -1) return -1;
                strSql = string.Format(strSql, com.ID);
                if (this.ExecNoQuery(strSql) == -1) return -1;
            }
            catch (Exception ee)
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
            string strSql = "";

            if (Sql.GetSql("Exami.ChkGroupDetail.DeleteDataInfo", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, groupID);
                if (ExecNoQuery(strSql) == -1) return -1;
            }
            catch (Exception e)
            {
                this.Err = "Exami.ChkGroup.DeleteDetails!" + e.Message;
                WriteErr();
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 按科室获取所有有效组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryValidGroupList(string deptID)
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
            string TempStr = GetGroupSql();
            if (TempStr == null)
            {
                return null;
            }
            if (this.Sql.GetSql("Exami.ChkGroup.GetAllGroups.where.1", ref strSql) == -1) return null;
            strSql = TempStr + strSql;
            strSql = string.Format(strSql, deptID);
            return QueryGroup(strSql);
        }

        /// <summary>
        /// 按科室获取所有组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryAllGroupListByDeptID(string deptID)
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

            string TempStr = GetGroupSql();
            if (TempStr == null)
            {
                return null;
            }
            if (this.Sql.GetSql("Exami.ChkGroup.GetAllGroups.where.5", ref strSql) == -1) return null;
            strSql = string.Format(strSql, deptID);
            strSql = TempStr + strSql;
            return QueryGroup(strSql);
            
        }
        /// <summary>
        /// 得到新的ID
        /// </summary>
        /// <returns></returns>
        public string GetGroupID()
        {
            string ID = "";
            string strSql = "";  //select seq_comgroupid.nextval from dual
            if (this.Sql.GetSql("Manager.ComGroup.getGroupID", ref strSql) == -1) return null;
            try
            {
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    ID = Reader[0].ToString();
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return "";
            }
            return ID;
        }
        #endregion  
    }
}
