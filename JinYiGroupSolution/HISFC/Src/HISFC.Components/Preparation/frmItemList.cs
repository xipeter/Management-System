using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UFC.Preparation
{
    public partial class frmItemList : Form
    {

        public frmItemList()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmItemList_Load);
            this.SizeChanged += new EventHandler(frmItemList_SizeChanged);
            this.ucItemList1.SelectItem += new EventHandler(ucItemList1_SelectItem);
            this.ucItemList1.VisibleChanged += new EventHandler(ucItemList1_VisibleChanged);
        }
        public event System.EventHandler SelectItem;

        /// <summary>
        /// 是否已进行过初始化
        /// </summary>
        private bool isInitFinished = false;
        /// <summary>
        /// 配置文件存储路径
        /// </summary>
        protected string FilePath = Application.StartupPath + "//Profile//PhaItem.xml";
        /// <summary>
        /// 窗口是否隐藏
        /// </summary>
        public bool FrmVisible
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.ucItemList1.Visible = value;
                this.Visible = value;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(string drugType)
        {
            Neusoft.NFC.Object.NeuObject myNeuObj = new Neusoft.NFC.Object.NeuObject();
            this.ucItemList1.Init(myNeuObj, drugType);
        }
        /// <summary>
        /// 按键相应
        /// </summary>
        /// <param name="key"></param>
        public void Key(Keys key)
        {
            this.ucItemList1.Key(key);
        }
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="strText"></param>
        public void Filter(string strText)
        {
            this.ucItemList1.Filter(strText);
        }


        private void frmItemList_Load(object sender, EventArgs e)
        {
            string strErr = "";
            ArrayList al = Neusoft.NFC.Interface.Classes.Function.GetDefaultValue("PHA", "WinItemSize", out strErr);
            if (al != null && al.Count > 1)
            {
                this.Height = Neusoft.NFC.Function.NConvert.ToInt32(al[0]);
                this.Width = Neusoft.NFC.Function.NConvert.ToInt32(al[1]);
            }
            else
            {
                this.Height = 160;
                this.Width = 456;
            }

            this.isInitFinished = true;
        }

        private void frmItemList_SizeChanged(object sender, EventArgs e)
        {
            if (this.isInitFinished)
            {
                string strErr = "";
                Neusoft.NFC.Interface.Classes.Function.SaveDefaultValue("PHA", "WinItemSize", out strErr, this.Height.ToString(), this.Width.ToString());
            }
        }

        private void ucItemList1_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = this.ucItemList1.Visible;
        }
        private void ucItemList1_SelectItem(object sender, EventArgs e)
        {
            if (this.SelectItem != null)
            {
                this.SelectItem(sender, System.EventArgs.Empty);
            }
        }

    }
}