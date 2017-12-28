using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MetCas
{
    public partial class ucMetZyOpbDay_wh : Common.ucQueryBaseForDataWindow
    {
        public ucMetZyOpbDay_wh()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {           
            return base.OnRetrieve(dtpBeginTime.Value.Date);
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
            trans.DbParameter = "PBCatalogOwner='lchis'";

            trans.Connect();
            this.dwMain.SetTransaction(trans);
            try
            {
                this.dwMain.UpdateData(true);
            }
            catch (Exception e)
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

        private void dwMain_EditChanged(object sender, Sybase.DataWindow.EditChangedEventArgs e)
        {
            this.dwMain.AcceptText();
        }
    }
}
