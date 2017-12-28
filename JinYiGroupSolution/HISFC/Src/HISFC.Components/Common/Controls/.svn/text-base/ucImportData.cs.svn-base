using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: 数据导入]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007－04]<br></br>
    /// <说明>
    ///     1、数据导入并显示 .xls 或 .dbf
    /// </说明>
    /// </summary>
    public partial class ucImportData : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucImportData()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 执行Sql
        /// </summary>
        private System.Data.OleDb.OleDbCommand oledbDataCommand = null;

        /// <summary>
        /// 数据连接
        /// </summary>
        private System.Data.OleDb.OleDbConnection oledbDataConnection = null;

        /// <summary>
        /// 数据适配器
        /// </summary>
        private System.Data.OleDb.OleDbDataAdapter oledbDataAdapter = null;

        /// <summary>
        /// ODBC
        /// </summary>
        private System.Data.Odbc.OdbcCommand odbcDataCommand = null;

        /// <summary>
        /// ODBC 数据连接
        /// </summary>
        private System.Data.Odbc.OdbcConnection odbcDataConnection = null;

        /// <summary>
        /// ODBC数据适配器
        /// </summary>
        private System.Data.Odbc.OdbcDataAdapter odbcDataAdapter = null;
        
        /// <summary>
        /// 由文件内读取的数据集
        /// </summary>
        private DataSet ds = null;

        /// <summary>
        /// 结果
        /// </summary>
        private DialogResult rs = DialogResult.Cancel;

        #endregion

        #region 属性

        /// <summary>
        /// 由文件内读取的数据集
        /// </summary>
        public DataSet ImportData
        {
            get
            {
                return this.ds;
            }
        }

        /// <summary>
        /// 结果 
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.rs;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 清屏
        /// </summary>
        protected void Claer()
        {
            if (this.ds != null)
            {
                this.ds.Clear();
            }

            this.txtFilePath.Text = "";
            this.lbDataInfo.Text = "数据信息:";

            this.rs = DialogResult.Cancel;
        }

        /// <summary>
        /// Excel数据导入
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        protected int ImportExcel(string dataFilePath)
        {
            if (this.ds != null)
            {
                this.ds.Clear();
            }
            else
            {
                this.ds = new DataSet();
            }

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg("正在读入数据 请稍候.."));
                Application.DoEvents();

                this.oledbDataConnection = new System.Data.OleDb.OleDbConnection();
                this.oledbDataConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataFilePath + @";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";

                this.oledbDataCommand = new System.Data.OleDb.OleDbCommand();
                this.oledbDataCommand.Connection = this.oledbDataConnection;
                this.oledbDataCommand.CommandText = "SELECT *  FROM " + "[sheet1$]";

                this.oledbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
                this.oledbDataAdapter.SelectCommand = this.oledbDataCommand;
                this.oledbDataAdapter.Fill(this.ds);

                if (this.ds.Tables.Count <= 0)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("无数据"));
                    return 1;
                }

                int column = this.ds.Tables[0].Columns.Count;

                int row = this.ds.Tables[0].Rows.Count;

                this.lbDataInfo.Text = string.Format("数据信息:共 {0} 列 {1} 行", column.ToString(), row.ToString());

                this.neuSpread1_Sheet1.DataSource = this.ds;

                this.rs = DialogResult.OK;

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// DBF数据导入
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int ImportDBF(string dataFilePath)
        {
            if (this.ds != null)
            {
                this.ds.Clear();
            }
            else
            {
                this.ds = new DataSet();
            }

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg("正在读入数据 请稍候.."));
                Application.DoEvents();

                string sourcePathName = dataFilePath.Substring(0, dataFilePath.LastIndexOf("\\"));
                string sourceFileName = dataFilePath.Substring(dataFilePath.LastIndexOf("\\") + 1, dataFilePath.Length - dataFilePath.LastIndexOf("\\") - 1);

                this.odbcDataAdapter = new System.Data.Odbc.OdbcDataAdapter();
                this.odbcDataCommand = new System.Data.Odbc.OdbcCommand();
                this.odbcDataConnection = new System.Data.Odbc.OdbcConnection();
                this.odbcDataConnection.ConnectionString = "MaxBufferSize=2048;DSN=dBASE Files;PageTimeout=5;DefaultDir=" + sourcePathName + "\\;DBQ=" + sourcePathName + "\\;DriverId=" + "533";
                this.odbcDataCommand.Connection = this.odbcDataConnection;
                this.odbcDataAdapter.SelectCommand = this.odbcDataCommand;
                this.odbcDataCommand.CommandText = "SELECT *  FROM " + sourceFileName;
                this.odbcDataAdapter.Fill(this.ds);

                if (this.ds.Tables.Count <= 0)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("无数据"));
                    return 1;
                }

                int column = this.ds.Tables[0].Columns.Count;
                int row = this.ds.Tables[0].Rows.Count;

                this.lbDataInfo.Text = "该数据文件共有" + column.ToString() + "列。共有" + row.ToString() + "条记录。";

                this.neuSpread1_Sheet1.DataSource = this.ds;

                this.rs = DialogResult.OK;

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            this.Claer();

            this.ds = null;

            base.OnLoad(e);
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            Stream dataStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (this.ckDbf.Checked)         //DBF文件
            {
                openFileDialog1.Filter = "DBF files (*.dbf)|*.dbf";               
            }
            else                            //XLS文件
            {
                openFileDialog1.Filter = "Excel files (*.xls)|*.xls"; 
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataStream = openFileDialog1.OpenFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(ex.Message));
                    return;
                }

                if (dataStream != null)
                {
                    this.txtFilePath.Text = openFileDialog1.FileName;
                }
                else
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("无效文件"));
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFilePath.Text))
            {
                MessageBox.Show("请选择数据文件路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFilePath.Focus();
                return;
            }

            if (this.ckDbf.Checked)
            {
                this.ImportDBF(this.txtFilePath.Text);
            }
            else
            {
                this.ImportExcel(this.txtFilePath.Text);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();

            this.rs = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            this.rs = DialogResult.Cancel;
        }
    }
}
