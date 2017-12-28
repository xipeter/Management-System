using System;
using System.Collections;
using System.Collections.Generic;
namespace Neusoft.FrameWork.Models
{
    /// <summary>
    /// NeuObject <br></br>
    /// [功能描述: NeuObject基础对象，所有对象都继承与此]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class NeuObject : IDisposable//:System.ICloneable
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public NeuObject()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			strID="";
			strName="";
			strMemo="";
		}

        public NeuObject(string id, string name, string memo)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            strID = id;
            strName = name;
            strMemo = memo;
        }

		//finalizer
        //~NeuObject()
        //{
        //    Dispose( false );
        //}

        #region 变量
        /// <summary>
		/// 局部变量
		/// </summary>
		private string strID;
		private string strName;
		private string strMemo;
		
        [Obsolete("作废，5.0不再使用",false)]
		public string User01 = string.Empty;
        [Obsolete("作废，5.0不再使用", false)]
        public string User02 = string.Empty;
        [Obsolete("作废，5.0不再使用", false)]
        public string User03 = string.Empty;

		private bool alreadyDisposed = false;
        #endregion

        #region 属性
        /// <summary>
		/// ID
		/// </summary>
		public virtual string ID
		{
			get
			{
				return strID + "";
			}
			set
			{
				strID=value;
			}
		}
		/// <summary>
		/// 属性Name
		/// </summary>
		/// <returns>Name</returns>
		public virtual string Name
		{
			get
			{
				return strName + "";
			}
			set
			{
				strName=value;
			}
		}
		/// <summary>
		/// 属性Memo
		/// </summary>
		/// <returns>Memo</returns>
		public virtual string Memo
		{	
			get
			{
				return strMemo + "";
			}
			set
			{
				strMemo=value;
			}
        }

        #endregion

        #region LIST属性
        //private Dictionary<string, object> propertyCollection;

        ///// <summary>
        ///// 【属性-属性值】集合
        ///// </summary>
        //public Dictionary<string, object> PropertyCollection
        //{
        //    get
        //    {
        //        if (propertyCollection == null)
        //        {
        //            propertyCollection = new Dictionary<string, object>();
        //        }
        //        return propertyCollection;
        //    }

        //    set
        //    {
        //        propertyCollection = value;
        //    }
        //}

        ///// <summary>
        ///// 获取属性的值
        ///// </summary>
        ///// <param name="property"></param>
        ///// <returns></returns>
        //public object GetProperty(string property)
        //{
        //    object propertyValue = null;
        //    if (PropertyCollection.ContainsKey(property))
        //        propertyValue = PropertyCollection[property];
        //    return propertyValue;
        //}

        ///// <summary>
        ///// 添加【属性-属性值】
        ///// </summary>
        ///// <param name="property">属性</param>
        ///// <param name="value">属性值</param>
        ///// <param name="isOverride">如果已存在该属性，是否覆盖该属性。true为覆盖;false为不覆盖，但是会抛出异常</param>
        //public void SetProperty(string property, object value, bool isOverride)
        //{
        //    if (PropertyCollection.ContainsKey(property))
        //    {
        //        if (isOverride)
        //        {
        //            PropertyCollection.Remove(property);
        //        }
        //    }

        //    PropertyCollection.Add(property, value);
        //}

        ///// <summary>
        ///// 添加【属性-属性值】对于已经存在的属性，默认覆盖该属性值
        ///// value:走三层，需要在服务契约接口上静态添加ServiceKnowType(typeof(value-type))属性
        ///// </summary>
        ///// <param name="property">属性</param>
        ///// <param name="value">属性值</param>
        //public void SetProperty(string property, object value)
        //{
        //    SetProperty(property, value, true);
        //}

        ///// <summary>
        ///// 该属性是否存在
        ///// </summary>
        ///// <param name="property">属性</param>
        ///// <returns>存在为true，否则false</returns>
        //public bool IsContainsProperty(string property)
        //{
        //    return PropertyCollection.ContainsKey(property);
        //}
        #endregion
        #region 方法
        /// <summary>
		/// 重载ToString
		/// </summary>
		/// <returns>Name</returns>
		public override string ToString()
		{
			return this.Name;
        }
        #endregion


        #region ICloneable 成员

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public NeuObject Clone()
		{
			return  this.MemberwiseClone() as FrameWork.Models.NeuObject;
		}
		#endregion

        protected virtual void Dispose(bool isDisposing)
        {
            if (alreadyDisposed)
                return;
            if (isDisposing)
            {
                // TODO: free managed resources here
            }
            //TODO: free unmanaged resources here
            alreadyDisposed = true;
        }


        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(true);
        }

        #endregion
	}
}
