using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.PhysicalExamination
{
    /// <summary>
    /// GroupDetail<br></br>
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
    public class GroupDetail : Neusoft.FrameWork.Management.Database
    {
        #region 公有函数
        /// <summary>
        /// 根据科室编码获取所有项目信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryGroupTailByDeptID(string deptCode)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Exami.ChkGroupDetail.GetComGroupTailByDeptCode", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, deptCode);
                this.ExecQuery(strSql);
                List = new ArrayList();
                Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.PhysicalExamination.GroupDetail();
                    info.ID = Reader[0].ToString();
                    info.sequenceNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1]);
                    info.itemCode = Reader[2].ToString();
                    info.drugFlag = Reader[3].ToString();
                    info.deptCode = Reader[4].ToString();
                    info.deptName = Reader[5].ToString();
                    info.qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[6]);
                    info.unitFlag = Reader[7].ToString();
                    info.combNo = Reader[8].ToString();
                    info.reMark = Reader[9].ToString();
                    info.operCode = Reader[10].ToString();
                    info.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[11]);
                    List.Add(info);
                    info = null;
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return null;
            }
            return List;
        }
        /// <summary>
        /// 得到新的ID
        /// </summary>
        /// <returns></returns>
        public string GetGroupID()
        {
            string ID = "";
            string strSql = "";
            if (this.Sql.GetSql("Exami.ChkGroupDetail.getGroupID", ref strSql) == -1) return null;
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
        /// <summary>
        /// 根据组套号获取组套明细
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public ArrayList QueryGroupTailByGroupID(string GroupID)
        {
            string strSql = "";
            if (this.Sql.GetSql("Exami.ChkGroupDetail.GetComGroupTail", ref strSql) == -1) return null;
            strSql = string.Format(strSql, GroupID);
            return  QueryGroupDetail(strSql);
        }
        /// <summary>
        /// 插入一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertGroupTail(Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info)
        {
            string strSql = "";
            try
            {
                if (this.Sql.GetSql("Exami.ChkGroupDetail.InsertDataIntoComGroupTail", ref strSql) == -1) return -1;
                return this.ExecNoQuery(strSql, GetParam(info));
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            
        }
        /// <summary>
        /// 修改一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateGroupTail(Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info)
        {
            string strSql = "";
            try
            {
                if (this.Sql.GetSql("Exami.ChkGroupDetail.ModefyDataIntoComGroupTail", ref strSql) == -1) return -1;
                return this.ExecNoQuery(strSql, GetParam(info));
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            //return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 删除一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int DeleteGroupTail(Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info)
        {
            string strSql = "";
            try
            {
                // delete fin_com_groupdetail where group_id ='{0}' and sequence_no ='{1}' and PARENT_CODE ='[父级编码]' and CURRENT_CODE  ='[本级编码] 
                if (this.Sql.GetSql("Exami.ChkGroupDetail.DeleteDataIntoComGroupTail", ref strSql) == -1) return -1;
                string OperCode = this.Operator.ID;
                strSql = string.Format(strSql, info.ID, info.sequenceNo);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        #endregion 

        #region 私有函数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string[] GetParam(Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info)
        {
            string[] str = new string[]
					{
						info.ID, //组套编码 
						info.SortNum.ToString(),// 序号 
						info.itemCode, //编码  
						info.Spacs, //规格 
						info.qty.ToString(),//开立数量
						info.reMark,//备注
						info.ValidState, //停用标志0在用/1停用
						info.unitFlag,//-项目标志0正常/1卫材/2组套
						info.combNo,//组合号
						info.ChkTime.ToString(),//检测次数
						this.Operator.ID, //操作员
						info.ExecDept.ID,
						info.RealPrice.ToString() //实际价格
					};
            return str;
        }
        /// <summary>
        /// 根据ＳＱＬ获取组套明细　
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList QueryGroupDetail(string strSql)
        {
            ArrayList List = null;
            try
            {
                this.ExecQuery(strSql);
                List = new ArrayList();
                Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.PhysicalExamination.GroupDetail();
                    info.ID = Reader[0].ToString(); //组套编码 
                    info.SortNum = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1]);// 序号 
                    info.itemCode = Reader[2].ToString(); //编码  
                    info.Spacs = Reader[3].ToString(); //规格 
                    info.qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[4]); //开立数量
                    info.reMark = Reader[5].ToString();//备注
                    info.ValidState = Reader[6].ToString(); //停用标志0在用/1停用
                    info.unitFlag = Reader[7].ToString();//-项目标志0正常/1卫材/2组套
                    info.combNo = Reader[8].ToString();//组合号
                    info.ChkTime = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[9]);//检测次数
                    info.operCode = Reader[10].ToString();//操作员
                    info.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[11]);//操作日期
                    info.ExecDept.ID = Reader[12].ToString();//执行科室
                    info.ExecDept.Name = Reader[13].ToString();//执行科室
                    info.RealPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[14].ToString());
                    List.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return null;
            }
            return List;
        }
        #endregion  
    }
}
