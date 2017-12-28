using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Neusoft.FrameWork.EPRControl
{
 
  [System.Drawing.ToolboxBitmap(typeof(RichTextBox))]
   public  partial class emrMultiLineTextBox1 : RichTextBox, IGroup
  {
        /// <summary>
        /// Struct Function
        /// </summary>
        public emrMultiLineTextBox1()
        {
            base.HideSelection = false;
            base.Font = new System.Drawing.Font("宋体", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            try
            {
                mnuCut.Click += onCut;
                mnuCopy.Click += onCopy;
                mnuPaste.Click += onPaste;
                mnuUndo.Click += onUndo;
                mnuRedo.Click += onRedo;
                cMenu.MenuItems.Add(mnuUndo);
                cMenu.MenuItems.Add(mnuRedo);
                cMenu.MenuItems.Add(mnuSplit);
                cMenu.MenuItems.Add(mnuCut);
                cMenu.MenuItems.Add(mnuCopy);
                cMenu.MenuItems.Add(mnuPaste);
               // this.ContextMenu = cMenu;
            }
            catch (Exception ex) { }
        }

    #region "组"

    private string ControlName;
    /// <summary>
    /// 组名
    /// </summary>
    private string GroupName = "无";
    private bool blnIsGroup;
    /// <summary>
    /// 是否分组
    /// </summary>
    private bool bIsGroup;
    private System.EventArgs e;
    public event NameChangedEventHandler NameChanged;
    public event IsGroupChangedEventHandler IsGroupChanged;
    public event GroupChangedEventHandler GroupChanged;

 
   [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
   public string 名称 
   {
    get 
      {
        if (this.ControlName == "")
        {
            this.ControlName = this.Name;
        }
       return this.ControlName;
      }
    set
      {
        if (CheckValue(value, 0) == false) return; 
        ControlName = value.Trim();
        try 
        {
            if (NameChanged != null) 
            {
                NameChanged(this, e);
            }
        }
        catch (Exception ex)
        {

        }

      }
    }
    [TypeConverter(typeof(emrGroup)),Browsable(true), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
    public string 组 
    {
    get { return this.GroupName; }
    set 
      {
        if (CheckValue(value, 1) == false) return; 
            this.GroupName = value.Trim();
        try {
            if (GroupChanged != null) 
             {
                GroupChanged(this, e);
             }
            }

        catch (Exception ex) {}
      }
    }
 
    [CategoryAttribute("设计"),Browsable(false), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!")]
    public bool 是否组 {
        get { return this.bIsGroup; }
        set 
        {
            this.bIsGroup = value;
            try
            {
                if (IsGroupChanged != null) 
                {
                    IsGroupChanged(this, e);
                }
            }
            catch (Exception ex) { }
        }
    }
    private bool CheckValue(string value, int i)
    {
        bool right = true;
        if (value == null || value == "") return false;
        if ((value.Trim() == "")) right = false; 
        if ((value.IndexOf("\\") >= 0)) right = false; 
        if ((value.IndexOf("/") >= 0)) right = false; 
        if ((value.IndexOf(">") >= 0)) right = false; 
        if ((value.IndexOf("<") >= 0)) right = false; 
        if ((value.IndexOf("=") >= 0)) right = false; 
        if ((value.IndexOf(".") >= 0)) right = false; 
        if ((value.IndexOf(",") >= 0)) right = false; 
        if ((value.IndexOf("%") >= 0)) right = false; 
        if (i == 0)
        {
            //名称
            if ((value == this.GroupName))
            {
                MessageBox.Show("名称和组不能同名！");
                return false;
            }
        }
        else
        {
            if (value == this.ControlName)
            {
                MessageBox.Show("名称和组不能同名！");
                return false;
            }
        }
        if (!right)
            {
            MessageBox.Show("不能包含非法字符！");
            }
            return right;
    }
    #endregion

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
    private ContextMenu cMenu = new ContextMenu();
    MenuItem mnuUndo = new MenuItem("撤销");
    MenuItem mnuRedo = new MenuItem("恢复");
    MenuItem mnuSplit = new MenuItem("-");
    MenuItem mnuCut = new MenuItem("减切(&X)");
    MenuItem mnuCopy = new MenuItem("复制(&C)");
    MenuItem mnuPaste = new MenuItem("粘贴(&P)");

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {

        if ((e.Button == MouseButtons.Right))
        {
            if (this.SelectedText == "")
            {
                mnuCut.Enabled = false;
            }
            else
            {
                mnuCut.Enabled = true;
            }
       

            if (this.CanUndo)
            {
                mnuUndo.Enabled = true;
            }
            else
            {
                mnuUndo.Enabled = false;
            }
            if (this.CanRedo)
            {
                mnuRedo.Enabled = true;
            }
            else
            {
                mnuRedo.Enabled = false;
            }
        }
            base.OnMouseDown(e);
    }
    private void onUndo(object sender, System.EventArgs e)
    {
        this.Undo();
    }
    private void onRedo(object sender, System.EventArgs e)
    {
        this.Redo();
    }
    private void onCut(object sender, System.EventArgs e)
    {
        this.Cut();
    }
    private void onCopy(object sender, System.EventArgs e)
    {
        this.Copy();
    }
    private void onPaste(object sender, System.EventArgs e)
    {
        this.Paste();
    }
    protected override void OnSizeChanged(System.EventArgs e)
    {
        if ((base.Height < 40))
        {
        base.Multiline = false;
        }
        else
        {
        base.Multiline = true;
        }
    }
       protected override void OnMouseUp(MouseEventArgs mevent)
       {
           if (mevent.Button == MouseButtons.Right)
           {
               base.OnMouseUp(mevent);
               
           }
       }
       protected override void OnMouseMove(MouseEventArgs e)
       {
           if (e.Button == MouseButtons.Right)
           {
               base.OnMouseMove(e);               
           }
       }
  }

}
