using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Neusoft.FrameWork.EPRControl
{
    public  delegate void NameChangedEventHandler(object sender, System.EventArgs e);
    public  delegate void GroupChangedEventHandler(object sender, System.EventArgs e); 
    public  delegate void IsGroupChangedEventHandler(object sender, System.EventArgs e);
    /// <summary>
    /// 组接口
    /// </summary>
    public interface IGroup
    {
        event NameChangedEventHandler NameChanged;
        event IsGroupChangedEventHandler IsGroupChanged;
        event GroupChangedEventHandler GroupChanged;     

        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
        string 名称
        {
            get;
            set;
        }
        [TypeConverter(typeof(emrGroup)), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
        string 组
        {
            get;
            set;
        }      
       
        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!")]
        bool 是否组
        {
            get;
            set;
        }
        [ CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("Snomed编码")]
        string Snomed
        {
            get;
            set;
        }    
    }
}
