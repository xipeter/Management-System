using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 报表控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReport : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucReport()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.Init();
            }
        }

        #region 字段
        private XmlDocument xmlDoc = new XmlDocument();
        #endregion

        private class ControlData
        {
            public string AssemblyName;
            public string CotnrolName;
            public Control Contorl;
        };

        #region 属性
        private Neusoft.FrameWork.WinForms.Forms.IReport Report
        {
            get
            {
                return ((ControlData)this.tvwControls.SelectedNode.Tag).Contorl as Neusoft.FrameWork.WinForms.Forms.IReport;
            }
        }
        #endregion
        #region 方法
        private void Init()
        {
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.J健康档案));
            //从XML文件中读出树结构
            xmlDoc.Load("OperationReport.xml");
            XmlNodeList items = xmlDoc.SelectNodes("/Config/Item");
            foreach (XmlNode node in items)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = node.Attributes[0].Value;
                treeNode.ImageIndex = 0;
                ControlData data = new ControlData();
                data.AssemblyName = node.Attributes[1].Value;
                data.CotnrolName = node.Attributes[2].Value;

                treeNode.Tag = data;
                this.tvwControls.Nodes.Add(treeNode);
            }
        }
        #endregion

        #region 事件
        private void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ControlData data = e.Node.Tag as ControlData;

            if (data.Contorl == null)
            {
                data.Contorl = Assembly.LoadFrom(data.AssemblyName).CreateInstance(data.CotnrolName) as Control;
                data.Contorl.Dock = DockStyle.Fill;
            }
            this.pnlControls.Controls.Clear();
            this.pnlControls.Controls.Add(data.Contorl);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.Report != null)
                this.Report.Query();

            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.Report != null)
                this.Report.Print();

            return base.OnPrint(sender, neuObject);
        }
        #endregion
    }
}
　