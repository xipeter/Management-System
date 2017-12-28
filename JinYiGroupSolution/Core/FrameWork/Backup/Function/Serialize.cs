using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Neusoft.FrameWork.Function
{
    /// <summary>
    /// 
    /// </summary>
    public class Serialize
    {
        private static IFormatter formatter = new BinaryFormatter();

        /// <summary>
        /// 序列化 同时完成压缩
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialization(object obj)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();

            formatter.Serialize(stream, obj);

            stream.Position = 0;
            byte[] bb = stream.GetBuffer();

            return Neusoft.FrameWork.Public.CompressionHelper.CompressBytes(bb);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static object DeSerialization(byte[] s)
        {
            byte[] ss = Neusoft.FrameWork.Public.CompressionHelper.DecompressBytes(s);

            System.IO.Stream stream = new System.IO.MemoryStream(ss);

            return formatter.Deserialize(stream);

        }
    }
}
