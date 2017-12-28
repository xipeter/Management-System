using System;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// Operation 的摘要说明：病案患者手术基本信息
    /// </summary>
    [Serializable]
    public class Operation : Neusoft.HISFC.Models.Base.Spell
    {

        public Operation()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 私有变量

        private Neusoft.FrameWork.Models.NeuObject myOperationInfo = new Neusoft.FrameWork.Models.NeuObject();
        private string operationEnName;

        #endregion

        #region 属性

        /// <summary>
        /// 手术项目信息 ID 手术编码 Name 手术中文名称
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OperationInfo
        {
            get { return myOperationInfo; }
            set { myOperationInfo = value; }
        }
        /// <summary>
        /// 手术英文名称
        /// </summary>
        public string OperationEnName
        {
            get { return operationEnName; }
            set { operationEnName = value; }
        }

        #endregion

        #region 公有函数


        public new Operation Clone()
        {
            Operation OpClone = base.MemberwiseClone() as Operation;

            OpClone.myOperationInfo = this.myOperationInfo.Clone();

            return OpClone;
        }

        #endregion



    }
}
