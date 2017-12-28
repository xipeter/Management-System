using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.MET.MetCas
{
    public partial class ucMetCasInpatientreportVerify : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasInpatientreportVerify()
        {
            InitializeComponent();
        }

        string strDeptCode = "ALL";
        ArrayList alDept = new ArrayList();
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
             //设置时间范围

            DateTime now = deptManager.GetDateTimeFromSysDateTime();
           
            neuDateTimePicker1.Text = now.Date.ToString();
            
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

        protected override int OnRetrieve(params object[] objects)
        {

            //if (base.GetQueryTime() == -1)
            //{
            //    return -1;
            //}

            strDeptCode = cmbDept.SelectedItem.ID;

            return base.OnRetrieve(this.neuDateTimePicker1.Value.Date, strDeptCode);
        }



    }
}
