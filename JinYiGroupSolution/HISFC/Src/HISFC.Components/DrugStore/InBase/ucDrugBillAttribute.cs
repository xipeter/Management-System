using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.DrugStore.Inpatient
{
    public partial class ucDrugBillAttribute : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDrugBillAttribute( )
        {
            InitializeComponent( );
        }
        private System.Windows.Forms.GroupBox groupBox1;
		private DrugStore.ucTreeViewChecked tvOrderType;
		private DrugStore.ucTreeViewChecked tvUsage;
		private DrugStore.ucTreeViewChecked tvDosageForm;
		private DrugStore.ucTreeViewChecked tvDrugQuality;
		private DrugStore.ucTreeViewChecked tvDrugType;
		private System.ComponentModel.IContainer components;

		//药房管理类－调用药房管理类中的方法
		private neusoft.HISFC.Management.Pharmacy.DrugStore myDrugStore = new neusoft.HISFC.Management.Pharmacy.DrugStore(); 
		//常数类－取常数列表
		neusoft.HISFC.Management.Manager.Constant constant = new neusoft.HISFC.Management.Manager.Constant();

		/// <summary>
		/// 保存控件中的摆药单分类明细
		/// </summary>
		public int Save(DrugBillClass info, bool IsDelete) {
			//判断传入参数是否有效
			if (info.ID == "") {
				MessageBox.Show("请在摆药单分类列表中选择要维护的记录并保存");
				return -1;
			}

			//非医嘱摆药单和退药单不允许设置明细信息
			if (info.ID == "R"||info.ID == "P") {
				MessageBox.Show("手术室摆药单不需要保存明细信息。");
				return -1;
			}

			#region 取树型列表中被选中的项，并检测是否漏选
			//医嘱类型
			ArrayList alOrderType = this.GetSelectedItems(tvOrderType);
			if (alOrderType.Count == 0) {
				MessageBox.Show("请选择医嘱类型");
				return -1;
			}
			//药品用法
			ArrayList alUsage = this.GetSelectedItems(tvUsage);
			if (alUsage.Count == 0) {
				MessageBox.Show("请选择药品用法");
				return -1;
			}
			//药品剂型
			ArrayList alDosageForm = this.GetSelectedItems(tvDosageForm);
			if (alDosageForm.Count == 0) {
				MessageBox.Show("请选择药品剂型");
				return -1;
			}
			//药品性质
			ArrayList alDrugQuality = this.GetSelectedItems(tvDrugQuality);
			if (alDrugQuality.Count == 0) {
				MessageBox.Show("请选择药品性质");
				return -1;
			}
			//药品类型
			ArrayList alDrugType = this.GetSelectedItems(tvDrugType);
			if (alDrugType.Count == 0) {
				MessageBox.Show("请选择药品类型");
				return -1;
			}
			#endregion

			int parm;
			neusoft.neuFC.Management.Transaction t = new neusoft.neuFC.Management.Transaction(neusoft.neuFC.Management.Connection.Instance);
			t.BeginTransaction();
			myDrugStore.SetTrans(t.Trans);

			//根据参数判断是否需要先删除后增加。
			if (IsDelete) {
				//先删除旧摆药单分类明细中的所有数据，然后插入新的数据。
				parm = myDrugStore.DeleteDrugBillList(info.ID);
				if (parm == -1) {
					t.RollBack();
					MessageBox.Show(this.myDrugStore.Err);
					return -1;
				}
			}

			//插入新数据，用医嘱类型，用法，剂型，药品性质，药铺类型的全排列分别插入明细表。	
			DrugBillList myList = new DrugBillList();
			myList.DrugBillClass.ID = info.ID;
			int pro	= 0; //进度条上显示的数据
			int max = alOrderType.Count * alUsage.Count * alDosageForm.Count * alDrugQuality.Count * alDrugType.Count;
			foreach(neuObject OrderType in alOrderType) {
				foreach(neuObject Usage in alUsage) {
					foreach(neuObject DosageForm in alDosageForm) {
						foreach(neuObject DrugQuality in alDrugQuality) {
							foreach(neuObject DrugType in alDrugType) {
								//为摆药单明细实例赋值
								myList.TypeCode       = OrderType.ID;
								myList.UsageCode      = Usage.ID;
								myList.DosageFormCode = DosageForm.ID;
								myList.DrugQuality    = DrugQuality.ID;
								myList.DrugType       = DrugType.ID;

								//插入摆药单分类明细表
								parm = this.myDrugStore.InsertDrugBillList(myList);
								if (parm != 1) {
									t.RollBack();
									if (this.myDrugStore.DBErrCode==1)
										MessageBox.Show("数据已经存在，不能重复维护！\n"+
											" 医嘱类型;"+OrderType.ID+OrderType.Name+
											" 用法:"+Usage.ID+Usage.Name+
											" 剂型:"+DosageForm.ID+DosageForm.Name+
											" 药品性质:"+DrugQuality.ID+DrugQuality.Name+
											" 药品类型:"+DrugType.ID+DrugType.Name);
									else
										MessageBox.Show(this.myDrugStore.Err);
									return -1;
								}
								neusoft.neuFC.Interface.Classes.Function.ShowWaitForm(pro++,max);
								Application.DoEvents();
							}
						}
					}
				}
			}
			//提交数据库
			t.Commit();

			return 1;
		}


		/// <summary>
		/// 取TreeView中被选中的项目数组
		/// </summary>
		/// <param name="tv">树型列表ucTreeViewChecked</param>
		/// <returns>数组</returns>
		private ArrayList GetSelectedItems(ucTreeViewChecked tv){
			ArrayList al = new ArrayList();
			foreach( TreeNode tn in tv.Nodes[0].Nodes) {
				if (tn.Checked) al.Add((neuObject)tn.Tag);
			}
			return al;
		}


		/// <summary>
		/// 取分类明细中的各项数据，并显示在TreeView中
		/// </summary>
		/// <param name="drugBillClassCode">摆药单分类编码</param>
		public void ShowList(string drugBillClassCode){

			ArrayList al;
			//医嘱类别
			this.tvOrderType.Nodes[0].Checked = false;
			al = this.myDrugStore.GetDrugBillList(drugBillClassCode,"TYPE_CODE");
			foreach( DrugBillList info in al) {
				foreach(TreeNode tn in this.tvOrderType.Nodes[0].Nodes) {
					neuObject obj = (neuObject)tn.Tag;
					if (info.ID == obj.ID) tn.Checked = true;
				}
			}
			//药品用法
			this.tvUsage.Nodes[0].Checked = false;
			al = this.myDrugStore.GetDrugBillList(drugBillClassCode,"USAGE_CODE");
			foreach( DrugBillList info in al) {
				foreach(TreeNode tn in this.tvUsage.Nodes[0].Nodes) {
					neuObject obj = (neuObject)tn.Tag;
					if (info.ID == obj.ID) tn.Checked = true;
				}
			}
			//药品剂型
			this.tvDosageForm.Nodes[0].Checked = false;
			al = this.myDrugStore.GetDrugBillList(drugBillClassCode,"DOSE_MODEL_CODE");
			foreach( DrugBillList info in al) {
				foreach(TreeNode tn in this.tvDosageForm.Nodes[0].Nodes) {
					neuObject obj = (neuObject)tn.Tag;
					if (info.ID == obj.ID) tn.Checked = true;
				}
			}
			//药品性质
			this.tvDrugQuality.Nodes[0].Checked = false;
			al = this.myDrugStore.GetDrugBillList(drugBillClassCode,"DRUG_QUALITY");
			foreach( DrugBillList info in al) {
				foreach(TreeNode tn in this.tvDrugQuality.Nodes[0].Nodes) {
					neuObject obj = (neuObject)tn.Tag;
					if (info.ID == obj.ID) tn.Checked = true;
				}
			}
			//药品类别
			this.tvDrugType.Nodes[0].Checked = false;
			al = this.myDrugStore.GetDrugBillList(drugBillClassCode,"DRUG_TYPE");
			foreach( DrugBillList info in al) {
				foreach(TreeNode tn in this.tvDrugType.Nodes[0].Nodes) {
					neuObject obj = (neuObject)tn.Tag;
					if (info.ID == obj.ID) tn.Checked = true;
				}
			}
		}


		/// <summary>
		/// 向TreeView中插入新节点
		/// </summary>
		/// <param name="parent">父级节点</param>
		/// <param name="item">插入的节点</param>
		/// <returns></returns>
		private int AddTreeViewItem( TreeNode parent, neuObject item) {
			//设置插入的节点信息
			TreeNode tn = new TreeNode();
			tn.Text = item.Name;
			tn.ImageIndex = -1;
			tn.SelectedImageIndex = -1;
			tn.Tag = item; //Tag属性保存item
			//返回插入的节点
			return parent.Nodes.Add(tn);
		}


		/// <summary>
		/// 清空TreeView中所有节点的checked
		/// </summary>
		public void ClearTreeViewChecked( ) {
			//清空医嘱类型
			tvOrderType.Nodes[0].Checked = false;
			
			//清空药品用法
			tvUsage.Nodes[0].Checked = false;
			
			//清空药品剂型
			tvDosageForm.Nodes[0].Checked = false;
			
			//清空药品性质
			tvDrugQuality.Nodes[0].Checked = false;
			
			//清空药品类型
			tvDrugType.Nodes[0].Checked = false;
		}


		/// <summary>
		/// 将数组中的数据显示在指定节点下
		/// </summary>
		/// <param name="tn"></param>
		/// <param name="al"></param>
		private void FillTreeViewList(TreeNode tn, ArrayList al) {
			foreach ( neuObject obj in al)  {
				//将数组中的实例插入到TreeView列表中
				this.AddTreeViewItem(tn, obj);
			}
		}


		/// <summary>
		/// 显示所有空的树型列表
		/// </summary>
		public void FillTreeView() {
			TreeNode tn;
			ArrayList al = new ArrayList();

			//填充医嘱类别树型列表
			tn = new TreeNode("医嘱类别");
			//取医嘱类型数组
			neusoft.HISFC.Management.Manager.OrderType orderType = new neusoft.HISFC.Management.Manager.OrderType();
		    al = orderType.GetList();
			this.FillTreeViewList(tn, al);
			this.tvOrderType.Nodes.Add(tn);
			this.tvOrderType.ExpandAll(); 

			//填充药品用法树型列表
			tn = new TreeNode("药品用法");
			//取药品用法数组
			al = constant.GetList(neusoft.HISFC.Object.Base.enuConstant.USAGE);
			this.FillTreeViewList(tn, al);
			this.tvUsage.Nodes.Add(tn);
			this.tvUsage.ExpandAll();

			//填充药品剂型树型列表
			tn = new TreeNode("药品剂型");
			//取药品剂型数组
			al = constant.GetList(neusoft.HISFC.Object.Base.enuConstant.DOSAGEFORM);
			this.FillTreeViewList(tn, al);
			this.tvDosageForm.Nodes.Add(tn);
			this.tvDosageForm.ExpandAll();

			//填充药品性质树型列表
			tn = new TreeNode("药品性质");
			//取药品性质数组
			al = constant.GetList("DRUGQUALITY");
			this.FillTreeViewList(tn, al);
			this.tvDrugQuality.Nodes.Add(tn);
			this.tvDrugQuality.ExpandAll();

			//填充药品类别树型列表
			tn = new TreeNode("药品类别");
			//取药品类别数组
			al = constant.GetList(neusoft.HISFC.Object.Base.enuConstant.ITEMTYPE);
			this.FillTreeViewList(tn, al);
			this.tvDrugType.Nodes.Add(tn);
			this.tvDrugType.ExpandAll();
		}
    }
}
