using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// [功能描述: 住院患者费用减免]<br></br>
    /// [创 建 者: nxy]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// <修改记录>
    ///     
    /// </修改记录>
    /// </summary>
    public partial class ucInpatientDerateFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
       
        public ucInpatientDerateFee()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 住院患者信息实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 入出转integrate层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 减免业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.Derate derateMgr = new Neusoft.HISFC.BizLogic.Fee.Derate();

        /// <summary>
        /// 已经减免的信息
        /// </summary>
        DataTable dtDerated = new DataTable();

        /// <summary>
        /// 管理业务层integrate
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 最小费用哈希表
        /// </summary>
        Hashtable minFeeHastable = null;

        /// <summary>
        /// 待删除列
        /// </summary>
        ArrayList alDelete = new ArrayList();

        /// <summary>
        /// toolBarService
        /// </summary>
        Neusoft.FrameWork.WinForms.Forms.ToolBarService tooBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 住院费用业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示总费用Sheet页
        /// </summary>
        [Category("设置")]
        public bool IsShowTotSheet
        {
            get
            {
                return this.fpFeeInfo_TotFee.Visible;
            }
            set
            {
                this.fpFeeInfo_TotFee.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示明细费用Sheet页
        /// </summary>
        [Category("设置")]
        public bool IsShowFeeDetailsSheet
        {
            get
            {
                return this.fpFeeInfo_Items.Visible;
            }
            set
            {
                this.fpFeeInfo_Items.Visible = value;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置减免fp显示格式
        /// </summary>
        /// <returns></returns>
        private int InitDataSetDerated()
        {
            this.dtDerated.Columns.AddRange(new DataColumn[] 
                    {
                        new DataColumn("医疗流水号",typeof(string)),  //0
                        new DataColumn("发生序号",typeof(int)),//1
                        new DataColumn("减免种类代码",typeof(string)),//2
                        new DataColumn("减免种类",typeof(string)),//3
                        new DataColumn("减免类型名称",typeof(string)),//4
                        new DataColumn("减免类型",typeof(string)),//5
                        new DataColumn("最小费用编码",typeof(string)),//6
                        new DataColumn("最小费用名称",typeof(string)),//7
                        new DataColumn("减免金额",typeof(decimal)),//8
                        new DataColumn("减免原因",typeof(string)),//9
                        new DataColumn("批准人员工代码",typeof(string)),//10
                        new DataColumn("批准人姓名",typeof(string)),//11
                        new DataColumn("科室代码",typeof(string)),//12
                        new DataColumn("科室名称",typeof(string)),//13
                        new DataColumn("作废人",typeof(string)),//14
                        new DataColumn("作废时间",typeof(DateTime)),//15
                        new DataColumn("操作员",typeof(string)),//16
                        new DataColumn("操作日期",typeof(DateTime)),//17
                        new DataColumn("项目代码",typeof(string)),//18
                        new DataColumn("项目名称",typeof(string)),//19
                        new DataColumn("是否有效",typeof(bool))//20
                    });

            this.fpDerateInfo_Sheet1.DataSource = this.dtDerated;

            //设置不可见
            this.fpDerateInfo_Sheet1.Columns[0].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[1].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[2].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[4].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[6].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[9].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[10].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[11].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[12].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[14].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[15].Visible = false;
            this.fpDerateInfo_Sheet1.Columns[18].Visible = false;

            this.fpDerateInfo_Sheet1.Columns[3].Width = 80;
            this.fpDerateInfo_Sheet1.Columns[5].Width = 80;
            this.fpDerateInfo_Sheet1.Columns[7].Width = 80;
            this.fpDerateInfo_Sheet1.Columns[8].Width = 80;
            for (int i = 0; i < this.fpDerateInfo_Sheet1.Columns.Count; i++)
            {
                this.fpDerateInfo_Sheet1.Columns[i].Locked = true;
            }

            return 1;
        }

        /// <summary>
        /// 将值插入dataset
        /// </summary>
        /// <param name="al"></param>
        private void InSertDataSet(ArrayList al)
        {
            foreach (Neusoft.HISFC.Models.Fee.DerateFee derateObj in al)
            {

                this.dtDerated.Rows.Add(new object[]
                        {
                            derateObj.InpatientNO,
                            derateObj.HappenNO,
                            derateObj.DerateKind.ID,
                            derateObj.DerateKind.Name,
                            derateObj.DerateType.ID,
                            derateObj.DerateType.Name,
                            derateObj.FeeCode,
                            derateObj.FeeName,
                            derateObj.DerateCost,
                            derateObj.DerateCause,
                            derateObj.ConfirmOperator.ID,
                            derateObj.ConfirmOperator.Name,
                            derateObj.DerateOper.Dept.ID,
                            derateObj.DerateOper.Dept.Name,
                            derateObj.CancelDerateOper.ID,
                            derateObj.CancelDerateOper.OperTime,
                            derateObj.DerateOper.ID,
                            derateObj.DerateOper.OperTime,
                            derateObj.ItemCode,
                            derateObj.ItemName,
                            derateObj.IsValid

                        }
                        );

            }

        }

        /// <summary>
        /// 比较值大小
        /// </summary>
        /// <param name="derateCode"></param>
        /// <param name="leftCost"></param>
        /// <returns></returns>
        private bool ValidDerateCost(decimal derateCost, decimal leftCost)
        {
            return derateCost <= leftCost;
        }

        /// <summary>
        /// 减免后金额(总金额)
        /// </summary>
        /// <param name="derateFee"></param>
        /// <returns></returns>
        private int SetAtferDerateTotFee(decimal derateFee)
        {
            //取已减免金额
            decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_TotFee.Cells[0, 4].Text);

            //取余额
            decimal leftFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_TotFee.Cells[0, 5].Text);

            //设置已减免金额
            this.fpFeeInfo_TotFee.Cells[0, 4].Text = (deratedFee + derateFee).ToString();

            //设置余额
            this.fpFeeInfo_TotFee.Cells[0, 5].Text = (leftFee - derateFee).ToString();


            return 1;
        }

        /// <summary>
        /// 减免后金额(最小费用)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="derateFee"></param>
        /// <returns></returns>
        private int SetAfterDerateMinFee(int row, decimal derateFee)
        {
            //取已减免金额
            decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[row, 7].Text);

            //取余额
            decimal leftFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[row, 8].Text);

            //设置已减免金额
            this.fpFeeInfo_FeeCode.Cells[row, 7].Text = (deratedFee + derateFee).ToString();

            //设置余额
            this.fpFeeInfo_FeeCode.Cells[row, 8].Text = (leftFee - derateFee).ToString();

            return 1;
        }

        /// <summary>
        /// 按照项目减免
        /// </summary>
        /// <param name="row"></param>
        /// <param name="derateFee"></param>
        /// <returns></returns>
        private int SetAfterDerateFeeDetail(int row, decimal derateFee)
        {
            //取已减免金额
            decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[row, 6].Text);

            //取余额
            decimal leftFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[row, 7].Text);

            //设置已减免金额
            this.fpFeeInfo_Items.Cells[row, 6].Text = (deratedFee + derateFee).ToString();

            //设置余额t
            this.fpFeeInfo_Items.Cells[row, 7].Text = (leftFee - derateFee).ToString();

            return 1;
        }

        /// <summary>
        /// 取得最小费用行号
        /// </summary>
        /// <param name="feeCode"></param>
        /// <returns></returns>
        private int GetRowIndex(string feeCode)
        {
            int count = this.fpFeeInfo_FeeCode.RowCount;
            string strFeeCode = "";
            if (count == 0)
            {
                //未指定行
                return -1;
            }

            for (int i = 0; i < count; i++)
            {
                strFeeCode = this.fpFeeInfo_FeeCode.Cells[i, 1].Text;
                if (strFeeCode == feeCode)
                {
                    return i;
                    break;
                }
            }

            //未指定行
            return -1;
        }

        /// <summary>
        /// 取得项目行号
        /// </summary>
        /// <param name="feeCode"></param>
        /// <returns></returns>
        private int GetRowItemsIndex(string itemCode)
        {
            int count = this.fpFeeInfo_Items.RowCount;
            string strItemCode = "";
            if (count == 0)
            {
                //未指定行
                return -1;
            }

            for (int i = 0; i < count; i++)
            {
                strItemCode = this.fpFeeInfo_Items.Cells[i, 2].Text;
                if (strItemCode == itemCode)
                {
                    return i;
                    break;
                }
            }

            //未指定行
            return -1;
        }

        /// <summary>
        /// 将费用添加哈希表
        /// </summary>
        private void AddHasTable()
        {
            //this.minFeeHastable.Clear();
            int count = this.fpFeeInfo_FeeCode.Rows.Count;

            if (count <= 0) return;
            this.minFeeHastable = new Hashtable();
            for (int i = 0; i < count; i++)
            {
                this.minFeeHastable.Add(this.fpFeeInfo_FeeCode.Cells[i, 1].Text, this.fpFeeInfo_FeeCode.Cells[i, 8].Text);
            }

            this.rbCost.Checked = true;
            this.ntxtFee.Enabled = true;
            this.ntxtFee.Text = "0.00";
            this.rbRate.Checked = false;
            this.ntxRate.Enabled = false;
            this.ntxRate.Text = "0.00";
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        private void SetFeeDetailHead()
        {
            this.fpFeeInfo_Items.Columns[0].Label = "费用编码";
            this.fpFeeInfo_Items.Columns[1].Label = "费用名称";
            this.fpFeeInfo_Items.Columns[2].Label = "项目编码";
            this.fpFeeInfo_Items.Columns[3].Label = "项目名称";
            this.fpFeeInfo_Items.Columns[4].Label = "费用总额";
            this.fpFeeInfo_Items.Columns[5].Label = "自费金额";
            this.fpFeeInfo_Items.Columns[6].Label = "已减免金额";
            this.fpFeeInfo_Items.Columns[7].Label = "减免后金额";

        }

        //实体赋值
        private ArrayList GetChanges(DataTable dt)
        {
            ArrayList al = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                Neusoft.HISFC.Models.Fee.DerateFee info = new Neusoft.HISFC.Models.Fee.DerateFee();

                info.InpatientNO = dr[0].ToString(); //住院流水号 

                info.HappenNO = this.derateMgr.GetHappenNO(this.patientInfo.ID); //发生序号
                info.DerateKind.ID = dr[2].ToString(); //减免种类  

                info.DerateType.ID = dr[4].ToString(); //减免类型 
                info.FeeCode = dr[6].ToString();  //最小费用 
                info.FeeName = dr[7].ToString();

                info.DerateCost = Convert.ToDecimal(dr[8]); //减免金额 

                info.DerateCause = dr[9].ToString(); //减免原因 

                info.ConfirmOperator.ID = dr[10].ToString(); //批准人编码 

                info.ConfirmOperator.Name = dr[11].ToString(); // 批准人 

                info.DerateOper.Dept.ID = dr[12].ToString(); //  科室

                info.CancelDerateOper.ID = dr[14].ToString();

                info.CancelDerateOper.OperTime = Convert.ToDateTime(dr[15].ToString());

                info.DerateOper.ID = dr[16].ToString();

                info.DerateOper.OperTime = Convert.ToDateTime(dr[17]);

                info.ItemCode = dr[18].ToString();

                info.ItemName = dr[19].ToString();
                info.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(dr[20]);
                info.BalanceState = "0";
                al.Add(info);

            }
            return al;
        }

        /// <summary>
        /// 更具减免类型代码取名称
        /// </summary>
        /// <param name="derateKindID"></param>
        /// <returns></returns>
        private string GetDerateKindName(string derateKindID)
        {
            string derateName = string.Empty;
            switch (derateKindID)
            {
                case "0":
                    {
                        derateName = "总费用减免";
                        break;
                    }
                case "1":
                    {
                        derateName = "最小费用减免";
                        break;
                    }
                case "2":
                    {
                        derateName = "项目减免";
                        break;
                    }
                case "3":
                    {
                        derateName = "最小费用减免";
                        break;
                    }
                default:
                    break;
            }
            return derateName;
            //decode(derate_kind,'0','总费用减免','1','最小费用减免','项目减免','3','最小费用减免')
        }

        /// <summary>
        /// 减免类型
        /// </summary>
        /// <returns></returns>
        private Neusoft.FrameWork.Models.NeuObject GetDerateType()
        {
            return this.cmbDerateType.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
        }

        #endregion

        #region 共有方法

        #region 初始化费用
        /// <summary>
        /// 获得患者费用信息
        /// </summary>
        /// <returns></returns>
        protected virtual int GetFeeInfo()
        {
            //取总费用
            int returnValue = this.GetTotCost();
            if (returnValue == -1)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 获得已经减免的费用信息
        /// </summary>
        /// <returns></returns>
        protected virtual int GetDeratedFeeInfo()
        {
            ArrayList al = this.derateMgr.GetDeratedDetail(this.patientInfo.ID);

            if (al == null)
            {
                MessageBox.Show(Language.Msg(this.derateMgr.Err));
                return -1;
            }

            //插入dataset
            this.InSertDataSet(al);

            this.dtDerated.AcceptChanges();
            return 1;
        }

        /// <summary>
        /// 获取总费用
        /// </summary>
        /// <returns></returns>
        protected virtual int GetTotCost()
        {
            this.fpFeeInfo_TotFee.AddRows(0, 1);
            string deratedCost = this.derateMgr.GetTotDerateFeeByClinicNO(this.patientInfo.ID);
            if (deratedCost == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("查询减免金额失败" + this.derateMgr.Err));
                return -1;
            }

            this.fpFeeInfo_TotFee.Cells[0, 0].Text = this.patientInfo.FT.TotCost.ToString();
            this.fpFeeInfo_TotFee.Cells[0, 1].Text = this.patientInfo.FT.OwnCost.ToString();
            this.fpFeeInfo_TotFee.Cells[0, 2].Text = this.patientInfo.FT.PayCost.ToString();
            this.fpFeeInfo_TotFee.Cells[0, 3].Text = this.patientInfo.FT.PubCost.ToString();
            this.fpFeeInfo_TotFee.Cells[0, 4].Text = deratedCost;
            this.fpFeeInfo_TotFee.Cells[0, 5].Text = (this.patientInfo.FT.OwnCost - Neusoft.FrameWork.Function.NConvert.ToDecimal(deratedCost)).ToString();



            return 1;
        }

        /// <summary>
        /// 获得最小费用
        /// </summary>
        /// <returns></returns>
        protected virtual int GetMinfee()
        {
            DataSet ds = new DataSet();
            ds = this.derateMgr.GetMinFeeAndDerateByInpatientNO(this.patientInfo.ID);
            if (ds == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("查询患者最小费用出错") + this.derateMgr.Err);
                return -1;
            }

            this.fpFeeInfo_FeeCode.DataSource = ds;

            this.fpFeeInfo_FeeCode.Columns[0].Visible = false;
            this.fpFeeInfo_FeeCode.Columns[1].Visible = false;

            this.fpFeeInfo_FeeCode.Columns[2].Width = 80;

            return 1;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        protected virtual int GetFeeDetail()
        {
            DataSet ds = new DataSet();
            ds = this.derateMgr.GetFeeDetailByInpatientNO(this.patientInfo.ID);
            if (ds == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("查询患者费用明细出错") + this.derateMgr.Err);
                return -1;
            }

            this.fpFeeInfo_Items.DataSource = ds;

            this.fpFeeInfo_Items.Columns[8].Visible = false;
            //this.fpFeeInfo_FeeCode.Columns[1].Visible = false;

            this.fpFeeInfo_Items.Columns[0].Width = 80;
            this.fpFeeInfo_Items.Columns[1].Width = 80;
            this.fpFeeInfo_Items.Columns[2].Width = 80;
            this.fpFeeInfo_Items.Columns[3].Width = 80;
            SetFeeDetailHead();
            return 1;
        }


        #endregion

        #region 减免费用
        /// <summary>
        /// 减免总费用
        /// </summary>
        /// <param name="isRate"></param>
        /// <param name="derateFee"></param>
        /// <param name="totOwnFee"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        protected int DerateTotoalFee(bool isRate, decimal derateFee, decimal totOwnFee, decimal rate)
        {


            if (!isRate) //按金额
            {
                if (derateFee <= 0)
                {
                    MessageBox.Show(Language.Msg("请输入正确的减免金额(大于零)"));
                    this.ntxtFee.Focus();
                    return -1;
                }

                if (totOwnFee <= 0)
                {
                    MessageBox.Show(Language.Msg("自费金额不能小于等于0"));
                    return -1;
                }
                if (derateFee >= totOwnFee)
                {
                    MessageBox.Show(Language.Msg("减免金额应该小于或等于自费总额"));
                    this.ntxtFee.Focus();
                    return -1;
                }

                rate = Neusoft.FrameWork.Public.String.FormatNumber(derateFee / totOwnFee, 4);
                this.ntxRate.Text = rate.ToString();
            }



            if (rate > 1 || rate < 0)
            {
                MessageBox.Show(Language.Msg("减免比例不正确,请核实"));
                return -1;
            }

            if (isRate)
            {
                derateFee = Neusoft.FrameWork.Public.String.FormatNumber(totOwnFee * rate, 2);
            }
            //已经减免的金额
            decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_TotFee.Cells[0, 4].Text);
            if (totOwnFee <= deratedFee + derateFee)
            {
                MessageBox.Show(Language.Msg("减免的金额不能大于患者的花费总额"));
                return -1;
            }

            ArrayList al = new ArrayList();

            Neusoft.HISFC.Models.Fee.DerateFee derateFeeObj = null;
            decimal sumTotCost = 0;
            for (int i = 0; i < this.fpFeeInfo_FeeCode.RowCount; i++)
            {
                derateFeeObj = new Neusoft.HISFC.Models.Fee.DerateFee();
                derateFeeObj.InpatientNO = this.patientInfo.ID;
                derateFeeObj.DerateKind.ID = "0";
                derateFeeObj.DerateKind.Name = this.GetDerateKindName(derateFeeObj.DerateKind.ID);
                derateFeeObj.FeeCode = this.fpFeeInfo_FeeCode.Cells[i, 1].Text;
                derateFeeObj.FeeName = this.fpFeeInfo_FeeCode.Cells[i, 2].Text;
                derateFeeObj.ItemCode = this.fpFeeInfo_FeeCode.Cells[i, 1].Text;
                derateFeeObj.ItemName = this.fpFeeInfo_FeeCode.Cells[i, 2].Text;
                derateFeeObj.IsValid = true;
                derateFeeObj.DerateOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;//((Neusoft.FrameWork.Management.Connection.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                derateFeeObj.DerateOper.Dept.Name = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                derateFeeObj.DerateOper.ID = this.derateMgr.Operator.ID;
                derateFeeObj.DerateType = this.GetDerateType();
                decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 4].Text);

                if (!isRate) //不是按比例用最后一项找平
                {
                    if (i == this.fpFeeInfo_FeeCode.RowCount - 1)
                    {
                        derateFeeObj.DerateCost = derateFee - sumTotCost;
                    }
                    else
                    {
                        rate *= 10000;
                        decimal dc = rate - (int)rate;
                        if (dc > 0)
                        {
                            rate += 1;
                        }
                        rate = rate / 10000;

                        derateFeeObj.DerateCost = ownCost * rate;
                    }
                }
                else //是比例按照比例处理
                {
                    derateFeeObj.DerateCost = Neusoft.FrameWork.Public.String.FormatNumber(ownCost * rate, 2);
                }

                sumTotCost += derateFeeObj.DerateCost;

                if (sumTotCost > derateFee)
                {
                    derateFeeObj.DerateCost = derateFeeObj.DerateCost + sumTotCost - derateFee;
                }
                al.Add(derateFeeObj);
                this.SetAfterDerateMinFee(i, derateFeeObj.DerateCost);
                if (sumTotCost > derateFee)
                {
                    break;
                }

            }

            //插入dataset
            this.InSertDataSet(al);

            //this.fpFeeInfo_TotFee.Cells[0, 1].Text = (totOwnFee - derateFee).ToString();
            this.fpFeeInfo_TotFee.Cells[0, 4].Text = (deratedFee + derateFee).ToString();

            //this.dtDerated.AcceptChanges();
            this.AddHasTable();
            return 1;
        }

        /// <summary>
        /// 按照最小费用减免
        /// </summary>
        /// <param name="isRate"></param>
        /// <param name="derateFee"></param>
        /// <param name="rate"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        protected int DerateMinFee(bool isRate, decimal derateFee, decimal rate, bool isAll)
        {
            decimal leftCost = 0m;  //剩余金额
            bool isAllowDerate = true;
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Fee.DerateFee derateFeeObj = null;

            if (!isRate) //按金额
            {
                if (derateFee <= 0)
                {
                    MessageBox.Show(Language.Msg("请输入正确的减免金额(大于零)"));
                    this.ntxtFee.Focus();
                    return -1;
                }
            }
            else
            {
                if (rate > 1 || rate < 0)
                {
                    MessageBox.Show(Language.Msg("减免比例不正确,请核实"));
                    return -1;
                }
            }

            decimal deratedFeeTotal = 0;
            if (isAll) //全选
            {

                for (int i = 0; i < this.fpFeeInfo_FeeCode.RowCount; i++)
                {
                    decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 4].Text);
                    leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 8].Text);

                    //是否允许减免
                    if (!isRate) //不是比例
                    {
                        isAllowDerate = this.ValidDerateCost(derateFee, leftCost);

                    }
                    else //按照比例
                    {
                        decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 4].Text);
                        leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 8].Text);
                        derateFee = ownCost * rate;

                        isAllowDerate = this.ValidDerateCost(derateFee, leftCost);
                    }
                    if (!isAllowDerate)
                    {
                        MessageBox.Show(Language.Msg(this.fpFeeInfo_FeeCode.Cells[i, 2].Text + "可减免金额不足!"));
                        return -1;
                    }
                }
                //开始减免
                for (int i = 0; i < this.fpFeeInfo_FeeCode.RowCount; i++)
                {
                    decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 4].Text);
                    leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 8].Text);

                    //是否允许减免
                    if (isRate) //不是比例
                    {
                        decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 4].Text);
                        leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[i, 8].Text);
                        derateFee = ownCost * rate;
                    }

                    derateFeeObj = new Neusoft.HISFC.Models.Fee.DerateFee();
                    derateFeeObj.InpatientNO = this.patientInfo.ID;
                    derateFeeObj.DerateKind.ID = "1";
                    derateFeeObj.DerateKind.Name = this.GetDerateKindName(derateFeeObj.DerateKind.ID);
                    derateFeeObj.FeeCode = this.fpFeeInfo_FeeCode.Cells[i, 1].Text;
                    derateFeeObj.FeeName = this.fpFeeInfo_FeeCode.Cells[i, 2].Text;
                    derateFeeObj.ItemCode = this.fpFeeInfo_FeeCode.Cells[i, 1].Text;
                    derateFeeObj.ItemName = this.fpFeeInfo_FeeCode.Cells[i, 2].Text;
                    derateFeeObj.DerateCost = derateFee;
                    derateFeeObj.IsValid = true;
                    derateFeeObj.DerateOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;//((Neusoft.FrameWork.Management.Connection.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                    derateFeeObj.DerateType = this.GetDerateType();
                    derateFeeObj.DerateOper.Dept.Name = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                    derateFeeObj.DerateOper.ID = this.derateMgr.Operator.ID;
                    //设置减免后金额
                    this.SetAfterDerateMinFee(i, derateFee);
                    deratedFeeTotal += derateFee;

                    al.Add(derateFeeObj);

                }

                this.InSertDataSet(al);
                this.SetAtferDerateTotFee(deratedFeeTotal);
            }
            else //单条
            {

                decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[this.fpFeeInfo_FeeCode.ActiveRowIndex, 4].Text);
                leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_FeeCode.Cells[this.fpFeeInfo_FeeCode.ActiveRowIndex, 8].Text);
                if (isRate)
                {
                    derateFee = ownCost * rate;
                }

                isAllowDerate = this.ValidDerateCost(derateFee, leftCost);
                if (!isAllowDerate)
                {
                    MessageBox.Show(Language.Msg(this.fpFeeInfo_FeeCode.Cells[this.fpFeeInfo_FeeCode.ActiveRowIndex, 2].Text + "的可减免金额不足"));
                    return -1;
                }

                derateFeeObj = new Neusoft.HISFC.Models.Fee.DerateFee();
                derateFeeObj.InpatientNO = this.patientInfo.ID;
                derateFeeObj.DerateKind.ID = "1";
                derateFeeObj.DerateKind.Name = this.GetDerateKindName(derateFeeObj.DerateKind.ID);
                derateFeeObj.FeeCode = this.fpFeeInfo_FeeCode.Cells[this.fpFeeInfo_FeeCode.ActiveRowIndex, 1].Text;
                derateFeeObj.FeeName = this.fpFeeInfo_FeeCode.Cells[this.fpFeeInfo_FeeCode.ActiveRowIndex, 2].Text;
                derateFeeObj.ItemCode = this.fpFeeInfo_FeeCode.Cells[this.fpFeeInfo_FeeCode.ActiveRowIndex, 1].Text;
                derateFeeObj.ItemName = this.fpFeeInfo_FeeCode.Cells[this.fpFeeInfo_FeeCode.ActiveRowIndex, 2].Text;
                derateFeeObj.DerateCost = derateFee;
                derateFeeObj.IsValid = true;
                derateFeeObj.DerateOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;//((Neusoft.FrameWork.Management.Connection.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                derateFeeObj.DerateType = this.GetDerateType();
                derateFeeObj.DerateOper.Dept.Name = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                derateFeeObj.DerateOper.ID = this.derateMgr.Operator.ID;
                //设置减免后金额
                this.SetAfterDerateMinFee(this.fpFeeInfo_FeeCode.ActiveRowIndex, derateFee);

                al.Add(derateFeeObj);
                this.InSertDataSet(al);
                this.SetAtferDerateTotFee(derateFee);
            }

            this.AddHasTable();
            return 1;
        }

        /// <summary>
        /// 按照项目减免
        /// </summary>
        /// <param name="isRate"></param>
        /// <param name="derateFee"></param>
        /// <param name="rate"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        protected int DerateFeeDetail(bool isRate, decimal derateFee, decimal rate, bool isAll)
        {
            Hashtable ht = new Hashtable();
            decimal leftCost = 0m;  //剩余金额
            bool isAllowDerate = true;
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Fee.DerateFee derateFeeObj = null;

            if (!isRate) //按金额
            {
                if (derateFee <= 0)
                {
                    MessageBox.Show(Language.Msg("请输入正确的减免金额(大于零)"));
                    this.ntxtFee.Focus();
                    return -1;
                }
            }
            else
            {
                if (rate > 1 || rate < 0)
                {
                    MessageBox.Show(Language.Msg("减免比例不正确,请核实"));
                    return -1;
                }
            }

            decimal deratedFeeTotal = 0;
            if (isAll) //全选
            {
                for (int i = 0; i < this.fpFeeInfo_Items.RowCount; i++)
                {
                    string feeCode = this.fpFeeInfo_Items.Cells[i, 0].Text;
                    decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 6].Text);
                    leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 7].Text);

                    //是否允许减免
                    if (!isRate) //不是比例
                    {
                        isAllowDerate = this.ValidDerateCost(derateFee, leftCost);

                    }
                    else //按照比例
                    {
                        decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 5].Text);
                        leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 7].Text);
                        derateFee = ownCost * rate;

                        isAllowDerate = this.ValidDerateCost(derateFee, leftCost);
                    }
                    if (!isAllowDerate)
                    {
                        MessageBox.Show(Language.Msg(this.fpFeeInfo_Items.Cells[i, 2].Text + "的可减免金额不足"));
                        this.AddHasTable();
                        return -1;
                    }

                    bool isExist = this.minFeeHastable.ContainsKey(feeCode);

                    if (isExist)
                    {
                        decimal myLeftcost = Neusoft.FrameWork.Function.NConvert.ToDecimal(minFeeHastable[feeCode]);
                        if (myLeftcost <= derateFee)
                        {
                            MessageBox.Show(Language.Msg(this.fpFeeInfo_Items.Cells[i, 1].Text + "金额小于减免金额"));
                            this.AddHasTable();
                            return -1;
                        }
                        else
                        {
                            minFeeHastable[feeCode] = myLeftcost - derateFee;
                        }
                    }

                }
                //开始减免
                for (int i = 0; i < this.fpFeeInfo_Items.RowCount; i++)
                {
                    decimal deratedFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 6].Text);
                    leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 7].Text);

                    //是否允许减免
                    if (isRate) //不是比例
                    {
                        decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 5].Text);
                        leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[i, 7].Text);
                        derateFee = ownCost * rate;
                    }

                    if (!isAllowDerate)
                    {
                        MessageBox.Show(Language.Msg(this.fpFeeInfo_Items.Cells[i, 1].Text + "的可减免金额不足"));
                        this.AddHasTable();
                        return -1;
                    }

                    derateFeeObj = new Neusoft.HISFC.Models.Fee.DerateFee();
                    derateFeeObj.InpatientNO = this.patientInfo.ID;
                    derateFeeObj.DerateKind.ID = "2";
                    derateFeeObj.DerateKind.Name = this.GetDerateKindName(derateFeeObj.DerateKind.ID);
                    derateFeeObj.FeeCode = this.fpFeeInfo_Items.Cells[i, 0].Text;
                    derateFeeObj.FeeName = this.fpFeeInfo_Items.Cells[i, 1].Text;
                    derateFeeObj.DerateCost = derateFee;
                    derateFeeObj.ItemCode = this.fpFeeInfo_Items.Cells[i, 2].Text;
                    derateFeeObj.ItemName = this.fpFeeInfo_Items.Cells[i, 3].Text;
                    derateFeeObj.IsValid = true;
                    derateFeeObj.DerateOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;//((Neusoft.FrameWork.Management.Connection.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                    derateFeeObj.DerateType = this.GetDerateType();
                    derateFeeObj.DerateOper.Dept.Name = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                    derateFeeObj.DerateOper.ID = this.derateMgr.Operator.ID;
                    //设置减免后金额

                    int row = this.GetRowIndex(derateFeeObj.FeeCode);

                    if (row < 0)
                    {
                        MessageBox.Show(Language.Msg("最小费用信息中没有" + derateFeeObj.FeeName + "对应的行"));
                        return -1;
                    }

                    this.SetAfterDerateMinFee(row, derateFee);

                    this.SetAfterDerateFeeDetail(i, derateFee);
                    deratedFeeTotal += derateFee;

                    al.Add(derateFeeObj);

                }

                this.InSertDataSet(al);
                this.SetAtferDerateTotFee(deratedFeeTotal);
            }
            else //单条
            {

                decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[this.fpFeeInfo_Items.ActiveRowIndex, 5].Text);
                leftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_Items.Cells[this.fpFeeInfo_Items.ActiveRowIndex, 7].Text);
                if (isRate)
                {
                    derateFee = ownCost * rate;
                }

                if (leftCost < derateFee)
                {
                    MessageBox.Show(Language.Msg("减免金额不能大于余额"));
                    return -1;
                }

                derateFeeObj = new Neusoft.HISFC.Models.Fee.DerateFee();
                derateFeeObj.InpatientNO = this.patientInfo.ID;
                derateFeeObj.DerateKind.ID = "2";
                derateFeeObj.DerateKind.Name = this.GetDerateKindName(derateFeeObj.DerateKind.ID);
                derateFeeObj.FeeCode = this.fpFeeInfo_Items.Cells[this.fpFeeInfo_Items.ActiveRowIndex, 0].Text;
                derateFeeObj.FeeName = this.fpFeeInfo_Items.Cells[this.fpFeeInfo_Items.ActiveRowIndex, 1].Text;
                derateFeeObj.ItemCode = this.fpFeeInfo_Items.Cells[this.fpFeeInfo_Items.ActiveRowIndex, 2].Text;
                derateFeeObj.ItemName = this.fpFeeInfo_Items.Cells[this.fpFeeInfo_Items.ActiveRowIndex, 3].Text;
                derateFeeObj.DerateCost = derateFee;
                derateFeeObj.IsValid = true;
                derateFeeObj.DerateOper.Dept.ID = this.patientInfo.PVisit.PatientLocation.Dept.ID;//((Neusoft.FrameWork.Management.Connection.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                derateFeeObj.DerateType = this.GetDerateType();
                derateFeeObj.DerateOper.Dept.Name = this.patientInfo.PVisit.PatientLocation.Dept.Name;
                derateFeeObj.DerateOper.ID = this.derateMgr.Operator.ID;
                //设置减免后金额
                //this.setAfterDerateMinFee(this.fpFeeInfo_Items.ActiveRowIndex, derateFee);

                al.Add(derateFeeObj);
                this.InSertDataSet(al);
                int row = this.GetRowIndex(derateFeeObj.FeeCode);

                if (row < 0)
                {
                    MessageBox.Show(Language.Msg("最小费用信息中没有" + derateFeeObj.FeeName + "对应的行"));
                    return -1;
                }

                this.SetAfterDerateMinFee(row, derateFee);


                this.SetAfterDerateFeeDetail(this.fpFeeInfo_Items.ActiveRowIndex, derateFee);

                this.SetAtferDerateTotFee(derateFee);
            }

            return 1;
        }

        #endregion

        #region 取消减免

        /// <summary>
        /// 全部取消减免
        /// </summary>
        /// <returns></returns>
        protected int CancelDerateAll()
        {
            for (int i = this.fpDerateInfo_Sheet1.RowCount - 1; i >= 0; i--)
            {
                this.CancelDerateOne(i);
            }
            return 1;

        }

        /// <summary>
        /// 单条取消减免
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected int CancelDerateOne(int row)
        {
            if (row < 0)
            {
                MessageBox.Show(Language.Msg("请选择减免记录"));
            }

            Neusoft.HISFC.Models.Fee.DerateFee derateFeeObj = new Neusoft.HISFC.Models.Fee.DerateFee();
            derateFeeObj.DerateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpDerateInfo_Sheet1.Cells[row, 8].Text);
            derateFeeObj.FeeCode = this.fpDerateInfo_Sheet1.Cells[row, 6].Text;
            derateFeeObj.FeeName = this.fpDerateInfo_Sheet1.Cells[row, 7].Text;
            derateFeeObj.ItemCode = this.fpDerateInfo_Sheet1.Cells[row, 18].Text;
            derateFeeObj.ItemName = this.fpDerateInfo_Sheet1.Cells[row, 19].Text;
            derateFeeObj.DerateKind.ID = this.fpDerateInfo_Sheet1.Cells[row, 2].Text;
            derateFeeObj.HappenNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpDerateInfo_Sheet1.Cells[row, 1].Text);
            derateFeeObj.InpatientNO = this.fpDerateInfo_Sheet1.Cells[row, 0].Text;
            derateFeeObj.DerateOper.ID = this.fpDerateInfo_Sheet1.Cells[row, 16].Text;
            derateFeeObj.DerateOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpDerateInfo_Sheet1.Cells[row, 17].Text);
            derateFeeObj.DerateType.ID = this.fpDerateInfo_Sheet1.Cells[row, 4].Text;
            derateFeeObj.BalanceState = "0";
            derateFeeObj.DerateOper.Dept = ((Neusoft.FrameWork.Management.Connection.Operator) as Neusoft.HISFC.Models.Base.Employee).Dept;
            if (derateFeeObj.DerateKind.ID == "2")
            {
                int rowItemsIndex = this.GetRowItemsIndex(derateFeeObj.ItemCode);
                if (rowItemsIndex < 0)
                {
                    MessageBox.Show(Language.Msg("项目信息中没有" + derateFeeObj.ItemName + "对应的行"));
                    return -1;
                }
                this.SetAfterDerateFeeDetail(rowItemsIndex, -derateFeeObj.DerateCost);
            }


            int rowIndex = this.GetRowIndex(derateFeeObj.FeeCode);

            if (row < 0)
            {
                MessageBox.Show(Language.Msg("最小费用信息中没有" + derateFeeObj.FeeName + "对应的行"));
                return -1;
            }

            this.SetAfterDerateMinFee(rowIndex, -derateFeeObj.DerateCost);
            this.SetAtferDerateTotFee(-derateFeeObj.DerateCost);
            this.fpDerateInfo_Sheet1.RemoveRows(row, 1);

            //
            if (derateFeeObj.HappenNO != 0)
            {
                alDelete.Add(derateFeeObj);
            }

            return 1;
        }


        #endregion

        #region 校验
        protected int ValidDerateType()
        {
            if (this.cmbDerateType.Tag == null || this.cmbDerateType.Tag.ToString() == "" || this.cmbDerateType.SelectedItem == null)
            {
                MessageBox.Show("请选择减免类型");
                this.cmbDerateType.Focus();
                return -1;
            }
            return 1;
        }
        #endregion

        #region 保存

        protected override int OnSave(object sender, object neuObject)
        {
            this.fpDerateInfo.StopCellEditing();
            DataTable dtAdd = this.dtDerated.GetChanges(DataRowState.Added);
            DataTable dtDelete = this.dtDerated.GetChanges(DataRowState.Deleted);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.derateMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int returnValue = 1;
            DateTime operDateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.derateMgr.GetSysDateTime());
            if (dtAdd != null)
            {
                ArrayList alAdd = this.GetChanges(dtAdd);

                foreach (Neusoft.HISFC.Models.Fee.DerateFee derateFeeObj in alAdd)
                {
                    derateFeeObj.HappenNO = this.derateMgr.GetHappenNO(derateFeeObj.InpatientNO);
                    derateFeeObj.DerateOper.ID = this.derateMgr.Operator.ID;
                    derateFeeObj.DerateOper.OperTime = operDateTime;

                    returnValue = this.derateMgr.InsertDerateFeeInfo(derateFeeObj);
                    if (returnValue < 0)
                    {
                        MessageBox.Show(Language.Msg(this.derateMgr.Err));
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                }
            }
            //取消减免
            if (this.alDelete != null && this.alDelete.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Fee.DerateFee derateFeeObj in this.alDelete)
                {
                    derateFeeObj.CancelDerateOper.ID = this.derateMgr.Operator.ID;
                    derateFeeObj.CancelDerateOper.OperTime = operDateTime;
                    derateFeeObj.IsValid = false;
                    returnValue = this.derateMgr.UpdateDerateFeeInfo(derateFeeObj);
                    if (returnValue < 0)
                    {
                        MessageBox.Show(Language.Msg(this.derateMgr.Err));
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                }

            }
            returnValue = this.feeInpatient.OpenAccount(this.patientInfo.ID);
            {
                if (returnValue == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("减免失败封帐失败" + this.feeInpatient.Err, 211);
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.dtDerated.AcceptChanges();

            MessageBox.Show(Language.Msg("保存成功"));

            //this.ResetFp();

            //this.GetTotCost();
            //this.GetMinfee();
            //this.GetFeeDetail();
            //this.GetDeratedFeeInfo();
            //this.alDelete.Clear();

            this.Clear();

            return base.OnSave(sender, neuObject);
        }

        public override int Exit(object sender, object neuObject)
        {
            if (this.patientInfo == null)
            {
                return base.Exit(sender, neuObject);
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return base.Exit(sender, neuObject);
            }

            if (this.feeInpatient.OpenAccount(this.patientInfo.ID) == -1)
            {
                MessageBox.Show("开帐失败" + this.feeInpatient.Err);
                return -1;
            }
            return base.Exit(sender, neuObject);
        }
        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected virtual int Init()
        {
            this.rbCost.Checked = true;
            this.ntxtFee.Enabled = true;

            this.ntxRate.Enabled = false;

            this.InitDataSetDerated();

            this.InitControl();

            return 1;
        }

        /// <summary>
        /// 初始化控件信息
        /// </summary>
        /// <returns></returns>
        protected virtual int InitControl()
        {
            ArrayList alDerateTypeList = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DERATEFEETYPE);
            this.cmbDerateType.AddItems(alDerateTypeList);

            for (int i = 0; i < this.fpDerateInfo_Sheet1.Columns.Count; i++)
            {
                this.fpDerateInfo_Sheet1.Columns[i].Locked = true;
            }

            for (int i = 0; i < this.fpFeeInfo_TotFee.Columns.Count; i++)
            {
                this.fpFeeInfo_TotFee.Columns[i].Locked = true;
            }
            for (int i = 0; i < this.fpFeeInfo_FeeCode.Columns.Count; i++)
            {
                this.fpFeeInfo_FeeCode.Columns[i].Locked = true;
            }
            for (int i = 0; i < this.fpFeeInfo_Items.Columns.Count; i++)
            {
                this.fpFeeInfo_Items.Columns[i].Locked = true;
            }
            return 1;
        }

        #endregion

        /// <summary>
        /// 清屏
        /// </summary>
        protected virtual void Clear()
        {
            //患者基本信息
            this.ucInpatientInfo1.Clear();

            //
            this.ucQueryInpatientNo1.Focus();

            //清除fp
            this.ResetFp();

            this.alDelete.Clear();
            if (this.minFeeHastable != null)
            {
                this.minFeeHastable.Clear();
            }
            if (this.patientInfo != null || patientInfo.ID == "")
            {
                //开帐


                if (this.feeInpatient.OpenAccount(this.patientInfo.ID) == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("开帐失败" + this.feeInpatient.Err, 211);
                    return;
                }
            }
            return;
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        protected virtual void ResetFp()
        {
            //清除fpFeeInfo_TotFee
            int count = this.fpFeeInfo_TotFee.RowCount;
            if (count > 0)
            {
                this.fpFeeInfo_TotFee.RemoveRows(0, count);
            }

            this.dtDerated.Clear();

            if (this.fpFeeInfo_Items.RowCount > 0)
            {
                this.fpFeeInfo_Items.RemoveRows(0, this.fpFeeInfo_Items.RowCount);
            }
            if (this.fpFeeInfo_FeeCode.RowCount > 0)
            {
                this.fpFeeInfo_FeeCode.RemoveRows(0, this.fpFeeInfo_FeeCode.RowCount);
            }
            if (this.fpFeeInfo_TotFee.RowCount > 0)
            {
                this.fpFeeInfo_TotFee.RemoveRows(0, this.fpFeeInfo_TotFee.RowCount);
            }


        }
        #endregion

        #region 事件
        private void ucQueryInpatientNo1_myEvent()
        {
            //this.dtDerated.Clear();
            this.Clear();

            if (string.IsNullOrEmpty(this.ucQueryInpatientNo1.InpatientNo))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有该患者信息"));
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo1.InpatientNo);

            if (this.patientInfo == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.radtIntegrate.Err));
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            //判断封帐
            if ((this.feeInpatient.GetStopAccount(this.patientInfo.ID)) == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者处于封帐状态,可能正在结算,请稍后再做此操作!", 111);
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            if (this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString())
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该患者处于无费退院状态,不能进行费用减免"));
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            if (this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该患者已经结算,不能进行费用减免"));
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            //封帐

            int returnValue = this.feeInpatient.CloseAccount(this.patientInfo.ID);
            {
                if (returnValue == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("封帐失败" + this.feeInpatient.Err, 211);
                    return;
                }
            }

            //界面赋值
            this.ucInpatientInfo1.PatientInfoObj = patientInfo;

            this.ResetFp();

            //取总费用
            returnValue = this.GetTotCost();
            if (returnValue == -1)
            {
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            //最小费用
            returnValue = this.GetMinfee();
            if (returnValue == -1)
            {
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            //费用项目
            returnValue = this.GetFeeDetail();
            if (returnValue == -1)
            {
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            returnValue = this.GetDeratedFeeInfo();
            if (returnValue < 0)
            {
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            this.AddHasTable();

            //设置焦点
            if (this.rbCost.Checked)
            {
                this.ntxtFee.Focus();
            }

            if (this.rbRate.Checked)
            {
                this.ntxRate.Focus();
            }



        }

        private void rbCost_CheckedChanged(object sender, EventArgs e)
        {
            this.ntxtFee.Enabled = this.rbCost.Checked;
            this.ntxtFee.Focus();

        }

        private void rbRate_CheckedChanged(object sender, EventArgs e)
        {
            this.ntxRate.Enabled = this.rbRate.Checked;
            this.ntxRate.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() == "DEVENV")
            {
                return;
            }
            //初始化
            this.Init();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btCancelAll, "取消全部减免记录");
            tip = new ToolTip();
            tip.SetToolTip(this.btCancelOne, "取消选中减免记录");
            tip = new ToolTip();
            tip.SetToolTip(this.btDerateAll, "减免多条记录");
            tip = new ToolTip();
            tip.SetToolTip(this.btDerateOne, "减免选中记录");
            base.OnLoad(e);
        }

        private void btDerateOne_Click(object sender, EventArgs e)
        {
            int returnValue = this.ValidDerateType();
            if (returnValue < 0)
            {
                return;
            }

            if (this.fpFeeInfo.ActiveSheetIndex == 0)
            {
                decimal totOwncost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_TotFee.Cells[0, 1].Text);
                this.DerateTotoalFee(this.rbRate.Checked, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxtFee.Text), totOwncost, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxRate.Text));
            }
            if (this.fpFeeInfo.ActiveSheetIndex == 1)
            {
                this.DerateMinFee(this.rbRate.Checked, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxtFee.Text), Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxRate.Text), false);
            }
            if (this.fpFeeInfo.ActiveSheetIndex == 2)
            {
                this.DerateFeeDetail(this.rbRate.Checked, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxtFee.Text), Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxRate.Text), false);
            }
        }

        private void btDerateAll_Click(object sender, EventArgs e)
        {
            int returnValue = this.ValidDerateType();
            if (returnValue < 0)
            {
                return;
            }
            if (this.fpFeeInfo.ActiveSheetIndex == 0)
            {
                decimal totOwncost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpFeeInfo_TotFee.Cells[0, 1].Text);
                this.DerateTotoalFee(this.rbRate.Checked, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxtFee.Text), totOwncost, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxRate.Text));
            }
            if (this.fpFeeInfo.ActiveSheetIndex == 1)
            {
                this.DerateMinFee(this.rbRate.Checked, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxtFee.Text), Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxRate.Text), true);
            }
            if (this.fpFeeInfo.ActiveSheetIndex == 2)
            {
                this.DerateFeeDetail(this.rbRate.Checked, Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxtFee.Text), Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxRate.Text), true);
            }
        }

        private void btCancelOne_Click(object sender, EventArgs e)
        {
            //int returnValue = this.ValidDerateType();
            //if (returnValue < 0)
            //{
            //    return;
            //}
            if (this.fpDerateInfo_Sheet1.RowCount <= 0)
            {
                MessageBox.Show(Language.Msg("没有减免记录"));
                return;
            }
            this.CancelDerateOne(this.fpDerateInfo_Sheet1.ActiveRowIndex);

        }

        private void btCancelAll_Click(object sender, EventArgs e)
        {
            //int returnValue = this.ValidDerateType();
            //if (returnValue < 0)
            //{
            //    return;
            //}
            if (this.fpDerateInfo_Sheet1.RowCount <= 0)
            {
                MessageBox.Show(Language.Msg("没有减免记录"));
                return;
            }
            this.CancelDerateAll();
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            tooBarService.AddToolButton("清屏", "清屏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);

            this.FindForm().FormClosing += new FormClosingEventHandler(ucInpatientDerateFee_FormClosing);

            return this.tooBarService;
        }

        void ucInpatientDerateFee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "")
                {
                    return;
                }
            }

            if (this.feeInpatient.OpenAccount(this.patientInfo.ID) == -1)
            {
                MessageBox.Show("开帐失败" + this.feeInpatient.Err);

                return;
            }

            return;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "清屏":
                    {
                        this.Clear();
                        break;
                    }
                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        private void ntxtFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbDerateType.Focus();
            }
        }

        private void ntxRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbDerateType.Focus();
            }
        }

        #endregion


    }

}
