using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Material;

namespace Neusoft.HISFC.Components.Material
{
    public class MatFactory  : Neusoft.HISFC.Components.Material.IFactory
    {
        public MatFactory()
        {

        }

        public IMatManager GetInInstance(Neusoft.FrameWork.Models.NeuObject inPrivType, In.ucMatIn ucMatManager)
        {
            switch (inPrivType.Memo)
            {
                case "11":          //一般入库
                    return new Material.In.CommonInPriv(false, ucMatManager);
                case "13":          //内部入库申请
                    if (inPrivType.ID == "02")
                    {
                        return new Material.In.InnerApplyPriv(false, ucMatManager); 
                    }
                    else 
                    {
                        return new Material.In.BuyApplyPriv(false, ucMatManager); 
                    }
                case "1A":          //发票入库
                    return new Material.In.InvoiceInPriv(ucMatManager);
                case "16":          //核准入库
                    return new Material.In.ApproveInPriv(ucMatManager);
                case "18":          //内部入库退库申请
                    return new Material.In.InnerApplyPriv(true, ucMatManager);
                case "19":			//入库退库
                    return new Material.In.BackInPriv(ucMatManager);
                case "1C":          //系统切换入库
                    return new Material.In.CommonInPriv(true, ucMatManager);
                default:
                    return null;
                //				case "1C":          //特殊入库
                //					return new Pharmacy.In.CommonInPriv(true,ucMatManager);
                    
                //				case "18":          //内部入库退库申请
                //					return new Pharmacy.In.InnerApplyPriv(true,ucMatManager);
                //				case "1A":          //发票入库
                //					return new Pharmacy.In.InvoiceInPriv(ucMatManager);
                //				case "16":          //核准入库
                //					return new Pharmacy.In.ApproveInPriv(ucMatManager);     
                //				case "19":          //入库退库
                //					return new Pharmacy.In.BackInPriv(ucMatManager);
            }
        }

        public IMatManager GetOutInstance(Neusoft.FrameWork.Models.NeuObject outPrivType, Out.ucMatOut ucMatManager)
        {
            //			return new Material.Out.CommonOutPriv(false,ucMatManager);
            switch (outPrivType.Memo)
            {
                case "21":          //一般出库
                    return new Material.Out.CommonOutPriv(false, ucMatManager);
                case "26":          //特殊出库
                    return new Material.Out.CommonOutPriv(true, ucMatManager);
                //case "24":          //出库申请
                //    return null;
                case "25":          //出库审批
                    return new Material.Out.ExamOutPriv(ucMatManager);
                case "22":			//出库退库
                    return new Material.Out.BackOutPriv(ucMatManager);
            }
            return null;
        }

        //public IMatManager GetApplyInstance(Neusoft.FrameWork.Models.NeuObject applyPrivType, Apply.ucApply ucMatApply)
        //{
        //    //入出库申请
        //    //return new Material.Apply.InApplyPriv(false,ucMatApply);
        //    switch (applyPrivType.Memo)
        //    {
        //        case "13":          //内部入库申请
        //            return new Material.Apply.InApplyPriv(false, ucMatApply);
        //        case "18":          //内部入库退库申请
        //            return new Material.Apply.InApplyPriv(true, ucMatApply);
        //        case "24":          //出库申请
        //            return new Material.Apply.InApplyPriv(true, ucMatApply);
        //        default:
        //            return new Material.Apply.InApplyPriv(false, ucMatApply);

        //    }

        //    //return null;
        //}
    }
    
}
