using System;

namespace neusoft.HISFC.Object.HealthCare
{
	/// <summary>
	/// Infection 的摘要说明。
	/// </summary>
	public class Infection: neusoft.neuFC.Object.neuObject
	{
		private System.String myId ;
		private System.String myZg ;
		private System.DateTime myInfectDate ;
		private System.String myIsOp ;
		private System.String myIsUrgop ;
		private System.String myInciType ;
		private System.DateTime myOpsDate ;
		private System.String myEndotrachealAnae ;
		private System.String myInfectSymptom ;
		private System.String myInfectDie ;
		private System.String myPathogenyInspect ;
		private System.String myPathogenyName1 ;
		private System.String myIsSusceptivity1 ;
		private System.String myIsInaction1 ;
		private System.String myPathogenyName2 ;
		private System.String myIsSusceptivity2 ;
		private System.String myIsInaction2 ;
		private System.String myAntibioticName ;
		private System.Int32 myAntibioticNum ;
		private System.String myOperCode ;
		private System.DateTime myOperDate ;
        private System.String isValid ;
		public Infection() 
		{
			// TODO: 在此处添加构造函数逻辑
		}


		/// <summary>
		/// 业务序号
		/// </summary>
		public System.String Id
		{
			get{ return this.myId; }
			set{ this.myId = value; }
		}

		/// <summary>
		/// 包含患者基本信息 ， 诊断信息 ，费用信息，结算信息 等 ID inpatientNO,name 名字,Memo 备注  
		/// </summary>
		public neusoft.HISFC.Object.RADT.PatientInfo PatientInfo=new neusoft.HISFC.Object.RADT.PatientInfo();


		/// <summary>
		/// 出院诊断
		/// </summary>
		public neusoft.neuFC.Object.neuObject OutDiag= new neusoft.neuFC.Object.neuObject();


		/// <summary>
		/// 转归
		/// </summary>
		public System.String Zg
		{
			get{ return this.myZg; }
			set{ this.myZg = value; }
		}


		/// <summary>
		/// 感染日期
		/// </summary>
		public System.DateTime InfectDate
		{
			get{ return this.myInfectDate; }
			set{ this.myInfectDate = value; }
		}


		/// <summary>
		/// 感染诊断代码
		/// </summary>
		public neusoft.neuFC.Object.neuObject InfectDiag = new neusoft.neuFC.Object.neuObject();


		/// <summary>
		/// 感染部位
		/// </summary>
		public neusoft.neuFC.Object.neuObject InfectPart = new neusoft.neuFC.Object.neuObject();


		/// <summary>
		/// 感染原因
		/// </summary>
		public neusoft.neuFC.Object.neuObject InfectReason = new neusoft.neuFC.Object.neuObject();
//		{
//			get{ return this.myInfectReason; }
//			set{ this.myInfectReason = value; }
//		}


		/// <summary>
		/// 是否手术
		/// </summary>
		public System.String IsOp
		{
			get{ return this.myIsOp; }
			set{ this.myIsOp = value; }
		}


		/// <summary>
		/// 手术代码
		/// </summary>
		public neusoft.neuFC.Object.neuObject OpsInfo = new neusoft.neuFC.Object.neuObject();
//		{
//			get{ return this.myOpsCode; }
//			set{ this.myOpsCode = value; }
//		}


//		/// <summary>
//		/// 手术名称
//		/// </summary>
//		public System.String OpsName
//		{
//			get{ return this.myOpsName; }
//			set{ this.myOpsName = value; }
//		}


		/// <summary>
		/// 是否急诊手术
		/// </summary>
		public System.String IsUrgop
		{
			get{ return this.myIsUrgop; }
			set{ this.myIsUrgop = value; }
		}


		/// <summary>
		/// 切口类型
		/// </summary>
		public System.String InciType
		{
			get{ return this.myInciType; }
			set{ this.myInciType = value; }
		}


