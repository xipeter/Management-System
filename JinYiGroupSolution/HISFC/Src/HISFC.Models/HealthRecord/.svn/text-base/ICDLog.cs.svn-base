using System;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// ICDLog 的摘要说明。
    /// </summary>
    [Serializable]
    public class ICDLog : Neusoft.FrameWork.Models.NeuObject
    {
        public ICDLog()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region  私有变量
        private ICD oldICDInfo = new ICD(); //聚合ICD实体,保存变更前信息
        private ICD newICDInfo = new ICD();  //聚合 ICD实体 保存变更后信息
        private string modifyFlag;           // 变更类别 1 增加 2 修改 3 作废;
        private int seqNo;                   //序号,是某个ICD的修改记录的序号,第一次增加,序号为1 以后为最大值加1
        #endregion

        #region  公有属性


        public ICD OldICDInfo
        {
            //聚合ICD实体,保存变更前信息
            get
            {
                return oldICDInfo;
            }
            set
            {
                oldICDInfo = value;
            }
        }

        public ICD NewICDInfo
        {
            //聚合 ICD实体 保存变更后信息
            get
            {
                return newICDInfo;
            }
            set
            {
                newICDInfo = value;
            }
        }

        public string ModifyFlag
        {
            // 变更类别 1 增加 2 修改 3 作废;
            get
            {
                return modifyFlag;
            }
            set
            {
                modifyFlag = value;
            }
        }

        public int SeqNo
        {
            //序号,是某个ICD的修改记录的序号,第一次增加,序号为1 以后为最大值加1
            get
            {
                return seqNo;
            }
            set
            {
                seqNo = value;
            }
        }

        #endregion

        #region  克隆函数
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new ICDLog Clone()
        {
            //克隆函数
            ICDLog icdLog = base.Clone() as ICDLog; // 克隆父类
            icdLog.oldICDInfo = oldICDInfo.Clone(); //变更前信息
            icdLog.newICDInfo = newICDInfo.Clone(); //变更后信息
            return icdLog;
        }
        #endregion
    }
}
