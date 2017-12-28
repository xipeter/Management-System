﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HIS
{
    static class Program
    {
        /// <summary>
        /// 是否有信息框show
        /// </summary>
        public static bool isMessageShow = false;

        /// <summary>
        /// 数据库类型[2007/11/28]
        /// </summary>
        static EnumDBType DBType = EnumDBType.ORACLE;//默认为Oracle

        /// <summary>
        /// 设置主窗口
        /// </summary>
        public static frmMain MainForm = null;

        static string strDataType = "";

        /// <summary>
        /// 是否测试库
        /// </summary>
        internal static bool IsTestDB = false;

        /// <summary>
        /// DB Hos Name
        /// </summary>
        public static string HosName = "";

        /// <summary>
        /// 客户端日志文件上限
        /// </summary>
        private static int maxLocalLogFileSize = 0;

        public static frmMain mainForm = new frmMain();

        /// </summary>
        [STAThread]
        static void Main(params string[] param)
        {
            Application.EnableVisualStyles();

            if (Application.StartupPath.Substring( Application.StartupPath.Length - 1, 1 ) == @"\")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath = Application.StartupPath;
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath = Application.StartupPath + @"\";
            }

            frmSplash splash = new frmSplash();
            splash.Show();
            splash.Refresh();
            Application.DoEvents();

            splash.Msg = "系统正在启动中…正在加载配置";
            splash.Progress = 10;

            string err = "";
            //不存在Remote.config则按照2层结构走，读取配置文件
            if (!System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + "Remote.config"))
            {
                if (Neusoft.FrameWork.Management.Connection.GetSetting(out err) == -1)
                {
                    MessageBox.Show(err);
                    Application.Exit();
                }
            }

            splash.Msg = "正在进行Licence授权校验...";
            splash.Progress = 15;

            string strErr = "";
            if (JudgeHISCryptoKeyFile( ref strErr ) == -1)
            {
                splash.Close();

                MessageBox.Show( strErr, "未授权版本", MessageBoxButtons.OK, MessageBoxIcon.Stop );
                //{9AAC3C1F-70D4-43fb-91C8-2632292F5D1C}
                //Neusoft.FrameWork.Management.Connection.Instance.Close();

                Application.Exit();
            }

            splash.Msg = "正在进行Sql配置加载...";
            splash.Progress = 20;

            if (Neusoft.FrameWork.Management.Connection.Sql == null)
            {
                try
                {

                    System.Collections.ArrayList al = Neusoft.FrameWork.Server.Function.Manager.GetSQL();
                    if (al == null)
                    {
                        MessageBox.Show( Neusoft.FrameWork.Server.Function.Manager.Err );
                        Application.Exit();
                        return;
                    }
                    Neusoft.FrameWork.Management.Connection.Sql = new Neusoft.FrameWork.Management.Sql();
                    try
                    {
                        Neusoft.FrameWork.Management.Connection.Sql.alSql = al[0] as System.Collections.ArrayList;
                        Neusoft.FrameWork.Management.Connection.Sql.table_name = al[1] as System.Collections.ArrayList;
                    }
                    catch (Exception ex)
                    {
                        Program.isMessageShow = false;
                        MessageBox.Show( "FrameWork版本不对！无法获得正确的SQL语句。" + ex.Message );
                        Program.isMessageShow = true;
                    }
                }
                catch
                {
                    return;
                }
            }

            splash.Msg = "系统正在启动中…正在读取语言配置";
            splash.Progress = 80;
            Neusoft.FrameWork.Management.Language l = new Neusoft.FrameWork.Management.Language(
                Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.LanguagePath + Neusoft.FrameWork.WinForms.Classes.Function.LanguageFileName );


            splash.Msg = "系统正在启动中…正在加载登录窗体";
            splash.Progress = 90;

            CreateFolder();

            try
            {
                string errLogFilePath = Application.StartupPath + "\\err.log";
                string sqlLogFilePath = Application.StartupPath + "\\debugSql.log";

                System.IO.FileInfo errLogFs = new System.IO.FileInfo( errLogFilePath );
                System.IO.FileInfo sqlLogFs = new System.IO.FileInfo( sqlLogFilePath );

                if (errLogFs.Exists)
                {
                    if (maxLocalLogFileSize > 0)
                    {
                        if (System.Math.Round( (decimal)errLogFs.Length / 1024, 2 ) > maxLocalLogFileSize)
                        {
                            System.IO.File.Delete( errLogFilePath );
                            System.IO.File.CreateText( errLogFilePath );
                        }
                    }
                }

                if (sqlLogFs.Exists)
                {
                    if (maxLocalLogFileSize > 0)
                    {
                        if (System.Math.Round( (decimal)sqlLogFs.Length / 1024, 2 ) > maxLocalLogFileSize)
                        {
                            System.IO.File.Delete( sqlLogFilePath );
                            System.IO.File.CreateText( sqlLogFilePath );
                        }
                    }
                }              
            }
            catch
            {
            }

            try
            {
                if (param.Length > 0)
                {
                    //传入 用户名，密码 直接登录
                }
                else
                {
                    frmLogin login = new frmLogin();
                    login.lbType.Text = strDataType;
                    login.Show();
                }

                splash.Close();

                Application.Run();
            }
            catch (Exception exception)
            {
                MessageBox.Show( exception.Message );
            }
        }

        #region 开始处理

        const string UrlFileName = "url.xml";
        static string DataSource = "";

        static bool IsSqlInDB = true;

        static string ManagerPWD = "his";
        /// <summary>
        /// 
        /// </summary>
        static string ServerPath = "";

        internal static int ConnectDB()
        {
            if (DataSource.IndexOf( "Provider" ) >= 0) //OLEDB Connection
            {
                Neusoft.FrameWork.Management.Connection.Instance = new System.Data.OleDb.OleDbConnection( DataSource );
            }
            else
            {
                Neusoft.FrameWork.Management.Connection.Instance = new System.Data.OracleClient.OracleConnection( DataSource );
                //Neusoft.FrameWork.Management.Connection.Instance = new Oracle.DataAccess.Client.OracleConnection(DataSource);
            }

            try
            {
                Neusoft.FrameWork.Management.Connection.Instance.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show( "无法连接数据库！\n" + ex.Message );
                return -1;
            }
            return 0;
        }

        internal static int ConnectSQL()
        {
            if (IsSqlInDB)
            {
                Neusoft.FrameWork.Management.Connection.Sql = new Neusoft.FrameWork.Management.Sql( Neusoft.FrameWork.Management.Connection.Instance );
            }
            else
            {
                Neusoft.FrameWork.Management.Connection.Sql = new Neusoft.FrameWork.Management.Sql( ServerPath + "SQL.xml" );
            }

            return 0;
        }


        /// <summary>
        /// 获得配置文件
        /// </summary>
        /// <returns></returns>
        internal static int GetSetting()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.Load( Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + UrlFileName );
            }
            catch (Exception ex)
            {
                MessageBox.Show( "装载url失败！\n" + ex.Message );
                return -1;
            }
            System.Xml.XmlNode node;
            #region 改成读一个地址列表，这样可以实现双机效果  {A5B6BD9E-68A1-45f5-BFE2-7EF0604AAAED}
            bool isUseUrlList = false;
            try
            {
                //校验用的node
                System.Xml.XmlNode nodeForCheck;
                nodeForCheck = doc.SelectSingleNode( "//root/dir" );
                if (nodeForCheck == null)
                {
                    isUseUrlList = false;
                }
                else
                {
                    isUseUrlList = true;
                }
            }
            catch (Exception ex)
            {
                isUseUrlList = false;
            }
            if (isUseUrlList == false)
            {
            #endregion
                #region 原有读单一路径的代码，为了兼容保留
                node = doc.SelectSingleNode( "//dir" );

                if (node == null)
                {
                    MessageBox.Show( "url中找dir结点出错！" );
                    return -1;
                }

                ServerPath = node.InnerText;
                //{B10E3309-D3F8-46c5-965D-9B0F3D328EE1}
                //TemplateDesignerHost.Function.SystemPath = ServerPath;//为电子病历使用的服务器路径


                string serverSettingFileName = "HisProfile.xml"; //服务器文件名

                try
                {
                    doc.Load( ServerPath + serverSettingFileName );
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "装载HisProfile.xml失败！\n" + ex.Message );

                }
                #endregion
                #region 改成读一个地址列表，这样可以实现双机效果 {A5B6BD9E-68A1-45f5-BFE2-7EF0604AAAED}
            }
            else
            {
                System.Xml.XmlNodeList xnl = doc.SelectNodes( "//root/dir" );
                if (xnl == null || xnl.Count == 0)
                {
                    MessageBox.Show( "url中找dir结点出错！" );
                    return -1;
                }

                int xnIdx = 0;
                foreach (System.Xml.XmlNode xn in xnl)
                {
                    ServerPath = xn.InnerText;
                    //TemplateDesignerHost.Function.SystemPath = ServerPath;//为电子病历使用的服务器路径
                    //{B10E3309-D3F8-46c5-965D-9B0F3D328EE1}
                    string serverSettingFileName = "HisProfile.xml"; //服务器文件名

                    try
                    {

                        doc.Load( ServerPath + serverSettingFileName );
                        break;
                    }
                    catch (Exception ex)
                    {

                        if (xnIdx == xnl.Count - 1)
                        {
                            MessageBox.Show( "装载HisProfile.xml失败！\n" + ex.Message );
                            return -1;
                        }
                        else
                        {
                            xnIdx++;
                            continue;
                        }
                    }
                }

            }
                #endregion
            node = doc.SelectSingleNode( "/设置/数据库设置" );

            if (node == null)
            {
                MessageBox.Show( "没有找到数据库设置!" );
                return -1;
            }

            string strDataSource = node.Attributes[0].Value;

            if (strDataSource.ToUpper().IndexOf( "PASSWORD" ) > 0)
            {

            }
            else //需要解密 
            {
                //strDataSource = Neusoft.HisDecrypt.Decrypt( strDataSource );
                //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
                strDataSource = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(strDataSource,Neusoft.FrameWork.Management.Connection.DESKey);
            }
            #region 鉴别是否是正式库
            node = doc.SelectSingleNode( "/设置/数据库类别" );
            if (node != null)
            {
                strDataType = node.Attributes[0].Value;
            }


            #endregion
            DataSource = strDataSource;

            node = doc.SelectSingleNode( "/设置/设置" );

            if (node == null)
            {
                MessageBox.Show( "没有找到SQL设置!" );
                return -1;
            }

            if (node.Attributes[0].Value == "1")//Sql.xml
            {
                IsSqlInDB = false;
            }
            else//数据库
            {
                IsSqlInDB = true;
            }

            node = doc.SelectSingleNode( "/设置/管理员" );


            if (node == null)
            {
                MessageBox.Show( "没有找到管理员密码!" );
                return -1;
            }

            ManagerPWD = node.Attributes[0].Value;

            return 0;


        }

        internal static void CreateFolder()
        {
            if (System.IO.Directory.Exists( Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath ) == false)
            {
                System.IO.Directory.CreateDirectory( Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath );
            }

            if (System.IO.Directory.Exists( Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.TempPath ) == false)
            {
                System.IO.Directory.CreateDirectory( Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.TempPath );
            }

            if (System.IO.Directory.Exists( Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.LanguagePath ) == false)
            {
                System.IO.Directory.CreateDirectory( Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.LanguagePath );
            }

        }

        #endregion

        /// <summary>
        /// Licence 判断
        /// </summary>
        /// <returns>成功进行返回1 失败返回-1</returns>
        private static int JudgeHISCryptoKeyFile(ref string strErr)
        {

            //去掉DATABASE_FLAG 字段
            string sql = "SELECT HOS_NAME,NUMBER_VALUE from com_departinfo";

            Neusoft.FrameWork.Management.DataBaseManger dataBase = new Neusoft.FrameWork.Management.DataBaseManger();
            if (dataBase.ExecQuery( sql ) == -1)
            {
                MessageBox.Show( dataBase.Err );
                return -1;
            }
            try
            {
                if (dataBase.Reader.Read())
                {
                    HosName = dataBase.Reader[0].ToString();
                    maxLocalLogFileSize = Neusoft.FrameWork.Function.NConvert.ToInt32( dataBase.Reader[1] );
                    ////{5313B8E5-709F-4741-A6E3-2186702DAC6C} 2013.02.20 modified by xipeter
                    //IsTestDB = Neusoft.FrameWork.Function.NConvert.ToBoolean(dataBase.Reader[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
                return -1;
            }
            finally
            {
                dataBase.Reader.Close();
            }

            DateTime sysTime = dataBase.GetDateTimeFromSysDateTime();

            string displayHosName = "";
            string licenceInformation = "";
            //int result = Neusoft.HisCrypto.Function.Licence(HosName, sysTime, out displayHosName, ref strErr);
            ////int result = Neusoft.HisCrypto.Function.Licence( HosName, sysTime, out displayHosName,out licenceInformation, ref strErr );

            //HosName = displayHosName;
            int result = 1;
            if (result == 1)
            {
                return 1;
            }

            return -1;
        }

        /// <summary>
        /// 后台数据库类型
        /// </summary>
        public enum EnumDBType
        {
            ORACLE = 0,
            SQLSERVER,
            DB2,
            SYSBASE,
            POSTGRESQL,
            OTHER
        }
    }
}