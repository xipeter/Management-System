using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.EPR.Controls
{
    internal partial class ucDiseaseInputOne : UserControl
    {
        public ucDiseaseInputOne()
        {
            InitializeComponent();
        }
         

        public delegate void DateTimePickerChanged(string str);
        public event DateTimePickerChanged DateTimePickerChange;
        /// <summary>
        /// 是否提交病程记录属性
        /// </summary>
        private string isUpSubmission = "0";
        public string IsUpSubmission
        {
            get 
            {
                return this.isUpSubmission ;
            }
            set
            {
                this.isUpSubmission = value;
                if (value == "1")
                {
                    this.label4.Text = "已提交";
                    this.emrMultiLineTextBox1.IsShowModify = true;
                    if(this.txtDocSign.Text.Trim()=="")
                        this.txtDocSign.Text = Neusoft.FrameWork.Management.Connection.Operator.Name;
                }
                else
                {
                    this.label4.Text = "未提交";
                    this.emrMultiLineTextBox1.IsShowModify = false;
                }
            }
        }
        /// <summary>
        /// 是否上级医生签名
        /// </summary>
        private string isUpDocSign = "0";
        public string IsUpDocSign 
        {
            get 
            {
                return this.isUpDocSign;
            }
            set 
            {
                this.isUpDocSign = value;
            }

        }
        private void ucDiseaseInputOne_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {            
            if (DateTimePickerChange != null)
            {
                this.DateTimePickerChange(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
        }
    }
}
