using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Order
{
    public partial class ucFinOpbQueryInvoice : Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinOpbQueryInvoice()
        {
            InitializeComponent();
        }
        private string personCode = string.Empty;
        private string personName = string.Empty;
        System.Collections.ArrayList alPersonconstantList = null;
        System.Collections.ArrayList alCancelFlagConstantList = null;
        private string invoiceNo = string.Empty;
        private string cardNo = string.Empty;
        private string name = string.Empty;
        private string cancelFlag0 = string.Empty;
        private string cancelFlag1 = string.Empty;
        private string cancelFlag2 = string.Empty;
        private string cancelFlag3 = string.Empty;

        protected override void OnLoad()
        {
            this.Init();
            
            base.OnLoad();
            //����ʱ�䷶Χ
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpBeginTime.Value = dt;

            //�������
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            alPersonconstantList = manager.QueryEmployeeAll();
            Neusoft.HISFC.Models.Base.Employee allPerson = new Neusoft.HISFC.Models.Base.Employee();
            allPerson.ID = "%%";
            allPerson.Name = "ȫ��";
            allPerson.SpellCode = "QB";
            //cboPersonCode.Items.Insert(0, allPerson);
            alPersonconstantList.Insert(0, allPerson);
            this.cboPersonCode.AddItems(alPersonconstantList);
            cboPersonCode.SelectedIndex = 0;


            alCancelFlagConstantList = new ArrayList();

            #region ȫ����Ʊ״̬
            
            //ȫ��
           Neusoft.HISFC.Models.Base.Const allCancelFlag0 = new Neusoft.HISFC.Models.Base.Const();
            allCancelFlag0.ID = "QB";
            allCancelFlag0.Name = "ȫ��";
            allCancelFlag0.SpellCode = "QB";
            alCancelFlagConstantList.Add(allCancelFlag0);
            //��Ч
            Neusoft.HISFC.Models.Base.Const allCancelFlag1 = new Neusoft.HISFC.Models.Base.Const();
            allCancelFlag1.ID = "YX";
            allCancelFlag1.Name = "��Ч";
            allCancelFlag1.SpellCode = "YX";
            alCancelFlagConstantList.Add(allCancelFlag1);
            //ȫ����Ʊ(�˷�,�ش�,ע��)
            Neusoft.HISFC.Models.Base.Const allCancelFlag2 = new Neusoft.HISFC.Models.Base.Const();
            allCancelFlag2.ID = "QBFP";
            allCancelFlag2.Name = "ȫ����Ʊ";
            allCancelFlag2.SpellCode = "QBFP";
            alCancelFlagConstantList.Add(allCancelFlag2);
            //�˷�
            Neusoft.HISFC.Models.Base.Const allCancelFlag3 = new Neusoft.HISFC.Models.Base.Const();
            allCancelFlag3.ID = "TF";
            allCancelFlag3.Name = "�˷�";
            allCancelFlag3.SpellCode = "TF";
            alCancelFlagConstantList.Add(allCancelFlag3);
            //�ش�
            Neusoft.HISFC.Models.Base.Const allCancelFlag4 = new Neusoft.HISFC.Models.Base.Const();
            allCancelFlag4.ID = "CD";
            allCancelFlag4.Name = "�ش�";
            allCancelFlag4.SpellCode = "CD";
            alCancelFlagConstantList.Add(allCancelFlag4);
            //ע��
            Neusoft.HISFC.Models.Base.Const allCancelFlag5 = new Neusoft.HISFC.Models.Base.Const();
            allCancelFlag5.ID = "ZX";
            allCancelFlag5.Name = "ע��";
            allCancelFlag5.SpellCode = "ZX";
            alCancelFlagConstantList.Add(allCancelFlag5);  
            #endregion
            
            this.cboCancelFlag.AddItems(alCancelFlagConstantList);
            cboCancelFlag.SelectedIndex = 0;


        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            if (string.IsNullOrEmpty(tbInvoiceNo.Text))
            {
                invoiceNo = "%%";
            }
            else
            {
                invoiceNo = "%" + tbInvoiceNo.Text.Trim() + "%";
            }

            if (string.IsNullOrEmpty(tbCardNo.Text))
            {
                cardNo = "%%";
            }
            else
            {
                cardNo = "%" + tbCardNo.Text.Trim() + "%";
            }

            if (string.IsNullOrEmpty(tbName.Text))
            {
                name = "%%";
            }
            else
            {
                name = "%" + tbName.Text.Trim() + "%";
            }
            //ȫ��
            //��Ч
            //ȫ����Ʊ(�˷�,�ش�,ע��)
            //�˷�
            //�ش�
            //ע��
            //��Ʊ״̬ 
            //"0" �˷� 
            //"1" ��Ч 
            //"2" �ش� 
            //"3" ע��    
            switch (this.cboCancelFlag.SelectedItem.ID)
            {
                case "QB":
                    {
                        cancelFlag0="0"; 
                        cancelFlag1="1";
                        cancelFlag2="2";
                        cancelFlag3="3";
                        break;
                    }
                case "YX":
                    {
                        cancelFlag0 = "1";
                        cancelFlag1 = "1";
                        cancelFlag2 = "1";
                        cancelFlag3 = "1";
                        break;
                    }
                case "QBFP":
                    {
                        cancelFlag0 = "0";
                        cancelFlag1 = "0";
                        cancelFlag2 = "2";
                        cancelFlag3 = "3";
                        break;
                    }
                case "TF":
                    {
                        cancelFlag0 = "0";
                        cancelFlag1 = "0";
                        cancelFlag2 = "0";
                        cancelFlag3 = "0";
                        break;
                    }
                case "CD":
                    {
                        cancelFlag0 = "2";
                        cancelFlag1 = "2";
                        cancelFlag2 = "2";
                        cancelFlag3 = "2";
                        break;
                    }
                case "ZX":
                    {
                        cancelFlag0 = "3";
                        cancelFlag1 = "3";
                        cancelFlag2 = "3";
                        cancelFlag3 = "3";
                        break;
                    }
                default :
                    {
                        cancelFlag0 = "0";
                        cancelFlag1 = "1";
                        cancelFlag2 = "2";
                        cancelFlag3 = "3";
                        break;
                    }
            }
            return base.OnRetrieve(base.beginTime, base.endTime,personCode , invoiceNo, cardNo, name, 
                cancelFlag0, cancelFlag1, cancelFlag2, cancelFlag3);
        }

        private void cboPersonCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPersonCode.SelectedIndex >= 0)
            {
                personCode = ((Neusoft.HISFC.Models.Base.Employee)alPersonconstantList[this.cboPersonCode.SelectedIndex]).ID.ToString();
                personName = ((Neusoft.HISFC.Models.Base.Employee)alPersonconstantList[this.cboPersonCode.SelectedIndex]).Name.ToString();
            }
        }

        private void dwMain_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            int currRow = e.RowNumber;
            if (currRow == 0)
            {
                dwDetail.Reset();
                return;
            }
            RetrieveDetail(currRow);
            return;
        }
        private void RetrieveDetail(int currRow)
        {
            try
            {

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("���ڼ�����ϸ�����Ժ�...");
                //��Ʊ�ţ�
                string invoice_no;
                //��Ʊʱ�䣺
                string invoice_date;
                //�տ�Ա��
                string oper_name;
                //��Ʊ״̬��
                string cancel_flag_name;
                //���ߣ�
                string name;

                invoice_no = dwMain.GetItemString(currRow, "fin_opb_invoiceinfo_invoice_no");
                invoice_date = dwMain.GetItemString(currRow, "fin_opb_invoiceinfo_invoice_date");
                oper_name = dwMain.GetItemString(currRow, "com_employee_empl_name");
                cancel_flag_name = dwMain.GetItemString(currRow, "cancel_flag_name");
                name = dwMain.GetItemString(currRow, "fin_opb_invoiceinfo_name");
                dwDetail.Retrieve(invoice_no, invoice_date, oper_name, cancel_flag_name, name);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            }
        }
    }
}
