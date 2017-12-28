using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UFC.EPR
{
    public partial class ucSuperMark : UserControl
    {
        #region 字段
        private ArrayList arrPicture;
        Bitmap imgSelect;   //选择图片
        Pen penDash;        //点划线画笔
        private InkOverlayEditingMode editingMode;  //图片编辑模式
        private Color drawingColor; //画笔颜色
        private InkOverlayEraserMode eraserMode;    //擦除模式
        Point pointStart;       //选择起始点
        Point pointPosition;    //选择按下位置
        bool hasEraseOld;
        private System.Windows.Forms.PictureBox frontPicture;

        #endregion 字段
        #region 构造函数
        public ucSuperMark()
        {
            InitializeComponent();
        }
        public ucSuperMark(ArrayList arrPicture)
        {
            InitializeComponent();
            this.arrPicture = arrPicture;
        }

        private void ucSuperMark_Load(object sender, EventArgs e)
        {
            if (arrPicture != null && arrPicture.Count > 0)
            {
                for (int i = 0; i < arrPicture.Count; i++)
                {
                    this.cboPage.Items.Add(i + 1);
                }
                cboPage.SelectedIndexChanged += new EventHandler(this.ComboBox1_SelectedIndexChanged);
                this.cboPage.SelectedIndex = 0;
                penDash = new Pen(Color.Black, 1);
                penDash.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                this.drawingColor = this.neuColorPicker1.Color;
                this.hasEraseOld = false;
            }
        }
        #endregion 构造函数

        #region 事件及事件处理方法

        /// <summary>
        /// 页码下拉框选择改变事件
        /// 打开对应的预览页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //this.PrintPreviewControl1.StartPage = this.ComboBox1.SelectedIndex;
            this.Panel2.Controls.Clear();
            PictureBox pic = new PictureBox();
            pic.Size = new Size(820, 1150);
            pic.MaximumSize = new Size(820, 1150);
            pic.MinimumSize = new Size(820, 1150);
            if (Panel2.Width > pic.Width + 26)
            {
                pic.Left = (Panel2.Width - pic.Width) / 2;
            }
            else
            {
                pic.Left = 12;
            }
            pic.Top = 13 - this.Panel2.VerticalScroll.Value * 1169 / (this.Panel2.VerticalScroll.Maximum - this.Panel2.VerticalScroll.Minimum);
            Image img = (Image)arrPicture[this.cboPage.SelectedIndex];
            pic.Image = img;
            //pic.MouseDown += new MouseEventHandler(pic_MouseDown);
            //pic.MouseMove += new MouseEventHandler(pic_MouseMove);
            //pic.Dock = DockStyle.Top;
            pic.Anchor = AnchorStyles.None;
            pic.BackColor = Color.White;
            this.Panel2.Controls.Add(pic);
            // 
            // frontPicture
            // 
            this.frontPicture = new PictureBox();
            this.frontPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.frontPicture.Location = new System.Drawing.Point(0, 0);
            this.frontPicture.Dock = DockStyle.Fill;
            this.frontPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frontPicture_MouseMove);
            this.frontPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frontPicture_MouseDown);
            this.frontPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frontPicture_MouseUp);

            pic.Controls.Add(this.frontPicture);
            Bitmap bmp = new Bitmap(this.frontPicture.Width, this.frontPicture.Height);
            this.SetBitmap(bmp);
            this.frontPicture.Image = bmp;
        }
        #region 按钮事件
        /// <summary>
        /// 画线按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbDraw_Click(object sender, EventArgs e)
        {
            this.frontPicture.Enabled = true;
            this.frontPicture.Controls.Clear();
            this.frontPicture.Cursor = Cursors.Default;
            this.tbSelect.Checked = this.tbDelete.Checked = this.tbEraze.Checked = false;
            this.editingMode = InkOverlayEditingMode.Ink;
        }

        /// <summary>
        /// 选择按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSelect_Click(object sender, EventArgs e)
        {
            this.frontPicture.Enabled = true;
            this.frontPicture.Controls.Clear();
            this.frontPicture.Cursor = Cursors.Cross;

            this.tbDraw.Checked = this.tbDelete.Checked = this.tbEraze.Checked = false;

            this.editingMode = InkOverlayEditingMode.Select;
        }

        /// <summary>
        /// 文字按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbText_Click(object sender, EventArgs e)
        {
            this.frontPicture.Enabled = true;
            this.frontPicture.Controls.Clear();

            this.tbDraw.Checked = this.tbSelect.Checked = this.tbEraze.Checked = false;
            //this.eraserMode = InkOverlayEraserMode.StrokeErase;
            this.frontPicture.Cursor = Cursors.IBeam;
            this.editingMode = InkOverlayEditingMode.Text;
        }

        /// <summary>
        /// 擦除按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEraze_Click(object sender, EventArgs e)
        {
            this.frontPicture.Enabled = true;
            this.frontPicture.Controls.Clear();

            this.tbDraw.Checked = this.tbSelect.Checked = this.tbDelete.Checked = false;
            this.eraserMode = InkOverlayEraserMode.PointErase;
            this.editingMode = InkOverlayEditingMode.Delete;
            this.frontPicture.Cursor = new Cursor(this.GetType(), "CursorErase.cur");
        }

        /// <summary>
        /// 选择颜色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuColorPicker1_NewColor(object sender, Neusoft.Toolkit.Controls.NewColorArgs e)
        {
            this.frontPicture.Enabled = true;

            this.drawingColor = e.NewColor;
        }
        #endregion 按钮事件

        /// <summary>
        /// 打开窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.pictureBox1.BackColor = Color.FromArgb(128, Color.Red);
            //this.panel1.BackColor = Color.FromArgb(128, Color.Red);
            penDash = new Pen(Color.Black, 1);
            penDash.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            Bitmap bmp = new Bitmap(this.frontPicture.Width, this.frontPicture.Height);

            this.SetBitmap(bmp);
            this.frontPicture.Image = bmp;
            this.drawingColor = this.neuColorPicker1.Color;
            this.hasEraseOld = false;
        }

        #region 画图图层事件
        /// <summary>
        /// 画图图层鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frontPicture_MouseDown(object sender, MouseEventArgs e)
        {
            Image img = this.frontPicture.Image;
            Graphics grap = Graphics.FromImage(img);
            if (e.Button == MouseButtons.Left)
            {
                switch (this.editingMode)
                {
                    case InkOverlayEditingMode.Delete:
                        //清除模式，清除图片
                        this.SetBitmap(this.frontPicture.Image as Bitmap, new Rectangle(e.Location.X, e.Location.Y, 8, 8));
                        this.frontPicture.Refresh();
                        break;
                    case InkOverlayEditingMode.Text:
                        //文本模式，输入文本
                        if (this.frontPicture.Controls.Count > 0 && this.frontPicture.Controls[0].GetType() == typeof(TextBox))
                        {
                            TextBox textBox = this.frontPicture.Controls[0] as TextBox;
                            if (textBox != null && textBox.Text != "")
                            {
                                grap.DrawString(textBox.Text, textBox.Font, new SolidBrush(textBox.ForeColor), textBox.Location);
                            }
                            this.frontPicture.Controls.Clear();
                            this.frontPicture.Refresh();
                            frontPicture.Cursor = Cursors.IBeam;
                        }
                        else
                        {
                            TextBox txtBox = new TextBox();
                            txtBox.Location = e.Location;
                            txtBox.ForeColor = this.drawingColor;
                            txtBox.BackColor = Color.White;
                            txtBox.Font = this.neuFontPicker1.SelectedFont;
                            txtBox.ImeMode = ImeMode.On;
                            txtBox.BorderStyle = BorderStyle.FixedSingle;
                            txtBox.KeyDown += new KeyEventHandler(this.Text_KeyDown);
                            this.frontPicture.Controls.Add(txtBox);
                            txtBox.Focus();
                            frontPicture.Cursor = Cursors.Default;
                        }
                        break;
                    case InkOverlayEditingMode.Select:
                        //选择模式，确定选择框位置
                        this.frontPicture.Controls.Clear();
                        pointStart = e.Location;
                        break;
                    default:
                        break;
                }
            }
            pointStart = e.Location;

        }

        /// <summary>
        /// 画图图层鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frontPicture_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = this.frontPicture.Image;
            Graphics grap = Graphics.FromImage(img);
            if (e.Button == MouseButtons.Left)
            {
                switch (this.editingMode)
                {
                    case InkOverlayEditingMode.Ink:
                        //画线模式，铅笔画
                        grap.FillEllipse(new SolidBrush(Color.FromArgb(255, this.drawingColor)), e.X - 1, e.Y - 1, 2, 2);
                        grap.DrawLine(new Pen(Color.FromArgb(255, this.drawingColor), 2), pointStart, e.Location);
                        this.frontPicture.Refresh();
                        pointStart = e.Location;
                        break;
                    case InkOverlayEditingMode.Delete:
                        if (this.eraserMode == InkOverlayEraserMode.PointErase)
                        {
                            //清除模式，清除图片
                            if (pointStart != null)
                            {
                                grap.DrawLine(new Pen(Color.White, 8), new Point(pointStart.X + 4, pointStart.Y + 4), new Point(e.Location.X + 4, e.Location.Y + 4));
                                //this.SetBitmap((Bitmap)img);
                            }
                        }

                        this.frontPicture.Refresh();
                        pointStart = e.Location;
                        break;
                    case InkOverlayEditingMode.Select:
                        //选择模式，改变选择框大小
                        this.frontPicture.Controls.Clear();
                        PictureBox picSelect = new PictureBox();
                        picSelect.Location = new Point(System.Math.Min(pointStart.X, e.X), System.Math.Min(pointStart.Y, e.Y));
                        picSelect.Size = new Size(System.Math.Abs(pointStart.X - e.X), System.Math.Abs(pointStart.Y - e.Y));
                        picSelect.BackColor = Color.Transparent;
                        if (picSelect.Width > 1 && picSelect.Height > 1)
                        {
                            Image imgSelect = new Bitmap(picSelect.Width, picSelect.Height);
                            Graphics grapSelect = Graphics.FromImage(imgSelect);
                            grapSelect.DrawRectangle(penDash, 0, 0, picSelect.Width - 1, picSelect.Height - 1);
                            picSelect.BorderStyle = BorderStyle.None;
                            picSelect.Image = imgSelect;
                        }
                        picSelect.Cursor = Cursors.Hand;
                        picSelect.MouseDown += new MouseEventHandler(picSelect_MouseDown);
                        picSelect.MouseUp += new MouseEventHandler(picSelect_MouseUp);

                        picSelect.MouseMove += new MouseEventHandler(picSelect_MouseMove);
                        this.frontPicture.Controls.Add(picSelect);
                        picSelect.SendToBack();
                        this.frontPicture.Refresh();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 画图图层鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frontPicture_MouseUp(object sender, MouseEventArgs e)
        {
            Image img = this.frontPicture.Image;
            Graphics grap = Graphics.FromImage(img);
            if (e.Button == MouseButtons.Left)
            {
                switch (this.editingMode)
                {
                    case InkOverlayEditingMode.Ink:
                        break;
                    case InkOverlayEditingMode.Delete:
                        if (this.eraserMode == InkOverlayEraserMode.PointErase)
                        {
                            //清除模式，清除清除范围
                            this.SetBitmap(this.frontPicture.Image as Bitmap, Color.White);
                            this.frontPicture.Refresh();
                        }
                        break;
                    case InkOverlayEditingMode.Select:
                        //选择模式，确定移动范围位置与大小
                        if (this.frontPicture.Controls.Count > 0)
                        {
                            PictureBox picSelect = this.frontPicture.Controls[0] as PictureBox;
                            if (picSelect != null && picSelect.Width != 0 && picSelect.Height != 0)
                            {
                                picSelect.Image = null;
                                pointStart = picSelect.Location;
                                imgSelect = new Bitmap(picSelect.Width, picSelect.Height);
                                this.SetBitmap(imgSelect, img as Bitmap, pointStart);
                                picSelect.BorderStyle = BorderStyle.None;
                                picSelect.Location = new Point(0, 0);
                                picSelect.Size = frontPicture.Size;
                                picSelect.Image = new Bitmap(picSelect.Width, picSelect.Height);
                                Graphics grapSelect = Graphics.FromImage(picSelect.Image);
                                grapSelect.DrawImage(imgSelect, pointStart);
                                grapSelect.DrawRectangle(penDash, pointStart.X - 1, pointStart.Y - 1, imgSelect.Width + 2, imgSelect.Height + 2);
                                picSelect.Refresh();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion 画图图层事件

        #region 选择框事件
        /// <summary>
        /// 选择框鼠标按下事件，如果在选择范围内，则清除选择区域图片，否则选择框失效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void picSelect_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= pointStart.X && e.X <= pointStart.X + imgSelect.Width && e.Y >= pointStart.Y && e.Y <= pointStart.Y + imgSelect.Height)
                {
                    if (Control.ModifierKeys != Keys.Control && !hasEraseOld)
                    {
                        Bitmap bmp = this.frontPicture.Image as Bitmap;
                        Control ctr = sender as Control;
                        Graphics grapTemp = Graphics.FromImage(this.frontPicture.Image);
                        grapTemp.FillRectangle(Brushes.White,  new Rectangle(pointStart, imgSelect.Size));
                        this.SetBitmap(bmp);
                        //this.SetBitmap(bmp, new Rectangle(pointStart, imgSelect.Size));
                        hasEraseOld = true;
                    }
                    else if (Control.ModifierKeys == Keys.Control)
                    {
                        Graphics grapInk = Graphics.FromImage(this.frontPicture.Image);
                        if (this.chkOverride.Checked)
                        {
                            this.SetBitmap((Bitmap)this.frontPicture.Image, new Rectangle(pointStart.X, pointStart.Y, imgSelect.Width, imgSelect.Height)); //(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y, imgSelect.Width, imgSelect.Height));
                        }
                        grapInk.DrawImage(imgSelect, pointStart); //new Point(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y));
                    }
                    pointPosition = e.Location;
                }
                else if (imgSelect != null && this.frontPicture.Controls.Count > 0)
                {
                    hasEraseOld = false;
                    Graphics grapInk = Graphics.FromImage(this.frontPicture.Image);
                    if (this.chkOverride.Checked)
                    {
                        this.SetBitmap((Bitmap)this.frontPicture.Image, new Rectangle(pointStart.X, pointStart.Y, imgSelect.Width, imgSelect.Height)); //(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y, imgSelect.Width, imgSelect.Height));
                    }
                    grapInk.DrawImage(imgSelect, pointStart); //new Point(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y));
                    this.frontPicture.Controls.Clear();
                }
            }
            frontPicture.Refresh();
        }

        /// <summary>
        /// 选择框鼠标抬起事件，如果在选择范围内移出，则移动选择区域的图片到新的位置
        /// 否则选择框失效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void picSelect_MouseUp(object sender, MouseEventArgs e)
        {
            pointStart = new Point(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y);
        }

        /// <summary>
        /// 选择框鼠标按下事件，如果在选择范围内，则清除选择区域图片，否则选择框失效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void picSelect_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox picSelect = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                Graphics grap = Graphics.FromImage(picSelect.Image);
                grap.Clear(Color.Transparent);
                if (this.chkOverride.Checked)
                {
                    grap.FillRectangle(new SolidBrush(Color.White), new Rectangle(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y, imgSelect.Width, imgSelect.Height));
                }
                grap.DrawImage(imgSelect, new Point(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y));

                grap.DrawRectangle(penDash, pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y, imgSelect.Width, imgSelect.Height);
                System.Diagnostics.Debug.WriteLine(e.Location);
                base.Refresh();
            }
            else
            {
                if (e.X >= pointStart.X && e.X <= pointStart.X + imgSelect.Width && e.Y >= pointStart.Y && e.Y <= pointStart.Y + imgSelect.Height)
                {
                    picSelect.Cursor = Cursors.SizeAll;
                }
                else
                {
                    picSelect.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// ch
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                if (this.editingMode == InkOverlayEditingMode.Select && imgSelect != null && this.frontPicture.Controls.Count > 0)
                {
                    //this.SetBitmap((Bitmap)this.frontPicture.Image, new Rectangle(pointStart.X, pointStart.Y, imgSelect.Width, imgSelect.Height)); //(pointStart.X + e.X - pointPosition.X, pointStart.Y + e.Y - pointPosition.Y, imgSelect.Width, imgSelect.Height));
                    Graphics grapTemp = Graphics.FromImage(this.frontPicture.Image);
                    grapTemp.FillRectangle(Brushes.White, new Rectangle(pointStart.X, pointStart.Y, imgSelect.Width, imgSelect.Height));
                    this.SetBitmap((Bitmap)this.frontPicture.Image);
                    this.frontPicture.Controls.Clear();
                    this.hasEraseOld = false;
                }
            }
            else if (keyData == Keys.Escape)
            {
                this.frontPicture.Controls.Clear();
                this.hasEraseOld = false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion 选择框事件

        #region 文本框事件
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                //回车提交文本
                if (textBox != null && textBox.Text != "")
                {
                    Graphics grap = Graphics.FromImage(this.frontPicture.Image);
                    grap.DrawString(textBox.Text, textBox.Font, new SolidBrush(textBox.ForeColor), textBox.Location);
                }
                sender = null;
                this.frontPicture.Controls.Clear();
                this.frontPicture.Refresh();
            }
            else if (e.Control && e.KeyCode == Keys.Left)
            {
                textBox.Left = textBox.Left - 1;
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Right)
            {
                textBox.Left = textBox.Left + 1;
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Up)
            {
                textBox.Top = textBox.Top - 1;
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Down)
            {
                textBox.Top = textBox.Top + 1;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                sender = null;
                this.frontPicture.Controls.Clear();
                this.frontPicture.Refresh();
            }
        }
        #endregion 文本框事件
        #endregion 事件

        #region 方法
        private void SetBitmap(Bitmap bmpDist)
        {
            bmpDist.MakeTransparent(Color.White);
            //for (int i = 0; i < bmpDist.Width; i++)
            //{
            //    for (int j = 0; j < bmpDist.Height; j++)
            //    {
            //        if (i >= 0 && j >= 0 && i < bmpDist.Width && j < bmpDist.Height)
            //        {
            //            bmpDist.SetPixel(i, j, Color.FromArgb(0, Color.White));
            //        }
            //    }
            //}

        }

        private void SetBitmap(Bitmap bmpDist, Color color)
        {
            bmpDist.MakeTransparent(Color.FromArgb(255, color));
            //for (int i = 0; i < bmpDist.Width; i++)
            //{
            //    for (int j = 0; j < bmpDist.Height; j++)
            //    {
            //        if (i >= 0 && j >= 0 && i < bmpDist.Width && j < bmpDist.Height)
            //        {
            //            if (bmpDist.GetPixel(i, j) == Color.FromArgb(255, color))
            //            {
            //                bmpDist.SetPixel(i, j, Color.FromArgb(0, Color.White));
            //            }
            //        }
            //    }
            //}

        }
        private void SetBitmap(Bitmap bmpDist, Rectangle rect)
        {
            for (int i = rect.X; i < rect.Right; i++)
            {
                for (int j = rect.Y; j < rect.Bottom; j++)
                {
                    if (i >= 0 && j >= 0 && i < bmpDist.Width && j < bmpDist.Height)
                    {
                        bmpDist.SetPixel(i, j, Color.FromArgb(0, Color.White));
                    }
                }
            }
        }

        private void SetBitmap(Bitmap bmpDist, Bitmap bmpSource, Point pointStart)
        {
            for (int i = 0; i < bmpDist.Width; i++)
            {
                for (int j = 0; j < bmpDist.Height; j++)
                {
                    if (i >= 0 && j >= 0 && i < bmpDist.Width && j < bmpDist.Height &&
                        i + pointStart.X >= 0 && j + pointStart.Y >= 0 && i + pointStart.X < bmpSource.Width && j + pointStart.Y < bmpSource.Height)
                    {
                        bmpDist.SetPixel(i, j, bmpSource.GetPixel(i + pointStart.X, j + pointStart.Y));
                    }
                }
            }
        }

        #endregion 方法
    }
    public enum InkOverlayEditingMode
    {
        [Description("InkOverlayEditingModeDelete 删除")]
        Delete = 1,
        [Description("InkOverlayEditingModeInk 画线")]
        Ink = 0,
        [Description("InkOverlayEditingModeSelect 选择")]
        Select = 2,
        [Description("InkOverlayEditingModeText 文本")]
        Text = 3
    }

    [Description("InkOverlayEraserMode")]
    public enum InkOverlayEraserMode
    {
        [Description("InkOverlayEraserModePointErase")]
        PointErase = 1,
        [Description("InkOverlayEraserModeStrokeErase")]
        StrokeErase = 0
    }
}
