using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.DrugStore
{
    /// <summary>
    /// 门诊注射单据打印类
    /// 
    /// <功能说明>
    ///     1、该单据目前在门诊药房打印
    ///     2、在该类内实现时，同时打印门诊注射配液清单、门诊注射配液标签
    ///     3、该单据格式参考肿瘤医院项目形成
    /// </功能说明>
    /// </summary>
    public class ZLInjectPrintInstance : Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint
    {
        /// <summary>
        /// 
        /// </summary>
        public ZLInjectPrintInstance()
        {
 
        }

        #region  域变量

        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register patientInfo;

        /// <summary>
        /// 标签打印
        /// </summary>
        private ucCompoundLabel ucLabel = null;

        /// <summary>
        /// 门诊注射清单
        /// </summary>
        private ucZLInjectList ucInject = null;

        /// <summary>
        /// 是否打印配置标签
        /// </summary>
        private bool isPrintCompoundLabel = false;

        /// <summary>
        /// 待打印配置标签
        /// </summary>
        private System.Collections.ArrayList alGroupCompound = new ArrayList();

        #endregion

        #region 属性

        /// <summary>
        /// 是否打印配置标签
        /// </summary>
        public bool IsPrintCompoundLabel
        {
            get
            {
                return this.isPrintCompoundLabel;
            }
            set
            {
                this.isPrintCompoundLabel = value;
            }
        }

        #endregion

        #region IDrugPrint 成员

        public void AddAllData(System.Collections.ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void AddAllData(System.Collections.ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void AddAllData(System.Collections.ArrayList alData)
        {
            if (alData.Count <= 0)
            {
                return;
            }

            #region 患者信息赋值

            Neusoft.HISFC.Models.Pharmacy.ApplyOut tempApply = alData[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
            string clinicNO = tempApply.PatientNO;

            Neusoft.HISFC.BizLogic.Registration.Register registerManager = new Neusoft.HISFC.BizLogic.Registration.Register();
            Neusoft.HISFC.Models.Registration.Register register = registerManager.GetByClinic(clinicNO);

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut temp in alData)
            {
                temp.UseTime = temp.Operation.ApplyOper.OperTime;
                temp.PatientNO = register.PID.CardNO;
                temp.User02 = register.Name;
            }

            #endregion

            if (this.ucInject == null)
            {
                this.ucInject = new ucZLInjectList();
            }

            this.ucInject.AddAllData(alData);

            //对打印标签的情况 对数据按组合分组
            ComboSort comboSort = new ComboSort();
            alData.Sort(comboSort);

            ArrayList alGroupApplyOut = new ArrayList();
            ArrayList alCombo = new ArrayList();
            string privCombo = "-1";

            #region 标签打印

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alData)
            {
                if (privCombo == "-1" || (privCombo == info.CombNO && info.CombNO != ""))
                {
                    alCombo.Add(info.Clone());
                    privCombo = info.CombNO;
                    continue;
                }
                else			//不同处方号
                {
                    alGroupApplyOut.Add(alCombo);

                    privCombo = info.CombNO;
                    alCombo = new ArrayList();

                    alCombo.Add(info.Clone());
                }
            }

            if (alCombo.Count > 0)
            {
                alGroupApplyOut.Add(alCombo);
            }

            this.alGroupCompound = alGroupApplyOut;

            #endregion
        }

        public void AddCombo(System.Collections.ArrayList alCombo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void AddSingle(Neusoft.HISFC.Models.Pharmacy.ApplyOut info)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public decimal DrugTotNum
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public Neusoft.HISFC.Models.RADT.PatientInfo InpatientInfo
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public decimal LabelTotNum
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public Neusoft.HISFC.Models.Registration.Register OutpatientInfo
        {
            get
            {
                return this.patientInfo;
            }
            set
            {
                // TODO:  添加 ucClinicBill.PatientInfo setter 实现
                this.patientInfo = value;
                this.Clear();
            }
        }

        public void Preview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Print()
        {
            this.ucInject.Print();

            if (this.alGroupCompound != null && this.alGroupCompound.Count > 0)
            {
                if (this.ucLabel == null)
                {
                    this.ucLabel = new ucCompoundLabel();
                }

                this.ucLabel.LabelTotNum = this.alGroupCompound.Count;
                this.ucLabel.AddCombo(this.alGroupCompound);
                this.ucLabel.Print();
            }
        }

        #endregion

        /// <summary>
        /// 清屏操作
        /// </summary>
        public void Clear()
        {
            if (this.ucLabel != null)
            {
                this.ucLabel.Clear();
            }
            if (this.ucInject != null)
            {
                this.ucInject.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected class ComboSort : System.Collections.IComparer
        {
            public ComboSort() { }


            #region IComparer 成员

            public int Compare(object x, object y)
            {
                // TODO:  添加 FeeSort.Compare 实现
                Neusoft.HISFC.Models.Pharmacy.ApplyOut obj1 = x as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                Neusoft.HISFC.Models.Pharmacy.ApplyOut obj2 = y as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                if (obj1 == null || obj2 == null)
                    throw new Exception("数组内必须为Pharmacy.ApplyOut类型");
                int i1 = NConvert.ToInt32(obj1.CombNO);
                int i2 = NConvert.ToInt32(obj2.CombNO);
                return i1 - i2;
            }

            #endregion
        }
    }
}
