using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UFC.Lis
{
    /// <summary>
    /// [功能描述: 检验单打印]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// </summary>
    public partial class ucPrintLisApply : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Classes.IControlPrintable
    {
        public ucPrintLisApply()
        {
            InitializeComponent();
        }


        protected object controlvalue = null;

        #region IControlPrintable 成员

        public int BeginHorizontalBlankWidth
        {
            get
            {
                return 5;
            }
            set
            {
                
            }
        }

        public int BeginVerticalBlankHeight
        {
            get
            {
                return 0;
            }
            set
            {
               
            }
        }

        public System.Collections.ArrayList Components
        {
            get
            {
                return null;
            }
            set
            {
               
            }
        }

        public Size ControlSize
        {
            get
            {
                return new Size(784, 308);
            }
        }

        public object ControlValue
        {
            get
            {
                return this.controlvalue;
            }
            set
            {
                if (value == null)
                {
                    MessageBox.Show("化验单传入对象类型错误!", "提示");
                    return;
                }

                //住院验单
                if (value.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo p = value as Neusoft.HISFC.Models.RADT.PatientInfo;
                    this.SetItem(p, p.User01, p.User02, p.User03);
                    this.controlvalue = p;
                }
            }
        }

        public int HorizontalBlankWidth
        {
            get
            {
                return 10;
            }
            set
            {
                
            }
        }

        	protected int hNum =0;
        protected int vNum = 0;

        public int HorizontalNum
        {
            get
            {
                return hNum;
            }
            set
            {
                hNum = value;
            }
        }

        public bool IsCanExtend
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public bool IsShowGrid
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public int VerticalBlankHeight
        {
            get
            {
                return 0;
            }
            set
            {
                
            }
        }

        public int VerticalNum
        {
            get
            {
                return vNum;
            }
            set
            {
                vNum = value;
            }
        }

        #endregion

        /// <summary>
        /// 当前检验项目
        /// </summary>
        protected virtual void SetItem(Neusoft.HISFC.Models.RADT.PatientInfo patientinfo, string id, string SampleName, string Item)
        {
            try
            {
                if (patientinfo.ExtendFlag1 == "True")
                {
                    this.lbEmc.Visible = true;
                }
                if (patientinfo.ExtendFlag2 == "True")
                {
                    this.lbPrePrint.Visible = true;
                }
                this.lbExecDept.Text += patientinfo.PVisit.User01;

                string strPatientInfo = "姓名：{0}    床号：{1}   性别：{2}  年龄：{3}  住院号：{4}  科室：{5}    ";
                this.lbPatientInfo.Text = string.Format(strPatientInfo,patientinfo.Name,patientinfo.PVisit.PatientLocation.Bed.Name,patientinfo.Sex.Name,patientinfo.Age,patientinfo.PID.PatientNO,patientinfo.PVisit.PatientLocation.Dept.Name);

                this.lbListID.Text = "检验单号：" + id;
                this.lbDoc.Text = "开立医生：" + patientinfo.PVisit.User02;
                this.lbDate.Text = "送检日期：" + patientinfo.PVisit.User03;

                this.lbSampleNam.Text = "样本类型：" + SampleName;
                this.lbItem.Text = "送检目的：\n" + Item;

                if (patientinfo.Diagnoses.Count > 0)
                {
                    this.lbDiagnose.Text = "诊断：" + patientinfo.Diagnoses[0].ToString();
                }
            }
            catch { }
        }

        private string SetAge(DateTime birthday)
        {
            if (birthday == DateTime.MinValue)
            {
                return "";
            }

            DateTime current;
            int year, month, day;

            current = DateTime.Now;
            year = current.Year - birthday.Year;
            month = current.Month - birthday.Month;
            day = current.Day - birthday.Day;

            if (year > 0)
            {
                return year.ToString() + "岁";
            }
            else if (month > 0)
            {
                return month.ToString() + "月";
            }
            else if (day > 0)
            {
                return day.ToString() + "天";
            }

            return "";
        }

        protected override void OnLoad(EventArgs e)
        {            
            base.OnLoad(e);
        }

    }
}