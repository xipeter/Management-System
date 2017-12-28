using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination
{

    public class ExamiManager : IntegrateBase
    {
        #region 变量
        //体检单位管理类
        protected Neusoft.HISFC.BizLogic.PhysicalExamination.Company mgrCompany = new Neusoft.HISFC.BizLogic.PhysicalExamination.Company();
        //体检组套管理类
        protected Neusoft.HISFC.BizLogic.PhysicalExamination.Group mgrGroup = new Neusoft.HISFC.BizLogic.PhysicalExamination.Group();
        //体检组套管理类
        protected Neusoft.HISFC.BizLogic.PhysicalExamination.GroupDetail mgrGroupDetail = new Neusoft.HISFC.BizLogic.PhysicalExamination.GroupDetail();
        //体检组套管理类
        protected Neusoft.HISFC.BizLogic.PhysicalExamination.Register mgrReg = new Neusoft.HISFC.BizLogic.PhysicalExamination.Register();
        #endregion

        #region 组套主表
         /// <summary>
        /// 事务
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            mgrGroup.SetTrans(trans);
            mgrCompany.SetTrans(trans);
            mgrGroupDetail.SetTrans(trans);
            mgrReg.SetTrans(trans);
        }
         
        /// <summary>
        /// 获取所有组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryAllGroups()
        {
            this.SetDB(mgrGroup);
            return mgrGroup.QueryAllGroups();
        }

        /// <summary>
        /// 根据组套ID获取组套信息
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.PhysicalExamination.Group GetGroupByGroupID(string groupID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.GetGroupByGroupID(groupID);
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertGroup(Neusoft.HISFC.Models.PhysicalExamination.Group info)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.InsertGroup(info);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateGroup(Neusoft.HISFC.Models.PhysicalExamination.Group info)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.UpdateGroup(info);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int DeleteGroup(Neusoft.HISFC.Models.PhysicalExamination.Group info)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.DeleteGroup(info);
        }

        /// <summary>
        /// 删除组套所有明细
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int DelGroupDetails(string groupID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.DelGroupDetails(groupID);
        }

        /// <summary>
        /// 按科室获取所有有效组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryValidGroupList(string deptID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.QueryValidGroupList(deptID);
        }

        /// <summary>
        /// 按科室获取所有有效组套
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryAllGroupListByDeptID(string deptID)
        {
            this.SetDB(mgrGroup);
            return mgrGroup.QueryAllGroupListByDeptID(deptID);
        }

        
        #endregion 

        #region 体检组套明细表
        /// <summary>
        /// 根据科室编码获取所有项目信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryGroupTailByDeptID(string deptCode)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.QueryGroupTailByDeptID(deptCode);
        }

        /// <summary>
        /// 得到新的ID
        /// </summary>
        /// <returns></returns>
        public string GetGroupID()
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.GetGroupID();
        }

        public ArrayList QueryGroupTailByGroupID(string groupID)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.QueryGroupTailByGroupID(groupID);
        }

        /// <summary>
        /// 插入一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertGroupTail(Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.InsertGroupTail(info);
        }

        /// <summary>
        /// 修改一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateGroupTail(Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.UpdateGroupTail(info);
        }

        /// <summary>
        /// 删除一条明细
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int DeleteGroupTail(Neusoft.HISFC.Models.PhysicalExamination.GroupDetail info)
        {
            this.SetDB(mgrGroupDetail);
            return mgrGroupDetail.DeleteGroupTail(info);
        }
        #endregion 

        #region 体检单位维护
        #region 查询所有的体检单位信息 返回动态数组
        /// <summary>
        /// 查询所有的体检单位信息 返回动态数组
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryCompany()
        {
            this.SetDB(mgrCompany);
            return mgrCompany.QueryCompany();
        }
        #endregion

        #region 查询某个ID的体检单位信息
        /// <summary>
        /// 查询某个ID的体检单位信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Pharmacy.Company GetCompanyByID(string ID)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.GetCompanyByID(ID);
        }
        #endregion

        #region 增加或删除一行数据
        /// <summary>
        /// 增加或删除一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int AddOrUpdate(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.AddOrUpdate(company);
        }
        #endregion

        #region  删除一行数据
        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int DeleteInfo(Neusoft.HISFC.Models.Pharmacy.Company company)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.DeleteInfo(company);
        }
        #endregion
        #region 是否已经存在
        /// <summary>
        /// 是否
        /// </summary>
        /// <param name="comCode"></param>
        /// <returns>-1 出错 ，1 没有用过 2 用过</returns>
        public int IsExistCompany(string comCode)
        {
            this.SetDB(mgrCompany);
            return mgrCompany.IsExistCompany(comCode);
        }
        #endregion
        #endregion 

        #region 体检基本信息
        #region 查询一段时间内体检人员信息 返回 动态数组
        /// <summary>
        /// 查询一段时间内体检人员信息 返回 动态数组
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ArrayList QueryPatient(string beginTime, string endTime)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryPatient(beginTime, endTime);
        }
        #endregion

        #region 根据卡号获取病人基本信息  注意不是登记信息
        /// <summary>
        /// 根据卡号获取病人基本信息  注意不是登记信息 
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public ArrayList QueryPatient(string cardNo)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryPatient(cardNo);
        }
        #endregion

        #region 获取某个时间段内的体检人员信息 返回 DataSet
        /// <summary>
        /// 获取某个时间段内的体检人员信息 返回 DataSet 
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int QueryPatient(string beginTime, string endTime, ref System.Data.DataSet ds)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryPatient(beginTime, endTime, ref ds);
        }
        #endregion

        #region  增加或修改一行数据
        /// <summary>
        /// 增加或修改一行数据
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public int AddOrUpdate(Neusoft.HISFC.Models.PhysicalExamination.Register register)
        {
            this.SetDB(mgrReg);
            return mgrReg.AddOrUpdate(register);
        }
        #endregion

        #region  删除一行数据
        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="register">体检登记实体</param>
        /// <returns></returns>
        protected int DeleteInfo(Neusoft.HISFC.Models.PhysicalExamination.Register register)
        {
            this.SetDB(mgrReg);
            return mgrReg.DeleteInfo(register);
        }
        #endregion
        #endregion 

        #region 人员信息登记

        #region 查询一段时间内的集体登记信息
        public ArrayList QueryCompanyRegister(string beginDate, string endDate)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryCompanyRegister(beginDate, endDate);
        }
        #endregion 
        #region 获取某个时间段内的体检人员信息 返回 DataSet
        /// <summary>
        /// 获取某个时间段内的体检人员信息 返回 DataSet 
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetRegisterPatient(string beginTime, string endTime, ref System.Data.DataSet ds)
        {
            this.SetDB(mgrReg);
            return mgrReg.GetRegisterPatient(beginTime, endTime, ref ds);
        }
        #endregion

        #region 按编码查询体检人员信息
        /// <summary>
        /// 按编码查询体检人员信息
        /// </summary>
        /// <param name="ID">卡号 或健康档案号,体检单位,姓名 </param>
        /// <param name="ds"></param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public int GetRegisterPatient(string beginTime, string endTime, string ID, ref System.Data.DataSet ds,Neusoft.HISFC.BizLogic.PhysicalExamination.Enum.ExamType type)
        {
            this.SetDB(mgrReg);
            return mgrReg.GetRegisterPatient(beginTime, endTime, ID, ref ds, type);
        }
        #endregion

        #region 根据体检号获取体检登记信息
        /// <summary>
        /// 根据体检号获取体检登记信息
        /// </summary>
        /// <param name="clinicNO">体检号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.PhysicalExamination.Register GetRegisterByClinicNO(string clinicNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.GetRegisterByClinicNO(clinicNO);
        }
        #endregion

        #region 根据卡号查询
        /// <summary>
        /// 根据卡号查询登记信息
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByCardNO(string cardNo)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryRegisterByCardNO(cardNo);
        }
        /// <summary>
        /// 根据卡号获取个人体检和集体体检登记人员信息 划价用
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <returns></returns>
        public ArrayList QueryCollectivityRegisterByCardNO(string cardNo)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryCollectivityRegisterByCardNO(cardNo);
        }
        #endregion

        #region 根据健康档案号查询登记信息
        /// <summary>
        /// 根据健康档案号查询登记信息
        /// </summary>
        /// <param name="archivesNO"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByArchivesNO(string archivesNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryRegisterByArchivesNO(archivesNO);
        }
        #endregion

        #region 增加或更新某行数据
        /// <summary>
        /// 增加或更新某行数据
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public int AddOrUpdateRegister(Neusoft.HISFC.Models.PhysicalExamination.Register register)
        {
            this.SetDB(mgrReg);
            return mgrReg.AddOrUpdateRegister(register);
        }
        #endregion

        #region 删除一行数据
        /// <summary>
        /// 根据体检流水号 删除一行数据
        /// </summary>
        /// <param name="clinicNo"></param>
        /// <returns></returns>
        public int DeleteInfoRegister(string clinicNo)
        {
            this.SetDB(mgrReg);
            return mgrReg.DeleteInfoRegister(clinicNo);
        }

        #endregion

        #region 获取 集体体检
        /// <summary>
        /// 获取集体体检记录
        /// </summary>
        /// <param name="compCode"></param>
        /// <returns></returns>
        public ArrayList QueryCollectivity(string compCode)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryCollectivity(compCode);
        }
        #endregion

        #region 根据集体体检号获取该体检人员信息
        /// <summary>
        /// 根据集体体检号获取该体检人员信息
        /// </summary>
        /// <param name="collectivityCode"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByCollectivityCode(string collectivityCode)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryRegisterByCollectivityCode(collectivityCode);
        }
        #endregion

        #region 根据集体体检号获取该体检单位的历次集体体检号
        /// <summary>
        /// 根据集体体检号获取该体检单位的历次集体体检号
        /// </summary>
        /// <param name="collectivityCode"></param>
        /// <returns></returns>
        public ArrayList QueryCompanyByCollectivityCode(string collectivityCode)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryCompanyByCollectivityCode(collectivityCode);
        }
        #endregion

        #endregion

        #region 费用信息
        #region  更新体检明细的确认人＆确认事件
        /// <summary>
        /// 更新体检明细的确认人＆确认事件
        /// 需要赋值 obj.NoBackQty, obj.SequenceNO, obj.IsConfirm, obj.ConformOper.ID
        /// </summary>
        /// <param name="MoOrder">医嘱流水号</param>
        /// <param name="ConfirmFlag">确认标志 0 未收费,1收费 2 执行</param>
        /// <param name="NoBackQty">可退数量</param>
        /// <returns></returns>
        public int UpdateConfirmInfo(string MoOrder, string ConfirmFlag, int NoBackQty)
        {
            this.SetDB(mgrReg);
            return mgrReg.UpdateConfirmInfo(MoOrder, ConfirmFlag, NoBackQty);
        }
        #endregion

        #region 更新或删除 体检费用明细 如果Qty为零 则删除
        /// <summary>
        /// 更新或删除 体检费用明细 如果 
        /// </summary>
        /// <param name="seqenceNO"></param>
        /// <param name="Qty"></param>
        /// <param name="BackQty"></param>
        /// <returns></returns>
        public int UpdateOrDeleteItemListBySequenceNO(string seqenceNO, int Qty, int BackQty)
        {
            this.SetDB(mgrReg);
            if (Qty == 0)
            {
                return mgrReg.DeleteItemListBySeqenceNO(seqenceNO);
            }
            else
            {
                return mgrReg.UpdateNobackNum(seqenceNO, Qty, BackQty);
            }
        }
        #endregion 
        #region 更新收费标志
        /// <summary>
        /// 更新收费标志
        /// </summary>
        /// <param name="feeFlag">  0 未收费，1，已收费，2作废 </param>
        /// <param name="MoOrder">医嘱流水号</param>
        /// <returns></returns>
        public int UpdateItemListFeeFlagByMoOrder(string feeFlag, string MoOrder)
        {
            this.SetDB(mgrReg);
            return mgrReg.UpdateItemListFeeFlagByMoOrder(feeFlag, MoOrder);
        }
         /// <summary>
        /// 更新收费标志
        /// </summary>
        /// <param name="feeFlag">  0 未收费，1，已收费，2作废 </param>
        /// <param name="RecipeSeq">收费组合号</param>
        /// <returns></returns>
        public int UpdateItemListFeeFlagByRecipeSeq(string feeFlag, string RecipeSeq)
        {
            this.SetDB(mgrReg);
            return mgrReg.UpdateItemListFeeFlagByRecipeSeq(feeFlag, RecipeSeq);
        }
        #endregion
        #region  获取体检明细
        /// <summary>
        /// 获取体检明细
        /// </summary>
        /// <param name="clinicNO"></param>
        /// <returns></returns>
        public ArrayList QueryItemListByClinicNO(string clinicNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryItemListByClinicNO(clinicNO);
        }
        /// <summary>
        /// 根据流水号获取体检项目明细
        /// </summary>
        /// <param name="sequenceNO"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.PhysicalExamination.ItemList GetItemListBySequence(string sequenceNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.GetItemListBySequence(sequenceNO);
        }
        #endregion

        #region 删除某一条体检明细
        /// <summary>
        /// 某一条体检明细
        /// </summary>
        /// <param name="seqenceNO"></param>
        /// <returns></returns>
        public int DeleteItemListBySeqenceNO(string seqenceNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.DeleteItemListBySeqenceNO(seqenceNO);
        }
        #endregion
       
        #endregion 
    }
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum EnumServiceEditTypes
    {
        Add, //增加
        Modify,//修改
        Delete,//删除
        Disuse //废弃
    }
}
