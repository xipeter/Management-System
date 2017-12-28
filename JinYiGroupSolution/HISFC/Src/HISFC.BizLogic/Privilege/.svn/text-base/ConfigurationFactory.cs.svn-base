using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using Neusoft.HISFC.BizProcess.Interface.Privilege;

namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 配置工厂
    /// </summary>
    public class ConfigurationFactory
    {
        #region 认证管理    
        
        /// <summary>
        /// 反射生成对象
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="dll"></param>
        /// <returns></returns>
        public static object Reflect(string typeName, string dll)
        {
            Type _type = Type.GetType(typeName);

            System.Reflection.Assembly _assembly;
            if (_type == null)
            {
                _assembly = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + dll);
               // _assembly = System.Reflection.Assembly.LoadFrom(dll);

            }
            else
            {
                _assembly = System.Reflection.Assembly.GetAssembly(_type);
            }
            object obj = _assembly.CreateInstance(typeName);

            return obj;
        }
        #endregion

        #region 组织机构管理
        /// <summary>
        /// 载入组织机构实现模块
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, IPrivInfo> LoadOrgProvider()
        {
            //NeuConfigurationSection section = ConfigurationUtil.GetConfigSection("orgFactory", "orgProvider");

            //Neusoft.Framework.Configuration.ConfigurationViewBase _configFactory = new Neusoft.Framework.Configuration.ConfigurationViewBase();
            //NeuConfigurationSection section = (NeuConfigurationSection)_configFactory.GetConfigurationSection("orgProvider");

            Dictionary<string, string> Collections = new Dictionary<string, string>();
            XmlDocument xml = new XmlDocument();
            string a = AppDomain.CurrentDomain.BaseDirectory + "Xml\\privilege.xml";
            xml.Load(a);
            XmlNodeList xmlNodeList = xml.SelectSingleNode("privilege/orgProvider/collection").ChildNodes;

            foreach (XmlNode node in xmlNodeList)
            {
                Collections.Add(node.Attributes["key"].Value.ToString(), node.Attributes["value"].Value.ToString());
            }

            IDictionary<string, IPrivInfo> _collection = new Dictionary<string, IPrivInfo>();
            foreach(KeyValuePair<string,string> pair in Collections)
            {
                string[] array = pair.Value.Split(new char[] { ',' });
                IPrivInfo _provider = (IPrivInfo)Reflect(array[0], array[1]);
                _collection.Add(pair.Key, _provider);
            }

            return _collection;
        }
        
        #endregion       

        #region 统一权限管理

        /// <summary>
        /// 载入统一授权实现模块
        /// </summary>
        /// <returns></returns>
        public static IDictionary<Neusoft.HISFC.BizLogic.Privilege.Model.ResourceType, 
            IList<Neusoft.HISFC.BizLogic.Privilege.Model.Operation>> LoadPermission()
        {
            //Neusoft.Framework.Configuration.ConfigurationViewBase _configFactory = new Neusoft.Framework.Configuration.ConfigurationViewBase();
            //PermissionConfigurationSection section = (PermissionConfigurationSection)_configFactory.GetConfigurationSection("permissionFactory");

            Dictionary<string, Dictionary<string, string>> allInfo = new Dictionary<string, Dictionary<string, string>>();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(AppDomain.CurrentDomain.BaseDirectory + "Xml\\privilege.xml");
            XmlNodeList xmlNodeList = xml.SelectNodes("//privilege/permissionFactory/permissionProviders");

            foreach (XmlNode node in xmlNodeList)
            {
                string key = node.Attributes["id"].ToString() + "|" + node.Attributes["name"].ToString() + "|" + node.Attributes["type"].ToString() + "|" + node.Attributes["exclusive"].ToString();
                Dictionary<string, string> childInfo = new Dictionary<string, string>();
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    childInfo.Add(childNode.Attributes["key"].ToString(), childNode.Attributes["value"].ToString());
                }
                allInfo.Add(key,childInfo);
            }


            IDictionary<Neusoft.HISFC.BizLogic.Privilege.Model.ResourceType,
                IList<Neusoft.HISFC.BizLogic.Privilege.Model.Operation>> _permissions =
                new Dictionary<Neusoft.HISFC.BizLogic.Privilege.Model.ResourceType, IList<Neusoft.HISFC.BizLogic.Privilege.Model.Operation>>();

            foreach (KeyValuePair<string,Dictionary<string,string>> pair in allInfo)
            {
                Neusoft.HISFC.BizLogic.Privilege.Model.ResourceType _resType = new Neusoft.HISFC.BizLogic.Privilege.Model.ResourceType();
                IList<Neusoft.HISFC.BizLogic.Privilege.Model.Operation> _operations = new List<Neusoft.HISFC.BizLogic.Privilege.Model.Operation>();

                string[] permissions = pair.Key.Split(new char[] { '|' });
                _resType.Id = permissions[0].ToString();
                _resType.Name = permissions[1].ToString();
                _resType.ImplType = permissions[2].ToString();
                _resType.Exclusive =FrameWork.Function.NConvert.ToBoolean( permissions[3].ToString());

                foreach (KeyValuePair<string,string> _operElement in pair.Value)
                {
                    Neusoft.HISFC.BizLogic.Privilege.Model.Operation _operation = new Neusoft.HISFC.BizLogic.Privilege.Model.Operation();
                    _operation.Id = _operElement.Key;
                    _operation.Name = _operElement.Value;
                    _operation.ResourceType = permissions[0].ToString(); ;

                    _operations.Add(_operation);
                }

                _permissions.Add(_resType, _operations);
            }

            return _permissions;
        }
               
        #endregion
    }


}
