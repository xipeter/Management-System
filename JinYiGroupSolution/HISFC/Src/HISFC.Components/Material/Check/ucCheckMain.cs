using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Material.Check
{
    public partial class ucCheckMain : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucCheckMain()
        {
            InitializeComponent();
        }
        /*
        #region 域变量
        //权限科室
        private Neusoft.NFC.Object.NeuObject myPrivDept = new Neusoft.NFC.Object.NeuObject();
        //当前操作员
        private string myOperCode;
        //当前库房是否按批号管理,默认按批号管理
        private bool isBatch = true;
        //当前点击盘点单号
        private string nowCheckCode = "";
        /// <summary>
        /// 是否盘点结存权限
        /// </summary>
        private bool isCheckCStore = false;
        Neusoft.HISFC.Management.Material.MetItem myMetItem = new Neusoft.HISFC.Management.Material.MetItem();
        private DateTime dateBegin;
        private DateTime dateEnd;
        #endregion

        #region 方法
        /// <summary>
        ///显示封帐盘点单列表
        /// </summary>
        private void ShowCheckList()
        {
            //清空列表
            this.ucChooseList.tvList.Nodes.Clear();
            //当前忽略对封帐人的判断，检索显示全部封帐盘点单
            ArrayList checkAl;
            try
            {
                checkAl = this.myItem.GetCheckList(this.myPrivDept.ID, "0", "ALL");
                if (checkAl == null)
                {
                    MessageBox.Show(this.myItem.Err);
                    return;
                }
                if (checkAl.Count == 0)
                {
                    this.ucChooseList.tvList.Nodes.Add(new TreeNode("没有封帐盘点单", 0, 0));
                }
                else
                {
                    this.ucChooseList.tvList.Nodes.Add(new TreeNode("封帐盘点单列表", 0, 0));
                    //显示盘点单列表
                    TreeNode newNode;
                    foreach (Neusoft.NFC.Object.NeuObject info in checkAl)
                    {
                        newNode = new TreeNode();
                        //获得封帐人员姓名
                        Neusoft.HISFC.Management.Manager.Person person = new Neusoft.HISFC.Management.Manager.Person();
                        Neusoft.HISFC.Object.RADT.Person personName = person.GetPersonByID(info.Name);
                        if (personName == null)
                        {
                            MessageBox.Show("获得封帐人员信息时出错！人员编码为info.Name的人员不存在");
                            return;
                        }
                        newNode.Text = info.ID + "-" + personName.Name;		//盘点单号+封帐人
                        newNode.Tag = info.ID;
                        newNode.SelectedImageIndex = newNode.ImageIndex;
                        this.ucChooseList.tvList.Nodes[0].Nodes.Add(newNode);
                    }
                    this.ucChooseList.tvList.Nodes[0].ExpandAll();
                    this.ucChooseList.tvList.SelectedNode = this.ucChooseList.tvList.Nodes[0];
                }
                //显示树型列表
                this.ucChooseList.IsShowTreeView = true;
                this.ucChooseList.Caption = "盘点单列表";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 初始化ucChooseList中DataSet
        /// </summary>
        public  void InitColumns()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");

            //在myDataTable中添加列
            this.ucChooseList.DataTable.Columns.AddRange(new DataColumn[] {
																			   new DataColumn("物资编码",    dtStr),
																			   new DataColumn("物资名称",    dtStr),
																			   new DataColumn("规格",        dtStr),
																			   new DataColumn("批号",        dtStr),
																			   new DataColumn("库位号",      dtStr),
																			   new DataColumn("库存",		 dtStr),
																			   new DataColumn("拼音码",      dtStr),
																			   new DataColumn("五笔码",      dtStr),
																			   new DataColumn("通用名拼音码",dtStr),
																			   new DataColumn("通用名五笔码",dtStr)
																		   });
        }


        /// <summary>
        /// 由库存药品列表内选择一条药品加入封帐记录
        /// </summary>
        /// <param name="row">选中的行索引</param>
        public  void ChooseData(int row)
        {
            this.dateBegin = this.ucCheckManager1.dtBegin.Value;
            this.dateEnd = this.ucCheckManager1.dtEnd.Value;
            if (row < 0) return;
            string itemCode = this.ucChooseList.fpChooseList_Sheet1.Cells[row, 0].Text;
            string batchNo = this.ucChooseList.fpChooseList_Sheet1.Cells[row, 3].Text;
            string placeCode = this.ucChooseList.fpChooseList_Sheet1.Cells[row, 4].Text;
            string checkCode = this.myMetItem.GetMaxCheckStoreCode(this.myPrivDept.ID);
            //加入盘点明细记录封帐处理
            this.ucCheckManager1.AddData(this.myPrivDept.ID, itemCode, checkCode, this.dateBegin, this.dateEnd, batchNo, placeCode, this.isBatch);
        }


        /// <summary>
        /// 判断操作员在当前科室是否存在权限
        /// </summary>
        /// <param name="privClass2Code">二级权限码</param>
        /// <returns>存在权限返回True 否则返回False</returns>
        private bool JudgePriv(string privClass2Code)
        {
            ArrayList al = Neusoft.Common.Class.Function.ChoosePivDept(privClass2Code);
            if (al == null || al.Count <= 0)
                return false;
            foreach (Neusoft.NFC.Object.NeuObject info in al)
            {
                if (info.ID == this.myPrivDept.ID)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 设置工具栏的显示
        /// </summary>
        /// <param name="buttonName">点击的按钮</param>
        private void SetToolBatButton(string buttonName)
        {
            //			this.tbbAddSave.Visible = true;
            //			this.tbbSave.Visible = false;
            //			this.tbbCheckClose.Visible = false;
            //			this.tbbCheckAdd.Visible = false;
            //			//盘点结存权限
            //			if(this.JudgePriv("0306"))	
            //			{
            //				this.tbbSave.Visible = true;
            //				this.tbbAddSave.Visible = false;
            //				this.tbbCheckClose.Visible = true;
            //				this.tbbCheckAdd.Visible = true;
            //			}

            switch (buttonName)
            {
                case "tbbCheckClose":		//封帐按钮
                    this.tbbCheckClose.Visible = false;			//封帐
                    this.tbbGroup.Visible = false;				//批量封帐
                    //this.tbbDrug.Visible = true;				//药品
                    this.tbbList.Visible = true;				//盘点列表
                    this.tbbCheckAdd.Visible = false;			//盘点模板
                    this.ucCheckManager1.AllowDel = true;		//允许对FarPoint内数据删除
                    this.tbbDel.Visible = true;					//删除按钮
                    this.tbPrint.Visible = false;				//打印
                    //this.tbbAddSave.Visible = false;			//增量保存
                    this.tbShow.Visible = true;
                    break;
                case "tbbList":				//盘点列表按钮
                    this.tbbCheckClose.Visible = true;			//封帐
                    this.tbbGroup.Visible = false;				//批量封帐
                    //this.tbbDrug.Visible = false;				//药品
                    this.tbbList.Visible = false;				//盘点列表
                    this.tbbCheckAdd.Visible = false;			//盘点模板
                    this.ucCheckManager1.AllowDel = false;		//不允许对FarPoint内数据删除
                    this.tbbDel.Visible = true;				//删除按钮
                    this.tbPrint.Visible = true;				//打印
                    //this.tbbAddSave.Visible = true;				//增量保存
                    this.tbShow.Visible = true;
                    break;
                case "Init":				//初始化
                    this.tbbCheckClose.Visible = true;
                    this.tbbCheck.Visible = false;
                    this.tbbDrug.Visible = false;
                    this.tbbList.Visible = false;
                    this.tbbCheckAdd.Visible = false;
                    this.tbbGroup.Visible = false;
                    this.tbbDel.Visible = true;
                    //this.tbbAddSave.Visible = true;				//增量保存
                    this.tbShow.Visible = true;
                    break;
            }

            //剂型分类按钮的显示与批量封帐显示相同
            //this.tbbDosageClass.Visible = this.tbbGroup.Visible;
            //this.tbbChecHistoryList.Visible = this.tbbGroup.Visible;
            this.tbbOpen.Visible = this.tbbGroup.Visible;
        }


        /// <summary>
        /// 根据剂型大类 设置批量盘点封帐
        /// </summary>
        public void SetDosageClass()
        {
            /////---liuxq---/////
            //			DialogResult rs = MessageBox.Show("批量分类将清除当前的数据 是否继续?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            //			if (rs == DialogResult.No)
            //				return;
            //
            //			try
            //			{
            //				Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在加载分类界面及数据 请稍候...");
            //				Application.DoEvents();
            //
            //				ucDosageClass uc = new ucDosageClass();
            //			
            //				Neusoft.HISFC.Management.Pharmacy.Item itemManager = new Neusoft.HISFC.Management.Pharmacy.Item();
            //				ArrayList alItem = itemManager.GetStorageList(this.myPrivDept.ID,this.isBatch);
            //				ArrayList alItemDetail = new ArrayList();
            //				int i = 1;
            //				foreach(Neusoft.HISFC.Object.Pharmacy.Item item in alItem)
            //				{
            //					i++;
            //					Neusoft.NFC.Interface.Classes.Function.ShowWaitForm(i,alItem.Count);
            //					Application.DoEvents();
            //
            //					Neusoft.HISFC.Object.Pharmacy.Item itemDetail = itemManager.GetItem(item.ID);
            //					if (itemDetail == null)
            //					{
            //						MessageBox.Show("药品字典内无数据" + item.Name + "-" + item.ID);
            //						continue;
            //					}
            //					alItemDetail.Add(itemDetail);
            //				}
            //				uc.OrignData = alItemDetail;
            //
            //				Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            //
            //				Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);
            //				if (uc.ConvertData != null)
            //				{
            //					Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在按选择的分类进行药品封帐处理..请稍候");
            //					Application.DoEvents();
            //
            //					this.ucCheckManager1.ClearData();
            //					foreach(Neusoft.HISFC.Object.Pharmacy.Item item in uc.ConvertData)
            //					{
            //						this.ucCheckManager1.AddData(this.myPrivDept.ID,item.ID,item.User01,item.User02,this.isBatch);
            //					}
            //
            //					Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            //				}
            //			}
            //			catch (Exception ex)
            //			{
            //				MessageBox.Show(ex.Message);
            //			}
            //			finally
            //			{
            //				Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            //			}
        }


        /// <summary>
        /// 获取历史单据记录
        /// </summary>
        public void ShowHistoryList()
        {
            DialogResult rs = MessageBox.Show("批量分类将清除当前的数据 是否继续?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            Neusoft.HISFC.Management.Pharmacy.Item itemManager = new Neusoft.HISFC.Management.Pharmacy.Item();
            ArrayList alCheck = new ArrayList();
            alCheck = itemManager.GetCheckList(this.myPrivDept.ID, "0", "ALL");
            if (alCheck == null)
            {
                MessageBox.Show(itemManager.Err);
                return;
            }
            ArrayList alInfo = new ArrayList();
            foreach (Neusoft.NFC.Object.NeuObject info in alCheck)
            {
                Neusoft.NFC.Object.NeuObject temp = new Neusoft.NFC.Object.NeuObject();
                //获得封帐人员姓名
                Neusoft.HISFC.Management.Manager.Person person = new Neusoft.HISFC.Management.Manager.Person();
                Neusoft.HISFC.Object.RADT.Person personName = person.GetPersonByID(info.Name);
                if (personName == null)
                {
                    MessageBox.Show("获得封帐人员信息时出错");
                    return;
                }
                temp.ID = info.ID;
                temp.Name = personName.Name;		//盘点单号+封帐人

                alInfo.Add(temp);
            }

            Neusoft.NFC.Object.NeuObject selectObj = new Neusoft.NFC.Object.NeuObject();
            string[] label = { "单据号", "封帐人" };
            float[] width = { 120F, 100F };
            bool[] visible = { true, true, false, false, false, false };
            ///---liuxq---///
            //			if (Function.ChooseItem(alInfo,label,width,visible,ref selectObj) == 0) 
            //			{
            //				return;
            //			}
            //			else 
            //			{				
            //				ArrayList al = new ArrayList();
            //			
            //				al = this.myItem.GetCheckDetailByCheckCode(this.myPrivDept.ID,selectObj.ID);
            //				if (al == null)
            //				{
            //					MessageBox.Show(this.myItem.Err);
            //					return;
            //				}
            //				Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在根据所选盘点单进行封帐处理...");
            //				Application.DoEvents();
            //				int i = 1;
            //				foreach(Neusoft.HISFC.Object.Pharmacy.Check checkInfo in al)
            //				{
            //					Neusoft.NFC.Interface.Classes.Function.ShowWaitForm(i,al.Count);
            //					Application.DoEvents();
            //
            //					this.ucCheckManager1.AddData(this.myPrivDept.ID,checkInfo.Item.ID,checkInfo.BatchNo,checkInfo.PlaceCode,this.isBatch);
            //				}
            //
            //				Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            //			}

        }


       
        /// <summary>
        /// 批量封帐（左边列表栏内数据，逐条添加）
        /// </summary>
        public void ShowItemAll()
        {
            this.dateBegin = this.ucCheckManager1.dtBegin.Value;
            this.dateEnd = this.ucCheckManager1.dtEnd.Value;

            string checkCode = this.myMetItem.GetMaxCheckStoreCode(this.myPrivDept.ID);

            if (this.ucChooseList.fpChooseList_Sheet1.RowCount <= 0)
                return;
            for (int i = 0; i < this.ucChooseList.fpChooseList_Sheet1.RowCount; i++)
            {
                string itemCode = this.ucChooseList.fpChooseList_Sheet1.Cells[i, 0].Text;
                string batchNo = this.ucChooseList.fpChooseList_Sheet1.Cells[i, 3].Text;
                string placeCode = this.ucChooseList.fpChooseList_Sheet1.Cells[i, 4].Text;
                this.ucCheckManager1.AddData(this.myPrivDept.ID, itemCode, checkCode, this.dateBegin, this.dateEnd, batchNo, placeCode, this.isBatch);
            }
        }
        #endregion

        private void ucCheckMain_Load(object sender, EventArgs e)
        {
            //定义事件
            this.ucChooseList.tvList.AfterSelect += new TreeViewEventHandler(tvList_AfterSelect);

            #region 判断权限并获取操作员信息
            //判断操作员是否拥有盘点权限，如果没有则不允许操作此窗口
            int privParm = Neusoft.Common.Class.Function.ChoosePivDept("0505", ref myPrivDept, this);
            if (privParm == 0)
                return;

            this.ucCheckManager1.myPrivDept = this.myPrivDept;
            try
            {
                Neusoft.NFC.Management.DataBaseManger data = new Neusoft.NFC.Management.DataBaseManger();
                this.myOperCode = ((Neusoft.HISFC.Object.RADT.Person)data.Operator).ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            //获得库房控制参数，判断对该库房是否按批号管理
            Neusoft.HISFC.Management.Manager.Controler ctrlMgr = new Neusoft.HISFC.Management.Manager.Controler();
            string ctrlStr = ctrlMgr.QueryControlerInfo("510001");
            if (ctrlStr == "1")
                this.isBatch = true;
            else
                this.isBatch = false;

            this.isCheckCStore = this.JudgePriv("0505");

            //初始化工具栏
            this.SetToolBatButton("Init");

            if (!this.isCheckCStore)
            {
                this.tbbCheckClose.Visible = false;
                this.tbbSave.Visible = false;
                this.tbbCheckAdd.Visible = false;
            }
            else
            {
                this.tbbAddSave.Visible = false;
            }

            this.ucCheckManager1.IsWindowCheck = !this.isCheckCStore;


            //显示树型列表
            this.ShowCheckList();
            //显示库存药品列表
            this.ShowDeptStorage(this.myPrivDept.ID, this.isBatch);
            int iWidth = 0;
            this.ucChooseList.GetColumnWidth(2, ref iWidth);
            if (iWidth > 0)
                this.panelLeft.Width = iWidth + 5;
            this.ucCheckManager1.dtBegin.Value = Neusoft.NFC.Function.NConvert.ToDateTime(this.myMetItem.GetMaxCheckStoreDate(this.myPrivDept.ID));
            this.ucCheckManager1.dtEnd.Value = this.myMetItem.GetDateTimeFromSysDateTime();
            this.dateBegin = this.ucCheckManager1.dtBegin.Value;
            this.dateEnd = this.ucCheckManager1.dtEnd.Value;

            #region 设置ucCheckManager参数
            //格式化FarPoint显示
            this.ucCheckManager1.SetFormat();
            //是否允许对盘点数量编辑
            this.ucCheckManager1.AllowEdit = true;
            //初始不允许对FarPoint内数据删除
            this.ucCheckManager1.AllowDel = false;

            #endregion
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //点击根节点
            if (e.Node.Parent == null)
            {
                this.ucCheckManager1.ClearData();
                return;
            }
            //盘点单号
            this.nowCheckCode = e.Node.Tag.ToString();
            if (this.nowCheckCode == "" || this.nowCheckCode == null)
                return;
            this.ucCheckManager1.ClearData();		//清空数据
            this.ucCheckManager1.ShowCheckDetail(this.myPrivDept.ID, this.nowCheckCode);
        }
         * */
    }
}
