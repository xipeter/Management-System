using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病历分区护理站维护]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007/09/13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class CaseSubarea : Neusoft.FrameWork.Models.NeuObject
    {
        public CaseSubarea()
        {
        }

        private Neusoft.FrameWork.Models.NeuObject subArea = new Neusoft.FrameWork.Models.NeuObject();

        private Neusoft.FrameWork.Models.NeuObject nurseStation = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 分区
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SubArea
        {
            get
            {
                return this.subArea;
            }
            set
            {
                this.subArea = value;
            }
        }


        /// <summary>
        /// 护理站
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseStation
        {
            get
            {
                return this.nurseStation;
            }
            set
            {
                this.nurseStation = value;
            }
        }

        /// <summary>
        /// 复制新对象
        /// </summary>
        /// <returns></returns>
        public new CaseSubarea Clone()
        {
            CaseSubarea cb = base.Clone() as CaseSubarea;

            cb.subArea = this.subArea.Clone();
            cb.nurseStation = this.nurseStation.Clone();

            return cb;
        }
    }
}
