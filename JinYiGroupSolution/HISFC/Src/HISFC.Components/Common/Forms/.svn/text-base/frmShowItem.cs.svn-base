using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Neusoft.HISFC.Components.Common.Forms
{
    public partial class frmShowItem : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmShowItem()
        {
            InitializeComponent();
            lnkMore.Click += new EventHandler(lnkMore_Click);
            this.cmbDrugDept.SelectedIndexChanged += new EventHandler(cmbDrugDept_SelectedIndexChanged);
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCSPTION = 2;
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int wMsg, int wParm, int lParm);
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCSPTION, 0);
        }
        FarPoint.Win.Spread.FpSpread sheetView = null;

        #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}
        /// <summary>
        /// 
        /// </summary>
        FarPoint.Win.Spread.FpSpread sheeViewDetail = null;
        #endregion

        /// <summary>
        /// 添加FarPoint
        /// </summary>
        /// <param name="c"></param>
        public void AddControl(Control c)
        {
            if (c.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
                sheetView = c as FarPoint.Win.Spread.FpSpread;
            c.Dock = DockStyle.Fill;
            c.Visible = true;
            this.PanelMain.Controls.Add(c);

            
           
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshFP()
        {

             Neusoft.HISFC.Components.Common.Controls.ucSetColumnForOrder.ReadXml(this.FileName, sheetView.ActiveSheet);

            #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}
            if (sheeViewDetail != null)//程序某些地方调用的时候sheeViewDetail可能为null，so加入此判断add by sunm
            {
                Neusoft.HISFC.Components.Common.Controls.ucSetColumnForOrder.ReadXml(this.FileName, sheeViewDetail.ActiveSheet);
                sheeViewDetail.Sheets[0].ColumnCount = sheetView.Sheets[0].ColumnCount;
            }
            #region {3E09F7EA-C33D-4b98-A52D-87CDD1A84DE9}
            else
            {
                sheeViewDetail = new FarPoint.Win.Spread.FpSpread();
                Neusoft.HISFC.Components.Common.Controls.ucSetColumnForOrder.ReadXml(this.FileName, sheeViewDetail.ActiveSheet);
                sheeViewDetail.Sheets[0].ColumnCount = sheetView.Sheets[0].ColumnCount;
            }
            #endregion

            #endregion

        }
        /// <summary>
        /// toolTip
        /// </summary>
        public string TipText
        {
            set
            {
                this.lblTip.Text = value;
            }
        }
        DataView dv = null;
        /// <summary>
        /// 当前视图
        /// </summary>
        public DataView DataView
        {
            set
            {
                this.dv = value;
            }
        }
        /// <summary>
        /// 是否精确查找
        /// </summary>
        public bool IsReal
        {
            get
            {
                return this.chkReal.Checked;
            }
            set
            {
                this.chkReal.Checked = value;
            }
        }

        private void lblLis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sheetView == null) return;
            Neusoft.HISFC.Components.Common.Controls.ucSetColumnForOrder uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumnForOrder();
            uc.SetColVisible(true, true, false, false);
            uc.SetDataTable(this.FileName,sheetView.ActiveSheet);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.TopMost = true;
            if (Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc) == DialogResult.OK)
            {

                Neusoft.HISFC.Components.Common.Controls.ucSetColumnForOrder.ReadXml(this.FileName, sheetView.ActiveSheet);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.TopMost = false;
        }

        /// <summary>
        /// 
        /// </summary>
        protected string FileName = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath +
            Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "Order.ItemList.xml";



        #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lnkMore_Click(object sender, EventArgs e)
        {
            if (lnkMore.Text == "显示5条")
            {
                this.ResizeBottom();
                this.lnkMore.Text = "更多...";
            }
            else
            {
                for (int i = 5; i < sheeViewDetail.Sheets[0].RowCount; i++)
                    sheeViewDetail.Sheets[0].SetRowVisible(i, true);
                this.resizebottomFP();
                this.lnkMore.Text = "显示5条";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResizeBottom()
        {
            this.lnkMore.Visible = false;
            if (sheeViewDetail.Sheets[0].Rows.Count > 5)
            {
                this.lnkMore.Visible = true;
                for (int i = 5; i < sheeViewDetail.Sheets[0].RowCount; i++)
                    sheeViewDetail.Sheets[0].SetRowVisible(i, false);
            }
            if (sheeViewDetail.Sheets[0].Rows.Count == 0)
            {
                this.pnlBottom.Visible = false;
                this.statusStrip1.Visible = false;
            }
            else if (sheeViewDetail.Sheets[0].RowCount <= 5)
            {
                this.pnlBottom.Visible = true;
                this.statusStrip1.Visible = true;
                
                this.pnlBottom.Height = 20 + sheeViewDetail.Sheets[0].RowCount * (20);
            }
            else
            {
                this.pnlBottom.Visible = true;
                this.statusStrip1.Visible = true;
                this.pnlBottom.Height = 20 + 5 * (20);
            }
        }

        private void resizebottomFP()
        {
            this.pnlBottom.Height = 20 + sheeViewDetail.Sheets[0].RowCount * (20);
            sheeViewDetail.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

        }

        /// <summary>
        /// 添加详细列表
        /// </summary>
        /// <param name="c"></param>
        public void AddBottomControl(Control c)
        {
            if (c.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
            {
                sheeViewDetail = c as FarPoint.Win.Spread.FpSpread;
                sheeViewDetail.Sheets[0].GrayAreaBackColor = pnlBottom.BackColor;
                sheeViewDetail.Sheets[0].DefaultStyle.BackColor = pnlBottom.BackColor;
                sheeViewDetail.Sheets[0].RowHeader.DefaultStyle.BackColor = pnlBottom.BackColor;
                this.statusbarText.Text = "下面显示复合项目对应的收费项目供医生参考";
            }
            else
            {
                this.statusbarText.Text = "下面显示的扩展信息供医生参考";
            }
            c.Dock = DockStyle.Fill;
            c.Visible = true;
            this.pnlBottom.Controls.Add(c);

        }

        #endregion

        #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}

        /// <summary>
        /// 添加详细列表
        /// </summary>
        /// <param name="c"></param>
        public void AddControlOfBottom(Control c)
        {
            if (c.GetType().IsSubclassOf(typeof(FarPoint.Win.Spread.FpSpread)))
            {
                sheeViewDetail = c as FarPoint.Win.Spread.FpSpread;
                sheeViewDetail.Sheets[0].GrayAreaBackColor = pnlBottom.BackColor;
                sheeViewDetail.Sheets[0].DefaultStyle.BackColor = pnlBottom.BackColor;
                sheeViewDetail.Sheets[0].RowHeader.DefaultStyle.BackColor = pnlBottom.BackColor;
                this.statusbarText.Text = "下面显示复合项目对应的收费项目供医生参考";
            }
            else
            {
                this.statusbarText.Text = "下面显示的扩展信息供医生参考";
            }
            c.BackColor = Color.Red;
            c.Visible = true;
            this.pnlBottom.Controls.Add(c);
        }
                
        private void cmbDrugDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cmbDrugDept.Text) && drugDeptChange != null)
            {
                this.drugDeptChange(this.cmbDrugDept.Text);
            }
        }

        public delegate void DrugDeptChanged(string deptCode);

        public event DrugDeptChanged drugDeptChange;
        
        #endregion
    }
}