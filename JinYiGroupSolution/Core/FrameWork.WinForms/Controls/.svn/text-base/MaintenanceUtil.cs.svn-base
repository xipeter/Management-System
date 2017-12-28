using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// [功能描述: 维护控件设置]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    internal class MaintenanceUtil
    {
        static MaintenanceUtil()
        {
            dict.Add("NeuGroupID", HIS.GroupID);
        }
        private static Dictionary<string, string> dict = new Dictionary<string, string>();

        public static string GenSQL(string sql)
        {
            string ret=sql;
            foreach(string s in dict.Keys)
            {
                ret = ret.Replace(s, dict[s]);
            }

            return ret;
        }
    }

    internal static class HIS
    {
        public static string GroupID = "REG";
        public static string OperatorID = "Robin";
        public static string OperateDate = "sysdate";
    };
}
