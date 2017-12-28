using System;

namespace Neusoft.HISFC.Models.File
{
    /// <summary>
    /// DataFileInfo 的摘要说明。
    /// ID 文件编号
    /// Name 说明名称
    /// </summary>
    [System.Serializable]
    public class DataFileInfo : Neusoft.FrameWork.Models.NeuObject
    {

        public DataFileInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public new string ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
                this.Param.FileName = value + ".xml";
            }
        }
        /// <summary>
        /// 参数
        /// </summary>
        public Neusoft.HISFC.Models.File.DataFileParam Param = new DataFileParam();
        /// <summary>
        /// 文件结构-住院病历,病程记录等
        /// </summary>
        public string DataType;
        /// <summary>
        /// 文件类型
        /// </summary>
        public string Type;
        /// <summary>
        /// 完整文件名
        /// </summary>
        public string FullFileName
        {
            get
            {
                string s;
                s = this.Param.Http + this.Param.Folders + "/" + this.Param.FileName;
                return s;
            }
        }
        /// <summary>
        /// 索引1
        /// </summary>
        public string Index1;
        /// <summary>
        /// 索引2
        /// </summary>
        public string Index2;
        /// <summary>
        /// 标识
        /// 是否可用 0 可用 1 不可用
        /// </summary>
        public int valid = 0;
        /// <summary>
        /// 数据
        /// </summary>
        public string Data;

        private int useType = 0;

        /// <summary>
        /// 使用人员 0 医生使用 1 护士使用
        /// </summary>
        public int UseType
        {
            get { return useType; }
            set { useType = value; }
        }

        private int count = 0;

        /// <summary>
        /// 使用记数
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new DataFileInfo Clone()
        {
            DataFileInfo obj = new DataFileInfo();
            obj = base.Clone() as DataFileInfo;
            obj.Param = this.Param.Clone();
            return obj;
        }
    }
}
