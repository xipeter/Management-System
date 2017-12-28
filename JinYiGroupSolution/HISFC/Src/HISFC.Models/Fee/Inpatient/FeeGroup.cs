using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{
    //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
    public class FeeGroup :Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量
        /// <summary>
        /// 患者信息
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
        
        /// <summary>
        /// 当前科室
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject nurseCell = new Neusoft.FrameWork.Models.NeuObject();
        
        /// <summary>
        /// 项目信息
        /// </summary>
        Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item();

        /// <summary>
        /// 付数
        /// </summary>
        decimal days = 0;

        /// <summary>
        /// 项目类别
        /// </summary>
        string drugFlag = string.Empty;
        
        /// <summary>
        /// 收费时间
        /// </summary>
        DateTime feeDate = DateTime.MinValue;

        /// <summary>
        /// 执行科室
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject execDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 复合项目信息
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject package = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作环境
        /// </summary>
        Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        #endregion

        #region 属性
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        /// <summary>
        /// 当前科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseCell
        {
            get { return nurseCell; }
            set { nurseCell = value; }
        }

        /// <summary>
        /// 项目信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.Item Item
        {
            get { return item; }
            set { item = value; }
        }

        /// <summary>
        /// 项目类别
        /// </summary>
        public string DrugFlag
        {
            get { return drugFlag; }
            set { drugFlag = value; }
        }

        /// <summary>
        /// 付数
        /// </summary>
        public decimal Days
        {
            get { return days; }
            set { days = value; }
        }

        /// <summary>
        /// 收费时间
        /// </summary>
        public DateTime FeeDate
        {
            get { return feeDate; }
            set { feeDate = value; }
        }

        /// <summary>
        /// 执行科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ExecDept
        {
            get { return execDept; }
            set { execDept = value; }
        }


        /// <summary>
        /// 复合项目信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Package
        {
            get { return package; }
            set { package = value; }
        }

        
        /// <summary>
        /// 操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new FeeGroup Clone()
        {
            FeeGroup obj = base.Clone() as FeeGroup;
            obj.patient = this.patient.Clone();
            obj.nurseCell = this.nurseCell.Clone();
            obj.item = this.item.Clone();
            obj.oper = this.oper.Clone();
            obj.package = this.package.Clone();
            obj.execDept = this.execDept.Clone();
            return obj;
        }
        #endregion
    }
}
