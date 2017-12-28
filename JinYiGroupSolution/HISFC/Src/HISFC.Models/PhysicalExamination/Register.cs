using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.PhysicalExamination
{
    /// <summary>
    /// Register<br></br>
    /// [功能描述: 体检人员基本信息登记]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Register : Neusoft.HISFC.Models.RADT.Patient
    {
        #region  私有变量
        /// <summary>
        /// 体检档案号 
        /// </summary>
        private string archivesNO = string.Empty;

        /// <summary>
        /// 体检流水号
        /// </summary>
        private string clinicNO = string.Empty;

        /// <summary>
        /// 药物过敏
        /// </summary>
        private string isAnaphy = string.Empty;

        /// <summary>
        /// 身份类别
        /// </summary>
        private string identityLevel = string.Empty;

        /// <summary>
        /// 血压最高值
        /// </summary>
        private string bloodPressTop = string.Empty;

        /// <summary>
        /// 血压最低值
        /// </summary>
        private string bloodPressDown = string.Empty;

        /// <summary>
        /// 累计自费金额
        /// </summary>
        private decimal ownCost;

        /// <summary>
        /// 责任护士
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dutyNuse = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 体检单位
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject companyInfo = new Neusoft.FrameWork.Models.NeuObject();


        /// <summary>
        /// 家属类
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Kin kin = new Neusoft.HISFC.Models.RADT.Kin();
        /// <summary>
        /// 扩展标记1
        /// </summary>
        private string extCha = string.Empty;

        /// <summary>
        /// 扩展标记2
        /// </summary>
        private System.DateTime extDate;

        /// <summary>
        /// 扩展标记3 
        /// </summary>
        private int extNum;

        /// <summary>
        /// 扩展标记4 
        /// </summary>
        private string extCha1 = string.Empty;

        /// <summary>
        /// 扩展标记 6
        /// </summary>
        private int extNum1;

        /// <summary>
        /// 扩展标记 5
        /// </summary>
        private System.DateTime extDate1;

        /// <summary>
        /// 挂号科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject regDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 集体体检号
        /// </summary>
        private string collectivityCode = string.Empty;

        /// <summary>
        /// 集体体检登记日期
        /// </summary>
        private System.DateTime collectivityTime;

        /// <summary>
        /// 体检单位 部门
        /// </summary>
        private string companyDeptName = string.Empty;

        /// <summary>
        /// 体检内序号
        /// </summary>
        private string companyDeptSeq = string.Empty;

        /// <summary>
        /// 疾病护理信息类
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PDisease disease = new Neusoft.HISFC.Models.RADT.PDisease();
        /// <summary>
        /// 特殊体检类型 如 招工体检，出国体检等 
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject specalExamType;

        /// <summary>
        /// 操作员科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 划价项目
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

        /// <summary>
        /// 划价项目列表
        /// </summary>
        private ArrayList itemList = new ArrayList();
        private string recipeSequence = string.Empty;//最近一次发票组合号
        #endregion

        #region 属性
        /// <summary>
        /// 疾病护理信息类
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PDisease Disease
        {
            get
            {
                return disease;
            }
            set
            {
                disease = value;
            }
        }
        /// <summary>
        /// 家属类 
        /// </summary>
        public Neusoft.HISFC.Models.RADT.Kin Kin
        {
            get
            {
                return kin;
            }
            set
            {
                kin = value;
            }
        }
        public string RecipeSequence
        {
            get
            {
                return recipeSequence;
            }
            set
            {
                recipeSequence = value;
            }
        }
        /// <summary>
        /// 体检单位内部序号
        /// </summary>
        public string CompanyDeptSeq
        {
            get
            {
                return companyDeptSeq;
            }
            set
            {
                companyDeptSeq = value;
            }
        }

        /// <summary>
        /// 体检单位部门
        /// </summary>
        public string CompanyDeptName
        {
            get
            {
                return companyDeptName;
            }
            set
            {
                companyDeptName = value;
            }
        }

        /// <summary>
        /// 集体体检登记日期
        /// </summary>
        public System.DateTime CollectivityTime
        {
            get
            {
                return collectivityTime;
            }
            set
            {
                collectivityTime = value;
            }
        }

        /// <summary>
        /// 集体体检号
        /// </summary>
        public string CollectivityCode
        {
            get
            {
                return collectivityCode;
            }
            set
            {
                collectivityCode = value;
            }
        }

        /// <summary>
        ///  //扩展标记5
        /// </summary>
        public System.DateTime ExtDate1
        {
            get
            {
                return extDate1;
            }
            set
            {
                extDate1 = value;
            }
        }

        /// <summary>
        ///  //扩展标记2
        /// </summary>
        public System.DateTime ExtDate
        {
            get
            {
                return extDate;
            }
            set
            {
                extDate = value;
            }
        }

        /// <summary>
        /// 扩展标记3 
        /// </summary>
        public int ExtNum1
        {
            get
            {
                return extNum1;
            }
            set
            {
                extNum1 = value;
            }
        }

        /// <summary>
        /// 扩展标记3 
        /// </summary>
        public int ExtNum
        {
            get
            {
                return extNum;
            }
            set
            {
                extNum = value;
            }
        }

        /// <summary>
        /// 扩展标记
        /// </summary>
        public string ExtCha1
        {
            get
            {
                return extCha1;
            }
            set
            {
                extCha1 = value;
            }
        }

        /// <summary>
        /// 扩展标记
        /// </summary>
        public string ExtCha
        {
            get
            {
                return extCha;
            }
            set
            {
                extCha = value;
            }
        }

        /// <summary>
        /// 挂号科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject RegDept
        {
            get
            {
                return regDept;
            }
            set
            {
                regDept = value;
            }
        }

        /// <summary>
        /// 责任护士
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DutyNuse
        {
            get
            {
                return dutyNuse;
            }
            set
            {
                dutyNuse = value;
            }
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal OwnCost
        {
            get
            {
                return ownCost;
            }
            set
            {
                ownCost = value;
            }
        }

        /// <summary>
        /// 血压最低值
        /// </summary>
        public string BloodPressDown
        {
            get
            {
                return bloodPressDown;
            }
            set
            {
                bloodPressDown = value;
            }
        }

        /// <summary>
        /// 血压最高值
        /// </summary>
        public string BloodPressTop
        {
            get
            {
                return bloodPressTop;
            }
            set
            {
                bloodPressTop = value;
            }
        }

        /// <summary>
        /// 类型1 个人 2  集体
        /// </summary>
        public string ChkKind;

        /// <summary>
        /// //病史
        /// </summary>
        public string CaseHospital;

        /// <summary>
        ///  //家庭病史
        /// </summary>
        public string HomeCase;

        /// <summary>
        /// 体检日期
        /// </summary>
        public System.DateTime CheckTime;

        /// <summary>
        /// 划价项目列表
        /// </summary>
        public ArrayList ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
            }
        }

        /// <summary>
        /// 体检序号 
        /// </summary>
        public int ChkSortNO;

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TransType;

        /// <summary>
        ///体检项目
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Item.Undrug Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }

        /// <summary>
        /// 身份类别
        /// </summary>
        public string IdentityLevel
        {
            get
            {
                return identityLevel;
            }
            set
            {
                identityLevel = value;
            }
        }

        /// <summary>
        /// 体检单位 
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Company
        {
            get
            {
                return companyInfo;
            }
            set
            {
                companyInfo = value;
            }
        }

        /// <summary>
        /// 药物过敏 
        /// </summary>
        public string AnaphyFlag
        {
            get
            {
                return isAnaphy;
            }
            set
            {
                isAnaphy = value;
            }
        }

        
        /// <summary>
        /// 健康档案号
        /// </summary>
        public string ArchivesNO
        {
            get
            {
                return archivesNO;
            }
            set
            {
                archivesNO = value;
            }
        }

        /// <summary>
        /// 特殊体检类型 如 招工体检，出国体检等 
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SpecalChkType
        {
            get
            {
                if (specalExamType == null)
                {
                    specalExamType = new Neusoft.FrameWork.Models.NeuObject();
                }
                return specalExamType;
            }
            set
            {
                specalExamType = value;
            }
        }

        /// <summary>
        /// 体检流水号
        /// </summary>
        public string ChkClinicNo
        {
            get
            {
                return clinicNO;
            }
            set
            {
                clinicNO = value;
            }
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Operator
        {
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        }
        #endregion

        #region 克隆函数
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new Register Clone()
        {
            Register obj = base.Clone() as Register;
            obj.item = this.item.Clone();
            obj.Company = this.companyInfo.Clone();
            //obj.PatientInfo = this.PatientInfo.Clone();
            obj.regDept = this.regDept.Clone();
            obj.Operator = this.Operator.Clone();
            obj.dutyNuse = DutyNuse.Clone();
            obj.operDept = this.operDept.Clone();
            return obj;
        }
        #endregion

        #region 过期属性
        /// <summary>
        /// 病人实体类
        /// </summary>
        [Obsolete("废弃 继承 Patient", true)]
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return patientInfo;
            }
            set
            {
                patientInfo = value;
            }
        }

        /// <summary>
        /// 健康档案号
        /// </summary>
        [Obsolete("作废 用 ArchivesNO 代替", true)]
        public string CHKID
        {
            get
            {
                return archivesNO;
            }
            set
            {
                archivesNO = value;
            }
        }
        /// <summary>
        /// 体检单位 
        /// </summary>
        [Obsolete("作废 用 Company 代替", true)]
        public Neusoft.FrameWork.Models.NeuObject ChkCompany
        {
            get
            {
                return companyInfo;
            }
            set
            {
                companyInfo = value;
            }
        }
        /// <summary>
        /// 操作员科室
        /// </summary>
        [Obsolete("作废 用 operInfo 里的科室代替", true)]
        public Neusoft.FrameWork.Models.NeuObject OperDept
        {
            get
            {
                if (operDept == null)
                {
                    operDept = new Neusoft.FrameWork.Models.NeuObject();
                }
                return operDept;
            }
            set
            {
                operDept = value;
            }
        }
        /// <summary>
        /// 集体体检登记日期
        /// </summary>
        [Obsolete("作废 用 CollectivityTime代替", true)]
        public System.DateTime CollectivityDate
        {
            get
            {
                return collectivityTime;
            }
            set
            {
                collectivityTime = value;
            }
        }
        /// <summary>
        /// 体检单位部门
        /// </summary>
        [Obsolete("作废 用 CompanyDeptName代替", true)]
        public string DeptName
        {
            get
            {
                return companyDeptName;
            }
            set
            {
                companyDeptName = value;
            }
        }
        /// <summary>
        /// 体检单位内部序号
        /// </summary>
        [Obsolete("作废 用 CompanyDeptSeq代替", true)]
        public string DeptSeq
        {
            get
            {
                return companyDeptSeq;
            }
            set
            {
                companyDeptSeq = value;
            }
        }
        /// <summary>
        /// 身份类别
        /// </summary>
        [Obsolete("作废 用IdentityLevel代替", true)]
        public string ChkLevel
        {
            get
            {
                return identityLevel;
            }
            set
            {
                identityLevel = value;
            }
        }
        #endregion

        #region 过期变量

        [Obsolete("作废 用 ItemList 代替", true)]
        public ArrayList chkItemList = new ArrayList();

        /// <summary>
        /// 患者基本信息
        /// </summary>
        [Obsolete("作废 继承Patient 代替")]
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        #endregion

    }
}
