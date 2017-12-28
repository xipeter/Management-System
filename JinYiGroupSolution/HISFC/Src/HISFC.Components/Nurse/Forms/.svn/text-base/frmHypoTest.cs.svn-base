using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Forms
{
    public partial class frmHypoTest : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmHypoTest()
        {
            InitializeComponent();
        }

        #region MyRegion
        private bool isEditMode = false;
        
        #endregion


        private ArrayList alOrderList = null;

        /// <summary>
        /// 待改皮试的医嘱信息
        /// </summary>
        public ArrayList AlOrderList
        {
            get { return alOrderList; }
            set { alOrderList = value; }
        }
        
        public int GetHypotestValue()
        {
            if (!this.rb2.Checked && !this.rb4.Checked)
            {
                MessageBox.Show("请选择皮试结果");
                return  -1;
            }
            //if (this.rb1.Checked)
            //{
            //    return 1;
            //}
            //else 
            if (this.rb2.Checked)
            {
                return 4;
            }
            //else if (this.rb3.Checked)//{BCF43AF9-C17E-43e3-8E21-E273CE96975D}
            //{
            //    return 2;
            //}
            else if (this.rb4.Checked)
            {
                return 3;
            }
            else
            {
                return 4;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            int hyTestValue = this.GetHypotestValue();
            if (hyTestValue == -1)
            {
                return;
            }

            ArrayList alOrderListClone = new ArrayList();

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order var in this.alOrderList)
            {
                alOrderListClone.Add(var.Clone());
            }

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order var in alOrderListClone)
            {
                if (var.HypoTest == 1) //不需要皮试
                {
                    continue;
                }

                int returnVlue = orderIntegrate.UpdateOrderHyTest(hyTestValue.ToString(), var.ID.ToString());

               
                if (returnVlue < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新医嘱的皮试信息出错!"  + orderIntegrate.Err);
                    return; 
                }

                var.HypoTest = hyTestValue;

            }


            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order var in this.alOrderList)
            {

                foreach (Neusoft.HISFC.Models.Order.OutPatient.Order varClone in alOrderListClone)
                {
                    if (var.ID == varClone.ID)
                    {
                        var.HypoTest = varClone.HypoTest;
                    }
                }
            }


            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("修改成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}