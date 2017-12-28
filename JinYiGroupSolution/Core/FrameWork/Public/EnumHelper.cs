using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;

namespace Neusoft.FrameWork.Public
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public class EnumHelper
    {
        #region 变量

        /// <summary>
        /// 线程粒度锁实体
        /// </summary>
        private static object myLock = new object();

        /// <summary>
        /// 帮助枚举实体
        /// </summary>
        private static EnumHelper enumHelp = null;

        /// <summary>
        /// 语言
        /// </summary>
        private string language = string.Empty;

        /// <summary>
        /// 枚举信息存储器
        /// </summary>
        private Dictionary<string, IList<EnumObject>> dicEnum = null;

        #endregion

        #region 构造

        /// <summary>
        /// 构造并初始化帮助枚举实体
        /// </summary>
        private EnumHelper()
        {
            dicEnum = new Dictionary<string, IList<EnumObject>>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 当前枚举帮助(全局)
        /// </summary>
        public static EnumHelper Current
        {
            get
            {
                if (enumHelp == null)
                {
                    lock (myLock)
                    {
                        enumHelp = new EnumHelper();
                    }
                }
                return enumHelp;
            }
        }

        /// <summary>
        /// 语言信息
        /// </summary>
        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 清除缓存
        /// </summary>
        public void Clear()
        {
            dicEnum.Clear();
        }

        /// <summary>
        /// 将枚举和对应的Desciption存放到当前帮助枚举中
        /// </summary>
        /// <param name="enumType">帮助枚举Type</param>
        /// <param name="listEnum">Description集合</param>
        public void Add(string enumType, IList<EnumObject> listEnum)
        {
            lock (myLock)
            {
                Remove(enumType);
                dicEnum.Add(enumType, listEnum);
            }
        }

        /// <summary>
        /// 添加枚举
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        public void Add<T>()
        {
            this.add(typeof(T));

            #region 被注释，用新的替换
            //string enumType = typeof(T).FullName;
            //if (dicEnum.ContainsKey(enumType)) return;
            //lock (myLock)
            //{
            //    List<EnumObject> list = GetDescription(typeof(T));
            //    this.Add(enumType, list);
            //}
            #endregion
        }

        /// <summary>
        /// 为枚举帮助集合中对应的枚举类型enumType添加新的Description
        /// </summary>
        /// <param name="enumType">枚举类型enumType</param>
        /// <param name="item">添加项</param>
        public void Add(string enumType, EnumObject item)
        {
            lock (myLock)
            {
                IList<EnumObject> list = null;
                if (dicEnum.ContainsKey(enumType))
                {
                    list = new List<EnumObject>();
                    dicEnum.Add(enumType, list);
                }
                else
                {
                    list = dicEnum[enumType];
                }
                list.Add(item);
            }
        }

        /// <summary>
        /// 移除类型为enumType的枚举
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        public void Remove(string enumType)
        {
            lock (myLock)
            {
                if (dicEnum.ContainsKey(enumType))
                {
                    dicEnum.Remove(enumType);
                }
            }
        }
        /// <summary>
        /// 将枚举信息按列表的方式返回(Name是按语言信息转换过的)
        /// </summary>
        /// <returns>枚举信息列表</returns>
        public IList<EnumObject> EnumList<T>()
        {
            string strType = typeof(T).FullName;
            testEnum<T>();
            return dicEnum[strType];
        }

        /// <summary>
        /// 通过枚举值value和类型T得到该枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">枚举</param>
        /// <returns>目标枚举</returns>
        public T GetEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// 通过整数值和枚举类型T得到该枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">值</param>
        /// <returns>目标枚举</returns>
        public T GetEnum<T>(int value)
        {
            return GetEnum<T>(value.ToString());
        }

        /// <summary>
        /// 通过枚举<paramref name="enumObj"/>得到该枚举的Description
        /// 如果该枚举没有对应的Description，则将返回该枚举的ToString()值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        [Obsolete("此方法已经被重构，请使用新方法GetName")]
        public string GetEnumName<T>(T enumObj)
        {
            EnumObject obj = this.GetEnum<T>(enumObj);
            if (obj != null) return obj.GetNameByLanguage(this.language);
            return enumObj.ToString();
        }

        /// <summary>
        /// 通过枚举<paramref name="enumObj"/>得到该枚举的Description
        /// 如果该枚举没有对应的Description，则将返回该枚举的ToString()值
        /// </summary>
        /// <param name="enumObj">枚举</param>
        /// <returns>对应的Description</returns>
        public string GetName(Enum enumObj)
        {
            EnumObject obj = null;
            Type t = enumObj.GetType();
            testEnum(t);

            string strType = t.FullName;
            IList<EnumObject> list = dicEnum[strType];
            string testString = enumObj.ToString();
            foreach (EnumObject item in list)
            {
                if (item.ID == testString)
                {
                    obj = item;
                }
            }
            if (obj == null)
            {
                //throw new NeuException(string.Format( "所指定的类型值不存在[0]...",enumObj.ToString()))
                return testString;
            }
            return obj.GetNameByLanguage(this.language);

        }

        /// <summary>
        /// 通过枚举<paramref name="enumObj"/>得到该枚举的枚举信息实体
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumObj">枚举</param>
        /// <returns>枚举信息实体</returns>
        public EnumObject GetEnum<T>(T enumObj)
        {
            string strType = typeof(T).FullName;
            testEnum<T>();
            IList<EnumObject> list = dicEnum[strType];
            string testValue = enumObj.ToString();
            foreach (EnumObject item in list)
            {
                if (item.ID == testValue)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 返回某各枚举类型的所有成员“描述信息”
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumObject> GetDescription(Type enumType)
        {

            if (!enumType.IsEnum) return null;
            List<EnumObject> list = new List<EnumObject>();
            EnumObject enumObj;
            System.Reflection.FieldInfo[] fieldInfos = enumType.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                DescriptionAttribute[] atts = (DescriptionAttribute[])fieldInfos[i].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (atts.Length > 0)
                {
                    enumObj = new EnumObject();
                    enumObj.ID = fieldInfos[i].Name;
                    enumObj.Name = atts[0].Description;
                    list.Add(enumObj);
                }
            }
            return list.Count > 0 ? list : null;
        }

        /// <summary>
        /// 返回某各Assembly下所有枚举类型的"描述信息"列表
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Dictionary<string, List<EnumObject>> GetDescription(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            if (types.Length == 0) return null;

            Dictionary<string, List<EnumObject>> list = new Dictionary<string, List<EnumObject>>();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsEnum)
                {
                    List<EnumObject> enumObjects = GetDescription(types[i]);
                    if (enumObjects != null) list.Add(types[i].FullName, enumObjects);
                }
            }

            return list.Count == 0 ? null : list;
        }

        /// <summary>
        /// 返回dll文件下所有枚举类型的"描述信息"列表
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Dictionary<string, List<EnumObject>> GetDescriptionFormAssembly(string fileName)
        {
            Assembly assembly = Assembly.LoadFile(fileName);
            if (assembly != null)
                return GetDescription(assembly);
            else
                return null;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 将类型为t的枚举添加到当前帮助枚举中
        /// </summary>
        /// <param name="t">枚举类型</param>
        private void add(Type t)
        {
            string enumType = t.FullName;
            if (dicEnum.ContainsKey(enumType)) return;
            lock (myLock)
            {
                List<EnumObject> list = GetDescription(t);
                this.Add(enumType, list);
            }
        }

        /// <summary>
        /// 检测t是否是枚举和是否存在
        /// </summary>
        /// <param name="t"></param>
        private void testEnum(Type t)
        {
            if (!t.IsEnum)
            {
                throw new Exception("所指定的类型不是Enum.");
            }
            string enumType = t.FullName;
            if (!dicEnum.ContainsKey(enumType))
            {
                this.add(t);
            }
        }

        /// <summary>
        /// 检测并添加该枚举T到帮助枚举中 
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        private void testEnum<T>()
        {
            string enumType = typeof(T).FullName;
            if (!dicEnum.ContainsKey(enumType))
            {
                //string tmp = string.Format("枚举[{0}],资源不存在！", enumType);
                //throw new NeuException(tmp);
                //如果资源中不存在，则系统直接将通过反射获取到，并加载于内存之中

                this.Add<T>();
            }
        }

        #endregion

        #region nested class 内嵌类 帮住枚举实体，用来存储枚举的信息
        /// <summary>
        /// 帮住枚举实体，用来存储枚举的信息
        /// </summary>
        public class EnumObject : Neusoft.FrameWork.Models.NeuObject
        {
            #region 变量

            /// <summary>
            /// 语言?
            /// </summary>
            private string language;

            #endregion

            #region 属性

            /// <summary>
            /// 获取或设置语言?
            /// </summary>
            public string Language
            {
                get
                {
                    if (string.IsNullOrEmpty(language)) return Name;
                    return language;
                }
                set { language = value; }
            }

            #endregion

            #region 公开方法

            /// <summary>
            /// 根据语言获取name?
            /// </summary>
            /// <param name="language"></param>
            /// <returns></returns>
            public virtual string GetNameByLanguage(string language)
            {
                return Name;
            }

            #endregion
        }

        #endregion

    } //end class 
} //namespace
