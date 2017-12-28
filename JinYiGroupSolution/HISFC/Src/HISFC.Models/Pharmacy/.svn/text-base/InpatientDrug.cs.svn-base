using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 住院发药查询实体类]
    /// [创 建 人: 孙久海]
    /// [创建时间: 2009-7-3]
    /// </summary>
    public class InpatientDrug : Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量

        /// <summary>
        /// 病人信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject patient = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 药品信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item drugInfo = new Neusoft.HISFC.Models.Pharmacy.Item();

        /// <summary>
        /// 单据号
        /// </summary>
        private string billNO = "";        

        /// <summary>
        /// 发生数量
        /// </summary>
        private decimal happenQty;

        /// <summary>
        /// 医生与操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment doctInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 病人信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Patient
        {
            get 
            { 
                return patient; 
            }
            set 
            {
                patient = value; 
            }
        }

        /// <summary>
        /// 药品信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item DrugInfo
        {
            get 
            { 
                return drugInfo; 
            }
            set 
            { 
                drugInfo = value; 
            }
        }

        /// <summary>
        /// 单据号
        /// </summary>
        public string BillNO
        {
            get
            {
                return billNO;
            }
            set
            {
                billNO = value;
            }
        }

        /// <summary>
        /// 发生数量
        /// </summary>
        public decimal HappenQty
        {
            get 
            { 
                return happenQty; 
            }
            set 
            {
                happenQty = value;
            }
        }

        /// <summary>
        /// 医生与操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment DoctInfo
        {
            get 
            {
                return doctInfo; 
            }
            set 
            { 
                doctInfo = value; 
            }
        }


        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new InpatientDrug Clone()
        {
            InpatientDrug iptDrug = new InpatientDrug();
            iptDrug.DoctInfo = this.DoctInfo.Clone();
            iptDrug.Patient = this.Patient.Clone();
            iptDrug.DrugInfo = this.DrugInfo.Clone();

            return iptDrug;
        }

        #endregion
    }
}
