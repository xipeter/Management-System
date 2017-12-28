using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Neusoft.HISFC.Components.Common.Forms
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        #region 业务层变量
        Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint Icpm = null;
        #endregion

        #region 方法
        /// <summary>
        /// 初始化TreeView
        /// </summary>
        private void InitTreeControl()
        {
            #region 变量
            //程序集
            System.Reflection.Assembly assembly;
            //根据文件扩展名判断是否是dll
            FileInfo fi;
            //程序集中所有类型
            Type[] t;
            #endregion 

            #region 初始化treeview

            //清空Treeview的node
            this.trvControl.Nodes.Clear();
            this.trvControl.ImageList = this.trvControl.deptImageList;
            //加载根节点
            TreeNode rnode = new TreeNode();
            
            rnode.Text = "系统模块";
            rnode.Tag = "Root";
            rnode.ImageIndex = 2;
            rnode.SelectedImageIndex = 2;
            //当前his.exe下所有文件的路径
            string[] s = Directory.GetFiles(Application.StartupPath);
            foreach (string file in s)
            {
                #region 加载程序集，得到该程序集中所有类型
                //判断该文件是否是.dll文件
                fi = new FileInfo(file);
                if (fi.Extension.ToLower() != ".dll") continue;
                try
                {
                    //加载程序集
                    assembly = System.Reflection.Assembly.LoadFrom(file);
                    if (assembly == null)
                    {
                        continue;
                    }
                    //获取该程序集中所有类型
                    t = assembly.GetTypes();
                    if (t == null)
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }
                #endregion

                #region 反射得到该对象
                foreach (Type type in t)
                {
                    //判断该类型中是否继承IControlParamMaint接口
                    if (type.GetInterface("IControlParamMaint") != null)
                    {
                        //通过反射得到objectHandle
                        System.Runtime.Remoting.ObjectHandle o = System.Activator.CreateInstance(type.Assembly.ToString(), type.Namespace + "." + type.Name);
                        if (o != null)
                        {
                            //得到该被封装的对象，并转化为Conrol
                            Icpm = o.Unwrap() as Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint;
                            TreeNode node = new TreeNode(Icpm.Description);
                            node.Tag = Icpm;
                            node.ImageIndex = 0;
                            node.ImageIndex = 1;
                            rnode.Nodes.Add(node);
                        }
                    }
                }
                
                #endregion
            }
            this.trvControl.Nodes.Add(rnode);
            this.trvControl.ExpandAll();
            #endregion
        }
        
        /// <summary>
        /// 保存数据
        /// </summary>
        private void Save()
        {
            if (Icpm == null) return;
            Icpm.Save();
        }

        #endregion

        #region 事件
        private void frmSetting_Load(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据，请稍后^^");
            Application.DoEvents();
            InitTreeControl();
            if (this.trvControl.Nodes[0].Nodes.Count > 0)
                this.trvControl.SelectedNode = this.trvControl.Nodes[0].Nodes[0];
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        private void trvControl_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag.ToString() == "Root") return;
                if (this.PanelControl.Controls.Count > 0) this.PanelControl.Controls.Clear();
                Control c = null;
                c = (Control)e.Node.Tag;
                c.Dock = DockStyle.Fill;
                this.PanelControl.Controls.Add(c);
                Icpm = (Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint)c;
                Icpm.IsShowOwnButtons = false;
                if (Icpm.Init() < 0)
                {
                    MessageBox.Show(Icpm.Description + "模块初始话失败！", "错误");
                }
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}