using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品批量调价设置]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    internal partial class frmGroupAdjust : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmGroupAdjust()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 所有项目
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> alAllItem;

        /// <summary>
        /// 调价项目
        /// </summary>
        private ArrayList adjustItems;

        /// <summary>
        /// 价格公式
        /// </summary>
        private string priceException = "";

        #endregion

        #region 属性

        /// <summary>
        /// 本次供挑选的所有项目
        /// </summary>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> AllItem
        {
            set
            {
                this.alAllItem = value;
            }
        }
      
        /// <summary>
        /// 调价项目
        /// </summary>
        public ArrayList AdjustItems
        {
            get
            {
                return this.adjustItems;
            }
        }

        /// <summary>
        /// 价格公式
        /// </summary>
        public string PriceException
        {
            get
            {
                return this.priceException;
            }
        }

        #endregion


        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            this.adjustItems = new ArrayList();

            this.priceException = "";
        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        {
            this.priceException = this.txtException.Text;

            if (this.priceException == "")
                return true;

            string priceStr = "";

            if (this.priceException.IndexOf("{0}*") == -1 && this.priceException.IndexOf("{0}+") == -1)//{8AFF28F4-6948-4714-A5A9-5AA923DBBC89}
            {
                MessageBox.Show("调价公式输入不正确 请参照提示信息重新录入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                priceStr = string.Format(this.priceException, "1");
            }
            catch (Exception e)
            {
                MessageBox.Show("调价公式输入不正确 请参照提示信息重新录入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            object o = Neusoft.FrameWork.Public.String.ExpressionVal(priceStr);
            if (o == null)
            {
                MessageBox.Show("公式设置不符合规则 请重新检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 根据传入的药品信息根据公式生成新零售价
        /// </summary>
        /// <param name="item">传入药品信息</param>
        /// <returns>成功返回新零售价 出错返回-1</returns>
        public decimal GetNewPrice(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            if (this.rbRetailFlag.Checked)
                return this.GetNewPrice(item.PriceCollection.RetailPrice);
            else
                return this.GetNewPrice(item.PriceCollection.PurchasePrice);
        }

        /// <summary>
        /// 获取新价格
        /// </summary>
        /// <param name="oldPrice"></param>
        /// <returns></returns>
        public decimal GetNewPrice(decimal oldPrice)
        {
            this.priceException = this.txtException.Text;

            string priceStr = "";

            try
            {
                priceStr = string.Format(this.priceException, oldPrice.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("调价公式输入不正确 请参照提示信息重新录入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            object o = Neusoft.FrameWork.Public.String.ExpressionVal(priceStr);
            if (o == null)
            {
                return -1;
            }
            else
            {
                return Neusoft.FrameWork.Function.NConvert.ToDecimal(o);
            }
        }


        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (!this.Valid())
                return;

            this.adjustItems = new ArrayList();

            if (this.alAllItem != null && !this.ckOnlyPrice.Checked)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.Item info in this.alAllItem)
                {
                    if (info.Type.ID == "P" && this.ckDrugP.Checked)
                    {
                        this.adjustItems.Add(info);
                        continue;
                    }
                    if (info.Type.ID == "C" && this.ckDrugC.Checked)
                    {
                        this.adjustItems.Add(info);
                        continue;
                    }
                    if (info.Type.ID == "Z" && this.ckDrugZ.Checked)
                    {
                        this.adjustItems.Add(info);
                    }
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        private void ckOnlyPrice_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ckOnlyPrice.Checked)
                this.neuGroupBox1.Enabled = false;
            else
                this.neuGroupBox1.Enabled = true;
        }

    }
}