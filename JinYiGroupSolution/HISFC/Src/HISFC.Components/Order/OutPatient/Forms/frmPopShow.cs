using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.OutPatient.Forms
{
    public partial class frmPopShow : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmPopShow()
        {
            InitializeComponent();
        }

        #region 变量
        private string name = "";//名称
        
        public bool isPrice = false;//是否是输入价格模式
        public bool isDays = false;//是否修改看诊间隔天数
        string filePath = Application.StartupPath + "\\HISDefaultValue.xml";//配置文件路径
        private bool isCancel = true;

        public bool IsCancel
        {
            get { return isCancel; }
            set { isCancel = value; }
        }
        #endregion

        #region 属性
        public string ModuleName
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.txtname.Text = this.name;
            }
        }
        #endregion
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        #region 函数
        /// <summary>
		/// 快捷键
		/// </summary>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if(keyData == Keys.Enter)
			{
				this.Save();
			}
			if(keyData == Keys.Escape)
			{
				this.name = "1";
				this.Close();
			}
			return base.ProcessDialogKey (keyData);
		}

        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            this.name = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtname.Text.Trim());//{10F8D472-0C7D-4c10-AFDF-11234A37FEFF}

            if (this.name.Length <= 0)
            {
                MessageBox.Show("输入的内容不能为空，请重新输入！");
                return;
            }

            if (this.isPrice || this.isDays)
            {
                decimal price = 0m;
                try
                {
                    price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.name);
                }
                catch
                {
                    MessageBox.Show("输入价格的格式不正确，请重新输入！");
                    return;
                }
                if (price <= 0)
                {
                    MessageBox.Show("输入的价格不能小于或等于0！");
                    return;
                }
                if (price >= 100000)
                {
                    MessageBox.Show("输入的价格过大！");
                    return;
                }
            }
            if (this.isDays)
            {

                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.name) > 9)
                {
                    MessageBox.Show("天数不能大于9，因为挂号有效天数为5天！");
                    return;
                }
                if (System.IO.File.Exists(this.filePath) == false)
                {
                    MessageBox.Show("没有找到本地配置文件:" + filePath + ",请通知信息科人员维护！");
                }
                else
                {
                    //neusoft.neHISFC.Components.Interface.Classes.Function.SaveDefaultValue("SeeHistoryDays", this.name);
                    Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("SeeHistoryDays", this.name);
                    MessageBox.Show("设置显示看诊患者列表间隔天数成功！");
                }
            }

            this.isCancel = false;
            this.Close();
        }
        #endregion 
    }
}