using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.PhysicalExamination
{
    /// <summary>
    /// SuggestionRule<br></br>
    /// [功能描述: 体检建议规则]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-06-10]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class SuggestionRule : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid,Neusoft.HISFC.Models.Base.ISpell
    {
        #region 私有变量
        //ID 规则编码
        //Name 规则名称
        private bool isValid = true; //有效标志
        private string spellCode = string.Empty; //拼音码
        private string wbCode = string.Empty;//五笔码
        private string userCode = string.Empty;//自定义码
        private string suggestionValue = string.Empty;//建议
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        #endregion

        #region 共有属性

        /// <summary>
        /// 操作员信息
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
        /// <summary>
        /// 建议
        /// </summary>
        public string SuggestionValue
        {
            get
            {
                return suggestionValue;
            }
            set
            {
                suggestionValue = value;
            }
        }

        #region IValid 成员
        /// <summary>
        /// 有效标志
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

        #region ISpell 成员
        /// <summary>
        /// 拼音码
        /// </summary>
        public string SpellCode
        {
            get
            {
                return spellCode;
            }
            set
            {
                spellCode = value;
            }
        }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string WBCode
        {
            get
            {
                return wbCode;
            }
            set
            {
                wbCode = value;
            }
        }
        /// <summary>
        /// 自定义码
        /// </summary>
        public string UserCode
        {
            get
            {
                return userCode;
            }
            set
            {
                userCode = value;
            }
        }

        #endregion

        #endregion 

        #region 克隆函数
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new SuggestionRule Clone()
        {
            SuggestionRule obj = base.Clone() as SuggestionRule;
            obj.operInfo = this.operInfo.Clone();
            return obj;
        }
        #endregion
    }
}