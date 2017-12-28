using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizProcess.Interface.Privilege;

namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 组织结构工厂
    /// </summary>
    public class OrgFactory
    {
        private static IDictionary<string, IPrivInfo> _orgProviders = null;
        /// <summary>
        /// 组织机构提供者
        /// </summary>
        public static IDictionary<string, IPrivInfo> getOrgProvider()
        {
            if (_orgProviders != null)
            {
                return _orgProviders;
            }
            else
            {
                _orgProviders = ConfigurationFactory.LoadOrgProvider();
            }

            if (_orgProviders == null) throw new Exception("请在配置文件中加载组织机构实现块!");

            return _orgProviders;
        }

    }
}
