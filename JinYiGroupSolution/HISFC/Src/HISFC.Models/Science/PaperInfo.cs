using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.PaperInfo<br></br>
    /// [功能描述:论文信息实体 ]<br></br>
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
    public class PaperInfo : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {

        #region 变量

        /// <summary>
        /// 有效性标记
        /// </summary>
        private bool isValid = false;

        /// <summary>
        /// 发表刊物
        /// </summary>
        private string publiction = string.Empty;

        /// <summary>
        /// 卷
        /// </summary>
        private string volume = string.Empty;

        /// <summary>
        /// 期
        /// </summary>
        private string period = string.Empty;

        /// <summary>
        /// 页
        /// </summary>
        private string page = string.Empty;

        /// <summary>
        /// 发表日期
        /// </summary>
        private DateTime publicDate;

        /// <summary>
        /// 作者
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject author = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 专科
        /// </summary>
        private string specialDept = string.Empty;

        /// <summary>
        /// 论文级别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject level = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 论文类别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject kind = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 论文来源
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject source = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        


        #endregion

        #region 属性

        /// <summary>
        /// 发表刊物
        /// </summary>
        public string Publiction
        {
            get
            {
                return this.publiction;
            }
            set
            {
                this.publiction = value;
            }
        }

        /// <summary>
        /// 卷
        /// </summary>
        public string Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                this.volume = value;
            }
        }

        /// <summary>
        /// 期
        /// </summary>
        public string Period
        {
            get
            {
                return this.period;
            }
            set
            {
                this.period = value;
            }
        }

        /// <summary>
        /// 页
        /// </summary>
        public string Page
        {
            get
            {
                return this.page;
            }
            set
            {
                this.page = value;
            }
        }

        /// <summary>
        /// 发表日期
        /// </summary>
        public DateTime PublicDate
        {
            get
            {
                return this.publicDate;
            }
            set
            {
                this.publicDate = value;
            }
        }

        /// <summary>
        /// 作者
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
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
        /// 专科
        /// </summary>
        public string SpecialDept
        {
            get
            {
                return this.specialDept;
            }
            set
            {
                this.specialDept = value;
            }
        }

        /// <summary>
        /// 论文级别
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
        /// 论文类别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }

        /// <summary>
        /// 论文来源
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

        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion

        #endregion

        #region 方法

        public new PaperInfo Clone()
        {
            PaperInfo paperInfo = base.Clone() as PaperInfo;

            paperInfo.Author = this.Author.Clone();
            paperInfo.Dept = this.Dept.Clone();
            paperInfo.Kind = this.Kind.Clone();
            paperInfo.Level = this.Level.Clone();
            paperInfo.OperInfo = this.OperInfo.Clone();
            paperInfo.Source = this.Source.Clone();

            return paperInfo;
        }

        #endregion

    }
}
