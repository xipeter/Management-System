using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.HL7
{
    /// <summary>
    /// [功能描述: LIS结果接口]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-05-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface ILisResult
    {
        /// <summary>
        /// 按医嘱显示检验结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ShowResult(string id);

        /// <summary>
        /// 检验结果是否已经生成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsValid(string id);
    }
}
