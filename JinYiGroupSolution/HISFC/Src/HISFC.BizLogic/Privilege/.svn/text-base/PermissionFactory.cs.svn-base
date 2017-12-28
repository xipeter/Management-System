using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Privilege.Model;


namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 权限工厂
    /// </summary>
   public class PermissionFactory
    {
        private static IDictionary<ResourceType, IList<Operation>> _permissionProviders = null;
       /// <summary>
       /// 权限提供者
       /// </summary>
       /// <returns></returns>
        public static IDictionary<ResourceType, IList<Operation>> LoadPermissionProvider()
        {
            if (_permissionProviders != null)
            {
                return _permissionProviders;
            }
            else
            {
                _permissionProviders = ConfigurationFactory.LoadPermission();
            }
            if (_permissionProviders == null) throw new Exception("请在配置文件中加载权限管理实现块!");
            return _permissionProviders;
        }
    }
}
