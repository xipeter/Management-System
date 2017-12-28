using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Finance.FinIpr
{
    public partial class ucFinIprInOutNum : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucFinIprInOutNum()
        {
            InitializeComponent();
        }

        string strOper = "全部";
        ArrayList alOper = new ArrayList();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        protected override void OnLoad(EventArgs e)
        {
            //人员
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "ALL";
            obj.Name = "全部";
            alOper.Add(obj);

            ArrayList list = new ArrayList();
            list = manager.QueryEmployeeAll();
            alOper.AddRange(list);

            cmbOper.AddItems(alOper);
            cmbOper.SelectedIndex = 0;

            base.OnLoad(e);
        }


        #region 查询
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(this.beginTime, this.endTime);
        }


        private void cmbOper_SelectedChanged(object sender, EventArgs e)
        {
            strOper = cmbOper.SelectedItem.ID;
            //this.dwMain.SetFilter("");
            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }
            if (strOper == "ALL")
            {
                dv.RowFilter = "";
                return;
            }
            dv.RowFilter = "oper_code = '" + strOper + "'";
            //.Filter();
            //if (strOper == "ALL")
            //{
            //    return;
            //}
            //this.dwMain.SetFilter("oper_code = '" + strOper + "'");
            //this.dwMain.Filter();
        }
        #endregion
    }
}