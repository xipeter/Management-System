using System;
using System.Collections.Generic;
using System.Text;

namespace UFC.Manager.Classes
{
    /// <summary>
    /// [功能描述: 报表打印维护业务层]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-27]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class ReportPrintManager : Neusoft.NFC.Management.DataBaseManger
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="containerDllName"></param>
        /// <param name="containerDllControl"></param>
        /// <param name="printDllName"></param>
        /// <param name="printDllControl"></param>
        /// <param name="index"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public int InsertData(string containerDllName,string containerDllControl, string printDllName,string printDllControl,int index,string memo, string interfaceName)
        {
            string sql = string.Format("insert into COM_MAINTENANCE_REPORT_PRINT (CONTAINERDLLNAME,CONTAINERCONTROL,PRINTERDLLNAME,PRINTERCONTROL,PRINTERINDEX,MEMO,INTERFACE) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}')",
                containerDllName, containerDllControl, printDllName, printDllControl, index.ToString(), memo);
            return this.ExecNoQuery(sql);
            
            
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="containerDllName"></param>
        /// <param name="containerDllControl"></param>
        /// <param name="printDllName"></param>
        /// <param name="printDllControl"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int DeleteData(string containerDllName,string containerDllControl, string printDllName,string printDllControl,int index)
        {
            string sql = string.Format("delete COM_MAINTENANCE_REPORT_PRINT where CONTAINERDLLNAME='{0}' and CONTAINERCONTROL='{1}' and PRINTERDLLNAME='{2}' and PRINTERCONTROL='{3}' and PRINTERINDEX={4}",
                containerDllName, containerDllControl, printDllName, printDllControl, index.ToString());
            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 装载数据
        /// </summary>
        /// <returns></returns>
        public List<ReportPrint> LoadData()
        {
            List<ReportPrint> ret = new List<ReportPrint>();
            string containerDllName = string.Empty;
            string containerControlName = string.Empty;
            string sql = "select * from COM_MAINTENANCE_REPORT_PRINT order by CONTAINERCONTROL,PRINTERCONTROL,PRINTERINDEX";
            this.ExecQuery(sql);

            if (this.Reader.Read())
            {
                containerDllName = this.Reader[0].ToString();
                containerControlName = this.Reader[1].ToString();

                //读取第一个
                ReportPrint reportPrint = new ReportPrint();
                reportPrint.ContainerDllName = containerDllName;
                reportPrint.ContainerContorl = containerControlName;
                reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString());
                ret.Add(reportPrint);

                //读取后面的数据
                while (this.Reader.Read())
                {
                    if (containerControlName == this.Reader[1].ToString())
                    {
                        reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString());
                    }
                    else
                    {
                        containerDllName = this.Reader[0].ToString();
                        containerControlName = this.Reader[1].ToString();

                        reportPrint = new ReportPrint();
                        reportPrint.ContainerDllName = containerDllName;
                        reportPrint.ContainerContorl = containerControlName;
                        reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString());
                        ret.Add(reportPrint);
                    }

                }
            }
            this.Reader.Dispose();

            return ret;
        }

        /// <summary>
        /// 获得报表打印控件
        /// </summary>
        /// <param name="controlName">控件完整名称</param>
        /// <returns></returns>
        public ReportPrint GetReportPrint(string controlName)
        {            
            string sql = string.Format("select * from COM_MAINTENANCE_REPORT_PRINT where PRINTERCONTROL='{0}' order by CONTAINERCONTROL,PRINTERCONTROL,PRINTERINDEX ", controlName);
            
            return this.GetReportPrintObject(sql);
        }

        /// <summary>
        /// 得到实现接口控件信息
        /// </summary>
        /// <param name="controlName">控件完整名称</param>
        /// <param name="interfaceName">接口完整名称</param>
        /// <param name="index">接口所索引</param>
        /// <returns></returns>
        public ReportPrint GetReportPrint(string controlName,string interfaceName,int index)
        {
            string sql = string.Format("select * from COM_MAINTENANCE_REPORT_PRINT where PRINTERCONTROL='{0}' and INTERFACE='{1}' and PRINTERINDEX={2} order by CONTAINERCONTROL,PRINTERCONTROL,PRINTERINDEX ", 
                controlName,interfaceName,index.ToString());
            
            return this.GetReportPrintObject(sql);

        }

        /// <summary>
        /// 得到实现接口控件信息
        /// </summary>
        /// <param name="controlName">控件完整名称</param>
        /// <param name="interfaceName">接口完整名称</param>
        /// <returns></returns>
        public ReportPrint GetReportPrint(string controlName, string interfaceName)
        {
            string sql = string.Format("select * from COM_MAINTENANCE_REPORT_PRINT where PRINTERCONTROL='{0}' and INTERFACE='{1}' order by CONTAINERCONTROL,PRINTERCONTROL,PRINTERINDEX ",
                controlName, interfaceName);

            return this.GetReportPrintObject(sql);
        }

        /// <summary>
        /// 得到实现接口控件信息
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        private ReportPrint GetReportPrintObject(string sql)
        {
            ReportPrint reportPrint = null;
            string containerDllName = string.Empty;
            string containerControlName = string.Empty;
            
            this.ExecQuery(sql);

            if (this.Reader.Read())
            {
                //读取第一个
                reportPrint = new ReportPrint();
                reportPrint.ContainerDllName = this.Reader[0].ToString();
                reportPrint.ContainerContorl = this.Reader[1].ToString();
                reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString());

                while (this.Reader.Read())
                {
                    reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString());
                }
            }

            this.Reader.Dispose();
            return reportPrint;
        }
    }
}
