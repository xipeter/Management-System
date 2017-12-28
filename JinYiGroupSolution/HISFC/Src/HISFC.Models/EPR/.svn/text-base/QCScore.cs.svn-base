
namespace Neusoft.HISFC.Models.EPR
{
    /// <summary>
    /// QCScoreSet 的摘要说明。
    /// </summary>
    [System.Serializable]
    public class QCScore : Neusoft.FrameWork.Models.NeuObject
    {
        public QCScore()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        private Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return this.myPatientInfo;
            }
            set
            {
                this.myPatientInfo = value;
            }
        }
        private string type;
        /// <summary>
        /// 项目类别
        /// </summary>
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        private string totalScore;
        /// <summary>
        /// 项目类别总分值
        /// </summary>
        public string TotalScore
        {
            get
            {
                return this.totalScore;
            }
            set
            {
                this.totalScore = value;
            }
        }
        private string miniScore;
        /// <summary>
        /// 最小分值
        /// </summary>
        public string MiniScore
        {
            get
            {
                return this.miniScore;
            }
            set
            {
                this.miniScore = value;
            }
        }
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public QCScore Clone()
        {
            QCScore score = base.Clone() as QCScore;
            score.PatientInfo = this.PatientInfo.Clone();
            return score;
        }
    }
}