using System;
using System.Collections.Generic;
using System.Text;

namespace UFC.Manager.Classes
{
    /// <summary>
    /// [功能描述: 动态创建实现接口的类]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class UtilInterface
    {
        private static ReportPrintManager rpm = new ReportPrintManager();


        /// <summary>
        /// 创建控件对象
        /// </summary>
        /// <param name="containerType">接口容器控件名称</param>
        /// <param name="interfaceType">接口名称</param>
        /// <param name="index">接口索引</param>
        /// <returns></returns>
        public static object CreateObject(Type containerType,Type interfaceType, int index)
        {
            object ret = null;
            ReportPrint reportPrint = rpm.GetReportPrint(containerType.ToString(), interfaceType.ToString(), index);
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(dllName).CreateInstance(controlName);
            }catch
            {
                return null;
            }

            return ret;
        }

        /// <summary>
        /// 创建控件对象
        /// </summary>
        /// <param name="containerType">接口容器控件名称</param>
        /// <param name="interfaceType">接口名称</param>        
        /// <returns></returns>
        public static object CreateObject(Type containerType, Type interfaceType)
        {
            object ret = null;
            ReportPrint reportPrint = rpm.GetReportPrint(containerType.ToString(), interfaceType.ToString());
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(dllName).CreateInstance(controlName);
            }
            catch
            {
                return null;
            }

            return ret;
        }
    }
}
