using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Inject
{
    /// <summary>
    /// ucCureReprint<br></br>
    /// <Font color='#FF1111'>[功能描述:{EB016FFE-0980-479c-879E-225462ECA6D0} 瓶签补打]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-29]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucCureReprint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数
        public ucCureReprint()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// 门诊注射业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Inject injectManager = new Neusoft.HISFC.BizLogic.Nurse.Inject();

        /// <summary>
        /// 需要补打的数据
        /// </summary>
        private ArrayList alData = null;

        #endregion

        #region 公开方法

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.InitDataTable();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化数据表
        /// </summary>
        private void InitDataTable()
        {
            this.dt = new DataTable();
            this.dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("患者姓名",typeof(string)),
                new DataColumn("开单医生",typeof(string)),
                new DataColumn("医嘱",typeof(string)),
                new DataColumn("登记时间",typeof(DateTime))
            });
            this.neuSpread1_Sheet1.DataSource = this.dt;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryData()
        {
            string printNo = this.txtPrintNo.Text.Trim();
            if (string.IsNullOrEmpty(printNo))
            {
                return;
            }
            this.dt.Clear();
            alData = this.injectManager.QueryRePrintInjectRecord(printNo);
            if (alData == null)
            {
                MessageBox.Show("查找需要补打的数据出错：" + this.injectManager.Err);
                return;
            }
            if (alData.Count == 0)
            {
                MessageBox.Show("没有找到数据");
                return;
            }
            foreach (Neusoft.HISFC.Models.Nurse.Inject inject in alData)
            {
                this.AddInjectToTable(inject);
            }
        }

        /// <summary>
        /// 将数据填入数据表
        /// </summary>
        /// <param name="inject"></param>
        private void AddInjectToTable(Neusoft.HISFC.Models.Nurse.Inject inject)
        {
            DataRow dr = this.dt.NewRow();
            this.dt.Rows.Add(dr);
            dr["患者姓名"] = inject.Patient.Name;
            dr["开单医生"] = inject.Item.Order.Doctor.Name;
            dr["医嘱"] = inject.Item.Name;
            dr["登记时间"] = inject.Booker.OperTime;
        }

        /// <summary>
        /// 补打瓶签
        /// </summary>
        private void RePrintCure()
        {
            if (this.alData == null || this.alData.Count == 0)
            {
                MessageBox.Show("没有要打印的数据");
                return;
            }
            Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint curePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint)) as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint;
            if (curePrint == null)
            {
                curePrint = new Nurse.Print.ucPrintCure() as Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectCurePrint;
            }
            curePrint.Init(this.alData);
        }
        #endregion

        #region 事件
        private void txtPrintNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.QueryData();
            }
        }

        private void btnCureRePrint_Click(object sender, EventArgs e)
        {
            this.RePrintCure();
        }

        #endregion

    }
}
