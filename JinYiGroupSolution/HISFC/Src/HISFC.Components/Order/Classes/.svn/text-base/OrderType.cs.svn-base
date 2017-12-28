using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Order.Classes
{
    /// <summary>
    /// [功能描述: 医嘱状态公用内存常数]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class OrderType
    {

        protected static System.Collections.ArrayList longOrderTypes = null;
        
        /// <summary>
        /// 医嘱用的长期医嘱类型列表
        /// </summary>
        public static System.Collections.ArrayList LongOrderTypes
        {
            get
            {
                if (longOrderTypes == null)
                {
                    GetOrderType();
                }
                return longOrderTypes;
            }
            set
            {
                longOrderTypes = value;
            }
        }

        protected static System.Collections.ArrayList shortOrderTypes = null;

        /// <summary>
        /// 医嘱用的临时医嘱类型列表
        /// </summary>
        public static System.Collections.ArrayList ShortOrderTypes
        {
            get
            {
                if (shortOrderTypes == null)
                {
                    GetOrderType();
                }
                return shortOrderTypes;
            }
            set
            {
                shortOrderTypes = value;
            }
        }

        private static void GetOrderType()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList al = manager.QueryOrderTypeList();
            if (al == null) return;
            longOrderTypes = new System.Collections.ArrayList();
            shortOrderTypes = new System.Collections.ArrayList();
            foreach (Neusoft.HISFC.Models.Order.OrderType obj in al)
            {
                if (obj.IsDecompose)
                {
                    //判断是否应用当前医院，不则不添加
                    longOrderTypes.Add(obj);
                }
                else
                {
                    //判断是否应用当前医院，不则不添加
                    shortOrderTypes.Add(obj);
                }
            }
        }

        /// <summary>
        /// 可能会用到查询数据库，小心用
        /// </summary>
        /// <param name="charge"></param>
        /// <param name="isLong"></param>
        public static void CheckChargeableOrderType(ref Neusoft.HISFC.Models.Order.OrderType currentType,bool charge)
        {
            if(currentType.IsDecompose)
                CheckChargeableOrderType(ref currentType, charge, LongOrderTypes);
            else
                CheckChargeableOrderType(ref currentType, charge, ShortOrderTypes);
        }
        /// <summary>
        /// 重新取
        /// </summary>
        /// <param name="currentType"></param>
        /// <param name="charge"></param>
        /// <param name="reset">是否重新取</param>
        public static void CheckChargeableOrderType(ref Neusoft.HISFC.Models.Order.OrderType currentType, bool charge,bool reset)
        {
            if (currentType.IsDecompose)
                CheckChargeableOrderType(ref currentType, charge, LongOrderTypes,reset);
            else
                CheckChargeableOrderType(ref currentType, charge, ShortOrderTypes,reset);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="charge"></param>
        public static void CheckChargeableOrderType(ref Neusoft.HISFC.Models.Order.OrderType currentType,bool charge,System.Collections.ArrayList orderTypes)
        {
            //判断当前医嘱收费类型            
            if (currentType != null)
            {
                if (currentType.IsCharge == charge)
                    return;
            }
            //不符合，查找第一个符合的收费类型
            foreach (Neusoft.HISFC.Models.Order.OrderType obj in orderTypes)
            {
                if (obj.IsCharge == charge)
                {
                    currentType = obj.Clone();
                    return;
                }
            }
        }
        public static void CheckChargeableOrderType(ref Neusoft.HISFC.Models.Order.OrderType currentType, bool charge, System.Collections.ArrayList orderTypes,bool reset)
        {
            //判断当前医嘱收费类型            
            if (reset == false && currentType != null)
            {
                if (currentType.IsCharge == charge)
                    return;
            }
            //不符合，查找第一个符合的收费类型
            foreach (Neusoft.HISFC.Models.Order.OrderType obj in orderTypes)
            {
                if (obj.IsCharge == charge)
                {
                    currentType = obj.Clone();
                    return;
                }
            }
        }

    }
}
