using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Interface.Registration
{
    public delegate void GetRegisterHander(ref Neusoft.HISFC.Models.Registration.Register reg);
    public interface INurseArrayRegister
    {
        Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get;
            set;
        }
        event GetRegisterHander OnGetRegister;
    }
}
