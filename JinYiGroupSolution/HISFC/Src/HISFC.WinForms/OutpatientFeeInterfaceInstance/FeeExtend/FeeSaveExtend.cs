using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
//{DA12F709-B696-4eb9-AD3B-6C9DB7D780CF}
namespace OutpatientFeeInterfaceInstance.FeeExtend
{
    public class FeeSaveExtend : Neusoft.HISFC.BizProcess.Interface.FeeInterface.IFeeExtendOutpatient
    {
        #region 变量

        /// <summary>
        /// 当前his事务
        /// </summary>
        protected System.Data.IDbTransaction trans;

        /// <summary>
        /// 错误信息
        /// </summary>
        protected string errText = string.Empty;

        #endregion

        #region IFeeExtendOutpatient 成员

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Err
        {
            get 
            {
                return this.errText;
            }
        }

        /// <summary>
        /// 判断收费扩展是否合法
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="Invoices">发票信息集合</param>
        /// <param name="feeItemLists">费用信息实体</param>
        /// <param name="otherObjects">其他信息</param>
        /// <returns>成功 true 失败 false 错误信息包含在Err属性中</returns>
        public bool IsValid(Neusoft.HISFC.Models.Registration.Register r, System.Collections.ArrayList Invoices, System.Collections.ArrayList feeItemLists, params object[] otherObjects)
        {
            if (feeItemLists == null && feeItemLists.Count == 0) 
            {
                this.errText = "没有费用明细!";

                return false;
            }

            #region 判断试敏

            bool returnValue = this.IsAllergyValid(feeItemLists);
            if (!returnValue) 
            {
                return false;
            }

            #endregion

            return true;
        }

        /// <summary>
        /// 当前事务
        /// </summary>
        public System.Data.IDbTransaction Trans
        {
            set 
            {
                this.trans = value;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 判断试敏
        /// </summary>
        /// <param name="feeItemLists">费用明细实体</param>
        /// <returns>成功 true 失败 false 错误信息包含在Err属性内</returns>
        protected virtual bool IsAllergyValid(ArrayList feeItemLists) 
        {
            this.errText = string.Empty;
            
            //需要验证过敏结果的药品集合
            List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList> pharmarcys = new List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList>();
            //药品业务层
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            //医嘱业务层
            Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();
            //不合法项目列表
            ArrayList unValidList = new ArrayList();
            
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in feeItemLists)
            {
                //如果是药品,并且需要试敏,那么加入以下试敏列表pharmarcys
                if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    Neusoft.HISFC.Models.Pharmacy.Item itemTemp = pharmacyIntegrate.GetItem(f.Item.ID);
                    if (itemTemp == null) 
                    {
                        this.errText = "获得药品基本信息出错!" + pharmacyIntegrate.Err;

                        return false;
                    }
                    //如果需要试敏,那么加入列表
                    if (itemTemp.IsAllergy)
                    {
                        pharmarcys.Add(f);
                    }
                }
            }

            //如果药品条目为0， 就不用判断试敏
            if (pharmarcys.Count == 0)
            {
                return true;
            }

            //在医嘱表,判断试敏标记是否已经有值,没有试敏,或者试敏阳性,不能收费!
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in pharmarcys) 
            {
                //如果没有医嘱号,说明不是医生站开出的医嘱,不判断试敏.
                if (string.IsNullOrEmpty(f.Order.ID)) 
                {
                    continue;
                }

                Neusoft.HISFC.Models.Order.OutPatient.Order orderTemp = orderIntegrate.GetOneOrder(f.Order.ID);
                //如果没有取出医嘱信息,那么不判断试敏,因为某些从门诊直接披费的项目,也有MoOrder号;
                if (orderTemp == null) 
                {
                    continue;
                }

                //需要皮试,但是还没有皮试结果
                if (orderTemp.HypoTest == 2) 
                {
                    this.errText += "[ " + f.Item.Name  + " ]" + "应该皮试,没有皮试结果!" + "\n";

                    unValidList.Add(f);
                }
                if (orderTemp.HypoTest == 3) 
                {
                    this.errText += "[ " + f.Item.Name + " ]" + "皮试结果为阳性!" + "\n";

                    unValidList.Add(f);
                }
            }

            if (unValidList.Count > 0) 
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
