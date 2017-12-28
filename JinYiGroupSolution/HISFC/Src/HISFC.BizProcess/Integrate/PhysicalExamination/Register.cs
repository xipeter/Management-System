using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Management.PhysicalExamination.Enum;
namespace Neusoft.HISFC.Integrate.PhysicalExamination
{
    class Register : IntegrateBase
    {
        #region 变量
        //体检登记管理类
        protected static Neusoft.HISFC.Management.PhysicalExamination.Register mgrReg = new Neusoft.HISFC.Management.PhysicalExamination.Register();
        #endregion

        #region 基本信息
        #region 事务
        /// <summary>
        /// 事务
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            mgrReg.SetTrans(trans);
        }
        #endregion 

        #region 查询一段时间内体检人员信息 返回 动态数组
        /// <summary>
        /// 查询一段时间内体检人员信息 返回 动态数组
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
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
        /// <param name="CardNo"></param>
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
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
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
        public int AddOrUpdate(Neusoft.HISFC.Object.PhysicalExamination.Register register)
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
        protected int DeleteInfo(Neusoft.HISFC.Object.PhysicalExamination.Register register)
        {
            this.SetDB(mgrReg);
            return mgrReg.DeleteInfo(register);
        }
        #endregion
        #endregion

        #region 人员信息登记
        #region 获取某个时间段内的体检人员信息 返回 DataSet
        /// <summary>
        /// 获取某个时间段内的体检人员信息 返回 DataSet 
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
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
        public int GetRegisterPatient(string beginTime, string endTime, string ID, ref System.Data.DataSet ds, ExamType type)
        {
            this.SetDB(mgrReg);
            return mgrReg.GetRegisterPatient(beginTime, endTime, ID, ref ds, type);
        }
        #endregion

        #region 根据体检号获取体检登记信息
        /// <summary>
        /// 根据体检号获取体检登记信息
        /// </summary>
        /// <param name="ClinicNO">体检号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Object.PhysicalExamination.Register GetRegisterByClinicNO(string clinicNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.GetRegisterByClinicNO(clinicNO);
        }
        #endregion

        #region 根据卡号查询
        /// <summary>
        /// 根据卡号查询登记信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByCardNO(string cardNo)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryRegisterByCardNO(cardNo);
        }
        /// <summary>
        /// 根据卡号获取个人体检和集体体检登记人员信息 划价用
        /// </summary>
        /// <param name="CollectivityCode">集体体检号</param>
        /// <param name="CardNo">卡号</param>
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
        /// <param name="ChkNO"></param>
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
        /// <param name="Register"></param>
        /// <returns></returns>
        public int AddOrUpdateRegister(Neusoft.HISFC.Object.PhysicalExamination.Register register)
        {
            this.SetDB(mgrReg);
            return mgrReg.AddOrUpdateRegister(register);
        }
        #endregion

        #region 删除一行数据
        /// <summary>
        /// 根据体检流水号 删除一行数据
        /// </summary>
        /// <param name="ClinicNo"></param>
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
        /// <param name="strCompCode"></param>
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
        /// <param name="CollectivityCode"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByCollectivityCode(string collectivityCode)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryRegisterByCollectivityCode(collectivityCode);
        }
        #endregion

        #region 根据集体体检号获取该体检人员信息
        /// <summary>
        /// 根据集体体检号获取该体检人员信息
        /// </summary>
        /// <param name="CollectivityCode"></param>
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
        /// </summary>
        /// <param name="obj">要确认的实体</param>
        /// <returns></returns>
        public int UpdateConfirmInfo(Neusoft.HISFC.Object.PhysicalExamination.ItemList obj)
        {
            this.SetDB(mgrReg);
            return mgrReg.UpdateConfirmInfo(obj);
        }
        /// <summary>
        /// 更新确认数量
        /// </summary>
        /// <param name="moOrder"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int UpdateConfirmAmount(string moOrder, decimal confirmNum)
        {
            this.SetDB(mgrReg);
            return mgrReg.UpdateConfirmAmount(moOrder, confirmNum);
        }
                #endregion

        #region  获取体检明细
        /// <summary>
        /// 获取体检明细
        /// </summary>
        /// <param name="ClinicNo"></param>
        /// <returns></returns>
        public ArrayList QueryItemListByClinicNO(string clinicNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.QueryItemListByClinicNO(clinicNO);
        }
        /// <summary>
        /// 根据流水号获取体检项目明细
        /// </summary>
        /// <param name="SequenceNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Object.PhysicalExamination.ItemList GetItemListBySequence(string sequenceNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.GetItemListBySequence(sequenceNO);
        }
        #endregion

        #region 删除某一条体检明细
        /// <summary>
        /// 某一条体检明细
        /// </summary>
        /// <param name="SeqenceNo"></param>
        /// <returns></returns>
        public int DeleteItemListBySeqenceNO(string seqenceNO)
        {
            this.SetDB(mgrReg);
            return mgrReg.DeleteItemListBySeqenceNO(seqenceNO);
        }
        #endregion
        #endregion 
    }
}
