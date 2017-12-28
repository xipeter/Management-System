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
    /// [功能描述: 病历使用跟踪]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-09-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucCaseTrack : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager ctManager = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager();


        public ucCaseTrack()
        {
            InitializeComponent();
        }


        private void QueryCaseTrackRecord(string caseID)
        {
            if (caseID == null || caseID.Trim() == string.Empty)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("病历号不能为空"));
                return ;
            }

            List<Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack> listTrack = this.ctManager.QueryTrackRecordByCaseID(caseID);

            if (listTrack == null || listTrack.Count == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有找到病历使用记录"));
                return ;
            }

            foreach (Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack track in listTrack)
            {
                this.FillTrackRecord(track);
            }


        }

        private void FillTrackRecord(Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack track)
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);
            int rowIndex = this.neuSpread1_Sheet1.Rows.Count;
       

            this.neuSpread1_Sheet1.SetText(rowIndex, 0, track.ID);
            this.neuSpread1_Sheet1.SetText(rowIndex, 1, track.PatientCase.ID);
            this.neuSpread1_Sheet1.SetText(rowIndex, 2, track.UseCaseEnv.ID);
            this.neuSpread1_Sheet1.SetText(rowIndex, 3, track.UseCaseEnv.Name);
            this.neuSpread1_Sheet1.SetText(rowIndex, 4, track.UseCaseEnv.Dept.ID);
            this.neuSpread1_Sheet1.SetText(rowIndex, 5, track.UseCaseEnv.Dept.Name);
            this.neuSpread1_Sheet1.SetText(rowIndex, 6, track.UseCaseEnv.OperTime.ToString());
            this.neuSpread1_Sheet1.SetText(rowIndex, 7, track.User01);
            this.neuSpread1_Sheet1.SetText(rowIndex, 8, track.User02);

            this.neuSpread1_Sheet1.Rows[rowIndex].Tag = track;
        }

        private void Setfp()
        {
            this.neuSpread1_Sheet1.Columns[0].Visible = false;
            this.neuSpread1_Sheet1.Columns[2].Visible = false;
            this.neuSpread1_Sheet1.Columns[4].Visible = false;
            this.neuSpread1_Sheet1.Columns[7].Visible = false;
        }

        private void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Clear();
            this.QueryCaseTrackRecord(this.tbCardID.Text.Trim());
        }

        private void ucCaseTrack_Load(object sender, EventArgs e)
        {
            this.Setfp();
        }
    }
}