using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.EPR;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class ucPrintPicture : UserControl
    {

        #region "字段"

        protected Neusoft.HISFC.Models.Base.PageSize myPageSize;
        protected int printSuperMarkType = -1;
        protected ArrayList arrSortedControls;
        private int[] checkprints;
        private int startPage = 1;
        protected int TotalPage;
        private Rectangle rect;
        private int[] yEnds;
        private int top;
        private int[] tops;
        private bool[] isPrinteds;
        protected Neusoft.HISFC.Models.RADT.PatientInfo patient;

        private int row;
        protected Point pointStart;
        protected ArrayList arrControls;
        protected TemplateDesignerApplication.ucDataFileLoader loader;
        protected Neusoft.FrameWork.EPRControl.emrPanel currentPanel;
        public ArrayList arrPicture;
        private Image gCheked = null;
        private Image gUnCheked = null;
        private Image gRadioCheked = null;
        private Image gRadioUnCheked = null;
        private bool bIsAutoFont = true;
        protected double times = 1;
        #endregion "字段"
        protected System.Windows.Forms.PictureBox frontPicture;
        /// <summary>
        /// 打印纸张大小
        /// </summary>
        protected Neusoft.HISFC.Models.Base.PageSize pageSize
        {
            get
            {
                if(myPageSize == null)
                {
                    myPageSize = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.GetPageSize("EMR");
                }
                return myPageSize;
            }
            set
            {
                    myPageSize = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.GetPageSize("EMR");
            }
        }
        /// <summary>
        /// 打印上级修改痕迹
        /// 1 打印
        /// 0 不打印
        /// </summary>
        protected int PrintSuperMarkType
        {
            get
            {
                if (printSuperMarkType == -1)
                {
                    string str = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetControlArgument("EPR001");
                    if (str == "1")
                    {
                        printSuperMarkType = 1;
                    }
                    else
                    {
                        printSuperMarkType = 0;
                    }
                }
                return printSuperMarkType;
            }
            set
            {
                string str = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetControlArgument("EPR001");
                if (str == "1")
                {
                    printSuperMarkType = 1;
                }
                else
                {
                    printSuperMarkType = 0;
                }
            }
        }
        #region "构造函数"
        public ucPrintPicture(TemplateDesignerApplication.ucDataFileLoader loader, Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            // 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent();
            this.Panel2.AutoScrollMinSize = new System.Drawing.Size(this.pageSize.Width, this.pageSize.Height);
            printControlCompare.SetEPRControl();
            this.loader = loader;
            this.patient = patient;
        }
        public ucPrintPicture()
        {
            InitializeComponent();
            printControlCompare.SetEPRControl();
            //gCheked = this.printImage.Images[4].Clone() as Image;
            //gUnCheked = this.printImage.Images[5].Clone() as Image;
            //gRadioCheked = this.printImage.Images[2].Clone() as Image;
            //gRadioUnCheked = this.printImage.Images[3].Clone() as Image;
        }
        private void ucPrintPicture_Load(object sender, System.EventArgs e)
        {
            //this.PrintPreviewControl1.Zoom = 1;
           
        }
        #endregion "构造函数"

        #region "事件与事件处理函数"
        /// <summary>
        /// 控件大小改变，调整打印框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPrintPicture_Resize(object sender, EventArgs e)
        {
            if (this.Panel2.Controls.Count > 0)
            {
                Control pic = this.Panel2.Controls[0];
                if (Panel2.Width > pic.Width + 26)
                {
                    pic.Left = (Panel2.Width - pic.Width) / 2 - this.Panel2.HorizontalScroll.Value * pic.Width / (this.Panel2.HorizontalScroll.Maximum - this.Panel2.HorizontalScroll.Minimum);
                }
                else
                {
                    pic.Left = 12 - this.Panel2.HorizontalScroll.Value * pic.Width / (this.Panel2.HorizontalScroll.Maximum - this.Panel2.HorizontalScroll.Minimum);
                }
                pic.Top = 13 - this.Panel2.VerticalScroll.Value * pic.Height / (this.Panel2.VerticalScroll.Maximum - this.Panel2.VerticalScroll.Minimum);
            }
        }

        /// <summary>
        /// 选择页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //this.PrintPreviewControl1.StartPage = this.ComboBox1.SelectedIndex;
            this.Panel2.Controls.Clear();
            PictureBox pic = new PictureBox();
            pic.Size = new Size((int)(this.pageSize.Width * times), (int)(this.pageSize.Height * times));
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            //pic.MaximumSize = new Size(this.pageSize.Width, this.pageSize.Height);
            //pic.MinimumSize = new Size(this.pageSize.Width, this.pageSize.Height);
            if (Panel2.Width > pic.Width + 26)
            {
                pic.Left = (Panel2.Width - pic.Width) / 2;
            }
            else
            {
                pic.Left = 12;
            }
            pic.Top = 13 - this.Panel2.VerticalScroll.Value * pic.Height / (this.Panel2.VerticalScroll.Maximum - this.Panel2.VerticalScroll.Minimum);

            Bitmap img = (Bitmap)(((Image)arrPicture[this.cboPage.SelectedIndex]).Clone());
            Bitmap imgBackGround;
            if (this.cboPage.SelectedIndex == 0)
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
                    imgBackGround = new Bitmap(pageSize.Width, pageSize.Height);
                }
            }
            else if (currentPanel.打印背景 != null)
            {
                imgBackGround = currentPanel.打印背景.Clone() as Bitmap;
            }
            else
            {
                imgBackGround = new Bitmap(pageSize.Width, pageSize.Height);
            }
            Bitmap imgPrint = new Bitmap(pageSize.Width, pageSize.Height);

            Graphics grapPrint = Graphics.FromImage(imgPrint);
            grapPrint.Clear(Color.White);
            imgBackGround.MakeTransparent(Color.White);
            grapPrint.DrawImage(imgBackGround, new Point(0, 0));
            img.MakeTransparent(Color.White);
            grapPrint.DrawImage(img, new Point(0, 0));

            pic.Image = imgPrint;
            //pic.MouseDown += new MouseEventHandler(pic_MouseDown);
            //pic.MouseMove += new MouseEventHandler(pic_MouseMove);
            //pic.Dock = DockStyle.Top;
            pic.Anchor = AnchorStyles.None;
            pic.BackColor = Color.White;
            this.Panel2.Controls.Add(pic);
            this.Page_SelectedChanged();

            // 
            // frontPicture
            // 
            this.frontPicture = null;
            this.frontPicture = new PictureBox();
            this.frontPicture.Size = new Size(pic.Width, pic.Height);
            this.frontPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.frontPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.frontPicture.Location = new System.Drawing.Point(0, 0);
            this.frontPicture.Dock = DockStyle.Fill;
            this.frontPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_MouseMove);
            this.frontPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_MouseDown);
            this.frontPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);

            //Neusoft.HISFC.Management.EPR.SuperMark supermarkManager = new Neusoft.HISFC.Management.EPR.SuperMark();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = this.loader.CurrentLoader.dt.ID;
            obj.Name = (this.cboPage.SelectedIndex + 1).ToString();
            byte[] byImage = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSuperMarkImage(obj);

            Bitmap bmpSuperMark = new Bitmap(this.frontPicture.Width, this.frontPicture.Height);
            Graphics grapSuperMark = Graphics.FromImage(bmpSuperMark);
            if (byImage != null && byImage.Length > 0)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byImage);
                Image imgTemp = Image.FromStream(stream);
                grapSuperMark.DrawImage(imgTemp, new Point(0, 0));
            }
            this.SetBitmap(bmpSuperMark);
            this.frontPicture.Image = bmpSuperMark;
            pic.Controls.Add(this.frontPicture);

        }

        /// <summary>
        /// 选择页改变
        /// </summary>
        protected virtual void Page_SelectedChanged()
        {
        }

        /// <summary>
        /// 失去焦点事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            this.Size = this.MinimumSize;
            base.OnLostFocus(e);
        }

        /// <summary>
        /// 控件按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPrintPicture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.Panel2.Controls.Count > 0)
                {
                    Control pic = this.Panel2.Controls[0];
                    pic.Controls.Clear();
                }
            }
        }

        public event EventHandler refresh_Click;

        /// <summary>
        /// 刷新按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.refresh_Click != null)
            {
                this.refresh_Click(sender, e);
            }
            else
            {
                this.Refresh();
            }
        }

        /// <summary>
        /// 图片框鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void pic_MouseDown(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// 图片框鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void pic_MouseMove(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// 图片框鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void pic_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void cboTimes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.cboTimes.Text.LastIndexOf("%") == -1)
                {
                    this.cboTimes.Text += "%";
                }
                this.AdjustTimes();
            }
        }

        private void cboTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AdjustTimes();
        }

        #endregion "事件与事件处理函数"

        #region "方法"
        /// <summary>
        /// 调整显示比率
        /// </summary>
        private void AdjustTimes()
        {
            double decTime = 0;
            try
            {
                decTime = double.Parse(this.cboTimes.Text.TrimEnd('%'));
            }
            catch (Exception e) { }

            if (decTime != 0)
            {
                if (this.cboTimes.Text.LastIndexOf('%') != -1)
                {
                    decTime /= 100;
                }
                if (decTime > 5 || decTime < 1e-1)
                {
                    MessageBox.Show("数字必须介于10和500之间", "警告");
                    return;
                }
                Control picCurrent = this.Panel2.Controls[0];
                picCurrent.Size = new Size((int)(decTime * pageSize.Width), (int)(decTime * pageSize.Height));
                times = 1 / decTime;
                this.ucPrintPicture_Resize(null, null);
            }
        }

        /// <summary>
        /// 刷新控件方法
        /// </summary>
        public override void Refresh()
        {
            //Neusoft.HISFC.Management.EPR.Print printManager = new Neusoft.HISFC.Management.EPR.Print();
            currentPanel = loader.CurrntPanel as Neusoft.FrameWork.EPRControl.emrPanel;
            this.arrControls = this.SortControls(loader.CurrntPanel);
            this.cboPage.Items.Clear();
            TotalPage = 0;
            //Neusoft.HISFC.Components.EPR.Query.Function func = new Neusoft.HISFC.Components.EPR.Query.Function();
            arrSortedControls = new ArrayList();
            this.SetImage(this.printImage);
            this.Print();
            this.ucPrintPicture_Resize(this, new EventArgs());

            //this.Print();
        }

        /// <summary>
        /// 设置控件焦点方法
        /// </summary>
        /// <param name="ctr"></param>
        private void SetFocus(Control ctr)
        {
            if (ctr.Parent.GetType() != typeof(Form) && !ctr.Parent.GetType().IsSubclassOf(typeof(Form)))
            {
                SetFocus(ctr.Parent);
            }
            ctr.Focus();
        }

        /// <summary>
        /// 设置当前的ucLoader和当前的患者
        /// </summary>
        /// <param name="loader"></param>
        /// <param name="patient"></param>
        public void SetLoader(TemplateDesignerApplication.ucDataFileLoader loader, Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.loader = loader;
            this.patient = patient;
        }


        /// <summary>
        /// 根据X和Y排序Control
        /// </summary>
        /// <param name="panel"></param>
        /// <returns>ArrayList：ArrayList的集合，子ArrayList里面是Control</returns>
        private ArrayList SortControls(Control panel)
        {
            ArrayList arrControls = new ArrayList();
            bool isInsert = false;
            foreach (Control ctrCurrent in panel.Controls)
            {
                isInsert = false;
                //如果没有，则添加一行，把ctrCurrent放到这一行
                if (arrControls.Count == 0)
                {
                    ArrayList arrNewRow = new ArrayList();
                    arrNewRow.Add(ctrCurrent);
                    arrControls.Add(arrNewRow);
                    isInsert = true;
                }
                //如果有则按顺序放到ArrayList里面
                else
                {
                    for (int i = arrControls.Count - 1; i >= 0; i--) //倒序查找每一行
                    {
                        ArrayList arrRowi = (ArrayList)arrControls[i];
                        Control ctri0 = (Control)arrRowi[0];
                        if (ctrCurrent.Top > ctri0.Top + 8) //在i行之下，则在i行后面插入一行，把ctrCurrent放到这一行
                        {
                            ArrayList arrNewRow = new ArrayList();
                            arrNewRow.Add(ctrCurrent);
                            arrControls.Insert(i + 1, arrNewRow);
                            isInsert = true;
                            break;
                        }
                        else if (ctrCurrent.Top >= ctri0.Top - 8 && ctrCurrent.Top <= ctri0.Top + 8) //在同一行
                        {
                            for (int j = arrRowi.Count - 1; j >= 0; j--) //倒序查找每一个控件
                            {
                                Control ctrij = (Control)arrRowi[j];
                                if (ctrCurrent.Left > ctrij.Left) //在j控件之后
                                {
                                    arrRowi.Insert(j + 1, ctrCurrent); //将控件插入j控件之后
                                    isInsert = true;
                                    break;
                                }
                            }
                            if (!isInsert)  //在所有控件之前
                            {
                                arrRowi.Insert(0, ctrCurrent); //放到第一个位置
                                isInsert = true;
                            }
                            break;
                        }
                    }
                    if (!isInsert)   //在所有行之前
                    {
                        ArrayList arrNewRow = new ArrayList();
                        arrNewRow.Add(ctrCurrent);
                        arrControls.Insert(0, arrNewRow);
                    }
                }
            }
            return arrControls;
        }

        /// <summary>
        /// 打印方法
        /// </summary>
        private void Print()
        {
            if (arrControls == null || arrControls.Count == 0)
            {
                return;
            }

            //初始化
            arrSortedControls = new ArrayList();
            arrPicture = new ArrayList();
            //checkprint = 0;

            checkprints = new int[20];
            yEnds = new int[20];
            tops = new int[20];
            isPrinteds = new bool[20];
            //index = 0;
            row = 0;
            top = 0;

            Image img = new Bitmap(this.pageSize.Width, this.pageSize.Height);
            Graphics grap = Graphics.FromImage(img);

            //打印页设置
            PageSettings setting = new PageSettings();
            setting.Color = true;
            setting.Landscape = false;
            setting.Margins = new Margins(this.pageSize.Left, this.pageSize.Top, 0, 40);
            setting.PaperSize = new PaperSize("A4", this.pageSize.Width, this.pageSize.Height);
            System.Drawing.Printing.PrintPageEventArgs e = new System.Drawing.Printing.PrintPageEventArgs(
                grap, new Rectangle(this.pageSize.Left, this.pageSize.Top, this.pageSize.Width - this.pageSize.Left, this.pageSize.Height - this.pageSize.Top - 40), new Rectangle(0, 0, this.pageSize.Width, this.pageSize.Height), setting);

            e.HasMorePages = true;


            //开始打印
            while (e.HasMorePages)
            {
                e.HasMorePages = false;
                if (currentPanel.自动分页)
                {
                    ContinuePrintPage(e);
                }
                else
                {
                    PrintPage(e);
                }
            }

            //设置页码
            //this.cboPage.Items.Clear();
            for (int i = 0; i < TotalPage; i++)
            {
                this.cboPage.Items.Add((i + startPage).ToString());
            }
            cboPage.SelectedIndexChanged -= new EventHandler(this.ComboBox1_SelectedIndexChanged);
            cboPage.SelectedIndexChanged += new EventHandler(this.ComboBox1_SelectedIndexChanged);
            if (this.cboPage.Items.Count > 0)
            {
                this.cboPage.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 打印每一页
        /// </summary>
        /// <param name="e"></param>
        private void PrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image img = new Bitmap(e.PageBounds.Width, e.PageBounds.Height);
            Graphics grap = Graphics.FromImage(img);
            grap.Clear(Color.White);

            //页眉
            if ((TotalPage != 0 && currentPanel.打印页眉) || (TotalPage == 0 && currentPanel.首页打印页眉))
            {
                grap.DrawString("姓名: " + patient.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - 30);
                grap.DrawString("科别: " + patient.PVisit.PatientLocation.Dept.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 150, e.MarginBounds.Top - 30);
                grap.DrawString("病区: " + patient.PVisit.PatientLocation.NurseCell.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 300, e.MarginBounds.Top - 30);
                grap.DrawString("床号: " + patient.PVisit.PatientLocation.Bed.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 450, e.MarginBounds.Top - 30);
                grap.DrawString("住院号: " + patient.PID.ID, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 550, e.MarginBounds.Top - 30);
                grap.DrawLine(new Pen(Color.Black, 2), e.MarginBounds.Left, e.MarginBounds.Top - 8, e.MarginBounds.Right, e.MarginBounds.Top - 8);
            }

            //页脚
            if (currentPanel.打印页脚)
            {
                grap.DrawString("第 " + (TotalPage + startPage).ToString() + " 页", new Font("宋体", 12), Brushes.Black, e.PageBounds.Width / 2 - 40, e.MarginBounds.Bottom + 4);
            }

            TotalPage += 1;
            top = 0;
            tops = new int[20];
            //bool isPrinted = false;

            //打印控件
            for (int i = row; i < arrControls.Count; i++)
            {
                //当前行
                #region 处理
                ArrayList arrRow = (ArrayList)arrControls[i];
                //遍历行的每一个控件
                for (int j = 0; j < arrRow.Count; j++)
                {
                    SortedControl sortedCtr = CalPage(e, grap, arrRow, j);
                    if (sortedCtr != null && sortedCtr.Rect != null && sortedCtr.Rect != new Rectangle(0, 0, 0, 0))
                    {
                        arrSortedControls.Add(sortedCtr);
                    }
                }
                #endregion
                // 如果当前的行的RichTextBox都没有超过行数，找到要打印的位置
                if (!e.HasMorePages)
                {
                    for (int j = 0; j < arrRow.Count; j++)
                    {
                        if (tops[j] > top)
                        {
                            top = tops[j];
                        }
                    }
                    checkprints = new int[20];
                    yEnds = new int[20];
                    tops = new int[20];
                    row = i + 1;
                    isPrinteds = new bool[20];
                }
                //否则，退出
                else
                {
                    top = 0;
                    //arrPicture.Add(img);
                    //img.Save("d:\\" + this.TotalPage.ToString() + "1.bmp");
                    break;
                }
            }
            arrPicture.Add(img);
            //img.Save("d:\\" + this.TotalPage.ToString() + "1.bmp");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="grap"></param>
        /// <param name="arrRow"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private SortedControl CalPage(System.Drawing.Printing.PrintPageEventArgs e, Graphics grap, ArrayList arrRow, int j)
        {
            Control ctr = (Control)arrRow[j];

            Control printControl = GetPrintControl(ctr);
            if (printControl != null) ctr = printControl;

            SortedControl sortedCtr = new SortedControl();
            sortedCtr.Name = ctr.Name;
            sortedCtr.Location = ctr.Location;
            sortedCtr.StartPosition = checkprints[j];
            sortedCtr.Page = TotalPage;
            


            if (ctr.GetType() == typeof(RichTextBox) || ctr.GetType().IsSubclassOf(typeof(RichTextBox)))
            {
                CalRichTextBox(e, grap, j, ctr, sortedCtr);
            }
            else if (ctr.GetType() == typeof(Neusoft.HISFC.Components.EPR.Controls.ucEMRInput) || ctr.GetType().IsSubclassOf(typeof(Neusoft.HISFC.Components.EPR.Controls.ucEMRInput)))
            {

                CalEMRInput(e, grap, j, ctr, sortedCtr);
            }else if(ctr.GetType()== typeof(FarPoint.Win.Spread.FpSpread) || ctr.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
            {
                #region farpoint
                FarPoint.Win.Spread.FpSpread t = ctr as FarPoint.Win.Spread.FpSpread;
                if (checkprints[j] <= t.ActiveSheet.NonEmptyRowCount)
                {
                    Rectangle rect = new Rectangle(ctr.Left + e.MarginBounds.Left, top + e.MarginBounds.Top, ctr.Width, e.MarginBounds.Height - top);
                    FarPoint.Win.Spread.PrintInfo printinfo = new FarPoint.Win.Spread.PrintInfo();
                    for (int iSheet = 0; iSheet < t.Sheets.Count; iSheet++)
                    {
                        if (this.ControlBorder == Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None)
                            printinfo.ShowBorder = false;
                        printinfo.ShowRowHeaders = t.Sheets[iSheet].RowHeader.Visible;
                        printinfo.ShowColumnHeaders = t.Sheets[iSheet].ColumnHeader.Visible;
                        printinfo.PageStart = 0;
                        t.Sheets[iSheet].PrintInfo = printinfo;
                    }
                    int iCount = t.GetOwnerPrintPageCount(grap, rect, 0);

                    //if (addpage == 0)
                    //{
                    //    addpage = 1;//开始页码
                    //}
                    //if (addpage < iCount)
                    //{
                        //e.HasMorePages = true;
                        t.OwnerPrintDraw(grap, rect, t.ActiveSheetIndex, 1);
                        int[] intRows = t.GetOwnerPrintRowPageBreaks(grap, rect, t.ActiveSheetIndex, true);
                        if (intRows == null || intRows.Length == 0)
                        {
                            checkprints[j] = t.ActiveSheet.NonEmptyRowCount + 1;
                        }
                        else
                        {
                            checkprints[j] = intRows[0];
                        }
                        //addpage++;
                        if (checkprints[j] < t.ActiveSheet.NonEmptyRowCount)
                        {
                            t.ActiveSheet.Rows[0, checkprints[j] - 1].Visible = false;
                            e.HasMorePages = true;
                        }
                        else
                        {
                            t.ActiveSheet.Rows[0, t.ActiveSheet.NonEmptyRowCount - 1].Visible = true;
                        }
                    //}
                    //else if (addpage == iCount)
                    //{
                    //    t.OwnerPrintDraw(grap, rect, t.ActiveSheetIndex, addpage);
                    //    t.ActiveSheet.Rows[0, t.ActiveSheet.NonEmptyRowCount].Visible = true;
                    //    addpage++;
                    //}
                }
                else
                {
                    //t.ActiveSheet.Rows[0, t.ActiveSheet.NonEmptyRowCount].Visible = true;
                }
                sortedCtr.Rect = new Rectangle(sortedCtr.Rect.X, sortedCtr.Rect.Y, sortedCtr.Rect.Width, Height); // Height = t.Height;
                tops[j] = top + t.Height;

                #endregion
            }
            //else if (ctr.GetType() == typeof(UFC.NurseTend.Controls.ucNurseRecordGroup) || ctr.GetType().IsSubclassOf(typeof(UFC.NurseTend.Controls.ucNurseRecordGroup)))
            //{
            //    CalNurseTendRecord(e, grap, j, ctr, sortedCtr);
            //}
            //else if (ctr.GetType() == typeof(UFC.NurseTend.Controls.ucTemperatureNew) || ctr.GetType().IsSubclassOf(typeof(UFC.NurseTend.Controls.ucTemperatureNew)))
            //{
            //    CalTemperatureNew(e, grap, j, ctr, sortedCtr);
            //}
            else
            {
                //没有打印
                if (!isPrinteds[j])
                {
                    if (ctr.Height + top > e.MarginBounds.Height && top != 0)
                    {
                        e.HasMorePages = true;
                        tops[j] = 0;
                    }
                    else
                    {
                        this.DrawForm(e, grap, new Point(ctr.Left, 0), ctr);
                        tops[j] = top + ctr.Height + 4;
                        isPrinteds[j] = true;
                        if (ctr.CanSelect)
                        {
                            sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((top) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
                        }
                    }
                }
            }
            return sortedCtr;
        }

        private void CalEMRInput(System.Drawing.Printing.PrintPageEventArgs e, Graphics grap, int j, Control ctr, SortedControl sortedCtr)
        {
            Neusoft.HISFC.Components.EPR.Controls.ucEMRInput ctrCurrent =
                (Neusoft.HISFC.Components.EPR.Controls.ucEMRInput)ctr;
            //如果打印完成，则不打印
            if (checkprints[j] >= ctrCurrent.GetTextLength())
            {
                tops[j] = 0;
                //continue;
            }
            //否则，接着打印这个控件
            else
            {
                rect = new Rectangle(ctrCurrent.Left, top, ctrCurrent.Width, 0);
                if (checkprints[j] > 0)
                {
                    yEnds[j] = ctrCurrent.GetLineFromCharIndex(checkprints[j] - 1);
                }
                else
                {
                    yEnds[j] = 0;
                }
                ctrCurrent.print(checkprints[j], ctrCurrent.GetTextLength(), e, rect, grap);
                checkprints[j] = ctrCurrent.print(checkprints[j], ctrCurrent.GetTextLength(), e, rect);
                //if (checkprint > textPos) {
                //    startPage += 1
                //}

                //look for more pages 
                // 如果当前的RichTextBox超过了行数，则在下一页接着打印
                if (checkprints[j] < ctrCurrent.GetTextLength())
                {
                    e.HasMorePages = true;
                }
                // 如果当前的RichTextBox没有超过行数，计算下一行的位置
                int temp = ctrCurrent.GetLineFromCharIndex(checkprints[j]) - yEnds[j];
                //Font ft = ctrCurrent.Font;
                //double space = 0;
                //int asc = 0;
                //space = ft.FontFamily.GetLineSpacing(System.Drawing.FontStyle.Regular);
                //asc = ft.FontFamily.GetEmHeight(System.Drawing.FontStyle.Regular);
                //temp = (int)(ft.Height * space * temp * 1.000 / asc);
                //tops[j] = top + temp;
                //checkprint = 0;

                //只有一行，取默认行高
                if (temp == 0)
                {
                    temp = (int)e.Graphics.MeasureString("李", ctrCurrent.Font).Height + 2;
                }
                //从头开始，比如0-30行，共有31行，只取了30行，需要加上默认行高
                else if (yEnds[j] == 0)
                {
                    temp = (int)((ctrCurrent.GetPositionFromCharIndex(checkprints[j]).Y - ctrCurrent.GetPositionFromCharIndex(ctrCurrent.GetFirstCharIndexFromLine(yEnds[j])).Y) * 1.000) + (int)e.Graphics.MeasureString("李", ctrCurrent.Font).Height + 2;
                }
                //继续打印，例如从30-60，实际从31行打印，共30行，不用加默认行高
                else
                {
                    temp = (int)((ctrCurrent.GetPositionFromCharIndex(checkprints[j]).Y - ctrCurrent.GetPositionFromCharIndex(ctrCurrent.GetFirstCharIndexFromLine(yEnds[j])).Y) * 1.000);
                }
                tops[j] = top + temp;
                if (tops[j] + 20 > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                }
                sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((top) / 1.00) + e.MarginBounds.Top, ctr.Width, temp);
                sortedCtr.EndPosition = checkprints[j];
            }
        }

        private void CalRichTextBox(System.Drawing.Printing.PrintPageEventArgs e, Graphics grap, int j, Control ctr, SortedControl sortedCtr)
        {
            Neusoft.FrameWork.EPRControl.emrMultiLineTextBox ctrCurrent =
                (Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)ctr;
            //如果打印完成，则不打印
            if (checkprints[j] >= ctrCurrent.TextLength)
            {
                tops[j] = 0;
                //continue;
            }
            //否则，接着打印这个控件
            else
            {
                rect = new Rectangle(ctrCurrent.Left, top, ctrCurrent.Width, 0);
                if (checkprints[j] > 0)
                {
                    yEnds[j] = ctrCurrent.GetLineFromCharIndex(checkprints[j] - 1);
                }
                else
                {
                    yEnds[j] = 0;
                }
                ctrCurrent.print(checkprints[j], ctrCurrent.TextLength, e, rect, grap);
                checkprints[j] = ctrCurrent.print(checkprints[j], ctrCurrent.TextLength, e, rect);
                //if (checkprint > textPos) {
                //    startPage += 1
                //}

                //look for more pages 
                // 如果当前的RichTextBox超过了行数，则在下一页接着打印
                if (checkprints[j] < ctrCurrent.TextLength)
                {
                    e.HasMorePages = true;
                }
                // 如果当前的RichTextBox没有超过行数，计算下一行的位置
                    int temp = ctrCurrent.GetLineFromCharIndex(checkprints[j]) - yEnds[j];
                    //Font ft = ctrCurrent.Font;
                    //double space = 0;
                    //int asc = 0;
                    //space = ft.FontFamily.GetLineSpacing(System.Drawing.FontStyle.Regular);
                    //asc = ft.FontFamily.GetEmHeight(System.Drawing.FontStyle.Regular);
                    //temp = (int)(ft.Height * space * temp * 1.000 / asc);

                    //只有一行，取默认行高
                    if (temp == 0)
                    {
                        temp = (int)e.Graphics.MeasureString("李", ctrCurrent.Font).Height + 2;
                    }
                    //从头开始，比如0-30行，共有31行，只取了30行，需要加上默认行高
                    else if (yEnds[j] == 0)
                    {
                        temp = (int)((ctrCurrent.GetPositionFromCharIndex(checkprints[j]).Y - ctrCurrent.GetPositionFromCharIndex(ctrCurrent.GetFirstCharIndexFromLine(yEnds[j])).Y) * 1.000) + (int)e.Graphics.MeasureString("李", ctrCurrent.Font).Height + 2;
                    }
                    //继续打印，例如从30-60，实际从31行打印，共30行，不用加默认行高
                    else
                    {
                        temp = (int)((ctrCurrent.GetPositionFromCharIndex(checkprints[j]).Y - ctrCurrent.GetPositionFromCharIndex(ctrCurrent.GetFirstCharIndexFromLine(yEnds[j])).Y) * 1.000);
                    }

                    tops[j] = top + temp;
                    if (tops[j] + 20 > e.MarginBounds.Height)
                    {
                        e.HasMorePages = true;
                    }
                    //checkprint = 0;
                    if (sortedCtr != null)
                    {
                        sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((top) / 1.00) + e.MarginBounds.Top, ctr.Width, temp);
                        sortedCtr.EndPosition = checkprints[j];
                    }
            }
        }
        private void CalTemperatureNew(System.Drawing.Printing.PrintPageEventArgs e, Graphics grap, int j, Control ctr, SortedControl sortedCtr)
        {
            //UFC.NurseTend.Controls.ucTemperatureNew ctrCurrent =
            //    (UFC.NurseTend.Controls.ucTemperatureNew)ctr;
            //ctrCurrent.patient = this.patient;
            ////如果打印完成，则不打印
            //if (checkprints[j] == 0 || ctrCurrent.In_Date.AddDays(checkprints[j] * 7) <= ctrCurrent.EndDate)
            //{
            //    if (currentPanel.自动分页)
            //    {
            //        checkprints[j] = ctrCurrent.continuePrint(checkprints[j], e, rect, grap);
            //    }
            //    else
            //    {
            //        checkprints[j] = ctrCurrent.print(checkprints[j], e, rect, grap);
            //    }
            //    if (ctrCurrent.In_Date.AddDays(checkprints[j] * 7) <= ctrCurrent.EndDate)
            //    {
            //        e.HasMorePages = true;
            //    }
            //    sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((top) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //    sortedCtr.EndPosition = checkprints[j];

            //}
            //else
            //{
            //    tops[j] = 0;
            //    //continue;
            //}
        }

        private void CalNurseTendRecord(System.Drawing.Printing.PrintPageEventArgs e, Graphics grap, int j, Control ctr, SortedControl sortedCtr)
        {
    //        UFC.NurseTend.Controls.ucNurseRecordGroup ctrCurrent =
    //(UFC.NurseTend.Controls.ucNurseRecordGroup)ctr;
    //        if (checkprints[j] < ctrCurrent.arrRecords.Count)
    //        {
    //                checkprints[j] = ctrCurrent.Print(checkprints[j], e, rect, grap);
    //            if (checkprints[j] < ctrCurrent.arrRecords.Count)
    //            {
    //                e.HasMorePages = true;
    //            }
    //            sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((top) / 1.00) + e.MarginBounds.Top, ctr.Width, e.MarginBounds.Bottom - ctr.Top);
    //            sortedCtr.EndPosition = checkprints[j];


    //        }
    //        else
    //        {
    //            tops[j] = 0;
    //            //continue;
    //        }
        }
        /// <summary>
        /// 打印每一页
        /// </summary>
        /// <param name="e"></param>
        private void ContinuePrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image img = new Bitmap(e.PageBounds.Width, e.PageBounds.Height);
            Graphics grap = Graphics.FromImage(img);
            grap.Clear(Color.White);

            //页眉
            if ((TotalPage != 0 && currentPanel.打印页眉) || (TotalPage != 0 && currentPanel.首页打印页眉))
            {
                grap.DrawString("姓名: " + patient.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - 30);
                grap.DrawString("科别: " + patient.PVisit.PatientLocation.Dept.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 150, e.MarginBounds.Top - 30);
                grap.DrawString("病区: " + patient.PVisit.PatientLocation.NurseCell.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 300, e.MarginBounds.Top - 30);
                grap.DrawString("床号: " + patient.PVisit.PatientLocation.Bed.Name, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 450, e.MarginBounds.Top - 30);
                grap.DrawString("住院号: " + patient.PID.ID, new Font("宋体", 12, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + 550, e.MarginBounds.Top - 30);
                grap.DrawLine(new Pen(Color.Black, 2), e.MarginBounds.Left, e.MarginBounds.Top - 8, e.MarginBounds.Right, e.MarginBounds.Top - 8);
            }

            //页脚
            if (currentPanel.打印页脚)
            {
                grap.DrawString("第 " + (TotalPage + startPage).ToString() + " 页", new Font("宋体", 12), Brushes.Black, e.PageBounds.Width / 2 - 40, e.MarginBounds.Bottom + 4);
            }

            TotalPage += 1;
            top = 0;
            //bool isPrinted = false;

            //打印控件
            for (int i = 0; i < arrControls.Count; i++)
            {
                //当前行
                ArrayList arrRow = (ArrayList)arrControls[i];
                //遍历行的每一个控件
                for (int j = 0; j < arrRow.Count; j++)
                {
                    Control ctr = (Control)arrRow[j];
                    rect = new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height);

                    SortedControl sortedCtr = new SortedControl();

                    sortedCtr.Name = ctr.Name;
                    sortedCtr.Location = ctr.Location;
                    sortedCtr.StartPosition = ctr.Top;
                    sortedCtr.Page = TotalPage;

                    Control printControl = GetPrintControl(ctr);

                    if (printControl != null)
                    {


                        printControl.Left = ctr.Left;
                        printControl.Top = ctr.Top;
                        printControl.Width = ctr.Width;
                        printControl.Height = ctr.Height;
                        ctr = printControl;
                    }
                    Neusoft.FrameWork.EPRControl.IControlPrintable ctrToPrint = ctr as Neusoft.FrameWork.EPRControl.IControlPrintable;
                    if (ctrToPrint != null)
                    {
                        ctrToPrint.continuePrint(e, rect, grap);
                        if (ctrToPrint.arrSortedControl() != null)
                        {
                            foreach(SortedControl tempCtr in ctrToPrint.arrSortedControl())
                            {
                                arrSortedControls.Add(tempCtr);
                            }
                        }
                    }

                    //多行文本框
                    #region emrMultiLineTextBox
                    else if (ctr.GetType() == typeof(Neusoft.FrameWork.EPRControl.emrMultiLineTextBox) || ctr.GetType().IsSubclassOf(typeof(Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)))
                    {
                        Neusoft.FrameWork.EPRControl.emrMultiLineTextBox ctrCurrent =
                            (Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)ctr;
                        //如果打印完成，则不打印
                        if (checkprints[j] >= ctrCurrent.TextLength)
                        {
                            continue;
                        }
                        //否则，接着打印这个控件
                        else
                        {
                            rect = new Rectangle(ctrCurrent.Left, ctrCurrent.Top, ctrCurrent.Width, ctrCurrent.Height);
                            checkprints[j] = ctrCurrent.print(checkprints[j], ctrCurrent.TextLength, e, rect, grap);

                            //look for more pages 
                            // 如果当前的RichTextBox超过了行数，则在下一页接着打印
                            if (checkprints[j] < ctrCurrent.TextLength)
                            {
                                e.HasMorePages = true;
                            }
                            sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((ctrCurrent.Top) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
                            sortedCtr.EndPosition = checkprints[j];
                            //checkprint = 0;
                        }
                    }
                    #endregion emrMultiLineTextBox

                    //多行文本框
                    #region Farpoint
                    else if (ctr.GetType() == typeof(FarPoint.Win.Spread.FpSpread) || ctr.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
                    {
                        FarPoint.Win.Spread.FpSpread ctrCurrent =
                            (FarPoint.Win.Spread.FpSpread)ctr;
                        //如果打印完成，则不打印
                        //if (checkprints[j] >= addpage)
                        //{
                        //    continue;
                        //}
                        //否则，接着打印这个控件
                        //else
                        //{
                            rect = new Rectangle(ctrCurrent.Left, ctrCurrent.Top, ctrCurrent.Width, ctrCurrent.Height);
                            DrawFarpoint(grap, ctrCurrent, ctr.Left + e.MarginBounds.Left, ctr.Top + e.MarginBounds.Top, ctr.Width, ctr.Height,e);
                            
                            //if (checkprint > textPos) {
                            //    startPage += 1
                            //}

                            //look for more pages 
                            // 如果当前的RichTextBox超过了行数，则在下一页接着打印
                            //if (checkprints[j] < ctrCurrent.TextLength)
                            //{
                            //    e.HasMorePages = true;
                            //}
                            sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((ctrCurrent.Top) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
                            //sortedCtr.EndPosition = checkprints[j];
                            //checkprint = 0;
                        //}
                    }
                    #endregion emrMultiLineTextBox

                    //SnoMed输入框
                    #region ucEMRInput
                    else if (ctr.GetType() == typeof(Neusoft.HISFC.Components.EPR.Controls.ucEMRInput) || ctr.GetType().IsSubclassOf(typeof(Neusoft.HISFC.Components.EPR.Controls.ucEMRInput)))
                    {
                        Neusoft.HISFC.Components.EPR.Controls.ucEMRInput ctrCurrent =
                            (Neusoft.HISFC.Components.EPR.Controls.ucEMRInput)ctr;
                        //如果打印完成，则不打印
                        if (checkprints[j] >= ctrCurrent.GetTextLength())
                        {
                            continue;
                        }
                        //否则，接着打印这个控件
                        else
                        {
                            rect = new Rectangle(ctrCurrent.Left, ctrCurrent.Top, ctrCurrent.Width, ctrCurrent.Height);
                            checkprints[j] = ctrCurrent.print(checkprints[j], ctrCurrent.GetTextLength(), e, rect, grap);

                            //look for more pages 
                            // 如果当前的RichTextBox超过了行数，则在下一页接着打印
                            if (checkprints[j] < ctrCurrent.GetTextLength())
                            {
                                e.HasMorePages = true;
                            }
                            // 如果当前的RichTextBox没有超过行数，计算下一行的位置
                            sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((ctrCurrent.Top) / 1.00) + e.MarginBounds.Top, ctr.Width, ctrCurrent.Height);
                            sortedCtr.EndPosition = checkprints[j];
                        }
                    }
                    #endregion ucEMRInput
                    //其他控件
                    else
                    {
                        this.DrawForm(e, grap, new Point(ctr.Left, ctr.Top), ctr);
                        if (ctr.CanSelect)
                        {
                            sortedCtr.Rect = new Rectangle(ctr.Left + e.MarginBounds.Left, (int)((ctr.Top) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
                        }
                    }
                    
                    if (sortedCtr.Rect != null && sortedCtr.Rect != new Rectangle(0, 0, 0, 0))
                    {
                        arrSortedControls.Add(sortedCtr);
                    }
                }
                // 如果当前的行的RichTextBox都没有超过行数，找到要打印的位置
                //arrPicture.Add(img);
               
            }
            arrPicture.Add(img);
            //string strIsSavePicture = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetControlArgument("EPR002");
            //if (strIsSavePicture == "1")
            //{
            //    Neusoft.HISFC.Models.EPR.EPRPrintPage printpage = new EPRPrintPage();
            //    printpage.SortedControls = arrSortedControls;
            //    printpage.StartRow = 0;
            //    printpage.Page = TotalPage;
            //    printpage.ID = this.loader.CurrentLoader.dt.ID;
            //    printpage.Name = this.loader.CurrentLoader.dt.Name;
            //    printpage.Memo = this.patient.ID;
            //    printpage.BeginDate = System.DateTime.MinValue;
            //    printpage.EndDate = System.DateTime.MaxValue;
            //    printpage.Img = img;
            //    printpage.PatientNo = this.patient.ID;

            //    string fileName = Neusoft.FrameWork.WinForms.Classes.Function.GetTempFileName() + ".bmp";
            //    img.Save(fileName);
            //    System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
            //    byte[] byteimg = new byte[stream.Length];

            //    stream.Read(byteimg, 0, (int)stream.Length);
            //    stream.Close();
            //    try
            //    {
            //        System.IO.File.Delete(fileName);
            //    }
            //    catch
            //    {
            //    }
            //    Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.SetPrintPage(printpage, byteimg);
            //}
        }

        /// <summary>
        /// 打印容器控件
        /// </summary>
        /// <param name="e"></param>
        /// <param name="grap"></param>
        /// <param name="pointForm"></param>
        /// <param name="form"></param>
        private void DrawForm(PrintPageEventArgs e, Graphics grap, Point pointForm, Control form)
        {
            this.DrawControl(e, grap, pointForm, form);
            foreach (Control c in form.Controls)
            {
                Point pointCtr = new Point(pointForm.X + c.Location.X, pointForm.Y + c.Location.Y);
                if (c != null && c.Visible)
                {
                    this.DrawForm(e, grap, pointCtr, c);
                }
            }
        }
        /// <summary>
        /// 打印控件对照
        /// </summary>
        private Neusoft.FrameWork.WinForms.Classes.PrintControlCompare printControlCompare = new Neusoft.FrameWork.WinForms.Classes.PrintControlCompare();

        /// <summary>
        /// 设置控件对照
        /// </summary>
        /// <param name="controlCompare"></param>
        public void SetControlCompare(Neusoft.FrameWork.WinForms.Classes.PrintControlCompare controlCompare)
        {
            this.printControlCompare = controlCompare;
        }

        /// <summary>
        /// 获得打印接口的控件
        /// </summary>
        /// <param name="ctr"></param>
        private System.Windows.Forms.Control GetPrintControl( Control ctr)
        {
            Neusoft.FrameWork.EPRControl.IControlPrintable print = ctr as Neusoft.FrameWork.EPRControl.IControlPrintable;
            
            if (print != null)
            {
                return  print.PrintControl();
            }
            return null;
        }

        private void DrawControl(PrintPageEventArgs e, Graphics grap, Point pointCtr, Control ctr)
        {

            //控件不显示不画
            if (ctr.Visible == false) return;

            Control printControl = GetPrintControl(ctr);
            if (printControl != null) ctr = printControl;

            string strType = ctr.GetType().ToString().Substring(ctr.GetType().ToString().LastIndexOf(".") + 1);

            //是表格不画子控件
            //判断父级控件类型是不是表格，是表格不画里面的线
            if (ctr.Parent != null)
            {
                string parentType = ctr.Parent.GetType().ToString().Substring(ctr.Parent.GetType().ToString().LastIndexOf(".") + 1);

                if (this.printControlCompare != null && this.printControlCompare.Controls.ContainsKey(parentType))
                {
                    parentType = this.printControlCompare.Controls[parentType].ToString();
                }

                if (parentType == "Grid") return;
            }

            if (this.printControlCompare != null && this.printControlCompare.Controls.ContainsKey(strType))
            {
                strType = this.printControlCompare.Controls[strType].ToString();
            }
           
            if (ctr.Tag != null && ctr.Tag.ToString() == "EMRGRIDLINE") return;

           

            if (strType == "Label")
            {
                Label t = ctr as Label;

                if (t.BorderStyle == BorderStyle.FixedSingle)
                {
                        ControlPaint.DrawBorder(grap, new Rectangle(pointCtr.X + e.MarginBounds.Left + 10, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top - 8, (int)grap.MeasureString(ctr.Text, ctr.Font).Width, (int)grap.MeasureString(ctr.Text, ctr.Font).Height),Color.Black,ButtonBorderStyle.Solid);   
                        //pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height), Color.Black, ButtonBorderStyle.Solid);                   
                }
                else
                {
                   
                }
                grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), new Point(pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top));



            }
            else if (strType == "CheckBox")
            {
                CheckBox t = ctr as CheckBox;
                if (t.Checked)
                {
                    grap.DrawImage(gCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
                }
                else
                {
                    grap.DrawImage(gUnCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
                }
                grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left + gCheked.Width, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());

            }
            else if (strType == "RadioButton")
            {
                RadioButton t = ctr as RadioButton;
                if (t.Checked)
                {
                    grap.DrawImage(gRadioCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
                }
                else
                {
                    grap.DrawImage(gRadioUnCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
                }
                grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left + gCheked.Width, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());
    
            }
            else if (strType == "GroupBox")
            {
                ControlPaint.DrawBorder(grap, new Rectangle(pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height), Color.Black, ButtonBorderStyle.Solid);
                grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left + 10, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top - 8, grap.MeasureString(ctr.Text, ctr.Font).Width, grap.MeasureString(ctr.Text, ctr.Font).Height);
                grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left + 10, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top - 8, new StringFormat());
            }
            else if (strType == "PictureBox")
            {
                PictureBox t = ctr as PictureBox;
                Image m = null;
                try
                {
                    m = t.Image.Clone() as Image;
                    grap.DrawImage(m, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
                }
                catch { }
            }
            else if (strType == "Panel")
            {
                 grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            }
             
            else if (strType == "TabPage" || strType == "TabControl")
            {

            }
            else if (strType == "emrLine")
            {
                grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);

            }
            else if (strType == "emrMultiLineTextBox")
            {
                Neusoft.FrameWork.EPRControl.emrMultiLineTextBox ctrCurrent =
                    (Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)ctr;
                rect = new Rectangle(pointCtr.X, top + pointCtr.Y, ctrCurrent.Width, 0);
                ctrCurrent.print(0, ctrCurrent.TextLength, e, rect, grap);
            }
            else if (strType == "FpSpread")
            {
                //DrawFarpoint(grap, ctr, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);

            }
            else if (strType.IndexOf("SpreadView") >= 0 || strType == "HScrollBar" || strType == "VScrollBar" || strType.IndexOf("ScrollBar") >= 0)
            {

            }
            else if (strType == "DataGrid")//strType.IndexOf("DataGrid")>=0)//DataGrid
            {
               

            }
            else if (strType == "DateTimePicker")
            {
               //日期，属于输入控件
                try
                {
                    grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
                    if (((DateTimePicker)ctr).Value == DateTime.MinValue)
                    {
                        grap.DrawString("00-00-00", ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());
                    }
                    else
                    {
                        grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());
                    }
                }
                catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }   
            }
            else if (strType == "Button")//不打印按钮
            {
            }
            else if (strType == ("Grid")) //自定义表格
            {
                DrawGrid(grap,ctr,pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            }
            else if (strType == "Form")//不打印窗口
            {

            }
            //FarPoint:采用FarPoint的打印
            else if (ctr.GetType() == typeof(FarPoint.Win.Spread.FpSpread) || ctr.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
            {
                DrawFarpoint(grap, ctr, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height,e);

            }
            else
            {
                if (ctr.Text != "")
                {
                    grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
                    if (ctr.Text != "")
                    {
                        grap.DrawString(ctr.Text, AutoFont(ctr, grap), new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());//2+pointParent.X + e.MarginBounds.Left+(int)pBlankMargin.X,3+allTop+ctr.Height /2 -grap.MeasureString("李",ctr.Font).Height/2+(int)pBlankMargin.Y		break;
                    }
                }

            }
            #region old
            ////Label:打印文本，格式采用控件原来的格式
            //if (ctr.GetType() == typeof(Label) || ctr.GetType().IsSubclassOf(typeof(Label)))
            //{
            //    //e.Graphics.DrawString(ctr.Text, ctr.Font, Brushes.Black, new Point(pointParent.X + e.MarginBounds.Left, (top + pointParent.Y) + e.MarginBounds.Top));
            //    grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), new Point(pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top));
            //}
            ////TextBox:打印文本，格式采用控件原来的格式
            //else if (ctr.GetType() == typeof(TextBox) || ctr.GetType().IsSubclassOf(typeof(TextBox)))
            //{
            //    //e.Graphics.DrawString(ctr.Text, ctr.Font, Brushes.Black, new Point(pointParent.X + e.MarginBounds.Left, (top + pointParent.Y) + e.MarginBounds.Top));
            //    grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), new Point(pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top));
            //}
            ////else if (ctr.GetType() == typeof(PictureBox) || ctr.GetType().IsSubclassOf(typeof(PictureBox)))
            ////{
            ////    //e.Graphics.DrawImage(((PictureBox)ctr).Image, new Point(pointParent.X + e.MarginBounds.Left, (top + pointParent.Y) + e.MarginBounds.Top));
            ////    grap.DrawImage(((PictureBox)ctr).Image, new Point(pointParent.X + e.MarginBounds.Left, (int)((top + pointParent.Y) / 1.00) + e.MarginBounds.Top));
            ////    tops[j] = (top + pointParent.Y) + ctr.Height;
            ////}

            ////emrLine:打印内部填充
            //else if (ctr.GetType() == typeof(Neusoft.FrameWork.EPRControl.emrLine) || ctr.GetType().IsSubclassOf(typeof(Neusoft.FrameWork.EPRControl.emrLine)))
            //{
            //    //e.Graphics.DrawString(ctr.Text, ctr.Font, Brushes.Black, new Point(pointParent.X + e.MarginBounds.Left, (top + pointParent.Y) + e.MarginBounds.Top));
            //    grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //}
            ////FarPoint:采用FarPoint的打印
            //else if (ctr.GetType() == typeof(FarPoint.Win.Spread.FpSpread) || ctr.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
            //{
            //    DrawFarpoint(grap, ctr, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);

            //}
            ////CheckBox：打印选择框和文本
            //else if (ctr.GetType() == typeof(CheckBox) || ctr.GetType().IsSubclassOf(typeof(CheckBox)))
            //{
            //    CheckBox t = ctr as CheckBox;
            //    if (t.Checked)
            //    {
            //        grap.DrawImage(gCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
            //    }
            //    else
            //    {
            //        grap.DrawImage(gUnCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
            //    }
            //    grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left + gCheked.Width, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());
            //}
            ////RadioButton：打印选择框和文本
            //else if (ctr.GetType() == typeof(RadioButton) || ctr.GetType().IsSubclassOf(typeof(RadioButton)))
            //{
            //    RadioButton t = ctr as RadioButton;
            //    if (t.Checked)
            //    {
            //        grap.DrawImage(gRadioCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
            //    }
            //    else
            //    {
            //        grap.DrawImage(gRadioUnCheked, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + 2);
            //    }
            //    grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left + gCheked.Width, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());
            //}
            ////GroupBox：打印内部填充和边界以及内部文本
            //else if (ctr.GetType() == typeof(GroupBox) || ctr.GetType().IsSubclassOf(typeof(GroupBox)))
            //{
            //    ControlPaint.DrawBorder(grap, new Rectangle(pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height), Color.Black, ButtonBorderStyle.Solid);
            //    grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left + 10, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top - 8, grap.MeasureString(ctr.Text, ctr.Font).Width, grap.MeasureString(ctr.Text, ctr.Font).Height);
            //    grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left + 10, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top - 8, new StringFormat());
            //}
            ////PictureBox：打印图片
            //else if (ctr.GetType() == typeof(PictureBox) || ctr.GetType().IsSubclassOf(typeof(PictureBox)))
            //{
            //    PictureBox t = ctr as PictureBox;
            //    Image m = null;
            //    try
            //    {
            //        m = t.Image.Clone() as Image;
            //        grap.DrawImage(m, pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //    }
            //    catch { }
            //}
            ////Panel：打印填充颜色和内容控件
            //else if (ctr.GetType() == typeof(Panel) || ctr.GetType().IsSubclassOf(typeof(Panel)))
            //{
            //    grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //}
            ////TabPage：不打印
            //else if (ctr.GetType() == typeof(TabPage) || ctr.GetType().IsSubclassOf(typeof(TabPage)))
            //{

            //}
            ////TabControl：不打印
            //else if (ctr.GetType() == typeof(TabControl) || ctr.GetType().IsSubclassOf(typeof(TabControl)))
            //{

            //}
            ////SpreadView：不打印
            //else if (ctr.GetType() == typeof(FarPoint.Win.Spread.SpreadView) || ctr.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.SpreadView)))
            //{

            //}
            ////HScrollBar：不打印
            //else if (ctr.GetType() == typeof(HScrollBar) || ctr.GetType().IsSubclassOf(typeof(HScrollBar)))
            //{

            //}
            ////VScrollBar：不打印
            //else if (ctr.GetType() == typeof(VScrollBar) || ctr.GetType().IsSubclassOf(typeof(VScrollBar)))
            //{

            //}
            ////ScrollBar：不打印
            //else if (ctr.GetType() == typeof(ScrollBar) || ctr.GetType().IsSubclassOf(typeof(ScrollBar)))
            //{

            //}
            ////DataGrid：不打印
            //else if (ctr.GetType() == typeof(DataGrid) || ctr.GetType().IsSubclassOf(typeof(DataGrid)))
            //{
            //    #region 画表格 --必须有dtTable
            //    DataGrid t = ctr as DataGrid;
            //    int CaptionHeight = 20;
            //    //画表格
            //    grap.FillRectangle(new SolidBrush(t.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //    if (t.CaptionVisible)
            //    {
            //        grap.FillRectangle(new SolidBrush(t.CaptionBackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //        grap.DrawString(t.CaptionText, t.Font, new SolidBrush(t.CaptionForeColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top);
            //    }

            //    //画列
            //    System.Data.DataTable dt = t.DataSource as System.Data.DataTable;
            //    Rectangle r;
            //    string sTemp = "";
            //    if (dt != null)
            //    {
            //        for (int col = 0; col < dt.Columns.Count; col++)
            //        {
            //            r = t.GetCellBounds(0, col);
            //            grap.FillRectangle(new SolidBrush(t.HeaderBackColor), pointCtr.X + e.MarginBounds.Left + r.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + CaptionHeight, r.Width, r.Height);
            //            grap.DrawString(dt.Columns[col].ColumnName, t.Font, new SolidBrush(t.HeaderForeColor), pointCtr.X + e.MarginBounds.Left + r.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + CaptionHeight);

            //        }
            //        for (int row1 = 0; row1 < dt.Rows.Count; row1++)
            //        {
            //            for (int col = 0; col < dt.Columns.Count; col++)
            //            {
            //                try
            //                {
            //                    sTemp = dt.Rows[row1][col].ToString();
            //                }
            //                catch
            //                {
            //                    sTemp = "";
            //                }
            //                r = t.GetCellBounds(row1, col);
            //                grap.FillRectangle(new SolidBrush(t.BackColor), pointCtr.X + e.MarginBounds.Left + r.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + r.Top, r.Width, r.Height);
            //                grap.DrawString(sTemp, t.Font, new SolidBrush(t.ForeColor), pointCtr.X + e.MarginBounds.Left + r.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + r.Top);
            //                //画grid 竖线
            //                Pen pen = new Pen(t.GridLineColor);
            //                grap.DrawRectangle(pen, pointCtr.X + e.MarginBounds.Left + r.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top + r.Top, r.Width, r.Height);

            //            }
            //        }
            //    }
            //    #endregion 画表格 --必须有dtTable
            //}
            //else if (ctr.GetType() == typeof(DateTimePicker) || ctr.GetType().IsSubclassOf(typeof(DateTimePicker)))
            //{
            //    //日期，属于输入控件
            //    try
            //    {
            //        grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //        if (((DateTimePicker)ctr).Value == DateTime.MinValue)
            //        {
            //            grap.DrawString("00-00-00", ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());
            //        }
            //        else
            //        {
            //            grap.DrawString(ctr.Text, ctr.Font, new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());
            //        }
            //    }
            //    catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
            //}
            //else if (ctr.GetType() == typeof(Button) || ctr.GetType().IsSubclassOf(typeof(Button)))//不打印按钮
            //{
            //}
            //else if (ctr.GetType() == typeof(Form) || ctr.GetType().IsSubclassOf(typeof(Form)))//不打印窗口
            //{

            //}
            //else
            //{
            //    if (ctr.Text != "")
            //    {
            //        grap.FillRectangle(new SolidBrush(ctr.BackColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, ctr.Width, ctr.Height);
            //        if (ctr.Text != "")
            //        {
            //            grap.DrawString(ctr.Text, AutoFont(ctr, grap), new SolidBrush(ctr.ForeColor), pointCtr.X + e.MarginBounds.Left, (int)((top + pointCtr.Y) / 1.00) + e.MarginBounds.Top, new StringFormat());//2+pointParent.X + e.MarginBounds.Left+(int)pBlankMargin.X,3+allTop+ctr.Height /2 -grap.MeasureString("李",ctr.Font).Height/2+(int)pBlankMargin.Y		break;
            //        }
            //    }

            //}
            #endregion 
        }

        private Neusoft.FrameWork.WinForms.Classes.enuControlBorder controlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
        private int addpage = 0;
        /// <summary>
        /// 控件边框
        /// </summary>
        public Neusoft.FrameWork.WinForms.Classes.enuControlBorder ControlBorder
        {
            get
            {
                return controlBorder;
            }
            set
            {
                controlBorder = value;
            }
        }
        /// <summary>
        /// 画farpoint
        /// </summary>
        /// <param name="g"></param>
        /// <param name="c"></param>
        /// <param name="ControlLeft"></param>
        /// <param name="ControlTop"></param>
        /// <param name="ControlWidth"></param>
        /// <param name="ControlHeight"></param>
        private void DrawFarpoint(System.Drawing.Graphics g, Control c, int ControlLeft, int ControlTop, int ControlWidth, int ControlHeight, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region farpoint
            FarPoint.Win.Spread.FpSpread t = c as FarPoint.Win.Spread.FpSpread;
            
            Rectangle rect = new Rectangle(ControlLeft, ControlTop, ControlWidth, ControlHeight);//new Rectangle(ControlLeft ,ControlTop ,ControlWidth,ControlHeight);//ControlWidth,ControlHeight );
            FarPoint.Win.Spread.PrintInfo printinfo = new FarPoint.Win.Spread.PrintInfo();
            for (int iSheet = 0; iSheet < t.Sheets.Count; iSheet++)
            {
                if (this.ControlBorder == Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None)
                    printinfo.ShowBorder = false;
                printinfo.ShowRowHeaders = t.Sheets[iSheet].RowHeader.Visible;
                printinfo.ShowColumnHeaders = t.Sheets[iSheet].ColumnHeader.Visible;
                printinfo.PageStart = 0;
                t.Sheets[iSheet].PrintInfo = printinfo;
            }
            int iCount = t.GetOwnerPrintPageCount(g, rect, 0);
            //if (TotalPage < iCount) TotalPage = iCount; //为多个farpoint打印用的
            if (addpage == 0)
            {
                addpage = 1;
            }
            if (addpage <= iCount)
            {
                t.OwnerPrintDraw(g, rect, t.ActiveSheetIndex, addpage);
                addpage++;
            }
            if (addpage > iCount)
            {
                addpage = 0;
            }
            else
            {
                e.HasMorePages = true;
            }
            #endregion
        }

        private void DrawGrid(System.Drawing.Graphics g, Control c, int ControlLeft, int ControlTop, int ControlWidth, int ControlHeight)
        {
            string[] l;
            string[] s;
            Rectangle r = new Rectangle(ControlLeft, ControlTop, ControlWidth, ControlHeight);
            //画背景		

            Neusoft.FrameWork.EPRControl.ucGrid t = c as Neusoft.FrameWork.EPRControl.ucGrid;
            if (t == null) return;
            l = t.saveDrawing();

            for (int m = 0; m < l.Length; m++)
            {
                s = l[m].Split(',');
                int left, top, width, height;
                if (int.Parse(s[0].ToString()) < 0)
                {
                    s[2] = (int.Parse(s[2]) + int.Parse(s[0])).ToString();
                    s[0] = "0";
                }
                left = int.Parse(s[0]) + ControlLeft;
                if (int.Parse(s[1]) < 0)
                {
                    s[3] = (int.Parse(s[3]) + int.Parse(s[1])).ToString();
                    s[1] = "0";
                }
                top = int.Parse(s[1]) + ControlTop;
                if (int.Parse(s[2]) + int.Parse(s[0]) > ControlWidth) s[2] = (ControlWidth - int.Parse(s[0])).ToString();
                width = int.Parse(s[2]);

                if (int.Parse(s[3]) + int.Parse(s[1]) > ControlHeight) s[3] = (ControlHeight - int.Parse(s[1])).ToString();
                height = int.Parse(s[3]);
                g.FillRectangle(new SolidBrush(Color.Black), left, top, width, height);
            }
        }

        /// <summary>
        /// 打印字体自动变动
        /// </summary>
        /// <param name="t"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        private Font AutoFont(Control t, Graphics g)
        {
            Font newFont = null;
            if (this.bIsAutoFont)//自动
            {
                if (g.MeasureString(t.Text, t.Font).Width > t.Width)
                {
                    newFont = new System.Drawing.Font(t.Font.FontFamily, (t.Font.Size * (float)0.8), t.Font.Style, t.Font.Unit);
                }
                else
                {
                    newFont = t.Font;
                }
            }
            else
            {
                newFont = t.Font;
            }
            return newFont;
        }

        /// <summary>
        /// 设置CheckBox的Checked和UnChecked图片和RadionButton的Checked和UnChecked图片
        /// </summary>
        /// <param name="imageList1"></param>
        public void SetImage(ImageList imageList1)
        {
            gCheked = imageList1.Images[0];
            gUnCheked = imageList1.Images[1]; ;
            gRadioCheked = imageList1.Images[2];
            gRadioUnCheked = imageList1.Images[3];
        }
        #region 方法
        /// <summary>
        /// 图片清空
        /// </summary>
        /// <param name="bmpDist"></param>
        protected void SetBitmap(Bitmap bmpDist)
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

        /// <summary>
        /// 图片清空
        /// </summary>
        /// <param name="bmpDist"></param>
        /// <param name="color"></param>
        protected void SetBitmap(Bitmap bmpDist, Color color)
        {
            bmpDist.MakeTransparent(Color.FromArgb(255, color));

        }

        /// <summary>
        /// 图片清空
        /// </summary>
        /// <param name="bmpDist"></param>
        /// <param name="rect"></param>
        protected void SetBitmap(Bitmap bmpDist, Rectangle rect)
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

        /// <summary>
        /// 图片清空
        /// </summary>
        /// <param name="bmpDist"></param>
        /// <param name="bmpSource"></param>
        /// <param name="pointStart"></param>
        protected void SetBitmap(Bitmap bmpDist, Bitmap bmpSource, Point pointStart)
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



        #endregion "方法"

    }       
}