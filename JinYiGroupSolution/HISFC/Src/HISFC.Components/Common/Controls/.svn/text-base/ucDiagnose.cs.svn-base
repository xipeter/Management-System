using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucDiagnose : UserControl
    {
        public ucDiagnose()
        {
            InitializeComponent();
        }

        private ArrayList al = new ArrayList();
        private ArrayList almc = new ArrayList();
        private DataSet ds = null;

        public delegate int MyDelegate(Keys key);
        /// <summary>
        /// 双击、回车项目列表时执行的事件
        /// </summary>
        public event MyDelegate SelectItem;
        public bool isDrag = false;

        #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}
        /// <summary>
        /// 科室常用诊断标志
        /// </summary>
        private bool isUseDeptICD = false;

        /// <summary>
        /// 科室常用诊断标志
        /// </summary>
        [Category("科室常用诊断"), Description("是否其使用科室常用诊断")]
        public bool IsUseDeptICD
        {
            get
            {
                return isUseDeptICD;
            }
            set
            {
                isUseDeptICD = value;
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            //t=new Thread(new ThreadStart(Retrieve));
            #region 生成DataSet
            ds = new DataSet();
            ds.Tables.Add("items");
            ds.Tables[0].Columns.AddRange(new DataColumn[]
				{
					new DataColumn("icd_code",Type.GetType("System.String")),
					new DataColumn("icd_name",Type.GetType("System.String")),
					new DataColumn("spell_code",Type.GetType("System.String"))					
				});
            ds.CaseSensitive = false;
            //			fpSpread1.DataSource=ds;
            //			fpSpread1_Sheet1.Columns[0].Width=66F;
            //			fpSpread1_Sheet1.Columns[1].Width=251F;
            //			fpSpread1_Sheet1.Columns[2].Width=90F;
            #endregion

            //t.Start();
            Retrieve();

            return 0;
        }
        private void Retrieve()
        {
            Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase icdMgr = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase();

            #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}
            //al = icdMgr.ICDQuery(ICDTypes.ICD10, QueryTypes.Valid);
            if (this.isUseDeptICD)
            {
                al = icdMgr.QueryDeptDiag(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID);
            }
            else
            {
                al = icdMgr.ICDQuery(ICDTypes.ICD10, QueryTypes.Valid);
            }

            #endregion

            if (al != null)
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.ICD item in al)
                {
                    ds.Tables[0].Rows.Add(new object[]
				{
					item.ID,item.Name,item.SpellCode});
                }

                fpSpread1.DataSource = ds;
                fpSpread1_Sheet1.Columns[0].Width = 66F;
                fpSpread1_Sheet1.Columns[1].Width = 251F;
                fpSpread1_Sheet1.Columns[2].Width = 90F;
            }
        }
        /// <summary>
        /// 初始化医保ICD
        /// </summary>
        /// <returns></returns>
        public int InitICDMedicare(String dType)
        {
            ds = new DataSet();
            ds.Tables.Add("items");
            ds.Tables[0].Columns.AddRange(new DataColumn[]
				{
					new DataColumn("icd_code",Type.GetType("System.String")),
					new DataColumn("icd_name",Type.GetType("System.String")),
					new DataColumn("spell_code",Type.GetType("System.String")),
					new DataColumn("icd_type",Type.GetType("System.String"))
				});
            ds.CaseSensitive = false;
            RetrieveICDMedicare(dType);
            return 0;
        }
        public void RetrieveICDMedicare(String dType)
        {
            ds.CaseSensitive = false;
            Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC icdMgrMc = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC();
            almc = icdMgrMc.ICDQueryMc(dType);
            String icdTypeName = "";
            if (almc != null)
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.ICDMedicare item in almc)
                {
                    switch (item.IcdType)
                    {
                        case "1":
                            icdTypeName = "ICD10";
                            break;
                        case "2":
                            icdTypeName = "市医保";
                            break;
                        case "3":
                            icdTypeName = "省医保";
                            break;
                        default:
                            icdTypeName = "";
                            break;
                    }
                    ds.Tables[0].Rows.Add(new object[] { item.ID, item.Name, item.SpellCode, icdTypeName });
                }
                
                fpSpread1.DataSource = ds;
                fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ICD类别";
                fpSpread1_Sheet1.Columns.Get(3).Label = "ICD类别";
                fpSpread1_Sheet1.Columns.Get(3).Visible = true;
                fpSpread1_Sheet1.Columns[0].Width = 66F;
                fpSpread1_Sheet1.Columns[1].Width = 251F;
                fpSpread1_Sheet1.Columns[2].Width = 90F;
                fpSpread1_Sheet1.Columns[3].Width = 66F;
            }
        }
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int Filter(string text)
        {
            text = "(icd_code like '%" + text.Trim() + "%') or " +
                 "(spell_code like '%" + text.Trim() + "%') or " +
                 "(icd_name like '%" + text.Trim() + "%')";

            DataView dv = new DataView(ds.Tables[0]);
            try
            {
                dv.RowFilter = text;
            }
            catch { }

            fpSpread1.DataSource = dv;
            fpSpread1_Sheet1.Columns[0].Width = 66F;
            fpSpread1_Sheet1.Columns[1].Width = 251F;
            fpSpread1_Sheet1.Columns[2].Width = 90F;

            if (fpSpread1_Sheet1.Rows.Count == 1 && this.isDrag)
            {
                if (SelectItem != null)
                {
                    this.SelectItem(Keys.Enter);
                }
            }
            return 0;
        }
        /// <summary>
        /// 下一行
        /// </summary>
        /// <returns></returns>
        public int NextRow()
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;
            if (row < fpSpread1_Sheet1.RowCount - 1)
            {
                fpSpread1_Sheet1.ActiveRowIndex = row + 1;
                fpSpread1_Sheet1.AddSelection(row + 1, 0, 1, 1);
                this.fpSpread1.ShowRow(0, this.fpSpread1_Sheet1.ActiveRowIndex, FarPoint.Win.Spread.VerticalPosition.Nearest);
            }
            return 0;
        }
        /// <summary>
        /// 上一行
        /// </summary>
        /// <returns></returns>
        public int PriorRow()
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;
            if (row > 0)
            {
                fpSpread1_Sheet1.ActiveRowIndex = row - 1;
                fpSpread1_Sheet1.AddSelection(row - 1, 0, 1, 1);
                this.fpSpread1.ShowRow(0, this.fpSpread1_Sheet1.ActiveRowIndex, FarPoint.Win.Spread.VerticalPosition.Nearest);
            }
            return 0;
        }

        /// <summary>
        /// 添加焦点
        /// </summary>
        /// <returns></returns>
        public void SetFocus()
        {
            this.fpSpread1.Focus();
        }
        /// <summary>
        /// 返回选择项
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GetItem(ref Neusoft.HISFC.Models.HealthRecord.ICD item)
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;

            if (row < 0 || fpSpread1_Sheet1.RowCount == 0)
            {
                item = null;
                return -1;
            }
            string IcdCode = fpSpread1_Sheet1.GetText(row, 0);//项目代码
            string IcdName = fpSpread1_Sheet1.GetText(row, 1);

            foreach (Neusoft.HISFC.Models.HealthRecord.ICD icd in al)
            {
                if (icd.ID == IcdCode && icd.Name == IcdName)
                {
                    item = icd;
                    return 0;
                }
            }

            item = null;
            return -1;
        }
        /// <summary>
        /// 返回选择项(医保)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GetItemMc(ref Neusoft.HISFC.Models.HealthRecord.ICDMedicare item)
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;

            if (row < 0 || fpSpread1_Sheet1.RowCount == 0)
            {
                item = null;
                return -1;
            }
            string IcdCode = fpSpread1_Sheet1.GetText(row, 0);//项目代码
            string IcdName = fpSpread1_Sheet1.GetText(row, 1);

            foreach (Neusoft.HISFC.Models.HealthRecord.ICDMedicare icd in almc)
            {
                if (icd.ID == IcdCode && icd.Name == IcdName)
                {
                    item = icd;
                    return 0;
                }
            }

            item = null;
            return -1;
        }
        private void fpSpread1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                if (SelectItem != null)
                {
                    this.SelectItem(Keys.Enter);
                }
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //{24C3CDF8-4FEF-4d59-A0E3-9EFF388F6E68}
            if (e.ColumnHeader)
            {
                return;
            }

            if (SelectItem != null)
            {
                this.SelectItem(Keys.Enter);
            }
        }

    }
}
