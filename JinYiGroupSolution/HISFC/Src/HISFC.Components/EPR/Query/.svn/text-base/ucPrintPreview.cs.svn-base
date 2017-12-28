using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.EPR;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class ucPrintPreview: ucPrintPicture
    {
        #region 字段
        private int intPage;
        ArrayList arrPageNumber;

        #endregion 字段

        public ucPrintPreview()
        {
            InitializeComponent();
        }
        public ucPrintPreview(ArrayList arrPicture)
        {
            InitializeComponent();
            this.arrPicture = arrPicture;
        }
        public ucPrintPreview(TemplateDesignerApplication.ucDataFileLoader loader, Neusoft.HISFC.Models.RADT.PatientInfo patient)
            : base(loader, patient)
        {
            InitializeComponent();
        }
       
        #region "事件与事件处理函数"
        /// <summary>
        /// 预览图鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       protected override void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || System.Math.Max(System.Math.Abs(e.X - pointStart.X), System.Math.Abs(e.Y - pointStart.Y)) <= 5)
            {
                return;
            }
            PictureBox pic = (PictureBox)sender;
            //选择打印范围
            if (this.rdoPrintSelection.Checked)
            {
                PictureBox picPanel = new PictureBox();
                picPanel.Left = System.Math.Min(e.X, pointStart.X);
                picPanel.Top = System.Math.Min(e.Y, pointStart.Y);
                picPanel.Width = System.Math.Abs(e.X - pointStart.X);
                picPanel.Height = System.Math.Abs(e.Y - pointStart.Y);
                picPanel.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                pic.Controls.Clear();
                pic.Controls.Add(picPanel);
                pic.Update();
            }
            //续打，包括横向排列情况
            else if (this.rdoContinuePrint.Checked)
            {
                //新点在下方
                if (e.Y - pointStart.Y > 5)
                {
                    //新点在右下方
                    if (e.X - pointStart.X < -5)
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = 0;
                        picPanel1.Top = pointStart.Y;
                        picPanel1.Width = pointStart.X;
                        picPanel1.Height = e.Y - pointStart.Y;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        PictureBox picPanel2 = new PictureBox();
                        picPanel2.Left = 0;
                        picPanel2.Top = e.Y;
                        picPanel2.Width = pic.Width;
                        picPanel2.Height = pic.Height - e.Y;
                        picPanel2.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Controls.Add(picPanel2);
                        pic.Update();
                    }
                    //新点在左下方
                    else if (e.X - pointStart.X > 5)
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = pointStart.X;
                        picPanel1.Top = pointStart.Y;
                        picPanel1.Width = pic.Width - pointStart.X;
                        picPanel1.Height = e.Y - pointStart.Y;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        PictureBox picPanel2 = new PictureBox();
                        picPanel2.Left = 0;
                        picPanel2.Top = e.Y;
                        picPanel2.Width = pic.Width;
                        picPanel2.Height = pic.Height - e.Y;
                        picPanel2.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Controls.Add(picPanel2);
                        pic.Update();
                    }
                    //新点在一条直线靠左，横排护理记录等等
                    else if (e.X - pointStart.X < 0)
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = 0;
                        picPanel1.Top = 0;
                        picPanel1.Width = pointStart.X;
                        picPanel1.Height = pic.Height;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Update();
                    }
                    //新点在一条直线靠右，体温单等等
                    else
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = pointStart.X;
                        picPanel1.Top = 0;
                        picPanel1.Width = pic.Width - pointStart.X;
                        picPanel1.Height = pic.Height;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Update();
                    }
                }
                //新点在上方
                else if (e.Y - pointStart.Y < -5)
                {
                    //新点在右上方
                    if (e.X - pointStart.X > 5)
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = pointStart.X;
                        picPanel1.Top = e.Y;
                        picPanel1.Width = pic.Width - pointStart.X;
                        picPanel1.Height = pointStart.Y - e.Y;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        PictureBox picPanel2 = new PictureBox();
                        picPanel2.Left = 0;
                        picPanel2.Top = pointStart.Y;
                        picPanel2.Width = pic.Width;
                        picPanel2.Height = pic.Height - pointStart.Y;
                        picPanel2.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Controls.Add(picPanel2);
                        pic.Update();
                    }
                    //新点在左上方
                    else if (e.X - pointStart.X < -5)
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = 0;
                        picPanel1.Top = e.Y;
                        picPanel1.Width = pointStart.X;
                        picPanel1.Height = pointStart.Y - e.Y;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        PictureBox picPanel2 = new PictureBox();
                        picPanel2.Left = 0;
                        picPanel2.Top = pointStart.Y;
                        picPanel2.Width = pic.Width;
                        picPanel2.Height = pic.Height - pointStart.Y;
                        picPanel2.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Controls.Add(picPanel2);
                        pic.Update();
                    }
                    //新点在一条直线靠左，横排护理记录等等
                    else if (e.X - pointStart.X < 0)
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = 0;
                        picPanel1.Top = 0;
                        picPanel1.Width = pointStart.X;
                        picPanel1.Height = pic.Height;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Update();
                    }
                    //新点在一条直线靠右，体温单等等
                    else
                    {
                        PictureBox picPanel1 = new PictureBox();
                        picPanel1.Left = pointStart.X;
                        picPanel1.Top = 0;
                        picPanel1.Width = pic.Width - pointStart.X;
                        picPanel1.Height = pic.Height;
                        picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                        pic.Controls.Clear();
                        pic.Controls.Add(picPanel1);
                        pic.Update();
                    }
                }
                //在一条直线上
                else
                {
                    PictureBox picPanel1 = new PictureBox();
                    picPanel1.Left = 0;
                    picPanel1.Top = pointStart.Y;
                    picPanel1.Width = pic.Width;
                    picPanel1.Height = pic.Height - pointStart.Y;
                    picPanel1.BackColor = System.Drawing.Color.FromArgb(70, 0, 100, 100);
                    pic.Controls.Clear();
                    pic.Controls.Add(picPanel1);
                    pic.Update();
                }
            }
        }

        /// <summary>
        /// 预览图鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void pic_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            //定位打印起始位置
            if (e.Button == MouseButtons.Left)
            {
                pointStart = e.Location;
                pic.Controls.Clear();
                pic.Update();
            }
        }
        
        void ucPrintPreview_Load(object sender, System.EventArgs e)
        {
            this.panel1.Controls.AddRange(new Control[] { this.button1, this.rdoPrintAll, this.rdoPrintActivePage, this.rdoPrintPages, this.txtPages, this.rdoPrintSelection , this.rdoContinuePrint});
        }


        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            if (Panel2.Controls == null || Panel2.Controls.Count == 0)
            {
                MessageBox.Show("没有页面要打印");
                return;
            }
            PictureBox pic = (PictureBox)this.Panel2.Controls[0];
            if (pic == null)
            {
                MessageBox.Show("没有页面要打印");
                return;
            }
            if (this.rdoContinuePrint.Checked || this.rdoPrintSelection.Checked)
            {
                if (pic.Controls == null || pic.Controls.Count == 0 || pic.Controls[0].Controls == null || pic.Controls[0].Controls.Count == 0)
                {
                    MessageBox.Show("请首先选择打印范围");
                    return;
                }
            }

            System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
            document.DefaultPageSettings.PaperSize = new PaperSize(this.pageSize.Name, this.pageSize.Width, this.pageSize.Height);
            document.DefaultPageSettings.Margins = new Margins(pageSize.Left, pageSize.Left, pageSize.Top, 50);
            document.BeginPrint += new PrintEventHandler(document_BeginPrint);
            document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.document_PrintPage);
            document.EndPrint += new PrintEventHandler(document_EndPrint);

            document.Print();
            //pic.Controls.Clear();
        }

        void document_EndPrint(object sender, PrintEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void document_BeginPrint(object sender, PrintEventArgs e)
        {
            arrPageNumber = new ArrayList();
            arrPageNumber.Clear();
            intPage = 0;
            if (this.rdoPrintAll.Checked)
            {
                for (int i = 0; i < arrPicture.Count; i++)
                {
                    arrPageNumber.Add(i + 1);
                }
            }
            else if (this.rdoPrintPages.Checked)
            {
                string[] strs1 = this.txtPages.Text.Split(',');
                foreach (string str1 in strs1)
                {
                    string[] strs2 = str1.Split('-');
                    for (int i = 0; i < strs2.Length; i++)
                    {
                        arrPageNumber.Add(int.Parse(strs2[i]));
                    }
                }
            }
            else if (this.rdoPrintActivePage.Checked)
            {
                arrPageNumber.Add(this.cboPage.SelectedIndex + 1);
            }
            else if (this.rdoContinuePrint.Checked)
            {
                for (int i = this.cboPage.SelectedIndex; i < arrPicture.Count; i++)
                {
                    arrPageNumber.Add(i + 1);
                }
            }
            else
            {
                arrPageNumber.Add(this.cboPage.SelectedIndex + 1);
            }
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int curPage = (int)arrPageNumber[intPage] - 1;
            Bitmap img = (Bitmap)((Image)arrPicture[curPage]).Clone();
            Graphics grap = Graphics.FromImage(img);
            //Bitmap imgPrint = new Bitmap(e.PageBounds.Width, e.PageBounds.Height);
            //Graphics grapPrint = Graphics.FromImage(imgPrint);
            if ((this.rdoContinuePrint.Checked || this.rdoPrintSelection.Checked) && intPage == 0)
            {
                PictureBox pic = (PictureBox)this.Panel2.Controls[0];
                if (this.PrintSuperMarkType == 1)
                {
                    //Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.loader.CurrentLoader.dt.ID;
                    obj.Name = (curPage + 1).ToString();
                    byte[] byImage = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSuperMarkImage(obj);

                    //Bitmap bmpSuperMark = new Bitmap(this.frontPicture.Width, this.frontPicture.Height);
                    //Graphics grapSuperMark = Graphics.FromImage(bmpSuperMark);
                    if (byImage != null && byImage.Length > 0)
                    {
                        System.IO.MemoryStream stream = new System.IO.MemoryStream(byImage);
                        Bitmap imgTemp = (Bitmap)Bitmap.FromStream(stream);
                        imgTemp.MakeTransparent(Color.White);
                        grap.DrawImage(imgTemp, new Point(0, 0));
                    }
                }
                //this.SetBitmap(bmpSuperMark);

                if (pic.Controls.Count >= 1 && pic.Controls[0].Controls.Count >= 1)
                {
                    Control picPanel = pic.Controls[0].Controls[0];
                    grap.FillRectangle(Brushes.White, 0, 0, (int)(pic.Width * times), (int)(picPanel.Top * times));
                    grap.FillRectangle(Brushes.White, 0, (int)(picPanel.Top * times), (int)(picPanel.Left * times), (int)(picPanel.Height * times));
                    grap.FillRectangle(Brushes.White, (int)(picPanel.Right * times), (int)(picPanel.Top * times), (int)((pic.Width - picPanel.Right) * times), (int)(picPanel.Height * times));
                    if (pic.Controls.Count >= 1 && pic.Controls[0].Controls.Count == 1)
                    {
                        grap.FillRectangle(Brushes.White, 0, (int)(picPanel.Bottom * times), (int)(pic.Width * times), (int)((pic.Height - picPanel.Bottom) * times));
                    }
                }
                grap.FillRectangle(Brushes.White, 0, e.MarginBounds.Bottom, e.PageBounds.Width, e.PageBounds.Bottom - e.MarginBounds.Bottom);
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            else
            {
                Bitmap imgBackGround;
                if (curPage == 0)
                {
                    if (currentPanel.首页打印背景 != null)
                    {
                        imgBackGround = currentPanel.首页打印背景.Clone() as Bitmap;
                    }
                    else if (currentPanel.打印背景 != null)
                    {
                        imgBackGround = currentPanel.打印背景.Clone() as Bitmap;
                    }
                    else
                    {
                        imgBackGround = null;
                    }
                }
                else if (currentPanel.打印背景 != null)
                {
                    imgBackGround = currentPanel.打印背景.Clone() as Bitmap;
                }
                else
                {
                    imgBackGround = null;
                }
                //Bitmap imgPrint = new Bitmap(pic.Width, pic.Height);

                //Graphics grapPrint = Graphics.FromImage(e);
                e.Graphics.Clear(Color.White);
                if (imgBackGround != null)
                {
                    imgBackGround.MakeTransparent(Color.White);
                    e.Graphics.DrawImage(imgBackGround, 0, 0, imgBackGround.Width, imgBackGround.Height);
                }
                img.MakeTransparent(Color.White);
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);

                //e.Graphics.DrawImage(imgPrint, new Point(0, 0));
                if (this.PrintSuperMarkType == 1)
                {
                    //Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.loader.CurrentLoader.dt.ID;
                    obj.Name = (curPage + 1).ToString();
                    byte[] byImage = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSuperMarkImage(obj);

                    //Bitmap bmpSuperMark = new Bitmap(this.frontPicture.Width, this.frontPicture.Height);
                    //Graphics grapSuperMark = Graphics.FromImage(bmpSuperMark);
                    if (byImage != null && byImage.Length > 0)
                    {
                        System.IO.MemoryStream stream = new System.IO.MemoryStream(byImage);
                        Bitmap imgTemp = (Bitmap)Image.FromStream(stream);
                        e.Graphics.DrawImage(imgTemp, 0, 0, imgTemp.Width, imgTemp.Height);
                        //grapSuperMark.DrawImage(imgTemp, new Point(0, 0));
                    }
                }
                //this.SetBitmap(bmpSuperMark);
                //e.Graphics.DrawImage(bmpSuperMark, new Point(0, 0));
            }

            intPage++;
            if (intPage >= arrPageNumber.Count)
            {
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
            }
        }


        #endregion "事件与事件处理函数"
        //private override page
        protected override void Page_SelectedChanged()
        {
        }
    }
}
