using System;
using System.Collections;

namespace neusoft.HISFC.Object.Case 
{
    /*----------------------------------------------------------------
    // Copyright (C) 2004 东软股份有限公司
    // 版权所有。 
    //
    // 文件名：BedReportType.cs
    // 文件功能描述：住院动态日报实体
    //
    // 
    // 创建标识:
    //
    // 修改标识：周雪松 20060420
    // 修改描述：大脑一片空白
    //
    // 修改标识：
    // 修改描述：
    //----------------------------------------------------------------*/
	public class BedReportType: neusoft.neuFC.Object.neuObject 
    {
		
        public BedReportType() 
        {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        
        /// <summary>
        /// 日报枚举
        /// </summary>
		public enum enuBedReportType 
        {
			/// <summary>
			/// 常规入院
			/// </summary>
			IN_NORMAL = 0,
			/// <summary>
			/// 他科转入
			/// </summary>
			IN_TRANSFER = 1,
			/// <summary>
			/// 召回入院
			/// </summary>
			IN_RETURN = 2		
		}
	
        /// <summary>
        /// 名称
        /// </summary>
		public new string Name 
        {
			get 
            {
				string strName;
				switch ((int)this.ID) 
                {
					case 1:
						strName = "特殊药品摆药";
						break;
					case 2:
						strName = "出院带药摆药";
						break;
					default:
						strName = "一般摆药";
						break;
				}
				return	strName;
			}
		}

		/// <summary>
		/// 重载ID
		/// </summary>
		private enuBedReportType myID;
		public new System.Object ID 
        {
			get 
            {
				return this.myID;
			}
			set 
            {
				try 
                {
					this.myID=(this.GetIDFromName (value.ToString())); 
				}
				catch 
                {
					string err="无法转换"+this.GetType().ToString()+"编码！";
				}
				base.ID=this.myID.ToString();
				base.Name = this.Name;
			}
		}

        /// <summary>
        /// 根据名称返回枚举
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
		public enuBedReportType GetIDFromName(string Name) 
        {
			enuBedReportType c = new enuBedReportType();
			for(int i=0;i<100;i++) 
            {
				c = (enuBedReportType)i;
				if(c.ToString()==Name) return c;
			}
			return (enuBedReportType)int.Parse(Name);
		}

		/// <summary>
		/// 返回中文
		/// </summary>
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(DrugAttribute)</returns>
		public static ArrayList List()
        {
			BedReportType o;
			enuBedReportType e=new enuBedReportType();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
            {
				o=new BedReportType();
				o.ID=(enuBedReportType)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}
        
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
		public new BedReportType Clone() 
        {
			return base.Clone() as BedReportType;
		}
	}
}
