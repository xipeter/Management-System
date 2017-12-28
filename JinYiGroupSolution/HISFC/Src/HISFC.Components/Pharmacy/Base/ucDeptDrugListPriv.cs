using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 病区药品列表检查]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明
    ///		检查病区医生可以看到的药品列表
    ///  />
    /// </summary>
    public partial class ucDeptDrugListPriv : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDeptDrugListPriv()
        {
            InitializeComponent();
        }        

        private DataTable dt = null;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList alDpet = deptManager.GetDeptmentAll();
            this.cmbDept.AddItems(alDpet);

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            ArrayList alPerson = personManager.GetEmployeeAll();
            this.cmbDoc.AddItems(alPerson);

            this.InitDataTable();

            return 1;
        }

        /// <summary>
        /// 数据表初始化
        /// </summary>
        /// <returns></returns>
        private void InitDataTable()
        {
            this.dt = new DataTable();

            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDTime = System.Type.GetType("System.DateTime");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.dt.Columns.AddRange(new DataColumn[] {
														new DataColumn("药品编码",    dtStr),														
														new DataColumn("商品名称",    dtStr),
														new DataColumn("规格",        dtStr),
														new DataColumn("拼音码",      dtStr),
														new DataColumn("五笔码",      dtStr),
				                                        new DataColumn("自定义码",    dtStr)
                    								});

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;

            this.dt.DefaultView.AllowNew = true;
        }

        /// <summary>
        /// 将数据加入DataTable
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        private void AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Storage storage)
        {
            DataRow dr = this.dt.NewRow();

            dr["药品编码"] = storage.Item.ID;
            dr["商品名称"] = storage.Item.Name;
            dr["规格"] = storage.Item.Specs;
            dr["拼音码"] = storage.Item.NameCollection.SpellCode;
            dr["五笔码"] = storage.Item.NameCollection.WBCode;
            dr["自定义码"] = storage.Item.NameCollection.UserCode;

            this.dt.Rows.Add(dr);
        }

        /// <summary>
        /// 将数据加入DataTable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private void AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            DataRow dr = this.dt.NewRow();

            dr["药品编码"] = item.ID;
            dr["商品名称"] = item.Name;
            dr["规格"] = item.Specs;
            dr["拼音码"] = item.NameCollection.SpellCode;
            dr["五笔码"] = item.NameCollection.WBCode;
            dr["自定义码"] = item.NameCollection.UserCode;

            this.dt.Rows.Add(dr);
        }

        /// <summary>
        /// 将药品列表信息加入数据表
        /// </summary>
        /// <param name="alStorage"></param>
        private void AddDataToTable(ArrayList alItem)
        {
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.Item item in alItem)
            {
                this.AddDataToTable(item);
            }

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
        }

        /// <summary>
        /// 将药品列表信息加入数据表
        /// </summary>
        /// <param name="alStorage"></param>
        private void AddDataToTable(List<Neusoft.HISFC.Models.Pharmacy.Storage> alStorage)
        {
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.Storage storage in alStorage)
            {
                this.AddDataToTable(storage);
            }

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
        }

        /// <summary>
        /// 将药品列表信息加入数据表
        /// </summary>
        /// <param name="alStorage"></param>
        private void AddDataToTable(List<Neusoft.HISFC.Models.Pharmacy.Item> alItem)
        {
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

            foreach (Neusoft.HISFC.Models.Pharmacy.Item item in alItem)
            {
                this.AddDataToTable(item);
            }

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
        }

        /// <summary>
        /// 查询
        /// </summary>
        protected void Query()
        {            
            if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "")
            {
                MessageBox.Show(Language.Msg("请选择查询库房"));
                return;
            }
            if (!this.ckIgnoreDoc.Checked)
            {
                if (this.cmbDoc.Tag == null || this.cmbDoc.Tag.ToString() == "")
                {
                    MessageBox.Show(Language.Msg("请选择医生"));
                    return;
                }
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy integratePha = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

            string deptCode = this.cmbDept.Tag.ToString();
            string docCode = "";
            string docGrade = "";
            if (!this.ckIgnoreDoc.Checked && this.cmbDoc.Tag != null)
            {
                docCode = this.cmbDoc.Tag.ToString();

                Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                Neusoft.HISFC.Models.Base.Employee person = personManager.GetPersonByID(docCode);

                docGrade = person.Level.ID;
            }

            this.dt.Rows.Clear();

            List<Neusoft.HISFC.Models.Pharmacy.Item> alList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            ArrayList alArrList = new ArrayList();
            if (!this.ckIgnoreDoc.Checked)
            {
                alList = integratePha.QueryItemAvailableList(deptCode, docCode, docGrade);

                if (alList == null)
                {
                    MessageBox.Show(integratePha.Err);
                    return;
                }

                this.AddDataToTable(alList);

                MessageBox.Show(Language.Msg("查询完成"));
            }
            else
            {
                alArrList = itemManager.QueryItemAvailableList(deptCode);

                if (alArrList == null)
                {
                    MessageBox.Show(itemManager.Err);
                    return;
                }

                this.AddDataToTable(alArrList);

                MessageBox.Show(Language.Msg("查询完成"));
            }
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        protected void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void cmbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDoc.Tag == null)
            {
                return;
            }

            string docCode = this.cmbDoc.Tag.ToString();

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            Neusoft.HISFC.Models.Base.Employee person = personManager.GetPersonByID(docCode);

            this.lbDocInfo.Text = string.Format("医生信息: {0} 职级 {1} 职务 {2}", person.Name, person.Level.ID, person.Duty.ID);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string queryCode = "";
            queryCode = "%" + this.txtFilter.Text.Trim() + "%";
            string filter = "";

            filter = Function.GetFilterStr(this.dt.DefaultView, queryCode);

            this.dt.DefaultView.RowFilter = filter;            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
