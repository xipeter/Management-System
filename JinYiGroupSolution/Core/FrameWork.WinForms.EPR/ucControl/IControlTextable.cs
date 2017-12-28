using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.FrameWork.EPRControl
{
    public interface IControlTextable
    {

        Control  FocedControl
        {
            get;
        }

        //返回QC实体
        ArrayList GetQCData();

        event EventHandler Enter;

        //当前rtf
        string Rtf
        {
            get;
            set;
        }

        //Super文本
        string SuperText
        {
            get;
            set;
        }

        //一级医生修改
        string Level1Rtf
        {
            get;
            set;
        }

        //二级医生修改
        string Level2Rtf
        {
            get;
            set;
        }

        //显示一级医生修改信息
        void ShowLevel1Text();

        //显示二级医生修改信息
        void ShowLevel2Text();

        //显示三级医生修改信息
        void ShowLevel3Text();

        //是否保存Super文本
        bool IsOnSaveSuperText
        {
            get;
            set;
        }
    }

}
