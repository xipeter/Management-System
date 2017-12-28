using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.FrameWork.WinForms.Classes
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
    public class ReportPrintManager : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 这个要改成静态的就可以实现实时刷新了，但没想好呢，先被非静态吧！
        /// </summary>
        public static  string currenInterfaceProfileTable = string.Empty;

        public string CurrenInterfaceProfileTable
        {
            get {
                if (string.IsNullOrEmpty(currenInterfaceProfileTable)==true)
                {
                    GetCurrenInterfaceProfileTable(ref currenInterfaceProfileTable);
                    if (string.IsNullOrEmpty(currenInterfaceProfileTable)==true )
                    {
                        currenInterfaceProfileTable = @"COM_MAINTENANCE_REPORT_PRINT";
                    }
                }
                return currenInterfaceProfileTable; }

        }
        /// <summary>
        /// 这个要改成静态的就可以实现实时刷新了，但没想好呢，先被非静态吧！
        /// </summary>
        //public static string hosCode = Neusoft.FrameWork.Management.Connection.Hospital.ID;

        //public string HosCode
        //{
        //    get
        //    {
        //        //if (string.IsNullOrEmpty(currenInterfaceProfileTable) == true)
        //        //{
        //        //    GetCurrenInterfaceProfileTable(ref currenInterfaceProfileTable);
        //        //    if (string.IsNullOrEmpty(currenInterfaceProfileTable) == true)
        //        //    {
        //        //        currenInterfaceProfileTable = @"COM_MAINTENANCE_REPORT_PRINT";
        //        //    }
        //        //}
        //        return hosCode;
        //    }

        //}
        public virtual int QueryCurrenInterfaceProfileTable(ref List<NeuObject> listInterfaceProfileTable)
        {
            //listInterfaceProfileTable
            listInterfaceProfileTable = new List<Neusoft.FrameWork.Models.NeuObject>();
            try
            {
                string sql = string.Format(@"select t.TABLE_NAME ,t.PROFILE_NAME,t.IS_IN_USE from COM_INTERFACE_SETTING t ");
                int ret = this.ExecQuery(sql);
                if (ret == -1)
                {
                    //System.Windows.Forms.MessageBox.Show(this.Err);
                    return ret;
                }

                while (this.Reader.Read())
                {
                    //读取第一个
                    Neusoft.FrameWork.Models.NeuObject no = new Neusoft.FrameWork.Models.NeuObject();
                    no.ID = this.Reader[0].ToString();
                    no.Name = this.Reader[1].ToString();
                    no.Memo = this.Reader[2].ToString();
                    listInterfaceProfileTable.Add(no);
                }

                this.Reader.Dispose();
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(this.Err + ex.Message);
            }
            return 0;
        }
        public virtual int GetCurrenInterfaceProfileTable(ref string ipt)
        {
            ipt = string.Empty;
            try
            {
                string sql = string.Format(@"select t.TABLE_NAME ,t.PROFILE_NAME,t.IS_IN_USE from COM_INTERFACE_SETTING t where  t.is_in_use = fun_get_valid()");
                int ret = this.ExecQuery(sql);
                if (ret == -1)
                {
                    //System.Windows.Forms.MessageBox.Show(this.Err);
                    return ret;
                }

                if (this.Reader.Read())
                {
                    //读取第一个
                    ipt = this.Reader[0].ToString();
                }

                this.Reader.Dispose();
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(this.Err + ex.Message);
                
            }
            return 0;
        }
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
        public int InsertData(string containerDllName, string containerDllControl, string printDllName, string printDllControl, int index, string memo, string interfaceName, string containertype, string name, string state)
        {
            string sql = string.Format("insert into " + this.CurrenInterfaceProfileTable + " (CONTAINERDLLNAME,CONTAINERCONTROL,PRINTERDLLNAME,PRINTERCONTROL,PRINTERINDEX,MEMO,INTERFACE,CONTAINERTYPE,NAME,STATE) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')",
                containerDllName, containerDllControl, printDllName, printDllControl, index.ToString(), memo, interfaceName, containertype, name, state);
            return this.ExecNoQuery(sql);


        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="reportPrint"></param>
        /// <returns></returns>
        public int InsertData(ReportPrint reportPrint)
        {
            int ret;
            int i = 0;
            foreach (ReportPrintControl reportPrintControl in reportPrint.ReportPrintControls)
            {

                string sql = string.Format("insert into  " + this.CurrenInterfaceProfileTable + "  (CONTAINERDLLNAME,CONTAINERCONTROL,PRINTERDLLNAME,PRINTERCONTROL,PRINTERINDEX,MEMO,INTERFACE,CONTAINERTYPE,NAME,STATE) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')",
                    reportPrint.ContainerDllName, reportPrint.ContainerContorl, reportPrintControl.DllName, reportPrintControl.ControlName, i.ToString(), reportPrintControl.Memo, reportPrintControl.InterfaceName, reportPrint.ContainerType, reportPrint.Name, reportPrintControl.State);
                ret = this.ExecNoQuery(sql);

                i++;
                if (ret == -1)
                    return -1;
            }

            return 0;
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="reportPrint"></param>
        /// <returns></returns>
        public int InsertCurrenInterfaceProfileTable(List<NeuObject> listInterfaceProfileTable)
        {
            int ret;
            //int i = 0;
            foreach (NeuObject  no in listInterfaceProfileTable)
            {

                string sql = string.Format(@"insert into  COM_INTERFACE_SETTING (
 TABLE_NAME,
  PROFILE_NAME,
  IS_IN_USE              
) values('{0}','{1}','{2}')",no.ID,no.Name,
                    no.Memo);

                ret = this.ExecNoQuery(sql);
                if (ret == -1)
                    return -1;
            }

            return 0;
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
        public int DeleteData(string containerDllName, string containerDllControl, string printDllName, string printDllControl, int index)
        {
            string sql = string.Format("delete  " + this.CurrenInterfaceProfileTable + "  where CONTAINERDLLNAME='{0}' and CONTAINERCONTROL='{1}' and PRINTERDLLNAME='{2}' and PRINTERCONTROL='{3}' and PRINTERINDEX={4} ",
                containerDllName, containerDllControl, printDllName, printDllControl, index.ToString());
            return this.ExecNoQuery(sql);
        }
        public int DeleteData(ReportPrint reportPrint)
        {
            string sql = string.Format("delete  " + this.CurrenInterfaceProfileTable + "  where CONTAINERDLLNAME='{0}' and CONTAINERCONTROL='{1}' ",
                reportPrint.ContainerDllName, reportPrint.ContainerContorl);
            return this.ExecNoQuery(sql);
        }
        public int DeleteCurrenInterfaceProfileTable()
        {
            string sql = string.Format(@"delete COM_INTERFACE_SETTING ");
            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 装载数据
        /// </summary>
        /// <returns></returns>
        public List<ReportPrint> LoadData()
        {
            List<ReportPrint> ret = new List<ReportPrint>();
            List<string> retjudge = new List<string>();
            Dictionary<string, ReportPrint> dic = new Dictionary<string, ReportPrint>();

            string containerDllName = string.Empty;
            string containerControlName = string.Empty;
            string containerType = string.Empty;
            string name = string.Empty;

            string sql = "select * from  " + this.CurrenInterfaceProfileTable + "   order by CONTAINERCONTROL,PRINTERINDEX,PRINTERCONTROL ";
            this.ExecQuery(sql);

            while (this.Reader.Read())
            {
                if (dic.Count == 0)
                {
                    ReportPrint reportPrint = new ReportPrint();
                    reportPrint.ContainerDllName = this.Reader[0].ToString();
                    reportPrint.ContainerContorl = this.Reader[1].ToString();
                    reportPrint.ContainerType = this.Reader[7].ToString();
                    reportPrint.Name = this.Reader[8].ToString();
                    reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString(), this.Reader[6].ToString(), this.Reader[9].ToString());
                    dic.Add(reportPrint.ContainerContorl, reportPrint);

                }
                else
                {
                    if (dic.ContainsKey(this.Reader[1].ToString()))
                    {
                        dic[this.Reader[1].ToString()].Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString(), this.Reader[6].ToString(), this.Reader[9].ToString());
                    }
                    else
                    {
                        ReportPrint reportPrint = new ReportPrint();
                        reportPrint.ContainerDllName = this.Reader[0].ToString();
                        reportPrint.ContainerContorl = this.Reader[1].ToString();
                        reportPrint.ContainerType = this.Reader[7].ToString();
                        reportPrint.Name = this.Reader[8].ToString();
                        reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString(), this.Reader[6].ToString(), this.Reader[9].ToString());
                        dic.Add(reportPrint.ContainerContorl, reportPrint);

                    }

                }
            }

            this.Reader.Dispose();

            foreach (string a in dic.Keys)
            {
                ret.Add(dic[a]);
            }

            return ret;
        }

        /// <summary>
        /// 获得报表打印控件
        /// </summary>
        /// <param name="controlName">控件完整名称</param>
        /// <returns></returns>
        public ReportPrint GetReportPrint(string controlName)
        {
            string sql = string.Format("select * from  " + this.CurrenInterfaceProfileTable + "  where CONTAINERCONTROL='{0}'  order by CONTAINERCONTROL,PRINTERCONTROL,PRINTERINDEX ", controlName);

            return this.GetReportPrintObject(sql);
        }

        /// <summary>
        /// 得到实现接口控件信息
        /// </summary>
        /// <param name="controlName">控件完整名称</param>
        /// <param name="interfaceName">接口完整名称</param>
        /// <param name="index">接口所索引</param>
        /// <returns></returns>
        public ReportPrint GetReportPrint(string controlName, string interfaceName, int index)
        {
            string sql = string.Format("select * from  " + this.CurrenInterfaceProfileTable + "  where CONTAINERCONTROL='{0}' and INTERFACE='{1}' and PRINTERINDEX={2}  order by CONTAINERCONTROL,PRINTERCONTROL,PRINTERINDEX ",
                controlName, interfaceName, index.ToString());

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
            string sql = string.Format("select * from  " + this.CurrenInterfaceProfileTable + "  where CONTAINERCONTROL='{0}' and INTERFACE='{1}'   order by CONTAINERCONTROL,PRINTERCONTROL,PRINTERINDEX ",
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

            int ret = this.ExecQuery(sql);
            if (ret == -1)
            {
                System.Windows.Forms.MessageBox.Show(this.Err);
                return null;
            }

            if (this.Reader.Read())
            {
                //读取第一个
                reportPrint = new ReportPrint();
                reportPrint.ContainerDllName = this.Reader[0].ToString();
                reportPrint.ContainerContorl = this.Reader[1].ToString();
                reportPrint.ContainerType = this.Reader[7].ToString();
                reportPrint.Name = this.Reader[8].ToString();
                reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString(), this.Reader[6].ToString(), this.Reader[9].ToString());

                while (this.Reader.Read())
                {
                    reportPrint.Add(this.Reader[2].ToString(), this.Reader[3].ToString(), short.Parse(this.Reader[4].ToString()), this.Reader[5].ToString(), this.Reader[6].ToString(), this.Reader[9].ToString());
                }
            }

            this.Reader.Dispose();
            return reportPrint;
        }

        public int SaveReportPrintType(Neusoft.FrameWork.Models.NeuObject type)
        {
            int ret = -1;
            string sqlInsert = "insert into COM_REPORTPRINT_TYPE(ID,NAME) values('{0}','{1}')";
            string sqlUpdate = "update COM_REPORTPRINT_TYPE T SET T.NAME='{1}' WHERE T.ID='{0}'";
            if (type.ID == string.Empty || type.ID == null)
            {
                type.ID = this.GetSequence("GET.SEQ_COM_REPORTPRINT_TYPE");
                sqlInsert = string.Format(sqlInsert, type.ID, type.Name);
                ret = this.ExecNoQuery(sqlInsert);
            }
            else
            {
                sqlUpdate = string.Format(sqlUpdate, type.ID, type.Name);
                ret = this.ExecNoQuery(sqlUpdate);

            }
            return ret;
        }

        public List<Neusoft.FrameWork.Models.NeuObject> QueryType()
        {
            List<Neusoft.FrameWork.Models.NeuObject> list = new List<Neusoft.FrameWork.Models.NeuObject>();

            string sql = "select * from COM_REPORTPRINT_TYPE";
            this.ExecQuery(sql);

            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                obj.Name = this.Reader[1].ToString();
                list.Add(obj);
            }

            this.Reader.Close();

            return list;

        }

        public int DeleteType(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string sql = "delete from COM_REPORTPRINT_TYPE where ID='{0}'";
            sql = string.Format(sql, obj.ID);
            int ret = this.ExecNoQuery(sql);
            return ret;
        }

        public int JudgeType(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string sql = "select count(*) from  " + this.CurrenInterfaceProfileTable + "  a ,com_controlargument b where a.containertype='{0}'  or b.kind='{0}'";
            sql = string.Format(sql, obj.ID);
            int ret =this.ExecQuery(sql);
            int count = 0;
            while (this.Reader.Read())
            {
                count =Convert.ToInt32( this.Reader[0].ToString());
            }
            if (count > 0) return -1;
            if (count == 0) return 0;
            if (ret == -1) return -1;
            return ret;
        }
    }
}
