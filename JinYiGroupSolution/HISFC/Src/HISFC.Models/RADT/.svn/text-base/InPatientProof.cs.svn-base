using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;
using System.Collections;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
    /// InPatientProof <br></br>
	/// [功能描述: 住院证实体]<br></br>
	/// [创 建 者: 何志力]<br></br>
	/// [创建时间: 2010.02.21]<br></br>
	/// </summary>
    [System.ComponentModel.DisplayName("住院证信息")]
    [Serializable]
	public class InPatientProof : Neusoft.HISFC.Models.Base.Spell
	{
		/// <summary>
        /// 住院证实体类
        ///zz_opr_inpatientproof   --门诊住院证记录
		/// </summary>
        public InPatientProof()
		{
		
		}
		#region 变量

		/// <summary>
        /// clinic_code,   --门诊流水号
		/// </summary>
        //private Neusoft.HISFC.Models.RADT.PID pid = new PID();
        private string clinic_code;

		/// <summary>
        /// card_no,   --门诊卡号
		/// </summary>
        private string card_no;

        //name,   --姓名
        private string name;

        //idenno,   --身份证号
        private string idenno;
                
        ///sex_code,   --性别
        private SexEnumService sex_code = new SexEnumService();

		// 出生日期
		private System.DateTime birthday;

		/// 年龄
		private string age;

        ///dept_code,   --科室代码
        private Neusoft.FrameWork.Models.NeuObject dept_code = new NeuObject();

        ///dept_name,   --科室名称
        private string dept_name;

        ///room,   --病室
        private string room;

        ///diagnose,   --诊断
        private string diagnose;

        ///address,   --地址
        private string address;

        ///intext,   --入院内容
        private string intext;

        ///wwfs,   --卧位方式：半卧、休克卧
        private string wwfs;

        ///is_ys,   --饮食：禁食、食
        private string is_ys;

        ///is_tj,   --抬价
        private string is_tj;

        ///is_zx,   --自行
        private string is_zx;

        ///is_my,   --沐浴
        private string is_my;

        ///is_lf,   --理发
        private string is_lf;

        ///in_date,   --开证日期
        private DateTime in_date;

        ///doct_code,   --开证医生
        private Neusoft.FrameWork.Models.NeuObject doct_code = new NeuObject();

        ///doct_name,   --医生名称

        ///inpatient_count,   --住院约计天数
        private int inpatient_count;

        ///is_drug,   --贵重药品：用、不用
        private string is_drug;

        ///ops_type,   --手术类型：大、中、小
        private string ops_type;
        
        ///blood_qty,   --输血数量
        private int blood_qty;

        ///xxfs,   --X光照相：一般、特别
        private string xxfs;

        ///memo,   --备注
        private string memo;

        ///memo1    --备注1
        private string memo1;

        #endregion

        #region 属性

        /// <summary>
		/// clinic_code,   --门诊流水号
		/// </summary>
		public string Clinic_code
		{
			get
			{
				return this.clinic_code;
			}
			set
			{
				this.clinic_code = value;
			}
		}

		/// <summary>
		/// card_no,   --门诊卡号
		/// </summary>
		public string Card_no
		{
			get
			{
				return this.card_no;
			}
			set
			{
				this.card_no = value;
			}
		}
        /// <summary>
        /// name, --姓名
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        [System.ComponentModel.DisplayName("身份证号")]
        [System.ComponentModel.Description("患者身份证号")]
		/// <summary>
		/// idenno,   --身份证号
		/// </summary>
        public string Idenno
        {
            get
            {
                return this.idenno;
            }
            set
            {
                this.idenno = value;
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public SexEnumService Sex_code
        {
            get { return sex_code; }
            set { sex_code = value; }
        }
        [System.ComponentModel.DisplayName("出生日期")]
        [System.ComponentModel.Description("患者出生日期")]
		/// <summary>
		/// 出生日期
		/// </summary>
		public System.DateTime Birthday
		{
			get
			{
				return this.birthday;
			}
			set
			{
				this.birthday = value;
			}
		}

        [System.ComponentModel.DisplayName("年龄")]
        [System.ComponentModel.Description("患者年龄")]
		/// <summary>
		/// 年龄
		/// </summary>
		public string Age
		{
			get
			{
				return this.age;
			}
			set
			{
				this.age = value;
			}
		}
        ///
        ///科室
        ///
        public Neusoft.FrameWork.Models.NeuObject Dept_code
        {
            get
            {
                return this.dept_code;
            }
            set
            {
                this.dept_code = value;
            }

        }
        ///
        /// 病室
        /// 
        public string Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
            }

        }
        ///
        ///diagnose,   --诊断
        ///
        public string Diagnose
        {
            get
            {
                return this.diagnose;
            }
            set
            {
                this.diagnose = value;
            }

        }
        ///
        ///address,   --地址
        ///
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }

        }
        ///
        ///intext,   --入院内容
        ///
        public string Intext
        {
            get { return intext; }
            set { intext = value; }
        }
        ///
        ///wwfs,   --卧位方式：半卧、休克卧
        ///
       public string Wwfs
        {
            get
            {
                return this.wwfs;
            }
            set
            {
                this.wwfs = value;
            }

        }
        ///
        ///is_ys,   --饮食：禁食、食
        ///
       public string Is_ys
        {
            get
            {
                return this.is_ys;
            }
            set
            {
                this.is_ys = value;
            }
        }
        ///
        ///is_tj,   --抬价
        ///
       public string Is_tj
        {
            get
            {
                return this.is_tj;
            }
            set
            {
                this.is_tj = value;
            }
        }
        ///
        ///is_zx,   --自行
        ///
       public string Is_zx
        {
            get
            {
                return this.is_zx;
            }
            set
            {
                this.is_zx = value;
            }
        }
        ///
        ///is_my,   --沐浴
        ///
       public string Is_my
        {
            get
            {
                return this.is_my;
            }
            set
            {
                this.is_my = value;
            }
        }
        ///
        ///is_lf,   --理发
        ///
       public string Is_lf
        {
            get
            {
                return this.is_lf;
            }
            set
            {
                this.is_lf = value;
            }
         }
        ///
        ///in_date,   --开证日期
        ///
        public System.DateTime In_date
        {
            get
            {
                return this.in_date;
            }
            set
            {
                this.in_date = value;
            }
        }

		/// <summary>
		///  住院证开据医师
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Doct_code
		{
			get
			{
				return this.doct_code;
			}
			set
			{
				this.doct_code = value;
			}
		}
        ///
        ///inpatient_count,   --住院约计天数
        ///
        public int Inpatient_count
        {
            get { return inpatient_count; }
            set { inpatient_count = value; }
        }
        ///
        ///is_drug,   --贵重药品：用、不用
        ///
        public string Is_drug
        {
          get { return is_drug; }
          set { is_drug = value; }
        }
        ///ops_type,   --手术类型：大、中、小
        public string Ops_type
        {
          get { return ops_type; }
          set { ops_type = value; }
        }
        
        ///blood_qty,   --输血数量
        public int Blood_qty
        {
          get { return blood_qty; }
          set { blood_qty = value; }
        }
        ///xxfs,   --X光照相：一般、特别
        public string Xxfs
        {
          get { return xxfs; }
          set { xxfs = value; }
        }
        ///memo,   --备注
        public string Memo1
        {
          get { return memo; }
          set { memo = value; }
        }
        ///memo1    --备注1
        public string Memo11
        {
          get { return memo1; }
          set { memo1 = value; }
        }
        #endregion

        #region 方法

        #region 克隆
        /// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
        public new InPatientProof Clone()
		{
            InPatientProof inpatientproof = base.Clone() as InPatientProof;

            inpatientproof.Sex_code = this.Sex_code.Clone();
            inpatientproof.Doct_code = this.Doct_code.Clone();

            return inpatientproof;
		}
		#endregion

		#endregion
		
		#region 过期


		#endregion
	}
}
