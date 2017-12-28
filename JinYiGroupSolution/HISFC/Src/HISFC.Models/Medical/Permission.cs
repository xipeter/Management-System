using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Medical
{
	/// <summary>
	/// [功能描述: 医疗管理权限实体，专门为医疗用]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
	public class Permission:Neusoft.FrameWork.Models.NeuObject
	{
		public Permission()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected Neusoft.HISFC.Models.Base.Employee myPerson = new Employee();
		/// <summary>
		/// 人员
		/// </summary>
		public Neusoft.HISFC.Models.Base.Employee Person
		{
			get
			{
				if(myPerson == null) myPerson = new Employee();
				return myPerson;
			}
			set
			{
				myPerson = value;
				base.ID = myPerson.ID;
				base.Name  = myPerson.Name;
			}
		}
		/// <summary>
		/// 人员编码
		/// </summary>
		public new string ID
		{
			get
			{
				return myPerson.ID;
			}
		}
		/// <summary>
		/// 人员名子
		/// </summary>
		public new string Name
		{
			get
			{
				return myPerson.Name;
			}
		}
		protected CPermission myOrderPermission = new CPermission();
		protected CPermission myEMRPermission =new CPermission();
		protected CPermission myQCPermission = new CPermission();
		/// <summary>
		/// 医嘱权限
		/// </summary>
		public CPermission OrderPermission
		{
			get
			{

				return this.myOrderPermission;
			}
			set
			{
				this.myOrderPermission = value;
			}
		}
		/// <summary>
		/// 医嘱授权起始时间
		/// </summary>
		public System.DateTime  DateBeginOrderPermission;
		/// <summary>
		/// 医嘱授权结束时间
		/// </summary>
		public  System.DateTime DateEndOrderPermission;
		/// <summary>
		/// 病历权限
		/// </summary>
		public CPermission EMRPermission
		{
			get
			{

				return this.myEMRPermission;
			}
			set
			{
				this.myEMRPermission = value;
			}
		}
		/// <summary>
		/// 指控权限
		/// </summary>
		public CPermission QCPermission
		{
			get
			{

				return this.myQCPermission;
			}
			set
			{
				this.myQCPermission = value;
			}
		}
		/// <summary>
		/// 操作人编码
		/// </summary>
		public string OperCode;
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OperDate;
		
		/// <summary>
		/// 重载克隆
		/// </summary>
		/// <returns></returns>
		public new Permission Clone()
		{
			Permission obj=base.Clone() as Permission;
			obj.Person = this.Person.Clone();
			obj.OrderPermission.Permission = this.OrderPermission.ToString();
			obj.EMRPermission.Permission = this.EMRPermission.ToString();
			obj.QCPermission.Permission = this.QCPermission.ToString();
			return obj;
		}

	}
	/// <summary>
	/// 权限类
	/// </summary>
	public class CPermission
	{
		public CPermission()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected string myPermission="";
		/// <summary>
		/// 当前权限
		/// </summary>
		public string Permission
		{
			set
			{
				myPermission = value;
			}
		}
		/// <summary>
		/// 获得权限
		/// </summary>
		/// <param name="iVal"></param>
		/// <returns></returns>
		public bool GetOnePermission(object iVal)
		{
			int i = 0;
			try
			{
				i = Neusoft.FrameWork.Function.NConvert.ToInt32(iVal);
			}
			catch{return false;}
			try
			{
				if(this.myPermission.Length<i) return false;
                i = Neusoft.FrameWork.Function.NConvert.ToInt32(myPermission.Substring(i, 1));
                return Neusoft.FrameWork.Function.NConvert.ToBoolean(i);
			}
			catch{return false;}
		}

        /// <summary>
        /// 获得权限
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetPermission(object obj)
        {
            int a = 0;
            try
            {
                a = Neusoft.FrameWork.Function.NConvert.ToInt32(obj);
            }
            catch { return -1; }
            try
            {
                if (this.myPermission.Length < a) return -1;
                a = Neusoft.FrameWork.Function.NConvert.ToInt32(myPermission.Substring(a, 1));
                return a;
            }
            catch { return -1; }

        }

		/// <summary>
		/// 返回当前权限
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.myPermission;
		}

	}

}
