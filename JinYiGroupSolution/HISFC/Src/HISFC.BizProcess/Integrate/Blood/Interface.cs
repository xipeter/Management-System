using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.Blood
{
   
    /// <summary>
    /// Ñª¿â´òÓ¡µ¥¾Ý
    /// </summary>
    public interface IBloodprint
    {
        int PrintBloodOutput(Neusoft.HISFC.Models.Blood.BloodApply apply,
           ArrayList match, ArrayList store);
    }
}
