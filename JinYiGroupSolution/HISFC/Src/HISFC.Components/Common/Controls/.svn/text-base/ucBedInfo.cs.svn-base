using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucBedInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private Neusoft.HISFC.BizLogic.Manager.Bed bed = new Neusoft.HISFC.BizLogic.Manager.Bed();
        private DataView dvBedInfo = new DataView();

        public ucBedInfo()
        {
            InitializeComponent();
        }

        private void ucBedInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.InitTreeView() == -1)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("初始化护士站列表失败"));                
                }
                this.dvBedInfo = new DataView();
                this.bed.QueryBedInfo(ref this.dvBedInfo);
                this.neuSpread1_Sheet1.DataSource = this.dvBedInfo;
            }
            catch
            {
                //MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("窗体初始化失败"));                
            }
        }

        /// <summary>
        /// 初始化护士站列表
        /// </summary>
        /// <returns>1,成功; -1,失败</returns>
        private int InitTreeView()
        {
            System.Collections.ArrayList alBeds = new System.Collections.ArrayList();
            alBeds = this.bed.QueryNurseStationInfo();
            if (alBeds == null)
            {
                return -1;
            }

            TreeNode root = new TreeNode("护士站列表");
            this.tvNurseStation.Nodes.Add(root);
            for (int i = 0, j = alBeds.Count; i < j; i++)
            {
                TreeNode tn = new TreeNode(((Neusoft.HISFC.Models.Base.Bed)alBeds[i]).Name);
                tn.Tag = ((Neusoft.HISFC.Models.Base.Bed)alBeds[i]).ID;
                root.Nodes.Add(tn);
            }
            return 1;
        }

        private void tvNurseStation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                this.dvBedInfo = new DataView();
                this.bed.QueryBedInfo(ref this.dvBedInfo);
                this.neuSpread1_Sheet1.DataSource = this.dvBedInfo;
                return;
                //显示所有床位信息
            }
            string id = (string)e.Node.Tag;
            this.dvBedInfo = new DataView();
            this.bed.QueryBedInfoByNurseStationID(id, ref this.dvBedInfo);
            this.neuSpread1_Sheet1.DataSource = this.dvBedInfo;
        }
    }
}
