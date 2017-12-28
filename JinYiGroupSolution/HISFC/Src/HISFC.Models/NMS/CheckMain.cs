using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述：表格护理呈报考核记录主表实体]
    /// [创 建 者：张林]
    /// [创建时间：2008-10-7]
    /// [ID:呈报主表流水号 MEMO:备注]
    /// </summary>
    [System.Serializable]
    public class CheckMain:Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

        /// <summary>
        /// 构造函数[ID:呈报主表流水号 MEMO:备注]
        /// </summary>
        public CheckMain()
        {
        }

        #endregion 

        #region 变量

        /// <summary>
        /// 模板信息(模板主流水号，模板名称，模板副标题，模板查询码，模板类型)
        /// </summary>
        private ModelMain modelMain = new ModelMain();

        /// <summary>
        /// 护理部审核状态1申请2查看3审核
        /// </summary>
        private string nuState;

        /// <summary>
        /// 质控科审核状态1申请2查看3审核
        /// </summary>
        private string quState;

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private bool validFlag;

        ///// <summary>
        ///// 表头说明
        ///// </summary>
        //private string headerMark;

        ///// <summary>
        ///// 页脚说明
        ///// </summary>
        //private string footerMark;

        /// <summary>
        /// 首次录入时间
        /// </summary>
        private DateTime firstDate;

        /// <summary>
        /// 申请人环境(申请人，申请时间)
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment itemOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 护理部审核(护理部审核人，护理部审核时间，护理部审核意见)
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment nuApp = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 质控科审核(质控科审核人，质控科审核时间，质控科审核意见)
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment qcApp = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 被考核/呈报人
        /// </summary>
        private string checkOper;

        /// <summary>
        /// 被考核/呈报病区
        /// </summary>
        private string checkWard;

        /// <summary>
        /// 被考核/呈报科室
        /// </summary>
        private string checkDept;

        /// <summary>
        /// 考核日期(默认申请日期)
        /// </summary>
        private DateTime checkDate;

        /// <summary>
        /// 考核级别
        /// </summary>
        private string checkLevel;

        /// <summary>
        /// 考核类别
        /// </summary>
        private string checkType;

        /// <summary>
        /// 考核人员类型
        /// </summary>
        private string operType;

        /// <summary>
        /// 被考核/呈报人员类型
        /// </summary>
        private string checkOperType;

        #endregion

        #region 属性

        /// <summary>
        /// 模板信息（模板主流水号，模板名称，模板副标题，模板查询码，模板类型）
        /// </summary>
        public ModelMain ModelMain
        {
            get
            {
                return modelMain;
            }
            set
            {
                modelMain = value;
            }
        }

        /// <summary>
        /// 护理部审核状态1申请2查看3审核
        /// </summary>
        public string NuState
        {
            get
            {
                return nuState;
            }
            set
            {
                nuState = value;
            }
        }

        /// <summary>
        /// 质控科审核状态1申请2查看3审核
        /// </summary>
        public string QuState
        {
            get
            {
                return quState;
            }
            set
            {
                quState = value;
            }
        }

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        public bool ValidFlag
        {
            get
            {
                return validFlag;
            }
            set
            {
                validFlag = value;
            }
        }

        ///// <summary>
        ///// 表头说明
        ///// </summary>
        //public string HeaderMark
        //{
        //    get
        //    {
        //        return headerMark;
        //    }
        //    set
        //    {
        //        headerMark = value;
        //    }
        //}

        ///// <summary>
        ///// 页脚说明
        ///// </summary>
        //public string FooterMark
        //{
        //    get
        //    {
        //        return footerMark;
        //    }
        //    set
        //    {
        //        footerMark = value;
        //    }
        //}

        /// <summary>
        /// 首次录入时间
        /// </summary>
        public DateTime FirstDate
        {
            get
            {
                return firstDate;
            }
            set
            {
                firstDate = value;
            }
        }

        /// <summary>
        /// 申请人环境(申请人，申请时间)
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ItemOper
        {
            get
            {
                return itemOper;
            }
            set
            {
                itemOper = value;
            }
        }

        /// <summary>
        /// 护理部审核(护理部审核人，护理部审核时间，护理部审核意见)
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment NuApp
        {
            get
            {
                return nuApp;
            }
            set
            {
                nuApp = value;
            }
        }

        /// <summary>
        /// 质控科审核(质控科审核人，质控科审核时间，质控科审核意见)
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment QcApp
        {
            get
            {
                return qcApp;
            }
            set
            {
                qcApp = value;
            }
        }

        /// <summary>
        /// 被考核/呈报人
        /// </summary>
        public string CheckOper
        {
            get
            {
                return checkOper;
            }
            set
            {
                checkOper = value;
            }
        }

        /// <summary>
        /// 被考核/呈报病区
        /// </summary>
        public string CheckWard
        {
            get
            {
                return checkWard;
            }
            set
            {
                checkWard = value;
            }
        }

        /// <summary>
        /// 被考核/呈报科室
        /// </summary>
        public string CheckDept
        {
            get
            {
                return checkDept;
            }
            set
            {
                checkDept = value;
            }
        }

        /// <summary>
        /// 考核日期(默认申请日期)
        /// </summary>
        public DateTime CheckDate
        {
            get
            {
                return checkDate;
            }
            set
            {
                checkDate = value;
            }
        }

        /// <summary>
        /// 考核级别
        /// </summary>
        public string CheckLevel
        {
            get
            {
                return checkLevel;
            }
            set
            {
                checkLevel = value;
            }
        }

        /// <summary>
        /// 考核类别
        /// </summary>
        public string CheckType
        {
            get
            {
                return checkType;
            }
            set
            {
                checkType = value;
            }
        }

        /// <summary>
        /// 考核人员类型
        /// </summary>
        public string OperType
        {
            get
            {
                return operType;
            }
            set
            {
                operType = value;
            }
        }

        /// <summary>
        /// 被考核/呈报人员类型
        /// </summary>
        public string CheckOperType
        {
            get
            {
                return checkOperType;
            }
            set
            {
                checkOperType = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new CheckMain Clone()
        {
            CheckMain checkmain=base.Clone() as CheckMain;
            checkmain.ModelMain = this.modelMain.Clone();
            checkmain.ItemOper = this.itemOper.Clone();
            return checkmain;
        }

        #endregion

    }
}
