using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.FrameWork.EPRControl
{
    public class Module
    {
        //判断字符是否符合故则
        //true 符合,false 不符合
        public static bool ValidName(string s)
        {
            bool wrong=false;
            if ((s.Trim() == "")) wrong = true;
            if ((s.IndexOf("\\") >= 0)) wrong = true;
            if ((s.IndexOf("/") >= 0)) wrong = true;
            if ((s.IndexOf(">") >= 0)) wrong = true;
            if ((s.IndexOf("<") >= 0)) wrong = true;
            if ((s.IndexOf("=") >= 0)) wrong = true;
            if ((s.IndexOf(".") >= 0)) wrong = true;
            if ((s.IndexOf(",") >= 0)) wrong = true;
            if ((s.IndexOf("%") >= 0)) wrong = true;
            if (wrong)
            {
                MessageBox.Show("名称不能包含非法字符！", "显示", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        //判断合法性
        public static bool ValidText(string s)
        {
            if ((s.Trim() == "-" | s.Trim() == ""))
            {
                return false;
            }
            return true;
        }
    }

}
