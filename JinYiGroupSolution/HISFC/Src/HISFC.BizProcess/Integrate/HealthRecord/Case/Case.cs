using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病案柜组合类]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007-9-11]<br></br>
    /// </summary>
    public class Case : IntegrateBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Case()
        {
        }

        #region 变量

        /// <summary>
        /// 科室管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();

        /// <summary>
        /// 人员管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();

        //{D2BDB9B8-7D50-4a66-8D1C-28EA0420592F}
        /// <summary>
        /// 常数管理
        /// </summary>
        public Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();
        //{D2BDB9B8-7D50-4a66-8D1C-28EA0420592F}
        #endregion

        #region 函数

        /// <summary>
        /// 事务设置
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            this.con.SetTrans(trans);
            this.dept.SetTrans(trans);
            this.person.SetTrans(trans);
        }

        /// <summary>
        /// 获取所有科室列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetDeptmentAll()
        {
            this.SetDB(this.dept);
            return this.dept.GetDeptmentAll();
        }

        /// <summary>
        /// 根据科室编号获得科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Base.Department GetDeptmentById(string id)
        {
            this.SetDB(this.dept);
            return this.dept.GetDeptmentById(id);
        }

        /// <summary>
        /// 获取所有人员列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetEmployeeAll()
        {
            this.SetDB(this.person);
            return this.person.GetEmployeeAll();
        }

        /// <summary>
        /// 根据员工编号获得员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Base.Employee GetPersonByID(string id)
        {
            this.SetDB(this.person);
            return this.person.GetPersonByID(id);
        }

        /// <summary>
        /// 获取常数列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCaseConstant(string str)
        {
            this.SetDB(con);
            return con.GetList(str);
        }

        /// <summary>
        /// 根据id查询常数
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public NeuObject GetConstant(string type, string id)
        {
            this.SetDB(con);
            return this.con.GetConstant(type, id);
        }

        #endregion

    }
}
