using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.UFC.Privilege.Forms
{
    /// <summary>
    /// [功能描述: ToolBarButton管理类]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    internal class ToolBarButtonService 
    {
        /// <summary>
        /// 默认２４
        /// </summary>
        protected static int ImageSize = 24;

        /// <summary>
        /// 0 下，１　右...
        /// </summary>
        protected static int TextPosition = 0;

        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="toolbar"></param>
        public static void ClearButton(ToolStrip toolbar)
        {
            for (int i = toolbar.Items.Count - 1; i >= 0; i--)
            {
                ToolStripItem tb = toolbar.Items[i];
                if (tb.Tag != null && tb.Tag.ToString() == "Default")
                {
                }
                else
                {
                    toolbar.Items.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// 设置按钮属性
        /// </summary>
        /// <param name="imageSize"></param>
        /// <param name="textPosition"></param>
        public static void SetButtonProperty(int imageSize, int textPosition)
        {
            ImageSize = imageSize;
            TextPosition = textPosition;
        }

        /// <summary>
        /// 设置按钮属性
        /// </summary>
        /// <param name="tb"></param>
        public static void SetButtonProperty(ToolStripItem tb)
        {
            tb.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tb.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            switch (TextPosition)
            {
                case 0:
                    tb.TextImageRelation = TextImageRelation.ImageAboveText;
                    break;
                case 1:
                    tb.TextImageRelation = TextImageRelation.ImageBeforeText;
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    tb.TextImageRelation = TextImageRelation.ImageAboveText;
                    break;
            }
        }


        /// <summary>
        /// 设置ToolBar
        /// </summary>
        /// <param name="tb1"></param>
        /// <param name="tb2"></param>
        /// <param name="al1"></param>
        /// <param name="al2"></param>
        public static void ChangeButton(ToolStrip tb1, ToolStrip tb2, ArrayList al1, ArrayList al2)
        {
            if (al1.Count == 0 && al2.Count == 0)
            {
                return;
            }

            tb1.SuspendLayout();
            tb2.SuspendLayout();

            ArrayList tbAll = new ArrayList();
            foreach (ToolStripItem tb in tb1.Items)
            {
                tbAll.Add(tb);
            }
            foreach (ToolStripItem tb in tb2.Items)
            {
                tbAll.Add(tb);
            }

            tb1.Items.Clear();
            tb2.Items.Clear();

            foreach (string text in al1)
            {
                if (text.Trim() == "-")
                {
                    ToolStripSeparator tb = new ToolStripSeparator();
                    tb1.Items.Add(tb);
                }
                else
                {
                    foreach (ToolStripItem tb in tbAll)
                    {
                        if (tb.Text.Trim() == text.Trim())
                        {
                            SetButtonProperty(tb);
                            tb1.Items.Add(tb);
                            break;
                        }
                    }
                }
            }

            foreach (string text in al2)
            {
                if (text.Trim() == "-")
                {
                    ToolStripSeparator tb = new ToolStripSeparator();
                    tb2.Items.Add(tb);
                }
                else
                {
                    foreach (ToolStripItem tb in tbAll)
                    {
                        if (tb.Text.Trim() == text.Trim())
                        {
                            SetButtonProperty(tb);
                            tb2.Items.Add(tb);
                            break;
                        }
                    }
                }
            }
            tb1.ResumeLayout(true);
            tb2.ResumeLayout(true);
        }
    }
}
