using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Medical
{
    public class Ability
    {
        public static Neusoft.HISFC.BizLogic.Order.Medical.Ability abilityMgr = new Neusoft.HISFC.BizLogic.Order.Medical.Ability();
          /// <summary>
        /// 医疗权限检查方法
        /// 修改了，增加参数isAllowNonRight{67FBD55B-1B0E-41e9-B13B-976E235D9FA2}
        /// </summary>
        /// <param name="emplCode">医生代码</param>
        /// <param name="itemCode">项目代码</param>
        /// <param name="sysClass">系统类别</param>
        /// <param name="isAllowNonRight">当在医疗权限管理中，所给医生没有被维护过所给系统类型权限的情况下，默认该医生具有该类型的所有权限</param>
        /// <param name="failCause">验证失败原因</param>
        /// <returns>成功 1 失败 -1 无权限 0</returns>
        public static int CheckPopedom(string emplCode, string itemCode, string sysClass, bool isAllowNonRight, ref string failCause)
        {
            return abilityMgr.CheckPopedom(emplCode, itemCode, sysClass, isAllowNonRight, ref failCause);
        }
    }
}
