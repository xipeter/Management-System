using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.MedTech.Base
{
    /// <summary>
    /// [功能描述: 医技项目接口]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public interface IPatientItemApply
    {
        /// <summary>
        /// 病人信息实体 ID 就医登记号 门诊 住院 体检 NAME为姓名

        /// </summary>
        Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get;
            set;
        }

        /// <summary>
        /// 项目信息实体
        /// </summary>
        Neusoft.HISFC.Models.Base.DeptItem DeptItem
        {
            get;
            set;
        }

        /// <summary>
        /// 项目数量
        /// </summary>
        decimal Amount
        {
            get;
            set;
        }

        /// <summary>
        /// 医嘱流水号

        /// </summary>
        string OrderExecSequence
        {
            get;
            set;
        }

        /// <summary>
        /// 设备信息
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject Machine
        {
            get;
            set;
        }

        /// <summary>
        /// 操作环境
        /// </summary>
        Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get;
            set;
        }
    }
}
