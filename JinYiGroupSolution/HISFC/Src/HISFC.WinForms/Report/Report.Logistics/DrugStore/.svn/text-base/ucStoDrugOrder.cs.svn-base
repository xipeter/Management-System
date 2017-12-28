using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucStoDrugOrder : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucStoDrugOrder()
        {
            InitializeComponent();
        }

        ArrayList alDrugQuality = new ArrayList();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        DeptZone deptZone1 = DeptZone.ALL;

        #region 枚举
        public enum DeptZone
        {
            MZ = 0,
            ZY = 1,
            ALL = 2,
        }
        #endregion

        #region 属性
        [Category("控制设置"),Description("查询范围：ALL：全院、MZ：门诊、ZY：住院") ]
        public DeptZone DeptZone1
        {
            get 
            {
                return deptZone1;
            }
            set
            {
                deptZone1 = value;
            }
        }
        #endregion 

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //药品性质
            
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "ALL";
            obj.Name = "全部";
            alDrugQuality.Add(obj);

            ArrayList list = manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
            alDrugQuality.AddRange(list);

            cmbDrugq.AddItems(alDrugQuality);
            cmbDrugq.SelectedIndex = 0;

            //部门
            cmbDept.ClearItems();

            if (deptZone1 == DeptZone.ALL)
            {
                cmbDept.Items.Add("全院");
                cmbDept.Items.Add("门诊");
                cmbDept.Items.Add("住院");

            }
            if (deptZone1 == DeptZone.MZ)
            {
                cmbDept.Items.Add("门诊");
                cmbDept.Enabled = false;
            }
            if (deptZone1 == DeptZone.ZY)
            {
                cmbDept.Items.Add("住院");
                cmbDept.Enabled = false;
            }

            cmbDept.SelectedIndex = 0;

            //查询类别
            cmbType.Items.Add("按金额查询");
            cmbType.Items.Add("按数量查询");
            cmbType.SelectedIndex = 0;
        }
        #endregion 


        #region 查询
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            string strDrugq;
            string strDept = "全院";
            List<string> alType = new List<string>();

            //选择查询类别
            if (cmbType.Items[cmbType.SelectedIndex].ToString() == "按金额查询")
            {
                this.mainDWDataObject = "d_sto_drugorder";
                dwMain.DataWindowObject = "d_sto_drugorder";
            }
            if (cmbType.Items[cmbType.SelectedIndex].ToString() == "按数量查询")
            {
                this.mainDWDataObject = "d_sto_drugnumorder";
                dwMain.DataWindowObject = "d_sto_drugnumorder";
            }

            //取查询类型：全院、门诊or住院
            if (!string.IsNullOrEmpty(cmbDept.Items[cmbDept.SelectedIndex].ToString()))
            {
                strDept = cmbDept.Items[cmbDept.SelectedIndex].ToString();
            }


            if (strDept == "全院")
            {
                //alType[0] = "M1";
                //alType[1] = "M2";
                //alType[2] = "Z1";
                //alType[3] = "Z2";
                alType.Add("M1");
                alType.Add("M2");
                alType.Add("Z1");
                alType.Add("Z2");


            }
            if (strDept == "门诊")
            {
                alType.Add("M1");
                alType.Add("M2");
            }
            if (strDept == "住院")
            {
                alType.Add("Z1");
                alType.Add("Z2");

            }

            //取药品性质
            strDrugq = cmbDrugq.SelectedItem.ID;

            // 门诊、住院or 全院
            string[] strValue = new string[alType.Count];
            for (int i = 0; i < alType.Count; i++)
            {
                strValue[i] = alType[i];
            }



            return base.OnRetrieve(this.beginTime, this.endTime, strDrugq, strValue);
        }

        #endregion
        


        #region 过滤

        private void ntbDrugOrder_SelectedChanged(object sender,EventArgs e)
        {
           int drugOrder ;

           try
           {
               drugOrder =  int.Parse(ntbDrugOrder.Text);
           }
           catch (Exception e1)
           {
               //if ( drugOrder == 0)
               //{
               //    dwMain.SetFilter("" );
               //    dwMain.Filter();
               //    dwMain.SetSort("排名");
               //    dwMain.Sort();
               //    return;
               //}
               //else
               //{
                   MessageBox.Show("请输入数字");
                   return;
               //}
           }

           dwMain.SetFilter("排名 <=" + drugOrder);
           dwMain.Filter();

           dwMain.SetSort("排名");
           dwMain.Sort();
        }

        #endregion 

       


    }
}