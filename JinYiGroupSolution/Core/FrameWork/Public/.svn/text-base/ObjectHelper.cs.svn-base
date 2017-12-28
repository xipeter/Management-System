using System;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.FrameWork.Public
{/// <summary>
    /// ObjectHelper<br></br>
    /// [功能描述: ObjectHelper类根据名字可以得到ID,根据ID可以得到NAME]<br></br>
    /// [创 建 者: 崔鹏]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public class ObjectHelper
    {
         
        /// <summary>
		/// 构造函数
		/// </summary>
		public ObjectHelper()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 重载构造函数，给al赋初值
		/// </summary>
		/// <param name="arrayObject"></param>
		public ObjectHelper(ArrayList arrayObject) 
        {
            if (arrayObject != null)
            {
             
                al = arrayObject;
            }
        }

        #region 变量

        //保存传入的对象列表
        private ArrayList al = new ArrayList();
        #endregion

        #region 属性

        /// <summary>
        /// 对象数组属性
        /// </summary>
        public ArrayList ArrayObject
        {
            get 
            { 
                return this.al; 
            }
            set
            {
                if (value != null) this.al = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
		/// 根据传入的Name，找到对应的ID
		/// </summary>
		/// <param name="name">Name属性</param>
		/// <returns>ID属性。如果没有找到ID，则返回null</returns>
		public string GetID(string name) 
        {
			for(int i=0;i<al.Count;i++)
            {
				NeuObject obj = al[i] as NeuObject;
                if (obj == null)
                {
                    return "";
                }
                if (obj.Name == name)
                {
                    return obj.ID;
                }
			}
			
            //如果没有找到ID，则返回null
			return null;
		}
		

		/// <summary>
		/// 根据传入的ID，找到对应的Name
		/// </summary>
		/// <param name="ID">ID属性</param>
		/// <returns>Name属性。如果没有找到ID，则返回null</returns>
		public string GetName(string ID) 
        {
			for(int i=0;i<al.Count;i++)
			{
				NeuObject obj = al[i] as NeuObject;
                if (obj == null)
                {
                    return "";
                }
                if (obj.ID == ID)
                {
                    return obj.Name;
                }
			}
			
            //如果没有找到ID，则返回null
			return null;
		}

        /// <summary>
		/// 根据传入的ID，找到对应的Object
		/// </summary>
		/// <param name="ID">ID属性</param>
		/// <returns>Object。如果没有找到Object，则返回null</returns>
		public Neusoft.FrameWork.Models.NeuObject GetObjectFromID(string ID) 
        {
			for(int i=0;i<al.Count;i++)
			{
				NeuObject obj = al[i] as NeuObject;
                if (obj == null)
                {
                    return null;
                }
                if (obj.ID == ID)
                {
                    return obj;
                }
			}

			//如果没有找到Object，则返回null
			return null;
		}

        /// <summary>
		/// 根据传入的Name，找到对应的Object
		/// </summary>
		/// <param name="name">Name属性</param>
		/// <returns>Object。如果没有找到Object，则返回null</returns>
		public Neusoft.FrameWork.Models.NeuObject GetObjectFromName(string name) 
		{
			for(int i=0;i<al.Count;i++)
			{
				NeuObject obj = al[i] as NeuObject;
                if (obj == null)
                {
                    return null;
                }
                if (obj.Name == name)
                {
                    return obj;
                }
			}

			//如果没有找到Object，则返回null
			return null;
        }
        #endregion

    }
}
