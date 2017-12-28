using System;
using System.Collections.Generic;
using System.Text;

namespace UFC.Manager.Classes
{
    /// <summary>
    /// [功能描述: 报表打印设置实体类]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-27]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class ReportPrint
    {
        public string ContainerDllName;
        public string ContainerContorl;
        public List<ReportPrintControl> ReportPrintControls=new List<ReportPrintControl>();

        public void Add(string dllName, string controlName,short index,string memo)
        {
            ReportPrintControl reportPrintControl = new ReportPrintControl();
            reportPrintControl.DllName = dllName;
            reportPrintControl.ControlName = controlName;
            reportPrintControl.Index = index;
            reportPrintControl.Memo = memo;

            this.ReportPrintControls.Add(reportPrintControl);
        }
    }

    /// <summary>
    /// [功能描述: 报表打印控件实体类]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-27]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class ReportPrintControl
    {
        public string DllName;
        public string ControlName;
        public string InterfaceName;
        public short Index;
        public string Memo;
    };
}
