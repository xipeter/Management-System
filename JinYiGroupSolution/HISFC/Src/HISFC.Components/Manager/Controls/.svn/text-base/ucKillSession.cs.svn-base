using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucKillSession : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint
    {
        private Neusoft.HISFC.BizLogic.Manager.AllObjects manager;
        private readonly string description = "数据库死锁进程管理";
        private bool isShowButtons;
        private DataSet dsSessions;
        private DataView dvSessions;


        public ucKillSession()
        {
            this.manager = new Neusoft.HISFC.BizLogic.Manager.AllObjects();

            InitializeComponent();
        }

        #region IControlParamMaint 成员

        public int Apply()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string ErrText
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Init()
        {
            this.QueryLockSession();
            return 1;
        }

        public bool IsModify
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool IsShowOwnButtons
        {
            get
            {
                return false;
            }
            set
            {
                this.isShowButtons = value;
            }
        }

        public int Save()
        {
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));
            return 1;
        }

        #endregion

        #region 辅助函数

        private void QueryLockSession()
        {
            try
            {
                this.dsSessions = new DataSet();
                if ((this.dsSessions = this.manager.QueryLockSession()) == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.manager.Err));
                    return;
                }
                this.dvSessions = new DataView(this.dsSessions.Tables[0]);
                this.neuSpread1_Sheet1.DataSource = this.dvSessions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(ex.Message));
            }
        }

        #endregion

        private void miUnlock_Click(object sender, EventArgs e)
        {
            int RowCount = 0;
            if (neuSpread1_Sheet1.Rows.Count > 0)
            {
                RowCount = neuSpread1_Sheet1.Rows.Count;
                int ActiveRow = neuSpread1_Sheet1.ActiveRowIndex;
                
                string sid = neuSpread1_Sheet1.Cells[ActiveRow, 2].Text;
                
                string session = neuSpread1_Sheet1.Cells[ActiveRow, 3].Text;

                Neusoft.HISFC.BizLogic.Manager.AllObjects obj = new Neusoft.HISFC.BizLogic.Manager.AllObjects();

                //执行
                if (obj.AlterSessionState(sid, session) == -1)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("解锁失败"));
                }

                //执行成功  刷新
                this.QueryLockSession();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("解锁成功"));
            }
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            this.QueryLockSession();
        }

        private void tbSearchField_TextChanged(object sender, EventArgs e)
        {
            this.dvSessions.RowFilter = "sid like '" + this.tbSearchField.Text + "%' or serial like '" + this.tbSearchField.Text + "%'";
        }

    }
}
