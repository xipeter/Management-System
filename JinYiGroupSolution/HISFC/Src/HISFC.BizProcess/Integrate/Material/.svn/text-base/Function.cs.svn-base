using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.Material
{
    /// <summary>
    /// [功能描述: 药品静态方法类 ]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-07]<br></br>
    /// 
    /// <说明>
    /// </说明>
    /// </summary>
    public class MaterialSort
    {
        /// <summary>
        /// 对物资出库数据按照物资编码排序
        /// </summary>
        /// <param name="alApplyOut"></param>
        public static void SortApplyOutByItemID(ref List<Neusoft.HISFC.Models.FeeStuff.Output> alOut)
        {
            CompareApplyOutByItemID compareInstance = new CompareApplyOutByItemID();
            alOut.Sort(compareInstance);
        }

        /// <summary>
        /// 对物资出库数据按照部门加物资编码排序
        /// </summary>
        /// <param name="alApplyOut"></param>
        public static void SortOutputByDeptAndItemID(ref List<Neusoft.HISFC.Models.FeeStuff.Output> alOut)
        {
            CompareOutputByDeptAndItemID compareInstance = new CompareOutputByDeptAndItemID();
            alOut.Sort(compareInstance);
        }

        /// <summary>
        /// 对物资入库数据按照物资编码排序
        /// </summary>
        /// <param name="alApplyOut"></param>
        public static void SortInputByItemID(ref List<Neusoft.HISFC.Models.FeeStuff.Input> alInput)
        {
            CompareInputByItemID compareInstance = new CompareInputByItemID();
            alInput.Sort(compareInstance);
        }

        /// <summary>
        /// 对物资入库数据按照物资编码排序
        /// </summary>
        /// <param name="alStockPlan"></param>
        public static void SortStockPlanByCompany(ref List<Neusoft.HISFC.Models.FeeStuff.InputPlan> alStockPlan)
        {
            CompareStockPlanByCompany compareInstance = new CompareStockPlanByCompany();
            alStockPlan.Sort(compareInstance);
        }
    }

    /// <summary>
    /// 出库物资排序类
    /// </summary>
    internal class CompareApplyOutByItemID : IComparer<Neusoft.HISFC.Models.FeeStuff.Output>
    {
        public int Compare(Neusoft.HISFC.Models.FeeStuff.Output o1, Neusoft.HISFC.Models.FeeStuff.Output o2)
        {
            //Neusoft.HISFC.Models.Material.Output o1 = (x as Neusoft.HISFC.Models.Material.Output).Clone();
            //Neusoft.HISFC.Models.Material.Output o2 = (y as Neusoft.HISFC.Models.Material.Output).Clone();

            string oX = o1.StoreBase.Item.ID;
            string oY = o2.StoreBase.Item.ID;     

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

    /// <summary>
    /// 出库物资排序类
    /// </summary>
    internal class CompareOutputByDeptAndItemID : IComparer<Neusoft.HISFC.Models.FeeStuff.Output>
    {
        public int Compare(Neusoft.HISFC.Models.FeeStuff.Output o1, Neusoft.HISFC.Models.FeeStuff.Output o2)
        {
            //Neusoft.HISFC.Models.Material.Output o1 = (x as Neusoft.HISFC.Models.Material.Output).Clone();
            //Neusoft.HISFC.Models.Material.Output o2 = (y as Neusoft.HISFC.Models.Material.Output).Clone();

            string oX = o1.StoreBase.TargetDept.ID + o1.StoreBase.Item.ID;
            string oY = o2.StoreBase.TargetDept.ID + o2.StoreBase.Item.ID;

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

    /// <summary>
    /// 入库物资排序类
    /// </summary>
    internal class CompareInputByItemID : IComparer<Neusoft.HISFC.Models.FeeStuff.Input>
    {
        public int Compare(Neusoft.HISFC.Models.FeeStuff.Input o1, Neusoft.HISFC.Models.FeeStuff.Input o2)
        {
            //Neusoft.HISFC.Models.Material.Input o1 = (x as Neusoft.HISFC.Models.Material.Input).Clone();
            //Neusoft.HISFC.Models.Material.Input o2 = (y as Neusoft.HISFC.Models.Material.Input).Clone();

            string oX = o1.StoreBase.Item.ID;
            string oY = o2.StoreBase.Item.ID;

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

    /// <summary>
    /// 采购计划排序类
    /// </summary>
    internal class CompareStockPlanByCompany : IComparer<Neusoft.HISFC.Models.FeeStuff.InputPlan>
    {
        public int Compare(Neusoft.HISFC.Models.FeeStuff.InputPlan o1, Neusoft.HISFC.Models.FeeStuff.InputPlan o2)
        {
            string oX = o1.Company.ID + o1.StoreBase.Item.ID;
            string oY = o2.Company.ID + o2.StoreBase.Item.ID;

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
