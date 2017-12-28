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
    public partial class ucFinIprOutpatientInfo :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIprOutpatientInfo()
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

            return base.OnRetrieve(this.beginTime,this.endTime);
          
        }
        #endregion 

        #region 过滤

        private void neuFilter_SelectedChanged(object sender, EventArgs e)
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
    }
}