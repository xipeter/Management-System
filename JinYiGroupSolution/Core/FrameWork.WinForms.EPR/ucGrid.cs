using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
namespace Neusoft.FrameWork.EPRControl
{

    public partial class ucGrid : System.Windows.Forms.Panel, IUserControlable
    {

	    public ucGrid() : base()
        {
            mygraphic = this.CreateGraphics();
		    this.SendToBack();
		    newRect = new Rectangle();
	    }
	    internal System.Windows.Forms.Panel Panel2;
	    internal System.Windows.Forms.Panel Panel1;
	    internal System.Windows.Forms.Panel Panel3;
	    internal System.Windows.Forms.Panel Panel4;
        private bool isPrint;
	    [DllImport("user32", EntryPoint = "ReleaseCapture", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
	    private static extern long ReleaseCapture();
	    [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
	    private static extern long SendMessage(IntPtr hwnd, int wMsg, long wParam, int lParam);

	    
	    //Public Event gridChanged(ByVal sender As Object, ByVal e As System.EventArgs)
	    //定义API
	    private const int  WM_NCLBUTTONDOWN = 161;
	    private const int HTCAPTION = 2;
	    private const int HTBORDER = 18;
	    private const int HTLEFT = 10;
	    private const int HTBOTTOM = 15;
	    private const int HTRIGHT = 11;
	    private const int HTTOP = 12;
	    private const int HTBOTTOMLEFT = 16;
	    private const int HTBOTTOMRIGHT = 17;
	    private const int HTTOPLEFT = 13;
	    private const int HTTOPRIGHT = 14;
	    private const int WM_MOUSEMOVE = 512;
	    private const int WM_ACTIVATE = 6;

	    //定义线的结构
	    public struct line
	    {
		    public int x1;
		    public int y1;
		    public int x2;
		    public int y2;
	    }
	    //属性变量
		    //行
	    private int rowNumber = 1;
		    //列
	    private int colNumber = 1;
		    //线宽
	    private int lineWidth = 1;
	    private System.EventArgs e;
	    public ArrayList lines;
		    //线的颜色
	    private Color lineBackColor = Color.Black;
	    private Rectangle newRect;
	    private ArrayList interRect;
		    //是否设计模式
	    public bool bDesign = false;

		    //选择的线
	    private Control selectedLine;
	    private bool bMove = true;
	    //内部变量
        protected Graphics mygraphic;
	    private Form form = new Form();

	    [Editor(typeof(UIemrGridEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置表格"), ExtenderProvidedProperty()]
	    public string 设置 {
		    get { return ""; }
		    set {
			    try {
				    if (value == null) return; 
				    if (value == "") return; 
				    Form f = new Form();
				    ucGrid g = new ucGrid();
				    string[] l;

				    g.Width = this.Width;
				    g.Height = this.Height;

				    g.行 = this.行;
				    g.列 = this.列;
				    l = this.saveDrawing();
				    g.IniDawing(l);
				    g.bDesign = true;
				    g.bMove = false;
				    form.Controls.Clear();
				    form.Controls.Add(g);

				    form.Width = g.Width + 200;
				    form.Height = g.Height + 200;
				    form.Text = "设置表格";
				    form.StartPosition = FormStartPosition.CenterScreen;
				    form.ShowDialog();

				    string[] l1 = g.saveDrawing();
				    this.InLines = l1;
			    }
			    catch (Exception ex) {
				    MessageBox.Show(ex.Message);
			    }

		    }
	    }

	    [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置多行!")]
	    public int 行 {
		    get { return rowNumber; }
		    set {

			    if ((rowNumber == 1 & lastValue == null))
			    {
				    rowNumber = value;
				    gridChanged(this, e);
			    }
                else if ((rowNumber == 1 & lastValue.Length > 0)) {
				    rowNumber = value;
			    }
			    else
			    {
				    rowNumber = value;
				    gridChanged(this, e);

			    }

		    }
	    }

	    [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置多少列!")]
	    public int 列 {
		    get { return colNumber; }
		    set {
			    if ((colNumber == 1 & lastValue == null))
			    {
				    colNumber = value;
				    gridChanged(this, e);
			    }
            else if ((colNumber == 1 & lastValue.Length > 0)) {
				    colNumber = value;
			    }
			    else
			    {
				    colNumber = value;
				    gridChanged(this, e);
			    }

		    }
	    }


	    [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置线宽!")]
	    public int 线宽 {
		    get { return lineWidth; }
		    set {
			    if (value > 10)
			    {
				    MessageBox.Show("错误！不可以大于10!");
				    return; // TODO: might not be correct. Was : Exit Property
			    }
			    lineWidth = value;
			    f_setLineWidth();
		    }
	    }

	    protected string[] lastValue;
	    [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("线属性")]
	    public string[] InLines {
		    get {
			    string[] l = this.saveDrawing();
			    return l;
		    }
		    set {
			    if (value == null) return; 
			    lastValue = value;
			    this.IniDawing(value);
		    }
	    }
	    //*************************************************
	    //公用函数 初始化线
	    public void IniDawing(string[] l)
	    {
		    int i=0;
		    string[] s;
		    reset();
		    lines = new ArrayList();

		    try {
			    for (i = 0; i <= l.Length - 1; i++) {
				    s = l[i].Split(',');
				    f_addControl(Neusoft.FrameWork.Function.NConvert.ToInt32(s[0]), Neusoft.FrameWork.Function.NConvert.ToInt32(s[1]), Neusoft.FrameWork.Function.NConvert.ToInt32(s[2]), Neusoft.FrameWork.Function.NConvert.ToInt32(s[3]));
			    }
		    }
		    catch (Exception ex) 
            {
			    MessageBox.Show("无法分解" + i.ToString() + "错误代码：" + ex.Message,"",MessageBoxButtons.OK );
                
		    }
	    }
	    public string[] saveDrawing()
	    {
		    int i;
		    Control c;
		    if (lines == null) return null; 
		    if (lines.Count <= 0) return null; 
		    string[] l = new string[lines.Count];
		    for (i = 0; i <= lines.Count - 1; i++) {
			    try
                {
				    c = lines[i] as Control;
				    l[i] = (c.Left + "," + c.Top + "," + c.Width + "," + c.Height);
			    }
			    catch {
			    }
		    }
		    return l;
	    }
	    public void reset()
	    {
		    int i;
		    try {
			    for (i = 0; i <= lines.Count - 1; i++) {
				    try {
					    ((Control)lines[i]).Dispose();
				    }
				    catch {
				    }
			    }
			    lines.Clear();
		    }
		    catch {
		    }
	    }
	    //**************************************************
	    //变化重新画
	    private void gridChanged(object sender, System.EventArgs e)
	    {
		    int i;
		    int j;

		    try {
			    for (i = 0; i <= lines.Count - 1; i++) {
				    ((Panel)lines[i]).Dispose();
			    }
		    }
		    catch {
		    }
		    lines = new ArrayList();

		    for (i = 0; i <= rowNumber - 1; i++) {
			    f_addControl(-500, this.Height / rowNumber * (i + 1), this.Width + 1000, lineWidth);
		    }
		    for (i = 0; i <= colNumber - 1; i++) {
			    f_addControl(this.Width / colNumber * (i + 1), -500, lineWidth, this.Height + 1000);
		    }
	    }
	    //add control
	    private void f_addControl(int left, int top, int width, int height)
	    {
		    Panel ControlNew;
		    ControlNew = new Panel();
		    ControlNew.BackColor = lineBackColor;
		    ControlNew.Top = top;
		    ControlNew.Left = left;
		    ControlNew.Width = width;
		    ControlNew.Height = height;
		    ControlNew.Visible = true;
		    ControlNew.Tag = emrNode.UserTag;
		    //标识控件不要打印
		    lines.Add(ControlNew);
		    this.Controls.Add(ControlNew);
		    ControlNew.MouseDown += ControlNew_MouseDown;
		    ControlNew.MouseMove += ControlNew_MouseMove;
		    ControlNew.MouseUp += ControlNew_MouseUp;
		    //AddHandler ControlNew.Move, AddressOf ControlNew_Move
		    //AddHandler ControlNew.Resize, AddressOf ControlNew_Resize
		    //AddHandler ControlNew.TextChanged, AddressOf ControlNew_TextChanged
		    ControlNew.KeyDown += ControlNew_KeyDown;
		    //AddHandler ControlNew.KeyUp, AddressOf ControlNew_KeyUp
	    }
	    //
	    private void f_setLineWidth()
	    {
		    int i;
		    for (i = 0; i <= this.Controls.Count - 1; i++) {
			    if (this.Controls[i].GetType().ToString() == "System.Windows.Forms.Panel")
			    {
				    if (this.Controls[i].Width <= 10)
				    {
					    this.Controls[i].Width = lineWidth;
				    }
				    if (this.Controls[i].Height <= 10)
				    {
					    this.Controls[i].Height = lineWidth;
				    }
			    }
		    }
	    }

	    private void DrawControlPoint(Control EmrControl)
	    {
		    int i;
		    Rectangle[] rect = new Rectangle[5];
		    int PointWidth = 5;
		    Graphics g;
		    //Dim pen As Pen = New Pen(Color.Black)
		    SolidBrush myBrush = new SolidBrush(Color.Black);
		    this.Refresh();
		    g = this.CreateGraphics();

		    rect[0].Location = new System.Drawing.Point(EmrControl.Left - PointWidth, EmrControl.Top - PointWidth);
		    rect[0].Size = new System.Drawing.Size(PointWidth, PointWidth);

		    rect[1].Location = new System.Drawing.Point(EmrControl.Left + EmrControl.Width, EmrControl.Top - PointWidth);
		    rect[1].Size = new System.Drawing.Size(PointWidth, PointWidth);

		    rect[2].Location = new System.Drawing.Point(EmrControl.Left - PointWidth, EmrControl.Top + EmrControl.Height);
		    rect[2].Size = new System.Drawing.Size(PointWidth, PointWidth);

		    rect[3].Location = new System.Drawing.Point(EmrControl.Left + EmrControl.Width, EmrControl.Top + EmrControl.Height);
		    rect[3].Size = new System.Drawing.Size(PointWidth, PointWidth);

		    for (i = 0; i <= 3; i++) {
			    g.FillRectangle(myBrush, rect[i]);
		    }
	    }
	    //-----------------------------------------------------------------------------------------------------
	    //                              控件处理事件
	    //-----------------------------------------------------------------------------------------------------
	    private void ControlNew_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	    {
		    selectedLine =(Control) sender;
		    //选择控件
		    DrawControlPoint((Control)sender);
		    if (e.Button == MouseButtons.Left)
		    {
			    //移动
			    MoveControl(sender, e, 1, 0);
		    }
		    else
		    {
			    selectedLine.ContextMenu = this.ShowPopupMenu();
		    }
	    }
	    System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();

	    private void ControlNew_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
	    {
		    ChangeCursor(sender, e, 1, 0);

	    }
	    //鼠标up
	    private void ControlNew_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
	    {

	    }
	    //按键
	    private void ControlNew_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	    {
		    Control tempControl = new Control();
		    tempControl = (Control)sender;
		    switch (e.KeyValue) {
			    case 39:
				    tempControl.Left = tempControl.Left + 1;
				    break;
			    case 37:
				    tempControl.Left = tempControl.Left - 1;
				    break;
			    case 40:
				    tempControl.Top = tempControl.Top + 1;
				    break;
			    case 38:
				    tempControl.Top = tempControl.Top - 1;
				    break;
			    case 46:
				    f_delLines(tempControl);
				    break;
			    default:
				    break;

		    }

	    }
	    //************************************************************************
	    //
	    //   本地函数
	    //************************************************************************
	    //移动控件函数
	    private void MoveControl(object sender, System.Windows.Forms.MouseEventArgs e, int i, int j)
	    {
		    if (bDesign == false) return; // TODO: might not be correct. Was : Exit Sub
     
		    Control ControlTemp = new Control();

		    IntPtr hWnd;
		    ControlTemp = sender as Control;
		    hWnd = ControlTemp.Handle;

		    ReleaseCapture();

		    //If e.X < i Then
		    //    If e.Y < i Then
		    //        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPLEFT, 0)
		    //    ElseIf e.Y > ControlTemp.Height - i - j Then
		    //        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMLEFT, 0)
		    //    Else
		    //        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTLEFT, 0)
		    //    End If
		    //ElseIf e.X > ControlTemp.Width - i - j Then

		    //    If e.Y < i Then
		    //        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0)
		    //    ElseIf e.Y > ControlTemp.Height - i - j Then
		    //        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMRIGHT, 0)
		    //    Else
		    //        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTRIGHT, 0)
		    //    End If

		    //ElseIf e.Y > ControlTemp.Height - i - j Then
		    //    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOM, 0)
		    //ElseIf e.Y < i Then
		    //    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOP, 0)
		    //Else
		    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0);
		    //End If

	    }
	    //移动控件函数
	    private void MoveMe(object sender, System.Windows.Forms.MouseEventArgs e, int i, int j)
	    {
		    if (bDesign == false) return; // TODO: might not be correct. Was : Exit Sub
     
		    Control ControlTemp = new Control();

		    IntPtr hWnd;
		    ControlTemp = sender as Control;
		    hWnd = ControlTemp.Handle;

		    ReleaseCapture();

		    if (e.X < i)
		    {
			    if (e.Y < i)
			    {
				    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPLEFT, 0);
			    }
                else if (e.Y > ControlTemp.Height - i - j) {
				    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMLEFT, 0);
			    }
			    else
			    {
				    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTLEFT, 0);
			    }
		    }
            else if (e.X > ControlTemp.Width - i - j) 
            {

			    if (e.Y < i)
			    {
				    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOPRIGHT, 0);
			    }
                else if (e.Y > ControlTemp.Height - i - j) {
				    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOMRIGHT, 0);
			    }
			    else
			    {
				    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTRIGHT, 0);
			    }
		    }

            else if (e.Y > ControlTemp.Height - i - j) 
            {
			    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTBOTTOM, 0);
		    }
            else if (e.Y < i) {
			    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTTOP, 0);
		    }
		    else
		    {
			    SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0);
		    }

	    }
	    //变化鼠标
	    private void ChangeCursor(object sender, System.Windows.Forms.MouseEventArgs e, int i, int j)
	    {
		    Control ControlTemp;
		    ControlTemp = sender as Control;

		    if (bDesign == false)
		    {

			    ControlTemp.Cursor = System.Windows.Forms.Cursors.Default;
			    return; // TODO: might not be correct. Was : Exit Sub
		    }

		   
		    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeAll;

	    }
	    private void ChangeMyCursor(object sender, System.Windows.Forms.MouseEventArgs e, int i, int j)
	    {
		    Control ControlTemp;
		    ControlTemp = sender as Control;

		    if (bDesign == false)
		    {
			    ControlTemp.Cursor = System.Windows.Forms.Cursors.Default;
			    return; // TODO: might not be correct. Was : Exit Sub
		    }

		    if (e.X < i)
		    {
			    if (e.Y < i)
			    {
				    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			    }
                else if (e.Y > ControlTemp.Height - i - j) {
				    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeNESW;
			    }
			    else
			    {
				    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeWE;
			    }
		    }

            else if (e.X > ControlTemp.Width - i - j) 
            {

			    if (e.Y < i)
			    {
				    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeNESW;
			    }
                else if (e.Y > ControlTemp.Height - i - j) {
				    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			    }
			    else
			    {
				    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeWE;
			    }
		    }

            else if (e.Y > ControlTemp.Height - i - j) 
            {
			    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeNS;
		    }
            else if (e.Y < i) 
            {
			    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeNS;
		    }
		    else
		    {
			    ControlTemp.Cursor = System.Windows.Forms.Cursors.SizeAll;
		    }
	    }
	    //获得矩形
	    private Rectangle getRect(int x, int y)
	    {
		    //查找控件 
		    int i;
		    int j;
		    Point p = new Point(x, y);
		    int left;
		    int right;
		    int top;
		    int bottom;
		    left = f_getRect(p, 0);
		    right = f_getRect(p, 1);
		    top = f_getRect(p, 2);
		    bottom = f_getRect(p, 3);

		    Rectangle r = new Rectangle(left + 1, top + 1, right - left - 1, bottom - top - 1);
		    return r;
	    }
	    //获得边缘
	    private int f_getRect(Point p, int state)
	    {
		    int i;
		    Point newP = p;
		    if (state < 2)
		    {
			    i = p.X;
		    }
		    else
		    {
			    i = p.Y;
		    }
		    do {

			    switch (state) {
				    case 0:
					    i = i - 1;
					    break;
				    case 1:
					    i = i + 1;
					    break;
				    case 2:
					    i = i - 1;
					    break;
				    case 3:
					    i = i + 1;
					    break;
			    }
			    if (state < 2)
			    {
				    newP = new Point(i, p.Y);
			    }
			    else
			    {
				    newP = new Point(p.X, i);
			    }
			    try {
				    if (this.GetChildAtPoint(newP) == null)
				    {
					    if (state < 2)
					    {
						    if (i <= 0 | i >= base.Width)
						    {
							    return i;
						    }
					    }
					    else
					    {
						    if (i <= 0 | i >= base.Height)
						    {
							    return i;
						    }
					    }
				    }
                    else if (this.GetChildAtPoint(newP).GetType().ToString() != "System.Windows.Forms.Panel")
                    {
					    MessageBox.Show(this.GetChildAtPoint(newP).GetType().ToString());
				    }
				    else
				    {
					    return i;

				    }
			    }
			    catch {
				    MessageBox.Show("Error");
			    }
		    }
		    while (true);
	    }
	    //******************menu*****************
	    private ContextMenu ShowPopupMenu()
	    {
		    //将所有菜单项对象插入到数组中并将它们同时添加到
		    //上下文菜单中
		    MenuItem[] mnuItms = new MenuItem[5];
		    mnuItms[0] = new MenuItem("合并单元格", new EventHandler(this.combinUnit));
		    mnuItms[1] = new MenuItem("复制该线", new EventHandler(this.Copy));
		    mnuItms[2] = new MenuItem("删除该线", new EventHandler(this.Del));
		    mnuItms[3] = new MenuItem("-");
		    mnuItms[4] = new MenuItem("移动", new EventHandler(this.myMove));

		    mnuItms[4].Checked = bMove;
		    if (selectedLine == null)
		    {
			    mnuItms[1].Enabled = false;
			    mnuItms[2].Enabled = false;
		    }
		    else
		    {
			    mnuItms[1].Enabled = true;
			    mnuItms[2].Enabled = true;
		    }
		    return new ContextMenu(mnuItms);
	    }
	    //合
	    public void combinUnit(object sender, EventArgs e)
	    {
		    if ((interRect == null)) return; 
		    int i;

		    for (i = 0; i <= interRect.Count - 1; i++) {
			    try
                {
				    f_delLine((Rectangle)interRect[i]);
			    }
			    catch {
			    }
		    }
	    }
	    //del line
	    public void Del(object sender, EventArgs e)
	    {
		    //
		    try {
			    f_delLines(selectedLine);
			    selectedLine.Dispose();
		    }
		    catch {
		    }
	    }
	    //copy line
	    public void Copy(object sender, EventArgs e)
	    {
		    //
		    try {
			    f_addControl(selectedLine.Left + 3, selectedLine.Top + 3, selectedLine.Width, selectedLine.Height);
		    }
		    catch {
		    }
	    }
	    public void myMove(object sender, EventArgs e)
	    {
		    //
		    bMove = !bMove;
	    }
	    //*******************************end menu********
	    private void f_delLine(Rectangle r)
	    {
		    Point p;
		    int i;
		    //If r.Width < r.Height Then
		    for (i = r.Left + 1; i <= r.Right - 1; i++) {
			    //+ lineWidth
			    p = new Point(i, r.Top + 1);
			    f_delControl(p, r);
		    }
		    //Else
		    for (i = r.Top + 1; i <= r.Bottom - 1; i++) {
			    //+ lineWidth
			    p = new Point(r.Left + 1, i);
			    f_delControl(p, r);
		    }
		    //End If

	    }
	    private void f_delControl(Point p, Rectangle rect)
	    {
		    Control c;
		    try {
			    c = this.GetChildAtPoint(p);
			    if (c == null) return; 
			    if (c.Width < c.Height)
			    {
				    //竖线
				    f_addControl(c.Left, c.Top, c.Width, rect.Top - c.Top);
				    f_addControl(c.Left, rect.Bottom, c.Width, c.Height - (rect.Bottom - c.Top));
			    }
			    else
			    {
				    //横线
				    f_addControl(c.Left, c.Top, rect.Left - c.Left, c.Height);
				    f_addControl(rect.Right, c.Top, c.Width - (rect.Right - c.Left), c.Height);
			    }
			    f_delLines(c);
		    }
		    catch {
			    // MsgBox("没找到控件")
		    }
	    }
	    private void f_delLines(Control c)
	    {
		    int i;
		    for (i = 0; i <= lines.Count - 1; i++) {
			    try {
				    if (((Control)lines[i]).Handle.ToInt32() == c.Handle.ToInt32())
				    {
					    lines.RemoveAt(i);
				    }
			    }
			    catch {
			    }
		    }
		    c.Dispose();
	    }
	    //判断两个rect是否临近
	    private bool f_combinRect(Rectangle r)
	    {
		    Rectangle tmpR = new Rectangle();

		    tmpR = new Rectangle(r.Left - lineWidth - 4, r.Top - lineWidth - 4, r.Width + lineWidth * 2 + 8, r.Height + lineWidth * 2 + 8);

		    if (tmpR.IntersectsWith(newRect) == true)
		    {
			    tmpR.Intersect(newRect);
			    if ((tmpR.Width < tmpR.Height))
			    {
				    //竖着的交集
				    if ((tmpR.Height > r.Height))
				    {
					    tmpR.Y = r.Y;
					    tmpR.Height = r.Height;
				    }
				  
				    if ((r.X - tmpR.X > 0))
				    {
					    tmpR.X = tmpR.X + 2;
				    }
				    else
				    {
					    tmpR.X = tmpR.X - 2;
				    }
			    }

			    else
			    {
				    //横着的交集
				    if ((tmpR.Width > r.Width))
				    {
					    tmpR.X = r.X;
					    tmpR.Width = r.Width;
				    }
				    //ElseIf (tmpR.Width > newRect.Width) Then
				    //tmpR.X = newRect.X
				    //tmpR.Width = newRect.Width
				    //End If
				    if ((r.Y - tmpR.Y > 0))
				    {
					    tmpR.Y = tmpR.Y + 2;
				    }
				    else
				    {
					    tmpR.Y = tmpR.Y - 2;
				    }


			    }
			   
			    interRect.Add(tmpR);
			    return true;
		    }
		    else
		    {
			    return false;
		    }
	    }

