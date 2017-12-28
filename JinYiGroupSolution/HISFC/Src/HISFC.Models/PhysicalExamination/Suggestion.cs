using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.PhysicalExamination
{
    /// <summary>
    /// Suggestion<br></br>
    /// [功能描述: 体检建议保存]<br></br>
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
    public class Suggestion : Neusoft.FrameWork.Models.NeuObject
    { 
        #region 私有变量
        //序列号
        private string seqNO = string.Empty;
        //体检流水号
        private string chkClinicNo = string.Empty; 
        //体检结果
        private string itemValue = string.Empty;
        //体检建议
        private SuggestionRule suggestions = new SuggestionRule();
        //操作员信息
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion 

        #region  共有属性

        /// <summary>
        /// 流水号
        /// </summary>
        public string SeqNO
        {
            get
            {
                return seqNO;
            }
            set
            {
                seqNO = value;
            }
        }

        /// <summary>
        /// 体检流水号
        /// </summary>
        public string ChkClinicNo
        {
            get
            {
                return chkClinicNo;
            }
            set
            {
                chkClinicNo = value;
            }
        }

        /// <summary>
        /// 体检结果
        /// </summary>
        public string ItemValue
        {
            get
            {
                return itemValue;
            }
            set
            {
                itemValue = value;
            }
        }
        /// <summary>
        /// 体检建议
        /// </summary>
        public SuggestionRule Suggestions
        {
            get
            {
                return suggestions;
            }
            set
            {
                suggestions = value;
            }
        }

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
    }
}
