using System;
using System.Collections.Generic;
using System.Text;

namespace UFC.Pharmacy.Out
{
    public class PhaOutFactory
    {
        public PhaOutFactory()
        {
 
        }

        public UFC.Pharmacy.In.IPhaInManager GetInInstance(Neusoft.NFC.Object.NeuObject inPrivType,UFC.Pharmacy.Out.ucPhaOut ucPhaManager)
        {
            switch (inPrivType.Memo)
            {
                //case "11":          //一般入库
                //    return new UFC.Pharmacy.In.CommonInPriv(false,ucPhaManager);
                //case "1C":          //特殊入库
                //    return new UFC.Pharmacy.In.CommonInPriv(true,ucPhaManager);
                //case "13":          //内部入库申请
                //    return new UFC.Pharmacy.In.InnerApplyPriv(false,ucPhaManager);
                //case "18":          //内部入库退库申请
                //    return new UFC.Pharmacy.In.InnerApplyPriv(true,ucPhaManager);
                //case "1A":          //发票入库
                //    return new UFC.Pharmacy.In.InvoiceInPriv(ucPhaManager);
                //case "16":          //核准入库
                //    return new UFC.Pharmacy.In.ApproveInPriv(ucPhaManager);     
                //case "19":            //入库退库
                //    return new UFC.Pharmacy.In.BackInPriv(ucPhaManager);
            }

            return null;
        }

        public void GetOutInstance(Neusoft.NFC.Object.NeuObject outPrivType)
        {

        }
    }
}
