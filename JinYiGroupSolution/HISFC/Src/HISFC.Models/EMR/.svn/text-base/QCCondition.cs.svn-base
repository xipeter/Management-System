using System;
using System.Collections;
namespace neusoft.HISFC.Object.EMR
{
	/// <summary>
	/// QCCondition 的摘要说明。
	/// ID Type =0,1,2,3,4,5
	/// 
	///	"若输入 \'信息\'，符合\'条件\'", 0
	///	"若HIS\'信息\'，符合\'条件\'",  1
	///	"若病历 \'名称\'，已经\'建立\'", 2
	///	"若病历-\'名称\'，已经\'签名\'", 3
	///	"若病历+\'名称\'，建立时间,不在\'时间\'内", 4
	///	"若控件 \'名称\'，符合\'条件\'" 5
	/// </summary>
	public class QCCondition:neusoft.neuFC.Object.neuObject
	{
		public QCCondition()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 条件
		/// </summary>
		public new string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
				if(value.Length<4) return;
				string s = value.Substring(0,4);
				if(s =="若输入 ")
				{
					base.ID = "0";
				}
				else if(s =="若HIS")
				{
					base.ID = "1";
				}
				else if(s =="若病历 ")
				{
					base.ID = "2";
				}
				else if(s =="若病历-")
				{
					base.ID = "3";
				}
				else if(s =="若病历+")
				{
					base.ID = "4";
				}
				else if(s =="若控件 ")
				{
					base.ID = "5";
				}
				else//不认识的
				{
					return;
				}
				//转化
				int iPosition_start =0,iPosition_end =0;
				try
				{
					iPosition_start = value.IndexOf("'",0);
					iPosition_end = value.IndexOf("'",iPosition_start + 1);
					this.strInfoName = value.Substring(iPosition_start + 1,iPosition_end - iPosition_start -1);
				
					iPosition_start = value.IndexOf("'",iPosition_end + 1);
					iPosition_end = value.IndexOf("'",iPosition_start + 1);
					this.strInfoCondition = value.Substring(iPosition_start + 1,iPosition_end - iPosition_start -1);
				
				}
				catch{}
			}
		}
		private string strInfoName ="";
		/// <summary>
		/// 条件信息
		/// </summary>
		public string InfoName
		{
			get
			{
				return this.strInfoName;
			}
			
		}
		private string  strInfoCondition ="";
		/// <summary>
		/// 信息条件
		/// </summary>
		public string InfoCondition
		{
			get
			{
				return this.strInfoCondition;
			}
			
		}
		
	}
}
