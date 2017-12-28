using System;
using System.Collections.Generic;

namespace UFC.Operation
{
    public interface IArrangePrint : Neusoft.NFC.Interface.Forms.IReportPrinter 
    {
        DateTime Date { set; }
        
        string Title { set; }

        void AddAppliction(Neusoft.HISFC.Object.Operation.OperationAppllication appliction);
        void Reset();

        EnumArrangeType ArrangeType
        {
            get;
            set;
        }


    }
    public enum EnumArrangeType
    {
        /// <summary>
        /// 手术安排
        /// </summary>
        Operation,
        /// <summary>
        /// 麻醉安排
        /// </summary>
        Anaesthesia
    }
}
