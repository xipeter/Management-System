using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 药品静态方法类 ]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-07]<br></br>
    /// <修改记录 
    ///		修改人='耿晓雷' 
    ///		修改时间='2008-10-16' 
    ///		修改目的='增加对药品申请数据按照项目编码排序'
    ///		修改描述='{1B35A424-0127-42ff-96A4-6835D5DB0151}'
    ///		/>
    /// <说明>
    /// </说明>
    /// </summary>
    public class PharmacyMethod
    {
        /// <summary>
        /// 对药品申请数据按照项目编码排序
        /// </summary>
        /// <param name="alApplyOut"></param>
        public static void SortApplyOutByItemCode(ref System.Collections.ArrayList alApplyOut)
        {
            CompareApplyOutByItemCode compareInstance = new CompareApplyOutByItemCode();
            alApplyOut.Sort(compareInstance);
        }
    }

    /// <summary>
    /// 项目排序类
    /// </summary>
    internal class CompareApplyOutByItemCode : IComparer
    {
        public int Compare(object x, object y)
        {
            Neusoft.HISFC.Models.Pharmacy.ApplyOut o1 = (x as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();
            Neusoft.HISFC.Models.Pharmacy.ApplyOut o2 = (y as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();

            string oX = o1.Item.ID;
            string oY = o2.Item.ID;

            int nComp;

            if (oX == null)
            {
                nComp = (oY != null) ? -1 : 0;
            }
            else if (oY == null)
            {
                nComp = 1;
            }
            else
            {
                nComp = string.Compare(oX.ToString(), oY.ToString());
            }

            return nComp;
        }

    }

}
