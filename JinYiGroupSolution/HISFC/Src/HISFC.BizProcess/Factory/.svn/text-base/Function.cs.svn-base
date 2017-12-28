using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Factory
{
    /// <summary>
    /// 
    /// </summary>
    public class Function
    {

        private Function()
        {

        }

        public static void BeginTransaction()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
        }

        public static void Commit()
        {
            Neusoft.FrameWork.Management.PublicTrans.Commit();
        }

        public static void RollBack()
        {
            Neusoft.FrameWork.Management.PublicTrans.RollBack();
        }

        static EPRBase EPRmanager = null;
        static ManagerBase ManManager = null;
        static OrderBase OrderManager = null;
        static RADTBase RadtManager = null;

        /// <summary>
        /// 当前电子病历业务层
        /// </summary>
        public static EPRBase IntegrateEPR
        {
            get
            {
                if(EPRmanager == null)
                     EPRmanager = new EPRManagement();

                 return EPRmanager;
            }
        }

        /// <summary>
        /// 系统管理
        /// </summary>
        public static ManagerBase IntegrateManager
        {
            get
            {
                if (ManManager == null)
                    ManManager = new ManagerManagement();

                return ManManager;
            }
        }

        /// <summary>
        /// 医嘱部分
        /// </summary>
        public static OrderBase IntegrateOrder
        {
            get
            {
                if (OrderManager == null)
                    OrderManager = new OrderManagement();

                return OrderManager;
            }
        }

        /// <summary>
        /// 入出转部分
        /// </summary>
        public static RADTBase IntegrateRADT
        {
            get
            {
                if (RadtManager == null)
                    RadtManager = new RADTManagement();

                return RadtManager;
            }
        }

    }

    public class EPRManagement : EPRBase
    {

    }

    public class ManagerManagement : ManagerBase
    {
         
    }

    public class OrderManagement : OrderBase
    {

    }

    public class RADTManagement : RADTBase
    {

    }
    
}
