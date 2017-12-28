using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;
namespace Neusoft.HISFC.Components.Nurse.Controls
{
    public partial class ucEmergencyPatientProperty : UserControl
    {
        public ucEmergencyPatientProperty()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面属性，接收传过来的患者信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
                GetPatientProperty();
            }

        }
        private PatientInfo patientInfo = new PatientInfo();
        private PropertyGrid propertyGrid1;
        Neusoft.HISFC.Models.Registration.Register patient;
        private void GetPatientProperty()
        {

            if (this.Patient != null)
            {
                patientInfo.PatientNo = Patient.PID.ID;//住院号
                this.patientInfo.Sex = Patient.Sex.Name;//性别
                this.patientInfo.Age = Patient.Age;//年龄
                this.patientInfo.BedNo = Patient.PVisit.PatientLocation.Bed.Name;//床号
                this.patientInfo.InDept = Patient.PVisit.PatientLocation.Dept.Name;//科室
                this.patientInfo.PatientName = Patient.Name;//姓名
                //				this.patientInfo.Pact = Patient.Patient.Pact.Name;//合同单位
                this.patientInfo.Indate = Patient.PVisit.InTime.ToShortDateString();//住院日期
                //				this.patientInfo.Paykind = Patient.PayKind.Name;
                //			
                //			this.patientInfo. = Patient.PVisit.In_State.Name;//在院状态
                
                if (this.Patient.PVisit.OutTime != DateTime.MinValue)
                {
                    this.patientInfo.OutDate = Patient.PVisit.OutTime.ToShortDateString();//出院日期
                }
                else
                {
                    this.patientInfo.OutDate = "未出院";
                }
                //				this.patientInfo.BursaryTotMedFee = Patient.Fee.BursaryTotMedFee.ToString();//公费药
                

                decimal Pub = 0;
                decimal Own = 0;
               //				this.patientInfo.Available = (Patient.Fee.Left_Cost - Patient.PVisit.MoneyAlert).ToString();
                //				this.patientInfo.Caution = Patient.Caution.Name;
                //				this.patientInfo.AdmittingDoctor = Patient.PVisit.AdmittingDoctor.Name;
                //				this.patientInfo.AdmittingNurse = Patient.PVisit.AdmittingNurse.Name;
                //				this.patientInfo.AttendingDoctor = Patient.PVisit.AttendingDoctor.Name;
                this.patientInfo.InState = Patient.PVisit.InState.Name;
                //			this.patientInfo = Patient.Memo;

            }

            this.propertyGrid1.SelectedObject = patientInfo;
            //			propertyGrid1.SelectedObjects = new object[]{patientInfo,Patient.Patient,Patient.PayKind,Patient.PVisit,Patient.SIMainInfo,Patient.Caution,Patient.Diagnoses,Patient.Disease};
        }

        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(267, 482);
            this.propertyGrid1.TabIndex = 1;
            // 
            // ucEmergencyPatientProperty
            // 
            this.Controls.Add(this.propertyGrid1);
            this.Name = "ucEmergencyPatientProperty";
            this.Size = new System.Drawing.Size(267, 482);
            this.ResumeLayout(false);

        }
    }


    #region 属性类基类
    #region 所有要放在PropertyGird中的对像的基类.

    class IBaseProperty : ICustomTypeDescriptor
    {
        private PropertyDescriptorCollection globalizedProps;

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
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
            if (globalizedProps == null)
            {
                PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, attributes, true);

                globalizedProps = new PropertyDescriptorCollection(null);

                foreach (PropertyDescriptor oProp in baseProps)
                {
                    globalizedProps.Add(new BasePropertyDescriptor(oProp));
                }
            }
            return globalizedProps;
        }

        public PropertyDescriptorCollection GetProperties()
        {
            if (globalizedProps == null)
            {
                PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);
                globalizedProps = new PropertyDescriptorCollection(null);

                foreach (PropertyDescriptor oProp in baseProps)
                {
                    globalizedProps.Add(new BasePropertyDescriptor(oProp));
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

    class BasePropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor basePropertyDescriptor;

        public BasePropertyDescriptor(PropertyDescriptor basePropertyDescriptor)
            : base(basePropertyDescriptor)
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
                string svalue = "";
                foreach (Attribute attribute in this.basePropertyDescriptor.Attributes)
                {
                    if (attribute is showChinese)
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
    class showChinese : System.Attribute
    {
        private string sChineseChar = "";

        public showChinese(string sChineseChar)
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
    class PatientInfo : IBaseProperty
    {
        #region 患者基本信息
        private string Patientno = null; //患者住院号
        private string Patienname = null;//患者姓名
        //            private string  pPaykind = null;   //支付方式
        private string pSex = null;//患者性别
        //			private string  pBirthdate = null;//患者生日
        private string pAge = null;//患者年龄
        //			private string  pPact = null; //合同单位
        private string pIndate = null;//住院日期
        private string pDate_Out = null;//出院日期
        private string pInstate = null;//在院状态

        [DescriptionAttribute("患者住院号。"), showChinese("A.住院号"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
        public string PatientNo
        {
            get { return Patientno; }
            set { Patientno = value; }
        }

        [DescriptionAttribute("患者姓名。"), showChinese("B.姓名"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
        public string PatientName
        {
            get { return Patienname; }
            set { Patienname = value; }
        }

        [DescriptionAttribute("患者性别。"), showChinese("C.性别"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
        public string Sex
        {
            get { return pSex; }
            set { pSex = value; }
        }

        //			[DescriptionAttribute("患者生日。"),showChinese("患者生日:"),CategoryAttribute("患者基本信息"),ReadOnlyAttribute(false)]
        //			public string BirthDate
        //			{
        //				get { return pBirthdate; }
        //				set { pBirthdate = value; }
        //			}
        [DescriptionAttribute("患者年龄。"), showChinese("D.年龄"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
        public string Age
        {
            get { return pAge; }
            set { pAge = value; }
        }



        [DescriptionAttribute("入院日期。"), showChinese("E.入院日期"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
        public string Indate
        {
            get { return pIndate; }
            set { pIndate = value; }
        }
        [DescriptionAttribute("在院状态。"), showChinese("F.状态"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
        public string InState
        {
            get { return pInstate; }
            set { pInstate = value; }
        }

        [DescriptionAttribute("出院日期。"), showChinese("G.出院日期"), CategoryAttribute("1.患者基本信息"), ReadOnlyAttribute(false)]
        public string OutDate
        {
            get { return pDate_Out; }
            set { pDate_Out = value; }
        }

        //			[DescriptionAttribute("结算方式。"),showChinese("结算方式:"),CategoryAttribute("患者基本信息"),ReadOnlyAttribute(false)]
        //			public string Pact
        //			{
        //				get { return pPact; }
        //				set { pPact = value; }
        //			}
        //			[DescriptionAttribute("支付方式。"),showChinese("支付方式:"),CategoryAttribute("患者基本信息"),ReadOnlyAttribute(false)]
        //			public string Paykind
        //			{
        //				get { return pPaykind; }
        //				set { pPaykind = value; }
        //			}

        #endregion

        #region 入院信息
        private string pIndept = null;//入院科室
        private string pBedno = null;//床号
        //			private string  pAttendingDoctor = null;//主治医师
        //			private string  pAdmittingDoctor = null;//责任医师，住院医师
        //			private string  pAdmittingNurse = null;//责任护士


        [DescriptionAttribute("入院科室。"), showChinese("H.入院科室"), CategoryAttribute("2.住院信息"), ReadOnlyAttribute(false)]
        public string InDept
        {
            get { return pIndept; }
            set { pIndept = value; }
        }

        [DescriptionAttribute("患者床号。"), showChinese("I.患者床号"), CategoryAttribute("2.住院信息"), ReadOnlyAttribute(false)]
        public string BedNo
        {
            get { return pBedno; }
            set { pBedno = value; }
        }
        //			[DescriptionAttribute("主治医师。"),showChinese("主治医师:"),CategoryAttribute("住院信息"),ReadOnlyAttribute(false)]
        //			public string  AttendingDoctor
        //			{
        //				get { return pAttendingDoctor; }
        //				set { pAttendingDoctor = value;}
        //			}
        //			[DescriptionAttribute("责任医师，住院医师。"),showChinese("责任医师:"),CategoryAttribute("住院信息"),ReadOnlyAttribute(false)]
        //			public string  AdmittingDoctor
        //			{
        //				get { return pAdmittingDoctor; }
        //				set { pAdmittingDoctor = value;}
        //			}
        //			[DescriptionAttribute("责任护士。"),showChinese("责任护士:"),CategoryAttribute("住院信息"),ReadOnlyAttribute(false)]
        //			public string  AdmittingNurse
        //			{
        //				get { return pAdmittingNurse; }
        //				set { pAdmittingNurse = value;}
        //			}


        #endregion

        #region 患者费用信息
        //			private string pCaution = null ;//担保类别
        private string pTot_Cost = null;//总费用
        private string pPrepay_Cost = null;// 预交金
        //            private string pBalance_Cost = null ;//已结
        private string pLeft_Cost = null;//结余
        //            private string pBursaryTotMedFee = null;//公费药
        private string pDay_Limit = null;//日限额
        private string pLimitTot = null;//日限额累计

        //            private string pPub_Cost = null;//总记账
        private string pOwn_Cost = null;//自费
        private string pPay_Cost = null;//公费自付金额
        //			private string pAvailable = null;//可用金额




        [DescriptionAttribute("预交金。"), showChinese("J.预交金"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        public string PrepayCost
        {
            get { return pPrepay_Cost; }
            set { pPrepay_Cost = value; }
        }
        [DescriptionAttribute("自费。"), showChinese("K.自费"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        public string OwnCost
        {
            get { return pOwn_Cost; }
            set { pOwn_Cost = value; }
        }

        [DescriptionAttribute("总费用。"), showChinese("L.总费用"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        public string TotCost
        {
            get { return pTot_Cost; }
            set { pTot_Cost = value; }
        }



        //			[DescriptionAttribute("已结。"),showChinese("已结"),CategoryAttribute("3.患者费用信息"),ReadOnlyAttribute(false)]
        //			public string  BalanceCost
        //			{
        //				get { return pBalance_Cost; }
        //				set { pBalance_Cost = value;}
        //			}

        [DescriptionAttribute("余额。"), showChinese("M.余额"), CategoryAttribute("3.患者费用信息"), ReadOnlyAttribute(false)]
        public string LeftCost
        {
            get { return pLeft_Cost; }
            set { pLeft_Cost = value; }
        }

        #endregion

        #region 公费信息

        [DescriptionAttribute("日限额。"), showChinese("N.日限额"), CategoryAttribute("4.公费信息"), ReadOnlyAttribute(false)]
        public string DayLimit
        {
            get { return pDay_Limit; }
            set { pDay_Limit = value; }
        }
        [DescriptionAttribute("日限额累计。"), showChinese("O.日限额累计"), CategoryAttribute("4.公费信息"), ReadOnlyAttribute(false)]
        public string LimitTot
        {
            get { return pLimitTot; }
            set { pLimitTot = value; }
        }

        [DescriptionAttribute("公费自付金额。"), showChinese("P.公费自付金额"), CategoryAttribute("4.公费信息"), ReadOnlyAttribute(false)]
        public string PayCost
        {
            get { return pPay_Cost; }
            set { pPay_Cost = value; }
        }

        #endregion

            #endregion
    }


}
