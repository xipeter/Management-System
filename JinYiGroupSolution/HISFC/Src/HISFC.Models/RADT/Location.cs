using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// [功能描述: 患者位置实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2006-9-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [System.Serializable]
    public class Location:NeuObject
	{
		/// <summary>
		/// 患者位置类
		/// </summary>
		public Location()
		{
		}
		
		#region 变量

		/// <summary>
		/// 科室
		/// </summary>
		private  NeuObject dept = new NeuObject();

		/// <summary>
		/// 病区
		/// </summary>
		private NeuObject nurseCell=new NeuObject();

		/// <summary>
		/// 楼
		/// </summary>
		private string building;

		/// <summary>
		/// 层
		/// </summary>
		private string floor;

		/// <summary>
		/// 屋
		/// </summary>
		private string room;

		/// <summary>
		/// 病床
		/// </summary>
		private Bed bed=new Bed();

		#endregion
		
		#region 属性
		/// <summary>
		/// 科室
		/// </summary>
		public  NeuObject Dept
		{
			get
			{
				return this.dept; ;
			}
			set
			{
				this.dept = value;
			}
		}

		/// <summary>
		/// 病区
		/// </summary>
		public NeuObject NurseCell
		{
			get
			{
				return this.nurseCell;
			}
			set
			{
				this.nurseCell = value ;
			}
		}

		/// <summary>
		/// 楼
		/// </summary>
		public string Building
		{
			get
			{
				return this.building;
			}
			set
			{
				this.building = value ;
			}
		}

		/// <summary>
		/// 层
		/// </summary>
		public string Floor
		{
			get
			{
				return this.floor ;
			}
			set
			{
				this.floor = value ;
			}
		}

		/// <summary>
		/// 屋
		/// </summary>
		public string Room
		{
			get
			{
				return this.room ;
			}
			set
			{
				this.room = value ;
			}
		}
		/// <summary>
		/// 病床
		/// </summary>
		public Bed Bed
		{
			get
			{
				return this.bed ;
			}
			set
			{
				this.bed = value;
			}
		}
		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Location Clone()
		{
			Location location=base.MemberwiseClone() as Location;
			location.Bed=this.Bed.Clone();
			location.Dept=this.Dept.Clone();
			location.NurseCell=this.NurseCell.Clone();
			return location;
		}
		#endregion
	}
}
