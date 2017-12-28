using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace Neusoft.DefultInterfacesAchieve.Common
{
    public class Pacs:Neusoft.HISFC.BizProcess.Interface.Common.IPacs
    {
        private string operationMode = "2";

        private string pacsViewType = "1";
        private string errCode = string.Empty;

        private string errMsg = string.Empty;
        #region 调用DLL
        /*曾经尝试把dll放入一个文件夹中，实际运行报错，没办法只能放在根目录*/
        /// <summary>
        /// 动态库初始化方法
        /// </summary>
        /// <returns></returns>
        [DllImport("joint.dll")]
        public static extern bool PacsInitialize();


        /// <summary>
        /// 动态库释放方法
        /// </summary>
        /// <returns></returns>
        [DllImport("joint.dll")]
        public static extern void PacsRelease();

        /// <summary>
        /// 结果查询
        /// </summary>
        /// <param name="nPatientType">患者编号类型：1 门诊，2 住院，3 处方号，4 社保号</param>
        /// <param name="lpszID">患者编号</param>
        /// <param name="nImageType">图像类型：1 图像，2 报告</param>
        /// <returns></returns>
        [DllImport("joint.dll")]
        public static extern int PacsView(int nPatientType, StringBuilder lpszID, int nImageType);

        //add TK 改为门诊{6684E838-EEB3-45b9-A77A-DC1A1251EC24} 2011-03-02
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();

        #endregion
        #region IPacs 成员

        public bool CheckOrder(Neusoft.HISFC.Models.Order.Order Order)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public int Connect()
        {
            //add TK 改为门诊{6684E838-EEB3-45b9-A77A-DC1A1251EC24} 2011-03-02
            /*bool iReturn = false;
            try
            {
                FrameWork.WinForms.Classes.Function.ShowWaitForm(FrameWork.Management.Language.Msg("初始化pacs接口！" ));
                iReturn = PacsInitialize();
                if (iReturn == true)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(FrameWork.Management.Language.Msg("pacs接口初始化失败！" + ex.Message));
                return -1;
            }
            finally
            {
                FrameWork.WinForms.Classes.Function.HideWaitForm();
            }*/
            return 1;
        }

        public int Disconnect()
        {
            int iReturn = 0;

            PacsRelease();

            return iReturn;
        }

        public string ErrCode
        {
            get
            {
                return this.errCode;
            }
            set
            {
                this.errCode = value;
            }
        }

        public string ErrMsg
        {
            get
            {
                return this.errMsg;
            }
            set
            {
                this.errMsg = value;
            }
        }

        public bool IsReportValid(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  1 , 门诊    2 , 住院  
        /// </summary>
        public string OprationMode
        {
            get
            {
                return this.operationMode;
            }
            set
            {
                this.operationMode = value;
            }
        }
        /// <summary>
        /// pacs结果察看类型1：图像2：报告
        /// </summary>
        public string PacsViewType
        {
            get
            {
                return this.pacsViewType;
            }
            set
            {
                this.pacsViewType = value;
            }
        }

        public int PlaceOrder(List<Neusoft.HISFC.Models.Order.Order> OrderList)
        {
            throw new NotImplementedException();
        }

        public int PlaceOrder(Neusoft.HISFC.Models.Order.Order Order)
        {
            throw new NotImplementedException();
        }

        public string[] QueryResult(string PatientNo)
        {
            throw new NotImplementedException();
        }

        public int Rollback()
        {
            throw new NotImplementedException();
        }

        public int SetPatient(Neusoft.HISFC.Models.RADT.Patient Patient)
        {
            throw new NotImplementedException();
        }

        public void SetTrans(System.Data.IDbTransaction t)
        {
            throw new NotImplementedException();
        }

        public void ShowForm()
        {
            throw new NotImplementedException();
        }

        public int ShowResult(string id)
        {
            throw new NotImplementedException();
        }
        //add TK 改为门诊{6684E838-EEB3-45b9-A77A-DC1A1251EC24} 2011-03-02
        private void DataLoad(string strInpNo)
        {
            string urll = this.ctlMgr.QueryControlerInfo("Pacs");
            if (string.IsNullOrEmpty(urll))
            {
                urll = "http://169.1.99.10/histopacs.aspx?clinic_id=";
            }
            if (strInpNo.Length > 0)
            {
                try
                {
                    KillProcess("IEXPLORE.EXE");

                    System.Diagnostics.Process.Start("IEXPLORE.EXE", urll + strInpNo);
                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
        }
        public void KillProcess(string processName)
        {
            //获得进程对象，以用来操作   
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程    
            try
            {
                //获得需要杀死的进程名   
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(processName))
                {
                    //立即杀死进程   
                    thisproc.Kill();
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
        }
        public int ShowResultByPatient(string PatientNo)
        {
            //add TK 改为门诊{6684E838-EEB3-45b9-A77A-DC1A1251EC24} 2011-03-02
            /*#region 取配置参数
            ArrayList defaultValue = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("pacs");
            if ((defaultValue == null) || (defaultValue.Count == 0))
            {
               
            }
            else 
            {
                this.pacsViewType = defaultValue[0].ToString();
                this.operationMode = defaultValue[1].ToString();
                PatientNo = defaultValue[2].ToString();
                
            }
           
            #endregion
          
            StringBuilder patientID = new StringBuilder(PatientNo);

            int iReturn = PacsView(Neusoft.FrameWork.Function.NConvert.ToInt32(this.operationMode), patientID, Neusoft.FrameWork.Function.NConvert.ToInt32(this.pacsViewType));

            return iReturn;*/
            if (PatientNo.Length > 10)
            {
                PatientNo = PatientNo.Substring(4);
            }
            DataLoad(PatientNo);
            return 1;
        }

        #endregion
    }

}
