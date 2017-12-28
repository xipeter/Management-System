using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// 警戒线设置控件
    /// </summary>
    public partial class ucMoneyAlert : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMoneyAlert()
        {
            InitializeComponent();
        }
        #region 变量

        /// <summary>
        /// 患者业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        
        DataTable dtPatInfo = new DataTable() ;
        DataView dvPatInfo = new DataView();
        
        /// <summary>
        /// toolbarservice
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化患者表格
        /// </summary>
        protected virtual void InitFrpPat()
        {
           
            this.dtPatInfo.Columns.AddRange(new DataColumn[]
            {
                new DataColumn ("住院号",typeof(string)),
                new DataColumn ("姓名",typeof(string)),
                new DataColumn ("合同单位",typeof(string)),
                new DataColumn ("床号",typeof(string)),
                new DataColumn ("警戒线",typeof(decimal)),
                new DataColumn ("住院流水号",typeof(string))
            });
            this.dvPatInfo = new DataView(this.dtPatInfo);
            this.fpInpatInfo_Sheet1.DataSource = this.dvPatInfo;
            this.fpInpatInfo_Sheet1.DataAutoCellTypes = false;
            this.fpInpatInfo_Sheet1.Columns[4].CellType = new Neusoft.HISFC.Components.Common.Classes.MarkCellType.NumCellType();
            
        }

        /// <summary>
        /// 添加树中选中的患者
        /// </summary>
        protected virtual void AddPatInFrp()
        {
          
            this.dtPatInfo.Rows.Clear();
            for (int i = 0; i < this.tvNursePatient.Nodes.Count; i++)
            {
                for (int j = 0; j < this.tvNursePatient.Nodes[i].Nodes.Count; j++)
                {
                    if (this.tvNursePatient.Nodes[i].Nodes[j].Checked)
                    {
                        if (this.tvNursePatient.Nodes[i].Nodes[j].Tag.GetType() != typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
                        {
                            return;
                        }
                            Neusoft.HISFC.Models.RADT.PatientInfo currPatInfo = null;
                            currPatInfo = this.tvNursePatient.Nodes[i].Nodes[j].Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
                            if (currPatInfo != null)
                            {
                                this.QueryPatientAlert(currPatInfo.ID);
                                this.SetFrpColumnType();
                            }
                        
                    }
                }
            }
        }

        /// <summary>
        /// 删除选中的患者
        /// </summary>
        protected virtual void DelPatFromFrp()
        {
            if (this.fpInpatInfo_Sheet1.Rows.Count <= 0)
                return;
            string inpatientNo = this.fpInpatInfo_Sheet1.Cells[this.fpInpatInfo_Sheet1.ActiveRow.Index, 5].Text;
            this.fpInpatInfo_Sheet1.Rows.Remove(this.fpInpatInfo_Sheet1.ActiveRow.Index, 1);
            this.dtPatInfo.AcceptChanges();
            for (int i = 0; i < this.tvNursePatient.Nodes.Count; i++)
            {
                for (int j = 0; j < this.tvNursePatient.Nodes[i].Nodes.Count; j++)
                {
                    if (this.tvNursePatient.Nodes[i].Nodes[j].Checked)
                    {
                        Neusoft.HISFC.Models.RADT.PatientInfo currPatInfo = null;
                        currPatInfo = this.tvNursePatient.Nodes[i].Nodes[j].Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
                        if (currPatInfo.ID == inpatientNo)
                        {
                            this.tvNursePatient.Nodes[i].Nodes[j].Checked = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加患者到列表中
        /// </summary>
        /// <param name="inPatientNo"></param>
        private void QueryPatientAlert(string inPatientNo)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patinfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            patinfo = this.radtManager.GetPatientInfomation(inPatientNo);
            
            //this.dtPatInfo.Rows.Clear();
            DataRow row = this.dtPatInfo.NewRow();
            row["住院号"] = patinfo.PID.PatientNO;
            row["姓名"] = patinfo.Name;
            row["合同单位"] = patinfo.Pact.Name;
            row["床号"] = patinfo.PVisit.PatientLocation.Bed.ID;
            row["警戒线"] = patinfo.PVisit.MoneyAlert;
            row["住院流水号"] = patinfo.ID;

            this.dtPatInfo.Rows.Add(row);
            this.dtPatInfo.AcceptChanges();
        }

        /// <summary>
        /// 锁定frp不可修改的列
        /// </summary>
        private void SetFrpColumnType()
        {
            this.fpInpatInfo_Sheet1.Columns[0].Locked = true;
            this.fpInpatInfo_Sheet1.Columns[1].Locked = true;
            this.fpInpatInfo_Sheet1.Columns[2].Locked = true;
            this.fpInpatInfo_Sheet1.Columns[3].Locked = true;
            this.fpInpatInfo_Sheet1.Columns[5].Locked = true;
            this.fpInpatInfo_Sheet1.Columns[5].Visible = false;
        }

        /// <summary>
        /// 对列表中所有患者设置警戒线
        /// </summary>
        private void SetSelectedPatMoneyAlert()
        {
            decimal moneyAlert = 0;
            frmMoneyAlertSet frmMoneyAlertSet = new InpatientFee.Maintenance.frmMoneyAlertSet(moneyAlert);
            DialogResult result = frmMoneyAlertSet.ShowDialog();
            if (result == DialogResult.OK)
            {
                moneyAlert = frmMoneyAlertSet.myMoneyAlert;
                int rowCount = this.fpInpatInfo_Sheet1.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    this.fpInpatInfo_Sheet1.Cells[i, 4].Text = moneyAlert.ToString();
                }
            }
        }

        /// <summary>
        /// 保存患者警戒线
        /// </summary>
        /// <param name="inPatientNo"></param>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        protected int SaveByPatient(string inPatientNo, decimal moneyAlert)
        {
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int sqlResult = 0;
            this.radtManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            sqlResult = this.radtManager.UpdatePatientAlert(inPatientNo, moneyAlert);
            if (sqlResult == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新" + inPatientNo+ "警戒线失败！" + this.radtManager.Err, "错误");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void SaveData()
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            int rowCount = this.fpInpatInfo_Sheet1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                string inPatienNo = string.Empty;
                decimal moneyAlert = 0;
                inPatienNo = this.fpInpatInfo_Sheet1.Cells[i, 5].Text;
                moneyAlert = Convert.ToDecimal(this.fpInpatInfo_Sheet1.Cells[i, 4].Text.Trim());
                //if (moneyAlert < 0)
                //{
                //    MessageBox.Show("患者警戒线不可以小于0");
                //    return;
                //}
                patientInfo = this.radtManager.GetPatientInfomation(inPatienNo);
                if (moneyAlert != patientInfo.PVisit.MoneyAlert)
                {
                    int result = this.SaveByPatient(inPatienNo, moneyAlert);
                    if (result == -1)
                    {
                        break;
                    }
                }
                patientInfo = null;
            }
            MessageBox.Show("保存成功");
        }

        /// <summary>
        /// 添加toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("添加", "将患者添加到表格", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除选中患者信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("金额", "设置表中患者警戒线", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 重载onsave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            return base.OnSave(sender, neuObject);
        }

        //public override int SetPrint(object sender, object neuObject)
        //{
        //    this.SetSelectedPatMoneyAlert();
        //    return base.SetPrint(sender, neuObject);
        //}

        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "添加":
                    this.AddPatInFrp();
                    break;
                case "删除":
                    this.DelPatFromFrp();
                    break;
                case "金额":
                    this.SetSelectedPatMoneyAlert();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            //print.PrintPage(0, 0, this.fpInpatInfo);
            print.PrintPreview(0, 0, this.neuPanel2);

            return base.OnPrint(sender, neuObject);
        }
        #endregion

        #region 事件

        private void ucMoneyAlert_Load(object sender, EventArgs e)
        {
            this.tvNursePatient.Init();
            this.InitFrpPat();
            
        }

        #endregion
    }
}

