using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Logistics.DrugStore
{
    public partial class ucStoDrugInputAcc : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucStoDrugInputAcc()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;    
       
        ArrayList alDept = new ArrayList();
        
        string deptId = "全院";
        string deptName = "全院";
         protected override void OnLoad(EventArgs e)
        {
            
           //药房名称
            ArrayList list = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

            obj.ID = "全院";
            obj.Name = "全院";
            alDept.Add(obj);

            list = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
            alDept.AddRange(list);

            cmbDeptName.AddItems(alDept);
            cmbDeptName.SelectedIndex = 0;

            base.OnLoad(e);
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
           
            deptId = cmbDeptName.SelectedItem.ID;
            deptName = cmbDeptName.SelectedItem.Name;
            int  RetrieveRow = base.OnRetrieve(this.beginTime, this.endTime, deptId, empl.Name);

           int rownum = dwMain.RowCount;

           for (int i = 1; i <= rownum; i++)
            {
                dwMain.SetItemString(i, "验收员", empl.Name);
            }

                dwMain.Modify("dept_name.text = '" + deptName + "'");
            return 1;
           
        }

    }
}
