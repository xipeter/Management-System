using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WorkStation.Forms
{
    /// <summary>
    /// 选择护士站控件
    /// </summary>
    public partial class frmSelectNurseCell : Neusoft.NFC.Interface.Forms.BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public frmSelectNurseCell()
        {
            InitializeComponent();
        }

        #region 变量

        private Neusoft.HISFC.Integrate.Manager deptManager = new Neusoft.HISFC.Integrate.Manager();

        private Neusoft.NFC.Object.NeuObject nurseStation = new Neusoft.NFC.Object.NeuObject();

        #endregion

        #region 属性

        public Neusoft.NFC.Object.NeuObject NurseStation
        {
            get
            {
                return this.nurseStation;
            }
            set
            {
                this.nurseStation = value;
            }
        }

        #endregion

        private void frmSelectNurseCell_Load(object sender, EventArgs e)
        {
            ArrayList alNurseCell = new ArrayList();
            
            alNurseCell = this.deptManager.GetDepartment(Neusoft.HISFC.Object.Base.EnumDepartmentType.N);
            this.lvNurseCell.Items.Clear();
            foreach (Neusoft.NFC.Object.NeuObject nurseCell in alNurseCell)
            {
                ListViewItem item = new ListViewItem(nurseCell.Name, 0);
                item.Text = nurseCell.Name;
                item.ImageIndex = 0;
                item.Tag = nurseCell;
                this.lvNurseCell.Items.Add(item);
            }
            this.lvNurseCell.Items[0].Selected = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.nurseStation = this.lvNurseCell.SelectedItems[0].Tag as Neusoft.NFC.Object.NeuObject;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCaccel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lvNurseCell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnOK_Click(null, null);

            }
            if (e.KeyCode == Keys.Up)
            {
                if (lvNurseCell.SelectedIndices[0] == 0)
                {
                    lvNurseCell.Items[lvNurseCell.Items.Count - 1].Selected = true;
                    lvNurseCell.Items[lvNurseCell.Items.Count - 1].Focused = true;
                    lvNurseCell.Items[lvNurseCell.Items.Count - 1].EnsureVisible();
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lvNurseCell.SelectedIndices[0] == lvNurseCell.Items.Count - 1)
                {
                    lvNurseCell.Items[0].Selected = true;
                    lvNurseCell.Items[0].Focused = true;
                    lvNurseCell.Items[0].EnsureVisible();
                    e.Handled = true;
                }
            }
        }

        private void lvNurseCell_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }


    }
}