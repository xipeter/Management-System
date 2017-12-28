using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.FinIpr
{
    public partial class ucFinIpbQuerypateintJs : Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbQuerypateintJs()
        {
            InitializeComponent();
        }

        private string pactCode = string.Empty;
        private string pactName = string.Empty;
        System.Collections.ArrayList alpaykindConstantList = null;
        protected override void OnLoad()
        {
            this.Init();

            base.OnLoad();
            //设置时间范围
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpBeginTime.Value = dt;

            //填充数据
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            alpaykindConstantList = manager.QueryPactUnitAll();
            Neusoft.HISFC.Models.Base.Pact alpact = new Neusoft.HISFC.Models.Base.Pact();
            alpact.ID = "ALL";
            alpact.Name = "全部";
            alpact.SpellCode = "QB";
            alpaykindConstantList.Insert(0, alpact);
            this.neuComboBox1.AddItems(alpaykindConstantList);
            neuComboBox1.SelectedIndex = 0;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索数据请稍候......");

                //Application.DoEvents();

                this.dwMain.Modify("time.text='统计时间：" + this.beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                return this.dwMain.Retrieve(this.beginTime, this.endTime, pactCode);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                this.dwMain.Print();
            }
            catch (Exception ex)
            {
                return 1;
            }

            return 1;
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox1.SelectedIndex >= 0)
            {
                pactCode = ((Neusoft.HISFC.Models.Base.Pact)alpaykindConstantList[this.neuComboBox1.SelectedIndex]).ID.ToString();
                pactName = ((Neusoft.HISFC.Models.Base.Pact)alpaykindConstantList[this.neuComboBox1.SelectedIndex]).Name.ToString();
            }
        }

        private string queryStr = "((name like '{0}%') or (wb_name like '{0}%') or (spell_name like '{0}%')) and ((op_name like '{1}%') or (op_wb_name like '{1}%') or (op_spell_name like '{1}%'))";

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string hz = this.neuTextBox1.Text.Trim().ToUpper().Replace(@"\", "");
            string op = this.neuTextBox2.Text.Trim().ToUpper().Replace(@"\", "");


            if (hz.Equals("") && op.Equals(""))
            {
                this.dwMain.SetFilter("");
                this.dwMain.Filter();
                return;
            }

            string str = string.Format(this.queryStr, hz, op);
            this.dwMain.SetFilter(str);
            this.dwMain.Filter();
        }

    }
}
