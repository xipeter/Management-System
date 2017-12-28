using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class cmbPayType : Neusoft.FrameWork.WinForms.Controls.NeuComboBox
    {
         public cmbPayType()
        {
            InitializeComponent();
        }

        public cmbPayType(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.initControl();
            this.SelectedIndexChanged+=new EventHandler(cmbPayType_SelectedIndexChanged);
        }

        #region "变量"
        /// <summary>
        /// 是否弹出
        /// </summary>
        private bool bPop = true;

        /// <summary>
        /// 工作单位
        /// </summary>
        private string workUnit = "";
        #endregion

        #region "实体变量"

        /// <summary>
        /// 银行实体
        /// </summary>
        public Neusoft.HISFC.Models.Base.Bank bank = new Neusoft.HISFC.Models.Base.Bank();

        #endregion

        #region"属性"
        /// <summary>
        /// 弹出属性

        /// </summary>
        public bool Pop
        {
            get
            {
                return this.bPop;
            }
            set
            {
                this.bPop = value;
            }
        }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string WorkUnit
        {
            get
            {
                return this.workUnit;
            }
            set
            {
                this.workUnit = value;
            }
        }
        #endregion 

        #region 方法
        /// <summary>
        /// 初始化控件

        /// </summary>
        private void initControl()
        {
            this.Items.Clear();


            //住院显示部分支付方式。


            try
            {
                //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                //this.AddItems(Neusoft.HISFC.Models.Fee.EnumPayTypeService.List());
                ArrayList al = managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);
                int index = 0;
                while (index <= al.Count -1)
                {
                    if ((al[index] as Neusoft.FrameWork.Models.NeuObject).ID == "YS")
                    {
                        al.RemoveAt(index);
                    }
                    index++;
                }
                this.AddItems(al);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 显示bank控件
        /// </summary>
        private void ShowBank()
        {

            Neusoft.FrameWork.WinForms.Forms.BaseForm f;
            f = new Neusoft.FrameWork.WinForms.Forms.BaseForm();

            ucBank Bank = new ucBank();

            Bank.Dock = System.Windows.Forms.DockStyle.Fill;
            f.Controls.Add(Bank);

            Bank.Bank = this.bank;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            f.Size = new System.Drawing.Size(295, 240);
            f.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            f.Text = "选择银行";
            f.ShowDialog();
        }
        #endregion

        #region 事件
        private void cmbPayType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.bPop == false) return;
                if(this.Tag == null || this.Tag.ToString()==string.Empty) return;
                this.bank = new Neusoft.HISFC.Models.Base.Bank();
                //Neusoft.HISFC.Models.Fee.EnumPayType payType =
                //    (Neusoft.HISFC.Models.Fee.EnumPayType)Enum.Parse(typeof(Neusoft.HISFC.Models.Fee.EnumPayType), this.Tag.ToString());
                //switch (payType)
                //{
                //    //借记卡
                //    case Neusoft.HISFC.Models.Fee.EnumPayType.DB:

                //        break;
                //    //支票
                //    case Neusoft.HISFC.Models.Fee.EnumPayType.CH:
                //        this.ShowBank();
                //        break;
                //    //信用卡

                //    case Neusoft.HISFC.Models.Fee.EnumPayType.CD:

                //        break;
                //    //汇票
                //    case Neusoft.HISFC.Models.Fee.EnumPayType.PO:
                //        this.ShowBank();
                //        break;

                //    default:
                //        break;
                //}
                Neusoft.FrameWork.Models.NeuObject payType = this.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
                switch (payType.ID)
                {
                    //借记卡
                    case "DB":

                        break;
                    //支票
                    case "CH":
                        this.ShowBank();
                        break;
                    //信用卡

                    case "CD":

                        break;
                    //汇票
                    case "PO":
                        this.ShowBank();
                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion
    }
}
