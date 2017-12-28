using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{


	/// <summary>
	/// FinanceGroup<br></br>
	/// [功能描述: 财务组类 ID财务组编码 Name 财务组名称]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class FinanceGroup : NeuObject, ISort, IValidState
	{
		#region 变量
		
		/// <summary>
		/// 财务组人员信息
		/// </summary>
		private Employee employee = new Employee();
		
		/// <summary>
		/// 有效性 停用(0) 有效(1) 废弃(2)
		/// </summary>
		private EnumValidState validState;
		
        ///// <summary>
        ///// 有效性 根据ValidState属性变化,ValidState = "1" 为true其他值均为false
        ///// </summary>
        //private bool isValid;
		
		/// <summary>
		/// 序号
		/// </summary>
		private int sortID;

        /// <summary>
        /// 唯一主键
        /// </summary>
        private string pkID = string.Empty;

		#endregion

		#region 属性
		
		/// <summary>
		/// 财务组人员信息
		/// </summary>
		public Employee Employee
		{
			get
			{
				return this.employee;
			}
			set
			{
				this.employee = value;
			}
		}
		
		/// <summary>
		/// 有效性 停用(0) 有效(1) 废弃(2)
		/// </summary>
        public EnumValidState ValidState
		{
			get
			{
				return this.validState;
			}
			set
			{
				this.validState = value;
			}
		}

        /// <summary>
        /// 唯一主键
        /// </summary>
        public string PkID 
        {
            get 
            {
                return this.pkID;
            }
            set 
            {
                this.pkID = value;
            }
        }

		#endregion

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回但前对象实例的副本</returns>
		public new FinanceGroup Clone()
		{
			FinanceGroup financeGroup = base.Clone() as FinanceGroup;

			financeGroup.Employee = this.Employee.Clone();

			return financeGroup;
		}
		
		#endregion

		#endregion

		#region 接口实现

		#region ISort 成员

		/// <summary>
		/// 序号
		/// </summary>
		public int SortID
		{
			get
			{
				return this.sortID;
			}
			set
			{
				this.sortID = value;
			}
		}

		#endregion

        //#region IValid 成员
		
        ///// <summary>
        ///// 有效性 根据ValidState属性变化,ValidState = "1" 为true其他值均为false
        ///// </summary>
        //public bool IsValid
        //{
        //    get
        //    {
        //        if (this.validState == "1")
        //        {
        //            this.isValid = true;
        //        }
        //        else
        //        {
        //            this.isValid = false;
        //        }

        //        return this.isValid;
        //    }
        //    set
        //    {
        //        this.isValid = value;
        //    }
        //}

        //#endregion

		#endregion

		#region 无用属性,变量

		//public Neusoft.FrameWork.Models.NeuObject Employee = new Neusoft.FrameWork.Models.NeuObject();
		[Obsolete("废弃, PkID", true)]
		public string PKId;
		[Obsolete("废弃, 用Emplyee.ID代替", true)]
		public string EmployeeID;
		[Obsolete("废弃, 用Emplyee.Name的ID代替", true)]
		public string EmployeeName;	   
		
		#endregion


       
    }
}
