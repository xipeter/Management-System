using System;
using System.Collections;
using Neusoft.FrameWork.Function;
namespace Neusoft.FrameWork.Management
{
	/// <summary>
	/// ExtendParam 的摘要说明。
	/// </summary>
	public class ExtendParam:Database
	{
		public ExtendParam()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 取特定项目、特定编码的扩展属性
		/// </summary>
		/// <param name="enuExtendClass"></param>
		/// <param name="PropertyCode"></param>
		/// <param name="ItemCode"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.ExtendInfo GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass enuExtendClass,string PropertyCode,string ItemCode)
		{
			string strSQL = "";
			string strWhere = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.ComExtInfo.GetComExtInfoList",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.GetComExtInfoList字段!";
				return null;
			}
			if (this.Sql.GetSql("Manager.ComExtInfo.And.ItemID",ref strWhere) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.And.ItemID字段!";
				return null;
			}
			//格式化SQL语句
			try 
			{
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL,enuExtendClass.ToString(), PropertyCode, ItemCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.And.ItemID:" + ex.Message;
				return null;
			}

			//取项目属性数据
			ArrayList al = this.myGetComExtInfo(strSQL);
			if(al == null) return null;

			if(al.Count == 0) 
				return new Neusoft.HISFC.Models.Base.ExtendInfo();

			return al[0] as Neusoft.HISFC.Models.Base.ExtendInfo;
		}


		/// <summary>
		/// 取项目的数值属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="ItemCode">项目编码</param>
		/// <returns>数值属性</returns>
		public decimal GetComExtInfoNumber(Neusoft.HISFC.Models.Base.EnumExtendClass enuExtendClass,string PropertyCode,string ItemCode) 
		{
			//取项目项目的扩展属性实体
			Neusoft.HISFC.Models.Base.ExtendInfo ext = this.GetComExtInfo(enuExtendClass,PropertyCode, ItemCode);
			if(ext == null) 
				return 0M;
			else
				return ext.NumberProperty;
		}


		/// <summary>
		/// 取项目的字符属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="ItemCode">项目编码</param>
		/// <returns>字符属性</returns>
		public string GetComExtInfoString(Neusoft.HISFC.Models.Base.EnumExtendClass enuExtendClass,string PropertyCode,string ItemCode) 
		{
			//取项目扩展属性实体
			Neusoft.HISFC.Models.Base.ExtendInfo ext = this.GetComExtInfo(enuExtendClass,PropertyCode, ItemCode);
			if(ext == null) 
				return "";
			else
				return ext.StringProperty;
		}

		
		/// <summary>
		/// 取项目的日期属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="ItemCode">项目编码</param>
		/// <returns>日期属性</returns>
		public DateTime GetComExtInfoDateTime(Neusoft.HISFC.Models.Base.EnumExtendClass enuExtendClass,string PropertyCode,string ItemCode) 
		{
			//取项目扩展属性实体
			Neusoft.HISFC.Models.Base.ExtendInfo ext = this.GetComExtInfo(enuExtendClass,PropertyCode, ItemCode);
			if(ext == null) 
				return DateTime.MinValue;
			else
				return ext.DateProperty;
		}


		/// <summary>
		/// 取某一扩展属性数据
		/// </summary>
		/// <param name="propertyCode">属性编码</param>
		/// <returns>项目属性数组，出错返回null</returns>
		public ArrayList GetComExtInfoList(Neusoft.HISFC.Models.Base.EnumExtendClass enuExtendClass,string propertyCode) 
		{
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.ComExtInfo.GetComExtInfoList",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.GetComExtInfoList字段!";
				return null;
			}

			//格式化SQL语句
			try 
			{
				strSQL = string.Format(strSQL,enuExtendClass, propertyCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.GetComExtInfoList:" + ex.Message;
				return null;
			}

			//取项目属性数据
			return this.myGetComExtInfo(strSQL);
		}


