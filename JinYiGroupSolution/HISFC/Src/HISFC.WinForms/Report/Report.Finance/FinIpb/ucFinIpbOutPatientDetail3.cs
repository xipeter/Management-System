using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Finance.FinIpb
{
    /// <summary>
    /// [功能描述: 住院患者费用汇总明细查询]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2009-11-17]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucFinIpbOutPatientDetail3 : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        private string feeType = "";

        public ucFinIpbOutPatientDetail3()
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
        //{33A82699-1DF2-4791-830D-4ECBB6B6034D} 席宗飞 modified 20100923
        protected override int OnQuery(object sender, object neuObject)
        {
            this.ucQueryInpatientNo1.query();
            return base.OnQuery(sender, neuObject);
        }
        protected override int OnRetrieve(params object[] objects)
        {

            ucQueryInpatientNo1_myEvent();
            return 1;
            //switch (this.neuComboBox1.Text)
            //{
            //    case "全部":
            //        this.feeType = "ALL";
            //        break;
            //    case "药品":
            //        this.feeType = "DRUG";
            //        break;
            //    case "非药品":
            //        this.feeType = "UNDRUG";
            //        break;
            //}

            //if (base.GetQueryTime() == -1)
            //{
            //    return -1;
            //}
            //if (this.ucQueryInpatientNo1.InpatientNo == null)
            //{
            //    return -1;
            //}

            ////时间

            //if (neuCheckBox1.Checked)
            //{
            //    this.dwMain.DataWindowObject = "d_fin_ipb_outpatient4";
            //    this.MainDWDataObject = "d_fin_ipb_outpatient4";
            //    this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            //    return base.OnRetrieve(this.ucQueryInpatientNo1.InpatientNo, this.feeType, this.dtpBeginTime.Value, this.dtpEndTime.Value);

            //}
            //else
            //{
            //    this.dwMain.DataWindowObject = "d_fin_ipb_outpatient4";
            //    this.MainDWDataObject = "d_fin_ipb_outpatient3";
            //    this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            //    return base.OnRetrieve(this.ucQueryInpatientNo1.InpatientNo, this.feeType);
            //}

        }

        private void ucQueryInpatientNo1_myEvent()
        {
            if (this.ucQueryInpatientNo1.Text == null || this.ucQueryInpatientNo1.Text.Trim() == "")
            {
                MessageBox.Show("请输入住院号");
                
                return;
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

                #region 加载cmbBalance
                //{D8F3FD26-9891-4e7a-944E-725A375A20CB}添加按照结算次数来选择时间
                GetData getData = new GetData();
                DataSet dsBalanceInfo = getData.GetBalanceInfo(this.ucQueryInpatientNo1.InpatientNo);
                ArrayList alBalanceInfo = new ArrayList();
                if (dsBalanceInfo.Tables.Count > 0)
                {
                    for (int i = 0; i < dsBalanceInfo.Tables[0].Rows.Count; i++)
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                        //住院号
                        obj.ID = dsBalanceInfo.Tables[0].DefaultView[i][0].ToString();
                        //结算类型
                        obj.Memo = dsBalanceInfo.Tables[0].DefaultView[i][3].ToString();
                        string temp_invoice = dsBalanceInfo.Tables[0].DefaultView[i][4].ToString();
                        ////住院日期
                        //obj.User01 = dsBalanceInfo.Tables[0].DefaultView[i][1].ToString();
                        ////结算日期
                        //obj.User02 = dsBalanceInfo.Tables[0].DefaultView[i][2].ToString();
                        if (obj.Memo == "I")
                        {
                            if (i == 0)
                            {
                                //显示
                                obj.Name = "中途结算-" + dsBalanceInfo.Tables[0].DefaultView[i][2].ToString();
                                //开始时间
                                obj.User01 = dsBalanceInfo.Tables[0].DefaultView[i][1].ToString();
                                //结束时间
                                obj.User02 = dsBalanceInfo.Tables[0].DefaultView[i][2].ToString();
                            }
                            else
                            {
                                obj.Name = "中途结算-" + dsBalanceInfo.Tables[0].DefaultView[i][2].ToString();
                                //开始时间 xizf@neusoft 20110107 中途结账情况下，用上次结算时间作为下次开始日期，不能包括所有的费用（最有可能是床位费）
                                //obj.User01 = dsBalanceInfo.Tables[0].DefaultView[i - 1][2].ToString();
                                obj.User01 = getData.GetMinDate(obj.ID, temp_invoice);
                                //结束时间
                                obj.User02 = dsBalanceInfo.Tables[0].DefaultView[i][2].ToString();
                            }
                        }
                        else
                        {
                            //显示
                            obj.Name = "出院结算-" + dsBalanceInfo.Tables[0].DefaultView[i][2].ToString();
                            //开始时间
                            obj.User01 = getData.GetMinDate(obj.ID, temp_invoice);
                            //结束时间
                            obj.User02 = dsBalanceInfo.Tables[0].DefaultView[i][2].ToString();
                        }

                        alBalanceInfo.Add(obj);
                    }
                    this.cmbBalance.AddItems(alBalanceInfo);
                }

                #endregion

                // base.OnRetrieve(this.ucQueryInpatientNo1.InpatientNo,this.feeType);
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
                    return ;
                }
                if (this.ucQueryInpatientNo1.InpatientNo == null)
                {
                    return ;
                }

                #region 郑大修改-donggq-{D245FA93-2D48-4763-AD06-932F8011C86F}
                //时间

                if (neuCheckBox1.Checked)
                {
                    this.dwMain.DataWindowObject = "d_fin_ipb_outpatient4";
                    this.MainDWDataObject = "d_fin_ipb_outpatient4";
                    this.MainDWLabrary = "Report\\zzlocal_fin_ipb.pbd;Report\\zzlocal_fin_ipb.pbl";
                    base.OnRetrieve(this.ucQueryInpatientNo1.InpatientNo, this.feeType, this.dtpBeginTime.Value, this.dtpEndTime.Value);

                }
                else
                {
                    this.dwMain.DataWindowObject = "d_fin_ipb_outpatient3";
                    this.MainDWDataObject = "d_fin_ipb_outpatient3";
                    this.MainDWLabrary = "Report\\zzlocal_fin_ipb.pbd;Report\\zzlocal_fin_ipb.pbl";
                    base.OnRetrieve(this.ucQueryInpatientNo1.InpatientNo, this.feeType);
                } 
                #endregion
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

        private void neuCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.neuCheckBox1.Checked)
            {
                this.dtpBeginTime.Enabled = true;
                this.dtpEndTime.Enabled = true;
                //{D8F3FD26-9891-4e7a-944E-725A375A20CB}添加按照结算次数来选择时间 by guanyx
                this.cmbBalance.Enabled = true;
            }
            else
            {
                this.dtpBeginTime.Enabled = false;
                this.dtpEndTime.Enabled = false;
                //{D8F3FD26-9891-4e7a-944E-725A375A20CB}添加按照结算次数来选择时间 by guanyx
                this.cmbBalance.Enabled = false;
            }
        }

        //{D8F3FD26-9891-4e7a-944E-725A375A20CB}添加按照结算次数来选择时间 by guanyx
        private void cmbBalance_SelectedValueChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject selectObj = this.cmbBalance.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            this.dtpBeginTime.Value = Convert.ToDateTime(selectObj.User01);
            this.dtpEndTime.Value = Convert.ToDateTime(selectObj.User02);
        }


    }

    //{D8F3FD26-9891-4e7a-944E-725A375A20CB}添加按照结算次数来选择时间 by guanyx
    public class GetData : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 获取这张发票的最小结算时间xizf@neusoft.com 20110107
        /// </summary>
        /// <param name="inpatient_no"></param>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public string GetMinDate(string inpatient_no,string invoice) {
            string sql = @"   select min(f.fee_date)
     from fin_ipb_itemlist f
    where f.inpatient_no = '{0}'
      and f.invoice_no = '{1}'";
            sql = string.Format(sql, inpatient_no, invoice);
            try
            {
                return ExecSqlReturnOne(sql);
            }
            catch {
                return "2011-1-1 00:00:00";
            }
            
        }

        /// <summary>
        /// 获取结算信息
        /// </summary>
        /// <param name="inPatientNO"></param>
        /// <returns></returns>
        public DataSet GetBalanceInfo(string inPatientNO)
        {
            try
            {
                string sql = @"SELECT H.INPATIENT_NO 住院号,
                                                           (SELECT I.IN_DATE
                                                              FROM FIN_IPR_INMAININFO I
                                                             WHERE I.INPATIENT_NO = H.INPATIENT_NO) 入院日期,
                                                           H.BALANCE_DATE 结算日期,
                                                           H.BALANCE_TYPE 结算类型,
                                                           h.invoice_no 发票号
                                                      FROM FIN_IPB_BALANCEHEAD H
                                                     WHERE H.TRANS_TYPE = '1'
                                                       AND H.WASTE_OPERCODE IS NULL
                                                       AND H.INPATIENT_NO = '{0}'
                                                     ORDER BY H.BALANCE_DATE
                                                                                                        ";
                sql = string.Format(sql, inPatientNO);
                DataSet ds = new DataSet();
                this.ExecQuery(sql, ref ds);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
