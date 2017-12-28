using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucStoOutFate : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucStoOutFate()
        {
            InitializeComponent();
            this.GetItemzFunctionInfo();
            this.GetItemzFunctionInfo1();
        }

        private bool GetItemzFunctionInfo()
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient Manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            System.Collections.ArrayList alUsecodeList = new ArrayList();
            this.neuComboBox1.alItems.Clear();
            this.neuComboBox1.Items.Clear();
            string strSql = @"select  t.dept_code,t.dept_name,t.spell_code,t.wb_code from com_department t where dept_type IN('P','PI')";

            strSql = string.Format(strSql);
            DataSet ds = new DataSet();
            if (Manager.ExecQuery(strSql, ref ds) == -1)
            {
                return false;
            }
            if (ds == null || ds.Tables[0] == null)
            {
                MessageBox.Show("查询错误", "警告,用法加载错误！");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Spell obj = new Neusoft.HISFC.Models.Base.Spell();
                    obj.ID = ds.Tables[0].Rows[i][0].ToString();
                    obj.Name = ds.Tables[0].Rows[i][1].ToString();
                    obj.SpellCode = ds.Tables[0].Rows[i][2].ToString();
                    obj.WBCode = ds.Tables[0].Rows[i][3].ToString();
                    alUsecodeList.Add(obj);
                }
                int c = this.neuComboBox1.AddItems(alUsecodeList);

            }
            else
            {
                return false;
            }
            return true;
        }
        private bool GetItemzFunctionInfo1()
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient Manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            System.Collections.ArrayList alUsecodeList1 = new ArrayList();
            this.neuComboBox2.alItems.Clear();
            this.neuComboBox2.Items.Clear();
            string strSql = @"select  t.dept_code,t.dept_name,t.spell_code,t.wb_code from com_department t ";

            strSql = string.Format(strSql);
            DataSet ds = new DataSet();
            if (Manager.ExecQuery(strSql, ref ds) == -1)
            {
                return false;
            }
            if (ds == null || ds.Tables[0] == null)
            {
                MessageBox.Show("查询错误", "警告,用法加载错误！");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Spell obj = new Neusoft.HISFC.Models.Base.Spell();
                    obj.ID = ds.Tables[0].Rows[i][0].ToString();
                    obj.Name = ds.Tables[0].Rows[i][1].ToString();
                    obj.SpellCode = ds.Tables[0].Rows[i][2].ToString();
                    obj.WBCode = ds.Tables[0].Rows[i][3].ToString();
                    alUsecodeList1.Add(obj);
                }
                int c = this.neuComboBox2.AddItems(alUsecodeList1);

            }
            else
            {
                return false;
            }
            return true;
        }
        
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1 )
            {
                return -1;
            }
            return base.OnRetrieve(base.beginTime,base.endTime,neuComboBox1.Tag,neuComboBox2.Tag);
        }
       
    }
}

