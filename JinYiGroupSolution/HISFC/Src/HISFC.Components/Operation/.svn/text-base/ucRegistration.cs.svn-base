using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;
using System.Collections;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术登记控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRegistration : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucRegistration()
        {
            InitializeComponent();
        }

        #region 字段
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        #endregion

        #region 方法
        /// <summary>
        /// 获取开始、结束时间
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int GetDateTime(out DateTime begin, out DateTime end)
        {
            DateTime d1 = this.neuDateTimePicker1.Value.Date;
            DateTime d2 = this.neuDateTimePicker2.Value.Date.AddDays(1);
            if (d1 > d2)
            {
                MessageBox.Show("开始时间不能大于结束时间!", "提示");
                begin = end = DateTime.MinValue;

                return -1;
            }
            string strBegin = neuDateTimePicker1.Value.Year.ToString() + "-" + neuDateTimePicker1.Value.Month.ToString() + "-" + neuDateTimePicker1.Value.Day.ToString() + " 00:00:00";
            string strEnd = neuDateTimePicker2.Value.Year.ToString() + "-" + neuDateTimePicker2.Value.Month.ToString() + "-" + neuDateTimePicker2.Value.Day.ToString() + " 23:59:59";
            begin =Neusoft.FrameWork.Function.NConvert.ToDateTime(strBegin);
            end = Neusoft.FrameWork.Function.NConvert.ToDateTime(strEnd); 

            return 0;
        }

        #endregion

        #region 事件

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {//{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}
            this.toolBarService.AddToolButton("作废", "作废", 1, true, false, null);
            this.toolBarService.AddToolButton("取消", "取消", 1, true, false, null);
            return this.toolBarService;
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            DateTime begin, end;
            if (this.GetDateTime(out begin, out end) == -1)
                return -1;

            this.tvList.RefreshList(begin, end);
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.ucRegistrationForm1.Save() >= 0)
            {
                OnQuery(sender, neuObject);
                this.ucRegistrationForm1.Clear();
            }
            return base.OnSave(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.ucRegistrationForm1.Print();
            return base.OnPrint(sender, neuObject);
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ////{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}
            if (e.ClickedItem.Text == "作废")
            {
                if (this.ucRegistrationForm1.Cancel() >= 0)
                {
                    OnQuery(sender, sender);
                    this.ucRegistrationForm1.Clear();
                }
            }
            if (e.ClickedItem.Text == "取消")
            {
                //{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}
                if (this.ucRegistrationForm1.DeleleteRegInfo() >= 0)
                {
                    OnQuery(sender, sender);
                    this.ucRegistrationForm1.Clear();
                }
            }

            base.ToolStrip_ItemClicked(sender, e);
        }
        private void neuTreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode select = this.tvList.SelectedNode;
            this.ucRegistrationForm1.HandInput = false;
            if (select == null)
                return;
            if (select.Tag == null)
                return;

            TreeNode parent = select.Parent;
            if (parent == null)
            {
                //this.ucRegistrationForm1.OperationApplication = new OperationAppllication();
                this.ucRegistrationForm1.OperationRecord = new OperationRecord();
                return;
            }

            if (parent.Tag.ToString() == "NO_Register" || parent.Tag.ToString() == "Cancel")
            {
                //this.ucQueryInpatientNo1.txtInputCode.Text =
                //    (select.Tag as neusoft.HISFC.Object.Operator.OpsApplication).PatientInfo.PID.PatientNo;
                //by zlw 2006-5-24
                //this.ucRecord1.Dept = tvList.SelectedNode.Text.Substring(tvList.SelectedNode.Text.IndexOf('[') + 1, tvList.SelectedNode.Text.IndexOf(']') - 1);


                this.ucRegistrationForm1.HandInput = false;
                if (parent.Tag.ToString() == "NO_Register")
                {
                    this.ucRegistrationForm1.IsNew = true;
                    this.ucRegistrationForm1.IsCancled = false;
                }
                else if (parent.Tag.ToString() == "Cancel")
                {
                    this.ucRegistrationForm1.IsCancled = true;
                    this.ucRegistrationForm1.IsNew = false;
                }

                // {CB2F6DC4-F9C6-4756-A118-CEDB907C39EC}
                OperationAppllication operationAppllication = select.Tag as OperationAppllication;
                int returnValue =  ValidInstate(select.Tag as OperationAppllication);

                if (returnValue < 0)
                {
                    //this.ucRegistrationForm1.OperationApplication = new OperationAppllication();
                    this.ucRegistrationForm1.Clear();
                    return;
                }
                //this.ucRegistrationForm1.OperationApplication = select.Tag as OperationAppllication;
                

                this.ucRegistrationForm1.OperationApplication = operationAppllication;
                

                this.ucRegistrationForm1.Focus();
            }
            else if (parent.Tag.ToString() == "Register")
            {
                //by zlw 2006-5-24
                //this.ucRecord1.Dept = tvList.SelectedNode.Text.Substring(tvList.SelectedNode.Text.IndexOf('[') + 1, tvList.SelectedNode.Text.IndexOf(']') - 1);

                //this.ucQueryInpatientNo1.txtInputCode.Text =
                //    (select.Tag as OperatorRecord).m_objOpsApp.PatientInfo.Patient.PID.PatientNo;
                this.ucRegistrationForm1.HandInput = false;
                this.ucRegistrationForm1.IsNew = false;
                this.ucRegistrationForm1.IsCancled = false;
                // {CB2F6DC4-F9C6-4756-A118-CEDB907C39EC}
                //this.ucRegistrationForm1.OperationRecord = select.Tag as OperationRecord;
                OperationRecord operationRecord = select.Tag as OperationRecord;

                int returnValue = ValidInstate(select.Tag as OperationRecord);

                if (returnValue < 0)
                {
                    //this.ucRegistrationForm1.OperationRecord = new OperationRecord();
                    this.ucRegistrationForm1.Clear();
                    return;
                }
                this.ucRegistrationForm1.OperationRecord = operationRecord;


                this.ucRegistrationForm1.Focus();
            }
            
        }

        #endregion

        /// <summary>
        /// {CB2F6DC4-F9C6-4756-A118-CEDB907C39EC}
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int ValidInstate(Neusoft.FrameWork.Models.NeuObject obj)
        {
            Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
           

            if (obj is OperationRecord)
            {
                OperationRecord tempObj = obj as OperationRecord;

                if (tempObj.OperationAppllication.PatientSouce == "2")
                {
                   patientInfo = radtIntegrate.GetPatientInfomation(tempObj.OperationAppllication.PatientInfo.ID);

                   if (patientInfo == null)
                   {
                       MessageBox.Show(radtIntegrate.Err);

                       return -1;
                   }



                    //if ((Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.N
                    //    || (Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.O)
                    if (patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!", 111);

                        return -1;
                    }

                }

            }
            if (obj is OperationAppllication)
            {
                OperationAppllication tempOA = obj as OperationAppllication;

                if (tempOA.PatientSouce == "2")
                {
                    patientInfo = radtIntegrate.GetPatientInfomation(tempOA.PatientInfo.ID);

                    if (patientInfo == null)
                    {
                        MessageBox.Show(radtIntegrate.Err);

                        return -1;
                    }



                    //if ((Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.N
                    //    || (Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.O)
                    if (patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!", 111);

                        return -1;
                    }
                }

            }

            return 1;
        }


        //====================================================================
        //修改人：路志鹏　时间：２００７-４-１２
        //目的：增加通过住院号检索出手术申请单
        private void neuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.neuTextBox1.Text = this.neuTextBox1.Text.Trim().PadLeft(10, '0');
                string Patient_code = this.neuTextBox1.Text;
                ArrayList al = Environment.OperationManager.GetOpsAppListByPatient(Environment.OperatorDeptID, Patient_code);
                if (al != null && al.Count > 0)
                {
                    if (al.Count > 1)
                    {
                        int count = this.neuSpread1_Sheet1.Rows.Count;
                        if (count > 0)
                        {
                            this.neuSpread1_Sheet1.Rows.Remove(0, count);
                        }
                        this.neuSpread1_Sheet1.Rows.Add(0, al.Count);
                        for (int i = 0; i < al.Count; i++)
                        {
                            OperationAppllication Record = al[i] as OperationAppllication;
                            this.neuSpread1_Sheet1.Cells[i, 0].Text = string.Concat("[",
                                Environment.GetDept(Record.PatientInfo.PVisit.PatientLocation.Dept.ID) + "]",
                                Record.PatientInfo.Name, "[" + Record.PreDate.ToString("yyyy-MM-dd") + "]");
                            this.neuSpread1_Sheet1.Rows[i].Tag = Record;

                        }
                        this.panel.Visible = true;
                        this.neuSpread1.Focus();
                        this.neuSpread1_Sheet1.ActiveRowIndex = 0;
                    }
                    else
                    {
                        OperationAppllication Record = al[0] as OperationAppllication;
                        this.SetRecord(Record);
                    }
                }
                else
                {
                    this.ucRegistrationForm1.Clear();
                    MessageBox.Show("该患者没有要登记的手术单，请核对住院号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SetRecord(OperationAppllication Record)
        {
            //未登记
            this.ucRegistrationForm1.IsNew = true;
            this.ucRegistrationForm1.IsCancled = false;
            this.ucRegistrationForm1.OperationApplication = Record;

            ////已登记
            //if (Record.ExecStatus == "4")
            //{
            //    this.ucRecord1.IsNew = false;
            //    this.ucRecord1.IsCancled = false;
            //    this.ucRecord1.HandInput = false;
            //    this.ucRecord1.IsNew = false;
            //    this.ucRecord1.IsCancled = false;
            //    this.ucRecord1.OperationRecord = select.Tag as OperationRecord;
            //    this.ucRecord1.Focus();
            //}

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (this.panel.Visible)
                {
                    this.panel.Visible = false;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void neuSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {

                if (this.neuSpread1_Sheet1.ActiveRowIndex > 0)
                {
                    this.neuSpread1_Sheet1.ActiveRowIndex--;
                    //this.neuSpread1_Sheet1.ActiveRow.ForeColor = Color.Bisque;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].ForeColor = Color.Bisque;
                }
            }
            if (e.KeyData == Keys.Down)
            {

                if (this.neuSpread1_Sheet1.ActiveRowIndex < this.neuSpread1_Sheet1.Rows.Count - 1)
                {
                    this.neuSpread1_Sheet1.ActiveRowIndex++;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].ForeColor = Color.Red;
                }
            }
            if (e.KeyData == Keys.Enter)
            {

                OperationAppllication Record = this.neuSpread1_Sheet1.ActiveRow.Tag as OperationAppllication;
                this.SetRecord(Record);
                this.panel.Visible = false;
                this.neuTextBox1.Focus();
                this.neuTextBox1.SelectAll();
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OperationAppllication Record = this.neuSpread1_Sheet1.ActiveRow.Tag as OperationAppllication;
            this.SetRecord(Record);
            this.panel.Visible = false;
            this.neuTextBox1.Focus();
            this.neuTextBox1.SelectAll();
        }

    }
}
