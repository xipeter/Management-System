using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.BizLogic.HL7
{
    public partial class ucLisResult : UserControl, ILisResult 
    {
        public ucLisResult()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                if (this.dataManager.con.State == ConnectionState.Closed)
                {
                    this.dataManager.con  = new System.Data.OracleClient.OracleConnection();
                    System.Data.OracleClient.OracleConnectionStringBuilder ooo = new System.Data.OracleClient.OracleConnectionStringBuilder();
                    ooo.UserID = "newhis45";
                    ooo.Password = "his";
                    ooo.DataSource = "chcc";
                    this.dataManager.con.ConnectionString = ooo.ToString();
                    this.dataManager.con.Open();
                }
            }
        }

        private LisManagment dataManager = new LisManagment();
        
#region 方法

#endregion
        #region ILisResult 成员

        public int ShowResult(string id)
        {
            string ret = this.dataManager.GetResult(id);
            if (ret == null || ret.Length == 0)
                return -1;

            using(System.IO.StreamWriter sw = System.IO.File.CreateText(Application.StartupPath+"\\lisresult.xml"))
            {
                sw.Write(ret);
                sw.Flush();
            }
            
            
            this.webBrowser1.Navigate(Application.StartupPath + "\\lisresult.xml");
            return 0;
        }

        public bool IsValid(string id)
        {
            return this.dataManager.IsResultExist(id);
        }

        #endregion
    }
}
