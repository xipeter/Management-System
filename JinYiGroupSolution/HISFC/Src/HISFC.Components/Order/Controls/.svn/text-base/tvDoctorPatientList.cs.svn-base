using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医生站患者列表]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class tvDoctorPatientList:Neusoft.HISFC.Components.Common.Controls.tvPatientList
    {
        public tvDoctorPatientList()
        {
            if (DesignMode) return;
            //if (Neusoft.FrameWork.Management.Connection.Instance == null) return;
            #region {5646474F-BA9A-4fdb-B580-085C4EB757EB}
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
            {
                return;
            }
            #endregion
            try
            {
                this.ShowType = enuShowType.Bed;
                this.Direction = enuShowDirection.Ahead;
                this.RefreshInfo();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        Neusoft.HISFC.BizProcess.Integrate.RADT manager = null;

        //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct medicalTeamForDoctBizlogic = null;

        public  void RefreshInfo()
        {
            this.Nodes.Clear();
            if (manager == null)
                manager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Base.Employee per = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            //节点说明
            al.Add("分管患者|patient");
            try
            {
                ArrayList al1 = new ArrayList();

                al1 = this.manager.QueryPatientByHouseDoc(per, Neusoft.HISFC.Models.Base.EnumInState.I, per.Dept.ID);
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo1 in al1)
                {
                    al.Add(PatientInfo1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找分管患者出错\n！" + ex.Message + this.manager.Err);

            }

            al.Add("本科室患者|DeptPatient");
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.I);

            al.Add("会诊患者|ConsultationPatient");

            try
            {
                ArrayList al1 = new ArrayList();
                Neusoft.FrameWork.Management.DataBaseManger dbManager = new Neusoft.FrameWork.Management.DataBaseManger();
                DateTime dt = dbManager.GetDateTimeFromSysDateTime();
                DateTime dt1 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                DateTime dt2 = new DateTime(dt.Year, dt.AddDays(1).Month, dt.AddDays(1).Day, 0, 0, 0, 0);
                al1 = this.manager.QueryPatientByConsultation(dbManager.Operator, dt1, dt2, per.Dept.ID);
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo1 in al1)
                {
                    al.Add(PatientInfo1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找会诊患者出错\n！" + ex.Message + this.manager.Err);
            }

            al.Add("授权患者|PermissionPatient");

            try
            {
                ArrayList al1 = new ArrayList();
                al1 = this.manager.QueryPatientByPermission(Neusoft.FrameWork.Management.Connection.Operator);
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo1 in al1)
                {
                    al.Add(PatientInfo1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找授权患者出错\n！" + ex.Message + this.manager.Err);
            }

            try
            {
                al.Add("查找患者|QueryPatient");
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找患者出错\n！" + ex.Message + this.manager.Err);
            }
            //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
            al.Add("医疗组内患者|TeamPatient");

            if (this.medicalTeamForDoctBizlogic == null)
            {
                this.medicalTeamForDoctBizlogic = new Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct();
            }


            List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> medicalTeamForDoctList =
                this.medicalTeamForDoctBizlogic.QueryQueryMedicalTeamForDoctInfo(per.Dept.ID, per.ID);
            if (medicalTeamForDoctList == null)
            {
                MessageBox.Show("查询医疗组失败!\n" + this.medicalTeamForDoctBizlogic.Err );
            }
             
            if (medicalTeamForDoctList.Count > 0)
            {
                Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medcialObj = medicalTeamForDoctList[0];

                addPatientListMedialTeam(al, Neusoft.HISFC.Models.Base.EnumInState.I, medcialObj.MedcicalTeam.ID);


            }

            this.SetPatient(al);

        }

        /// <summary>
        /// 根据医生工作站得到患者
        /// </summary>
        /// <param name="al"></param>
        private void addPatientList(ArrayList al, Neusoft.HISFC.Models.Base.EnumInState Status)
        {
            ArrayList al1 = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Base.Employee per = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                al1 = this.manager.QueryPatient(per.Dept.ID,Status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找科室患者出错\n！" + ex.Message + this.manager.Err);
            }
            //foreach (Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo1 in al1)
            //{
            //    al.Add(PatientInfo1);
            //}
            al.AddRange(al1);
        }

        //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        private void addPatientListMedialTeam(ArrayList al, Neusoft.HISFC.Models.Base.EnumInState Status,string medcialTeamCode)
        {
            ArrayList al1 = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Base.Employee per = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                al1 = this.manager.PatientQueryByMedicalTeam(medcialTeamCode, Status,per.Dept.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查找科室患者出错\n！" + ex.Message + this.manager.Err);
            }
            //foreach (Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo1 in al1)
            //{
            //    al.Add(PatientInfo1);
            //}
            al.AddRange(al1);
        }

        #region addby xuewj 2009-8-24 添加患者查询功能，根据权限控制是否能查看全院患者 {8B4B8C49-2181-4aeb-95D4-DADFDE26DBC2}

        /// <summary>
        /// 根据住院流水号查询患者信息
        /// </summary>
        /// <param name="patientInfo"></param>
        public void QueryPaitent(string inpatientNO, Neusoft.HISFC.Models.Base.Employee empl)
        {
            if (inpatientNO == "")
            {
                return;
            }

            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.manager.QueryPatientInfoByInpatientNO(inpatientNO);

            if (patientInfo == null)
            {
                MessageBox.Show("查询患者基本信息失败!");
                return;
            }

            int returnValue=this.PreArrange(empl);

            int branch = -1;
            branch = GetBrach("QueryPatient");

            if (returnValue == -1)
            {
                //只能查看本科出院患者
                if (patientInfo.PVisit.PatientLocation.Dept.ID == empl.Dept.ID)
                //&& (patientInfo.PVisit.InState.ID.ToString() == "P"
                //|| patientInfo.PVisit.InState.ID.ToString() == "D"
                //|| patientInfo.PVisit.InState.ID.ToString() == "T"))
                {
                    this.Nodes[branch].Nodes.Clear();
                    this.AddTreeNode(branch, patientInfo);
                    this.SelectedNode = this.Nodes[branch].Nodes[0];
                }
                else
                {
                    MessageBox.Show("您没有权限查看其他科室的患者医嘱");
                }
            }
            else
            {
                this.Nodes[branch].Nodes.Clear();
                this.AddTreeNode(branch, patientInfo);
                this.SelectedNode = this.Nodes[branch].Nodes[0];
            }
        }

        /// <summary>
        /// 权限判断
        /// </summary>
        /// <returns></returns>
        private int PreArrange(Neusoft.HISFC.Models.Base.Employee empl)
        {
            if(Neusoft.HISFC.Components.Common.Classes.Function.ChoosePiv("0001")==false)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// get selectedNode's index
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public int GetBrach(string tag)
        {
            int branch = -1;
            foreach (TreeNode treeNode in this.Nodes)
            {
                if (treeNode.Tag != null && treeNode.Tag.ToString() == tag)
                {
                    branch = treeNode.Index;
                    break;
                }
            }
            return branch;
        }

        #endregion

    }
}
