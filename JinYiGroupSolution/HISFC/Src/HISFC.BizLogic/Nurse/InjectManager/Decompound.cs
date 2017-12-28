using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Nurse.InjectManager
{
    /// <summary>
    /// [功能描述: 注射项目分解]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-08-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary> 
    public class Decompound : Neusoft.FrameWork.Management.Database
    {
        public Decompound()
        {
        }

        /// <summary>
        /// 获取注射项目
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <param name="clinicCode">门诊号</param>
        /// <returns>null失败</returns>
        public List<Neusoft.HISFC.Models.Nurse.InjectInfo> QueryItemListByCardNoAndClinicCode(string cardNo, string clinicCode)
        {
            if (cardNo == null || clinicCode == null)
            {
                return null;
            }
            string strsql = "";
            if (this.Sql.GetSql("INJECT_QUERY_CARD_CLINIC", ref strsql) == -1)
            {
                this.Err = "INJECT_QUERY_CARD_CLINIC  " + this.Sql.Err;
                return null;
            }
            try
            {
                strsql = string.Format(strsql, cardNo, clinicCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }

            Neusoft.HISFC.Models.Nurse.InjectInfo items;
            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = new List<Neusoft.HISFC.Models.Nurse.InjectInfo>();

            try
            {
                while (this.Reader.Read())
                {
                    items = new Neusoft.HISFC.Models.Nurse.InjectInfo();
                    items.Order.ReciptNO = this.Reader.IsDBNull(0) ? "" : this.Reader[0].ToString();//处方号

                    items.Order.SequenceNO = this.Reader.IsDBNull(2) ? 1 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());//处方内顺号

                    items.Order.ID = this.Reader.IsDBNull(1) ? "" : this.Reader[2].ToString();//医嘱流水号MO_Order
                    items.Order.Combo.ID = this.Reader.IsDBNull(3) ? "" : this.Reader[3].ToString();//组合号


                    items.Order.Item.ID = this.Reader.IsDBNull(4) ? "" : this.Reader[4].ToString();//项目编码
                    items.Order.Item.Name = this.Reader.IsDBNull(5) ? "" : this.Reader[5].ToString();//项目名称

                    items.Order.Item.Specs = this.Reader.IsDBNull(6) ? "" : this.Reader[6].ToString();//规格
                    items.Order.Item.Qty = this.Reader.IsDBNull(7) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[7].ToString());//数量

                    items.Quality.ID = this.Reader.IsDBNull(8) ? "" : this.Reader[8].ToString();//药品性质
                    items.Quality.Name = this.Reader.IsDBNull(9) ? "" : this.Reader[9].ToString();//药品性质名称

                    items.Dosage.ID = this.Reader.IsDBNull(10) ? "" : this.Reader[10].ToString();//剂型
                    items.Dosage.Name = this.Reader.IsDBNull(11) ? "" : this.Reader[11].ToString();//剂型名称

                    items.Order.Frequency.ID = this.Reader.IsDBNull(12) ? "" : this.Reader[12].ToString();//频次编码
                    items.Order.Frequency.Name = this.Reader.IsDBNull(13) ? "" : this.Reader[13].ToString();//频次名称
                    items.Order.Usage.ID = this.Reader.IsDBNull(14) ? "" : this.Reader[14].ToString();//用法编码
                    items.Order.Usage.Name = this.Reader.IsDBNull(15) ? "" : this.Reader[15].ToString();//用法名称
                    items.Order.InjectCount = this.Reader.IsDBNull(16) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[16].ToString());//院注次数
                    items.Order.DoseOnce = this.Reader.IsDBNull(17) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());//一次用量

                    items.Order.DoseUnit = this.Reader.IsDBNull(18) ? "" : this.Reader[18].ToString();//一次用量单位                    

                    items.BaseDose = this.Reader.IsDBNull(19) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());//基本剂量

                    items.Order.Item.PackQty = this.Reader.IsDBNull(20) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());//包装数量                    
                    items.IsMainDrug = this.Reader.IsDBNull(21) ? false : Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[21].ToString());//是否主药

                    items.GlassNum = this.Reader.IsDBNull(22) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[22].ToString());//分瓶数量

                    items.User01 = items.Order.InjectCount.ToString();//可退数量
                    items.User02 = "0";     //已经确认数量

                    //items.Order.Patient.PID.CardNO = this.Reader.IsDBNull(23) ? "" : this.Reader[23].ToString();//病历号

                    //items.Order.Patient.PID.CaseNO = this.Reader.IsDBNull(24) ? "" : this.Reader[24].ToString();//门诊流水号


                    itemList.Add(items);
                }
            }
            catch (Exception ex)
            {
                this.Reader.Close();
                this.Err = ex.Message;
                return null;
            }
            this.Reader.Close();
            return itemList;
        }

        /// <summary>
        /// 保存预约注射信息[注射登记窗口使用]
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns>1,成功；-1失败</returns>
        public int InsertPrecontractInejctItem(List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList)
        {
            if (itemList == null || itemList.Count == 0)
            {
                return -1;
            }
            string str = "";
            if (this.Sql.GetSql("INJECT_INSERT", ref str) == -1)
            {
                this.Err = "INJECT_INSERT  " + this.Sql.Err;
                return -1;
            }

            string cardNo = this.GetInjectCardID().PadLeft(12, '0');// = this.GetInjectCardID().PadLeft(12, '0');//注射单号
            int group = 0;
            try
            {
                foreach (Neusoft.HISFC.Models.Nurse.InjectInfo inject in itemList)
                {
                    string strsql = str;
                    string sequence = this.GetMainInjectSequenct().PadLeft(12, '0');//表流水号
                    if (group >= inject.Order.InjectCount)
                    {
                        group = 0;
                        cardNo = this.GetInjectCardID().PadLeft(12, '0');
                    }
                    //if (inject.PrecontractOrder != "")
                    //{
                    //    //number = inject.PrecontractOrder;
                    //    cardNo = this.GetInjectCardID().PadLeft(12, '0');
                    //}

                    strsql = string.Format(strsql,
                                            sequence,
                                            cardNo,
                                            inject.Order.Patient.Name,
                                            inject.Order.Patient.Sex.Name,
                                            inject.Order.Patient.Birthday.ToShortDateString(),
                                            inject.Order.Patient.PID.CardNO/*病历号*/,
                                            inject.Order.Patient.PID.CaseNO/*门诊流水号*/,
                                            inject.Order.RegTime.ToString(),
                                            ""/*挂号科室编码*/,
                                            ""/*挂号科室名称*/,
                                            inject.Order.ReciptDept.ID,
                                            inject.Order.ReciptDept.Name,
                                            inject.Order.ReciptDoctor.ID,
                                            inject.Order.ReciptDoctor.Name,
                                            inject.Order.ReciptNO,
                                            inject.Order.SequenceNO,
                                            inject.Order.ID,/*医嘱流水号*/
                                            inject.GlassNum.ToString(),
                                            inject.Order.Combo.ID,
                                            inject.Order.Item.ID,
                                            inject.Order.Item.Name,
                                            inject.Order.Item.Specs,
                                            inject.Order.Item.Qty.ToString(),
                                            inject.Quality.ID,
                                            inject.Dosage.ID,
                                            inject.Order.Frequency.ID,
                                            inject.Order.Frequency.Name,
                                            inject.Order.Usage.ID,
                                            inject.Order.Usage.Name,
                                            inject.Order.InjectCount.ToString(),
                                            inject.Order.DoseOnce.ToString(),
                                            inject.Order.DoseUnit,
                                            inject.BaseDose.ToString(),
                                            inject.Order.Item.PackQty.ToString(),
                                            (inject.IsMainDrug ? "1" : "0"),
                                            inject.Name/*注射次数*/,
                                            inject.PrecontractDate.ToString(),
                                            inject.PrecontractOrder,
                                            inject.InjectType,
                                            inject.InjectTypeNumber,
                                            "0",/**/
                                            inject.OperEnv.ID,
                                            inject.OperEnv.Name,
                                            inject.OperEnv.OperTime.ToString(),
                                            ""/*备注*/,
                                            inject.User01,
                                            inject.User02);
                    if (this.ExecNoQuery(strsql) <= 0)
                    {
                        return -1;
                    }
                    strsql = "";
                    group++;

                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 1;

        }

        /// <summary>
        /// 根据病历号，日期得到患者本次注射信息,状态为：0
        /// 注射状态  0预约,1配药,2注射,3取消,4报到,5巡视,6拔针
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <param name="date">注射日期</param>
        /// <returns>null失败</returns>
        public List<Neusoft.HISFC.Models.Nurse.InjectInfo> QueryInjectItem(string cardNo, DateTime date)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT_GETINJECTINFO_BY_CARDNO_DATE", ref strsql) == -1)
            {
                this.Err = "得到INJECT_GETINJECTINFO_BY_CARDNO_DATE语句失败";
                return null;
            }
            try
            {
                strsql = string.Format(strsql, cardNo, date.ToShortDateString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = new List<Neusoft.HISFC.Models.Nurse.InjectInfo>();
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Nurse.InjectInfo inject = new Neusoft.HISFC.Models.Nurse.InjectInfo();
                    inject.ID = this.Reader.IsDBNull(0) ? "" : this.Reader[0].ToString();//表流水号
                    inject.Memo = this.Reader.IsDBNull(1) ? "" : this.Reader[1].ToString();//注射单号

                    inject.Order.Patient.Name = this.Reader.IsDBNull(2) ? "" : this.Reader[2].ToString();//患者姓名

                    inject.Order.Patient.Sex.Name = this.Reader.IsDBNull(3) ? "" : this.Reader[3].ToString();//性别
                    inject.Order.Patient.Birthday = this.Reader.IsDBNull(4) ? DateTime.MinValue : Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());

                    inject.Name = this.Reader.IsDBNull(5) ? "" : this.Reader[5].ToString();//注射次数，比如第一次注射，没有地方，用NAME存

                    inject.PrecontractDate = this.Reader.IsDBNull(6) ? DateTime.MinValue : Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//预约注射日期
                    inject.PrecontractOrder = this.Reader.IsDBNull(7) ? "" : this.Reader[7].ToString();//预约注射序号
                    inject.InjectType = this.Reader.IsDBNull(8) ? "" : this.Reader[8].ToString();//注射类型
                    inject.InjectTypeNumber = this.Reader.IsDBNull(9) ? "" : this.Reader[9].ToString();//注射类型序号

                    inject.Order.Item.Name = this.Reader.IsDBNull(10) ? "" : this.Reader[10].ToString();//项目名称
                    inject.Order.Item.Specs = this.Reader.IsDBNull(11) ? "" : this.Reader[11].ToString();//规格
                    inject.Order.DoseOnce = this.Reader.IsDBNull(12) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString());//一次用量

                    inject.Order.DoseUnit = this.Reader.IsDBNull(13) ? "" : this.Reader[13].ToString();//一次用量单位

                    inject.GlassNum = this.Reader.IsDBNull(14) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14].ToString());//接瓶数


                    inject.Order.Usage.Name = this.Reader.IsDBNull(15) ? "" : this.Reader[15].ToString();// 用法名称
                    inject.Order.Frequency.ID = this.Reader.IsDBNull(16) ? "" : this.Reader[16].ToString();//频次代码
                    inject.Order.Frequency.Name = this.Reader.IsDBNull(17) ? "" : this.Reader[17].ToString();//频次名称

                    inject.Order.Qty = this.Reader.IsDBNull(18) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18].ToString());//开立数量

                    inject.BaseDose = this.Reader.IsDBNull(19) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());//基本剂量
                    inject.Order.Item.PackQty = this.Reader.IsDBNull(20) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());//包装数量
                    inject.Quality.Name = this.Reader.IsDBNull(21) ? "" : this.Reader[21].ToString();//药品性质
                    inject.Dosage.Name = this.Reader.IsDBNull(22) ? "" : this.Reader[22].ToString();//剂型
                    inject.IsMainDrug = this.Reader.IsDBNull(23) ? false : Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[23].ToString());//是否主药

                    inject.Order.ReciptNO = this.Reader.IsDBNull(24) ? "" : this.Reader[24].ToString();//处方号
                    inject.Order.ReciptSequence = this.Reader.IsDBNull(25) ? "" : this.Reader[25].ToString();//处方内流水号
                    inject.Order.Patient.PID.CaseNO = this.Reader.IsDBNull(26) ? "" : this.Reader[26].ToString();//病历号
                    inject.Order.Patient.PID.CardNO = this.Reader.IsDBNull(27) ? "" : this.Reader[27].ToString();//门诊号

                    inject.User01 = this.Reader.IsDBNull(28) ? "" : this.Reader[28].ToString();//可退数量
                    inject.User02 = this.Reader.IsDBNull(29) ? "" : this.Reader[29].ToString();//已确认数量

                    inject.Order.InjectCount = this.Reader.IsDBNull(30) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[30].ToString());//院注次数


                    itemList.Add(inject);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.Reader.Close();
                return null;
            }
            this.Reader.Close();
            return itemList;
        }

        /// <summary>
        /// 更新注射项目状态[配药窗口使用]
        /// </summary>
        /// <param name="recordID">表ID</param>
        /// <returns>-1失败，1成功</returns>
        public int UpdateInjectItemState(Neusoft.HISFC.Models.Nurse.InjectInfo inject)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT_UPDATE_RECORDID", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,
                                       inject.User01,
                                       inject.User02,
                                       inject.Order.ReciptNO,
                                       inject.Order.ReciptSequence);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 获取已经配药的注射项目，配药状态为：1
        /// 注射状态  0预约,1配药,2注射,3取消,4报到,5巡视,6拔针
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <param name="date">日期</param>
        /// <returns>null失败</returns>
        public List<Neusoft.HISFC.Models.Nurse.InjectInfo> QueryAlreadyDosageInjectItem(string cardNo, DateTime date)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT.INJECTCONFIRM.QUERY.CARDNO.DATE", ref strsql) == -1)
            {
                this.Err = "得到INJECT.INJECTCONFIRM.QUERY.CARDNO.DATE语句失败";
                return null;
            }
            try
            {
                strsql = string.Format(strsql, cardNo, date.ToShortDateString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = new List<Neusoft.HISFC.Models.Nurse.InjectInfo>();
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Nurse.InjectInfo inject = new Neusoft.HISFC.Models.Nurse.InjectInfo();
                    inject.ID = this.Reader.IsDBNull(0) ? "" : this.Reader[0].ToString();//表流水号
                    inject.Memo = this.Reader.IsDBNull(1) ? "" : this.Reader[1].ToString();//注射单号

                    inject.Order.Patient.Name = this.Reader.IsDBNull(2) ? "" : this.Reader[2].ToString();//患者姓名

                    inject.Order.Patient.Sex.Name = this.Reader.IsDBNull(3) ? "" : this.Reader[3].ToString();//性别
                    inject.Order.Patient.Birthday = this.Reader.IsDBNull(4) ? DateTime.MinValue : Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());

                    inject.Name = this.Reader.IsDBNull(5) ? "" : this.Reader[5].ToString();//注射次数，比如第一次注射，没有地方，用NAME存

                    inject.PrecontractDate = this.Reader.IsDBNull(6) ? DateTime.MinValue : Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//预约注射日期
                    inject.PrecontractOrder = this.Reader.IsDBNull(7) ? "" : this.Reader[7].ToString();//预约注射序号
                    inject.InjectType = this.Reader.IsDBNull(8) ? "" : this.Reader[8].ToString();//注射类型
                    inject.InjectTypeNumber = this.Reader.IsDBNull(9) ? "" : this.Reader[9].ToString();//注射类型序号

                    inject.Order.Item.Name = this.Reader.IsDBNull(10) ? "" : this.Reader[10].ToString();//项目名称
                    inject.Order.Item.Specs = this.Reader.IsDBNull(11) ? "" : this.Reader[11].ToString();//规格
                    inject.Order.DoseOnce = this.Reader.IsDBNull(12) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString());//一次用量

                    inject.Order.DoseUnit = this.Reader.IsDBNull(13) ? "" : this.Reader[13].ToString();//一次用量单位

                    inject.GlassNum = this.Reader.IsDBNull(14) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14].ToString());//接瓶数


                    inject.Order.Usage.Name = this.Reader.IsDBNull(15) ? "" : this.Reader[15].ToString();// 用法名称
                    inject.Order.Frequency.ID = this.Reader.IsDBNull(16) ? "" : this.Reader[16].ToString();//频次代码
                    inject.Order.Frequency.Name = this.Reader.IsDBNull(17) ? "" : this.Reader[17].ToString();//频次名称

                    inject.Order.Qty = this.Reader.IsDBNull(18) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18].ToString());//开立数量

                    inject.BaseDose = this.Reader.IsDBNull(19) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());//基本剂量
                    inject.Order.Item.PackQty = this.Reader.IsDBNull(20) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());//包装数量
                    inject.Quality.Name = this.Reader.IsDBNull(21) ? "" : this.Reader[21].ToString();//药品性质
                    inject.Dosage.Name = this.Reader.IsDBNull(22) ? "" : this.Reader[22].ToString();//剂型
                    inject.IsMainDrug = this.Reader.IsDBNull(23) ? false : Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[23].ToString());//是否主药

                    inject.Order.ReciptNO = this.Reader.IsDBNull(24) ? "" : this.Reader[24].ToString();//处方号
                    inject.Order.ReciptSequence = this.Reader.IsDBNull(25) ? "" : this.Reader[25].ToString();//处方内流水号
                    inject.Order.Patient.PID.CaseNO = this.Reader.IsDBNull(26) ? "" : this.Reader[26].ToString();//病历号
                    inject.Order.Patient.PID.CardNO = this.Reader.IsDBNull(27) ? "" : this.Reader[27].ToString();//门诊号

                    inject.User01 = this.Reader.IsDBNull(28) ? "" : this.Reader[28].ToString();//可退数量
                    inject.User02 = this.Reader.IsDBNull(29) ? "" : this.Reader[29].ToString();//已确认数量

                    inject.Order.InjectCount = this.Reader.IsDBNull(30) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[30].ToString());//院注次数


                    itemList.Add(inject);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.Reader.Close();
                return null;
            }
            this.Reader.Close();
            return itemList;
        }

        /// <summary>
        /// 更新已经配药的注射项目的状态，状态为：2[注射窗口使用]
        /// 注射状态  0预约,1配药,2注射,3取消,4报到,5巡视,6拔针
        /// </summary>
        /// <param name="inject">实体</param>
        /// <returns>-1失败，1成功</returns>
        public int UpdateAlreadyDosageInjectItemState(Neusoft.HISFC.Models.Nurse.InjectInfo inject)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT.INJECTCONFIRM.UPDATE", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,
                                       inject.Order.ReciptNO,
                                       inject.Order.ReciptSequence);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 根据病历号，日期得到已经预约的患者的次注射信息,状态为：0
        /// 注射状态  0预约,1配药,2注射,3取消,4报到,5巡视,6拔针
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <param name="date">注射日期</param>
        /// <returns>null失败</returns>
        public List<Neusoft.HISFC.Models.Nurse.InjectInfo> QueryAlreadyPrecontractInjectItem(string cardNo, DateTime date)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT_GETAlreadyPrecontractPatient_BY_CARDNO_DATE", ref strsql) == -1)
            {
                this.Err = "得到INJECT_GETAlreadyPrecontractPatient_BY_CARDNO_DATE语句失败";
                return null;
            }
            try
            {
                strsql = string.Format(strsql, cardNo, date.ToShortDateString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.Nurse.InjectInfo> itemList = new List<Neusoft.HISFC.Models.Nurse.InjectInfo>();
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Nurse.InjectInfo inject = new Neusoft.HISFC.Models.Nurse.InjectInfo();
                    inject.ID = this.Reader.IsDBNull(0) ? "" : this.Reader[0].ToString();//表流水号
                    inject.Memo = this.Reader.IsDBNull(1) ? "" : this.Reader[1].ToString();//注射单号

                    inject.Order.Patient.Name = this.Reader.IsDBNull(2) ? "" : this.Reader[2].ToString();//患者姓名


                    inject.Order.Patient.Sex.Name = this.Reader.IsDBNull(3) ? "" : this.Reader[3].ToString();//性别
                    inject.Order.Patient.Birthday = this.Reader.IsDBNull(4) ? DateTime.MinValue : Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());

                    inject.Name = this.Reader.IsDBNull(5) ? "" : this.Reader[5].ToString();//注射次数，比如第一次注射，没有地方，用NAME存


                    inject.PrecontractDate = this.Reader.IsDBNull(6) ? DateTime.MinValue : Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//预约注射日期
                    inject.PrecontractOrder = this.Reader.IsDBNull(7) ? "" : this.Reader[7].ToString();//预约注射序号
                    inject.InjectType = this.Reader.IsDBNull(8) ? "" : this.Reader[8].ToString();//注射类型
                    inject.InjectTypeNumber = this.Reader.IsDBNull(9) ? "" : this.Reader[9].ToString();//注射类型序号

                    inject.Order.Item.Name = this.Reader.IsDBNull(10) ? "" : this.Reader[10].ToString();//项目名称
                    inject.Order.Item.Specs = this.Reader.IsDBNull(11) ? "" : this.Reader[11].ToString();//规格
                    inject.Order.DoseOnce = this.Reader.IsDBNull(12) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString());//一次用量


                    inject.Order.DoseUnit = this.Reader.IsDBNull(13) ? "" : this.Reader[13].ToString();//一次用量单位


                    inject.GlassNum = this.Reader.IsDBNull(14) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14].ToString());//接瓶数



                    inject.Order.Usage.Name = this.Reader.IsDBNull(15) ? "" : this.Reader[15].ToString();// 用法名称
                    inject.Order.Frequency.ID = this.Reader.IsDBNull(16) ? "" : this.Reader[16].ToString();//频次代码
                    inject.Order.Frequency.Name = this.Reader.IsDBNull(17) ? "" : this.Reader[17].ToString();//频次名称

                    inject.Order.Qty = this.Reader.IsDBNull(18) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18].ToString());//开立数量


                    inject.BaseDose = this.Reader.IsDBNull(19) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());//基本剂量
                    inject.Order.Item.PackQty = this.Reader.IsDBNull(20) ? 0 : Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());//包装数量
                    inject.Quality.Name = this.Reader.IsDBNull(21) ? "" : this.Reader[21].ToString();//药品性质
                    inject.Dosage.Name = this.Reader.IsDBNull(22) ? "" : this.Reader[22].ToString();//剂型
                    inject.IsMainDrug = this.Reader.IsDBNull(23) ? false : Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[23].ToString());//是否主药

                    inject.Order.ReciptNO = this.Reader.IsDBNull(24) ? "" : this.Reader[24].ToString();//处方号

                    inject.Order.ReciptSequence = this.Reader.IsDBNull(25) ? "" : this.Reader[25].ToString();//处方内流水号
                    inject.Order.Patient.PID.CaseNO = this.Reader.IsDBNull(26) ? "" : this.Reader[26].ToString();//病历号

                    inject.Order.Patient.PID.CardNO = this.Reader.IsDBNull(27) ? "" : this.Reader[27].ToString();//门诊号


                    inject.User01 = this.Reader.IsDBNull(28) ? "" : this.Reader[28].ToString();//可退数量
                    inject.User02 = this.Reader.IsDBNull(29) ? "" : this.Reader[29].ToString();//已确认数量


                    inject.Order.InjectCount = this.Reader.IsDBNull(30) ? 0 : Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[30].ToString());//院注次数


                    itemList.Add(inject);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.Reader.Close();
                return null;
            }
            this.Reader.Close();
            return itemList;
        }

        /// <summary>
        /// 更新已经预约的注射项目状态为报到状态
        /// </summary>
        /// <param name="inject">注射实体</param>
        /// <returns>-1失败，1成功</returns>
        public int UpdateAlreadyPrecontractInjectItem(Neusoft.HISFC.Models.Nurse.InjectInfo inject)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT_UPDATE_ALREADYPRECONTRACTITEM", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,
                                       inject.Order.ReciptNO,
                                       inject.Order.ReciptSequence);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 得到表流水号
        /// </summary>
        /// <returns>表流水号</returns>
        private string GetMainInjectSequenct()
        {
            return this.GetSequence("INJECT_GETSEQ_SEQUENCE");
        }

        /// <summary>
        /// 得到注射单号
        /// </summary>
        /// <returns>注射单号</returns>
        private string GetInjectCardID()
        {
            return this.GetSequence("INJECT_GETSEQ_INJECTCARDID");
        }
    }
}
