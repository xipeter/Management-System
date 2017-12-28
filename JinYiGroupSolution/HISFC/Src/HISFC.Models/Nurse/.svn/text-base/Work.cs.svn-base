using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Nurse
{
    /// <summary>
    /// <br>RegLevel</br>
    /// <br>[功能描述: 护士排班实体]</br>
    /// <br>[创 建 者: 张琦]</br>
    /// <br>[创建时间: 2007-9-9]</br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class Work
    {
         public Work()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 排班模板
        /// </summary>
        private WorkTemplet templet = new WorkTemplet();

        /// <summary>
        /// 排班信息
        /// </summary>
        public WorkTemplet Templet
        {
            get { return templet; }
            set { templet = value; }
        }

        /// <summary>
        /// 排班时间
        /// </summary>
        private DateTime workDate = DateTime.MaxValue;

        public DateTime WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }
       
        /// <summary>
        /// 排班序号
        /// </summary>
        private int workNO = 0;

        public int WorkNO
        {
            get { return workNO; }
            set { workNO = value; }
        }

        #endregion
   
        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public Work Clone()
        {
            Work obj = base.MemberwiseClone() as Work;

            obj.Templet = this.Templet.Clone();            

            return obj;
        }
        #endregion

    }
}
