using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Print
{
    /// <summary>
    /// {637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
    /// </summary>
    public partial class ucPrintPatient : UserControl, Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectPatientPrint
    {
        #region 变量

        private ArrayList alPrint = new ArrayList();
        private Neusoft.HISFC.BizLogic.Nurse.Inject injectMgr = new Neusoft.HISFC.BizLogic.Nurse.Inject();

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public ucPrintPatient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="al"></param>
        public void Init(ArrayList al)
        {
            try
            {
                ArrayList sortList = new ArrayList();
                while (al.Count > 0)
                {
                    Neusoft.HISFC.Models.Nurse.Inject temp = al[0] as Neusoft.HISFC.Models.Nurse.Inject;
                    ArrayList sameList = new ArrayList();
                    foreach (Neusoft.HISFC.Models.Nurse.Inject obj in al)
                    {
                        if (obj.InjectOrder == null || obj.InjectOrder == "")//.Item.CombNo
                        {
                            sameList.Add(obj);
                            break;
                        }
                        if (obj.InjectOrder == temp.InjectOrder)
                        {
                            sameList.Add(obj);
                        }
                    }
                    sortList.Add(sameList);
                    foreach (Neusoft.HISFC.Models.Nurse.Inject obj in sameList)
                    {
                        al.Remove(obj);
                    }
                }
                foreach (ArrayList tmp in sortList)
                {
                    Neusoft.HISFC.Models.Nurse.Inject info = null;

                    //接瓶次数
                    int jpNum = 1;
                    info = (Neusoft.HISFC.Models.Nurse.Inject)tmp[0];
                    this.lbName.Text = info.Patient.Name;
                    this.lbCard.Text = info.Patient.PID.CardNO;
                    this.lbTime.Text = System.DateTime.Now.ToString();
                    this.lbOrder.Text = info.OrderNO;
                    this.lbAge.Text = this.injectMgr.GetAge(info.Patient.Birthday, System.DateTime.Now);
                    if (info.Patient.Sex.ID.ToString() == "M")
                    {
                        this.lbSex.Text = "男";
                    }
                    else if (info.Patient.Sex.ID.ToString() == "F")
                    {
                        this.lbSex.Text = "女";
                    }
                    else
                    {
                        this.lbSex.Text = "";
                    }

                    this.Print();

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        /// <summary>
        /// 打印函数
        /// </summary>
        private void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = null;
            if (p == null)
            {
                p = new Neusoft.FrameWork.WinForms.Classes.Print();

                //neusoft.Common.Class.Function.GetPageSize("Inject", ref p);
            }
            //System.Windows.Forms.Control c = this;
            //c.Width = this.Width;
            //c.Height = this.Height;

            p.PrintPage(12, 1, this.pnlPrint);
        }
    }
}
