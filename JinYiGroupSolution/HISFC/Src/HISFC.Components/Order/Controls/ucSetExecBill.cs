using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucSetExecBill : Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        private Neusoft.FrameWork.Models.NeuObject objExecBill = new Neusoft.FrameWork.Models.NeuObject();
        private Neusoft.FrameWork.Public.ObjectHelper helper;
        private Neusoft.HISFC.BizProcess.Integrate.Manager costManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizLogic.Order.ExecBill oCExecBill = new Neusoft.HISFC.BizLogic.Order.ExecBill();
        private ArrayList alItem = new ArrayList();
        private TreeNode tnItemList = new TreeNode();
        private TreeNode tnDragType = new TreeNode();
        private TreeNode tnConstant = new TreeNode();
        private int icont = 0;

        /// <summary>
        /// 在实现接口中使用的变量
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.ExecBill oExecBill = new Neusoft.HISFC.BizLogic.Order.ExecBill();

        //*********************************
        public static string strName = "";
        //*********************************

        public ucSetExecBill()
        {
            InitializeComponent();
        }

        #region 函数
        private void LoadTab()
        {
        }
        private void AddInfo(int Branch, Neusoft.FrameWork.Models.NeuObject neuObj, object obj)
        {
            string strText = neuObj.Name;

        }
        private void AddTreeNode(int root, string Name, object obj, int ImageIndex)
        {
            System.Windows.Forms.TreeNode Node = new System.Windows.Forms.TreeNode();
            try
            {
                Node.Text = Name;
                Node.Tag = obj;
            }
            catch { }
        }
        private void AddRootNode()
        {
            this.tvDrug.Nodes.Add("药物执行单项目选择");
            this.tvUndrug.Nodes.Add("非药物执行单项目选择");
        }
        #endregion

        #region 方法

        private void Filter(int index)
        {

            for (int i = 0; i < this.neuSpread1.Sheets[index].RowCount; i++)
            {
                string str1 = this.neuSpread1.Sheets[index].Cells[i, 1].Text;
                string str2 = this.neuSpread1.Sheets[index].Cells[i, 2].Text;
                string str3 = this.neuSpread1.Sheets[index].Cells[i, 3].Text;
                if (str3 != "")//药品
                {
                    foreach (TreeNode node in this.tvDrug.Nodes)
                    {
                        if (str1 == node.Text)
                        {
                            foreach (TreeNode childnode in node.Nodes)
                            {
                                if (str2 == childnode.Text)
                                {
                                    foreach (TreeNode n in childnode.Nodes)
                                    {
                                        if (str3 == n.Text)
                                        {
                                            n.Remove();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else//非药品
                {
                    foreach (TreeNode node in this.tvUndrug.Nodes)
                    {
                        if (str1 == node.Text)
                        {
                            foreach (TreeNode childnode in node.Nodes)
                            {
                                if (str2 == childnode.Text)
                                {
                                    childnode.Remove();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private ArrayList GetFpSheet()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < this.neuSpread1.Sheets.Count; i++)
            {
                al.Add(this.neuSpread1.Sheets[i].SheetName.Trim());
            }
            return al;
        }

        private bool IsRepeat()
        {
            bool bRet = true;
            for (int i = 0; i < this.neuSpread1.Sheets.Count; i++)
            {
                if (txtExecBillName.Text.Trim() == this.neuSpread1.Sheets[i].SheetName.Trim())
                {
                    MessageBox.Show("名字重复！");
                    bRet = false;
                    grpExecBillD.Visible = true;
                }
            }
            return bRet;
        }

        /// <summary>
        /// 初始化Tree
        /// </summary>
        private void InitTree()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager oOrderType = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizProcess.Integrate.Manager oConstant = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            Enum enDrug = Neusoft.HISFC.Models.Base.EnumSysClass.P;
            //enDrug.ToString();
            arrDrugType.AddRange(this.alItem);

            //获得项目类别列表：
            arrOrderType = oOrderType.QueryOrderTypeList();

            //获得用法列表：
            arrConstant = oConstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
            arrItemList = Neusoft.HISFC.Models.Base.SysClassEnumService.List();

            //刷新显示
            this.RefreshList();
            //过滤所有已经有的
            for (int i = 0; i < this.neuSpread1.Sheets.Count; i++)
                this.Filter(i);
        }

        private void RefreshList()
        {
            this.tvDrug.Nodes.Clear();
            this.tvUndrug.Nodes.Clear();
            //非药物执行单
            try
            {
                for (int i = 0; i < arrOrderType.Count; i++)
                {
                    TreeNode node = new TreeNode(arrOrderType[i].ToString());
                    node.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrOrderType[i]).ID.ToString();

                    for (int j = 0; j < arrItemList.Count; j++)
                    {
                        if (((Neusoft.FrameWork.Models.NeuObject)arrItemList[j]).ID.Substring(0, 1) != "P")
                        {
                            tnItemList = new TreeNode(arrItemList[j].ToString());
                            //tnItemList.Tag = ((Neusoft.HISFC.Models.Base.EnumSysClass)arrItemList[j]).ID.ToString();
                            tnItemList.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrItemList[j]).ID.ToString();
                            node.Nodes.Add(tnItemList);
                        }
                    }
                    this.tvUndrug.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误！" + ex.Message);
            }

            //药物执行单
            try
            {
                for (int i = 0; i < arrOrderType.Count; i++)
                {
                    TreeNode node = new TreeNode(arrOrderType[i].ToString());
                    node.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrOrderType[i]).ID.ToString();
                    //node.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrConstant[i]).ID.ToString();//[2007/01/15]xuweizhe

                    for (int j = 0; j < arrDrugType.Count; j++)
                    {
                        tnDragType = new TreeNode(arrDrugType[j].ToString());
                        tnDragType.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrDrugType[j]).ID.ToString();
                        for (int k = 0; k < arrConstant.Count; k++)
                        {
                            tnConstant = new TreeNode(arrConstant[k].ToString());
                            tnConstant.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrConstant[k]).ID.ToString();
                            tnDragType.Nodes.Add(tnConstant);
                        }
                        node.Nodes.Add(tnDragType);
                    }
                    this.tvDrug.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误！" + ex.Message);
            }

            #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
            //非药物项目执行单
            try
            {
                for (int i = 0; i < arrOrderType.Count; i++)
                {
                    TreeNode node = new TreeNode(arrOrderType[i].ToString());
                    node.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrOrderType[i]).ID.ToString();

                    for (int j = 0; j < arrItemList.Count; j++)
                    {
                        if (((Neusoft.FrameWork.Models.NeuObject)arrItemList[j]).ID.Substring(0, 1) != "P")
                        {
                            tnItemList = new TreeNode(arrItemList[j].ToString());
                            //tnItemList.Tag = ((Neusoft.HISFC.Object.Base.EnumSysClass)arrItemList[j]).ID.ToString();
                            tnItemList.Tag = ((Neusoft.FrameWork.Models.NeuObject)arrItemList[j]).ID.ToString();
                            node.Nodes.Add(tnItemList);
                        }
                    }
                    this.tvUndrugItem.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误！" + ex.Message);
            }
            #endregion
        }

        private void InitControl()
        {
            this.alItem = this.costManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            helper = new Neusoft.FrameWork.Public.ObjectHelper(alItem);
            this.InitTree();

        }

        private int SaveBill()
        {
            if (this.neuSpread1.Sheets.Count == 0) return -1;

            #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
            //如果是项目执行单，已经保存过了
            Neusoft.FrameWork.Models.NeuObject bill = this.neuSpread1.ActiveSheet.Tag as Neusoft.FrameWork.Models.NeuObject;
            if (bill.Memo == "1")
            {
                return 0;
            }
            #endregion

            if (this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].SheetName.Trim() == "" || this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].SheetName.Trim() == null)
            {
                if (this.txtExecBillName.Text.Trim() == "" || this.txtExecBillName.Text.Trim() == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("请输入单子的名称", 211);
                    return -1;
                }
                this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].SheetName = this.txtExecBillName.Text.Trim();
            }

            Neusoft.HISFC.BizLogic.Order.ExecBill oExecBill = new Neusoft.HISFC.BizLogic.Order.ExecBill();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(oExecBill.Connection);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            oExecBill.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            ArrayList al = new ArrayList();
            oExecBill.Name = neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].SheetName.Trim();
            for (int i = 0; i < this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Rows.Count; i++)
            {
                try
                {
                    Neusoft.FrameWork.Models.NeuObject objBill = new Neusoft.FrameWork.Models.NeuObject();
                    //必须填写（objBill.ID 执行单流水号，objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型,

                    objBill.Name = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].SheetName.Trim();//执行单名		
                    if (this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Tag != null)
                        #region {46983F5B-E184-4b8b-B819-AA1C34993F1B}
                        //objBill.ID = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Tag.ToString();
                        objBill.ID = ((Neusoft.FrameWork.Models.NeuObject)this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Tag).ID;
                        #endregion
                    objBill.Memo = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[i, 0].Text.Trim();//执行单类型；
                    //					objBill.Memo = oExecBill.Memo;
                    objBill.User01 = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[i, 1].Tag.ToString(); //医嘱类型,

                    objBill.User02 = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[i, 2].Tag.ToString();//非药系统类别、药品类别,
                    objBill.User03 = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[i, 3].Tag.ToString();//药品用法）
                    al.Add(objBill);
                    objBill = null;
                }
                catch { }
            }
            //Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            //personMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            string personId = oExecBill.Operator.ID;
            //Neusoft.HISFC.Models.Base.Employee person = personMgr.GetEmployeeInfo(personId);
            string strNurse = (oExecBill.Operator as Neusoft.HISFC.Models.Base.Employee).Nurse.ID; //person.Nurse.ID.ToString();
            string BillID = "";//执行单号

            if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag == null)
            {
                //				fpSpread1.Sheets[fpSpread1.ActiveSheetIndex].Tag = oExecBill.GetNewExecBillID();
                this.objExecBill.Name = neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].SheetName.Trim();
                if (oExecBill.SetExecBill(al, this.objExecBill, strNurse, ref BillID) == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag = BillID;
                    //MessageBox.Show("保存成功!");
                    return 0;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                    //MessageBox.Show("错误!" + oExecBill.Err);
                    return -1;
                }
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                for (int i = 0; i < al.Count; i++)
                {
                    obj = (Neusoft.FrameWork.Models.NeuObject)al[i];
                    if (oExecBill.UpdateExecBill(obj, strNurse/*, obj.Memo*/) != 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                        //MessageBox.Show("保存错误!" + oExecBill.Err);
                        return -1;
                    }
                }
                if (this.txtExecBillName.Text.Trim() != "" || this.txtExecBillName.Text.Trim() != null)
                {
                    oExecBill.UpdateExecBillName(obj.ID, this.txtExecBillName.Text.Trim(), obj.User01, obj.User02);
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                //MessageBox.Show("保存成功!");

                return 0;
            }
        }


        private ArrayList arrOrderType = new ArrayList();//医嘱数组
        private ArrayList arrConstant = new ArrayList();//定义用法数组
        private ArrayList arrItemList = new ArrayList();//项目数组
        private ArrayList arrDrugType = new ArrayList();//药品类别
        private ArrayList alExecBill = new ArrayList();//执行单数组

        public bool IsNull(Neusoft.FrameWork.WinForms.Controls.NeuTextBox obj)
        {
            if (obj.Text.Trim() != "")
                return true;
            else
                return false;
        }


        /// <summary>
        /// farP增加
        /// </summary>
        /// <param name="obj">医嘱类型</param>
        /// <param name="i">单子个数</param>
        protected void AddExecBill(Neusoft.HISFC.Models.Order.Inpatient.Order obj, int i)
        {
            this.neuSpread1.Sheets[i].Rows.Add(0, 1);
            this.neuSpread1.Sheets[i].SetValue(0, 0, obj.Memo, false);
            //fpSpread1.Sheets[i].Cells[0,0].Text = obj.Memo.ToString();//执行单类型		
            this.neuSpread1.Sheets[i].SetValue(0, 1, obj.OrderType.Name, false);
            //fpSpread1.Sheets[i].Cells[0,1].Value  = obj.OrderType.Name;//医嘱类型
            this.neuSpread1.Sheets[i].Cells[0, 1].Tag = obj.OrderType.ID;
            if (obj.Memo == "2")
            {
                this.neuSpread1.Sheets[i].SetValue(0, 2, obj.Item.SysClass.Name, false);
                //fpSpread1.Sheets[i].Cells[0,2].Value = obj.Item.SysClass.Name;//药品类型
                this.neuSpread1.Sheets[i].Cells[0, 2].Tag = obj.Item.SysClass.ID;
            }
            else
            {
                this.neuSpread1.Sheets[i].SetValue(0, 2, helper.GetName(obj.Item.User01), false);
                //fpSpread1.Sheets[i].Cells[0,2].Value = obj.Item.SysClass.Name;//药品类型
                this.neuSpread1.Sheets[i].Cells[0, 2].Tag = obj.Item.User01;
            }
            this.neuSpread1.Sheets[i].SetValue(0, 3, obj.Usage.Name, false);
            //fpSpread1.Sheets[i].Cells[0,3].Text = obj.Usage.Name;//服用方法
            this.neuSpread1.Sheets[i].Cells[0, 3].Tag = obj.Usage.ID;
            this.neuSpread1.Sheets[i].SetValue(0, 4, oCExecBill.Operator.Name, false);
            //fpSpread1.Sheets[i].Cells[0,4].Text = oCExecBill.Operator.Name.ToString();//操作员
            this.neuSpread1.Sheets[i].Cells[0, 4].Tag = oCExecBill.Operator.ID.ToString();
            this.neuSpread1.Sheets[i].SetValue(0, 5, DateTime.Now.ToString(), false);
            //fpSpread1.Sheets[i].Cells[0,5].Text = oCExecBill.GetSysDate();//操作时间						
        }

        /// <summary>
        /// 将明细添加到farpoint上面
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="i"></param>
        /// <param name="isItemDetail">是否项目明细执行单 </param>
        protected void AddExecBill(Neusoft.HISFC.Models.Order.Inpatient.Order obj, int i, bool isItemDetail)
        {
            this.neuSpread1.Sheets[i].Rows.Add(0, 1);

            this.neuSpread1.Sheets[i].SetValue(0, 0, obj.Memo, false);	//药品/非药品
            this.neuSpread1.Sheets[i].SetValue(0, 1, obj.OrderType.Name, false); //医嘱类别
            this.neuSpread1.Sheets[i].Cells[0, 1].Tag = obj.OrderType.ID;

            if (obj.Memo == "2")
            {
                this.neuSpread1.Sheets[i].SetValue(0, 2, obj.Item.SysClass.Name, false); //系统类别
                this.neuSpread1.Sheets[i].Cells[0, 2].Tag = obj.Item.SysClass.ID;
            }
            else
            {
                this.neuSpread1.Sheets[i].SetValue(0, 2, helper.GetName(obj.Item.User01), false); //药品类别
                this.neuSpread1.Sheets[i].Cells[0, 2].Tag = obj.Item.User01;
            }

            if (isItemDetail)
            {
                this.neuSpread1.Sheets[i].SetValue(0, 3, obj.Item.Name, false); //项目名称
                this.neuSpread1.Sheets[i].Cells[0, 3].Tag = obj.Item.ID;
                this.neuSpread1.Sheets[i].Rows[0].Tag = obj.Item;
            }
            else
            {
                this.neuSpread1.Sheets[i].SetValue(0, 3, obj.Usage.Name, false); //服法名称
                this.neuSpread1.Sheets[i].Cells[0, 3].Tag = obj.Usage.ID;
            }

            this.neuSpread1.Sheets[i].SetValue(0, 4, oCExecBill.Operator.Name, false);
            this.neuSpread1.Sheets[i].Cells[0, 4].Tag = oCExecBill.Operator.ID.ToString();
            this.neuSpread1.Sheets[i].SetValue(0, 5, DateTime.Now.ToString(), false);
        }


        //private void InitFp(string strBillName, int i, string strID)
        //{46983F5B-E184-4b8b-B819-AA1C34993F1B}
        private void InitFp(Neusoft.FrameWork.Models.NeuObject execBill, int i)
        {
            //			this.fpTreeView1.sv_CellChanged+=new FarPoint.Win.Spread.SheetViewEventHandler(fpTreeView1_sv_CellChanged);

            this.neuSpread1.Sheets.Count = i + 1;
            if (execBill.Name == "")
                this.neuSpread1.Sheets[i].SheetName = " ";
            else
                this.neuSpread1.Sheets[i].SheetName = execBill.Name;
            //			this.fpSpread1.Sheets[i].Tag = 
            this.neuSpread1.Sheets[i].Columns[0].Visible = false;
            this.neuSpread1.Sheets[i].Columns[1].Label = "医嘱类型";
            this.neuSpread1.Sheets[i].Columns[2].Label = "项目类别";
            #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
            //this.neuSpread1.Sheets[i].Columns[3].Label = "服用方法";
            //非药品项目明细执行单
            if (Neusoft.FrameWork.Function.NConvert.ToBoolean(execBill.Memo))
            {
                this.neuSpread1.Sheets[i].Columns[3].Label = "项目名称";
            }
            else
            {
                this.neuSpread1.Sheets[i].Columns[3].Label = "服用方法";
            }
            #endregion
            this.neuSpread1.Sheets[i].Columns[4].Label = "当前操作员";
            this.neuSpread1.Sheets[i].Columns[5].Label = "操作时间";

            this.neuSpread1.Sheets[i].Columns[1].Width = 150;
            this.neuSpread1.Sheets[i].Columns[2].Width = 150;
            this.neuSpread1.Sheets[i].Columns[3].Width = 150;
            this.neuSpread1.Sheets[i].Columns[4].Width = 150;
            this.neuSpread1.Sheets[i].Columns[5].Width = 150;

            this.neuSpread1.Sheets[i].RowCount = 0;
            this.neuSpread1.Sheets[i].ColumnCount = 6;
            this.neuSpread1.Sheets[i].GrayAreaBackColor = Color.WhiteSmoke;

            this.neuSpread1.ActiveSheetIndex = i;
            #region  xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
            //if (strID != "")
            //    this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag = strID;
            //else
            //    this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag = null;

            this.neuSpread1.ActiveSheet.Tag = execBill;
            #endregion
            int im = 3;
            this.neuSpread1.Sheets[i].OperationMode = (FarPoint.Win.Spread.OperationMode)im;
            this.neuSpread1.Sheets[i].SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always);
        }
        private void BindFp()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizLogic.Order.ExecBill oExecBill = new Neusoft.HISFC.BizLogic.Order.ExecBill();
            //			ArrayList alExecBill = new ArrayList();
            string personId = oExecBill.Operator.ID;
            Neusoft.HISFC.Models.Base.Employee person = (oExecBill.Operator as Neusoft.HISFC.Models.Base.Employee);//personMgr.GetPersonByID(personId);
            string strNurse = person.Nurse.ID.ToString();
            alExecBill = oExecBill.QueryExecBill(strNurse);
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            ArrayList arrDetail = new ArrayList();
            for (int i = 0; i < alExecBill.Count; i++)
            {
                #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
                //string strName = ((Neusoft.FrameWork.Models.NeuObject)alExecBill[i]).Name;
                //string strID = ((Neusoft.FrameWork.Models.NeuObject)alExecBill[i]).ID;
                //InitFp(strName, i, strID);
                //arrDetail = oExecBill.QueryExecBillDetail(strID); 
                obj = alExecBill[i] as Neusoft.FrameWork.Models.NeuObject;
                InitFp(obj, i);
                arrDetail = oExecBill.QueryExecBillDetail(obj.ID);
                #endregion
                if (arrDetail != null)
                {
                    for (int j = 0; j < arrDetail.Count; j++)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order objDetail = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                        #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护

                        //objDetail.ID = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).ID;//执行单id
                        //objDetail.Memo = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).Memo;//药品非药品
                        //objDetail.OrderType.ID = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).OrderType.ID;//医嘱类别id
                        //objDetail.OrderType.Name = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).OrderType.Name;//医嘱类别名称
                        //if (objDetail.Memo == "1")                        
                        //    objDetail.Item.User01 = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).Item.User01;//药品类型                        
                        //else                        
                        //    objDetail.Item.SysClass.ID = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).Item.SysClass.ID;//系统类别


                        ////						objDetail.Item.SysClass.Name = ((Neusoft.HISFC.Models.Order.Order)arrDetail[j]).Item.SysClass.Name;//系统类别
                        //objDetail.Usage.ID = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).Usage.ID;//用法id
                        //objDetail.Usage.Name = ((Neusoft.HISFC.Models.Order.Inpatient.Order)arrDetail[j]).Usage.Name;//用法name

                        //AddExecBill(objDetail, i);

                        objDetail = arrDetail[j] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        AddExecBill(objDetail, i, Neusoft.FrameWork.Function.NConvert.ToBoolean(obj.Memo));

                        #endregion
                    }
                }
                icont = alExecBill.Count;
            }

        }


        #endregion

        #region 属性

        public string ExeBillName
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }
        #endregion

        #region 事件

        private void EventResultChanged(ArrayList al)
        {

        }

        private void PrintInfo()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPreview(this.neuPanel2);
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.neuSpread1.ActiveSheet == null) return;
            if (this.neuSpread1.ActiveSheet.ActiveRow == null) return;

            DialogResult result;
            result = MessageBox.Show("是否删除数据", "确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //医嘱类型
                string orderType = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 1].Text;
                //系统类别
                string sysClass = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 2].Text;
                //使用方法
                string usage = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 3].Text;

                //恢复到树型列表中
                if (this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 0].Text == "1")
                {
                    foreach (TreeNode node in this.tvDrug.Nodes)
                    {
                        if (orderType == node.Text)
                        {
                            foreach (TreeNode childnode in node.Nodes)
                            {
                                if (sysClass == childnode.Text)
                                {
                                    TreeNode obj = new TreeNode(usage);
                                    obj.Tag = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 3].Tag.ToString();
                                    childnode.Nodes.Add(obj);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    foreach (TreeNode node in this.tvUndrug.Nodes)
                    {
                        if (orderType == node.Text)
                        {
                            TreeNode obj = new TreeNode(sysClass);
                            obj.Tag = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 2].Tag.ToString();
                            node.Nodes.Add(obj);
                            break;
                        }
                    }
                }
                if (neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Tag != null)
                {
                    string exeBillID = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Tag.ToString();//执行单号
                    if (exeBillID != null && exeBillID != "")
                    {
                        Neusoft.HISFC.BizLogic.Order.ExecBill billMgr = new Neusoft.HISFC.BizLogic.Order.ExecBill();
                        //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(billMgr.Connection);
                        //t.BeginTransaction();
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        billMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                        Neusoft.FrameWork.Models.NeuObject objBill = new Neusoft.FrameWork.Models.NeuObject();
                        //必须填写（objBill.ID 执行单流水号，objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型,
                        // objBill.user02非药系统类别、药品类别,objBill.user03 药品用法）			
                        objBill.Name = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].SheetName.Trim();//执行单名		
                        objBill.ID = exeBillID;
                        objBill.Memo = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 0].Text.Trim();//执行单类型；
                        objBill.User01 = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 1].Tag.ToString(); //医嘱类型,
                        objBill.User02 = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 2].Tag.ToString();//非药系统类别、药品类别,
                        objBill.User03 = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 3].Tag.ToString();//药品用法）

                        if (billMgr.DeleteExecBill(objBill) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                            MessageBox.Show(billMgr.Err, "提示");
                            return;
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                    }
                }
                neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Rows.Remove(neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].ActiveRowIndex, 1);
            }
        }

        private void ucSetExecBill_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitControl();
                //if((Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager)
                //    this.btnDelete.Visible = true;
                //else
                //    this.btnDelete.Visible = false;
                grpExecBillD.Visible = false;
                grpExecBillName.Visible = true;
                tabItemType.Visible = true;
                BindFp();
                grpExecBillD.Visible = true;
                if (this.neuSpread1.Sheets.Count > 0)
                {
                    for (int index = 0; index < this.neuSpread1.Sheets.Count; index++)
                    {
                        #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护

                        if (this.neuSpread1.Sheets[index].Tag == null) { return; }
                        Neusoft.FrameWork.Models.NeuObject execBill = this.neuSpread1.Sheets[index].Tag as Neusoft.FrameWork.Models.NeuObject;
                        if (Neusoft.FrameWork.Function.NConvert.ToBoolean(execBill.Memo))
                        {
                        }
                        else
                        {
                            this.Filter(index);
                        }

                        #endregion
                    }
                    this.neuSpread1.ActiveSheetIndex = 0;
                    this.txtExecBillName.Text = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].SheetName;
                    #region  {46983F5B-E184-4b8b-B819-AA1C34993F1B}
                    if (this.neuSpread1.Sheets.Count == 1)
                    {
                        this.SetTabVisible();
                    }
                    #endregion
                }
            }
            catch { }

        }

        private void tvDrug_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.neuSpread1.Sheets.Count == 0) return;
            #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
            if (this.neuSpread1.ActiveSheet.Tag == null)
            {
                MessageBox.Show("请选择执行单!");
                return;
            }
            if (this.tvDrug.SelectedNode == null)
            {
                return;
            }
            #endregion
            Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            if (this.tvDrug.SelectedNode.Parent != null)
            {
                //叶子节点---服用方法
                if (this.tvDrug.SelectedNode.Parent.Parent != null && this.tvDrug.SelectedNode.Parent != null)
                {
                    ArrayList alTree = new ArrayList();
                    obj.ID = "";//执行单id
                    obj.Memo = "1";//药品非药品
                    obj.OrderType.ID = this.tvDrug.SelectedNode.Parent.Parent.Tag.ToString();//医嘱类别id
                    obj.OrderType.Name = this.tvDrug.SelectedNode.Parent.Parent.Text;//医嘱类别名称
                    //[xuweizhe]obj.Item.SysClass.ID = this.tvDrug.SelectedNode.Parent.Tag.ToString();//系统类别
                    obj.Item.User01 = this.tvDrug.SelectedNode.Parent.Tag.ToString();
                    obj.Usage.ID = this.tvDrug.SelectedNode.Tag.ToString();//用法id
                    obj.Usage.Name = this.tvDrug.SelectedNode.Text;
                    AddExecBill(obj, this.neuSpread1.ActiveSheetIndex);
                    this.tvDrug.SelectedNode.Parent.Nodes.RemoveAt(this.tvDrug.SelectedNode.Index);
                }
                else if (this.tvDrug.SelectedNode.Parent != null)
                {
                    //药品类型节点
                    string[] arrAll = new string[this.tvDrug.SelectedNode.Nodes.Count];
                    for (int i = this.tvDrug.SelectedNode.Nodes.Count - 1; i >= 0; i--)
                    {
                        obj.ID = "";//执行单id
                        obj.Memo = "1";//药品非药品
                        obj.OrderType.ID = this.tvDrug.SelectedNode.Parent.Tag.ToString();//医嘱类别id
                        obj.OrderType.Name = this.tvDrug.SelectedNode.Parent.Text;//医嘱类别名称
                        //[xuweizhe]obj.Item.SysClass.ID = this.tvDrug.SelectedNode.Tag.ToString();//系统类别
                        obj.Usage.ID = this.tvDrug.SelectedNode.Nodes[i].Tag.ToString();//用法id
                        obj.Usage.Name = this.tvDrug.SelectedNode.Nodes[i].Text;
                        obj.Item.User01 = this.tvDrug.SelectedNode.Tag.ToString();
                        AddExecBill(obj, this.neuSpread1.ActiveSheetIndex);
                        this.tvDrug.SelectedNode.Nodes[i].Remove();
                    }
                }
            }
        }

        private void tvUndrug_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.neuSpread1.Sheets.Count == 0) return;
            #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
            if (this.neuSpread1.ActiveSheet.Tag == null)
            {
                MessageBox.Show("请选择执行单!");
                return;
            }

            if (this.tvUndrug.SelectedNode == null)
            {
                return;
            }
            #endregion
            Neusoft.HISFC.Models.Order.Inpatient.Order obj = new Neusoft.HISFC.Models.Order.Inpatient.Order();

            if (this.tvUndrug.SelectedNode.Parent != null)
            {
                ArrayList alTree = new ArrayList();
                obj.ID = "";//执行单id
                obj.Memo = "2";//药品非药品
                obj.OrderType.ID = this.tvUndrug.SelectedNode.Parent.Tag.ToString();//医嘱类别id
                obj.OrderType.Name = tvUndrug.SelectedNode.Parent.Text;//医嘱类别名称
                obj.Item.SysClass.ID = tvUndrug.SelectedNode.Tag.ToString();//系统类别
                AddExecBill(obj, this.neuSpread1.ActiveSheetIndex);
                tvUndrug.SelectedNode.Parent.Nodes.RemoveAt(tvUndrug.SelectedNode.Index);
            }
            else
            {
                for (int i = this.tvUndrug.SelectedNode.Nodes.Count - 1; i >= 0; i--)
                {
                    obj.ID = "";//执行单id
                    obj.Memo = "2";//药品非药品
                    obj.OrderType.ID = this.tvUndrug.SelectedNode.Tag.ToString();//医嘱类别id
                    obj.OrderType.Name = tvUndrug.SelectedNode.Text;//医嘱类别名称
                    obj.Item.SysClass.ID = tvUndrug.SelectedNode.Nodes[i].Tag.ToString();//系统类别

                    AddExecBill(obj, this.neuSpread1.ActiveSheetIndex);
                    this.tvUndrug.SelectedNode.Nodes[i].Remove();
                }
            }
        }

        private void neuSpread1_ActiveSheetChanging(object sender, FarPoint.Win.Spread.ActiveSheetChangingEventArgs e)
        {
            if (this.neuSpread1.ActiveSheet != null)
            {
                if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag == null)
                {
                    DialogResult result;
                    if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Rows.Count > 0)
                    {
                        result = MessageBox.Show("数据已被修改且尚未存盘，现在保存吗？", "确认", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            SaveBill();
                        }
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            this.txtExecBillName.Text = this.neuSpread1.Sheets[e.ActivatedSheetIndex].SheetName;
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.neuSpread1.ActiveSheet == null) return;
            if (this.neuSpread1.ActiveSheet.ActiveRow == null) return;

            DialogResult result;
            result = MessageBox.Show("是否删除数据", "确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //医嘱类型
                string orderType = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 1].Text;
                //系统类别
                string sysClass = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 2].Text;
                //使用方法
                string usage = this.neuSpread1.Sheets[neuSpread1.ActiveSheetIndex].Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 3].Text;
                #region {46983F5B-E184-4b8b-B819-AA1C34993F1B}
                if (((Neusoft.FrameWork.Models.NeuObject)this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag).Memo != "1")
                {//当前页不是单项目类型
                    //恢复到树型列表中
                    if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 0].Text == "1")
                    {
                        foreach (TreeNode node in this.tvDrug.Nodes)
                        {
                            if (orderType == node.Text)
                            {
                                foreach (TreeNode childnode in node.Nodes)
                                {
                                    if (sysClass == childnode.Text)
                                    {
                                        TreeNode obj = new TreeNode(usage);
                                        obj.Tag = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 3].Tag.ToString();
                                        childnode.Nodes.Add(obj);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (TreeNode node in this.tvUndrug.Nodes)
                        {
                            if (orderType == node.Text)
                            {
                                TreeNode obj = new TreeNode(sysClass);
                                obj.Tag = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, 2].Tag.ToString();
                                node.Nodes.Add(obj);
                                break;
                            }
                        }
                    }
                }
                #endregion
                if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag != null)
                {
                    #region {46983F5B-E184-4b8b-B819-AA1C34993F1B}
                    //string exeBillID = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag.ToString();//执行单号
                    string exeBillID = ((Neusoft.FrameWork.Models.NeuObject)this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag).ID;//执行单号
                    #endregion
                    if (exeBillID != null && exeBillID != "")
                    {
                        Neusoft.HISFC.BizLogic.Order.ExecBill billMgr = new Neusoft.HISFC.BizLogic.Order.ExecBill();
                        //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(billMgr.Connection);
                        //t.BeginTransaction();
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        billMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                        Neusoft.FrameWork.Models.NeuObject objBill = new Neusoft.FrameWork.Models.NeuObject();
                        //必须填写（objBill.ID 执行单流水号，objBill.Memo执行单类型，1药/2非药,objBill.user01 医嘱类型,
                        // objBill.user02非药系统类别、药品类别,objBill.user03 药品用法）			
                        objBill.Name = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].SheetName.Trim();//执行单名		
                        objBill.ID = exeBillID;
                        objBill.Memo = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 0].Text.Trim();//执行单类型；
                        objBill.User01 = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 1].Tag.ToString(); //医嘱类型,
                        objBill.User02 = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 2].Tag.ToString();//非药系统类别、药品类别,
                        objBill.User03 = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Cells[neuSpread1.ActiveSheet.ActiveRowIndex, 3].Tag.ToString();//药品用法）
                        #region {46983F5B-E184-4b8b-B819-AA1C34993F1B}
                        if (((Neusoft.FrameWork.Models.NeuObject)this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag).Memo != "1")
                        {//当前页不是单项目类型
                            if (billMgr.DeleteExecBill(objBill) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                MessageBox.Show(billMgr.Err, "提示");
                                return;
                            }
                        }
                        else
                        {//当前页是单项目类型，删除一个项目
                            //对DataSet进行处理
                            if (this.unDrugItemSelect != null)
                            {
                                DataRow delItemRow = this.unDrugItemSelect.ucInputUndrug.DsUndrugItem.Tables[objBill.User01].NewRow();
                                Neusoft.HISFC.Models.Base.Item delItem = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Rows[this.neuSpread1.ActiveSheet.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Base.Item;

                                delItemRow["编码"] = delItem.ID;
                                delItemRow["名称"] = delItem.Name;
                                delItemRow["规格"] = delItem.Specs;
                                delItemRow["价格"] = delItem.Price;
                                delItemRow["单位"] = delItem.PriceUnit;
                                delItemRow["类别"] = delItem.SysClass.ID;
                                delItemRow["类别编码"] = delItem.SysClass.ID;
                                delItemRow["拼音码"] = delItem.SpellCode;
                                delItemRow["五笔码"] = delItem.WBCode;
                                delItemRow["自定义码"] = delItem.UserCode;

                                this.unDrugItemSelect.ucInputUndrug.DsUndrugItem.Tables[objBill.User01].Rows.Add(delItemRow);
                            }
                            if (billMgr.DeleteExecBillOneItem(objBill) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                MessageBox.Show(billMgr.Err, "提示");
                                return;
                            }
                        }
                        #endregion
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                    }
                }
                this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Rows.Remove(this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].ActiveRowIndex, 1);
            }
        }

        #endregion

        #region IMaintenanceControlable 成员

        public int Add()
        {
            try
            {
                cResult r = new cResult();
                r.TextChanged += new TextChangedHandler(this.EventResultChanged);
                r.al = GetFpSheet();

                ucBillAdd ba = new ucBillAdd(r);
                ba.alExecBill = this.alExecBill;
                Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(ba);
                this.objExecBill = ba.objExecBill;
                if (r.Result1 != "")
                {
                    grpExecBillName.Visible = true;
                    tabItemType.Visible = true;
                    txtExecBillName.Text = r.Result1;
                    txtExecBillName.Tag = "Add";
                    #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护

                    //InitFp(txtExecBillName.Text, icont, ""); 
                    InitFp(objExecBill, icont);
                    this.SetTabVisible();
                    #endregion
                    icont++;
                    grpExecBillName.Visible = true;
                    //					txtExecBillName.Text = "";
                    grpExecBillD.Visible = true;
                }
                return 1;
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
                return -1;
            }
        }

        public int Copy()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int Cut()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int Delete()
        {
            try
            {
                if (this.txtExecBillName.Text.Trim() == "") return -1;
                if (this.neuSpread1.ActiveSheet == null) return -1;

                if (MessageBox.Show("是否删除执行单【" + this.txtExecBillName.Text + "】", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return -1;

                if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag != null)
                {
                    #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
                    //if (oExecBill.DeleteExecBill(this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag.ToString()) != -1)
                    if (oExecBill.DeleteExecBill(((Neusoft.FrameWork.Models.NeuObject)this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag).ID) != -1)
                    #endregion
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败!" + oExecBill.Err);
                    }
                    #region {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
                    try
                    {
                        this.neuSpread1.Sheets.RemoveAt(this.neuSpread1.ActiveSheetIndex);
                    }
                    catch//catch只有一个Sheet时报异常
                    {

                    }
                    #endregion
                    icont--;
                    #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护

                    if (neuSpread1.ActiveSheetIndex != -1 && neuSpread1.ActiveSheet.Tag != null)
                    {
                        if (((Neusoft.FrameWork.Models.NeuObject)this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag).Memo == "1")
                        {//项目类型执行单
                            if (this.unDrugItemSelect != null)
                            {
                                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在重新初始化项目列表，请等待！"); ;
                                Application.DoEvents();
                                if (this.unDrugItemSelect.ucInputUndrug.GetUndrugDS() == -1) //this.unDrugItemSelect.Init() == -1)
                                {
                                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                    return -1;
                                }
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    this.neuSpread1.Sheets.RemoveAt(this.neuSpread1.ActiveSheetIndex);
                    icont--;
                }
                this.RefreshList();
                if (this.neuSpread1.Sheets.Count > 0)
                {
                    for (int index = 0; index < this.neuSpread1.Sheets.Count; index++)
                    {
                        this.Filter(index);
                    }
                    txtExecBillName.Text = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].SheetName;
                }
                else
                {
                     //{46983F5B-E184-4b8b-B819-AA1C34993F1B} 
                    txtExecBillName.Text = "";
                }
                return 1;
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
                MessageBox.Show(Error);
                return -1;
            }
        }

        public int Export()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int Import()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int Init()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public bool IsDirty
        {
            get
            {
                //throw new Exception("The method or operation is not implemented.");
                return false;
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Modify()
        {
            try
            {
                cResult r = new cResult();
                r.TextChanged += new TextChangedHandler(this.EventResultChanged);
                r.al = GetFpSheet();
                r.Result1 = txtExecBillName.Text;

                if (this.neuSpread1.ActiveSheetIndex < 0)
                    return -1;

                if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag == null)
                {
                    r.Result2 = "";
                }
                else
                {
                    r.Result2 = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].Tag.ToString();
                }
                ucBillAdd ba = new ucBillAdd(r);
                ba.alExecBill = this.alExecBill;
                Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(ba);

                if (r.Result1 != "")
                {
                    txtExecBillName.Text = r.Result1;
                    this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].SheetName = r.Result1;
                    grpExecBillName.Visible = true;
                }
                else
                {
                    txtExecBillName.Text = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].SheetName;
                }
                return 1;
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
                MessageBox.Show(Error);
                return -1;
            }
        }

        public int NextRow()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int Paste()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int PreRow()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int Print()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int PrintConfig()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public int PrintPreview()
        {
            PrintInfo();
            return 1;
        }

        public int Query()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                //throw new Exception("The method or operation is not implemented.");
                return null;
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Save()
        {
            if (SaveBill() >= 0)
            {
                txtExecBillName.Text = this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].SheetName;//= 
                MessageBox.Show("保存成功！");
                return 1;
            }
            else
            {
                MessageBox.Show("保存失败！");
                return 1;
            }
            return -1;
        }

        #endregion

        #region 非药品项目执行单
        Neusoft.HISFC.Components.Order.Controls.ucUndrugItemSelect unDrugItemSelect = null;

        //非药品项目标签页选择
        private void tvUndrugItem_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.neuSpread1.Sheets.Count == 0)
            {
                return;
            }

            #region addby xuewj 2010-9-2 {46983F5B-E184-4b8b-B819-AA1C34993F1B} 非药物执行单单项目维护
            if (this.neuSpread1.ActiveSheet.Tag == null)
            {
                MessageBox.Show("请选择执行单!");
                return;
            }
            if (this.tvUndrugItem.SelectedNode == null)
            {
                return;
            }
            #endregion

            if (this.tvUndrugItem.SelectedNode == null) return;

            Neusoft.FrameWork.Models.NeuObject execBill = this.neuSpread1.ActiveSheet.Tag as Neusoft.FrameWork.Models.NeuObject;

            if (execBill == null || !Neusoft.FrameWork.Function.NConvert.ToBoolean(execBill.Memo))
            {
                MessageBox.Show("请选择非药品项目执行单！");
                return;
            }

            if (e.Node.Parent == null)
            {
                MessageBox.Show("请选择医嘱项目类别！");
                return;
            }

            if (this.unDrugItemSelect == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化，请等待！");
                Application.DoEvents();
                this.unDrugItemSelect = new ucUndrugItemSelect();
                Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                this.unDrugItemSelect.NurseID = empl.Nurse.ID;

                if (this.unDrugItemSelect.Init() == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }
                this.unDrugItemSelect.ItemAllUpdate += new ucUndrugItemSelect.AllItemHandle(unDrugItemSelect_ItemAllUpdate);
                this.unDrugItemSelect.ItemOtherInsert += new ucUndrugItemSelect.ItemHandle(unDrugItemSelect_ItemOtherInsert);
                this.unDrugItemSelect.ItemInsert += new ucUndrugItemSelect.ItemHandle(unDrugItemSelect_ItemInsert);
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

            this.unDrugItemSelect.BillNO = execBill.ID;
            this.unDrugItemSelect.MyOrderType = e.Node.Parent.Tag.ToString();
            this.unDrugItemSelect.MySysClass = e.Node.Tag.ToString();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(this.unDrugItemSelect);

        }

        //选择剩余项目事件
        int unDrugItemSelect_ItemOtherInsert(ArrayList items)
        {
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in items)
            {
                this.AddExecBill(order, this.neuSpread1.ActiveSheetIndex, true);
            }
            return 0;
        }

        //选择单个或多个项目事件
        int unDrugItemSelect_ItemInsert(ArrayList items)
        {
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in items)
            {
                this.AddExecBill(order, this.neuSpread1.ActiveSheetIndex, true);
            }
            return 0;
        }

        //选择全部项目事件
        int unDrugItemSelect_ItemAllUpdate(string orderType, string sysClass, ArrayList items)
        {
            Neusoft.FrameWork.Models.NeuObject activeExecBill = this.neuSpread1.ActiveSheet.Tag as Neusoft.FrameWork.Models.NeuObject;
            //先清空
            ArrayList alOrder = new ArrayList();
            for (int i = 0; i < this.neuSpread1.Sheets.Count; i++)
            {
                if (i != this.neuSpread1.ActiveSheetIndex)
                {
                    Neusoft.FrameWork.Models.NeuObject execBill = this.neuSpread1.Sheets[i].Tag as Neusoft.FrameWork.Models.NeuObject;
                    if (execBill != null)
                    {
                        if (Neusoft.FrameWork.Function.NConvert.ToBoolean(execBill.Memo))
                        {
                            for (int j = this.neuSpread1.Sheets[i].RowCount - 1; j >= 0; j--)
                            {
                                if (this.neuSpread1.Sheets[i].Cells[j, 1].Tag.ToString() == orderType)
                                {
                                    object obj = this.neuSpread1.Sheets[i].Cells[j, 2].Tag as object;
                                    if (obj.ToString() == sysClass)
                                    {
                                        Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                                        order.ID = activeExecBill.ID;
                                        order.Memo = "2";
                                        order.OrderType.ID = orderType;
                                        order.OrderType.Name = this.neuSpread1.Sheets[i].Cells[j, 1].Text;
                                        order.Item.SysClass.ID = sysClass;
                                        order.Item.ID = this.neuSpread1.Sheets[i].Cells[j, 3].Tag.ToString();
                                        order.Item.Name = this.neuSpread1.Sheets[i].Cells[j, 3].Text;
                                        alOrder.Add(order);
                                        this.neuSpread1.Sheets[i].Rows.Remove(j, 1);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            items.AddRange(alOrder);
            //添加到当前sheet
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in items)
            {
                this.AddExecBill(order, this.neuSpread1.ActiveSheetIndex, true);
            }
            return 0;
        }

        //sheet变换
        private void neuSpread1_ActiveSheetChanged(object sender, EventArgs e)
        {
            this.SetTabVisible();
        }

        //tab页变换
        private void SetTabVisible()
        {
            Neusoft.FrameWork.Models.NeuObject execBill = this.neuSpread1.ActiveSheet.Tag as Neusoft.FrameWork.Models.NeuObject;
            if (execBill != null)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(execBill.Memo))
                {
                    if (this.tabItemType.TabPages.Contains(this.tabdrug))
                    {
                        this.tabItemType.TabPages.Remove(this.tabdrug);
                    }

                    if (this.tabItemType.TabPages.Contains(this.tabUndrag))
                    {
                        this.tabItemType.TabPages.Remove(this.tabUndrag);
                    }

                    if (!this.tabItemType.TabPages.Contains(this.tabUndrugItem))
                    {
                        this.tabItemType.TabPages.Add(this.tabUndrugItem);
                    }
                }
                else
                {
                    if (!this.tabItemType.TabPages.Contains(this.tabdrug))
                    {
                        this.tabItemType.TabPages.Add(this.tabdrug);
                    }

                    if (!this.tabItemType.TabPages.Contains(this.tabUndrag))
                    {
                        this.tabItemType.TabPages.Add(this.tabUndrag);
                    }

                    if (this.tabItemType.TabPages.Contains(this.tabUndrugItem))
                    {
                        this.tabItemType.TabPages.Remove(this.tabUndrugItem);
                    }
                }
            }
            else
            {
            }
        }
        #endregion
    }

    public delegate void TextChangedHandler(ArrayList s);

    public class cResult
    {
        public string Result1 = "";
        public string Result2 = "";

        public event TextChangedHandler TextChanged;
        public ArrayList al = new ArrayList();
        public void ChangeText(ArrayList al)
        {
            if (al != null)
                TextChanged(al);
        }
    }
}
