using System;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// EnumService<br></br>
	/// [功能描述: Enum服务类基类，用于实现Enum中文名称]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-31]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
	public abstract class EnumServiceBase : NeuObject//, IEnumService
	{
		#region 变量

		
		#endregion
		
		#region 属性

		/// <summary>
		/// 保存Enum中文名称
		/// </summary>
		protected abstract Hashtable Items
		{
			get;
		}

		/// <summary>
		/// 枚举项目
		/// </summary>
		protected abstract Enum EnumItem
		{
			get;
		}
        /// <summary>
        /// 当设置的ID找不到时，将返回DefaultItem,默认为Enum第一项
        /// </summary>
        protected virtual Enum DefaultItem
        {
            get
            {
                return (Enum.GetValues(this.EnumItem.GetType())).GetValue(0) as Enum;
            }
        }
		/// <summary>
		/// ID
		/// </summary>
        public new object ID
        {
            get
            {
                if (base.ID == null)
                {
                    return string.Empty;
                }
                else
                {
                    return base.ID;
                }
            }
            set
            {
                
                if(value==null)
                {
                    base.ID = " ";
                    this.Name = " ";
                    return;
                }

                base.ID = value.ToString();

                if (base.ID.Trim().Length == 0)
                {
                    this.Name = base.ID;
                    return;
                }
                string t = base.ID;
                if (char.IsNumber(base.ID[0]))
                {
                    t = Enum.GetName(this.EnumItem.GetType(), int.Parse(base.ID));
                }
                if (t == null)
                {
                    t = this.DefaultItem.ToString();
                }
                this.Name = this.GetName((Enum)Enum.Parse(this.EnumItem.GetType(), t));
            }
        }

        ///// <summary>
        ///// 项目列表数组
        ///// </summary>
        //public static NeuObject[] ObjectItems
        //{
        //    get
        //    {
        //        return GetObjectItems(item);
        //    }
        //}

		/// <summary>
		/// 项目中文列表数组
		/// </summary>
		public string[] StringItems
		{
			get
			{
				return this.GetStringItems(this.Items);
			}
		}
		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new EnumServiceBase Clone()
		{
			EnumServiceBase enumServiceBase = base.Clone() as EnumServiceBase;

			return enumServiceBase;
		}

		/// <summary>
		/// 得到项目中文列表数组
		/// </summary>
		/// <param name="items">Enum字典</param>
		/// <returns>NeuObject[]</returns>
		protected static NeuObject[] GetObjectItems(Hashtable items)
		{
			
			NeuObject[] ret = new NeuObject[items.Count];
			int i=0;
			DictionaryEntry de;
			IEnumerator en=items.GetEnumerator();
			while(en.MoveNext())
			{
				ret[i] = new NeuObject();
				de=(DictionaryEntry)en.Current;
				ret[i].ID = (de.Key).ToString();
				ret[i].Name = items[de.Key] as string;
				i++;
			}

			return ret;
			
		}

		/// <summary>
		/// 得到项目中文列表数组
		/// </summary>
		/// <param name="items">Enum字典</param>
		/// <returns>string[]</returns>
		private string[] GetStringItems(Hashtable items)
		{
			
			string[] ret = new string[items.Count];
			int i=0;
			IEnumerator en=items.Values.GetEnumerator();
			while(en.MoveNext())
			{
				ret[i]=en.Current as string;
				i++;
			}

			return ret;		
		}

		/// <summary>
		/// 得到枚举中文名称
		/// </summary>
		/// <param name="enumType">枚举</param>
		/// <returns>枚举中文名称</returns>
		public string GetName(Enum enumType)
		{
			if (Items.ContainsKey(enumType)) 
			{
				return this.Items[enumType].ToString();
			}
			else
			{
				throw new EnumNotFoundException(enumType);
			}
		}

        public  ArrayList List()
        {
            return (new ArrayList(GetObjectItems(this.Items)));
        }
		#endregion

	}

}
