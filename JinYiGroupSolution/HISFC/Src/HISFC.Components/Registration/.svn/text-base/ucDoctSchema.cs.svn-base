using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucDoctSchema : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDoctSchema()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmDoctShemaTemplet_Load);
            this.treeView1.BeforeSelect += new TreeViewCancelEventHandler(treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);

            this.tabControl1.Deselecting += new TabControlCancelEventHandler(tabControl1_SelectionChanging);
            this.tabControl1.Selected += new TabControlEventHandler(tabControl1_SelectionChanged);

            this.cmbDept.IsFlat = true;
            this.cmbDept.SelectedIndexChanged += new EventHandler(cmbDept_SelectedIndexChanged);
            this.cmbDept.KeyDown += new KeyEventHandler(cmbDept_KeyDown);
            
        }

        /// <summary>
        /// 排班控件数组,方便操作
        /// </summary>
        protected Registration.ucSchema[] controls;
        /// <summary>
        /// 排班模板类别
        /// </summary>
        protected Neusoft.HISFC.Models.Base.EnumSchemaType SchemaType;

        private void frmDoctShemaTemplet_Load(object sender, EventArgs e)
        {
            //if (this.Tag == null || this.Tag.ToString() == "" || this.Tag.ToString().ToUpper() == "DEPT")
            //{
            //    this.SchemaType = Neusoft.HISFC.Models.Base.EnumSchemaType.Dept;
            //    this.Text = "专科排班";
            //}
            //else
            //{
                this.SchemaType = Neusoft.HISFC.Models.Base.EnumSchemaType.Doct;
                this.Text = "专家排班";
            //}

            this.InitTab();

            this.InitArray();

            this.InitDept();

            this.InitControls();

            this.QueryTodaySchema();
            //
            //			this.treeView1_AfterSelect(new object(),new System.Windows.Forms.TreeViewEventArgs(new TreeNode(),System.Windows.Forms.TreeViewAction.Unknown));
        }
        /// <summary>
        /// 生成排班日期
        /// </summary>
        private void InitTab()
        {
            Neusoft.HISFC.BizLogic.Registration.Schema sMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
            DateTime Current = sMgr.GetDateTimeFromSysDateTime();

            DateTime Monday = this.GetMonday(Current);

            this.setWeek(Monday);
        }
        private void setWeek(DateTime Monday)
        {
            string[] Week = new string[] { "一", "二", "三", "四", "五", "六", "日" };

            for (int i = 0; i < 7; i++)
            {
                this.tabControl1.TabPages[i].Tag = Monday.AddDays(i);
                this.tabControl1.TabPages[i].Text = Monday.AddDays(i).ToString("yyyy-MM-dd") + "  " + Week[i];
            }
        }
        /// <summary>
        /// 获取当前日期所在星期的星期一
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private DateTime GetMonday(DateTime current)
        {
            DayOfWeek today = current.DayOfWeek;

            int interval = 1 - (int)today;

            if (interval == 1)//星期日
            {
                interval = -6;//将星期日归到上星期
            }

            return current.AddDays(interval);
        }

        /// <summary>
        /// 初始化数组
        /// </summary>
        private void InitArray()
        {
            controls = new Registration.ucSchema[7];
            controls[0] = this.ucSchema1;
            controls[1] = this.ucSchema2;
            controls[2] = this.ucSchema3;
            controls[3] = this.ucSchema4;
            controls[4] = this.ucSchema5;
            controls[5] = this.ucSchema6;
            controls[6] = this.ucSchema7;
        }

        /// <summary>
        /// 初始化模板控间
        /// </summary>
        private void InitControls()
        {
            Registration.ucSchema obj;

            for (int i = 0; i < 7; i++)
            {
                obj = controls[i];
                obj.Init(DateTime.Parse(tabControl1.TabPages[i].Tag.ToString()), this.SchemaType);
            }
        }

        /// <summary>
        /// 生成门诊科室树
        /// </summary>
        private void InitDept()
        {
            this.treeView1.Nodes.Clear();
            TreeNode parent = new TreeNode("出诊科室");
            this.treeView1.ImageList = this.treeView1.deptImageList;
            parent.ImageIndex = 5;
            parent.SelectedImageIndex = 5;
            this.treeView1.Nodes.Add(parent);

            Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            ArrayList al = deptMgr.QueryRegDepartment();
            if (al == null)
            {
                MessageBox.Show("获取科室列表时出错!" + deptMgr.Err, "提示");
                return;
            }

            foreach (Neusoft.HISFC.Models.Base.Department dept in al)
            {
                TreeNode node = new TreeNode();
                node.Text = dept.Name;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 1;
                node.Tag = dept;

                parent.Nodes.Add(node);
            }

            parent.ExpandAll();

            this.cmbDept.AddItems(al);
        }

        /// <summary>
        /// 默认显示当日排班
        /// </summary>
        private void QueryTodaySchema()
        {
            Neusoft.HISFC.BizLogic.Registration.Schema SchemaMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();

            DateTime today = SchemaMgr.GetDateTimeFromSysDateTime();

            int Index = (int)today.DayOfWeek;
            Index--;
            if (Index == -1) Index = 6;

            this.tabControl1.SelectedIndex = Index;
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            int Index = this.tabControl1.SelectedIndex;

            if (controls[Index].IsChange())
            {
                if (MessageBox.Show("数据已经改变,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (controls[Index].Save() == -1)
                    {
                        e.Cancel = true;
                        controls[Index].Focus();
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;

            if (node == null) return;

            string deptID;
            Neusoft.HISFC.Models.Base.Department dept = null;

            if (node.Parent == null)//父节点
            {
                deptID = "ALL";
            }
            else
            {
                dept = (Neusoft.HISFC.Models.Base.Department)node.Tag;
                deptID = dept.ID;
            }

            controls[this.tabControl1.SelectedIndex].Dept = dept;
            controls[this.tabControl1.SelectedIndex].Query(deptID);
        }
        
        /// <summary>
        /// 增加
        /// </summary>
        private void Add()
        {
            int Index = this.tabControl1.SelectedIndex;

            controls[Index].Add();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            int Index = this.tabControl1.SelectedIndex;

            controls[Index].Del();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            int Index = this.tabControl1.SelectedIndex;

            if (controls[Index].Save() == -1)
            {
                controls[Index].Focus();
                return;
            }

            MessageBox.Show("保存成功!", "提示");

            controls[Index].Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Next()
        {
            DateTime Monday;

            
             Monday = this.GetMonday(DateTime.Parse(this.tabPage7.Tag.ToString()).AddDays(2));
                            
            this.setWeek(Monday);

            for (int i = 0; i < 7; i++)
            {
                this.controls[i].Tag = null;
                this.controls[i].SeeDate = DateTime.Parse(this.tabControl1.TabPages[i].Tag.ToString());
            }


            this.controls[this.tabControl1.SelectedIndex].Query("ALL");
        }

        private void Prior()
        {
            DateTime Monday;

            Monday = this.GetMonday(DateTime.Parse(this.tabPage1.Tag.ToString()).AddDays(-3));

            this.setWeek(Monday);

            for (int i = 0; i < 7; i++)
            {
                this.controls[i].Tag = null;
                this.controls[i].SeeDate = DateTime.Parse(this.tabControl1.TabPages[i].Tag.ToString());
            }


            this.controls[this.tabControl1.SelectedIndex].Query("ALL");
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void DelAll()
        {
            int Index = this.tabControl1.SelectedIndex;

            controls[Index].DelAll();
        }
        /// <summary>
        /// 载入模板
        /// </summary>
        private void LoadTemplet()
        {
            frmSelectWeek f = new frmSelectWeek();

            DateTime week = DateTime.Parse(this.tabControl1.SelectedTab.Tag.ToString());

             
            f.SelectedWeek = week.DayOfWeek;
            if (f.ShowDialog() == DialogResult.Yes)
            {
                Neusoft.HISFC.BizLogic.Registration.SchemaTemplet templetMgr = new Neusoft.HISFC.BizLogic.Registration.SchemaTemplet();

                //获取全部模板信息
                ArrayList al = templetMgr.Query(this.SchemaType, f.SelectedWeek, "ALL");
                if (al == null)
                {
                    MessageBox.Show("查询模板信息时出错!" + templetMgr.Err, "提示");
                    return;
                }

                DateTime currentDate = templetMgr.GetDateTimeFromSysDateTime();



                foreach (Neusoft.HISFC.Models.Registration.SchemaTemplet templet in al)
                {
                    //controls[this.tabControl1.SelectedIndex].Add(templet);
                    if (currentDate.Date == controls[this.tabControl1.SelectedIndex].SeeDate.Date)
                    {
                        if (templet.End.TimeOfDay > currentDate.TimeOfDay)
                        {

                            controls[this.tabControl1.SelectedIndex].Add(templet);
                        }
                    }

                    if (currentDate.Date < controls[this.tabControl1.SelectedIndex].SeeDate.Date)
                    {
                        controls[this.tabControl1.SelectedIndex].Add(templet);
                    }


                }

                controls[this.tabControl1.SelectedIndex].Focus();
                f.Dispose();
            }
        }
        private void Find()
        {
            int Index = this.tabControl1.SelectedIndex;

            frmFindEmployee f = new frmFindEmployee();
            f.SelectedEmployee = controls[Index].SearchEmployee;

            this.cmbDept.Focus();

            if (f.ShowDialog() == DialogResult.Yes)
            {
                controls[Index].Focus();
                controls[Index].SearchEmployee = f.SelectedEmployee;
                f.Dispose();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            //{
            //    this.Del();
            //    return true;
            //}
            //else if (keyData == Keys.Add || keyData == Keys.Oemplus)
            //{
            //    this.Add();

            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            //{
            //    this.FindForm().Close();
            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            //{
            //    this.Save();

            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.C.GetHashCode())
            //{
            //    LoadTemplet();

            //    return true;
            //}
            //else if (keyData == Keys.F2)
            //{
            //    Next();

            //    return true;
            //}
            if (keyData == Keys.F1)
            {
                this.cmbDept.Focus();

                return true;
            }
            //else if (keyData == Keys.F3)
            //{
            //    this.Find();

            //    return true;
            //}

            return base.ProcessDialogKey(keyData);
        }

        private void tabControl1_SelectionChanging(object sender, EventArgs e)
        {
            int Index = this.tabControl1.SelectedIndex;

            if (controls[Index].IsChange())
            {
                if (MessageBox.Show("数据已经修改,是否保存变动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (controls[Index].Save() == -1)
                    {
                        return;
                    }
                }
            }
        }

        private void tabControl1_SelectionChanged(object sender, EventArgs e)
        {
            object obj = controls[this.tabControl1.SelectedIndex].Tag;

            if (obj == null || obj.ToString() == "")
            {
                this.treeView1.SelectedNode = this.treeView1.Nodes[0];
                this.treeView1_AfterSelect(new object(), new System.Windows.Forms.TreeViewEventArgs(new TreeNode(), System.Windows.Forms.TreeViewAction.Unknown));

                controls[this.tabControl1.SelectedIndex].Tag = "Has Retrieve";
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.treeView1.Nodes[0].Nodes)
            {
                if ((node.Tag as Neusoft.HISFC.Models.Base.Department).ID == this.cmbDept.Tag.ToString())
                {
                    this.treeView1.SelectedNode = node;
                    break;
                }
            }
        }

        private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Index = this.tabControl1.SelectedIndex;

                controls[Index].Focus();
            }
        }

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("复制模板", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.F复制, true, false, null);
            toolBarService.AddToolButton("查找", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找, true, false, null);
            toolBarService.AddToolButton("下周", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个, true, false, null);
            toolBarService.AddToolButton("上周", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S上一个, true, false, null);
            toolBarService.AddToolButton("全部删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全退, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.Add();

                    break;
                case "删除":
                    this.Del();

                    break;
                case "复制模板":
                    this.LoadTemplet();
                    break;
                case "查找":
                    this.Find();
                    break;
                case "上周":
                    Prior();

                    break;
                case "下周":
                    Next();

                    break;
                case "全部删除":
                    DelAll();

                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return base.OnSave(sender, neuObject);
        }
    }
}
