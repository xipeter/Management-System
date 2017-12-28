using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Forms;
using System.Collections;
using System.Reflection;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// [功能描述: 常数维护控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucMaintenanceConst : UserControl, IMaintenanceControlable
    {
        public ucMaintenanceConst()
        {
            InitializeComponent();
        }

        #region 字段
        private IMaintenanceControlable maintenanceControl;
        private IMaintenanceForm maintenanceForm;
        /// <summary>
        /// 已经初始化过的维护控件
        /// </summary>
        protected Dictionary<TreeNode, IMaintenanceControlable> initedMaintenanceControl = new Dictionary<TreeNode, IMaintenanceControlable>();
        #endregion

        #region 属性

        private IMaintenanceControlable CurrentMaintenanceControl
        {
            get
            {
                if (this.tvList.SelectedNode != null && this.tvList.SelectedNode.Parent != null)
                {

                    if (this.initedMaintenanceControl.ContainsKey(this.tvList.SelectedNode))
                    {
                        this.maintenanceControl = this.initedMaintenanceControl[this.tvList.SelectedNode];


                    }
                    else
                    {
                        if (this.tvList.SelectedNode.Tag != null)
                        {
                            Neusoft.HISFC.Models.Admin.SysModelFunction info = this.tvList.SelectedNode.Tag as Neusoft.HISFC.Models.Admin.SysModelFunction;

                            if (info.WinName == typeof(Neusoft.FrameWork.WinForms.Controls.ucMaintenance).FullName)  //动态维护窗口
                            {
                                object[] arg = new object[1];
                                Neusoft.HISFC.Models.Base.Employee user = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                                arg[0] = user.CurrentGroup.ID + "_" + info.ID;

                                this.maintenanceControl = Assembly.LoadFrom(Application.StartupPath + "\\FrameWork.WinForms.dll").CreateInstance("Neusoft.FrameWork.WinForms.Controls.ucMaintenance",
                                    true, BindingFlags.CreateInstance, null, arg, null, null) as IMaintenanceControlable;
                            }
                            else
                            {
                                this.maintenanceControl = Assembly.LoadFrom(Application.StartupPath + "\\" + info.DllName + ".dll").CreateInstance(info.WinName) as IMaintenanceControlable;
                                (this.maintenanceControl as Control).Text = info.Param;
                            }

                            this.maintenanceControl.Init();
                            this.ShowMaintenanceControl(this.maintenanceControl as Control);

                            this.initedMaintenanceControl.Add(this.tvList.SelectedNode, this.maintenanceControl);
                        }
                    }

                    return this.maintenanceControl;
                }
                else
                    return null;

            }

        }
        #endregion

        #region 方法
        protected override void OnLoad(EventArgs e)
        {
            this.ShowList();
            this.maintenanceForm.ShowExportButton = false;
            this.maintenanceForm.ShowImportButton = false;
            this.maintenanceForm.ShowPrintButton = false;
            this.maintenanceForm.ShowPrintPreviewButton = false;
            this.maintenanceForm.ShowPrintConfigButton = false;
            (this.maintenanceForm as Neusoft.FrameWork.WinForms.Forms.frmQuery).ShowQueryButton = false;
            base.OnLoad(e);
        }

        private void ShowMaintenanceControl(Control control)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                this.splitContainer1.Panel2.Controls.Add(control);
            }
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowList()
        {
            //清空列表
            this.tvList.Nodes.Clear();
            this.tvList.ImageList = this.tvList.groupImageList;
            //显示根节点
            Neusoft.HISFC.Models.Admin.SysModelFunction obj = new Neusoft.HISFC.Models.Admin.SysModelFunction();
            obj.ID = ""; //显示所有数据
            TreeNode node = new TreeNode();
            node.Text = "常数维护";
            node.ImageIndex = 0;
            node.SelectedImageIndex = node.ImageIndex;
            //node.Tag = obj;
            this.tvList.Nodes.Add(node);

            //取当前用户组中可以维护的常数
            Neusoft.HISFC.BizLogic.Manager.SysGroup group = new Neusoft.HISFC.BizLogic.Manager.SysGroup();
            //
            //  I don't think this is a good idea to save the info in this class
            //  Robin   2006-11-14
            Neusoft.HISFC.Models.Base.Employee user = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            ArrayList al = group.GetConstByGroup(user.CurrentGroup.ID);

            if (al == null)
            {
                MessageBox.Show("没有可以维护的常数，请在系统管理中设置常数维护项");
                return;
            }

            //显示常数维护数据
            foreach (Neusoft.HISFC.Models.Admin.SysModelFunction info in al)
            {
                node = new TreeNode();
                node.Text = info.Name;
                node.ImageIndex = 3;
                node.SelectedImageIndex = 4;
                node.Tag = info;
                this.tvList.Nodes[0].Nodes.Add(node);
            }

            this.tvList.Nodes[0].ExpandAll();
        }

        /// <summary>
        /// 刷新库存明细数据
        /// </summary>
        public void RefreshData()
        {
            //调用接口的Query函数，显示数据
            if (this.CurrentMaintenanceControl != null)
            {
                this.ShowMaintenanceControl(this.maintenanceControl as Control);
                this.maintenanceControl.Query();
            }
            else
            {

            }
        }

        #endregion



        #region 事件

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //刷新数据
            this.RefreshData();
        }
        private void tvList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (this.CurrentMaintenanceControl != null)
            {
                //this.CurrentMaintenanceControl.Save();
            }
        }
        #endregion
        #region IMaintenanceControlable 成员

        public IMaintenanceForm QueryForm
        {
            get
            {
                return this.maintenanceForm;
            }
            set
            {
                this.maintenanceForm = value;
            }
        }

        public int Query()
        {
            if (this.maintenanceControl != null)
                return maintenanceControl.Query();

            return -1;
        }

        public int Add()
        {
            if (this.maintenanceControl != null)
                return this.maintenanceControl.Add();

            return -1;
        }

        public int Delete()
        {
            if (this.CurrentMaintenanceControl != null)
            {
                return this.CurrentMaintenanceControl.Delete();
            }
            else
            {
                return -1;
            }
        }

        public int Save()
        {
            if (this.CurrentMaintenanceControl != null)
            {
                return this.CurrentMaintenanceControl.Save();
            }
            else
            {
                return -1;
            }
        }

        public int Export()
        {
            if (this.CurrentMaintenanceControl != null)
            {
                return this.CurrentMaintenanceControl.Export();
            }
            else
            {
                return -1;
            }
        }

        public int Print()
        {
            if (this.CurrentMaintenanceControl != null)
            {
                return this.CurrentMaintenanceControl.Print();
            }
            else
            {
                return -1;
            }
        }

        public bool IsDirty
        {
            get
            {
                if (this.CurrentMaintenanceControl != null)
                    return this.CurrentMaintenanceControl.IsDirty;
                return false;
            }
            set
            {
                if (this.CurrentMaintenanceControl != null)
                    this.CurrentMaintenanceControl.IsDirty = value;
            }
        }


        public int Copy()
        {
            return 0;
        }

        public int Cut()
        {
            return 0;
        }

        public int Import()
        {
            return 0;
        }

        public int Init()
        {
            return 0;
        }

        public int Modify()
        {
            return 0;
        }

        public int NextRow()
        {
            return 0;
        }

        public int Paste()
        {
            return 0;
        }

        public int PreRow()
        {
            return 0;
        }

        public int PrintConfig()
        {
            return 0;
        }

        public int PrintPreview()
        {
            return 0;
        }

        #endregion


    }

}
