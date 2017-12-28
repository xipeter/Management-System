using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.EPR.Interface
{
    public delegate void ObjectHandle(Neusoft.FrameWork.Models.NeuObject patient);
    /// <summary>
    /// 查找患者接口
    /// </summary>
    public interface ISearchPatient
    {
        event ObjectHandle OnSelectedPatient;
        System.Windows.Forms.Control SearchControl { get;}
    }
}
