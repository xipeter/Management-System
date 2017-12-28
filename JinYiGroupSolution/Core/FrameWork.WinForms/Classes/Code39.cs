using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Drawing.Text;
using System.Drawing.Imaging;

namespace Neusoft.FrameWork.WinForms.Classes
{
    //{F0445AB0-DF1A-4007-9454-F4822DE85CBE}
    /// <summary>
    /// 画条码 luzhp 2007-9-8
    /// </summary>
    public class Code39
    {
        private const int itemSepHeight = 3;
        //标题size
        SizeF titleSize = SizeF.Empty;
        //条码size
        SizeF barCodeSize = SizeF.Empty;
        //条码字符串size
        SizeF codeStringSize = SizeF.Empty;

        #region 标题

        private string titleString = null;
        private Font titleFont = null;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return titleString; }
            set { titleString = value; }
        }
        /// <summary>
        /// 标题字体
        /// </summary>
        public Font TitleFont
        {
            get { return titleFont; }
            set { titleFont = value; }
        }
        #endregion

        #region 条码字符串

        private bool showCodeString = false;
        private Font codeStringFont = null;
        /// <summary>
        /// 是否显示条码字符串
        /// </summary>
        public bool ShowCodeString
        {
            get { return showCodeString; }
            set { showCodeString = value; }
        }

        /// <summary>
        /// 画条码字符串字体
        /// </summary>
        public Font CodeStringFont
        {
            get { return codeStringFont; }
            set { codeStringFont = value; }
        }
        #endregion

        #region 条码字体

        private Font c39Font = null;
        private float c39FontSize = 24;
        /// <summary>
        /// 条形码字体size
        /// </summary>
        public float FontSize
        {
            get { return c39FontSize; }
            set { c39FontSize = value; }
        }

        /// <summary>
        /// 得到条形码字体
        /// </summary>
        private Font Code39Font
        {
            get
            {
                if (c39Font == null)
                {
                    PrivateFontCollection pfc = new PrivateFontCollection();

                    byte[] fontdata = global ::Neusoft.FrameWork.WinForms.Properties.Resources.FREE3OF9;
                    unsafe
                    {

                        fixed (byte* pFontData = fontdata)
                        {

                            pfc.AddMemoryFont((System.IntPtr)pFontData, fontdata.Length);

                        }

                    }
                    foreach (FontFamily ff in pfc.Families)
                    {
                        if (ff.IsStyleAvailable(FontStyle.Regular))
                        {
                            c39Font = new Font(ff, c39FontSize);
                            break;
                        }
                    }
                }
                return c39Font;
            }
        }

        #endregion

        public Code39()
        {
            if (titleFont == null)
            {
                titleFont = new Font("Arial", 8);
            }

            if (codeStringFont == null)
            {
                codeStringFont = new Font("Arial", 8);
            }
        }

        #region 画条形码

        /// <summary>
        /// 画条形码
        /// </summary>
        /// <param name="barCode">条形码字符串</param>
        /// <returns></returns>
        public Bitmap GenerateBarcode(string barCode)
        {

            int bcodeWidth = 0;
            int bcodeHeight = 0;

            // 得到空白图片
            Bitmap bcodeBitmap = CreateImageContainer(barCode, ref bcodeWidth, ref bcodeHeight);
            Graphics objGraphics = Graphics.FromImage(bcodeBitmap);

            // 填充背景颜色
            objGraphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, bcodeWidth, bcodeHeight));

            int vpos = 0;

            // 画标题
            if (titleString != null)
            {
                objGraphics.DrawString(titleString, titleFont, new SolidBrush(Color.Black), XCentered((int)titleSize.Width, bcodeWidth), vpos);
                vpos += (((int)titleSize.Height) + itemSepHeight);
            }
            // 画条码
            objGraphics.DrawString(barCode, Code39Font, new SolidBrush(Color.Black), XCentered((int)barCodeSize.Width, bcodeWidth), vpos);

            // 画条码字符串
            if (showCodeString)
            {
                vpos += (((int)barCodeSize.Height));
                objGraphics.DrawString(barCode, codeStringFont, new SolidBrush(Color.Black), XCentered((int)codeStringSize.Width, bcodeWidth), vpos);
            }

            //返回条码图片									
            return bcodeBitmap;
        }

        /// <summary>
        /// 建立指定大小的空白图片
        /// </summary>
        /// <param name="barCode">条码字符串</param>
        /// <param name="bcodeWidth">宽度</param>
        /// <param name="bcodeHeight">高度</param>
        /// <returns></returns>
        private Bitmap CreateImageContainer(string barCode, ref int bcodeWidth, ref int bcodeHeight)
        {

            Graphics objGraphics;
            //建立临时图片
            Bitmap tmpBitmap = new Bitmap(1, 1, PixelFormat.Format64bppPArgb);
            objGraphics = Graphics.FromImage(tmpBitmap);

            // 计算标题size
            if (!string.IsNullOrEmpty(titleString))
            {
                titleSize = objGraphics.MeasureString(titleString, titleFont);
                bcodeWidth = (int)titleSize.Width;
                bcodeHeight = (int)titleSize.Height + itemSepHeight;
            }
            //计算条码size
            barCodeSize = objGraphics.MeasureString(barCode, Code39Font);
            bcodeWidth = Max(bcodeWidth, (int)barCodeSize.Width);
            bcodeHeight += (int)barCodeSize.Height;
            //计算条码字符串size
            if (showCodeString)
            {
                codeStringSize = objGraphics.MeasureString(barCode, codeStringFont);
                bcodeWidth = Max(bcodeWidth, (int)codeStringSize.Width);
                bcodeHeight += (itemSepHeight + (int)codeStringSize.Height);
            }

            //释放资源
            objGraphics.Dispose();
            tmpBitmap.Dispose();

            return (new Bitmap(bcodeWidth, bcodeHeight, PixelFormat.Format32bppArgb));
        }

        #endregion


        #region 计算方法

        /// <summary>
        /// 比较大小
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private int Max(int v1, int v2)
        {
            return (v1 > v2 ? v1 : v2);
        }

        /// <summary>
        /// 返回中心点
        /// </summary>
        /// <param name="localWidth"></param>
        /// <param name="globalWidth"></param>
        /// <returns></returns>
        private int XCentered(int localWidth, int globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }

        #endregion

    }
}
