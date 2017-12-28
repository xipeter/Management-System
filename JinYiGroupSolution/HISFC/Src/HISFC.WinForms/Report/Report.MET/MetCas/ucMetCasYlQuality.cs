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
    public partial class ucMetCasYlQuality : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasYlQuality()
        {
            InitializeComponent();

        }

        Neusoft.HISFC.BizLogic.Manager.Department deptManger = new Neusoft.HISFC.BizLogic.Manager.Department();
        
        private string deptId = string.Empty;
        private string deptName = string.Empty;
        ArrayList alDeptList = new ArrayList();

        protected override void OnLoad(EventArgs e)
        {
            Neusoft.HISFC.Models.Base.Department objAll = new Neusoft.HISFC.Models.Base.Department();
           

            objAll.ID = "ALL";
            objAll.Name = "全部";

            alDeptList.Add(objAll);

            ArrayList dept = new ArrayList();
            dept = deptManger.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            alDeptList.AddRange(dept);

            this.cboDeptCode.AddItems(alDeptList);
            this.cboDeptCode.SelectedIndex = 0;

            base.OnLoad(e);
        }
     


        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            
            deptId = ((Neusoft.HISFC.Models.Base.Department)alDeptList[this.cboDeptCode.SelectedIndex]).ID;
            deptName = ((Neusoft.HISFC.Models.Base.Department)alDeptList[this.cboDeptCode.SelectedIndex]).Name;

            base.OnRetrieve(base.beginTime, base.endTime,deptId);

            this.dwMain.Modify("t_dept.text = '"+deptName+"'");
      
            return 1;

        }
    }
}
