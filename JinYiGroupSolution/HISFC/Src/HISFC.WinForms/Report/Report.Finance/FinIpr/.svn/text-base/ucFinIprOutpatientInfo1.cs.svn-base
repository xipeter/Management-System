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
    public partial class ucFinIprOutpatientInfo1 :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIprOutpatientInfo1()
        {
            InitializeComponent();
        }

        string queryStr = string.Empty;
        string strDeptCode = "ALL";
        string strPatientID = string.Empty;
        ArrayList alDept = new ArrayList();
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                DateTime now = deptManager.GetDateTimeFromSysDateTime();
                //this.dtpBeginTime.Value = now;
                this.dtpBeginTime.Value = new DateTime(now.Year,now.Month,now.Day,0,0,0);
                this.dtpEndTime.Value = new DateTime(now.Year,now.Month,now.Day,23,59,59);
            }
            
            //科室
            ArrayList list = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "ALL";
            obj.Name = "全部";
            alDept.Add(obj);

            list = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            alDept.AddRange(list);
            cmbDept.AddItems(alDept);
            cmbDept.SelectedIndex = 0;
            this.isSort = true;
            

           // base.OnLoad(e);
        }
        #endregion 

        #region 查询
        protected override int OnRetrieve(params object[] objects)
        {

            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            base.OnRetrieve(this.beginTime,this.endTime);
            Query();

            return 1;
          
        }
        #endregion 

        #region 过滤

        //private void neuFilter_SelectedChanged(object sender, EventArgs e)
        //{
        //    Query();

        //}

        //private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Query();

        //}

        private void ntbPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            //Query();
        }


        private void Query()
        {
            strDeptCode = cmbDept.SelectedItem.ID;
            strPatientID = ntbPatientID.Text.Trim().ToUpper().Replace(@"\", "");
            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            if (strDeptCode == "ALL")
            {
                queryStr = "住院号 like '%{1}'";

            }
            else
            {
                queryStr = "((dept_code = '{0}')) and ((住院号 like '%{1}') )";
            }

            //this.dwMain.SetFilter("");
            //this.dwMain.Filter();
            dv.RowFilter = "";

            string str = string.Format(this.queryStr, strDeptCode, strPatientID);
            //this.dwMain.SetFilter(str);
            //this.dwMain.Filter();
            try
            {
                dv.RowFilter = str;
            }
            catch
            {
                MessageBox.Show("不许输入特殊字符，请输入正确的查询信息！");
                return;
            }
        }


     

      

        #endregion 

        private void cmbDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Query();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //char enter = (char)13;
            //if (e.KeyChar == enter || this.cmbDept.Focus())
            //{
            //    this.OnQuery(null, null);
            //}
            //base.OnKeyPress(e);
        }



        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.cmbDept.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    //string pNO = this.lblTxtPatientNO.Text.PadLeft(10, '0');
                    //this.lblTxtPatientNO.Text = pNO.ToString();
                    this.OnQuery(null, null);
                }
            }
            return base.ProcessDialogKey(keyData);
        }

      
    }
}