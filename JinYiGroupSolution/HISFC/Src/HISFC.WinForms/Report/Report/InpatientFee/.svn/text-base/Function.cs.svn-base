using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.WinForms.Report.InpatientFee
{
    class Function
    {
        private static Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #region 住院取部分支付方式
        /// <summary>
        /// 发票只打印大写数字 打印到十万
        /// </summary>
        /// <param name="Cash"></param>
        /// <returns></returns>
        public static string[] GetUpperCashNumberByNumber(decimal Cash)
        {
            string[] sNumber = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string[] sReturn = new string[9];
            string strCash = null;
            //填充位数
            int iLen = 0;
            strCash = Neusoft.FrameWork.Public.String.FormatNumber(Cash, 2).ToString("############.00");
            if (strCash.Length > 9)
            {
                strCash = strCash.Substring(strCash.Length - 9);
            }

            //填充位数
            iLen = 9 - strCash.Length;
            for (int j = 0; j < iLen; j++)
            {
                int k = 0;
                k = 8 - j;
                sReturn[k] = "零";
            }
            for (int i = 0; i < strCash.Length; i++)
            {
                string Temp = null;

                Temp = strCash.Substring(strCash.Length - 1 - i, 1);

                if (Temp == ".")
                {
                    continue;
                }
                sReturn[i] = sNumber[int.Parse(Temp)];
            }
            return sReturn;
        }
        /// <summary>
        /// 获得指定名称输入框
        /// </summary>
        /// <param name="n">名称</param>
        /// <returns>费用名称输入框控件</returns>
        public static System.Windows.Forms.Label GetFeeNameLable(string n, System.Windows.Forms.Control control)
        {
            foreach (System.Windows.Forms.Control c in control.Controls)
            {
                if (c.Name == n)
                {
                    return (System.Windows.Forms.Label)c;
                }
            }
            return null;
        }
        /// <summary>
        /// 发票只打印大写数字 打印到十万
        /// </summary>
        /// <param name="Cash"></param>
        /// <returns></returns>
        public static string GetUpperCashByNumber(decimal Cash)
        {
            #region 大写总金额
            string returnValue = string.Empty;
            string[] strMoney = new string[8];
            //---------------------------|\*/|-----这个＂点＂字没有用，纯属凑数！
            string[] unit = { "分", "角", "点", "元", "拾", "佰", "仟", "万", "十万" };
            strMoney = GetUpperCashNumberByNumber(Neusoft.FrameWork.Public.String.FormatNumber(Cash, 2));
            bool isStart = false;
            string tempDaXie = string.Empty;
            for (int i = 0; i < strMoney.Length; i++)
            {
                #region 从非零位开始打印
                if (!isStart)
                {
                    if (strMoney[i] != "零")
                    {
                        isStart = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                #endregion
                if (strMoney[i] != null)
                {
                    if (strMoney[i] != "零")
                    {
                        tempDaXie = strMoney[i] + unit[i] + tempDaXie;
                        returnValue = tempDaXie + returnValue;
                        tempDaXie = string.Empty;
                    }
                    else
                    {
                        tempDaXie = "零";
                    }
                }
            }
            return returnValue;
            #endregion
        }

        /// <summary>
        /// 通过结算方式找id
        /// </summary>
        /// <param name="payTypeName"></param>
        /// <returns></returns>
        public static string GetPayTypeIdByName(string payTypeName)
        {
            ArrayList al = new ArrayList();
            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            //al = Neusoft.HISFC.Models.Fee.EnumPayTypeService.List();
            al = managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);
            for (int i = 0; i < al.Count; i++)
            {
                //Neusoft.HISFC.Models.Fee.EnumPayTypeService payType = new Neusoft.HISFC.Models.Fee.EnumPayTypeService();
                //payType = (EnumPayTypeService)al[i];
                if (((Neusoft.FrameWork.Models.NeuObject)al[i]).Name == payTypeName) return ((Neusoft.FrameWork.Models.NeuObject)al[i]).ID;
            }
            return null;
        }
        /// <summary>
        /// 通过银行名称获取银行id
        /// </summary>
        /// <param name="bankName">银行名称</param>
        /// <returns>银行ID</returns>
        public static string GetBankIdByName(string bankName)
        {
            ArrayList al = new ArrayList();
            al = managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BANK);
            if (al == null || al.Count <= 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("获取银行列表失败!", 211);
                return null;
            }

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj;
                obj = (Neusoft.FrameWork.Models.NeuObject)al[i];
                if (obj.Name == bankName) return obj.ID;
            }
            return null;


        }

        #endregion

        #region "大写"
        /// <summary>
        /// 
        /// </summary>
        private static readonly string cnNumber = "零壹贰叁肆伍陆柒捌玖";
        private static readonly string cnUnit = "分角元拾佰仟万拾佰仟亿拾佰仟兆拾佰仟";
        private static readonly string[] enSmallNumber = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static readonly string[] enLargeNumber = { "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        private static readonly string[] enUnit = { "", "THOUSAND", "MILLION", "BILLION", "TRILLION" };
        // 最大转化金额         9999999999999999.99  （16位整数位，2位小数位）

        // 方法返回值           转换成功则返回非零长字串,否则返回零长字串

        // 静态英文转换方法     string GetEnString(string MoneyString)
        // 最大转化金额         999999999999999.99   （15位整数位，2位小数位）

        // 方法返回值           转换成功则返回非零长字串,否则返回零长字串


        // 以下是货币金额中文大写转换方法

        public static string ConvertNumberToChineseMoneyString(string MoneyString)
        {
            string[] tmpString = MoneyString.Split('.');
            string intString = MoneyString;   // 默认为整数

            string decString = "";            // 保存小数部分字串
            string rmbCapital = "";            // 保存中文大写字串
            int k;
            int j;
            int n;

            if (tmpString.Length > 1)
            {
                intString = tmpString[0];             // 取整数部分

                decString = tmpString[1];             // 取小数部分

            }
            decString += "00";
            decString = decString.Substring(0, 2);   // 保留两位小数位

            intString += decString;

            try
            {
                k = intString.Length - 1;
                if (k > 0 && k < 18)
                {
                    for (int i = 0; i <= k; i++)
                    {
                        j = (int)intString[i] - 48;
                        // rmbCapital = rmbCapital + cnNumber[j] + cnUnit[k-i];     // 供调试用的直接转换

                        n = i + 1 >= k ? (int)intString[k] - 48 : (int)intString[i + 1] - 48; // 等效于 if( ){ }else{ }
                        if (j == 0)
                        {
                            if (k - i == 2 || k - i == 6 || k - i == 10 || k - i == 14)
                            {
                                rmbCapital += cnUnit[k - i];
                            }
                            else
                            {
                                if (n != 0)
                                {
                                    rmbCapital += cnNumber[j];
                                }
                            }
                        }
                        else
                        {
                            rmbCapital = rmbCapital + cnNumber[j] + cnUnit[k - i];
                        }
                    }

                    rmbCapital = rmbCapital.Replace("兆亿万", "兆");
                    rmbCapital = rmbCapital.Replace("兆亿", "兆");
                    rmbCapital = rmbCapital.Replace("亿万", "亿");
                    rmbCapital = rmbCapital.TrimStart('元');
                    rmbCapital = rmbCapital.TrimStart('零');

                    return rmbCapital;
                }
                else
                {
                    return "";   // 超出转换范围时，返回零长字串
                }
            }
            catch
            {
                return "";   // 含有非数值字符时，返回零长字串

            }
        }

        #endregion

        #region 判断就诊卡号第一个字符是否含有字符

        /// <summary>
        /// 判断就诊卡号第一个字符是否含有字符

        /// </summary>
        /// <param name="CarNO">得到就诊卡号</param>
        /// <returns></returns>
        public static string GetCarNO(string CarNO)
        {
            if (!Char.IsNumber(CarNO, 0))
            {
                string FirtrLeter = CarNO.Substring(0, 1).ToUpper();
                string TempStr = CarNO.Substring(1, CarNO.Length - 1);
                TempStr = TempStr.PadLeft(9, '0');
                CarNO = FirtrLeter + TempStr;
            }
            else
            {
                CarNO = CarNO.PadLeft(10, '0');
            }
            return CarNO;
        }
        #endregion
    }

}
