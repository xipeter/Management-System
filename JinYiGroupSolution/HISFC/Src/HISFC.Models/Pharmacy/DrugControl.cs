using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 药品摆药控制台]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理'
	///  />
	///  ID		控制台编码
	///  Name	控制台名称
	/// </summary>
    [Serializable]
    public class DrugControl: Neusoft.FrameWork.Models.NeuObject 
	{
		public DrugControl() 
		{

		}
        
		#region 变量

		/// <summary>
		/// 摆药科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject myDept = new Neusoft.FrameWork.Models.NeuObject() ;

		/// <summary>
		/// 摆药属性
		/// </summary>
		private DrugBillClass myDrugBillClass = new DrugBillClass();

		/// <summary>
		/// 摆药单分类
		/// </summary>
		private DrugAttribute myDrugAttribute = new DrugAttribute();

		/// <summary>
		/// 发送类型
		/// </summary>
		private int mySendType;

		/// <summary>
		/// 显示等级
		/// </summary>
		private int myShowLevel;

        /// <summary>
        /// 是否自动打印摆药单
        /// </summary>
        private bool isAutoPrint = false;

        /// <summary>
        /// 是否打印门诊标签 该参数只对出院带药摆药有效
        /// </summary>
        private bool isPrintLabel = false;

        /// <summary>
        /// 摆药单是否需要预览 打印门诊标签时该字段无效
        /// </summary>
        private bool isBillPreview = false;

		#endregion

		/// <summary>
		/// 摆药科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept 
		{
			get
			{
				return this.myDept; 
			}
			set
			{
				this.myDept = value; 
			}
		}

		/// <summary>
		/// 摆药属性
		/// </summary>
		public DrugAttribute DrugAttribute 
		{
			get
			{
				return this.myDrugAttribute; 
			}
			set
			{ 
				this.myDrugAttribute = value; 
			}
		}

		/// <summary>
		/// 摆药单分类集合
		/// </summary>
		public DrugBillClass DrugBillClass  
		{
			get
			{
				return this.myDrugBillClass;
			}
			set
			{ 
				this.myDrugBillClass = value;
			}
		}

		/// <summary>
		/// 此摆药台接收的发送类型0全部，1集中，2临时
		/// </summary>
		public int SendType 
		{
			get
			{
				return this.mySendType; 
			}
			set
			{
				this.mySendType = value;
			}
		}

		/// <summary>
		/// 显示等级
		/// </summary>
		public int ShowLevel 
		{
			get 
			{
				return myShowLevel;
			}
			set 
			{
				myShowLevel = value;
			}
		}

        /// <summary>
        /// 是否自动打印摆药单
        /// </summary>
        public bool IsAutoPrint
        {
            get
            {
                return this.isAutoPrint;
            }
            set
            {
                this.isAutoPrint = value;
            }
        }

        /// <summary>
        /// 是否打印门诊标签 该参数只对出院带药摆药有效
        /// </summary>
        public bool IsPrintLabel
        {
            get
            {
                return this.isPrintLabel;
            }
            set
            {
                this.isPrintLabel = value;
            }
        }

        /// <summary>
        /// 摆药单是否需要预览 打印门诊标签时该字段无效
        /// </summary>
        public bool IsBillPreview
        {
            get
            {
                return this.isBillPreview;
            }
            set
            {
                this.isBillPreview = value;
            }
        }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExtendFlag;

        /// <summary>
        /// 扩展字段1
        /// </summary>
        public string ExtendFlag1;


		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>返回当前实例的副本</returns>
		public new DrugControl Clone()
		{
			DrugControl drugControl = base.Clone() as DrugControl;

			drugControl.Dept = this.Dept.Clone();
			drugControl.DrugAttribute = this.DrugAttribute.Clone();
			drugControl.DrugBillClass = this.DrugBillClass.Clone();

			return drugControl;
		}
	}
}