		/// <summary>
		/// 手术日期
		/// </summary>
		public System.DateTime OpsDate
		{
			get{ return this.myOpsDate; }
			set{ this.myOpsDate = value; }
		}


		/// <summary>
		/// 是否气管内麻醉
		/// </summary>
		public System.String EndotrachealAnae
		{
			get{ return this.myEndotrachealAnae; }
			set{ this.myEndotrachealAnae = value; }
		}


		/// <summary>
		/// 感染临床症状
		/// </summary>
		public System.String InfectSymptom
		{
			get{ return this.myInfectSymptom; }
			set{ this.myInfectSymptom = value; }
		}


		/// <summary>
		/// 感染与死亡关系
		/// </summary>
		public System.String InfectDie
		{
			get{ return this.myInfectDie; }
			set{ this.myInfectDie = value; }
		}


		/// <summary>
		/// 病原学检查
		/// </summary>
		public System.String PathogenyInspect
		{
			get{ return this.myPathogenyInspect; }
			set{ this.myPathogenyInspect = value; }
		}


		/// <summary>
		/// 标本1
		/// </summary>
		public neusoft.neuFC.Object.neuObject LabSample1 = new neusoft.neuFC.Object.neuObject();
		
		/// <summary>
		/// 病原体种类
		/// </summary>
		public neusoft.neuFC.Object.neuObject PathogenyKind1 = new neusoft.neuFC.Object.neuObject();
		
		/// <summary>
		/// 病原体名称
		/// </summary>
		public System.String PathogenyName1
		{
			get{ return this.myPathogenyName1; }
			set{ this.myPathogenyName1 = value; }
		}


		

		/// <summary>
		/// 是否敏感
		/// </summary>
		public System.String IsSusceptivity1
		{
			get{ return this.myIsSusceptivity1; }
			set{ this.myIsSusceptivity1 = value; }
		}


		/// <summary>
		/// 是否耐药
		/// </summary>
		public System.String IsInaction1
		{
			get{ return this.myIsInaction1; }
			set{ this.myIsInaction1 = value; }
		}


		/// <summary>
		/// 标本2
		/// </summary>
		public neusoft.neuFC.Object.neuObject LabSample2 = new neusoft.neuFC.Object.neuObject();
		

		/// <summary>
		/// 病原体种类2
		/// </summary>
		public neusoft.neuFC.Object.neuObject PathogenyKind2 = new neusoft.neuFC.Object.neuObject();

		/// <summary>
		/// 病原体名称
		/// </summary>
		public System.String PathogenyName2
		{
			get{ return this.myPathogenyName2; }
			set{ this.myPathogenyName2 = value; }
		}

		/// <summary>
		/// 是否敏感
		/// </summary>
		public System.String IsSusceptivity2
		{
			get{ return this.myIsSusceptivity2; }
			set{ this.myIsSusceptivity2 = value; }
		}

		/// <summary>
		/// 是否耐药
		/// </summary>
		public System.String IsInaction2
		{
			get{ return this.myIsInaction2; }
			set{ this.myIsInaction2 = value; }
		}


		/// <summary>
		/// 使用抗生素名称
		/// </summary>
		public System.String AntibioticName
		{
			get{ return this.myAntibioticName; }
			set{ this.myAntibioticName = value; }
		}


		/// <summary>
		/// 抗生素种类
		/// </summary>
		public System.Int32 AntibioticNum
		{
			get{ return this.myAntibioticNum; }
			set{ this.myAntibioticNum = value; }
		}


		/// <summary>
		/// 登记人
		/// </summary>
		public System.String OperCode
		{
			get{ return this.myOperCode; }
			set{ this.myOperCode = value; }
		}


		/// <summary>
		/// 登记时间
		/// </summary>
		public System.DateTime OperDate
		{
			get{ return this.myOperDate; }
			set{ this.myOperDate = value; }
		}


		/// <summary>
		/// 是否有效
		/// </summary>
		public System.String IsValid
		{
			get{ return this.isValid; }
			set{ this.isValid = value; }
		}

	}
}
