using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{    
    /// <summary>
    /// Neusoft.HISFC.Models.Science.BookMaking<br></br>
    /// [功能描述:著作信息实体 ]<br></br>
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
    public class BookMaking : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {

        #region 变量 

        private bool isValid = true;

        /// <summary>
        /// 出版社
        /// </summary>
        private string publishingCompany = string.Empty;

        /// <summary>
        /// 出版日期
        /// </summary>
        private DateTime publishingDate;

        /// <summary>
        /// 字数
        /// </summary>
        private int wordNumber = 0;

        /// <summary>
        /// 主编
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject editerChief = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        private string extFile00 = string.Empty;

        private string extFile01 = string.Empty;

        private string extFile02 = string.Empty;

        private string extFile03 = string.Empty;

        #endregion

        #region 属性

        #region IValid 成员

        /// <summary>
        /// 有效性标记
        /// </summary>
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

        /// <summary>
        /// 出版社
        /// </summary>
        public string PublishingCompany
        {
            get
            {
                return this.publishingCompany;
            }
            set
            {
                this.publishingCompany = value;
            }
        }

        /// <summary>
        /// 出版日期
        /// </summary>
        public DateTime PublishingDate
        {
            get
            {
                return this.publishingDate;
            }
            set
            {
                this.publishingDate = value;
            }
        }

        /// <summary>
        /// 字数
        /// </summary>
        public int WordNumber
        {
            get
            {
                return this.wordNumber;
            }
            set
            {
                this.wordNumber = value;
            }
        }

        /// <summary>
        /// 主编
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EditerChief
        {
            get
            {
                return this.editerChief;
            }
            set
            {
                this.editerChief = value;
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

        /// <summary>
        /// 扩展标记
        /// </summary>
        public string ExtFile00
        {
            get
            {
                return this.extFile00;
            }
            set
            {
                this.extFile00 = value;
            }
        }

        /// <summary>
        /// 扩展标记
        /// </summary>
        public string ExtFile01
        {
            get
            {
                return this.extFile01;
            }
            set
            {
                this.extFile01 = value;
            }
        }

        /// <summary>
        /// 扩展标记
        /// </summary>
        public string ExtFile02
        {
            get
            {
                return this.extFile02;
            }
            set
            {
                this.extFile02 = value;
            }
        }

        /// <summary>
        /// 扩展标记
        /// </summary>
        public string ExtFile03
        {
            get
            {
                return this.extFile03;
            }
            set
            {
                this.extFile03 = value;
            }
        }

        #endregion

        #region 方法

        public new BookMaking Clone()
        {
            BookMaking bookmaking = base.Clone() as BookMaking;

            bookmaking.EditerChief = this.EditerChief.Clone();
            bookmaking.Dept = this.Dept.Clone();
            bookmaking.OperInfo = this.OperInfo.Clone();
            
            return bookmaking;

        }

        #endregion
    }
}
