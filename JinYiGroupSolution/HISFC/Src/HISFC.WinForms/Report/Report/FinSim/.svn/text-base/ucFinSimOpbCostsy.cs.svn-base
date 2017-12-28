using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.FinSim
{
    public partial class ucFinSimOpbCostsy : Common.ucQueryBaseForDataWindow
    {
        public ucFinSimOpbCostsy()
        {
            InitializeComponent();
        }
       protected override void  OnLoad()
        {
                    this.Init();

                    this.InitCombox();

 	                base.OnLoad();
        }

             /// <summary>
             /// 用于判断报表中的市保类型（城镇职工和城镇居民）
             /// </summary>
             private void InitCombox()
             {
                 ArrayList al = new ArrayList();

                 ///加关于是否包含中途结算数据的判断
                 Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                 obj.ID = "城镇职工";
                 obj.Name = "城镇职工";
                 al.Add(obj);

                 obj = new Neusoft.FrameWork.Models.NeuObject();
                 obj.ID = "城镇居民";
                 obj.Name = "城镇居民";
                 al.Add(obj);

                 obj = new Neusoft.FrameWork.Models.NeuObject();
                 obj.ID = "农民工人员";
                 obj.Name = "农民工人员";
                 al.Add(obj);

                 obj = new Neusoft.FrameWork.Models.NeuObject();
                 obj.ID = "所有患者";
                 obj.Name = "所有患者";
                 al.Add(obj);

                 this.neuComboBox1.AddItems(al);

             }

        protected override int OnRetrieve(params object[] objects)
        {


            string idsim = this.neuComboBox1.Tag.ToString();

            dwMain.Retrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,idsim);
            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,idsim);
        }

        //这个是下拉列表选择改变事件(判断报表中的市保类型(城镇职工和城镇居民))
        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnRetrieve();
        }
    }
}
