using System;

namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// Connection 的摘要说明。s
	/// </summary>
	public class Connection
	{
		private static System.Data.IDbConnection connection =null;
		private static System.Data.IDbConnection nearconnection =null;
		private static Neusoft.FrameWork.Management.Sql sql =null;
		private Connection(string ConnectionString)
		{
			
		}
		private Connection()
		{

		}
		/// <summary>
		/// 数据库连接实例
		/// </summary>
		public static System.Data.IDbConnection Instance
		{
			get
			{   
				return connection;
			}
			set
			{
				connection = value;
			}
		}

		/// <summary>
		/// 近线数据库连接实例
		/// </summary>
		public static System.Data.IDbConnection NearInstance
		{
			get
			{
				return nearconnection;
			}
			set
			{
				nearconnection = value;
			}
		}
		/// <summary>
		/// sql语句管理
		/// </summary>
		public static Neusoft.FrameWork.Management.Sql Sql
		{
			get
			{
				return sql;
			}
			set
			{
				sql = value;
			}
		}

		private static Neusoft.FrameWork.Models.NeuObject oper =new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 操作员，可转成当前操作员类
		/// </summary>
		public static Neusoft.FrameWork.Models.NeuObject Operator
		{
			get
			{
				return oper;
			}
			set
			{
				oper = value;
                Server.Function.Manager.SetOperation(value);
			}
        }

        ////{7F75F400-8180-485f-B968-E95E472FF9AA}
        //private static Neusoft.FrameWork.Models.NeuObject hospital = new Neusoft.FrameWork.Models.NeuObject();

        ///// <summary>
        ///// 医院信息
        ///// </summary>
        //public static Neusoft.FrameWork.Models.NeuObject Hospital
        //{
        //    get
        //    {
   
        //        return hospital;
        //    }
        //    set
        //    {
        //        hospital = value;
        //    }
        //}
        //{7F75F400-8180-485f-B968-E95E472FF9AA}
        public static string CoreHospatialCode = "CORE_HIS50";

        #region 电子申请单初始化 addby zhangkj {A93EE0CA-F50E-4142-8477-761E257AC974}

        private static Neusoft.FrameWork.Models.NeuObject applyoper = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 操作员，可转成当前操作员类
        /// </summary>
        public static Neusoft.FrameWork.Models.NeuObject ApplyOperator
        {
            get
            {
                return applyoper;
            }
            set
            {
                applyoper = value;
                //Server.Function.Manager.SetOperation(value);
            }
        }
        #endregion
        private static bool bIsWeb = false;
		/// <summary>
		/// 是否web
		/// </summary>
		public static bool IsWeb 
		{
			get
			{
				return bIsWeb;
			}
			set
			{
				bIsWeb = value;
			}
		}

		private static bool bIsHistory = false;
		/// <summary>
		/// 是否查询历史库
		/// </summary>
		public static bool IsHistory
		{
			get
			{
				return bIsHistory;
			}
			set
			{
				bIsHistory = value;
			}
		}

        /// <summary>
        /// 系统路径url.xml
        /// http:\\localhost\
        /// </summary>
        public static string SystemPath = "";

        /// <summary>
        /// 是否测试库
        /// </summary>
        public static bool IsTestDB = false;

        /// <summary>
        /// 主库连接串
        /// </summary>
        public static string DataSouceString = "";

        /// <summary>
        /// 管理员密码
        /// </summary>
        public static string ManagerPWD = "";

        /// <summary>
        /// 无效连接超时时间
        /// 最小时间间隔6秒
        /// 为0时候不释放
        /// </summary>
        public static int TimeOutSecond = 38;

        /// <summary>
        /// 最大连接数
        /// 0无限制
        /// </summary>
        public static int MaxConnection = 0;

        /// <summary>
        ///三层监控是否使用
        /// </summary>
        public static bool IsSocketUsed = false;

        /// <summary>
        /// {38B71167-48DF-4972-9857-3EAFDD6466B0} 
        /// </summary>
        public static string mapPath = "";

        /// <summary>
        /// DESKey {D515E09B-E299-47e0-BF19-EDFDB6E4C775}
        /// HIS加密解密deskey，不同于lisence的deskey
        /// </summary>
        public static string DESKey = "Core_H_N";

        /// <summary>
        /// 获得配置文件{38B71167-48DF-4972-9857-3EAFDD6466B0}
        /// </summary>
        /// <returns></returns>
        public static int GetSettingPB(string path, out string err)
        {
            int i = path.IndexOf('\0');
            if (i != -1)
            {
                path = path.Substring(0, i);
            }

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.Load(path + "url.xml");
            }
            catch (Exception ex)
            {
                err = ("装载url失败！\n" + ex.Message);
                return -1;
            }
            System.Xml.XmlNode node;
            #region 改成读一个地址列表，这样可以实现双机效果  {A5B6BD9E-68A1-45f5-BFE2-7EF0604AAAED}
            bool isUseUrlList = false;
            try
            {
                //校验用的node
                System.Xml.XmlNode nodeForCheck;
                nodeForCheck = doc.SelectSingleNode("//root/dir");
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
                err = ex.Message;
                isUseUrlList = false;
            }
            #endregion
            if (isUseUrlList == false)
            {

                #region 原有读单一路径的代码，为了兼容保留
                node = doc.SelectSingleNode("//dir");

                if (node == null)
                {
                    err = ("url中找dir结点出错！");
                    return -1;
                }

                SystemPath = node.InnerText;

                string serverSettingFileName = "Profile.xml"; //服务器文件名

                try
                {
                    doc.Load(SystemPath + serverSettingFileName);
                }
                catch (Exception ex)
                {
                    err = ("装载Profile.xml失败！\n" + ex.Message);

                }
                #endregion
                #region 改成读一个地址列表，这样可以实现双机效果 {A5B6BD9E-68A1-45f5-BFE2-7EF0604AAAED}
            }
            else
            {
                System.Xml.XmlNodeList xnl = doc.SelectNodes("//root/dir");
                if (xnl == null || xnl.Count == 0)
                {
                    err = ("url中找dir结点出错！");
                    return -1;
                }

                int xnIdx = 0;
                foreach (System.Xml.XmlNode xn in xnl)
                {
                    SystemPath = xn.InnerText;

                    string serverSettingFileName = "HisProfile.xml"; //服务器文件名

                    try
                    {

                        doc.Load(SystemPath + serverSettingFileName);
                        break;
                    }
                    catch (Exception ex)
                    {

                        if (xnIdx == xnl.Count - 1)
                        {
                            err = ("装载HisProfile.xml失败！\n" + ex.Message);
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
            node = doc.SelectSingleNode("/设置/数据库设置");

            if (node == null)
            {
                err = ("没有找到数据库设置!");
                return -1;
            }

            string strDataSource = node.Attributes[0].Value;

            //判断连接串是否加密{2480BEE8-92D0-484e-8D7E-2E24CC41C0C1}
            node = doc.SelectSingleNode("/设置/加密");
            if (node == null)
            {
                err = ("没有找到是否加密信息!");
                return -1;
            }
            string strCrypto = node.Attributes[0].Value;
            if (strCrypto.Trim().Equals("1"))
            {
                //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
                //strDataSource = Neusoft.HisDecrypt.Decrypt(strDataSource);
                strDataSource = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(strDataSource,DESKey);
            }
            //END

            #region 数据库类型
            node = doc.SelectSingleNode("/设置/数据库类别");
            if (node != null)
            {

                DBType = GetDBType(node.Attributes[0].Value);//数据库类型判断.//{08F955BE-6313-47cc-AB3A-14897F4147B8}
            }


            #endregion
            DataSouceString = strDataSource;

            node = doc.SelectSingleNode("/设置/设置");

            if (node == null)
            {
                err = ("没有找到SQL设置!");
                return -1;
            }



            node = doc.SelectSingleNode("/设置/管理员");


            if (node == null)
            {
                err = ("没有找到管理员密码!");
                return -1;
            }
            //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
            //ManagerPWD = Neusoft.HisDecrypt.Decrypt(node.Attributes[0].Value);
            ManagerPWD = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(node.Attributes[0].Value,DESKey);

            node = doc.SelectSingleNode("/设置/正式库");
            if (node != null)
            {
                if (node.Attributes[0].Value == "0")
                {
                    IsTestDB = true;
                }
                else
                {
                    IsTestDB = false;
                }
            }
            node = doc.SelectSingleNode("/设置/服务器");
            if (node != null)
            {
                MaxConnection = FrameWork.Function.NConvert.ToInt32(node.Attributes[0].Value);

                try
                {
                    TimeOutSecond = FrameWork.Function.NConvert.ToInt32(node.Attributes[1].Value);
                }
                catch
                {
                }

                if (TimeOutSecond < 6 && TimeOutSecond > 0)
                    TimeOutSecond = 6;//最小时间间隔
            }
            err = "";


            return 0;


        }
        /// <summary>
        /// 获得配置文件
        /// </summary>
        /// <returns></returns>
        public static int GetSetting(out string err)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.Load(System.Windows.Forms.Application.StartupPath + @"\" + "url.xml");
            }
            catch (Exception ex)
            {
                err = ("装载url失败！\n" + ex.Message);
                return -1;
            }
            System.Xml.XmlNode node;
            #region 改成读一个地址列表，这样可以实现双机效果  {A5B6BD9E-68A1-45f5-BFE2-7EF0604AAAED}
            bool isUseUrlList = false;
            try
            {
                //校验用的node
                System.Xml.XmlNode nodeForCheck;
                nodeForCheck = doc.SelectSingleNode("//root/dir");
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
                err = ex.Message;
                isUseUrlList = false;
            }
            #endregion
            if (isUseUrlList == false)
            {
          
                #region 原有读单一路径的代码，为了兼容保留
                node = doc.SelectSingleNode("//dir");

                if (node == null)
                {
                    err = ("url中找dir结点出错！");
                    return -1;
                }

                SystemPath = node.InnerText;

                string serverSettingFileName = "Profile.xml"; //服务器文件名

                try
                {
                    doc.Load(SystemPath + serverSettingFileName);
                }
                catch (Exception ex)
                {
                    err =("装载Profile.xml失败！\n" + ex.Message);
                    
                }
                #endregion
                #region 改成读一个地址列表，这样可以实现双机效果 {A5B6BD9E-68A1-45f5-BFE2-7EF0604AAAED}
            }
            else
            {
                System.Xml.XmlNodeList xnl = doc.SelectNodes("//root/dir");
                if (xnl == null || xnl.Count == 0)
                {
                    err  =("url中找dir结点出错！");
                    return -1;
                }

                int xnIdx = 0;
                foreach (System.Xml.XmlNode xn in xnl)
                {
                    SystemPath = xn.InnerText;

                    string serverSettingFileName = "HisProfile.xml"; //服务器文件名

                    try
                    {

                        doc.Load(SystemPath + serverSettingFileName);
                        break;
                    }
                    catch (Exception ex)
                    {

                        if (xnIdx == xnl.Count - 1)
                        {
                           err =("装载HisProfile.xml失败！\n" + ex.Message);
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
            node = doc.SelectSingleNode("/设置/数据库设置");

            if (node == null)
            {
                err = ("没有找到数据库设置!");
                return -1;
            }

            string strDataSource = node.Attributes[0].Value;

            //判断连接串是否加密{2480BEE8-92D0-484e-8D7E-2E24CC41C0C1}
            node = doc.SelectSingleNode("/设置/加密");
            if (node == null)
            {
                err = ("没有找到是否加密信息!");
                return -1;
            }
            string strCrypto = node.Attributes[0].Value;
            if (strCrypto.Trim().Equals("1"))
            {
                //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
                //strDataSource = Neusoft.HisDecrypt.Decrypt(strDataSource);
                strDataSource = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(strDataSource,DESKey);
            }
            //END

            #region 数据库类型
            node = doc.SelectSingleNode("/设置/数据库类别");
            if (node != null)
            {

                DBType = GetDBType(node.Attributes[0].Value);//数据库类型判断.//{08F955BE-6313-47cc-AB3A-14897F4147B8}
            }


            #endregion
            DataSouceString = strDataSource;

            node = doc.SelectSingleNode("/设置/设置");

            if (node == null)
            {
                err = ("没有找到SQL设置!");
                return -1;
            }

         

            node = doc.SelectSingleNode("/设置/管理员");


            if (node == null)
            {
                err = ("没有找到管理员密码!");
                return -1;
            }
            //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
            //ManagerPWD = Neusoft.HisDecrypt.Decrypt(node.Attributes[0].Value);
            ManagerPWD = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(node.Attributes[0].Value,DESKey);

            node = doc.SelectSingleNode("/设置/正式库");
            if (node != null)
            {
                if (node.Attributes[0].Value == "0")
                {
                    IsTestDB = true;
                }
                else
                {
                    IsTestDB = false;
                }
            }
            node = doc.SelectSingleNode("/设置/服务器");
            if (node != null)
            {
                MaxConnection = FrameWork.Function.NConvert.ToInt32(node.Attributes[0].Value);

                try
                {
                    TimeOutSecond = FrameWork.Function.NConvert.ToInt32(node.Attributes[1].Value);
                }
                catch { }

                if (TimeOutSecond < 6 && TimeOutSecond > 0)
                    TimeOutSecond = 6;//最小时间间隔
            }
            //add start
            #region 三层监控设置
            node = doc.SelectSingleNode("/设置/三层监控");
            if (node != null)
            {
                if (node.Attributes.Count > 0)
                {
                    if (node.Attributes[0].Value == "0")//0代表使用三层监控
                    {
                        IsSocketUsed = true;
                    }
                    else
                    {
                        IsSocketUsed = false;
                    }
                }
            }
            #endregion
            //add end

            err = "";

           
            return 0;


        }

        internal static EnumDBType GetDBType(string dbtype)
        {
            EnumDBType dt;
            try
            {
                switch (dbtype.ToUpper().Trim())
                {
                    case "ORACLE":
                        dt = (EnumDBType)0;
                        break;
                    case "SQLSERVER":
                        dt = (EnumDBType)1;
                        break;
                    case "DB2":
                        dt = (EnumDBType)2;
                        break;
                    case "SYSBASE":
                        dt = (EnumDBType)3;
                        break;
                    case "POSTGRESQL":
                        dt = (EnumDBType)4;
                        break;
                    case "OTHER":
                        dt = (EnumDBType)5;
                        break;
                    default:
                        dt = (EnumDBType)0;
                        break;
                }
            }
            catch
            {
                dt = EnumDBType.ORACLE;
            }

            return dt;
        }
        public static EnumDBType DBType = EnumDBType.ORACLE;
        /// <summary>
        /// 后台数据库类型
        /// </summary>
        public  enum EnumDBType
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
