using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
    public interface TerminalInterface
    {
        int Reset();

        int ControlValue(Object obj);
        int Print();
    }
}
