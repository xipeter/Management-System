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
    public partial class ucStoOutTypeandModle : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucStoOutTypeandModle()
        {
            InitializeComponent();
            this.myInit();
            this.GetItemzFunctionInfo();
            this.GetItemzFunctionInfo1();
        }

        private void myInit()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList alItemType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            if (alItemType == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取药品类型名称发生错误!") + consManager.Err);
                return;
            }
            this.cmbType.AddItems(alItemType);

        }
        private bool GetItemzFunctionInfo()
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient Manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            System.Collections.ArrayList alUsecodeList = new ArrayList();
            this.neuComboBox1.alItems.Clear();
            this.neuComboBox1.Items.Clear();
            string strSql = @"select code,name,spell_code,wb_code from com_dictionary  where type = 'DOSAGEFORM'";

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
            string strSql = @"select * from com_department where dept_type='P'";

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
        protected Neusoft.HISFC.Models.Base.Employee employee = null;

        protected override int OnRetrieve(params object[] objects)
        {
            if (textBox1.Text == null && textBox1.Text == "")
            {
                MessageBox.Show("请输入比较天数！");
                this.textBox1.Focus();
                return -1;
            }
            int num = 0;

            if (!int.TryParse(textBox1.Text, out num))
            {
                MessageBox.Show("只能输入数字");
                this.textBox1.Focus();
                return -1;
            }
            this.employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;
            return base.OnRetrieve(neuComboBox1.Tag, Convert.ToInt32(textBox1.Text), neuComboBox2.Tag, cmbType.Tag, System.DateTime.Now, employee.Dept.Name);

        }
    }
}

