using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
	/// <summary>
	/// frmSelectTree 的摘要说明。
	/// </summary>
	public class frmNodePath : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNodePath()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(8, 8);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(280, 256);
			this.treeView1.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(144, 272);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(64, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "确定";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(216, 272);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmNodePath
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(290, 298);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmNodePath";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "选择电子病历节点";
			this.Load += new System.EventHandler(this.frmSelectTree_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region 方法

		ArrayList arrTree;

		private void GetTreeList()
		{
			//从数据库读数据
            System.Data.DataSet ds = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetNodePath();
			arrTree = new ArrayList();

			//将数据拷贝到ArrayList里面
			foreach(System.Data.DataRow dr in ds.Tables[0].Rows)
			{
				Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
				obj.ID = dr["节点路径"].ToString();
				arrTree.Add(obj);
			}
			
		}

		private void CreateTree()
		{
			this.treeView1.Nodes.Clear();
			TreeNode root = new TreeNode("电子病历");
			this.treeView1.Nodes.Add(root);
			foreach(object obj in arrTree)
			{
				Neusoft.FrameWork.Models.NeuObject neuobj = (Neusoft.FrameWork.Models.NeuObject)obj;
				string[] fullpath = neuobj.ID.Split('\\');
				string parpath = "电子病历";
				TreeNode nodeParent = this.treeView1.Nodes[0];
				foreach(string path in fullpath)
				{
					parpath += "\\" + path ;
					TreeNode node = null;
					GetNodeFromFullPath(parpath, nodeParent, ref node);
					if(node == null)
					{
						node = nodeParent.Nodes.Add(path);
					}
					nodeParent = node;
				}
			}


		}

		private  void GetNodeFromFullPath(string tag,TreeNode tv,ref TreeNode rtnNode)
		{
            if (tv.FullPath == tag)
            {
                rtnNode = tv;
                return;
            }
	
			foreach(TreeNode node in tv.Nodes)
			{
                if (node.FullPath == tag)
                {
                    rtnNode = node;
                    return;
                }
                if (tag.IndexOf(node.FullPath) > 0)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        GetNodeFromFullPath(tag, childNode, ref rtnNode);
                    }
                }
			}
		}

		private void frmSelectTree_Load(object sender, System.EventArgs e)
		{
			GetTreeList();
			CreateTree();
		}
		#endregion 方法

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#region 属性
		/// <summary>
		/// 属性，除去根节点的节点的完全路径
		/// </summary>
		public string NodeFullPath
		{
			get
			{
				if(this.treeView1.SelectedNode == null || this.treeView1.SelectedNode == this.treeView1.Nodes[0])
				{
					return null;
				}
				else
				{
					string fullpath = this.treeView1.SelectedNode.FullPath;
					fullpath = fullpath.Substring(5);
					return fullpath;
				}
			}
		}
		#endregion 属性
	}
}
