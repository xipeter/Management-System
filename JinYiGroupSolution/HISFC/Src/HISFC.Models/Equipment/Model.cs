using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Equipment
{
    [System.Serializable]
    public class Model : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Model()
        { 
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 模板流水号

        /// </summary>
        private string modelBillCode;

        /// <summary>
        /// 模板序号
        /// </summary>
        private int modelSerialCode;

        /// <summary>
        /// 模板分类1卡片查询
        /// </summary>
        private string modelType;

        /// <summary>
        /// 模板名称
        /// </summary>
        private string modelName;

        /// <summary>
        /// 字段代码
        /// </summary>
        private string fieldCode;

        /// <summary>
        /// 字段名称
        /// </summary>
        private string fieldName;

        /// <summary>
        /// 操作符=,<,>,<=,>=,<>,like,not like
        /// </summary>
        private string operSign;

        /// <summary>
        /// 字段值

        /// </summary>
        private string fieldValue;

        /// <summary>
        /// 逻辑操作符and,or
        /// </summary>
        private string operLogic;

        /// <summary>
        /// 操作信息
        /// </summary>
        private OperEnvironment operInfo = new OperEnvironment();

        #endregion

        #region 属性


        /// <summary>
        /// 模板流水号

        /// </summary>
        public string ModelBillCode
        {
            get { return modelBillCode; }
            set { modelBillCode = value; }
        }

        /// <summary>
        /// 模板序号
        /// </summary>
        public int ModelSerialCode
        {
            get { return modelSerialCode; }
            set { modelSerialCode = value; }
        }

        /// <summary>
        /// 模板分类1卡片查询
        /// </summary>
        public string ModelType
        {
            get { return modelType; }
            set { modelType = value; }
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        /// <summary>
        /// 字段代码
        /// </summary>
        public string FieldCode
        {
            get { return fieldCode; }
            set { fieldCode = value; }
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        /// <summary>
        /// 操作符=,<,>,<=,>=,<>,like,not like
        /// </summary>
        public string OperSign
        {
            get { return operSign; }
            set { operSign = value; }
        }

        /// <summary>
        /// 字段值

        /// </summary>
        public string FieldValue
        {
            get { return fieldValue; }
            set { fieldValue = value; }
        }

        /// <summary>
        /// 逻辑操作符and,or
        /// </summary>
        public string OperLogic
        {
            get { return operLogic; }
            set { operLogic = value; }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public OperEnvironment OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new Model Clone()
        {
            Model model = base.Clone() as Model;

            model.operInfo = this.operInfo.Clone();

            return model;
        }

        #endregion
    }
}
