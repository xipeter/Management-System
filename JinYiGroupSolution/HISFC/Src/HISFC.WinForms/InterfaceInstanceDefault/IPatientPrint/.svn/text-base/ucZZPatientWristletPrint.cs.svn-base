using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InterfaceInstanceDefault.IPatientPrint
{
    /// <summary>
    /// ucZZPatientWristletPrint<br></br>
    /// [功能描述: 郑州腕带<br></br>//
    /// [创 建 者: donggq]<br></br>
    /// [创建时间: 2010-10-18]<br></br>
    /// <修改记录 
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucZZPatientWristletPrint : System.Windows.Forms.UserControl, Neusoft.HISFC.BizProcess.Interface.IPatientWristletPrint
    {

        public ucZZPatientWristletPrint()
        {
            InitializeComponent();
        }



        public int Print()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print print = null;
                try
                {
                    print = new Neusoft.FrameWork.WinForms.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }

                //Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize();
                

                //Neusoft.HISFC.BizLogic.Manager.PageSize pss = new Neusoft.HISFC.BizLogic.Manager.PageSize();
                
                //ps = pss.GetPageSize("wandai");

                //print.SetPageSize(ps);
                
                //print.PrintPage(160, 0, this);
                //print.PrintPage(100, 40, this);
                print.PrintPage(0, 40, this);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1; 
        }

        public int PrintPreview()
        {
            return -1;
        }

        public int SetValue(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            

            string age = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(patientInfo.Birthday);

            try
            {
                //姓名
                this.lblname.Text = string.Format("姓名：{0}", patientInfo.Name);
                //性别
                this.lblsex.Text =string.Format("性别：{0}", patientInfo.Sex.Name);
                //年龄
                this.lblage.Text = string.Format("年龄：{0}", age);//patientInfo.Age;
                //入院日期
                //this.lblindate.Text =string.Format("", patientInfo.PVisit.InTime.ToString();
                //住院科室
                this.lbldeptname.Text =string.Format("科别：{0}", patientInfo.PVisit.PatientLocation.Dept.Name);
                //住院号码
                this.lblpatientinfo.Text =string.Format("住院号：{0}", patientInfo.PID.PatientNO);

                //条码
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;
                //===== Encoding performed here =====
                b.IncludeLabel = true;
                barcode.Image = b.Encode(type, patientInfo.ID, System.Drawing.Color.Black, System.Drawing.Color.White, barcode.Width, barcode.Height);

            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }




        /// <summary>
        /// Get Age
        /// </summary>
        /// <param name="birthday"></param>
        //private void GetAge(DateTime birthday)
        //{
        //    string age = string.Empty;

        //    if (birthday == DateTime.MinValue)
        //    {
        //        return;
        //    }

        //    DateTime current;
        //    int year, month, day;

        //    .GetDateTimeFromSysDateTime();
        //    year = current.Year - birthday.Year;
        //    month = current.Month - birthday.Month;
        //    day = current.Day - birthday.Day;

        //    if (year > 1)
        //    {
        //        age = year.ToString()+"岁";
        //    }
        //    else if (year == 1)
        //    {
        //        if (month >= 0)//一岁
        //        {
        //            this.txtAge.Text = year.ToString();
        //            this.cmbUnit.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            this.txtAge.Text = Convert.ToString(12 + month);
        //            this.cmbUnit.SelectedIndex = 1;
        //        }
        //    }
        //    else if (month > 0)
        //    {
        //        this.txtAge.Text = month.ToString();
        //        this.cmbUnit.SelectedIndex = 1;
        //    }
        //    else if (day > 0)
        //    {
        //        this.txtAge.Text = day.ToString();
        //        this.cmbUnit.SelectedIndex = 2;
        //    }
        //}

    }
}
