using System;

namespace Neusoft.HISFC.Models.AdminQuery
{
	
	/*----------------------------------------------------------------
	// Copyright (C) 2004 东软股份有限公司
	// 版权所有。 
	//
	// 文件名：FileTree.cs
	// 文件功能描述：ID 文件操作编码 NAME 文件操作名称 的摘要说明。
	//
	// 
	// 创建标识：无名氏 20050328
	//
	// 修改标识：周雪松 20060411
	// 修改描述：整理一下代码
	//
	// 修改标识：周雪松 20060411
	// 修改描述：增加克隆实体
	//----------------------------------------------------------------*/

	public class FileTree:Neusoft.FrameWork.Models.NeuObject
	{
		public FileTree()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        private Neusoft.FrameWork.Models.NeuObject upObj = new Neusoft.FrameWork.Models.NeuObject();   //承载实体                        
		private string strURL = "";															   //连接地址
		private string strTarget = "";														   //目标地址
		private bool isValid = false;														   //是否有效
		private string strLevel = "";														   //层级
		private string strActorID = "";														   //角色
	    private string strLoginID = "";														   //登录ID

		/// <summary>
		/// 上级编码
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject UpObj
		{
			get
			{
				return this.upObj;
			}
			set
			{
				this.upObj = value;
			}
		}
	
		/// <summary>
		/// 连接地址
		/// </summary>
		public string URL
		{
			get
			{
				return this.strURL;
			}
			set
			{
				this.strURL = value;
			}
		}

		/// <summary>
		/// 容器
		/// </summary>
		public string Target
		{
			get
			{
				return this.strTarget;
			}
			set
			{
				this.strTarget = value;
			}
		}

		/// <summary>
		/// 是否有效
		/// </summary>
		public bool Valid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
		}

		/// <summary>
		/// 层级
		/// </summary>
		public string Level
		{
			get
			{
				return this.strLevel;
			}
			set
			{
				this.strLevel = value;
			}
		}
		
		/// <summary>
		/// 角色标识
		/// </summary>
		public string ActorID
		{
			get
			{
				return this.strActorID;
			}
			set
			{
				this.strActorID = value;
			}
		}
		
		/// <summary>
		/// 登陆标识
		/// </summary>
		public string LoginID
		{
			get
			{
				return this.strLoginID;
			}
			set
			{
				this.strLoginID = value;
			}
		}

		/*
		周雪松 20060411
		增加克隆函数
		*/

		/// <summary>
		/// 克隆一下实体
		/// </summary>
		/// <returns></returns>
		public new FileTree Clone()
		{
			FileTree obj=base.MemberwiseClone() as FileTree;
			obj.upObj   =this.upObj.Clone();
			return obj;
		}

	}
}
