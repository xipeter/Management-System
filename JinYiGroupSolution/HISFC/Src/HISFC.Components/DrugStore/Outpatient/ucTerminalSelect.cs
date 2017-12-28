using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Outpatient
{
    /// <summary>
    /// [功能描述: 终端选择控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// </summary>
    public partial class ucTerminalSelect : UserControl
    {
        public ucTerminalSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 操作结果
        /// </summary>
        DialogResult result = DialogResult.Cancel;

        /// <summary>
        /// 操作结果
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }

        /// <summary>
        /// 列表初始化
        /// </summary>
        public void InitList()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

            ArrayList alTermianalList = drugStoreManager.QueryDrugTerminalByTerminalType("0");
            if (alTermianalList == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载所有终端列表发生错误") + drugStoreManager.Err);
                return;
            }

            this.tvList.ImageList = this.tvList.groupImageList;

            string privDeptCode = "";
            TreeNode deptNode = null;
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugTerminal info in alTermianalList)
            {
                if (privDeptCode != info.Dept.ID)
                {
                    Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDeptmentById(info.Dept.ID);
                    if (dept == null)
                    {
                        continue;
                    }
                    info.Dept = dept;

                    deptNode = new TreeNode(dept.Name);                    
                    deptNode.ImageIndex = 0;
                    deptNode.SelectedImageIndex = 0;
                    deptNode.Tag = null;

                    privDeptCode = info.Dept.ID;

                    this.tvList.Nodes.Add(deptNode);
                }

                TreeNode terminalNode = new TreeNode(info.Name);
                terminalNode.ImageIndex = 1;
                terminalNode.SelectedImageIndex = 1;
                terminalNode.Tag = info;

                deptNode.Nodes.Add(terminalNode);
            }
        }

        public List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal> GetTerminalList()
        {
            List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal> terminalList = new List<Neusoft.HISFC.Models.Pharmacy.DrugTerminal>();
            foreach (TreeNode deptNode in this.tvList.Nodes)
            {
                if (deptNode.Nodes.Count > 0)
                {
                    foreach (TreeNode terminalNode in deptNode.Nodes)
                    {
                        if (terminalNode.Checked)
                        {
                            terminalList.Add(terminalNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal);
                        }
                    }
                }
            }

            return terminalList;
        }

        public virtual void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.GetTerminalList();

            this.result = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.Cancel;

            this.Close();
        }

        private void ucTerminalSelect_Load(object sender, EventArgs e)
        {
            this.InitList();

            this.tvList.AfterCheck += new TreeViewEventHandler(tvList_AfterCheck);
        }

        void tvList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }
    }
}
