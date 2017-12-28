using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucItem : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucItem()
        {
            InitializeComponent();
        }

        #region 变量

        private Neusoft.HISFC.BizLogic.Fee.Interface interfaceMgr = new Neusoft.HISFC.BizLogic.Fee.Interface();

        private bool isModify = false;

        private string itemCode = "";

        private string pactCode = "06";

        private Neusoft.HISFC.Models.SIInterface.Compare compare = new Neusoft.HISFC.Models.SIInterface.Compare();

        private DialogResult dr = DialogResult.No;

        #endregion

        #region 属性

        /// <summary>
        /// 是否是修改True修改False添加
        /// </summary>
        public bool IsModify
        {
            get { return this.isModify; }
            set
            {
                this.isModify = value;
                this.txtItemCode.Enabled = !value;
                this.txtName.Enabled = !value;
            }

        }

        /// <summary>
        /// 当前项目编码（修改时用）
        /// </summary>
        public string ItemCode
        {
            set { this.itemCode = value; }
            get { return this.itemCode; }
        }

        /// <summary>
        /// 合同单位
        /// </summary>
        public string PactCode
        {
            set { this.pactCode = value; }
            get { return this.pactCode; }
        }

        public DialogResult DiagResult
        {
            get { return this.dr; }
        }

        public Neusoft.HISFC.Models.SIInterface.Compare CompareItem
        {
            set
            {
                this.compare = value;
                this.SetValue();
            }
            get { return this.compare; }
        }

        #endregion

        #region 方法

        private void SetValue()
        {
            if (this.isModify)
            {
                if (this.compare != null)
                {
                    Neusoft.HISFC.Models.SIInterface.Compare com = new Neusoft.HISFC.Models.SIInterface.Compare();
                    this.interfaceMgr.GetCompareSingleItem(this.pactCode, this.compare.HisCode, ref com);
                    this.txtItemCode.Text = com.CenterItem.ID;
                    this.txtName.Text = com.CenterItem.Name;
                    this.txtPrice.Text = com.CenterItem.Price.ToString("0.00");
                    this.txtRate.Text = com.CenterItem.Rate.ToString("0.00");
                    this.txtMemo.Text = com.CenterItem.Memo;
                }
                else
                {
                    MessageBox.Show("获取市离休编码为 " + this.itemCode + " 目录出错！");
                }
            }
        }

        private void GetValue()
        {
            this.compare.CenterItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPrice.Text);
            this.compare.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtRate.Text);
            this.compare.CenterItem.Memo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtMemo.Text);

            this.compare.CenterItem.OperCode = this.interfaceMgr.Operator.ID;
            this.compare.CenterItem.OperDate = this.interfaceMgr.GetDateTimeFromSysDateTime();
        }

        private int Save()
        {
            if (this.compare == null)
            {
                return -1;
            }

            this.GetValue();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.interfaceMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int result = -1;
            if (this.isModify)
            {
                string sql2 = @"update fin_com_compare c
   set c.center_price = {2},
       c.center_rate  = {3},
       c.center_memo  = '{4}',
       c.oper_code    = '{5}',
       c.oper_date    = to_date('{6}', 'yyyy-mm-dd hh24:mi:ss')
 where c.pact_code = '{0}'
   and c.his_code = '{1}'
";
                sql2 = string.Format(sql2, this.pactCode, this.compare.HisCode, this.compare.CenterItem.Price,
                    this.compare.CenterItem.Rate, this.compare.CenterItem.Memo, this.compare.CenterItem.OperCode, 
                    this.compare.CenterItem.OperDate);
                result = this.interfaceMgr.ExecNoQuery(sql2);
            }
            else
            {

            }
            if (result == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存失败：" + this.interfaceMgr.Err);
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功！");
                this.CloseForm();
            }
            return 1;
        }

        private void CloseForm()
        {
            this.FindForm().Close();
        }

        private void ProcessKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.dr = DialogResult.No;
                this.CloseForm();
            }
        }

        #endregion

        #region 事件

        private void ucItem_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
            this.dr = DialogResult.Yes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CloseForm();
            this.dr = DialogResult.No;
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            this.ProcessKey(sender, e);
        }

        #endregion
    }
}
