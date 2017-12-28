using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class ucCalendar : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCalendar()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 定义工具栏        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        private Neusoft.HISFC.BizProcess.Factory.ManagerManagement managerManager = new Neusoft.HISFC.BizProcess.Factory.ManagerManagement();

        #endregion
        #region 初始化
        public int InitCalendarData()
        {
            ArrayList calendarLis =
                Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryCalendar();

            if (calendarLis == null) return 0;

            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }


            foreach (Neusoft.HISFC.Models.Base.Calendar calendar in calendarLis)
            {

                this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);

                int row = this.neuSpread1_Sheet1.RowCount - 1;

                this.neuSpread1_Sheet1.SetValue(row, 0, calendar.CalendarDate);
                this.neuSpread1_Sheet1.SetValue(row, 1, calendar.Name);
                this.neuSpread1_Sheet1.SetValue(row, 2, calendar.Type);
                string name = managerManager.GetPersonByID(calendar.Oper.ID).ToString();
                this.neuSpread1_Sheet1.SetValue(row, 3, name);
                this.neuSpread1_Sheet1.SetValue(row, 4, calendar.Oper.OperTime);
                
            }

            return 1;
        }
        /// <summary>
        /// 按时间段查询
        /// </summary>
        /// <returns></returns>
        private int InitCalendarData(DateTime dtBegin, DateTime dtEnd)
        {
            ArrayList calendarLis =
                Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryCalendar(dtBegin, dtEnd);

            if (calendarLis == null) return 0;

            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }


            foreach (Neusoft.HISFC.Models.Base.Calendar calendar in calendarLis)
            {

                this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);

                int row = this.neuSpread1_Sheet1.RowCount - 1;

                this.neuSpread1_Sheet1.SetValue(row, 0, calendar.CalendarDate);
                this.neuSpread1_Sheet1.SetValue(row, 1, calendar.Name);
                this.neuSpread1_Sheet1.SetValue(row, 2, calendar.Type);
                Neusoft.HISFC.Models.Base.Employee oper = managerManager.GetPersonByID(calendar.Oper.ID);
                this.neuSpread1_Sheet1.SetValue(row, 3, oper.Name);
                this.neuSpread1_Sheet1.SetValue(row, 4, calendar.Oper.OperTime);
                

            }

            return 1;
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCalendar_Load(object sender, EventArgs e)
        {
            InitCalendarData();
        }
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "增加", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            return toolBarService ;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Query(object sender, object neuObject)
        {
            QueryCalendar();
            return base.Query(sender, neuObject);
        }
        #endregion 

       
        
        
        #region 事件
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加")
            {
                AddNewCalendar();
            }
          
        }

        //private void beginDate_ValueChanged(object sender, EventArgs e)
        //{
        //    this.endDate.Text = this.beginDate.Text.Trim();
        //}


        #endregion 

        #region 方法
       /// <summary>
       /// 增加日程信息
       /// </summary>
        public void AddNewCalendar()
        {
            try{
            ucCalendarInput calendarInput = new ucCalendarInput(ref this.neuSpread1_Sheet1);
            
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "增加";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(calendarInput);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "/" + ex.Message);
            }
        }
        /// <summary>
        /// 按时间段查询
        /// </summary>
        public void QueryCalendar()
        {
            DateTime dtBegin = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.beginDate.Text.Trim());

            DateTime dtEnd = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.endDate.Text.Trim());

            if (dtBegin.CompareTo(dtEnd)> 0)
            {
                MessageBox.Show("开始时间应小于结束时间！","提示");
            }
            else
            {
                this.InitCalendarData(dtBegin, dtEnd);
            }

            
         }

       
        #endregion 

        
       

    }
}
