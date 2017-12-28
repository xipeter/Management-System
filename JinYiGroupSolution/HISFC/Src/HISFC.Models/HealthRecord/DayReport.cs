using System;

namespace Neusoft.HISFC.Models.HealthRecord
{
    /// <summary>
    /// PatientInfo <br></br>
    /// [功能描述: 住院日报实体]<br></br>
    /// [创 建 者: sunm]<br></br>
    /// [创建时间: 2007-07]<br></br>
    /// 
    /// <修改记录
    /// 
    ///		修改人=刘强
    ///		修改时间=2007-7-23
    ///		修改目的=适应业务需要
    ///		修改描述=添加是否已经有记录的属性
    ///  />
    /// </summary>
    [Serializable]
    public class DayReport : Neusoft.FrameWork.Models.NeuObject
    {
        public DayReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量
        private string hasRecord;       
        //日报日期
        private DateTime date_stat;
        //科室
        private Neusoft.FrameWork.Models.NeuObject objDept = new Neusoft.FrameWork.Models.NeuObject();
        //编制内床位数
        private int bed_stand;
        //编制外病床数
        private int bed_nonst;
        //加床数
        private int bed_add;
        //空床数
        private int bed_free;
        //原有病人数
        private int remain_yesterday;
        //常规入院数
        private int in_normal;
        //急诊入院数
        private int in_emc;
        //转入数
        private int in_change;
        //常规出院数
        private int out_normal;
        //24小时内死亡数
        private int dead_in24;
        //24小时外死亡数
        private int dead_out24;
        //恶性肿瘤死亡数
        private int dead_ezs;
        //转出数
        private int out_change;
        //退院人数
        private int withdrawal;
        //病情一般患者
        private int patient_normal;
        //病重患者数
        private int patient_serious;
        //病危患者数
        private int patient_terminally;
        //病床使用率
        private decimal bed_userate;
        //陪护数
        private int tend_num;
        //病理送检数
        private int pa_num;
        //临床病理符合数
        private int clpa_num;
        //记录状态
        private string rec_flag;
        //整理人
        private Neusoft.FrameWork.Models.NeuObject modi_usercd;
        //整理日期
        private DateTime modi_date;
        //实际占床数
        private int bed_guding;
        //出院召回数（不用）
        private int todayin_outchange;
        //未知字段
        private int todayin_inchange;
        //医保人数
        private int yb_num;
        //陪护人数
        private int acc_num;
        //期末实有人数
        private int ban_pnum;
        //护士站
        private Neusoft.FrameWork.Models.NeuObject nurse_station;
        //陪床数
        private int accom_num;
        //褥疮数
        private int bedstore_num;
        //院内感染数
        private int infect_num;
        //输液人数
        private int trans_num;
        //输液反应人数
        private int fecttrans_num;
        //输血人数
        private int blood_num;
        //输血反应人数
        private int fectblood_num;
        //出院召回数
        private int in_back;
        #endregion

