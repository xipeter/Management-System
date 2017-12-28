using System;
using System.Collections;
using Neusoft.NFC.Object;

namespace Neusoft.HISFC.Object.material
{
	/// <summary>
	/// ComEnumService 的摘要说明。
	/// </summary>
	public class ComEnumService:Neusoft.NFC.Object.NeuObject
	{		
		static ComEnumService()
		{
			items[EnumCompanyKind.Phamacy.ToString()] = "药品";
			items[EnumCompanyKind.Material.ToString()] = "物资";
			items[EnumCompanyKind.Equipment.ToString()] = "设备";
			items[EnumCompanyKind.All.ToString()] = "全部";
		}

		private EnumCompanyKind enumCompanyKind;

		protected static System.Collections.Hashtable items = new System.Collections.Hashtable();

		protected  System.Collections.Hashtable Items
		{
			get 
			{
				return items;
			}
		}


		protected  Enum EnumItem
		{
			get 
			{
				return enumCompanyKind;
			}
		}


		public new string ID
		{
			get
			{
				if (base.ID == null)
					return string.Empty;
				else
					return base.ID;
			}
			set
			{
				if (value == null)
				{
					base.ID = "";
					base.Name = "";
					return;
				}
				base.ID = value.ToString();
				System.Enum enumTemp = (EnumCompanyKind)Enum.Parse(this.enumCompanyKind.GetType(),base.ID);
				if (items.ContainsKey(base.ID))
					this.Name = items[base.ID].ToString();
				else
					this.Name = "";
			}
		}

		/// <summary>
		/// 得到项目中文列表数组
		/// </summary>
		/// <param name="items">Enum字典</param>
		/// <returns>NeuObject[]</returns>
		protected static NeuObject[] GetObjectItems(Hashtable items)
		{
			
			Neusoft.NFC.Object.NeuObject[] ret = new NeuObject[items.Count];
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
		/// 返回列表
		/// </summary>
		/// <returns>neuobject数组</returns>
		public new static System.Collections.ArrayList List()
		{
			return (new System.Collections.ArrayList(GetObjectItems(items)));
		}
	}

	public enum EnumCompanyKind
	{
		/// <summary>
		/// 药品
		/// </summary>
		Phamacy = 1,
		/// <summary>
		/// 物资
		/// </summary>
		Material = 2,
		/// <summary>
		/// 设备
		/// </summary>
		Equipment = 3,
		/// <summary>
		/// 全部
		/// </summary>
		All = 0,
	}
	
}
