using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.EPRControl
{
    /// <summary>
    /// 用户控件接口
    /// </summary>
    public interface IUserControlable
    {

        //装载
        void Init(object sender, string[] @params);

        //保存
        int Save(object sender);

        //当前是否打印
        bool IsPrint
        {
            get;
            set;
        }

        //刷新
        void RefreshUC(object sender, string[] @params);

        //判断
        int Valid(object sender);

        System.Windows.Forms.Control FocusedControl { get;}

       
    }


}
