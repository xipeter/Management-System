using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Account.Class
{
    public class Function
    {
        /// <summary>
        /// 根据身份证号获取生日
        /// </summary>
        /// <param name="idNO">身份证号</param>
        /// <returns></returns>
        public static string  GetBirthDayFromIdNO(string idNO,ref string err)
        {
            
            if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idNO, ref err) < 0)
            {
                return "-1";
            }
            if (idNO.Length == 15)
            {
                idNO = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            }
            string datestr = idNO.Substring(6, 8);
            string year = datestr.Substring(0, 4);
            string month = datestr.Substring(4, 2);
            string day = datestr.Substring(6, 2);
            datestr = year + "-" + month + "-" + day;
            return datestr;
        }
        /// <summary>
        /// 根据身份证号获取性别
        /// </summary>
        /// <param name="idNO">身份证号</param>
        /// <returns></returns>
        public static Neusoft.FrameWork.Models.NeuObject GetSexFromIdNO(string idNO,ref string err)
        {
            if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idNO, ref err) < 0)
            {
                return null;
            }

            if (idNO.Length == 15)
            {
                idNO = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            }

            int flag = Neusoft.FrameWork.Function.NConvert.ToInt32((idNO.Substring(16, 1)));
           FrameWork.Models.NeuObject sexobj = new Neusoft.FrameWork.Models.NeuObject();
            HISFC.Models.Base.SexEnumService sexlist = new Neusoft.HISFC.Models.Base.SexEnumService();
            if (flag % 2 == 0)
            {
                sexobj.ID = HISFC.Models.Base.EnumSex.F.ToString();
                sexobj.Name = sexlist.GetName(HISFC.Models.Base.EnumSex.F);
            }
            else
            {
                sexobj.ID = HISFC.Models.Base.EnumSex.M.ToString();
                sexobj.Name = sexlist.GetName(HISFC.Models.Base.EnumSex.M);
            }
            return sexobj;
        }
    }
}