	    //*******************************************************************
	    //本地处理事件
	    //*******************************************************************
	    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	    {
		    if (bDesign == false) return; // TODO: might not be correct. Was : Exit Sub
     
		    this.ContextMenu = this.ShowPopupMenu();
		    if (e.Button == MouseButtons.Left)
		    {
			    if (!bMove)
			    {
				    try {
                        
					    Rectangle r = new Rectangle();
					    if (Control.ModifierKeys != Keys.Control)
					    {
						    this.Refresh();
						    interRect = new ArrayList();
						    r = getRect(e.X, e.Y);
					    }
					    else
					    {
						    //按control
						    r = getRect(e.X, e.Y);
						    if (f_combinRect(r) == false)
						    {
							    //可以
							    this.Refresh();
							    interRect = new ArrayList();
							    //更新重叠区域
						    }
					    }
					    newRect = r;
					    mygraphic.FillRectangle(new SolidBrush(Color.SkyBlue), r);
				    }
				    catch (Exception ex) {
					    MessageBox.Show(ex.Message);
				    }
			    }
			    else
			    {
				    MoveMe(this, e, 4, 5);
				    //移动
			    }
		    }
		    else
		    {

		    }

	    }
	    //mouse up
	    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	    {
		    if (e.Button == MouseButtons.Right)
		    {
		    }

		    else
		    {
			    //Me.SendToBack()
		    }

	    }
	    //
	    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
	    {
		    if (bMove)
		    {
			    ChangeMyCursor(this, e, 4, 5);
		    }
		    else
		    {
			    this.Cursor = System.Windows.Forms.Cursors.Arrow;
		    }
	    }

	   

