using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;
using System.Collections;
using Neusoft.HISFC.BizProcess.Interface.Order;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Registration;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.DefultInterfacesAchieve
{
    public class Pass : IReasonableMedicine
    {
        private string err = "";
        private bool passEnabled = false;
        private int stationType = 0;

        public int DoCommand(int commandType)
        {
            if (this.PassEnabled && (PassGetState("0") != 0))
            {
                return PassDoCommand(commandType);
            }
            return -4;
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassDoCommand(int commandNo);
        [DllImport("DIFPassDll.dll")]
        public static extern int PassGetState(string queryItemNo);
        public int PassGetStateIn(string queryItemNo)
        {
            return PassGetState(queryItemNo);
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassGetWarn(string drugUniqeCode);
        public int PassGetWarnFlag(string orderId)
        {
            if (this.PassEnabled && (PassGetState("0") != 0))
            {
                return PassGetWarn(orderId);
            }
            return -4;
        }

        public int PassGetWarnInfo(string orderId, string flag)
        {
            if (this.PassEnabled && (PassGetState("0") != 0))
            {
                PassSetWarnDrug(orderId);
                if (flag == "0")
                {
                    PassDoCommand(0x193);
                }
                else
                {
                    PassDoCommand(6);
                }
            }
            return 1;
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassInit(string userInfo, string deptInfo, int stationType);
        public int PassInit(string userID, string userName, string deptID, string deptName, int stationType)
        {
            return this.PassInit(userID, userName, deptID, deptName, stationType, true);
        }

        public int PassInit(string userID, string userName, string deptID, string deptName, int stationType, bool isJudgeLocalSetting)
        {
            Exception exception;
            Neusoft.HISFC.BizLogic.Manager.Controler controler = new Neusoft.HISFC.BizLogic.Manager.Controler();
            try
            {
                this.PassEnabled = NConvert.ToBoolean(controler.QueryControlerInfo("200014"));
            }
            catch (Exception exception1)
            {
                exception = exception1;
                this.err = exception.Message;
                this.PassEnabled = false;
                return -1;
            }
            if (!this.PassEnabled)
            {
                return 0;
            }
            if (isJudgeLocalSetting)
            {
                try
                {
                    ArrayList defaultValue = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("PassSetting", out this.err);
                    if ((defaultValue == null) || (defaultValue.Count == 0))
                    {
                        this.PassEnabled = false;
                    }
                    else if ((defaultValue[0] as string) == "1")
                    {
                        this.PassEnabled = true;
                    }
                    else
                    {
                        this.PassEnabled = false;
                    }
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    this.err = exception.Message;
                    this.PassEnabled = false;
                    return -1;
                }
                if (!this.PassEnabled)
                {
                    return 0;
                }
            }
            try
            {
                if (PassInit(userID + "/" + userName, deptID + "/" + deptName, stationType) == 0)
                {
                    this.err = "合理用药系统 初始化失败! 请与管理员联系";
                    return -1;
                }
                if (PassGetState("0") != 0)
                {
                    PassSetControlParam(1, 2, 0, 2, 1);
                }
            }
            catch (DllNotFoundException)
            {
                this.err = "未找到合理用药系统正常运行所需Dll 合理用药系统将无法正常启动！\n                 请与管理员联系";
                this.PassEnabled = false;
                return -1;
            }
            return 1;
        }

        public void PassQueryDrug(string drugCode, string drugName, string doseUnit, string useName, int left, int top, int right, int bottom)
        {
            if (this.PassEnabled)
            {
                PassSetQueryDrug(drugCode, drugName, doseUnit, useName);
                PassSetFloatWinPos(left, top, right, bottom);
                this.ShowFloatWin(true);
            }
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassQuit();
        public int PassQuitIn()
        {
            if (this.passEnabled && (PassGetState("0") != 0))
            {
                return PassQuit();
            }
            return -1;
        }

        public int PassSaveCheck(PatientInfo patient, List<Neusoft.HISFC.Models.Order.Inpatient.Order> alOrder, int checkType)
        {
            if (!this.PassEnabled)
            {
                return 0;
            }
            if ((alOrder == null) || (alOrder.Count == 0))
            {
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in alOrder)
            {
                if (order == null)
                {
                    this.err = "执行医嘱用药审查时出错! 发生类型转换错误";
                    return -1;
                }
                if ((order.Item.SysClass.ID.ToString().Substring(0, 1) == "P") && (order.Status != 3))
                {
                    try
                    {
                        this.PassSetRecipeInfo(order);
                    }
                    catch (Exception exception)
                    {
                        this.err = "合理用药审查传送医嘱数据过程中发生错误! " + exception.Message;
                        return -1;
                    }
                }
            }
            PassDoCommand(checkType);
            return 1;
        }

        public int PassSaveCheck(Register patient, List<Neusoft.HISFC.Models.Order.OutPatient.Order> alOrder, int checkType)
        {
            if (!this.PassEnabled)
            {
                return 0;
            }
            if ((alOrder == null) || (alOrder.Count == 0))
            {
                return -1;
            }
            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order order in alOrder)
            {
                if (order == null)
                {
                    this.err = "执行医嘱用药审查时出错! 发生类型转换错误";
                    return -1;
                }
                if ((order.Item.SysClass.ID.ToString().Substring(0, 1) == "P") && (order.Status != 3))
                {
                    try
                    {
                        this.PassSetRecipeInfo(order);
                    }
                    catch (Exception exception)
                    {
                        this.err = "合理用药审查传送医嘱数据过程中发生错误! " + exception.Message;
                        return -1;
                    }
                }
            }
            PassDoCommand(checkType);
            return 1;
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetAllergenInfo(string allergenIndex, string allergenCode, string allergenDesc, string allergenType, string reaction);
        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetControlParam(int saveCheckResult, int allowAllegen, int checkMode, int disqMode, int useDiposeIden);
        public int PassSetDrug(string drugCode, string drugName, string doseUnit, string routeName)
        {
            return PassSetQueryDrug(drugCode, drugName, doseUnit, routeName);
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetFloatWinPos(int left, int top, int right, int bottom);
        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetMedCond(string medCondIndex, string medCondCode, string medCondDesc, string medCondType, string startDate, string endDate);
        public void PassSetPatientInfo(PatientInfo patient, string docID, string docName)
        {
            if (((patient != null) && this.PassEnabled) && (PassGetState("0") != 0))
            {
                string str2;
                string patientNO = patient.PID.PatientNO;
                try
                {
                    str2 = NConvert.ToInt32(patient.ID.Substring(2, 2)).ToString();
                }
                catch
                {
                    str2 = "1";
                }
                string name = patient.Name;
                string sex = "";
                if ((patient.Sex.ID.ToString() == "F") || (patient.Sex.ID.ToString() == "M"))
                {
                    sex = patient.Sex.Name;
                }
                else
                {
                    sex = "未知";
                }
                string birthday = patient.Birthday.ToString("yyyy-MM-dd");
                string weight = patient.Weight;
                string height = patient.Height;
                string departMentName = patient.PVisit.PatientLocation.Dept.ID + "/" + patient.PVisit.PatientLocation.Dept.Name;
                string doctor = patient.PVisit.AdmittingDoctor.ID + "/" + patient.PVisit.AdmittingDoctor.Name;
                string leaveHospitalDate = "";
                PassDoCommand(0x192);
                PassSetPatientInfo(patientNO, str2, name, sex, birthday, weight, height, departMentName, doctor, leaveHospitalDate);
            }
        }

        public void PassSetPatientInfo(Register patient, string docID, string docName)
        {
            if (((patient != null) && this.PassEnabled) && (PassGetState("0") != 0))
            {
                string str2;
                string patientNO = patient.PID.PatientNO;
                try
                {
                    str2 = NConvert.ToInt32(patient.ID.Substring(2, 2)).ToString();
                }
                catch
                {
                    str2 = "1";
                }
                string name = patient.Name;
                string sex = "";
                if ((patient.Sex.ID.ToString() == "F") || (patient.Sex.ID.ToString() == "M"))
                {
                    sex = patient.Sex.Name;
                }
                else
                {
                    sex = "未知";
                }
                string birthday = patient.Birthday.ToString("yyyy-MM-dd");
                string weight = patient.Weight;
                string height = patient.Height;
                string departMentName = patient.PVisit.PatientLocation.Dept.ID + "/" + patient.PVisit.PatientLocation.Dept.Name;
                string doctor = patient.PVisit.AdmittingDoctor.ID + "/" + patient.PVisit.AdmittingDoctor.Name;
                string leaveHospitalDate = "";
                PassDoCommand(0x192);
                PassSetPatientInfo(patientNO, str2, name, sex, birthday, weight, height, departMentName, doctor, leaveHospitalDate);
            }
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetPatientInfo(string PatientID, string VisitID, string Name, string Sex, string Birthday, string Weight, string cHeight, string DepartMentName, string Doctor, string LeaveHospitalDate);
        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetQueryDrug(string drugCode, string drugName, string doseUnit, string routeName);
        public void PassSetRecipeInfo(Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            if (this.PassEnabled && ((order != null) && (order.Item.ItemType.ToString() != ItemTypes.Undrug.ToString())))
            {
                string applyNO = order.ApplyNo;
                //string iD = order.Item.ID;
                string iD = "Y00000001077";
                string name = order.Item.Name;
                string singleDose = order.DoseOnce.ToString();
                string doseUnit = order.DoseUnit;
                int length = 0;
                string str7 = "";
                if ((order.Frequency != null) && (order.Usage != null))
                {
                    if (order.Frequency.Time == null)
                    {
                        Neusoft.HISFC.BizLogic.Manager.Frequency frequency = new Neusoft.HISFC.BizLogic.Manager.Frequency();
                        order.Frequency = (Neusoft.HISFC.Models.Order.Frequency)frequency.Get(order.Frequency, "ROOT");
                        if (order.Frequency == null)
                        {
                            return;
                        }
                    }
                    if (order.Frequency.Time == null)
                    {
                        length = 1;
                    }
                    else
                    {
                        length = order.Frequency.Times.Length;
                    }
                    if (order.Frequency.Days == null)
                    {
                        str7 = "1";
                    }
                    else
                    {
                        str7 = order.Frequency.Days[0];
                    }
                    string str6 = length.ToString() + "/" + str7.ToString();
                    string startOrderDate = order.BeginTime.ToString("yyyy-MM-dd");
                    string stopOrderDate = "";
                    string routeName = order.Usage.Name;
                    string groupTag = order.Combo.ID;
                    string orderType = order.OrderType.ID;
                    string orderDoctor = order.Doctor.ID + "/" + order.Doctor.Name;
                    PassSetRecipeInfo(applyNO, iD, name, singleDose, doseUnit, str6, startOrderDate, stopOrderDate, routeName, groupTag, orderType, orderDoctor);
                }
            }
        }

        public void PassSetRecipeInfo(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            if (this.PassEnabled && ((order != null) && (order.Item.ItemType.ToString() != ItemTypes.Undrug.ToString())))
            {
                string applyNO = order.ApplyNo;
                //string iD = order.Item.ID;
                string iD = "Y00000001077";
                string name = order.Item.Name;
                string singleDose = order.DoseOnce.ToString();
                string doseUnit = order.DoseUnit;
                int length = 0;
                string str7 = "";
                if ((order.Frequency != null) && (order.Usage != null))
                {
                    if (order.Frequency.Time == null)
                    {
                        Neusoft.HISFC.BizLogic.Manager.Frequency frequency = new Neusoft.HISFC.BizLogic.Manager.Frequency();
                        order.Frequency = (Neusoft.HISFC.Models.Order.Frequency)frequency.Get(order.Frequency, "ROOT");
                        if (order.Frequency == null)
                        {
                            return;
                        }
                    }
                    if (order.Frequency.Time == null)
                    {
                        length = 1;
                    }
                    else
                    {
                        length = order.Frequency.Times.Length;
                    }
                    if (order.Frequency.Days == null)
                    {
                        str7 = "1";
                    }
                    else
                    {
                        str7 = order.Frequency.Days[0];
                    }
                    string str6 = length.ToString() + "/" + str7.ToString();
                    string startOrderDate = order.BeginTime.ToString("yyyy-MM-dd");
                    string stopOrderDate = "";
                    string routeName = order.Usage.Name;
                    string groupTag = order.Combo.ID;
                    string orderType = "1";
                    string orderDoctor = order.Doctor.ID + "/" + order.Doctor.Name;
                    PassSetRecipeInfo(applyNO, iD, name, singleDose, doseUnit, str6, startOrderDate, stopOrderDate, routeName, groupTag, orderType, orderDoctor);
                }
            }
        }

        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetRecipeInfo(string OrderUniqueCode, string DrugCode, string DrugName, string SingleDose, string DoseUnit, string Frequency, string StartOrderDate, string StopOrderDate, string RouteName, string GroupTag, string OrderType, string OrderDoctor);
        [DllImport("DIFPassDll.dll")]
        public static extern int PassSetWarnDrug(string drugUniqueCode);
        [DllImport("ShellRunAs.dll")]
        public static extern int RegisterServer();
        public void ShowFloatWin(bool isShow)
        {
            if (this.PassEnabled && (PassGetState("0") != 0))
            {
                if (isShow)
                {
                    PassDoCommand(0x191);
                }
                else
                {
                    PassDoCommand(0x192);
                }
            }
        }

        public string Err
        {
            get
            {
                return this.err;
            }
            set
            {
                this.err = value;
            }
        }

        public bool PassEnabled
        {
            get
            {
                return this.passEnabled;
            }
            set
            {
                this.passEnabled = value;
            }
        }

        public int StationType
        {
            get
            {
                return this.stationType;
            }
            set
            {
                this.stationType = value;
            }
        }
    }
}
