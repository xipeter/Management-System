using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbBalPatient :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbBalPatient()
        {
            InitializeComponent();
        }
        string queryStr = string.Empty;
        string strOperCode = "ALL";
        //string strIsCallBack = "ALL";
        string transtype = null;
        string emp_code = null;
        ArrayList alBack = new ArrayList();
        ArrayList alOper = new ArrayList();
        Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
            //科室
            ArrayList list = new ArrayList();
        
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "ALL";
            obj.Name = "全部";
            alOper.Add(obj);
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "ALL";
            obj1.Name = "全部";
            alBack.Add(obj1);
            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            obj2.ID = "No";
            obj2.Name = "否";
            alBack.Add(obj2);
            Neusoft.FrameWork.Models.NeuObject obj3 = new Neusoft.FrameWork.Models.NeuObject();
            obj3.ID = "Yes";
            obj3.Name = "是";
            alBack.Add(obj3);
           
            list = person.GetEmployee("6101");
            alOper.AddRange(list);
            cmbOper.AddItems(alOper);
            isCallBack.AddItems(alBack);
            cmbOper.SelectedIndex = 0;
            isCallBack.SelectedIndex = 0;
            // base.OnLoad(e);
        }
        #endregion 
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            if(isCallBack.Tag.ToString()=="ALL")
            {
                this.transtype="ALL";
            }
            if(isCallBack.Tag.ToString()=="Yes")
            {
                this.transtype="2";
            }
            if(isCallBack.Tag.ToString()=="No")
            {
                this.transtype="1";
            }
            return base.OnRetrieve(base.beginTime, base.endTime,transtype,this.cmbOper.Tag.ToString());
        }


        //private void cmbOper_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    strOperCode = cmbOper.SelectedItem.ID;
        //    DataView dv = this.dwMain.Dv;
        //    if (dv == null)
        //    {
        //        return;
        //    }
        //    if (strOperCode == "ALL")
        //    {
        //        queryStr = "((1=1))";
        //    }
        //    else
        //    {
        //        queryStr = "((empl_code = '{0}'))";
        //    }

        //    dv.RowFilter = "";
        //    string str = string.Format(this.queryStr, strOperCode);
        //    try
        //    {
        //        dv.RowFilter = str;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("不许输入特殊字符，请输入正确的查询信息！");
        //        return;
        //    }
        //}

   

    }
}
