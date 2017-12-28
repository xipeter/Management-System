using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.ConferenceInfo<br></br>
    /// [功能描述: 学术会议实体 ]<br></br>
    /// [创 建 者: 陈樊]<br></br>
    /// [创建时间: 2008-05-21]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class ConferenceInfo : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        #region 变量

        /// <summary>
        /// 会议开始时间
        /// </summary>
        private DateTime start;

        /// <summary>
        /// 会议结束时间
        /// </summary>
        private DateTime end;

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 会议地点
        /// </summary>
        private string locate = string.Empty;

        /// <summary>
        /// 会议级别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject level = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 论文交流形式
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject paperCommunion = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 论文篇数
        /// </summary>
        private int paperCopies = 0;

        /// <summary>
        /// 会议费来源
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject source = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 会议费
        /// </summary>
        private decimal cost = 0M;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();


        private bool isValid = true;

        #endregion

        #region 属性

        /// <summary>
        /// 会议开始时间
        /// </summary>
        public DateTime Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
            }
        }

        /// <summary>
        /// 会议结束时间
        /// </summary>
        public DateTime End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
            }
        }

        /// <summary>
        /// 会议地点
        /// </summary>
        public string Locate
        {
            get
            {
                return this.locate;
            }
            set
            {
                this.locate = value;
            }
        }

        /// <summary>
        /// 会议级别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        /// <summary>
        /// 论文交流形式
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PaperCommunion
        {
            get
            {
                return this.paperCommunion;
            }
            set
            {
                this.paperCommunion = value;
            }
        }

        /// <summary>
        /// 论文篇数
        /// </summary>
        public int PaperCopies
        {
            get
            {
                return this.paperCopies;
            }
            set
            {
                this.paperCopies = value;
            }
        }

        /// <summary>
        /// 会议费来源
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }

        /// <summary>
        /// 会议费
        /// </summary>
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
            }
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public Base.OperEnvironment OperInfo
        {
            get
            {
                return this.operInfo;
            }
            set
            {
                this.operInfo = value;
            }
        }

        #region IValid 成员

        /// <summary>
        /// 有效性
        /// </summary>
        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        #endregion

        #endregion

        #region 方法

        public new ConferenceInfo Clone()
        {
            ConferenceInfo conferenceInfo = base.Clone() as ConferenceInfo;
            conferenceInfo.Dept = this.Dept.Clone();
            conferenceInfo.Level = this.Level.Clone();
            conferenceInfo.OperInfo = this.OperInfo.Clone();
            conferenceInfo.PaperCommunion = this.Clone();

            return conferenceInfo;
        }

        #endregion
    }
}
