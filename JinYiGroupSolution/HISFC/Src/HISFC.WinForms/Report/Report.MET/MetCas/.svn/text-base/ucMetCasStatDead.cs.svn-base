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
    public partial class ucMetCasStatDead :NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasStatDead()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizLogic.Manager.Department deptManger = new Neusoft.HISFC.BizLogic.Manager.Department();
        System.Collections.ArrayList alDeptList = null;
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

             return base.OnRetrieve(base.beginTime, base.endTime, patientNo, patientName, deptId);
          
        }

        private void ucMetCasStatDead_Load(object sender, EventArgs e)
        {


            Neusoft.HISFC.Models.Base.Department objAll = new Neusoft.HISFC.Models.Base.Department();

            objAll.ID = "ALL";
            objAll.Name = "全部";

            alDeptList = deptManger.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            //foreach (Neusoft.HISFC.Models.Base.Department dept in alDeptList)
            //{
            //    cboDeptCode.Items.Add(dept);
            //    //deptId = dept.ID;
            //    //deptName = dept.Name;
            //}
            ////填充数据  
            ////this.cboDeptCode.AddItems(alDeptList);

            //foreach (Neusoft.HISFC.Models.Base.Department dept in alDeptList)
            //{                
            //    deptId = dept.ID;
            //    deptName = dept.Name;
            //}
            //填充数据  
            alDeptList.Add(objAll);
            this.cboDeptCode.AddItems(alDeptList);
            cboDeptCode.SelectedIndex = alDeptList.Count-1;
            DateTime currentDateTime = this.deptManger.GetDateTimeFromSysDateTime();
            this.dtpBeginTime.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 00, 00, 00);
            this.dtpEndTime.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 23, 59, 59);
           
        }

        private void cboDeptCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptId = ((Neusoft.HISFC.Models.Base.Department)alDeptList[this.cboDeptCode.SelectedIndex]).ID;
            deptName = ((Neusoft.HISFC.Models.Base.Department)alDeptList[this.cboDeptCode.SelectedIndex]).Name;
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
