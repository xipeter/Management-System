using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Examination
{
    /// <summary>
    /// IBaby<br></br>
    /// [功能描述: 体检单位分组]<br></br>
    /// [创 建 者: 王政东]<br></br>
    /// [创建时间: 2006-12-08]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class CHKCompanyGroup : Neusoft.HISFC.Object.Base.Item
    {
        #region 变量
        /// <summary>
        /// 科室实体类
        /// </summary>
        private Neusoft.HISFC.Object.Base.Department department = new Neusoft.HISFC.Object.Base.Department();
        /// <summary>
        /// 分组查询码
        /// </summary>
        private string groupSpell = string.Empty;
        
        /// <summary>
        /// 性别
        /// </summary>
        private string sexCode = string.Empty;
        
        /// <summary>
        /// 婚姻状况
        /// </summary>
        private string wedState = string.Empty;
        
        /// <summary>
        /// 年龄上限
        /// </summary>
        private int ageTop = 0;
        
        /// <summary>
        /// 年龄下限
        /// </summary>
        private int ageBottom = 0;
        
        /// <summary>
        /// 职务
        /// </summary>
        private string postCode = string.Empty;
        
        /// <summary>
        /// 职称
        /// </summary>
        private string postTitleCode = string.Empty;
       
        /// <summary>
        /// 是否有效1有效0无效
        /// </summary>
        private string validFlag;
        #endregion

        #region 属性
        ///// <summary>
        ///// 分组名称
        ///// </summary>
        //public string GroupName
        //{
        //    get
        //    {
        //        return groupName;
        //    }
        //    set
        //    {
        //        groupName = value;
        //    }
        //}

        /// <summary>
        /// 分组查询码
        /// </summary>
        public string GroupSpell
        {
            get
            {
                return groupSpell;
            }
            set
            {
                groupSpell = value;
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string SexCode
        {
            get
            {
                return sexCode;
            }
            set
            {
                sexCode = value;
            }
        }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string WedState
        {
            get
            {
                return wedState;
            }
            set
            {
                wedState = value;
            }
        }

        /// <summary>
        /// 年龄上限
        /// </summary>
        public int AgeTop
        {
            get
            {
                return ageTop;
            }
            set
            {
                ageTop = value;
            }
        }

        /// <summary>
        /// 年龄下限
        /// </summary>
        public int AgeBottom
        {
            get
            {
                return ageBottom;
            }
            set
            {
                ageBottom = value;
            }
        }

        /// <summary>
        /// 职务
        /// </summary>
        public string PostCode
        {
            get
            {
                return postCode;
            }
            set
            {
                postCode = value;
            }
        }

        /// <summary>
        /// 职称
        /// </summary>
        public string PostTitleCode
        {
            get
            {
                return postTitleCode;
            }
            set
            {
                postTitleCode = value;
            }
        }

        /// <summary>
        /// 是否有效1有效0无效
        /// </summary>
        public string ValidFlag
        {
            get
            {
                return validFlag;
            }
            set
            {
                validFlag = value;
            }
        }

        /// <summary>
        /// 科室实体类
        /// </summary>
        public Neusoft.HISFC.Object.Base.Department Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }
        #endregion

        #region 克隆函数
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new CHKCompanyGroup Clone ()
        {
            CHKCompanyGroup obj = base.Clone() as CHKCompanyGroup;
            obj.Department = obj.Department.Clone();
            return obj;
        }
        #endregion
    }
}
