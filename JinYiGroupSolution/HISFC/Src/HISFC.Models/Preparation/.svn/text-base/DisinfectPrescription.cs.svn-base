using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Preparation
{
    /// <summary>
    /// Prescription<br></br>
    /// [功能描述: 制剂非药品成品配方]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-09-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class DisinfectPrescription : PrescriptionBase
    {
        /// <summary>
		/// 构造函数
		/// </summary>
        public DisinfectPrescription()
		{
		}

		#region  变量

		/// <summary>
		/// 成品
		/// </summary>
        private Fee.Item.Undrug drug = new Fee.Item.Undrug();

		#endregion

		#region  属性

		/// <summary>
		/// 制剂成品
		/// </summary>
        public Fee.Item.Undrug Drug
		{
			get
			{
				return this.drug;
			}
			set
			{
				this.drug = value;
                base.ID = value.ID;
                base.Name = value.Name;
			}
		}

        public override string ID
        {
            get
            {
                return base.ID;
            }
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }
        }

		#endregion

		#region 方法

		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>Prescription</returns>
        public new DisinfectPrescription Clone()
		{
            DisinfectPrescription prescription = base.Clone() as DisinfectPrescription;

			prescription.drug = this.drug.Clone();

			return prescription;
		}
		#endregion
    }
}
