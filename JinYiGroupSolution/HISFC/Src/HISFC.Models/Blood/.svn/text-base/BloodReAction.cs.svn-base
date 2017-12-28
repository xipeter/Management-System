using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.Blood
{
    /// <summary>
    /// [功能描述: 输血反映]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-4-19]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public class BloodReAction : Spell, ISort, IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BloodReAction()
        {
        }

        #region 字段
        /// <summary>
        /// ISort
        /// </summary>
        private int iSort;

        /// <summary>
        /// IValid
        /// </summary>
        private bool iValid;

        /// <summary>
        /// 申请号，血袋号
        /// </summary> 
        private Neusoft.HISFC.Object.Blood.BloodMatchRecord bloodMatch = new BloodMatchRecord();

        /// <summary>
        /// 填报医生，填报时间
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment reportDoctor = new OperEnvironment();

        /// <summary>
        /// 填报者
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment reportPerson = new OperEnvironment();

        /// <summary>
        /// 复核者
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment reportCheckPerson = new OperEnvironment();

        /// <summary>
        /// 输血至发生反映时间
        /// </summary>
        private string bloodToReActionTime;

        /// <summary>
        /// 脉搏
        /// </summary>
        private string bloodPulse;

        /// <summary>
        /// 血压
        /// </summary>
        private string bloodPress;

        /// <summary>
        /// 输入量
        /// </summary>
        private decimal bloodInputQty;

        /// <summary>
        /// 是否发热
        /// </summary>
        private bool ibloodFever;

        /// <summary>
        /// 是否头晕
        /// </summary>
        private bool ibloodSwirl;

        /// <summary>
        /// 是否心悸
        /// </summary>
        private bool ibloodHeart;

        /// <summary>
        /// 是否伤口渗血
        /// </summary>
        private bool ibloodWound;

        /// <summary>
        /// 是否气急
        /// </summary>
        private bool ibloodBreath;

        /// <summary>
        /// 是否面色苍白
        /// </summary>
        private bool ibloodFaceWhilt;

        /// <summary>
        /// 是否黄疸
        /// </summary>
        private bool ibloodIcterus;

        /// <summary>
        /// 是否出汗
        /// </summary>
        private bool ibloodPerspire;

        /// <summary>
        /// 是否皮疹
        /// </summary>
        private bool ibloodTetter;

        /// <summary>
        /// 是否面部潮红、紫绀
        /// </summary>
        private bool ibloodFaceRed;

        /// <summary>
        /// 是否血红蛋白尿
        /// </summary>
        private bool ibloodStalered;

        /// <summary>
        /// 是否恶心、呕吐
        /// </summary>
        private bool ibloodSurfeit;

        /// <summary>
        /// 是否紫癜
        /// </summary>
        private bool ibloodPurple;

        /// <summary>
        /// 是否昏迷
        /// </summary>
        private bool ibloodComa;

        /// <summary>
        /// 是否腰酸背痛
        /// </summary>
        private bool ibloodLumbago;

        /// <summary>
        /// 是否麻疹
        /// </summary>
        private bool ibloodHives;

        /// <summary>
        /// 是否输血处痛、发红
        /// </summary>
        private bool ibloodTranspain;

        /// <summary>
        /// 是否出血
        /// </summary>
        private bool ibloodBleed;

        /// <summary>
        /// 是否尿少尿闭
        /// </summary>
        private bool ibloodStaleLittle;

        /// <summary>
        /// 输血科意见
        /// </summary>
        private string bloodClinicSuggestion;

        /// <summary>
        /// 血站意见
        /// </summary>
        private string bloodStationSuggestion;

        /// <summary>
        /// 其他情况
        /// </summary>
        private string bloodOtherThings;

        #endregion

        #region 属性

        /// <summary>
        /// 申请号，血袋号
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodMatchRecord BloodMatch
        {
            get { return bloodMatch; }
            set { bloodMatch = value; }
        }

        /// <summary>
        /// 填报医生，填报时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment ReportDoctor
        {
            get { return reportDoctor; }
            set { reportDoctor = value; }
        }

        /// <summary>
        /// 填报者
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment ReportPerson
        {
            get { return reportPerson; }
            set { reportPerson = value; }
        }

        /// <summary>
        /// 复核者
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment ReportCheckPerson
        {
            get { return reportCheckPerson; }
            set { reportCheckPerson = value; }
        }

        /// <summary>
        /// 输血至发生反映时间
        /// </summary>
        public string BloodToReActionTime1
        {
            get { return bloodToReActionTime; }
            set { bloodToReActionTime = value; }
        }

        /// <summary>
        /// 脉搏
        /// </summary>
        public string BloodPulse
        {
            get { return bloodPulse; }
            set { bloodPulse = value; }
        }

        /// <summary>
        /// 血压
        /// </summary>
        public string BloodPress
        {
            get { return bloodPress; }
            set { bloodPress = value; }
        }

        /// <summary>
        /// 输入量
        /// </summary>
        public decimal BloodInputQty
        {
            get { return bloodInputQty; }
            set { bloodInputQty = value; }
        }

        /// <summary>
        /// 是否发热
        /// </summary>
        public bool BloodFever
        {
            get { return ibloodFever; }
            set { ibloodFever = value; }
        }

        /// <summary>
        /// 是否头晕
        /// </summary>
        public bool BloodSwirl
        {
            get { return ibloodSwirl; }
            set { ibloodSwirl = value; }
        }

        /// <summary>
        /// 是否心悸
        /// </summary>
        public bool BloodHeart
        {
            get { return ibloodHeart; }
            set { ibloodHeart = value; }
        }

        /// <summary>
        /// 是否伤口渗血
        /// </summary>
        public bool BloodWound
        {
            get { return ibloodWound; }
            set { ibloodWound = value; }
        }

        /// <summary>
        /// 是否气急
        /// </summary>
        public bool BloodBreath
        {
            get { return ibloodBreath; }
            set { ibloodBreath = value; }
        }

        /// <summary>
        /// 是否面色苍白
        /// </summary>
        public bool BloodFaceWhilt
        {
            get { return ibloodFaceWhilt; }
            set { ibloodFaceWhilt = value; }
        }

        /// <summary>
        /// 是否黄疸
        /// </summary>
        public bool BloodIcterus
        {
            get { return ibloodIcterus; }
            set { ibloodIcterus = value; }
        }

        /// <summary>
        /// 是否出汗
        /// </summary>
        public bool BloodPerspire
        {
            get { return ibloodPerspire; }
            set { ibloodPerspire = value; }
        }

        /// <summary>
        /// 是否皮疹
        /// </summary>
        public bool BloodTetter
        {
            get { return ibloodTetter; }
            set { ibloodTetter = value; }
        }

        /// <summary>
        /// 是否面部潮红、紫绀
        /// </summary>
        public bool BloodFaceRed
        {
            get { return ibloodFaceRed; }
            set { ibloodFaceRed = value; }
        }

        /// <summary>
        /// 是否血红蛋白尿
        /// </summary>
        public bool BloodStalered
        {
            get { return ibloodStalered; }
            set { ibloodStalered = value; }
        }

        /// <summary>
        /// 是否恶心、呕吐
        /// </summary>
        public bool BloodSurfeit
        {
            get { return ibloodSurfeit; }
            set { ibloodSurfeit = value; }
        }

        /// <summary>
        /// 是否紫癜
        /// </summary>
        public bool BloodPurple
        {
            get { return ibloodPurple; }
            set { ibloodPurple = value; }
        }

        /// <summary>
        /// 是否昏迷
        /// </summary>
        public bool BloodComa
        {
            get { return ibloodComa; }
            set { ibloodComa = value; }
        }

        /// <summary>
        /// 是否腰酸背痛
        /// </summary>
        public bool BloodLumbago
        {
            get { return ibloodLumbago; }
            set { ibloodLumbago = value; }
        }

        /// <summary>
        /// 是否麻疹
        /// </summary>
        public bool BloodHives
        {
            get { return ibloodHives; }
            set { ibloodHives = value; }
        }

        /// <summary>
        /// 是否输血处痛、发红
        /// </summary>
        public bool BloodTranspain
        {
            get { return ibloodTranspain; }
            set { ibloodTranspain = value; }
        }

        /// <summary>
        /// 是否出血
        /// </summary>
        public bool BloodBleed
        {
            get { return ibloodBleed; }
            set { ibloodBleed = value; }
        }

        /// <summary>
        /// 是否尿少尿闭
        /// </summary>
        public bool BloodStaleLittle
        {
            get { return ibloodStaleLittle; }
            set { ibloodStaleLittle = value; }
        }

        /// <summary>
        /// 输血科意见
        /// </summary>
        public string BloodClinicSuggestion
        {
            get { return bloodClinicSuggestion; }
            set { bloodClinicSuggestion = value; }
        }

        /// <summary>
        /// 血站意见
        /// </summary>
        public string BloodStationSuggestion
        {
            get { return bloodStationSuggestion; }
            set { bloodStationSuggestion = value; }
        }

        /// <summary>
        /// 其他情况
        /// </summary>
        public string BloodOtherThings
        {
            get { return bloodOtherThings; }
            set { bloodOtherThings = value; }
        }

        #endregion

        #region ISort 成员

        public int SortID
        {
            get
            {
                return iSort;
            }
            set
            {
                this.iSort = value;
            }
        }

        #endregion

        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return iValid;
            }
            set
            {
                this.iValid = value;
            }
        }

        #endregion

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new BloodReAction Clone()
        {
            BloodReAction bloodReAction = base.Clone() as BloodReAction;

            bloodReAction.ReportCheckPerson = this.ReportCheckPerson.Clone();
            bloodReAction.ReportDoctor = this.ReportDoctor.Clone();
            bloodReAction.ReportCheckPerson = this.ReportCheckPerson.Clone();
            bloodReAction.BloodMatch = this.BloodMatch.Clone();

            return bloodReAction;
        }
        #endregion
    }
}
