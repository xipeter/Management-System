using System;
using System.Collections.Generic;
using System.Text;


namespace Neusoft.HISFC.Models.Privilege
{
    /// <summary>
    /// 人员接口实现,外部调用使用
    /// </summary>
    public class Person :Neusoft.FrameWork.Models.NeuObject
    {
        private string id;
        private string name;
        private string remark;
        private string appId;
        #region Person 成员

        /// <summary>
        /// Id
        /// </summary>
        
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

        /// <summary>
        /// 所属系统模块
        /// </summary>
        
        public string AppId
        {
            get
            {
                return appId;
            }
            set
            {
                appId = value;
            }
        }
        #endregion

        /// <summary>
        /// 人员克隆
        /// </summary>
        /// <returns></returns>
        public new Person Clone()
        {
            Person obj = base.MemberwiseClone() as Person;
            return obj;
        }
    }
}
