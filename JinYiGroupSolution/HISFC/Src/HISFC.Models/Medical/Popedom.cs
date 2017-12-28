using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Medical
{
    /// <summary>
    /// Popedom <br></br>
    /// [功能描述: 医疗权限实体类]<br></br>
    /// [创 建 者: 孙久海]<br></br>
    /// [创建时间: 2008-07-23]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class Popedom : NeuObject
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Popedom()
        {

        }

        #region 字段

        /// <summary>
        /// 医生代码
        /// </summary>
        private string emplCode;
        /// <summary>
        /// 医生名称
        /// </summary>
        private string emplName;
        /// <summary>
        /// 权限类型
        /// </summary>
        private NeuObject popedomType = new NeuObject();
        /// <summary>
        /// 权限
        /// </summary>
        private NeuObject popedoms = new NeuObject();
        /// <summary>
        /// 审核标识
        /// </summary>
        private string checkFlag;

        #endregion

        #region 属性


        /// <summary>
        /// 医生代码
        /// </summary>
        public string EmplCode
        {
            get { return emplCode; }
            set { emplCode = value; }
        }
        /// <summary>
        /// 医生名称
        /// </summary>
        public string EmplName
        {
            get { return emplName; }
            set { emplName = value; }
        }
        /// <summary>
        /// 权限类型
        /// </summary>
        public NeuObject PopedomType
        {
            get { return popedomType; }
            set { popedomType = value; }
        }
        /// <summary>
        /// 权限
        /// </summary>
        public NeuObject Popedoms
        {
            get { return popedoms; }
            set { popedoms = value; }
        }
        /// <summary>
        /// 审核标识
        /// </summary>
        public string CheckFlag
        {
            get { return checkFlag; }
            set { checkFlag = value; }
        }

        #endregion

        #region 方法

        public new Popedom Clone()
        {
            Popedom popedom = base.Clone() as Popedom;
            popedom.popedomType = this.popedomType.Clone();
            popedom.popedoms = this.popedoms.Clone();

            return popedom;
        }

        #endregion
    }
}
