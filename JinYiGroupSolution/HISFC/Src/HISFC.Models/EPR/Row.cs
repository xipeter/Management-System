using System;
using System.Collections.Generic;
using System.Text;
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
    public class Row : Neusoft.FrameWork.Models.NeuObject, System.IComparable
    {
        private string text;

        [Description("文本"), Category("设计")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string rtf;

        [Description("行超文本"), Category("设计")]
        public string Rtf
        {
            get { return rtf; }
            set { rtf = value; }
        }

        private System.Drawing.Bitmap bmp;

        [Description("行图像"), Category("设计")]
        public System.Drawing.Bitmap BmpLine
        {
            get { return bmp; }
            set { bmp = value; }
        }

        private int rowCount;

        /// <summary>
        /// 行数量
        /// 考虑到图片和自定义图像占用多行的问题，加入这个属性
        /// </summary>
        [Description("行数量"), Category("设计")]
        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value; }
        }

        private DateTime dateInput;

        /// <summary>
        /// 输入日期
        /// 排序
        /// </summary>
        [Description("行数量"), Category("设计")]
        public DateTime DateInput
        {
            get { return dateInput; }
            set { dateInput = value; }
        }

        private int index;

        /// <summary>
        /// 输入日期内的索引
        /// 排序
        /// </summary>
        [Description("输入日期内的索引"), Category("设计")]
        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        #region IComparable 成员

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Neusoft.HISFC.Models.EPR.Row ctr = (Neusoft.HISFC.Models.EPR.Row)obj;
            if (this == null)
            {
                return -1;
            }
            else if (this.DateInput < ctr.DateInput)
            {
                return -1;
            }
            else if (this.DateInput < ctr.DateInput)
            {
                return 1;
            }
            else
            {
                if (this.index < ctr.index)
                {
                    return -1;
                }
                else if (this.index > ctr.index)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion
    }
}
