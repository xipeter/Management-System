using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    /// <summary>
    /// [功能描述: 住院患者费用汇总明细查询]<br></br>
    /// [创 建 者: wangjianfeng]<br></br>
    /// [创建时间: 2009-11-17]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucFinIpbOutPatientDetail2 : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        private string feeType = "";

        public ucFinIpbOutPatientDetail2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 打印方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                this.dwMain.Print();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错", "提示");
                return -1;
            }

        }

        /// <summary>
        /// 导出方法
        /// </summary>
        /// <returns></returns>
        protected override int OnExport()
        {
            //如果存在多个DataWindow时导出方法需要重写，否则不需要重写该方法，根据焦点判断导出具体哪个DataWindow
            try
            {
                //导出Excel格式文件
                SaveFileDialog saveDial = new SaveFileDialog();
                saveDial.Filter = "Excel文件（*.xls）|*.xls";
                //文件名

                string fileName = string.Empty;
                if (saveDial.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveDial.FileName;
                }
                this.dwMain.SaveAs(fileName, Sybase.DataWindow.FileSaveAsType.Excel);
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出出错", "提示");
                return -1;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            switch (this.neuComboBox1.Text)
            {
                case "全部":
                    this.feeType = "ALL";
                    break;
                case "药品":
                    this.feeType = "DRUG";
                    break;
                case "非药品":
                    this.feeType = "UNDRUG";
                    break;
            }

            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            if (this.ucQueryInpatientNo1.InpatientNo == null)
            {
                return -1;
            }
            return base.OnRetrieve(this.ucQueryInpatientNo1.InpatientNo,this.feeType);
        }

        private void ucQueryInpatientNo1_myEvent()
        {
            switch (this.neuComboBox1.Text)
            {
                case "全部":
                    this.feeType = "ALL";
                    break;
                case "药品":
                    this.feeType="DRUG";
                    break;
                case "非药品":
                    this.feeType = "UNDRUG";
                    break;
            }

            if (this.ucQueryInpatientNo1.InpatientNo == null || this.ucQueryInpatientNo1.InpatientNo.Trim() == "")
            {
                if (this.ucQueryInpatientNo1.Err == "")
                {
                    ucQueryInpatientNo1.Err = "此患者不在院!";
                }
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.ucQueryInpatientNo1.Err, 211);

                this.ucQueryInpatientNo1.Focus();
                return;
            }
            else 
            {
                base.OnRetrieve(this.ucQueryInpatientNo1.InpatientNo,this.feeType);
            }
        }

        private void ucMetNuiOutPatientDetail_Load(object sender, EventArgs e)
        {
            if (this.neuComboBox1.Items.Count > 0)
            {
                this.neuComboBox1.SelectedIndex = 0;
            }
            else
            {
                return;
            }
        }        

    }
}