        #region 属性
        public string HasRecord
        {
            get
            {
                return hasRecord;
            }
            set
            {
                hasRecord = value;
            }
        }
        /// <summary>
        /// 日报日期
        /// </summary>
        public DateTime DateStat
        {
            get { return this.date_stat; }
            set { this.date_stat = value; }
        }
        /// <summary>
        /// 日报科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get { return this.objDept; }
            set { this.objDept = value; }
        }
        /// <summary>
        /// 编制内床位数
        /// </summary>
        public int BedStandNum 
        {
            get { return this.bed_stand; }
            set { this.bed_stand = value; }
        }
        /// <summary>
        /// 编制外病床数
        /// </summary>
        public int BedNonstNum 
        {
            get { return this.bed_nonst; }
            set { this.bed_nonst = value; }
        }
        /// <summary>
        /// 加床数
        /// </summary>
        public int BedAddNum 
        {
            get { return this.bed_add; }
            set { this.bed_add = value; }
        }
        /// <summary>
        /// 空床数
        /// </summary>
        public int BedFreeNum 
        {
            get { return this.bed_free; }
            set { this.bed_free = value; }
        }
        /// <summary>
        /// 原有病人数
        /// </summary>
        public int RemainYesterdayNum 
        {
            get { return this.remain_yesterday; }
            set { this.remain_yesterday = value; }
        }
        /// <summary>
        /// 常规入院数
        /// </summary>
        public int InNormalNum 
        {
            get { return this.in_normal; }
            set { this.in_normal = value; }
        }
        /// <summary>
        /// 急诊入院数
        /// </summary>
        public int InEmcNum 
        {
            get { return this.in_emc; }
            set { this.in_emc = value; }
        }
        /// <summary>
        /// 转入数
        /// </summary>
        public int InChangeNum 
        {
            get { return this.in_change; }
            set { this.in_change = value; }
        }
        /// <summary>
        /// 常规出院数
        /// </summary>
        public int OutNormalNum 
        {
            get { return this.out_normal; }
            set { this.out_normal = value; }
        }
        /// <summary>
        /// 24小时内死亡数
        /// </summary>
        public int DeadIn24Num 
        {
            get { return this.dead_in24; }
            set { this.dead_in24 = value; }
        }
        /// <summary>
        /// 24小时外死亡数
        /// </summary>
        public int DeadOut24Num 
        {
            get { return this.dead_out24; }
            set { this.dead_out24 = value; }
        }
        /// <summary>
        /// 恶性肿瘤死亡数
        /// </summary>
        public int DeadEzsNum 
        {
            get { return this.dead_ezs; }
            set { this.dead_ezs = value; }
        }
        /// <summary>
        /// 转出数
        /// </summary>
        public int OutChangeNum 
        {
            get { return this.out_change; }
            set { this.out_change = value; }
        }
        /// <summary>
        /// 退院人数
        /// </summary>
        public int WithdrawalNum 
        {
            get { return this.withdrawal; }
            set { this.withdrawal = value; }
        }
        /// <summary>
        /// 病情一般患者
        /// </summary>
        public int PatientNormalNum 
        {
            get { return this.patient_normal; }
            set { this.patient_normal = value; }
        }
        /// <summary>
        /// 病重患者数
        /// </summary>
        public int PatientSeriousNum 
        {
            get { return this.patient_serious; }
            set { this.patient_serious = value; }
        }
        /// <summary>
        /// 病危患者数
        /// </summary>
        public int PatientTerminallyNum 
        {
            get { return this.patient_terminally; }
            set { this.patient_terminally = value; }
        }
        /// <summary>
        /// 病床使用率
        /// </summary>
        public decimal BedUseRate
        {
            get { return this.bed_userate; }
            set { this.bed_userate = value; }
        }
        /// <summary>
        /// 陪护数
        /// </summary>
        public int TendNum 
        {
            get { return this.tend_num; }
            set { this.tend_num = value; }
        }
        /// <summary>
        /// 病理送检数
        /// </summary>
        public int PaNum 
        {
            get { return this.pa_num; }
            set { this.pa_num = value; }
        }
        /// <summary>
        /// 临床病理符合数
        /// </summary>
        public int ClPaNum 
        {
            get { return this.clpa_num; }
            set { this.clpa_num = value; }
        }
        /// <summary>
        /// 记录状态
        /// </summary>
        public string RecFlag 
        {
            get { return this.rec_flag; }
            set { this.rec_flag = value; }
        }
        /// <summary>
        /// 整理人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ModiUser 
        {
            get { return this.modi_usercd; }
            set { this.modi_usercd = value; }
        }
        /// <summary>
        /// 整理日期
        /// </summary>
        public DateTime ModiDate 
        {
            get { return this.modi_date; }
            set { this.modi_date = value; }
        }
        /// <summary>
        /// 实际占床数
        /// </summary>
        public int BedGuding 
        {
            get { return this.bed_guding; }
            set { this.bed_guding = value; }
        }
        /// <summary>
        /// 出院召回数（不用）
        /// </summary>
        public int TodayInoutChange 
        {
            get { return this.todayin_outchange; }
            set { this.todayin_outchange = value; }
        }
        /// <summary>
        /// 未知字段,目前数据库没有注释，暂作为备用字段
        /// </summary>
        public int TodayIninChange 
        {
            get { return this.todayin_inchange; }
            set { this.todayin_inchange = value; }
        }
        /// <summary>
        /// 医保人数
        /// </summary>
        public int YbNum 
        {
            get { return this.yb_num; }
            set { this.yb_num = value; }
        }
        /// <summary>
        /// 陪护人数
        /// </summary>
        public int AccNum 
        {
            get { return this.acc_num; }
            set { this.acc_num = value; }
        }
        /// <summary>
        /// 期末实有人数
        /// </summary>
        public int BanpNum
        {
            get { return this.ban_pnum; }
            set { this.ban_pnum = value; }
        }
        /// <summary>
        /// 护士站
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseStation 
        {
            get { return this.nurse_station; }
            set { this.nurse_station = value; }
        }
        /// <summary>
        /// 陪床数
        /// </summary>
        public int AccomNum 
        {
            get { return this.accom_num; }
            set { this.accom_num = value; }
        }
        /// <summary>
        /// 褥疮数
        /// </summary>
        public int BedStoreNum 
        {
            get { return this.bedstore_num; }
            set { this.bedstore_num = value; }
        }
        /// <summary>
        /// 院内感染数
        /// </summary>
        public int InfectNum 
        {
            get { return this.infect_num; }
            set { this.infect_num = value; }
        }
        /// <summary>
        /// 输液人数
        /// </summary>
        public int TransNum 
        {
            get { return this.trans_num; }
            set { this.trans_num = value; }
        }
        /// <summary>
        /// 输液反应人数
        /// </summary>
        public int FectTransNum 
        {
            get { return this.fecttrans_num; }
            set { this.fecttrans_num = value; }
        }
        /// <summary>
        /// 输血人数
        /// </summary>
        public int BloodNum 
        {
            get { return this.blood_num; }
            set { this.blood_num = value; }
        }
        /// <summary>
        /// 输血反应人数
        /// </summary>
        public int FectBloodNum 
        {
            get { return this.fectblood_num; }
            set { this.fectblood_num = value; }
        }
        /// <summary>
        /// 出院召回数
        /// </summary>
        public int InBackNum 
        {
            get { return this.in_back; }
            set { this.in_back = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new DayReport Clone()
        {
            DayReport myDayReport = base.Clone() as DayReport;
            myDayReport.Dept = this.Dept.Clone();
            myDayReport.ModiUser = this.ModiUser.Clone();
            myDayReport.NurseStation = this.NurseStation.Clone();

            return myDayReport;
        }

        #endregion
    }
}
