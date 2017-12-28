using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.PhysicalExamination
{
    /// <summary>
    /// DeptUse<br></br>
    /// [功能描述: 科常用管理]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class DeptUse : NFC.Object.NeuObject
    {
        #region 私有变量
        /// <summary>
        /// 执行科室
        /// </summary>
        private NFC.Object.NeuObject execDeptInfo = new Neusoft.NFC.Object.NeuObject() ;
        /// <summary>
        /// 科室
        /// </summary>
        private NFC.Object.NeuObject deptInfo = new Neusoft.NFC.Object.NeuObject();
        /// <summary>
        /// 标识 
        /// </summary>
        private string unitFlag;
        /// <summary>
        /// 是否统计
        /// </summary>
        public string isStat;
        /// <summary>
        /// 项目
        /// </summary>
        public Neusoft.HISFC.Object.Base.Item item = new Neusoft.HISFC.Object.Base.Item();
        #endregion 

        #region 属性
        /// <summary>
        /// 执行科室
        /// </summary>
        public NFC.Object.NeuObject ExeDept
        {
            get
            { 
                return execDeptInfo;
            }
            set
            {
                execDeptInfo = value;
            }
        }
        /// <summary>
        /// 科室
        /// </summary>
        public NFC.Object.NeuObject DeptInfo
        {
            get
            { 
                return deptInfo;
            }
            set
            {
                deptInfo = value;
            }
        }
        /// <summary>
        /// 项目
        /// </summary>
        public Neusoft.HISFC.Object.Base.Item Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }
        /// <summary>
        /// 标示明细还是祖套
        /// </summary>
        public string UnitFlag
        {
            get
            {
                return unitFlag;
            }
            set
            {
                unitFlag = value;
            }
        }
        /// <summary>
        /// 是否统计
        /// </summary>
        public string ISStat
        {
            get
            {
                return isStat;
            }
            set
            {
                isStat = value;
            }
        }
        #endregion 

        #region 克隆
        public new DeptUse Clone()
        {
            DeptUse obj = base.Clone() as DeptUse;
            obj.ExeDept = this.ExeDept.Clone();
            obj.DeptInfo = this.DeptInfo.Clone(); 
            obj.item = this.item.Clone();
            return obj;
        }
        #endregion 

        #region 废弃
        /// <summary>
        /// 执行科室
        /// </summary>
        [Obsolete("废弃，用ExeDept代替",true)]
        public NFC.Object.NeuObject ExecDeptInfo
        {
            get
            {
                return execDeptInfo;
            }
            set
            {
                execDeptInfo = value;
            }
        }
        #endregion 
    }
}
