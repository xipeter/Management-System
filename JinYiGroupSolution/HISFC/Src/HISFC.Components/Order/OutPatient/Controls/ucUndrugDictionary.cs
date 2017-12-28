using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    public partial class ucUndrugDictionary : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucUndrugDictionary()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 非药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee undrugManagement = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        private List<Neusoft.HISFC.Models.Fee.Item.Undrug> undrugList = new List<Neusoft.HISFC.Models.Fee.Item.Undrug>();

        private DataSet dsUndrug = new DataSet();
        private DataTable dtUndrug = new DataTable();
        private DataView dvUndrug = new DataView();
        private string filterInput = "";
        private string mainSettingFilePath = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + @".\UndrugDictionary.xml";
        #endregion

        #region 私有方法

        /// <summary>
        /// 设置ｆｒｐ
        /// </summary>
        private void InitFrp()
        {
            dsUndrug = new DataSet();
            dtUndrug = new DataTable();
            dvUndrug = new DataView();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化表格，请稍候.....");
            if (File.Exists(this.mainSettingFilePath))
            {
                
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.mainSettingFilePath, this.dtUndrug, ref this.dvUndrug, this.fpSpread1_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, this.mainSettingFilePath);
            }
            else
            {
                this.dtUndrug.Columns.AddRange(new DataColumn[] 
                {
                    new DataColumn("非药品代码", typeof(string)),
                    new DataColumn("非药品名称", typeof(string)),
                    new DataColumn("国标码", typeof(string)),
                    new DataColumn("国际编码", typeof(string)),
                    new DataColumn("系统类别", typeof(string)),
                    new DataColumn("最小费用码", typeof(string)),
                    new DataColumn("拼音码", typeof(string)),
                    new DataColumn("五笔码", typeof(string)),
                    new DataColumn("输入码", typeof(string)),
                    new DataColumn("计价单位", typeof(string)),
                    new DataColumn("有效性标志", typeof(string)),
                    new DataColumn("规格", typeof(string)),
                    new DataColumn("执行科室", typeof(string)),
                    new DataColumn("默认检查部位", typeof(string)),
                    new DataColumn("价格", typeof(decimal)),
                    new DataColumn("特诊价", typeof(decimal)),
                    new DataColumn("儿童价", typeof(decimal)),
                    new DataColumn("确认标志", typeof(bool))
                    
                });

                this.dvUndrug = new DataView(this.dtUndrug);

                this.fpSpread1.DataSource = this.dvUndrug;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, this.mainSettingFilePath);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 加载非药品信息
        /// </summary>
        private void QueryUndrug()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载非药品信息，请稍候.....");
            Application.DoEvents();
            undrugList = undrugManagement.QueryAllItemsList();
            
            this.dtUndrug.Clear();
            foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in undrugList)
            {
                DataRow row = this.dtUndrug.NewRow();

                row["非药品代码"] = undrug.ID;
                row["非药品名称"] = undrug.Name;
                row["国标码"] = undrug.GBCode;
                row["国际编码"] = undrug.NationCode;
                row["系统类别"] = undrug.SysClass.Name;
                row["最小费用码"] = undrug.MinFee.Name;
                row["拼音码"] = undrug.SpellCode;
                row["五笔码"] = undrug.WBCode;
                row["输入码"] = undrug.UserCode;
                row["计价单位"] = undrug.PriceUnit;
                row["有效性标志"] = undrug.ValidState;
                row["规格"] = undrug.Specs;
                row["执行科室"] = undrug.ExecDept;
                row["默认检查部位"] = undrug.CheckBody;
                row["价格"] = undrug.Price;
                row["特诊价"] = undrug.SpecialPrice;
                row["儿童价"] = undrug.ChildPrice;
                row["确认标志"] = undrug.IsNeedConfirm;

                this.dtUndrug.Rows.Add(row);
            }
            this.dtUndrug.AcceptChanges();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }
                
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            if (!this.DesignMode)
            {
                this.InitFrp();
                this.QueryUndrug();
            }
            return base.OnInit(sender, neuObject, param);
        }

        #endregion
                
        #region 事件
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtFilter.Text);

            queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(queryCode, "'", "%");
            
            queryCode = queryCode + "%";
            this.filterInput = "((拼音码 LIKE '" + queryCode + "') OR " +
                "(五笔码 LIKE '" + queryCode + "') OR " +
                "(输入码 LIKE '" + queryCode + "') OR " +
                "(国标码 LIKE '" + queryCode + "') )" ;

            this.dvUndrug.RowFilter = filterInput;
        }

        private void linkLblSet_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            uc.FilePath = this.mainSettingFilePath;
            uc.SetDataTable(this.mainSettingFilePath, this.fpSpread1_Sheet1);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            uc.DisplayEvent += new EventHandler(ucSetColumn_DisplayEvent);
            this.ucSetColumn_DisplayEvent(null, null);
        }

        private void ucSetColumn_DisplayEvent(object sender, EventArgs e)
        {
            this.InitFrp();
            this.QueryUndrug();
        }
        
        #endregion

        

    }
}

