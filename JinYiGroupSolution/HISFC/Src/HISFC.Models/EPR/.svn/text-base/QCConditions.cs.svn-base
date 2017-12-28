using System;
using System.Collections;
namespace Neusoft.HISFC.Models.EPR
{
	/// <summary>
	/// QCCondition 的摘要说明。
	/// 质控条件 实体
	/// ID 编码，Name 指控名称
	/// </summary>
    [Serializable]
	public class QCConditions:Neusoft.FrameWork.Models.NeuObject
	{
		public QCConditions()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	
		/// <summary>
		/// 质量控制条件
		/// </summary>
		protected string strConditions = "";
		/// <summary>
		/// 质量控制条件
		/// </summary>
		public string Conditions
		{
			get
			{
				return this.strConditions;
			}
			set
			{
				this.strConditions = value;
				//分解字符串，付给QACondition，给alCondition,待解析。
				string[] s = strConditions.Split('\n');
				this.alConditions.Clear();
				for(int i=0;i<s.Length;i++)
				{
					if(s[i].Trim()!="")
					{
						Neusoft.HISFC.Models.EPR.QCCondition obj = new QCCondition();
						obj.Name = s[i].TrimStart();
						this.alConditions.Add(obj);
					}
				}
			}
		}
		protected ArrayList alConditions = new ArrayList();
		/// <summary>
		/// 获得条件数组
		/// </summary>
		public ArrayList AlConditions
		{
			get
			{
				return this.alConditions;
			}
			set
			{
				this.alConditions = value;
			}
		}
		protected QCAction action = new QCAction();
		/// <summary>
		/// 动作
		/// </summary>
		public QCAction Acion
		{
			get
			{
				return action;
			}
			set
			{
				this.action = value;
			}
		}

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new QCConditions Clone()
		{
			QCConditions newObj = new QCConditions();
			newObj = base.Clone() as QCConditions;
			newObj.alConditions = this.alConditions.Clone() as ArrayList;
			newObj.action = this.action.Clone();
			return newObj;
		}
	}
}
