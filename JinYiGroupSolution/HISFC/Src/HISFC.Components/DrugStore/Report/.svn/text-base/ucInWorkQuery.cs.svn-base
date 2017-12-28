using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Report
{
    /// <summary>
    /// [功能描述: 住院工作量查询]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-03]<br></br>
    /// <修改记录 
    ///		 待实现 权限系统完善
    ///  />
    /// </summary>
    public partial class ucInWorkQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInWorkQuery()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 药品管理业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        #endregion

        #region 属性

        /// <summary>
        /// 查询起始时间
        /// </summary>
        public DateTime BeginTime
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text);
            }
        }

        /// <summary>
        /// 查询终止时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text);
            }
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            //增加工具栏
            //this.toolBarService.AddToolButton("导出", "导出当前工作量信息", 0, true, false, null);
            return this.toolBarService;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            this.Export();

            return 1;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "导出")
            {
                this.Export();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        /// <summary>
        /// 数据查询
        /// </summary>
        private void Query()
        {
            if (this.cmbDept.SelectedValue == null || this.cmbDept.SelectedValue.ToString() == "")
            {
                MessageBox.Show(Language.Msg("请选择查询药房"));
                return;
            }

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询，请稍候...");
                Application.DoEvents();

                //查询统计
                DataSet ds = new DataSet();
                if (this.itemManager.ExecQuery("Pharmarcy.Report.Inpatient.Query", ref ds, this.cmbDept.SelectedValue.ToString(), this.BeginTime.ToString(), this.EndTime.ToString()) == -1)
                {
                    Function.ShowMsg("数据查询失败，请与管理员联系！" + this.itemManager.Err);
                    return;
                }

                //显示统计结果
                this.neuSpread1_Sheet1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 明细查询
        /// </summary>
        /// <param name="operInfo">操作员</param>
        /// <param name="class3MeaningCode">类型编码</param>
        private void QueryDetail(Neusoft.FrameWork.Models.NeuObject operInfo,string class3MeaningCode)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在查询，请稍候..."));
                Application.DoEvents();

                DataSet ds = new DataSet();
                if (this.itemManager.ExecQuery("Pharmarcy.Report.Inpatient.DetailQuery", ref ds, this.cmbDept.SelectedValue.ToString(),operInfo.ID, this.BeginTime.ToString(), this.EndTime.ToString(),class3MeaningCode) == -1)
                {
                    Function.ShowMsg("数据查询失败，请与管理员联系！" + this.itemManager.Err);
                    return;
                }

                if (ds.Tables.Count > 0)
                {
                    //当记录有效时 此时有效日期存储医嘱用药日期 屏蔽此时的日期显示
                    if (ds.Tables[0].Columns.Contains("取消日期") && ds.Tables[0].Columns.Contains("有效标记") )
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["有效标记"].ToString() == "有效")
                            {
                                dr["取消日期"] = "";
                            }
                        }
                    }
                }

                this.neuSpread1_Sheet2.DataSource = ds;

                this.neuSpread1_Sheet2.SheetName = operInfo.Name + " 明细摆药信息";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void Export()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Application.DoEvents();

                //默认时间段				
                System.DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

                this.dtBegin.Value = new DateTime(sysTime.Year, sysTime.Month, sysTime.Day, 0, 0, 0);
                this.dtEnd.Value = new DateTime(sysTime.Year, sysTime.Month, sysTime.Day, 23, 59, 59);

                #region 加载药房列表

                //药房选项
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList al = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                if (al == null)
                {
                    Function.ShowMsg("加载药房列表失败\n" + this.itemManager.Err);
                    return;
                }

                this.cmbDept.DataSource = al;
                this.cmbDept.DisplayMember = "Name";
                this.cmbDept.ValueMember = "ID";

                #endregion

                this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
                this.neuSpread1_Sheet2.DefaultStyle.Locked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

            base.OnLoad(e);
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (this.neuSpread1_Sheet1.RowCount == 0)
                {
                    return;
                }

                if (!this.neuSpread1.Sheets.Contains(this.neuSpread1_Sheet2))
                    this.neuSpread1.Sheets.Add(this.neuSpread1_Sheet2);

                if (this.neuSpread1.ActiveSheet == this.neuSpread1_Sheet1)
                {
                    string operCode = this.neuSpread1_Sheet1.Cells[e.Row, 0].Text;
                    string operName = this.neuSpread1_Sheet1.Cells[e.Row, 1].Text;
                    string class3Meaning = this.neuSpread1_Sheet1.Cells[e.Row, 2].Text == "退药"?"Z2":"Z1";


                    Neusoft.FrameWork.Models.NeuObject operInfo = new Neusoft.FrameWork.Models.NeuObject();
                    operInfo.ID = operCode;
                    operInfo.Name = operName;

                    this.QueryDetail(operInfo,class3Meaning);
                }

                this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
