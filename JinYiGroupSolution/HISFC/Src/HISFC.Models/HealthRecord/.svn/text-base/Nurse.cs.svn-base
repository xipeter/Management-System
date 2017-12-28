using System;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// Nurse 的摘要说明:护理等级信息	ID 操作员编号 Name 操作员姓名
    /// </summary>
    [Serializable]
    public class Nurse : Neusoft.FrameWork.Models.NeuObject
    {
        public Nurse()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 私有变量

        private Neusoft.HISFC.Models.RADT.Patient myPatientInfo = new Neusoft.HISFC.Models.RADT.Patient();
        private Neusoft.FrameWork.Models.NeuObject myNurseInfo = new Neusoft.FrameWork.Models.NeuObject();
        private int exeNumber;
        private string exeUnit;
        private DateTime operDate;

        #endregion

        #region 属性
        /// <summary>
        /// 患者基本信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.Patient PatientInfo
        {
            get { return myPatientInfo; }
            set { myPatientInfo = value; }
        }
        /// <summary>
        /// 护理等级信息 ID 等级编码 Name 等级名称
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseInfo
        {
            get { return myNurseInfo; }
            set { myNurseInfo = value; }
        }
        /// <summary>
        /// 执行数量
        /// </summary>
        public int ExeNumber
        {
            get { return exeNumber; }
            set { exeNumber = value; }
        }
        /// <summary>
        /// 执行单位
        /// </summary>
        public string ExeUnit
        {
            get { return exeUnit; }
            set { exeUnit = value; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate
        {
            get { return operDate; }
            set { operDate = value; }
        }

        #endregion

        #region 公有函数


        public new Nurse Clone()
        {
            Nurse NurseClone = base.MemberwiseClone() as Nurse;

            NurseClone.PatientInfo = this.PatientInfo.Clone();
            NurseClone.myNurseInfo = this.myNurseInfo.Clone();

            return NurseClone;
        }
        #endregion
    }
}
