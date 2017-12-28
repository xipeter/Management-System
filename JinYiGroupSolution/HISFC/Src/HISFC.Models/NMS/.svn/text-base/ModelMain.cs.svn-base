using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述: 护理模板实体类]<br></br>
    /// [创 建 者: 侯伟标]<br></br>
    /// [创建时间: 2008-10-07]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class ModelMain : Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

	    /// <summary>
        /// 构造函数 (ID:模板主表流水号，Name:模板名称)
	    /// </summary>
        public ModelMain()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

	    #endregion 构造函数

        #region 变量

        /// <summary>
        /// 模板副标题
        /// </summary>
        private string modelSubName;
        
        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private bool validFlag;
        
        /// <summary>
        /// 模板查询码
        /// </summary>
        private string modelSpell;
        
        /// <summary>
        /// 模板类型:1一般呈报,2不良呈报,3个人考核,4病区考核,5科室考核
        /// </summary>
        private string modelType;
        
        /// <summary>
        /// 表头说明
        /// </summary>
        private string headerMark;
        
        /// <summary>
        /// 页脚说明
        /// </summary>
        private string footerMark;
        
        /// <summary>
        /// 操作环境信息（操作员编码、操作时间）
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 模板副标题
        /// </summary>
        public string ModelSubName
        {
            get 
            {
                return modelSubName; 
            }
            set 
            {
                modelSubName = value;
            }
        }

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        public bool ValidFlag
        {
            get 
            {
                return validFlag; 
            }
            set 
            {
                validFlag = value; 
            }
        }

        /// <summary>
        /// 模板查询码
        /// </summary>
        public string ModelSpell
        {
            get
            {
                return modelSpell;
            }
            set
            {
                modelSpell = value;
            }
        }

        /// <summary>
        /// 模板类型:1一般呈报,2不良呈报,3个人考核,4病区考核,5科室考核
        /// </summary>
        public string ModelType
        {
            get
            {
                return modelType;
            }
            set
            {
                modelType = value;
            }
        }

        /// <summary>
        /// 表头说明
        /// </summary>
        public string HeaderMark
        {
            get
            {
                return headerMark;
            }
            set
            {
                headerMark = value;
            }
        }

        /// <summary>
        /// 页脚说明
        /// </summary>
        public string FooterMark
        {
            get
            {
                return footerMark;
            }
            set
            {
                footerMark = value;
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
        public new ModelMain Clone()
        {
            ModelMain modelMain = base.Clone() as ModelMain;
            modelMain.OperInfo = this.operInfo.Clone();
            return modelMain;
        }

        #endregion
    }
}
