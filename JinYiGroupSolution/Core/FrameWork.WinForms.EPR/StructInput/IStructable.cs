using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Neusoft.FrameWork.EPRControl.StructInput
{
    /// <summary>
    /// 结构化录入接口
    /// </summary>
    public interface IStructable
    {
        /// <summary>
        /// 查找类型
        /// </summary>
        enumSearchType SearchType
        {
            get;
            set;
        }

        /// <summary>
        /// 查找类别表

        /// </summary>
        string SearchTable
        {
            get;
            set;
        }

        /// <summary>
        /// 是否精确查询
        /// </summary>
        bool IsExactSearch
        {
            get;
            set;
        }

        /// <summary>
        /// 关键字结束索引

        /// </summary>
        int SelectionIndex
        {
            get;
        }

        /// <summary>
        /// 关键字开始索引

        /// </summary>
        int KeyWordIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 关键字

        /// </summary>
        string SelectText
        {
            get;
            set;
        }

        /// <summary>
        /// 获得关键字坐标

        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Point GetPositionFromIndex(int index);

        /// <summary>
        /// 选中关键字

        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        void SelectKeyWord(int start, int length);
    }
}
