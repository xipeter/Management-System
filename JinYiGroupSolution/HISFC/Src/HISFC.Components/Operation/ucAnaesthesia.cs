using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 麻醉安排控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-11]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucAnaesthesia : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucAnaesthesia()
        {
            InitializeComponent();
        }

        #region 字段
        private ArrayList alApplys;

        //{4F4C0095-4E5A-4e48-AD22-D38A2894A31F}
        /// <summary>
        /// 科室分类表维护管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager deptStatMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
        #endregion

        #region 方法

        /// <summary>
        /// 刷新手术申请列表
        /// </summary>
        /// <returns></returns>
        public int RefreshApplys()
        {
            this.ucAnaesthesiaSpread1.Reset();

            //开始时间
            DateTime beginTime = this.dateTimePicker1.Value.Date;
            //结束时间
            DateTime endTime = this.dateTimePicker1.Value.Date.AddDays(1);

            //neusoft.neNeusoft.HISFC.Components.Interface.Classes.Function.ShowWaitForm("正在载入数据,请稍后...");
            Application.DoEvents();
            try
            {
                this.ucAnaesthesiaSpread1.Reset();
                alApplys = Environment.OperationManager.GetOpsAppList(beginTime, endTime);
                if (alApplys != null)
                {

                    this.ucAnaesthesiaSpread1.QueryTime =string.Format("安排时间：{0}至{1}", beginTime.ToString(), endTime.ToString());

                    foreach (OperationAppllication apply in alApplys)
                    {
                        //{25E1FC1A-66A0-4e40-9236-9CC6710A5704} 手术室麻醉室对

                        #region 载入手术室麻醉室关系，进行过滤；只能过滤出本科室上面对应的手术室的申请
                        ArrayList alAnesDepts = this.deptStatMgr.LoadChildren("10", apply.ExeDept.ID, 1);
                        if (alAnesDepts == null)
                        {
                            MessageBox.Show("查找科室对应关系时出错：" + this.deptStatMgr.Err);
                            return -1;
                        }
                        if (alAnesDepts.Count == 0)
                        {
                            Neusoft.HISFC.BizProcess.Integrate.Manager depMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                            apply.ExeDept.Name = depMgr.GetDepartment(apply.ExeDept.ID).Name;
                            MessageBox.Show("手术科室：“" + apply.ExeDept.Name + "”找不到与麻醉室的对应关系，请在科室结构树中维护！");
                            return -1;
                        }
                        foreach (Neusoft.HISFC.Models.Base.DepartmentStat deptStat in alAnesDepts)
                        {
                            #region {2F58330D-0BEC-4a68-AE06-6C2868CFE545}
                            //{E4C275E8-6E12-4a42-A60A-0EB9A8CB52BD}
                            if (deptStat.DeptCode == (this.dataManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID)
                            {
                                this.ucAnaesthesiaSpread1.AddOperationApplication(apply);
                                break;
                            }
                            //if (deptStat.PardepCode == (this.deptStatMgr.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID)
                            //{
                            //    this.ucAnaesthesiaSpread1.AddOperationApplication(apply);
                            //    break;
                            //}
                            #endregion
                        }
                        #endregion
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("生成手术申请信息出错!" + e.Message, "提示");
                return -1;
            }

            //neusoft.neNeusoft.HISFC.Components.Interface.Classes.Function.HideWaitForm();
            //if (fpSpread1_Sheet1.RowCount > 0)
            //{
            //    FarPoint.Win.Spread.LeaveCellEventArgs e = new FarPoint.Win.Spread.LeaveCellEventArgs
            //        (new FarPoint.Win.Spread.SpreadView(fpSpread1), 0, 0, 0, (int)Cols.anaeType);
            //    fpSpread1_LeaveCell(fpSpread1, e);
            //fpSpread1.Focus();
            //fpSpread1_Sheet1.SetActiveCell(0, (int)Cols.anaeType, true);
            //}

            return 0;
        }
        #endregion

        #region 事件

        protected override int OnQuery(object sender, object neuObject)
        {
            this.RefreshApplys();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.ucAnaesthesiaSpread1.Save();
            return base.OnSave(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            //this.ucAnaesthesiaSpread1.Date = this.dateTimePicker1.Value;
            //this.ucAnaesthesiaSpread1.Print();
            //return base.OnPrint(sender, neuObject);

            return this.ucAnaesthesiaSpread1.Print();
        }

        public override int Export(object sender, object neuObject)
        {
            return this.ucAnaesthesiaSpread1.Export();
        }
        #endregion

        private void ucAnaesthesiaSpread1_applictionSelected(object sender, OperationAppllication e)
        {
            if (e != null)
            {
                this.ucArrangementInfo1.OperationApplication = e;
            }
        }
    }
}
