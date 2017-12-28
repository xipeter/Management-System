using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.PhysicalExamination
{
    /// <summary>
    /// GroupDetail<br></br>
    /// [功能描述: 体检组套管理类]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class GroupDetail : Neusoft.HISFC.Models.Fee.ComGroupTail
    {
        #region 变量
        /// <summary>
        /// 有效标志
        /// </summary>
        private string validState = string.Empty;
        /// <summary>
        /// 检测次数
        /// </summary>
        private int chkTime ;
        /// <summary>
        /// 规格
        /// </summary>
        private string spacs = string.Empty;
        /// <summary>
        /// 执行科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject execDept = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 实际价格
        /// </summary>
        private decimal realPrice;
        #endregion 

        #region 属性
        /// <summary>
        /// 有效 0 有效 1无效 
        /// </summary>
        public string ValidState
        {
            get
            {
                return validState;
            }
            set
            {
                validState = value;
            }
        }
        /// <summary>
        /// 检测次数
        /// </summary>
        public int ChkTime
        {
            get
            {
                return chkTime;
            }
            set
            {
                chkTime = value;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spacs
        {
            get
            {
                return spacs;
            }
            set
            {
                spacs = value;
            }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ExecDept
        {
            get
            {
                return execDept;
            }
            set
            {
                execDept = value;
            }
        }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal RealPrice
        {
            get
            {
                return realPrice;
            }
            set
            {
                realPrice = value;
            }
        }
        #endregion 
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new GroupDetail Clone()
        {
            GroupDetail obj = base.Clone() as GroupDetail;
            obj.execDept = this.execDept.Clone();
            return obj;
        }
    }
}
