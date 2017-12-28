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
    /// [功能描述: 检验单界面显示]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// </summary>
    public partial class ucLisApplyControl : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Classes.IControlPrintable
    {
        public ucLisApplyControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否选择
        /// </summary>
        protected bool bSelected = false;

        /// <summary>
        /// 诊断
        /// </summary>
        protected string diagNose = "";

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.bSelected;
            }
            set
            {
                this.bSelected = value;
                if (value)
                {
                    this.BackColor = Color.FromArgb(224, 224, 224);
                }
                else
                {
                    this.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        #region IControlPrintable 成员

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

        public int BeginVerticalBlankHeight
        {
            get
            {
                return 5;
            }
            set
            {

            }
        }

        public int VerticalBlankHeight
        {
            get
            {
                return 10;
            }
            set
            {

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

        public ArrayList Comonents
        {
            get
            {
                return null;
            }
            set
            {

            }
        }
        protected int hNum = 0;
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
        /// <summary>
        /// 控件大小
        /// </summary>
        public Size ControlSize
        {
            get
            {
                return new Size(584, 112);
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
        protected object controlvalue = null;
        /// <summary>
        /// 当前数值
        /// </summary>
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

                this.diagNose = "";                

                //住院验单
                if (value.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo p = value as Neusoft.HISFC.Models.RADT.PatientInfo;

                    this.SetItem(p, p.User01, p.User02, p.User03);
                    this.controlvalue = p;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
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
                else
                {
                    this.lbEmc.Visible = false;
                }

                this.lbAge.Text = "年龄：" + patientinfo.Age;
                this.lbBed.Text = "床号" + patientinfo.PVisit.PatientLocation.Bed.ID;
                this.lbDate.Text = "送检日期：" + patientinfo.PVisit.User03;

                if (patientinfo.Diagnoses.Count > 0)
                {
                    this.lbDiagnose.Text = "诊断：" + patientinfo.Diagnoses[0].ToString();
                }
                this.lbDoc.Text = "医生：" + patientinfo.PVisit.User02;
                this.lbName.Text = "姓名：" + patientinfo.Name;
                this.lbID.Text = "住院号：" + patientinfo.PID.PatientNO;
                this.lbListNO.Text = "执行科室：" + patientinfo.PVisit.User01;
                this.lbSample.Text = "样本：" + SampleName;
                this.lbSex.Text = "性别：" + patientinfo.Sex.Name;
                this.lbTarget.Text = "送检目的：" + Item + "  X" + patientinfo.PVisit.Memo;
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


        private void ucLisApplyControl_Click(object sender, EventArgs e)
        {
            this.IsSelected = !this.IsSelected;
        }

        #region IControlPrintable 成员


        public ArrayList Components
        {
            get
            {
                return new ArrayList();
            }
            set
            {

            }
        }

        #endregion
    }
}