	    [Browsable(false)]
	    public override System.Drawing.Color BackColor {
		    get { return base.BackColor; }
		    set { base.BackColor = value; }
	    }
	    [CategoryAttribute("颜色"), Description("修改设置表格的背景颜色。")]
	    public System.Drawing.Color 背景颜色 {
		    get { return base.BackColor; }
		    set { base.BackColor = value; }
	    }

	    [Browsable(false)]
	    public override System.Drawing.Color ForeColor {
		    get { return base.ForeColor; }
		    set { base.ForeColor = value; }
	    }


	    [Browsable(false)]
	    public override System.Drawing.Font Font {
		    get { return base.Font; }
		    set { base.Font = value; }
	    }
	    [CategoryAttribute("设计"), Description("修改病历页的字体大小。"), Browsable(false)]
	    public System.Drawing.Font 字体 {
		    get { return base.Font; }
		    set { base.Font = value; }
	    }
	    [Browsable(false)]
	    public new System.Drawing.Size Size {
		    get { return base.Size; }
		    set { base.Size = value; }
	    }
	    [CategoryAttribute("布局"), Description("修改设置表格的尺寸大小。")]
	    public System.Drawing.Size 表格尺寸 {
		    get { return base.Size; }
		    set { base.Size = value; }
	    }

	    [CategoryAttribute("布局"), Description("修改设置表格的坐标。")]
	    public new System.Drawing.Point 位置 {
		    get { return base.Location; }
		    set { base.Location = value; }
	    }

	

	    private void emrGrid_SizeChanged(object sender, System.EventArgs e)
	    {
		    mygraphic = this.CreateGraphics();
	    }

	    public bool IsPrint {

            get { return this.isPrint; }

            set { this.isPrint = value; }
	    }



        #region IUserControlable 成员

        public void Init(object sender, string[] @params)
        {
            return;
        }

        public int Save(object sender)
        {
            return 0;
        }

        public void RefreshUC(object sender, string[] @params)
        {
            return;
        }

        public int Valid(object sender)
        {
            return 0;
        }

        #endregion

        #region IUserControlable 成员


        public Control FocusedControl
        {
            get { return null; }
        }

        #endregion
    }

}
