using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 历史医嘱查询]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人='Dorian'
    ///		修改时间='2008-01'
    ///		修改目的='根据肿瘤医院的修改情况整合'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucOrderHistory : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucOrderHistory()
        {
            InitializeComponent();
            this.treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            //{7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}
            this.fpSpread1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fpSpread1_MouseUp);
        }

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null) return;
                Neusoft.FrameWork.Models.NeuObject obj = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;
                ArrayList al = orderManager.QueryOrder(obj.ID);
                Neusoft.HISFC.Components.Common.Classes.Function.ShowOrder(this.fpSpread1_Sheet1, al, Neusoft.HISFC.Models.Base.ServiceTypes.I);
                #region {EE6864E5-796D-4b21-B9C4-ABD40F5CF9A5}
                for (int i = 0; i < this.fpSpread1_Sheet1.Columns.Count; i++)
                {
                    this.fpSpread1_Sheet1.Columns[i].Locked = true;
                }
                #endregion

            }
            catch { }
        }
        Neusoft.HISFC.BizProcess.Integrate.RADT manager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();
        //{3EC00FCD-64D6-49ea-8A23-CB2B0CAB9A53}
        //是否显示住院号输入框
        private bool isShowPatientControl = false;

        /// <summary>
        /// 是否显示住院号输入框
        /// </summary>
        [Category("控件设置"),Description("是否显示住院号输入框"),DefaultValue(false)]
        public bool IsShowPatientControl
        {
            get { return isShowPatientControl; }
            set { this.isShowPatientControl = value; }
        }


        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.Patient = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            return 0;
        }

        protected Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            set
            {
                if (value == null) return;
                //{3EC00FCD-64D6-49ea-8A23-CB2B0CAB9A53}
                this.txtPatientNO.Text = value.PID.PatientNO;
                ArrayList al = manager.QueryInpatientNoByPatientNo(value.PID.PatientNO);
                if (al == null)
                {
                    MessageBox.Show("获取患者信息出错", manager.Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.treeView1.Nodes[0].Nodes.Clear();
                    if (this.fpSpread1_Sheet1.Rows.Count > 0)
                    {
                        this.fpSpread1_Sheet1.RemoveRows(0, this.fpSpread1_Sheet1.RowCount);
                    }

                    return;
                }
                if (al.Count == 0)
                {
                    this.treeView1.Nodes[0].Nodes.Clear();
                    if (this.fpSpread1_Sheet1.Rows.Count > 0)
                    {
                        this.fpSpread1_Sheet1.RemoveRows(0, this.fpSpread1_Sheet1.RowCount);
                    }
                    return;
                }

                this.treeView1.Nodes[0].Nodes.Clear();
                #region {1705F464-D530-47e8-A675-761A10CA8E52}
                if (this.fpSpread1_Sheet1.Rows.Count > 0)
                {
                    this.fpSpread1_Sheet1.RemoveRows(0, this.fpSpread1_Sheet1.RowCount);
                }
                #endregion
                foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
                {
                    //{3EC00FCD-64D6-49ea-8A23-CB2B0CAB9A53}
                    string no = obj.ID;
                    Neusoft.HISFC.Models.RADT.PatientInfo p = manager.GetPatientInfomation(obj.ID);
                    if (p == null)
                    {
                        MessageBox.Show("查询患者信息出错" + manager.Err);
                        return;
                    }
                    if (p.PVisit.InState.ID.ToString() == "I")
                    {
                        continue;
                    }
                    if (obj.ID != value.ID)
                    {
                        try
                        {
                            no = obj.ID.Substring(2, 2);
                        }
                        catch { }
                        TreeNode node = new TreeNode("[" + no + "]" + obj.Name);
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 2;
                        node.Tag = obj;
                        this.treeView1.Nodes[0].Nodes.Add(node);
                    }
                }
            }
        }

        //{3EC00FCD-64D6-49ea-8A23-CB2B0CAB9A53}
        private void txtPatientNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            if (string.IsNullOrEmpty(this.txtPatientNO.Text.Trim()))
            {
                return;
            }

            Neusoft.HISFC.Models.RADT.PatientInfo p = new Neusoft.HISFC.Models.RADT.PatientInfo();

            

            this.txtPatientNO.Text = this.txtPatientNO.Text.Trim().PadLeft(10, '0');
            p.PID.PatientNO = this.txtPatientNO.Text;

            this.Patient = p;
        }
        //{3EC00FCD-64D6-49ea-8A23-CB2B0CAB9A53}
        protected override void OnLoad(EventArgs e)
        {
            this.txtPatientNO.Visible = this.isShowPatientControl;
            base.OnLoad(e);
        }

        #region 复制粘贴{7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}

        /// <summary>
        /// 右键菜单
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip contextMenu1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();


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
            string type = "2";
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
