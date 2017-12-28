using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucDepartmentExt : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDepartmentExt()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager myDeptManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
        private Neusoft.FrameWork.Management.ExtendParam myDeptExt = new Neusoft.FrameWork.Management.ExtendParam();
        Neusoft.HISFC.Models.Base.ExtendInfo myExtendInfo = null;
        private DataTable dtDepartmentExt = new DataTable("科室维护");
        private Hashtable htDepartment = new Hashtable();
        ArrayList al = new ArrayList();
        ArrayList alDepartExt = new ArrayList();
        

        private void ucDepartmentExt_Load(object sender, EventArgs e)
        {
            this.InitDateTable();
            this.InitTreeView();
            this.InitFp();
            this.GetDepartmentExt();
        }

        private void InitDateTable()
        {
            try
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                Type floatType = typeof(System.Single);

                this.dtDepartmentExt.Columns.AddRange(new DataColumn[]{
														   new DataColumn("科室编码", strType),	//0
														   new DataColumn("科室名称", strType),	 //1
														   new DataColumn("属性编码", strType),//2
														   new DataColumn("属性名称", strType),//3
														   new DataColumn("字符属性", strType),//4
														   new DataColumn("床位数", intType),//5
														   new DataColumn("日期属性", dtType),//6
														   new DataColumn("备注",     strType), //7
														   new DataColumn("操作人",   strType),//8
														   new DataColumn("操作时间", dtType),//9
														   new DataColumn("科室类型", strType)});//10
                //绑定数据源
                this.fpSpread1.DataSource = this.dtDepartmentExt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitFp()
        {
            this.fpSpread1.Sheets[0].Columns[0].Visible = false;
            this.fpSpread1.Sheets[0].Columns[2].Visible = false;
            this.fpSpread1_Sheet1.Columns[4].Visible = false;
            this.fpSpread1_Sheet1.Columns[6].Visible = false;
            this.fpSpread1_Sheet1.Columns[10].Visible = false;
            this.fpSpread1_Sheet1.Columns[1].Locked = true;
            this.fpSpread1_Sheet1.Columns[3].Locked = true;
            this.fpSpread1_Sheet1.Columns[8].Locked = true;
        }

        private void InitTreeView()
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Tag = "ALL";
            treeNode.Text = "住院科室";
            this.tvdept.Nodes.Add(treeNode);
            this.al = this.myDeptManager.LoadDepartmentStatAndByNodeKind("72", "1");
            for (int i = 0; i < al.Count; i++)
            {
                TreeNode onenode = new TreeNode();
                onenode.Tag = ((Neusoft.HISFC.Models.Base.DepartmentStat)al[i]).DeptCode;
                onenode.Text = ((Neusoft.HISFC.Models.Base.DepartmentStat)al[i]).DeptName;
                this.tvdept.Nodes[0].Nodes.Add(onenode);
            }
            this.tvdept.ExpandAll();
        }

        private void GetDepartmentExt()
        {
            this.alDepartExt = this.myDeptExt.GetComExtInfoList(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT,"CASE_BED_STAND");
            Neusoft.HISFC.Models.Base.ExtendInfo departmentExt = new Neusoft.HISFC.Models.Base.ExtendInfo();
            for (int i = 0; i < this.alDepartExt.Count; i++)
            {
                departmentExt = this.alDepartExt[i] as Neusoft.HISFC.Models.Base.ExtendInfo;

                this.htDepartment.Add(departmentExt.Item.ID, departmentExt.Item.ID);
                DataRow row = this.dtDepartmentExt.NewRow();
                row["科室编码"] = departmentExt.Item.ID;
                row["科室名称"] = departmentExt.PropertyName;
                row["属性编码"] = "CASE_BED_STAND";
                row["属性名称"] = "床位数";
                row["床位数"] = departmentExt.NumberProperty;
                row["操作人"] = departmentExt.OperEnvironment.ID;
                row["操作时间"] = Neusoft.FrameWork.Function.NConvert.ToDateTime( departmentExt.OperEnvironment.Memo);
                this.dtDepartmentExt.Rows.Add(row);
            }
        }

        private void tvdept_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (((TreeView)sender).SelectedNode.Level == 1)
            {
                if (htDepartment.ContainsKey(this.tvdept.SelectedNode.Tag))
                {
                }
                else
                {
                    this.htDepartment.Add(this.tvdept.SelectedNode.Tag, this.tvdept.SelectedNode.Tag);
                    DataRow row = this.dtDepartmentExt.NewRow();
                    row["科室编码"] = this.tvdept.SelectedNode.Tag;
                    row["科室名称"] = this.tvdept.SelectedNode.Text;
                    row["属性编码"] = "CASE_BED_STAND";
                    row["属性名称"] = "床位数";
                    row["床位数"] = 0;
                    row["操作人"] = this.myDeptManager.Operator.ID;
                    row["操作时间"] = this.myDeptManager.GetDateTimeFromSysDateTime();
                    this.dtDepartmentExt.Rows.Add(row);
                }
            }
            else
            {
                for (int i = 0; i < al.Count; i++)
                {
                    if (!htDepartment.ContainsKey(((Neusoft.HISFC.Models.Base.DepartmentStat)al[i]).DeptCode))
                    {
                        this.htDepartment.Add(((Neusoft.HISFC.Models.Base.DepartmentStat)al[i]).DeptCode, ((Neusoft.HISFC.Models.Base.DepartmentStat)al[i]).DeptCode);
                        DataRow row = this.dtDepartmentExt.NewRow();
                        row["科室编码"] = ((Neusoft.HISFC.Models.Base.DepartmentStat)al[i]).DeptCode;
                        row["科室名称"] = ((Neusoft.HISFC.Models.Base.DepartmentStat)al[i]).DeptName;
                        row["属性编码"] = "CASE_BED_STAND";
                        row["属性名称"] = "床位数";
                        row["床位数"] = 0;
                        row["操作人"] = this.myDeptManager.Operator.ID;
                        row["操作时间"] = this.myDeptManager.GetDateTimeFromSysDateTime();
                        this.dtDepartmentExt.Rows.Add(row);
                    }
                }
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.myDeptExt.Connection);
            //trans.BeginTransaction();
            this.myDeptExt.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                this.SetDepartmentExt(i);
                if (this.myDeptExt.SetComExtInfo(this.myExtendInfo) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("保存失败!");
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功!");
            return base.OnSave(sender, neuObject);
        }
        private void SetDepartmentExt(int a)
        {
            this.myExtendInfo = new Neusoft.HISFC.Models.Base.ExtendInfo();
            this.myExtendInfo.ExtendClass = Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT;
            this.myExtendInfo.Item.ID = this.fpSpread1_Sheet1.Cells[a, 0].Text;
            this.myExtendInfo.PropertyCode = "CASE_BED_STAND";
            this.myExtendInfo.PropertyName = this.fpSpread1_Sheet1.Cells[a, 1].Text;
            this.myExtendInfo.NumberProperty = Neusoft.FrameWork.Function.NConvert.ToInt32( this.fpSpread1_Sheet1.Cells[a, 5].Value);
            this.myExtendInfo.Memo = this.fpSpread1_Sheet1.Cells[a, 7].Text;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPreview(0, 0, this.neuPanel1);
            return base.OnPrint(sender, neuObject);
        }
    }
}
