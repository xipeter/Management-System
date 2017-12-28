using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace Neusoft.HISFC.Components.Account.Class
{
    /// <summary>
    /// 画条码 luzhp 2007-7-11
    /// </summary>
    public class Code39
    {
        private const int _itemSepHeight = 3;
        //标题size
        SizeF _titleSize = SizeF.Empty;
        //条码size
        SizeF _barCodeSize = SizeF.Empty;
        //条码字符串size
        SizeF _codeStringSize = SizeF.Empty;

        #region 标题

        private string _titleString = null;
        private Font _titleFont = null;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _titleString; }
            set { _titleString = value; }
        }
        /// <summary>
        /// 标题字体
        /// </summary>
        public Font TitleFont
        {
            get { return _titleFont; }
            set { _titleFont = value; }
        }
        #endregion

        #region 条码字符串

        private bool _showCodeString = false;
        private Font _codeStringFont = null;
        /// <summary>
        /// 是否显示条码字符串
        /// </summary>
        public bool ShowCodeString
        {
            get { return _showCodeString; }
            set { _showCodeString = value; }
        }

        /// <summary>
        /// 画条码字符串字体
        /// </summary>
        public Font CodeStringFont
        {
            get { return _codeStringFont; }
            set { _codeStringFont = value; }
        }
        #endregion

        #region 条码字体

        private Font _c39Font = null;
        private float _c39FontSize = 24;
        /// <summary>
        /// 条形码字体size
        /// </summary>
        public float FontSize
        {
            get { return _c39FontSize; }
            set { _c39FontSize = value; }
        }

        /// <summary>
        /// 得到条形码字体
        /// </summary>
        private Font Code39Font
        {
            get
            {
                if (_c39Font == null)
                {
                    PrivateFontCollection pfc = new PrivateFontCollection();

                    byte[] fontdata = global ::Neusoft.HISFC.Components.Account.Properties.Resources.FREE3OF9;
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
                            _c39Font = new Font(ff, _c39FontSize);
                            break;
                        }
                    }
                }
                return _c39Font;
            }
        }

        #endregion

        public Code39()
        {
            _titleFont = new Font("Arial", 8);
            _codeStringFont = new Font("Arial", 8);
        }

        #region 画条形码

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
            if (_titleString != null)
            {
                objGraphics.DrawString(_titleString, _titleFont, new SolidBrush(Color.Black), XCentered((int)_titleSize.Width, bcodeWidth), vpos);
                vpos += (((int)_titleSize.Height) + _itemSepHeight);
            }
            // 画条码
            objGraphics.DrawString(barCode, Code39Font, new SolidBrush(Color.Black), XCentered((int)_barCodeSize.Width, bcodeWidth), vpos);

            // 画条码字符串
            if (_showCodeString)
            {
                vpos += (((int)_barCodeSize.Height));
                objGraphics.DrawString(barCode, _codeStringFont, new SolidBrush(Color.Black), XCentered((int)_codeStringSize.Width, bcodeWidth), vpos);
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
            if (_titleString != null)
            {
                _titleSize = objGraphics.MeasureString(_titleString, _titleFont);
                bcodeWidth = (int)_titleSize.Width;
                bcodeHeight = (int)_titleSize.Height + _itemSepHeight;
            }
            //计算条码size
            _barCodeSize = objGraphics.MeasureString(barCode, Code39Font);
            bcodeWidth = Max(bcodeWidth, (int)_barCodeSize.Width);
            bcodeHeight += (int)_barCodeSize.Height;
            //计算条码字符串size
            if (_showCodeString)
            {
                _codeStringSize = objGraphics.MeasureString(barCode, _codeStringFont);
                bcodeWidth = Max(bcodeWidth, (int)_codeStringSize.Width);
                bcodeHeight += (_itemSepHeight + (int)_codeStringSize.Height);
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
