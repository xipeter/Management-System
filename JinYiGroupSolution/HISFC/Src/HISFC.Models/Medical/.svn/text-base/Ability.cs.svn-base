using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.Models.Medical
{
    /// <summary>
    /// Ability <br></br>
    /// [功能描述: 资质实体类]<br></br>
    /// [创 建 者: 孙久海]<br></br>
    /// [创建时间: 2008-07-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class Ability : NeuObject
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Ability()
        {
            //
        }
        #region 字段
        /// <summary>
        /// 聚合人员基本信息类

        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
        /// <summary>
        /// 所学专业

        /// </summary>
        private NeuObject speciality = new NeuObject();
        /// <summary>
        /// 执业证书编号
        /// </summary>
        private string vocationCardNO;
        /// <summary>
        /// 资质证书编号
        /// </summary>
        private string abilityCardNO;
        /// <summary>
        /// 执业类型
        /// </summary>
        private NeuObject vocationType = new NeuObject();
        /// <summary>
        /// 执业范围
        /// </summary>
        private string vocationArea;
        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        #endregion

        #region 属性

        /// <summary>
        /// 聚合人员基本信息类

        /// </summary>
        public Neusoft.HISFC.Models.Base.Employee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
            }
        }
        /// <summary>
        /// 所学专业

        /// </summary>
        public NeuObject Speciality
        {
            get
            {
                return speciality;
            }
            set
            {
                speciality = value;
            }
        }
        /// <summary>
        /// 执业证书编号
        /// </summary>
        public string VocationCardNO
        {
            get
            {
                return vocationCardNO;
            }
            set
            {
                vocationCardNO = value;
            }
        }
        /// <summary>
        /// 资质证书编号
        /// </summary>
        public string AbilityCardNO
        {
            get
            {
                return abilityCardNO;
            }
            set
            {
                abilityCardNO = value;
            }
        }
        /// <summary>
        /// 执业类型
        /// </summary>
        public NeuObject VocationType
        {
            get
            {
                return vocationType;
            }
            set
            {
                vocationType = value;
            }
        }
        /// <summary>
        /// 执业范围
        /// </summary>
        public string VocationArea
        {
            get
            {
                return vocationArea;
            }
            set
            {
                vocationArea = value;
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
        #endregion

        #region 方法

        public new Ability Clone()
        {
            Ability ability = base.Clone() as Ability;
            ability.Employee = this.Employee.Clone();
            ability.Speciality = this.Speciality.Clone();
            ability.VocationType = this.VocationType.Clone();

            return ability;
        }

        #endregion

    }
}
