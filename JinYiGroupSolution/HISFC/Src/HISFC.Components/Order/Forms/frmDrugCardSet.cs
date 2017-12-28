using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Order.Forms
{
    public partial class frmDrugCardSet : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmDrugCardSet()
        {
            InitializeComponent();
        }

        private void frmDrugCardSet_Load(object sender, EventArgs e)
        {

        }

        Neusoft.HISFC.BizLogic.Order.TransFusion manager = new Neusoft.HISFC.BizLogic.Order.TransFusion();
        Neusoft.HISFC.Models.Base.Employee person = null;
        ArrayList alDel = null;
        protected override void OnLoad(EventArgs e)
        {
            this.InitControl();
            base.OnLoad(e);
        }
        
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            #region 添加用法
            Neusoft.HISFC.BizProcess.Integrate.Manager dept = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            
            ArrayList al = null;
            if (Neusoft.FrameWork.Management.Connection.Operator != null)  //获得病区
            {
                person = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                
            }
            
            try
            {
                //系统用法
                al = dept.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
            }
            catch { return; }
            this.listView1.Columns.Add("系统中的用法", 100, HorizontalAlignment.Center);
            this.listView2.Columns.Add("选择的用法", 100, HorizontalAlignment.Center);
            this.listView1.View = View.Details;
            this.listView2.View = View.Details;
            if (al != null)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject o = al[i] as Neusoft.FrameWork.Models.NeuObject;
                    ListViewItem lt = new ListViewItem();
                    lt.Tag = o;
                    lt.Text = o.Name;
                    lt.ImageIndex = 0;
                    this.listView1.Items.Add(lt);
                }
            }
          
            #endregion

            
            al = manager.QueryTransFusion(person.Nurse.ID);
            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }
            for (int i = 0; i < al.Count; i++)
            {
                try
                {
                    ListViewItem item = (ListViewItem)this.GetUserFromItem(al[i].ToString()).Clone();
                    this.listView2.Items.Add(item);
                    this.listView1.Items.Remove(GetUserFromItem(al[i].ToString()));
                }
                catch { MessageBox.Show(al[i].ToString() + "没找到！"); }
            }
            alDel = (ArrayList)al.Clone();
        }
        private ListViewItem GetUserFromItem(string UsageCode)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (((Neusoft.FrameWork.Models.NeuObject)this.listView1.Items[i].Tag).ID == UsageCode)
                {
                    return this.listView1.Items[i];
                }
            }
            return null;
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            Add();
        }
        private void Add()
        {
            try
            {
                ListViewItem item = (ListViewItem)listView1.SelectedItems[0].Clone();
                this.listView2.Items.Add(item);
                listView1.SelectedItems[0].Remove();
            }
            catch { }
        }

        private void listView2_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                ListViewItem item = (ListViewItem)listView2.SelectedItems[0].Clone();
                this.listView1.Items.Add(item);
                listView2.SelectedItems[0].Remove();
            }
            catch { }
        }
        //保存
        private void button1_Click(object sender, System.EventArgs e)
        {
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            for (int i = 0; i < this.alDel.Count; i++)
            {
                if (manager.DeleteTransFusion(person.Nurse.ID, alDel[i].ToString()) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(manager.Err);
                    return;
                }
            }
            for (int i = 0; i < this.listView2.Items.Count; i++)
            {
                if (manager.InsertTransFusion(person.Nurse.ID, ((Neusoft.FrameWork.Models.NeuObject)this.listView2.Items[i].Tag).ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(manager.Err);
                    return;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

      
    }
}