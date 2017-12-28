using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.OutpatientFee.Query
{
    public partial class ucRegLED : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.Registration.IShowLED
    {
        public ucRegLED()
        {
            InitializeComponent();
        }
        #region 定义
        private Neusoft.HISFC.BizLogic.Registration.Schema schemaManager = new Neusoft.HISFC.BizLogic.Registration.Schema();
        #endregion

        #region 方法
        /// <summary>
        /// 医生出诊情况
        /// </summary>
        /// <returns></returns>
        public string Query()
        {
            DateTime currentDate = schemaManager.GetDateTimeFromSysDateTime();
            string strLED = string.Empty;
            DataSet ds = new DataSet();
            ds = this.schemaManager.QueryDoctForLED(currentDate.Date, currentDate);
            if (ds == null)
            {
                return null; 
            }

            this.neuSpread1_Sheet1.DataSource = ds;
            this.SetFPFormat();
            return strLED;
        }
        /// <summary>
        /// 设置farpoint显示格式
        /// </summary>
        /// <returns></returns>
        public int SetFPFormat()
        {
            this.neuSpread1_Sheet1.Columns[0].Visible = false;

            this.neuSpread1_Sheet1.Columns[1].Label = "科室名称";
            this.neuSpread1_Sheet1.Columns[1].Width = 100;
            this.neuSpread1_Sheet1.Columns[2].Visible = false;

            this.neuSpread1_Sheet1.Columns[3].Label = "科室名称";
            this.neuSpread1_Sheet1.Columns[3].Width = 100;
            

            this.neuSpread1_Sheet1.Columns[4].Label = "午别";
            this.neuSpread1_Sheet1.Columns[4].Width = 100;

            this.neuSpread1_Sheet1.Columns[5].Label = "开始时间";
            this.neuSpread1_Sheet1.Columns[5].Width = 100;

            this.neuSpread1_Sheet1.Columns[6].Label = "结束时间";
            this.neuSpread1_Sheet1.Columns[6].Width = 100;
            this.neuSpread1_Sheet1.Columns[7].Label = "挂号限额";
            this.neuSpread1_Sheet1.Columns[7].Width = 100;
            this.neuSpread1_Sheet1.Columns[8].Label = "已挂人数";
            this.neuSpread1_Sheet1.Columns[8].Width = 100;
            this.neuSpread1_Sheet1.Columns[9].Label = "预约号数";
            this.neuSpread1_Sheet1.Columns[9].Width = 100;
            this.neuSpread1_Sheet1.Columns[10].Label = "预约已挂";
            this.neuSpread1_Sheet1.Columns[10].Width = 100;
            this.neuSpread1_Sheet1.Columns[11].Label = "特诊挂号限额";
            this.neuSpread1_Sheet1.Columns[11].Width = 100;
            this.neuSpread1_Sheet1.Columns[12].Label = "特诊已挂人数";
            this.neuSpread1_Sheet1.Columns[12].Width = 100;

            //this.neuSpread1_Sheet1.Columns[11].Visible = false;
             
            //this.neuSpread1_Sheet1.Columns[12].Visible = false;
             
            this.neuSpread1_Sheet1.Columns[13].Visible = false;

            return 1;
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.Query();
            //this.SetFPFormat();
        }
        /// <summary>
        /// 调用LED 接口 组成显示串给LED
        /// </summary>
        public int CreateString()
        {
            return 1;
        }

        public void SetFresh (bool Valid,string strNum )
        {
            this.timer1.Enabled = Valid;
            timer1.Interval = 1000 * Neusoft.FrameWork.Function.NConvert.ToInt32(strNum);

        }
        
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //SetFresh(true,this.neuNumericTextBox1.Text);
            
            this.Query();
            this.OK_Click(null,null);
            this.FindForm().Text = "医生出诊情况(LED显示屏使用)";
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0,this.NpPrint );
             
            return base.OnPrint(sender, neuObject);
        }
        //导出
        public override int Export(object sender, object neuObject)
        {

            SaveFileDialog op = new SaveFileDialog();

            op.Title = "请选择保存的路径和名称";
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.DefaultExt = "*.xls";
            op.Filter = "(*.xls)|*.xls";

            DialogResult result = op.ShowDialog();

            if (result == DialogResult.Cancel || op.FileName == string.Empty)
            {
                return -1;
            }

            string filePath = op.FileName;

            bool returnValue = this.neuSpread1.SaveExcel(filePath, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
            return base.Export(sender, neuObject);
        }
        #endregion
        #region 事件
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRegLED_Load(object sender, EventArgs e)
        {
            this.Init();
        }
       
        private void OK_Click(object sender, EventArgs e)
        {
            this.neuNumericTextBox1.Enabled = false;
            this.SetFresh(true, this.neuNumericTextBox1.Text);

        }

        private void ReSet_Click(object sender, EventArgs e)
        {
            this.neuNumericTextBox1.Enabled = true;
            this.SetFresh(false, this.neuNumericTextBox1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Query();
            
            
        }
        #endregion
    }
   
   
}
