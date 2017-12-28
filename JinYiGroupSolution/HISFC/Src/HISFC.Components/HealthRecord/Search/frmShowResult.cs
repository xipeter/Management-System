using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class frmShowResult : Form
    {
        public frmShowResult()
        {
            InitializeComponent();
        }

        #region 全局变量
        //存储住院流水号列表
        private string inpatientNoList = "";
        //业务层
        private Neusoft.HISFC.BizLogic.HealthRecord.SearchManager SearMan = new Neusoft.HISFC.BizLogic.HealthRecord.SearchManager();
        //暂存数据的　变量
        private System.Data.DataSet ds = null;

        public bool boolClose = false;
        #endregion 
        #region　属性　住院流水号字符串
        /// <summary>
        /// 住院流水号列表　
        /// </summary>
        public string InpatientNoList
        {
            get
            {
                return inpatientNoList;
            }
            set
            {
                inpatientNoList = value;
            }
        }
        #endregion

        public void InitTree()
        {
            //			this.treeView1.ImageIndex = 1;
            //			this.treeView1.ImageList = this.ilTreeView;
            //			this.treeView1.Location = new System.Drawing.Point(32, 160);
            //			this.treeView1.Name = "treeView1";
            //			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            //																				  new System.Windows.Forms.TreeNode("显示类型", new System.Windows.Forms.TreeNode[] {
            //		new System.Windows.Forms.TreeNode("显示病案号"),
            //		new System.Windows.Forms.TreeNode("显示病案号和次数"),
            //		new System.Windows.Forms.TreeNode("显示月份统计"),
            //		new System.Windows.Forms.TreeNode("显示年份统计"),
            //		new System.Windows.Forms.TreeNode("显示年份统计(仅合计)"),
            //		new System.Windows.Forms.TreeNode("显示简单内容"),
            //		new System.Windows.Forms.TreeNode("地区分布人次表"),
            //		new System.Windows.Forms.TreeNode("职业道德调查表"),
            //		new System.Windows.Forms.TreeNode("显示重病案号"),
            //		new System.Windows.Forms.TreeNode("手术次数统计表"),
            //		new System.Windows.Forms.TreeNode("一周内复入院统计表")})});
            this.treeView1.tvList.ImageList = this.ilTreeView;
            TreeNode tnParentUr;
            //画树头  未登记病人列表
            tnParentUr = new TreeNode();
            tnParentUr.Text = "显示类型";
            tnParentUr.ImageIndex = 0;
            tnParentUr.SelectedImageIndex = 0;
            //加载节点 
            this.treeView1.tvList.Nodes.Add(tnParentUr);

            TreeNode tnPatient = new TreeNode();

            tnPatient = new TreeNode();
            tnPatient.Text = "显示病案号";
            tnPatient.ImageIndex = 1;
            tnPatient.SelectedImageIndex = 2;
            tnParentUr.Nodes.Add(tnPatient);

            tnPatient = new TreeNode();
            tnPatient.Text = "显示病案号和次数";
            tnPatient.ImageIndex = 1;
            tnPatient.SelectedImageIndex = 2;
            tnParentUr.Nodes.Add(tnPatient);

            //tnPatient = new TreeNode();
            //tnPatient.Text = "显示月份统计";
            //tnPatient.ImageIndex = 1;
            //tnPatient.SelectedImageIndex = 2;
            //tnParentUr.Nodes.Add(tnPatient);


            //tnPatient = new TreeNode();
            //tnPatient.Text = "显示年份统计";
            //tnPatient.ImageIndex = 1;
            //tnPatient.SelectedImageIndex = 2;
            //tnParentUr.Nodes.Add(tnPatient);

            //tnPatient = new TreeNode();
            //tnPatient.Text = "显示年份统计(仅合计)";
            //tnPatient.ImageIndex = 1;
            //tnPatient.SelectedImageIndex = 2;
            //tnParentUr.Nodes.Add(tnPatient);

            tnPatient = new TreeNode();
            tnPatient.Text = "地区分布人次表";
            tnPatient.ImageIndex = 1;
            tnPatient.SelectedImageIndex = 2;
            tnParentUr.Nodes.Add(tnPatient);

            tnPatient = new TreeNode();
            tnPatient.Text = "职业道德调查表";
            tnPatient.ImageIndex = 1;
            tnPatient.SelectedImageIndex = 2;
            tnParentUr.Nodes.Add(tnPatient);

            tnPatient = new TreeNode();
            tnPatient.Text = "显示重病案号";
            tnPatient.ImageIndex = 1;
            tnPatient.SelectedImageIndex = 2;
            tnParentUr.Nodes.Add(tnPatient);

            tnPatient = new TreeNode();
            tnPatient.Text = "手术次数统计表";
            tnPatient.ImageIndex = 1;
            tnPatient.SelectedImageIndex = 2;
            tnParentUr.Nodes.Add(tnPatient);

            tnPatient = new TreeNode();
            tnPatient.Text = "一周内复入院统计表";
            tnPatient.ImageIndex = 1;
            tnPatient.SelectedImageIndex = 2;
            tnParentUr.Nodes.Add(tnPatient);

            tnParentUr.Expand();
            this.treeView1.tvList.EndUpdate();
            //定义单击事件 
            this.treeView1.tvList.AfterSelect += new TreeViewEventHandler(tvList_AfterSelect);
        }

        private void frmShowResult_Load(object sender, System.EventArgs e)
        {
            InitTree();

            this.ilMenu.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印));
            this.ilMenu.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.L列表));
            this.ilMenu.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出));
            this.toolBar1.ImageList = this.ilMenu;
            this.tbPrint.ImageIndex = 0;
            this.tbList.ImageIndex = 1;
            this.tbExist.ImageIndex = 2;
           

        }

        private void frmShowResult_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!boolClose)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void LockFp()
        {
            try
            {
                switch (this.treeView1.tvList.SelectedNode.Text)
                {
                    case "显示病案号": //只显示病案号 
                        this.fpSpread1_Sheet1.Columns[0].Width = 100;
                        break;
                    case "显示病案号和次数": //显示病案号和次数
                        this.fpSpread1_Sheet1.Columns[0].Width = 100;
                        this.fpSpread1_Sheet1.Columns[1].Width = 50;
                        break;
                    case "显示月份统计":
                        //if (this.fpSpread1_Sheet1.RowCount <= 0) return;
                        //fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count, 1);
                        //int count = this.fpSpread1_Sheet1.Rows.Count - 1;
                        //fpSpread1_Sheet1.Cells[count, 0].Text = "合计: ";
                        //fpSpread1_Sheet1.Cells[count, 1].Formula = "sum(B1:B" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 2].Formula = "sum(C1:C" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 3].Formula = "sum(D1:D" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 4].Formula = "sum(E1:E" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 5].Formula = "sum(F1:F" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 6].Formula = "sum(G1:G" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 7].Formula = "sum(H1:H" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 8].Formula = "sum(I1:I" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 9].Formula = "sum(J1:J" + count.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count, 10].Formula = "sum(K1:K" + count.ToString() + ")";
                        //break;
                    case "显示年份统计":
                        //if (this.fpSpread1_Sheet1.RowCount <= 0) return;
                        //fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count, 1);
                        //int count1 = this.fpSpread1_Sheet1.Rows.Count - 1;
                        //fpSpread1_Sheet1.Cells[count1, 0].Text = "合计: ";
                        //fpSpread1_Sheet1.Cells[count1, 1].Formula = "sum(B1:B" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 1].Formula = "sum(B1:B" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 2].Formula = "sum(C1:C" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 3].Formula = "sum(D1:D" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 4].Formula = "sum(E1:E" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 5].Formula = "sum(F1:F" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 6].Formula = "sum(G1:G" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 7].Formula = "sum(H1:H" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 8].Formula = "sum(I1:I" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 9].Formula = "sum(J1:J" + count1.ToString() + ")";
                        //fpSpread1_Sheet1.Cells[count1, 10].Formula = "sum(K1:K" + count1.ToString() + ")";
                        //break;
                    case "显示年份统计(仅合计)":
                        //						fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count,1);
                        //						int count2 = this.fpSpread1_Sheet1.Rows.Count -1 ;
                        //						fpSpread1_Sheet1.Cells[count2,0].Text = "合计: ";
                        //						fpSpread1_Sheet1.Cells[count2,1].Formula="sum(B1:B"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,1].Formula="sum(B1:B"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,2].Formula="sum(C1:C"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,3].Formula="sum(D1:D"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,4].Formula="sum(E1:E"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,5].Formula="sum(F1:F"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,6].Formula="sum(G1:G"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,7].Formula="sum(H1:H"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,8].Formula="sum(I1:I"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,9].Formula="sum(J1:J"+count2.ToString()+")";
                        //						fpSpread1_Sheet1.Cells[count2,10].Formula="sum(K1:K"+count2.ToString()+")";
                        break;
                    case "显示简单内容":
                        this.fpSpread1_Sheet1.Columns[0].Width = 80;//病案号
                        this.fpSpread1_Sheet1.Columns[1].Width = 30;//次数
                        this.fpSpread1_Sheet1.Columns[2].Width = 30;//性别
                        this.fpSpread1_Sheet1.Columns[3].Width = 50;//年龄
                        this.fpSpread1_Sheet1.Columns[4].Width = 60;//姓名
                        this.fpSpread1_Sheet1.Columns[5].Width = 65;//入院日期
                        this.fpSpread1_Sheet1.Columns[6].Width = 65;//出院日期
                        this.fpSpread1_Sheet1.Columns[7].Width = 65;//出院科别
                        this.fpSpread1_Sheet1.Columns[8].Width = 65;//主治医生
                        this.fpSpread1_Sheet1.Columns[9].Width = 100;//第一诊断
                        this.fpSpread1_Sheet1.Columns[10].Width = 50;//病理符合,
                        this.fpSpread1_Sheet1.Columns[11].Width = 50;//转归
                        this.fpSpread1_Sheet1.Columns[12].Width = 100;//手术名称
                        break;
                    case "地区分布人次表":
                        this.fpSpread1_Sheet1.Columns[0].Width = 60;//编码
                        this.fpSpread1_Sheet1.Columns[1].Width = 200;//地区
                        this.fpSpread1_Sheet1.Columns[2].Width = 50;//人数
                        break;
                    case "职业道德调查表":
                        this.fpSpread1_Sheet1.Columns[0].Width = 60;//姓名
                        this.fpSpread1_Sheet1.Columns[1].Width = 40;//性别
                        this.fpSpread1_Sheet1.Columns[2].Width = 50;//年龄
                        this.fpSpread1_Sheet1.Columns[3].Width = 65;//住院号
                        this.fpSpread1_Sheet1.Columns[4].Width = 20;//次数
                        this.fpSpread1_Sheet1.Columns[5].Width = 65;//入院日期
                        this.fpSpread1_Sheet1.Columns[6].Width = 65;//出院日期
                        this.fpSpread1_Sheet1.Columns[7].Width = 50;//入院科室
                        this.fpSpread1_Sheet1.Columns[8].Width = 50;//户口邮编
                        this.fpSpread1_Sheet1.Columns[9].Width = 120;//户籍地址
                        this.fpSpread1_Sheet1.Columns[10].Width = 120;//疾病名称
                        this.fpSpread1_Sheet1.Columns[11].Width = 60;//转归
                        this.fpSpread1_Sheet1.Columns[12].Width = 60;//住院医师
                        this.fpSpread1_Sheet1.Columns[13].Width = 60;//主治医生
                        this.fpSpread1_Sheet1.Columns[14].Width = 60;//主任医生
                        break;
                    case "显示重病案号":
                        this.fpSpread1_Sheet1.Columns[0].Width = 80;
                        break;
                    case "手术次数统计表"://手术次数统计表
                        this.fpSpread1_Sheet1.Columns[0].Width = 80;//病案号
                        this.fpSpread1_Sheet1.Columns[1].Width = 30;//次数
                        this.fpSpread1_Sheet1.Columns[2].Width = 30;//性别
                        this.fpSpread1_Sheet1.Columns[3].Width = 50;//年龄
                        this.fpSpread1_Sheet1.Columns[4].Width = 60;//姓名
                        this.fpSpread1_Sheet1.Columns[5].Width = 65;//入院日期
                        this.fpSpread1_Sheet1.Columns[6].Width = 65;//出院日期
                        this.fpSpread1_Sheet1.Columns[7].Width = 65;//出院科别
                        this.fpSpread1_Sheet1.Columns[8].Width = 65;//主治医生
                        this.fpSpread1_Sheet1.Columns[9].Width = 65;//手术码
                        this.fpSpread1_Sheet1.Columns[10].Width = 80;//手术名称,
                        this.fpSpread1_Sheet1.Columns[11].Width = 20;//手术次数
                        this.fpSpread1_Sheet1.Columns[12].Width = 65;//手术日期
                        this.fpSpread1_Sheet1.Columns[13].Width = 50;//切口
                        this.fpSpread1_Sheet1.Columns[14].Width = 50;//愈合
                        this.fpSpread1_Sheet1.Columns[15].Width = 20;//附属码 
                        break;
                    case "一周内复入院统计表":
                        this.fpSpread1_Sheet1.Columns[0].Width = 65;//住院号
                        this.fpSpread1_Sheet1.Columns[1].Width = 60;//姓名
                        this.fpSpread1_Sheet1.Columns[2].Width = 30;//性别
                        this.fpSpread1_Sheet1.Columns[3].Width = 20;//次数
                        this.fpSpread1_Sheet1.Columns[4].Width = 65;//入院日期
                        this.fpSpread1_Sheet1.Columns[5].Width = 65;//入院科别
                        this.fpSpread1_Sheet1.Columns[6].Width = 65;//入院日期
                        this.fpSpread1_Sheet1.Columns[7].Width = 65;//入院科别
                        this.fpSpread1_Sheet1.Columns[8].Width = 50;//天数
                        this.fpSpread1_Sheet1.Columns[9].Width = 90;//ICD 
                        this.fpSpread1_Sheet1.Columns[10].Width = 200;//第一诊断名称
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void PrintInfo()
        {
            try
            {

                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                p.PrintPreview(this.neuPanel1);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (this.toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    PrintInfo();
                    break;
                case 1:
                    this.treeView1.Visible = !this.treeView1.Visible;
                    break;
                case 2:
                    this.Close();
                    break;
            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (this.treeView1.tvList.SelectedNode.Text == "显示类型")
                {
                    return;
                }
                ds = new System.Data.DataSet();
                SearMan.GetInfoBySql(treeView1.tvList.SelectedNode.Text, ref ds, inpatientNoList);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        this.fpSpread1_Sheet1.DataSource = ds.Tables[0];
                    }
                }
                LockFp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
