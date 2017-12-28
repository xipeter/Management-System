using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpr
{
    public partial class ucFinIprOutFreecost : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIprOutFreecost ()
        {
            InitializeComponent();
        }

        
        //private bool isAllDept = true;

        /// <summary>
        /// 住院或门诊  
        /// </summary>
        //public bool IsAllDept
        //{
        //    get
        //    {
        //        return this.isAllDept;
        //    }
        //    set
        //    {
        //        this.isAllDept = value;
        //    }
        //}

        
               

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
                //如果有两个以上DataWindow控件时需要打印输入时，根据焦点判断打印哪个DataWindow控件
                
                if (this.dwMain.Focused)
                {
                    this.dwMain.Print();
                }
                else if(this.dwDetail.Focused) //其它DataWindow控件打印，与此类推
                {
                    this.dwDetail.Print();         
                }
                     return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错", "提示");
                return -1;
            }
 
        }

        //protected override int OnQuery(object sender, object neuObject)
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            //string  deptCode;

            //if (this.IsAllDept)
            //{
            //   deptCode = "all" ;
                
            //}
            //else
            //{
            //    deptCode = this.employee.Dept.ID;
            //}
            
             this.dwMain.Modify("time.text='出院时间：" + this.beginTime.ToString() + "至" + this.endTime.ToString() + "'");
             this.dwMain.RowFocusChanged -= this.dwMain_RowFocusChanged;
             int num = this.dwMain.Retrieve(this.beginTime, this.endTime);
             this.dwMain.RowFocusChanged += this.dwMain_RowFocusChanged;
             if (dwMain.RowCount > 0)
             {
                 RetrieveDetail(1);

             }
             else
             {
                 dwDetail.Reset();
             }
             return num;
            
        }

        private void dwMain_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            if (e.RowNumber == 0)
            {
                this.dwDetail.Reset();
                return;
            }
             RetrieveDetail(e.RowNumber);
        }

        private void RetrieveDetail(int currRow)
        {
           

                //科室编码
                string deptNo = string.Empty;
                //开始时间
                DateTime beginDate;
                //结束时间
                DateTime endDate;

                try
                {
                    deptNo = this.dwMain.GetItemString(currRow, "aaa"); //科室编码
                    //beginDate = this.dwMain.GetItemDateTime(e.RowNumber, "begin_date");
                    //endDate = this.dwMain.GetItemDateTime(e.RowNumber, "end_date");
                    this.dwDetail.Modify("time.text='出院时间：" + this.beginTime.ToString() + "至" + this.endTime.ToString() + "'");
                    this.dwDetail.Retrieve(deptNo, beginTime, endTime);
                   
                }
                finally
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

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
                else
                {
                    return 1;
                }
                
                //根据焦点判断导出哪个DataWindow
                if (this.dwMain.Focused)
                {
                    this.dwMain.SaveAs(fileName, Sybase.DataWindow.FileSaveAsType.Excel);
                }
                else if(this.dwDetail.Focused) //多个以此类推
                {
                    this.dwDetail.SaveAs(fileName, Sybase.DataWindow.FileSaveAsType.Excel);
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出出错","提示");
                return -1;
            }
        }

    }
}

