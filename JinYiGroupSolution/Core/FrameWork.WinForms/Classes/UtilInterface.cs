using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Classes
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
        public string Err = "";
        /// <summary>
        /// 创建控件对象
        /// </summary>
        /// <param name="containerType">接口容器控件名称</param>
        /// <param name="interfaceType">接口名称</param>
        /// <param name="index">接口索引</param>
        /// <returns></returns>
        public static object CreateObject(Type containerType, Type interfaceType, int index)
        {
            object ret = null;
            ReportPrint reportPrint = rpm.GetReportPrint(containerType.ToString(), interfaceType.ToString(), index);

            if (reportPrint == null || reportPrint.ReportPrintControls.Count <= 0 || reportPrint.ReportPrintControls[0].DllName == "")
            {
                //("没有对接口进行维护！");
                //需要调用维护界面
                return null;
            }
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            //{0F501BAD-97E7-4717-8EA6-B63ABF728E12}
            if (!dllName.ToLower().EndsWith(".dll"))
                dllName = string.Concat(dllName, ".dll");
            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllName).CreateInstance(controlName);
            }
            catch(Exception ex)
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
            if (reportPrint == null || reportPrint.ReportPrintControls.Count <= 0 || reportPrint.ReportPrintControls[0].DllName == "")
            {
                //System.Windows.Forms.MessageBox.Show("没有对接口进行维护！");
                //需要调用维护界面
                return null;
            }
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            if (!dllName.ToLower().EndsWith(".dll"))
                dllName = string.Concat(dllName, ".dll");

            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllName).CreateInstance(controlName);
            }
            catch (Exception ex)
            { 
                return null;
            }

            return ret;
        }

        /// <summary>
        /// 创建控件对象
        /// </summary>
        /// <typeparam name="T">接口泛型类型</typeparam>
        /// <param name="containerType">接口容器控件名称</param>
        /// <returns>成功接口实例, 失败 null</returns>
        public static T CreateObject<T>(Type containerType) 
        {
            object ret = null;

            ReportPrint reportPrint = rpm.GetReportPrint(containerType.ToString(), typeof(T).ToString());
            if (reportPrint == null || reportPrint.ReportPrintControls.Count <= 0 || reportPrint.ReportPrintControls[0].DllName == "")
            {
                //System.Windows.Forms.MessageBox.Show("没有对接口进行维护！");
                //需要调用维护界面
                return default(T);
            }
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            if (!dllName.ToLower().EndsWith(".dll"))
                dllName = string.Concat(dllName, ".dll");

            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllName).CreateInstance(controlName);
            }
            catch (Exception ex)
            {
                return default(T);
            }

            return (T)ret;
        }

        /// <summary>
        /// 创建控件对象
        /// </summary>
        /// <param name="containerType">接口容器控件名称</param>
        /// <param name="interfaceType">接口名称</param>        
        /// <returns></returns>
        public static object CreateObject(Type containerType, Type interfaceType, Neusoft.FrameWork.Management.Transaction trans)
        {
            rpm.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            object ret = null;
            ReportPrint reportPrint = rpm.GetReportPrint(containerType.ToString(), interfaceType.ToString());
            if (reportPrint == null || reportPrint.ReportPrintControls.Count <= 0 || reportPrint.ReportPrintControls[0].DllName == "")
            {
                //System.Windows.Forms.MessageBox.Show("没有对接口进行维护！");
                //需要调用维护界面
                return null;
            }
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            if (!dllName.ToLower().EndsWith(".dll"))
                dllName = string.Concat(dllName, ".dll");

            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllName).CreateInstance(controlName);
            }
            catch (Exception ex)
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
        public static object CreateObject(Type containerType, Type interfaceType, System.Data.IDbTransaction trans)
        {
            rpm.SetTrans(trans);
            object ret = null;
            ReportPrint reportPrint = rpm.GetReportPrint(containerType.ToString(), interfaceType.ToString());
            if (reportPrint == null || reportPrint.ReportPrintControls.Count <= 0 || reportPrint.ReportPrintControls[0].DllName == "")
            {
                //System.Windows.Forms.MessageBox.Show("没有对接口进行维护！");
                //需要调用维护界面
                return null;
            }
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            if (!dllName.ToLower().EndsWith(".dll"))
                dllName = string.Concat(dllName, ".dll");

            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllName).CreateInstance(controlName);
            }
            catch (Exception ex)
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
        /// <param name="index">接口索引</param>
        /// <returns></returns>
        public static object CreateObject(Type containerType, Type interfaceType, int index, Neusoft.FrameWork.Management.Transaction trans)
        {
            rpm.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            object ret = null;
            ReportPrint reportPrint = rpm.GetReportPrint(containerType.ToString(), interfaceType.ToString(), index);

            if (reportPrint == null || reportPrint.ReportPrintControls.Count <= 0 || reportPrint.ReportPrintControls[0].DllName == "")
            {
                //("没有对接口进行维护！");
                //需要调用维护界面
                return null;
            }
            string dllName = reportPrint.ReportPrintControls[0].DllName;
            string controlName = reportPrint.ReportPrintControls[0].ControlName;
            try
            {
                ret = System.Reflection.Assembly.LoadFrom(Application.StartupPath + "\\" + dllName).CreateInstance(controlName);
            }
            catch (Exception ex)
            { 
                return null;
            }

            return ret;
        }
    }
}
