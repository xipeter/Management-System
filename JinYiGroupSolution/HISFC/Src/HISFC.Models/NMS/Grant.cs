using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述: 权限范围分配实体类]<br></br>
    /// [创 建 者: 侯伟标]<br></br>
    /// [创建时间: 2008-10-07]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class Grant : Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

	    /// <summary>
        /// 构造函数 (ID:流水号)
	    /// </summary>
        public Grant()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

	    #endregion 构造函数

        #region 变量

        /// <summary>
        /// 分配人(人员ID)
        /// </summary>
        private string grantOper;

        /// <summary>
        /// 分配类型：1一般呈报，2不良呈报，3个人考核，4病区考核，5科室考核
        /// </summary>
        private string grantType;

        /// <summary>
        /// 被分配人(人员ID)
        /// </summary>
        private string inGrantOper;

        /// <summary>
        /// 被分配病区
        /// </summary>
        private string inGrantWard;

        /// <summary>
        /// 被分配科室
        /// </summary>
        private string inGrantDept;

        /// <summary>
        /// 考核权限:1有,0无
        /// </summary>
        private string writeFlag;

        /// <summary>
        /// 阅读权限:1有,0无
        /// </summary>
        private string readFlag;

        /// <summary>
        /// 操作环境信息（操作员编码、操作时间）
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
        #endregion 

        #region 属性

        /// <summary>
        /// 分配人（人员ID）
        /// </summary>
        public string GrantOper
        {
            get
            {
                return grantOper;
            }
            set
            {
                grantOper = value;
            }
        }

        /// <summary>
        /// 分配类型：1一般呈报，2不良呈报，3个人考核，4病区考核，5科室考核
        /// </summary>
        public string GrantType
        {
            get
            {
                return grantType;
            }
            set
            {
                grantType = value;
            }
        }

        /// <summary>
        /// 被分配人（人员ID）
        /// </summary>
        public string InGrantOper
        {
            get
            {
                return inGrantOper;
            }
            set
            {
                inGrantOper = value;
            }
        }

        /// <summary>
        /// 被分配病区
        /// </summary>
        public string InGrantWard
        {
            get
            {
                return inGrantWard;
            }
            set
            {
                inGrantWard = value;
            }
        }

        /// <summary>
        /// 被分配科室
        /// </summary>
        public string InGrantDept
        {
            get
            {
                return inGrantDept;
            }
            set
            {
                inGrantDept = value;
            }
        }

        /// <summary>
        /// 考核权限:1有,0无
        /// </summary>
        public string WriteFlag
        {
            get
            {
                return writeFlag;
            }
            set
            {
                writeFlag = value;
            }
        }

        /// <summary>
        /// 阅读权限:1有,0无
        /// </summary>
        public string ReadFlag
        {
            get
            {
                return readFlag;
            }
            set
            {
                readFlag = value;
            }
        }

        /// <summary>
        /// 操作环境信息（操作员编码、操作时间）
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Grant Clone()
        {
            Grant grant = base.Clone() as Grant;
            grant.OperInfo = this.operInfo.Clone();

            return grant;
        }

        #endregion
    }
}
