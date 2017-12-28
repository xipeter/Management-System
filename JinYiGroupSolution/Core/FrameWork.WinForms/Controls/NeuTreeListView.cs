using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Neusoft.FrameWork.WinForms.Controls
{
    [ToolboxBitmap(typeof(TreeView))]
    public partial class NeuTreeListView : System.Windows.Forms.TreeListView
    {
        public NeuTreeListView()
        {
            InitializeComponent();
        }

        public NeuTreeListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
