using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Case.Controls
{
    public partial class ucSubareaHandler : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseSubareaManager cbManager = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseSubareaManager();

        public ucSubareaHandler()
        {
            InitializeComponent();
        }

        private int SetSubarea()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager constant = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList alSubarea = constant.GetConstantList("CASE13");

            if (alSubarea.Count == 0 || alSubarea == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取分区失败"));
                return -1;
            }

            this.cbSubarea.AddItems(alSubarea);
            return 1;
        }

        private int SetNurseStation()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager department = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList alDepartment = department.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);

            if (alDepartment.Count == 0 || alDepartment == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取护理站失败"));
                return -1;
            }

            this.cbNurse.AddItems(alDepartment);
            return 1;
        }

        private void ucSubareaHandler_Load(object sender, EventArgs e)
        {
            this.SetSubarea();
            this.SetNurseStation();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject nurseObj = this.cbNurse.SelectedItem;
            Neusoft.FrameWork.Models.NeuObject subareaObj = this.cbSubarea.SelectedItem;
            Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea s = new Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea();
            s.SubArea.ID = subareaObj.ID;
            s.NurseStation.ID = nurseObj.ID;

            if (this.cbManager.IsExist(s))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("记录已经存在"));
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.cbManager.Connection);
            //trans.BeginTransaction();
            this.cbManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.cbManager.Insert(s) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败"));
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
