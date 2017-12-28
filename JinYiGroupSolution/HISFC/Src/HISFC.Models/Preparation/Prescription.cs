using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Prescription<br></br>
	/// [功能描述: 制剂成品配方]<br></br>
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
    public class Prescription : PrescriptionBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Prescription()
		{
		}

		#region  变量

		/// <summary>
		/// 成品
		/// </summary>
        private Pharmacy.Item drug = new Pharmacy.Item();

		#endregion

		#region  属性

		/// <summary>
		/// 制剂成品
		/// </summary>
        public Pharmacy.Item Drug
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
		public new Prescription Clone()
		{
			Prescription prescription = base.Clone() as Prescription;

			prescription.drug = this.drug.Clone();

			return prescription;
		}
		#endregion
	}
}
