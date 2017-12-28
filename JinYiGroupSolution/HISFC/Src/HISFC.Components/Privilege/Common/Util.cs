using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Neusoft.HISFC.BizLogic.Privilege.Service;


namespace Neusoft.HISFC.Components.Privilege.Common
{
    internal class Util
    {
        ////private static Neusoft.Framework.Unity.UnityContainerFactoryNew factory;

        //Util()
        //{

        //}

        public static PrivilegeService CreateProxy()
        {
            PrivilegeService p = new PrivilegeService();
            return p;
        }
        public static string ToString(object obj)
        {
            if (obj == null) return "";

            return obj.ToString();
        }

        ///// <summary>
        ///// 获得系统时间
        ///// </summary>
        ///// <returns></returns>
        //public  DateTime GetDateTime()
        //{
 
        //    DateTime _current = DateTime.MinValue;
        //    _current = Neusoft.Framework.Facade.Context.GetServerDateTime();
        //    return _current;
        //}

        /// <summary>
        /// Hash加密
        /// </summary>
        /// <param name="orig"></param>
        /// <returns></returns>
        public static string CreateHash(string origin)
        {
            return null;// Neusoft.Framework.Security.Cryptography.Cryptographer.CreateHash("SHA1Managed", origin);
        }

        /// <summary>
        /// Hash解密
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool CompareHash(string newOriginPass, string oldEncryptPass)
        {
            return false;// Neusoft.Framework.Security.Cryptography.Cryptographer.CompareHash("SHA1Managed", newOriginPass, oldEncryptPass);
        }


    }

}
