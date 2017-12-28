using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述：表格护理呈报考核记录明细表实体]
    /// [创 建 者：张林]
    /// [创建时间：2008-10-7]
    /// [ID:呈报明细表流水号]
    /// </summary>
    [System.Serializable]
    public class CheckList:Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

        /// <summary>
        /// 构造函数[ID:呈报明细表流水号]
        /// </summary>
        public CheckList()
        {
        }

        #endregion

        #region 变量

        /// <summary>
        /// 呈报主表流水号
        /// </summary>
        private string checkMainId;

        /// <summary>
        /// 模板明细(模板明细流水号，模板主表流水号、护理项目分类信息，分类标号，分类显示标记，护理项目信息，项目标号)
        /// </summary>
        private ModelList modelListInfo = new ModelList();

        /// <summary>
        /// 抽查数量(项目类型为抽查)
        /// </summary>
        private string itemPickNum;

        /// <summary>
        /// 抽查不合格数量(项目类型为抽查)
        /// </summary>
        private string itemRejectNum;

        #endregion

        #region 属性

        /// <summary>
        /// 呈报主表(呈报主表流水号)
        /// </summary>
        public string CheckMainId
        {
            get
            {
                return checkMainId;
            }
            set
            {
                checkMainId = value;
            }
        }

        /// <summary>
        /// 模板明细(模板明细流水号，模板主表流水号、护理项目分类信息，分类标号，分类显示标记，护理项目信息，项目标号)
        /// </summary>
        public ModelList ModelListInfo
        {
            get
            {
                return modelListInfo;
            }
            set
            {
                modelListInfo = value;
            }
        }

        /// <summary>
        /// 抽查数量(项目类型为抽查)
        /// </summary>
        public string ItemPickNum
        {
            get
            {
                return itemPickNum;
            }
            set
            {
                itemPickNum = value;
            }
        }

        /// <summary>
        /// 抽查不合格数量(项目类型为抽查)
        /// </summary>
        public string ItemRejectNum
        {
            get
            {
                return itemRejectNum;
            }
            set
            {
                itemRejectNum = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new CheckList Clone()
        {
            CheckList checklist = base.Clone() as CheckList;
            checklist.ModelListInfo= this.modelListInfo.Clone();

            return checklist;
        }

        #endregion


    }
}
