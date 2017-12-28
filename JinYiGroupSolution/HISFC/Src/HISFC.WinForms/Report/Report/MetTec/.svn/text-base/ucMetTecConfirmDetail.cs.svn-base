using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Report.MetTec
{
    public partial class ucMetTecConfirmDetail : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucMetTecConfirmDetail()
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


        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string state = "";
            switch (cmbstate.SelectedIndex)
            {
                //case 0: state = "all"; break;
                case 0: state = "5"; break;
                case 1: state = "6"; break;
                case 2: state = "0"; break;
                default: MessageBox.Show(Language.Msg("请选择查询状态")); return -1; break;
            }


            return base.OnRetrieve(base.beginTime, base.endTime,base.employee.Dept.ID,state);

        }
         /// <summary>
        /// 回车后根据住院号过滤  add by wangyx 2007-11-08
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string inPatientNo;
        //    inPatientNo = this.textBox1.Text;
        //    if (e.KeyChar == (char)Keys.Enter)
        //        this.dwMain.SetFilter("compute_0001 like  '%" + inPatientNo + "%'");
        //    this.dwMain.Filter();
           
        // }


      
        /// <summary>
        /// 西安才子制作   2007-12-17 距离回家还有一个多月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    

        private void cmdstate_selectedIndexChanged(object sender, EventArgs e)
        {
           this.OnRetrieve(base.beginTime, base.endTime, base.employee.Dept.ID,this.cmbstate.Text.GetType());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string inPatientNo;
            inPatientNo = this.textBox1.Text;
            if (inPatientNo == null || inPatientNo == "")
            {
               this.OnRetrieve(base.beginTime, base.endTime, base.employee.Dept.ID, this.cmbstate.Text.GetType());
                this.dwMain.SetFilter("1=1");
                this.dwMain.Filter();
            }


            else
            {
                this.dwMain.SetFilter("compute_0001 like '%" + inPatientNo + "%'");
                this.dwMain.Filter();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string spell;
            spell= this.textBox2.Text.ToString().ToUpper();
            if (spell == null || spell == "")
            {
                this.OnRetrieve(base.beginTime, base.endTime, base.employee.Dept.ID, this.cmbstate.Text.GetType());
                this.dwMain.SetFilter("1=1");
                this.dwMain.Filter();
            }


            else
            {
                this.dwMain.SetFilter("compute_0009 like '" + spell + "%'");
                this.dwMain.Filter();
            }
        }
     
        
        
    }
}
