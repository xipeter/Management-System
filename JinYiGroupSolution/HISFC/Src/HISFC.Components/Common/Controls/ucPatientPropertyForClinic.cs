using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucPatientPropertyForClinic : UserControl
    {
        public ucPatientPropertyForClinic()
        {
            InitializeComponent();
        }

        /// <summary>
		/// 页面属性，接收传过来的患者信息
		/// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            get 
            {
                return this.myPatientInfo;
            }
            set 
            {
                this.myPatientInfo = value;
                GetPatientProperty();
            }
        }


        private Neusoft.HISFC.Models.Registration.Register myPatientInfo = new Neusoft.HISFC.Models.Registration.Register();
        private PatientInfoForClinic patientInfo = new PatientInfoForClinic();
		
        private void GetPatientProperty()
		{

            if (this.PatientInfo != null)
			{
                Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManager = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
                
                this.patientInfo.PatientNo = myPatientInfo.PID.CardNO;//门诊病例号
                this.patientInfo.Sex = myPatientInfo.Sex.Name;//性别
                this.patientInfo.Age = orderManager.GetAge(myPatientInfo.Birthday);//年龄
                this.patientInfo.RegDoct = myPatientInfo.DoctorInfo.Templet.Doct.Name;
                this.patientInfo.RegDept = myPatientInfo.DoctorInfo.Templet.Dept.Name;//科室
                this.patientInfo.PatientName = myPatientInfo.Name;//姓名
                this.patientInfo.RegLevel = myPatientInfo.DoctorInfo.Templet.RegLevel.Name;
                this.patientInfo.RegDate = myPatientInfo.DoctorInfo.SeeDate.ToShortDateString();
                this.patientInfo.PactName = myPatientInfo.Pact.Name;
                
			}

			this.propertyGrid1.SelectedObject = patientInfo;
//			propertyGrid1.SelectedObjects = new object[]{patientInfo,Patient.Patient,Patient.PayKind,Patient.PVisit,Patient.SIMainInfo,Patient.Caution,Patient.Diagnoses,Patient.Disease};
		}
	}


	#region 属性类基类
	#region 所有要放在PropertyGird中的对像的基类.

	class IBasePropertyForClinic : ICustomTypeDescriptor
	{
		private PropertyDescriptorCollection globalizedProps;

		public String GetClassName()
		{
			return TypeDescriptor.GetClassName(this,true);
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this,true);
		}

		public String GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptor GetDefaultEvent() 
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		public PropertyDescriptor GetDefaultProperty() 
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		public object GetEditor(Type editorBaseType) 
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes) 
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			if ( globalizedProps == null) 
			{
				PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, attributes, true);

				globalizedProps = new PropertyDescriptorCollection(null);

				foreach( PropertyDescriptor oProp in baseProps )
				{
                    globalizedProps.Add(new BasePropertyDescriptorForClinic(oProp));
				}
			}
			return globalizedProps;
		}

		public PropertyDescriptorCollection GetProperties()
		{
			if ( globalizedProps == null) 
			{
				PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);
				globalizedProps = new PropertyDescriptorCollection(null);

				foreach( PropertyDescriptor oProp in baseProps )
				{
                    globalizedProps.Add(new BasePropertyDescriptorForClinic(oProp));
				}
			}
			return globalizedProps;
		}

		public object GetPropertyOwner(PropertyDescriptor pd) 
		{
			return this;
		}
	}
	#endregion

	#region 所以要放在PropertyGird中的对像的描绘进行重写

	class BasePropertyDescriptorForClinic : PropertyDescriptor
	{
        private PropertyDescriptor basePropertyDescriptor; 
  
		public BasePropertyDescriptorForClinic(PropertyDescriptor basePropertyDescriptor) : base(basePropertyDescriptor)
		{
			this.basePropertyDescriptor = basePropertyDescriptor;
		}

		public override bool CanResetValue(object component)
		{
			return basePropertyDescriptor.CanResetValue(component);
		}

		public override Type ComponentType
		{
			get { return basePropertyDescriptor.ComponentType; }
		}

		public override string DisplayName
		{
			get 
			{
				string svalue  = "";
				foreach(Attribute attribute in this.basePropertyDescriptor.Attributes)
				{
                    if (attribute is showChineseForClinic)
					{
						svalue = attribute.ToString();
						break;
					}
				}
				if (svalue == "") return this.basePropertyDescriptor.Name;
				else return svalue;
			}
		}

		public override string Description
		{
			get
			{
				return this.basePropertyDescriptor.Description;
			}
		}

		public override object GetValue(object component)
		{
			return this.basePropertyDescriptor.GetValue(component);
		}

		public override bool IsReadOnly
		{
			get { return this.basePropertyDescriptor.IsReadOnly; }
		}

		public override string Name
		{
			get { return this.basePropertyDescriptor.Name; }
		}

		public override Type PropertyType
		{
			get { return this.basePropertyDescriptor.PropertyType; }
		}

		public override void ResetValue(object component)
		{
			this.basePropertyDescriptor.ResetValue(component);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return this.basePropertyDescriptor.ShouldSerializeValue(component);
		}

		public override void SetValue(object component, object value)
		{
			this.basePropertyDescriptor.SetValue(component, value);
		}
	}
	#endregion


	#region 自定义属性用来显示左的边的汉字
	[AttributeUsage(AttributeTargets.Property)]
	class showChineseForClinic : System.Attribute
	{
		private string sChineseChar = "";

        public showChineseForClinic(string sChineseChar)
		{
			this.sChineseChar = sChineseChar;
		}

		public string ChineseChar
		{
			get
			{
				return this.sChineseChar;
			}
		}

		public override string ToString()
		{
			return this.sChineseChar;
		}
	}
	#endregion

	#endregion

	#region 患者属性类
	/// <summary>
	/// 用于显示患者属性
	/// </summary> 
    class PatientInfoForClinic : IBasePropertyForClinic
	{
		#region 患者基本信息
        private string Patientno = null; //患者门诊病例号
		private string Patienname = null;//患者姓名
		
		private string pSex = null;//患者性别
		
		private string pAge = null;//患者年龄


        [DescriptionAttribute("患者门诊病例号。"), showChineseForClinic("A.门诊病例号"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
		public string  PatientNo
		{
			get { return Patientno; }
			set { Patientno = value;}
		}

        [DescriptionAttribute("患者姓名。"), showChineseForClinic("B.姓名"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
		public string PatientName
		{
			get { return Patienname; }
			set { Patienname = value; }
		}

        [DescriptionAttribute("患者性别。"), showChineseForClinic("C.性别"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
		public string Sex
		{
			get { return pSex; }
			set { pSex = value; }
		}

        [DescriptionAttribute("患者年龄。"), showChineseForClinic("D.年龄"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
		public string Age
		{
			get { return pAge; }
			set { pAge = value; }
		}
        	
                
     	
		#endregion

		#region 挂号信息
		private string  regDept = null;//挂号科室
        private string regDoct = null;//挂号医生
        private string regLevel = null;//挂号级别
        private string pactName = null;//合同单位
        private string regDate = null;//挂号时间

        [DescriptionAttribute("挂号科室。"), showChineseForClinic("E.挂号科室"), CategoryAttribute("2.挂号信息"), ReadOnlyAttribute(false)]
		public string  RegDept
		{
            get { return regDept; }
            set { regDept = value; }
		}

        [DescriptionAttribute("挂号医生。"), showChineseForClinic("F.挂号医生"), CategoryAttribute("2.挂号信息"), ReadOnlyAttribute(false)]
		public string  RegDoct
		{
            get { return regDoct; }
            set { regDoct = value; }
		}

        [DescriptionAttribute("挂号级别。"), showChineseForClinic("G.挂号级别"), CategoryAttribute("2.挂号信息"), ReadOnlyAttribute(false)]
        public string RegLevel
        {
            get { return regLevel; }
            set { regLevel = value; }
        }

        [DescriptionAttribute("合同单位。"), showChineseForClinic("H.合同单位"), CategoryAttribute("2.挂号信息"), ReadOnlyAttribute(false)]
        public string PactName
        {
            get { return pactName; }
            set { pactName = value; }
        }

        [DescriptionAttribute("挂号时间。"), showChineseForClinic("I.挂号时间"), CategoryAttribute("2.挂号信息"), ReadOnlyAttribute(false)]
        public string RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

		#endregion

		#region 患者费用信息
		
        //private string pTot_Cost = null;//总费用
        //private string pPrepay_Cost = null ;// 预交金
		
        //private string pLeft_Cost = null ;//结余
		
        //private string pDay_Limit = null;//日限额
        //private string pLimitTot = null;//日限额累计
        		
        //private string pOwn_Cost = null;//自费
        //private string pPay_Cost = null;//公费自付金额





        //[DescriptionAttribute("预交金。"), showChineseForClinic("J.预交金"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        //public string  PrepayCost
        //{
        //    get { return pPrepay_Cost; }
        //    set { pPrepay_Cost = value;}
        //}
        //[DescriptionAttribute("自费。"), showChineseForClinic("K.自费"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        //public string  OwnCost
        //{
        //    get { return pOwn_Cost; }
        //    set { pOwn_Cost = value;}
        //}

        //[DescriptionAttribute("总费用。"), showChineseForClinic("L.总费用"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        //public string  TotCost
        //{
        //    get { return pTot_Cost; }
        //    set { pTot_Cost = value;}
        //}

        //[DescriptionAttribute("余额。"), showChineseForClinic("M.余额"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        //public string  LeftCost
        //{
        //    get { return pLeft_Cost; }
        //    set { pLeft_Cost = value;}
        //}

		#endregion

		#region 公费信息

        //[DescriptionAttribute("日限额。"), showChineseForClinic("N.日限额"), CategoryAttribute("4.公费信息"), ReadOnlyAttribute(false)]
        //public string  DayLimit
        //{
        //    get { return pDay_Limit; }
        //    set { pDay_Limit = value;}
        //}
        //[DescriptionAttribute("日限额累计。"), showChineseForClinic("O.日限额累计"), CategoryAttribute("4.公费信息"), ReadOnlyAttribute(false)]
        //public string  LimitTot
        //{
        //    get { return pLimitTot; }
        //    set { pLimitTot = value;}
        //}

        //[DescriptionAttribute("公费自付金额。"), showChineseForClinic("P.公费自付金额"), CategoryAttribute("4.公费信息"), ReadOnlyAttribute(false)]
        //public string  PayCost
        //{
        //    get { return pPay_Cost; }
        //    set { pPay_Cost = value;}
        //}
	
		#endregion

	 #endregion
	}	


	}
