using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// [功能描述: 简单工作流信息类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// </summary>
    [System.Serializable]
    public class WorkFlow : Neusoft.FrameWork.Models.NeuObject
    {
        public WorkFlow()
        {
        }

        #region 变量

        /// <summary>
        /// 主键状态
        /// </summary>
        private string state;

        /// <summary>
        /// 下一状态
        /// </summary>
        private string nextState;

        /// <summary>
        /// 是否需要权限管理
        /// </summary>
        private bool isNeedCompetence;

        /// <summary>
        /// 权限集合
        /// </summary>
        private List<string> competenceList = new List<string>();

        /// <summary>
        /// 参数(属性)集合
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> paramList = new List<Neusoft.FrameWork.Models.NeuObject>();

        #endregion

        #region 属性

        /// <summary>
        /// 主键状态
        /// </summary>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
                this.ID = value;
            }
        }

        /// <summary>
        /// 下一状态
        /// </summary>
        public string NextState
        {
            get
            {
                return this.nextState;
            }
            set
            {
                this.nextState = value;
            }
        }

        /// <summary>
        /// 是否需要权限管理
        /// </summary>
        public bool IsNeedCompetence
        {
            get
            {
                return this.isNeedCompetence;
            }
            set
            {
                this.isNeedCompetence = value;
            }
        }

        /// <summary>
        /// 权限集合
        /// </summary>
        public List<string> CompetenceList
        {
            get
            {
                return this.competenceList;
            }
            set
            {
                this.competenceList = value;
            }
        }

        /// <summary>
        /// 参数(属性)集合
        /// </summary>
        public List<Neusoft.FrameWork.Models.NeuObject> ParamList
        {
            get
            {
                return this.paramList;
            }
            set
            {
                this.paramList = value;                
            }
        }

        #endregion
    }
}
