using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.FrameWork.EPRControl
{

    //-------------------------------
    //病历功能控件
    //
    //-------------------------------

    public partial class emrNode : System.Windows.Forms.Panel, IUserControlable,IGroup
    {

	    #region " Windows 窗体设计器生成的代码 "

	    public emrNode() : base()
	    {
            this.InitializeComponent();
		    base.Tag = emrNode.UserTag;
            this.panelCheckBox.CheckedChanged+=new EventHandler(panelCheckBox_CheckedChanged);
            this.ComboBox1.SelectedIndexChanged+=new EventHandler(ComboBox1_SelectedIndexChanged);

	    }

	    //注意: 以下过程是 Windows 窗体设计器所必需的
	    //可以使用 Windows 窗体设计器修改此过程。
	    //不要使用代码编辑器修改它。
	    internal System.Windows.Forms.ComboBox ComboBox1;
	    internal System.Windows.Forms.Label Label1;
	    internal System.Windows.Forms.Panel panelCombox;
	    internal System.Windows.Forms.CheckBox panelCheckBox;
        public event NameChangedEventHandler NameChanged;
        public event IsGroupChangedEventHandler IsGroupChanged;
        public event GroupChangedEventHandler GroupChanged;
	   
	    #endregion
	    private string strType = "ComboBox";
	    private string strText;
	    private string strTrueText = "有";

	    //用户控件，不可操作
	    public static string UserTag = "EMRGRIDLINE";

	    private void changeType()
	    {
		    if ((strType == "ComboBox"))
		    {
			    this.panelCheckBox.Visible = false;
			    this.panelCombox.Visible = true;
		    }
            else if ((strType == "CheckBox"))
            {
			    this.panelCombox.Visible = false;
			    this.panelCheckBox.Visible = true;
		    }
		    else
		    {
			    System.Windows.Forms.MessageBox.Show("未知类型");
		    }
	    }

	    [CategoryAttribute("布局"), DescriptionAttribute("提示文本大小")]
	    public System.Drawing.Size InnerSize
        {
		    get 
            {
                if (strType == "ComboBox")
                {
                    return this.panelCombox.Size;
                }
                else if (strType == "CheckBox")
                {
                    return this.panelCheckBox.Size;
                }
                return new System.Drawing.Size();//zgx
         
		    }
		    set
            {
			    if (strType == "ComboBox")
			    {
				    this.panelCombox.Size = value;
			    }
                else if (strType == "CheckBox")
                {
				    this.panelCheckBox.Size = value;
			    }
		    }
	    }
	    [CategoryAttribute("下拉列表选项"), DescriptionAttribute("下拉列表默认文本")]
	    public string ComboBoxDefaultText 
        {
		    get { return this.ComboBox1.Text; }
		    set 
            {
			    this.ComboBox1.Text = value;
			    this.ComboBox1_SelectedIndexChanged(this.ComboBox1, null);
		    }
	    }

	    [CategoryAttribute("下拉列表选项"), DescriptionAttribute("下拉列表阳性文本，可用|来进行分割")]
	    public string ComboBoxTrueText 
        {
		    get { return this.strTrueText; }
		    set { this.strTrueText = value; }
	    }
	    [CategoryAttribute("下拉列表选项"), DescriptionAttribute("下拉列表文本")]
	    public string[] ComboBoxList {
		    get {
			    if ((this.ComboBox1.Items.Count == 0))
			    {
				    this.ComboBox1.Items.Add(" ");
			    }
			    string[] s = new string[this.ComboBox1.Items.Count];
			    int  i;
			    for (i = 0; i <= this.ComboBox1.Items.Count - 1; i++) 
                {
				    s[i] = this.ComboBox1.Items[i].ToString();
			    }
			    return s;
		    }
		    set {
			    int i = 0;
			    this.ComboBox1.Items.Clear();
			    for (i = 0; i <= value.Length - 1; i++) {
				    this.ComboBox1.Items.Add(value[i]);
			    }
		    }
	    }
	    [CategoryAttribute("设计"), DescriptionAttribute("提示文本"), Browsable(true)]
	    public new string Text
        {
		    get
            {
			    if ((strType == "ComboBox"))
			    {
				    //combobox 提示文本
				    return this.Label1.Text;
			    }
                else if ((strType == "CheckBox"))
                {
				    return this.panelCheckBox.Text;
			    }
                return "";
		    }
		    set 
            {
			    strText = value;
			    this.Label1.Text = value;
			    this.panelCheckBox.Text = value;
		    }
	    }

	    [TypeConverter(typeof(emrNodeType)), CategoryAttribute("设计"), DefaultValue("ComboBox"), DescriptionAttribute("选择控件模式")]
	    public string Type 
        {
		    get { return this.strType; }
		    set 
            {
			    this.strType = value;
			    changeType();
		    }
	    }
	    private bool bPrint = false;
	    //打印
	    public bool IsPrint 
        {
		    get { return bPrint; }
		    set {
			    bPrint = value;
			    if ((bTrue)) return; 
			    //如果是有条件，不限制打印
			    foreach (Control c in this.Controls) {
				    if ((object.ReferenceEquals(c, this.panelCheckBox)) || object.ReferenceEquals(c, this.panelCombox))
				    {
				    }
				    else
				    {
					    c.Visible = !value;
				    }
			    }
		    }
	    }

	  

	    #region "组"
        
	    private string myName;
	    [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
	    public string 名称 
        {
		    get { return myName; }
		    set {
			    if ((Module.ValidName(value)) == false) return; 
			    this.myName = value;
			    try {
				    if (NameChanged != null) {
					    NameChanged(this, null);
				    }
			    }
			    catch {
			    }

		    }
	    }
	    private bool bGroup;
	    [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!"), Browsable(false)]
	    public bool 是否组 {
		    get { return bGroup; }
		    set {

			    this.bGroup = value;
			    try {
				    if (IsGroupChanged != null) {
					    IsGroupChanged(this, null);
				    }
			    }
			    catch {}
		    }
	    }
	    private string strGroup;
	    [TypeConverter(typeof(emrGroup)), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
	    public string 组 {
		    get { return strGroup; }
		    set {
			    strGroup = value;
			    try {
				    if (GroupChanged != null) {
					    GroupChanged(this, null);
				    }
			    }
			    catch {}
		    }
	    }
	    #endregion
	    private bool bTrue = false;
	    private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
	    {
		    if (this.strType == "ComboBox")
		    {
			    string[] s = strTrueText.Split('|');
			    Int16 i;
			    for (i = 0; i <= s.Length - 1; i++) {
				    if ((this.ComboBox1.Text == s[i]))
				    {
					    bTrue = true;
				    }
				    else
				    {
					    bTrue = false;
				    }
                    foreach (Control c in this.Controls)
                    {
					    if ((object.ReferenceEquals(c, this.panelCheckBox)) | object.ReferenceEquals(c, this.panelCombox))
					    {
					    }
					    else
					    {
						    c.Enabled = bTrue;
					    }
				    }
				    if (bTrue) return; 
			    }
		    }
            else if (this.strType == "CheckBox") 
                {

		        }
	    }

	    private void panelCheckBox_CheckedChanged(object sender, System.EventArgs e)
	    {
		    if (this.strType == "ComboBox")
		    {
		    }

            else if (this.strType == "CheckBox") {
			    bTrue = this.panelCheckBox.Checked;
			    foreach (Control c in this.Controls) {
				    if ((object.ReferenceEquals(c, this.panelCheckBox)) | object.ReferenceEquals(c, this.panelCombox))
				    {
				    }
				    else
				    {
					    c.Enabled = this.panelCheckBox.Checked;
				    }
			    }
		    }

	    }

        #region Snomed 成员

        string snomed = "";
        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("Snomed编码")]
        public string Snomed
        {
            get
            {
                return snomed;
            }
            set
            {
                snomed = value;

            }
        }

        #endregion


        #region IUserControlable 成员

        public void Init(object sender, string[] @params)
        {
            
        }

        public int Save(object sender)
        {
            return 0;
        }

        public void RefreshUC(object sender, string[] @params)
        {
           
        }

        public int Valid(object sender)
        {
            return 0;
        }

        #endregion

        #region IUserControlable 成员


        public Control FocusedControl
        {
            get { return this.ComboBox1; }
        }

        #endregion
    }

}
