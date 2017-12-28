using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

//{DF8058FF-72C0-404f-8F36-6B4057B6F6CD}
namespace Neusoft.HISFC.Components.Order.Classes
{
    
    #region 剪贴板

    /// <summary>
    /// 剪贴板
    /// </summary>
    internal class Clipboard
    {
        #region 变量

        List<object> instanceCollection = new List<object>();

        /// <summary>
        /// 剪贴板
        /// </summary>
        IClipboard clipboard = null;

        #endregion

        #region 构造

        /// <summary>
        /// 默认采用xml剪贴板
        /// </summary>
        public Clipboard()
        {
            clipboard = new BinaryClipboard();
        }

        /// <summary>
        /// 构造类型为type的剪贴板
        /// </summary>
        /// <param name="type"></param>
        public Clipboard(EnumClipboard type)
        {
            ClipboardEnumService service = new ClipboardEnumService();
            string classFullName = service.GetName(type);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            clipboard = assembly.CreateInstance(classFullName) as IClipboard;
            //总有一个剪贴板
            if (clipboard == null)
            {
                clipboard = new XmlClipboard();
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 先向剪贴板中插入当前实例,并不直接执行copy
        /// 要copy，使用Copy();
        /// </summary>
        /// <param name="instance"></param>
        public void Add(object instance)
        {
            instanceCollection.Add(instance);
        }

        /// <summary>
        /// 清空剪贴板
        /// </summary>
        public void Clear()
        {
            instanceCollection.Clear();
        }

        /// <summary>
        /// 复制
        /// </summary>
        public bool Copy()
        {
            bool result = clipboard.Copy(instanceCollection);
            instanceCollection.Clear();
            return result; ;
        }

        /// <summary>
        /// 粘贴
        /// 粘贴内容被组装在List-object泛型列表中
        /// </summary>
        /// <returns>返回粘贴内容</returns>
        public object Paste()
        {
            return clipboard.Paste(instanceCollection.GetType());
        }

        #endregion
    }

    #endregion

    #region 枚举和枚举服务类

    /// <summary>
    /// 剪贴类型枚举
    /// </summary>
    enum EnumClipboard
    {
        Xml,
        Binary
    }

    /// <summary>
    /// 剪贴枚举服务类
    /// </summary>
    class ClipboardEnumService : EnumServiceBase
    {
        static System.Collections.Hashtable hashtable = new System.Collections.Hashtable();

        static ClipboardEnumService()
        {
            hashtable[EnumClipboard.Xml] = "Neusoft.HISFC.Components.Order.Classes.XmlClipboard";
            hashtable[EnumClipboard.Binary] = "Neusoft.HISFC.Components.Order.Classes.BinaryClipboard";
        }

        EnumClipboard myEnum;

        protected override Enum EnumItem
        {
            get
            {
                return myEnum;
            }
        }

        protected override System.Collections.Hashtable Items
        {
            get
            {
                return hashtable;
            }
        }
    }

    #endregion

    #region 剪贴板

    /// <summary>
    /// 剪贴接口，一次只剪贴一个实体
    /// </summary>
    interface IClipboard
    {
        object Paste(Type type);
        bool Copy(object parameter);
    }

    /// <summary>
    /// xml剪贴板
    /// </summary>
    class XmlClipboard : IClipboard
    {
        const string file = "clipboard.xml";

        public object Paste(Type type)
        {
            System.IO.Stream stream = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
                object instance = serializer.Deserialize(stream);
                stream.Flush();
                stream.Close();
                return instance;
            }
            catch
            {
                return null;
            }
            finally
            {
                stream.Close();
            }
        }

        public bool Copy(object parameter)
        {
            System.IO.Stream stream = new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(parameter.GetType());
                serializer.Serialize(stream, parameter);
                stream.Flush();
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                stream.Close();
            }
        }
    }

    /// <summary>
    /// 二进制剪贴板
    /// </summary>
    class BinaryClipboard : IClipboard
    {
        const string file = "clipboard.dat";

        public object Paste(Type type)
        {
            if (System.IO.File.Exists( file ) == false)
            {
                return null;
            }
            System.IO.Stream stream = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                object instance = formater.Deserialize(stream);
                stream.Flush();
                stream.Close();
                return instance;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                stream.Close();
            }
        }

        public bool Copy(object parameter)
        {
            System.IO.Stream stream = new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formater.Serialize(stream, parameter);
                stream.Flush();
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                stream.Close();
            }
        }
    }

    #endregion

    #region 历史医嘱查询粘贴类

    /// <summary>
    /// 历史医嘱查询粘贴类
    /// </summary>
    public class HistoryOrderClipboard
    {
        static List<string> data = new List<string>();
        static bool isReaded = false;

        private static void GetContent()
        {
            data.Clear();
            List<object> objdata = clipboard.Paste() as List<object>;
            if ((objdata != null) && (objdata.Count > 0))
            {
                for (int count = 0; count < objdata.Count; count++)
                {
                    data.Add(objdata[count].ToString());
                }
            }
            isReaded = true;
        }

        /// <summary>
        /// 从剪贴板获的医嘱ID列表
        /// </summary>
        public static List<string> OrderList
        {
            get
            {
                if (!isReaded)
                {
                    GetContent();
                }
                if (data.Count <= 0)
                {
                    return null;
                }
                string[] array = new string[data.Count - 1];
                data.CopyTo(0, array, 0, array.Length);
                data.CopyTo(0, array, 0, array.Length);
                List<string> list = new List<string>(array);
                type = (ServiceTypes)Convert.ToInt32(data[data.Count - 1]);
                data.Clear();
                return list;
            }
        }

        private static Neusoft.HISFC.Models.Base.ServiceTypes type = ServiceTypes.I;

        /// <summary>
        /// 标识门诊还是住院
        /// </summary>
        public static Neusoft.HISFC.Models.Base.ServiceTypes Type
        {
            get { return type; }
        }


        static Clipboard clipboard = new Clipboard();

        /// <summary>
        /// 执行添加，不复制
        /// </summary>
        /// <param name="instance"></param>
        public static void Add(object instance)
        {
            clipboard.Add(instance);
        }

        /// <summary>
        /// 执行复制
        /// </summary>
        public static void Copy()
        {
            clipboard.Copy();
            isReaded = false;
        }
    }

    #endregion
}