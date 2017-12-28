using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Report
{
    /// <summary>
    /// [功能描述: 门诊日报维护]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007-09-17]<br></br>
    /// 
    /// <修改记录
    ///		修改人 =
    ///		修改时间 =
    ///		修改目的 =
    ///		修改描述 =
    ///  />
    /// </summary>
    public partial class ucDayReportRegister : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDayReportRegister()
        {
            InitializeComponent();
        }

        #region 变量

        private DataTable dtDayReport = null;
        private DataView dvDayReport = null;
        private DateTime dtTime = DateTime.Now.Date;
        
        //标志日报是否存储在数据库中 true - 已存储, false - 未存储
        private bool hasRecord;

        #endregion

        #region 方法

        /// <summary>
        /// 初始化DateTable字段
        /// </summary>
        private void InitDataSet()
        {
            this.dtDayReport = new DataTable("DayReportRegister");

            this.dtDayReport.Columns.AddRange(new DataColumn[]
			{
                new DataColumn("DateStat",typeof(DateTime)),
                new DataColumn("DeptCode",typeof(string)),
                new DataColumn("DeptName",typeof(string)),
                new DataColumn("ClinicNum",typeof(int)),
                new DataColumn("EmcNum",typeof(int)),
                new DataColumn("EmcDeadNum",typeof(int)),
                new DataColumn("ObserveNum",typeof(int)),
                new DataColumn("ObserveDeadNum",typeof(int)),
                new DataColumn("ReDiagnoseNum",typeof(int)),
                new DataColumn("ClcDiagnoseNum",typeof(int)),
                new DataColumn("SpecialNum",typeof(int)),
                new DataColumn("HosInsuranceNum",typeof(int)),
                new DataColumn("BdCheckNum",typeof(int))
			});
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        private void InitFrp(DateTime dateTime)
        {

            Neusoft.HISFC.BizLogic.HealthRecord.DayReportRegister dayReport = new Neusoft.HISFC.BizLogic.HealthRecord.DayReportRegister();
            ArrayList al = new ArrayList();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化表格，请稍候...");
            Application.DoEvents();

            al = dayReport.QueryByStatTime(dateTime);
            this.hasRecord = true;

           /*本段内容为默认初始化farpoint
            if (al.Count == 0)
            {
                this.hasRecord = false;
                al = dayReport.QueryAllDept(dateTime);
            }
            else
            {
                this.hasRecord = true;
            }
            */
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //清空原有数据
            this.dtDayReport.Rows.Clear();

            Neusoft.HISFC.Models.HealthRecord.DayReportRegister regReport = new Neusoft.HISFC.Models.HealthRecord.DayReportRegister();

            foreach (object obj in al)
            {
                regReport = obj as Neusoft.HISFC.Models.HealthRecord.DayReportRegister;

                this.dtDayReport.Rows.Add(new object[]
                {
                    regReport.DateStat,
                    regReport.Dept.ID,
                    regReport.Dept.Name,
                    regReport.ClinicNum,
                    regReport.EmcNum,
                    regReport.EmcDeadNum,
                    regReport.ObserveNum,
                    regReport.ObserveDeadNum,
                    regReport.ReDiagnoseNum,
                    regReport.ClcDiagnoseNum,
                    regReport.SpecialNum,
                    regReport.HosInsuranceNum,
                    regReport.BdCheckNum
                });
            }

            this.dtDayReport.AcceptChanges();
            this.dvDayReport = this.dtDayReport.DefaultView;
            this.dvDayReport.AllowDelete = true;
            this.dvDayReport.AllowEdit = true;
            this.dvDayReport.AllowNew = true;
            this.neuSpread1_Sheet1.DataSource = this.dvDayReport;
            this.neuSpread1_Sheet1.DataMember = "DayReportRegister";

            this.SetFpFormat();
        }

        /// <summary>
        /// 设置Farpoint显示格式
        /// </summary>
        private void SetFpFormat()
        {
            FarPoint.Win.Spread.CellType.NumberCellType numbCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numbCellType.DecimalPlaces = 0;
            numbCellType.MaximumValue = 9999;
            numbCellType.MinimumValue = 0;

            FarPoint.Win.Spread.CellType.DateTimeCellType dtCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            dtCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dtCellType.UserDefinedFormat = "yyyy-MM-dd";
            dtCellType.ReadOnly = true;

            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;

            #region 设置每列的属性

            this.neuSpread1_Sheet1.Columns[0].CellType = dtCellType;
            this.neuSpread1_Sheet1.Columns[0].BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[0].Label = "日期";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[0].Width = 90f;
            this.neuSpread1_Sheet1.Columns[1].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[1].Visible = false;
            this.neuSpread1_Sheet1.Columns[2].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[2].BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[2].Label = "科室名称";
            this.neuSpread1_Sheet1.Columns[3].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[3].Label = "门诊人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[3].Width = 90f;
            this.neuSpread1_Sheet1.Columns[4].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[4].Label = "急诊人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[4].Width = 90f;
            this.neuSpread1_Sheet1.Columns[5].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[5].Label = "急诊死亡人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[5].Width = 90f;
            this.neuSpread1_Sheet1.Columns[6].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[6].Label = "观察人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[6].Width = 90f;
            this.neuSpread1_Sheet1.Columns[7].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[7].Label = "观察死亡人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[7].Width = 90f;
            this.neuSpread1_Sheet1.Columns[8].CellType = numbCellType;
            this.neuSpread1_Sheet1.Columns[8].Visible = false;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[8].Label = "复诊人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[8].Width = 90f;
            this.neuSpread1_Sheet1.Columns[9].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[9].Label = "其他门诊诊疗人次数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[9].Width = 110f;
            this.neuSpread1_Sheet1.Columns[10].CellType = numbCellType;
            this.neuSpread1_Sheet1.Columns[10].Visible = false;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[10].Label = "专家门诊人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[10].Width = 90f;
            this.neuSpread1_Sheet1.Columns[11].CellType = numbCellType;
            this.neuSpread1_Sheet1.Columns[11].Visible = false;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[11].Label = "医保患者人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[11].Width = 90f;
            this.neuSpread1_Sheet1.Columns[12].CellType = numbCellType;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[12].Label = "体检健康检查人数";
            this.neuSpread1_Sheet1.ColumnHeader.Columns[12].Width = 110f;

            #endregion

        }

        /// <summary>
        /// 判断farpoint数据是否被修改 true - 修改, false - 未修改
        /// </summary>
        /// <returns></returns>
        private bool IsChange()
        {
            this.neuSpread1.StopCellEditing();

            if (neuSpread1_Sheet1.RowCount > 0)
            {
                this.dtDayReport.Rows[neuSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }

            DataTable dt = this.dtDayReport.GetChanges();
            
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 保存数据 1 保存成功, -1 保存失败
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            if (!this.IsChange()) return 1;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.HealthRecord.DayReportRegister regReportMrg = new Neusoft.HISFC.BizLogic.HealthRecord.DayReportRegister();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            ArrayList al = new ArrayList();

            //t.BeginTransaction();
            //regReportMrg.SetTrans(t.Trans);

            if (!this.hasRecord)
            {
                //保存数据
                al = this.GetList(this.dtDayReport);

                if (al == null) return -1;

                if (regReportMrg.InsertOpdDayReport(al) < 0)
                {
                    MessageBox.Show("插入数据出错！", "提示");
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            else
            {
                //更新数据
                DataTable dtChange = this.dtDayReport.GetChanges();

                al = this.GetList(dtChange);

                if (al == null) return -1;

                if (regReportMrg.UpdateOpdDayReport(al) < 0)
                {
                    MessageBox.Show("更新数据出错！", "提示");
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.dtDayReport.AcceptChanges();
            this.SetFpFormat();

            MessageBox.Show("保存成功！", "提示");

            return 1;
        }

        /// <summary>
        /// 得到数据表中的对象
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns>对象集</returns>
        private ArrayList GetList(DataTable dataTable)
        {
            ArrayList arrayList = new ArrayList();

            try
            {
                foreach (DataRow dtRow in dataTable.Rows)
                {
                    Neusoft.HISFC.Models.HealthRecord.DayReportRegister regReport = new Neusoft.HISFC.Models.HealthRecord.DayReportRegister();

                    regReport.DateStat = DateTime.Parse(dtRow["DateStat"].ToString());
                    regReport.Dept.ID = dtRow["DeptCode"].ToString();
                    regReport.Dept.Name = dtRow["DeptName"].ToString();
                    regReport.ClinicNum = int.Parse(dtRow["ClinicNum"].ToString());
                    regReport.EmcNum = int.Parse(dtRow["EmcNum"].ToString());
                    regReport.EmcDeadNum = int.Parse(dtRow["EmcDeadNum"].ToString());
                    regReport.ObserveNum = int.Parse(dtRow["ObserveNum"].ToString());
                    regReport.ObserveDeadNum = int.Parse(dtRow["ObserveDeadNum"].ToString());
                    regReport.ReDiagnoseNum = int.Parse(dtRow["ReDiagnoseNum"].ToString());
                    regReport.ClcDiagnoseNum = int.Parse(dtRow["ClcDiagnoseNum"].ToString());
                    regReport.SpecialNum = int.Parse(dtRow["SpecialNum"].ToString());
                    regReport.HosInsuranceNum = int.Parse(dtRow["HosInsuranceNum"].ToString());
                    regReport.BdCheckNum = int.Parse(dtRow["BdCheckNum"].ToString());

                    regReport.Oper.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID;

                    arrayList.Add(regReport);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("生成实体集合出错!" + e.Message, "提示");
                return null;
            }

            return arrayList;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDayReportRegister_Load(object sender, EventArgs e)
        {
            //设置数据列
            this.InitDataSet();
            this.InitFrp(this.dtTime);
        }

        /// <summary>
        /// 日期控件value改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStatDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.IsChange())
            {
                DialogResult dr = MessageBox.Show("数据已经修改,是否保存?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (dr == DialogResult.Yes)
                {
                    if (this.Save() < 0)
                    {
                        this.txtStatDate.Value = this.dtTime;
                        return;
                    }
                }
                else if (dr == DialogResult.Cancel) return;
            }

            this.dtTime = this.txtStatDate.Value.Date;
            this.InitFrp(this.dtTime);
        }

        /// <summary>
        /// 退出判断数据是否改变 如果改变提示保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Exit(object sender, object neuObject)
        {
            if (IsChange())
            {
                DialogResult dr = MessageBox.Show("数据已经修改,是否保存?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (dr == DialogResult.Yes)
                {
                    if (this.Save() < 0) return -1;
                }
                else if (dr == DialogResult.Cancel)
                {
                    return -1;
                }
            }

            return base.Exit(sender, neuObject);
        }

        #endregion
    }
}
