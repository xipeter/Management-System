using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Neusoft.HISFC.WinForms.WorkStation
{
    /// <summary>
    /// 护士医嘱管理
    /// </summary>
    public partial class frmNurseOrder : Neusoft.FrameWork.WinForms.Forms.frmBaseForm
    {
        public frmNurseOrder()
        {
            InitializeComponent();
            base.tree = this.tvNurseCellPatientList1;
            base.initTree();
            this.tvNurseCellPatientList1.Refresh();
            #region {839D3A8A-49FA-4d47-A022-6196EB1A5715}
            if (!this.DesignMode)
            {
                timer1.Enabled = true;
                timer1.Interval = 500;
            }
            #endregion
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.tbExport.Visible = false;//不显示导出按忸

            #region {1D527E81-93EB-4efb-B0EA-C9D6710886EC}

            tbRefresh = new System.Windows.Forms.ToolStripButton();
            tbRefresh.TextImageRelation = TextImageRelation.ImageAboveText;
            tbRefresh.ToolTipText = "刷新患者";
            tbRefresh.Text = "刷新患者";
            tbRefresh.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新);
            toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(toolBar1_ItemClicked);
            toolBar1.Items.Add(this.tbRefresh);

            this.tbRefresh.Visible = true;//先把它隐藏，需要时打开

            #region {C9B369B5-37FA-44f9-924A-63B6ABDBCBDB} Lis接口按钮

            tbLis = new System.Windows.Forms.ToolStripButton();
            tbLis.TextImageRelation = TextImageRelation.ImageAboveText;
            tbLis.ToolTipText = "Lis接口";
            tbLis.Text = "Lis接口";
            tbLis.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.M模版);
            toolBar1.Items.Add(this.tbLis);

            #endregion

            ToolStripItem tempItem = null;
            foreach (ToolStripItem item in toolBar1.Items)
            {
                if (item.Text == "退出")
                {
                    tempItem = item;
                    toolBar1.Items.Remove(item);
                    break;
                }
            }
            if (tempItem != null)
            {
                toolBar1.Items.Add(tempItem);
            }
            #endregion
        }

        private System.Windows.Forms.ToolStripButton tbRefresh = null;
        private System.Windows.Forms.ToolStripButton tbLis = null;

        #region 事件

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Controls.Count > 0)
            {
                this.iQueryControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IQueryControlable;
                this.iControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                this.CurrentControl = this.tabControl1.SelectedTab.Controls[0];

                #region donggq--2010.09.25--{BCE43E46-FD43-498d-B213-A18992055E56}


                #region {82A35314-09A6-4da8-AD20-C2ADBD09F6FF} tab选择后新增的按钮按钮消失 20100910

                #region {1D527E81-93EB-4efb-B0EA-C9D6710886EC}

                tbRefresh = new System.Windows.Forms.ToolStripButton();
                tbRefresh.TextImageRelation = TextImageRelation.ImageAboveText;
                tbRefresh.ToolTipText = "刷新患者";
                tbRefresh.Text = "刷新患者";
                tbRefresh.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新);
                toolBar1.Items.Add(this.tbRefresh);

                #endregion

                #region {C9B369B5-37FA-44f9-924A-63B6ABDBCBDB} Lis接口按钮

                tbLis = new System.Windows.Forms.ToolStripButton();
                tbLis.TextImageRelation = TextImageRelation.ImageAboveText;
                tbLis.ToolTipText = "Lis接口";
                tbLis.Text = "Lis接口";
                tbLis.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.M模版);

                toolBar1.Items.Add(this.tbLis);

                toolBar1.ItemClicked -= new ToolStripItemClickedEventHandler(toolBar1_ItemClicked);
                toolBar1.ItemClicked += new ToolStripItemClickedEventHandler(toolBar1_ItemClicked);

                #endregion

                ToolStripItem tempItem = null;
                foreach (ToolStripItem item in toolBar1.Items)
                {
                    if (item.Text == "退出")
                    {
                        tempItem = item;
                        toolBar1.Items.Remove(item);
                        break;
                    }
                }
                if (tempItem != null)
                {
                    toolBar1.Items.Add(tempItem);
                }


                #endregion


                
                #endregion

            }
        }

        private void toolBar1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.tbRefresh)
            {
                this.tvNurseCellPatientList1.Refresh();
            }
            else if (e.ClickedItem.Text == "Lis接口") 
            {
                #region {C9B369B5-37FA-44f9-924A-63B6ABDBCBDB} 增加的LIS接口，单击事件

                try
                {
                    rm_barprinter_common.In_rm_barprinter_common mobj;
                    mobj = new rm_barprinter_common.COClass_n_rm_barprinter_commonClass();

                    Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();

                    string oper = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID;

                    string bqcode = string.Empty;
                    string kscode = string.Empty;

                    ArrayList alist =  deptMgr.GetNurseStationFromDept(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept, "01");
                    if (alist != null && alist.Count > 0)
                    {
                        bqcode = (( Neusoft.FrameWork.Models.NeuObject)alist[0]).ID.ToString();// ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                        kscode = string.Empty;
                    }

                    if (!string.IsNullOrEmpty(bqcode))
                    {
                        mobj.uf_lisbarcode(kscode, bqcode, oper);

                        #region donggq--2010.09.21--{7F844EEB-63F5-4f0f-B5EC-473B3BAFC8FA}

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(mobj); 
                        #endregion
                        
                        //MessageBox.Show("from lis");
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 

                #endregion
            }

        }
        #endregion

        #region {839D3A8A-49FA-4d47-A022-6196EB1A5715} 将MQ嵌入系统，医生站保存时能自动通知护士站。护士站医嘱界面能自动响应，类似QQ的头像晃动，并可以给出声音提示
        
        /// <summary>
        /// 刷新时间间隔
        /// </summary>
        //public int RefreshInterval
        //{
        //    set
        //    {
        //        this.timer1.Interval = value;
        //    }
        //}

        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ArrayList alInpatientNO = GetChangedNO();

            if (alInpatientNO != null && alInpatientNO.Count > 0)
            {
                //this.tvNurseCellPatientList1.RefreshMQ(alInpatientNO);
                this.tvNurseCellPatientList1.RefreshImage(alInpatientNO);
            }
        }

        private ArrayList GetChangedNO()
        {
            string strLabel = Neusoft.HISFC.Components.Common.Classes.Function.Label("");

            string[] messageArr = strLabel.Split('\0');
            ArrayList alInpatientNO = new ArrayList();
            Hashtable htInpatientNO = new Hashtable();
            foreach (string messageInfo in messageArr)
            {
                if (messageInfo != "")
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    string inpatientNO = messageInfo.Substring(messageInfo.IndexOf("ZY"), 14);
                    if (inpatientNO != "")
                    {
                        if (!htInpatientNO.Contains(inpatientNO))
                        {
                            alInpatientNO.Add(inpatientNO);
                            htInpatientNO.Add(inpatientNO, null);
                        }
                    }
                }
            }
            return alInpatientNO;
        }

        #endregion
    }
}