		/// <summary>
		/// 向项目属性表中插入一条记录
		/// </summary>
		/// <param name="extendInfo">项目扩展属性</param>
		/// <returns></returns>
		public int InsertComExtInfo(Neusoft.HISFC.Models.Base.ExtendInfo extendInfo) 
		{
			string strSQL="";
			//取插入操作的SQL语句
			if(this.Sql.GetSql("Manager.ComExtInfo.InsertComExtInfo",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.InsertComExtInfo字段!";
				return -1;
			}
			try 
			{  
				string[] strParm = myGetParmComExtInfo( extendInfo );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.InsertComExtInfo:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 更新项目属性表中一条记录
		/// </summary>
		/// <param name="extendInfo">项目扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdateComExtInfo(Neusoft.HISFC.Models.Base.ExtendInfo extendInfo) 
		{
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.ComExtInfo.UpdateComExtInfo",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.UpdateComExtInfo字段!";
				return -1;
			}
			try 
			{  
				string[] strParm = myGetParmComExtInfo( extendInfo );     //取参数列表
				strSQL=string.Format(strSQL, strParm);						//替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.UpdateComExtInfo:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 删除项目属性表中一条记录
		/// </summary>
		/// <param name="enuExtendClass"></param>
		/// <param name="itemCode"></param>
		/// <param name="propertyCode"></param>
		/// <returns></returns>
		public int DeleteComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass enuExtendClass,string itemCode, string propertyCode) 
		{
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.ComExtInfo.DeleteComExtInfo",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.DeleteComExtInfo字段!";
				return -1;
			}
			try 
			{  
				//如果是新增加的项目属性单，则直接返回
				strSQL=string.Format(strSQL, enuExtendClass,itemCode, propertyCode);    //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.DeleteComExtInfo:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 保存项目扩展属性数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="extendInfo"></param>
		/// <returns></returns>
		public int SetComExtInfo(Neusoft.HISFC.Models.Base.ExtendInfo extendInfo) 
		{
			int parm;
			//执行更新操作
			parm = UpdateComExtInfo(extendInfo);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0 ) 
			{
				parm = InsertComExtInfo(extendInfo);
			}
			return parm;
		}


		/// <summary>
		/// 取项目属性信息列表，可能是一条或者多条项目扩展属性
		/// 私有方法，在其他方法中调用
		/// writed by cuipeng
		/// 2005-1
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>项目属性信息对象数组</returns>
		private ArrayList myGetComExtInfo(string SQLString) 
		{
			ArrayList al=new ArrayList();                
			Neusoft.HISFC.Models.Base.ExtendInfo extendInfo; //项目属性信息实体
			this.ProgressBarText="正在检索项目属性单信息...";
			this.ProgressBarValue=0;
			
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) 
			{
				this.Err="获得项目属性信息时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try 
			{
				while (this.Reader.Read()) 
				{
					//取查询结果中的记录
					extendInfo = new Neusoft.HISFC.Models.Base.ExtendInfo();
                    //extendInfo.ExtendClass   = (Neusoft.HISFC.Models.Base.EnumExtendClass)this.Reader[0];          //0 项目编码
                    extendInfo.ExtendClass = (Neusoft.HISFC.Models.Base.EnumExtendClass)System.Enum.Parse(typeof(Neusoft.HISFC.Models.Base.EnumExtendClass), this.Reader[0].ToString());
					extendInfo.Item.ID   = this.Reader[1].ToString();          //0 项目编码
					extendInfo.PropertyCode   = this.Reader[2].ToString();     //2 属性编码
					extendInfo.PropertyName   = this.Reader[3].ToString();     //3 属性名称
					extendInfo.StringProperty = this.Reader[4].ToString();     //4 字符属性 
					extendInfo.NumberProperty = NConvert.ToDecimal(this.Reader[5].ToString()); //5 数值属性
					extendInfo.DateProperty   = NConvert.ToDateTime(this.Reader[6].ToString());//6 日期属性
					extendInfo.Memo      = this.Reader[7].ToString();          //7 备注
					extendInfo.OperEnvironment.ID  = this.Reader[8].ToString();          //8 操作日期
					extendInfo.OperEnvironment.Memo  = (this.Reader[9].ToString());     //9 操作时间
					this.ProgressBarValue++;
					al.Add(extendInfo);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得项目属性信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}


		/// <summary>
		/// 获得update或者insert项目属性表的传入参数数组
		/// </summary>
		/// <param name="extendInfo"></param>
		/// <returns></returns>
		private string[] myGetParmComExtInfo(Neusoft.HISFC.Models.Base.ExtendInfo extendInfo) 
		{

			string[] strParm={   extendInfo.ExtendClass.ToString(),
								 extendInfo.Item.ID,                  //0 项目编码
								 extendInfo.PropertyCode.ToString(),  //1 属性编码
								 extendInfo.PropertyName.ToString(),  //2 属性名称
								 extendInfo.StringProperty.ToString(),//3 字符属性 
								 extendInfo.NumberProperty.ToString(),//4 数值属性
								 extendInfo.DateProperty.ToString(),  //5 日期属性
								 extendInfo.Memo.ToString(),          //6 备注
								 this.Operator.ID,                       //7 操作员编码
			};								 
			return strParm;
		}
	}
}


namespace Neusoft.HISFC.Models.Base
{
	public enum EnumExtendClass
	{
		/// <summary>
		/// 科室扩展
		/// </summary>
		DEPT,
		/// <summary>
		/// 人员扩展
		/// </summary>
		PERSON,
		/// <summary>
		/// 患者扩展
		/// </summary>
		PATIENT
	}

	/// <summary>
	/// ComExtInfo<br></br>
	/// [功能描述: 扩展属性]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class ExtendInfo : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public ExtendInfo()
		{
		}


		#region 变量

		
		/// <summary>
		/// 扩展属性编码
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject item = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 属性编码
		/// </summary>
		private string propertyCode;

		/// <summary>
		/// 属性名称
		/// </summary>
		private string propertyName ;

		/// <summary>
		/// 字符属性
		/// </summary>
		private string stringProperty = "" ;

		/// <summary>
		/// 数值属性
		/// </summary>
		private decimal numberProperty = 0;

		/// <summary>
		/// 日期属性
		/// </summary>
		private System.DateTime dateProperty = DateTime.MinValue;

		/// <summary>
		/// 操作信息
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject operEnvironment = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 扩展属性
		/// </summary>
		private EnumExtendClass extendClass = new EnumExtendClass();
		#endregion

		#region 属性

		/// <summary>
		/// 扩展项目编码
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Item 
		{
			get
			{ 
				return this.item; 
			}
			set
			{
				this.item = value;
				this.ID = value.ID;
			}
		}

		/// <summary>
		/// 属性编码
		/// </summary>
		public string PropertyCode 
		{
			get
			{ 
				return this.propertyCode; 
			}
			set
			{ 
				this.propertyCode = value; 
			}
		}

		/// <summary>
		/// 属性名称
		/// </summary>
		public string PropertyName 
		{
			get
			{ 
				return this.propertyName; 
			}
			set
			{
				this.propertyName = value; 
			}
		}

		/// <summary>
		/// 字符属性
		/// </summary>
		public string StringProperty 
		{
			get
			{ 
				return this.stringProperty; 
			}
			set
			{
				this.stringProperty = value; 
				this.Name = value;
			}
		}

		/// <summary>
		/// 数值属性
		/// </summary>
		public System.Decimal NumberProperty 
		{
			get
			{ 
				return this.numberProperty; 
			}
			set
			{
				this.numberProperty = value; 
				this.Name = value.ToString();
			}
		}

		/// <summary>
		/// 日期属性
		/// </summary>
		public System.DateTime DateProperty 
		{
			get
			{ 
				return this.dateProperty; 
			}
			set
			{
				this.dateProperty = value; 
				this.Name = value.ToString();
			}
		}

		/// <summary>
		/// 操作环境
        /// ID 操作人编码，name 操作人名称,memo 操作时间
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject OperEnvironment
		{
			get
			{ 
				return this.operEnvironment;
			}
			set
			{ 
				this.operEnvironment = value; 
			}
		}


     

		/// <summary>
		/// 扩展类别
		/// </summary>
		public EnumExtendClass ExtendClass
		{
			get
			{
				return this.extendClass;
			}
			set
			{
				this.extendClass = value;
			}
		}
		#endregion

		#region 方法


		#region 克隆

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>ComExtInfo类实例</returns>
		public new ExtendInfo Clone()
		{
			ExtendInfo comExtInfo = base.Clone() as ExtendInfo;

			comExtInfo.Item = this.Item.Clone();
			comExtInfo.OperEnvironment = this.OperEnvironment.Clone();

			return comExtInfo;
		}

		#endregion

		#endregion
		

	}
}

