using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述:受血人血液检验信息]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-06-05]<br></br>
    /// <修改>
    ///		<修改人></修改人>
    ///		<修改时间></修改时间>
    ///		<修改说明></修改说明>
    /// </修改>
    /// <说明>
    ///		
    /// </说明>
    /// </summary>
    [System.Serializable]
    public class BloodTest : Neusoft.FrameWork.Models.NeuObject
    {
        public BloodTest()
        {

        }


        #region 字段

        /// <summary>
        /// 血型ABO
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumBloodKind bloodType = Neusoft.HISFC.Models.Base.EnumBloodKind.U;

        /// <summary>
        /// 血型Hr
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult rh = Neusoft.HISFC.Models.Base.EnumTestResult.待查;

        /// <summary>
        /// 既往输血史

        /// </summary>
        private int bloodHistory;

        /// <summary>
        /// 孕产情况
        /// </summary>
        private string pregnant;

        /// <summary> 
        /// 血红蛋白

        /// </summary>
        private decimal hemation;

        /// <summary> 
        /// HCT
        /// </summary>
        private decimal hCT;

        /// <summary> 
        /// 血小板
        /// </summary>
        private decimal platelet;

        /// <summary> 
        /// ALT
        /// </summary>
        private decimal aLT;

        /// <summary> 
        /// Anti-HCV
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult anti_HCV;

        /// <summary> 
        /// Anti_HIV1/2
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult anti_HIV;

        /// <summary> 
        /// 梅毒
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult lues;

        /// <summary> 
        /// HBsAg
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult hBsAg;

        /// <summary> 
        /// 是否用用血互助金

        /// </summary>
        private bool isCharge;

        #endregion

        #region 属性


        /// <summary>
        /// 血型ABO
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumBloodKind BloodKind
        {
            get
            {
                return this.bloodType;
            }
            set
            {
                this.bloodType = value;
            }

        }


        /// <summary>
        /// 血型Hr
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumTestResult RH
        {
            get
            {
                return this.rh;
            }
            set
            {
                this.rh = value;
            }

        }


        /// <summary>
        /// 既往输血史

        /// </summary>
        public int BloodHistory
        {
            get
            {
                return this.bloodHistory;
            }
            set
            {
                this.bloodHistory = value;
            }
        }


        /// <summary>
        /// 孕产情况    
        /// </summary>
        public string Pregnant
        {
            get
            {
                return pregnant;
            }
            set
            {
                pregnant = value;
            }
        }


        /// <summary> 
        /// 血红蛋白

        /// </summary>
        public decimal Hemation
        {
            get
            {
                return hemation;
            }
            set
            {
                hemation = value;
            }
        }


        /// <summary> 
        /// HCT
        /// </summary>
        public decimal HCT
        {
            get
            {
                return hCT;
            }
            set
            {
                hCT = value;
            }
        }


        /// <summary> 
        /// 血小板
        /// </summary>
        public decimal Platelet
        {
            get
            {
                return platelet;
            }
            set
            {
                platelet = value;
            }
        }


        /// <summary> 
        /// Anti-HCV
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumTestResult Anti_HCV
        {
            get
            {
                return anti_HCV;
            }
            set
            {
                anti_HCV = value;
            }
        }


        /// <summary> 
        /// ALT
        /// </summary>
        public decimal ALT
        {
            get
            {
                return aLT;
            }
            set
            {
                aLT = value;
            }
        }


        /// <summary> 
        /// Anti_HIV1/2
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumTestResult Anti_HIV
        {
            get
            {
                return anti_HIV;
            }
            set
            {
                anti_HIV = value;
            }
        }


        /// <summary> 
        /// 梅毒
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumTestResult Lues
        {
            get
            {
                return lues;
            }
            set
            {
                lues = value;
            }
        }


        /// <summary> 
        /// HBsAg
        /// </summary> 
        public Neusoft.HISFC.Models.Base.EnumTestResult HBsAg
        {
            get
            {
                return hBsAg;
            }
            set
            {
                hBsAg = value;
            }
        }


        /// <summary> 
        /// 是否用用血互助金

        /// </summary>
        public bool IsCharge
        {
            get
            {
                return isCharge;
            }
            set
            {
                isCharge = value;
            }
        }


        #endregion

    }
}
