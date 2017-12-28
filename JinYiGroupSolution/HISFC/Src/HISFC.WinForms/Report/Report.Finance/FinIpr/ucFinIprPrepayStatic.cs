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
    public partial class ucFinIprPrepayStatic : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIprPrepayStatic()
        {
            InitializeComponent();
        }

        string strOper = "ALL";
        string strPID = string.Empty;
        ArrayList alOper = new ArrayList();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "ALL";
            obj.Name = "全部";
            alOper.Add(obj);

            ArrayList list = new ArrayList();
            //{E9BB1720-56E4-43ea-8DF5-01CA45B37A02} 修改人员控件只过滤收款员
            //list = manager.QueryEmployeeAll();
            list = manager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.F);
            alOper.AddRange(list);

            cmbOper.AddItems(alOper);
            cmbOper.SelectedIndex = 0;
            //foreach (Neusoft.HISFC.Models.Base.Employee emp in list)
            //{
            //    cmbOper.Items.Add(emp);
           
            //}
            cmbOper.SelectedIndex = 0;
            base.OnLoad(e);
        }
        #endregion 

        #region 查询
        protected override int OnRetrieve(params object[] objects)
        {
           // ArrayList allll = this.cmbOper.alItems;
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            string strOperName = string.Empty;
            string strInvo = string.Empty;
            string strCAMoney = string.Empty;
            decimal decCAMoney = 0;
            int rowcount = 0;
        
            strOper = cmbOper.SelectedItem.ID;
            strOperName = cmbOper.SelectedItem.Name;

            int intReturnNum = base.OnRetrieve(this.beginTime, this.endTime, strOper);
            rowcount = this.dwMain.RowCount;
            //操作员赋值
            dwMain.Modify("oper_text.text = '" + strOperName + "'");

            //现金
            decCAMoney = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.dwMain.GetItemString(1, "ca_text"));
            strCAMoney = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(decCAMoney);
      

            this.dwMain.Modify("money_text.text = '" + strCAMoney + "'");
           
            ////号码范围
            //if (rowcount > 0)
            //{   
            //    strInvo = this.dwMain.GetItemString(1, "发票号") + "~" + this.dwMain.GetItemString(rowcount, "发票号");

            //    this.dwMain.Modify("invoive_text.text = '" + strInvo + "'");
            //}
            return intReturnNum;
        }

        private void ntbPID_SelectTextChanged(object sender,EventArgs e)
        {
            strPID = this.ntbPID.Text.Trim();
            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            //this.dwMain.SetFilter("");
            //this.dwMain.Filter();
            dv.RowFilter = "";

            if (string.IsNullOrEmpty(strPID))
            {
                return;
            }
            //this.dwMain.SetFilter("住院号 like '%"+strPID+"'");
            //this.dwMain.Filter();
            try
            {
                dv.RowFilter = "住院号 like '%" + strPID + "'";
            }
            catch
            {
                MessageBox.Show("不许输入特殊字符，请输入正确的查询信息！");
                return;
            }
        }
        #endregion 
    }
}