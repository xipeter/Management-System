using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    //Add Service Contract sign
    /// <summary>
    /// 实体基类(所有的实体类都要继承它)
    /// 提供基本属性 
    /// Id:string
    /// Name:string
    /// Remark:string
    /// ClassCode:string
    /// </summary>
    [Serializable]
    public class BasicData 
    {
        /// <summary>
        /// 数据标识符
        /// </summary>
        protected String id;

        /// <summary>
        /// 数据标识符
        /// </summary>
        public String Id
        {
            get { return id; }
            set { id = value == null ? "" : value; }
        }

        /// <summary>
        /// 数据名称
        /// </summary>
        protected String name;

        /// <summary>
        /// 数据名称
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value == null ? "" : value; }
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        protected String remark;

        /// <summary>
        /// 备注信息
        /// </summary>
        public String Remark
        {
            get { return remark; }
            set { remark = value == null ? "" : value; }
        }


        ///// <summary>
        ///// 用于HL7扩展
        ///// </summary>
        //public String ClassCode
        //{
        //    get
        //    {
        //        if (PropertyCollection.ContainsKey("ClassCode"))
        //            return (String)PropertyCollection["ClassCode"];
        //        else
        //            return "";
        //    }
        //    set { SetProperty("ClassCode",value); }
        //}

    }
}
