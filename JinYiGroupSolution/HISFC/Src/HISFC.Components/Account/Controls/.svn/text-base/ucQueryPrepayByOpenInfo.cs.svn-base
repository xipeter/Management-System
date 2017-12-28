using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 根据开户信息查询患者预交信息
    /// </summary>
    public partial class ucQueryPrepayByOpenInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQueryPrepayByOpenInfo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();
            base.OnLoad(e);
        }

        /// <summary>
        /// 交叉业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant conManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 选择显示的列
        /// </summary>
        [Description("选择显示的列"),System.ComponentModel.Category("设置"),Browsable(true),DefaultValue(true)]
        public bool[] ShowColumns
        {
            get
            {
                bool[] dic = new bool[this.neuSpread1_Sheet1.ColumnCount];
                for (int i = 0; i < this.neuSpread1_Sheet1.ColumnCount; i++)
                {
                    dic[i]=this.neuSpread1_Sheet1.Columns[i].Visible;
                }
                return dic;
            }
            set
            {
                bool[] dic = value;

                for (int i=0;i<dic.Length;i++)
                {
                    this.neuSpread1_Sheet1.Columns[i].Visible = dic[i];
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            System.Collections.ArrayList al = this.conManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.BANK);
            if (al == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取开户行出错！"));
                return;
            }
            if (al.Count == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("无开户行信息，请维护！"));
                return;
            }
            this.cmbOpenBank.AddItems(al);
        }

        protected override int OnQuery(object sender, object neuObject)
        {

            if (string.IsNullOrEmpty(this.txtOpenAccount.Text) && string.IsNullOrEmpty(this.txtOpenCompany.Text) && string.IsNullOrEmpty(this.txtPostransNO.Text) && string.IsNullOrEmpty(this.cmbOpenBank.Text))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请输入开户信息中一项或多项信息"));
                return -1;
            }
            string openAccount = this.txtOpenAccount.Text;
            if (string.IsNullOrEmpty(openAccount))
            {
                openAccount = "ALL";
            }
            string openCompany = this.txtOpenCompany.Text;
            if (string.IsNullOrEmpty(openCompany))
            {
                openCompany = "ALL";
            }
            string postransNO= this.txtPostransNO.Text;
            if (string.IsNullOrEmpty(postransNO))
            {
                postransNO = "ALL";
            }
            string openBank = this.cmbOpenBank.Text;
            if (string.IsNullOrEmpty(openBank))
            {
                openBank = "ALL";
            }


            string[] obj = new string[] { openCompany, openBank, openAccount, postransNO };

            DataSet ds=new DataSet();

            if (this.conManager.ExecQuery("Fee.Account.QueryByOpenInfo", ref ds, obj) == -1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("执行Fee.Account.QueryByOpenInfo语句出错！"));
                return -1;
            }

            this.neuSpread1_Sheet1.DataSource = ds;

            return base.OnQuery(sender, neuObject);
        }
    }
}
