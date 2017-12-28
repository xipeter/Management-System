using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.Logistics.Pharmacy
{
    public partial class ucPhaCheckStatic : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPhaCheckStatic()
        {
            InitializeComponent();
        }

        Neusoft.FrameWork.Management.DataBaseManger dbMgr = new Neusoft.FrameWork.Management.DataBaseManger(); 
        ArrayList alDept = new ArrayList();
        string deptCode = string.Empty;
        string deptName = string.Empty;
        string strCheckCode = string.Empty;
       

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager intergrateMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

            obj.ID = "ALL";
            obj.Name = "全部";
            alDept.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "0";
            obj.Name = "全部部门";
            alDept.Add(obj);

            ArrayList dept = new ArrayList();
            dept = intergrateMgr.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
            alDept.AddRange(dept);

            dept = intergrateMgr.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);
            alDept.AddRange(dept);

            this.neuDept.AddItems(alDept);
            this.neuDept.SelectedIndex = 0;
            deptCode = this.neuDept.SelectedItem.ID;
            deptName = this.neuDept.SelectedItem.Name;

            //{3182F277-6779-4392-914D-C65356F57E19}
            DateTime dt=dbMgr.GetDateTimeFromSysDateTime();
            this.dtpFrom.Value = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            this.dtpTo.Value = this.dtpFrom.Value.AddDays(1);

            base.OnLoad(e);
        }
        #endregion 

        #region 汇总查询

        protected override int OnQuery(object sender, object neuObject)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在查询，请稍候..."));
                Application.DoEvents();


                // 查询参数

                DataSet ds = new DataSet();
                int rowCount = 0;
                decimal sumNum3 = 0;
                decimal sumNum2 = 0;
                decimal sumNum1 = 0;

                List<string> strPamars = new List<string>();

                strPamars.Add(dtpFrom.Value.ToString());
                strPamars.Add(dtpTo.Value.ToString());
                strPamars.Add(deptCode);
                strPamars.ToArray();
                string[] pamars = strPamars.ToArray();

                if (QueryDataBySql("WinForms.Report.Logistics.Pharmacy.Checkstatic", ref ds, pamars) == -1)
                {
                    return -1;
                }
                this.neuSpread1_Sheet1.DataSource = ds.Tables[0].DefaultView;

                this.lb1.Text = "查询时间：" + dtpFrom.Value.ToString() + "至" + dtpTo.Value.ToString();
                this.lb2.Text = "查询科室：" + deptName;
                //this.neuSpread2_Sheet1.Reset();
                //this.neuSpread3_Sheet1.Reset();
                this.neuSpread2_Sheet1.DataSource = null;
                this.neuSpread3_Sheet1.DataSource = null;
                //合计
                rowCount = this.neuSpread1_Sheet1.RowCount;
                for (int i = 0;i < rowCount; i++ )
                {
                    sumNum3 = sumNum3 + NConvert.ToDecimal( (this.neuSpread1_Sheet1.Cells[i,10].Text));
                    sumNum2 = sumNum2 + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i,9].Text);
                    sumNum1 = sumNum1 + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 8].Text);
                }
                

                this.neuSpread1_Sheet1.Rows.Add(rowCount,1);
               // rowCount = this.neuSpread1_Sheet1.RowCount;
                this.neuSpread1_Sheet1.Cells[rowCount, 0].Text = "合计：";
                this.neuSpread1_Sheet1.Cells[rowCount,10].Text = sumNum3.ToString();
                this.neuSpread1_Sheet1.Cells[rowCount,9].Text = sumNum2.ToString();
                this.neuSpread1_Sheet1.Cells[rowCount,8].Text = sumNum1.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              

            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                
            }
            return 1;
            // base.OnQuery(sender, neuObject);
        }
        //private void CheckStaticQry()
        //{
        //    try
        //    {
        //        Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在查询，请稍候..."));
        //        Application.DoEvents();


        //        // 查询参数

        //        DataSet ds = new DataSet();

        //        List<string> strPamars = new List<string>();

        //        strPamars.Add(dtpFrom.Value.ToString());
        //        strPamars.Add(dtpTo.Value.ToString());
        //        strPamars.Add(deptCode);
        //        strPamars.ToArray();
        //        string[] pamars = strPamars.ToArray();

        //        if (QueryDataBySql("WinForms.Report.Logistics.Pharmacy.Checkstatic", ref ds, pamars) == -1)
        //        {
        //            return;
        //        }
        //        this.neuSpread1_Sheet1.DataSource = ds;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {
        //        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        //    }

        //}

        #endregion 

        #region  查询数据

        private int QueryDataBySql(string sqlId,ref DataSet ds,params string[] p)
        {
            string sql = string.Empty;
            if (dbMgr.Sql.GetSql(sqlId, ref sql) == -1)
            {
                return -1;
            }
            try
            {
                sql = string.Format(sql, p);
            }
            catch(Exception ex)
            {
                dbMgr.Err = ex.Message;
                return -1;
            }

            if (this.dbMgr.Sql.ExecQuery(sql, ref ds) == -1)
            {
                return -1;
            }

            return 1;
        }

       

        #endregion 


        #region 取科室编码
        private void neuDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptCode = this.neuDept.SelectedItem.ID;
            deptName = this.neuDept.SelectedItem.Name;
          
        }
        
        #endregion 

        #region 按盘点单号过滤

        private void ntbCheckCode_TextChanged(object sender, EventArgs e)
        {
            strCheckCode = this.ntbCheckCode.Text;
            (this.neuSpread1_Sheet1.DataSource as DataView).RowFilter = "盘点单号 like '%" + strCheckCode + "'";
        }
        #endregion




        #region 双击显示明细
        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在查询，请稍候..."));
                Application.DoEvents();

                string strCheckCode = string.Empty;
                string strDeptID = string.Empty;
                string strCheckDate = string.Empty;

                decimal sumNum4 = 0;
                decimal sumNum3 = 0;
                decimal sumNum2 = 0;
                decimal sumNum1 = 0;
                int rowCount = 0;

                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();

                strCheckCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
                strDeptID = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Text;
                string[] param = { strCheckCode,strDeptID };
               
                if (QueryDataBySql("WinForms.Report.Logistics.Pharmacy.Checkdetail1", ref ds1, param) == -1)
                {
                    return;
                }
                this.neuSpread2_Sheet1.DataSource = ds1.Tables[0].DefaultView;

                if (QueryDataBySql("WinForms.Report.Logistics.Pharmacy.Checkdetail2", ref ds2, param) == -1)
                {
                    return;
                }
                this.neuSpread3_Sheet1.DataSource = ds2.Tables[0].DefaultView;
                //label赋值
                strCheckDate = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 5].Text;
                this.lb21.Text = "科别：" + deptName;
                this.lb22.Text = "封帐时间：" + strCheckDate;
                this.lb23.Text = "封帐人：" + this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 4].Text;
                this.lb24.Text = "结存人：" + this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 6].Text;
                this.lb26.Text = "盘点单号：" + strCheckCode;

                this.lb31.Text = "科别：" + deptName;
                this.lb32.Text = "封帐时间：" + strCheckDate;
                this.lb33.Text = "封帐人：" + this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 4].Text;
                this.lb34.Text = "结存人：" + this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 6].Text;
                this.lb36.Text = "盘点单号：" + strCheckCode;

                //合计
                rowCount = this.neuSpread2_Sheet1.RowCount;

                for (int i = 0; i < rowCount; i++)
                {

                    sumNum1 = sumNum1 + NConvert.ToDecimal(this.neuSpread2_Sheet1.Cells[i, 12].Text);


                    sumNum2 = sumNum2 + NConvert.ToDecimal(this.neuSpread2_Sheet1.Cells[i, 13].Text);
                }
                this.neuSpread2_Sheet1.Rows.Add(rowCount, 1);
                //rowCount = this.neuSpread2_Sheet1.RowCount;
                this.neuSpread2_Sheet1.Cells[rowCount, 0].Text = "合计：";

                this.neuSpread2_Sheet1.Cells[rowCount, 12].Text = sumNum1.ToString();
                this.neuSpread2_Sheet1.Cells[rowCount, 13].Text = sumNum2.ToString();

                rowCount = this.neuSpread3_Sheet1.RowCount;
                for (int i = 0; i < rowCount; i++)
                {

                    sumNum3 = sumNum3 + NConvert.ToDecimal(this.neuSpread3_Sheet1.Cells[i, 9].Text);

                    sumNum4 = sumNum4 + NConvert.ToDecimal(this.neuSpread3_Sheet1.Cells[i, 10].Text);
                }
                this.neuSpread3_Sheet1.Rows.Add(rowCount, 1);
                //rowCount = this.neuSpread3_Sheet1.RowCount;
                this.neuSpread3_Sheet1.Cells[rowCount, 0].Text = "合计：";
                this.neuSpread3_Sheet1.Cells[rowCount, 9].Text = sumNum3.ToString();
                this.neuSpread3_Sheet1.Cells[rowCount, 10].Text = sumNum4.ToString();

                this.neuTabControl1.SelectedIndex = 1;
                

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
        #endregion 

       
        #region 打印

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Line;
            print.PageLabel = neuLabel8;

            if (this.neuTabControl1.SelectedIndex == 0)
            {             
                print.PrintPage (30, 10, this.neuPanel4);
            }
            if (this.neuTabControl1.SelectedIndex == 1)
            {
                print.PrintPage(30, 10, this.neuPanel6);
            }
            if (this.neuTabControl1.SelectedIndex == 2)
            {
                print.PrintPage(30, 10, this.neuPanel8);
            }

            return base.OnPrint(sender, neuObject);
        }
        #endregion


    }
}
