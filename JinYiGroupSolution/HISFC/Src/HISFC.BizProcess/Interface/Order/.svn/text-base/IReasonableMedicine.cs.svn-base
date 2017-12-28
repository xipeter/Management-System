using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Registration;

namespace Neusoft.HISFC.BizProcess.Interface.Order
{
    public interface IReasonableMedicine
    {
        int DoCommand(int commandType);
        int PassGetStateIn(string queryItemNo);
        int PassGetWarnFlag(string orderId);
        int PassGetWarnInfo(string orderId, string flag);
        int PassInit(string userID, string userName, string deptID, string deptName, int stationType, bool isJudgeLocalSetting);
        void PassQueryDrug(string drugCode, string drugName, string doseUnit, string useName, int left, int top, int right, int bottom);
        int PassQuitIn();
        int PassSaveCheck(PatientInfo patient, List<Neusoft.HISFC.Models.Order.Inpatient.Order> listOrder, int checkType);
        int PassSaveCheck(Register patient, List<Neusoft.HISFC.Models.Order.OutPatient.Order> listOrder, int checkType);
        int PassSetDrug(string drugCode, string drugName, string doseUnit, string routeName);
        void PassSetPatientInfo(PatientInfo patient, string docID, string docName);
        void PassSetPatientInfo(Register patient, string docID, string docName);
        void PassSetRecipeInfo(Neusoft.HISFC.Models.Order.Inpatient.Order order);
        void PassSetRecipeInfo(Neusoft.HISFC.Models.Order.OutPatient.Order order);
        void ShowFloatWin(bool isShow);

        string Err
        {
            get;
            set;
        }

        bool PassEnabled
        {
            get;
            set;
        }

        int StationType
        {
            get;
            set;
        }
    }
}
