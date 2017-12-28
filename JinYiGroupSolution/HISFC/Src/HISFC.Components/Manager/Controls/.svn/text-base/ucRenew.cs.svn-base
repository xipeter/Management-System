using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucRenew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint
    {
        //接口使用
        private readonly string description = "数据库对象检查修复";
        private bool isShowButtons;

        private System.Data.DataSet ds;
        private System.Data.DataView dv;

        // 这个是过滤条件，以后要得到其他医院的数据库对象就改这个
        private readonly string owner = "NEWHIS45";

        public ucRenew()
        {
            this.dv = new DataView();

            InitializeComponent();
        }


        #region IControlParamMaint 成员

        public int Apply()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string ErrText
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Init()
        {
            try
            {
                Neusoft.HISFC.BizLogic.Manager.AllObjects obj = new Neusoft.HISFC.BizLogic.Manager.AllObjects();
                
                this.ds = obj.GetAllObject(this.owner);
                if (ds != null && ds.Tables.Count > 0)
                {
                    this.dv = new System.Data.DataView(ds.Tables[0]);
                    neuSpread1_Sheet1.DataSource = dv;
                }
                else
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(obj.Err));
                }
                SetfpSpread1();
            }
            catch (Exception ee)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(ee.Message));
            }
            return 1;
        }

        public bool IsModify
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool IsShowOwnButtons
        {
            get
            {
                return false;
            }
            set
            {
                this.isShowButtons = value;
            }
        }

        public int Save()
        {
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));
            return 1;
        }

        #endregion

        private void ucRenew_Load(object sender, EventArgs e)
        {
            
        }

        private void miCompile_Click(object sender, EventArgs e)
        {
            this.AlterSql();
        }


        private void miRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshfpSpread();
        }

        private void tbSearchField_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "名称 like '" + this.tbSearchField.Text + "%' or 类型 like '" + this.tbSearchField.Text + "%'";
        }

        #region 自定义函数
        private void FromClose()
        {
            this.FindForm().Close();
        }
        /// <summary>
        /// 设定 farPoint的宽度和格式
        /// </summary>
        private void SetfpSpread1()
        {
            neuSpread1_Sheet1.Columns[0].Width = 200;
            neuSpread1_Sheet1.Columns[1].Width = 200;
            neuSpread1_Sheet1.Columns[2].Width = 200;
        }
        /// <summary>
        /// 编译失效的程序
        /// </summary>
        private void AlterSql()
        {
            int RowCount = 0;
            if (neuSpread1_Sheet1.Rows.Count > 0)
            {
                RowCount = neuSpread1_Sheet1.Rows.Count;
                int ActiveRow = neuSpread1_Sheet1.ActiveRowIndex;
                //拥有者
                string Own = neuSpread1_Sheet1.Cells[ActiveRow, 0].Text;
                //程序名称
                string ObjectName = neuSpread1_Sheet1.Cells[ActiveRow, 1].Text;
                //程序类型
                string ObjectType = neuSpread1_Sheet1.Cells[ActiveRow, 2].Text;
                ObjectType = GetName(ObjectType);
                //组合要传递的参数
                string ParameterString = ObjectType + "  " + Own + "." + ObjectName;

                Neusoft.HISFC.BizLogic.Manager.AllObjects obj = new Neusoft.HISFC.BizLogic.Manager.AllObjects();

                //执行
                obj.AlterSql(ParameterString);

                //执行成功  刷新
                RefreshfpSpread();
                if (RowCount == neuSpread1_Sheet1.Rows.Count)
                {
                    //执行失败
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("编译失败"));
                }
                else
                {
                    //执行成功

                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("编译成功"));
                }
            }
        }
        /// <summary>
        /// 翻译成相对应的词 ，
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetName(string str)
        {
            switch (str)
            {
                case "函数": return "FUNCTION";
                case "索引": return "INDEX";
                case "索引类型": return "INDEXTYPE";
                case "库": return "LIBRARY";
                case "操作员": return "OPERATOR";
                case "包": return "PACKAGE";
                case "过程": return "PROCEDURE";
                case "序列": return "SEQUENCE";
                case "同义词": return "SYNONYM";
                case "表": return "TABLE";
                case "表空间": return "TABLE PARTITION";
                case "触发器": return "TRIGGER";
                case "类型": return "TYPE";
                case "视图": return "VIEW";
                case "JAVA CLASS": return "JAVA";
                case "JAVA DATA": return "JAVA";
                case "JAVA RESOURCE": return "JAVA";
                case "JAVA SOURCE": return "JAVA";
                default: return "";
            }
        }
        /// <summary>
        ///  刷新界面
        /// </summary>
        private void RefreshfpSpread()
        {
            Neusoft.HISFC.BizLogic.Manager.AllObjects obj = new Neusoft.HISFC.BizLogic.Manager.AllObjects();
            ds = obj.GetAllObject(this.owner);
            if (this.ds != null && this.ds.Tables.Count > 0)
            {
                this.dv = new System.Data.DataView(this.ds.Tables[0]);
                neuSpread1_Sheet1.DataSource = this.dv;
            }
            SetfpSpread1();
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        public void ExportInfo()
        {
            bool ret = false;
            //导出数据
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel|.xls";
                saveFileDialog1.FileName = "";
                saveFileDialog1.Title = "导出数据";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ret = this.neuSpread1.SaveExcel(saveFileDialog1.FileName);
                    if (ret)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("导出成功"));
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(ee.Message));
            }
        }
        #endregion 

    }
}
