using System;
using System.Collections;
using System.ComponentModel;
namespace Neusoft.HISFC.Models.EPR
{
    /// <summary>
    /// ucNurseSheetSettingColumn<br></br>
    /// [功能描述: 护理记录设置输入列类]<br></br>
    /// [创 建 者: 刘志存]<br></br>
    /// [创建时间: 2007-11-05]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
	public class NurseSheetSettingColumn
	{
        //private string id;

        //[Description("列编码，最大长度10位"), Category("设计"), Obsolete("没有什么意义")]
        //public string ID
        //{
        //    get { return id; }
        //    set { id = value; }
        //}

        private string caption;

        [Description("列标题，最大长度10位"), Category("设计")]
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        private int wordCount;

        [Obsolete("废弃，不需要设置字符数量", true), Description("字符的数量，汉字占两位"), Category("设计")]
        public int WordCount
        {
            get { return wordCount; }
            set { wordCount = value; }
        }

        private int width;

        [Description("宽度"), Category("设计")]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int left;

        [Description("左边距"), Category("设计")]
        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        private ColumnStyle style;

        [Description("列类型：下拉框、文本框、时间"), Category("设计")]
        public ColumnStyle Style
        {
            get { return style; }
            set { style = value; }
        }

        private string[] items;

        [Description("下拉选项数组"), Category("设计")]
        public string[] Items
        {
            get { return items; }
            set { items = value; }
        }

        private bool isDescription = false;

        [Description("是否病情描述"), Category("设计"), DefaultValue(false)]
        public bool IsDescription
        {
            get { return isDescription; }
            set { isDescription = value; }
        }

        private bool isUseHelp = false;

        [Description("是否显示帮助"), DefaultValue(false), Category("设计")]
        public bool IsUseHelp
        {
            get { return isUseHelp; }
            set { isUseHelp = value; }
        }

        private string[] help;

        [Description("帮助信息"), Category("设计")]
        public string[] Help
        {
            get { return help; }
            set { help = value; }
        }

    }
    public enum ColumnStyle
    {
        文本框,
        下拉框,
        多行文本框,
        日期
    }
}
