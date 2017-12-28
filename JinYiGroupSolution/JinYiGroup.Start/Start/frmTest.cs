using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class frmTest : Neusoft.FrameWork.WinForms.Forms.BaseForm 
    {
        public frmTest()
        {
            InitializeComponent();
            this.txtDllName.Focus();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.Admin.SysMenu obj = new Neusoft.HISFC.Models.Admin.SysMenu();
            obj.ModelFuntion.DllName = this.txtDllName.Text;
            obj.ModelFuntion.WinName = this.cmbFormName.Text;
            obj.MenuParm = this.txtTag.Text;
            obj.ModelFuntion.TreeControl.WinName = this.cmbTree.Text;
            obj.ModelFuntion.TreeControl.DllName = this.txtDllName.Text;
            obj.ModelFuntion.FormShowType = this.cmdShowType.Text;
            ToolStripMenuItem menu = new ToolStripMenuItem();
            menu.Text = "测试";
            menu.Tag = obj;
            HIS.Menu.MenuClick(menu, null);
            this.Close();
        }

        private void txtDllName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.addForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDllName_Leave(object sender, EventArgs e)
        {
            this.addForm();   
        }
        private void addForm()
        {
            if (this.txtDllName.Text.Trim() == "") return;
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(this.txtDllName.Text.Trim() + ".dll");
                Type[] type = assembly.GetTypes();
                this.cmbFormName.Items.Clear();
                this.cmbTree.Items.Clear();
                foreach (Type mytype in type)
                {
                    if (mytype.IsPublic && mytype.IsClass)
                    {
                        this.cmbFormName.Items.Add(mytype.ToString());
                        this.cmbTree.Items.Add(mytype.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索");
            Application.DoEvents();
            Neusoft.FrameWork.Management.Connection.Instance = new System.Data.OracleClient.OracleConnection(Neusoft.FrameWork.Management.Connection.Instance.ConnectionString);
            Neusoft.FrameWork.Management.Connection.Instance.Open();
            
            Neusoft.FrameWork.Management.DataBaseManger m = new Neusoft.FrameWork.Management.DataBaseManger();
            DataSet ds = new DataSet();
            if (m.ExecQuery("select id,name from com_sql", ref ds) == -1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(m.Err);
                return;
            }
            //Neusoft.FrameWork.Management.Connection.Instance.Close();
            //Neusoft.FrameWork.Management.Connection.Instance = new Oracle.DataAccess.Client.OracleConnection(Neusoft.FrameWork.Management.Connection.Instance.ConnectionString);
            //Neusoft.FrameWork.Management.Connection.Instance.Open();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            m.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //m.SetTrans(t.Trans);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string s = "update com_sql set name1 = :a where id='" + dr[0].ToString() + "'";
                System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(s);
                command.Connection = Neusoft.FrameWork.Management.Connection.Instance as System.Data.OracleClient.OracleConnection;
                command.CommandText = s;
                command.CommandType = System.Data.CommandType.Text;
                command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as System.Data.OracleClient.OracleTransaction;


                System.Data.OracleClient.OracleParameter param = command.Parameters.Add("a", System.Data.OracleClient.OracleType.Clob);
                param.Direction = System.Data.ParameterDirection.Input;

                // Assign Byte Array to Oracle Parameter
                param.Value = dr[1].ToString();
                // Step 5
                // Execute the Anonymous PL/SQL Block
                try
                {
                    if (command.ExecuteNonQuery() == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                          Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show(m.Err);
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(ex.Message);
                    return;
                }
			
                
                //if (m.InputBlob(s, b)== -1)
                //{
                //    t.RollBack();
                //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //    MessageBox.Show(m.Err);
                //    return;
                //}
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(dr[0].ToString()+"\n"+dr[1].ToString());
                Application.DoEvents();
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            MessageBox.Show("成功！");
        }
    }
}