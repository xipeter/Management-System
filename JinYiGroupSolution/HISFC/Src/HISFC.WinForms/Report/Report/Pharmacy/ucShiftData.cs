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

namespace Neusoft.WinForms.Report.Pharmacy
{
    public partial class ucShiftData : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,IDisposable
    {
        public ucShiftData()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        #region 域变量

        /// <summary>
        /// 药品信息
        /// </summary>
        private ArrayList alDrug = new ArrayList();

        #endregion

        #region 属性

        /// <summary>
        /// 起始时间
        /// </summary>
        protected DateTime BeginTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtBegin.Text);
            }
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        protected DateTime EndTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtEnd.Text);
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            List<Neusoft.HISFC.Models.Pharmacy.Item> itemList = itemManager.QueryItemList(true);
            if (itemList == null)
            {
                MessageBox.Show(Language.Msg("基础数据初始化 加载药品列表发生错误") + itemManager.Err);
                return;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Item item in itemList)
            {
                item.Memo = item.Specs;
            }

            this.cmbDrug.AddItems(new ArrayList(itemList.ToArray()));

            itemList.Clear();
            itemList = null;

            DateTime sysTime = itemManager.GetDateTimeFromSysDateTime();

            this.dtEnd.Value = sysTime.AddHours(1);
            this.dtBegin.Value = sysTime.AddDays(-7);
        }

        /// <summary>
        /// 获取Sql索引
        /// </summary>
        /// <returns></returns>
        private string GetSqlIndex()
        {
            if (this.ckIngoreDrug.Checked)
            {
                return "Pharmacy.ShiftData.IngoreDrug";
            }

            return "Pharmacy.ShiftData.Detail";
        }

        /// <summary>
        /// 有效性
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (this.BeginTime >= this.EndTime)
            {
                MessageBox.Show(Language.Msg("起始时间不能大于等于终止时间"));
                return false;
            }
            if (!this.ckIngoreDrug.Checked)
            {
                if (this.cmbDrug.Tag == null || this.cmbDrug.Tag.ToString() == "")
                {
                    MessageBox.Show(Language.Msg("请选择需查询药品"));
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int Query()
        {
            if (!this.IsValid())
            {
                return -1;
            }

            string strSqlIndex = this.GetSqlIndex();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            DataSet ds = new DataSet();
            if (dataManager.ExecQuery(strSqlIndex, ref ds, this.cmbDrug.Tag.ToString(), this.BeginTime.ToString(), this.EndTime.ToString()) == -1)
            {
                MessageBox.Show(Language.Msg("执行查询发生错误") + dataManager.Err);
                return -1;
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.DataSource = ds;
            }
            else
            {
                this.neuSpread1_Sheet1.DataSource = null;
                this.neuSpread1_Sheet1.Rows.Count = 0;
            }

            return 1;
        }

        #endregion      
  
        protected override int OnQuery(object sender, object neuObject)
        {
            return this.Query();
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
            return base.Export(sender, neuObject);
        }

        private void ckIngoreDrug_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbDrug.Enabled = !this.ckIngoreDrug.Checked;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.FormClosed += new FormClosedEventHandler(ParentForm_FormClosed);
            }
            base.OnLoad(e);
        }

        void ParentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        #region IDisposable 成员

        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion
    }
}
