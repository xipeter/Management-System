using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls {
	/// <summary>
	/// ucChooseMultiObject 的摘要说明。
	/// 根据传入的数组，将对象显示在树型列表中，让用户选择多个项目
	/// writed by cuipeng 
	/// 2005-4
	/// </summary>
	public class ucChooseMultiObject: System.Windows.Forms.UserControl {
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ImageList ilTreeView;
		private System.Windows.Forms.TreeView tvObject;
		private ArrayList myArrayObject = new ArrayList();

		/// <summary>
		/// 保存选中的数据
		/// </summary>
		public ArrayList ArrayObject {
			get {return myArrayObject;}
			set {myArrayObject = value;}
		}


		public ucChooseMultiObject() {
			this.components = new System.ComponentModel.Container();
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

		}

		public ucChooseMultiObject(ArrayList alObject) {
			this.components = new System.ComponentModel.Container();
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
			//根据传入的数组，将对象显示在树型列表中
			this.ShowList(alObject);
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>

		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		/// 根据传入的数组，显示在tvObject中
		/// </summary>
		/// <param name="arrayObject">NeuObject数组</param>
		public virtual void ShowList(ArrayList arrayObject) {
			TreeNode nodeParent = null;
			TreeNode node = null;
			//添加父级节点
			nodeParent = new TreeNode();
				nodeParent.Text = "全部";
				nodeParent.Tag  = "";
				nodeParent.ImageIndex = 0;
				nodeParent.SelectedImageIndex = 0;
				this.tvObject.Nodes.Add(nodeParent);

			foreach(Neusoft.FrameWork.Models.NeuObject obj in arrayObject) {
				node = new TreeNode();
				node.Text = obj.Name;
				node.Tag  = obj;
				node.ImageIndex = 0;
				node.SelectedImageIndex = 0;
				nodeParent.Nodes.Add(node);
			}
			
		}


		/// <summary>
		/// 将treeview中选中的数据保存到数组中
		/// </summary>
		public void Save() {
			//清空数组中的数据。
			this.myArrayObject.Clear();

			if(this.tvObject.Nodes.Count == 0) return;
			foreach(TreeNode node in this.tvObject.Nodes) {
				foreach(TreeNode tn in node.Nodes) {
					//将选中的项保存到数组中
					if(tn.Checked) this.myArrayObject.Add(tn.Tag as Neusoft.FrameWork.Models.NeuObject);
				}
			}
		}


		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucChooseMultiObject));
			this.tvObject = new System.Windows.Forms.TreeView();
			this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tvObject
			// 
			this.tvObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tvObject.CheckBoxes = true;
			this.tvObject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tvObject.ImageList = this.ilTreeView;
			this.tvObject.Location = new System.Drawing.Point(0, 0);
			this.tvObject.Name = "tvObject";
			this.tvObject.Size = new System.Drawing.Size(297, 362);
			this.tvObject.TabIndex = 0;
			// 
			// ilTreeView
			// 
			this.ilTreeView.ImageSize = new System.Drawing.Size(16, 16);
			this.ilTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeView.ImageStream")));
			this.ilTreeView.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOK.Location = new System.Drawing.Point(129, 369);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "确定(&O)";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(217, 369);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "取消(&C)";
			// 
			// ucChooseMultiObject
			// 
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tvObject);
			this.Controls.Add(this.btnCancel);
			this.Name = "ucChooseMultiObject";
			this.Size = new System.Drawing.Size(297, 398);
			this.Load += new System.EventHandler(this.ucChooseMultiObject_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ucChooseMultiObject_Load(object sender, System.EventArgs e) {
			this.btnOK.Click +=new EventHandler(btnOK_Click);
			this.btnCancel.Click +=new EventHandler(btnCancel_Click);
			this.tvObject.AfterCheck +=new TreeViewEventHandler(tvObject_AfterCheck);
		}


		private void btnOK_Click(object sender, EventArgs e) {
			this.Save();
			this.ParentForm.Close();
		}


		private void btnCancel_Click(object sender, EventArgs e) {
			this.ParentForm.Close();
		}


		private void tvObject_AfterCheck(object sender, TreeViewEventArgs e) {
			//如果选中的是根节点，则选中其所有子节点
			if(e.Node.Parent == null) {
				foreach(TreeNode node in e.Node.Nodes) {
					if(node.Checked != e.Node.Checked) node.Checked = e.Node.Checked;
				}
			}
		}


	}
}
