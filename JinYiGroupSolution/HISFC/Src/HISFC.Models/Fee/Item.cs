using System;
using System.Data;

using System.Collections;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// 项目 非药品类继承于Neusoft.HISFC.Object.Item written by zhouxs 
	/// 2004-11-24 
	/// <br><a href="">Item</a></br>
	/// </summary>
	public class Item:Neusoft.HISFC.Object.Base.Item
	{
		/// <summary>
		/// 项目类 项目 非药品/类
		/// ID			非药品编码  
		/// Name		非药品名称  
		/// SysClass	系统类别
		/// MinFee		最小费用代码 
		/// UserCode   输入码
		/// SpellCode   拼音码
		/// WbCode      五笔
		/// GbCode      国标
		/// NationCode  国际标准代码
		/// Price       单价
		/// PriceUnit	单位
		/// EmcRate     急诊加成比例                       
		/// Family      计划生育标记
		/// Special     特定治疗项目
		/// ItemGrade   甲乙类
		/// ConfirmFlag 确认标志
		/// ValidState  有效性标识 0 在用 1 停用 2 废弃 
		/// Specs	    规格
		/// ExecuteDept 执行科室
		/// MachineNo	设备编号
		/// DefaultSample默认检查部位
		/// OperateId   手术编码
		/// OperateKind 手术分类
		/// OperateType 手术规模
		/// CollateFlag 是否有物资项目与之对照  22  手术分类  23 手术规模
		/// Mark        是否有物资项目与之对照(1有，0没有)
		/// OperCode    操作员
		/// OperDate    操作时间
		/// </summary>
		public Item()
		{
			// TODO: 在此处添加构造函数逻辑
			this.isPharmacy = false;
		}
		/// <summary>
		/// 执行科室
		/// </summary>
		private string exeDept;


		/// <summary>
		/// 急诊比例
		/// </summary>
		public decimal EmcRate;
		/// <summary>
		/// 计划生育标记
		/// </summary>
		public bool Family;
		///<summary>
		///确认标志
		///</summary>
		public bool  ConfirmFlag;
		/// <summary>
		/// 有效性标识 0 在用 1 停用 2 废弃 
		/// </summary>
		public bool  ValidState;
		///<summary>
		///执行科室
		///</summary>
		public ArrayList ExecuteDepts = new  ArrayList();
		/// <summary>
		/// 科室字符串
		/// </summary>
		public string ExecuteDept
		{
			get
			{
				return exeDept;
			}
			set
			{
				exeDept = value;
				string[] s =value.Split('|');
				this.ExecuteDepts.Clear();
				foreach(string temp in s)
				{
					ExecuteDepts.Add(temp);
				}

				//this.ExecuteDepts.CopyTo(s,0);
			}
		}
		
		///<summary>
		///设备编号
		///</summary>
		public ArrayList MachineNos = new ArrayList();
		/// <summary>
		/// 机器号码
		/// </summary>
		public string MachineNo
		{
			get
			{
				return "";
			}
			set
			{
				string[] s1=value.Split('|');
				this.MachineNos.Clear();
				this.MachineNos.CopyTo(s1,0);
			}
		}
		///<summary>
		///默认检查部位
		///</summary>
		public string  DefaultSample = "";
		///<summary>
		///是否有物资与之对照
		///</summary>
		///
		public bool  CollateFlag;
		/// <summary>
		/// 操作人
		/// </summary>
		public Neusoft.NFC.Object.NeuObject  OperInfo= new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate;
		/// <summary>
		/// 手术信息
		/// </summary>
		public Neusoft.NFC.Object.NeuObject  OperateInfo  = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 手术分类 ID 存储编码  name 存储名称
		/// </summary>
		public Neusoft.NFC.Object.NeuObject OperateKind = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 手术规模 ID存储编码 name存储名称
		/// </summary>
		public Neusoft.NFC.Object.NeuObject OperateType = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 疾病分类 id存储编码 name 存储名称
		/// </summary>
		public string DiscaseClass = "";
		/// <summary>
		/// 专科名称 
		/// </summary>
		public string SpecalDept  = "";
		/// <summary>
		/// 知情同意书
		/// </summary>
		public bool ConsentFlag ;
		/// <summary>
		///  病史及检查
		/// </summary>
		public string Mark1 = "";
		/// <summary>
		/// 检查要求  
		/// </summary>
		public string Mark2 = "";
		/// <summary>
		/// 注意事项           
		/// </summary>
		public string Mark3 = "";
		/// <summary>
		/// 检查申请单名称  
		/// </summary>
		public string Mark4 = "";
		/// <summary>
		/// 是否需要预约  1 需要 0 不需要  
		/// </summary>
		public string NeedBespeak;
		/// <summary>
		/// 项目范围
		/// </summary>
		public string ItemArea = "";
		/// <summary>
		/// 项目例外
		/// </summary>
		public string ItemNoArea = "";
		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public new Item  Clone()
		{
			return this.MemberwiseClone() as Item;
		}
	
	
	}
}