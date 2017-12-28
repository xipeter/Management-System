using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.NMS
{
    public class Nms : IntegrateBase
    {
        public Nms()
        {
        }

        #region 变量

        /// <summary>
        /// 权限业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

        protected Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
      
        /// <summary>
        /// 设置Trans
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            powerManager.SetTrans(trans);

        }

        #endregion

        #region 方法

        /// <summary>
        /// class1Code，class2Code，class3Code
        /// </summary>
        /// <param name="class1Code"></param>
        /// <param name="class2Code"></param>
        /// <param name="class3code"></param>
        /// <returns></returns>
        public ArrayList QueryAllPrivUser(string class1Code, string class2Code, string class3Code)
        {
            this.SetDB(powerManager);

            return powerManager.QueryAllPrivUser(class1Code, class2Code, class3Code);
        }

        /// <summary>
        /// 取所有科室信息
        /// </summary>
        /// <returns></returns>
        public ArrayList GetDeptmentAll()
        {
            this.SetDB(deptManager);
            return deptManager.GetDeptmentAll();
        }

        public ArrayList GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType Type)
        {
            this.SetDB(deptManager);
            return deptManager.GetDeptment(Type);
        }
        
        #endregion
    }
    
}
