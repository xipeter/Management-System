using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucChangeStoreDept : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucChangeStoreDept()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取药药房列
        /// </summary>
        private static System.Collections.Hashtable hsStoreDeptCollection = new System.Collections.Hashtable();

        Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaConsManager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        private Neusoft.HISFC.Models.Order.Order order = null;

        private DialogResult rs = DialogResult.OK;

        public Neusoft.HISFC.Models.Order.Order Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;

                System.Collections.ArrayList alList = this.QueryStoreList(value.Patient.PVisit.PatientLocation.Dept.ID);
                this.cmbStoreDept.AddItems(alList);

                if (value.StockDept != null && value.StockDept.ID != "")
                {
                    this.cmbStoreDept.Tag = value.StockDept.ID;
                }
            }
        }

        public DialogResult Rs
        {
            get
            {
                return rs;
            }
            set
            {
                this.rs = value;
            }
        }

        /// <summary>
        /// 取药病区
        /// </summary>
        /// <param name="roomCode"></param>
        /// <returns></returns>
        private System.Collections.ArrayList QueryStoreList(string roomCode)
        {
            if (hsStoreDeptCollection.ContainsKey(roomCode))
            {
                return hsStoreDeptCollection[roomCode] as System.Collections.ArrayList;
            }
            else
            {
                return this.phaConsManager.QueryReciveDrugDept(roomCode,"A");
            }
        }

        private void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cmbStoreDept.Tag != null)
            {
                string storeDept = this.cmbStoreDept.Tag.ToString();

                this.order.StockDept.ID = storeDept;
                this.order.StockDept.Name = this.cmbStoreDept.Text;

                this.Close();

                this.rs = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择取药科室");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            this.rs = DialogResult.Cancel;
        }

        /// <summary>
        /// 对未生效医嘱修改取药药房
        /// </summary>
        /// <param name="order"></param>
        public static  Neusoft.FrameWork.Models.NeuObject ChangeStoreDept(Neusoft.HISFC.Models.Order.Order order)
        {
            using (ucChangeStoreDept uc = new ucChangeStoreDept())
            {
                uc.Order = order;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                if (uc.Rs == DialogResult.OK)
                {
                    return order.StockDept;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
