using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品管理常数类]<br></br>
    /// [创 建 者: liangjz]<br></br>
    /// [创建时间: 2008-01]<br></br>
    /// </summary>
    [Serializable]
    public class DrugConstant : Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
    {
        public DrugConstant()
        {

        }

        #region 域变量

        /// <summary>
        /// 常数类别
        /// </summary>
        private string consType;

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 药品类别
        /// </summary>
        private string drugType;

        /// <summary>
        /// 二级权限码
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject class2Priv = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 三级权限码
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject class3Priv = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 分类项目
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject item = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        /// <summary>
        /// 分类项目
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Item
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
        /// 三级权限码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Class3Priv
        {
            get
            {
                return class3Priv;
            }
            set
            {
                class3Priv = value;
            }
        }

        /// <summary>
        /// 二级权限码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Class2Priv
        {
            get
            {
                return class2Priv;
            }
            set
            {
                class2Priv = value;
            }
        }

        /// <summary>
        /// 药品类别
        /// </summary>
        public string DrugType
        {
            get
            {
                return drugType;
            }
            set
            {
                drugType = value;
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return dept;
            }
            set
            {
                dept = value;
            }
        }

        /// <summary>
        /// 常数类别
        /// </summary>
        public string ConsType
        {
            get
            {
                return consType;
            }
            set
            {
                consType = value;
            }
        }

        #endregion

        #region IValid 成员

        /// <summary>
        /// 有效性
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 有效性
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new DrugConstant Clone()
        {
            DrugConstant info = base.Clone() as DrugConstant;

            info.oper = this.oper.Clone();
            info.item = this.item.Clone();
            info.class2Priv = this.class2Priv.Clone();
            info.class3Priv = this.class3Priv.Clone();
            info.dept = this.dept.Clone();

            return info;
        }

        #endregion
    }
}
