using System;
using System.Collections.Generic;
using System.Text;

namespace ReadMarkNO
{
    public class ReadMarkNO : Neusoft.HISFC.BizLogic.Fee.IReadMarkNO
    {
        Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.FrameWork.Management.ControlParam ctlParam = new Neusoft.FrameWork.Management.ControlParam();
        public int ReadMarkNOByRule(string markNO, ref Neusoft.HISFC.Models.Account.AccountCard accountCard)
        {
            string validedMarkNo = string.Empty;
            Neusoft.FrameWork.Models.NeuObject markType = null;
            if (markNO == string.Empty)
            {
                this.error = "请输入就诊卡号！";
                return -1;
            }

            //取卡规则 0 表示用病历号做卡号
            string returnValue = this.ctlParam.QueryControlerInfo("800006");

            if (string.IsNullOrEmpty(returnValue))
            {
                returnValue = "0";
            }

            if (returnValue != "0")
            {

                if (markNO.Length < 3)
                {
                    this.error = "输入的卡号不正确，请重新输入！";
                    return -1;
                }

                string firstleter = markNO.Substring(0, 1);
                if (firstleter != ";")
                {
                    this.error = "输入的卡号不正确，请重新输入！";
                    return -1;
                }
                string lastleter = markNO.Substring(markNO.Length - 1, 1);
                if (lastleter != "?")
                {
                    this.error = "输入的卡号不正确，请重新输入！";
                    return -1;
                }

                validedMarkNo = markNO.Substring(1, markNO.Length - 2);
                foreach (char c in validedMarkNo)
                {
                    if (!char.IsNumber(c))
                    {
                        this.error = "输入的卡号不正确，请重新输入！";
                        return -1;
                    }
                }
                
                accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                //卡类型根据在常数维护中维护的编码和名称要对照上
                markType = new Neusoft.FrameWork.Models.NeuObject();
                markType.ID = "1";
                markType.Name = "条码卡";
            }
            else
            {
                validedMarkNo = markNO.PadLeft(10, '0');
                markType = new Neusoft.FrameWork.Models.NeuObject();
                markType.ID = "0";
                markType.Name = "就诊卡";
            }
            accountCard = accountManager.GetAccountCard(validedMarkNo, markType.ID);
            //卡未发放
            if (accountCard == null || !accountCard.IsValid)
            {
                accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                accountCard.MarkNO = validedMarkNo;
                accountCard.MarkType = markType;
                this.error = "该卡还未发放或该卡已停用！";
                return 0;
            }


            Neusoft.HISFC.Models.RADT.PatientInfo patient = radtIntegrate.QueryComPatientInfo(accountCard.Patient.PID.CardNO);
            accountCard.Patient = patient;
            return 1;
        }
        private string error = string.Empty;
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
            }
        }
    }
}
