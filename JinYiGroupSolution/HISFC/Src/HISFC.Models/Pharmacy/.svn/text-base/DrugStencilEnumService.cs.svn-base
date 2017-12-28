using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
    [Serializable]
    public class DrugStencilEnumService : Neusoft.FrameWork.Models.NeuObject
    {
        static DrugStencilEnumService()
		{
            items[EnumDrugStencil.Check.ToString()] = "盘点";
            items[EnumDrugStencil.Plan.ToString()] = "计划";
            items[EnumDrugStencil.Apply.ToString()] = "申请";
		}

        private EnumDrugStencil enumDrugStencil;

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
				return enumDrugStencil;
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
                System.Enum enumTemp = (EnumDrugStencil)Enum.Parse(this.enumDrugStencil.GetType(), base.ID);
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
		/// <returns>neuObject[]</returns>
		protected static Neusoft.FrameWork.Models.NeuObject[] GetObjectItems(Hashtable items)
		{
            Neusoft.FrameWork.Models.NeuObject[] ret = new Neusoft.FrameWork.Models.NeuObject[items.Count];
			int i=0;
			DictionaryEntry de;
			IEnumerator en = items.GetEnumerator();
			while(en.MoveNext())
			{
				ret[i] = new Neusoft.FrameWork.Models.NeuObject();
				de = (DictionaryEntry)en.Current;
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

    public enum EnumDrugStencil
    {
        /// <summary>
        /// 盘点
        /// </summary>
        Check,
        /// <summary>
        /// 计划
        /// </summary>
        Plan,
        /// <summary>
        /// 申请
        /// </summary>
        Apply
    }
}
