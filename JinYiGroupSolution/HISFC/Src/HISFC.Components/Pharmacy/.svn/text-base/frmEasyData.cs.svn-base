using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy
{
    public partial class frmEasyData : Form
    {
        public frmEasyData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 简单选择控件，名称标题显示
        /// </summary>
        public string EasyLabel
        {
            set
            {
                this.lbName.Text = value;
            }
        }

        /// <summary>
        /// 数据最大长度
        /// </summary>
        public int MaxLength
        {
            set
            {
                this.txtData.MaxLength = value;
            }
        }

        /// <summary>
        /// 用户输入数据
        /// </summary>
        public string EasyData
        {
            get
            {
                return this.txtData.Text;
            }
            set
            {
                this.txtData.Text = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtData.Text.Trim() == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请输入名称"));
                return;
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}