using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.MET.MetCas
{
    public partial class ucMetCasStatDead2 :NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasStatDead2()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizLogic.Manager.Department deptManger = new Neusoft.HISFC.BizLogic.Manager.Department();
        System.Collections.ArrayList alDeptList = new ArrayList();
        private string patientNo = string.Empty;
        private string patientName = string.Empty;
        private string deptId = string.Empty;
        private string deptName = string.Empty;

         

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            if (string.IsNullOrEmpty(tbpatientNo.Text))
            {
                patientNo = "%%";
            }
            else
            {
                patientNo = "%" + tbpatientNo.Text.Trim() + "%";
                //patientNo = patientNo.PadLeft(10, '0');
                //this.tbpatientNo.Text = patientNo;
            }

            if (string.IsNullOrEmpty(tbpatientName.Text))
            {
                patientName = "%%";
            }
            else
            {
                patientName = "%" + tbpatientName.Text.Trim() + "%";
            }
            deptId = ((Neusoft.HISFC.Models.Base.Department)alDeptList[this.cboDeptCode.SelectedIndex]).ID;
            deptName = ((Neusoft.HISFC.Models.Base.Department)alDeptList[this.cboDeptCode.SelectedIndex]).Name;

              base.OnRetrieve(base.beginTime, base.endTime, patientNo, patientName, deptId);
              base.dwMain.CalculateGroups();
              //dwMain.CalculateGroups();
              return 1;
          
        }

        private void ucMetCasStatDead_Load(object sender, EventArgs e)
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

            DateTime currentDateTime = this.deptManger.GetDateTimeFromSysDateTime();
            this.dtpBeginTime.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 00, 00, 00);
            this.dtpEndTime.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 23, 59, 59);
           
        }

       

        /// <summary>
        /// 打印方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {

                this.dwMain.Print();
                return 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错", "提示");
                return -1;
            }

        }
    }
}
