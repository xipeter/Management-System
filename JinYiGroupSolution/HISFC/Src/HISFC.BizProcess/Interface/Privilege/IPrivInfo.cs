using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.HISFC.Models.Privilege;

namespace Neusoft.HISFC.BizProcess.Interface.Privilege
{
    /// <summary>
    /// 对外接口
    /// </summary>
    public interface IPrivInfo
    {
        /// <summary>
        /// 获取应用Id
        /// </summary>       
        string QueryAppID();

        /// <summary>
        /// 查询组织所有有效人员
        /// </summary>        
        /// <returns></returns>        
        IList<Person> QueryPerson();

        /// <summary>
        /// 查询所有有效组织
        /// </summary>        
        /// <returns></returns>
        IList<Organization> QueryUnit();

        /// <summary>
        /// 查询所有组织类别
        /// </summary>
        /// <returns></returns>
        List<String> GetOrgType();
    }
}
