using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Neusoft.HISFC.Components.Operation
{
    public partial class ucOpsTableAllot : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public ucOpsTableAllot()
        {
            try
            {
                InitializeComponent();
                //初始化
                this.InitCtrl();
            }
            catch { }

        }
        #region 定义变量
        //科室信息
        private Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
        //业务控制
        private Neusoft.HISFC.BizLogic.Operation.OpsTableAlloc OpsMana = new Neusoft.HISFC.BizLogic.Operation.OpsTableAlloc();
        //业务实体
        public Neusoft.HISFC.Models.Operation.OpsTableAllot OpsObj = new Neusoft.HISFC.Models.Operation.OpsTableAllot();
        //手术安排信息数组，元素为neusoft.HISFC.Object.Operator.OpsTableAllot类型
        public ArrayList OpsTableAllotAl = new ArrayList();
        //显示科室正台分配数的变量
        private int[] iOpsNum = new int[] {0,0,0,0,0,0,0};
        private int iOpsTotal = 0;
        #endregion
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitCtrl()
        {
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.L楼房));
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.L楼层));
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.F房间));

            try
            {
                //初始化手术室
                ArrayList OpsDept;// = new ArrayList();
                OpsDept = dept.GetDeptment("1");//"1"表示手术类型的科室
                
                foreach (Neusoft.HISFC.Models.Base.Department ThisDept in OpsDept)
                {
                    ListViewItem DeptItem = new ListViewItem();
                    DeptItem.Tag = ThisDept.ID.ToString();
                    DeptItem.Text = ThisDept.Name;
                    DeptItem.ImageIndex = 1;
                    DeptItem.StateImageIndex = 2;
                    this.lvDept.Items.Add(DeptItem);

                }
                this.ncbDept.Items.Clear();
                this.ncbDept.AddItems(dept.GetDeptmentAll());
                
                
            }
            catch
            {}
        }
        private void SumQtyToShow()
        {
            foreach (int i in this.iOpsNum)
            {
                this.iOpsTotal = this.iOpsTotal + i;
            }
            this.lbTotNum.Text = this.iOpsTotal.ToString();
            this.iOpsTotal = 0;
        }
        private void lvDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tvShow.Nodes.Clear();
            this.OpsTableAllotAl.Clear();
            if (this.lvDept.SelectedItems.Count == 0) return;
            //把数组iNumAl初始化为0
            for (int i=0; i < 7; i++)
            {
                this.iOpsNum[i] = 0;
            }
            //清空星期
            this.nnudMon.Text = "0";
            this.nnudTues.Text = "0";
            this.nnudWed.Text = "0";
            this.nnudThur.Text = "0";
            this.nnudFri.Text = "0";
            this.nnudSat.Text = "0";
            this.nnudSun.Text = "0";

            SumQtyToShow();
            llExpand.Text = "展开";
            //将选中的项列为红色，其余的项均置为黑色
            for (int i = 0; i < this.lvDept.Items.Count; i++)
            {
                this.lvDept.Items[i].ForeColor = System.Drawing.Color.Black;
            }
            this.lvDept.SelectedItems[0].ForeColor = System.Drawing.Color.Red;

            //手术室编码
            //string t1 = this.lvDept.SelectedItems[0].Tag as string; ;
            this.OpsObj.OpsRoom.ID =  this.lvDept.SelectedItems[0].Tag as string;
            this.OpsObj.Name = this.lvDept.SelectedItems[0].Text;
            this.gbTableShow.Text = this.OpsObj.Name + " 正台分配情况一览";
            //如果手术室为空，则添加空的星期
            if (this.OpsObj.OpsRoom.ID == null || this.OpsObj.OpsRoom.ID == "") return;

            //添加星期，初始化
            this.tvShow.Nodes.Add(new TreeNode ("星期一"));
            this.tvShow.Nodes.Add(new TreeNode("星期二"));
            this.tvShow.Nodes.Add(new TreeNode("星期三"));
            this.tvShow.Nodes.Add(new TreeNode("星期四"));
            this.tvShow.Nodes.Add(new TreeNode("星期五"));
            this.tvShow.Nodes.Add(new TreeNode("星期六"));
            this.tvShow.Nodes.Add(new TreeNode("星期日"));

            foreach (TreeNode t in this.tvShow.Nodes)
            {
                t.Tag = 0;
                t.ImageIndex = 0;

            }

            //获取科室的在选定的手术室的正台安排情况（保存在OpsTableAllocAl中）
            this.OpsMana.GetAllotInfo(ref this.OpsTableAllotAl, this.OpsObj.OpsRoom);

            foreach (Neusoft.HISFC.Models.Operation.OpsTableAllot ThisAllot in this.OpsTableAllotAl)
            {
                TreeNode TmpTreeNode = new TreeNode(ThisAllot.Dept + "(" +
                                    ThisAllot.Qty.ToString() + ")");
                TmpTreeNode.ImageIndex = 1;
                TmpTreeNode.SelectedImageIndex = 2;
                //树中节点存放格式为：
                //根节点 Tag值为本节点下所有子节点的安排台数之和，Text值为 “星期XTag值”
                //子节点 Tag值为“科室编码/本科室分配台数”，Text值为“科室名称分配台数”
                switch (ThisAllot.Week.ID.ToString())
                { 
                    case "1":
                        this.tvShow.Nodes[0].Nodes.Add(TmpTreeNode);
                        TmpTreeNode.Tag = ThisAllot.Dept.ID.ToString() + "/" +
                                          ThisAllot.Qty.ToString();
                        TmpTreeNode.Parent.Tag = System.Convert.ToInt16(TmpTreeNode.Parent.Tag) +
                                                 ThisAllot.Qty;
                        TmpTreeNode.Parent.Text = "星期一【共" + TmpTreeNode.Parent.Tag.ToString() +
                                                  "台】";
                        break;
                    case "2":
                        this.tvShow.Nodes[1].Nodes.Add(TmpTreeNode);
                        TmpTreeNode.Tag = ThisAllot.Dept.ID.ToString() + "/" +
                                          ThisAllot.Qty.ToString();
                        TmpTreeNode.Parent.Tag = System.Convert.ToInt16(TmpTreeNode.Parent.Tag) +
                                                 ThisAllot.Qty;
                        TmpTreeNode.Parent.Text = "星期二【共" + TmpTreeNode.Parent.Tag.ToString() +
                                                  "台】";
                        break;
                    case "3":
                        this.tvShow.Nodes[2].Nodes.Add(TmpTreeNode);
                        TmpTreeNode.Tag = ThisAllot.Dept.ID.ToString() + "/" +
                                          ThisAllot.Qty.ToString();
                        TmpTreeNode.Parent.Tag = System.Convert.ToInt16(TmpTreeNode.Parent.Tag) +
                                                 ThisAllot.Qty;
                        TmpTreeNode.Parent.Text = "星期三【共" + TmpTreeNode.Parent.Tag.ToString() +
                                                  "台】";
                        break;
                    case "4":
                        this.tvShow.Nodes[3].Nodes.Add(TmpTreeNode);
                        TmpTreeNode.Tag = ThisAllot.Dept.ID.ToString() + "/" +
                                          ThisAllot.Qty.ToString();
                        TmpTreeNode.Parent.Tag = System.Convert.ToInt16(TmpTreeNode.Parent.Tag) +
                                                 ThisAllot.Qty;
                        TmpTreeNode.Parent.Text = "星期四【共" + TmpTreeNode.Parent.Tag.ToString() +
                                                  "台】";

                        break;
                    case "5":
                        this.tvShow.Nodes[4].Nodes.Add(TmpTreeNode);
                        TmpTreeNode.Tag = ThisAllot.Dept.ID.ToString() + "/" +
                                          ThisAllot.Qty.ToString();
                        TmpTreeNode.Parent.Tag = System.Convert.ToInt16(TmpTreeNode.Parent.Tag) +
                                                 ThisAllot.Qty;
                        TmpTreeNode.Parent.Text = "星期五【共" + TmpTreeNode.Parent.Tag.ToString() +
                                                  "台】";

                        break;
                    case "6":
                        this.tvShow.Nodes[5].Nodes.Add(TmpTreeNode);
                        TmpTreeNode.Tag = ThisAllot.Dept.ID.ToString() + "/" +
                                          ThisAllot.Qty.ToString();
                        TmpTreeNode.Parent.Tag = System.Convert.ToInt16(TmpTreeNode.Parent.Tag) +
                                                 ThisAllot.Qty;
                        TmpTreeNode.Parent.Text = "星期六【共" + TmpTreeNode.Parent.Tag.ToString() +
                                                  "台】";

                        break;
                    case "7":
                        this.tvShow.Nodes[6].Nodes.Add(TmpTreeNode);
                        TmpTreeNode.Tag = ThisAllot.Dept.ID.ToString() + "/" +
                                          ThisAllot.Qty.ToString();
                        TmpTreeNode.Parent.Tag = System.Convert.ToInt16(TmpTreeNode.Parent.Tag) +
                                                 ThisAllot.Qty;
                        TmpTreeNode.Parent.Text = "星期日【共" + TmpTreeNode.Parent.Tag.ToString() +
                                                  "台】";

                        break;
                }

            }

        }
        //选择科室
        private void ncbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OpsTableAllotAl.Clear();
            //科室编码
            this.OpsObj.Dept.ID = this.ncbDept.Tag.ToString();
            this.OpsObj.Dept.Name = this.ncbDept.Text;
            this.gbTable.Text = this.ncbDept.Text + " 正台分配";
            //初始化数组
            for (int i=0; i < 7; i++)
            {
                this.iOpsNum[i] = 0;
            }
            //获取科室的在选定的手术室的正台安排情况（保存在OpsTableAllocAl中）
            this.OpsMana.GetAllotInfo(ref this.OpsTableAllotAl, this.OpsObj.OpsRoom, this.OpsObj.Dept);
            if (this.OpsTableAllotAl.Count != 0)
            {
                foreach (Neusoft.HISFC.Models.Operation.OpsTableAllot ThisAllot in this.OpsTableAllotAl)
                {
                    switch (ThisAllot.Week.ID.ToString())
                    { 
                        case "1":
                            this.nnudMon.Text = ThisAllot.Qty.ToString();
                            this.iOpsNum[0] = ThisAllot.Qty;
                            break;
                        case "2":
                            this.nnudTues.Text = ThisAllot.Qty.ToString();
                            this.iOpsNum[1] = ThisAllot.Qty;
                            break;
                        case "3":
                            this.nnudWed.Text = ThisAllot.Qty.ToString();
                            this.iOpsNum[2] = ThisAllot.Qty;
                            break;
                        case "4":
                            this.nnudThur.Text = ThisAllot.Qty.ToString();
                            this.iOpsNum[3] = ThisAllot.Qty;
                            break;
                        case "5":
                            this.nnudFri.Text = ThisAllot.Qty.ToString();
                            this.iOpsNum[4] = ThisAllot.Qty;
                            break;
                        case "6":
                            this.nnudSat.Text = ThisAllot.Qty.ToString();
                            this.iOpsNum[5] = ThisAllot.Qty;
                            break;
                        case "7":
                            this.nnudSun.Text = ThisAllot.Qty.ToString();
                            this.iOpsNum[6] = ThisAllot.Qty;
                            break;
                    }
                    this.SumQtyToShow();
                }
                this.OpsTableAllotAl.Clear();
                this.nnudMon.Focus();
            }
        }
        //将当前界面显示的分配情况加入TreeView
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (ncbDept.Tag == null || ncbDept.Tag.ToString() == "")
            {
                MessageBox.Show("请选择科室");
                ncbDept.Focus();
                return;
            }
            if (ncbDept.Text == "")
            {
                MessageBox.Show("请选择科室");
                ncbDept.Focus();
                return;
            }
            #region 
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(nnudMon.Text) > 100)
            {
                MessageBox.Show("星期一分配数量过大");
                nnudMon.Focus();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(nnudTues.Text) > 100)
            {
                MessageBox.Show("星期二分配数量过大");
                nnudTues.Focus();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(nnudWed.Text) > 100)
            {
                MessageBox.Show("星期三分配数量过大");
                nnudWed.Focus();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(nnudThur.Text) > 100)
            {
                MessageBox.Show("星期四分配数量过大");
                nnudThur.Focus();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(nnudFri.Text) > 100)
            {
                MessageBox.Show("星期五分配数量过大");
                nnudFri.Focus();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(nnudSat.Text) > 100)
            {
                MessageBox.Show("星期六分配数量过大");
                nnudSat.Focus();
                return;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(nnudSun.Text) > 100)
            {
                MessageBox.Show("星期日分配数量过大");
                nnudSun.Focus();
                return;
            }
            #endregion 
            if (this.tvShow.Nodes.Count == 0) return;
            ArrayList willAddAl = new ArrayList();		//新增项目列表
            ArrayList willUpdateAl = new ArrayList();	//修改项目列表

            //获取当前界面显示的分配情况
            this.OpsTableAllotAl = this.GetCurrentAllot();
            if (this.OpsTableAllotAl.Count == 0 || this.OpsTableAllotAl == null) return;
            //数据库事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.OpsMana.Connection);
            //trans.BeginTransaction();

            this.OpsMana.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //对星期中的每一日的分配情况分别处理
                foreach (Neusoft.HISFC.Models.Operation.OpsTableAllot thisAllot in this.OpsTableAllotAl)
                {
                    string sFlag = "NeedAddNew";
                    string sTmp = "";
                    string sWeekDay = "";
                    switch (thisAllot.Week.ID.ToString())
                    {
                        case "1":
                            sWeekDay = "星期一";
                            break;
                        case "2":
                            sWeekDay = "星期二";
                            break;
                        case "3":
                            sWeekDay = "星期三";
                            break;
                        case "4":
                            sWeekDay = "星期四";
                            break;
                        case "5":
                            sWeekDay = "星期五";
                            break;
                        case "6":
                            sWeekDay = "星期六";
                            break;
                        case "7":
                            sWeekDay = "星期日";
                            break;
                    }
                    int index = System.Convert.ToInt16(thisAllot.Week.ID.ToString()) - 1;
                    //遍历index所指根节点下的所有项，看有没有匹配的
                    //有，更新之，没有，新增之！
                    foreach (TreeNode thisnode in this.tvShow.Nodes[index].Nodes)
                    {
                        ////获取科室编码(4位)
                        sTmp = thisnode.Tag.ToString().Substring(0, 4);
                        //TreeView中星期该日已存在该科室的分配信息,更新之
                        if (sTmp == thisAllot.Dept.ID.ToString())
                        {
                            //待更新项目列表中加入当前对象
                            willUpdateAl.Add(thisAllot);

                            //如果更新数量为0，则删除结点，否则更新数量
                            if (thisAllot.Qty == 0)
                            {
                                if (this.OpsMana.DelAllotInfo(thisAllot) == -1)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    this.btDel.Enabled = true;
                                    MessageBox.Show("更新手术正台分配信息时出错！", "提示");
                                    return;
                                }

                                thisnode.Parent.Tag = Convert.ToString(Convert.ToInt16(thisnode.Parent.Tag) -
                                                                       Convert.ToInt16(thisnode.Tag.ToString().Substring(5)) 
                                                                       );
                                thisnode.Parent.Text = sWeekDay + "【共" + thisnode.Parent.Tag.ToString() + "台】";
                                thisnode.Remove();
                                sFlag = "DelUpdate";
                            }
                            else
                            { 
                            //更新数量
                                if (this.OpsMana.UpdateAllotInfo(willUpdateAl) == -1)
                                {
                                    MessageBox.Show("更新手术正台分配信息时出错！", "提示");
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    return;
                                }


                                thisnode.Parent.Tag = Convert.ToString(Convert.ToInt16(thisnode.Parent.Tag) -
                                                                       Convert.ToInt16(thisnode.Tag.ToString().Substring(5)) +
                                                                       thisAllot.Qty);
                                thisnode.Parent.Text = sWeekDay + "【共" + thisnode.Parent.Tag.ToString() + "台】";
                                thisnode.Tag = sTmp + "/" + thisAllot.Qty.ToString();
                                thisnode.Text = thisAllot.Dept.Name + "(" + thisAllot.Qty.ToString() + ")";
                                sFlag = "NeedUpdate";

                            }
                            //分配数 = 原总数 - 科室原分配数 + 科室现分配数
                            willUpdateAl.Clear();

                        }

                    }
                    //未找到匹配的，则需要新增节点
                    if (sFlag == "NeedAddNew")
                    { //待增加项目列表中加入当前对象
                        willAddAl.Add(thisAllot);
                        //Insert 数据库
                        if (this.OpsMana.AddAllotInfo(willAddAl) == -1)
                        {
                            MessageBox.Show("增加手术正台分配信息时出错！", "提示");
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            return;
                        }
                        TreeNode NewNode = new TreeNode(thisAllot.Dept.Name + "(" + thisAllot.Qty.ToString() + ")");
                        this.tvShow.Nodes[index].Nodes.Add(NewNode);
                        NewNode.ImageIndex = 1;
                        NewNode.SelectedImageIndex = 2;
                        NewNode.Tag = thisAllot.Dept.ID.ToString() + "/" + thisAllot.Qty.ToString();
                        //分配数 = 原总数 + 科室现分配数
                        NewNode.Parent.Tag = Convert.ToString(Convert.ToInt16(NewNode.Parent.Tag) + thisAllot.Qty);
                        NewNode.Parent.Text = sWeekDay + "【共" + NewNode.Parent.Tag.ToString() + "台】";

                        willAddAl.Clear();
                    }

                    switch (thisAllot.Week.ID.ToString())
                    {
                        case "1":
                            this.nnudMon.Text = thisAllot.Qty.ToString();
                            this.iOpsNum[0] = Convert.ToInt16(this.nnudMon.Text);
                            break;
                        case "2":
                            this.nnudTues.Text = thisAllot.Qty.ToString();
                            this.iOpsNum[1] = Convert.ToInt16(this.nnudTues.Text);
                            break;
                        case "3":
                            this.nnudWed.Text = thisAllot.Qty.ToString();
                            this.iOpsNum[2] = Convert.ToInt16(this.nnudWed.Text);
                            break;
                        case "4":
                            this.nnudThur.Text = thisAllot.Qty.ToString();
                            this.iOpsNum[3] = Convert.ToInt16(this.nnudThur.Text);
                            break;
                        case "5":
                            this.nnudFri.Text = thisAllot.Qty.ToString();
                            this.iOpsNum[4] = Convert.ToInt16(this.nnudFri.Text);
                            break;
                        case "6":
                            this.nnudSat.Text = thisAllot.Qty.ToString();
                            this.iOpsNum[5] = Convert.ToInt16(this.nnudSat.Text);
                            break;
                        case "7":
                            this.nnudSun.Text = thisAllot.Qty.ToString();
                            this.iOpsNum[6] = Convert.ToInt16(this.nnudSun.Text);
                            break;
                    }
                    this.SumQtyToShow();
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功");
        }
        //获取当前界面上设置的科室正台信息
        //返回一个包含了当前界面显示的正台信息的数组。
        public ArrayList GetCurrentAllot()
        {
            ArrayList alCurList = new ArrayList();
            if (this.OpsObj.OpsRoom.ID == null || this.OpsObj.Dept.ID == null)
            {
                MessageBox.Show("请选择手术室和要进行正台分配的科室！", "提示");
                //返回一个空的数组
                return alCurList;
            }
            this.OpsObj.Week.ID = "1";
            this.OpsObj.Qty = Convert.ToInt16(this.nnudMon.Text);
            alCurList.Add(this.OpsObj.Clone());

            this.OpsObj.Week.ID = "2";
            this.OpsObj.Qty = Convert.ToInt16(this.nnudTues.Text);
            alCurList.Add(this.OpsObj.Clone());

            this.OpsObj.Week.ID = "3";
            this.OpsObj.Qty = Convert.ToInt16(this.nnudWed.Text);
            alCurList.Add(this.OpsObj.Clone());

            this.OpsObj.Week.ID = "4";
            this.OpsObj.Qty = Convert.ToInt16(this.nnudThur.Text);
            alCurList.Add(this.OpsObj.Clone());

            this.OpsObj.Week.ID = "5";
            this.OpsObj.Qty = Convert.ToInt16(this.nnudFri.Text);
            alCurList.Add(this.OpsObj.Clone());

            this.OpsObj.Week.ID = "6";
            this.OpsObj.Qty = Convert.ToInt16(this.nnudSat.Text);
            alCurList.Add(this.OpsObj.Clone());

            this.OpsObj.Week.ID = "7";
            this.OpsObj.Qty = Convert.ToInt16(this.nnudSun.Text);
            alCurList.Add(this.OpsObj.Clone());

            return alCurList;
        }

        #region//删除TreeView中所选节点
        private void btDel_Click(object sender, EventArgs e)
        {
            string sOldNode;
            this.btDel.Enabled = false;
            //只能删除叶节点
            if (this.tvShow.SelectedNode != null && this.tvShow.Nodes.Count != 0 && this.tvShow.Parent != null)
            {
                //将选中的节点信息置为对象
                Neusoft.HISFC.Models.Operation.OpsTableAllot thisAllot = new Neusoft.HISFC.Models.Operation.OpsTableAllot();
                thisAllot.OpsRoom.ID = this.OpsObj.OpsRoom.ID;
                thisAllot.Dept.ID = this.tvShow.SelectedNode.Tag.ToString().Substring(0, 4);
                thisAllot.Week.ID = Convert.ToString(this.tvShow.SelectedNode.Parent.Index + 1);
                thisAllot.Qty = Convert.ToInt16( this.tvShow.SelectedNode.Tag.ToString().Substring(5));
                string sWeekDay = "";
                switch (thisAllot.Week.ID.ToString())
                { 
                    case "1":
                        sWeekDay = "星期一";
                        break;
                    case "2":
                        sWeekDay = "星期二";
                        break;
                    case "3":
                        sWeekDay = "星期三";
                        break;
                    case "4":
                        sWeekDay = "星期四";
                        break;
                    case "5":
                        sWeekDay = "星期五";
                        break;
                    case "6":
                        sWeekDay = "星期六";
                        break;
                    case "7":
                        sWeekDay = "星期日";
                        break;
                }
                //Delete数据库中该对象所对应的数据

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction Trans = new Neusoft.FrameWork.Management.Transaction(this.OpsMana.Connection);
                //Trans.BeginTransaction();

                this.OpsMana.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.OpsMana.DelAllotInfo(thisAllot) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.btDel.Enabled = true;
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                //删除节点后刷新显示根节点信息
                //分配数 = 原总数 - 被移除的科室分配数
                sOldNode = this.tvShow.SelectedNode.Tag.ToString().Substring(0,4);
                this.tvShow.SelectedNode.Parent.Tag = Convert.ToString(Convert.ToInt16(this.tvShow.SelectedNode.Parent.Tag) -
                                                                       Convert.ToInt16(this.tvShow.SelectedNode.Tag.ToString().Substring(5))
                                                                       );
                this.tvShow.SelectedNode.Parent.Text = sWeekDay + "【共" + this.tvShow.SelectedNode.Parent.Tag.ToString() + "台】";
                this.tvShow.SelectedNode.Remove();
                this.tvShow.SelectedNode = this.tvShow.Nodes[0];
                //如果正台分配选择了该科室则刷新
                if (this.ncbDept.Tag.ToString() == sOldNode)
                {
                    switch (thisAllot.Week.ID.ToString())
                    {
                        case "1":
                            this.nnudMon.Text = Convert.ToString(Neusoft.FrameWork.Function.NConvert.ToInt32(this.nnudMon.Text) - thisAllot.Qty);
                            this.iOpsNum[0] = Convert.ToInt16( this.nnudMon.Text );
                            break;
                        case "2":
                            this.nnudTues.Text =   Convert.ToString(Neusoft.FrameWork.Function.NConvert.ToInt32(this.nnudTues.Text) - thisAllot.Qty);
                            this.iOpsNum[1] = Convert.ToInt16(this.nnudTues.Text );
                            break;
                        case "3":
                            this.nnudWed.Text = Convert.ToString(Neusoft.FrameWork.Function.NConvert.ToInt32(this.nnudWed.Text) - thisAllot.Qty);
                            this.iOpsNum[2] = Convert.ToInt16(this.nnudWed.Text );
                            break;
                        case "4":
                            this.nnudThur.Text =   Convert.ToString(Neusoft.FrameWork.Function.NConvert.ToInt32(this.nnudThur.Text) - thisAllot.Qty);
                            this.iOpsNum[3] = Convert.ToInt16(this.nnudThur.Text );
                            break;
                        case "5":
                            this.nnudFri.Text =   Convert.ToString(Neusoft.FrameWork.Function.NConvert.ToInt32(this.nnudFri.Text) - thisAllot.Qty);
                            this.iOpsNum[4] = Convert.ToInt16(this.nnudFri.Text );
                            break;
                        case "6":
                            this.nnudSat.Text =   Convert.ToString(Neusoft.FrameWork.Function.NConvert.ToInt32(this.nnudSat.Text) - thisAllot.Qty);
                            this.iOpsNum[5] = Convert.ToInt16(this.nnudSat.Text );
                            break;
                        case "7":
                            this.nnudSun.Text =   Convert.ToString(Neusoft.FrameWork.Function.NConvert.ToInt32(this.nnudSun.Text) - thisAllot.Qty);
                            this.iOpsNum[6] = Convert.ToInt16(this.nnudSun.Text );
                            break;
                    }
                    this.SumQtyToShow();

                }
            }
            this.btDel.Enabled = true;
        }
        #endregion

        #region 展开&折叠树型列表中的所有项目
        private void llExpand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (this.llExpand.Text)
            {
                case "展开":
                    foreach (TreeNode Node in this.tvShow.Nodes)
                    { 
                        this.llExpand.Text = "折叠";
                        Node.ExpandAll();
                    }
                    break;
                case "折叠":
                    foreach(TreeNode Node in this.tvShow.Nodes)
                    {
                        this.llExpand.Text = "展开";
                        Node.Collapse();
                    }
                    break;
            }
        }
        #endregion

    }
}
