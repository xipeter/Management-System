using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord
{
    /// <summary>
	/// Const<br></br>
	/// [功能描述: 分娩记录实体]<br></br>
	/// [创 建 者: 杨永刚]<br></br>
	/// [创建时间: 2007-09-03]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class ChildbirthRecord:Neusoft.FrameWork.Models.NeuObject
   {
       #region 变量

       /// <summary>
       /// 患者信息
       /// </summary>
       private RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
       /// <summary>
       /// 婴儿性别
       /// </summary>
       private Neusoft.HISFC.Models.Base.EnumSex babySex = Neusoft.HISFC.Models.Base.EnumSex.M;
       /// <summary>
       /// 操作环境
       /// </summary>
       private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
       /// <summary>
       /// 序号
       /// </summary>
       private int happenNo;
       /// <summary>
       /// 是否正常分娩
       /// </summary>
       private bool isNormalChildbirth;
       /// <summary>
       /// 是否难产
       /// </summary>
       private bool isDystocia;
       /// <summary>
       /// 计划生育方式
       /// </summary>
       private HISFC.Models.Base.Const familyPlanning = new Neusoft.HISFC.Models.Base.Const();
       /// <summary>
       /// 会阴是否破裂
       /// </summary>
       private bool isPerineumBreak;
       /// <summary>
       /// 产妇类型
       /// </summary>
       private Neusoft.HISFC.Models.Base.Const womenKind = new Neusoft.HISFC.Models.Base.Const();
       /// <summary>
       /// 是否破裂
       /// </summary>
       private bool isBreak;
       /// <summary>
       /// 破裂程度
       /// </summary>
       private HISFC.Models.Base.Const breakLevel = new Neusoft.HISFC.Models.Base.Const();
       /// <summary>
       /// 小孩体重
       /// </summary>
       private decimal babyWeight = 0m;

       #endregion 

       #region 属性
       /// <summary>
       /// 患者信息
       /// </summary>
       public RADT.PatientInfo Patient
       {
           get
           {
               return this.patient;
           }
           set
           {
               this.patient = value;
           }
       }
       /// <summary>
       /// 序号
       /// </summary>
       public int HappenNO
       {
           get
           {
               return this.happenNo;
           }
           set
           {
               this.happenNo = value;
           }
       }
       /// <summary>
       /// 婴儿性别
       /// </summary>
       public Neusoft.HISFC.Models.Base.EnumSex BabySex
       {
           get
           {
               return this.babySex;
           }
           set
           {
               this.babySex = value;
           }
       }
       /// <summary>
       /// 操作环境
       /// </summary>
       public Neusoft.HISFC.Models.Base.OperEnvironment Oper
       {
           get
           {
               return this.oper;
           }
           set
           {
               this.oper = value;
           }
       }
       /// <summary>
       /// 是否正常分娩
       /// </summary>
       public bool IsNormalChildbirth
       {
           get
           {
               return this.isNormalChildbirth;
           }
           set
           {
               this.isNormalChildbirth = value;
           }
       }

       /// <summary>
       /// 是否难产
       /// </summary>
       public bool IsDystocia
       {
           get
           {
               return this.isDystocia;
           }
           set
           {
               this.isDystocia = value;
           }
       }
       /// <summary>
       /// 计划生育方式
       /// </summary>
       public HISFC.Models.Base.Const FamilyPlanning
       {
           get
           {
               return this.familyPlanning;
           }
           set
           {
               this.familyPlanning = value;
           }
       }
       /// <summary>
       /// 会阴是否破裂
       /// </summary>
       public bool IsPerineumBreak
       {
           get
           {
               return this.isPerineumBreak;
           }
           set
           {
               this.isPerineumBreak = value;
           }
       }
       /// <summary>
       /// 产妇类型
       /// </summary>
       public Neusoft.HISFC.Models.Base.Const WomenKind
       {
           get
           {
               return this.womenKind;
           }
           set
           {
               this.womenKind = value;
           }
       }
       /// <summary>
       /// 是否破裂
       /// </summary>
       public bool IsBreak
       {
           get
           {
               return this.isBreak;
           }
           set
           {
               this.isBreak = value;
           }
       }
       /// <summary>
       /// 破裂程度
       /// </summary>
       public Neusoft.HISFC.Models.Base.Const BreakLevel
       {
           get
           {
               return this.breakLevel;
           }
           set
           {
               this.breakLevel = value;
           }
       }
       /// <summary>
       /// 小孩体重
       /// </summary>
       public decimal BabyWeight
       {
           get
           {
               return this.babyWeight;
           }
           set
           {
               this.babyWeight = value;
           }
       }

       #endregion

       #region 方法

       #region 克降

       /// <summary>
       /// 克隆函数
       /// </summary>
       /// <returns>返回当前实例的副本</returns>
       public new ChildbirthRecord Clone()
       {
           ChildbirthRecord childbirthRecord = base.Clone() as ChildbirthRecord;

           childbirthRecord.Patient = this.Patient.Clone();

           childbirthRecord.Oper = this.Oper.Clone();

           return childbirthRecord;
       }

       #endregion

       #endregion
   }

  
}
