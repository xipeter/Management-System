using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.MetCas
{
    public partial class ucMetZyOpbList_wh : Common.ucQueryBaseForDataWindow
    {
        public ucMetZyOpbList_wh()
        {
            InitializeComponent();
            base.LeftControl = QueryControls.Tree;
        }
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager myDepartmentStatManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();

        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            ArrayList deptList = this.myDepartmentStatManager.LoadDepartmentStatAndByNodeKind("72", "1");

            TreeNode parentTreeNode = new TreeNode("全部");
            parentTreeNode.Tag = "ALL";
            parentTreeNode.Text = "全院";
            tvLeft.Nodes.Add(parentTreeNode);
            foreach (Neusoft.HISFC.Models.Base.DepartmentStat dept in deptList)
            {
                TreeNode deptNode = new TreeNode();
                deptNode.Tag = dept.ID;
                deptNode.Text = dept.Name;
                parentTreeNode.Nodes.Add(deptNode);
            }
            parentTreeNode.ExpandAll();

            return base.OnDrawTree();
                        
        }

        public void update()
        {
            Sybase.DataWindow.Transaction trans = new Sybase.DataWindow.Transaction();
            System.Data.OracleClient.OracleConnectionStringBuilder ocs =
            new System.Data.OracleClient.OracleConnectionStringBuilder(Neusoft.FrameWork.Management.Connection.Instance.ConnectionString);
            trans.Password = ocs.Password;
            trans.ServerName = ocs.DataSource;
            trans.UserId = ocs.UserID;

            trans.Dbms = Sybase.DataWindow.DbmsType.Oracle8i;


            trans.AutoCommit = false;
            trans.DbParameter = "PBCatalogOwner='lchis19'";

            trans.Connect();
            this.dwMain.SetTransaction(trans);
            try
            {
                this.dwMain.UpdateData(true);
            }
            catch(Exception e)
            {
                trans.Rollback();
                MessageBox.Show("保存失败！" + e.Message);
                return;
            }
            trans.Commit();
            MessageBox.Show("保存成功！");
        }
        protected override int OnSave(object sender, object neuObject)
        {
            this.update();

            return base.OnSave(sender, neuObject);
        }


        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            TreeNode selectNode = tvLeft.SelectedNode;

            if (selectNode.Tag == "ALL")
            {
                MessageBox.Show("请选择具体科室!");
                return -1;
            }
            
            string deptCode = selectNode.Tag.ToString();
            string deptName = selectNode.Text.ToString();

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptCode, deptName);
        }

        private void ucMetZyOpbList_wh_Load(object sender, EventArgs e)
        {
             DateTime sysTime = this.myDepartmentStatManager.GetDateTimeFromSysDateTime();
            this.dtpBeginTime.Text = sysTime.AddDays(-1).ToShortDateString() + " 00:00:00";
            this.dtpEndTime.Text = sysTime.ToShortDateString() + " 00:00:00";
        }

        private void dwMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
               
               // SendKeys.Send("{TAB}");
               // return;
            }
        }

        private void dwMain_EditChanged(object sender, Sybase.DataWindow.EditChangedEventArgs e)
        {
            this.dwMain.AcceptText();
        }

        //private void ucMetOpbList_Click(object sender, EventArgs e)
        //{
        //    DateTime sysTime = this.myDepartmentStatManager.GetDateTimeFromSysDateTime();

        //    this.dtpBeginTime.Text = sysTime.AddDays(-1).ToShortDateString() + " 00:00:00";
        //    this.dtpEndTime.Text = sysTime.ToShortDateString() + " 00:00:00";
        //}

    }
    }

