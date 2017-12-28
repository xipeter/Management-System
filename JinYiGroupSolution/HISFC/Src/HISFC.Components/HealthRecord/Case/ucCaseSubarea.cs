using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Case
{
    /// <summary>
    /// ucCabinet<br></br>
    /// [��������: ��������վά��]<br></br>
    /// [�� �� ��: ��ΰ��]<br></br>
    /// [����ʱ��: 2007-09-13]<br></br>
    /// <�޸ļ�¼
    ///		�޸���=''
    ///		�޸�ʱ��='yyyy-mm-dd'
    ///		�޸�Ŀ��=''
    ///		�޸�����=''
    ///  />
    /// </summary>
    public partial class ucCaseSubarea : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseSubareaManager cbManager = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseSubareaManager();

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("����", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T����, true, false, null);
            return this.toolBarService;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "����":
                    this.Add();
                    break;
                default:
                    break;
            }
        }

        private void Add()
        {
            Neusoft.HISFC.Components.HealthRecord.Case.Controls.ucSubareaHandler uc = new Neusoft.HISFC.Components.HealthRecord.Case.Controls.ucSubareaHandler();
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }

        public ucCaseSubarea()
        {
            InitializeComponent();
        }

        public void FillTreeview()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager constant = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList alConstant = constant.GetConstantList("CASE13");

            TreeNode root = new TreeNode("���з���");
            this.neuTreeView1.Nodes.Add(root);

            if (alConstant.Count == 0 || alConstant == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("��ȡ����ʧ��"));
                return;
            }
            for (int i = 0; i < alConstant.Count; i++)
            {
                Neusoft.HISFC.Models.Base.Const cons = alConstant[i] as Neusoft.HISFC.Models.Base.Const;
                if (cons == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("������ʧ��"));
                    return;
                }
                TreeNode tn = new TreeNode(cons.Name);
                tn.Tag = cons;
                root.Nodes.Add(tn);

                
            }
        }

        private void neuTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.Clear();

            if (e.Node.Parent == null)
            {
                return;
            }
            Neusoft.HISFC.Models.Base.Const subarea = e.Node.Tag as Neusoft.HISFC.Models.Base.Const;
            if( subarea == null )
            {
                return;
            }

            List<Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea> listSubarea = this.cbManager.QueryBySubareaID(subarea.ID);
            if (listSubarea == null || listSubarea.Count == 0)
            {
                return;
            }
            foreach (Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea area in listSubarea)
            {
                this.FillFP(area);
            }


        }

        private void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
        }

        private void FillFP(Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea subarea)
        {
            int rowIndex = this.neuSpread1_Sheet1.Rows.Count;            
            
            this.neuSpread1_Sheet1.Rows.Add(rowIndex, 1);

            this.neuSpread1_Sheet1.SetText(rowIndex, 0, subarea.SubArea.ID);
            this.neuSpread1_Sheet1.SetText(rowIndex, 1, subarea.SubArea.Name);
            this.neuSpread1_Sheet1.SetText(rowIndex, 2, subarea.NurseStation.ID);
            this.neuSpread1_Sheet1.SetText(rowIndex, 3, subarea.NurseStation.Name);

            this.neuSpread1_Sheet1.Rows[rowIndex].Tag = subarea;
        }

        private void ucCaseSubarea_Load(object sender, EventArgs e)
        {
            this.FillTreeview();
        }
    }
}