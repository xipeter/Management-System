using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    public partial class ucChangeCompany : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucChangeCompany()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 供货公司信息
        /// </summary>
        private ArrayList alCompany = new ArrayList();

        /// <summary>
        /// 供货公司帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper companyHerlper = null;

        /// <summary>
        /// 查询单据类别 0 发票号 1 入库单据号
        /// </summary>
        private string noType = "0";

        /// <summary>
        /// 新供货公司
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject newCompany = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前登陆科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();

        #region 工具栏

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();

            return base.OnQuery(sender, neuObject);
        }
        #endregion

        private void Init()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            this.alCompany = phaConsManager.QueryCompany("1");
            if (this.alCompany == null)
            {
                MessageBox.Show("获取供货单位列表发生错误");
                return;
            }

            this.companyHerlper = new Neusoft.FrameWork.Public.ObjectHelper(this.alCompany);

            this.deptInfo = ((Neusoft.HISFC.Models.Base.Employee)phaConsManager.Operator).Dept;
        }


        private void Query()
        {
            ArrayList al = new ArrayList();

            string state = "1";
            switch (this.cmbState.Text)
            {
                case "申请":
                    state = "0";
                    break;
                case "审批":
                    state = "1";
                    break;
                case "核准":
                    state = "2";
                    break;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            if (this.noType == "0")
            {
                al = itemManager.QueryInputInfoByInvoice(this.deptInfo.ID, this.txtNO.Text, state);
                if (al == null)
                {
                    MessageBox.Show("根据发票号获取入库信息发生错误");
                    return;
                }
            }
            else
            {
                al = itemManager.QueryInputInfoByListID(this.deptInfo.ID, this.txtNO.Text, "AAAA", state);
                if (al == null)
                {
                    MessageBox.Show("根据单据号获取入库信息发生错误");
                    return;
                }
            }

            this.neuSpread1_Sheet1.Rows.Count = 0;

            foreach (Neusoft.HISFC.Models.Pharmacy.Input info in al)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);
                this.neuSpread1_Sheet1.Cells[0, 0].Value = true;
                this.neuSpread1_Sheet1.Cells[0, 1].Text = info.InListNO;
                this.neuSpread1_Sheet1.Cells[0, 2].Text = info.InvoiceNO;
                this.neuSpread1_Sheet1.Cells[0, 3].Text = this.companyHerlper.GetName(info.Company.ID);
                this.neuSpread1_Sheet1.Cells[0, 4].Text = info.Item.Name + "【" + info.Item.Specs + "】";
                this.neuSpread1_Sheet1.Cells[0, 5].Text = (info.Quantity / info.Item.PackQty).ToString("N");
                this.neuSpread1_Sheet1.Cells[0, 6].Text = info.Item.PackUnit;
                this.neuSpread1_Sheet1.Rows[0].Tag = info;
            }
        }

        private void Save()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            //itemManager.SetTrans(t.Trans);

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value))
                {
                    Neusoft.HISFC.Models.Pharmacy.Input input = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.Input;

                    input.Company = this.newCompany;

                    if (itemManager.UpdateInput(input) != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新供货公司信息失败");
                        return;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功");
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.Init();
            }
            catch
            { }

            base.OnLoad(e);
        }

        private void lnbCompany_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //操作员对窗口选择返回的信息
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alCompany, ref this.newCompany) == 0)
            {
                return;
            }
            else
            {
                this.lbCompany.Text = this.newCompany.Name;
            }
        }

        private void lnbNOType_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (this.noType == "0")
            {
                this.noType = "1";
                this.lnbNOType.Text = "单据号";
            }
            else
            {
                this.noType = "0";
                this.lnbNOType.Text = "发票号";
                this.cmbState.Text = "审批";
            }
            this.txtNO.Text = "";
        }
    }
}
