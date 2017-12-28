using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace neusoft.neuFC.Interface.Controls {
	/// <summary>
	/// tvPatientList 的摘要说明。
	/// 患者列表控件
	/// </summary>
	public class tvPatientList :System.Windows.Forms.TreeView {
		
		public tvPatientList() {
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			InitializeComponent();
			init();//初始化
		}

		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		#region 组件设计器生成的代码


		public tvPatientList(System.ComponentModel.IContainer container) {
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			container.Add(this);
			InitializeComponent();
			init();//初始化
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(tvPatientList));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tvPatientList
			// 
			this.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPatientList_AfterCheck);

		}
		#endregion
	
		/// <summary>
		/// 显示其他信息-住院号，科室，病床，在院状态
		/// </summary>
		public enum enuShowType {
			None = 0,
			InpatientNo=1,
			Dept=3,
			Bed=5,
			Status=7
		}

		/// <summary>
		/// 显示信息方向，前面，后面(姓名放在相反的方向)
		/// </summary>
		public enum enuShowDirection {
			Ahead,
			Behind
		}

		/// <summary>
		/// 选择类型
		/// </summary>
		public enum enuChecked {
			None,
			Radio,
			MultiSelect
		}

		private ArrayList myPatients=new ArrayList();
		private enuShowType myShowType = enuShowType.Bed;   //默认显示床号
		private enuChecked myChecked = enuChecked.None;     //默认不显示CheckBox
		private enuShowDirection myDirection = enuShowDirection.Ahead; //默认其他信息放在前面,姓名放在后面
		private bool bIsShowNewPatient = true;  //默认如果是当天入院的患者,显示【新】
		private bool bControlChecked=false;
		private DateTime dtToday;
		protected  bool bIsShowCount=true;
		public int RootImageIndex=0;
		public int RootSelectedImageIndex=1;
		public int BranchImageIndex=2;
		public int BranchSelectedImageIndex=3;
		public int MaleImageIndex=4;
		public int MaleSelectedImageIndex=5;
		public int FemaleImageIndex=6;
		public int FemaleSelectedImageIndex=7;
		/// <summary>
		/// 是否显示新的患者
		/// </summary>
		public bool IsShowNewPatient {
			get {
				return this.bIsShowNewPatient ;
			}
			set {
				this.bIsShowNewPatient = value;
			}
		}

		/// <summary>
		/// 显示类型
		/// </summary>
		public enuShowType ShowType {
			get {
				return this.myShowType;
			}
			set {
				this.myShowType=value;
			}
		}

		/// <summary>
		/// 患者数组，包含分割object
		/// </summary>
		public ArrayList alPatients {
			get {
				return this.myPatients;
			}
			set {
				this.myPatients=value;
				this.RefreshList();
			}
		}

		/// <summary>
		/// 显示选择类型
		/// </summary>
		public enuChecked Checked {
			get {
				return this.myChecked;
			}
			set {
				this.myChecked=value;
				if(this.myChecked==enuChecked.MultiSelect) {
					this.CheckBoxes = true;
				}
				else {
					this.CheckBoxes = false;
				}
			}
		}

		/// <summary>
		/// 显示其他信息位置
		/// </summary>
		public enuShowDirection Direction {
			get {
				return this.myDirection;
			}
			set {
				this.myDirection=value;
			}
		}

		/// <summary>
		/// 是否显示nodeCount
		/// </summary>
		public bool IsShowCount {
			get {
				return this.bIsShowCount;
			}
			set {
				this.bIsShowCount=value;
			}
		}




		/// <summary>
		/// 刷新列表
		/// </summary>
		private void RefreshList() {
			this.Nodes.Clear();
			int Branch=0;
			if(this.myPatients.Count ==0) this.AddRootNode();
			for(int i=0 ;i<this.myPatients.Count;i++) {
				System.Windows.Forms.TreeNode newNode=new System.Windows.Forms.TreeNode();
				neusoft.neuFC.Object.neuObject obj=new neusoft.neuFC.Object.neuObject();
				//类型为叶
				if(this.myPatients[i].GetType().ToString()=="neusoft.HISFC.Object.RADT.PatientInfo") {
					try {
						neusoft.HISFC.Object.RADT.PatientInfo PatientInfo=(neusoft.HISFC.Object.RADT.PatientInfo)this.myPatients[i];
						obj.ID=PatientInfo.Patient.PID.PatientNo;
						obj.Name = PatientInfo.Name;
						try {
							obj.Memo=PatientInfo.PVisit.PatientLocation.Bed.ID;
						}
						catch{//无病床信息
						}
						obj.User01=PatientInfo.PVisit.PatientLocation.Dept.Name;
						obj.User02=PatientInfo.PVisit.In_State.Name;
						obj.User03=PatientInfo.Patient.Sex.ID.ToString();
						if(this.bIsShowNewPatient) {
							if(dtToday.Date ==  PatientInfo.PVisit.Date_In.Date) obj.Name = obj.Name +"(新)";
						}
						this.AddTreeNode(Branch,obj,PatientInfo);
					}
					catch{}
				}
				else if(this.myPatients[i].GetType().ToString()=="neusoft.HISFC.Object.RADT.Patient") {
					neusoft.HISFC.Object.RADT.Patient PatientInfo=(neusoft.HISFC.Object.RADT.Patient)this.myPatients[i];
					obj.ID=PatientInfo.PID.PatientNo;
					obj.Name=PatientInfo.Name;
					obj.Memo="";
					obj.User01="";
					obj.User02="";
					obj.User03=PatientInfo.Sex.ID.ToString();
					this.AddTreeNode(Branch,obj,PatientInfo);
				}
				else if(this.myPatients[i].GetType().ToString()=="neusoft.neuFC.Object.neuObject") {
					obj=(neusoft.neuFC.Object.neuObject)this.myPatients[i];
					this.AddTreeNode(Branch,obj,obj);
				}
				else {//为干
					//分割字符串 text|tag 标识结点
					string all=this.myPatients[i].ToString();
					string[] s=all.Split('|');

					newNode.Text=s[0];
					
					try {
						newNode.Tag=s[1];
					}
					catch{newNode.Tag="";}
					try {
						newNode.ImageIndex=this.BranchImageIndex;
						newNode.SelectedImageIndex=this.BranchSelectedImageIndex;
					}
					catch{}
					Branch=this.Nodes.Add(newNode);
				}
			}
			if(this.bIsShowCount) {
				foreach(System.Windows.Forms.TreeNode node in this.Nodes) {
				
					if(node.Tag ==null || node.Tag.GetType().ToString()=="System.String" ) {//结点
						int count=0;
						count=node.GetNodeCount(false);
						node.Text=node.Text+"("+count.ToString()+")";
					}
				}
			}
			this.ExpandAll();
		}


		/// <summary>
		/// 删除节点
		/// </summary>
		/// <param name="branch">父级节点索引</param>
		/// <param name="nodeIndex">要删除节点索引</param>
		public void DeleteNode(int branch, int nodeIndex) {
			//移除节点
			this.Nodes[branch].Nodes[nodeIndex].Remove();
		}


		/// <summary>
		/// 根据传入参数,修改指定的节点信息
		/// </summary>
		/// <param name="branch">父级节点索引</param>
		/// <param name="nodeIndex">被修改节点索引</param>
		/// <param name="neuObj">节点Text信息</param>
		/// <param name="obj">节点Tag属性</param>
		public void ModifiyNode(int branch, int nodeIndex, neusoft.neuFC.Object.neuObject nodeTextInfo,object nodeTag) {
			try {
				System.Windows.Forms.TreeNode node = this.Nodes[branch].Nodes[nodeIndex];
				//生成节点信息
				this.CreateNodeInfo(nodeTextInfo, nodeTag, ref node);
			}
			catch {}
		}


		/// <summary>
		/// 根据传入的信息,增加一个新节点
		/// </summary>
		/// <param name="branch">要增加节点的父级节点</param>
		/// <param name="neuObj">节点的Text信息</param>
		/// <param name="obj">节点的Tag属性</param>
		public void AddTreeNode(int branch, neusoft.neuFC.Object.neuObject nodeTextInfo, object nodeTag) {
			System.Windows.Forms.TreeNode node=new System.Windows.Forms.TreeNode();
			//生产要添加的节点
			this.CreateNodeInfo(nodeTextInfo, nodeTag, ref node);
				
			//指定当前选中的节点
			try {
				this.SelectedNode=this.Nodes[branch];
			}
			catch {
				this.Nodes.Add(new System.Windows.Forms.TreeNode("患者"));
				this.SelectedNode=this.Nodes[0];
			}

			//在选中的节点上增加新节点
			this.SelectedNode.Nodes.Add(node);
		}


		/// <summary>
		/// 根据传入参数,创建节点信息
		/// </summary>
		/// <param name="neuObj">节点Text信息:obj.id ,name,memo=bed,user01=dept,user02=status user03=sex </param>
		/// <param name="obj">节点的Tag属性</param>
		/// <param name="node">返回参数:节点</param>
		private void CreateNodeInfo(neusoft.neuFC.Object.neuObject neuObj, object obj, ref System.Windows.Forms.TreeNode node) {
			//如果传入节点为空,则新建一个节点
			if(node == null) 
				node = new System.Windows.Forms.TreeNode();

			#region 生成节点的Text
			string strText = neuObj.Name; //患者姓名
			string strMemo="";
			switch(this.myShowType.GetHashCode()) {
				case 1:
					//住院号
					strMemo="【"+neuObj.ID+"】";
					break;
				case 3:
					//科室
					if(neuObj.User01!="" || neuObj.User01!=null) strMemo="【"+neuObj.User01+"】";
					break;
				case 5:
					//病床
					if(neuObj.Memo!="" || neuObj.Memo!=null) { 
						strMemo = neuObj.Memo;

						if(strMemo.Length > 4) {
							strMemo = strMemo.Substring(4);
						}
						#region
						//						int tempBedNo = 0;
						//						try
						//						{
						//							tempBedNo = Convert.ToInt32(strMemo);
						//
						//							strMemo = tempBedNo.ToString();
						//						}
						//						catch(Exception e)
						//						{
						//							strMemo = "【"+neuObj.Memo+"】";
						//							break;
						//						}
						#endregion
						strMemo="【"+strMemo+"】";
					}
					break;
				case 7:
					//状态
					strMemo="【"+neuObj.User02+"】";
					break;
				case 4:
					//科室+住院号
					strMemo="【"+neuObj.User01+"】"+"【"+neuObj.ID+"】";
					break;
				case 6:
					//病床+住院号
					if(neuObj.Memo!="" || neuObj.Memo!=null) 
						strMemo="【"+neuObj.Memo.Substring(4)+"】"+"【"+neuObj.ID+"】";
					else
						strMemo="【"+neuObj.ID+"】";
					break;
				case 8:
					//住院号+状态
					strMemo="【"+neuObj.ID+"】"+"【"+neuObj.User02+"】";
					break;
				case 10:
					//科室+状态
					strMemo="【"+neuObj.User01 +"】"+"【"+neuObj.User02+"】";
					break;
				case 12:
					//病床+状态
					if(neuObj.Memo!="" || neuObj.Memo!=null) 
						strMemo="【"+neuObj.Memo.Substring(4)+"】"+"【"+neuObj.User02 +"】";
					else
						strMemo="【"+neuObj.User02+"】";
					break;
				default:
					strMemo = "";
					break;
			}

			//根据显示位置,确定最终的名称
			if(this.myDirection==enuShowDirection.Behind) {
				strText = strText+strMemo;
			}
			else {
				strText=strMemo+strText;
			}
			node.Text = strText;
			#endregion

			//生产节点的ImageIndex
			switch(neuObj.User03) {
				case "F":
					node.ImageIndex=this.FemaleImageIndex;
					break;
				case "M":
					node.ImageIndex=this.MaleImageIndex;
					break;
				default:
					node.ImageIndex=this.MaleImageIndex;
					break;
			}

			//生产节点的SelectedImageIndex
			node.SelectedImageIndex = node.ImageIndex + 1;

			//生产节点的Tag属性
			node.Tag = obj;
		}


		/// <summary>
		/// 添加根节点
		/// </summary>
		private void AddRootNode() {
			this.Nodes.Add(new System.Windows.Forms.TreeNode("患者"));
		}


		/// <summary>
		/// 初始化
		/// </summary>
		private void init() {
				this.ImageList=this.imageList1;
				this.HideSelection = false;

			try {
				neusoft.neuFC.Management.Database dataBase = new neusoft.neuFC.Management.Database();
				this.dtToday = dataBase.GetDateTimeFromSysDateTime();
			}
			catch{ 
				this.dtToday= DateTime.Today;
			}
		}


		private void tvPatientList_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			if(this.CheckBoxes && this.bControlChecked==false) {
				foreach(System.Windows.Forms.TreeNode node in e.Node.Nodes) {
					node.Checked=e.Node.Checked;
				}
			}
		}
	}	
}
