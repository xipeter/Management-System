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
    /// <summary>
    /// 权限管理
    /// </summary>
    public partial class ucPermission : UserControl,Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        public ucPermission()
        {
            InitializeComponent();
        }

        

        private DataSet ds = new DataSet();
        private DataView dv;
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void init()
        {
            //初始化DataTable
            DataTable table = new DataTable("Table");

            DataColumn dataColumn1 = new DataColumn("员工编码");
            dataColumn1.DataType = typeof(System.String);
            table.Columns.Add(dataColumn1);

            DataColumn dataColumn2 = new DataColumn("姓名");
            dataColumn2.DataType = typeof(System.String);
            table.Columns.Add(dataColumn2);

            DataColumn dataColumn3 = new DataColumn("科室");
            dataColumn3.DataType = typeof(System.String);
            table.Columns.Add(dataColumn3);

            DataColumn dataColumn4 = new DataColumn("医嘱权限");
            dataColumn4.DataType = typeof(System.String);
            table.Columns.Add(dataColumn4);

            DataColumn dataColumn5 = new DataColumn("医嘱授权起始");
            dataColumn5.DataType = typeof(System.DateTime);
            table.Columns.Add(dataColumn5);

            DataColumn dataColumn6 = new DataColumn("医嘱授权结束");
            dataColumn6.DataType = typeof(System.DateTime);
            table.Columns.Add(dataColumn6);

            DataColumn dataColumn7 = new DataColumn("病历权限");
            dataColumn7.DataType = typeof(System.String);
            table.Columns.Add(dataColumn7);

            DataColumn dataColumn8 = new DataColumn("质控权限");
            dataColumn8.DataType = typeof(System.String);
            table.Columns.Add(dataColumn8);

            DataColumn dataColumn9 = new DataColumn("操作员");
            dataColumn9.DataType = typeof(System.String);
            table.Columns.Add(dataColumn9);

            DataColumn dataColumn10 = new DataColumn("操作日期");
            dataColumn10.DataType = typeof(System.DateTime);
            table.Columns.Add(dataColumn10);

            //初始化dataSet
            ds.Tables.Add(table);


            dv = new DataView(ds.Tables[0]);
            this.fpSpread1.Sheets[0].DataSource = dv;
            this.fpSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this._SetFP();
        }

        protected void _SetFP()
        {
            this.fpSpread1.Sheets[0].Columns[0].Width = 80;
            this.fpSpread1.Sheets[0].Columns[1].Width = 100;
            this.fpSpread1.Sheets[0].Columns[2].Width = 100;
            this.fpSpread1.Sheets[0].Columns[3].Width = 100;
            this.fpSpread1.Sheets[0].Columns[4].Width = 100;
            this.fpSpread1.Sheets[0].Columns[5].Width = 100;
            this.fpSpread1.Sheets[0].Columns[6].Width = 100;
            this.fpSpread1.Sheets[0].Columns[7].Width = 100;
            this.fpSpread1.Sheets[0].Columns[8].Width = 60;
            this.fpSpread1.Sheets[0].Columns[9].Width = 100;
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int Modify()
        {
            //// TODO:  添加 ucPermissionManager.Auditing 实现
            //if (this.fpSpread1.Sheets[0].ActiveRowIndex < 0)
            //{
            //    MessageBox.Show("请选择要修改的行！");
            //    return 0;
            //}
            //int i = this.fpSpread1.Sheets[0].ActiveRowIndex;
            ////Neusoft.HISFC.Models.Medical.Permission obj = new Neusoft.HISFC.Models.Medical.Permission();
            //obj.Person.ID = this.fpSpread1.Sheets[0].Cells[i, 0].Text;
            //obj.Person.Name = this.fpSpread1.Sheets[0].Cells[i, 1].Text;
            //obj.OrderPermission.Permission = this.fpSpread1.Sheets[0].Cells[i, 3].Text;
            //obj.DateBeginOrderPermission = DateTime.Parse(this.fpSpread1.Sheets[0].Cells[i, 4].Value.ToString());
            //obj.DateEndOrderPermission = DateTime.Parse(this.fpSpread1.Sheets[0].Cells[i, 5].Value.ToString());
            //obj.EMRPermission.Permission = this.fpSpread1.Sheets[0].Cells[i, 6].Text;
            //obj.QCPermission.Permission = this.fpSpread1.Sheets[0].Cells[i, 7].Text;
            //obj.OperCode = this.fpSpread1.Sheets[0].Cells[i, 8].Text;
            //ucPermissionInput uc = new ucPermissionInput(obj);
            //Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "修改";
            //if (Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc) == DialogResult.OK)
            //{
            //    this.Retrieve();
            //}
            return 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Del()
        {
            //// TODO:  添加 ucPermissionManager.Del 实现
            //if (this.fpSpread1.Sheets[0].ActiveRowIndex < 0)
            //{
            //    MessageBox.Show("请选择要修改的行！");
            //    return 0;
            //}
            //int i = this.fpSpread1.Sheets[0].ActiveRowIndex;
            //if (MessageBox.Show("确认要删除吗？", "确认", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.No) return 0;

            //Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();

            //if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeletePermission(this.fpSpread1.Sheets[0].Cells[i, 0].Text) == -1)
            //{
            //    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
            //    MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
            //    return -1;
            //}
            //Neusoft.HISFC.BizProcess.Factory.Function.Commit();
            //MessageBox.Show("删除成功！");
            //this.fpSpread1.Sheets[0].Rows.Remove(i, 1);
            return 0;
        }

     
        public int Pre()
        {
            // TODO:  添加 ucPermissionManager.Pre 实现
            this.fpSpread1.Sheets[0].ActiveRowIndex--;
            this.fpSpread1.Sheets[0].AddSelection(this.fpSpread1.Sheets[0].ActiveRowIndex, 0, 1, 1);
            return 0;
        }


        public int Next()
        {
            // TODO:  添加 ucPermissionManager.Next 实现
            this.fpSpread1.Sheets[0].ActiveRowIndex++;
            this.fpSpread1.Sheets[0].AddSelection(this.fpSpread1.Sheets[0].ActiveRowIndex, 0, 1, 1);
            return 0;
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <returns></returns>
        public int Retrieve()
        {
            //// TODO:  添加 ucPermissionManager.Retrieve 实现
            //ds.Tables[0].Rows.Clear();
            //ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetPermissionList();
            //foreach (Neusoft.HISFC.Models.Medical.Permission obj in al)
            //{
            //    DataRow dr = ds.Tables[0].NewRow();

            //    dr["员工编码"] = obj.ID;
            //    dr["姓名"] = obj.Name;
            //    dr["科室"] = obj.Person.Dept.Name;
            //    dr["医嘱权限"] = obj.OrderPermission.ToString();
            //    dr["医嘱授权起始"] = obj.DateBeginOrderPermission;
            //    dr["医嘱授权结束"] = obj.DateEndOrderPermission;
            //    dr["病历权限"] = obj.EMRPermission.ToString();
            //    dr["质控权限"] = obj.QCPermission.ToString();
            //    dr["操作员"] = obj.OperCode;
            //    dr["操作日期"] = obj.OperDate;
            //    ds.Tables[0].Rows.Add(dr);
            //}
            //this._SetFP();
            return 0;
        }
        /// <summary>
        /// 添加新人员权限
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            //// TODO:  添加 ucPermissionManager.Add 实现
            //Neusoft.HISFC.Models.Medical.Permission obj = new Neusoft.HISFC.Models.Medical.Permission();
            //ucPermissionInput uc = new ucPermissionInput(obj);
            //Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "添加";
            //if (Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc) == DialogResult.OK)
            //{
            //    this.Retrieve();
            //}
            return 0;
        }

      
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public int Exit()
        {
            // TODO:  添加 ucPermissionManager.Exit 实现
            this.FindForm().Close();
            return 0;
        }

        public int Save()
        {
            // TODO:  添加 ucPermissionManager.Save 实现
            return 0;
        }

        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            dv.RowFilter = "员工编码 like '%" + this.textBox1.Text.Trim() + "%'";
            this._SetFP();
        }

        public int Print()
        {
            return 0;
        }


        #region IMaintenanceControlable 成员


        public int Copy()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Cut()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Delete()
        {
            return this.Del();
        }

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Import()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Init()
        {
             this.init();
             return 0;
        }

        private bool bdirty = false;
        public bool IsDirty
        {
            get
            {
                return bdirty;
            }
            set
            {
                bdirty = value;
            }
        }

       

        public int NextRow()
        {
            this.Next();
            return 0;
        }

        public int Paste()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreRow()
        {
            this.Pre();
            return 0;
        }

        public int PrintConfig()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintPreview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Query()
        {
           return this.Retrieve();
        }
        Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm a;
        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                if (a != null)
                {
                    a.ShowCutButton = false;
                    a.ShowCopyButton = false;
                    a.ShowModifyButton = true;
                    a.ShowNextRowButton = true;
                    a.ShowPreRowButton = true;
                    a.ShowPrintButton = false;
                    a.ShowExportButton = false;
                    a.ShowImportButton = false;
                    a.ShowPasteButton = false;
                    a.ShowPrintConfigButton = false;
                    a.ShowPrintPreviewButton = false;
                    a.ShowSaveButton = false;
                }
            }
        }

        #endregion
    }
}
