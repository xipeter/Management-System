using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.WinForms.Report.Finance.FinOpb.FinRegPatientInfo
{
    /// <summary>
    /// [功能描述: 历史医嘱查询]<br></br>
    /// [创 建 者: licheng]<br></br>
    /// [创建时间: 2010-5-26]<br></br>
    /// <修改记录
    ///		修改人='sunm'
    ///		修改时间=''
    ///		修改目的='门诊历史医嘱查询使用'
    ///		修改描述='对住院当中的本控件进行的另存，修改患者和医嘱为门诊'
    ///  />
    /// </summary>
    public partial class ucOrderHistoryQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucOrderHistoryQuery()
        {
            InitializeComponent();
            this.treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            //{DF8058FF-72C0-404f-8F36-6B4057B6F6CD}
            this.fpSpread1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fpSpread1_MouseUp);
        }

        /// <summary>
        /// 右键菜单{DF8058FF-72C0-404f-8F36-6B4057B6F6CD}
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip contextMenu1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();

        /// <summary>
        /// 挂号业务
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration manager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 门诊医嘱业务
        /// </summary>
        Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManager = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null) return;
                Neusoft.FrameWork.Models.NeuObject obj = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                ArrayList al = orderManager.QueryOrder(obj.ID);
                Neusoft.HISFC.Components.Common.Classes.Function.ShowOrder(this.fpSpread1_Sheet1, al, Neusoft.HISFC.Models.Base.ServiceTypes.C);


            }
            catch { }
        }


        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.Patient = neuObject as Neusoft.HISFC.Models.Registration.Register;
            return 0;
        }

        public int OnSetValue(object neuObject)
        {
            this.Patient = neuObject as Neusoft.HISFC.Models.Registration.Register;
            return 0;
        }

        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            set
            {
                if (value == null) return;
                DateTime dtNow = this.orderManager.GetDateTimeFromSysDateTime();
                DateTime dtBegin = Convert.ToDateTime("1900-01-01");
                ArrayList al = manager.QueryValidPatientsByCardNO(value.PID.CardNO, dtBegin);
                if (al == null) return;
                this.treeView1.Nodes[0].Nodes.Clear();

                foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
                {
                    string no = obj.ID;
                    //if (obj.ID != value.ID)
                    //{
                    Neusoft.HISFC.Models.Registration.Register reg = obj as Neusoft.HISFC.Models.Registration.Register;

                    TreeNode node = new TreeNode("【" + reg.DoctorInfo.SeeDate.Date.ToString("yyyy-MM-dd") + "】" + obj.Name);
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 2;
                    node.Tag = obj;

                    this.treeView1.Nodes[0].Nodes.Add(node);

                    ArrayList alSeeNO = orderManager.QuerySeeNoListByCardNo(reg.ID, reg.PID.CardNO);
                    foreach (Neusoft.FrameWork.Models.NeuObject seeNO in alSeeNO)
                    {
                        TreeNode nodeChild = new TreeNode(seeNO.User02 + "【" + seeNO.ID + "】");
                        nodeChild.ImageIndex = 3;
                        nodeChild.SelectedImageIndex = 3;
                        nodeChild.Tag = seeNO;
                        node.Nodes.Add(nodeChild);

                    }
                    //}

                }
            }
        }

        #region 复制粘贴{DF8058FF-72C0-404f-8F36-6B4057B6F6CD}

        /// <summary>
        /// 复制
        /// </summary>
        private void CopyOrder()
        {
            if (this.fpSpread1_Sheet1.Rows.Count <= 0) return;

            this.fpSpread1.Focus();

            ArrayList list = new ArrayList();

            //获取选中行的医嘱ID
            for (int row = 0; row < this.fpSpread1_Sheet1.Rows.Count; row++)
            {
                for (int col = 0; col < this.fpSpread1_Sheet1.Columns.Count; col++)
                {
                    if (this.fpSpread1_Sheet1.IsSelected(row, col))
                    {
                        list.Add(fpSpread1_Sheet1.Cells[row, 0].Value.ToString());
                        break;
                    }
                }
            }

            if (list.Count <= 0) return;
            //先添加到COPY列表
            for (int count = 0; count < list.Count; count++)
            {
                HISFC.Components.Order.Classes.HistoryOrderClipboard.Add(list[count]);
            }
            string type = "1";
            HISFC.Components.Order.Classes.HistoryOrderClipboard.Add(type);
            //然后将copy列表放到剪贴板上
            HISFC.Components.Order.Classes.HistoryOrderClipboard.Copy();
        }

        /// <summary>
        /// 右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_MouseUp(object sender, MouseEventArgs e)
        {
            int ActiveRowIndex = -1;

            if (e.Button == MouseButtons.Right)
            {
                this.contextMenu1.Items.Clear();
                FarPoint.Win.Spread.Model.CellRange c = fpSpread1.GetCellFromPixel(0, 0, e.X, e.Y);
                if (c.Row >= 0)
                {
                    this.fpSpread1.ActiveSheet.ActiveRowIndex = c.Row;
                    this.fpSpread1.ActiveSheet.AddSelection(c.Row, 0, 1, 1);
                    ActiveRowIndex = c.Row;
                }
                else
                {
                    ActiveRowIndex = -1;
                }
                if (ActiveRowIndex < 0) return;


                //ToolStripMenuItem mnuCopyGroup = new ToolStripMenuItem();
                //mnuCopyGroup.Text = "复制成组套";
                //mnuCopyGroup.Click += new EventHandler(mnuCopyGroup_Click);
                //this.contextMenu1.Items.Add(mnuCopyGroup);

                ToolStripMenuItem mnuCopyOrder = new ToolStripMenuItem();
                mnuCopyOrder.Text = "复制";
                mnuCopyOrder.Click += new EventHandler(mnuCopyOrder_Click);
                this.contextMenu1.Items.Add(mnuCopyOrder);

                this.contextMenu1.Show(this.fpSpread1, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// 菜单点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCopyOrder_Click(object sender, EventArgs e)
        {
            this.CopyOrder();
        }

        #endregion

    }
}
