using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.DefultInterfacesAchieve.Common
{
    public class ItemExtendInfoAchieve : Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo
    {

        #region 变量

        private Neusoft.HISFC.Models.Base.EnumItemType itemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;

        private Neusoft.FrameWork.Models.NeuObject pactInfo = new Neusoft.FrameWork.Models.NeuObject();

        #endregion

        #region IItemExtendInfo 成员

        public int GetItemExtendInfo(string ItemID, ref string ExtendInfoTxt, ref System.Collections.ArrayList AlExtendInfo)
        {
            string txtReturn = string.Empty;
            ArrayList al = new ArrayList();

            Neusoft.HISFC.BizLogic.Fee.Item itemMgr = new Neusoft.HISFC.BizLogic.Fee.Item();
            Neusoft.HISFC.BizLogic.Fee.UndrugPackAge undrugPkgMgr = new Neusoft.HISFC.BizLogic.Fee.UndrugPackAge();
            Neusoft.HISFC.BizLogic.Pharmacy.Item phaMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            //{A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
            Neusoft.HISFC.BizLogic.Fee.Interface feeInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();
            if (this.itemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                Neusoft.HISFC.Models.Pharmacy.Item drug = null;
                #region addby xuewj 2010-9-15 {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
                drug = phaMgr.GetItem(ItemID);
                #region addby xuewj 2010-10-1 {EA10BA8E-CBF4-4348-8BCE-9AD0D193CAE1}
                string rtnindication = feeInterface.ShowItemIndicationByPactAndItemCode(this.pactInfo.ID, ItemID); 
                #endregion
                string baseDrugInfo = drug.ExtendData2;
                string rtn = feeInterface.ShowItemGradeByPactAndItemCode(this.pactInfo.ID, ItemID);
                txtReturn = "药品编码：" + drug.ID + "\r\n" + "药品名称：" + drug.Name + "\r\n" + "自负比例：" + rtn + "\r\n" +
                    "国家基本药物编码：" + baseDrugInfo + "\r\n" +
                 "适应症：" + rtnindication + "\r\n" + "使用限制等级：" + "" + "\r\n" +//{EA10BA8E-CBF4-4348-8BCE-9AD0D193CAE1}
                "说明书：" + drug.Product.Manual + "\r\n";
                #endregion
            }

            if (this.itemType == Neusoft.HISFC.Models.Base.EnumItemType.UnDrug)
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = null;

                undrug = itemMgr.GetValidItemByUndrugCode(ItemID);

                #region {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
                //if (undrug != null && undrug.UnitFlag == "1")
                //{
                //    al = undrugPkgMgr.QueryUndrugPackagesBypackageCode(undrug.ID);
                //}
                if (undrug != null)
                {
                    #region addby xuewj 2010-10-1 {EA10BA8E-CBF4-4348-8BCE-9AD0D193CAE1}
                    string rtnindication = feeInterface.ShowItemIndicationByPactAndItemCode(this.pactInfo.ID, ItemID);
                    #endregion
                    string rtn = feeInterface.ShowItemGradeByPactAndItemCode(this.pactInfo.ID, ItemID);
                    txtReturn = "非药品编码：" + undrug.ID.Trim() + "  " + "非药品名称：" + undrug.Name.Trim() + "  " + "自负比例：" + rtn + "  "
                        + "适应症：" + rtnindication.Trim();
                }
                #endregion
            }

            ExtendInfoTxt = txtReturn;
            AlExtendInfo = al;

            return 1;
        }

        /// <summary>
        /// 项目类别
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumItemType ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }

        public Neusoft.FrameWork.Models.NeuObject PactInfo
        {
            get
            {
                return this.pactInfo;
            }
            set
            {
                this.pactInfo = value;
            }
        }

        #endregion
    }
}
