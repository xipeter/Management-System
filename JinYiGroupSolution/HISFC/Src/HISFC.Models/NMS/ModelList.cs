using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述: 护理模板明细实体类]<br></br>
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
    public class ModelList : Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

	    /// <summary>
	    /// 构造函数(ID:明细表流水号)
	    /// </summary>
        public ModelList()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

	    #endregion 构造函数

        #region 变量

        /// <summary>
        /// 模板主表流水号
        /// </summary>
        private string modelMainID;

        /// <summary>
        /// 护理项目分类信息（分类流水号、分类名称、分类分数标识、分类分数值、分类备注）
        /// </summary>
        private KindInfo kindInfo = new KindInfo();

        /// <summary>
        /// 护理项目信息（项目流水号、项目顺序号、项目名称、项目类型、取值范围、项目单位、项目分数、项目查询码、是否可编辑、项目备注）
        /// </summary>
        private NMSKindItem kindItemInfo = new NMSKindItem();       

        #endregion

        #region 属性

        /// <summary>
        /// 模板主表流水号
        /// </summary>
        public string ModelMainID
        {
            get
            {
                return modelMainID;
            }
            set
            {
                modelMainID = value;
            }
        }

        /// <summary>
        /// 护理项目分类信息（分类流水号、分类名称、分类分数标识、分类分数值、分类备注）
        /// </summary>
        public KindInfo KindInfo
        {
            get
            {
                return kindInfo;
            }
            set
            {
                kindInfo = value;
            }
        }     

        /// <summary>
        /// 护理项目信息（项目流水号、项目顺序号、项目名称、项目类型、取值范围、项目单位、项目分数、项目查询码、是否可编辑、项目备注）
        /// </summary>
        public NMSKindItem KindItemInfo
        {
            get
            {
                return kindItemInfo;
            }
            set
            {
                kindItemInfo = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new ModelList Clone()
        {
            ModelList modelList = base.Clone() as ModelList;
            modelList.KindInfo = this.kindInfo.Clone();
            modelList.KindItemInfo = this.kindItemInfo.Clone();

            return modelList;
        }

        #endregion
    }
}
