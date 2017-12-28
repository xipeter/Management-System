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
    public partial class ucCalendarInput : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCalendarInput(ref FarPoint.Win.Spread.SheetView view)
        {
            this.view = view;
            
            InitializeComponent();
        }
        #region 变量
        private Neusoft.HISFC.Models.Base.Calendar calendar = new Neusoft.HISFC.Models.Base.Calendar();

        private FarPoint.Win.Spread.SheetView view ;
        
        private Neusoft.HISFC.BizProcess.Factory.ManagerManagement managerManager = new Neusoft.HISFC.BizProcess.Factory.ManagerManagement();
        #endregion 
        #region 初始化
        private void ucCalendarInput_Load(object sender, EventArgs e)
        {
            InitialCombox();

            this.comOperName.Text = Neusoft.FrameWork.Management.Connection.Operator.Name;

            this.comOperName.Tag = Neusoft.FrameWork.Management.Connection.Operator.ID;
        }
        private void InitialCombox()
        {
            ArrayList personLis = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.QueryEmployeeAll();

            this.comOperName.AddItems(personLis);
        }
        #endregion 
        #region 事件
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValueValidated())
            {
                if (this.Save() == 1)
                {
                    if (this.neuCheckBox1.Checked)
                    {
                        this.ClearUp();
                    }

                    else if (!this.neuCheckBox1.Checked)
                    {
                        this.FindForm().Close();
                    }

                }
            }
            
        }

        #endregion 
        #region 方法
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            calendar = this.CovertCalendarFromPanel();

            try
            {
                Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();

                int returnValue = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.AddCalender(calendar);

                if (returnValue == -1)
                {
                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();

                    return -1;
                }
                else
                {
                    Neusoft.HISFC.BizProcess.Factory.Function.Commit();

                    MessageBox.Show("保存成功！");

                    this.AddNewRow(calendar);
                    
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"/"+ex.StackTrace);

                return -1;
            }
               
            
        }
       /// <summary>
       /// 数据校验
       /// </summary>
       /// <returns></returns>
        private bool ValueValidated()
        {
           
            if (this.txtCalendarName.Text.Trim() == "")
            {
                MessageBox.Show("请输入日程名称！", "提示");

                this.txtCalendarName.Focus();

                return false;
            }
            else
            {
                return true;
            }
           
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearUp()
        {
            this.txtCalendarName.Text = "";
            this.txtParam.Text = "";
            this.comType.Text = "";
            
        }
        /// <summary>
        /// 把控件上的数据传到实体中
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Calendar CovertCalendarFromPanel()
        {
            calendar.CalendarDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.calendarDate.Text.Trim());

            calendar.Name = this.txtCalendarName.Text.Trim();

            calendar.ParamXML = this.txtParam.Text.Trim();

            calendar.Oper.ID = this.comOperName.Tag.ToString();

            calendar.Oper.Name = this.comOperName.Text.Trim();

            calendar.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.OperDate.Text.Trim());

            calendar.Type = this.comType.Text.Trim();

            return calendar;
        }
        /// <summary>
        /// tab顺序
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// 在fp中增加一行
        /// </summary>
        /// <param name="calendar"></param>
        private void AddNewRow(Neusoft.HISFC.Models.Base.Calendar calendar)
        {
            this.view.Rows.Add(this.view.Rows.Count, 1);
            this.view.SetValue(this.view.Rows.Count - 1, 0, calendar.CalendarDate);
            this.view.SetValue(this.view.Rows.Count - 1, 1, calendar.Name);
            this.view.SetValue(this.view.Rows.Count - 1, 2, calendar.Type);
            this.view.SetValue(this.view.Rows.Count - 1, 3, calendar.Oper.Name);
            this.view.SetValue(this.view.Rows.Count - 1, 4, calendar.Oper.OperTime);
            
        }
        #endregion 

       
       


        

        
        
       
       
    }
}
